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
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuitem : GXDataArea
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
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxJX_Action41") == 0 )
         {
            A352MenuItemId = (short)(NumberUtil.Val( GetPar( "MenuItemId"), "."));
            AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            XC_41_0I19( A352MenuItemId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel5"+"_"+"MENUITEMID") == 0 )
         {
            AV7MenuItemId = (short)(NumberUtil.Val( GetPar( "MenuItemId"), "."));
            AssignAttri("", false, "AV7MenuItemId", StringUtil.LTrimStr( (decimal)(AV7MenuItemId), 4, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vMENUITEMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MenuItemId), "ZZZ9"), context));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX5ASAMENUITEMID0I19( AV7MenuItemId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel30"+"_"+"MENUITEMCAPTION") == 0 )
         {
            AV14MenuItemCaption = GetPar( "MenuItemCaption");
            AssignAttri("", false, "AV14MenuItemCaption", AV14MenuItemCaption);
            Gx_BScreen = (short)(NumberUtil.Val( GetPar( "Gx_BScreen"), "."));
            AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX30ASAMENUITEMCAPTION0I19( AV14MenuItemCaption, Gx_BScreen) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel31"+"_"+"MENUITEMCAPTION") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX31ASAMENUITEMCAPTION0I19( ) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_43") == 0 )
         {
            A353MenuItemFatherId = (short)(NumberUtil.Val( GetPar( "MenuItemFatherId"), "."));
            n353MenuItemFatherId = false;
            AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_43( A353MenuItemFatherId) ;
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.menuitem.aspx")), "wwpbaseobjects.menuitem.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.menuitem.aspx")))) ;
            }
            else
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
         }
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7MenuItemId = (short)(NumberUtil.Val( GetPar( "MenuItemId"), "."));
                  AssignAttri("", false, "AV7MenuItemId", StringUtil.LTrimStr( (decimal)(AV7MenuItemId), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMENUITEMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MenuItemId), "ZZZ9"), context));
                  AV13MenuItemFatherId = (short)(NumberUtil.Val( GetPar( "MenuItemFatherId"), "."));
                  AssignAttri("", false, "AV13MenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV13MenuItemFatherId), 4, 0));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
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
            Form.Meta.addItem("description", "Menu Item", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMenuItemOrder_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public menuitem( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuitem( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_MenuItemId ,
                           ref short aP2_MenuItemFatherId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MenuItemId = aP1_MenuItemId;
         this.AV13MenuItemFatherId = aP2_MenuItemFatherId;
         executePrivate();
         aP2_MenuItemFatherId=this.AV13MenuItemFatherId;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbMenuItemType = new GXCombobox();
         chkMenuItemLinkTarget = new GXCheckbox();
         chkMenuItemShowDeveloperMenuOptio = new GXCheckbox();
         chkMenuItemShowEditMenuOptions = new GXCheckbox();
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
         if ( cmbMenuItemType.ItemCount > 0 )
         {
            A1232MenuItemType = (short)(NumberUtil.Val( cmbMenuItemType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0))), "."));
            AssignAttri("", false, "A1232MenuItemType", StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbMenuItemType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
            AssignProp("", false, cmbMenuItemType_Internalname, "Values", cmbMenuItemType.ToJavascriptSource(), true);
         }
         A1228MenuItemLinkTarget = ((StringUtil.StrCmp(A1228MenuItemLinkTarget, "_blank")==0) ? "_blank" : "_");
         AssignAttri("", false, "A1228MenuItemLinkTarget", A1228MenuItemLinkTarget);
         A1230MenuItemShowDeveloperMenuOptio = StringUtil.StrToBool( StringUtil.BoolToStr( A1230MenuItemShowDeveloperMenuOptio));
         AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
         A1231MenuItemShowEditMenuOptions = StringUtil.StrToBool( StringUtil.BoolToStr( A1231MenuItemShowEditMenuOptions));
         AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-lg-6", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, divMenuitemid_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemid_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtMenuItemId_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuItemId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuItemId_Internalname, "Id", "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMenuItemId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A352MenuItemId), 4, 0, ".", "")), StringUtil.LTrim( ((edtMenuItemId_Enabled!=0) ? context.localUtil.Format( (decimal)(A352MenuItemId), "ZZZ9") : context.localUtil.Format( (decimal)(A352MenuItemId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuItemId_Jsonclick, 0, "Attribute", "", "", "", "", edtMenuItemId_Visible, edtMenuItemId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuItemOrder_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuItemOrder_Internalname, "Orden Menu", "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuItemOrder_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1229MenuItemOrder), 4, 0, ".", "")), StringUtil.LTrim( ((edtMenuItemOrder_Enabled!=0) ? context.localUtil.Format( (decimal)(A1229MenuItemOrder), "ZZZ9") : context.localUtil.Format( (decimal)(A1229MenuItemOrder), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuItemOrder_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuItemOrder_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divCombo_menuitemfatherid_cell_Internalname, 1, 0, "px", 0, "px", divCombo_menuitemfatherid_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedmenuitemfatherid_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-4 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockmenuitemfatherid_Internalname, "Inside Menu", "", "", lblTextblockmenuitemfatherid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-8", "left", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_menuitemfatherid.SetProperty("Caption", Combo_menuitemfatherid_Caption);
         ucCombo_menuitemfatherid.SetProperty("Cls", Combo_menuitemfatherid_Cls);
         ucCombo_menuitemfatherid.SetProperty("DataListProc", Combo_menuitemfatherid_Datalistproc);
         ucCombo_menuitemfatherid.SetProperty("DataListProcParametersPrefix", Combo_menuitemfatherid_Datalistprocparametersprefix);
         ucCombo_menuitemfatherid.SetProperty("DropDownOptionsTitleSettingsIcons", AV18DDO_TitleSettingsIcons);
         ucCombo_menuitemfatherid.SetProperty("DropDownOptionsData", AV17MenuItemFatherId_Data);
         ucCombo_menuitemfatherid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_menuitemfatherid_Internalname, "COMBO_MENUITEMFATHERIDContainer");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuItemFatherId_Internalname, "Inside Menu", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuItemFatherId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A353MenuItemFatherId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A353MenuItemFatherId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuItemFatherId_Jsonclick, 0, "Attribute", "", "", "", "", edtMenuItemFatherId_Visible, edtMenuItemFatherId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuItemCaption_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuItemCaption_Internalname, "Nombre Menu / Opción", "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuItemCaption_Internalname, A1222MenuItemCaption, StringUtil.RTrim( context.localUtil.Format( A1222MenuItemCaption, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuItemCaption_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMenuItemCaption_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMenuitemtype_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemtype_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", cmbMenuItemType.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbMenuItemType_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbMenuItemType_Internalname, "Type", "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbMenuItemType, cmbMenuItemType_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0)), 1, cmbMenuItemType_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbMenuItemType.Visible, cmbMenuItemType.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "", true, 1, "HLP_WWPBaseObjects\\MenuItem.htm");
         cmbMenuItemType.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
         AssignProp("", false, cmbMenuItemType_Internalname, "Values", (string)(cmbMenuItemType.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMenuitemiconclass_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemiconclass_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtMenuItemIconClass_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuItemIconClass_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuItemIconClass_Internalname, "Icon Class", "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuItemIconClass_Internalname, A1225MenuItemIconClass, StringUtil.RTrim( context.localUtil.Format( A1225MenuItemIconClass, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuItemIconClass_Jsonclick, 0, "Attribute", "", "", "", "", edtMenuItemIconClass_Visible, edtMenuItemIconClass_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMenuitemlink_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemlink_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtMenuItemLink_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuItemLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuItemLink_Internalname, "Link", "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuItemLink_Internalname, A1226MenuItemLink, StringUtil.RTrim( context.localUtil.Format( A1226MenuItemLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuItemLink_Jsonclick, 0, "Attribute", "", "", "", "", edtMenuItemLink_Visible, edtMenuItemLink_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMenuitemlinkparameters_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemlinkparameters_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", edtMenuItemLinkParameters_Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMenuItemLinkParameters_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMenuItemLinkParameters_Internalname, "Parameters", "col-sm-4 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-8 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMenuItemLinkParameters_Internalname, A1227MenuItemLinkParameters, StringUtil.RTrim( context.localUtil.Format( A1227MenuItemLinkParameters, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMenuItemLinkParameters_Jsonclick, 0, "Attribute", "", "", "", "", edtMenuItemLinkParameters_Visible, edtMenuItemLinkParameters_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMenuitemlinktarget_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemlinktarget_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", chkMenuItemLinkTarget.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkMenuItemLinkTarget_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkMenuItemLinkTarget_Internalname, " ", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkMenuItemLinkTarget_Internalname, A1228MenuItemLinkTarget, "", " ", chkMenuItemLinkTarget.Visible, chkMenuItemLinkTarget.Enabled, "_blank", "Open in new tab/window", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, '_blank', '_',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,68);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMenuitemshowdevelopermenuoption_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemshowdevelopermenuoption_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", chkMenuItemShowDeveloperMenuOptio.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkMenuItemShowDeveloperMenuOptio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkMenuItemShowDeveloperMenuOptio_Internalname, " ", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkMenuItemShowDeveloperMenuOptio_Internalname, StringUtil.BoolToStr( A1230MenuItemShowDeveloperMenuOptio), "", " ", chkMenuItemShowDeveloperMenuOptio.Visible, chkMenuItemShowDeveloperMenuOptio.Enabled, "true", "Mostrar menú de desarrollo", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(73, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,73);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMenuitemshoweditmenuoptions_cell_Internalname, 1, 0, "px", 0, "px", divMenuitemshoweditmenuoptions_cell_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", chkMenuItemShowEditMenuOptions.Visible, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkMenuItemShowEditMenuOptions_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkMenuItemShowEditMenuOptions_Internalname, " ", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkMenuItemShowEditMenuOptions_Internalname, StringUtil.BoolToStr( A1231MenuItemShowEditMenuOptions), "", " ", chkMenuItemShowEditMenuOptions.Visible, chkMenuItemShowEditMenuOptions.Enabled, "true", "Mostrar opción para editar menú", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(78, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,78);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 85,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\MenuItem.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_menuitemfatherid_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombomenuitemfatherid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ComboMenuItemFatherId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCombomenuitemfatherid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV22ComboMenuItemFatherId), "ZZZ9") : context.localUtil.Format( (decimal)(AV22ComboMenuItemFatherId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombomenuitemfatherid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombomenuitemfatherid_Visible, edtavCombomenuitemfatherid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_WWPBaseObjects\\MenuItem.htm");
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
         E110I2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV18DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vMENUITEMFATHERID_DATA"), AV17MenuItemFatherId_Data);
               /* Read saved values. */
               Z352MenuItemId = (short)(context.localUtil.CToN( cgiGet( "Z352MenuItemId"), ".", ","));
               Z1232MenuItemType = (short)(context.localUtil.CToN( cgiGet( "Z1232MenuItemType"), ".", ","));
               Z1222MenuItemCaption = cgiGet( "Z1222MenuItemCaption");
               Z1229MenuItemOrder = (short)(context.localUtil.CToN( cgiGet( "Z1229MenuItemOrder"), ".", ","));
               Z1226MenuItemLink = cgiGet( "Z1226MenuItemLink");
               Z1227MenuItemLinkParameters = cgiGet( "Z1227MenuItemLinkParameters");
               Z1228MenuItemLinkTarget = cgiGet( "Z1228MenuItemLinkTarget");
               Z1225MenuItemIconClass = cgiGet( "Z1225MenuItemIconClass");
               Z1230MenuItemShowDeveloperMenuOptio = StringUtil.StrToBool( cgiGet( "Z1230MenuItemShowDeveloperMenuOptio"));
               Z1231MenuItemShowEditMenuOptions = StringUtil.StrToBool( cgiGet( "Z1231MenuItemShowEditMenuOptions"));
               Z353MenuItemFatherId = (short)(context.localUtil.CToN( cgiGet( "Z353MenuItemFatherId"), ".", ","));
               n353MenuItemFatherId = ((0==A353MenuItemFatherId) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N353MenuItemFatherId = (short)(context.localUtil.CToN( cgiGet( "N353MenuItemFatherId"), ".", ","));
               n353MenuItemFatherId = ((0==A353MenuItemFatherId) ? true : false);
               AV7MenuItemId = (short)(context.localUtil.CToN( cgiGet( "vMENUITEMID"), ".", ","));
               AV11Insert_MenuItemFatherId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_MENUITEMFATHERID"), ".", ","));
               AV13MenuItemFatherId = (short)(context.localUtil.CToN( cgiGet( "vMENUITEMFATHERID"), ".", ","));
               AV14MenuItemCaption = cgiGet( "vMENUITEMCAPTION");
               AV15MenuItemIconClass = cgiGet( "vMENUITEMICONCLASS");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV16MenuItemShowDeveloperMenuOption = StringUtil.StrToBool( cgiGet( "vMENUITEMSHOWDEVELOPERMENUOPTION"));
               Gx_mode = cgiGet( "vMODE");
               A1223MenuItemFatherCaption = cgiGet( "MENUITEMFATHERCAPTION");
               A1224MenuItemFatherType = (short)(context.localUtil.CToN( cgiGet( "MENUITEMFATHERTYPE"), ".", ","));
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_menuitemfatherid_Objectcall = cgiGet( "COMBO_MENUITEMFATHERID_Objectcall");
               Combo_menuitemfatherid_Class = cgiGet( "COMBO_MENUITEMFATHERID_Class");
               Combo_menuitemfatherid_Icontype = cgiGet( "COMBO_MENUITEMFATHERID_Icontype");
               Combo_menuitemfatherid_Icon = cgiGet( "COMBO_MENUITEMFATHERID_Icon");
               Combo_menuitemfatherid_Caption = cgiGet( "COMBO_MENUITEMFATHERID_Caption");
               Combo_menuitemfatherid_Tooltip = cgiGet( "COMBO_MENUITEMFATHERID_Tooltip");
               Combo_menuitemfatherid_Cls = cgiGet( "COMBO_MENUITEMFATHERID_Cls");
               Combo_menuitemfatherid_Selectedvalue_set = cgiGet( "COMBO_MENUITEMFATHERID_Selectedvalue_set");
               Combo_menuitemfatherid_Selectedvalue_get = cgiGet( "COMBO_MENUITEMFATHERID_Selectedvalue_get");
               Combo_menuitemfatherid_Selectedtext_set = cgiGet( "COMBO_MENUITEMFATHERID_Selectedtext_set");
               Combo_menuitemfatherid_Selectedtext_get = cgiGet( "COMBO_MENUITEMFATHERID_Selectedtext_get");
               Combo_menuitemfatherid_Gamoauthtoken = cgiGet( "COMBO_MENUITEMFATHERID_Gamoauthtoken");
               Combo_menuitemfatherid_Ddointernalname = cgiGet( "COMBO_MENUITEMFATHERID_Ddointernalname");
               Combo_menuitemfatherid_Titlecontrolalign = cgiGet( "COMBO_MENUITEMFATHERID_Titlecontrolalign");
               Combo_menuitemfatherid_Dropdownoptionstype = cgiGet( "COMBO_MENUITEMFATHERID_Dropdownoptionstype");
               Combo_menuitemfatherid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Enabled"));
               Combo_menuitemfatherid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Visible"));
               Combo_menuitemfatherid_Titlecontrolidtoreplace = cgiGet( "COMBO_MENUITEMFATHERID_Titlecontrolidtoreplace");
               Combo_menuitemfatherid_Datalisttype = cgiGet( "COMBO_MENUITEMFATHERID_Datalisttype");
               Combo_menuitemfatherid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Allowmultipleselection"));
               Combo_menuitemfatherid_Datalistfixedvalues = cgiGet( "COMBO_MENUITEMFATHERID_Datalistfixedvalues");
               Combo_menuitemfatherid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Isgriditem"));
               Combo_menuitemfatherid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Hasdescription"));
               Combo_menuitemfatherid_Datalistproc = cgiGet( "COMBO_MENUITEMFATHERID_Datalistproc");
               Combo_menuitemfatherid_Datalistprocparametersprefix = cgiGet( "COMBO_MENUITEMFATHERID_Datalistprocparametersprefix");
               Combo_menuitemfatherid_Datalistupdateminimumcharacters = (int)(context.localUtil.CToN( cgiGet( "COMBO_MENUITEMFATHERID_Datalistupdateminimumcharacters"), ".", ","));
               Combo_menuitemfatherid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Includeonlyselectedoption"));
               Combo_menuitemfatherid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Includeselectalloption"));
               Combo_menuitemfatherid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Emptyitem"));
               Combo_menuitemfatherid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_MENUITEMFATHERID_Includeaddnewoption"));
               Combo_menuitemfatherid_Htmltemplate = cgiGet( "COMBO_MENUITEMFATHERID_Htmltemplate");
               Combo_menuitemfatherid_Multiplevaluestype = cgiGet( "COMBO_MENUITEMFATHERID_Multiplevaluestype");
               Combo_menuitemfatherid_Loadingdata = cgiGet( "COMBO_MENUITEMFATHERID_Loadingdata");
               Combo_menuitemfatherid_Noresultsfound = cgiGet( "COMBO_MENUITEMFATHERID_Noresultsfound");
               Combo_menuitemfatherid_Emptyitemtext = cgiGet( "COMBO_MENUITEMFATHERID_Emptyitemtext");
               Combo_menuitemfatherid_Onlyselectedvalues = cgiGet( "COMBO_MENUITEMFATHERID_Onlyselectedvalues");
               Combo_menuitemfatherid_Selectalltext = cgiGet( "COMBO_MENUITEMFATHERID_Selectalltext");
               Combo_menuitemfatherid_Multiplevaluesseparator = cgiGet( "COMBO_MENUITEMFATHERID_Multiplevaluesseparator");
               Combo_menuitemfatherid_Addnewoptiontext = cgiGet( "COMBO_MENUITEMFATHERID_Addnewoptiontext");
               Combo_menuitemfatherid_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "COMBO_MENUITEMFATHERID_Gxcontroltype"), ".", ","));
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
               A352MenuItemId = (short)(context.localUtil.CToN( cgiGet( edtMenuItemId_Internalname), ".", ","));
               AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtMenuItemOrder_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMenuItemOrder_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MENUITEMORDER");
                  AnyError = 1;
                  GX_FocusControl = edtMenuItemOrder_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1229MenuItemOrder = 0;
                  AssignAttri("", false, "A1229MenuItemOrder", StringUtil.LTrimStr( (decimal)(A1229MenuItemOrder), 4, 0));
               }
               else
               {
                  A1229MenuItemOrder = (short)(context.localUtil.CToN( cgiGet( edtMenuItemOrder_Internalname), ".", ","));
                  AssignAttri("", false, "A1229MenuItemOrder", StringUtil.LTrimStr( (decimal)(A1229MenuItemOrder), 4, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMenuItemFatherId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMenuItemFatherId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MENUITEMFATHERID");
                  AnyError = 1;
                  GX_FocusControl = edtMenuItemFatherId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A353MenuItemFatherId = 0;
                  n353MenuItemFatherId = false;
                  AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
               }
               else
               {
                  A353MenuItemFatherId = (short)(context.localUtil.CToN( cgiGet( edtMenuItemFatherId_Internalname), ".", ","));
                  n353MenuItemFatherId = false;
                  AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
               }
               n353MenuItemFatherId = ((0==A353MenuItemFatherId) ? true : false);
               A1222MenuItemCaption = cgiGet( edtMenuItemCaption_Internalname);
               AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
               cmbMenuItemType.CurrentValue = cgiGet( cmbMenuItemType_Internalname);
               A1232MenuItemType = (short)(NumberUtil.Val( cgiGet( cmbMenuItemType_Internalname), "."));
               AssignAttri("", false, "A1232MenuItemType", StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
               A1225MenuItemIconClass = cgiGet( edtMenuItemIconClass_Internalname);
               AssignAttri("", false, "A1225MenuItemIconClass", A1225MenuItemIconClass);
               A1226MenuItemLink = cgiGet( edtMenuItemLink_Internalname);
               AssignAttri("", false, "A1226MenuItemLink", A1226MenuItemLink);
               A1227MenuItemLinkParameters = cgiGet( edtMenuItemLinkParameters_Internalname);
               AssignAttri("", false, "A1227MenuItemLinkParameters", A1227MenuItemLinkParameters);
               A1228MenuItemLinkTarget = ((StringUtil.StrCmp(cgiGet( chkMenuItemLinkTarget_Internalname), "_blank")==0) ? "_blank" : "_");
               AssignAttri("", false, "A1228MenuItemLinkTarget", A1228MenuItemLinkTarget);
               A1230MenuItemShowDeveloperMenuOptio = StringUtil.StrToBool( cgiGet( chkMenuItemShowDeveloperMenuOptio_Internalname));
               AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
               A1231MenuItemShowEditMenuOptions = StringUtil.StrToBool( cgiGet( chkMenuItemShowEditMenuOptions_Internalname));
               AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
               AV22ComboMenuItemFatherId = (short)(context.localUtil.CToN( cgiGet( edtavCombomenuitemfatherid_Internalname), ".", ","));
               AssignAttri("", false, "AV22ComboMenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV22ComboMenuItemFatherId), 4, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"MenuItem");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A352MenuItemId != Z352MenuItemId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("wwpbaseobjects\\menuitem:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A352MenuItemId = (short)(NumberUtil.Val( GetPar( "MenuItemId"), "."));
                  AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode19 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode19;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound19 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0I0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MENUITEMID");
                        AnyError = 1;
                        GX_FocusControl = edtMenuItemId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
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
                           E110I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120I2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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
            E120I2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0I19( ) ;
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
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0I19( ) ;
         }
         AssignProp("", false, edtavCombomenuitemfatherid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomenuitemfatherid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I19( ) ;
            }
            else
            {
               CheckExtendedTable0I19( ) ;
               CloseExtendedTableCursors0I19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0I0( )
      {
      }

      protected void E110I2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV18DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV18DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         edtMenuItemFatherId_Visible = 0;
         AssignProp("", false, edtMenuItemFatherId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemFatherId_Visible), 5, 0), true);
         AV22ComboMenuItemFatherId = 0;
         AssignAttri("", false, "AV22ComboMenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV22ComboMenuItemFatherId), 4, 0));
         edtavCombomenuitemfatherid_Visible = 0;
         AssignProp("", false, edtavCombomenuitemfatherid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombomenuitemfatherid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOMENUITEMFATHERID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "MenuItemFatherId") == 0 )
               {
                  AV11Insert_MenuItemFatherId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_MenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV11Insert_MenuItemFatherId), 4, 0));
                  if ( ! (0==AV11Insert_MenuItemFatherId) )
                  {
                     AV22ComboMenuItemFatherId = AV11Insert_MenuItemFatherId;
                     AssignAttri("", false, "AV22ComboMenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV22ComboMenuItemFatherId), 4, 0));
                     Combo_menuitemfatherid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV22ComboMenuItemFatherId), 4, 0));
                     ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "SelectedValue_set", Combo_menuitemfatherid_Selectedvalue_set);
                     GXt_char2 = AV21Combo_DataJson;
                     new GeneXus.Programs.wwpbaseobjects.menuitemloaddvcombo(context ).execute(  "MenuItemFatherId",  "GET",  false,  AV7MenuItemId,  AV12TrnContextAtt.gxTpr_Attributevalue, out  AV19ComboSelectedValue, out  AV20ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV19ComboSelectedValue", AV19ComboSelectedValue);
                     AssignAttri("", false, "AV20ComboSelectedText", AV20ComboSelectedText);
                     AV21Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV21Combo_DataJson", AV21Combo_DataJson);
                     Combo_menuitemfatherid_Selectedtext_set = AV20ComboSelectedText;
                     ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "SelectedText_set", Combo_menuitemfatherid_Selectedtext_set);
                     Combo_menuitemfatherid_Enabled = false;
                     ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_menuitemfatherid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         if ( AV13MenuItemFatherId == 0 )
         {
            AV16MenuItemShowDeveloperMenuOption = true;
            AssignAttri("", false, "AV16MenuItemShowDeveloperMenuOption", AV16MenuItemShowDeveloperMenuOption);
         }
      }

      protected void E120I2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.setWebReturnParms(new Object[] {(short)AV13MenuItemFatherId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13MenuItemFatherId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV13MenuItemFatherId == 0 )
         {
            edtMenuItemId_Visible = 0;
            AssignProp("", false, edtMenuItemId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemId_Visible), 5, 0), true);
            divMenuitemid_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemid_cell_Internalname, "Class", divMenuitemid_cell_Class, true);
            Combo_menuitemfatherid_Visible = false;
            ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "Visible", StringUtil.BoolToStr( Combo_menuitemfatherid_Visible));
            divCombo_menuitemfatherid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_menuitemfatherid_cell_Internalname, "Class", divCombo_menuitemfatherid_cell_Class, true);
            cmbMenuItemType.Visible = 0;
            AssignProp("", false, cmbMenuItemType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMenuItemType.Visible), 5, 0), true);
            divMenuitemtype_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemtype_cell_Internalname, "Class", divMenuitemtype_cell_Class, true);
            edtMenuItemIconClass_Visible = 0;
            AssignProp("", false, edtMenuItemIconClass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemIconClass_Visible), 5, 0), true);
            divMenuitemiconclass_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemiconclass_cell_Internalname, "Class", divMenuitemiconclass_cell_Class, true);
            edtMenuItemLink_Visible = 0;
            AssignProp("", false, edtMenuItemLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLink_Visible), 5, 0), true);
            divMenuitemlink_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
            edtMenuItemLinkParameters_Visible = 0;
            AssignProp("", false, edtMenuItemLinkParameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLinkParameters_Visible), 5, 0), true);
            divMenuitemlinkparameters_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
            chkMenuItemLinkTarget.Visible = 0;
            AssignProp("", false, chkMenuItemLinkTarget_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemLinkTarget.Visible), 5, 0), true);
            divMenuitemlinktarget_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
            chkMenuItemShowDeveloperMenuOptio.Visible = 0;
            AssignProp("", false, chkMenuItemShowDeveloperMenuOptio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemShowDeveloperMenuOptio.Visible), 5, 0), true);
            divMenuitemshowdevelopermenuoption_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemshowdevelopermenuoption_cell_Internalname, "Class", divMenuitemshowdevelopermenuoption_cell_Class, true);
            chkMenuItemShowEditMenuOptions.Visible = 0;
            AssignProp("", false, chkMenuItemShowEditMenuOptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemShowEditMenuOptions.Visible), 5, 0), true);
            divMenuitemshoweditmenuoptions_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemshoweditmenuoptions_cell_Internalname, "Class", divMenuitemshoweditmenuoptions_cell_Class, true);
         }
      }

      protected void S112( )
      {
         /* 'LOADCOMBOMENUITEMFATHERID' Routine */
         returnInSub = false;
         GXt_char2 = AV21Combo_DataJson;
         new GeneXus.Programs.wwpbaseobjects.menuitemloaddvcombo(context ).execute(  "MenuItemFatherId",  Gx_mode,  false,  AV7MenuItemId,  "", out  AV19ComboSelectedValue, out  AV20ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV19ComboSelectedValue", AV19ComboSelectedValue);
         AssignAttri("", false, "AV20ComboSelectedText", AV20ComboSelectedText);
         AV21Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV21Combo_DataJson", AV21Combo_DataJson);
         Combo_menuitemfatherid_Selectedvalue_set = AV19ComboSelectedValue;
         ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "SelectedValue_set", Combo_menuitemfatherid_Selectedvalue_set);
         Combo_menuitemfatherid_Selectedtext_set = AV20ComboSelectedText;
         ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "SelectedText_set", Combo_menuitemfatherid_Selectedtext_set);
         AV22ComboMenuItemFatherId = (short)(NumberUtil.Val( AV19ComboSelectedValue, "."));
         AssignAttri("", false, "AV22ComboMenuItemFatherId", StringUtil.LTrimStr( (decimal)(AV22ComboMenuItemFatherId), 4, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_menuitemfatherid_Enabled = false;
            ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_menuitemfatherid_Enabled));
         }
      }

      protected void ZM0I19( short GX_JID )
      {
         if ( ( GX_JID == 42 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1232MenuItemType = T000I3_A1232MenuItemType[0];
               Z1222MenuItemCaption = T000I3_A1222MenuItemCaption[0];
               Z1229MenuItemOrder = T000I3_A1229MenuItemOrder[0];
               Z1226MenuItemLink = T000I3_A1226MenuItemLink[0];
               Z1227MenuItemLinkParameters = T000I3_A1227MenuItemLinkParameters[0];
               Z1228MenuItemLinkTarget = T000I3_A1228MenuItemLinkTarget[0];
               Z1225MenuItemIconClass = T000I3_A1225MenuItemIconClass[0];
               Z1230MenuItemShowDeveloperMenuOptio = T000I3_A1230MenuItemShowDeveloperMenuOptio[0];
               Z1231MenuItemShowEditMenuOptions = T000I3_A1231MenuItemShowEditMenuOptions[0];
               Z353MenuItemFatherId = T000I3_A353MenuItemFatherId[0];
            }
            else
            {
               Z1232MenuItemType = A1232MenuItemType;
               Z1222MenuItemCaption = A1222MenuItemCaption;
               Z1229MenuItemOrder = A1229MenuItemOrder;
               Z1226MenuItemLink = A1226MenuItemLink;
               Z1227MenuItemLinkParameters = A1227MenuItemLinkParameters;
               Z1228MenuItemLinkTarget = A1228MenuItemLinkTarget;
               Z1225MenuItemIconClass = A1225MenuItemIconClass;
               Z1230MenuItemShowDeveloperMenuOptio = A1230MenuItemShowDeveloperMenuOptio;
               Z1231MenuItemShowEditMenuOptions = A1231MenuItemShowEditMenuOptions;
               Z353MenuItemFatherId = A353MenuItemFatherId;
            }
         }
         if ( GX_JID == -42 )
         {
            Z352MenuItemId = A352MenuItemId;
            Z1232MenuItemType = A1232MenuItemType;
            Z1222MenuItemCaption = A1222MenuItemCaption;
            Z1229MenuItemOrder = A1229MenuItemOrder;
            Z1226MenuItemLink = A1226MenuItemLink;
            Z1227MenuItemLinkParameters = A1227MenuItemLinkParameters;
            Z1228MenuItemLinkTarget = A1228MenuItemLinkTarget;
            Z1225MenuItemIconClass = A1225MenuItemIconClass;
            Z1230MenuItemShowDeveloperMenuOptio = A1230MenuItemShowDeveloperMenuOptio;
            Z1231MenuItemShowEditMenuOptions = A1231MenuItemShowEditMenuOptions;
            Z353MenuItemFatherId = A353MenuItemFatherId;
            Z1223MenuItemFatherCaption = A1223MenuItemFatherCaption;
            Z1224MenuItemFatherType = A1224MenuItemFatherType;
         }
      }

      protected void standaloneNotModal( )
      {
         edtMenuItemId_Enabled = 0;
         AssignProp("", false, edtMenuItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemId_Enabled), 5, 0), true);
         AV25Pgmname = "WWPBaseObjects.MenuItem";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtMenuItemId_Enabled = 0;
         AssignProp("", false, edtMenuItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemId_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MenuItemId) )
         {
            A352MenuItemId = AV7MenuItemId;
            AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GXt_int3 = A352MenuItemId;
               new GeneXus.Programs.wwpbaseobjects.obtieneitemmenu(context ).execute( out  GXt_int3) ;
               A352MenuItemId = GXt_int3;
               AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
            }
         }
         edtMenuItemId_Visible = ((AV13MenuItemFatherId>0) ? 1 : 0);
         AssignProp("", false, edtMenuItemId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemId_Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId > 0 ) ) )
         {
            divMenuitemid_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemid_cell_Internalname, "Class", divMenuitemid_cell_Class, true);
         }
         else
         {
            if ( AV13MenuItemFatherId > 0 )
            {
               divMenuitemid_cell_Class = "col-xs-12 RequiredDataContentCell";
               AssignProp("", false, divMenuitemid_cell_Internalname, "Class", divMenuitemid_cell_Class, true);
            }
         }
         Combo_menuitemfatherid_Visible = (bool)((AV13MenuItemFatherId>0));
         ucCombo_menuitemfatherid.SendProperty(context, "", false, Combo_menuitemfatherid_Internalname, "Visible", StringUtil.BoolToStr( Combo_menuitemfatherid_Visible));
         if ( ! ( ( AV13MenuItemFatherId > 0 ) ) )
         {
            divCombo_menuitemfatherid_cell_Class = "Invisible";
            AssignProp("", false, divCombo_menuitemfatherid_cell_Internalname, "Class", divCombo_menuitemfatherid_cell_Class, true);
         }
         else
         {
            if ( AV13MenuItemFatherId > 0 )
            {
               divCombo_menuitemfatherid_cell_Class = "col-xs-12 DataContentCell ExtendedComboCell";
               AssignProp("", false, divCombo_menuitemfatherid_cell_Internalname, "Class", divCombo_menuitemfatherid_cell_Class, true);
            }
         }
         cmbMenuItemType.Visible = ((AV13MenuItemFatherId>0) ? 1 : 0);
         AssignProp("", false, cmbMenuItemType_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbMenuItemType.Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId > 0 ) ) )
         {
            divMenuitemtype_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemtype_cell_Internalname, "Class", divMenuitemtype_cell_Class, true);
         }
         else
         {
            if ( AV13MenuItemFatherId > 0 )
            {
               divMenuitemtype_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemtype_cell_Internalname, "Class", divMenuitemtype_cell_Class, true);
            }
         }
         edtMenuItemIconClass_Visible = ((AV13MenuItemFatherId>0) ? 1 : 0);
         AssignProp("", false, edtMenuItemIconClass_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemIconClass_Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId > 0 ) ) )
         {
            divMenuitemiconclass_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemiconclass_cell_Internalname, "Class", divMenuitemiconclass_cell_Class, true);
         }
         else
         {
            if ( AV13MenuItemFatherId > 0 )
            {
               divMenuitemiconclass_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemiconclass_cell_Internalname, "Class", divMenuitemiconclass_cell_Class, true);
            }
         }
         chkMenuItemShowDeveloperMenuOptio.Visible = ((AV13MenuItemFatherId==0) ? 1 : 0);
         AssignProp("", false, chkMenuItemShowDeveloperMenuOptio_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemShowDeveloperMenuOptio.Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId == 0 ) ) )
         {
            divMenuitemshowdevelopermenuoption_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemshowdevelopermenuoption_cell_Internalname, "Class", divMenuitemshowdevelopermenuoption_cell_Class, true);
         }
         else
         {
            if ( AV13MenuItemFatherId == 0 )
            {
               divMenuitemshowdevelopermenuoption_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemshowdevelopermenuoption_cell_Internalname, "Class", divMenuitemshowdevelopermenuoption_cell_Class, true);
            }
         }
         chkMenuItemShowEditMenuOptions.Visible = ((AV13MenuItemFatherId==0) ? 1 : 0);
         AssignProp("", false, chkMenuItemShowEditMenuOptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemShowEditMenuOptions.Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId == 0 ) ) )
         {
            divMenuitemshoweditmenuoptions_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemshoweditmenuoptions_cell_Internalname, "Class", divMenuitemshoweditmenuoptions_cell_Class, true);
         }
         else
         {
            if ( AV13MenuItemFatherId == 0 )
            {
               divMenuitemshoweditmenuoptions_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemshoweditmenuoptions_cell_Internalname, "Class", divMenuitemshoweditmenuoptions_cell_Class, true);
            }
         }
         if ( AV13MenuItemFatherId == 0 )
         {
            AV14MenuItemCaption = "MainMenu";
            AssignAttri("", false, "AV14MenuItemCaption", AV14MenuItemCaption);
         }
         if ( AV13MenuItemFatherId > 0 )
         {
            AV15MenuItemIconClass = "HorizontalMenuIcon fa fa-asterisk";
            AssignAttri("", false, "AV15MenuItemIconClass", AV15MenuItemIconClass);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_MenuItemFatherId) )
         {
            edtMenuItemFatherId_Enabled = 0;
            AssignProp("", false, edtMenuItemFatherId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemFatherId_Enabled), 5, 0), true);
         }
         else
         {
            if ( ( AV13MenuItemFatherId > 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
            {
               edtMenuItemFatherId_Enabled = 0;
               AssignProp("", false, edtMenuItemFatherId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemFatherId_Enabled), 5, 0), true);
            }
            else
            {
               edtMenuItemFatherId_Enabled = 1;
               AssignProp("", false, edtMenuItemFatherId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemFatherId_Enabled), 5, 0), true);
            }
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_MenuItemFatherId) )
         {
            A353MenuItemFatherId = AV11Insert_MenuItemFatherId;
            n353MenuItemFatherId = false;
            AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
         }
         else
         {
            if ( (0==AV22ComboMenuItemFatherId) )
            {
               A353MenuItemFatherId = 0;
               n353MenuItemFatherId = false;
               AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
               n353MenuItemFatherId = true;
               AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
            }
            else
            {
               if ( ! (0==AV22ComboMenuItemFatherId) )
               {
                  A353MenuItemFatherId = AV22ComboMenuItemFatherId;
                  n353MenuItemFatherId = false;
                  AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
               }
               else
               {
                  if ( ( AV13MenuItemFatherId > 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
                  {
                     A353MenuItemFatherId = AV13MenuItemFatherId;
                     n353MenuItemFatherId = false;
                     AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
                  }
               }
            }
         }
         if ( AV13MenuItemFatherId == 0 )
         {
            A1232MenuItemType = 2;
            AssignAttri("", false, "A1232MenuItemType", StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
         }
         if ( ( AV13MenuItemFatherId > 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            edtMenuItemFatherId_Enabled = 0;
            AssignProp("", false, edtMenuItemFatherId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemFatherId_Enabled), 5, 0), true);
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
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A1222MenuItemCaption)) && ( Gx_BScreen == 0 ) )
         {
            A1222MenuItemCaption = AV14MenuItemCaption;
            AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
         }
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A1225MenuItemIconClass)) && ( Gx_BScreen == 0 ) )
         {
            A1225MenuItemIconClass = AV15MenuItemIconClass;
            AssignAttri("", false, "A1225MenuItemIconClass", A1225MenuItemIconClass);
         }
         if ( IsIns( )  && (false==A1230MenuItemShowDeveloperMenuOptio) && ( Gx_BScreen == 0 ) )
         {
            A1230MenuItemShowDeveloperMenuOptio = AV16MenuItemShowDeveloperMenuOption;
            AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
         }
         if ( IsIns( )  && (false==A1231MenuItemShowEditMenuOptions) && ( Gx_BScreen == 0 ) )
         {
            A1231MenuItemShowEditMenuOptions = AV16MenuItemShowDeveloperMenuOption;
            AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000I4 */
            pr_default.execute(2, new Object[] {n353MenuItemFatherId, A353MenuItemFatherId});
            A1223MenuItemFatherCaption = T000I4_A1223MenuItemFatherCaption[0];
            A1224MenuItemFatherType = T000I4_A1224MenuItemFatherType[0];
            pr_default.close(2);
            chkMenuItemLinkTarget.Visible = ((A1232MenuItemType==1) ? 1 : 0);
            AssignProp("", false, chkMenuItemLinkTarget_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemLinkTarget.Visible), 5, 0), true);
            if ( ! ( ( A1232MenuItemType == 1 ) ) )
            {
               divMenuitemlinktarget_cell_Class = "Invisible";
               AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
            }
            else
            {
               if ( A1232MenuItemType == 1 )
               {
                  divMenuitemlinktarget_cell_Class = "col-xs-12 DataContentCell";
                  AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
               }
            }
            edtMenuItemLink_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
            AssignProp("", false, edtMenuItemLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLink_Visible), 5, 0), true);
            if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
            {
               divMenuitemlink_cell_Class = "Invisible";
               AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
            }
            else
            {
               if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
               {
                  divMenuitemlink_cell_Class = "col-xs-12 DataContentCell";
                  AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
               }
            }
            edtMenuItemLinkParameters_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
            AssignProp("", false, edtMenuItemLinkParameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLinkParameters_Visible), 5, 0), true);
            if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
            {
               divMenuitemlinkparameters_cell_Class = "Invisible";
               AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
            }
            else
            {
               if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
               {
                  divMenuitemlinkparameters_cell_Class = "col-xs-12 DataContentCell";
                  AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
               }
            }
         }
      }

      protected void Load0I19( )
      {
         /* Using cursor T000I5 */
         pr_default.execute(3, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
            A1232MenuItemType = T000I5_A1232MenuItemType[0];
            AssignAttri("", false, "A1232MenuItemType", StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
            A1222MenuItemCaption = T000I5_A1222MenuItemCaption[0];
            AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
            A1229MenuItemOrder = T000I5_A1229MenuItemOrder[0];
            AssignAttri("", false, "A1229MenuItemOrder", StringUtil.LTrimStr( (decimal)(A1229MenuItemOrder), 4, 0));
            A1223MenuItemFatherCaption = T000I5_A1223MenuItemFatherCaption[0];
            A1224MenuItemFatherType = T000I5_A1224MenuItemFatherType[0];
            A1226MenuItemLink = T000I5_A1226MenuItemLink[0];
            AssignAttri("", false, "A1226MenuItemLink", A1226MenuItemLink);
            A1227MenuItemLinkParameters = T000I5_A1227MenuItemLinkParameters[0];
            AssignAttri("", false, "A1227MenuItemLinkParameters", A1227MenuItemLinkParameters);
            A1228MenuItemLinkTarget = T000I5_A1228MenuItemLinkTarget[0];
            AssignAttri("", false, "A1228MenuItemLinkTarget", A1228MenuItemLinkTarget);
            A1225MenuItemIconClass = T000I5_A1225MenuItemIconClass[0];
            AssignAttri("", false, "A1225MenuItemIconClass", A1225MenuItemIconClass);
            A1230MenuItemShowDeveloperMenuOptio = T000I5_A1230MenuItemShowDeveloperMenuOptio[0];
            AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
            A1231MenuItemShowEditMenuOptions = T000I5_A1231MenuItemShowEditMenuOptions[0];
            AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
            A353MenuItemFatherId = T000I5_A353MenuItemFatherId[0];
            n353MenuItemFatherId = T000I5_n353MenuItemFatherId[0];
            AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
            ZM0I19( -42) ;
         }
         pr_default.close(3);
         OnLoadActions0I19( ) ;
      }

      protected void OnLoadActions0I19( )
      {
         edtMenuItemLink_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
         AssignProp("", false, edtMenuItemLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLink_Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
         {
            divMenuitemlink_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
         }
         else
         {
            if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
            {
               divMenuitemlink_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
            }
         }
         edtMenuItemLinkParameters_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
         AssignProp("", false, edtMenuItemLinkParameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLinkParameters_Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
         {
            divMenuitemlinkparameters_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
         }
         else
         {
            if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
            {
               divMenuitemlinkparameters_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
            }
         }
         chkMenuItemLinkTarget.Visible = ((A1232MenuItemType==1) ? 1 : 0);
         AssignProp("", false, chkMenuItemLinkTarget_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemLinkTarget.Visible), 5, 0), true);
         if ( ! ( ( A1232MenuItemType == 1 ) ) )
         {
            divMenuitemlinktarget_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
         }
         else
         {
            if ( A1232MenuItemType == 1 )
            {
               divMenuitemlinktarget_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
            }
         }
      }

      protected void CheckExtendedTable0I19( )
      {
         nIsDirty_19 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         edtMenuItemLink_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
         AssignProp("", false, edtMenuItemLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLink_Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
         {
            divMenuitemlink_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
         }
         else
         {
            if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
            {
               divMenuitemlink_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
            }
         }
         edtMenuItemLinkParameters_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
         AssignProp("", false, edtMenuItemLinkParameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLinkParameters_Visible), 5, 0), true);
         if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
         {
            divMenuitemlinkparameters_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
         }
         else
         {
            if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
            {
               divMenuitemlinkparameters_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
            }
         }
         if ( (0==A352MenuItemId) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Id", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1222MenuItemCaption)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Caption", "", "", "", "", "", "", "", ""), 1, "MENUITEMCAPTION");
            AnyError = 1;
            GX_FocusControl = edtMenuItemCaption_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ( new GeneXus.Programs.wwpbaseobjects.getamountofmainmenus(context).executeUdp(  A1222MenuItemCaption) > 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            GX_msglist.addItem("Ya existe", 1, "MENUITEMCAPTION");
            AnyError = 1;
            GX_FocusControl = edtMenuItemCaption_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (0==A1229MenuItemOrder) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Menu Item Order", "", "", "", "", "", "", "", ""), 1, "MENUITEMORDER");
            AnyError = 1;
            GX_FocusControl = edtMenuItemOrder_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000I4 */
         pr_default.execute(2, new Object[] {n353MenuItemFatherId, A353MenuItemFatherId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A353MenuItemFatherId) ) )
            {
               GX_msglist.addItem("No existe 'Menu Item Father'.", "ForeignKeyNotFound", 1, "MENUITEMFATHERID");
               AnyError = 1;
               GX_FocusControl = edtMenuItemFatherId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1223MenuItemFatherCaption = T000I4_A1223MenuItemFatherCaption[0];
         A1224MenuItemFatherType = T000I4_A1224MenuItemFatherType[0];
         pr_default.close(2);
         if ( ! ( ( A1232MenuItemType == 1 ) || ( A1232MenuItemType == 2 ) ) )
         {
            GX_msglist.addItem("Campo Type fuera de rango", "OutOfRange", 1, "MENUITEMTYPE");
            AnyError = 1;
            GX_FocusControl = cmbMenuItemType_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         chkMenuItemLinkTarget.Visible = ((A1232MenuItemType==1) ? 1 : 0);
         AssignProp("", false, chkMenuItemLinkTarget_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemLinkTarget.Visible), 5, 0), true);
         if ( ! ( ( A1232MenuItemType == 1 ) ) )
         {
            divMenuitemlinktarget_cell_Class = "Invisible";
            AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
         }
         else
         {
            if ( A1232MenuItemType == 1 )
            {
               divMenuitemlinktarget_cell_Class = "col-xs-12 DataContentCell";
               AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
            }
         }
      }

      protected void CloseExtendedTableCursors0I19( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_43( short A353MenuItemFatherId )
      {
         /* Using cursor T000I6 */
         pr_default.execute(4, new Object[] {n353MenuItemFatherId, A353MenuItemFatherId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A353MenuItemFatherId) ) )
            {
               GX_msglist.addItem("No existe 'Menu Item Father'.", "ForeignKeyNotFound", 1, "MENUITEMFATHERID");
               AnyError = 1;
               GX_FocusControl = edtMenuItemFatherId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1223MenuItemFatherCaption = T000I6_A1223MenuItemFatherCaption[0];
         A1224MenuItemFatherType = T000I6_A1224MenuItemFatherType[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1223MenuItemFatherCaption)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1224MenuItemFatherType), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey0I19( )
      {
         /* Using cursor T000I7 */
         pr_default.execute(5, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000I3 */
         pr_default.execute(1, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I19( 42) ;
            RcdFound19 = 1;
            A352MenuItemId = T000I3_A352MenuItemId[0];
            AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
            A1232MenuItemType = T000I3_A1232MenuItemType[0];
            AssignAttri("", false, "A1232MenuItemType", StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
            A1222MenuItemCaption = T000I3_A1222MenuItemCaption[0];
            AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
            A1229MenuItemOrder = T000I3_A1229MenuItemOrder[0];
            AssignAttri("", false, "A1229MenuItemOrder", StringUtil.LTrimStr( (decimal)(A1229MenuItemOrder), 4, 0));
            A1226MenuItemLink = T000I3_A1226MenuItemLink[0];
            AssignAttri("", false, "A1226MenuItemLink", A1226MenuItemLink);
            A1227MenuItemLinkParameters = T000I3_A1227MenuItemLinkParameters[0];
            AssignAttri("", false, "A1227MenuItemLinkParameters", A1227MenuItemLinkParameters);
            A1228MenuItemLinkTarget = T000I3_A1228MenuItemLinkTarget[0];
            AssignAttri("", false, "A1228MenuItemLinkTarget", A1228MenuItemLinkTarget);
            A1225MenuItemIconClass = T000I3_A1225MenuItemIconClass[0];
            AssignAttri("", false, "A1225MenuItemIconClass", A1225MenuItemIconClass);
            A1230MenuItemShowDeveloperMenuOptio = T000I3_A1230MenuItemShowDeveloperMenuOptio[0];
            AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
            A1231MenuItemShowEditMenuOptions = T000I3_A1231MenuItemShowEditMenuOptions[0];
            AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
            A353MenuItemFatherId = T000I3_A353MenuItemFatherId[0];
            n353MenuItemFatherId = T000I3_n353MenuItemFatherId[0];
            AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
            Z352MenuItemId = A352MenuItemId;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0I19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0I19( ) ;
            }
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0I19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode19;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I19( ) ;
         if ( RcdFound19 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound19 = 0;
         /* Using cursor T000I8 */
         pr_default.execute(6, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000I8_A352MenuItemId[0] < A352MenuItemId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000I8_A352MenuItemId[0] > A352MenuItemId ) ) )
            {
               A352MenuItemId = T000I8_A352MenuItemId[0];
               AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound19 = 0;
         /* Using cursor T000I9 */
         pr_default.execute(7, new Object[] {A352MenuItemId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T000I9_A352MenuItemId[0] > A352MenuItemId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T000I9_A352MenuItemId[0] < A352MenuItemId ) ) )
            {
               A352MenuItemId = T000I9_A352MenuItemId[0];
               AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
               RcdFound19 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0I19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMenuItemOrder_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0I19( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( A352MenuItemId != Z352MenuItemId )
               {
                  A352MenuItemId = Z352MenuItemId;
                  AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MENUITEMID");
                  AnyError = 1;
                  GX_FocusControl = edtMenuItemId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMenuItemOrder_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0I19( ) ;
                  GX_FocusControl = edtMenuItemOrder_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A352MenuItemId != Z352MenuItemId )
               {
                  /* Insert record */
                  GX_FocusControl = edtMenuItemOrder_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0I19( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MENUITEMID");
                     AnyError = 1;
                     GX_FocusControl = edtMenuItemId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMenuItemOrder_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0I19( ) ;
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
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A352MenuItemId != Z352MenuItemId )
         {
            A352MenuItemId = Z352MenuItemId;
            AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MENUITEMID");
            AnyError = 1;
            GX_FocusControl = edtMenuItemId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMenuItemOrder_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0I19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000I2 */
            pr_default.execute(0, new Object[] {A352MenuItemId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SIGERPMenu"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1232MenuItemType != T000I2_A1232MenuItemType[0] ) || ( StringUtil.StrCmp(Z1222MenuItemCaption, T000I2_A1222MenuItemCaption[0]) != 0 ) || ( Z1229MenuItemOrder != T000I2_A1229MenuItemOrder[0] ) || ( StringUtil.StrCmp(Z1226MenuItemLink, T000I2_A1226MenuItemLink[0]) != 0 ) || ( StringUtil.StrCmp(Z1227MenuItemLinkParameters, T000I2_A1227MenuItemLinkParameters[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1228MenuItemLinkTarget, T000I2_A1228MenuItemLinkTarget[0]) != 0 ) || ( StringUtil.StrCmp(Z1225MenuItemIconClass, T000I2_A1225MenuItemIconClass[0]) != 0 ) || ( Z1230MenuItemShowDeveloperMenuOptio != T000I2_A1230MenuItemShowDeveloperMenuOptio[0] ) || ( Z1231MenuItemShowEditMenuOptions != T000I2_A1231MenuItemShowEditMenuOptions[0] ) || ( Z353MenuItemFatherId != T000I2_A353MenuItemFatherId[0] ) )
            {
               if ( Z1232MenuItemType != T000I2_A1232MenuItemType[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemType");
                  GXUtil.WriteLogRaw("Old: ",Z1232MenuItemType);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1232MenuItemType[0]);
               }
               if ( StringUtil.StrCmp(Z1222MenuItemCaption, T000I2_A1222MenuItemCaption[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemCaption");
                  GXUtil.WriteLogRaw("Old: ",Z1222MenuItemCaption);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1222MenuItemCaption[0]);
               }
               if ( Z1229MenuItemOrder != T000I2_A1229MenuItemOrder[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemOrder");
                  GXUtil.WriteLogRaw("Old: ",Z1229MenuItemOrder);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1229MenuItemOrder[0]);
               }
               if ( StringUtil.StrCmp(Z1226MenuItemLink, T000I2_A1226MenuItemLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemLink");
                  GXUtil.WriteLogRaw("Old: ",Z1226MenuItemLink);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1226MenuItemLink[0]);
               }
               if ( StringUtil.StrCmp(Z1227MenuItemLinkParameters, T000I2_A1227MenuItemLinkParameters[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemLinkParameters");
                  GXUtil.WriteLogRaw("Old: ",Z1227MenuItemLinkParameters);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1227MenuItemLinkParameters[0]);
               }
               if ( StringUtil.StrCmp(Z1228MenuItemLinkTarget, T000I2_A1228MenuItemLinkTarget[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemLinkTarget");
                  GXUtil.WriteLogRaw("Old: ",Z1228MenuItemLinkTarget);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1228MenuItemLinkTarget[0]);
               }
               if ( StringUtil.StrCmp(Z1225MenuItemIconClass, T000I2_A1225MenuItemIconClass[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemIconClass");
                  GXUtil.WriteLogRaw("Old: ",Z1225MenuItemIconClass);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1225MenuItemIconClass[0]);
               }
               if ( Z1230MenuItemShowDeveloperMenuOptio != T000I2_A1230MenuItemShowDeveloperMenuOptio[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemShowDeveloperMenuOptio");
                  GXUtil.WriteLogRaw("Old: ",Z1230MenuItemShowDeveloperMenuOptio);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1230MenuItemShowDeveloperMenuOptio[0]);
               }
               if ( Z1231MenuItemShowEditMenuOptions != T000I2_A1231MenuItemShowEditMenuOptions[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemShowEditMenuOptions");
                  GXUtil.WriteLogRaw("Old: ",Z1231MenuItemShowEditMenuOptions);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A1231MenuItemShowEditMenuOptions[0]);
               }
               if ( Z353MenuItemFatherId != T000I2_A353MenuItemFatherId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.menuitem:[seudo value changed for attri]"+"MenuItemFatherId");
                  GXUtil.WriteLogRaw("Old: ",Z353MenuItemFatherId);
                  GXUtil.WriteLogRaw("Current: ",T000I2_A353MenuItemFatherId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SIGERPMenu"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I19( 0) ;
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I10 */
                     pr_default.execute(8, new Object[] {A352MenuItemId, A1232MenuItemType, A1222MenuItemCaption, A1229MenuItemOrder, A1226MenuItemLink, A1227MenuItemLinkParameters, A1228MenuItemLinkTarget, A1225MenuItemIconClass, A1230MenuItemShowDeveloperMenuOptio, A1231MenuItemShowEditMenuOptions, n353MenuItemFatherId, A353MenuItemFatherId});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("SIGERPMenu");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        new GeneXus.Programs.wwpbaseobjects.updatemenuitemorder(context ).execute( ref  A352MenuItemId) ;
                        AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0I0( ) ;
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
               Load0I19( ) ;
            }
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void Update0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000I11 */
                     pr_default.execute(9, new Object[] {A1232MenuItemType, A1222MenuItemCaption, A1229MenuItemOrder, A1226MenuItemLink, A1227MenuItemLinkParameters, A1228MenuItemLinkTarget, A1225MenuItemIconClass, A1230MenuItemShowDeveloperMenuOptio, A1231MenuItemShowEditMenuOptions, n353MenuItemFatherId, A353MenuItemFatherId, A352MenuItemId});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("SIGERPMenu");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SIGERPMenu"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I19( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
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
            }
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void DeferredUpdate0I19( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I19( ) ;
            AfterConfirm0I19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000I12 */
                  pr_default.execute(10, new Object[] {A352MenuItemId});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("SIGERPMenu");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
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
         }
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0I19( ) ;
         Gx_mode = sMode19;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0I19( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000I13 */
            pr_default.execute(11, new Object[] {n353MenuItemFatherId, A353MenuItemFatherId});
            A1223MenuItemFatherCaption = T000I13_A1223MenuItemFatherCaption[0];
            A1224MenuItemFatherType = T000I13_A1224MenuItemFatherType[0];
            pr_default.close(11);
            edtMenuItemLink_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
            AssignProp("", false, edtMenuItemLink_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLink_Visible), 5, 0), true);
            if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
            {
               divMenuitemlink_cell_Class = "Invisible";
               AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
            }
            else
            {
               if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
               {
                  divMenuitemlink_cell_Class = "col-xs-12 DataContentCell";
                  AssignProp("", false, divMenuitemlink_cell_Internalname, "Class", divMenuitemlink_cell_Class, true);
               }
            }
            edtMenuItemLinkParameters_Visible = ((AV13MenuItemFatherId>0)&&(A1232MenuItemType==1) ? 1 : 0);
            AssignProp("", false, edtMenuItemLinkParameters_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMenuItemLinkParameters_Visible), 5, 0), true);
            if ( ! ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) ) )
            {
               divMenuitemlinkparameters_cell_Class = "Invisible";
               AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
            }
            else
            {
               if ( ( AV13MenuItemFatherId > 0 ) && ( A1232MenuItemType == 1 ) )
               {
                  divMenuitemlinkparameters_cell_Class = "col-xs-12 DataContentCell";
                  AssignProp("", false, divMenuitemlinkparameters_cell_Internalname, "Class", divMenuitemlinkparameters_cell_Class, true);
               }
            }
            chkMenuItemLinkTarget.Visible = ((A1232MenuItemType==1) ? 1 : 0);
            AssignProp("", false, chkMenuItemLinkTarget_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkMenuItemLinkTarget.Visible), 5, 0), true);
            if ( ! ( ( A1232MenuItemType == 1 ) ) )
            {
               divMenuitemlinktarget_cell_Class = "Invisible";
               AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
            }
            else
            {
               if ( A1232MenuItemType == 1 )
               {
                  divMenuitemlinktarget_cell_Class = "col-xs-12 DataContentCell";
                  AssignProp("", false, divMenuitemlinktarget_cell_Internalname, "Class", divMenuitemlinktarget_cell_Class, true);
               }
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000I14 */
            pr_default.execute(12, new Object[] {A352MenuItemId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item de Menú"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0I19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(11);
            context.CommitDataStores("wwpbaseobjects.menuitem",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0I0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(11);
            context.RollbackDataStores("wwpbaseobjects.menuitem",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0I19( )
      {
         /* Scan By routine */
         /* Using cursor T000I15 */
         pr_default.execute(13);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound19 = 1;
            A352MenuItemId = T000I15_A352MenuItemId[0];
            AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0I19( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound19 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound19 = 1;
            A352MenuItemId = T000I15_A352MenuItemId[0];
            AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
         }
      }

      protected void ScanEnd0I19( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0I19( )
      {
         /* After Confirm Rules */
         if ( (0==A353MenuItemFatherId) )
         {
            A353MenuItemFatherId = 0;
            n353MenuItemFatherId = false;
            AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
            n353MenuItemFatherId = true;
            AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
         }
      }

      protected void BeforeInsert0I19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I19( )
      {
         /* Before Validate Rules */
         GXt_int3 = 0;
         new GeneXus.Programs.wwpbaseobjects.getamountofmainmenus(context ).execute(  "MainMenu", out  GXt_int3) ;
         if ( GXt_int3 == 0 )
         {
            A1222MenuItemCaption = "MainMenu";
            AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
         }
      }

      protected void DisableAttributes0I19( )
      {
         edtMenuItemId_Enabled = 0;
         AssignProp("", false, edtMenuItemId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemId_Enabled), 5, 0), true);
         edtMenuItemOrder_Enabled = 0;
         AssignProp("", false, edtMenuItemOrder_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemOrder_Enabled), 5, 0), true);
         edtMenuItemFatherId_Enabled = 0;
         AssignProp("", false, edtMenuItemFatherId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemFatherId_Enabled), 5, 0), true);
         edtMenuItemCaption_Enabled = 0;
         AssignProp("", false, edtMenuItemCaption_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemCaption_Enabled), 5, 0), true);
         cmbMenuItemType.Enabled = 0;
         AssignProp("", false, cmbMenuItemType_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbMenuItemType.Enabled), 5, 0), true);
         edtMenuItemIconClass_Enabled = 0;
         AssignProp("", false, edtMenuItemIconClass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemIconClass_Enabled), 5, 0), true);
         edtMenuItemLink_Enabled = 0;
         AssignProp("", false, edtMenuItemLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemLink_Enabled), 5, 0), true);
         edtMenuItemLinkParameters_Enabled = 0;
         AssignProp("", false, edtMenuItemLinkParameters_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMenuItemLinkParameters_Enabled), 5, 0), true);
         chkMenuItemLinkTarget.Enabled = 0;
         AssignProp("", false, chkMenuItemLinkTarget_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkMenuItemLinkTarget.Enabled), 5, 0), true);
         chkMenuItemShowDeveloperMenuOptio.Enabled = 0;
         AssignProp("", false, chkMenuItemShowDeveloperMenuOptio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkMenuItemShowDeveloperMenuOptio.Enabled), 5, 0), true);
         chkMenuItemShowEditMenuOptions.Enabled = 0;
         AssignProp("", false, chkMenuItemShowEditMenuOptions_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkMenuItemShowEditMenuOptions.Enabled), 5, 0), true);
         edtavCombomenuitemfatherid_Enabled = 0;
         AssignProp("", false, edtavCombomenuitemfatherid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombomenuitemfatherid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0I19( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0I0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816422919", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.menuitem.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MenuItemId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13MenuItemFatherId,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.menuitem.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"MenuItem");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("wwpbaseobjects\\menuitem:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z352MenuItemId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z352MenuItemId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1232MenuItemType", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1232MenuItemType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1222MenuItemCaption", Z1222MenuItemCaption);
         GxWebStd.gx_hidden_field( context, "Z1229MenuItemOrder", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1229MenuItemOrder), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1226MenuItemLink", Z1226MenuItemLink);
         GxWebStd.gx_hidden_field( context, "Z1227MenuItemLinkParameters", Z1227MenuItemLinkParameters);
         GxWebStd.gx_hidden_field( context, "Z1228MenuItemLinkTarget", Z1228MenuItemLinkTarget);
         GxWebStd.gx_hidden_field( context, "Z1225MenuItemIconClass", Z1225MenuItemIconClass);
         GxWebStd.gx_boolean_hidden_field( context, "Z1230MenuItemShowDeveloperMenuOptio", Z1230MenuItemShowDeveloperMenuOptio);
         GxWebStd.gx_boolean_hidden_field( context, "Z1231MenuItemShowEditMenuOptions", Z1231MenuItemShowEditMenuOptions);
         GxWebStd.gx_hidden_field( context, "Z353MenuItemFatherId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z353MenuItemFatherId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N353MenuItemFatherId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A353MenuItemFatherId), 4, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV18DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMENUITEMFATHERID_DATA", AV17MenuItemFatherId_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMENUITEMFATHERID_DATA", AV17MenuItemFatherId_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMENUITEMID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MenuItemId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMENUITEMID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MenuItemId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_MENUITEMFATHERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_MenuItemFatherId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMENUITEMFATHERID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13MenuItemFatherId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMENUITEMCAPTION", AV14MenuItemCaption);
         GxWebStd.gx_hidden_field( context, "vMENUITEMICONCLASS", AV15MenuItemIconClass);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vMENUITEMSHOWDEVELOPERMENUOPTION", AV16MenuItemShowDeveloperMenuOption);
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "MENUITEMFATHERCAPTION", A1223MenuItemFatherCaption);
         GxWebStd.gx_hidden_field( context, "MENUITEMFATHERTYPE", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1224MenuItemFatherType), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Objectcall", StringUtil.RTrim( Combo_menuitemfatherid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Cls", StringUtil.RTrim( Combo_menuitemfatherid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Selectedvalue_set", StringUtil.RTrim( Combo_menuitemfatherid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Selectedtext_set", StringUtil.RTrim( Combo_menuitemfatherid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Enabled", StringUtil.BoolToStr( Combo_menuitemfatherid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Visible", StringUtil.BoolToStr( Combo_menuitemfatherid_Visible));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Datalistproc", StringUtil.RTrim( Combo_menuitemfatherid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_MENUITEMFATHERID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_menuitemfatherid_Datalistprocparametersprefix));
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "wwpbaseobjects.menuitem.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MenuItemId,4,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV13MenuItemFatherId,4,0));
         return formatLink("wwpbaseobjects.menuitem.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.MenuItem" ;
      }

      public override string GetPgmdesc( )
      {
         return "Menu Item" ;
      }

      protected void InitializeNonKey0I19( )
      {
         A353MenuItemFatherId = 0;
         n353MenuItemFatherId = false;
         AssignAttri("", false, "A353MenuItemFatherId", StringUtil.LTrimStr( (decimal)(A353MenuItemFatherId), 4, 0));
         n353MenuItemFatherId = ((0==A353MenuItemFatherId) ? true : false);
         A1232MenuItemType = 0;
         AssignAttri("", false, "A1232MenuItemType", StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
         A1229MenuItemOrder = 0;
         AssignAttri("", false, "A1229MenuItemOrder", StringUtil.LTrimStr( (decimal)(A1229MenuItemOrder), 4, 0));
         A1223MenuItemFatherCaption = "";
         AssignAttri("", false, "A1223MenuItemFatherCaption", A1223MenuItemFatherCaption);
         A1224MenuItemFatherType = 0;
         AssignAttri("", false, "A1224MenuItemFatherType", StringUtil.Str( (decimal)(A1224MenuItemFatherType), 1, 0));
         A1226MenuItemLink = "";
         AssignAttri("", false, "A1226MenuItemLink", A1226MenuItemLink);
         A1227MenuItemLinkParameters = "";
         AssignAttri("", false, "A1227MenuItemLinkParameters", A1227MenuItemLinkParameters);
         A1228MenuItemLinkTarget = "";
         AssignAttri("", false, "A1228MenuItemLinkTarget", A1228MenuItemLinkTarget);
         A1222MenuItemCaption = AV14MenuItemCaption;
         AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
         A1225MenuItemIconClass = AV15MenuItemIconClass;
         AssignAttri("", false, "A1225MenuItemIconClass", A1225MenuItemIconClass);
         A1230MenuItemShowDeveloperMenuOptio = AV16MenuItemShowDeveloperMenuOption;
         AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
         A1231MenuItemShowEditMenuOptions = AV16MenuItemShowDeveloperMenuOption;
         AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
         Z1232MenuItemType = 0;
         Z1222MenuItemCaption = "";
         Z1229MenuItemOrder = 0;
         Z1226MenuItemLink = "";
         Z1227MenuItemLinkParameters = "";
         Z1228MenuItemLinkTarget = "";
         Z1225MenuItemIconClass = "";
         Z1230MenuItemShowDeveloperMenuOptio = false;
         Z1231MenuItemShowEditMenuOptions = false;
         Z353MenuItemFatherId = 0;
      }

      protected void InitAll0I19( )
      {
         A352MenuItemId = 0;
         AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
         InitializeNonKey0I19( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1222MenuItemCaption = i1222MenuItemCaption;
         AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
         A1225MenuItemIconClass = i1225MenuItemIconClass;
         AssignAttri("", false, "A1225MenuItemIconClass", A1225MenuItemIconClass);
         A1230MenuItemShowDeveloperMenuOptio = i1230MenuItemShowDeveloperMenuOptio;
         AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
         A1231MenuItemShowEditMenuOptions = i1231MenuItemShowEditMenuOptions;
         AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816422982", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/menuitem.js", "?202281816422983", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMenuItemId_Internalname = "MENUITEMID";
         divMenuitemid_cell_Internalname = "MENUITEMID_CELL";
         edtMenuItemOrder_Internalname = "MENUITEMORDER";
         lblTextblockmenuitemfatherid_Internalname = "TEXTBLOCKMENUITEMFATHERID";
         Combo_menuitemfatherid_Internalname = "COMBO_MENUITEMFATHERID";
         edtMenuItemFatherId_Internalname = "MENUITEMFATHERID";
         divTablesplittedmenuitemfatherid_Internalname = "TABLESPLITTEDMENUITEMFATHERID";
         divCombo_menuitemfatherid_cell_Internalname = "COMBO_MENUITEMFATHERID_CELL";
         edtMenuItemCaption_Internalname = "MENUITEMCAPTION";
         cmbMenuItemType_Internalname = "MENUITEMTYPE";
         divMenuitemtype_cell_Internalname = "MENUITEMTYPE_CELL";
         edtMenuItemIconClass_Internalname = "MENUITEMICONCLASS";
         divMenuitemiconclass_cell_Internalname = "MENUITEMICONCLASS_CELL";
         edtMenuItemLink_Internalname = "MENUITEMLINK";
         divMenuitemlink_cell_Internalname = "MENUITEMLINK_CELL";
         edtMenuItemLinkParameters_Internalname = "MENUITEMLINKPARAMETERS";
         divMenuitemlinkparameters_cell_Internalname = "MENUITEMLINKPARAMETERS_CELL";
         chkMenuItemLinkTarget_Internalname = "MENUITEMLINKTARGET";
         divMenuitemlinktarget_cell_Internalname = "MENUITEMLINKTARGET_CELL";
         chkMenuItemShowDeveloperMenuOptio_Internalname = "MENUITEMSHOWDEVELOPERMENUOPTIO";
         divMenuitemshowdevelopermenuoption_cell_Internalname = "MENUITEMSHOWDEVELOPERMENUOPTION_CELL";
         chkMenuItemShowEditMenuOptions_Internalname = "MENUITEMSHOWEDITMENUOPTIONS";
         divMenuitemshoweditmenuoptions_cell_Internalname = "MENUITEMSHOWEDITMENUOPTIONS_CELL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombomenuitemfatherid_Internalname = "vCOMBOMENUITEMFATHERID";
         divSectionattribute_menuitemfatherid_Internalname = "SECTIONATTRIBUTE_MENUITEMFATHERID";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Caption = "Menu Item";
         Combo_menuitemfatherid_Visible = Convert.ToBoolean( -1);
         edtavCombomenuitemfatherid_Jsonclick = "";
         edtavCombomenuitemfatherid_Enabled = 0;
         edtavCombomenuitemfatherid_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         chkMenuItemShowEditMenuOptions.Enabled = 1;
         chkMenuItemShowEditMenuOptions.Visible = 1;
         divMenuitemshoweditmenuoptions_cell_Class = "col-xs-12";
         chkMenuItemShowDeveloperMenuOptio.Enabled = 1;
         chkMenuItemShowDeveloperMenuOptio.Visible = 1;
         divMenuitemshowdevelopermenuoption_cell_Class = "col-xs-12";
         chkMenuItemLinkTarget.Enabled = 1;
         chkMenuItemLinkTarget.Visible = 1;
         divMenuitemlinktarget_cell_Class = "col-xs-12";
         edtMenuItemLinkParameters_Jsonclick = "";
         edtMenuItemLinkParameters_Enabled = 1;
         edtMenuItemLinkParameters_Visible = 1;
         divMenuitemlinkparameters_cell_Class = "col-xs-12";
         edtMenuItemLink_Jsonclick = "";
         edtMenuItemLink_Enabled = 1;
         edtMenuItemLink_Visible = 1;
         divMenuitemlink_cell_Class = "col-xs-12";
         edtMenuItemIconClass_Jsonclick = "";
         edtMenuItemIconClass_Enabled = 1;
         edtMenuItemIconClass_Visible = 1;
         divMenuitemiconclass_cell_Class = "col-xs-12";
         cmbMenuItemType_Jsonclick = "";
         cmbMenuItemType.Enabled = 1;
         cmbMenuItemType.Visible = 1;
         divMenuitemtype_cell_Class = "col-xs-12";
         edtMenuItemCaption_Jsonclick = "";
         edtMenuItemCaption_Enabled = 1;
         edtMenuItemFatherId_Jsonclick = "";
         edtMenuItemFatherId_Enabled = 1;
         edtMenuItemFatherId_Visible = 1;
         Combo_menuitemfatherid_Datalistprocparametersprefix = " \"ComboName\": \"MenuItemFatherId\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"MenuItemId\": 0";
         Combo_menuitemfatherid_Datalistproc = "WWPBaseObjects.MenuItemLoadDVCombo";
         Combo_menuitemfatherid_Cls = "ExtendedCombo Attribute";
         Combo_menuitemfatherid_Caption = "";
         Combo_menuitemfatherid_Enabled = Convert.ToBoolean( -1);
         divCombo_menuitemfatherid_cell_Class = "col-xs-12";
         edtMenuItemOrder_Jsonclick = "";
         edtMenuItemOrder_Enabled = 1;
         edtMenuItemId_Jsonclick = "";
         edtMenuItemId_Enabled = 0;
         edtMenuItemId_Visible = 1;
         divMenuitemid_cell_Class = "col-xs-12";
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "General Information";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
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

      protected void GX5ASAMENUITEMID0I19( short AV7MenuItemId )
      {
         if ( ! (0==AV7MenuItemId) )
         {
            A352MenuItemId = AV7MenuItemId;
            AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
         }
         else
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               GXt_int3 = A352MenuItemId;
               new GeneXus.Programs.wwpbaseobjects.obtieneitemmenu(context ).execute( out  GXt_int3) ;
               A352MenuItemId = GXt_int3;
               AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A352MenuItemId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX30ASAMENUITEMCAPTION0I19( string AV14MenuItemCaption ,
                                                 short Gx_BScreen )
      {
         if ( IsIns( )  && String.IsNullOrEmpty(StringUtil.RTrim( A1222MenuItemCaption)) && ( Gx_BScreen == 0 ) )
         {
            A1222MenuItemCaption = AV14MenuItemCaption;
            AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1222MenuItemCaption)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void GX31ASAMENUITEMCAPTION0I19( )
      {
         GXt_int3 = 0;
         new GeneXus.Programs.wwpbaseobjects.getamountofmainmenus(context ).execute(  "MainMenu", out  GXt_int3) ;
         if ( GXt_int3 == 0 )
         {
            A1222MenuItemCaption = "MainMenu";
            AssignAttri("", false, "A1222MenuItemCaption", A1222MenuItemCaption);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A1222MenuItemCaption)+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_41_0I19( short A352MenuItemId )
      {
         new GeneXus.Programs.wwpbaseobjects.updatemenuitemorder(context ).execute( ref  A352MenuItemId) ;
         AssignAttri("", false, "A352MenuItemId", StringUtil.LTrimStr( (decimal)(A352MenuItemId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A352MenuItemId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbMenuItemType.Name = "MENUITEMTYPE";
         cmbMenuItemType.WebTags = "";
         cmbMenuItemType.addItem("1", "Link Item", 0);
         cmbMenuItemType.addItem("2", "Menu", 0);
         if ( cmbMenuItemType.ItemCount > 0 )
         {
            A1232MenuItemType = (short)(NumberUtil.Val( cmbMenuItemType.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0))), "."));
            AssignAttri("", false, "A1232MenuItemType", StringUtil.Str( (decimal)(A1232MenuItemType), 1, 0));
         }
         chkMenuItemLinkTarget.Name = "MENUITEMLINKTARGET";
         chkMenuItemLinkTarget.WebTags = "";
         chkMenuItemLinkTarget.Caption = "Open in new tab/window";
         AssignProp("", false, chkMenuItemLinkTarget_Internalname, "TitleCaption", chkMenuItemLinkTarget.Caption, true);
         chkMenuItemLinkTarget.CheckedValue = "_";
         A1228MenuItemLinkTarget = ((StringUtil.StrCmp(A1228MenuItemLinkTarget, "_blank")==0) ? "_blank" : "_");
         AssignAttri("", false, "A1228MenuItemLinkTarget", A1228MenuItemLinkTarget);
         chkMenuItemShowDeveloperMenuOptio.Name = "MENUITEMSHOWDEVELOPERMENUOPTIO";
         chkMenuItemShowDeveloperMenuOptio.WebTags = "";
         chkMenuItemShowDeveloperMenuOptio.Caption = "Mostrar menú de desarrollo";
         AssignProp("", false, chkMenuItemShowDeveloperMenuOptio_Internalname, "TitleCaption", chkMenuItemShowDeveloperMenuOptio.Caption, true);
         chkMenuItemShowDeveloperMenuOptio.CheckedValue = "false";
         if ( (false==A1230MenuItemShowDeveloperMenuOptio) )
         {
            A1230MenuItemShowDeveloperMenuOptio = AV16MenuItemShowDeveloperMenuOption;
            AssignAttri("", false, "A1230MenuItemShowDeveloperMenuOptio", A1230MenuItemShowDeveloperMenuOptio);
         }
         chkMenuItemShowEditMenuOptions.Name = "MENUITEMSHOWEDITMENUOPTIONS";
         chkMenuItemShowEditMenuOptions.WebTags = "";
         chkMenuItemShowEditMenuOptions.Caption = "Mostrar opción para editar menú";
         AssignProp("", false, chkMenuItemShowEditMenuOptions_Internalname, "TitleCaption", chkMenuItemShowEditMenuOptions.Caption, true);
         chkMenuItemShowEditMenuOptions.CheckedValue = "false";
         if ( (false==A1231MenuItemShowEditMenuOptions) )
         {
            A1231MenuItemShowEditMenuOptions = AV16MenuItemShowDeveloperMenuOption;
            AssignAttri("", false, "A1231MenuItemShowEditMenuOptions", A1231MenuItemShowEditMenuOptions);
         }
         /* End function init_web_controls */
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

      public void Valid_Menuitemfatherid( )
      {
         n353MenuItemFatherId = false;
         /* Using cursor T000I13 */
         pr_default.execute(11, new Object[] {n353MenuItemFatherId, A353MenuItemFatherId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A353MenuItemFatherId) ) )
            {
               GX_msglist.addItem("No existe 'Menu Item Father'.", "ForeignKeyNotFound", 1, "MENUITEMFATHERID");
               AnyError = 1;
               GX_FocusControl = edtMenuItemFatherId_Internalname;
            }
         }
         A1223MenuItemFatherCaption = T000I13_A1223MenuItemFatherCaption[0];
         A1224MenuItemFatherType = T000I13_A1224MenuItemFatherType[0];
         pr_default.close(11);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1223MenuItemFatherCaption", A1223MenuItemFatherCaption);
         AssignAttri("", false, "A1224MenuItemFatherType", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1224MenuItemFatherType), 1, 0, ".", "")));
      }

      public void Valid_Menuitemcaption( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1222MenuItemCaption)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Caption", "", "", "", "", "", "", "", ""), 1, "MENUITEMCAPTION");
            AnyError = 1;
            GX_FocusControl = edtMenuItemCaption_Internalname;
         }
         if ( ( new GeneXus.Programs.wwpbaseobjects.getamountofmainmenus(context).executeUdp(  A1222MenuItemCaption) > 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            GX_msglist.addItem("Ya existe", 1, "MENUITEMCAPTION");
            AnyError = 1;
            GX_FocusControl = edtMenuItemCaption_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MenuItemId',fld:'vMENUITEMID',pic:'ZZZ9',hsh:true},{av:'AV13MenuItemFatherId',fld:'vMENUITEMFATHERID',pic:'ZZZ9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MenuItemId',fld:'vMENUITEMID',pic:'ZZZ9',hsh:true},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120I2',iparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("VALID_MENUITEMID","{handler:'Valid_Menuitemid',iparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("VALID_MENUITEMID",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("VALID_MENUITEMORDER","{handler:'Valid_Menuitemorder',iparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("VALID_MENUITEMORDER",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("VALID_MENUITEMFATHERID","{handler:'Valid_Menuitemfatherid',iparms:[{av:'A353MenuItemFatherId',fld:'MENUITEMFATHERID',pic:'ZZZ9'},{av:'A1223MenuItemFatherCaption',fld:'MENUITEMFATHERCAPTION',pic:''},{av:'A1224MenuItemFatherType',fld:'MENUITEMFATHERTYPE',pic:'9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("VALID_MENUITEMFATHERID",",oparms:[{av:'A1223MenuItemFatherCaption',fld:'MENUITEMFATHERCAPTION',pic:''},{av:'A1224MenuItemFatherType',fld:'MENUITEMFATHERTYPE',pic:'9'},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("VALID_MENUITEMCAPTION","{handler:'Valid_Menuitemcaption',iparms:[{av:'A1222MenuItemCaption',fld:'MENUITEMCAPTION',pic:''},{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("VALID_MENUITEMCAPTION",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("VALID_MENUITEMTYPE","{handler:'Valid_Menuitemtype',iparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("VALID_MENUITEMTYPE",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
         setEventMetadata("VALIDV_COMBOMENUITEMFATHERID","{handler:'Validv_Combomenuitemfatherid',iparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]");
         setEventMetadata("VALIDV_COMBOMENUITEMFATHERID",",oparms:[{av:'A1228MenuItemLinkTarget',fld:'MENUITEMLINKTARGET',pic:''},{av:'A1230MenuItemShowDeveloperMenuOptio',fld:'MENUITEMSHOWDEVELOPERMENUOPTIO',pic:''},{av:'A1231MenuItemShowEditMenuOptions',fld:'MENUITEMSHOWEDITMENUOPTIONS',pic:''}]}");
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
         pr_default.close(11);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z1222MenuItemCaption = "";
         Z1226MenuItemLink = "";
         Z1227MenuItemLinkParameters = "";
         Z1228MenuItemLinkTarget = "";
         Z1225MenuItemIconClass = "";
         Combo_menuitemfatherid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV14MenuItemCaption = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1228MenuItemLinkTarget = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         lblTextblockmenuitemfatherid_Jsonclick = "";
         ucCombo_menuitemfatherid = new GXUserControl();
         AV18DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV17MenuItemFatherId_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A1222MenuItemCaption = "";
         A1225MenuItemIconClass = "";
         A1226MenuItemLink = "";
         A1227MenuItemLinkParameters = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         AV15MenuItemIconClass = "";
         A1223MenuItemFatherCaption = "";
         AV25Pgmname = "";
         Combo_menuitemfatherid_Objectcall = "";
         Combo_menuitemfatherid_Class = "";
         Combo_menuitemfatherid_Icontype = "";
         Combo_menuitemfatherid_Icon = "";
         Combo_menuitemfatherid_Tooltip = "";
         Combo_menuitemfatherid_Selectedvalue_set = "";
         Combo_menuitemfatherid_Selectedtext_set = "";
         Combo_menuitemfatherid_Selectedtext_get = "";
         Combo_menuitemfatherid_Gamoauthtoken = "";
         Combo_menuitemfatherid_Ddointernalname = "";
         Combo_menuitemfatherid_Titlecontrolalign = "";
         Combo_menuitemfatherid_Dropdownoptionstype = "";
         Combo_menuitemfatherid_Titlecontrolidtoreplace = "";
         Combo_menuitemfatherid_Datalisttype = "";
         Combo_menuitemfatherid_Datalistfixedvalues = "";
         Combo_menuitemfatherid_Htmltemplate = "";
         Combo_menuitemfatherid_Multiplevaluestype = "";
         Combo_menuitemfatherid_Loadingdata = "";
         Combo_menuitemfatherid_Noresultsfound = "";
         Combo_menuitemfatherid_Emptyitemtext = "";
         Combo_menuitemfatherid_Onlyselectedvalues = "";
         Combo_menuitemfatherid_Selectalltext = "";
         Combo_menuitemfatherid_Multiplevaluesseparator = "";
         Combo_menuitemfatherid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode19 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV21Combo_DataJson = "";
         AV19ComboSelectedValue = "";
         AV20ComboSelectedText = "";
         GXt_char2 = "";
         Z1223MenuItemFatherCaption = "";
         T000I4_A1223MenuItemFatherCaption = new string[] {""} ;
         T000I4_A1224MenuItemFatherType = new short[1] ;
         T000I5_A352MenuItemId = new short[1] ;
         T000I5_A1232MenuItemType = new short[1] ;
         T000I5_A1222MenuItemCaption = new string[] {""} ;
         T000I5_A1229MenuItemOrder = new short[1] ;
         T000I5_A1223MenuItemFatherCaption = new string[] {""} ;
         T000I5_A1224MenuItemFatherType = new short[1] ;
         T000I5_A1226MenuItemLink = new string[] {""} ;
         T000I5_A1227MenuItemLinkParameters = new string[] {""} ;
         T000I5_A1228MenuItemLinkTarget = new string[] {""} ;
         T000I5_A1225MenuItemIconClass = new string[] {""} ;
         T000I5_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         T000I5_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         T000I5_A353MenuItemFatherId = new short[1] ;
         T000I5_n353MenuItemFatherId = new bool[] {false} ;
         T000I6_A1223MenuItemFatherCaption = new string[] {""} ;
         T000I6_A1224MenuItemFatherType = new short[1] ;
         T000I7_A352MenuItemId = new short[1] ;
         T000I3_A352MenuItemId = new short[1] ;
         T000I3_A1232MenuItemType = new short[1] ;
         T000I3_A1222MenuItemCaption = new string[] {""} ;
         T000I3_A1229MenuItemOrder = new short[1] ;
         T000I3_A1226MenuItemLink = new string[] {""} ;
         T000I3_A1227MenuItemLinkParameters = new string[] {""} ;
         T000I3_A1228MenuItemLinkTarget = new string[] {""} ;
         T000I3_A1225MenuItemIconClass = new string[] {""} ;
         T000I3_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         T000I3_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         T000I3_A353MenuItemFatherId = new short[1] ;
         T000I3_n353MenuItemFatherId = new bool[] {false} ;
         T000I8_A352MenuItemId = new short[1] ;
         T000I9_A352MenuItemId = new short[1] ;
         T000I2_A352MenuItemId = new short[1] ;
         T000I2_A1232MenuItemType = new short[1] ;
         T000I2_A1222MenuItemCaption = new string[] {""} ;
         T000I2_A1229MenuItemOrder = new short[1] ;
         T000I2_A1226MenuItemLink = new string[] {""} ;
         T000I2_A1227MenuItemLinkParameters = new string[] {""} ;
         T000I2_A1228MenuItemLinkTarget = new string[] {""} ;
         T000I2_A1225MenuItemIconClass = new string[] {""} ;
         T000I2_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         T000I2_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         T000I2_A353MenuItemFatherId = new short[1] ;
         T000I2_n353MenuItemFatherId = new bool[] {false} ;
         T000I13_A1223MenuItemFatherCaption = new string[] {""} ;
         T000I13_A1224MenuItemFatherType = new short[1] ;
         T000I14_A353MenuItemFatherId = new short[1] ;
         T000I14_n353MenuItemFatherId = new bool[] {false} ;
         T000I15_A352MenuItemId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         i1222MenuItemCaption = "";
         i1225MenuItemIconClass = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitem__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitem__default(),
            new Object[][] {
                new Object[] {
               T000I2_A352MenuItemId, T000I2_A1232MenuItemType, T000I2_A1222MenuItemCaption, T000I2_A1229MenuItemOrder, T000I2_A1226MenuItemLink, T000I2_A1227MenuItemLinkParameters, T000I2_A1228MenuItemLinkTarget, T000I2_A1225MenuItemIconClass, T000I2_A1230MenuItemShowDeveloperMenuOptio, T000I2_A1231MenuItemShowEditMenuOptions,
               T000I2_A353MenuItemFatherId, T000I2_n353MenuItemFatherId
               }
               , new Object[] {
               T000I3_A352MenuItemId, T000I3_A1232MenuItemType, T000I3_A1222MenuItemCaption, T000I3_A1229MenuItemOrder, T000I3_A1226MenuItemLink, T000I3_A1227MenuItemLinkParameters, T000I3_A1228MenuItemLinkTarget, T000I3_A1225MenuItemIconClass, T000I3_A1230MenuItemShowDeveloperMenuOptio, T000I3_A1231MenuItemShowEditMenuOptions,
               T000I3_A353MenuItemFatherId, T000I3_n353MenuItemFatherId
               }
               , new Object[] {
               T000I4_A1223MenuItemFatherCaption, T000I4_A1224MenuItemFatherType
               }
               , new Object[] {
               T000I5_A352MenuItemId, T000I5_A1232MenuItemType, T000I5_A1222MenuItemCaption, T000I5_A1229MenuItemOrder, T000I5_A1223MenuItemFatherCaption, T000I5_A1224MenuItemFatherType, T000I5_A1226MenuItemLink, T000I5_A1227MenuItemLinkParameters, T000I5_A1228MenuItemLinkTarget, T000I5_A1225MenuItemIconClass,
               T000I5_A1230MenuItemShowDeveloperMenuOptio, T000I5_A1231MenuItemShowEditMenuOptions, T000I5_A353MenuItemFatherId, T000I5_n353MenuItemFatherId
               }
               , new Object[] {
               T000I6_A1223MenuItemFatherCaption, T000I6_A1224MenuItemFatherType
               }
               , new Object[] {
               T000I7_A352MenuItemId
               }
               , new Object[] {
               T000I8_A352MenuItemId
               }
               , new Object[] {
               T000I9_A352MenuItemId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000I13_A1223MenuItemFatherCaption, T000I13_A1224MenuItemFatherType
               }
               , new Object[] {
               T000I14_A353MenuItemFatherId
               }
               , new Object[] {
               T000I15_A352MenuItemId
               }
            }
         );
         AV25Pgmname = "WWPBaseObjects.MenuItem";
         Z1231MenuItemShowEditMenuOptions = false;
         A1231MenuItemShowEditMenuOptions = false;
         i1231MenuItemShowEditMenuOptions = false;
         Z1230MenuItemShowDeveloperMenuOptio = false;
         A1230MenuItemShowDeveloperMenuOptio = false;
         i1230MenuItemShowDeveloperMenuOptio = false;
         Z1225MenuItemIconClass = "";
         A1225MenuItemIconClass = "";
         i1225MenuItemIconClass = "";
         Z1222MenuItemCaption = "";
         A1222MenuItemCaption = "";
         i1222MenuItemCaption = "";
      }

      private short wcpOAV7MenuItemId ;
      private short wcpOAV13MenuItemFatherId ;
      private short Z352MenuItemId ;
      private short Z1232MenuItemType ;
      private short Z1229MenuItemOrder ;
      private short Z353MenuItemFatherId ;
      private short N353MenuItemFatherId ;
      private short GxWebError ;
      private short A352MenuItemId ;
      private short AV7MenuItemId ;
      private short Gx_BScreen ;
      private short A353MenuItemFatherId ;
      private short AV13MenuItemFatherId ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1232MenuItemType ;
      private short A1229MenuItemOrder ;
      private short AV22ComboMenuItemFatherId ;
      private short AV11Insert_MenuItemFatherId ;
      private short A1224MenuItemFatherType ;
      private short RcdFound19 ;
      private short GX_JID ;
      private short Z1224MenuItemFatherType ;
      private short nIsDirty_19 ;
      private short gxajaxcallmode ;
      private short GXt_int3 ;
      private int trnEnded ;
      private int edtMenuItemId_Visible ;
      private int edtMenuItemId_Enabled ;
      private int edtMenuItemOrder_Enabled ;
      private int edtMenuItemFatherId_Visible ;
      private int edtMenuItemFatherId_Enabled ;
      private int edtMenuItemCaption_Enabled ;
      private int edtMenuItemIconClass_Visible ;
      private int edtMenuItemIconClass_Enabled ;
      private int edtMenuItemLink_Visible ;
      private int edtMenuItemLink_Enabled ;
      private int edtMenuItemLinkParameters_Visible ;
      private int edtMenuItemLinkParameters_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int edtavCombomenuitemfatherid_Enabled ;
      private int edtavCombomenuitemfatherid_Visible ;
      private int Combo_menuitemfatherid_Datalistupdateminimumcharacters ;
      private int Combo_menuitemfatherid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Combo_menuitemfatherid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMenuItemOrder_Internalname ;
      private string cmbMenuItemType_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
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
      private string divMenuitemid_cell_Internalname ;
      private string divMenuitemid_cell_Class ;
      private string edtMenuItemId_Internalname ;
      private string edtMenuItemId_Jsonclick ;
      private string TempTags ;
      private string edtMenuItemOrder_Jsonclick ;
      private string divCombo_menuitemfatherid_cell_Internalname ;
      private string divCombo_menuitemfatherid_cell_Class ;
      private string divTablesplittedmenuitemfatherid_Internalname ;
      private string lblTextblockmenuitemfatherid_Internalname ;
      private string lblTextblockmenuitemfatherid_Jsonclick ;
      private string Combo_menuitemfatherid_Caption ;
      private string Combo_menuitemfatherid_Cls ;
      private string Combo_menuitemfatherid_Datalistproc ;
      private string Combo_menuitemfatherid_Datalistprocparametersprefix ;
      private string Combo_menuitemfatherid_Internalname ;
      private string edtMenuItemFatherId_Internalname ;
      private string edtMenuItemFatherId_Jsonclick ;
      private string edtMenuItemCaption_Internalname ;
      private string edtMenuItemCaption_Jsonclick ;
      private string divMenuitemtype_cell_Internalname ;
      private string divMenuitemtype_cell_Class ;
      private string cmbMenuItemType_Jsonclick ;
      private string divMenuitemiconclass_cell_Internalname ;
      private string divMenuitemiconclass_cell_Class ;
      private string edtMenuItemIconClass_Internalname ;
      private string edtMenuItemIconClass_Jsonclick ;
      private string divMenuitemlink_cell_Internalname ;
      private string divMenuitemlink_cell_Class ;
      private string edtMenuItemLink_Internalname ;
      private string edtMenuItemLink_Jsonclick ;
      private string divMenuitemlinkparameters_cell_Internalname ;
      private string divMenuitemlinkparameters_cell_Class ;
      private string edtMenuItemLinkParameters_Internalname ;
      private string edtMenuItemLinkParameters_Jsonclick ;
      private string divMenuitemlinktarget_cell_Internalname ;
      private string divMenuitemlinktarget_cell_Class ;
      private string chkMenuItemLinkTarget_Internalname ;
      private string divMenuitemshowdevelopermenuoption_cell_Internalname ;
      private string divMenuitemshowdevelopermenuoption_cell_Class ;
      private string chkMenuItemShowDeveloperMenuOptio_Internalname ;
      private string divMenuitemshoweditmenuoptions_cell_Internalname ;
      private string divMenuitemshoweditmenuoptions_cell_Class ;
      private string chkMenuItemShowEditMenuOptions_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_menuitemfatherid_Internalname ;
      private string edtavCombomenuitemfatherid_Internalname ;
      private string edtavCombomenuitemfatherid_Jsonclick ;
      private string AV25Pgmname ;
      private string Combo_menuitemfatherid_Objectcall ;
      private string Combo_menuitemfatherid_Class ;
      private string Combo_menuitemfatherid_Icontype ;
      private string Combo_menuitemfatherid_Icon ;
      private string Combo_menuitemfatherid_Tooltip ;
      private string Combo_menuitemfatherid_Selectedvalue_set ;
      private string Combo_menuitemfatherid_Selectedtext_set ;
      private string Combo_menuitemfatherid_Selectedtext_get ;
      private string Combo_menuitemfatherid_Gamoauthtoken ;
      private string Combo_menuitemfatherid_Ddointernalname ;
      private string Combo_menuitemfatherid_Titlecontrolalign ;
      private string Combo_menuitemfatherid_Dropdownoptionstype ;
      private string Combo_menuitemfatherid_Titlecontrolidtoreplace ;
      private string Combo_menuitemfatherid_Datalisttype ;
      private string Combo_menuitemfatherid_Datalistfixedvalues ;
      private string Combo_menuitemfatherid_Htmltemplate ;
      private string Combo_menuitemfatherid_Multiplevaluestype ;
      private string Combo_menuitemfatherid_Loadingdata ;
      private string Combo_menuitemfatherid_Noresultsfound ;
      private string Combo_menuitemfatherid_Emptyitemtext ;
      private string Combo_menuitemfatherid_Onlyselectedvalues ;
      private string Combo_menuitemfatherid_Selectalltext ;
      private string Combo_menuitemfatherid_Multiplevaluesseparator ;
      private string Combo_menuitemfatherid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode19 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool Z1230MenuItemShowDeveloperMenuOptio ;
      private bool Z1231MenuItemShowEditMenuOptions ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n353MenuItemFatherId ;
      private bool wbErr ;
      private bool A1230MenuItemShowDeveloperMenuOptio ;
      private bool A1231MenuItemShowEditMenuOptions ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool AV16MenuItemShowDeveloperMenuOption ;
      private bool Combo_menuitemfatherid_Enabled ;
      private bool Combo_menuitemfatherid_Visible ;
      private bool Combo_menuitemfatherid_Allowmultipleselection ;
      private bool Combo_menuitemfatherid_Isgriditem ;
      private bool Combo_menuitemfatherid_Hasdescription ;
      private bool Combo_menuitemfatherid_Includeonlyselectedoption ;
      private bool Combo_menuitemfatherid_Includeselectalloption ;
      private bool Combo_menuitemfatherid_Emptyitem ;
      private bool Combo_menuitemfatherid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i1230MenuItemShowDeveloperMenuOptio ;
      private bool i1231MenuItemShowEditMenuOptions ;
      private string AV21Combo_DataJson ;
      private string Z1222MenuItemCaption ;
      private string Z1226MenuItemLink ;
      private string Z1227MenuItemLinkParameters ;
      private string Z1228MenuItemLinkTarget ;
      private string Z1225MenuItemIconClass ;
      private string AV14MenuItemCaption ;
      private string A1228MenuItemLinkTarget ;
      private string A1222MenuItemCaption ;
      private string A1225MenuItemIconClass ;
      private string A1226MenuItemLink ;
      private string A1227MenuItemLinkParameters ;
      private string AV15MenuItemIconClass ;
      private string A1223MenuItemFatherCaption ;
      private string AV19ComboSelectedValue ;
      private string AV20ComboSelectedText ;
      private string Z1223MenuItemFatherCaption ;
      private string i1222MenuItemCaption ;
      private string i1225MenuItemIconClass ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_menuitemfatherid ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private short aP2_MenuItemFatherId ;
      private GXCombobox cmbMenuItemType ;
      private GXCheckbox chkMenuItemLinkTarget ;
      private GXCheckbox chkMenuItemShowDeveloperMenuOptio ;
      private GXCheckbox chkMenuItemShowEditMenuOptions ;
      private IDataStoreProvider pr_default ;
      private string[] T000I4_A1223MenuItemFatherCaption ;
      private short[] T000I4_A1224MenuItemFatherType ;
      private short[] T000I5_A352MenuItemId ;
      private short[] T000I5_A1232MenuItemType ;
      private string[] T000I5_A1222MenuItemCaption ;
      private short[] T000I5_A1229MenuItemOrder ;
      private string[] T000I5_A1223MenuItemFatherCaption ;
      private short[] T000I5_A1224MenuItemFatherType ;
      private string[] T000I5_A1226MenuItemLink ;
      private string[] T000I5_A1227MenuItemLinkParameters ;
      private string[] T000I5_A1228MenuItemLinkTarget ;
      private string[] T000I5_A1225MenuItemIconClass ;
      private bool[] T000I5_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] T000I5_A1231MenuItemShowEditMenuOptions ;
      private short[] T000I5_A353MenuItemFatherId ;
      private bool[] T000I5_n353MenuItemFatherId ;
      private string[] T000I6_A1223MenuItemFatherCaption ;
      private short[] T000I6_A1224MenuItemFatherType ;
      private short[] T000I7_A352MenuItemId ;
      private short[] T000I3_A352MenuItemId ;
      private short[] T000I3_A1232MenuItemType ;
      private string[] T000I3_A1222MenuItemCaption ;
      private short[] T000I3_A1229MenuItemOrder ;
      private string[] T000I3_A1226MenuItemLink ;
      private string[] T000I3_A1227MenuItemLinkParameters ;
      private string[] T000I3_A1228MenuItemLinkTarget ;
      private string[] T000I3_A1225MenuItemIconClass ;
      private bool[] T000I3_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] T000I3_A1231MenuItemShowEditMenuOptions ;
      private short[] T000I3_A353MenuItemFatherId ;
      private bool[] T000I3_n353MenuItemFatherId ;
      private short[] T000I8_A352MenuItemId ;
      private short[] T000I9_A352MenuItemId ;
      private short[] T000I2_A352MenuItemId ;
      private short[] T000I2_A1232MenuItemType ;
      private string[] T000I2_A1222MenuItemCaption ;
      private short[] T000I2_A1229MenuItemOrder ;
      private string[] T000I2_A1226MenuItemLink ;
      private string[] T000I2_A1227MenuItemLinkParameters ;
      private string[] T000I2_A1228MenuItemLinkTarget ;
      private string[] T000I2_A1225MenuItemIconClass ;
      private bool[] T000I2_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] T000I2_A1231MenuItemShowEditMenuOptions ;
      private short[] T000I2_A353MenuItemFatherId ;
      private bool[] T000I2_n353MenuItemFatherId ;
      private string[] T000I13_A1223MenuItemFatherCaption ;
      private short[] T000I13_A1224MenuItemFatherType ;
      private short[] T000I14_A353MenuItemFatherId ;
      private bool[] T000I14_n353MenuItemFatherId ;
      private short[] T000I15_A352MenuItemId ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV17MenuItemFatherId_Data ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV12TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV18DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class menuitem__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class menuitem__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000I5;
        prmT000I5 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I4;
        prmT000I4 = new Object[] {
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000I6;
        prmT000I6 = new Object[] {
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000I7;
        prmT000I7 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I3;
        prmT000I3 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I8;
        prmT000I8 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I9;
        prmT000I9 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I2;
        prmT000I2 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I10;
        prmT000I10 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0) ,
        new ParDef("@MenuItemType",GXType.Int16,1,0) ,
        new ParDef("@MenuItemCaption",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemOrder",GXType.Int16,4,0) ,
        new ParDef("@MenuItemLink",GXType.NVarChar,80,0) ,
        new ParDef("@MenuItemLinkParameters",GXType.NVarChar,100,0) ,
        new ParDef("@MenuItemLinkTarget",GXType.NVarChar,10,0) ,
        new ParDef("@MenuItemIconClass",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemShowDeveloperMenuOptio",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemShowEditMenuOptions",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true}
        };
        Object[] prmT000I11;
        prmT000I11 = new Object[] {
        new ParDef("@MenuItemType",GXType.Int16,1,0) ,
        new ParDef("@MenuItemCaption",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemOrder",GXType.Int16,4,0) ,
        new ParDef("@MenuItemLink",GXType.NVarChar,80,0) ,
        new ParDef("@MenuItemLinkParameters",GXType.NVarChar,100,0) ,
        new ParDef("@MenuItemLinkTarget",GXType.NVarChar,10,0) ,
        new ParDef("@MenuItemIconClass",GXType.NVarChar,40,0) ,
        new ParDef("@MenuItemShowDeveloperMenuOptio",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemShowEditMenuOptions",GXType.Boolean,4,0) ,
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I12;
        prmT000I12 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I14;
        prmT000I14 = new Object[] {
        new ParDef("@MenuItemId",GXType.Int16,4,0)
        };
        Object[] prmT000I15;
        prmT000I15 = new Object[] {
        };
        Object[] prmT000I13;
        prmT000I13 = new Object[] {
        new ParDef("@MenuItemFatherId",GXType.Int16,4,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000I2", "SELECT [MenuItemId], [MenuItemType], [MenuItemCaption], [MenuItemOrder], [MenuItemLink], [MenuItemLinkParameters], [MenuItemLinkTarget], [MenuItemIconClass], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions], [MenuItemFatherId] AS MenuItemFatherId FROM [SIGERPMenu] WITH (UPDLOCK) WHERE [MenuItemId] = @MenuItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I3", "SELECT [MenuItemId], [MenuItemType], [MenuItemCaption], [MenuItemOrder], [MenuItemLink], [MenuItemLinkParameters], [MenuItemLinkTarget], [MenuItemIconClass], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions], [MenuItemFatherId] AS MenuItemFatherId FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I4", "SELECT [MenuItemCaption] AS MenuItemFatherCaption, [MenuItemType] AS MenuItemFatherType FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemFatherId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I5", "SELECT TM1.[MenuItemId], TM1.[MenuItemType], TM1.[MenuItemCaption], TM1.[MenuItemOrder], T2.[MenuItemCaption] AS MenuItemFatherCaption, T2.[MenuItemType] AS MenuItemFatherType, TM1.[MenuItemLink], TM1.[MenuItemLinkParameters], TM1.[MenuItemLinkTarget], TM1.[MenuItemIconClass], TM1.[MenuItemShowDeveloperMenuOptio], TM1.[MenuItemShowEditMenuOptions], TM1.[MenuItemFatherId] AS MenuItemFatherId FROM ([SIGERPMenu] TM1 LEFT JOIN [SIGERPMenu] T2 ON T2.[MenuItemId] = TM1.[MenuItemFatherId]) WHERE TM1.[MenuItemId] = @MenuItemId ORDER BY TM1.[MenuItemId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I6", "SELECT [MenuItemCaption] AS MenuItemFatherCaption, [MenuItemType] AS MenuItemFatherType FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemFatherId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I7", "SELECT [MenuItemId] FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I8", "SELECT TOP 1 [MenuItemId] FROM [SIGERPMenu] WHERE ( [MenuItemId] > @MenuItemId) ORDER BY [MenuItemId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I9", "SELECT TOP 1 [MenuItemId] FROM [SIGERPMenu] WHERE ( [MenuItemId] < @MenuItemId) ORDER BY [MenuItemId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I10", "INSERT INTO [SIGERPMenu]([MenuItemId], [MenuItemType], [MenuItemCaption], [MenuItemOrder], [MenuItemLink], [MenuItemLinkParameters], [MenuItemLinkTarget], [MenuItemIconClass], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions], [MenuItemFatherId]) VALUES(@MenuItemId, @MenuItemType, @MenuItemCaption, @MenuItemOrder, @MenuItemLink, @MenuItemLinkParameters, @MenuItemLinkTarget, @MenuItemIconClass, @MenuItemShowDeveloperMenuOptio, @MenuItemShowEditMenuOptions, @MenuItemFatherId)", GxErrorMask.GX_NOMASK,prmT000I10)
           ,new CursorDef("T000I11", "UPDATE [SIGERPMenu] SET [MenuItemType]=@MenuItemType, [MenuItemCaption]=@MenuItemCaption, [MenuItemOrder]=@MenuItemOrder, [MenuItemLink]=@MenuItemLink, [MenuItemLinkParameters]=@MenuItemLinkParameters, [MenuItemLinkTarget]=@MenuItemLinkTarget, [MenuItemIconClass]=@MenuItemIconClass, [MenuItemShowDeveloperMenuOptio]=@MenuItemShowDeveloperMenuOptio, [MenuItemShowEditMenuOptions]=@MenuItemShowEditMenuOptions, [MenuItemFatherId]=@MenuItemFatherId  WHERE [MenuItemId] = @MenuItemId", GxErrorMask.GX_NOMASK,prmT000I11)
           ,new CursorDef("T000I12", "DELETE FROM [SIGERPMenu]  WHERE [MenuItemId] = @MenuItemId", GxErrorMask.GX_NOMASK,prmT000I12)
           ,new CursorDef("T000I13", "SELECT [MenuItemCaption] AS MenuItemFatherCaption, [MenuItemType] AS MenuItemFatherType FROM [SIGERPMenu] WHERE [MenuItemId] = @MenuItemFatherId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000I14", "SELECT TOP 1 [MenuItemId] AS MenuItemFatherId FROM [SIGERPMenu] WHERE [MenuItemFatherId] = @MenuItemId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000I14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000I15", "SELECT [MenuItemId] FROM [SIGERPMenu] ORDER BY [MenuItemId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000I15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((bool[]) buf[11])[0] = rslt.wasNull(11);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((bool[]) buf[11])[0] = rslt.getBool(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((bool[]) buf[13])[0] = rslt.wasNull(13);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
