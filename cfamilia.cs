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
   public class cfamilia : GXDataArea
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
            Form.Meta.addItem("description", "Familia", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFamCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cfamilia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cfamilia( IGxContext context )
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
         cmbFamSts = new GXCombobox();
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
         if ( cmbFamSts.ItemCount > 0 )
         {
            A979FamSts = (short)(NumberUtil.Val( cmbFamSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0))), "."));
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFamSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0));
            AssignProp("", false, cmbFamSts_Internalname, "Values", cmbFamSts.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFamCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFamCod_Internalname, "Codigo Familia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFamCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtFamCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFamCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CFAMILIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFamDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFamDsc_Internalname, "Familia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFamDsc_Internalname, StringUtil.RTrim( A977FamDsc), StringUtil.RTrim( context.localUtil.Format( A977FamDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFamDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CFAMILIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFamAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFamAbr_Internalname, "Abr. Familia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFamAbr_Internalname, StringUtil.RTrim( A976FamAbr), StringUtil.RTrim( context.localUtil.Format( A976FamAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFamAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CFAMILIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbFamSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbFamSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFamSts, cmbFamSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0)), 1, cmbFamSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbFamSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 1, "HLP_CFAMILIA.htm");
         cmbFamSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         AssignProp("", false, cmbFamSts_Internalname, "Values", (string)(cmbFamSts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgFamFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A978FamFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FamFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.PathToRelativeUrl( A978FamFoto));
         GxWebStd.gx_bitmap( context, imgFamFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgFamFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", "", "", 0, A978FamFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_CFAMILIA.htm");
         AssignProp("", false, imgFamFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.PathToRelativeUrl( A978FamFoto)), true);
         AssignProp("", false, imgFamFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A978FamFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFAMILIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFAMILIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CFAMILIA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112B2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z50FamCod = (int)(context.localUtil.CToN( cgiGet( "Z50FamCod"), ".", ","));
               Z977FamDsc = cgiGet( "Z977FamDsc");
               Z976FamAbr = cgiGet( "Z976FamAbr");
               Z979FamSts = (short)(context.localUtil.CToN( cgiGet( "Z979FamSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               A40000FamFoto_GXI = cgiGet( "FAMFOTO_GXI");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FAMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A50FamCod = 0;
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               else
               {
                  A50FamCod = (int)(context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ","));
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               A977FamDsc = cgiGet( edtFamDsc_Internalname);
               AssignAttri("", false, "A977FamDsc", A977FamDsc);
               A976FamAbr = cgiGet( edtFamAbr_Internalname);
               AssignAttri("", false, "A976FamAbr", A976FamAbr);
               cmbFamSts.CurrentValue = cgiGet( cmbFamSts_Internalname);
               A979FamSts = (short)(NumberUtil.Val( cgiGet( cmbFamSts_Internalname), "."));
               AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
               A978FamFoto = cgiGet( imgFamFoto_Internalname);
               AssignAttri("", false, "A978FamFoto", A978FamFoto);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgFamFoto_Internalname, ref  A978FamFoto, ref  A40000FamFoto_GXI);
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
                  A50FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E112B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E122B2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            /* Execute user event: After Trn */
            E122B2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll2B80( ) ;
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
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtntrn_enter_Visible = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
         }
         DisableAttributes2B80( ) ;
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

      protected void ResetCaption2B0( )
      {
      }

      protected void E112B2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E122B2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM2B80( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z977FamDsc = T002B3_A977FamDsc[0];
               Z976FamAbr = T002B3_A976FamAbr[0];
               Z979FamSts = T002B3_A979FamSts[0];
            }
            else
            {
               Z977FamDsc = A977FamDsc;
               Z976FamAbr = A976FamAbr;
               Z979FamSts = A979FamSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z50FamCod = A50FamCod;
            Z977FamDsc = A977FamDsc;
            Z976FamAbr = A976FamAbr;
            Z979FamSts = A979FamSts;
            Z978FamFoto = A978FamFoto;
            Z40000FamFoto_GXI = A40000FamFoto_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtntrn_delete_Enabled = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_delete_Enabled = 1;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load2B80( )
      {
         /* Using cursor T002B4 */
         pr_default.execute(2, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound80 = 1;
            A977FamDsc = T002B4_A977FamDsc[0];
            AssignAttri("", false, "A977FamDsc", A977FamDsc);
            A976FamAbr = T002B4_A976FamAbr[0];
            AssignAttri("", false, "A976FamAbr", A976FamAbr);
            A979FamSts = T002B4_A979FamSts[0];
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
            A40000FamFoto_GXI = T002B4_A40000FamFoto_GXI[0];
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            A978FamFoto = T002B4_A978FamFoto[0];
            AssignAttri("", false, "A978FamFoto", A978FamFoto);
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            ZM2B80( -1) ;
         }
         pr_default.close(2);
         OnLoadActions2B80( ) ;
      }

      protected void OnLoadActions2B80( )
      {
      }

      protected void CheckExtendedTable2B80( )
      {
         nIsDirty_80 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors2B80( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey2B80( )
      {
         /* Using cursor T002B5 */
         pr_default.execute(3, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound80 = 1;
         }
         else
         {
            RcdFound80 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002B3 */
         pr_default.execute(1, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2B80( 1) ;
            RcdFound80 = 1;
            A50FamCod = T002B3_A50FamCod[0];
            n50FamCod = T002B3_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            A977FamDsc = T002B3_A977FamDsc[0];
            AssignAttri("", false, "A977FamDsc", A977FamDsc);
            A976FamAbr = T002B3_A976FamAbr[0];
            AssignAttri("", false, "A976FamAbr", A976FamAbr);
            A979FamSts = T002B3_A979FamSts[0];
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
            A40000FamFoto_GXI = T002B3_A40000FamFoto_GXI[0];
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            A978FamFoto = T002B3_A978FamFoto[0];
            AssignAttri("", false, "A978FamFoto", A978FamFoto);
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            Z50FamCod = A50FamCod;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2B80( ) ;
            if ( AnyError == 1 )
            {
               RcdFound80 = 0;
               InitializeNonKey2B80( ) ;
            }
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound80 = 0;
            InitializeNonKey2B80( ) ;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2B80( ) ;
         if ( RcdFound80 == 0 )
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
         RcdFound80 = 0;
         /* Using cursor T002B6 */
         pr_default.execute(4, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T002B6_A50FamCod[0] < A50FamCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T002B6_A50FamCod[0] > A50FamCod ) ) )
            {
               A50FamCod = T002B6_A50FamCod[0];
               n50FamCod = T002B6_n50FamCod[0];
               AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               RcdFound80 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound80 = 0;
         /* Using cursor T002B7 */
         pr_default.execute(5, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T002B7_A50FamCod[0] > A50FamCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T002B7_A50FamCod[0] < A50FamCod ) ) )
            {
               A50FamCod = T002B7_A50FamCod[0];
               n50FamCod = T002B7_n50FamCod[0];
               AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               RcdFound80 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2B80( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFamCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2B80( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound80 == 1 )
            {
               if ( A50FamCod != Z50FamCod )
               {
                  A50FamCod = Z50FamCod;
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FAMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2B80( ) ;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A50FamCod != Z50FamCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2B80( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FAMCOD");
                     AnyError = 1;
                     GX_FocusControl = edtFamCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtFamCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2B80( ) ;
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
         if ( A50FamCod != Z50FamCod )
         {
            A50FamCod = Z50FamCod;
            n50FamCod = false;
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FAMCOD");
            AnyError = 1;
            GX_FocusControl = edtFamCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFamCod_Internalname;
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
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FAMCOD");
            AnyError = 1;
            GX_FocusControl = edtFamCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFamDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2B80( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFamDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2B80( ) ;
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
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFamDsc_Internalname;
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
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFamDsc_Internalname;
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
         ScanStart2B80( ) ;
         if ( RcdFound80 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound80 != 0 )
            {
               ScanNext2B80( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFamDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2B80( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2B80( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002B2 */
            pr_default.execute(0, new Object[] {n50FamCod, A50FamCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFAMILIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z977FamDsc, T002B2_A977FamDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z976FamAbr, T002B2_A976FamAbr[0]) != 0 ) || ( Z979FamSts != T002B2_A979FamSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z977FamDsc, T002B2_A977FamDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cfamilia:[seudo value changed for attri]"+"FamDsc");
                  GXUtil.WriteLogRaw("Old: ",Z977FamDsc);
                  GXUtil.WriteLogRaw("Current: ",T002B2_A977FamDsc[0]);
               }
               if ( StringUtil.StrCmp(Z976FamAbr, T002B2_A976FamAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cfamilia:[seudo value changed for attri]"+"FamAbr");
                  GXUtil.WriteLogRaw("Old: ",Z976FamAbr);
                  GXUtil.WriteLogRaw("Current: ",T002B2_A976FamAbr[0]);
               }
               if ( Z979FamSts != T002B2_A979FamSts[0] )
               {
                  GXUtil.WriteLog("cfamilia:[seudo value changed for attri]"+"FamSts");
                  GXUtil.WriteLogRaw("Old: ",Z979FamSts);
                  GXUtil.WriteLogRaw("Current: ",T002B2_A979FamSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CFAMILIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2B80( )
      {
         BeforeValidate2B80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2B80( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2B80( 0) ;
            CheckOptimisticConcurrency2B80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2B80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2B80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002B8 */
                     pr_default.execute(6, new Object[] {n50FamCod, A50FamCod, A977FamDsc, A976FamAbr, A979FamSts, A978FamFoto, A40000FamFoto_GXI});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
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
                           ResetCaption2B0( ) ;
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
               Load2B80( ) ;
            }
            EndLevel2B80( ) ;
         }
         CloseExtendedTableCursors2B80( ) ;
      }

      protected void Update2B80( )
      {
         BeforeValidate2B80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2B80( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2B80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2B80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2B80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002B9 */
                     pr_default.execute(7, new Object[] {A977FamDsc, A976FamAbr, A979FamSts, n50FamCod, A50FamCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFAMILIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2B80( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2B0( ) ;
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
            EndLevel2B80( ) ;
         }
         CloseExtendedTableCursors2B80( ) ;
      }

      protected void DeferredUpdate2B80( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T002B10 */
            pr_default.execute(8, new Object[] {A978FamFoto, A40000FamFoto_GXI, n50FamCod, A50FamCod});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2B80( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2B80( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2B80( ) ;
            AfterConfirm2B80( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2B80( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002B11 */
                  pr_default.execute(9, new Object[] {n50FamCod, A50FamCod});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound80 == 0 )
                        {
                           InitAll2B80( ) ;
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
                        ResetCaption2B0( ) ;
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
         sMode80 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2B80( ) ;
         Gx_mode = sMode80;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2B80( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T002B12 */
            pr_default.execute(10, new Object[] {n50FamCod, A50FamCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel2B80( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2B80( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cfamilia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cfamilia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2B80( )
      {
         /* Scan By routine */
         /* Using cursor T002B13 */
         pr_default.execute(11);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound80 = 1;
            A50FamCod = T002B13_A50FamCod[0];
            n50FamCod = T002B13_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2B80( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound80 = 1;
            A50FamCod = T002B13_A50FamCod[0];
            n50FamCod = T002B13_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         }
      }

      protected void ScanEnd2B80( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2B80( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2B80( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2B80( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2B80( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2B80( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2B80( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2B80( )
      {
         edtFamCod_Enabled = 0;
         AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
         edtFamDsc_Enabled = 0;
         AssignProp("", false, edtFamDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamDsc_Enabled), 5, 0), true);
         edtFamAbr_Enabled = 0;
         AssignProp("", false, edtFamAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamAbr_Enabled), 5, 0), true);
         cmbFamSts.Enabled = 0;
         AssignProp("", false, cmbFamSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFamSts.Enabled), 5, 0), true);
         imgFamFoto_Enabled = 0;
         AssignProp("", false, imgFamFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgFamFoto_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2B80( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2B0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816423020", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cfamilia.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z977FamDsc", StringUtil.RTrim( Z977FamDsc));
         GxWebStd.gx_hidden_field( context, "Z976FamAbr", StringUtil.RTrim( Z976FamAbr));
         GxWebStd.gx_hidden_field( context, "Z979FamSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z979FamSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "FAMFOTO_GXI", A40000FamFoto_GXI);
         GXCCtlgxBlob = "FAMFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A978FamFoto);
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
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
         return formatLink("cfamilia.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CFAMILIA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Familia" ;
      }

      protected void InitializeNonKey2B80( )
      {
         A977FamDsc = "";
         AssignAttri("", false, "A977FamDsc", A977FamDsc);
         A976FamAbr = "";
         AssignAttri("", false, "A976FamAbr", A976FamAbr);
         A979FamSts = 0;
         AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         A978FamFoto = "";
         AssignAttri("", false, "A978FamFoto", A978FamFoto);
         AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
         AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
         A40000FamFoto_GXI = "";
         AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
         AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
         Z977FamDsc = "";
         Z976FamAbr = "";
         Z979FamSts = 0;
      }

      protected void InitAll2B80( )
      {
         A50FamCod = 0;
         n50FamCod = false;
         AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         InitializeNonKey2B80( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816423041", true, true);
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
         context.AddJavascriptSource("cfamilia.js", "?202281816423042", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtFamCod_Internalname = "FAMCOD";
         edtFamDsc_Internalname = "FAMDSC";
         edtFamAbr_Internalname = "FAMABR";
         cmbFamSts_Internalname = "FAMSTS";
         imgFamFoto_Internalname = "FAMFOTO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
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
         Form.Caption = "Familia";
         bttBtntrn_delete_Enabled = 1;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         imgFamFoto_Enabled = 1;
         cmbFamSts_Jsonclick = "";
         cmbFamSts.Enabled = 1;
         edtFamAbr_Jsonclick = "";
         edtFamAbr_Enabled = 1;
         edtFamDsc_Jsonclick = "";
         edtFamDsc_Enabled = 1;
         edtFamCod_Jsonclick = "";
         edtFamCod_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Información General";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
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
         cmbFamSts.Name = "FAMSTS";
         cmbFamSts.WebTags = "";
         cmbFamSts.addItem("1", "ACTIVO", 0);
         cmbFamSts.addItem("0", "INACTIVO", 0);
         if ( cmbFamSts.ItemCount > 0 )
         {
            A979FamSts = (short)(NumberUtil.Val( cmbFamSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0))), "."));
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtFamDsc_Internalname;
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

      public void Valid_Famcod( )
      {
         A979FamSts = (short)(NumberUtil.Val( cmbFamSts.CurrentValue, "."));
         cmbFamSts.CurrentValue = StringUtil.Str( (decimal)(A979FamSts), 1, 0);
         n50FamCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbFamSts.ItemCount > 0 )
         {
            A979FamSts = (short)(NumberUtil.Val( cmbFamSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0))), "."));
            cmbFamSts.CurrentValue = StringUtil.Str( (decimal)(A979FamSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFamSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A977FamDsc", StringUtil.RTrim( A977FamDsc));
         AssignAttri("", false, "A976FamAbr", StringUtil.RTrim( A976FamAbr));
         AssignAttri("", false, "A979FamSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A979FamSts), 1, 0, ".", "")));
         cmbFamSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         AssignProp("", false, cmbFamSts_Internalname, "Values", cmbFamSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A978FamFoto", context.PathToRelativeUrl( A978FamFoto));
         GXCCtlgxBlob = "FAMFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A978FamFoto));
         AssignAttri("", false, "A40000FamFoto_GXI", A40000FamFoto_GXI);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z977FamDsc", StringUtil.RTrim( Z977FamDsc));
         GxWebStd.gx_hidden_field( context, "Z976FamAbr", StringUtil.RTrim( Z976FamAbr));
         GxWebStd.gx_hidden_field( context, "Z979FamSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z979FamSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z978FamFoto", context.PathToRelativeUrl( Z978FamFoto));
         GxWebStd.gx_hidden_field( context, "Z40000FamFoto_GXI", Z40000FamFoto_GXI);
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
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
         setEventMetadata("AFTER TRN","{handler:'E122B2',iparms:[]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_FAMCOD","{handler:'Valid_Famcod',iparms:[{av:'cmbFamSts'},{av:'A979FamSts',fld:'FAMSTS',pic:'9'},{av:'A50FamCod',fld:'FAMCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_FAMCOD",",oparms:[{av:'A977FamDsc',fld:'FAMDSC',pic:''},{av:'A976FamAbr',fld:'FAMABR',pic:''},{av:'cmbFamSts'},{av:'A979FamSts',fld:'FAMSTS',pic:'9'},{av:'A978FamFoto',fld:'FAMFOTO',pic:''},{av:'A40000FamFoto_GXI',fld:'FAMFOTO_GXI',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z50FamCod'},{av:'Z977FamDsc'},{av:'Z976FamAbr'},{av:'Z979FamSts'},{av:'Z978FamFoto'},{av:'Z40000FamFoto_GXI'},{ctrl:'BTNTRN_DELETE',prop:'Enabled'},{ctrl:'BTNTRN_ENTER',prop:'Enabled'}]}");
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
         Z977FamDsc = "";
         Z976FamAbr = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A977FamDsc = "";
         A976FamAbr = "";
         A978FamFoto = "";
         A40000FamFoto_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Gx_mode = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z978FamFoto = "";
         Z40000FamFoto_GXI = "";
         T002B4_A50FamCod = new int[1] ;
         T002B4_n50FamCod = new bool[] {false} ;
         T002B4_A977FamDsc = new string[] {""} ;
         T002B4_A976FamAbr = new string[] {""} ;
         T002B4_A979FamSts = new short[1] ;
         T002B4_A40000FamFoto_GXI = new string[] {""} ;
         T002B4_A978FamFoto = new string[] {""} ;
         T002B5_A50FamCod = new int[1] ;
         T002B5_n50FamCod = new bool[] {false} ;
         T002B3_A50FamCod = new int[1] ;
         T002B3_n50FamCod = new bool[] {false} ;
         T002B3_A977FamDsc = new string[] {""} ;
         T002B3_A976FamAbr = new string[] {""} ;
         T002B3_A979FamSts = new short[1] ;
         T002B3_A40000FamFoto_GXI = new string[] {""} ;
         T002B3_A978FamFoto = new string[] {""} ;
         sMode80 = "";
         T002B6_A50FamCod = new int[1] ;
         T002B6_n50FamCod = new bool[] {false} ;
         T002B7_A50FamCod = new int[1] ;
         T002B7_n50FamCod = new bool[] {false} ;
         T002B2_A50FamCod = new int[1] ;
         T002B2_n50FamCod = new bool[] {false} ;
         T002B2_A977FamDsc = new string[] {""} ;
         T002B2_A976FamAbr = new string[] {""} ;
         T002B2_A979FamSts = new short[1] ;
         T002B2_A40000FamFoto_GXI = new string[] {""} ;
         T002B2_A978FamFoto = new string[] {""} ;
         T002B12_A28ProdCod = new string[] {""} ;
         T002B13_A50FamCod = new int[1] ;
         T002B13_n50FamCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ977FamDsc = "";
         ZZ976FamAbr = "";
         ZZ978FamFoto = "";
         ZZ40000FamFoto_GXI = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cfamilia__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cfamilia__default(),
            new Object[][] {
                new Object[] {
               T002B2_A50FamCod, T002B2_A977FamDsc, T002B2_A976FamAbr, T002B2_A979FamSts, T002B2_A40000FamFoto_GXI, T002B2_A978FamFoto
               }
               , new Object[] {
               T002B3_A50FamCod, T002B3_A977FamDsc, T002B3_A976FamAbr, T002B3_A979FamSts, T002B3_A40000FamFoto_GXI, T002B3_A978FamFoto
               }
               , new Object[] {
               T002B4_A50FamCod, T002B4_A977FamDsc, T002B4_A976FamAbr, T002B4_A979FamSts, T002B4_A40000FamFoto_GXI, T002B4_A978FamFoto
               }
               , new Object[] {
               T002B5_A50FamCod
               }
               , new Object[] {
               T002B6_A50FamCod
               }
               , new Object[] {
               T002B7_A50FamCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002B12_A28ProdCod
               }
               , new Object[] {
               T002B13_A50FamCod
               }
            }
         );
      }

      private short Z979FamSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A979FamSts ;
      private short GX_JID ;
      private short RcdFound80 ;
      private short nIsDirty_80 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ979FamSts ;
      private int Z50FamCod ;
      private int trnEnded ;
      private int A50FamCod ;
      private int edtFamCod_Enabled ;
      private int edtFamDsc_Enabled ;
      private int edtFamAbr_Enabled ;
      private int imgFamFoto_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private int ZZ50FamCod ;
      private string sPrefix ;
      private string Z977FamDsc ;
      private string Z976FamAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFamCod_Internalname ;
      private string cmbFamSts_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtFamCod_Jsonclick ;
      private string edtFamDsc_Internalname ;
      private string A977FamDsc ;
      private string edtFamDsc_Jsonclick ;
      private string edtFamAbr_Internalname ;
      private string A976FamAbr ;
      private string edtFamAbr_Jsonclick ;
      private string cmbFamSts_Jsonclick ;
      private string imgFamFoto_Internalname ;
      private string sImgUrl ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Gx_mode ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode80 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ977FamDsc ;
      private string ZZ976FamAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A978FamFoto_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n50FamCod ;
      private bool returnInSub ;
      private string A40000FamFoto_GXI ;
      private string Z40000FamFoto_GXI ;
      private string ZZ40000FamFoto_GXI ;
      private string A978FamFoto ;
      private string Z978FamFoto ;
      private string ZZ978FamFoto ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFamSts ;
      private IDataStoreProvider pr_default ;
      private int[] T002B4_A50FamCod ;
      private bool[] T002B4_n50FamCod ;
      private string[] T002B4_A977FamDsc ;
      private string[] T002B4_A976FamAbr ;
      private short[] T002B4_A979FamSts ;
      private string[] T002B4_A40000FamFoto_GXI ;
      private string[] T002B4_A978FamFoto ;
      private int[] T002B5_A50FamCod ;
      private bool[] T002B5_n50FamCod ;
      private int[] T002B3_A50FamCod ;
      private bool[] T002B3_n50FamCod ;
      private string[] T002B3_A977FamDsc ;
      private string[] T002B3_A976FamAbr ;
      private short[] T002B3_A979FamSts ;
      private string[] T002B3_A40000FamFoto_GXI ;
      private string[] T002B3_A978FamFoto ;
      private int[] T002B6_A50FamCod ;
      private bool[] T002B6_n50FamCod ;
      private int[] T002B7_A50FamCod ;
      private bool[] T002B7_n50FamCod ;
      private int[] T002B2_A50FamCod ;
      private bool[] T002B2_n50FamCod ;
      private string[] T002B2_A977FamDsc ;
      private string[] T002B2_A976FamAbr ;
      private short[] T002B2_A979FamSts ;
      private string[] T002B2_A40000FamFoto_GXI ;
      private string[] T002B2_A978FamFoto ;
      private string[] T002B12_A28ProdCod ;
      private int[] T002B13_A50FamCod ;
      private bool[] T002B13_n50FamCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cfamilia__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cfamilia__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002B4;
        prmT002B4 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B5;
        prmT002B5 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B3;
        prmT002B3 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B6;
        prmT002B6 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B7;
        prmT002B7 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B2;
        prmT002B2 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B8;
        prmT002B8 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@FamDsc",GXType.NChar,100,0) ,
        new ParDef("@FamAbr",GXType.NChar,5,0) ,
        new ParDef("@FamSts",GXType.Int16,1,0) ,
        new ParDef("@FamFoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@FamFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="CFAMILIA", Fld="FamFoto"}
        };
        Object[] prmT002B9;
        prmT002B9 = new Object[] {
        new ParDef("@FamDsc",GXType.NChar,100,0) ,
        new ParDef("@FamAbr",GXType.NChar,5,0) ,
        new ParDef("@FamSts",GXType.Int16,1,0) ,
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B10;
        prmT002B10 = new Object[] {
        new ParDef("@FamFoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@FamFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="CFAMILIA", Fld="FamFoto"} ,
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B11;
        prmT002B11 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B12;
        prmT002B12 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT002B13;
        prmT002B13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T002B2", "SELECT [FamCod], [FamDsc], [FamAbr], [FamSts], [FamFoto_GXI], [FamFoto] FROM [CFAMILIA] WITH (UPDLOCK) WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002B3", "SELECT [FamCod], [FamDsc], [FamAbr], [FamSts], [FamFoto_GXI], [FamFoto] FROM [CFAMILIA] WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002B4", "SELECT TM1.[FamCod], TM1.[FamDsc], TM1.[FamAbr], TM1.[FamSts], TM1.[FamFoto_GXI], TM1.[FamFoto] FROM [CFAMILIA] TM1 WHERE TM1.[FamCod] = @FamCod ORDER BY TM1.[FamCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002B4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002B5", "SELECT [FamCod] FROM [CFAMILIA] WHERE [FamCod] = @FamCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002B6", "SELECT TOP 1 [FamCod] FROM [CFAMILIA] WHERE ( [FamCod] > @FamCod) ORDER BY [FamCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002B6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002B7", "SELECT TOP 1 [FamCod] FROM [CFAMILIA] WHERE ( [FamCod] < @FamCod) ORDER BY [FamCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002B7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002B8", "INSERT INTO [CFAMILIA]([FamCod], [FamDsc], [FamAbr], [FamSts], [FamFoto], [FamFoto_GXI]) VALUES(@FamCod, @FamDsc, @FamAbr, @FamSts, @FamFoto, @FamFoto_GXI)", GxErrorMask.GX_NOMASK,prmT002B8)
           ,new CursorDef("T002B9", "UPDATE [CFAMILIA] SET [FamDsc]=@FamDsc, [FamAbr]=@FamAbr, [FamSts]=@FamSts  WHERE [FamCod] = @FamCod", GxErrorMask.GX_NOMASK,prmT002B9)
           ,new CursorDef("T002B10", "UPDATE [CFAMILIA] SET [FamFoto]=@FamFoto, [FamFoto_GXI]=@FamFoto_GXI  WHERE [FamCod] = @FamCod", GxErrorMask.GX_NOMASK,prmT002B10)
           ,new CursorDef("T002B11", "DELETE FROM [CFAMILIA]  WHERE [FamCod] = @FamCod", GxErrorMask.GX_NOMASK,prmT002B11)
           ,new CursorDef("T002B12", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002B12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002B13", "SELECT [FamCod] FROM [CFAMILIA] ORDER BY [FamCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002B13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
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
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
