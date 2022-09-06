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
   public class amovimientosfifo : GXDataArea
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
            Form.Meta.addItem("description", "AMOVIMIENTOSFIFO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFifoAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public amovimientosfifo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public amovimientosfifo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "AMOVIMIENTOSFIFO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_AMOVIMIENTOSFIFO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AMOVIMIENTOSFIFO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoAlmCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoAlmCod_Internalname, "Almacen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A40FifoAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtFifoAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A40FifoAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A40FifoAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVACod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVACod_Internalname, "Ingreso", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoMVACod_Internalname, StringUtil.RTrim( A41FifoMVACod), StringUtil.RTrim( context.localUtil.Format( A41FifoMVACod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVACod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVAFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVAFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtFifoMVAFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtFifoMVAFec_Internalname, context.localUtil.Format(A985FifoMVAFec, "99/99/99"), context.localUtil.Format( A985FifoMVAFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVAFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVAFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_bitmap( context, edtFifoMVAFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtFifoMVAFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AMOVIMIENTOSFIFO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoProdCod_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoProdCod_Internalname, StringUtil.RTrim( A42FifoProdCod), StringUtil.RTrim( context.localUtil.Format( A42FifoProdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVADItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVADItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoMVADItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A43FifoMVADItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtFifoMVADItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A43FifoMVADItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A43FifoMVADItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVADItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVADItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVADCant_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVADCant_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoMVADCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A980FifoMVADCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtFifoMVADCant_Enabled!=0) ? context.localUtil.Format( A980FifoMVADCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A980FifoMVADCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVADCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVADCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVADPrecio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVADPrecio_Internalname, "Precio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoMVADPrecio_Internalname, StringUtil.LTrim( StringUtil.NToC( A984FifoMVADPrecio, 17, 4, ".", "")), StringUtil.LTrim( ((edtFifoMVADPrecio_Enabled!=0) ? context.localUtil.Format( A984FifoMVADPrecio, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A984FifoMVADPrecio, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVADPrecio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVADPrecio_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVADCosto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVADCosto_Internalname, "Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoMVADCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A983FifoMVADCosto, 17, 2, ".", "")), StringUtil.LTrim( ((edtFifoMVADCosto_Enabled!=0) ? context.localUtil.Format( A983FifoMVADCosto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A983FifoMVADCosto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVADCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVADCosto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVADCantFifo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVADCantFifo_Internalname, "Fifo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFifoMVADCantFifo_Internalname, StringUtil.LTrim( StringUtil.NToC( A981FifoMVADCantFifo, 17, 4, ".", "")), StringUtil.LTrim( ((edtFifoMVADCantFifo_Enabled!=0) ? context.localUtil.Format( A981FifoMVADCantFifo, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A981FifoMVADCantFifo, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVADCantFifo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVADCantFifo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFifoMVADCantSaldo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFifoMVADCantSaldo_Internalname, "Saldo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFifoMVADCantSaldo_Internalname, StringUtil.LTrim( StringUtil.NToC( A982FifoMVADCantSaldo, 17, 4, ".", "")), StringUtil.LTrim( ((edtFifoMVADCantSaldo_Enabled!=0) ? context.localUtil.Format( A982FifoMVADCantSaldo, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A982FifoMVADCantSaldo, "ZZZZ,ZZZ,ZZ9.9999"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFifoMVADCantSaldo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFifoMVADCantSaldo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AMOVIMIENTOSFIFO.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AMOVIMIENTOSFIFO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AMOVIMIENTOSFIFO.htm");
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
            Z40FifoAlmCod = (int)(context.localUtil.CToN( cgiGet( "Z40FifoAlmCod"), ".", ","));
            Z41FifoMVACod = cgiGet( "Z41FifoMVACod");
            Z42FifoProdCod = cgiGet( "Z42FifoProdCod");
            Z43FifoMVADItem = (int)(context.localUtil.CToN( cgiGet( "Z43FifoMVADItem"), ".", ","));
            Z985FifoMVAFec = context.localUtil.CToD( cgiGet( "Z985FifoMVAFec"), 0);
            Z980FifoMVADCant = context.localUtil.CToN( cgiGet( "Z980FifoMVADCant"), ".", ",");
            Z984FifoMVADPrecio = context.localUtil.CToN( cgiGet( "Z984FifoMVADPrecio"), ".", ",");
            Z983FifoMVADCosto = context.localUtil.CToN( cgiGet( "Z983FifoMVADCosto"), ".", ",");
            Z981FifoMVADCantFifo = context.localUtil.CToN( cgiGet( "Z981FifoMVADCantFifo"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtFifoAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFifoAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FIFOALMCOD");
               AnyError = 1;
               GX_FocusControl = edtFifoAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A40FifoAlmCod = 0;
               AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
            }
            else
            {
               A40FifoAlmCod = (int)(context.localUtil.CToN( cgiGet( edtFifoAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
            }
            A41FifoMVACod = cgiGet( edtFifoMVACod_Internalname);
            AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
            if ( context.localUtil.VCDate( cgiGet( edtFifoMVAFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "FIFOMVAFEC");
               AnyError = 1;
               GX_FocusControl = edtFifoMVAFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A985FifoMVAFec = DateTime.MinValue;
               AssignAttri("", false, "A985FifoMVAFec", context.localUtil.Format(A985FifoMVAFec, "99/99/99"));
            }
            else
            {
               A985FifoMVAFec = context.localUtil.CToD( cgiGet( edtFifoMVAFec_Internalname), 2);
               AssignAttri("", false, "A985FifoMVAFec", context.localUtil.Format(A985FifoMVAFec, "99/99/99"));
            }
            A42FifoProdCod = cgiGet( edtFifoProdCod_Internalname);
            AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtFifoMVADItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFifoMVADItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FIFOMVADITEM");
               AnyError = 1;
               GX_FocusControl = edtFifoMVADItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A43FifoMVADItem = 0;
               AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
            }
            else
            {
               A43FifoMVADItem = (int)(context.localUtil.CToN( cgiGet( edtFifoMVADItem_Internalname), ".", ","));
               AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFifoMVADCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtFifoMVADCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FIFOMVADCANT");
               AnyError = 1;
               GX_FocusControl = edtFifoMVADCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A980FifoMVADCant = 0;
               AssignAttri("", false, "A980FifoMVADCant", StringUtil.LTrimStr( A980FifoMVADCant, 15, 4));
            }
            else
            {
               A980FifoMVADCant = context.localUtil.CToN( cgiGet( edtFifoMVADCant_Internalname), ".", ",");
               AssignAttri("", false, "A980FifoMVADCant", StringUtil.LTrimStr( A980FifoMVADCant, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFifoMVADPrecio_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtFifoMVADPrecio_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FIFOMVADPRECIO");
               AnyError = 1;
               GX_FocusControl = edtFifoMVADPrecio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A984FifoMVADPrecio = 0;
               AssignAttri("", false, "A984FifoMVADPrecio", StringUtil.LTrimStr( A984FifoMVADPrecio, 15, 4));
            }
            else
            {
               A984FifoMVADPrecio = context.localUtil.CToN( cgiGet( edtFifoMVADPrecio_Internalname), ".", ",");
               AssignAttri("", false, "A984FifoMVADPrecio", StringUtil.LTrimStr( A984FifoMVADPrecio, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFifoMVADCosto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtFifoMVADCosto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FIFOMVADCOSTO");
               AnyError = 1;
               GX_FocusControl = edtFifoMVADCosto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A983FifoMVADCosto = 0;
               AssignAttri("", false, "A983FifoMVADCosto", StringUtil.LTrimStr( A983FifoMVADCosto, 15, 2));
            }
            else
            {
               A983FifoMVADCosto = context.localUtil.CToN( cgiGet( edtFifoMVADCosto_Internalname), ".", ",");
               AssignAttri("", false, "A983FifoMVADCosto", StringUtil.LTrimStr( A983FifoMVADCosto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtFifoMVADCantFifo_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtFifoMVADCantFifo_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FIFOMVADCANTFIFO");
               AnyError = 1;
               GX_FocusControl = edtFifoMVADCantFifo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A981FifoMVADCantFifo = 0;
               AssignAttri("", false, "A981FifoMVADCantFifo", StringUtil.LTrimStr( A981FifoMVADCantFifo, 15, 4));
            }
            else
            {
               A981FifoMVADCantFifo = context.localUtil.CToN( cgiGet( edtFifoMVADCantFifo_Internalname), ".", ",");
               AssignAttri("", false, "A981FifoMVADCantFifo", StringUtil.LTrimStr( A981FifoMVADCantFifo, 15, 4));
            }
            A982FifoMVADCantSaldo = context.localUtil.CToN( cgiGet( edtFifoMVADCantSaldo_Internalname), ".", ",");
            AssignAttri("", false, "A982FifoMVADCantSaldo", StringUtil.LTrimStr( A982FifoMVADCantSaldo, 15, 4));
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
               A40FifoAlmCod = (int)(NumberUtil.Val( GetPar( "FifoAlmCod"), "."));
               AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
               A41FifoMVACod = GetPar( "FifoMVACod");
               AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
               A42FifoProdCod = GetPar( "FifoProdCod");
               AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
               A43FifoMVADItem = (int)(NumberUtil.Val( GetPar( "FifoMVADItem"), "."));
               AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
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
               InitAll033( ) ;
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
         DisableAttributes033( ) ;
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

      protected void ResetCaption030( )
      {
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z985FifoMVAFec = T00033_A985FifoMVAFec[0];
               Z980FifoMVADCant = T00033_A980FifoMVADCant[0];
               Z984FifoMVADPrecio = T00033_A984FifoMVADPrecio[0];
               Z983FifoMVADCosto = T00033_A983FifoMVADCosto[0];
               Z981FifoMVADCantFifo = T00033_A981FifoMVADCantFifo[0];
            }
            else
            {
               Z985FifoMVAFec = A985FifoMVAFec;
               Z980FifoMVADCant = A980FifoMVADCant;
               Z984FifoMVADPrecio = A984FifoMVADPrecio;
               Z983FifoMVADCosto = A983FifoMVADCosto;
               Z981FifoMVADCantFifo = A981FifoMVADCantFifo;
            }
         }
         if ( GX_JID == -3 )
         {
            Z40FifoAlmCod = A40FifoAlmCod;
            Z41FifoMVACod = A41FifoMVACod;
            Z42FifoProdCod = A42FifoProdCod;
            Z43FifoMVADItem = A43FifoMVADItem;
            Z985FifoMVAFec = A985FifoMVAFec;
            Z980FifoMVADCant = A980FifoMVADCant;
            Z984FifoMVADPrecio = A984FifoMVADPrecio;
            Z983FifoMVADCosto = A983FifoMVADCosto;
            Z981FifoMVADCantFifo = A981FifoMVADCantFifo;
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

      protected void Load033( )
      {
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound3 = 1;
            A985FifoMVAFec = T00034_A985FifoMVAFec[0];
            AssignAttri("", false, "A985FifoMVAFec", context.localUtil.Format(A985FifoMVAFec, "99/99/99"));
            A980FifoMVADCant = T00034_A980FifoMVADCant[0];
            AssignAttri("", false, "A980FifoMVADCant", StringUtil.LTrimStr( A980FifoMVADCant, 15, 4));
            A984FifoMVADPrecio = T00034_A984FifoMVADPrecio[0];
            AssignAttri("", false, "A984FifoMVADPrecio", StringUtil.LTrimStr( A984FifoMVADPrecio, 15, 4));
            A983FifoMVADCosto = T00034_A983FifoMVADCosto[0];
            AssignAttri("", false, "A983FifoMVADCosto", StringUtil.LTrimStr( A983FifoMVADCosto, 15, 2));
            A981FifoMVADCantFifo = T00034_A981FifoMVADCantFifo[0];
            AssignAttri("", false, "A981FifoMVADCantFifo", StringUtil.LTrimStr( A981FifoMVADCantFifo, 15, 4));
            ZM033( -3) ;
         }
         pr_default.close(2);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         A982FifoMVADCantSaldo = (decimal)(A980FifoMVADCant-A981FifoMVADCantFifo);
         AssignAttri("", false, "A982FifoMVADCantSaldo", StringUtil.LTrimStr( A982FifoMVADCantSaldo, 15, 4));
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A985FifoMVAFec) || ( DateTimeUtil.ResetTime ( A985FifoMVAFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "FIFOMVAFEC");
            AnyError = 1;
            GX_FocusControl = edtFifoMVAFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_3 = 1;
         A982FifoMVADCantSaldo = (decimal)(A980FifoMVADCant-A981FifoMVADCantFifo);
         AssignAttri("", false, "A982FifoMVADCantSaldo", StringUtil.LTrimStr( A982FifoMVADCantSaldo, 15, 4));
      }

      protected void CloseExtendedTableCursors033( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 3) ;
            RcdFound3 = 1;
            A40FifoAlmCod = T00033_A40FifoAlmCod[0];
            AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
            A41FifoMVACod = T00033_A41FifoMVACod[0];
            AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
            A42FifoProdCod = T00033_A42FifoProdCod[0];
            AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
            A43FifoMVADItem = T00033_A43FifoMVADItem[0];
            AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
            A985FifoMVAFec = T00033_A985FifoMVAFec[0];
            AssignAttri("", false, "A985FifoMVAFec", context.localUtil.Format(A985FifoMVAFec, "99/99/99"));
            A980FifoMVADCant = T00033_A980FifoMVADCant[0];
            AssignAttri("", false, "A980FifoMVADCant", StringUtil.LTrimStr( A980FifoMVADCant, 15, 4));
            A984FifoMVADPrecio = T00033_A984FifoMVADPrecio[0];
            AssignAttri("", false, "A984FifoMVADPrecio", StringUtil.LTrimStr( A984FifoMVADPrecio, 15, 4));
            A983FifoMVADCosto = T00033_A983FifoMVADCosto[0];
            AssignAttri("", false, "A983FifoMVADCosto", StringUtil.LTrimStr( A983FifoMVADCosto, 15, 2));
            A981FifoMVADCantFifo = T00033_A981FifoMVADCantFifo[0];
            AssignAttri("", false, "A981FifoMVADCantFifo", StringUtil.LTrimStr( A981FifoMVADCantFifo, 15, 4));
            Z40FifoAlmCod = A40FifoAlmCod;
            Z41FifoMVACod = A41FifoMVACod;
            Z42FifoProdCod = A42FifoProdCod;
            Z43FifoMVADItem = A43FifoMVADItem;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         RcdFound3 = 0;
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00036_A40FifoAlmCod[0] < A40FifoAlmCod ) || ( T00036_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00036_A41FifoMVACod[0], A41FifoMVACod) < 0 ) || ( StringUtil.StrCmp(T00036_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00036_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00036_A42FifoProdCod[0], A42FifoProdCod) < 0 ) || ( StringUtil.StrCmp(T00036_A42FifoProdCod[0], A42FifoProdCod) == 0 ) && ( StringUtil.StrCmp(T00036_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00036_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( T00036_A43FifoMVADItem[0] < A43FifoMVADItem ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00036_A40FifoAlmCod[0] > A40FifoAlmCod ) || ( T00036_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00036_A41FifoMVACod[0], A41FifoMVACod) > 0 ) || ( StringUtil.StrCmp(T00036_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00036_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00036_A42FifoProdCod[0], A42FifoProdCod) > 0 ) || ( StringUtil.StrCmp(T00036_A42FifoProdCod[0], A42FifoProdCod) == 0 ) && ( StringUtil.StrCmp(T00036_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00036_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( T00036_A43FifoMVADItem[0] > A43FifoMVADItem ) ) )
            {
               A40FifoAlmCod = T00036_A40FifoAlmCod[0];
               AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
               A41FifoMVACod = T00036_A41FifoMVACod[0];
               AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
               A42FifoProdCod = T00036_A42FifoProdCod[0];
               AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
               A43FifoMVADItem = T00036_A43FifoMVADItem[0];
               AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00037_A40FifoAlmCod[0] > A40FifoAlmCod ) || ( T00037_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00037_A41FifoMVACod[0], A41FifoMVACod) > 0 ) || ( StringUtil.StrCmp(T00037_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00037_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00037_A42FifoProdCod[0], A42FifoProdCod) > 0 ) || ( StringUtil.StrCmp(T00037_A42FifoProdCod[0], A42FifoProdCod) == 0 ) && ( StringUtil.StrCmp(T00037_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00037_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( T00037_A43FifoMVADItem[0] > A43FifoMVADItem ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00037_A40FifoAlmCod[0] < A40FifoAlmCod ) || ( T00037_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00037_A41FifoMVACod[0], A41FifoMVACod) < 0 ) || ( StringUtil.StrCmp(T00037_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00037_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( StringUtil.StrCmp(T00037_A42FifoProdCod[0], A42FifoProdCod) < 0 ) || ( StringUtil.StrCmp(T00037_A42FifoProdCod[0], A42FifoProdCod) == 0 ) && ( StringUtil.StrCmp(T00037_A41FifoMVACod[0], A41FifoMVACod) == 0 ) && ( T00037_A40FifoAlmCod[0] == A40FifoAlmCod ) && ( T00037_A43FifoMVADItem[0] < A43FifoMVADItem ) ) )
            {
               A40FifoAlmCod = T00037_A40FifoAlmCod[0];
               AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
               A41FifoMVACod = T00037_A41FifoMVACod[0];
               AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
               A42FifoProdCod = T00037_A42FifoProdCod[0];
               AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
               A43FifoMVADItem = T00037_A43FifoMVADItem[0];
               AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFifoAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( ( A40FifoAlmCod != Z40FifoAlmCod ) || ( StringUtil.StrCmp(A41FifoMVACod, Z41FifoMVACod) != 0 ) || ( StringUtil.StrCmp(A42FifoProdCod, Z42FifoProdCod) != 0 ) || ( A43FifoMVADItem != Z43FifoMVADItem ) )
               {
                  A40FifoAlmCod = Z40FifoAlmCod;
                  AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
                  A41FifoMVACod = Z41FifoMVACod;
                  AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
                  A42FifoProdCod = Z42FifoProdCod;
                  AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
                  A43FifoMVADItem = Z43FifoMVADItem;
                  AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FIFOALMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtFifoAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFifoAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtFifoAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A40FifoAlmCod != Z40FifoAlmCod ) || ( StringUtil.StrCmp(A41FifoMVACod, Z41FifoMVACod) != 0 ) || ( StringUtil.StrCmp(A42FifoProdCod, Z42FifoProdCod) != 0 ) || ( A43FifoMVADItem != Z43FifoMVADItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtFifoAlmCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FIFOALMCOD");
                     AnyError = 1;
                     GX_FocusControl = edtFifoAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtFifoAlmCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
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
         if ( ( A40FifoAlmCod != Z40FifoAlmCod ) || ( StringUtil.StrCmp(A41FifoMVACod, Z41FifoMVACod) != 0 ) || ( StringUtil.StrCmp(A42FifoProdCod, Z42FifoProdCod) != 0 ) || ( A43FifoMVADItem != Z43FifoMVADItem ) )
         {
            A40FifoAlmCod = Z40FifoAlmCod;
            AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
            A41FifoMVACod = Z41FifoMVACod;
            AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
            A42FifoProdCod = Z42FifoProdCod;
            AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
            A43FifoMVADItem = Z43FifoMVADItem;
            AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FIFOALMCOD");
            AnyError = 1;
            GX_FocusControl = edtFifoAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFifoAlmCod_Internalname;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "FIFOALMCOD");
            AnyError = 1;
            GX_FocusControl = edtFifoAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtFifoMVAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFifoMVAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd033( ) ;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFifoMVAFec_Internalname;
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
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFifoMVAFec_Internalname;
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
         ScanStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound3 != 0 )
            {
               ScanNext033( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtFifoMVAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd033( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AMOVIMIENTOSFIFO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z985FifoMVAFec ) != DateTimeUtil.ResetTime ( T00032_A985FifoMVAFec[0] ) ) || ( Z980FifoMVADCant != T00032_A980FifoMVADCant[0] ) || ( Z984FifoMVADPrecio != T00032_A984FifoMVADPrecio[0] ) || ( Z983FifoMVADCosto != T00032_A983FifoMVADCosto[0] ) || ( Z981FifoMVADCantFifo != T00032_A981FifoMVADCantFifo[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z985FifoMVAFec ) != DateTimeUtil.ResetTime ( T00032_A985FifoMVAFec[0] ) )
               {
                  GXUtil.WriteLog("amovimientosfifo:[seudo value changed for attri]"+"FifoMVAFec");
                  GXUtil.WriteLogRaw("Old: ",Z985FifoMVAFec);
                  GXUtil.WriteLogRaw("Current: ",T00032_A985FifoMVAFec[0]);
               }
               if ( Z980FifoMVADCant != T00032_A980FifoMVADCant[0] )
               {
                  GXUtil.WriteLog("amovimientosfifo:[seudo value changed for attri]"+"FifoMVADCant");
                  GXUtil.WriteLogRaw("Old: ",Z980FifoMVADCant);
                  GXUtil.WriteLogRaw("Current: ",T00032_A980FifoMVADCant[0]);
               }
               if ( Z984FifoMVADPrecio != T00032_A984FifoMVADPrecio[0] )
               {
                  GXUtil.WriteLog("amovimientosfifo:[seudo value changed for attri]"+"FifoMVADPrecio");
                  GXUtil.WriteLogRaw("Old: ",Z984FifoMVADPrecio);
                  GXUtil.WriteLogRaw("Current: ",T00032_A984FifoMVADPrecio[0]);
               }
               if ( Z983FifoMVADCosto != T00032_A983FifoMVADCosto[0] )
               {
                  GXUtil.WriteLog("amovimientosfifo:[seudo value changed for attri]"+"FifoMVADCosto");
                  GXUtil.WriteLogRaw("Old: ",Z983FifoMVADCosto);
                  GXUtil.WriteLogRaw("Current: ",T00032_A983FifoMVADCosto[0]);
               }
               if ( Z981FifoMVADCantFifo != T00032_A981FifoMVADCantFifo[0] )
               {
                  GXUtil.WriteLog("amovimientosfifo:[seudo value changed for attri]"+"FifoMVADCantFifo");
                  GXUtil.WriteLogRaw("Old: ",Z981FifoMVADCantFifo);
                  GXUtil.WriteLogRaw("Current: ",T00032_A981FifoMVADCantFifo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AMOVIMIENTOSFIFO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00038 */
                     pr_default.execute(6, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem, A985FifoMVAFec, A980FifoMVADCant, A984FifoMVADPrecio, A983FifoMVADCosto, A981FifoMVADCantFifo});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
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
                           ResetCaption030( ) ;
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00039 */
                     pr_default.execute(7, new Object[] {A985FifoMVAFec, A980FifoMVADCant, A984FifoMVADPrecio, A983FifoMVADCosto, A981FifoMVADCantFifo, A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AMOVIMIENTOSFIFO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption030( ) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000310 */
                  pr_default.execute(8, new Object[] {A40FifoAlmCod, A41FifoMVACod, A42FifoProdCod, A43FifoMVADItem});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("AMOVIMIENTOSFIFO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound3 == 0 )
                        {
                           InitAll033( ) ;
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
                        ResetCaption030( ) ;
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A982FifoMVADCantSaldo = (decimal)(A980FifoMVADCant-A981FifoMVADCantFifo);
            AssignAttri("", false, "A982FifoMVADCantSaldo", StringUtil.LTrimStr( A982FifoMVADCantSaldo, 15, 4));
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("amovimientosfifo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("amovimientosfifo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Using cursor T000311 */
         pr_default.execute(9);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A40FifoAlmCod = T000311_A40FifoAlmCod[0];
            AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
            A41FifoMVACod = T000311_A41FifoMVACod[0];
            AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
            A42FifoProdCod = T000311_A42FifoProdCod[0];
            AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
            A43FifoMVADItem = T000311_A43FifoMVADItem[0];
            AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound3 = 1;
            A40FifoAlmCod = T000311_A40FifoAlmCod[0];
            AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
            A41FifoMVACod = T000311_A41FifoMVACod[0];
            AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
            A42FifoProdCod = T000311_A42FifoProdCod[0];
            AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
            A43FifoMVADItem = T000311_A43FifoMVADItem[0];
            AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtFifoAlmCod_Enabled = 0;
         AssignProp("", false, edtFifoAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoAlmCod_Enabled), 5, 0), true);
         edtFifoMVACod_Enabled = 0;
         AssignProp("", false, edtFifoMVACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVACod_Enabled), 5, 0), true);
         edtFifoMVAFec_Enabled = 0;
         AssignProp("", false, edtFifoMVAFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVAFec_Enabled), 5, 0), true);
         edtFifoProdCod_Enabled = 0;
         AssignProp("", false, edtFifoProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoProdCod_Enabled), 5, 0), true);
         edtFifoMVADItem_Enabled = 0;
         AssignProp("", false, edtFifoMVADItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVADItem_Enabled), 5, 0), true);
         edtFifoMVADCant_Enabled = 0;
         AssignProp("", false, edtFifoMVADCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVADCant_Enabled), 5, 0), true);
         edtFifoMVADPrecio_Enabled = 0;
         AssignProp("", false, edtFifoMVADPrecio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVADPrecio_Enabled), 5, 0), true);
         edtFifoMVADCosto_Enabled = 0;
         AssignProp("", false, edtFifoMVADCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVADCosto_Enabled), 5, 0), true);
         edtFifoMVADCantFifo_Enabled = 0;
         AssignProp("", false, edtFifoMVADCantFifo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVADCantFifo_Enabled), 5, 0), true);
         edtFifoMVADCantSaldo_Enabled = 0;
         AssignProp("", false, edtFifoMVADCantSaldo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFifoMVADCantSaldo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181144695", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("amovimientosfifo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z40FifoAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FifoAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41FifoMVACod", StringUtil.RTrim( Z41FifoMVACod));
         GxWebStd.gx_hidden_field( context, "Z42FifoProdCod", StringUtil.RTrim( Z42FifoProdCod));
         GxWebStd.gx_hidden_field( context, "Z43FifoMVADItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43FifoMVADItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z985FifoMVAFec", context.localUtil.DToC( Z985FifoMVAFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z980FifoMVADCant", StringUtil.LTrim( StringUtil.NToC( Z980FifoMVADCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z984FifoMVADPrecio", StringUtil.LTrim( StringUtil.NToC( Z984FifoMVADPrecio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z983FifoMVADCosto", StringUtil.LTrim( StringUtil.NToC( Z983FifoMVADCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z981FifoMVADCantFifo", StringUtil.LTrim( StringUtil.NToC( Z981FifoMVADCantFifo, 15, 4, ".", "")));
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
         return formatLink("amovimientosfifo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AMOVIMIENTOSFIFO" ;
      }

      public override string GetPgmdesc( )
      {
         return "AMOVIMIENTOSFIFO" ;
      }

      protected void InitializeNonKey033( )
      {
         A982FifoMVADCantSaldo = 0;
         AssignAttri("", false, "A982FifoMVADCantSaldo", StringUtil.LTrimStr( A982FifoMVADCantSaldo, 15, 4));
         A985FifoMVAFec = DateTime.MinValue;
         AssignAttri("", false, "A985FifoMVAFec", context.localUtil.Format(A985FifoMVAFec, "99/99/99"));
         A980FifoMVADCant = 0;
         AssignAttri("", false, "A980FifoMVADCant", StringUtil.LTrimStr( A980FifoMVADCant, 15, 4));
         A984FifoMVADPrecio = 0;
         AssignAttri("", false, "A984FifoMVADPrecio", StringUtil.LTrimStr( A984FifoMVADPrecio, 15, 4));
         A983FifoMVADCosto = 0;
         AssignAttri("", false, "A983FifoMVADCosto", StringUtil.LTrimStr( A983FifoMVADCosto, 15, 2));
         A981FifoMVADCantFifo = 0;
         AssignAttri("", false, "A981FifoMVADCantFifo", StringUtil.LTrimStr( A981FifoMVADCantFifo, 15, 4));
         Z985FifoMVAFec = DateTime.MinValue;
         Z980FifoMVADCant = 0;
         Z984FifoMVADPrecio = 0;
         Z983FifoMVADCosto = 0;
         Z981FifoMVADCantFifo = 0;
      }

      protected void InitAll033( )
      {
         A40FifoAlmCod = 0;
         AssignAttri("", false, "A40FifoAlmCod", StringUtil.LTrimStr( (decimal)(A40FifoAlmCod), 6, 0));
         A41FifoMVACod = "";
         AssignAttri("", false, "A41FifoMVACod", A41FifoMVACod);
         A42FifoProdCod = "";
         AssignAttri("", false, "A42FifoProdCod", A42FifoProdCod);
         A43FifoMVADItem = 0;
         AssignAttri("", false, "A43FifoMVADItem", StringUtil.LTrimStr( (decimal)(A43FifoMVADItem), 6, 0));
         InitializeNonKey033( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022818114472", true, true);
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
         context.AddJavascriptSource("amovimientosfifo.js", "?2022818114473", false, true);
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
         edtFifoAlmCod_Internalname = "FIFOALMCOD";
         edtFifoMVACod_Internalname = "FIFOMVACOD";
         edtFifoMVAFec_Internalname = "FIFOMVAFEC";
         edtFifoProdCod_Internalname = "FIFOPRODCOD";
         edtFifoMVADItem_Internalname = "FIFOMVADITEM";
         edtFifoMVADCant_Internalname = "FIFOMVADCANT";
         edtFifoMVADPrecio_Internalname = "FIFOMVADPRECIO";
         edtFifoMVADCosto_Internalname = "FIFOMVADCOSTO";
         edtFifoMVADCantFifo_Internalname = "FIFOMVADCANTFIFO";
         edtFifoMVADCantSaldo_Internalname = "FIFOMVADCANTSALDO";
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
         Form.Caption = "AMOVIMIENTOSFIFO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFifoMVADCantSaldo_Jsonclick = "";
         edtFifoMVADCantSaldo_Enabled = 0;
         edtFifoMVADCantFifo_Jsonclick = "";
         edtFifoMVADCantFifo_Enabled = 1;
         edtFifoMVADCosto_Jsonclick = "";
         edtFifoMVADCosto_Enabled = 1;
         edtFifoMVADPrecio_Jsonclick = "";
         edtFifoMVADPrecio_Enabled = 1;
         edtFifoMVADCant_Jsonclick = "";
         edtFifoMVADCant_Enabled = 1;
         edtFifoMVADItem_Jsonclick = "";
         edtFifoMVADItem_Enabled = 1;
         edtFifoProdCod_Jsonclick = "";
         edtFifoProdCod_Enabled = 1;
         edtFifoMVAFec_Jsonclick = "";
         edtFifoMVAFec_Enabled = 1;
         edtFifoMVACod_Jsonclick = "";
         edtFifoMVACod_Enabled = 1;
         edtFifoAlmCod_Jsonclick = "";
         edtFifoAlmCod_Enabled = 1;
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
         GX_FocusControl = edtFifoMVAFec_Internalname;
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

      public void Valid_Fifomvaditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A985FifoMVAFec", context.localUtil.Format(A985FifoMVAFec, "99/99/99"));
         AssignAttri("", false, "A980FifoMVADCant", StringUtil.LTrim( StringUtil.NToC( A980FifoMVADCant, 15, 4, ".", "")));
         AssignAttri("", false, "A984FifoMVADPrecio", StringUtil.LTrim( StringUtil.NToC( A984FifoMVADPrecio, 15, 4, ".", "")));
         AssignAttri("", false, "A983FifoMVADCosto", StringUtil.LTrim( StringUtil.NToC( A983FifoMVADCosto, 15, 2, ".", "")));
         AssignAttri("", false, "A981FifoMVADCantFifo", StringUtil.LTrim( StringUtil.NToC( A981FifoMVADCantFifo, 15, 4, ".", "")));
         AssignAttri("", false, "A982FifoMVADCantSaldo", StringUtil.LTrim( StringUtil.NToC( A982FifoMVADCantSaldo, 15, 4, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z40FifoAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z40FifoAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z41FifoMVACod", StringUtil.RTrim( Z41FifoMVACod));
         GxWebStd.gx_hidden_field( context, "Z42FifoProdCod", StringUtil.RTrim( Z42FifoProdCod));
         GxWebStd.gx_hidden_field( context, "Z43FifoMVADItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43FifoMVADItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z985FifoMVAFec", context.localUtil.Format(Z985FifoMVAFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z980FifoMVADCant", StringUtil.LTrim( StringUtil.NToC( Z980FifoMVADCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z984FifoMVADPrecio", StringUtil.LTrim( StringUtil.NToC( Z984FifoMVADPrecio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z983FifoMVADCosto", StringUtil.LTrim( StringUtil.NToC( Z983FifoMVADCosto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z981FifoMVADCantFifo", StringUtil.LTrim( StringUtil.NToC( Z981FifoMVADCantFifo, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z982FifoMVADCantSaldo", StringUtil.LTrim( StringUtil.NToC( Z982FifoMVADCantSaldo, 15, 4, ".", "")));
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
         setEventMetadata("VALID_FIFOALMCOD","{handler:'Valid_Fifoalmcod',iparms:[]");
         setEventMetadata("VALID_FIFOALMCOD",",oparms:[]}");
         setEventMetadata("VALID_FIFOMVACOD","{handler:'Valid_Fifomvacod',iparms:[]");
         setEventMetadata("VALID_FIFOMVACOD",",oparms:[]}");
         setEventMetadata("VALID_FIFOMVAFEC","{handler:'Valid_Fifomvafec',iparms:[]");
         setEventMetadata("VALID_FIFOMVAFEC",",oparms:[]}");
         setEventMetadata("VALID_FIFOPRODCOD","{handler:'Valid_Fifoprodcod',iparms:[]");
         setEventMetadata("VALID_FIFOPRODCOD",",oparms:[]}");
         setEventMetadata("VALID_FIFOMVADITEM","{handler:'Valid_Fifomvaditem',iparms:[{av:'A40FifoAlmCod',fld:'FIFOALMCOD',pic:'ZZZZZ9'},{av:'A41FifoMVACod',fld:'FIFOMVACOD',pic:''},{av:'A42FifoProdCod',fld:'FIFOPRODCOD',pic:''},{av:'A43FifoMVADItem',fld:'FIFOMVADITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_FIFOMVADITEM",",oparms:[{av:'A985FifoMVAFec',fld:'FIFOMVAFEC',pic:''},{av:'A980FifoMVADCant',fld:'FIFOMVADCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A984FifoMVADPrecio',fld:'FIFOMVADPRECIO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A983FifoMVADCosto',fld:'FIFOMVADCOSTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A981FifoMVADCantFifo',fld:'FIFOMVADCANTFIFO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A982FifoMVADCantSaldo',fld:'FIFOMVADCANTSALDO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z40FifoAlmCod'},{av:'Z41FifoMVACod'},{av:'Z42FifoProdCod'},{av:'Z43FifoMVADItem'},{av:'Z985FifoMVAFec'},{av:'Z980FifoMVADCant'},{av:'Z984FifoMVADPrecio'},{av:'Z983FifoMVADCosto'},{av:'Z981FifoMVADCantFifo'},{av:'Z982FifoMVADCantSaldo'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_FIFOMVADCANT","{handler:'Valid_Fifomvadcant',iparms:[]");
         setEventMetadata("VALID_FIFOMVADCANT",",oparms:[]}");
         setEventMetadata("VALID_FIFOMVADCANTFIFO","{handler:'Valid_Fifomvadcantfifo',iparms:[]");
         setEventMetadata("VALID_FIFOMVADCANTFIFO",",oparms:[]}");
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
         Z41FifoMVACod = "";
         Z42FifoProdCod = "";
         Z985FifoMVAFec = DateTime.MinValue;
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
         A41FifoMVACod = "";
         A985FifoMVAFec = DateTime.MinValue;
         A42FifoProdCod = "";
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
         T00034_A40FifoAlmCod = new int[1] ;
         T00034_A41FifoMVACod = new string[] {""} ;
         T00034_A42FifoProdCod = new string[] {""} ;
         T00034_A43FifoMVADItem = new int[1] ;
         T00034_A985FifoMVAFec = new DateTime[] {DateTime.MinValue} ;
         T00034_A980FifoMVADCant = new decimal[1] ;
         T00034_A984FifoMVADPrecio = new decimal[1] ;
         T00034_A983FifoMVADCosto = new decimal[1] ;
         T00034_A981FifoMVADCantFifo = new decimal[1] ;
         T00035_A40FifoAlmCod = new int[1] ;
         T00035_A41FifoMVACod = new string[] {""} ;
         T00035_A42FifoProdCod = new string[] {""} ;
         T00035_A43FifoMVADItem = new int[1] ;
         T00033_A40FifoAlmCod = new int[1] ;
         T00033_A41FifoMVACod = new string[] {""} ;
         T00033_A42FifoProdCod = new string[] {""} ;
         T00033_A43FifoMVADItem = new int[1] ;
         T00033_A985FifoMVAFec = new DateTime[] {DateTime.MinValue} ;
         T00033_A980FifoMVADCant = new decimal[1] ;
         T00033_A984FifoMVADPrecio = new decimal[1] ;
         T00033_A983FifoMVADCosto = new decimal[1] ;
         T00033_A981FifoMVADCantFifo = new decimal[1] ;
         sMode3 = "";
         T00036_A40FifoAlmCod = new int[1] ;
         T00036_A41FifoMVACod = new string[] {""} ;
         T00036_A42FifoProdCod = new string[] {""} ;
         T00036_A43FifoMVADItem = new int[1] ;
         T00037_A40FifoAlmCod = new int[1] ;
         T00037_A41FifoMVACod = new string[] {""} ;
         T00037_A42FifoProdCod = new string[] {""} ;
         T00037_A43FifoMVADItem = new int[1] ;
         T00032_A40FifoAlmCod = new int[1] ;
         T00032_A41FifoMVACod = new string[] {""} ;
         T00032_A42FifoProdCod = new string[] {""} ;
         T00032_A43FifoMVADItem = new int[1] ;
         T00032_A985FifoMVAFec = new DateTime[] {DateTime.MinValue} ;
         T00032_A980FifoMVADCant = new decimal[1] ;
         T00032_A984FifoMVADPrecio = new decimal[1] ;
         T00032_A983FifoMVADCosto = new decimal[1] ;
         T00032_A981FifoMVADCantFifo = new decimal[1] ;
         T000311_A40FifoAlmCod = new int[1] ;
         T000311_A41FifoMVACod = new string[] {""} ;
         T000311_A42FifoProdCod = new string[] {""} ;
         T000311_A43FifoMVADItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ41FifoMVACod = "";
         ZZ42FifoProdCod = "";
         ZZ985FifoMVAFec = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.amovimientosfifo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amovimientosfifo__default(),
            new Object[][] {
                new Object[] {
               T00032_A40FifoAlmCod, T00032_A41FifoMVACod, T00032_A42FifoProdCod, T00032_A43FifoMVADItem, T00032_A985FifoMVAFec, T00032_A980FifoMVADCant, T00032_A984FifoMVADPrecio, T00032_A983FifoMVADCosto, T00032_A981FifoMVADCantFifo
               }
               , new Object[] {
               T00033_A40FifoAlmCod, T00033_A41FifoMVACod, T00033_A42FifoProdCod, T00033_A43FifoMVADItem, T00033_A985FifoMVAFec, T00033_A980FifoMVADCant, T00033_A984FifoMVADPrecio, T00033_A983FifoMVADCosto, T00033_A981FifoMVADCantFifo
               }
               , new Object[] {
               T00034_A40FifoAlmCod, T00034_A41FifoMVACod, T00034_A42FifoProdCod, T00034_A43FifoMVADItem, T00034_A985FifoMVAFec, T00034_A980FifoMVADCant, T00034_A984FifoMVADPrecio, T00034_A983FifoMVADCosto, T00034_A981FifoMVADCantFifo
               }
               , new Object[] {
               T00035_A40FifoAlmCod, T00035_A41FifoMVACod, T00035_A42FifoProdCod, T00035_A43FifoMVADItem
               }
               , new Object[] {
               T00036_A40FifoAlmCod, T00036_A41FifoMVACod, T00036_A42FifoProdCod, T00036_A43FifoMVADItem
               }
               , new Object[] {
               T00037_A40FifoAlmCod, T00037_A41FifoMVACod, T00037_A42FifoProdCod, T00037_A43FifoMVADItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000311_A40FifoAlmCod, T000311_A41FifoMVACod, T000311_A42FifoProdCod, T000311_A43FifoMVADItem
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
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z40FifoAlmCod ;
      private int Z43FifoMVADItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A40FifoAlmCod ;
      private int edtFifoAlmCod_Enabled ;
      private int edtFifoMVACod_Enabled ;
      private int edtFifoMVAFec_Enabled ;
      private int edtFifoProdCod_Enabled ;
      private int A43FifoMVADItem ;
      private int edtFifoMVADItem_Enabled ;
      private int edtFifoMVADCant_Enabled ;
      private int edtFifoMVADPrecio_Enabled ;
      private int edtFifoMVADCosto_Enabled ;
      private int edtFifoMVADCantFifo_Enabled ;
      private int edtFifoMVADCantSaldo_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ40FifoAlmCod ;
      private int ZZ43FifoMVADItem ;
      private decimal Z980FifoMVADCant ;
      private decimal Z984FifoMVADPrecio ;
      private decimal Z983FifoMVADCosto ;
      private decimal Z981FifoMVADCantFifo ;
      private decimal A980FifoMVADCant ;
      private decimal A984FifoMVADPrecio ;
      private decimal A983FifoMVADCosto ;
      private decimal A981FifoMVADCantFifo ;
      private decimal A982FifoMVADCantSaldo ;
      private decimal Z982FifoMVADCantSaldo ;
      private decimal ZZ980FifoMVADCant ;
      private decimal ZZ984FifoMVADPrecio ;
      private decimal ZZ983FifoMVADCosto ;
      private decimal ZZ981FifoMVADCantFifo ;
      private decimal ZZ982FifoMVADCantSaldo ;
      private string sPrefix ;
      private string Z41FifoMVACod ;
      private string Z42FifoProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFifoAlmCod_Internalname ;
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
      private string edtFifoAlmCod_Jsonclick ;
      private string edtFifoMVACod_Internalname ;
      private string A41FifoMVACod ;
      private string edtFifoMVACod_Jsonclick ;
      private string edtFifoMVAFec_Internalname ;
      private string edtFifoMVAFec_Jsonclick ;
      private string edtFifoProdCod_Internalname ;
      private string A42FifoProdCod ;
      private string edtFifoProdCod_Jsonclick ;
      private string edtFifoMVADItem_Internalname ;
      private string edtFifoMVADItem_Jsonclick ;
      private string edtFifoMVADCant_Internalname ;
      private string edtFifoMVADCant_Jsonclick ;
      private string edtFifoMVADPrecio_Internalname ;
      private string edtFifoMVADPrecio_Jsonclick ;
      private string edtFifoMVADCosto_Internalname ;
      private string edtFifoMVADCosto_Jsonclick ;
      private string edtFifoMVADCantFifo_Internalname ;
      private string edtFifoMVADCantFifo_Jsonclick ;
      private string edtFifoMVADCantSaldo_Internalname ;
      private string edtFifoMVADCantSaldo_Jsonclick ;
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
      private string sMode3 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ41FifoMVACod ;
      private string ZZ42FifoProdCod ;
      private DateTime Z985FifoMVAFec ;
      private DateTime A985FifoMVAFec ;
      private DateTime ZZ985FifoMVAFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00034_A40FifoAlmCod ;
      private string[] T00034_A41FifoMVACod ;
      private string[] T00034_A42FifoProdCod ;
      private int[] T00034_A43FifoMVADItem ;
      private DateTime[] T00034_A985FifoMVAFec ;
      private decimal[] T00034_A980FifoMVADCant ;
      private decimal[] T00034_A984FifoMVADPrecio ;
      private decimal[] T00034_A983FifoMVADCosto ;
      private decimal[] T00034_A981FifoMVADCantFifo ;
      private int[] T00035_A40FifoAlmCod ;
      private string[] T00035_A41FifoMVACod ;
      private string[] T00035_A42FifoProdCod ;
      private int[] T00035_A43FifoMVADItem ;
      private int[] T00033_A40FifoAlmCod ;
      private string[] T00033_A41FifoMVACod ;
      private string[] T00033_A42FifoProdCod ;
      private int[] T00033_A43FifoMVADItem ;
      private DateTime[] T00033_A985FifoMVAFec ;
      private decimal[] T00033_A980FifoMVADCant ;
      private decimal[] T00033_A984FifoMVADPrecio ;
      private decimal[] T00033_A983FifoMVADCosto ;
      private decimal[] T00033_A981FifoMVADCantFifo ;
      private int[] T00036_A40FifoAlmCod ;
      private string[] T00036_A41FifoMVACod ;
      private string[] T00036_A42FifoProdCod ;
      private int[] T00036_A43FifoMVADItem ;
      private int[] T00037_A40FifoAlmCod ;
      private string[] T00037_A41FifoMVACod ;
      private string[] T00037_A42FifoProdCod ;
      private int[] T00037_A43FifoMVADItem ;
      private int[] T00032_A40FifoAlmCod ;
      private string[] T00032_A41FifoMVACod ;
      private string[] T00032_A42FifoProdCod ;
      private int[] T00032_A43FifoMVADItem ;
      private DateTime[] T00032_A985FifoMVAFec ;
      private decimal[] T00032_A980FifoMVADCant ;
      private decimal[] T00032_A984FifoMVADPrecio ;
      private decimal[] T00032_A983FifoMVADCosto ;
      private decimal[] T00032_A981FifoMVADCantFifo ;
      private int[] T000311_A40FifoAlmCod ;
      private string[] T000311_A41FifoMVACod ;
      private string[] T000311_A42FifoProdCod ;
      private int[] T000311_A43FifoMVADItem ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class amovimientosfifo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class amovimientosfifo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00034;
        prmT00034 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT00035;
        prmT00035 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT00033;
        prmT00033 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT00036;
        prmT00036 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT00037;
        prmT00037 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT00032;
        prmT00032 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT00038;
        prmT00038 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0) ,
        new ParDef("@FifoMVAFec",GXType.Date,8,0) ,
        new ParDef("@FifoMVADCant",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADPrecio",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADCosto",GXType.Decimal,15,2) ,
        new ParDef("@FifoMVADCantFifo",GXType.Decimal,15,4)
        };
        Object[] prmT00039;
        prmT00039 = new Object[] {
        new ParDef("@FifoMVAFec",GXType.Date,8,0) ,
        new ParDef("@FifoMVADCant",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADPrecio",GXType.Decimal,15,4) ,
        new ParDef("@FifoMVADCosto",GXType.Decimal,15,2) ,
        new ParDef("@FifoMVADCantFifo",GXType.Decimal,15,4) ,
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT000310;
        prmT000310 = new Object[] {
        new ParDef("@FifoAlmCod",GXType.Int32,6,0) ,
        new ParDef("@FifoMVACod",GXType.NChar,12,0) ,
        new ParDef("@FifoProdCod",GXType.NChar,15,0) ,
        new ParDef("@FifoMVADItem",GXType.Int32,6,0)
        };
        Object[] prmT000311;
        prmT000311 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00032", "SELECT [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem], [FifoMVAFec], [FifoMVADCant], [FifoMVADPrecio], [FifoMVADCosto], [FifoMVADCantFifo] FROM [AMOVIMIENTOSFIFO] WITH (UPDLOCK) WHERE [FifoAlmCod] = @FifoAlmCod AND [FifoMVACod] = @FifoMVACod AND [FifoProdCod] = @FifoProdCod AND [FifoMVADItem] = @FifoMVADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00033", "SELECT [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem], [FifoMVAFec], [FifoMVADCant], [FifoMVADPrecio], [FifoMVADCosto], [FifoMVADCantFifo] FROM [AMOVIMIENTOSFIFO] WHERE [FifoAlmCod] = @FifoAlmCod AND [FifoMVACod] = @FifoMVACod AND [FifoProdCod] = @FifoProdCod AND [FifoMVADItem] = @FifoMVADItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00034", "SELECT TM1.[FifoAlmCod], TM1.[FifoMVACod], TM1.[FifoProdCod], TM1.[FifoMVADItem], TM1.[FifoMVAFec], TM1.[FifoMVADCant], TM1.[FifoMVADPrecio], TM1.[FifoMVADCosto], TM1.[FifoMVADCantFifo] FROM [AMOVIMIENTOSFIFO] TM1 WHERE TM1.[FifoAlmCod] = @FifoAlmCod and TM1.[FifoMVACod] = @FifoMVACod and TM1.[FifoProdCod] = @FifoProdCod and TM1.[FifoMVADItem] = @FifoMVADItem ORDER BY TM1.[FifoAlmCod], TM1.[FifoMVACod], TM1.[FifoProdCod], TM1.[FifoMVADItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00035", "SELECT [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem] FROM [AMOVIMIENTOSFIFO] WHERE [FifoAlmCod] = @FifoAlmCod AND [FifoMVACod] = @FifoMVACod AND [FifoProdCod] = @FifoProdCod AND [FifoMVADItem] = @FifoMVADItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00036", "SELECT TOP 1 [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem] FROM [AMOVIMIENTOSFIFO] WHERE ( [FifoAlmCod] > @FifoAlmCod or [FifoAlmCod] = @FifoAlmCod and [FifoMVACod] > @FifoMVACod or [FifoMVACod] = @FifoMVACod and [FifoAlmCod] = @FifoAlmCod and [FifoProdCod] > @FifoProdCod or [FifoProdCod] = @FifoProdCod and [FifoMVACod] = @FifoMVACod and [FifoAlmCod] = @FifoAlmCod and [FifoMVADItem] > @FifoMVADItem) ORDER BY [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00037", "SELECT TOP 1 [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem] FROM [AMOVIMIENTOSFIFO] WHERE ( [FifoAlmCod] < @FifoAlmCod or [FifoAlmCod] = @FifoAlmCod and [FifoMVACod] < @FifoMVACod or [FifoMVACod] = @FifoMVACod and [FifoAlmCod] = @FifoAlmCod and [FifoProdCod] < @FifoProdCod or [FifoProdCod] = @FifoProdCod and [FifoMVACod] = @FifoMVACod and [FifoAlmCod] = @FifoAlmCod and [FifoMVADItem] < @FifoMVADItem) ORDER BY [FifoAlmCod] DESC, [FifoMVACod] DESC, [FifoProdCod] DESC, [FifoMVADItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00038", "INSERT INTO [AMOVIMIENTOSFIFO]([FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem], [FifoMVAFec], [FifoMVADCant], [FifoMVADPrecio], [FifoMVADCosto], [FifoMVADCantFifo]) VALUES(@FifoAlmCod, @FifoMVACod, @FifoProdCod, @FifoMVADItem, @FifoMVAFec, @FifoMVADCant, @FifoMVADPrecio, @FifoMVADCosto, @FifoMVADCantFifo)", GxErrorMask.GX_NOMASK,prmT00038)
           ,new CursorDef("T00039", "UPDATE [AMOVIMIENTOSFIFO] SET [FifoMVAFec]=@FifoMVAFec, [FifoMVADCant]=@FifoMVADCant, [FifoMVADPrecio]=@FifoMVADPrecio, [FifoMVADCosto]=@FifoMVADCosto, [FifoMVADCantFifo]=@FifoMVADCantFifo  WHERE [FifoAlmCod] = @FifoAlmCod AND [FifoMVACod] = @FifoMVACod AND [FifoProdCod] = @FifoProdCod AND [FifoMVADItem] = @FifoMVADItem", GxErrorMask.GX_NOMASK,prmT00039)
           ,new CursorDef("T000310", "DELETE FROM [AMOVIMIENTOSFIFO]  WHERE [FifoAlmCod] = @FifoAlmCod AND [FifoMVACod] = @FifoMVACod AND [FifoProdCod] = @FifoProdCod AND [FifoMVADItem] = @FifoMVADItem", GxErrorMask.GX_NOMASK,prmT000310)
           ,new CursorDef("T000311", "SELECT [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem] FROM [AMOVIMIENTOSFIFO] ORDER BY [FifoAlmCod], [FifoMVACod], [FifoProdCod], [FifoMVADItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000311,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
     }
  }

}

}
