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
   public class cplistaprecioshis : GXDataArea
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
            A286CPLisHisProdCod = GetPar( "CPLisHisProdCod");
            AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A286CPLisHisProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A287CPLisHisPrvCod = GetPar( "CPLisHisPrvCod");
            AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A287CPLisHisPrvCod) ;
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
            Form.Meta.addItem("description", "Historico de Lista de Precios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cplistaprecioshis( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cplistaprecioshis( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPLISTAPRECIOSHIS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Producto", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisHisProdCod_Internalname, StringUtil.RTrim( A286CPLisHisProdCod), StringUtil.RTrim( context.localUtil.Format( A286CPLisHisProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisHisProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisHisProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "R.U.C.", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisHisPrvCod_Internalname, StringUtil.RTrim( A287CPLisHisPrvCod), StringUtil.RTrim( context.localUtil.Format( A287CPLisHisPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisHisPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisHisPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCPLisHisFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCPLisHisFecha_Internalname, context.localUtil.Format(A288CPLisHisFecha, "99/99/99"), context.localUtil.Format( A288CPLisHisFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisHisFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisHisFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLISTAPRECIOSHIS.htm");
         GxWebStd.gx_bitmap( context, edtCPLisHisFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCPLisHisFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Producto", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPLisHisProdDsc_Internalname, StringUtil.RTrim( A825CPLisHisProdDsc), StringUtil.RTrim( context.localUtil.Format( A825CPLisHisProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisHisProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisHisProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Proveedor", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCPLisHisPrvDsc_Internalname, StringUtil.RTrim( A826CPLisHisPrvDsc), StringUtil.RTrim( context.localUtil.Format( A826CPLisHisPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisHisPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisHisPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Importe MN", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisHisImpMN_Internalname, StringUtil.LTrim( StringUtil.NToC( A824CPLisHisImpMN, 17, 4, ".", "")), StringUtil.LTrim( ((edtCPLisHisImpMN_Enabled!=0) ? context.localUtil.Format( A824CPLisHisImpMN, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A824CPLisHisImpMN, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisHisImpMN_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisHisImpMN_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Importe ME", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCPLisHisImpME_Internalname, StringUtil.LTrim( StringUtil.NToC( A823CPLisHisImpME, 17, 4, ".", "")), StringUtil.LTrim( ((edtCPLisHisImpME_Enabled!=0) ? context.localUtil.Format( A823CPLisHisImpME, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A823CPLisHisImpME, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCPLisHisImpME_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCPLisHisImpME_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPLISTAPRECIOSHIS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLISTAPRECIOSHIS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPLISTAPRECIOSHIS.htm");
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
            Z286CPLisHisProdCod = cgiGet( "Z286CPLisHisProdCod");
            Z287CPLisHisPrvCod = cgiGet( "Z287CPLisHisPrvCod");
            Z288CPLisHisFecha = context.localUtil.CToD( cgiGet( "Z288CPLisHisFecha"), 0);
            Z824CPLisHisImpMN = context.localUtil.CToN( cgiGet( "Z824CPLisHisImpMN"), ".", ",");
            Z823CPLisHisImpME = context.localUtil.CToN( cgiGet( "Z823CPLisHisImpME"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A286CPLisHisProdCod = StringUtil.Upper( cgiGet( edtCPLisHisProdCod_Internalname));
            AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
            A287CPLisHisPrvCod = StringUtil.Upper( cgiGet( edtCPLisHisPrvCod_Internalname));
            AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
            if ( context.localUtil.VCDate( cgiGet( edtCPLisHisFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "CPLISHISFECHA");
               AnyError = 1;
               GX_FocusControl = edtCPLisHisFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A288CPLisHisFecha = DateTime.MinValue;
               AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
            }
            else
            {
               A288CPLisHisFecha = context.localUtil.CToD( cgiGet( edtCPLisHisFecha_Internalname), 2);
               AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
            }
            A825CPLisHisProdDsc = cgiGet( edtCPLisHisProdDsc_Internalname);
            AssignAttri("", false, "A825CPLisHisProdDsc", A825CPLisHisProdDsc);
            A826CPLisHisPrvDsc = cgiGet( edtCPLisHisPrvDsc_Internalname);
            AssignAttri("", false, "A826CPLisHisPrvDsc", A826CPLisHisPrvDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPLisHisImpMN_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCPLisHisImpMN_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPLISHISIMPMN");
               AnyError = 1;
               GX_FocusControl = edtCPLisHisImpMN_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A824CPLisHisImpMN = 0;
               AssignAttri("", false, "A824CPLisHisImpMN", StringUtil.LTrimStr( A824CPLisHisImpMN, 15, 4));
            }
            else
            {
               A824CPLisHisImpMN = context.localUtil.CToN( cgiGet( edtCPLisHisImpMN_Internalname), ".", ",");
               AssignAttri("", false, "A824CPLisHisImpMN", StringUtil.LTrimStr( A824CPLisHisImpMN, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCPLisHisImpME_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCPLisHisImpME_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CPLISHISIMPME");
               AnyError = 1;
               GX_FocusControl = edtCPLisHisImpME_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A823CPLisHisImpME = 0;
               AssignAttri("", false, "A823CPLisHisImpME", StringUtil.LTrimStr( A823CPLisHisImpME, 15, 4));
            }
            else
            {
               A823CPLisHisImpME = context.localUtil.CToN( cgiGet( edtCPLisHisImpME_Internalname), ".", ",");
               AssignAttri("", false, "A823CPLisHisImpME", StringUtil.LTrimStr( A823CPLisHisImpME, 15, 4));
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
               A286CPLisHisProdCod = GetPar( "CPLisHisProdCod");
               AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
               A287CPLisHisPrvCod = GetPar( "CPLisHisPrvCod");
               AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
               A288CPLisHisFecha = context.localUtil.ParseDateParm( GetPar( "CPLisHisFecha"));
               AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
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
               InitAll3H120( ) ;
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
         DisableAttributes3H120( ) ;
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

      protected void CONFIRM_3H0( )
      {
         BeforeValidate3H120( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3H120( ) ;
            }
            else
            {
               CheckExtendedTable3H120( ) ;
               if ( AnyError == 0 )
               {
                  ZM3H120( 3) ;
                  ZM3H120( 4) ;
               }
               CloseExtendedTableCursors3H120( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3H0( ) ;
         }
      }

      protected void ResetCaption3H0( )
      {
      }

      protected void ZM3H120( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z824CPLisHisImpMN = T003H3_A824CPLisHisImpMN[0];
               Z823CPLisHisImpME = T003H3_A823CPLisHisImpME[0];
            }
            else
            {
               Z824CPLisHisImpMN = A824CPLisHisImpMN;
               Z823CPLisHisImpME = A823CPLisHisImpME;
            }
         }
         if ( GX_JID == -2 )
         {
            Z288CPLisHisFecha = A288CPLisHisFecha;
            Z824CPLisHisImpMN = A824CPLisHisImpMN;
            Z823CPLisHisImpME = A823CPLisHisImpME;
            Z286CPLisHisProdCod = A286CPLisHisProdCod;
            Z287CPLisHisPrvCod = A287CPLisHisPrvCod;
            Z825CPLisHisProdDsc = A825CPLisHisProdDsc;
            Z826CPLisHisPrvDsc = A826CPLisHisPrvDsc;
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

      protected void Load3H120( )
      {
         /* Using cursor T003H6 */
         pr_default.execute(4, new Object[] {A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound120 = 1;
            A825CPLisHisProdDsc = T003H6_A825CPLisHisProdDsc[0];
            AssignAttri("", false, "A825CPLisHisProdDsc", A825CPLisHisProdDsc);
            A826CPLisHisPrvDsc = T003H6_A826CPLisHisPrvDsc[0];
            AssignAttri("", false, "A826CPLisHisPrvDsc", A826CPLisHisPrvDsc);
            A824CPLisHisImpMN = T003H6_A824CPLisHisImpMN[0];
            AssignAttri("", false, "A824CPLisHisImpMN", StringUtil.LTrimStr( A824CPLisHisImpMN, 15, 4));
            A823CPLisHisImpME = T003H6_A823CPLisHisImpME[0];
            AssignAttri("", false, "A823CPLisHisImpME", StringUtil.LTrimStr( A823CPLisHisImpME, 15, 4));
            ZM3H120( -2) ;
         }
         pr_default.close(4);
         OnLoadActions3H120( ) ;
      }

      protected void OnLoadActions3H120( )
      {
      }

      protected void CheckExtendedTable3H120( )
      {
         nIsDirty_120 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003H4 */
         pr_default.execute(2, new Object[] {A286CPLisHisProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Producto'.", "ForeignKeyNotFound", 1, "CPLISHISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A825CPLisHisProdDsc = T003H4_A825CPLisHisProdDsc[0];
         AssignAttri("", false, "A825CPLisHisProdDsc", A825CPLisHisProdDsc);
         pr_default.close(2);
         /* Using cursor T003H5 */
         pr_default.execute(3, new Object[] {A287CPLisHisPrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Proveedor'.", "ForeignKeyNotFound", 1, "CPLISHISPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A826CPLisHisPrvDsc = T003H5_A826CPLisHisPrvDsc[0];
         AssignAttri("", false, "A826CPLisHisPrvDsc", A826CPLisHisPrvDsc);
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A288CPLisHisFecha) || ( DateTimeUtil.ResetTime ( A288CPLisHisFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CPLISHISFECHA");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3H120( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A286CPLisHisProdCod )
      {
         /* Using cursor T003H7 */
         pr_default.execute(5, new Object[] {A286CPLisHisProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Producto'.", "ForeignKeyNotFound", 1, "CPLISHISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A825CPLisHisProdDsc = T003H7_A825CPLisHisProdDsc[0];
         AssignAttri("", false, "A825CPLisHisProdDsc", A825CPLisHisProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A825CPLisHisProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_4( string A287CPLisHisPrvCod )
      {
         /* Using cursor T003H8 */
         pr_default.execute(6, new Object[] {A287CPLisHisPrvCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Proveedor'.", "ForeignKeyNotFound", 1, "CPLISHISPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A826CPLisHisPrvDsc = T003H8_A826CPLisHisPrvDsc[0];
         AssignAttri("", false, "A826CPLisHisPrvDsc", A826CPLisHisPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A826CPLisHisPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey3H120( )
      {
         /* Using cursor T003H9 */
         pr_default.execute(7, new Object[] {A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound120 = 1;
         }
         else
         {
            RcdFound120 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003H3 */
         pr_default.execute(1, new Object[] {A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3H120( 2) ;
            RcdFound120 = 1;
            A288CPLisHisFecha = T003H3_A288CPLisHisFecha[0];
            AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
            A824CPLisHisImpMN = T003H3_A824CPLisHisImpMN[0];
            AssignAttri("", false, "A824CPLisHisImpMN", StringUtil.LTrimStr( A824CPLisHisImpMN, 15, 4));
            A823CPLisHisImpME = T003H3_A823CPLisHisImpME[0];
            AssignAttri("", false, "A823CPLisHisImpME", StringUtil.LTrimStr( A823CPLisHisImpME, 15, 4));
            A286CPLisHisProdCod = T003H3_A286CPLisHisProdCod[0];
            AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
            A287CPLisHisPrvCod = T003H3_A287CPLisHisPrvCod[0];
            AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
            Z286CPLisHisProdCod = A286CPLisHisProdCod;
            Z287CPLisHisPrvCod = A287CPLisHisPrvCod;
            Z288CPLisHisFecha = A288CPLisHisFecha;
            sMode120 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3H120( ) ;
            if ( AnyError == 1 )
            {
               RcdFound120 = 0;
               InitializeNonKey3H120( ) ;
            }
            Gx_mode = sMode120;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound120 = 0;
            InitializeNonKey3H120( ) ;
            sMode120 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode120;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3H120( ) ;
         if ( RcdFound120 == 0 )
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
         RcdFound120 = 0;
         /* Using cursor T003H10 */
         pr_default.execute(8, new Object[] {A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003H10_A286CPLisHisProdCod[0], A286CPLisHisProdCod) < 0 ) || ( StringUtil.StrCmp(T003H10_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( StringUtil.StrCmp(T003H10_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) < 0 ) || ( StringUtil.StrCmp(T003H10_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) == 0 ) && ( StringUtil.StrCmp(T003H10_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( DateTimeUtil.ResetTime ( T003H10_A288CPLisHisFecha[0] ) < DateTimeUtil.ResetTime ( A288CPLisHisFecha ) ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003H10_A286CPLisHisProdCod[0], A286CPLisHisProdCod) > 0 ) || ( StringUtil.StrCmp(T003H10_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( StringUtil.StrCmp(T003H10_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) > 0 ) || ( StringUtil.StrCmp(T003H10_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) == 0 ) && ( StringUtil.StrCmp(T003H10_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( DateTimeUtil.ResetTime ( T003H10_A288CPLisHisFecha[0] ) > DateTimeUtil.ResetTime ( A288CPLisHisFecha ) ) ) )
            {
               A286CPLisHisProdCod = T003H10_A286CPLisHisProdCod[0];
               AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
               A287CPLisHisPrvCod = T003H10_A287CPLisHisPrvCod[0];
               AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
               A288CPLisHisFecha = T003H10_A288CPLisHisFecha[0];
               AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
               RcdFound120 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound120 = 0;
         /* Using cursor T003H11 */
         pr_default.execute(9, new Object[] {A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003H11_A286CPLisHisProdCod[0], A286CPLisHisProdCod) > 0 ) || ( StringUtil.StrCmp(T003H11_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( StringUtil.StrCmp(T003H11_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) > 0 ) || ( StringUtil.StrCmp(T003H11_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) == 0 ) && ( StringUtil.StrCmp(T003H11_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( DateTimeUtil.ResetTime ( T003H11_A288CPLisHisFecha[0] ) > DateTimeUtil.ResetTime ( A288CPLisHisFecha ) ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003H11_A286CPLisHisProdCod[0], A286CPLisHisProdCod) < 0 ) || ( StringUtil.StrCmp(T003H11_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( StringUtil.StrCmp(T003H11_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) < 0 ) || ( StringUtil.StrCmp(T003H11_A287CPLisHisPrvCod[0], A287CPLisHisPrvCod) == 0 ) && ( StringUtil.StrCmp(T003H11_A286CPLisHisProdCod[0], A286CPLisHisProdCod) == 0 ) && ( DateTimeUtil.ResetTime ( T003H11_A288CPLisHisFecha[0] ) < DateTimeUtil.ResetTime ( A288CPLisHisFecha ) ) ) )
            {
               A286CPLisHisProdCod = T003H11_A286CPLisHisProdCod[0];
               AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
               A287CPLisHisPrvCod = T003H11_A287CPLisHisPrvCod[0];
               AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
               A288CPLisHisFecha = T003H11_A288CPLisHisFecha[0];
               AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
               RcdFound120 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3H120( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3H120( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound120 == 1 )
            {
               if ( ( StringUtil.StrCmp(A286CPLisHisProdCod, Z286CPLisHisProdCod) != 0 ) || ( StringUtil.StrCmp(A287CPLisHisPrvCod, Z287CPLisHisPrvCod) != 0 ) || ( DateTimeUtil.ResetTime ( A288CPLisHisFecha ) != DateTimeUtil.ResetTime ( Z288CPLisHisFecha ) ) )
               {
                  A286CPLisHisProdCod = Z286CPLisHisProdCod;
                  AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
                  A287CPLisHisPrvCod = Z287CPLisHisPrvCod;
                  AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
                  A288CPLisHisFecha = Z288CPLisHisFecha;
                  AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CPLISHISPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPLisHisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCPLisHisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3H120( ) ;
                  GX_FocusControl = edtCPLisHisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A286CPLisHisProdCod, Z286CPLisHisProdCod) != 0 ) || ( StringUtil.StrCmp(A287CPLisHisPrvCod, Z287CPLisHisPrvCod) != 0 ) || ( DateTimeUtil.ResetTime ( A288CPLisHisFecha ) != DateTimeUtil.ResetTime ( Z288CPLisHisFecha ) ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCPLisHisProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3H120( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPLISHISPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCPLisHisProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCPLisHisProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3H120( ) ;
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
         if ( ( StringUtil.StrCmp(A286CPLisHisProdCod, Z286CPLisHisProdCod) != 0 ) || ( StringUtil.StrCmp(A287CPLisHisPrvCod, Z287CPLisHisPrvCod) != 0 ) || ( DateTimeUtil.ResetTime ( A288CPLisHisFecha ) != DateTimeUtil.ResetTime ( Z288CPLisHisFecha ) ) )
         {
            A286CPLisHisProdCod = Z286CPLisHisProdCod;
            AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
            A287CPLisHisPrvCod = Z287CPLisHisPrvCod;
            AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
            A288CPLisHisFecha = Z288CPLisHisFecha;
            AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CPLISHISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
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
         GetKey3H120( ) ;
         if ( RcdFound120 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CPLISHISPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtCPLisHisProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A286CPLisHisProdCod, Z286CPLisHisProdCod) != 0 ) || ( StringUtil.StrCmp(A287CPLisHisPrvCod, Z287CPLisHisPrvCod) != 0 ) || ( DateTimeUtil.ResetTime ( A288CPLisHisFecha ) != DateTimeUtil.ResetTime ( Z288CPLisHisFecha ) ) )
            {
               A286CPLisHisProdCod = Z286CPLisHisProdCod;
               AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
               A287CPLisHisPrvCod = Z287CPLisHisPrvCod;
               AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
               A288CPLisHisFecha = Z288CPLisHisFecha;
               AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CPLISHISPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtCPLisHisProdCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A286CPLisHisProdCod, Z286CPLisHisProdCod) != 0 ) || ( StringUtil.StrCmp(A287CPLisHisPrvCod, Z287CPLisHisPrvCod) != 0 ) || ( DateTimeUtil.ResetTime ( A288CPLisHisFecha ) != DateTimeUtil.ResetTime ( Z288CPLisHisFecha ) ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CPLISHISPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCPLisHisProdCod_Internalname;
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
         context.RollbackDataStores("cplistaprecioshis",pr_default);
         GX_FocusControl = edtCPLisHisImpMN_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3H0( ) ;
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
         if ( RcdFound120 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CPLISHISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCPLisHisImpMN_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3H120( ) ;
         if ( RcdFound120 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPLisHisImpMN_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3H120( ) ;
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
         if ( RcdFound120 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPLisHisImpMN_Internalname;
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
         if ( RcdFound120 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPLisHisImpMN_Internalname;
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
         ScanStart3H120( ) ;
         if ( RcdFound120 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound120 != 0 )
            {
               ScanNext3H120( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCPLisHisImpMN_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3H120( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3H120( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003H2 */
            pr_default.execute(0, new Object[] {A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLISTAPRECIOSHIS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z824CPLisHisImpMN != T003H2_A824CPLisHisImpMN[0] ) || ( Z823CPLisHisImpME != T003H2_A823CPLisHisImpME[0] ) )
            {
               if ( Z824CPLisHisImpMN != T003H2_A824CPLisHisImpMN[0] )
               {
                  GXUtil.WriteLog("cplistaprecioshis:[seudo value changed for attri]"+"CPLisHisImpMN");
                  GXUtil.WriteLogRaw("Old: ",Z824CPLisHisImpMN);
                  GXUtil.WriteLogRaw("Current: ",T003H2_A824CPLisHisImpMN[0]);
               }
               if ( Z823CPLisHisImpME != T003H2_A823CPLisHisImpME[0] )
               {
                  GXUtil.WriteLog("cplistaprecioshis:[seudo value changed for attri]"+"CPLisHisImpME");
                  GXUtil.WriteLogRaw("Old: ",Z823CPLisHisImpME);
                  GXUtil.WriteLogRaw("Current: ",T003H2_A823CPLisHisImpME[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPLISTAPRECIOSHIS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3H120( )
      {
         BeforeValidate3H120( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3H120( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3H120( 0) ;
            CheckOptimisticConcurrency3H120( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3H120( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3H120( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003H12 */
                     pr_default.execute(10, new Object[] {A288CPLisHisFecha, A824CPLisHisImpMN, A823CPLisHisImpME, A286CPLisHisProdCod, A287CPLisHisPrvCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLISTAPRECIOSHIS");
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
                           ResetCaption3H0( ) ;
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
               Load3H120( ) ;
            }
            EndLevel3H120( ) ;
         }
         CloseExtendedTableCursors3H120( ) ;
      }

      protected void Update3H120( )
      {
         BeforeValidate3H120( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3H120( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3H120( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3H120( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3H120( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003H13 */
                     pr_default.execute(11, new Object[] {A824CPLisHisImpMN, A823CPLisHisImpME, A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLISTAPRECIOSHIS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLISTAPRECIOSHIS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3H120( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3H0( ) ;
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
            EndLevel3H120( ) ;
         }
         CloseExtendedTableCursors3H120( ) ;
      }

      protected void DeferredUpdate3H120( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3H120( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3H120( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3H120( ) ;
            AfterConfirm3H120( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3H120( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003H14 */
                  pr_default.execute(12, new Object[] {A286CPLisHisProdCod, A287CPLisHisPrvCod, A288CPLisHisFecha});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPLISTAPRECIOSHIS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound120 == 0 )
                        {
                           InitAll3H120( ) ;
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
                        ResetCaption3H0( ) ;
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
         sMode120 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3H120( ) ;
         Gx_mode = sMode120;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3H120( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003H15 */
            pr_default.execute(13, new Object[] {A286CPLisHisProdCod});
            A825CPLisHisProdDsc = T003H15_A825CPLisHisProdDsc[0];
            AssignAttri("", false, "A825CPLisHisProdDsc", A825CPLisHisProdDsc);
            pr_default.close(13);
            /* Using cursor T003H16 */
            pr_default.execute(14, new Object[] {A287CPLisHisPrvCod});
            A826CPLisHisPrvDsc = T003H16_A826CPLisHisPrvDsc[0];
            AssignAttri("", false, "A826CPLisHisPrvDsc", A826CPLisHisPrvDsc);
            pr_default.close(14);
         }
      }

      protected void EndLevel3H120( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3H120( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("cplistaprecioshis",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3H0( ) ;
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
            context.RollbackDataStores("cplistaprecioshis",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3H120( )
      {
         /* Using cursor T003H17 */
         pr_default.execute(15);
         RcdFound120 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound120 = 1;
            A286CPLisHisProdCod = T003H17_A286CPLisHisProdCod[0];
            AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
            A287CPLisHisPrvCod = T003H17_A287CPLisHisPrvCod[0];
            AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
            A288CPLisHisFecha = T003H17_A288CPLisHisFecha[0];
            AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3H120( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound120 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound120 = 1;
            A286CPLisHisProdCod = T003H17_A286CPLisHisProdCod[0];
            AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
            A287CPLisHisPrvCod = T003H17_A287CPLisHisPrvCod[0];
            AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
            A288CPLisHisFecha = T003H17_A288CPLisHisFecha[0];
            AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
         }
      }

      protected void ScanEnd3H120( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm3H120( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3H120( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3H120( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3H120( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3H120( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3H120( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3H120( )
      {
         edtCPLisHisProdCod_Enabled = 0;
         AssignProp("", false, edtCPLisHisProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisHisProdCod_Enabled), 5, 0), true);
         edtCPLisHisPrvCod_Enabled = 0;
         AssignProp("", false, edtCPLisHisPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisHisPrvCod_Enabled), 5, 0), true);
         edtCPLisHisFecha_Enabled = 0;
         AssignProp("", false, edtCPLisHisFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisHisFecha_Enabled), 5, 0), true);
         edtCPLisHisProdDsc_Enabled = 0;
         AssignProp("", false, edtCPLisHisProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisHisProdDsc_Enabled), 5, 0), true);
         edtCPLisHisPrvDsc_Enabled = 0;
         AssignProp("", false, edtCPLisHisPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisHisPrvDsc_Enabled), 5, 0), true);
         edtCPLisHisImpMN_Enabled = 0;
         AssignProp("", false, edtCPLisHisImpMN_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisHisImpMN_Enabled), 5, 0), true);
         edtCPLisHisImpME_Enabled = 0;
         AssignProp("", false, edtCPLisHisImpME_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCPLisHisImpME_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3H120( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3H0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810251162", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cplistaprecioshis.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z286CPLisHisProdCod", StringUtil.RTrim( Z286CPLisHisProdCod));
         GxWebStd.gx_hidden_field( context, "Z287CPLisHisPrvCod", StringUtil.RTrim( Z287CPLisHisPrvCod));
         GxWebStd.gx_hidden_field( context, "Z288CPLisHisFecha", context.localUtil.DToC( Z288CPLisHisFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z824CPLisHisImpMN", StringUtil.LTrim( StringUtil.NToC( Z824CPLisHisImpMN, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z823CPLisHisImpME", StringUtil.LTrim( StringUtil.NToC( Z823CPLisHisImpME, 15, 4, ".", "")));
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
         return formatLink("cplistaprecioshis.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPLISTAPRECIOSHIS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Historico de Lista de Precios" ;
      }

      protected void InitializeNonKey3H120( )
      {
         A825CPLisHisProdDsc = "";
         AssignAttri("", false, "A825CPLisHisProdDsc", A825CPLisHisProdDsc);
         A826CPLisHisPrvDsc = "";
         AssignAttri("", false, "A826CPLisHisPrvDsc", A826CPLisHisPrvDsc);
         A824CPLisHisImpMN = 0;
         AssignAttri("", false, "A824CPLisHisImpMN", StringUtil.LTrimStr( A824CPLisHisImpMN, 15, 4));
         A823CPLisHisImpME = 0;
         AssignAttri("", false, "A823CPLisHisImpME", StringUtil.LTrimStr( A823CPLisHisImpME, 15, 4));
         Z824CPLisHisImpMN = 0;
         Z823CPLisHisImpME = 0;
      }

      protected void InitAll3H120( )
      {
         A286CPLisHisProdCod = "";
         AssignAttri("", false, "A286CPLisHisProdCod", A286CPLisHisProdCod);
         A287CPLisHisPrvCod = "";
         AssignAttri("", false, "A287CPLisHisPrvCod", A287CPLisHisPrvCod);
         A288CPLisHisFecha = DateTime.MinValue;
         AssignAttri("", false, "A288CPLisHisFecha", context.localUtil.Format(A288CPLisHisFecha, "99/99/99"));
         InitializeNonKey3H120( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810251169", true, true);
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
         context.AddJavascriptSource("cplistaprecioshis.js", "?202281810251170", false, true);
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
         edtCPLisHisProdCod_Internalname = "CPLISHISPRODCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCPLisHisPrvCod_Internalname = "CPLISHISPRVCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCPLisHisFecha_Internalname = "CPLISHISFECHA";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCPLisHisProdDsc_Internalname = "CPLISHISPRODDSC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCPLisHisPrvDsc_Internalname = "CPLISHISPRVDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCPLisHisImpMN_Internalname = "CPLISHISIMPMN";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCPLisHisImpME_Internalname = "CPLISHISIMPME";
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
         Form.Caption = "Historico de Lista de Precios";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCPLisHisImpME_Jsonclick = "";
         edtCPLisHisImpME_Enabled = 1;
         edtCPLisHisImpMN_Jsonclick = "";
         edtCPLisHisImpMN_Enabled = 1;
         edtCPLisHisPrvDsc_Jsonclick = "";
         edtCPLisHisPrvDsc_Enabled = 0;
         edtCPLisHisProdDsc_Jsonclick = "";
         edtCPLisHisProdDsc_Enabled = 0;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCPLisHisFecha_Jsonclick = "";
         edtCPLisHisFecha_Enabled = 1;
         edtCPLisHisPrvCod_Jsonclick = "";
         edtCPLisHisPrvCod_Enabled = 1;
         edtCPLisHisProdCod_Jsonclick = "";
         edtCPLisHisProdCod_Enabled = 1;
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
         /* Using cursor T003H15 */
         pr_default.execute(13, new Object[] {A286CPLisHisProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Producto'.", "ForeignKeyNotFound", 1, "CPLISHISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A825CPLisHisProdDsc = T003H15_A825CPLisHisProdDsc[0];
         AssignAttri("", false, "A825CPLisHisProdDsc", A825CPLisHisProdDsc);
         pr_default.close(13);
         /* Using cursor T003H16 */
         pr_default.execute(14, new Object[] {A287CPLisHisPrvCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Proveedor'.", "ForeignKeyNotFound", 1, "CPLISHISPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A826CPLisHisPrvDsc = T003H16_A826CPLisHisPrvDsc[0];
         AssignAttri("", false, "A826CPLisHisPrvDsc", A826CPLisHisPrvDsc);
         pr_default.close(14);
         GX_FocusControl = edtCPLisHisImpMN_Internalname;
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

      public void Valid_Cplishisprodcod( )
      {
         /* Using cursor T003H15 */
         pr_default.execute(13, new Object[] {A286CPLisHisProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Producto'.", "ForeignKeyNotFound", 1, "CPLISHISPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisProdCod_Internalname;
         }
         A825CPLisHisProdDsc = T003H15_A825CPLisHisProdDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A825CPLisHisProdDsc", StringUtil.RTrim( A825CPLisHisProdDsc));
      }

      public void Valid_Cplishisprvcod( )
      {
         /* Using cursor T003H16 */
         pr_default.execute(14, new Object[] {A287CPLisHisPrvCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Lista Historico Proveedor'.", "ForeignKeyNotFound", 1, "CPLISHISPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisPrvCod_Internalname;
         }
         A826CPLisHisPrvDsc = T003H16_A826CPLisHisPrvDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A826CPLisHisPrvDsc", StringUtil.RTrim( A826CPLisHisPrvDsc));
      }

      public void Valid_Cplishisfecha( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         if ( ! ( (DateTime.MinValue==A288CPLisHisFecha) || ( DateTimeUtil.ResetTime ( A288CPLisHisFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CPLISHISFECHA");
            AnyError = 1;
            GX_FocusControl = edtCPLisHisFecha_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A824CPLisHisImpMN", StringUtil.LTrim( StringUtil.NToC( A824CPLisHisImpMN, 15, 4, ".", "")));
         AssignAttri("", false, "A823CPLisHisImpME", StringUtil.LTrim( StringUtil.NToC( A823CPLisHisImpME, 15, 4, ".", "")));
         AssignAttri("", false, "A825CPLisHisProdDsc", StringUtil.RTrim( A825CPLisHisProdDsc));
         AssignAttri("", false, "A826CPLisHisPrvDsc", StringUtil.RTrim( A826CPLisHisPrvDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z286CPLisHisProdCod", StringUtil.RTrim( Z286CPLisHisProdCod));
         GxWebStd.gx_hidden_field( context, "Z287CPLisHisPrvCod", StringUtil.RTrim( Z287CPLisHisPrvCod));
         GxWebStd.gx_hidden_field( context, "Z288CPLisHisFecha", context.localUtil.Format(Z288CPLisHisFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z824CPLisHisImpMN", StringUtil.LTrim( StringUtil.NToC( Z824CPLisHisImpMN, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z823CPLisHisImpME", StringUtil.LTrim( StringUtil.NToC( Z823CPLisHisImpME, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z825CPLisHisProdDsc", StringUtil.RTrim( Z825CPLisHisProdDsc));
         GxWebStd.gx_hidden_field( context, "Z826CPLisHisPrvDsc", StringUtil.RTrim( Z826CPLisHisPrvDsc));
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
         setEventMetadata("VALID_CPLISHISPRODCOD","{handler:'Valid_Cplishisprodcod',iparms:[{av:'A286CPLisHisProdCod',fld:'CPLISHISPRODCOD',pic:'@!'},{av:'A825CPLisHisProdDsc',fld:'CPLISHISPRODDSC',pic:''}]");
         setEventMetadata("VALID_CPLISHISPRODCOD",",oparms:[{av:'A825CPLisHisProdDsc',fld:'CPLISHISPRODDSC',pic:''}]}");
         setEventMetadata("VALID_CPLISHISPRVCOD","{handler:'Valid_Cplishisprvcod',iparms:[{av:'A287CPLisHisPrvCod',fld:'CPLISHISPRVCOD',pic:'@!'},{av:'A826CPLisHisPrvDsc',fld:'CPLISHISPRVDSC',pic:''}]");
         setEventMetadata("VALID_CPLISHISPRVCOD",",oparms:[{av:'A826CPLisHisPrvDsc',fld:'CPLISHISPRVDSC',pic:''}]}");
         setEventMetadata("VALID_CPLISHISFECHA","{handler:'Valid_Cplishisfecha',iparms:[{av:'A286CPLisHisProdCod',fld:'CPLISHISPRODCOD',pic:'@!'},{av:'A287CPLisHisPrvCod',fld:'CPLISHISPRVCOD',pic:'@!'},{av:'A288CPLisHisFecha',fld:'CPLISHISFECHA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CPLISHISFECHA",",oparms:[{av:'A824CPLisHisImpMN',fld:'CPLISHISIMPMN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A823CPLisHisImpME',fld:'CPLISHISIMPME',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A825CPLisHisProdDsc',fld:'CPLISHISPRODDSC',pic:''},{av:'A826CPLisHisPrvDsc',fld:'CPLISHISPRVDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z286CPLisHisProdCod'},{av:'Z287CPLisHisPrvCod'},{av:'Z288CPLisHisFecha'},{av:'Z824CPLisHisImpMN'},{av:'Z823CPLisHisImpME'},{av:'Z825CPLisHisProdDsc'},{av:'Z826CPLisHisPrvDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z286CPLisHisProdCod = "";
         Z287CPLisHisPrvCod = "";
         Z288CPLisHisFecha = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A286CPLisHisProdCod = "";
         A287CPLisHisPrvCod = "";
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
         A288CPLisHisFecha = DateTime.MinValue;
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A825CPLisHisProdDsc = "";
         lblTextblock5_Jsonclick = "";
         A826CPLisHisPrvDsc = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
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
         Z825CPLisHisProdDsc = "";
         Z826CPLisHisPrvDsc = "";
         T003H6_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T003H6_A825CPLisHisProdDsc = new string[] {""} ;
         T003H6_A826CPLisHisPrvDsc = new string[] {""} ;
         T003H6_A824CPLisHisImpMN = new decimal[1] ;
         T003H6_A823CPLisHisImpME = new decimal[1] ;
         T003H6_A286CPLisHisProdCod = new string[] {""} ;
         T003H6_A287CPLisHisPrvCod = new string[] {""} ;
         T003H4_A825CPLisHisProdDsc = new string[] {""} ;
         T003H5_A826CPLisHisPrvDsc = new string[] {""} ;
         T003H7_A825CPLisHisProdDsc = new string[] {""} ;
         T003H8_A826CPLisHisPrvDsc = new string[] {""} ;
         T003H9_A286CPLisHisProdCod = new string[] {""} ;
         T003H9_A287CPLisHisPrvCod = new string[] {""} ;
         T003H9_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T003H3_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T003H3_A824CPLisHisImpMN = new decimal[1] ;
         T003H3_A823CPLisHisImpME = new decimal[1] ;
         T003H3_A286CPLisHisProdCod = new string[] {""} ;
         T003H3_A287CPLisHisPrvCod = new string[] {""} ;
         sMode120 = "";
         T003H10_A286CPLisHisProdCod = new string[] {""} ;
         T003H10_A287CPLisHisPrvCod = new string[] {""} ;
         T003H10_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T003H11_A286CPLisHisProdCod = new string[] {""} ;
         T003H11_A287CPLisHisPrvCod = new string[] {""} ;
         T003H11_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T003H2_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T003H2_A824CPLisHisImpMN = new decimal[1] ;
         T003H2_A823CPLisHisImpME = new decimal[1] ;
         T003H2_A286CPLisHisProdCod = new string[] {""} ;
         T003H2_A287CPLisHisPrvCod = new string[] {""} ;
         T003H15_A825CPLisHisProdDsc = new string[] {""} ;
         T003H16_A826CPLisHisPrvDsc = new string[] {""} ;
         T003H17_A286CPLisHisProdCod = new string[] {""} ;
         T003H17_A287CPLisHisPrvCod = new string[] {""} ;
         T003H17_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ286CPLisHisProdCod = "";
         ZZ287CPLisHisPrvCod = "";
         ZZ288CPLisHisFecha = DateTime.MinValue;
         ZZ825CPLisHisProdDsc = "";
         ZZ826CPLisHisPrvDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cplistaprecioshis__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cplistaprecioshis__default(),
            new Object[][] {
                new Object[] {
               T003H2_A288CPLisHisFecha, T003H2_A824CPLisHisImpMN, T003H2_A823CPLisHisImpME, T003H2_A286CPLisHisProdCod, T003H2_A287CPLisHisPrvCod
               }
               , new Object[] {
               T003H3_A288CPLisHisFecha, T003H3_A824CPLisHisImpMN, T003H3_A823CPLisHisImpME, T003H3_A286CPLisHisProdCod, T003H3_A287CPLisHisPrvCod
               }
               , new Object[] {
               T003H4_A825CPLisHisProdDsc
               }
               , new Object[] {
               T003H5_A826CPLisHisPrvDsc
               }
               , new Object[] {
               T003H6_A288CPLisHisFecha, T003H6_A825CPLisHisProdDsc, T003H6_A826CPLisHisPrvDsc, T003H6_A824CPLisHisImpMN, T003H6_A823CPLisHisImpME, T003H6_A286CPLisHisProdCod, T003H6_A287CPLisHisPrvCod
               }
               , new Object[] {
               T003H7_A825CPLisHisProdDsc
               }
               , new Object[] {
               T003H8_A826CPLisHisPrvDsc
               }
               , new Object[] {
               T003H9_A286CPLisHisProdCod, T003H9_A287CPLisHisPrvCod, T003H9_A288CPLisHisFecha
               }
               , new Object[] {
               T003H10_A286CPLisHisProdCod, T003H10_A287CPLisHisPrvCod, T003H10_A288CPLisHisFecha
               }
               , new Object[] {
               T003H11_A286CPLisHisProdCod, T003H11_A287CPLisHisPrvCod, T003H11_A288CPLisHisFecha
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003H15_A825CPLisHisProdDsc
               }
               , new Object[] {
               T003H16_A826CPLisHisPrvDsc
               }
               , new Object[] {
               T003H17_A286CPLisHisProdCod, T003H17_A287CPLisHisPrvCod, T003H17_A288CPLisHisFecha
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
      private short RcdFound120 ;
      private short nIsDirty_120 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCPLisHisProdCod_Enabled ;
      private int edtCPLisHisPrvCod_Enabled ;
      private int edtCPLisHisFecha_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCPLisHisProdDsc_Enabled ;
      private int edtCPLisHisPrvDsc_Enabled ;
      private int edtCPLisHisImpMN_Enabled ;
      private int edtCPLisHisImpME_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private decimal Z824CPLisHisImpMN ;
      private decimal Z823CPLisHisImpME ;
      private decimal A824CPLisHisImpMN ;
      private decimal A823CPLisHisImpME ;
      private decimal ZZ824CPLisHisImpMN ;
      private decimal ZZ823CPLisHisImpME ;
      private string sPrefix ;
      private string Z286CPLisHisProdCod ;
      private string Z287CPLisHisPrvCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A286CPLisHisProdCod ;
      private string A287CPLisHisPrvCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCPLisHisProdCod_Internalname ;
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
      private string edtCPLisHisProdCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCPLisHisPrvCod_Internalname ;
      private string edtCPLisHisPrvCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCPLisHisFecha_Internalname ;
      private string edtCPLisHisFecha_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCPLisHisProdDsc_Internalname ;
      private string A825CPLisHisProdDsc ;
      private string edtCPLisHisProdDsc_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCPLisHisPrvDsc_Internalname ;
      private string A826CPLisHisPrvDsc ;
      private string edtCPLisHisPrvDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCPLisHisImpMN_Internalname ;
      private string edtCPLisHisImpMN_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCPLisHisImpME_Internalname ;
      private string edtCPLisHisImpME_Jsonclick ;
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
      private string Z825CPLisHisProdDsc ;
      private string Z826CPLisHisPrvDsc ;
      private string sMode120 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ286CPLisHisProdCod ;
      private string ZZ287CPLisHisPrvCod ;
      private string ZZ825CPLisHisProdDsc ;
      private string ZZ826CPLisHisPrvDsc ;
      private DateTime Z288CPLisHisFecha ;
      private DateTime A288CPLisHisFecha ;
      private DateTime ZZ288CPLisHisFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] T003H6_A288CPLisHisFecha ;
      private string[] T003H6_A825CPLisHisProdDsc ;
      private string[] T003H6_A826CPLisHisPrvDsc ;
      private decimal[] T003H6_A824CPLisHisImpMN ;
      private decimal[] T003H6_A823CPLisHisImpME ;
      private string[] T003H6_A286CPLisHisProdCod ;
      private string[] T003H6_A287CPLisHisPrvCod ;
      private string[] T003H4_A825CPLisHisProdDsc ;
      private string[] T003H5_A826CPLisHisPrvDsc ;
      private string[] T003H7_A825CPLisHisProdDsc ;
      private string[] T003H8_A826CPLisHisPrvDsc ;
      private string[] T003H9_A286CPLisHisProdCod ;
      private string[] T003H9_A287CPLisHisPrvCod ;
      private DateTime[] T003H9_A288CPLisHisFecha ;
      private DateTime[] T003H3_A288CPLisHisFecha ;
      private decimal[] T003H3_A824CPLisHisImpMN ;
      private decimal[] T003H3_A823CPLisHisImpME ;
      private string[] T003H3_A286CPLisHisProdCod ;
      private string[] T003H3_A287CPLisHisPrvCod ;
      private string[] T003H10_A286CPLisHisProdCod ;
      private string[] T003H10_A287CPLisHisPrvCod ;
      private DateTime[] T003H10_A288CPLisHisFecha ;
      private string[] T003H11_A286CPLisHisProdCod ;
      private string[] T003H11_A287CPLisHisPrvCod ;
      private DateTime[] T003H11_A288CPLisHisFecha ;
      private DateTime[] T003H2_A288CPLisHisFecha ;
      private decimal[] T003H2_A824CPLisHisImpMN ;
      private decimal[] T003H2_A823CPLisHisImpME ;
      private string[] T003H2_A286CPLisHisProdCod ;
      private string[] T003H2_A287CPLisHisPrvCod ;
      private string[] T003H15_A825CPLisHisProdDsc ;
      private string[] T003H16_A826CPLisHisPrvDsc ;
      private string[] T003H17_A286CPLisHisProdCod ;
      private string[] T003H17_A287CPLisHisPrvCod ;
      private DateTime[] T003H17_A288CPLisHisFecha ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cplistaprecioshis__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cplistaprecioshis__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003H6;
        prmT003H6 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H4;
        prmT003H4 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003H5;
        prmT003H5 = new Object[] {
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003H7;
        prmT003H7 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003H8;
        prmT003H8 = new Object[] {
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003H9;
        prmT003H9 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H3;
        prmT003H3 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H10;
        prmT003H10 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H11;
        prmT003H11 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H2;
        prmT003H2 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H12;
        prmT003H12 = new Object[] {
        new ParDef("@CPLisHisFecha",GXType.Date,8,0) ,
        new ParDef("@CPLisHisImpMN",GXType.Decimal,15,4) ,
        new ParDef("@CPLisHisImpME",GXType.Decimal,15,4) ,
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003H13;
        prmT003H13 = new Object[] {
        new ParDef("@CPLisHisImpMN",GXType.Decimal,15,4) ,
        new ParDef("@CPLisHisImpME",GXType.Decimal,15,4) ,
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H14;
        prmT003H14 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0) ,
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0) ,
        new ParDef("@CPLisHisFecha",GXType.Date,8,0)
        };
        Object[] prmT003H17;
        prmT003H17 = new Object[] {
        };
        Object[] prmT003H15;
        prmT003H15 = new Object[] {
        new ParDef("@CPLisHisProdCod",GXType.NChar,15,0)
        };
        Object[] prmT003H16;
        prmT003H16 = new Object[] {
        new ParDef("@CPLisHisPrvCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003H2", "SELECT [CPLisHisFecha], [CPLisHisImpMN], [CPLisHisImpME], [CPLisHisProdCod] AS CPLisHisProdCod, [CPLisHisPrvCod] AS CPLisHisPrvCod FROM [CPLISTAPRECIOSHIS] WITH (UPDLOCK) WHERE [CPLisHisProdCod] = @CPLisHisProdCod AND [CPLisHisPrvCod] = @CPLisHisPrvCod AND [CPLisHisFecha] = @CPLisHisFecha ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H3", "SELECT [CPLisHisFecha], [CPLisHisImpMN], [CPLisHisImpME], [CPLisHisProdCod] AS CPLisHisProdCod, [CPLisHisPrvCod] AS CPLisHisPrvCod FROM [CPLISTAPRECIOSHIS] WHERE [CPLisHisProdCod] = @CPLisHisProdCod AND [CPLisHisPrvCod] = @CPLisHisPrvCod AND [CPLisHisFecha] = @CPLisHisFecha ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H4", "SELECT [ProdDsc] AS CPLisHisProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CPLisHisProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H5", "SELECT [PrvDsc] AS CPLisHisPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CPLisHisPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H6", "SELECT TM1.[CPLisHisFecha], T2.[ProdDsc] AS CPLisHisProdDsc, T3.[PrvDsc] AS CPLisHisPrvDsc, TM1.[CPLisHisImpMN], TM1.[CPLisHisImpME], TM1.[CPLisHisProdCod] AS CPLisHisProdCod, TM1.[CPLisHisPrvCod] AS CPLisHisPrvCod FROM (([CPLISTAPRECIOSHIS] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[CPLisHisProdCod]) INNER JOIN [CPPROVEEDORES] T3 ON T3.[PrvCod] = TM1.[CPLisHisPrvCod]) WHERE TM1.[CPLisHisProdCod] = @CPLisHisProdCod and TM1.[CPLisHisPrvCod] = @CPLisHisPrvCod and TM1.[CPLisHisFecha] = @CPLisHisFecha ORDER BY TM1.[CPLisHisProdCod], TM1.[CPLisHisPrvCod], TM1.[CPLisHisFecha]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003H6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H7", "SELECT [ProdDsc] AS CPLisHisProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CPLisHisProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H8", "SELECT [PrvDsc] AS CPLisHisPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CPLisHisPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H9", "SELECT [CPLisHisProdCod] AS CPLisHisProdCod, [CPLisHisPrvCod] AS CPLisHisPrvCod, [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] WHERE [CPLisHisProdCod] = @CPLisHisProdCod AND [CPLisHisPrvCod] = @CPLisHisPrvCod AND [CPLisHisFecha] = @CPLisHisFecha  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003H9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H10", "SELECT TOP 1 [CPLisHisProdCod] AS CPLisHisProdCod, [CPLisHisPrvCod] AS CPLisHisPrvCod, [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] WHERE ( [CPLisHisProdCod] > @CPLisHisProdCod or [CPLisHisProdCod] = @CPLisHisProdCod and [CPLisHisPrvCod] > @CPLisHisPrvCod or [CPLisHisPrvCod] = @CPLisHisPrvCod and [CPLisHisProdCod] = @CPLisHisProdCod and [CPLisHisFecha] > @CPLisHisFecha) ORDER BY [CPLisHisProdCod], [CPLisHisPrvCod], [CPLisHisFecha]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003H10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003H11", "SELECT TOP 1 [CPLisHisProdCod] AS CPLisHisProdCod, [CPLisHisPrvCod] AS CPLisHisPrvCod, [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] WHERE ( [CPLisHisProdCod] < @CPLisHisProdCod or [CPLisHisProdCod] = @CPLisHisProdCod and [CPLisHisPrvCod] < @CPLisHisPrvCod or [CPLisHisPrvCod] = @CPLisHisPrvCod and [CPLisHisProdCod] = @CPLisHisProdCod and [CPLisHisFecha] < @CPLisHisFecha) ORDER BY [CPLisHisProdCod] DESC, [CPLisHisPrvCod] DESC, [CPLisHisFecha] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003H11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003H12", "INSERT INTO [CPLISTAPRECIOSHIS]([CPLisHisFecha], [CPLisHisImpMN], [CPLisHisImpME], [CPLisHisProdCod], [CPLisHisPrvCod]) VALUES(@CPLisHisFecha, @CPLisHisImpMN, @CPLisHisImpME, @CPLisHisProdCod, @CPLisHisPrvCod)", GxErrorMask.GX_NOMASK,prmT003H12)
           ,new CursorDef("T003H13", "UPDATE [CPLISTAPRECIOSHIS] SET [CPLisHisImpMN]=@CPLisHisImpMN, [CPLisHisImpME]=@CPLisHisImpME  WHERE [CPLisHisProdCod] = @CPLisHisProdCod AND [CPLisHisPrvCod] = @CPLisHisPrvCod AND [CPLisHisFecha] = @CPLisHisFecha", GxErrorMask.GX_NOMASK,prmT003H13)
           ,new CursorDef("T003H14", "DELETE FROM [CPLISTAPRECIOSHIS]  WHERE [CPLisHisProdCod] = @CPLisHisProdCod AND [CPLisHisPrvCod] = @CPLisHisPrvCod AND [CPLisHisFecha] = @CPLisHisFecha", GxErrorMask.GX_NOMASK,prmT003H14)
           ,new CursorDef("T003H15", "SELECT [ProdDsc] AS CPLisHisProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CPLisHisProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H16", "SELECT [PrvDsc] AS CPLisHisPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @CPLisHisPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003H16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003H17", "SELECT [CPLisHisProdCod] AS CPLisHisProdCod, [CPLisHisPrvCod] AS CPLisHisPrvCod, [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] ORDER BY [CPLisHisProdCod], [CPLisHisPrvCod], [CPLisHisFecha]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003H17,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 1 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
     }
  }

}

}
