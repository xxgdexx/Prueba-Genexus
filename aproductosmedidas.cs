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
   public class aproductosmedidas : GXHttpHandler
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
            A58ProdMedUniCod = (int)(NumberUtil.Val( GetPar( "ProdMedUniCod"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A58ProdMedUniCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridaproductosmedidas_level1item") == 0 )
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
            gxnrGridaproductosmedidas_level1item_newrow( ) ;
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
            Form.Meta.addItem("description", "Productos Unidades de Medida", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aproductosmedidas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aproductosmedidas( IGxContext context )
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
            RenderHtmlCloseForm1D44( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Container FormContainer", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Productos Unidades de Medida", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOSMEDIDAS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_APRODUCTOSMEDIDAS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdCod_Internalname, "Codigo Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlelevel1_Internalname, "Level1", "", "", lblTitlelevel1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridaproductosmedidas_level1item( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSMEDIDAS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridaproductosmedidas_level1item( )
      {
         /*  Grid Control  */
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("GridName", "Gridaproductosmedidas_level1item");
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Header", subGridaproductosmedidas_level1item_Header);
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Class", "Grid");
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Backcolorstyle), 1, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("CmpContext", "");
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("InMasterPage", "false");
         Gridaproductosmedidas_level1itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridaproductosmedidas_level1itemColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A58ProdMedUniCod), 6, 0, ".", "")));
         Gridaproductosmedidas_level1itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniCod_Enabled), 5, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddColumnProperties(Gridaproductosmedidas_level1itemColumn);
         Gridaproductosmedidas_level1itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridaproductosmedidas_level1itemColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1700ProdMedValor, 20, 6, ".", "")));
         Gridaproductosmedidas_level1itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedValor_Enabled), 5, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddColumnProperties(Gridaproductosmedidas_level1itemColumn);
         Gridaproductosmedidas_level1itemColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridaproductosmedidas_level1itemColumn.AddObjectProperty("Value", StringUtil.RTrim( A1699ProdMedUniDsc));
         Gridaproductosmedidas_level1itemColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniDsc_Enabled), 5, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddColumnProperties(Gridaproductosmedidas_level1itemColumn);
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Selectedindex), 4, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Allowselection), 1, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Selectioncolor), 9, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Allowhovering), 1, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Hoveringcolor), 9, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Allowcollapsing), 1, 0, ".", "")));
         Gridaproductosmedidas_level1itemContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridaproductosmedidas_level1item_Collapsed), 1, 0, ".", "")));
         nGXsfl_34_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount47 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_47 = 1;
               ScanStart1D47( ) ;
               while ( RcdFound47 != 0 )
               {
                  init_level_properties47( ) ;
                  getByPrimaryKey1D47( ) ;
                  AddRow1D47( ) ;
                  ScanNext1D47( ) ;
               }
               ScanEnd1D47( ) ;
               nBlankRcdCount47 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1D47( ) ;
            standaloneModal1D47( ) ;
            sMode47 = Gx_mode;
            while ( nGXsfl_34_idx < nRC_GXsfl_34 )
            {
               bGXsfl_34_Refreshing = true;
               ReadRow1D47( ) ;
               edtProdMedUniCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODMEDUNICOD_"+sGXsfl_34_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdMedUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedUniCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               edtProdMedValor_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODMEDVALOR_"+sGXsfl_34_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdMedValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedValor_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               edtProdMedUniDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODMEDUNIDSC_"+sGXsfl_34_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdMedUniDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedUniDsc_Enabled), 5, 0), !bGXsfl_34_Refreshing);
               if ( ( nRcdExists_47 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1D47( ) ;
               }
               SendRow1D47( ) ;
               bGXsfl_34_Refreshing = false;
            }
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount47 = 5;
            nRcdExists_47 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1D47( ) ;
               while ( RcdFound47 != 0 )
               {
                  sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3447( ) ;
                  init_level_properties47( ) ;
                  standaloneNotModal1D47( ) ;
                  getByPrimaryKey1D47( ) ;
                  standaloneModal1D47( ) ;
                  AddRow1D47( ) ;
                  ScanNext1D47( ) ;
               }
               ScanEnd1D47( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode47 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx+1), 4, 0), 4, "0");
         SubsflControlProps_3447( ) ;
         InitAll1D47( ) ;
         init_level_properties47( ) ;
         nRcdExists_47 = 0;
         nIsMod_47 = 0;
         nRcdDeleted_47 = 0;
         nBlankRcdCount47 = (short)(nBlankRcdUsr47+nBlankRcdCount47);
         fRowAdded = 0;
         while ( nBlankRcdCount47 > 0 )
         {
            standaloneNotModal1D47( ) ;
            standaloneModal1D47( ) ;
            AddRow1D47( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtProdMedUniCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount47 = (short)(nBlankRcdCount47-1);
         }
         Gx_mode = sMode47;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridaproductosmedidas_level1itemContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridaproductosmedidas_level1item", Gridaproductosmedidas_level1itemContainer);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridaproductosmedidas_level1itemContainerData", Gridaproductosmedidas_level1itemContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridaproductosmedidas_level1itemContainerData"+"V", Gridaproductosmedidas_level1itemContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridaproductosmedidas_level1itemContainerData"+"V"+"\" value='"+Gridaproductosmedidas_level1itemContainer.GridValuesHidden()+"'/>") ;
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
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "Z906ProdAfecICBPER"), ".", ","));
            Z907ProdValICBPER = context.localUtil.CToN( cgiGet( "Z907ProdValICBPER"), ".", ",");
            Z908ProdValICBPERD = context.localUtil.CToN( cgiGet( "Z908ProdValICBPERD"), ".", ",");
            A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "Z906ProdAfecICBPER"), ".", ","));
            A907ProdValICBPER = context.localUtil.CToN( cgiGet( "Z907ProdValICBPER"), ".", ",");
            A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "Z908ProdValICBPERD"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_34 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_34"), ".", ","));
            A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "PRODAFECICBPER"), ".", ","));
            A907ProdValICBPER = context.localUtil.CToN( cgiGet( "PRODVALICBPER"), ".", ",");
            A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "PRODVALICBPERD"), ".", ",");
            /* Read variables values. */
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"APRODUCTOSMEDIDAS");
            forbiddenHiddens.Add("ProdAfecICBPER", context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9"));
            forbiddenHiddens.Add("ProdValICBPER", context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99"));
            forbiddenHiddens.Add("ProdValICBPERD", context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("aproductosmedidas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               AnyError = 1;
               return  ;
            }
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
               A28ProdCod = GetPar( "ProdCod");
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
               InitAll1D44( ) ;
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
         DisableAttributes1D44( ) ;
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

      protected void CONFIRM_1D47( )
      {
         nGXsfl_34_idx = 0;
         while ( nGXsfl_34_idx < nRC_GXsfl_34 )
         {
            ReadRow1D47( ) ;
            if ( ( nRcdExists_47 != 0 ) || ( nIsMod_47 != 0 ) )
            {
               GetKey1D47( ) ;
               if ( ( nRcdExists_47 == 0 ) && ( nRcdDeleted_47 == 0 ) )
               {
                  if ( RcdFound47 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1D47( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1D47( ) ;
                        CloseExtendedTableCursors1D47( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODMEDUNICOD_" + sGXsfl_34_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProdMedUniCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound47 != 0 )
                  {
                     if ( nRcdDeleted_47 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1D47( ) ;
                        Load1D47( ) ;
                        BeforeValidate1D47( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1D47( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1D47( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1D47( ) ;
                              CloseExtendedTableCursors1D47( ) ;
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
                     if ( nRcdDeleted_47 == 0 )
                     {
                        GXCCtl = "PRODMEDUNICOD_" + sGXsfl_34_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdMedUniCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProdMedUniCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A58ProdMedUniCod), 6, 0, ".", ""))) ;
            ChangePostValue( edtProdMedValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A1700ProdMedValor, 20, 6, ".", ""))) ;
            ChangePostValue( edtProdMedUniDsc_Internalname, StringUtil.RTrim( A1699ProdMedUniDsc)) ;
            ChangePostValue( "ZT_"+"Z58ProdMedUniCod_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z58ProdMedUniCod), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1700ProdMedValor_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( Z1700ProdMedValor, 18, 6, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_47_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_47_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_47_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, ".", ""))) ;
            if ( nIsMod_47 != 0 )
            {
               ChangePostValue( "PRODMEDUNICOD_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODMEDVALOR_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODMEDUNIDSC_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1D0( )
      {
      }

      protected void ZM1D44( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z906ProdAfecICBPER = T001D6_A906ProdAfecICBPER[0];
               Z907ProdValICBPER = T001D6_A907ProdValICBPER[0];
               Z908ProdValICBPERD = T001D6_A908ProdValICBPERD[0];
            }
            else
            {
               Z906ProdAfecICBPER = A906ProdAfecICBPER;
               Z907ProdValICBPER = A907ProdValICBPER;
               Z908ProdValICBPERD = A908ProdValICBPERD;
            }
         }
         if ( GX_JID == -1 )
         {
            Z28ProdCod = A28ProdCod;
            Z906ProdAfecICBPER = A906ProdAfecICBPER;
            Z907ProdValICBPER = A907ProdValICBPER;
            Z908ProdValICBPERD = A908ProdValICBPERD;
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

      protected void Load1D44( )
      {
         /* Using cursor T001D7 */
         pr_default.execute(5, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound44 = 1;
            A906ProdAfecICBPER = T001D7_A906ProdAfecICBPER[0];
            A907ProdValICBPER = T001D7_A907ProdValICBPER[0];
            A908ProdValICBPERD = T001D7_A908ProdValICBPERD[0];
            ZM1D44( -1) ;
         }
         pr_default.close(5);
         OnLoadActions1D44( ) ;
      }

      protected void OnLoadActions1D44( )
      {
      }

      protected void CheckExtendedTable1D44( )
      {
         nIsDirty_44 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1D44( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1D44( )
      {
         /* Using cursor T001D8 */
         pr_default.execute(6, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001D6 */
         pr_default.execute(4, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1D44( 1) ;
            RcdFound44 = 1;
            A28ProdCod = T001D6_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A906ProdAfecICBPER = T001D6_A906ProdAfecICBPER[0];
            A907ProdValICBPER = T001D6_A907ProdValICBPER[0];
            A908ProdValICBPERD = T001D6_A908ProdValICBPERD[0];
            Z28ProdCod = A28ProdCod;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1D44( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1D44( ) ;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1D44( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey1D44( ) ;
         if ( RcdFound44 == 0 )
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
         RcdFound44 = 0;
         /* Using cursor T001D9 */
         pr_default.execute(7, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T001D9_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T001D9_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               A28ProdCod = T001D9_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound44 = 0;
         /* Using cursor T001D10 */
         pr_default.execute(8, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001D10_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001D10_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               A28ProdCod = T001D10_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1D44( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1D44( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
               {
                  A28ProdCod = Z28ProdCod;
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1D44( ) ;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1D44( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1D44( ) ;
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
         if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
         {
            A28ProdCod = Z28ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProdCod_Internalname;
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
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
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
         ScanStart1D44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1D44( ) ;
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
         if ( RcdFound44 == 0 )
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
         if ( RcdFound44 == 0 )
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
         ScanStart1D44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound44 != 0 )
            {
               ScanNext1D44( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1D44( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1D44( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001D5 */
            pr_default.execute(3, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z906ProdAfecICBPER != T001D5_A906ProdAfecICBPER[0] ) || ( Z907ProdValICBPER != T001D5_A907ProdValICBPER[0] ) || ( Z908ProdValICBPERD != T001D5_A908ProdValICBPERD[0] ) )
            {
               if ( Z906ProdAfecICBPER != T001D5_A906ProdAfecICBPER[0] )
               {
                  GXUtil.WriteLog("aproductosmedidas:[seudo value changed for attri]"+"ProdAfecICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z906ProdAfecICBPER);
                  GXUtil.WriteLogRaw("Current: ",T001D5_A906ProdAfecICBPER[0]);
               }
               if ( Z907ProdValICBPER != T001D5_A907ProdValICBPER[0] )
               {
                  GXUtil.WriteLog("aproductosmedidas:[seudo value changed for attri]"+"ProdValICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z907ProdValICBPER);
                  GXUtil.WriteLogRaw("Current: ",T001D5_A907ProdValICBPER[0]);
               }
               if ( Z908ProdValICBPERD != T001D5_A908ProdValICBPERD[0] )
               {
                  GXUtil.WriteLog("aproductosmedidas:[seudo value changed for attri]"+"ProdValICBPERD");
                  GXUtil.WriteLogRaw("Old: ",Z908ProdValICBPERD);
                  GXUtil.WriteLogRaw("Current: ",T001D5_A908ProdValICBPERD[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"APRODUCTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D44( )
      {
         BeforeValidate1D44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D44( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D44( 0) ;
            CheckOptimisticConcurrency1D44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D11 */
                     pr_default.execute(9, new Object[] {A28ProdCod, A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
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
                           ProcessLevel1D44( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1D0( ) ;
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
               Load1D44( ) ;
            }
            EndLevel1D44( ) ;
         }
         CloseExtendedTableCursors1D44( ) ;
      }

      protected void Update1D44( )
      {
         BeforeValidate1D44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D44( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1D44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D12 */
                     pr_default.execute(10, new Object[] {A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD, A28ProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1D44( ) ;
                     if ( AnyError == 0 )
                     {
                        new aproductosupdateredundancy(context ).execute( ref  A28ProdCod) ;
                        AssignAttri("", false, "A28ProdCod", A28ProdCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1D44( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1D0( ) ;
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
            EndLevel1D44( ) ;
         }
         CloseExtendedTableCursors1D44( ) ;
      }

      protected void DeferredUpdate1D44( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1D44( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D44( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D44( ) ;
            AfterConfirm1D44( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D44( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1D47( ) ;
                  while ( RcdFound47 != 0 )
                  {
                     getByPrimaryKey1D47( ) ;
                     Delete1D47( ) ;
                     ScanNext1D47( ) ;
                  }
                  ScanEnd1D47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D13 */
                     pr_default.execute(11, new Object[] {A28ProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound44 == 0 )
                           {
                              InitAll1D44( ) ;
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
                           ResetCaption1D0( ) ;
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1D44( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1D44( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001D14 */
            pr_default.execute(12, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Materias Primas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001D15 */
            pr_default.execute(13, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Gastos de Fabricación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001D16 */
            pr_default.execute(14, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POSERVICIODET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001D17 */
            pr_default.execute(15, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Orden de Servicio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001D18 */
            pr_default.execute(16, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Plan de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T001D19 */
            pr_default.execute(17, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001D20 */
            pr_default.execute(18, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T001D21 */
            pr_default.execute(19, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZADET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T001D22 */
            pr_default.execute(20, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T001D23 */
            pr_default.execute(21, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sabana de Compras "}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T001D24 */
            pr_default.execute(22, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T001D25 */
            pr_default.execute(23, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T001D26 */
            pr_default.execute(24, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T001D27 */
            pr_default.execute(25, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T001D28 */
            pr_default.execute(26, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Detalle Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T001D29 */
            pr_default.execute(27, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Sub Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T001D30 */
            pr_default.execute(28, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldo Mensual de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T001D31 */
            pr_default.execute(29, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Descuentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T001D32 */
            pr_default.execute(30, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Orden de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T001D33 */
            pr_default.execute(31, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ventas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T001D34 */
            pr_default.execute(32, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T001D35 */
            pr_default.execute(33, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T001D36 */
            pr_default.execute(34, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T001D37 */
            pr_default.execute(35, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T001D38 */
            pr_default.execute(36, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov Almacen Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T001D39 */
            pr_default.execute(37, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLPEDIDOSDETLOTE"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T001D40 */
            pr_default.execute(38, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Stock Actual"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T001D41 */
            pr_default.execute(39, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Formula de Productos"+" ("+"Producto en Formula"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T001D42 */
            pr_default.execute(40, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Formula de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T001D43 */
            pr_default.execute(41, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"+" ("+"Productos Equivalentes"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T001D44 */
            pr_default.execute(42, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T001D45 */
            pr_default.execute(43, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seguimiento de Consignacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
         }
      }

      protected void ProcessNestedLevel1D47( )
      {
         nGXsfl_34_idx = 0;
         while ( nGXsfl_34_idx < nRC_GXsfl_34 )
         {
            ReadRow1D47( ) ;
            if ( ( nRcdExists_47 != 0 ) || ( nIsMod_47 != 0 ) )
            {
               standaloneNotModal1D47( ) ;
               GetKey1D47( ) ;
               if ( ( nRcdExists_47 == 0 ) && ( nRcdDeleted_47 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1D47( ) ;
               }
               else
               {
                  if ( RcdFound47 != 0 )
                  {
                     if ( ( nRcdDeleted_47 != 0 ) && ( nRcdExists_47 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1D47( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_47 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1D47( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_47 == 0 )
                     {
                        GXCCtl = "PRODMEDUNICOD_" + sGXsfl_34_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdMedUniCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProdMedUniCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A58ProdMedUniCod), 6, 0, ".", ""))) ;
            ChangePostValue( edtProdMedValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A1700ProdMedValor, 20, 6, ".", ""))) ;
            ChangePostValue( edtProdMedUniDsc_Internalname, StringUtil.RTrim( A1699ProdMedUniDsc)) ;
            ChangePostValue( "ZT_"+"Z58ProdMedUniCod_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z58ProdMedUniCod), 6, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1700ProdMedValor_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( Z1700ProdMedValor, 18, 6, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_47_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_47_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_47_"+sGXsfl_34_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, ".", ""))) ;
            if ( nIsMod_47 != 0 )
            {
               ChangePostValue( "PRODMEDUNICOD_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODMEDVALOR_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedValor_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODMEDUNIDSC_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniDsc_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1D47( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_47 = 0;
         nIsMod_47 = 0;
         nRcdDeleted_47 = 0;
      }

      protected void ProcessLevel1D44( )
      {
         /* Save parent mode. */
         sMode44 = Gx_mode;
         ProcessNestedLevel1D47( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1D44( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1D44( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("aproductosmedidas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1D0( ) ;
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
            context.RollbackDataStores("aproductosmedidas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1D44( )
      {
         /* Using cursor T001D46 */
         pr_default.execute(44);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T001D46_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1D44( )
      {
         /* Scan next routine */
         pr_default.readNext(44);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T001D46_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
      }

      protected void ScanEnd1D44( )
      {
         pr_default.close(44);
      }

      protected void AfterConfirm1D44( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D44( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D44( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1D44( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D44( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D44( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D44( )
      {
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
      }

      protected void ZM1D47( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1700ProdMedValor = T001D3_A1700ProdMedValor[0];
            }
            else
            {
               Z1700ProdMedValor = A1700ProdMedValor;
            }
         }
         if ( GX_JID == -2 )
         {
            Z28ProdCod = A28ProdCod;
            Z1700ProdMedValor = A1700ProdMedValor;
            Z58ProdMedUniCod = A58ProdMedUniCod;
            Z1699ProdMedUniDsc = A1699ProdMedUniDsc;
         }
      }

      protected void standaloneNotModal1D47( )
      {
      }

      protected void standaloneModal1D47( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProdMedUniCod_Enabled = 0;
            AssignProp("", false, edtProdMedUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedUniCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         }
         else
         {
            edtProdMedUniCod_Enabled = 1;
            AssignProp("", false, edtProdMedUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedUniCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         }
      }

      protected void Load1D47( )
      {
         /* Using cursor T001D47 */
         pr_default.execute(45, new Object[] {A28ProdCod, A58ProdMedUniCod});
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound47 = 1;
            A1700ProdMedValor = T001D47_A1700ProdMedValor[0];
            A1699ProdMedUniDsc = T001D47_A1699ProdMedUniDsc[0];
            ZM1D47( -2) ;
         }
         pr_default.close(45);
         OnLoadActions1D47( ) ;
      }

      protected void OnLoadActions1D47( )
      {
      }

      protected void CheckExtendedTable1D47( )
      {
         nIsDirty_47 = 0;
         Gx_BScreen = 1;
         standaloneModal1D47( ) ;
         /* Using cursor T001D4 */
         pr_default.execute(2, new Object[] {A58ProdMedUniCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODMEDUNICOD_" + sGXsfl_34_idx;
            GX_msglist.addItem("No existe 'Productos Unidades'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdMedUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1699ProdMedUniDsc = T001D4_A1699ProdMedUniDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1D47( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1D47( )
      {
      }

      protected void gxLoad_3( int A58ProdMedUniCod )
      {
         /* Using cursor T001D48 */
         pr_default.execute(46, new Object[] {A58ProdMedUniCod});
         if ( (pr_default.getStatus(46) == 101) )
         {
            GXCCtl = "PRODMEDUNICOD_" + sGXsfl_34_idx;
            GX_msglist.addItem("No existe 'Productos Unidades'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdMedUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1699ProdMedUniDsc = T001D48_A1699ProdMedUniDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1699ProdMedUniDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(46) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(46);
      }

      protected void GetKey1D47( )
      {
         /* Using cursor T001D49 */
         pr_default.execute(47, new Object[] {A28ProdCod, A58ProdMedUniCod});
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound47 = 1;
         }
         else
         {
            RcdFound47 = 0;
         }
         pr_default.close(47);
      }

      protected void getByPrimaryKey1D47( )
      {
         /* Using cursor T001D3 */
         pr_default.execute(1, new Object[] {A28ProdCod, A58ProdMedUniCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1D47( 2) ;
            RcdFound47 = 1;
            InitializeNonKey1D47( ) ;
            A1700ProdMedValor = T001D3_A1700ProdMedValor[0];
            A58ProdMedUniCod = T001D3_A58ProdMedUniCod[0];
            Z28ProdCod = A28ProdCod;
            Z58ProdMedUniCod = A58ProdMedUniCod;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1D47( ) ;
            Load1D47( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound47 = 0;
            InitializeNonKey1D47( ) ;
            sMode47 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1D47( ) ;
            Gx_mode = sMode47;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1D47( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1D47( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001D2 */
            pr_default.execute(0, new Object[] {A28ProdCod, A58ProdMedUniCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOSMEDIDAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1700ProdMedValor != T001D2_A1700ProdMedValor[0] ) )
            {
               if ( Z1700ProdMedValor != T001D2_A1700ProdMedValor[0] )
               {
                  GXUtil.WriteLog("aproductosmedidas:[seudo value changed for attri]"+"ProdMedValor");
                  GXUtil.WriteLogRaw("Old: ",Z1700ProdMedValor);
                  GXUtil.WriteLogRaw("Current: ",T001D2_A1700ProdMedValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"APRODUCTOSMEDIDAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1D47( )
      {
         BeforeValidate1D47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D47( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1D47( 0) ;
            CheckOptimisticConcurrency1D47( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1D47( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1D47( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001D50 */
                     pr_default.execute(48, new Object[] {A28ProdCod, A1700ProdMedValor, A58ProdMedUniCod});
                     pr_default.close(48);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOSMEDIDAS");
                     if ( (pr_default.getStatus(48) == 1) )
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
               Load1D47( ) ;
            }
            EndLevel1D47( ) ;
         }
         CloseExtendedTableCursors1D47( ) ;
      }

      protected void Update1D47( )
      {
         BeforeValidate1D47( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1D47( ) ;
         }
         if ( ( nIsMod_47 != 0 ) || ( nIsDirty_47 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1D47( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1D47( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1D47( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001D51 */
                        pr_default.execute(49, new Object[] {A1700ProdMedValor, A28ProdCod, A58ProdMedUniCod});
                        pr_default.close(49);
                        dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOSMEDIDAS");
                        if ( (pr_default.getStatus(49) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOSMEDIDAS"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1D47( ) ;
                        if ( AnyError == 0 )
                        {
                           new aproductosupdateredundancy(context ).execute( ref  A28ProdCod) ;
                           AssignAttri("", false, "A28ProdCod", A28ProdCod);
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1D47( ) ;
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
               EndLevel1D47( ) ;
            }
         }
         CloseExtendedTableCursors1D47( ) ;
      }

      protected void DeferredUpdate1D47( )
      {
      }

      protected void Delete1D47( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1D47( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1D47( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1D47( ) ;
            AfterConfirm1D47( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1D47( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001D52 */
                  pr_default.execute(50, new Object[] {A28ProdCod, A58ProdMedUniCod});
                  pr_default.close(50);
                  dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOSMEDIDAS");
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
         sMode47 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1D47( ) ;
         Gx_mode = sMode47;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1D47( )
      {
         standaloneModal1D47( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001D53 */
            pr_default.execute(51, new Object[] {A58ProdMedUniCod});
            A1699ProdMedUniDsc = T001D53_A1699ProdMedUniDsc[0];
            pr_default.close(51);
         }
      }

      protected void EndLevel1D47( )
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

      public void ScanStart1D47( )
      {
         /* Scan By routine */
         /* Using cursor T001D54 */
         pr_default.execute(52, new Object[] {A28ProdCod});
         RcdFound47 = 0;
         if ( (pr_default.getStatus(52) != 101) )
         {
            RcdFound47 = 1;
            A58ProdMedUniCod = T001D54_A58ProdMedUniCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1D47( )
      {
         /* Scan next routine */
         pr_default.readNext(52);
         RcdFound47 = 0;
         if ( (pr_default.getStatus(52) != 101) )
         {
            RcdFound47 = 1;
            A58ProdMedUniCod = T001D54_A58ProdMedUniCod[0];
         }
      }

      protected void ScanEnd1D47( )
      {
         pr_default.close(52);
      }

      protected void AfterConfirm1D47( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1D47( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1D47( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1D47( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1D47( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1D47( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1D47( )
      {
         edtProdMedUniCod_Enabled = 0;
         AssignProp("", false, edtProdMedUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedUniCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         edtProdMedValor_Enabled = 0;
         AssignProp("", false, edtProdMedValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedValor_Enabled), 5, 0), !bGXsfl_34_Refreshing);
         edtProdMedUniDsc_Enabled = 0;
         AssignProp("", false, edtProdMedUniDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedUniDsc_Enabled), 5, 0), !bGXsfl_34_Refreshing);
      }

      protected void send_integrity_lvl_hashes1D47( )
      {
      }

      protected void send_integrity_lvl_hashes1D44( )
      {
      }

      protected void SubsflControlProps_3447( )
      {
         edtProdMedUniCod_Internalname = "PRODMEDUNICOD_"+sGXsfl_34_idx;
         edtProdMedValor_Internalname = "PRODMEDVALOR_"+sGXsfl_34_idx;
         edtProdMedUniDsc_Internalname = "PRODMEDUNIDSC_"+sGXsfl_34_idx;
      }

      protected void SubsflControlProps_fel_3447( )
      {
         edtProdMedUniCod_Internalname = "PRODMEDUNICOD_"+sGXsfl_34_fel_idx;
         edtProdMedValor_Internalname = "PRODMEDVALOR_"+sGXsfl_34_fel_idx;
         edtProdMedUniDsc_Internalname = "PRODMEDUNIDSC_"+sGXsfl_34_fel_idx;
      }

      protected void AddRow1D47( )
      {
         nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_3447( ) ;
         SendRow1D47( ) ;
      }

      protected void SendRow1D47( )
      {
         Gridaproductosmedidas_level1itemRow = GXWebRow.GetNew(context);
         if ( subGridaproductosmedidas_level1item_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridaproductosmedidas_level1item_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridaproductosmedidas_level1item_Class, "") != 0 )
            {
               subGridaproductosmedidas_level1item_Linesclass = subGridaproductosmedidas_level1item_Class+"Odd";
            }
         }
         else if ( subGridaproductosmedidas_level1item_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridaproductosmedidas_level1item_Backstyle = 0;
            subGridaproductosmedidas_level1item_Backcolor = subGridaproductosmedidas_level1item_Allbackcolor;
            if ( StringUtil.StrCmp(subGridaproductosmedidas_level1item_Class, "") != 0 )
            {
               subGridaproductosmedidas_level1item_Linesclass = subGridaproductosmedidas_level1item_Class+"Uniform";
            }
         }
         else if ( subGridaproductosmedidas_level1item_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridaproductosmedidas_level1item_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridaproductosmedidas_level1item_Class, "") != 0 )
            {
               subGridaproductosmedidas_level1item_Linesclass = subGridaproductosmedidas_level1item_Class+"Odd";
            }
            subGridaproductosmedidas_level1item_Backcolor = (int)(0x0);
         }
         else if ( subGridaproductosmedidas_level1item_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridaproductosmedidas_level1item_Backstyle = 1;
            if ( ((int)((nGXsfl_34_idx) % (2))) == 0 )
            {
               subGridaproductosmedidas_level1item_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridaproductosmedidas_level1item_Class, "") != 0 )
               {
                  subGridaproductosmedidas_level1item_Linesclass = subGridaproductosmedidas_level1item_Class+"Even";
               }
            }
            else
            {
               subGridaproductosmedidas_level1item_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridaproductosmedidas_level1item_Class, "") != 0 )
               {
                  subGridaproductosmedidas_level1item_Linesclass = subGridaproductosmedidas_level1item_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_47_" + sGXsfl_34_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_34_idx + "',34)\"";
         ROClassString = "Attribute";
         Gridaproductosmedidas_level1itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdMedUniCod_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A58ProdMedUniCod), 6, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A58ProdMedUniCod), "ZZZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdMedUniCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdMedUniCod_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)6,(short)0,(short)0,(short)34,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_47_" + sGXsfl_34_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_34_idx + "',34)\"";
         ROClassString = "Attribute";
         Gridaproductosmedidas_level1itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdMedValor_Internalname,StringUtil.LTrim( StringUtil.NToC( A1700ProdMedValor, 20, 6, ".", "")),StringUtil.LTrim( ((edtProdMedValor_Enabled!=0) ? context.localUtil.Format( A1700ProdMedValor, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A1700ProdMedValor, "ZZZZZ,ZZZ,ZZ9.999999"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,36);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdMedValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdMedValor_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)34,(short)1,(short)-1,(short)0,(bool)true,(string)"Precio6",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridaproductosmedidas_level1itemRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdMedUniDsc_Internalname,StringUtil.RTrim( A1699ProdMedUniDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdMedUniDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdMedUniDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)34,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridaproductosmedidas_level1itemRow);
         send_integrity_lvl_hashes1D47( ) ;
         GXCCtl = "Z58ProdMedUniCod_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z58ProdMedUniCod), 6, 0, ".", "")));
         GXCCtl = "Z1700ProdMedValor_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z1700ProdMedValor, 18, 6, ".", "")));
         GXCCtl = "nRcdDeleted_47_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_47), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_47_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_47), 4, 0, ".", "")));
         GXCCtl = "nIsMod_47_" + sGXsfl_34_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_47), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODMEDUNICOD_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODMEDVALOR_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedValor_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODMEDUNIDSC_"+sGXsfl_34_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdMedUniDsc_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridaproductosmedidas_level1itemContainer.AddRow(Gridaproductosmedidas_level1itemRow);
      }

      protected void ReadRow1D47( )
      {
         nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_3447( ) ;
         edtProdMedUniCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODMEDUNICOD_"+sGXsfl_34_idx+"Enabled"), ".", ","));
         edtProdMedValor_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODMEDVALOR_"+sGXsfl_34_idx+"Enabled"), ".", ","));
         edtProdMedUniDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODMEDUNIDSC_"+sGXsfl_34_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtProdMedUniCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdMedUniCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
         {
            GXCCtl = "PRODMEDUNICOD_" + sGXsfl_34_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdMedUniCod_Internalname;
            wbErr = true;
            A58ProdMedUniCod = 0;
         }
         else
         {
            A58ProdMedUniCod = (int)(context.localUtil.CToN( cgiGet( edtProdMedUniCod_Internalname), ".", ","));
         }
         if ( ( ( context.localUtil.CToN( cgiGet( edtProdMedValor_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdMedValor_Internalname), ".", ",") > 99999999999.999999m ) ) )
         {
            GXCCtl = "PRODMEDVALOR_" + sGXsfl_34_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdMedValor_Internalname;
            wbErr = true;
            A1700ProdMedValor = 0;
         }
         else
         {
            A1700ProdMedValor = context.localUtil.CToN( cgiGet( edtProdMedValor_Internalname), ".", ",");
         }
         A1699ProdMedUniDsc = cgiGet( edtProdMedUniDsc_Internalname);
         GXCCtl = "Z58ProdMedUniCod_" + sGXsfl_34_idx;
         Z58ProdMedUniCod = (int)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z1700ProdMedValor_" + sGXsfl_34_idx;
         Z1700ProdMedValor = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_47_" + sGXsfl_34_idx;
         nRcdDeleted_47 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_47_" + sGXsfl_34_idx;
         nRcdExists_47 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_47_" + sGXsfl_34_idx;
         nIsMod_47 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtProdMedUniCod_Enabled = edtProdMedUniCod_Enabled;
      }

      protected void ConfirmValues1D0( )
      {
         nGXsfl_34_idx = 0;
         sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
         SubsflControlProps_3447( ) ;
         while ( nGXsfl_34_idx < nRC_GXsfl_34 )
         {
            nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_3447( ) ;
            ChangePostValue( "Z58ProdMedUniCod_"+sGXsfl_34_idx, cgiGet( "ZT_"+"Z58ProdMedUniCod_"+sGXsfl_34_idx)) ;
            DeletePostValue( "ZT_"+"Z58ProdMedUniCod_"+sGXsfl_34_idx) ;
            ChangePostValue( "Z1700ProdMedValor_"+sGXsfl_34_idx, cgiGet( "ZT_"+"Z1700ProdMedValor_"+sGXsfl_34_idx)) ;
            DeletePostValue( "ZT_"+"Z1700ProdMedValor_"+sGXsfl_34_idx) ;
         }
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Productos Unidades de Medida") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810235735", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aproductosmedidas.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"APRODUCTOSMEDIDAS");
         forbiddenHiddens.Add("ProdAfecICBPER", context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9"));
         forbiddenHiddens.Add("ProdValICBPER", context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("ProdValICBPERD", context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("aproductosmedidas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_34", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_34_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODAFECICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
      }

      protected void RenderHtmlCloseForm1D44( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "APRODUCTOSMEDIDAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Productos Unidades de Medida" ;
      }

      protected void InitializeNonKey1D44( )
      {
         A906ProdAfecICBPER = 0;
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
         A907ProdValICBPER = 0;
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
         A908ProdValICBPERD = 0;
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
         Z906ProdAfecICBPER = 0;
         Z907ProdValICBPER = 0;
         Z908ProdValICBPERD = 0;
      }

      protected void InitAll1D44( )
      {
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         InitializeNonKey1D44( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1D47( )
      {
         A1700ProdMedValor = 0;
         A1699ProdMedUniDsc = "";
         Z1700ProdMedValor = 0;
      }

      protected void InitAll1D47( )
      {
         A58ProdMedUniCod = 0;
         InitializeNonKey1D47( ) ;
      }

      protected void StandaloneModalInsert1D47( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810235743", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("aproductosmedidas.js", "?202281810235744", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties47( )
      {
         edtProdMedUniCod_Enabled = defedtProdMedUniCod_Enabled;
         AssignProp("", false, edtProdMedUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdMedUniCod_Enabled), 5, 0), !bGXsfl_34_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtProdCod_Internalname = "PRODCOD";
         lblTitlelevel1_Internalname = "TITLELEVEL1";
         edtProdMedUniCod_Internalname = "PRODMEDUNICOD";
         edtProdMedValor_Internalname = "PRODMEDVALOR";
         edtProdMedUniDsc_Internalname = "PRODMEDUNIDSC";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridaproductosmedidas_level1item_Internalname = "GRIDAPRODUCTOSMEDIDAS_LEVEL1ITEM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         edtProdMedUniDsc_Jsonclick = "";
         edtProdMedValor_Jsonclick = "";
         edtProdMedUniCod_Jsonclick = "";
         subGridaproductosmedidas_level1item_Class = "Grid";
         subGridaproductosmedidas_level1item_Backcolorstyle = 0;
         subGridaproductosmedidas_level1item_Allowcollapsing = 0;
         subGridaproductosmedidas_level1item_Allowselection = 0;
         edtProdMedUniDsc_Enabled = 0;
         edtProdMedValor_Enabled = 1;
         edtProdMedUniCod_Enabled = 1;
         subGridaproductosmedidas_level1item_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
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

      protected void gxnrGridaproductosmedidas_level1item_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3447( ) ;
         while ( nGXsfl_34_idx <= nRC_GXsfl_34 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1D47( ) ;
            standaloneModal1D47( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1D47( ) ;
            nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
            sGXsfl_34_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_34_idx), 4, 0), 4, "0");
            SubsflControlProps_3447( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridaproductosmedidas_level1itemContainer)) ;
         /* End function gxnrGridaproductosmedidas_level1item_newrow */
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

      public void Valid_Prodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodmedunicod( )
      {
         /* Using cursor T001D53 */
         pr_default.execute(51, new Object[] {A58ProdMedUniCod});
         if ( (pr_default.getStatus(51) == 101) )
         {
            GX_msglist.addItem("No existe 'Productos Unidades'.", "ForeignKeyNotFound", 1, "PRODMEDUNICOD");
            AnyError = 1;
            GX_FocusControl = edtProdMedUniCod_Internalname;
         }
         A1699ProdMedUniDsc = T001D53_A1699ProdMedUniDsc[0];
         pr_default.close(51);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1699ProdMedUniDsc", StringUtil.RTrim( A1699ProdMedUniDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z28ProdCod'},{av:'Z906ProdAfecICBPER'},{av:'Z907ProdValICBPER'},{av:'Z908ProdValICBPERD'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODMEDUNICOD","{handler:'Valid_Prodmedunicod',iparms:[{av:'A58ProdMedUniCod',fld:'PRODMEDUNICOD',pic:'ZZZZZ9'},{av:'A1699ProdMedUniDsc',fld:'PRODMEDUNIDSC',pic:''}]");
         setEventMetadata("VALID_PRODMEDUNICOD",",oparms:[{av:'A1699ProdMedUniDsc',fld:'PRODMEDUNIDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Prodmedunidsc',iparms:[]");
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
         pr_default.close(51);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z28ProdCod = "";
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
         A28ProdCod = "";
         lblTitlelevel1_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridaproductosmedidas_level1itemContainer = new GXWebGrid( context);
         Gridaproductosmedidas_level1itemColumn = new GXWebColumn();
         A1699ProdMedUniDsc = "";
         sMode47 = "";
         sStyleString = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         T001D7_A28ProdCod = new string[] {""} ;
         T001D7_A906ProdAfecICBPER = new short[1] ;
         T001D7_A907ProdValICBPER = new decimal[1] ;
         T001D7_A908ProdValICBPERD = new decimal[1] ;
         T001D8_A28ProdCod = new string[] {""} ;
         T001D6_A28ProdCod = new string[] {""} ;
         T001D6_A906ProdAfecICBPER = new short[1] ;
         T001D6_A907ProdValICBPER = new decimal[1] ;
         T001D6_A908ProdValICBPERD = new decimal[1] ;
         sMode44 = "";
         T001D9_A28ProdCod = new string[] {""} ;
         T001D10_A28ProdCod = new string[] {""} ;
         T001D5_A28ProdCod = new string[] {""} ;
         T001D5_A906ProdAfecICBPER = new short[1] ;
         T001D5_A907ProdValICBPER = new decimal[1] ;
         T001D5_A908ProdValICBPERD = new decimal[1] ;
         T001D14_A2385ProCosProdCod = new string[] {""} ;
         T001D15_A2382ProGasProdCod = new string[] {""} ;
         T001D16_A329PSerCod = new string[] {""} ;
         T001D16_A335PSerDItem = new int[1] ;
         T001D17_A329PSerCod = new string[] {""} ;
         T001D18_A324ProPlanCod = new string[] {""} ;
         T001D18_A331ProPlanDProdCod = new string[] {""} ;
         T001D19_A322ProCod = new string[] {""} ;
         T001D19_A326ProDItem = new int[1] ;
         T001D20_A322ProCod = new string[] {""} ;
         T001D21_A317ProCotProdCod = new string[] {""} ;
         T001D21_A318ProCotItem = new int[1] ;
         T001D22_A317ProCotProdCod = new string[] {""} ;
         T001D23_A310Iesa_SabPedCod = new string[] {""} ;
         T001D23_A311Iesa_SabProdSec = new int[1] ;
         T001D23_A312Iesa_SabProdCod = new string[] {""} ;
         T001D24_A286CPLisHisProdCod = new string[] {""} ;
         T001D24_A287CPLisHisPrvCod = new string[] {""} ;
         T001D24_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T001D25_A284CPLisProdCod = new string[] {""} ;
         T001D26_A149TipCod = new string[] {""} ;
         T001D26_A243ComCod = new string[] {""} ;
         T001D26_A244PrvCod = new string[] {""} ;
         T001D26_A250ComDItem = new short[1] ;
         T001D26_A251ComDOrdCod = new string[] {""} ;
         T001D27_A191ImpItem = new long[1] ;
         T001D27_A197ImpDItem = new int[1] ;
         T001D28_A81CBonProdCod = new string[] {""} ;
         T001D29_A81CBonProdCod = new string[] {""} ;
         T001D30_A59SalCosAno = new int[1] ;
         T001D30_A60SalCosMes = new short[1] ;
         T001D30_A61SalCosAlmCod = new int[1] ;
         T001D30_A62SalCosProdCod = new string[] {""} ;
         T001D31_A37ListItem = new int[1] ;
         T001D32_A289OrdCod = new string[] {""} ;
         T001D32_A295OrdDItem = new int[1] ;
         T001D33_A149TipCod = new string[] {""} ;
         T001D33_A24DocNum = new string[] {""} ;
         T001D33_A233DocItem = new long[1] ;
         T001D34_A224LotCliCod = new string[] {""} ;
         T001D35_A210PedCod = new string[] {""} ;
         T001D35_A216PedDItem = new short[1] ;
         T001D36_A202TipLCod = new int[1] ;
         T001D36_A203TipLItem = new int[1] ;
         T001D37_A177CotCod = new string[] {""} ;
         T001D37_A183CotDItem = new short[1] ;
         T001D38_A13MvATip = new string[] {""} ;
         T001D38_A14MvACod = new string[] {""} ;
         T001D38_A30MvADItem = new int[1] ;
         T001D39_A210PedCod = new string[] {""} ;
         T001D39_A28ProdCod = new string[] {""} ;
         T001D39_A217PedDLRef1 = new string[] {""} ;
         T001D40_A63AlmCod = new int[1] ;
         T001D40_A28ProdCod = new string[] {""} ;
         T001D41_A28ProdCod = new string[] {""} ;
         T001D41_A57ProdForProdCod = new string[] {""} ;
         T001D42_A28ProdCod = new string[] {""} ;
         T001D42_A57ProdForProdCod = new string[] {""} ;
         T001D43_A28ProdCod = new string[] {""} ;
         T001D43_A56ProdEQVCod = new string[] {""} ;
         T001D44_A28ProdCod = new string[] {""} ;
         T001D44_A56ProdEQVCod = new string[] {""} ;
         T001D45_A26AGMVATip = new string[] {""} ;
         T001D45_A27AGMVACod = new string[] {""} ;
         T001D45_A28ProdCod = new string[] {""} ;
         T001D46_A28ProdCod = new string[] {""} ;
         Z1699ProdMedUniDsc = "";
         T001D47_A28ProdCod = new string[] {""} ;
         T001D47_A1700ProdMedValor = new decimal[1] ;
         T001D47_A1699ProdMedUniDsc = new string[] {""} ;
         T001D47_A58ProdMedUniCod = new int[1] ;
         T001D4_A1699ProdMedUniDsc = new string[] {""} ;
         T001D48_A1699ProdMedUniDsc = new string[] {""} ;
         T001D49_A28ProdCod = new string[] {""} ;
         T001D49_A58ProdMedUniCod = new int[1] ;
         T001D3_A28ProdCod = new string[] {""} ;
         T001D3_A1700ProdMedValor = new decimal[1] ;
         T001D3_A58ProdMedUniCod = new int[1] ;
         T001D2_A28ProdCod = new string[] {""} ;
         T001D2_A1700ProdMedValor = new decimal[1] ;
         T001D2_A58ProdMedUniCod = new int[1] ;
         T001D53_A1699ProdMedUniDsc = new string[] {""} ;
         T001D54_A28ProdCod = new string[] {""} ;
         T001D54_A58ProdMedUniCod = new int[1] ;
         Gridaproductosmedidas_level1itemRow = new GXWebRow();
         subGridaproductosmedidas_level1item_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ28ProdCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aproductosmedidas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductosmedidas__default(),
            new Object[][] {
                new Object[] {
               T001D2_A28ProdCod, T001D2_A1700ProdMedValor, T001D2_A58ProdMedUniCod
               }
               , new Object[] {
               T001D3_A28ProdCod, T001D3_A1700ProdMedValor, T001D3_A58ProdMedUniCod
               }
               , new Object[] {
               T001D4_A1699ProdMedUniDsc
               }
               , new Object[] {
               T001D5_A28ProdCod, T001D5_A906ProdAfecICBPER, T001D5_A907ProdValICBPER, T001D5_A908ProdValICBPERD
               }
               , new Object[] {
               T001D6_A28ProdCod, T001D6_A906ProdAfecICBPER, T001D6_A907ProdValICBPER, T001D6_A908ProdValICBPERD
               }
               , new Object[] {
               T001D7_A28ProdCod, T001D7_A906ProdAfecICBPER, T001D7_A907ProdValICBPER, T001D7_A908ProdValICBPERD
               }
               , new Object[] {
               T001D8_A28ProdCod
               }
               , new Object[] {
               T001D9_A28ProdCod
               }
               , new Object[] {
               T001D10_A28ProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001D14_A2385ProCosProdCod
               }
               , new Object[] {
               T001D15_A2382ProGasProdCod
               }
               , new Object[] {
               T001D16_A329PSerCod, T001D16_A335PSerDItem
               }
               , new Object[] {
               T001D17_A329PSerCod
               }
               , new Object[] {
               T001D18_A324ProPlanCod, T001D18_A331ProPlanDProdCod
               }
               , new Object[] {
               T001D19_A322ProCod, T001D19_A326ProDItem
               }
               , new Object[] {
               T001D20_A322ProCod
               }
               , new Object[] {
               T001D21_A317ProCotProdCod, T001D21_A318ProCotItem
               }
               , new Object[] {
               T001D22_A317ProCotProdCod
               }
               , new Object[] {
               T001D23_A310Iesa_SabPedCod, T001D23_A311Iesa_SabProdSec, T001D23_A312Iesa_SabProdCod
               }
               , new Object[] {
               T001D24_A286CPLisHisProdCod, T001D24_A287CPLisHisPrvCod, T001D24_A288CPLisHisFecha
               }
               , new Object[] {
               T001D25_A284CPLisProdCod
               }
               , new Object[] {
               T001D26_A149TipCod, T001D26_A243ComCod, T001D26_A244PrvCod, T001D26_A250ComDItem, T001D26_A251ComDOrdCod
               }
               , new Object[] {
               T001D27_A191ImpItem, T001D27_A197ImpDItem
               }
               , new Object[] {
               T001D28_A81CBonProdCod
               }
               , new Object[] {
               T001D29_A81CBonProdCod
               }
               , new Object[] {
               T001D30_A59SalCosAno, T001D30_A60SalCosMes, T001D30_A61SalCosAlmCod, T001D30_A62SalCosProdCod
               }
               , new Object[] {
               T001D31_A37ListItem
               }
               , new Object[] {
               T001D32_A289OrdCod, T001D32_A295OrdDItem
               }
               , new Object[] {
               T001D33_A149TipCod, T001D33_A24DocNum, T001D33_A233DocItem
               }
               , new Object[] {
               T001D34_A224LotCliCod
               }
               , new Object[] {
               T001D35_A210PedCod, T001D35_A216PedDItem
               }
               , new Object[] {
               T001D36_A202TipLCod, T001D36_A203TipLItem
               }
               , new Object[] {
               T001D37_A177CotCod, T001D37_A183CotDItem
               }
               , new Object[] {
               T001D38_A13MvATip, T001D38_A14MvACod, T001D38_A30MvADItem
               }
               , new Object[] {
               T001D39_A210PedCod, T001D39_A28ProdCod, T001D39_A217PedDLRef1
               }
               , new Object[] {
               T001D40_A63AlmCod, T001D40_A28ProdCod
               }
               , new Object[] {
               T001D41_A28ProdCod, T001D41_A57ProdForProdCod
               }
               , new Object[] {
               T001D42_A28ProdCod, T001D42_A57ProdForProdCod
               }
               , new Object[] {
               T001D43_A28ProdCod, T001D43_A56ProdEQVCod
               }
               , new Object[] {
               T001D44_A28ProdCod, T001D44_A56ProdEQVCod
               }
               , new Object[] {
               T001D45_A26AGMVATip, T001D45_A27AGMVACod, T001D45_A28ProdCod
               }
               , new Object[] {
               T001D46_A28ProdCod
               }
               , new Object[] {
               T001D47_A28ProdCod, T001D47_A1700ProdMedValor, T001D47_A1699ProdMedUniDsc, T001D47_A58ProdMedUniCod
               }
               , new Object[] {
               T001D48_A1699ProdMedUniDsc
               }
               , new Object[] {
               T001D49_A28ProdCod, T001D49_A58ProdMedUniCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001D53_A1699ProdMedUniDsc
               }
               , new Object[] {
               T001D54_A28ProdCod, T001D54_A58ProdMedUniCod
               }
            }
         );
      }

      private short Z906ProdAfecICBPER ;
      private short nRcdDeleted_47 ;
      private short nRcdExists_47 ;
      private short nIsMod_47 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short subGridaproductosmedidas_level1item_Backcolorstyle ;
      private short subGridaproductosmedidas_level1item_Allowselection ;
      private short subGridaproductosmedidas_level1item_Allowhovering ;
      private short subGridaproductosmedidas_level1item_Allowcollapsing ;
      private short subGridaproductosmedidas_level1item_Collapsed ;
      private short nBlankRcdCount47 ;
      private short RcdFound47 ;
      private short nBlankRcdUsr47 ;
      private short A906ProdAfecICBPER ;
      private short GX_JID ;
      private short RcdFound44 ;
      private short nIsDirty_44 ;
      private short Gx_BScreen ;
      private short nIsDirty_47 ;
      private short subGridaproductosmedidas_level1item_Backstyle ;
      private short ZZ906ProdAfecICBPER ;
      private int nRC_GXsfl_34 ;
      private int nGXsfl_34_idx=1 ;
      private int Z58ProdMedUniCod ;
      private int A58ProdMedUniCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProdCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProdMedUniCod_Enabled ;
      private int edtProdMedValor_Enabled ;
      private int edtProdMedUniDsc_Enabled ;
      private int subGridaproductosmedidas_level1item_Selectedindex ;
      private int subGridaproductosmedidas_level1item_Selectioncolor ;
      private int subGridaproductosmedidas_level1item_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridaproductosmedidas_level1item_Backcolor ;
      private int subGridaproductosmedidas_level1item_Allbackcolor ;
      private int defedtProdMedUniCod_Enabled ;
      private int idxLst ;
      private long GRIDAPRODUCTOSMEDIDAS_LEVEL1ITEM_nFirstRecordOnPage ;
      private decimal Z907ProdValICBPER ;
      private decimal Z908ProdValICBPERD ;
      private decimal Z1700ProdMedValor ;
      private decimal A1700ProdMedValor ;
      private decimal A907ProdValICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal ZZ907ProdValICBPER ;
      private decimal ZZ908ProdValICBPERD ;
      private string sPrefix ;
      private string Z28ProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_34_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProdCod_Internalname ;
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
      private string A28ProdCod ;
      private string edtProdCod_Jsonclick ;
      private string lblTitlelevel1_Internalname ;
      private string lblTitlelevel1_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridaproductosmedidas_level1item_Header ;
      private string A1699ProdMedUniDsc ;
      private string sMode47 ;
      private string edtProdMedUniCod_Internalname ;
      private string edtProdMedValor_Internalname ;
      private string edtProdMedUniDsc_Internalname ;
      private string sStyleString ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode44 ;
      private string Z1699ProdMedUniDsc ;
      private string sGXsfl_34_fel_idx="0001" ;
      private string subGridaproductosmedidas_level1item_Class ;
      private string subGridaproductosmedidas_level1item_Linesclass ;
      private string ROClassString ;
      private string edtProdMedUniCod_Jsonclick ;
      private string edtProdMedValor_Jsonclick ;
      private string edtProdMedUniDsc_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridaproductosmedidas_level1item_Internalname ;
      private string ZZ28ProdCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_34_Refreshing=false ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridaproductosmedidas_level1itemContainer ;
      private GXWebRow Gridaproductosmedidas_level1itemRow ;
      private GXWebColumn Gridaproductosmedidas_level1itemColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001D7_A28ProdCod ;
      private short[] T001D7_A906ProdAfecICBPER ;
      private decimal[] T001D7_A907ProdValICBPER ;
      private decimal[] T001D7_A908ProdValICBPERD ;
      private string[] T001D8_A28ProdCod ;
      private string[] T001D6_A28ProdCod ;
      private short[] T001D6_A906ProdAfecICBPER ;
      private decimal[] T001D6_A907ProdValICBPER ;
      private decimal[] T001D6_A908ProdValICBPERD ;
      private string[] T001D9_A28ProdCod ;
      private string[] T001D10_A28ProdCod ;
      private string[] T001D5_A28ProdCod ;
      private short[] T001D5_A906ProdAfecICBPER ;
      private decimal[] T001D5_A907ProdValICBPER ;
      private decimal[] T001D5_A908ProdValICBPERD ;
      private string[] T001D14_A2385ProCosProdCod ;
      private string[] T001D15_A2382ProGasProdCod ;
      private string[] T001D16_A329PSerCod ;
      private int[] T001D16_A335PSerDItem ;
      private string[] T001D17_A329PSerCod ;
      private string[] T001D18_A324ProPlanCod ;
      private string[] T001D18_A331ProPlanDProdCod ;
      private string[] T001D19_A322ProCod ;
      private int[] T001D19_A326ProDItem ;
      private string[] T001D20_A322ProCod ;
      private string[] T001D21_A317ProCotProdCod ;
      private int[] T001D21_A318ProCotItem ;
      private string[] T001D22_A317ProCotProdCod ;
      private string[] T001D23_A310Iesa_SabPedCod ;
      private int[] T001D23_A311Iesa_SabProdSec ;
      private string[] T001D23_A312Iesa_SabProdCod ;
      private string[] T001D24_A286CPLisHisProdCod ;
      private string[] T001D24_A287CPLisHisPrvCod ;
      private DateTime[] T001D24_A288CPLisHisFecha ;
      private string[] T001D25_A284CPLisProdCod ;
      private string[] T001D26_A149TipCod ;
      private string[] T001D26_A243ComCod ;
      private string[] T001D26_A244PrvCod ;
      private short[] T001D26_A250ComDItem ;
      private string[] T001D26_A251ComDOrdCod ;
      private long[] T001D27_A191ImpItem ;
      private int[] T001D27_A197ImpDItem ;
      private string[] T001D28_A81CBonProdCod ;
      private string[] T001D29_A81CBonProdCod ;
      private int[] T001D30_A59SalCosAno ;
      private short[] T001D30_A60SalCosMes ;
      private int[] T001D30_A61SalCosAlmCod ;
      private string[] T001D30_A62SalCosProdCod ;
      private int[] T001D31_A37ListItem ;
      private string[] T001D32_A289OrdCod ;
      private int[] T001D32_A295OrdDItem ;
      private string[] T001D33_A149TipCod ;
      private string[] T001D33_A24DocNum ;
      private long[] T001D33_A233DocItem ;
      private string[] T001D34_A224LotCliCod ;
      private string[] T001D35_A210PedCod ;
      private short[] T001D35_A216PedDItem ;
      private int[] T001D36_A202TipLCod ;
      private int[] T001D36_A203TipLItem ;
      private string[] T001D37_A177CotCod ;
      private short[] T001D37_A183CotDItem ;
      private string[] T001D38_A13MvATip ;
      private string[] T001D38_A14MvACod ;
      private int[] T001D38_A30MvADItem ;
      private string[] T001D39_A210PedCod ;
      private string[] T001D39_A28ProdCod ;
      private string[] T001D39_A217PedDLRef1 ;
      private int[] T001D40_A63AlmCod ;
      private string[] T001D40_A28ProdCod ;
      private string[] T001D41_A28ProdCod ;
      private string[] T001D41_A57ProdForProdCod ;
      private string[] T001D42_A28ProdCod ;
      private string[] T001D42_A57ProdForProdCod ;
      private string[] T001D43_A28ProdCod ;
      private string[] T001D43_A56ProdEQVCod ;
      private string[] T001D44_A28ProdCod ;
      private string[] T001D44_A56ProdEQVCod ;
      private string[] T001D45_A26AGMVATip ;
      private string[] T001D45_A27AGMVACod ;
      private string[] T001D45_A28ProdCod ;
      private string[] T001D46_A28ProdCod ;
      private string[] T001D47_A28ProdCod ;
      private decimal[] T001D47_A1700ProdMedValor ;
      private string[] T001D47_A1699ProdMedUniDsc ;
      private int[] T001D47_A58ProdMedUniCod ;
      private string[] T001D4_A1699ProdMedUniDsc ;
      private string[] T001D48_A1699ProdMedUniDsc ;
      private string[] T001D49_A28ProdCod ;
      private int[] T001D49_A58ProdMedUniCod ;
      private string[] T001D3_A28ProdCod ;
      private decimal[] T001D3_A1700ProdMedValor ;
      private int[] T001D3_A58ProdMedUniCod ;
      private string[] T001D2_A28ProdCod ;
      private decimal[] T001D2_A1700ProdMedValor ;
      private int[] T001D2_A58ProdMedUniCod ;
      private string[] T001D53_A1699ProdMedUniDsc ;
      private string[] T001D54_A28ProdCod ;
      private int[] T001D54_A58ProdMedUniCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class aproductosmedidas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aproductosmedidas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[11])
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
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new UpdateCursor(def[48])
       ,new UpdateCursor(def[49])
       ,new UpdateCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001D7;
        prmT001D7 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D8;
        prmT001D8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D6;
        prmT001D6 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D9;
        prmT001D9 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D10;
        prmT001D10 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D5;
        prmT001D5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D11;
        prmT001D11 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdAfecICBPER",GXType.Int16,1,0) ,
        new ParDef("@ProdValICBPER",GXType.Decimal,15,2) ,
        new ParDef("@ProdValICBPERD",GXType.Decimal,15,2)
        };
        Object[] prmT001D12;
        prmT001D12 = new Object[] {
        new ParDef("@ProdAfecICBPER",GXType.Int16,1,0) ,
        new ParDef("@ProdValICBPER",GXType.Decimal,15,2) ,
        new ParDef("@ProdValICBPERD",GXType.Decimal,15,2) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D13;
        prmT001D13 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D14;
        prmT001D14 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D15;
        prmT001D15 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D16;
        prmT001D16 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D17;
        prmT001D17 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D18;
        prmT001D18 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D19;
        prmT001D19 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D20;
        prmT001D20 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D21;
        prmT001D21 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D22;
        prmT001D22 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D23;
        prmT001D23 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D24;
        prmT001D24 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D25;
        prmT001D25 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D26;
        prmT001D26 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D27;
        prmT001D27 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D28;
        prmT001D28 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D29;
        prmT001D29 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D30;
        prmT001D30 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D31;
        prmT001D31 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D32;
        prmT001D32 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D33;
        prmT001D33 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D34;
        prmT001D34 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D35;
        prmT001D35 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D36;
        prmT001D36 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D37;
        prmT001D37 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D38;
        prmT001D38 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D39;
        prmT001D39 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D40;
        prmT001D40 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D41;
        prmT001D41 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D42;
        prmT001D42 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D43;
        prmT001D43 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D44;
        prmT001D44 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D45;
        prmT001D45 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D46;
        prmT001D46 = new Object[] {
        };
        Object[] prmT001D47;
        prmT001D47 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D4;
        prmT001D4 = new Object[] {
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D48;
        prmT001D48 = new Object[] {
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D49;
        prmT001D49 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D3;
        prmT001D3 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D2;
        prmT001D2 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D50;
        prmT001D50 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdMedValor",GXType.Decimal,18,6) ,
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D51;
        prmT001D51 = new Object[] {
        new ParDef("@ProdMedValor",GXType.Decimal,18,6) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D52;
        prmT001D52 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        Object[] prmT001D54;
        prmT001D54 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001D53;
        prmT001D53 = new Object[] {
        new ParDef("@ProdMedUniCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001D2", "SELECT [ProdCod], [ProdMedValor], [ProdMedUniCod] AS ProdMedUniCod FROM [APRODUCTOSMEDIDAS] WITH (UPDLOCK) WHERE [ProdCod] = @ProdCod AND [ProdMedUniCod] = @ProdMedUniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D3", "SELECT [ProdCod], [ProdMedValor], [ProdMedUniCod] AS ProdMedUniCod FROM [APRODUCTOSMEDIDAS] WHERE [ProdCod] = @ProdCod AND [ProdMedUniCod] = @ProdMedUniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D4", "SELECT [UniDsc] AS ProdMedUniDsc FROM [CUNIDADMEDIDA] WHERE [UniCod] = @ProdMedUniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D5", "SELECT [ProdCod], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD] FROM [APRODUCTOS] WITH (UPDLOCK) WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D6", "SELECT [ProdCod], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D7", "SELECT TM1.[ProdCod], TM1.[ProdAfecICBPER], TM1.[ProdValICBPER], TM1.[ProdValICBPERD] FROM [APRODUCTOS] TM1 WHERE TM1.[ProdCod] = @ProdCod ORDER BY TM1.[ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D8", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D9", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE ( [ProdCod] > @ProdCod) ORDER BY [ProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D10", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE ( [ProdCod] < @ProdCod) ORDER BY [ProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D11", "INSERT INTO [APRODUCTOS]([ProdCod], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD], [LinCod], [ProdDsc], [SublCod], [FamCod], [UniCod], [ProdVta], [ProdCmp], [ProdPeso], [ProdVolumen], [ProdStkMax], [ProdStkMin], [ProdFoto], [ProdFoto_GXI], [ProdRef1], [ProdRef2], [ProdRef3], [ProdRef4], [ProdRef5], [ProdRef6], [ProdRef7], [ProdRef8], [ProdRef9], [ProdRef10], [ProdSts], [ProdCosto], [ProdCostoFec], [ProdCostoD], [ProdIna], [ProdPorSel], [ProdImpSel], [ProdAdValor], [ProdFrecuente], [ProdCuentaV], [ProdCuentaC], [ProdCuentaA], [ProdUsuCod], [ProdUsuFec], [ProdAfec], [ProdObs], [ProdCanLote], [ProdBarra], [ProdExportacion], [CBSuCod], [cDetCod]) VALUES(@ProdCod, @ProdAfecICBPER, @ProdValICBPER, @ProdValICBPERD, convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), CONVERT(varbinary(1), ''), '', '', '', '', '', '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', '', convert( DATETIME, '17530101', 112 ), convert(int, 0), '', convert(int, 0), '', '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT001D11)
           ,new CursorDef("T001D12", "UPDATE [APRODUCTOS] SET [ProdAfecICBPER]=@ProdAfecICBPER, [ProdValICBPER]=@ProdValICBPER, [ProdValICBPERD]=@ProdValICBPERD  WHERE [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001D12)
           ,new CursorDef("T001D13", "DELETE FROM [APRODUCTOS]  WHERE [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001D13)
           ,new CursorDef("T001D14", "SELECT TOP 1 [ProCosProdCod] FROM [PROCOSTOMATERIAS] WHERE [ProCosProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D15", "SELECT TOP 1 [ProGasProdCod] FROM [PROCOSTOGASTOS] WHERE [ProGasProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D16", "SELECT TOP 1 [PSerCod], [PSerDItem] FROM [POSERVICIODET] WHERE [PSerDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D17", "SELECT TOP 1 [PSerCod] FROM [POSERVICIO] WHERE [PSerProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D18", "SELECT TOP 1 [ProPlanCod], [ProPlanDProdCod] FROM [POPLANDET] WHERE [ProPlanDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D19", "SELECT TOP 1 [ProCod], [ProDItem] FROM [POORDENESDET] WHERE [ProDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D20", "SELECT TOP 1 [ProCod] FROM [POORDENES] WHERE [ProProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D21", "SELECT TOP 1 [ProCotProdCod], [ProCotItem] FROM [POCOTIZADET] WHERE [ProCotDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D22", "SELECT TOP 1 [ProCotProdCod] FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D23", "SELECT TOP 1 [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod] FROM [OBR_SABANA] WHERE [Iesa_SabProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D24", "SELECT TOP 1 [CPLisHisProdCod], [CPLisHisPrvCod], [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] WHERE [CPLisHisProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D25", "SELECT TOP 1 [CPLisProdCod] FROM [CPLISTAPRECIOS] WHERE [CPLisProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D26", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [ComDProCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D27", "SELECT TOP 1 [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] WHERE [ImpDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D28", "SELECT TOP 1 [CBonProdCod] FROM [CBONIFICACION] WHERE [CBonDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D29", "SELECT TOP 1 [CBonProdCod] FROM [CBONIFICACION] WHERE [CBonProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D30", "SELECT TOP 1 [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod] FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D31", "SELECT TOP 1 [ListItem] FROM [ALISTADESCUENTO] WHERE [ListProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D32", "SELECT TOP 1 [OrdCod], [OrdDItem] FROM [CPORDENDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D33", "SELECT TOP 1 [TipCod], [DocNum], [DocItem] FROM [CLVENTASDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D34", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D35", "SELECT TOP 1 [PedCod], [PedDItem] FROM [CLPEDIDOSDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D36", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D37", "SELECT TOP 1 [CotCod], [CotDItem] FROM [CLCOTIZADET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D38", "SELECT TOP 1 [MvATip], [MvACod], [MvADItem] FROM [AGUIASDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D39", "SELECT TOP 1 [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D40", "SELECT TOP 1 [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D41", "SELECT TOP 1 [ProdCod], [ProdForProdCod] FROM [APRODUCTOSFORMULA] WHERE [ProdForProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D41,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D42", "SELECT TOP 1 [ProdCod], [ProdForProdCod] FROM [APRODUCTOSFORMULA] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D42,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D43", "SELECT TOP 1 [ProdCod], [ProdEQVCod] FROM [APRODUCTOSEQUIVALENTE] WHERE [ProdEQVCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D43,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D44", "SELECT TOP 1 [ProdCod], [ProdEQVCod] FROM [APRODUCTOSEQUIVALENTE] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D44,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D45", "SELECT TOP 1 [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D45,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001D46", "SELECT [ProdCod] FROM [APRODUCTOS] ORDER BY [ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001D46,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D47", "SELECT T1.[ProdCod], T1.[ProdMedValor], T2.[UniDsc] AS ProdMedUniDsc, T1.[ProdMedUniCod] AS ProdMedUniCod FROM ([APRODUCTOSMEDIDAS] T1 INNER JOIN [CUNIDADMEDIDA] T2 ON T2.[UniCod] = T1.[ProdMedUniCod]) WHERE T1.[ProdCod] = @ProdCod and T1.[ProdMedUniCod] = @ProdMedUniCod ORDER BY T1.[ProdCod], T1.[ProdMedUniCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D47,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D48", "SELECT [UniDsc] AS ProdMedUniDsc FROM [CUNIDADMEDIDA] WHERE [UniCod] = @ProdMedUniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D48,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D49", "SELECT [ProdCod], [ProdMedUniCod] AS ProdMedUniCod FROM [APRODUCTOSMEDIDAS] WHERE [ProdCod] = @ProdCod AND [ProdMedUniCod] = @ProdMedUniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D49,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D50", "INSERT INTO [APRODUCTOSMEDIDAS]([ProdCod], [ProdMedValor], [ProdMedUniCod]) VALUES(@ProdCod, @ProdMedValor, @ProdMedUniCod)", GxErrorMask.GX_NOMASK,prmT001D50)
           ,new CursorDef("T001D51", "UPDATE [APRODUCTOSMEDIDAS] SET [ProdMedValor]=@ProdMedValor  WHERE [ProdCod] = @ProdCod AND [ProdMedUniCod] = @ProdMedUniCod", GxErrorMask.GX_NOMASK,prmT001D51)
           ,new CursorDef("T001D52", "DELETE FROM [APRODUCTOSMEDIDAS]  WHERE [ProdCod] = @ProdCod AND [ProdMedUniCod] = @ProdMedUniCod", GxErrorMask.GX_NOMASK,prmT001D52)
           ,new CursorDef("T001D53", "SELECT [UniDsc] AS ProdMedUniDsc FROM [CUNIDADMEDIDA] WHERE [UniCod] = @ProdMedUniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D53,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001D54", "SELECT [ProdCod], [ProdMedUniCod] AS ProdMedUniCod FROM [APRODUCTOSMEDIDAS] WHERE [ProdCod] = @ProdCod ORDER BY [ProdCod], [ProdMedUniCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001D54,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 29 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 34 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 38 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 52 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
     }
  }

}

}
