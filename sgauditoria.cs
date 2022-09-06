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
   public class sgauditoria : GXDataArea
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
            Form.Meta.addItem("description", "SGAUDITORIA", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSGAuMod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public sgauditoria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgauditoria( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "SGAUDITORIA", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGAUDITORIA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGAUDITORIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuMod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuMod_Internalname, "Modulo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGAuMod_Internalname, A337SGAuMod, StringUtil.RTrim( context.localUtil.Format( A337SGAuMod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuMod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuMod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuFecha_Internalname, "Fecha Hora", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSGAuFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSGAuFecha_Internalname, context.localUtil.TToC( A338SGAuFecha, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A338SGAuFecha, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuFecha_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_bitmap( context, edtSGAuFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSGAuFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SGAUDITORIA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuTipCod_Internalname, "Tipo Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGAuTipCod_Internalname, A1847SGAuTipCod, StringUtil.RTrim( context.localUtil.Format( A1847SGAuTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuTipCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuDocNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuDocNum_Internalname, "N° Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGAuDocNum_Internalname, A1844SGAuDocNum, StringUtil.RTrim( context.localUtil.Format( A1844SGAuDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuDocNum_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuDocRef_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuDocRef_Internalname, "Doc.Referencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGAuDocRef_Internalname, A1845SGAuDocRef, StringUtil.RTrim( context.localUtil.Format( A1845SGAuDocRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuDocRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuDocRef_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuDocGls_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuDocGls_Internalname, "Glosa", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGAuDocGls_Internalname, A1843SGAuDocGls, StringUtil.RTrim( context.localUtil.Format( A1843SGAuDocGls, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuDocGls_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuDocGls_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGAuUsuCod_Internalname, A1849SGAuUsuCod, StringUtil.RTrim( context.localUtil.Format( A1849SGAuUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSGAuTipo_Internalname, A1848SGAuTipo, StringUtil.RTrim( context.localUtil.Format( A1848SGAuTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuTipo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSGAuFech_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSGAuFech_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtSGAuFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtSGAuFech_Internalname, context.localUtil.Format(A1846SGAuFech, "99/99/99"), context.localUtil.Format( A1846SGAuFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSGAuFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSGAuFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_bitmap( context, edtSGAuFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtSGAuFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_SGAUDITORIA.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGAUDITORIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGAUDITORIA.htm");
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
            Z337SGAuMod = cgiGet( "Z337SGAuMod");
            Z338SGAuFecha = context.localUtil.CToT( cgiGet( "Z338SGAuFecha"), 0);
            Z1847SGAuTipCod = cgiGet( "Z1847SGAuTipCod");
            Z1844SGAuDocNum = cgiGet( "Z1844SGAuDocNum");
            Z1845SGAuDocRef = cgiGet( "Z1845SGAuDocRef");
            Z1843SGAuDocGls = cgiGet( "Z1843SGAuDocGls");
            Z1849SGAuUsuCod = cgiGet( "Z1849SGAuUsuCod");
            Z1848SGAuTipo = cgiGet( "Z1848SGAuTipo");
            Z1846SGAuFech = context.localUtil.CToD( cgiGet( "Z1846SGAuFech"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A337SGAuMod = cgiGet( edtSGAuMod_Internalname);
            AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
            if ( context.localUtil.VCDateTime( cgiGet( edtSGAuFecha_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Hora"}), 1, "SGAUFECHA");
               AnyError = 1;
               GX_FocusControl = edtSGAuFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A338SGAuFecha = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A338SGAuFecha = context.localUtil.CToT( cgiGet( edtSGAuFecha_Internalname));
               AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
            }
            A1847SGAuTipCod = cgiGet( edtSGAuTipCod_Internalname);
            AssignAttri("", false, "A1847SGAuTipCod", A1847SGAuTipCod);
            A1844SGAuDocNum = cgiGet( edtSGAuDocNum_Internalname);
            AssignAttri("", false, "A1844SGAuDocNum", A1844SGAuDocNum);
            A1845SGAuDocRef = cgiGet( edtSGAuDocRef_Internalname);
            AssignAttri("", false, "A1845SGAuDocRef", A1845SGAuDocRef);
            A1843SGAuDocGls = cgiGet( edtSGAuDocGls_Internalname);
            AssignAttri("", false, "A1843SGAuDocGls", A1843SGAuDocGls);
            A1849SGAuUsuCod = cgiGet( edtSGAuUsuCod_Internalname);
            AssignAttri("", false, "A1849SGAuUsuCod", A1849SGAuUsuCod);
            A1848SGAuTipo = cgiGet( edtSGAuTipo_Internalname);
            AssignAttri("", false, "A1848SGAuTipo", A1848SGAuTipo);
            if ( context.localUtil.VCDate( cgiGet( edtSGAuFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "SGAUFECH");
               AnyError = 1;
               GX_FocusControl = edtSGAuFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1846SGAuFech = DateTime.MinValue;
               AssignAttri("", false, "A1846SGAuFech", context.localUtil.Format(A1846SGAuFech, "99/99/99"));
            }
            else
            {
               A1846SGAuFech = context.localUtil.CToD( cgiGet( edtSGAuFech_Internalname), 2);
               AssignAttri("", false, "A1846SGAuFech", context.localUtil.Format(A1846SGAuFech, "99/99/99"));
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
               A337SGAuMod = GetPar( "SGAuMod");
               AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
               A338SGAuFecha = context.localUtil.ParseDTimeParm( GetPar( "SGAuFecha"));
               AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
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
               InitAll0K21( ) ;
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
         DisableAttributes0K21( ) ;
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

      protected void ResetCaption0K0( )
      {
      }

      protected void ZM0K21( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1847SGAuTipCod = T000K3_A1847SGAuTipCod[0];
               Z1844SGAuDocNum = T000K3_A1844SGAuDocNum[0];
               Z1845SGAuDocRef = T000K3_A1845SGAuDocRef[0];
               Z1843SGAuDocGls = T000K3_A1843SGAuDocGls[0];
               Z1849SGAuUsuCod = T000K3_A1849SGAuUsuCod[0];
               Z1848SGAuTipo = T000K3_A1848SGAuTipo[0];
               Z1846SGAuFech = T000K3_A1846SGAuFech[0];
            }
            else
            {
               Z1847SGAuTipCod = A1847SGAuTipCod;
               Z1844SGAuDocNum = A1844SGAuDocNum;
               Z1845SGAuDocRef = A1845SGAuDocRef;
               Z1843SGAuDocGls = A1843SGAuDocGls;
               Z1849SGAuUsuCod = A1849SGAuUsuCod;
               Z1848SGAuTipo = A1848SGAuTipo;
               Z1846SGAuFech = A1846SGAuFech;
            }
         }
         if ( GX_JID == -3 )
         {
            Z337SGAuMod = A337SGAuMod;
            Z338SGAuFecha = A338SGAuFecha;
            Z1847SGAuTipCod = A1847SGAuTipCod;
            Z1844SGAuDocNum = A1844SGAuDocNum;
            Z1845SGAuDocRef = A1845SGAuDocRef;
            Z1843SGAuDocGls = A1843SGAuDocGls;
            Z1849SGAuUsuCod = A1849SGAuUsuCod;
            Z1848SGAuTipo = A1848SGAuTipo;
            Z1846SGAuFech = A1846SGAuFech;
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

      protected void Load0K21( )
      {
         /* Using cursor T000K4 */
         pr_default.execute(2, new Object[] {A337SGAuMod, A338SGAuFecha});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound21 = 1;
            A1847SGAuTipCod = T000K4_A1847SGAuTipCod[0];
            AssignAttri("", false, "A1847SGAuTipCod", A1847SGAuTipCod);
            A1844SGAuDocNum = T000K4_A1844SGAuDocNum[0];
            AssignAttri("", false, "A1844SGAuDocNum", A1844SGAuDocNum);
            A1845SGAuDocRef = T000K4_A1845SGAuDocRef[0];
            AssignAttri("", false, "A1845SGAuDocRef", A1845SGAuDocRef);
            A1843SGAuDocGls = T000K4_A1843SGAuDocGls[0];
            AssignAttri("", false, "A1843SGAuDocGls", A1843SGAuDocGls);
            A1849SGAuUsuCod = T000K4_A1849SGAuUsuCod[0];
            AssignAttri("", false, "A1849SGAuUsuCod", A1849SGAuUsuCod);
            A1848SGAuTipo = T000K4_A1848SGAuTipo[0];
            AssignAttri("", false, "A1848SGAuTipo", A1848SGAuTipo);
            A1846SGAuFech = T000K4_A1846SGAuFech[0];
            AssignAttri("", false, "A1846SGAuFech", context.localUtil.Format(A1846SGAuFech, "99/99/99"));
            ZM0K21( -3) ;
         }
         pr_default.close(2);
         OnLoadActions0K21( ) ;
      }

      protected void OnLoadActions0K21( )
      {
      }

      protected void CheckExtendedTable0K21( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A338SGAuFecha) || ( A338SGAuFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "SGAUFECHA");
            AnyError = 1;
            GX_FocusControl = edtSGAuFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1846SGAuFech) || ( DateTimeUtil.ResetTime ( A1846SGAuFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "SGAUFECH");
            AnyError = 1;
            GX_FocusControl = edtSGAuFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0K21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K21( )
      {
         /* Using cursor T000K5 */
         pr_default.execute(3, new Object[] {A337SGAuMod, A338SGAuFecha});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000K3 */
         pr_default.execute(1, new Object[] {A337SGAuMod, A338SGAuFecha});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K21( 3) ;
            RcdFound21 = 1;
            A337SGAuMod = T000K3_A337SGAuMod[0];
            AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
            A338SGAuFecha = T000K3_A338SGAuFecha[0];
            AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
            A1847SGAuTipCod = T000K3_A1847SGAuTipCod[0];
            AssignAttri("", false, "A1847SGAuTipCod", A1847SGAuTipCod);
            A1844SGAuDocNum = T000K3_A1844SGAuDocNum[0];
            AssignAttri("", false, "A1844SGAuDocNum", A1844SGAuDocNum);
            A1845SGAuDocRef = T000K3_A1845SGAuDocRef[0];
            AssignAttri("", false, "A1845SGAuDocRef", A1845SGAuDocRef);
            A1843SGAuDocGls = T000K3_A1843SGAuDocGls[0];
            AssignAttri("", false, "A1843SGAuDocGls", A1843SGAuDocGls);
            A1849SGAuUsuCod = T000K3_A1849SGAuUsuCod[0];
            AssignAttri("", false, "A1849SGAuUsuCod", A1849SGAuUsuCod);
            A1848SGAuTipo = T000K3_A1848SGAuTipo[0];
            AssignAttri("", false, "A1848SGAuTipo", A1848SGAuTipo);
            A1846SGAuFech = T000K3_A1846SGAuFech[0];
            AssignAttri("", false, "A1846SGAuFech", context.localUtil.Format(A1846SGAuFech, "99/99/99"));
            Z337SGAuMod = A337SGAuMod;
            Z338SGAuFecha = A338SGAuFecha;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0K21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0K21( ) ;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0K21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K21( ) ;
         if ( RcdFound21 == 0 )
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
         RcdFound21 = 0;
         /* Using cursor T000K6 */
         pr_default.execute(4, new Object[] {A337SGAuMod, A338SGAuFecha});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000K6_A337SGAuMod[0], A337SGAuMod) < 0 ) || ( StringUtil.StrCmp(T000K6_A337SGAuMod[0], A337SGAuMod) == 0 ) && ( T000K6_A338SGAuFecha[0] < A338SGAuFecha ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000K6_A337SGAuMod[0], A337SGAuMod) > 0 ) || ( StringUtil.StrCmp(T000K6_A337SGAuMod[0], A337SGAuMod) == 0 ) && ( T000K6_A338SGAuFecha[0] > A338SGAuFecha ) ) )
            {
               A337SGAuMod = T000K6_A337SGAuMod[0];
               AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
               A338SGAuFecha = T000K6_A338SGAuFecha[0];
               AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
               RcdFound21 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound21 = 0;
         /* Using cursor T000K7 */
         pr_default.execute(5, new Object[] {A337SGAuMod, A338SGAuFecha});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000K7_A337SGAuMod[0], A337SGAuMod) > 0 ) || ( StringUtil.StrCmp(T000K7_A337SGAuMod[0], A337SGAuMod) == 0 ) && ( T000K7_A338SGAuFecha[0] > A338SGAuFecha ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000K7_A337SGAuMod[0], A337SGAuMod) < 0 ) || ( StringUtil.StrCmp(T000K7_A337SGAuMod[0], A337SGAuMod) == 0 ) && ( T000K7_A338SGAuFecha[0] < A338SGAuFecha ) ) )
            {
               A337SGAuMod = T000K7_A337SGAuMod[0];
               AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
               A338SGAuFecha = T000K7_A338SGAuFecha[0];
               AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
               RcdFound21 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0K21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSGAuMod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0K21( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( ( StringUtil.StrCmp(A337SGAuMod, Z337SGAuMod) != 0 ) || ( A338SGAuFecha != Z338SGAuFecha ) )
               {
                  A337SGAuMod = Z337SGAuMod;
                  AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
                  A338SGAuFecha = Z338SGAuFecha;
                  AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SGAUMOD");
                  AnyError = 1;
                  GX_FocusControl = edtSGAuMod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSGAuMod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0K21( ) ;
                  GX_FocusControl = edtSGAuMod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A337SGAuMod, Z337SGAuMod) != 0 ) || ( A338SGAuFecha != Z338SGAuFecha ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSGAuMod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0K21( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SGAUMOD");
                     AnyError = 1;
                     GX_FocusControl = edtSGAuMod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSGAuMod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0K21( ) ;
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
         if ( ( StringUtil.StrCmp(A337SGAuMod, Z337SGAuMod) != 0 ) || ( A338SGAuFecha != Z338SGAuFecha ) )
         {
            A337SGAuMod = Z337SGAuMod;
            AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
            A338SGAuFecha = Z338SGAuFecha;
            AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SGAUMOD");
            AnyError = 1;
            GX_FocusControl = edtSGAuMod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSGAuMod_Internalname;
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
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SGAUMOD");
            AnyError = 1;
            GX_FocusControl = edtSGAuMod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSGAuTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGAuTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0K21( ) ;
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
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGAuTipCod_Internalname;
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
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGAuTipCod_Internalname;
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
         ScanStart0K21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound21 != 0 )
            {
               ScanNext0K21( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSGAuTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0K21( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0K21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000K2 */
            pr_default.execute(0, new Object[] {A337SGAuMod, A338SGAuFecha});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGAUDITORIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1847SGAuTipCod, T000K2_A1847SGAuTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1844SGAuDocNum, T000K2_A1844SGAuDocNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1845SGAuDocRef, T000K2_A1845SGAuDocRef[0]) != 0 ) || ( StringUtil.StrCmp(Z1843SGAuDocGls, T000K2_A1843SGAuDocGls[0]) != 0 ) || ( StringUtil.StrCmp(Z1849SGAuUsuCod, T000K2_A1849SGAuUsuCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1848SGAuTipo, T000K2_A1848SGAuTipo[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1846SGAuFech ) != DateTimeUtil.ResetTime ( T000K2_A1846SGAuFech[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z1847SGAuTipCod, T000K2_A1847SGAuTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("sgauditoria:[seudo value changed for attri]"+"SGAuTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z1847SGAuTipCod);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A1847SGAuTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z1844SGAuDocNum, T000K2_A1844SGAuDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("sgauditoria:[seudo value changed for attri]"+"SGAuDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z1844SGAuDocNum);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A1844SGAuDocNum[0]);
               }
               if ( StringUtil.StrCmp(Z1845SGAuDocRef, T000K2_A1845SGAuDocRef[0]) != 0 )
               {
                  GXUtil.WriteLog("sgauditoria:[seudo value changed for attri]"+"SGAuDocRef");
                  GXUtil.WriteLogRaw("Old: ",Z1845SGAuDocRef);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A1845SGAuDocRef[0]);
               }
               if ( StringUtil.StrCmp(Z1843SGAuDocGls, T000K2_A1843SGAuDocGls[0]) != 0 )
               {
                  GXUtil.WriteLog("sgauditoria:[seudo value changed for attri]"+"SGAuDocGls");
                  GXUtil.WriteLogRaw("Old: ",Z1843SGAuDocGls);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A1843SGAuDocGls[0]);
               }
               if ( StringUtil.StrCmp(Z1849SGAuUsuCod, T000K2_A1849SGAuUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("sgauditoria:[seudo value changed for attri]"+"SGAuUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1849SGAuUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A1849SGAuUsuCod[0]);
               }
               if ( StringUtil.StrCmp(Z1848SGAuTipo, T000K2_A1848SGAuTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("sgauditoria:[seudo value changed for attri]"+"SGAuTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1848SGAuTipo);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A1848SGAuTipo[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1846SGAuFech ) != DateTimeUtil.ResetTime ( T000K2_A1846SGAuFech[0] ) )
               {
                  GXUtil.WriteLog("sgauditoria:[seudo value changed for attri]"+"SGAuFech");
                  GXUtil.WriteLogRaw("Old: ",Z1846SGAuFech);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A1846SGAuFech[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGAUDITORIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K21( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K21( 0) ;
            CheckOptimisticConcurrency0K21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K8 */
                     pr_default.execute(6, new Object[] {A337SGAuMod, A338SGAuFecha, A1847SGAuTipCod, A1844SGAuDocNum, A1845SGAuDocRef, A1843SGAuDocGls, A1849SGAuUsuCod, A1848SGAuTipo, A1846SGAuFech});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGAUDITORIA");
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
                           ResetCaption0K0( ) ;
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
               Load0K21( ) ;
            }
            EndLevel0K21( ) ;
         }
         CloseExtendedTableCursors0K21( ) ;
      }

      protected void Update0K21( )
      {
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K9 */
                     pr_default.execute(7, new Object[] {A1847SGAuTipCod, A1844SGAuDocNum, A1845SGAuDocRef, A1843SGAuDocGls, A1849SGAuUsuCod, A1848SGAuTipo, A1846SGAuFech, A337SGAuMod, A338SGAuFecha});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGAUDITORIA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGAUDITORIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0K21( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0K0( ) ;
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
            EndLevel0K21( ) ;
         }
         CloseExtendedTableCursors0K21( ) ;
      }

      protected void DeferredUpdate0K21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0K21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K21( ) ;
            AfterConfirm0K21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000K10 */
                  pr_default.execute(8, new Object[] {A337SGAuMod, A338SGAuFecha});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGAUDITORIA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound21 == 0 )
                        {
                           InitAll0K21( ) ;
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
                        ResetCaption0K0( ) ;
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0K21( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0K21( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0K21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K21( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("sgauditoria",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("sgauditoria",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0K21( )
      {
         /* Using cursor T000K11 */
         pr_default.execute(9);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound21 = 1;
            A337SGAuMod = T000K11_A337SGAuMod[0];
            AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
            A338SGAuFecha = T000K11_A338SGAuFecha[0];
            AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0K21( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound21 = 1;
            A337SGAuMod = T000K11_A337SGAuMod[0];
            AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
            A338SGAuFecha = T000K11_A338SGAuFecha[0];
            AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void ScanEnd0K21( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0K21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K21( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0K21( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0K21( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0K21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K21( )
      {
         edtSGAuMod_Enabled = 0;
         AssignProp("", false, edtSGAuMod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuMod_Enabled), 5, 0), true);
         edtSGAuFecha_Enabled = 0;
         AssignProp("", false, edtSGAuFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuFecha_Enabled), 5, 0), true);
         edtSGAuTipCod_Enabled = 0;
         AssignProp("", false, edtSGAuTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuTipCod_Enabled), 5, 0), true);
         edtSGAuDocNum_Enabled = 0;
         AssignProp("", false, edtSGAuDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuDocNum_Enabled), 5, 0), true);
         edtSGAuDocRef_Enabled = 0;
         AssignProp("", false, edtSGAuDocRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuDocRef_Enabled), 5, 0), true);
         edtSGAuDocGls_Enabled = 0;
         AssignProp("", false, edtSGAuDocGls_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuDocGls_Enabled), 5, 0), true);
         edtSGAuUsuCod_Enabled = 0;
         AssignProp("", false, edtSGAuUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuUsuCod_Enabled), 5, 0), true);
         edtSGAuTipo_Enabled = 0;
         AssignProp("", false, edtSGAuTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuTipo_Enabled), 5, 0), true);
         edtSGAuFech_Enabled = 0;
         AssignProp("", false, edtSGAuFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSGAuFech_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0K21( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0K0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811442035", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgauditoria.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z337SGAuMod", Z337SGAuMod);
         GxWebStd.gx_hidden_field( context, "Z338SGAuFecha", context.localUtil.TToC( Z338SGAuFecha, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1847SGAuTipCod", Z1847SGAuTipCod);
         GxWebStd.gx_hidden_field( context, "Z1844SGAuDocNum", Z1844SGAuDocNum);
         GxWebStd.gx_hidden_field( context, "Z1845SGAuDocRef", Z1845SGAuDocRef);
         GxWebStd.gx_hidden_field( context, "Z1843SGAuDocGls", Z1843SGAuDocGls);
         GxWebStd.gx_hidden_field( context, "Z1849SGAuUsuCod", Z1849SGAuUsuCod);
         GxWebStd.gx_hidden_field( context, "Z1848SGAuTipo", Z1848SGAuTipo);
         GxWebStd.gx_hidden_field( context, "Z1846SGAuFech", context.localUtil.DToC( Z1846SGAuFech, 0, "/"));
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
         return formatLink("sgauditoria.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGAUDITORIA" ;
      }

      public override string GetPgmdesc( )
      {
         return "SGAUDITORIA" ;
      }

      protected void InitializeNonKey0K21( )
      {
         A1847SGAuTipCod = "";
         AssignAttri("", false, "A1847SGAuTipCod", A1847SGAuTipCod);
         A1844SGAuDocNum = "";
         AssignAttri("", false, "A1844SGAuDocNum", A1844SGAuDocNum);
         A1845SGAuDocRef = "";
         AssignAttri("", false, "A1845SGAuDocRef", A1845SGAuDocRef);
         A1843SGAuDocGls = "";
         AssignAttri("", false, "A1843SGAuDocGls", A1843SGAuDocGls);
         A1849SGAuUsuCod = "";
         AssignAttri("", false, "A1849SGAuUsuCod", A1849SGAuUsuCod);
         A1848SGAuTipo = "";
         AssignAttri("", false, "A1848SGAuTipo", A1848SGAuTipo);
         A1846SGAuFech = DateTime.MinValue;
         AssignAttri("", false, "A1846SGAuFech", context.localUtil.Format(A1846SGAuFech, "99/99/99"));
         Z1847SGAuTipCod = "";
         Z1844SGAuDocNum = "";
         Z1845SGAuDocRef = "";
         Z1843SGAuDocGls = "";
         Z1849SGAuUsuCod = "";
         Z1848SGAuTipo = "";
         Z1846SGAuFech = DateTime.MinValue;
      }

      protected void InitAll0K21( )
      {
         A337SGAuMod = "";
         AssignAttri("", false, "A337SGAuMod", A337SGAuMod);
         A338SGAuFecha = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A338SGAuFecha", context.localUtil.TToC( A338SGAuFecha, 8, 5, 0, 3, "/", ":", " "));
         InitializeNonKey0K21( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811442042", true, true);
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
         context.AddJavascriptSource("sgauditoria.js", "?202281811442042", false, true);
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
         edtSGAuMod_Internalname = "SGAUMOD";
         edtSGAuFecha_Internalname = "SGAUFECHA";
         edtSGAuTipCod_Internalname = "SGAUTIPCOD";
         edtSGAuDocNum_Internalname = "SGAUDOCNUM";
         edtSGAuDocRef_Internalname = "SGAUDOCREF";
         edtSGAuDocGls_Internalname = "SGAUDOCGLS";
         edtSGAuUsuCod_Internalname = "SGAUUSUCOD";
         edtSGAuTipo_Internalname = "SGAUTIPO";
         edtSGAuFech_Internalname = "SGAUFECH";
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
         Form.Caption = "SGAUDITORIA";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSGAuFech_Jsonclick = "";
         edtSGAuFech_Enabled = 1;
         edtSGAuTipo_Jsonclick = "";
         edtSGAuTipo_Enabled = 1;
         edtSGAuUsuCod_Jsonclick = "";
         edtSGAuUsuCod_Enabled = 1;
         edtSGAuDocGls_Jsonclick = "";
         edtSGAuDocGls_Enabled = 1;
         edtSGAuDocRef_Jsonclick = "";
         edtSGAuDocRef_Enabled = 1;
         edtSGAuDocNum_Jsonclick = "";
         edtSGAuDocNum_Enabled = 1;
         edtSGAuTipCod_Jsonclick = "";
         edtSGAuTipCod_Enabled = 1;
         edtSGAuFecha_Jsonclick = "";
         edtSGAuFecha_Enabled = 1;
         edtSGAuMod_Jsonclick = "";
         edtSGAuMod_Enabled = 1;
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
         GX_FocusControl = edtSGAuTipCod_Internalname;
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

      public void Valid_Sgaufecha( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         if ( ! ( (DateTime.MinValue==A338SGAuFecha) || ( A338SGAuFecha >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Hora fuera de rango", "OutOfRange", 1, "SGAUFECHA");
            AnyError = 1;
            GX_FocusControl = edtSGAuFecha_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1847SGAuTipCod", A1847SGAuTipCod);
         AssignAttri("", false, "A1844SGAuDocNum", A1844SGAuDocNum);
         AssignAttri("", false, "A1845SGAuDocRef", A1845SGAuDocRef);
         AssignAttri("", false, "A1843SGAuDocGls", A1843SGAuDocGls);
         AssignAttri("", false, "A1849SGAuUsuCod", A1849SGAuUsuCod);
         AssignAttri("", false, "A1848SGAuTipo", A1848SGAuTipo);
         AssignAttri("", false, "A1846SGAuFech", context.localUtil.Format(A1846SGAuFech, "99/99/99"));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z337SGAuMod", Z337SGAuMod);
         GxWebStd.gx_hidden_field( context, "Z338SGAuFecha", context.localUtil.TToC( Z338SGAuFecha, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1847SGAuTipCod", Z1847SGAuTipCod);
         GxWebStd.gx_hidden_field( context, "Z1844SGAuDocNum", Z1844SGAuDocNum);
         GxWebStd.gx_hidden_field( context, "Z1845SGAuDocRef", Z1845SGAuDocRef);
         GxWebStd.gx_hidden_field( context, "Z1843SGAuDocGls", Z1843SGAuDocGls);
         GxWebStd.gx_hidden_field( context, "Z1849SGAuUsuCod", Z1849SGAuUsuCod);
         GxWebStd.gx_hidden_field( context, "Z1848SGAuTipo", Z1848SGAuTipo);
         GxWebStd.gx_hidden_field( context, "Z1846SGAuFech", context.localUtil.Format(Z1846SGAuFech, "99/99/99"));
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
         setEventMetadata("VALID_SGAUMOD","{handler:'Valid_Sgaumod',iparms:[]");
         setEventMetadata("VALID_SGAUMOD",",oparms:[]}");
         setEventMetadata("VALID_SGAUFECHA","{handler:'Valid_Sgaufecha',iparms:[{av:'A337SGAuMod',fld:'SGAUMOD',pic:''},{av:'A338SGAuFecha',fld:'SGAUFECHA',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SGAUFECHA",",oparms:[{av:'A1847SGAuTipCod',fld:'SGAUTIPCOD',pic:''},{av:'A1844SGAuDocNum',fld:'SGAUDOCNUM',pic:''},{av:'A1845SGAuDocRef',fld:'SGAUDOCREF',pic:''},{av:'A1843SGAuDocGls',fld:'SGAUDOCGLS',pic:''},{av:'A1849SGAuUsuCod',fld:'SGAUUSUCOD',pic:''},{av:'A1848SGAuTipo',fld:'SGAUTIPO',pic:''},{av:'A1846SGAuFech',fld:'SGAUFECH',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z337SGAuMod'},{av:'Z338SGAuFecha'},{av:'Z1847SGAuTipCod'},{av:'Z1844SGAuDocNum'},{av:'Z1845SGAuDocRef'},{av:'Z1843SGAuDocGls'},{av:'Z1849SGAuUsuCod'},{av:'Z1848SGAuTipo'},{av:'Z1846SGAuFech'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_SGAUFECH","{handler:'Valid_Sgaufech',iparms:[]");
         setEventMetadata("VALID_SGAUFECH",",oparms:[]}");
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
         Z337SGAuMod = "";
         Z338SGAuFecha = (DateTime)(DateTime.MinValue);
         Z1847SGAuTipCod = "";
         Z1844SGAuDocNum = "";
         Z1845SGAuDocRef = "";
         Z1843SGAuDocGls = "";
         Z1849SGAuUsuCod = "";
         Z1848SGAuTipo = "";
         Z1846SGAuFech = DateTime.MinValue;
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
         A337SGAuMod = "";
         A338SGAuFecha = (DateTime)(DateTime.MinValue);
         A1847SGAuTipCod = "";
         A1844SGAuDocNum = "";
         A1845SGAuDocRef = "";
         A1843SGAuDocGls = "";
         A1849SGAuUsuCod = "";
         A1848SGAuTipo = "";
         A1846SGAuFech = DateTime.MinValue;
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
         T000K4_A337SGAuMod = new string[] {""} ;
         T000K4_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         T000K4_A1847SGAuTipCod = new string[] {""} ;
         T000K4_A1844SGAuDocNum = new string[] {""} ;
         T000K4_A1845SGAuDocRef = new string[] {""} ;
         T000K4_A1843SGAuDocGls = new string[] {""} ;
         T000K4_A1849SGAuUsuCod = new string[] {""} ;
         T000K4_A1848SGAuTipo = new string[] {""} ;
         T000K4_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         T000K5_A337SGAuMod = new string[] {""} ;
         T000K5_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         T000K3_A337SGAuMod = new string[] {""} ;
         T000K3_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         T000K3_A1847SGAuTipCod = new string[] {""} ;
         T000K3_A1844SGAuDocNum = new string[] {""} ;
         T000K3_A1845SGAuDocRef = new string[] {""} ;
         T000K3_A1843SGAuDocGls = new string[] {""} ;
         T000K3_A1849SGAuUsuCod = new string[] {""} ;
         T000K3_A1848SGAuTipo = new string[] {""} ;
         T000K3_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         sMode21 = "";
         T000K6_A337SGAuMod = new string[] {""} ;
         T000K6_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         T000K7_A337SGAuMod = new string[] {""} ;
         T000K7_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         T000K2_A337SGAuMod = new string[] {""} ;
         T000K2_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         T000K2_A1847SGAuTipCod = new string[] {""} ;
         T000K2_A1844SGAuDocNum = new string[] {""} ;
         T000K2_A1845SGAuDocRef = new string[] {""} ;
         T000K2_A1843SGAuDocGls = new string[] {""} ;
         T000K2_A1849SGAuUsuCod = new string[] {""} ;
         T000K2_A1848SGAuTipo = new string[] {""} ;
         T000K2_A1846SGAuFech = new DateTime[] {DateTime.MinValue} ;
         T000K11_A337SGAuMod = new string[] {""} ;
         T000K11_A338SGAuFecha = new DateTime[] {DateTime.MinValue} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ337SGAuMod = "";
         ZZ338SGAuFecha = (DateTime)(DateTime.MinValue);
         ZZ1847SGAuTipCod = "";
         ZZ1844SGAuDocNum = "";
         ZZ1845SGAuDocRef = "";
         ZZ1843SGAuDocGls = "";
         ZZ1849SGAuUsuCod = "";
         ZZ1848SGAuTipo = "";
         ZZ1846SGAuFech = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgauditoria__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgauditoria__default(),
            new Object[][] {
                new Object[] {
               T000K2_A337SGAuMod, T000K2_A338SGAuFecha, T000K2_A1847SGAuTipCod, T000K2_A1844SGAuDocNum, T000K2_A1845SGAuDocRef, T000K2_A1843SGAuDocGls, T000K2_A1849SGAuUsuCod, T000K2_A1848SGAuTipo, T000K2_A1846SGAuFech
               }
               , new Object[] {
               T000K3_A337SGAuMod, T000K3_A338SGAuFecha, T000K3_A1847SGAuTipCod, T000K3_A1844SGAuDocNum, T000K3_A1845SGAuDocRef, T000K3_A1843SGAuDocGls, T000K3_A1849SGAuUsuCod, T000K3_A1848SGAuTipo, T000K3_A1846SGAuFech
               }
               , new Object[] {
               T000K4_A337SGAuMod, T000K4_A338SGAuFecha, T000K4_A1847SGAuTipCod, T000K4_A1844SGAuDocNum, T000K4_A1845SGAuDocRef, T000K4_A1843SGAuDocGls, T000K4_A1849SGAuUsuCod, T000K4_A1848SGAuTipo, T000K4_A1846SGAuFech
               }
               , new Object[] {
               T000K5_A337SGAuMod, T000K5_A338SGAuFecha
               }
               , new Object[] {
               T000K6_A337SGAuMod, T000K6_A338SGAuFecha
               }
               , new Object[] {
               T000K7_A337SGAuMod, T000K7_A338SGAuFecha
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000K11_A337SGAuMod, T000K11_A338SGAuFecha
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
      private short RcdFound21 ;
      private short nIsDirty_21 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSGAuMod_Enabled ;
      private int edtSGAuFecha_Enabled ;
      private int edtSGAuTipCod_Enabled ;
      private int edtSGAuDocNum_Enabled ;
      private int edtSGAuDocRef_Enabled ;
      private int edtSGAuDocGls_Enabled ;
      private int edtSGAuUsuCod_Enabled ;
      private int edtSGAuTipo_Enabled ;
      private int edtSGAuFech_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSGAuMod_Internalname ;
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
      private string edtSGAuMod_Jsonclick ;
      private string edtSGAuFecha_Internalname ;
      private string edtSGAuFecha_Jsonclick ;
      private string edtSGAuTipCod_Internalname ;
      private string edtSGAuTipCod_Jsonclick ;
      private string edtSGAuDocNum_Internalname ;
      private string edtSGAuDocNum_Jsonclick ;
      private string edtSGAuDocRef_Internalname ;
      private string edtSGAuDocRef_Jsonclick ;
      private string edtSGAuDocGls_Internalname ;
      private string edtSGAuDocGls_Jsonclick ;
      private string edtSGAuUsuCod_Internalname ;
      private string edtSGAuUsuCod_Jsonclick ;
      private string edtSGAuTipo_Internalname ;
      private string edtSGAuTipo_Jsonclick ;
      private string edtSGAuFech_Internalname ;
      private string edtSGAuFech_Jsonclick ;
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
      private string sMode21 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z338SGAuFecha ;
      private DateTime A338SGAuFecha ;
      private DateTime ZZ338SGAuFecha ;
      private DateTime Z1846SGAuFech ;
      private DateTime A1846SGAuFech ;
      private DateTime ZZ1846SGAuFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z337SGAuMod ;
      private string Z1847SGAuTipCod ;
      private string Z1844SGAuDocNum ;
      private string Z1845SGAuDocRef ;
      private string Z1843SGAuDocGls ;
      private string Z1849SGAuUsuCod ;
      private string Z1848SGAuTipo ;
      private string A337SGAuMod ;
      private string A1847SGAuTipCod ;
      private string A1844SGAuDocNum ;
      private string A1845SGAuDocRef ;
      private string A1843SGAuDocGls ;
      private string A1849SGAuUsuCod ;
      private string A1848SGAuTipo ;
      private string ZZ337SGAuMod ;
      private string ZZ1847SGAuTipCod ;
      private string ZZ1844SGAuDocNum ;
      private string ZZ1845SGAuDocRef ;
      private string ZZ1843SGAuDocGls ;
      private string ZZ1849SGAuUsuCod ;
      private string ZZ1848SGAuTipo ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000K4_A337SGAuMod ;
      private DateTime[] T000K4_A338SGAuFecha ;
      private string[] T000K4_A1847SGAuTipCod ;
      private string[] T000K4_A1844SGAuDocNum ;
      private string[] T000K4_A1845SGAuDocRef ;
      private string[] T000K4_A1843SGAuDocGls ;
      private string[] T000K4_A1849SGAuUsuCod ;
      private string[] T000K4_A1848SGAuTipo ;
      private DateTime[] T000K4_A1846SGAuFech ;
      private string[] T000K5_A337SGAuMod ;
      private DateTime[] T000K5_A338SGAuFecha ;
      private string[] T000K3_A337SGAuMod ;
      private DateTime[] T000K3_A338SGAuFecha ;
      private string[] T000K3_A1847SGAuTipCod ;
      private string[] T000K3_A1844SGAuDocNum ;
      private string[] T000K3_A1845SGAuDocRef ;
      private string[] T000K3_A1843SGAuDocGls ;
      private string[] T000K3_A1849SGAuUsuCod ;
      private string[] T000K3_A1848SGAuTipo ;
      private DateTime[] T000K3_A1846SGAuFech ;
      private string[] T000K6_A337SGAuMod ;
      private DateTime[] T000K6_A338SGAuFecha ;
      private string[] T000K7_A337SGAuMod ;
      private DateTime[] T000K7_A338SGAuFecha ;
      private string[] T000K2_A337SGAuMod ;
      private DateTime[] T000K2_A338SGAuFecha ;
      private string[] T000K2_A1847SGAuTipCod ;
      private string[] T000K2_A1844SGAuDocNum ;
      private string[] T000K2_A1845SGAuDocRef ;
      private string[] T000K2_A1843SGAuDocGls ;
      private string[] T000K2_A1849SGAuUsuCod ;
      private string[] T000K2_A1848SGAuTipo ;
      private DateTime[] T000K2_A1846SGAuFech ;
      private string[] T000K11_A337SGAuMod ;
      private DateTime[] T000K11_A338SGAuFecha ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgauditoria__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgauditoria__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000K4;
        prmT000K4 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K5;
        prmT000K5 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K3;
        prmT000K3 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K6;
        prmT000K6 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K7;
        prmT000K7 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K2;
        prmT000K2 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K8;
        prmT000K8 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5) ,
        new ParDef("@SGAuTipCod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuDocNum",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuDocRef",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuDocGls",GXType.NVarChar,100,0) ,
        new ParDef("@SGAuUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@SGAuTipo",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuFech",GXType.Date,8,0)
        };
        Object[] prmT000K9;
        prmT000K9 = new Object[] {
        new ParDef("@SGAuTipCod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuDocNum",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuDocRef",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuDocGls",GXType.NVarChar,100,0) ,
        new ParDef("@SGAuUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@SGAuTipo",GXType.NVarChar,20,0) ,
        new ParDef("@SGAuFech",GXType.Date,8,0) ,
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K10;
        prmT000K10 = new Object[] {
        new ParDef("@SGAuMod",GXType.NVarChar,5,0) ,
        new ParDef("@SGAuFecha",GXType.DateTime,8,5)
        };
        Object[] prmT000K11;
        prmT000K11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000K2", "SELECT [SGAuMod], [SGAuFecha], [SGAuTipCod], [SGAuDocNum], [SGAuDocRef], [SGAuDocGls], [SGAuUsuCod], [SGAuTipo], [SGAuFech] FROM [SGAUDITORIA] WITH (UPDLOCK) WHERE [SGAuMod] = @SGAuMod AND [SGAuFecha] = @SGAuFecha ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K3", "SELECT [SGAuMod], [SGAuFecha], [SGAuTipCod], [SGAuDocNum], [SGAuDocRef], [SGAuDocGls], [SGAuUsuCod], [SGAuTipo], [SGAuFech] FROM [SGAUDITORIA] WHERE [SGAuMod] = @SGAuMod AND [SGAuFecha] = @SGAuFecha ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K4", "SELECT TM1.[SGAuMod], TM1.[SGAuFecha], TM1.[SGAuTipCod], TM1.[SGAuDocNum], TM1.[SGAuDocRef], TM1.[SGAuDocGls], TM1.[SGAuUsuCod], TM1.[SGAuTipo], TM1.[SGAuFech] FROM [SGAUDITORIA] TM1 WHERE TM1.[SGAuMod] = @SGAuMod and TM1.[SGAuFecha] = @SGAuFecha ORDER BY TM1.[SGAuMod], TM1.[SGAuFecha]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K5", "SELECT [SGAuMod], [SGAuFecha] FROM [SGAUDITORIA] WHERE [SGAuMod] = @SGAuMod AND [SGAuFecha] = @SGAuFecha  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K6", "SELECT TOP 1 [SGAuMod], [SGAuFecha] FROM [SGAUDITORIA] WHERE ( [SGAuMod] > @SGAuMod or [SGAuMod] = @SGAuMod and [SGAuFecha] > @SGAuFecha) ORDER BY [SGAuMod], [SGAuFecha]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K7", "SELECT TOP 1 [SGAuMod], [SGAuFecha] FROM [SGAUDITORIA] WHERE ( [SGAuMod] < @SGAuMod or [SGAuMod] = @SGAuMod and [SGAuFecha] < @SGAuFecha) ORDER BY [SGAuMod] DESC, [SGAuFecha] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K8", "INSERT INTO [SGAUDITORIA]([SGAuMod], [SGAuFecha], [SGAuTipCod], [SGAuDocNum], [SGAuDocRef], [SGAuDocGls], [SGAuUsuCod], [SGAuTipo], [SGAuFech]) VALUES(@SGAuMod, @SGAuFecha, @SGAuTipCod, @SGAuDocNum, @SGAuDocRef, @SGAuDocGls, @SGAuUsuCod, @SGAuTipo, @SGAuFech)", GxErrorMask.GX_NOMASK,prmT000K8)
           ,new CursorDef("T000K9", "UPDATE [SGAUDITORIA] SET [SGAuTipCod]=@SGAuTipCod, [SGAuDocNum]=@SGAuDocNum, [SGAuDocRef]=@SGAuDocRef, [SGAuDocGls]=@SGAuDocGls, [SGAuUsuCod]=@SGAuUsuCod, [SGAuTipo]=@SGAuTipo, [SGAuFech]=@SGAuFech  WHERE [SGAuMod] = @SGAuMod AND [SGAuFecha] = @SGAuFecha", GxErrorMask.GX_NOMASK,prmT000K9)
           ,new CursorDef("T000K10", "DELETE FROM [SGAUDITORIA]  WHERE [SGAuMod] = @SGAuMod AND [SGAuFecha] = @SGAuFecha", GxErrorMask.GX_NOMASK,prmT000K10)
           ,new CursorDef("T000K11", "SELECT [SGAuMod], [SGAuFecha] FROM [SGAUDITORIA] ORDER BY [SGAuMod], [SGAuFecha]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000K11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDate(9);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              return;
     }
  }

}

}
