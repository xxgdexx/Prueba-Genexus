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
   public class cldocumentos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A196ImpCliCod = GetPar( "ImpCliCod");
            AssignAttri("", false, "A196ImpCliCod", A196ImpCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A196ImpCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A195ImpMonCod = (int)(NumberUtil.Val( GetPar( "ImpMonCod"), "."));
            AssignAttri("", false, "A195ImpMonCod", StringUtil.LTrimStr( (decimal)(A195ImpMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A195ImpMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A194ImpConpCod = (int)(NumberUtil.Val( GetPar( "ImpConpCod"), "."));
            AssignAttri("", false, "A194ImpConpCod", StringUtil.LTrimStr( (decimal)(A194ImpConpCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A194ImpConpCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A193ImpMovCod = (int)(NumberUtil.Val( GetPar( "ImpMovCod"), "."));
            AssignAttri("", false, "A193ImpMovCod", StringUtil.LTrimStr( (decimal)(A193ImpMovCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A193ImpMovCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A192ImpVendCod = (int)(NumberUtil.Val( GetPar( "ImpVendCod"), "."));
            AssignAttri("", false, "A192ImpVendCod", StringUtil.LTrimStr( (decimal)(A192ImpVendCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A192ImpVendCod) ;
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
            Form.Meta.addItem("description", "Documentos Afectos IGV - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cldocumentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cldocumentos( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLDOCUMENTOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Item", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A191ImpItem), 10, 0, ".", "")), StringUtil.LTrim( ((edtImpItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A191ImpItem), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A191ImpItem), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpItem_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Documento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpTipCod_Internalname, StringUtil.RTrim( A1046ImpTipCod), StringUtil.RTrim( context.localUtil.Format( A1046ImpTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Documento", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpDocNum_Internalname, StringUtil.RTrim( A1030ImpDocNum), StringUtil.RTrim( context.localUtil.Format( A1030ImpDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtImpFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtImpFec_Internalname, context.localUtil.Format(A1034ImpFec, "99/99/99"), context.localUtil.Format( A1034ImpFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         GxWebStd.gx_bitmap( context, edtImpFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtImpFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha Vcto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtImpFecVcto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtImpFecVcto_Internalname, context.localUtil.Format(A1037ImpFecVcto, "99/99/99"), context.localUtil.Format( A1037ImpFecVcto, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpFecVcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpFecVcto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         GxWebStd.gx_bitmap( context, edtImpFecVcto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtImpFecVcto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "RUC", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpCliCod_Internalname, StringUtil.RTrim( A196ImpCliCod), StringUtil.RTrim( context.localUtil.Format( A196ImpCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Cliente", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpCliDsc_Internalname, StringUtil.RTrim( A1021ImpCliDsc), StringUtil.RTrim( context.localUtil.Format( A1021ImpCliDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Moneda", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A195ImpMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A195ImpMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A195ImpMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Condición Pago", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A194ImpConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A194ImpConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A194ImpConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Condición de Pago", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtImpConpDsc_Internalname, StringUtil.RTrim( A1024ImpConpDsc), StringUtil.RTrim( context.localUtil.Format( A1024ImpConpDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpConpDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpConpDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Dias", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtImpConpDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1023ImpConpDias), 4, 0, ".", "")), StringUtil.LTrim( ((edtImpConpDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A1023ImpConpDias), "ZZZ9") : context.localUtil.Format( (decimal)(A1023ImpConpDias), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpConpDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpConpDias_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Lista de Precios", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpTLis_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1048ImpTLis), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpTLis_Enabled!=0) ? context.localUtil.Format( (decimal)(A1048ImpTLis), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1048ImpTLis), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpTLis_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpTLis_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "% Dscto", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPorDscto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1040ImpPorDscto, 17, 2, ".", "")), StringUtil.LTrim( ((edtImpPorDscto_Enabled!=0) ? context.localUtil.Format( A1040ImpPorDscto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1040ImpPorDscto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPorDscto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPorDscto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "% I.G.V.", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpPorIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A1041ImpPorIVA, 17, 2, ".", "")), StringUtil.LTrim( ((edtImpPorIVA_Enabled!=0) ? context.localUtil.Format( A1041ImpPorIVA, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1041ImpPorIVA, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpPorIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpPorIVA_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Observaciones", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtImpObs_Internalname, A1039ImpObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", 0, 1, edtImpObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "T/D Referencia", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpTRef_Internalname, StringUtil.RTrim( A1050ImpTRef), StringUtil.RTrim( context.localUtil.Format( A1050ImpTRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpTRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpTRef_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Doc. Referencia", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpRef_Internalname, StringUtil.RTrim( A1043ImpRef), StringUtil.RTrim( context.localUtil.Format( A1043ImpRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpRef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Situación", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpSts_Internalname, StringUtil.RTrim( A1044ImpSts), StringUtil.RTrim( context.localUtil.Format( A1044ImpSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Total Item", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( A1047ImpTItem, 17, 2, ".", "")), StringUtil.LTrim( ((edtImpTItem_Enabled!=0) ? context.localUtil.Format( A1047ImpTItem, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1047ImpTItem, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpTItem_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Fecha Referencia", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtImpFecRef_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtImpFecRef_Internalname, context.localUtil.Format(A1036ImpFecRef, "99/99/99"), context.localUtil.Format( A1036ImpFecRef, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpFecRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpFecRef_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         GxWebStd.gx_bitmap( context, edtImpFecRef_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtImpFecRef_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Movimiento", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A193ImpMovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpMovCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A193ImpMovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A193ImpMovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpMovCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Almacen", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1016ImpAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1016ImpAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1016ImpAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Direccion Anexa", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpCliDirCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1020ImpCliDirCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpCliDirCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1020ImpCliDirCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1020ImpCliDirCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpCliDirCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpCliDirCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Vendedor", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpVendCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A192ImpVendCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpVendCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A192ImpVendCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A192ImpVendCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpVendCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpVendCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Forma de Pago", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1038ImpForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1038ImpForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1038ImpForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Banco", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1017ImpBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1017ImpBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1017ImpBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "N° Informe", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpCobCod_Internalname, StringUtil.RTrim( A1022ImpCobCod), StringUtil.RTrim( context.localUtil.Format( A1022ImpCobCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpCobCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpCobCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Direccion de Despacho", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpCliDespacho_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1018ImpCliDespacho), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpCliDespacho_Enabled!=0) ? context.localUtil.Format( (decimal)(A1018ImpCliDespacho), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1018ImpCliDespacho), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpCliDespacho_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpCliDespacho_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Fecha Atención", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtImpFecAten_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtImpFecAten_Internalname, context.localUtil.TToC( A1035ImpFecAten, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1035ImpFecAten, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpFecAten_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpFecAten_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         GxWebStd.gx_bitmap( context, edtImpFecAten_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtImpFecAten_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Tipo de Pedido", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtImpTPedCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1049ImpTPedCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtImpTPedCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1049ImpTPedCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1049ImpTPedCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtImpTPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtImpTPedCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLDOCUMENTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 169,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 170,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 172,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLDOCUMENTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLDOCUMENTOS.htm");
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
            Z191ImpItem = (long)(context.localUtil.CToN( cgiGet( "Z191ImpItem"), ".", ","));
            Z1046ImpTipCod = cgiGet( "Z1046ImpTipCod");
            Z1030ImpDocNum = cgiGet( "Z1030ImpDocNum");
            Z1034ImpFec = context.localUtil.CToD( cgiGet( "Z1034ImpFec"), 0);
            Z1037ImpFecVcto = context.localUtil.CToD( cgiGet( "Z1037ImpFecVcto"), 0);
            Z1021ImpCliDsc = cgiGet( "Z1021ImpCliDsc");
            Z1048ImpTLis = (int)(context.localUtil.CToN( cgiGet( "Z1048ImpTLis"), ".", ","));
            Z1040ImpPorDscto = context.localUtil.CToN( cgiGet( "Z1040ImpPorDscto"), ".", ",");
            Z1041ImpPorIVA = context.localUtil.CToN( cgiGet( "Z1041ImpPorIVA"), ".", ",");
            Z1050ImpTRef = cgiGet( "Z1050ImpTRef");
            Z1043ImpRef = cgiGet( "Z1043ImpRef");
            Z1044ImpSts = cgiGet( "Z1044ImpSts");
            Z1047ImpTItem = context.localUtil.CToN( cgiGet( "Z1047ImpTItem"), ".", ",");
            Z1036ImpFecRef = context.localUtil.CToD( cgiGet( "Z1036ImpFecRef"), 0);
            Z1016ImpAlmCod = (int)(context.localUtil.CToN( cgiGet( "Z1016ImpAlmCod"), ".", ","));
            Z1020ImpCliDirCod = (int)(context.localUtil.CToN( cgiGet( "Z1020ImpCliDirCod"), ".", ","));
            Z1038ImpForCod = (int)(context.localUtil.CToN( cgiGet( "Z1038ImpForCod"), ".", ","));
            Z1017ImpBanCod = (int)(context.localUtil.CToN( cgiGet( "Z1017ImpBanCod"), ".", ","));
            Z1022ImpCobCod = cgiGet( "Z1022ImpCobCod");
            Z1018ImpCliDespacho = (int)(context.localUtil.CToN( cgiGet( "Z1018ImpCliDespacho"), ".", ","));
            Z1035ImpFecAten = context.localUtil.CToT( cgiGet( "Z1035ImpFecAten"), 0);
            Z1049ImpTPedCod = (int)(context.localUtil.CToN( cgiGet( "Z1049ImpTPedCod"), ".", ","));
            Z1045ImpTieCod = (int)(context.localUtil.CToN( cgiGet( "Z1045ImpTieCod"), ".", ","));
            Z196ImpCliCod = cgiGet( "Z196ImpCliCod");
            Z195ImpMonCod = (int)(context.localUtil.CToN( cgiGet( "Z195ImpMonCod"), ".", ","));
            Z194ImpConpCod = (int)(context.localUtil.CToN( cgiGet( "Z194ImpConpCod"), ".", ","));
            Z193ImpMovCod = (int)(context.localUtil.CToN( cgiGet( "Z193ImpMovCod"), ".", ","));
            Z192ImpVendCod = (int)(context.localUtil.CToN( cgiGet( "Z192ImpVendCod"), ".", ","));
            A1045ImpTieCod = (int)(context.localUtil.CToN( cgiGet( "Z1045ImpTieCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1045ImpTieCod = (int)(context.localUtil.CToN( cgiGet( "IMPTIECOD"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpItem_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPITEM");
               AnyError = 1;
               GX_FocusControl = edtImpItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A191ImpItem = 0;
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            }
            else
            {
               A191ImpItem = (long)(context.localUtil.CToN( cgiGet( edtImpItem_Internalname), ".", ","));
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            }
            A1046ImpTipCod = cgiGet( edtImpTipCod_Internalname);
            AssignAttri("", false, "A1046ImpTipCod", A1046ImpTipCod);
            A1030ImpDocNum = cgiGet( edtImpDocNum_Internalname);
            AssignAttri("", false, "A1030ImpDocNum", A1030ImpDocNum);
            if ( context.localUtil.VCDate( cgiGet( edtImpFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "IMPFEC");
               AnyError = 1;
               GX_FocusControl = edtImpFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1034ImpFec = DateTime.MinValue;
               AssignAttri("", false, "A1034ImpFec", context.localUtil.Format(A1034ImpFec, "99/99/99"));
            }
            else
            {
               A1034ImpFec = context.localUtil.CToD( cgiGet( edtImpFec_Internalname), 2);
               AssignAttri("", false, "A1034ImpFec", context.localUtil.Format(A1034ImpFec, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtImpFecVcto_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "IMPFECVCTO");
               AnyError = 1;
               GX_FocusControl = edtImpFecVcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1037ImpFecVcto = DateTime.MinValue;
               AssignAttri("", false, "A1037ImpFecVcto", context.localUtil.Format(A1037ImpFecVcto, "99/99/99"));
            }
            else
            {
               A1037ImpFecVcto = context.localUtil.CToD( cgiGet( edtImpFecVcto_Internalname), 2);
               AssignAttri("", false, "A1037ImpFecVcto", context.localUtil.Format(A1037ImpFecVcto, "99/99/99"));
            }
            A196ImpCliCod = cgiGet( edtImpCliCod_Internalname);
            AssignAttri("", false, "A196ImpCliCod", A196ImpCliCod);
            A1021ImpCliDsc = cgiGet( edtImpCliDsc_Internalname);
            AssignAttri("", false, "A1021ImpCliDsc", A1021ImpCliDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPMONCOD");
               AnyError = 1;
               GX_FocusControl = edtImpMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A195ImpMonCod = 0;
               AssignAttri("", false, "A195ImpMonCod", StringUtil.LTrimStr( (decimal)(A195ImpMonCod), 6, 0));
            }
            else
            {
               A195ImpMonCod = (int)(context.localUtil.CToN( cgiGet( edtImpMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A195ImpMonCod", StringUtil.LTrimStr( (decimal)(A195ImpMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtImpConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A194ImpConpCod = 0;
               AssignAttri("", false, "A194ImpConpCod", StringUtil.LTrimStr( (decimal)(A194ImpConpCod), 6, 0));
            }
            else
            {
               A194ImpConpCod = (int)(context.localUtil.CToN( cgiGet( edtImpConpCod_Internalname), ".", ","));
               AssignAttri("", false, "A194ImpConpCod", StringUtil.LTrimStr( (decimal)(A194ImpConpCod), 6, 0));
            }
            A1024ImpConpDsc = cgiGet( edtImpConpDsc_Internalname);
            AssignAttri("", false, "A1024ImpConpDsc", A1024ImpConpDsc);
            A1023ImpConpDias = (short)(context.localUtil.CToN( cgiGet( edtImpConpDias_Internalname), ".", ","));
            AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrimStr( (decimal)(A1023ImpConpDias), 4, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpTLis_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpTLis_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPTLIS");
               AnyError = 1;
               GX_FocusControl = edtImpTLis_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1048ImpTLis = 0;
               AssignAttri("", false, "A1048ImpTLis", StringUtil.LTrimStr( (decimal)(A1048ImpTLis), 6, 0));
            }
            else
            {
               A1048ImpTLis = (int)(context.localUtil.CToN( cgiGet( edtImpTLis_Internalname), ".", ","));
               AssignAttri("", false, "A1048ImpTLis", StringUtil.LTrimStr( (decimal)(A1048ImpTLis), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpPorDscto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtImpPorDscto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPPORDSCTO");
               AnyError = 1;
               GX_FocusControl = edtImpPorDscto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1040ImpPorDscto = 0;
               AssignAttri("", false, "A1040ImpPorDscto", StringUtil.LTrimStr( A1040ImpPorDscto, 15, 2));
            }
            else
            {
               A1040ImpPorDscto = context.localUtil.CToN( cgiGet( edtImpPorDscto_Internalname), ".", ",");
               AssignAttri("", false, "A1040ImpPorDscto", StringUtil.LTrimStr( A1040ImpPorDscto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpPorIVA_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtImpPorIVA_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPPORIVA");
               AnyError = 1;
               GX_FocusControl = edtImpPorIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1041ImpPorIVA = 0;
               AssignAttri("", false, "A1041ImpPorIVA", StringUtil.LTrimStr( A1041ImpPorIVA, 15, 2));
            }
            else
            {
               A1041ImpPorIVA = context.localUtil.CToN( cgiGet( edtImpPorIVA_Internalname), ".", ",");
               AssignAttri("", false, "A1041ImpPorIVA", StringUtil.LTrimStr( A1041ImpPorIVA, 15, 2));
            }
            A1039ImpObs = cgiGet( edtImpObs_Internalname);
            AssignAttri("", false, "A1039ImpObs", A1039ImpObs);
            A1050ImpTRef = cgiGet( edtImpTRef_Internalname);
            AssignAttri("", false, "A1050ImpTRef", A1050ImpTRef);
            A1043ImpRef = cgiGet( edtImpRef_Internalname);
            AssignAttri("", false, "A1043ImpRef", A1043ImpRef);
            A1044ImpSts = cgiGet( edtImpSts_Internalname);
            AssignAttri("", false, "A1044ImpSts", A1044ImpSts);
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpTItem_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtImpTItem_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPTITEM");
               AnyError = 1;
               GX_FocusControl = edtImpTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1047ImpTItem = 0;
               AssignAttri("", false, "A1047ImpTItem", StringUtil.LTrimStr( A1047ImpTItem, 15, 2));
            }
            else
            {
               A1047ImpTItem = context.localUtil.CToN( cgiGet( edtImpTItem_Internalname), ".", ",");
               AssignAttri("", false, "A1047ImpTItem", StringUtil.LTrimStr( A1047ImpTItem, 15, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtImpFecRef_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Referencia"}), 1, "IMPFECREF");
               AnyError = 1;
               GX_FocusControl = edtImpFecRef_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1036ImpFecRef = DateTime.MinValue;
               AssignAttri("", false, "A1036ImpFecRef", context.localUtil.Format(A1036ImpFecRef, "99/99/99"));
            }
            else
            {
               A1036ImpFecRef = context.localUtil.CToD( cgiGet( edtImpFecRef_Internalname), 2);
               AssignAttri("", false, "A1036ImpFecRef", context.localUtil.Format(A1036ImpFecRef, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtImpMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A193ImpMovCod = 0;
               AssignAttri("", false, "A193ImpMovCod", StringUtil.LTrimStr( (decimal)(A193ImpMovCod), 6, 0));
            }
            else
            {
               A193ImpMovCod = (int)(context.localUtil.CToN( cgiGet( edtImpMovCod_Internalname), ".", ","));
               AssignAttri("", false, "A193ImpMovCod", StringUtil.LTrimStr( (decimal)(A193ImpMovCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPALMCOD");
               AnyError = 1;
               GX_FocusControl = edtImpAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1016ImpAlmCod = 0;
               AssignAttri("", false, "A1016ImpAlmCod", StringUtil.LTrimStr( (decimal)(A1016ImpAlmCod), 6, 0));
            }
            else
            {
               A1016ImpAlmCod = (int)(context.localUtil.CToN( cgiGet( edtImpAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A1016ImpAlmCod", StringUtil.LTrimStr( (decimal)(A1016ImpAlmCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpCliDirCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpCliDirCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPCLIDIRCOD");
               AnyError = 1;
               GX_FocusControl = edtImpCliDirCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1020ImpCliDirCod = 0;
               AssignAttri("", false, "A1020ImpCliDirCod", StringUtil.LTrimStr( (decimal)(A1020ImpCliDirCod), 6, 0));
            }
            else
            {
               A1020ImpCliDirCod = (int)(context.localUtil.CToN( cgiGet( edtImpCliDirCod_Internalname), ".", ","));
               AssignAttri("", false, "A1020ImpCliDirCod", StringUtil.LTrimStr( (decimal)(A1020ImpCliDirCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpVendCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpVendCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPVENDCOD");
               AnyError = 1;
               GX_FocusControl = edtImpVendCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A192ImpVendCod = 0;
               AssignAttri("", false, "A192ImpVendCod", StringUtil.LTrimStr( (decimal)(A192ImpVendCod), 6, 0));
            }
            else
            {
               A192ImpVendCod = (int)(context.localUtil.CToN( cgiGet( edtImpVendCod_Internalname), ".", ","));
               AssignAttri("", false, "A192ImpVendCod", StringUtil.LTrimStr( (decimal)(A192ImpVendCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPFORCOD");
               AnyError = 1;
               GX_FocusControl = edtImpForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1038ImpForCod = 0;
               AssignAttri("", false, "A1038ImpForCod", StringUtil.LTrimStr( (decimal)(A1038ImpForCod), 6, 0));
            }
            else
            {
               A1038ImpForCod = (int)(context.localUtil.CToN( cgiGet( edtImpForCod_Internalname), ".", ","));
               AssignAttri("", false, "A1038ImpForCod", StringUtil.LTrimStr( (decimal)(A1038ImpForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPBANCOD");
               AnyError = 1;
               GX_FocusControl = edtImpBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1017ImpBanCod = 0;
               AssignAttri("", false, "A1017ImpBanCod", StringUtil.LTrimStr( (decimal)(A1017ImpBanCod), 6, 0));
            }
            else
            {
               A1017ImpBanCod = (int)(context.localUtil.CToN( cgiGet( edtImpBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A1017ImpBanCod", StringUtil.LTrimStr( (decimal)(A1017ImpBanCod), 6, 0));
            }
            A1022ImpCobCod = cgiGet( edtImpCobCod_Internalname);
            AssignAttri("", false, "A1022ImpCobCod", A1022ImpCobCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpCliDespacho_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpCliDespacho_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPCLIDESPACHO");
               AnyError = 1;
               GX_FocusControl = edtImpCliDespacho_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1018ImpCliDespacho = 0;
               AssignAttri("", false, "A1018ImpCliDespacho", StringUtil.LTrimStr( (decimal)(A1018ImpCliDespacho), 6, 0));
            }
            else
            {
               A1018ImpCliDespacho = (int)(context.localUtil.CToN( cgiGet( edtImpCliDespacho_Internalname), ".", ","));
               AssignAttri("", false, "A1018ImpCliDespacho", StringUtil.LTrimStr( (decimal)(A1018ImpCliDespacho), 6, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtImpFecAten_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Atención"}), 1, "IMPFECATEN");
               AnyError = 1;
               GX_FocusControl = edtImpFecAten_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1035ImpFecAten = (DateTime)(DateTime.MinValue);
               n1035ImpFecAten = false;
               AssignAttri("", false, "A1035ImpFecAten", context.localUtil.TToC( A1035ImpFecAten, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1035ImpFecAten = context.localUtil.CToT( cgiGet( edtImpFecAten_Internalname));
               n1035ImpFecAten = false;
               AssignAttri("", false, "A1035ImpFecAten", context.localUtil.TToC( A1035ImpFecAten, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtImpTPedCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtImpTPedCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "IMPTPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtImpTPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1049ImpTPedCod = 0;
               AssignAttri("", false, "A1049ImpTPedCod", StringUtil.LTrimStr( (decimal)(A1049ImpTPedCod), 6, 0));
            }
            else
            {
               A1049ImpTPedCod = (int)(context.localUtil.CToN( cgiGet( edtImpTPedCod_Internalname), ".", ","));
               AssignAttri("", false, "A1049ImpTPedCod", StringUtil.LTrimStr( (decimal)(A1049ImpTPedCod), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CLDOCUMENTOS");
            forbiddenHiddens.Add("ImpTieCod", context.localUtil.Format( (decimal)(A1045ImpTieCod), "ZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A191ImpItem != Z191ImpItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cldocumentos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A191ImpItem = (long)(NumberUtil.Val( GetPar( "ImpItem"), "."));
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
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
               InitAll2L89( ) ;
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
         DisableAttributes2L89( ) ;
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

      protected void CONFIRM_2L0( )
      {
         BeforeValidate2L89( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2L89( ) ;
            }
            else
            {
               CheckExtendedTable2L89( ) ;
               if ( AnyError == 0 )
               {
                  ZM2L89( 6) ;
                  ZM2L89( 7) ;
                  ZM2L89( 8) ;
                  ZM2L89( 9) ;
                  ZM2L89( 10) ;
               }
               CloseExtendedTableCursors2L89( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2L0( ) ;
         }
      }

      protected void ResetCaption2L0( )
      {
      }

      protected void ZM2L89( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1046ImpTipCod = T002L3_A1046ImpTipCod[0];
               Z1030ImpDocNum = T002L3_A1030ImpDocNum[0];
               Z1034ImpFec = T002L3_A1034ImpFec[0];
               Z1037ImpFecVcto = T002L3_A1037ImpFecVcto[0];
               Z1021ImpCliDsc = T002L3_A1021ImpCliDsc[0];
               Z1048ImpTLis = T002L3_A1048ImpTLis[0];
               Z1040ImpPorDscto = T002L3_A1040ImpPorDscto[0];
               Z1041ImpPorIVA = T002L3_A1041ImpPorIVA[0];
               Z1050ImpTRef = T002L3_A1050ImpTRef[0];
               Z1043ImpRef = T002L3_A1043ImpRef[0];
               Z1044ImpSts = T002L3_A1044ImpSts[0];
               Z1047ImpTItem = T002L3_A1047ImpTItem[0];
               Z1036ImpFecRef = T002L3_A1036ImpFecRef[0];
               Z1016ImpAlmCod = T002L3_A1016ImpAlmCod[0];
               Z1020ImpCliDirCod = T002L3_A1020ImpCliDirCod[0];
               Z1038ImpForCod = T002L3_A1038ImpForCod[0];
               Z1017ImpBanCod = T002L3_A1017ImpBanCod[0];
               Z1022ImpCobCod = T002L3_A1022ImpCobCod[0];
               Z1018ImpCliDespacho = T002L3_A1018ImpCliDespacho[0];
               Z1035ImpFecAten = T002L3_A1035ImpFecAten[0];
               Z1049ImpTPedCod = T002L3_A1049ImpTPedCod[0];
               Z1045ImpTieCod = T002L3_A1045ImpTieCod[0];
               Z196ImpCliCod = T002L3_A196ImpCliCod[0];
               Z195ImpMonCod = T002L3_A195ImpMonCod[0];
               Z194ImpConpCod = T002L3_A194ImpConpCod[0];
               Z193ImpMovCod = T002L3_A193ImpMovCod[0];
               Z192ImpVendCod = T002L3_A192ImpVendCod[0];
            }
            else
            {
               Z1046ImpTipCod = A1046ImpTipCod;
               Z1030ImpDocNum = A1030ImpDocNum;
               Z1034ImpFec = A1034ImpFec;
               Z1037ImpFecVcto = A1037ImpFecVcto;
               Z1021ImpCliDsc = A1021ImpCliDsc;
               Z1048ImpTLis = A1048ImpTLis;
               Z1040ImpPorDscto = A1040ImpPorDscto;
               Z1041ImpPorIVA = A1041ImpPorIVA;
               Z1050ImpTRef = A1050ImpTRef;
               Z1043ImpRef = A1043ImpRef;
               Z1044ImpSts = A1044ImpSts;
               Z1047ImpTItem = A1047ImpTItem;
               Z1036ImpFecRef = A1036ImpFecRef;
               Z1016ImpAlmCod = A1016ImpAlmCod;
               Z1020ImpCliDirCod = A1020ImpCliDirCod;
               Z1038ImpForCod = A1038ImpForCod;
               Z1017ImpBanCod = A1017ImpBanCod;
               Z1022ImpCobCod = A1022ImpCobCod;
               Z1018ImpCliDespacho = A1018ImpCliDespacho;
               Z1035ImpFecAten = A1035ImpFecAten;
               Z1049ImpTPedCod = A1049ImpTPedCod;
               Z1045ImpTieCod = A1045ImpTieCod;
               Z196ImpCliCod = A196ImpCliCod;
               Z195ImpMonCod = A195ImpMonCod;
               Z194ImpConpCod = A194ImpConpCod;
               Z193ImpMovCod = A193ImpMovCod;
               Z192ImpVendCod = A192ImpVendCod;
            }
         }
         if ( GX_JID == -5 )
         {
            Z191ImpItem = A191ImpItem;
            Z1046ImpTipCod = A1046ImpTipCod;
            Z1030ImpDocNum = A1030ImpDocNum;
            Z1034ImpFec = A1034ImpFec;
            Z1037ImpFecVcto = A1037ImpFecVcto;
            Z1021ImpCliDsc = A1021ImpCliDsc;
            Z1048ImpTLis = A1048ImpTLis;
            Z1040ImpPorDscto = A1040ImpPorDscto;
            Z1041ImpPorIVA = A1041ImpPorIVA;
            Z1039ImpObs = A1039ImpObs;
            Z1050ImpTRef = A1050ImpTRef;
            Z1043ImpRef = A1043ImpRef;
            Z1044ImpSts = A1044ImpSts;
            Z1047ImpTItem = A1047ImpTItem;
            Z1036ImpFecRef = A1036ImpFecRef;
            Z1016ImpAlmCod = A1016ImpAlmCod;
            Z1020ImpCliDirCod = A1020ImpCliDirCod;
            Z1038ImpForCod = A1038ImpForCod;
            Z1017ImpBanCod = A1017ImpBanCod;
            Z1022ImpCobCod = A1022ImpCobCod;
            Z1018ImpCliDespacho = A1018ImpCliDespacho;
            Z1035ImpFecAten = A1035ImpFecAten;
            Z1049ImpTPedCod = A1049ImpTPedCod;
            Z1045ImpTieCod = A1045ImpTieCod;
            Z196ImpCliCod = A196ImpCliCod;
            Z195ImpMonCod = A195ImpMonCod;
            Z194ImpConpCod = A194ImpConpCod;
            Z193ImpMovCod = A193ImpMovCod;
            Z192ImpVendCod = A192ImpVendCod;
            Z1024ImpConpDsc = A1024ImpConpDsc;
            Z1023ImpConpDias = A1023ImpConpDias;
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

      protected void Load2L89( )
      {
         /* Using cursor T002L9 */
         pr_default.execute(7, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound89 = 1;
            A1046ImpTipCod = T002L9_A1046ImpTipCod[0];
            AssignAttri("", false, "A1046ImpTipCod", A1046ImpTipCod);
            A1030ImpDocNum = T002L9_A1030ImpDocNum[0];
            AssignAttri("", false, "A1030ImpDocNum", A1030ImpDocNum);
            A1034ImpFec = T002L9_A1034ImpFec[0];
            AssignAttri("", false, "A1034ImpFec", context.localUtil.Format(A1034ImpFec, "99/99/99"));
            A1037ImpFecVcto = T002L9_A1037ImpFecVcto[0];
            AssignAttri("", false, "A1037ImpFecVcto", context.localUtil.Format(A1037ImpFecVcto, "99/99/99"));
            A1021ImpCliDsc = T002L9_A1021ImpCliDsc[0];
            AssignAttri("", false, "A1021ImpCliDsc", A1021ImpCliDsc);
            A1024ImpConpDsc = T002L9_A1024ImpConpDsc[0];
            AssignAttri("", false, "A1024ImpConpDsc", A1024ImpConpDsc);
            A1023ImpConpDias = T002L9_A1023ImpConpDias[0];
            AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrimStr( (decimal)(A1023ImpConpDias), 4, 0));
            A1048ImpTLis = T002L9_A1048ImpTLis[0];
            AssignAttri("", false, "A1048ImpTLis", StringUtil.LTrimStr( (decimal)(A1048ImpTLis), 6, 0));
            A1040ImpPorDscto = T002L9_A1040ImpPorDscto[0];
            AssignAttri("", false, "A1040ImpPorDscto", StringUtil.LTrimStr( A1040ImpPorDscto, 15, 2));
            A1041ImpPorIVA = T002L9_A1041ImpPorIVA[0];
            AssignAttri("", false, "A1041ImpPorIVA", StringUtil.LTrimStr( A1041ImpPorIVA, 15, 2));
            A1039ImpObs = T002L9_A1039ImpObs[0];
            AssignAttri("", false, "A1039ImpObs", A1039ImpObs);
            A1050ImpTRef = T002L9_A1050ImpTRef[0];
            AssignAttri("", false, "A1050ImpTRef", A1050ImpTRef);
            A1043ImpRef = T002L9_A1043ImpRef[0];
            AssignAttri("", false, "A1043ImpRef", A1043ImpRef);
            A1044ImpSts = T002L9_A1044ImpSts[0];
            AssignAttri("", false, "A1044ImpSts", A1044ImpSts);
            A1047ImpTItem = T002L9_A1047ImpTItem[0];
            AssignAttri("", false, "A1047ImpTItem", StringUtil.LTrimStr( A1047ImpTItem, 15, 2));
            A1036ImpFecRef = T002L9_A1036ImpFecRef[0];
            AssignAttri("", false, "A1036ImpFecRef", context.localUtil.Format(A1036ImpFecRef, "99/99/99"));
            A1016ImpAlmCod = T002L9_A1016ImpAlmCod[0];
            AssignAttri("", false, "A1016ImpAlmCod", StringUtil.LTrimStr( (decimal)(A1016ImpAlmCod), 6, 0));
            A1020ImpCliDirCod = T002L9_A1020ImpCliDirCod[0];
            AssignAttri("", false, "A1020ImpCliDirCod", StringUtil.LTrimStr( (decimal)(A1020ImpCliDirCod), 6, 0));
            A1038ImpForCod = T002L9_A1038ImpForCod[0];
            AssignAttri("", false, "A1038ImpForCod", StringUtil.LTrimStr( (decimal)(A1038ImpForCod), 6, 0));
            A1017ImpBanCod = T002L9_A1017ImpBanCod[0];
            AssignAttri("", false, "A1017ImpBanCod", StringUtil.LTrimStr( (decimal)(A1017ImpBanCod), 6, 0));
            A1022ImpCobCod = T002L9_A1022ImpCobCod[0];
            AssignAttri("", false, "A1022ImpCobCod", A1022ImpCobCod);
            A1018ImpCliDespacho = T002L9_A1018ImpCliDespacho[0];
            AssignAttri("", false, "A1018ImpCliDespacho", StringUtil.LTrimStr( (decimal)(A1018ImpCliDespacho), 6, 0));
            A1035ImpFecAten = T002L9_A1035ImpFecAten[0];
            n1035ImpFecAten = T002L9_n1035ImpFecAten[0];
            AssignAttri("", false, "A1035ImpFecAten", context.localUtil.TToC( A1035ImpFecAten, 8, 5, 0, 3, "/", ":", " "));
            A1049ImpTPedCod = T002L9_A1049ImpTPedCod[0];
            AssignAttri("", false, "A1049ImpTPedCod", StringUtil.LTrimStr( (decimal)(A1049ImpTPedCod), 6, 0));
            A1045ImpTieCod = T002L9_A1045ImpTieCod[0];
            A196ImpCliCod = T002L9_A196ImpCliCod[0];
            AssignAttri("", false, "A196ImpCliCod", A196ImpCliCod);
            A195ImpMonCod = T002L9_A195ImpMonCod[0];
            AssignAttri("", false, "A195ImpMonCod", StringUtil.LTrimStr( (decimal)(A195ImpMonCod), 6, 0));
            A194ImpConpCod = T002L9_A194ImpConpCod[0];
            AssignAttri("", false, "A194ImpConpCod", StringUtil.LTrimStr( (decimal)(A194ImpConpCod), 6, 0));
            A193ImpMovCod = T002L9_A193ImpMovCod[0];
            AssignAttri("", false, "A193ImpMovCod", StringUtil.LTrimStr( (decimal)(A193ImpMovCod), 6, 0));
            A192ImpVendCod = T002L9_A192ImpVendCod[0];
            AssignAttri("", false, "A192ImpVendCod", StringUtil.LTrimStr( (decimal)(A192ImpVendCod), 6, 0));
            ZM2L89( -5) ;
         }
         pr_default.close(7);
         OnLoadActions2L89( ) ;
      }

      protected void OnLoadActions2L89( )
      {
      }

      protected void CheckExtendedTable2L89( )
      {
         nIsDirty_89 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1034ImpFec) || ( DateTimeUtil.ResetTime ( A1034ImpFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "IMPFEC");
            AnyError = 1;
            GX_FocusControl = edtImpFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1037ImpFecVcto) || ( DateTimeUtil.ResetTime ( A1037ImpFecVcto ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "IMPFECVCTO");
            AnyError = 1;
            GX_FocusControl = edtImpFecVcto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002L4 */
         pr_default.execute(2, new Object[] {A196ImpCliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "IMPCLICOD");
            AnyError = 1;
            GX_FocusControl = edtImpCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002L5 */
         pr_default.execute(3, new Object[] {A195ImpMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "IMPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtImpMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         /* Using cursor T002L6 */
         pr_default.execute(4, new Object[] {A194ImpConpCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Pago'.", "ForeignKeyNotFound", 1, "IMPCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtImpConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1024ImpConpDsc = T002L6_A1024ImpConpDsc[0];
         AssignAttri("", false, "A1024ImpConpDsc", A1024ImpConpDsc);
         A1023ImpConpDias = T002L6_A1023ImpConpDias[0];
         AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrimStr( (decimal)(A1023ImpConpDias), 4, 0));
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A1036ImpFecRef) || ( DateTimeUtil.ResetTime ( A1036ImpFecRef ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Referencia fuera de rango", "OutOfRange", 1, "IMPFECREF");
            AnyError = 1;
            GX_FocusControl = edtImpFecRef_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002L7 */
         pr_default.execute(5, new Object[] {A193ImpMovCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento'.", "ForeignKeyNotFound", 1, "IMPMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtImpMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T002L8 */
         pr_default.execute(6, new Object[] {A192ImpVendCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "IMPVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtImpVendCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A1035ImpFecAten) || ( A1035ImpFecAten >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Atención fuera de rango", "OutOfRange", 1, "IMPFECATEN");
            AnyError = 1;
            GX_FocusControl = edtImpFecAten_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors2L89( )
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

      protected void gxLoad_6( string A196ImpCliCod )
      {
         /* Using cursor T002L10 */
         pr_default.execute(8, new Object[] {A196ImpCliCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "IMPCLICOD");
            AnyError = 1;
            GX_FocusControl = edtImpCliCod_Internalname;
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

      protected void gxLoad_7( int A195ImpMonCod )
      {
         /* Using cursor T002L11 */
         pr_default.execute(9, new Object[] {A195ImpMonCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "IMPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtImpMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_8( int A194ImpConpCod )
      {
         /* Using cursor T002L12 */
         pr_default.execute(10, new Object[] {A194ImpConpCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Pago'.", "ForeignKeyNotFound", 1, "IMPCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtImpConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1024ImpConpDsc = T002L12_A1024ImpConpDsc[0];
         AssignAttri("", false, "A1024ImpConpDsc", A1024ImpConpDsc);
         A1023ImpConpDias = T002L12_A1023ImpConpDias[0];
         AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrimStr( (decimal)(A1023ImpConpDias), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1024ImpConpDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1023ImpConpDias), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_9( int A193ImpMovCod )
      {
         /* Using cursor T002L13 */
         pr_default.execute(11, new Object[] {A193ImpMovCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento'.", "ForeignKeyNotFound", 1, "IMPMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtImpMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_10( int A192ImpVendCod )
      {
         /* Using cursor T002L14 */
         pr_default.execute(12, new Object[] {A192ImpVendCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "IMPVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtImpVendCod_Internalname;
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

      protected void GetKey2L89( )
      {
         /* Using cursor T002L15 */
         pr_default.execute(13, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound89 = 1;
         }
         else
         {
            RcdFound89 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002L3 */
         pr_default.execute(1, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2L89( 5) ;
            RcdFound89 = 1;
            A191ImpItem = T002L3_A191ImpItem[0];
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            A1046ImpTipCod = T002L3_A1046ImpTipCod[0];
            AssignAttri("", false, "A1046ImpTipCod", A1046ImpTipCod);
            A1030ImpDocNum = T002L3_A1030ImpDocNum[0];
            AssignAttri("", false, "A1030ImpDocNum", A1030ImpDocNum);
            A1034ImpFec = T002L3_A1034ImpFec[0];
            AssignAttri("", false, "A1034ImpFec", context.localUtil.Format(A1034ImpFec, "99/99/99"));
            A1037ImpFecVcto = T002L3_A1037ImpFecVcto[0];
            AssignAttri("", false, "A1037ImpFecVcto", context.localUtil.Format(A1037ImpFecVcto, "99/99/99"));
            A1021ImpCliDsc = T002L3_A1021ImpCliDsc[0];
            AssignAttri("", false, "A1021ImpCliDsc", A1021ImpCliDsc);
            A1048ImpTLis = T002L3_A1048ImpTLis[0];
            AssignAttri("", false, "A1048ImpTLis", StringUtil.LTrimStr( (decimal)(A1048ImpTLis), 6, 0));
            A1040ImpPorDscto = T002L3_A1040ImpPorDscto[0];
            AssignAttri("", false, "A1040ImpPorDscto", StringUtil.LTrimStr( A1040ImpPorDscto, 15, 2));
            A1041ImpPorIVA = T002L3_A1041ImpPorIVA[0];
            AssignAttri("", false, "A1041ImpPorIVA", StringUtil.LTrimStr( A1041ImpPorIVA, 15, 2));
            A1039ImpObs = T002L3_A1039ImpObs[0];
            AssignAttri("", false, "A1039ImpObs", A1039ImpObs);
            A1050ImpTRef = T002L3_A1050ImpTRef[0];
            AssignAttri("", false, "A1050ImpTRef", A1050ImpTRef);
            A1043ImpRef = T002L3_A1043ImpRef[0];
            AssignAttri("", false, "A1043ImpRef", A1043ImpRef);
            A1044ImpSts = T002L3_A1044ImpSts[0];
            AssignAttri("", false, "A1044ImpSts", A1044ImpSts);
            A1047ImpTItem = T002L3_A1047ImpTItem[0];
            AssignAttri("", false, "A1047ImpTItem", StringUtil.LTrimStr( A1047ImpTItem, 15, 2));
            A1036ImpFecRef = T002L3_A1036ImpFecRef[0];
            AssignAttri("", false, "A1036ImpFecRef", context.localUtil.Format(A1036ImpFecRef, "99/99/99"));
            A1016ImpAlmCod = T002L3_A1016ImpAlmCod[0];
            AssignAttri("", false, "A1016ImpAlmCod", StringUtil.LTrimStr( (decimal)(A1016ImpAlmCod), 6, 0));
            A1020ImpCliDirCod = T002L3_A1020ImpCliDirCod[0];
            AssignAttri("", false, "A1020ImpCliDirCod", StringUtil.LTrimStr( (decimal)(A1020ImpCliDirCod), 6, 0));
            A1038ImpForCod = T002L3_A1038ImpForCod[0];
            AssignAttri("", false, "A1038ImpForCod", StringUtil.LTrimStr( (decimal)(A1038ImpForCod), 6, 0));
            A1017ImpBanCod = T002L3_A1017ImpBanCod[0];
            AssignAttri("", false, "A1017ImpBanCod", StringUtil.LTrimStr( (decimal)(A1017ImpBanCod), 6, 0));
            A1022ImpCobCod = T002L3_A1022ImpCobCod[0];
            AssignAttri("", false, "A1022ImpCobCod", A1022ImpCobCod);
            A1018ImpCliDespacho = T002L3_A1018ImpCliDespacho[0];
            AssignAttri("", false, "A1018ImpCliDespacho", StringUtil.LTrimStr( (decimal)(A1018ImpCliDespacho), 6, 0));
            A1035ImpFecAten = T002L3_A1035ImpFecAten[0];
            n1035ImpFecAten = T002L3_n1035ImpFecAten[0];
            AssignAttri("", false, "A1035ImpFecAten", context.localUtil.TToC( A1035ImpFecAten, 8, 5, 0, 3, "/", ":", " "));
            A1049ImpTPedCod = T002L3_A1049ImpTPedCod[0];
            AssignAttri("", false, "A1049ImpTPedCod", StringUtil.LTrimStr( (decimal)(A1049ImpTPedCod), 6, 0));
            A1045ImpTieCod = T002L3_A1045ImpTieCod[0];
            A196ImpCliCod = T002L3_A196ImpCliCod[0];
            AssignAttri("", false, "A196ImpCliCod", A196ImpCliCod);
            A195ImpMonCod = T002L3_A195ImpMonCod[0];
            AssignAttri("", false, "A195ImpMonCod", StringUtil.LTrimStr( (decimal)(A195ImpMonCod), 6, 0));
            A194ImpConpCod = T002L3_A194ImpConpCod[0];
            AssignAttri("", false, "A194ImpConpCod", StringUtil.LTrimStr( (decimal)(A194ImpConpCod), 6, 0));
            A193ImpMovCod = T002L3_A193ImpMovCod[0];
            AssignAttri("", false, "A193ImpMovCod", StringUtil.LTrimStr( (decimal)(A193ImpMovCod), 6, 0));
            A192ImpVendCod = T002L3_A192ImpVendCod[0];
            AssignAttri("", false, "A192ImpVendCod", StringUtil.LTrimStr( (decimal)(A192ImpVendCod), 6, 0));
            Z191ImpItem = A191ImpItem;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2L89( ) ;
            if ( AnyError == 1 )
            {
               RcdFound89 = 0;
               InitializeNonKey2L89( ) ;
            }
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound89 = 0;
            InitializeNonKey2L89( ) ;
            sMode89 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode89;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2L89( ) ;
         if ( RcdFound89 == 0 )
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
         RcdFound89 = 0;
         /* Using cursor T002L16 */
         pr_default.execute(14, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T002L16_A191ImpItem[0] < A191ImpItem ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T002L16_A191ImpItem[0] > A191ImpItem ) ) )
            {
               A191ImpItem = T002L16_A191ImpItem[0];
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
               RcdFound89 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound89 = 0;
         /* Using cursor T002L17 */
         pr_default.execute(15, new Object[] {A191ImpItem});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T002L17_A191ImpItem[0] > A191ImpItem ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T002L17_A191ImpItem[0] < A191ImpItem ) ) )
            {
               A191ImpItem = T002L17_A191ImpItem[0];
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
               RcdFound89 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2L89( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2L89( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound89 == 1 )
            {
               if ( A191ImpItem != Z191ImpItem )
               {
                  A191ImpItem = Z191ImpItem;
                  AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "IMPITEM");
                  AnyError = 1;
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2L89( ) ;
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A191ImpItem != Z191ImpItem )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtImpItem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2L89( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IMPITEM");
                     AnyError = 1;
                     GX_FocusControl = edtImpItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtImpItem_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2L89( ) ;
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
         if ( A191ImpItem != Z191ImpItem )
         {
            A191ImpItem = Z191ImpItem;
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtImpItem_Internalname;
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
         GetKey2L89( ) ;
         if ( RcdFound89 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "IMPITEM");
               AnyError = 1;
               GX_FocusControl = edtImpItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A191ImpItem != Z191ImpItem )
            {
               A191ImpItem = Z191ImpItem;
               AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "IMPITEM");
               AnyError = 1;
               GX_FocusControl = edtImpItem_Internalname;
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
            if ( A191ImpItem != Z191ImpItem )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "IMPITEM");
                  AnyError = 1;
                  GX_FocusControl = edtImpItem_Internalname;
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
         context.RollbackDataStores("cldocumentos",pr_default);
         GX_FocusControl = edtImpTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2L0( ) ;
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
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "IMPITEM");
            AnyError = 1;
            GX_FocusControl = edtImpItem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtImpTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2L89( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2L89( ) ;
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
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpTipCod_Internalname;
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
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpTipCod_Internalname;
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
         ScanStart2L89( ) ;
         if ( RcdFound89 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound89 != 0 )
            {
               ScanNext2L89( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtImpTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2L89( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2L89( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002L2 */
            pr_default.execute(0, new Object[] {A191ImpItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLDOCUMENTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1046ImpTipCod, T002L2_A1046ImpTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1030ImpDocNum, T002L2_A1030ImpDocNum[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1034ImpFec ) != DateTimeUtil.ResetTime ( T002L2_A1034ImpFec[0] ) ) || ( DateTimeUtil.ResetTime ( Z1037ImpFecVcto ) != DateTimeUtil.ResetTime ( T002L2_A1037ImpFecVcto[0] ) ) || ( StringUtil.StrCmp(Z1021ImpCliDsc, T002L2_A1021ImpCliDsc[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1048ImpTLis != T002L2_A1048ImpTLis[0] ) || ( Z1040ImpPorDscto != T002L2_A1040ImpPorDscto[0] ) || ( Z1041ImpPorIVA != T002L2_A1041ImpPorIVA[0] ) || ( StringUtil.StrCmp(Z1050ImpTRef, T002L2_A1050ImpTRef[0]) != 0 ) || ( StringUtil.StrCmp(Z1043ImpRef, T002L2_A1043ImpRef[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1044ImpSts, T002L2_A1044ImpSts[0]) != 0 ) || ( Z1047ImpTItem != T002L2_A1047ImpTItem[0] ) || ( DateTimeUtil.ResetTime ( Z1036ImpFecRef ) != DateTimeUtil.ResetTime ( T002L2_A1036ImpFecRef[0] ) ) || ( Z1016ImpAlmCod != T002L2_A1016ImpAlmCod[0] ) || ( Z1020ImpCliDirCod != T002L2_A1020ImpCliDirCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1038ImpForCod != T002L2_A1038ImpForCod[0] ) || ( Z1017ImpBanCod != T002L2_A1017ImpBanCod[0] ) || ( StringUtil.StrCmp(Z1022ImpCobCod, T002L2_A1022ImpCobCod[0]) != 0 ) || ( Z1018ImpCliDespacho != T002L2_A1018ImpCliDespacho[0] ) || ( Z1035ImpFecAten != T002L2_A1035ImpFecAten[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1049ImpTPedCod != T002L2_A1049ImpTPedCod[0] ) || ( Z1045ImpTieCod != T002L2_A1045ImpTieCod[0] ) || ( StringUtil.StrCmp(Z196ImpCliCod, T002L2_A196ImpCliCod[0]) != 0 ) || ( Z195ImpMonCod != T002L2_A195ImpMonCod[0] ) || ( Z194ImpConpCod != T002L2_A194ImpConpCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z193ImpMovCod != T002L2_A193ImpMovCod[0] ) || ( Z192ImpVendCod != T002L2_A192ImpVendCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z1046ImpTipCod, T002L2_A1046ImpTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z1046ImpTipCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1046ImpTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z1030ImpDocNum, T002L2_A1030ImpDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z1030ImpDocNum);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1030ImpDocNum[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1034ImpFec ) != DateTimeUtil.ResetTime ( T002L2_A1034ImpFec[0] ) )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpFec");
                  GXUtil.WriteLogRaw("Old: ",Z1034ImpFec);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1034ImpFec[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1037ImpFecVcto ) != DateTimeUtil.ResetTime ( T002L2_A1037ImpFecVcto[0] ) )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpFecVcto");
                  GXUtil.WriteLogRaw("Old: ",Z1037ImpFecVcto);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1037ImpFecVcto[0]);
               }
               if ( StringUtil.StrCmp(Z1021ImpCliDsc, T002L2_A1021ImpCliDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpCliDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1021ImpCliDsc);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1021ImpCliDsc[0]);
               }
               if ( Z1048ImpTLis != T002L2_A1048ImpTLis[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpTLis");
                  GXUtil.WriteLogRaw("Old: ",Z1048ImpTLis);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1048ImpTLis[0]);
               }
               if ( Z1040ImpPorDscto != T002L2_A1040ImpPorDscto[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpPorDscto");
                  GXUtil.WriteLogRaw("Old: ",Z1040ImpPorDscto);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1040ImpPorDscto[0]);
               }
               if ( Z1041ImpPorIVA != T002L2_A1041ImpPorIVA[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpPorIVA");
                  GXUtil.WriteLogRaw("Old: ",Z1041ImpPorIVA);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1041ImpPorIVA[0]);
               }
               if ( StringUtil.StrCmp(Z1050ImpTRef, T002L2_A1050ImpTRef[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpTRef");
                  GXUtil.WriteLogRaw("Old: ",Z1050ImpTRef);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1050ImpTRef[0]);
               }
               if ( StringUtil.StrCmp(Z1043ImpRef, T002L2_A1043ImpRef[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpRef");
                  GXUtil.WriteLogRaw("Old: ",Z1043ImpRef);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1043ImpRef[0]);
               }
               if ( StringUtil.StrCmp(Z1044ImpSts, T002L2_A1044ImpSts[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpSts");
                  GXUtil.WriteLogRaw("Old: ",Z1044ImpSts);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1044ImpSts[0]);
               }
               if ( Z1047ImpTItem != T002L2_A1047ImpTItem[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpTItem");
                  GXUtil.WriteLogRaw("Old: ",Z1047ImpTItem);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1047ImpTItem[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1036ImpFecRef ) != DateTimeUtil.ResetTime ( T002L2_A1036ImpFecRef[0] ) )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpFecRef");
                  GXUtil.WriteLogRaw("Old: ",Z1036ImpFecRef);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1036ImpFecRef[0]);
               }
               if ( Z1016ImpAlmCod != T002L2_A1016ImpAlmCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpAlmCod");
                  GXUtil.WriteLogRaw("Old: ",Z1016ImpAlmCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1016ImpAlmCod[0]);
               }
               if ( Z1020ImpCliDirCod != T002L2_A1020ImpCliDirCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpCliDirCod");
                  GXUtil.WriteLogRaw("Old: ",Z1020ImpCliDirCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1020ImpCliDirCod[0]);
               }
               if ( Z1038ImpForCod != T002L2_A1038ImpForCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpForCod");
                  GXUtil.WriteLogRaw("Old: ",Z1038ImpForCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1038ImpForCod[0]);
               }
               if ( Z1017ImpBanCod != T002L2_A1017ImpBanCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z1017ImpBanCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1017ImpBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z1022ImpCobCod, T002L2_A1022ImpCobCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpCobCod");
                  GXUtil.WriteLogRaw("Old: ",Z1022ImpCobCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1022ImpCobCod[0]);
               }
               if ( Z1018ImpCliDespacho != T002L2_A1018ImpCliDespacho[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpCliDespacho");
                  GXUtil.WriteLogRaw("Old: ",Z1018ImpCliDespacho);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1018ImpCliDespacho[0]);
               }
               if ( Z1035ImpFecAten != T002L2_A1035ImpFecAten[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpFecAten");
                  GXUtil.WriteLogRaw("Old: ",Z1035ImpFecAten);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1035ImpFecAten[0]);
               }
               if ( Z1049ImpTPedCod != T002L2_A1049ImpTPedCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpTPedCod");
                  GXUtil.WriteLogRaw("Old: ",Z1049ImpTPedCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1049ImpTPedCod[0]);
               }
               if ( Z1045ImpTieCod != T002L2_A1045ImpTieCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpTieCod");
                  GXUtil.WriteLogRaw("Old: ",Z1045ImpTieCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A1045ImpTieCod[0]);
               }
               if ( StringUtil.StrCmp(Z196ImpCliCod, T002L2_A196ImpCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z196ImpCliCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A196ImpCliCod[0]);
               }
               if ( Z195ImpMonCod != T002L2_A195ImpMonCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z195ImpMonCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A195ImpMonCod[0]);
               }
               if ( Z194ImpConpCod != T002L2_A194ImpConpCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpConpCod");
                  GXUtil.WriteLogRaw("Old: ",Z194ImpConpCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A194ImpConpCod[0]);
               }
               if ( Z193ImpMovCod != T002L2_A193ImpMovCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpMovCod");
                  GXUtil.WriteLogRaw("Old: ",Z193ImpMovCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A193ImpMovCod[0]);
               }
               if ( Z192ImpVendCod != T002L2_A192ImpVendCod[0] )
               {
                  GXUtil.WriteLog("cldocumentos:[seudo value changed for attri]"+"ImpVendCod");
                  GXUtil.WriteLogRaw("Old: ",Z192ImpVendCod);
                  GXUtil.WriteLogRaw("Current: ",T002L2_A192ImpVendCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLDOCUMENTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2L89( )
      {
         BeforeValidate2L89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L89( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2L89( 0) ;
            CheckOptimisticConcurrency2L89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2L89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002L18 */
                     pr_default.execute(16, new Object[] {A191ImpItem, A1046ImpTipCod, A1030ImpDocNum, A1034ImpFec, A1037ImpFecVcto, A1021ImpCliDsc, A1048ImpTLis, A1040ImpPorDscto, A1041ImpPorIVA, A1039ImpObs, A1050ImpTRef, A1043ImpRef, A1044ImpSts, A1047ImpTItem, A1036ImpFecRef, A1016ImpAlmCod, A1020ImpCliDirCod, A1038ImpForCod, A1017ImpBanCod, A1022ImpCobCod, A1018ImpCliDespacho, n1035ImpFecAten, A1035ImpFecAten, A1049ImpTPedCod, A1045ImpTieCod, A196ImpCliCod, A195ImpMonCod, A194ImpConpCod, A193ImpMovCod, A192ImpVendCod});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CLDOCUMENTOS");
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
                           ResetCaption2L0( ) ;
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
               Load2L89( ) ;
            }
            EndLevel2L89( ) ;
         }
         CloseExtendedTableCursors2L89( ) ;
      }

      protected void Update2L89( )
      {
         BeforeValidate2L89( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2L89( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L89( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2L89( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2L89( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002L19 */
                     pr_default.execute(17, new Object[] {A1046ImpTipCod, A1030ImpDocNum, A1034ImpFec, A1037ImpFecVcto, A1021ImpCliDsc, A1048ImpTLis, A1040ImpPorDscto, A1041ImpPorIVA, A1039ImpObs, A1050ImpTRef, A1043ImpRef, A1044ImpSts, A1047ImpTItem, A1036ImpFecRef, A1016ImpAlmCod, A1020ImpCliDirCod, A1038ImpForCod, A1017ImpBanCod, A1022ImpCobCod, A1018ImpCliDespacho, n1035ImpFecAten, A1035ImpFecAten, A1049ImpTPedCod, A1045ImpTieCod, A196ImpCliCod, A195ImpMonCod, A194ImpConpCod, A193ImpMovCod, A192ImpVendCod, A191ImpItem});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CLDOCUMENTOS");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLDOCUMENTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2L89( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2L0( ) ;
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
            EndLevel2L89( ) ;
         }
         CloseExtendedTableCursors2L89( ) ;
      }

      protected void DeferredUpdate2L89( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2L89( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2L89( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2L89( ) ;
            AfterConfirm2L89( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2L89( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002L20 */
                  pr_default.execute(18, new Object[] {A191ImpItem});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CLDOCUMENTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound89 == 0 )
                        {
                           InitAll2L89( ) ;
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
                        ResetCaption2L0( ) ;
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
         sMode89 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2L89( ) ;
         Gx_mode = sMode89;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2L89( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002L21 */
            pr_default.execute(19, new Object[] {A194ImpConpCod});
            A1024ImpConpDsc = T002L21_A1024ImpConpDsc[0];
            AssignAttri("", false, "A1024ImpConpDsc", A1024ImpConpDsc);
            A1023ImpConpDias = T002L21_A1023ImpConpDias[0];
            AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrimStr( (decimal)(A1023ImpConpDias), 4, 0));
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002L22 */
            pr_default.execute(20, new Object[] {A191ImpItem});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel2L89( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2L89( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            context.CommitDataStores("cldocumentos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            context.RollbackDataStores("cldocumentos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2L89( )
      {
         /* Using cursor T002L23 */
         pr_default.execute(21);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound89 = 1;
            A191ImpItem = T002L23_A191ImpItem[0];
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2L89( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound89 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound89 = 1;
            A191ImpItem = T002L23_A191ImpItem[0];
            AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
         }
      }

      protected void ScanEnd2L89( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm2L89( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2L89( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2L89( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2L89( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2L89( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2L89( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2L89( )
      {
         edtImpItem_Enabled = 0;
         AssignProp("", false, edtImpItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpItem_Enabled), 5, 0), true);
         edtImpTipCod_Enabled = 0;
         AssignProp("", false, edtImpTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpTipCod_Enabled), 5, 0), true);
         edtImpDocNum_Enabled = 0;
         AssignProp("", false, edtImpDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpDocNum_Enabled), 5, 0), true);
         edtImpFec_Enabled = 0;
         AssignProp("", false, edtImpFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpFec_Enabled), 5, 0), true);
         edtImpFecVcto_Enabled = 0;
         AssignProp("", false, edtImpFecVcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpFecVcto_Enabled), 5, 0), true);
         edtImpCliCod_Enabled = 0;
         AssignProp("", false, edtImpCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpCliCod_Enabled), 5, 0), true);
         edtImpCliDsc_Enabled = 0;
         AssignProp("", false, edtImpCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpCliDsc_Enabled), 5, 0), true);
         edtImpMonCod_Enabled = 0;
         AssignProp("", false, edtImpMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpMonCod_Enabled), 5, 0), true);
         edtImpConpCod_Enabled = 0;
         AssignProp("", false, edtImpConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpConpCod_Enabled), 5, 0), true);
         edtImpConpDsc_Enabled = 0;
         AssignProp("", false, edtImpConpDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpConpDsc_Enabled), 5, 0), true);
         edtImpConpDias_Enabled = 0;
         AssignProp("", false, edtImpConpDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpConpDias_Enabled), 5, 0), true);
         edtImpTLis_Enabled = 0;
         AssignProp("", false, edtImpTLis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpTLis_Enabled), 5, 0), true);
         edtImpPorDscto_Enabled = 0;
         AssignProp("", false, edtImpPorDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPorDscto_Enabled), 5, 0), true);
         edtImpPorIVA_Enabled = 0;
         AssignProp("", false, edtImpPorIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpPorIVA_Enabled), 5, 0), true);
         edtImpObs_Enabled = 0;
         AssignProp("", false, edtImpObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpObs_Enabled), 5, 0), true);
         edtImpTRef_Enabled = 0;
         AssignProp("", false, edtImpTRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpTRef_Enabled), 5, 0), true);
         edtImpRef_Enabled = 0;
         AssignProp("", false, edtImpRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpRef_Enabled), 5, 0), true);
         edtImpSts_Enabled = 0;
         AssignProp("", false, edtImpSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpSts_Enabled), 5, 0), true);
         edtImpTItem_Enabled = 0;
         AssignProp("", false, edtImpTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpTItem_Enabled), 5, 0), true);
         edtImpFecRef_Enabled = 0;
         AssignProp("", false, edtImpFecRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpFecRef_Enabled), 5, 0), true);
         edtImpMovCod_Enabled = 0;
         AssignProp("", false, edtImpMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpMovCod_Enabled), 5, 0), true);
         edtImpAlmCod_Enabled = 0;
         AssignProp("", false, edtImpAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpAlmCod_Enabled), 5, 0), true);
         edtImpCliDirCod_Enabled = 0;
         AssignProp("", false, edtImpCliDirCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpCliDirCod_Enabled), 5, 0), true);
         edtImpVendCod_Enabled = 0;
         AssignProp("", false, edtImpVendCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpVendCod_Enabled), 5, 0), true);
         edtImpForCod_Enabled = 0;
         AssignProp("", false, edtImpForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpForCod_Enabled), 5, 0), true);
         edtImpBanCod_Enabled = 0;
         AssignProp("", false, edtImpBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpBanCod_Enabled), 5, 0), true);
         edtImpCobCod_Enabled = 0;
         AssignProp("", false, edtImpCobCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpCobCod_Enabled), 5, 0), true);
         edtImpCliDespacho_Enabled = 0;
         AssignProp("", false, edtImpCliDespacho_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpCliDespacho_Enabled), 5, 0), true);
         edtImpFecAten_Enabled = 0;
         AssignProp("", false, edtImpFecAten_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpFecAten_Enabled), 5, 0), true);
         edtImpTPedCod_Enabled = 0;
         AssignProp("", false, edtImpTPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtImpTPedCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2L89( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816425273", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cldocumentos.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CLDOCUMENTOS");
         forbiddenHiddens.Add("ImpTieCod", context.localUtil.Format( (decimal)(A1045ImpTieCod), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cldocumentos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z191ImpItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z191ImpItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1046ImpTipCod", StringUtil.RTrim( Z1046ImpTipCod));
         GxWebStd.gx_hidden_field( context, "Z1030ImpDocNum", StringUtil.RTrim( Z1030ImpDocNum));
         GxWebStd.gx_hidden_field( context, "Z1034ImpFec", context.localUtil.DToC( Z1034ImpFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1037ImpFecVcto", context.localUtil.DToC( Z1037ImpFecVcto, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1021ImpCliDsc", StringUtil.RTrim( Z1021ImpCliDsc));
         GxWebStd.gx_hidden_field( context, "Z1048ImpTLis", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1048ImpTLis), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1040ImpPorDscto", StringUtil.LTrim( StringUtil.NToC( Z1040ImpPorDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1041ImpPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1041ImpPorIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1050ImpTRef", StringUtil.RTrim( Z1050ImpTRef));
         GxWebStd.gx_hidden_field( context, "Z1043ImpRef", StringUtil.RTrim( Z1043ImpRef));
         GxWebStd.gx_hidden_field( context, "Z1044ImpSts", StringUtil.RTrim( Z1044ImpSts));
         GxWebStd.gx_hidden_field( context, "Z1047ImpTItem", StringUtil.LTrim( StringUtil.NToC( Z1047ImpTItem, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1036ImpFecRef", context.localUtil.DToC( Z1036ImpFecRef, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1016ImpAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1016ImpAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1020ImpCliDirCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1020ImpCliDirCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1038ImpForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1038ImpForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1017ImpBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1017ImpBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1022ImpCobCod", StringUtil.RTrim( Z1022ImpCobCod));
         GxWebStd.gx_hidden_field( context, "Z1018ImpCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1018ImpCliDespacho), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1035ImpFecAten", context.localUtil.TToC( Z1035ImpFecAten, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1049ImpTPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1049ImpTPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1045ImpTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1045ImpTieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z196ImpCliCod", StringUtil.RTrim( Z196ImpCliCod));
         GxWebStd.gx_hidden_field( context, "Z195ImpMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z195ImpMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z194ImpConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z194ImpConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z193ImpMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z193ImpMovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z192ImpVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z192ImpVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "IMPTIECOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1045ImpTieCod), 6, 0, ".", "")));
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
         return formatLink("cldocumentos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLDOCUMENTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documentos Afectos IGV - Cabecera" ;
      }

      protected void InitializeNonKey2L89( )
      {
         A1046ImpTipCod = "";
         AssignAttri("", false, "A1046ImpTipCod", A1046ImpTipCod);
         A1030ImpDocNum = "";
         AssignAttri("", false, "A1030ImpDocNum", A1030ImpDocNum);
         A1034ImpFec = DateTime.MinValue;
         AssignAttri("", false, "A1034ImpFec", context.localUtil.Format(A1034ImpFec, "99/99/99"));
         A1037ImpFecVcto = DateTime.MinValue;
         AssignAttri("", false, "A1037ImpFecVcto", context.localUtil.Format(A1037ImpFecVcto, "99/99/99"));
         A196ImpCliCod = "";
         AssignAttri("", false, "A196ImpCliCod", A196ImpCliCod);
         A1021ImpCliDsc = "";
         AssignAttri("", false, "A1021ImpCliDsc", A1021ImpCliDsc);
         A195ImpMonCod = 0;
         AssignAttri("", false, "A195ImpMonCod", StringUtil.LTrimStr( (decimal)(A195ImpMonCod), 6, 0));
         A194ImpConpCod = 0;
         AssignAttri("", false, "A194ImpConpCod", StringUtil.LTrimStr( (decimal)(A194ImpConpCod), 6, 0));
         A1024ImpConpDsc = "";
         AssignAttri("", false, "A1024ImpConpDsc", A1024ImpConpDsc);
         A1023ImpConpDias = 0;
         AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrimStr( (decimal)(A1023ImpConpDias), 4, 0));
         A1048ImpTLis = 0;
         AssignAttri("", false, "A1048ImpTLis", StringUtil.LTrimStr( (decimal)(A1048ImpTLis), 6, 0));
         A1040ImpPorDscto = 0;
         AssignAttri("", false, "A1040ImpPorDscto", StringUtil.LTrimStr( A1040ImpPorDscto, 15, 2));
         A1041ImpPorIVA = 0;
         AssignAttri("", false, "A1041ImpPorIVA", StringUtil.LTrimStr( A1041ImpPorIVA, 15, 2));
         A1039ImpObs = "";
         AssignAttri("", false, "A1039ImpObs", A1039ImpObs);
         A1050ImpTRef = "";
         AssignAttri("", false, "A1050ImpTRef", A1050ImpTRef);
         A1043ImpRef = "";
         AssignAttri("", false, "A1043ImpRef", A1043ImpRef);
         A1044ImpSts = "";
         AssignAttri("", false, "A1044ImpSts", A1044ImpSts);
         A1047ImpTItem = 0;
         AssignAttri("", false, "A1047ImpTItem", StringUtil.LTrimStr( A1047ImpTItem, 15, 2));
         A1036ImpFecRef = DateTime.MinValue;
         AssignAttri("", false, "A1036ImpFecRef", context.localUtil.Format(A1036ImpFecRef, "99/99/99"));
         A193ImpMovCod = 0;
         AssignAttri("", false, "A193ImpMovCod", StringUtil.LTrimStr( (decimal)(A193ImpMovCod), 6, 0));
         A1016ImpAlmCod = 0;
         AssignAttri("", false, "A1016ImpAlmCod", StringUtil.LTrimStr( (decimal)(A1016ImpAlmCod), 6, 0));
         A1020ImpCliDirCod = 0;
         AssignAttri("", false, "A1020ImpCliDirCod", StringUtil.LTrimStr( (decimal)(A1020ImpCliDirCod), 6, 0));
         A192ImpVendCod = 0;
         AssignAttri("", false, "A192ImpVendCod", StringUtil.LTrimStr( (decimal)(A192ImpVendCod), 6, 0));
         A1038ImpForCod = 0;
         AssignAttri("", false, "A1038ImpForCod", StringUtil.LTrimStr( (decimal)(A1038ImpForCod), 6, 0));
         A1017ImpBanCod = 0;
         AssignAttri("", false, "A1017ImpBanCod", StringUtil.LTrimStr( (decimal)(A1017ImpBanCod), 6, 0));
         A1022ImpCobCod = "";
         AssignAttri("", false, "A1022ImpCobCod", A1022ImpCobCod);
         A1018ImpCliDespacho = 0;
         AssignAttri("", false, "A1018ImpCliDespacho", StringUtil.LTrimStr( (decimal)(A1018ImpCliDespacho), 6, 0));
         A1035ImpFecAten = (DateTime)(DateTime.MinValue);
         n1035ImpFecAten = false;
         AssignAttri("", false, "A1035ImpFecAten", context.localUtil.TToC( A1035ImpFecAten, 8, 5, 0, 3, "/", ":", " "));
         A1049ImpTPedCod = 0;
         AssignAttri("", false, "A1049ImpTPedCod", StringUtil.LTrimStr( (decimal)(A1049ImpTPedCod), 6, 0));
         A1045ImpTieCod = 0;
         AssignAttri("", false, "A1045ImpTieCod", StringUtil.LTrimStr( (decimal)(A1045ImpTieCod), 6, 0));
         Z1046ImpTipCod = "";
         Z1030ImpDocNum = "";
         Z1034ImpFec = DateTime.MinValue;
         Z1037ImpFecVcto = DateTime.MinValue;
         Z1021ImpCliDsc = "";
         Z1048ImpTLis = 0;
         Z1040ImpPorDscto = 0;
         Z1041ImpPorIVA = 0;
         Z1050ImpTRef = "";
         Z1043ImpRef = "";
         Z1044ImpSts = "";
         Z1047ImpTItem = 0;
         Z1036ImpFecRef = DateTime.MinValue;
         Z1016ImpAlmCod = 0;
         Z1020ImpCliDirCod = 0;
         Z1038ImpForCod = 0;
         Z1017ImpBanCod = 0;
         Z1022ImpCobCod = "";
         Z1018ImpCliDespacho = 0;
         Z1035ImpFecAten = (DateTime)(DateTime.MinValue);
         Z1049ImpTPedCod = 0;
         Z1045ImpTieCod = 0;
         Z196ImpCliCod = "";
         Z195ImpMonCod = 0;
         Z194ImpConpCod = 0;
         Z193ImpMovCod = 0;
         Z192ImpVendCod = 0;
      }

      protected void InitAll2L89( )
      {
         A191ImpItem = 0;
         AssignAttri("", false, "A191ImpItem", StringUtil.LTrimStr( (decimal)(A191ImpItem), 10, 0));
         InitializeNonKey2L89( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816425299", true, true);
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
         context.AddJavascriptSource("cldocumentos.js", "?20228181642530", false, true);
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
         edtImpItem_Internalname = "IMPITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtImpTipCod_Internalname = "IMPTIPCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtImpDocNum_Internalname = "IMPDOCNUM";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtImpFec_Internalname = "IMPFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtImpFecVcto_Internalname = "IMPFECVCTO";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtImpCliCod_Internalname = "IMPCLICOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtImpCliDsc_Internalname = "IMPCLIDSC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtImpMonCod_Internalname = "IMPMONCOD";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtImpConpCod_Internalname = "IMPCONPCOD";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtImpConpDsc_Internalname = "IMPCONPDSC";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtImpConpDias_Internalname = "IMPCONPDIAS";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtImpTLis_Internalname = "IMPTLIS";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtImpPorDscto_Internalname = "IMPPORDSCTO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtImpPorIVA_Internalname = "IMPPORIVA";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtImpObs_Internalname = "IMPOBS";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtImpTRef_Internalname = "IMPTREF";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtImpRef_Internalname = "IMPREF";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtImpSts_Internalname = "IMPSTS";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtImpTItem_Internalname = "IMPTITEM";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtImpFecRef_Internalname = "IMPFECREF";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtImpMovCod_Internalname = "IMPMOVCOD";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtImpAlmCod_Internalname = "IMPALMCOD";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtImpCliDirCod_Internalname = "IMPCLIDIRCOD";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtImpVendCod_Internalname = "IMPVENDCOD";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtImpForCod_Internalname = "IMPFORCOD";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtImpBanCod_Internalname = "IMPBANCOD";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtImpCobCod_Internalname = "IMPCOBCOD";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtImpCliDespacho_Internalname = "IMPCLIDESPACHO";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtImpFecAten_Internalname = "IMPFECATEN";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtImpTPedCod_Internalname = "IMPTPEDCOD";
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
         Form.Caption = "Documentos Afectos IGV - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtImpTPedCod_Jsonclick = "";
         edtImpTPedCod_Enabled = 1;
         edtImpFecAten_Jsonclick = "";
         edtImpFecAten_Enabled = 1;
         edtImpCliDespacho_Jsonclick = "";
         edtImpCliDespacho_Enabled = 1;
         edtImpCobCod_Jsonclick = "";
         edtImpCobCod_Enabled = 1;
         edtImpBanCod_Jsonclick = "";
         edtImpBanCod_Enabled = 1;
         edtImpForCod_Jsonclick = "";
         edtImpForCod_Enabled = 1;
         edtImpVendCod_Jsonclick = "";
         edtImpVendCod_Enabled = 1;
         edtImpCliDirCod_Jsonclick = "";
         edtImpCliDirCod_Enabled = 1;
         edtImpAlmCod_Jsonclick = "";
         edtImpAlmCod_Enabled = 1;
         edtImpMovCod_Jsonclick = "";
         edtImpMovCod_Enabled = 1;
         edtImpFecRef_Jsonclick = "";
         edtImpFecRef_Enabled = 1;
         edtImpTItem_Jsonclick = "";
         edtImpTItem_Enabled = 1;
         edtImpSts_Jsonclick = "";
         edtImpSts_Enabled = 1;
         edtImpRef_Jsonclick = "";
         edtImpRef_Enabled = 1;
         edtImpTRef_Jsonclick = "";
         edtImpTRef_Enabled = 1;
         edtImpObs_Enabled = 1;
         edtImpPorIVA_Jsonclick = "";
         edtImpPorIVA_Enabled = 1;
         edtImpPorDscto_Jsonclick = "";
         edtImpPorDscto_Enabled = 1;
         edtImpTLis_Jsonclick = "";
         edtImpTLis_Enabled = 1;
         edtImpConpDias_Jsonclick = "";
         edtImpConpDias_Enabled = 0;
         edtImpConpDsc_Jsonclick = "";
         edtImpConpDsc_Enabled = 0;
         edtImpConpCod_Jsonclick = "";
         edtImpConpCod_Enabled = 1;
         edtImpMonCod_Jsonclick = "";
         edtImpMonCod_Enabled = 1;
         edtImpCliDsc_Jsonclick = "";
         edtImpCliDsc_Enabled = 1;
         edtImpCliCod_Jsonclick = "";
         edtImpCliCod_Enabled = 1;
         edtImpFecVcto_Jsonclick = "";
         edtImpFecVcto_Enabled = 1;
         edtImpFec_Jsonclick = "";
         edtImpFec_Enabled = 1;
         edtImpDocNum_Jsonclick = "";
         edtImpDocNum_Enabled = 1;
         edtImpTipCod_Jsonclick = "";
         edtImpTipCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtImpItem_Jsonclick = "";
         edtImpItem_Enabled = 1;
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
         GX_FocusControl = edtImpTipCod_Internalname;
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

      public void Valid_Impitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1046ImpTipCod", StringUtil.RTrim( A1046ImpTipCod));
         AssignAttri("", false, "A1030ImpDocNum", StringUtil.RTrim( A1030ImpDocNum));
         AssignAttri("", false, "A1034ImpFec", context.localUtil.Format(A1034ImpFec, "99/99/99"));
         AssignAttri("", false, "A1037ImpFecVcto", context.localUtil.Format(A1037ImpFecVcto, "99/99/99"));
         AssignAttri("", false, "A196ImpCliCod", StringUtil.RTrim( A196ImpCliCod));
         AssignAttri("", false, "A1021ImpCliDsc", StringUtil.RTrim( A1021ImpCliDsc));
         AssignAttri("", false, "A195ImpMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A195ImpMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A194ImpConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A194ImpConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1048ImpTLis", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1048ImpTLis), 6, 0, ".", "")));
         AssignAttri("", false, "A1040ImpPorDscto", StringUtil.LTrim( StringUtil.NToC( A1040ImpPorDscto, 15, 2, ".", "")));
         AssignAttri("", false, "A1041ImpPorIVA", StringUtil.LTrim( StringUtil.NToC( A1041ImpPorIVA, 15, 2, ".", "")));
         AssignAttri("", false, "A1039ImpObs", A1039ImpObs);
         AssignAttri("", false, "A1050ImpTRef", StringUtil.RTrim( A1050ImpTRef));
         AssignAttri("", false, "A1043ImpRef", StringUtil.RTrim( A1043ImpRef));
         AssignAttri("", false, "A1044ImpSts", StringUtil.RTrim( A1044ImpSts));
         AssignAttri("", false, "A1047ImpTItem", StringUtil.LTrim( StringUtil.NToC( A1047ImpTItem, 15, 2, ".", "")));
         AssignAttri("", false, "A1036ImpFecRef", context.localUtil.Format(A1036ImpFecRef, "99/99/99"));
         AssignAttri("", false, "A193ImpMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A193ImpMovCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1016ImpAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1016ImpAlmCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1020ImpCliDirCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1020ImpCliDirCod), 6, 0, ".", "")));
         AssignAttri("", false, "A192ImpVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A192ImpVendCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1038ImpForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1038ImpForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1017ImpBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1017ImpBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1022ImpCobCod", StringUtil.RTrim( A1022ImpCobCod));
         AssignAttri("", false, "A1018ImpCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1018ImpCliDespacho), 6, 0, ".", "")));
         AssignAttri("", false, "A1035ImpFecAten", context.localUtil.TToC( A1035ImpFecAten, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1049ImpTPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1049ImpTPedCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1045ImpTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1045ImpTieCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1024ImpConpDsc", StringUtil.RTrim( A1024ImpConpDsc));
         AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1023ImpConpDias), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z191ImpItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z191ImpItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1046ImpTipCod", StringUtil.RTrim( Z1046ImpTipCod));
         GxWebStd.gx_hidden_field( context, "Z1030ImpDocNum", StringUtil.RTrim( Z1030ImpDocNum));
         GxWebStd.gx_hidden_field( context, "Z1034ImpFec", context.localUtil.Format(Z1034ImpFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1037ImpFecVcto", context.localUtil.Format(Z1037ImpFecVcto, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z196ImpCliCod", StringUtil.RTrim( Z196ImpCliCod));
         GxWebStd.gx_hidden_field( context, "Z1021ImpCliDsc", StringUtil.RTrim( Z1021ImpCliDsc));
         GxWebStd.gx_hidden_field( context, "Z195ImpMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z195ImpMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z194ImpConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z194ImpConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1048ImpTLis", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1048ImpTLis), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1040ImpPorDscto", StringUtil.LTrim( StringUtil.NToC( Z1040ImpPorDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1041ImpPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1041ImpPorIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1039ImpObs", Z1039ImpObs);
         GxWebStd.gx_hidden_field( context, "Z1050ImpTRef", StringUtil.RTrim( Z1050ImpTRef));
         GxWebStd.gx_hidden_field( context, "Z1043ImpRef", StringUtil.RTrim( Z1043ImpRef));
         GxWebStd.gx_hidden_field( context, "Z1044ImpSts", StringUtil.RTrim( Z1044ImpSts));
         GxWebStd.gx_hidden_field( context, "Z1047ImpTItem", StringUtil.LTrim( StringUtil.NToC( Z1047ImpTItem, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1036ImpFecRef", context.localUtil.Format(Z1036ImpFecRef, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z193ImpMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z193ImpMovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1016ImpAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1016ImpAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1020ImpCliDirCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1020ImpCliDirCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z192ImpVendCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z192ImpVendCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1038ImpForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1038ImpForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1017ImpBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1017ImpBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1022ImpCobCod", StringUtil.RTrim( Z1022ImpCobCod));
         GxWebStd.gx_hidden_field( context, "Z1018ImpCliDespacho", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1018ImpCliDespacho), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1035ImpFecAten", context.localUtil.TToC( Z1035ImpFecAten, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1049ImpTPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1049ImpTPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1045ImpTieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1045ImpTieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1024ImpConpDsc", StringUtil.RTrim( Z1024ImpConpDsc));
         GxWebStd.gx_hidden_field( context, "Z1023ImpConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1023ImpConpDias), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Impclicod( )
      {
         /* Using cursor T002L24 */
         pr_default.execute(22, new Object[] {A196ImpCliCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "IMPCLICOD");
            AnyError = 1;
            GX_FocusControl = edtImpCliCod_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Impmoncod( )
      {
         /* Using cursor T002L25 */
         pr_default.execute(23, new Object[] {A195ImpMonCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "IMPMONCOD");
            AnyError = 1;
            GX_FocusControl = edtImpMonCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Impconpcod( )
      {
         /* Using cursor T002L21 */
         pr_default.execute(19, new Object[] {A194ImpConpCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Condición de Pago'.", "ForeignKeyNotFound", 1, "IMPCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtImpConpCod_Internalname;
         }
         A1024ImpConpDsc = T002L21_A1024ImpConpDsc[0];
         A1023ImpConpDias = T002L21_A1023ImpConpDias[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1024ImpConpDsc", StringUtil.RTrim( A1024ImpConpDsc));
         AssignAttri("", false, "A1023ImpConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1023ImpConpDias), 4, 0, ".", "")));
      }

      public void Valid_Impmovcod( )
      {
         /* Using cursor T002L26 */
         pr_default.execute(24, new Object[] {A193ImpMovCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento'.", "ForeignKeyNotFound", 1, "IMPMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtImpMovCod_Internalname;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Impvendcod( )
      {
         /* Using cursor T002L27 */
         pr_default.execute(25, new Object[] {A192ImpVendCod});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Vendedor'.", "ForeignKeyNotFound", 1, "IMPVENDCOD");
            AnyError = 1;
            GX_FocusControl = edtImpVendCod_Internalname;
         }
         pr_default.close(25);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1045ImpTieCod',fld:'IMPTIECOD',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_IMPITEM","{handler:'Valid_Impitem',iparms:[{av:'A1045ImpTieCod',fld:'IMPTIECOD',pic:'ZZZZZ9'},{av:'A191ImpItem',fld:'IMPITEM',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_IMPITEM",",oparms:[{av:'A1046ImpTipCod',fld:'IMPTIPCOD',pic:''},{av:'A1030ImpDocNum',fld:'IMPDOCNUM',pic:''},{av:'A1034ImpFec',fld:'IMPFEC',pic:''},{av:'A1037ImpFecVcto',fld:'IMPFECVCTO',pic:''},{av:'A196ImpCliCod',fld:'IMPCLICOD',pic:''},{av:'A1021ImpCliDsc',fld:'IMPCLIDSC',pic:''},{av:'A195ImpMonCod',fld:'IMPMONCOD',pic:'ZZZZZ9'},{av:'A194ImpConpCod',fld:'IMPCONPCOD',pic:'ZZZZZ9'},{av:'A1048ImpTLis',fld:'IMPTLIS',pic:'ZZZZZ9'},{av:'A1040ImpPorDscto',fld:'IMPPORDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1041ImpPorIVA',fld:'IMPPORIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1039ImpObs',fld:'IMPOBS',pic:''},{av:'A1050ImpTRef',fld:'IMPTREF',pic:''},{av:'A1043ImpRef',fld:'IMPREF',pic:''},{av:'A1044ImpSts',fld:'IMPSTS',pic:''},{av:'A1047ImpTItem',fld:'IMPTITEM',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1036ImpFecRef',fld:'IMPFECREF',pic:''},{av:'A193ImpMovCod',fld:'IMPMOVCOD',pic:'ZZZZZ9'},{av:'A1016ImpAlmCod',fld:'IMPALMCOD',pic:'ZZZZZ9'},{av:'A1020ImpCliDirCod',fld:'IMPCLIDIRCOD',pic:'ZZZZZ9'},{av:'A192ImpVendCod',fld:'IMPVENDCOD',pic:'ZZZZZ9'},{av:'A1038ImpForCod',fld:'IMPFORCOD',pic:'ZZZZZ9'},{av:'A1017ImpBanCod',fld:'IMPBANCOD',pic:'ZZZZZ9'},{av:'A1022ImpCobCod',fld:'IMPCOBCOD',pic:''},{av:'A1018ImpCliDespacho',fld:'IMPCLIDESPACHO',pic:'ZZZZZ9'},{av:'A1035ImpFecAten',fld:'IMPFECATEN',pic:'99/99/99 99:99'},{av:'A1049ImpTPedCod',fld:'IMPTPEDCOD',pic:'ZZZZZ9'},{av:'A1045ImpTieCod',fld:'IMPTIECOD',pic:'ZZZZZ9'},{av:'A1024ImpConpDsc',fld:'IMPCONPDSC',pic:''},{av:'A1023ImpConpDias',fld:'IMPCONPDIAS',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z191ImpItem'},{av:'Z1046ImpTipCod'},{av:'Z1030ImpDocNum'},{av:'Z1034ImpFec'},{av:'Z1037ImpFecVcto'},{av:'Z196ImpCliCod'},{av:'Z1021ImpCliDsc'},{av:'Z195ImpMonCod'},{av:'Z194ImpConpCod'},{av:'Z1048ImpTLis'},{av:'Z1040ImpPorDscto'},{av:'Z1041ImpPorIVA'},{av:'Z1039ImpObs'},{av:'Z1050ImpTRef'},{av:'Z1043ImpRef'},{av:'Z1044ImpSts'},{av:'Z1047ImpTItem'},{av:'Z1036ImpFecRef'},{av:'Z193ImpMovCod'},{av:'Z1016ImpAlmCod'},{av:'Z1020ImpCliDirCod'},{av:'Z192ImpVendCod'},{av:'Z1038ImpForCod'},{av:'Z1017ImpBanCod'},{av:'Z1022ImpCobCod'},{av:'Z1018ImpCliDespacho'},{av:'Z1035ImpFecAten'},{av:'Z1049ImpTPedCod'},{av:'Z1045ImpTieCod'},{av:'Z1024ImpConpDsc'},{av:'Z1023ImpConpDias'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_IMPFEC","{handler:'Valid_Impfec',iparms:[]");
         setEventMetadata("VALID_IMPFEC",",oparms:[]}");
         setEventMetadata("VALID_IMPFECVCTO","{handler:'Valid_Impfecvcto',iparms:[]");
         setEventMetadata("VALID_IMPFECVCTO",",oparms:[]}");
         setEventMetadata("VALID_IMPCLICOD","{handler:'Valid_Impclicod',iparms:[{av:'A196ImpCliCod',fld:'IMPCLICOD',pic:''}]");
         setEventMetadata("VALID_IMPCLICOD",",oparms:[]}");
         setEventMetadata("VALID_IMPMONCOD","{handler:'Valid_Impmoncod',iparms:[{av:'A195ImpMonCod',fld:'IMPMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_IMPMONCOD",",oparms:[]}");
         setEventMetadata("VALID_IMPCONPCOD","{handler:'Valid_Impconpcod',iparms:[{av:'A194ImpConpCod',fld:'IMPCONPCOD',pic:'ZZZZZ9'},{av:'A1024ImpConpDsc',fld:'IMPCONPDSC',pic:''},{av:'A1023ImpConpDias',fld:'IMPCONPDIAS',pic:'ZZZ9'}]");
         setEventMetadata("VALID_IMPCONPCOD",",oparms:[{av:'A1024ImpConpDsc',fld:'IMPCONPDSC',pic:''},{av:'A1023ImpConpDias',fld:'IMPCONPDIAS',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_IMPFECREF","{handler:'Valid_Impfecref',iparms:[]");
         setEventMetadata("VALID_IMPFECREF",",oparms:[]}");
         setEventMetadata("VALID_IMPMOVCOD","{handler:'Valid_Impmovcod',iparms:[{av:'A193ImpMovCod',fld:'IMPMOVCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_IMPMOVCOD",",oparms:[]}");
         setEventMetadata("VALID_IMPVENDCOD","{handler:'Valid_Impvendcod',iparms:[{av:'A192ImpVendCod',fld:'IMPVENDCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_IMPVENDCOD",",oparms:[]}");
         setEventMetadata("VALID_IMPFECATEN","{handler:'Valid_Impfecaten',iparms:[]");
         setEventMetadata("VALID_IMPFECATEN",",oparms:[]}");
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
         pr_default.close(23);
         pr_default.close(19);
         pr_default.close(24);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1046ImpTipCod = "";
         Z1030ImpDocNum = "";
         Z1034ImpFec = DateTime.MinValue;
         Z1037ImpFecVcto = DateTime.MinValue;
         Z1021ImpCliDsc = "";
         Z1050ImpTRef = "";
         Z1043ImpRef = "";
         Z1044ImpSts = "";
         Z1036ImpFecRef = DateTime.MinValue;
         Z1022ImpCobCod = "";
         Z1035ImpFecAten = (DateTime)(DateTime.MinValue);
         Z196ImpCliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A196ImpCliCod = "";
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
         A1046ImpTipCod = "";
         lblTextblock3_Jsonclick = "";
         A1030ImpDocNum = "";
         lblTextblock4_Jsonclick = "";
         A1034ImpFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A1037ImpFecVcto = DateTime.MinValue;
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1021ImpCliDsc = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1024ImpConpDsc = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1039ImpObs = "";
         lblTextblock16_Jsonclick = "";
         A1050ImpTRef = "";
         lblTextblock17_Jsonclick = "";
         A1043ImpRef = "";
         lblTextblock18_Jsonclick = "";
         A1044ImpSts = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         A1036ImpFecRef = DateTime.MinValue;
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
         A1022ImpCobCod = "";
         lblTextblock28_Jsonclick = "";
         lblTextblock29_Jsonclick = "";
         A1035ImpFecAten = (DateTime)(DateTime.MinValue);
         lblTextblock30_Jsonclick = "";
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
         Z1039ImpObs = "";
         Z1024ImpConpDsc = "";
         T002L9_A191ImpItem = new long[1] ;
         T002L9_A1046ImpTipCod = new string[] {""} ;
         T002L9_A1030ImpDocNum = new string[] {""} ;
         T002L9_A1034ImpFec = new DateTime[] {DateTime.MinValue} ;
         T002L9_A1037ImpFecVcto = new DateTime[] {DateTime.MinValue} ;
         T002L9_A1021ImpCliDsc = new string[] {""} ;
         T002L9_A1024ImpConpDsc = new string[] {""} ;
         T002L9_A1023ImpConpDias = new short[1] ;
         T002L9_A1048ImpTLis = new int[1] ;
         T002L9_A1040ImpPorDscto = new decimal[1] ;
         T002L9_A1041ImpPorIVA = new decimal[1] ;
         T002L9_A1039ImpObs = new string[] {""} ;
         T002L9_A1050ImpTRef = new string[] {""} ;
         T002L9_A1043ImpRef = new string[] {""} ;
         T002L9_A1044ImpSts = new string[] {""} ;
         T002L9_A1047ImpTItem = new decimal[1] ;
         T002L9_A1036ImpFecRef = new DateTime[] {DateTime.MinValue} ;
         T002L9_A1016ImpAlmCod = new int[1] ;
         T002L9_A1020ImpCliDirCod = new int[1] ;
         T002L9_A1038ImpForCod = new int[1] ;
         T002L9_A1017ImpBanCod = new int[1] ;
         T002L9_A1022ImpCobCod = new string[] {""} ;
         T002L9_A1018ImpCliDespacho = new int[1] ;
         T002L9_A1035ImpFecAten = new DateTime[] {DateTime.MinValue} ;
         T002L9_n1035ImpFecAten = new bool[] {false} ;
         T002L9_A1049ImpTPedCod = new int[1] ;
         T002L9_A1045ImpTieCod = new int[1] ;
         T002L9_A196ImpCliCod = new string[] {""} ;
         T002L9_A195ImpMonCod = new int[1] ;
         T002L9_A194ImpConpCod = new int[1] ;
         T002L9_A193ImpMovCod = new int[1] ;
         T002L9_A192ImpVendCod = new int[1] ;
         T002L4_A196ImpCliCod = new string[] {""} ;
         T002L5_A195ImpMonCod = new int[1] ;
         T002L6_A1024ImpConpDsc = new string[] {""} ;
         T002L6_A1023ImpConpDias = new short[1] ;
         T002L7_A193ImpMovCod = new int[1] ;
         T002L8_A192ImpVendCod = new int[1] ;
         T002L10_A196ImpCliCod = new string[] {""} ;
         T002L11_A195ImpMonCod = new int[1] ;
         T002L12_A1024ImpConpDsc = new string[] {""} ;
         T002L12_A1023ImpConpDias = new short[1] ;
         T002L13_A193ImpMovCod = new int[1] ;
         T002L14_A192ImpVendCod = new int[1] ;
         T002L15_A191ImpItem = new long[1] ;
         T002L3_A191ImpItem = new long[1] ;
         T002L3_A1046ImpTipCod = new string[] {""} ;
         T002L3_A1030ImpDocNum = new string[] {""} ;
         T002L3_A1034ImpFec = new DateTime[] {DateTime.MinValue} ;
         T002L3_A1037ImpFecVcto = new DateTime[] {DateTime.MinValue} ;
         T002L3_A1021ImpCliDsc = new string[] {""} ;
         T002L3_A1048ImpTLis = new int[1] ;
         T002L3_A1040ImpPorDscto = new decimal[1] ;
         T002L3_A1041ImpPorIVA = new decimal[1] ;
         T002L3_A1039ImpObs = new string[] {""} ;
         T002L3_A1050ImpTRef = new string[] {""} ;
         T002L3_A1043ImpRef = new string[] {""} ;
         T002L3_A1044ImpSts = new string[] {""} ;
         T002L3_A1047ImpTItem = new decimal[1] ;
         T002L3_A1036ImpFecRef = new DateTime[] {DateTime.MinValue} ;
         T002L3_A1016ImpAlmCod = new int[1] ;
         T002L3_A1020ImpCliDirCod = new int[1] ;
         T002L3_A1038ImpForCod = new int[1] ;
         T002L3_A1017ImpBanCod = new int[1] ;
         T002L3_A1022ImpCobCod = new string[] {""} ;
         T002L3_A1018ImpCliDespacho = new int[1] ;
         T002L3_A1035ImpFecAten = new DateTime[] {DateTime.MinValue} ;
         T002L3_n1035ImpFecAten = new bool[] {false} ;
         T002L3_A1049ImpTPedCod = new int[1] ;
         T002L3_A1045ImpTieCod = new int[1] ;
         T002L3_A196ImpCliCod = new string[] {""} ;
         T002L3_A195ImpMonCod = new int[1] ;
         T002L3_A194ImpConpCod = new int[1] ;
         T002L3_A193ImpMovCod = new int[1] ;
         T002L3_A192ImpVendCod = new int[1] ;
         sMode89 = "";
         T002L16_A191ImpItem = new long[1] ;
         T002L17_A191ImpItem = new long[1] ;
         T002L2_A191ImpItem = new long[1] ;
         T002L2_A1046ImpTipCod = new string[] {""} ;
         T002L2_A1030ImpDocNum = new string[] {""} ;
         T002L2_A1034ImpFec = new DateTime[] {DateTime.MinValue} ;
         T002L2_A1037ImpFecVcto = new DateTime[] {DateTime.MinValue} ;
         T002L2_A1021ImpCliDsc = new string[] {""} ;
         T002L2_A1048ImpTLis = new int[1] ;
         T002L2_A1040ImpPorDscto = new decimal[1] ;
         T002L2_A1041ImpPorIVA = new decimal[1] ;
         T002L2_A1039ImpObs = new string[] {""} ;
         T002L2_A1050ImpTRef = new string[] {""} ;
         T002L2_A1043ImpRef = new string[] {""} ;
         T002L2_A1044ImpSts = new string[] {""} ;
         T002L2_A1047ImpTItem = new decimal[1] ;
         T002L2_A1036ImpFecRef = new DateTime[] {DateTime.MinValue} ;
         T002L2_A1016ImpAlmCod = new int[1] ;
         T002L2_A1020ImpCliDirCod = new int[1] ;
         T002L2_A1038ImpForCod = new int[1] ;
         T002L2_A1017ImpBanCod = new int[1] ;
         T002L2_A1022ImpCobCod = new string[] {""} ;
         T002L2_A1018ImpCliDespacho = new int[1] ;
         T002L2_A1035ImpFecAten = new DateTime[] {DateTime.MinValue} ;
         T002L2_n1035ImpFecAten = new bool[] {false} ;
         T002L2_A1049ImpTPedCod = new int[1] ;
         T002L2_A1045ImpTieCod = new int[1] ;
         T002L2_A196ImpCliCod = new string[] {""} ;
         T002L2_A195ImpMonCod = new int[1] ;
         T002L2_A194ImpConpCod = new int[1] ;
         T002L2_A193ImpMovCod = new int[1] ;
         T002L2_A192ImpVendCod = new int[1] ;
         T002L21_A1024ImpConpDsc = new string[] {""} ;
         T002L21_A1023ImpConpDias = new short[1] ;
         T002L22_A191ImpItem = new long[1] ;
         T002L22_A197ImpDItem = new int[1] ;
         T002L23_A191ImpItem = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1046ImpTipCod = "";
         ZZ1030ImpDocNum = "";
         ZZ1034ImpFec = DateTime.MinValue;
         ZZ1037ImpFecVcto = DateTime.MinValue;
         ZZ196ImpCliCod = "";
         ZZ1021ImpCliDsc = "";
         ZZ1039ImpObs = "";
         ZZ1050ImpTRef = "";
         ZZ1043ImpRef = "";
         ZZ1044ImpSts = "";
         ZZ1036ImpFecRef = DateTime.MinValue;
         ZZ1022ImpCobCod = "";
         ZZ1035ImpFecAten = (DateTime)(DateTime.MinValue);
         ZZ1024ImpConpDsc = "";
         T002L24_A196ImpCliCod = new string[] {""} ;
         T002L25_A195ImpMonCod = new int[1] ;
         T002L26_A193ImpMovCod = new int[1] ;
         T002L27_A192ImpVendCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cldocumentos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cldocumentos__default(),
            new Object[][] {
                new Object[] {
               T002L2_A191ImpItem, T002L2_A1046ImpTipCod, T002L2_A1030ImpDocNum, T002L2_A1034ImpFec, T002L2_A1037ImpFecVcto, T002L2_A1021ImpCliDsc, T002L2_A1048ImpTLis, T002L2_A1040ImpPorDscto, T002L2_A1041ImpPorIVA, T002L2_A1039ImpObs,
               T002L2_A1050ImpTRef, T002L2_A1043ImpRef, T002L2_A1044ImpSts, T002L2_A1047ImpTItem, T002L2_A1036ImpFecRef, T002L2_A1016ImpAlmCod, T002L2_A1020ImpCliDirCod, T002L2_A1038ImpForCod, T002L2_A1017ImpBanCod, T002L2_A1022ImpCobCod,
               T002L2_A1018ImpCliDespacho, T002L2_A1035ImpFecAten, T002L2_n1035ImpFecAten, T002L2_A1049ImpTPedCod, T002L2_A1045ImpTieCod, T002L2_A196ImpCliCod, T002L2_A195ImpMonCod, T002L2_A194ImpConpCod, T002L2_A193ImpMovCod, T002L2_A192ImpVendCod
               }
               , new Object[] {
               T002L3_A191ImpItem, T002L3_A1046ImpTipCod, T002L3_A1030ImpDocNum, T002L3_A1034ImpFec, T002L3_A1037ImpFecVcto, T002L3_A1021ImpCliDsc, T002L3_A1048ImpTLis, T002L3_A1040ImpPorDscto, T002L3_A1041ImpPorIVA, T002L3_A1039ImpObs,
               T002L3_A1050ImpTRef, T002L3_A1043ImpRef, T002L3_A1044ImpSts, T002L3_A1047ImpTItem, T002L3_A1036ImpFecRef, T002L3_A1016ImpAlmCod, T002L3_A1020ImpCliDirCod, T002L3_A1038ImpForCod, T002L3_A1017ImpBanCod, T002L3_A1022ImpCobCod,
               T002L3_A1018ImpCliDespacho, T002L3_A1035ImpFecAten, T002L3_n1035ImpFecAten, T002L3_A1049ImpTPedCod, T002L3_A1045ImpTieCod, T002L3_A196ImpCliCod, T002L3_A195ImpMonCod, T002L3_A194ImpConpCod, T002L3_A193ImpMovCod, T002L3_A192ImpVendCod
               }
               , new Object[] {
               T002L4_A196ImpCliCod
               }
               , new Object[] {
               T002L5_A195ImpMonCod
               }
               , new Object[] {
               T002L6_A1024ImpConpDsc, T002L6_A1023ImpConpDias
               }
               , new Object[] {
               T002L7_A193ImpMovCod
               }
               , new Object[] {
               T002L8_A192ImpVendCod
               }
               , new Object[] {
               T002L9_A191ImpItem, T002L9_A1046ImpTipCod, T002L9_A1030ImpDocNum, T002L9_A1034ImpFec, T002L9_A1037ImpFecVcto, T002L9_A1021ImpCliDsc, T002L9_A1024ImpConpDsc, T002L9_A1023ImpConpDias, T002L9_A1048ImpTLis, T002L9_A1040ImpPorDscto,
               T002L9_A1041ImpPorIVA, T002L9_A1039ImpObs, T002L9_A1050ImpTRef, T002L9_A1043ImpRef, T002L9_A1044ImpSts, T002L9_A1047ImpTItem, T002L9_A1036ImpFecRef, T002L9_A1016ImpAlmCod, T002L9_A1020ImpCliDirCod, T002L9_A1038ImpForCod,
               T002L9_A1017ImpBanCod, T002L9_A1022ImpCobCod, T002L9_A1018ImpCliDespacho, T002L9_A1035ImpFecAten, T002L9_n1035ImpFecAten, T002L9_A1049ImpTPedCod, T002L9_A1045ImpTieCod, T002L9_A196ImpCliCod, T002L9_A195ImpMonCod, T002L9_A194ImpConpCod,
               T002L9_A193ImpMovCod, T002L9_A192ImpVendCod
               }
               , new Object[] {
               T002L10_A196ImpCliCod
               }
               , new Object[] {
               T002L11_A195ImpMonCod
               }
               , new Object[] {
               T002L12_A1024ImpConpDsc, T002L12_A1023ImpConpDias
               }
               , new Object[] {
               T002L13_A193ImpMovCod
               }
               , new Object[] {
               T002L14_A192ImpVendCod
               }
               , new Object[] {
               T002L15_A191ImpItem
               }
               , new Object[] {
               T002L16_A191ImpItem
               }
               , new Object[] {
               T002L17_A191ImpItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002L21_A1024ImpConpDsc, T002L21_A1023ImpConpDias
               }
               , new Object[] {
               T002L22_A191ImpItem, T002L22_A197ImpDItem
               }
               , new Object[] {
               T002L23_A191ImpItem
               }
               , new Object[] {
               T002L24_A196ImpCliCod
               }
               , new Object[] {
               T002L25_A195ImpMonCod
               }
               , new Object[] {
               T002L26_A193ImpMovCod
               }
               , new Object[] {
               T002L27_A192ImpVendCod
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
      private short A1023ImpConpDias ;
      private short GX_JID ;
      private short Z1023ImpConpDias ;
      private short RcdFound89 ;
      private short nIsDirty_89 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1023ImpConpDias ;
      private int Z1048ImpTLis ;
      private int Z1016ImpAlmCod ;
      private int Z1020ImpCliDirCod ;
      private int Z1038ImpForCod ;
      private int Z1017ImpBanCod ;
      private int Z1018ImpCliDespacho ;
      private int Z1049ImpTPedCod ;
      private int Z1045ImpTieCod ;
      private int Z195ImpMonCod ;
      private int Z194ImpConpCod ;
      private int Z193ImpMovCod ;
      private int Z192ImpVendCod ;
      private int A195ImpMonCod ;
      private int A194ImpConpCod ;
      private int A193ImpMovCod ;
      private int A192ImpVendCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtImpItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtImpTipCod_Enabled ;
      private int edtImpDocNum_Enabled ;
      private int edtImpFec_Enabled ;
      private int edtImpFecVcto_Enabled ;
      private int edtImpCliCod_Enabled ;
      private int edtImpCliDsc_Enabled ;
      private int edtImpMonCod_Enabled ;
      private int edtImpConpCod_Enabled ;
      private int edtImpConpDsc_Enabled ;
      private int edtImpConpDias_Enabled ;
      private int A1048ImpTLis ;
      private int edtImpTLis_Enabled ;
      private int edtImpPorDscto_Enabled ;
      private int edtImpPorIVA_Enabled ;
      private int edtImpObs_Enabled ;
      private int edtImpTRef_Enabled ;
      private int edtImpRef_Enabled ;
      private int edtImpSts_Enabled ;
      private int edtImpTItem_Enabled ;
      private int edtImpFecRef_Enabled ;
      private int edtImpMovCod_Enabled ;
      private int A1016ImpAlmCod ;
      private int edtImpAlmCod_Enabled ;
      private int A1020ImpCliDirCod ;
      private int edtImpCliDirCod_Enabled ;
      private int edtImpVendCod_Enabled ;
      private int A1038ImpForCod ;
      private int edtImpForCod_Enabled ;
      private int A1017ImpBanCod ;
      private int edtImpBanCod_Enabled ;
      private int edtImpCobCod_Enabled ;
      private int A1018ImpCliDespacho ;
      private int edtImpCliDespacho_Enabled ;
      private int edtImpFecAten_Enabled ;
      private int A1049ImpTPedCod ;
      private int edtImpTPedCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A1045ImpTieCod ;
      private int idxLst ;
      private int ZZ195ImpMonCod ;
      private int ZZ194ImpConpCod ;
      private int ZZ1048ImpTLis ;
      private int ZZ193ImpMovCod ;
      private int ZZ1016ImpAlmCod ;
      private int ZZ1020ImpCliDirCod ;
      private int ZZ192ImpVendCod ;
      private int ZZ1038ImpForCod ;
      private int ZZ1017ImpBanCod ;
      private int ZZ1018ImpCliDespacho ;
      private int ZZ1049ImpTPedCod ;
      private int ZZ1045ImpTieCod ;
      private long Z191ImpItem ;
      private long A191ImpItem ;
      private long ZZ191ImpItem ;
      private decimal Z1040ImpPorDscto ;
      private decimal Z1041ImpPorIVA ;
      private decimal Z1047ImpTItem ;
      private decimal A1040ImpPorDscto ;
      private decimal A1041ImpPorIVA ;
      private decimal A1047ImpTItem ;
      private decimal ZZ1040ImpPorDscto ;
      private decimal ZZ1041ImpPorIVA ;
      private decimal ZZ1047ImpTItem ;
      private string sPrefix ;
      private string Z1046ImpTipCod ;
      private string Z1030ImpDocNum ;
      private string Z1021ImpCliDsc ;
      private string Z1050ImpTRef ;
      private string Z1043ImpRef ;
      private string Z1044ImpSts ;
      private string Z1022ImpCobCod ;
      private string Z196ImpCliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A196ImpCliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtImpItem_Internalname ;
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
      private string edtImpItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtImpTipCod_Internalname ;
      private string A1046ImpTipCod ;
      private string edtImpTipCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtImpDocNum_Internalname ;
      private string A1030ImpDocNum ;
      private string edtImpDocNum_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtImpFec_Internalname ;
      private string edtImpFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtImpFecVcto_Internalname ;
      private string edtImpFecVcto_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtImpCliCod_Internalname ;
      private string edtImpCliCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtImpCliDsc_Internalname ;
      private string A1021ImpCliDsc ;
      private string edtImpCliDsc_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtImpMonCod_Internalname ;
      private string edtImpMonCod_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtImpConpCod_Internalname ;
      private string edtImpConpCod_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtImpConpDsc_Internalname ;
      private string A1024ImpConpDsc ;
      private string edtImpConpDsc_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtImpConpDias_Internalname ;
      private string edtImpConpDias_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtImpTLis_Internalname ;
      private string edtImpTLis_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtImpPorDscto_Internalname ;
      private string edtImpPorDscto_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtImpPorIVA_Internalname ;
      private string edtImpPorIVA_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtImpObs_Internalname ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtImpTRef_Internalname ;
      private string A1050ImpTRef ;
      private string edtImpTRef_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtImpRef_Internalname ;
      private string A1043ImpRef ;
      private string edtImpRef_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtImpSts_Internalname ;
      private string A1044ImpSts ;
      private string edtImpSts_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtImpTItem_Internalname ;
      private string edtImpTItem_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtImpFecRef_Internalname ;
      private string edtImpFecRef_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtImpMovCod_Internalname ;
      private string edtImpMovCod_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtImpAlmCod_Internalname ;
      private string edtImpAlmCod_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtImpCliDirCod_Internalname ;
      private string edtImpCliDirCod_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtImpVendCod_Internalname ;
      private string edtImpVendCod_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtImpForCod_Internalname ;
      private string edtImpForCod_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtImpBanCod_Internalname ;
      private string edtImpBanCod_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtImpCobCod_Internalname ;
      private string A1022ImpCobCod ;
      private string edtImpCobCod_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtImpCliDespacho_Internalname ;
      private string edtImpCliDespacho_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtImpFecAten_Internalname ;
      private string edtImpFecAten_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtImpTPedCod_Internalname ;
      private string edtImpTPedCod_Jsonclick ;
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
      private string Z1024ImpConpDsc ;
      private string sMode89 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1046ImpTipCod ;
      private string ZZ1030ImpDocNum ;
      private string ZZ196ImpCliCod ;
      private string ZZ1021ImpCliDsc ;
      private string ZZ1050ImpTRef ;
      private string ZZ1043ImpRef ;
      private string ZZ1044ImpSts ;
      private string ZZ1022ImpCobCod ;
      private string ZZ1024ImpConpDsc ;
      private DateTime Z1035ImpFecAten ;
      private DateTime A1035ImpFecAten ;
      private DateTime ZZ1035ImpFecAten ;
      private DateTime Z1034ImpFec ;
      private DateTime Z1037ImpFecVcto ;
      private DateTime Z1036ImpFecRef ;
      private DateTime A1034ImpFec ;
      private DateTime A1037ImpFecVcto ;
      private DateTime A1036ImpFecRef ;
      private DateTime ZZ1034ImpFec ;
      private DateTime ZZ1037ImpFecVcto ;
      private DateTime ZZ1036ImpFecRef ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1035ImpFecAten ;
      private bool Gx_longc ;
      private string A1039ImpObs ;
      private string Z1039ImpObs ;
      private string ZZ1039ImpObs ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] T002L9_A191ImpItem ;
      private string[] T002L9_A1046ImpTipCod ;
      private string[] T002L9_A1030ImpDocNum ;
      private DateTime[] T002L9_A1034ImpFec ;
      private DateTime[] T002L9_A1037ImpFecVcto ;
      private string[] T002L9_A1021ImpCliDsc ;
      private string[] T002L9_A1024ImpConpDsc ;
      private short[] T002L9_A1023ImpConpDias ;
      private int[] T002L9_A1048ImpTLis ;
      private decimal[] T002L9_A1040ImpPorDscto ;
      private decimal[] T002L9_A1041ImpPorIVA ;
      private string[] T002L9_A1039ImpObs ;
      private string[] T002L9_A1050ImpTRef ;
      private string[] T002L9_A1043ImpRef ;
      private string[] T002L9_A1044ImpSts ;
      private decimal[] T002L9_A1047ImpTItem ;
      private DateTime[] T002L9_A1036ImpFecRef ;
      private int[] T002L9_A1016ImpAlmCod ;
      private int[] T002L9_A1020ImpCliDirCod ;
      private int[] T002L9_A1038ImpForCod ;
      private int[] T002L9_A1017ImpBanCod ;
      private string[] T002L9_A1022ImpCobCod ;
      private int[] T002L9_A1018ImpCliDespacho ;
      private DateTime[] T002L9_A1035ImpFecAten ;
      private bool[] T002L9_n1035ImpFecAten ;
      private int[] T002L9_A1049ImpTPedCod ;
      private int[] T002L9_A1045ImpTieCod ;
      private string[] T002L9_A196ImpCliCod ;
      private int[] T002L9_A195ImpMonCod ;
      private int[] T002L9_A194ImpConpCod ;
      private int[] T002L9_A193ImpMovCod ;
      private int[] T002L9_A192ImpVendCod ;
      private string[] T002L4_A196ImpCliCod ;
      private int[] T002L5_A195ImpMonCod ;
      private string[] T002L6_A1024ImpConpDsc ;
      private short[] T002L6_A1023ImpConpDias ;
      private int[] T002L7_A193ImpMovCod ;
      private int[] T002L8_A192ImpVendCod ;
      private string[] T002L10_A196ImpCliCod ;
      private int[] T002L11_A195ImpMonCod ;
      private string[] T002L12_A1024ImpConpDsc ;
      private short[] T002L12_A1023ImpConpDias ;
      private int[] T002L13_A193ImpMovCod ;
      private int[] T002L14_A192ImpVendCod ;
      private long[] T002L15_A191ImpItem ;
      private long[] T002L3_A191ImpItem ;
      private string[] T002L3_A1046ImpTipCod ;
      private string[] T002L3_A1030ImpDocNum ;
      private DateTime[] T002L3_A1034ImpFec ;
      private DateTime[] T002L3_A1037ImpFecVcto ;
      private string[] T002L3_A1021ImpCliDsc ;
      private int[] T002L3_A1048ImpTLis ;
      private decimal[] T002L3_A1040ImpPorDscto ;
      private decimal[] T002L3_A1041ImpPorIVA ;
      private string[] T002L3_A1039ImpObs ;
      private string[] T002L3_A1050ImpTRef ;
      private string[] T002L3_A1043ImpRef ;
      private string[] T002L3_A1044ImpSts ;
      private decimal[] T002L3_A1047ImpTItem ;
      private DateTime[] T002L3_A1036ImpFecRef ;
      private int[] T002L3_A1016ImpAlmCod ;
      private int[] T002L3_A1020ImpCliDirCod ;
      private int[] T002L3_A1038ImpForCod ;
      private int[] T002L3_A1017ImpBanCod ;
      private string[] T002L3_A1022ImpCobCod ;
      private int[] T002L3_A1018ImpCliDespacho ;
      private DateTime[] T002L3_A1035ImpFecAten ;
      private bool[] T002L3_n1035ImpFecAten ;
      private int[] T002L3_A1049ImpTPedCod ;
      private int[] T002L3_A1045ImpTieCod ;
      private string[] T002L3_A196ImpCliCod ;
      private int[] T002L3_A195ImpMonCod ;
      private int[] T002L3_A194ImpConpCod ;
      private int[] T002L3_A193ImpMovCod ;
      private int[] T002L3_A192ImpVendCod ;
      private long[] T002L16_A191ImpItem ;
      private long[] T002L17_A191ImpItem ;
      private long[] T002L2_A191ImpItem ;
      private string[] T002L2_A1046ImpTipCod ;
      private string[] T002L2_A1030ImpDocNum ;
      private DateTime[] T002L2_A1034ImpFec ;
      private DateTime[] T002L2_A1037ImpFecVcto ;
      private string[] T002L2_A1021ImpCliDsc ;
      private int[] T002L2_A1048ImpTLis ;
      private decimal[] T002L2_A1040ImpPorDscto ;
      private decimal[] T002L2_A1041ImpPorIVA ;
      private string[] T002L2_A1039ImpObs ;
      private string[] T002L2_A1050ImpTRef ;
      private string[] T002L2_A1043ImpRef ;
      private string[] T002L2_A1044ImpSts ;
      private decimal[] T002L2_A1047ImpTItem ;
      private DateTime[] T002L2_A1036ImpFecRef ;
      private int[] T002L2_A1016ImpAlmCod ;
      private int[] T002L2_A1020ImpCliDirCod ;
      private int[] T002L2_A1038ImpForCod ;
      private int[] T002L2_A1017ImpBanCod ;
      private string[] T002L2_A1022ImpCobCod ;
      private int[] T002L2_A1018ImpCliDespacho ;
      private DateTime[] T002L2_A1035ImpFecAten ;
      private bool[] T002L2_n1035ImpFecAten ;
      private int[] T002L2_A1049ImpTPedCod ;
      private int[] T002L2_A1045ImpTieCod ;
      private string[] T002L2_A196ImpCliCod ;
      private int[] T002L2_A195ImpMonCod ;
      private int[] T002L2_A194ImpConpCod ;
      private int[] T002L2_A193ImpMovCod ;
      private int[] T002L2_A192ImpVendCod ;
      private string[] T002L21_A1024ImpConpDsc ;
      private short[] T002L21_A1023ImpConpDias ;
      private long[] T002L22_A191ImpItem ;
      private int[] T002L22_A197ImpDItem ;
      private long[] T002L23_A191ImpItem ;
      private string[] T002L24_A196ImpCliCod ;
      private int[] T002L25_A195ImpMonCod ;
      private int[] T002L26_A193ImpMovCod ;
      private int[] T002L27_A192ImpVendCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cldocumentos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cldocumentos__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT002L9;
        prmT002L9 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L4;
        prmT002L4 = new Object[] {
        new ParDef("@ImpCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002L5;
        prmT002L5 = new Object[] {
        new ParDef("@ImpMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002L6;
        prmT002L6 = new Object[] {
        new ParDef("@ImpConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002L7;
        prmT002L7 = new Object[] {
        new ParDef("@ImpMovCod",GXType.Int32,6,0)
        };
        Object[] prmT002L8;
        prmT002L8 = new Object[] {
        new ParDef("@ImpVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002L10;
        prmT002L10 = new Object[] {
        new ParDef("@ImpCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002L11;
        prmT002L11 = new Object[] {
        new ParDef("@ImpMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002L12;
        prmT002L12 = new Object[] {
        new ParDef("@ImpConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002L13;
        prmT002L13 = new Object[] {
        new ParDef("@ImpMovCod",GXType.Int32,6,0)
        };
        Object[] prmT002L14;
        prmT002L14 = new Object[] {
        new ParDef("@ImpVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002L15;
        prmT002L15 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L3;
        prmT002L3 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L16;
        prmT002L16 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L17;
        prmT002L17 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L2;
        prmT002L2 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L18;
        prmT002L18 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0) ,
        new ParDef("@ImpTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpDocNum",GXType.NChar,12,0) ,
        new ParDef("@ImpFec",GXType.Date,8,0) ,
        new ParDef("@ImpFecVcto",GXType.Date,8,0) ,
        new ParDef("@ImpCliDsc",GXType.NChar,100,0) ,
        new ParDef("@ImpTLis",GXType.Int32,6,0) ,
        new ParDef("@ImpPorDscto",GXType.Decimal,15,2) ,
        new ParDef("@ImpPorIVA",GXType.Decimal,15,2) ,
        new ParDef("@ImpObs",GXType.NVarChar,500,0) ,
        new ParDef("@ImpTRef",GXType.NChar,3,0) ,
        new ParDef("@ImpRef",GXType.NChar,10,0) ,
        new ParDef("@ImpSts",GXType.NChar,1,0) ,
        new ParDef("@ImpTItem",GXType.Decimal,15,2) ,
        new ParDef("@ImpFecRef",GXType.Date,8,0) ,
        new ParDef("@ImpAlmCod",GXType.Int32,6,0) ,
        new ParDef("@ImpCliDirCod",GXType.Int32,6,0) ,
        new ParDef("@ImpForCod",GXType.Int32,6,0) ,
        new ParDef("@ImpBanCod",GXType.Int32,6,0) ,
        new ParDef("@ImpCobCod",GXType.NChar,10,0) ,
        new ParDef("@ImpCliDespacho",GXType.Int32,6,0) ,
        new ParDef("@ImpFecAten",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ImpTPedCod",GXType.Int32,6,0) ,
        new ParDef("@ImpTieCod",GXType.Int32,6,0) ,
        new ParDef("@ImpCliCod",GXType.NChar,20,0) ,
        new ParDef("@ImpMonCod",GXType.Int32,6,0) ,
        new ParDef("@ImpConpCod",GXType.Int32,6,0) ,
        new ParDef("@ImpMovCod",GXType.Int32,6,0) ,
        new ParDef("@ImpVendCod",GXType.Int32,6,0)
        };
        Object[] prmT002L19;
        prmT002L19 = new Object[] {
        new ParDef("@ImpTipCod",GXType.NChar,3,0) ,
        new ParDef("@ImpDocNum",GXType.NChar,12,0) ,
        new ParDef("@ImpFec",GXType.Date,8,0) ,
        new ParDef("@ImpFecVcto",GXType.Date,8,0) ,
        new ParDef("@ImpCliDsc",GXType.NChar,100,0) ,
        new ParDef("@ImpTLis",GXType.Int32,6,0) ,
        new ParDef("@ImpPorDscto",GXType.Decimal,15,2) ,
        new ParDef("@ImpPorIVA",GXType.Decimal,15,2) ,
        new ParDef("@ImpObs",GXType.NVarChar,500,0) ,
        new ParDef("@ImpTRef",GXType.NChar,3,0) ,
        new ParDef("@ImpRef",GXType.NChar,10,0) ,
        new ParDef("@ImpSts",GXType.NChar,1,0) ,
        new ParDef("@ImpTItem",GXType.Decimal,15,2) ,
        new ParDef("@ImpFecRef",GXType.Date,8,0) ,
        new ParDef("@ImpAlmCod",GXType.Int32,6,0) ,
        new ParDef("@ImpCliDirCod",GXType.Int32,6,0) ,
        new ParDef("@ImpForCod",GXType.Int32,6,0) ,
        new ParDef("@ImpBanCod",GXType.Int32,6,0) ,
        new ParDef("@ImpCobCod",GXType.NChar,10,0) ,
        new ParDef("@ImpCliDespacho",GXType.Int32,6,0) ,
        new ParDef("@ImpFecAten",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@ImpTPedCod",GXType.Int32,6,0) ,
        new ParDef("@ImpTieCod",GXType.Int32,6,0) ,
        new ParDef("@ImpCliCod",GXType.NChar,20,0) ,
        new ParDef("@ImpMonCod",GXType.Int32,6,0) ,
        new ParDef("@ImpConpCod",GXType.Int32,6,0) ,
        new ParDef("@ImpMovCod",GXType.Int32,6,0) ,
        new ParDef("@ImpVendCod",GXType.Int32,6,0) ,
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L20;
        prmT002L20 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L22;
        prmT002L22 = new Object[] {
        new ParDef("@ImpItem",GXType.Decimal,10,0)
        };
        Object[] prmT002L23;
        prmT002L23 = new Object[] {
        };
        Object[] prmT002L24;
        prmT002L24 = new Object[] {
        new ParDef("@ImpCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002L25;
        prmT002L25 = new Object[] {
        new ParDef("@ImpMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002L21;
        prmT002L21 = new Object[] {
        new ParDef("@ImpConpCod",GXType.Int32,6,0)
        };
        Object[] prmT002L26;
        prmT002L26 = new Object[] {
        new ParDef("@ImpMovCod",GXType.Int32,6,0)
        };
        Object[] prmT002L27;
        prmT002L27 = new Object[] {
        new ParDef("@ImpVendCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002L2", "SELECT [ImpItem], [ImpTipCod], [ImpDocNum], [ImpFec], [ImpFecVcto], [ImpCliDsc], [ImpTLis], [ImpPorDscto], [ImpPorIVA], [ImpObs], [ImpTRef], [ImpRef], [ImpSts], [ImpTItem], [ImpFecRef], [ImpAlmCod], [ImpCliDirCod], [ImpForCod], [ImpBanCod], [ImpCobCod], [ImpCliDespacho], [ImpFecAten], [ImpTPedCod], [ImpTieCod], [ImpCliCod] AS ImpCliCod, [ImpMonCod] AS ImpMonCod, [ImpConpCod] AS ImpConpCod, [ImpMovCod] AS ImpMovCod, [ImpVendCod] AS ImpVendCod FROM [CLDOCUMENTOS] WITH (UPDLOCK) WHERE [ImpItem] = @ImpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L3", "SELECT [ImpItem], [ImpTipCod], [ImpDocNum], [ImpFec], [ImpFecVcto], [ImpCliDsc], [ImpTLis], [ImpPorDscto], [ImpPorIVA], [ImpObs], [ImpTRef], [ImpRef], [ImpSts], [ImpTItem], [ImpFecRef], [ImpAlmCod], [ImpCliDirCod], [ImpForCod], [ImpBanCod], [ImpCobCod], [ImpCliDespacho], [ImpFecAten], [ImpTPedCod], [ImpTieCod], [ImpCliCod] AS ImpCliCod, [ImpMonCod] AS ImpMonCod, [ImpConpCod] AS ImpConpCod, [ImpMovCod] AS ImpMovCod, [ImpVendCod] AS ImpVendCod FROM [CLDOCUMENTOS] WHERE [ImpItem] = @ImpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L4", "SELECT [CliCod] AS ImpCliCod FROM [CLCLIENTES] WHERE [CliCod] = @ImpCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L5", "SELECT [MonCod] AS ImpMonCod FROM [CMONEDAS] WHERE [MonCod] = @ImpMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L6", "SELECT [ConpDsc] AS ImpConpDsc, [ConpDias] AS ImpConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @ImpConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L7", "SELECT [MovCod] AS ImpMovCod FROM [CMOVALMACEN] WHERE [MovCod] = @ImpMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L8", "SELECT [VenCod] AS ImpVendCod FROM [CVENDEDORES] WHERE [VenCod] = @ImpVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L9", "SELECT TM1.[ImpItem], TM1.[ImpTipCod], TM1.[ImpDocNum], TM1.[ImpFec], TM1.[ImpFecVcto], TM1.[ImpCliDsc], T2.[ConpDsc] AS ImpConpDsc, T2.[ConpDias] AS ImpConpDias, TM1.[ImpTLis], TM1.[ImpPorDscto], TM1.[ImpPorIVA], TM1.[ImpObs], TM1.[ImpTRef], TM1.[ImpRef], TM1.[ImpSts], TM1.[ImpTItem], TM1.[ImpFecRef], TM1.[ImpAlmCod], TM1.[ImpCliDirCod], TM1.[ImpForCod], TM1.[ImpBanCod], TM1.[ImpCobCod], TM1.[ImpCliDespacho], TM1.[ImpFecAten], TM1.[ImpTPedCod], TM1.[ImpTieCod], TM1.[ImpCliCod] AS ImpCliCod, TM1.[ImpMonCod] AS ImpMonCod, TM1.[ImpConpCod] AS ImpConpCod, TM1.[ImpMovCod] AS ImpMovCod, TM1.[ImpVendCod] AS ImpVendCod FROM ([CLDOCUMENTOS] TM1 INNER JOIN [CCONDICIONPAGO] T2 ON T2.[Conpcod] = TM1.[ImpConpCod]) WHERE TM1.[ImpItem] = @ImpItem ORDER BY TM1.[ImpItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L10", "SELECT [CliCod] AS ImpCliCod FROM [CLCLIENTES] WHERE [CliCod] = @ImpCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L11", "SELECT [MonCod] AS ImpMonCod FROM [CMONEDAS] WHERE [MonCod] = @ImpMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L12", "SELECT [ConpDsc] AS ImpConpDsc, [ConpDias] AS ImpConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @ImpConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L13", "SELECT [MovCod] AS ImpMovCod FROM [CMOVALMACEN] WHERE [MovCod] = @ImpMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L14", "SELECT [VenCod] AS ImpVendCod FROM [CVENDEDORES] WHERE [VenCod] = @ImpVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L15", "SELECT [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpItem] = @ImpItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L16", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE ( [ImpItem] > @ImpItem) ORDER BY [ImpItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002L17", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE ( [ImpItem] < @ImpItem) ORDER BY [ImpItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002L18", "INSERT INTO [CLDOCUMENTOS]([ImpItem], [ImpTipCod], [ImpDocNum], [ImpFec], [ImpFecVcto], [ImpCliDsc], [ImpTLis], [ImpPorDscto], [ImpPorIVA], [ImpObs], [ImpTRef], [ImpRef], [ImpSts], [ImpTItem], [ImpFecRef], [ImpAlmCod], [ImpCliDirCod], [ImpForCod], [ImpBanCod], [ImpCobCod], [ImpCliDespacho], [ImpFecAten], [ImpTPedCod], [ImpTieCod], [ImpCliCod], [ImpMonCod], [ImpConpCod], [ImpMovCod], [ImpVendCod]) VALUES(@ImpItem, @ImpTipCod, @ImpDocNum, @ImpFec, @ImpFecVcto, @ImpCliDsc, @ImpTLis, @ImpPorDscto, @ImpPorIVA, @ImpObs, @ImpTRef, @ImpRef, @ImpSts, @ImpTItem, @ImpFecRef, @ImpAlmCod, @ImpCliDirCod, @ImpForCod, @ImpBanCod, @ImpCobCod, @ImpCliDespacho, @ImpFecAten, @ImpTPedCod, @ImpTieCod, @ImpCliCod, @ImpMonCod, @ImpConpCod, @ImpMovCod, @ImpVendCod)", GxErrorMask.GX_NOMASK,prmT002L18)
           ,new CursorDef("T002L19", "UPDATE [CLDOCUMENTOS] SET [ImpTipCod]=@ImpTipCod, [ImpDocNum]=@ImpDocNum, [ImpFec]=@ImpFec, [ImpFecVcto]=@ImpFecVcto, [ImpCliDsc]=@ImpCliDsc, [ImpTLis]=@ImpTLis, [ImpPorDscto]=@ImpPorDscto, [ImpPorIVA]=@ImpPorIVA, [ImpObs]=@ImpObs, [ImpTRef]=@ImpTRef, [ImpRef]=@ImpRef, [ImpSts]=@ImpSts, [ImpTItem]=@ImpTItem, [ImpFecRef]=@ImpFecRef, [ImpAlmCod]=@ImpAlmCod, [ImpCliDirCod]=@ImpCliDirCod, [ImpForCod]=@ImpForCod, [ImpBanCod]=@ImpBanCod, [ImpCobCod]=@ImpCobCod, [ImpCliDespacho]=@ImpCliDespacho, [ImpFecAten]=@ImpFecAten, [ImpTPedCod]=@ImpTPedCod, [ImpTieCod]=@ImpTieCod, [ImpCliCod]=@ImpCliCod, [ImpMonCod]=@ImpMonCod, [ImpConpCod]=@ImpConpCod, [ImpMovCod]=@ImpMovCod, [ImpVendCod]=@ImpVendCod  WHERE [ImpItem] = @ImpItem", GxErrorMask.GX_NOMASK,prmT002L19)
           ,new CursorDef("T002L20", "DELETE FROM [CLDOCUMENTOS]  WHERE [ImpItem] = @ImpItem", GxErrorMask.GX_NOMASK,prmT002L20)
           ,new CursorDef("T002L21", "SELECT [ConpDsc] AS ImpConpDsc, [ConpDias] AS ImpConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @ImpConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L22", "SELECT TOP 1 [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] WHERE [ImpItem] = @ImpItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002L23", "SELECT [ImpItem] FROM [CLDOCUMENTOS] ORDER BY [ImpItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002L23,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L24", "SELECT [CliCod] AS ImpCliCod FROM [CLCLIENTES] WHERE [CliCod] = @ImpCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L25", "SELECT [MonCod] AS ImpMonCod FROM [CMONEDAS] WHERE [MonCod] = @ImpMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L26", "SELECT [MovCod] AS ImpMovCod FROM [CMOVALMACEN] WHERE [MovCod] = @ImpMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002L27", "SELECT [VenCod] AS ImpVendCod FROM [CVENDEDORES] WHERE [VenCod] = @ImpVendCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002L27,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((int[]) buf[23])[0] = rslt.getInt(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((string[]) buf[25])[0] = rslt.getString(25, 20);
              ((int[]) buf[26])[0] = rslt.getInt(26);
              ((int[]) buf[27])[0] = rslt.getInt(27);
              ((int[]) buf[28])[0] = rslt.getInt(28);
              ((int[]) buf[29])[0] = rslt.getInt(29);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((int[]) buf[23])[0] = rslt.getInt(23);
              ((int[]) buf[24])[0] = rslt.getInt(24);
              ((string[]) buf[25])[0] = rslt.getString(25, 20);
              ((int[]) buf[26])[0] = rslt.getInt(26);
              ((int[]) buf[27])[0] = rslt.getInt(27);
              ((int[]) buf[28])[0] = rslt.getInt(28);
              ((int[]) buf[29])[0] = rslt.getInt(29);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 3);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((string[]) buf[14])[0] = rslt.getString(15, 1);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 10);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(24);
              ((bool[]) buf[24])[0] = rslt.wasNull(24);
              ((int[]) buf[25])[0] = rslt.getInt(25);
              ((int[]) buf[26])[0] = rslt.getInt(26);
              ((string[]) buf[27])[0] = rslt.getString(27, 20);
              ((int[]) buf[28])[0] = rslt.getInt(28);
              ((int[]) buf[29])[0] = rslt.getInt(29);
              ((int[]) buf[30])[0] = rslt.getInt(30);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
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
