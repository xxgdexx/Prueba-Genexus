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
   public class aguiastemporal : GXDataArea
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
            Form.Meta.addItem("description", "Guias Lotes Temporal", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTmpUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aguiastemporal( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aguiastemporal( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Guias Lotes Temporal", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_AGUIASTEMPORAL.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AGUIASTEMPORAL.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpUsuCod_Internalname, A32TmpUsuCod, StringUtil.RTrim( context.localUtil.Format( A32TmpUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpMVATip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpMVATip_Internalname, "G", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpMVATip_Internalname, A33TmpMVATip, StringUtil.RTrim( context.localUtil.Format( A33TmpMVATip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpMVATip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpMVATip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A34TmpItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtTmpItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A34TmpItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A34TmpItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpProdCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpProdCod_Internalname, "Producto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpProdCod_Internalname, A35TmpProdCod, StringUtil.RTrim( context.localUtil.Format( A35TmpProdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpCantidad_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpCantidad_Internalname, "Cantidad", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpCantidad_Internalname, StringUtil.LTrim( StringUtil.NToC( A1922TmpCantidad, 17, 4, ".", "")), StringUtil.LTrim( ((edtTmpCantidad_Enabled!=0) ? context.localUtil.Format( A1922TmpCantidad, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1922TmpCantidad, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpCantidad_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpCantidad_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpRef1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpRef1_Internalname, "1", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpRef1_Internalname, A36TmpRef1, StringUtil.RTrim( context.localUtil.Format( A36TmpRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpRef2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpRef2_Internalname, "2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpRef2_Internalname, A1923TmpRef2, StringUtil.RTrim( context.localUtil.Format( A1923TmpRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpRef3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpRef3_Internalname, "3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpRef3_Internalname, A1924TmpRef3, StringUtil.RTrim( context.localUtil.Format( A1924TmpRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpRef4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpRef4_Internalname, "4", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpRef4_Internalname, A1925TmpRef4, StringUtil.RTrim( context.localUtil.Format( A1925TmpRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTmpRef5_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTmpRef5_Internalname, "5", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTmpRef5_Internalname, A1926TmpRef5, StringUtil.RTrim( context.localUtil.Format( A1926TmpRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTmpRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTmpRef5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIASTEMPORAL.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASTEMPORAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIASTEMPORAL.htm");
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
            Z32TmpUsuCod = cgiGet( "Z32TmpUsuCod");
            Z33TmpMVATip = cgiGet( "Z33TmpMVATip");
            Z34TmpItem = (int)(context.localUtil.CToN( cgiGet( "Z34TmpItem"), ".", ","));
            Z35TmpProdCod = cgiGet( "Z35TmpProdCod");
            Z36TmpRef1 = cgiGet( "Z36TmpRef1");
            Z1922TmpCantidad = context.localUtil.CToN( cgiGet( "Z1922TmpCantidad"), ".", ",");
            Z1923TmpRef2 = cgiGet( "Z1923TmpRef2");
            Z1924TmpRef3 = cgiGet( "Z1924TmpRef3");
            Z1925TmpRef4 = cgiGet( "Z1925TmpRef4");
            Z1926TmpRef5 = cgiGet( "Z1926TmpRef5");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A32TmpUsuCod = cgiGet( edtTmpUsuCod_Internalname);
            AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
            A33TmpMVATip = cgiGet( edtTmpMVATip_Internalname);
            AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTmpItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTmpItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TMPITEM");
               AnyError = 1;
               GX_FocusControl = edtTmpItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A34TmpItem = 0;
               AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
            }
            else
            {
               A34TmpItem = (int)(context.localUtil.CToN( cgiGet( edtTmpItem_Internalname), ".", ","));
               AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
            }
            A35TmpProdCod = cgiGet( edtTmpProdCod_Internalname);
            AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTmpCantidad_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTmpCantidad_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TMPCANTIDAD");
               AnyError = 1;
               GX_FocusControl = edtTmpCantidad_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1922TmpCantidad = 0;
               AssignAttri("", false, "A1922TmpCantidad", StringUtil.LTrimStr( A1922TmpCantidad, 15, 4));
            }
            else
            {
               A1922TmpCantidad = context.localUtil.CToN( cgiGet( edtTmpCantidad_Internalname), ".", ",");
               AssignAttri("", false, "A1922TmpCantidad", StringUtil.LTrimStr( A1922TmpCantidad, 15, 4));
            }
            A36TmpRef1 = cgiGet( edtTmpRef1_Internalname);
            AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
            A1923TmpRef2 = cgiGet( edtTmpRef2_Internalname);
            AssignAttri("", false, "A1923TmpRef2", A1923TmpRef2);
            A1924TmpRef3 = cgiGet( edtTmpRef3_Internalname);
            AssignAttri("", false, "A1924TmpRef3", A1924TmpRef3);
            A1925TmpRef4 = cgiGet( edtTmpRef4_Internalname);
            AssignAttri("", false, "A1925TmpRef4", A1925TmpRef4);
            A1926TmpRef5 = cgiGet( edtTmpRef5_Internalname);
            AssignAttri("", false, "A1926TmpRef5", A1926TmpRef5);
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
               A32TmpUsuCod = GetPar( "TmpUsuCod");
               AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
               A33TmpMVATip = GetPar( "TmpMVATip");
               AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
               A34TmpItem = (int)(NumberUtil.Val( GetPar( "TmpItem"), "."));
               AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
               A35TmpProdCod = GetPar( "TmpProdCod");
               AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
               A36TmpRef1 = GetPar( "TmpRef1");
               AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
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
               InitAll022( ) ;
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
         DisableAttributes022( ) ;
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

      protected void ResetCaption020( )
      {
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1922TmpCantidad = T00023_A1922TmpCantidad[0];
               Z1923TmpRef2 = T00023_A1923TmpRef2[0];
               Z1924TmpRef3 = T00023_A1924TmpRef3[0];
               Z1925TmpRef4 = T00023_A1925TmpRef4[0];
               Z1926TmpRef5 = T00023_A1926TmpRef5[0];
            }
            else
            {
               Z1922TmpCantidad = A1922TmpCantidad;
               Z1923TmpRef2 = A1923TmpRef2;
               Z1924TmpRef3 = A1924TmpRef3;
               Z1925TmpRef4 = A1925TmpRef4;
               Z1926TmpRef5 = A1926TmpRef5;
            }
         }
         if ( GX_JID == -1 )
         {
            Z32TmpUsuCod = A32TmpUsuCod;
            Z33TmpMVATip = A33TmpMVATip;
            Z34TmpItem = A34TmpItem;
            Z35TmpProdCod = A35TmpProdCod;
            Z36TmpRef1 = A36TmpRef1;
            Z1922TmpCantidad = A1922TmpCantidad;
            Z1923TmpRef2 = A1923TmpRef2;
            Z1924TmpRef3 = A1924TmpRef3;
            Z1925TmpRef4 = A1925TmpRef4;
            Z1926TmpRef5 = A1926TmpRef5;
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

      protected void Load022( )
      {
         /* Using cursor T00024 */
         pr_default.execute(2, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound2 = 1;
            A1922TmpCantidad = T00024_A1922TmpCantidad[0];
            AssignAttri("", false, "A1922TmpCantidad", StringUtil.LTrimStr( A1922TmpCantidad, 15, 4));
            A1923TmpRef2 = T00024_A1923TmpRef2[0];
            AssignAttri("", false, "A1923TmpRef2", A1923TmpRef2);
            A1924TmpRef3 = T00024_A1924TmpRef3[0];
            AssignAttri("", false, "A1924TmpRef3", A1924TmpRef3);
            A1925TmpRef4 = T00024_A1925TmpRef4[0];
            AssignAttri("", false, "A1925TmpRef4", A1925TmpRef4);
            A1926TmpRef5 = T00024_A1926TmpRef5[0];
            AssignAttri("", false, "A1926TmpRef5", A1926TmpRef5);
            ZM022( -1) ;
         }
         pr_default.close(2);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors022( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor T00025 */
         pr_default.execute(3, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00023 */
         pr_default.execute(1, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 1) ;
            RcdFound2 = 1;
            A32TmpUsuCod = T00023_A32TmpUsuCod[0];
            AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
            A33TmpMVATip = T00023_A33TmpMVATip[0];
            AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
            A34TmpItem = T00023_A34TmpItem[0];
            AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
            A35TmpProdCod = T00023_A35TmpProdCod[0];
            AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
            A36TmpRef1 = T00023_A36TmpRef1[0];
            AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
            A1922TmpCantidad = T00023_A1922TmpCantidad[0];
            AssignAttri("", false, "A1922TmpCantidad", StringUtil.LTrimStr( A1922TmpCantidad, 15, 4));
            A1923TmpRef2 = T00023_A1923TmpRef2[0];
            AssignAttri("", false, "A1923TmpRef2", A1923TmpRef2);
            A1924TmpRef3 = T00023_A1924TmpRef3[0];
            AssignAttri("", false, "A1924TmpRef3", A1924TmpRef3);
            A1925TmpRef4 = T00023_A1925TmpRef4[0];
            AssignAttri("", false, "A1925TmpRef4", A1925TmpRef4);
            A1926TmpRef5 = T00023_A1926TmpRef5[0];
            AssignAttri("", false, "A1926TmpRef5", A1926TmpRef5);
            Z32TmpUsuCod = A32TmpUsuCod;
            Z33TmpMVATip = A33TmpMVATip;
            Z34TmpItem = A34TmpItem;
            Z35TmpProdCod = A35TmpProdCod;
            Z36TmpRef1 = A36TmpRef1;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode2;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         RcdFound2 = 0;
         /* Using cursor T00026 */
         pr_default.execute(4, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) < 0 ) || ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) < 0 ) || ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( T00026_A34TmpItem[0] < A34TmpItem ) || ( T00026_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00026_A35TmpProdCod[0], A35TmpProdCod) < 0 ) || ( StringUtil.StrCmp(T00026_A35TmpProdCod[0], A35TmpProdCod) == 0 ) && ( T00026_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00026_A36TmpRef1[0], A36TmpRef1) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) > 0 ) || ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) > 0 ) || ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( T00026_A34TmpItem[0] > A34TmpItem ) || ( T00026_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00026_A35TmpProdCod[0], A35TmpProdCod) > 0 ) || ( StringUtil.StrCmp(T00026_A35TmpProdCod[0], A35TmpProdCod) == 0 ) && ( T00026_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00026_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00026_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00026_A36TmpRef1[0], A36TmpRef1) > 0 ) ) )
            {
               A32TmpUsuCod = T00026_A32TmpUsuCod[0];
               AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
               A33TmpMVATip = T00026_A33TmpMVATip[0];
               AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
               A34TmpItem = T00026_A34TmpItem[0];
               AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
               A35TmpProdCod = T00026_A35TmpProdCod[0];
               AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
               A36TmpRef1 = T00026_A36TmpRef1[0];
               AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
               RcdFound2 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound2 = 0;
         /* Using cursor T00027 */
         pr_default.execute(5, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) > 0 ) || ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) > 0 ) || ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( T00027_A34TmpItem[0] > A34TmpItem ) || ( T00027_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00027_A35TmpProdCod[0], A35TmpProdCod) > 0 ) || ( StringUtil.StrCmp(T00027_A35TmpProdCod[0], A35TmpProdCod) == 0 ) && ( T00027_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00027_A36TmpRef1[0], A36TmpRef1) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) < 0 ) || ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) < 0 ) || ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( T00027_A34TmpItem[0] < A34TmpItem ) || ( T00027_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00027_A35TmpProdCod[0], A35TmpProdCod) < 0 ) || ( StringUtil.StrCmp(T00027_A35TmpProdCod[0], A35TmpProdCod) == 0 ) && ( T00027_A34TmpItem[0] == A34TmpItem ) && ( StringUtil.StrCmp(T00027_A33TmpMVATip[0], A33TmpMVATip) == 0 ) && ( StringUtil.StrCmp(T00027_A32TmpUsuCod[0], A32TmpUsuCod) == 0 ) && ( StringUtil.StrCmp(T00027_A36TmpRef1[0], A36TmpRef1) < 0 ) ) )
            {
               A32TmpUsuCod = T00027_A32TmpUsuCod[0];
               AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
               A33TmpMVATip = T00027_A33TmpMVATip[0];
               AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
               A34TmpItem = T00027_A34TmpItem[0];
               AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
               A35TmpProdCod = T00027_A35TmpProdCod[0];
               AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
               A36TmpRef1 = T00027_A36TmpRef1[0];
               AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
               RcdFound2 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTmpUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert022( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( ( StringUtil.StrCmp(A32TmpUsuCod, Z32TmpUsuCod) != 0 ) || ( StringUtil.StrCmp(A33TmpMVATip, Z33TmpMVATip) != 0 ) || ( A34TmpItem != Z34TmpItem ) || ( StringUtil.StrCmp(A35TmpProdCod, Z35TmpProdCod) != 0 ) || ( StringUtil.StrCmp(A36TmpRef1, Z36TmpRef1) != 0 ) )
               {
                  A32TmpUsuCod = Z32TmpUsuCod;
                  AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
                  A33TmpMVATip = Z33TmpMVATip;
                  AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
                  A34TmpItem = Z34TmpItem;
                  AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
                  A35TmpProdCod = Z35TmpProdCod;
                  AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
                  A36TmpRef1 = Z36TmpRef1;
                  AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TMPUSUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTmpUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTmpUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update022( ) ;
                  GX_FocusControl = edtTmpUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A32TmpUsuCod, Z32TmpUsuCod) != 0 ) || ( StringUtil.StrCmp(A33TmpMVATip, Z33TmpMVATip) != 0 ) || ( A34TmpItem != Z34TmpItem ) || ( StringUtil.StrCmp(A35TmpProdCod, Z35TmpProdCod) != 0 ) || ( StringUtil.StrCmp(A36TmpRef1, Z36TmpRef1) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTmpUsuCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert022( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TMPUSUCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTmpUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTmpUsuCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert022( ) ;
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
         if ( ( StringUtil.StrCmp(A32TmpUsuCod, Z32TmpUsuCod) != 0 ) || ( StringUtil.StrCmp(A33TmpMVATip, Z33TmpMVATip) != 0 ) || ( A34TmpItem != Z34TmpItem ) || ( StringUtil.StrCmp(A35TmpProdCod, Z35TmpProdCod) != 0 ) || ( StringUtil.StrCmp(A36TmpRef1, Z36TmpRef1) != 0 ) )
         {
            A32TmpUsuCod = Z32TmpUsuCod;
            AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
            A33TmpMVATip = Z33TmpMVATip;
            AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
            A34TmpItem = Z34TmpItem;
            AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
            A35TmpProdCod = Z35TmpProdCod;
            AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
            A36TmpRef1 = Z36TmpRef1;
            AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TMPUSUCOD");
            AnyError = 1;
            GX_FocusControl = edtTmpUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTmpUsuCod_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TMPUSUCOD");
            AnyError = 1;
            GX_FocusControl = edtTmpUsuCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTmpCantidad_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTmpCantidad_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTmpCantidad_Internalname;
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
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTmpCantidad_Internalname;
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
         ScanStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound2 != 0 )
            {
               ScanNext022( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTmpCantidad_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd022( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00022 */
            pr_default.execute(0, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASTEMPORAL"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1922TmpCantidad != T00022_A1922TmpCantidad[0] ) || ( StringUtil.StrCmp(Z1923TmpRef2, T00022_A1923TmpRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1924TmpRef3, T00022_A1924TmpRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1925TmpRef4, T00022_A1925TmpRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z1926TmpRef5, T00022_A1926TmpRef5[0]) != 0 ) )
            {
               if ( Z1922TmpCantidad != T00022_A1922TmpCantidad[0] )
               {
                  GXUtil.WriteLog("aguiastemporal:[seudo value changed for attri]"+"TmpCantidad");
                  GXUtil.WriteLogRaw("Old: ",Z1922TmpCantidad);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1922TmpCantidad[0]);
               }
               if ( StringUtil.StrCmp(Z1923TmpRef2, T00022_A1923TmpRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiastemporal:[seudo value changed for attri]"+"TmpRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1923TmpRef2);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1923TmpRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1924TmpRef3, T00022_A1924TmpRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiastemporal:[seudo value changed for attri]"+"TmpRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1924TmpRef3);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1924TmpRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1925TmpRef4, T00022_A1925TmpRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiastemporal:[seudo value changed for attri]"+"TmpRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1925TmpRef4);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1925TmpRef4[0]);
               }
               if ( StringUtil.StrCmp(Z1926TmpRef5, T00022_A1926TmpRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("aguiastemporal:[seudo value changed for attri]"+"TmpRef5");
                  GXUtil.WriteLogRaw("Old: ",Z1926TmpRef5);
                  GXUtil.WriteLogRaw("Current: ",T00022_A1926TmpRef5[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AGUIASTEMPORAL"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00028 */
                     pr_default.execute(6, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1, A1922TmpCantidad, A1923TmpRef2, A1924TmpRef3, A1925TmpRef4, A1926TmpRef5});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASTEMPORAL");
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
                           ResetCaption020( ) ;
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00029 */
                     pr_default.execute(7, new Object[] {A1922TmpCantidad, A1923TmpRef2, A1924TmpRef3, A1925TmpRef4, A1926TmpRef5, A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIASTEMPORAL");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIASTEMPORAL"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption020( ) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000210 */
                  pr_default.execute(8, new Object[] {A32TmpUsuCod, A33TmpMVATip, A34TmpItem, A35TmpProdCod, A36TmpRef1});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("AGUIASTEMPORAL");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound2 == 0 )
                        {
                           InitAll022( ) ;
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
                        ResetCaption020( ) ;
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel022( ) ;
         Gx_mode = sMode2;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("aguiastemporal",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues020( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("aguiastemporal",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart022( )
      {
         /* Using cursor T000211 */
         pr_default.execute(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A32TmpUsuCod = T000211_A32TmpUsuCod[0];
            AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
            A33TmpMVATip = T000211_A33TmpMVATip[0];
            AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
            A34TmpItem = T000211_A34TmpItem[0];
            AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
            A35TmpProdCod = T000211_A35TmpProdCod[0];
            AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
            A36TmpRef1 = T000211_A36TmpRef1[0];
            AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound2 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound2 = 1;
            A32TmpUsuCod = T000211_A32TmpUsuCod[0];
            AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
            A33TmpMVATip = T000211_A33TmpMVATip[0];
            AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
            A34TmpItem = T000211_A34TmpItem[0];
            AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
            A35TmpProdCod = T000211_A35TmpProdCod[0];
            AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
            A36TmpRef1 = T000211_A36TmpRef1[0];
            AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
         }
      }

      protected void ScanEnd022( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
         edtTmpUsuCod_Enabled = 0;
         AssignProp("", false, edtTmpUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpUsuCod_Enabled), 5, 0), true);
         edtTmpMVATip_Enabled = 0;
         AssignProp("", false, edtTmpMVATip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpMVATip_Enabled), 5, 0), true);
         edtTmpItem_Enabled = 0;
         AssignProp("", false, edtTmpItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpItem_Enabled), 5, 0), true);
         edtTmpProdCod_Enabled = 0;
         AssignProp("", false, edtTmpProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpProdCod_Enabled), 5, 0), true);
         edtTmpCantidad_Enabled = 0;
         AssignProp("", false, edtTmpCantidad_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpCantidad_Enabled), 5, 0), true);
         edtTmpRef1_Enabled = 0;
         AssignProp("", false, edtTmpRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpRef1_Enabled), 5, 0), true);
         edtTmpRef2_Enabled = 0;
         AssignProp("", false, edtTmpRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpRef2_Enabled), 5, 0), true);
         edtTmpRef3_Enabled = 0;
         AssignProp("", false, edtTmpRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpRef3_Enabled), 5, 0), true);
         edtTmpRef4_Enabled = 0;
         AssignProp("", false, edtTmpRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpRef4_Enabled), 5, 0), true);
         edtTmpRef5_Enabled = 0;
         AssignProp("", false, edtTmpRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTmpRef5_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues020( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811441196", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("aguiastemporal.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z32TmpUsuCod", Z32TmpUsuCod);
         GxWebStd.gx_hidden_field( context, "Z33TmpMVATip", Z33TmpMVATip);
         GxWebStd.gx_hidden_field( context, "Z34TmpItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34TmpItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z35TmpProdCod", Z35TmpProdCod);
         GxWebStd.gx_hidden_field( context, "Z36TmpRef1", Z36TmpRef1);
         GxWebStd.gx_hidden_field( context, "Z1922TmpCantidad", StringUtil.LTrim( StringUtil.NToC( Z1922TmpCantidad, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1923TmpRef2", Z1923TmpRef2);
         GxWebStd.gx_hidden_field( context, "Z1924TmpRef3", Z1924TmpRef3);
         GxWebStd.gx_hidden_field( context, "Z1925TmpRef4", Z1925TmpRef4);
         GxWebStd.gx_hidden_field( context, "Z1926TmpRef5", Z1926TmpRef5);
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
         return formatLink("aguiastemporal.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AGUIASTEMPORAL" ;
      }

      public override string GetPgmdesc( )
      {
         return "Guias Lotes Temporal" ;
      }

      protected void InitializeNonKey022( )
      {
         A1922TmpCantidad = 0;
         AssignAttri("", false, "A1922TmpCantidad", StringUtil.LTrimStr( A1922TmpCantidad, 15, 4));
         A1923TmpRef2 = "";
         AssignAttri("", false, "A1923TmpRef2", A1923TmpRef2);
         A1924TmpRef3 = "";
         AssignAttri("", false, "A1924TmpRef3", A1924TmpRef3);
         A1925TmpRef4 = "";
         AssignAttri("", false, "A1925TmpRef4", A1925TmpRef4);
         A1926TmpRef5 = "";
         AssignAttri("", false, "A1926TmpRef5", A1926TmpRef5);
         Z1922TmpCantidad = 0;
         Z1923TmpRef2 = "";
         Z1924TmpRef3 = "";
         Z1925TmpRef4 = "";
         Z1926TmpRef5 = "";
      }

      protected void InitAll022( )
      {
         A32TmpUsuCod = "";
         AssignAttri("", false, "A32TmpUsuCod", A32TmpUsuCod);
         A33TmpMVATip = "";
         AssignAttri("", false, "A33TmpMVATip", A33TmpMVATip);
         A34TmpItem = 0;
         AssignAttri("", false, "A34TmpItem", StringUtil.LTrimStr( (decimal)(A34TmpItem), 6, 0));
         A35TmpProdCod = "";
         AssignAttri("", false, "A35TmpProdCod", A35TmpProdCod);
         A36TmpRef1 = "";
         AssignAttri("", false, "A36TmpRef1", A36TmpRef1);
         InitializeNonKey022( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181144124", true, true);
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
         context.AddJavascriptSource("aguiastemporal.js", "?20228181144124", false, true);
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
         edtTmpUsuCod_Internalname = "TMPUSUCOD";
         edtTmpMVATip_Internalname = "TMPMVATIP";
         edtTmpItem_Internalname = "TMPITEM";
         edtTmpProdCod_Internalname = "TMPPRODCOD";
         edtTmpCantidad_Internalname = "TMPCANTIDAD";
         edtTmpRef1_Internalname = "TMPREF1";
         edtTmpRef2_Internalname = "TMPREF2";
         edtTmpRef3_Internalname = "TMPREF3";
         edtTmpRef4_Internalname = "TMPREF4";
         edtTmpRef5_Internalname = "TMPREF5";
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
         Form.Caption = "Guias Lotes Temporal";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTmpRef5_Jsonclick = "";
         edtTmpRef5_Enabled = 1;
         edtTmpRef4_Jsonclick = "";
         edtTmpRef4_Enabled = 1;
         edtTmpRef3_Jsonclick = "";
         edtTmpRef3_Enabled = 1;
         edtTmpRef2_Jsonclick = "";
         edtTmpRef2_Enabled = 1;
         edtTmpRef1_Jsonclick = "";
         edtTmpRef1_Enabled = 1;
         edtTmpCantidad_Jsonclick = "";
         edtTmpCantidad_Enabled = 1;
         edtTmpProdCod_Jsonclick = "";
         edtTmpProdCod_Enabled = 1;
         edtTmpItem_Jsonclick = "";
         edtTmpItem_Enabled = 1;
         edtTmpMVATip_Jsonclick = "";
         edtTmpMVATip_Enabled = 1;
         edtTmpUsuCod_Jsonclick = "";
         edtTmpUsuCod_Enabled = 1;
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
         GX_FocusControl = edtTmpCantidad_Internalname;
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

      public void Valid_Tmpref1( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1922TmpCantidad", StringUtil.LTrim( StringUtil.NToC( A1922TmpCantidad, 15, 4, ".", "")));
         AssignAttri("", false, "A1923TmpRef2", A1923TmpRef2);
         AssignAttri("", false, "A1924TmpRef3", A1924TmpRef3);
         AssignAttri("", false, "A1925TmpRef4", A1925TmpRef4);
         AssignAttri("", false, "A1926TmpRef5", A1926TmpRef5);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z32TmpUsuCod", Z32TmpUsuCod);
         GxWebStd.gx_hidden_field( context, "Z33TmpMVATip", Z33TmpMVATip);
         GxWebStd.gx_hidden_field( context, "Z34TmpItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z34TmpItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z35TmpProdCod", Z35TmpProdCod);
         GxWebStd.gx_hidden_field( context, "Z36TmpRef1", Z36TmpRef1);
         GxWebStd.gx_hidden_field( context, "Z1922TmpCantidad", StringUtil.LTrim( StringUtil.NToC( Z1922TmpCantidad, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1923TmpRef2", Z1923TmpRef2);
         GxWebStd.gx_hidden_field( context, "Z1924TmpRef3", Z1924TmpRef3);
         GxWebStd.gx_hidden_field( context, "Z1925TmpRef4", Z1925TmpRef4);
         GxWebStd.gx_hidden_field( context, "Z1926TmpRef5", Z1926TmpRef5);
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
         setEventMetadata("VALID_TMPUSUCOD","{handler:'Valid_Tmpusucod',iparms:[]");
         setEventMetadata("VALID_TMPUSUCOD",",oparms:[]}");
         setEventMetadata("VALID_TMPMVATIP","{handler:'Valid_Tmpmvatip',iparms:[]");
         setEventMetadata("VALID_TMPMVATIP",",oparms:[]}");
         setEventMetadata("VALID_TMPITEM","{handler:'Valid_Tmpitem',iparms:[]");
         setEventMetadata("VALID_TMPITEM",",oparms:[]}");
         setEventMetadata("VALID_TMPPRODCOD","{handler:'Valid_Tmpprodcod',iparms:[]");
         setEventMetadata("VALID_TMPPRODCOD",",oparms:[]}");
         setEventMetadata("VALID_TMPREF1","{handler:'Valid_Tmpref1',iparms:[{av:'A32TmpUsuCod',fld:'TMPUSUCOD',pic:''},{av:'A33TmpMVATip',fld:'TMPMVATIP',pic:''},{av:'A34TmpItem',fld:'TMPITEM',pic:'ZZZZZ9'},{av:'A35TmpProdCod',fld:'TMPPRODCOD',pic:''},{av:'A36TmpRef1',fld:'TMPREF1',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TMPREF1",",oparms:[{av:'A1922TmpCantidad',fld:'TMPCANTIDAD',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1923TmpRef2',fld:'TMPREF2',pic:''},{av:'A1924TmpRef3',fld:'TMPREF3',pic:''},{av:'A1925TmpRef4',fld:'TMPREF4',pic:''},{av:'A1926TmpRef5',fld:'TMPREF5',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z32TmpUsuCod'},{av:'Z33TmpMVATip'},{av:'Z34TmpItem'},{av:'Z35TmpProdCod'},{av:'Z36TmpRef1'},{av:'Z1922TmpCantidad'},{av:'Z1923TmpRef2'},{av:'Z1924TmpRef3'},{av:'Z1925TmpRef4'},{av:'Z1926TmpRef5'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z32TmpUsuCod = "";
         Z33TmpMVATip = "";
         Z35TmpProdCod = "";
         Z36TmpRef1 = "";
         Z1923TmpRef2 = "";
         Z1924TmpRef3 = "";
         Z1925TmpRef4 = "";
         Z1926TmpRef5 = "";
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
         A32TmpUsuCod = "";
         A33TmpMVATip = "";
         A35TmpProdCod = "";
         A36TmpRef1 = "";
         A1923TmpRef2 = "";
         A1924TmpRef3 = "";
         A1925TmpRef4 = "";
         A1926TmpRef5 = "";
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
         T00024_A32TmpUsuCod = new string[] {""} ;
         T00024_A33TmpMVATip = new string[] {""} ;
         T00024_A34TmpItem = new int[1] ;
         T00024_A35TmpProdCod = new string[] {""} ;
         T00024_A36TmpRef1 = new string[] {""} ;
         T00024_A1922TmpCantidad = new decimal[1] ;
         T00024_A1923TmpRef2 = new string[] {""} ;
         T00024_A1924TmpRef3 = new string[] {""} ;
         T00024_A1925TmpRef4 = new string[] {""} ;
         T00024_A1926TmpRef5 = new string[] {""} ;
         T00025_A32TmpUsuCod = new string[] {""} ;
         T00025_A33TmpMVATip = new string[] {""} ;
         T00025_A34TmpItem = new int[1] ;
         T00025_A35TmpProdCod = new string[] {""} ;
         T00025_A36TmpRef1 = new string[] {""} ;
         T00023_A32TmpUsuCod = new string[] {""} ;
         T00023_A33TmpMVATip = new string[] {""} ;
         T00023_A34TmpItem = new int[1] ;
         T00023_A35TmpProdCod = new string[] {""} ;
         T00023_A36TmpRef1 = new string[] {""} ;
         T00023_A1922TmpCantidad = new decimal[1] ;
         T00023_A1923TmpRef2 = new string[] {""} ;
         T00023_A1924TmpRef3 = new string[] {""} ;
         T00023_A1925TmpRef4 = new string[] {""} ;
         T00023_A1926TmpRef5 = new string[] {""} ;
         sMode2 = "";
         T00026_A32TmpUsuCod = new string[] {""} ;
         T00026_A33TmpMVATip = new string[] {""} ;
         T00026_A34TmpItem = new int[1] ;
         T00026_A35TmpProdCod = new string[] {""} ;
         T00026_A36TmpRef1 = new string[] {""} ;
         T00027_A32TmpUsuCod = new string[] {""} ;
         T00027_A33TmpMVATip = new string[] {""} ;
         T00027_A34TmpItem = new int[1] ;
         T00027_A35TmpProdCod = new string[] {""} ;
         T00027_A36TmpRef1 = new string[] {""} ;
         T00022_A32TmpUsuCod = new string[] {""} ;
         T00022_A33TmpMVATip = new string[] {""} ;
         T00022_A34TmpItem = new int[1] ;
         T00022_A35TmpProdCod = new string[] {""} ;
         T00022_A36TmpRef1 = new string[] {""} ;
         T00022_A1922TmpCantidad = new decimal[1] ;
         T00022_A1923TmpRef2 = new string[] {""} ;
         T00022_A1924TmpRef3 = new string[] {""} ;
         T00022_A1925TmpRef4 = new string[] {""} ;
         T00022_A1926TmpRef5 = new string[] {""} ;
         T000211_A32TmpUsuCod = new string[] {""} ;
         T000211_A33TmpMVATip = new string[] {""} ;
         T000211_A34TmpItem = new int[1] ;
         T000211_A35TmpProdCod = new string[] {""} ;
         T000211_A36TmpRef1 = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ32TmpUsuCod = "";
         ZZ33TmpMVATip = "";
         ZZ35TmpProdCod = "";
         ZZ36TmpRef1 = "";
         ZZ1923TmpRef2 = "";
         ZZ1924TmpRef3 = "";
         ZZ1925TmpRef4 = "";
         ZZ1926TmpRef5 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aguiastemporal__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aguiastemporal__default(),
            new Object[][] {
                new Object[] {
               T00022_A32TmpUsuCod, T00022_A33TmpMVATip, T00022_A34TmpItem, T00022_A35TmpProdCod, T00022_A36TmpRef1, T00022_A1922TmpCantidad, T00022_A1923TmpRef2, T00022_A1924TmpRef3, T00022_A1925TmpRef4, T00022_A1926TmpRef5
               }
               , new Object[] {
               T00023_A32TmpUsuCod, T00023_A33TmpMVATip, T00023_A34TmpItem, T00023_A35TmpProdCod, T00023_A36TmpRef1, T00023_A1922TmpCantidad, T00023_A1923TmpRef2, T00023_A1924TmpRef3, T00023_A1925TmpRef4, T00023_A1926TmpRef5
               }
               , new Object[] {
               T00024_A32TmpUsuCod, T00024_A33TmpMVATip, T00024_A34TmpItem, T00024_A35TmpProdCod, T00024_A36TmpRef1, T00024_A1922TmpCantidad, T00024_A1923TmpRef2, T00024_A1924TmpRef3, T00024_A1925TmpRef4, T00024_A1926TmpRef5
               }
               , new Object[] {
               T00025_A32TmpUsuCod, T00025_A33TmpMVATip, T00025_A34TmpItem, T00025_A35TmpProdCod, T00025_A36TmpRef1
               }
               , new Object[] {
               T00026_A32TmpUsuCod, T00026_A33TmpMVATip, T00026_A34TmpItem, T00026_A35TmpProdCod, T00026_A36TmpRef1
               }
               , new Object[] {
               T00027_A32TmpUsuCod, T00027_A33TmpMVATip, T00027_A34TmpItem, T00027_A35TmpProdCod, T00027_A36TmpRef1
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000211_A32TmpUsuCod, T000211_A33TmpMVATip, T000211_A34TmpItem, T000211_A35TmpProdCod, T000211_A36TmpRef1
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
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z34TmpItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTmpUsuCod_Enabled ;
      private int edtTmpMVATip_Enabled ;
      private int A34TmpItem ;
      private int edtTmpItem_Enabled ;
      private int edtTmpProdCod_Enabled ;
      private int edtTmpCantidad_Enabled ;
      private int edtTmpRef1_Enabled ;
      private int edtTmpRef2_Enabled ;
      private int edtTmpRef3_Enabled ;
      private int edtTmpRef4_Enabled ;
      private int edtTmpRef5_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ34TmpItem ;
      private decimal Z1922TmpCantidad ;
      private decimal A1922TmpCantidad ;
      private decimal ZZ1922TmpCantidad ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTmpUsuCod_Internalname ;
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
      private string edtTmpUsuCod_Jsonclick ;
      private string edtTmpMVATip_Internalname ;
      private string edtTmpMVATip_Jsonclick ;
      private string edtTmpItem_Internalname ;
      private string edtTmpItem_Jsonclick ;
      private string edtTmpProdCod_Internalname ;
      private string edtTmpProdCod_Jsonclick ;
      private string edtTmpCantidad_Internalname ;
      private string edtTmpCantidad_Jsonclick ;
      private string edtTmpRef1_Internalname ;
      private string edtTmpRef1_Jsonclick ;
      private string edtTmpRef2_Internalname ;
      private string edtTmpRef2_Jsonclick ;
      private string edtTmpRef3_Internalname ;
      private string edtTmpRef3_Jsonclick ;
      private string edtTmpRef4_Internalname ;
      private string edtTmpRef4_Jsonclick ;
      private string edtTmpRef5_Internalname ;
      private string edtTmpRef5_Jsonclick ;
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
      private string sMode2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z32TmpUsuCod ;
      private string Z33TmpMVATip ;
      private string Z35TmpProdCod ;
      private string Z36TmpRef1 ;
      private string Z1923TmpRef2 ;
      private string Z1924TmpRef3 ;
      private string Z1925TmpRef4 ;
      private string Z1926TmpRef5 ;
      private string A32TmpUsuCod ;
      private string A33TmpMVATip ;
      private string A35TmpProdCod ;
      private string A36TmpRef1 ;
      private string A1923TmpRef2 ;
      private string A1924TmpRef3 ;
      private string A1925TmpRef4 ;
      private string A1926TmpRef5 ;
      private string ZZ32TmpUsuCod ;
      private string ZZ33TmpMVATip ;
      private string ZZ35TmpProdCod ;
      private string ZZ36TmpRef1 ;
      private string ZZ1923TmpRef2 ;
      private string ZZ1924TmpRef3 ;
      private string ZZ1925TmpRef4 ;
      private string ZZ1926TmpRef5 ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00024_A32TmpUsuCod ;
      private string[] T00024_A33TmpMVATip ;
      private int[] T00024_A34TmpItem ;
      private string[] T00024_A35TmpProdCod ;
      private string[] T00024_A36TmpRef1 ;
      private decimal[] T00024_A1922TmpCantidad ;
      private string[] T00024_A1923TmpRef2 ;
      private string[] T00024_A1924TmpRef3 ;
      private string[] T00024_A1925TmpRef4 ;
      private string[] T00024_A1926TmpRef5 ;
      private string[] T00025_A32TmpUsuCod ;
      private string[] T00025_A33TmpMVATip ;
      private int[] T00025_A34TmpItem ;
      private string[] T00025_A35TmpProdCod ;
      private string[] T00025_A36TmpRef1 ;
      private string[] T00023_A32TmpUsuCod ;
      private string[] T00023_A33TmpMVATip ;
      private int[] T00023_A34TmpItem ;
      private string[] T00023_A35TmpProdCod ;
      private string[] T00023_A36TmpRef1 ;
      private decimal[] T00023_A1922TmpCantidad ;
      private string[] T00023_A1923TmpRef2 ;
      private string[] T00023_A1924TmpRef3 ;
      private string[] T00023_A1925TmpRef4 ;
      private string[] T00023_A1926TmpRef5 ;
      private string[] T00026_A32TmpUsuCod ;
      private string[] T00026_A33TmpMVATip ;
      private int[] T00026_A34TmpItem ;
      private string[] T00026_A35TmpProdCod ;
      private string[] T00026_A36TmpRef1 ;
      private string[] T00027_A32TmpUsuCod ;
      private string[] T00027_A33TmpMVATip ;
      private int[] T00027_A34TmpItem ;
      private string[] T00027_A35TmpProdCod ;
      private string[] T00027_A36TmpRef1 ;
      private string[] T00022_A32TmpUsuCod ;
      private string[] T00022_A33TmpMVATip ;
      private int[] T00022_A34TmpItem ;
      private string[] T00022_A35TmpProdCod ;
      private string[] T00022_A36TmpRef1 ;
      private decimal[] T00022_A1922TmpCantidad ;
      private string[] T00022_A1923TmpRef2 ;
      private string[] T00022_A1924TmpRef3 ;
      private string[] T00022_A1925TmpRef4 ;
      private string[] T00022_A1926TmpRef5 ;
      private string[] T000211_A32TmpUsuCod ;
      private string[] T000211_A33TmpMVATip ;
      private int[] T000211_A34TmpItem ;
      private string[] T000211_A35TmpProdCod ;
      private string[] T000211_A36TmpRef1 ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aguiastemporal__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aguiastemporal__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00024;
        prmT00024 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00025;
        prmT00025 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00023;
        prmT00023 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00026;
        prmT00026 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00027;
        prmT00027 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00022;
        prmT00022 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT00028;
        prmT00028 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0) ,
        new ParDef("@TmpCantidad",GXType.Decimal,15,4) ,
        new ParDef("@TmpRef2",GXType.NVarChar,20,0) ,
        new ParDef("@TmpRef3",GXType.NVarChar,20,0) ,
        new ParDef("@TmpRef4",GXType.NVarChar,20,0) ,
        new ParDef("@TmpRef5",GXType.NVarChar,20,0)
        };
        Object[] prmT00029;
        prmT00029 = new Object[] {
        new ParDef("@TmpCantidad",GXType.Decimal,15,4) ,
        new ParDef("@TmpRef2",GXType.NVarChar,20,0) ,
        new ParDef("@TmpRef3",GXType.NVarChar,20,0) ,
        new ParDef("@TmpRef4",GXType.NVarChar,20,0) ,
        new ParDef("@TmpRef5",GXType.NVarChar,20,0) ,
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT000210;
        prmT000210 = new Object[] {
        new ParDef("@TmpUsuCod",GXType.NVarChar,10,0) ,
        new ParDef("@TmpMVATip",GXType.NVarChar,3,0) ,
        new ParDef("@TmpItem",GXType.Int32,6,0) ,
        new ParDef("@TmpProdCod",GXType.NVarChar,15,0) ,
        new ParDef("@TmpRef1",GXType.NVarChar,20,0)
        };
        Object[] prmT000211;
        prmT000211 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00022", "SELECT [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1], [TmpCantidad], [TmpRef2], [TmpRef3], [TmpRef4], [TmpRef5] FROM [AGUIASTEMPORAL] WITH (UPDLOCK) WHERE [TmpUsuCod] = @TmpUsuCod AND [TmpMVATip] = @TmpMVATip AND [TmpItem] = @TmpItem AND [TmpProdCod] = @TmpProdCod AND [TmpRef1] = @TmpRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00023", "SELECT [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1], [TmpCantidad], [TmpRef2], [TmpRef3], [TmpRef4], [TmpRef5] FROM [AGUIASTEMPORAL] WHERE [TmpUsuCod] = @TmpUsuCod AND [TmpMVATip] = @TmpMVATip AND [TmpItem] = @TmpItem AND [TmpProdCod] = @TmpProdCod AND [TmpRef1] = @TmpRef1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00024", "SELECT TM1.[TmpUsuCod], TM1.[TmpMVATip], TM1.[TmpItem], TM1.[TmpProdCod], TM1.[TmpRef1], TM1.[TmpCantidad], TM1.[TmpRef2], TM1.[TmpRef3], TM1.[TmpRef4], TM1.[TmpRef5] FROM [AGUIASTEMPORAL] TM1 WHERE TM1.[TmpUsuCod] = @TmpUsuCod and TM1.[TmpMVATip] = @TmpMVATip and TM1.[TmpItem] = @TmpItem and TM1.[TmpProdCod] = @TmpProdCod and TM1.[TmpRef1] = @TmpRef1 ORDER BY TM1.[TmpUsuCod], TM1.[TmpMVATip], TM1.[TmpItem], TM1.[TmpProdCod], TM1.[TmpRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00024,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00025", "SELECT [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1] FROM [AGUIASTEMPORAL] WHERE [TmpUsuCod] = @TmpUsuCod AND [TmpMVATip] = @TmpMVATip AND [TmpItem] = @TmpItem AND [TmpProdCod] = @TmpProdCod AND [TmpRef1] = @TmpRef1  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00025,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00026", "SELECT TOP 1 [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1] FROM [AGUIASTEMPORAL] WHERE ( [TmpUsuCod] > @TmpUsuCod or [TmpUsuCod] = @TmpUsuCod and [TmpMVATip] > @TmpMVATip or [TmpMVATip] = @TmpMVATip and [TmpUsuCod] = @TmpUsuCod and [TmpItem] > @TmpItem or [TmpItem] = @TmpItem and [TmpMVATip] = @TmpMVATip and [TmpUsuCod] = @TmpUsuCod and [TmpProdCod] > @TmpProdCod or [TmpProdCod] = @TmpProdCod and [TmpItem] = @TmpItem and [TmpMVATip] = @TmpMVATip and [TmpUsuCod] = @TmpUsuCod and [TmpRef1] > @TmpRef1) ORDER BY [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00026,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00027", "SELECT TOP 1 [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1] FROM [AGUIASTEMPORAL] WHERE ( [TmpUsuCod] < @TmpUsuCod or [TmpUsuCod] = @TmpUsuCod and [TmpMVATip] < @TmpMVATip or [TmpMVATip] = @TmpMVATip and [TmpUsuCod] = @TmpUsuCod and [TmpItem] < @TmpItem or [TmpItem] = @TmpItem and [TmpMVATip] = @TmpMVATip and [TmpUsuCod] = @TmpUsuCod and [TmpProdCod] < @TmpProdCod or [TmpProdCod] = @TmpProdCod and [TmpItem] = @TmpItem and [TmpMVATip] = @TmpMVATip and [TmpUsuCod] = @TmpUsuCod and [TmpRef1] < @TmpRef1) ORDER BY [TmpUsuCod] DESC, [TmpMVATip] DESC, [TmpItem] DESC, [TmpProdCod] DESC, [TmpRef1] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00027,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00028", "INSERT INTO [AGUIASTEMPORAL]([TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1], [TmpCantidad], [TmpRef2], [TmpRef3], [TmpRef4], [TmpRef5]) VALUES(@TmpUsuCod, @TmpMVATip, @TmpItem, @TmpProdCod, @TmpRef1, @TmpCantidad, @TmpRef2, @TmpRef3, @TmpRef4, @TmpRef5)", GxErrorMask.GX_NOMASK,prmT00028)
           ,new CursorDef("T00029", "UPDATE [AGUIASTEMPORAL] SET [TmpCantidad]=@TmpCantidad, [TmpRef2]=@TmpRef2, [TmpRef3]=@TmpRef3, [TmpRef4]=@TmpRef4, [TmpRef5]=@TmpRef5  WHERE [TmpUsuCod] = @TmpUsuCod AND [TmpMVATip] = @TmpMVATip AND [TmpItem] = @TmpItem AND [TmpProdCod] = @TmpProdCod AND [TmpRef1] = @TmpRef1", GxErrorMask.GX_NOMASK,prmT00029)
           ,new CursorDef("T000210", "DELETE FROM [AGUIASTEMPORAL]  WHERE [TmpUsuCod] = @TmpUsuCod AND [TmpMVATip] = @TmpMVATip AND [TmpItem] = @TmpItem AND [TmpProdCod] = @TmpProdCod AND [TmpRef1] = @TmpRef1", GxErrorMask.GX_NOMASK,prmT000210)
           ,new CursorDef("T000211", "SELECT [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1] FROM [AGUIASTEMPORAL] ORDER BY [TmpUsuCod], [TmpMVATip], [TmpItem], [TmpProdCod], [TmpRef1]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000211,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
     }
  }

}

}
