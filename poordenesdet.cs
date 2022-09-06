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
   public class poordenesdet : GXDataArea
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
            A322ProCod = GetPar( "ProCod");
            AssignAttri("", false, "A322ProCod", A322ProCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A322ProCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A327ProDProdCod = GetPar( "ProDProdCod");
            n327ProDProdCod = false;
            AssignAttri("", false, "A327ProDProdCod", A327ProDProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A327ProDProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A1720ProDUniCodigo = (int)(NumberUtil.Val( GetPar( "ProDUniCodigo"), "."));
            AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrimStr( (decimal)(A1720ProDUniCodigo), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A1720ProDUniCodigo) ;
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
            Form.Meta.addItem("description", "Detalle de Ordenes de Producción", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public poordenesdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public poordenesdet( IGxContext context )
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
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Detalle de Ordenes de Producción", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 12,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCod_Internalname, "N° Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCod_Internalname, StringUtil.RTrim( A322ProCod), StringUtil.RTrim( context.localUtil.Format( A322ProCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A326ProDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtProDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A326ProDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A326ProDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDProdCod_Internalname, "Materia Prima", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProDProdCod_Internalname, StringUtil.RTrim( A327ProDProdCod), StringUtil.RTrim( context.localUtil.Format( A327ProDProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDProdDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDProdDsc_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProDProdDsc_Internalname, StringUtil.RTrim( A1704ProDProdDsc), StringUtil.RTrim( context.localUtil.Format( A1704ProDProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDUniCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDUniCodigo_Internalname, "Unidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProDUniCodigo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1720ProDUniCodigo), 6, 0, ".", "")), StringUtil.LTrim( ((edtProDUniCodigo_Enabled!=0) ? context.localUtil.Format( (decimal)(A1720ProDUniCodigo), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1720ProDUniCodigo), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDUniCodigo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDUniCodigo_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDUniAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDUniAbr_Internalname, "Unidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProDUniAbr_Internalname, StringUtil.RTrim( A1719ProDUniAbr), StringUtil.RTrim( context.localUtil.Format( A1719ProDUniAbr, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDUniAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDUniAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDConcepto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDConcepto_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProDConcepto_Internalname, StringUtil.RTrim( A1680ProDConcepto), StringUtil.RTrim( context.localUtil.Format( A1680ProDConcepto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDConcepto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDCantFormula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDCantFormula_Internalname, "Cantidad Formula", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProDCantFormula_Internalname, StringUtil.LTrim( StringUtil.NToC( A1677ProDCantFormula, 20, 8, ".", "")), StringUtil.LTrim( ((edtProDCantFormula_Enabled!=0) ? context.localUtil.Format( A1677ProDCantFormula, "ZZZ,ZZZ,ZZ9.99999999") : context.localUtil.Format( A1677ProDCantFormula, "ZZZ,ZZZ,ZZ9.99999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDCantFormula_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDCantFormula_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDCantIng_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDCantIng_Internalname, "Cantidad Ingresada", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProDCantIng_Internalname, StringUtil.LTrim( StringUtil.NToC( A1678ProDCantIng, 20, 8, ".", "")), StringUtil.LTrim( ((edtProDCantIng_Enabled!=0) ? context.localUtil.Format( A1678ProDCantIng, "ZZZ,ZZZ,ZZ9.99999999") : context.localUtil.Format( A1678ProDCantIng, "ZZZ,ZZZ,ZZ9.99999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDCantIng_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDCantIng_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCosto_Internalname, "Costo MN", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1656ProCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtProCosto_Enabled!=0) ? context.localUtil.Format( A1656ProCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1656ProCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProDCantFalta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProDCantFalta_Internalname, "Faltante", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProDCantFalta_Internalname, StringUtil.LTrim( StringUtil.NToC( A1676ProDCantFalta, 20, 8, ".", "")), StringUtil.LTrim( ((edtProDCantFalta_Enabled!=0) ? context.localUtil.Format( A1676ProDCantFalta, "ZZZ,ZZZ,ZZ9.99999999") : context.localUtil.Format( A1676ProDCantFalta, "ZZZ,ZZZ,ZZ9.99999999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProDCantFalta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProDCantFalta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group Confirm", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_POORDENESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
            Z322ProCod = cgiGet( "Z322ProCod");
            Z326ProDItem = (int)(context.localUtil.CToN( cgiGet( "Z326ProDItem"), ".", ","));
            Z1680ProDConcepto = cgiGet( "Z1680ProDConcepto");
            Z1677ProDCantFormula = context.localUtil.CToN( cgiGet( "Z1677ProDCantFormula"), ".", ",");
            Z1678ProDCantIng = context.localUtil.CToN( cgiGet( "Z1678ProDCantIng"), ".", ",");
            Z1656ProCosto = context.localUtil.CToN( cgiGet( "Z1656ProCosto"), ".", ",");
            Z327ProDProdCod = cgiGet( "Z327ProDProdCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A322ProCod = cgiGet( edtProCod_Internalname);
            AssignAttri("", false, "A322ProCod", A322ProCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODITEM");
               AnyError = 1;
               GX_FocusControl = edtProDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A326ProDItem = 0;
               AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
            }
            else
            {
               A326ProDItem = (int)(context.localUtil.CToN( cgiGet( edtProDItem_Internalname), ".", ","));
               AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
            }
            A327ProDProdCod = StringUtil.Upper( cgiGet( edtProDProdCod_Internalname));
            n327ProDProdCod = false;
            AssignAttri("", false, "A327ProDProdCod", A327ProDProdCod);
            A1704ProDProdDsc = cgiGet( edtProDProdDsc_Internalname);
            AssignAttri("", false, "A1704ProDProdDsc", A1704ProDProdDsc);
            A1720ProDUniCodigo = (int)(context.localUtil.CToN( cgiGet( edtProDUniCodigo_Internalname), ".", ","));
            AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrimStr( (decimal)(A1720ProDUniCodigo), 6, 0));
            A1719ProDUniAbr = cgiGet( edtProDUniAbr_Internalname);
            AssignAttri("", false, "A1719ProDUniAbr", A1719ProDUniAbr);
            A1680ProDConcepto = cgiGet( edtProDConcepto_Internalname);
            AssignAttri("", false, "A1680ProDConcepto", A1680ProDConcepto);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProDCantFormula_Internalname), ".", ",") < -99999999.99999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProDCantFormula_Internalname), ".", ",") > 999999999.99999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCANTFORMULA");
               AnyError = 1;
               GX_FocusControl = edtProDCantFormula_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1677ProDCantFormula = 0;
               AssignAttri("", false, "A1677ProDCantFormula", StringUtil.LTrimStr( A1677ProDCantFormula, 18, 8));
            }
            else
            {
               A1677ProDCantFormula = context.localUtil.CToN( cgiGet( edtProDCantFormula_Internalname), ".", ",");
               AssignAttri("", false, "A1677ProDCantFormula", StringUtil.LTrimStr( A1677ProDCantFormula, 18, 8));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProDCantIng_Internalname), ".", ",") < -99999999.99999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProDCantIng_Internalname), ".", ",") > 999999999.99999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCANTING");
               AnyError = 1;
               GX_FocusControl = edtProDCantIng_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1678ProDCantIng = 0;
               AssignAttri("", false, "A1678ProDCantIng", StringUtil.LTrimStr( A1678ProDCantIng, 18, 8));
            }
            else
            {
               A1678ProDCantIng = context.localUtil.CToN( cgiGet( edtProDCantIng_Internalname), ".", ",");
               AssignAttri("", false, "A1678ProDCantIng", StringUtil.LTrimStr( A1678ProDCantIng, 18, 8));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOSTO");
               AnyError = 1;
               GX_FocusControl = edtProCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1656ProCosto = 0;
               AssignAttri("", false, "A1656ProCosto", StringUtil.LTrimStr( A1656ProCosto, 15, 2));
            }
            else
            {
               A1656ProCosto = context.localUtil.CToN( cgiGet( edtProCosto_Internalname), ".", ",");
               AssignAttri("", false, "A1656ProCosto", StringUtil.LTrimStr( A1656ProCosto, 15, 2));
            }
            A1676ProDCantFalta = context.localUtil.CToN( cgiGet( edtProDCantFalta_Internalname), ".", ",");
            AssignAttri("", false, "A1676ProDCantFalta", StringUtil.LTrimStr( A1676ProDCantFalta, 18, 8));
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
               A322ProCod = GetPar( "ProCod");
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A326ProDItem = (int)(NumberUtil.Val( GetPar( "ProDItem"), "."));
               AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
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
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
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
               InitAll49148( ) ;
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
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes49148( ) ;
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

      protected void ResetCaption490( )
      {
      }

      protected void ZM49148( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1680ProDConcepto = T00493_A1680ProDConcepto[0];
               Z1677ProDCantFormula = T00493_A1677ProDCantFormula[0];
               Z1678ProDCantIng = T00493_A1678ProDCantIng[0];
               Z1656ProCosto = T00493_A1656ProCosto[0];
               Z327ProDProdCod = T00493_A327ProDProdCod[0];
            }
            else
            {
               Z1680ProDConcepto = A1680ProDConcepto;
               Z1677ProDCantFormula = A1677ProDCantFormula;
               Z1678ProDCantIng = A1678ProDCantIng;
               Z1656ProCosto = A1656ProCosto;
               Z327ProDProdCod = A327ProDProdCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z326ProDItem = A326ProDItem;
            Z1680ProDConcepto = A1680ProDConcepto;
            Z1677ProDCantFormula = A1677ProDCantFormula;
            Z1678ProDCantIng = A1678ProDCantIng;
            Z1656ProCosto = A1656ProCosto;
            Z322ProCod = A322ProCod;
            Z327ProDProdCod = A327ProDProdCod;
            Z1704ProDProdDsc = A1704ProDProdDsc;
            Z1720ProDUniCodigo = A1720ProDUniCodigo;
            Z1719ProDUniAbr = A1719ProDUniAbr;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load49148( )
      {
         /* Using cursor T00497 */
         pr_default.execute(5, new Object[] {A322ProCod, A326ProDItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound148 = 1;
            A1704ProDProdDsc = T00497_A1704ProDProdDsc[0];
            AssignAttri("", false, "A1704ProDProdDsc", A1704ProDProdDsc);
            A1719ProDUniAbr = T00497_A1719ProDUniAbr[0];
            AssignAttri("", false, "A1719ProDUniAbr", A1719ProDUniAbr);
            A1680ProDConcepto = T00497_A1680ProDConcepto[0];
            AssignAttri("", false, "A1680ProDConcepto", A1680ProDConcepto);
            A1677ProDCantFormula = T00497_A1677ProDCantFormula[0];
            AssignAttri("", false, "A1677ProDCantFormula", StringUtil.LTrimStr( A1677ProDCantFormula, 18, 8));
            A1678ProDCantIng = T00497_A1678ProDCantIng[0];
            AssignAttri("", false, "A1678ProDCantIng", StringUtil.LTrimStr( A1678ProDCantIng, 18, 8));
            A1656ProCosto = T00497_A1656ProCosto[0];
            AssignAttri("", false, "A1656ProCosto", StringUtil.LTrimStr( A1656ProCosto, 15, 2));
            A327ProDProdCod = T00497_A327ProDProdCod[0];
            n327ProDProdCod = T00497_n327ProDProdCod[0];
            AssignAttri("", false, "A327ProDProdCod", A327ProDProdCod);
            A1720ProDUniCodigo = T00497_A1720ProDUniCodigo[0];
            AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrimStr( (decimal)(A1720ProDUniCodigo), 6, 0));
            ZM49148( -2) ;
         }
         pr_default.close(5);
         OnLoadActions49148( ) ;
      }

      protected void OnLoadActions49148( )
      {
         A1676ProDCantFalta = (decimal)(A1677ProDCantFormula-A1678ProDCantIng);
         AssignAttri("", false, "A1676ProDCantFalta", StringUtil.LTrimStr( A1676ProDCantFalta, 18, 8));
      }

      protected void CheckExtendedTable49148( )
      {
         nIsDirty_148 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00494 */
         pr_default.execute(2, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00495 */
         pr_default.execute(3, new Object[] {n327ProDProdCod, A327ProDProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A327ProDProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PRODPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProDProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1704ProDProdDsc = T00495_A1704ProDProdDsc[0];
         AssignAttri("", false, "A1704ProDProdDsc", A1704ProDProdDsc);
         A1720ProDUniCodigo = T00495_A1720ProDUniCodigo[0];
         AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrimStr( (decimal)(A1720ProDUniCodigo), 6, 0));
         pr_default.close(3);
         /* Using cursor T00496 */
         pr_default.execute(4, new Object[] {A1720ProDUniCodigo});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A1720ProDUniCodigo) ) )
            {
               GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PRODUNICODIGO");
               AnyError = 1;
            }
         }
         A1719ProDUniAbr = T00496_A1719ProDUniAbr[0];
         AssignAttri("", false, "A1719ProDUniAbr", A1719ProDUniAbr);
         pr_default.close(4);
         nIsDirty_148 = 1;
         A1676ProDCantFalta = (decimal)(A1677ProDCantFormula-A1678ProDCantIng);
         AssignAttri("", false, "A1676ProDCantFalta", StringUtil.LTrimStr( A1676ProDCantFalta, 18, 8));
      }

      protected void CloseExtendedTableCursors49148( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A322ProCod )
      {
         /* Using cursor T00498 */
         pr_default.execute(6, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
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

      protected void gxLoad_4( string A327ProDProdCod )
      {
         /* Using cursor T00499 */
         pr_default.execute(7, new Object[] {n327ProDProdCod, A327ProDProdCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A327ProDProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PRODPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProDProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1704ProDProdDsc = T00499_A1704ProDProdDsc[0];
         AssignAttri("", false, "A1704ProDProdDsc", A1704ProDProdDsc);
         A1720ProDUniCodigo = T00499_A1720ProDUniCodigo[0];
         AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrimStr( (decimal)(A1720ProDUniCodigo), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1704ProDProdDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1720ProDUniCodigo), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( int A1720ProDUniCodigo )
      {
         /* Using cursor T004910 */
         pr_default.execute(8, new Object[] {A1720ProDUniCodigo});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A1720ProDUniCodigo) ) )
            {
               GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PRODUNICODIGO");
               AnyError = 1;
            }
         }
         A1719ProDUniAbr = T004910_A1719ProDUniAbr[0];
         AssignAttri("", false, "A1719ProDUniAbr", A1719ProDUniAbr);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1719ProDUniAbr))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey49148( )
      {
         /* Using cursor T004911 */
         pr_default.execute(9, new Object[] {A322ProCod, A326ProDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound148 = 1;
         }
         else
         {
            RcdFound148 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00493 */
         pr_default.execute(1, new Object[] {A322ProCod, A326ProDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM49148( 2) ;
            RcdFound148 = 1;
            A326ProDItem = T00493_A326ProDItem[0];
            AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
            A1680ProDConcepto = T00493_A1680ProDConcepto[0];
            AssignAttri("", false, "A1680ProDConcepto", A1680ProDConcepto);
            A1677ProDCantFormula = T00493_A1677ProDCantFormula[0];
            AssignAttri("", false, "A1677ProDCantFormula", StringUtil.LTrimStr( A1677ProDCantFormula, 18, 8));
            A1678ProDCantIng = T00493_A1678ProDCantIng[0];
            AssignAttri("", false, "A1678ProDCantIng", StringUtil.LTrimStr( A1678ProDCantIng, 18, 8));
            A1656ProCosto = T00493_A1656ProCosto[0];
            AssignAttri("", false, "A1656ProCosto", StringUtil.LTrimStr( A1656ProCosto, 15, 2));
            A322ProCod = T00493_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A327ProDProdCod = T00493_A327ProDProdCod[0];
            n327ProDProdCod = T00493_n327ProDProdCod[0];
            AssignAttri("", false, "A327ProDProdCod", A327ProDProdCod);
            Z322ProCod = A322ProCod;
            Z326ProDItem = A326ProDItem;
            sMode148 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load49148( ) ;
            if ( AnyError == 1 )
            {
               RcdFound148 = 0;
               InitializeNonKey49148( ) ;
            }
            Gx_mode = sMode148;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound148 = 0;
            InitializeNonKey49148( ) ;
            sMode148 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode148;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey49148( ) ;
         if ( RcdFound148 == 0 )
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
         RcdFound148 = 0;
         /* Using cursor T004912 */
         pr_default.execute(10, new Object[] {A322ProCod, A326ProDItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T004912_A322ProCod[0], A322ProCod) < 0 ) || ( StringUtil.StrCmp(T004912_A322ProCod[0], A322ProCod) == 0 ) && ( T004912_A326ProDItem[0] < A326ProDItem ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T004912_A322ProCod[0], A322ProCod) > 0 ) || ( StringUtil.StrCmp(T004912_A322ProCod[0], A322ProCod) == 0 ) && ( T004912_A326ProDItem[0] > A326ProDItem ) ) )
            {
               A322ProCod = T004912_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A326ProDItem = T004912_A326ProDItem[0];
               AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
               RcdFound148 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound148 = 0;
         /* Using cursor T004913 */
         pr_default.execute(11, new Object[] {A322ProCod, A326ProDItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T004913_A322ProCod[0], A322ProCod) > 0 ) || ( StringUtil.StrCmp(T004913_A322ProCod[0], A322ProCod) == 0 ) && ( T004913_A326ProDItem[0] > A326ProDItem ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T004913_A322ProCod[0], A322ProCod) < 0 ) || ( StringUtil.StrCmp(T004913_A322ProCod[0], A322ProCod) == 0 ) && ( T004913_A326ProDItem[0] < A326ProDItem ) ) )
            {
               A322ProCod = T004913_A322ProCod[0];
               AssignAttri("", false, "A322ProCod", A322ProCod);
               A326ProDItem = T004913_A326ProDItem[0];
               AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
               RcdFound148 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey49148( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert49148( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound148 == 1 )
            {
               if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( A326ProDItem != Z326ProDItem ) )
               {
                  A322ProCod = Z322ProCod;
                  AssignAttri("", false, "A322ProCod", A322ProCod);
                  A326ProDItem = Z326ProDItem;
                  AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update49148( ) ;
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( A326ProDItem != Z326ProDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert49148( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert49148( ) ;
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
         if ( ( StringUtil.StrCmp(A322ProCod, Z322ProCod) != 0 ) || ( A326ProDItem != Z326ProDItem ) )
         {
            A322ProCod = Z322ProCod;
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A326ProDItem = Z326ProDItem;
            AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCod_Internalname;
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

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart49148( ) ;
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd49148( ) ;
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
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProDProdCod_Internalname;
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
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProDProdCod_Internalname;
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
         ScanStart49148( ) ;
         if ( RcdFound148 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound148 != 0 )
            {
               ScanNext49148( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd49148( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency49148( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00492 */
            pr_default.execute(0, new Object[] {A322ProCod, A326ProDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENESDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1680ProDConcepto, T00492_A1680ProDConcepto[0]) != 0 ) || ( Z1677ProDCantFormula != T00492_A1677ProDCantFormula[0] ) || ( Z1678ProDCantIng != T00492_A1678ProDCantIng[0] ) || ( Z1656ProCosto != T00492_A1656ProCosto[0] ) || ( StringUtil.StrCmp(Z327ProDProdCod, T00492_A327ProDProdCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1680ProDConcepto, T00492_A1680ProDConcepto[0]) != 0 )
               {
                  GXUtil.WriteLog("poordenesdet:[seudo value changed for attri]"+"ProDConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1680ProDConcepto);
                  GXUtil.WriteLogRaw("Current: ",T00492_A1680ProDConcepto[0]);
               }
               if ( Z1677ProDCantFormula != T00492_A1677ProDCantFormula[0] )
               {
                  GXUtil.WriteLog("poordenesdet:[seudo value changed for attri]"+"ProDCantFormula");
                  GXUtil.WriteLogRaw("Old: ",Z1677ProDCantFormula);
                  GXUtil.WriteLogRaw("Current: ",T00492_A1677ProDCantFormula[0]);
               }
               if ( Z1678ProDCantIng != T00492_A1678ProDCantIng[0] )
               {
                  GXUtil.WriteLog("poordenesdet:[seudo value changed for attri]"+"ProDCantIng");
                  GXUtil.WriteLogRaw("Old: ",Z1678ProDCantIng);
                  GXUtil.WriteLogRaw("Current: ",T00492_A1678ProDCantIng[0]);
               }
               if ( Z1656ProCosto != T00492_A1656ProCosto[0] )
               {
                  GXUtil.WriteLog("poordenesdet:[seudo value changed for attri]"+"ProCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1656ProCosto);
                  GXUtil.WriteLogRaw("Current: ",T00492_A1656ProCosto[0]);
               }
               if ( StringUtil.StrCmp(Z327ProDProdCod, T00492_A327ProDProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("poordenesdet:[seudo value changed for attri]"+"ProDProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z327ProDProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00492_A327ProDProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"POORDENESDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert49148( )
      {
         BeforeValidate49148( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable49148( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM49148( 0) ;
            CheckOptimisticConcurrency49148( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm49148( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert49148( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004914 */
                     pr_default.execute(12, new Object[] {A326ProDItem, A1680ProDConcepto, A1677ProDCantFormula, A1678ProDCantIng, A1656ProCosto, A322ProCod, n327ProDProdCod, A327ProDProdCod});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENESDET");
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
                           ResetCaption490( ) ;
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
               Load49148( ) ;
            }
            EndLevel49148( ) ;
         }
         CloseExtendedTableCursors49148( ) ;
      }

      protected void Update49148( )
      {
         BeforeValidate49148( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable49148( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency49148( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm49148( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate49148( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004915 */
                     pr_default.execute(13, new Object[] {A1680ProDConcepto, A1677ProDCantFormula, A1678ProDCantIng, A1656ProCosto, n327ProDProdCod, A327ProDProdCod, A322ProCod, A326ProDItem});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("POORDENESDET");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"POORDENESDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate49148( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption490( ) ;
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
            EndLevel49148( ) ;
         }
         CloseExtendedTableCursors49148( ) ;
      }

      protected void DeferredUpdate49148( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate49148( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency49148( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls49148( ) ;
            AfterConfirm49148( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete49148( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004916 */
                  pr_default.execute(14, new Object[] {A322ProCod, A326ProDItem});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("POORDENESDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound148 == 0 )
                        {
                           InitAll49148( ) ;
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
                        ResetCaption490( ) ;
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
         sMode148 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel49148( ) ;
         Gx_mode = sMode148;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls49148( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004917 */
            pr_default.execute(15, new Object[] {n327ProDProdCod, A327ProDProdCod});
            A1704ProDProdDsc = T004917_A1704ProDProdDsc[0];
            AssignAttri("", false, "A1704ProDProdDsc", A1704ProDProdDsc);
            A1720ProDUniCodigo = T004917_A1720ProDUniCodigo[0];
            AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrimStr( (decimal)(A1720ProDUniCodigo), 6, 0));
            pr_default.close(15);
            /* Using cursor T004918 */
            pr_default.execute(16, new Object[] {A1720ProDUniCodigo});
            A1719ProDUniAbr = T004918_A1719ProDUniAbr[0];
            AssignAttri("", false, "A1719ProDUniAbr", A1719ProDUniAbr);
            pr_default.close(16);
            A1676ProDCantFalta = (decimal)(A1677ProDCantFormula-A1678ProDCantIng);
            AssignAttri("", false, "A1676ProDCantFalta", StringUtil.LTrimStr( A1676ProDCantFalta, 18, 8));
         }
      }

      protected void EndLevel49148( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete49148( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("poordenesdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues490( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("poordenesdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart49148( )
      {
         /* Using cursor T004919 */
         pr_default.execute(17);
         RcdFound148 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound148 = 1;
            A322ProCod = T004919_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A326ProDItem = T004919_A326ProDItem[0];
            AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext49148( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound148 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound148 = 1;
            A322ProCod = T004919_A322ProCod[0];
            AssignAttri("", false, "A322ProCod", A322ProCod);
            A326ProDItem = T004919_A326ProDItem[0];
            AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
         }
      }

      protected void ScanEnd49148( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm49148( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert49148( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate49148( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete49148( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete49148( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate49148( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes49148( )
      {
         edtProCod_Enabled = 0;
         AssignProp("", false, edtProCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCod_Enabled), 5, 0), true);
         edtProDItem_Enabled = 0;
         AssignProp("", false, edtProDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDItem_Enabled), 5, 0), true);
         edtProDProdCod_Enabled = 0;
         AssignProp("", false, edtProDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDProdCod_Enabled), 5, 0), true);
         edtProDProdDsc_Enabled = 0;
         AssignProp("", false, edtProDProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDProdDsc_Enabled), 5, 0), true);
         edtProDUniCodigo_Enabled = 0;
         AssignProp("", false, edtProDUniCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDUniCodigo_Enabled), 5, 0), true);
         edtProDUniAbr_Enabled = 0;
         AssignProp("", false, edtProDUniAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDUniAbr_Enabled), 5, 0), true);
         edtProDConcepto_Enabled = 0;
         AssignProp("", false, edtProDConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDConcepto_Enabled), 5, 0), true);
         edtProDCantFormula_Enabled = 0;
         AssignProp("", false, edtProDCantFormula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDCantFormula_Enabled), 5, 0), true);
         edtProDCantIng_Enabled = 0;
         AssignProp("", false, edtProDCantIng_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDCantIng_Enabled), 5, 0), true);
         edtProCosto_Enabled = 0;
         AssignProp("", false, edtProCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCosto_Enabled), 5, 0), true);
         edtProDCantFalta_Enabled = 0;
         AssignProp("", false, edtProDCantFalta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProDCantFalta_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes49148( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues490( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
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
         context.AddJavascriptSource("gxcfg.js", "?202281810253384", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("poordenesdet.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
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
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z326ProDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z326ProDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1680ProDConcepto", StringUtil.RTrim( Z1680ProDConcepto));
         GxWebStd.gx_hidden_field( context, "Z1677ProDCantFormula", StringUtil.LTrim( StringUtil.NToC( Z1677ProDCantFormula, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1678ProDCantIng", StringUtil.LTrim( StringUtil.NToC( Z1678ProDCantIng, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1656ProCosto", StringUtil.LTrim( StringUtil.NToC( Z1656ProCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z327ProDProdCod", StringUtil.RTrim( Z327ProDProdCod));
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
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
         return formatLink("poordenesdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "POORDENESDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Detalle de Ordenes de Producción" ;
      }

      protected void InitializeNonKey49148( )
      {
         A1676ProDCantFalta = 0;
         AssignAttri("", false, "A1676ProDCantFalta", StringUtil.LTrimStr( A1676ProDCantFalta, 18, 8));
         A327ProDProdCod = "";
         n327ProDProdCod = false;
         AssignAttri("", false, "A327ProDProdCod", A327ProDProdCod);
         A1704ProDProdDsc = "";
         AssignAttri("", false, "A1704ProDProdDsc", A1704ProDProdDsc);
         A1720ProDUniCodigo = 0;
         AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrimStr( (decimal)(A1720ProDUniCodigo), 6, 0));
         A1719ProDUniAbr = "";
         AssignAttri("", false, "A1719ProDUniAbr", A1719ProDUniAbr);
         A1680ProDConcepto = "";
         AssignAttri("", false, "A1680ProDConcepto", A1680ProDConcepto);
         A1677ProDCantFormula = 0;
         AssignAttri("", false, "A1677ProDCantFormula", StringUtil.LTrimStr( A1677ProDCantFormula, 18, 8));
         A1678ProDCantIng = 0;
         AssignAttri("", false, "A1678ProDCantIng", StringUtil.LTrimStr( A1678ProDCantIng, 18, 8));
         A1656ProCosto = 0;
         AssignAttri("", false, "A1656ProCosto", StringUtil.LTrimStr( A1656ProCosto, 15, 2));
         Z1680ProDConcepto = "";
         Z1677ProDCantFormula = 0;
         Z1678ProDCantIng = 0;
         Z1656ProCosto = 0;
         Z327ProDProdCod = "";
      }

      protected void InitAll49148( )
      {
         A322ProCod = "";
         AssignAttri("", false, "A322ProCod", A322ProCod);
         A326ProDItem = 0;
         AssignAttri("", false, "A326ProDItem", StringUtil.LTrimStr( (decimal)(A326ProDItem), 6, 0));
         InitializeNonKey49148( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810253392", true, true);
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
         context.AddJavascriptSource("poordenesdet.js", "?202281810253392", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtProCod_Internalname = "PROCOD";
         edtProDItem_Internalname = "PRODITEM";
         edtProDProdCod_Internalname = "PRODPRODCOD";
         edtProDProdDsc_Internalname = "PRODPRODDSC";
         edtProDUniCodigo_Internalname = "PRODUNICODIGO";
         edtProDUniAbr_Internalname = "PRODUNIABR";
         edtProDConcepto_Internalname = "PRODCONCEPTO";
         edtProDCantFormula_Internalname = "PRODCANTFORMULA";
         edtProDCantIng_Internalname = "PRODCANTING";
         edtProCosto_Internalname = "PROCOSTO";
         edtProDCantFalta_Internalname = "PRODCANTFALTA";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
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
         Form.Caption = "Detalle de Ordenes de Producción";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProDCantFalta_Jsonclick = "";
         edtProDCantFalta_Enabled = 0;
         edtProCosto_Jsonclick = "";
         edtProCosto_Enabled = 1;
         edtProDCantIng_Jsonclick = "";
         edtProDCantIng_Enabled = 1;
         edtProDCantFormula_Jsonclick = "";
         edtProDCantFormula_Enabled = 1;
         edtProDConcepto_Jsonclick = "";
         edtProDConcepto_Enabled = 1;
         edtProDUniAbr_Jsonclick = "";
         edtProDUniAbr_Enabled = 0;
         edtProDUniCodigo_Jsonclick = "";
         edtProDUniCodigo_Enabled = 0;
         edtProDProdDsc_Jsonclick = "";
         edtProDProdDsc_Enabled = 0;
         edtProDProdCod_Jsonclick = "";
         edtProDProdCod_Enabled = 1;
         edtProDItem_Jsonclick = "";
         edtProDItem_Enabled = 1;
         edtProCod_Jsonclick = "";
         edtProCod_Enabled = 1;
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
         /* Using cursor T004920 */
         pr_default.execute(18, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(18);
         GX_FocusControl = edtProDProdCod_Internalname;
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

      public void Valid_Procod( )
      {
         /* Using cursor T004920 */
         pr_default.execute(18, new Object[] {A322ProCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Cabecera Ordenes de Producción'.", "ForeignKeyNotFound", 1, "PROCOD");
            AnyError = 1;
            GX_FocusControl = edtProCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Proditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A327ProDProdCod", StringUtil.RTrim( A327ProDProdCod));
         AssignAttri("", false, "A1680ProDConcepto", StringUtil.RTrim( A1680ProDConcepto));
         AssignAttri("", false, "A1677ProDCantFormula", StringUtil.LTrim( StringUtil.NToC( A1677ProDCantFormula, 18, 8, ".", "")));
         AssignAttri("", false, "A1678ProDCantIng", StringUtil.LTrim( StringUtil.NToC( A1678ProDCantIng, 18, 8, ".", "")));
         AssignAttri("", false, "A1656ProCosto", StringUtil.LTrim( StringUtil.NToC( A1656ProCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A1704ProDProdDsc", StringUtil.RTrim( A1704ProDProdDsc));
         AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1720ProDUniCodigo), 6, 0, ".", "")));
         AssignAttri("", false, "A1719ProDUniAbr", StringUtil.RTrim( A1719ProDUniAbr));
         AssignAttri("", false, "A1676ProDCantFalta", StringUtil.LTrim( StringUtil.NToC( A1676ProDCantFalta, 18, 8, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z322ProCod", StringUtil.RTrim( Z322ProCod));
         GxWebStd.gx_hidden_field( context, "Z326ProDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z326ProDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z327ProDProdCod", StringUtil.RTrim( Z327ProDProdCod));
         GxWebStd.gx_hidden_field( context, "Z1680ProDConcepto", StringUtil.RTrim( Z1680ProDConcepto));
         GxWebStd.gx_hidden_field( context, "Z1677ProDCantFormula", StringUtil.LTrim( StringUtil.NToC( Z1677ProDCantFormula, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1678ProDCantIng", StringUtil.LTrim( StringUtil.NToC( Z1678ProDCantIng, 18, 8, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1656ProCosto", StringUtil.LTrim( StringUtil.NToC( Z1656ProCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1704ProDProdDsc", StringUtil.RTrim( Z1704ProDProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1720ProDUniCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1720ProDUniCodigo), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1719ProDUniAbr", StringUtil.RTrim( Z1719ProDUniAbr));
         GxWebStd.gx_hidden_field( context, "Z1676ProDCantFalta", StringUtil.LTrim( StringUtil.NToC( Z1676ProDCantFalta, 18, 8, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodprodcod( )
      {
         n327ProDProdCod = false;
         /* Using cursor T004917 */
         pr_default.execute(15, new Object[] {n327ProDProdCod, A327ProDProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A327ProDProdCod)) ) )
            {
               GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PRODPRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProDProdCod_Internalname;
            }
         }
         A1704ProDProdDsc = T004917_A1704ProDProdDsc[0];
         A1720ProDUniCodigo = T004917_A1720ProDUniCodigo[0];
         pr_default.close(15);
         /* Using cursor T004918 */
         pr_default.execute(16, new Object[] {A1720ProDUniCodigo});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( (0==A1720ProDUniCodigo) ) )
            {
               GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "PRODUNICODIGO");
               AnyError = 1;
            }
         }
         A1719ProDUniAbr = T004918_A1719ProDUniAbr[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1704ProDProdDsc", StringUtil.RTrim( A1704ProDProdDsc));
         AssignAttri("", false, "A1720ProDUniCodigo", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1720ProDUniCodigo), 6, 0, ".", "")));
         AssignAttri("", false, "A1719ProDUniAbr", StringUtil.RTrim( A1719ProDUniAbr));
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
         setEventMetadata("VALID_PROCOD","{handler:'Valid_Procod',iparms:[{av:'A322ProCod',fld:'PROCOD',pic:''}]");
         setEventMetadata("VALID_PROCOD",",oparms:[]}");
         setEventMetadata("VALID_PRODITEM","{handler:'Valid_Proditem',iparms:[{av:'A322ProCod',fld:'PROCOD',pic:''},{av:'A326ProDItem',fld:'PRODITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRODITEM",",oparms:[{av:'A327ProDProdCod',fld:'PRODPRODCOD',pic:'@!'},{av:'A1680ProDConcepto',fld:'PRODCONCEPTO',pic:''},{av:'A1677ProDCantFormula',fld:'PRODCANTFORMULA',pic:'ZZZ,ZZZ,ZZ9.99999999'},{av:'A1678ProDCantIng',fld:'PRODCANTING',pic:'ZZZ,ZZZ,ZZ9.99999999'},{av:'A1656ProCosto',fld:'PROCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1704ProDProdDsc',fld:'PRODPRODDSC',pic:''},{av:'A1720ProDUniCodigo',fld:'PRODUNICODIGO',pic:'ZZZZZ9'},{av:'A1719ProDUniAbr',fld:'PRODUNIABR',pic:''},{av:'A1676ProDCantFalta',fld:'PRODCANTFALTA',pic:'ZZZ,ZZZ,ZZ9.99999999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z322ProCod'},{av:'Z326ProDItem'},{av:'Z327ProDProdCod'},{av:'Z1680ProDConcepto'},{av:'Z1677ProDCantFormula'},{av:'Z1678ProDCantIng'},{av:'Z1656ProCosto'},{av:'Z1704ProDProdDsc'},{av:'Z1720ProDUniCodigo'},{av:'Z1719ProDUniAbr'},{av:'Z1676ProDCantFalta'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODPRODCOD","{handler:'Valid_Prodprodcod',iparms:[{av:'A327ProDProdCod',fld:'PRODPRODCOD',pic:'@!'},{av:'A1720ProDUniCodigo',fld:'PRODUNICODIGO',pic:'ZZZZZ9'},{av:'A1704ProDProdDsc',fld:'PRODPRODDSC',pic:''},{av:'A1719ProDUniAbr',fld:'PRODUNIABR',pic:''}]");
         setEventMetadata("VALID_PRODPRODCOD",",oparms:[{av:'A1704ProDProdDsc',fld:'PRODPRODDSC',pic:''},{av:'A1720ProDUniCodigo',fld:'PRODUNICODIGO',pic:'ZZZZZ9'},{av:'A1719ProDUniAbr',fld:'PRODUNIABR',pic:''}]}");
         setEventMetadata("VALID_PRODUNICODIGO","{handler:'Valid_Produnicodigo',iparms:[]");
         setEventMetadata("VALID_PRODUNICODIGO",",oparms:[]}");
         setEventMetadata("VALID_PRODCANTFORMULA","{handler:'Valid_Prodcantformula',iparms:[]");
         setEventMetadata("VALID_PRODCANTFORMULA",",oparms:[]}");
         setEventMetadata("VALID_PRODCANTING","{handler:'Valid_Prodcanting',iparms:[]");
         setEventMetadata("VALID_PRODCANTING",",oparms:[]}");
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
         pr_default.close(18);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z322ProCod = "";
         Z1680ProDConcepto = "";
         Z327ProDProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A322ProCod = "";
         A327ProDProdCod = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A1704ProDProdDsc = "";
         A1719ProDUniAbr = "";
         A1680ProDConcepto = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1704ProDProdDsc = "";
         Z1719ProDUniAbr = "";
         T00497_A326ProDItem = new int[1] ;
         T00497_A1704ProDProdDsc = new string[] {""} ;
         T00497_A1719ProDUniAbr = new string[] {""} ;
         T00497_A1680ProDConcepto = new string[] {""} ;
         T00497_A1677ProDCantFormula = new decimal[1] ;
         T00497_A1678ProDCantIng = new decimal[1] ;
         T00497_A1656ProCosto = new decimal[1] ;
         T00497_A322ProCod = new string[] {""} ;
         T00497_A327ProDProdCod = new string[] {""} ;
         T00497_n327ProDProdCod = new bool[] {false} ;
         T00497_A1720ProDUniCodigo = new int[1] ;
         T00494_A322ProCod = new string[] {""} ;
         T00495_A1704ProDProdDsc = new string[] {""} ;
         T00495_A1720ProDUniCodigo = new int[1] ;
         T00496_A1719ProDUniAbr = new string[] {""} ;
         T00498_A322ProCod = new string[] {""} ;
         T00499_A1704ProDProdDsc = new string[] {""} ;
         T00499_A1720ProDUniCodigo = new int[1] ;
         T004910_A1719ProDUniAbr = new string[] {""} ;
         T004911_A322ProCod = new string[] {""} ;
         T004911_A326ProDItem = new int[1] ;
         T00493_A326ProDItem = new int[1] ;
         T00493_A1680ProDConcepto = new string[] {""} ;
         T00493_A1677ProDCantFormula = new decimal[1] ;
         T00493_A1678ProDCantIng = new decimal[1] ;
         T00493_A1656ProCosto = new decimal[1] ;
         T00493_A322ProCod = new string[] {""} ;
         T00493_A327ProDProdCod = new string[] {""} ;
         T00493_n327ProDProdCod = new bool[] {false} ;
         sMode148 = "";
         T004912_A322ProCod = new string[] {""} ;
         T004912_A326ProDItem = new int[1] ;
         T004913_A322ProCod = new string[] {""} ;
         T004913_A326ProDItem = new int[1] ;
         T00492_A326ProDItem = new int[1] ;
         T00492_A1680ProDConcepto = new string[] {""} ;
         T00492_A1677ProDCantFormula = new decimal[1] ;
         T00492_A1678ProDCantIng = new decimal[1] ;
         T00492_A1656ProCosto = new decimal[1] ;
         T00492_A322ProCod = new string[] {""} ;
         T00492_A327ProDProdCod = new string[] {""} ;
         T00492_n327ProDProdCod = new bool[] {false} ;
         T004917_A1704ProDProdDsc = new string[] {""} ;
         T004917_A1720ProDUniCodigo = new int[1] ;
         T004918_A1719ProDUniAbr = new string[] {""} ;
         T004919_A322ProCod = new string[] {""} ;
         T004919_A326ProDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004920_A322ProCod = new string[] {""} ;
         ZZ322ProCod = "";
         ZZ327ProDProdCod = "";
         ZZ1680ProDConcepto = "";
         ZZ1704ProDProdDsc = "";
         ZZ1719ProDUniAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.poordenesdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.poordenesdet__default(),
            new Object[][] {
                new Object[] {
               T00492_A326ProDItem, T00492_A1680ProDConcepto, T00492_A1677ProDCantFormula, T00492_A1678ProDCantIng, T00492_A1656ProCosto, T00492_A322ProCod, T00492_A327ProDProdCod, T00492_n327ProDProdCod
               }
               , new Object[] {
               T00493_A326ProDItem, T00493_A1680ProDConcepto, T00493_A1677ProDCantFormula, T00493_A1678ProDCantIng, T00493_A1656ProCosto, T00493_A322ProCod, T00493_A327ProDProdCod, T00493_n327ProDProdCod
               }
               , new Object[] {
               T00494_A322ProCod
               }
               , new Object[] {
               T00495_A1704ProDProdDsc, T00495_A1720ProDUniCodigo
               }
               , new Object[] {
               T00496_A1719ProDUniAbr
               }
               , new Object[] {
               T00497_A326ProDItem, T00497_A1704ProDProdDsc, T00497_A1719ProDUniAbr, T00497_A1680ProDConcepto, T00497_A1677ProDCantFormula, T00497_A1678ProDCantIng, T00497_A1656ProCosto, T00497_A322ProCod, T00497_A327ProDProdCod, T00497_n327ProDProdCod,
               T00497_A1720ProDUniCodigo
               }
               , new Object[] {
               T00498_A322ProCod
               }
               , new Object[] {
               T00499_A1704ProDProdDsc, T00499_A1720ProDUniCodigo
               }
               , new Object[] {
               T004910_A1719ProDUniAbr
               }
               , new Object[] {
               T004911_A322ProCod, T004911_A326ProDItem
               }
               , new Object[] {
               T004912_A322ProCod, T004912_A326ProDItem
               }
               , new Object[] {
               T004913_A322ProCod, T004913_A326ProDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004917_A1704ProDProdDsc, T004917_A1720ProDUniCodigo
               }
               , new Object[] {
               T004918_A1719ProDUniAbr
               }
               , new Object[] {
               T004919_A322ProCod, T004919_A326ProDItem
               }
               , new Object[] {
               T004920_A322ProCod
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
      private short RcdFound148 ;
      private short nIsDirty_148 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z326ProDItem ;
      private int A1720ProDUniCodigo ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCod_Enabled ;
      private int A326ProDItem ;
      private int edtProDItem_Enabled ;
      private int edtProDProdCod_Enabled ;
      private int edtProDProdDsc_Enabled ;
      private int edtProDUniCodigo_Enabled ;
      private int edtProDUniAbr_Enabled ;
      private int edtProDConcepto_Enabled ;
      private int edtProDCantFormula_Enabled ;
      private int edtProDCantIng_Enabled ;
      private int edtProCosto_Enabled ;
      private int edtProDCantFalta_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z1720ProDUniCodigo ;
      private int idxLst ;
      private int ZZ326ProDItem ;
      private int ZZ1720ProDUniCodigo ;
      private decimal Z1677ProDCantFormula ;
      private decimal Z1678ProDCantIng ;
      private decimal Z1656ProCosto ;
      private decimal A1677ProDCantFormula ;
      private decimal A1678ProDCantIng ;
      private decimal A1656ProCosto ;
      private decimal A1676ProDCantFalta ;
      private decimal Z1676ProDCantFalta ;
      private decimal ZZ1677ProDCantFormula ;
      private decimal ZZ1678ProDCantIng ;
      private decimal ZZ1656ProCosto ;
      private decimal ZZ1676ProDCantFalta ;
      private string sPrefix ;
      private string Z322ProCod ;
      private string Z1680ProDConcepto ;
      private string Z327ProDProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A322ProCod ;
      private string A327ProDProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCod_Internalname ;
      private string divTablemain_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
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
      private string edtProCod_Jsonclick ;
      private string edtProDItem_Internalname ;
      private string edtProDItem_Jsonclick ;
      private string edtProDProdCod_Internalname ;
      private string edtProDProdCod_Jsonclick ;
      private string edtProDProdDsc_Internalname ;
      private string A1704ProDProdDsc ;
      private string edtProDProdDsc_Jsonclick ;
      private string edtProDUniCodigo_Internalname ;
      private string edtProDUniCodigo_Jsonclick ;
      private string edtProDUniAbr_Internalname ;
      private string A1719ProDUniAbr ;
      private string edtProDUniAbr_Jsonclick ;
      private string edtProDConcepto_Internalname ;
      private string A1680ProDConcepto ;
      private string edtProDConcepto_Jsonclick ;
      private string edtProDCantFormula_Internalname ;
      private string edtProDCantFormula_Jsonclick ;
      private string edtProDCantIng_Internalname ;
      private string edtProDCantIng_Jsonclick ;
      private string edtProCosto_Internalname ;
      private string edtProCosto_Jsonclick ;
      private string edtProDCantFalta_Internalname ;
      private string edtProDCantFalta_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1704ProDProdDsc ;
      private string Z1719ProDUniAbr ;
      private string sMode148 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ322ProCod ;
      private string ZZ327ProDProdCod ;
      private string ZZ1680ProDConcepto ;
      private string ZZ1704ProDProdDsc ;
      private string ZZ1719ProDUniAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n327ProDProdCod ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00497_A326ProDItem ;
      private string[] T00497_A1704ProDProdDsc ;
      private string[] T00497_A1719ProDUniAbr ;
      private string[] T00497_A1680ProDConcepto ;
      private decimal[] T00497_A1677ProDCantFormula ;
      private decimal[] T00497_A1678ProDCantIng ;
      private decimal[] T00497_A1656ProCosto ;
      private string[] T00497_A322ProCod ;
      private string[] T00497_A327ProDProdCod ;
      private bool[] T00497_n327ProDProdCod ;
      private int[] T00497_A1720ProDUniCodigo ;
      private string[] T00494_A322ProCod ;
      private string[] T00495_A1704ProDProdDsc ;
      private int[] T00495_A1720ProDUniCodigo ;
      private string[] T00496_A1719ProDUniAbr ;
      private string[] T00498_A322ProCod ;
      private string[] T00499_A1704ProDProdDsc ;
      private int[] T00499_A1720ProDUniCodigo ;
      private string[] T004910_A1719ProDUniAbr ;
      private string[] T004911_A322ProCod ;
      private int[] T004911_A326ProDItem ;
      private int[] T00493_A326ProDItem ;
      private string[] T00493_A1680ProDConcepto ;
      private decimal[] T00493_A1677ProDCantFormula ;
      private decimal[] T00493_A1678ProDCantIng ;
      private decimal[] T00493_A1656ProCosto ;
      private string[] T00493_A322ProCod ;
      private string[] T00493_A327ProDProdCod ;
      private bool[] T00493_n327ProDProdCod ;
      private string[] T004912_A322ProCod ;
      private int[] T004912_A326ProDItem ;
      private string[] T004913_A322ProCod ;
      private int[] T004913_A326ProDItem ;
      private int[] T00492_A326ProDItem ;
      private string[] T00492_A1680ProDConcepto ;
      private decimal[] T00492_A1677ProDCantFormula ;
      private decimal[] T00492_A1678ProDCantIng ;
      private decimal[] T00492_A1656ProCosto ;
      private string[] T00492_A322ProCod ;
      private string[] T00492_A327ProDProdCod ;
      private bool[] T00492_n327ProDProdCod ;
      private string[] T004917_A1704ProDProdDsc ;
      private int[] T004917_A1720ProDUniCodigo ;
      private string[] T004918_A1719ProDUniAbr ;
      private string[] T004919_A322ProCod ;
      private int[] T004919_A326ProDItem ;
      private string[] T004920_A322ProCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class poordenesdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class poordenesdet__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00497;
        prmT00497 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT00494;
        prmT00494 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT00495;
        prmT00495 = new Object[] {
        new ParDef("@ProDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT00496;
        prmT00496 = new Object[] {
        new ParDef("@ProDUniCodigo",GXType.Int32,6,0)
        };
        Object[] prmT00498;
        prmT00498 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT00499;
        prmT00499 = new Object[] {
        new ParDef("@ProDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT004910;
        prmT004910 = new Object[] {
        new ParDef("@ProDUniCodigo",GXType.Int32,6,0)
        };
        Object[] prmT004911;
        prmT004911 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT00493;
        prmT00493 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT004912;
        prmT004912 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT004913;
        prmT004913 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT00492;
        prmT00492 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT004914;
        prmT004914 = new Object[] {
        new ParDef("@ProDItem",GXType.Int32,6,0) ,
        new ParDef("@ProDConcepto",GXType.NChar,100,0) ,
        new ParDef("@ProDCantFormula",GXType.Decimal,18,8) ,
        new ParDef("@ProDCantIng",GXType.Decimal,18,8) ,
        new ParDef("@ProCosto",GXType.Decimal,15,2) ,
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT004915;
        prmT004915 = new Object[] {
        new ParDef("@ProDConcepto",GXType.NChar,100,0) ,
        new ParDef("@ProDCantFormula",GXType.Decimal,18,8) ,
        new ParDef("@ProDCantIng",GXType.Decimal,18,8) ,
        new ParDef("@ProCosto",GXType.Decimal,15,2) ,
        new ParDef("@ProDProdCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT004916;
        prmT004916 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0) ,
        new ParDef("@ProDItem",GXType.Int32,6,0)
        };
        Object[] prmT004919;
        prmT004919 = new Object[] {
        };
        Object[] prmT004920;
        prmT004920 = new Object[] {
        new ParDef("@ProCod",GXType.NChar,10,0)
        };
        Object[] prmT004917;
        prmT004917 = new Object[] {
        new ParDef("@ProDProdCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT004918;
        prmT004918 = new Object[] {
        new ParDef("@ProDUniCodigo",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00492", "SELECT [ProDItem], [ProDConcepto], [ProDCantFormula], [ProDCantIng], [ProCosto], [ProCod], [ProDProdCod] AS ProDProdCod FROM [POORDENESDET] WITH (UPDLOCK) WHERE [ProCod] = @ProCod AND [ProDItem] = @ProDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00492,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00493", "SELECT [ProDItem], [ProDConcepto], [ProDCantFormula], [ProDCantIng], [ProCosto], [ProCod], [ProDProdCod] AS ProDProdCod FROM [POORDENESDET] WHERE [ProCod] = @ProCod AND [ProDItem] = @ProDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00493,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00494", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00494,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00495", "SELECT [ProdDsc] AS ProDProdDsc, [UniCod] AS ProDUniCodigo FROM [APRODUCTOS] WHERE [ProdCod] = @ProDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00495,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00496", "SELECT [UniAbr] AS ProDUniAbr FROM [CUNIDADMEDIDA] WHERE [UniCod] = @ProDUniCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT00496,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00497", "SELECT TM1.[ProDItem], T2.[ProdDsc] AS ProDProdDsc, T3.[UniAbr] AS ProDUniAbr, TM1.[ProDConcepto], TM1.[ProDCantFormula], TM1.[ProDCantIng], TM1.[ProCosto], TM1.[ProCod], TM1.[ProDProdCod] AS ProDProdCod, T2.[UniCod] AS ProDUniCodigo FROM (([POORDENESDET] TM1 LEFT JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ProDProdCod]) LEFT JOIN [CUNIDADMEDIDA] T3 ON T3.[UniCod] = T2.[UniCod]) WHERE TM1.[ProCod] = @ProCod and TM1.[ProDItem] = @ProDItem ORDER BY TM1.[ProCod], TM1.[ProDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00497,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00498", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00498,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00499", "SELECT [ProdDsc] AS ProDProdDsc, [UniCod] AS ProDUniCodigo FROM [APRODUCTOS] WHERE [ProdCod] = @ProDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00499,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004910", "SELECT [UniAbr] AS ProDUniAbr FROM [CUNIDADMEDIDA] WHERE [UniCod] = @ProDUniCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT004910,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004911", "SELECT [ProCod], [ProDItem] FROM [POORDENESDET] WHERE [ProCod] = @ProCod AND [ProDItem] = @ProDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004911,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004912", "SELECT TOP 1 [ProCod], [ProDItem] FROM [POORDENESDET] WHERE ( [ProCod] > @ProCod or [ProCod] = @ProCod and [ProDItem] > @ProDItem) ORDER BY [ProCod], [ProDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004912,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004913", "SELECT TOP 1 [ProCod], [ProDItem] FROM [POORDENESDET] WHERE ( [ProCod] < @ProCod or [ProCod] = @ProCod and [ProDItem] < @ProDItem) ORDER BY [ProCod] DESC, [ProDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004913,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004914", "INSERT INTO [POORDENESDET]([ProDItem], [ProDConcepto], [ProDCantFormula], [ProDCantIng], [ProCosto], [ProCod], [ProDProdCod]) VALUES(@ProDItem, @ProDConcepto, @ProDCantFormula, @ProDCantIng, @ProCosto, @ProCod, @ProDProdCod)", GxErrorMask.GX_NOMASK,prmT004914)
           ,new CursorDef("T004915", "UPDATE [POORDENESDET] SET [ProDConcepto]=@ProDConcepto, [ProDCantFormula]=@ProDCantFormula, [ProDCantIng]=@ProDCantIng, [ProCosto]=@ProCosto, [ProDProdCod]=@ProDProdCod  WHERE [ProCod] = @ProCod AND [ProDItem] = @ProDItem", GxErrorMask.GX_NOMASK,prmT004915)
           ,new CursorDef("T004916", "DELETE FROM [POORDENESDET]  WHERE [ProCod] = @ProCod AND [ProDItem] = @ProDItem", GxErrorMask.GX_NOMASK,prmT004916)
           ,new CursorDef("T004917", "SELECT [ProdDsc] AS ProDProdDsc, [UniCod] AS ProDUniCodigo FROM [APRODUCTOS] WHERE [ProdCod] = @ProDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004917,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004918", "SELECT [UniAbr] AS ProDUniAbr FROM [CUNIDADMEDIDA] WHERE [UniCod] = @ProDUniCodigo ",true, GxErrorMask.GX_NOMASK, false, this,prmT004918,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004919", "SELECT [ProCod], [ProDItem] FROM [POORDENESDET] ORDER BY [ProCod], [ProDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004919,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004920", "SELECT [ProCod] FROM [POORDENES] WHERE [ProCod] = @ProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004920,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getString(7, 15);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((string[]) buf[8])[0] = rslt.getString(9, 15);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
