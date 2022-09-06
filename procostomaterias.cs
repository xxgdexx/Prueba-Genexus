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
   public class procostomaterias : GXHttpHandler
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
            A2385ProCosProdCod = GetPar( "ProCosProdCod");
            AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2385ProCosProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A2386ProCosMonCod = (int)(NumberUtil.Val( GetPar( "ProCosMonCod"), "."));
            AssignAttri("", false, "A2386ProCosMonCod", StringUtil.LTrimStr( (decimal)(A2386ProCosMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A2386ProCosMonCod) ;
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
            Form.Meta.addItem("description", "Costo Estandar Materias Primas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public procostomaterias( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public procostomaterias( IGxContext context )
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
            RenderHtmlCloseForm7M210( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Costo Estandar Materias Primas", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_PROCOSTOMATERIAS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PROCOSTOMATERIAS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCosProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCosProdCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCosProdCod_Internalname, StringUtil.RTrim( A2385ProCosProdCod), StringUtil.RTrim( context.localUtil.Format( A2385ProCosProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCosProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCosProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCosProdDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCosProdDsc_Internalname, "Productos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProCosProdDsc_Internalname, StringUtil.RTrim( A2400ProCosProdDsc), StringUtil.RTrim( context.localUtil.Format( A2400ProCosProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCosProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCosProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCosMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCosMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCosMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2386ProCosMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtProCosMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2386ProCosMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2386ProCosMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCosMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCosMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCosMonDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCosMonDsc_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProCosMonDsc_Internalname, StringUtil.RTrim( A2401ProCosMonDsc), StringUtil.RTrim( context.localUtil.Format( A2401ProCosMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCosMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCosMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProCosCostoU_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProCosCostoU_Internalname, "Costo Unitario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProCosCostoU_Internalname, StringUtil.LTrim( StringUtil.NToC( A2396ProCosCostoU, 17, 4, ".", "")), StringUtil.LTrim( ((edtProCosCostoU_Enabled!=0) ? context.localUtil.Format( A2396ProCosCostoU, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A2396ProCosCostoU, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProCosCostoU_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProCosCostoU_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_PROCOSTOMATERIAS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOMATERIAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOMATERIAS.htm");
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
            Z2385ProCosProdCod = cgiGet( "Z2385ProCosProdCod");
            Z2396ProCosCostoU = context.localUtil.CToN( cgiGet( "Z2396ProCosCostoU"), ".", ",");
            Z2386ProCosMonCod = (int)(context.localUtil.CToN( cgiGet( "Z2386ProCosMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2385ProCosProdCod = StringUtil.Upper( cgiGet( edtProCosProdCod_Internalname));
            AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
            A2400ProCosProdDsc = cgiGet( edtProCosProdDsc_Internalname);
            AssignAttri("", false, "A2400ProCosProdDsc", A2400ProCosProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCosMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProCosMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOSMONCOD");
               AnyError = 1;
               GX_FocusControl = edtProCosMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2386ProCosMonCod = 0;
               AssignAttri("", false, "A2386ProCosMonCod", StringUtil.LTrimStr( (decimal)(A2386ProCosMonCod), 6, 0));
            }
            else
            {
               A2386ProCosMonCod = (int)(context.localUtil.CToN( cgiGet( edtProCosMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A2386ProCosMonCod", StringUtil.LTrimStr( (decimal)(A2386ProCosMonCod), 6, 0));
            }
            A2401ProCosMonDsc = cgiGet( edtProCosMonDsc_Internalname);
            AssignAttri("", false, "A2401ProCosMonDsc", A2401ProCosMonDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProCosCostoU_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProCosCostoU_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROCOSCOSTOU");
               AnyError = 1;
               GX_FocusControl = edtProCosCostoU_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2396ProCosCostoU = 0;
               AssignAttri("", false, "A2396ProCosCostoU", StringUtil.LTrimStr( A2396ProCosCostoU, 15, 4));
            }
            else
            {
               A2396ProCosCostoU = context.localUtil.CToN( cgiGet( edtProCosCostoU_Internalname), ".", ",");
               AssignAttri("", false, "A2396ProCosCostoU", StringUtil.LTrimStr( A2396ProCosCostoU, 15, 4));
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
               A2385ProCosProdCod = GetPar( "ProCosProdCod");
               AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
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
               InitAll7M210( ) ;
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
         DisableAttributes7M210( ) ;
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

      protected void ResetCaption7M0( )
      {
      }

      protected void ZM7M210( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2396ProCosCostoU = T007M3_A2396ProCosCostoU[0];
               Z2386ProCosMonCod = T007M3_A2386ProCosMonCod[0];
            }
            else
            {
               Z2396ProCosCostoU = A2396ProCosCostoU;
               Z2386ProCosMonCod = A2386ProCosMonCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2396ProCosCostoU = A2396ProCosCostoU;
            Z2385ProCosProdCod = A2385ProCosProdCod;
            Z2386ProCosMonCod = A2386ProCosMonCod;
            Z2400ProCosProdDsc = A2400ProCosProdDsc;
            Z2401ProCosMonDsc = A2401ProCosMonDsc;
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

      protected void Load7M210( )
      {
         /* Using cursor T007M6 */
         pr_default.execute(4, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound210 = 1;
            A2400ProCosProdDsc = T007M6_A2400ProCosProdDsc[0];
            AssignAttri("", false, "A2400ProCosProdDsc", A2400ProCosProdDsc);
            A2401ProCosMonDsc = T007M6_A2401ProCosMonDsc[0];
            AssignAttri("", false, "A2401ProCosMonDsc", A2401ProCosMonDsc);
            A2396ProCosCostoU = T007M6_A2396ProCosCostoU[0];
            AssignAttri("", false, "A2396ProCosCostoU", StringUtil.LTrimStr( A2396ProCosCostoU, 15, 4));
            A2386ProCosMonCod = T007M6_A2386ProCosMonCod[0];
            AssignAttri("", false, "A2386ProCosMonCod", StringUtil.LTrimStr( (decimal)(A2386ProCosMonCod), 6, 0));
            ZM7M210( -1) ;
         }
         pr_default.close(4);
         OnLoadActions7M210( ) ;
      }

      protected void OnLoadActions7M210( )
      {
      }

      protected void CheckExtendedTable7M210( )
      {
         nIsDirty_210 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007M4 */
         pr_default.execute(2, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Costo Estandar Producto'.", "ForeignKeyNotFound", 1, "PROCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2400ProCosProdDsc = T007M4_A2400ProCosProdDsc[0];
         AssignAttri("", false, "A2400ProCosProdDsc", A2400ProCosProdDsc);
         pr_default.close(2);
         /* Using cursor T007M5 */
         pr_default.execute(3, new Object[] {A2386ProCosMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Costo Estandar Moneda'.", "ForeignKeyNotFound", 1, "PROCOSMONCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2401ProCosMonDsc = T007M5_A2401ProCosMonDsc[0];
         AssignAttri("", false, "A2401ProCosMonDsc", A2401ProCosMonDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors7M210( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A2385ProCosProdCod )
      {
         /* Using cursor T007M7 */
         pr_default.execute(5, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Costo Estandar Producto'.", "ForeignKeyNotFound", 1, "PROCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2400ProCosProdDsc = T007M7_A2400ProCosProdDsc[0];
         AssignAttri("", false, "A2400ProCosProdDsc", A2400ProCosProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2400ProCosProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( int A2386ProCosMonCod )
      {
         /* Using cursor T007M8 */
         pr_default.execute(6, new Object[] {A2386ProCosMonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Costo Estandar Moneda'.", "ForeignKeyNotFound", 1, "PROCOSMONCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2401ProCosMonDsc = T007M8_A2401ProCosMonDsc[0];
         AssignAttri("", false, "A2401ProCosMonDsc", A2401ProCosMonDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2401ProCosMonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey7M210( )
      {
         /* Using cursor T007M9 */
         pr_default.execute(7, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound210 = 1;
         }
         else
         {
            RcdFound210 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007M3 */
         pr_default.execute(1, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7M210( 1) ;
            RcdFound210 = 1;
            A2396ProCosCostoU = T007M3_A2396ProCosCostoU[0];
            AssignAttri("", false, "A2396ProCosCostoU", StringUtil.LTrimStr( A2396ProCosCostoU, 15, 4));
            A2385ProCosProdCod = T007M3_A2385ProCosProdCod[0];
            AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
            A2386ProCosMonCod = T007M3_A2386ProCosMonCod[0];
            AssignAttri("", false, "A2386ProCosMonCod", StringUtil.LTrimStr( (decimal)(A2386ProCosMonCod), 6, 0));
            Z2385ProCosProdCod = A2385ProCosProdCod;
            sMode210 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7M210( ) ;
            if ( AnyError == 1 )
            {
               RcdFound210 = 0;
               InitializeNonKey7M210( ) ;
            }
            Gx_mode = sMode210;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound210 = 0;
            InitializeNonKey7M210( ) ;
            sMode210 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode210;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7M210( ) ;
         if ( RcdFound210 == 0 )
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
         RcdFound210 = 0;
         /* Using cursor T007M10 */
         pr_default.execute(8, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T007M10_A2385ProCosProdCod[0], A2385ProCosProdCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T007M10_A2385ProCosProdCod[0], A2385ProCosProdCod) > 0 ) ) )
            {
               A2385ProCosProdCod = T007M10_A2385ProCosProdCod[0];
               AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
               RcdFound210 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound210 = 0;
         /* Using cursor T007M11 */
         pr_default.execute(9, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007M11_A2385ProCosProdCod[0], A2385ProCosProdCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T007M11_A2385ProCosProdCod[0], A2385ProCosProdCod) < 0 ) ) )
            {
               A2385ProCosProdCod = T007M11_A2385ProCosProdCod[0];
               AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
               RcdFound210 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7M210( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7M210( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound210 == 1 )
            {
               if ( StringUtil.StrCmp(A2385ProCosProdCod, Z2385ProCosProdCod) != 0 )
               {
                  A2385ProCosProdCod = Z2385ProCosProdCod;
                  AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROCOSPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProCosProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProCosProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7M210( ) ;
                  GX_FocusControl = edtProCosProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2385ProCosProdCod, Z2385ProCosProdCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProCosProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7M210( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROCOSPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProCosProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProCosProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7M210( ) ;
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
         if ( StringUtil.StrCmp(A2385ProCosProdCod, Z2385ProCosProdCod) != 0 )
         {
            A2385ProCosProdCod = Z2385ProCosProdCod;
            AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProCosProdCod_Internalname;
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
         if ( RcdFound210 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProCosMonCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7M210( ) ;
         if ( RcdFound210 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCosMonCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7M210( ) ;
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
         if ( RcdFound210 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCosMonCod_Internalname;
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
         if ( RcdFound210 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCosMonCod_Internalname;
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
         ScanStart7M210( ) ;
         if ( RcdFound210 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound210 != 0 )
            {
               ScanNext7M210( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProCosMonCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7M210( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7M210( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007M2 */
            pr_default.execute(0, new Object[] {A2385ProCosProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PROCOSTOMATERIAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2396ProCosCostoU != T007M2_A2396ProCosCostoU[0] ) || ( Z2386ProCosMonCod != T007M2_A2386ProCosMonCod[0] ) )
            {
               if ( Z2396ProCosCostoU != T007M2_A2396ProCosCostoU[0] )
               {
                  GXUtil.WriteLog("procostomaterias:[seudo value changed for attri]"+"ProCosCostoU");
                  GXUtil.WriteLogRaw("Old: ",Z2396ProCosCostoU);
                  GXUtil.WriteLogRaw("Current: ",T007M2_A2396ProCosCostoU[0]);
               }
               if ( Z2386ProCosMonCod != T007M2_A2386ProCosMonCod[0] )
               {
                  GXUtil.WriteLog("procostomaterias:[seudo value changed for attri]"+"ProCosMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z2386ProCosMonCod);
                  GXUtil.WriteLogRaw("Current: ",T007M2_A2386ProCosMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PROCOSTOMATERIAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7M210( )
      {
         BeforeValidate7M210( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7M210( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7M210( 0) ;
            CheckOptimisticConcurrency7M210( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7M210( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7M210( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007M12 */
                     pr_default.execute(10, new Object[] {A2396ProCosCostoU, A2385ProCosProdCod, A2386ProCosMonCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOMATERIAS");
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
                           ResetCaption7M0( ) ;
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
               Load7M210( ) ;
            }
            EndLevel7M210( ) ;
         }
         CloseExtendedTableCursors7M210( ) ;
      }

      protected void Update7M210( )
      {
         BeforeValidate7M210( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7M210( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7M210( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7M210( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7M210( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007M13 */
                     pr_default.execute(11, new Object[] {A2396ProCosCostoU, A2386ProCosMonCod, A2385ProCosProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOMATERIAS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PROCOSTOMATERIAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7M210( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7M0( ) ;
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
            EndLevel7M210( ) ;
         }
         CloseExtendedTableCursors7M210( ) ;
      }

      protected void DeferredUpdate7M210( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7M210( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7M210( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7M210( ) ;
            AfterConfirm7M210( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7M210( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007M14 */
                  pr_default.execute(12, new Object[] {A2385ProCosProdCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOMATERIAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound210 == 0 )
                        {
                           InitAll7M210( ) ;
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
                        ResetCaption7M0( ) ;
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
         sMode210 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7M210( ) ;
         Gx_mode = sMode210;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7M210( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007M15 */
            pr_default.execute(13, new Object[] {A2385ProCosProdCod});
            A2400ProCosProdDsc = T007M15_A2400ProCosProdDsc[0];
            AssignAttri("", false, "A2400ProCosProdDsc", A2400ProCosProdDsc);
            pr_default.close(13);
            /* Using cursor T007M16 */
            pr_default.execute(14, new Object[] {A2386ProCosMonCod});
            A2401ProCosMonDsc = T007M16_A2401ProCosMonDsc[0];
            AssignAttri("", false, "A2401ProCosMonDsc", A2401ProCosMonDsc);
            pr_default.close(14);
         }
      }

      protected void EndLevel7M210( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7M210( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("procostomaterias",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7M0( ) ;
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
            context.RollbackDataStores("procostomaterias",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7M210( )
      {
         /* Using cursor T007M17 */
         pr_default.execute(15);
         RcdFound210 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound210 = 1;
            A2385ProCosProdCod = T007M17_A2385ProCosProdCod[0];
            AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7M210( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound210 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound210 = 1;
            A2385ProCosProdCod = T007M17_A2385ProCosProdCod[0];
            AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
         }
      }

      protected void ScanEnd7M210( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm7M210( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7M210( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7M210( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7M210( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7M210( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7M210( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7M210( )
      {
         edtProCosProdCod_Enabled = 0;
         AssignProp("", false, edtProCosProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCosProdCod_Enabled), 5, 0), true);
         edtProCosProdDsc_Enabled = 0;
         AssignProp("", false, edtProCosProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCosProdDsc_Enabled), 5, 0), true);
         edtProCosMonCod_Enabled = 0;
         AssignProp("", false, edtProCosMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCosMonCod_Enabled), 5, 0), true);
         edtProCosMonDsc_Enabled = 0;
         AssignProp("", false, edtProCosMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCosMonDsc_Enabled), 5, 0), true);
         edtProCosCostoU_Enabled = 0;
         AssignProp("", false, edtProCosCostoU_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProCosCostoU_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7M210( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7M0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Costo Estandar Materias Primas") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271436", false, true);
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
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("procostomaterias.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2385ProCosProdCod", StringUtil.RTrim( Z2385ProCosProdCod));
         GxWebStd.gx_hidden_field( context, "Z2396ProCosCostoU", StringUtil.LTrim( StringUtil.NToC( Z2396ProCosCostoU, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2386ProCosMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2386ProCosMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm7M210( )
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
         return "PROCOSTOMATERIAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Costo Estandar Materias Primas" ;
      }

      protected void InitializeNonKey7M210( )
      {
         A2400ProCosProdDsc = "";
         AssignAttri("", false, "A2400ProCosProdDsc", A2400ProCosProdDsc);
         A2386ProCosMonCod = 0;
         AssignAttri("", false, "A2386ProCosMonCod", StringUtil.LTrimStr( (decimal)(A2386ProCosMonCod), 6, 0));
         A2401ProCosMonDsc = "";
         AssignAttri("", false, "A2401ProCosMonDsc", A2401ProCosMonDsc);
         A2396ProCosCostoU = 0;
         AssignAttri("", false, "A2396ProCosCostoU", StringUtil.LTrimStr( A2396ProCosCostoU, 15, 4));
         Z2396ProCosCostoU = 0;
         Z2386ProCosMonCod = 0;
      }

      protected void InitAll7M210( )
      {
         A2385ProCosProdCod = "";
         AssignAttri("", false, "A2385ProCosProdCod", A2385ProCosProdCod);
         InitializeNonKey7M210( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271441", true, true);
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
         context.AddJavascriptSource("procostomaterias.js", "?202281810271441", false, true);
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
         edtProCosProdCod_Internalname = "PROCOSPRODCOD";
         edtProCosProdDsc_Internalname = "PROCOSPRODDSC";
         edtProCosMonCod_Internalname = "PROCOSMONCOD";
         edtProCosMonDsc_Internalname = "PROCOSMONDSC";
         edtProCosCostoU_Internalname = "PROCOSCOSTOU";
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
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProCosCostoU_Jsonclick = "";
         edtProCosCostoU_Enabled = 1;
         edtProCosMonDsc_Jsonclick = "";
         edtProCosMonDsc_Enabled = 0;
         edtProCosMonCod_Jsonclick = "";
         edtProCosMonCod_Enabled = 1;
         edtProCosProdDsc_Jsonclick = "";
         edtProCosProdDsc_Enabled = 0;
         edtProCosProdCod_Jsonclick = "";
         edtProCosProdCod_Enabled = 1;
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
         GX_FocusControl = edtProCosMonCod_Internalname;
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

      public void Valid_Procosprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T007M15 */
         pr_default.execute(13, new Object[] {A2385ProCosProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Costo Estandar Producto'.", "ForeignKeyNotFound", 1, "PROCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosProdCod_Internalname;
         }
         A2400ProCosProdDsc = T007M15_A2400ProCosProdDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2386ProCosMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2386ProCosMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2396ProCosCostoU", StringUtil.LTrim( StringUtil.NToC( A2396ProCosCostoU, 15, 4, ".", "")));
         AssignAttri("", false, "A2400ProCosProdDsc", StringUtil.RTrim( A2400ProCosProdDsc));
         AssignAttri("", false, "A2401ProCosMonDsc", StringUtil.RTrim( A2401ProCosMonDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2385ProCosProdCod", StringUtil.RTrim( Z2385ProCosProdCod));
         GxWebStd.gx_hidden_field( context, "Z2386ProCosMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2386ProCosMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2396ProCosCostoU", StringUtil.LTrim( StringUtil.NToC( Z2396ProCosCostoU, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2400ProCosProdDsc", StringUtil.RTrim( Z2400ProCosProdDsc));
         GxWebStd.gx_hidden_field( context, "Z2401ProCosMonDsc", StringUtil.RTrim( Z2401ProCosMonDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Procosmoncod( )
      {
         /* Using cursor T007M16 */
         pr_default.execute(14, new Object[] {A2386ProCosMonCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Costo Estandar Moneda'.", "ForeignKeyNotFound", 1, "PROCOSMONCOD");
            AnyError = 1;
            GX_FocusControl = edtProCosMonCod_Internalname;
         }
         A2401ProCosMonDsc = T007M16_A2401ProCosMonDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2401ProCosMonDsc", StringUtil.RTrim( A2401ProCosMonDsc));
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
         setEventMetadata("VALID_PROCOSPRODCOD","{handler:'Valid_Procosprodcod',iparms:[{av:'A2385ProCosProdCod',fld:'PROCOSPRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROCOSPRODCOD",",oparms:[{av:'A2386ProCosMonCod',fld:'PROCOSMONCOD',pic:'ZZZZZ9'},{av:'A2396ProCosCostoU',fld:'PROCOSCOSTOU',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A2400ProCosProdDsc',fld:'PROCOSPRODDSC',pic:''},{av:'A2401ProCosMonDsc',fld:'PROCOSMONDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2385ProCosProdCod'},{av:'Z2386ProCosMonCod'},{av:'Z2396ProCosCostoU'},{av:'Z2400ProCosProdDsc'},{av:'Z2401ProCosMonDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PROCOSMONCOD","{handler:'Valid_Procosmoncod',iparms:[{av:'A2386ProCosMonCod',fld:'PROCOSMONCOD',pic:'ZZZZZ9'},{av:'A2401ProCosMonDsc',fld:'PROCOSMONDSC',pic:''}]");
         setEventMetadata("VALID_PROCOSMONCOD",",oparms:[{av:'A2401ProCosMonDsc',fld:'PROCOSMONDSC',pic:''}]}");
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
         Z2385ProCosProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2385ProCosProdCod = "";
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
         A2400ProCosProdDsc = "";
         A2401ProCosMonDsc = "";
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
         Z2400ProCosProdDsc = "";
         Z2401ProCosMonDsc = "";
         T007M6_A2400ProCosProdDsc = new string[] {""} ;
         T007M6_A2401ProCosMonDsc = new string[] {""} ;
         T007M6_A2396ProCosCostoU = new decimal[1] ;
         T007M6_A2385ProCosProdCod = new string[] {""} ;
         T007M6_A2386ProCosMonCod = new int[1] ;
         T007M4_A2400ProCosProdDsc = new string[] {""} ;
         T007M5_A2401ProCosMonDsc = new string[] {""} ;
         T007M7_A2400ProCosProdDsc = new string[] {""} ;
         T007M8_A2401ProCosMonDsc = new string[] {""} ;
         T007M9_A2385ProCosProdCod = new string[] {""} ;
         T007M3_A2396ProCosCostoU = new decimal[1] ;
         T007M3_A2385ProCosProdCod = new string[] {""} ;
         T007M3_A2386ProCosMonCod = new int[1] ;
         sMode210 = "";
         T007M10_A2385ProCosProdCod = new string[] {""} ;
         T007M11_A2385ProCosProdCod = new string[] {""} ;
         T007M2_A2396ProCosCostoU = new decimal[1] ;
         T007M2_A2385ProCosProdCod = new string[] {""} ;
         T007M2_A2386ProCosMonCod = new int[1] ;
         T007M15_A2400ProCosProdDsc = new string[] {""} ;
         T007M16_A2401ProCosMonDsc = new string[] {""} ;
         T007M17_A2385ProCosProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2385ProCosProdCod = "";
         ZZ2400ProCosProdDsc = "";
         ZZ2401ProCosMonDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.procostomaterias__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procostomaterias__default(),
            new Object[][] {
                new Object[] {
               T007M2_A2396ProCosCostoU, T007M2_A2385ProCosProdCod, T007M2_A2386ProCosMonCod
               }
               , new Object[] {
               T007M3_A2396ProCosCostoU, T007M3_A2385ProCosProdCod, T007M3_A2386ProCosMonCod
               }
               , new Object[] {
               T007M4_A2400ProCosProdDsc
               }
               , new Object[] {
               T007M5_A2401ProCosMonDsc
               }
               , new Object[] {
               T007M6_A2400ProCosProdDsc, T007M6_A2401ProCosMonDsc, T007M6_A2396ProCosCostoU, T007M6_A2385ProCosProdCod, T007M6_A2386ProCosMonCod
               }
               , new Object[] {
               T007M7_A2400ProCosProdDsc
               }
               , new Object[] {
               T007M8_A2401ProCosMonDsc
               }
               , new Object[] {
               T007M9_A2385ProCosProdCod
               }
               , new Object[] {
               T007M10_A2385ProCosProdCod
               }
               , new Object[] {
               T007M11_A2385ProCosProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007M15_A2400ProCosProdDsc
               }
               , new Object[] {
               T007M16_A2401ProCosMonDsc
               }
               , new Object[] {
               T007M17_A2385ProCosProdCod
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
      private short nDynComponent ;
      private short GX_JID ;
      private short RcdFound210 ;
      private short nIsDirty_210 ;
      private short Gx_BScreen ;
      private int Z2386ProCosMonCod ;
      private int A2386ProCosMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProCosProdCod_Enabled ;
      private int edtProCosProdDsc_Enabled ;
      private int edtProCosMonCod_Enabled ;
      private int edtProCosMonDsc_Enabled ;
      private int edtProCosCostoU_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2386ProCosMonCod ;
      private decimal Z2396ProCosCostoU ;
      private decimal A2396ProCosCostoU ;
      private decimal ZZ2396ProCosCostoU ;
      private string sPrefix ;
      private string Z2385ProCosProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2385ProCosProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProCosProdCod_Internalname ;
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
      private string edtProCosProdCod_Jsonclick ;
      private string edtProCosProdDsc_Internalname ;
      private string A2400ProCosProdDsc ;
      private string edtProCosProdDsc_Jsonclick ;
      private string edtProCosMonCod_Internalname ;
      private string edtProCosMonCod_Jsonclick ;
      private string edtProCosMonDsc_Internalname ;
      private string A2401ProCosMonDsc ;
      private string edtProCosMonDsc_Jsonclick ;
      private string edtProCosCostoU_Internalname ;
      private string edtProCosCostoU_Jsonclick ;
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
      private string Z2400ProCosProdDsc ;
      private string Z2401ProCosMonDsc ;
      private string sMode210 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2385ProCosProdCod ;
      private string ZZ2400ProCosProdDsc ;
      private string ZZ2401ProCosMonDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007M6_A2400ProCosProdDsc ;
      private string[] T007M6_A2401ProCosMonDsc ;
      private decimal[] T007M6_A2396ProCosCostoU ;
      private string[] T007M6_A2385ProCosProdCod ;
      private int[] T007M6_A2386ProCosMonCod ;
      private string[] T007M4_A2400ProCosProdDsc ;
      private string[] T007M5_A2401ProCosMonDsc ;
      private string[] T007M7_A2400ProCosProdDsc ;
      private string[] T007M8_A2401ProCosMonDsc ;
      private string[] T007M9_A2385ProCosProdCod ;
      private decimal[] T007M3_A2396ProCosCostoU ;
      private string[] T007M3_A2385ProCosProdCod ;
      private int[] T007M3_A2386ProCosMonCod ;
      private string[] T007M10_A2385ProCosProdCod ;
      private string[] T007M11_A2385ProCosProdCod ;
      private decimal[] T007M2_A2396ProCosCostoU ;
      private string[] T007M2_A2385ProCosProdCod ;
      private int[] T007M2_A2386ProCosMonCod ;
      private string[] T007M15_A2400ProCosProdDsc ;
      private string[] T007M16_A2401ProCosMonDsc ;
      private string[] T007M17_A2385ProCosProdCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class procostomaterias__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class procostomaterias__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007M6;
        prmT007M6 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M4;
        prmT007M4 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M5;
        prmT007M5 = new Object[] {
        new ParDef("@ProCosMonCod",GXType.Int32,6,0)
        };
        Object[] prmT007M7;
        prmT007M7 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M8;
        prmT007M8 = new Object[] {
        new ParDef("@ProCosMonCod",GXType.Int32,6,0)
        };
        Object[] prmT007M9;
        prmT007M9 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M3;
        prmT007M3 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M10;
        prmT007M10 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M11;
        prmT007M11 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M2;
        prmT007M2 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M12;
        prmT007M12 = new Object[] {
        new ParDef("@ProCosCostoU",GXType.Decimal,15,4) ,
        new ParDef("@ProCosProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProCosMonCod",GXType.Int32,6,0)
        };
        Object[] prmT007M13;
        prmT007M13 = new Object[] {
        new ParDef("@ProCosCostoU",GXType.Decimal,15,4) ,
        new ParDef("@ProCosMonCod",GXType.Int32,6,0) ,
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M14;
        prmT007M14 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M17;
        prmT007M17 = new Object[] {
        };
        Object[] prmT007M15;
        prmT007M15 = new Object[] {
        new ParDef("@ProCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007M16;
        prmT007M16 = new Object[] {
        new ParDef("@ProCosMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007M2", "SELECT [ProCosCostoU], [ProCosProdCod] AS ProCosProdCod, [ProCosMonCod] AS ProCosMonCod FROM [PROCOSTOMATERIAS] WITH (UPDLOCK) WHERE [ProCosProdCod] = @ProCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M3", "SELECT [ProCosCostoU], [ProCosProdCod] AS ProCosProdCod, [ProCosMonCod] AS ProCosMonCod FROM [PROCOSTOMATERIAS] WHERE [ProCosProdCod] = @ProCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M4", "SELECT [ProdDsc] AS ProCosProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M5", "SELECT [MonDsc] AS ProCosMonDsc FROM [CMONEDAS] WHERE [MonCod] = @ProCosMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M6", "SELECT T2.[ProdDsc] AS ProCosProdDsc, T3.[MonDsc] AS ProCosMonDsc, TM1.[ProCosCostoU], TM1.[ProCosProdCod] AS ProCosProdCod, TM1.[ProCosMonCod] AS ProCosMonCod FROM (([PROCOSTOMATERIAS] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ProCosProdCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = TM1.[ProCosMonCod]) WHERE TM1.[ProCosProdCod] = @ProCosProdCod ORDER BY TM1.[ProCosProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007M6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M7", "SELECT [ProdDsc] AS ProCosProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M8", "SELECT [MonDsc] AS ProCosMonDsc FROM [CMONEDAS] WHERE [MonCod] = @ProCosMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M9", "SELECT [ProCosProdCod] AS ProCosProdCod FROM [PROCOSTOMATERIAS] WHERE [ProCosProdCod] = @ProCosProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007M9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M10", "SELECT TOP 1 [ProCosProdCod] AS ProCosProdCod FROM [PROCOSTOMATERIAS] WHERE ( [ProCosProdCod] > @ProCosProdCod) ORDER BY [ProCosProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007M10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007M11", "SELECT TOP 1 [ProCosProdCod] AS ProCosProdCod FROM [PROCOSTOMATERIAS] WHERE ( [ProCosProdCod] < @ProCosProdCod) ORDER BY [ProCosProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007M11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007M12", "INSERT INTO [PROCOSTOMATERIAS]([ProCosCostoU], [ProCosProdCod], [ProCosMonCod]) VALUES(@ProCosCostoU, @ProCosProdCod, @ProCosMonCod)", GxErrorMask.GX_NOMASK,prmT007M12)
           ,new CursorDef("T007M13", "UPDATE [PROCOSTOMATERIAS] SET [ProCosCostoU]=@ProCosCostoU, [ProCosMonCod]=@ProCosMonCod  WHERE [ProCosProdCod] = @ProCosProdCod", GxErrorMask.GX_NOMASK,prmT007M13)
           ,new CursorDef("T007M14", "DELETE FROM [PROCOSTOMATERIAS]  WHERE [ProCosProdCod] = @ProCosProdCod", GxErrorMask.GX_NOMASK,prmT007M14)
           ,new CursorDef("T007M15", "SELECT [ProdDsc] AS ProCosProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M16", "SELECT [MonDsc] AS ProCosMonDsc FROM [CMONEDAS] WHERE [MonCod] = @ProCosMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007M16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007M17", "SELECT [ProCosProdCod] AS ProCosProdCod FROM [PROCOSTOMATERIAS] ORDER BY [ProCosProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007M17,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
