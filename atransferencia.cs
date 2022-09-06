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
   public class atransferencia : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A65TraMVATip = GetPar( "TraMVATip");
            AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
            A66TraMVACod = GetPar( "TraMVACod");
            AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A65TraMVATip, A66TraMVACod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A1943TraAlmCod = (int)(NumberUtil.Val( GetPar( "TraAlmCod"), "."));
            AssignAttri("", false, "A1943TraAlmCod", StringUtil.LTrimStr( (decimal)(A1943TraAlmCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A1943TraAlmCod) ;
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
            Form.Meta.addItem("description", "Transferencia Entre Almacenes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTraMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public atransferencia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public atransferencia( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ATRANSFERENCIA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo Guia", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTraMVATip_Internalname, StringUtil.RTrim( A65TraMVATip), StringUtil.RTrim( context.localUtil.Format( A65TraMVATip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraMVATip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraMVATip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Salida", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTraMVACod_Internalname, StringUtil.RTrim( A66TraMVACod), StringUtil.RTrim( context.localUtil.Format( A66TraMVACod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraMVACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraMVACod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha de Transferencia", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTraFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTraFec_Internalname, context.localUtil.Format(A67TraFec, "99/99/99"), context.localUtil.Format( A67TraFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ATRANSFERENCIA.htm");
         GxWebStd.gx_bitmap( context, edtTraFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTraFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Almacen Destino", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTraAlmDestino_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1944TraAlmDestino), 6, 0, ".", "")), StringUtil.LTrim( ((edtTraAlmDestino_Enabled!=0) ? context.localUtil.Format( (decimal)(A1944TraAlmDestino), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1944TraAlmDestino), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraAlmDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraAlmDestino_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Usuario TransFerencia", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTraUSUC_Internalname, StringUtil.RTrim( A1949TraUSUC), StringUtil.RTrim( context.localUtil.Format( A1949TraUSUC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraUSUC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraUSUC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Fecha TransFerencia", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTraUSUFT_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTraUSUFT_Internalname, context.localUtil.TToC( A1952TraUSUFT, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1952TraUSUFT, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraUSUFT_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraUSUFT_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ATRANSFERENCIA.htm");
         GxWebStd.gx_bitmap( context, edtTraUSUFT_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTraUSUFT_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Estado", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edttrasts_Internalname, StringUtil.RTrim( A1948trasts), StringUtil.RTrim( context.localUtil.Format( A1948trasts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edttrasts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edttrasts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Guia Entrada", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTraMVACodE_Internalname, StringUtil.RTrim( A1946TraMVACodE), StringUtil.RTrim( context.localUtil.Format( A1946TraMVACodE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraMVACodE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraMVACodE_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Usuario Entrada", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTraUsuE_Internalname, StringUtil.RTrim( A1950TraUsuE), StringUtil.RTrim( context.localUtil.Format( A1950TraUsuE, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraUsuE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraUsuE_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Fecha Entrada", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ATRANSFERENCIA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTraUsuFE_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTraUsuFE_Internalname, context.localUtil.TToC( A1951TraUsuFE, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1951TraUsuFE, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTraUsuFE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTraUsuFE_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ATRANSFERENCIA.htm");
         GxWebStd.gx_bitmap( context, edtTraUsuFE_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTraUsuFE_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ATRANSFERENCIA.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ATRANSFERENCIA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ATRANSFERENCIA.htm");
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
            Z65TraMVATip = cgiGet( "Z65TraMVATip");
            Z66TraMVACod = cgiGet( "Z66TraMVACod");
            Z67TraFec = context.localUtil.CToD( cgiGet( "Z67TraFec"), 0);
            Z1944TraAlmDestino = (int)(context.localUtil.CToN( cgiGet( "Z1944TraAlmDestino"), ".", ","));
            Z1949TraUSUC = cgiGet( "Z1949TraUSUC");
            Z1952TraUSUFT = context.localUtil.CToT( cgiGet( "Z1952TraUSUFT"), 0);
            Z1948trasts = cgiGet( "Z1948trasts");
            Z1946TraMVACodE = cgiGet( "Z1946TraMVACodE");
            Z1950TraUsuE = cgiGet( "Z1950TraUsuE");
            Z1951TraUsuFE = context.localUtil.CToT( cgiGet( "Z1951TraUsuFE"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1943TraAlmCod = (int)(context.localUtil.CToN( cgiGet( "TRAALMCOD"), ".", ","));
            A1947TraMVCliCod = cgiGet( "TRAMVCLICOD");
            n1947TraMVCliCod = false;
            A1945TraAlmDsc = cgiGet( "TRAALMDSC");
            /* Read variables values. */
            A65TraMVATip = cgiGet( edtTraMVATip_Internalname);
            AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
            A66TraMVACod = cgiGet( edtTraMVACod_Internalname);
            AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
            if ( context.localUtil.VCDate( cgiGet( edtTraFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha de Transferencia"}), 1, "TRAFEC");
               AnyError = 1;
               GX_FocusControl = edtTraFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A67TraFec = DateTime.MinValue;
               AssignAttri("", false, "A67TraFec", context.localUtil.Format(A67TraFec, "99/99/99"));
            }
            else
            {
               A67TraFec = context.localUtil.CToD( cgiGet( edtTraFec_Internalname), 2);
               AssignAttri("", false, "A67TraFec", context.localUtil.Format(A67TraFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTraAlmDestino_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTraAlmDestino_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TRAALMDESTINO");
               AnyError = 1;
               GX_FocusControl = edtTraAlmDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1944TraAlmDestino = 0;
               AssignAttri("", false, "A1944TraAlmDestino", StringUtil.LTrimStr( (decimal)(A1944TraAlmDestino), 6, 0));
            }
            else
            {
               A1944TraAlmDestino = (int)(context.localUtil.CToN( cgiGet( edtTraAlmDestino_Internalname), ".", ","));
               AssignAttri("", false, "A1944TraAlmDestino", StringUtil.LTrimStr( (decimal)(A1944TraAlmDestino), 6, 0));
            }
            A1949TraUSUC = cgiGet( edtTraUSUC_Internalname);
            AssignAttri("", false, "A1949TraUSUC", A1949TraUSUC);
            if ( context.localUtil.VCDateTime( cgiGet( edtTraUSUFT_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha TransFerencia"}), 1, "TRAUSUFT");
               AnyError = 1;
               GX_FocusControl = edtTraUSUFT_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1952TraUSUFT = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1952TraUSUFT", context.localUtil.TToC( A1952TraUSUFT, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1952TraUSUFT = context.localUtil.CToT( cgiGet( edtTraUSUFT_Internalname));
               AssignAttri("", false, "A1952TraUSUFT", context.localUtil.TToC( A1952TraUSUFT, 8, 5, 0, 3, "/", ":", " "));
            }
            A1948trasts = cgiGet( edttrasts_Internalname);
            AssignAttri("", false, "A1948trasts", A1948trasts);
            A1946TraMVACodE = cgiGet( edtTraMVACodE_Internalname);
            AssignAttri("", false, "A1946TraMVACodE", A1946TraMVACodE);
            A1950TraUsuE = cgiGet( edtTraUsuE_Internalname);
            AssignAttri("", false, "A1950TraUsuE", A1950TraUsuE);
            if ( context.localUtil.VCDateTime( cgiGet( edtTraUsuFE_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Entrada"}), 1, "TRAUSUFE");
               AnyError = 1;
               GX_FocusControl = edtTraUsuFE_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1951TraUsuFE = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1951TraUsuFE", context.localUtil.TToC( A1951TraUsuFE, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1951TraUsuFE = context.localUtil.CToT( cgiGet( edtTraUsuFE_Internalname));
               AssignAttri("", false, "A1951TraUsuFE", context.localUtil.TToC( A1951TraUsuFE, 8, 5, 0, 3, "/", ":", " "));
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
               A65TraMVATip = GetPar( "TraMVATip");
               AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
               A66TraMVACod = GetPar( "TraMVACod");
               AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
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
               InitAll1H51( ) ;
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
         DisableAttributes1H51( ) ;
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

      protected void CONFIRM_1H0( )
      {
         BeforeValidate1H51( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1H51( ) ;
            }
            else
            {
               CheckExtendedTable1H51( ) ;
               if ( AnyError == 0 )
               {
                  ZM1H51( 5) ;
                  ZM1H51( 6) ;
               }
               CloseExtendedTableCursors1H51( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1H0( ) ;
         }
      }

      protected void ResetCaption1H0( )
      {
      }

      protected void ZM1H51( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z67TraFec = T001H3_A67TraFec[0];
               Z1944TraAlmDestino = T001H3_A1944TraAlmDestino[0];
               Z1949TraUSUC = T001H3_A1949TraUSUC[0];
               Z1952TraUSUFT = T001H3_A1952TraUSUFT[0];
               Z1948trasts = T001H3_A1948trasts[0];
               Z1946TraMVACodE = T001H3_A1946TraMVACodE[0];
               Z1950TraUsuE = T001H3_A1950TraUsuE[0];
               Z1951TraUsuFE = T001H3_A1951TraUsuFE[0];
            }
            else
            {
               Z67TraFec = A67TraFec;
               Z1944TraAlmDestino = A1944TraAlmDestino;
               Z1949TraUSUC = A1949TraUSUC;
               Z1952TraUSUFT = A1952TraUSUFT;
               Z1948trasts = A1948trasts;
               Z1946TraMVACodE = A1946TraMVACodE;
               Z1950TraUsuE = A1950TraUsuE;
               Z1951TraUsuFE = A1951TraUsuFE;
            }
         }
         if ( GX_JID == -4 )
         {
            Z67TraFec = A67TraFec;
            Z1944TraAlmDestino = A1944TraAlmDestino;
            Z1949TraUSUC = A1949TraUSUC;
            Z1952TraUSUFT = A1952TraUSUFT;
            Z1948trasts = A1948trasts;
            Z1946TraMVACodE = A1946TraMVACodE;
            Z1950TraUsuE = A1950TraUsuE;
            Z1951TraUsuFE = A1951TraUsuFE;
            Z65TraMVATip = A65TraMVATip;
            Z66TraMVACod = A66TraMVACod;
            Z1943TraAlmCod = A1943TraAlmCod;
            Z1947TraMVCliCod = A1947TraMVCliCod;
            Z1945TraAlmDsc = A1945TraAlmDsc;
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

      protected void Load1H51( )
      {
         /* Using cursor T001H6 */
         pr_default.execute(4, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound51 = 1;
            A1945TraAlmDsc = T001H6_A1945TraAlmDsc[0];
            A67TraFec = T001H6_A67TraFec[0];
            AssignAttri("", false, "A67TraFec", context.localUtil.Format(A67TraFec, "99/99/99"));
            A1944TraAlmDestino = T001H6_A1944TraAlmDestino[0];
            AssignAttri("", false, "A1944TraAlmDestino", StringUtil.LTrimStr( (decimal)(A1944TraAlmDestino), 6, 0));
            A1949TraUSUC = T001H6_A1949TraUSUC[0];
            AssignAttri("", false, "A1949TraUSUC", A1949TraUSUC);
            A1952TraUSUFT = T001H6_A1952TraUSUFT[0];
            AssignAttri("", false, "A1952TraUSUFT", context.localUtil.TToC( A1952TraUSUFT, 8, 5, 0, 3, "/", ":", " "));
            A1948trasts = T001H6_A1948trasts[0];
            AssignAttri("", false, "A1948trasts", A1948trasts);
            A1946TraMVACodE = T001H6_A1946TraMVACodE[0];
            AssignAttri("", false, "A1946TraMVACodE", A1946TraMVACodE);
            A1950TraUsuE = T001H6_A1950TraUsuE[0];
            AssignAttri("", false, "A1950TraUsuE", A1950TraUsuE);
            A1951TraUsuFE = T001H6_A1951TraUsuFE[0];
            AssignAttri("", false, "A1951TraUsuFE", context.localUtil.TToC( A1951TraUsuFE, 8, 5, 0, 3, "/", ":", " "));
            A1943TraAlmCod = T001H6_A1943TraAlmCod[0];
            A1947TraMVCliCod = T001H6_A1947TraMVCliCod[0];
            n1947TraMVCliCod = T001H6_n1947TraMVCliCod[0];
            ZM1H51( -4) ;
         }
         pr_default.close(4);
         OnLoadActions1H51( ) ;
      }

      protected void OnLoadActions1H51( )
      {
      }

      protected void CheckExtendedTable1H51( )
      {
         nIsDirty_51 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001H4 */
         pr_default.execute(2, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Transferencia'.", "ForeignKeyNotFound", 1, "TRAMVACOD");
            AnyError = 1;
            GX_FocusControl = edtTraMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1943TraAlmCod = T001H4_A1943TraAlmCod[0];
         A1947TraMVCliCod = T001H4_A1947TraMVCliCod[0];
         n1947TraMVCliCod = T001H4_n1947TraMVCliCod[0];
         pr_default.close(2);
         /* Using cursor T001H5 */
         pr_default.execute(3, new Object[] {A1943TraAlmCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "TRAALMCOD");
            AnyError = 1;
         }
         A1945TraAlmDsc = T001H5_A1945TraAlmDsc[0];
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A67TraFec) || ( DateTimeUtil.ResetTime ( A67TraFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha de Transferencia fuera de rango", "OutOfRange", 1, "TRAFEC");
            AnyError = 1;
            GX_FocusControl = edtTraFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1952TraUSUFT) || ( A1952TraUSUFT >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha TransFerencia fuera de rango", "OutOfRange", 1, "TRAUSUFT");
            AnyError = 1;
            GX_FocusControl = edtTraUSUFT_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1951TraUsuFE) || ( A1951TraUsuFE >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Entrada fuera de rango", "OutOfRange", 1, "TRAUSUFE");
            AnyError = 1;
            GX_FocusControl = edtTraUsuFE_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1H51( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( string A65TraMVATip ,
                               string A66TraMVACod )
      {
         /* Using cursor T001H7 */
         pr_default.execute(5, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Transferencia'.", "ForeignKeyNotFound", 1, "TRAMVACOD");
            AnyError = 1;
            GX_FocusControl = edtTraMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1943TraAlmCod = T001H7_A1943TraAlmCod[0];
         A1947TraMVCliCod = T001H7_A1947TraMVCliCod[0];
         n1947TraMVCliCod = T001H7_n1947TraMVCliCod[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1943TraAlmCod), 6, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1947TraMVCliCod))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_6( int A1943TraAlmCod )
      {
         /* Using cursor T001H8 */
         pr_default.execute(6, new Object[] {A1943TraAlmCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "TRAALMCOD");
            AnyError = 1;
         }
         A1945TraAlmDsc = T001H8_A1945TraAlmDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1945TraAlmDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey1H51( )
      {
         /* Using cursor T001H9 */
         pr_default.execute(7, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound51 = 1;
         }
         else
         {
            RcdFound51 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001H3 */
         pr_default.execute(1, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1H51( 4) ;
            RcdFound51 = 1;
            A67TraFec = T001H3_A67TraFec[0];
            AssignAttri("", false, "A67TraFec", context.localUtil.Format(A67TraFec, "99/99/99"));
            A1944TraAlmDestino = T001H3_A1944TraAlmDestino[0];
            AssignAttri("", false, "A1944TraAlmDestino", StringUtil.LTrimStr( (decimal)(A1944TraAlmDestino), 6, 0));
            A1949TraUSUC = T001H3_A1949TraUSUC[0];
            AssignAttri("", false, "A1949TraUSUC", A1949TraUSUC);
            A1952TraUSUFT = T001H3_A1952TraUSUFT[0];
            AssignAttri("", false, "A1952TraUSUFT", context.localUtil.TToC( A1952TraUSUFT, 8, 5, 0, 3, "/", ":", " "));
            A1948trasts = T001H3_A1948trasts[0];
            AssignAttri("", false, "A1948trasts", A1948trasts);
            A1946TraMVACodE = T001H3_A1946TraMVACodE[0];
            AssignAttri("", false, "A1946TraMVACodE", A1946TraMVACodE);
            A1950TraUsuE = T001H3_A1950TraUsuE[0];
            AssignAttri("", false, "A1950TraUsuE", A1950TraUsuE);
            A1951TraUsuFE = T001H3_A1951TraUsuFE[0];
            AssignAttri("", false, "A1951TraUsuFE", context.localUtil.TToC( A1951TraUsuFE, 8, 5, 0, 3, "/", ":", " "));
            A65TraMVATip = T001H3_A65TraMVATip[0];
            AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
            A66TraMVACod = T001H3_A66TraMVACod[0];
            AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
            Z65TraMVATip = A65TraMVATip;
            Z66TraMVACod = A66TraMVACod;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1H51( ) ;
            if ( AnyError == 1 )
            {
               RcdFound51 = 0;
               InitializeNonKey1H51( ) ;
            }
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound51 = 0;
            InitializeNonKey1H51( ) ;
            sMode51 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode51;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1H51( ) ;
         if ( RcdFound51 == 0 )
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
         RcdFound51 = 0;
         /* Using cursor T001H10 */
         pr_default.execute(8, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001H10_A65TraMVATip[0], A65TraMVATip) < 0 ) || ( StringUtil.StrCmp(T001H10_A65TraMVATip[0], A65TraMVATip) == 0 ) && ( StringUtil.StrCmp(T001H10_A66TraMVACod[0], A66TraMVACod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001H10_A65TraMVATip[0], A65TraMVATip) > 0 ) || ( StringUtil.StrCmp(T001H10_A65TraMVATip[0], A65TraMVATip) == 0 ) && ( StringUtil.StrCmp(T001H10_A66TraMVACod[0], A66TraMVACod) > 0 ) ) )
            {
               A65TraMVATip = T001H10_A65TraMVATip[0];
               AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
               A66TraMVACod = T001H10_A66TraMVACod[0];
               AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
               RcdFound51 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound51 = 0;
         /* Using cursor T001H11 */
         pr_default.execute(9, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001H11_A65TraMVATip[0], A65TraMVATip) > 0 ) || ( StringUtil.StrCmp(T001H11_A65TraMVATip[0], A65TraMVATip) == 0 ) && ( StringUtil.StrCmp(T001H11_A66TraMVACod[0], A66TraMVACod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001H11_A65TraMVATip[0], A65TraMVATip) < 0 ) || ( StringUtil.StrCmp(T001H11_A65TraMVATip[0], A65TraMVATip) == 0 ) && ( StringUtil.StrCmp(T001H11_A66TraMVACod[0], A66TraMVACod) < 0 ) ) )
            {
               A65TraMVATip = T001H11_A65TraMVATip[0];
               AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
               A66TraMVACod = T001H11_A66TraMVACod[0];
               AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
               RcdFound51 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1H51( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTraMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1H51( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound51 == 1 )
            {
               if ( ( StringUtil.StrCmp(A65TraMVATip, Z65TraMVATip) != 0 ) || ( StringUtil.StrCmp(A66TraMVACod, Z66TraMVACod) != 0 ) )
               {
                  A65TraMVATip = Z65TraMVATip;
                  AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
                  A66TraMVACod = Z66TraMVACod;
                  AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TRAMVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtTraMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTraMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1H51( ) ;
                  GX_FocusControl = edtTraMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A65TraMVATip, Z65TraMVATip) != 0 ) || ( StringUtil.StrCmp(A66TraMVACod, Z66TraMVACod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTraMVATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1H51( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRAMVATIP");
                     AnyError = 1;
                     GX_FocusControl = edtTraMVATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTraMVATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1H51( ) ;
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
         if ( ( StringUtil.StrCmp(A65TraMVATip, Z65TraMVATip) != 0 ) || ( StringUtil.StrCmp(A66TraMVACod, Z66TraMVACod) != 0 ) )
         {
            A65TraMVATip = Z65TraMVATip;
            AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
            A66TraMVACod = Z66TraMVACod;
            AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TRAMVATIP");
            AnyError = 1;
            GX_FocusControl = edtTraMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTraMVATip_Internalname;
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
         GetKey1H51( ) ;
         if ( RcdFound51 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TRAMVATIP");
               AnyError = 1;
               GX_FocusControl = edtTraMVATip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A65TraMVATip, Z65TraMVATip) != 0 ) || ( StringUtil.StrCmp(A66TraMVACod, Z66TraMVACod) != 0 ) )
            {
               A65TraMVATip = Z65TraMVATip;
               AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
               A66TraMVACod = Z66TraMVACod;
               AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TRAMVATIP");
               AnyError = 1;
               GX_FocusControl = edtTraMVATip_Internalname;
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
            if ( ( StringUtil.StrCmp(A65TraMVATip, Z65TraMVATip) != 0 ) || ( StringUtil.StrCmp(A66TraMVACod, Z66TraMVACod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TRAMVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtTraMVATip_Internalname;
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
         context.RollbackDataStores("atransferencia",pr_default);
         GX_FocusControl = edtTraFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1H0( ) ;
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
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TRAMVATIP");
            AnyError = 1;
            GX_FocusControl = edtTraMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTraFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1H51( ) ;
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTraFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1H51( ) ;
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
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTraFec_Internalname;
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
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTraFec_Internalname;
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
         ScanStart1H51( ) ;
         if ( RcdFound51 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound51 != 0 )
            {
               ScanNext1H51( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTraFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1H51( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1H51( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001H2 */
            pr_default.execute(0, new Object[] {A65TraMVATip, A66TraMVACod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ATRANSFERENCIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z67TraFec ) != DateTimeUtil.ResetTime ( T001H2_A67TraFec[0] ) ) || ( Z1944TraAlmDestino != T001H2_A1944TraAlmDestino[0] ) || ( StringUtil.StrCmp(Z1949TraUSUC, T001H2_A1949TraUSUC[0]) != 0 ) || ( Z1952TraUSUFT != T001H2_A1952TraUSUFT[0] ) || ( StringUtil.StrCmp(Z1948trasts, T001H2_A1948trasts[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1946TraMVACodE, T001H2_A1946TraMVACodE[0]) != 0 ) || ( StringUtil.StrCmp(Z1950TraUsuE, T001H2_A1950TraUsuE[0]) != 0 ) || ( Z1951TraUsuFE != T001H2_A1951TraUsuFE[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z67TraFec ) != DateTimeUtil.ResetTime ( T001H2_A67TraFec[0] ) )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"TraFec");
                  GXUtil.WriteLogRaw("Old: ",Z67TraFec);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A67TraFec[0]);
               }
               if ( Z1944TraAlmDestino != T001H2_A1944TraAlmDestino[0] )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"TraAlmDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1944TraAlmDestino);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A1944TraAlmDestino[0]);
               }
               if ( StringUtil.StrCmp(Z1949TraUSUC, T001H2_A1949TraUSUC[0]) != 0 )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"TraUSUC");
                  GXUtil.WriteLogRaw("Old: ",Z1949TraUSUC);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A1949TraUSUC[0]);
               }
               if ( Z1952TraUSUFT != T001H2_A1952TraUSUFT[0] )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"TraUSUFT");
                  GXUtil.WriteLogRaw("Old: ",Z1952TraUSUFT);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A1952TraUSUFT[0]);
               }
               if ( StringUtil.StrCmp(Z1948trasts, T001H2_A1948trasts[0]) != 0 )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"trasts");
                  GXUtil.WriteLogRaw("Old: ",Z1948trasts);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A1948trasts[0]);
               }
               if ( StringUtil.StrCmp(Z1946TraMVACodE, T001H2_A1946TraMVACodE[0]) != 0 )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"TraMVACodE");
                  GXUtil.WriteLogRaw("Old: ",Z1946TraMVACodE);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A1946TraMVACodE[0]);
               }
               if ( StringUtil.StrCmp(Z1950TraUsuE, T001H2_A1950TraUsuE[0]) != 0 )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"TraUsuE");
                  GXUtil.WriteLogRaw("Old: ",Z1950TraUsuE);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A1950TraUsuE[0]);
               }
               if ( Z1951TraUsuFE != T001H2_A1951TraUsuFE[0] )
               {
                  GXUtil.WriteLog("atransferencia:[seudo value changed for attri]"+"TraUsuFE");
                  GXUtil.WriteLogRaw("Old: ",Z1951TraUsuFE);
                  GXUtil.WriteLogRaw("Current: ",T001H2_A1951TraUsuFE[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ATRANSFERENCIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1H51( )
      {
         BeforeValidate1H51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H51( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1H51( 0) ;
            CheckOptimisticConcurrency1H51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1H51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001H12 */
                     pr_default.execute(10, new Object[] {A67TraFec, A1944TraAlmDestino, A1949TraUSUC, A1952TraUSUFT, A1948trasts, A1946TraMVACodE, A1950TraUsuE, A1951TraUsuFE, A65TraMVATip, A66TraMVACod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ATRANSFERENCIA");
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
                           ResetCaption1H0( ) ;
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
               Load1H51( ) ;
            }
            EndLevel1H51( ) ;
         }
         CloseExtendedTableCursors1H51( ) ;
      }

      protected void Update1H51( )
      {
         BeforeValidate1H51( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1H51( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H51( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1H51( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1H51( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001H13 */
                     pr_default.execute(11, new Object[] {A67TraFec, A1944TraAlmDestino, A1949TraUSUC, A1952TraUSUFT, A1948trasts, A1946TraMVACodE, A1950TraUsuE, A1951TraUsuFE, A65TraMVATip, A66TraMVACod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ATRANSFERENCIA");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ATRANSFERENCIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1H51( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1H0( ) ;
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
            EndLevel1H51( ) ;
         }
         CloseExtendedTableCursors1H51( ) ;
      }

      protected void DeferredUpdate1H51( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1H51( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1H51( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1H51( ) ;
            AfterConfirm1H51( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1H51( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001H14 */
                  pr_default.execute(12, new Object[] {A65TraMVATip, A66TraMVACod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ATRANSFERENCIA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound51 == 0 )
                        {
                           InitAll1H51( ) ;
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
                        ResetCaption1H0( ) ;
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
         sMode51 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1H51( ) ;
         Gx_mode = sMode51;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1H51( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001H15 */
            pr_default.execute(13, new Object[] {A65TraMVATip, A66TraMVACod});
            A1943TraAlmCod = T001H15_A1943TraAlmCod[0];
            A1947TraMVCliCod = T001H15_A1947TraMVCliCod[0];
            n1947TraMVCliCod = T001H15_n1947TraMVCliCod[0];
            pr_default.close(13);
            /* Using cursor T001H16 */
            pr_default.execute(14, new Object[] {A1943TraAlmCod});
            A1945TraAlmDsc = T001H16_A1945TraAlmDsc[0];
            pr_default.close(14);
         }
      }

      protected void EndLevel1H51( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1H51( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("atransferencia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.RollbackDataStores("atransferencia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1H51( )
      {
         /* Using cursor T001H17 */
         pr_default.execute(15);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound51 = 1;
            A65TraMVATip = T001H17_A65TraMVATip[0];
            AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
            A66TraMVACod = T001H17_A66TraMVACod[0];
            AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1H51( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound51 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound51 = 1;
            A65TraMVATip = T001H17_A65TraMVATip[0];
            AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
            A66TraMVACod = T001H17_A66TraMVACod[0];
            AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
         }
      }

      protected void ScanEnd1H51( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1H51( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1H51( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1H51( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1H51( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1H51( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1H51( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1H51( )
      {
         edtTraMVATip_Enabled = 0;
         AssignProp("", false, edtTraMVATip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraMVATip_Enabled), 5, 0), true);
         edtTraMVACod_Enabled = 0;
         AssignProp("", false, edtTraMVACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraMVACod_Enabled), 5, 0), true);
         edtTraFec_Enabled = 0;
         AssignProp("", false, edtTraFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraFec_Enabled), 5, 0), true);
         edtTraAlmDestino_Enabled = 0;
         AssignProp("", false, edtTraAlmDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraAlmDestino_Enabled), 5, 0), true);
         edtTraUSUC_Enabled = 0;
         AssignProp("", false, edtTraUSUC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraUSUC_Enabled), 5, 0), true);
         edtTraUSUFT_Enabled = 0;
         AssignProp("", false, edtTraUSUFT_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraUSUFT_Enabled), 5, 0), true);
         edttrasts_Enabled = 0;
         AssignProp("", false, edttrasts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edttrasts_Enabled), 5, 0), true);
         edtTraMVACodE_Enabled = 0;
         AssignProp("", false, edtTraMVACodE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraMVACodE_Enabled), 5, 0), true);
         edtTraUsuE_Enabled = 0;
         AssignProp("", false, edtTraUsuE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraUsuE_Enabled), 5, 0), true);
         edtTraUsuFE_Enabled = 0;
         AssignProp("", false, edtTraUsuFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTraUsuFE_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1H51( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1H0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810235284", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("atransferencia.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z65TraMVATip", StringUtil.RTrim( Z65TraMVATip));
         GxWebStd.gx_hidden_field( context, "Z66TraMVACod", StringUtil.RTrim( Z66TraMVACod));
         GxWebStd.gx_hidden_field( context, "Z67TraFec", context.localUtil.DToC( Z67TraFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1944TraAlmDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1944TraAlmDestino), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1949TraUSUC", StringUtil.RTrim( Z1949TraUSUC));
         GxWebStd.gx_hidden_field( context, "Z1952TraUSUFT", context.localUtil.TToC( Z1952TraUSUFT, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1948trasts", StringUtil.RTrim( Z1948trasts));
         GxWebStd.gx_hidden_field( context, "Z1946TraMVACodE", StringUtil.RTrim( Z1946TraMVACodE));
         GxWebStd.gx_hidden_field( context, "Z1950TraUsuE", StringUtil.RTrim( Z1950TraUsuE));
         GxWebStd.gx_hidden_field( context, "Z1951TraUsuFE", context.localUtil.TToC( Z1951TraUsuFE, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "TRAALMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1943TraAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TRAMVCLICOD", StringUtil.RTrim( A1947TraMVCliCod));
         GxWebStd.gx_hidden_field( context, "TRAALMDSC", StringUtil.RTrim( A1945TraAlmDsc));
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
         return formatLink("atransferencia.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ATRANSFERENCIA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Transferencia Entre Almacenes" ;
      }

      protected void InitializeNonKey1H51( )
      {
         A1945TraAlmDsc = "";
         AssignAttri("", false, "A1945TraAlmDsc", A1945TraAlmDsc);
         A1943TraAlmCod = 0;
         AssignAttri("", false, "A1943TraAlmCod", StringUtil.LTrimStr( (decimal)(A1943TraAlmCod), 6, 0));
         A1947TraMVCliCod = "";
         n1947TraMVCliCod = false;
         AssignAttri("", false, "A1947TraMVCliCod", A1947TraMVCliCod);
         A67TraFec = DateTime.MinValue;
         AssignAttri("", false, "A67TraFec", context.localUtil.Format(A67TraFec, "99/99/99"));
         A1944TraAlmDestino = 0;
         AssignAttri("", false, "A1944TraAlmDestino", StringUtil.LTrimStr( (decimal)(A1944TraAlmDestino), 6, 0));
         A1949TraUSUC = "";
         AssignAttri("", false, "A1949TraUSUC", A1949TraUSUC);
         A1952TraUSUFT = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1952TraUSUFT", context.localUtil.TToC( A1952TraUSUFT, 8, 5, 0, 3, "/", ":", " "));
         A1948trasts = "";
         AssignAttri("", false, "A1948trasts", A1948trasts);
         A1946TraMVACodE = "";
         AssignAttri("", false, "A1946TraMVACodE", A1946TraMVACodE);
         A1950TraUsuE = "";
         AssignAttri("", false, "A1950TraUsuE", A1950TraUsuE);
         A1951TraUsuFE = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1951TraUsuFE", context.localUtil.TToC( A1951TraUsuFE, 8, 5, 0, 3, "/", ":", " "));
         Z67TraFec = DateTime.MinValue;
         Z1944TraAlmDestino = 0;
         Z1949TraUSUC = "";
         Z1952TraUSUFT = (DateTime)(DateTime.MinValue);
         Z1948trasts = "";
         Z1946TraMVACodE = "";
         Z1950TraUsuE = "";
         Z1951TraUsuFE = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll1H51( )
      {
         A65TraMVATip = "";
         AssignAttri("", false, "A65TraMVATip", A65TraMVATip);
         A66TraMVACod = "";
         AssignAttri("", false, "A66TraMVACod", A66TraMVACod);
         InitializeNonKey1H51( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810235295", true, true);
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
         context.AddJavascriptSource("atransferencia.js", "?202281810235296", false, true);
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
         edtTraMVATip_Internalname = "TRAMVATIP";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTraMVACod_Internalname = "TRAMVACOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtTraFec_Internalname = "TRAFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtTraAlmDestino_Internalname = "TRAALMDESTINO";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtTraUSUC_Internalname = "TRAUSUC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtTraUSUFT_Internalname = "TRAUSUFT";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edttrasts_Internalname = "TRASTS";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtTraMVACodE_Internalname = "TRAMVACODE";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtTraUsuE_Internalname = "TRAUSUE";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtTraUsuFE_Internalname = "TRAUSUFE";
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
         Form.Caption = "Transferencia Entre Almacenes";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTraUsuFE_Jsonclick = "";
         edtTraUsuFE_Enabled = 1;
         edtTraUsuE_Jsonclick = "";
         edtTraUsuE_Enabled = 1;
         edtTraMVACodE_Jsonclick = "";
         edtTraMVACodE_Enabled = 1;
         edttrasts_Jsonclick = "";
         edttrasts_Enabled = 1;
         edtTraUSUFT_Jsonclick = "";
         edtTraUSUFT_Enabled = 1;
         edtTraUSUC_Jsonclick = "";
         edtTraUSUC_Enabled = 1;
         edtTraAlmDestino_Jsonclick = "";
         edtTraAlmDestino_Enabled = 1;
         edtTraFec_Jsonclick = "";
         edtTraFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTraMVACod_Jsonclick = "";
         edtTraMVACod_Enabled = 1;
         edtTraMVATip_Jsonclick = "";
         edtTraMVATip_Enabled = 1;
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
         /* Using cursor T001H15 */
         pr_default.execute(13, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Transferencia'.", "ForeignKeyNotFound", 1, "TRAMVACOD");
            AnyError = 1;
            GX_FocusControl = edtTraMVATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1943TraAlmCod = T001H15_A1943TraAlmCod[0];
         A1947TraMVCliCod = T001H15_A1947TraMVCliCod[0];
         n1947TraMVCliCod = T001H15_n1947TraMVCliCod[0];
         pr_default.close(13);
         /* Using cursor T001H16 */
         pr_default.execute(14, new Object[] {A1943TraAlmCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "TRAALMCOD");
            AnyError = 1;
         }
         A1945TraAlmDsc = T001H16_A1945TraAlmDsc[0];
         pr_default.close(14);
         GX_FocusControl = edtTraFec_Internalname;
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

      public void Valid_Tramvacod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001H15 */
         pr_default.execute(13, new Object[] {A65TraMVATip, A66TraMVACod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Transferencia'.", "ForeignKeyNotFound", 1, "TRAMVACOD");
            AnyError = 1;
            GX_FocusControl = edtTraMVATip_Internalname;
         }
         A1943TraAlmCod = T001H15_A1943TraAlmCod[0];
         A1947TraMVCliCod = T001H15_A1947TraMVCliCod[0];
         n1947TraMVCliCod = T001H15_n1947TraMVCliCod[0];
         pr_default.close(13);
         /* Using cursor T001H16 */
         pr_default.execute(14, new Object[] {A1943TraAlmCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "TRAALMCOD");
            AnyError = 1;
         }
         A1945TraAlmDsc = T001H16_A1945TraAlmDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A67TraFec", context.localUtil.Format(A67TraFec, "99/99/99"));
         AssignAttri("", false, "A1944TraAlmDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1944TraAlmDestino), 6, 0, ".", "")));
         AssignAttri("", false, "A1949TraUSUC", StringUtil.RTrim( A1949TraUSUC));
         AssignAttri("", false, "A1952TraUSUFT", context.localUtil.TToC( A1952TraUSUFT, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1948trasts", StringUtil.RTrim( A1948trasts));
         AssignAttri("", false, "A1946TraMVACodE", StringUtil.RTrim( A1946TraMVACodE));
         AssignAttri("", false, "A1950TraUsuE", StringUtil.RTrim( A1950TraUsuE));
         AssignAttri("", false, "A1951TraUsuFE", context.localUtil.TToC( A1951TraUsuFE, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1943TraAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1943TraAlmCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1947TraMVCliCod", StringUtil.RTrim( A1947TraMVCliCod));
         AssignAttri("", false, "A1945TraAlmDsc", StringUtil.RTrim( A1945TraAlmDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z65TraMVATip", StringUtil.RTrim( Z65TraMVATip));
         GxWebStd.gx_hidden_field( context, "Z66TraMVACod", StringUtil.RTrim( Z66TraMVACod));
         GxWebStd.gx_hidden_field( context, "Z67TraFec", context.localUtil.Format(Z67TraFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1944TraAlmDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1944TraAlmDestino), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1949TraUSUC", StringUtil.RTrim( Z1949TraUSUC));
         GxWebStd.gx_hidden_field( context, "Z1952TraUSUFT", context.localUtil.TToC( Z1952TraUSUFT, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1948trasts", StringUtil.RTrim( Z1948trasts));
         GxWebStd.gx_hidden_field( context, "Z1946TraMVACodE", StringUtil.RTrim( Z1946TraMVACodE));
         GxWebStd.gx_hidden_field( context, "Z1950TraUsuE", StringUtil.RTrim( Z1950TraUsuE));
         GxWebStd.gx_hidden_field( context, "Z1951TraUsuFE", context.localUtil.TToC( Z1951TraUsuFE, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1943TraAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1943TraAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1947TraMVCliCod", StringUtil.RTrim( Z1947TraMVCliCod));
         GxWebStd.gx_hidden_field( context, "Z1945TraAlmDsc", StringUtil.RTrim( Z1945TraAlmDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("VALID_TRAMVATIP","{handler:'Valid_Tramvatip',iparms:[]");
         setEventMetadata("VALID_TRAMVATIP",",oparms:[]}");
         setEventMetadata("VALID_TRAMVACOD","{handler:'Valid_Tramvacod',iparms:[{av:'A65TraMVATip',fld:'TRAMVATIP',pic:''},{av:'A66TraMVACod',fld:'TRAMVACOD',pic:''},{av:'A1943TraAlmCod',fld:'TRAALMCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TRAMVACOD",",oparms:[{av:'A67TraFec',fld:'TRAFEC',pic:''},{av:'A1944TraAlmDestino',fld:'TRAALMDESTINO',pic:'ZZZZZ9'},{av:'A1949TraUSUC',fld:'TRAUSUC',pic:''},{av:'A1952TraUSUFT',fld:'TRAUSUFT',pic:'99/99/99 99:99'},{av:'A1948trasts',fld:'TRASTS',pic:''},{av:'A1946TraMVACodE',fld:'TRAMVACODE',pic:''},{av:'A1950TraUsuE',fld:'TRAUSUE',pic:''},{av:'A1951TraUsuFE',fld:'TRAUSUFE',pic:'99/99/99 99:99'},{av:'A1943TraAlmCod',fld:'TRAALMCOD',pic:'ZZZZZ9'},{av:'A1947TraMVCliCod',fld:'TRAMVCLICOD',pic:''},{av:'A1945TraAlmDsc',fld:'TRAALMDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z65TraMVATip'},{av:'Z66TraMVACod'},{av:'Z67TraFec'},{av:'Z1944TraAlmDestino'},{av:'Z1949TraUSUC'},{av:'Z1952TraUSUFT'},{av:'Z1948trasts'},{av:'Z1946TraMVACodE'},{av:'Z1950TraUsuE'},{av:'Z1951TraUsuFE'},{av:'Z1943TraAlmCod'},{av:'Z1947TraMVCliCod'},{av:'Z1945TraAlmDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_TRAFEC","{handler:'Valid_Trafec',iparms:[]");
         setEventMetadata("VALID_TRAFEC",",oparms:[]}");
         setEventMetadata("VALID_TRAUSUFT","{handler:'Valid_Trausuft',iparms:[]");
         setEventMetadata("VALID_TRAUSUFT",",oparms:[]}");
         setEventMetadata("VALID_TRAUSUFE","{handler:'Valid_Trausufe',iparms:[]");
         setEventMetadata("VALID_TRAUSUFE",",oparms:[]}");
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
         pr_default.close(13);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z65TraMVATip = "";
         Z66TraMVACod = "";
         Z67TraFec = DateTime.MinValue;
         Z1949TraUSUC = "";
         Z1952TraUSUFT = (DateTime)(DateTime.MinValue);
         Z1948trasts = "";
         Z1946TraMVACodE = "";
         Z1950TraUsuE = "";
         Z1951TraUsuFE = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A65TraMVATip = "";
         A66TraMVACod = "";
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
         A67TraFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         A1949TraUSUC = "";
         lblTextblock6_Jsonclick = "";
         A1952TraUSUFT = (DateTime)(DateTime.MinValue);
         lblTextblock7_Jsonclick = "";
         A1948trasts = "";
         lblTextblock8_Jsonclick = "";
         A1946TraMVACodE = "";
         lblTextblock9_Jsonclick = "";
         A1950TraUsuE = "";
         lblTextblock10_Jsonclick = "";
         A1951TraUsuFE = (DateTime)(DateTime.MinValue);
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         A1947TraMVCliCod = "";
         A1945TraAlmDsc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1947TraMVCliCod = "";
         Z1945TraAlmDsc = "";
         T001H6_A1945TraAlmDsc = new string[] {""} ;
         T001H6_A67TraFec = new DateTime[] {DateTime.MinValue} ;
         T001H6_A1944TraAlmDestino = new int[1] ;
         T001H6_A1949TraUSUC = new string[] {""} ;
         T001H6_A1952TraUSUFT = new DateTime[] {DateTime.MinValue} ;
         T001H6_A1948trasts = new string[] {""} ;
         T001H6_A1946TraMVACodE = new string[] {""} ;
         T001H6_A1950TraUsuE = new string[] {""} ;
         T001H6_A1951TraUsuFE = new DateTime[] {DateTime.MinValue} ;
         T001H6_A65TraMVATip = new string[] {""} ;
         T001H6_A66TraMVACod = new string[] {""} ;
         T001H6_A1943TraAlmCod = new int[1] ;
         T001H6_A1947TraMVCliCod = new string[] {""} ;
         T001H6_n1947TraMVCliCod = new bool[] {false} ;
         T001H4_A1943TraAlmCod = new int[1] ;
         T001H4_A1947TraMVCliCod = new string[] {""} ;
         T001H4_n1947TraMVCliCod = new bool[] {false} ;
         T001H5_A1945TraAlmDsc = new string[] {""} ;
         T001H7_A1943TraAlmCod = new int[1] ;
         T001H7_A1947TraMVCliCod = new string[] {""} ;
         T001H7_n1947TraMVCliCod = new bool[] {false} ;
         T001H8_A1945TraAlmDsc = new string[] {""} ;
         T001H9_A65TraMVATip = new string[] {""} ;
         T001H9_A66TraMVACod = new string[] {""} ;
         T001H3_A67TraFec = new DateTime[] {DateTime.MinValue} ;
         T001H3_A1944TraAlmDestino = new int[1] ;
         T001H3_A1949TraUSUC = new string[] {""} ;
         T001H3_A1952TraUSUFT = new DateTime[] {DateTime.MinValue} ;
         T001H3_A1948trasts = new string[] {""} ;
         T001H3_A1946TraMVACodE = new string[] {""} ;
         T001H3_A1950TraUsuE = new string[] {""} ;
         T001H3_A1951TraUsuFE = new DateTime[] {DateTime.MinValue} ;
         T001H3_A65TraMVATip = new string[] {""} ;
         T001H3_A66TraMVACod = new string[] {""} ;
         sMode51 = "";
         T001H10_A65TraMVATip = new string[] {""} ;
         T001H10_A66TraMVACod = new string[] {""} ;
         T001H11_A65TraMVATip = new string[] {""} ;
         T001H11_A66TraMVACod = new string[] {""} ;
         T001H2_A67TraFec = new DateTime[] {DateTime.MinValue} ;
         T001H2_A1944TraAlmDestino = new int[1] ;
         T001H2_A1949TraUSUC = new string[] {""} ;
         T001H2_A1952TraUSUFT = new DateTime[] {DateTime.MinValue} ;
         T001H2_A1948trasts = new string[] {""} ;
         T001H2_A1946TraMVACodE = new string[] {""} ;
         T001H2_A1950TraUsuE = new string[] {""} ;
         T001H2_A1951TraUsuFE = new DateTime[] {DateTime.MinValue} ;
         T001H2_A65TraMVATip = new string[] {""} ;
         T001H2_A66TraMVACod = new string[] {""} ;
         T001H15_A1943TraAlmCod = new int[1] ;
         T001H15_A1947TraMVCliCod = new string[] {""} ;
         T001H15_n1947TraMVCliCod = new bool[] {false} ;
         T001H16_A1945TraAlmDsc = new string[] {""} ;
         T001H17_A65TraMVATip = new string[] {""} ;
         T001H17_A66TraMVACod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ65TraMVATip = "";
         ZZ66TraMVACod = "";
         ZZ67TraFec = DateTime.MinValue;
         ZZ1949TraUSUC = "";
         ZZ1952TraUSUFT = (DateTime)(DateTime.MinValue);
         ZZ1948trasts = "";
         ZZ1946TraMVACodE = "";
         ZZ1950TraUsuE = "";
         ZZ1951TraUsuFE = (DateTime)(DateTime.MinValue);
         ZZ1947TraMVCliCod = "";
         ZZ1945TraAlmDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.atransferencia__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.atransferencia__default(),
            new Object[][] {
                new Object[] {
               T001H2_A67TraFec, T001H2_A1944TraAlmDestino, T001H2_A1949TraUSUC, T001H2_A1952TraUSUFT, T001H2_A1948trasts, T001H2_A1946TraMVACodE, T001H2_A1950TraUsuE, T001H2_A1951TraUsuFE, T001H2_A65TraMVATip, T001H2_A66TraMVACod
               }
               , new Object[] {
               T001H3_A67TraFec, T001H3_A1944TraAlmDestino, T001H3_A1949TraUSUC, T001H3_A1952TraUSUFT, T001H3_A1948trasts, T001H3_A1946TraMVACodE, T001H3_A1950TraUsuE, T001H3_A1951TraUsuFE, T001H3_A65TraMVATip, T001H3_A66TraMVACod
               }
               , new Object[] {
               T001H4_A1943TraAlmCod, T001H4_A1947TraMVCliCod, T001H4_n1947TraMVCliCod
               }
               , new Object[] {
               T001H5_A1945TraAlmDsc
               }
               , new Object[] {
               T001H6_A1945TraAlmDsc, T001H6_A67TraFec, T001H6_A1944TraAlmDestino, T001H6_A1949TraUSUC, T001H6_A1952TraUSUFT, T001H6_A1948trasts, T001H6_A1946TraMVACodE, T001H6_A1950TraUsuE, T001H6_A1951TraUsuFE, T001H6_A65TraMVATip,
               T001H6_A66TraMVACod, T001H6_A1943TraAlmCod, T001H6_A1947TraMVCliCod, T001H6_n1947TraMVCliCod
               }
               , new Object[] {
               T001H7_A1943TraAlmCod, T001H7_A1947TraMVCliCod, T001H7_n1947TraMVCliCod
               }
               , new Object[] {
               T001H8_A1945TraAlmDsc
               }
               , new Object[] {
               T001H9_A65TraMVATip, T001H9_A66TraMVACod
               }
               , new Object[] {
               T001H10_A65TraMVATip, T001H10_A66TraMVACod
               }
               , new Object[] {
               T001H11_A65TraMVATip, T001H11_A66TraMVACod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001H15_A1943TraAlmCod, T001H15_A1947TraMVCliCod, T001H15_n1947TraMVCliCod
               }
               , new Object[] {
               T001H16_A1945TraAlmDsc
               }
               , new Object[] {
               T001H17_A65TraMVATip, T001H17_A66TraMVACod
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
      private short RcdFound51 ;
      private short nIsDirty_51 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1944TraAlmDestino ;
      private int A1943TraAlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTraMVATip_Enabled ;
      private int edtTraMVACod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTraFec_Enabled ;
      private int A1944TraAlmDestino ;
      private int edtTraAlmDestino_Enabled ;
      private int edtTraUSUC_Enabled ;
      private int edtTraUSUFT_Enabled ;
      private int edttrasts_Enabled ;
      private int edtTraMVACodE_Enabled ;
      private int edtTraUsuE_Enabled ;
      private int edtTraUsuFE_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int Z1943TraAlmCod ;
      private int idxLst ;
      private int ZZ1944TraAlmDestino ;
      private int ZZ1943TraAlmCod ;
      private string sPrefix ;
      private string Z65TraMVATip ;
      private string Z66TraMVACod ;
      private string Z1949TraUSUC ;
      private string Z1948trasts ;
      private string Z1946TraMVACodE ;
      private string Z1950TraUsuE ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A65TraMVATip ;
      private string A66TraMVACod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTraMVATip_Internalname ;
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
      private string edtTraMVATip_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTraMVACod_Internalname ;
      private string edtTraMVACod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtTraFec_Internalname ;
      private string edtTraFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtTraAlmDestino_Internalname ;
      private string edtTraAlmDestino_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtTraUSUC_Internalname ;
      private string A1949TraUSUC ;
      private string edtTraUSUC_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtTraUSUFT_Internalname ;
      private string edtTraUSUFT_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edttrasts_Internalname ;
      private string A1948trasts ;
      private string edttrasts_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtTraMVACodE_Internalname ;
      private string A1946TraMVACodE ;
      private string edtTraMVACodE_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtTraUsuE_Internalname ;
      private string A1950TraUsuE ;
      private string edtTraUsuE_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtTraUsuFE_Internalname ;
      private string edtTraUsuFE_Jsonclick ;
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
      private string A1947TraMVCliCod ;
      private string A1945TraAlmDsc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1947TraMVCliCod ;
      private string Z1945TraAlmDsc ;
      private string sMode51 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ65TraMVATip ;
      private string ZZ66TraMVACod ;
      private string ZZ1949TraUSUC ;
      private string ZZ1948trasts ;
      private string ZZ1946TraMVACodE ;
      private string ZZ1950TraUsuE ;
      private string ZZ1947TraMVCliCod ;
      private string ZZ1945TraAlmDsc ;
      private DateTime Z1952TraUSUFT ;
      private DateTime Z1951TraUsuFE ;
      private DateTime A1952TraUSUFT ;
      private DateTime A1951TraUsuFE ;
      private DateTime ZZ1952TraUSUFT ;
      private DateTime ZZ1951TraUsuFE ;
      private DateTime Z67TraFec ;
      private DateTime A67TraFec ;
      private DateTime ZZ67TraFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1947TraMVCliCod ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001H6_A1945TraAlmDsc ;
      private DateTime[] T001H6_A67TraFec ;
      private int[] T001H6_A1944TraAlmDestino ;
      private string[] T001H6_A1949TraUSUC ;
      private DateTime[] T001H6_A1952TraUSUFT ;
      private string[] T001H6_A1948trasts ;
      private string[] T001H6_A1946TraMVACodE ;
      private string[] T001H6_A1950TraUsuE ;
      private DateTime[] T001H6_A1951TraUsuFE ;
      private string[] T001H6_A65TraMVATip ;
      private string[] T001H6_A66TraMVACod ;
      private int[] T001H6_A1943TraAlmCod ;
      private string[] T001H6_A1947TraMVCliCod ;
      private bool[] T001H6_n1947TraMVCliCod ;
      private int[] T001H4_A1943TraAlmCod ;
      private string[] T001H4_A1947TraMVCliCod ;
      private bool[] T001H4_n1947TraMVCliCod ;
      private string[] T001H5_A1945TraAlmDsc ;
      private int[] T001H7_A1943TraAlmCod ;
      private string[] T001H7_A1947TraMVCliCod ;
      private bool[] T001H7_n1947TraMVCliCod ;
      private string[] T001H8_A1945TraAlmDsc ;
      private string[] T001H9_A65TraMVATip ;
      private string[] T001H9_A66TraMVACod ;
      private DateTime[] T001H3_A67TraFec ;
      private int[] T001H3_A1944TraAlmDestino ;
      private string[] T001H3_A1949TraUSUC ;
      private DateTime[] T001H3_A1952TraUSUFT ;
      private string[] T001H3_A1948trasts ;
      private string[] T001H3_A1946TraMVACodE ;
      private string[] T001H3_A1950TraUsuE ;
      private DateTime[] T001H3_A1951TraUsuFE ;
      private string[] T001H3_A65TraMVATip ;
      private string[] T001H3_A66TraMVACod ;
      private string[] T001H10_A65TraMVATip ;
      private string[] T001H10_A66TraMVACod ;
      private string[] T001H11_A65TraMVATip ;
      private string[] T001H11_A66TraMVACod ;
      private DateTime[] T001H2_A67TraFec ;
      private int[] T001H2_A1944TraAlmDestino ;
      private string[] T001H2_A1949TraUSUC ;
      private DateTime[] T001H2_A1952TraUSUFT ;
      private string[] T001H2_A1948trasts ;
      private string[] T001H2_A1946TraMVACodE ;
      private string[] T001H2_A1950TraUsuE ;
      private DateTime[] T001H2_A1951TraUsuFE ;
      private string[] T001H2_A65TraMVATip ;
      private string[] T001H2_A66TraMVACod ;
      private int[] T001H15_A1943TraAlmCod ;
      private string[] T001H15_A1947TraMVCliCod ;
      private bool[] T001H15_n1947TraMVCliCod ;
      private string[] T001H16_A1945TraAlmDsc ;
      private string[] T001H17_A65TraMVATip ;
      private string[] T001H17_A66TraMVACod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class atransferencia__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class atransferencia__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001H6;
        prmT001H6 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H4;
        prmT001H4 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H5;
        prmT001H5 = new Object[] {
        new ParDef("@TraAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001H7;
        prmT001H7 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H8;
        prmT001H8 = new Object[] {
        new ParDef("@TraAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001H9;
        prmT001H9 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H3;
        prmT001H3 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H10;
        prmT001H10 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H11;
        prmT001H11 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H2;
        prmT001H2 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H12;
        prmT001H12 = new Object[] {
        new ParDef("@TraFec",GXType.Date,8,0) ,
        new ParDef("@TraAlmDestino",GXType.Int32,6,0) ,
        new ParDef("@TraUSUC",GXType.NChar,10,0) ,
        new ParDef("@TraUSUFT",GXType.DateTime,8,5) ,
        new ParDef("@trasts",GXType.NChar,1,0) ,
        new ParDef("@TraMVACodE",GXType.NChar,12,0) ,
        new ParDef("@TraUsuE",GXType.NChar,10,0) ,
        new ParDef("@TraUsuFE",GXType.DateTime,8,5) ,
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H13;
        prmT001H13 = new Object[] {
        new ParDef("@TraFec",GXType.Date,8,0) ,
        new ParDef("@TraAlmDestino",GXType.Int32,6,0) ,
        new ParDef("@TraUSUC",GXType.NChar,10,0) ,
        new ParDef("@TraUSUFT",GXType.DateTime,8,5) ,
        new ParDef("@trasts",GXType.NChar,1,0) ,
        new ParDef("@TraMVACodE",GXType.NChar,12,0) ,
        new ParDef("@TraUsuE",GXType.NChar,10,0) ,
        new ParDef("@TraUsuFE",GXType.DateTime,8,5) ,
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H14;
        prmT001H14 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H17;
        prmT001H17 = new Object[] {
        };
        Object[] prmT001H15;
        prmT001H15 = new Object[] {
        new ParDef("@TraMVATip",GXType.NChar,3,0) ,
        new ParDef("@TraMVACod",GXType.NChar,12,0)
        };
        Object[] prmT001H16;
        prmT001H16 = new Object[] {
        new ParDef("@TraAlmCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001H2", "SELECT [TraFec], [TraAlmDestino], [TraUSUC], [TraUSUFT], [trasts], [TraMVACodE], [TraUsuE], [TraUsuFE], [TraMVATip] AS TraMVATip, [TraMVACod] AS TraMVACod FROM [ATRANSFERENCIA] WITH (UPDLOCK) WHERE [TraMVATip] = @TraMVATip AND [TraMVACod] = @TraMVACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H3", "SELECT [TraFec], [TraAlmDestino], [TraUSUC], [TraUSUFT], [trasts], [TraMVACodE], [TraUsuE], [TraUsuFE], [TraMVATip] AS TraMVATip, [TraMVACod] AS TraMVACod FROM [ATRANSFERENCIA] WHERE [TraMVATip] = @TraMVATip AND [TraMVACod] = @TraMVACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H4", "SELECT [MvAlm] AS TraAlmCod, [MVCliCod] AS TraMVCliCod FROM [AGUIAS] WHERE [MvATip] = @TraMVATip AND [MvACod] = @TraMVACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H5", "SELECT [AlmDsc] AS TraAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @TraAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H6", "SELECT T3.[AlmDsc] AS TraAlmDsc, TM1.[TraFec], TM1.[TraAlmDestino], TM1.[TraUSUC], TM1.[TraUSUFT], TM1.[trasts], TM1.[TraMVACodE], TM1.[TraUsuE], TM1.[TraUsuFE], TM1.[TraMVATip] AS TraMVATip, TM1.[TraMVACod] AS TraMVACod, T2.[MvAlm] AS TraAlmCod, T2.[MVCliCod] AS TraMVCliCod FROM (([ATRANSFERENCIA] TM1 INNER JOIN [AGUIAS] T2 ON T2.[MvATip] = TM1.[TraMVATip] AND T2.[MvACod] = TM1.[TraMVACod]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = T2.[MvAlm]) WHERE TM1.[TraMVATip] = @TraMVATip and TM1.[TraMVACod] = @TraMVACod ORDER BY TM1.[TraMVATip], TM1.[TraMVACod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H7", "SELECT [MvAlm] AS TraAlmCod, [MVCliCod] AS TraMVCliCod FROM [AGUIAS] WHERE [MvATip] = @TraMVATip AND [MvACod] = @TraMVACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H8", "SELECT [AlmDsc] AS TraAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @TraAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H9", "SELECT [TraMVATip] AS TraMVATip, [TraMVACod] AS TraMVACod FROM [ATRANSFERENCIA] WHERE [TraMVATip] = @TraMVATip AND [TraMVACod] = @TraMVACod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H10", "SELECT TOP 1 [TraMVATip] AS TraMVATip, [TraMVACod] AS TraMVACod FROM [ATRANSFERENCIA] WHERE ( [TraMVATip] > @TraMVATip or [TraMVATip] = @TraMVATip and [TraMVACod] > @TraMVACod) ORDER BY [TraMVATip], [TraMVACod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001H11", "SELECT TOP 1 [TraMVATip] AS TraMVATip, [TraMVACod] AS TraMVACod FROM [ATRANSFERENCIA] WHERE ( [TraMVATip] < @TraMVATip or [TraMVATip] = @TraMVATip and [TraMVACod] < @TraMVACod) ORDER BY [TraMVATip] DESC, [TraMVACod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001H12", "INSERT INTO [ATRANSFERENCIA]([TraFec], [TraAlmDestino], [TraUSUC], [TraUSUFT], [trasts], [TraMVACodE], [TraUsuE], [TraUsuFE], [TraMVATip], [TraMVACod]) VALUES(@TraFec, @TraAlmDestino, @TraUSUC, @TraUSUFT, @trasts, @TraMVACodE, @TraUsuE, @TraUsuFE, @TraMVATip, @TraMVACod)", GxErrorMask.GX_NOMASK,prmT001H12)
           ,new CursorDef("T001H13", "UPDATE [ATRANSFERENCIA] SET [TraFec]=@TraFec, [TraAlmDestino]=@TraAlmDestino, [TraUSUC]=@TraUSUC, [TraUSUFT]=@TraUSUFT, [trasts]=@trasts, [TraMVACodE]=@TraMVACodE, [TraUsuE]=@TraUsuE, [TraUsuFE]=@TraUsuFE  WHERE [TraMVATip] = @TraMVATip AND [TraMVACod] = @TraMVACod", GxErrorMask.GX_NOMASK,prmT001H13)
           ,new CursorDef("T001H14", "DELETE FROM [ATRANSFERENCIA]  WHERE [TraMVATip] = @TraMVATip AND [TraMVACod] = @TraMVACod", GxErrorMask.GX_NOMASK,prmT001H14)
           ,new CursorDef("T001H15", "SELECT [MvAlm] AS TraAlmCod, [MVCliCod] AS TraMVCliCod FROM [AGUIAS] WHERE [MvATip] = @TraMVATip AND [MvACod] = @TraMVACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H16", "SELECT [AlmDsc] AS TraAlmDsc FROM [CALMACEN] WHERE [AlmCod] = @TraAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001H16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001H17", "SELECT [TraMVATip] AS TraMVATip, [TraMVACod] AS TraMVACod FROM [ATRANSFERENCIA] ORDER BY [TraMVATip], [TraMVACod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001H17,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 12);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 12);
              return;
           case 1 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 12);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 12);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getString(7, 12);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 12);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
     }
  }

}

}
