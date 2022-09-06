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
   public class sgusuarioniv2 : GXDataArea
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
            A342SGMenuPrograma = GetPar( "SGMenuPrograma");
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A342SGMenuPrograma = GetPar( "SGMenuPrograma");
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = GetPar( "SGMenuNiv2ID");
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID) ;
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
            Form.Meta.addItem("description", "SGUSUARIONIV2", 0) ;
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

      public sgusuarioniv2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuarioniv2( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGUSUARIONIV2", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIONIV2.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIONIV2.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuPrograma_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuPrograma_Internalname, "SGMenu Programa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuPrograma_Internalname, A342SGMenuPrograma, StringUtil.RTrim( context.localUtil.Format( A342SGMenuPrograma, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuPrograma_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuPrograma_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv1ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv1ID_Internalname, "ID", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv1ID_Internalname, A343SGMenuNiv1ID, StringUtil.RTrim( context.localUtil.Format( A343SGMenuNiv1ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv1ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv1ID_Enabled, 0, "text", "", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGMenuNiv2ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGMenuNiv2ID_Internalname, "ID Nivel 2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGMenuNiv2ID_Internalname, A344SGMenuNiv2ID, StringUtil.RTrim( context.localUtil.Format( A344SGMenuNiv2ID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGMenuNiv2ID_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGMenuNiv2ID_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN1New_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN1New_Internalname, "Nuevo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN1New_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1857SGUsuN1New), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN1New_Enabled!=0) ? context.localUtil.Format( (decimal)(A1857SGUsuN1New), "9") : context.localUtil.Format( (decimal)(A1857SGUsuN1New), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN1New_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN1New_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN1Upd_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN1Upd_Internalname, "Modificar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN1Upd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1859SGUsuN1Upd), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN1Upd_Enabled!=0) ? context.localUtil.Format( (decimal)(A1859SGUsuN1Upd), "9") : context.localUtil.Format( (decimal)(A1859SGUsuN1Upd), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN1Upd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN1Upd_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN1Del_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN1Del_Internalname, "Borrar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN1Del_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1855SGUsuN1Del), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN1Del_Enabled!=0) ? context.localUtil.Format( (decimal)(A1855SGUsuN1Del), "9") : context.localUtil.Format( (decimal)(A1855SGUsuN1Del), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN1Del_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN1Del_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN1DSP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN1DSP_Internalname, "Visualizar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN1DSP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1856SGUsuN1DSP), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN1DSP_Enabled!=0) ? context.localUtil.Format( (decimal)(A1856SGUsuN1DSP), "9") : context.localUtil.Format( (decimal)(A1856SGUsuN1DSP), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN1DSP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN1DSP_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGUsuN1Tot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGUsuN1Tot_Internalname, "Todos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGUsuN1Tot_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1858SGUsuN1Tot), 1, 0, ".", "")), StringUtil.LTrim( ((edtSGUsuN1Tot_Enabled!=0) ? context.localUtil.Format( (decimal)(A1858SGUsuN1Tot), "9") : context.localUtil.Format( (decimal)(A1858SGUsuN1Tot), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGUsuN1Tot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGUsuN1Tot_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGUSUARIONIV2.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV2.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIONIV2.htm");
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
            Z342SGMenuPrograma = cgiGet( "Z342SGMenuPrograma");
            Z343SGMenuNiv1ID = cgiGet( "Z343SGMenuNiv1ID");
            Z344SGMenuNiv2ID = cgiGet( "Z344SGMenuNiv2ID");
            Z1857SGUsuN1New = (short)(context.localUtil.CToN( cgiGet( "Z1857SGUsuN1New"), ".", ","));
            Z1859SGUsuN1Upd = (short)(context.localUtil.CToN( cgiGet( "Z1859SGUsuN1Upd"), ".", ","));
            Z1855SGUsuN1Del = (short)(context.localUtil.CToN( cgiGet( "Z1855SGUsuN1Del"), ".", ","));
            Z1856SGUsuN1DSP = (short)(context.localUtil.CToN( cgiGet( "Z1856SGUsuN1DSP"), ".", ","));
            Z1858SGUsuN1Tot = (short)(context.localUtil.CToN( cgiGet( "Z1858SGUsuN1Tot"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A348UsuCod = cgiGet( edtUsuCod_Internalname);
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = cgiGet( edtSGMenuPrograma_Internalname);
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = cgiGet( edtSGMenuNiv1ID_Internalname);
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = cgiGet( edtSGMenuNiv2ID_Internalname);
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1New_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1New_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN1NEW");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN1New_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1857SGUsuN1New = 0;
               AssignAttri("", false, "A1857SGUsuN1New", StringUtil.Str( (decimal)(A1857SGUsuN1New), 1, 0));
            }
            else
            {
               A1857SGUsuN1New = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN1New_Internalname), ".", ","));
               AssignAttri("", false, "A1857SGUsuN1New", StringUtil.Str( (decimal)(A1857SGUsuN1New), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1Upd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1Upd_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN1UPD");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN1Upd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1859SGUsuN1Upd = 0;
               AssignAttri("", false, "A1859SGUsuN1Upd", StringUtil.Str( (decimal)(A1859SGUsuN1Upd), 1, 0));
            }
            else
            {
               A1859SGUsuN1Upd = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN1Upd_Internalname), ".", ","));
               AssignAttri("", false, "A1859SGUsuN1Upd", StringUtil.Str( (decimal)(A1859SGUsuN1Upd), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1Del_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1Del_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN1DEL");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN1Del_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1855SGUsuN1Del = 0;
               AssignAttri("", false, "A1855SGUsuN1Del", StringUtil.Str( (decimal)(A1855SGUsuN1Del), 1, 0));
            }
            else
            {
               A1855SGUsuN1Del = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN1Del_Internalname), ".", ","));
               AssignAttri("", false, "A1855SGUsuN1Del", StringUtil.Str( (decimal)(A1855SGUsuN1Del), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1DSP_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1DSP_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN1DSP");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN1DSP_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1856SGUsuN1DSP = 0;
               AssignAttri("", false, "A1856SGUsuN1DSP", StringUtil.Str( (decimal)(A1856SGUsuN1DSP), 1, 0));
            }
            else
            {
               A1856SGUsuN1DSP = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN1DSP_Internalname), ".", ","));
               AssignAttri("", false, "A1856SGUsuN1DSP", StringUtil.Str( (decimal)(A1856SGUsuN1DSP), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1Tot_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSGUsuN1Tot_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SGUSUN1TOT");
               AnyError = 1;
               GX_FocusControl = edtSGUsuN1Tot_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1858SGUsuN1Tot = 0;
               AssignAttri("", false, "A1858SGUsuN1Tot", StringUtil.Str( (decimal)(A1858SGUsuN1Tot), 1, 0));
            }
            else
            {
               A1858SGUsuN1Tot = (short)(context.localUtil.CToN( cgiGet( edtSGUsuN1Tot_Internalname), ".", ","));
               AssignAttri("", false, "A1858SGUsuN1Tot", StringUtil.Str( (decimal)(A1858SGUsuN1Tot), 1, 0));
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
               A342SGMenuPrograma = GetPar( "SGMenuPrograma");
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = GetPar( "SGMenuNiv1ID");
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               A344SGMenuNiv2ID = GetPar( "SGMenuNiv2ID");
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
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
               InitAll0V30( ) ;
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
         DisableAttributes0V30( ) ;
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

      protected void ResetCaption0V0( )
      {
      }

      protected void ZM0V30( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1857SGUsuN1New = T000V3_A1857SGUsuN1New[0];
               Z1859SGUsuN1Upd = T000V3_A1859SGUsuN1Upd[0];
               Z1855SGUsuN1Del = T000V3_A1855SGUsuN1Del[0];
               Z1856SGUsuN1DSP = T000V3_A1856SGUsuN1DSP[0];
               Z1858SGUsuN1Tot = T000V3_A1858SGUsuN1Tot[0];
            }
            else
            {
               Z1857SGUsuN1New = A1857SGUsuN1New;
               Z1859SGUsuN1Upd = A1859SGUsuN1Upd;
               Z1855SGUsuN1Del = A1855SGUsuN1Del;
               Z1856SGUsuN1DSP = A1856SGUsuN1DSP;
               Z1858SGUsuN1Tot = A1858SGUsuN1Tot;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1857SGUsuN1New = A1857SGUsuN1New;
            Z1859SGUsuN1Upd = A1859SGUsuN1Upd;
            Z1855SGUsuN1Del = A1855SGUsuN1Del;
            Z1856SGUsuN1DSP = A1856SGUsuN1DSP;
            Z1858SGUsuN1Tot = A1858SGUsuN1Tot;
            Z348UsuCod = A348UsuCod;
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            Z344SGMenuNiv2ID = A344SGMenuNiv2ID;
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

      protected void Load0V30( )
      {
         /* Using cursor T000V6 */
         pr_default.execute(4, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound30 = 1;
            A1857SGUsuN1New = T000V6_A1857SGUsuN1New[0];
            AssignAttri("", false, "A1857SGUsuN1New", StringUtil.Str( (decimal)(A1857SGUsuN1New), 1, 0));
            A1859SGUsuN1Upd = T000V6_A1859SGUsuN1Upd[0];
            AssignAttri("", false, "A1859SGUsuN1Upd", StringUtil.Str( (decimal)(A1859SGUsuN1Upd), 1, 0));
            A1855SGUsuN1Del = T000V6_A1855SGUsuN1Del[0];
            AssignAttri("", false, "A1855SGUsuN1Del", StringUtil.Str( (decimal)(A1855SGUsuN1Del), 1, 0));
            A1856SGUsuN1DSP = T000V6_A1856SGUsuN1DSP[0];
            AssignAttri("", false, "A1856SGUsuN1DSP", StringUtil.Str( (decimal)(A1856SGUsuN1DSP), 1, 0));
            A1858SGUsuN1Tot = T000V6_A1858SGUsuN1Tot[0];
            AssignAttri("", false, "A1858SGUsuN1Tot", StringUtil.Str( (decimal)(A1858SGUsuN1Tot), 1, 0));
            ZM0V30( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0V30( ) ;
      }

      protected void OnLoadActions0V30( )
      {
      }

      protected void CheckExtendedTable0V30( )
      {
         nIsDirty_30 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000V4 */
         pr_default.execute(2, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000V5 */
         pr_default.execute(3, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0V30( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A348UsuCod ,
                               string A342SGMenuPrograma ,
                               string A343SGMenuNiv1ID )
      {
         /* Using cursor T000V7 */
         pr_default.execute(5, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
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

      protected void gxLoad_3( string A342SGMenuPrograma ,
                               string A343SGMenuNiv1ID ,
                               string A344SGMenuNiv2ID )
      {
         /* Using cursor T000V8 */
         pr_default.execute(6, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
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

      protected void GetKey0V30( )
      {
         /* Using cursor T000V9 */
         pr_default.execute(7, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000V3 */
         pr_default.execute(1, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0V30( 1) ;
            RcdFound30 = 1;
            A1857SGUsuN1New = T000V3_A1857SGUsuN1New[0];
            AssignAttri("", false, "A1857SGUsuN1New", StringUtil.Str( (decimal)(A1857SGUsuN1New), 1, 0));
            A1859SGUsuN1Upd = T000V3_A1859SGUsuN1Upd[0];
            AssignAttri("", false, "A1859SGUsuN1Upd", StringUtil.Str( (decimal)(A1859SGUsuN1Upd), 1, 0));
            A1855SGUsuN1Del = T000V3_A1855SGUsuN1Del[0];
            AssignAttri("", false, "A1855SGUsuN1Del", StringUtil.Str( (decimal)(A1855SGUsuN1Del), 1, 0));
            A1856SGUsuN1DSP = T000V3_A1856SGUsuN1DSP[0];
            AssignAttri("", false, "A1856SGUsuN1DSP", StringUtil.Str( (decimal)(A1856SGUsuN1DSP), 1, 0));
            A1858SGUsuN1Tot = T000V3_A1858SGUsuN1Tot[0];
            AssignAttri("", false, "A1858SGUsuN1Tot", StringUtil.Str( (decimal)(A1858SGUsuN1Tot), 1, 0));
            A348UsuCod = T000V3_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000V3_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000V3_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000V3_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
            Z348UsuCod = A348UsuCod;
            Z342SGMenuPrograma = A342SGMenuPrograma;
            Z343SGMenuNiv1ID = A343SGMenuNiv1ID;
            Z344SGMenuNiv2ID = A344SGMenuNiv2ID;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0V30( ) ;
            if ( AnyError == 1 )
            {
               RcdFound30 = 0;
               InitializeNonKey0V30( ) ;
            }
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0V30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0V30( ) ;
         if ( RcdFound30 == 0 )
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
         RcdFound30 = 0;
         /* Using cursor T000V10 */
         pr_default.execute(8, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V10_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000V10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) || ( StringUtil.StrCmp(T000V10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000V10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V10_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V10_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000V10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) || ( StringUtil.StrCmp(T000V10_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000V10_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V10_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V10_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) > 0 ) ) )
            {
               A348UsuCod = T000V10_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A342SGMenuPrograma = T000V10_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000V10_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               A344SGMenuNiv2ID = T000V10_A344SGMenuNiv2ID[0];
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
               RcdFound30 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound30 = 0;
         /* Using cursor T000V11 */
         pr_default.execute(9, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) > 0 ) || ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V11_A342SGMenuPrograma[0], A342SGMenuPrograma) > 0 ) || ( StringUtil.StrCmp(T000V11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) > 0 ) || ( StringUtil.StrCmp(T000V11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000V11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V11_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) < 0 ) || ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V11_A342SGMenuPrograma[0], A342SGMenuPrograma) < 0 ) || ( StringUtil.StrCmp(T000V11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) < 0 ) || ( StringUtil.StrCmp(T000V11_A343SGMenuNiv1ID[0], A343SGMenuNiv1ID) == 0 ) && ( StringUtil.StrCmp(T000V11_A342SGMenuPrograma[0], A342SGMenuPrograma) == 0 ) && ( StringUtil.StrCmp(T000V11_A348UsuCod[0], A348UsuCod) == 0 ) && ( StringUtil.StrCmp(T000V11_A344SGMenuNiv2ID[0], A344SGMenuNiv2ID) < 0 ) ) )
            {
               A348UsuCod = T000V11_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               A342SGMenuPrograma = T000V11_A342SGMenuPrograma[0];
               AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
               A343SGMenuNiv1ID = T000V11_A343SGMenuNiv1ID[0];
               AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
               A344SGMenuNiv2ID = T000V11_A344SGMenuNiv2ID[0];
               AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
               RcdFound30 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0V30( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0V30( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound30 == 1 )
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
                  A342SGMenuPrograma = Z342SGMenuPrograma;
                  AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
                  A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
                  AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
                  A344SGMenuNiv2ID = Z344SGMenuNiv2ID;
                  AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
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
                  Update0V30( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0V30( ) ;
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
                     Insert0V30( ) ;
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
         if ( ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 ) || ( StringUtil.StrCmp(A342SGMenuPrograma, Z342SGMenuPrograma) != 0 ) || ( StringUtil.StrCmp(A343SGMenuNiv1ID, Z343SGMenuNiv1ID) != 0 ) || ( StringUtil.StrCmp(A344SGMenuNiv2ID, Z344SGMenuNiv2ID) != 0 ) )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = Z342SGMenuPrograma;
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = Z343SGMenuNiv1ID;
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = Z344SGMenuNiv2ID;
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSGUsuN1New_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0V30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN1New_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0V30( ) ;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN1New_Internalname;
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
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN1New_Internalname;
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
         ScanStart0V30( ) ;
         if ( RcdFound30 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound30 != 0 )
            {
               ScanNext0V30( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGUsuN1New_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0V30( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0V30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000V2 */
            pr_default.execute(0, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIONIV2"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1857SGUsuN1New != T000V2_A1857SGUsuN1New[0] ) || ( Z1859SGUsuN1Upd != T000V2_A1859SGUsuN1Upd[0] ) || ( Z1855SGUsuN1Del != T000V2_A1855SGUsuN1Del[0] ) || ( Z1856SGUsuN1DSP != T000V2_A1856SGUsuN1DSP[0] ) || ( Z1858SGUsuN1Tot != T000V2_A1858SGUsuN1Tot[0] ) )
            {
               if ( Z1857SGUsuN1New != T000V2_A1857SGUsuN1New[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv2:[seudo value changed for attri]"+"SGUsuN1New");
                  GXUtil.WriteLogRaw("Old: ",Z1857SGUsuN1New);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A1857SGUsuN1New[0]);
               }
               if ( Z1859SGUsuN1Upd != T000V2_A1859SGUsuN1Upd[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv2:[seudo value changed for attri]"+"SGUsuN1Upd");
                  GXUtil.WriteLogRaw("Old: ",Z1859SGUsuN1Upd);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A1859SGUsuN1Upd[0]);
               }
               if ( Z1855SGUsuN1Del != T000V2_A1855SGUsuN1Del[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv2:[seudo value changed for attri]"+"SGUsuN1Del");
                  GXUtil.WriteLogRaw("Old: ",Z1855SGUsuN1Del);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A1855SGUsuN1Del[0]);
               }
               if ( Z1856SGUsuN1DSP != T000V2_A1856SGUsuN1DSP[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv2:[seudo value changed for attri]"+"SGUsuN1DSP");
                  GXUtil.WriteLogRaw("Old: ",Z1856SGUsuN1DSP);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A1856SGUsuN1DSP[0]);
               }
               if ( Z1858SGUsuN1Tot != T000V2_A1858SGUsuN1Tot[0] )
               {
                  GXUtil.WriteLog("sgusuarioniv2:[seudo value changed for attri]"+"SGUsuN1Tot");
                  GXUtil.WriteLogRaw("Old: ",Z1858SGUsuN1Tot);
                  GXUtil.WriteLogRaw("Current: ",T000V2_A1858SGUsuN1Tot[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIONIV2"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0V30( )
      {
         BeforeValidate0V30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0V30( 0) ;
            CheckOptimisticConcurrency0V30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0V30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V12 */
                     pr_default.execute(10, new Object[] {A1857SGUsuN1New, A1859SGUsuN1Upd, A1855SGUsuN1Del, A1856SGUsuN1DSP, A1858SGUsuN1Tot, A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV2");
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
                           ResetCaption0V0( ) ;
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
               Load0V30( ) ;
            }
            EndLevel0V30( ) ;
         }
         CloseExtendedTableCursors0V30( ) ;
      }

      protected void Update0V30( )
      {
         BeforeValidate0V30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0V30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0V30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0V30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000V13 */
                     pr_default.execute(11, new Object[] {A1857SGUsuN1New, A1859SGUsuN1Upd, A1855SGUsuN1Del, A1856SGUsuN1DSP, A1858SGUsuN1Tot, A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV2");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIONIV2"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0V30( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0V0( ) ;
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
            EndLevel0V30( ) ;
         }
         CloseExtendedTableCursors0V30( ) ;
      }

      protected void DeferredUpdate0V30( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0V30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0V30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0V30( ) ;
            AfterConfirm0V30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0V30( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000V14 */
                  pr_default.execute(12, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIONIV2");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound30 == 0 )
                        {
                           InitAll0V30( ) ;
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
                        ResetCaption0V0( ) ;
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0V30( ) ;
         Gx_mode = sMode30;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0V30( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000V15 */
            pr_default.execute(13, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV3"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0V30( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0V30( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgusuarioniv2",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgusuarioniv2",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0V30( )
      {
         /* Using cursor T000V16 */
         pr_default.execute(14);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound30 = 1;
            A348UsuCod = T000V16_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000V16_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000V16_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000V16_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0V30( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound30 = 1;
            A348UsuCod = T000V16_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            A342SGMenuPrograma = T000V16_A342SGMenuPrograma[0];
            AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
            A343SGMenuNiv1ID = T000V16_A343SGMenuNiv1ID[0];
            AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
            A344SGMenuNiv2ID = T000V16_A344SGMenuNiv2ID[0];
            AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
         }
      }

      protected void ScanEnd0V30( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0V30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0V30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0V30( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0V30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0V30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0V30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0V30( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
         edtSGMenuPrograma_Enabled = 0;
         AssignProp("", false, edtSGMenuPrograma_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuPrograma_Enabled), 5, 0), true);
         edtSGMenuNiv1ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv1ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv1ID_Enabled), 5, 0), true);
         edtSGMenuNiv2ID_Enabled = 0;
         AssignProp("", false, edtSGMenuNiv2ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGMenuNiv2ID_Enabled), 5, 0), true);
         edtSGUsuN1New_Enabled = 0;
         AssignProp("", false, edtSGUsuN1New_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN1New_Enabled), 5, 0), true);
         edtSGUsuN1Upd_Enabled = 0;
         AssignProp("", false, edtSGUsuN1Upd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN1Upd_Enabled), 5, 0), true);
         edtSGUsuN1Del_Enabled = 0;
         AssignProp("", false, edtSGUsuN1Del_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN1Del_Enabled), 5, 0), true);
         edtSGUsuN1DSP_Enabled = 0;
         AssignProp("", false, edtSGUsuN1DSP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN1DSP_Enabled), 5, 0), true);
         edtSGUsuN1Tot_Enabled = 0;
         AssignProp("", false, edtSGUsuN1Tot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGUsuN1Tot_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0V30( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0V0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442761", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuarioniv2.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, "Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, "Z344SGMenuNiv2ID", Z344SGMenuNiv2ID);
         GxWebStd.gx_hidden_field( context, "Z1857SGUsuN1New", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1857SGUsuN1New), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1859SGUsuN1Upd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1859SGUsuN1Upd), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1855SGUsuN1Del", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1855SGUsuN1Del), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1856SGUsuN1DSP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1856SGUsuN1DSP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1858SGUsuN1Tot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1858SGUsuN1Tot), 1, 0, ".", "")));
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
         return formatLink("sgusuarioniv2.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGUSUARIONIV2" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGUSUARIONIV2" ;
      }

      protected void InitializeNonKey0V30( )
      {
         A1857SGUsuN1New = 0;
         AssignAttri("", false, "A1857SGUsuN1New", StringUtil.Str( (decimal)(A1857SGUsuN1New), 1, 0));
         A1859SGUsuN1Upd = 0;
         AssignAttri("", false, "A1859SGUsuN1Upd", StringUtil.Str( (decimal)(A1859SGUsuN1Upd), 1, 0));
         A1855SGUsuN1Del = 0;
         AssignAttri("", false, "A1855SGUsuN1Del", StringUtil.Str( (decimal)(A1855SGUsuN1Del), 1, 0));
         A1856SGUsuN1DSP = 0;
         AssignAttri("", false, "A1856SGUsuN1DSP", StringUtil.Str( (decimal)(A1856SGUsuN1DSP), 1, 0));
         A1858SGUsuN1Tot = 0;
         AssignAttri("", false, "A1858SGUsuN1Tot", StringUtil.Str( (decimal)(A1858SGUsuN1Tot), 1, 0));
         Z1857SGUsuN1New = 0;
         Z1859SGUsuN1Upd = 0;
         Z1855SGUsuN1Del = 0;
         Z1856SGUsuN1DSP = 0;
         Z1858SGUsuN1Tot = 0;
      }

      protected void InitAll0V30( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         A342SGMenuPrograma = "";
         AssignAttri("", false, "A342SGMenuPrograma", A342SGMenuPrograma);
         A343SGMenuNiv1ID = "";
         AssignAttri("", false, "A343SGMenuNiv1ID", A343SGMenuNiv1ID);
         A344SGMenuNiv2ID = "";
         AssignAttri("", false, "A344SGMenuNiv2ID", A344SGMenuNiv2ID);
         InitializeNonKey0V30( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811442769", true, true);
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
         context.AddJavascriptSource("sgusuarioniv2.js", "?202281811442770", false, true);
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
         edtSGMenuPrograma_Internalname = "SGMENUPROGRAMA";
         edtSGMenuNiv1ID_Internalname = "SGMENUNIV1ID";
         edtSGMenuNiv2ID_Internalname = "SGMENUNIV2ID";
         edtSGUsuN1New_Internalname = "SGUSUN1NEW";
         edtSGUsuN1Upd_Internalname = "SGUSUN1UPD";
         edtSGUsuN1Del_Internalname = "SGUSUN1DEL";
         edtSGUsuN1DSP_Internalname = "SGUSUN1DSP";
         edtSGUsuN1Tot_Internalname = "SGUSUN1TOT";
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
         Form.Caption = "SGUSUARIONIV2";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSGUsuN1Tot_Jsonclick = "";
         edtSGUsuN1Tot_Enabled = 1;
         edtSGUsuN1DSP_Jsonclick = "";
         edtSGUsuN1DSP_Enabled = 1;
         edtSGUsuN1Del_Jsonclick = "";
         edtSGUsuN1Del_Enabled = 1;
         edtSGUsuN1Upd_Jsonclick = "";
         edtSGUsuN1Upd_Enabled = 1;
         edtSGUsuN1New_Jsonclick = "";
         edtSGUsuN1New_Enabled = 1;
         edtSGMenuNiv2ID_Jsonclick = "";
         edtSGMenuNiv2ID_Enabled = 1;
         edtSGMenuNiv1ID_Jsonclick = "";
         edtSGMenuNiv1ID_Enabled = 1;
         edtSGMenuPrograma_Jsonclick = "";
         edtSGMenuPrograma_Enabled = 1;
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
         /* Using cursor T000V17 */
         pr_default.execute(15, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         /* Using cursor T000V18 */
         pr_default.execute(16, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(16);
         GX_FocusControl = edtSGUsuN1New_Internalname;
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

      public void Valid_Sgmenuniv1id( )
      {
         /* Using cursor T000V17 */
         pr_default.execute(15, new Object[] {A348UsuCod, A342SGMenuPrograma, A343SGMenuNiv1ID});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'SGUSUARIONIV1'.", "ForeignKeyNotFound", 1, "SGMENUNIV1ID");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sgmenuniv2id( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000V18 */
         pr_default.execute(16, new Object[] {A342SGMenuPrograma, A343SGMenuNiv1ID, A344SGMenuNiv2ID});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Nivel 2'.", "ForeignKeyNotFound", 1, "SGMENUNIV2ID");
            AnyError = 1;
            GX_FocusControl = edtSGMenuPrograma_Internalname;
         }
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1857SGUsuN1New", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1857SGUsuN1New), 1, 0, ".", "")));
         AssignAttri("", false, "A1859SGUsuN1Upd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1859SGUsuN1Upd), 1, 0, ".", "")));
         AssignAttri("", false, "A1855SGUsuN1Del", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1855SGUsuN1Del), 1, 0, ".", "")));
         AssignAttri("", false, "A1856SGUsuN1DSP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1856SGUsuN1DSP), 1, 0, ".", "")));
         AssignAttri("", false, "A1858SGUsuN1Tot", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1858SGUsuN1Tot), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         GxWebStd.gx_hidden_field( context, "Z342SGMenuPrograma", Z342SGMenuPrograma);
         GxWebStd.gx_hidden_field( context, "Z343SGMenuNiv1ID", Z343SGMenuNiv1ID);
         GxWebStd.gx_hidden_field( context, "Z344SGMenuNiv2ID", Z344SGMenuNiv2ID);
         GxWebStd.gx_hidden_field( context, "Z1857SGUsuN1New", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1857SGUsuN1New), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1859SGUsuN1Upd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1859SGUsuN1Upd), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1855SGUsuN1Del", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1855SGUsuN1Del), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1856SGUsuN1DSP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1856SGUsuN1DSP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1858SGUsuN1Tot", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1858SGUsuN1Tot), 1, 0, ".", "")));
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
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[]");
         setEventMetadata("VALID_USUCOD",",oparms:[]}");
         setEventMetadata("VALID_SGMENUPROGRAMA","{handler:'Valid_Sgmenuprograma',iparms:[]");
         setEventMetadata("VALID_SGMENUPROGRAMA",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV1ID","{handler:'Valid_Sgmenuniv1id',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''}]");
         setEventMetadata("VALID_SGMENUNIV1ID",",oparms:[]}");
         setEventMetadata("VALID_SGMENUNIV2ID","{handler:'Valid_Sgmenuniv2id',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'A342SGMenuPrograma',fld:'SGMENUPROGRAMA',pic:''},{av:'A343SGMenuNiv1ID',fld:'SGMENUNIV1ID',pic:''},{av:'A344SGMenuNiv2ID',fld:'SGMENUNIV2ID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGMENUNIV2ID",",oparms:[{av:'A1857SGUsuN1New',fld:'SGUSUN1NEW',pic:'9'},{av:'A1859SGUsuN1Upd',fld:'SGUSUN1UPD',pic:'9'},{av:'A1855SGUsuN1Del',fld:'SGUSUN1DEL',pic:'9'},{av:'A1856SGUsuN1DSP',fld:'SGUSUN1DSP',pic:'9'},{av:'A1858SGUsuN1Tot',fld:'SGUSUN1TOT',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{av:'Z342SGMenuPrograma'},{av:'Z343SGMenuNiv1ID'},{av:'Z344SGMenuNiv2ID'},{av:'Z1857SGUsuN1New'},{av:'Z1859SGUsuN1Upd'},{av:'Z1855SGUsuN1Del'},{av:'Z1856SGUsuN1DSP'},{av:'Z1858SGUsuN1Tot'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         Z342SGMenuPrograma = "";
         Z343SGMenuNiv1ID = "";
         Z344SGMenuNiv2ID = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A348UsuCod = "";
         A342SGMenuPrograma = "";
         A343SGMenuNiv1ID = "";
         A344SGMenuNiv2ID = "";
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
         T000V6_A1857SGUsuN1New = new short[1] ;
         T000V6_A1859SGUsuN1Upd = new short[1] ;
         T000V6_A1855SGUsuN1Del = new short[1] ;
         T000V6_A1856SGUsuN1DSP = new short[1] ;
         T000V6_A1858SGUsuN1Tot = new short[1] ;
         T000V6_A348UsuCod = new string[] {""} ;
         T000V6_A342SGMenuPrograma = new string[] {""} ;
         T000V6_A343SGMenuNiv1ID = new string[] {""} ;
         T000V6_A344SGMenuNiv2ID = new string[] {""} ;
         T000V4_A348UsuCod = new string[] {""} ;
         T000V5_A342SGMenuPrograma = new string[] {""} ;
         T000V7_A348UsuCod = new string[] {""} ;
         T000V8_A342SGMenuPrograma = new string[] {""} ;
         T000V9_A348UsuCod = new string[] {""} ;
         T000V9_A342SGMenuPrograma = new string[] {""} ;
         T000V9_A343SGMenuNiv1ID = new string[] {""} ;
         T000V9_A344SGMenuNiv2ID = new string[] {""} ;
         T000V3_A1857SGUsuN1New = new short[1] ;
         T000V3_A1859SGUsuN1Upd = new short[1] ;
         T000V3_A1855SGUsuN1Del = new short[1] ;
         T000V3_A1856SGUsuN1DSP = new short[1] ;
         T000V3_A1858SGUsuN1Tot = new short[1] ;
         T000V3_A348UsuCod = new string[] {""} ;
         T000V3_A342SGMenuPrograma = new string[] {""} ;
         T000V3_A343SGMenuNiv1ID = new string[] {""} ;
         T000V3_A344SGMenuNiv2ID = new string[] {""} ;
         sMode30 = "";
         T000V10_A348UsuCod = new string[] {""} ;
         T000V10_A342SGMenuPrograma = new string[] {""} ;
         T000V10_A343SGMenuNiv1ID = new string[] {""} ;
         T000V10_A344SGMenuNiv2ID = new string[] {""} ;
         T000V11_A348UsuCod = new string[] {""} ;
         T000V11_A342SGMenuPrograma = new string[] {""} ;
         T000V11_A343SGMenuNiv1ID = new string[] {""} ;
         T000V11_A344SGMenuNiv2ID = new string[] {""} ;
         T000V2_A1857SGUsuN1New = new short[1] ;
         T000V2_A1859SGUsuN1Upd = new short[1] ;
         T000V2_A1855SGUsuN1Del = new short[1] ;
         T000V2_A1856SGUsuN1DSP = new short[1] ;
         T000V2_A1858SGUsuN1Tot = new short[1] ;
         T000V2_A348UsuCod = new string[] {""} ;
         T000V2_A342SGMenuPrograma = new string[] {""} ;
         T000V2_A343SGMenuNiv1ID = new string[] {""} ;
         T000V2_A344SGMenuNiv2ID = new string[] {""} ;
         T000V15_A348UsuCod = new string[] {""} ;
         T000V15_A342SGMenuPrograma = new string[] {""} ;
         T000V15_A343SGMenuNiv1ID = new string[] {""} ;
         T000V15_A344SGMenuNiv2ID = new string[] {""} ;
         T000V15_A345SGMenuNiv3ID = new string[] {""} ;
         T000V16_A348UsuCod = new string[] {""} ;
         T000V16_A342SGMenuPrograma = new string[] {""} ;
         T000V16_A343SGMenuNiv1ID = new string[] {""} ;
         T000V16_A344SGMenuNiv2ID = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000V17_A348UsuCod = new string[] {""} ;
         T000V18_A342SGMenuPrograma = new string[] {""} ;
         ZZ348UsuCod = "";
         ZZ342SGMenuPrograma = "";
         ZZ343SGMenuNiv1ID = "";
         ZZ344SGMenuNiv2ID = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioniv2__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuarioniv2__default(),
            new Object[][] {
                new Object[] {
               T000V2_A1857SGUsuN1New, T000V2_A1859SGUsuN1Upd, T000V2_A1855SGUsuN1Del, T000V2_A1856SGUsuN1DSP, T000V2_A1858SGUsuN1Tot, T000V2_A348UsuCod, T000V2_A342SGMenuPrograma, T000V2_A343SGMenuNiv1ID, T000V2_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000V3_A1857SGUsuN1New, T000V3_A1859SGUsuN1Upd, T000V3_A1855SGUsuN1Del, T000V3_A1856SGUsuN1DSP, T000V3_A1858SGUsuN1Tot, T000V3_A348UsuCod, T000V3_A342SGMenuPrograma, T000V3_A343SGMenuNiv1ID, T000V3_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000V4_A348UsuCod
               }
               , new Object[] {
               T000V5_A342SGMenuPrograma
               }
               , new Object[] {
               T000V6_A1857SGUsuN1New, T000V6_A1859SGUsuN1Upd, T000V6_A1855SGUsuN1Del, T000V6_A1856SGUsuN1DSP, T000V6_A1858SGUsuN1Tot, T000V6_A348UsuCod, T000V6_A342SGMenuPrograma, T000V6_A343SGMenuNiv1ID, T000V6_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000V7_A348UsuCod
               }
               , new Object[] {
               T000V8_A342SGMenuPrograma
               }
               , new Object[] {
               T000V9_A348UsuCod, T000V9_A342SGMenuPrograma, T000V9_A343SGMenuNiv1ID, T000V9_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000V10_A348UsuCod, T000V10_A342SGMenuPrograma, T000V10_A343SGMenuNiv1ID, T000V10_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000V11_A348UsuCod, T000V11_A342SGMenuPrograma, T000V11_A343SGMenuNiv1ID, T000V11_A344SGMenuNiv2ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000V15_A348UsuCod, T000V15_A342SGMenuPrograma, T000V15_A343SGMenuNiv1ID, T000V15_A344SGMenuNiv2ID, T000V15_A345SGMenuNiv3ID
               }
               , new Object[] {
               T000V16_A348UsuCod, T000V16_A342SGMenuPrograma, T000V16_A343SGMenuNiv1ID, T000V16_A344SGMenuNiv2ID
               }
               , new Object[] {
               T000V17_A348UsuCod
               }
               , new Object[] {
               T000V18_A342SGMenuPrograma
               }
            }
         );
      }

      private short Z1857SGUsuN1New ;
      private short Z1859SGUsuN1Upd ;
      private short Z1855SGUsuN1Del ;
      private short Z1856SGUsuN1DSP ;
      private short Z1858SGUsuN1Tot ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1857SGUsuN1New ;
      private short A1859SGUsuN1Upd ;
      private short A1855SGUsuN1Del ;
      private short A1856SGUsuN1DSP ;
      private short A1858SGUsuN1Tot ;
      private short GX_JID ;
      private short RcdFound30 ;
      private short nIsDirty_30 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1857SGUsuN1New ;
      private short ZZ1859SGUsuN1Upd ;
      private short ZZ1855SGUsuN1Del ;
      private short ZZ1856SGUsuN1DSP ;
      private short ZZ1858SGUsuN1Tot ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int edtSGMenuPrograma_Enabled ;
      private int edtSGMenuNiv1ID_Enabled ;
      private int edtSGMenuNiv2ID_Enabled ;
      private int edtSGUsuN1New_Enabled ;
      private int edtSGUsuN1Upd_Enabled ;
      private int edtSGUsuN1Del_Enabled ;
      private int edtSGUsuN1DSP_Enabled ;
      private int edtSGUsuN1Tot_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
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
      private string edtSGMenuPrograma_Internalname ;
      private string edtSGMenuPrograma_Jsonclick ;
      private string edtSGMenuNiv1ID_Internalname ;
      private string edtSGMenuNiv1ID_Jsonclick ;
      private string edtSGMenuNiv2ID_Internalname ;
      private string edtSGMenuNiv2ID_Jsonclick ;
      private string edtSGUsuN1New_Internalname ;
      private string edtSGUsuN1New_Jsonclick ;
      private string edtSGUsuN1Upd_Internalname ;
      private string edtSGUsuN1Upd_Jsonclick ;
      private string edtSGUsuN1Del_Internalname ;
      private string edtSGUsuN1Del_Jsonclick ;
      private string edtSGUsuN1DSP_Internalname ;
      private string edtSGUsuN1DSP_Jsonclick ;
      private string edtSGUsuN1Tot_Internalname ;
      private string edtSGUsuN1Tot_Jsonclick ;
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
      private string sMode30 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ348UsuCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z342SGMenuPrograma ;
      private string Z343SGMenuNiv1ID ;
      private string Z344SGMenuNiv2ID ;
      private string A342SGMenuPrograma ;
      private string A343SGMenuNiv1ID ;
      private string A344SGMenuNiv2ID ;
      private string ZZ342SGMenuPrograma ;
      private string ZZ343SGMenuNiv1ID ;
      private string ZZ344SGMenuNiv2ID ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T000V6_A1857SGUsuN1New ;
      private short[] T000V6_A1859SGUsuN1Upd ;
      private short[] T000V6_A1855SGUsuN1Del ;
      private short[] T000V6_A1856SGUsuN1DSP ;
      private short[] T000V6_A1858SGUsuN1Tot ;
      private string[] T000V6_A348UsuCod ;
      private string[] T000V6_A342SGMenuPrograma ;
      private string[] T000V6_A343SGMenuNiv1ID ;
      private string[] T000V6_A344SGMenuNiv2ID ;
      private string[] T000V4_A348UsuCod ;
      private string[] T000V5_A342SGMenuPrograma ;
      private string[] T000V7_A348UsuCod ;
      private string[] T000V8_A342SGMenuPrograma ;
      private string[] T000V9_A348UsuCod ;
      private string[] T000V9_A342SGMenuPrograma ;
      private string[] T000V9_A343SGMenuNiv1ID ;
      private string[] T000V9_A344SGMenuNiv2ID ;
      private short[] T000V3_A1857SGUsuN1New ;
      private short[] T000V3_A1859SGUsuN1Upd ;
      private short[] T000V3_A1855SGUsuN1Del ;
      private short[] T000V3_A1856SGUsuN1DSP ;
      private short[] T000V3_A1858SGUsuN1Tot ;
      private string[] T000V3_A348UsuCod ;
      private string[] T000V3_A342SGMenuPrograma ;
      private string[] T000V3_A343SGMenuNiv1ID ;
      private string[] T000V3_A344SGMenuNiv2ID ;
      private string[] T000V10_A348UsuCod ;
      private string[] T000V10_A342SGMenuPrograma ;
      private string[] T000V10_A343SGMenuNiv1ID ;
      private string[] T000V10_A344SGMenuNiv2ID ;
      private string[] T000V11_A348UsuCod ;
      private string[] T000V11_A342SGMenuPrograma ;
      private string[] T000V11_A343SGMenuNiv1ID ;
      private string[] T000V11_A344SGMenuNiv2ID ;
      private short[] T000V2_A1857SGUsuN1New ;
      private short[] T000V2_A1859SGUsuN1Upd ;
      private short[] T000V2_A1855SGUsuN1Del ;
      private short[] T000V2_A1856SGUsuN1DSP ;
      private short[] T000V2_A1858SGUsuN1Tot ;
      private string[] T000V2_A348UsuCod ;
      private string[] T000V2_A342SGMenuPrograma ;
      private string[] T000V2_A343SGMenuNiv1ID ;
      private string[] T000V2_A344SGMenuNiv2ID ;
      private string[] T000V15_A348UsuCod ;
      private string[] T000V15_A342SGMenuPrograma ;
      private string[] T000V15_A343SGMenuNiv1ID ;
      private string[] T000V15_A344SGMenuNiv2ID ;
      private string[] T000V15_A345SGMenuNiv3ID ;
      private string[] T000V16_A348UsuCod ;
      private string[] T000V16_A342SGMenuPrograma ;
      private string[] T000V16_A343SGMenuNiv1ID ;
      private string[] T000V16_A344SGMenuNiv2ID ;
      private string[] T000V17_A348UsuCod ;
      private string[] T000V18_A342SGMenuPrograma ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgusuarioniv2__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuarioniv2__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000V6;
        prmT000V6 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V4;
        prmT000V4 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000V5;
        prmT000V5 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V7;
        prmT000V7 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000V8;
        prmT000V8 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V9;
        prmT000V9 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V3;
        prmT000V3 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V10;
        prmT000V10 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V11;
        prmT000V11 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V2;
        prmT000V2 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V12;
        prmT000V12 = new Object[] {
        new ParDef("@SGUsuN1New",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Upd",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Del",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1DSP",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Tot",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V13;
        prmT000V13 = new Object[] {
        new ParDef("@SGUsuN1New",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Upd",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Del",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1DSP",GXType.Int16,1,0) ,
        new ParDef("@SGUsuN1Tot",GXType.Int16,1,0) ,
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V14;
        prmT000V14 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V15;
        prmT000V15 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        Object[] prmT000V16;
        prmT000V16 = new Object[] {
        };
        Object[] prmT000V17;
        prmT000V17 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0)
        };
        Object[] prmT000V18;
        prmT000V18 = new Object[] {
        new ParDef("@SGMenuPrograma",GXType.NVarChar,20,0) ,
        new ParDef("@SGMenuNiv1ID",GXType.NVarChar,2,0) ,
        new ParDef("@SGMenuNiv2ID",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000V2", "SELECT [SGUsuN1New], [SGUsuN1Upd], [SGUsuN1Del], [SGUsuN1DSP], [SGUsuN1Tot], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGUSUARIONIV2] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V3", "SELECT [SGUsuN1New], [SGUsuN1Upd], [SGUsuN1Del], [SGUsuN1DSP], [SGUsuN1Tot], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGUSUARIONIV2] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V4", "SELECT [UsuCod] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V5", "SELECT [SGMenuPrograma] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V6", "SELECT TM1.[SGUsuN1New], TM1.[SGUsuN1Upd], TM1.[SGUsuN1Del], TM1.[SGUsuN1DSP], TM1.[SGUsuN1Tot], TM1.[UsuCod], TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID], TM1.[SGMenuNiv2ID] FROM [SGUSUARIONIV2] TM1 WHERE TM1.[UsuCod] = @UsuCod and TM1.[SGMenuPrograma] = @SGMenuPrograma and TM1.[SGMenuNiv1ID] = @SGMenuNiv1ID and TM1.[SGMenuNiv2ID] = @SGMenuNiv2ID ORDER BY TM1.[UsuCod], TM1.[SGMenuPrograma], TM1.[SGMenuNiv1ID], TM1.[SGMenuNiv2ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V7", "SELECT [UsuCod] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V8", "SELECT [SGMenuPrograma] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V9", "SELECT [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGUSUARIONIV2] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V10", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGUSUARIONIV2] WHERE ( [UsuCod] > @UsuCod or [UsuCod] = @UsuCod and [SGMenuPrograma] > @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv1ID] > @SGMenuNiv1ID or [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv2ID] > @SGMenuNiv2ID) ORDER BY [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V11", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGUSUARIONIV2] WHERE ( [UsuCod] < @UsuCod or [UsuCod] = @UsuCod and [SGMenuPrograma] < @SGMenuPrograma or [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv1ID] < @SGMenuNiv1ID or [SGMenuNiv1ID] = @SGMenuNiv1ID and [SGMenuPrograma] = @SGMenuPrograma and [UsuCod] = @UsuCod and [SGMenuNiv2ID] < @SGMenuNiv2ID) ORDER BY [UsuCod] DESC, [SGMenuPrograma] DESC, [SGMenuNiv1ID] DESC, [SGMenuNiv2ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V12", "INSERT INTO [SGUSUARIONIV2]([SGUsuN1New], [SGUsuN1Upd], [SGUsuN1Del], [SGUsuN1DSP], [SGUsuN1Tot], [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID]) VALUES(@SGUsuN1New, @SGUsuN1Upd, @SGUsuN1Del, @SGUsuN1DSP, @SGUsuN1Tot, @UsuCod, @SGMenuPrograma, @SGMenuNiv1ID, @SGMenuNiv2ID)", GxErrorMask.GX_NOMASK,prmT000V12)
           ,new CursorDef("T000V13", "UPDATE [SGUSUARIONIV2] SET [SGUsuN1New]=@SGUsuN1New, [SGUsuN1Upd]=@SGUsuN1Upd, [SGUsuN1Del]=@SGUsuN1Del, [SGUsuN1DSP]=@SGUsuN1DSP, [SGUsuN1Tot]=@SGUsuN1Tot  WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID", GxErrorMask.GX_NOMASK,prmT000V13)
           ,new CursorDef("T000V14", "DELETE FROM [SGUSUARIONIV2]  WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID", GxErrorMask.GX_NOMASK,prmT000V14)
           ,new CursorDef("T000V15", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID], [SGMenuNiv3ID] FROM [SGUSUARIONIV3] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000V16", "SELECT [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID] FROM [SGUSUARIONIV2] ORDER BY [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID], [SGMenuNiv2ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000V16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V17", "SELECT [UsuCod] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod AND [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000V18", "SELECT [SGMenuPrograma] FROM [SGMENUNIV2] WHERE [SGMenuPrograma] = @SGMenuPrograma AND [SGMenuNiv1ID] = @SGMenuNiv1ID AND [SGMenuNiv2ID] = @SGMenuNiv2ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000V18,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 10);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
