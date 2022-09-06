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
   public class cbpresupuestolinea : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_2") == 0 )
         {
            A2280CBTipPre = (int)(NumberUtil.Val( GetPar( "CBTipPre"), "."));
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A2280CBTipPre) ;
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
            Form.Meta.addItem("description", "Linea de Presupuesto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbpresupuestolinea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbpresupuestolinea( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Linea de Presupuesto", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBPRESUPUESTOLINEA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPRESUPUESTOLINEA.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBTipPre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBTipPre_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBTipPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2280CBTipPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBTipPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2280CBTipPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBTipTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBTipTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBTipTipo_Internalname, A2281CBTipTipo, StringUtil.RTrim( context.localUtil.Format( A2281CBTipTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBTipTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBTipTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBLinPre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBLinPre_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBLinPre_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2282CBLinPre), 6, 0, ".", "")), StringUtil.LTrim( ((edtCBLinPre_Enabled!=0) ? context.localUtil.Format( (decimal)(A2282CBLinPre), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2282CBLinPre), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBLinPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBLinPre_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBLinPreDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBLinPreDsc_Internalname, "de Presupuesto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBLinPreDsc_Internalname, A2289CBLinPreDsc, StringUtil.RTrim( context.localUtil.Format( A2289CBLinPreDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBLinPreDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBLinPreDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCBLinPreSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCBLinPreSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCBLinPreSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2290CBLinPreSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtCBLinPreSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A2290CBLinPreSts), "9") : context.localUtil.Format( (decimal)(A2290CBLinPreSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCBLinPreSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCBLinPreSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPRESUPUESTOLINEA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOLINEA.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPRESUPUESTOLINEA.htm");
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
            Z2280CBTipPre = (int)(context.localUtil.CToN( cgiGet( "Z2280CBTipPre"), ".", ","));
            Z2281CBTipTipo = cgiGet( "Z2281CBTipTipo");
            Z2282CBLinPre = (int)(context.localUtil.CToN( cgiGet( "Z2282CBLinPre"), ".", ","));
            Z2289CBLinPreDsc = cgiGet( "Z2289CBLinPreDsc");
            Z2290CBLinPreSts = (short)(context.localUtil.CToN( cgiGet( "Z2290CBLinPreSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBTipPre_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBTipPre_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBTIPPRE");
               AnyError = 1;
               GX_FocusControl = edtCBTipPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2280CBTipPre = 0;
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            }
            else
            {
               A2280CBTipPre = (int)(context.localUtil.CToN( cgiGet( edtCBTipPre_Internalname), ".", ","));
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            }
            A2281CBTipTipo = cgiGet( edtCBTipTipo_Internalname);
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBLinPre_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBLinPre_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBLINPRE");
               AnyError = 1;
               GX_FocusControl = edtCBLinPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2282CBLinPre = 0;
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            }
            else
            {
               A2282CBLinPre = (int)(context.localUtil.CToN( cgiGet( edtCBLinPre_Internalname), ".", ","));
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            }
            A2289CBLinPreDsc = cgiGet( edtCBLinPreDsc_Internalname);
            AssignAttri("", false, "A2289CBLinPreDsc", A2289CBLinPreDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCBLinPreSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCBLinPreSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CBLINPRESTS");
               AnyError = 1;
               GX_FocusControl = edtCBLinPreSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2290CBLinPreSts = 0;
               AssignAttri("", false, "A2290CBLinPreSts", StringUtil.Str( (decimal)(A2290CBLinPreSts), 1, 0));
            }
            else
            {
               A2290CBLinPreSts = (short)(context.localUtil.CToN( cgiGet( edtCBLinPreSts_Internalname), ".", ","));
               AssignAttri("", false, "A2290CBLinPreSts", StringUtil.Str( (decimal)(A2290CBLinPreSts), 1, 0));
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
               A2280CBTipPre = (int)(NumberUtil.Val( GetPar( "CBTipPre"), "."));
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = GetPar( "CBTipTipo");
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = (int)(NumberUtil.Val( GetPar( "CBLinPre"), "."));
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
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
               InitAll7G204( ) ;
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
         DisableAttributes7G204( ) ;
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

      protected void ResetCaption7G0( )
      {
      }

      protected void ZM7G204( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2289CBLinPreDsc = T007G3_A2289CBLinPreDsc[0];
               Z2290CBLinPreSts = T007G3_A2290CBLinPreSts[0];
            }
            else
            {
               Z2289CBLinPreDsc = A2289CBLinPreDsc;
               Z2290CBLinPreSts = A2290CBLinPreSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            Z2289CBLinPreDsc = A2289CBLinPreDsc;
            Z2290CBLinPreSts = A2290CBLinPreSts;
            Z2280CBTipPre = A2280CBTipPre;
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

      protected void Load7G204( )
      {
         /* Using cursor T007G5 */
         pr_default.execute(3, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound204 = 1;
            A2289CBLinPreDsc = T007G5_A2289CBLinPreDsc[0];
            AssignAttri("", false, "A2289CBLinPreDsc", A2289CBLinPreDsc);
            A2290CBLinPreSts = T007G5_A2290CBLinPreSts[0];
            AssignAttri("", false, "A2290CBLinPreSts", StringUtil.Str( (decimal)(A2290CBLinPreSts), 1, 0));
            ZM7G204( -1) ;
         }
         pr_default.close(3);
         OnLoadActions7G204( ) ;
      }

      protected void OnLoadActions7G204( )
      {
      }

      protected void CheckExtendedTable7G204( )
      {
         nIsDirty_204 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T007G4 */
         pr_default.execute(2, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Presupuesto'.", "ForeignKeyNotFound", 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors7G204( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A2280CBTipPre )
      {
         /* Using cursor T007G6 */
         pr_default.execute(4, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Presupuesto'.", "ForeignKeyNotFound", 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
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

      protected void GetKey7G204( )
      {
         /* Using cursor T007G7 */
         pr_default.execute(5, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound204 = 1;
         }
         else
         {
            RcdFound204 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T007G3 */
         pr_default.execute(1, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM7G204( 1) ;
            RcdFound204 = 1;
            A2281CBTipTipo = T007G3_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007G3_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            A2289CBLinPreDsc = T007G3_A2289CBLinPreDsc[0];
            AssignAttri("", false, "A2289CBLinPreDsc", A2289CBLinPreDsc);
            A2290CBLinPreSts = T007G3_A2290CBLinPreSts[0];
            AssignAttri("", false, "A2290CBLinPreSts", StringUtil.Str( (decimal)(A2290CBLinPreSts), 1, 0));
            A2280CBTipPre = T007G3_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            Z2280CBTipPre = A2280CBTipPre;
            Z2281CBTipTipo = A2281CBTipTipo;
            Z2282CBLinPre = A2282CBLinPre;
            sMode204 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load7G204( ) ;
            if ( AnyError == 1 )
            {
               RcdFound204 = 0;
               InitializeNonKey7G204( ) ;
            }
            Gx_mode = sMode204;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound204 = 0;
            InitializeNonKey7G204( ) ;
            sMode204 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode204;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey7G204( ) ;
         if ( RcdFound204 == 0 )
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
         RcdFound204 = 0;
         /* Using cursor T007G8 */
         pr_default.execute(6, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T007G8_A2280CBTipPre[0] < A2280CBTipPre ) || ( T007G8_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007G8_A2281CBTipTipo[0], A2281CBTipTipo) < 0 ) || ( StringUtil.StrCmp(T007G8_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007G8_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007G8_A2282CBLinPre[0] < A2282CBLinPre ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T007G8_A2280CBTipPre[0] > A2280CBTipPre ) || ( T007G8_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007G8_A2281CBTipTipo[0], A2281CBTipTipo) > 0 ) || ( StringUtil.StrCmp(T007G8_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007G8_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007G8_A2282CBLinPre[0] > A2282CBLinPre ) ) )
            {
               A2280CBTipPre = T007G8_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = T007G8_A2281CBTipTipo[0];
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = T007G8_A2282CBLinPre[0];
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
               RcdFound204 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound204 = 0;
         /* Using cursor T007G9 */
         pr_default.execute(7, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T007G9_A2280CBTipPre[0] > A2280CBTipPre ) || ( T007G9_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007G9_A2281CBTipTipo[0], A2281CBTipTipo) > 0 ) || ( StringUtil.StrCmp(T007G9_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007G9_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007G9_A2282CBLinPre[0] > A2282CBLinPre ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T007G9_A2280CBTipPre[0] < A2280CBTipPre ) || ( T007G9_A2280CBTipPre[0] == A2280CBTipPre ) && ( StringUtil.StrCmp(T007G9_A2281CBTipTipo[0], A2281CBTipTipo) < 0 ) || ( StringUtil.StrCmp(T007G9_A2281CBTipTipo[0], A2281CBTipTipo) == 0 ) && ( T007G9_A2280CBTipPre[0] == A2280CBTipPre ) && ( T007G9_A2282CBLinPre[0] < A2282CBLinPre ) ) )
            {
               A2280CBTipPre = T007G9_A2280CBTipPre[0];
               AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
               A2281CBTipTipo = T007G9_A2281CBTipTipo[0];
               AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
               A2282CBLinPre = T007G9_A2282CBLinPre[0];
               AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
               RcdFound204 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey7G204( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert7G204( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound204 == 1 )
            {
               if ( ( A2280CBTipPre != Z2280CBTipPre ) || ( StringUtil.StrCmp(A2281CBTipTipo, Z2281CBTipTipo) != 0 ) || ( A2282CBLinPre != Z2282CBLinPre ) )
               {
                  A2280CBTipPre = Z2280CBTipPre;
                  AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
                  A2281CBTipTipo = Z2281CBTipTipo;
                  AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
                  A2282CBLinPre = Z2282CBLinPre;
                  AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CBTIPPRE");
                  AnyError = 1;
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update7G204( ) ;
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A2280CBTipPre != Z2280CBTipPre ) || ( StringUtil.StrCmp(A2281CBTipTipo, Z2281CBTipTipo) != 0 ) || ( A2282CBLinPre != Z2282CBLinPre ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCBTipPre_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert7G204( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CBTIPPRE");
                     AnyError = 1;
                     GX_FocusControl = edtCBTipPre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCBTipPre_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert7G204( ) ;
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
         if ( ( A2280CBTipPre != Z2280CBTipPre ) || ( StringUtil.StrCmp(A2281CBTipTipo, Z2281CBTipTipo) != 0 ) || ( A2282CBLinPre != Z2282CBLinPre ) )
         {
            A2280CBTipPre = Z2280CBTipPre;
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = Z2281CBTipTipo;
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = Z2282CBLinPre;
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCBTipPre_Internalname;
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
         if ( RcdFound204 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCBLinPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart7G204( ) ;
         if ( RcdFound204 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBLinPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7G204( ) ;
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
         if ( RcdFound204 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBLinPreDsc_Internalname;
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
         if ( RcdFound204 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBLinPreDsc_Internalname;
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
         ScanStart7G204( ) ;
         if ( RcdFound204 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound204 != 0 )
            {
               ScanNext7G204( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCBLinPreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd7G204( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency7G204( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T007G2 */
            pr_default.execute(0, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTOLINEA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2289CBLinPreDsc, T007G2_A2289CBLinPreDsc[0]) != 0 ) || ( Z2290CBLinPreSts != T007G2_A2290CBLinPreSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z2289CBLinPreDsc, T007G2_A2289CBLinPreDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbpresupuestolinea:[seudo value changed for attri]"+"CBLinPreDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2289CBLinPreDsc);
                  GXUtil.WriteLogRaw("Current: ",T007G2_A2289CBLinPreDsc[0]);
               }
               if ( Z2290CBLinPreSts != T007G2_A2290CBLinPreSts[0] )
               {
                  GXUtil.WriteLog("cbpresupuestolinea:[seudo value changed for attri]"+"CBLinPreSts");
                  GXUtil.WriteLogRaw("Old: ",Z2290CBLinPreSts);
                  GXUtil.WriteLogRaw("Current: ",T007G2_A2290CBLinPreSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPRESUPUESTOLINEA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert7G204( )
      {
         BeforeValidate7G204( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7G204( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM7G204( 0) ;
            CheckOptimisticConcurrency7G204( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7G204( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert7G204( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007G10 */
                     pr_default.execute(8, new Object[] {A2281CBTipTipo, A2282CBLinPre, A2289CBLinPreDsc, A2290CBLinPreSts, A2280CBTipPre});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTOLINEA");
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
                           ResetCaption7G0( ) ;
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
               Load7G204( ) ;
            }
            EndLevel7G204( ) ;
         }
         CloseExtendedTableCursors7G204( ) ;
      }

      protected void Update7G204( )
      {
         BeforeValidate7G204( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable7G204( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7G204( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm7G204( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate7G204( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T007G11 */
                     pr_default.execute(9, new Object[] {A2289CBLinPreDsc, A2290CBLinPreSts, A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTOLINEA");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPRESUPUESTOLINEA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate7G204( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption7G0( ) ;
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
            EndLevel7G204( ) ;
         }
         CloseExtendedTableCursors7G204( ) ;
      }

      protected void DeferredUpdate7G204( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate7G204( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency7G204( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls7G204( ) ;
            AfterConfirm7G204( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete7G204( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007G12 */
                  pr_default.execute(10, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPRESUPUESTOLINEA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound204 == 0 )
                        {
                           InitAll7G204( ) ;
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
                        ResetCaption7G0( ) ;
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
         sMode204 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel7G204( ) ;
         Gx_mode = sMode204;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls7G204( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007G13 */
            pr_default.execute(11, new Object[] {A2280CBTipPre, A2281CBTipTipo, A2282CBLinPre});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Rubros de Presupuestos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel7G204( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete7G204( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbpresupuestolinea",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues7G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbpresupuestolinea",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart7G204( )
      {
         /* Using cursor T007G14 */
         pr_default.execute(12);
         RcdFound204 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound204 = 1;
            A2280CBTipPre = T007G14_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007G14_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007G14_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext7G204( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound204 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound204 = 1;
            A2280CBTipPre = T007G14_A2280CBTipPre[0];
            AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
            A2281CBTipTipo = T007G14_A2281CBTipTipo[0];
            AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
            A2282CBLinPre = T007G14_A2282CBLinPre[0];
            AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
         }
      }

      protected void ScanEnd7G204( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm7G204( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert7G204( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate7G204( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete7G204( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete7G204( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate7G204( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes7G204( )
      {
         edtCBTipPre_Enabled = 0;
         AssignProp("", false, edtCBTipPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBTipPre_Enabled), 5, 0), true);
         edtCBTipTipo_Enabled = 0;
         AssignProp("", false, edtCBTipTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBTipTipo_Enabled), 5, 0), true);
         edtCBLinPre_Enabled = 0;
         AssignProp("", false, edtCBLinPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBLinPre_Enabled), 5, 0), true);
         edtCBLinPreDsc_Enabled = 0;
         AssignProp("", false, edtCBLinPreDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBLinPreDsc_Enabled), 5, 0), true);
         edtCBLinPreSts_Enabled = 0;
         AssignProp("", false, edtCBLinPreSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCBLinPreSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes7G204( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues7G0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181027718", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbpresupuestolinea.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2280CBTipPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2280CBTipPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2281CBTipTipo", Z2281CBTipTipo);
         GxWebStd.gx_hidden_field( context, "Z2282CBLinPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2282CBLinPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2289CBLinPreDsc", Z2289CBLinPreDsc);
         GxWebStd.gx_hidden_field( context, "Z2290CBLinPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2290CBLinPreSts), 1, 0, ".", "")));
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
         return formatLink("cbpresupuestolinea.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPRESUPUESTOLINEA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Linea de Presupuesto" ;
      }

      protected void InitializeNonKey7G204( )
      {
         A2289CBLinPreDsc = "";
         AssignAttri("", false, "A2289CBLinPreDsc", A2289CBLinPreDsc);
         A2290CBLinPreSts = 0;
         AssignAttri("", false, "A2290CBLinPreSts", StringUtil.Str( (decimal)(A2290CBLinPreSts), 1, 0));
         Z2289CBLinPreDsc = "";
         Z2290CBLinPreSts = 0;
      }

      protected void InitAll7G204( )
      {
         A2280CBTipPre = 0;
         AssignAttri("", false, "A2280CBTipPre", StringUtil.LTrimStr( (decimal)(A2280CBTipPre), 6, 0));
         A2281CBTipTipo = "";
         AssignAttri("", false, "A2281CBTipTipo", A2281CBTipTipo);
         A2282CBLinPre = 0;
         AssignAttri("", false, "A2282CBLinPre", StringUtil.LTrimStr( (decimal)(A2282CBLinPre), 6, 0));
         InitializeNonKey7G204( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181027724", true, true);
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
         context.AddJavascriptSource("cbpresupuestolinea.js", "?20228181027724", false, true);
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
         edtCBTipPre_Internalname = "CBTIPPRE";
         edtCBTipTipo_Internalname = "CBTIPTIPO";
         edtCBLinPre_Internalname = "CBLINPRE";
         edtCBLinPreDsc_Internalname = "CBLINPREDSC";
         edtCBLinPreSts_Internalname = "CBLINPRESTS";
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
         Form.Caption = "Linea de Presupuesto";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCBLinPreSts_Jsonclick = "";
         edtCBLinPreSts_Enabled = 1;
         edtCBLinPreDsc_Jsonclick = "";
         edtCBLinPreDsc_Enabled = 1;
         edtCBLinPre_Jsonclick = "";
         edtCBLinPre_Enabled = 1;
         edtCBTipTipo_Jsonclick = "";
         edtCBTipTipo_Enabled = 1;
         edtCBTipPre_Jsonclick = "";
         edtCBTipPre_Enabled = 1;
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
         /* Using cursor T007G15 */
         pr_default.execute(13, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Presupuesto'.", "ForeignKeyNotFound", 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         GX_FocusControl = edtCBLinPreDsc_Internalname;
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

      public void Valid_Cbtippre( )
      {
         /* Using cursor T007G15 */
         pr_default.execute(13, new Object[] {A2280CBTipPre});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Presupuesto'.", "ForeignKeyNotFound", 1, "CBTIPPRE");
            AnyError = 1;
            GX_FocusControl = edtCBTipPre_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cblinpre( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2289CBLinPreDsc", A2289CBLinPreDsc);
         AssignAttri("", false, "A2290CBLinPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2290CBLinPreSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2280CBTipPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2280CBTipPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2281CBTipTipo", Z2281CBTipTipo);
         GxWebStd.gx_hidden_field( context, "Z2282CBLinPre", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2282CBLinPre), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2289CBLinPreDsc", Z2289CBLinPreDsc);
         GxWebStd.gx_hidden_field( context, "Z2290CBLinPreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2290CBLinPreSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_CBTIPPRE","{handler:'Valid_Cbtippre',iparms:[{av:'A2280CBTipPre',fld:'CBTIPPRE',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CBTIPPRE",",oparms:[]}");
         setEventMetadata("VALID_CBTIPTIPO","{handler:'Valid_Cbtiptipo',iparms:[]");
         setEventMetadata("VALID_CBTIPTIPO",",oparms:[]}");
         setEventMetadata("VALID_CBLINPRE","{handler:'Valid_Cblinpre',iparms:[{av:'A2280CBTipPre',fld:'CBTIPPRE',pic:'ZZZZZ9'},{av:'A2281CBTipTipo',fld:'CBTIPTIPO',pic:''},{av:'A2282CBLinPre',fld:'CBLINPRE',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CBLINPRE",",oparms:[{av:'A2289CBLinPreDsc',fld:'CBLINPREDSC',pic:''},{av:'A2290CBLinPreSts',fld:'CBLINPRESTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2280CBTipPre'},{av:'Z2281CBTipTipo'},{av:'Z2282CBLinPre'},{av:'Z2289CBLinPreDsc'},{av:'Z2290CBLinPreSts'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z2281CBTipTipo = "";
         Z2289CBLinPreDsc = "";
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
         A2281CBTipTipo = "";
         A2289CBLinPreDsc = "";
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
         T007G5_A2281CBTipTipo = new string[] {""} ;
         T007G5_A2282CBLinPre = new int[1] ;
         T007G5_A2289CBLinPreDsc = new string[] {""} ;
         T007G5_A2290CBLinPreSts = new short[1] ;
         T007G5_A2280CBTipPre = new int[1] ;
         T007G4_A2280CBTipPre = new int[1] ;
         T007G6_A2280CBTipPre = new int[1] ;
         T007G7_A2280CBTipPre = new int[1] ;
         T007G7_A2281CBTipTipo = new string[] {""} ;
         T007G7_A2282CBLinPre = new int[1] ;
         T007G3_A2281CBTipTipo = new string[] {""} ;
         T007G3_A2282CBLinPre = new int[1] ;
         T007G3_A2289CBLinPreDsc = new string[] {""} ;
         T007G3_A2290CBLinPreSts = new short[1] ;
         T007G3_A2280CBTipPre = new int[1] ;
         sMode204 = "";
         T007G8_A2280CBTipPre = new int[1] ;
         T007G8_A2281CBTipTipo = new string[] {""} ;
         T007G8_A2282CBLinPre = new int[1] ;
         T007G9_A2280CBTipPre = new int[1] ;
         T007G9_A2281CBTipTipo = new string[] {""} ;
         T007G9_A2282CBLinPre = new int[1] ;
         T007G2_A2281CBTipTipo = new string[] {""} ;
         T007G2_A2282CBLinPre = new int[1] ;
         T007G2_A2289CBLinPreDsc = new string[] {""} ;
         T007G2_A2290CBLinPreSts = new short[1] ;
         T007G2_A2280CBTipPre = new int[1] ;
         T007G13_A2280CBTipPre = new int[1] ;
         T007G13_A2281CBTipTipo = new string[] {""} ;
         T007G13_A2282CBLinPre = new int[1] ;
         T007G13_A2283CBRubPre = new int[1] ;
         T007G14_A2280CBTipPre = new int[1] ;
         T007G14_A2281CBTipTipo = new string[] {""} ;
         T007G14_A2282CBLinPre = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T007G15_A2280CBTipPre = new int[1] ;
         ZZ2281CBTipTipo = "";
         ZZ2289CBLinPreDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestolinea__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbpresupuestolinea__default(),
            new Object[][] {
                new Object[] {
               T007G2_A2281CBTipTipo, T007G2_A2282CBLinPre, T007G2_A2289CBLinPreDsc, T007G2_A2290CBLinPreSts, T007G2_A2280CBTipPre
               }
               , new Object[] {
               T007G3_A2281CBTipTipo, T007G3_A2282CBLinPre, T007G3_A2289CBLinPreDsc, T007G3_A2290CBLinPreSts, T007G3_A2280CBTipPre
               }
               , new Object[] {
               T007G4_A2280CBTipPre
               }
               , new Object[] {
               T007G5_A2281CBTipTipo, T007G5_A2282CBLinPre, T007G5_A2289CBLinPreDsc, T007G5_A2290CBLinPreSts, T007G5_A2280CBTipPre
               }
               , new Object[] {
               T007G6_A2280CBTipPre
               }
               , new Object[] {
               T007G7_A2280CBTipPre, T007G7_A2281CBTipTipo, T007G7_A2282CBLinPre
               }
               , new Object[] {
               T007G8_A2280CBTipPre, T007G8_A2281CBTipTipo, T007G8_A2282CBLinPre
               }
               , new Object[] {
               T007G9_A2280CBTipPre, T007G9_A2281CBTipTipo, T007G9_A2282CBLinPre
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007G13_A2280CBTipPre, T007G13_A2281CBTipTipo, T007G13_A2282CBLinPre, T007G13_A2283CBRubPre
               }
               , new Object[] {
               T007G14_A2280CBTipPre, T007G14_A2281CBTipTipo, T007G14_A2282CBLinPre
               }
               , new Object[] {
               T007G15_A2280CBTipPre
               }
            }
         );
      }

      private short Z2290CBLinPreSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2290CBLinPreSts ;
      private short GX_JID ;
      private short RcdFound204 ;
      private short nIsDirty_204 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2290CBLinPreSts ;
      private int Z2280CBTipPre ;
      private int Z2282CBLinPre ;
      private int A2280CBTipPre ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCBTipPre_Enabled ;
      private int edtCBTipTipo_Enabled ;
      private int A2282CBLinPre ;
      private int edtCBLinPre_Enabled ;
      private int edtCBLinPreDsc_Enabled ;
      private int edtCBLinPreSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2280CBTipPre ;
      private int ZZ2282CBLinPre ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCBTipPre_Internalname ;
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
      private string edtCBTipPre_Jsonclick ;
      private string edtCBTipTipo_Internalname ;
      private string edtCBTipTipo_Jsonclick ;
      private string edtCBLinPre_Internalname ;
      private string edtCBLinPre_Jsonclick ;
      private string edtCBLinPreDsc_Internalname ;
      private string edtCBLinPreDsc_Jsonclick ;
      private string edtCBLinPreSts_Internalname ;
      private string edtCBLinPreSts_Jsonclick ;
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
      private string sMode204 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z2281CBTipTipo ;
      private string Z2289CBLinPreDsc ;
      private string A2281CBTipTipo ;
      private string A2289CBLinPreDsc ;
      private string ZZ2281CBTipTipo ;
      private string ZZ2289CBLinPreDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T007G5_A2281CBTipTipo ;
      private int[] T007G5_A2282CBLinPre ;
      private string[] T007G5_A2289CBLinPreDsc ;
      private short[] T007G5_A2290CBLinPreSts ;
      private int[] T007G5_A2280CBTipPre ;
      private int[] T007G4_A2280CBTipPre ;
      private int[] T007G6_A2280CBTipPre ;
      private int[] T007G7_A2280CBTipPre ;
      private string[] T007G7_A2281CBTipTipo ;
      private int[] T007G7_A2282CBLinPre ;
      private string[] T007G3_A2281CBTipTipo ;
      private int[] T007G3_A2282CBLinPre ;
      private string[] T007G3_A2289CBLinPreDsc ;
      private short[] T007G3_A2290CBLinPreSts ;
      private int[] T007G3_A2280CBTipPre ;
      private int[] T007G8_A2280CBTipPre ;
      private string[] T007G8_A2281CBTipTipo ;
      private int[] T007G8_A2282CBLinPre ;
      private int[] T007G9_A2280CBTipPre ;
      private string[] T007G9_A2281CBTipTipo ;
      private int[] T007G9_A2282CBLinPre ;
      private string[] T007G2_A2281CBTipTipo ;
      private int[] T007G2_A2282CBLinPre ;
      private string[] T007G2_A2289CBLinPreDsc ;
      private short[] T007G2_A2290CBLinPreSts ;
      private int[] T007G2_A2280CBTipPre ;
      private int[] T007G13_A2280CBTipPre ;
      private string[] T007G13_A2281CBTipTipo ;
      private int[] T007G13_A2282CBLinPre ;
      private int[] T007G13_A2283CBRubPre ;
      private int[] T007G14_A2280CBTipPre ;
      private string[] T007G14_A2281CBTipTipo ;
      private int[] T007G14_A2282CBLinPre ;
      private int[] T007G15_A2280CBTipPre ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbpresupuestolinea__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbpresupuestolinea__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT007G5;
        prmT007G5 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G4;
        prmT007G4 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007G6;
        prmT007G6 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007G7;
        prmT007G7 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G3;
        prmT007G3 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G8;
        prmT007G8 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G9;
        prmT007G9 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G2;
        prmT007G2 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G10;
        prmT007G10 = new Object[] {
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0) ,
        new ParDef("@CBLinPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBLinPreSts",GXType.Int16,1,0) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        Object[] prmT007G11;
        prmT007G11 = new Object[] {
        new ParDef("@CBLinPreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@CBLinPreSts",GXType.Int16,1,0) ,
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G12;
        prmT007G12 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G13;
        prmT007G13 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0) ,
        new ParDef("@CBTipTipo",GXType.NVarChar,1,0) ,
        new ParDef("@CBLinPre",GXType.Int32,6,0)
        };
        Object[] prmT007G14;
        prmT007G14 = new Object[] {
        };
        Object[] prmT007G15;
        prmT007G15 = new Object[] {
        new ParDef("@CBTipPre",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T007G2", "SELECT [CBTipTipo], [CBLinPre], [CBLinPreDsc], [CBLinPreSts], [CBTipPre] FROM [CBPRESUPUESTOLINEA] WITH (UPDLOCK) WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007G3", "SELECT [CBTipTipo], [CBLinPre], [CBLinPreDsc], [CBLinPreSts], [CBTipPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007G4", "SELECT [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @CBTipPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007G5", "SELECT TM1.[CBTipTipo], TM1.[CBLinPre], TM1.[CBLinPreDsc], TM1.[CBLinPreSts], TM1.[CBTipPre] FROM [CBPRESUPUESTOLINEA] TM1 WHERE TM1.[CBTipPre] = @CBTipPre and TM1.[CBTipTipo] = @CBTipTipo and TM1.[CBLinPre] = @CBLinPre ORDER BY TM1.[CBTipPre], TM1.[CBTipTipo], TM1.[CBLinPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007G5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007G6", "SELECT [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @CBTipPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007G7", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTOLINEA] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007G7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007G8", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTOLINEA] WHERE ( [CBTipPre] > @CBTipPre or [CBTipPre] = @CBTipPre and [CBTipTipo] > @CBTipTipo or [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBLinPre] > @CBLinPre) ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007G8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007G9", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTOLINEA] WHERE ( [CBTipPre] < @CBTipPre or [CBTipPre] = @CBTipPre and [CBTipTipo] < @CBTipTipo or [CBTipTipo] = @CBTipTipo and [CBTipPre] = @CBTipPre and [CBLinPre] < @CBLinPre) ORDER BY [CBTipPre] DESC, [CBTipTipo] DESC, [CBLinPre] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT007G9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007G10", "INSERT INTO [CBPRESUPUESTOLINEA]([CBTipTipo], [CBLinPre], [CBLinPreDsc], [CBLinPreSts], [CBTipPre]) VALUES(@CBTipTipo, @CBLinPre, @CBLinPreDsc, @CBLinPreSts, @CBTipPre)", GxErrorMask.GX_NOMASK,prmT007G10)
           ,new CursorDef("T007G11", "UPDATE [CBPRESUPUESTOLINEA] SET [CBLinPreDsc]=@CBLinPreDsc, [CBLinPreSts]=@CBLinPreSts  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre", GxErrorMask.GX_NOMASK,prmT007G11)
           ,new CursorDef("T007G12", "DELETE FROM [CBPRESUPUESTOLINEA]  WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre", GxErrorMask.GX_NOMASK,prmT007G12)
           ,new CursorDef("T007G13", "SELECT TOP 1 [CBTipPre], [CBTipTipo], [CBLinPre], [CBRubPre] FROM [CBPRESUPUESTORUBROS] WHERE [CBTipPre] = @CBTipPre AND [CBTipTipo] = @CBTipTipo AND [CBLinPre] = @CBLinPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007G13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007G14", "SELECT [CBTipPre], [CBTipTipo], [CBLinPre] FROM [CBPRESUPUESTOLINEA] ORDER BY [CBTipPre], [CBTipTipo], [CBLinPre]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007G14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T007G15", "SELECT [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE [CBTipPre] = @CBTipPre ",true, GxErrorMask.GX_NOMASK, false, this,prmT007G15,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
