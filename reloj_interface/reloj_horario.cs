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
namespace GeneXus.Programs.reloj_interface {
   public class reloj_horario : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "reloj_interface.reloj_horario.aspx")), "reloj_interface.reloj_horario.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "reloj_interface.reloj_horario.aspx")))) ;
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
                  AV7Horario_ID = (short)(NumberUtil.Val( GetPar( "Horario_ID"), "."));
                  AssignAttri("", false, "AV7Horario_ID", StringUtil.LTrimStr( (decimal)(AV7Horario_ID), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vHORARIO_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Horario_ID), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Maestro de Horario", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtHorario_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public reloj_horario( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_horario( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_Horario_ID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7Horario_ID = aP1_Horario_ID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbHorario_Sts = new GXCombobox();
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
         if ( cmbHorario_Sts.ItemCount > 0 )
         {
            A2463Horario_Sts = (short)(NumberUtil.Val( cmbHorario_Sts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0))), "."));
            AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbHorario_Sts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
            AssignProp("", false, cmbHorario_Sts_Internalname, "Values", cmbHorario_Sts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHorario_ID_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_ID_Internalname, "ID", "col-sm-3 AttributeLabel BootstrapTooltipRightLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_ID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2432Horario_ID), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A2432Horario_ID), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_ID_Tooltiptext, "Codigo del Horario", edtHorario_ID_Jsonclick, 0, "Attribute BootstrapTooltipRight", "", "", "", "", 1, edtHorario_ID_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHorario_Dsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dsc_Internalname, "Descripcion", "col-sm-3 AttributeLabel BootstrapTooltipRightLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dsc_Internalname, A2433Horario_Dsc, StringUtil.RTrim( context.localUtil.Format( A2433Horario_Dsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dsc_Tooltiptext, "Descripción", edtHorario_Dsc_Jsonclick, 0, "Attribute BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHorario_Vigencia_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Vigencia_Internalname, "Fecha Registro", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtHorario_Vigencia_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtHorario_Vigencia_Internalname, context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2462Horario_Vigencia, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Vigencia_Tooltiptext, "Entra en Vigencia", edtHorario_Vigencia_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Vigencia_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_bitmap( context, edtHorario_Vigencia_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtHorario_Vigencia_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbHorario_Sts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbHorario_Sts_Internalname, "Estado", "col-sm-3 AttributeLabel BootstrapTooltipRightLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbHorario_Sts, cmbHorario_Sts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0)), 1, cmbHorario_Sts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", cmbHorario_Sts.TooltipText, 1, cmbHorario_Sts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute BootstrapTooltipRight", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 1, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         cmbHorario_Sts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
         AssignProp("", false, cmbHorario_Sts_Internalname, "Values", (string)(cmbHorario_Sts.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHorario_Dia_Toling_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Toling_Internalname, "Tolerancia Ingreso (Min)", "col-sm-3 AttributeLabel BootstrapTooltipRightLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Toling_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2464Horario_Dia_Toling), 9, 0, ".", "")), StringUtil.LTrim( ((edtHorario_Dia_Toling_Enabled!=0) ? context.localUtil.Format( (decimal)(A2464Horario_Dia_Toling), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2464Horario_Dia_Toling), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Toling_Tooltiptext, "(Minutos)", edtHorario_Dia_Toling_Jsonclick, 0, "Attribute BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Toling_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-6 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtHorario_Dia_TolSal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_TolSal_Internalname, "Tolerancia Salida (Min)", "col-sm-3 AttributeLabel BootstrapTooltipRightLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_TolSal_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2466Horario_Dia_TolSal), 9, 0, ".", "")), StringUtil.LTrim( ((edtHorario_Dia_TolSal_Enabled!=0) ? context.localUtil.Format( (decimal)(A2466Horario_Dia_TolSal), "ZZZZZZZZ9") : context.localUtil.Format( (decimal)(A2466Horario_Dia_TolSal), "ZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_TolSal_Tooltiptext, "(Minutos)", edtHorario_Dia_TolSal_Jsonclick, 0, "Attribute BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_TolSal_Enabled, 0, "text", "1", 9, "chr", 1, "row", 9, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_table2.SetProperty("Width", Dvpanel_table2_Width);
         ucDvpanel_table2.SetProperty("AutoWidth", Dvpanel_table2_Autowidth);
         ucDvpanel_table2.SetProperty("AutoHeight", Dvpanel_table2_Autoheight);
         ucDvpanel_table2.SetProperty("Cls", Dvpanel_table2_Cls);
         ucDvpanel_table2.SetProperty("Title", Dvpanel_table2_Title);
         ucDvpanel_table2.SetProperty("Collapsible", Dvpanel_table2_Collapsible);
         ucDvpanel_table2.SetProperty("Collapsed", Dvpanel_table2_Collapsed);
         ucDvpanel_table2.SetProperty("ShowCollapseIcon", Dvpanel_table2_Showcollapseicon);
         ucDvpanel_table2.SetProperty("IconPosition", Dvpanel_table2_Iconposition);
         ucDvpanel_table2.SetProperty("AutoScroll", Dvpanel_table2_Autoscroll);
         ucDvpanel_table2.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_table2_Internalname, "DVPANEL_TABLE2Container");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLE2Container"+"Table2"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTable2_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft30", "left", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblLunes_Internalname, "Lunes", "", "", lblLunes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft30", "left", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblMartes_Internalname, "Martes", "", "", lblMartes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft30", "left", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblMiercoles_Internalname, "Miercoles", "", "", lblMiercoles_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft30", "left", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblJueves_Internalname, "Jueves", "", "", lblJueves_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft30", "left", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblViernes_Internalname, "Viernes", "", "", lblViernes_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft30", "left", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblSabado_Internalname, "Sabado", "", "", lblSabado_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingLeft30", "left", "top", "", "flex-grow:1;", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblDomingo_Internalname, "Domingo", "", "", lblDomingo_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtable3_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_ini_01_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_ini_01_Internalname, "", "", "", lblTextblockhorario_dia_ini_01_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Ingreso", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Ini_01_Internalname, "Horario_Dia_Ini_01", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Ini_01_Internalname, context.localUtil.TToC( A2434Horario_Dia_Ini_01, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2434Horario_Dia_Ini_01, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,80);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Ini_01_Tooltiptext, "Hora Ingreso", edtHorario_Dia_Ini_01_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Ini_01_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_ini_02_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_ini_02_Internalname, "", "", "", lblTextblockhorario_dia_ini_02_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Ingreso", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Ini_02_Internalname, "Horario_Dia_Ini_02", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Ini_02_Internalname, context.localUtil.TToC( A2435Horario_Dia_Ini_02, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2435Horario_Dia_Ini_02, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Ini_02_Tooltiptext, "Hora Ingreso", edtHorario_Dia_Ini_02_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Ini_02_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_ini_03_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_ini_03_Internalname, "", "", "", lblTextblockhorario_dia_ini_03_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Ingreso", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Ini_03_Internalname, "Horario_Dia_Ini_03", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Ini_03_Internalname, context.localUtil.TToC( A2436Horario_Dia_Ini_03, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2436Horario_Dia_Ini_03, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Ini_03_Tooltiptext, "Hora Ingreso", edtHorario_Dia_Ini_03_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Ini_03_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_ini_04_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_ini_04_Internalname, "", "", "", lblTextblockhorario_dia_ini_04_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Ingreso", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Ini_04_Internalname, "Horario_Dia_Ini_04", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Ini_04_Internalname, context.localUtil.TToC( A2437Horario_Dia_Ini_04, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2437Horario_Dia_Ini_04, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Ini_04_Tooltiptext, "Hora Ingreso", edtHorario_Dia_Ini_04_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Ini_04_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_ini_05_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_ini_05_Internalname, "", "", "", lblTextblockhorario_dia_ini_05_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Ingreso", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Ini_05_Internalname, "Horario_Dia_Ini_05", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 112,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Ini_05_Internalname, context.localUtil.TToC( A2438Horario_Dia_Ini_05, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2438Horario_Dia_Ini_05, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,112);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Ini_05_Tooltiptext, "Hora Ingreso", edtHorario_Dia_Ini_05_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Ini_05_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_ini_06_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_ini_06_Internalname, "", "", "", lblTextblockhorario_dia_ini_06_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Ingreso", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Ini_06_Internalname, "Horario_Dia_Ini_06", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Ini_06_Internalname, context.localUtil.TToC( A2439Horario_Dia_Ini_06, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2439Horario_Dia_Ini_06, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,120);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Ini_06_Tooltiptext, "Hora Ingreso", edtHorario_Dia_Ini_06_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Ini_06_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_ini_07_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_ini_07_Internalname, "", "", "", lblTextblockhorario_dia_ini_07_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Ingreso", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Ini_07_Internalname, "Horario_Dia_Ini_07", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Ini_07_Internalname, context.localUtil.TToC( A2440Horario_Dia_Ini_07, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2440Horario_Dia_Ini_07, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Ini_07_Tooltiptext, "Hora Ingreso", edtHorario_Dia_Ini_07_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Ini_07_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         GxWebStd.gx_div_start( context, divUnnamedtable4_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_ini_01_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_ini_01_Internalname, "", "", "", lblTextblockhorario_ref_ini_01_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Ingreso al refrigerio", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Ini_01_Internalname, "Horario_Ref_Ini_01", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 139,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Ini_01_Internalname, context.localUtil.TToC( A2448Horario_Ref_Ini_01, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2448Horario_Ref_Ini_01, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,139);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Ini_01_Tooltiptext, "Hora Refrigerio", edtHorario_Ref_Ini_01_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Ini_01_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_ini_02_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_ini_02_Internalname, "", "", "", lblTextblockhorario_ref_ini_02_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Ingreso al refrigerio", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Ini_02_Internalname, "Horario_Ref_Ini_02", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 147,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Ini_02_Internalname, context.localUtil.TToC( A2449Horario_Ref_Ini_02, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2449Horario_Ref_Ini_02, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,147);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Ini_02_Tooltiptext, "Hora Refrigerio", edtHorario_Ref_Ini_02_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Ini_02_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_ini_03_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_ini_03_Internalname, "", "", "", lblTextblockhorario_ref_ini_03_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Ingreso al refrigerio", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Ini_03_Internalname, "Horario_Ref_Ini_03", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 155,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Ini_03_Internalname, context.localUtil.TToC( A2450Horario_Ref_Ini_03, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2450Horario_Ref_Ini_03, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,155);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Ini_03_Tooltiptext, "Hora Refrigerio", edtHorario_Ref_Ini_03_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Ini_03_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_ini_04_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_ini_04_Internalname, "", "", "", lblTextblockhorario_ref_ini_04_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Ingreso al refrigerio", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Ini_04_Internalname, "Horario_Ref_Ini_04", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 163,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Ini_04_Internalname, context.localUtil.TToC( A2451Horario_Ref_Ini_04, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2451Horario_Ref_Ini_04, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,163);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Ini_04_Tooltiptext, "Hora Refrigerio", edtHorario_Ref_Ini_04_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Ini_04_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_ini_05_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_ini_05_Internalname, "", "", "", lblTextblockhorario_ref_ini_05_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Ingreso al refrigerio", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Ini_05_Internalname, "Horario_Ref_Ini_05", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Ini_05_Internalname, context.localUtil.TToC( A2452Horario_Ref_Ini_05, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2452Horario_Ref_Ini_05, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Ini_05_Tooltiptext, "Hora Refrigerio", edtHorario_Ref_Ini_05_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Ini_05_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_ini_06_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_ini_06_Internalname, "", "", "", lblTextblockhorario_ref_ini_06_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Ingreso al refrigerio", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Ini_06_Internalname, "Horario_Ref_Ini_06", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 179,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Ini_06_Internalname, context.localUtil.TToC( A2453Horario_Ref_Ini_06, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2453Horario_Ref_Ini_06, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,179);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Ini_06_Tooltiptext, "Hora Refrigerio", edtHorario_Ref_Ini_06_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Ini_06_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_ini_07_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_ini_07_Internalname, "", "", "", lblTextblockhorario_ref_ini_07_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Ingreso al refrigerio", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Ini_07_Internalname, "Horario_Ref_Ini_07", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Ini_07_Internalname, context.localUtil.TToC( A2454Horario_Ref_Ini_07, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2454Horario_Ref_Ini_07, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,187);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Ini_07_Tooltiptext, "Hora Refrigerio", edtHorario_Ref_Ini_07_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Ini_07_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         GxWebStd.gx_div_start( context, divUnnamedtable5_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_fin_01_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_fin_01_Internalname, "", "", "", lblTextblockhorario_ref_fin_01_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Salida De Refrigero", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Fin_01_Internalname, "Horario_Ref_Fin_01", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 198,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Fin_01_Internalname, context.localUtil.TToC( A2455Horario_Ref_Fin_01, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2455Horario_Ref_Fin_01, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,198);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Fin_01_Tooltiptext, "Hora Refrigerio Sal", edtHorario_Ref_Fin_01_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Fin_01_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_fin_02_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_fin_02_Internalname, "", "", "", lblTextblockhorario_ref_fin_02_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Salida De Refrigero", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         drawControls1( ) ;
      }

      protected void drawControls1( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Fin_02_Internalname, "Horario_Ref_Fin_02", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Fin_02_Internalname, context.localUtil.TToC( A2456Horario_Ref_Fin_02, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2456Horario_Ref_Fin_02, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Fin_02_Tooltiptext, "Hora Refrigerio Sal", edtHorario_Ref_Fin_02_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Fin_02_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_fin_03_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_fin_03_Internalname, "", "", "", lblTextblockhorario_ref_fin_03_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Salida De Refrigero", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Fin_03_Internalname, "Horario_Ref_Fin_03", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 214,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Fin_03_Internalname, context.localUtil.TToC( A2457Horario_Ref_Fin_03, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2457Horario_Ref_Fin_03, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,214);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Fin_03_Tooltiptext, "Hora Refrigerio Sal", edtHorario_Ref_Fin_03_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Fin_03_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_fin_04_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_fin_04_Internalname, "", "", "", lblTextblockhorario_ref_fin_04_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Salida De Refrigero", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Fin_04_Internalname, "Horario_Ref_Fin_04", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 222,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Fin_04_Internalname, context.localUtil.TToC( A2458Horario_Ref_Fin_04, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2458Horario_Ref_Fin_04, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,222);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Fin_04_Tooltiptext, "Hora Refrigerio Sal", edtHorario_Ref_Fin_04_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Fin_04_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_fin_05_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_fin_05_Internalname, "", "", "", lblTextblockhorario_ref_fin_05_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Salida De Refrigero", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Fin_05_Internalname, "Horario_Ref_Fin_05", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 230,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Fin_05_Internalname, context.localUtil.TToC( A2459Horario_Ref_Fin_05, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2459Horario_Ref_Fin_05, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,230);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Fin_05_Tooltiptext, "Hora Refrigerio Sal", edtHorario_Ref_Fin_05_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Fin_05_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_fin_06_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_fin_06_Internalname, "", "", "", lblTextblockhorario_ref_fin_06_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Salida De Refrigero", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Fin_06_Internalname, "Horario_Ref_Fin_06", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 238,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Fin_06_Internalname, context.localUtil.TToC( A2460Horario_Ref_Fin_06, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2460Horario_Ref_Fin_06, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,238);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Fin_06_Tooltiptext, "Hora Refrigerio Sal", edtHorario_Ref_Fin_06_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Fin_06_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_ref_fin_07_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_ref_fin_07_Internalname, "", "", "", lblTextblockhorario_ref_fin_07_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Salida De Refrigero", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Ref_Fin_07_Internalname, "Horario_Ref_Fin_07", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Ref_Fin_07_Internalname, context.localUtil.TToC( A2461Horario_Ref_Fin_07, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2461Horario_Ref_Fin_07, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,246);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Ref_Fin_07_Tooltiptext, "Hora Refrigerio Sal", edtHorario_Ref_Fin_07_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Ref_Fin_07_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         GxWebStd.gx_div_start( context, divUnnamedtable6_Internalname, 1, 0, "px", 0, "px", "Flex", "left", "top", " "+"data-gx-flex"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_fin_01_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_fin_01_Internalname, "", "", "", lblTextblockhorario_dia_fin_01_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Salida", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Fin_01_Internalname, "Horario_Dia_Fin_01", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 257,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Fin_01_Internalname, context.localUtil.TToC( A2441Horario_Dia_Fin_01, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2441Horario_Dia_Fin_01, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,257);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Fin_01_Tooltiptext, "Hora Salida", edtHorario_Dia_Fin_01_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Fin_01_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_fin_02_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_fin_02_Internalname, "", "", "", lblTextblockhorario_dia_fin_02_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Salida", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Fin_02_Internalname, "Horario_Dia_Fin_02", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 265,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Fin_02_Internalname, context.localUtil.TToC( A2442Horario_Dia_Fin_02, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2442Horario_Dia_Fin_02, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,265);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Fin_02_Tooltiptext, "Hora Salida", edtHorario_Dia_Fin_02_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Fin_02_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_fin_03_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_fin_03_Internalname, "", "", "", lblTextblockhorario_dia_fin_03_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Salida", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Fin_03_Internalname, "Horario_Dia_Fin_03", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 273,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Fin_03_Internalname, context.localUtil.TToC( A2443Horario_Dia_Fin_03, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2443Horario_Dia_Fin_03, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,273);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Fin_03_Tooltiptext, "Hora Salida", edtHorario_Dia_Fin_03_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Fin_03_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_fin_04_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_fin_04_Internalname, "", "", "", lblTextblockhorario_dia_fin_04_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Salida", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Fin_04_Internalname, "Horario_Dia_Fin_04", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Fin_04_Internalname, context.localUtil.TToC( A2444Horario_Dia_Fin_04, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2444Horario_Dia_Fin_04, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,281);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Fin_04_Tooltiptext, "Hora Salida", edtHorario_Dia_Fin_04_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Fin_04_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_fin_05_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_fin_05_Internalname, "", "", "", lblTextblockhorario_dia_fin_05_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Salida", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Fin_05_Internalname, "Horario_Dia_Fin_05", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 289,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Fin_05_Internalname, context.localUtil.TToC( A2445Horario_Dia_Fin_05, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2445Horario_Dia_Fin_05, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,289);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Fin_05_Tooltiptext, "Hora Salida", edtHorario_Dia_Fin_05_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Fin_05_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_fin_06_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_fin_06_Internalname, "", "", "", lblTextblockhorario_dia_fin_06_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Salida", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Fin_06_Internalname, "Horario_Dia_Fin_06", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 297,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Fin_06_Internalname, context.localUtil.TToC( A2446Horario_Dia_Fin_06, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2446Horario_Dia_Fin_06, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,297);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Fin_06_Tooltiptext, "Hora Salida", edtHorario_Dia_Fin_06_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Fin_06_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DataContentCell DscTop", "left", "top", "", "flex-grow:1;", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divUnnamedtablehorario_dia_fin_07_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 MergeLabelCell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockhorario_dia_fin_07_Internalname, "", "", "", lblTextblockhorario_dia_fin_07_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label BootstrapTooltipTop", 0, "Hora Salida", 1, 1, 0, 0, "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtHorario_Dia_Fin_07_Internalname, "Horario_Dia_Fin_07", "col-sm-3 AttributeDateTimeLabel BootstrapTooltipRightLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 305,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtHorario_Dia_Fin_07_Internalname, context.localUtil.TToC( A2447Horario_Dia_Fin_07, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A2447Horario_Dia_Fin_07, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,305);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", edtHorario_Dia_Fin_07_Tooltiptext, "Hora Salida", edtHorario_Dia_Fin_07_Jsonclick, 0, "AttributeDateTime BootstrapTooltipRight", "", "", "", "", 1, edtHorario_Dia_Fin_07_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, 0, true, "Dominio_Hora", "center", false, "", "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 310,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 312,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Horario.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 314,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Reloj_Interface\\Reloj_Horario.htm");
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
         E117R2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z2432Horario_ID = (short)(context.localUtil.CToN( cgiGet( "Z2432Horario_ID"), ".", ","));
               Z2433Horario_Dsc = cgiGet( "Z2433Horario_Dsc");
               Z2434Horario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2434Horario_Dia_Ini_01"), 0));
               Z2435Horario_Dia_Ini_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2435Horario_Dia_Ini_02"), 0));
               Z2436Horario_Dia_Ini_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2436Horario_Dia_Ini_03"), 0));
               Z2437Horario_Dia_Ini_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2437Horario_Dia_Ini_04"), 0));
               Z2438Horario_Dia_Ini_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2438Horario_Dia_Ini_05"), 0));
               Z2439Horario_Dia_Ini_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2439Horario_Dia_Ini_06"), 0));
               Z2440Horario_Dia_Ini_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2440Horario_Dia_Ini_07"), 0));
               Z2441Horario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2441Horario_Dia_Fin_01"), 0));
               Z2442Horario_Dia_Fin_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2442Horario_Dia_Fin_02"), 0));
               Z2443Horario_Dia_Fin_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2443Horario_Dia_Fin_03"), 0));
               Z2444Horario_Dia_Fin_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2444Horario_Dia_Fin_04"), 0));
               Z2445Horario_Dia_Fin_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2445Horario_Dia_Fin_05"), 0));
               Z2446Horario_Dia_Fin_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2446Horario_Dia_Fin_06"), 0));
               Z2447Horario_Dia_Fin_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2447Horario_Dia_Fin_07"), 0));
               Z2448Horario_Ref_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2448Horario_Ref_Ini_01"), 0));
               Z2449Horario_Ref_Ini_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2449Horario_Ref_Ini_02"), 0));
               Z2450Horario_Ref_Ini_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2450Horario_Ref_Ini_03"), 0));
               Z2451Horario_Ref_Ini_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2451Horario_Ref_Ini_04"), 0));
               Z2452Horario_Ref_Ini_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2452Horario_Ref_Ini_05"), 0));
               Z2453Horario_Ref_Ini_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2453Horario_Ref_Ini_06"), 0));
               Z2454Horario_Ref_Ini_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2454Horario_Ref_Ini_07"), 0));
               Z2455Horario_Ref_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2455Horario_Ref_Fin_01"), 0));
               Z2456Horario_Ref_Fin_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2456Horario_Ref_Fin_02"), 0));
               Z2457Horario_Ref_Fin_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2457Horario_Ref_Fin_03"), 0));
               Z2458Horario_Ref_Fin_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2458Horario_Ref_Fin_04"), 0));
               Z2459Horario_Ref_Fin_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2459Horario_Ref_Fin_05"), 0));
               Z2460Horario_Ref_Fin_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2460Horario_Ref_Fin_06"), 0));
               Z2461Horario_Ref_Fin_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z2461Horario_Ref_Fin_07"), 0));
               Z2462Horario_Vigencia = context.localUtil.CToT( cgiGet( "Z2462Horario_Vigencia"), 0);
               Z2463Horario_Sts = (short)(context.localUtil.CToN( cgiGet( "Z2463Horario_Sts"), ".", ","));
               Z2464Horario_Dia_Toling = (int)(context.localUtil.CToN( cgiGet( "Z2464Horario_Dia_Toling"), ".", ","));
               Z2465Horario_Dia_TolRef = (int)(context.localUtil.CToN( cgiGet( "Z2465Horario_Dia_TolRef"), ".", ","));
               Z2466Horario_Dia_TolSal = (int)(context.localUtil.CToN( cgiGet( "Z2466Horario_Dia_TolSal"), ".", ","));
               A2465Horario_Dia_TolRef = (int)(context.localUtil.CToN( cgiGet( "Z2465Horario_Dia_TolRef"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7Horario_ID = (short)(context.localUtil.CToN( cgiGet( "vHORARIO_ID"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A2465Horario_Dia_TolRef = (int)(context.localUtil.CToN( cgiGet( "HORARIO_DIA_TOLREF"), ".", ","));
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
               Dvpanel_table2_Objectcall = cgiGet( "DVPANEL_TABLE2_Objectcall");
               Dvpanel_table2_Class = cgiGet( "DVPANEL_TABLE2_Class");
               Dvpanel_table2_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Enabled"));
               Dvpanel_table2_Width = cgiGet( "DVPANEL_TABLE2_Width");
               Dvpanel_table2_Height = cgiGet( "DVPANEL_TABLE2_Height");
               Dvpanel_table2_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Autowidth"));
               Dvpanel_table2_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Autoheight"));
               Dvpanel_table2_Cls = cgiGet( "DVPANEL_TABLE2_Cls");
               Dvpanel_table2_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Showheader"));
               Dvpanel_table2_Title = cgiGet( "DVPANEL_TABLE2_Title");
               Dvpanel_table2_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Collapsible"));
               Dvpanel_table2_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Collapsed"));
               Dvpanel_table2_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Showcollapseicon"));
               Dvpanel_table2_Iconposition = cgiGet( "DVPANEL_TABLE2_Iconposition");
               Dvpanel_table2_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Autoscroll"));
               Dvpanel_table2_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLE2_Visible"));
               Dvpanel_table2_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLE2_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtHorario_ID_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHorario_ID_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HORARIO_ID");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2432Horario_ID = 0;
                  AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
               }
               else
               {
                  A2432Horario_ID = (short)(context.localUtil.CToN( cgiGet( edtHorario_ID_Internalname), ".", ","));
                  AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
               }
               A2433Horario_Dsc = cgiGet( edtHorario_Dsc_Internalname);
               AssignAttri("", false, "A2433Horario_Dsc", A2433Horario_Dsc);
               if ( context.localUtil.VCDateTime( cgiGet( edtHorario_Vigencia_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Horario_Vigencia"}), 1, "HORARIO_VIGENCIA");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Vigencia_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2462Horario_Vigencia", context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2462Horario_Vigencia = context.localUtil.CToT( cgiGet( edtHorario_Vigencia_Internalname));
                  AssignAttri("", false, "A2462Horario_Vigencia", context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
               }
               cmbHorario_Sts.CurrentValue = cgiGet( cmbHorario_Sts_Internalname);
               A2463Horario_Sts = (short)(NumberUtil.Val( cgiGet( cmbHorario_Sts_Internalname), "."));
               AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtHorario_Dia_Toling_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHorario_Dia_Toling_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HORARIO_DIA_TOLING");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Toling_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2464Horario_Dia_Toling = 0;
                  AssignAttri("", false, "A2464Horario_Dia_Toling", StringUtil.LTrimStr( (decimal)(A2464Horario_Dia_Toling), 9, 0));
               }
               else
               {
                  A2464Horario_Dia_Toling = (int)(context.localUtil.CToN( cgiGet( edtHorario_Dia_Toling_Internalname), ".", ","));
                  AssignAttri("", false, "A2464Horario_Dia_Toling", StringUtil.LTrimStr( (decimal)(A2464Horario_Dia_Toling), 9, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtHorario_Dia_TolSal_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtHorario_Dia_TolSal_Internalname), ".", ",") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "HORARIO_DIA_TOLSAL");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_TolSal_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2466Horario_Dia_TolSal = 0;
                  AssignAttri("", false, "A2466Horario_Dia_TolSal", StringUtil.LTrimStr( (decimal)(A2466Horario_Dia_TolSal), 9, 0));
               }
               else
               {
                  A2466Horario_Dia_TolSal = (int)(context.localUtil.CToN( cgiGet( edtHorario_Dia_TolSal_Internalname), ".", ","));
                  AssignAttri("", false, "A2466Horario_Dia_TolSal", StringUtil.LTrimStr( (decimal)(A2466Horario_Dia_TolSal), 9, 0));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Ini_01_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Ini_01"}), 1, "HORARIO_DIA_INI_01");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Ini_01_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2434Horario_Dia_Ini_01", context.localUtil.TToC( A2434Horario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2434Horario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_01_Internalname)));
                  AssignAttri("", false, "A2434Horario_Dia_Ini_01", context.localUtil.TToC( A2434Horario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Ini_02_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Ini_02"}), 1, "HORARIO_DIA_INI_02");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Ini_02_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2435Horario_Dia_Ini_02 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2435Horario_Dia_Ini_02", context.localUtil.TToC( A2435Horario_Dia_Ini_02, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2435Horario_Dia_Ini_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_02_Internalname)));
                  AssignAttri("", false, "A2435Horario_Dia_Ini_02", context.localUtil.TToC( A2435Horario_Dia_Ini_02, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Ini_03_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Ini_03"}), 1, "HORARIO_DIA_INI_03");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Ini_03_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2436Horario_Dia_Ini_03 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2436Horario_Dia_Ini_03", context.localUtil.TToC( A2436Horario_Dia_Ini_03, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2436Horario_Dia_Ini_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_03_Internalname)));
                  AssignAttri("", false, "A2436Horario_Dia_Ini_03", context.localUtil.TToC( A2436Horario_Dia_Ini_03, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Ini_04_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Ini_04"}), 1, "HORARIO_DIA_INI_04");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Ini_04_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2437Horario_Dia_Ini_04 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2437Horario_Dia_Ini_04", context.localUtil.TToC( A2437Horario_Dia_Ini_04, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2437Horario_Dia_Ini_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_04_Internalname)));
                  AssignAttri("", false, "A2437Horario_Dia_Ini_04", context.localUtil.TToC( A2437Horario_Dia_Ini_04, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Ini_05_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Ini_05"}), 1, "HORARIO_DIA_INI_05");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Ini_05_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2438Horario_Dia_Ini_05 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2438Horario_Dia_Ini_05", context.localUtil.TToC( A2438Horario_Dia_Ini_05, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2438Horario_Dia_Ini_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_05_Internalname)));
                  AssignAttri("", false, "A2438Horario_Dia_Ini_05", context.localUtil.TToC( A2438Horario_Dia_Ini_05, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Ini_06_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Ini_06"}), 1, "HORARIO_DIA_INI_06");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Ini_06_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2439Horario_Dia_Ini_06 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2439Horario_Dia_Ini_06", context.localUtil.TToC( A2439Horario_Dia_Ini_06, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2439Horario_Dia_Ini_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_06_Internalname)));
                  AssignAttri("", false, "A2439Horario_Dia_Ini_06", context.localUtil.TToC( A2439Horario_Dia_Ini_06, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Ini_07_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Ini_07"}), 1, "HORARIO_DIA_INI_07");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Ini_07_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2440Horario_Dia_Ini_07 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2440Horario_Dia_Ini_07", context.localUtil.TToC( A2440Horario_Dia_Ini_07, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2440Horario_Dia_Ini_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Ini_07_Internalname)));
                  AssignAttri("", false, "A2440Horario_Dia_Ini_07", context.localUtil.TToC( A2440Horario_Dia_Ini_07, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Ini_01_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Ini_01"}), 1, "HORARIO_REF_INI_01");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Ini_01_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2448Horario_Ref_Ini_01 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2448Horario_Ref_Ini_01", context.localUtil.TToC( A2448Horario_Ref_Ini_01, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2448Horario_Ref_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Ini_01_Internalname)));
                  AssignAttri("", false, "A2448Horario_Ref_Ini_01", context.localUtil.TToC( A2448Horario_Ref_Ini_01, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Ini_02_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Ini_02"}), 1, "HORARIO_REF_INI_02");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Ini_02_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2449Horario_Ref_Ini_02 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2449Horario_Ref_Ini_02", context.localUtil.TToC( A2449Horario_Ref_Ini_02, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2449Horario_Ref_Ini_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Ini_02_Internalname)));
                  AssignAttri("", false, "A2449Horario_Ref_Ini_02", context.localUtil.TToC( A2449Horario_Ref_Ini_02, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Ini_03_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Ini_03"}), 1, "HORARIO_REF_INI_03");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Ini_03_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2450Horario_Ref_Ini_03 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2450Horario_Ref_Ini_03", context.localUtil.TToC( A2450Horario_Ref_Ini_03, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2450Horario_Ref_Ini_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Ini_03_Internalname)));
                  AssignAttri("", false, "A2450Horario_Ref_Ini_03", context.localUtil.TToC( A2450Horario_Ref_Ini_03, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Ini_04_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Ini_04"}), 1, "HORARIO_REF_INI_04");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Ini_04_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2451Horario_Ref_Ini_04 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2451Horario_Ref_Ini_04", context.localUtil.TToC( A2451Horario_Ref_Ini_04, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2451Horario_Ref_Ini_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Ini_04_Internalname)));
                  AssignAttri("", false, "A2451Horario_Ref_Ini_04", context.localUtil.TToC( A2451Horario_Ref_Ini_04, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Ini_05_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Ini_05"}), 1, "HORARIO_REF_INI_05");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Ini_05_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2452Horario_Ref_Ini_05 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2452Horario_Ref_Ini_05", context.localUtil.TToC( A2452Horario_Ref_Ini_05, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2452Horario_Ref_Ini_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Ini_05_Internalname)));
                  AssignAttri("", false, "A2452Horario_Ref_Ini_05", context.localUtil.TToC( A2452Horario_Ref_Ini_05, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Ini_06_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Ini_06"}), 1, "HORARIO_REF_INI_06");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Ini_06_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2453Horario_Ref_Ini_06 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2453Horario_Ref_Ini_06", context.localUtil.TToC( A2453Horario_Ref_Ini_06, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2453Horario_Ref_Ini_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Ini_06_Internalname)));
                  AssignAttri("", false, "A2453Horario_Ref_Ini_06", context.localUtil.TToC( A2453Horario_Ref_Ini_06, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Ini_07_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Ini_07"}), 1, "HORARIO_REF_INI_07");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Ini_07_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2454Horario_Ref_Ini_07 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2454Horario_Ref_Ini_07", context.localUtil.TToC( A2454Horario_Ref_Ini_07, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2454Horario_Ref_Ini_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Ini_07_Internalname)));
                  AssignAttri("", false, "A2454Horario_Ref_Ini_07", context.localUtil.TToC( A2454Horario_Ref_Ini_07, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Fin_01_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Fin_01"}), 1, "HORARIO_REF_FIN_01");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Fin_01_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2455Horario_Ref_Fin_01 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2455Horario_Ref_Fin_01", context.localUtil.TToC( A2455Horario_Ref_Fin_01, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2455Horario_Ref_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Fin_01_Internalname)));
                  AssignAttri("", false, "A2455Horario_Ref_Fin_01", context.localUtil.TToC( A2455Horario_Ref_Fin_01, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Fin_02_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Fin_02"}), 1, "HORARIO_REF_FIN_02");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Fin_02_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2456Horario_Ref_Fin_02 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2456Horario_Ref_Fin_02", context.localUtil.TToC( A2456Horario_Ref_Fin_02, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2456Horario_Ref_Fin_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Fin_02_Internalname)));
                  AssignAttri("", false, "A2456Horario_Ref_Fin_02", context.localUtil.TToC( A2456Horario_Ref_Fin_02, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Fin_03_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Fin_03"}), 1, "HORARIO_REF_FIN_03");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Fin_03_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2457Horario_Ref_Fin_03 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2457Horario_Ref_Fin_03", context.localUtil.TToC( A2457Horario_Ref_Fin_03, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2457Horario_Ref_Fin_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Fin_03_Internalname)));
                  AssignAttri("", false, "A2457Horario_Ref_Fin_03", context.localUtil.TToC( A2457Horario_Ref_Fin_03, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Fin_04_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Fin_04"}), 1, "HORARIO_REF_FIN_04");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Fin_04_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2458Horario_Ref_Fin_04 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2458Horario_Ref_Fin_04", context.localUtil.TToC( A2458Horario_Ref_Fin_04, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2458Horario_Ref_Fin_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Fin_04_Internalname)));
                  AssignAttri("", false, "A2458Horario_Ref_Fin_04", context.localUtil.TToC( A2458Horario_Ref_Fin_04, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Fin_05_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Fin_05"}), 1, "HORARIO_REF_FIN_05");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Fin_05_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2459Horario_Ref_Fin_05 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2459Horario_Ref_Fin_05", context.localUtil.TToC( A2459Horario_Ref_Fin_05, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2459Horario_Ref_Fin_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Fin_05_Internalname)));
                  AssignAttri("", false, "A2459Horario_Ref_Fin_05", context.localUtil.TToC( A2459Horario_Ref_Fin_05, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Fin_06_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Fin_06"}), 1, "HORARIO_REF_FIN_06");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Fin_06_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2460Horario_Ref_Fin_06 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2460Horario_Ref_Fin_06", context.localUtil.TToC( A2460Horario_Ref_Fin_06, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2460Horario_Ref_Fin_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Fin_06_Internalname)));
                  AssignAttri("", false, "A2460Horario_Ref_Fin_06", context.localUtil.TToC( A2460Horario_Ref_Fin_06, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Ref_Fin_07_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Ref_Fin_07"}), 1, "HORARIO_REF_FIN_07");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Ref_Fin_07_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2461Horario_Ref_Fin_07 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2461Horario_Ref_Fin_07", context.localUtil.TToC( A2461Horario_Ref_Fin_07, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2461Horario_Ref_Fin_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Ref_Fin_07_Internalname)));
                  AssignAttri("", false, "A2461Horario_Ref_Fin_07", context.localUtil.TToC( A2461Horario_Ref_Fin_07, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Fin_01_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Fin_01"}), 1, "HORARIO_DIA_FIN_01");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Fin_01_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2441Horario_Dia_Fin_01", context.localUtil.TToC( A2441Horario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2441Horario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_01_Internalname)));
                  AssignAttri("", false, "A2441Horario_Dia_Fin_01", context.localUtil.TToC( A2441Horario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Fin_02_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Fin_02"}), 1, "HORARIO_DIA_FIN_02");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Fin_02_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2442Horario_Dia_Fin_02 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2442Horario_Dia_Fin_02", context.localUtil.TToC( A2442Horario_Dia_Fin_02, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2442Horario_Dia_Fin_02 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_02_Internalname)));
                  AssignAttri("", false, "A2442Horario_Dia_Fin_02", context.localUtil.TToC( A2442Horario_Dia_Fin_02, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Fin_03_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Fin_03"}), 1, "HORARIO_DIA_FIN_03");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Fin_03_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2443Horario_Dia_Fin_03 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2443Horario_Dia_Fin_03", context.localUtil.TToC( A2443Horario_Dia_Fin_03, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2443Horario_Dia_Fin_03 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_03_Internalname)));
                  AssignAttri("", false, "A2443Horario_Dia_Fin_03", context.localUtil.TToC( A2443Horario_Dia_Fin_03, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Fin_04_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Fin_04"}), 1, "HORARIO_DIA_FIN_04");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Fin_04_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2444Horario_Dia_Fin_04 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2444Horario_Dia_Fin_04", context.localUtil.TToC( A2444Horario_Dia_Fin_04, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2444Horario_Dia_Fin_04 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_04_Internalname)));
                  AssignAttri("", false, "A2444Horario_Dia_Fin_04", context.localUtil.TToC( A2444Horario_Dia_Fin_04, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Fin_05_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Fin_05"}), 1, "HORARIO_DIA_FIN_05");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Fin_05_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2445Horario_Dia_Fin_05 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2445Horario_Dia_Fin_05", context.localUtil.TToC( A2445Horario_Dia_Fin_05, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2445Horario_Dia_Fin_05 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_05_Internalname)));
                  AssignAttri("", false, "A2445Horario_Dia_Fin_05", context.localUtil.TToC( A2445Horario_Dia_Fin_05, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Fin_06_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Fin_06"}), 1, "HORARIO_DIA_FIN_06");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Fin_06_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2446Horario_Dia_Fin_06 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2446Horario_Dia_Fin_06", context.localUtil.TToC( A2446Horario_Dia_Fin_06, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2446Horario_Dia_Fin_06 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_06_Internalname)));
                  AssignAttri("", false, "A2446Horario_Dia_Fin_06", context.localUtil.TToC( A2446Horario_Dia_Fin_06, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtHorario_Dia_Fin_07_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Horario_Dia_Fin_07"}), 1, "HORARIO_DIA_FIN_07");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_Dia_Fin_07_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A2447Horario_Dia_Fin_07 = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A2447Horario_Dia_Fin_07", context.localUtil.TToC( A2447Horario_Dia_Fin_07, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A2447Horario_Dia_Fin_07 = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtHorario_Dia_Fin_07_Internalname)));
                  AssignAttri("", false, "A2447Horario_Dia_Fin_07", context.localUtil.TToC( A2447Horario_Dia_Fin_07, 0, 5, 0, 3, "/", ":", " "));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Reloj_Horario");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Horario_Dia_TolRef", context.localUtil.Format( (decimal)(A2465Horario_Dia_TolRef), "ZZZZZZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A2432Horario_ID != Z2432Horario_ID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("reloj_interface\\reloj_horario:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A2432Horario_ID = (short)(NumberUtil.Val( GetPar( "Horario_ID"), "."));
                  AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
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
                     sMode213 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode213;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound213 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_7R0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "HORARIO_ID");
                        AnyError = 1;
                        GX_FocusControl = edtHorario_ID_Internalname;
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
                           E117R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E127R2 ();
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
            E127R2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll7R213( ) ;
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
            DisableAttributes7R213( ) ;
         }
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

      protected void CONFIRM_7R0( )
      {
         BeforeValidate7R213( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls7R213( ) ;
            }
            else
            {
               CheckExtendedTable7R213( ) ;
               CloseExtendedTableCursors7R213( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption7R0( )
      {
      }

      protected void E117R2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtHorario_Dia_Fin_07_Tooltiptext = "Hora Salida";
         AssignProp("", false, edtHorario_Dia_Fin_07_Internalname, "Tooltiptext", edtHorario_Dia_Fin_07_Tooltiptext, true);
         edtHorario_Dia_Fin_06_Tooltiptext = "Hora Salida";
         AssignProp("", false, edtHorario_Dia_Fin_06_Internalname, "Tooltiptext", edtHorario_Dia_Fin_06_Tooltiptext, true);
         edtHorario_Dia_Fin_05_Tooltiptext = "Hora Salida";
         AssignProp("", false, edtHorario_Dia_Fin_05_Internalname, "Tooltiptext", edtHorario_Dia_Fin_05_Tooltiptext, true);
         edtHorario_Dia_Fin_04_Tooltiptext = "Hora Salida";
         AssignProp("", false, edtHorario_Dia_Fin_04_Internalname, "Tooltiptext", edtHorario_Dia_Fin_04_Tooltiptext, true);
         edtHorario_Dia_Fin_03_Tooltiptext = "Hora Salida";
         AssignProp("", false, edtHorario_Dia_Fin_03_Internalname, "Tooltiptext", edtHorario_Dia_Fin_03_Tooltiptext, true);
         edtHorario_Dia_Fin_02_Tooltiptext = "Hora Salida";
         AssignProp("", false, edtHorario_Dia_Fin_02_Internalname, "Tooltiptext", edtHorario_Dia_Fin_02_Tooltiptext, true);
         edtHorario_Dia_Fin_01_Tooltiptext = "Hora Salida";
         AssignProp("", false, edtHorario_Dia_Fin_01_Internalname, "Tooltiptext", edtHorario_Dia_Fin_01_Tooltiptext, true);
         edtHorario_Ref_Fin_07_Tooltiptext = "Salida De Refrigero";
         AssignProp("", false, edtHorario_Ref_Fin_07_Internalname, "Tooltiptext", edtHorario_Ref_Fin_07_Tooltiptext, true);
         edtHorario_Ref_Fin_06_Tooltiptext = "Salida De Refrigero";
         AssignProp("", false, edtHorario_Ref_Fin_06_Internalname, "Tooltiptext", edtHorario_Ref_Fin_06_Tooltiptext, true);
         edtHorario_Ref_Fin_05_Tooltiptext = "Salida De Refrigero";
         AssignProp("", false, edtHorario_Ref_Fin_05_Internalname, "Tooltiptext", edtHorario_Ref_Fin_05_Tooltiptext, true);
         edtHorario_Ref_Fin_04_Tooltiptext = "Salida De Refrigero";
         AssignProp("", false, edtHorario_Ref_Fin_04_Internalname, "Tooltiptext", edtHorario_Ref_Fin_04_Tooltiptext, true);
         edtHorario_Ref_Fin_03_Tooltiptext = "Salida De Refrigero";
         AssignProp("", false, edtHorario_Ref_Fin_03_Internalname, "Tooltiptext", edtHorario_Ref_Fin_03_Tooltiptext, true);
         edtHorario_Ref_Fin_02_Tooltiptext = "Salida De Refrigero";
         AssignProp("", false, edtHorario_Ref_Fin_02_Internalname, "Tooltiptext", edtHorario_Ref_Fin_02_Tooltiptext, true);
         edtHorario_Ref_Fin_01_Tooltiptext = "Salida De Refrigero";
         AssignProp("", false, edtHorario_Ref_Fin_01_Internalname, "Tooltiptext", edtHorario_Ref_Fin_01_Tooltiptext, true);
         edtHorario_Ref_Ini_07_Tooltiptext = "Ingreso al refrigerio";
         AssignProp("", false, edtHorario_Ref_Ini_07_Internalname, "Tooltiptext", edtHorario_Ref_Ini_07_Tooltiptext, true);
         edtHorario_Ref_Ini_06_Tooltiptext = "Ingreso al refrigerio";
         AssignProp("", false, edtHorario_Ref_Ini_06_Internalname, "Tooltiptext", edtHorario_Ref_Ini_06_Tooltiptext, true);
         edtHorario_Ref_Ini_05_Tooltiptext = "Ingreso al refrigerio";
         AssignProp("", false, edtHorario_Ref_Ini_05_Internalname, "Tooltiptext", edtHorario_Ref_Ini_05_Tooltiptext, true);
         edtHorario_Ref_Ini_04_Tooltiptext = "Ingreso al refrigerio";
         AssignProp("", false, edtHorario_Ref_Ini_04_Internalname, "Tooltiptext", edtHorario_Ref_Ini_04_Tooltiptext, true);
         edtHorario_Ref_Ini_03_Tooltiptext = "Ingreso al refrigerio";
         AssignProp("", false, edtHorario_Ref_Ini_03_Internalname, "Tooltiptext", edtHorario_Ref_Ini_03_Tooltiptext, true);
         edtHorario_Ref_Ini_02_Tooltiptext = "Ingreso al refrigerio";
         AssignProp("", false, edtHorario_Ref_Ini_02_Internalname, "Tooltiptext", edtHorario_Ref_Ini_02_Tooltiptext, true);
         edtHorario_Ref_Ini_01_Tooltiptext = "Ingreso al refrigerio";
         AssignProp("", false, edtHorario_Ref_Ini_01_Internalname, "Tooltiptext", edtHorario_Ref_Ini_01_Tooltiptext, true);
         edtHorario_Dia_Ini_07_Tooltiptext = "Hora Ingreso";
         AssignProp("", false, edtHorario_Dia_Ini_07_Internalname, "Tooltiptext", edtHorario_Dia_Ini_07_Tooltiptext, true);
         edtHorario_Dia_Ini_06_Tooltiptext = "Hora Ingreso";
         AssignProp("", false, edtHorario_Dia_Ini_06_Internalname, "Tooltiptext", edtHorario_Dia_Ini_06_Tooltiptext, true);
         edtHorario_Dia_Ini_05_Tooltiptext = "Hora Ingreso";
         AssignProp("", false, edtHorario_Dia_Ini_05_Internalname, "Tooltiptext", edtHorario_Dia_Ini_05_Tooltiptext, true);
         edtHorario_Dia_Ini_04_Tooltiptext = "Hora Ingreso";
         AssignProp("", false, edtHorario_Dia_Ini_04_Internalname, "Tooltiptext", edtHorario_Dia_Ini_04_Tooltiptext, true);
         edtHorario_Dia_Ini_03_Tooltiptext = "Hora Ingreso";
         AssignProp("", false, edtHorario_Dia_Ini_03_Internalname, "Tooltiptext", edtHorario_Dia_Ini_03_Tooltiptext, true);
         edtHorario_Dia_Ini_02_Tooltiptext = "Hora Ingreso";
         AssignProp("", false, edtHorario_Dia_Ini_02_Internalname, "Tooltiptext", edtHorario_Dia_Ini_02_Tooltiptext, true);
         edtHorario_Dia_Ini_01_Tooltiptext = "Hora Ingreso";
         AssignProp("", false, edtHorario_Dia_Ini_01_Internalname, "Tooltiptext", edtHorario_Dia_Ini_01_Tooltiptext, true);
         edtHorario_Dia_TolSal_Tooltiptext = "Hor Ingreso";
         AssignProp("", false, edtHorario_Dia_TolSal_Internalname, "Tooltiptext", edtHorario_Dia_TolSal_Tooltiptext, true);
         edtHorario_Dia_Toling_Tooltiptext = "Hor Ingreso";
         AssignProp("", false, edtHorario_Dia_Toling_Internalname, "Tooltiptext", edtHorario_Dia_Toling_Tooltiptext, true);
         cmbHorario_Sts.TooltipText = "Hor Ingreso";
         AssignProp("", false, cmbHorario_Sts_Internalname, "Tooltiptext", cmbHorario_Sts.TooltipText, true);
         edtHorario_Vigencia_Tooltiptext = "Entra en Vigencia";
         AssignProp("", false, edtHorario_Vigencia_Internalname, "Tooltiptext", edtHorario_Vigencia_Tooltiptext, true);
         edtHorario_Dsc_Tooltiptext = "Descipción del Horario";
         AssignProp("", false, edtHorario_Dsc_Internalname, "Tooltiptext", edtHorario_Dsc_Tooltiptext, true);
         edtHorario_ID_Tooltiptext = "Codigo del Horario";
         AssignProp("", false, edtHorario_ID_Internalname, "Tooltiptext", edtHorario_ID_Tooltiptext, true);
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E127R2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("reloj_interface.reloj_horarioww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM7R213( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2433Horario_Dsc = T007R3_A2433Horario_Dsc[0];
               Z2434Horario_Dia_Ini_01 = T007R3_A2434Horario_Dia_Ini_01[0];
               Z2435Horario_Dia_Ini_02 = T007R3_A2435Horario_Dia_Ini_02[0];
               Z2436Horario_Dia_Ini_03 = T007R3_A2436Horario_Dia_Ini_03[0];
               Z2437Horario_Dia_Ini_04 = T007R3_A2437Horario_Dia_Ini_04[0];
               Z2438Horario_Dia_Ini_05 = T007R3_A2438Horario_Dia_Ini_05[0];
               Z2439Horario_Dia_Ini_06 = T007R3_A2439Horario_Dia_Ini_06[0];
               Z2440Horario_Dia_Ini_07 = T007R3_A2440Horario_Dia_Ini_07[0];
               Z2441Horario_Dia_Fin_01 = T007R3_A2441Horario_Dia_Fin_01[0];
               Z2442Horario_Dia_Fin_02 = T007R3_A2442Horario_Dia_Fin_02[0];
               Z2443Horario_Dia_Fin_03 = T007R3_A2443Horario_Dia_Fin_03[0];
               Z2444Horario_Dia_Fin_04 = T007R3_A2444Horario_Dia_Fin_04[0];
               Z2445Horario_Dia_Fin_05 = T007R3_A2445Horario_Dia_Fin_05[0];
               Z2446Horario_Dia_Fin_06 = T007R3_A2446Horario_Dia_Fin_06[0];
               Z2447Horario_Dia_Fin_07 = T007R3_A2447Horario_Dia_Fin_07[0];
               Z2448Horario_Ref_Ini_01 = T007R3_A2448Horario_Ref_Ini_01[0];
               Z2449Horario_Ref_Ini_02 = T007R3_A2449Horario_Ref_Ini_02[0];
               Z2450Horario_Ref_Ini_03 = T007R3_A2450Horario_Ref_Ini_03[0];
               Z2451Horario_Ref_Ini_04 = T007R3_A2451Horario_Ref_Ini_04[0];
               Z2452Horario_Ref_Ini_05 = T007R3_A2452Horario_Ref_Ini_05[0];
               Z2453Horario_Ref_Ini_06 = T007R3_A2453Horario_Ref_Ini_06[0];
               Z2454Horario_Ref_Ini_07 = T007R3_A2454Horario_Ref_Ini_07[0];
               Z2455Horario_Ref_Fin_01 = T007R3_A2455Horario_Ref_Fin_01[0];
               Z2456Horario_Ref_Fin_02 = T007R3_A2456Horario_Ref_Fin_02[0];
               Z2457Horario_Ref_Fin_03 = T007R3_A2457Horario_Ref_Fin_03[0];
               Z2458Horario_Ref_Fin_04 = T007R3_A2458Horario_Ref_Fin_04[0];
               Z2459Horario_Ref_Fin_05 = T007R3_A2459Horario_Ref_Fin_05[0];
               Z2460Horario_Ref_Fin_06 = T007R3_A2460Horario_Ref_Fin_06[0];
               Z2461Horario_Ref_Fin_07 = T007R3_A2461Horario_Ref_Fin_07[0];
               Z2462Horario_Vigencia = T007R3_A2462Horario_Vigencia[0];
               Z2463Horario_Sts = T007R3_A2463Horario_Sts[0];
               Z2464Horario_Dia_Toling = T007R3_A2464Horario_Dia_Toling[0];
               Z2465Horario_Dia_TolRef = T007R3_A2465Horario_Dia_TolRef[0];
               Z2466Horario_Dia_TolSal = T007R3_A2466Horario_Dia_TolSal[0];
            }
            else
            {
               Z2433Horario_Dsc = A2433Horario_Dsc;
               Z2434Horario_Dia_Ini_01 = A2434Horario_Dia_Ini_01;
               Z2435Horario_Dia_Ini_02 = A2435Horario_Dia_Ini_02;
               Z2436Horario_Dia_Ini_03 = A2436Horario_Dia_Ini_03;
               Z2437Horario_Dia_Ini_04 = A2437Horario_Dia_Ini_04;
               Z2438Horario_Dia_Ini_05 = A2438Horario_Dia_Ini_05;
               Z2439Horario_Dia_Ini_06 = A2439Horario_Dia_Ini_06;
               Z2440Horario_Dia_Ini_07 = A2440Horario_Dia_Ini_07;
               Z2441Horario_Dia_Fin_01 = A2441Horario_Dia_Fin_01;
               Z2442Horario_Dia_Fin_02 = A2442Horario_Dia_Fin_02;
               Z2443Horario_Dia_Fin_03 = A2443Horario_Dia_Fin_03;
               Z2444Horario_Dia_Fin_04 = A2444Horario_Dia_Fin_04;
               Z2445Horario_Dia_Fin_05 = A2445Horario_Dia_Fin_05;
               Z2446Horario_Dia_Fin_06 = A2446Horario_Dia_Fin_06;
               Z2447Horario_Dia_Fin_07 = A2447Horario_Dia_Fin_07;
               Z2448Horario_Ref_Ini_01 = A2448Horario_Ref_Ini_01;
               Z2449Horario_Ref_Ini_02 = A2449Horario_Ref_Ini_02;
               Z2450Horario_Ref_Ini_03 = A2450Horario_Ref_Ini_03;
               Z2451Horario_Ref_Ini_04 = A2451Horario_Ref_Ini_04;
               Z2452Horario_Ref_Ini_05 = A2452Horario_Ref_Ini_05;
               Z2453Horario_Ref_Ini_06 = A2453Horario_Ref_Ini_06;
               Z2454Horario_Ref_Ini_07 = A2454Horario_Ref_Ini_07;
               Z2455Horario_Ref_Fin_01 = A2455Horario_Ref_Fin_01;
               Z2456Horario_Ref_Fin_02 = A2456Horario_Ref_Fin_02;
               Z2457Horario_Ref_Fin_03 = A2457Horario_Ref_Fin_03;
               Z2458Horario_Ref_Fin_04 = A2458Horario_Ref_Fin_04;
               Z2459Horario_Ref_Fin_05 = A2459Horario_Ref_Fin_05;
               Z2460Horario_Ref_Fin_06 = A2460Horario_Ref_Fin_06;
               Z2461Horario_Ref_Fin_07 = A2461Horario_Ref_Fin_07;
               Z2462Horario_Vigencia = A2462Horario_Vigencia;
               Z2463Horario_Sts = A2463Horario_Sts;
               Z2464Horario_Dia_Toling = A2464Horario_Dia_Toling;
               Z2465Horario_Dia_TolRef = A2465Horario_Dia_TolRef;
               Z2466Horario_Dia_TolSal = A2466Horario_Dia_TolSal;
            }
         }
         if ( GX_JID == -6 )
         {
            Z2432Horario_ID = A2432Horario_ID;
            Z2433Horario_Dsc = A2433Horario_Dsc;
            Z2434Horario_Dia_Ini_01 = A2434Horario_Dia_Ini_01;
            Z2435Horario_Dia_Ini_02 = A2435Horario_Dia_Ini_02;
            Z2436Horario_Dia_Ini_03 = A2436Horario_Dia_Ini_03;
            Z2437Horario_Dia_Ini_04 = A2437Horario_Dia_Ini_04;
            Z2438Horario_Dia_Ini_05 = A2438Horario_Dia_Ini_05;
            Z2439Horario_Dia_Ini_06 = A2439Horario_Dia_Ini_06;
            Z2440Horario_Dia_Ini_07 = A2440Horario_Dia_Ini_07;
            Z2441Horario_Dia_Fin_01 = A2441Horario_Dia_Fin_01;
            Z2442Horario_Dia_Fin_02 = A2442Horario_Dia_Fin_02;
            Z2443Horario_Dia_Fin_03 = A2443Horario_Dia_Fin_03;
            Z2444Horario_Dia_Fin_04 = A2444Horario_Dia_Fin_04;
            Z2445Horario_Dia_Fin_05 = A2445Horario_Dia_Fin_05;
            Z2446Horario_Dia_Fin_06 = A2446Horario_Dia_Fin_06;
            Z2447Horario_Dia_Fin_07 = A2447Horario_Dia_Fin_07;
            Z2448Horario_Ref_Ini_01 = A2448Horario_Ref_Ini_01;
            Z2449Horario_Ref_Ini_02 = A2449Horario_Ref_Ini_02;
            Z2450Horario_Ref_Ini_03 = A2450Horario_Ref_Ini_03;
            Z2451Horario_Ref_Ini_04 = A2451Horario_Ref_Ini_04;
            Z2452Horario_Ref_Ini_05 = A2452Horario_Ref_Ini_05;
            Z2453Horario_Ref_Ini_06 = A2453Horario_Ref_Ini_06;
            Z2454Horario_Ref_Ini_07 = A2454Horario_Ref_Ini_07;
            Z2455Horario_Ref_Fin_01 = A2455Horario_Ref_Fin_01;
            Z2456Horario_Ref_Fin_02 = A2456Horario_Ref_Fin_02;
            Z2457Horario_Ref_Fin_03 = A2457Horario_Ref_Fin_03;
            Z2458Horario_Ref_Fin_04 = A2458Horario_Ref_Fin_04;
            Z2459Horario_Ref_Fin_05 = A2459Horario_Ref_Fin_05;
            Z2460Horario_Ref_Fin_06 = A2460Horario_Ref_Fin_06;
            Z2461Horario_Ref_Fin_07 = A2461Horario_Ref_Fin_07;
            Z2462Horario_Vigencia = A2462Horario_Vigencia;
            Z2463Horario_Sts = A2463Horario_Sts;
            Z2464Horario_Dia_Toling = A2464Horario_Dia_Toling;
            Z2465Horario_Dia_TolRef = A2465Horario_Dia_TolRef;
            Z2466Horario_Dia_TolSal = A2466Horario_Dia_TolSal;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7Horario_ID) )
         {
            A2432Horario_ID = AV7Horario_ID;
            AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
         }
         if ( ! (0==AV7Horario_ID) )
         {
            edtHorario_ID_Enabled = 0;
            AssignProp("", false, edtHorario_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_ID_Enabled), 5, 0), true);
         }
         else
         {
            edtHorario_ID_Enabled = 1;
            AssignProp("", false, edtHorario_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_ID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7Horario_ID) )
         {
            edtHorario_ID_Enabled = 0;
            AssignProp("", false, edtHorario_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_ID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
         if ( IsIns( )  && (0==A2463Horario_Sts) && ( Gx_BScreen == 0 ) )
         {
            A2463Horario_Sts = 1;
            AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
         }
      }

      protected void Load7R213( )
      {
         /* Using cursor T007R4 */
         pr_default.execute(2, new Object[] {A2432Horario_ID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound213 = 1;
            A2433Horario_Dsc = T007R4_A2433Horario_Dsc[0];
            AssignAttri("", false, "A2433Horario_Dsc", A2433Horario_Dsc);
            A2434Horario_Dia_Ini_01 = T007R4_A2434Horario_Dia_Ini_01[0];
            AssignAttri("", false, "A2434Horario_Dia_Ini_01", context.localUtil.TToC( A2434Horario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " "));
            A2435Horario_Dia_Ini_02 = T007R4_A2435Horario_Dia_Ini_02[0];
            AssignAttri("", false, "A2435Horario_Dia_Ini_02", context.localUtil.TToC( A2435Horario_Dia_Ini_02, 0, 5, 0, 3, "/", ":", " "));
            A2436Horario_Dia_Ini_03 = T007R4_A2436Horario_Dia_Ini_03[0];
            AssignAttri("", false, "A2436Horario_Dia_Ini_03", context.localUtil.TToC( A2436Horario_Dia_Ini_03, 0, 5, 0, 3, "/", ":", " "));
            A2437Horario_Dia_Ini_04 = T007R4_A2437Horario_Dia_Ini_04[0];
            AssignAttri("", false, "A2437Horario_Dia_Ini_04", context.localUtil.TToC( A2437Horario_Dia_Ini_04, 0, 5, 0, 3, "/", ":", " "));
            A2438Horario_Dia_Ini_05 = T007R4_A2438Horario_Dia_Ini_05[0];
            AssignAttri("", false, "A2438Horario_Dia_Ini_05", context.localUtil.TToC( A2438Horario_Dia_Ini_05, 0, 5, 0, 3, "/", ":", " "));
            A2439Horario_Dia_Ini_06 = T007R4_A2439Horario_Dia_Ini_06[0];
            AssignAttri("", false, "A2439Horario_Dia_Ini_06", context.localUtil.TToC( A2439Horario_Dia_Ini_06, 0, 5, 0, 3, "/", ":", " "));
            A2440Horario_Dia_Ini_07 = T007R4_A2440Horario_Dia_Ini_07[0];
            AssignAttri("", false, "A2440Horario_Dia_Ini_07", context.localUtil.TToC( A2440Horario_Dia_Ini_07, 0, 5, 0, 3, "/", ":", " "));
            A2441Horario_Dia_Fin_01 = T007R4_A2441Horario_Dia_Fin_01[0];
            AssignAttri("", false, "A2441Horario_Dia_Fin_01", context.localUtil.TToC( A2441Horario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " "));
            A2442Horario_Dia_Fin_02 = T007R4_A2442Horario_Dia_Fin_02[0];
            AssignAttri("", false, "A2442Horario_Dia_Fin_02", context.localUtil.TToC( A2442Horario_Dia_Fin_02, 0, 5, 0, 3, "/", ":", " "));
            A2443Horario_Dia_Fin_03 = T007R4_A2443Horario_Dia_Fin_03[0];
            AssignAttri("", false, "A2443Horario_Dia_Fin_03", context.localUtil.TToC( A2443Horario_Dia_Fin_03, 0, 5, 0, 3, "/", ":", " "));
            A2444Horario_Dia_Fin_04 = T007R4_A2444Horario_Dia_Fin_04[0];
            AssignAttri("", false, "A2444Horario_Dia_Fin_04", context.localUtil.TToC( A2444Horario_Dia_Fin_04, 0, 5, 0, 3, "/", ":", " "));
            A2445Horario_Dia_Fin_05 = T007R4_A2445Horario_Dia_Fin_05[0];
            AssignAttri("", false, "A2445Horario_Dia_Fin_05", context.localUtil.TToC( A2445Horario_Dia_Fin_05, 0, 5, 0, 3, "/", ":", " "));
            A2446Horario_Dia_Fin_06 = T007R4_A2446Horario_Dia_Fin_06[0];
            AssignAttri("", false, "A2446Horario_Dia_Fin_06", context.localUtil.TToC( A2446Horario_Dia_Fin_06, 0, 5, 0, 3, "/", ":", " "));
            A2447Horario_Dia_Fin_07 = T007R4_A2447Horario_Dia_Fin_07[0];
            AssignAttri("", false, "A2447Horario_Dia_Fin_07", context.localUtil.TToC( A2447Horario_Dia_Fin_07, 0, 5, 0, 3, "/", ":", " "));
            A2448Horario_Ref_Ini_01 = T007R4_A2448Horario_Ref_Ini_01[0];
            AssignAttri("", false, "A2448Horario_Ref_Ini_01", context.localUtil.TToC( A2448Horario_Ref_Ini_01, 0, 5, 0, 3, "/", ":", " "));
            A2449Horario_Ref_Ini_02 = T007R4_A2449Horario_Ref_Ini_02[0];
            AssignAttri("", false, "A2449Horario_Ref_Ini_02", context.localUtil.TToC( A2449Horario_Ref_Ini_02, 0, 5, 0, 3, "/", ":", " "));
            A2450Horario_Ref_Ini_03 = T007R4_A2450Horario_Ref_Ini_03[0];
            AssignAttri("", false, "A2450Horario_Ref_Ini_03", context.localUtil.TToC( A2450Horario_Ref_Ini_03, 0, 5, 0, 3, "/", ":", " "));
            A2451Horario_Ref_Ini_04 = T007R4_A2451Horario_Ref_Ini_04[0];
            AssignAttri("", false, "A2451Horario_Ref_Ini_04", context.localUtil.TToC( A2451Horario_Ref_Ini_04, 0, 5, 0, 3, "/", ":", " "));
            A2452Horario_Ref_Ini_05 = T007R4_A2452Horario_Ref_Ini_05[0];
            AssignAttri("", false, "A2452Horario_Ref_Ini_05", context.localUtil.TToC( A2452Horario_Ref_Ini_05, 0, 5, 0, 3, "/", ":", " "));
            A2453Horario_Ref_Ini_06 = T007R4_A2453Horario_Ref_Ini_06[0];
            AssignAttri("", false, "A2453Horario_Ref_Ini_06", context.localUtil.TToC( A2453Horario_Ref_Ini_06, 0, 5, 0, 3, "/", ":", " "));
            A2454Horario_Ref_Ini_07 = T007R4_A2454Horario_Ref_Ini_07[0];
            AssignAttri("", false, "A2454Horario_Ref_Ini_07", context.localUtil.TToC( A2454Horario_Ref_Ini_07, 0, 5, 0, 3, "/", ":", " "));
            A2455Horario_Ref_Fin_01 = T007R4_A2455Horario_Ref_Fin_01[0];
            AssignAttri("", false, "A2455Horario_Ref_Fin_01", context.localUtil.TToC( A2455Horario_Ref_Fin_01, 0, 5, 0, 3, "/", ":", " "));
            A2456Horario_Ref_Fin_02 = T007R4_A2456Horario_Ref_Fin_02[0];
            AssignAttri("", false, "A2456Horario_Ref_Fin_02", context.localUtil.TToC( A2456Horario_Ref_Fin_02, 0, 5, 0, 3, "/", ":", " "));
            A2457Horario_Ref_Fin_03 = T007R4_A2457Horario_Ref_Fin_03[0];
            AssignAttri("", false, "A2457Horario_Ref_Fin_03", context.localUtil.TToC( A2457Horario_Ref_Fin_03, 0, 5, 0, 3, "/", ":", " "));
            A2458Horario_Ref_Fin_04 = T007R4_A2458Horario_Ref_Fin_04[0];
            AssignAttri("", false, "A2458Horario_Ref_Fin_04", context.localUtil.TToC( A2458Horario_Ref_Fin_04, 0, 5, 0, 3, "/", ":", " "));
            A2459Horario_Ref_Fin_05 = T007R4_A2459Horario_Ref_Fin_05[0];
            AssignAttri("", false, "A2459Horario_Ref_Fin_05", context.localUtil.TToC( A2459Horario_Ref_Fin_05, 0, 5, 0, 3, "/", ":", " "));
            A2460Horario_Ref_Fin_06 = T007R4_A2460Horario_Ref_Fin_06[0];
            AssignAttri("", false, "A2460Horario_Ref_Fin_06", context.localUtil.TToC( A2460Horario_Ref_Fin_06, 0, 5, 0, 3, "/", ":", " "));
            A2461Horario_Ref_Fin_07 = T007R4_A2461Horario_Ref_Fin_07[0];
            AssignAttri("", false, "A2461Horario_Ref_Fin_07", context.localUtil.TToC( A2461Horario_Ref_Fin_07, 0, 5, 0, 3, "/", ":", " "));
            A2462Horario_Vigencia = T007R4_A2462Horario_Vigencia[0];
            AssignAttri("", false, "A2462Horario_Vigencia", context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
            A2463Horario_Sts = T007R4_A2463Horario_Sts[0];
            AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
            A2464Horario_Dia_Toling = T007R4_A2464Horario_Dia_Toling[0];
            AssignAttri("", false, "A2464Horario_Dia_Toling", StringUtil.LTrimStr( (decimal)(A2464Horario_Dia_Toling), 9, 0));
            A2465Horario_Dia_TolRef = T007R4_A2465Horario_Dia_TolRef[0];
            A2466Horario_Dia_TolSal = T007R4_A2466Horario_Dia_TolSal[0];
            AssignAttri("", false, "A2466Horario_Dia_TolSal", StringUtil.LTrimStr( (decimal)(A2466Horario_Dia_TolSal), 9, 0));
            ZM7R213( -6) ;
         }
         pr_default.close(2);
         OnLoadActions7R213( ) ;
      }

      protected void OnLoadActions7R213( )
      {
      }

      protected void CheckExtendedTable7R213( )
      {
         nIsDirty_213 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A2462Horario_Vigencia) || ( A2462Horario_Vigencia >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Horario_Vigencia fuera de rango", "OutOfRange", 1, "HORARIO_VIGENCIA");
            AnyError = 1;
            GX_FocusControl = edtHorario_Vigencia_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors7R213( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey7R213( )
      {
         /* Using cursor T007R5 */
         pr_default.execute(3, new Object[] {A2432Horario_ID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound213 = 1;
         }
         else
         {
            RcdFound213 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007R3 */
         pr_default.execute(1, new Object[] {A2432Horario_ID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7R213( 6) ;
            RcdFound213 = 1;
            A2432Horario_ID = T007R3_A2432Horario_ID[0];
            AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
            A2433Horario_Dsc = T007R3_A2433Horario_Dsc[0];
            AssignAttri("", false, "A2433Horario_Dsc", A2433Horario_Dsc);
            A2434Horario_Dia_Ini_01 = T007R3_A2434Horario_Dia_Ini_01[0];
            AssignAttri("", false, "A2434Horario_Dia_Ini_01", context.localUtil.TToC( A2434Horario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " "));
            A2435Horario_Dia_Ini_02 = T007R3_A2435Horario_Dia_Ini_02[0];
            AssignAttri("", false, "A2435Horario_Dia_Ini_02", context.localUtil.TToC( A2435Horario_Dia_Ini_02, 0, 5, 0, 3, "/", ":", " "));
            A2436Horario_Dia_Ini_03 = T007R3_A2436Horario_Dia_Ini_03[0];
            AssignAttri("", false, "A2436Horario_Dia_Ini_03", context.localUtil.TToC( A2436Horario_Dia_Ini_03, 0, 5, 0, 3, "/", ":", " "));
            A2437Horario_Dia_Ini_04 = T007R3_A2437Horario_Dia_Ini_04[0];
            AssignAttri("", false, "A2437Horario_Dia_Ini_04", context.localUtil.TToC( A2437Horario_Dia_Ini_04, 0, 5, 0, 3, "/", ":", " "));
            A2438Horario_Dia_Ini_05 = T007R3_A2438Horario_Dia_Ini_05[0];
            AssignAttri("", false, "A2438Horario_Dia_Ini_05", context.localUtil.TToC( A2438Horario_Dia_Ini_05, 0, 5, 0, 3, "/", ":", " "));
            A2439Horario_Dia_Ini_06 = T007R3_A2439Horario_Dia_Ini_06[0];
            AssignAttri("", false, "A2439Horario_Dia_Ini_06", context.localUtil.TToC( A2439Horario_Dia_Ini_06, 0, 5, 0, 3, "/", ":", " "));
            A2440Horario_Dia_Ini_07 = T007R3_A2440Horario_Dia_Ini_07[0];
            AssignAttri("", false, "A2440Horario_Dia_Ini_07", context.localUtil.TToC( A2440Horario_Dia_Ini_07, 0, 5, 0, 3, "/", ":", " "));
            A2441Horario_Dia_Fin_01 = T007R3_A2441Horario_Dia_Fin_01[0];
            AssignAttri("", false, "A2441Horario_Dia_Fin_01", context.localUtil.TToC( A2441Horario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " "));
            A2442Horario_Dia_Fin_02 = T007R3_A2442Horario_Dia_Fin_02[0];
            AssignAttri("", false, "A2442Horario_Dia_Fin_02", context.localUtil.TToC( A2442Horario_Dia_Fin_02, 0, 5, 0, 3, "/", ":", " "));
            A2443Horario_Dia_Fin_03 = T007R3_A2443Horario_Dia_Fin_03[0];
            AssignAttri("", false, "A2443Horario_Dia_Fin_03", context.localUtil.TToC( A2443Horario_Dia_Fin_03, 0, 5, 0, 3, "/", ":", " "));
            A2444Horario_Dia_Fin_04 = T007R3_A2444Horario_Dia_Fin_04[0];
            AssignAttri("", false, "A2444Horario_Dia_Fin_04", context.localUtil.TToC( A2444Horario_Dia_Fin_04, 0, 5, 0, 3, "/", ":", " "));
            A2445Horario_Dia_Fin_05 = T007R3_A2445Horario_Dia_Fin_05[0];
            AssignAttri("", false, "A2445Horario_Dia_Fin_05", context.localUtil.TToC( A2445Horario_Dia_Fin_05, 0, 5, 0, 3, "/", ":", " "));
            A2446Horario_Dia_Fin_06 = T007R3_A2446Horario_Dia_Fin_06[0];
            AssignAttri("", false, "A2446Horario_Dia_Fin_06", context.localUtil.TToC( A2446Horario_Dia_Fin_06, 0, 5, 0, 3, "/", ":", " "));
            A2447Horario_Dia_Fin_07 = T007R3_A2447Horario_Dia_Fin_07[0];
            AssignAttri("", false, "A2447Horario_Dia_Fin_07", context.localUtil.TToC( A2447Horario_Dia_Fin_07, 0, 5, 0, 3, "/", ":", " "));
            A2448Horario_Ref_Ini_01 = T007R3_A2448Horario_Ref_Ini_01[0];
            AssignAttri("", false, "A2448Horario_Ref_Ini_01", context.localUtil.TToC( A2448Horario_Ref_Ini_01, 0, 5, 0, 3, "/", ":", " "));
            A2449Horario_Ref_Ini_02 = T007R3_A2449Horario_Ref_Ini_02[0];
            AssignAttri("", false, "A2449Horario_Ref_Ini_02", context.localUtil.TToC( A2449Horario_Ref_Ini_02, 0, 5, 0, 3, "/", ":", " "));
            A2450Horario_Ref_Ini_03 = T007R3_A2450Horario_Ref_Ini_03[0];
            AssignAttri("", false, "A2450Horario_Ref_Ini_03", context.localUtil.TToC( A2450Horario_Ref_Ini_03, 0, 5, 0, 3, "/", ":", " "));
            A2451Horario_Ref_Ini_04 = T007R3_A2451Horario_Ref_Ini_04[0];
            AssignAttri("", false, "A2451Horario_Ref_Ini_04", context.localUtil.TToC( A2451Horario_Ref_Ini_04, 0, 5, 0, 3, "/", ":", " "));
            A2452Horario_Ref_Ini_05 = T007R3_A2452Horario_Ref_Ini_05[0];
            AssignAttri("", false, "A2452Horario_Ref_Ini_05", context.localUtil.TToC( A2452Horario_Ref_Ini_05, 0, 5, 0, 3, "/", ":", " "));
            A2453Horario_Ref_Ini_06 = T007R3_A2453Horario_Ref_Ini_06[0];
            AssignAttri("", false, "A2453Horario_Ref_Ini_06", context.localUtil.TToC( A2453Horario_Ref_Ini_06, 0, 5, 0, 3, "/", ":", " "));
            A2454Horario_Ref_Ini_07 = T007R3_A2454Horario_Ref_Ini_07[0];
            AssignAttri("", false, "A2454Horario_Ref_Ini_07", context.localUtil.TToC( A2454Horario_Ref_Ini_07, 0, 5, 0, 3, "/", ":", " "));
            A2455Horario_Ref_Fin_01 = T007R3_A2455Horario_Ref_Fin_01[0];
            AssignAttri("", false, "A2455Horario_Ref_Fin_01", context.localUtil.TToC( A2455Horario_Ref_Fin_01, 0, 5, 0, 3, "/", ":", " "));
            A2456Horario_Ref_Fin_02 = T007R3_A2456Horario_Ref_Fin_02[0];
            AssignAttri("", false, "A2456Horario_Ref_Fin_02", context.localUtil.TToC( A2456Horario_Ref_Fin_02, 0, 5, 0, 3, "/", ":", " "));
            A2457Horario_Ref_Fin_03 = T007R3_A2457Horario_Ref_Fin_03[0];
            AssignAttri("", false, "A2457Horario_Ref_Fin_03", context.localUtil.TToC( A2457Horario_Ref_Fin_03, 0, 5, 0, 3, "/", ":", " "));
            A2458Horario_Ref_Fin_04 = T007R3_A2458Horario_Ref_Fin_04[0];
            AssignAttri("", false, "A2458Horario_Ref_Fin_04", context.localUtil.TToC( A2458Horario_Ref_Fin_04, 0, 5, 0, 3, "/", ":", " "));
            A2459Horario_Ref_Fin_05 = T007R3_A2459Horario_Ref_Fin_05[0];
            AssignAttri("", false, "A2459Horario_Ref_Fin_05", context.localUtil.TToC( A2459Horario_Ref_Fin_05, 0, 5, 0, 3, "/", ":", " "));
            A2460Horario_Ref_Fin_06 = T007R3_A2460Horario_Ref_Fin_06[0];
            AssignAttri("", false, "A2460Horario_Ref_Fin_06", context.localUtil.TToC( A2460Horario_Ref_Fin_06, 0, 5, 0, 3, "/", ":", " "));
            A2461Horario_Ref_Fin_07 = T007R3_A2461Horario_Ref_Fin_07[0];
            AssignAttri("", false, "A2461Horario_Ref_Fin_07", context.localUtil.TToC( A2461Horario_Ref_Fin_07, 0, 5, 0, 3, "/", ":", " "));
            A2462Horario_Vigencia = T007R3_A2462Horario_Vigencia[0];
            AssignAttri("", false, "A2462Horario_Vigencia", context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
            A2463Horario_Sts = T007R3_A2463Horario_Sts[0];
            AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
            A2464Horario_Dia_Toling = T007R3_A2464Horario_Dia_Toling[0];
            AssignAttri("", false, "A2464Horario_Dia_Toling", StringUtil.LTrimStr( (decimal)(A2464Horario_Dia_Toling), 9, 0));
            A2465Horario_Dia_TolRef = T007R3_A2465Horario_Dia_TolRef[0];
            A2466Horario_Dia_TolSal = T007R3_A2466Horario_Dia_TolSal[0];
            AssignAttri("", false, "A2466Horario_Dia_TolSal", StringUtil.LTrimStr( (decimal)(A2466Horario_Dia_TolSal), 9, 0));
            Z2432Horario_ID = A2432Horario_ID;
            sMode213 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load7R213( ) ;
            if ( AnyError == 1 )
            {
               RcdFound213 = 0;
               InitializeNonKey7R213( ) ;
            }
            Gx_mode = sMode213;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound213 = 0;
            InitializeNonKey7R213( ) ;
            sMode213 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode213;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7R213( ) ;
         if ( RcdFound213 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound213 = 0;
         /* Using cursor T007R6 */
         pr_default.execute(4, new Object[] {A2432Horario_ID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T007R6_A2432Horario_ID[0] < A2432Horario_ID ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T007R6_A2432Horario_ID[0] > A2432Horario_ID ) ) )
            {
               A2432Horario_ID = T007R6_A2432Horario_ID[0];
               AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
               RcdFound213 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound213 = 0;
         /* Using cursor T007R7 */
         pr_default.execute(5, new Object[] {A2432Horario_ID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T007R7_A2432Horario_ID[0] > A2432Horario_ID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T007R7_A2432Horario_ID[0] < A2432Horario_ID ) ) )
            {
               A2432Horario_ID = T007R7_A2432Horario_ID[0];
               AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
               RcdFound213 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7R213( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtHorario_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7R213( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound213 == 1 )
            {
               if ( A2432Horario_ID != Z2432Horario_ID )
               {
                  A2432Horario_ID = Z2432Horario_ID;
                  AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "HORARIO_ID");
                  AnyError = 1;
                  GX_FocusControl = edtHorario_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtHorario_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update7R213( ) ;
                  GX_FocusControl = edtHorario_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A2432Horario_ID != Z2432Horario_ID )
               {
                  /* Insert record */
                  GX_FocusControl = edtHorario_ID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7R213( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "HORARIO_ID");
                     AnyError = 1;
                     GX_FocusControl = edtHorario_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtHorario_ID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7R213( ) ;
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
         if ( A2432Horario_ID != Z2432Horario_ID )
         {
            A2432Horario_ID = Z2432Horario_ID;
            AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "HORARIO_ID");
            AnyError = 1;
            GX_FocusControl = edtHorario_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtHorario_ID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency7R213( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007R2 */
            pr_default.execute(0, new Object[] {A2432Horario_ID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj_Horario"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2433Horario_Dsc, T007R2_A2433Horario_Dsc[0]) != 0 ) || ( Z2434Horario_Dia_Ini_01 != T007R2_A2434Horario_Dia_Ini_01[0] ) || ( Z2435Horario_Dia_Ini_02 != T007R2_A2435Horario_Dia_Ini_02[0] ) || ( Z2436Horario_Dia_Ini_03 != T007R2_A2436Horario_Dia_Ini_03[0] ) || ( Z2437Horario_Dia_Ini_04 != T007R2_A2437Horario_Dia_Ini_04[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2438Horario_Dia_Ini_05 != T007R2_A2438Horario_Dia_Ini_05[0] ) || ( Z2439Horario_Dia_Ini_06 != T007R2_A2439Horario_Dia_Ini_06[0] ) || ( Z2440Horario_Dia_Ini_07 != T007R2_A2440Horario_Dia_Ini_07[0] ) || ( Z2441Horario_Dia_Fin_01 != T007R2_A2441Horario_Dia_Fin_01[0] ) || ( Z2442Horario_Dia_Fin_02 != T007R2_A2442Horario_Dia_Fin_02[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2443Horario_Dia_Fin_03 != T007R2_A2443Horario_Dia_Fin_03[0] ) || ( Z2444Horario_Dia_Fin_04 != T007R2_A2444Horario_Dia_Fin_04[0] ) || ( Z2445Horario_Dia_Fin_05 != T007R2_A2445Horario_Dia_Fin_05[0] ) || ( Z2446Horario_Dia_Fin_06 != T007R2_A2446Horario_Dia_Fin_06[0] ) || ( Z2447Horario_Dia_Fin_07 != T007R2_A2447Horario_Dia_Fin_07[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2448Horario_Ref_Ini_01 != T007R2_A2448Horario_Ref_Ini_01[0] ) || ( Z2449Horario_Ref_Ini_02 != T007R2_A2449Horario_Ref_Ini_02[0] ) || ( Z2450Horario_Ref_Ini_03 != T007R2_A2450Horario_Ref_Ini_03[0] ) || ( Z2451Horario_Ref_Ini_04 != T007R2_A2451Horario_Ref_Ini_04[0] ) || ( Z2452Horario_Ref_Ini_05 != T007R2_A2452Horario_Ref_Ini_05[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2453Horario_Ref_Ini_06 != T007R2_A2453Horario_Ref_Ini_06[0] ) || ( Z2454Horario_Ref_Ini_07 != T007R2_A2454Horario_Ref_Ini_07[0] ) || ( Z2455Horario_Ref_Fin_01 != T007R2_A2455Horario_Ref_Fin_01[0] ) || ( Z2456Horario_Ref_Fin_02 != T007R2_A2456Horario_Ref_Fin_02[0] ) || ( Z2457Horario_Ref_Fin_03 != T007R2_A2457Horario_Ref_Fin_03[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2458Horario_Ref_Fin_04 != T007R2_A2458Horario_Ref_Fin_04[0] ) || ( Z2459Horario_Ref_Fin_05 != T007R2_A2459Horario_Ref_Fin_05[0] ) || ( Z2460Horario_Ref_Fin_06 != T007R2_A2460Horario_Ref_Fin_06[0] ) || ( Z2461Horario_Ref_Fin_07 != T007R2_A2461Horario_Ref_Fin_07[0] ) || ( Z2462Horario_Vigencia != T007R2_A2462Horario_Vigencia[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2463Horario_Sts != T007R2_A2463Horario_Sts[0] ) || ( Z2464Horario_Dia_Toling != T007R2_A2464Horario_Dia_Toling[0] ) || ( Z2465Horario_Dia_TolRef != T007R2_A2465Horario_Dia_TolRef[0] ) || ( Z2466Horario_Dia_TolSal != T007R2_A2466Horario_Dia_TolSal[0] ) )
            {
               if ( StringUtil.StrCmp(Z2433Horario_Dsc, T007R2_A2433Horario_Dsc[0]) != 0 )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dsc");
                  GXUtil.WriteLogRaw("Old: ",Z2433Horario_Dsc);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2433Horario_Dsc[0]);
               }
               if ( Z2434Horario_Dia_Ini_01 != T007R2_A2434Horario_Dia_Ini_01[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Ini_01");
                  GXUtil.WriteLogRaw("Old: ",Z2434Horario_Dia_Ini_01);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2434Horario_Dia_Ini_01[0]);
               }
               if ( Z2435Horario_Dia_Ini_02 != T007R2_A2435Horario_Dia_Ini_02[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Ini_02");
                  GXUtil.WriteLogRaw("Old: ",Z2435Horario_Dia_Ini_02);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2435Horario_Dia_Ini_02[0]);
               }
               if ( Z2436Horario_Dia_Ini_03 != T007R2_A2436Horario_Dia_Ini_03[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Ini_03");
                  GXUtil.WriteLogRaw("Old: ",Z2436Horario_Dia_Ini_03);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2436Horario_Dia_Ini_03[0]);
               }
               if ( Z2437Horario_Dia_Ini_04 != T007R2_A2437Horario_Dia_Ini_04[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Ini_04");
                  GXUtil.WriteLogRaw("Old: ",Z2437Horario_Dia_Ini_04);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2437Horario_Dia_Ini_04[0]);
               }
               if ( Z2438Horario_Dia_Ini_05 != T007R2_A2438Horario_Dia_Ini_05[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Ini_05");
                  GXUtil.WriteLogRaw("Old: ",Z2438Horario_Dia_Ini_05);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2438Horario_Dia_Ini_05[0]);
               }
               if ( Z2439Horario_Dia_Ini_06 != T007R2_A2439Horario_Dia_Ini_06[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Ini_06");
                  GXUtil.WriteLogRaw("Old: ",Z2439Horario_Dia_Ini_06);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2439Horario_Dia_Ini_06[0]);
               }
               if ( Z2440Horario_Dia_Ini_07 != T007R2_A2440Horario_Dia_Ini_07[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Ini_07");
                  GXUtil.WriteLogRaw("Old: ",Z2440Horario_Dia_Ini_07);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2440Horario_Dia_Ini_07[0]);
               }
               if ( Z2441Horario_Dia_Fin_01 != T007R2_A2441Horario_Dia_Fin_01[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Fin_01");
                  GXUtil.WriteLogRaw("Old: ",Z2441Horario_Dia_Fin_01);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2441Horario_Dia_Fin_01[0]);
               }
               if ( Z2442Horario_Dia_Fin_02 != T007R2_A2442Horario_Dia_Fin_02[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Fin_02");
                  GXUtil.WriteLogRaw("Old: ",Z2442Horario_Dia_Fin_02);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2442Horario_Dia_Fin_02[0]);
               }
               if ( Z2443Horario_Dia_Fin_03 != T007R2_A2443Horario_Dia_Fin_03[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Fin_03");
                  GXUtil.WriteLogRaw("Old: ",Z2443Horario_Dia_Fin_03);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2443Horario_Dia_Fin_03[0]);
               }
               if ( Z2444Horario_Dia_Fin_04 != T007R2_A2444Horario_Dia_Fin_04[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Fin_04");
                  GXUtil.WriteLogRaw("Old: ",Z2444Horario_Dia_Fin_04);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2444Horario_Dia_Fin_04[0]);
               }
               if ( Z2445Horario_Dia_Fin_05 != T007R2_A2445Horario_Dia_Fin_05[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Fin_05");
                  GXUtil.WriteLogRaw("Old: ",Z2445Horario_Dia_Fin_05);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2445Horario_Dia_Fin_05[0]);
               }
               if ( Z2446Horario_Dia_Fin_06 != T007R2_A2446Horario_Dia_Fin_06[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Fin_06");
                  GXUtil.WriteLogRaw("Old: ",Z2446Horario_Dia_Fin_06);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2446Horario_Dia_Fin_06[0]);
               }
               if ( Z2447Horario_Dia_Fin_07 != T007R2_A2447Horario_Dia_Fin_07[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Fin_07");
                  GXUtil.WriteLogRaw("Old: ",Z2447Horario_Dia_Fin_07);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2447Horario_Dia_Fin_07[0]);
               }
               if ( Z2448Horario_Ref_Ini_01 != T007R2_A2448Horario_Ref_Ini_01[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Ini_01");
                  GXUtil.WriteLogRaw("Old: ",Z2448Horario_Ref_Ini_01);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2448Horario_Ref_Ini_01[0]);
               }
               if ( Z2449Horario_Ref_Ini_02 != T007R2_A2449Horario_Ref_Ini_02[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Ini_02");
                  GXUtil.WriteLogRaw("Old: ",Z2449Horario_Ref_Ini_02);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2449Horario_Ref_Ini_02[0]);
               }
               if ( Z2450Horario_Ref_Ini_03 != T007R2_A2450Horario_Ref_Ini_03[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Ini_03");
                  GXUtil.WriteLogRaw("Old: ",Z2450Horario_Ref_Ini_03);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2450Horario_Ref_Ini_03[0]);
               }
               if ( Z2451Horario_Ref_Ini_04 != T007R2_A2451Horario_Ref_Ini_04[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Ini_04");
                  GXUtil.WriteLogRaw("Old: ",Z2451Horario_Ref_Ini_04);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2451Horario_Ref_Ini_04[0]);
               }
               if ( Z2452Horario_Ref_Ini_05 != T007R2_A2452Horario_Ref_Ini_05[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Ini_05");
                  GXUtil.WriteLogRaw("Old: ",Z2452Horario_Ref_Ini_05);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2452Horario_Ref_Ini_05[0]);
               }
               if ( Z2453Horario_Ref_Ini_06 != T007R2_A2453Horario_Ref_Ini_06[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Ini_06");
                  GXUtil.WriteLogRaw("Old: ",Z2453Horario_Ref_Ini_06);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2453Horario_Ref_Ini_06[0]);
               }
               if ( Z2454Horario_Ref_Ini_07 != T007R2_A2454Horario_Ref_Ini_07[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Ini_07");
                  GXUtil.WriteLogRaw("Old: ",Z2454Horario_Ref_Ini_07);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2454Horario_Ref_Ini_07[0]);
               }
               if ( Z2455Horario_Ref_Fin_01 != T007R2_A2455Horario_Ref_Fin_01[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Fin_01");
                  GXUtil.WriteLogRaw("Old: ",Z2455Horario_Ref_Fin_01);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2455Horario_Ref_Fin_01[0]);
               }
               if ( Z2456Horario_Ref_Fin_02 != T007R2_A2456Horario_Ref_Fin_02[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Fin_02");
                  GXUtil.WriteLogRaw("Old: ",Z2456Horario_Ref_Fin_02);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2456Horario_Ref_Fin_02[0]);
               }
               if ( Z2457Horario_Ref_Fin_03 != T007R2_A2457Horario_Ref_Fin_03[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Fin_03");
                  GXUtil.WriteLogRaw("Old: ",Z2457Horario_Ref_Fin_03);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2457Horario_Ref_Fin_03[0]);
               }
               if ( Z2458Horario_Ref_Fin_04 != T007R2_A2458Horario_Ref_Fin_04[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Fin_04");
                  GXUtil.WriteLogRaw("Old: ",Z2458Horario_Ref_Fin_04);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2458Horario_Ref_Fin_04[0]);
               }
               if ( Z2459Horario_Ref_Fin_05 != T007R2_A2459Horario_Ref_Fin_05[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Fin_05");
                  GXUtil.WriteLogRaw("Old: ",Z2459Horario_Ref_Fin_05);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2459Horario_Ref_Fin_05[0]);
               }
               if ( Z2460Horario_Ref_Fin_06 != T007R2_A2460Horario_Ref_Fin_06[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Fin_06");
                  GXUtil.WriteLogRaw("Old: ",Z2460Horario_Ref_Fin_06);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2460Horario_Ref_Fin_06[0]);
               }
               if ( Z2461Horario_Ref_Fin_07 != T007R2_A2461Horario_Ref_Fin_07[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Ref_Fin_07");
                  GXUtil.WriteLogRaw("Old: ",Z2461Horario_Ref_Fin_07);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2461Horario_Ref_Fin_07[0]);
               }
               if ( Z2462Horario_Vigencia != T007R2_A2462Horario_Vigencia[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Vigencia");
                  GXUtil.WriteLogRaw("Old: ",Z2462Horario_Vigencia);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2462Horario_Vigencia[0]);
               }
               if ( Z2463Horario_Sts != T007R2_A2463Horario_Sts[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Sts");
                  GXUtil.WriteLogRaw("Old: ",Z2463Horario_Sts);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2463Horario_Sts[0]);
               }
               if ( Z2464Horario_Dia_Toling != T007R2_A2464Horario_Dia_Toling[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_Toling");
                  GXUtil.WriteLogRaw("Old: ",Z2464Horario_Dia_Toling);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2464Horario_Dia_Toling[0]);
               }
               if ( Z2465Horario_Dia_TolRef != T007R2_A2465Horario_Dia_TolRef[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_TolRef");
                  GXUtil.WriteLogRaw("Old: ",Z2465Horario_Dia_TolRef);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2465Horario_Dia_TolRef[0]);
               }
               if ( Z2466Horario_Dia_TolSal != T007R2_A2466Horario_Dia_TolSal[0] )
               {
                  GXUtil.WriteLog("reloj_interface.reloj_horario:[seudo value changed for attri]"+"Horario_Dia_TolSal");
                  GXUtil.WriteLogRaw("Old: ",Z2466Horario_Dia_TolSal);
                  GXUtil.WriteLogRaw("Current: ",T007R2_A2466Horario_Dia_TolSal[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Reloj_Horario"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7R213( )
      {
         BeforeValidate7R213( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7R213( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7R213( 0) ;
            CheckOptimisticConcurrency7R213( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7R213( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7R213( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007R8 */
                     pr_default.execute(6, new Object[] {A2432Horario_ID, A2433Horario_Dsc, A2434Horario_Dia_Ini_01, A2435Horario_Dia_Ini_02, A2436Horario_Dia_Ini_03, A2437Horario_Dia_Ini_04, A2438Horario_Dia_Ini_05, A2439Horario_Dia_Ini_06, A2440Horario_Dia_Ini_07, A2441Horario_Dia_Fin_01, A2442Horario_Dia_Fin_02, A2443Horario_Dia_Fin_03, A2444Horario_Dia_Fin_04, A2445Horario_Dia_Fin_05, A2446Horario_Dia_Fin_06, A2447Horario_Dia_Fin_07, A2448Horario_Ref_Ini_01, A2449Horario_Ref_Ini_02, A2450Horario_Ref_Ini_03, A2451Horario_Ref_Ini_04, A2452Horario_Ref_Ini_05, A2453Horario_Ref_Ini_06, A2454Horario_Ref_Ini_07, A2455Horario_Ref_Fin_01, A2456Horario_Ref_Fin_02, A2457Horario_Ref_Fin_03, A2458Horario_Ref_Fin_04, A2459Horario_Ref_Fin_05, A2460Horario_Ref_Fin_06, A2461Horario_Ref_Fin_07, A2462Horario_Vigencia, A2463Horario_Sts, A2464Horario_Dia_Toling, A2465Horario_Dia_TolRef, A2466Horario_Dia_TolSal});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj_Horario");
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
                           ResetCaption7R0( ) ;
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
               Load7R213( ) ;
            }
            EndLevel7R213( ) ;
         }
         CloseExtendedTableCursors7R213( ) ;
      }

      protected void Update7R213( )
      {
         BeforeValidate7R213( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7R213( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7R213( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7R213( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7R213( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007R9 */
                     pr_default.execute(7, new Object[] {A2433Horario_Dsc, A2434Horario_Dia_Ini_01, A2435Horario_Dia_Ini_02, A2436Horario_Dia_Ini_03, A2437Horario_Dia_Ini_04, A2438Horario_Dia_Ini_05, A2439Horario_Dia_Ini_06, A2440Horario_Dia_Ini_07, A2441Horario_Dia_Fin_01, A2442Horario_Dia_Fin_02, A2443Horario_Dia_Fin_03, A2444Horario_Dia_Fin_04, A2445Horario_Dia_Fin_05, A2446Horario_Dia_Fin_06, A2447Horario_Dia_Fin_07, A2448Horario_Ref_Ini_01, A2449Horario_Ref_Ini_02, A2450Horario_Ref_Ini_03, A2451Horario_Ref_Ini_04, A2452Horario_Ref_Ini_05, A2453Horario_Ref_Ini_06, A2454Horario_Ref_Ini_07, A2455Horario_Ref_Fin_01, A2456Horario_Ref_Fin_02, A2457Horario_Ref_Fin_03, A2458Horario_Ref_Fin_04, A2459Horario_Ref_Fin_05, A2460Horario_Ref_Fin_06, A2461Horario_Ref_Fin_07, A2462Horario_Vigencia, A2463Horario_Sts, A2464Horario_Dia_Toling, A2465Horario_Dia_TolRef, A2466Horario_Dia_TolSal, A2432Horario_ID});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("Reloj_Horario");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Reloj_Horario"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7R213( ) ;
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
            EndLevel7R213( ) ;
         }
         CloseExtendedTableCursors7R213( ) ;
      }

      protected void DeferredUpdate7R213( )
      {
      }

      protected void delete( )
      {
         BeforeValidate7R213( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7R213( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7R213( ) ;
            AfterConfirm7R213( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7R213( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007R10 */
                  pr_default.execute(8, new Object[] {A2432Horario_ID});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("Reloj_Horario");
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
         sMode213 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7R213( ) ;
         Gx_mode = sMode213;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7R213( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel7R213( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7R213( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("reloj_interface.reloj_horario",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("reloj_interface.reloj_horario",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7R213( )
      {
         /* Scan By routine */
         /* Using cursor T007R11 */
         pr_default.execute(9);
         RcdFound213 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound213 = 1;
            A2432Horario_ID = T007R11_A2432Horario_ID[0];
            AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7R213( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound213 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound213 = 1;
            A2432Horario_ID = T007R11_A2432Horario_ID[0];
            AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
         }
      }

      protected void ScanEnd7R213( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm7R213( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7R213( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7R213( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7R213( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7R213( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7R213( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7R213( )
      {
         edtHorario_ID_Enabled = 0;
         AssignProp("", false, edtHorario_ID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_ID_Enabled), 5, 0), true);
         edtHorario_Dsc_Enabled = 0;
         AssignProp("", false, edtHorario_Dsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dsc_Enabled), 5, 0), true);
         edtHorario_Vigencia_Enabled = 0;
         AssignProp("", false, edtHorario_Vigencia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Vigencia_Enabled), 5, 0), true);
         cmbHorario_Sts.Enabled = 0;
         AssignProp("", false, cmbHorario_Sts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbHorario_Sts.Enabled), 5, 0), true);
         edtHorario_Dia_Toling_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Toling_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Toling_Enabled), 5, 0), true);
         edtHorario_Dia_TolSal_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_TolSal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_TolSal_Enabled), 5, 0), true);
         edtHorario_Dia_Ini_01_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Ini_01_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Ini_01_Enabled), 5, 0), true);
         edtHorario_Dia_Ini_02_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Ini_02_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Ini_02_Enabled), 5, 0), true);
         edtHorario_Dia_Ini_03_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Ini_03_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Ini_03_Enabled), 5, 0), true);
         edtHorario_Dia_Ini_04_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Ini_04_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Ini_04_Enabled), 5, 0), true);
         edtHorario_Dia_Ini_05_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Ini_05_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Ini_05_Enabled), 5, 0), true);
         edtHorario_Dia_Ini_06_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Ini_06_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Ini_06_Enabled), 5, 0), true);
         edtHorario_Dia_Ini_07_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Ini_07_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Ini_07_Enabled), 5, 0), true);
         edtHorario_Ref_Ini_01_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Ini_01_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Ini_01_Enabled), 5, 0), true);
         edtHorario_Ref_Ini_02_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Ini_02_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Ini_02_Enabled), 5, 0), true);
         edtHorario_Ref_Ini_03_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Ini_03_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Ini_03_Enabled), 5, 0), true);
         edtHorario_Ref_Ini_04_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Ini_04_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Ini_04_Enabled), 5, 0), true);
         edtHorario_Ref_Ini_05_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Ini_05_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Ini_05_Enabled), 5, 0), true);
         edtHorario_Ref_Ini_06_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Ini_06_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Ini_06_Enabled), 5, 0), true);
         edtHorario_Ref_Ini_07_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Ini_07_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Ini_07_Enabled), 5, 0), true);
         edtHorario_Ref_Fin_01_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Fin_01_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Fin_01_Enabled), 5, 0), true);
         edtHorario_Ref_Fin_02_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Fin_02_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Fin_02_Enabled), 5, 0), true);
         edtHorario_Ref_Fin_03_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Fin_03_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Fin_03_Enabled), 5, 0), true);
         edtHorario_Ref_Fin_04_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Fin_04_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Fin_04_Enabled), 5, 0), true);
         edtHorario_Ref_Fin_05_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Fin_05_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Fin_05_Enabled), 5, 0), true);
         edtHorario_Ref_Fin_06_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Fin_06_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Fin_06_Enabled), 5, 0), true);
         edtHorario_Ref_Fin_07_Enabled = 0;
         AssignProp("", false, edtHorario_Ref_Fin_07_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Ref_Fin_07_Enabled), 5, 0), true);
         edtHorario_Dia_Fin_01_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Fin_01_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Fin_01_Enabled), 5, 0), true);
         edtHorario_Dia_Fin_02_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Fin_02_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Fin_02_Enabled), 5, 0), true);
         edtHorario_Dia_Fin_03_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Fin_03_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Fin_03_Enabled), 5, 0), true);
         edtHorario_Dia_Fin_04_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Fin_04_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Fin_04_Enabled), 5, 0), true);
         edtHorario_Dia_Fin_05_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Fin_05_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Fin_05_Enabled), 5, 0), true);
         edtHorario_Dia_Fin_06_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Fin_06_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Fin_06_Enabled), 5, 0), true);
         edtHorario_Dia_Fin_07_Enabled = 0;
         AssignProp("", false, edtHorario_Dia_Fin_07_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtHorario_Dia_Fin_07_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7R213( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7R0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181235452", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("calendar-es.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7Horario_ID,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Reloj_Horario");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Horario_Dia_TolRef", context.localUtil.Format( (decimal)(A2465Horario_Dia_TolRef), "ZZZZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("reloj_interface\\reloj_horario:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z2432Horario_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2432Horario_ID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2433Horario_Dsc", Z2433Horario_Dsc);
         GxWebStd.gx_hidden_field( context, "Z2434Horario_Dia_Ini_01", context.localUtil.TToC( Z2434Horario_Dia_Ini_01, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2435Horario_Dia_Ini_02", context.localUtil.TToC( Z2435Horario_Dia_Ini_02, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2436Horario_Dia_Ini_03", context.localUtil.TToC( Z2436Horario_Dia_Ini_03, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2437Horario_Dia_Ini_04", context.localUtil.TToC( Z2437Horario_Dia_Ini_04, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2438Horario_Dia_Ini_05", context.localUtil.TToC( Z2438Horario_Dia_Ini_05, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2439Horario_Dia_Ini_06", context.localUtil.TToC( Z2439Horario_Dia_Ini_06, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2440Horario_Dia_Ini_07", context.localUtil.TToC( Z2440Horario_Dia_Ini_07, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2441Horario_Dia_Fin_01", context.localUtil.TToC( Z2441Horario_Dia_Fin_01, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2442Horario_Dia_Fin_02", context.localUtil.TToC( Z2442Horario_Dia_Fin_02, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2443Horario_Dia_Fin_03", context.localUtil.TToC( Z2443Horario_Dia_Fin_03, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2444Horario_Dia_Fin_04", context.localUtil.TToC( Z2444Horario_Dia_Fin_04, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2445Horario_Dia_Fin_05", context.localUtil.TToC( Z2445Horario_Dia_Fin_05, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2446Horario_Dia_Fin_06", context.localUtil.TToC( Z2446Horario_Dia_Fin_06, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2447Horario_Dia_Fin_07", context.localUtil.TToC( Z2447Horario_Dia_Fin_07, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2448Horario_Ref_Ini_01", context.localUtil.TToC( Z2448Horario_Ref_Ini_01, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2449Horario_Ref_Ini_02", context.localUtil.TToC( Z2449Horario_Ref_Ini_02, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2450Horario_Ref_Ini_03", context.localUtil.TToC( Z2450Horario_Ref_Ini_03, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2451Horario_Ref_Ini_04", context.localUtil.TToC( Z2451Horario_Ref_Ini_04, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2452Horario_Ref_Ini_05", context.localUtil.TToC( Z2452Horario_Ref_Ini_05, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2453Horario_Ref_Ini_06", context.localUtil.TToC( Z2453Horario_Ref_Ini_06, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2454Horario_Ref_Ini_07", context.localUtil.TToC( Z2454Horario_Ref_Ini_07, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2455Horario_Ref_Fin_01", context.localUtil.TToC( Z2455Horario_Ref_Fin_01, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2456Horario_Ref_Fin_02", context.localUtil.TToC( Z2456Horario_Ref_Fin_02, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2457Horario_Ref_Fin_03", context.localUtil.TToC( Z2457Horario_Ref_Fin_03, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2458Horario_Ref_Fin_04", context.localUtil.TToC( Z2458Horario_Ref_Fin_04, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2459Horario_Ref_Fin_05", context.localUtil.TToC( Z2459Horario_Ref_Fin_05, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2460Horario_Ref_Fin_06", context.localUtil.TToC( Z2460Horario_Ref_Fin_06, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2461Horario_Ref_Fin_07", context.localUtil.TToC( Z2461Horario_Ref_Fin_07, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2462Horario_Vigencia", context.localUtil.TToC( Z2462Horario_Vigencia, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z2463Horario_Sts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2463Horario_Sts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2464Horario_Dia_Toling", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2464Horario_Dia_Toling), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2465Horario_Dia_TolRef", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2465Horario_Dia_TolRef), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2466Horario_Dia_TolSal", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2466Horario_Dia_TolSal), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vHORARIO_ID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7Horario_ID), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vHORARIO_ID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7Horario_ID), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "HORARIO_DIA_TOLREF", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2465Horario_Dia_TolRef), 9, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Objectcall", StringUtil.RTrim( Dvpanel_table2_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Enabled", StringUtil.BoolToStr( Dvpanel_table2_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Width", StringUtil.RTrim( Dvpanel_table2_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Autowidth", StringUtil.BoolToStr( Dvpanel_table2_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Autoheight", StringUtil.BoolToStr( Dvpanel_table2_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Cls", StringUtil.RTrim( Dvpanel_table2_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Title", StringUtil.RTrim( Dvpanel_table2_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Collapsible", StringUtil.BoolToStr( Dvpanel_table2_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Collapsed", StringUtil.BoolToStr( Dvpanel_table2_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_table2_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Iconposition", StringUtil.RTrim( Dvpanel_table2_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLE2_Autoscroll", StringUtil.BoolToStr( Dvpanel_table2_Autoscroll));
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
         GXEncryptionTmp = "reloj_interface.reloj_horario.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7Horario_ID,4,0));
         return formatLink("reloj_interface.reloj_horario.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Reloj_Interface.Reloj_Horario" ;
      }

      public override string GetPgmdesc( )
      {
         return "Maestro de Horario" ;
      }

      protected void InitializeNonKey7R213( )
      {
         A2433Horario_Dsc = "";
         AssignAttri("", false, "A2433Horario_Dsc", A2433Horario_Dsc);
         A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2434Horario_Dia_Ini_01", context.localUtil.TToC( A2434Horario_Dia_Ini_01, 0, 5, 0, 3, "/", ":", " "));
         A2435Horario_Dia_Ini_02 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2435Horario_Dia_Ini_02", context.localUtil.TToC( A2435Horario_Dia_Ini_02, 0, 5, 0, 3, "/", ":", " "));
         A2436Horario_Dia_Ini_03 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2436Horario_Dia_Ini_03", context.localUtil.TToC( A2436Horario_Dia_Ini_03, 0, 5, 0, 3, "/", ":", " "));
         A2437Horario_Dia_Ini_04 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2437Horario_Dia_Ini_04", context.localUtil.TToC( A2437Horario_Dia_Ini_04, 0, 5, 0, 3, "/", ":", " "));
         A2438Horario_Dia_Ini_05 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2438Horario_Dia_Ini_05", context.localUtil.TToC( A2438Horario_Dia_Ini_05, 0, 5, 0, 3, "/", ":", " "));
         A2439Horario_Dia_Ini_06 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2439Horario_Dia_Ini_06", context.localUtil.TToC( A2439Horario_Dia_Ini_06, 0, 5, 0, 3, "/", ":", " "));
         A2440Horario_Dia_Ini_07 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2440Horario_Dia_Ini_07", context.localUtil.TToC( A2440Horario_Dia_Ini_07, 0, 5, 0, 3, "/", ":", " "));
         A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2441Horario_Dia_Fin_01", context.localUtil.TToC( A2441Horario_Dia_Fin_01, 0, 5, 0, 3, "/", ":", " "));
         A2442Horario_Dia_Fin_02 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2442Horario_Dia_Fin_02", context.localUtil.TToC( A2442Horario_Dia_Fin_02, 0, 5, 0, 3, "/", ":", " "));
         A2443Horario_Dia_Fin_03 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2443Horario_Dia_Fin_03", context.localUtil.TToC( A2443Horario_Dia_Fin_03, 0, 5, 0, 3, "/", ":", " "));
         A2444Horario_Dia_Fin_04 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2444Horario_Dia_Fin_04", context.localUtil.TToC( A2444Horario_Dia_Fin_04, 0, 5, 0, 3, "/", ":", " "));
         A2445Horario_Dia_Fin_05 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2445Horario_Dia_Fin_05", context.localUtil.TToC( A2445Horario_Dia_Fin_05, 0, 5, 0, 3, "/", ":", " "));
         A2446Horario_Dia_Fin_06 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2446Horario_Dia_Fin_06", context.localUtil.TToC( A2446Horario_Dia_Fin_06, 0, 5, 0, 3, "/", ":", " "));
         A2447Horario_Dia_Fin_07 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2447Horario_Dia_Fin_07", context.localUtil.TToC( A2447Horario_Dia_Fin_07, 0, 5, 0, 3, "/", ":", " "));
         A2448Horario_Ref_Ini_01 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2448Horario_Ref_Ini_01", context.localUtil.TToC( A2448Horario_Ref_Ini_01, 0, 5, 0, 3, "/", ":", " "));
         A2449Horario_Ref_Ini_02 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2449Horario_Ref_Ini_02", context.localUtil.TToC( A2449Horario_Ref_Ini_02, 0, 5, 0, 3, "/", ":", " "));
         A2450Horario_Ref_Ini_03 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2450Horario_Ref_Ini_03", context.localUtil.TToC( A2450Horario_Ref_Ini_03, 0, 5, 0, 3, "/", ":", " "));
         A2451Horario_Ref_Ini_04 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2451Horario_Ref_Ini_04", context.localUtil.TToC( A2451Horario_Ref_Ini_04, 0, 5, 0, 3, "/", ":", " "));
         A2452Horario_Ref_Ini_05 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2452Horario_Ref_Ini_05", context.localUtil.TToC( A2452Horario_Ref_Ini_05, 0, 5, 0, 3, "/", ":", " "));
         A2453Horario_Ref_Ini_06 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2453Horario_Ref_Ini_06", context.localUtil.TToC( A2453Horario_Ref_Ini_06, 0, 5, 0, 3, "/", ":", " "));
         A2454Horario_Ref_Ini_07 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2454Horario_Ref_Ini_07", context.localUtil.TToC( A2454Horario_Ref_Ini_07, 0, 5, 0, 3, "/", ":", " "));
         A2455Horario_Ref_Fin_01 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2455Horario_Ref_Fin_01", context.localUtil.TToC( A2455Horario_Ref_Fin_01, 0, 5, 0, 3, "/", ":", " "));
         A2456Horario_Ref_Fin_02 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2456Horario_Ref_Fin_02", context.localUtil.TToC( A2456Horario_Ref_Fin_02, 0, 5, 0, 3, "/", ":", " "));
         A2457Horario_Ref_Fin_03 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2457Horario_Ref_Fin_03", context.localUtil.TToC( A2457Horario_Ref_Fin_03, 0, 5, 0, 3, "/", ":", " "));
         A2458Horario_Ref_Fin_04 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2458Horario_Ref_Fin_04", context.localUtil.TToC( A2458Horario_Ref_Fin_04, 0, 5, 0, 3, "/", ":", " "));
         A2459Horario_Ref_Fin_05 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2459Horario_Ref_Fin_05", context.localUtil.TToC( A2459Horario_Ref_Fin_05, 0, 5, 0, 3, "/", ":", " "));
         A2460Horario_Ref_Fin_06 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2460Horario_Ref_Fin_06", context.localUtil.TToC( A2460Horario_Ref_Fin_06, 0, 5, 0, 3, "/", ":", " "));
         A2461Horario_Ref_Fin_07 = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2461Horario_Ref_Fin_07", context.localUtil.TToC( A2461Horario_Ref_Fin_07, 0, 5, 0, 3, "/", ":", " "));
         A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A2462Horario_Vigencia", context.localUtil.TToC( A2462Horario_Vigencia, 10, 8, 0, 3, "/", ":", " "));
         A2464Horario_Dia_Toling = 0;
         AssignAttri("", false, "A2464Horario_Dia_Toling", StringUtil.LTrimStr( (decimal)(A2464Horario_Dia_Toling), 9, 0));
         A2465Horario_Dia_TolRef = 0;
         AssignAttri("", false, "A2465Horario_Dia_TolRef", StringUtil.LTrimStr( (decimal)(A2465Horario_Dia_TolRef), 9, 0));
         A2466Horario_Dia_TolSal = 0;
         AssignAttri("", false, "A2466Horario_Dia_TolSal", StringUtil.LTrimStr( (decimal)(A2466Horario_Dia_TolSal), 9, 0));
         A2463Horario_Sts = 1;
         AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
         Z2433Horario_Dsc = "";
         Z2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         Z2435Horario_Dia_Ini_02 = (DateTime)(DateTime.MinValue);
         Z2436Horario_Dia_Ini_03 = (DateTime)(DateTime.MinValue);
         Z2437Horario_Dia_Ini_04 = (DateTime)(DateTime.MinValue);
         Z2438Horario_Dia_Ini_05 = (DateTime)(DateTime.MinValue);
         Z2439Horario_Dia_Ini_06 = (DateTime)(DateTime.MinValue);
         Z2440Horario_Dia_Ini_07 = (DateTime)(DateTime.MinValue);
         Z2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         Z2442Horario_Dia_Fin_02 = (DateTime)(DateTime.MinValue);
         Z2443Horario_Dia_Fin_03 = (DateTime)(DateTime.MinValue);
         Z2444Horario_Dia_Fin_04 = (DateTime)(DateTime.MinValue);
         Z2445Horario_Dia_Fin_05 = (DateTime)(DateTime.MinValue);
         Z2446Horario_Dia_Fin_06 = (DateTime)(DateTime.MinValue);
         Z2447Horario_Dia_Fin_07 = (DateTime)(DateTime.MinValue);
         Z2448Horario_Ref_Ini_01 = (DateTime)(DateTime.MinValue);
         Z2449Horario_Ref_Ini_02 = (DateTime)(DateTime.MinValue);
         Z2450Horario_Ref_Ini_03 = (DateTime)(DateTime.MinValue);
         Z2451Horario_Ref_Ini_04 = (DateTime)(DateTime.MinValue);
         Z2452Horario_Ref_Ini_05 = (DateTime)(DateTime.MinValue);
         Z2453Horario_Ref_Ini_06 = (DateTime)(DateTime.MinValue);
         Z2454Horario_Ref_Ini_07 = (DateTime)(DateTime.MinValue);
         Z2455Horario_Ref_Fin_01 = (DateTime)(DateTime.MinValue);
         Z2456Horario_Ref_Fin_02 = (DateTime)(DateTime.MinValue);
         Z2457Horario_Ref_Fin_03 = (DateTime)(DateTime.MinValue);
         Z2458Horario_Ref_Fin_04 = (DateTime)(DateTime.MinValue);
         Z2459Horario_Ref_Fin_05 = (DateTime)(DateTime.MinValue);
         Z2460Horario_Ref_Fin_06 = (DateTime)(DateTime.MinValue);
         Z2461Horario_Ref_Fin_07 = (DateTime)(DateTime.MinValue);
         Z2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         Z2463Horario_Sts = 0;
         Z2464Horario_Dia_Toling = 0;
         Z2465Horario_Dia_TolRef = 0;
         Z2466Horario_Dia_TolSal = 0;
      }

      protected void InitAll7R213( )
      {
         A2432Horario_ID = 0;
         AssignAttri("", false, "A2432Horario_ID", StringUtil.LTrimStr( (decimal)(A2432Horario_ID), 4, 0));
         InitializeNonKey7R213( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A2463Horario_Sts = i2463Horario_Sts;
         AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281812354530", true, true);
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
         context.AddJavascriptSource("reloj_interface/reloj_horario.js", "?202281812354530", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtHorario_ID_Internalname = "HORARIO_ID";
         edtHorario_Dsc_Internalname = "HORARIO_DSC";
         edtHorario_Vigencia_Internalname = "HORARIO_VIGENCIA";
         cmbHorario_Sts_Internalname = "HORARIO_STS";
         edtHorario_Dia_Toling_Internalname = "HORARIO_DIA_TOLING";
         edtHorario_Dia_TolSal_Internalname = "HORARIO_DIA_TOLSAL";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         lblLunes_Internalname = "LUNES";
         lblMartes_Internalname = "MARTES";
         lblMiercoles_Internalname = "MIERCOLES";
         lblJueves_Internalname = "JUEVES";
         lblViernes_Internalname = "VIERNES";
         lblSabado_Internalname = "SABADO";
         lblDomingo_Internalname = "DOMINGO";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         lblTextblockhorario_dia_ini_01_Internalname = "TEXTBLOCKHORARIO_DIA_INI_01";
         edtHorario_Dia_Ini_01_Internalname = "HORARIO_DIA_INI_01";
         divUnnamedtablehorario_dia_ini_01_Internalname = "UNNAMEDTABLEHORARIO_DIA_INI_01";
         lblTextblockhorario_dia_ini_02_Internalname = "TEXTBLOCKHORARIO_DIA_INI_02";
         edtHorario_Dia_Ini_02_Internalname = "HORARIO_DIA_INI_02";
         divUnnamedtablehorario_dia_ini_02_Internalname = "UNNAMEDTABLEHORARIO_DIA_INI_02";
         lblTextblockhorario_dia_ini_03_Internalname = "TEXTBLOCKHORARIO_DIA_INI_03";
         edtHorario_Dia_Ini_03_Internalname = "HORARIO_DIA_INI_03";
         divUnnamedtablehorario_dia_ini_03_Internalname = "UNNAMEDTABLEHORARIO_DIA_INI_03";
         lblTextblockhorario_dia_ini_04_Internalname = "TEXTBLOCKHORARIO_DIA_INI_04";
         edtHorario_Dia_Ini_04_Internalname = "HORARIO_DIA_INI_04";
         divUnnamedtablehorario_dia_ini_04_Internalname = "UNNAMEDTABLEHORARIO_DIA_INI_04";
         lblTextblockhorario_dia_ini_05_Internalname = "TEXTBLOCKHORARIO_DIA_INI_05";
         edtHorario_Dia_Ini_05_Internalname = "HORARIO_DIA_INI_05";
         divUnnamedtablehorario_dia_ini_05_Internalname = "UNNAMEDTABLEHORARIO_DIA_INI_05";
         lblTextblockhorario_dia_ini_06_Internalname = "TEXTBLOCKHORARIO_DIA_INI_06";
         edtHorario_Dia_Ini_06_Internalname = "HORARIO_DIA_INI_06";
         divUnnamedtablehorario_dia_ini_06_Internalname = "UNNAMEDTABLEHORARIO_DIA_INI_06";
         lblTextblockhorario_dia_ini_07_Internalname = "TEXTBLOCKHORARIO_DIA_INI_07";
         edtHorario_Dia_Ini_07_Internalname = "HORARIO_DIA_INI_07";
         divUnnamedtablehorario_dia_ini_07_Internalname = "UNNAMEDTABLEHORARIO_DIA_INI_07";
         divUnnamedtable3_Internalname = "UNNAMEDTABLE3";
         lblTextblockhorario_ref_ini_01_Internalname = "TEXTBLOCKHORARIO_REF_INI_01";
         edtHorario_Ref_Ini_01_Internalname = "HORARIO_REF_INI_01";
         divUnnamedtablehorario_ref_ini_01_Internalname = "UNNAMEDTABLEHORARIO_REF_INI_01";
         lblTextblockhorario_ref_ini_02_Internalname = "TEXTBLOCKHORARIO_REF_INI_02";
         edtHorario_Ref_Ini_02_Internalname = "HORARIO_REF_INI_02";
         divUnnamedtablehorario_ref_ini_02_Internalname = "UNNAMEDTABLEHORARIO_REF_INI_02";
         lblTextblockhorario_ref_ini_03_Internalname = "TEXTBLOCKHORARIO_REF_INI_03";
         edtHorario_Ref_Ini_03_Internalname = "HORARIO_REF_INI_03";
         divUnnamedtablehorario_ref_ini_03_Internalname = "UNNAMEDTABLEHORARIO_REF_INI_03";
         lblTextblockhorario_ref_ini_04_Internalname = "TEXTBLOCKHORARIO_REF_INI_04";
         edtHorario_Ref_Ini_04_Internalname = "HORARIO_REF_INI_04";
         divUnnamedtablehorario_ref_ini_04_Internalname = "UNNAMEDTABLEHORARIO_REF_INI_04";
         lblTextblockhorario_ref_ini_05_Internalname = "TEXTBLOCKHORARIO_REF_INI_05";
         edtHorario_Ref_Ini_05_Internalname = "HORARIO_REF_INI_05";
         divUnnamedtablehorario_ref_ini_05_Internalname = "UNNAMEDTABLEHORARIO_REF_INI_05";
         lblTextblockhorario_ref_ini_06_Internalname = "TEXTBLOCKHORARIO_REF_INI_06";
         edtHorario_Ref_Ini_06_Internalname = "HORARIO_REF_INI_06";
         divUnnamedtablehorario_ref_ini_06_Internalname = "UNNAMEDTABLEHORARIO_REF_INI_06";
         lblTextblockhorario_ref_ini_07_Internalname = "TEXTBLOCKHORARIO_REF_INI_07";
         edtHorario_Ref_Ini_07_Internalname = "HORARIO_REF_INI_07";
         divUnnamedtablehorario_ref_ini_07_Internalname = "UNNAMEDTABLEHORARIO_REF_INI_07";
         divUnnamedtable4_Internalname = "UNNAMEDTABLE4";
         lblTextblockhorario_ref_fin_01_Internalname = "TEXTBLOCKHORARIO_REF_FIN_01";
         edtHorario_Ref_Fin_01_Internalname = "HORARIO_REF_FIN_01";
         divUnnamedtablehorario_ref_fin_01_Internalname = "UNNAMEDTABLEHORARIO_REF_FIN_01";
         lblTextblockhorario_ref_fin_02_Internalname = "TEXTBLOCKHORARIO_REF_FIN_02";
         edtHorario_Ref_Fin_02_Internalname = "HORARIO_REF_FIN_02";
         divUnnamedtablehorario_ref_fin_02_Internalname = "UNNAMEDTABLEHORARIO_REF_FIN_02";
         lblTextblockhorario_ref_fin_03_Internalname = "TEXTBLOCKHORARIO_REF_FIN_03";
         edtHorario_Ref_Fin_03_Internalname = "HORARIO_REF_FIN_03";
         divUnnamedtablehorario_ref_fin_03_Internalname = "UNNAMEDTABLEHORARIO_REF_FIN_03";
         lblTextblockhorario_ref_fin_04_Internalname = "TEXTBLOCKHORARIO_REF_FIN_04";
         edtHorario_Ref_Fin_04_Internalname = "HORARIO_REF_FIN_04";
         divUnnamedtablehorario_ref_fin_04_Internalname = "UNNAMEDTABLEHORARIO_REF_FIN_04";
         lblTextblockhorario_ref_fin_05_Internalname = "TEXTBLOCKHORARIO_REF_FIN_05";
         edtHorario_Ref_Fin_05_Internalname = "HORARIO_REF_FIN_05";
         divUnnamedtablehorario_ref_fin_05_Internalname = "UNNAMEDTABLEHORARIO_REF_FIN_05";
         lblTextblockhorario_ref_fin_06_Internalname = "TEXTBLOCKHORARIO_REF_FIN_06";
         edtHorario_Ref_Fin_06_Internalname = "HORARIO_REF_FIN_06";
         divUnnamedtablehorario_ref_fin_06_Internalname = "UNNAMEDTABLEHORARIO_REF_FIN_06";
         lblTextblockhorario_ref_fin_07_Internalname = "TEXTBLOCKHORARIO_REF_FIN_07";
         edtHorario_Ref_Fin_07_Internalname = "HORARIO_REF_FIN_07";
         divUnnamedtablehorario_ref_fin_07_Internalname = "UNNAMEDTABLEHORARIO_REF_FIN_07";
         divUnnamedtable5_Internalname = "UNNAMEDTABLE5";
         lblTextblockhorario_dia_fin_01_Internalname = "TEXTBLOCKHORARIO_DIA_FIN_01";
         edtHorario_Dia_Fin_01_Internalname = "HORARIO_DIA_FIN_01";
         divUnnamedtablehorario_dia_fin_01_Internalname = "UNNAMEDTABLEHORARIO_DIA_FIN_01";
         lblTextblockhorario_dia_fin_02_Internalname = "TEXTBLOCKHORARIO_DIA_FIN_02";
         edtHorario_Dia_Fin_02_Internalname = "HORARIO_DIA_FIN_02";
         divUnnamedtablehorario_dia_fin_02_Internalname = "UNNAMEDTABLEHORARIO_DIA_FIN_02";
         lblTextblockhorario_dia_fin_03_Internalname = "TEXTBLOCKHORARIO_DIA_FIN_03";
         edtHorario_Dia_Fin_03_Internalname = "HORARIO_DIA_FIN_03";
         divUnnamedtablehorario_dia_fin_03_Internalname = "UNNAMEDTABLEHORARIO_DIA_FIN_03";
         lblTextblockhorario_dia_fin_04_Internalname = "TEXTBLOCKHORARIO_DIA_FIN_04";
         edtHorario_Dia_Fin_04_Internalname = "HORARIO_DIA_FIN_04";
         divUnnamedtablehorario_dia_fin_04_Internalname = "UNNAMEDTABLEHORARIO_DIA_FIN_04";
         lblTextblockhorario_dia_fin_05_Internalname = "TEXTBLOCKHORARIO_DIA_FIN_05";
         edtHorario_Dia_Fin_05_Internalname = "HORARIO_DIA_FIN_05";
         divUnnamedtablehorario_dia_fin_05_Internalname = "UNNAMEDTABLEHORARIO_DIA_FIN_05";
         lblTextblockhorario_dia_fin_06_Internalname = "TEXTBLOCKHORARIO_DIA_FIN_06";
         edtHorario_Dia_Fin_06_Internalname = "HORARIO_DIA_FIN_06";
         divUnnamedtablehorario_dia_fin_06_Internalname = "UNNAMEDTABLEHORARIO_DIA_FIN_06";
         lblTextblockhorario_dia_fin_07_Internalname = "TEXTBLOCKHORARIO_DIA_FIN_07";
         edtHorario_Dia_Fin_07_Internalname = "HORARIO_DIA_FIN_07";
         divUnnamedtablehorario_dia_fin_07_Internalname = "UNNAMEDTABLEHORARIO_DIA_FIN_07";
         divUnnamedtable6_Internalname = "UNNAMEDTABLE6";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTable2_Internalname = "TABLE2";
         Dvpanel_table2_Internalname = "DVPANEL_TABLE2";
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
         Form.Caption = "Maestro de Horario";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtHorario_Dia_Fin_07_Jsonclick = "";
         edtHorario_Dia_Fin_07_Tooltiptext = "";
         edtHorario_Dia_Fin_07_Enabled = 1;
         edtHorario_Dia_Fin_06_Jsonclick = "";
         edtHorario_Dia_Fin_06_Tooltiptext = "";
         edtHorario_Dia_Fin_06_Enabled = 1;
         edtHorario_Dia_Fin_05_Jsonclick = "";
         edtHorario_Dia_Fin_05_Tooltiptext = "";
         edtHorario_Dia_Fin_05_Enabled = 1;
         edtHorario_Dia_Fin_04_Jsonclick = "";
         edtHorario_Dia_Fin_04_Tooltiptext = "";
         edtHorario_Dia_Fin_04_Enabled = 1;
         edtHorario_Dia_Fin_03_Jsonclick = "";
         edtHorario_Dia_Fin_03_Tooltiptext = "";
         edtHorario_Dia_Fin_03_Enabled = 1;
         edtHorario_Dia_Fin_02_Jsonclick = "";
         edtHorario_Dia_Fin_02_Tooltiptext = "";
         edtHorario_Dia_Fin_02_Enabled = 1;
         edtHorario_Dia_Fin_01_Jsonclick = "";
         edtHorario_Dia_Fin_01_Tooltiptext = "";
         edtHorario_Dia_Fin_01_Enabled = 1;
         edtHorario_Ref_Fin_07_Jsonclick = "";
         edtHorario_Ref_Fin_07_Tooltiptext = "";
         edtHorario_Ref_Fin_07_Enabled = 1;
         edtHorario_Ref_Fin_06_Jsonclick = "";
         edtHorario_Ref_Fin_06_Tooltiptext = "";
         edtHorario_Ref_Fin_06_Enabled = 1;
         edtHorario_Ref_Fin_05_Jsonclick = "";
         edtHorario_Ref_Fin_05_Tooltiptext = "";
         edtHorario_Ref_Fin_05_Enabled = 1;
         edtHorario_Ref_Fin_04_Jsonclick = "";
         edtHorario_Ref_Fin_04_Tooltiptext = "";
         edtHorario_Ref_Fin_04_Enabled = 1;
         edtHorario_Ref_Fin_03_Jsonclick = "";
         edtHorario_Ref_Fin_03_Tooltiptext = "";
         edtHorario_Ref_Fin_03_Enabled = 1;
         edtHorario_Ref_Fin_02_Jsonclick = "";
         edtHorario_Ref_Fin_02_Tooltiptext = "";
         edtHorario_Ref_Fin_02_Enabled = 1;
         edtHorario_Ref_Fin_01_Jsonclick = "";
         edtHorario_Ref_Fin_01_Tooltiptext = "";
         edtHorario_Ref_Fin_01_Enabled = 1;
         edtHorario_Ref_Ini_07_Jsonclick = "";
         edtHorario_Ref_Ini_07_Tooltiptext = "";
         edtHorario_Ref_Ini_07_Enabled = 1;
         edtHorario_Ref_Ini_06_Jsonclick = "";
         edtHorario_Ref_Ini_06_Tooltiptext = "";
         edtHorario_Ref_Ini_06_Enabled = 1;
         edtHorario_Ref_Ini_05_Jsonclick = "";
         edtHorario_Ref_Ini_05_Tooltiptext = "";
         edtHorario_Ref_Ini_05_Enabled = 1;
         edtHorario_Ref_Ini_04_Jsonclick = "";
         edtHorario_Ref_Ini_04_Tooltiptext = "";
         edtHorario_Ref_Ini_04_Enabled = 1;
         edtHorario_Ref_Ini_03_Jsonclick = "";
         edtHorario_Ref_Ini_03_Tooltiptext = "";
         edtHorario_Ref_Ini_03_Enabled = 1;
         edtHorario_Ref_Ini_02_Jsonclick = "";
         edtHorario_Ref_Ini_02_Tooltiptext = "";
         edtHorario_Ref_Ini_02_Enabled = 1;
         edtHorario_Ref_Ini_01_Jsonclick = "";
         edtHorario_Ref_Ini_01_Tooltiptext = "";
         edtHorario_Ref_Ini_01_Enabled = 1;
         edtHorario_Dia_Ini_07_Jsonclick = "";
         edtHorario_Dia_Ini_07_Tooltiptext = "";
         edtHorario_Dia_Ini_07_Enabled = 1;
         edtHorario_Dia_Ini_06_Jsonclick = "";
         edtHorario_Dia_Ini_06_Tooltiptext = "";
         edtHorario_Dia_Ini_06_Enabled = 1;
         edtHorario_Dia_Ini_05_Jsonclick = "";
         edtHorario_Dia_Ini_05_Tooltiptext = "";
         edtHorario_Dia_Ini_05_Enabled = 1;
         edtHorario_Dia_Ini_04_Jsonclick = "";
         edtHorario_Dia_Ini_04_Tooltiptext = "";
         edtHorario_Dia_Ini_04_Enabled = 1;
         edtHorario_Dia_Ini_03_Jsonclick = "";
         edtHorario_Dia_Ini_03_Tooltiptext = "";
         edtHorario_Dia_Ini_03_Enabled = 1;
         edtHorario_Dia_Ini_02_Jsonclick = "";
         edtHorario_Dia_Ini_02_Tooltiptext = "";
         edtHorario_Dia_Ini_02_Enabled = 1;
         edtHorario_Dia_Ini_01_Jsonclick = "";
         edtHorario_Dia_Ini_01_Tooltiptext = "";
         edtHorario_Dia_Ini_01_Enabled = 1;
         lblDomingo_Jsonclick = "";
         lblSabado_Jsonclick = "";
         lblViernes_Jsonclick = "";
         lblJueves_Jsonclick = "";
         lblMiercoles_Jsonclick = "";
         lblMartes_Jsonclick = "";
         lblLunes_Jsonclick = "";
         Dvpanel_table2_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_table2_Iconposition = "Right";
         Dvpanel_table2_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_table2_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_table2_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_table2_Title = "Horario Semanal";
         Dvpanel_table2_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_table2_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_table2_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_table2_Width = "100%";
         edtHorario_Dia_TolSal_Jsonclick = "";
         edtHorario_Dia_TolSal_Tooltiptext = "";
         edtHorario_Dia_TolSal_Enabled = 1;
         edtHorario_Dia_Toling_Jsonclick = "";
         edtHorario_Dia_Toling_Tooltiptext = "";
         edtHorario_Dia_Toling_Enabled = 1;
         cmbHorario_Sts_Jsonclick = "";
         cmbHorario_Sts.TooltipText = "";
         cmbHorario_Sts.Enabled = 1;
         edtHorario_Vigencia_Jsonclick = "";
         edtHorario_Vigencia_Tooltiptext = "";
         edtHorario_Vigencia_Enabled = 1;
         edtHorario_Dsc_Jsonclick = "";
         edtHorario_Dsc_Tooltiptext = "";
         edtHorario_Dsc_Enabled = 1;
         edtHorario_ID_Jsonclick = "";
         edtHorario_ID_Tooltiptext = "";
         edtHorario_ID_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Información del Horario";
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

      protected void init_web_controls( )
      {
         cmbHorario_Sts.Name = "HORARIO_STS";
         cmbHorario_Sts.WebTags = "";
         cmbHorario_Sts.addItem("1", "Activo", 0);
         cmbHorario_Sts.addItem("0", "Inactivo", 0);
         if ( cmbHorario_Sts.ItemCount > 0 )
         {
            if ( (0==A2463Horario_Sts) )
            {
               A2463Horario_Sts = 1;
               AssignAttri("", false, "A2463Horario_Sts", StringUtil.Str( (decimal)(A2463Horario_Sts), 1, 0));
            }
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

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7Horario_ID',fld:'vHORARIO_ID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7Horario_ID',fld:'vHORARIO_ID',pic:'ZZZ9',hsh:true},{av:'A2465Horario_Dia_TolRef',fld:'HORARIO_DIA_TOLREF',pic:'ZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E127R2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_HORARIO_ID","{handler:'Valid_Horario_id',iparms:[]");
         setEventMetadata("VALID_HORARIO_ID",",oparms:[]}");
         setEventMetadata("VALID_HORARIO_VIGENCIA","{handler:'Valid_Horario_vigencia',iparms:[]");
         setEventMetadata("VALID_HORARIO_VIGENCIA",",oparms:[]}");
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
         wcpOGx_mode = "";
         Z2433Horario_Dsc = "";
         Z2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         Z2435Horario_Dia_Ini_02 = (DateTime)(DateTime.MinValue);
         Z2436Horario_Dia_Ini_03 = (DateTime)(DateTime.MinValue);
         Z2437Horario_Dia_Ini_04 = (DateTime)(DateTime.MinValue);
         Z2438Horario_Dia_Ini_05 = (DateTime)(DateTime.MinValue);
         Z2439Horario_Dia_Ini_06 = (DateTime)(DateTime.MinValue);
         Z2440Horario_Dia_Ini_07 = (DateTime)(DateTime.MinValue);
         Z2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         Z2442Horario_Dia_Fin_02 = (DateTime)(DateTime.MinValue);
         Z2443Horario_Dia_Fin_03 = (DateTime)(DateTime.MinValue);
         Z2444Horario_Dia_Fin_04 = (DateTime)(DateTime.MinValue);
         Z2445Horario_Dia_Fin_05 = (DateTime)(DateTime.MinValue);
         Z2446Horario_Dia_Fin_06 = (DateTime)(DateTime.MinValue);
         Z2447Horario_Dia_Fin_07 = (DateTime)(DateTime.MinValue);
         Z2448Horario_Ref_Ini_01 = (DateTime)(DateTime.MinValue);
         Z2449Horario_Ref_Ini_02 = (DateTime)(DateTime.MinValue);
         Z2450Horario_Ref_Ini_03 = (DateTime)(DateTime.MinValue);
         Z2451Horario_Ref_Ini_04 = (DateTime)(DateTime.MinValue);
         Z2452Horario_Ref_Ini_05 = (DateTime)(DateTime.MinValue);
         Z2453Horario_Ref_Ini_06 = (DateTime)(DateTime.MinValue);
         Z2454Horario_Ref_Ini_07 = (DateTime)(DateTime.MinValue);
         Z2455Horario_Ref_Fin_01 = (DateTime)(DateTime.MinValue);
         Z2456Horario_Ref_Fin_02 = (DateTime)(DateTime.MinValue);
         Z2457Horario_Ref_Fin_03 = (DateTime)(DateTime.MinValue);
         Z2458Horario_Ref_Fin_04 = (DateTime)(DateTime.MinValue);
         Z2459Horario_Ref_Fin_05 = (DateTime)(DateTime.MinValue);
         Z2460Horario_Ref_Fin_06 = (DateTime)(DateTime.MinValue);
         Z2461Horario_Ref_Fin_07 = (DateTime)(DateTime.MinValue);
         Z2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A2433Horario_Dsc = "";
         A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         ucDvpanel_table2 = new GXUserControl();
         lblTextblockhorario_dia_ini_01_Jsonclick = "";
         A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_ini_02_Jsonclick = "";
         A2435Horario_Dia_Ini_02 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_ini_03_Jsonclick = "";
         A2436Horario_Dia_Ini_03 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_ini_04_Jsonclick = "";
         A2437Horario_Dia_Ini_04 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_ini_05_Jsonclick = "";
         A2438Horario_Dia_Ini_05 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_ini_06_Jsonclick = "";
         A2439Horario_Dia_Ini_06 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_ini_07_Jsonclick = "";
         A2440Horario_Dia_Ini_07 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_ini_01_Jsonclick = "";
         A2448Horario_Ref_Ini_01 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_ini_02_Jsonclick = "";
         A2449Horario_Ref_Ini_02 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_ini_03_Jsonclick = "";
         A2450Horario_Ref_Ini_03 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_ini_04_Jsonclick = "";
         A2451Horario_Ref_Ini_04 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_ini_05_Jsonclick = "";
         A2452Horario_Ref_Ini_05 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_ini_06_Jsonclick = "";
         A2453Horario_Ref_Ini_06 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_ini_07_Jsonclick = "";
         A2454Horario_Ref_Ini_07 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_fin_01_Jsonclick = "";
         A2455Horario_Ref_Fin_01 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_fin_02_Jsonclick = "";
         A2456Horario_Ref_Fin_02 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_fin_03_Jsonclick = "";
         A2457Horario_Ref_Fin_03 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_fin_04_Jsonclick = "";
         A2458Horario_Ref_Fin_04 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_fin_05_Jsonclick = "";
         A2459Horario_Ref_Fin_05 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_fin_06_Jsonclick = "";
         A2460Horario_Ref_Fin_06 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_ref_fin_07_Jsonclick = "";
         A2461Horario_Ref_Fin_07 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_fin_01_Jsonclick = "";
         A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_fin_02_Jsonclick = "";
         A2442Horario_Dia_Fin_02 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_fin_03_Jsonclick = "";
         A2443Horario_Dia_Fin_03 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_fin_04_Jsonclick = "";
         A2444Horario_Dia_Fin_04 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_fin_05_Jsonclick = "";
         A2445Horario_Dia_Fin_05 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_fin_06_Jsonclick = "";
         A2446Horario_Dia_Fin_06 = (DateTime)(DateTime.MinValue);
         lblTextblockhorario_dia_fin_07_Jsonclick = "";
         A2447Horario_Dia_Fin_07 = (DateTime)(DateTime.MinValue);
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Dvpanel_table2_Objectcall = "";
         Dvpanel_table2_Class = "";
         Dvpanel_table2_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode213 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T007R4_A2432Horario_ID = new short[1] ;
         T007R4_A2433Horario_Dsc = new string[] {""} ;
         T007R4_A2434Horario_Dia_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2435Horario_Dia_Ini_02 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2436Horario_Dia_Ini_03 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2437Horario_Dia_Ini_04 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2438Horario_Dia_Ini_05 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2439Horario_Dia_Ini_06 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2440Horario_Dia_Ini_07 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2441Horario_Dia_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2442Horario_Dia_Fin_02 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2443Horario_Dia_Fin_03 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2444Horario_Dia_Fin_04 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2445Horario_Dia_Fin_05 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2446Horario_Dia_Fin_06 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2447Horario_Dia_Fin_07 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2448Horario_Ref_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2449Horario_Ref_Ini_02 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2450Horario_Ref_Ini_03 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2451Horario_Ref_Ini_04 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2452Horario_Ref_Ini_05 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2453Horario_Ref_Ini_06 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2454Horario_Ref_Ini_07 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2455Horario_Ref_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2456Horario_Ref_Fin_02 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2457Horario_Ref_Fin_03 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2458Horario_Ref_Fin_04 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2459Horario_Ref_Fin_05 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2460Horario_Ref_Fin_06 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2461Horario_Ref_Fin_07 = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2462Horario_Vigencia = new DateTime[] {DateTime.MinValue} ;
         T007R4_A2463Horario_Sts = new short[1] ;
         T007R4_A2464Horario_Dia_Toling = new int[1] ;
         T007R4_A2465Horario_Dia_TolRef = new int[1] ;
         T007R4_A2466Horario_Dia_TolSal = new int[1] ;
         T007R5_A2432Horario_ID = new short[1] ;
         T007R3_A2432Horario_ID = new short[1] ;
         T007R3_A2433Horario_Dsc = new string[] {""} ;
         T007R3_A2434Horario_Dia_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2435Horario_Dia_Ini_02 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2436Horario_Dia_Ini_03 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2437Horario_Dia_Ini_04 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2438Horario_Dia_Ini_05 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2439Horario_Dia_Ini_06 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2440Horario_Dia_Ini_07 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2441Horario_Dia_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2442Horario_Dia_Fin_02 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2443Horario_Dia_Fin_03 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2444Horario_Dia_Fin_04 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2445Horario_Dia_Fin_05 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2446Horario_Dia_Fin_06 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2447Horario_Dia_Fin_07 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2448Horario_Ref_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2449Horario_Ref_Ini_02 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2450Horario_Ref_Ini_03 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2451Horario_Ref_Ini_04 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2452Horario_Ref_Ini_05 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2453Horario_Ref_Ini_06 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2454Horario_Ref_Ini_07 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2455Horario_Ref_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2456Horario_Ref_Fin_02 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2457Horario_Ref_Fin_03 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2458Horario_Ref_Fin_04 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2459Horario_Ref_Fin_05 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2460Horario_Ref_Fin_06 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2461Horario_Ref_Fin_07 = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2462Horario_Vigencia = new DateTime[] {DateTime.MinValue} ;
         T007R3_A2463Horario_Sts = new short[1] ;
         T007R3_A2464Horario_Dia_Toling = new int[1] ;
         T007R3_A2465Horario_Dia_TolRef = new int[1] ;
         T007R3_A2466Horario_Dia_TolSal = new int[1] ;
         T007R6_A2432Horario_ID = new short[1] ;
         T007R7_A2432Horario_ID = new short[1] ;
         T007R2_A2432Horario_ID = new short[1] ;
         T007R2_A2433Horario_Dsc = new string[] {""} ;
         T007R2_A2434Horario_Dia_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2435Horario_Dia_Ini_02 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2436Horario_Dia_Ini_03 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2437Horario_Dia_Ini_04 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2438Horario_Dia_Ini_05 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2439Horario_Dia_Ini_06 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2440Horario_Dia_Ini_07 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2441Horario_Dia_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2442Horario_Dia_Fin_02 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2443Horario_Dia_Fin_03 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2444Horario_Dia_Fin_04 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2445Horario_Dia_Fin_05 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2446Horario_Dia_Fin_06 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2447Horario_Dia_Fin_07 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2448Horario_Ref_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2449Horario_Ref_Ini_02 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2450Horario_Ref_Ini_03 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2451Horario_Ref_Ini_04 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2452Horario_Ref_Ini_05 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2453Horario_Ref_Ini_06 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2454Horario_Ref_Ini_07 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2455Horario_Ref_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2456Horario_Ref_Fin_02 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2457Horario_Ref_Fin_03 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2458Horario_Ref_Fin_04 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2459Horario_Ref_Fin_05 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2460Horario_Ref_Fin_06 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2461Horario_Ref_Fin_07 = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2462Horario_Vigencia = new DateTime[] {DateTime.MinValue} ;
         T007R2_A2463Horario_Sts = new short[1] ;
         T007R2_A2464Horario_Dia_Toling = new int[1] ;
         T007R2_A2465Horario_Dia_TolRef = new int[1] ;
         T007R2_A2466Horario_Dia_TolSal = new int[1] ;
         T007R11_A2432Horario_ID = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_horario__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_horario__default(),
            new Object[][] {
                new Object[] {
               T007R2_A2432Horario_ID, T007R2_A2433Horario_Dsc, T007R2_A2434Horario_Dia_Ini_01, T007R2_A2435Horario_Dia_Ini_02, T007R2_A2436Horario_Dia_Ini_03, T007R2_A2437Horario_Dia_Ini_04, T007R2_A2438Horario_Dia_Ini_05, T007R2_A2439Horario_Dia_Ini_06, T007R2_A2440Horario_Dia_Ini_07, T007R2_A2441Horario_Dia_Fin_01,
               T007R2_A2442Horario_Dia_Fin_02, T007R2_A2443Horario_Dia_Fin_03, T007R2_A2444Horario_Dia_Fin_04, T007R2_A2445Horario_Dia_Fin_05, T007R2_A2446Horario_Dia_Fin_06, T007R2_A2447Horario_Dia_Fin_07, T007R2_A2448Horario_Ref_Ini_01, T007R2_A2449Horario_Ref_Ini_02, T007R2_A2450Horario_Ref_Ini_03, T007R2_A2451Horario_Ref_Ini_04,
               T007R2_A2452Horario_Ref_Ini_05, T007R2_A2453Horario_Ref_Ini_06, T007R2_A2454Horario_Ref_Ini_07, T007R2_A2455Horario_Ref_Fin_01, T007R2_A2456Horario_Ref_Fin_02, T007R2_A2457Horario_Ref_Fin_03, T007R2_A2458Horario_Ref_Fin_04, T007R2_A2459Horario_Ref_Fin_05, T007R2_A2460Horario_Ref_Fin_06, T007R2_A2461Horario_Ref_Fin_07,
               T007R2_A2462Horario_Vigencia, T007R2_A2463Horario_Sts, T007R2_A2464Horario_Dia_Toling, T007R2_A2465Horario_Dia_TolRef, T007R2_A2466Horario_Dia_TolSal
               }
               , new Object[] {
               T007R3_A2432Horario_ID, T007R3_A2433Horario_Dsc, T007R3_A2434Horario_Dia_Ini_01, T007R3_A2435Horario_Dia_Ini_02, T007R3_A2436Horario_Dia_Ini_03, T007R3_A2437Horario_Dia_Ini_04, T007R3_A2438Horario_Dia_Ini_05, T007R3_A2439Horario_Dia_Ini_06, T007R3_A2440Horario_Dia_Ini_07, T007R3_A2441Horario_Dia_Fin_01,
               T007R3_A2442Horario_Dia_Fin_02, T007R3_A2443Horario_Dia_Fin_03, T007R3_A2444Horario_Dia_Fin_04, T007R3_A2445Horario_Dia_Fin_05, T007R3_A2446Horario_Dia_Fin_06, T007R3_A2447Horario_Dia_Fin_07, T007R3_A2448Horario_Ref_Ini_01, T007R3_A2449Horario_Ref_Ini_02, T007R3_A2450Horario_Ref_Ini_03, T007R3_A2451Horario_Ref_Ini_04,
               T007R3_A2452Horario_Ref_Ini_05, T007R3_A2453Horario_Ref_Ini_06, T007R3_A2454Horario_Ref_Ini_07, T007R3_A2455Horario_Ref_Fin_01, T007R3_A2456Horario_Ref_Fin_02, T007R3_A2457Horario_Ref_Fin_03, T007R3_A2458Horario_Ref_Fin_04, T007R3_A2459Horario_Ref_Fin_05, T007R3_A2460Horario_Ref_Fin_06, T007R3_A2461Horario_Ref_Fin_07,
               T007R3_A2462Horario_Vigencia, T007R3_A2463Horario_Sts, T007R3_A2464Horario_Dia_Toling, T007R3_A2465Horario_Dia_TolRef, T007R3_A2466Horario_Dia_TolSal
               }
               , new Object[] {
               T007R4_A2432Horario_ID, T007R4_A2433Horario_Dsc, T007R4_A2434Horario_Dia_Ini_01, T007R4_A2435Horario_Dia_Ini_02, T007R4_A2436Horario_Dia_Ini_03, T007R4_A2437Horario_Dia_Ini_04, T007R4_A2438Horario_Dia_Ini_05, T007R4_A2439Horario_Dia_Ini_06, T007R4_A2440Horario_Dia_Ini_07, T007R4_A2441Horario_Dia_Fin_01,
               T007R4_A2442Horario_Dia_Fin_02, T007R4_A2443Horario_Dia_Fin_03, T007R4_A2444Horario_Dia_Fin_04, T007R4_A2445Horario_Dia_Fin_05, T007R4_A2446Horario_Dia_Fin_06, T007R4_A2447Horario_Dia_Fin_07, T007R4_A2448Horario_Ref_Ini_01, T007R4_A2449Horario_Ref_Ini_02, T007R4_A2450Horario_Ref_Ini_03, T007R4_A2451Horario_Ref_Ini_04,
               T007R4_A2452Horario_Ref_Ini_05, T007R4_A2453Horario_Ref_Ini_06, T007R4_A2454Horario_Ref_Ini_07, T007R4_A2455Horario_Ref_Fin_01, T007R4_A2456Horario_Ref_Fin_02, T007R4_A2457Horario_Ref_Fin_03, T007R4_A2458Horario_Ref_Fin_04, T007R4_A2459Horario_Ref_Fin_05, T007R4_A2460Horario_Ref_Fin_06, T007R4_A2461Horario_Ref_Fin_07,
               T007R4_A2462Horario_Vigencia, T007R4_A2463Horario_Sts, T007R4_A2464Horario_Dia_Toling, T007R4_A2465Horario_Dia_TolRef, T007R4_A2466Horario_Dia_TolSal
               }
               , new Object[] {
               T007R5_A2432Horario_ID
               }
               , new Object[] {
               T007R6_A2432Horario_ID
               }
               , new Object[] {
               T007R7_A2432Horario_ID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007R11_A2432Horario_ID
               }
            }
         );
         Z2463Horario_Sts = 1;
         A2463Horario_Sts = 1;
         i2463Horario_Sts = 1;
      }

      private short wcpOAV7Horario_ID ;
      private short Z2432Horario_ID ;
      private short Z2463Horario_Sts ;
      private short GxWebError ;
      private short AV7Horario_ID ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2463Horario_Sts ;
      private short A2432Horario_ID ;
      private short Gx_BScreen ;
      private short RcdFound213 ;
      private short GX_JID ;
      private short nIsDirty_213 ;
      private short gxajaxcallmode ;
      private short i2463Horario_Sts ;
      private int Z2464Horario_Dia_Toling ;
      private int Z2465Horario_Dia_TolRef ;
      private int Z2466Horario_Dia_TolSal ;
      private int trnEnded ;
      private int edtHorario_ID_Enabled ;
      private int edtHorario_Dsc_Enabled ;
      private int edtHorario_Vigencia_Enabled ;
      private int A2464Horario_Dia_Toling ;
      private int edtHorario_Dia_Toling_Enabled ;
      private int A2466Horario_Dia_TolSal ;
      private int edtHorario_Dia_TolSal_Enabled ;
      private int edtHorario_Dia_Ini_01_Enabled ;
      private int edtHorario_Dia_Ini_02_Enabled ;
      private int edtHorario_Dia_Ini_03_Enabled ;
      private int edtHorario_Dia_Ini_04_Enabled ;
      private int edtHorario_Dia_Ini_05_Enabled ;
      private int edtHorario_Dia_Ini_06_Enabled ;
      private int edtHorario_Dia_Ini_07_Enabled ;
      private int edtHorario_Ref_Ini_01_Enabled ;
      private int edtHorario_Ref_Ini_02_Enabled ;
      private int edtHorario_Ref_Ini_03_Enabled ;
      private int edtHorario_Ref_Ini_04_Enabled ;
      private int edtHorario_Ref_Ini_05_Enabled ;
      private int edtHorario_Ref_Ini_06_Enabled ;
      private int edtHorario_Ref_Ini_07_Enabled ;
      private int edtHorario_Ref_Fin_01_Enabled ;
      private int edtHorario_Ref_Fin_02_Enabled ;
      private int edtHorario_Ref_Fin_03_Enabled ;
      private int edtHorario_Ref_Fin_04_Enabled ;
      private int edtHorario_Ref_Fin_05_Enabled ;
      private int edtHorario_Ref_Fin_06_Enabled ;
      private int edtHorario_Ref_Fin_07_Enabled ;
      private int edtHorario_Dia_Fin_01_Enabled ;
      private int edtHorario_Dia_Fin_02_Enabled ;
      private int edtHorario_Dia_Fin_03_Enabled ;
      private int edtHorario_Dia_Fin_04_Enabled ;
      private int edtHorario_Dia_Fin_05_Enabled ;
      private int edtHorario_Dia_Fin_06_Enabled ;
      private int edtHorario_Dia_Fin_07_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A2465Horario_Dia_TolRef ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Dvpanel_table2_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtHorario_ID_Internalname ;
      private string cmbHorario_Sts_Internalname ;
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
      private string TempTags ;
      private string edtHorario_ID_Tooltiptext ;
      private string edtHorario_ID_Jsonclick ;
      private string edtHorario_Dsc_Internalname ;
      private string edtHorario_Dsc_Tooltiptext ;
      private string edtHorario_Dsc_Jsonclick ;
      private string edtHorario_Vigencia_Internalname ;
      private string edtHorario_Vigencia_Tooltiptext ;
      private string edtHorario_Vigencia_Jsonclick ;
      private string cmbHorario_Sts_Jsonclick ;
      private string edtHorario_Dia_Toling_Internalname ;
      private string edtHorario_Dia_Toling_Tooltiptext ;
      private string edtHorario_Dia_Toling_Jsonclick ;
      private string edtHorario_Dia_TolSal_Internalname ;
      private string edtHorario_Dia_TolSal_Tooltiptext ;
      private string edtHorario_Dia_TolSal_Jsonclick ;
      private string Dvpanel_table2_Width ;
      private string Dvpanel_table2_Cls ;
      private string Dvpanel_table2_Title ;
      private string Dvpanel_table2_Iconposition ;
      private string Dvpanel_table2_Internalname ;
      private string divTable2_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string lblLunes_Internalname ;
      private string lblLunes_Jsonclick ;
      private string lblMartes_Internalname ;
      private string lblMartes_Jsonclick ;
      private string lblMiercoles_Internalname ;
      private string lblMiercoles_Jsonclick ;
      private string lblJueves_Internalname ;
      private string lblJueves_Jsonclick ;
      private string lblViernes_Internalname ;
      private string lblViernes_Jsonclick ;
      private string lblSabado_Internalname ;
      private string lblSabado_Jsonclick ;
      private string lblDomingo_Internalname ;
      private string lblDomingo_Jsonclick ;
      private string divUnnamedtable3_Internalname ;
      private string divUnnamedtablehorario_dia_ini_01_Internalname ;
      private string lblTextblockhorario_dia_ini_01_Internalname ;
      private string lblTextblockhorario_dia_ini_01_Jsonclick ;
      private string edtHorario_Dia_Ini_01_Internalname ;
      private string edtHorario_Dia_Ini_01_Tooltiptext ;
      private string edtHorario_Dia_Ini_01_Jsonclick ;
      private string divUnnamedtablehorario_dia_ini_02_Internalname ;
      private string lblTextblockhorario_dia_ini_02_Internalname ;
      private string lblTextblockhorario_dia_ini_02_Jsonclick ;
      private string edtHorario_Dia_Ini_02_Internalname ;
      private string edtHorario_Dia_Ini_02_Tooltiptext ;
      private string edtHorario_Dia_Ini_02_Jsonclick ;
      private string divUnnamedtablehorario_dia_ini_03_Internalname ;
      private string lblTextblockhorario_dia_ini_03_Internalname ;
      private string lblTextblockhorario_dia_ini_03_Jsonclick ;
      private string edtHorario_Dia_Ini_03_Internalname ;
      private string edtHorario_Dia_Ini_03_Tooltiptext ;
      private string edtHorario_Dia_Ini_03_Jsonclick ;
      private string divUnnamedtablehorario_dia_ini_04_Internalname ;
      private string lblTextblockhorario_dia_ini_04_Internalname ;
      private string lblTextblockhorario_dia_ini_04_Jsonclick ;
      private string edtHorario_Dia_Ini_04_Internalname ;
      private string edtHorario_Dia_Ini_04_Tooltiptext ;
      private string edtHorario_Dia_Ini_04_Jsonclick ;
      private string divUnnamedtablehorario_dia_ini_05_Internalname ;
      private string lblTextblockhorario_dia_ini_05_Internalname ;
      private string lblTextblockhorario_dia_ini_05_Jsonclick ;
      private string edtHorario_Dia_Ini_05_Internalname ;
      private string edtHorario_Dia_Ini_05_Tooltiptext ;
      private string edtHorario_Dia_Ini_05_Jsonclick ;
      private string divUnnamedtablehorario_dia_ini_06_Internalname ;
      private string lblTextblockhorario_dia_ini_06_Internalname ;
      private string lblTextblockhorario_dia_ini_06_Jsonclick ;
      private string edtHorario_Dia_Ini_06_Internalname ;
      private string edtHorario_Dia_Ini_06_Tooltiptext ;
      private string edtHorario_Dia_Ini_06_Jsonclick ;
      private string divUnnamedtablehorario_dia_ini_07_Internalname ;
      private string lblTextblockhorario_dia_ini_07_Internalname ;
      private string lblTextblockhorario_dia_ini_07_Jsonclick ;
      private string edtHorario_Dia_Ini_07_Internalname ;
      private string edtHorario_Dia_Ini_07_Tooltiptext ;
      private string edtHorario_Dia_Ini_07_Jsonclick ;
      private string divUnnamedtable4_Internalname ;
      private string divUnnamedtablehorario_ref_ini_01_Internalname ;
      private string lblTextblockhorario_ref_ini_01_Internalname ;
      private string lblTextblockhorario_ref_ini_01_Jsonclick ;
      private string edtHorario_Ref_Ini_01_Internalname ;
      private string edtHorario_Ref_Ini_01_Tooltiptext ;
      private string edtHorario_Ref_Ini_01_Jsonclick ;
      private string divUnnamedtablehorario_ref_ini_02_Internalname ;
      private string lblTextblockhorario_ref_ini_02_Internalname ;
      private string lblTextblockhorario_ref_ini_02_Jsonclick ;
      private string edtHorario_Ref_Ini_02_Internalname ;
      private string edtHorario_Ref_Ini_02_Tooltiptext ;
      private string edtHorario_Ref_Ini_02_Jsonclick ;
      private string divUnnamedtablehorario_ref_ini_03_Internalname ;
      private string lblTextblockhorario_ref_ini_03_Internalname ;
      private string lblTextblockhorario_ref_ini_03_Jsonclick ;
      private string edtHorario_Ref_Ini_03_Internalname ;
      private string edtHorario_Ref_Ini_03_Tooltiptext ;
      private string edtHorario_Ref_Ini_03_Jsonclick ;
      private string divUnnamedtablehorario_ref_ini_04_Internalname ;
      private string lblTextblockhorario_ref_ini_04_Internalname ;
      private string lblTextblockhorario_ref_ini_04_Jsonclick ;
      private string edtHorario_Ref_Ini_04_Internalname ;
      private string edtHorario_Ref_Ini_04_Tooltiptext ;
      private string edtHorario_Ref_Ini_04_Jsonclick ;
      private string divUnnamedtablehorario_ref_ini_05_Internalname ;
      private string lblTextblockhorario_ref_ini_05_Internalname ;
      private string lblTextblockhorario_ref_ini_05_Jsonclick ;
      private string edtHorario_Ref_Ini_05_Internalname ;
      private string edtHorario_Ref_Ini_05_Tooltiptext ;
      private string edtHorario_Ref_Ini_05_Jsonclick ;
      private string divUnnamedtablehorario_ref_ini_06_Internalname ;
      private string lblTextblockhorario_ref_ini_06_Internalname ;
      private string lblTextblockhorario_ref_ini_06_Jsonclick ;
      private string edtHorario_Ref_Ini_06_Internalname ;
      private string edtHorario_Ref_Ini_06_Tooltiptext ;
      private string edtHorario_Ref_Ini_06_Jsonclick ;
      private string divUnnamedtablehorario_ref_ini_07_Internalname ;
      private string lblTextblockhorario_ref_ini_07_Internalname ;
      private string lblTextblockhorario_ref_ini_07_Jsonclick ;
      private string edtHorario_Ref_Ini_07_Internalname ;
      private string edtHorario_Ref_Ini_07_Tooltiptext ;
      private string edtHorario_Ref_Ini_07_Jsonclick ;
      private string divUnnamedtable5_Internalname ;
      private string divUnnamedtablehorario_ref_fin_01_Internalname ;
      private string lblTextblockhorario_ref_fin_01_Internalname ;
      private string lblTextblockhorario_ref_fin_01_Jsonclick ;
      private string edtHorario_Ref_Fin_01_Internalname ;
      private string edtHorario_Ref_Fin_01_Tooltiptext ;
      private string edtHorario_Ref_Fin_01_Jsonclick ;
      private string divUnnamedtablehorario_ref_fin_02_Internalname ;
      private string lblTextblockhorario_ref_fin_02_Internalname ;
      private string lblTextblockhorario_ref_fin_02_Jsonclick ;
      private string edtHorario_Ref_Fin_02_Internalname ;
      private string edtHorario_Ref_Fin_02_Tooltiptext ;
      private string edtHorario_Ref_Fin_02_Jsonclick ;
      private string divUnnamedtablehorario_ref_fin_03_Internalname ;
      private string lblTextblockhorario_ref_fin_03_Internalname ;
      private string lblTextblockhorario_ref_fin_03_Jsonclick ;
      private string edtHorario_Ref_Fin_03_Internalname ;
      private string edtHorario_Ref_Fin_03_Tooltiptext ;
      private string edtHorario_Ref_Fin_03_Jsonclick ;
      private string divUnnamedtablehorario_ref_fin_04_Internalname ;
      private string lblTextblockhorario_ref_fin_04_Internalname ;
      private string lblTextblockhorario_ref_fin_04_Jsonclick ;
      private string edtHorario_Ref_Fin_04_Internalname ;
      private string edtHorario_Ref_Fin_04_Tooltiptext ;
      private string edtHorario_Ref_Fin_04_Jsonclick ;
      private string divUnnamedtablehorario_ref_fin_05_Internalname ;
      private string lblTextblockhorario_ref_fin_05_Internalname ;
      private string lblTextblockhorario_ref_fin_05_Jsonclick ;
      private string edtHorario_Ref_Fin_05_Internalname ;
      private string edtHorario_Ref_Fin_05_Tooltiptext ;
      private string edtHorario_Ref_Fin_05_Jsonclick ;
      private string divUnnamedtablehorario_ref_fin_06_Internalname ;
      private string lblTextblockhorario_ref_fin_06_Internalname ;
      private string lblTextblockhorario_ref_fin_06_Jsonclick ;
      private string edtHorario_Ref_Fin_06_Internalname ;
      private string edtHorario_Ref_Fin_06_Tooltiptext ;
      private string edtHorario_Ref_Fin_06_Jsonclick ;
      private string divUnnamedtablehorario_ref_fin_07_Internalname ;
      private string lblTextblockhorario_ref_fin_07_Internalname ;
      private string lblTextblockhorario_ref_fin_07_Jsonclick ;
      private string edtHorario_Ref_Fin_07_Internalname ;
      private string edtHorario_Ref_Fin_07_Tooltiptext ;
      private string edtHorario_Ref_Fin_07_Jsonclick ;
      private string divUnnamedtable6_Internalname ;
      private string divUnnamedtablehorario_dia_fin_01_Internalname ;
      private string lblTextblockhorario_dia_fin_01_Internalname ;
      private string lblTextblockhorario_dia_fin_01_Jsonclick ;
      private string edtHorario_Dia_Fin_01_Internalname ;
      private string edtHorario_Dia_Fin_01_Tooltiptext ;
      private string edtHorario_Dia_Fin_01_Jsonclick ;
      private string divUnnamedtablehorario_dia_fin_02_Internalname ;
      private string lblTextblockhorario_dia_fin_02_Internalname ;
      private string lblTextblockhorario_dia_fin_02_Jsonclick ;
      private string edtHorario_Dia_Fin_02_Internalname ;
      private string edtHorario_Dia_Fin_02_Tooltiptext ;
      private string edtHorario_Dia_Fin_02_Jsonclick ;
      private string divUnnamedtablehorario_dia_fin_03_Internalname ;
      private string lblTextblockhorario_dia_fin_03_Internalname ;
      private string lblTextblockhorario_dia_fin_03_Jsonclick ;
      private string edtHorario_Dia_Fin_03_Internalname ;
      private string edtHorario_Dia_Fin_03_Tooltiptext ;
      private string edtHorario_Dia_Fin_03_Jsonclick ;
      private string divUnnamedtablehorario_dia_fin_04_Internalname ;
      private string lblTextblockhorario_dia_fin_04_Internalname ;
      private string lblTextblockhorario_dia_fin_04_Jsonclick ;
      private string edtHorario_Dia_Fin_04_Internalname ;
      private string edtHorario_Dia_Fin_04_Tooltiptext ;
      private string edtHorario_Dia_Fin_04_Jsonclick ;
      private string divUnnamedtablehorario_dia_fin_05_Internalname ;
      private string lblTextblockhorario_dia_fin_05_Internalname ;
      private string lblTextblockhorario_dia_fin_05_Jsonclick ;
      private string edtHorario_Dia_Fin_05_Internalname ;
      private string edtHorario_Dia_Fin_05_Tooltiptext ;
      private string edtHorario_Dia_Fin_05_Jsonclick ;
      private string divUnnamedtablehorario_dia_fin_06_Internalname ;
      private string lblTextblockhorario_dia_fin_06_Internalname ;
      private string lblTextblockhorario_dia_fin_06_Jsonclick ;
      private string edtHorario_Dia_Fin_06_Internalname ;
      private string edtHorario_Dia_Fin_06_Tooltiptext ;
      private string edtHorario_Dia_Fin_06_Jsonclick ;
      private string divUnnamedtablehorario_dia_fin_07_Internalname ;
      private string lblTextblockhorario_dia_fin_07_Internalname ;
      private string lblTextblockhorario_dia_fin_07_Jsonclick ;
      private string edtHorario_Dia_Fin_07_Internalname ;
      private string edtHorario_Dia_Fin_07_Tooltiptext ;
      private string edtHorario_Dia_Fin_07_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Dvpanel_table2_Objectcall ;
      private string Dvpanel_table2_Class ;
      private string Dvpanel_table2_Height ;
      private string hsh ;
      private string sMode213 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z2434Horario_Dia_Ini_01 ;
      private DateTime Z2435Horario_Dia_Ini_02 ;
      private DateTime Z2436Horario_Dia_Ini_03 ;
      private DateTime Z2437Horario_Dia_Ini_04 ;
      private DateTime Z2438Horario_Dia_Ini_05 ;
      private DateTime Z2439Horario_Dia_Ini_06 ;
      private DateTime Z2440Horario_Dia_Ini_07 ;
      private DateTime Z2441Horario_Dia_Fin_01 ;
      private DateTime Z2442Horario_Dia_Fin_02 ;
      private DateTime Z2443Horario_Dia_Fin_03 ;
      private DateTime Z2444Horario_Dia_Fin_04 ;
      private DateTime Z2445Horario_Dia_Fin_05 ;
      private DateTime Z2446Horario_Dia_Fin_06 ;
      private DateTime Z2447Horario_Dia_Fin_07 ;
      private DateTime Z2448Horario_Ref_Ini_01 ;
      private DateTime Z2449Horario_Ref_Ini_02 ;
      private DateTime Z2450Horario_Ref_Ini_03 ;
      private DateTime Z2451Horario_Ref_Ini_04 ;
      private DateTime Z2452Horario_Ref_Ini_05 ;
      private DateTime Z2453Horario_Ref_Ini_06 ;
      private DateTime Z2454Horario_Ref_Ini_07 ;
      private DateTime Z2455Horario_Ref_Fin_01 ;
      private DateTime Z2456Horario_Ref_Fin_02 ;
      private DateTime Z2457Horario_Ref_Fin_03 ;
      private DateTime Z2458Horario_Ref_Fin_04 ;
      private DateTime Z2459Horario_Ref_Fin_05 ;
      private DateTime Z2460Horario_Ref_Fin_06 ;
      private DateTime Z2461Horario_Ref_Fin_07 ;
      private DateTime Z2462Horario_Vigencia ;
      private DateTime A2462Horario_Vigencia ;
      private DateTime A2434Horario_Dia_Ini_01 ;
      private DateTime A2435Horario_Dia_Ini_02 ;
      private DateTime A2436Horario_Dia_Ini_03 ;
      private DateTime A2437Horario_Dia_Ini_04 ;
      private DateTime A2438Horario_Dia_Ini_05 ;
      private DateTime A2439Horario_Dia_Ini_06 ;
      private DateTime A2440Horario_Dia_Ini_07 ;
      private DateTime A2448Horario_Ref_Ini_01 ;
      private DateTime A2449Horario_Ref_Ini_02 ;
      private DateTime A2450Horario_Ref_Ini_03 ;
      private DateTime A2451Horario_Ref_Ini_04 ;
      private DateTime A2452Horario_Ref_Ini_05 ;
      private DateTime A2453Horario_Ref_Ini_06 ;
      private DateTime A2454Horario_Ref_Ini_07 ;
      private DateTime A2455Horario_Ref_Fin_01 ;
      private DateTime A2456Horario_Ref_Fin_02 ;
      private DateTime A2457Horario_Ref_Fin_03 ;
      private DateTime A2458Horario_Ref_Fin_04 ;
      private DateTime A2459Horario_Ref_Fin_05 ;
      private DateTime A2460Horario_Ref_Fin_06 ;
      private DateTime A2461Horario_Ref_Fin_07 ;
      private DateTime A2441Horario_Dia_Fin_01 ;
      private DateTime A2442Horario_Dia_Fin_02 ;
      private DateTime A2443Horario_Dia_Fin_03 ;
      private DateTime A2444Horario_Dia_Fin_04 ;
      private DateTime A2445Horario_Dia_Fin_05 ;
      private DateTime A2446Horario_Dia_Fin_06 ;
      private DateTime A2447Horario_Dia_Fin_07 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_table2_Autowidth ;
      private bool Dvpanel_table2_Autoheight ;
      private bool Dvpanel_table2_Collapsible ;
      private bool Dvpanel_table2_Collapsed ;
      private bool Dvpanel_table2_Showcollapseicon ;
      private bool Dvpanel_table2_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Dvpanel_table2_Enabled ;
      private bool Dvpanel_table2_Showheader ;
      private bool Dvpanel_table2_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z2433Horario_Dsc ;
      private string A2433Horario_Dsc ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucDvpanel_table2 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbHorario_Sts ;
      private IDataStoreProvider pr_default ;
      private short[] T007R4_A2432Horario_ID ;
      private string[] T007R4_A2433Horario_Dsc ;
      private DateTime[] T007R4_A2434Horario_Dia_Ini_01 ;
      private DateTime[] T007R4_A2435Horario_Dia_Ini_02 ;
      private DateTime[] T007R4_A2436Horario_Dia_Ini_03 ;
      private DateTime[] T007R4_A2437Horario_Dia_Ini_04 ;
      private DateTime[] T007R4_A2438Horario_Dia_Ini_05 ;
      private DateTime[] T007R4_A2439Horario_Dia_Ini_06 ;
      private DateTime[] T007R4_A2440Horario_Dia_Ini_07 ;
      private DateTime[] T007R4_A2441Horario_Dia_Fin_01 ;
      private DateTime[] T007R4_A2442Horario_Dia_Fin_02 ;
      private DateTime[] T007R4_A2443Horario_Dia_Fin_03 ;
      private DateTime[] T007R4_A2444Horario_Dia_Fin_04 ;
      private DateTime[] T007R4_A2445Horario_Dia_Fin_05 ;
      private DateTime[] T007R4_A2446Horario_Dia_Fin_06 ;
      private DateTime[] T007R4_A2447Horario_Dia_Fin_07 ;
      private DateTime[] T007R4_A2448Horario_Ref_Ini_01 ;
      private DateTime[] T007R4_A2449Horario_Ref_Ini_02 ;
      private DateTime[] T007R4_A2450Horario_Ref_Ini_03 ;
      private DateTime[] T007R4_A2451Horario_Ref_Ini_04 ;
      private DateTime[] T007R4_A2452Horario_Ref_Ini_05 ;
      private DateTime[] T007R4_A2453Horario_Ref_Ini_06 ;
      private DateTime[] T007R4_A2454Horario_Ref_Ini_07 ;
      private DateTime[] T007R4_A2455Horario_Ref_Fin_01 ;
      private DateTime[] T007R4_A2456Horario_Ref_Fin_02 ;
      private DateTime[] T007R4_A2457Horario_Ref_Fin_03 ;
      private DateTime[] T007R4_A2458Horario_Ref_Fin_04 ;
      private DateTime[] T007R4_A2459Horario_Ref_Fin_05 ;
      private DateTime[] T007R4_A2460Horario_Ref_Fin_06 ;
      private DateTime[] T007R4_A2461Horario_Ref_Fin_07 ;
      private DateTime[] T007R4_A2462Horario_Vigencia ;
      private short[] T007R4_A2463Horario_Sts ;
      private int[] T007R4_A2464Horario_Dia_Toling ;
      private int[] T007R4_A2465Horario_Dia_TolRef ;
      private int[] T007R4_A2466Horario_Dia_TolSal ;
      private short[] T007R5_A2432Horario_ID ;
      private short[] T007R3_A2432Horario_ID ;
      private string[] T007R3_A2433Horario_Dsc ;
      private DateTime[] T007R3_A2434Horario_Dia_Ini_01 ;
      private DateTime[] T007R3_A2435Horario_Dia_Ini_02 ;
      private DateTime[] T007R3_A2436Horario_Dia_Ini_03 ;
      private DateTime[] T007R3_A2437Horario_Dia_Ini_04 ;
      private DateTime[] T007R3_A2438Horario_Dia_Ini_05 ;
      private DateTime[] T007R3_A2439Horario_Dia_Ini_06 ;
      private DateTime[] T007R3_A2440Horario_Dia_Ini_07 ;
      private DateTime[] T007R3_A2441Horario_Dia_Fin_01 ;
      private DateTime[] T007R3_A2442Horario_Dia_Fin_02 ;
      private DateTime[] T007R3_A2443Horario_Dia_Fin_03 ;
      private DateTime[] T007R3_A2444Horario_Dia_Fin_04 ;
      private DateTime[] T007R3_A2445Horario_Dia_Fin_05 ;
      private DateTime[] T007R3_A2446Horario_Dia_Fin_06 ;
      private DateTime[] T007R3_A2447Horario_Dia_Fin_07 ;
      private DateTime[] T007R3_A2448Horario_Ref_Ini_01 ;
      private DateTime[] T007R3_A2449Horario_Ref_Ini_02 ;
      private DateTime[] T007R3_A2450Horario_Ref_Ini_03 ;
      private DateTime[] T007R3_A2451Horario_Ref_Ini_04 ;
      private DateTime[] T007R3_A2452Horario_Ref_Ini_05 ;
      private DateTime[] T007R3_A2453Horario_Ref_Ini_06 ;
      private DateTime[] T007R3_A2454Horario_Ref_Ini_07 ;
      private DateTime[] T007R3_A2455Horario_Ref_Fin_01 ;
      private DateTime[] T007R3_A2456Horario_Ref_Fin_02 ;
      private DateTime[] T007R3_A2457Horario_Ref_Fin_03 ;
      private DateTime[] T007R3_A2458Horario_Ref_Fin_04 ;
      private DateTime[] T007R3_A2459Horario_Ref_Fin_05 ;
      private DateTime[] T007R3_A2460Horario_Ref_Fin_06 ;
      private DateTime[] T007R3_A2461Horario_Ref_Fin_07 ;
      private DateTime[] T007R3_A2462Horario_Vigencia ;
      private short[] T007R3_A2463Horario_Sts ;
      private int[] T007R3_A2464Horario_Dia_Toling ;
      private int[] T007R3_A2465Horario_Dia_TolRef ;
      private int[] T007R3_A2466Horario_Dia_TolSal ;
      private short[] T007R6_A2432Horario_ID ;
      private short[] T007R7_A2432Horario_ID ;
      private short[] T007R2_A2432Horario_ID ;
      private string[] T007R2_A2433Horario_Dsc ;
      private DateTime[] T007R2_A2434Horario_Dia_Ini_01 ;
      private DateTime[] T007R2_A2435Horario_Dia_Ini_02 ;
      private DateTime[] T007R2_A2436Horario_Dia_Ini_03 ;
      private DateTime[] T007R2_A2437Horario_Dia_Ini_04 ;
      private DateTime[] T007R2_A2438Horario_Dia_Ini_05 ;
      private DateTime[] T007R2_A2439Horario_Dia_Ini_06 ;
      private DateTime[] T007R2_A2440Horario_Dia_Ini_07 ;
      private DateTime[] T007R2_A2441Horario_Dia_Fin_01 ;
      private DateTime[] T007R2_A2442Horario_Dia_Fin_02 ;
      private DateTime[] T007R2_A2443Horario_Dia_Fin_03 ;
      private DateTime[] T007R2_A2444Horario_Dia_Fin_04 ;
      private DateTime[] T007R2_A2445Horario_Dia_Fin_05 ;
      private DateTime[] T007R2_A2446Horario_Dia_Fin_06 ;
      private DateTime[] T007R2_A2447Horario_Dia_Fin_07 ;
      private DateTime[] T007R2_A2448Horario_Ref_Ini_01 ;
      private DateTime[] T007R2_A2449Horario_Ref_Ini_02 ;
      private DateTime[] T007R2_A2450Horario_Ref_Ini_03 ;
      private DateTime[] T007R2_A2451Horario_Ref_Ini_04 ;
      private DateTime[] T007R2_A2452Horario_Ref_Ini_05 ;
      private DateTime[] T007R2_A2453Horario_Ref_Ini_06 ;
      private DateTime[] T007R2_A2454Horario_Ref_Ini_07 ;
      private DateTime[] T007R2_A2455Horario_Ref_Fin_01 ;
      private DateTime[] T007R2_A2456Horario_Ref_Fin_02 ;
      private DateTime[] T007R2_A2457Horario_Ref_Fin_03 ;
      private DateTime[] T007R2_A2458Horario_Ref_Fin_04 ;
      private DateTime[] T007R2_A2459Horario_Ref_Fin_05 ;
      private DateTime[] T007R2_A2460Horario_Ref_Fin_06 ;
      private DateTime[] T007R2_A2461Horario_Ref_Fin_07 ;
      private DateTime[] T007R2_A2462Horario_Vigencia ;
      private short[] T007R2_A2463Horario_Sts ;
      private int[] T007R2_A2464Horario_Dia_Toling ;
      private int[] T007R2_A2465Horario_Dia_TolRef ;
      private int[] T007R2_A2466Horario_Dia_TolSal ;
      private short[] T007R11_A2432Horario_ID ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
   }

   public class reloj_horario__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class reloj_horario__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007R4;
        prmT007R4 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R5;
        prmT007R5 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R3;
        prmT007R3 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R6;
        prmT007R6 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R7;
        prmT007R7 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R2;
        prmT007R2 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R8;
        prmT007R8 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0) ,
        new ParDef("@Horario_Dsc",GXType.NVarChar,100,5) ,
        new ParDef("@Horario_Dia_Ini_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Vigencia",GXType.DateTime,10,8) ,
        new ParDef("@Horario_Sts",GXType.Int16,1,0) ,
        new ParDef("@Horario_Dia_Toling",GXType.Int32,9,0) ,
        new ParDef("@Horario_Dia_TolRef",GXType.Int32,9,0) ,
        new ParDef("@Horario_Dia_TolSal",GXType.Int32,9,0)
        };
        Object[] prmT007R9;
        prmT007R9 = new Object[] {
        new ParDef("@Horario_Dsc",GXType.NVarChar,100,5) ,
        new ParDef("@Horario_Dia_Ini_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Ini_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Dia_Fin_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Ini_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_01",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_02",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_03",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_04",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_05",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_06",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Ref_Fin_07",GXType.DateTime,0,5) ,
        new ParDef("@Horario_Vigencia",GXType.DateTime,10,8) ,
        new ParDef("@Horario_Sts",GXType.Int16,1,0) ,
        new ParDef("@Horario_Dia_Toling",GXType.Int32,9,0) ,
        new ParDef("@Horario_Dia_TolRef",GXType.Int32,9,0) ,
        new ParDef("@Horario_Dia_TolSal",GXType.Int32,9,0) ,
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R10;
        prmT007R10 = new Object[] {
        new ParDef("@Horario_ID",GXType.Int16,4,0)
        };
        Object[] prmT007R11;
        prmT007R11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T007R2", "SELECT [Horario_ID], [Horario_Dsc], [Horario_Dia_Ini_01], [Horario_Dia_Ini_02], [Horario_Dia_Ini_03], [Horario_Dia_Ini_04], [Horario_Dia_Ini_05], [Horario_Dia_Ini_06], [Horario_Dia_Ini_07], [Horario_Dia_Fin_01], [Horario_Dia_Fin_02], [Horario_Dia_Fin_03], [Horario_Dia_Fin_04], [Horario_Dia_Fin_05], [Horario_Dia_Fin_06], [Horario_Dia_Fin_07], [Horario_Ref_Ini_01], [Horario_Ref_Ini_02], [Horario_Ref_Ini_03], [Horario_Ref_Ini_04], [Horario_Ref_Ini_05], [Horario_Ref_Ini_06], [Horario_Ref_Ini_07], [Horario_Ref_Fin_01], [Horario_Ref_Fin_02], [Horario_Ref_Fin_03], [Horario_Ref_Fin_04], [Horario_Ref_Fin_05], [Horario_Ref_Fin_06], [Horario_Ref_Fin_07], [Horario_Vigencia], [Horario_Sts], [Horario_Dia_Toling], [Horario_Dia_TolRef], [Horario_Dia_TolSal] FROM [Reloj_Horario] WITH (UPDLOCK) WHERE [Horario_ID] = @Horario_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007R3", "SELECT [Horario_ID], [Horario_Dsc], [Horario_Dia_Ini_01], [Horario_Dia_Ini_02], [Horario_Dia_Ini_03], [Horario_Dia_Ini_04], [Horario_Dia_Ini_05], [Horario_Dia_Ini_06], [Horario_Dia_Ini_07], [Horario_Dia_Fin_01], [Horario_Dia_Fin_02], [Horario_Dia_Fin_03], [Horario_Dia_Fin_04], [Horario_Dia_Fin_05], [Horario_Dia_Fin_06], [Horario_Dia_Fin_07], [Horario_Ref_Ini_01], [Horario_Ref_Ini_02], [Horario_Ref_Ini_03], [Horario_Ref_Ini_04], [Horario_Ref_Ini_05], [Horario_Ref_Ini_06], [Horario_Ref_Ini_07], [Horario_Ref_Fin_01], [Horario_Ref_Fin_02], [Horario_Ref_Fin_03], [Horario_Ref_Fin_04], [Horario_Ref_Fin_05], [Horario_Ref_Fin_06], [Horario_Ref_Fin_07], [Horario_Vigencia], [Horario_Sts], [Horario_Dia_Toling], [Horario_Dia_TolRef], [Horario_Dia_TolSal] FROM [Reloj_Horario] WHERE [Horario_ID] = @Horario_ID ",true, GxErrorMask.GX_NOMASK, false, this,prmT007R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007R4", "SELECT TM1.[Horario_ID], TM1.[Horario_Dsc], TM1.[Horario_Dia_Ini_01], TM1.[Horario_Dia_Ini_02], TM1.[Horario_Dia_Ini_03], TM1.[Horario_Dia_Ini_04], TM1.[Horario_Dia_Ini_05], TM1.[Horario_Dia_Ini_06], TM1.[Horario_Dia_Ini_07], TM1.[Horario_Dia_Fin_01], TM1.[Horario_Dia_Fin_02], TM1.[Horario_Dia_Fin_03], TM1.[Horario_Dia_Fin_04], TM1.[Horario_Dia_Fin_05], TM1.[Horario_Dia_Fin_06], TM1.[Horario_Dia_Fin_07], TM1.[Horario_Ref_Ini_01], TM1.[Horario_Ref_Ini_02], TM1.[Horario_Ref_Ini_03], TM1.[Horario_Ref_Ini_04], TM1.[Horario_Ref_Ini_05], TM1.[Horario_Ref_Ini_06], TM1.[Horario_Ref_Ini_07], TM1.[Horario_Ref_Fin_01], TM1.[Horario_Ref_Fin_02], TM1.[Horario_Ref_Fin_03], TM1.[Horario_Ref_Fin_04], TM1.[Horario_Ref_Fin_05], TM1.[Horario_Ref_Fin_06], TM1.[Horario_Ref_Fin_07], TM1.[Horario_Vigencia], TM1.[Horario_Sts], TM1.[Horario_Dia_Toling], TM1.[Horario_Dia_TolRef], TM1.[Horario_Dia_TolSal] FROM [Reloj_Horario] TM1 WHERE TM1.[Horario_ID] = @Horario_ID ORDER BY TM1.[Horario_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007R4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007R5", "SELECT [Horario_ID] FROM [Reloj_Horario] WHERE [Horario_ID] = @Horario_ID  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007R6", "SELECT TOP 1 [Horario_ID] FROM [Reloj_Horario] WHERE ( [Horario_ID] > @Horario_ID) ORDER BY [Horario_ID]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007R6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007R7", "SELECT TOP 1 [Horario_ID] FROM [Reloj_Horario] WHERE ( [Horario_ID] < @Horario_ID) ORDER BY [Horario_ID] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007R7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007R8", "INSERT INTO [Reloj_Horario]([Horario_ID], [Horario_Dsc], [Horario_Dia_Ini_01], [Horario_Dia_Ini_02], [Horario_Dia_Ini_03], [Horario_Dia_Ini_04], [Horario_Dia_Ini_05], [Horario_Dia_Ini_06], [Horario_Dia_Ini_07], [Horario_Dia_Fin_01], [Horario_Dia_Fin_02], [Horario_Dia_Fin_03], [Horario_Dia_Fin_04], [Horario_Dia_Fin_05], [Horario_Dia_Fin_06], [Horario_Dia_Fin_07], [Horario_Ref_Ini_01], [Horario_Ref_Ini_02], [Horario_Ref_Ini_03], [Horario_Ref_Ini_04], [Horario_Ref_Ini_05], [Horario_Ref_Ini_06], [Horario_Ref_Ini_07], [Horario_Ref_Fin_01], [Horario_Ref_Fin_02], [Horario_Ref_Fin_03], [Horario_Ref_Fin_04], [Horario_Ref_Fin_05], [Horario_Ref_Fin_06], [Horario_Ref_Fin_07], [Horario_Vigencia], [Horario_Sts], [Horario_Dia_Toling], [Horario_Dia_TolRef], [Horario_Dia_TolSal]) VALUES(@Horario_ID, @Horario_Dsc, @Horario_Dia_Ini_01, @Horario_Dia_Ini_02, @Horario_Dia_Ini_03, @Horario_Dia_Ini_04, @Horario_Dia_Ini_05, @Horario_Dia_Ini_06, @Horario_Dia_Ini_07, @Horario_Dia_Fin_01, @Horario_Dia_Fin_02, @Horario_Dia_Fin_03, @Horario_Dia_Fin_04, @Horario_Dia_Fin_05, @Horario_Dia_Fin_06, @Horario_Dia_Fin_07, @Horario_Ref_Ini_01, @Horario_Ref_Ini_02, @Horario_Ref_Ini_03, @Horario_Ref_Ini_04, @Horario_Ref_Ini_05, @Horario_Ref_Ini_06, @Horario_Ref_Ini_07, @Horario_Ref_Fin_01, @Horario_Ref_Fin_02, @Horario_Ref_Fin_03, @Horario_Ref_Fin_04, @Horario_Ref_Fin_05, @Horario_Ref_Fin_06, @Horario_Ref_Fin_07, @Horario_Vigencia, @Horario_Sts, @Horario_Dia_Toling, @Horario_Dia_TolRef, @Horario_Dia_TolSal)", GxErrorMask.GX_NOMASK,prmT007R8)
           ,new CursorDef("T007R9", "UPDATE [Reloj_Horario] SET [Horario_Dsc]=@Horario_Dsc, [Horario_Dia_Ini_01]=@Horario_Dia_Ini_01, [Horario_Dia_Ini_02]=@Horario_Dia_Ini_02, [Horario_Dia_Ini_03]=@Horario_Dia_Ini_03, [Horario_Dia_Ini_04]=@Horario_Dia_Ini_04, [Horario_Dia_Ini_05]=@Horario_Dia_Ini_05, [Horario_Dia_Ini_06]=@Horario_Dia_Ini_06, [Horario_Dia_Ini_07]=@Horario_Dia_Ini_07, [Horario_Dia_Fin_01]=@Horario_Dia_Fin_01, [Horario_Dia_Fin_02]=@Horario_Dia_Fin_02, [Horario_Dia_Fin_03]=@Horario_Dia_Fin_03, [Horario_Dia_Fin_04]=@Horario_Dia_Fin_04, [Horario_Dia_Fin_05]=@Horario_Dia_Fin_05, [Horario_Dia_Fin_06]=@Horario_Dia_Fin_06, [Horario_Dia_Fin_07]=@Horario_Dia_Fin_07, [Horario_Ref_Ini_01]=@Horario_Ref_Ini_01, [Horario_Ref_Ini_02]=@Horario_Ref_Ini_02, [Horario_Ref_Ini_03]=@Horario_Ref_Ini_03, [Horario_Ref_Ini_04]=@Horario_Ref_Ini_04, [Horario_Ref_Ini_05]=@Horario_Ref_Ini_05, [Horario_Ref_Ini_06]=@Horario_Ref_Ini_06, [Horario_Ref_Ini_07]=@Horario_Ref_Ini_07, [Horario_Ref_Fin_01]=@Horario_Ref_Fin_01, [Horario_Ref_Fin_02]=@Horario_Ref_Fin_02, [Horario_Ref_Fin_03]=@Horario_Ref_Fin_03, [Horario_Ref_Fin_04]=@Horario_Ref_Fin_04, [Horario_Ref_Fin_05]=@Horario_Ref_Fin_05, [Horario_Ref_Fin_06]=@Horario_Ref_Fin_06, [Horario_Ref_Fin_07]=@Horario_Ref_Fin_07, [Horario_Vigencia]=@Horario_Vigencia, [Horario_Sts]=@Horario_Sts, [Horario_Dia_Toling]=@Horario_Dia_Toling, [Horario_Dia_TolRef]=@Horario_Dia_TolRef, [Horario_Dia_TolSal]=@Horario_Dia_TolSal  WHERE [Horario_ID] = @Horario_ID", GxErrorMask.GX_NOMASK,prmT007R9)
           ,new CursorDef("T007R10", "DELETE FROM [Reloj_Horario]  WHERE [Horario_ID] = @Horario_ID", GxErrorMask.GX_NOMASK,prmT007R10)
           ,new CursorDef("T007R11", "SELECT [Horario_ID] FROM [Reloj_Horario] ORDER BY [Horario_ID]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007R11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(16);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(18);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(19);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(23);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(24);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(25);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(26);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(27);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(28);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(29);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(30);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((int[]) buf[34])[0] = rslt.getInt(35);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(16);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(18);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(19);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(23);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(24);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(25);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(26);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(27);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(28);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(29);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(30);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((int[]) buf[34])[0] = rslt.getInt(35);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(16);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(18);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(19);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(20);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(23);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(24);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(25);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(26);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(27);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(28);
              ((DateTime[]) buf[28])[0] = rslt.getGXDateTime(29);
              ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(30);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((int[]) buf[34])[0] = rslt.getInt(35);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
     }
  }

}

}
