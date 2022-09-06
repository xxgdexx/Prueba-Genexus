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
   public class sgnotificacionesdet : GXDataArea
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
            A2237SGNotificacionID = (long)(NumberUtil.Val( GetPar( "SGNotificacionID"), "."));
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2237SGNotificacionID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A2246SGNotificacionDetUsuario = GetPar( "SGNotificacionDetUsuario");
            AssignAttri("", false, "A2246SGNotificacionDetUsuario", A2246SGNotificacionDetUsuario);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A2246SGNotificacionDetUsuario) ;
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
            Form.Meta.addItem("description", "SGNOTIFICACIONESDET", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgnotificacionesdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgnotificacionesdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGNOTIFICACIONESDET", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGNOTIFICACIONESDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGNOTIFICACIONESDET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2237SGNotificacionID), 10, 0, ".", "")), StringUtil.LTrim( ((edtSGNotificacionID_Enabled!=0) ? context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2237SGNotificacionID), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionID_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionDetID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionDetID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionDetID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2245SGNotificacionDetID), 4, 0, ".", "")), StringUtil.LTrim( ((edtSGNotificacionDetID_Enabled!=0) ? context.localUtil.Format( (decimal)(A2245SGNotificacionDetID), "ZZZ9") : context.localUtil.Format( (decimal)(A2245SGNotificacionDetID), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionDetID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionDetID_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionDetUsuario_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionDetUsuario_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionDetUsuario_Internalname, StringUtil.RTrim( A2246SGNotificacionDetUsuario), StringUtil.RTrim( context.localUtil.Format( A2246SGNotificacionDetUsuario, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionDetUsuario_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionDetUsuario_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionDetUsuarioDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionDetUsuarioDsc_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionDetUsuarioDsc_Internalname, StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc), StringUtil.RTrim( context.localUtil.Format( A2247SGNotificacionDetUsuarioDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionDetUsuarioDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionDetUsuarioDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGNotificacionDetEstado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGNotificacionDetEstado_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGNotificacionDetEstado_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2248SGNotificacionDetEstado), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGNotificacionDetEstado_Enabled!=0) ? context.localUtil.Format( (decimal)(A2248SGNotificacionDetEstado), "9") : context.localUtil.Format( (decimal)(A2248SGNotificacionDetEstado), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGNotificacionDetEstado_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGNotificacionDetEstado_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGNOTIFICACIONESDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONESDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGNOTIFICACIONESDET.htm");
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
            Z2237SGNotificacionID = (long)(context.localUtil.CToN( cgiGet( "Z2237SGNotificacionID"), ".", ","));
            Z2245SGNotificacionDetID = (short)(context.localUtil.CToN( cgiGet( "Z2245SGNotificacionDetID"), ".", ","));
            Z2248SGNotificacionDetEstado = (short)(context.localUtil.CToN( cgiGet( "Z2248SGNotificacionDetEstado"), ".", ","));
            Z2246SGNotificacionDetUsuario = cgiGet( "Z2246SGNotificacionDetUsuario");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionID_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGNOTIFICACIONID");
               AnyError = 1;
               GX_FocusControl = edtSGNotificacionID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2237SGNotificacionID = 0;
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            }
            else
            {
               A2237SGNotificacionID = (long)(context.localUtil.CToN( cgiGet( edtSGNotificacionID_Internalname), ".", ","));
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGNOTIFICACIONDETID");
               AnyError = 1;
               GX_FocusControl = edtSGNotificacionDetID_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2245SGNotificacionDetID = 0;
               AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
            }
            else
            {
               A2245SGNotificacionDetID = (short)(context.localUtil.CToN( cgiGet( edtSGNotificacionDetID_Internalname), ".", ","));
               AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
            }
            A2246SGNotificacionDetUsuario = cgiGet( edtSGNotificacionDetUsuario_Internalname);
            AssignAttri("", false, "A2246SGNotificacionDetUsuario", A2246SGNotificacionDetUsuario);
            A2247SGNotificacionDetUsuarioDsc = cgiGet( edtSGNotificacionDetUsuarioDsc_Internalname);
            AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", A2247SGNotificacionDetUsuarioDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetEstado_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGNotificacionDetEstado_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGNOTIFICACIONDETESTADO");
               AnyError = 1;
               GX_FocusControl = edtSGNotificacionDetEstado_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2248SGNotificacionDetEstado = 0;
               AssignAttri("", false, "A2248SGNotificacionDetEstado", StringUtil.Str( (decimal)(A2248SGNotificacionDetEstado), 1, 0));
            }
            else
            {
               A2248SGNotificacionDetEstado = (short)(context.localUtil.CToN( cgiGet( edtSGNotificacionDetEstado_Internalname), ".", ","));
               AssignAttri("", false, "A2248SGNotificacionDetEstado", StringUtil.Str( (decimal)(A2248SGNotificacionDetEstado), 1, 0));
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
               A2237SGNotificacionID = (long)(NumberUtil.Val( GetPar( "SGNotificacionID"), "."));
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               A2245SGNotificacionDetID = (short)(NumberUtil.Val( GetPar( "SGNotificacionDetID"), "."));
               AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
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
               InitAll79199( ) ;
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
         DisableAttributes79199( ) ;
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

      protected void ResetCaption790( )
      {
      }

      protected void ZM79199( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2248SGNotificacionDetEstado = T00793_A2248SGNotificacionDetEstado[0];
               Z2246SGNotificacionDetUsuario = T00793_A2246SGNotificacionDetUsuario[0];
            }
            else
            {
               Z2248SGNotificacionDetEstado = A2248SGNotificacionDetEstado;
               Z2246SGNotificacionDetUsuario = A2246SGNotificacionDetUsuario;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
            Z2248SGNotificacionDetEstado = A2248SGNotificacionDetEstado;
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2246SGNotificacionDetUsuario = A2246SGNotificacionDetUsuario;
            Z2247SGNotificacionDetUsuarioDsc = A2247SGNotificacionDetUsuarioDsc;
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

      protected void Load79199( )
      {
         /* Using cursor T00796 */
         pr_default.execute(4, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound199 = 1;
            A2247SGNotificacionDetUsuarioDsc = T00796_A2247SGNotificacionDetUsuarioDsc[0];
            AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", A2247SGNotificacionDetUsuarioDsc);
            A2248SGNotificacionDetEstado = T00796_A2248SGNotificacionDetEstado[0];
            AssignAttri("", false, "A2248SGNotificacionDetEstado", StringUtil.Str( (decimal)(A2248SGNotificacionDetEstado), 1, 0));
            A2246SGNotificacionDetUsuario = T00796_A2246SGNotificacionDetUsuario[0];
            AssignAttri("", false, "A2246SGNotificacionDetUsuario", A2246SGNotificacionDetUsuario);
            ZM79199( -1) ;
         }
         pr_default.close(4);
         OnLoadActions79199( ) ;
      }

      protected void OnLoadActions79199( )
      {
      }

      protected void CheckExtendedTable79199( )
      {
         nIsDirty_199 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00794 */
         pr_default.execute(2, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'SGNOTIFICACIONES'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00795 */
         pr_default.execute(3, new Object[] {A2246SGNotificacionDetUsuario});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONDETUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2247SGNotificacionDetUsuarioDsc = T00795_A2247SGNotificacionDetUsuarioDsc[0];
         AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", A2247SGNotificacionDetUsuarioDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors79199( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( long A2237SGNotificacionID )
      {
         /* Using cursor T00797 */
         pr_default.execute(5, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'SGNOTIFICACIONES'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
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

      protected void gxLoad_3( string A2246SGNotificacionDetUsuario )
      {
         /* Using cursor T00798 */
         pr_default.execute(6, new Object[] {A2246SGNotificacionDetUsuario});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONDETUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A2247SGNotificacionDetUsuarioDsc = T00798_A2247SGNotificacionDetUsuarioDsc[0];
         AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", A2247SGNotificacionDetUsuarioDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey79199( )
      {
         /* Using cursor T00799 */
         pr_default.execute(7, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound199 = 1;
         }
         else
         {
            RcdFound199 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00793 */
         pr_default.execute(1, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM79199( 1) ;
            RcdFound199 = 1;
            A2245SGNotificacionDetID = T00793_A2245SGNotificacionDetID[0];
            AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
            A2248SGNotificacionDetEstado = T00793_A2248SGNotificacionDetEstado[0];
            AssignAttri("", false, "A2248SGNotificacionDetEstado", StringUtil.Str( (decimal)(A2248SGNotificacionDetEstado), 1, 0));
            A2237SGNotificacionID = T00793_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            A2246SGNotificacionDetUsuario = T00793_A2246SGNotificacionDetUsuario[0];
            AssignAttri("", false, "A2246SGNotificacionDetUsuario", A2246SGNotificacionDetUsuario);
            Z2237SGNotificacionID = A2237SGNotificacionID;
            Z2245SGNotificacionDetID = A2245SGNotificacionDetID;
            sMode199 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load79199( ) ;
            if ( AnyError == 1 )
            {
               RcdFound199 = 0;
               InitializeNonKey79199( ) ;
            }
            Gx_mode = sMode199;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound199 = 0;
            InitializeNonKey79199( ) ;
            sMode199 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode199;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey79199( ) ;
         if ( RcdFound199 == 0 )
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
         RcdFound199 = 0;
         /* Using cursor T007910 */
         pr_default.execute(8, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T007910_A2237SGNotificacionID[0] < A2237SGNotificacionID ) || ( T007910_A2237SGNotificacionID[0] == A2237SGNotificacionID ) && ( T007910_A2245SGNotificacionDetID[0] < A2245SGNotificacionDetID ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T007910_A2237SGNotificacionID[0] > A2237SGNotificacionID ) || ( T007910_A2237SGNotificacionID[0] == A2237SGNotificacionID ) && ( T007910_A2245SGNotificacionDetID[0] > A2245SGNotificacionDetID ) ) )
            {
               A2237SGNotificacionID = T007910_A2237SGNotificacionID[0];
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               A2245SGNotificacionDetID = T007910_A2245SGNotificacionDetID[0];
               AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
               RcdFound199 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound199 = 0;
         /* Using cursor T007911 */
         pr_default.execute(9, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T007911_A2237SGNotificacionID[0] > A2237SGNotificacionID ) || ( T007911_A2237SGNotificacionID[0] == A2237SGNotificacionID ) && ( T007911_A2245SGNotificacionDetID[0] > A2245SGNotificacionDetID ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T007911_A2237SGNotificacionID[0] < A2237SGNotificacionID ) || ( T007911_A2237SGNotificacionID[0] == A2237SGNotificacionID ) && ( T007911_A2245SGNotificacionDetID[0] < A2245SGNotificacionDetID ) ) )
            {
               A2237SGNotificacionID = T007911_A2237SGNotificacionID[0];
               AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
               A2245SGNotificacionDetID = T007911_A2245SGNotificacionDetID[0];
               AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
               RcdFound199 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey79199( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert79199( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound199 == 1 )
            {
               if ( ( A2237SGNotificacionID != Z2237SGNotificacionID ) || ( A2245SGNotificacionDetID != Z2245SGNotificacionDetID ) )
               {
                  A2237SGNotificacionID = Z2237SGNotificacionID;
                  AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
                  A2245SGNotificacionDetID = Z2245SGNotificacionDetID;
                  AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SGNOTIFICACIONID");
                  AnyError = 1;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update79199( ) ;
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A2237SGNotificacionID != Z2237SGNotificacionID ) || ( A2245SGNotificacionDetID != Z2245SGNotificacionDetID ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSGNotificacionID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert79199( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SGNOTIFICACIONID");
                     AnyError = 1;
                     GX_FocusControl = edtSGNotificacionID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSGNotificacionID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert79199( ) ;
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
         if ( ( A2237SGNotificacionID != Z2237SGNotificacionID ) || ( A2245SGNotificacionDetID != Z2245SGNotificacionDetID ) )
         {
            A2237SGNotificacionID = Z2237SGNotificacionID;
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            A2245SGNotificacionDetID = Z2245SGNotificacionDetID;
            AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSGNotificacionID_Internalname;
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
         if ( RcdFound199 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart79199( ) ;
         if ( RcdFound199 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd79199( ) ;
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
         if ( RcdFound199 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
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
         if ( RcdFound199 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
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
         ScanStart79199( ) ;
         if ( RcdFound199 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound199 != 0 )
            {
               ScanNext79199( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd79199( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency79199( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00792 */
            pr_default.execute(0, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z2248SGNotificacionDetEstado != T00792_A2248SGNotificacionDetEstado[0] ) || ( StringUtil.StrCmp(Z2246SGNotificacionDetUsuario, T00792_A2246SGNotificacionDetUsuario[0]) != 0 ) )
            {
               if ( Z2248SGNotificacionDetEstado != T00792_A2248SGNotificacionDetEstado[0] )
               {
                  GXUtil.WriteLog("sgnotificacionesdet:[seudo value changed for attri]"+"SGNotificacionDetEstado");
                  GXUtil.WriteLogRaw("Old: ",Z2248SGNotificacionDetEstado);
                  GXUtil.WriteLogRaw("Current: ",T00792_A2248SGNotificacionDetEstado[0]);
               }
               if ( StringUtil.StrCmp(Z2246SGNotificacionDetUsuario, T00792_A2246SGNotificacionDetUsuario[0]) != 0 )
               {
                  GXUtil.WriteLog("sgnotificacionesdet:[seudo value changed for attri]"+"SGNotificacionDetUsuario");
                  GXUtil.WriteLogRaw("Old: ",Z2246SGNotificacionDetUsuario);
                  GXUtil.WriteLogRaw("Current: ",T00792_A2246SGNotificacionDetUsuario[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert79199( )
      {
         BeforeValidate79199( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable79199( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM79199( 0) ;
            CheckOptimisticConcurrency79199( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm79199( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert79199( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007912 */
                     pr_default.execute(10, new Object[] {A2245SGNotificacionDetID, A2248SGNotificacionDetEstado, A2237SGNotificacionID, A2246SGNotificacionDetUsuario});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
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
                           ResetCaption790( ) ;
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
               Load79199( ) ;
            }
            EndLevel79199( ) ;
         }
         CloseExtendedTableCursors79199( ) ;
      }

      protected void Update79199( )
      {
         BeforeValidate79199( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable79199( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency79199( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm79199( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate79199( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007913 */
                     pr_default.execute(11, new Object[] {A2248SGNotificacionDetEstado, A2246SGNotificacionDetUsuario, A2237SGNotificacionID, A2245SGNotificacionDetID});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGNOTIFICACIONESDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate79199( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption790( ) ;
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
            EndLevel79199( ) ;
         }
         CloseExtendedTableCursors79199( ) ;
      }

      protected void DeferredUpdate79199( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate79199( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency79199( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls79199( ) ;
            AfterConfirm79199( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete79199( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007914 */
                  pr_default.execute(12, new Object[] {A2237SGNotificacionID, A2245SGNotificacionDetID});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("SGNOTIFICACIONESDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound199 == 0 )
                        {
                           InitAll79199( ) ;
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
                        ResetCaption790( ) ;
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
         sMode199 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel79199( ) ;
         Gx_mode = sMode199;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls79199( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T007915 */
            pr_default.execute(13, new Object[] {A2246SGNotificacionDetUsuario});
            A2247SGNotificacionDetUsuarioDsc = T007915_A2247SGNotificacionDetUsuarioDsc[0];
            AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", A2247SGNotificacionDetUsuarioDsc);
            pr_default.close(13);
         }
      }

      protected void EndLevel79199( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete79199( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("sgnotificacionesdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues790( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("sgnotificacionesdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart79199( )
      {
         /* Using cursor T007916 */
         pr_default.execute(14);
         RcdFound199 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound199 = 1;
            A2237SGNotificacionID = T007916_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            A2245SGNotificacionDetID = T007916_A2245SGNotificacionDetID[0];
            AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext79199( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound199 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound199 = 1;
            A2237SGNotificacionID = T007916_A2237SGNotificacionID[0];
            AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
            A2245SGNotificacionDetID = T007916_A2245SGNotificacionDetID[0];
            AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
         }
      }

      protected void ScanEnd79199( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm79199( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert79199( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate79199( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete79199( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete79199( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate79199( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes79199( )
      {
         edtSGNotificacionID_Enabled = 0;
         AssignProp("", false, edtSGNotificacionID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionID_Enabled), 5, 0), true);
         edtSGNotificacionDetID_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetID_Enabled), 5, 0), true);
         edtSGNotificacionDetUsuario_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetUsuario_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetUsuario_Enabled), 5, 0), true);
         edtSGNotificacionDetUsuarioDsc_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetUsuarioDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetUsuarioDsc_Enabled), 5, 0), true);
         edtSGNotificacionDetEstado_Enabled = 0;
         AssignProp("", false, edtSGNotificacionDetEstado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGNotificacionDetEstado_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes79199( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues790( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027218", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgnotificacionesdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2237SGNotificacionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2237SGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2245SGNotificacionDetID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2245SGNotificacionDetID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2248SGNotificacionDetEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2248SGNotificacionDetEstado), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2246SGNotificacionDetUsuario", StringUtil.RTrim( Z2246SGNotificacionDetUsuario));
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
         return formatLink("sgnotificacionesdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGNOTIFICACIONESDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGNOTIFICACIONESDET" ;
      }

      protected void InitializeNonKey79199( )
      {
         A2246SGNotificacionDetUsuario = "";
         AssignAttri("", false, "A2246SGNotificacionDetUsuario", A2246SGNotificacionDetUsuario);
         A2247SGNotificacionDetUsuarioDsc = "";
         AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", A2247SGNotificacionDetUsuarioDsc);
         A2248SGNotificacionDetEstado = 0;
         AssignAttri("", false, "A2248SGNotificacionDetEstado", StringUtil.Str( (decimal)(A2248SGNotificacionDetEstado), 1, 0));
         Z2248SGNotificacionDetEstado = 0;
         Z2246SGNotificacionDetUsuario = "";
      }

      protected void InitAll79199( )
      {
         A2237SGNotificacionID = 0;
         AssignAttri("", false, "A2237SGNotificacionID", StringUtil.LTrimStr( (decimal)(A2237SGNotificacionID), 10, 0));
         A2245SGNotificacionDetID = 0;
         AssignAttri("", false, "A2245SGNotificacionDetID", StringUtil.LTrimStr( (decimal)(A2245SGNotificacionDetID), 4, 0));
         InitializeNonKey79199( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027224", true, true);
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
         context.AddJavascriptSource("sgnotificacionesdet.js", "?20228181027224", false, true);
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
         edtSGNotificacionID_Internalname = "SGNOTIFICACIONID";
         edtSGNotificacionDetID_Internalname = "SGNOTIFICACIONDETID";
         edtSGNotificacionDetUsuario_Internalname = "SGNOTIFICACIONDETUSUARIO";
         edtSGNotificacionDetUsuarioDsc_Internalname = "SGNOTIFICACIONDETUSUARIODSC";
         edtSGNotificacionDetEstado_Internalname = "SGNOTIFICACIONDETESTADO";
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
         Form.Caption = "SGNOTIFICACIONESDET";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSGNotificacionDetEstado_Jsonclick = "";
         edtSGNotificacionDetEstado_Enabled = 1;
         edtSGNotificacionDetUsuarioDsc_Jsonclick = "";
         edtSGNotificacionDetUsuarioDsc_Enabled = 0;
         edtSGNotificacionDetUsuario_Jsonclick = "";
         edtSGNotificacionDetUsuario_Enabled = 1;
         edtSGNotificacionDetID_Jsonclick = "";
         edtSGNotificacionDetID_Enabled = 1;
         edtSGNotificacionID_Jsonclick = "";
         edtSGNotificacionID_Enabled = 1;
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
         /* Using cursor T007917 */
         pr_default.execute(15, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'SGNOTIFICACIONES'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
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

      public void Valid_Sgnotificacionid( )
      {
         /* Using cursor T007917 */
         pr_default.execute(15, new Object[] {A2237SGNotificacionID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'SGNOTIFICACIONES'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONID");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionID_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sgnotificaciondetid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2246SGNotificacionDetUsuario", StringUtil.RTrim( A2246SGNotificacionDetUsuario));
         AssignAttri("", false, "A2248SGNotificacionDetEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2248SGNotificacionDetEstado), 1, 0, ".", "")));
         AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2237SGNotificacionID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2237SGNotificacionID), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2245SGNotificacionDetID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2245SGNotificacionDetID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2246SGNotificacionDetUsuario", StringUtil.RTrim( Z2246SGNotificacionDetUsuario));
         GxWebStd.gx_hidden_field( context, "Z2248SGNotificacionDetEstado", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2248SGNotificacionDetEstado), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2247SGNotificacionDetUsuarioDsc", StringUtil.RTrim( Z2247SGNotificacionDetUsuarioDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Sgnotificaciondetusuario( )
      {
         /* Using cursor T007915 */
         pr_default.execute(13, new Object[] {A2246SGNotificacionDetUsuario});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Usuario'.", "ForeignKeyNotFound", 1, "SGNOTIFICACIONDETUSUARIO");
            AnyError = 1;
            GX_FocusControl = edtSGNotificacionDetUsuario_Internalname;
         }
         A2247SGNotificacionDetUsuarioDsc = T007915_A2247SGNotificacionDetUsuarioDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2247SGNotificacionDetUsuarioDsc", StringUtil.RTrim( A2247SGNotificacionDetUsuarioDsc));
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
         setEventMetadata("VALID_SGNOTIFICACIONID","{handler:'Valid_Sgnotificacionid',iparms:[{av:'A2237SGNotificacionID',fld:'SGNOTIFICACIONID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("VALID_SGNOTIFICACIONID",",oparms:[]}");
         setEventMetadata("VALID_SGNOTIFICACIONDETID","{handler:'Valid_Sgnotificaciondetid',iparms:[{av:'A2237SGNotificacionID',fld:'SGNOTIFICACIONID',pic:'ZZZZZZZZZ9'},{av:'A2245SGNotificacionDetID',fld:'SGNOTIFICACIONDETID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGNOTIFICACIONDETID",",oparms:[{av:'A2246SGNotificacionDetUsuario',fld:'SGNOTIFICACIONDETUSUARIO',pic:''},{av:'A2248SGNotificacionDetEstado',fld:'SGNOTIFICACIONDETESTADO',pic:'9'},{av:'A2247SGNotificacionDetUsuarioDsc',fld:'SGNOTIFICACIONDETUSUARIODSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2237SGNotificacionID'},{av:'Z2245SGNotificacionDetID'},{av:'Z2246SGNotificacionDetUsuario'},{av:'Z2248SGNotificacionDetEstado'},{av:'Z2247SGNotificacionDetUsuarioDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SGNOTIFICACIONDETUSUARIO","{handler:'Valid_Sgnotificaciondetusuario',iparms:[{av:'A2246SGNotificacionDetUsuario',fld:'SGNOTIFICACIONDETUSUARIO',pic:''},{av:'A2247SGNotificacionDetUsuarioDsc',fld:'SGNOTIFICACIONDETUSUARIODSC',pic:''}]");
         setEventMetadata("VALID_SGNOTIFICACIONDETUSUARIO",",oparms:[{av:'A2247SGNotificacionDetUsuarioDsc',fld:'SGNOTIFICACIONDETUSUARIODSC',pic:''}]}");
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
         pr_default.close(15);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2246SGNotificacionDetUsuario = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2246SGNotificacionDetUsuario = "";
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
         A2247SGNotificacionDetUsuarioDsc = "";
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
         Z2247SGNotificacionDetUsuarioDsc = "";
         T00796_A2245SGNotificacionDetID = new short[1] ;
         T00796_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T00796_A2248SGNotificacionDetEstado = new short[1] ;
         T00796_A2237SGNotificacionID = new long[1] ;
         T00796_A2246SGNotificacionDetUsuario = new string[] {""} ;
         T00794_A2237SGNotificacionID = new long[1] ;
         T00795_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T00797_A2237SGNotificacionID = new long[1] ;
         T00798_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T00799_A2237SGNotificacionID = new long[1] ;
         T00799_A2245SGNotificacionDetID = new short[1] ;
         T00793_A2245SGNotificacionDetID = new short[1] ;
         T00793_A2248SGNotificacionDetEstado = new short[1] ;
         T00793_A2237SGNotificacionID = new long[1] ;
         T00793_A2246SGNotificacionDetUsuario = new string[] {""} ;
         sMode199 = "";
         T007910_A2237SGNotificacionID = new long[1] ;
         T007910_A2245SGNotificacionDetID = new short[1] ;
         T007911_A2237SGNotificacionID = new long[1] ;
         T007911_A2245SGNotificacionDetID = new short[1] ;
         T00792_A2245SGNotificacionDetID = new short[1] ;
         T00792_A2248SGNotificacionDetEstado = new short[1] ;
         T00792_A2237SGNotificacionID = new long[1] ;
         T00792_A2246SGNotificacionDetUsuario = new string[] {""} ;
         T007915_A2247SGNotificacionDetUsuarioDsc = new string[] {""} ;
         T007916_A2237SGNotificacionID = new long[1] ;
         T007916_A2245SGNotificacionDetID = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007917_A2237SGNotificacionID = new long[1] ;
         ZZ2246SGNotificacionDetUsuario = "";
         ZZ2247SGNotificacionDetUsuarioDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgnotificacionesdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgnotificacionesdet__default(),
            new Object[][] {
                new Object[] {
               T00792_A2245SGNotificacionDetID, T00792_A2248SGNotificacionDetEstado, T00792_A2237SGNotificacionID, T00792_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               T00793_A2245SGNotificacionDetID, T00793_A2248SGNotificacionDetEstado, T00793_A2237SGNotificacionID, T00793_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               T00794_A2237SGNotificacionID
               }
               , new Object[] {
               T00795_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               T00796_A2245SGNotificacionDetID, T00796_A2247SGNotificacionDetUsuarioDsc, T00796_A2248SGNotificacionDetEstado, T00796_A2237SGNotificacionID, T00796_A2246SGNotificacionDetUsuario
               }
               , new Object[] {
               T00797_A2237SGNotificacionID
               }
               , new Object[] {
               T00798_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               T00799_A2237SGNotificacionID, T00799_A2245SGNotificacionDetID
               }
               , new Object[] {
               T007910_A2237SGNotificacionID, T007910_A2245SGNotificacionDetID
               }
               , new Object[] {
               T007911_A2237SGNotificacionID, T007911_A2245SGNotificacionDetID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007915_A2247SGNotificacionDetUsuarioDsc
               }
               , new Object[] {
               T007916_A2237SGNotificacionID, T007916_A2245SGNotificacionDetID
               }
               , new Object[] {
               T007917_A2237SGNotificacionID
               }
            }
         );
      }

      private short Z2245SGNotificacionDetID ;
      private short Z2248SGNotificacionDetEstado ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2245SGNotificacionDetID ;
      private short A2248SGNotificacionDetEstado ;
      private short GX_JID ;
      private short RcdFound199 ;
      private short nIsDirty_199 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2245SGNotificacionDetID ;
      private short ZZ2248SGNotificacionDetEstado ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSGNotificacionID_Enabled ;
      private int edtSGNotificacionDetID_Enabled ;
      private int edtSGNotificacionDetUsuario_Enabled ;
      private int edtSGNotificacionDetUsuarioDsc_Enabled ;
      private int edtSGNotificacionDetEstado_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z2237SGNotificacionID ;
      private long A2237SGNotificacionID ;
      private long ZZ2237SGNotificacionID ;
      private string sPrefix ;
      private string Z2246SGNotificacionDetUsuario ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A2246SGNotificacionDetUsuario ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSGNotificacionID_Internalname ;
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
      private string edtSGNotificacionID_Jsonclick ;
      private string edtSGNotificacionDetID_Internalname ;
      private string edtSGNotificacionDetID_Jsonclick ;
      private string edtSGNotificacionDetUsuario_Internalname ;
      private string edtSGNotificacionDetUsuario_Jsonclick ;
      private string edtSGNotificacionDetUsuarioDsc_Internalname ;
      private string A2247SGNotificacionDetUsuarioDsc ;
      private string edtSGNotificacionDetUsuarioDsc_Jsonclick ;
      private string edtSGNotificacionDetEstado_Internalname ;
      private string edtSGNotificacionDetEstado_Jsonclick ;
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
      private string Z2247SGNotificacionDetUsuarioDsc ;
      private string sMode199 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2246SGNotificacionDetUsuario ;
      private string ZZ2247SGNotificacionDetUsuarioDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00796_A2245SGNotificacionDetID ;
      private string[] T00796_A2247SGNotificacionDetUsuarioDsc ;
      private short[] T00796_A2248SGNotificacionDetEstado ;
      private long[] T00796_A2237SGNotificacionID ;
      private string[] T00796_A2246SGNotificacionDetUsuario ;
      private long[] T00794_A2237SGNotificacionID ;
      private string[] T00795_A2247SGNotificacionDetUsuarioDsc ;
      private long[] T00797_A2237SGNotificacionID ;
      private string[] T00798_A2247SGNotificacionDetUsuarioDsc ;
      private long[] T00799_A2237SGNotificacionID ;
      private short[] T00799_A2245SGNotificacionDetID ;
      private short[] T00793_A2245SGNotificacionDetID ;
      private short[] T00793_A2248SGNotificacionDetEstado ;
      private long[] T00793_A2237SGNotificacionID ;
      private string[] T00793_A2246SGNotificacionDetUsuario ;
      private long[] T007910_A2237SGNotificacionID ;
      private short[] T007910_A2245SGNotificacionDetID ;
      private long[] T007911_A2237SGNotificacionID ;
      private short[] T007911_A2245SGNotificacionDetID ;
      private short[] T00792_A2245SGNotificacionDetID ;
      private short[] T00792_A2248SGNotificacionDetEstado ;
      private long[] T00792_A2237SGNotificacionID ;
      private string[] T00792_A2246SGNotificacionDetUsuario ;
      private string[] T007915_A2247SGNotificacionDetUsuarioDsc ;
      private long[] T007916_A2237SGNotificacionID ;
      private short[] T007916_A2245SGNotificacionDetID ;
      private long[] T007917_A2237SGNotificacionID ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgnotificacionesdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgnotificacionesdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00796;
        prmT00796 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT00794;
        prmT00794 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT00795;
        prmT00795 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmT00797;
        prmT00797 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT00798;
        prmT00798 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmT00799;
        prmT00799 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT00793;
        prmT00793 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007910;
        prmT007910 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007911;
        prmT007911 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT00792;
        prmT00792 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007912;
        prmT007912 = new Object[] {
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0) ,
        new ParDef("@SGNotificacionDetEstado",GXType.Int16,1,0) ,
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        Object[] prmT007913;
        prmT007913 = new Object[] {
        new ParDef("@SGNotificacionDetEstado",GXType.Int16,1,0) ,
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0) ,
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007914;
        prmT007914 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0) ,
        new ParDef("@SGNotificacionDetID",GXType.Int16,4,0)
        };
        Object[] prmT007916;
        prmT007916 = new Object[] {
        };
        Object[] prmT007917;
        prmT007917 = new Object[] {
        new ParDef("@SGNotificacionID",GXType.Decimal,10,0)
        };
        Object[] prmT007915;
        prmT007915 = new Object[] {
        new ParDef("@SGNotificacionDetUsuario",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00792", "SELECT [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionID], [SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM [SGNOTIFICACIONESDET] WITH (UPDLOCK) WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00792,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00793", "SELECT [SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionID], [SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00793,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00794", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00794,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00795", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT00795,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00796", "SELECT TM1.[SGNotificacionDetID], T2.[UsuNom] AS SGNotificacionDetUsuarioDsc, TM1.[SGNotificacionDetEstado], TM1.[SGNotificacionID], TM1.[SGNotificacionDetUsuario] AS SGNotificacionDetUsuario FROM ([SGNOTIFICACIONESDET] TM1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = TM1.[SGNotificacionDetUsuario]) WHERE TM1.[SGNotificacionID] = @SGNotificacionID and TM1.[SGNotificacionDetID] = @SGNotificacionDetID ORDER BY TM1.[SGNotificacionID], TM1.[SGNotificacionDetID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00796,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00797", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00797,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00798", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT00798,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00799", "SELECT [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00799,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007910", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE ( [SGNotificacionID] > @SGNotificacionID or [SGNotificacionID] = @SGNotificacionID and [SGNotificacionDetID] > @SGNotificacionDetID) ORDER BY [SGNotificacionID], [SGNotificacionDetID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007910,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007911", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE ( [SGNotificacionID] < @SGNotificacionID or [SGNotificacionID] = @SGNotificacionID and [SGNotificacionDetID] < @SGNotificacionDetID) ORDER BY [SGNotificacionID] DESC, [SGNotificacionDetID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007911,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007912", "INSERT INTO [SGNOTIFICACIONESDET]([SGNotificacionDetID], [SGNotificacionDetEstado], [SGNotificacionID], [SGNotificacionDetUsuario]) VALUES(@SGNotificacionDetID, @SGNotificacionDetEstado, @SGNotificacionID, @SGNotificacionDetUsuario)", GxErrorMask.GX_NOMASK,prmT007912)
           ,new CursorDef("T007913", "UPDATE [SGNOTIFICACIONESDET] SET [SGNotificacionDetEstado]=@SGNotificacionDetEstado, [SGNotificacionDetUsuario]=@SGNotificacionDetUsuario  WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID", GxErrorMask.GX_NOMASK,prmT007913)
           ,new CursorDef("T007914", "DELETE FROM [SGNOTIFICACIONESDET]  WHERE [SGNotificacionID] = @SGNotificacionID AND [SGNotificacionDetID] = @SGNotificacionDetID", GxErrorMask.GX_NOMASK,prmT007914)
           ,new CursorDef("T007915", "SELECT [UsuNom] AS SGNotificacionDetUsuarioDsc FROM [SGUSUARIOS] WHERE [UsuCod] = @SGNotificacionDetUsuario ",true, GxErrorMask.GX_NOMASK, false, this,prmT007915,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007916", "SELECT [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] ORDER BY [SGNotificacionID], [SGNotificacionDetID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007916,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007917", "SELECT [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionID] = @SGNotificacionID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007917,1, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
