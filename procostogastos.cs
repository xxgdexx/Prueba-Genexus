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
   public class procostogastos : GXHttpHandler
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
            A2382ProGasProdCod = GetPar( "ProGasProdCod");
            AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2382ProGasProdCod) ;
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
            Form.Meta.addItem("description", "Costo Estandar Gastos de Fabricación", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProGasProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public procostogastos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public procostogastos( IGxContext context )
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
            RenderHtmlCloseForm7L209( ) ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Costo Estandar Gastos de Fabricación", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_PROCOSTOGASTOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_PROCOSTOGASTOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasProdCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasProdCod_Internalname, StringUtil.RTrim( A2382ProGasProdCod), StringUtil.RTrim( context.localUtil.Format( A2382ProGasProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasProdDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasProdDsc_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProGasProdDsc_Internalname, StringUtil.RTrim( A2398ProGasProdDsc), StringUtil.RTrim( context.localUtil.Format( A2398ProGasProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasMODUND_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasMODUND_Internalname, "MOD Unidades", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasMODUND_Internalname, StringUtil.LTrim( StringUtil.NToC( A2388ProGasMODUND, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasMODUND_Enabled!=0) ? context.localUtil.Format( A2388ProGasMODUND, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2388ProGasMODUND, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasMODUND_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasMODUND_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasMODCos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasMODCos_Internalname, "MOD Costo Unit.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasMODCos_Internalname, StringUtil.LTrim( StringUtil.NToC( A2389ProGasMODCos, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasMODCos_Enabled!=0) ? context.localUtil.Format( A2389ProGasMODCos, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2389ProGasMODCos, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasMODCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasMODCos_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasMOIUND_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasMOIUND_Internalname, "MOI Unidades", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasMOIUND_Internalname, StringUtil.LTrim( StringUtil.NToC( A2390ProGasMOIUND, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasMOIUND_Enabled!=0) ? context.localUtil.Format( A2390ProGasMOIUND, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2390ProGasMOIUND, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasMOIUND_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasMOIUND_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasMOICos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasMOICos_Internalname, "MOI Costo Unit.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasMOICos_Internalname, StringUtil.LTrim( StringUtil.NToC( A2391ProGasMOICos, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasMOICos_Enabled!=0) ? context.localUtil.Format( A2391ProGasMOICos, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2391ProGasMOICos, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasMOICos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasMOICos_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasGIFUND_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasGIFUND_Internalname, "GIF Unidades", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasGIFUND_Internalname, StringUtil.LTrim( StringUtil.NToC( A2392ProGasGIFUND, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasGIFUND_Enabled!=0) ? context.localUtil.Format( A2392ProGasGIFUND, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2392ProGasGIFUND, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasGIFUND_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasGIFUND_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGASGIFCos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGASGIFCos_Internalname, "GIF Costo Unit.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGASGIFCos_Internalname, StringUtil.LTrim( StringUtil.NToC( A2393ProGASGIFCos, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGASGIFCos_Enabled!=0) ? context.localUtil.Format( A2393ProGASGIFCos, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2393ProGASGIFCos, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGASGIFCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGASGIFCos_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasLoteOpt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasLoteOpt_Internalname, "Lote Optimo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasLoteOpt_Internalname, StringUtil.LTrim( StringUtil.NToC( A2395ProGasLoteOpt, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasLoteOpt_Enabled!=0) ? context.localUtil.Format( A2395ProGasLoteOpt, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2395ProGasLoteOpt, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasLoteOpt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasLoteOpt_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasCostoUND_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasCostoUND_Internalname, "Unitario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasCostoUND_Internalname, StringUtil.LTrim( StringUtil.NToC( A2399ProGasCostoUND, 20, 6, ".", "")), StringUtil.LTrim( ((edtProGasCostoUND_Enabled!=0) ? context.localUtil.Format( A2399ProGasCostoUND, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A2399ProGasCostoUND, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasCostoUND_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasCostoUND_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasSubProducto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasSubProducto_Internalname, "Check Sub Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasSubProducto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2397ProGasSubProducto), 1, 0, ".", "")), StringUtil.LTrim( ((edtProGasSubProducto_Enabled!=0) ? context.localUtil.Format( (decimal)(A2397ProGasSubProducto), "9") : context.localUtil.Format( (decimal)(A2397ProGasSubProducto), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasSubProducto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasSubProducto_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProGasPorcentaje_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProGasPorcentaje_Internalname, "% Incremento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProGasPorcentaje_Internalname, StringUtil.LTrim( StringUtil.NToC( A2394ProGasPorcentaje, 15, 2, ".", "")), StringUtil.LTrim( ((edtProGasPorcentaje_Enabled!=0) ? context.localUtil.Format( A2394ProGasPorcentaje, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A2394ProGasPorcentaje, "ZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProGasPorcentaje_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProGasPorcentaje_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_PROCOSTOGASTOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOGASTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 92,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_PROCOSTOGASTOS.htm");
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
            Z2382ProGasProdCod = cgiGet( "Z2382ProGasProdCod");
            Z2388ProGasMODUND = context.localUtil.CToN( cgiGet( "Z2388ProGasMODUND"), ".", ",");
            Z2389ProGasMODCos = context.localUtil.CToN( cgiGet( "Z2389ProGasMODCos"), ".", ",");
            Z2390ProGasMOIUND = context.localUtil.CToN( cgiGet( "Z2390ProGasMOIUND"), ".", ",");
            Z2391ProGasMOICos = context.localUtil.CToN( cgiGet( "Z2391ProGasMOICos"), ".", ",");
            Z2392ProGasGIFUND = context.localUtil.CToN( cgiGet( "Z2392ProGasGIFUND"), ".", ",");
            Z2393ProGASGIFCos = context.localUtil.CToN( cgiGet( "Z2393ProGASGIFCos"), ".", ",");
            Z2395ProGasLoteOpt = context.localUtil.CToN( cgiGet( "Z2395ProGasLoteOpt"), ".", ",");
            Z2399ProGasCostoUND = context.localUtil.CToN( cgiGet( "Z2399ProGasCostoUND"), ".", ",");
            Z2397ProGasSubProducto = (short)(context.localUtil.CToN( cgiGet( "Z2397ProGasSubProducto"), ".", ","));
            Z2394ProGasPorcentaje = context.localUtil.CToN( cgiGet( "Z2394ProGasPorcentaje"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2382ProGasProdCod = StringUtil.Upper( cgiGet( edtProGasProdCod_Internalname));
            AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
            A2398ProGasProdDsc = cgiGet( edtProGasProdDsc_Internalname);
            AssignAttri("", false, "A2398ProGasProdDsc", A2398ProGasProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasMODUND_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasMODUND_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASMODUND");
               AnyError = 1;
               GX_FocusControl = edtProGasMODUND_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2388ProGasMODUND = 0;
               AssignAttri("", false, "A2388ProGasMODUND", StringUtil.LTrimStr( A2388ProGasMODUND, 18, 6));
            }
            else
            {
               A2388ProGasMODUND = context.localUtil.CToN( cgiGet( edtProGasMODUND_Internalname), ".", ",");
               AssignAttri("", false, "A2388ProGasMODUND", StringUtil.LTrimStr( A2388ProGasMODUND, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasMODCos_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasMODCos_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASMODCOS");
               AnyError = 1;
               GX_FocusControl = edtProGasMODCos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2389ProGasMODCos = 0;
               AssignAttri("", false, "A2389ProGasMODCos", StringUtil.LTrimStr( A2389ProGasMODCos, 18, 6));
            }
            else
            {
               A2389ProGasMODCos = context.localUtil.CToN( cgiGet( edtProGasMODCos_Internalname), ".", ",");
               AssignAttri("", false, "A2389ProGasMODCos", StringUtil.LTrimStr( A2389ProGasMODCos, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasMOIUND_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasMOIUND_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASMOIUND");
               AnyError = 1;
               GX_FocusControl = edtProGasMOIUND_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2390ProGasMOIUND = 0;
               AssignAttri("", false, "A2390ProGasMOIUND", StringUtil.LTrimStr( A2390ProGasMOIUND, 18, 6));
            }
            else
            {
               A2390ProGasMOIUND = context.localUtil.CToN( cgiGet( edtProGasMOIUND_Internalname), ".", ",");
               AssignAttri("", false, "A2390ProGasMOIUND", StringUtil.LTrimStr( A2390ProGasMOIUND, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasMOICos_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasMOICos_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASMOICOS");
               AnyError = 1;
               GX_FocusControl = edtProGasMOICos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2391ProGasMOICos = 0;
               AssignAttri("", false, "A2391ProGasMOICos", StringUtil.LTrimStr( A2391ProGasMOICos, 18, 6));
            }
            else
            {
               A2391ProGasMOICos = context.localUtil.CToN( cgiGet( edtProGasMOICos_Internalname), ".", ",");
               AssignAttri("", false, "A2391ProGasMOICos", StringUtil.LTrimStr( A2391ProGasMOICos, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasGIFUND_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasGIFUND_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASGIFUND");
               AnyError = 1;
               GX_FocusControl = edtProGasGIFUND_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2392ProGasGIFUND = 0;
               AssignAttri("", false, "A2392ProGasGIFUND", StringUtil.LTrimStr( A2392ProGasGIFUND, 18, 6));
            }
            else
            {
               A2392ProGasGIFUND = context.localUtil.CToN( cgiGet( edtProGasGIFUND_Internalname), ".", ",");
               AssignAttri("", false, "A2392ProGasGIFUND", StringUtil.LTrimStr( A2392ProGasGIFUND, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGASGIFCos_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGASGIFCos_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASGIFCOS");
               AnyError = 1;
               GX_FocusControl = edtProGASGIFCos_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2393ProGASGIFCos = 0;
               AssignAttri("", false, "A2393ProGASGIFCos", StringUtil.LTrimStr( A2393ProGASGIFCos, 18, 6));
            }
            else
            {
               A2393ProGASGIFCos = context.localUtil.CToN( cgiGet( edtProGASGIFCos_Internalname), ".", ",");
               AssignAttri("", false, "A2393ProGASGIFCos", StringUtil.LTrimStr( A2393ProGASGIFCos, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasLoteOpt_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasLoteOpt_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASLOTEOPT");
               AnyError = 1;
               GX_FocusControl = edtProGasLoteOpt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2395ProGasLoteOpt = 0;
               AssignAttri("", false, "A2395ProGasLoteOpt", StringUtil.LTrimStr( A2395ProGasLoteOpt, 18, 6));
            }
            else
            {
               A2395ProGasLoteOpt = context.localUtil.CToN( cgiGet( edtProGasLoteOpt_Internalname), ".", ",");
               AssignAttri("", false, "A2395ProGasLoteOpt", StringUtil.LTrimStr( A2395ProGasLoteOpt, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasCostoUND_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasCostoUND_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASCOSTOUND");
               AnyError = 1;
               GX_FocusControl = edtProGasCostoUND_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2399ProGasCostoUND = 0;
               AssignAttri("", false, "A2399ProGasCostoUND", StringUtil.LTrimStr( A2399ProGasCostoUND, 18, 6));
            }
            else
            {
               A2399ProGasCostoUND = context.localUtil.CToN( cgiGet( edtProGasCostoUND_Internalname), ".", ",");
               AssignAttri("", false, "A2399ProGasCostoUND", StringUtil.LTrimStr( A2399ProGasCostoUND, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasSubProducto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasSubProducto_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASSUBPRODUCTO");
               AnyError = 1;
               GX_FocusControl = edtProGasSubProducto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2397ProGasSubProducto = 0;
               AssignAttri("", false, "A2397ProGasSubProducto", StringUtil.Str( (decimal)(A2397ProGasSubProducto), 1, 0));
            }
            else
            {
               A2397ProGasSubProducto = (short)(context.localUtil.CToN( cgiGet( edtProGasSubProducto_Internalname), ".", ","));
               AssignAttri("", false, "A2397ProGasSubProducto", StringUtil.Str( (decimal)(A2397ProGasSubProducto), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtProGasPorcentaje_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProGasPorcentaje_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROGASPORCENTAJE");
               AnyError = 1;
               GX_FocusControl = edtProGasPorcentaje_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2394ProGasPorcentaje = 0;
               AssignAttri("", false, "A2394ProGasPorcentaje", StringUtil.LTrimStr( A2394ProGasPorcentaje, 15, 2));
            }
            else
            {
               A2394ProGasPorcentaje = context.localUtil.CToN( cgiGet( edtProGasPorcentaje_Internalname), ".", ",");
               AssignAttri("", false, "A2394ProGasPorcentaje", StringUtil.LTrimStr( A2394ProGasPorcentaje, 15, 2));
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
               A2382ProGasProdCod = GetPar( "ProGasProdCod");
               AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
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
               InitAll7L209( ) ;
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
         DisableAttributes7L209( ) ;
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

      protected void ResetCaption7L0( )
      {
      }

      protected void ZM7L209( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2388ProGasMODUND = T007L3_A2388ProGasMODUND[0];
               Z2389ProGasMODCos = T007L3_A2389ProGasMODCos[0];
               Z2390ProGasMOIUND = T007L3_A2390ProGasMOIUND[0];
               Z2391ProGasMOICos = T007L3_A2391ProGasMOICos[0];
               Z2392ProGasGIFUND = T007L3_A2392ProGasGIFUND[0];
               Z2393ProGASGIFCos = T007L3_A2393ProGASGIFCos[0];
               Z2395ProGasLoteOpt = T007L3_A2395ProGasLoteOpt[0];
               Z2399ProGasCostoUND = T007L3_A2399ProGasCostoUND[0];
               Z2397ProGasSubProducto = T007L3_A2397ProGasSubProducto[0];
               Z2394ProGasPorcentaje = T007L3_A2394ProGasPorcentaje[0];
            }
            else
            {
               Z2388ProGasMODUND = A2388ProGasMODUND;
               Z2389ProGasMODCos = A2389ProGasMODCos;
               Z2390ProGasMOIUND = A2390ProGasMOIUND;
               Z2391ProGasMOICos = A2391ProGasMOICos;
               Z2392ProGasGIFUND = A2392ProGasGIFUND;
               Z2393ProGASGIFCos = A2393ProGASGIFCos;
               Z2395ProGasLoteOpt = A2395ProGasLoteOpt;
               Z2399ProGasCostoUND = A2399ProGasCostoUND;
               Z2397ProGasSubProducto = A2397ProGasSubProducto;
               Z2394ProGasPorcentaje = A2394ProGasPorcentaje;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2388ProGasMODUND = A2388ProGasMODUND;
            Z2389ProGasMODCos = A2389ProGasMODCos;
            Z2390ProGasMOIUND = A2390ProGasMOIUND;
            Z2391ProGasMOICos = A2391ProGasMOICos;
            Z2392ProGasGIFUND = A2392ProGasGIFUND;
            Z2393ProGASGIFCos = A2393ProGASGIFCos;
            Z2395ProGasLoteOpt = A2395ProGasLoteOpt;
            Z2399ProGasCostoUND = A2399ProGasCostoUND;
            Z2397ProGasSubProducto = A2397ProGasSubProducto;
            Z2394ProGasPorcentaje = A2394ProGasPorcentaje;
            Z2382ProGasProdCod = A2382ProGasProdCod;
            Z2398ProGasProdDsc = A2398ProGasProdDsc;
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

      protected void Load7L209( )
      {
         /* Using cursor T007L5 */
         pr_default.execute(3, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound209 = 1;
            A2398ProGasProdDsc = T007L5_A2398ProGasProdDsc[0];
            AssignAttri("", false, "A2398ProGasProdDsc", A2398ProGasProdDsc);
            A2388ProGasMODUND = T007L5_A2388ProGasMODUND[0];
            AssignAttri("", false, "A2388ProGasMODUND", StringUtil.LTrimStr( A2388ProGasMODUND, 18, 6));
            A2389ProGasMODCos = T007L5_A2389ProGasMODCos[0];
            AssignAttri("", false, "A2389ProGasMODCos", StringUtil.LTrimStr( A2389ProGasMODCos, 18, 6));
            A2390ProGasMOIUND = T007L5_A2390ProGasMOIUND[0];
            AssignAttri("", false, "A2390ProGasMOIUND", StringUtil.LTrimStr( A2390ProGasMOIUND, 18, 6));
            A2391ProGasMOICos = T007L5_A2391ProGasMOICos[0];
            AssignAttri("", false, "A2391ProGasMOICos", StringUtil.LTrimStr( A2391ProGasMOICos, 18, 6));
            A2392ProGasGIFUND = T007L5_A2392ProGasGIFUND[0];
            AssignAttri("", false, "A2392ProGasGIFUND", StringUtil.LTrimStr( A2392ProGasGIFUND, 18, 6));
            A2393ProGASGIFCos = T007L5_A2393ProGASGIFCos[0];
            AssignAttri("", false, "A2393ProGASGIFCos", StringUtil.LTrimStr( A2393ProGASGIFCos, 18, 6));
            A2395ProGasLoteOpt = T007L5_A2395ProGasLoteOpt[0];
            AssignAttri("", false, "A2395ProGasLoteOpt", StringUtil.LTrimStr( A2395ProGasLoteOpt, 18, 6));
            A2399ProGasCostoUND = T007L5_A2399ProGasCostoUND[0];
            AssignAttri("", false, "A2399ProGasCostoUND", StringUtil.LTrimStr( A2399ProGasCostoUND, 18, 6));
            A2397ProGasSubProducto = T007L5_A2397ProGasSubProducto[0];
            AssignAttri("", false, "A2397ProGasSubProducto", StringUtil.Str( (decimal)(A2397ProGasSubProducto), 1, 0));
            A2394ProGasPorcentaje = T007L5_A2394ProGasPorcentaje[0];
            AssignAttri("", false, "A2394ProGasPorcentaje", StringUtil.LTrimStr( A2394ProGasPorcentaje, 15, 2));
            ZM7L209( -1) ;
         }
         pr_default.close(3);
         OnLoadActions7L209( ) ;
      }

      protected void OnLoadActions7L209( )
      {
      }

      protected void CheckExtendedTable7L209( )
      {
         nIsDirty_209 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007L4 */
         pr_default.execute(2, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Gastos Fabricacion Producto'.", "ForeignKeyNotFound", 1, "PROGASPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProGasProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2398ProGasProdDsc = T007L4_A2398ProGasProdDsc[0];
         AssignAttri("", false, "A2398ProGasProdDsc", A2398ProGasProdDsc);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7L209( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A2382ProGasProdCod )
      {
         /* Using cursor T007L6 */
         pr_default.execute(4, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Gastos Fabricacion Producto'.", "ForeignKeyNotFound", 1, "PROGASPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProGasProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2398ProGasProdDsc = T007L6_A2398ProGasProdDsc[0];
         AssignAttri("", false, "A2398ProGasProdDsc", A2398ProGasProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2398ProGasProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey7L209( )
      {
         /* Using cursor T007L7 */
         pr_default.execute(5, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound209 = 1;
         }
         else
         {
            RcdFound209 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007L3 */
         pr_default.execute(1, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7L209( 1) ;
            RcdFound209 = 1;
            A2388ProGasMODUND = T007L3_A2388ProGasMODUND[0];
            AssignAttri("", false, "A2388ProGasMODUND", StringUtil.LTrimStr( A2388ProGasMODUND, 18, 6));
            A2389ProGasMODCos = T007L3_A2389ProGasMODCos[0];
            AssignAttri("", false, "A2389ProGasMODCos", StringUtil.LTrimStr( A2389ProGasMODCos, 18, 6));
            A2390ProGasMOIUND = T007L3_A2390ProGasMOIUND[0];
            AssignAttri("", false, "A2390ProGasMOIUND", StringUtil.LTrimStr( A2390ProGasMOIUND, 18, 6));
            A2391ProGasMOICos = T007L3_A2391ProGasMOICos[0];
            AssignAttri("", false, "A2391ProGasMOICos", StringUtil.LTrimStr( A2391ProGasMOICos, 18, 6));
            A2392ProGasGIFUND = T007L3_A2392ProGasGIFUND[0];
            AssignAttri("", false, "A2392ProGasGIFUND", StringUtil.LTrimStr( A2392ProGasGIFUND, 18, 6));
            A2393ProGASGIFCos = T007L3_A2393ProGASGIFCos[0];
            AssignAttri("", false, "A2393ProGASGIFCos", StringUtil.LTrimStr( A2393ProGASGIFCos, 18, 6));
            A2395ProGasLoteOpt = T007L3_A2395ProGasLoteOpt[0];
            AssignAttri("", false, "A2395ProGasLoteOpt", StringUtil.LTrimStr( A2395ProGasLoteOpt, 18, 6));
            A2399ProGasCostoUND = T007L3_A2399ProGasCostoUND[0];
            AssignAttri("", false, "A2399ProGasCostoUND", StringUtil.LTrimStr( A2399ProGasCostoUND, 18, 6));
            A2397ProGasSubProducto = T007L3_A2397ProGasSubProducto[0];
            AssignAttri("", false, "A2397ProGasSubProducto", StringUtil.Str( (decimal)(A2397ProGasSubProducto), 1, 0));
            A2394ProGasPorcentaje = T007L3_A2394ProGasPorcentaje[0];
            AssignAttri("", false, "A2394ProGasPorcentaje", StringUtil.LTrimStr( A2394ProGasPorcentaje, 15, 2));
            A2382ProGasProdCod = T007L3_A2382ProGasProdCod[0];
            AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
            Z2382ProGasProdCod = A2382ProGasProdCod;
            sMode209 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7L209( ) ;
            if ( AnyError == 1 )
            {
               RcdFound209 = 0;
               InitializeNonKey7L209( ) ;
            }
            Gx_mode = sMode209;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound209 = 0;
            InitializeNonKey7L209( ) ;
            sMode209 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode209;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7L209( ) ;
         if ( RcdFound209 == 0 )
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
         RcdFound209 = 0;
         /* Using cursor T007L8 */
         pr_default.execute(6, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T007L8_A2382ProGasProdCod[0], A2382ProGasProdCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T007L8_A2382ProGasProdCod[0], A2382ProGasProdCod) > 0 ) ) )
            {
               A2382ProGasProdCod = T007L8_A2382ProGasProdCod[0];
               AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
               RcdFound209 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound209 = 0;
         /* Using cursor T007L9 */
         pr_default.execute(7, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T007L9_A2382ProGasProdCod[0], A2382ProGasProdCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T007L9_A2382ProGasProdCod[0], A2382ProGasProdCod) < 0 ) ) )
            {
               A2382ProGasProdCod = T007L9_A2382ProGasProdCod[0];
               AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
               RcdFound209 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7L209( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProGasProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7L209( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound209 == 1 )
            {
               if ( StringUtil.StrCmp(A2382ProGasProdCod, Z2382ProGasProdCod) != 0 )
               {
                  A2382ProGasProdCod = Z2382ProGasProdCod;
                  AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROGASPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProGasProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProGasProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7L209( ) ;
                  GX_FocusControl = edtProGasProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2382ProGasProdCod, Z2382ProGasProdCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProGasProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7L209( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROGASPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProGasProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProGasProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7L209( ) ;
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
         if ( StringUtil.StrCmp(A2382ProGasProdCod, Z2382ProGasProdCod) != 0 )
         {
            A2382ProGasProdCod = Z2382ProGasProdCod;
            AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROGASPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProGasProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProGasProdCod_Internalname;
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
         if ( RcdFound209 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PROGASPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProGasProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtProGasMODUND_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7L209( ) ;
         if ( RcdFound209 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasMODUND_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7L209( ) ;
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
         if ( RcdFound209 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasMODUND_Internalname;
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
         if ( RcdFound209 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasMODUND_Internalname;
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
         ScanStart7L209( ) ;
         if ( RcdFound209 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound209 != 0 )
            {
               ScanNext7L209( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtProGasMODUND_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7L209( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7L209( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007L2 */
            pr_default.execute(0, new Object[] {A2382ProGasProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PROCOSTOGASTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z2388ProGasMODUND != T007L2_A2388ProGasMODUND[0] ) || ( Z2389ProGasMODCos != T007L2_A2389ProGasMODCos[0] ) || ( Z2390ProGasMOIUND != T007L2_A2390ProGasMOIUND[0] ) || ( Z2391ProGasMOICos != T007L2_A2391ProGasMOICos[0] ) || ( Z2392ProGasGIFUND != T007L2_A2392ProGasGIFUND[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2393ProGASGIFCos != T007L2_A2393ProGASGIFCos[0] ) || ( Z2395ProGasLoteOpt != T007L2_A2395ProGasLoteOpt[0] ) || ( Z2399ProGasCostoUND != T007L2_A2399ProGasCostoUND[0] ) || ( Z2397ProGasSubProducto != T007L2_A2397ProGasSubProducto[0] ) || ( Z2394ProGasPorcentaje != T007L2_A2394ProGasPorcentaje[0] ) )
            {
               if ( Z2388ProGasMODUND != T007L2_A2388ProGasMODUND[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasMODUND");
                  GXUtil.WriteLogRaw("Old: ",Z2388ProGasMODUND);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2388ProGasMODUND[0]);
               }
               if ( Z2389ProGasMODCos != T007L2_A2389ProGasMODCos[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasMODCos");
                  GXUtil.WriteLogRaw("Old: ",Z2389ProGasMODCos);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2389ProGasMODCos[0]);
               }
               if ( Z2390ProGasMOIUND != T007L2_A2390ProGasMOIUND[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasMOIUND");
                  GXUtil.WriteLogRaw("Old: ",Z2390ProGasMOIUND);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2390ProGasMOIUND[0]);
               }
               if ( Z2391ProGasMOICos != T007L2_A2391ProGasMOICos[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasMOICos");
                  GXUtil.WriteLogRaw("Old: ",Z2391ProGasMOICos);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2391ProGasMOICos[0]);
               }
               if ( Z2392ProGasGIFUND != T007L2_A2392ProGasGIFUND[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasGIFUND");
                  GXUtil.WriteLogRaw("Old: ",Z2392ProGasGIFUND);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2392ProGasGIFUND[0]);
               }
               if ( Z2393ProGASGIFCos != T007L2_A2393ProGASGIFCos[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGASGIFCos");
                  GXUtil.WriteLogRaw("Old: ",Z2393ProGASGIFCos);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2393ProGASGIFCos[0]);
               }
               if ( Z2395ProGasLoteOpt != T007L2_A2395ProGasLoteOpt[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasLoteOpt");
                  GXUtil.WriteLogRaw("Old: ",Z2395ProGasLoteOpt);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2395ProGasLoteOpt[0]);
               }
               if ( Z2399ProGasCostoUND != T007L2_A2399ProGasCostoUND[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasCostoUND");
                  GXUtil.WriteLogRaw("Old: ",Z2399ProGasCostoUND);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2399ProGasCostoUND[0]);
               }
               if ( Z2397ProGasSubProducto != T007L2_A2397ProGasSubProducto[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasSubProducto");
                  GXUtil.WriteLogRaw("Old: ",Z2397ProGasSubProducto);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2397ProGasSubProducto[0]);
               }
               if ( Z2394ProGasPorcentaje != T007L2_A2394ProGasPorcentaje[0] )
               {
                  GXUtil.WriteLog("procostogastos:[seudo value changed for attri]"+"ProGasPorcentaje");
                  GXUtil.WriteLogRaw("Old: ",Z2394ProGasPorcentaje);
                  GXUtil.WriteLogRaw("Current: ",T007L2_A2394ProGasPorcentaje[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PROCOSTOGASTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7L209( )
      {
         BeforeValidate7L209( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7L209( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7L209( 0) ;
            CheckOptimisticConcurrency7L209( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7L209( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7L209( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007L10 */
                     pr_default.execute(8, new Object[] {A2388ProGasMODUND, A2389ProGasMODCos, A2390ProGasMOIUND, A2391ProGasMOICos, A2392ProGasGIFUND, A2393ProGASGIFCos, A2395ProGasLoteOpt, A2399ProGasCostoUND, A2397ProGasSubProducto, A2394ProGasPorcentaje, A2382ProGasProdCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOGASTOS");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption7L0( ) ;
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
               Load7L209( ) ;
            }
            EndLevel7L209( ) ;
         }
         CloseExtendedTableCursors7L209( ) ;
      }

      protected void Update7L209( )
      {
         BeforeValidate7L209( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7L209( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7L209( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7L209( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7L209( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007L11 */
                     pr_default.execute(9, new Object[] {A2388ProGasMODUND, A2389ProGasMODCos, A2390ProGasMOIUND, A2391ProGasMOICos, A2392ProGasGIFUND, A2393ProGASGIFCos, A2395ProGasLoteOpt, A2399ProGasCostoUND, A2397ProGasSubProducto, A2394ProGasPorcentaje, A2382ProGasProdCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOGASTOS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PROCOSTOGASTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7L209( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7L0( ) ;
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
            EndLevel7L209( ) ;
         }
         CloseExtendedTableCursors7L209( ) ;
      }

      protected void DeferredUpdate7L209( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7L209( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7L209( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7L209( ) ;
            AfterConfirm7L209( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7L209( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007L12 */
                  pr_default.execute(10, new Object[] {A2382ProGasProdCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("PROCOSTOGASTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound209 == 0 )
                        {
                           InitAll7L209( ) ;
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
                        ResetCaption7L0( ) ;
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
         sMode209 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7L209( ) ;
         Gx_mode = sMode209;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7L209( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007L13 */
            pr_default.execute(11, new Object[] {A2382ProGasProdCod});
            A2398ProGasProdDsc = T007L13_A2398ProGasProdDsc[0];
            AssignAttri("", false, "A2398ProGasProdDsc", A2398ProGasProdDsc);
            pr_default.close(11);
         }
      }

      protected void EndLevel7L209( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7L209( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("procostogastos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("procostogastos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7L209( )
      {
         /* Using cursor T007L14 */
         pr_default.execute(12);
         RcdFound209 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound209 = 1;
            A2382ProGasProdCod = T007L14_A2382ProGasProdCod[0];
            AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7L209( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound209 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound209 = 1;
            A2382ProGasProdCod = T007L14_A2382ProGasProdCod[0];
            AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
         }
      }

      protected void ScanEnd7L209( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm7L209( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7L209( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7L209( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7L209( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7L209( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7L209( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7L209( )
      {
         edtProGasProdCod_Enabled = 0;
         AssignProp("", false, edtProGasProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasProdCod_Enabled), 5, 0), true);
         edtProGasProdDsc_Enabled = 0;
         AssignProp("", false, edtProGasProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasProdDsc_Enabled), 5, 0), true);
         edtProGasMODUND_Enabled = 0;
         AssignProp("", false, edtProGasMODUND_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasMODUND_Enabled), 5, 0), true);
         edtProGasMODCos_Enabled = 0;
         AssignProp("", false, edtProGasMODCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasMODCos_Enabled), 5, 0), true);
         edtProGasMOIUND_Enabled = 0;
         AssignProp("", false, edtProGasMOIUND_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasMOIUND_Enabled), 5, 0), true);
         edtProGasMOICos_Enabled = 0;
         AssignProp("", false, edtProGasMOICos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasMOICos_Enabled), 5, 0), true);
         edtProGasGIFUND_Enabled = 0;
         AssignProp("", false, edtProGasGIFUND_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasGIFUND_Enabled), 5, 0), true);
         edtProGASGIFCos_Enabled = 0;
         AssignProp("", false, edtProGASGIFCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGASGIFCos_Enabled), 5, 0), true);
         edtProGasLoteOpt_Enabled = 0;
         AssignProp("", false, edtProGasLoteOpt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasLoteOpt_Enabled), 5, 0), true);
         edtProGasCostoUND_Enabled = 0;
         AssignProp("", false, edtProGasCostoUND_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasCostoUND_Enabled), 5, 0), true);
         edtProGasSubProducto_Enabled = 0;
         AssignProp("", false, edtProGasSubProducto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasSubProducto_Enabled), 5, 0), true);
         edtProGasPorcentaje_Enabled = 0;
         AssignProp("", false, edtProGasPorcentaje_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProGasPorcentaje_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7L209( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7L0( )
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
         context.SendWebValue( "Costo Estandar Gastos de Fabricación") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810271676", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("procostogastos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2382ProGasProdCod", StringUtil.RTrim( Z2382ProGasProdCod));
         GxWebStd.gx_hidden_field( context, "Z2388ProGasMODUND", StringUtil.LTrim( StringUtil.NToC( Z2388ProGasMODUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2389ProGasMODCos", StringUtil.LTrim( StringUtil.NToC( Z2389ProGasMODCos, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2390ProGasMOIUND", StringUtil.LTrim( StringUtil.NToC( Z2390ProGasMOIUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2391ProGasMOICos", StringUtil.LTrim( StringUtil.NToC( Z2391ProGasMOICos, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2392ProGasGIFUND", StringUtil.LTrim( StringUtil.NToC( Z2392ProGasGIFUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2393ProGASGIFCos", StringUtil.LTrim( StringUtil.NToC( Z2393ProGASGIFCos, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2395ProGasLoteOpt", StringUtil.LTrim( StringUtil.NToC( Z2395ProGasLoteOpt, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2399ProGasCostoUND", StringUtil.LTrim( StringUtil.NToC( Z2399ProGasCostoUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2397ProGasSubProducto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2397ProGasSubProducto), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2394ProGasPorcentaje", StringUtil.LTrim( StringUtil.NToC( Z2394ProGasPorcentaje, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm7L209( )
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
         return "PROCOSTOGASTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Costo Estandar Gastos de Fabricación" ;
      }

      protected void InitializeNonKey7L209( )
      {
         A2398ProGasProdDsc = "";
         AssignAttri("", false, "A2398ProGasProdDsc", A2398ProGasProdDsc);
         A2388ProGasMODUND = 0;
         AssignAttri("", false, "A2388ProGasMODUND", StringUtil.LTrimStr( A2388ProGasMODUND, 18, 6));
         A2389ProGasMODCos = 0;
         AssignAttri("", false, "A2389ProGasMODCos", StringUtil.LTrimStr( A2389ProGasMODCos, 18, 6));
         A2390ProGasMOIUND = 0;
         AssignAttri("", false, "A2390ProGasMOIUND", StringUtil.LTrimStr( A2390ProGasMOIUND, 18, 6));
         A2391ProGasMOICos = 0;
         AssignAttri("", false, "A2391ProGasMOICos", StringUtil.LTrimStr( A2391ProGasMOICos, 18, 6));
         A2392ProGasGIFUND = 0;
         AssignAttri("", false, "A2392ProGasGIFUND", StringUtil.LTrimStr( A2392ProGasGIFUND, 18, 6));
         A2393ProGASGIFCos = 0;
         AssignAttri("", false, "A2393ProGASGIFCos", StringUtil.LTrimStr( A2393ProGASGIFCos, 18, 6));
         A2395ProGasLoteOpt = 0;
         AssignAttri("", false, "A2395ProGasLoteOpt", StringUtil.LTrimStr( A2395ProGasLoteOpt, 18, 6));
         A2399ProGasCostoUND = 0;
         AssignAttri("", false, "A2399ProGasCostoUND", StringUtil.LTrimStr( A2399ProGasCostoUND, 18, 6));
         A2397ProGasSubProducto = 0;
         AssignAttri("", false, "A2397ProGasSubProducto", StringUtil.Str( (decimal)(A2397ProGasSubProducto), 1, 0));
         A2394ProGasPorcentaje = 0;
         AssignAttri("", false, "A2394ProGasPorcentaje", StringUtil.LTrimStr( A2394ProGasPorcentaje, 15, 2));
         Z2388ProGasMODUND = 0;
         Z2389ProGasMODCos = 0;
         Z2390ProGasMOIUND = 0;
         Z2391ProGasMOICos = 0;
         Z2392ProGasGIFUND = 0;
         Z2393ProGASGIFCos = 0;
         Z2395ProGasLoteOpt = 0;
         Z2399ProGasCostoUND = 0;
         Z2397ProGasSubProducto = 0;
         Z2394ProGasPorcentaje = 0;
      }

      protected void InitAll7L209( )
      {
         A2382ProGasProdCod = "";
         AssignAttri("", false, "A2382ProGasProdCod", A2382ProGasProdCod);
         InitializeNonKey7L209( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810271686", true, true);
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
         context.AddJavascriptSource("procostogastos.js", "?202281810271687", false, true);
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
         edtProGasProdCod_Internalname = "PROGASPRODCOD";
         edtProGasProdDsc_Internalname = "PROGASPRODDSC";
         edtProGasMODUND_Internalname = "PROGASMODUND";
         edtProGasMODCos_Internalname = "PROGASMODCOS";
         edtProGasMOIUND_Internalname = "PROGASMOIUND";
         edtProGasMOICos_Internalname = "PROGASMOICOS";
         edtProGasGIFUND_Internalname = "PROGASGIFUND";
         edtProGASGIFCos_Internalname = "PROGASGIFCOS";
         edtProGasLoteOpt_Internalname = "PROGASLOTEOPT";
         edtProGasCostoUND_Internalname = "PROGASCOSTOUND";
         edtProGasSubProducto_Internalname = "PROGASSUBPRODUCTO";
         edtProGasPorcentaje_Internalname = "PROGASPORCENTAJE";
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
         edtProGasPorcentaje_Jsonclick = "";
         edtProGasPorcentaje_Enabled = 1;
         edtProGasSubProducto_Jsonclick = "";
         edtProGasSubProducto_Enabled = 1;
         edtProGasCostoUND_Jsonclick = "";
         edtProGasCostoUND_Enabled = 1;
         edtProGasLoteOpt_Jsonclick = "";
         edtProGasLoteOpt_Enabled = 1;
         edtProGASGIFCos_Jsonclick = "";
         edtProGASGIFCos_Enabled = 1;
         edtProGasGIFUND_Jsonclick = "";
         edtProGasGIFUND_Enabled = 1;
         edtProGasMOICos_Jsonclick = "";
         edtProGasMOICos_Enabled = 1;
         edtProGasMOIUND_Jsonclick = "";
         edtProGasMOIUND_Enabled = 1;
         edtProGasMODCos_Jsonclick = "";
         edtProGasMODCos_Enabled = 1;
         edtProGasMODUND_Jsonclick = "";
         edtProGasMODUND_Enabled = 1;
         edtProGasProdDsc_Jsonclick = "";
         edtProGasProdDsc_Enabled = 0;
         edtProGasProdCod_Jsonclick = "";
         edtProGasProdCod_Enabled = 1;
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
         GX_FocusControl = edtProGasMODUND_Internalname;
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

      public void Valid_Progasprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T007L13 */
         pr_default.execute(11, new Object[] {A2382ProGasProdCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Gastos Fabricacion Producto'.", "ForeignKeyNotFound", 1, "PROGASPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProGasProdCod_Internalname;
         }
         A2398ProGasProdDsc = T007L13_A2398ProGasProdDsc[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2388ProGasMODUND", StringUtil.LTrim( StringUtil.NToC( A2388ProGasMODUND, 18, 6, ".", "")));
         AssignAttri("", false, "A2389ProGasMODCos", StringUtil.LTrim( StringUtil.NToC( A2389ProGasMODCos, 18, 6, ".", "")));
         AssignAttri("", false, "A2390ProGasMOIUND", StringUtil.LTrim( StringUtil.NToC( A2390ProGasMOIUND, 18, 6, ".", "")));
         AssignAttri("", false, "A2391ProGasMOICos", StringUtil.LTrim( StringUtil.NToC( A2391ProGasMOICos, 18, 6, ".", "")));
         AssignAttri("", false, "A2392ProGasGIFUND", StringUtil.LTrim( StringUtil.NToC( A2392ProGasGIFUND, 18, 6, ".", "")));
         AssignAttri("", false, "A2393ProGASGIFCos", StringUtil.LTrim( StringUtil.NToC( A2393ProGASGIFCos, 18, 6, ".", "")));
         AssignAttri("", false, "A2395ProGasLoteOpt", StringUtil.LTrim( StringUtil.NToC( A2395ProGasLoteOpt, 18, 6, ".", "")));
         AssignAttri("", false, "A2399ProGasCostoUND", StringUtil.LTrim( StringUtil.NToC( A2399ProGasCostoUND, 18, 6, ".", "")));
         AssignAttri("", false, "A2397ProGasSubProducto", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2397ProGasSubProducto), 1, 0, ".", "")));
         AssignAttri("", false, "A2394ProGasPorcentaje", StringUtil.LTrim( StringUtil.NToC( A2394ProGasPorcentaje, 15, 2, ".", "")));
         AssignAttri("", false, "A2398ProGasProdDsc", StringUtil.RTrim( A2398ProGasProdDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2382ProGasProdCod", StringUtil.RTrim( Z2382ProGasProdCod));
         GxWebStd.gx_hidden_field( context, "Z2388ProGasMODUND", StringUtil.LTrim( StringUtil.NToC( Z2388ProGasMODUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2389ProGasMODCos", StringUtil.LTrim( StringUtil.NToC( Z2389ProGasMODCos, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2390ProGasMOIUND", StringUtil.LTrim( StringUtil.NToC( Z2390ProGasMOIUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2391ProGasMOICos", StringUtil.LTrim( StringUtil.NToC( Z2391ProGasMOICos, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2392ProGasGIFUND", StringUtil.LTrim( StringUtil.NToC( Z2392ProGasGIFUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2393ProGASGIFCos", StringUtil.LTrim( StringUtil.NToC( Z2393ProGASGIFCos, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2395ProGasLoteOpt", StringUtil.LTrim( StringUtil.NToC( Z2395ProGasLoteOpt, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2399ProGasCostoUND", StringUtil.LTrim( StringUtil.NToC( Z2399ProGasCostoUND, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2397ProGasSubProducto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2397ProGasSubProducto), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2394ProGasPorcentaje", StringUtil.LTrim( StringUtil.NToC( Z2394ProGasPorcentaje, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2398ProGasProdDsc", StringUtil.RTrim( Z2398ProGasProdDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
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
         setEventMetadata("VALID_PROGASPRODCOD","{handler:'Valid_Progasprodcod',iparms:[{av:'A2382ProGasProdCod',fld:'PROGASPRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PROGASPRODCOD",",oparms:[{av:'A2388ProGasMODUND',fld:'PROGASMODUND',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2389ProGasMODCos',fld:'PROGASMODCOS',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2390ProGasMOIUND',fld:'PROGASMOIUND',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2391ProGasMOICos',fld:'PROGASMOICOS',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2392ProGasGIFUND',fld:'PROGASGIFUND',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2393ProGASGIFCos',fld:'PROGASGIFCOS',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2395ProGasLoteOpt',fld:'PROGASLOTEOPT',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2399ProGasCostoUND',fld:'PROGASCOSTOUND',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A2397ProGasSubProducto',fld:'PROGASSUBPRODUCTO',pic:'9'},{av:'A2394ProGasPorcentaje',fld:'PROGASPORCENTAJE',pic:'ZZZZZZZZZZZ9.99'},{av:'A2398ProGasProdDsc',fld:'PROGASPRODDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2382ProGasProdCod'},{av:'Z2388ProGasMODUND'},{av:'Z2389ProGasMODCos'},{av:'Z2390ProGasMOIUND'},{av:'Z2391ProGasMOICos'},{av:'Z2392ProGasGIFUND'},{av:'Z2393ProGASGIFCos'},{av:'Z2395ProGasLoteOpt'},{av:'Z2399ProGasCostoUND'},{av:'Z2397ProGasSubProducto'},{av:'Z2394ProGasPorcentaje'},{av:'Z2398ProGasProdDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2382ProGasProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2382ProGasProdCod = "";
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
         A2398ProGasProdDsc = "";
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
         Z2398ProGasProdDsc = "";
         T007L5_A2398ProGasProdDsc = new string[] {""} ;
         T007L5_A2388ProGasMODUND = new decimal[1] ;
         T007L5_A2389ProGasMODCos = new decimal[1] ;
         T007L5_A2390ProGasMOIUND = new decimal[1] ;
         T007L5_A2391ProGasMOICos = new decimal[1] ;
         T007L5_A2392ProGasGIFUND = new decimal[1] ;
         T007L5_A2393ProGASGIFCos = new decimal[1] ;
         T007L5_A2395ProGasLoteOpt = new decimal[1] ;
         T007L5_A2399ProGasCostoUND = new decimal[1] ;
         T007L5_A2397ProGasSubProducto = new short[1] ;
         T007L5_A2394ProGasPorcentaje = new decimal[1] ;
         T007L5_A2382ProGasProdCod = new string[] {""} ;
         T007L4_A2398ProGasProdDsc = new string[] {""} ;
         T007L6_A2398ProGasProdDsc = new string[] {""} ;
         T007L7_A2382ProGasProdCod = new string[] {""} ;
         T007L3_A2388ProGasMODUND = new decimal[1] ;
         T007L3_A2389ProGasMODCos = new decimal[1] ;
         T007L3_A2390ProGasMOIUND = new decimal[1] ;
         T007L3_A2391ProGasMOICos = new decimal[1] ;
         T007L3_A2392ProGasGIFUND = new decimal[1] ;
         T007L3_A2393ProGASGIFCos = new decimal[1] ;
         T007L3_A2395ProGasLoteOpt = new decimal[1] ;
         T007L3_A2399ProGasCostoUND = new decimal[1] ;
         T007L3_A2397ProGasSubProducto = new short[1] ;
         T007L3_A2394ProGasPorcentaje = new decimal[1] ;
         T007L3_A2382ProGasProdCod = new string[] {""} ;
         sMode209 = "";
         T007L8_A2382ProGasProdCod = new string[] {""} ;
         T007L9_A2382ProGasProdCod = new string[] {""} ;
         T007L2_A2388ProGasMODUND = new decimal[1] ;
         T007L2_A2389ProGasMODCos = new decimal[1] ;
         T007L2_A2390ProGasMOIUND = new decimal[1] ;
         T007L2_A2391ProGasMOICos = new decimal[1] ;
         T007L2_A2392ProGasGIFUND = new decimal[1] ;
         T007L2_A2393ProGASGIFCos = new decimal[1] ;
         T007L2_A2395ProGasLoteOpt = new decimal[1] ;
         T007L2_A2399ProGasCostoUND = new decimal[1] ;
         T007L2_A2397ProGasSubProducto = new short[1] ;
         T007L2_A2394ProGasPorcentaje = new decimal[1] ;
         T007L2_A2382ProGasProdCod = new string[] {""} ;
         T007L13_A2398ProGasProdDsc = new string[] {""} ;
         T007L14_A2382ProGasProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2382ProGasProdCod = "";
         ZZ2398ProGasProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.procostogastos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.procostogastos__default(),
            new Object[][] {
                new Object[] {
               T007L2_A2388ProGasMODUND, T007L2_A2389ProGasMODCos, T007L2_A2390ProGasMOIUND, T007L2_A2391ProGasMOICos, T007L2_A2392ProGasGIFUND, T007L2_A2393ProGASGIFCos, T007L2_A2395ProGasLoteOpt, T007L2_A2399ProGasCostoUND, T007L2_A2397ProGasSubProducto, T007L2_A2394ProGasPorcentaje,
               T007L2_A2382ProGasProdCod
               }
               , new Object[] {
               T007L3_A2388ProGasMODUND, T007L3_A2389ProGasMODCos, T007L3_A2390ProGasMOIUND, T007L3_A2391ProGasMOICos, T007L3_A2392ProGasGIFUND, T007L3_A2393ProGASGIFCos, T007L3_A2395ProGasLoteOpt, T007L3_A2399ProGasCostoUND, T007L3_A2397ProGasSubProducto, T007L3_A2394ProGasPorcentaje,
               T007L3_A2382ProGasProdCod
               }
               , new Object[] {
               T007L4_A2398ProGasProdDsc
               }
               , new Object[] {
               T007L5_A2398ProGasProdDsc, T007L5_A2388ProGasMODUND, T007L5_A2389ProGasMODCos, T007L5_A2390ProGasMOIUND, T007L5_A2391ProGasMOICos, T007L5_A2392ProGasGIFUND, T007L5_A2393ProGASGIFCos, T007L5_A2395ProGasLoteOpt, T007L5_A2399ProGasCostoUND, T007L5_A2397ProGasSubProducto,
               T007L5_A2394ProGasPorcentaje, T007L5_A2382ProGasProdCod
               }
               , new Object[] {
               T007L6_A2398ProGasProdDsc
               }
               , new Object[] {
               T007L7_A2382ProGasProdCod
               }
               , new Object[] {
               T007L8_A2382ProGasProdCod
               }
               , new Object[] {
               T007L9_A2382ProGasProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007L13_A2398ProGasProdDsc
               }
               , new Object[] {
               T007L14_A2382ProGasProdCod
               }
            }
         );
      }

      private short Z2397ProGasSubProducto ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2397ProGasSubProducto ;
      private short GX_JID ;
      private short RcdFound209 ;
      private short nIsDirty_209 ;
      private short Gx_BScreen ;
      private short ZZ2397ProGasSubProducto ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProGasProdCod_Enabled ;
      private int edtProGasProdDsc_Enabled ;
      private int edtProGasMODUND_Enabled ;
      private int edtProGasMODCos_Enabled ;
      private int edtProGasMOIUND_Enabled ;
      private int edtProGasMOICos_Enabled ;
      private int edtProGasGIFUND_Enabled ;
      private int edtProGASGIFCos_Enabled ;
      private int edtProGasLoteOpt_Enabled ;
      private int edtProGasCostoUND_Enabled ;
      private int edtProGasSubProducto_Enabled ;
      private int edtProGasPorcentaje_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z2388ProGasMODUND ;
      private decimal Z2389ProGasMODCos ;
      private decimal Z2390ProGasMOIUND ;
      private decimal Z2391ProGasMOICos ;
      private decimal Z2392ProGasGIFUND ;
      private decimal Z2393ProGASGIFCos ;
      private decimal Z2395ProGasLoteOpt ;
      private decimal Z2399ProGasCostoUND ;
      private decimal Z2394ProGasPorcentaje ;
      private decimal A2388ProGasMODUND ;
      private decimal A2389ProGasMODCos ;
      private decimal A2390ProGasMOIUND ;
      private decimal A2391ProGasMOICos ;
      private decimal A2392ProGasGIFUND ;
      private decimal A2393ProGASGIFCos ;
      private decimal A2395ProGasLoteOpt ;
      private decimal A2399ProGasCostoUND ;
      private decimal A2394ProGasPorcentaje ;
      private decimal ZZ2388ProGasMODUND ;
      private decimal ZZ2389ProGasMODCos ;
      private decimal ZZ2390ProGasMOIUND ;
      private decimal ZZ2391ProGasMOICos ;
      private decimal ZZ2392ProGasGIFUND ;
      private decimal ZZ2393ProGASGIFCos ;
      private decimal ZZ2395ProGasLoteOpt ;
      private decimal ZZ2399ProGasCostoUND ;
      private decimal ZZ2394ProGasPorcentaje ;
      private string sPrefix ;
      private string Z2382ProGasProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2382ProGasProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProGasProdCod_Internalname ;
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
      private string edtProGasProdCod_Jsonclick ;
      private string edtProGasProdDsc_Internalname ;
      private string A2398ProGasProdDsc ;
      private string edtProGasProdDsc_Jsonclick ;
      private string edtProGasMODUND_Internalname ;
      private string edtProGasMODUND_Jsonclick ;
      private string edtProGasMODCos_Internalname ;
      private string edtProGasMODCos_Jsonclick ;
      private string edtProGasMOIUND_Internalname ;
      private string edtProGasMOIUND_Jsonclick ;
      private string edtProGasMOICos_Internalname ;
      private string edtProGasMOICos_Jsonclick ;
      private string edtProGasGIFUND_Internalname ;
      private string edtProGasGIFUND_Jsonclick ;
      private string edtProGASGIFCos_Internalname ;
      private string edtProGASGIFCos_Jsonclick ;
      private string edtProGasLoteOpt_Internalname ;
      private string edtProGasLoteOpt_Jsonclick ;
      private string edtProGasCostoUND_Internalname ;
      private string edtProGasCostoUND_Jsonclick ;
      private string edtProGasSubProducto_Internalname ;
      private string edtProGasSubProducto_Jsonclick ;
      private string edtProGasPorcentaje_Internalname ;
      private string edtProGasPorcentaje_Jsonclick ;
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
      private string Z2398ProGasProdDsc ;
      private string sMode209 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2382ProGasProdCod ;
      private string ZZ2398ProGasProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007L5_A2398ProGasProdDsc ;
      private decimal[] T007L5_A2388ProGasMODUND ;
      private decimal[] T007L5_A2389ProGasMODCos ;
      private decimal[] T007L5_A2390ProGasMOIUND ;
      private decimal[] T007L5_A2391ProGasMOICos ;
      private decimal[] T007L5_A2392ProGasGIFUND ;
      private decimal[] T007L5_A2393ProGASGIFCos ;
      private decimal[] T007L5_A2395ProGasLoteOpt ;
      private decimal[] T007L5_A2399ProGasCostoUND ;
      private short[] T007L5_A2397ProGasSubProducto ;
      private decimal[] T007L5_A2394ProGasPorcentaje ;
      private string[] T007L5_A2382ProGasProdCod ;
      private string[] T007L4_A2398ProGasProdDsc ;
      private string[] T007L6_A2398ProGasProdDsc ;
      private string[] T007L7_A2382ProGasProdCod ;
      private decimal[] T007L3_A2388ProGasMODUND ;
      private decimal[] T007L3_A2389ProGasMODCos ;
      private decimal[] T007L3_A2390ProGasMOIUND ;
      private decimal[] T007L3_A2391ProGasMOICos ;
      private decimal[] T007L3_A2392ProGasGIFUND ;
      private decimal[] T007L3_A2393ProGASGIFCos ;
      private decimal[] T007L3_A2395ProGasLoteOpt ;
      private decimal[] T007L3_A2399ProGasCostoUND ;
      private short[] T007L3_A2397ProGasSubProducto ;
      private decimal[] T007L3_A2394ProGasPorcentaje ;
      private string[] T007L3_A2382ProGasProdCod ;
      private string[] T007L8_A2382ProGasProdCod ;
      private string[] T007L9_A2382ProGasProdCod ;
      private decimal[] T007L2_A2388ProGasMODUND ;
      private decimal[] T007L2_A2389ProGasMODCos ;
      private decimal[] T007L2_A2390ProGasMOIUND ;
      private decimal[] T007L2_A2391ProGasMOICos ;
      private decimal[] T007L2_A2392ProGasGIFUND ;
      private decimal[] T007L2_A2393ProGASGIFCos ;
      private decimal[] T007L2_A2395ProGasLoteOpt ;
      private decimal[] T007L2_A2399ProGasCostoUND ;
      private short[] T007L2_A2397ProGasSubProducto ;
      private decimal[] T007L2_A2394ProGasPorcentaje ;
      private string[] T007L2_A2382ProGasProdCod ;
      private string[] T007L13_A2398ProGasProdDsc ;
      private string[] T007L14_A2382ProGasProdCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class procostogastos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class procostogastos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT007L5;
        prmT007L5 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L4;
        prmT007L4 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L6;
        prmT007L6 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L7;
        prmT007L7 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L3;
        prmT007L3 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L8;
        prmT007L8 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L9;
        prmT007L9 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L2;
        prmT007L2 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L10;
        prmT007L10 = new Object[] {
        new ParDef("@ProGasMODUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGasMODCos",GXType.Decimal,18,6) ,
        new ParDef("@ProGasMOIUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGasMOICos",GXType.Decimal,18,6) ,
        new ParDef("@ProGasGIFUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGASGIFCos",GXType.Decimal,18,6) ,
        new ParDef("@ProGasLoteOpt",GXType.Decimal,18,6) ,
        new ParDef("@ProGasCostoUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGasSubProducto",GXType.Int16,1,0) ,
        new ParDef("@ProGasPorcentaje",GXType.Decimal,15,2) ,
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L11;
        prmT007L11 = new Object[] {
        new ParDef("@ProGasMODUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGasMODCos",GXType.Decimal,18,6) ,
        new ParDef("@ProGasMOIUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGasMOICos",GXType.Decimal,18,6) ,
        new ParDef("@ProGasGIFUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGASGIFCos",GXType.Decimal,18,6) ,
        new ParDef("@ProGasLoteOpt",GXType.Decimal,18,6) ,
        new ParDef("@ProGasCostoUND",GXType.Decimal,18,6) ,
        new ParDef("@ProGasSubProducto",GXType.Int16,1,0) ,
        new ParDef("@ProGasPorcentaje",GXType.Decimal,15,2) ,
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L12;
        prmT007L12 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        Object[] prmT007L14;
        prmT007L14 = new Object[] {
        };
        Object[] prmT007L13;
        prmT007L13 = new Object[] {
        new ParDef("@ProGasProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007L2", "SELECT [ProGasMODUND], [ProGasMODCos], [ProGasMOIUND], [ProGasMOICos], [ProGasGIFUND], [ProGASGIFCos], [ProGasLoteOpt], [ProGasCostoUND], [ProGasSubProducto], [ProGasPorcentaje], [ProGasProdCod] AS ProGasProdCod FROM [PROCOSTOGASTOS] WITH (UPDLOCK) WHERE [ProGasProdCod] = @ProGasProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007L3", "SELECT [ProGasMODUND], [ProGasMODCos], [ProGasMOIUND], [ProGasMOICos], [ProGasGIFUND], [ProGASGIFCos], [ProGasLoteOpt], [ProGasCostoUND], [ProGasSubProducto], [ProGasPorcentaje], [ProGasProdCod] AS ProGasProdCod FROM [PROCOSTOGASTOS] WHERE [ProGasProdCod] = @ProGasProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007L4", "SELECT [ProdDsc] AS ProGasProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProGasProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007L4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007L5", "SELECT T2.[ProdDsc] AS ProGasProdDsc, TM1.[ProGasMODUND], TM1.[ProGasMODCos], TM1.[ProGasMOIUND], TM1.[ProGasMOICos], TM1.[ProGasGIFUND], TM1.[ProGASGIFCos], TM1.[ProGasLoteOpt], TM1.[ProGasCostoUND], TM1.[ProGasSubProducto], TM1.[ProGasPorcentaje], TM1.[ProGasProdCod] AS ProGasProdCod FROM ([PROCOSTOGASTOS] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[ProGasProdCod]) WHERE TM1.[ProGasProdCod] = @ProGasProdCod ORDER BY TM1.[ProGasProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007L5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007L6", "SELECT [ProdDsc] AS ProGasProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProGasProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007L7", "SELECT [ProGasProdCod] AS ProGasProdCod FROM [PROCOSTOGASTOS] WHERE [ProGasProdCod] = @ProGasProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007L7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007L8", "SELECT TOP 1 [ProGasProdCod] AS ProGasProdCod FROM [PROCOSTOGASTOS] WHERE ( [ProGasProdCod] > @ProGasProdCod) ORDER BY [ProGasProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007L8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007L9", "SELECT TOP 1 [ProGasProdCod] AS ProGasProdCod FROM [PROCOSTOGASTOS] WHERE ( [ProGasProdCod] < @ProGasProdCod) ORDER BY [ProGasProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007L9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007L10", "INSERT INTO [PROCOSTOGASTOS]([ProGasMODUND], [ProGasMODCos], [ProGasMOIUND], [ProGasMOICos], [ProGasGIFUND], [ProGASGIFCos], [ProGasLoteOpt], [ProGasCostoUND], [ProGasSubProducto], [ProGasPorcentaje], [ProGasProdCod]) VALUES(@ProGasMODUND, @ProGasMODCos, @ProGasMOIUND, @ProGasMOICos, @ProGasGIFUND, @ProGASGIFCos, @ProGasLoteOpt, @ProGasCostoUND, @ProGasSubProducto, @ProGasPorcentaje, @ProGasProdCod)", GxErrorMask.GX_NOMASK,prmT007L10)
           ,new CursorDef("T007L11", "UPDATE [PROCOSTOGASTOS] SET [ProGasMODUND]=@ProGasMODUND, [ProGasMODCos]=@ProGasMODCos, [ProGasMOIUND]=@ProGasMOIUND, [ProGasMOICos]=@ProGasMOICos, [ProGasGIFUND]=@ProGasGIFUND, [ProGASGIFCos]=@ProGASGIFCos, [ProGasLoteOpt]=@ProGasLoteOpt, [ProGasCostoUND]=@ProGasCostoUND, [ProGasSubProducto]=@ProGasSubProducto, [ProGasPorcentaje]=@ProGasPorcentaje  WHERE [ProGasProdCod] = @ProGasProdCod", GxErrorMask.GX_NOMASK,prmT007L11)
           ,new CursorDef("T007L12", "DELETE FROM [PROCOSTOGASTOS]  WHERE [ProGasProdCod] = @ProGasProdCod", GxErrorMask.GX_NOMASK,prmT007L12)
           ,new CursorDef("T007L13", "SELECT [ProdDsc] AS ProGasProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProGasProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007L13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007L14", "SELECT [ProGasProdCod] AS ProGasProdCod FROM [PROCOSTOGASTOS] ORDER BY [ProGasProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007L14,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
