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
   public class tsanticipos : GXDataArea
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
            A244PrvCod = GetPar( "PrvCod");
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A355ConBCod = (int)(NumberUtil.Val( GetPar( "ConBCod"), "."));
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A355ConBCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A374ConBCueCod = GetPar( "ConBCueCod");
            AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A374ConBCueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A356TSAntBanCod = (int)(NumberUtil.Val( GetPar( "TSAntBanCod"), "."));
            AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrimStr( (decimal)(A356TSAntBanCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A356TSAntBanCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A356TSAntBanCod = (int)(NumberUtil.Val( GetPar( "TSAntBanCod"), "."));
            AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrimStr( (decimal)(A356TSAntBanCod), 6, 0));
            A357TSAntCBCod = GetPar( "TSAntCBCod");
            AssignAttri("", false, "A357TSAntCBCod", A357TSAntCBCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A356TSAntBanCod, A357TSAntCBCod) ;
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
            Form.Meta.addItem("description", "Anticipos Proveedores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTSAntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsanticipos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsanticipos( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSANTICIPOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "N° Anticipo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntCod_Internalname, A354TSAntCod, StringUtil.RTrim( context.localUtil.Format( A354TSAntCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Fecha", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTSAntFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTSAntFec_Internalname, context.localUtil.Format(A1962TSAntFec, "99/99/99"), context.localUtil.Format( A1962TSAntFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSANTICIPOS.htm");
         GxWebStd.gx_bitmap( context, edtTSAntFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTSAntFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Proveedor", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Razon Social", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvDsc_Internalname, StringUtil.RTrim( A247PrvDsc), StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "N° Documento", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntDoc_Internalname, A1960TSAntDoc, StringUtil.RTrim( context.localUtil.Format( A1960TSAntDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtConBCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A355ConBCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtConBCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A355ConBCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A355ConBCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConBCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Banco", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A356TSAntBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSAntBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A356TSAntBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A356TSAntBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "N° Cuenta", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntCBCod_Internalname, StringUtil.RTrim( A357TSAntCBCod), StringUtil.RTrim( context.localUtil.Format( A357TSAntCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Importe", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A1964TSAntImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtTSAntImporte_Enabled!=0) ? context.localUtil.Format( A1964TSAntImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1964TSAntImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Concepto", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntConcepto_Internalname, A1959TSAntConcepto, StringUtil.RTrim( context.localUtil.Format( A1959TSAntConcepto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntConcepto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "N° Registro", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntBanReg_Internalname, A1957TSAntBanReg, StringUtil.RTrim( context.localUtil.Format( A1957TSAntBanReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntBanReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntBanReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Tipo Cambio", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1966TSAntTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtTSAntTipCmb_Enabled!=0) ? context.localUtil.Format( A1966TSAntTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1966TSAntTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Beneficiario", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntBeneficiario_Internalname, A1958TSAntBeneficiario, StringUtil.RTrim( context.localUtil.Format( A1958TSAntBeneficiario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntBeneficiario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntBeneficiario_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Moneda Origen", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1965TSAntMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSAntMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1965TSAntMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1965TSAntMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "N° Doc Referencia", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntDocRef_Internalname, A1961TSAntDocRef, StringUtil.RTrim( context.localUtil.Format( A1961TSAntDocRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntDocRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntDocRef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Forma de Pago", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSAntForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1963TSAntForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSAntForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1963TSAntForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1963TSAntForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Descripción", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtConBCueDsc_Internalname, StringUtil.RTrim( A744ConBCueDsc), StringUtil.RTrim( context.localUtil.Format( A744ConBCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtConBCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtConBCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Banco", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTSAntBanDsc_Internalname, StringUtil.RTrim( A1953TSAntBanDsc), StringUtil.RTrim( context.localUtil.Format( A1953TSAntBanDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntBanDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntBanDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Moneda", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTSAntBanMonAbr_Internalname, StringUtil.RTrim( A1954TSAntBanMonAbr), StringUtil.RTrim( context.localUtil.Format( A1954TSAntBanMonAbr, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntBanMonAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntBanMonAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Moneda", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTSAntBanMonDsc_Internalname, StringUtil.RTrim( A1956TSAntBanMonDsc), StringUtil.RTrim( context.localUtil.Format( A1956TSAntBanMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSAntBanMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSAntBanMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSANTICIPOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 119,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSANTICIPOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSANTICIPOS.htm");
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
            Z354TSAntCod = cgiGet( "Z354TSAntCod");
            Z1962TSAntFec = context.localUtil.CToD( cgiGet( "Z1962TSAntFec"), 0);
            Z1960TSAntDoc = cgiGet( "Z1960TSAntDoc");
            Z1964TSAntImporte = context.localUtil.CToN( cgiGet( "Z1964TSAntImporte"), ".", ",");
            Z1959TSAntConcepto = cgiGet( "Z1959TSAntConcepto");
            Z1957TSAntBanReg = cgiGet( "Z1957TSAntBanReg");
            Z1966TSAntTipCmb = context.localUtil.CToN( cgiGet( "Z1966TSAntTipCmb"), ".", ",");
            Z1958TSAntBeneficiario = cgiGet( "Z1958TSAntBeneficiario");
            Z1965TSAntMonCod = (int)(context.localUtil.CToN( cgiGet( "Z1965TSAntMonCod"), ".", ","));
            Z1961TSAntDocRef = cgiGet( "Z1961TSAntDocRef");
            Z1963TSAntForCod = (int)(context.localUtil.CToN( cgiGet( "Z1963TSAntForCod"), ".", ","));
            Z244PrvCod = cgiGet( "Z244PrvCod");
            Z355ConBCod = (int)(context.localUtil.CToN( cgiGet( "Z355ConBCod"), ".", ","));
            Z356TSAntBanCod = (int)(context.localUtil.CToN( cgiGet( "Z356TSAntBanCod"), ".", ","));
            Z357TSAntCBCod = cgiGet( "Z357TSAntCBCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A374ConBCueCod = cgiGet( "CONBCUECOD");
            /* Read variables values. */
            A354TSAntCod = cgiGet( edtTSAntCod_Internalname);
            AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
            if ( context.localUtil.VCDate( cgiGet( edtTSAntFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "TSANTFEC");
               AnyError = 1;
               GX_FocusControl = edtTSAntFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1962TSAntFec = DateTime.MinValue;
               AssignAttri("", false, "A1962TSAntFec", context.localUtil.Format(A1962TSAntFec, "99/99/99"));
            }
            else
            {
               A1962TSAntFec = context.localUtil.CToD( cgiGet( edtTSAntFec_Internalname), 2);
               AssignAttri("", false, "A1962TSAntFec", context.localUtil.Format(A1962TSAntFec, "99/99/99"));
            }
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A247PrvDsc = cgiGet( edtPrvDsc_Internalname);
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1960TSAntDoc = cgiGet( edtTSAntDoc_Internalname);
            AssignAttri("", false, "A1960TSAntDoc", A1960TSAntDoc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CONBCOD");
               AnyError = 1;
               GX_FocusControl = edtConBCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A355ConBCod = 0;
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            }
            else
            {
               A355ConBCod = (int)(context.localUtil.CToN( cgiGet( edtConBCod_Internalname), ".", ","));
               AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSAntBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSAntBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSANTBANCOD");
               AnyError = 1;
               GX_FocusControl = edtTSAntBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A356TSAntBanCod = 0;
               AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrimStr( (decimal)(A356TSAntBanCod), 6, 0));
            }
            else
            {
               A356TSAntBanCod = (int)(context.localUtil.CToN( cgiGet( edtTSAntBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrimStr( (decimal)(A356TSAntBanCod), 6, 0));
            }
            A357TSAntCBCod = cgiGet( edtTSAntCBCod_Internalname);
            AssignAttri("", false, "A357TSAntCBCod", A357TSAntCBCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSAntImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTSAntImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSANTIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtTSAntImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1964TSAntImporte = 0;
               AssignAttri("", false, "A1964TSAntImporte", StringUtil.LTrimStr( A1964TSAntImporte, 15, 2));
            }
            else
            {
               A1964TSAntImporte = context.localUtil.CToN( cgiGet( edtTSAntImporte_Internalname), ".", ",");
               AssignAttri("", false, "A1964TSAntImporte", StringUtil.LTrimStr( A1964TSAntImporte, 15, 2));
            }
            A1959TSAntConcepto = cgiGet( edtTSAntConcepto_Internalname);
            AssignAttri("", false, "A1959TSAntConcepto", A1959TSAntConcepto);
            A1957TSAntBanReg = cgiGet( edtTSAntBanReg_Internalname);
            AssignAttri("", false, "A1957TSAntBanReg", A1957TSAntBanReg);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSAntTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSAntTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSANTTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtTSAntTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1966TSAntTipCmb = 0;
               AssignAttri("", false, "A1966TSAntTipCmb", StringUtil.LTrimStr( A1966TSAntTipCmb, 15, 5));
            }
            else
            {
               A1966TSAntTipCmb = context.localUtil.CToN( cgiGet( edtTSAntTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1966TSAntTipCmb", StringUtil.LTrimStr( A1966TSAntTipCmb, 15, 5));
            }
            A1958TSAntBeneficiario = cgiGet( edtTSAntBeneficiario_Internalname);
            AssignAttri("", false, "A1958TSAntBeneficiario", A1958TSAntBeneficiario);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSAntMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSAntMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSANTMONCOD");
               AnyError = 1;
               GX_FocusControl = edtTSAntMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1965TSAntMonCod = 0;
               AssignAttri("", false, "A1965TSAntMonCod", StringUtil.LTrimStr( (decimal)(A1965TSAntMonCod), 6, 0));
            }
            else
            {
               A1965TSAntMonCod = (int)(context.localUtil.CToN( cgiGet( edtTSAntMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A1965TSAntMonCod", StringUtil.LTrimStr( (decimal)(A1965TSAntMonCod), 6, 0));
            }
            A1961TSAntDocRef = cgiGet( edtTSAntDocRef_Internalname);
            AssignAttri("", false, "A1961TSAntDocRef", A1961TSAntDocRef);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSAntForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSAntForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSANTFORCOD");
               AnyError = 1;
               GX_FocusControl = edtTSAntForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1963TSAntForCod = 0;
               AssignAttri("", false, "A1963TSAntForCod", StringUtil.LTrimStr( (decimal)(A1963TSAntForCod), 6, 0));
            }
            else
            {
               A1963TSAntForCod = (int)(context.localUtil.CToN( cgiGet( edtTSAntForCod_Internalname), ".", ","));
               AssignAttri("", false, "A1963TSAntForCod", StringUtil.LTrimStr( (decimal)(A1963TSAntForCod), 6, 0));
            }
            A744ConBCueDsc = cgiGet( edtConBCueDsc_Internalname);
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            A1953TSAntBanDsc = cgiGet( edtTSAntBanDsc_Internalname);
            AssignAttri("", false, "A1953TSAntBanDsc", A1953TSAntBanDsc);
            A1954TSAntBanMonAbr = cgiGet( edtTSAntBanMonAbr_Internalname);
            AssignAttri("", false, "A1954TSAntBanMonAbr", A1954TSAntBanMonAbr);
            A1956TSAntBanMonDsc = cgiGet( edtTSAntBanMonDsc_Internalname);
            AssignAttri("", false, "A1956TSAntBanMonDsc", A1956TSAntBanMonDsc);
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
               A354TSAntCod = GetPar( "TSAntCod");
               AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
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
               InitAll4Y165( ) ;
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
         DisableAttributes4Y165( ) ;
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

      protected void CONFIRM_4Y0( )
      {
         BeforeValidate4Y165( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls4Y165( ) ;
            }
            else
            {
               CheckExtendedTable4Y165( ) ;
               if ( AnyError == 0 )
               {
                  ZM4Y165( 3) ;
                  ZM4Y165( 4) ;
                  ZM4Y165( 5) ;
                  ZM4Y165( 6) ;
                  ZM4Y165( 7) ;
               }
               CloseExtendedTableCursors4Y165( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues4Y0( ) ;
         }
      }

      protected void ResetCaption4Y0( )
      {
      }

      protected void ZM4Y165( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1962TSAntFec = T004Y3_A1962TSAntFec[0];
               Z1960TSAntDoc = T004Y3_A1960TSAntDoc[0];
               Z1964TSAntImporte = T004Y3_A1964TSAntImporte[0];
               Z1959TSAntConcepto = T004Y3_A1959TSAntConcepto[0];
               Z1957TSAntBanReg = T004Y3_A1957TSAntBanReg[0];
               Z1966TSAntTipCmb = T004Y3_A1966TSAntTipCmb[0];
               Z1958TSAntBeneficiario = T004Y3_A1958TSAntBeneficiario[0];
               Z1965TSAntMonCod = T004Y3_A1965TSAntMonCod[0];
               Z1961TSAntDocRef = T004Y3_A1961TSAntDocRef[0];
               Z1963TSAntForCod = T004Y3_A1963TSAntForCod[0];
               Z244PrvCod = T004Y3_A244PrvCod[0];
               Z355ConBCod = T004Y3_A355ConBCod[0];
               Z356TSAntBanCod = T004Y3_A356TSAntBanCod[0];
               Z357TSAntCBCod = T004Y3_A357TSAntCBCod[0];
            }
            else
            {
               Z1962TSAntFec = A1962TSAntFec;
               Z1960TSAntDoc = A1960TSAntDoc;
               Z1964TSAntImporte = A1964TSAntImporte;
               Z1959TSAntConcepto = A1959TSAntConcepto;
               Z1957TSAntBanReg = A1957TSAntBanReg;
               Z1966TSAntTipCmb = A1966TSAntTipCmb;
               Z1958TSAntBeneficiario = A1958TSAntBeneficiario;
               Z1965TSAntMonCod = A1965TSAntMonCod;
               Z1961TSAntDocRef = A1961TSAntDocRef;
               Z1963TSAntForCod = A1963TSAntForCod;
               Z244PrvCod = A244PrvCod;
               Z355ConBCod = A355ConBCod;
               Z356TSAntBanCod = A356TSAntBanCod;
               Z357TSAntCBCod = A357TSAntCBCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z354TSAntCod = A354TSAntCod;
            Z1962TSAntFec = A1962TSAntFec;
            Z1960TSAntDoc = A1960TSAntDoc;
            Z1964TSAntImporte = A1964TSAntImporte;
            Z1959TSAntConcepto = A1959TSAntConcepto;
            Z1957TSAntBanReg = A1957TSAntBanReg;
            Z1966TSAntTipCmb = A1966TSAntTipCmb;
            Z1958TSAntBeneficiario = A1958TSAntBeneficiario;
            Z1965TSAntMonCod = A1965TSAntMonCod;
            Z1961TSAntDocRef = A1961TSAntDocRef;
            Z1963TSAntForCod = A1963TSAntForCod;
            Z244PrvCod = A244PrvCod;
            Z355ConBCod = A355ConBCod;
            Z356TSAntBanCod = A356TSAntBanCod;
            Z357TSAntCBCod = A357TSAntCBCod;
            Z247PrvDsc = A247PrvDsc;
            Z374ConBCueCod = A374ConBCueCod;
            Z744ConBCueDsc = A744ConBCueDsc;
            Z1953TSAntBanDsc = A1953TSAntBanDsc;
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

      protected void Load4Y165( )
      {
         /* Using cursor T004Y9 */
         pr_default.execute(7, new Object[] {A354TSAntCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound165 = 1;
            A374ConBCueCod = T004Y9_A374ConBCueCod[0];
            A1962TSAntFec = T004Y9_A1962TSAntFec[0];
            AssignAttri("", false, "A1962TSAntFec", context.localUtil.Format(A1962TSAntFec, "99/99/99"));
            A247PrvDsc = T004Y9_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1960TSAntDoc = T004Y9_A1960TSAntDoc[0];
            AssignAttri("", false, "A1960TSAntDoc", A1960TSAntDoc);
            A1964TSAntImporte = T004Y9_A1964TSAntImporte[0];
            AssignAttri("", false, "A1964TSAntImporte", StringUtil.LTrimStr( A1964TSAntImporte, 15, 2));
            A1959TSAntConcepto = T004Y9_A1959TSAntConcepto[0];
            AssignAttri("", false, "A1959TSAntConcepto", A1959TSAntConcepto);
            A1957TSAntBanReg = T004Y9_A1957TSAntBanReg[0];
            AssignAttri("", false, "A1957TSAntBanReg", A1957TSAntBanReg);
            A1966TSAntTipCmb = T004Y9_A1966TSAntTipCmb[0];
            AssignAttri("", false, "A1966TSAntTipCmb", StringUtil.LTrimStr( A1966TSAntTipCmb, 15, 5));
            A1958TSAntBeneficiario = T004Y9_A1958TSAntBeneficiario[0];
            AssignAttri("", false, "A1958TSAntBeneficiario", A1958TSAntBeneficiario);
            A1965TSAntMonCod = T004Y9_A1965TSAntMonCod[0];
            AssignAttri("", false, "A1965TSAntMonCod", StringUtil.LTrimStr( (decimal)(A1965TSAntMonCod), 6, 0));
            A1961TSAntDocRef = T004Y9_A1961TSAntDocRef[0];
            AssignAttri("", false, "A1961TSAntDocRef", A1961TSAntDocRef);
            A1963TSAntForCod = T004Y9_A1963TSAntForCod[0];
            AssignAttri("", false, "A1963TSAntForCod", StringUtil.LTrimStr( (decimal)(A1963TSAntForCod), 6, 0));
            A744ConBCueDsc = T004Y9_A744ConBCueDsc[0];
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            A1953TSAntBanDsc = T004Y9_A1953TSAntBanDsc[0];
            AssignAttri("", false, "A1953TSAntBanDsc", A1953TSAntBanDsc);
            A244PrvCod = T004Y9_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A355ConBCod = T004Y9_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            A356TSAntBanCod = T004Y9_A356TSAntBanCod[0];
            AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrimStr( (decimal)(A356TSAntBanCod), 6, 0));
            A357TSAntCBCod = T004Y9_A357TSAntCBCod[0];
            AssignAttri("", false, "A357TSAntCBCod", A357TSAntCBCod);
            ZM4Y165( -2) ;
         }
         pr_default.close(7);
         OnLoadActions4Y165( ) ;
      }

      protected void OnLoadActions4Y165( )
      {
      }

      protected void CheckExtendedTable4Y165( )
      {
         nIsDirty_165 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1962TSAntFec) || ( DateTimeUtil.ResetTime ( A1962TSAntFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "TSANTFEC");
            AnyError = 1;
            GX_FocusControl = edtTSAntFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T004Y4 */
         pr_default.execute(2, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T004Y4_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         pr_default.close(2);
         /* Using cursor T004Y5 */
         pr_default.execute(3, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Bancos'.", "ForeignKeyNotFound", 1, "CONBCOD");
            AnyError = 1;
            GX_FocusControl = edtConBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A374ConBCueCod = T004Y5_A374ConBCueCod[0];
         pr_default.close(3);
         /* Using cursor T004Y8 */
         pr_default.execute(6, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
         }
         A744ConBCueDsc = T004Y8_A744ConBCueDsc[0];
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         pr_default.close(6);
         /* Using cursor T004Y6 */
         pr_default.execute(4, new Object[] {A356TSAntBanCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "TSANTBANCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1953TSAntBanDsc = T004Y6_A1953TSAntBanDsc[0];
         AssignAttri("", false, "A1953TSAntBanDsc", A1953TSAntBanDsc);
         pr_default.close(4);
         /* Using cursor T004Y7 */
         pr_default.execute(5, new Object[] {A356TSAntBanCod, A357TSAntCBCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "TSANTCBCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors4Y165( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(6);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A244PrvCod )
      {
         /* Using cursor T004Y10 */
         pr_default.execute(8, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T004Y10_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A247PrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_4( int A355ConBCod )
      {
         /* Using cursor T004Y11 */
         pr_default.execute(9, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Bancos'.", "ForeignKeyNotFound", 1, "CONBCOD");
            AnyError = 1;
            GX_FocusControl = edtConBCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A374ConBCueCod = T004Y11_A374ConBCueCod[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A374ConBCueCod))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_7( string A374ConBCueCod )
      {
         /* Using cursor T004Y12 */
         pr_default.execute(10, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
         }
         A744ConBCueDsc = T004Y12_A744ConBCueDsc[0];
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A744ConBCueDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_5( int A356TSAntBanCod )
      {
         /* Using cursor T004Y13 */
         pr_default.execute(11, new Object[] {A356TSAntBanCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "TSANTBANCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1953TSAntBanDsc = T004Y13_A1953TSAntBanDsc[0];
         AssignAttri("", false, "A1953TSAntBanDsc", A1953TSAntBanDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1953TSAntBanDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_6( int A356TSAntBanCod ,
                               string A357TSAntCBCod )
      {
         /* Using cursor T004Y14 */
         pr_default.execute(12, new Object[] {A356TSAntBanCod, A357TSAntCBCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "TSANTCBCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntBanCod_Internalname;
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

      protected void GetKey4Y165( )
      {
         /* Using cursor T004Y15 */
         pr_default.execute(13, new Object[] {A354TSAntCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound165 = 1;
         }
         else
         {
            RcdFound165 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004Y3 */
         pr_default.execute(1, new Object[] {A354TSAntCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4Y165( 2) ;
            RcdFound165 = 1;
            A354TSAntCod = T004Y3_A354TSAntCod[0];
            AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
            A1962TSAntFec = T004Y3_A1962TSAntFec[0];
            AssignAttri("", false, "A1962TSAntFec", context.localUtil.Format(A1962TSAntFec, "99/99/99"));
            A1960TSAntDoc = T004Y3_A1960TSAntDoc[0];
            AssignAttri("", false, "A1960TSAntDoc", A1960TSAntDoc);
            A1964TSAntImporte = T004Y3_A1964TSAntImporte[0];
            AssignAttri("", false, "A1964TSAntImporte", StringUtil.LTrimStr( A1964TSAntImporte, 15, 2));
            A1959TSAntConcepto = T004Y3_A1959TSAntConcepto[0];
            AssignAttri("", false, "A1959TSAntConcepto", A1959TSAntConcepto);
            A1957TSAntBanReg = T004Y3_A1957TSAntBanReg[0];
            AssignAttri("", false, "A1957TSAntBanReg", A1957TSAntBanReg);
            A1966TSAntTipCmb = T004Y3_A1966TSAntTipCmb[0];
            AssignAttri("", false, "A1966TSAntTipCmb", StringUtil.LTrimStr( A1966TSAntTipCmb, 15, 5));
            A1958TSAntBeneficiario = T004Y3_A1958TSAntBeneficiario[0];
            AssignAttri("", false, "A1958TSAntBeneficiario", A1958TSAntBeneficiario);
            A1965TSAntMonCod = T004Y3_A1965TSAntMonCod[0];
            AssignAttri("", false, "A1965TSAntMonCod", StringUtil.LTrimStr( (decimal)(A1965TSAntMonCod), 6, 0));
            A1961TSAntDocRef = T004Y3_A1961TSAntDocRef[0];
            AssignAttri("", false, "A1961TSAntDocRef", A1961TSAntDocRef);
            A1963TSAntForCod = T004Y3_A1963TSAntForCod[0];
            AssignAttri("", false, "A1963TSAntForCod", StringUtil.LTrimStr( (decimal)(A1963TSAntForCod), 6, 0));
            A244PrvCod = T004Y3_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A355ConBCod = T004Y3_A355ConBCod[0];
            AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
            A356TSAntBanCod = T004Y3_A356TSAntBanCod[0];
            AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrimStr( (decimal)(A356TSAntBanCod), 6, 0));
            A357TSAntCBCod = T004Y3_A357TSAntCBCod[0];
            AssignAttri("", false, "A357TSAntCBCod", A357TSAntCBCod);
            Z354TSAntCod = A354TSAntCod;
            sMode165 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4Y165( ) ;
            if ( AnyError == 1 )
            {
               RcdFound165 = 0;
               InitializeNonKey4Y165( ) ;
            }
            Gx_mode = sMode165;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound165 = 0;
            InitializeNonKey4Y165( ) ;
            sMode165 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode165;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4Y165( ) ;
         if ( RcdFound165 == 0 )
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
         RcdFound165 = 0;
         /* Using cursor T004Y16 */
         pr_default.execute(14, new Object[] {A354TSAntCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T004Y16_A354TSAntCod[0], A354TSAntCod) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T004Y16_A354TSAntCod[0], A354TSAntCod) > 0 ) ) )
            {
               A354TSAntCod = T004Y16_A354TSAntCod[0];
               AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
               RcdFound165 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound165 = 0;
         /* Using cursor T004Y17 */
         pr_default.execute(15, new Object[] {A354TSAntCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T004Y17_A354TSAntCod[0], A354TSAntCod) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T004Y17_A354TSAntCod[0], A354TSAntCod) < 0 ) ) )
            {
               A354TSAntCod = T004Y17_A354TSAntCod[0];
               AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
               RcdFound165 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4Y165( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTSAntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4Y165( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound165 == 1 )
            {
               if ( StringUtil.StrCmp(A354TSAntCod, Z354TSAntCod) != 0 )
               {
                  A354TSAntCod = Z354TSAntCod;
                  AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TSANTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTSAntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTSAntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4Y165( ) ;
                  GX_FocusControl = edtTSAntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A354TSAntCod, Z354TSAntCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTSAntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4Y165( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TSANTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTSAntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTSAntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4Y165( ) ;
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
         if ( StringUtil.StrCmp(A354TSAntCod, Z354TSAntCod) != 0 )
         {
            A354TSAntCod = Z354TSAntCod;
            AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TSANTCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTSAntCod_Internalname;
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
         GetKey4Y165( ) ;
         if ( RcdFound165 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TSANTCOD");
               AnyError = 1;
               GX_FocusControl = edtTSAntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A354TSAntCod, Z354TSAntCod) != 0 )
            {
               A354TSAntCod = Z354TSAntCod;
               AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TSANTCOD");
               AnyError = 1;
               GX_FocusControl = edtTSAntCod_Internalname;
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
            if ( StringUtil.StrCmp(A354TSAntCod, Z354TSAntCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TSANTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTSAntCod_Internalname;
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
         context.RollbackDataStores("tsanticipos",pr_default);
         GX_FocusControl = edtTSAntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_4Y0( ) ;
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
         if ( RcdFound165 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TSANTCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTSAntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4Y165( ) ;
         if ( RcdFound165 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSAntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4Y165( ) ;
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
         if ( RcdFound165 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSAntFec_Internalname;
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
         if ( RcdFound165 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSAntFec_Internalname;
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
         ScanStart4Y165( ) ;
         if ( RcdFound165 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound165 != 0 )
            {
               ScanNext4Y165( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSAntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4Y165( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4Y165( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004Y2 */
            pr_default.execute(0, new Object[] {A354TSAntCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSANTICIPOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1962TSAntFec ) != DateTimeUtil.ResetTime ( T004Y2_A1962TSAntFec[0] ) ) || ( StringUtil.StrCmp(Z1960TSAntDoc, T004Y2_A1960TSAntDoc[0]) != 0 ) || ( Z1964TSAntImporte != T004Y2_A1964TSAntImporte[0] ) || ( StringUtil.StrCmp(Z1959TSAntConcepto, T004Y2_A1959TSAntConcepto[0]) != 0 ) || ( StringUtil.StrCmp(Z1957TSAntBanReg, T004Y2_A1957TSAntBanReg[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1966TSAntTipCmb != T004Y2_A1966TSAntTipCmb[0] ) || ( StringUtil.StrCmp(Z1958TSAntBeneficiario, T004Y2_A1958TSAntBeneficiario[0]) != 0 ) || ( Z1965TSAntMonCod != T004Y2_A1965TSAntMonCod[0] ) || ( StringUtil.StrCmp(Z1961TSAntDocRef, T004Y2_A1961TSAntDocRef[0]) != 0 ) || ( Z1963TSAntForCod != T004Y2_A1963TSAntForCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z244PrvCod, T004Y2_A244PrvCod[0]) != 0 ) || ( Z355ConBCod != T004Y2_A355ConBCod[0] ) || ( Z356TSAntBanCod != T004Y2_A356TSAntBanCod[0] ) || ( StringUtil.StrCmp(Z357TSAntCBCod, T004Y2_A357TSAntCBCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1962TSAntFec ) != DateTimeUtil.ResetTime ( T004Y2_A1962TSAntFec[0] ) )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntFec");
                  GXUtil.WriteLogRaw("Old: ",Z1962TSAntFec);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1962TSAntFec[0]);
               }
               if ( StringUtil.StrCmp(Z1960TSAntDoc, T004Y2_A1960TSAntDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1960TSAntDoc);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1960TSAntDoc[0]);
               }
               if ( Z1964TSAntImporte != T004Y2_A1964TSAntImporte[0] )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntImporte");
                  GXUtil.WriteLogRaw("Old: ",Z1964TSAntImporte);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1964TSAntImporte[0]);
               }
               if ( StringUtil.StrCmp(Z1959TSAntConcepto, T004Y2_A1959TSAntConcepto[0]) != 0 )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1959TSAntConcepto);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1959TSAntConcepto[0]);
               }
               if ( StringUtil.StrCmp(Z1957TSAntBanReg, T004Y2_A1957TSAntBanReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntBanReg");
                  GXUtil.WriteLogRaw("Old: ",Z1957TSAntBanReg);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1957TSAntBanReg[0]);
               }
               if ( Z1966TSAntTipCmb != T004Y2_A1966TSAntTipCmb[0] )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1966TSAntTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1966TSAntTipCmb[0]);
               }
               if ( StringUtil.StrCmp(Z1958TSAntBeneficiario, T004Y2_A1958TSAntBeneficiario[0]) != 0 )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntBeneficiario");
                  GXUtil.WriteLogRaw("Old: ",Z1958TSAntBeneficiario);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1958TSAntBeneficiario[0]);
               }
               if ( Z1965TSAntMonCod != T004Y2_A1965TSAntMonCod[0] )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z1965TSAntMonCod);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1965TSAntMonCod[0]);
               }
               if ( StringUtil.StrCmp(Z1961TSAntDocRef, T004Y2_A1961TSAntDocRef[0]) != 0 )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntDocRef");
                  GXUtil.WriteLogRaw("Old: ",Z1961TSAntDocRef);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1961TSAntDocRef[0]);
               }
               if ( Z1963TSAntForCod != T004Y2_A1963TSAntForCod[0] )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntForCod");
                  GXUtil.WriteLogRaw("Old: ",Z1963TSAntForCod);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A1963TSAntForCod[0]);
               }
               if ( StringUtil.StrCmp(Z244PrvCod, T004Y2_A244PrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"PrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z244PrvCod);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A244PrvCod[0]);
               }
               if ( Z355ConBCod != T004Y2_A355ConBCod[0] )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"ConBCod");
                  GXUtil.WriteLogRaw("Old: ",Z355ConBCod);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A355ConBCod[0]);
               }
               if ( Z356TSAntBanCod != T004Y2_A356TSAntBanCod[0] )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z356TSAntBanCod);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A356TSAntBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z357TSAntCBCod, T004Y2_A357TSAntCBCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsanticipos:[seudo value changed for attri]"+"TSAntCBCod");
                  GXUtil.WriteLogRaw("Old: ",Z357TSAntCBCod);
                  GXUtil.WriteLogRaw("Current: ",T004Y2_A357TSAntCBCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSANTICIPOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4Y165( )
      {
         BeforeValidate4Y165( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4Y165( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4Y165( 0) ;
            CheckOptimisticConcurrency4Y165( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4Y165( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4Y165( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004Y18 */
                     pr_default.execute(16, new Object[] {A354TSAntCod, A1962TSAntFec, A1960TSAntDoc, A1964TSAntImporte, A1959TSAntConcepto, A1957TSAntBanReg, A1966TSAntTipCmb, A1958TSAntBeneficiario, A1965TSAntMonCod, A1961TSAntDocRef, A1963TSAntForCod, A244PrvCod, A355ConBCod, A356TSAntBanCod, A357TSAntCBCod});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("TSANTICIPOS");
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
                           ResetCaption4Y0( ) ;
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
               Load4Y165( ) ;
            }
            EndLevel4Y165( ) ;
         }
         CloseExtendedTableCursors4Y165( ) ;
      }

      protected void Update4Y165( )
      {
         BeforeValidate4Y165( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4Y165( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4Y165( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4Y165( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4Y165( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004Y19 */
                     pr_default.execute(17, new Object[] {A1962TSAntFec, A1960TSAntDoc, A1964TSAntImporte, A1959TSAntConcepto, A1957TSAntBanReg, A1966TSAntTipCmb, A1958TSAntBeneficiario, A1965TSAntMonCod, A1961TSAntDocRef, A1963TSAntForCod, A244PrvCod, A355ConBCod, A356TSAntBanCod, A357TSAntCBCod, A354TSAntCod});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("TSANTICIPOS");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSANTICIPOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4Y165( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4Y0( ) ;
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
            EndLevel4Y165( ) ;
         }
         CloseExtendedTableCursors4Y165( ) ;
      }

      protected void DeferredUpdate4Y165( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4Y165( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4Y165( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4Y165( ) ;
            AfterConfirm4Y165( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4Y165( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004Y20 */
                  pr_default.execute(18, new Object[] {A354TSAntCod});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("TSANTICIPOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound165 == 0 )
                        {
                           InitAll4Y165( ) ;
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
                        ResetCaption4Y0( ) ;
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
         sMode165 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4Y165( ) ;
         Gx_mode = sMode165;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4Y165( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004Y21 */
            pr_default.execute(19, new Object[] {A244PrvCod});
            A247PrvDsc = T004Y21_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            pr_default.close(19);
            /* Using cursor T004Y22 */
            pr_default.execute(20, new Object[] {A355ConBCod});
            A374ConBCueCod = T004Y22_A374ConBCueCod[0];
            pr_default.close(20);
            /* Using cursor T004Y23 */
            pr_default.execute(21, new Object[] {A374ConBCueCod});
            A744ConBCueDsc = T004Y23_A744ConBCueDsc[0];
            AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
            pr_default.close(21);
            /* Using cursor T004Y24 */
            pr_default.execute(22, new Object[] {A356TSAntBanCod});
            A1953TSAntBanDsc = T004Y24_A1953TSAntBanDsc[0];
            AssignAttri("", false, "A1953TSAntBanDsc", A1953TSAntBanDsc);
            pr_default.close(22);
         }
      }

      protected void EndLevel4Y165( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4Y165( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            pr_default.close(22);
            pr_default.close(21);
            context.CommitDataStores("tsanticipos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4Y0( ) ;
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
            pr_default.close(22);
            pr_default.close(21);
            context.RollbackDataStores("tsanticipos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4Y165( )
      {
         /* Using cursor T004Y25 */
         pr_default.execute(23);
         RcdFound165 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound165 = 1;
            A354TSAntCod = T004Y25_A354TSAntCod[0];
            AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4Y165( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound165 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound165 = 1;
            A354TSAntCod = T004Y25_A354TSAntCod[0];
            AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
         }
      }

      protected void ScanEnd4Y165( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm4Y165( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4Y165( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4Y165( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4Y165( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4Y165( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4Y165( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4Y165( )
      {
         edtTSAntCod_Enabled = 0;
         AssignProp("", false, edtTSAntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntCod_Enabled), 5, 0), true);
         edtTSAntFec_Enabled = 0;
         AssignProp("", false, edtTSAntFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntFec_Enabled), 5, 0), true);
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtPrvDsc_Enabled = 0;
         AssignProp("", false, edtPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDsc_Enabled), 5, 0), true);
         edtTSAntDoc_Enabled = 0;
         AssignProp("", false, edtTSAntDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntDoc_Enabled), 5, 0), true);
         edtConBCod_Enabled = 0;
         AssignProp("", false, edtConBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCod_Enabled), 5, 0), true);
         edtTSAntBanCod_Enabled = 0;
         AssignProp("", false, edtTSAntBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntBanCod_Enabled), 5, 0), true);
         edtTSAntCBCod_Enabled = 0;
         AssignProp("", false, edtTSAntCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntCBCod_Enabled), 5, 0), true);
         edtTSAntImporte_Enabled = 0;
         AssignProp("", false, edtTSAntImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntImporte_Enabled), 5, 0), true);
         edtTSAntConcepto_Enabled = 0;
         AssignProp("", false, edtTSAntConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntConcepto_Enabled), 5, 0), true);
         edtTSAntBanReg_Enabled = 0;
         AssignProp("", false, edtTSAntBanReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntBanReg_Enabled), 5, 0), true);
         edtTSAntTipCmb_Enabled = 0;
         AssignProp("", false, edtTSAntTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntTipCmb_Enabled), 5, 0), true);
         edtTSAntBeneficiario_Enabled = 0;
         AssignProp("", false, edtTSAntBeneficiario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntBeneficiario_Enabled), 5, 0), true);
         edtTSAntMonCod_Enabled = 0;
         AssignProp("", false, edtTSAntMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntMonCod_Enabled), 5, 0), true);
         edtTSAntDocRef_Enabled = 0;
         AssignProp("", false, edtTSAntDocRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntDocRef_Enabled), 5, 0), true);
         edtTSAntForCod_Enabled = 0;
         AssignProp("", false, edtTSAntForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntForCod_Enabled), 5, 0), true);
         edtConBCueDsc_Enabled = 0;
         AssignProp("", false, edtConBCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtConBCueDsc_Enabled), 5, 0), true);
         edtTSAntBanDsc_Enabled = 0;
         AssignProp("", false, edtTSAntBanDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntBanDsc_Enabled), 5, 0), true);
         edtTSAntBanMonAbr_Enabled = 0;
         AssignProp("", false, edtTSAntBanMonAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntBanMonAbr_Enabled), 5, 0), true);
         edtTSAntBanMonDsc_Enabled = 0;
         AssignProp("", false, edtTSAntBanMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSAntBanMonDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4Y165( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4Y0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025445", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsanticipos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z354TSAntCod", Z354TSAntCod);
         GxWebStd.gx_hidden_field( context, "Z1962TSAntFec", context.localUtil.DToC( Z1962TSAntFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1960TSAntDoc", Z1960TSAntDoc);
         GxWebStd.gx_hidden_field( context, "Z1964TSAntImporte", StringUtil.LTrim( StringUtil.NToC( Z1964TSAntImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1959TSAntConcepto", Z1959TSAntConcepto);
         GxWebStd.gx_hidden_field( context, "Z1957TSAntBanReg", Z1957TSAntBanReg);
         GxWebStd.gx_hidden_field( context, "Z1966TSAntTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1966TSAntTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1958TSAntBeneficiario", Z1958TSAntBeneficiario);
         GxWebStd.gx_hidden_field( context, "Z1965TSAntMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1965TSAntMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1961TSAntDocRef", Z1961TSAntDocRef);
         GxWebStd.gx_hidden_field( context, "Z1963TSAntForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1963TSAntForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z355ConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z355ConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z356TSAntBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z356TSAntBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z357TSAntCBCod", StringUtil.RTrim( Z357TSAntCBCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "CONBCUECOD", StringUtil.RTrim( A374ConBCueCod));
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
         return formatLink("tsanticipos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSANTICIPOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Anticipos Proveedores" ;
      }

      protected void InitializeNonKey4Y165( )
      {
         A374ConBCueCod = "";
         AssignAttri("", false, "A374ConBCueCod", A374ConBCueCod);
         A1962TSAntFec = DateTime.MinValue;
         AssignAttri("", false, "A1962TSAntFec", context.localUtil.Format(A1962TSAntFec, "99/99/99"));
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         A247PrvDsc = "";
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1960TSAntDoc = "";
         AssignAttri("", false, "A1960TSAntDoc", A1960TSAntDoc);
         A355ConBCod = 0;
         AssignAttri("", false, "A355ConBCod", StringUtil.LTrimStr( (decimal)(A355ConBCod), 6, 0));
         A356TSAntBanCod = 0;
         AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrimStr( (decimal)(A356TSAntBanCod), 6, 0));
         A357TSAntCBCod = "";
         AssignAttri("", false, "A357TSAntCBCod", A357TSAntCBCod);
         A1964TSAntImporte = 0;
         AssignAttri("", false, "A1964TSAntImporte", StringUtil.LTrimStr( A1964TSAntImporte, 15, 2));
         A1959TSAntConcepto = "";
         AssignAttri("", false, "A1959TSAntConcepto", A1959TSAntConcepto);
         A1957TSAntBanReg = "";
         AssignAttri("", false, "A1957TSAntBanReg", A1957TSAntBanReg);
         A1966TSAntTipCmb = 0;
         AssignAttri("", false, "A1966TSAntTipCmb", StringUtil.LTrimStr( A1966TSAntTipCmb, 15, 5));
         A1958TSAntBeneficiario = "";
         AssignAttri("", false, "A1958TSAntBeneficiario", A1958TSAntBeneficiario);
         A1965TSAntMonCod = 0;
         AssignAttri("", false, "A1965TSAntMonCod", StringUtil.LTrimStr( (decimal)(A1965TSAntMonCod), 6, 0));
         A1961TSAntDocRef = "";
         AssignAttri("", false, "A1961TSAntDocRef", A1961TSAntDocRef);
         A1963TSAntForCod = 0;
         AssignAttri("", false, "A1963TSAntForCod", StringUtil.LTrimStr( (decimal)(A1963TSAntForCod), 6, 0));
         A744ConBCueDsc = "";
         AssignAttri("", false, "A744ConBCueDsc", A744ConBCueDsc);
         A1953TSAntBanDsc = "";
         AssignAttri("", false, "A1953TSAntBanDsc", A1953TSAntBanDsc);
         A1954TSAntBanMonAbr = "";
         AssignAttri("", false, "A1954TSAntBanMonAbr", A1954TSAntBanMonAbr);
         A1956TSAntBanMonDsc = "";
         AssignAttri("", false, "A1956TSAntBanMonDsc", A1956TSAntBanMonDsc);
         Z1962TSAntFec = DateTime.MinValue;
         Z1960TSAntDoc = "";
         Z1964TSAntImporte = 0;
         Z1959TSAntConcepto = "";
         Z1957TSAntBanReg = "";
         Z1966TSAntTipCmb = 0;
         Z1958TSAntBeneficiario = "";
         Z1965TSAntMonCod = 0;
         Z1961TSAntDocRef = "";
         Z1963TSAntForCod = 0;
         Z244PrvCod = "";
         Z355ConBCod = 0;
         Z356TSAntBanCod = 0;
         Z357TSAntCBCod = "";
      }

      protected void InitAll4Y165( )
      {
         A354TSAntCod = "";
         AssignAttri("", false, "A354TSAntCod", A354TSAntCod);
         InitializeNonKey4Y165( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254419", true, true);
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
         context.AddJavascriptSource("tsanticipos.js", "?202281810254419", false, true);
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
         edtTSAntCod_Internalname = "TSANTCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTSAntFec_Internalname = "TSANTFEC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPrvCod_Internalname = "PRVCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPrvDsc_Internalname = "PRVDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtTSAntDoc_Internalname = "TSANTDOC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtConBCod_Internalname = "CONBCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtTSAntBanCod_Internalname = "TSANTBANCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtTSAntCBCod_Internalname = "TSANTCBCOD";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtTSAntImporte_Internalname = "TSANTIMPORTE";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtTSAntConcepto_Internalname = "TSANTCONCEPTO";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtTSAntBanReg_Internalname = "TSANTBANREG";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtTSAntTipCmb_Internalname = "TSANTTIPCMB";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtTSAntBeneficiario_Internalname = "TSANTBENEFICIARIO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtTSAntMonCod_Internalname = "TSANTMONCOD";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtTSAntDocRef_Internalname = "TSANTDOCREF";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtTSAntForCod_Internalname = "TSANTFORCOD";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtConBCueDsc_Internalname = "CONBCUEDSC";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtTSAntBanDsc_Internalname = "TSANTBANDSC";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtTSAntBanMonAbr_Internalname = "TSANTBANMONABR";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtTSAntBanMonDsc_Internalname = "TSANTBANMONDSC";
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
         Form.Caption = "Anticipos Proveedores";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTSAntBanMonDsc_Jsonclick = "";
         edtTSAntBanMonDsc_Enabled = 0;
         edtTSAntBanMonAbr_Jsonclick = "";
         edtTSAntBanMonAbr_Enabled = 0;
         edtTSAntBanDsc_Jsonclick = "";
         edtTSAntBanDsc_Enabled = 0;
         edtConBCueDsc_Jsonclick = "";
         edtConBCueDsc_Enabled = 0;
         edtTSAntForCod_Jsonclick = "";
         edtTSAntForCod_Enabled = 1;
         edtTSAntDocRef_Jsonclick = "";
         edtTSAntDocRef_Enabled = 1;
         edtTSAntMonCod_Jsonclick = "";
         edtTSAntMonCod_Enabled = 1;
         edtTSAntBeneficiario_Jsonclick = "";
         edtTSAntBeneficiario_Enabled = 1;
         edtTSAntTipCmb_Jsonclick = "";
         edtTSAntTipCmb_Enabled = 1;
         edtTSAntBanReg_Jsonclick = "";
         edtTSAntBanReg_Enabled = 1;
         edtTSAntConcepto_Jsonclick = "";
         edtTSAntConcepto_Enabled = 1;
         edtTSAntImporte_Jsonclick = "";
         edtTSAntImporte_Enabled = 1;
         edtTSAntCBCod_Jsonclick = "";
         edtTSAntCBCod_Enabled = 1;
         edtTSAntBanCod_Jsonclick = "";
         edtTSAntBanCod_Enabled = 1;
         edtConBCod_Jsonclick = "";
         edtConBCod_Enabled = 1;
         edtTSAntDoc_Jsonclick = "";
         edtTSAntDoc_Enabled = 1;
         edtPrvDsc_Jsonclick = "";
         edtPrvDsc_Enabled = 0;
         edtPrvCod_Jsonclick = "";
         edtPrvCod_Enabled = 1;
         edtTSAntFec_Jsonclick = "";
         edtTSAntFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTSAntCod_Jsonclick = "";
         edtTSAntCod_Enabled = 1;
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
         GX_FocusControl = edtTSAntFec_Internalname;
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

      public void Valid_Tsantcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1962TSAntFec", context.localUtil.Format(A1962TSAntFec, "99/99/99"));
         AssignAttri("", false, "A244PrvCod", StringUtil.RTrim( A244PrvCod));
         AssignAttri("", false, "A1960TSAntDoc", A1960TSAntDoc);
         AssignAttri("", false, "A355ConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A355ConBCod), 6, 0, ".", "")));
         AssignAttri("", false, "A356TSAntBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A356TSAntBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A357TSAntCBCod", StringUtil.RTrim( A357TSAntCBCod));
         AssignAttri("", false, "A1964TSAntImporte", StringUtil.LTrim( StringUtil.NToC( A1964TSAntImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A1959TSAntConcepto", A1959TSAntConcepto);
         AssignAttri("", false, "A1957TSAntBanReg", A1957TSAntBanReg);
         AssignAttri("", false, "A1966TSAntTipCmb", StringUtil.LTrim( StringUtil.NToC( A1966TSAntTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A1958TSAntBeneficiario", A1958TSAntBeneficiario);
         AssignAttri("", false, "A1965TSAntMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1965TSAntMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1961TSAntDocRef", A1961TSAntDocRef);
         AssignAttri("", false, "A1963TSAntForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1963TSAntForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1954TSAntBanMonAbr", StringUtil.RTrim( A1954TSAntBanMonAbr));
         AssignAttri("", false, "A1956TSAntBanMonDsc", StringUtil.RTrim( A1956TSAntBanMonDsc));
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A374ConBCueCod", StringUtil.RTrim( A374ConBCueCod));
         AssignAttri("", false, "A744ConBCueDsc", StringUtil.RTrim( A744ConBCueDsc));
         AssignAttri("", false, "A1953TSAntBanDsc", StringUtil.RTrim( A1953TSAntBanDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z354TSAntCod", Z354TSAntCod);
         GxWebStd.gx_hidden_field( context, "Z1962TSAntFec", context.localUtil.Format(Z1962TSAntFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z1960TSAntDoc", Z1960TSAntDoc);
         GxWebStd.gx_hidden_field( context, "Z355ConBCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z355ConBCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z356TSAntBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z356TSAntBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z357TSAntCBCod", StringUtil.RTrim( Z357TSAntCBCod));
         GxWebStd.gx_hidden_field( context, "Z1964TSAntImporte", StringUtil.LTrim( StringUtil.NToC( Z1964TSAntImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1959TSAntConcepto", Z1959TSAntConcepto);
         GxWebStd.gx_hidden_field( context, "Z1957TSAntBanReg", Z1957TSAntBanReg);
         GxWebStd.gx_hidden_field( context, "Z1966TSAntTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1966TSAntTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1958TSAntBeneficiario", Z1958TSAntBeneficiario);
         GxWebStd.gx_hidden_field( context, "Z1965TSAntMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1965TSAntMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1961TSAntDocRef", Z1961TSAntDocRef);
         GxWebStd.gx_hidden_field( context, "Z1963TSAntForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1963TSAntForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1954TSAntBanMonAbr", StringUtil.RTrim( Z1954TSAntBanMonAbr));
         GxWebStd.gx_hidden_field( context, "Z1956TSAntBanMonDsc", StringUtil.RTrim( Z1956TSAntBanMonDsc));
         GxWebStd.gx_hidden_field( context, "Z247PrvDsc", StringUtil.RTrim( Z247PrvDsc));
         GxWebStd.gx_hidden_field( context, "Z374ConBCueCod", StringUtil.RTrim( Z374ConBCueCod));
         GxWebStd.gx_hidden_field( context, "Z744ConBCueDsc", StringUtil.RTrim( Z744ConBCueDsc));
         GxWebStd.gx_hidden_field( context, "Z1953TSAntBanDsc", StringUtil.RTrim( Z1953TSAntBanDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prvcod( )
      {
         /* Using cursor T004Y21 */
         pr_default.execute(19, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
         }
         A247PrvDsc = T004Y21_A247PrvDsc[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
      }

      public void Valid_Conbcod( )
      {
         /* Using cursor T004Y22 */
         pr_default.execute(20, new Object[] {A355ConBCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Bancos'.", "ForeignKeyNotFound", 1, "CONBCOD");
            AnyError = 1;
            GX_FocusControl = edtConBCod_Internalname;
         }
         A374ConBCueCod = T004Y22_A374ConBCueCod[0];
         pr_default.close(20);
         /* Using cursor T004Y23 */
         pr_default.execute(21, new Object[] {A374ConBCueCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "CONBCUECOD");
            AnyError = 1;
         }
         A744ConBCueDsc = T004Y23_A744ConBCueDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A374ConBCueCod", StringUtil.RTrim( A374ConBCueCod));
         AssignAttri("", false, "A744ConBCueDsc", StringUtil.RTrim( A744ConBCueDsc));
      }

      public void Valid_Tsantbancod( )
      {
         /* Using cursor T004Y24 */
         pr_default.execute(22, new Object[] {A356TSAntBanCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "TSANTBANCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntBanCod_Internalname;
         }
         A1953TSAntBanDsc = T004Y24_A1953TSAntBanDsc[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1953TSAntBanDsc", StringUtil.RTrim( A1953TSAntBanDsc));
      }

      public void Valid_Tsantcbcod( )
      {
         /* Using cursor T004Y26 */
         pr_default.execute(24, new Object[] {A356TSAntBanCod, A357TSAntCBCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "TSANTCBCOD");
            AnyError = 1;
            GX_FocusControl = edtTSAntBanCod_Internalname;
         }
         pr_default.close(24);
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
         setEventMetadata("VALID_TSANTCOD","{handler:'Valid_Tsantcod',iparms:[{av:'A354TSAntCod',fld:'TSANTCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TSANTCOD",",oparms:[{av:'A1962TSAntFec',fld:'TSANTFEC',pic:''},{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A1960TSAntDoc',fld:'TSANTDOC',pic:''},{av:'A355ConBCod',fld:'CONBCOD',pic:'ZZZZZ9'},{av:'A356TSAntBanCod',fld:'TSANTBANCOD',pic:'ZZZZZ9'},{av:'A357TSAntCBCod',fld:'TSANTCBCOD',pic:''},{av:'A1964TSAntImporte',fld:'TSANTIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1959TSAntConcepto',fld:'TSANTCONCEPTO',pic:''},{av:'A1957TSAntBanReg',fld:'TSANTBANREG',pic:''},{av:'A1966TSAntTipCmb',fld:'TSANTTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A1958TSAntBeneficiario',fld:'TSANTBENEFICIARIO',pic:''},{av:'A1965TSAntMonCod',fld:'TSANTMONCOD',pic:'ZZZZZ9'},{av:'A1961TSAntDocRef',fld:'TSANTDOCREF',pic:''},{av:'A1963TSAntForCod',fld:'TSANTFORCOD',pic:'ZZZZZ9'},{av:'A1954TSAntBanMonAbr',fld:'TSANTBANMONABR',pic:''},{av:'A1956TSAntBanMonDsc',fld:'TSANTBANMONDSC',pic:''},{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A374ConBCueCod',fld:'CONBCUECOD',pic:''},{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''},{av:'A1953TSAntBanDsc',fld:'TSANTBANDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z354TSAntCod'},{av:'Z1962TSAntFec'},{av:'Z244PrvCod'},{av:'Z1960TSAntDoc'},{av:'Z355ConBCod'},{av:'Z356TSAntBanCod'},{av:'Z357TSAntCBCod'},{av:'Z1964TSAntImporte'},{av:'Z1959TSAntConcepto'},{av:'Z1957TSAntBanReg'},{av:'Z1966TSAntTipCmb'},{av:'Z1958TSAntBeneficiario'},{av:'Z1965TSAntMonCod'},{av:'Z1961TSAntDocRef'},{av:'Z1963TSAntForCod'},{av:'Z1954TSAntBanMonAbr'},{av:'Z1956TSAntBanMonDsc'},{av:'Z247PrvDsc'},{av:'Z374ConBCueCod'},{av:'Z744ConBCueDsc'},{av:'Z1953TSAntBanDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_TSANTFEC","{handler:'Valid_Tsantfec',iparms:[]");
         setEventMetadata("VALID_TSANTFEC",",oparms:[]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A247PrvDsc',fld:'PRVDSC',pic:''}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[{av:'A247PrvDsc',fld:'PRVDSC',pic:''}]}");
         setEventMetadata("VALID_CONBCOD","{handler:'Valid_Conbcod',iparms:[{av:'A355ConBCod',fld:'CONBCOD',pic:'ZZZZZ9'},{av:'A374ConBCueCod',fld:'CONBCUECOD',pic:''},{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''}]");
         setEventMetadata("VALID_CONBCOD",",oparms:[{av:'A374ConBCueCod',fld:'CONBCUECOD',pic:''},{av:'A744ConBCueDsc',fld:'CONBCUEDSC',pic:''}]}");
         setEventMetadata("VALID_TSANTBANCOD","{handler:'Valid_Tsantbancod',iparms:[{av:'A356TSAntBanCod',fld:'TSANTBANCOD',pic:'ZZZZZ9'},{av:'A1953TSAntBanDsc',fld:'TSANTBANDSC',pic:''}]");
         setEventMetadata("VALID_TSANTBANCOD",",oparms:[{av:'A1953TSAntBanDsc',fld:'TSANTBANDSC',pic:''}]}");
         setEventMetadata("VALID_TSANTCBCOD","{handler:'Valid_Tsantcbcod',iparms:[{av:'A356TSAntBanCod',fld:'TSANTBANCOD',pic:'ZZZZZ9'},{av:'A357TSAntCBCod',fld:'TSANTCBCOD',pic:''}]");
         setEventMetadata("VALID_TSANTCBCOD",",oparms:[]}");
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
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(22);
         pr_default.close(24);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z354TSAntCod = "";
         Z1962TSAntFec = DateTime.MinValue;
         Z1960TSAntDoc = "";
         Z1959TSAntConcepto = "";
         Z1957TSAntBanReg = "";
         Z1958TSAntBeneficiario = "";
         Z1961TSAntDocRef = "";
         Z244PrvCod = "";
         Z357TSAntCBCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A244PrvCod = "";
         A374ConBCueCod = "";
         A357TSAntCBCod = "";
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
         A354TSAntCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1962TSAntFec = DateTime.MinValue;
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A247PrvDsc = "";
         lblTextblock5_Jsonclick = "";
         A1960TSAntDoc = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1959TSAntConcepto = "";
         lblTextblock11_Jsonclick = "";
         A1957TSAntBanReg = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A1958TSAntBeneficiario = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1961TSAntDocRef = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         A744ConBCueDsc = "";
         lblTextblock18_Jsonclick = "";
         A1953TSAntBanDsc = "";
         lblTextblock19_Jsonclick = "";
         A1954TSAntBanMonAbr = "";
         lblTextblock20_Jsonclick = "";
         A1956TSAntBanMonDsc = "";
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
         Z247PrvDsc = "";
         Z374ConBCueCod = "";
         Z744ConBCueDsc = "";
         Z1953TSAntBanDsc = "";
         T004Y9_A374ConBCueCod = new string[] {""} ;
         T004Y9_A354TSAntCod = new string[] {""} ;
         T004Y9_A1962TSAntFec = new DateTime[] {DateTime.MinValue} ;
         T004Y9_A247PrvDsc = new string[] {""} ;
         T004Y9_A1960TSAntDoc = new string[] {""} ;
         T004Y9_A1964TSAntImporte = new decimal[1] ;
         T004Y9_A1959TSAntConcepto = new string[] {""} ;
         T004Y9_A1957TSAntBanReg = new string[] {""} ;
         T004Y9_A1966TSAntTipCmb = new decimal[1] ;
         T004Y9_A1958TSAntBeneficiario = new string[] {""} ;
         T004Y9_A1965TSAntMonCod = new int[1] ;
         T004Y9_A1961TSAntDocRef = new string[] {""} ;
         T004Y9_A1963TSAntForCod = new int[1] ;
         T004Y9_A744ConBCueDsc = new string[] {""} ;
         T004Y9_A1953TSAntBanDsc = new string[] {""} ;
         T004Y9_A244PrvCod = new string[] {""} ;
         T004Y9_A355ConBCod = new int[1] ;
         T004Y9_A356TSAntBanCod = new int[1] ;
         T004Y9_A357TSAntCBCod = new string[] {""} ;
         T004Y4_A247PrvDsc = new string[] {""} ;
         T004Y5_A374ConBCueCod = new string[] {""} ;
         T004Y8_A744ConBCueDsc = new string[] {""} ;
         T004Y6_A1953TSAntBanDsc = new string[] {""} ;
         T004Y7_A356TSAntBanCod = new int[1] ;
         T004Y10_A247PrvDsc = new string[] {""} ;
         T004Y11_A374ConBCueCod = new string[] {""} ;
         T004Y12_A744ConBCueDsc = new string[] {""} ;
         T004Y13_A1953TSAntBanDsc = new string[] {""} ;
         T004Y14_A356TSAntBanCod = new int[1] ;
         T004Y15_A354TSAntCod = new string[] {""} ;
         T004Y3_A354TSAntCod = new string[] {""} ;
         T004Y3_A1962TSAntFec = new DateTime[] {DateTime.MinValue} ;
         T004Y3_A1960TSAntDoc = new string[] {""} ;
         T004Y3_A1964TSAntImporte = new decimal[1] ;
         T004Y3_A1959TSAntConcepto = new string[] {""} ;
         T004Y3_A1957TSAntBanReg = new string[] {""} ;
         T004Y3_A1966TSAntTipCmb = new decimal[1] ;
         T004Y3_A1958TSAntBeneficiario = new string[] {""} ;
         T004Y3_A1965TSAntMonCod = new int[1] ;
         T004Y3_A1961TSAntDocRef = new string[] {""} ;
         T004Y3_A1963TSAntForCod = new int[1] ;
         T004Y3_A244PrvCod = new string[] {""} ;
         T004Y3_A355ConBCod = new int[1] ;
         T004Y3_A356TSAntBanCod = new int[1] ;
         T004Y3_A357TSAntCBCod = new string[] {""} ;
         sMode165 = "";
         T004Y16_A354TSAntCod = new string[] {""} ;
         T004Y17_A354TSAntCod = new string[] {""} ;
         T004Y2_A354TSAntCod = new string[] {""} ;
         T004Y2_A1962TSAntFec = new DateTime[] {DateTime.MinValue} ;
         T004Y2_A1960TSAntDoc = new string[] {""} ;
         T004Y2_A1964TSAntImporte = new decimal[1] ;
         T004Y2_A1959TSAntConcepto = new string[] {""} ;
         T004Y2_A1957TSAntBanReg = new string[] {""} ;
         T004Y2_A1966TSAntTipCmb = new decimal[1] ;
         T004Y2_A1958TSAntBeneficiario = new string[] {""} ;
         T004Y2_A1965TSAntMonCod = new int[1] ;
         T004Y2_A1961TSAntDocRef = new string[] {""} ;
         T004Y2_A1963TSAntForCod = new int[1] ;
         T004Y2_A244PrvCod = new string[] {""} ;
         T004Y2_A355ConBCod = new int[1] ;
         T004Y2_A356TSAntBanCod = new int[1] ;
         T004Y2_A357TSAntCBCod = new string[] {""} ;
         T004Y21_A247PrvDsc = new string[] {""} ;
         T004Y22_A374ConBCueCod = new string[] {""} ;
         T004Y23_A744ConBCueDsc = new string[] {""} ;
         T004Y24_A1953TSAntBanDsc = new string[] {""} ;
         T004Y25_A354TSAntCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         Z1954TSAntBanMonAbr = "";
         Z1956TSAntBanMonDsc = "";
         ZZ354TSAntCod = "";
         ZZ1962TSAntFec = DateTime.MinValue;
         ZZ244PrvCod = "";
         ZZ1960TSAntDoc = "";
         ZZ357TSAntCBCod = "";
         ZZ1959TSAntConcepto = "";
         ZZ1957TSAntBanReg = "";
         ZZ1958TSAntBeneficiario = "";
         ZZ1961TSAntDocRef = "";
         ZZ1954TSAntBanMonAbr = "";
         ZZ1956TSAntBanMonDsc = "";
         ZZ247PrvDsc = "";
         ZZ374ConBCueCod = "";
         ZZ744ConBCueDsc = "";
         ZZ1953TSAntBanDsc = "";
         T004Y26_A356TSAntBanCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsanticipos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsanticipos__default(),
            new Object[][] {
                new Object[] {
               T004Y2_A354TSAntCod, T004Y2_A1962TSAntFec, T004Y2_A1960TSAntDoc, T004Y2_A1964TSAntImporte, T004Y2_A1959TSAntConcepto, T004Y2_A1957TSAntBanReg, T004Y2_A1966TSAntTipCmb, T004Y2_A1958TSAntBeneficiario, T004Y2_A1965TSAntMonCod, T004Y2_A1961TSAntDocRef,
               T004Y2_A1963TSAntForCod, T004Y2_A244PrvCod, T004Y2_A355ConBCod, T004Y2_A356TSAntBanCod, T004Y2_A357TSAntCBCod
               }
               , new Object[] {
               T004Y3_A354TSAntCod, T004Y3_A1962TSAntFec, T004Y3_A1960TSAntDoc, T004Y3_A1964TSAntImporte, T004Y3_A1959TSAntConcepto, T004Y3_A1957TSAntBanReg, T004Y3_A1966TSAntTipCmb, T004Y3_A1958TSAntBeneficiario, T004Y3_A1965TSAntMonCod, T004Y3_A1961TSAntDocRef,
               T004Y3_A1963TSAntForCod, T004Y3_A244PrvCod, T004Y3_A355ConBCod, T004Y3_A356TSAntBanCod, T004Y3_A357TSAntCBCod
               }
               , new Object[] {
               T004Y4_A247PrvDsc
               }
               , new Object[] {
               T004Y5_A374ConBCueCod
               }
               , new Object[] {
               T004Y6_A1953TSAntBanDsc
               }
               , new Object[] {
               T004Y7_A356TSAntBanCod
               }
               , new Object[] {
               T004Y8_A744ConBCueDsc
               }
               , new Object[] {
               T004Y9_A374ConBCueCod, T004Y9_A354TSAntCod, T004Y9_A1962TSAntFec, T004Y9_A247PrvDsc, T004Y9_A1960TSAntDoc, T004Y9_A1964TSAntImporte, T004Y9_A1959TSAntConcepto, T004Y9_A1957TSAntBanReg, T004Y9_A1966TSAntTipCmb, T004Y9_A1958TSAntBeneficiario,
               T004Y9_A1965TSAntMonCod, T004Y9_A1961TSAntDocRef, T004Y9_A1963TSAntForCod, T004Y9_A744ConBCueDsc, T004Y9_A1953TSAntBanDsc, T004Y9_A244PrvCod, T004Y9_A355ConBCod, T004Y9_A356TSAntBanCod, T004Y9_A357TSAntCBCod
               }
               , new Object[] {
               T004Y10_A247PrvDsc
               }
               , new Object[] {
               T004Y11_A374ConBCueCod
               }
               , new Object[] {
               T004Y12_A744ConBCueDsc
               }
               , new Object[] {
               T004Y13_A1953TSAntBanDsc
               }
               , new Object[] {
               T004Y14_A356TSAntBanCod
               }
               , new Object[] {
               T004Y15_A354TSAntCod
               }
               , new Object[] {
               T004Y16_A354TSAntCod
               }
               , new Object[] {
               T004Y17_A354TSAntCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004Y21_A247PrvDsc
               }
               , new Object[] {
               T004Y22_A374ConBCueCod
               }
               , new Object[] {
               T004Y23_A744ConBCueDsc
               }
               , new Object[] {
               T004Y24_A1953TSAntBanDsc
               }
               , new Object[] {
               T004Y25_A354TSAntCod
               }
               , new Object[] {
               T004Y26_A356TSAntBanCod
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
      private short RcdFound165 ;
      private short nIsDirty_165 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1965TSAntMonCod ;
      private int Z1963TSAntForCod ;
      private int Z355ConBCod ;
      private int Z356TSAntBanCod ;
      private int A355ConBCod ;
      private int A356TSAntBanCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTSAntCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTSAntFec_Enabled ;
      private int edtPrvCod_Enabled ;
      private int edtPrvDsc_Enabled ;
      private int edtTSAntDoc_Enabled ;
      private int edtConBCod_Enabled ;
      private int edtTSAntBanCod_Enabled ;
      private int edtTSAntCBCod_Enabled ;
      private int edtTSAntImporte_Enabled ;
      private int edtTSAntConcepto_Enabled ;
      private int edtTSAntBanReg_Enabled ;
      private int edtTSAntTipCmb_Enabled ;
      private int edtTSAntBeneficiario_Enabled ;
      private int A1965TSAntMonCod ;
      private int edtTSAntMonCod_Enabled ;
      private int edtTSAntDocRef_Enabled ;
      private int A1963TSAntForCod ;
      private int edtTSAntForCod_Enabled ;
      private int edtConBCueDsc_Enabled ;
      private int edtTSAntBanDsc_Enabled ;
      private int edtTSAntBanMonAbr_Enabled ;
      private int edtTSAntBanMonDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ355ConBCod ;
      private int ZZ356TSAntBanCod ;
      private int ZZ1965TSAntMonCod ;
      private int ZZ1963TSAntForCod ;
      private decimal Z1964TSAntImporte ;
      private decimal Z1966TSAntTipCmb ;
      private decimal A1964TSAntImporte ;
      private decimal A1966TSAntTipCmb ;
      private decimal ZZ1964TSAntImporte ;
      private decimal ZZ1966TSAntTipCmb ;
      private string sPrefix ;
      private string Z244PrvCod ;
      private string Z357TSAntCBCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A244PrvCod ;
      private string A374ConBCueCod ;
      private string A357TSAntCBCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTSAntCod_Internalname ;
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
      private string edtTSAntCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTSAntFec_Internalname ;
      private string edtTSAntFec_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPrvCod_Internalname ;
      private string edtPrvCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPrvDsc_Internalname ;
      private string A247PrvDsc ;
      private string edtPrvDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtTSAntDoc_Internalname ;
      private string edtTSAntDoc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtConBCod_Internalname ;
      private string edtConBCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtTSAntBanCod_Internalname ;
      private string edtTSAntBanCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtTSAntCBCod_Internalname ;
      private string edtTSAntCBCod_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtTSAntImporte_Internalname ;
      private string edtTSAntImporte_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtTSAntConcepto_Internalname ;
      private string edtTSAntConcepto_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtTSAntBanReg_Internalname ;
      private string edtTSAntBanReg_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtTSAntTipCmb_Internalname ;
      private string edtTSAntTipCmb_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtTSAntBeneficiario_Internalname ;
      private string edtTSAntBeneficiario_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtTSAntMonCod_Internalname ;
      private string edtTSAntMonCod_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtTSAntDocRef_Internalname ;
      private string edtTSAntDocRef_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtTSAntForCod_Internalname ;
      private string edtTSAntForCod_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtConBCueDsc_Internalname ;
      private string A744ConBCueDsc ;
      private string edtConBCueDsc_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtTSAntBanDsc_Internalname ;
      private string A1953TSAntBanDsc ;
      private string edtTSAntBanDsc_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtTSAntBanMonAbr_Internalname ;
      private string A1954TSAntBanMonAbr ;
      private string edtTSAntBanMonAbr_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtTSAntBanMonDsc_Internalname ;
      private string A1956TSAntBanMonDsc ;
      private string edtTSAntBanMonDsc_Jsonclick ;
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
      private string Z247PrvDsc ;
      private string Z374ConBCueCod ;
      private string Z744ConBCueDsc ;
      private string Z1953TSAntBanDsc ;
      private string sMode165 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string Z1954TSAntBanMonAbr ;
      private string Z1956TSAntBanMonDsc ;
      private string ZZ244PrvCod ;
      private string ZZ357TSAntCBCod ;
      private string ZZ1954TSAntBanMonAbr ;
      private string ZZ1956TSAntBanMonDsc ;
      private string ZZ247PrvDsc ;
      private string ZZ374ConBCueCod ;
      private string ZZ744ConBCueDsc ;
      private string ZZ1953TSAntBanDsc ;
      private DateTime Z1962TSAntFec ;
      private DateTime A1962TSAntFec ;
      private DateTime ZZ1962TSAntFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z354TSAntCod ;
      private string Z1960TSAntDoc ;
      private string Z1959TSAntConcepto ;
      private string Z1957TSAntBanReg ;
      private string Z1958TSAntBeneficiario ;
      private string Z1961TSAntDocRef ;
      private string A354TSAntCod ;
      private string A1960TSAntDoc ;
      private string A1959TSAntConcepto ;
      private string A1957TSAntBanReg ;
      private string A1958TSAntBeneficiario ;
      private string A1961TSAntDocRef ;
      private string ZZ354TSAntCod ;
      private string ZZ1960TSAntDoc ;
      private string ZZ1959TSAntConcepto ;
      private string ZZ1957TSAntBanReg ;
      private string ZZ1958TSAntBeneficiario ;
      private string ZZ1961TSAntDocRef ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T004Y9_A374ConBCueCod ;
      private string[] T004Y9_A354TSAntCod ;
      private DateTime[] T004Y9_A1962TSAntFec ;
      private string[] T004Y9_A247PrvDsc ;
      private string[] T004Y9_A1960TSAntDoc ;
      private decimal[] T004Y9_A1964TSAntImporte ;
      private string[] T004Y9_A1959TSAntConcepto ;
      private string[] T004Y9_A1957TSAntBanReg ;
      private decimal[] T004Y9_A1966TSAntTipCmb ;
      private string[] T004Y9_A1958TSAntBeneficiario ;
      private int[] T004Y9_A1965TSAntMonCod ;
      private string[] T004Y9_A1961TSAntDocRef ;
      private int[] T004Y9_A1963TSAntForCod ;
      private string[] T004Y9_A744ConBCueDsc ;
      private string[] T004Y9_A1953TSAntBanDsc ;
      private string[] T004Y9_A244PrvCod ;
      private int[] T004Y9_A355ConBCod ;
      private int[] T004Y9_A356TSAntBanCod ;
      private string[] T004Y9_A357TSAntCBCod ;
      private string[] T004Y4_A247PrvDsc ;
      private string[] T004Y5_A374ConBCueCod ;
      private string[] T004Y8_A744ConBCueDsc ;
      private string[] T004Y6_A1953TSAntBanDsc ;
      private int[] T004Y7_A356TSAntBanCod ;
      private string[] T004Y10_A247PrvDsc ;
      private string[] T004Y11_A374ConBCueCod ;
      private string[] T004Y12_A744ConBCueDsc ;
      private string[] T004Y13_A1953TSAntBanDsc ;
      private int[] T004Y14_A356TSAntBanCod ;
      private string[] T004Y15_A354TSAntCod ;
      private string[] T004Y3_A354TSAntCod ;
      private DateTime[] T004Y3_A1962TSAntFec ;
      private string[] T004Y3_A1960TSAntDoc ;
      private decimal[] T004Y3_A1964TSAntImporte ;
      private string[] T004Y3_A1959TSAntConcepto ;
      private string[] T004Y3_A1957TSAntBanReg ;
      private decimal[] T004Y3_A1966TSAntTipCmb ;
      private string[] T004Y3_A1958TSAntBeneficiario ;
      private int[] T004Y3_A1965TSAntMonCod ;
      private string[] T004Y3_A1961TSAntDocRef ;
      private int[] T004Y3_A1963TSAntForCod ;
      private string[] T004Y3_A244PrvCod ;
      private int[] T004Y3_A355ConBCod ;
      private int[] T004Y3_A356TSAntBanCod ;
      private string[] T004Y3_A357TSAntCBCod ;
      private string[] T004Y16_A354TSAntCod ;
      private string[] T004Y17_A354TSAntCod ;
      private string[] T004Y2_A354TSAntCod ;
      private DateTime[] T004Y2_A1962TSAntFec ;
      private string[] T004Y2_A1960TSAntDoc ;
      private decimal[] T004Y2_A1964TSAntImporte ;
      private string[] T004Y2_A1959TSAntConcepto ;
      private string[] T004Y2_A1957TSAntBanReg ;
      private decimal[] T004Y2_A1966TSAntTipCmb ;
      private string[] T004Y2_A1958TSAntBeneficiario ;
      private int[] T004Y2_A1965TSAntMonCod ;
      private string[] T004Y2_A1961TSAntDocRef ;
      private int[] T004Y2_A1963TSAntForCod ;
      private string[] T004Y2_A244PrvCod ;
      private int[] T004Y2_A355ConBCod ;
      private int[] T004Y2_A356TSAntBanCod ;
      private string[] T004Y2_A357TSAntCBCod ;
      private string[] T004Y21_A247PrvDsc ;
      private string[] T004Y22_A374ConBCueCod ;
      private string[] T004Y23_A744ConBCueDsc ;
      private string[] T004Y24_A1953TSAntBanDsc ;
      private string[] T004Y25_A354TSAntCod ;
      private int[] T004Y26_A356TSAntBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsanticipos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsanticipos__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT004Y9;
        prmT004Y9 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y4;
        prmT004Y4 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT004Y5;
        prmT004Y5 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT004Y8;
        prmT004Y8 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004Y6;
        prmT004Y6 = new Object[] {
        new ParDef("@TSAntBanCod",GXType.Int32,6,0)
        };
        Object[] prmT004Y7;
        prmT004Y7 = new Object[] {
        new ParDef("@TSAntBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntCBCod",GXType.NChar,20,0)
        };
        Object[] prmT004Y10;
        prmT004Y10 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT004Y11;
        prmT004Y11 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT004Y12;
        prmT004Y12 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004Y13;
        prmT004Y13 = new Object[] {
        new ParDef("@TSAntBanCod",GXType.Int32,6,0)
        };
        Object[] prmT004Y14;
        prmT004Y14 = new Object[] {
        new ParDef("@TSAntBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntCBCod",GXType.NChar,20,0)
        };
        Object[] prmT004Y15;
        prmT004Y15 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y3;
        prmT004Y3 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y16;
        prmT004Y16 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y17;
        prmT004Y17 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y2;
        prmT004Y2 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y18;
        prmT004Y18 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSAntFec",GXType.Date,8,0) ,
        new ParDef("@TSAntDoc",GXType.NVarChar,20,0) ,
        new ParDef("@TSAntImporte",GXType.Decimal,15,2) ,
        new ParDef("@TSAntConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@TSAntBanReg",GXType.NVarChar,10,0) ,
        new ParDef("@TSAntTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@TSAntBeneficiario",GXType.NVarChar,100,0) ,
        new ParDef("@TSAntMonCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntDocRef",GXType.NVarChar,10,0) ,
        new ParDef("@TSAntForCod",GXType.Int32,6,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ConBCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntCBCod",GXType.NChar,20,0)
        };
        Object[] prmT004Y19;
        prmT004Y19 = new Object[] {
        new ParDef("@TSAntFec",GXType.Date,8,0) ,
        new ParDef("@TSAntDoc",GXType.NVarChar,20,0) ,
        new ParDef("@TSAntImporte",GXType.Decimal,15,2) ,
        new ParDef("@TSAntConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@TSAntBanReg",GXType.NVarChar,10,0) ,
        new ParDef("@TSAntTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@TSAntBeneficiario",GXType.NVarChar,100,0) ,
        new ParDef("@TSAntMonCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntDocRef",GXType.NVarChar,10,0) ,
        new ParDef("@TSAntForCod",GXType.Int32,6,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ConBCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntCBCod",GXType.NChar,20,0) ,
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y20;
        prmT004Y20 = new Object[] {
        new ParDef("@TSAntCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004Y25;
        prmT004Y25 = new Object[] {
        };
        Object[] prmT004Y21;
        prmT004Y21 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT004Y22;
        prmT004Y22 = new Object[] {
        new ParDef("@ConBCod",GXType.Int32,6,0)
        };
        Object[] prmT004Y23;
        prmT004Y23 = new Object[] {
        new ParDef("@ConBCueCod",GXType.NChar,15,0)
        };
        Object[] prmT004Y24;
        prmT004Y24 = new Object[] {
        new ParDef("@TSAntBanCod",GXType.Int32,6,0)
        };
        Object[] prmT004Y26;
        prmT004Y26 = new Object[] {
        new ParDef("@TSAntBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSAntCBCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004Y2", "SELECT [TSAntCod], [TSAntFec], [TSAntDoc], [TSAntImporte], [TSAntConcepto], [TSAntBanReg], [TSAntTipCmb], [TSAntBeneficiario], [TSAntMonCod], [TSAntDocRef], [TSAntForCod], [PrvCod], [ConBCod], [TSAntBanCod] AS TSAntBanCod, [TSAntCBCod] AS TSAntCBCod FROM [TSANTICIPOS] WITH (UPDLOCK) WHERE [TSAntCod] = @TSAntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y3", "SELECT [TSAntCod], [TSAntFec], [TSAntDoc], [TSAntImporte], [TSAntConcepto], [TSAntBanReg], [TSAntTipCmb], [TSAntBeneficiario], [TSAntMonCod], [TSAntDocRef], [TSAntForCod], [PrvCod], [ConBCod], [TSAntBanCod] AS TSAntBanCod, [TSAntCBCod] AS TSAntCBCod FROM [TSANTICIPOS] WHERE [TSAntCod] = @TSAntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y4", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y5", "SELECT [ConBCueCod] AS ConBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y6", "SELECT [BanDsc] AS TSAntBanDsc FROM [TSBANCOS] WHERE [BanCod] = @TSAntBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y7", "SELECT [BanCod] AS TSAntBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @TSAntBanCod AND [CBCod] = @TSAntCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y8", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y9", "SELECT T3.[ConBCueCod] AS ConBCueCod, TM1.[TSAntCod], TM1.[TSAntFec], T2.[PrvDsc], TM1.[TSAntDoc], TM1.[TSAntImporte], TM1.[TSAntConcepto], TM1.[TSAntBanReg], TM1.[TSAntTipCmb], TM1.[TSAntBeneficiario], TM1.[TSAntMonCod], TM1.[TSAntDocRef], TM1.[TSAntForCod], T4.[CueDsc] AS ConBCueDsc, T5.[BanDsc] AS TSAntBanDsc, TM1.[PrvCod], TM1.[ConBCod], TM1.[TSAntBanCod] AS TSAntBanCod, TM1.[TSAntCBCod] AS TSAntCBCod FROM (((([TSANTICIPOS] TM1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = TM1.[PrvCod]) INNER JOIN [TSCONCEPTOBANCOS] T3 ON T3.[ConBCod] = TM1.[ConBCod]) INNER JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = T3.[ConBCueCod]) INNER JOIN [TSBANCOS] T5 ON T5.[BanCod] = TM1.[TSAntBanCod]) WHERE TM1.[TSAntCod] = @TSAntCod ORDER BY TM1.[TSAntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y10", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y11", "SELECT [ConBCueCod] AS ConBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y12", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y13", "SELECT [BanDsc] AS TSAntBanDsc FROM [TSBANCOS] WHERE [BanCod] = @TSAntBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y14", "SELECT [BanCod] AS TSAntBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @TSAntBanCod AND [CBCod] = @TSAntCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y15", "SELECT [TSAntCod] FROM [TSANTICIPOS] WHERE [TSAntCod] = @TSAntCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y16", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE ( [TSAntCod] > @TSAntCod) ORDER BY [TSAntCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004Y17", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE ( [TSAntCod] < @TSAntCod) ORDER BY [TSAntCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004Y18", "INSERT INTO [TSANTICIPOS]([TSAntCod], [TSAntFec], [TSAntDoc], [TSAntImporte], [TSAntConcepto], [TSAntBanReg], [TSAntTipCmb], [TSAntBeneficiario], [TSAntMonCod], [TSAntDocRef], [TSAntForCod], [PrvCod], [ConBCod], [TSAntBanCod], [TSAntCBCod]) VALUES(@TSAntCod, @TSAntFec, @TSAntDoc, @TSAntImporte, @TSAntConcepto, @TSAntBanReg, @TSAntTipCmb, @TSAntBeneficiario, @TSAntMonCod, @TSAntDocRef, @TSAntForCod, @PrvCod, @ConBCod, @TSAntBanCod, @TSAntCBCod)", GxErrorMask.GX_NOMASK,prmT004Y18)
           ,new CursorDef("T004Y19", "UPDATE [TSANTICIPOS] SET [TSAntFec]=@TSAntFec, [TSAntDoc]=@TSAntDoc, [TSAntImporte]=@TSAntImporte, [TSAntConcepto]=@TSAntConcepto, [TSAntBanReg]=@TSAntBanReg, [TSAntTipCmb]=@TSAntTipCmb, [TSAntBeneficiario]=@TSAntBeneficiario, [TSAntMonCod]=@TSAntMonCod, [TSAntDocRef]=@TSAntDocRef, [TSAntForCod]=@TSAntForCod, [PrvCod]=@PrvCod, [ConBCod]=@ConBCod, [TSAntBanCod]=@TSAntBanCod, [TSAntCBCod]=@TSAntCBCod  WHERE [TSAntCod] = @TSAntCod", GxErrorMask.GX_NOMASK,prmT004Y19)
           ,new CursorDef("T004Y20", "DELETE FROM [TSANTICIPOS]  WHERE [TSAntCod] = @TSAntCod", GxErrorMask.GX_NOMASK,prmT004Y20)
           ,new CursorDef("T004Y21", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y22", "SELECT [ConBCueCod] AS ConBCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @ConBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y23", "SELECT [CueDsc] AS ConBCueDsc FROM [CBPLANCUENTA] WHERE [CueCod] = @ConBCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y24", "SELECT [BanDsc] AS TSAntBanDsc FROM [TSBANCOS] WHERE [BanCod] = @TSAntBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y25", "SELECT [TSAntCod] FROM [TSANTICIPOS] ORDER BY [TSAntCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y25,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004Y26", "SELECT [BanCod] AS TSAntBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @TSAntBanCod AND [CBCod] = @TSAntCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004Y26,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
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
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 100);
              ((string[]) buf[14])[0] = rslt.getString(15, 100);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
