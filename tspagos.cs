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
   public class tspagos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A417PagPrvCod = GetPar( "PagPrvCod");
            AssignAttri("", false, "A417PagPrvCod", A417PagPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A417PagPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A416PagForCod = (int)(NumberUtil.Val( GetPar( "PagForCod"), "."));
            AssignAttri("", false, "A416PagForCod", StringUtil.LTrimStr( (decimal)(A416PagForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A416PagForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A414PagBanCod = (int)(NumberUtil.Val( GetPar( "PagBanCod"), "."));
            n414PagBanCod = false;
            AssignAttri("", false, "A414PagBanCod", StringUtil.LTrimStr( (decimal)(A414PagBanCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A414PagBanCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A414PagBanCod = (int)(NumberUtil.Val( GetPar( "PagBanCod"), "."));
            n414PagBanCod = false;
            AssignAttri("", false, "A414PagBanCod", StringUtil.LTrimStr( (decimal)(A414PagBanCod), 6, 0));
            A415PagCBCod = GetPar( "PagCBCod");
            n415PagCBCod = false;
            AssignAttri("", false, "A415PagCBCod", A415PagCBCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A414PagBanCod, A415PagCBCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A1473PagCBMon = (int)(NumberUtil.Val( GetPar( "PagCBMon"), "."));
            AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrimStr( (decimal)(A1473PagCBMon), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A1473PagCBMon) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A413PagMonCod = (int)(NumberUtil.Val( GetPar( "PagMonCod"), "."));
            AssignAttri("", false, "A413PagMonCod", StringUtil.LTrimStr( (decimal)(A413PagMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A413PagMonCod) ;
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
            Form.Meta.addItem("description", "Pagos - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tspagos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tspagos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Pagos - Cabecera", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_TSPAGOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSPAGOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagReg_Internalname, "Registro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagReg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A412PagReg), 10, 0, ".", "")), StringUtil.LTrim( ((edtPagReg_Enabled!=0) ? context.localUtil.Format( (decimal)(A412PagReg), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A412PagReg), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagReg_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagPrvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagPrvCod_Internalname, "Proveedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagPrvCod_Internalname, StringUtil.RTrim( A417PagPrvCod), StringUtil.RTrim( context.localUtil.Format( A417PagPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagFech_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagFech_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPagFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPagFech_Internalname, context.localUtil.Format(A418PagFech, "99/99/99"), context.localUtil.Format( A418PagFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_bitmap( context, edtPagFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPagFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSPAGOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagForCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagForCod_Internalname, "Forma de Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A416PagForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPagForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A416PagForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A416PagForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagBanCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagBanCod_Internalname, "Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A414PagBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPagBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A414PagBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A414PagBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagCBCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagCBCod_Internalname, "Cuenta Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagCBCod_Internalname, StringUtil.RTrim( A415PagCBCod), StringUtil.RTrim( context.localUtil.Format( A415PagCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A413PagMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPagMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A413PagMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A413PagMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagCheque_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagCheque_Internalname, "N° Cheque", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagCheque_Internalname, StringUtil.RTrim( A1475PagCheque), StringUtil.RTrim( context.localUtil.Format( A1475PagCheque, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagCheque_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagCheque_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagRegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagRegistro_Internalname, "Registro Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagRegistro_Internalname, StringUtil.RTrim( A1489PagRegistro), StringUtil.RTrim( context.localUtil.Format( A1489PagRegistro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagRegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagRegistro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagTItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagTItem_Internalname, "Total Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1492PagTItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtPagTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1492PagTItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1492PagTItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagTItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagTipCmb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagTipCmb_Internalname, "Tipo de Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1491PagTipCmb, 15, 5, ".", "")), StringUtil.LTrim( ((edtPagTipCmb_Enabled!=0) ? context.localUtil.Format( A1491PagTipCmb, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1491PagTipCmb, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagTipCmb_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagPago_Internalname, "Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A1487PagPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtPagPago_Enabled!=0) ? context.localUtil.Format( A1487PagPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1487PagPago, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagAjuste_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagAjuste_Internalname, "Ajuste", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagAjuste_Internalname, StringUtil.LTrim( StringUtil.NToC( A1471PagAjuste, 17, 2, ".", "")), StringUtil.LTrim( ((edtPagAjuste_Enabled!=0) ? context.localUtil.Format( A1471PagAjuste, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1471PagAjuste, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagAjuste_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagAjuste_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagTotal_Internalname, "Pago Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1493PagTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtPagTotal_Enabled!=0) ? context.localUtil.Format( A1493PagTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1493PagTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagVouAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1496PagVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtPagVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1496PagVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1496PagVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagVouMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1497PagVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtPagVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1497PagVouMes), "Z9") : context.localUtil.Format( (decimal)(A1497PagVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagTASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagTASICod_Internalname, "Tipo Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1490PagTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtPagTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1490PagTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1490PagTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagVouNum_Internalname, "N° Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagVouNum_Internalname, StringUtil.RTrim( A1498PagVouNum), StringUtil.RTrim( context.localUtil.Format( A1498PagVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagUsuC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagUsuC_Internalname, "Usuario Creación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagUsuC_Internalname, StringUtil.RTrim( A1494PagUsuC), StringUtil.RTrim( context.localUtil.Format( A1494PagUsuC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagUsuC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagUsuC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagFecC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagFecC_Internalname, "Fecha Creación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPagFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPagFecC_Internalname, context.localUtil.Format(A1482PagFecC, "99/99/99"), context.localUtil.Format( A1482PagFecC, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagFecC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagFecC_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_bitmap( context, edtPagFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPagFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSPAGOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagUsuM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagUsuM_Internalname, "Usuario Modifica", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPagUsuM_Internalname, StringUtil.RTrim( A1495PagUsuM), StringUtil.RTrim( context.localUtil.Format( A1495PagUsuM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagUsuM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagUsuM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagFecM_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagFecM_Internalname, "Fecha Modificación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPagFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPagFecM_Internalname, context.localUtil.Format(A1483PagFecM, "99/99/99"), context.localUtil.Format( A1483PagFecM, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagFecM_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_bitmap( context, edtPagFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPagFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSPAGOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagPrvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagPrvDsc_Internalname, "Pag Prv Dsc", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagPrvDsc_Internalname, StringUtil.RTrim( A1488PagPrvDsc), StringUtil.RTrim( context.localUtil.Format( A1488PagPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagForDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagForDsc_Internalname, "Forma de Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagForDsc_Internalname, StringUtil.RTrim( A1485PagForDsc), StringUtil.RTrim( context.localUtil.Format( A1485PagForDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagForDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagForDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagForBanSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagForBanSts_Internalname, "Afecta Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagForBanSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1484PagForBanSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtPagForBanSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1484PagForBanSts), "9") : context.localUtil.Format( (decimal)(A1484PagForBanSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagForBanSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagForBanSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagCBMon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagCBMon_Internalname, "Moneda Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagCBMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1473PagCBMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtPagCBMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A1473PagCBMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1473PagCBMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagCBMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagCBMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagMonDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagMonDsc_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagMonDsc_Internalname, StringUtil.RTrim( A1486PagMonDsc), StringUtil.RTrim( context.localUtil.Format( A1486PagMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagBanDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagBanDsc_Internalname, "Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagBanDsc_Internalname, StringUtil.RTrim( A1472PagBanDsc), StringUtil.RTrim( context.localUtil.Format( A1472PagBanDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagBanDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagBanDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPagCBMonDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPagCBMonDsc_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPagCBMonDsc_Internalname, StringUtil.RTrim( A1474PagCBMonDsc), StringUtil.RTrim( context.localUtil.Format( A1474PagCBMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPagCBMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPagCBMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSPAGOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 173,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSPAGOS.htm");
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
            Z412PagReg = (long)(context.localUtil.CToN( cgiGet( "Z412PagReg"), ".", ","));
            Z1493PagTotal = context.localUtil.CToN( cgiGet( "Z1493PagTotal"), ".", ",");
            Z418PagFech = context.localUtil.CToD( cgiGet( "Z418PagFech"), 0);
            Z1475PagCheque = cgiGet( "Z1475PagCheque");
            Z1489PagRegistro = cgiGet( "Z1489PagRegistro");
            Z1492PagTItem = (int)(context.localUtil.CToN( cgiGet( "Z1492PagTItem"), ".", ","));
            Z1491PagTipCmb = context.localUtil.CToN( cgiGet( "Z1491PagTipCmb"), ".", ",");
            Z1487PagPago = context.localUtil.CToN( cgiGet( "Z1487PagPago"), ".", ",");
            Z1471PagAjuste = context.localUtil.CToN( cgiGet( "Z1471PagAjuste"), ".", ",");
            Z1496PagVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1496PagVouAno"), ".", ","));
            Z1497PagVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1497PagVouMes"), ".", ","));
            Z1490PagTASICod = (int)(context.localUtil.CToN( cgiGet( "Z1490PagTASICod"), ".", ","));
            Z1498PagVouNum = cgiGet( "Z1498PagVouNum");
            Z1494PagUsuC = cgiGet( "Z1494PagUsuC");
            Z1482PagFecC = context.localUtil.CToD( cgiGet( "Z1482PagFecC"), 0);
            Z1495PagUsuM = cgiGet( "Z1495PagUsuM");
            Z1483PagFecM = context.localUtil.CToD( cgiGet( "Z1483PagFecM"), 0);
            Z417PagPrvCod = cgiGet( "Z417PagPrvCod");
            Z416PagForCod = (int)(context.localUtil.CToN( cgiGet( "Z416PagForCod"), ".", ","));
            Z414PagBanCod = (int)(context.localUtil.CToN( cgiGet( "Z414PagBanCod"), ".", ","));
            n414PagBanCod = ((0==A414PagBanCod) ? true : false);
            Z415PagCBCod = cgiGet( "Z415PagCBCod");
            n415PagCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A415PagCBCod)) ? true : false);
            Z413PagMonCod = (int)(context.localUtil.CToN( cgiGet( "Z413PagMonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagReg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagReg_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGREG");
               AnyError = 1;
               GX_FocusControl = edtPagReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A412PagReg = 0;
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            }
            else
            {
               A412PagReg = (long)(context.localUtil.CToN( cgiGet( edtPagReg_Internalname), ".", ","));
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            }
            A417PagPrvCod = StringUtil.Upper( cgiGet( edtPagPrvCod_Internalname));
            AssignAttri("", false, "A417PagPrvCod", A417PagPrvCod);
            if ( context.localUtil.VCDate( cgiGet( edtPagFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "PAGFECH");
               AnyError = 1;
               GX_FocusControl = edtPagFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A418PagFech = DateTime.MinValue;
               AssignAttri("", false, "A418PagFech", context.localUtil.Format(A418PagFech, "99/99/99"));
            }
            else
            {
               A418PagFech = context.localUtil.CToD( cgiGet( edtPagFech_Internalname), 2);
               AssignAttri("", false, "A418PagFech", context.localUtil.Format(A418PagFech, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGFORCOD");
               AnyError = 1;
               GX_FocusControl = edtPagForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A416PagForCod = 0;
               AssignAttri("", false, "A416PagForCod", StringUtil.LTrimStr( (decimal)(A416PagForCod), 6, 0));
            }
            else
            {
               A416PagForCod = (int)(context.localUtil.CToN( cgiGet( edtPagForCod_Internalname), ".", ","));
               AssignAttri("", false, "A416PagForCod", StringUtil.LTrimStr( (decimal)(A416PagForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGBANCOD");
               AnyError = 1;
               GX_FocusControl = edtPagBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A414PagBanCod = 0;
               n414PagBanCod = false;
               AssignAttri("", false, "A414PagBanCod", StringUtil.LTrimStr( (decimal)(A414PagBanCod), 6, 0));
            }
            else
            {
               A414PagBanCod = (int)(context.localUtil.CToN( cgiGet( edtPagBanCod_Internalname), ".", ","));
               n414PagBanCod = false;
               AssignAttri("", false, "A414PagBanCod", StringUtil.LTrimStr( (decimal)(A414PagBanCod), 6, 0));
            }
            n414PagBanCod = ((0==A414PagBanCod) ? true : false);
            A415PagCBCod = cgiGet( edtPagCBCod_Internalname);
            n415PagCBCod = false;
            AssignAttri("", false, "A415PagCBCod", A415PagCBCod);
            n415PagCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A415PagCBCod)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGMONCOD");
               AnyError = 1;
               GX_FocusControl = edtPagMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A413PagMonCod = 0;
               AssignAttri("", false, "A413PagMonCod", StringUtil.LTrimStr( (decimal)(A413PagMonCod), 6, 0));
            }
            else
            {
               A413PagMonCod = (int)(context.localUtil.CToN( cgiGet( edtPagMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A413PagMonCod", StringUtil.LTrimStr( (decimal)(A413PagMonCod), 6, 0));
            }
            A1475PagCheque = cgiGet( edtPagCheque_Internalname);
            AssignAttri("", false, "A1475PagCheque", A1475PagCheque);
            A1489PagRegistro = cgiGet( edtPagRegistro_Internalname);
            AssignAttri("", false, "A1489PagRegistro", A1489PagRegistro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagTItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGTITEM");
               AnyError = 1;
               GX_FocusControl = edtPagTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1492PagTItem = 0;
               AssignAttri("", false, "A1492PagTItem", StringUtil.LTrimStr( (decimal)(A1492PagTItem), 6, 0));
            }
            else
            {
               A1492PagTItem = (int)(context.localUtil.CToN( cgiGet( edtPagTItem_Internalname), ".", ","));
               AssignAttri("", false, "A1492PagTItem", StringUtil.LTrimStr( (decimal)(A1492PagTItem), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagTipCmb_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtPagTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1491PagTipCmb = 0;
               AssignAttri("", false, "A1491PagTipCmb", StringUtil.LTrimStr( A1491PagTipCmb, 15, 5));
            }
            else
            {
               A1491PagTipCmb = context.localUtil.CToN( cgiGet( edtPagTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1491PagTipCmb", StringUtil.LTrimStr( A1491PagTipCmb, 15, 5));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagPago_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPagPago_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGPAGO");
               AnyError = 1;
               GX_FocusControl = edtPagPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1487PagPago = 0;
               AssignAttri("", false, "A1487PagPago", StringUtil.LTrimStr( A1487PagPago, 15, 2));
            }
            else
            {
               A1487PagPago = context.localUtil.CToN( cgiGet( edtPagPago_Internalname), ".", ",");
               AssignAttri("", false, "A1487PagPago", StringUtil.LTrimStr( A1487PagPago, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagAjuste_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtPagAjuste_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGAJUSTE");
               AnyError = 1;
               GX_FocusControl = edtPagAjuste_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1471PagAjuste = 0;
               AssignAttri("", false, "A1471PagAjuste", StringUtil.LTrimStr( A1471PagAjuste, 15, 2));
            }
            else
            {
               A1471PagAjuste = context.localUtil.CToN( cgiGet( edtPagAjuste_Internalname), ".", ",");
               AssignAttri("", false, "A1471PagAjuste", StringUtil.LTrimStr( A1471PagAjuste, 15, 2));
            }
            A1493PagTotal = context.localUtil.CToN( cgiGet( edtPagTotal_Internalname), ".", ",");
            AssignAttri("", false, "A1493PagTotal", StringUtil.LTrimStr( A1493PagTotal, 15, 2));
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGVOUANO");
               AnyError = 1;
               GX_FocusControl = edtPagVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1496PagVouAno = 0;
               AssignAttri("", false, "A1496PagVouAno", StringUtil.LTrimStr( (decimal)(A1496PagVouAno), 4, 0));
            }
            else
            {
               A1496PagVouAno = (short)(context.localUtil.CToN( cgiGet( edtPagVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1496PagVouAno", StringUtil.LTrimStr( (decimal)(A1496PagVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGVOUMES");
               AnyError = 1;
               GX_FocusControl = edtPagVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1497PagVouMes = 0;
               AssignAttri("", false, "A1497PagVouMes", StringUtil.LTrimStr( (decimal)(A1497PagVouMes), 2, 0));
            }
            else
            {
               A1497PagVouMes = (short)(context.localUtil.CToN( cgiGet( edtPagVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1497PagVouMes", StringUtil.LTrimStr( (decimal)(A1497PagVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPagTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPagTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAGTASICOD");
               AnyError = 1;
               GX_FocusControl = edtPagTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1490PagTASICod = 0;
               AssignAttri("", false, "A1490PagTASICod", StringUtil.LTrimStr( (decimal)(A1490PagTASICod), 6, 0));
            }
            else
            {
               A1490PagTASICod = (int)(context.localUtil.CToN( cgiGet( edtPagTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A1490PagTASICod", StringUtil.LTrimStr( (decimal)(A1490PagTASICod), 6, 0));
            }
            A1498PagVouNum = cgiGet( edtPagVouNum_Internalname);
            AssignAttri("", false, "A1498PagVouNum", A1498PagVouNum);
            A1494PagUsuC = cgiGet( edtPagUsuC_Internalname);
            AssignAttri("", false, "A1494PagUsuC", A1494PagUsuC);
            if ( context.localUtil.VCDate( cgiGet( edtPagFecC_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Creación"}), 1, "PAGFECC");
               AnyError = 1;
               GX_FocusControl = edtPagFecC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1482PagFecC = DateTime.MinValue;
               AssignAttri("", false, "A1482PagFecC", context.localUtil.Format(A1482PagFecC, "99/99/99"));
            }
            else
            {
               A1482PagFecC = context.localUtil.CToD( cgiGet( edtPagFecC_Internalname), 2);
               AssignAttri("", false, "A1482PagFecC", context.localUtil.Format(A1482PagFecC, "99/99/99"));
            }
            A1495PagUsuM = cgiGet( edtPagUsuM_Internalname);
            AssignAttri("", false, "A1495PagUsuM", A1495PagUsuM);
            if ( context.localUtil.VCDate( cgiGet( edtPagFecM_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Modificación"}), 1, "PAGFECM");
               AnyError = 1;
               GX_FocusControl = edtPagFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1483PagFecM = DateTime.MinValue;
               AssignAttri("", false, "A1483PagFecM", context.localUtil.Format(A1483PagFecM, "99/99/99"));
            }
            else
            {
               A1483PagFecM = context.localUtil.CToD( cgiGet( edtPagFecM_Internalname), 2);
               AssignAttri("", false, "A1483PagFecM", context.localUtil.Format(A1483PagFecM, "99/99/99"));
            }
            A1488PagPrvDsc = cgiGet( edtPagPrvDsc_Internalname);
            AssignAttri("", false, "A1488PagPrvDsc", A1488PagPrvDsc);
            A1485PagForDsc = cgiGet( edtPagForDsc_Internalname);
            AssignAttri("", false, "A1485PagForDsc", A1485PagForDsc);
            A1484PagForBanSts = (short)(context.localUtil.CToN( cgiGet( edtPagForBanSts_Internalname), ".", ","));
            AssignAttri("", false, "A1484PagForBanSts", StringUtil.Str( (decimal)(A1484PagForBanSts), 1, 0));
            A1473PagCBMon = (int)(context.localUtil.CToN( cgiGet( edtPagCBMon_Internalname), ".", ","));
            AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrimStr( (decimal)(A1473PagCBMon), 6, 0));
            A1486PagMonDsc = cgiGet( edtPagMonDsc_Internalname);
            AssignAttri("", false, "A1486PagMonDsc", A1486PagMonDsc);
            A1472PagBanDsc = cgiGet( edtPagBanDsc_Internalname);
            AssignAttri("", false, "A1472PagBanDsc", A1472PagBanDsc);
            A1474PagCBMonDsc = cgiGet( edtPagCBMonDsc_Internalname);
            AssignAttri("", false, "A1474PagCBMonDsc", A1474PagCBMonDsc);
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
               A412PagReg = (long)(NumberUtil.Val( GetPar( "PagReg"), "."));
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
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
               InitAll5D180( ) ;
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
         DisableAttributes5D180( ) ;
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

      protected void ResetCaption5D0( )
      {
      }

      protected void ZM5D180( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1493PagTotal = T005D3_A1493PagTotal[0];
               Z418PagFech = T005D3_A418PagFech[0];
               Z1475PagCheque = T005D3_A1475PagCheque[0];
               Z1489PagRegistro = T005D3_A1489PagRegistro[0];
               Z1492PagTItem = T005D3_A1492PagTItem[0];
               Z1491PagTipCmb = T005D3_A1491PagTipCmb[0];
               Z1487PagPago = T005D3_A1487PagPago[0];
               Z1471PagAjuste = T005D3_A1471PagAjuste[0];
               Z1496PagVouAno = T005D3_A1496PagVouAno[0];
               Z1497PagVouMes = T005D3_A1497PagVouMes[0];
               Z1490PagTASICod = T005D3_A1490PagTASICod[0];
               Z1498PagVouNum = T005D3_A1498PagVouNum[0];
               Z1494PagUsuC = T005D3_A1494PagUsuC[0];
               Z1482PagFecC = T005D3_A1482PagFecC[0];
               Z1495PagUsuM = T005D3_A1495PagUsuM[0];
               Z1483PagFecM = T005D3_A1483PagFecM[0];
               Z417PagPrvCod = T005D3_A417PagPrvCod[0];
               Z416PagForCod = T005D3_A416PagForCod[0];
               Z414PagBanCod = T005D3_A414PagBanCod[0];
               Z415PagCBCod = T005D3_A415PagCBCod[0];
               Z413PagMonCod = T005D3_A413PagMonCod[0];
            }
            else
            {
               Z1493PagTotal = A1493PagTotal;
               Z418PagFech = A418PagFech;
               Z1475PagCheque = A1475PagCheque;
               Z1489PagRegistro = A1489PagRegistro;
               Z1492PagTItem = A1492PagTItem;
               Z1491PagTipCmb = A1491PagTipCmb;
               Z1487PagPago = A1487PagPago;
               Z1471PagAjuste = A1471PagAjuste;
               Z1496PagVouAno = A1496PagVouAno;
               Z1497PagVouMes = A1497PagVouMes;
               Z1490PagTASICod = A1490PagTASICod;
               Z1498PagVouNum = A1498PagVouNum;
               Z1494PagUsuC = A1494PagUsuC;
               Z1482PagFecC = A1482PagFecC;
               Z1495PagUsuM = A1495PagUsuM;
               Z1483PagFecM = A1483PagFecM;
               Z417PagPrvCod = A417PagPrvCod;
               Z416PagForCod = A416PagForCod;
               Z414PagBanCod = A414PagBanCod;
               Z415PagCBCod = A415PagCBCod;
               Z413PagMonCod = A413PagMonCod;
            }
         }
         if ( GX_JID == -5 )
         {
            Z1493PagTotal = A1493PagTotal;
            Z412PagReg = A412PagReg;
            Z418PagFech = A418PagFech;
            Z1475PagCheque = A1475PagCheque;
            Z1489PagRegistro = A1489PagRegistro;
            Z1492PagTItem = A1492PagTItem;
            Z1491PagTipCmb = A1491PagTipCmb;
            Z1487PagPago = A1487PagPago;
            Z1471PagAjuste = A1471PagAjuste;
            Z1496PagVouAno = A1496PagVouAno;
            Z1497PagVouMes = A1497PagVouMes;
            Z1490PagTASICod = A1490PagTASICod;
            Z1498PagVouNum = A1498PagVouNum;
            Z1494PagUsuC = A1494PagUsuC;
            Z1482PagFecC = A1482PagFecC;
            Z1495PagUsuM = A1495PagUsuM;
            Z1483PagFecM = A1483PagFecM;
            Z417PagPrvCod = A417PagPrvCod;
            Z416PagForCod = A416PagForCod;
            Z414PagBanCod = A414PagBanCod;
            Z415PagCBCod = A415PagCBCod;
            Z413PagMonCod = A413PagMonCod;
            Z1488PagPrvDsc = A1488PagPrvDsc;
            Z1485PagForDsc = A1485PagForDsc;
            Z1484PagForBanSts = A1484PagForBanSts;
            Z1472PagBanDsc = A1472PagBanDsc;
            Z1473PagCBMon = A1473PagCBMon;
            Z1474PagCBMonDsc = A1474PagCBMonDsc;
            Z1486PagMonDsc = A1486PagMonDsc;
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

      protected void Load5D180( )
      {
         /* Using cursor T005D10 */
         pr_default.execute(8, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound180 = 1;
            A1493PagTotal = T005D10_A1493PagTotal[0];
            AssignAttri("", false, "A1493PagTotal", StringUtil.LTrimStr( A1493PagTotal, 15, 2));
            A418PagFech = T005D10_A418PagFech[0];
            AssignAttri("", false, "A418PagFech", context.localUtil.Format(A418PagFech, "99/99/99"));
            A1475PagCheque = T005D10_A1475PagCheque[0];
            AssignAttri("", false, "A1475PagCheque", A1475PagCheque);
            A1489PagRegistro = T005D10_A1489PagRegistro[0];
            AssignAttri("", false, "A1489PagRegistro", A1489PagRegistro);
            A1492PagTItem = T005D10_A1492PagTItem[0];
            AssignAttri("", false, "A1492PagTItem", StringUtil.LTrimStr( (decimal)(A1492PagTItem), 6, 0));
            A1491PagTipCmb = T005D10_A1491PagTipCmb[0];
            AssignAttri("", false, "A1491PagTipCmb", StringUtil.LTrimStr( A1491PagTipCmb, 15, 5));
            A1487PagPago = T005D10_A1487PagPago[0];
            AssignAttri("", false, "A1487PagPago", StringUtil.LTrimStr( A1487PagPago, 15, 2));
            A1471PagAjuste = T005D10_A1471PagAjuste[0];
            AssignAttri("", false, "A1471PagAjuste", StringUtil.LTrimStr( A1471PagAjuste, 15, 2));
            A1496PagVouAno = T005D10_A1496PagVouAno[0];
            AssignAttri("", false, "A1496PagVouAno", StringUtil.LTrimStr( (decimal)(A1496PagVouAno), 4, 0));
            A1497PagVouMes = T005D10_A1497PagVouMes[0];
            AssignAttri("", false, "A1497PagVouMes", StringUtil.LTrimStr( (decimal)(A1497PagVouMes), 2, 0));
            A1490PagTASICod = T005D10_A1490PagTASICod[0];
            AssignAttri("", false, "A1490PagTASICod", StringUtil.LTrimStr( (decimal)(A1490PagTASICod), 6, 0));
            A1498PagVouNum = T005D10_A1498PagVouNum[0];
            AssignAttri("", false, "A1498PagVouNum", A1498PagVouNum);
            A1494PagUsuC = T005D10_A1494PagUsuC[0];
            AssignAttri("", false, "A1494PagUsuC", A1494PagUsuC);
            A1482PagFecC = T005D10_A1482PagFecC[0];
            AssignAttri("", false, "A1482PagFecC", context.localUtil.Format(A1482PagFecC, "99/99/99"));
            A1495PagUsuM = T005D10_A1495PagUsuM[0];
            AssignAttri("", false, "A1495PagUsuM", A1495PagUsuM);
            A1483PagFecM = T005D10_A1483PagFecM[0];
            AssignAttri("", false, "A1483PagFecM", context.localUtil.Format(A1483PagFecM, "99/99/99"));
            A1488PagPrvDsc = T005D10_A1488PagPrvDsc[0];
            AssignAttri("", false, "A1488PagPrvDsc", A1488PagPrvDsc);
            A1485PagForDsc = T005D10_A1485PagForDsc[0];
            AssignAttri("", false, "A1485PagForDsc", A1485PagForDsc);
            A1484PagForBanSts = T005D10_A1484PagForBanSts[0];
            AssignAttri("", false, "A1484PagForBanSts", StringUtil.Str( (decimal)(A1484PagForBanSts), 1, 0));
            A1486PagMonDsc = T005D10_A1486PagMonDsc[0];
            AssignAttri("", false, "A1486PagMonDsc", A1486PagMonDsc);
            A1472PagBanDsc = T005D10_A1472PagBanDsc[0];
            AssignAttri("", false, "A1472PagBanDsc", A1472PagBanDsc);
            A1474PagCBMonDsc = T005D10_A1474PagCBMonDsc[0];
            AssignAttri("", false, "A1474PagCBMonDsc", A1474PagCBMonDsc);
            A417PagPrvCod = T005D10_A417PagPrvCod[0];
            AssignAttri("", false, "A417PagPrvCod", A417PagPrvCod);
            A416PagForCod = T005D10_A416PagForCod[0];
            AssignAttri("", false, "A416PagForCod", StringUtil.LTrimStr( (decimal)(A416PagForCod), 6, 0));
            A414PagBanCod = T005D10_A414PagBanCod[0];
            n414PagBanCod = T005D10_n414PagBanCod[0];
            AssignAttri("", false, "A414PagBanCod", StringUtil.LTrimStr( (decimal)(A414PagBanCod), 6, 0));
            A415PagCBCod = T005D10_A415PagCBCod[0];
            n415PagCBCod = T005D10_n415PagCBCod[0];
            AssignAttri("", false, "A415PagCBCod", A415PagCBCod);
            A413PagMonCod = T005D10_A413PagMonCod[0];
            AssignAttri("", false, "A413PagMonCod", StringUtil.LTrimStr( (decimal)(A413PagMonCod), 6, 0));
            A1473PagCBMon = T005D10_A1473PagCBMon[0];
            AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrimStr( (decimal)(A1473PagCBMon), 6, 0));
            ZM5D180( -5) ;
         }
         pr_default.close(8);
         OnLoadActions5D180( ) ;
      }

      protected void OnLoadActions5D180( )
      {
         A1493PagTotal = (decimal)(A1487PagPago+A1471PagAjuste);
         AssignAttri("", false, "A1493PagTotal", StringUtil.LTrimStr( A1493PagTotal, 15, 2));
      }

      protected void CheckExtendedTable5D180( )
      {
         nIsDirty_180 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T005D4 */
         pr_default.execute(2, new Object[] {A417PagPrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Pagos Proveedor'.", "ForeignKeyNotFound", 1, "PAGPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPagPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1488PagPrvDsc = T005D4_A1488PagPrvDsc[0];
         AssignAttri("", false, "A1488PagPrvDsc", A1488PagPrvDsc);
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A418PagFech) || ( DateTimeUtil.ResetTime ( A418PagFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "PAGFECH");
            AnyError = 1;
            GX_FocusControl = edtPagFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005D5 */
         pr_default.execute(3, new Object[] {A416PagForCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de pago'.", "ForeignKeyNotFound", 1, "PAGFORCOD");
            AnyError = 1;
            GX_FocusControl = edtPagForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1485PagForDsc = T005D5_A1485PagForDsc[0];
         AssignAttri("", false, "A1485PagForDsc", A1485PagForDsc);
         A1484PagForBanSts = T005D5_A1484PagForBanSts[0];
         AssignAttri("", false, "A1484PagForBanSts", StringUtil.Str( (decimal)(A1484PagForBanSts), 1, 0));
         pr_default.close(3);
         /* Using cursor T005D6 */
         pr_default.execute(4, new Object[] {n414PagBanCod, A414PagBanCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A414PagBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGBANCOD");
               AnyError = 1;
               GX_FocusControl = edtPagBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1472PagBanDsc = T005D6_A1472PagBanDsc[0];
         AssignAttri("", false, "A1472PagBanDsc", A1472PagBanDsc);
         pr_default.close(4);
         /* Using cursor T005D7 */
         pr_default.execute(5, new Object[] {n414PagBanCod, A414PagBanCod, n415PagCBCod, A415PagCBCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A414PagBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A415PagCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGCBCOD");
               AnyError = 1;
               GX_FocusControl = edtPagBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1473PagCBMon = T005D7_A1473PagCBMon[0];
         AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrimStr( (decimal)(A1473PagCBMon), 6, 0));
         pr_default.close(5);
         /* Using cursor T005D9 */
         pr_default.execute(7, new Object[] {A1473PagCBMon});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A1473PagCBMon) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGCBMON");
               AnyError = 1;
            }
         }
         A1474PagCBMonDsc = T005D9_A1474PagCBMonDsc[0];
         AssignAttri("", false, "A1474PagCBMonDsc", A1474PagCBMonDsc);
         pr_default.close(7);
         /* Using cursor T005D8 */
         pr_default.execute(6, new Object[] {A413PagMonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "PAGMONCOD");
            AnyError = 1;
            GX_FocusControl = edtPagMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1486PagMonDsc = T005D8_A1486PagMonDsc[0];
         AssignAttri("", false, "A1486PagMonDsc", A1486PagMonDsc);
         pr_default.close(6);
         nIsDirty_180 = 1;
         A1493PagTotal = (decimal)(A1487PagPago+A1471PagAjuste);
         AssignAttri("", false, "A1493PagTotal", StringUtil.LTrimStr( A1493PagTotal, 15, 2));
         if ( ! ( (DateTime.MinValue==A1482PagFecC) || ( DateTimeUtil.ResetTime ( A1482PagFecC ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Creación fuera de rango", "OutOfRange", 1, "PAGFECC");
            AnyError = 1;
            GX_FocusControl = edtPagFecC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1483PagFecM) || ( DateTimeUtil.ResetTime ( A1483PagFecM ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Modificación fuera de rango", "OutOfRange", 1, "PAGFECM");
            AnyError = 1;
            GX_FocusControl = edtPagFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5D180( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(7);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( string A417PagPrvCod )
      {
         /* Using cursor T005D11 */
         pr_default.execute(9, new Object[] {A417PagPrvCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Pagos Proveedor'.", "ForeignKeyNotFound", 1, "PAGPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPagPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1488PagPrvDsc = T005D11_A1488PagPrvDsc[0];
         AssignAttri("", false, "A1488PagPrvDsc", A1488PagPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1488PagPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_7( int A416PagForCod )
      {
         /* Using cursor T005D12 */
         pr_default.execute(10, new Object[] {A416PagForCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de pago'.", "ForeignKeyNotFound", 1, "PAGFORCOD");
            AnyError = 1;
            GX_FocusControl = edtPagForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1485PagForDsc = T005D12_A1485PagForDsc[0];
         AssignAttri("", false, "A1485PagForDsc", A1485PagForDsc);
         A1484PagForBanSts = T005D12_A1484PagForBanSts[0];
         AssignAttri("", false, "A1484PagForBanSts", StringUtil.Str( (decimal)(A1484PagForBanSts), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1485PagForDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1484PagForBanSts), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_8( int A414PagBanCod )
      {
         /* Using cursor T005D13 */
         pr_default.execute(11, new Object[] {n414PagBanCod, A414PagBanCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( (0==A414PagBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGBANCOD");
               AnyError = 1;
               GX_FocusControl = edtPagBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1472PagBanDsc = T005D13_A1472PagBanDsc[0];
         AssignAttri("", false, "A1472PagBanDsc", A1472PagBanDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1472PagBanDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_9( int A414PagBanCod ,
                               string A415PagCBCod )
      {
         /* Using cursor T005D14 */
         pr_default.execute(12, new Object[] {n414PagBanCod, A414PagBanCod, n415PagCBCod, A415PagCBCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A414PagBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A415PagCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGCBCOD");
               AnyError = 1;
               GX_FocusControl = edtPagBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1473PagCBMon = T005D14_A1473PagCBMon[0];
         AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrimStr( (decimal)(A1473PagCBMon), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1473PagCBMon), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_11( int A1473PagCBMon )
      {
         /* Using cursor T005D15 */
         pr_default.execute(13, new Object[] {A1473PagCBMon});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A1473PagCBMon) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGCBMON");
               AnyError = 1;
            }
         }
         A1474PagCBMonDsc = T005D15_A1474PagCBMonDsc[0];
         AssignAttri("", false, "A1474PagCBMonDsc", A1474PagCBMonDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1474PagCBMonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_10( int A413PagMonCod )
      {
         /* Using cursor T005D16 */
         pr_default.execute(14, new Object[] {A413PagMonCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "PAGMONCOD");
            AnyError = 1;
            GX_FocusControl = edtPagMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1486PagMonDsc = T005D16_A1486PagMonDsc[0];
         AssignAttri("", false, "A1486PagMonDsc", A1486PagMonDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1486PagMonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey5D180( )
      {
         /* Using cursor T005D17 */
         pr_default.execute(15, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound180 = 1;
         }
         else
         {
            RcdFound180 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005D3 */
         pr_default.execute(1, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5D180( 5) ;
            RcdFound180 = 1;
            A1493PagTotal = T005D3_A1493PagTotal[0];
            AssignAttri("", false, "A1493PagTotal", StringUtil.LTrimStr( A1493PagTotal, 15, 2));
            A412PagReg = T005D3_A412PagReg[0];
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            A418PagFech = T005D3_A418PagFech[0];
            AssignAttri("", false, "A418PagFech", context.localUtil.Format(A418PagFech, "99/99/99"));
            A1475PagCheque = T005D3_A1475PagCheque[0];
            AssignAttri("", false, "A1475PagCheque", A1475PagCheque);
            A1489PagRegistro = T005D3_A1489PagRegistro[0];
            AssignAttri("", false, "A1489PagRegistro", A1489PagRegistro);
            A1492PagTItem = T005D3_A1492PagTItem[0];
            AssignAttri("", false, "A1492PagTItem", StringUtil.LTrimStr( (decimal)(A1492PagTItem), 6, 0));
            A1491PagTipCmb = T005D3_A1491PagTipCmb[0];
            AssignAttri("", false, "A1491PagTipCmb", StringUtil.LTrimStr( A1491PagTipCmb, 15, 5));
            A1487PagPago = T005D3_A1487PagPago[0];
            AssignAttri("", false, "A1487PagPago", StringUtil.LTrimStr( A1487PagPago, 15, 2));
            A1471PagAjuste = T005D3_A1471PagAjuste[0];
            AssignAttri("", false, "A1471PagAjuste", StringUtil.LTrimStr( A1471PagAjuste, 15, 2));
            A1496PagVouAno = T005D3_A1496PagVouAno[0];
            AssignAttri("", false, "A1496PagVouAno", StringUtil.LTrimStr( (decimal)(A1496PagVouAno), 4, 0));
            A1497PagVouMes = T005D3_A1497PagVouMes[0];
            AssignAttri("", false, "A1497PagVouMes", StringUtil.LTrimStr( (decimal)(A1497PagVouMes), 2, 0));
            A1490PagTASICod = T005D3_A1490PagTASICod[0];
            AssignAttri("", false, "A1490PagTASICod", StringUtil.LTrimStr( (decimal)(A1490PagTASICod), 6, 0));
            A1498PagVouNum = T005D3_A1498PagVouNum[0];
            AssignAttri("", false, "A1498PagVouNum", A1498PagVouNum);
            A1494PagUsuC = T005D3_A1494PagUsuC[0];
            AssignAttri("", false, "A1494PagUsuC", A1494PagUsuC);
            A1482PagFecC = T005D3_A1482PagFecC[0];
            AssignAttri("", false, "A1482PagFecC", context.localUtil.Format(A1482PagFecC, "99/99/99"));
            A1495PagUsuM = T005D3_A1495PagUsuM[0];
            AssignAttri("", false, "A1495PagUsuM", A1495PagUsuM);
            A1483PagFecM = T005D3_A1483PagFecM[0];
            AssignAttri("", false, "A1483PagFecM", context.localUtil.Format(A1483PagFecM, "99/99/99"));
            A417PagPrvCod = T005D3_A417PagPrvCod[0];
            AssignAttri("", false, "A417PagPrvCod", A417PagPrvCod);
            A416PagForCod = T005D3_A416PagForCod[0];
            AssignAttri("", false, "A416PagForCod", StringUtil.LTrimStr( (decimal)(A416PagForCod), 6, 0));
            A414PagBanCod = T005D3_A414PagBanCod[0];
            n414PagBanCod = T005D3_n414PagBanCod[0];
            AssignAttri("", false, "A414PagBanCod", StringUtil.LTrimStr( (decimal)(A414PagBanCod), 6, 0));
            A415PagCBCod = T005D3_A415PagCBCod[0];
            n415PagCBCod = T005D3_n415PagCBCod[0];
            AssignAttri("", false, "A415PagCBCod", A415PagCBCod);
            A413PagMonCod = T005D3_A413PagMonCod[0];
            AssignAttri("", false, "A413PagMonCod", StringUtil.LTrimStr( (decimal)(A413PagMonCod), 6, 0));
            Z412PagReg = A412PagReg;
            sMode180 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load5D180( ) ;
            if ( AnyError == 1 )
            {
               RcdFound180 = 0;
               InitializeNonKey5D180( ) ;
            }
            Gx_mode = sMode180;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound180 = 0;
            InitializeNonKey5D180( ) ;
            sMode180 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode180;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5D180( ) ;
         if ( RcdFound180 == 0 )
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
         RcdFound180 = 0;
         /* Using cursor T005D18 */
         pr_default.execute(16, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( T005D18_A412PagReg[0] < A412PagReg ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( T005D18_A412PagReg[0] > A412PagReg ) ) )
            {
               A412PagReg = T005D18_A412PagReg[0];
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
               RcdFound180 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound180 = 0;
         /* Using cursor T005D19 */
         pr_default.execute(17, new Object[] {A412PagReg});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( T005D19_A412PagReg[0] > A412PagReg ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( T005D19_A412PagReg[0] < A412PagReg ) ) )
            {
               A412PagReg = T005D19_A412PagReg[0];
               AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
               RcdFound180 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5D180( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5D180( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound180 == 1 )
            {
               if ( A412PagReg != Z412PagReg )
               {
                  A412PagReg = Z412PagReg;
                  AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PAGREG");
                  AnyError = 1;
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update5D180( ) ;
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A412PagReg != Z412PagReg )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPagReg_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5D180( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PAGREG");
                     AnyError = 1;
                     GX_FocusControl = edtPagReg_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPagReg_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5D180( ) ;
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
         if ( A412PagReg != Z412PagReg )
         {
            A412PagReg = Z412PagReg;
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPagReg_Internalname;
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
         if ( RcdFound180 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PAGREG");
            AnyError = 1;
            GX_FocusControl = edtPagReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtPagPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart5D180( ) ;
         if ( RcdFound180 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5D180( ) ;
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
         if ( RcdFound180 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagPrvCod_Internalname;
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
         if ( RcdFound180 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagPrvCod_Internalname;
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
         ScanStart5D180( ) ;
         if ( RcdFound180 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound180 != 0 )
            {
               ScanNext5D180( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtPagPrvCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5D180( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency5D180( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005D2 */
            pr_default.execute(0, new Object[] {A412PagReg});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSPAGOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z1493PagTotal != T005D2_A1493PagTotal[0] ) || ( DateTimeUtil.ResetTime ( Z418PagFech ) != DateTimeUtil.ResetTime ( T005D2_A418PagFech[0] ) ) || ( StringUtil.StrCmp(Z1475PagCheque, T005D2_A1475PagCheque[0]) != 0 ) || ( StringUtil.StrCmp(Z1489PagRegistro, T005D2_A1489PagRegistro[0]) != 0 ) || ( Z1492PagTItem != T005D2_A1492PagTItem[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1491PagTipCmb != T005D2_A1491PagTipCmb[0] ) || ( Z1487PagPago != T005D2_A1487PagPago[0] ) || ( Z1471PagAjuste != T005D2_A1471PagAjuste[0] ) || ( Z1496PagVouAno != T005D2_A1496PagVouAno[0] ) || ( Z1497PagVouMes != T005D2_A1497PagVouMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1490PagTASICod != T005D2_A1490PagTASICod[0] ) || ( StringUtil.StrCmp(Z1498PagVouNum, T005D2_A1498PagVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1494PagUsuC, T005D2_A1494PagUsuC[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1482PagFecC ) != DateTimeUtil.ResetTime ( T005D2_A1482PagFecC[0] ) ) || ( StringUtil.StrCmp(Z1495PagUsuM, T005D2_A1495PagUsuM[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( DateTimeUtil.ResetTime ( Z1483PagFecM ) != DateTimeUtil.ResetTime ( T005D2_A1483PagFecM[0] ) ) || ( StringUtil.StrCmp(Z417PagPrvCod, T005D2_A417PagPrvCod[0]) != 0 ) || ( Z416PagForCod != T005D2_A416PagForCod[0] ) || ( Z414PagBanCod != T005D2_A414PagBanCod[0] ) || ( StringUtil.StrCmp(Z415PagCBCod, T005D2_A415PagCBCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z413PagMonCod != T005D2_A413PagMonCod[0] ) )
            {
               if ( Z1493PagTotal != T005D2_A1493PagTotal[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagTotal");
                  GXUtil.WriteLogRaw("Old: ",Z1493PagTotal);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1493PagTotal[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z418PagFech ) != DateTimeUtil.ResetTime ( T005D2_A418PagFech[0] ) )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagFech");
                  GXUtil.WriteLogRaw("Old: ",Z418PagFech);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A418PagFech[0]);
               }
               if ( StringUtil.StrCmp(Z1475PagCheque, T005D2_A1475PagCheque[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagCheque");
                  GXUtil.WriteLogRaw("Old: ",Z1475PagCheque);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1475PagCheque[0]);
               }
               if ( StringUtil.StrCmp(Z1489PagRegistro, T005D2_A1489PagRegistro[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagRegistro");
                  GXUtil.WriteLogRaw("Old: ",Z1489PagRegistro);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1489PagRegistro[0]);
               }
               if ( Z1492PagTItem != T005D2_A1492PagTItem[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagTItem");
                  GXUtil.WriteLogRaw("Old: ",Z1492PagTItem);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1492PagTItem[0]);
               }
               if ( Z1491PagTipCmb != T005D2_A1491PagTipCmb[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1491PagTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1491PagTipCmb[0]);
               }
               if ( Z1487PagPago != T005D2_A1487PagPago[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagPago");
                  GXUtil.WriteLogRaw("Old: ",Z1487PagPago);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1487PagPago[0]);
               }
               if ( Z1471PagAjuste != T005D2_A1471PagAjuste[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagAjuste");
                  GXUtil.WriteLogRaw("Old: ",Z1471PagAjuste);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1471PagAjuste[0]);
               }
               if ( Z1496PagVouAno != T005D2_A1496PagVouAno[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1496PagVouAno);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1496PagVouAno[0]);
               }
               if ( Z1497PagVouMes != T005D2_A1497PagVouMes[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1497PagVouMes);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1497PagVouMes[0]);
               }
               if ( Z1490PagTASICod != T005D2_A1490PagTASICod[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z1490PagTASICod);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1490PagTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z1498PagVouNum, T005D2_A1498PagVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1498PagVouNum);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1498PagVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1494PagUsuC, T005D2_A1494PagUsuC[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagUsuC");
                  GXUtil.WriteLogRaw("Old: ",Z1494PagUsuC);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1494PagUsuC[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1482PagFecC ) != DateTimeUtil.ResetTime ( T005D2_A1482PagFecC[0] ) )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagFecC");
                  GXUtil.WriteLogRaw("Old: ",Z1482PagFecC);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1482PagFecC[0]);
               }
               if ( StringUtil.StrCmp(Z1495PagUsuM, T005D2_A1495PagUsuM[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagUsuM");
                  GXUtil.WriteLogRaw("Old: ",Z1495PagUsuM);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1495PagUsuM[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1483PagFecM ) != DateTimeUtil.ResetTime ( T005D2_A1483PagFecM[0] ) )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagFecM");
                  GXUtil.WriteLogRaw("Old: ",Z1483PagFecM);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A1483PagFecM[0]);
               }
               if ( StringUtil.StrCmp(Z417PagPrvCod, T005D2_A417PagPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z417PagPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A417PagPrvCod[0]);
               }
               if ( Z416PagForCod != T005D2_A416PagForCod[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagForCod");
                  GXUtil.WriteLogRaw("Old: ",Z416PagForCod);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A416PagForCod[0]);
               }
               if ( Z414PagBanCod != T005D2_A414PagBanCod[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z414PagBanCod);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A414PagBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z415PagCBCod, T005D2_A415PagCBCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagCBCod");
                  GXUtil.WriteLogRaw("Old: ",Z415PagCBCod);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A415PagCBCod[0]);
               }
               if ( Z413PagMonCod != T005D2_A413PagMonCod[0] )
               {
                  GXUtil.WriteLog("tspagos:[seudo value changed for attri]"+"PagMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z413PagMonCod);
                  GXUtil.WriteLogRaw("Current: ",T005D2_A413PagMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSPAGOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5D180( )
      {
         BeforeValidate5D180( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5D180( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5D180( 0) ;
            CheckOptimisticConcurrency5D180( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5D180( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5D180( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005D20 */
                     pr_default.execute(18, new Object[] {A1493PagTotal, A412PagReg, A418PagFech, A1475PagCheque, A1489PagRegistro, A1492PagTItem, A1491PagTipCmb, A1487PagPago, A1471PagAjuste, A1496PagVouAno, A1497PagVouMes, A1490PagTASICod, A1498PagVouNum, A1494PagUsuC, A1482PagFecC, A1495PagUsuM, A1483PagFecM, A417PagPrvCod, A416PagForCod, n414PagBanCod, A414PagBanCod, n415PagCBCod, A415PagCBCod, A413PagMonCod});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("TSPAGOS");
                     if ( (pr_default.getStatus(18) == 1) )
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
                           ResetCaption5D0( ) ;
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
               Load5D180( ) ;
            }
            EndLevel5D180( ) ;
         }
         CloseExtendedTableCursors5D180( ) ;
      }

      protected void Update5D180( )
      {
         BeforeValidate5D180( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5D180( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5D180( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5D180( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5D180( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005D21 */
                     pr_default.execute(19, new Object[] {A1493PagTotal, A418PagFech, A1475PagCheque, A1489PagRegistro, A1492PagTItem, A1491PagTipCmb, A1487PagPago, A1471PagAjuste, A1496PagVouAno, A1497PagVouMes, A1490PagTASICod, A1498PagVouNum, A1494PagUsuC, A1482PagFecC, A1495PagUsuM, A1483PagFecM, A417PagPrvCod, A416PagForCod, n414PagBanCod, A414PagBanCod, n415PagCBCod, A415PagCBCod, A413PagMonCod, A412PagReg});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("TSPAGOS");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSPAGOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5D180( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption5D0( ) ;
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
            EndLevel5D180( ) ;
         }
         CloseExtendedTableCursors5D180( ) ;
      }

      protected void DeferredUpdate5D180( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate5D180( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5D180( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5D180( ) ;
            AfterConfirm5D180( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5D180( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005D22 */
                  pr_default.execute(20, new Object[] {A412PagReg});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("TSPAGOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound180 == 0 )
                        {
                           InitAll5D180( ) ;
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
                        ResetCaption5D0( ) ;
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
         sMode180 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5D180( ) ;
         Gx_mode = sMode180;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5D180( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005D23 */
            pr_default.execute(21, new Object[] {A417PagPrvCod});
            A1488PagPrvDsc = T005D23_A1488PagPrvDsc[0];
            AssignAttri("", false, "A1488PagPrvDsc", A1488PagPrvDsc);
            pr_default.close(21);
            /* Using cursor T005D24 */
            pr_default.execute(22, new Object[] {A416PagForCod});
            A1485PagForDsc = T005D24_A1485PagForDsc[0];
            AssignAttri("", false, "A1485PagForDsc", A1485PagForDsc);
            A1484PagForBanSts = T005D24_A1484PagForBanSts[0];
            AssignAttri("", false, "A1484PagForBanSts", StringUtil.Str( (decimal)(A1484PagForBanSts), 1, 0));
            pr_default.close(22);
            /* Using cursor T005D25 */
            pr_default.execute(23, new Object[] {n414PagBanCod, A414PagBanCod});
            A1472PagBanDsc = T005D25_A1472PagBanDsc[0];
            AssignAttri("", false, "A1472PagBanDsc", A1472PagBanDsc);
            pr_default.close(23);
            /* Using cursor T005D26 */
            pr_default.execute(24, new Object[] {n414PagBanCod, A414PagBanCod, n415PagCBCod, A415PagCBCod});
            A1473PagCBMon = T005D26_A1473PagCBMon[0];
            AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrimStr( (decimal)(A1473PagCBMon), 6, 0));
            pr_default.close(24);
            /* Using cursor T005D27 */
            pr_default.execute(25, new Object[] {A1473PagCBMon});
            A1474PagCBMonDsc = T005D27_A1474PagCBMonDsc[0];
            AssignAttri("", false, "A1474PagCBMonDsc", A1474PagCBMonDsc);
            pr_default.close(25);
            /* Using cursor T005D28 */
            pr_default.execute(26, new Object[] {A413PagMonCod});
            A1486PagMonDsc = T005D28_A1486PagMonDsc[0];
            AssignAttri("", false, "A1486PagMonDsc", A1486PagMonDsc);
            pr_default.close(26);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T005D29 */
            pr_default.execute(27, new Object[] {A412PagReg});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Pagos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
         }
      }

      protected void EndLevel5D180( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5D180( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(26);
            pr_default.close(25);
            context.CommitDataStores("tspagos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(21);
            pr_default.close(22);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(26);
            pr_default.close(25);
            context.RollbackDataStores("tspagos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5D180( )
      {
         /* Using cursor T005D30 */
         pr_default.execute(28);
         RcdFound180 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound180 = 1;
            A412PagReg = T005D30_A412PagReg[0];
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5D180( )
      {
         /* Scan next routine */
         pr_default.readNext(28);
         RcdFound180 = 0;
         if ( (pr_default.getStatus(28) != 101) )
         {
            RcdFound180 = 1;
            A412PagReg = T005D30_A412PagReg[0];
            AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
         }
      }

      protected void ScanEnd5D180( )
      {
         pr_default.close(28);
      }

      protected void AfterConfirm5D180( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5D180( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5D180( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5D180( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5D180( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5D180( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5D180( )
      {
         edtPagReg_Enabled = 0;
         AssignProp("", false, edtPagReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagReg_Enabled), 5, 0), true);
         edtPagPrvCod_Enabled = 0;
         AssignProp("", false, edtPagPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagPrvCod_Enabled), 5, 0), true);
         edtPagFech_Enabled = 0;
         AssignProp("", false, edtPagFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagFech_Enabled), 5, 0), true);
         edtPagForCod_Enabled = 0;
         AssignProp("", false, edtPagForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagForCod_Enabled), 5, 0), true);
         edtPagBanCod_Enabled = 0;
         AssignProp("", false, edtPagBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagBanCod_Enabled), 5, 0), true);
         edtPagCBCod_Enabled = 0;
         AssignProp("", false, edtPagCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagCBCod_Enabled), 5, 0), true);
         edtPagMonCod_Enabled = 0;
         AssignProp("", false, edtPagMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagMonCod_Enabled), 5, 0), true);
         edtPagCheque_Enabled = 0;
         AssignProp("", false, edtPagCheque_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagCheque_Enabled), 5, 0), true);
         edtPagRegistro_Enabled = 0;
         AssignProp("", false, edtPagRegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagRegistro_Enabled), 5, 0), true);
         edtPagTItem_Enabled = 0;
         AssignProp("", false, edtPagTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagTItem_Enabled), 5, 0), true);
         edtPagTipCmb_Enabled = 0;
         AssignProp("", false, edtPagTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagTipCmb_Enabled), 5, 0), true);
         edtPagPago_Enabled = 0;
         AssignProp("", false, edtPagPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagPago_Enabled), 5, 0), true);
         edtPagAjuste_Enabled = 0;
         AssignProp("", false, edtPagAjuste_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagAjuste_Enabled), 5, 0), true);
         edtPagTotal_Enabled = 0;
         AssignProp("", false, edtPagTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagTotal_Enabled), 5, 0), true);
         edtPagVouAno_Enabled = 0;
         AssignProp("", false, edtPagVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagVouAno_Enabled), 5, 0), true);
         edtPagVouMes_Enabled = 0;
         AssignProp("", false, edtPagVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagVouMes_Enabled), 5, 0), true);
         edtPagTASICod_Enabled = 0;
         AssignProp("", false, edtPagTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagTASICod_Enabled), 5, 0), true);
         edtPagVouNum_Enabled = 0;
         AssignProp("", false, edtPagVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagVouNum_Enabled), 5, 0), true);
         edtPagUsuC_Enabled = 0;
         AssignProp("", false, edtPagUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagUsuC_Enabled), 5, 0), true);
         edtPagFecC_Enabled = 0;
         AssignProp("", false, edtPagFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagFecC_Enabled), 5, 0), true);
         edtPagUsuM_Enabled = 0;
         AssignProp("", false, edtPagUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagUsuM_Enabled), 5, 0), true);
         edtPagFecM_Enabled = 0;
         AssignProp("", false, edtPagFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagFecM_Enabled), 5, 0), true);
         edtPagPrvDsc_Enabled = 0;
         AssignProp("", false, edtPagPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagPrvDsc_Enabled), 5, 0), true);
         edtPagForDsc_Enabled = 0;
         AssignProp("", false, edtPagForDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagForDsc_Enabled), 5, 0), true);
         edtPagForBanSts_Enabled = 0;
         AssignProp("", false, edtPagForBanSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagForBanSts_Enabled), 5, 0), true);
         edtPagCBMon_Enabled = 0;
         AssignProp("", false, edtPagCBMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagCBMon_Enabled), 5, 0), true);
         edtPagMonDsc_Enabled = 0;
         AssignProp("", false, edtPagMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagMonDsc_Enabled), 5, 0), true);
         edtPagBanDsc_Enabled = 0;
         AssignProp("", false, edtPagBanDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagBanDsc_Enabled), 5, 0), true);
         edtPagCBMonDsc_Enabled = 0;
         AssignProp("", false, edtPagCBMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPagCBMonDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5D180( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5D0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255982", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tspagos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z412PagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z412PagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1493PagTotal", StringUtil.LTrim( StringUtil.NToC( Z1493PagTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z418PagFech", context.localUtil.DToC( Z418PagFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1475PagCheque", StringUtil.RTrim( Z1475PagCheque));
         GxWebStd.gx_hidden_field( context, "Z1489PagRegistro", StringUtil.RTrim( Z1489PagRegistro));
         GxWebStd.gx_hidden_field( context, "Z1492PagTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1492PagTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1491PagTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1491PagTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1487PagPago", StringUtil.LTrim( StringUtil.NToC( Z1487PagPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1471PagAjuste", StringUtil.LTrim( StringUtil.NToC( Z1471PagAjuste, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1496PagVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1496PagVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1497PagVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1497PagVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1490PagTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1490PagTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1498PagVouNum", StringUtil.RTrim( Z1498PagVouNum));
         GxWebStd.gx_hidden_field( context, "Z1494PagUsuC", StringUtil.RTrim( Z1494PagUsuC));
         GxWebStd.gx_hidden_field( context, "Z1482PagFecC", context.localUtil.DToC( Z1482PagFecC, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1495PagUsuM", StringUtil.RTrim( Z1495PagUsuM));
         GxWebStd.gx_hidden_field( context, "Z1483PagFecM", context.localUtil.DToC( Z1483PagFecM, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z417PagPrvCod", StringUtil.RTrim( Z417PagPrvCod));
         GxWebStd.gx_hidden_field( context, "Z416PagForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z416PagForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z414PagBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z414PagBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z415PagCBCod", StringUtil.RTrim( Z415PagCBCod));
         GxWebStd.gx_hidden_field( context, "Z413PagMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z413PagMonCod), 6, 0, ".", "")));
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
         return formatLink("tspagos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSPAGOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Pagos - Cabecera" ;
      }

      protected void InitializeNonKey5D180( )
      {
         A1493PagTotal = 0;
         AssignAttri("", false, "A1493PagTotal", StringUtil.LTrimStr( A1493PagTotal, 15, 2));
         A417PagPrvCod = "";
         AssignAttri("", false, "A417PagPrvCod", A417PagPrvCod);
         A418PagFech = DateTime.MinValue;
         AssignAttri("", false, "A418PagFech", context.localUtil.Format(A418PagFech, "99/99/99"));
         A416PagForCod = 0;
         AssignAttri("", false, "A416PagForCod", StringUtil.LTrimStr( (decimal)(A416PagForCod), 6, 0));
         A414PagBanCod = 0;
         n414PagBanCod = false;
         AssignAttri("", false, "A414PagBanCod", StringUtil.LTrimStr( (decimal)(A414PagBanCod), 6, 0));
         n414PagBanCod = ((0==A414PagBanCod) ? true : false);
         A415PagCBCod = "";
         n415PagCBCod = false;
         AssignAttri("", false, "A415PagCBCod", A415PagCBCod);
         n415PagCBCod = (String.IsNullOrEmpty(StringUtil.RTrim( A415PagCBCod)) ? true : false);
         A413PagMonCod = 0;
         AssignAttri("", false, "A413PagMonCod", StringUtil.LTrimStr( (decimal)(A413PagMonCod), 6, 0));
         A1475PagCheque = "";
         AssignAttri("", false, "A1475PagCheque", A1475PagCheque);
         A1489PagRegistro = "";
         AssignAttri("", false, "A1489PagRegistro", A1489PagRegistro);
         A1492PagTItem = 0;
         AssignAttri("", false, "A1492PagTItem", StringUtil.LTrimStr( (decimal)(A1492PagTItem), 6, 0));
         A1491PagTipCmb = 0;
         AssignAttri("", false, "A1491PagTipCmb", StringUtil.LTrimStr( A1491PagTipCmb, 15, 5));
         A1487PagPago = 0;
         AssignAttri("", false, "A1487PagPago", StringUtil.LTrimStr( A1487PagPago, 15, 2));
         A1471PagAjuste = 0;
         AssignAttri("", false, "A1471PagAjuste", StringUtil.LTrimStr( A1471PagAjuste, 15, 2));
         A1496PagVouAno = 0;
         AssignAttri("", false, "A1496PagVouAno", StringUtil.LTrimStr( (decimal)(A1496PagVouAno), 4, 0));
         A1497PagVouMes = 0;
         AssignAttri("", false, "A1497PagVouMes", StringUtil.LTrimStr( (decimal)(A1497PagVouMes), 2, 0));
         A1490PagTASICod = 0;
         AssignAttri("", false, "A1490PagTASICod", StringUtil.LTrimStr( (decimal)(A1490PagTASICod), 6, 0));
         A1498PagVouNum = "";
         AssignAttri("", false, "A1498PagVouNum", A1498PagVouNum);
         A1494PagUsuC = "";
         AssignAttri("", false, "A1494PagUsuC", A1494PagUsuC);
         A1482PagFecC = DateTime.MinValue;
         AssignAttri("", false, "A1482PagFecC", context.localUtil.Format(A1482PagFecC, "99/99/99"));
         A1495PagUsuM = "";
         AssignAttri("", false, "A1495PagUsuM", A1495PagUsuM);
         A1483PagFecM = DateTime.MinValue;
         AssignAttri("", false, "A1483PagFecM", context.localUtil.Format(A1483PagFecM, "99/99/99"));
         A1488PagPrvDsc = "";
         AssignAttri("", false, "A1488PagPrvDsc", A1488PagPrvDsc);
         A1485PagForDsc = "";
         AssignAttri("", false, "A1485PagForDsc", A1485PagForDsc);
         A1484PagForBanSts = 0;
         AssignAttri("", false, "A1484PagForBanSts", StringUtil.Str( (decimal)(A1484PagForBanSts), 1, 0));
         A1473PagCBMon = 0;
         AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrimStr( (decimal)(A1473PagCBMon), 6, 0));
         A1486PagMonDsc = "";
         AssignAttri("", false, "A1486PagMonDsc", A1486PagMonDsc);
         A1472PagBanDsc = "";
         AssignAttri("", false, "A1472PagBanDsc", A1472PagBanDsc);
         A1474PagCBMonDsc = "";
         AssignAttri("", false, "A1474PagCBMonDsc", A1474PagCBMonDsc);
         Z1493PagTotal = 0;
         Z418PagFech = DateTime.MinValue;
         Z1475PagCheque = "";
         Z1489PagRegistro = "";
         Z1492PagTItem = 0;
         Z1491PagTipCmb = 0;
         Z1487PagPago = 0;
         Z1471PagAjuste = 0;
         Z1496PagVouAno = 0;
         Z1497PagVouMes = 0;
         Z1490PagTASICod = 0;
         Z1498PagVouNum = "";
         Z1494PagUsuC = "";
         Z1482PagFecC = DateTime.MinValue;
         Z1495PagUsuM = "";
         Z1483PagFecM = DateTime.MinValue;
         Z417PagPrvCod = "";
         Z416PagForCod = 0;
         Z414PagBanCod = 0;
         Z415PagCBCod = "";
         Z413PagMonCod = 0;
      }

      protected void InitAll5D180( )
      {
         A412PagReg = 0;
         AssignAttri("", false, "A412PagReg", StringUtil.LTrimStr( (decimal)(A412PagReg), 10, 0));
         InitializeNonKey5D180( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022818102603", true, true);
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
         context.AddJavascriptSource("tspagos.js", "?2022818102604", false, true);
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
         edtPagReg_Internalname = "PAGREG";
         edtPagPrvCod_Internalname = "PAGPRVCOD";
         edtPagFech_Internalname = "PAGFECH";
         edtPagForCod_Internalname = "PAGFORCOD";
         edtPagBanCod_Internalname = "PAGBANCOD";
         edtPagCBCod_Internalname = "PAGCBCOD";
         edtPagMonCod_Internalname = "PAGMONCOD";
         edtPagCheque_Internalname = "PAGCHEQUE";
         edtPagRegistro_Internalname = "PAGREGISTRO";
         edtPagTItem_Internalname = "PAGTITEM";
         edtPagTipCmb_Internalname = "PAGTIPCMB";
         edtPagPago_Internalname = "PAGPAGO";
         edtPagAjuste_Internalname = "PAGAJUSTE";
         edtPagTotal_Internalname = "PAGTOTAL";
         edtPagVouAno_Internalname = "PAGVOUANO";
         edtPagVouMes_Internalname = "PAGVOUMES";
         edtPagTASICod_Internalname = "PAGTASICOD";
         edtPagVouNum_Internalname = "PAGVOUNUM";
         edtPagUsuC_Internalname = "PAGUSUC";
         edtPagFecC_Internalname = "PAGFECC";
         edtPagUsuM_Internalname = "PAGUSUM";
         edtPagFecM_Internalname = "PAGFECM";
         edtPagPrvDsc_Internalname = "PAGPRVDSC";
         edtPagForDsc_Internalname = "PAGFORDSC";
         edtPagForBanSts_Internalname = "PAGFORBANSTS";
         edtPagCBMon_Internalname = "PAGCBMON";
         edtPagMonDsc_Internalname = "PAGMONDSC";
         edtPagBanDsc_Internalname = "PAGBANDSC";
         edtPagCBMonDsc_Internalname = "PAGCBMONDSC";
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
         Form.Caption = "Pagos - Cabecera";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPagCBMonDsc_Jsonclick = "";
         edtPagCBMonDsc_Enabled = 0;
         edtPagBanDsc_Jsonclick = "";
         edtPagBanDsc_Enabled = 0;
         edtPagMonDsc_Jsonclick = "";
         edtPagMonDsc_Enabled = 0;
         edtPagCBMon_Jsonclick = "";
         edtPagCBMon_Enabled = 0;
         edtPagForBanSts_Jsonclick = "";
         edtPagForBanSts_Enabled = 0;
         edtPagForDsc_Jsonclick = "";
         edtPagForDsc_Enabled = 0;
         edtPagPrvDsc_Jsonclick = "";
         edtPagPrvDsc_Enabled = 0;
         edtPagFecM_Jsonclick = "";
         edtPagFecM_Enabled = 1;
         edtPagUsuM_Jsonclick = "";
         edtPagUsuM_Enabled = 1;
         edtPagFecC_Jsonclick = "";
         edtPagFecC_Enabled = 1;
         edtPagUsuC_Jsonclick = "";
         edtPagUsuC_Enabled = 1;
         edtPagVouNum_Jsonclick = "";
         edtPagVouNum_Enabled = 1;
         edtPagTASICod_Jsonclick = "";
         edtPagTASICod_Enabled = 1;
         edtPagVouMes_Jsonclick = "";
         edtPagVouMes_Enabled = 1;
         edtPagVouAno_Jsonclick = "";
         edtPagVouAno_Enabled = 1;
         edtPagTotal_Jsonclick = "";
         edtPagTotal_Enabled = 0;
         edtPagAjuste_Jsonclick = "";
         edtPagAjuste_Enabled = 1;
         edtPagPago_Jsonclick = "";
         edtPagPago_Enabled = 1;
         edtPagTipCmb_Jsonclick = "";
         edtPagTipCmb_Enabled = 1;
         edtPagTItem_Jsonclick = "";
         edtPagTItem_Enabled = 1;
         edtPagRegistro_Jsonclick = "";
         edtPagRegistro_Enabled = 1;
         edtPagCheque_Jsonclick = "";
         edtPagCheque_Enabled = 1;
         edtPagMonCod_Jsonclick = "";
         edtPagMonCod_Enabled = 1;
         edtPagCBCod_Jsonclick = "";
         edtPagCBCod_Enabled = 1;
         edtPagBanCod_Jsonclick = "";
         edtPagBanCod_Enabled = 1;
         edtPagForCod_Jsonclick = "";
         edtPagForCod_Enabled = 1;
         edtPagFech_Jsonclick = "";
         edtPagFech_Enabled = 1;
         edtPagPrvCod_Jsonclick = "";
         edtPagPrvCod_Enabled = 1;
         edtPagReg_Jsonclick = "";
         edtPagReg_Enabled = 1;
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
         GX_FocusControl = edtPagPrvCod_Internalname;
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

      public void Valid_Pagreg( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A417PagPrvCod", StringUtil.RTrim( A417PagPrvCod));
         AssignAttri("", false, "A418PagFech", context.localUtil.Format(A418PagFech, "99/99/99"));
         AssignAttri("", false, "A416PagForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A416PagForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A414PagBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A414PagBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A415PagCBCod", StringUtil.RTrim( A415PagCBCod));
         AssignAttri("", false, "A413PagMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A413PagMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1475PagCheque", StringUtil.RTrim( A1475PagCheque));
         AssignAttri("", false, "A1489PagRegistro", StringUtil.RTrim( A1489PagRegistro));
         AssignAttri("", false, "A1492PagTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1492PagTItem), 6, 0, ".", "")));
         AssignAttri("", false, "A1491PagTipCmb", StringUtil.LTrim( StringUtil.NToC( A1491PagTipCmb, 15, 5, ".", "")));
         AssignAttri("", false, "A1487PagPago", StringUtil.LTrim( StringUtil.NToC( A1487PagPago, 15, 2, ".", "")));
         AssignAttri("", false, "A1471PagAjuste", StringUtil.LTrim( StringUtil.NToC( A1471PagAjuste, 15, 2, ".", "")));
         AssignAttri("", false, "A1496PagVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1496PagVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1497PagVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1497PagVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1490PagTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1490PagTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A1498PagVouNum", StringUtil.RTrim( A1498PagVouNum));
         AssignAttri("", false, "A1494PagUsuC", StringUtil.RTrim( A1494PagUsuC));
         AssignAttri("", false, "A1482PagFecC", context.localUtil.Format(A1482PagFecC, "99/99/99"));
         AssignAttri("", false, "A1495PagUsuM", StringUtil.RTrim( A1495PagUsuM));
         AssignAttri("", false, "A1483PagFecM", context.localUtil.Format(A1483PagFecM, "99/99/99"));
         AssignAttri("", false, "A1488PagPrvDsc", StringUtil.RTrim( A1488PagPrvDsc));
         AssignAttri("", false, "A1485PagForDsc", StringUtil.RTrim( A1485PagForDsc));
         AssignAttri("", false, "A1484PagForBanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1484PagForBanSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1472PagBanDsc", StringUtil.RTrim( A1472PagBanDsc));
         AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1473PagCBMon), 6, 0, ".", "")));
         AssignAttri("", false, "A1474PagCBMonDsc", StringUtil.RTrim( A1474PagCBMonDsc));
         AssignAttri("", false, "A1486PagMonDsc", StringUtil.RTrim( A1486PagMonDsc));
         AssignAttri("", false, "A1493PagTotal", StringUtil.LTrim( StringUtil.NToC( A1493PagTotal, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z412PagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z412PagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z417PagPrvCod", StringUtil.RTrim( Z417PagPrvCod));
         GxWebStd.gx_hidden_field( context, "Z418PagFech", context.localUtil.Format(Z418PagFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z416PagForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z416PagForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z414PagBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z414PagBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z415PagCBCod", StringUtil.RTrim( Z415PagCBCod));
         GxWebStd.gx_hidden_field( context, "Z413PagMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z413PagMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1475PagCheque", StringUtil.RTrim( Z1475PagCheque));
         GxWebStd.gx_hidden_field( context, "Z1489PagRegistro", StringUtil.RTrim( Z1489PagRegistro));
         GxWebStd.gx_hidden_field( context, "Z1492PagTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1492PagTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1491PagTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1491PagTipCmb, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1487PagPago", StringUtil.LTrim( StringUtil.NToC( Z1487PagPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1471PagAjuste", StringUtil.LTrim( StringUtil.NToC( Z1471PagAjuste, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1496PagVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1496PagVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1497PagVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1497PagVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1490PagTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1490PagTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1498PagVouNum", StringUtil.RTrim( Z1498PagVouNum));
         GxWebStd.gx_hidden_field( context, "Z1494PagUsuC", StringUtil.RTrim( Z1494PagUsuC));
         GxWebStd.gx_hidden_field( context, "Z1482PagFecC", context.localUtil.Format(Z1482PagFecC, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1495PagUsuM", StringUtil.RTrim( Z1495PagUsuM));
         GxWebStd.gx_hidden_field( context, "Z1483PagFecM", context.localUtil.Format(Z1483PagFecM, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1488PagPrvDsc", StringUtil.RTrim( Z1488PagPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1485PagForDsc", StringUtil.RTrim( Z1485PagForDsc));
         GxWebStd.gx_hidden_field( context, "Z1484PagForBanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1484PagForBanSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1472PagBanDsc", StringUtil.RTrim( Z1472PagBanDsc));
         GxWebStd.gx_hidden_field( context, "Z1473PagCBMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1473PagCBMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1474PagCBMonDsc", StringUtil.RTrim( Z1474PagCBMonDsc));
         GxWebStd.gx_hidden_field( context, "Z1486PagMonDsc", StringUtil.RTrim( Z1486PagMonDsc));
         GxWebStd.gx_hidden_field( context, "Z1493PagTotal", StringUtil.LTrim( StringUtil.NToC( Z1493PagTotal, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Pagprvcod( )
      {
         /* Using cursor T005D23 */
         pr_default.execute(21, new Object[] {A417PagPrvCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Pagos Proveedor'.", "ForeignKeyNotFound", 1, "PAGPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPagPrvCod_Internalname;
         }
         A1488PagPrvDsc = T005D23_A1488PagPrvDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1488PagPrvDsc", StringUtil.RTrim( A1488PagPrvDsc));
      }

      public void Valid_Pagforcod( )
      {
         /* Using cursor T005D24 */
         pr_default.execute(22, new Object[] {A416PagForCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de pago'.", "ForeignKeyNotFound", 1, "PAGFORCOD");
            AnyError = 1;
            GX_FocusControl = edtPagForCod_Internalname;
         }
         A1485PagForDsc = T005D24_A1485PagForDsc[0];
         A1484PagForBanSts = T005D24_A1484PagForBanSts[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1485PagForDsc", StringUtil.RTrim( A1485PagForDsc));
         AssignAttri("", false, "A1484PagForBanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1484PagForBanSts), 1, 0, ".", "")));
      }

      public void Valid_Pagbancod( )
      {
         n414PagBanCod = false;
         /* Using cursor T005D25 */
         pr_default.execute(23, new Object[] {n414PagBanCod, A414PagBanCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( (0==A414PagBanCod) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGBANCOD");
               AnyError = 1;
               GX_FocusControl = edtPagBanCod_Internalname;
            }
         }
         A1472PagBanDsc = T005D25_A1472PagBanDsc[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1472PagBanDsc", StringUtil.RTrim( A1472PagBanDsc));
      }

      public void Valid_Pagcbcod( )
      {
         n414PagBanCod = false;
         n415PagCBCod = false;
         /* Using cursor T005D26 */
         pr_default.execute(24, new Object[] {n414PagBanCod, A414PagBanCod, n415PagCBCod, A415PagCBCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A414PagBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A415PagCBCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGCBCOD");
               AnyError = 1;
               GX_FocusControl = edtPagBanCod_Internalname;
            }
         }
         A1473PagCBMon = T005D26_A1473PagCBMon[0];
         pr_default.close(24);
         /* Using cursor T005D27 */
         pr_default.execute(25, new Object[] {A1473PagCBMon});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( (0==A1473PagCBMon) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta de Banco'.", "ForeignKeyNotFound", 1, "PAGCBMON");
               AnyError = 1;
            }
         }
         A1474PagCBMonDsc = T005D27_A1474PagCBMonDsc[0];
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1473PagCBMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1473PagCBMon), 6, 0, ".", "")));
         AssignAttri("", false, "A1474PagCBMonDsc", StringUtil.RTrim( A1474PagCBMonDsc));
      }

      public void Valid_Pagmoncod( )
      {
         /* Using cursor T005D28 */
         pr_default.execute(26, new Object[] {A413PagMonCod});
         if ( (pr_default.getStatus(26) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "PAGMONCOD");
            AnyError = 1;
            GX_FocusControl = edtPagMonCod_Internalname;
         }
         A1486PagMonDsc = T005D28_A1486PagMonDsc[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1486PagMonDsc", StringUtil.RTrim( A1486PagMonDsc));
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
         setEventMetadata("VALID_PAGREG","{handler:'Valid_Pagreg',iparms:[{av:'A412PagReg',fld:'PAGREG',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PAGREG",",oparms:[{av:'A417PagPrvCod',fld:'PAGPRVCOD',pic:'@!'},{av:'A418PagFech',fld:'PAGFECH',pic:''},{av:'A416PagForCod',fld:'PAGFORCOD',pic:'ZZZZZ9'},{av:'A414PagBanCod',fld:'PAGBANCOD',pic:'ZZZZZ9'},{av:'A415PagCBCod',fld:'PAGCBCOD',pic:''},{av:'A413PagMonCod',fld:'PAGMONCOD',pic:'ZZZZZ9'},{av:'A1475PagCheque',fld:'PAGCHEQUE',pic:''},{av:'A1489PagRegistro',fld:'PAGREGISTRO',pic:''},{av:'A1492PagTItem',fld:'PAGTITEM',pic:'ZZZZZ9'},{av:'A1491PagTipCmb',fld:'PAGTIPCMB',pic:'ZZZZZZZZ9.99999'},{av:'A1487PagPago',fld:'PAGPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1471PagAjuste',fld:'PAGAJUSTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1496PagVouAno',fld:'PAGVOUANO',pic:'ZZZ9'},{av:'A1497PagVouMes',fld:'PAGVOUMES',pic:'Z9'},{av:'A1490PagTASICod',fld:'PAGTASICOD',pic:'ZZZZZ9'},{av:'A1498PagVouNum',fld:'PAGVOUNUM',pic:''},{av:'A1494PagUsuC',fld:'PAGUSUC',pic:''},{av:'A1482PagFecC',fld:'PAGFECC',pic:''},{av:'A1495PagUsuM',fld:'PAGUSUM',pic:''},{av:'A1483PagFecM',fld:'PAGFECM',pic:''},{av:'A1488PagPrvDsc',fld:'PAGPRVDSC',pic:''},{av:'A1485PagForDsc',fld:'PAGFORDSC',pic:''},{av:'A1484PagForBanSts',fld:'PAGFORBANSTS',pic:'9'},{av:'A1472PagBanDsc',fld:'PAGBANDSC',pic:''},{av:'A1473PagCBMon',fld:'PAGCBMON',pic:'ZZZZZ9'},{av:'A1474PagCBMonDsc',fld:'PAGCBMONDSC',pic:''},{av:'A1486PagMonDsc',fld:'PAGMONDSC',pic:''},{av:'A1493PagTotal',fld:'PAGTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z412PagReg'},{av:'Z417PagPrvCod'},{av:'Z418PagFech'},{av:'Z416PagForCod'},{av:'Z414PagBanCod'},{av:'Z415PagCBCod'},{av:'Z413PagMonCod'},{av:'Z1475PagCheque'},{av:'Z1489PagRegistro'},{av:'Z1492PagTItem'},{av:'Z1491PagTipCmb'},{av:'Z1487PagPago'},{av:'Z1471PagAjuste'},{av:'Z1496PagVouAno'},{av:'Z1497PagVouMes'},{av:'Z1490PagTASICod'},{av:'Z1498PagVouNum'},{av:'Z1494PagUsuC'},{av:'Z1482PagFecC'},{av:'Z1495PagUsuM'},{av:'Z1483PagFecM'},{av:'Z1488PagPrvDsc'},{av:'Z1485PagForDsc'},{av:'Z1484PagForBanSts'},{av:'Z1472PagBanDsc'},{av:'Z1473PagCBMon'},{av:'Z1474PagCBMonDsc'},{av:'Z1486PagMonDsc'},{av:'Z1493PagTotal'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_PAGPRVCOD","{handler:'Valid_Pagprvcod',iparms:[{av:'A417PagPrvCod',fld:'PAGPRVCOD',pic:'@!'},{av:'A1488PagPrvDsc',fld:'PAGPRVDSC',pic:''}]");
         setEventMetadata("VALID_PAGPRVCOD",",oparms:[{av:'A1488PagPrvDsc',fld:'PAGPRVDSC',pic:''}]}");
         setEventMetadata("VALID_PAGFECH","{handler:'Valid_Pagfech',iparms:[]");
         setEventMetadata("VALID_PAGFECH",",oparms:[]}");
         setEventMetadata("VALID_PAGFORCOD","{handler:'Valid_Pagforcod',iparms:[{av:'A416PagForCod',fld:'PAGFORCOD',pic:'ZZZZZ9'},{av:'A1485PagForDsc',fld:'PAGFORDSC',pic:''},{av:'A1484PagForBanSts',fld:'PAGFORBANSTS',pic:'9'}]");
         setEventMetadata("VALID_PAGFORCOD",",oparms:[{av:'A1485PagForDsc',fld:'PAGFORDSC',pic:''},{av:'A1484PagForBanSts',fld:'PAGFORBANSTS',pic:'9'}]}");
         setEventMetadata("VALID_PAGBANCOD","{handler:'Valid_Pagbancod',iparms:[{av:'A414PagBanCod',fld:'PAGBANCOD',pic:'ZZZZZ9'},{av:'A1472PagBanDsc',fld:'PAGBANDSC',pic:''}]");
         setEventMetadata("VALID_PAGBANCOD",",oparms:[{av:'A1472PagBanDsc',fld:'PAGBANDSC',pic:''}]}");
         setEventMetadata("VALID_PAGCBCOD","{handler:'Valid_Pagcbcod',iparms:[{av:'A414PagBanCod',fld:'PAGBANCOD',pic:'ZZZZZ9'},{av:'A415PagCBCod',fld:'PAGCBCOD',pic:''},{av:'A1473PagCBMon',fld:'PAGCBMON',pic:'ZZZZZ9'},{av:'A1474PagCBMonDsc',fld:'PAGCBMONDSC',pic:''}]");
         setEventMetadata("VALID_PAGCBCOD",",oparms:[{av:'A1473PagCBMon',fld:'PAGCBMON',pic:'ZZZZZ9'},{av:'A1474PagCBMonDsc',fld:'PAGCBMONDSC',pic:''}]}");
         setEventMetadata("VALID_PAGMONCOD","{handler:'Valid_Pagmoncod',iparms:[{av:'A413PagMonCod',fld:'PAGMONCOD',pic:'ZZZZZ9'},{av:'A1486PagMonDsc',fld:'PAGMONDSC',pic:''}]");
         setEventMetadata("VALID_PAGMONCOD",",oparms:[{av:'A1486PagMonDsc',fld:'PAGMONDSC',pic:''}]}");
         setEventMetadata("VALID_PAGPAGO","{handler:'Valid_Pagpago',iparms:[]");
         setEventMetadata("VALID_PAGPAGO",",oparms:[]}");
         setEventMetadata("VALID_PAGAJUSTE","{handler:'Valid_Pagajuste',iparms:[]");
         setEventMetadata("VALID_PAGAJUSTE",",oparms:[]}");
         setEventMetadata("VALID_PAGFECC","{handler:'Valid_Pagfecc',iparms:[]");
         setEventMetadata("VALID_PAGFECC",",oparms:[]}");
         setEventMetadata("VALID_PAGFECM","{handler:'Valid_Pagfecm',iparms:[]");
         setEventMetadata("VALID_PAGFECM",",oparms:[]}");
         setEventMetadata("VALID_PAGCBMON","{handler:'Valid_Pagcbmon',iparms:[]");
         setEventMetadata("VALID_PAGCBMON",",oparms:[]}");
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
         pr_default.close(21);
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(26);
         pr_default.close(25);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z418PagFech = DateTime.MinValue;
         Z1475PagCheque = "";
         Z1489PagRegistro = "";
         Z1498PagVouNum = "";
         Z1494PagUsuC = "";
         Z1482PagFecC = DateTime.MinValue;
         Z1495PagUsuM = "";
         Z1483PagFecM = DateTime.MinValue;
         Z417PagPrvCod = "";
         Z415PagCBCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A417PagPrvCod = "";
         A415PagCBCod = "";
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
         A418PagFech = DateTime.MinValue;
         A1475PagCheque = "";
         A1489PagRegistro = "";
         A1498PagVouNum = "";
         A1494PagUsuC = "";
         A1482PagFecC = DateTime.MinValue;
         A1495PagUsuM = "";
         A1483PagFecM = DateTime.MinValue;
         A1488PagPrvDsc = "";
         A1485PagForDsc = "";
         A1486PagMonDsc = "";
         A1472PagBanDsc = "";
         A1474PagCBMonDsc = "";
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
         Z1488PagPrvDsc = "";
         Z1485PagForDsc = "";
         Z1472PagBanDsc = "";
         Z1474PagCBMonDsc = "";
         Z1486PagMonDsc = "";
         T005D10_A1493PagTotal = new decimal[1] ;
         T005D10_A412PagReg = new long[1] ;
         T005D10_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         T005D10_A1475PagCheque = new string[] {""} ;
         T005D10_A1489PagRegistro = new string[] {""} ;
         T005D10_A1492PagTItem = new int[1] ;
         T005D10_A1491PagTipCmb = new decimal[1] ;
         T005D10_A1487PagPago = new decimal[1] ;
         T005D10_A1471PagAjuste = new decimal[1] ;
         T005D10_A1496PagVouAno = new short[1] ;
         T005D10_A1497PagVouMes = new short[1] ;
         T005D10_A1490PagTASICod = new int[1] ;
         T005D10_A1498PagVouNum = new string[] {""} ;
         T005D10_A1494PagUsuC = new string[] {""} ;
         T005D10_A1482PagFecC = new DateTime[] {DateTime.MinValue} ;
         T005D10_A1495PagUsuM = new string[] {""} ;
         T005D10_A1483PagFecM = new DateTime[] {DateTime.MinValue} ;
         T005D10_A1488PagPrvDsc = new string[] {""} ;
         T005D10_A1485PagForDsc = new string[] {""} ;
         T005D10_A1484PagForBanSts = new short[1] ;
         T005D10_A1486PagMonDsc = new string[] {""} ;
         T005D10_A1472PagBanDsc = new string[] {""} ;
         T005D10_A1474PagCBMonDsc = new string[] {""} ;
         T005D10_A417PagPrvCod = new string[] {""} ;
         T005D10_A416PagForCod = new int[1] ;
         T005D10_A414PagBanCod = new int[1] ;
         T005D10_n414PagBanCod = new bool[] {false} ;
         T005D10_A415PagCBCod = new string[] {""} ;
         T005D10_n415PagCBCod = new bool[] {false} ;
         T005D10_A413PagMonCod = new int[1] ;
         T005D10_A1473PagCBMon = new int[1] ;
         T005D4_A1488PagPrvDsc = new string[] {""} ;
         T005D5_A1485PagForDsc = new string[] {""} ;
         T005D5_A1484PagForBanSts = new short[1] ;
         T005D6_A1472PagBanDsc = new string[] {""} ;
         T005D7_A1473PagCBMon = new int[1] ;
         T005D9_A1474PagCBMonDsc = new string[] {""} ;
         T005D8_A1486PagMonDsc = new string[] {""} ;
         T005D11_A1488PagPrvDsc = new string[] {""} ;
         T005D12_A1485PagForDsc = new string[] {""} ;
         T005D12_A1484PagForBanSts = new short[1] ;
         T005D13_A1472PagBanDsc = new string[] {""} ;
         T005D14_A1473PagCBMon = new int[1] ;
         T005D15_A1474PagCBMonDsc = new string[] {""} ;
         T005D16_A1486PagMonDsc = new string[] {""} ;
         T005D17_A412PagReg = new long[1] ;
         T005D3_A1493PagTotal = new decimal[1] ;
         T005D3_A412PagReg = new long[1] ;
         T005D3_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         T005D3_A1475PagCheque = new string[] {""} ;
         T005D3_A1489PagRegistro = new string[] {""} ;
         T005D3_A1492PagTItem = new int[1] ;
         T005D3_A1491PagTipCmb = new decimal[1] ;
         T005D3_A1487PagPago = new decimal[1] ;
         T005D3_A1471PagAjuste = new decimal[1] ;
         T005D3_A1496PagVouAno = new short[1] ;
         T005D3_A1497PagVouMes = new short[1] ;
         T005D3_A1490PagTASICod = new int[1] ;
         T005D3_A1498PagVouNum = new string[] {""} ;
         T005D3_A1494PagUsuC = new string[] {""} ;
         T005D3_A1482PagFecC = new DateTime[] {DateTime.MinValue} ;
         T005D3_A1495PagUsuM = new string[] {""} ;
         T005D3_A1483PagFecM = new DateTime[] {DateTime.MinValue} ;
         T005D3_A417PagPrvCod = new string[] {""} ;
         T005D3_A416PagForCod = new int[1] ;
         T005D3_A414PagBanCod = new int[1] ;
         T005D3_n414PagBanCod = new bool[] {false} ;
         T005D3_A415PagCBCod = new string[] {""} ;
         T005D3_n415PagCBCod = new bool[] {false} ;
         T005D3_A413PagMonCod = new int[1] ;
         sMode180 = "";
         T005D18_A412PagReg = new long[1] ;
         T005D19_A412PagReg = new long[1] ;
         T005D2_A1493PagTotal = new decimal[1] ;
         T005D2_A412PagReg = new long[1] ;
         T005D2_A418PagFech = new DateTime[] {DateTime.MinValue} ;
         T005D2_A1475PagCheque = new string[] {""} ;
         T005D2_A1489PagRegistro = new string[] {""} ;
         T005D2_A1492PagTItem = new int[1] ;
         T005D2_A1491PagTipCmb = new decimal[1] ;
         T005D2_A1487PagPago = new decimal[1] ;
         T005D2_A1471PagAjuste = new decimal[1] ;
         T005D2_A1496PagVouAno = new short[1] ;
         T005D2_A1497PagVouMes = new short[1] ;
         T005D2_A1490PagTASICod = new int[1] ;
         T005D2_A1498PagVouNum = new string[] {""} ;
         T005D2_A1494PagUsuC = new string[] {""} ;
         T005D2_A1482PagFecC = new DateTime[] {DateTime.MinValue} ;
         T005D2_A1495PagUsuM = new string[] {""} ;
         T005D2_A1483PagFecM = new DateTime[] {DateTime.MinValue} ;
         T005D2_A417PagPrvCod = new string[] {""} ;
         T005D2_A416PagForCod = new int[1] ;
         T005D2_A414PagBanCod = new int[1] ;
         T005D2_n414PagBanCod = new bool[] {false} ;
         T005D2_A415PagCBCod = new string[] {""} ;
         T005D2_n415PagCBCod = new bool[] {false} ;
         T005D2_A413PagMonCod = new int[1] ;
         T005D23_A1488PagPrvDsc = new string[] {""} ;
         T005D24_A1485PagForDsc = new string[] {""} ;
         T005D24_A1484PagForBanSts = new short[1] ;
         T005D25_A1472PagBanDsc = new string[] {""} ;
         T005D26_A1473PagCBMon = new int[1] ;
         T005D27_A1474PagCBMonDsc = new string[] {""} ;
         T005D28_A1486PagMonDsc = new string[] {""} ;
         T005D29_A412PagReg = new long[1] ;
         T005D29_A419PagItem = new short[1] ;
         T005D30_A412PagReg = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ417PagPrvCod = "";
         ZZ418PagFech = DateTime.MinValue;
         ZZ415PagCBCod = "";
         ZZ1475PagCheque = "";
         ZZ1489PagRegistro = "";
         ZZ1498PagVouNum = "";
         ZZ1494PagUsuC = "";
         ZZ1482PagFecC = DateTime.MinValue;
         ZZ1495PagUsuM = "";
         ZZ1483PagFecM = DateTime.MinValue;
         ZZ1488PagPrvDsc = "";
         ZZ1485PagForDsc = "";
         ZZ1472PagBanDsc = "";
         ZZ1474PagCBMonDsc = "";
         ZZ1486PagMonDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tspagos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tspagos__default(),
            new Object[][] {
                new Object[] {
               T005D2_A1493PagTotal, T005D2_A412PagReg, T005D2_A418PagFech, T005D2_A1475PagCheque, T005D2_A1489PagRegistro, T005D2_A1492PagTItem, T005D2_A1491PagTipCmb, T005D2_A1487PagPago, T005D2_A1471PagAjuste, T005D2_A1496PagVouAno,
               T005D2_A1497PagVouMes, T005D2_A1490PagTASICod, T005D2_A1498PagVouNum, T005D2_A1494PagUsuC, T005D2_A1482PagFecC, T005D2_A1495PagUsuM, T005D2_A1483PagFecM, T005D2_A417PagPrvCod, T005D2_A416PagForCod, T005D2_A414PagBanCod,
               T005D2_n414PagBanCod, T005D2_A415PagCBCod, T005D2_n415PagCBCod, T005D2_A413PagMonCod
               }
               , new Object[] {
               T005D3_A1493PagTotal, T005D3_A412PagReg, T005D3_A418PagFech, T005D3_A1475PagCheque, T005D3_A1489PagRegistro, T005D3_A1492PagTItem, T005D3_A1491PagTipCmb, T005D3_A1487PagPago, T005D3_A1471PagAjuste, T005D3_A1496PagVouAno,
               T005D3_A1497PagVouMes, T005D3_A1490PagTASICod, T005D3_A1498PagVouNum, T005D3_A1494PagUsuC, T005D3_A1482PagFecC, T005D3_A1495PagUsuM, T005D3_A1483PagFecM, T005D3_A417PagPrvCod, T005D3_A416PagForCod, T005D3_A414PagBanCod,
               T005D3_n414PagBanCod, T005D3_A415PagCBCod, T005D3_n415PagCBCod, T005D3_A413PagMonCod
               }
               , new Object[] {
               T005D4_A1488PagPrvDsc
               }
               , new Object[] {
               T005D5_A1485PagForDsc, T005D5_A1484PagForBanSts
               }
               , new Object[] {
               T005D6_A1472PagBanDsc
               }
               , new Object[] {
               T005D7_A1473PagCBMon
               }
               , new Object[] {
               T005D8_A1486PagMonDsc
               }
               , new Object[] {
               T005D9_A1474PagCBMonDsc
               }
               , new Object[] {
               T005D10_A1493PagTotal, T005D10_A412PagReg, T005D10_A418PagFech, T005D10_A1475PagCheque, T005D10_A1489PagRegistro, T005D10_A1492PagTItem, T005D10_A1491PagTipCmb, T005D10_A1487PagPago, T005D10_A1471PagAjuste, T005D10_A1496PagVouAno,
               T005D10_A1497PagVouMes, T005D10_A1490PagTASICod, T005D10_A1498PagVouNum, T005D10_A1494PagUsuC, T005D10_A1482PagFecC, T005D10_A1495PagUsuM, T005D10_A1483PagFecM, T005D10_A1488PagPrvDsc, T005D10_A1485PagForDsc, T005D10_A1484PagForBanSts,
               T005D10_A1486PagMonDsc, T005D10_A1472PagBanDsc, T005D10_A1474PagCBMonDsc, T005D10_A417PagPrvCod, T005D10_A416PagForCod, T005D10_A414PagBanCod, T005D10_n414PagBanCod, T005D10_A415PagCBCod, T005D10_n415PagCBCod, T005D10_A413PagMonCod,
               T005D10_A1473PagCBMon
               }
               , new Object[] {
               T005D11_A1488PagPrvDsc
               }
               , new Object[] {
               T005D12_A1485PagForDsc, T005D12_A1484PagForBanSts
               }
               , new Object[] {
               T005D13_A1472PagBanDsc
               }
               , new Object[] {
               T005D14_A1473PagCBMon
               }
               , new Object[] {
               T005D15_A1474PagCBMonDsc
               }
               , new Object[] {
               T005D16_A1486PagMonDsc
               }
               , new Object[] {
               T005D17_A412PagReg
               }
               , new Object[] {
               T005D18_A412PagReg
               }
               , new Object[] {
               T005D19_A412PagReg
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005D23_A1488PagPrvDsc
               }
               , new Object[] {
               T005D24_A1485PagForDsc, T005D24_A1484PagForBanSts
               }
               , new Object[] {
               T005D25_A1472PagBanDsc
               }
               , new Object[] {
               T005D26_A1473PagCBMon
               }
               , new Object[] {
               T005D27_A1474PagCBMonDsc
               }
               , new Object[] {
               T005D28_A1486PagMonDsc
               }
               , new Object[] {
               T005D29_A412PagReg, T005D29_A419PagItem
               }
               , new Object[] {
               T005D30_A412PagReg
               }
            }
         );
      }

      private short Z1496PagVouAno ;
      private short Z1497PagVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1496PagVouAno ;
      private short A1497PagVouMes ;
      private short A1484PagForBanSts ;
      private short GX_JID ;
      private short Z1484PagForBanSts ;
      private short RcdFound180 ;
      private short nIsDirty_180 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1496PagVouAno ;
      private short ZZ1497PagVouMes ;
      private short ZZ1484PagForBanSts ;
      private int Z1492PagTItem ;
      private int Z1490PagTASICod ;
      private int Z416PagForCod ;
      private int Z414PagBanCod ;
      private int Z413PagMonCod ;
      private int A416PagForCod ;
      private int A414PagBanCod ;
      private int A1473PagCBMon ;
      private int A413PagMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPagReg_Enabled ;
      private int edtPagPrvCod_Enabled ;
      private int edtPagFech_Enabled ;
      private int edtPagForCod_Enabled ;
      private int edtPagBanCod_Enabled ;
      private int edtPagCBCod_Enabled ;
      private int edtPagMonCod_Enabled ;
      private int edtPagCheque_Enabled ;
      private int edtPagRegistro_Enabled ;
      private int A1492PagTItem ;
      private int edtPagTItem_Enabled ;
      private int edtPagTipCmb_Enabled ;
      private int edtPagPago_Enabled ;
      private int edtPagAjuste_Enabled ;
      private int edtPagTotal_Enabled ;
      private int edtPagVouAno_Enabled ;
      private int edtPagVouMes_Enabled ;
      private int A1490PagTASICod ;
      private int edtPagTASICod_Enabled ;
      private int edtPagVouNum_Enabled ;
      private int edtPagUsuC_Enabled ;
      private int edtPagFecC_Enabled ;
      private int edtPagUsuM_Enabled ;
      private int edtPagFecM_Enabled ;
      private int edtPagPrvDsc_Enabled ;
      private int edtPagForDsc_Enabled ;
      private int edtPagForBanSts_Enabled ;
      private int edtPagCBMon_Enabled ;
      private int edtPagMonDsc_Enabled ;
      private int edtPagBanDsc_Enabled ;
      private int edtPagCBMonDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z1473PagCBMon ;
      private int idxLst ;
      private int ZZ416PagForCod ;
      private int ZZ414PagBanCod ;
      private int ZZ413PagMonCod ;
      private int ZZ1492PagTItem ;
      private int ZZ1490PagTASICod ;
      private int ZZ1473PagCBMon ;
      private long Z412PagReg ;
      private long A412PagReg ;
      private long ZZ412PagReg ;
      private decimal Z1493PagTotal ;
      private decimal Z1491PagTipCmb ;
      private decimal Z1487PagPago ;
      private decimal Z1471PagAjuste ;
      private decimal A1491PagTipCmb ;
      private decimal A1487PagPago ;
      private decimal A1471PagAjuste ;
      private decimal A1493PagTotal ;
      private decimal ZZ1491PagTipCmb ;
      private decimal ZZ1487PagPago ;
      private decimal ZZ1471PagAjuste ;
      private decimal ZZ1493PagTotal ;
      private string sPrefix ;
      private string Z1475PagCheque ;
      private string Z1489PagRegistro ;
      private string Z1498PagVouNum ;
      private string Z1494PagUsuC ;
      private string Z1495PagUsuM ;
      private string Z417PagPrvCod ;
      private string Z415PagCBCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A417PagPrvCod ;
      private string A415PagCBCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPagReg_Internalname ;
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
      private string edtPagReg_Jsonclick ;
      private string edtPagPrvCod_Internalname ;
      private string edtPagPrvCod_Jsonclick ;
      private string edtPagFech_Internalname ;
      private string edtPagFech_Jsonclick ;
      private string edtPagForCod_Internalname ;
      private string edtPagForCod_Jsonclick ;
      private string edtPagBanCod_Internalname ;
      private string edtPagBanCod_Jsonclick ;
      private string edtPagCBCod_Internalname ;
      private string edtPagCBCod_Jsonclick ;
      private string edtPagMonCod_Internalname ;
      private string edtPagMonCod_Jsonclick ;
      private string edtPagCheque_Internalname ;
      private string A1475PagCheque ;
      private string edtPagCheque_Jsonclick ;
      private string edtPagRegistro_Internalname ;
      private string A1489PagRegistro ;
      private string edtPagRegistro_Jsonclick ;
      private string edtPagTItem_Internalname ;
      private string edtPagTItem_Jsonclick ;
      private string edtPagTipCmb_Internalname ;
      private string edtPagTipCmb_Jsonclick ;
      private string edtPagPago_Internalname ;
      private string edtPagPago_Jsonclick ;
      private string edtPagAjuste_Internalname ;
      private string edtPagAjuste_Jsonclick ;
      private string edtPagTotal_Internalname ;
      private string edtPagTotal_Jsonclick ;
      private string edtPagVouAno_Internalname ;
      private string edtPagVouAno_Jsonclick ;
      private string edtPagVouMes_Internalname ;
      private string edtPagVouMes_Jsonclick ;
      private string edtPagTASICod_Internalname ;
      private string edtPagTASICod_Jsonclick ;
      private string edtPagVouNum_Internalname ;
      private string A1498PagVouNum ;
      private string edtPagVouNum_Jsonclick ;
      private string edtPagUsuC_Internalname ;
      private string A1494PagUsuC ;
      private string edtPagUsuC_Jsonclick ;
      private string edtPagFecC_Internalname ;
      private string edtPagFecC_Jsonclick ;
      private string edtPagUsuM_Internalname ;
      private string A1495PagUsuM ;
      private string edtPagUsuM_Jsonclick ;
      private string edtPagFecM_Internalname ;
      private string edtPagFecM_Jsonclick ;
      private string edtPagPrvDsc_Internalname ;
      private string A1488PagPrvDsc ;
      private string edtPagPrvDsc_Jsonclick ;
      private string edtPagForDsc_Internalname ;
      private string A1485PagForDsc ;
      private string edtPagForDsc_Jsonclick ;
      private string edtPagForBanSts_Internalname ;
      private string edtPagForBanSts_Jsonclick ;
      private string edtPagCBMon_Internalname ;
      private string edtPagCBMon_Jsonclick ;
      private string edtPagMonDsc_Internalname ;
      private string A1486PagMonDsc ;
      private string edtPagMonDsc_Jsonclick ;
      private string edtPagBanDsc_Internalname ;
      private string A1472PagBanDsc ;
      private string edtPagBanDsc_Jsonclick ;
      private string edtPagCBMonDsc_Internalname ;
      private string A1474PagCBMonDsc ;
      private string edtPagCBMonDsc_Jsonclick ;
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
      private string Z1488PagPrvDsc ;
      private string Z1485PagForDsc ;
      private string Z1472PagBanDsc ;
      private string Z1474PagCBMonDsc ;
      private string Z1486PagMonDsc ;
      private string sMode180 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ417PagPrvCod ;
      private string ZZ415PagCBCod ;
      private string ZZ1475PagCheque ;
      private string ZZ1489PagRegistro ;
      private string ZZ1498PagVouNum ;
      private string ZZ1494PagUsuC ;
      private string ZZ1495PagUsuM ;
      private string ZZ1488PagPrvDsc ;
      private string ZZ1485PagForDsc ;
      private string ZZ1472PagBanDsc ;
      private string ZZ1474PagCBMonDsc ;
      private string ZZ1486PagMonDsc ;
      private DateTime Z418PagFech ;
      private DateTime Z1482PagFecC ;
      private DateTime Z1483PagFecM ;
      private DateTime A418PagFech ;
      private DateTime A1482PagFecC ;
      private DateTime A1483PagFecM ;
      private DateTime ZZ418PagFech ;
      private DateTime ZZ1482PagFecC ;
      private DateTime ZZ1483PagFecM ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n414PagBanCod ;
      private bool n415PagCBCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T005D10_A1493PagTotal ;
      private long[] T005D10_A412PagReg ;
      private DateTime[] T005D10_A418PagFech ;
      private string[] T005D10_A1475PagCheque ;
      private string[] T005D10_A1489PagRegistro ;
      private int[] T005D10_A1492PagTItem ;
      private decimal[] T005D10_A1491PagTipCmb ;
      private decimal[] T005D10_A1487PagPago ;
      private decimal[] T005D10_A1471PagAjuste ;
      private short[] T005D10_A1496PagVouAno ;
      private short[] T005D10_A1497PagVouMes ;
      private int[] T005D10_A1490PagTASICod ;
      private string[] T005D10_A1498PagVouNum ;
      private string[] T005D10_A1494PagUsuC ;
      private DateTime[] T005D10_A1482PagFecC ;
      private string[] T005D10_A1495PagUsuM ;
      private DateTime[] T005D10_A1483PagFecM ;
      private string[] T005D10_A1488PagPrvDsc ;
      private string[] T005D10_A1485PagForDsc ;
      private short[] T005D10_A1484PagForBanSts ;
      private string[] T005D10_A1486PagMonDsc ;
      private string[] T005D10_A1472PagBanDsc ;
      private string[] T005D10_A1474PagCBMonDsc ;
      private string[] T005D10_A417PagPrvCod ;
      private int[] T005D10_A416PagForCod ;
      private int[] T005D10_A414PagBanCod ;
      private bool[] T005D10_n414PagBanCod ;
      private string[] T005D10_A415PagCBCod ;
      private bool[] T005D10_n415PagCBCod ;
      private int[] T005D10_A413PagMonCod ;
      private int[] T005D10_A1473PagCBMon ;
      private string[] T005D4_A1488PagPrvDsc ;
      private string[] T005D5_A1485PagForDsc ;
      private short[] T005D5_A1484PagForBanSts ;
      private string[] T005D6_A1472PagBanDsc ;
      private int[] T005D7_A1473PagCBMon ;
      private string[] T005D9_A1474PagCBMonDsc ;
      private string[] T005D8_A1486PagMonDsc ;
      private string[] T005D11_A1488PagPrvDsc ;
      private string[] T005D12_A1485PagForDsc ;
      private short[] T005D12_A1484PagForBanSts ;
      private string[] T005D13_A1472PagBanDsc ;
      private int[] T005D14_A1473PagCBMon ;
      private string[] T005D15_A1474PagCBMonDsc ;
      private string[] T005D16_A1486PagMonDsc ;
      private long[] T005D17_A412PagReg ;
      private decimal[] T005D3_A1493PagTotal ;
      private long[] T005D3_A412PagReg ;
      private DateTime[] T005D3_A418PagFech ;
      private string[] T005D3_A1475PagCheque ;
      private string[] T005D3_A1489PagRegistro ;
      private int[] T005D3_A1492PagTItem ;
      private decimal[] T005D3_A1491PagTipCmb ;
      private decimal[] T005D3_A1487PagPago ;
      private decimal[] T005D3_A1471PagAjuste ;
      private short[] T005D3_A1496PagVouAno ;
      private short[] T005D3_A1497PagVouMes ;
      private int[] T005D3_A1490PagTASICod ;
      private string[] T005D3_A1498PagVouNum ;
      private string[] T005D3_A1494PagUsuC ;
      private DateTime[] T005D3_A1482PagFecC ;
      private string[] T005D3_A1495PagUsuM ;
      private DateTime[] T005D3_A1483PagFecM ;
      private string[] T005D3_A417PagPrvCod ;
      private int[] T005D3_A416PagForCod ;
      private int[] T005D3_A414PagBanCod ;
      private bool[] T005D3_n414PagBanCod ;
      private string[] T005D3_A415PagCBCod ;
      private bool[] T005D3_n415PagCBCod ;
      private int[] T005D3_A413PagMonCod ;
      private long[] T005D18_A412PagReg ;
      private long[] T005D19_A412PagReg ;
      private decimal[] T005D2_A1493PagTotal ;
      private long[] T005D2_A412PagReg ;
      private DateTime[] T005D2_A418PagFech ;
      private string[] T005D2_A1475PagCheque ;
      private string[] T005D2_A1489PagRegistro ;
      private int[] T005D2_A1492PagTItem ;
      private decimal[] T005D2_A1491PagTipCmb ;
      private decimal[] T005D2_A1487PagPago ;
      private decimal[] T005D2_A1471PagAjuste ;
      private short[] T005D2_A1496PagVouAno ;
      private short[] T005D2_A1497PagVouMes ;
      private int[] T005D2_A1490PagTASICod ;
      private string[] T005D2_A1498PagVouNum ;
      private string[] T005D2_A1494PagUsuC ;
      private DateTime[] T005D2_A1482PagFecC ;
      private string[] T005D2_A1495PagUsuM ;
      private DateTime[] T005D2_A1483PagFecM ;
      private string[] T005D2_A417PagPrvCod ;
      private int[] T005D2_A416PagForCod ;
      private int[] T005D2_A414PagBanCod ;
      private bool[] T005D2_n414PagBanCod ;
      private string[] T005D2_A415PagCBCod ;
      private bool[] T005D2_n415PagCBCod ;
      private int[] T005D2_A413PagMonCod ;
      private string[] T005D23_A1488PagPrvDsc ;
      private string[] T005D24_A1485PagForDsc ;
      private short[] T005D24_A1484PagForBanSts ;
      private string[] T005D25_A1472PagBanDsc ;
      private int[] T005D26_A1473PagCBMon ;
      private string[] T005D27_A1474PagCBMonDsc ;
      private string[] T005D28_A1486PagMonDsc ;
      private long[] T005D29_A412PagReg ;
      private short[] T005D29_A419PagItem ;
      private long[] T005D30_A412PagReg ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tspagos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tspagos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005D10;
        prmT005D10 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D4;
        prmT005D4 = new Object[] {
        new ParDef("@PagPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005D5;
        prmT005D5 = new Object[] {
        new ParDef("@PagForCod",GXType.Int32,6,0)
        };
        Object[] prmT005D6;
        prmT005D6 = new Object[] {
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005D7;
        prmT005D7 = new Object[] {
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PagCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005D9;
        prmT005D9 = new Object[] {
        new ParDef("@PagCBMon",GXType.Int32,6,0)
        };
        Object[] prmT005D8;
        prmT005D8 = new Object[] {
        new ParDef("@PagMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005D11;
        prmT005D11 = new Object[] {
        new ParDef("@PagPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005D12;
        prmT005D12 = new Object[] {
        new ParDef("@PagForCod",GXType.Int32,6,0)
        };
        Object[] prmT005D13;
        prmT005D13 = new Object[] {
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005D14;
        prmT005D14 = new Object[] {
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PagCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005D15;
        prmT005D15 = new Object[] {
        new ParDef("@PagCBMon",GXType.Int32,6,0)
        };
        Object[] prmT005D16;
        prmT005D16 = new Object[] {
        new ParDef("@PagMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005D17;
        prmT005D17 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D3;
        prmT005D3 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D18;
        prmT005D18 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D19;
        prmT005D19 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D2;
        prmT005D2 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D20;
        prmT005D20 = new Object[] {
        new ParDef("@PagTotal",GXType.Decimal,15,2) ,
        new ParDef("@PagReg",GXType.Decimal,10,0) ,
        new ParDef("@PagFech",GXType.Date,8,0) ,
        new ParDef("@PagCheque",GXType.NChar,20,0) ,
        new ParDef("@PagRegistro",GXType.NChar,10,0) ,
        new ParDef("@PagTItem",GXType.Int32,6,0) ,
        new ParDef("@PagTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@PagPago",GXType.Decimal,15,2) ,
        new ParDef("@PagAjuste",GXType.Decimal,15,2) ,
        new ParDef("@PagVouAno",GXType.Int16,4,0) ,
        new ParDef("@PagVouMes",GXType.Int16,2,0) ,
        new ParDef("@PagTASICod",GXType.Int32,6,0) ,
        new ParDef("@PagVouNum",GXType.NChar,10,0) ,
        new ParDef("@PagUsuC",GXType.NChar,10,0) ,
        new ParDef("@PagFecC",GXType.Date,8,0) ,
        new ParDef("@PagUsuM",GXType.NChar,10,0) ,
        new ParDef("@PagFecM",GXType.Date,8,0) ,
        new ParDef("@PagPrvCod",GXType.NChar,20,0) ,
        new ParDef("@PagForCod",GXType.Int32,6,0) ,
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PagCBCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@PagMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005D21;
        prmT005D21 = new Object[] {
        new ParDef("@PagTotal",GXType.Decimal,15,2) ,
        new ParDef("@PagFech",GXType.Date,8,0) ,
        new ParDef("@PagCheque",GXType.NChar,20,0) ,
        new ParDef("@PagRegistro",GXType.NChar,10,0) ,
        new ParDef("@PagTItem",GXType.Int32,6,0) ,
        new ParDef("@PagTipCmb",GXType.Decimal,15,5) ,
        new ParDef("@PagPago",GXType.Decimal,15,2) ,
        new ParDef("@PagAjuste",GXType.Decimal,15,2) ,
        new ParDef("@PagVouAno",GXType.Int16,4,0) ,
        new ParDef("@PagVouMes",GXType.Int16,2,0) ,
        new ParDef("@PagTASICod",GXType.Int32,6,0) ,
        new ParDef("@PagVouNum",GXType.NChar,10,0) ,
        new ParDef("@PagUsuC",GXType.NChar,10,0) ,
        new ParDef("@PagFecC",GXType.Date,8,0) ,
        new ParDef("@PagUsuM",GXType.NChar,10,0) ,
        new ParDef("@PagFecM",GXType.Date,8,0) ,
        new ParDef("@PagPrvCod",GXType.NChar,20,0) ,
        new ParDef("@PagForCod",GXType.Int32,6,0) ,
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PagCBCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@PagMonCod",GXType.Int32,6,0) ,
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D22;
        prmT005D22 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D29;
        prmT005D29 = new Object[] {
        new ParDef("@PagReg",GXType.Decimal,10,0)
        };
        Object[] prmT005D30;
        prmT005D30 = new Object[] {
        };
        Object[] prmT005D23;
        prmT005D23 = new Object[] {
        new ParDef("@PagPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005D24;
        prmT005D24 = new Object[] {
        new ParDef("@PagForCod",GXType.Int32,6,0)
        };
        Object[] prmT005D25;
        prmT005D25 = new Object[] {
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005D26;
        prmT005D26 = new Object[] {
        new ParDef("@PagBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@PagCBCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT005D27;
        prmT005D27 = new Object[] {
        new ParDef("@PagCBMon",GXType.Int32,6,0)
        };
        Object[] prmT005D28;
        prmT005D28 = new Object[] {
        new ParDef("@PagMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005D2", "SELECT [PagTotal], [PagReg], [PagFech], [PagCheque], [PagRegistro], [PagTItem], [PagTipCmb], [PagPago], [PagAjuste], [PagVouAno], [PagVouMes], [PagTASICod], [PagVouNum], [PagUsuC], [PagFecC], [PagUsuM], [PagFecM], [PagPrvCod] AS PagPrvCod, [PagForCod] AS PagForCod, [PagBanCod] AS PagBanCod, [PagCBCod] AS PagCBCod, [PagMonCod] AS PagMonCod FROM [TSPAGOS] WITH (UPDLOCK) WHERE [PagReg] = @PagReg ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D3", "SELECT [PagTotal], [PagReg], [PagFech], [PagCheque], [PagRegistro], [PagTItem], [PagTipCmb], [PagPago], [PagAjuste], [PagVouAno], [PagVouMes], [PagTASICod], [PagVouNum], [PagUsuC], [PagFecC], [PagUsuM], [PagFecM], [PagPrvCod] AS PagPrvCod, [PagForCod] AS PagForCod, [PagBanCod] AS PagBanCod, [PagCBCod] AS PagCBCod, [PagMonCod] AS PagMonCod FROM [TSPAGOS] WHERE [PagReg] = @PagReg ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D4", "SELECT [PrvDsc] AS PagPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @PagPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D5", "SELECT [ForDsc] AS PagForDsc, [ForBanSts] AS PagForBanSts FROM [CFORMAPAGO] WHERE [ForCod] = @PagForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D6", "SELECT [BanDsc] AS PagBanDsc FROM [TSBANCOS] WHERE [BanCod] = @PagBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D7", "SELECT [MonCod] AS PagCBMon FROM [TSCUENTABANCO] WHERE [BanCod] = @PagBanCod AND [CBCod] = @PagCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D8", "SELECT [MonDsc] AS PagMonDsc FROM [CMONEDAS] WHERE [MonCod] = @PagMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D9", "SELECT [MonDsc] AS PagCBMonDsc FROM [CMONEDAS] WHERE [MonCod] = @PagCBMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D10", "SELECT TM1.[PagTotal], TM1.[PagReg], TM1.[PagFech], TM1.[PagCheque], TM1.[PagRegistro], TM1.[PagTItem], TM1.[PagTipCmb], TM1.[PagPago], TM1.[PagAjuste], TM1.[PagVouAno], TM1.[PagVouMes], TM1.[PagTASICod], TM1.[PagVouNum], TM1.[PagUsuC], TM1.[PagFecC], TM1.[PagUsuM], TM1.[PagFecM], T2.[PrvDsc] AS PagPrvDsc, T3.[ForDsc] AS PagForDsc, T3.[ForBanSts] AS PagForBanSts, T7.[MonDsc] AS PagMonDsc, T4.[BanDsc] AS PagBanDsc, T6.[MonDsc] AS PagCBMonDsc, TM1.[PagPrvCod] AS PagPrvCod, TM1.[PagForCod] AS PagForCod, TM1.[PagBanCod] AS PagBanCod, TM1.[PagCBCod] AS PagCBCod, TM1.[PagMonCod] AS PagMonCod, T5.[MonCod] AS PagCBMon FROM (((((([TSPAGOS] TM1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = TM1.[PagPrvCod]) INNER JOIN [CFORMAPAGO] T3 ON T3.[ForCod] = TM1.[PagForCod]) LEFT JOIN [TSBANCOS] T4 ON T4.[BanCod] = TM1.[PagBanCod]) LEFT JOIN [TSCUENTABANCO] T5 ON T5.[BanCod] = TM1.[PagBanCod] AND T5.[CBCod] = TM1.[PagCBCod]) LEFT JOIN [CMONEDAS] T6 ON T6.[MonCod] = T5.[MonCod]) INNER JOIN [CMONEDAS] T7 ON T7.[MonCod] = TM1.[PagMonCod]) WHERE TM1.[PagReg] = @PagReg ORDER BY TM1.[PagReg]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005D10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D11", "SELECT [PrvDsc] AS PagPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @PagPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D12", "SELECT [ForDsc] AS PagForDsc, [ForBanSts] AS PagForBanSts FROM [CFORMAPAGO] WHERE [ForCod] = @PagForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D13", "SELECT [BanDsc] AS PagBanDsc FROM [TSBANCOS] WHERE [BanCod] = @PagBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D14", "SELECT [MonCod] AS PagCBMon FROM [TSCUENTABANCO] WHERE [BanCod] = @PagBanCod AND [CBCod] = @PagCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D15", "SELECT [MonDsc] AS PagCBMonDsc FROM [CMONEDAS] WHERE [MonCod] = @PagCBMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D16", "SELECT [MonDsc] AS PagMonDsc FROM [CMONEDAS] WHERE [MonCod] = @PagMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D17", "SELECT [PagReg] FROM [TSPAGOS] WHERE [PagReg] = @PagReg  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005D17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D18", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE ( [PagReg] > @PagReg) ORDER BY [PagReg]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005D18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005D19", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE ( [PagReg] < @PagReg) ORDER BY [PagReg] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005D19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005D20", "INSERT INTO [TSPAGOS]([PagTotal], [PagReg], [PagFech], [PagCheque], [PagRegistro], [PagTItem], [PagTipCmb], [PagPago], [PagAjuste], [PagVouAno], [PagVouMes], [PagTASICod], [PagVouNum], [PagUsuC], [PagFecC], [PagUsuM], [PagFecM], [PagPrvCod], [PagForCod], [PagBanCod], [PagCBCod], [PagMonCod]) VALUES(@PagTotal, @PagReg, @PagFech, @PagCheque, @PagRegistro, @PagTItem, @PagTipCmb, @PagPago, @PagAjuste, @PagVouAno, @PagVouMes, @PagTASICod, @PagVouNum, @PagUsuC, @PagFecC, @PagUsuM, @PagFecM, @PagPrvCod, @PagForCod, @PagBanCod, @PagCBCod, @PagMonCod)", GxErrorMask.GX_NOMASK,prmT005D20)
           ,new CursorDef("T005D21", "UPDATE [TSPAGOS] SET [PagTotal]=@PagTotal, [PagFech]=@PagFech, [PagCheque]=@PagCheque, [PagRegistro]=@PagRegistro, [PagTItem]=@PagTItem, [PagTipCmb]=@PagTipCmb, [PagPago]=@PagPago, [PagAjuste]=@PagAjuste, [PagVouAno]=@PagVouAno, [PagVouMes]=@PagVouMes, [PagTASICod]=@PagTASICod, [PagVouNum]=@PagVouNum, [PagUsuC]=@PagUsuC, [PagFecC]=@PagFecC, [PagUsuM]=@PagUsuM, [PagFecM]=@PagFecM, [PagPrvCod]=@PagPrvCod, [PagForCod]=@PagForCod, [PagBanCod]=@PagBanCod, [PagCBCod]=@PagCBCod, [PagMonCod]=@PagMonCod  WHERE [PagReg] = @PagReg", GxErrorMask.GX_NOMASK,prmT005D21)
           ,new CursorDef("T005D22", "DELETE FROM [TSPAGOS]  WHERE [PagReg] = @PagReg", GxErrorMask.GX_NOMASK,prmT005D22)
           ,new CursorDef("T005D23", "SELECT [PrvDsc] AS PagPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @PagPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D24", "SELECT [ForDsc] AS PagForDsc, [ForBanSts] AS PagForBanSts FROM [CFORMAPAGO] WHERE [ForCod] = @PagForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D25", "SELECT [BanDsc] AS PagBanDsc FROM [TSBANCOS] WHERE [BanCod] = @PagBanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D26", "SELECT [MonCod] AS PagCBMon FROM [TSCUENTABANCO] WHERE [BanCod] = @PagBanCod AND [CBCod] = @PagCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D27", "SELECT [MonDsc] AS PagCBMonDsc FROM [CMONEDAS] WHERE [MonCod] = @PagCBMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D28", "SELECT [MonDsc] AS PagMonDsc FROM [CMONEDAS] WHERE [MonCod] = @PagMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005D29", "SELECT TOP 1 [PagReg], [PagItem] FROM [TSPAGOSDET] WHERE [PagReg] = @PagReg ",true, GxErrorMask.GX_NOMASK, false, this,prmT005D29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005D30", "SELECT [PagReg] FROM [TSPAGOS] ORDER BY [PagReg]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005D30,100, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 20);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((bool[]) buf[20])[0] = rslt.wasNull(20);
              ((string[]) buf[21])[0] = rslt.getString(21, 20);
              ((bool[]) buf[22])[0] = rslt.wasNull(21);
              ((int[]) buf[23])[0] = rslt.getInt(22);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 20);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((bool[]) buf[20])[0] = rslt.wasNull(20);
              ((string[]) buf[21])[0] = rslt.getString(21, 20);
              ((bool[]) buf[22])[0] = rslt.wasNull(21);
              ((int[]) buf[23])[0] = rslt.getInt(22);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((short[]) buf[19])[0] = rslt.getShort(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 100);
              ((string[]) buf[21])[0] = rslt.getString(22, 100);
              ((string[]) buf[22])[0] = rslt.getString(23, 100);
              ((string[]) buf[23])[0] = rslt.getString(24, 20);
              ((int[]) buf[24])[0] = rslt.getInt(25);
              ((int[]) buf[25])[0] = rslt.getInt(26);
              ((bool[]) buf[26])[0] = rslt.wasNull(26);
              ((string[]) buf[27])[0] = rslt.getString(27, 20);
              ((bool[]) buf[28])[0] = rslt.wasNull(27);
              ((int[]) buf[29])[0] = rslt.getInt(28);
              ((int[]) buf[30])[0] = rslt.getInt(29);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 27 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 28 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
