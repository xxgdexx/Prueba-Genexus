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
   public class cbonificacion : GXDataArea
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
            A81CBonProdCod = GetPar( "CBonProdCod");
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A81CBonProdCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A82CBonDProdCod = GetPar( "CBonDProdCod");
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A82CBonDProdCod) ;
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
            Form.Meta.addItem("description", "CBONIFICACION", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbonificacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbonificacion( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CBONIFICACION", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBONIFICACION.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBONIFICACION.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonProdCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonProdCod_Internalname, StringUtil.RTrim( A81CBonProdCod), StringUtil.RTrim( context.localUtil.Format( A81CBonProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonProdDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonProdDsc_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCBonProdDsc_Internalname, StringUtil.RTrim( A503CBonProdDsc), StringUtil.RTrim( context.localUtil.Format( A503CBonProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonDProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonDProdCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonDProdCod_Internalname, StringUtil.RTrim( A82CBonDProdCod), StringUtil.RTrim( context.localUtil.Format( A82CBonDProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonDProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonDProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonDProdDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonDProdDsc_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCBonDProdDsc_Internalname, StringUtil.RTrim( A502CBonDProdDsc), StringUtil.RTrim( context.localUtil.Format( A502CBonDProdDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonDProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonDProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonCan1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonCan1_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonCan1_Internalname, StringUtil.LTrim( StringUtil.NToC( A497CBonCan1, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonCan1_Enabled!=0) ? context.localUtil.Format( A497CBonCan1, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A497CBonCan1, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonCan1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonCan1_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonBon1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonBon1_Internalname, "Bonifica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonBon1_Internalname, StringUtil.LTrim( StringUtil.NToC( A492CBonBon1, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonBon1_Enabled!=0) ? context.localUtil.Format( A492CBonBon1, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A492CBonBon1, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonBon1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonBon1_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonCan2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonCan2_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonCan2_Internalname, StringUtil.LTrim( StringUtil.NToC( A498CBonCan2, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonCan2_Enabled!=0) ? context.localUtil.Format( A498CBonCan2, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A498CBonCan2, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonCan2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonCan2_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonBon2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonBon2_Internalname, "Bonifica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonBon2_Internalname, StringUtil.LTrim( StringUtil.NToC( A493CBonBon2, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonBon2_Enabled!=0) ? context.localUtil.Format( A493CBonBon2, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A493CBonBon2, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonBon2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonBon2_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonCan3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonCan3_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonCan3_Internalname, StringUtil.LTrim( StringUtil.NToC( A499CBonCan3, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonCan3_Enabled!=0) ? context.localUtil.Format( A499CBonCan3, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A499CBonCan3, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonCan3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonCan3_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonBon3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonBon3_Internalname, "Bonifica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonBon3_Internalname, StringUtil.LTrim( StringUtil.NToC( A494CBonBon3, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonBon3_Enabled!=0) ? context.localUtil.Format( A494CBonBon3, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A494CBonBon3, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonBon3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonBon3_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonCan4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonCan4_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonCan4_Internalname, StringUtil.LTrim( StringUtil.NToC( A500CBonCan4, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonCan4_Enabled!=0) ? context.localUtil.Format( A500CBonCan4, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A500CBonCan4, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonCan4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonCan4_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonBon4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonBon4_Internalname, "Bonifica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonBon4_Internalname, StringUtil.LTrim( StringUtil.NToC( A495CBonBon4, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonBon4_Enabled!=0) ? context.localUtil.Format( A495CBonBon4, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A495CBonBon4, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonBon4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonBon4_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonCan5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonCan5_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonCan5_Internalname, StringUtil.LTrim( StringUtil.NToC( A501CBonCan5, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonCan5_Enabled!=0) ? context.localUtil.Format( A501CBonCan5, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A501CBonCan5, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonCan5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonCan5_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBonBon5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBonBon5_Internalname, "Bonifica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBonBon5_Internalname, StringUtil.LTrim( StringUtil.NToC( A496CBonBon5, 17, 2, ".", "")), StringUtil.LTrim( ((edtCBonBon5_Enabled!=0) ? context.localUtil.Format( A496CBonBon5, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A496CBonBon5, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBonBon5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBonBon5_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBONIFICACION.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBONIFICACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBONIFICACION.htm");
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
            Z81CBonProdCod = cgiGet( "Z81CBonProdCod");
            Z497CBonCan1 = context.localUtil.CToN( cgiGet( "Z497CBonCan1"), ".", ",");
            Z492CBonBon1 = context.localUtil.CToN( cgiGet( "Z492CBonBon1"), ".", ",");
            Z498CBonCan2 = context.localUtil.CToN( cgiGet( "Z498CBonCan2"), ".", ",");
            Z493CBonBon2 = context.localUtil.CToN( cgiGet( "Z493CBonBon2"), ".", ",");
            Z499CBonCan3 = context.localUtil.CToN( cgiGet( "Z499CBonCan3"), ".", ",");
            Z494CBonBon3 = context.localUtil.CToN( cgiGet( "Z494CBonBon3"), ".", ",");
            Z500CBonCan4 = context.localUtil.CToN( cgiGet( "Z500CBonCan4"), ".", ",");
            Z495CBonBon4 = context.localUtil.CToN( cgiGet( "Z495CBonBon4"), ".", ",");
            Z501CBonCan5 = context.localUtil.CToN( cgiGet( "Z501CBonCan5"), ".", ",");
            Z496CBonBon5 = context.localUtil.CToN( cgiGet( "Z496CBonBon5"), ".", ",");
            Z82CBonDProdCod = cgiGet( "Z82CBonDProdCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A81CBonProdCod = StringUtil.Upper( cgiGet( edtCBonProdCod_Internalname));
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
            A503CBonProdDsc = cgiGet( edtCBonProdDsc_Internalname);
            AssignAttri("", false, "A503CBonProdDsc", A503CBonProdDsc);
            A82CBonDProdCod = StringUtil.Upper( cgiGet( edtCBonDProdCod_Internalname));
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
            A502CBonDProdDsc = cgiGet( edtCBonDProdDsc_Internalname);
            AssignAttri("", false, "A502CBonDProdDsc", A502CBonDProdDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonCan1_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonCan1_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONCAN1");
               AnyError = 1;
               GX_FocusControl = edtCBonCan1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A497CBonCan1 = 0;
               AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
            }
            else
            {
               A497CBonCan1 = context.localUtil.CToN( cgiGet( edtCBonCan1_Internalname), ".", ",");
               AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonBon1_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonBon1_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONBON1");
               AnyError = 1;
               GX_FocusControl = edtCBonBon1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A492CBonBon1 = 0;
               AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
            }
            else
            {
               A492CBonBon1 = context.localUtil.CToN( cgiGet( edtCBonBon1_Internalname), ".", ",");
               AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonCan2_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonCan2_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONCAN2");
               AnyError = 1;
               GX_FocusControl = edtCBonCan2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A498CBonCan2 = 0;
               AssignAttri("", false, "A498CBonCan2", StringUtil.LTrimStr( A498CBonCan2, 15, 2));
            }
            else
            {
               A498CBonCan2 = context.localUtil.CToN( cgiGet( edtCBonCan2_Internalname), ".", ",");
               AssignAttri("", false, "A498CBonCan2", StringUtil.LTrimStr( A498CBonCan2, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonBon2_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonBon2_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONBON2");
               AnyError = 1;
               GX_FocusControl = edtCBonBon2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A493CBonBon2 = 0;
               AssignAttri("", false, "A493CBonBon2", StringUtil.LTrimStr( A493CBonBon2, 15, 2));
            }
            else
            {
               A493CBonBon2 = context.localUtil.CToN( cgiGet( edtCBonBon2_Internalname), ".", ",");
               AssignAttri("", false, "A493CBonBon2", StringUtil.LTrimStr( A493CBonBon2, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonCan3_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonCan3_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONCAN3");
               AnyError = 1;
               GX_FocusControl = edtCBonCan3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A499CBonCan3 = 0;
               AssignAttri("", false, "A499CBonCan3", StringUtil.LTrimStr( A499CBonCan3, 15, 2));
            }
            else
            {
               A499CBonCan3 = context.localUtil.CToN( cgiGet( edtCBonCan3_Internalname), ".", ",");
               AssignAttri("", false, "A499CBonCan3", StringUtil.LTrimStr( A499CBonCan3, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonBon3_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonBon3_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONBON3");
               AnyError = 1;
               GX_FocusControl = edtCBonBon3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A494CBonBon3 = 0;
               AssignAttri("", false, "A494CBonBon3", StringUtil.LTrimStr( A494CBonBon3, 15, 2));
            }
            else
            {
               A494CBonBon3 = context.localUtil.CToN( cgiGet( edtCBonBon3_Internalname), ".", ",");
               AssignAttri("", false, "A494CBonBon3", StringUtil.LTrimStr( A494CBonBon3, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonCan4_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonCan4_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONCAN4");
               AnyError = 1;
               GX_FocusControl = edtCBonCan4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A500CBonCan4 = 0;
               AssignAttri("", false, "A500CBonCan4", StringUtil.LTrimStr( A500CBonCan4, 15, 2));
            }
            else
            {
               A500CBonCan4 = context.localUtil.CToN( cgiGet( edtCBonCan4_Internalname), ".", ",");
               AssignAttri("", false, "A500CBonCan4", StringUtil.LTrimStr( A500CBonCan4, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonBon4_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonBon4_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONBON4");
               AnyError = 1;
               GX_FocusControl = edtCBonBon4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A495CBonBon4 = 0;
               AssignAttri("", false, "A495CBonBon4", StringUtil.LTrimStr( A495CBonBon4, 15, 2));
            }
            else
            {
               A495CBonBon4 = context.localUtil.CToN( cgiGet( edtCBonBon4_Internalname), ".", ",");
               AssignAttri("", false, "A495CBonBon4", StringUtil.LTrimStr( A495CBonBon4, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonCan5_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonCan5_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONCAN5");
               AnyError = 1;
               GX_FocusControl = edtCBonCan5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A501CBonCan5 = 0;
               AssignAttri("", false, "A501CBonCan5", StringUtil.LTrimStr( A501CBonCan5, 15, 2));
            }
            else
            {
               A501CBonCan5 = context.localUtil.CToN( cgiGet( edtCBonCan5_Internalname), ".", ",");
               AssignAttri("", false, "A501CBonCan5", StringUtil.LTrimStr( A501CBonCan5, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBonBon5_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCBonBon5_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBONBON5");
               AnyError = 1;
               GX_FocusControl = edtCBonBon5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A496CBonBon5 = 0;
               AssignAttri("", false, "A496CBonBon5", StringUtil.LTrimStr( A496CBonBon5, 15, 2));
            }
            else
            {
               A496CBonBon5 = context.localUtil.CToN( cgiGet( edtCBonBon5_Internalname), ".", ",");
               AssignAttri("", false, "A496CBonBon5", StringUtil.LTrimStr( A496CBonBon5, 15, 2));
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
               A81CBonProdCod = GetPar( "CBonProdCod");
               AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
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
               InitAll044( ) ;
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
         DisableAttributes044( ) ;
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

      protected void ResetCaption040( )
      {
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z497CBonCan1 = T00043_A497CBonCan1[0];
               Z492CBonBon1 = T00043_A492CBonBon1[0];
               Z498CBonCan2 = T00043_A498CBonCan2[0];
               Z493CBonBon2 = T00043_A493CBonBon2[0];
               Z499CBonCan3 = T00043_A499CBonCan3[0];
               Z494CBonBon3 = T00043_A494CBonBon3[0];
               Z500CBonCan4 = T00043_A500CBonCan4[0];
               Z495CBonBon4 = T00043_A495CBonBon4[0];
               Z501CBonCan5 = T00043_A501CBonCan5[0];
               Z496CBonBon5 = T00043_A496CBonBon5[0];
               Z82CBonDProdCod = T00043_A82CBonDProdCod[0];
            }
            else
            {
               Z497CBonCan1 = A497CBonCan1;
               Z492CBonBon1 = A492CBonBon1;
               Z498CBonCan2 = A498CBonCan2;
               Z493CBonBon2 = A493CBonBon2;
               Z499CBonCan3 = A499CBonCan3;
               Z494CBonBon3 = A494CBonBon3;
               Z500CBonCan4 = A500CBonCan4;
               Z495CBonBon4 = A495CBonBon4;
               Z501CBonCan5 = A501CBonCan5;
               Z496CBonBon5 = A496CBonBon5;
               Z82CBonDProdCod = A82CBonDProdCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z497CBonCan1 = A497CBonCan1;
            Z492CBonBon1 = A492CBonBon1;
            Z498CBonCan2 = A498CBonCan2;
            Z493CBonBon2 = A493CBonBon2;
            Z499CBonCan3 = A499CBonCan3;
            Z494CBonBon3 = A494CBonBon3;
            Z500CBonCan4 = A500CBonCan4;
            Z495CBonBon4 = A495CBonBon4;
            Z501CBonCan5 = A501CBonCan5;
            Z496CBonBon5 = A496CBonBon5;
            Z81CBonProdCod = A81CBonProdCod;
            Z82CBonDProdCod = A82CBonDProdCod;
            Z503CBonProdDsc = A503CBonProdDsc;
            Z502CBonDProdDsc = A502CBonDProdDsc;
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

      protected void Load044( )
      {
         /* Using cursor T00046 */
         pr_default.execute(4, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound4 = 1;
            A503CBonProdDsc = T00046_A503CBonProdDsc[0];
            AssignAttri("", false, "A503CBonProdDsc", A503CBonProdDsc);
            A502CBonDProdDsc = T00046_A502CBonDProdDsc[0];
            AssignAttri("", false, "A502CBonDProdDsc", A502CBonDProdDsc);
            A497CBonCan1 = T00046_A497CBonCan1[0];
            AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
            A492CBonBon1 = T00046_A492CBonBon1[0];
            AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
            A498CBonCan2 = T00046_A498CBonCan2[0];
            AssignAttri("", false, "A498CBonCan2", StringUtil.LTrimStr( A498CBonCan2, 15, 2));
            A493CBonBon2 = T00046_A493CBonBon2[0];
            AssignAttri("", false, "A493CBonBon2", StringUtil.LTrimStr( A493CBonBon2, 15, 2));
            A499CBonCan3 = T00046_A499CBonCan3[0];
            AssignAttri("", false, "A499CBonCan3", StringUtil.LTrimStr( A499CBonCan3, 15, 2));
            A494CBonBon3 = T00046_A494CBonBon3[0];
            AssignAttri("", false, "A494CBonBon3", StringUtil.LTrimStr( A494CBonBon3, 15, 2));
            A500CBonCan4 = T00046_A500CBonCan4[0];
            AssignAttri("", false, "A500CBonCan4", StringUtil.LTrimStr( A500CBonCan4, 15, 2));
            A495CBonBon4 = T00046_A495CBonBon4[0];
            AssignAttri("", false, "A495CBonBon4", StringUtil.LTrimStr( A495CBonBon4, 15, 2));
            A501CBonCan5 = T00046_A501CBonCan5[0];
            AssignAttri("", false, "A501CBonCan5", StringUtil.LTrimStr( A501CBonCan5, 15, 2));
            A496CBonBon5 = T00046_A496CBonBon5[0];
            AssignAttri("", false, "A496CBonBon5", StringUtil.LTrimStr( A496CBonBon5, 15, 2));
            A82CBonDProdCod = T00046_A82CBonDProdCod[0];
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
            ZM044( -1) ;
         }
         pr_default.close(4);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00044 */
         pr_default.execute(2, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A503CBonProdDsc = T00044_A503CBonProdDsc[0];
         AssignAttri("", false, "A503CBonProdDsc", A503CBonProdDsc);
         pr_default.close(2);
         /* Using cursor T00045 */
         pr_default.execute(3, new Object[] {A82CBonDProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A502CBonDProdDsc = T00045_A502CBonDProdDsc[0];
         AssignAttri("", false, "A502CBonDProdDsc", A502CBonDProdDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A81CBonProdCod )
      {
         /* Using cursor T00047 */
         pr_default.execute(5, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A503CBonProdDsc = T00047_A503CBonProdDsc[0];
         AssignAttri("", false, "A503CBonProdDsc", A503CBonProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A503CBonProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A82CBonDProdCod )
      {
         /* Using cursor T00048 */
         pr_default.execute(6, new Object[] {A82CBonDProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A502CBonDProdDsc = T00048_A502CBonDProdDsc[0];
         AssignAttri("", false, "A502CBonDProdDsc", A502CBonDProdDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A502CBonDProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey044( )
      {
         /* Using cursor T00049 */
         pr_default.execute(7, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00043 */
         pr_default.execute(1, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 1) ;
            RcdFound4 = 1;
            A497CBonCan1 = T00043_A497CBonCan1[0];
            AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
            A492CBonBon1 = T00043_A492CBonBon1[0];
            AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
            A498CBonCan2 = T00043_A498CBonCan2[0];
            AssignAttri("", false, "A498CBonCan2", StringUtil.LTrimStr( A498CBonCan2, 15, 2));
            A493CBonBon2 = T00043_A493CBonBon2[0];
            AssignAttri("", false, "A493CBonBon2", StringUtil.LTrimStr( A493CBonBon2, 15, 2));
            A499CBonCan3 = T00043_A499CBonCan3[0];
            AssignAttri("", false, "A499CBonCan3", StringUtil.LTrimStr( A499CBonCan3, 15, 2));
            A494CBonBon3 = T00043_A494CBonBon3[0];
            AssignAttri("", false, "A494CBonBon3", StringUtil.LTrimStr( A494CBonBon3, 15, 2));
            A500CBonCan4 = T00043_A500CBonCan4[0];
            AssignAttri("", false, "A500CBonCan4", StringUtil.LTrimStr( A500CBonCan4, 15, 2));
            A495CBonBon4 = T00043_A495CBonBon4[0];
            AssignAttri("", false, "A495CBonBon4", StringUtil.LTrimStr( A495CBonBon4, 15, 2));
            A501CBonCan5 = T00043_A501CBonCan5[0];
            AssignAttri("", false, "A501CBonCan5", StringUtil.LTrimStr( A501CBonCan5, 15, 2));
            A496CBonBon5 = T00043_A496CBonBon5[0];
            AssignAttri("", false, "A496CBonBon5", StringUtil.LTrimStr( A496CBonBon5, 15, 2));
            A81CBonProdCod = T00043_A81CBonProdCod[0];
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
            A82CBonDProdCod = T00043_A82CBonDProdCod[0];
            AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
            Z81CBonProdCod = A81CBonProdCod;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode4;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         RcdFound4 = 0;
         /* Using cursor T000410 */
         pr_default.execute(8, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000410_A81CBonProdCod[0], A81CBonProdCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000410_A81CBonProdCod[0], A81CBonProdCod) > 0 ) ) )
            {
               A81CBonProdCod = T000410_A81CBonProdCod[0];
               AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
               RcdFound4 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound4 = 0;
         /* Using cursor T000411 */
         pr_default.execute(9, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000411_A81CBonProdCod[0], A81CBonProdCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000411_A81CBonProdCod[0], A81CBonProdCod) < 0 ) ) )
            {
               A81CBonProdCod = T000411_A81CBonProdCod[0];
               AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
               RcdFound4 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert044( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( StringUtil.StrCmp(A81CBonProdCod, Z81CBonProdCod) != 0 )
               {
                  A81CBonProdCod = Z81CBonProdCod;
                  AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CBONPRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update044( ) ;
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A81CBonProdCod, Z81CBonProdCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBonProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert044( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CBONPRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCBonProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCBonProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert044( ) ;
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
         if ( StringUtil.StrCmp(A81CBonProdCod, Z81CBonProdCod) != 0 )
         {
            A81CBonProdCod = Z81CBonProdCod;
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCBonProdCod_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBonDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBonDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBonDProdCod_Internalname;
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
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBonDProdCod_Internalname;
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
         ScanStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound4 != 0 )
            {
               ScanNext044( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBonDProdCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd044( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00042 */
            pr_default.execute(0, new Object[] {A81CBonProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBONIFICACION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z497CBonCan1 != T00042_A497CBonCan1[0] ) || ( Z492CBonBon1 != T00042_A492CBonBon1[0] ) || ( Z498CBonCan2 != T00042_A498CBonCan2[0] ) || ( Z493CBonBon2 != T00042_A493CBonBon2[0] ) || ( Z499CBonCan3 != T00042_A499CBonCan3[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z494CBonBon3 != T00042_A494CBonBon3[0] ) || ( Z500CBonCan4 != T00042_A500CBonCan4[0] ) || ( Z495CBonBon4 != T00042_A495CBonBon4[0] ) || ( Z501CBonCan5 != T00042_A501CBonCan5[0] ) || ( Z496CBonBon5 != T00042_A496CBonBon5[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z82CBonDProdCod, T00042_A82CBonDProdCod[0]) != 0 ) )
            {
               if ( Z497CBonCan1 != T00042_A497CBonCan1[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonCan1");
                  GXUtil.WriteLogRaw("Old: ",Z497CBonCan1);
                  GXUtil.WriteLogRaw("Current: ",T00042_A497CBonCan1[0]);
               }
               if ( Z492CBonBon1 != T00042_A492CBonBon1[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonBon1");
                  GXUtil.WriteLogRaw("Old: ",Z492CBonBon1);
                  GXUtil.WriteLogRaw("Current: ",T00042_A492CBonBon1[0]);
               }
               if ( Z498CBonCan2 != T00042_A498CBonCan2[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonCan2");
                  GXUtil.WriteLogRaw("Old: ",Z498CBonCan2);
                  GXUtil.WriteLogRaw("Current: ",T00042_A498CBonCan2[0]);
               }
               if ( Z493CBonBon2 != T00042_A493CBonBon2[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonBon2");
                  GXUtil.WriteLogRaw("Old: ",Z493CBonBon2);
                  GXUtil.WriteLogRaw("Current: ",T00042_A493CBonBon2[0]);
               }
               if ( Z499CBonCan3 != T00042_A499CBonCan3[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonCan3");
                  GXUtil.WriteLogRaw("Old: ",Z499CBonCan3);
                  GXUtil.WriteLogRaw("Current: ",T00042_A499CBonCan3[0]);
               }
               if ( Z494CBonBon3 != T00042_A494CBonBon3[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonBon3");
                  GXUtil.WriteLogRaw("Old: ",Z494CBonBon3);
                  GXUtil.WriteLogRaw("Current: ",T00042_A494CBonBon3[0]);
               }
               if ( Z500CBonCan4 != T00042_A500CBonCan4[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonCan4");
                  GXUtil.WriteLogRaw("Old: ",Z500CBonCan4);
                  GXUtil.WriteLogRaw("Current: ",T00042_A500CBonCan4[0]);
               }
               if ( Z495CBonBon4 != T00042_A495CBonBon4[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonBon4");
                  GXUtil.WriteLogRaw("Old: ",Z495CBonBon4);
                  GXUtil.WriteLogRaw("Current: ",T00042_A495CBonBon4[0]);
               }
               if ( Z501CBonCan5 != T00042_A501CBonCan5[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonCan5");
                  GXUtil.WriteLogRaw("Old: ",Z501CBonCan5);
                  GXUtil.WriteLogRaw("Current: ",T00042_A501CBonCan5[0]);
               }
               if ( Z496CBonBon5 != T00042_A496CBonBon5[0] )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonBon5");
                  GXUtil.WriteLogRaw("Old: ",Z496CBonBon5);
                  GXUtil.WriteLogRaw("Current: ",T00042_A496CBonBon5[0]);
               }
               if ( StringUtil.StrCmp(Z82CBonDProdCod, T00042_A82CBonDProdCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbonificacion:[seudo value changed for attri]"+"CBonDProdCod");
                  GXUtil.WriteLogRaw("Old: ",Z82CBonDProdCod);
                  GXUtil.WriteLogRaw("Current: ",T00042_A82CBonDProdCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBONIFICACION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000412 */
                     pr_default.execute(10, new Object[] {A497CBonCan1, A492CBonBon1, A498CBonCan2, A493CBonBon2, A499CBonCan3, A494CBonBon3, A500CBonCan4, A495CBonBon4, A501CBonCan5, A496CBonBon5, A81CBonProdCod, A82CBonDProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CBONIFICACION");
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
                           ResetCaption040( ) ;
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000413 */
                     pr_default.execute(11, new Object[] {A497CBonCan1, A492CBonBon1, A498CBonCan2, A493CBonBon2, A499CBonCan3, A494CBonBon3, A500CBonCan4, A495CBonBon4, A501CBonCan5, A496CBonBon5, A82CBonDProdCod, A81CBonProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBONIFICACION");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBONIFICACION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption040( ) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000414 */
                  pr_default.execute(12, new Object[] {A81CBonProdCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CBONIFICACION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound4 == 0 )
                        {
                           InitAll044( ) ;
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
                        ResetCaption040( ) ;
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel044( ) ;
         Gx_mode = sMode4;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000415 */
            pr_default.execute(13, new Object[] {A81CBonProdCod});
            A503CBonProdDsc = T000415_A503CBonProdDsc[0];
            AssignAttri("", false, "A503CBonProdDsc", A503CBonProdDsc);
            pr_default.close(13);
            /* Using cursor T000416 */
            pr_default.execute(14, new Object[] {A82CBonDProdCod});
            A502CBonDProdDsc = T000416_A502CBonDProdDsc[0];
            AssignAttri("", false, "A502CBonDProdDsc", A502CBonDProdDsc);
            pr_default.close(14);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            pr_default.close(14);
            context.CommitDataStores("cbonificacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues040( ) ;
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
            context.RollbackDataStores("cbonificacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart044( )
      {
         /* Using cursor T000417 */
         pr_default.execute(15);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
            A81CBonProdCod = T000417_A81CBonProdCod[0];
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound4 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound4 = 1;
            A81CBonProdCod = T000417_A81CBonProdCod[0];
            AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         }
      }

      protected void ScanEnd044( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
         edtCBonProdCod_Enabled = 0;
         AssignProp("", false, edtCBonProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonProdCod_Enabled), 5, 0), true);
         edtCBonProdDsc_Enabled = 0;
         AssignProp("", false, edtCBonProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonProdDsc_Enabled), 5, 0), true);
         edtCBonDProdCod_Enabled = 0;
         AssignProp("", false, edtCBonDProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonDProdCod_Enabled), 5, 0), true);
         edtCBonDProdDsc_Enabled = 0;
         AssignProp("", false, edtCBonDProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonDProdDsc_Enabled), 5, 0), true);
         edtCBonCan1_Enabled = 0;
         AssignProp("", false, edtCBonCan1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonCan1_Enabled), 5, 0), true);
         edtCBonBon1_Enabled = 0;
         AssignProp("", false, edtCBonBon1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonBon1_Enabled), 5, 0), true);
         edtCBonCan2_Enabled = 0;
         AssignProp("", false, edtCBonCan2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonCan2_Enabled), 5, 0), true);
         edtCBonBon2_Enabled = 0;
         AssignProp("", false, edtCBonBon2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonBon2_Enabled), 5, 0), true);
         edtCBonCan3_Enabled = 0;
         AssignProp("", false, edtCBonCan3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonCan3_Enabled), 5, 0), true);
         edtCBonBon3_Enabled = 0;
         AssignProp("", false, edtCBonBon3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonBon3_Enabled), 5, 0), true);
         edtCBonCan4_Enabled = 0;
         AssignProp("", false, edtCBonCan4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonCan4_Enabled), 5, 0), true);
         edtCBonBon4_Enabled = 0;
         AssignProp("", false, edtCBonBon4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonBon4_Enabled), 5, 0), true);
         edtCBonCan5_Enabled = 0;
         AssignProp("", false, edtCBonCan5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonCan5_Enabled), 5, 0), true);
         edtCBonBon5_Enabled = 0;
         AssignProp("", false, edtCBonBon5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBonBon5_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues040( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816421285", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbonificacion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z81CBonProdCod", StringUtil.RTrim( Z81CBonProdCod));
         GxWebStd.gx_hidden_field( context, "Z497CBonCan1", StringUtil.LTrim( StringUtil.NToC( Z497CBonCan1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z492CBonBon1", StringUtil.LTrim( StringUtil.NToC( Z492CBonBon1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z498CBonCan2", StringUtil.LTrim( StringUtil.NToC( Z498CBonCan2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z493CBonBon2", StringUtil.LTrim( StringUtil.NToC( Z493CBonBon2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z499CBonCan3", StringUtil.LTrim( StringUtil.NToC( Z499CBonCan3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z494CBonBon3", StringUtil.LTrim( StringUtil.NToC( Z494CBonBon3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z500CBonCan4", StringUtil.LTrim( StringUtil.NToC( Z500CBonCan4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z495CBonBon4", StringUtil.LTrim( StringUtil.NToC( Z495CBonBon4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z501CBonCan5", StringUtil.LTrim( StringUtil.NToC( Z501CBonCan5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z496CBonBon5", StringUtil.LTrim( StringUtil.NToC( Z496CBonBon5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z82CBonDProdCod", StringUtil.RTrim( Z82CBonDProdCod));
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
         return formatLink("cbonificacion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBONIFICACION" ;
      }

      public override string GetPgmdesc( )
      {
         return "CBONIFICACION" ;
      }

      protected void InitializeNonKey044( )
      {
         A503CBonProdDsc = "";
         AssignAttri("", false, "A503CBonProdDsc", A503CBonProdDsc);
         A82CBonDProdCod = "";
         AssignAttri("", false, "A82CBonDProdCod", A82CBonDProdCod);
         A502CBonDProdDsc = "";
         AssignAttri("", false, "A502CBonDProdDsc", A502CBonDProdDsc);
         A497CBonCan1 = 0;
         AssignAttri("", false, "A497CBonCan1", StringUtil.LTrimStr( A497CBonCan1, 15, 2));
         A492CBonBon1 = 0;
         AssignAttri("", false, "A492CBonBon1", StringUtil.LTrimStr( A492CBonBon1, 15, 2));
         A498CBonCan2 = 0;
         AssignAttri("", false, "A498CBonCan2", StringUtil.LTrimStr( A498CBonCan2, 15, 2));
         A493CBonBon2 = 0;
         AssignAttri("", false, "A493CBonBon2", StringUtil.LTrimStr( A493CBonBon2, 15, 2));
         A499CBonCan3 = 0;
         AssignAttri("", false, "A499CBonCan3", StringUtil.LTrimStr( A499CBonCan3, 15, 2));
         A494CBonBon3 = 0;
         AssignAttri("", false, "A494CBonBon3", StringUtil.LTrimStr( A494CBonBon3, 15, 2));
         A500CBonCan4 = 0;
         AssignAttri("", false, "A500CBonCan4", StringUtil.LTrimStr( A500CBonCan4, 15, 2));
         A495CBonBon4 = 0;
         AssignAttri("", false, "A495CBonBon4", StringUtil.LTrimStr( A495CBonBon4, 15, 2));
         A501CBonCan5 = 0;
         AssignAttri("", false, "A501CBonCan5", StringUtil.LTrimStr( A501CBonCan5, 15, 2));
         A496CBonBon5 = 0;
         AssignAttri("", false, "A496CBonBon5", StringUtil.LTrimStr( A496CBonBon5, 15, 2));
         Z497CBonCan1 = 0;
         Z492CBonBon1 = 0;
         Z498CBonCan2 = 0;
         Z493CBonBon2 = 0;
         Z499CBonCan3 = 0;
         Z494CBonBon3 = 0;
         Z500CBonCan4 = 0;
         Z495CBonBon4 = 0;
         Z501CBonCan5 = 0;
         Z496CBonBon5 = 0;
         Z82CBonDProdCod = "";
      }

      protected void InitAll044( )
      {
         A81CBonProdCod = "";
         AssignAttri("", false, "A81CBonProdCod", A81CBonProdCod);
         InitializeNonKey044( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816421299", true, true);
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
         context.AddJavascriptSource("cbonificacion.js", "?202281816421299", false, true);
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
         edtCBonProdCod_Internalname = "CBONPRODCOD";
         edtCBonProdDsc_Internalname = "CBONPRODDSC";
         edtCBonDProdCod_Internalname = "CBONDPRODCOD";
         edtCBonDProdDsc_Internalname = "CBONDPRODDSC";
         edtCBonCan1_Internalname = "CBONCAN1";
         edtCBonBon1_Internalname = "CBONBON1";
         edtCBonCan2_Internalname = "CBONCAN2";
         edtCBonBon2_Internalname = "CBONBON2";
         edtCBonCan3_Internalname = "CBONCAN3";
         edtCBonBon3_Internalname = "CBONBON3";
         edtCBonCan4_Internalname = "CBONCAN4";
         edtCBonBon4_Internalname = "CBONBON4";
         edtCBonCan5_Internalname = "CBONCAN5";
         edtCBonBon5_Internalname = "CBONBON5";
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
         Form.Caption = "CBONIFICACION";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCBonBon5_Jsonclick = "";
         edtCBonBon5_Enabled = 1;
         edtCBonCan5_Jsonclick = "";
         edtCBonCan5_Enabled = 1;
         edtCBonBon4_Jsonclick = "";
         edtCBonBon4_Enabled = 1;
         edtCBonCan4_Jsonclick = "";
         edtCBonCan4_Enabled = 1;
         edtCBonBon3_Jsonclick = "";
         edtCBonBon3_Enabled = 1;
         edtCBonCan3_Jsonclick = "";
         edtCBonCan3_Enabled = 1;
         edtCBonBon2_Jsonclick = "";
         edtCBonBon2_Enabled = 1;
         edtCBonCan2_Jsonclick = "";
         edtCBonCan2_Enabled = 1;
         edtCBonBon1_Jsonclick = "";
         edtCBonBon1_Enabled = 1;
         edtCBonCan1_Jsonclick = "";
         edtCBonCan1_Enabled = 1;
         edtCBonDProdDsc_Jsonclick = "";
         edtCBonDProdDsc_Enabled = 0;
         edtCBonDProdCod_Jsonclick = "";
         edtCBonDProdCod_Enabled = 1;
         edtCBonProdDsc_Jsonclick = "";
         edtCBonProdDsc_Enabled = 0;
         edtCBonProdCod_Jsonclick = "";
         edtCBonProdCod_Enabled = 1;
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
         GX_FocusControl = edtCBonDProdCod_Internalname;
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

      public void Valid_Cbonprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000415 */
         pr_default.execute(13, new Object[] {A81CBonProdCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonProdCod_Internalname;
         }
         A503CBonProdDsc = T000415_A503CBonProdDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A82CBonDProdCod", StringUtil.RTrim( A82CBonDProdCod));
         AssignAttri("", false, "A497CBonCan1", StringUtil.LTrim( StringUtil.NToC( A497CBonCan1, 15, 2, ".", "")));
         AssignAttri("", false, "A492CBonBon1", StringUtil.LTrim( StringUtil.NToC( A492CBonBon1, 15, 2, ".", "")));
         AssignAttri("", false, "A498CBonCan2", StringUtil.LTrim( StringUtil.NToC( A498CBonCan2, 15, 2, ".", "")));
         AssignAttri("", false, "A493CBonBon2", StringUtil.LTrim( StringUtil.NToC( A493CBonBon2, 15, 2, ".", "")));
         AssignAttri("", false, "A499CBonCan3", StringUtil.LTrim( StringUtil.NToC( A499CBonCan3, 15, 2, ".", "")));
         AssignAttri("", false, "A494CBonBon3", StringUtil.LTrim( StringUtil.NToC( A494CBonBon3, 15, 2, ".", "")));
         AssignAttri("", false, "A500CBonCan4", StringUtil.LTrim( StringUtil.NToC( A500CBonCan4, 15, 2, ".", "")));
         AssignAttri("", false, "A495CBonBon4", StringUtil.LTrim( StringUtil.NToC( A495CBonBon4, 15, 2, ".", "")));
         AssignAttri("", false, "A501CBonCan5", StringUtil.LTrim( StringUtil.NToC( A501CBonCan5, 15, 2, ".", "")));
         AssignAttri("", false, "A496CBonBon5", StringUtil.LTrim( StringUtil.NToC( A496CBonBon5, 15, 2, ".", "")));
         AssignAttri("", false, "A503CBonProdDsc", StringUtil.RTrim( A503CBonProdDsc));
         AssignAttri("", false, "A502CBonDProdDsc", StringUtil.RTrim( A502CBonDProdDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z81CBonProdCod", StringUtil.RTrim( Z81CBonProdCod));
         GxWebStd.gx_hidden_field( context, "Z82CBonDProdCod", StringUtil.RTrim( Z82CBonDProdCod));
         GxWebStd.gx_hidden_field( context, "Z497CBonCan1", StringUtil.LTrim( StringUtil.NToC( Z497CBonCan1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z492CBonBon1", StringUtil.LTrim( StringUtil.NToC( Z492CBonBon1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z498CBonCan2", StringUtil.LTrim( StringUtil.NToC( Z498CBonCan2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z493CBonBon2", StringUtil.LTrim( StringUtil.NToC( Z493CBonBon2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z499CBonCan3", StringUtil.LTrim( StringUtil.NToC( Z499CBonCan3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z494CBonBon3", StringUtil.LTrim( StringUtil.NToC( Z494CBonBon3, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z500CBonCan4", StringUtil.LTrim( StringUtil.NToC( Z500CBonCan4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z495CBonBon4", StringUtil.LTrim( StringUtil.NToC( Z495CBonBon4, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z501CBonCan5", StringUtil.LTrim( StringUtil.NToC( Z501CBonCan5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z496CBonBon5", StringUtil.LTrim( StringUtil.NToC( Z496CBonBon5, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z503CBonProdDsc", StringUtil.RTrim( Z503CBonProdDsc));
         GxWebStd.gx_hidden_field( context, "Z502CBonDProdDsc", StringUtil.RTrim( Z502CBonDProdDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cbondprodcod( )
      {
         /* Using cursor T000416 */
         pr_default.execute(14, new Object[] {A82CBonDProdCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle Producto Bonificacion'.", "ForeignKeyNotFound", 1, "CBONDPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtCBonDProdCod_Internalname;
         }
         A502CBonDProdDsc = T000416_A502CBonDProdDsc[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A502CBonDProdDsc", StringUtil.RTrim( A502CBonDProdDsc));
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
         setEventMetadata("VALID_CBONPRODCOD","{handler:'Valid_Cbonprodcod',iparms:[{av:'A81CBonProdCod',fld:'CBONPRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBONPRODCOD",",oparms:[{av:'A82CBonDProdCod',fld:'CBONDPRODCOD',pic:'@!'},{av:'A497CBonCan1',fld:'CBONCAN1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A492CBonBon1',fld:'CBONBON1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A498CBonCan2',fld:'CBONCAN2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A493CBonBon2',fld:'CBONBON2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A499CBonCan3',fld:'CBONCAN3',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A494CBonBon3',fld:'CBONBON3',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A500CBonCan4',fld:'CBONCAN4',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A495CBonBon4',fld:'CBONBON4',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A501CBonCan5',fld:'CBONCAN5',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A496CBonBon5',fld:'CBONBON5',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A503CBonProdDsc',fld:'CBONPRODDSC',pic:''},{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z81CBonProdCod'},{av:'Z82CBonDProdCod'},{av:'Z497CBonCan1'},{av:'Z492CBonBon1'},{av:'Z498CBonCan2'},{av:'Z493CBonBon2'},{av:'Z499CBonCan3'},{av:'Z494CBonBon3'},{av:'Z500CBonCan4'},{av:'Z495CBonBon4'},{av:'Z501CBonCan5'},{av:'Z496CBonBon5'},{av:'Z503CBonProdDsc'},{av:'Z502CBonDProdDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CBONDPRODCOD","{handler:'Valid_Cbondprodcod',iparms:[{av:'A82CBonDProdCod',fld:'CBONDPRODCOD',pic:'@!'},{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''}]");
         setEventMetadata("VALID_CBONDPRODCOD",",oparms:[{av:'A502CBonDProdDsc',fld:'CBONDPRODDSC',pic:''}]}");
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
         Z81CBonProdCod = "";
         Z82CBonDProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A81CBonProdCod = "";
         A82CBonDProdCod = "";
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
         A503CBonProdDsc = "";
         A502CBonDProdDsc = "";
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
         Z503CBonProdDsc = "";
         Z502CBonDProdDsc = "";
         T00046_A503CBonProdDsc = new string[] {""} ;
         T00046_A502CBonDProdDsc = new string[] {""} ;
         T00046_A497CBonCan1 = new decimal[1] ;
         T00046_A492CBonBon1 = new decimal[1] ;
         T00046_A498CBonCan2 = new decimal[1] ;
         T00046_A493CBonBon2 = new decimal[1] ;
         T00046_A499CBonCan3 = new decimal[1] ;
         T00046_A494CBonBon3 = new decimal[1] ;
         T00046_A500CBonCan4 = new decimal[1] ;
         T00046_A495CBonBon4 = new decimal[1] ;
         T00046_A501CBonCan5 = new decimal[1] ;
         T00046_A496CBonBon5 = new decimal[1] ;
         T00046_A81CBonProdCod = new string[] {""} ;
         T00046_A82CBonDProdCod = new string[] {""} ;
         T00044_A503CBonProdDsc = new string[] {""} ;
         T00045_A502CBonDProdDsc = new string[] {""} ;
         T00047_A503CBonProdDsc = new string[] {""} ;
         T00048_A502CBonDProdDsc = new string[] {""} ;
         T00049_A81CBonProdCod = new string[] {""} ;
         T00043_A497CBonCan1 = new decimal[1] ;
         T00043_A492CBonBon1 = new decimal[1] ;
         T00043_A498CBonCan2 = new decimal[1] ;
         T00043_A493CBonBon2 = new decimal[1] ;
         T00043_A499CBonCan3 = new decimal[1] ;
         T00043_A494CBonBon3 = new decimal[1] ;
         T00043_A500CBonCan4 = new decimal[1] ;
         T00043_A495CBonBon4 = new decimal[1] ;
         T00043_A501CBonCan5 = new decimal[1] ;
         T00043_A496CBonBon5 = new decimal[1] ;
         T00043_A81CBonProdCod = new string[] {""} ;
         T00043_A82CBonDProdCod = new string[] {""} ;
         sMode4 = "";
         T000410_A81CBonProdCod = new string[] {""} ;
         T000411_A81CBonProdCod = new string[] {""} ;
         T00042_A497CBonCan1 = new decimal[1] ;
         T00042_A492CBonBon1 = new decimal[1] ;
         T00042_A498CBonCan2 = new decimal[1] ;
         T00042_A493CBonBon2 = new decimal[1] ;
         T00042_A499CBonCan3 = new decimal[1] ;
         T00042_A494CBonBon3 = new decimal[1] ;
         T00042_A500CBonCan4 = new decimal[1] ;
         T00042_A495CBonBon4 = new decimal[1] ;
         T00042_A501CBonCan5 = new decimal[1] ;
         T00042_A496CBonBon5 = new decimal[1] ;
         T00042_A81CBonProdCod = new string[] {""} ;
         T00042_A82CBonDProdCod = new string[] {""} ;
         T000415_A503CBonProdDsc = new string[] {""} ;
         T000416_A502CBonDProdDsc = new string[] {""} ;
         T000417_A81CBonProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ81CBonProdCod = "";
         ZZ82CBonDProdCod = "";
         ZZ503CBonProdDsc = "";
         ZZ502CBonDProdDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbonificacion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbonificacion__default(),
            new Object[][] {
                new Object[] {
               T00042_A497CBonCan1, T00042_A492CBonBon1, T00042_A498CBonCan2, T00042_A493CBonBon2, T00042_A499CBonCan3, T00042_A494CBonBon3, T00042_A500CBonCan4, T00042_A495CBonBon4, T00042_A501CBonCan5, T00042_A496CBonBon5,
               T00042_A81CBonProdCod, T00042_A82CBonDProdCod
               }
               , new Object[] {
               T00043_A497CBonCan1, T00043_A492CBonBon1, T00043_A498CBonCan2, T00043_A493CBonBon2, T00043_A499CBonCan3, T00043_A494CBonBon3, T00043_A500CBonCan4, T00043_A495CBonBon4, T00043_A501CBonCan5, T00043_A496CBonBon5,
               T00043_A81CBonProdCod, T00043_A82CBonDProdCod
               }
               , new Object[] {
               T00044_A503CBonProdDsc
               }
               , new Object[] {
               T00045_A502CBonDProdDsc
               }
               , new Object[] {
               T00046_A503CBonProdDsc, T00046_A502CBonDProdDsc, T00046_A497CBonCan1, T00046_A492CBonBon1, T00046_A498CBonCan2, T00046_A493CBonBon2, T00046_A499CBonCan3, T00046_A494CBonBon3, T00046_A500CBonCan4, T00046_A495CBonBon4,
               T00046_A501CBonCan5, T00046_A496CBonBon5, T00046_A81CBonProdCod, T00046_A82CBonDProdCod
               }
               , new Object[] {
               T00047_A503CBonProdDsc
               }
               , new Object[] {
               T00048_A502CBonDProdDsc
               }
               , new Object[] {
               T00049_A81CBonProdCod
               }
               , new Object[] {
               T000410_A81CBonProdCod
               }
               , new Object[] {
               T000411_A81CBonProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000415_A503CBonProdDsc
               }
               , new Object[] {
               T000416_A502CBonDProdDsc
               }
               , new Object[] {
               T000417_A81CBonProdCod
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
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCBonProdCod_Enabled ;
      private int edtCBonProdDsc_Enabled ;
      private int edtCBonDProdCod_Enabled ;
      private int edtCBonDProdDsc_Enabled ;
      private int edtCBonCan1_Enabled ;
      private int edtCBonBon1_Enabled ;
      private int edtCBonCan2_Enabled ;
      private int edtCBonBon2_Enabled ;
      private int edtCBonCan3_Enabled ;
      private int edtCBonBon3_Enabled ;
      private int edtCBonCan4_Enabled ;
      private int edtCBonBon4_Enabled ;
      private int edtCBonCan5_Enabled ;
      private int edtCBonBon5_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z497CBonCan1 ;
      private decimal Z492CBonBon1 ;
      private decimal Z498CBonCan2 ;
      private decimal Z493CBonBon2 ;
      private decimal Z499CBonCan3 ;
      private decimal Z494CBonBon3 ;
      private decimal Z500CBonCan4 ;
      private decimal Z495CBonBon4 ;
      private decimal Z501CBonCan5 ;
      private decimal Z496CBonBon5 ;
      private decimal A497CBonCan1 ;
      private decimal A492CBonBon1 ;
      private decimal A498CBonCan2 ;
      private decimal A493CBonBon2 ;
      private decimal A499CBonCan3 ;
      private decimal A494CBonBon3 ;
      private decimal A500CBonCan4 ;
      private decimal A495CBonBon4 ;
      private decimal A501CBonCan5 ;
      private decimal A496CBonBon5 ;
      private decimal ZZ497CBonCan1 ;
      private decimal ZZ492CBonBon1 ;
      private decimal ZZ498CBonCan2 ;
      private decimal ZZ493CBonBon2 ;
      private decimal ZZ499CBonCan3 ;
      private decimal ZZ494CBonBon3 ;
      private decimal ZZ500CBonCan4 ;
      private decimal ZZ495CBonBon4 ;
      private decimal ZZ501CBonCan5 ;
      private decimal ZZ496CBonBon5 ;
      private string sPrefix ;
      private string Z81CBonProdCod ;
      private string Z82CBonDProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A81CBonProdCod ;
      private string A82CBonDProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCBonProdCod_Internalname ;
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
      private string edtCBonProdCod_Jsonclick ;
      private string edtCBonProdDsc_Internalname ;
      private string A503CBonProdDsc ;
      private string edtCBonProdDsc_Jsonclick ;
      private string edtCBonDProdCod_Internalname ;
      private string edtCBonDProdCod_Jsonclick ;
      private string edtCBonDProdDsc_Internalname ;
      private string A502CBonDProdDsc ;
      private string edtCBonDProdDsc_Jsonclick ;
      private string edtCBonCan1_Internalname ;
      private string edtCBonCan1_Jsonclick ;
      private string edtCBonBon1_Internalname ;
      private string edtCBonBon1_Jsonclick ;
      private string edtCBonCan2_Internalname ;
      private string edtCBonCan2_Jsonclick ;
      private string edtCBonBon2_Internalname ;
      private string edtCBonBon2_Jsonclick ;
      private string edtCBonCan3_Internalname ;
      private string edtCBonCan3_Jsonclick ;
      private string edtCBonBon3_Internalname ;
      private string edtCBonBon3_Jsonclick ;
      private string edtCBonCan4_Internalname ;
      private string edtCBonCan4_Jsonclick ;
      private string edtCBonBon4_Internalname ;
      private string edtCBonBon4_Jsonclick ;
      private string edtCBonCan5_Internalname ;
      private string edtCBonCan5_Jsonclick ;
      private string edtCBonBon5_Internalname ;
      private string edtCBonBon5_Jsonclick ;
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
      private string Z503CBonProdDsc ;
      private string Z502CBonDProdDsc ;
      private string sMode4 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ81CBonProdCod ;
      private string ZZ82CBonDProdCod ;
      private string ZZ503CBonProdDsc ;
      private string ZZ502CBonDProdDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00046_A503CBonProdDsc ;
      private string[] T00046_A502CBonDProdDsc ;
      private decimal[] T00046_A497CBonCan1 ;
      private decimal[] T00046_A492CBonBon1 ;
      private decimal[] T00046_A498CBonCan2 ;
      private decimal[] T00046_A493CBonBon2 ;
      private decimal[] T00046_A499CBonCan3 ;
      private decimal[] T00046_A494CBonBon3 ;
      private decimal[] T00046_A500CBonCan4 ;
      private decimal[] T00046_A495CBonBon4 ;
      private decimal[] T00046_A501CBonCan5 ;
      private decimal[] T00046_A496CBonBon5 ;
      private string[] T00046_A81CBonProdCod ;
      private string[] T00046_A82CBonDProdCod ;
      private string[] T00044_A503CBonProdDsc ;
      private string[] T00045_A502CBonDProdDsc ;
      private string[] T00047_A503CBonProdDsc ;
      private string[] T00048_A502CBonDProdDsc ;
      private string[] T00049_A81CBonProdCod ;
      private decimal[] T00043_A497CBonCan1 ;
      private decimal[] T00043_A492CBonBon1 ;
      private decimal[] T00043_A498CBonCan2 ;
      private decimal[] T00043_A493CBonBon2 ;
      private decimal[] T00043_A499CBonCan3 ;
      private decimal[] T00043_A494CBonBon3 ;
      private decimal[] T00043_A500CBonCan4 ;
      private decimal[] T00043_A495CBonBon4 ;
      private decimal[] T00043_A501CBonCan5 ;
      private decimal[] T00043_A496CBonBon5 ;
      private string[] T00043_A81CBonProdCod ;
      private string[] T00043_A82CBonDProdCod ;
      private string[] T000410_A81CBonProdCod ;
      private string[] T000411_A81CBonProdCod ;
      private decimal[] T00042_A497CBonCan1 ;
      private decimal[] T00042_A492CBonBon1 ;
      private decimal[] T00042_A498CBonCan2 ;
      private decimal[] T00042_A493CBonBon2 ;
      private decimal[] T00042_A499CBonCan3 ;
      private decimal[] T00042_A494CBonBon3 ;
      private decimal[] T00042_A500CBonCan4 ;
      private decimal[] T00042_A495CBonBon4 ;
      private decimal[] T00042_A501CBonCan5 ;
      private decimal[] T00042_A496CBonBon5 ;
      private string[] T00042_A81CBonProdCod ;
      private string[] T00042_A82CBonDProdCod ;
      private string[] T000415_A503CBonProdDsc ;
      private string[] T000416_A502CBonDProdDsc ;
      private string[] T000417_A81CBonProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbonificacion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbonificacion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00046;
        prmT00046 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00044;
        prmT00044 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00045;
        prmT00045 = new Object[] {
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00047;
        prmT00047 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00048;
        prmT00048 = new Object[] {
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00049;
        prmT00049 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00043;
        prmT00043 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT000410;
        prmT000410 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT000411;
        prmT000411 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT00042;
        prmT00042 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT000412;
        prmT000412 = new Object[] {
        new ParDef("@CBonCan1",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon1",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan2",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon2",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan3",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon3",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan4",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon4",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan5",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon5",GXType.Decimal,15,2) ,
        new ParDef("@CBonProdCod",GXType.NChar,15,0) ,
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        Object[] prmT000413;
        prmT000413 = new Object[] {
        new ParDef("@CBonCan1",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon1",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan2",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon2",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan3",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon3",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan4",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon4",GXType.Decimal,15,2) ,
        new ParDef("@CBonCan5",GXType.Decimal,15,2) ,
        new ParDef("@CBonBon5",GXType.Decimal,15,2) ,
        new ParDef("@CBonDProdCod",GXType.NChar,15,0) ,
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT000414;
        prmT000414 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT000417;
        prmT000417 = new Object[] {
        };
        Object[] prmT000415;
        prmT000415 = new Object[] {
        new ParDef("@CBonProdCod",GXType.NChar,15,0)
        };
        Object[] prmT000416;
        prmT000416 = new Object[] {
        new ParDef("@CBonDProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00042", "SELECT [CBonCan1], [CBonBon1], [CBonCan2], [CBonBon2], [CBonCan3], [CBonBon3], [CBonCan4], [CBonBon4], [CBonCan5], [CBonBon5], [CBonProdCod] AS CBonProdCod, [CBonDProdCod] AS CBonDProdCod FROM [CBONIFICACION] WITH (UPDLOCK) WHERE [CBonProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00043", "SELECT [CBonCan1], [CBonBon1], [CBonCan2], [CBonBon2], [CBonCan3], [CBonBon3], [CBonCan4], [CBonBon4], [CBonCan5], [CBonBon5], [CBonProdCod] AS CBonProdCod, [CBonDProdCod] AS CBonDProdCod FROM [CBONIFICACION] WHERE [CBonProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00044", "SELECT [ProdDsc] AS CBonProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00045", "SELECT [ProdDsc] AS CBonDProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00046", "SELECT T2.[ProdDsc] AS CBonProdDsc, T3.[ProdDsc] AS CBonDProdDsc, TM1.[CBonCan1], TM1.[CBonBon1], TM1.[CBonCan2], TM1.[CBonBon2], TM1.[CBonCan3], TM1.[CBonBon3], TM1.[CBonCan4], TM1.[CBonBon4], TM1.[CBonCan5], TM1.[CBonBon5], TM1.[CBonProdCod] AS CBonProdCod, TM1.[CBonDProdCod] AS CBonDProdCod FROM (([CBONIFICACION] TM1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = TM1.[CBonProdCod]) INNER JOIN [APRODUCTOS] T3 ON T3.[ProdCod] = TM1.[CBonDProdCod]) WHERE TM1.[CBonProdCod] = @CBonProdCod ORDER BY TM1.[CBonProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00046,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00047", "SELECT [ProdDsc] AS CBonProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00047,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00048", "SELECT [ProdDsc] AS CBonDProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00048,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00049", "SELECT [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] WHERE [CBonProdCod] = @CBonProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00049,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000410", "SELECT TOP 1 [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] WHERE ( [CBonProdCod] > @CBonProdCod) ORDER BY [CBonProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000410,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000411", "SELECT TOP 1 [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] WHERE ( [CBonProdCod] < @CBonProdCod) ORDER BY [CBonProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000411,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000412", "INSERT INTO [CBONIFICACION]([CBonCan1], [CBonBon1], [CBonCan2], [CBonBon2], [CBonCan3], [CBonBon3], [CBonCan4], [CBonBon4], [CBonCan5], [CBonBon5], [CBonProdCod], [CBonDProdCod]) VALUES(@CBonCan1, @CBonBon1, @CBonCan2, @CBonBon2, @CBonCan3, @CBonBon3, @CBonCan4, @CBonBon4, @CBonCan5, @CBonBon5, @CBonProdCod, @CBonDProdCod)", GxErrorMask.GX_NOMASK,prmT000412)
           ,new CursorDef("T000413", "UPDATE [CBONIFICACION] SET [CBonCan1]=@CBonCan1, [CBonBon1]=@CBonBon1, [CBonCan2]=@CBonCan2, [CBonBon2]=@CBonBon2, [CBonCan3]=@CBonCan3, [CBonBon3]=@CBonBon3, [CBonCan4]=@CBonCan4, [CBonBon4]=@CBonBon4, [CBonCan5]=@CBonCan5, [CBonBon5]=@CBonBon5, [CBonDProdCod]=@CBonDProdCod  WHERE [CBonProdCod] = @CBonProdCod", GxErrorMask.GX_NOMASK,prmT000413)
           ,new CursorDef("T000414", "DELETE FROM [CBONIFICACION]  WHERE [CBonProdCod] = @CBonProdCod", GxErrorMask.GX_NOMASK,prmT000414)
           ,new CursorDef("T000415", "SELECT [ProdDsc] AS CBonProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000415,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000416", "SELECT [ProdDsc] AS CBonDProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @CBonDProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000416,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000417", "SELECT [CBonProdCod] AS CBonProdCod FROM [CBONIFICACION] ORDER BY [CBonProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000417,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
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
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 15);
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
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 15);
              ((string[]) buf[13])[0] = rslt.getString(14, 15);
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
