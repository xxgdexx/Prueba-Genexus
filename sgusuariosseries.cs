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
   public class sgusuariosseries : GXDataArea
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
            A149TipCod = GetPar( "TipCod");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A149TipCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridsgusuariosseries_tip") == 0 )
         {
            nRC_GXsfl_34 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_34"), "."));
            nGXsfl_34_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_34_idx"), "."));
            sGXsfl_34_idx = GetPar( "sGXsfl_34_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridsgusuariosseries_tip_newrow( ) ;
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
            Form.Meta.addItem("description", "Series por Usuarios", 0) ;
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

      public sgusuariosseries( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sgusuariosseries( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Series por Usuarios", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIOSSERIES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_SGUSUARIOSSERIES.htm");
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
         GxWebStd.gx_single_line_edit( context, edtUsuCod_Internalname, StringUtil.RTrim( A348UsuCod), StringUtil.RTrim( context.localUtil.Format( A348UsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitletip_Internalname, "Tip", "", "", lblTitletip_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridsgusuariosseries_tip( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_SGUSUARIOSSERIES.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridsgusuariosseries_tip( )
      {
         /*  Grid Control  */
         Gridsgusuariosseries_tipContainer.AddObjectProperty("GridName", "Gridsgusuariosseries_tip");
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Header", subGridsgusuariosseries_tip_Header);
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Class", "Grid");
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Backcolorstyle), 1, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("CmpContext", "");
         Gridsgusuariosseries_tipContainer.AddObjectProperty("InMasterPage", "false");
         Gridsgusuariosseries_tipColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsgusuariosseries_tipColumn.AddObjectProperty("Value", StringUtil.RTrim( A149TipCod));
         Gridsgusuariosseries_tipColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddColumnProperties(Gridsgusuariosseries_tipColumn);
         Gridsgusuariosseries_tipColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridsgusuariosseries_tipColumn.AddObjectProperty("Value", StringUtil.RTrim( A351UsuSerDet));
         Gridsgusuariosseries_tipColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddColumnProperties(Gridsgusuariosseries_tipColumn);
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Selectedindex), 4, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Allowselection), 1, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Selectioncolor), 9, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Allowhovering), 1, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Hoveringcolor), 9, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Allowcollapsing), 1, 0, ".", "")));
         Gridsgusuariosseries_tipContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridsgusuariosseries_tip_Collapsed), 1, 0, ".", "")));
         nGXsfl_34_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount34 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_34 = 1;
               ScanStart1034( ) ;
               while ( RcdFound34 != 0 )
               {
                  init_level_properties34( ) ;
                  getByPrimaryKey1034( ) ;
                  AddRow1034( ) ;
                  ScanNext1034( ) ;
               }
               ScanEnd1034( ) ;
               nBlankRcdCount34 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1034( ) ;
            standaloneModal1034( ) ;
            sMode34 = Gx_mode;
            while ( nGXsfl_34_idx < nRC_GXsfl_34 )
            {
               bGXsfl_34_Refreshing = true;
               ReadRow1034( ) ;
               edtTipCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "TIPCOD_"+sGXsfl_34_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               edtUsuSerDet_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUSERDET_"+sGXsfl_34_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               if ( ( nRcdExists_34 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1034( ) ;
               }
               SendRow1034( ) ;
               bGXsfl_34_Refreshing = false;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount34 = 5;
            nRcdExists_34 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1034( ) ;
               while ( RcdFound34 != 0 )
               {
                  sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3434( ) ;
                  init_level_properties34( ) ;
                  standaloneNotModal1034( ) ;
                  getByPrimaryKey1034( ) ;
                  standaloneModal1034( ) ;
                  AddRow1034( ) ;
                  ScanNext1034( ) ;
               }
               ScanEnd1034( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode34 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx+1), 4, 0), 4, "0");
         SubsflControlProps_3434( ) ;
         InitAll1034( ) ;
         init_level_properties34( ) ;
         nRcdExists_34 = 0;
         nIsMod_34 = 0;
         nRcdDeleted_34 = 0;
         nBlankRcdCount34 = (short)(nBlankRcdUsr34+nBlankRcdCount34);
         fRowAdded = 0;
         while ( nBlankRcdCount34 > 0 )
         {
            standaloneNotModal1034( ) ;
            standaloneModal1034( ) ;
            AddRow1034( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount34 = (short)(nBlankRcdCount34-1);
         }
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridsgusuariosseries_tipContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridsgusuariosseries_tip", Gridsgusuariosseries_tipContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsgusuariosseries_tipContainerData", Gridsgusuariosseries_tipContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridsgusuariosseries_tipContainerData"+"V", Gridsgusuariosseries_tipContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridsgusuariosseries_tipContainerData"+"V"+"\" value='"+Gridsgusuariosseries_tipContainer.GridValuesHidden()+"'/>") ;
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
            Z348UsuCod = cgiGet( "Z348UsuCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_34 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), ".", ","));
            /* Read variables values. */
            A348UsuCod = cgiGet( edtUsuCod_Internalname);
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
               A348UsuCod = GetPar( "UsuCod");
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
               InitAll1032( ) ;
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
         DisableAttributes1032( ) ;
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

      protected void CONFIRM_1034( )
      {
         nGXsfl_34_idx = 0;
         while ( nGXsfl_34_idx < nRC_GXsfl_34 )
         {
            ReadRow1034( ) ;
            if ( ( nRcdExists_34 != 0 ) || ( nIsMod_34 != 0 ) )
            {
               GetKey1034( ) ;
               if ( ( nRcdExists_34 == 0 ) && ( nRcdDeleted_34 == 0 ) )
               {
                  if ( RcdFound34 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1034( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1034( ) ;
                        CloseExtendedTableCursors1034( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "TIPCOD_" + sGXsfl_34_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound34 != 0 )
                  {
                     if ( nRcdDeleted_34 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1034( ) ;
                        Load1034( ) ;
                        BeforeValidate1034( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1034( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_34 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1034( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1034( ) ;
                              CloseExtendedTableCursors1034( ) ;
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
                     if ( nRcdDeleted_34 == 0 )
                     {
                        GXCCtl = "TIPCOD_" + sGXsfl_34_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTipCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtTipCod_Internalname, StringUtil.RTrim( A149TipCod)) ;
            ChangePostValue( edtUsuSerDet_Internalname, StringUtil.RTrim( A351UsuSerDet)) ;
            ChangePostValue( "ZT_"+"Z149TipCod_"+sGXsfl_34_idx, StringUtil.RTrim( Z149TipCod)) ;
            ChangePostValue( "ZT_"+"Z351UsuSerDet_"+sGXsfl_34_idx, StringUtil.RTrim( Z351UsuSerDet)) ;
            ChangePostValue( "nRcdDeleted_34_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_34), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_34_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_34), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_34_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_34), 4, 0, ".", ""))) ;
            if ( nIsMod_34 != 0 )
            {
               ChangePostValue( "TIPCOD_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUSERDET_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption100( )
      {
      }

      protected void ZM1032( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -1 )
         {
            Z348UsuCod = A348UsuCod;
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

      protected void Load1032( )
      {
         /* Using cursor T00107 */
         pr_default.execute(5, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound32 = 1;
            ZM1032( -1) ;
         }
         pr_default.close(5);
         OnLoadActions1032( ) ;
      }

      protected void OnLoadActions1032( )
      {
      }

      protected void CheckExtendedTable1032( )
      {
         nIsDirty_32 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1032( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1032( )
      {
         /* Using cursor T00108 */
         pr_default.execute(6, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound32 = 1;
         }
         else
         {
            RcdFound32 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00106 */
         pr_default.execute(4, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1032( 1) ;
            RcdFound32 = 1;
            A348UsuCod = T00106_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
            Z348UsuCod = A348UsuCod;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1032( ) ;
            if ( AnyError == 1 )
            {
               RcdFound32 = 0;
               InitializeNonKey1032( ) ;
            }
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound32 = 0;
            InitializeNonKey1032( ) ;
            sMode32 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode32;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey1032( ) ;
         if ( RcdFound32 == 0 )
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
         RcdFound32 = 0;
         /* Using cursor T00109 */
         pr_default.execute(7, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00109_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00109_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               A348UsuCod = T00109_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound32 = 0;
         /* Using cursor T001010 */
         pr_default.execute(8, new Object[] {A348UsuCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001010_A348UsuCod[0], A348UsuCod) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001010_A348UsuCod[0], A348UsuCod) < 0 ) ) )
            {
               A348UsuCod = T001010_A348UsuCod[0];
               AssignAttri("", false, "A348UsuCod", A348UsuCod);
               RcdFound32 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1032( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1032( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound32 == 1 )
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  A348UsuCod = Z348UsuCod;
                  AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
                  Update1032( ) ;
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1032( ) ;
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
                     Insert1032( ) ;
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
         if ( StringUtil.StrCmp(A348UsuCod, Z348UsuCod) != 0 )
         {
            A348UsuCod = Z348UsuCod;
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "USUCOD");
            AnyError = 1;
            GX_FocusControl = edtUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1032( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1032( ) ;
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
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
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1032( ) ;
         if ( RcdFound32 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound32 != 0 )
            {
               ScanNext1032( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1032( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1032( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00105 */
            pr_default.execute(3, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1032( )
      {
         BeforeValidate1032( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1032( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1032( 0) ;
            CheckOptimisticConcurrency1032( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1032( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1032( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001011 */
                     pr_default.execute(9, new Object[] {A348UsuCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel1032( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption100( ) ;
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
               Load1032( ) ;
            }
            EndLevel1032( ) ;
         }
         CloseExtendedTableCursors1032( ) ;
      }

      protected void Update1032( )
      {
         BeforeValidate1032( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1032( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1032( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1032( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1032( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table [SGUSUARIOS] */
                     DeferredUpdate1032( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1032( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption100( ) ;
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
            EndLevel1032( ) ;
         }
         CloseExtendedTableCursors1032( ) ;
      }

      protected void DeferredUpdate1032( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1032( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1032( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1032( ) ;
            AfterConfirm1032( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1032( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1034( ) ;
                  while ( RcdFound34 != 0 )
                  {
                     getByPrimaryKey1034( ) ;
                     Delete1034( ) ;
                     ScanNext1034( ) ;
                  }
                  ScanEnd1034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001012 */
                     pr_default.execute(10, new Object[] {A348UsuCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound32 == 0 )
                           {
                              InitAll1032( ) ;
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
                           ResetCaption100( ) ;
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
         sMode32 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1032( ) ;
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1032( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001013 */
            pr_default.execute(11, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONESDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T001014 */
            pr_default.execute(12, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGNOTIFICACIONES"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001015 */
            pr_default.execute(13, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Objetos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001016 */
            pr_default.execute(14, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"SGUSUARIONIV1"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001017 */
            pr_default.execute(15, new Object[] {A348UsuCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void ProcessNestedLevel1034( )
      {
         nGXsfl_34_idx = 0;
         while ( nGXsfl_34_idx < nRC_GXsfl_34 )
         {
            ReadRow1034( ) ;
            if ( ( nRcdExists_34 != 0 ) || ( nIsMod_34 != 0 ) )
            {
               standaloneNotModal1034( ) ;
               GetKey1034( ) ;
               if ( ( nRcdExists_34 == 0 ) && ( nRcdDeleted_34 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1034( ) ;
               }
               else
               {
                  if ( RcdFound34 != 0 )
                  {
                     if ( ( nRcdDeleted_34 != 0 ) && ( nRcdExists_34 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1034( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_34 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1034( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_34 == 0 )
                     {
                        GXCCtl = "TIPCOD_" + sGXsfl_34_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTipCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtTipCod_Internalname, StringUtil.RTrim( A149TipCod)) ;
            ChangePostValue( edtUsuSerDet_Internalname, StringUtil.RTrim( A351UsuSerDet)) ;
            ChangePostValue( "ZT_"+"Z149TipCod_"+sGXsfl_34_idx, StringUtil.RTrim( Z149TipCod)) ;
            ChangePostValue( "ZT_"+"Z351UsuSerDet_"+sGXsfl_34_idx, StringUtil.RTrim( Z351UsuSerDet)) ;
            ChangePostValue( "nRcdDeleted_34_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_34), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_34_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_34), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_34_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_34), 4, 0, ".", ""))) ;
            if ( nIsMod_34 != 0 )
            {
               ChangePostValue( "TIPCOD_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "USUSERDET_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1034( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_34 = 0;
         nIsMod_34 = 0;
         nRcdDeleted_34 = 0;
      }

      protected void ProcessLevel1032( )
      {
         /* Save parent mode. */
         sMode32 = Gx_mode;
         ProcessNestedLevel1034( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode32;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1032( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1032( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("sgusuariosseries",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues100( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("sgusuariosseries",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1032( )
      {
         /* Using cursor T001018 */
         pr_default.execute(16);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T001018_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1032( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound32 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound32 = 1;
            A348UsuCod = T001018_A348UsuCod[0];
            AssignAttri("", false, "A348UsuCod", A348UsuCod);
         }
      }

      protected void ScanEnd1032( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1032( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1032( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1032( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1032( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1032( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1032( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1032( )
      {
         edtUsuCod_Enabled = 0;
         AssignProp("", false, edtUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuCod_Enabled), 5, 0), true);
      }

      protected void ZM1034( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -2 )
         {
            Z348UsuCod = A348UsuCod;
            Z351UsuSerDet = A351UsuSerDet;
            Z149TipCod = A149TipCod;
         }
      }

      protected void standaloneNotModal1034( )
      {
      }

      protected void standaloneModal1034( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtTipCod_Enabled = 0;
            AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         }
         else
         {
            edtTipCod_Enabled = 1;
            AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtUsuSerDet_Enabled = 0;
            AssignProp("", false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         }
         else
         {
            edtUsuSerDet_Enabled = 1;
            AssignProp("", false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         }
      }

      protected void Load1034( )
      {
         /* Using cursor T001019 */
         pr_default.execute(17, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound34 = 1;
            ZM1034( -2) ;
         }
         pr_default.close(17);
         OnLoadActions1034( ) ;
      }

      protected void OnLoadActions1034( )
      {
      }

      protected void CheckExtendedTable1034( )
      {
         nIsDirty_34 = 0;
         Gx_BScreen = 1;
         standaloneModal1034( ) ;
         /* Using cursor T00104 */
         pr_default.execute(2, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "TIPCOD_" + sGXsfl_34_idx;
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1034( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1034( )
      {
      }

      protected void gxLoad_3( string A149TipCod )
      {
         /* Using cursor T001020 */
         pr_default.execute(18, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GXCCtl = "TIPCOD_" + sGXsfl_34_idx;
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey1034( )
      {
         /* Using cursor T001021 */
         pr_default.execute(19, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey1034( )
      {
         /* Using cursor T00103 */
         pr_default.execute(1, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1034( 2) ;
            RcdFound34 = 1;
            InitializeNonKey1034( ) ;
            A351UsuSerDet = T00103_A351UsuSerDet[0];
            A149TipCod = T00103_A149TipCod[0];
            Z348UsuCod = A348UsuCod;
            Z149TipCod = A149TipCod;
            Z351UsuSerDet = A351UsuSerDet;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1034( ) ;
            Load1034( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey1034( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1034( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1034( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1034( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00102 */
            pr_default.execute(0, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGUSUARIOSSERIES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGUSUARIOSSERIES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1034( )
      {
         BeforeValidate1034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1034( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1034( 0) ;
            CheckOptimisticConcurrency1034( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1034( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1034( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001022 */
                     pr_default.execute(20, new Object[] {A348UsuCod, A351UsuSerDet, A149TipCod});
                     pr_default.close(20);
                     dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOSSERIES");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load1034( ) ;
            }
            EndLevel1034( ) ;
         }
         CloseExtendedTableCursors1034( ) ;
      }

      protected void Update1034( )
      {
         BeforeValidate1034( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1034( ) ;
         }
         if ( ( nIsMod_34 != 0 ) || ( nIsDirty_34 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1034( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1034( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1034( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [SGUSUARIOSSERIES] */
                        DeferredUpdate1034( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1034( ) ;
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
               EndLevel1034( ) ;
            }
         }
         CloseExtendedTableCursors1034( ) ;
      }

      protected void DeferredUpdate1034( )
      {
      }

      protected void Delete1034( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1034( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1034( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1034( ) ;
            AfterConfirm1034( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1034( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001023 */
                  pr_default.execute(21, new Object[] {A348UsuCod, A149TipCod, A351UsuSerDet});
                  pr_default.close(21);
                  dsDefault.SmartCacheProvider.SetUpdated("SGUSUARIOSSERIES");
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1034( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1034( )
      {
         standaloneModal1034( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1034( )
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

      public void ScanStart1034( )
      {
         /* Scan By routine */
         /* Using cursor T001024 */
         pr_default.execute(22, new Object[] {A348UsuCod});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound34 = 1;
            A149TipCod = T001024_A149TipCod[0];
            A351UsuSerDet = T001024_A351UsuSerDet[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1034( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound34 = 1;
            A149TipCod = T001024_A149TipCod[0];
            A351UsuSerDet = T001024_A351UsuSerDet[0];
         }
      }

      protected void ScanEnd1034( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm1034( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1034( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1034( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1034( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1034( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1034( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1034( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         edtUsuSerDet_Enabled = 0;
         AssignProp("", false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_34_Refreshing);
      }

      protected void send_integrity_lvl_hashes1034( )
      {
      }

      protected void send_integrity_lvl_hashes1032( )
      {
      }

      protected void SubsflControlProps_3434( )
      {
         edtTipCod_Internalname = "TIPCOD_"+sGXsfl_34_idx;
         edtUsuSerDet_Internalname = "USUSERDET_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_3434( )
      {
         edtTipCod_Internalname = "TIPCOD_"+sGXsfl_34_fel_idx;
         edtUsuSerDet_Internalname = "USUSERDET_"+sGXsfl_34_fel_idx;
      }

      protected void AddRow1034( )
      {
         nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_3434( ) ;
         SendRow1034( ) ;
      }

      protected void SendRow1034( )
      {
         Gridsgusuariosseries_tipRow = GXWebRow.GetNew(context);
         if ( subGridsgusuariosseries_tip_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridsgusuariosseries_tip_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridsgusuariosseries_tip_Class, "") != 0 )
            {
               subGridsgusuariosseries_tip_Linesclass = subGridsgusuariosseries_tip_Class+"Odd";
            }
         }
         else if ( subGridsgusuariosseries_tip_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridsgusuariosseries_tip_Backstyle = 0;
            subGridsgusuariosseries_tip_Backcolor = subGridsgusuariosseries_tip_Allbackcolor;
            if ( StringUtil.StrCmp(subGridsgusuariosseries_tip_Class, "") != 0 )
            {
               subGridsgusuariosseries_tip_Linesclass = subGridsgusuariosseries_tip_Class+"Uniform";
            }
         }
         else if ( subGridsgusuariosseries_tip_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridsgusuariosseries_tip_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridsgusuariosseries_tip_Class, "") != 0 )
            {
               subGridsgusuariosseries_tip_Linesclass = subGridsgusuariosseries_tip_Class+"Odd";
            }
            subGridsgusuariosseries_tip_Backcolor = (int)(0x0);
         }
         else if ( subGridsgusuariosseries_tip_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridsgusuariosseries_tip_Backstyle = 1;
            if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
            {
               subGridsgusuariosseries_tip_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsgusuariosseries_tip_Class, "") != 0 )
               {
                  subGridsgusuariosseries_tip_Linesclass = subGridsgusuariosseries_tip_Class+"Even";
               }
            }
            else
            {
               subGridsgusuariosseries_tip_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridsgusuariosseries_tip_Class, "") != 0 )
               {
                  subGridsgusuariosseries_tip_Linesclass = subGridsgusuariosseries_tip_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_34_" + sGXsfl_34_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_34_idx + "',34)\"";
         ROClassString = "Attribute";
         Gridsgusuariosseries_tipRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipCod_Internalname,StringUtil.RTrim( A149TipCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtTipCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)34,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_34_" + sGXsfl_34_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_34_idx + "',34)\"";
         ROClassString = "Attribute";
         Gridsgusuariosseries_tipRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtUsuSerDet_Internalname,StringUtil.RTrim( A351UsuSerDet),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtUsuSerDet_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtUsuSerDet_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)34,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridsgusuariosseries_tipRow);
         send_integrity_lvl_hashes1034( ) ;
         GXCCtl = "Z149TipCod_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z149TipCod));
         GXCCtl = "Z351UsuSerDet_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z351UsuSerDet));
         GXCCtl = "nRcdDeleted_34_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_34), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_34_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_34), 4, 0, ".", "")));
         GXCCtl = "nIsMod_34_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_34), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIPCOD_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "USUSERDET_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtUsuSerDet_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridsgusuariosseries_tipContainer.AddRow(Gridsgusuariosseries_tipRow);
      }

      protected void ReadRow1034( )
      {
         nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_3434( ) ;
         edtTipCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "TIPCOD_"+sGXsfl_34_idx+"Enabled"), ".", ","));
         edtUsuSerDet_Enabled = (int)(context.localUtil.CToN( cgiGet( "USUSERDET_"+sGXsfl_34_idx+"Enabled"), ".", ","));
         A149TipCod = cgiGet( edtTipCod_Internalname);
         A351UsuSerDet = cgiGet( edtUsuSerDet_Internalname);
         GXCCtl = "Z149TipCod_" + sGXsfl_34_idx;
         Z149TipCod = cgiGet( GXCCtl);
         GXCCtl = "Z351UsuSerDet_" + sGXsfl_34_idx;
         Z351UsuSerDet = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_34_" + sGXsfl_34_idx;
         nRcdDeleted_34 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_34_" + sGXsfl_34_idx;
         nRcdExists_34 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_34_" + sGXsfl_34_idx;
         nIsMod_34 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtUsuSerDet_Enabled = edtUsuSerDet_Enabled;
         defedtTipCod_Enabled = edtTipCod_Enabled;
      }

      protected void ConfirmValues100( )
      {
         nGXsfl_34_idx = 0;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_3434( ) ;
         while ( nGXsfl_34_idx < nRC_GXsfl_34 )
         {
            nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_3434( ) ;
            ChangePostValue( "Z149TipCod_"+sGXsfl_34_idx, cgiGet( "ZT_"+"Z149TipCod_"+sGXsfl_34_idx)) ;
            DeletePostValue( "ZT_"+"Z149TipCod_"+sGXsfl_34_idx) ;
            ChangePostValue( "Z351UsuSerDet_"+sGXsfl_34_idx, cgiGet( "ZT_"+"Z351UsuSerDet_"+sGXsfl_34_idx)) ;
            DeletePostValue( "ZT_"+"Z351UsuSerDet_"+sGXsfl_34_idx) ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281811443756", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("sgusuariosseries.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_34_idx), 8, 0, ".", "")));
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
         return formatLink("sgusuariosseries.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "SGUSUARIOSSERIES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Series por Usuarios" ;
      }

      protected void InitializeNonKey1032( )
      {
      }

      protected void InitAll1032( )
      {
         A348UsuCod = "";
         AssignAttri("", false, "A348UsuCod", A348UsuCod);
         InitializeNonKey1032( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1034( )
      {
      }

      protected void InitAll1034( )
      {
         A149TipCod = "";
         A351UsuSerDet = "";
         InitializeNonKey1034( ) ;
      }

      protected void StandaloneModalInsert1034( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443760", true, true);
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
         context.AddJavascriptSource("sgusuariosseries.js", "?202281811443760", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties34( )
      {
         edtUsuSerDet_Enabled = defedtUsuSerDet_Enabled;
         AssignProp("", false, edtUsuSerDet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUsuSerDet_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         edtTipCod_Enabled = defedtTipCod_Enabled;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
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
         lblTitletip_Internalname = "TITLETIP";
         edtTipCod_Internalname = "TIPCOD";
         edtUsuSerDet_Internalname = "USUSERDET";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridsgusuariosseries_tip_Internalname = "GRIDSGUSUARIOSSERIES_TIP";
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
         Form.Caption = "Series por Usuarios";
         edtUsuSerDet_Jsonclick = "";
         edtTipCod_Jsonclick = "";
         subGridsgusuariosseries_tip_Class = "Grid";
         subGridsgusuariosseries_tip_Backcolorstyle = 0;
         subGridsgusuariosseries_tip_Allowcollapsing = 0;
         subGridsgusuariosseries_tip_Allowselection = 0;
         edtUsuSerDet_Enabled = 1;
         edtTipCod_Enabled = 1;
         subGridsgusuariosseries_tip_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
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

      protected void gxnrGridsgusuariosseries_tip_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3434( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1034( ) ;
            standaloneModal1034( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1034( ) ;
            nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_3434( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridsgusuariosseries_tipContainer)) ;
         /* End function gxnrGridsgusuariosseries_tip_newrow */
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
         if ( AnyError == 0 )
         {
            GX_FocusControl = "";
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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

      public void Valid_Usucod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z348UsuCod", StringUtil.RTrim( Z348UsuCod));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Tipcod( )
      {
         /* Using cursor T001025 */
         pr_default.execute(23, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
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
         setEventMetadata("VALID_USUCOD","{handler:'Valid_Usucod',iparms:[{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_USUCOD",",oparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z348UsuCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_USUSERDET","{handler:'Valid_Ususerdet',iparms:[]");
         setEventMetadata("VALID_USUSERDET",",oparms:[]}");
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
         pr_default.close(23);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z348UsuCod = "";
         Z149TipCod = "";
         Z351UsuSerDet = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A149TipCod = "";
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
         A348UsuCod = "";
         lblTitletip_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridsgusuariosseries_tipContainer = new GXWebGrid( context);
         Gridsgusuariosseries_tipColumn = new GXWebColumn();
         A351UsuSerDet = "";
         sMode34 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T00107_A348UsuCod = new string[] {""} ;
         T00108_A348UsuCod = new string[] {""} ;
         T00106_A348UsuCod = new string[] {""} ;
         sMode32 = "";
         T00109_A348UsuCod = new string[] {""} ;
         T001010_A348UsuCod = new string[] {""} ;
         T00105_A348UsuCod = new string[] {""} ;
         T001013_A2237SGNotificacionID = new long[1] ;
         T001013_A2245SGNotificacionDetID = new short[1] ;
         T001014_A2237SGNotificacionID = new long[1] ;
         T001015_A348UsuCod = new string[] {""} ;
         T001015_A346ObjCod = new int[1] ;
         T001016_A348UsuCod = new string[] {""} ;
         T001016_A342SGMenuPrograma = new string[] {""} ;
         T001016_A343SGMenuNiv1ID = new string[] {""} ;
         T001017_A348UsuCod = new string[] {""} ;
         T001017_A349UsuAlmCod = new int[1] ;
         T001018_A348UsuCod = new string[] {""} ;
         T001019_A348UsuCod = new string[] {""} ;
         T001019_A351UsuSerDet = new string[] {""} ;
         T001019_A149TipCod = new string[] {""} ;
         T00104_A149TipCod = new string[] {""} ;
         T001020_A149TipCod = new string[] {""} ;
         T001021_A348UsuCod = new string[] {""} ;
         T001021_A149TipCod = new string[] {""} ;
         T001021_A351UsuSerDet = new string[] {""} ;
         T00103_A348UsuCod = new string[] {""} ;
         T00103_A351UsuSerDet = new string[] {""} ;
         T00103_A149TipCod = new string[] {""} ;
         T00102_A348UsuCod = new string[] {""} ;
         T00102_A351UsuSerDet = new string[] {""} ;
         T00102_A149TipCod = new string[] {""} ;
         T001024_A348UsuCod = new string[] {""} ;
         T001024_A149TipCod = new string[] {""} ;
         T001024_A351UsuSerDet = new string[] {""} ;
         Gridsgusuariosseries_tipRow = new GXWebRow();
         subGridsgusuariosseries_tip_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ348UsuCod = "";
         T001025_A149TipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.sgusuariosseries__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.sgusuariosseries__default(),
            new Object[][] {
                new Object[] {
               T00102_A348UsuCod, T00102_A351UsuSerDet, T00102_A149TipCod
               }
               , new Object[] {
               T00103_A348UsuCod, T00103_A351UsuSerDet, T00103_A149TipCod
               }
               , new Object[] {
               T00104_A149TipCod
               }
               , new Object[] {
               T00105_A348UsuCod
               }
               , new Object[] {
               T00106_A348UsuCod
               }
               , new Object[] {
               T00107_A348UsuCod
               }
               , new Object[] {
               T00108_A348UsuCod
               }
               , new Object[] {
               T00109_A348UsuCod
               }
               , new Object[] {
               T001010_A348UsuCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001013_A2237SGNotificacionID, T001013_A2245SGNotificacionDetID
               }
               , new Object[] {
               T001014_A2237SGNotificacionID
               }
               , new Object[] {
               T001015_A348UsuCod, T001015_A346ObjCod
               }
               , new Object[] {
               T001016_A348UsuCod, T001016_A342SGMenuPrograma, T001016_A343SGMenuNiv1ID
               }
               , new Object[] {
               T001017_A348UsuCod, T001017_A349UsuAlmCod
               }
               , new Object[] {
               T001018_A348UsuCod
               }
               , new Object[] {
               T001019_A348UsuCod, T001019_A351UsuSerDet, T001019_A149TipCod
               }
               , new Object[] {
               T001020_A149TipCod
               }
               , new Object[] {
               T001021_A348UsuCod, T001021_A149TipCod, T001021_A351UsuSerDet
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001024_A348UsuCod, T001024_A149TipCod, T001024_A351UsuSerDet
               }
               , new Object[] {
               T001025_A149TipCod
               }
            }
         );
      }

      private short nRcdDeleted_34 ;
      private short nRcdExists_34 ;
      private short nIsMod_34 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridsgusuariosseries_tip_Backcolorstyle ;
      private short subGridsgusuariosseries_tip_Allowselection ;
      private short subGridsgusuariosseries_tip_Allowhovering ;
      private short subGridsgusuariosseries_tip_Allowcollapsing ;
      private short subGridsgusuariosseries_tip_Collapsed ;
      private short nBlankRcdCount34 ;
      private short RcdFound34 ;
      private short nBlankRcdUsr34 ;
      private short GX_JID ;
      private short RcdFound32 ;
      private short nIsDirty_32 ;
      private short Gx_BScreen ;
      private short nIsDirty_34 ;
      private short subGridsgusuariosseries_tip_Backstyle ;
      private short gxajaxcallmode ;
      private int nRC_GXsfl_34 ;
      private int nGXsfl_34_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtUsuCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtTipCod_Enabled ;
      private int edtUsuSerDet_Enabled ;
      private int subGridsgusuariosseries_tip_Selectedindex ;
      private int subGridsgusuariosseries_tip_Selectioncolor ;
      private int subGridsgusuariosseries_tip_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridsgusuariosseries_tip_Backcolor ;
      private int subGridsgusuariosseries_tip_Allbackcolor ;
      private int defedtUsuSerDet_Enabled ;
      private int defedtTipCod_Enabled ;
      private int idxLst ;
      private long GRIDSGUSUARIOSSERIES_TIP_nFirstRecordOnPage ;
      private string sPrefix ;
      private string Z348UsuCod ;
      private string Z149TipCod ;
      private string Z351UsuSerDet ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A149TipCod ;
      private string sGXsfl_34_idx="0001" ;
      private string Gx_mode ;
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
      private string A348UsuCod ;
      private string edtUsuCod_Jsonclick ;
      private string lblTitletip_Internalname ;
      private string lblTitletip_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridsgusuariosseries_tip_Header ;
      private string A351UsuSerDet ;
      private string sMode34 ;
      private string edtTipCod_Internalname ;
      private string edtUsuSerDet_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode32 ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string subGridsgusuariosseries_tip_Class ;
      private string subGridsgusuariosseries_tip_Linesclass ;
      private string ROClassString ;
      private string edtTipCod_Jsonclick ;
      private string edtUsuSerDet_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridsgusuariosseries_tip_Internalname ;
      private string ZZ348UsuCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_34_Refreshing=false ;
      private GXWebGrid Gridsgusuariosseries_tipContainer ;
      private GXWebRow Gridsgusuariosseries_tipRow ;
      private GXWebColumn Gridsgusuariosseries_tipColumn ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00107_A348UsuCod ;
      private string[] T00108_A348UsuCod ;
      private string[] T00106_A348UsuCod ;
      private string[] T00109_A348UsuCod ;
      private string[] T001010_A348UsuCod ;
      private string[] T00105_A348UsuCod ;
      private long[] T001013_A2237SGNotificacionID ;
      private short[] T001013_A2245SGNotificacionDetID ;
      private long[] T001014_A2237SGNotificacionID ;
      private string[] T001015_A348UsuCod ;
      private int[] T001015_A346ObjCod ;
      private string[] T001016_A348UsuCod ;
      private string[] T001016_A342SGMenuPrograma ;
      private string[] T001016_A343SGMenuNiv1ID ;
      private string[] T001017_A348UsuCod ;
      private int[] T001017_A349UsuAlmCod ;
      private string[] T001018_A348UsuCod ;
      private string[] T001019_A348UsuCod ;
      private string[] T001019_A351UsuSerDet ;
      private string[] T001019_A149TipCod ;
      private string[] T00104_A149TipCod ;
      private string[] T001020_A149TipCod ;
      private string[] T001021_A348UsuCod ;
      private string[] T001021_A149TipCod ;
      private string[] T001021_A351UsuSerDet ;
      private string[] T00103_A348UsuCod ;
      private string[] T00103_A351UsuSerDet ;
      private string[] T00103_A149TipCod ;
      private string[] T00102_A348UsuCod ;
      private string[] T00102_A351UsuSerDet ;
      private string[] T00102_A149TipCod ;
      private string[] T001024_A348UsuCod ;
      private string[] T001024_A149TipCod ;
      private string[] T001024_A351UsuSerDet ;
      private string[] T001025_A149TipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class sgusuariosseries__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class sgusuariosseries__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00107;
        prmT00107 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT00108;
        prmT00108 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT00106;
        prmT00106 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT00109;
        prmT00109 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001010;
        prmT001010 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT00105;
        prmT00105 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001011;
        prmT001011 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001012;
        prmT001012 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001013;
        prmT001013 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001014;
        prmT001014 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001015;
        prmT001015 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001016;
        prmT001016 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001017;
        prmT001017 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001018;
        prmT001018 = new Object[] {
        };
        Object[] prmT001019;
        prmT001019 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT00104;
        prmT00104 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT001020;
        prmT001020 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT001021;
        prmT001021 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT00103;
        prmT00103 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT00102;
        prmT00102 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT001022;
        prmT001022 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT001023;
        prmT001023 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@UsuSerDet",GXType.NChar,4,0)
        };
        Object[] prmT001024;
        prmT001024 = new Object[] {
        new ParDef("@UsuCod",GXType.NChar,10,0)
        };
        Object[] prmT001025;
        prmT001025 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00102", "SELECT [UsuCod], [UsuSerDet], [TipCod] FROM [SGUSUARIOSSERIES] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet ",true, GxErrorMask.GX_NOMASK, false, this,prmT00102,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00103", "SELECT [UsuCod], [UsuSerDet], [TipCod] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet ",true, GxErrorMask.GX_NOMASK, false, this,prmT00103,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00104", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00104,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00105", "SELECT [UsuCod] FROM [SGUSUARIOS] WITH (UPDLOCK) WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00105,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00106", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00106,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00107", "SELECT TM1.[UsuCod] FROM [SGUSUARIOS] TM1 WHERE TM1.[UsuCod] = @UsuCod ORDER BY TM1.[UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00107,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00108", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @UsuCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00108,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00109", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] > @UsuCod) ORDER BY [UsuCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00109,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001010", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE ( [UsuCod] < @UsuCod) ORDER BY [UsuCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001010,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001011", "INSERT INTO [SGUSUARIOS]([UsuCod], [UsuNom], [UsuPedPrecio], [UsuPedDscto], [UsuPedStock], [UsuPedVend], [UsuPedCond], [UsuPedList], [UsuPedMon], [UsuMosBanCod], [UsuMosCBCod], [UsuMosConcepto], [UsuPas], [UsuSerie], [UsuAutOcom], [UsuAutPago], [UsuSts], [UsuSerie1], [UsuSerie2], [UsuSerie3], [UsuSerie4], [UsuVend], [UsuSerie5], [UsuReqADM], [UsuTieCod], [UsuAut1], [UsuAut2], [UsuOcMail], [UsuEMAIL], [UsuPedMail], [UsuSOrden], [AreCod], [UsuSRet], [UsuDep], [UsuVendAut]) VALUES(@UsuCod, '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', '', convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), '', convert(int, 0), '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT001011)
           ,new CursorDef("T001012", "DELETE FROM [SGUSUARIOS]  WHERE [UsuCod] = @UsuCod", GxErrorMask.GX_NOMASK,prmT001012)
           ,new CursorDef("T001013", "SELECT TOP 1 [SGNotificacionID], [SGNotificacionDetID] FROM [SGNOTIFICACIONESDET] WHERE [SGNotificacionDetUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001013,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001014", "SELECT TOP 1 [SGNotificacionID] FROM [SGNOTIFICACIONES] WHERE [SGNotificacionUsuario] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001014,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001015", "SELECT TOP 1 [UsuCod], [ObjCod] FROM [SGUSUARIOSDET] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001015,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001016", "SELECT TOP 1 [UsuCod], [SGMenuPrograma], [SGMenuNiv1ID] FROM [SGUSUARIONIV1] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001017", "SELECT TOP 1 [UsuCod], [UsuAlmCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @UsuCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001018", "SELECT [UsuCod] FROM [SGUSUARIOS] ORDER BY [UsuCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001018,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001019", "SELECT [UsuCod], [UsuSerDet], [TipCod] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod and [TipCod] = @TipCod and [UsuSerDet] = @UsuSerDet ORDER BY [UsuCod], [TipCod], [UsuSerDet] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001019,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001020", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001020,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001021", "SELECT [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet ",true, GxErrorMask.GX_NOMASK, false, this,prmT001021,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001022", "INSERT INTO [SGUSUARIOSSERIES]([UsuCod], [UsuSerDet], [TipCod]) VALUES(@UsuCod, @UsuSerDet, @TipCod)", GxErrorMask.GX_NOMASK,prmT001022)
           ,new CursorDef("T001023", "DELETE FROM [SGUSUARIOSSERIES]  WHERE [UsuCod] = @UsuCod AND [TipCod] = @TipCod AND [UsuSerDet] = @UsuSerDet", GxErrorMask.GX_NOMASK,prmT001023)
           ,new CursorDef("T001024", "SELECT [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [UsuCod] = @UsuCod ORDER BY [UsuCod], [TipCod], [UsuSerDet] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001024,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001025", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001025,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
