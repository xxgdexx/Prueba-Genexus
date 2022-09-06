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
   public class sgusuarioopciones : GXDataArea
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
            A2016UsuMosBanCod = (int)(NumberUtil.Val( GetPar( "UsuMosBanCod"), "."));
            n2016UsuMosBanCod = false;
            AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2016UsuMosBanCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A2016UsuMosBanCod = (int)(NumberUtil.Val( GetPar( "UsuMosBanCod"), "."));
            n2016UsuMosBanCod = false;
            AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            A2017UsuMosCBCod = GetPar( "UsuMosCBCod");
            n2017UsuMosCBCod = false;
            AssignAttri("", false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A2016UsuMosBanCod, A2017UsuMosCBCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A350UsuMosConcepto = (int)(NumberUtil.Val( GetPar( "UsuMosConcepto"), "."));
            n350UsuMosConcepto = false;
            AssignAttri("", false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A350UsuMosConcepto) ;
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
            Form.Meta.addItem("description", "SGUSUARIOOPCIONES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgusuarioopciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuarioopciones( IGxContext context )
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
         chkUsuPedPrecio = new GXCheckbox();
         chkUsuPedDscto = new GXCheckbox();
         chkUsuPedStock = new GXCheckbox();
         chkUsuPedVend = new GXCheckbox();
         chkUsuPedCond = new GXCheckbox();
         chkUsuPedList = new GXCheckbox();
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
         A2027UsuPedPrecio = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2027UsuPedPrecio), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
         A2023UsuPedDscto = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2023UsuPedDscto), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
         A2028UsuPedStock = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2028UsuPedStock), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
         A2029UsuPedVend = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2029UsuPedVend), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
         A2022UsuPedCond = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2022UsuPedCond), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
         A2024UsuPedList = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2024UsuPedList), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGUSUARIOOPCIONES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIOOPCIONES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIOOPCIONES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuNom_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuNom_Internalname, "Nombre Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuNom_Internalname, StringUtil.RTrim( A2019UsuNom), StringUtil.RTrim( context.localUtil.Format( A2019UsuNom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuNom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuNom_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedPrecio_Internalname, "Precios", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedPrecio_Internalname, StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0), "", "Precios", 1, chkUsuPedPrecio.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(38, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedDscto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedDscto_Internalname, "Descuentos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedDscto_Internalname, StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0), "", "Descuentos", 1, chkUsuPedDscto.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(43, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedStock_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedStock_Internalname, "Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedStock_Internalname, StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0), "", "Stock", 1, chkUsuPedStock.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(48, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedVend_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedVend_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedVend_Internalname, StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0), "", "Vendedor", 1, chkUsuPedVend.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(53, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedCond_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedCond_Internalname, "de Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedCond_Internalname, StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0), "", "de Pago", 1, chkUsuPedCond.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(58, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkUsuPedList_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkUsuPedList_Internalname, "de Precios", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkUsuPedList_Internalname, StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0), "", "de Precios", 1, chkUsuPedList.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(63, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuPedMon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuPedMon_Internalname, "Default", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuPedMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2026UsuPedMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtUsuPedMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A2026UsuPedMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2026UsuPedMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuPedMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuPedMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuMosBanCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuMosBanCod_Internalname, "Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuMosBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2016UsuMosBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtUsuMosBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2016UsuMosBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2016UsuMosBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuMosBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuMosBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuMosCBCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuMosCBCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuMosCBCod_Internalname, StringUtil.RTrim( A2017UsuMosCBCod), StringUtil.RTrim( context.localUtil.Format( A2017UsuMosCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuMosCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuMosCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuMosConcepto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuMosConcepto_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUsuMosConcepto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A350UsuMosConcepto), 6, 0, ".", "")), StringUtil.LTrim( ((edtUsuMosConcepto_Enabled!=0) ? context.localUtil.Format( (decimal)(A350UsuMosConcepto), "ZZZZZ9") : context.localUtil.Format( (decimal)(A350UsuMosConcepto), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuMosConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuMosConcepto_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtUsuMosConceptoDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtUsuMosConceptoDsc_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtUsuMosConceptoDsc_Internalname, StringUtil.RTrim( A2018UsuMosConceptoDsc), StringUtil.RTrim( context.localUtil.Format( A2018UsuMosConceptoDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuMosConceptoDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuMosConceptoDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOOPCIONES.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOOPCIONES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOOPCIONES.htm");
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
            Z348UsuCod = cgiGet( "Z348UsuCod");
            Z2019UsuNom = cgiGet( "Z2019UsuNom");
            Z2027UsuPedPrecio = (short)(context.localUtil.CToN( cgiGet( "Z2027UsuPedPrecio"), ".", ","));
            Z2023UsuPedDscto = (short)(context.localUtil.CToN( cgiGet( "Z2023UsuPedDscto"), ".", ","));
            Z2028UsuPedStock = (short)(context.localUtil.CToN( cgiGet( "Z2028UsuPedStock"), ".", ","));
            Z2029UsuPedVend = (short)(context.localUtil.CToN( cgiGet( "Z2029UsuPedVend"), ".", ","));
            Z2022UsuPedCond = (short)(context.localUtil.CToN( cgiGet( "Z2022UsuPedCond"), ".", ","));
            Z2024UsuPedList = (short)(context.localUtil.CToN( cgiGet( "Z2024UsuPedList"), ".", ","));
            Z2026UsuPedMon = (int)(context.localUtil.CToN( cgiGet( "Z2026UsuPedMon"), ".", ","));
            n2026UsuPedMon = ((0==A2026UsuPedMon) ? true : false);
            Z2016UsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( "Z2016UsuMosBanCod"), ".", ","));
            n2016UsuMosBanCod = ((0==A2016UsuMosBanCod) ? true : false);
            Z2017UsuMosCBCod = cgiGet( "Z2017UsuMosCBCod");
            n2017UsuMosCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ? true : false);
            Z350UsuMosConcepto = (int)(context.localUtil.CToN( cgiGet( "Z350UsuMosConcepto"), ".", ","));
            n350UsuMosConcepto = ((0==A350UsuMosConcepto) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A348UsuCod = cgiGet( edtUsuCod_Internalname);
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A2019UsuNom = cgiGet( edtUsuNom_Internalname);
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedPrecio_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedPrecio_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDPRECIO");
               AnyError = 1;
               GX_FocusControl = chkUsuPedPrecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2027UsuPedPrecio = 0;
               AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
            }
            else
            {
               A2027UsuPedPrecio = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedPrecio_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedDscto_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedDscto_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDDSCTO");
               AnyError = 1;
               GX_FocusControl = chkUsuPedDscto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2023UsuPedDscto = 0;
               AssignAttri("", false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
            }
            else
            {
               A2023UsuPedDscto = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedDscto_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedStock_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedStock_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDSTOCK");
               AnyError = 1;
               GX_FocusControl = chkUsuPedStock_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2028UsuPedStock = 0;
               AssignAttri("", false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
            }
            else
            {
               A2028UsuPedStock = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedStock_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedVend_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedVend_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDVEND");
               AnyError = 1;
               GX_FocusControl = chkUsuPedVend_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2029UsuPedVend = 0;
               AssignAttri("", false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
            }
            else
            {
               A2029UsuPedVend = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedVend_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedCond_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedCond_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDCOND");
               AnyError = 1;
               GX_FocusControl = chkUsuPedCond_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2022UsuPedCond = 0;
               AssignAttri("", false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
            }
            else
            {
               A2022UsuPedCond = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedCond_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedList_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkUsuPedList_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDLIST");
               AnyError = 1;
               GX_FocusControl = chkUsuPedList_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2024UsuPedList = 0;
               AssignAttri("", false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
            }
            else
            {
               A2024UsuPedList = (short)(((StringUtil.StrCmp(cgiGet( chkUsuPedList_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuPedMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuPedMon_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUPEDMON");
               AnyError = 1;
               GX_FocusControl = edtUsuPedMon_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2026UsuPedMon = 0;
               n2026UsuPedMon = false;
               AssignAttri("", false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
            }
            else
            {
               A2026UsuPedMon = (int)(context.localUtil.CToN( cgiGet( edtUsuPedMon_Internalname), ".", ","));
               n2026UsuPedMon = false;
               AssignAttri("", false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
            }
            n2026UsuPedMon = ((0==A2026UsuPedMon) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuMosBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuMosBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUMOSBANCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2016UsuMosBanCod = 0;
               n2016UsuMosBanCod = false;
               AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            }
            else
            {
               A2016UsuMosBanCod = (int)(context.localUtil.CToN( cgiGet( edtUsuMosBanCod_Internalname), ".", ","));
               n2016UsuMosBanCod = false;
               AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            }
            n2016UsuMosBanCod = ((0==A2016UsuMosBanCod) ? true : false);
            A2017UsuMosCBCod = cgiGet( edtUsuMosCBCod_Internalname);
            n2017UsuMosCBCod = false;
            AssignAttri("", false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
            n2017UsuMosCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtUsuMosConcepto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUsuMosConcepto_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "USUMOSCONCEPTO");
               AnyError = 1;
               GX_FocusControl = edtUsuMosConcepto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A350UsuMosConcepto = 0;
               n350UsuMosConcepto = false;
               AssignAttri("", false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            }
            else
            {
               A350UsuMosConcepto = (int)(context.localUtil.CToN( cgiGet( edtUsuMosConcepto_Internalname), ".", ","));
               n350UsuMosConcepto = false;
               AssignAttri("", false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            }
            n350UsuMosConcepto = ((0==A350UsuMosConcepto) ? true : false);
            A2018UsuMosConceptoDsc = cgiGet( edtUsuMosConceptoDsc_Internalname);
            AssignAttri("", false, "A2018UsuMosConceptoDsc", A2018UsuMosConceptoDsc);
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
               A348UsuCod = GetPar( "UsuCod");
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
               InitAll0X32( ) ;
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
         DisableAttributes0X32( ) ;
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

      protected void ResetCaption0X0( )
      {
      }

      protected void ZM0X32( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2019UsuNom = T000X3_A2019UsuNom[0];
               Z2027UsuPedPrecio = T000X3_A2027UsuPedPrecio[0];
               Z2023UsuPedDscto = T000X3_A2023UsuPedDscto[0];
               Z2028UsuPedStock = T000X3_A2028UsuPedStock[0];
               Z2029UsuPedVend = T000X3_A2029UsuPedVend[0];
               Z2022UsuPedCond = T000X3_A2022UsuPedCond[0];
               Z2024UsuPedList = T000X3_A2024UsuPedList[0];
               Z2026UsuPedMon = T000X3_A2026UsuPedMon[0];
               Z2016UsuMosBanCod = T000X3_A2016UsuMosBanCod[0];
               Z2017UsuMosCBCod = T000X3_A2017UsuMosCBCod[0];
               Z350UsuMosConcepto = T000X3_A350UsuMosConcepto[0];
            }
            else
            {
               Z2019UsuNom = A2019UsuNom;
               Z2027UsuPedPrecio = A2027UsuPedPrecio;
               Z2023UsuPedDscto = A2023UsuPedDscto;
               Z2028UsuPedStock = A2028UsuPedStock;
               Z2029UsuPedVend = A2029UsuPedVend;
               Z2022UsuPedCond = A2022UsuPedCond;
               Z2024UsuPedList = A2024UsuPedList;
               Z2026UsuPedMon = A2026UsuPedMon;
               Z2016UsuMosBanCod = A2016UsuMosBanCod;
               Z2017UsuMosCBCod = A2017UsuMosCBCod;
               Z350UsuMosConcepto = A350UsuMosConcepto;
            }
         }
         if ( GX_JID == -1 )
         {
            Z348UsuCod = A348UsuCod;
            Z2019UsuNom = A2019UsuNom;
            Z2027UsuPedPrecio = A2027UsuPedPrecio;
            Z2023UsuPedDscto = A2023UsuPedDscto;
            Z2028UsuPedStock = A2028UsuPedStock;
            Z2029UsuPedVend = A2029UsuPedVend;
            Z2022UsuPedCond = A2022UsuPedCond;
            Z2024UsuPedList = A2024UsuPedList;
            Z2026UsuPedMon = A2026UsuPedMon;
            Z2016UsuMosBanCod = A2016UsuMosBanCod;
            Z2017UsuMosCBCod = A2017UsuMosCBCod;
            Z350UsuMosConcepto = A350UsuMosConcepto;
            Z2018UsuMosConceptoDsc = A2018UsuMosConceptoDsc;
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

      protected void Load0X32( )
      {
         /* Using cursor T000X7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound32 = 1;
            A2019UsuNom = T000X7_A2019UsuNom[0];
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            A2027UsuPedPrecio = T000X7_A2027UsuPedPrecio[0];
            AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
            A2023UsuPedDscto = T000X7_A2023UsuPedDscto[0];
            AssignAttri("", false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
            A2028UsuPedStock = T000X7_A2028UsuPedStock[0];
            AssignAttri("", false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
            A2029UsuPedVend = T000X7_A2029UsuPedVend[0];
            AssignAttri("", false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
            A2022UsuPedCond = T000X7_A2022UsuPedCond[0];
            AssignAttri("", false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
            A2024UsuPedList = T000X7_A2024UsuPedList[0];
            AssignAttri("", false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
            A2026UsuPedMon = T000X7_A2026UsuPedMon[0];
            n2026UsuPedMon = T000X7_n2026UsuPedMon[0];
            AssignAttri("", false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
            A2018UsuMosConceptoDsc = T000X7_A2018UsuMosConceptoDsc[0];
            AssignAttri("", false, "A2018UsuMosConceptoDsc", A2018UsuMosConceptoDsc);
            A2016UsuMosBanCod = T000X7_A2016UsuMosBanCod[0];
            n2016UsuMosBanCod = T000X7_n2016UsuMosBanCod[0];
            AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            A2017UsuMosCBCod = T000X7_A2017UsuMosCBCod[0];
            n2017UsuMosCBCod = T000X7_n2017UsuMosCBCod[0];
            AssignAttri("", false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
            A350UsuMosConcepto = T000X7_A350UsuMosConcepto[0];
            n350UsuMosConcepto = T000X7_n350UsuMosConcepto[0];
            AssignAttri("", false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            ZM0X32( -1) ;
         }
         pr_default.close(5);
         OnLoadActions0X32( ) ;
      }

      protected void OnLoadActions0X32( )
      {
      }

      protected void CheckExtendedTable0X32( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000X4 */
         pr_default.execute(2, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "USUMOSBANCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(2);
         /* Using cursor T000X5 */
         pr_default.execute(3, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Banco'.", "ForeignKeyNotFound", 1, "USUMOSCBCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T000X6 */
         pr_default.execute(4, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A350UsuMosConcepto) ) )
            {
               GX_msglist.addItem("No existe 'Sub Banco Mostrador'.", "ForeignKeyNotFound", 1, "USUMOSCONCEPTO");
               AnyError = 1;
               GX_FocusControl = edtUsuMosConcepto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2018UsuMosConceptoDsc = T000X6_A2018UsuMosConceptoDsc[0];
         AssignAttri("", false, "A2018UsuMosConceptoDsc", A2018UsuMosConceptoDsc);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0X32( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A2016UsuMosBanCod )
      {
         /* Using cursor T000X8 */
         pr_default.execute(6, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "USUMOSBANCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_3( int A2016UsuMosBanCod ,
                               string A2017UsuMosCBCod )
      {
         /* Using cursor T000X9 */
         pr_default.execute(7, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Banco'.", "ForeignKeyNotFound", 1, "USUMOSCBCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( int A350UsuMosConcepto )
      {
         /* Using cursor T000X10 */
         pr_default.execute(8, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A350UsuMosConcepto) ) )
            {
               GX_msglist.addItem("No existe 'Sub Banco Mostrador'.", "ForeignKeyNotFound", 1, "USUMOSCONCEPTO");
               AnyError = 1;
               GX_FocusControl = edtUsuMosConcepto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A2018UsuMosConceptoDsc = T000X10_A2018UsuMosConceptoDsc[0];
         AssignAttri("", false, "A2018UsuMosConceptoDsc", A2018UsuMosConceptoDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2018UsuMosConceptoDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0X32( )
      {
         /* Using cursor T000X11 */
         pr_default.execute(9, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000X3 */
         pr_default.execute(1, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X32( 1) ;
            RcdFound32 = 1;
            A348UsuCod = T000X3_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A2019UsuNom = T000X3_A2019UsuNom[0];
            AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
            A2027UsuPedPrecio = T000X3_A2027UsuPedPrecio[0];
            AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
            A2023UsuPedDscto = T000X3_A2023UsuPedDscto[0];
            AssignAttri("", false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
            A2028UsuPedStock = T000X3_A2028UsuPedStock[0];
            AssignAttri("", false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
            A2029UsuPedVend = T000X3_A2029UsuPedVend[0];
            AssignAttri("", false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
            A2022UsuPedCond = T000X3_A2022UsuPedCond[0];
            AssignAttri("", false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
            A2024UsuPedList = T000X3_A2024UsuPedList[0];
            AssignAttri("", false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
            A2026UsuPedMon = T000X3_A2026UsuPedMon[0];
            n2026UsuPedMon = T000X3_n2026UsuPedMon[0];
            AssignAttri("", false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
            A2016UsuMosBanCod = T000X3_A2016UsuMosBanCod[0];
            n2016UsuMosBanCod = T000X3_n2016UsuMosBanCod[0];
            AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
            A2017UsuMosCBCod = T000X3_A2017UsuMosCBCod[0];
            n2017UsuMosCBCod = T000X3_n2017UsuMosCBCod[0];
            AssignAttri("", false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
            A350UsuMosConcepto = T000X3_A350UsuMosConcepto[0];
            n350UsuMosConcepto = T000X3_n350UsuMosConcepto[0];
            AssignAttri("", false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
            Z348UsuCod = A348UsuCod;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0X32( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey0X32( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey0X32( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X32( ) ;
         if ( RcdFound32 == 0 )
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
         RcdFound32 = 0;
         /* Using cursor T000X12 */
         pr_default.execute(10, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T000X12_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T000X12_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               A348UsuCod = T000X12_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T000X13 */
         pr_default.execute(11, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T000X13_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T000X13_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               A348UsuCod = T000X13_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0X32( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0X32( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "USUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0X32( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0X32( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "USUCOD");
                     AnyError = 1;
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0X32( ) ;
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
         if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUsuCod_Internalname;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUsuNom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0X32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuNom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0X32( ) ;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuNom_Internalname;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuNom_Internalname;
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
         ScanStart0X32( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound32 != 0 )
            {
               ScanNext0X32( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUsuNom_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0X32( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0X32( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000X2 */
            pr_default.execute(0, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2019UsuNom, T000X2_A2019UsuNom[0]) != 0 ) || ( Z2027UsuPedPrecio != T000X2_A2027UsuPedPrecio[0] ) || ( Z2023UsuPedDscto != T000X2_A2023UsuPedDscto[0] ) || ( Z2028UsuPedStock != T000X2_A2028UsuPedStock[0] ) || ( Z2029UsuPedVend != T000X2_A2029UsuPedVend[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2022UsuPedCond != T000X2_A2022UsuPedCond[0] ) || ( Z2024UsuPedList != T000X2_A2024UsuPedList[0] ) || ( Z2026UsuPedMon != T000X2_A2026UsuPedMon[0] ) || ( Z2016UsuMosBanCod != T000X2_A2016UsuMosBanCod[0] ) || ( StringUtil.StrCmp(Z2017UsuMosCBCod, T000X2_A2017UsuMosCBCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z350UsuMosConcepto != T000X2_A350UsuMosConcepto[0] ) )
            {
               if ( StringUtil.StrCmp(Z2019UsuNom, T000X2_A2019UsuNom[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuNom");
                  GXUtil.WriteLogRaw("Old: ",Z2019UsuNom);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2019UsuNom[0]);
               }
               if ( Z2027UsuPedPrecio != T000X2_A2027UsuPedPrecio[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuPedPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z2027UsuPedPrecio);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2027UsuPedPrecio[0]);
               }
               if ( Z2023UsuPedDscto != T000X2_A2023UsuPedDscto[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuPedDscto");
                  GXUtil.WriteLogRaw("Old: ",Z2023UsuPedDscto);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2023UsuPedDscto[0]);
               }
               if ( Z2028UsuPedStock != T000X2_A2028UsuPedStock[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuPedStock");
                  GXUtil.WriteLogRaw("Old: ",Z2028UsuPedStock);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2028UsuPedStock[0]);
               }
               if ( Z2029UsuPedVend != T000X2_A2029UsuPedVend[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuPedVend");
                  GXUtil.WriteLogRaw("Old: ",Z2029UsuPedVend);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2029UsuPedVend[0]);
               }
               if ( Z2022UsuPedCond != T000X2_A2022UsuPedCond[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuPedCond");
                  GXUtil.WriteLogRaw("Old: ",Z2022UsuPedCond);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2022UsuPedCond[0]);
               }
               if ( Z2024UsuPedList != T000X2_A2024UsuPedList[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuPedList");
                  GXUtil.WriteLogRaw("Old: ",Z2024UsuPedList);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2024UsuPedList[0]);
               }
               if ( Z2026UsuPedMon != T000X2_A2026UsuPedMon[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuPedMon");
                  GXUtil.WriteLogRaw("Old: ",Z2026UsuPedMon);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2026UsuPedMon[0]);
               }
               if ( Z2016UsuMosBanCod != T000X2_A2016UsuMosBanCod[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuMosBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z2016UsuMosBanCod);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2016UsuMosBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z2017UsuMosCBCod, T000X2_A2017UsuMosCBCod[0]) != 0 )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuMosCBCod");
                  GXUtil.WriteLogRaw("Old: ",Z2017UsuMosCBCod);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A2017UsuMosCBCod[0]);
               }
               if ( Z350UsuMosConcepto != T000X2_A350UsuMosConcepto[0] )
               {
                  GXUtil.WriteLog("sgusuarioopciones:[seudo value changed for attri]"+"UsuMosConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z350UsuMosConcepto);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A350UsuMosConcepto[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X32( )
      {
         BeforeValidate0X32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X32( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X32( 0) ;
            CheckOptimisticConcurrency0X32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X14 */
                     pr_default.execute(12, new Object[] {A348UsuCod, A2019UsuNom, A2027UsuPedPrecio, A2023UsuPedDscto, A2028UsuPedStock, A2029UsuPedVend, A2022UsuPedCond, A2024UsuPedList, n2026UsuPedMon, A2026UsuPedMon, n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod, n350UsuMosConcepto, A350UsuMosConcepto});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
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
                           ResetCaption0X0( ) ;
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
               Load0X32( ) ;
            }
            EndLevel0X32( ) ;
         }
         CloseExtendedTableCursors0X32( ) ;
      }

      protected void Update0X32( )
      {
         BeforeValidate0X32( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X32( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X32( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X32( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X32( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X15 */
                     pr_default.execute(13, new Object[] {A2019UsuNom, A2027UsuPedPrecio, A2023UsuPedDscto, A2028UsuPedStock, A2029UsuPedVend, A2022UsuPedCond, A2024UsuPedList, n2026UsuPedMon, A2026UsuPedMon, n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod, n350UsuMosConcepto, A350UsuMosConcepto, A348UsuCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X32( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0X0( ) ;
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
            EndLevel0X32( ) ;
         }
         CloseExtendedTableCursors0X32( ) ;
      }

      protected void DeferredUpdate0X32( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0X32( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X32( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X32( ) ;
            AfterConfirm0X32( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X32( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000X16 */
                  pr_default.execute(14, new Object[] {A348UsuCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound32 == 0 )
                        {
                           InitAll0X32( ) ;
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
                        ResetCaption0X0( ) ;
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0X32( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0X32( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000X17 */
            pr_default.execute(15, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
            A2018UsuMosConceptoDsc = T000X17_A2018UsuMosConceptoDsc[0];
            AssignAttri("", false, "A2018UsuMosConceptoDsc", A2018UsuMosConceptoDsc);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000X18 */
            pr_default.execute(16, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONESDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000X19 */
            pr_default.execute(17, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000X20 */
            pr_default.execute(18, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tip"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000X21 */
            pr_default.execute(19, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Objetos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000X22 */
            pr_default.execute(20, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000X23 */
            pr_default.execute(21, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel0X32( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X32( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            context.CommitDataStores("sgusuarioopciones",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            context.RollbackDataStores("sgusuarioopciones",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0X32( )
      {
         /* Using cursor T000X24 */
         pr_default.execute(22);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T000X24_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0X32( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T000X24_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
      }

      protected void ScanEnd0X32( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm0X32( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X32( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X32( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0X32( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0X32( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0X32( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X32( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtUsuNom_Enabled = 0;
         AssignProp("", false, edtUsuNom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuNom_Enabled), 5, 0), true);
         chkUsuPedPrecio.Enabled = 0;
         AssignProp("", false, chkUsuPedPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedPrecio.Enabled), 5, 0), true);
         chkUsuPedDscto.Enabled = 0;
         AssignProp("", false, chkUsuPedDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedDscto.Enabled), 5, 0), true);
         chkUsuPedStock.Enabled = 0;
         AssignProp("", false, chkUsuPedStock_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedStock.Enabled), 5, 0), true);
         chkUsuPedVend.Enabled = 0;
         AssignProp("", false, chkUsuPedVend_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedVend.Enabled), 5, 0), true);
         chkUsuPedCond.Enabled = 0;
         AssignProp("", false, chkUsuPedCond_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedCond.Enabled), 5, 0), true);
         chkUsuPedList.Enabled = 0;
         AssignProp("", false, chkUsuPedList_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkUsuPedList.Enabled), 5, 0), true);
         edtUsuPedMon_Enabled = 0;
         AssignProp("", false, edtUsuPedMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuPedMon_Enabled), 5, 0), true);
         edtUsuMosBanCod_Enabled = 0;
         AssignProp("", false, edtUsuMosBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosBanCod_Enabled), 5, 0), true);
         edtUsuMosCBCod_Enabled = 0;
         AssignProp("", false, edtUsuMosCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosCBCod_Enabled), 5, 0), true);
         edtUsuMosConcepto_Enabled = 0;
         AssignProp("", false, edtUsuMosConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosConcepto_Enabled), 5, 0), true);
         edtUsuMosConceptoDsc_Enabled = 0;
         AssignProp("", false, edtUsuMosConceptoDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuMosConceptoDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0X32( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0X0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443419", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuarioopciones.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z2019UsuNom", StringUtil.RTrim( Z2019UsuNom));
         GxWebStd.gx_hidden_field( context, "Z2027UsuPedPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2027UsuPedPrecio), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2023UsuPedDscto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2023UsuPedDscto), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2028UsuPedStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2028UsuPedStock), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2029UsuPedVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2029UsuPedVend), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2022UsuPedCond", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2022UsuPedCond), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2024UsuPedList", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2024UsuPedList), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2026UsuPedMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2026UsuPedMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2016UsuMosBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2016UsuMosBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2017UsuMosCBCod", StringUtil.RTrim( Z2017UsuMosCBCod));
         GxWebStd.gx_hidden_field( context, "Z350UsuMosConcepto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z350UsuMosConcepto), 6, 0, ".", "")));
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
         return formatLink("sgusuarioopciones.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGUSUARIOOPCIONES" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGUSUARIOOPCIONES" ;
      }

      protected void InitializeNonKey0X32( )
      {
         A2019UsuNom = "";
         AssignAttri("", false, "A2019UsuNom", A2019UsuNom);
         A2027UsuPedPrecio = 0;
         AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
         A2023UsuPedDscto = 0;
         AssignAttri("", false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
         A2028UsuPedStock = 0;
         AssignAttri("", false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
         A2029UsuPedVend = 0;
         AssignAttri("", false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
         A2022UsuPedCond = 0;
         AssignAttri("", false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
         A2024UsuPedList = 0;
         AssignAttri("", false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
         A2026UsuPedMon = 0;
         n2026UsuPedMon = false;
         AssignAttri("", false, "A2026UsuPedMon", StringUtil.LTrimStr( (decimal)(A2026UsuPedMon), 6, 0));
         n2026UsuPedMon = ((0==A2026UsuPedMon) ? true : false);
         A2016UsuMosBanCod = 0;
         n2016UsuMosBanCod = false;
         AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrimStr( (decimal)(A2016UsuMosBanCod), 6, 0));
         n2016UsuMosBanCod = ((0==A2016UsuMosBanCod) ? true : false);
         A2017UsuMosCBCod = "";
         n2017UsuMosCBCod = false;
         AssignAttri("", false, "A2017UsuMosCBCod", A2017UsuMosCBCod);
         n2017UsuMosCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ? true : false);
         A350UsuMosConcepto = 0;
         n350UsuMosConcepto = false;
         AssignAttri("", false, "A350UsuMosConcepto", StringUtil.LTrimStr( (decimal)(A350UsuMosConcepto), 6, 0));
         n350UsuMosConcepto = ((0==A350UsuMosConcepto) ? true : false);
         A2018UsuMosConceptoDsc = "";
         AssignAttri("", false, "A2018UsuMosConceptoDsc", A2018UsuMosConceptoDsc);
         Z2019UsuNom = "";
         Z2027UsuPedPrecio = 0;
         Z2023UsuPedDscto = 0;
         Z2028UsuPedStock = 0;
         Z2029UsuPedVend = 0;
         Z2022UsuPedCond = 0;
         Z2024UsuPedList = 0;
         Z2026UsuPedMon = 0;
         Z2016UsuMosBanCod = 0;
         Z2017UsuMosCBCod = "";
         Z350UsuMosConcepto = 0;
      }

      protected void InitAll0X32( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         InitializeNonKey0X32( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443431", true, true);
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
         context.AddJavascriptSource("sgusuarioopciones.js", "?202281811443431", false, true);
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
         edtUsuCod_Internalname = "USUCOD";
         edtUsuNom_Internalname = "USUNOM";
         chkUsuPedPrecio_Internalname = "USUPEDPRECIO";
         chkUsuPedDscto_Internalname = "USUPEDDSCTO";
         chkUsuPedStock_Internalname = "USUPEDSTOCK";
         chkUsuPedVend_Internalname = "USUPEDVEND";
         chkUsuPedCond_Internalname = "USUPEDCOND";
         chkUsuPedList_Internalname = "USUPEDLIST";
         edtUsuPedMon_Internalname = "USUPEDMON";
         edtUsuMosBanCod_Internalname = "USUMOSBANCOD";
         edtUsuMosCBCod_Internalname = "USUMOSCBCOD";
         edtUsuMosConcepto_Internalname = "USUMOSCONCEPTO";
         edtUsuMosConceptoDsc_Internalname = "USUMOSCONCEPTODSC";
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
         Form.Caption = "SGUSUARIOOPCIONES";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtUsuMosConceptoDsc_Jsonclick = "";
         edtUsuMosConceptoDsc_Enabled = 0;
         edtUsuMosConcepto_Jsonclick = "";
         edtUsuMosConcepto_Enabled = 1;
         edtUsuMosCBCod_Jsonclick = "";
         edtUsuMosCBCod_Enabled = 1;
         edtUsuMosBanCod_Jsonclick = "";
         edtUsuMosBanCod_Enabled = 1;
         edtUsuPedMon_Jsonclick = "";
         edtUsuPedMon_Enabled = 1;
         chkUsuPedList.Enabled = 1;
         chkUsuPedCond.Enabled = 1;
         chkUsuPedVend.Enabled = 1;
         chkUsuPedStock.Enabled = 1;
         chkUsuPedDscto.Enabled = 1;
         chkUsuPedPrecio.Enabled = 1;
         edtUsuNom_Jsonclick = "";
         edtUsuNom_Enabled = 1;
         edtUsuCod_Jsonclick = "";
         edtUsuCod_Enabled = 1;
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
         chkUsuPedPrecio.Name = "USUPEDPRECIO";
         chkUsuPedPrecio.WebTags = "";
         chkUsuPedPrecio.Caption = "";
         AssignProp("", false, chkUsuPedPrecio_Internalname, "TitleCaption", chkUsuPedPrecio.Caption, true);
         chkUsuPedPrecio.CheckedValue = "0";
         A2027UsuPedPrecio = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2027UsuPedPrecio), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.Str( (decimal)(A2027UsuPedPrecio), 1, 0));
         chkUsuPedDscto.Name = "USUPEDDSCTO";
         chkUsuPedDscto.WebTags = "";
         chkUsuPedDscto.Caption = "";
         AssignProp("", false, chkUsuPedDscto_Internalname, "TitleCaption", chkUsuPedDscto.Caption, true);
         chkUsuPedDscto.CheckedValue = "0";
         A2023UsuPedDscto = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2023UsuPedDscto), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2023UsuPedDscto", StringUtil.Str( (decimal)(A2023UsuPedDscto), 1, 0));
         chkUsuPedStock.Name = "USUPEDSTOCK";
         chkUsuPedStock.WebTags = "";
         chkUsuPedStock.Caption = "";
         AssignProp("", false, chkUsuPedStock_Internalname, "TitleCaption", chkUsuPedStock.Caption, true);
         chkUsuPedStock.CheckedValue = "0";
         A2028UsuPedStock = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2028UsuPedStock), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2028UsuPedStock", StringUtil.Str( (decimal)(A2028UsuPedStock), 1, 0));
         chkUsuPedVend.Name = "USUPEDVEND";
         chkUsuPedVend.WebTags = "";
         chkUsuPedVend.Caption = "";
         AssignProp("", false, chkUsuPedVend_Internalname, "TitleCaption", chkUsuPedVend.Caption, true);
         chkUsuPedVend.CheckedValue = "0";
         A2029UsuPedVend = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2029UsuPedVend), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2029UsuPedVend", StringUtil.Str( (decimal)(A2029UsuPedVend), 1, 0));
         chkUsuPedCond.Name = "USUPEDCOND";
         chkUsuPedCond.WebTags = "";
         chkUsuPedCond.Caption = "";
         AssignProp("", false, chkUsuPedCond_Internalname, "TitleCaption", chkUsuPedCond.Caption, true);
         chkUsuPedCond.CheckedValue = "0";
         A2022UsuPedCond = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2022UsuPedCond), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2022UsuPedCond", StringUtil.Str( (decimal)(A2022UsuPedCond), 1, 0));
         chkUsuPedList.Name = "USUPEDLIST";
         chkUsuPedList.WebTags = "";
         chkUsuPedList.Caption = "";
         AssignProp("", false, chkUsuPedList_Internalname, "TitleCaption", chkUsuPedList.Caption, true);
         chkUsuPedList.CheckedValue = "0";
         A2024UsuPedList = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2024UsuPedList), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A2024UsuPedList", StringUtil.Str( (decimal)(A2024UsuPedList), 1, 0));
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtUsuNom_Internalname;
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

      public void Valid_Usucod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A2027UsuPedPrecio = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2027UsuPedPrecio), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2023UsuPedDscto = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2023UsuPedDscto), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2028UsuPedStock = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2028UsuPedStock), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2029UsuPedVend = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2029UsuPedVend), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2022UsuPedCond = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2022UsuPedCond), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A2024UsuPedList = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A2024UsuPedList), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         /*  Sending validation outputs */
         AssignAttri("", false, "A2019UsuNom", StringUtil.RTrim( A2019UsuNom));
         AssignAttri("", false, "A2027UsuPedPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2027UsuPedPrecio), 1, 0, ".", "")));
         AssignAttri("", false, "A2023UsuPedDscto", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2023UsuPedDscto), 1, 0, ".", "")));
         AssignAttri("", false, "A2028UsuPedStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2028UsuPedStock), 1, 0, ".", "")));
         AssignAttri("", false, "A2029UsuPedVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2029UsuPedVend), 1, 0, ".", "")));
         AssignAttri("", false, "A2022UsuPedCond", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2022UsuPedCond), 1, 0, ".", "")));
         AssignAttri("", false, "A2024UsuPedList", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2024UsuPedList), 1, 0, ".", "")));
         AssignAttri("", false, "A2026UsuPedMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2026UsuPedMon), 6, 0, ".", "")));
         AssignAttri("", false, "A2016UsuMosBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2016UsuMosBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A2017UsuMosCBCod", StringUtil.RTrim( A2017UsuMosCBCod));
         AssignAttri("", false, "A350UsuMosConcepto", StringUtil.LTrim( StringUtil.NToC( (decimal)(A350UsuMosConcepto), 6, 0, ".", "")));
         AssignAttri("", false, "A2018UsuMosConceptoDsc", StringUtil.RTrim( A2018UsuMosConceptoDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z2019UsuNom", StringUtil.RTrim( Z2019UsuNom));
         GxWebStd.gx_hidden_field( context, "Z2027UsuPedPrecio", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2027UsuPedPrecio), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2023UsuPedDscto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2023UsuPedDscto), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2028UsuPedStock", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2028UsuPedStock), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2029UsuPedVend", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2029UsuPedVend), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2022UsuPedCond", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2022UsuPedCond), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2024UsuPedList", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2024UsuPedList), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2026UsuPedMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2026UsuPedMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2016UsuMosBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2016UsuMosBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2017UsuMosCBCod", StringUtil.RTrim( Z2017UsuMosCBCod));
         GxWebStd.gx_hidden_field( context, "Z350UsuMosConcepto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z350UsuMosConcepto), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2018UsuMosConceptoDsc", StringUtil.RTrim( Z2018UsuMosConceptoDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Usumosbancod( )
      {
         n2016UsuMosBanCod = false;
         /* Using cursor T000X25 */
         pr_default.execute(23, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "USUMOSBANCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
            }
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usumoscbcod( )
      {
         n2016UsuMosBanCod = false;
         n2017UsuMosCBCod = false;
         /* Using cursor T000X26 */
         pr_default.execute(24, new Object[] {n2016UsuMosBanCod, A2016UsuMosBanCod, n2017UsuMosCBCod, A2017UsuMosCBCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A2016UsuMosBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A2017UsuMosCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Banco'.", "ForeignKeyNotFound", 1, "USUMOSCBCOD");
               AnyError = 1;
               GX_FocusControl = edtUsuMosBanCod_Internalname;
            }
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Usumosconcepto( )
      {
         n350UsuMosConcepto = false;
         /* Using cursor T000X17 */
         pr_default.execute(15, new Object[] {n350UsuMosConcepto, A350UsuMosConcepto});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A350UsuMosConcepto) ) )
            {
               GX_msglist.addItem("No existe 'Sub Banco Mostrador'.", "ForeignKeyNotFound", 1, "USUMOSCONCEPTO");
               AnyError = 1;
               GX_FocusControl = edtUsuMosConcepto_Internalname;
            }
         }
         A2018UsuMosConceptoDsc = T000X17_A2018UsuMosConceptoDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2018UsuMosConceptoDsc", StringUtil.RTrim( A2018UsuMosConceptoDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUCOD",",oparms:[{av:'A2019UsuNom',fld:'USUNOM',pic:''},{av:'A2026UsuPedMon',fld:'USUPEDMON',pic:'ZZZZZ9'},{av:'A2016UsuMosBanCod',fld:'USUMOSBANCOD',pic:'ZZZZZ9'},{av:'A2017UsuMosCBCod',fld:'USUMOSCBCOD',pic:''},{av:'A350UsuMosConcepto',fld:'USUMOSCONCEPTO',pic:'ZZZZZ9'},{av:'A2018UsuMosConceptoDsc',fld:'USUMOSCONCEPTODSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{av:'Z2019UsuNom'},{av:'Z2027UsuPedPrecio'},{av:'Z2023UsuPedDscto'},{av:'Z2028UsuPedStock'},{av:'Z2029UsuPedVend'},{av:'Z2022UsuPedCond'},{av:'Z2024UsuPedList'},{av:'Z2026UsuPedMon'},{av:'Z2016UsuMosBanCod'},{av:'Z2017UsuMosCBCod'},{av:'Z350UsuMosConcepto'},{av:'Z2018UsuMosConceptoDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUMOSBANCOD","{handler:'Valid_Usumosbancod',iparms:[{av:'A2016UsuMosBanCod',fld:'USUMOSBANCOD',pic:'ZZZZZ9'},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUMOSBANCOD",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUMOSCBCOD","{handler:'Valid_Usumoscbcod',iparms:[{av:'A2016UsuMosBanCod',fld:'USUMOSBANCOD',pic:'ZZZZZ9'},{av:'A2017UsuMosCBCod',fld:'USUMOSCBCOD',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUMOSCBCOD",",oparms:[{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
         setEventMetadata("VALID_USUMOSCONCEPTO","{handler:'Valid_Usumosconcepto',iparms:[{av:'A350UsuMosConcepto',fld:'USUMOSCONCEPTO',pic:'ZZZZZ9'},{av:'A2018UsuMosConceptoDsc',fld:'USUMOSCONCEPTODSC',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]");
         setEventMetadata("VALID_USUMOSCONCEPTO",",oparms:[{av:'A2018UsuMosConceptoDsc',fld:'USUMOSCONCEPTODSC',pic:''},{av:'A2027UsuPedPrecio',fld:'USUPEDPRECIO',pic:'9'},{av:'A2023UsuPedDscto',fld:'USUPEDDSCTO',pic:'9'},{av:'A2028UsuPedStock',fld:'USUPEDSTOCK',pic:'9'},{av:'A2029UsuPedVend',fld:'USUPEDVEND',pic:'9'},{av:'A2022UsuPedCond',fld:'USUPEDCOND',pic:'9'},{av:'A2024UsuPedList',fld:'USUPEDLIST',pic:'9'}]}");
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         Z2019UsuNom = "";
         Z2017UsuMosCBCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2017UsuMosCBCod = "";
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
         A348UsuCod = "";
         A2019UsuNom = "";
         A2018UsuMosConceptoDsc = "";
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
         Z2018UsuMosConceptoDsc = "";
         T000X7_A348UsuCod = new string[] {""} ;
         T000X7_A2019UsuNom = new string[] {""} ;
         T000X7_A2027UsuPedPrecio = new short[1] ;
         T000X7_A2023UsuPedDscto = new short[1] ;
         T000X7_A2028UsuPedStock = new short[1] ;
         T000X7_A2029UsuPedVend = new short[1] ;
         T000X7_A2022UsuPedCond = new short[1] ;
         T000X7_A2024UsuPedList = new short[1] ;
         T000X7_A2026UsuPedMon = new int[1] ;
         T000X7_n2026UsuPedMon = new bool[] {false} ;
         T000X7_A2018UsuMosConceptoDsc = new string[] {""} ;
         T000X7_A2016UsuMosBanCod = new int[1] ;
         T000X7_n2016UsuMosBanCod = new bool[] {false} ;
         T000X7_A2017UsuMosCBCod = new string[] {""} ;
         T000X7_n2017UsuMosCBCod = new bool[] {false} ;
         T000X7_A350UsuMosConcepto = new int[1] ;
         T000X7_n350UsuMosConcepto = new bool[] {false} ;
         T000X4_A2016UsuMosBanCod = new int[1] ;
         T000X4_n2016UsuMosBanCod = new bool[] {false} ;
         T000X5_A2016UsuMosBanCod = new int[1] ;
         T000X5_n2016UsuMosBanCod = new bool[] {false} ;
         T000X6_A2018UsuMosConceptoDsc = new string[] {""} ;
         T000X8_A2016UsuMosBanCod = new int[1] ;
         T000X8_n2016UsuMosBanCod = new bool[] {false} ;
         T000X9_A2016UsuMosBanCod = new int[1] ;
         T000X9_n2016UsuMosBanCod = new bool[] {false} ;
         T000X10_A2018UsuMosConceptoDsc = new string[] {""} ;
         T000X11_A348UsuCod = new string[] {""} ;
         T000X3_A348UsuCod = new string[] {""} ;
         T000X3_A2019UsuNom = new string[] {""} ;
         T000X3_A2027UsuPedPrecio = new short[1] ;
         T000X3_A2023UsuPedDscto = new short[1] ;
         T000X3_A2028UsuPedStock = new short[1] ;
         T000X3_A2029UsuPedVend = new short[1] ;
         T000X3_A2022UsuPedCond = new short[1] ;
         T000X3_A2024UsuPedList = new short[1] ;
         T000X3_A2026UsuPedMon = new int[1] ;
         T000X3_n2026UsuPedMon = new bool[] {false} ;
         T000X3_A2016UsuMosBanCod = new int[1] ;
         T000X3_n2016UsuMosBanCod = new bool[] {false} ;
         T000X3_A2017UsuMosCBCod = new string[] {""} ;
         T000X3_n2017UsuMosCBCod = new bool[] {false} ;
         T000X3_A350UsuMosConcepto = new int[1] ;
         T000X3_n350UsuMosConcepto = new bool[] {false} ;
         sMode32 = "";
         T000X12_A348UsuCod = new string[] {""} ;
         T000X13_A348UsuCod = new string[] {""} ;
         T000X2_A348UsuCod = new string[] {""} ;
         T000X2_A2019UsuNom = new string[] {""} ;
         T000X2_A2027UsuPedPrecio = new short[1] ;
         T000X2_A2023UsuPedDscto = new short[1] ;
         T000X2_A2028UsuPedStock = new short[1] ;
         T000X2_A2029UsuPedVend = new short[1] ;
         T000X2_A2022UsuPedCond = new short[1] ;
         T000X2_A2024UsuPedList = new short[1] ;
         T000X2_A2026UsuPedMon = new int[1] ;
         T000X2_n2026UsuPedMon = new bool[] {false} ;
         T000X2_A2016UsuMosBanCod = new int[1] ;
         T000X2_n2016UsuMosBanCod = new bool[] {false} ;
         T000X2_A2017UsuMosCBCod = new string[] {""} ;
         T000X2_n2017UsuMosCBCod = new bool[] {false} ;
         T000X2_A350UsuMosConcepto = new int[1] ;
         T000X2_n350UsuMosConcepto = new bool[] {false} ;
         T000X17_A2018UsuMosConceptoDsc = new string[] {""} ;
         T000X18_A2237SGNotificacionID = new long[1] ;
         T000X18_A2245SGNotificacionDetID = new short[1] ;
         T000X19_A2237SGNotificacionID = new long[1] ;
         T000X20_A348UsuCod = new string[] {""} ;
         T000X20_A149TipCod = new string[] {""} ;
         T000X20_A351UsuSerDet = new string[] {""} ;
         T000X21_A348UsuCod = new string[] {""} ;
         T000X21_A346ObjCod = new int[1] ;
         T000X22_A348UsuCod = new string[] {""} ;
         T000X22_A342SGMenuPrograma = new string[] {""} ;
         T000X22_A343SGMenuNiv1ID = new string[] {""} ;
         T000X23_A348UsuCod = new string[] {""} ;
         T000X23_A349UsuAlmCod = new int[1] ;
         T000X24_A348UsuCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ348UsuCod = "";
         ZZ2019UsuNom = "";
         ZZ2017UsuMosCBCod = "";
         ZZ2018UsuMosConceptoDsc = "";
         T000X25_A2016UsuMosBanCod = new int[1] ;
         T000X25_n2016UsuMosBanCod = new bool[] {false} ;
         T000X26_A2016UsuMosBanCod = new int[1] ;
         T000X26_n2016UsuMosBanCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioopciones__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioopciones__default(),
            new Object[][] {
                new Object[] {
               T000X2_A348UsuCod, T000X2_A2019UsuNom, T000X2_A2027UsuPedPrecio, T000X2_A2023UsuPedDscto, T000X2_A2028UsuPedStock, T000X2_A2029UsuPedVend, T000X2_A2022UsuPedCond, T000X2_A2024UsuPedList, T000X2_A2026UsuPedMon, T000X2_n2026UsuPedMon,
               T000X2_A2016UsuMosBanCod, T000X2_n2016UsuMosBanCod, T000X2_A2017UsuMosCBCod, T000X2_n2017UsuMosCBCod, T000X2_A350UsuMosConcepto, T000X2_n350UsuMosConcepto
               }
               , new Object[] {
               T000X3_A348UsuCod, T000X3_A2019UsuNom, T000X3_A2027UsuPedPrecio, T000X3_A2023UsuPedDscto, T000X3_A2028UsuPedStock, T000X3_A2029UsuPedVend, T000X3_A2022UsuPedCond, T000X3_A2024UsuPedList, T000X3_A2026UsuPedMon, T000X3_n2026UsuPedMon,
               T000X3_A2016UsuMosBanCod, T000X3_n2016UsuMosBanCod, T000X3_A2017UsuMosCBCod, T000X3_n2017UsuMosCBCod, T000X3_A350UsuMosConcepto, T000X3_n350UsuMosConcepto
               }
               , new Object[] {
               T000X4_A2016UsuMosBanCod
               }
               , new Object[] {
               T000X5_A2016UsuMosBanCod
               }
               , new Object[] {
               T000X6_A2018UsuMosConceptoDsc
               }
               , new Object[] {
               T000X7_A348UsuCod, T000X7_A2019UsuNom, T000X7_A2027UsuPedPrecio, T000X7_A2023UsuPedDscto, T000X7_A2028UsuPedStock, T000X7_A2029UsuPedVend, T000X7_A2022UsuPedCond, T000X7_A2024UsuPedList, T000X7_A2026UsuPedMon, T000X7_n2026UsuPedMon,
               T000X7_A2018UsuMosConceptoDsc, T000X7_A2016UsuMosBanCod, T000X7_n2016UsuMosBanCod, T000X7_A2017UsuMosCBCod, T000X7_n2017UsuMosCBCod, T000X7_A350UsuMosConcepto, T000X7_n350UsuMosConcepto
               }
               , new Object[] {
               T000X8_A2016UsuMosBanCod
               }
               , new Object[] {
               T000X9_A2016UsuMosBanCod
               }
               , new Object[] {
               T000X10_A2018UsuMosConceptoDsc
               }
               , new Object[] {
               T000X11_A348UsuCod
               }
               , new Object[] {
               T000X12_A348UsuCod
               }
               , new Object[] {
               T000X13_A348UsuCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000X17_A2018UsuMosConceptoDsc
               }
               , new Object[] {
               T000X18_A2237SGNotificacionID, T000X18_A2245SGNotificacionDetID
               }
               , new Object[] {
               T000X19_A2237SGNotificacionID
               }
               , new Object[] {
               T000X20_A348UsuCod, T000X20_A149TipCod, T000X20_A351UsuSerDet
               }
               , new Object[] {
               T000X21_A348UsuCod, T000X21_A346ObjCod
               }
               , new Object[] {
               T000X22_A348UsuCod, T000X22_A342SGMenuPrograma, T000X22_A343SGMenuNiv1ID
               }
               , new Object[] {
               T000X23_A348UsuCod, T000X23_A349UsuAlmCod
               }
               , new Object[] {
               T000X24_A348UsuCod
               }
               , new Object[] {
               T000X25_A2016UsuMosBanCod
               }
               , new Object[] {
               T000X26_A2016UsuMosBanCod
               }
            }
         );
      }

      private short Z2027UsuPedPrecio ;
      private short Z2023UsuPedDscto ;
      private short Z2028UsuPedStock ;
      private short Z2029UsuPedVend ;
      private short Z2022UsuPedCond ;
      private short Z2024UsuPedList ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2027UsuPedPrecio ;
      private short A2023UsuPedDscto ;
      private short A2028UsuPedStock ;
      private short A2029UsuPedVend ;
      private short A2022UsuPedCond ;
      private short A2024UsuPedList ;
      private short GX_JID ;
      private short RcdFound32 ;
      private short nIsDirty_32 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2027UsuPedPrecio ;
      private short ZZ2023UsuPedDscto ;
      private short ZZ2028UsuPedStock ;
      private short ZZ2029UsuPedVend ;
      private short ZZ2022UsuPedCond ;
      private short ZZ2024UsuPedList ;
      private int Z2026UsuPedMon ;
      private int Z2016UsuMosBanCod ;
      private int Z350UsuMosConcepto ;
      private int A2016UsuMosBanCod ;
      private int A350UsuMosConcepto ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtUsuNom_Enabled ;
      private int A2026UsuPedMon ;
      private int edtUsuPedMon_Enabled ;
      private int edtUsuMosBanCod_Enabled ;
      private int edtUsuMosCBCod_Enabled ;
      private int edtUsuMosConcepto_Enabled ;
      private int edtUsuMosConceptoDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2026UsuPedMon ;
      private int ZZ2016UsuMosBanCod ;
      private int ZZ350UsuMosConcepto ;
      private string sPrefix ;
      private string Z348UsuCod ;
      private string Z2019UsuNom ;
      private string Z2017UsuMosCBCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2017UsuMosCBCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUsuCod_Internalname ;
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
      private string A348UsuCod ;
      private string edtUsuCod_Jsonclick ;
      private string edtUsuNom_Internalname ;
      private string A2019UsuNom ;
      private string edtUsuNom_Jsonclick ;
      private string chkUsuPedPrecio_Internalname ;
      private string chkUsuPedDscto_Internalname ;
      private string chkUsuPedStock_Internalname ;
      private string chkUsuPedVend_Internalname ;
      private string chkUsuPedCond_Internalname ;
      private string chkUsuPedList_Internalname ;
      private string edtUsuPedMon_Internalname ;
      private string edtUsuPedMon_Jsonclick ;
      private string edtUsuMosBanCod_Internalname ;
      private string edtUsuMosBanCod_Jsonclick ;
      private string edtUsuMosCBCod_Internalname ;
      private string edtUsuMosCBCod_Jsonclick ;
      private string edtUsuMosConcepto_Internalname ;
      private string edtUsuMosConcepto_Jsonclick ;
      private string edtUsuMosConceptoDsc_Internalname ;
      private string A2018UsuMosConceptoDsc ;
      private string edtUsuMosConceptoDsc_Jsonclick ;
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
      private string Z2018UsuMosConceptoDsc ;
      private string sMode32 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ348UsuCod ;
      private string ZZ2019UsuNom ;
      private string ZZ2017UsuMosCBCod ;
      private string ZZ2018UsuMosConceptoDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n2016UsuMosBanCod ;
      private bool n2017UsuMosCBCod ;
      private bool n350UsuMosConcepto ;
      private bool wbErr ;
      private bool n2026UsuPedMon ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkUsuPedPrecio ;
      private GXCheckbox chkUsuPedDscto ;
      private GXCheckbox chkUsuPedStock ;
      private GXCheckbox chkUsuPedVend ;
      private GXCheckbox chkUsuPedCond ;
      private GXCheckbox chkUsuPedList ;
      private IDataStoreProvider pr_default ;
      private string[] T000X7_A348UsuCod ;
      private string[] T000X7_A2019UsuNom ;
      private short[] T000X7_A2027UsuPedPrecio ;
      private short[] T000X7_A2023UsuPedDscto ;
      private short[] T000X7_A2028UsuPedStock ;
      private short[] T000X7_A2029UsuPedVend ;
      private short[] T000X7_A2022UsuPedCond ;
      private short[] T000X7_A2024UsuPedList ;
      private int[] T000X7_A2026UsuPedMon ;
      private bool[] T000X7_n2026UsuPedMon ;
      private string[] T000X7_A2018UsuMosConceptoDsc ;
      private int[] T000X7_A2016UsuMosBanCod ;
      private bool[] T000X7_n2016UsuMosBanCod ;
      private string[] T000X7_A2017UsuMosCBCod ;
      private bool[] T000X7_n2017UsuMosCBCod ;
      private int[] T000X7_A350UsuMosConcepto ;
      private bool[] T000X7_n350UsuMosConcepto ;
      private int[] T000X4_A2016UsuMosBanCod ;
      private bool[] T000X4_n2016UsuMosBanCod ;
      private int[] T000X5_A2016UsuMosBanCod ;
      private bool[] T000X5_n2016UsuMosBanCod ;
      private string[] T000X6_A2018UsuMosConceptoDsc ;
      private int[] T000X8_A2016UsuMosBanCod ;
      private bool[] T000X8_n2016UsuMosBanCod ;
      private int[] T000X9_A2016UsuMosBanCod ;
      private bool[] T000X9_n2016UsuMosBanCod ;
      private string[] T000X10_A2018UsuMosConceptoDsc ;
      private string[] T000X11_A348UsuCod ;
      private string[] T000X3_A348UsuCod ;
      private string[] T000X3_A2019UsuNom ;
      private short[] T000X3_A2027UsuPedPrecio ;
      private short[] T000X3_A2023UsuPedDscto ;
      private short[] T000X3_A2028UsuPedStock ;
      private short[] T000X3_A2029UsuPedVend ;
      private short[] T000X3_A2022UsuPedCond ;
      private short[] T000X3_A2024UsuPedList ;
      private int[] T000X3_A2026UsuPedMon ;
      private bool[] T000X3_n2026UsuPedMon ;
      private int[] T000X3_A2016UsuMosBanCod ;
      private bool[] T000X3_n2016UsuMosBanCod ;
      private string[] T000X3_A2017UsuMosCBCod ;
      private bool[] T000X3_n2017UsuMosCBCod ;
      private int[] T000X3_A350UsuMosConcepto ;
      private bool[] T000X3_n350UsuMosConcepto ;
      private string[] T000X12_A348UsuCod ;
      private string[] T000X13_A348UsuCod ;
      private string[] T000X2_A348UsuCod ;
      private string[] T000X2_A2019UsuNom ;
      private short[] T000X2_A2027UsuPedPrecio ;
      private short[] T000X2_A2023UsuPedDscto ;
      private short[] T000X2_A2028UsuPedStock ;
      private short[] T000X2_A2029UsuPedVend ;
      private short[] T000X2_A2022UsuPedCond ;
      private short[] T000X2_A2024UsuPedList ;
      private int[] T000X2_A2026UsuPedMon ;
      private bool[] T000X2_n2026UsuPedMon ;
      private int[] T000X2_A2016UsuMosBanCod ;
      private bool[] T000X2_n2016UsuMosBanCod ;
      private string[] T000X2_A2017UsuMosCBCod ;
      private bool[] T000X2_n2017UsuMosCBCod ;
      private int[] T000X2_A350UsuMosConcepto ;
      private bool[] T000X2_n350UsuMosConcepto ;
      private string[] T000X17_A2018UsuMosConceptoDsc ;
      private long[] T000X18_A2237SGNotificacionID ;
      private short[] T000X18_A2245SGNotificacionDetID ;
      private long[] T000X19_A2237SGNotificacionID ;
      private string[] T000X20_A348UsuCod ;
      private string[] T000X20_A149TipCod ;
      private string[] T000X20_A351UsuSerDet ;
      private string[] T000X21_A348UsuCod ;
      private int[] T000X21_A346ObjCod ;
      private string[] T000X22_A348UsuCod ;
      private string[] T000X22_A342SGMenuPrograma ;
      private string[] T000X22_A343SGMenuNiv1ID ;
      private string[] T000X23_A348UsuCod ;
      private int[] T000X23_A349UsuAlmCod ;
      private string[] T000X24_A348UsuCod ;
      private int[] T000X25_A2016UsuMosBanCod ;
      private bool[] T000X25_n2016UsuMosBanCod ;
      private int[] T000X26_A2016UsuMosBanCod ;
      private bool[] T000X26_n2016UsuMosBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgusuarioopciones__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuarioopciones__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000X7;
        prmT000X7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X4;
        prmT000X4 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000X5;
        prmT000X5 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000X6;
        prmT000X6 = new Object[] {
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000X8;
        prmT000X8 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000X9;
        prmT000X9 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000X10;
        prmT000X10 = new Object[] {
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000X11;
        prmT000X11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X3;
        prmT000X3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X12;
        prmT000X12 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X13;
        prmT000X13 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X2;
        prmT000X2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X14;
        prmT000X14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuPedPrecio",GXType.Int16,1,0) ,
        new ParDef("@UsuPedDscto",GXType.Int16,1,0) ,
        new ParDef("@UsuPedStock",GXType.Int16,1,0) ,
        new ParDef("@UsuPedVend",GXType.Int16,1,0) ,
        new ParDef("@UsuPedCond",GXType.Int16,1,0) ,
        new ParDef("@UsuPedList",GXType.Int16,1,0) ,
        new ParDef("@UsuPedMon",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000X15;
        prmT000X15 = new Object[] {
        new ParDef("@UsuNom",GXType.NChar,100,0) ,
        new ParDef("@UsuPedPrecio",GXType.Int16,1,0) ,
        new ParDef("@UsuPedDscto",GXType.Int16,1,0) ,
        new ParDef("@UsuPedStock",GXType.Int16,1,0) ,
        new ParDef("@UsuPedVend",GXType.Int16,1,0) ,
        new ParDef("@UsuPedCond",GXType.Int16,1,0) ,
        new ParDef("@UsuPedList",GXType.Int16,1,0) ,
        new ParDef("@UsuPedMon",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X16;
        prmT000X16 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X18;
        prmT000X18 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X19;
        prmT000X19 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X20;
        prmT000X20 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X21;
        prmT000X21 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X22;
        prmT000X22 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X23;
        prmT000X23 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000X24;
        prmT000X24 = new Object[] {
        };
        Object[] prmT000X25;
        prmT000X25 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000X26;
        prmT000X26 = new Object[] {
        new ParDef("@UsuMosBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@UsuMosCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000X17;
        prmT000X17 = new Object[] {
        new ParDef("@UsuMosConcepto",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000X2", "SELECT [UsuCod], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuPedMon], [UsuMosBanCod] AS UsuMosBanCod, [UsuMosCBCod] AS UsuMosCBCod, [UsuMosConcepto] AS UsuMosConcepto FROM [SGUSUARIOS] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X3", "SELECT [UsuCod], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuPedMon], [UsuMosBanCod] AS UsuMosBanCod, [UsuMosCBCod] AS UsuMosCBCod, [UsuMosConcepto] AS UsuMosConcepto FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X4", "SELECT [BanCod] AS UsuMosBanCod FROM [TSBANCOS] WHERE [BanCod] = @UsuMosBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X5", "SELECT [BanCod] AS UsuMosBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @UsuMosBanCod AND [CBCod] = @UsuMosCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X6", "SELECT [ConBDsc] AS UsuMosConceptoDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @UsuMosConcepto ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X7", "SELECT TM1.[UsuCod], TM1.[UsuNom], TM1.[UsuPedPrecio], TM1.[UsuPedDscto], TM1.[UsuPedStock], TM1.[UsuPedVend], TM1.[UsuPedCond], TM1.[UsuPedList], TM1.[UsuPedMon], T2.[ConBDsc] AS UsuMosConceptoDsc, TM1.[UsuMosBanCod] AS UsuMosBanCod, TM1.[UsuMosCBCod] AS UsuMosCBCod, TM1.[UsuMosConcepto] AS UsuMosConcepto FROM ([SGUSUARIOS] TM1 LEFT JOIN [TSCONCEPTOBANCOS] T2 ON T2.[ConBCod] = TM1.[UsuMosConcepto]) WHERE TM1.[UsuCod] = @UsuCod ORDER BY TM1.[UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X8", "SELECT [BanCod] AS UsuMosBanCod FROM [TSBANCOS] WHERE [BanCod] = @UsuMosBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X9", "SELECT [BanCod] AS UsuMosBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @UsuMosBanCod AND [CBCod] = @UsuMosCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X10", "SELECT [ConBDsc] AS UsuMosConceptoDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @UsuMosConcepto ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X11", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X12", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] > @UsuCod) ORDER BY [UsuCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X13", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] < @UsuCod) ORDER BY [UsuCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X14", "INSERT INTO [SGUSUARIOS]([UsuCod], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuPedMon], [UsuMosBanCod], [UsuMosCBCod], [UsuMosConcepto], [UsuPas], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuVend], [UsuSerie5], [UsuReqADM], [UsuTieCod], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [AreCod], [UsuSRet], [UsuDep], [UsuVendAut]) VALUES(@UsuCod, @UsuNom, @UsuPedPrecio, @UsuPedDscto, @UsuPedStock, @UsuPedVend, @UsuPedCond, @UsuPedList, @UsuPedMon, @UsuMosBanCod, @UsuMosCBCod, @UsuMosConcepto, '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', '', convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), '', convert(int, 0), '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT000X14)
           ,new CursorDef("T000X15", "UPDATE [SGUSUARIOS] SET [UsuNom]=@UsuNom, [UsuPedPrecio]=@UsuPedPrecio, [UsuPedDscto]=@UsuPedDscto, [UsuPedStock]=@UsuPedStock, [UsuPedVend]=@UsuPedVend, [UsuPedCond]=@UsuPedCond, [UsuPedList]=@UsuPedList, [UsuPedMon]=@UsuPedMon, [UsuMosBanCod]=@UsuMosBanCod, [UsuMosCBCod]=@UsuMosCBCod, [UsuMosConcepto]=@UsuMosConcepto  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT000X15)
           ,new CursorDef("T000X16", "DELETE FROM [SGUSUARIOS]  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT000X16)
           ,new CursorDef("T000X17", "SELECT [ConBDsc] AS UsuMosConceptoDsc FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @UsuMosConcepto ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X18", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionDetUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X19", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X20", "SELECT TOP 1 [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X21", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X22", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X23", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X24", "SELECT [UsuCod] FROM [SGUSUARIOS] ORDER BY [UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000X24,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X25", "SELECT [BanCod] AS UsuMosBanCod FROM [TSBANCOS] WHERE [BanCod] = @UsuMosBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X26", "SELECT [BanCod] AS UsuMosBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @UsuMosBanCod AND [CBCod] = @UsuMosCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X26,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 20);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((int[]) buf[14])[0] = rslt.getInt(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((int[]) buf[10])[0] = rslt.getInt(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((string[]) buf[12])[0] = rslt.getString(11, 20);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((int[]) buf[14])[0] = rslt.getInt(12);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((bool[]) buf[9])[0] = rslt.wasNull(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 100);
              ((int[]) buf[11])[0] = rslt.getInt(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((string[]) buf[13])[0] = rslt.getString(12, 20);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((int[]) buf[15])[0] = rslt.getInt(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
