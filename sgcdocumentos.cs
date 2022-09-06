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
   public class sgcdocumentos : GXDataArea
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
            Form.Meta.addItem("description", "SGCDOCUMENTOS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgcdocumentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgcdocumentos( IGxContext context )
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
         chkCorFE = new GXCheckbox();
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
         A756CorFE = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGCDOCUMENTOS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGCDOCUMENTOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGCDOCUMENTOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorDoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorDoc_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorDoc_Internalname, StringUtil.RTrim( A339CorDoc), StringUtil.RTrim( context.localUtil.Format( A339CorDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorDoc_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorSerie_Internalname, "Serie", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorSerie_Internalname, StringUtil.RTrim( A340CorSerie), StringUtil.RTrim( context.localUtil.Format( A340CorSerie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorSerie_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorSerie_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNumDoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNumDoc_Internalname, "Numero", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNumDoc_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1377NumDoc), 10, 0, ".", "")), StringUtil.LTrim( ((edtNumDoc_Enabled!=0) ? context.localUtil.Format( (decimal)(A1377NumDoc), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1377NumDoc), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNumDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNumDoc_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkCorFE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkCorFE_Internalname, "Electronica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkCorFE_Internalname, StringUtil.Str( (decimal)(A756CorFE), 1, 0), "", "Electronica", 1, chkCorFE.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(43, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorFormato_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorFormato_Internalname, "Formato", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorFormato_Internalname, A757CorFormato, StringUtil.RTrim( context.localUtil.Format( A757CorFormato, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorFormato_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorFormato_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGCDOCUMENTOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGCDOCUMENTOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGCDOCUMENTOS.htm");
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
            Z339CorDoc = cgiGet( "Z339CorDoc");
            Z340CorSerie = cgiGet( "Z340CorSerie");
            Z1377NumDoc = (long)(context.localUtil.CToN( cgiGet( "Z1377NumDoc"), ".", ","));
            Z756CorFE = (short)(context.localUtil.CToN( cgiGet( "Z756CorFE"), ".", ","));
            Z757CorFormato = cgiGet( "Z757CorFormato");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A339CorDoc = cgiGet( edtCorDoc_Internalname);
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = cgiGet( edtCorSerie_Internalname);
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
            if ( ( ( context.localUtil.CToN( cgiGet( edtNumDoc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNumDoc_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NUMDOC");
               AnyError = 1;
               GX_FocusControl = edtNumDoc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1377NumDoc = 0;
               AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
            }
            else
            {
               A1377NumDoc = (long)(context.localUtil.CToN( cgiGet( edtNumDoc_Internalname), ".", ","));
               AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkCorFE_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkCorFE_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CORFE");
               AnyError = 1;
               GX_FocusControl = chkCorFE_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A756CorFE = 0;
               AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
            }
            else
            {
               A756CorFE = (short)(((StringUtil.StrCmp(cgiGet( chkCorFE_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
            }
            A757CorFormato = cgiGet( edtCorFormato_Internalname);
            AssignAttri("", false, "A757CorFormato", A757CorFormato);
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
               A339CorDoc = GetPar( "CorDoc");
               AssignAttri("", false, "A339CorDoc", A339CorDoc);
               A340CorSerie = GetPar( "CorSerie");
               AssignAttri("", false, "A340CorSerie", A340CorSerie);
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
               InitAll0L20( ) ;
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
         DisableAttributes0L20( ) ;
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

      protected void ResetCaption0L0( )
      {
      }

      protected void ZM0L20( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1377NumDoc = T000L3_A1377NumDoc[0];
               Z756CorFE = T000L3_A756CorFE[0];
               Z757CorFormato = T000L3_A757CorFormato[0];
            }
            else
            {
               Z1377NumDoc = A1377NumDoc;
               Z756CorFE = A756CorFE;
               Z757CorFormato = A757CorFormato;
            }
         }
         if ( GX_JID == -1 )
         {
            Z339CorDoc = A339CorDoc;
            Z340CorSerie = A340CorSerie;
            Z1377NumDoc = A1377NumDoc;
            Z756CorFE = A756CorFE;
            Z757CorFormato = A757CorFormato;
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

      protected void Load0L20( )
      {
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A1377NumDoc = T000L4_A1377NumDoc[0];
            AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
            A756CorFE = T000L4_A756CorFE[0];
            AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
            A757CorFormato = T000L4_A757CorFormato[0];
            AssignAttri("", false, "A757CorFormato", A757CorFormato);
            ZM0L20( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0L20( ) ;
      }

      protected void OnLoadActions0L20( )
      {
      }

      protected void CheckExtendedTable0L20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0L20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L20( )
      {
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L20( 1) ;
            RcdFound20 = 1;
            A339CorDoc = T000L3_A339CorDoc[0];
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = T000L3_A340CorSerie[0];
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
            A1377NumDoc = T000L3_A1377NumDoc[0];
            AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
            A756CorFE = T000L3_A756CorFE[0];
            AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
            A757CorFormato = T000L3_A757CorFormato[0];
            AssignAttri("", false, "A757CorFormato", A757CorFormato);
            Z339CorDoc = A339CorDoc;
            Z340CorSerie = A340CorSerie;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0L20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0L20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0L20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L20( ) ;
         if ( RcdFound20 == 0 )
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
         RcdFound20 = 0;
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000L6_A339CorDoc[0], A339CorDoc) < 0 ) || ( StringUtil.StrCmp(T000L6_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000L6_A340CorSerie[0], A340CorSerie) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000L6_A339CorDoc[0], A339CorDoc) > 0 ) || ( StringUtil.StrCmp(T000L6_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000L6_A340CorSerie[0], A340CorSerie) > 0 ) ) )
            {
               A339CorDoc = T000L6_A339CorDoc[0];
               AssignAttri("", false, "A339CorDoc", A339CorDoc);
               A340CorSerie = T000L6_A340CorSerie[0];
               AssignAttri("", false, "A340CorSerie", A340CorSerie);
               RcdFound20 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000L7_A339CorDoc[0], A339CorDoc) > 0 ) || ( StringUtil.StrCmp(T000L7_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000L7_A340CorSerie[0], A340CorSerie) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000L7_A339CorDoc[0], A339CorDoc) < 0 ) || ( StringUtil.StrCmp(T000L7_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000L7_A340CorSerie[0], A340CorSerie) < 0 ) ) )
            {
               A339CorDoc = T000L7_A339CorDoc[0];
               AssignAttri("", false, "A339CorDoc", A339CorDoc);
               A340CorSerie = T000L7_A340CorSerie[0];
               AssignAttri("", false, "A340CorSerie", A340CorSerie);
               RcdFound20 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( ( StringUtil.StrCmp(A339CorDoc, Z339CorDoc) != 0 ) || ( StringUtil.StrCmp(A340CorSerie, Z340CorSerie) != 0 ) )
               {
                  A339CorDoc = Z339CorDoc;
                  AssignAttri("", false, "A339CorDoc", A339CorDoc);
                  A340CorSerie = Z340CorSerie;
                  AssignAttri("", false, "A340CorSerie", A340CorSerie);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CORDOC");
                  AnyError = 1;
                  GX_FocusControl = edtCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0L20( ) ;
                  GX_FocusControl = edtCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A339CorDoc, Z339CorDoc) != 0 ) || ( StringUtil.StrCmp(A340CorSerie, Z340CorSerie) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CORDOC");
                     AnyError = 1;
                     GX_FocusControl = edtCorDoc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCorDoc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L20( ) ;
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
         if ( ( StringUtil.StrCmp(A339CorDoc, Z339CorDoc) != 0 ) || ( StringUtil.StrCmp(A340CorSerie, Z340CorSerie) != 0 ) )
         {
            A339CorDoc = Z339CorDoc;
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = Z340CorSerie;
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CORDOC");
            AnyError = 1;
            GX_FocusControl = edtCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCorDoc_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CORDOC");
            AnyError = 1;
            GX_FocusControl = edtCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtNumDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0L20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNumDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0L20( ) ;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNumDoc_Internalname;
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
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNumDoc_Internalname;
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
         ScanStart0L20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound20 != 0 )
            {
               ScanNext0L20( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtNumDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0L20( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0L20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A339CorDoc, A340CorSerie});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGCDOCUMENTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1377NumDoc != T000L2_A1377NumDoc[0] ) || ( Z756CorFE != T000L2_A756CorFE[0] ) || ( StringUtil.StrCmp(Z757CorFormato, T000L2_A757CorFormato[0]) != 0 ) )
            {
               if ( Z1377NumDoc != T000L2_A1377NumDoc[0] )
               {
                  GXUtil.WriteLog("sgcdocumentos:[seudo value changed for attri]"+"NumDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1377NumDoc);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A1377NumDoc[0]);
               }
               if ( Z756CorFE != T000L2_A756CorFE[0] )
               {
                  GXUtil.WriteLog("sgcdocumentos:[seudo value changed for attri]"+"CorFE");
                  GXUtil.WriteLogRaw("Old: ",Z756CorFE);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A756CorFE[0]);
               }
               if ( StringUtil.StrCmp(Z757CorFormato, T000L2_A757CorFormato[0]) != 0 )
               {
                  GXUtil.WriteLog("sgcdocumentos:[seudo value changed for attri]"+"CorFormato");
                  GXUtil.WriteLogRaw("Old: ",Z757CorFormato);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A757CorFormato[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGCDOCUMENTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L20( )
      {
         BeforeValidate0L20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L20( 0) ;
            CheckOptimisticConcurrency0L20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L8 */
                     pr_default.execute(6, new Object[] {A339CorDoc, A340CorSerie, A1377NumDoc, A756CorFE, A757CorFormato});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGCDOCUMENTOS");
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
                           ResetCaption0L0( ) ;
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
               Load0L20( ) ;
            }
            EndLevel0L20( ) ;
         }
         CloseExtendedTableCursors0L20( ) ;
      }

      protected void Update0L20( )
      {
         BeforeValidate0L20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L9 */
                     pr_default.execute(7, new Object[] {A1377NumDoc, A756CorFE, A757CorFormato, A339CorDoc, A340CorSerie});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGCDOCUMENTOS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGCDOCUMENTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L20( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0L0( ) ;
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
            EndLevel0L20( ) ;
         }
         CloseExtendedTableCursors0L20( ) ;
      }

      protected void DeferredUpdate0L20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0L20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L20( ) ;
            AfterConfirm0L20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L10 */
                  pr_default.execute(8, new Object[] {A339CorDoc, A340CorSerie});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGCDOCUMENTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound20 == 0 )
                        {
                           InitAll0L20( ) ;
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
                        ResetCaption0L0( ) ;
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0L20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgcdocumentos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgcdocumentos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L20( )
      {
         /* Using cursor T000L11 */
         pr_default.execute(9);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound20 = 1;
            A339CorDoc = T000L11_A339CorDoc[0];
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = T000L11_A340CorSerie[0];
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L20( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound20 = 1;
            A339CorDoc = T000L11_A339CorDoc[0];
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = T000L11_A340CorSerie[0];
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
         }
      }

      protected void ScanEnd0L20( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0L20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0L20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0L20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0L20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L20( )
      {
         edtCorDoc_Enabled = 0;
         AssignProp("", false, edtCorDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorDoc_Enabled), 5, 0), true);
         edtCorSerie_Enabled = 0;
         AssignProp("", false, edtCorSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorSerie_Enabled), 5, 0), true);
         edtNumDoc_Enabled = 0;
         AssignProp("", false, edtNumDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNumDoc_Enabled), 5, 0), true);
         chkCorFE.Enabled = 0;
         AssignProp("", false, chkCorFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkCorFE.Enabled), 5, 0), true);
         edtCorFormato_Enabled = 0;
         AssignProp("", false, edtCorFormato_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorFormato_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442197", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgcdocumentos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z339CorDoc", StringUtil.RTrim( Z339CorDoc));
         GxWebStd.gx_hidden_field( context, "Z340CorSerie", StringUtil.RTrim( Z340CorSerie));
         GxWebStd.gx_hidden_field( context, "Z1377NumDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1377NumDoc), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z756CorFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z756CorFE), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z757CorFormato", Z757CorFormato);
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
         return formatLink("sgcdocumentos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGCDOCUMENTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGCDOCUMENTOS" ;
      }

      protected void InitializeNonKey0L20( )
      {
         A1377NumDoc = 0;
         AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
         A756CorFE = 0;
         AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
         A757CorFormato = "";
         AssignAttri("", false, "A757CorFormato", A757CorFormato);
         Z1377NumDoc = 0;
         Z756CorFE = 0;
         Z757CorFormato = "";
      }

      protected void InitAll0L20( )
      {
         A339CorDoc = "";
         AssignAttri("", false, "A339CorDoc", A339CorDoc);
         A340CorSerie = "";
         AssignAttri("", false, "A340CorSerie", A340CorSerie);
         InitializeNonKey0L20( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181144223", true, true);
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
         context.AddJavascriptSource("sgcdocumentos.js", "?20228181144223", false, true);
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
         edtCorDoc_Internalname = "CORDOC";
         edtCorSerie_Internalname = "CORSERIE";
         edtNumDoc_Internalname = "NUMDOC";
         chkCorFE_Internalname = "CORFE";
         edtCorFormato_Internalname = "CORFORMATO";
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
         Form.Caption = "SGCDOCUMENTOS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCorFormato_Jsonclick = "";
         edtCorFormato_Enabled = 1;
         chkCorFE.Enabled = 1;
         edtNumDoc_Jsonclick = "";
         edtNumDoc_Enabled = 1;
         edtCorSerie_Jsonclick = "";
         edtCorSerie_Enabled = 1;
         edtCorDoc_Jsonclick = "";
         edtCorDoc_Enabled = 1;
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
         chkCorFE.Name = "CORFE";
         chkCorFE.WebTags = "";
         chkCorFE.Caption = "";
         AssignProp("", false, chkCorFE_Internalname, "TitleCaption", chkCorFE.Caption, true);
         chkCorFE.CheckedValue = "0";
         A756CorFE = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtNumDoc_Internalname;
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

      public void Valid_Corserie( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A756CorFE = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         /*  Sending validation outputs */
         AssignAttri("", false, "A1377NumDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1377NumDoc), 10, 0, ".", "")));
         AssignAttri("", false, "A756CorFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")));
         AssignAttri("", false, "A757CorFormato", A757CorFormato);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z339CorDoc", StringUtil.RTrim( Z339CorDoc));
         GxWebStd.gx_hidden_field( context, "Z340CorSerie", StringUtil.RTrim( Z340CorSerie));
         GxWebStd.gx_hidden_field( context, "Z1377NumDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1377NumDoc), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z756CorFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z756CorFE), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z757CorFormato", Z757CorFormato);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
         setEventMetadata("VALID_CORDOC","{handler:'Valid_Cordoc',iparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("VALID_CORDOC",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
         setEventMetadata("VALID_CORSERIE","{handler:'Valid_Corserie',iparms:[{av:'A339CorDoc',fld:'CORDOC',pic:''},{av:'A340CorSerie',fld:'CORSERIE',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("VALID_CORSERIE",",oparms:[{av:'A1377NumDoc',fld:'NUMDOC',pic:'ZZZZZZZZZ9'},{av:'A757CorFormato',fld:'CORFORMATO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z339CorDoc'},{av:'Z340CorSerie'},{av:'Z1377NumDoc'},{av:'Z756CorFE'},{av:'Z757CorFormato'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
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
         Z339CorDoc = "";
         Z340CorSerie = "";
         Z757CorFormato = "";
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
         A339CorDoc = "";
         A340CorSerie = "";
         A757CorFormato = "";
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
         T000L4_A339CorDoc = new string[] {""} ;
         T000L4_A340CorSerie = new string[] {""} ;
         T000L4_A1377NumDoc = new long[1] ;
         T000L4_A756CorFE = new short[1] ;
         T000L4_A757CorFormato = new string[] {""} ;
         T000L5_A339CorDoc = new string[] {""} ;
         T000L5_A340CorSerie = new string[] {""} ;
         T000L3_A339CorDoc = new string[] {""} ;
         T000L3_A340CorSerie = new string[] {""} ;
         T000L3_A1377NumDoc = new long[1] ;
         T000L3_A756CorFE = new short[1] ;
         T000L3_A757CorFormato = new string[] {""} ;
         sMode20 = "";
         T000L6_A339CorDoc = new string[] {""} ;
         T000L6_A340CorSerie = new string[] {""} ;
         T000L7_A339CorDoc = new string[] {""} ;
         T000L7_A340CorSerie = new string[] {""} ;
         T000L2_A339CorDoc = new string[] {""} ;
         T000L2_A340CorSerie = new string[] {""} ;
         T000L2_A1377NumDoc = new long[1] ;
         T000L2_A756CorFE = new short[1] ;
         T000L2_A757CorFormato = new string[] {""} ;
         T000L11_A339CorDoc = new string[] {""} ;
         T000L11_A340CorSerie = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ339CorDoc = "";
         ZZ340CorSerie = "";
         ZZ757CorFormato = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgcdocumentos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgcdocumentos__default(),
            new Object[][] {
                new Object[] {
               T000L2_A339CorDoc, T000L2_A340CorSerie, T000L2_A1377NumDoc, T000L2_A756CorFE, T000L2_A757CorFormato
               }
               , new Object[] {
               T000L3_A339CorDoc, T000L3_A340CorSerie, T000L3_A1377NumDoc, T000L3_A756CorFE, T000L3_A757CorFormato
               }
               , new Object[] {
               T000L4_A339CorDoc, T000L4_A340CorSerie, T000L4_A1377NumDoc, T000L4_A756CorFE, T000L4_A757CorFormato
               }
               , new Object[] {
               T000L5_A339CorDoc, T000L5_A340CorSerie
               }
               , new Object[] {
               T000L6_A339CorDoc, T000L6_A340CorSerie
               }
               , new Object[] {
               T000L7_A339CorDoc, T000L7_A340CorSerie
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L11_A339CorDoc, T000L11_A340CorSerie
               }
            }
         );
      }

      private short Z756CorFE ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A756CorFE ;
      private short GX_JID ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ756CorFE ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCorDoc_Enabled ;
      private int edtCorSerie_Enabled ;
      private int edtNumDoc_Enabled ;
      private int edtCorFormato_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z1377NumDoc ;
      private long A1377NumDoc ;
      private long ZZ1377NumDoc ;
      private string sPrefix ;
      private string Z339CorDoc ;
      private string Z340CorSerie ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCorDoc_Internalname ;
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
      private string A339CorDoc ;
      private string edtCorDoc_Jsonclick ;
      private string edtCorSerie_Internalname ;
      private string A340CorSerie ;
      private string edtCorSerie_Jsonclick ;
      private string edtNumDoc_Internalname ;
      private string edtNumDoc_Jsonclick ;
      private string chkCorFE_Internalname ;
      private string edtCorFormato_Internalname ;
      private string edtCorFormato_Jsonclick ;
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
      private string sMode20 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ339CorDoc ;
      private string ZZ340CorSerie ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z757CorFormato ;
      private string A757CorFormato ;
      private string ZZ757CorFormato ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkCorFE ;
      private IDataStoreProvider pr_default ;
      private string[] T000L4_A339CorDoc ;
      private string[] T000L4_A340CorSerie ;
      private long[] T000L4_A1377NumDoc ;
      private short[] T000L4_A756CorFE ;
      private string[] T000L4_A757CorFormato ;
      private string[] T000L5_A339CorDoc ;
      private string[] T000L5_A340CorSerie ;
      private string[] T000L3_A339CorDoc ;
      private string[] T000L3_A340CorSerie ;
      private long[] T000L3_A1377NumDoc ;
      private short[] T000L3_A756CorFE ;
      private string[] T000L3_A757CorFormato ;
      private string[] T000L6_A339CorDoc ;
      private string[] T000L6_A340CorSerie ;
      private string[] T000L7_A339CorDoc ;
      private string[] T000L7_A340CorSerie ;
      private string[] T000L2_A339CorDoc ;
      private string[] T000L2_A340CorSerie ;
      private long[] T000L2_A1377NumDoc ;
      private short[] T000L2_A756CorFE ;
      private string[] T000L2_A757CorFormato ;
      private string[] T000L11_A339CorDoc ;
      private string[] T000L11_A340CorSerie ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgcdocumentos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgcdocumentos__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000L4;
        prmT000L4 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L5;
        prmT000L5 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L3;
        prmT000L3 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L6;
        prmT000L6 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L7;
        prmT000L7 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L2;
        prmT000L2 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L8;
        prmT000L8 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0) ,
        new ParDef("@NumDoc",GXType.Decimal,10,0) ,
        new ParDef("@CorFE",GXType.Int16,1,0) ,
        new ParDef("@CorFormato",GXType.NVarChar,50,0)
        };
        Object[] prmT000L9;
        prmT000L9 = new Object[] {
        new ParDef("@NumDoc",GXType.Decimal,10,0) ,
        new ParDef("@CorFE",GXType.Int16,1,0) ,
        new ParDef("@CorFormato",GXType.NVarChar,50,0) ,
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L10;
        prmT000L10 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000L11;
        prmT000L11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000L2", "SELECT [CorDoc], [CorSerie], [NumDoc], [CorFE], [CorFormato] FROM [SGCDOCUMENTOS] WITH (UPDLOCK) WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L3", "SELECT [CorDoc], [CorSerie], [NumDoc], [CorFE], [CorFormato] FROM [SGCDOCUMENTOS] WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L4", "SELECT TM1.[CorDoc], TM1.[CorSerie], TM1.[NumDoc], TM1.[CorFE], TM1.[CorFormato] FROM [SGCDOCUMENTOS] TM1 WHERE TM1.[CorDoc] = @CorDoc and TM1.[CorSerie] = @CorSerie ORDER BY TM1.[CorDoc], TM1.[CorSerie]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L5", "SELECT [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L6", "SELECT TOP 1 [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] WHERE ( [CorDoc] > @CorDoc or [CorDoc] = @CorDoc and [CorSerie] > @CorSerie) ORDER BY [CorDoc], [CorSerie]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L7", "SELECT TOP 1 [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] WHERE ( [CorDoc] < @CorDoc or [CorDoc] = @CorDoc and [CorSerie] < @CorSerie) ORDER BY [CorDoc] DESC, [CorSerie] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L8", "INSERT INTO [SGCDOCUMENTOS]([CorDoc], [CorSerie], [NumDoc], [CorFE], [CorFormato]) VALUES(@CorDoc, @CorSerie, @NumDoc, @CorFE, @CorFormato)", GxErrorMask.GX_NOMASK,prmT000L8)
           ,new CursorDef("T000L9", "UPDATE [SGCDOCUMENTOS] SET [NumDoc]=@NumDoc, [CorFE]=@CorFE, [CorFormato]=@CorFormato  WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie", GxErrorMask.GX_NOMASK,prmT000L9)
           ,new CursorDef("T000L10", "DELETE FROM [SGCDOCUMENTOS]  WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie", GxErrorMask.GX_NOMASK,prmT000L10)
           ,new CursorDef("T000L11", "SELECT [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] ORDER BY [CorDoc], [CorSerie]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000L11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
     }
  }

}

}
