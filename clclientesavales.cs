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
   public class clclientesavales : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridclclientesavales_level1") == 0 )
         {
            nRC_GXsfl_39 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_39"), "."));
            nGXsfl_39_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_39_idx"), "."));
            sGXsfl_39_idx = GetPar( "sGXsfl_39_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridclclientesavales_level1_newrow( ) ;
            return  ;
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
            Form.Meta.addItem("description", "CLCLIENTESAVALES", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clclientesavales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clclientesavales( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CLCLIENTESAVALES", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESAVALES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCLIENTESAVALES.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliCod_Internalname, "Codigo Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliDTAval_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliDTAval_Internalname, "Aval", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDTAval_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A608CliDTAval), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliDTAval_Enabled!=0) ? context.localUtil.Format( (decimal)(A608CliDTAval), "ZZZZZ9") : context.localUtil.Format( (decimal)(A608CliDTAval), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDTAval_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDTAval_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlelevel1_Internalname, "Level1", "", "", lblTitlelevel1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridclclientesavales_level1( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESAVALES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridclclientesavales_level1( )
      {
         /*  Grid Control  */
         Gridclclientesavales_level1Container.AddObjectProperty("GridName", "Gridclclientesavales_level1");
         Gridclclientesavales_level1Container.AddObjectProperty("Header", subGridclclientesavales_level1_Header);
         Gridclclientesavales_level1Container.AddObjectProperty("Class", "Grid");
         Gridclclientesavales_level1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Backcolorstyle), 1, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("CmpContext", "");
         Gridclclientesavales_level1Container.AddObjectProperty("InMasterPage", "false");
         Gridclclientesavales_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclclientesavales_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A162CliDAval), 6, 0, ".", "")));
         Gridclclientesavales_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAval_Enabled), 5, 0, ".", "")));
         Gridclclientesavales_level1Container.AddColumnProperties(Gridclclientesavales_level1Column);
         Gridclclientesavales_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclclientesavales_level1Column.AddObjectProperty("Value", A594CliDAValRUC);
         Gridclclientesavales_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAValRUC_Enabled), 5, 0, ".", "")));
         Gridclclientesavales_level1Container.AddColumnProperties(Gridclclientesavales_level1Column);
         Gridclclientesavales_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclclientesavales_level1Column.AddObjectProperty("Value", A593CliDAvalDsc);
         Gridclclientesavales_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDsc_Enabled), 5, 0, ".", "")));
         Gridclclientesavales_level1Container.AddColumnProperties(Gridclclientesavales_level1Column);
         Gridclclientesavales_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclclientesavales_level1Column.AddObjectProperty("Value", A592CliDAvalDir);
         Gridclclientesavales_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDir_Enabled), 5, 0, ".", "")));
         Gridclclientesavales_level1Container.AddColumnProperties(Gridclclientesavales_level1Column);
         Gridclclientesavales_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclclientesavales_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A595CliDAvalSts), 1, 0, ".", "")));
         Gridclclientesavales_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalSts_Enabled), 5, 0, ".", "")));
         Gridclclientesavales_level1Container.AddColumnProperties(Gridclclientesavales_level1Column);
         Gridclclientesavales_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Selectedindex), 4, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Allowselection), 1, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Selectioncolor), 9, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Allowhovering), 1, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridclclientesavales_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclclientesavales_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_39_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount12 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_12 = 1;
               ScanStart0B12( ) ;
               while ( RcdFound12 != 0 )
               {
                  init_level_properties12( ) ;
                  getByPrimaryKey0B12( ) ;
                  AddRow0B12( ) ;
                  ScanNext0B12( ) ;
               }
               ScanEnd0B12( ) ;
               nBlankRcdCount12 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0B12( ) ;
            standaloneModal0B12( ) ;
            sMode12 = Gx_mode;
            while ( nGXsfl_39_idx < nRC_GXsfl_39 )
            {
               bGXsfl_39_Refreshing = true;
               ReadRow0B12( ) ;
               edtCliDAval_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVAL_"+sGXsfl_39_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDAval_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAval_Enabled), 5, 0), !bGXsfl_39_Refreshing);
               edtCliDAValRUC_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALRUC_"+sGXsfl_39_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDAValRUC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAValRUC_Enabled), 5, 0), !bGXsfl_39_Refreshing);
               edtCliDAvalDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALDSC_"+sGXsfl_39_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDAvalDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAvalDsc_Enabled), 5, 0), !bGXsfl_39_Refreshing);
               edtCliDAvalDir_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALDIR_"+sGXsfl_39_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDAvalDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAvalDir_Enabled), 5, 0), !bGXsfl_39_Refreshing);
               edtCliDAvalSts_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALSTS_"+sGXsfl_39_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCliDAvalSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAvalSts_Enabled), 5, 0), !bGXsfl_39_Refreshing);
               if ( ( nRcdExists_12 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0B12( ) ;
               }
               SendRow0B12( ) ;
               bGXsfl_39_Refreshing = false;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount12 = 5;
            nRcdExists_12 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0B12( ) ;
               while ( RcdFound12 != 0 )
               {
                  sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3912( ) ;
                  init_level_properties12( ) ;
                  standaloneNotModal0B12( ) ;
                  getByPrimaryKey0B12( ) ;
                  standaloneModal0B12( ) ;
                  AddRow0B12( ) ;
                  ScanNext0B12( ) ;
               }
               ScanEnd0B12( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode12 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx+1), 4, 0), 4, "0");
         SubsflControlProps_3912( ) ;
         InitAll0B12( ) ;
         init_level_properties12( ) ;
         nRcdExists_12 = 0;
         nIsMod_12 = 0;
         nRcdDeleted_12 = 0;
         nBlankRcdCount12 = (short)(nBlankRcdUsr12+nBlankRcdCount12);
         fRowAdded = 0;
         while ( nBlankRcdCount12 > 0 )
         {
            standaloneNotModal0B12( ) ;
            standaloneModal0B12( ) ;
            AddRow0B12( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtCliDAval_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount12 = (short)(nBlankRcdCount12-1);
         }
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridclclientesavales_level1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridclclientesavales_level1", Gridclclientesavales_level1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridclclientesavales_level1ContainerData", Gridclclientesavales_level1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridclclientesavales_level1ContainerData"+"V", Gridclclientesavales_level1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridclclientesavales_level1ContainerData"+"V"+"\" value='"+Gridclclientesavales_level1Container.GridValuesHidden()+"'/>") ;
         }
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
            Z45CliCod = cgiGet( "Z45CliCod");
            Z608CliDTAval = (int)(context.localUtil.CToN( cgiGet( "Z608CliDTAval"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_39 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_39"), ".", ","));
            /* Read variables values. */
            A45CliCod = cgiGet( edtCliCod_Internalname);
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCliDTAval_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDTAval_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIDTAVAL");
               AnyError = 1;
               GX_FocusControl = edtCliDTAval_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A608CliDTAval = 0;
               AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
            }
            else
            {
               A608CliDTAval = (int)(context.localUtil.CToN( cgiGet( edtCliDTAval_Internalname), ".", ","));
               AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A45CliCod = GetPar( "CliCod");
               n45CliCod = false;
               AssignAttri("", false, "A45CliCod", A45CliCod);
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll0B11( ) ;
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
         DisableAttributes0B11( ) ;
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

      protected void CONFIRM_0B12( )
      {
         nGXsfl_39_idx = 0;
         while ( nGXsfl_39_idx < nRC_GXsfl_39 )
         {
            ReadRow0B12( ) ;
            if ( ( nRcdExists_12 != 0 ) || ( nIsMod_12 != 0 ) )
            {
               GetKey0B12( ) ;
               if ( ( nRcdExists_12 == 0 ) && ( nRcdDeleted_12 == 0 ) )
               {
                  if ( RcdFound12 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0B12( ) ;
                        CloseExtendedTableCursors0B12( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "CLIDAVAL_" + sGXsfl_39_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtCliDAval_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( nRcdDeleted_12 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0B12( ) ;
                        Load0B12( ) ;
                        BeforeValidate0B12( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0B12( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0B12( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0B12( ) ;
                              CloseExtendedTableCursors0B12( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_12 == 0 )
                     {
                        GXCCtl = "CLIDAVAL_" + sGXsfl_39_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCliDAval_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCliDAval_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A162CliDAval), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliDAValRUC_Internalname, A594CliDAValRUC) ;
            ChangePostValue( edtCliDAvalDsc_Internalname, A593CliDAvalDsc) ;
            ChangePostValue( edtCliDAvalDir_Internalname, A592CliDAvalDir) ;
            ChangePostValue( edtCliDAvalSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A595CliDAvalSts), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z162CliDAval_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z162CliDAval), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z594CliDAValRUC_"+sGXsfl_39_idx, Z594CliDAValRUC) ;
            ChangePostValue( "ZT_"+"Z593CliDAvalDsc_"+sGXsfl_39_idx, Z593CliDAvalDsc) ;
            ChangePostValue( "ZT_"+"Z592CliDAvalDir_"+sGXsfl_39_idx, Z592CliDAvalDir) ;
            ChangePostValue( "ZT_"+"Z595CliDAvalSts_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z595CliDAvalSts), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "CLIDAVAL_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAval_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALRUC_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAValRUC_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALDSC_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALDIR_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDir_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALSTS_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalSts_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0B0( )
      {
      }

      protected void ZM0B11( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z608CliDTAval = T000B5_A608CliDTAval[0];
            }
            else
            {
               Z608CliDTAval = A608CliDTAval;
            }
         }
         if ( GX_JID == -1 )
         {
            Z45CliCod = A45CliCod;
            Z608CliDTAval = A608CliDTAval;
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

      protected void Load0B11( )
      {
         /* Using cursor T000B6 */
         pr_default.execute(4, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound11 = 1;
            A608CliDTAval = T000B6_A608CliDTAval[0];
            AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
            ZM0B11( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0B11( ) ;
      }

      protected void OnLoadActions0B11( )
      {
      }

      protected void CheckExtendedTable0B11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0B11( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B11( )
      {
         /* Using cursor T000B7 */
         pr_default.execute(5, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000B5 */
         pr_default.execute(3, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0B11( 1) ;
            RcdFound11 = 1;
            A45CliCod = T000B5_A45CliCod[0];
            n45CliCod = T000B5_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A608CliDTAval = T000B5_A608CliDTAval[0];
            AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
            Z45CliCod = A45CliCod;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0B11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0B11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0B11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B11( ) ;
         if ( RcdFound11 == 0 )
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
         RcdFound11 = 0;
         /* Using cursor T000B8 */
         pr_default.execute(6, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000B8_A45CliCod[0], A45CliCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000B8_A45CliCod[0], A45CliCod) > 0 ) ) )
            {
               A45CliCod = T000B8_A45CliCod[0];
               n45CliCod = T000B8_n45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               RcdFound11 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000B9 */
         pr_default.execute(7, new Object[] {n45CliCod, A45CliCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000B9_A45CliCod[0], A45CliCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000B9_A45CliCod[0], A45CliCod) < 0 ) ) )
            {
               A45CliCod = T000B9_A45CliCod[0];
               n45CliCod = T000B9_n45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               RcdFound11 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0B11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0B11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
               {
                  A45CliCod = Z45CliCod;
                  n45CliCod = false;
                  AssignAttri("", false, "A45CliCod", A45CliCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLICOD");
                  AnyError = 1;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0B11( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0B11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLICOD");
                     AnyError = 1;
                     GX_FocusControl = edtCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0B11( ) ;
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
         if ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 )
         {
            A45CliCod = Z45CliCod;
            n45CliCod = false;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCliCod_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCliDTAval_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDTAval_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B11( ) ;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDTAval_Internalname;
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
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDTAval_Internalname;
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
         ScanStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound11 != 0 )
            {
               ScanNext0B11( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDTAval_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0B11( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0B11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B4 */
            pr_default.execute(2, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(2) == 101) || ( Z608CliDTAval != T000B4_A608CliDTAval[0] ) )
            {
               if ( Z608CliDTAval != T000B4_A608CliDTAval[0] )
               {
                  GXUtil.WriteLog("clclientesavales:[seudo value changed for attri]"+"CliDTAval");
                  GXUtil.WriteLogRaw("Old: ",Z608CliDTAval);
                  GXUtil.WriteLogRaw("Current: ",T000B4_A608CliDTAval[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B11( 0) ;
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B10 */
                     pr_default.execute(8, new Object[] {n45CliCod, A45CliCod, A608CliDTAval});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
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
                           ProcessLevel0B11( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0B0( ) ;
                           }
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
               Load0B11( ) ;
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void Update0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B11 */
                     pr_default.execute(9, new Object[] {A608CliDTAval, n45CliCod, A45CliCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B11( ) ;
                     if ( AnyError == 0 )
                     {
                        new clclientesupdateredundancy(context ).execute( ref  A45CliCod) ;
                        AssignAttri("", false, "A45CliCod", A45CliCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0B11( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption0B0( ) ;
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
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void DeferredUpdate0B11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B11( ) ;
            AfterConfirm0B11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B11( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0B12( ) ;
                  while ( RcdFound12 != 0 )
                  {
                     getByPrimaryKey0B12( ) ;
                     Delete0B12( ) ;
                     ScanNext0B12( ) ;
                  }
                  ScanEnd0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B12 */
                     pr_default.execute(10, new Object[] {n45CliCod, A45CliCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTES");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound11 == 0 )
                           {
                              InitAll0B11( ) ;
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
                           ResetCaption0B0( ) ;
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
         }
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B11( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000B13 */
            pr_default.execute(11, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000B14 */
            pr_default.execute(12, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000B15 */
            pr_default.execute(13, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Comprobantes de Percepción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000B16 */
            pr_default.execute(14, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T000B17 */
            pr_default.execute(15, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T000B18 */
            pr_default.execute(16, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000B19 */
            pr_default.execute(17, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000B20 */
            pr_default.execute(18, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000B21 */
            pr_default.execute(19, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T000B22 */
            pr_default.execute(20, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T000B23 */
            pr_default.execute(21, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T000B24 */
            pr_default.execute(22, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Vehiculos Placas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T000B25 */
            pr_default.execute(23, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Clientes Direcciones"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000B26 */
            pr_default.execute(24, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Clientes Contacto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T000B27 */
            pr_default.execute(25, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Descuentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T000B28 */
            pr_default.execute(26, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seguimiento de Consignacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T000B29 */
            pr_default.execute(27, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T000B30 */
            pr_default.execute(28, new Object[] {n45CliCod, A45CliCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Cliente"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
         }
      }

      protected void ProcessNestedLevel0B12( )
      {
         nGXsfl_39_idx = 0;
         while ( nGXsfl_39_idx < nRC_GXsfl_39 )
         {
            ReadRow0B12( ) ;
            if ( ( nRcdExists_12 != 0 ) || ( nIsMod_12 != 0 ) )
            {
               standaloneNotModal0B12( ) ;
               GetKey0B12( ) ;
               if ( ( nRcdExists_12 == 0 ) && ( nRcdDeleted_12 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0B12( ) ;
               }
               else
               {
                  if ( RcdFound12 != 0 )
                  {
                     if ( ( nRcdDeleted_12 != 0 ) && ( nRcdExists_12 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0B12( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_12 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0B12( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_12 == 0 )
                     {
                        GXCCtl = "CLIDAVAL_" + sGXsfl_39_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtCliDAval_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtCliDAval_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A162CliDAval), 6, 0, ".", ""))) ;
            ChangePostValue( edtCliDAValRUC_Internalname, A594CliDAValRUC) ;
            ChangePostValue( edtCliDAvalDsc_Internalname, A593CliDAvalDsc) ;
            ChangePostValue( edtCliDAvalDir_Internalname, A592CliDAvalDir) ;
            ChangePostValue( edtCliDAvalSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A595CliDAvalSts), 1, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z162CliDAval_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z162CliDAval), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z594CliDAValRUC_"+sGXsfl_39_idx, Z594CliDAValRUC) ;
            ChangePostValue( "ZT_"+"Z593CliDAvalDsc_"+sGXsfl_39_idx, Z593CliDAvalDsc) ;
            ChangePostValue( "ZT_"+"Z592CliDAvalDir_"+sGXsfl_39_idx, Z592CliDAvalDir) ;
            ChangePostValue( "ZT_"+"Z595CliDAvalSts_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z595CliDAvalSts), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_12_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_12_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_12_"+sGXsfl_39_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", ""))) ;
            if ( nIsMod_12 != 0 )
            {
               ChangePostValue( "CLIDAVAL_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAval_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALRUC_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAValRUC_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALDSC_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALDIR_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDir_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLIDAVALSTS_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalSts_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0B12( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_12 = 0;
         nIsMod_12 = 0;
         nRcdDeleted_12 = 0;
      }

      protected void ProcessLevel0B11( )
      {
         /* Save parent mode. */
         sMode11 = Gx_mode;
         ProcessNestedLevel0B12( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0B11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.CommitDataStores("clclientesavales",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(3);
            pr_default.close(1);
            pr_default.close(0);
            context.RollbackDataStores("clclientesavales",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B11( )
      {
         /* Using cursor T000B31 */
         pr_default.execute(29);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound11 = 1;
            A45CliCod = T000B31_A45CliCod[0];
            n45CliCod = T000B31_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B11( )
      {
         /* Scan next routine */
         pr_default.readNext(29);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound11 = 1;
            A45CliCod = T000B31_A45CliCod[0];
            n45CliCod = T000B31_n45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
         }
      }

      protected void ScanEnd0B11( )
      {
         pr_default.close(29);
      }

      protected void AfterConfirm0B11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B11( )
      {
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtCliDTAval_Enabled = 0;
         AssignProp("", false, edtCliDTAval_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDTAval_Enabled), 5, 0), true);
      }

      protected void ZM0B12( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z594CliDAValRUC = T000B3_A594CliDAValRUC[0];
               Z593CliDAvalDsc = T000B3_A593CliDAvalDsc[0];
               Z592CliDAvalDir = T000B3_A592CliDAvalDir[0];
               Z595CliDAvalSts = T000B3_A595CliDAvalSts[0];
            }
            else
            {
               Z594CliDAValRUC = A594CliDAValRUC;
               Z593CliDAvalDsc = A593CliDAvalDsc;
               Z592CliDAvalDir = A592CliDAvalDir;
               Z595CliDAvalSts = A595CliDAvalSts;
            }
         }
         if ( GX_JID == -2 )
         {
            Z45CliCod = A45CliCod;
            Z162CliDAval = A162CliDAval;
            Z594CliDAValRUC = A594CliDAValRUC;
            Z593CliDAvalDsc = A593CliDAvalDsc;
            Z592CliDAvalDir = A592CliDAvalDir;
            Z595CliDAvalSts = A595CliDAvalSts;
         }
      }

      protected void standaloneNotModal0B12( )
      {
      }

      protected void standaloneModal0B12( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtCliDAval_Enabled = 0;
            AssignProp("", false, edtCliDAval_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAval_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         }
         else
         {
            edtCliDAval_Enabled = 1;
            AssignProp("", false, edtCliDAval_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAval_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         }
      }

      protected void Load0B12( )
      {
         /* Using cursor T000B32 */
         pr_default.execute(30, new Object[] {n45CliCod, A45CliCod, A162CliDAval});
         if ( (pr_default.getStatus(30) != 101) )
         {
            RcdFound12 = 1;
            A594CliDAValRUC = T000B32_A594CliDAValRUC[0];
            A593CliDAvalDsc = T000B32_A593CliDAvalDsc[0];
            A592CliDAvalDir = T000B32_A592CliDAvalDir[0];
            A595CliDAvalSts = T000B32_A595CliDAvalSts[0];
            ZM0B12( -2) ;
         }
         pr_default.close(30);
         OnLoadActions0B12( ) ;
      }

      protected void OnLoadActions0B12( )
      {
      }

      protected void CheckExtendedTable0B12( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         standaloneModal0B12( ) ;
      }

      protected void CloseExtendedTableCursors0B12( )
      {
      }

      protected void enableDisable0B12( )
      {
      }

      protected void GetKey0B12( )
      {
         /* Using cursor T000B33 */
         pr_default.execute(31, new Object[] {n45CliCod, A45CliCod, A162CliDAval});
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(31);
      }

      protected void getByPrimaryKey0B12( )
      {
         /* Using cursor T000B3 */
         pr_default.execute(1, new Object[] {n45CliCod, A45CliCod, A162CliDAval});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B12( 2) ;
            RcdFound12 = 1;
            InitializeNonKey0B12( ) ;
            A162CliDAval = T000B3_A162CliDAval[0];
            A594CliDAValRUC = T000B3_A594CliDAValRUC[0];
            A593CliDAvalDsc = T000B3_A593CliDAvalDsc[0];
            A592CliDAvalDir = T000B3_A592CliDAvalDir[0];
            A595CliDAvalSts = T000B3_A595CliDAvalSts[0];
            Z45CliCod = A45CliCod;
            Z162CliDAval = A162CliDAval;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0B12( ) ;
            Load0B12( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0B12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0B12( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0B12( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0B12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000B2 */
            pr_default.execute(0, new Object[] {n45CliCod, A45CliCod, A162CliDAval});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESAVALES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z594CliDAValRUC, T000B2_A594CliDAValRUC[0]) != 0 ) || ( StringUtil.StrCmp(Z593CliDAvalDsc, T000B2_A593CliDAvalDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z592CliDAvalDir, T000B2_A592CliDAvalDir[0]) != 0 ) || ( Z595CliDAvalSts != T000B2_A595CliDAvalSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z594CliDAValRUC, T000B2_A594CliDAValRUC[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesavales:[seudo value changed for attri]"+"CliDAValRUC");
                  GXUtil.WriteLogRaw("Old: ",Z594CliDAValRUC);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A594CliDAValRUC[0]);
               }
               if ( StringUtil.StrCmp(Z593CliDAvalDsc, T000B2_A593CliDAvalDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesavales:[seudo value changed for attri]"+"CliDAvalDsc");
                  GXUtil.WriteLogRaw("Old: ",Z593CliDAvalDsc);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A593CliDAvalDsc[0]);
               }
               if ( StringUtil.StrCmp(Z592CliDAvalDir, T000B2_A592CliDAvalDir[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesavales:[seudo value changed for attri]"+"CliDAvalDir");
                  GXUtil.WriteLogRaw("Old: ",Z592CliDAvalDir);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A592CliDAvalDir[0]);
               }
               if ( Z595CliDAvalSts != T000B2_A595CliDAvalSts[0] )
               {
                  GXUtil.WriteLog("clclientesavales:[seudo value changed for attri]"+"CliDAvalSts");
                  GXUtil.WriteLogRaw("Old: ",Z595CliDAvalSts);
                  GXUtil.WriteLogRaw("Current: ",T000B2_A595CliDAvalSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTESAVALES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B12( 0) ;
            CheckOptimisticConcurrency0B12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000B34 */
                     pr_default.execute(32, new Object[] {n45CliCod, A45CliCod, A162CliDAval, A594CliDAValRUC, A593CliDAvalDsc, A592CliDAvalDir, A595CliDAvalSts});
                     pr_default.close(32);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESAVALES");
                     if ( (pr_default.getStatus(32) == 1) )
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
               Load0B12( ) ;
            }
            EndLevel0B12( ) ;
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void Update0B12( )
      {
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B12( ) ;
         }
         if ( ( nIsMod_12 != 0 ) || ( nIsDirty_12 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0B12( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0B12( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0B12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000B35 */
                        pr_default.execute(33, new Object[] {A594CliDAValRUC, A593CliDAvalDsc, A592CliDAvalDir, A595CliDAvalSts, n45CliCod, A45CliCod, A162CliDAval});
                        pr_default.close(33);
                        dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESAVALES");
                        if ( (pr_default.getStatus(33) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESAVALES"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0B12( ) ;
                        if ( AnyError == 0 )
                        {
                           new clclientesupdateredundancy(context ).execute( ref  A45CliCod) ;
                           AssignAttri("", false, "A45CliCod", A45CliCod);
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0B12( ) ;
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
               EndLevel0B12( ) ;
            }
         }
         CloseExtendedTableCursors0B12( ) ;
      }

      protected void DeferredUpdate0B12( )
      {
      }

      protected void Delete0B12( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0B12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B12( ) ;
            AfterConfirm0B12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000B36 */
                  pr_default.execute(34, new Object[] {n45CliCod, A45CliCod, A162CliDAval});
                  pr_default.close(34);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESAVALES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0B12( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0B12( )
      {
         standaloneModal0B12( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0B12( )
      {
         /* Scan By routine */
         /* Using cursor T000B37 */
         pr_default.execute(35, new Object[] {n45CliCod, A45CliCod});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound12 = 1;
            A162CliDAval = T000B37_A162CliDAval[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0B12( )
      {
         /* Scan next routine */
         pr_default.readNext(35);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(35) != 101) )
         {
            RcdFound12 = 1;
            A162CliDAval = T000B37_A162CliDAval[0];
         }
      }

      protected void ScanEnd0B12( )
      {
         pr_default.close(35);
      }

      protected void AfterConfirm0B12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B12( )
      {
         edtCliDAval_Enabled = 0;
         AssignProp("", false, edtCliDAval_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAval_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtCliDAValRUC_Enabled = 0;
         AssignProp("", false, edtCliDAValRUC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAValRUC_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtCliDAvalDsc_Enabled = 0;
         AssignProp("", false, edtCliDAvalDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAvalDsc_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtCliDAvalDir_Enabled = 0;
         AssignProp("", false, edtCliDAvalDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAvalDir_Enabled), 5, 0), !bGXsfl_39_Refreshing);
         edtCliDAvalSts_Enabled = 0;
         AssignProp("", false, edtCliDAvalSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAvalSts_Enabled), 5, 0), !bGXsfl_39_Refreshing);
      }

      protected void send_integrity_lvl_hashes0B12( )
      {
      }

      protected void send_integrity_lvl_hashes0B11( )
      {
      }

      protected void SubsflControlProps_3912( )
      {
         edtCliDAval_Internalname = "CLIDAVAL_"+sGXsfl_39_idx;
         edtCliDAValRUC_Internalname = "CLIDAVALRUC_"+sGXsfl_39_idx;
         edtCliDAvalDsc_Internalname = "CLIDAVALDSC_"+sGXsfl_39_idx;
         edtCliDAvalDir_Internalname = "CLIDAVALDIR_"+sGXsfl_39_idx;
         edtCliDAvalSts_Internalname = "CLIDAVALSTS_"+sGXsfl_39_idx;
      }

      protected void SubsflControlProps_fel_3912( )
      {
         edtCliDAval_Internalname = "CLIDAVAL_"+sGXsfl_39_fel_idx;
         edtCliDAValRUC_Internalname = "CLIDAVALRUC_"+sGXsfl_39_fel_idx;
         edtCliDAvalDsc_Internalname = "CLIDAVALDSC_"+sGXsfl_39_fel_idx;
         edtCliDAvalDir_Internalname = "CLIDAVALDIR_"+sGXsfl_39_fel_idx;
         edtCliDAvalSts_Internalname = "CLIDAVALSTS_"+sGXsfl_39_fel_idx;
      }

      protected void AddRow0B12( )
      {
         nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_3912( ) ;
         SendRow0B12( ) ;
      }

      protected void SendRow0B12( )
      {
         Gridclclientesavales_level1Row = GXWebRow.GetNew(context);
         if ( subGridclclientesavales_level1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridclclientesavales_level1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridclclientesavales_level1_Class, "") != 0 )
            {
               subGridclclientesavales_level1_Linesclass = subGridclclientesavales_level1_Class+"Odd";
            }
         }
         else if ( subGridclclientesavales_level1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridclclientesavales_level1_Backstyle = 0;
            subGridclclientesavales_level1_Backcolor = subGridclclientesavales_level1_Allbackcolor;
            if ( StringUtil.StrCmp(subGridclclientesavales_level1_Class, "") != 0 )
            {
               subGridclclientesavales_level1_Linesclass = subGridclclientesavales_level1_Class+"Uniform";
            }
         }
         else if ( subGridclclientesavales_level1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridclclientesavales_level1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridclclientesavales_level1_Class, "") != 0 )
            {
               subGridclclientesavales_level1_Linesclass = subGridclclientesavales_level1_Class+"Odd";
            }
            subGridclclientesavales_level1_Backcolor = (int)(0x0);
         }
         else if ( subGridclclientesavales_level1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridclclientesavales_level1_Backstyle = 1;
            if ( ((int)((nGXsfl_39_idx) % (2))) == 0 )
            {
               subGridclclientesavales_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridclclientesavales_level1_Class, "") != 0 )
               {
                  subGridclclientesavales_level1_Linesclass = subGridclclientesavales_level1_Class+"Even";
               }
            }
            else
            {
               subGridclclientesavales_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridclclientesavales_level1_Class, "") != 0 )
               {
                  subGridclclientesavales_level1_Linesclass = subGridclclientesavales_level1_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ROClassString = "Attribute";
         Gridclclientesavales_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDAval_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A162CliDAval), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A162CliDAval), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,40);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDAval_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCliDAval_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 41,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ROClassString = "Attribute";
         Gridclclientesavales_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDAValRUC_Internalname,(string)A594CliDAValRUC,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDAValRUC_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCliDAValRUC_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 42,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ROClassString = "Attribute";
         Gridclclientesavales_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDAvalDsc_Internalname,(string)A593CliDAvalDsc,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDAvalDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCliDAvalDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 43,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ROClassString = "Attribute";
         Gridclclientesavales_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDAvalDir_Internalname,(string)A592CliDAvalDir,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDAvalDir_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCliDAvalDir_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_12_" + sGXsfl_39_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 44,'',false,'" + sGXsfl_39_idx + "',39)\"";
         ROClassString = "Attribute";
         Gridclclientesavales_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliDAvalSts_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A595CliDAvalSts), 1, 0, ".", "")),StringUtil.LTrim( ((edtCliDAvalSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A595CliDAvalSts), "9") : context.localUtil.Format( (decimal)(A595CliDAvalSts), "9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliDAvalSts_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCliDAvalSts_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)1,(short)0,(short)0,(short)39,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridclclientesavales_level1Row);
         send_integrity_lvl_hashes0B12( ) ;
         GXCCtl = "Z162CliDAval_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z162CliDAval), 6, 0, ".", "")));
         GXCCtl = "Z594CliDAValRUC_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z594CliDAValRUC);
         GXCCtl = "Z593CliDAvalDsc_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z593CliDAvalDsc);
         GXCCtl = "Z592CliDAvalDir_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z592CliDAvalDir);
         GXCCtl = "Z595CliDAvalSts_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z595CliDAvalSts), 1, 0, ".", "")));
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_12), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_12_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_12), 4, 0, ".", "")));
         GXCCtl = "nIsMod_12_" + sGXsfl_39_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_12), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDAVAL_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAval_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDAVALRUC_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAValRUC_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDAVALDSC_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDAVALDIR_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalDir_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLIDAVALSTS_"+sGXsfl_39_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliDAvalSts_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridclclientesavales_level1Container.AddRow(Gridclclientesavales_level1Row);
      }

      protected void ReadRow0B12( )
      {
         nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_3912( ) ;
         edtCliDAval_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVAL_"+sGXsfl_39_idx+"Enabled"), ".", ","));
         edtCliDAValRUC_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALRUC_"+sGXsfl_39_idx+"Enabled"), ".", ","));
         edtCliDAvalDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALDSC_"+sGXsfl_39_idx+"Enabled"), ".", ","));
         edtCliDAvalDir_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALDIR_"+sGXsfl_39_idx+"Enabled"), ".", ","));
         edtCliDAvalSts_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLIDAVALSTS_"+sGXsfl_39_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtCliDAval_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDAval_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "CLIDAVAL_" + sGXsfl_39_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliDAval_Internalname;
            wbErr = true;
            A162CliDAval = 0;
         }
         else
         {
            A162CliDAval = (int)(context.localUtil.CToN( cgiGet( edtCliDAval_Internalname), ".", ","));
         }
         A594CliDAValRUC = cgiGet( edtCliDAValRUC_Internalname);
         A593CliDAvalDsc = cgiGet( edtCliDAvalDsc_Internalname);
         A592CliDAvalDir = cgiGet( edtCliDAvalDir_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtCliDAvalSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDAvalSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
         {
            GXCCtl = "CLIDAVALSTS_" + sGXsfl_39_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCliDAvalSts_Internalname;
            wbErr = true;
            A595CliDAvalSts = 0;
         }
         else
         {
            A595CliDAvalSts = (short)(context.localUtil.CToN( cgiGet( edtCliDAvalSts_Internalname), ".", ","));
         }
         GXCCtl = "Z162CliDAval_" + sGXsfl_39_idx;
         Z162CliDAval = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z594CliDAValRUC_" + sGXsfl_39_idx;
         Z594CliDAValRUC = cgiGet( GXCCtl);
         GXCCtl = "Z593CliDAvalDsc_" + sGXsfl_39_idx;
         Z593CliDAvalDsc = cgiGet( GXCCtl);
         GXCCtl = "Z592CliDAvalDir_" + sGXsfl_39_idx;
         Z592CliDAvalDir = cgiGet( GXCCtl);
         GXCCtl = "Z595CliDAvalSts_" + sGXsfl_39_idx;
         Z595CliDAvalSts = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_12_" + sGXsfl_39_idx;
         nRcdDeleted_12 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_12_" + sGXsfl_39_idx;
         nRcdExists_12 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_12_" + sGXsfl_39_idx;
         nIsMod_12 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtCliDAval_Enabled = edtCliDAval_Enabled;
      }

      protected void ConfirmValues0B0( )
      {
         nGXsfl_39_idx = 0;
         sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
         SubsflControlProps_3912( ) ;
         while ( nGXsfl_39_idx < nRC_GXsfl_39 )
         {
            nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_3912( ) ;
            ChangePostValue( "Z162CliDAval_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z162CliDAval_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z162CliDAval_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z594CliDAValRUC_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z594CliDAValRUC_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z594CliDAValRUC_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z593CliDAvalDsc_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z593CliDAvalDsc_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z593CliDAvalDsc_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z592CliDAvalDir_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z592CliDAvalDir_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z592CliDAvalDir_"+sGXsfl_39_idx) ;
            ChangePostValue( "Z595CliDAvalSts_"+sGXsfl_39_idx, cgiGet( "ZT_"+"Z595CliDAvalSts_"+sGXsfl_39_idx)) ;
            DeletePostValue( "ZT_"+"Z595CliDAvalSts_"+sGXsfl_39_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?202281811441768", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clclientesavales.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z608CliDTAval", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z608CliDTAval), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_39", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_39_idx), 8, 0, ".", "")));
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
         return formatLink("clclientesavales.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCLIENTESAVALES" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLCLIENTESAVALES" ;
      }

      protected void InitializeNonKey0B11( )
      {
         A608CliDTAval = 0;
         AssignAttri("", false, "A608CliDTAval", StringUtil.LTrimStr( (decimal)(A608CliDTAval), 6, 0));
         Z608CliDTAval = 0;
      }

      protected void InitAll0B11( )
      {
         A45CliCod = "";
         n45CliCod = false;
         AssignAttri("", false, "A45CliCod", A45CliCod);
         InitializeNonKey0B11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey0B12( )
      {
         A594CliDAValRUC = "";
         A593CliDAvalDsc = "";
         A592CliDAvalDir = "";
         A595CliDAvalSts = 0;
         Z594CliDAValRUC = "";
         Z593CliDAvalDsc = "";
         Z592CliDAvalDir = "";
         Z595CliDAvalSts = 0;
      }

      protected void InitAll0B12( )
      {
         A162CliDAval = 0;
         InitializeNonKey0B12( ) ;
      }

      protected void StandaloneModalInsert0B12( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811441775", true, true);
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
         context.AddJavascriptSource("clclientesavales.js", "?202281811441775", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties12( )
      {
         edtCliDAval_Enabled = defedtCliDAval_Enabled;
         AssignProp("", false, edtCliDAval_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDAval_Enabled), 5, 0), !bGXsfl_39_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtCliCod_Internalname = "CLICOD";
         edtCliDTAval_Internalname = "CLIDTAVAL";
         lblTitlelevel1_Internalname = "TITLELEVEL1";
         edtCliDAval_Internalname = "CLIDAVAL";
         edtCliDAValRUC_Internalname = "CLIDAVALRUC";
         edtCliDAvalDsc_Internalname = "CLIDAVALDSC";
         edtCliDAvalDir_Internalname = "CLIDAVALDIR";
         edtCliDAvalSts_Internalname = "CLIDAVALSTS";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridclclientesavales_level1_Internalname = "GRIDCLCLIENTESAVALES_LEVEL1";
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
         Form.Caption = "CLCLIENTESAVALES";
         edtCliDAvalSts_Jsonclick = "";
         edtCliDAvalDir_Jsonclick = "";
         edtCliDAvalDsc_Jsonclick = "";
         edtCliDAValRUC_Jsonclick = "";
         edtCliDAval_Jsonclick = "";
         subGridclclientesavales_level1_Class = "Grid";
         subGridclclientesavales_level1_Backcolorstyle = 0;
         subGridclclientesavales_level1_Allowcollapsing = 0;
         subGridclclientesavales_level1_Allowselection = 0;
         edtCliDAvalSts_Enabled = 1;
         edtCliDAvalDir_Enabled = 1;
         edtCliDAvalDsc_Enabled = 1;
         edtCliDAValRUC_Enabled = 1;
         edtCliDAval_Enabled = 1;
         subGridclclientesavales_level1_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCliDTAval_Jsonclick = "";
         edtCliDTAval_Enabled = 1;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
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

      protected void gxnrGridclclientesavales_level1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3912( ) ;
         while ( nGXsfl_39_idx <= nRC_GXsfl_39 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0B12( ) ;
            standaloneModal0B12( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0B12( ) ;
            nGXsfl_39_idx = (int)(nGXsfl_39_idx+1);
            sGXsfl_39_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_39_idx), 4, 0), 4, "0");
            SubsflControlProps_3912( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridclclientesavales_level1Container)) ;
         /* End function gxnrGridclclientesavales_level1_newrow */
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
         GX_FocusControl = edtCliDTAval_Internalname;
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

      public void Valid_Clicod( )
      {
         n45CliCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A608CliDTAval", StringUtil.LTrim( StringUtil.NToC( (decimal)(A608CliDTAval), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z608CliDTAval", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z608CliDTAval), 6, 0, ".", "")));
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
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLICOD",",oparms:[{av:'A608CliDTAval',fld:'CLIDTAVAL',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z45CliCod'},{av:'Z608CliDTAval'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLIDAVAL","{handler:'Valid_Clidaval',iparms:[]");
         setEventMetadata("VALID_CLIDAVAL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Clidavalsts',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(3);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z45CliCod = "";
         Z594CliDAValRUC = "";
         Z593CliDAvalDsc = "";
         Z592CliDAvalDir = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
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
         A45CliCod = "";
         lblTitlelevel1_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridclclientesavales_level1Container = new GXWebGrid( context);
         Gridclclientesavales_level1Column = new GXWebColumn();
         A594CliDAValRUC = "";
         A593CliDAvalDsc = "";
         A592CliDAvalDir = "";
         sMode12 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T000B6_A45CliCod = new string[] {""} ;
         T000B6_n45CliCod = new bool[] {false} ;
         T000B6_A608CliDTAval = new int[1] ;
         T000B7_A45CliCod = new string[] {""} ;
         T000B7_n45CliCod = new bool[] {false} ;
         T000B5_A45CliCod = new string[] {""} ;
         T000B5_n45CliCod = new bool[] {false} ;
         T000B5_A608CliDTAval = new int[1] ;
         sMode11 = "";
         T000B8_A45CliCod = new string[] {""} ;
         T000B8_n45CliCod = new bool[] {false} ;
         T000B9_A45CliCod = new string[] {""} ;
         T000B9_n45CliCod = new bool[] {false} ;
         T000B4_A45CliCod = new string[] {""} ;
         T000B4_n45CliCod = new bool[] {false} ;
         T000B4_A608CliDTAval = new int[1] ;
         T000B13_A149TipCod = new string[] {""} ;
         T000B13_A24DocNum = new string[] {""} ;
         T000B14_A224LotCliCod = new string[] {""} ;
         T000B15_A218PerCod = new string[] {""} ;
         T000B15_A219PerTip = new string[] {""} ;
         T000B15_A220PerTDoc = new string[] {""} ;
         T000B16_A204LetCLetCod = new string[] {""} ;
         T000B17_A191ImpItem = new long[1] ;
         T000B18_A184CCTipCod = new string[] {""} ;
         T000B18_A185CCDocNum = new string[] {""} ;
         T000B19_A150CLCheqDCod = new string[] {""} ;
         T000B20_A144CLAntTipCod = new string[] {""} ;
         T000B20_A145CLAntDocNum = new string[] {""} ;
         T000B21_A210PedCod = new string[] {""} ;
         T000B22_A202TipLCod = new int[1] ;
         T000B22_A203TipLItem = new int[1] ;
         T000B23_A177CotCod = new string[] {""} ;
         T000B24_A44PlaCod = new string[] {""} ;
         T000B25_A45CliCod = new string[] {""} ;
         T000B25_n45CliCod = new bool[] {false} ;
         T000B25_A164CliDirItem = new int[1] ;
         T000B26_A45CliCod = new string[] {""} ;
         T000B26_n45CliCod = new bool[] {false} ;
         T000B26_A163CliConCod = new int[1] ;
         T000B27_A37ListItem = new int[1] ;
         T000B28_A26AGMVATip = new string[] {""} ;
         T000B28_A27AGMVACod = new string[] {""} ;
         T000B28_A28ProdCod = new string[] {""} ;
         T000B29_A13MvATip = new string[] {""} ;
         T000B29_A14MvACod = new string[] {""} ;
         T000B30_A13MvATip = new string[] {""} ;
         T000B30_A14MvACod = new string[] {""} ;
         T000B31_A45CliCod = new string[] {""} ;
         T000B31_n45CliCod = new bool[] {false} ;
         T000B32_A45CliCod = new string[] {""} ;
         T000B32_n45CliCod = new bool[] {false} ;
         T000B32_A162CliDAval = new int[1] ;
         T000B32_A594CliDAValRUC = new string[] {""} ;
         T000B32_A593CliDAvalDsc = new string[] {""} ;
         T000B32_A592CliDAvalDir = new string[] {""} ;
         T000B32_A595CliDAvalSts = new short[1] ;
         T000B33_A45CliCod = new string[] {""} ;
         T000B33_n45CliCod = new bool[] {false} ;
         T000B33_A162CliDAval = new int[1] ;
         T000B3_A45CliCod = new string[] {""} ;
         T000B3_n45CliCod = new bool[] {false} ;
         T000B3_A162CliDAval = new int[1] ;
         T000B3_A594CliDAValRUC = new string[] {""} ;
         T000B3_A593CliDAvalDsc = new string[] {""} ;
         T000B3_A592CliDAvalDir = new string[] {""} ;
         T000B3_A595CliDAvalSts = new short[1] ;
         T000B2_A45CliCod = new string[] {""} ;
         T000B2_n45CliCod = new bool[] {false} ;
         T000B2_A162CliDAval = new int[1] ;
         T000B2_A594CliDAValRUC = new string[] {""} ;
         T000B2_A593CliDAvalDsc = new string[] {""} ;
         T000B2_A592CliDAvalDir = new string[] {""} ;
         T000B2_A595CliDAvalSts = new short[1] ;
         T000B37_A45CliCod = new string[] {""} ;
         T000B37_n45CliCod = new bool[] {false} ;
         T000B37_A162CliDAval = new int[1] ;
         Gridclclientesavales_level1Row = new GXWebRow();
         subGridclclientesavales_level1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ45CliCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clclientesavales__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clclientesavales__default(),
            new Object[][] {
                new Object[] {
               T000B2_A45CliCod, T000B2_A162CliDAval, T000B2_A594CliDAValRUC, T000B2_A593CliDAvalDsc, T000B2_A592CliDAvalDir, T000B2_A595CliDAvalSts
               }
               , new Object[] {
               T000B3_A45CliCod, T000B3_A162CliDAval, T000B3_A594CliDAValRUC, T000B3_A593CliDAvalDsc, T000B3_A592CliDAvalDir, T000B3_A595CliDAvalSts
               }
               , new Object[] {
               T000B4_A45CliCod, T000B4_A608CliDTAval
               }
               , new Object[] {
               T000B5_A45CliCod, T000B5_A608CliDTAval
               }
               , new Object[] {
               T000B6_A45CliCod, T000B6_A608CliDTAval
               }
               , new Object[] {
               T000B7_A45CliCod
               }
               , new Object[] {
               T000B8_A45CliCod
               }
               , new Object[] {
               T000B9_A45CliCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B13_A149TipCod, T000B13_A24DocNum
               }
               , new Object[] {
               T000B14_A224LotCliCod
               }
               , new Object[] {
               T000B15_A218PerCod, T000B15_A219PerTip, T000B15_A220PerTDoc
               }
               , new Object[] {
               T000B16_A204LetCLetCod
               }
               , new Object[] {
               T000B17_A191ImpItem
               }
               , new Object[] {
               T000B18_A184CCTipCod, T000B18_A185CCDocNum
               }
               , new Object[] {
               T000B19_A150CLCheqDCod
               }
               , new Object[] {
               T000B20_A144CLAntTipCod, T000B20_A145CLAntDocNum
               }
               , new Object[] {
               T000B21_A210PedCod
               }
               , new Object[] {
               T000B22_A202TipLCod, T000B22_A203TipLItem
               }
               , new Object[] {
               T000B23_A177CotCod
               }
               , new Object[] {
               T000B24_A44PlaCod
               }
               , new Object[] {
               T000B25_A45CliCod, T000B25_A164CliDirItem
               }
               , new Object[] {
               T000B26_A45CliCod, T000B26_A163CliConCod
               }
               , new Object[] {
               T000B27_A37ListItem
               }
               , new Object[] {
               T000B28_A26AGMVATip, T000B28_A27AGMVACod, T000B28_A28ProdCod
               }
               , new Object[] {
               T000B29_A13MvATip, T000B29_A14MvACod
               }
               , new Object[] {
               T000B30_A13MvATip, T000B30_A14MvACod
               }
               , new Object[] {
               T000B31_A45CliCod
               }
               , new Object[] {
               T000B32_A45CliCod, T000B32_A162CliDAval, T000B32_A594CliDAValRUC, T000B32_A593CliDAvalDsc, T000B32_A592CliDAvalDir, T000B32_A595CliDAvalSts
               }
               , new Object[] {
               T000B33_A45CliCod, T000B33_A162CliDAval
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000B37_A45CliCod, T000B37_A162CliDAval
               }
            }
         );
      }

      private short Z595CliDAvalSts ;
      private short nRcdDeleted_12 ;
      private short nRcdExists_12 ;
      private short nIsMod_12 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridclclientesavales_level1_Backcolorstyle ;
      private short A595CliDAvalSts ;
      private short subGridclclientesavales_level1_Allowselection ;
      private short subGridclclientesavales_level1_Allowhovering ;
      private short subGridclclientesavales_level1_Allowcollapsing ;
      private short subGridclclientesavales_level1_Collapsed ;
      private short nBlankRcdCount12 ;
      private short RcdFound12 ;
      private short nBlankRcdUsr12 ;
      private short GX_JID ;
      private short RcdFound11 ;
      private short nIsDirty_11 ;
      private short Gx_BScreen ;
      private short nIsDirty_12 ;
      private short subGridclclientesavales_level1_Backstyle ;
      private short gxajaxcallmode ;
      private int Z608CliDTAval ;
      private int nRC_GXsfl_39 ;
      private int nGXsfl_39_idx=1 ;
      private int Z162CliDAval ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCliCod_Enabled ;
      private int A608CliDTAval ;
      private int edtCliDTAval_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int A162CliDAval ;
      private int edtCliDAval_Enabled ;
      private int edtCliDAValRUC_Enabled ;
      private int edtCliDAvalDsc_Enabled ;
      private int edtCliDAvalDir_Enabled ;
      private int edtCliDAvalSts_Enabled ;
      private int subGridclclientesavales_level1_Selectedindex ;
      private int subGridclclientesavales_level1_Selectioncolor ;
      private int subGridclclientesavales_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridclclientesavales_level1_Backcolor ;
      private int subGridclclientesavales_level1_Allbackcolor ;
      private int defedtCliDAval_Enabled ;
      private int idxLst ;
      private int ZZ608CliDTAval ;
      private long GRIDCLCLIENTESAVALES_LEVEL1_nFirstRecordOnPage ;
      private string sPrefix ;
      private string Z45CliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_39_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCliCod_Internalname ;
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
      private string A45CliCod ;
      private string edtCliCod_Jsonclick ;
      private string edtCliDTAval_Internalname ;
      private string edtCliDTAval_Jsonclick ;
      private string lblTitlelevel1_Internalname ;
      private string lblTitlelevel1_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridclclientesavales_level1_Header ;
      private string sMode12 ;
      private string edtCliDAval_Internalname ;
      private string edtCliDAValRUC_Internalname ;
      private string edtCliDAvalDsc_Internalname ;
      private string edtCliDAvalDir_Internalname ;
      private string edtCliDAvalSts_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode11 ;
      private string sGXsfl_39_fel_idx="0001" ;
      private string subGridclclientesavales_level1_Class ;
      private string subGridclclientesavales_level1_Linesclass ;
      private string ROClassString ;
      private string edtCliDAval_Jsonclick ;
      private string edtCliDAValRUC_Jsonclick ;
      private string edtCliDAvalDsc_Jsonclick ;
      private string edtCliDAvalDir_Jsonclick ;
      private string edtCliDAvalSts_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridclclientesavales_level1_Internalname ;
      private string ZZ45CliCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_39_Refreshing=false ;
      private bool n45CliCod ;
      private string Z594CliDAValRUC ;
      private string Z593CliDAvalDsc ;
      private string Z592CliDAvalDir ;
      private string A594CliDAValRUC ;
      private string A593CliDAvalDsc ;
      private string A592CliDAvalDir ;
      private GXWebGrid Gridclclientesavales_level1Container ;
      private GXWebRow Gridclclientesavales_level1Row ;
      private GXWebColumn Gridclclientesavales_level1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000B6_A45CliCod ;
      private bool[] T000B6_n45CliCod ;
      private int[] T000B6_A608CliDTAval ;
      private string[] T000B7_A45CliCod ;
      private bool[] T000B7_n45CliCod ;
      private string[] T000B5_A45CliCod ;
      private bool[] T000B5_n45CliCod ;
      private int[] T000B5_A608CliDTAval ;
      private string[] T000B8_A45CliCod ;
      private bool[] T000B8_n45CliCod ;
      private string[] T000B9_A45CliCod ;
      private bool[] T000B9_n45CliCod ;
      private string[] T000B4_A45CliCod ;
      private bool[] T000B4_n45CliCod ;
      private int[] T000B4_A608CliDTAval ;
      private string[] T000B13_A149TipCod ;
      private string[] T000B13_A24DocNum ;
      private string[] T000B14_A224LotCliCod ;
      private string[] T000B15_A218PerCod ;
      private string[] T000B15_A219PerTip ;
      private string[] T000B15_A220PerTDoc ;
      private string[] T000B16_A204LetCLetCod ;
      private long[] T000B17_A191ImpItem ;
      private string[] T000B18_A184CCTipCod ;
      private string[] T000B18_A185CCDocNum ;
      private string[] T000B19_A150CLCheqDCod ;
      private string[] T000B20_A144CLAntTipCod ;
      private string[] T000B20_A145CLAntDocNum ;
      private string[] T000B21_A210PedCod ;
      private int[] T000B22_A202TipLCod ;
      private int[] T000B22_A203TipLItem ;
      private string[] T000B23_A177CotCod ;
      private string[] T000B24_A44PlaCod ;
      private string[] T000B25_A45CliCod ;
      private bool[] T000B25_n45CliCod ;
      private int[] T000B25_A164CliDirItem ;
      private string[] T000B26_A45CliCod ;
      private bool[] T000B26_n45CliCod ;
      private int[] T000B26_A163CliConCod ;
      private int[] T000B27_A37ListItem ;
      private string[] T000B28_A26AGMVATip ;
      private string[] T000B28_A27AGMVACod ;
      private string[] T000B28_A28ProdCod ;
      private string[] T000B29_A13MvATip ;
      private string[] T000B29_A14MvACod ;
      private string[] T000B30_A13MvATip ;
      private string[] T000B30_A14MvACod ;
      private string[] T000B31_A45CliCod ;
      private bool[] T000B31_n45CliCod ;
      private string[] T000B32_A45CliCod ;
      private bool[] T000B32_n45CliCod ;
      private int[] T000B32_A162CliDAval ;
      private string[] T000B32_A594CliDAValRUC ;
      private string[] T000B32_A593CliDAvalDsc ;
      private string[] T000B32_A592CliDAvalDir ;
      private short[] T000B32_A595CliDAvalSts ;
      private string[] T000B33_A45CliCod ;
      private bool[] T000B33_n45CliCod ;
      private int[] T000B33_A162CliDAval ;
      private string[] T000B3_A45CliCod ;
      private bool[] T000B3_n45CliCod ;
      private int[] T000B3_A162CliDAval ;
      private string[] T000B3_A594CliDAValRUC ;
      private string[] T000B3_A593CliDAvalDsc ;
      private string[] T000B3_A592CliDAvalDir ;
      private short[] T000B3_A595CliDAvalSts ;
      private string[] T000B2_A45CliCod ;
      private bool[] T000B2_n45CliCod ;
      private int[] T000B2_A162CliDAval ;
      private string[] T000B2_A594CliDAValRUC ;
      private string[] T000B2_A593CliDAvalDsc ;
      private string[] T000B2_A592CliDAvalDir ;
      private short[] T000B2_A595CliDAvalSts ;
      private string[] T000B37_A45CliCod ;
      private bool[] T000B37_n45CliCod ;
      private int[] T000B37_A162CliDAval ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clclientesavales__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clclientesavales__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
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
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new ForEachCursor(def[35])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000B6;
        prmT000B6 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B7;
        prmT000B7 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B5;
        prmT000B5 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B8;
        prmT000B8 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B9;
        prmT000B9 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B4;
        prmT000B4 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B10;
        prmT000B10 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDTAval",GXType.Int32,6,0)
        };
        Object[] prmT000B11;
        prmT000B11 = new Object[] {
        new ParDef("@CliDTAval",GXType.Int32,6,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B12;
        prmT000B12 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B13;
        prmT000B13 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B14;
        prmT000B14 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B15;
        prmT000B15 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B16;
        prmT000B16 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B17;
        prmT000B17 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B18;
        prmT000B18 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B19;
        prmT000B19 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B20;
        prmT000B20 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B21;
        prmT000B21 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B22;
        prmT000B22 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B23;
        prmT000B23 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B24;
        prmT000B24 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B25;
        prmT000B25 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B26;
        prmT000B26 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B27;
        prmT000B27 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B28;
        prmT000B28 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B29;
        prmT000B29 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B30;
        prmT000B30 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT000B31;
        prmT000B31 = new Object[] {
        };
        Object[] prmT000B32;
        prmT000B32 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDAval",GXType.Int32,6,0)
        };
        Object[] prmT000B33;
        prmT000B33 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDAval",GXType.Int32,6,0)
        };
        Object[] prmT000B3;
        prmT000B3 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDAval",GXType.Int32,6,0)
        };
        Object[] prmT000B2;
        prmT000B2 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDAval",GXType.Int32,6,0)
        };
        Object[] prmT000B34;
        prmT000B34 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDAval",GXType.Int32,6,0) ,
        new ParDef("@CliDAValRUC",GXType.NVarChar,11,0) ,
        new ParDef("@CliDAvalDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CliDAvalDir",GXType.NVarChar,100,0) ,
        new ParDef("@CliDAvalSts",GXType.Int16,1,0)
        };
        Object[] prmT000B35;
        prmT000B35 = new Object[] {
        new ParDef("@CliDAValRUC",GXType.NVarChar,11,0) ,
        new ParDef("@CliDAvalDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CliDAvalDir",GXType.NVarChar,100,0) ,
        new ParDef("@CliDAvalSts",GXType.Int16,1,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDAval",GXType.Int32,6,0)
        };
        Object[] prmT000B36;
        prmT000B36 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@CliDAval",GXType.Int32,6,0)
        };
        Object[] prmT000B37;
        prmT000B37 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000B2", "SELECT [CliCod], [CliDAval], [CliDAValRUC], [CliDAvalDsc], [CliDAvalDir], [CliDAvalSts] FROM [CLCLIENTESAVALES] WITH (UPDLOCK) WHERE [CliCod] = @CliCod AND [CliDAval] = @CliDAval ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B3", "SELECT [CliCod], [CliDAval], [CliDAValRUC], [CliDAvalDsc], [CliDAvalDir], [CliDAvalSts] FROM [CLCLIENTESAVALES] WHERE [CliCod] = @CliCod AND [CliDAval] = @CliDAval ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B4", "SELECT [CliCod], [CliDTAval] FROM [CLCLIENTES] WITH (UPDLOCK) WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B5", "SELECT [CliCod], [CliDTAval] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B6", "SELECT TM1.[CliCod], TM1.[CliDTAval] FROM [CLCLIENTES] TM1 WHERE TM1.[CliCod] = @CliCod ORDER BY TM1.[CliCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B7", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B8", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE ( [CliCod] > @CliCod) ORDER BY [CliCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B9", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE ( [CliCod] < @CliCod) ORDER BY [CliCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B10", "INSERT INTO [CLCLIENTES]([CliCod], [CliDTAval], [CliDsc], [CliDir], [EstCod], [PaiCod], [CliTel1], [CliTel2], [CliFax], [CliCel], [CliEma], [CliWeb], [TipCCod], [CliFoto], [CliFoto_GXI], [CliSts], [Conpcod], [CliLim], [CliVend], [CliRef1], [CliRef2], [CliRef3], [CliRef4], [CliRef5], [CliRef6], [CliRef7], [CliRef8], [CliCont1], [CliCTel1], [CliCont2], [CliCTel2], [CliCont3], [CliCtel3], [CliCont4], [CliCTel4], [CliCont5], [CliCtel5], [DisCod], [ProvCod], [CliTItemDir], [ZonCod], [CliMon], [CliVincula], [CliRetencion], [CliPercepcion], [CliTipLCod], [CliNom], [CliAPEP], [CliAPEM], [TipSCod], [CliUsuCod], [CliUsuFec], [CliEMAPer], [CliPassPer], [CliTCon], [CliTipCod]) VALUES(@CliCod, @CliDTAval, '', '', '', '', '', '', '', '', '', '', convert(int, 0), CONVERT(varbinary(1), ''), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', convert(int, 0), '', convert( DATETIME, '17530101', 112 ), '', '', convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmT000B10)
           ,new CursorDef("T000B11", "UPDATE [CLCLIENTES] SET [CliDTAval]=@CliDTAval  WHERE [CliCod] = @CliCod", GxErrorMask.GX_NOMASK,prmT000B11)
           ,new CursorDef("T000B12", "DELETE FROM [CLCLIENTES]  WHERE [CliCod] = @CliCod", GxErrorMask.GX_NOMASK,prmT000B12)
           ,new CursorDef("T000B13", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B14", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [LotCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B15", "SELECT TOP 1 [PerCod], [PerTip], [PerTDoc] FROM [CLPERCEPCION] WHERE [PerCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B16", "SELECT TOP 1 [LetCLetCod] FROM [CLLETRAS] WHERE [LetCCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B17", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B18", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B19", "SELECT TOP 1 [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B20", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE [CLAntCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B21", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B22", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B23", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B24", "SELECT TOP 1 [PlaCod] FROM [APLACAS] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B25", "SELECT TOP 1 [CliCod], [CliDirItem] FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B26", "SELECT TOP 1 [CliCod], [CliConCod] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B27", "SELECT TOP 1 [ListItem] FROM [ALISTADESCUENTO] WHERE [ListCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B28", "SELECT TOP 1 [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE [AGCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B29", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCDesCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B30", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000B31", "SELECT [CliCod] FROM [CLCLIENTES] ORDER BY [CliCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000B31,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B32", "SELECT [CliCod], [CliDAval], [CliDAValRUC], [CliDAvalDsc], [CliDAvalDir], [CliDAvalSts] FROM [CLCLIENTESAVALES] WHERE [CliCod] = @CliCod and [CliDAval] = @CliDAval ORDER BY [CliCod], [CliDAval] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B32,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B33", "SELECT [CliCod], [CliDAval] FROM [CLCLIENTESAVALES] WHERE [CliCod] = @CliCod AND [CliDAval] = @CliDAval ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000B34", "INSERT INTO [CLCLIENTESAVALES]([CliCod], [CliDAval], [CliDAValRUC], [CliDAvalDsc], [CliDAvalDir], [CliDAvalSts]) VALUES(@CliCod, @CliDAval, @CliDAValRUC, @CliDAvalDsc, @CliDAvalDir, @CliDAvalSts)", GxErrorMask.GX_NOMASK,prmT000B34)
           ,new CursorDef("T000B35", "UPDATE [CLCLIENTESAVALES] SET [CliDAValRUC]=@CliDAValRUC, [CliDAvalDsc]=@CliDAvalDsc, [CliDAvalDir]=@CliDAvalDir, [CliDAvalSts]=@CliDAvalSts  WHERE [CliCod] = @CliCod AND [CliDAval] = @CliDAval", GxErrorMask.GX_NOMASK,prmT000B35)
           ,new CursorDef("T000B36", "DELETE FROM [CLCLIENTESAVALES]  WHERE [CliCod] = @CliCod AND [CliDAval] = @CliDAval", GxErrorMask.GX_NOMASK,prmT000B36)
           ,new CursorDef("T000B37", "SELECT [CliCod], [CliDAval] FROM [CLCLIENTESAVALES] WHERE [CliCod] = @CliCod ORDER BY [CliCod], [CliDAval] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000B37,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
  }

}

}
