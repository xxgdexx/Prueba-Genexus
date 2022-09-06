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
   public class tslibrobancos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A379LBBanCod = (int)(NumberUtil.Val( GetPar( "LBBanCod"), "."));
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A379LBBanCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A379LBBanCod = (int)(NumberUtil.Val( GetPar( "LBBanCod"), "."));
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = GetPar( "LBCBCod");
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A379LBBanCod, A380LBCBCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A379LBBanCod = (int)(NumberUtil.Val( GetPar( "LBBanCod"), "."));
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = GetPar( "LBCBCod");
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = GetPar( "LBRegistro");
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A379LBBanCod, A380LBCBCod, A381LBRegistro) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A382LBForCod = (int)(NumberUtil.Val( GetPar( "LBForCod"), "."));
            AssignAttri("", false, "A382LBForCod", StringUtil.LTrimStr( (decimal)(A382LBForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A382LBForCod) ;
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
            Form.Meta.addItem("description", "Libro Bancos - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tslibrobancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tslibrobancos( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSLIBROBANCOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Banco", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A379LBBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A379LBBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A379LBBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Cuenta Banco", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBCBCod_Internalname, StringUtil.RTrim( A380LBCBCod), StringUtil.RTrim( context.localUtil.Format( A380LBCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Registro", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBRegistro_Internalname, StringUtil.RTrim( A381LBRegistro), StringUtil.RTrim( context.localUtil.Format( A381LBRegistro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBRegistro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Año", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1051LBAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtLBAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1051LBAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1051LBAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Mes", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1084LBMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtLBMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1084LBMes), "Z9") : context.localUtil.Format( (decimal)(A1084LBMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Documento", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBDocumento_Internalname, StringUtil.RTrim( A1075LBDocumento), StringUtil.RTrim( context.localUtil.Format( A1075LBDocumento, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDocumento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDocumento_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Fecha", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLBFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLBFech_Internalname, context.localUtil.Format(A1079LBFech, "99/99/99"), context.localUtil.Format( A1079LBFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         GxWebStd.gx_bitmap( context, edtLBFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLBFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Tipo D/H", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBTipo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1070LBTipo), 1, 0, ".", "")), StringUtil.LTrim( ((edtLBTipo_Enabled!=0) ? context.localUtil.Format( (decimal)(A1070LBTipo), "9") : context.localUtil.Format( (decimal)(A1070LBTipo), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBTipo_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cheque", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBCheq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1056LBCheq), 1, 0, ".", "")), StringUtil.LTrim( ((edtLBCheq_Enabled!=0) ? context.localUtil.Format( (decimal)(A1056LBCheq), "9") : context.localUtil.Format( (decimal)(A1056LBCheq), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCheq_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCheq_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Concepto", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBConcepto_Internalname, StringUtil.RTrim( A1057LBConcepto), StringUtil.RTrim( context.localUtil.Format( A1057LBConcepto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBConcepto_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Beneficiario", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBBeneficia_Internalname, StringUtil.RTrim( A1054LBBeneficia), StringUtil.RTrim( context.localUtil.Format( A1054LBBeneficia, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBBeneficia_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBBeneficia_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Procesado", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBProcesado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1086LBProcesado), 1, 0, ".", "")), StringUtil.LTrim( ((edtLBProcesado_Enabled!=0) ? context.localUtil.Format( (decimal)(A1086LBProcesado), "9") : context.localUtil.Format( (decimal)(A1086LBProcesado), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBProcesado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBProcesado_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Total Item", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBItemTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1083LBItemTotal), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBItemTotal_Enabled!=0) ? context.localUtil.Format( (decimal)(A1083LBItemTotal), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1083LBItemTotal), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBItemTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBItemTotal_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Tipo de Cambio", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1091LBTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtLBTipCmb_Enabled!=0) ? context.localUtil.Format( A1091LBTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1091LBTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Estado", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBEstado_Internalname, StringUtil.RTrim( A1078LBEstado), StringUtil.RTrim( context.localUtil.Format( A1078LBEstado, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBEstado_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Año", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1097LBVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtLBVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1097LBVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1097LBVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Mes", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098LBVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtLBVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1098LBVouMes), "Z9") : context.localUtil.Format( (decimal)(A1098LBVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Tipo Asiento", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1089LBTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1089LBTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1089LBTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "N° Asiento", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBVouNum_Internalname, StringUtil.RTrim( A1099LBVouNum), StringUtil.RTrim( context.localUtil.Format( A1099LBVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Usuario C", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBUsuCod_Internalname, StringUtil.RTrim( A1093LBUsuCod), StringUtil.RTrim( context.localUtil.Format( A1093LBUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Fecha C", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLBUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLBUsuFec_Internalname, context.localUtil.TToC( A1095LBUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1095LBUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         GxWebStd.gx_bitmap( context, edtLBUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLBUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Usuario M", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBUsuCodM_Internalname, StringUtil.RTrim( A1094LBUsuCodM), StringUtil.RTrim( context.localUtil.Format( A1094LBUsuCodM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBUsuCodM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBUsuCodM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Fecha M", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLBUsuFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLBUsuFecM_Internalname, context.localUtil.TToC( A1096LBUsuFecM, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1096LBUsuFecM, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBUsuFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBUsuFecM_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         GxWebStd.gx_bitmap( context, edtLBUsuFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLBUsuFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Forma de Pago", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A382LBForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A382LBForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A382LBForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Estado Check", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBCheck_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1055LBCheck), 1, 0, ".", "")), StringUtil.LTrim( ((edtLBCheck_Enabled!=0) ? context.localUtil.Format( (decimal)(A1055LBCheck), "9") : context.localUtil.Format( (decimal)(A1055LBCheck), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCheck_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCheck_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Usuario Check 1", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBCUsuCod1_Internalname, StringUtil.RTrim( A1062LBCUsuCod1), StringUtil.RTrim( context.localUtil.Format( A1062LBCUsuCod1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCUsuCod1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCUsuCod1_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Usuario Check 2", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLBCUsuCod2_Internalname, StringUtil.RTrim( A1063LBCUsuCod2), StringUtil.RTrim( context.localUtil.Format( A1063LBCUsuCod2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBCUsuCod2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBCUsuCod2_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Total Debe", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBDebeTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1069LBDebeTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtLBDebeTot_Enabled!=0) ? context.localUtil.Format( A1069LBDebeTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1069LBDebeTot, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBDebeTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBDebeTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Total Haber", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBHaberTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1082LBHaberTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtLBHaberTot_Enabled!=0) ? context.localUtil.Format( A1082LBHaberTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1082LBHaberTot, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBHaberTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBHaberTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Saldo", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBTSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1071LBTSaldo, 17, 2, ".", "")), StringUtil.LTrim( ((edtLBTSaldo_Enabled!=0) ? context.localUtil.Format( A1071LBTSaldo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1071LBTSaldo, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBTSaldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBTSaldo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Debe Detalle", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBTDebe_Internalname, StringUtil.LTrim( StringUtil.NToC( A1072LBTDebe, 17, 2, ".", "")), StringUtil.LTrim( ((edtLBTDebe_Enabled!=0) ? context.localUtil.Format( A1072LBTDebe, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1072LBTDebe, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBTDebe_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBTDebe_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Haber Detalle", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBTHaber_Internalname, StringUtil.LTrim( StringUtil.NToC( A1073LBTHaber, 17, 2, ".", "")), StringUtil.LTrim( ((edtLBTHaber_Enabled!=0) ? context.localUtil.Format( A1073LBTHaber, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1073LBTHaber, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBTHaber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBTHaber_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Forma de Pago", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBForDsc_Internalname, StringUtil.RTrim( A1080LBForDsc), StringUtil.RTrim( context.localUtil.Format( A1080LBForDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBForDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBForDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Moneda", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1085LBMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLBMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1085LBMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1085LBMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Cod. Sunat", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLBForSunat_Internalname, StringUtil.RTrim( A1081LBForSunat), StringUtil.RTrim( context.localUtil.Format( A1081LBForSunat, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLBForSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLBForSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSLIBROBANCOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 194,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 195,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 197,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSLIBROBANCOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSLIBROBANCOS.htm");
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
            Z379LBBanCod = (int)(context.localUtil.CToN( cgiGet( "Z379LBBanCod"), ".", ","));
            Z380LBCBCod = cgiGet( "Z380LBCBCod");
            Z381LBRegistro = cgiGet( "Z381LBRegistro");
            Z1051LBAno = (short)(context.localUtil.CToN( cgiGet( "Z1051LBAno"), ".", ","));
            Z1084LBMes = (short)(context.localUtil.CToN( cgiGet( "Z1084LBMes"), ".", ","));
            Z1075LBDocumento = cgiGet( "Z1075LBDocumento");
            Z1079LBFech = context.localUtil.CToD( cgiGet( "Z1079LBFech"), 0);
            Z1070LBTipo = (short)(context.localUtil.CToN( cgiGet( "Z1070LBTipo"), ".", ","));
            Z1056LBCheq = (short)(context.localUtil.CToN( cgiGet( "Z1056LBCheq"), ".", ","));
            Z1057LBConcepto = cgiGet( "Z1057LBConcepto");
            Z1054LBBeneficia = cgiGet( "Z1054LBBeneficia");
            Z1086LBProcesado = (short)(context.localUtil.CToN( cgiGet( "Z1086LBProcesado"), ".", ","));
            Z1083LBItemTotal = (int)(context.localUtil.CToN( cgiGet( "Z1083LBItemTotal"), ".", ","));
            Z1091LBTipCmb = context.localUtil.CToN( cgiGet( "Z1091LBTipCmb"), ".", ",");
            Z1078LBEstado = cgiGet( "Z1078LBEstado");
            Z1097LBVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1097LBVouAno"), ".", ","));
            Z1098LBVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1098LBVouMes"), ".", ","));
            Z1089LBTASICod = (int)(context.localUtil.CToN( cgiGet( "Z1089LBTASICod"), ".", ","));
            Z1099LBVouNum = cgiGet( "Z1099LBVouNum");
            Z1093LBUsuCod = cgiGet( "Z1093LBUsuCod");
            Z1095LBUsuFec = context.localUtil.CToT( cgiGet( "Z1095LBUsuFec"), 0);
            Z1094LBUsuCodM = cgiGet( "Z1094LBUsuCodM");
            Z1096LBUsuFecM = context.localUtil.CToT( cgiGet( "Z1096LBUsuFecM"), 0);
            Z1055LBCheck = (short)(context.localUtil.CToN( cgiGet( "Z1055LBCheck"), ".", ","));
            Z1062LBCUsuCod1 = cgiGet( "Z1062LBCUsuCod1");
            Z1063LBCUsuCod2 = cgiGet( "Z1063LBCUsuCod2");
            Z1052LBAnticipoAplic = context.localUtil.CToN( cgiGet( "Z1052LBAnticipoAplic"), ".", ",");
            Z382LBForCod = (int)(context.localUtil.CToN( cgiGet( "Z382LBForCod"), ".", ","));
            A1052LBAnticipoAplic = context.localUtil.CToN( cgiGet( "Z1052LBAnticipoAplic"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1052LBAnticipoAplic = context.localUtil.CToN( cgiGet( "LBANTICIPOAPLIC"), ".", ",");
            A1088LBSaldoAnticipo = context.localUtil.CToN( cgiGet( "LBSALDOANTICIPO"), ".", ",");
            A1053LBBanAbr = cgiGet( "LBBANABR");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLBBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A379LBBanCod = 0;
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            }
            else
            {
               A379LBBanCod = (int)(context.localUtil.CToN( cgiGet( edtLBBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            }
            A380LBCBCod = cgiGet( edtLBCBCod_Internalname);
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = cgiGet( edtLBRegistro_Internalname);
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBANO");
               AnyError = 1;
               GX_FocusControl = edtLBAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1051LBAno = 0;
               AssignAttri("", false, "A1051LBAno", StringUtil.LTrimStr( (decimal)(A1051LBAno), 4, 0));
            }
            else
            {
               A1051LBAno = (short)(context.localUtil.CToN( cgiGet( edtLBAno_Internalname), ".", ","));
               AssignAttri("", false, "A1051LBAno", StringUtil.LTrimStr( (decimal)(A1051LBAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBMES");
               AnyError = 1;
               GX_FocusControl = edtLBMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1084LBMes = 0;
               AssignAttri("", false, "A1084LBMes", StringUtil.LTrimStr( (decimal)(A1084LBMes), 2, 0));
            }
            else
            {
               A1084LBMes = (short)(context.localUtil.CToN( cgiGet( edtLBMes_Internalname), ".", ","));
               AssignAttri("", false, "A1084LBMes", StringUtil.LTrimStr( (decimal)(A1084LBMes), 2, 0));
            }
            A1075LBDocumento = cgiGet( edtLBDocumento_Internalname);
            AssignAttri("", false, "A1075LBDocumento", A1075LBDocumento);
            if ( context.localUtil.VCDate( cgiGet( edtLBFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "LBFECH");
               AnyError = 1;
               GX_FocusControl = edtLBFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1079LBFech = DateTime.MinValue;
               AssignAttri("", false, "A1079LBFech", context.localUtil.Format(A1079LBFech, "99/99/99"));
            }
            else
            {
               A1079LBFech = context.localUtil.CToD( cgiGet( edtLBFech_Internalname), 2);
               AssignAttri("", false, "A1079LBFech", context.localUtil.Format(A1079LBFech, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBTipo_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBTipo_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBTIPO");
               AnyError = 1;
               GX_FocusControl = edtLBTipo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1070LBTipo = 0;
               AssignAttri("", false, "A1070LBTipo", StringUtil.Str( (decimal)(A1070LBTipo), 1, 0));
            }
            else
            {
               A1070LBTipo = (short)(context.localUtil.CToN( cgiGet( edtLBTipo_Internalname), ".", ","));
               AssignAttri("", false, "A1070LBTipo", StringUtil.Str( (decimal)(A1070LBTipo), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBCheq_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBCheq_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBCHEQ");
               AnyError = 1;
               GX_FocusControl = edtLBCheq_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1056LBCheq = 0;
               AssignAttri("", false, "A1056LBCheq", StringUtil.Str( (decimal)(A1056LBCheq), 1, 0));
            }
            else
            {
               A1056LBCheq = (short)(context.localUtil.CToN( cgiGet( edtLBCheq_Internalname), ".", ","));
               AssignAttri("", false, "A1056LBCheq", StringUtil.Str( (decimal)(A1056LBCheq), 1, 0));
            }
            A1057LBConcepto = cgiGet( edtLBConcepto_Internalname);
            AssignAttri("", false, "A1057LBConcepto", A1057LBConcepto);
            A1054LBBeneficia = cgiGet( edtLBBeneficia_Internalname);
            AssignAttri("", false, "A1054LBBeneficia", A1054LBBeneficia);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBProcesado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBProcesado_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBPROCESADO");
               AnyError = 1;
               GX_FocusControl = edtLBProcesado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1086LBProcesado = 0;
               AssignAttri("", false, "A1086LBProcesado", StringUtil.Str( (decimal)(A1086LBProcesado), 1, 0));
            }
            else
            {
               A1086LBProcesado = (short)(context.localUtil.CToN( cgiGet( edtLBProcesado_Internalname), ".", ","));
               AssignAttri("", false, "A1086LBProcesado", StringUtil.Str( (decimal)(A1086LBProcesado), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBItemTotal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBItemTotal_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBITEMTOTAL");
               AnyError = 1;
               GX_FocusControl = edtLBItemTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1083LBItemTotal = 0;
               AssignAttri("", false, "A1083LBItemTotal", StringUtil.LTrimStr( (decimal)(A1083LBItemTotal), 6, 0));
            }
            else
            {
               A1083LBItemTotal = (int)(context.localUtil.CToN( cgiGet( edtLBItemTotal_Internalname), ".", ","));
               AssignAttri("", false, "A1083LBItemTotal", StringUtil.LTrimStr( (decimal)(A1083LBItemTotal), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtLBTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1091LBTipCmb = 0;
               AssignAttri("", false, "A1091LBTipCmb", StringUtil.LTrimStr( A1091LBTipCmb, 15, 5));
            }
            else
            {
               A1091LBTipCmb = context.localUtil.CToN( cgiGet( edtLBTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1091LBTipCmb", StringUtil.LTrimStr( A1091LBTipCmb, 15, 5));
            }
            A1078LBEstado = cgiGet( edtLBEstado_Internalname);
            AssignAttri("", false, "A1078LBEstado", A1078LBEstado);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBVOUANO");
               AnyError = 1;
               GX_FocusControl = edtLBVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1097LBVouAno = 0;
               AssignAttri("", false, "A1097LBVouAno", StringUtil.LTrimStr( (decimal)(A1097LBVouAno), 4, 0));
            }
            else
            {
               A1097LBVouAno = (short)(context.localUtil.CToN( cgiGet( edtLBVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1097LBVouAno", StringUtil.LTrimStr( (decimal)(A1097LBVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBVOUMES");
               AnyError = 1;
               GX_FocusControl = edtLBVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1098LBVouMes = 0;
               AssignAttri("", false, "A1098LBVouMes", StringUtil.LTrimStr( (decimal)(A1098LBVouMes), 2, 0));
            }
            else
            {
               A1098LBVouMes = (short)(context.localUtil.CToN( cgiGet( edtLBVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1098LBVouMes", StringUtil.LTrimStr( (decimal)(A1098LBVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBTASICOD");
               AnyError = 1;
               GX_FocusControl = edtLBTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1089LBTASICod = 0;
               AssignAttri("", false, "A1089LBTASICod", StringUtil.LTrimStr( (decimal)(A1089LBTASICod), 6, 0));
            }
            else
            {
               A1089LBTASICod = (int)(context.localUtil.CToN( cgiGet( edtLBTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A1089LBTASICod", StringUtil.LTrimStr( (decimal)(A1089LBTASICod), 6, 0));
            }
            A1099LBVouNum = cgiGet( edtLBVouNum_Internalname);
            AssignAttri("", false, "A1099LBVouNum", A1099LBVouNum);
            A1093LBUsuCod = cgiGet( edtLBUsuCod_Internalname);
            AssignAttri("", false, "A1093LBUsuCod", A1093LBUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtLBUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha C"}), 1, "LBUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtLBUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1095LBUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1095LBUsuFec", context.localUtil.TToC( A1095LBUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1095LBUsuFec = context.localUtil.CToT( cgiGet( edtLBUsuFec_Internalname));
               AssignAttri("", false, "A1095LBUsuFec", context.localUtil.TToC( A1095LBUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            A1094LBUsuCodM = cgiGet( edtLBUsuCodM_Internalname);
            AssignAttri("", false, "A1094LBUsuCodM", A1094LBUsuCodM);
            if ( context.localUtil.VCDateTime( cgiGet( edtLBUsuFecM_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha M"}), 1, "LBUSUFECM");
               AnyError = 1;
               GX_FocusControl = edtLBUsuFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1096LBUsuFecM = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1096LBUsuFecM", context.localUtil.TToC( A1096LBUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1096LBUsuFecM = context.localUtil.CToT( cgiGet( edtLBUsuFecM_Internalname));
               AssignAttri("", false, "A1096LBUsuFecM", context.localUtil.TToC( A1096LBUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLBForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A382LBForCod = 0;
               AssignAttri("", false, "A382LBForCod", StringUtil.LTrimStr( (decimal)(A382LBForCod), 6, 0));
            }
            else
            {
               A382LBForCod = (int)(context.localUtil.CToN( cgiGet( edtLBForCod_Internalname), ".", ","));
               AssignAttri("", false, "A382LBForCod", StringUtil.LTrimStr( (decimal)(A382LBForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLBCheck_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLBCheck_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LBCHECK");
               AnyError = 1;
               GX_FocusControl = edtLBCheck_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1055LBCheck = 0;
               AssignAttri("", false, "A1055LBCheck", StringUtil.Str( (decimal)(A1055LBCheck), 1, 0));
            }
            else
            {
               A1055LBCheck = (short)(context.localUtil.CToN( cgiGet( edtLBCheck_Internalname), ".", ","));
               AssignAttri("", false, "A1055LBCheck", StringUtil.Str( (decimal)(A1055LBCheck), 1, 0));
            }
            A1062LBCUsuCod1 = cgiGet( edtLBCUsuCod1_Internalname);
            AssignAttri("", false, "A1062LBCUsuCod1", A1062LBCUsuCod1);
            A1063LBCUsuCod2 = cgiGet( edtLBCUsuCod2_Internalname);
            AssignAttri("", false, "A1063LBCUsuCod2", A1063LBCUsuCod2);
            A1069LBDebeTot = context.localUtil.CToN( cgiGet( edtLBDebeTot_Internalname), ".", ",");
            AssignAttri("", false, "A1069LBDebeTot", StringUtil.LTrimStr( A1069LBDebeTot, 15, 2));
            A1082LBHaberTot = context.localUtil.CToN( cgiGet( edtLBHaberTot_Internalname), ".", ",");
            AssignAttri("", false, "A1082LBHaberTot", StringUtil.LTrimStr( A1082LBHaberTot, 15, 2));
            A1071LBTSaldo = context.localUtil.CToN( cgiGet( edtLBTSaldo_Internalname), ".", ",");
            AssignAttri("", false, "A1071LBTSaldo", StringUtil.LTrimStr( A1071LBTSaldo, 15, 2));
            A1072LBTDebe = context.localUtil.CToN( cgiGet( edtLBTDebe_Internalname), ".", ",");
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = context.localUtil.CToN( cgiGet( edtLBTHaber_Internalname), ".", ",");
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
            A1080LBForDsc = cgiGet( edtLBForDsc_Internalname);
            AssignAttri("", false, "A1080LBForDsc", A1080LBForDsc);
            A1085LBMonCod = (int)(context.localUtil.CToN( cgiGet( edtLBMonCod_Internalname), ".", ","));
            AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrimStr( (decimal)(A1085LBMonCod), 6, 0));
            A1081LBForSunat = cgiGet( edtLBForSunat_Internalname);
            AssignAttri("", false, "A1081LBForSunat", A1081LBForSunat);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"TSLIBROBANCOS");
            forbiddenHiddens.Add("LBAnticipoAplic", context.localUtil.Format( A1052LBAnticipoAplic, "ZZZZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("tslibrobancos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A379LBBanCod = (int)(NumberUtil.Val( GetPar( "LBBanCod"), "."));
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = GetPar( "LBCBCod");
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = GetPar( "LBRegistro");
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
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
               InitAll59176( ) ;
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
         DisableAttributes59176( ) ;
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

      protected void CONFIRM_590( )
      {
         BeforeValidate59176( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls59176( ) ;
            }
            else
            {
               CheckExtendedTable59176( ) ;
               if ( AnyError == 0 )
               {
                  ZM59176( 9) ;
                  ZM59176( 10) ;
                  ZM59176( 11) ;
                  ZM59176( 12) ;
               }
               CloseExtendedTableCursors59176( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues590( ) ;
         }
      }

      protected void ResetCaption590( )
      {
      }

      protected void ZM59176( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1051LBAno = T00593_A1051LBAno[0];
               Z1084LBMes = T00593_A1084LBMes[0];
               Z1075LBDocumento = T00593_A1075LBDocumento[0];
               Z1079LBFech = T00593_A1079LBFech[0];
               Z1070LBTipo = T00593_A1070LBTipo[0];
               Z1056LBCheq = T00593_A1056LBCheq[0];
               Z1057LBConcepto = T00593_A1057LBConcepto[0];
               Z1054LBBeneficia = T00593_A1054LBBeneficia[0];
               Z1086LBProcesado = T00593_A1086LBProcesado[0];
               Z1083LBItemTotal = T00593_A1083LBItemTotal[0];
               Z1091LBTipCmb = T00593_A1091LBTipCmb[0];
               Z1078LBEstado = T00593_A1078LBEstado[0];
               Z1097LBVouAno = T00593_A1097LBVouAno[0];
               Z1098LBVouMes = T00593_A1098LBVouMes[0];
               Z1089LBTASICod = T00593_A1089LBTASICod[0];
               Z1099LBVouNum = T00593_A1099LBVouNum[0];
               Z1093LBUsuCod = T00593_A1093LBUsuCod[0];
               Z1095LBUsuFec = T00593_A1095LBUsuFec[0];
               Z1094LBUsuCodM = T00593_A1094LBUsuCodM[0];
               Z1096LBUsuFecM = T00593_A1096LBUsuFecM[0];
               Z1055LBCheck = T00593_A1055LBCheck[0];
               Z1062LBCUsuCod1 = T00593_A1062LBCUsuCod1[0];
               Z1063LBCUsuCod2 = T00593_A1063LBCUsuCod2[0];
               Z1052LBAnticipoAplic = T00593_A1052LBAnticipoAplic[0];
               Z382LBForCod = T00593_A382LBForCod[0];
            }
            else
            {
               Z1051LBAno = A1051LBAno;
               Z1084LBMes = A1084LBMes;
               Z1075LBDocumento = A1075LBDocumento;
               Z1079LBFech = A1079LBFech;
               Z1070LBTipo = A1070LBTipo;
               Z1056LBCheq = A1056LBCheq;
               Z1057LBConcepto = A1057LBConcepto;
               Z1054LBBeneficia = A1054LBBeneficia;
               Z1086LBProcesado = A1086LBProcesado;
               Z1083LBItemTotal = A1083LBItemTotal;
               Z1091LBTipCmb = A1091LBTipCmb;
               Z1078LBEstado = A1078LBEstado;
               Z1097LBVouAno = A1097LBVouAno;
               Z1098LBVouMes = A1098LBVouMes;
               Z1089LBTASICod = A1089LBTASICod;
               Z1099LBVouNum = A1099LBVouNum;
               Z1093LBUsuCod = A1093LBUsuCod;
               Z1095LBUsuFec = A1095LBUsuFec;
               Z1094LBUsuCodM = A1094LBUsuCodM;
               Z1096LBUsuFecM = A1096LBUsuFecM;
               Z1055LBCheck = A1055LBCheck;
               Z1062LBCUsuCod1 = A1062LBCUsuCod1;
               Z1063LBCUsuCod2 = A1063LBCUsuCod2;
               Z1052LBAnticipoAplic = A1052LBAnticipoAplic;
               Z382LBForCod = A382LBForCod;
            }
         }
         if ( GX_JID == -8 )
         {
            Z381LBRegistro = A381LBRegistro;
            Z1051LBAno = A1051LBAno;
            Z1084LBMes = A1084LBMes;
            Z1075LBDocumento = A1075LBDocumento;
            Z1079LBFech = A1079LBFech;
            Z1070LBTipo = A1070LBTipo;
            Z1056LBCheq = A1056LBCheq;
            Z1057LBConcepto = A1057LBConcepto;
            Z1054LBBeneficia = A1054LBBeneficia;
            Z1086LBProcesado = A1086LBProcesado;
            Z1083LBItemTotal = A1083LBItemTotal;
            Z1091LBTipCmb = A1091LBTipCmb;
            Z1078LBEstado = A1078LBEstado;
            Z1097LBVouAno = A1097LBVouAno;
            Z1098LBVouMes = A1098LBVouMes;
            Z1089LBTASICod = A1089LBTASICod;
            Z1099LBVouNum = A1099LBVouNum;
            Z1093LBUsuCod = A1093LBUsuCod;
            Z1095LBUsuFec = A1095LBUsuFec;
            Z1094LBUsuCodM = A1094LBUsuCodM;
            Z1096LBUsuFecM = A1096LBUsuFecM;
            Z1055LBCheck = A1055LBCheck;
            Z1062LBCUsuCod1 = A1062LBCUsuCod1;
            Z1063LBCUsuCod2 = A1063LBCUsuCod2;
            Z1052LBAnticipoAplic = A1052LBAnticipoAplic;
            Z379LBBanCod = A379LBBanCod;
            Z380LBCBCod = A380LBCBCod;
            Z382LBForCod = A382LBForCod;
            Z1053LBBanAbr = A1053LBBanAbr;
            Z1085LBMonCod = A1085LBMonCod;
            Z1080LBForDsc = A1080LBForDsc;
            Z1081LBForSunat = A1081LBForSunat;
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

      protected void Load59176( )
      {
         /* Using cursor T00599 */
         pr_default.execute(6, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound176 = 1;
            A1051LBAno = T00599_A1051LBAno[0];
            AssignAttri("", false, "A1051LBAno", StringUtil.LTrimStr( (decimal)(A1051LBAno), 4, 0));
            A1053LBBanAbr = T00599_A1053LBBanAbr[0];
            A1084LBMes = T00599_A1084LBMes[0];
            AssignAttri("", false, "A1084LBMes", StringUtil.LTrimStr( (decimal)(A1084LBMes), 2, 0));
            A1075LBDocumento = T00599_A1075LBDocumento[0];
            AssignAttri("", false, "A1075LBDocumento", A1075LBDocumento);
            A1079LBFech = T00599_A1079LBFech[0];
            AssignAttri("", false, "A1079LBFech", context.localUtil.Format(A1079LBFech, "99/99/99"));
            A1070LBTipo = T00599_A1070LBTipo[0];
            AssignAttri("", false, "A1070LBTipo", StringUtil.Str( (decimal)(A1070LBTipo), 1, 0));
            A1056LBCheq = T00599_A1056LBCheq[0];
            AssignAttri("", false, "A1056LBCheq", StringUtil.Str( (decimal)(A1056LBCheq), 1, 0));
            A1057LBConcepto = T00599_A1057LBConcepto[0];
            AssignAttri("", false, "A1057LBConcepto", A1057LBConcepto);
            A1054LBBeneficia = T00599_A1054LBBeneficia[0];
            AssignAttri("", false, "A1054LBBeneficia", A1054LBBeneficia);
            A1086LBProcesado = T00599_A1086LBProcesado[0];
            AssignAttri("", false, "A1086LBProcesado", StringUtil.Str( (decimal)(A1086LBProcesado), 1, 0));
            A1083LBItemTotal = T00599_A1083LBItemTotal[0];
            AssignAttri("", false, "A1083LBItemTotal", StringUtil.LTrimStr( (decimal)(A1083LBItemTotal), 6, 0));
            A1091LBTipCmb = T00599_A1091LBTipCmb[0];
            AssignAttri("", false, "A1091LBTipCmb", StringUtil.LTrimStr( A1091LBTipCmb, 15, 5));
            A1078LBEstado = T00599_A1078LBEstado[0];
            AssignAttri("", false, "A1078LBEstado", A1078LBEstado);
            A1097LBVouAno = T00599_A1097LBVouAno[0];
            AssignAttri("", false, "A1097LBVouAno", StringUtil.LTrimStr( (decimal)(A1097LBVouAno), 4, 0));
            A1098LBVouMes = T00599_A1098LBVouMes[0];
            AssignAttri("", false, "A1098LBVouMes", StringUtil.LTrimStr( (decimal)(A1098LBVouMes), 2, 0));
            A1089LBTASICod = T00599_A1089LBTASICod[0];
            AssignAttri("", false, "A1089LBTASICod", StringUtil.LTrimStr( (decimal)(A1089LBTASICod), 6, 0));
            A1099LBVouNum = T00599_A1099LBVouNum[0];
            AssignAttri("", false, "A1099LBVouNum", A1099LBVouNum);
            A1093LBUsuCod = T00599_A1093LBUsuCod[0];
            AssignAttri("", false, "A1093LBUsuCod", A1093LBUsuCod);
            A1095LBUsuFec = T00599_A1095LBUsuFec[0];
            AssignAttri("", false, "A1095LBUsuFec", context.localUtil.TToC( A1095LBUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1094LBUsuCodM = T00599_A1094LBUsuCodM[0];
            AssignAttri("", false, "A1094LBUsuCodM", A1094LBUsuCodM);
            A1096LBUsuFecM = T00599_A1096LBUsuFecM[0];
            AssignAttri("", false, "A1096LBUsuFecM", context.localUtil.TToC( A1096LBUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            A1055LBCheck = T00599_A1055LBCheck[0];
            AssignAttri("", false, "A1055LBCheck", StringUtil.Str( (decimal)(A1055LBCheck), 1, 0));
            A1062LBCUsuCod1 = T00599_A1062LBCUsuCod1[0];
            AssignAttri("", false, "A1062LBCUsuCod1", A1062LBCUsuCod1);
            A1063LBCUsuCod2 = T00599_A1063LBCUsuCod2[0];
            AssignAttri("", false, "A1063LBCUsuCod2", A1063LBCUsuCod2);
            A1080LBForDsc = T00599_A1080LBForDsc[0];
            AssignAttri("", false, "A1080LBForDsc", A1080LBForDsc);
            A1081LBForSunat = T00599_A1081LBForSunat[0];
            AssignAttri("", false, "A1081LBForSunat", A1081LBForSunat);
            A1052LBAnticipoAplic = T00599_A1052LBAnticipoAplic[0];
            A382LBForCod = T00599_A382LBForCod[0];
            AssignAttri("", false, "A382LBForCod", StringUtil.LTrimStr( (decimal)(A382LBForCod), 6, 0));
            A1085LBMonCod = T00599_A1085LBMonCod[0];
            AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrimStr( (decimal)(A1085LBMonCod), 6, 0));
            ZM59176( -8) ;
         }
         pr_default.close(6);
         OnLoadActions59176( ) ;
      }

      protected void OnLoadActions59176( )
      {
         /* Using cursor T00598 */
         pr_default.execute(5, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1072LBTDebe = T00598_A1072LBTDebe[0];
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = T00598_A1073LBTHaber[0];
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         else
         {
            A1072LBTDebe = 0;
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = 0;
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         pr_default.close(5);
         A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
         AssignAttri("", false, "A1071LBTSaldo", StringUtil.LTrimStr( A1071LBTSaldo, 15, 2));
         A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
         AssignAttri("", false, "A1082LBHaberTot", StringUtil.LTrimStr( A1082LBHaberTot, 15, 2));
         A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
         AssignAttri("", false, "A1069LBDebeTot", StringUtil.LTrimStr( A1069LBDebeTot, 15, 2));
         A1088LBSaldoAnticipo = (decimal)(A1073LBTHaber-A1052LBAnticipoAplic);
         AssignAttri("", false, "A1088LBSaldoAnticipo", StringUtil.LTrimStr( A1088LBSaldoAnticipo, 15, 2));
      }

      protected void CheckExtendedTable59176( )
      {
         nIsDirty_176 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00594 */
         pr_default.execute(2, new Object[] {A379LBBanCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1053LBBanAbr = T00594_A1053LBBanAbr[0];
         pr_default.close(2);
         /* Using cursor T00595 */
         pr_default.execute(3, new Object[] {A379LBBanCod, A380LBCBCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBCBCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1085LBMonCod = T00595_A1085LBMonCod[0];
         AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrimStr( (decimal)(A1085LBMonCod), 6, 0));
         pr_default.close(3);
         /* Using cursor T00598 */
         pr_default.execute(5, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A1072LBTDebe = T00598_A1072LBTDebe[0];
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = T00598_A1073LBTHaber[0];
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         else
         {
            nIsDirty_176 = 1;
            A1072LBTDebe = 0;
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            nIsDirty_176 = 1;
            A1073LBTHaber = 0;
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         pr_default.close(5);
         nIsDirty_176 = 1;
         A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
         AssignAttri("", false, "A1071LBTSaldo", StringUtil.LTrimStr( A1071LBTSaldo, 15, 2));
         nIsDirty_176 = 1;
         A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
         AssignAttri("", false, "A1082LBHaberTot", StringUtil.LTrimStr( A1082LBHaberTot, 15, 2));
         nIsDirty_176 = 1;
         A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
         AssignAttri("", false, "A1069LBDebeTot", StringUtil.LTrimStr( A1069LBDebeTot, 15, 2));
         nIsDirty_176 = 1;
         A1088LBSaldoAnticipo = (decimal)(A1073LBTHaber-A1052LBAnticipoAplic);
         AssignAttri("", false, "A1088LBSaldoAnticipo", StringUtil.LTrimStr( A1088LBSaldoAnticipo, 15, 2));
         if ( ! ( (DateTime.MinValue==A1079LBFech) || ( DateTimeUtil.ResetTime ( A1079LBFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "LBFECH");
            AnyError = 1;
            GX_FocusControl = edtLBFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1095LBUsuFec) || ( A1095LBUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha C fuera de rango", "OutOfRange", 1, "LBUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtLBUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1096LBUsuFecM) || ( A1096LBUsuFecM >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha M fuera de rango", "OutOfRange", 1, "LBUSUFECM");
            AnyError = 1;
            GX_FocusControl = edtLBUsuFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00596 */
         pr_default.execute(4, new Object[] {A382LBForCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Libro Bancos Forma Pago'.", "ForeignKeyNotFound", 1, "LBFORCOD");
            AnyError = 1;
            GX_FocusControl = edtLBForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1080LBForDsc = T00596_A1080LBForDsc[0];
         AssignAttri("", false, "A1080LBForDsc", A1080LBForDsc);
         A1081LBForSunat = T00596_A1081LBForSunat[0];
         AssignAttri("", false, "A1081LBForSunat", A1081LBForSunat);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors59176( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_9( int A379LBBanCod )
      {
         /* Using cursor T005910 */
         pr_default.execute(7, new Object[] {A379LBBanCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1053LBBanAbr = T005910_A1053LBBanAbr[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1053LBBanAbr))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_10( int A379LBBanCod ,
                                string A380LBCBCod )
      {
         /* Using cursor T005911 */
         pr_default.execute(8, new Object[] {A379LBBanCod, A380LBCBCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBCBCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1085LBMonCod = T005911_A1085LBMonCod[0];
         AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrimStr( (decimal)(A1085LBMonCod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1085LBMonCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_12( int A379LBBanCod ,
                                string A380LBCBCod ,
                                string A381LBRegistro )
      {
         /* Using cursor T005913 */
         pr_default.execute(9, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(9) != 101) )
         {
            A1072LBTDebe = T005913_A1072LBTDebe[0];
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = T005913_A1073LBTHaber[0];
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         else
         {
            A1072LBTDebe = 0;
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = 0;
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1072LBTDebe, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1073LBTHaber, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_11( int A382LBForCod )
      {
         /* Using cursor T005914 */
         pr_default.execute(10, new Object[] {A382LBForCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Libro Bancos Forma Pago'.", "ForeignKeyNotFound", 1, "LBFORCOD");
            AnyError = 1;
            GX_FocusControl = edtLBForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1080LBForDsc = T005914_A1080LBForDsc[0];
         AssignAttri("", false, "A1080LBForDsc", A1080LBForDsc);
         A1081LBForSunat = T005914_A1081LBForSunat[0];
         AssignAttri("", false, "A1081LBForSunat", A1081LBForSunat);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1080LBForDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1081LBForSunat))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey59176( )
      {
         /* Using cursor T005915 */
         pr_default.execute(11, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound176 = 1;
         }
         else
         {
            RcdFound176 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00593 */
         pr_default.execute(1, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM59176( 8) ;
            RcdFound176 = 1;
            A381LBRegistro = T00593_A381LBRegistro[0];
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            A1051LBAno = T00593_A1051LBAno[0];
            AssignAttri("", false, "A1051LBAno", StringUtil.LTrimStr( (decimal)(A1051LBAno), 4, 0));
            A1084LBMes = T00593_A1084LBMes[0];
            AssignAttri("", false, "A1084LBMes", StringUtil.LTrimStr( (decimal)(A1084LBMes), 2, 0));
            A1075LBDocumento = T00593_A1075LBDocumento[0];
            AssignAttri("", false, "A1075LBDocumento", A1075LBDocumento);
            A1079LBFech = T00593_A1079LBFech[0];
            AssignAttri("", false, "A1079LBFech", context.localUtil.Format(A1079LBFech, "99/99/99"));
            A1070LBTipo = T00593_A1070LBTipo[0];
            AssignAttri("", false, "A1070LBTipo", StringUtil.Str( (decimal)(A1070LBTipo), 1, 0));
            A1056LBCheq = T00593_A1056LBCheq[0];
            AssignAttri("", false, "A1056LBCheq", StringUtil.Str( (decimal)(A1056LBCheq), 1, 0));
            A1057LBConcepto = T00593_A1057LBConcepto[0];
            AssignAttri("", false, "A1057LBConcepto", A1057LBConcepto);
            A1054LBBeneficia = T00593_A1054LBBeneficia[0];
            AssignAttri("", false, "A1054LBBeneficia", A1054LBBeneficia);
            A1086LBProcesado = T00593_A1086LBProcesado[0];
            AssignAttri("", false, "A1086LBProcesado", StringUtil.Str( (decimal)(A1086LBProcesado), 1, 0));
            A1083LBItemTotal = T00593_A1083LBItemTotal[0];
            AssignAttri("", false, "A1083LBItemTotal", StringUtil.LTrimStr( (decimal)(A1083LBItemTotal), 6, 0));
            A1091LBTipCmb = T00593_A1091LBTipCmb[0];
            AssignAttri("", false, "A1091LBTipCmb", StringUtil.LTrimStr( A1091LBTipCmb, 15, 5));
            A1078LBEstado = T00593_A1078LBEstado[0];
            AssignAttri("", false, "A1078LBEstado", A1078LBEstado);
            A1097LBVouAno = T00593_A1097LBVouAno[0];
            AssignAttri("", false, "A1097LBVouAno", StringUtil.LTrimStr( (decimal)(A1097LBVouAno), 4, 0));
            A1098LBVouMes = T00593_A1098LBVouMes[0];
            AssignAttri("", false, "A1098LBVouMes", StringUtil.LTrimStr( (decimal)(A1098LBVouMes), 2, 0));
            A1089LBTASICod = T00593_A1089LBTASICod[0];
            AssignAttri("", false, "A1089LBTASICod", StringUtil.LTrimStr( (decimal)(A1089LBTASICod), 6, 0));
            A1099LBVouNum = T00593_A1099LBVouNum[0];
            AssignAttri("", false, "A1099LBVouNum", A1099LBVouNum);
            A1093LBUsuCod = T00593_A1093LBUsuCod[0];
            AssignAttri("", false, "A1093LBUsuCod", A1093LBUsuCod);
            A1095LBUsuFec = T00593_A1095LBUsuFec[0];
            AssignAttri("", false, "A1095LBUsuFec", context.localUtil.TToC( A1095LBUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1094LBUsuCodM = T00593_A1094LBUsuCodM[0];
            AssignAttri("", false, "A1094LBUsuCodM", A1094LBUsuCodM);
            A1096LBUsuFecM = T00593_A1096LBUsuFecM[0];
            AssignAttri("", false, "A1096LBUsuFecM", context.localUtil.TToC( A1096LBUsuFecM, 8, 5, 0, 3, "/", ":", " "));
            A1055LBCheck = T00593_A1055LBCheck[0];
            AssignAttri("", false, "A1055LBCheck", StringUtil.Str( (decimal)(A1055LBCheck), 1, 0));
            A1062LBCUsuCod1 = T00593_A1062LBCUsuCod1[0];
            AssignAttri("", false, "A1062LBCUsuCod1", A1062LBCUsuCod1);
            A1063LBCUsuCod2 = T00593_A1063LBCUsuCod2[0];
            AssignAttri("", false, "A1063LBCUsuCod2", A1063LBCUsuCod2);
            A1052LBAnticipoAplic = T00593_A1052LBAnticipoAplic[0];
            A379LBBanCod = T00593_A379LBBanCod[0];
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = T00593_A380LBCBCod[0];
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A382LBForCod = T00593_A382LBForCod[0];
            AssignAttri("", false, "A382LBForCod", StringUtil.LTrimStr( (decimal)(A382LBForCod), 6, 0));
            Z379LBBanCod = A379LBBanCod;
            Z380LBCBCod = A380LBCBCod;
            Z381LBRegistro = A381LBRegistro;
            sMode176 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load59176( ) ;
            if ( AnyError == 1 )
            {
               RcdFound176 = 0;
               InitializeNonKey59176( ) ;
            }
            Gx_mode = sMode176;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound176 = 0;
            InitializeNonKey59176( ) ;
            sMode176 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode176;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey59176( ) ;
         if ( RcdFound176 == 0 )
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
         RcdFound176 = 0;
         /* Using cursor T005916 */
         pr_default.execute(12, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( T005916_A379LBBanCod[0] < A379LBBanCod ) || ( T005916_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005916_A380LBCBCod[0], A380LBCBCod) < 0 ) || ( StringUtil.StrCmp(T005916_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005916_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005916_A381LBRegistro[0], A381LBRegistro) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( T005916_A379LBBanCod[0] > A379LBBanCod ) || ( T005916_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005916_A380LBCBCod[0], A380LBCBCod) > 0 ) || ( StringUtil.StrCmp(T005916_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005916_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005916_A381LBRegistro[0], A381LBRegistro) > 0 ) ) )
            {
               A379LBBanCod = T005916_A379LBBanCod[0];
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = T005916_A380LBCBCod[0];
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = T005916_A381LBRegistro[0];
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
               RcdFound176 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound176 = 0;
         /* Using cursor T005917 */
         pr_default.execute(13, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T005917_A379LBBanCod[0] > A379LBBanCod ) || ( T005917_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005917_A380LBCBCod[0], A380LBCBCod) > 0 ) || ( StringUtil.StrCmp(T005917_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005917_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005917_A381LBRegistro[0], A381LBRegistro) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T005917_A379LBBanCod[0] < A379LBBanCod ) || ( T005917_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005917_A380LBCBCod[0], A380LBCBCod) < 0 ) || ( StringUtil.StrCmp(T005917_A380LBCBCod[0], A380LBCBCod) == 0 ) && ( T005917_A379LBBanCod[0] == A379LBBanCod ) && ( StringUtil.StrCmp(T005917_A381LBRegistro[0], A381LBRegistro) < 0 ) ) )
            {
               A379LBBanCod = T005917_A379LBBanCod[0];
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = T005917_A380LBCBCod[0];
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = T005917_A381LBRegistro[0];
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
               RcdFound176 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey59176( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert59176( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound176 == 1 )
            {
               if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) )
               {
                  A379LBBanCod = Z379LBBanCod;
                  AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
                  A380LBCBCod = Z380LBCBCod;
                  AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
                  A381LBRegistro = Z381LBRegistro;
                  AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LBBANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update59176( ) ;
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLBBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert59176( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LBBANCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLBBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLBBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert59176( ) ;
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
         if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) )
         {
            A379LBBanCod = Z379LBBanCod;
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = Z380LBCBCod;
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = Z381LBRegistro;
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLBBanCod_Internalname;
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
         GetKey59176( ) ;
         if ( RcdFound176 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "LBBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLBBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) )
            {
               A379LBBanCod = Z379LBBanCod;
               AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
               A380LBCBCod = Z380LBCBCod;
               AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
               A381LBRegistro = Z381LBRegistro;
               AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "LBBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLBBanCod_Internalname;
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
            if ( ( A379LBBanCod != Z379LBBanCod ) || ( StringUtil.StrCmp(A380LBCBCod, Z380LBCBCod) != 0 ) || ( StringUtil.StrCmp(A381LBRegistro, Z381LBRegistro) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LBBANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLBBanCod_Internalname;
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
         context.RollbackDataStores("tslibrobancos",pr_default);
         GX_FocusControl = edtLBAno_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_590( ) ;
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
         if ( RcdFound176 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLBAno_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart59176( ) ;
         if ( RcdFound176 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBAno_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd59176( ) ;
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
         if ( RcdFound176 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBAno_Internalname;
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
         if ( RcdFound176 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBAno_Internalname;
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
         ScanStart59176( ) ;
         if ( RcdFound176 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound176 != 0 )
            {
               ScanNext59176( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLBAno_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd59176( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency59176( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00592 */
            pr_default.execute(0, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSLIBROBANCOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1051LBAno != T00592_A1051LBAno[0] ) || ( Z1084LBMes != T00592_A1084LBMes[0] ) || ( StringUtil.StrCmp(Z1075LBDocumento, T00592_A1075LBDocumento[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1079LBFech ) != DateTimeUtil.ResetTime ( T00592_A1079LBFech[0] ) ) || ( Z1070LBTipo != T00592_A1070LBTipo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1056LBCheq != T00592_A1056LBCheq[0] ) || ( StringUtil.StrCmp(Z1057LBConcepto, T00592_A1057LBConcepto[0]) != 0 ) || ( StringUtil.StrCmp(Z1054LBBeneficia, T00592_A1054LBBeneficia[0]) != 0 ) || ( Z1086LBProcesado != T00592_A1086LBProcesado[0] ) || ( Z1083LBItemTotal != T00592_A1083LBItemTotal[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1091LBTipCmb != T00592_A1091LBTipCmb[0] ) || ( StringUtil.StrCmp(Z1078LBEstado, T00592_A1078LBEstado[0]) != 0 ) || ( Z1097LBVouAno != T00592_A1097LBVouAno[0] ) || ( Z1098LBVouMes != T00592_A1098LBVouMes[0] ) || ( Z1089LBTASICod != T00592_A1089LBTASICod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1099LBVouNum, T00592_A1099LBVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1093LBUsuCod, T00592_A1093LBUsuCod[0]) != 0 ) || ( Z1095LBUsuFec != T00592_A1095LBUsuFec[0] ) || ( StringUtil.StrCmp(Z1094LBUsuCodM, T00592_A1094LBUsuCodM[0]) != 0 ) || ( Z1096LBUsuFecM != T00592_A1096LBUsuFecM[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1055LBCheck != T00592_A1055LBCheck[0] ) || ( StringUtil.StrCmp(Z1062LBCUsuCod1, T00592_A1062LBCUsuCod1[0]) != 0 ) || ( StringUtil.StrCmp(Z1063LBCUsuCod2, T00592_A1063LBCUsuCod2[0]) != 0 ) || ( Z1052LBAnticipoAplic != T00592_A1052LBAnticipoAplic[0] ) || ( Z382LBForCod != T00592_A382LBForCod[0] ) )
            {
               if ( Z1051LBAno != T00592_A1051LBAno[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBAno");
                  GXUtil.WriteLogRaw("Old: ",Z1051LBAno);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1051LBAno[0]);
               }
               if ( Z1084LBMes != T00592_A1084LBMes[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBMes");
                  GXUtil.WriteLogRaw("Old: ",Z1084LBMes);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1084LBMes[0]);
               }
               if ( StringUtil.StrCmp(Z1075LBDocumento, T00592_A1075LBDocumento[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBDocumento");
                  GXUtil.WriteLogRaw("Old: ",Z1075LBDocumento);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1075LBDocumento[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1079LBFech ) != DateTimeUtil.ResetTime ( T00592_A1079LBFech[0] ) )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBFech");
                  GXUtil.WriteLogRaw("Old: ",Z1079LBFech);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1079LBFech[0]);
               }
               if ( Z1070LBTipo != T00592_A1070LBTipo[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1070LBTipo);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1070LBTipo[0]);
               }
               if ( Z1056LBCheq != T00592_A1056LBCheq[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBCheq");
                  GXUtil.WriteLogRaw("Old: ",Z1056LBCheq);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1056LBCheq[0]);
               }
               if ( StringUtil.StrCmp(Z1057LBConcepto, T00592_A1057LBConcepto[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1057LBConcepto);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1057LBConcepto[0]);
               }
               if ( StringUtil.StrCmp(Z1054LBBeneficia, T00592_A1054LBBeneficia[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBBeneficia");
                  GXUtil.WriteLogRaw("Old: ",Z1054LBBeneficia);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1054LBBeneficia[0]);
               }
               if ( Z1086LBProcesado != T00592_A1086LBProcesado[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBProcesado");
                  GXUtil.WriteLogRaw("Old: ",Z1086LBProcesado);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1086LBProcesado[0]);
               }
               if ( Z1083LBItemTotal != T00592_A1083LBItemTotal[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBItemTotal");
                  GXUtil.WriteLogRaw("Old: ",Z1083LBItemTotal);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1083LBItemTotal[0]);
               }
               if ( Z1091LBTipCmb != T00592_A1091LBTipCmb[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1091LBTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1091LBTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z1078LBEstado, T00592_A1078LBEstado[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBEstado");
                  GXUtil.WriteLogRaw("Old: ",Z1078LBEstado);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1078LBEstado[0]);
               }
               if ( Z1097LBVouAno != T00592_A1097LBVouAno[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1097LBVouAno);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1097LBVouAno[0]);
               }
               if ( Z1098LBVouMes != T00592_A1098LBVouMes[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1098LBVouMes);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1098LBVouMes[0]);
               }
               if ( Z1089LBTASICod != T00592_A1089LBTASICod[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z1089LBTASICod);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1089LBTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z1099LBVouNum, T00592_A1099LBVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1099LBVouNum);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1099LBVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1093LBUsuCod, T00592_A1093LBUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1093LBUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1093LBUsuCod[0]);
               }
               if ( Z1095LBUsuFec != T00592_A1095LBUsuFec[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1095LBUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1095LBUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z1094LBUsuCodM, T00592_A1094LBUsuCodM[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBUsuCodM");
                  GXUtil.WriteLogRaw("Old: ",Z1094LBUsuCodM);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1094LBUsuCodM[0]);
               }
               if ( Z1096LBUsuFecM != T00592_A1096LBUsuFecM[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBUsuFecM");
                  GXUtil.WriteLogRaw("Old: ",Z1096LBUsuFecM);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1096LBUsuFecM[0]);
               }
               if ( Z1055LBCheck != T00592_A1055LBCheck[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBCheck");
                  GXUtil.WriteLogRaw("Old: ",Z1055LBCheck);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1055LBCheck[0]);
               }
               if ( StringUtil.StrCmp(Z1062LBCUsuCod1, T00592_A1062LBCUsuCod1[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBCUsuCod1");
                  GXUtil.WriteLogRaw("Old: ",Z1062LBCUsuCod1);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1062LBCUsuCod1[0]);
               }
               if ( StringUtil.StrCmp(Z1063LBCUsuCod2, T00592_A1063LBCUsuCod2[0]) != 0 )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBCUsuCod2");
                  GXUtil.WriteLogRaw("Old: ",Z1063LBCUsuCod2);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1063LBCUsuCod2[0]);
               }
               if ( Z1052LBAnticipoAplic != T00592_A1052LBAnticipoAplic[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBAnticipoAplic");
                  GXUtil.WriteLogRaw("Old: ",Z1052LBAnticipoAplic);
                  GXUtil.WriteLogRaw("Current: ",T00592_A1052LBAnticipoAplic[0]);
               }
               if ( Z382LBForCod != T00592_A382LBForCod[0] )
               {
                  GXUtil.WriteLog("tslibrobancos:[seudo value changed for attri]"+"LBForCod");
                  GXUtil.WriteLogRaw("Old: ",Z382LBForCod);
                  GXUtil.WriteLogRaw("Current: ",T00592_A382LBForCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSLIBROBANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert59176( )
      {
         BeforeValidate59176( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable59176( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM59176( 0) ;
            CheckOptimisticConcurrency59176( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm59176( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert59176( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005918 */
                     pr_default.execute(14, new Object[] {A381LBRegistro, A1051LBAno, A1084LBMes, A1075LBDocumento, A1079LBFech, A1070LBTipo, A1056LBCheq, A1057LBConcepto, A1054LBBeneficia, A1086LBProcesado, A1083LBItemTotal, A1091LBTipCmb, A1078LBEstado, A1097LBVouAno, A1098LBVouMes, A1089LBTASICod, A1099LBVouNum, A1093LBUsuCod, A1095LBUsuFec, A1094LBUsuCodM, A1096LBUsuFecM, A1055LBCheck, A1062LBCUsuCod1, A1063LBCUsuCod2, A1052LBAnticipoAplic, A379LBBanCod, A380LBCBCod, A382LBForCod, A1072LBTDebe, A1073LBTHaber});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOS");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption590( ) ;
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
               Load59176( ) ;
            }
            EndLevel59176( ) ;
         }
         CloseExtendedTableCursors59176( ) ;
      }

      protected void Update59176( )
      {
         BeforeValidate59176( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable59176( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency59176( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm59176( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate59176( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005919 */
                     pr_default.execute(15, new Object[] {A1051LBAno, A1084LBMes, A1075LBDocumento, A1079LBFech, A1070LBTipo, A1056LBCheq, A1057LBConcepto, A1054LBBeneficia, A1086LBProcesado, A1083LBItemTotal, A1091LBTipCmb, A1078LBEstado, A1097LBVouAno, A1098LBVouMes, A1089LBTASICod, A1099LBVouNum, A1093LBUsuCod, A1095LBUsuFec, A1094LBUsuCodM, A1096LBUsuFecM, A1055LBCheck, A1062LBCUsuCod1, A1063LBCUsuCod2, A1052LBAnticipoAplic, A382LBForCod, A1072LBTDebe, A1073LBTHaber, A379LBBanCod, A380LBCBCod, A381LBRegistro});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOS");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSLIBROBANCOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate59176( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption590( ) ;
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
            EndLevel59176( ) ;
         }
         CloseExtendedTableCursors59176( ) ;
      }

      protected void DeferredUpdate59176( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate59176( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency59176( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls59176( ) ;
            AfterConfirm59176( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete59176( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005920 */
                  pr_default.execute(16, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("TSLIBROBANCOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound176 == 0 )
                        {
                           InitAll59176( ) ;
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
                        ResetCaption590( ) ;
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
         sMode176 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel59176( ) ;
         Gx_mode = sMode176;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls59176( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005921 */
            pr_default.execute(17, new Object[] {A379LBBanCod});
            A1053LBBanAbr = T005921_A1053LBBanAbr[0];
            pr_default.close(17);
            /* Using cursor T005922 */
            pr_default.execute(18, new Object[] {A379LBBanCod, A380LBCBCod});
            A1085LBMonCod = T005922_A1085LBMonCod[0];
            AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrimStr( (decimal)(A1085LBMonCod), 6, 0));
            pr_default.close(18);
            /* Using cursor T005924 */
            pr_default.execute(19, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A1072LBTDebe = T005924_A1072LBTDebe[0];
               AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
               A1073LBTHaber = T005924_A1073LBTHaber[0];
               AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
            }
            else
            {
               A1072LBTDebe = 0;
               AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
               A1073LBTHaber = 0;
               AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
            }
            pr_default.close(19);
            A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
            AssignAttri("", false, "A1071LBTSaldo", StringUtil.LTrimStr( A1071LBTSaldo, 15, 2));
            A1082LBHaberTot = ((A1070LBTipo==0) ? A1071LBTSaldo : (decimal)(0));
            AssignAttri("", false, "A1082LBHaberTot", StringUtil.LTrimStr( A1082LBHaberTot, 15, 2));
            A1069LBDebeTot = ((A1070LBTipo==1) ? A1071LBTSaldo : (decimal)(0));
            AssignAttri("", false, "A1069LBDebeTot", StringUtil.LTrimStr( A1069LBDebeTot, 15, 2));
            /* Using cursor T005925 */
            pr_default.execute(20, new Object[] {A382LBForCod});
            A1080LBForDsc = T005925_A1080LBForDsc[0];
            AssignAttri("", false, "A1080LBForDsc", A1080LBForDsc);
            A1081LBForSunat = T005925_A1081LBForSunat[0];
            AssignAttri("", false, "A1081LBForSunat", A1081LBForSunat);
            pr_default.close(20);
            A1088LBSaldoAnticipo = (decimal)(A1073LBTHaber-A1052LBAnticipoAplic);
            AssignAttri("", false, "A1088LBSaldoAnticipo", StringUtil.LTrimStr( A1088LBSaldoAnticipo, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005926 */
            pr_default.execute(21, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Libro Bancos - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T005927 */
            pr_default.execute(22, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Flujo Conceptos Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel59176( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete59176( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            pr_default.close(20);
            pr_default.close(19);
            context.CommitDataStores("tslibrobancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues590( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            pr_default.close(20);
            pr_default.close(19);
            context.RollbackDataStores("tslibrobancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart59176( )
      {
         /* Using cursor T005928 */
         pr_default.execute(23);
         RcdFound176 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound176 = 1;
            A379LBBanCod = T005928_A379LBBanCod[0];
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = T005928_A380LBCBCod[0];
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = T005928_A381LBRegistro[0];
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext59176( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound176 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound176 = 1;
            A379LBBanCod = T005928_A379LBBanCod[0];
            AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
            A380LBCBCod = T005928_A380LBCBCod[0];
            AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
            A381LBRegistro = T005928_A381LBRegistro[0];
            AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
         }
      }

      protected void ScanEnd59176( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm59176( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert59176( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate59176( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete59176( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete59176( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate59176( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes59176( )
      {
         edtLBBanCod_Enabled = 0;
         AssignProp("", false, edtLBBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBBanCod_Enabled), 5, 0), true);
         edtLBCBCod_Enabled = 0;
         AssignProp("", false, edtLBCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCBCod_Enabled), 5, 0), true);
         edtLBRegistro_Enabled = 0;
         AssignProp("", false, edtLBRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBRegistro_Enabled), 5, 0), true);
         edtLBAno_Enabled = 0;
         AssignProp("", false, edtLBAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBAno_Enabled), 5, 0), true);
         edtLBMes_Enabled = 0;
         AssignProp("", false, edtLBMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBMes_Enabled), 5, 0), true);
         edtLBDocumento_Enabled = 0;
         AssignProp("", false, edtLBDocumento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDocumento_Enabled), 5, 0), true);
         edtLBFech_Enabled = 0;
         AssignProp("", false, edtLBFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBFech_Enabled), 5, 0), true);
         edtLBTipo_Enabled = 0;
         AssignProp("", false, edtLBTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBTipo_Enabled), 5, 0), true);
         edtLBCheq_Enabled = 0;
         AssignProp("", false, edtLBCheq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCheq_Enabled), 5, 0), true);
         edtLBConcepto_Enabled = 0;
         AssignProp("", false, edtLBConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBConcepto_Enabled), 5, 0), true);
         edtLBBeneficia_Enabled = 0;
         AssignProp("", false, edtLBBeneficia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBBeneficia_Enabled), 5, 0), true);
         edtLBProcesado_Enabled = 0;
         AssignProp("", false, edtLBProcesado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBProcesado_Enabled), 5, 0), true);
         edtLBItemTotal_Enabled = 0;
         AssignProp("", false, edtLBItemTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBItemTotal_Enabled), 5, 0), true);
         edtLBTipCmb_Enabled = 0;
         AssignProp("", false, edtLBTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBTipCmb_Enabled), 5, 0), true);
         edtLBEstado_Enabled = 0;
         AssignProp("", false, edtLBEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBEstado_Enabled), 5, 0), true);
         edtLBVouAno_Enabled = 0;
         AssignProp("", false, edtLBVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBVouAno_Enabled), 5, 0), true);
         edtLBVouMes_Enabled = 0;
         AssignProp("", false, edtLBVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBVouMes_Enabled), 5, 0), true);
         edtLBTASICod_Enabled = 0;
         AssignProp("", false, edtLBTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBTASICod_Enabled), 5, 0), true);
         edtLBVouNum_Enabled = 0;
         AssignProp("", false, edtLBVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBVouNum_Enabled), 5, 0), true);
         edtLBUsuCod_Enabled = 0;
         AssignProp("", false, edtLBUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBUsuCod_Enabled), 5, 0), true);
         edtLBUsuFec_Enabled = 0;
         AssignProp("", false, edtLBUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBUsuFec_Enabled), 5, 0), true);
         edtLBUsuCodM_Enabled = 0;
         AssignProp("", false, edtLBUsuCodM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBUsuCodM_Enabled), 5, 0), true);
         edtLBUsuFecM_Enabled = 0;
         AssignProp("", false, edtLBUsuFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBUsuFecM_Enabled), 5, 0), true);
         edtLBForCod_Enabled = 0;
         AssignProp("", false, edtLBForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBForCod_Enabled), 5, 0), true);
         edtLBCheck_Enabled = 0;
         AssignProp("", false, edtLBCheck_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCheck_Enabled), 5, 0), true);
         edtLBCUsuCod1_Enabled = 0;
         AssignProp("", false, edtLBCUsuCod1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCUsuCod1_Enabled), 5, 0), true);
         edtLBCUsuCod2_Enabled = 0;
         AssignProp("", false, edtLBCUsuCod2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBCUsuCod2_Enabled), 5, 0), true);
         edtLBDebeTot_Enabled = 0;
         AssignProp("", false, edtLBDebeTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBDebeTot_Enabled), 5, 0), true);
         edtLBHaberTot_Enabled = 0;
         AssignProp("", false, edtLBHaberTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBHaberTot_Enabled), 5, 0), true);
         edtLBTSaldo_Enabled = 0;
         AssignProp("", false, edtLBTSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBTSaldo_Enabled), 5, 0), true);
         edtLBTDebe_Enabled = 0;
         AssignProp("", false, edtLBTDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBTDebe_Enabled), 5, 0), true);
         edtLBTHaber_Enabled = 0;
         AssignProp("", false, edtLBTHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBTHaber_Enabled), 5, 0), true);
         edtLBForDsc_Enabled = 0;
         AssignProp("", false, edtLBForDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBForDsc_Enabled), 5, 0), true);
         edtLBMonCod_Enabled = 0;
         AssignProp("", false, edtLBMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBMonCod_Enabled), 5, 0), true);
         edtLBForSunat_Enabled = 0;
         AssignProp("", false, edtLBForSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLBForSunat_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes59176( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues590( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255528", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tslibrobancos.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TSLIBROBANCOS");
         forbiddenHiddens.Add("LBAnticipoAplic", context.localUtil.Format( A1052LBAnticipoAplic, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tslibrobancos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z379LBBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z379LBBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z380LBCBCod", StringUtil.RTrim( Z380LBCBCod));
         GxWebStd.gx_hidden_field( context, "Z381LBRegistro", StringUtil.RTrim( Z381LBRegistro));
         GxWebStd.gx_hidden_field( context, "Z1051LBAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1051LBAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1084LBMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1084LBMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1075LBDocumento", StringUtil.RTrim( Z1075LBDocumento));
         GxWebStd.gx_hidden_field( context, "Z1079LBFech", context.localUtil.DToC( Z1079LBFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1070LBTipo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1070LBTipo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1056LBCheq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1056LBCheq), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1057LBConcepto", StringUtil.RTrim( Z1057LBConcepto));
         GxWebStd.gx_hidden_field( context, "Z1054LBBeneficia", StringUtil.RTrim( Z1054LBBeneficia));
         GxWebStd.gx_hidden_field( context, "Z1086LBProcesado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1086LBProcesado), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1083LBItemTotal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1083LBItemTotal), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1091LBTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1091LBTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1078LBEstado", StringUtil.RTrim( Z1078LBEstado));
         GxWebStd.gx_hidden_field( context, "Z1097LBVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1097LBVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1098LBVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1098LBVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1089LBTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1089LBTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1099LBVouNum", StringUtil.RTrim( Z1099LBVouNum));
         GxWebStd.gx_hidden_field( context, "Z1093LBUsuCod", StringUtil.RTrim( Z1093LBUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1095LBUsuFec", context.localUtil.TToC( Z1095LBUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1094LBUsuCodM", StringUtil.RTrim( Z1094LBUsuCodM));
         GxWebStd.gx_hidden_field( context, "Z1096LBUsuFecM", context.localUtil.TToC( Z1096LBUsuFecM, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1055LBCheck", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1055LBCheck), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1062LBCUsuCod1", StringUtil.RTrim( Z1062LBCUsuCod1));
         GxWebStd.gx_hidden_field( context, "Z1063LBCUsuCod2", StringUtil.RTrim( Z1063LBCUsuCod2));
         GxWebStd.gx_hidden_field( context, "Z1052LBAnticipoAplic", StringUtil.LTrim( StringUtil.NToC( Z1052LBAnticipoAplic, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z382LBForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z382LBForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "LBANTICIPOAPLIC", StringUtil.LTrim( StringUtil.NToC( A1052LBAnticipoAplic, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "LBSALDOANTICIPO", StringUtil.LTrim( StringUtil.NToC( A1088LBSaldoAnticipo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "LBBANABR", StringUtil.RTrim( A1053LBBanAbr));
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
         return formatLink("tslibrobancos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSLIBROBANCOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Libro Bancos - Cabecera" ;
      }

      protected void InitializeNonKey59176( )
      {
         A1088LBSaldoAnticipo = 0;
         AssignAttri("", false, "A1088LBSaldoAnticipo", StringUtil.LTrimStr( A1088LBSaldoAnticipo, 15, 2));
         A1071LBTSaldo = 0;
         AssignAttri("", false, "A1071LBTSaldo", StringUtil.LTrimStr( A1071LBTSaldo, 15, 2));
         A1069LBDebeTot = 0;
         AssignAttri("", false, "A1069LBDebeTot", StringUtil.LTrimStr( A1069LBDebeTot, 15, 2));
         A1082LBHaberTot = 0;
         AssignAttri("", false, "A1082LBHaberTot", StringUtil.LTrimStr( A1082LBHaberTot, 15, 2));
         A1051LBAno = 0;
         AssignAttri("", false, "A1051LBAno", StringUtil.LTrimStr( (decimal)(A1051LBAno), 4, 0));
         A1053LBBanAbr = "";
         AssignAttri("", false, "A1053LBBanAbr", A1053LBBanAbr);
         A1084LBMes = 0;
         AssignAttri("", false, "A1084LBMes", StringUtil.LTrimStr( (decimal)(A1084LBMes), 2, 0));
         A1075LBDocumento = "";
         AssignAttri("", false, "A1075LBDocumento", A1075LBDocumento);
         A1079LBFech = DateTime.MinValue;
         AssignAttri("", false, "A1079LBFech", context.localUtil.Format(A1079LBFech, "99/99/99"));
         A1070LBTipo = 0;
         AssignAttri("", false, "A1070LBTipo", StringUtil.Str( (decimal)(A1070LBTipo), 1, 0));
         A1056LBCheq = 0;
         AssignAttri("", false, "A1056LBCheq", StringUtil.Str( (decimal)(A1056LBCheq), 1, 0));
         A1057LBConcepto = "";
         AssignAttri("", false, "A1057LBConcepto", A1057LBConcepto);
         A1054LBBeneficia = "";
         AssignAttri("", false, "A1054LBBeneficia", A1054LBBeneficia);
         A1086LBProcesado = 0;
         AssignAttri("", false, "A1086LBProcesado", StringUtil.Str( (decimal)(A1086LBProcesado), 1, 0));
         A1083LBItemTotal = 0;
         AssignAttri("", false, "A1083LBItemTotal", StringUtil.LTrimStr( (decimal)(A1083LBItemTotal), 6, 0));
         A1091LBTipCmb = 0;
         AssignAttri("", false, "A1091LBTipCmb", StringUtil.LTrimStr( A1091LBTipCmb, 15, 5));
         A1078LBEstado = "";
         AssignAttri("", false, "A1078LBEstado", A1078LBEstado);
         A1097LBVouAno = 0;
         AssignAttri("", false, "A1097LBVouAno", StringUtil.LTrimStr( (decimal)(A1097LBVouAno), 4, 0));
         A1098LBVouMes = 0;
         AssignAttri("", false, "A1098LBVouMes", StringUtil.LTrimStr( (decimal)(A1098LBVouMes), 2, 0));
         A1089LBTASICod = 0;
         AssignAttri("", false, "A1089LBTASICod", StringUtil.LTrimStr( (decimal)(A1089LBTASICod), 6, 0));
         A1099LBVouNum = "";
         AssignAttri("", false, "A1099LBVouNum", A1099LBVouNum);
         A1093LBUsuCod = "";
         AssignAttri("", false, "A1093LBUsuCod", A1093LBUsuCod);
         A1095LBUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1095LBUsuFec", context.localUtil.TToC( A1095LBUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1094LBUsuCodM = "";
         AssignAttri("", false, "A1094LBUsuCodM", A1094LBUsuCodM);
         A1096LBUsuFecM = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1096LBUsuFecM", context.localUtil.TToC( A1096LBUsuFecM, 8, 5, 0, 3, "/", ":", " "));
         A382LBForCod = 0;
         AssignAttri("", false, "A382LBForCod", StringUtil.LTrimStr( (decimal)(A382LBForCod), 6, 0));
         A1055LBCheck = 0;
         AssignAttri("", false, "A1055LBCheck", StringUtil.Str( (decimal)(A1055LBCheck), 1, 0));
         A1062LBCUsuCod1 = "";
         AssignAttri("", false, "A1062LBCUsuCod1", A1062LBCUsuCod1);
         A1063LBCUsuCod2 = "";
         AssignAttri("", false, "A1063LBCUsuCod2", A1063LBCUsuCod2);
         A1072LBTDebe = 0;
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
         A1073LBTHaber = 0;
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         A1080LBForDsc = "";
         AssignAttri("", false, "A1080LBForDsc", A1080LBForDsc);
         A1085LBMonCod = 0;
         AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrimStr( (decimal)(A1085LBMonCod), 6, 0));
         A1081LBForSunat = "";
         AssignAttri("", false, "A1081LBForSunat", A1081LBForSunat);
         A1052LBAnticipoAplic = 0;
         AssignAttri("", false, "A1052LBAnticipoAplic", StringUtil.LTrimStr( A1052LBAnticipoAplic, 15, 2));
         Z1051LBAno = 0;
         Z1084LBMes = 0;
         Z1075LBDocumento = "";
         Z1079LBFech = DateTime.MinValue;
         Z1070LBTipo = 0;
         Z1056LBCheq = 0;
         Z1057LBConcepto = "";
         Z1054LBBeneficia = "";
         Z1086LBProcesado = 0;
         Z1083LBItemTotal = 0;
         Z1091LBTipCmb = 0;
         Z1078LBEstado = "";
         Z1097LBVouAno = 0;
         Z1098LBVouMes = 0;
         Z1089LBTASICod = 0;
         Z1099LBVouNum = "";
         Z1093LBUsuCod = "";
         Z1095LBUsuFec = (DateTime)(DateTime.MinValue);
         Z1094LBUsuCodM = "";
         Z1096LBUsuFecM = (DateTime)(DateTime.MinValue);
         Z1055LBCheck = 0;
         Z1062LBCUsuCod1 = "";
         Z1063LBCUsuCod2 = "";
         Z1052LBAnticipoAplic = 0;
         Z382LBForCod = 0;
      }

      protected void InitAll59176( )
      {
         A379LBBanCod = 0;
         AssignAttri("", false, "A379LBBanCod", StringUtil.LTrimStr( (decimal)(A379LBBanCod), 6, 0));
         A380LBCBCod = "";
         AssignAttri("", false, "A380LBCBCod", A380LBCBCod);
         A381LBRegistro = "";
         AssignAttri("", false, "A381LBRegistro", A381LBRegistro);
         InitializeNonKey59176( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810255558", true, true);
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
         context.AddJavascriptSource("tslibrobancos.js", "?202281810255558", false, true);
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
         edtLBBanCod_Internalname = "LBBANCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLBCBCod_Internalname = "LBCBCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtLBRegistro_Internalname = "LBREGISTRO";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtLBAno_Internalname = "LBANO";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtLBMes_Internalname = "LBMES";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtLBDocumento_Internalname = "LBDOCUMENTO";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtLBFech_Internalname = "LBFECH";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtLBTipo_Internalname = "LBTIPO";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtLBCheq_Internalname = "LBCHEQ";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtLBConcepto_Internalname = "LBCONCEPTO";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtLBBeneficia_Internalname = "LBBENEFICIA";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtLBProcesado_Internalname = "LBPROCESADO";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtLBItemTotal_Internalname = "LBITEMTOTAL";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtLBTipCmb_Internalname = "LBTIPCMB";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtLBEstado_Internalname = "LBESTADO";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtLBVouAno_Internalname = "LBVOUANO";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtLBVouMes_Internalname = "LBVOUMES";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtLBTASICod_Internalname = "LBTASICOD";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtLBVouNum_Internalname = "LBVOUNUM";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtLBUsuCod_Internalname = "LBUSUCOD";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtLBUsuFec_Internalname = "LBUSUFEC";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtLBUsuCodM_Internalname = "LBUSUCODM";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtLBUsuFecM_Internalname = "LBUSUFECM";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtLBForCod_Internalname = "LBFORCOD";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtLBCheck_Internalname = "LBCHECK";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtLBCUsuCod1_Internalname = "LBCUSUCOD1";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtLBCUsuCod2_Internalname = "LBCUSUCOD2";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtLBDebeTot_Internalname = "LBDEBETOT";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtLBHaberTot_Internalname = "LBHABERTOT";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtLBTSaldo_Internalname = "LBTSALDO";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtLBTDebe_Internalname = "LBTDEBE";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtLBTHaber_Internalname = "LBTHABER";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtLBForDsc_Internalname = "LBFORDSC";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtLBMonCod_Internalname = "LBMONCOD";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtLBForSunat_Internalname = "LBFORSUNAT";
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
         Form.Caption = "Libro Bancos - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLBForSunat_Jsonclick = "";
         edtLBForSunat_Enabled = 0;
         edtLBMonCod_Jsonclick = "";
         edtLBMonCod_Enabled = 0;
         edtLBForDsc_Jsonclick = "";
         edtLBForDsc_Enabled = 0;
         edtLBTHaber_Jsonclick = "";
         edtLBTHaber_Enabled = 0;
         edtLBTDebe_Jsonclick = "";
         edtLBTDebe_Enabled = 0;
         edtLBTSaldo_Jsonclick = "";
         edtLBTSaldo_Enabled = 0;
         edtLBHaberTot_Jsonclick = "";
         edtLBHaberTot_Enabled = 0;
         edtLBDebeTot_Jsonclick = "";
         edtLBDebeTot_Enabled = 0;
         edtLBCUsuCod2_Jsonclick = "";
         edtLBCUsuCod2_Enabled = 1;
         edtLBCUsuCod1_Jsonclick = "";
         edtLBCUsuCod1_Enabled = 1;
         edtLBCheck_Jsonclick = "";
         edtLBCheck_Enabled = 1;
         edtLBForCod_Jsonclick = "";
         edtLBForCod_Enabled = 1;
         edtLBUsuFecM_Jsonclick = "";
         edtLBUsuFecM_Enabled = 1;
         edtLBUsuCodM_Jsonclick = "";
         edtLBUsuCodM_Enabled = 1;
         edtLBUsuFec_Jsonclick = "";
         edtLBUsuFec_Enabled = 1;
         edtLBUsuCod_Jsonclick = "";
         edtLBUsuCod_Enabled = 1;
         edtLBVouNum_Jsonclick = "";
         edtLBVouNum_Enabled = 1;
         edtLBTASICod_Jsonclick = "";
         edtLBTASICod_Enabled = 1;
         edtLBVouMes_Jsonclick = "";
         edtLBVouMes_Enabled = 1;
         edtLBVouAno_Jsonclick = "";
         edtLBVouAno_Enabled = 1;
         edtLBEstado_Jsonclick = "";
         edtLBEstado_Enabled = 1;
         edtLBTipCmb_Jsonclick = "";
         edtLBTipCmb_Enabled = 1;
         edtLBItemTotal_Jsonclick = "";
         edtLBItemTotal_Enabled = 1;
         edtLBProcesado_Jsonclick = "";
         edtLBProcesado_Enabled = 1;
         edtLBBeneficia_Jsonclick = "";
         edtLBBeneficia_Enabled = 1;
         edtLBConcepto_Jsonclick = "";
         edtLBConcepto_Enabled = 1;
         edtLBCheq_Jsonclick = "";
         edtLBCheq_Enabled = 1;
         edtLBTipo_Jsonclick = "";
         edtLBTipo_Enabled = 1;
         edtLBFech_Jsonclick = "";
         edtLBFech_Enabled = 1;
         edtLBDocumento_Jsonclick = "";
         edtLBDocumento_Enabled = 1;
         edtLBMes_Jsonclick = "";
         edtLBMes_Enabled = 1;
         edtLBAno_Jsonclick = "";
         edtLBAno_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtLBRegistro_Jsonclick = "";
         edtLBRegistro_Enabled = 1;
         edtLBCBCod_Jsonclick = "";
         edtLBCBCod_Enabled = 1;
         edtLBBanCod_Jsonclick = "";
         edtLBBanCod_Enabled = 1;
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
         /* Using cursor T005921 */
         pr_default.execute(17, new Object[] {A379LBBanCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1053LBBanAbr = T005921_A1053LBBanAbr[0];
         pr_default.close(17);
         /* Using cursor T005922 */
         pr_default.execute(18, new Object[] {A379LBBanCod, A380LBCBCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBCBCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1085LBMonCod = T005922_A1085LBMonCod[0];
         AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrimStr( (decimal)(A1085LBMonCod), 6, 0));
         pr_default.close(18);
         /* Using cursor T005924 */
         pr_default.execute(19, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A1072LBTDebe = T005924_A1072LBTDebe[0];
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = T005924_A1073LBTHaber[0];
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         else
         {
            A1072LBTDebe = 0;
            AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrimStr( A1072LBTDebe, 15, 2));
            A1073LBTHaber = 0;
            AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrimStr( A1073LBTHaber, 15, 2));
         }
         pr_default.close(19);
         GX_FocusControl = edtLBAno_Internalname;
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

      public void Valid_Lbbancod( )
      {
         /* Using cursor T005921 */
         pr_default.execute(17, new Object[] {A379LBBanCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBBANCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
         }
         A1053LBBanAbr = T005921_A1053LBBanAbr[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1053LBBanAbr", StringUtil.RTrim( A1053LBBanAbr));
      }

      public void Valid_Lbcbcod( )
      {
         /* Using cursor T005922 */
         pr_default.execute(18, new Object[] {A379LBBanCod, A380LBCBCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LBCBCOD");
            AnyError = 1;
            GX_FocusControl = edtLBBanCod_Internalname;
         }
         A1085LBMonCod = T005922_A1085LBMonCod[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1085LBMonCod), 6, 0, ".", "")));
      }

      public void Valid_Lbregistro( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T005924 */
         pr_default.execute(19, new Object[] {A379LBBanCod, A380LBCBCod, A381LBRegistro});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A1072LBTDebe = T005924_A1072LBTDebe[0];
            A1073LBTHaber = T005924_A1073LBTHaber[0];
         }
         else
         {
            A1072LBTDebe = 0;
            A1073LBTHaber = 0;
         }
         pr_default.close(19);
         A1071LBTSaldo = (((A1072LBTDebe-A1073LBTHaber)<Convert.ToDecimal(0)) ? (A1072LBTDebe-A1073LBTHaber)*-1 : (((A1073LBTHaber-A1072LBTDebe)<Convert.ToDecimal(0)) ? (A1073LBTHaber-A1072LBTDebe)*-1 : A1072LBTDebe-A1073LBTHaber));
         A1088LBSaldoAnticipo = (decimal)(A1073LBTHaber-A1052LBAnticipoAplic);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1051LBAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1051LBAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1084LBMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1084LBMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1075LBDocumento", StringUtil.RTrim( A1075LBDocumento));
         AssignAttri("", false, "A1079LBFech", context.localUtil.Format(A1079LBFech, "99/99/99"));
         AssignAttri("", false, "A1070LBTipo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1070LBTipo), 1, 0, ".", "")));
         AssignAttri("", false, "A1056LBCheq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1056LBCheq), 1, 0, ".", "")));
         AssignAttri("", false, "A1057LBConcepto", StringUtil.RTrim( A1057LBConcepto));
         AssignAttri("", false, "A1054LBBeneficia", StringUtil.RTrim( A1054LBBeneficia));
         AssignAttri("", false, "A1086LBProcesado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1086LBProcesado), 1, 0, ".", "")));
         AssignAttri("", false, "A1083LBItemTotal", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1083LBItemTotal), 6, 0, ".", "")));
         AssignAttri("", false, "A1091LBTipCmb", StringUtil.LTrim( StringUtil.NToC( A1091LBTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A1078LBEstado", StringUtil.RTrim( A1078LBEstado));
         AssignAttri("", false, "A1097LBVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1097LBVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1098LBVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1098LBVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1089LBTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1089LBTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A1099LBVouNum", StringUtil.RTrim( A1099LBVouNum));
         AssignAttri("", false, "A1093LBUsuCod", StringUtil.RTrim( A1093LBUsuCod));
         AssignAttri("", false, "A1095LBUsuFec", context.localUtil.TToC( A1095LBUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1094LBUsuCodM", StringUtil.RTrim( A1094LBUsuCodM));
         AssignAttri("", false, "A1096LBUsuFecM", context.localUtil.TToC( A1096LBUsuFecM, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A382LBForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A382LBForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1055LBCheck", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1055LBCheck), 1, 0, ".", "")));
         AssignAttri("", false, "A1062LBCUsuCod1", StringUtil.RTrim( A1062LBCUsuCod1));
         AssignAttri("", false, "A1063LBCUsuCod2", StringUtil.RTrim( A1063LBCUsuCod2));
         AssignAttri("", false, "A1052LBAnticipoAplic", StringUtil.LTrim( StringUtil.NToC( A1052LBAnticipoAplic, 15, 2, ".", "")));
         AssignAttri("", false, "A1053LBBanAbr", StringUtil.RTrim( A1053LBBanAbr));
         AssignAttri("", false, "A1085LBMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1085LBMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( A1072LBTDebe, 15, 2, ".", "")));
         AssignAttri("", false, "A1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( A1073LBTHaber, 15, 2, ".", "")));
         AssignAttri("", false, "A1071LBTSaldo", StringUtil.LTrim( StringUtil.NToC( A1071LBTSaldo, 15, 2, ".", "")));
         AssignAttri("", false, "A1082LBHaberTot", StringUtil.LTrim( StringUtil.NToC( A1082LBHaberTot, 15, 2, ".", "")));
         AssignAttri("", false, "A1069LBDebeTot", StringUtil.LTrim( StringUtil.NToC( A1069LBDebeTot, 15, 2, ".", "")));
         AssignAttri("", false, "A1088LBSaldoAnticipo", StringUtil.LTrim( StringUtil.NToC( A1088LBSaldoAnticipo, 15, 2, ".", "")));
         AssignAttri("", false, "A1080LBForDsc", StringUtil.RTrim( A1080LBForDsc));
         AssignAttri("", false, "A1081LBForSunat", StringUtil.RTrim( A1081LBForSunat));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z379LBBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z379LBBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z380LBCBCod", StringUtil.RTrim( Z380LBCBCod));
         GxWebStd.gx_hidden_field( context, "Z381LBRegistro", StringUtil.RTrim( Z381LBRegistro));
         GxWebStd.gx_hidden_field( context, "Z1051LBAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1051LBAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1084LBMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1084LBMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1075LBDocumento", StringUtil.RTrim( Z1075LBDocumento));
         GxWebStd.gx_hidden_field( context, "Z1079LBFech", context.localUtil.Format(Z1079LBFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1070LBTipo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1070LBTipo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1056LBCheq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1056LBCheq), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1057LBConcepto", StringUtil.RTrim( Z1057LBConcepto));
         GxWebStd.gx_hidden_field( context, "Z1054LBBeneficia", StringUtil.RTrim( Z1054LBBeneficia));
         GxWebStd.gx_hidden_field( context, "Z1086LBProcesado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1086LBProcesado), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1083LBItemTotal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1083LBItemTotal), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1091LBTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1091LBTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1078LBEstado", StringUtil.RTrim( Z1078LBEstado));
         GxWebStd.gx_hidden_field( context, "Z1097LBVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1097LBVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1098LBVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1098LBVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1089LBTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1089LBTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1099LBVouNum", StringUtil.RTrim( Z1099LBVouNum));
         GxWebStd.gx_hidden_field( context, "Z1093LBUsuCod", StringUtil.RTrim( Z1093LBUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1095LBUsuFec", context.localUtil.TToC( Z1095LBUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1094LBUsuCodM", StringUtil.RTrim( Z1094LBUsuCodM));
         GxWebStd.gx_hidden_field( context, "Z1096LBUsuFecM", context.localUtil.TToC( Z1096LBUsuFecM, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z382LBForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z382LBForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1055LBCheck", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1055LBCheck), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1062LBCUsuCod1", StringUtil.RTrim( Z1062LBCUsuCod1));
         GxWebStd.gx_hidden_field( context, "Z1063LBCUsuCod2", StringUtil.RTrim( Z1063LBCUsuCod2));
         GxWebStd.gx_hidden_field( context, "Z1052LBAnticipoAplic", StringUtil.LTrim( StringUtil.NToC( Z1052LBAnticipoAplic, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1053LBBanAbr", StringUtil.RTrim( Z1053LBBanAbr));
         GxWebStd.gx_hidden_field( context, "Z1085LBMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1085LBMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1072LBTDebe", StringUtil.LTrim( StringUtil.NToC( Z1072LBTDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1073LBTHaber", StringUtil.LTrim( StringUtil.NToC( Z1073LBTHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1071LBTSaldo", StringUtil.LTrim( StringUtil.NToC( Z1071LBTSaldo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1082LBHaberTot", StringUtil.LTrim( StringUtil.NToC( Z1082LBHaberTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1069LBDebeTot", StringUtil.LTrim( StringUtil.NToC( Z1069LBDebeTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1088LBSaldoAnticipo", StringUtil.LTrim( StringUtil.NToC( Z1088LBSaldoAnticipo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1080LBForDsc", StringUtil.RTrim( Z1080LBForDsc));
         GxWebStd.gx_hidden_field( context, "Z1081LBForSunat", StringUtil.RTrim( Z1081LBForSunat));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Lbforcod( )
      {
         /* Using cursor T005925 */
         pr_default.execute(20, new Object[] {A382LBForCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Libro Bancos Forma Pago'.", "ForeignKeyNotFound", 1, "LBFORCOD");
            AnyError = 1;
            GX_FocusControl = edtLBForCod_Internalname;
         }
         A1080LBForDsc = T005925_A1080LBForDsc[0];
         A1081LBForSunat = T005925_A1081LBForSunat[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1080LBForDsc", StringUtil.RTrim( A1080LBForDsc));
         AssignAttri("", false, "A1081LBForSunat", StringUtil.RTrim( A1081LBForSunat));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1052LBAnticipoAplic',fld:'LBANTICIPOAPLIC',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_LBBANCOD","{handler:'Valid_Lbbancod',iparms:[{av:'A379LBBanCod',fld:'LBBANCOD',pic:'ZZZZZ9'},{av:'A1053LBBanAbr',fld:'LBBANABR',pic:''}]");
         setEventMetadata("VALID_LBBANCOD",",oparms:[{av:'A1053LBBanAbr',fld:'LBBANABR',pic:''}]}");
         setEventMetadata("VALID_LBCBCOD","{handler:'Valid_Lbcbcod',iparms:[{av:'A379LBBanCod',fld:'LBBANCOD',pic:'ZZZZZ9'},{av:'A380LBCBCod',fld:'LBCBCOD',pic:''},{av:'A1085LBMonCod',fld:'LBMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LBCBCOD",",oparms:[{av:'A1085LBMonCod',fld:'LBMONCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_LBREGISTRO","{handler:'Valid_Lbregistro',iparms:[{av:'A379LBBanCod',fld:'LBBANCOD',pic:'ZZZZZ9'},{av:'A380LBCBCod',fld:'LBCBCOD',pic:''},{av:'A381LBRegistro',fld:'LBREGISTRO',pic:''},{av:'A1072LBTDebe',fld:'LBTDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1073LBTHaber',fld:'LBTHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1052LBAnticipoAplic',fld:'LBANTICIPOAPLIC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LBREGISTRO",",oparms:[{av:'A1051LBAno',fld:'LBANO',pic:'ZZZ9'},{av:'A1084LBMes',fld:'LBMES',pic:'Z9'},{av:'A1075LBDocumento',fld:'LBDOCUMENTO',pic:''},{av:'A1079LBFech',fld:'LBFECH',pic:''},{av:'A1070LBTipo',fld:'LBTIPO',pic:'9'},{av:'A1056LBCheq',fld:'LBCHEQ',pic:'9'},{av:'A1057LBConcepto',fld:'LBCONCEPTO',pic:''},{av:'A1054LBBeneficia',fld:'LBBENEFICIA',pic:''},{av:'A1086LBProcesado',fld:'LBPROCESADO',pic:'9'},{av:'A1083LBItemTotal',fld:'LBITEMTOTAL',pic:'ZZZZZ9'},{av:'A1091LBTipCmb',fld:'LBTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A1078LBEstado',fld:'LBESTADO',pic:''},{av:'A1097LBVouAno',fld:'LBVOUANO',pic:'ZZZ9'},{av:'A1098LBVouMes',fld:'LBVOUMES',pic:'Z9'},{av:'A1089LBTASICod',fld:'LBTASICOD',pic:'ZZZZZ9'},{av:'A1099LBVouNum',fld:'LBVOUNUM',pic:''},{av:'A1093LBUsuCod',fld:'LBUSUCOD',pic:''},{av:'A1095LBUsuFec',fld:'LBUSUFEC',pic:'99/99/99 99:99'},{av:'A1094LBUsuCodM',fld:'LBUSUCODM',pic:''},{av:'A1096LBUsuFecM',fld:'LBUSUFECM',pic:'99/99/99 99:99'},{av:'A382LBForCod',fld:'LBFORCOD',pic:'ZZZZZ9'},{av:'A1055LBCheck',fld:'LBCHECK',pic:'9'},{av:'A1062LBCUsuCod1',fld:'LBCUSUCOD1',pic:''},{av:'A1063LBCUsuCod2',fld:'LBCUSUCOD2',pic:''},{av:'A1052LBAnticipoAplic',fld:'LBANTICIPOAPLIC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1053LBBanAbr',fld:'LBBANABR',pic:''},{av:'A1085LBMonCod',fld:'LBMONCOD',pic:'ZZZZZ9'},{av:'A1072LBTDebe',fld:'LBTDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1073LBTHaber',fld:'LBTHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1071LBTSaldo',fld:'LBTSALDO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1082LBHaberTot',fld:'LBHABERTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1069LBDebeTot',fld:'LBDEBETOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1088LBSaldoAnticipo',fld:'LBSALDOANTICIPO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1080LBForDsc',fld:'LBFORDSC',pic:''},{av:'A1081LBForSunat',fld:'LBFORSUNAT',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z379LBBanCod'},{av:'Z380LBCBCod'},{av:'Z381LBRegistro'},{av:'Z1051LBAno'},{av:'Z1084LBMes'},{av:'Z1075LBDocumento'},{av:'Z1079LBFech'},{av:'Z1070LBTipo'},{av:'Z1056LBCheq'},{av:'Z1057LBConcepto'},{av:'Z1054LBBeneficia'},{av:'Z1086LBProcesado'},{av:'Z1083LBItemTotal'},{av:'Z1091LBTipCmb'},{av:'Z1078LBEstado'},{av:'Z1097LBVouAno'},{av:'Z1098LBVouMes'},{av:'Z1089LBTASICod'},{av:'Z1099LBVouNum'},{av:'Z1093LBUsuCod'},{av:'Z1095LBUsuFec'},{av:'Z1094LBUsuCodM'},{av:'Z1096LBUsuFecM'},{av:'Z382LBForCod'},{av:'Z1055LBCheck'},{av:'Z1062LBCUsuCod1'},{av:'Z1063LBCUsuCod2'},{av:'Z1052LBAnticipoAplic'},{av:'Z1053LBBanAbr'},{av:'Z1085LBMonCod'},{av:'Z1072LBTDebe'},{av:'Z1073LBTHaber'},{av:'Z1071LBTSaldo'},{av:'Z1082LBHaberTot'},{av:'Z1069LBDebeTot'},{av:'Z1088LBSaldoAnticipo'},{av:'Z1080LBForDsc'},{av:'Z1081LBForSunat'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_LBFECH","{handler:'Valid_Lbfech',iparms:[]");
         setEventMetadata("VALID_LBFECH",",oparms:[]}");
         setEventMetadata("VALID_LBTIPO","{handler:'Valid_Lbtipo',iparms:[]");
         setEventMetadata("VALID_LBTIPO",",oparms:[]}");
         setEventMetadata("VALID_LBUSUFEC","{handler:'Valid_Lbusufec',iparms:[]");
         setEventMetadata("VALID_LBUSUFEC",",oparms:[]}");
         setEventMetadata("VALID_LBUSUFECM","{handler:'Valid_Lbusufecm',iparms:[]");
         setEventMetadata("VALID_LBUSUFECM",",oparms:[]}");
         setEventMetadata("VALID_LBFORCOD","{handler:'Valid_Lbforcod',iparms:[{av:'A382LBForCod',fld:'LBFORCOD',pic:'ZZZZZ9'},{av:'A1080LBForDsc',fld:'LBFORDSC',pic:''},{av:'A1081LBForSunat',fld:'LBFORSUNAT',pic:''}]");
         setEventMetadata("VALID_LBFORCOD",",oparms:[{av:'A1080LBForDsc',fld:'LBFORDSC',pic:''},{av:'A1081LBForSunat',fld:'LBFORSUNAT',pic:''}]}");
         setEventMetadata("VALID_LBTSALDO","{handler:'Valid_Lbtsaldo',iparms:[]");
         setEventMetadata("VALID_LBTSALDO",",oparms:[]}");
         setEventMetadata("VALID_LBTDEBE","{handler:'Valid_Lbtdebe',iparms:[]");
         setEventMetadata("VALID_LBTDEBE",",oparms:[]}");
         setEventMetadata("VALID_LBTHABER","{handler:'Valid_Lbthaber',iparms:[]");
         setEventMetadata("VALID_LBTHABER",",oparms:[]}");
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
         pr_default.close(17);
         pr_default.close(18);
         pr_default.close(20);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z380LBCBCod = "";
         Z381LBRegistro = "";
         Z1075LBDocumento = "";
         Z1079LBFech = DateTime.MinValue;
         Z1057LBConcepto = "";
         Z1054LBBeneficia = "";
         Z1078LBEstado = "";
         Z1099LBVouNum = "";
         Z1093LBUsuCod = "";
         Z1095LBUsuFec = (DateTime)(DateTime.MinValue);
         Z1094LBUsuCodM = "";
         Z1096LBUsuFecM = (DateTime)(DateTime.MinValue);
         Z1062LBCUsuCod1 = "";
         Z1063LBCUsuCod2 = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A380LBCBCod = "";
         A381LBRegistro = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         A1075LBDocumento = "";
         lblTextblock7_Jsonclick = "";
         A1079LBFech = DateTime.MinValue;
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1057LBConcepto = "";
         lblTextblock11_Jsonclick = "";
         A1054LBBeneficia = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1078LBEstado = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         A1099LBVouNum = "";
         lblTextblock20_Jsonclick = "";
         A1093LBUsuCod = "";
         lblTextblock21_Jsonclick = "";
         A1095LBUsuFec = (DateTime)(DateTime.MinValue);
         lblTextblock22_Jsonclick = "";
         A1094LBUsuCodM = "";
         lblTextblock23_Jsonclick = "";
         A1096LBUsuFecM = (DateTime)(DateTime.MinValue);
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         A1062LBCUsuCod1 = "";
         lblTextblock27_Jsonclick = "";
         A1063LBCUsuCod2 = "";
         lblTextblock28_Jsonclick = "";
         lblTextblock29_Jsonclick = "";
         lblTextblock30_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         lblTextblock32_Jsonclick = "";
         lblTextblock33_Jsonclick = "";
         A1080LBForDsc = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         A1081LBForSunat = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         A1053LBBanAbr = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1053LBBanAbr = "";
         Z1080LBForDsc = "";
         Z1081LBForSunat = "";
         T00599_A381LBRegistro = new string[] {""} ;
         T00599_A1051LBAno = new short[1] ;
         T00599_A1053LBBanAbr = new string[] {""} ;
         T00599_A1084LBMes = new short[1] ;
         T00599_A1075LBDocumento = new string[] {""} ;
         T00599_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         T00599_A1070LBTipo = new short[1] ;
         T00599_A1056LBCheq = new short[1] ;
         T00599_A1057LBConcepto = new string[] {""} ;
         T00599_A1054LBBeneficia = new string[] {""} ;
         T00599_A1086LBProcesado = new short[1] ;
         T00599_A1083LBItemTotal = new int[1] ;
         T00599_A1091LBTipCmb = new decimal[1] ;
         T00599_A1078LBEstado = new string[] {""} ;
         T00599_A1097LBVouAno = new short[1] ;
         T00599_A1098LBVouMes = new short[1] ;
         T00599_A1089LBTASICod = new int[1] ;
         T00599_A1099LBVouNum = new string[] {""} ;
         T00599_A1093LBUsuCod = new string[] {""} ;
         T00599_A1095LBUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00599_A1094LBUsuCodM = new string[] {""} ;
         T00599_A1096LBUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T00599_A1055LBCheck = new short[1] ;
         T00599_A1062LBCUsuCod1 = new string[] {""} ;
         T00599_A1063LBCUsuCod2 = new string[] {""} ;
         T00599_A1080LBForDsc = new string[] {""} ;
         T00599_A1081LBForSunat = new string[] {""} ;
         T00599_A1052LBAnticipoAplic = new decimal[1] ;
         T00599_A379LBBanCod = new int[1] ;
         T00599_A380LBCBCod = new string[] {""} ;
         T00599_A382LBForCod = new int[1] ;
         T00599_A1085LBMonCod = new int[1] ;
         T00598_A1072LBTDebe = new decimal[1] ;
         T00598_A1073LBTHaber = new decimal[1] ;
         T00594_A1053LBBanAbr = new string[] {""} ;
         T00595_A1085LBMonCod = new int[1] ;
         T00596_A1080LBForDsc = new string[] {""} ;
         T00596_A1081LBForSunat = new string[] {""} ;
         T005910_A1053LBBanAbr = new string[] {""} ;
         T005911_A1085LBMonCod = new int[1] ;
         T005913_A1072LBTDebe = new decimal[1] ;
         T005913_A1073LBTHaber = new decimal[1] ;
         T005914_A1080LBForDsc = new string[] {""} ;
         T005914_A1081LBForSunat = new string[] {""} ;
         T005915_A379LBBanCod = new int[1] ;
         T005915_A380LBCBCod = new string[] {""} ;
         T005915_A381LBRegistro = new string[] {""} ;
         T00593_A381LBRegistro = new string[] {""} ;
         T00593_A1051LBAno = new short[1] ;
         T00593_A1084LBMes = new short[1] ;
         T00593_A1075LBDocumento = new string[] {""} ;
         T00593_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         T00593_A1070LBTipo = new short[1] ;
         T00593_A1056LBCheq = new short[1] ;
         T00593_A1057LBConcepto = new string[] {""} ;
         T00593_A1054LBBeneficia = new string[] {""} ;
         T00593_A1086LBProcesado = new short[1] ;
         T00593_A1083LBItemTotal = new int[1] ;
         T00593_A1091LBTipCmb = new decimal[1] ;
         T00593_A1078LBEstado = new string[] {""} ;
         T00593_A1097LBVouAno = new short[1] ;
         T00593_A1098LBVouMes = new short[1] ;
         T00593_A1089LBTASICod = new int[1] ;
         T00593_A1099LBVouNum = new string[] {""} ;
         T00593_A1093LBUsuCod = new string[] {""} ;
         T00593_A1095LBUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00593_A1094LBUsuCodM = new string[] {""} ;
         T00593_A1096LBUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T00593_A1055LBCheck = new short[1] ;
         T00593_A1062LBCUsuCod1 = new string[] {""} ;
         T00593_A1063LBCUsuCod2 = new string[] {""} ;
         T00593_A1052LBAnticipoAplic = new decimal[1] ;
         T00593_A379LBBanCod = new int[1] ;
         T00593_A380LBCBCod = new string[] {""} ;
         T00593_A382LBForCod = new int[1] ;
         sMode176 = "";
         T005916_A379LBBanCod = new int[1] ;
         T005916_A380LBCBCod = new string[] {""} ;
         T005916_A381LBRegistro = new string[] {""} ;
         T005917_A379LBBanCod = new int[1] ;
         T005917_A380LBCBCod = new string[] {""} ;
         T005917_A381LBRegistro = new string[] {""} ;
         T00592_A381LBRegistro = new string[] {""} ;
         T00592_A1051LBAno = new short[1] ;
         T00592_A1084LBMes = new short[1] ;
         T00592_A1075LBDocumento = new string[] {""} ;
         T00592_A1079LBFech = new DateTime[] {DateTime.MinValue} ;
         T00592_A1070LBTipo = new short[1] ;
         T00592_A1056LBCheq = new short[1] ;
         T00592_A1057LBConcepto = new string[] {""} ;
         T00592_A1054LBBeneficia = new string[] {""} ;
         T00592_A1086LBProcesado = new short[1] ;
         T00592_A1083LBItemTotal = new int[1] ;
         T00592_A1091LBTipCmb = new decimal[1] ;
         T00592_A1078LBEstado = new string[] {""} ;
         T00592_A1097LBVouAno = new short[1] ;
         T00592_A1098LBVouMes = new short[1] ;
         T00592_A1089LBTASICod = new int[1] ;
         T00592_A1099LBVouNum = new string[] {""} ;
         T00592_A1093LBUsuCod = new string[] {""} ;
         T00592_A1095LBUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00592_A1094LBUsuCodM = new string[] {""} ;
         T00592_A1096LBUsuFecM = new DateTime[] {DateTime.MinValue} ;
         T00592_A1055LBCheck = new short[1] ;
         T00592_A1062LBCUsuCod1 = new string[] {""} ;
         T00592_A1063LBCUsuCod2 = new string[] {""} ;
         T00592_A1052LBAnticipoAplic = new decimal[1] ;
         T00592_A379LBBanCod = new int[1] ;
         T00592_A380LBCBCod = new string[] {""} ;
         T00592_A382LBForCod = new int[1] ;
         T005921_A1053LBBanAbr = new string[] {""} ;
         T005922_A1085LBMonCod = new int[1] ;
         T005924_A1072LBTDebe = new decimal[1] ;
         T005924_A1073LBTHaber = new decimal[1] ;
         T005925_A1080LBForDsc = new string[] {""} ;
         T005925_A1081LBForSunat = new string[] {""} ;
         T005926_A379LBBanCod = new int[1] ;
         T005926_A380LBCBCod = new string[] {""} ;
         T005926_A381LBRegistro = new string[] {""} ;
         T005926_A383LBDITem = new int[1] ;
         T005927_A2263CBFlujCAno = new short[1] ;
         T005927_A2264CBFlujCMes = new short[1] ;
         T005927_A2265CBFlujCBanCod = new int[1] ;
         T005927_A2266CBFlujCCuenta = new string[] {""} ;
         T005927_A2267CBFlujCRegistro = new string[] {""} ;
         T005928_A379LBBanCod = new int[1] ;
         T005928_A380LBCBCod = new string[] {""} ;
         T005928_A381LBRegistro = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ380LBCBCod = "";
         ZZ381LBRegistro = "";
         ZZ1075LBDocumento = "";
         ZZ1079LBFech = DateTime.MinValue;
         ZZ1057LBConcepto = "";
         ZZ1054LBBeneficia = "";
         ZZ1078LBEstado = "";
         ZZ1099LBVouNum = "";
         ZZ1093LBUsuCod = "";
         ZZ1095LBUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1094LBUsuCodM = "";
         ZZ1096LBUsuFecM = (DateTime)(DateTime.MinValue);
         ZZ1062LBCUsuCod1 = "";
         ZZ1063LBCUsuCod2 = "";
         ZZ1053LBBanAbr = "";
         ZZ1080LBForDsc = "";
         ZZ1081LBForSunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tslibrobancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tslibrobancos__default(),
            new Object[][] {
                new Object[] {
               T00592_A381LBRegistro, T00592_A1051LBAno, T00592_A1084LBMes, T00592_A1075LBDocumento, T00592_A1079LBFech, T00592_A1070LBTipo, T00592_A1056LBCheq, T00592_A1057LBConcepto, T00592_A1054LBBeneficia, T00592_A1086LBProcesado,
               T00592_A1083LBItemTotal, T00592_A1091LBTipCmb, T00592_A1078LBEstado, T00592_A1097LBVouAno, T00592_A1098LBVouMes, T00592_A1089LBTASICod, T00592_A1099LBVouNum, T00592_A1093LBUsuCod, T00592_A1095LBUsuFec, T00592_A1094LBUsuCodM,
               T00592_A1096LBUsuFecM, T00592_A1055LBCheck, T00592_A1062LBCUsuCod1, T00592_A1063LBCUsuCod2, T00592_A1052LBAnticipoAplic, T00592_A379LBBanCod, T00592_A380LBCBCod, T00592_A382LBForCod
               }
               , new Object[] {
               T00593_A381LBRegistro, T00593_A1051LBAno, T00593_A1084LBMes, T00593_A1075LBDocumento, T00593_A1079LBFech, T00593_A1070LBTipo, T00593_A1056LBCheq, T00593_A1057LBConcepto, T00593_A1054LBBeneficia, T00593_A1086LBProcesado,
               T00593_A1083LBItemTotal, T00593_A1091LBTipCmb, T00593_A1078LBEstado, T00593_A1097LBVouAno, T00593_A1098LBVouMes, T00593_A1089LBTASICod, T00593_A1099LBVouNum, T00593_A1093LBUsuCod, T00593_A1095LBUsuFec, T00593_A1094LBUsuCodM,
               T00593_A1096LBUsuFecM, T00593_A1055LBCheck, T00593_A1062LBCUsuCod1, T00593_A1063LBCUsuCod2, T00593_A1052LBAnticipoAplic, T00593_A379LBBanCod, T00593_A380LBCBCod, T00593_A382LBForCod
               }
               , new Object[] {
               T00594_A1053LBBanAbr
               }
               , new Object[] {
               T00595_A1085LBMonCod
               }
               , new Object[] {
               T00596_A1080LBForDsc, T00596_A1081LBForSunat
               }
               , new Object[] {
               T00598_A1072LBTDebe, T00598_A1073LBTHaber
               }
               , new Object[] {
               T00599_A381LBRegistro, T00599_A1051LBAno, T00599_A1053LBBanAbr, T00599_A1084LBMes, T00599_A1075LBDocumento, T00599_A1079LBFech, T00599_A1070LBTipo, T00599_A1056LBCheq, T00599_A1057LBConcepto, T00599_A1054LBBeneficia,
               T00599_A1086LBProcesado, T00599_A1083LBItemTotal, T00599_A1091LBTipCmb, T00599_A1078LBEstado, T00599_A1097LBVouAno, T00599_A1098LBVouMes, T00599_A1089LBTASICod, T00599_A1099LBVouNum, T00599_A1093LBUsuCod, T00599_A1095LBUsuFec,
               T00599_A1094LBUsuCodM, T00599_A1096LBUsuFecM, T00599_A1055LBCheck, T00599_A1062LBCUsuCod1, T00599_A1063LBCUsuCod2, T00599_A1080LBForDsc, T00599_A1081LBForSunat, T00599_A1052LBAnticipoAplic, T00599_A379LBBanCod, T00599_A380LBCBCod,
               T00599_A382LBForCod, T00599_A1085LBMonCod
               }
               , new Object[] {
               T005910_A1053LBBanAbr
               }
               , new Object[] {
               T005911_A1085LBMonCod
               }
               , new Object[] {
               T005913_A1072LBTDebe, T005913_A1073LBTHaber
               }
               , new Object[] {
               T005914_A1080LBForDsc, T005914_A1081LBForSunat
               }
               , new Object[] {
               T005915_A379LBBanCod, T005915_A380LBCBCod, T005915_A381LBRegistro
               }
               , new Object[] {
               T005916_A379LBBanCod, T005916_A380LBCBCod, T005916_A381LBRegistro
               }
               , new Object[] {
               T005917_A379LBBanCod, T005917_A380LBCBCod, T005917_A381LBRegistro
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005921_A1053LBBanAbr
               }
               , new Object[] {
               T005922_A1085LBMonCod
               }
               , new Object[] {
               T005924_A1072LBTDebe, T005924_A1073LBTHaber
               }
               , new Object[] {
               T005925_A1080LBForDsc, T005925_A1081LBForSunat
               }
               , new Object[] {
               T005926_A379LBBanCod, T005926_A380LBCBCod, T005926_A381LBRegistro, T005926_A383LBDITem
               }
               , new Object[] {
               T005927_A2263CBFlujCAno, T005927_A2264CBFlujCMes, T005927_A2265CBFlujCBanCod, T005927_A2266CBFlujCCuenta, T005927_A2267CBFlujCRegistro
               }
               , new Object[] {
               T005928_A379LBBanCod, T005928_A380LBCBCod, T005928_A381LBRegistro
               }
            }
         );
      }

      private short Z1051LBAno ;
      private short Z1084LBMes ;
      private short Z1070LBTipo ;
      private short Z1056LBCheq ;
      private short Z1086LBProcesado ;
      private short Z1097LBVouAno ;
      private short Z1098LBVouMes ;
      private short Z1055LBCheck ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1051LBAno ;
      private short A1084LBMes ;
      private short A1070LBTipo ;
      private short A1056LBCheq ;
      private short A1086LBProcesado ;
      private short A1097LBVouAno ;
      private short A1098LBVouMes ;
      private short A1055LBCheck ;
      private short GX_JID ;
      private short RcdFound176 ;
      private short nIsDirty_176 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1051LBAno ;
      private short ZZ1084LBMes ;
      private short ZZ1070LBTipo ;
      private short ZZ1056LBCheq ;
      private short ZZ1086LBProcesado ;
      private short ZZ1097LBVouAno ;
      private short ZZ1098LBVouMes ;
      private short ZZ1055LBCheck ;
      private int Z379LBBanCod ;
      private int Z1083LBItemTotal ;
      private int Z1089LBTASICod ;
      private int Z382LBForCod ;
      private int A379LBBanCod ;
      private int A382LBForCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLBBanCod_Enabled ;
      private int edtLBCBCod_Enabled ;
      private int edtLBRegistro_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtLBAno_Enabled ;
      private int edtLBMes_Enabled ;
      private int edtLBDocumento_Enabled ;
      private int edtLBFech_Enabled ;
      private int edtLBTipo_Enabled ;
      private int edtLBCheq_Enabled ;
      private int edtLBConcepto_Enabled ;
      private int edtLBBeneficia_Enabled ;
      private int edtLBProcesado_Enabled ;
      private int A1083LBItemTotal ;
      private int edtLBItemTotal_Enabled ;
      private int edtLBTipCmb_Enabled ;
      private int edtLBEstado_Enabled ;
      private int edtLBVouAno_Enabled ;
      private int edtLBVouMes_Enabled ;
      private int A1089LBTASICod ;
      private int edtLBTASICod_Enabled ;
      private int edtLBVouNum_Enabled ;
      private int edtLBUsuCod_Enabled ;
      private int edtLBUsuFec_Enabled ;
      private int edtLBUsuCodM_Enabled ;
      private int edtLBUsuFecM_Enabled ;
      private int edtLBForCod_Enabled ;
      private int edtLBCheck_Enabled ;
      private int edtLBCUsuCod1_Enabled ;
      private int edtLBCUsuCod2_Enabled ;
      private int edtLBDebeTot_Enabled ;
      private int edtLBHaberTot_Enabled ;
      private int edtLBTSaldo_Enabled ;
      private int edtLBTDebe_Enabled ;
      private int edtLBTHaber_Enabled ;
      private int edtLBForDsc_Enabled ;
      private int A1085LBMonCod ;
      private int edtLBMonCod_Enabled ;
      private int edtLBForSunat_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z1085LBMonCod ;
      private int idxLst ;
      private int ZZ379LBBanCod ;
      private int ZZ1083LBItemTotal ;
      private int ZZ1089LBTASICod ;
      private int ZZ382LBForCod ;
      private int ZZ1085LBMonCod ;
      private decimal Z1091LBTipCmb ;
      private decimal Z1052LBAnticipoAplic ;
      private decimal A1091LBTipCmb ;
      private decimal A1069LBDebeTot ;
      private decimal A1082LBHaberTot ;
      private decimal A1071LBTSaldo ;
      private decimal A1072LBTDebe ;
      private decimal A1073LBTHaber ;
      private decimal A1052LBAnticipoAplic ;
      private decimal A1088LBSaldoAnticipo ;
      private decimal Z1072LBTDebe ;
      private decimal Z1073LBTHaber ;
      private decimal Z1071LBTSaldo ;
      private decimal Z1082LBHaberTot ;
      private decimal Z1069LBDebeTot ;
      private decimal Z1088LBSaldoAnticipo ;
      private decimal ZZ1091LBTipCmb ;
      private decimal ZZ1052LBAnticipoAplic ;
      private decimal ZZ1072LBTDebe ;
      private decimal ZZ1073LBTHaber ;
      private decimal ZZ1071LBTSaldo ;
      private decimal ZZ1082LBHaberTot ;
      private decimal ZZ1069LBDebeTot ;
      private decimal ZZ1088LBSaldoAnticipo ;
      private string sPrefix ;
      private string Z380LBCBCod ;
      private string Z381LBRegistro ;
      private string Z1075LBDocumento ;
      private string Z1057LBConcepto ;
      private string Z1054LBBeneficia ;
      private string Z1078LBEstado ;
      private string Z1099LBVouNum ;
      private string Z1093LBUsuCod ;
      private string Z1094LBUsuCodM ;
      private string Z1062LBCUsuCod1 ;
      private string Z1063LBCUsuCod2 ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A380LBCBCod ;
      private string A381LBRegistro ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLBBanCod_Internalname ;
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
      private string edtLBBanCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtLBCBCod_Internalname ;
      private string edtLBCBCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtLBRegistro_Internalname ;
      private string edtLBRegistro_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtLBAno_Internalname ;
      private string edtLBAno_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtLBMes_Internalname ;
      private string edtLBMes_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtLBDocumento_Internalname ;
      private string A1075LBDocumento ;
      private string edtLBDocumento_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtLBFech_Internalname ;
      private string edtLBFech_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtLBTipo_Internalname ;
      private string edtLBTipo_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtLBCheq_Internalname ;
      private string edtLBCheq_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtLBConcepto_Internalname ;
      private string A1057LBConcepto ;
      private string edtLBConcepto_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtLBBeneficia_Internalname ;
      private string A1054LBBeneficia ;
      private string edtLBBeneficia_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtLBProcesado_Internalname ;
      private string edtLBProcesado_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtLBItemTotal_Internalname ;
      private string edtLBItemTotal_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtLBTipCmb_Internalname ;
      private string edtLBTipCmb_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtLBEstado_Internalname ;
      private string A1078LBEstado ;
      private string edtLBEstado_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtLBVouAno_Internalname ;
      private string edtLBVouAno_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtLBVouMes_Internalname ;
      private string edtLBVouMes_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtLBTASICod_Internalname ;
      private string edtLBTASICod_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtLBVouNum_Internalname ;
      private string A1099LBVouNum ;
      private string edtLBVouNum_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtLBUsuCod_Internalname ;
      private string A1093LBUsuCod ;
      private string edtLBUsuCod_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtLBUsuFec_Internalname ;
      private string edtLBUsuFec_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtLBUsuCodM_Internalname ;
      private string A1094LBUsuCodM ;
      private string edtLBUsuCodM_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtLBUsuFecM_Internalname ;
      private string edtLBUsuFecM_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtLBForCod_Internalname ;
      private string edtLBForCod_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtLBCheck_Internalname ;
      private string edtLBCheck_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtLBCUsuCod1_Internalname ;
      private string A1062LBCUsuCod1 ;
      private string edtLBCUsuCod1_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtLBCUsuCod2_Internalname ;
      private string A1063LBCUsuCod2 ;
      private string edtLBCUsuCod2_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtLBDebeTot_Internalname ;
      private string edtLBDebeTot_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtLBHaberTot_Internalname ;
      private string edtLBHaberTot_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtLBTSaldo_Internalname ;
      private string edtLBTSaldo_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtLBTDebe_Internalname ;
      private string edtLBTDebe_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtLBTHaber_Internalname ;
      private string edtLBTHaber_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtLBForDsc_Internalname ;
      private string A1080LBForDsc ;
      private string edtLBForDsc_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtLBMonCod_Internalname ;
      private string edtLBMonCod_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtLBForSunat_Internalname ;
      private string A1081LBForSunat ;
      private string edtLBForSunat_Jsonclick ;
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
      private string A1053LBBanAbr ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1053LBBanAbr ;
      private string Z1080LBForDsc ;
      private string Z1081LBForSunat ;
      private string sMode176 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ380LBCBCod ;
      private string ZZ381LBRegistro ;
      private string ZZ1075LBDocumento ;
      private string ZZ1057LBConcepto ;
      private string ZZ1054LBBeneficia ;
      private string ZZ1078LBEstado ;
      private string ZZ1099LBVouNum ;
      private string ZZ1093LBUsuCod ;
      private string ZZ1094LBUsuCodM ;
      private string ZZ1062LBCUsuCod1 ;
      private string ZZ1063LBCUsuCod2 ;
      private string ZZ1053LBBanAbr ;
      private string ZZ1080LBForDsc ;
      private string ZZ1081LBForSunat ;
      private DateTime Z1095LBUsuFec ;
      private DateTime Z1096LBUsuFecM ;
      private DateTime A1095LBUsuFec ;
      private DateTime A1096LBUsuFecM ;
      private DateTime ZZ1095LBUsuFec ;
      private DateTime ZZ1096LBUsuFecM ;
      private DateTime Z1079LBFech ;
      private DateTime A1079LBFech ;
      private DateTime ZZ1079LBFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00599_A381LBRegistro ;
      private short[] T00599_A1051LBAno ;
      private string[] T00599_A1053LBBanAbr ;
      private short[] T00599_A1084LBMes ;
      private string[] T00599_A1075LBDocumento ;
      private DateTime[] T00599_A1079LBFech ;
      private short[] T00599_A1070LBTipo ;
      private short[] T00599_A1056LBCheq ;
      private string[] T00599_A1057LBConcepto ;
      private string[] T00599_A1054LBBeneficia ;
      private short[] T00599_A1086LBProcesado ;
      private int[] T00599_A1083LBItemTotal ;
      private decimal[] T00599_A1091LBTipCmb ;
      private string[] T00599_A1078LBEstado ;
      private short[] T00599_A1097LBVouAno ;
      private short[] T00599_A1098LBVouMes ;
      private int[] T00599_A1089LBTASICod ;
      private string[] T00599_A1099LBVouNum ;
      private string[] T00599_A1093LBUsuCod ;
      private DateTime[] T00599_A1095LBUsuFec ;
      private string[] T00599_A1094LBUsuCodM ;
      private DateTime[] T00599_A1096LBUsuFecM ;
      private short[] T00599_A1055LBCheck ;
      private string[] T00599_A1062LBCUsuCod1 ;
      private string[] T00599_A1063LBCUsuCod2 ;
      private string[] T00599_A1080LBForDsc ;
      private string[] T00599_A1081LBForSunat ;
      private decimal[] T00599_A1052LBAnticipoAplic ;
      private int[] T00599_A379LBBanCod ;
      private string[] T00599_A380LBCBCod ;
      private int[] T00599_A382LBForCod ;
      private int[] T00599_A1085LBMonCod ;
      private decimal[] T00598_A1072LBTDebe ;
      private decimal[] T00598_A1073LBTHaber ;
      private string[] T00594_A1053LBBanAbr ;
      private int[] T00595_A1085LBMonCod ;
      private string[] T00596_A1080LBForDsc ;
      private string[] T00596_A1081LBForSunat ;
      private string[] T005910_A1053LBBanAbr ;
      private int[] T005911_A1085LBMonCod ;
      private decimal[] T005913_A1072LBTDebe ;
      private decimal[] T005913_A1073LBTHaber ;
      private string[] T005914_A1080LBForDsc ;
      private string[] T005914_A1081LBForSunat ;
      private int[] T005915_A379LBBanCod ;
      private string[] T005915_A380LBCBCod ;
      private string[] T005915_A381LBRegistro ;
      private string[] T00593_A381LBRegistro ;
      private short[] T00593_A1051LBAno ;
      private short[] T00593_A1084LBMes ;
      private string[] T00593_A1075LBDocumento ;
      private DateTime[] T00593_A1079LBFech ;
      private short[] T00593_A1070LBTipo ;
      private short[] T00593_A1056LBCheq ;
      private string[] T00593_A1057LBConcepto ;
      private string[] T00593_A1054LBBeneficia ;
      private short[] T00593_A1086LBProcesado ;
      private int[] T00593_A1083LBItemTotal ;
      private decimal[] T00593_A1091LBTipCmb ;
      private string[] T00593_A1078LBEstado ;
      private short[] T00593_A1097LBVouAno ;
      private short[] T00593_A1098LBVouMes ;
      private int[] T00593_A1089LBTASICod ;
      private string[] T00593_A1099LBVouNum ;
      private string[] T00593_A1093LBUsuCod ;
      private DateTime[] T00593_A1095LBUsuFec ;
      private string[] T00593_A1094LBUsuCodM ;
      private DateTime[] T00593_A1096LBUsuFecM ;
      private short[] T00593_A1055LBCheck ;
      private string[] T00593_A1062LBCUsuCod1 ;
      private string[] T00593_A1063LBCUsuCod2 ;
      private decimal[] T00593_A1052LBAnticipoAplic ;
      private int[] T00593_A379LBBanCod ;
      private string[] T00593_A380LBCBCod ;
      private int[] T00593_A382LBForCod ;
      private int[] T005916_A379LBBanCod ;
      private string[] T005916_A380LBCBCod ;
      private string[] T005916_A381LBRegistro ;
      private int[] T005917_A379LBBanCod ;
      private string[] T005917_A380LBCBCod ;
      private string[] T005917_A381LBRegistro ;
      private string[] T00592_A381LBRegistro ;
      private short[] T00592_A1051LBAno ;
      private short[] T00592_A1084LBMes ;
      private string[] T00592_A1075LBDocumento ;
      private DateTime[] T00592_A1079LBFech ;
      private short[] T00592_A1070LBTipo ;
      private short[] T00592_A1056LBCheq ;
      private string[] T00592_A1057LBConcepto ;
      private string[] T00592_A1054LBBeneficia ;
      private short[] T00592_A1086LBProcesado ;
      private int[] T00592_A1083LBItemTotal ;
      private decimal[] T00592_A1091LBTipCmb ;
      private string[] T00592_A1078LBEstado ;
      private short[] T00592_A1097LBVouAno ;
      private short[] T00592_A1098LBVouMes ;
      private int[] T00592_A1089LBTASICod ;
      private string[] T00592_A1099LBVouNum ;
      private string[] T00592_A1093LBUsuCod ;
      private DateTime[] T00592_A1095LBUsuFec ;
      private string[] T00592_A1094LBUsuCodM ;
      private DateTime[] T00592_A1096LBUsuFecM ;
      private short[] T00592_A1055LBCheck ;
      private string[] T00592_A1062LBCUsuCod1 ;
      private string[] T00592_A1063LBCUsuCod2 ;
      private decimal[] T00592_A1052LBAnticipoAplic ;
      private int[] T00592_A379LBBanCod ;
      private string[] T00592_A380LBCBCod ;
      private int[] T00592_A382LBForCod ;
      private string[] T005921_A1053LBBanAbr ;
      private int[] T005922_A1085LBMonCod ;
      private decimal[] T005924_A1072LBTDebe ;
      private decimal[] T005924_A1073LBTHaber ;
      private string[] T005925_A1080LBForDsc ;
      private string[] T005925_A1081LBForSunat ;
      private int[] T005926_A379LBBanCod ;
      private string[] T005926_A380LBCBCod ;
      private string[] T005926_A381LBRegistro ;
      private int[] T005926_A383LBDITem ;
      private short[] T005927_A2263CBFlujCAno ;
      private short[] T005927_A2264CBFlujCMes ;
      private int[] T005927_A2265CBFlujCBanCod ;
      private string[] T005927_A2266CBFlujCCuenta ;
      private string[] T005927_A2267CBFlujCRegistro ;
      private int[] T005928_A379LBBanCod ;
      private string[] T005928_A380LBCBCod ;
      private string[] T005928_A381LBRegistro ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tslibrobancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tslibrobancos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00599;
        prmT00599 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT00594;
        prmT00594 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0)
        };
        Object[] prmT00595;
        prmT00595 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0)
        };
        Object[] prmT00598;
        prmT00598 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT00596;
        prmT00596 = new Object[] {
        new ParDef("@LBForCod",GXType.Int32,6,0)
        };
        Object[] prmT005910;
        prmT005910 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0)
        };
        Object[] prmT005911;
        prmT005911 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0)
        };
        Object[] prmT005913;
        prmT005913 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005914;
        prmT005914 = new Object[] {
        new ParDef("@LBForCod",GXType.Int32,6,0)
        };
        Object[] prmT005915;
        prmT005915 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT00593;
        prmT00593 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005916;
        prmT005916 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005917;
        prmT005917 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT00592;
        prmT00592 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005918;
        prmT005918 = new Object[] {
        new ParDef("@LBRegistro",GXType.NChar,10,0) ,
        new ParDef("@LBAno",GXType.Int16,4,0) ,
        new ParDef("@LBMes",GXType.Int16,2,0) ,
        new ParDef("@LBDocumento",GXType.NChar,20,0) ,
        new ParDef("@LBFech",GXType.Date,8,0) ,
        new ParDef("@LBTipo",GXType.Int16,1,0) ,
        new ParDef("@LBCheq",GXType.Int16,1,0) ,
        new ParDef("@LBConcepto",GXType.NChar,60,0) ,
        new ParDef("@LBBeneficia",GXType.NChar,60,0) ,
        new ParDef("@LBProcesado",GXType.Int16,1,0) ,
        new ParDef("@LBItemTotal",GXType.Int32,6,0) ,
        new ParDef("@LBTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LBEstado",GXType.NChar,1,0) ,
        new ParDef("@LBVouAno",GXType.Int16,4,0) ,
        new ParDef("@LBVouMes",GXType.Int16,2,0) ,
        new ParDef("@LBTASICod",GXType.Int32,6,0) ,
        new ParDef("@LBVouNum",GXType.NChar,10,0) ,
        new ParDef("@LBUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LBUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LBUsuCodM",GXType.NChar,10,0) ,
        new ParDef("@LBUsuFecM",GXType.DateTime,8,5) ,
        new ParDef("@LBCheck",GXType.Int16,1,0) ,
        new ParDef("@LBCUsuCod1",GXType.NChar,10,0) ,
        new ParDef("@LBCUsuCod2",GXType.NChar,10,0) ,
        new ParDef("@LBAnticipoAplic",GXType.Decimal,15,2) ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBForCod",GXType.Int32,6,0) ,
        new ParDef("@LBTDebe",GXType.Decimal,15,2) ,
        new ParDef("@LBTHaber",GXType.Decimal,15,2)
        };
        Object[] prmT005919;
        prmT005919 = new Object[] {
        new ParDef("@LBAno",GXType.Int16,4,0) ,
        new ParDef("@LBMes",GXType.Int16,2,0) ,
        new ParDef("@LBDocumento",GXType.NChar,20,0) ,
        new ParDef("@LBFech",GXType.Date,8,0) ,
        new ParDef("@LBTipo",GXType.Int16,1,0) ,
        new ParDef("@LBCheq",GXType.Int16,1,0) ,
        new ParDef("@LBConcepto",GXType.NChar,60,0) ,
        new ParDef("@LBBeneficia",GXType.NChar,60,0) ,
        new ParDef("@LBProcesado",GXType.Int16,1,0) ,
        new ParDef("@LBItemTotal",GXType.Int32,6,0) ,
        new ParDef("@LBTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@LBEstado",GXType.NChar,1,0) ,
        new ParDef("@LBVouAno",GXType.Int16,4,0) ,
        new ParDef("@LBVouMes",GXType.Int16,2,0) ,
        new ParDef("@LBTASICod",GXType.Int32,6,0) ,
        new ParDef("@LBVouNum",GXType.NChar,10,0) ,
        new ParDef("@LBUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LBUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LBUsuCodM",GXType.NChar,10,0) ,
        new ParDef("@LBUsuFecM",GXType.DateTime,8,5) ,
        new ParDef("@LBCheck",GXType.Int16,1,0) ,
        new ParDef("@LBCUsuCod1",GXType.NChar,10,0) ,
        new ParDef("@LBCUsuCod2",GXType.NChar,10,0) ,
        new ParDef("@LBAnticipoAplic",GXType.Decimal,15,2) ,
        new ParDef("@LBForCod",GXType.Int32,6,0) ,
        new ParDef("@LBTDebe",GXType.Decimal,15,2) ,
        new ParDef("@LBTHaber",GXType.Decimal,15,2) ,
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005920;
        prmT005920 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005926;
        prmT005926 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005927;
        prmT005927 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005928;
        prmT005928 = new Object[] {
        };
        Object[] prmT005921;
        prmT005921 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0)
        };
        Object[] prmT005922;
        prmT005922 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0)
        };
        Object[] prmT005924;
        prmT005924 = new Object[] {
        new ParDef("@LBBanCod",GXType.Int32,6,0) ,
        new ParDef("@LBCBCod",GXType.NChar,20,0) ,
        new ParDef("@LBRegistro",GXType.NChar,10,0)
        };
        Object[] prmT005925;
        prmT005925 = new Object[] {
        new ParDef("@LBForCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00592", "SELECT [LBRegistro], [LBAno], [LBMes], [LBDocumento], [LBFech], [LBTipo], [LBCheq], [LBConcepto], [LBBeneficia], [LBProcesado], [LBItemTotal], [LBTipCmb], [LBEstado], [LBVouAno], [LBVouMes], [LBTASICod], [LBVouNum], [LBUsuCod], [LBUsuFec], [LBUsuCodM], [LBUsuFecM], [LBCheck], [LBCUsuCod1], [LBCUsuCod2], [LBAnticipoAplic], [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBForCod] AS LBForCod FROM [TSLIBROBANCOS] WITH (UPDLOCK) WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT00592,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00593", "SELECT [LBRegistro], [LBAno], [LBMes], [LBDocumento], [LBFech], [LBTipo], [LBCheq], [LBConcepto], [LBBeneficia], [LBProcesado], [LBItemTotal], [LBTipCmb], [LBEstado], [LBVouAno], [LBVouMes], [LBTASICod], [LBVouNum], [LBUsuCod], [LBUsuFec], [LBUsuCodM], [LBUsuFecM], [LBCheck], [LBCUsuCod1], [LBCUsuCod2], [LBAnticipoAplic], [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBForCod] AS LBForCod FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT00593,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00594", "SELECT [BanAbr] AS LBBanAbr FROM [TSBANCOS] WHERE [BanCod] = @LBBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00594,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00595", "SELECT [MonCod] AS LBMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @LBBanCod AND [CBCod] = @LBCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00595,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00596", "SELECT [ForDsc] AS LBForDsc, [ForSunat] AS LBForSunat FROM [CFORMAPAGO] WHERE [ForCod] = @LBForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00596,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00598", "SELECT COALESCE( T1.[LBTDebe], 0) AS LBTDebe, COALESCE( T1.[LBTHaber], 0) AS LBTHaber FROM (SELECT SUM([LBDDebe]) AS LBTDebe, [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro], SUM([LBDHaber]) AS LBTHaber FROM [TSLIBROBANCOSDET] GROUP BY [LBBanCod], [LBCBCod], [LBRegistro] ) T1 WHERE T1.[LBBanCod] = @LBBanCod AND T1.[LBCBCod] = @LBCBCod AND T1.[LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT00598,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00599", "SELECT TM1.[LBRegistro], TM1.[LBAno], T2.[BanAbr] AS LBBanAbr, TM1.[LBMes], TM1.[LBDocumento], TM1.[LBFech], TM1.[LBTipo], TM1.[LBCheq], TM1.[LBConcepto], TM1.[LBBeneficia], TM1.[LBProcesado], TM1.[LBItemTotal], TM1.[LBTipCmb], TM1.[LBEstado], TM1.[LBVouAno], TM1.[LBVouMes], TM1.[LBTASICod], TM1.[LBVouNum], TM1.[LBUsuCod], TM1.[LBUsuFec], TM1.[LBUsuCodM], TM1.[LBUsuFecM], TM1.[LBCheck], TM1.[LBCUsuCod1], TM1.[LBCUsuCod2], T4.[ForDsc] AS LBForDsc, T4.[ForSunat] AS LBForSunat, TM1.[LBAnticipoAplic], TM1.[LBBanCod] AS LBBanCod, TM1.[LBCBCod] AS LBCBCod, TM1.[LBForCod] AS LBForCod, T3.[MonCod] AS LBMonCod FROM ((([TSLIBROBANCOS] TM1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = TM1.[LBBanCod]) INNER JOIN [TSCUENTABANCO] T3 ON T3.[BanCod] = TM1.[LBBanCod] AND T3.[CBCod] = TM1.[LBCBCod]) INNER JOIN [CFORMAPAGO] T4 ON T4.[ForCod] = TM1.[LBForCod]) WHERE TM1.[LBBanCod] = @LBBanCod and TM1.[LBCBCod] = @LBCBCod and TM1.[LBRegistro] = @LBRegistro ORDER BY TM1.[LBBanCod], TM1.[LBCBCod], TM1.[LBRegistro]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00599,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005910", "SELECT [BanAbr] AS LBBanAbr FROM [TSBANCOS] WHERE [BanCod] = @LBBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005910,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005911", "SELECT [MonCod] AS LBMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @LBBanCod AND [CBCod] = @LBCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005911,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005913", "SELECT COALESCE( T1.[LBTDebe], 0) AS LBTDebe, COALESCE( T1.[LBTHaber], 0) AS LBTHaber FROM (SELECT SUM([LBDDebe]) AS LBTDebe, [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro], SUM([LBDHaber]) AS LBTHaber FROM [TSLIBROBANCOSDET] GROUP BY [LBBanCod], [LBCBCod], [LBRegistro] ) T1 WHERE T1.[LBBanCod] = @LBBanCod AND T1.[LBCBCod] = @LBCBCod AND T1.[LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005913,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005914", "SELECT [ForDsc] AS LBForDsc, [ForSunat] AS LBForSunat FROM [CFORMAPAGO] WHERE [ForCod] = @LBForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005914,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005915", "SELECT [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro] FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005915,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005916", "SELECT TOP 1 [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro] FROM [TSLIBROBANCOS] WHERE ( [LBBanCod] > @LBBanCod or [LBBanCod] = @LBBanCod and [LBCBCod] > @LBCBCod or [LBCBCod] = @LBCBCod and [LBBanCod] = @LBBanCod and [LBRegistro] > @LBRegistro) ORDER BY [LBBanCod], [LBCBCod], [LBRegistro]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005916,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005917", "SELECT TOP 1 [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro] FROM [TSLIBROBANCOS] WHERE ( [LBBanCod] < @LBBanCod or [LBBanCod] = @LBBanCod and [LBCBCod] < @LBCBCod or [LBCBCod] = @LBCBCod and [LBBanCod] = @LBBanCod and [LBRegistro] < @LBRegistro) ORDER BY [LBBanCod] DESC, [LBCBCod] DESC, [LBRegistro] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005917,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005918", "INSERT INTO [TSLIBROBANCOS]([LBRegistro], [LBAno], [LBMes], [LBDocumento], [LBFech], [LBTipo], [LBCheq], [LBConcepto], [LBBeneficia], [LBProcesado], [LBItemTotal], [LBTipCmb], [LBEstado], [LBVouAno], [LBVouMes], [LBTASICod], [LBVouNum], [LBUsuCod], [LBUsuFec], [LBUsuCodM], [LBUsuFecM], [LBCheck], [LBCUsuCod1], [LBCUsuCod2], [LBAnticipoAplic], [LBBanCod], [LBCBCod], [LBForCod], [LBTDebe], [LBTHaber]) VALUES(@LBRegistro, @LBAno, @LBMes, @LBDocumento, @LBFech, @LBTipo, @LBCheq, @LBConcepto, @LBBeneficia, @LBProcesado, @LBItemTotal, @LBTipCmb, @LBEstado, @LBVouAno, @LBVouMes, @LBTASICod, @LBVouNum, @LBUsuCod, @LBUsuFec, @LBUsuCodM, @LBUsuFecM, @LBCheck, @LBCUsuCod1, @LBCUsuCod2, @LBAnticipoAplic, @LBBanCod, @LBCBCod, @LBForCod, @LBTDebe, @LBTHaber)", GxErrorMask.GX_NOMASK,prmT005918)
           ,new CursorDef("T005919", "UPDATE [TSLIBROBANCOS] SET [LBAno]=@LBAno, [LBMes]=@LBMes, [LBDocumento]=@LBDocumento, [LBFech]=@LBFech, [LBTipo]=@LBTipo, [LBCheq]=@LBCheq, [LBConcepto]=@LBConcepto, [LBBeneficia]=@LBBeneficia, [LBProcesado]=@LBProcesado, [LBItemTotal]=@LBItemTotal, [LBTipCmb]=@LBTipCmb, [LBEstado]=@LBEstado, [LBVouAno]=@LBVouAno, [LBVouMes]=@LBVouMes, [LBTASICod]=@LBTASICod, [LBVouNum]=@LBVouNum, [LBUsuCod]=@LBUsuCod, [LBUsuFec]=@LBUsuFec, [LBUsuCodM]=@LBUsuCodM, [LBUsuFecM]=@LBUsuFecM, [LBCheck]=@LBCheck, [LBCUsuCod1]=@LBCUsuCod1, [LBCUsuCod2]=@LBCUsuCod2, [LBAnticipoAplic]=@LBAnticipoAplic, [LBForCod]=@LBForCod, [LBTDebe]=@LBTDebe, [LBTHaber]=@LBTHaber  WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro", GxErrorMask.GX_NOMASK,prmT005919)
           ,new CursorDef("T005920", "DELETE FROM [TSLIBROBANCOS]  WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro", GxErrorMask.GX_NOMASK,prmT005920)
           ,new CursorDef("T005921", "SELECT [BanAbr] AS LBBanAbr FROM [TSBANCOS] WHERE [BanCod] = @LBBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005921,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005922", "SELECT [MonCod] AS LBMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @LBBanCod AND [CBCod] = @LBCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005922,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005924", "SELECT COALESCE( T1.[LBTDebe], 0) AS LBTDebe, COALESCE( T1.[LBTHaber], 0) AS LBTHaber FROM (SELECT SUM([LBDDebe]) AS LBTDebe, [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro], SUM([LBDHaber]) AS LBTHaber FROM [TSLIBROBANCOSDET] GROUP BY [LBBanCod], [LBCBCod], [LBRegistro] ) T1 WHERE T1.[LBBanCod] = @LBBanCod AND T1.[LBCBCod] = @LBCBCod AND T1.[LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005924,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005925", "SELECT [ForDsc] AS LBForDsc, [ForSunat] AS LBForSunat FROM [CFORMAPAGO] WHERE [ForCod] = @LBForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005925,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005926", "SELECT TOP 1 [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBBanCod] = @LBBanCod AND [LBCBCod] = @LBCBCod AND [LBRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005926,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005927", "SELECT TOP 1 [CBFlujCAno], [CBFlujCMes], [CBFlujCBanCod], [CBFlujCCuenta], [CBFlujCRegistro] FROM [CBFLUJOCONCEPTOS] WHERE [CBFlujCBanCod] = @LBBanCod AND [CBFlujCCuenta] = @LBCBCod AND [CBFlujCRegistro] = @LBRegistro ",true, GxErrorMask.GX_NOMASK, false, this,prmT005927,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005928", "SELECT [LBBanCod] AS LBBanCod, [LBCBCod] AS LBCBCod, [LBRegistro] FROM [TSLIBROBANCOS] ORDER BY [LBBanCod], [LBCBCod], [LBRegistro]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005928,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 60);
              ((string[]) buf[8])[0] = rslt.getString(9, 60);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 10);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(19);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 10);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((decimal[]) buf[24])[0] = rslt.getDecimal(25);
              ((int[]) buf[25])[0] = rslt.getInt(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 20);
              ((int[]) buf[27])[0] = rslt.getInt(28);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 60);
              ((string[]) buf[8])[0] = rslt.getString(9, 60);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 10);
              ((string[]) buf[17])[0] = rslt.getString(18, 10);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(19);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 10);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((decimal[]) buf[24])[0] = rslt.getDecimal(25);
              ((int[]) buf[25])[0] = rslt.getInt(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 20);
              ((int[]) buf[27])[0] = rslt.getInt(28);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 60);
              ((string[]) buf[9])[0] = rslt.getString(10, 60);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 1);
              ((short[]) buf[14])[0] = rslt.getShort(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 10);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 10);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((string[]) buf[24])[0] = rslt.getString(25, 10);
              ((string[]) buf[25])[0] = rslt.getString(26, 100);
              ((string[]) buf[26])[0] = rslt.getString(27, 5);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(28);
              ((int[]) buf[28])[0] = rslt.getInt(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 20);
              ((int[]) buf[30])[0] = rslt.getInt(31);
              ((int[]) buf[31])[0] = rslt.getInt(32);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 19 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 5);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 22 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
     }
  }

}

}
