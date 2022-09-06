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
   public class sgusuariosdet : GXDataArea
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
            A348UsuCod = GetPar( "UsuCod");
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A348UsuCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A346ObjCod = (int)(NumberUtil.Val( GetPar( "ObjCod"), "."));
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A346ObjCod) ;
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
            Form.Meta.addItem("description", "SGUSUARIOSDET", 0) ;
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

      public sgusuariosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuariosdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGUSUARIOSDET", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A346ObjCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtObjCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A346ObjCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A346ObjCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjTot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjTot_Internalname, "Todos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjTot_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1386ObjTot), 1, 0, ".", "")), StringUtil.LTrim( ((edtObjTot_Enabled!=0) ? context.localUtil.Format( (decimal)(A1386ObjTot), "9") : context.localUtil.Format( (decimal)(A1386ObjTot), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjTot_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjNew_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjNew_Internalname, "Nuevo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjNew_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1384ObjNew), 1, 0, ".", "")), StringUtil.LTrim( ((edtObjNew_Enabled!=0) ? context.localUtil.Format( (decimal)(A1384ObjNew), "9") : context.localUtil.Format( (decimal)(A1384ObjNew), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjNew_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjNew_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjUpd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjUpd_Internalname, "Actualizar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjUpd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1387ObjUpd), 1, 0, ".", "")), StringUtil.LTrim( ((edtObjUpd_Enabled!=0) ? context.localUtil.Format( (decimal)(A1387ObjUpd), "9") : context.localUtil.Format( (decimal)(A1387ObjUpd), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjUpd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjUpd_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjDlt_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjDlt_Internalname, "Eliminar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjDlt_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1378ObjDlt), 1, 0, ".", "")), StringUtil.LTrim( ((edtObjDlt_Enabled!=0) ? context.localUtil.Format( (decimal)(A1378ObjDlt), "9") : context.localUtil.Format( (decimal)(A1378ObjDlt), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjDlt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjDlt_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtObjDsp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtObjDsp_Internalname, "Visualizar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtObjDsp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1380ObjDsp), 1, 0, ".", "")), StringUtil.LTrim( ((edtObjDsp_Enabled!=0) ? context.localUtil.Format( (decimal)(A1380ObjDsp), "9") : context.localUtil.Format( (decimal)(A1380ObjDsp), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtObjDsp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtObjDsp_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSDET.htm");
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
            Z346ObjCod = (int)(context.localUtil.CToN( cgiGet( "Z346ObjCod"), ".", ","));
            Z1386ObjTot = (short)(context.localUtil.CToN( cgiGet( "Z1386ObjTot"), ".", ","));
            Z1384ObjNew = (short)(context.localUtil.CToN( cgiGet( "Z1384ObjNew"), ".", ","));
            Z1387ObjUpd = (short)(context.localUtil.CToN( cgiGet( "Z1387ObjUpd"), ".", ","));
            Z1378ObjDlt = (short)(context.localUtil.CToN( cgiGet( "Z1378ObjDlt"), ".", ","));
            Z1380ObjDsp = (short)(context.localUtil.CToN( cgiGet( "Z1380ObjDsp"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A348UsuCod = cgiGet( edtUsuCod_Internalname);
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjTot_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjTot_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJTOT");
               AnyError = 1;
               GX_FocusControl = edtObjTot_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1386ObjTot = 0;
               AssignAttri("", false, "A1386ObjTot", StringUtil.Str( (decimal)(A1386ObjTot), 1, 0));
            }
            else
            {
               A1386ObjTot = (short)(context.localUtil.CToN( cgiGet( edtObjTot_Internalname), ".", ","));
               AssignAttri("", false, "A1386ObjTot", StringUtil.Str( (decimal)(A1386ObjTot), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjNew_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjNew_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJNEW");
               AnyError = 1;
               GX_FocusControl = edtObjNew_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1384ObjNew = 0;
               AssignAttri("", false, "A1384ObjNew", StringUtil.Str( (decimal)(A1384ObjNew), 1, 0));
            }
            else
            {
               A1384ObjNew = (short)(context.localUtil.CToN( cgiGet( edtObjNew_Internalname), ".", ","));
               AssignAttri("", false, "A1384ObjNew", StringUtil.Str( (decimal)(A1384ObjNew), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjUpd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjUpd_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJUPD");
               AnyError = 1;
               GX_FocusControl = edtObjUpd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1387ObjUpd = 0;
               AssignAttri("", false, "A1387ObjUpd", StringUtil.Str( (decimal)(A1387ObjUpd), 1, 0));
            }
            else
            {
               A1387ObjUpd = (short)(context.localUtil.CToN( cgiGet( edtObjUpd_Internalname), ".", ","));
               AssignAttri("", false, "A1387ObjUpd", StringUtil.Str( (decimal)(A1387ObjUpd), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjDlt_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjDlt_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJDLT");
               AnyError = 1;
               GX_FocusControl = edtObjDlt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1378ObjDlt = 0;
               AssignAttri("", false, "A1378ObjDlt", StringUtil.Str( (decimal)(A1378ObjDlt), 1, 0));
            }
            else
            {
               A1378ObjDlt = (short)(context.localUtil.CToN( cgiGet( edtObjDlt_Internalname), ".", ","));
               AssignAttri("", false, "A1378ObjDlt", StringUtil.Str( (decimal)(A1378ObjDlt), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtObjDsp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtObjDsp_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "OBJDSP");
               AnyError = 1;
               GX_FocusControl = edtObjDsp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1380ObjDsp = 0;
               AssignAttri("", false, "A1380ObjDsp", StringUtil.Str( (decimal)(A1380ObjDsp), 1, 0));
            }
            else
            {
               A1380ObjDsp = (short)(context.localUtil.CToN( cgiGet( edtObjDsp_Internalname), ".", ","));
               AssignAttri("", false, "A1380ObjDsp", StringUtil.Str( (decimal)(A1380ObjDsp), 1, 0));
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
               A348UsuCod = GetPar( "UsuCod");
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
               InitAll0Z33( ) ;
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
         DisableAttributes0Z33( ) ;
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

      protected void ResetCaption0Z0( )
      {
      }

      protected void ZM0Z33( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1386ObjTot = T000Z3_A1386ObjTot[0];
               Z1384ObjNew = T000Z3_A1384ObjNew[0];
               Z1387ObjUpd = T000Z3_A1387ObjUpd[0];
               Z1378ObjDlt = T000Z3_A1378ObjDlt[0];
               Z1380ObjDsp = T000Z3_A1380ObjDsp[0];
            }
            else
            {
               Z1386ObjTot = A1386ObjTot;
               Z1384ObjNew = A1384ObjNew;
               Z1387ObjUpd = A1387ObjUpd;
               Z1378ObjDlt = A1378ObjDlt;
               Z1380ObjDsp = A1380ObjDsp;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1386ObjTot = A1386ObjTot;
            Z1384ObjNew = A1384ObjNew;
            Z1387ObjUpd = A1387ObjUpd;
            Z1378ObjDlt = A1378ObjDlt;
            Z1380ObjDsp = A1380ObjDsp;
            Z348UsuCod = A348UsuCod;
            Z346ObjCod = A346ObjCod;
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

      protected void Load0Z33( )
      {
         /* Using cursor T000Z6 */
         pr_default.execute(4, new Object[] {A348UsuCod, A346ObjCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound33 = 1;
            A1386ObjTot = T000Z6_A1386ObjTot[0];
            AssignAttri("", false, "A1386ObjTot", StringUtil.Str( (decimal)(A1386ObjTot), 1, 0));
            A1384ObjNew = T000Z6_A1384ObjNew[0];
            AssignAttri("", false, "A1384ObjNew", StringUtil.Str( (decimal)(A1384ObjNew), 1, 0));
            A1387ObjUpd = T000Z6_A1387ObjUpd[0];
            AssignAttri("", false, "A1387ObjUpd", StringUtil.Str( (decimal)(A1387ObjUpd), 1, 0));
            A1378ObjDlt = T000Z6_A1378ObjDlt[0];
            AssignAttri("", false, "A1378ObjDlt", StringUtil.Str( (decimal)(A1378ObjDlt), 1, 0));
            A1380ObjDsp = T000Z6_A1380ObjDsp[0];
            AssignAttri("", false, "A1380ObjDsp", StringUtil.Str( (decimal)(A1380ObjDsp), 1, 0));
            ZM0Z33( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0Z33( ) ;
      }

      protected void OnLoadActions0Z33( )
      {
      }

      protected void CheckExtendedTable0Z33( )
      {
         nIsDirty_33 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000Z4 */
         pr_default.execute(2, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000Z5 */
         pr_default.execute(3, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Objetos'.", "ForeignKeyNotFound", 1, "OBJCOD");
            AnyError = 1;
            GX_FocusControl = edtObjCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0Z33( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A348UsuCod )
      {
         /* Using cursor T000Z7 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( int A346ObjCod )
      {
         /* Using cursor T000Z8 */
         pr_default.execute(6, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Objetos'.", "ForeignKeyNotFound", 1, "OBJCOD");
            AnyError = 1;
            GX_FocusControl = edtObjCod_Internalname;
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

      protected void GetKey0Z33( )
      {
         /* Using cursor T000Z9 */
         pr_default.execute(7, new Object[] {A348UsuCod, A346ObjCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Z3 */
         pr_default.execute(1, new Object[] {A348UsuCod, A346ObjCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Z33( 1) ;
            RcdFound33 = 1;
            A1386ObjTot = T000Z3_A1386ObjTot[0];
            AssignAttri("", false, "A1386ObjTot", StringUtil.Str( (decimal)(A1386ObjTot), 1, 0));
            A1384ObjNew = T000Z3_A1384ObjNew[0];
            AssignAttri("", false, "A1384ObjNew", StringUtil.Str( (decimal)(A1384ObjNew), 1, 0));
            A1387ObjUpd = T000Z3_A1387ObjUpd[0];
            AssignAttri("", false, "A1387ObjUpd", StringUtil.Str( (decimal)(A1387ObjUpd), 1, 0));
            A1378ObjDlt = T000Z3_A1378ObjDlt[0];
            AssignAttri("", false, "A1378ObjDlt", StringUtil.Str( (decimal)(A1378ObjDlt), 1, 0));
            A1380ObjDsp = T000Z3_A1380ObjDsp[0];
            AssignAttri("", false, "A1380ObjDsp", StringUtil.Str( (decimal)(A1380ObjDsp), 1, 0));
            A348UsuCod = T000Z3_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A346ObjCod = T000Z3_A346ObjCod[0];
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
            Z348UsuCod = A348UsuCod;
            Z346ObjCod = A346ObjCod;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0Z33( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey0Z33( ) ;
            }
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey0Z33( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Z33( ) ;
         if ( RcdFound33 == 0 )
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
         RcdFound33 = 0;
         /* Using cursor T000Z10 */
         pr_default.execute(8, new Object[] {A348UsuCod, A346ObjCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000Z10_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000Z10_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000Z10_A346ObjCod[0] < A346ObjCod ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000Z10_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000Z10_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000Z10_A346ObjCod[0] > A346ObjCod ) ) )
            {
               A348UsuCod = T000Z10_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A346ObjCod = T000Z10_A346ObjCod[0];
               AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
               RcdFound33 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound33 = 0;
         /* Using cursor T000Z11 */
         pr_default.execute(9, new Object[] {A348UsuCod, A346ObjCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000Z11_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000Z11_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000Z11_A346ObjCod[0] > A346ObjCod ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000Z11_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000Z11_A348UsuCod[0], A348UsuCod) == 0 ) && ( T000Z11_A346ObjCod[0] < A346ObjCod ) ) )
            {
               A348UsuCod = T000Z11_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A346ObjCod = T000Z11_A346ObjCod[0];
               AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
               RcdFound33 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Z33( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Z33( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound33 == 1 )
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A346ObjCod != Z346ObjCod ) )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  A346ObjCod = Z346ObjCod;
                  AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
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
                  Update0Z33( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A346ObjCod != Z346ObjCod ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Z33( ) ;
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
                     Insert0Z33( ) ;
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
         if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( A346ObjCod != Z346ObjCod ) )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A346ObjCod = Z346ObjCod;
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtObjTot_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0Z33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjTot_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Z33( ) ;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjTot_Internalname;
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
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjTot_Internalname;
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
         ScanStart0Z33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound33 != 0 )
            {
               ScanNext0Z33( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtObjTot_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0Z33( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0Z33( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Z2 */
            pr_default.execute(0, new Object[] {A348UsuCod, A346ObjCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1386ObjTot != T000Z2_A1386ObjTot[0] ) || ( Z1384ObjNew != T000Z2_A1384ObjNew[0] ) || ( Z1387ObjUpd != T000Z2_A1387ObjUpd[0] ) || ( Z1378ObjDlt != T000Z2_A1378ObjDlt[0] ) || ( Z1380ObjDsp != T000Z2_A1380ObjDsp[0] ) )
            {
               if ( Z1386ObjTot != T000Z2_A1386ObjTot[0] )
               {
                  GXUtil.WriteLog("sgusuariosdet:[seudo value changed for attri]"+"ObjTot");
                  GXUtil.WriteLogRaw("Old: ",Z1386ObjTot);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1386ObjTot[0]);
               }
               if ( Z1384ObjNew != T000Z2_A1384ObjNew[0] )
               {
                  GXUtil.WriteLog("sgusuariosdet:[seudo value changed for attri]"+"ObjNew");
                  GXUtil.WriteLogRaw("Old: ",Z1384ObjNew);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1384ObjNew[0]);
               }
               if ( Z1387ObjUpd != T000Z2_A1387ObjUpd[0] )
               {
                  GXUtil.WriteLog("sgusuariosdet:[seudo value changed for attri]"+"ObjUpd");
                  GXUtil.WriteLogRaw("Old: ",Z1387ObjUpd);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1387ObjUpd[0]);
               }
               if ( Z1378ObjDlt != T000Z2_A1378ObjDlt[0] )
               {
                  GXUtil.WriteLog("sgusuariosdet:[seudo value changed for attri]"+"ObjDlt");
                  GXUtil.WriteLogRaw("Old: ",Z1378ObjDlt);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1378ObjDlt[0]);
               }
               if ( Z1380ObjDsp != T000Z2_A1380ObjDsp[0] )
               {
                  GXUtil.WriteLog("sgusuariosdet:[seudo value changed for attri]"+"ObjDsp");
                  GXUtil.WriteLogRaw("Old: ",Z1380ObjDsp);
                  GXUtil.WriteLogRaw("Current: ",T000Z2_A1380ObjDsp[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Z33( )
      {
         BeforeValidate0Z33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z33( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Z33( 0) ;
            CheckOptimisticConcurrency0Z33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Z33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z12 */
                     pr_default.execute(10, new Object[] {A1386ObjTot, A1384ObjNew, A1387ObjUpd, A1378ObjDlt, A1380ObjDsp, A348UsuCod, A346ObjCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOSDET");
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
                           ResetCaption0Z0( ) ;
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
               Load0Z33( ) ;
            }
            EndLevel0Z33( ) ;
         }
         CloseExtendedTableCursors0Z33( ) ;
      }

      protected void Update0Z33( )
      {
         BeforeValidate0Z33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Z33( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Z33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Z33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Z13 */
                     pr_default.execute(11, new Object[] {A1386ObjTot, A1384ObjNew, A1387ObjUpd, A1378ObjDlt, A1380ObjDsp, A348UsuCod, A346ObjCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOSDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Z33( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0Z0( ) ;
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
            EndLevel0Z33( ) ;
         }
         CloseExtendedTableCursors0Z33( ) ;
      }

      protected void DeferredUpdate0Z33( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0Z33( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Z33( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Z33( ) ;
            AfterConfirm0Z33( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Z33( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Z14 */
                  pr_default.execute(12, new Object[] {A348UsuCod, A346ObjCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound33 == 0 )
                        {
                           InitAll0Z33( ) ;
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
                        ResetCaption0Z0( ) ;
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
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Z33( ) ;
         Gx_mode = sMode33;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Z33( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Z33( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Z33( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgusuariosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgusuariosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Z33( )
      {
         /* Using cursor T000Z15 */
         pr_default.execute(13);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound33 = 1;
            A348UsuCod = T000Z15_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A346ObjCod = T000Z15_A346ObjCod[0];
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Z33( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound33 = 1;
            A348UsuCod = T000Z15_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A346ObjCod = T000Z15_A346ObjCod[0];
            AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
         }
      }

      protected void ScanEnd0Z33( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0Z33( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Z33( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Z33( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0Z33( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0Z33( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0Z33( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Z33( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtObjCod_Enabled = 0;
         AssignProp("", false, edtObjCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjCod_Enabled), 5, 0), true);
         edtObjTot_Enabled = 0;
         AssignProp("", false, edtObjTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjTot_Enabled), 5, 0), true);
         edtObjNew_Enabled = 0;
         AssignProp("", false, edtObjNew_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjNew_Enabled), 5, 0), true);
         edtObjUpd_Enabled = 0;
         AssignProp("", false, edtObjUpd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjUpd_Enabled), 5, 0), true);
         edtObjDlt_Enabled = 0;
         AssignProp("", false, edtObjDlt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjDlt_Enabled), 5, 0), true);
         edtObjDsp_Enabled = 0;
         AssignProp("", false, edtObjDsp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtObjDsp_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Z33( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Z0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443217", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuariosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z346ObjCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z346ObjCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1386ObjTot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1386ObjTot), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1384ObjNew", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1384ObjNew), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1387ObjUpd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1387ObjUpd), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1378ObjDlt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1378ObjDlt), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1380ObjDsp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1380ObjDsp), 1, 0, ".", "")));
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
         return formatLink("sgusuariosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGUSUARIOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGUSUARIOSDET" ;
      }

      protected void InitializeNonKey0Z33( )
      {
         A1386ObjTot = 0;
         AssignAttri("", false, "A1386ObjTot", StringUtil.Str( (decimal)(A1386ObjTot), 1, 0));
         A1384ObjNew = 0;
         AssignAttri("", false, "A1384ObjNew", StringUtil.Str( (decimal)(A1384ObjNew), 1, 0));
         A1387ObjUpd = 0;
         AssignAttri("", false, "A1387ObjUpd", StringUtil.Str( (decimal)(A1387ObjUpd), 1, 0));
         A1378ObjDlt = 0;
         AssignAttri("", false, "A1378ObjDlt", StringUtil.Str( (decimal)(A1378ObjDlt), 1, 0));
         A1380ObjDsp = 0;
         AssignAttri("", false, "A1380ObjDsp", StringUtil.Str( (decimal)(A1380ObjDsp), 1, 0));
         Z1386ObjTot = 0;
         Z1384ObjNew = 0;
         Z1387ObjUpd = 0;
         Z1378ObjDlt = 0;
         Z1380ObjDsp = 0;
      }

      protected void InitAll0Z33( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         A346ObjCod = 0;
         AssignAttri("", false, "A346ObjCod", StringUtil.LTrimStr( (decimal)(A346ObjCod), 6, 0));
         InitializeNonKey0Z33( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443227", true, true);
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
         context.AddJavascriptSource("sgusuariosdet.js", "?202281811443228", false, true);
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
         edtObjCod_Internalname = "OBJCOD";
         edtObjTot_Internalname = "OBJTOT";
         edtObjNew_Internalname = "OBJNEW";
         edtObjUpd_Internalname = "OBJUPD";
         edtObjDlt_Internalname = "OBJDLT";
         edtObjDsp_Internalname = "OBJDSP";
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
         Form.Caption = "SGUSUARIOSDET";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtObjDsp_Jsonclick = "";
         edtObjDsp_Enabled = 1;
         edtObjDlt_Jsonclick = "";
         edtObjDlt_Enabled = 1;
         edtObjUpd_Jsonclick = "";
         edtObjUpd_Enabled = 1;
         edtObjNew_Jsonclick = "";
         edtObjNew_Enabled = 1;
         edtObjTot_Jsonclick = "";
         edtObjTot_Enabled = 1;
         edtObjCod_Jsonclick = "";
         edtObjCod_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000Z16 */
         pr_default.execute(14, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000Z17 */
         pr_default.execute(15, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Objetos'.", "ForeignKeyNotFound", 1, "OBJCOD");
            AnyError = 1;
            GX_FocusControl = edtObjCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtObjTot_Internalname;
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
         /* Using cursor T000Z16 */
         pr_default.execute(14, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuarios'.", "ForeignKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Objcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000Z17 */
         pr_default.execute(15, new Object[] {A346ObjCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Objetos'.", "ForeignKeyNotFound", 1, "OBJCOD");
            AnyError = 1;
            GX_FocusControl = edtObjCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1386ObjTot", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1386ObjTot), 1, 0, ".", "")));
         AssignAttri("", false, "A1384ObjNew", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1384ObjNew), 1, 0, ".", "")));
         AssignAttri("", false, "A1387ObjUpd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1387ObjUpd), 1, 0, ".", "")));
         AssignAttri("", false, "A1378ObjDlt", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1378ObjDlt), 1, 0, ".", "")));
         AssignAttri("", false, "A1380ObjDsp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1380ObjDsp), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z346ObjCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z346ObjCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1386ObjTot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1386ObjTot), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1384ObjNew", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1384ObjNew), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1387ObjUpd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1387ObjUpd), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1378ObjDlt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1378ObjDlt), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1380ObjDsp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1380ObjDsp), 1, 0, ".", "")));
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
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''}]");
         setEventMetadata("VALID_USUCOD",",oparms:[]}");
         setEventMetadata("VALID_OBJCOD","{handler:'Valid_Objcod',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A346ObjCod',fld:'OBJCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_OBJCOD",",oparms:[{av:'A1386ObjTot',fld:'OBJTOT',pic:'9'},{av:'A1384ObjNew',fld:'OBJNEW',pic:'9'},{av:'A1387ObjUpd',fld:'OBJUPD',pic:'9'},{av:'A1378ObjDlt',fld:'OBJDLT',pic:'9'},{av:'A1380ObjDsp',fld:'OBJDSP',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{av:'Z346ObjCod'},{av:'Z1386ObjTot'},{av:'Z1384ObjNew'},{av:'Z1387ObjUpd'},{av:'Z1378ObjDlt'},{av:'Z1380ObjDsp'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A348UsuCod = "";
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
         T000Z6_A1386ObjTot = new short[1] ;
         T000Z6_A1384ObjNew = new short[1] ;
         T000Z6_A1387ObjUpd = new short[1] ;
         T000Z6_A1378ObjDlt = new short[1] ;
         T000Z6_A1380ObjDsp = new short[1] ;
         T000Z6_A348UsuCod = new string[] {""} ;
         T000Z6_A346ObjCod = new int[1] ;
         T000Z4_A348UsuCod = new string[] {""} ;
         T000Z5_A346ObjCod = new int[1] ;
         T000Z7_A348UsuCod = new string[] {""} ;
         T000Z8_A346ObjCod = new int[1] ;
         T000Z9_A348UsuCod = new string[] {""} ;
         T000Z9_A346ObjCod = new int[1] ;
         T000Z3_A1386ObjTot = new short[1] ;
         T000Z3_A1384ObjNew = new short[1] ;
         T000Z3_A1387ObjUpd = new short[1] ;
         T000Z3_A1378ObjDlt = new short[1] ;
         T000Z3_A1380ObjDsp = new short[1] ;
         T000Z3_A348UsuCod = new string[] {""} ;
         T000Z3_A346ObjCod = new int[1] ;
         sMode33 = "";
         T000Z10_A348UsuCod = new string[] {""} ;
         T000Z10_A346ObjCod = new int[1] ;
         T000Z11_A348UsuCod = new string[] {""} ;
         T000Z11_A346ObjCod = new int[1] ;
         T000Z2_A1386ObjTot = new short[1] ;
         T000Z2_A1384ObjNew = new short[1] ;
         T000Z2_A1387ObjUpd = new short[1] ;
         T000Z2_A1378ObjDlt = new short[1] ;
         T000Z2_A1380ObjDsp = new short[1] ;
         T000Z2_A348UsuCod = new string[] {""} ;
         T000Z2_A346ObjCod = new int[1] ;
         T000Z15_A348UsuCod = new string[] {""} ;
         T000Z15_A346ObjCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000Z16_A348UsuCod = new string[] {""} ;
         T000Z17_A346ObjCod = new int[1] ;
         ZZ348UsuCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuariosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuariosdet__default(),
            new Object[][] {
                new Object[] {
               T000Z2_A1386ObjTot, T000Z2_A1384ObjNew, T000Z2_A1387ObjUpd, T000Z2_A1378ObjDlt, T000Z2_A1380ObjDsp, T000Z2_A348UsuCod, T000Z2_A346ObjCod
               }
               , new Object[] {
               T000Z3_A1386ObjTot, T000Z3_A1384ObjNew, T000Z3_A1387ObjUpd, T000Z3_A1378ObjDlt, T000Z3_A1380ObjDsp, T000Z3_A348UsuCod, T000Z3_A346ObjCod
               }
               , new Object[] {
               T000Z4_A348UsuCod
               }
               , new Object[] {
               T000Z5_A346ObjCod
               }
               , new Object[] {
               T000Z6_A1386ObjTot, T000Z6_A1384ObjNew, T000Z6_A1387ObjUpd, T000Z6_A1378ObjDlt, T000Z6_A1380ObjDsp, T000Z6_A348UsuCod, T000Z6_A346ObjCod
               }
               , new Object[] {
               T000Z7_A348UsuCod
               }
               , new Object[] {
               T000Z8_A346ObjCod
               }
               , new Object[] {
               T000Z9_A348UsuCod, T000Z9_A346ObjCod
               }
               , new Object[] {
               T000Z10_A348UsuCod, T000Z10_A346ObjCod
               }
               , new Object[] {
               T000Z11_A348UsuCod, T000Z11_A346ObjCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Z15_A348UsuCod, T000Z15_A346ObjCod
               }
               , new Object[] {
               T000Z16_A348UsuCod
               }
               , new Object[] {
               T000Z17_A346ObjCod
               }
            }
         );
      }

      private short Z1386ObjTot ;
      private short Z1384ObjNew ;
      private short Z1387ObjUpd ;
      private short Z1378ObjDlt ;
      private short Z1380ObjDsp ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1386ObjTot ;
      private short A1384ObjNew ;
      private short A1387ObjUpd ;
      private short A1378ObjDlt ;
      private short A1380ObjDsp ;
      private short GX_JID ;
      private short RcdFound33 ;
      private short nIsDirty_33 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1386ObjTot ;
      private short ZZ1384ObjNew ;
      private short ZZ1387ObjUpd ;
      private short ZZ1378ObjDlt ;
      private short ZZ1380ObjDsp ;
      private int Z346ObjCod ;
      private int A346ObjCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtObjCod_Enabled ;
      private int edtObjTot_Enabled ;
      private int edtObjNew_Enabled ;
      private int edtObjUpd_Enabled ;
      private int edtObjDlt_Enabled ;
      private int edtObjDsp_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ346ObjCod ;
      private string sPrefix ;
      private string Z348UsuCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A348UsuCod ;
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
      private string edtUsuCod_Jsonclick ;
      private string edtObjCod_Internalname ;
      private string edtObjCod_Jsonclick ;
      private string edtObjTot_Internalname ;
      private string edtObjTot_Jsonclick ;
      private string edtObjNew_Internalname ;
      private string edtObjNew_Jsonclick ;
      private string edtObjUpd_Internalname ;
      private string edtObjUpd_Jsonclick ;
      private string edtObjDlt_Internalname ;
      private string edtObjDlt_Jsonclick ;
      private string edtObjDsp_Internalname ;
      private string edtObjDsp_Jsonclick ;
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
      private string sMode33 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ348UsuCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000Z6_A1386ObjTot ;
      private short[] T000Z6_A1384ObjNew ;
      private short[] T000Z6_A1387ObjUpd ;
      private short[] T000Z6_A1378ObjDlt ;
      private short[] T000Z6_A1380ObjDsp ;
      private string[] T000Z6_A348UsuCod ;
      private int[] T000Z6_A346ObjCod ;
      private string[] T000Z4_A348UsuCod ;
      private int[] T000Z5_A346ObjCod ;
      private string[] T000Z7_A348UsuCod ;
      private int[] T000Z8_A346ObjCod ;
      private string[] T000Z9_A348UsuCod ;
      private int[] T000Z9_A346ObjCod ;
      private short[] T000Z3_A1386ObjTot ;
      private short[] T000Z3_A1384ObjNew ;
      private short[] T000Z3_A1387ObjUpd ;
      private short[] T000Z3_A1378ObjDlt ;
      private short[] T000Z3_A1380ObjDsp ;
      private string[] T000Z3_A348UsuCod ;
      private int[] T000Z3_A346ObjCod ;
      private string[] T000Z10_A348UsuCod ;
      private int[] T000Z10_A346ObjCod ;
      private string[] T000Z11_A348UsuCod ;
      private int[] T000Z11_A346ObjCod ;
      private short[] T000Z2_A1386ObjTot ;
      private short[] T000Z2_A1384ObjNew ;
      private short[] T000Z2_A1387ObjUpd ;
      private short[] T000Z2_A1378ObjDlt ;
      private short[] T000Z2_A1380ObjDsp ;
      private string[] T000Z2_A348UsuCod ;
      private int[] T000Z2_A346ObjCod ;
      private string[] T000Z15_A348UsuCod ;
      private int[] T000Z15_A346ObjCod ;
      private string[] T000Z16_A348UsuCod ;
      private int[] T000Z17_A346ObjCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgusuariosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuariosdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000Z6;
        prmT000Z6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z4;
        prmT000Z4 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Z5;
        prmT000Z5 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z7;
        prmT000Z7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Z8;
        prmT000Z8 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z9;
        prmT000Z9 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z3;
        prmT000Z3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z10;
        prmT000Z10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z11;
        prmT000Z11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z2;
        prmT000Z2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z12;
        prmT000Z12 = new Object[] {
        new ParDef("@ObjTot",GXType.Int16,1,0) ,
        new ParDef("@ObjNew",GXType.Int16,1,0) ,
        new ParDef("@ObjUpd",GXType.Int16,1,0) ,
        new ParDef("@ObjDlt",GXType.Int16,1,0) ,
        new ParDef("@ObjDsp",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z13;
        prmT000Z13 = new Object[] {
        new ParDef("@ObjTot",GXType.Int16,1,0) ,
        new ParDef("@ObjNew",GXType.Int16,1,0) ,
        new ParDef("@ObjUpd",GXType.Int16,1,0) ,
        new ParDef("@ObjDlt",GXType.Int16,1,0) ,
        new ParDef("@ObjDsp",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z14;
        prmT000Z14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        Object[] prmT000Z15;
        prmT000Z15 = new Object[] {
        };
        Object[] prmT000Z16;
        prmT000Z16 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT000Z17;
        prmT000Z17 = new Object[] {
        new ParDef("@ObjCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000Z2", "SELECT [ObjTot], [ObjNew], [ObjUpd], [ObjDlt], [ObjDsp], [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z3", "SELECT [ObjTot], [ObjNew], [ObjUpd], [ObjDlt], [ObjDsp], [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod AND [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z4", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z5", "SELECT [ObjCod] FROM [SGOBJETOS] WHERE [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z6", "SELECT TM1.[ObjTot], TM1.[ObjNew], TM1.[ObjUpd], TM1.[ObjDlt], TM1.[ObjDsp], TM1.[UsuCod], TM1.[ObjCod] FROM [SGUSUARIOSDET] TM1 WHERE TM1.[UsuCod] = @UsuCod and TM1.[ObjCod] = @ObjCod ORDER BY TM1.[UsuCod], TM1.[ObjCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z7", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z8", "SELECT [ObjCod] FROM [SGOBJETOS] WHERE [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z9", "SELECT [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod AND [ObjCod] = @ObjCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z10", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE ( [UsuCod] > @UsuCod or [UsuCod] = @UsuCod and [ObjCod] > @ObjCod) ORDER BY [UsuCod], [ObjCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z11", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE ( [UsuCod] < @UsuCod or [UsuCod] = @UsuCod and [ObjCod] < @ObjCod) ORDER BY [UsuCod] DESC, [ObjCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Z12", "INSERT INTO [SGUSUARIOSDET]([ObjTot], [ObjNew], [ObjUpd], [ObjDlt], [ObjDsp], [UsuCod], [ObjCod]) VALUES(@ObjTot, @ObjNew, @ObjUpd, @ObjDlt, @ObjDsp, @UsuCod, @ObjCod)", GxErrorMask.GX_NOMASK,prmT000Z12)
           ,new CursorDef("T000Z13", "UPDATE [SGUSUARIOSDET] SET [ObjTot]=@ObjTot, [ObjNew]=@ObjNew, [ObjUpd]=@ObjUpd, [ObjDlt]=@ObjDlt, [ObjDsp]=@ObjDsp  WHERE [UsuCod] = @UsuCod AND [ObjCod] = @ObjCod", GxErrorMask.GX_NOMASK,prmT000Z13)
           ,new CursorDef("T000Z14", "DELETE FROM [SGUSUARIOSDET]  WHERE [UsuCod] = @UsuCod AND [ObjCod] = @ObjCod", GxErrorMask.GX_NOMASK,prmT000Z14)
           ,new CursorDef("T000Z15", "SELECT [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] ORDER BY [UsuCod], [ObjCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z16", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Z17", "SELECT [ObjCod] FROM [SGOBJETOS] WHERE [ObjCod] = @ObjCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Z17,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
