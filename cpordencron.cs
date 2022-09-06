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
   public class cpordencron : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A289OrdCod = GetPar( "OrdCod");
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A289OrdCod) ;
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
            Form.Meta.addItem("description", "CPORDENCRON", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpordencron( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpordencron( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CPORDENCRON", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CPORDENCRON.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPORDENCRON.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrdCod_Internalname, "N° Orden", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdCod_Internalname, StringUtil.RTrim( A289OrdCod), StringUtil.RTrim( context.localUtil.Format( A289OrdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrdCron_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrdCron_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdCron_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A294OrdCron), 6, 0, ".", "")), StringUtil.LTrim( ((edtOrdCron_Enabled!=0) ? context.localUtil.Format( (decimal)(A294OrdCron), "ZZZZZ9") : context.localUtil.Format( (decimal)(A294OrdCron), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdCron_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdCron_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrdCronFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrdCronFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtOrdCronFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtOrdCronFec_Internalname, context.localUtil.Format(A1428OrdCronFec, "99/99/99"), context.localUtil.Format( A1428OrdCronFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdCronFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdCronFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPORDENCRON.htm");
         GxWebStd.gx_bitmap( context, edtOrdCronFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtOrdCronFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPORDENCRON.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtOrdCronRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtOrdCronRef_Internalname, "Comentario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtOrdCronRef_Internalname, StringUtil.RTrim( A1429OrdCronRef), StringUtil.RTrim( context.localUtil.Format( A1429OrdCronRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtOrdCronRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtOrdCronRef_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPORDENCRON.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENCRON.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPORDENCRON.htm");
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
            Z289OrdCod = cgiGet( "Z289OrdCod");
            Z294OrdCron = (int)(context.localUtil.CToN( cgiGet( "Z294OrdCron"), ".", ","));
            Z1428OrdCronFec = context.localUtil.CToD( cgiGet( "Z1428OrdCronFec"), 0);
            Z1429OrdCronRef = cgiGet( "Z1429OrdCronRef");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A289OrdCod = cgiGet( edtOrdCod_Internalname);
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtOrdCron_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtOrdCron_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ORDCRON");
               AnyError = 1;
               GX_FocusControl = edtOrdCron_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A294OrdCron = 0;
               AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
            }
            else
            {
               A294OrdCron = (int)(context.localUtil.CToN( cgiGet( edtOrdCron_Internalname), ".", ","));
               AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtOrdCronFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "ORDCRONFEC");
               AnyError = 1;
               GX_FocusControl = edtOrdCronFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1428OrdCronFec = DateTime.MinValue;
               AssignAttri("", false, "A1428OrdCronFec", context.localUtil.Format(A1428OrdCronFec, "99/99/99"));
            }
            else
            {
               A1428OrdCronFec = context.localUtil.CToD( cgiGet( edtOrdCronFec_Internalname), 2);
               AssignAttri("", false, "A1428OrdCronFec", context.localUtil.Format(A1428OrdCronFec, "99/99/99"));
            }
            A1429OrdCronRef = cgiGet( edtOrdCronRef_Internalname);
            AssignAttri("", false, "A1429OrdCronRef", A1429OrdCronRef);
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
               A289OrdCod = GetPar( "OrdCod");
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               A294OrdCron = (int)(NumberUtil.Val( GetPar( "OrdCron"), "."));
               AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
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
               InitAll7B122( ) ;
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
         DisableAttributes7B122( ) ;
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

      protected void ResetCaption7B0( )
      {
      }

      protected void ZM7B122( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1428OrdCronFec = T007B3_A1428OrdCronFec[0];
               Z1429OrdCronRef = T007B3_A1429OrdCronRef[0];
            }
            else
            {
               Z1428OrdCronFec = A1428OrdCronFec;
               Z1429OrdCronRef = A1429OrdCronRef;
            }
         }
         if ( GX_JID == -2 )
         {
            Z294OrdCron = A294OrdCron;
            Z1428OrdCronFec = A1428OrdCronFec;
            Z1429OrdCronRef = A1429OrdCronRef;
            Z289OrdCod = A289OrdCod;
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

      protected void Load7B122( )
      {
         /* Using cursor T007B5 */
         pr_default.execute(3, new Object[] {A289OrdCod, A294OrdCron});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound122 = 1;
            A1428OrdCronFec = T007B5_A1428OrdCronFec[0];
            AssignAttri("", false, "A1428OrdCronFec", context.localUtil.Format(A1428OrdCronFec, "99/99/99"));
            A1429OrdCronRef = T007B5_A1429OrdCronRef[0];
            AssignAttri("", false, "A1429OrdCronRef", A1429OrdCronRef);
            ZM7B122( -2) ;
         }
         pr_default.close(3);
         OnLoadActions7B122( ) ;
      }

      protected void OnLoadActions7B122( )
      {
      }

      protected void CheckExtendedTable7B122( )
      {
         nIsDirty_122 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007B4 */
         pr_default.execute(2, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1428OrdCronFec) || ( DateTimeUtil.ResetTime ( A1428OrdCronFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "ORDCRONFEC");
            AnyError = 1;
            GX_FocusControl = edtOrdCronFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors7B122( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A289OrdCod )
      {
         /* Using cursor T007B6 */
         pr_default.execute(4, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
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

      protected void GetKey7B122( )
      {
         /* Using cursor T007B7 */
         pr_default.execute(5, new Object[] {A289OrdCod, A294OrdCron});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound122 = 1;
         }
         else
         {
            RcdFound122 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007B3 */
         pr_default.execute(1, new Object[] {A289OrdCod, A294OrdCron});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7B122( 2) ;
            RcdFound122 = 1;
            A294OrdCron = T007B3_A294OrdCron[0];
            AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
            A1428OrdCronFec = T007B3_A1428OrdCronFec[0];
            AssignAttri("", false, "A1428OrdCronFec", context.localUtil.Format(A1428OrdCronFec, "99/99/99"));
            A1429OrdCronRef = T007B3_A1429OrdCronRef[0];
            AssignAttri("", false, "A1429OrdCronRef", A1429OrdCronRef);
            A289OrdCod = T007B3_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            Z289OrdCod = A289OrdCod;
            Z294OrdCron = A294OrdCron;
            sMode122 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7B122( ) ;
            if ( AnyError == 1 )
            {
               RcdFound122 = 0;
               InitializeNonKey7B122( ) ;
            }
            Gx_mode = sMode122;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound122 = 0;
            InitializeNonKey7B122( ) ;
            sMode122 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode122;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7B122( ) ;
         if ( RcdFound122 == 0 )
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
         RcdFound122 = 0;
         /* Using cursor T007B8 */
         pr_default.execute(6, new Object[] {A289OrdCod, A294OrdCron});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T007B8_A289OrdCod[0], A289OrdCod) < 0 ) || ( StringUtil.StrCmp(T007B8_A289OrdCod[0], A289OrdCod) == 0 ) && ( T007B8_A294OrdCron[0] < A294OrdCron ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T007B8_A289OrdCod[0], A289OrdCod) > 0 ) || ( StringUtil.StrCmp(T007B8_A289OrdCod[0], A289OrdCod) == 0 ) && ( T007B8_A294OrdCron[0] > A294OrdCron ) ) )
            {
               A289OrdCod = T007B8_A289OrdCod[0];
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               A294OrdCron = T007B8_A294OrdCron[0];
               AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
               RcdFound122 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound122 = 0;
         /* Using cursor T007B9 */
         pr_default.execute(7, new Object[] {A289OrdCod, A294OrdCron});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T007B9_A289OrdCod[0], A289OrdCod) > 0 ) || ( StringUtil.StrCmp(T007B9_A289OrdCod[0], A289OrdCod) == 0 ) && ( T007B9_A294OrdCron[0] > A294OrdCron ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T007B9_A289OrdCod[0], A289OrdCod) < 0 ) || ( StringUtil.StrCmp(T007B9_A289OrdCod[0], A289OrdCod) == 0 ) && ( T007B9_A294OrdCron[0] < A294OrdCron ) ) )
            {
               A289OrdCod = T007B9_A289OrdCod[0];
               AssignAttri("", false, "A289OrdCod", A289OrdCod);
               A294OrdCron = T007B9_A294OrdCron[0];
               AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
               RcdFound122 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7B122( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7B122( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound122 == 1 )
            {
               if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A294OrdCron != Z294OrdCron ) )
               {
                  A289OrdCod = Z289OrdCod;
                  AssignAttri("", false, "A289OrdCod", A289OrdCod);
                  A294OrdCron = Z294OrdCron;
                  AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ORDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7B122( ) ;
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A294OrdCron != Z294OrdCron ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtOrdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7B122( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ORDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtOrdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtOrdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7B122( ) ;
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
         if ( ( StringUtil.StrCmp(A289OrdCod, Z289OrdCod) != 0 ) || ( A294OrdCron != Z294OrdCron ) )
         {
            A289OrdCod = Z289OrdCod;
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A294OrdCron = Z294OrdCron;
            AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtOrdCod_Internalname;
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
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtOrdCronFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7B122( ) ;
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrdCronFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7B122( ) ;
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
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrdCronFec_Internalname;
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
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrdCronFec_Internalname;
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
         ScanStart7B122( ) ;
         if ( RcdFound122 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound122 != 0 )
            {
               ScanNext7B122( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtOrdCronFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7B122( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7B122( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007B2 */
            pr_default.execute(0, new Object[] {A289OrdCod, A294OrdCron});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPORDENCRON"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1428OrdCronFec ) != DateTimeUtil.ResetTime ( T007B2_A1428OrdCronFec[0] ) ) || ( StringUtil.StrCmp(Z1429OrdCronRef, T007B2_A1429OrdCronRef[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1428OrdCronFec ) != DateTimeUtil.ResetTime ( T007B2_A1428OrdCronFec[0] ) )
               {
                  GXUtil.WriteLog("cpordencron:[seudo value changed for attri]"+"OrdCronFec");
                  GXUtil.WriteLogRaw("Old: ",Z1428OrdCronFec);
                  GXUtil.WriteLogRaw("Current: ",T007B2_A1428OrdCronFec[0]);
               }
               if ( StringUtil.StrCmp(Z1429OrdCronRef, T007B2_A1429OrdCronRef[0]) != 0 )
               {
                  GXUtil.WriteLog("cpordencron:[seudo value changed for attri]"+"OrdCronRef");
                  GXUtil.WriteLogRaw("Old: ",Z1429OrdCronRef);
                  GXUtil.WriteLogRaw("Current: ",T007B2_A1429OrdCronRef[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPORDENCRON"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7B122( )
      {
         BeforeValidate7B122( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7B122( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7B122( 0) ;
            CheckOptimisticConcurrency7B122( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7B122( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7B122( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007B10 */
                     pr_default.execute(8, new Object[] {A294OrdCron, A1428OrdCronFec, A1429OrdCronRef, A289OrdCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CPORDENCRON");
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
                           ResetCaption7B0( ) ;
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
               Load7B122( ) ;
            }
            EndLevel7B122( ) ;
         }
         CloseExtendedTableCursors7B122( ) ;
      }

      protected void Update7B122( )
      {
         BeforeValidate7B122( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7B122( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7B122( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7B122( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7B122( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007B11 */
                     pr_default.execute(9, new Object[] {A1428OrdCronFec, A1429OrdCronRef, A289OrdCod, A294OrdCron});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CPORDENCRON");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPORDENCRON"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7B122( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7B0( ) ;
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
            EndLevel7B122( ) ;
         }
         CloseExtendedTableCursors7B122( ) ;
      }

      protected void DeferredUpdate7B122( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7B122( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7B122( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7B122( ) ;
            AfterConfirm7B122( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7B122( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007B12 */
                  pr_default.execute(10, new Object[] {A289OrdCod, A294OrdCron});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CPORDENCRON");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound122 == 0 )
                        {
                           InitAll7B122( ) ;
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
                        ResetCaption7B0( ) ;
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
         sMode122 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7B122( ) ;
         Gx_mode = sMode122;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7B122( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7B122( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7B122( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpordencron",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpordencron",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7B122( )
      {
         /* Using cursor T007B13 */
         pr_default.execute(11);
         RcdFound122 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound122 = 1;
            A289OrdCod = T007B13_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A294OrdCron = T007B13_A294OrdCron[0];
            AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7B122( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound122 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound122 = 1;
            A289OrdCod = T007B13_A289OrdCod[0];
            AssignAttri("", false, "A289OrdCod", A289OrdCod);
            A294OrdCron = T007B13_A294OrdCron[0];
            AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
         }
      }

      protected void ScanEnd7B122( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm7B122( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7B122( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7B122( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7B122( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7B122( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7B122( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7B122( )
      {
         edtOrdCod_Enabled = 0;
         AssignProp("", false, edtOrdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdCod_Enabled), 5, 0), true);
         edtOrdCron_Enabled = 0;
         AssignProp("", false, edtOrdCron_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdCron_Enabled), 5, 0), true);
         edtOrdCronFec_Enabled = 0;
         AssignProp("", false, edtOrdCronFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdCronFec_Enabled), 5, 0), true);
         edtOrdCronRef_Enabled = 0;
         AssignProp("", false, edtOrdCronRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtOrdCronRef_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7B122( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7B0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027313", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cpordencron.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z289OrdCod", StringUtil.RTrim( Z289OrdCod));
         GxWebStd.gx_hidden_field( context, "Z294OrdCron", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z294OrdCron), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1428OrdCronFec", context.localUtil.DToC( Z1428OrdCronFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1429OrdCronRef", StringUtil.RTrim( Z1429OrdCronRef));
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
         return formatLink("cpordencron.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPORDENCRON" ;
      }

      public override string GetPgmdesc( )
      {
         return "CPORDENCRON" ;
      }

      protected void InitializeNonKey7B122( )
      {
         A1428OrdCronFec = DateTime.MinValue;
         AssignAttri("", false, "A1428OrdCronFec", context.localUtil.Format(A1428OrdCronFec, "99/99/99"));
         A1429OrdCronRef = "";
         AssignAttri("", false, "A1429OrdCronRef", A1429OrdCronRef);
         Z1428OrdCronFec = DateTime.MinValue;
         Z1429OrdCronRef = "";
      }

      protected void InitAll7B122( )
      {
         A289OrdCod = "";
         AssignAttri("", false, "A289OrdCod", A289OrdCod);
         A294OrdCron = 0;
         AssignAttri("", false, "A294OrdCron", StringUtil.LTrimStr( (decimal)(A294OrdCron), 6, 0));
         InitializeNonKey7B122( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027319", true, true);
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
         context.AddJavascriptSource("cpordencron.js", "?20228181027319", false, true);
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
         edtOrdCod_Internalname = "ORDCOD";
         edtOrdCron_Internalname = "ORDCRON";
         edtOrdCronFec_Internalname = "ORDCRONFEC";
         edtOrdCronRef_Internalname = "ORDCRONREF";
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
         Form.Caption = "CPORDENCRON";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtOrdCronRef_Jsonclick = "";
         edtOrdCronRef_Enabled = 1;
         edtOrdCronFec_Jsonclick = "";
         edtOrdCronFec_Enabled = 1;
         edtOrdCron_Jsonclick = "";
         edtOrdCron_Enabled = 1;
         edtOrdCod_Jsonclick = "";
         edtOrdCod_Enabled = 1;
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
         /* Using cursor T007B14 */
         pr_default.execute(12, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtOrdCronFec_Internalname;
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

      public void Valid_Ordcod( )
      {
         /* Using cursor T007B14 */
         pr_default.execute(12, new Object[] {A289OrdCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Ordenes de Compra'.", "ForeignKeyNotFound", 1, "ORDCOD");
            AnyError = 1;
            GX_FocusControl = edtOrdCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Ordcron( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1428OrdCronFec", context.localUtil.Format(A1428OrdCronFec, "99/99/99"));
         AssignAttri("", false, "A1429OrdCronRef", StringUtil.RTrim( A1429OrdCronRef));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z289OrdCod", StringUtil.RTrim( Z289OrdCod));
         GxWebStd.gx_hidden_field( context, "Z294OrdCron", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z294OrdCron), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1428OrdCronFec", context.localUtil.Format(Z1428OrdCronFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1429OrdCronRef", StringUtil.RTrim( Z1429OrdCronRef));
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
         setEventMetadata("VALID_ORDCOD","{handler:'Valid_Ordcod',iparms:[{av:'A289OrdCod',fld:'ORDCOD',pic:''}]");
         setEventMetadata("VALID_ORDCOD",",oparms:[]}");
         setEventMetadata("VALID_ORDCRON","{handler:'Valid_Ordcron',iparms:[{av:'A289OrdCod',fld:'ORDCOD',pic:''},{av:'A294OrdCron',fld:'ORDCRON',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ORDCRON",",oparms:[{av:'A1428OrdCronFec',fld:'ORDCRONFEC',pic:''},{av:'A1429OrdCronRef',fld:'ORDCRONREF',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z289OrdCod'},{av:'Z294OrdCron'},{av:'Z1428OrdCronFec'},{av:'Z1429OrdCronRef'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ORDCRONFEC","{handler:'Valid_Ordcronfec',iparms:[]");
         setEventMetadata("VALID_ORDCRONFEC",",oparms:[]}");
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
         Z289OrdCod = "";
         Z1428OrdCronFec = DateTime.MinValue;
         Z1429OrdCronRef = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A289OrdCod = "";
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
         A1428OrdCronFec = DateTime.MinValue;
         A1429OrdCronRef = "";
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
         T007B5_A294OrdCron = new int[1] ;
         T007B5_A1428OrdCronFec = new DateTime[] {DateTime.MinValue} ;
         T007B5_A1429OrdCronRef = new string[] {""} ;
         T007B5_A289OrdCod = new string[] {""} ;
         T007B4_A289OrdCod = new string[] {""} ;
         T007B6_A289OrdCod = new string[] {""} ;
         T007B7_A289OrdCod = new string[] {""} ;
         T007B7_A294OrdCron = new int[1] ;
         T007B3_A294OrdCron = new int[1] ;
         T007B3_A1428OrdCronFec = new DateTime[] {DateTime.MinValue} ;
         T007B3_A1429OrdCronRef = new string[] {""} ;
         T007B3_A289OrdCod = new string[] {""} ;
         sMode122 = "";
         T007B8_A289OrdCod = new string[] {""} ;
         T007B8_A294OrdCron = new int[1] ;
         T007B9_A289OrdCod = new string[] {""} ;
         T007B9_A294OrdCron = new int[1] ;
         T007B2_A294OrdCron = new int[1] ;
         T007B2_A1428OrdCronFec = new DateTime[] {DateTime.MinValue} ;
         T007B2_A1429OrdCronRef = new string[] {""} ;
         T007B2_A289OrdCod = new string[] {""} ;
         T007B13_A289OrdCod = new string[] {""} ;
         T007B13_A294OrdCron = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007B14_A289OrdCod = new string[] {""} ;
         ZZ289OrdCod = "";
         ZZ1428OrdCronFec = DateTime.MinValue;
         ZZ1429OrdCronRef = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpordencron__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpordencron__default(),
            new Object[][] {
                new Object[] {
               T007B2_A294OrdCron, T007B2_A1428OrdCronFec, T007B2_A1429OrdCronRef, T007B2_A289OrdCod
               }
               , new Object[] {
               T007B3_A294OrdCron, T007B3_A1428OrdCronFec, T007B3_A1429OrdCronRef, T007B3_A289OrdCod
               }
               , new Object[] {
               T007B4_A289OrdCod
               }
               , new Object[] {
               T007B5_A294OrdCron, T007B5_A1428OrdCronFec, T007B5_A1429OrdCronRef, T007B5_A289OrdCod
               }
               , new Object[] {
               T007B6_A289OrdCod
               }
               , new Object[] {
               T007B7_A289OrdCod, T007B7_A294OrdCron
               }
               , new Object[] {
               T007B8_A289OrdCod, T007B8_A294OrdCron
               }
               , new Object[] {
               T007B9_A289OrdCod, T007B9_A294OrdCron
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007B13_A289OrdCod, T007B13_A294OrdCron
               }
               , new Object[] {
               T007B14_A289OrdCod
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
      private short RcdFound122 ;
      private short nIsDirty_122 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z294OrdCron ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtOrdCod_Enabled ;
      private int A294OrdCron ;
      private int edtOrdCron_Enabled ;
      private int edtOrdCronFec_Enabled ;
      private int edtOrdCronRef_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ294OrdCron ;
      private string sPrefix ;
      private string Z289OrdCod ;
      private string Z1429OrdCronRef ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A289OrdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtOrdCod_Internalname ;
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
      private string edtOrdCod_Jsonclick ;
      private string edtOrdCron_Internalname ;
      private string edtOrdCron_Jsonclick ;
      private string edtOrdCronFec_Internalname ;
      private string edtOrdCronFec_Jsonclick ;
      private string edtOrdCronRef_Internalname ;
      private string A1429OrdCronRef ;
      private string edtOrdCronRef_Jsonclick ;
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
      private string sMode122 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ289OrdCod ;
      private string ZZ1429OrdCronRef ;
      private DateTime Z1428OrdCronFec ;
      private DateTime A1428OrdCronFec ;
      private DateTime ZZ1428OrdCronFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T007B5_A294OrdCron ;
      private DateTime[] T007B5_A1428OrdCronFec ;
      private string[] T007B5_A1429OrdCronRef ;
      private string[] T007B5_A289OrdCod ;
      private string[] T007B4_A289OrdCod ;
      private string[] T007B6_A289OrdCod ;
      private string[] T007B7_A289OrdCod ;
      private int[] T007B7_A294OrdCron ;
      private int[] T007B3_A294OrdCron ;
      private DateTime[] T007B3_A1428OrdCronFec ;
      private string[] T007B3_A1429OrdCronRef ;
      private string[] T007B3_A289OrdCod ;
      private string[] T007B8_A289OrdCod ;
      private int[] T007B8_A294OrdCron ;
      private string[] T007B9_A289OrdCod ;
      private int[] T007B9_A294OrdCron ;
      private int[] T007B2_A294OrdCron ;
      private DateTime[] T007B2_A1428OrdCronFec ;
      private string[] T007B2_A1429OrdCronRef ;
      private string[] T007B2_A289OrdCod ;
      private string[] T007B13_A289OrdCod ;
      private int[] T007B13_A294OrdCron ;
      private string[] T007B14_A289OrdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpordencron__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpordencron__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007B5;
        prmT007B5 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B4;
        prmT007B4 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT007B6;
        prmT007B6 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT007B7;
        prmT007B7 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B3;
        prmT007B3 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B8;
        prmT007B8 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B9;
        prmT007B9 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B2;
        prmT007B2 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B10;
        prmT007B10 = new Object[] {
        new ParDef("@OrdCron",GXType.Int32,6,0) ,
        new ParDef("@OrdCronFec",GXType.Date,8,0) ,
        new ParDef("@OrdCronRef",GXType.NChar,100,0) ,
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        Object[] prmT007B11;
        prmT007B11 = new Object[] {
        new ParDef("@OrdCronFec",GXType.Date,8,0) ,
        new ParDef("@OrdCronRef",GXType.NChar,100,0) ,
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B12;
        prmT007B12 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0) ,
        new ParDef("@OrdCron",GXType.Int32,6,0)
        };
        Object[] prmT007B13;
        prmT007B13 = new Object[] {
        };
        Object[] prmT007B14;
        prmT007B14 = new Object[] {
        new ParDef("@OrdCod",GXType.NChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007B2", "SELECT [OrdCron], [OrdCronFec], [OrdCronRef], [OrdCod] FROM [CPORDENCRON] WITH (UPDLOCK) WHERE [OrdCod] = @OrdCod AND [OrdCron] = @OrdCron ",true, GxErrorMask.GX_NOMASK, false, this,prmT007B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007B3", "SELECT [OrdCron], [OrdCronFec], [OrdCronRef], [OrdCod] FROM [CPORDENCRON] WHERE [OrdCod] = @OrdCod AND [OrdCron] = @OrdCron ",true, GxErrorMask.GX_NOMASK, false, this,prmT007B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007B4", "SELECT [OrdCod] FROM [CPORDEN] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007B5", "SELECT TM1.[OrdCron], TM1.[OrdCronFec], TM1.[OrdCronRef], TM1.[OrdCod] FROM [CPORDENCRON] TM1 WHERE TM1.[OrdCod] = @OrdCod and TM1.[OrdCron] = @OrdCron ORDER BY TM1.[OrdCod], TM1.[OrdCron]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007B5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007B6", "SELECT [OrdCod] FROM [CPORDEN] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007B7", "SELECT [OrdCod], [OrdCron] FROM [CPORDENCRON] WHERE [OrdCod] = @OrdCod AND [OrdCron] = @OrdCron  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007B8", "SELECT TOP 1 [OrdCod], [OrdCron] FROM [CPORDENCRON] WHERE ( [OrdCod] > @OrdCod or [OrdCod] = @OrdCod and [OrdCron] > @OrdCron) ORDER BY [OrdCod], [OrdCron]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007B8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007B9", "SELECT TOP 1 [OrdCod], [OrdCron] FROM [CPORDENCRON] WHERE ( [OrdCod] < @OrdCod or [OrdCod] = @OrdCod and [OrdCron] < @OrdCron) ORDER BY [OrdCod] DESC, [OrdCron] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007B9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007B10", "INSERT INTO [CPORDENCRON]([OrdCron], [OrdCronFec], [OrdCronRef], [OrdCod]) VALUES(@OrdCron, @OrdCronFec, @OrdCronRef, @OrdCod)", GxErrorMask.GX_NOMASK,prmT007B10)
           ,new CursorDef("T007B11", "UPDATE [CPORDENCRON] SET [OrdCronFec]=@OrdCronFec, [OrdCronRef]=@OrdCronRef  WHERE [OrdCod] = @OrdCod AND [OrdCron] = @OrdCron", GxErrorMask.GX_NOMASK,prmT007B11)
           ,new CursorDef("T007B12", "DELETE FROM [CPORDENCRON]  WHERE [OrdCod] = @OrdCod AND [OrdCron] = @OrdCron", GxErrorMask.GX_NOMASK,prmT007B12)
           ,new CursorDef("T007B13", "SELECT [OrdCod], [OrdCron] FROM [CPORDENCRON] ORDER BY [OrdCod], [OrdCron]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007B13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007B14", "SELECT [OrdCod] FROM [CPORDEN] WHERE [OrdCod] = @OrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007B14,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
