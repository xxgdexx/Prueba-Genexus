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
   public class clclientescontactos : GXDataArea
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
            A45CliCod = GetPar( "CliCod");
            AssignAttri("", false, "A45CliCod", A45CliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A45CliCod) ;
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
            Form.Meta.addItem("description", "Clientes Contacto", 0) ;
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

      public clclientescontactos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clclientescontactos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Clientes Contacto", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESCONTACTOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCLIENTESCONTACTOS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliConCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliConCod_Internalname, "Contacto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliConCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A163CliConCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliConCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A163CliConCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A163CliConCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliConCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliConCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliConDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliConDsc_Internalname, "Contacto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliConDsc_Internalname, StringUtil.RTrim( A578CliConDsc), StringUtil.RTrim( context.localUtil.Format( A578CliConDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliConDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliConDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliConCargo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliConCargo_Internalname, "Cargo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliConCargo_Internalname, StringUtil.RTrim( A577CliConCargo), StringUtil.RTrim( context.localUtil.Format( A577CliConCargo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliConCargo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliConCargo_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliConTelf_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliConTelf_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliConTelf_Internalname, StringUtil.RTrim( A586CliConTelf), StringUtil.RTrim( context.localUtil.Format( A586CliConTelf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliConTelf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliConTelf_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliConArea_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliConArea_Internalname, "Area", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliConArea_Internalname, StringUtil.RTrim( A576CliConArea), StringUtil.RTrim( context.localUtil.Format( A576CliConArea, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliConArea_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliConArea_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliConMail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliConMail_Internalname, "Mail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliConMail_Internalname, A579CliConMail, StringUtil.RTrim( context.localUtil.Format( A579CliConMail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliConMail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliConMail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCliConMailFE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliConMailFE_Internalname, "FE", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliConMailFE_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A580CliConMailFE), 1, 0, ".", "")), StringUtil.LTrim( ((edtCliConMailFE_Enabled!=0) ? context.localUtil.Format( (decimal)(A580CliConMailFE), "9") : context.localUtil.Format( (decimal)(A580CliConMailFE), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliConMailFE_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliConMailFE_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTESCONTACTOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESCONTACTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESCONTACTOS.htm");
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
            Z45CliCod = cgiGet( "Z45CliCod");
            Z163CliConCod = (int)(context.localUtil.CToN( cgiGet( "Z163CliConCod"), ".", ","));
            Z578CliConDsc = cgiGet( "Z578CliConDsc");
            Z577CliConCargo = cgiGet( "Z577CliConCargo");
            Z586CliConTelf = cgiGet( "Z586CliConTelf");
            Z576CliConArea = cgiGet( "Z576CliConArea");
            Z579CliConMail = cgiGet( "Z579CliConMail");
            Z580CliConMailFE = (short)(context.localUtil.CToN( cgiGet( "Z580CliConMailFE"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A45CliCod = cgiGet( edtCliCod_Internalname);
            AssignAttri("", false, "A45CliCod", A45CliCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCliConCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliConCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLICONCOD");
               AnyError = 1;
               GX_FocusControl = edtCliConCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A163CliConCod = 0;
               AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
            }
            else
            {
               A163CliConCod = (int)(context.localUtil.CToN( cgiGet( edtCliConCod_Internalname), ".", ","));
               AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
            }
            A578CliConDsc = cgiGet( edtCliConDsc_Internalname);
            AssignAttri("", false, "A578CliConDsc", A578CliConDsc);
            A577CliConCargo = cgiGet( edtCliConCargo_Internalname);
            AssignAttri("", false, "A577CliConCargo", A577CliConCargo);
            A586CliConTelf = cgiGet( edtCliConTelf_Internalname);
            AssignAttri("", false, "A586CliConTelf", A586CliConTelf);
            A576CliConArea = cgiGet( edtCliConArea_Internalname);
            AssignAttri("", false, "A576CliConArea", A576CliConArea);
            A579CliConMail = cgiGet( edtCliConMail_Internalname);
            AssignAttri("", false, "A579CliConMail", A579CliConMail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCliConMailFE_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliConMailFE_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLICONMAILFE");
               AnyError = 1;
               GX_FocusControl = edtCliConMailFE_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A580CliConMailFE = 0;
               AssignAttri("", false, "A580CliConMailFE", StringUtil.Str( (decimal)(A580CliConMailFE), 1, 0));
            }
            else
            {
               A580CliConMailFE = (short)(context.localUtil.CToN( cgiGet( edtCliConMailFE_Internalname), ".", ","));
               AssignAttri("", false, "A580CliConMailFE", StringUtil.Str( (decimal)(A580CliConMailFE), 1, 0));
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
               A45CliCod = GetPar( "CliCod");
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A163CliConCod = (int)(NumberUtil.Val( GetPar( "CliConCod"), "."));
               AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
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
               InitAll0C13( ) ;
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
         DisableAttributes0C13( ) ;
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

      protected void ResetCaption0C0( )
      {
      }

      protected void ZM0C13( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z578CliConDsc = T000C3_A578CliConDsc[0];
               Z577CliConCargo = T000C3_A577CliConCargo[0];
               Z586CliConTelf = T000C3_A586CliConTelf[0];
               Z576CliConArea = T000C3_A576CliConArea[0];
               Z579CliConMail = T000C3_A579CliConMail[0];
               Z580CliConMailFE = T000C3_A580CliConMailFE[0];
            }
            else
            {
               Z578CliConDsc = A578CliConDsc;
               Z577CliConCargo = A577CliConCargo;
               Z586CliConTelf = A586CliConTelf;
               Z576CliConArea = A576CliConArea;
               Z579CliConMail = A579CliConMail;
               Z580CliConMailFE = A580CliConMailFE;
            }
         }
         if ( GX_JID == -1 )
         {
            Z163CliConCod = A163CliConCod;
            Z578CliConDsc = A578CliConDsc;
            Z577CliConCargo = A577CliConCargo;
            Z586CliConTelf = A586CliConTelf;
            Z576CliConArea = A576CliConArea;
            Z579CliConMail = A579CliConMail;
            Z580CliConMailFE = A580CliConMailFE;
            Z45CliCod = A45CliCod;
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

      protected void Load0C13( )
      {
         /* Using cursor T000C5 */
         pr_default.execute(3, new Object[] {A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound13 = 1;
            A578CliConDsc = T000C5_A578CliConDsc[0];
            AssignAttri("", false, "A578CliConDsc", A578CliConDsc);
            A577CliConCargo = T000C5_A577CliConCargo[0];
            AssignAttri("", false, "A577CliConCargo", A577CliConCargo);
            A586CliConTelf = T000C5_A586CliConTelf[0];
            AssignAttri("", false, "A586CliConTelf", A586CliConTelf);
            A576CliConArea = T000C5_A576CliConArea[0];
            AssignAttri("", false, "A576CliConArea", A576CliConArea);
            A579CliConMail = T000C5_A579CliConMail[0];
            AssignAttri("", false, "A579CliConMail", A579CliConMail);
            A580CliConMailFE = T000C5_A580CliConMailFE[0];
            AssignAttri("", false, "A580CliConMailFE", StringUtil.Str( (decimal)(A580CliConMailFE), 1, 0));
            ZM0C13( -1) ;
         }
         pr_default.close(3);
         OnLoadActions0C13( ) ;
      }

      protected void OnLoadActions0C13( )
      {
      }

      protected void CheckExtendedTable0C13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000C4 */
         pr_default.execute(2, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0C13( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A45CliCod )
      {
         /* Using cursor T000C6 */
         pr_default.execute(4, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0C13( )
      {
         /* Using cursor T000C7 */
         pr_default.execute(5, new Object[] {A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C13( 1) ;
            RcdFound13 = 1;
            A163CliConCod = T000C3_A163CliConCod[0];
            AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
            A578CliConDsc = T000C3_A578CliConDsc[0];
            AssignAttri("", false, "A578CliConDsc", A578CliConDsc);
            A577CliConCargo = T000C3_A577CliConCargo[0];
            AssignAttri("", false, "A577CliConCargo", A577CliConCargo);
            A586CliConTelf = T000C3_A586CliConTelf[0];
            AssignAttri("", false, "A586CliConTelf", A586CliConTelf);
            A576CliConArea = T000C3_A576CliConArea[0];
            AssignAttri("", false, "A576CliConArea", A576CliConArea);
            A579CliConMail = T000C3_A579CliConMail[0];
            AssignAttri("", false, "A579CliConMail", A579CliConMail);
            A580CliConMailFE = T000C3_A580CliConMailFE[0];
            AssignAttri("", false, "A580CliConMailFE", StringUtil.Str( (decimal)(A580CliConMailFE), 1, 0));
            A45CliCod = T000C3_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            Z45CliCod = A45CliCod;
            Z163CliConCod = A163CliConCod;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0C13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0C13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0C13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C13( ) ;
         if ( RcdFound13 == 0 )
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
         RcdFound13 = 0;
         /* Using cursor T000C8 */
         pr_default.execute(6, new Object[] {A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000C8_A45CliCod[0], A45CliCod) < 0 ) || ( StringUtil.StrCmp(T000C8_A45CliCod[0], A45CliCod) == 0 ) && ( T000C8_A163CliConCod[0] < A163CliConCod ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T000C8_A45CliCod[0], A45CliCod) > 0 ) || ( StringUtil.StrCmp(T000C8_A45CliCod[0], A45CliCod) == 0 ) && ( T000C8_A163CliConCod[0] > A163CliConCod ) ) )
            {
               A45CliCod = T000C8_A45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A163CliConCod = T000C8_A163CliConCod[0];
               AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000C9 */
         pr_default.execute(7, new Object[] {A45CliCod, A163CliConCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000C9_A45CliCod[0], A45CliCod) > 0 ) || ( StringUtil.StrCmp(T000C9_A45CliCod[0], A45CliCod) == 0 ) && ( T000C9_A163CliConCod[0] > A163CliConCod ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T000C9_A45CliCod[0], A45CliCod) < 0 ) || ( StringUtil.StrCmp(T000C9_A45CliCod[0], A45CliCod) == 0 ) && ( T000C9_A163CliConCod[0] < A163CliConCod ) ) )
            {
               A45CliCod = T000C9_A45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A163CliConCod = T000C9_A163CliConCod[0];
               AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A163CliConCod != Z163CliConCod ) )
               {
                  A45CliCod = Z45CliCod;
                  AssignAttri("", false, "A45CliCod", A45CliCod);
                  A163CliConCod = Z163CliConCod;
                  AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
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
                  Update0C13( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A163CliConCod != Z163CliConCod ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C13( ) ;
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
                     Insert0C13( ) ;
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
         if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A163CliConCod != Z163CliConCod ) )
         {
            A45CliCod = Z45CliCod;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A163CliConCod = Z163CliConCod;
            AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCliConDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliConDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0C13( ) ;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliConDsc_Internalname;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliConDsc_Internalname;
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
         ScanStart0C13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0C13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliConDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0C13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0C13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A45CliCod, A163CliConCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESCONTACTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z578CliConDsc, T000C2_A578CliConDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z577CliConCargo, T000C2_A577CliConCargo[0]) != 0 ) || ( StringUtil.StrCmp(Z586CliConTelf, T000C2_A586CliConTelf[0]) != 0 ) || ( StringUtil.StrCmp(Z576CliConArea, T000C2_A576CliConArea[0]) != 0 ) || ( StringUtil.StrCmp(Z579CliConMail, T000C2_A579CliConMail[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z580CliConMailFE != T000C2_A580CliConMailFE[0] ) )
            {
               if ( StringUtil.StrCmp(Z578CliConDsc, T000C2_A578CliConDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientescontactos:[seudo value changed for attri]"+"CliConDsc");
                  GXUtil.WriteLogRaw("Old: ",Z578CliConDsc);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A578CliConDsc[0]);
               }
               if ( StringUtil.StrCmp(Z577CliConCargo, T000C2_A577CliConCargo[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientescontactos:[seudo value changed for attri]"+"CliConCargo");
                  GXUtil.WriteLogRaw("Old: ",Z577CliConCargo);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A577CliConCargo[0]);
               }
               if ( StringUtil.StrCmp(Z586CliConTelf, T000C2_A586CliConTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientescontactos:[seudo value changed for attri]"+"CliConTelf");
                  GXUtil.WriteLogRaw("Old: ",Z586CliConTelf);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A586CliConTelf[0]);
               }
               if ( StringUtil.StrCmp(Z576CliConArea, T000C2_A576CliConArea[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientescontactos:[seudo value changed for attri]"+"CliConArea");
                  GXUtil.WriteLogRaw("Old: ",Z576CliConArea);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A576CliConArea[0]);
               }
               if ( StringUtil.StrCmp(Z579CliConMail, T000C2_A579CliConMail[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientescontactos:[seudo value changed for attri]"+"CliConMail");
                  GXUtil.WriteLogRaw("Old: ",Z579CliConMail);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A579CliConMail[0]);
               }
               if ( Z580CliConMailFE != T000C2_A580CliConMailFE[0] )
               {
                  GXUtil.WriteLog("clclientescontactos:[seudo value changed for attri]"+"CliConMailFE");
                  GXUtil.WriteLogRaw("Old: ",Z580CliConMailFE);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A580CliConMailFE[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTESCONTACTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C13( 0) ;
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C10 */
                     pr_default.execute(8, new Object[] {A163CliConCod, A578CliConDsc, A577CliConCargo, A586CliConTelf, A576CliConArea, A579CliConMail, A580CliConMailFE, A45CliCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESCONTACTOS");
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
                           ResetCaption0C0( ) ;
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
               Load0C13( ) ;
            }
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void Update0C13( )
      {
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C11 */
                     pr_default.execute(9, new Object[] {A578CliConDsc, A577CliConCargo, A586CliConTelf, A576CliConArea, A579CliConMail, A580CliConMailFE, A45CliCod, A163CliConCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESCONTACTOS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESCONTACTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0C0( ) ;
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
            EndLevel0C13( ) ;
         }
         CloseExtendedTableCursors0C13( ) ;
      }

      protected void DeferredUpdate0C13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0C13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C13( ) ;
            AfterConfirm0C13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C12 */
                  pr_default.execute(10, new Object[] {A45CliCod, A163CliConCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESCONTACTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound13 == 0 )
                        {
                           InitAll0C13( ) ;
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
                        ResetCaption0C0( ) ;
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C13( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0C13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C13( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clclientescontactos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clclientescontactos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C13( )
      {
         /* Using cursor T000C13 */
         pr_default.execute(11);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound13 = 1;
            A45CliCod = T000C13_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A163CliConCod = T000C13_A163CliConCod[0];
            AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C13( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound13 = 1;
            A45CliCod = T000C13_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A163CliConCod = T000C13_A163CliConCod[0];
            AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
         }
      }

      protected void ScanEnd0C13( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0C13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C13( )
      {
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtCliConCod_Enabled = 0;
         AssignProp("", false, edtCliConCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCod_Enabled), 5, 0), true);
         edtCliConDsc_Enabled = 0;
         AssignProp("", false, edtCliConDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConDsc_Enabled), 5, 0), true);
         edtCliConCargo_Enabled = 0;
         AssignProp("", false, edtCliConCargo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConCargo_Enabled), 5, 0), true);
         edtCliConTelf_Enabled = 0;
         AssignProp("", false, edtCliConTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConTelf_Enabled), 5, 0), true);
         edtCliConArea_Enabled = 0;
         AssignProp("", false, edtCliConArea_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConArea_Enabled), 5, 0), true);
         edtCliConMail_Enabled = 0;
         AssignProp("", false, edtCliConMail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConMail_Enabled), 5, 0), true);
         edtCliConMailFE_Enabled = 0;
         AssignProp("", false, edtCliConMailFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliConMailFE_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811441246", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clclientescontactos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z163CliConCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z163CliConCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z578CliConDsc", StringUtil.RTrim( Z578CliConDsc));
         GxWebStd.gx_hidden_field( context, "Z577CliConCargo", StringUtil.RTrim( Z577CliConCargo));
         GxWebStd.gx_hidden_field( context, "Z586CliConTelf", StringUtil.RTrim( Z586CliConTelf));
         GxWebStd.gx_hidden_field( context, "Z576CliConArea", StringUtil.RTrim( Z576CliConArea));
         GxWebStd.gx_hidden_field( context, "Z579CliConMail", Z579CliConMail);
         GxWebStd.gx_hidden_field( context, "Z580CliConMailFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z580CliConMailFE), 1, 0, ".", "")));
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
         return formatLink("clclientescontactos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCLIENTESCONTACTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Clientes Contacto" ;
      }

      protected void InitializeNonKey0C13( )
      {
         A578CliConDsc = "";
         AssignAttri("", false, "A578CliConDsc", A578CliConDsc);
         A577CliConCargo = "";
         AssignAttri("", false, "A577CliConCargo", A577CliConCargo);
         A586CliConTelf = "";
         AssignAttri("", false, "A586CliConTelf", A586CliConTelf);
         A576CliConArea = "";
         AssignAttri("", false, "A576CliConArea", A576CliConArea);
         A579CliConMail = "";
         AssignAttri("", false, "A579CliConMail", A579CliConMail);
         A580CliConMailFE = 0;
         AssignAttri("", false, "A580CliConMailFE", StringUtil.Str( (decimal)(A580CliConMailFE), 1, 0));
         Z578CliConDsc = "";
         Z577CliConCargo = "";
         Z586CliConTelf = "";
         Z576CliConArea = "";
         Z579CliConMail = "";
         Z580CliConMailFE = 0;
      }

      protected void InitAll0C13( )
      {
         A45CliCod = "";
         AssignAttri("", false, "A45CliCod", A45CliCod);
         A163CliConCod = 0;
         AssignAttri("", false, "A163CliConCod", StringUtil.LTrimStr( (decimal)(A163CliConCod), 6, 0));
         InitializeNonKey0C13( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811441254", true, true);
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
         context.AddJavascriptSource("clclientescontactos.js", "?202281811441254", false, true);
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
         edtCliCod_Internalname = "CLICOD";
         edtCliConCod_Internalname = "CLICONCOD";
         edtCliConDsc_Internalname = "CLICONDSC";
         edtCliConCargo_Internalname = "CLICONCARGO";
         edtCliConTelf_Internalname = "CLICONTELF";
         edtCliConArea_Internalname = "CLICONAREA";
         edtCliConMail_Internalname = "CLICONMAIL";
         edtCliConMailFE_Internalname = "CLICONMAILFE";
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
         Form.Caption = "Clientes Contacto";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCliConMailFE_Jsonclick = "";
         edtCliConMailFE_Enabled = 1;
         edtCliConMail_Jsonclick = "";
         edtCliConMail_Enabled = 1;
         edtCliConArea_Jsonclick = "";
         edtCliConArea_Enabled = 1;
         edtCliConTelf_Jsonclick = "";
         edtCliConTelf_Enabled = 1;
         edtCliConCargo_Jsonclick = "";
         edtCliConCargo_Enabled = 1;
         edtCliConDsc_Jsonclick = "";
         edtCliConDsc_Enabled = 1;
         edtCliConCod_Jsonclick = "";
         edtCliConCod_Enabled = 1;
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

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000C14 */
         pr_default.execute(12, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtCliConDsc_Internalname;
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
         /* Using cursor T000C14 */
         pr_default.execute(12, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cliconcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A578CliConDsc", StringUtil.RTrim( A578CliConDsc));
         AssignAttri("", false, "A577CliConCargo", StringUtil.RTrim( A577CliConCargo));
         AssignAttri("", false, "A586CliConTelf", StringUtil.RTrim( A586CliConTelf));
         AssignAttri("", false, "A576CliConArea", StringUtil.RTrim( A576CliConArea));
         AssignAttri("", false, "A579CliConMail", A579CliConMail);
         AssignAttri("", false, "A580CliConMailFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A580CliConMailFE), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z163CliConCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z163CliConCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z578CliConDsc", StringUtil.RTrim( Z578CliConDsc));
         GxWebStd.gx_hidden_field( context, "Z577CliConCargo", StringUtil.RTrim( Z577CliConCargo));
         GxWebStd.gx_hidden_field( context, "Z586CliConTelf", StringUtil.RTrim( Z586CliConTelf));
         GxWebStd.gx_hidden_field( context, "Z576CliConArea", StringUtil.RTrim( Z576CliConArea));
         GxWebStd.gx_hidden_field( context, "Z579CliConMail", Z579CliConMail);
         GxWebStd.gx_hidden_field( context, "Z580CliConMailFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z580CliConMailFE), 1, 0, ".", "")));
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
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''}]");
         setEventMetadata("VALID_CLICOD",",oparms:[]}");
         setEventMetadata("VALID_CLICONCOD","{handler:'Valid_Cliconcod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A163CliConCod',fld:'CLICONCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLICONCOD",",oparms:[{av:'A578CliConDsc',fld:'CLICONDSC',pic:''},{av:'A577CliConCargo',fld:'CLICONCARGO',pic:''},{av:'A586CliConTelf',fld:'CLICONTELF',pic:''},{av:'A576CliConArea',fld:'CLICONAREA',pic:''},{av:'A579CliConMail',fld:'CLICONMAIL',pic:''},{av:'A580CliConMailFE',fld:'CLICONMAILFE',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z45CliCod'},{av:'Z163CliConCod'},{av:'Z578CliConDsc'},{av:'Z577CliConCargo'},{av:'Z586CliConTelf'},{av:'Z576CliConArea'},{av:'Z579CliConMail'},{av:'Z580CliConMailFE'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z45CliCod = "";
         Z578CliConDsc = "";
         Z577CliConCargo = "";
         Z586CliConTelf = "";
         Z576CliConArea = "";
         Z579CliConMail = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A45CliCod = "";
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
         A578CliConDsc = "";
         A577CliConCargo = "";
         A586CliConTelf = "";
         A576CliConArea = "";
         A579CliConMail = "";
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
         T000C5_A163CliConCod = new int[1] ;
         T000C5_A578CliConDsc = new string[] {""} ;
         T000C5_A577CliConCargo = new string[] {""} ;
         T000C5_A586CliConTelf = new string[] {""} ;
         T000C5_A576CliConArea = new string[] {""} ;
         T000C5_A579CliConMail = new string[] {""} ;
         T000C5_A580CliConMailFE = new short[1] ;
         T000C5_A45CliCod = new string[] {""} ;
         T000C4_A45CliCod = new string[] {""} ;
         T000C6_A45CliCod = new string[] {""} ;
         T000C7_A45CliCod = new string[] {""} ;
         T000C7_A163CliConCod = new int[1] ;
         T000C3_A163CliConCod = new int[1] ;
         T000C3_A578CliConDsc = new string[] {""} ;
         T000C3_A577CliConCargo = new string[] {""} ;
         T000C3_A586CliConTelf = new string[] {""} ;
         T000C3_A576CliConArea = new string[] {""} ;
         T000C3_A579CliConMail = new string[] {""} ;
         T000C3_A580CliConMailFE = new short[1] ;
         T000C3_A45CliCod = new string[] {""} ;
         sMode13 = "";
         T000C8_A45CliCod = new string[] {""} ;
         T000C8_A163CliConCod = new int[1] ;
         T000C9_A45CliCod = new string[] {""} ;
         T000C9_A163CliConCod = new int[1] ;
         T000C2_A163CliConCod = new int[1] ;
         T000C2_A578CliConDsc = new string[] {""} ;
         T000C2_A577CliConCargo = new string[] {""} ;
         T000C2_A586CliConTelf = new string[] {""} ;
         T000C2_A576CliConArea = new string[] {""} ;
         T000C2_A579CliConMail = new string[] {""} ;
         T000C2_A580CliConMailFE = new short[1] ;
         T000C2_A45CliCod = new string[] {""} ;
         T000C13_A45CliCod = new string[] {""} ;
         T000C13_A163CliConCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000C14_A45CliCod = new string[] {""} ;
         ZZ45CliCod = "";
         ZZ578CliConDsc = "";
         ZZ577CliConCargo = "";
         ZZ586CliConTelf = "";
         ZZ576CliConArea = "";
         ZZ579CliConMail = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clclientescontactos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clclientescontactos__default(),
            new Object[][] {
                new Object[] {
               T000C2_A163CliConCod, T000C2_A578CliConDsc, T000C2_A577CliConCargo, T000C2_A586CliConTelf, T000C2_A576CliConArea, T000C2_A579CliConMail, T000C2_A580CliConMailFE, T000C2_A45CliCod
               }
               , new Object[] {
               T000C3_A163CliConCod, T000C3_A578CliConDsc, T000C3_A577CliConCargo, T000C3_A586CliConTelf, T000C3_A576CliConArea, T000C3_A579CliConMail, T000C3_A580CliConMailFE, T000C3_A45CliCod
               }
               , new Object[] {
               T000C4_A45CliCod
               }
               , new Object[] {
               T000C5_A163CliConCod, T000C5_A578CliConDsc, T000C5_A577CliConCargo, T000C5_A586CliConTelf, T000C5_A576CliConArea, T000C5_A579CliConMail, T000C5_A580CliConMailFE, T000C5_A45CliCod
               }
               , new Object[] {
               T000C6_A45CliCod
               }
               , new Object[] {
               T000C7_A45CliCod, T000C7_A163CliConCod
               }
               , new Object[] {
               T000C8_A45CliCod, T000C8_A163CliConCod
               }
               , new Object[] {
               T000C9_A45CliCod, T000C9_A163CliConCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C13_A45CliCod, T000C13_A163CliConCod
               }
               , new Object[] {
               T000C14_A45CliCod
               }
            }
         );
      }

      private short Z580CliConMailFE ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A580CliConMailFE ;
      private short GX_JID ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ580CliConMailFE ;
      private int Z163CliConCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCliCod_Enabled ;
      private int A163CliConCod ;
      private int edtCliConCod_Enabled ;
      private int edtCliConDsc_Enabled ;
      private int edtCliConCargo_Enabled ;
      private int edtCliConTelf_Enabled ;
      private int edtCliConArea_Enabled ;
      private int edtCliConMail_Enabled ;
      private int edtCliConMailFE_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ163CliConCod ;
      private string sPrefix ;
      private string Z45CliCod ;
      private string Z578CliConDsc ;
      private string Z577CliConCargo ;
      private string Z586CliConTelf ;
      private string Z576CliConArea ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A45CliCod ;
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
      private string edtCliCod_Jsonclick ;
      private string edtCliConCod_Internalname ;
      private string edtCliConCod_Jsonclick ;
      private string edtCliConDsc_Internalname ;
      private string A578CliConDsc ;
      private string edtCliConDsc_Jsonclick ;
      private string edtCliConCargo_Internalname ;
      private string A577CliConCargo ;
      private string edtCliConCargo_Jsonclick ;
      private string edtCliConTelf_Internalname ;
      private string A586CliConTelf ;
      private string edtCliConTelf_Jsonclick ;
      private string edtCliConArea_Internalname ;
      private string A576CliConArea ;
      private string edtCliConArea_Jsonclick ;
      private string edtCliConMail_Internalname ;
      private string edtCliConMail_Jsonclick ;
      private string edtCliConMailFE_Internalname ;
      private string edtCliConMailFE_Jsonclick ;
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
      private string sMode13 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ45CliCod ;
      private string ZZ578CliConDsc ;
      private string ZZ577CliConCargo ;
      private string ZZ586CliConTelf ;
      private string ZZ576CliConArea ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z579CliConMail ;
      private string A579CliConMail ;
      private string ZZ579CliConMail ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000C5_A163CliConCod ;
      private string[] T000C5_A578CliConDsc ;
      private string[] T000C5_A577CliConCargo ;
      private string[] T000C5_A586CliConTelf ;
      private string[] T000C5_A576CliConArea ;
      private string[] T000C5_A579CliConMail ;
      private short[] T000C5_A580CliConMailFE ;
      private string[] T000C5_A45CliCod ;
      private string[] T000C4_A45CliCod ;
      private string[] T000C6_A45CliCod ;
      private string[] T000C7_A45CliCod ;
      private int[] T000C7_A163CliConCod ;
      private int[] T000C3_A163CliConCod ;
      private string[] T000C3_A578CliConDsc ;
      private string[] T000C3_A577CliConCargo ;
      private string[] T000C3_A586CliConTelf ;
      private string[] T000C3_A576CliConArea ;
      private string[] T000C3_A579CliConMail ;
      private short[] T000C3_A580CliConMailFE ;
      private string[] T000C3_A45CliCod ;
      private string[] T000C8_A45CliCod ;
      private int[] T000C8_A163CliConCod ;
      private string[] T000C9_A45CliCod ;
      private int[] T000C9_A163CliConCod ;
      private int[] T000C2_A163CliConCod ;
      private string[] T000C2_A578CliConDsc ;
      private string[] T000C2_A577CliConCargo ;
      private string[] T000C2_A586CliConTelf ;
      private string[] T000C2_A576CliConArea ;
      private string[] T000C2_A579CliConMail ;
      private short[] T000C2_A580CliConMailFE ;
      private string[] T000C2_A45CliCod ;
      private string[] T000C13_A45CliCod ;
      private int[] T000C13_A163CliConCod ;
      private string[] T000C14_A45CliCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clclientescontactos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clclientescontactos__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000C5;
        prmT000C5 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C4;
        prmT000C4 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT000C6;
        prmT000C6 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT000C7;
        prmT000C7 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C3;
        prmT000C3 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C8;
        prmT000C8 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C9;
        prmT000C9 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C2;
        prmT000C2 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C10;
        prmT000C10 = new Object[] {
        new ParDef("@CliConCod",GXType.Int32,6,0) ,
        new ParDef("@CliConDsc",GXType.NChar,100,0) ,
        new ParDef("@CliConCargo",GXType.NChar,100,0) ,
        new ParDef("@CliConTelf",GXType.NChar,40,0) ,
        new ParDef("@CliConArea",GXType.NChar,100,0) ,
        new ParDef("@CliConMail",GXType.NVarChar,100,0) ,
        new ParDef("@CliConMailFE",GXType.Int16,1,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT000C11;
        prmT000C11 = new Object[] {
        new ParDef("@CliConDsc",GXType.NChar,100,0) ,
        new ParDef("@CliConCargo",GXType.NChar,100,0) ,
        new ParDef("@CliConTelf",GXType.NChar,40,0) ,
        new ParDef("@CliConArea",GXType.NChar,100,0) ,
        new ParDef("@CliConMail",GXType.NVarChar,100,0) ,
        new ParDef("@CliConMailFE",GXType.Int16,1,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C12;
        prmT000C12 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliConCod",GXType.Int32,6,0)
        };
        Object[] prmT000C13;
        prmT000C13 = new Object[] {
        };
        Object[] prmT000C14;
        prmT000C14 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000C2", "SELECT [CliConCod], [CliConDsc], [CliConCargo], [CliConTelf], [CliConArea], [CliConMail], [CliConMailFE], [CliCod] FROM [CLCLIENTESCONTACTOS] WITH (UPDLOCK) WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C3", "SELECT [CliConCod], [CliConDsc], [CliConCargo], [CliConTelf], [CliConArea], [CliConMail], [CliConMailFE], [CliCod] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C4", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C5", "SELECT TM1.[CliConCod], TM1.[CliConDsc], TM1.[CliConCargo], TM1.[CliConTelf], TM1.[CliConArea], TM1.[CliConMail], TM1.[CliConMailFE], TM1.[CliCod] FROM [CLCLIENTESCONTACTOS] TM1 WHERE TM1.[CliCod] = @CliCod and TM1.[CliConCod] = @CliConCod ORDER BY TM1.[CliCod], TM1.[CliConCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C6", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C7", "SELECT [CliCod], [CliConCod] FROM [CLCLIENTESCONTACTOS] WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C8", "SELECT TOP 1 [CliCod], [CliConCod] FROM [CLCLIENTESCONTACTOS] WHERE ( [CliCod] > @CliCod or [CliCod] = @CliCod and [CliConCod] > @CliConCod) ORDER BY [CliCod], [CliConCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C9", "SELECT TOP 1 [CliCod], [CliConCod] FROM [CLCLIENTESCONTACTOS] WHERE ( [CliCod] < @CliCod or [CliCod] = @CliCod and [CliConCod] < @CliConCod) ORDER BY [CliCod] DESC, [CliConCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000C10", "INSERT INTO [CLCLIENTESCONTACTOS]([CliConCod], [CliConDsc], [CliConCargo], [CliConTelf], [CliConArea], [CliConMail], [CliConMailFE], [CliCod]) VALUES(@CliConCod, @CliConDsc, @CliConCargo, @CliConTelf, @CliConArea, @CliConMail, @CliConMailFE, @CliCod)", GxErrorMask.GX_NOMASK,prmT000C10)
           ,new CursorDef("T000C11", "UPDATE [CLCLIENTESCONTACTOS] SET [CliConDsc]=@CliConDsc, [CliConCargo]=@CliConCargo, [CliConTelf]=@CliConTelf, [CliConArea]=@CliConArea, [CliConMail]=@CliConMail, [CliConMailFE]=@CliConMailFE  WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod", GxErrorMask.GX_NOMASK,prmT000C11)
           ,new CursorDef("T000C12", "DELETE FROM [CLCLIENTESCONTACTOS]  WHERE [CliCod] = @CliCod AND [CliConCod] = @CliConCod", GxErrorMask.GX_NOMASK,prmT000C12)
           ,new CursorDef("T000C13", "SELECT [CliCod], [CliConCod] FROM [CLCLIENTESCONTACTOS] ORDER BY [CliCod], [CliConCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000C14", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
  }

}

}
