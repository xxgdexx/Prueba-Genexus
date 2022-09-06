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
   public class sgobjetos : GXDataArea
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
            Form.Meta.addItem("description", "SGOBJETOS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtObjCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgobjetos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgobjetos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGOBJETOS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGOBJETOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGOBJETOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A346ObjCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtObjCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A346ObjCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A346ObjCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjDsc_Internalname, "Objeto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjDsc_Internalname, StringUtil.RTrim( A1379ObjDsc), StringUtil.RTrim( context.localUtil.Format( A1379ObjDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjUrl_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjUrl_Internalname, "URL", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjUrl_Internalname, StringUtil.RTrim( A1388ObjUrl), StringUtil.RTrim( context.localUtil.Format( A1388ObjUrl, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjUrl_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjUrl_Enabled, 0, "text", "", 31, "chr", 1, "row", 31, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1385ObjSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtObjSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1385ObjSts), "9") : context.localUtil.Format( (decimal)(A1385ObjSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjMod_Internalname, "Modulo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjMod_Internalname, StringUtil.RTrim( A1383ObjMod), StringUtil.RTrim( context.localUtil.Format( A1383ObjMod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjMod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjMod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjMenuOrden_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjMenuOrden_Internalname, "Menu Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjMenuOrden_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1382ObjMenuOrden), 6, 0, ".", "")), StringUtil.LTrim( ((edtObjMenuOrden_Enabled!=0) ? context.localUtil.Format( (decimal)(A1382ObjMenuOrden), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1382ObjMenuOrden), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjMenuOrden_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjMenuOrden_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjMenuDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjMenuDsc_Internalname, "Menu", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjMenuDsc_Internalname, A1381ObjMenuDsc, StringUtil.RTrim( context.localUtil.Format( A1381ObjMenuDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjMenuDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjMenuDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGOBJETOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOBJETOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGOBJETOS.htm");
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
            Z346ObjCod = (int)(context.localUtil.CToN( cgiGet( "Z346ObjCod"), ".", ","));
            Z1379ObjDsc = cgiGet( "Z1379ObjDsc");
            Z1388ObjUrl = cgiGet( "Z1388ObjUrl");
            Z1385ObjSts = (short)(context.localUtil.CToN( cgiGet( "Z1385ObjSts"), ".", ","));
            Z1383ObjMod = cgiGet( "Z1383ObjMod");
            Z1382ObjMenuOrden = (int)(context.localUtil.CToN( cgiGet( "Z1382ObjMenuOrden"), ".", ","));
            Z1381ObjMenuDsc = cgiGet( "Z1381ObjMenuDsc");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJCOD");
               AnyError = 1;
               GX_FocusControl = edtObjCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A346ObjCod = 0;
               AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
            }
            else
            {
               A346ObjCod = (int)(context.localUtil.CToN( cgiGet( edtObjCod_Internalname), ".", ","));
               AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
            }
            A1379ObjDsc = cgiGet( edtObjDsc_Internalname);
            AssignAttri("", false, "A1379ObjDsc", A1379ObjDsc);
            A1388ObjUrl = cgiGet( edtObjUrl_Internalname);
            AssignAttri("", false, "A1388ObjUrl", A1388ObjUrl);
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJSTS");
               AnyError = 1;
               GX_FocusControl = edtObjSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1385ObjSts = 0;
               AssignAttri("", false, "A1385ObjSts", StringUtil.Str( (decimal)(A1385ObjSts), 1, 0));
            }
            else
            {
               A1385ObjSts = (short)(context.localUtil.CToN( cgiGet( edtObjSts_Internalname), ".", ","));
               AssignAttri("", false, "A1385ObjSts", StringUtil.Str( (decimal)(A1385ObjSts), 1, 0));
            }
            A1383ObjMod = cgiGet( edtObjMod_Internalname);
            AssignAttri("", false, "A1383ObjMod", A1383ObjMod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjMenuOrden_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjMenuOrden_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJMENUORDEN");
               AnyError = 1;
               GX_FocusControl = edtObjMenuOrden_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1382ObjMenuOrden = 0;
               AssignAttri("", false, "A1382ObjMenuOrden", StringUtil.LTrimStr( (decimal)(A1382ObjMenuOrden), 6, 0));
            }
            else
            {
               A1382ObjMenuOrden = (int)(context.localUtil.CToN( cgiGet( edtObjMenuOrden_Internalname), ".", ","));
               AssignAttri("", false, "A1382ObjMenuOrden", StringUtil.LTrimStr( (decimal)(A1382ObjMenuOrden), 6, 0));
            }
            A1381ObjMenuDsc = cgiGet( edtObjMenuDsc_Internalname);
            AssignAttri("", false, "A1381ObjMenuDsc", A1381ObjMenuDsc);
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
               A346ObjCod = (int)(NumberUtil.Val( GetPar( "ObjCod"), "."));
               AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
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
               InitAll0Q26( ) ;
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
         DisableAttributes0Q26( ) ;
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

      protected void ResetCaption0Q0( )
      {
      }

      protected void ZM0Q26( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1379ObjDsc = T000Q3_A1379ObjDsc[0];
               Z1388ObjUrl = T000Q3_A1388ObjUrl[0];
               Z1385ObjSts = T000Q3_A1385ObjSts[0];
               Z1383ObjMod = T000Q3_A1383ObjMod[0];
               Z1382ObjMenuOrden = T000Q3_A1382ObjMenuOrden[0];
               Z1381ObjMenuDsc = T000Q3_A1381ObjMenuDsc[0];
            }
            else
            {
               Z1379ObjDsc = A1379ObjDsc;
               Z1388ObjUrl = A1388ObjUrl;
               Z1385ObjSts = A1385ObjSts;
               Z1383ObjMod = A1383ObjMod;
               Z1382ObjMenuOrden = A1382ObjMenuOrden;
               Z1381ObjMenuDsc = A1381ObjMenuDsc;
            }
         }
         if ( GX_JID == -1 )
         {
            Z346ObjCod = A346ObjCod;
            Z1379ObjDsc = A1379ObjDsc;
            Z1388ObjUrl = A1388ObjUrl;
            Z1385ObjSts = A1385ObjSts;
            Z1383ObjMod = A1383ObjMod;
            Z1382ObjMenuOrden = A1382ObjMenuOrden;
            Z1381ObjMenuDsc = A1381ObjMenuDsc;
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

      protected void Load0Q26( )
      {
         /* Using cursor T000Q4 */
         pr_default.execute(2, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound26 = 1;
            A1379ObjDsc = T000Q4_A1379ObjDsc[0];
            AssignAttri("", false, "A1379ObjDsc", A1379ObjDsc);
            A1388ObjUrl = T000Q4_A1388ObjUrl[0];
            AssignAttri("", false, "A1388ObjUrl", A1388ObjUrl);
            A1385ObjSts = T000Q4_A1385ObjSts[0];
            AssignAttri("", false, "A1385ObjSts", StringUtil.Str( (decimal)(A1385ObjSts), 1, 0));
            A1383ObjMod = T000Q4_A1383ObjMod[0];
            AssignAttri("", false, "A1383ObjMod", A1383ObjMod);
            A1382ObjMenuOrden = T000Q4_A1382ObjMenuOrden[0];
            AssignAttri("", false, "A1382ObjMenuOrden", StringUtil.LTrimStr( (decimal)(A1382ObjMenuOrden), 6, 0));
            A1381ObjMenuDsc = T000Q4_A1381ObjMenuDsc[0];
            AssignAttri("", false, "A1381ObjMenuDsc", A1381ObjMenuDsc);
            ZM0Q26( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0Q26( ) ;
      }

      protected void OnLoadActions0Q26( )
      {
      }

      protected void CheckExtendedTable0Q26( )
      {
         nIsDirty_26 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0Q26( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Q26( )
      {
         /* Using cursor T000Q5 */
         pr_default.execute(3, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Q3 */
         pr_default.execute(1, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q26( 1) ;
            RcdFound26 = 1;
            A346ObjCod = T000Q3_A346ObjCod[0];
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
            A1379ObjDsc = T000Q3_A1379ObjDsc[0];
            AssignAttri("", false, "A1379ObjDsc", A1379ObjDsc);
            A1388ObjUrl = T000Q3_A1388ObjUrl[0];
            AssignAttri("", false, "A1388ObjUrl", A1388ObjUrl);
            A1385ObjSts = T000Q3_A1385ObjSts[0];
            AssignAttri("", false, "A1385ObjSts", StringUtil.Str( (decimal)(A1385ObjSts), 1, 0));
            A1383ObjMod = T000Q3_A1383ObjMod[0];
            AssignAttri("", false, "A1383ObjMod", A1383ObjMod);
            A1382ObjMenuOrden = T000Q3_A1382ObjMenuOrden[0];
            AssignAttri("", false, "A1382ObjMenuOrden", StringUtil.LTrimStr( (decimal)(A1382ObjMenuOrden), 6, 0));
            A1381ObjMenuDsc = T000Q3_A1381ObjMenuDsc[0];
            AssignAttri("", false, "A1381ObjMenuDsc", A1381ObjMenuDsc);
            Z346ObjCod = A346ObjCod;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Q26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0Q26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0Q26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q26( ) ;
         if ( RcdFound26 == 0 )
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
         RcdFound26 = 0;
         /* Using cursor T000Q6 */
         pr_default.execute(4, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000Q6_A346ObjCod[0] < A346ObjCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000Q6_A346ObjCod[0] > A346ObjCod ) ) )
            {
               A346ObjCod = T000Q6_A346ObjCod[0];
               AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000Q7 */
         pr_default.execute(5, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000Q7_A346ObjCod[0] > A346ObjCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000Q7_A346ObjCod[0] < A346ObjCod ) ) )
            {
               A346ObjCod = T000Q7_A346ObjCod[0];
               AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Q26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtObjCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Q26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A346ObjCod != Z346ObjCod )
               {
                  A346ObjCod = Z346ObjCod;
                  AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "OBJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtObjCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtObjCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0Q26( ) ;
                  GX_FocusControl = edtObjCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A346ObjCod != Z346ObjCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtObjCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Q26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "OBJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtObjCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtObjCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Q26( ) ;
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
         if ( A346ObjCod != Z346ObjCod )
         {
            A346ObjCod = Z346ObjCod;
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "OBJCOD");
            AnyError = 1;
            GX_FocusControl = edtObjCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtObjCod_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "OBJCOD");
            AnyError = 1;
            GX_FocusControl = edtObjCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtObjDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Q26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Q26( ) ;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjDsc_Internalname;
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
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjDsc_Internalname;
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
         ScanStart0Q26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound26 != 0 )
            {
               ScanNext0Q26( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Q26( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Q26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Q2 */
            pr_default.execute(0, new Object[] {A346ObjCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGOBJETOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1379ObjDsc, T000Q2_A1379ObjDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1388ObjUrl, T000Q2_A1388ObjUrl[0]) != 0 ) || ( Z1385ObjSts != T000Q2_A1385ObjSts[0] ) || ( StringUtil.StrCmp(Z1383ObjMod, T000Q2_A1383ObjMod[0]) != 0 ) || ( Z1382ObjMenuOrden != T000Q2_A1382ObjMenuOrden[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1381ObjMenuDsc, T000Q2_A1381ObjMenuDsc[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1379ObjDsc, T000Q2_A1379ObjDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("sgobjetos:[seudo value changed for attri]"+"ObjDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1379ObjDsc);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A1379ObjDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1388ObjUrl, T000Q2_A1388ObjUrl[0]) != 0 )
               {
                  GXUtil.WriteLog("sgobjetos:[seudo value changed for attri]"+"ObjUrl");
                  GXUtil.WriteLogRaw("Old: ",Z1388ObjUrl);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A1388ObjUrl[0]);
               }
               if ( Z1385ObjSts != T000Q2_A1385ObjSts[0] )
               {
                  GXUtil.WriteLog("sgobjetos:[seudo value changed for attri]"+"ObjSts");
                  GXUtil.WriteLogRaw("Old: ",Z1385ObjSts);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A1385ObjSts[0]);
               }
               if ( StringUtil.StrCmp(Z1383ObjMod, T000Q2_A1383ObjMod[0]) != 0 )
               {
                  GXUtil.WriteLog("sgobjetos:[seudo value changed for attri]"+"ObjMod");
                  GXUtil.WriteLogRaw("Old: ",Z1383ObjMod);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A1383ObjMod[0]);
               }
               if ( Z1382ObjMenuOrden != T000Q2_A1382ObjMenuOrden[0] )
               {
                  GXUtil.WriteLog("sgobjetos:[seudo value changed for attri]"+"ObjMenuOrden");
                  GXUtil.WriteLogRaw("Old: ",Z1382ObjMenuOrden);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A1382ObjMenuOrden[0]);
               }
               if ( StringUtil.StrCmp(Z1381ObjMenuDsc, T000Q2_A1381ObjMenuDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("sgobjetos:[seudo value changed for attri]"+"ObjMenuDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1381ObjMenuDsc);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A1381ObjMenuDsc[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGOBJETOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q26( )
      {
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q26( 0) ;
            CheckOptimisticConcurrency0Q26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q8 */
                     pr_default.execute(6, new Object[] {A346ObjCod, A1379ObjDsc, A1388ObjUrl, A1385ObjSts, A1383ObjMod, A1382ObjMenuOrden, A1381ObjMenuDsc});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGOBJETOS");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption0Q0( ) ;
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
               Load0Q26( ) ;
            }
            EndLevel0Q26( ) ;
         }
         CloseExtendedTableCursors0Q26( ) ;
      }

      protected void Update0Q26( )
      {
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q9 */
                     pr_default.execute(7, new Object[] {A1379ObjDsc, A1388ObjUrl, A1385ObjSts, A1383ObjMod, A1382ObjMenuOrden, A1381ObjMenuDsc, A346ObjCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGOBJETOS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGOBJETOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q26( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Q0( ) ;
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
            EndLevel0Q26( ) ;
         }
         CloseExtendedTableCursors0Q26( ) ;
      }

      protected void DeferredUpdate0Q26( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q26( ) ;
            AfterConfirm0Q26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Q10 */
                  pr_default.execute(8, new Object[] {A346ObjCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGOBJETOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound26 == 0 )
                        {
                           InitAll0Q26( ) ;
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
                        ResetCaption0Q0( ) ;
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Q26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Q26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000Q11 */
            pr_default.execute(9, new Object[] {A346ObjCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Objetos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0Q26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgobjetos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgobjetos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Q26( )
      {
         /* Using cursor T000Q12 */
         pr_default.execute(10);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound26 = 1;
            A346ObjCod = T000Q12_A346ObjCod[0];
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Q26( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound26 = 1;
            A346ObjCod = T000Q12_A346ObjCod[0];
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
         }
      }

      protected void ScanEnd0Q26( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0Q26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q26( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Q26( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Q26( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Q26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q26( )
      {
         edtObjCod_Enabled = 0;
         AssignProp("", false, edtObjCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjCod_Enabled), 5, 0), true);
         edtObjDsc_Enabled = 0;
         AssignProp("", false, edtObjDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjDsc_Enabled), 5, 0), true);
         edtObjUrl_Enabled = 0;
         AssignProp("", false, edtObjUrl_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjUrl_Enabled), 5, 0), true);
         edtObjSts_Enabled = 0;
         AssignProp("", false, edtObjSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjSts_Enabled), 5, 0), true);
         edtObjMod_Enabled = 0;
         AssignProp("", false, edtObjMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjMod_Enabled), 5, 0), true);
         edtObjMenuOrden_Enabled = 0;
         AssignProp("", false, edtObjMenuOrden_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjMenuOrden_Enabled), 5, 0), true);
         edtObjMenuDsc_Enabled = 0;
         AssignProp("", false, edtObjMenuDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjMenuDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Q26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Q0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442499", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgobjetos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z346ObjCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z346ObjCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1379ObjDsc", StringUtil.RTrim( Z1379ObjDsc));
         GxWebStd.gx_hidden_field( context, "Z1388ObjUrl", StringUtil.RTrim( Z1388ObjUrl));
         GxWebStd.gx_hidden_field( context, "Z1385ObjSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1385ObjSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1383ObjMod", StringUtil.RTrim( Z1383ObjMod));
         GxWebStd.gx_hidden_field( context, "Z1382ObjMenuOrden", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1382ObjMenuOrden), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1381ObjMenuDsc", Z1381ObjMenuDsc);
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
         return formatLink("sgobjetos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGOBJETOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGOBJETOS" ;
      }

      protected void InitializeNonKey0Q26( )
      {
         A1379ObjDsc = "";
         AssignAttri("", false, "A1379ObjDsc", A1379ObjDsc);
         A1388ObjUrl = "";
         AssignAttri("", false, "A1388ObjUrl", A1388ObjUrl);
         A1385ObjSts = 0;
         AssignAttri("", false, "A1385ObjSts", StringUtil.Str( (decimal)(A1385ObjSts), 1, 0));
         A1383ObjMod = "";
         AssignAttri("", false, "A1383ObjMod", A1383ObjMod);
         A1382ObjMenuOrden = 0;
         AssignAttri("", false, "A1382ObjMenuOrden", StringUtil.LTrimStr( (decimal)(A1382ObjMenuOrden), 6, 0));
         A1381ObjMenuDsc = "";
         AssignAttri("", false, "A1381ObjMenuDsc", A1381ObjMenuDsc);
         Z1379ObjDsc = "";
         Z1388ObjUrl = "";
         Z1385ObjSts = 0;
         Z1383ObjMod = "";
         Z1382ObjMenuOrden = 0;
         Z1381ObjMenuDsc = "";
      }

      protected void InitAll0Q26( )
      {
         A346ObjCod = 0;
         AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
         InitializeNonKey0Q26( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181144255", true, true);
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
         context.AddJavascriptSource("sgobjetos.js", "?20228181144256", false, true);
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
         edtObjCod_Internalname = "OBJCOD";
         edtObjDsc_Internalname = "OBJDSC";
         edtObjUrl_Internalname = "OBJURL";
         edtObjSts_Internalname = "OBJSTS";
         edtObjMod_Internalname = "OBJMOD";
         edtObjMenuOrden_Internalname = "OBJMENUORDEN";
         edtObjMenuDsc_Internalname = "OBJMENUDSC";
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
         Form.Caption = "SGOBJETOS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtObjMenuDsc_Jsonclick = "";
         edtObjMenuDsc_Enabled = 1;
         edtObjMenuOrden_Jsonclick = "";
         edtObjMenuOrden_Enabled = 1;
         edtObjMod_Jsonclick = "";
         edtObjMod_Enabled = 1;
         edtObjSts_Jsonclick = "";
         edtObjSts_Enabled = 1;
         edtObjUrl_Jsonclick = "";
         edtObjUrl_Enabled = 1;
         edtObjDsc_Jsonclick = "";
         edtObjDsc_Enabled = 1;
         edtObjCod_Jsonclick = "";
         edtObjCod_Enabled = 1;
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
         GX_FocusControl = edtObjDsc_Internalname;
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

      public void Valid_Objcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1379ObjDsc", StringUtil.RTrim( A1379ObjDsc));
         AssignAttri("", false, "A1388ObjUrl", StringUtil.RTrim( A1388ObjUrl));
         AssignAttri("", false, "A1385ObjSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1385ObjSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1383ObjMod", StringUtil.RTrim( A1383ObjMod));
         AssignAttri("", false, "A1382ObjMenuOrden", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1382ObjMenuOrden), 6, 0, ".", "")));
         AssignAttri("", false, "A1381ObjMenuDsc", A1381ObjMenuDsc);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z346ObjCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z346ObjCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1379ObjDsc", StringUtil.RTrim( Z1379ObjDsc));
         GxWebStd.gx_hidden_field( context, "Z1388ObjUrl", StringUtil.RTrim( Z1388ObjUrl));
         GxWebStd.gx_hidden_field( context, "Z1385ObjSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1385ObjSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1383ObjMod", StringUtil.RTrim( Z1383ObjMod));
         GxWebStd.gx_hidden_field( context, "Z1382ObjMenuOrden", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1382ObjMenuOrden), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1381ObjMenuDsc", Z1381ObjMenuDsc);
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
         setEventMetadata("VALID_OBJCOD","{handler:'Valid_Objcod',iparms:[{av:'A346ObjCod',fld:'OBJCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_OBJCOD",",oparms:[{av:'A1379ObjDsc',fld:'OBJDSC',pic:''},{av:'A1388ObjUrl',fld:'OBJURL',pic:''},{av:'A1385ObjSts',fld:'OBJSTS',pic:'9'},{av:'A1383ObjMod',fld:'OBJMOD',pic:''},{av:'A1382ObjMenuOrden',fld:'OBJMENUORDEN',pic:'ZZZZZ9'},{av:'A1381ObjMenuDsc',fld:'OBJMENUDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z346ObjCod'},{av:'Z1379ObjDsc'},{av:'Z1388ObjUrl'},{av:'Z1385ObjSts'},{av:'Z1383ObjMod'},{av:'Z1382ObjMenuOrden'},{av:'Z1381ObjMenuDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1379ObjDsc = "";
         Z1388ObjUrl = "";
         Z1383ObjMod = "";
         Z1381ObjMenuDsc = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A1379ObjDsc = "";
         A1388ObjUrl = "";
         A1383ObjMod = "";
         A1381ObjMenuDsc = "";
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
         T000Q4_A346ObjCod = new int[1] ;
         T000Q4_A1379ObjDsc = new string[] {""} ;
         T000Q4_A1388ObjUrl = new string[] {""} ;
         T000Q4_A1385ObjSts = new short[1] ;
         T000Q4_A1383ObjMod = new string[] {""} ;
         T000Q4_A1382ObjMenuOrden = new int[1] ;
         T000Q4_A1381ObjMenuDsc = new string[] {""} ;
         T000Q5_A346ObjCod = new int[1] ;
         T000Q3_A346ObjCod = new int[1] ;
         T000Q3_A1379ObjDsc = new string[] {""} ;
         T000Q3_A1388ObjUrl = new string[] {""} ;
         T000Q3_A1385ObjSts = new short[1] ;
         T000Q3_A1383ObjMod = new string[] {""} ;
         T000Q3_A1382ObjMenuOrden = new int[1] ;
         T000Q3_A1381ObjMenuDsc = new string[] {""} ;
         sMode26 = "";
         T000Q6_A346ObjCod = new int[1] ;
         T000Q7_A346ObjCod = new int[1] ;
         T000Q2_A346ObjCod = new int[1] ;
         T000Q2_A1379ObjDsc = new string[] {""} ;
         T000Q2_A1388ObjUrl = new string[] {""} ;
         T000Q2_A1385ObjSts = new short[1] ;
         T000Q2_A1383ObjMod = new string[] {""} ;
         T000Q2_A1382ObjMenuOrden = new int[1] ;
         T000Q2_A1381ObjMenuDsc = new string[] {""} ;
         T000Q11_A348UsuCod = new string[] {""} ;
         T000Q11_A346ObjCod = new int[1] ;
         T000Q12_A346ObjCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1379ObjDsc = "";
         ZZ1388ObjUrl = "";
         ZZ1383ObjMod = "";
         ZZ1381ObjMenuDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgobjetos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgobjetos__default(),
            new Object[][] {
                new Object[] {
               T000Q2_A346ObjCod, T000Q2_A1379ObjDsc, T000Q2_A1388ObjUrl, T000Q2_A1385ObjSts, T000Q2_A1383ObjMod, T000Q2_A1382ObjMenuOrden, T000Q2_A1381ObjMenuDsc
               }
               , new Object[] {
               T000Q3_A346ObjCod, T000Q3_A1379ObjDsc, T000Q3_A1388ObjUrl, T000Q3_A1385ObjSts, T000Q3_A1383ObjMod, T000Q3_A1382ObjMenuOrden, T000Q3_A1381ObjMenuDsc
               }
               , new Object[] {
               T000Q4_A346ObjCod, T000Q4_A1379ObjDsc, T000Q4_A1388ObjUrl, T000Q4_A1385ObjSts, T000Q4_A1383ObjMod, T000Q4_A1382ObjMenuOrden, T000Q4_A1381ObjMenuDsc
               }
               , new Object[] {
               T000Q5_A346ObjCod
               }
               , new Object[] {
               T000Q6_A346ObjCod
               }
               , new Object[] {
               T000Q7_A346ObjCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Q11_A348UsuCod, T000Q11_A346ObjCod
               }
               , new Object[] {
               T000Q12_A346ObjCod
               }
            }
         );
      }

      private short Z1385ObjSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1385ObjSts ;
      private short GX_JID ;
      private short RcdFound26 ;
      private short nIsDirty_26 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1385ObjSts ;
      private int Z346ObjCod ;
      private int Z1382ObjMenuOrden ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A346ObjCod ;
      private int edtObjCod_Enabled ;
      private int edtObjDsc_Enabled ;
      private int edtObjUrl_Enabled ;
      private int edtObjSts_Enabled ;
      private int edtObjMod_Enabled ;
      private int A1382ObjMenuOrden ;
      private int edtObjMenuOrden_Enabled ;
      private int edtObjMenuDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ346ObjCod ;
      private int ZZ1382ObjMenuOrden ;
      private string sPrefix ;
      private string Z1379ObjDsc ;
      private string Z1388ObjUrl ;
      private string Z1383ObjMod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtObjCod_Internalname ;
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
      private string edtObjCod_Jsonclick ;
      private string edtObjDsc_Internalname ;
      private string A1379ObjDsc ;
      private string edtObjDsc_Jsonclick ;
      private string edtObjUrl_Internalname ;
      private string A1388ObjUrl ;
      private string edtObjUrl_Jsonclick ;
      private string edtObjSts_Internalname ;
      private string edtObjSts_Jsonclick ;
      private string edtObjMod_Internalname ;
      private string A1383ObjMod ;
      private string edtObjMod_Jsonclick ;
      private string edtObjMenuOrden_Internalname ;
      private string edtObjMenuOrden_Jsonclick ;
      private string edtObjMenuDsc_Internalname ;
      private string edtObjMenuDsc_Jsonclick ;
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
      private string sMode26 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1379ObjDsc ;
      private string ZZ1388ObjUrl ;
      private string ZZ1383ObjMod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z1381ObjMenuDsc ;
      private string A1381ObjMenuDsc ;
      private string ZZ1381ObjMenuDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000Q4_A346ObjCod ;
      private string[] T000Q4_A1379ObjDsc ;
      private string[] T000Q4_A1388ObjUrl ;
      private short[] T000Q4_A1385ObjSts ;
      private string[] T000Q4_A1383ObjMod ;
      private int[] T000Q4_A1382ObjMenuOrden ;
      private string[] T000Q4_A1381ObjMenuDsc ;
      private int[] T000Q5_A346ObjCod ;
      private int[] T000Q3_A346ObjCod ;
      private string[] T000Q3_A1379ObjDsc ;
      private string[] T000Q3_A1388ObjUrl ;
      private short[] T000Q3_A1385ObjSts ;
      private string[] T000Q3_A1383ObjMod ;
      private int[] T000Q3_A1382ObjMenuOrden ;
      private string[] T000Q3_A1381ObjMenuDsc ;
      private int[] T000Q6_A346ObjCod ;
      private int[] T000Q7_A346ObjCod ;
      private int[] T000Q2_A346ObjCod ;
      private string[] T000Q2_A1379ObjDsc ;
      private string[] T000Q2_A1388ObjUrl ;
      private short[] T000Q2_A1385ObjSts ;
      private string[] T000Q2_A1383ObjMod ;
      private int[] T000Q2_A1382ObjMenuOrden ;
      private string[] T000Q2_A1381ObjMenuDsc ;
      private string[] T000Q11_A348UsuCod ;
      private int[] T000Q11_A346ObjCod ;
      private int[] T000Q12_A346ObjCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgobjetos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgobjetos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000Q4;
        prmT000Q4 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q5;
        prmT000Q5 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q3;
        prmT000Q3 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q6;
        prmT000Q6 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q7;
        prmT000Q7 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q2;
        prmT000Q2 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q8;
        prmT000Q8 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0) ,
        new ParDef("@ObjDsc",GXType.NChar,100,0) ,
        new ParDef("@ObjUrl",GXType.NChar,31,0) ,
        new ParDef("@ObjSts",GXType.Int16,1,0) ,
        new ParDef("@ObjMod",GXType.NChar,3,0) ,
        new ParDef("@ObjMenuOrden",GXType.Int32,6,0) ,
        new ParDef("@ObjMenuDsc",GXType.NVarChar,100,0)
        };
        Object[] prmT000Q9;
        prmT000Q9 = new Object[] {
        new ParDef("@ObjDsc",GXType.NChar,100,0) ,
        new ParDef("@ObjUrl",GXType.NChar,31,0) ,
        new ParDef("@ObjSts",GXType.Int16,1,0) ,
        new ParDef("@ObjMod",GXType.NChar,3,0) ,
        new ParDef("@ObjMenuOrden",GXType.Int32,6,0) ,
        new ParDef("@ObjMenuDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q10;
        prmT000Q10 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q11;
        prmT000Q11 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Q12;
        prmT000Q12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000Q2", "SELECT [ObjCod], [ObjDsc], [ObjUrl], [ObjSts], [ObjMod], [ObjMenuOrden], [ObjMenuDsc] FROM [SGOBJETOS] WITH (UPDLOCK) WHERE [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q3", "SELECT [ObjCod], [ObjDsc], [ObjUrl], [ObjSts], [ObjMod], [ObjMenuOrden], [ObjMenuDsc] FROM [SGOBJETOS] WHERE [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q4", "SELECT TM1.[ObjCod], TM1.[ObjDsc], TM1.[ObjUrl], TM1.[ObjSts], TM1.[ObjMod], TM1.[ObjMenuOrden], TM1.[ObjMenuDsc] FROM [SGOBJETOS] TM1 WHERE TM1.[ObjCod] = @ObjCod ORDER BY TM1.[ObjCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q5", "SELECT [ObjCod] FROM [SGOBJETOS] WHERE [ObjCod] = @ObjCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q6", "SELECT TOP 1 [ObjCod] FROM [SGOBJETOS] WHERE ( [ObjCod] > @ObjCod) ORDER BY [ObjCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q7", "SELECT TOP 1 [ObjCod] FROM [SGOBJETOS] WHERE ( [ObjCod] < @ObjCod) ORDER BY [ObjCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q8", "INSERT INTO [SGOBJETOS]([ObjCod], [ObjDsc], [ObjUrl], [ObjSts], [ObjMod], [ObjMenuOrden], [ObjMenuDsc]) VALUES(@ObjCod, @ObjDsc, @ObjUrl, @ObjSts, @ObjMod, @ObjMenuOrden, @ObjMenuDsc)", GxErrorMask.GX_NOMASK,prmT000Q8)
           ,new CursorDef("T000Q9", "UPDATE [SGOBJETOS] SET [ObjDsc]=@ObjDsc, [ObjUrl]=@ObjUrl, [ObjSts]=@ObjSts, [ObjMod]=@ObjMod, [ObjMenuOrden]=@ObjMenuOrden, [ObjMenuDsc]=@ObjMenuDsc  WHERE [ObjCod] = @ObjCod", GxErrorMask.GX_NOMASK,prmT000Q9)
           ,new CursorDef("T000Q10", "DELETE FROM [SGOBJETOS]  WHERE [ObjCod] = @ObjCod", GxErrorMask.GX_NOMASK,prmT000Q10)
           ,new CursorDef("T000Q11", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q12", "SELECT [ObjCod] FROM [SGOBJETOS] ORDER BY [ObjCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 31);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 31);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 31);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 3);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
