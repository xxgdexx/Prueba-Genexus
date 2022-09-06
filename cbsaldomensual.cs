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
   public class cbsaldomensual : GXDataArea
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
            A123SalCueCod = GetPar( "SalCueCod");
            AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A123SalCueCod) ;
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
            Form.Meta.addItem("description", "Saldos Mensual Almacen", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSalVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbsaldomensual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbsaldomensual( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Saldos Mensual Almacen", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBSALDOMENSUAL.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBSALDOMENSUAL.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalVouAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A121SalVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtSalVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A121SalVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A121SalVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalVouMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A122SalVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtSalVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A122SalVouMes), "Z9") : context.localUtil.Format( (decimal)(A122SalVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalCueCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCueCod_Internalname, StringUtil.RTrim( A123SalCueCod), StringUtil.RTrim( context.localUtil.Format( A123SalCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A124SalMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtSalMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A124SalMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A124SalMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalCueAux_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalCueAux_Internalname, "Auxiliar", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCueAux_Internalname, StringUtil.RTrim( A125SalCueAux), StringUtil.RTrim( context.localUtil.Format( A125SalCueAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCueAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCueAux_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalVouDebe_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalVouDebe_Internalname, "Debe MN", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalVouDebe_Internalname, StringUtil.LTrim( StringUtil.NToC( A1839SalVouDebe, 17, 2, ".", "")), StringUtil.LTrim( ((edtSalVouDebe_Enabled!=0) ? context.localUtil.Format( A1839SalVouDebe, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1839SalVouDebe, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalVouDebe_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalVouDebe_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalVouHaber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalVouHaber_Internalname, "Haber MN", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalVouHaber_Internalname, StringUtil.LTrim( StringUtil.NToC( A1841SalVouHaber, 17, 2, ".", "")), StringUtil.LTrim( ((edtSalVouHaber_Enabled!=0) ? context.localUtil.Format( A1841SalVouHaber, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1841SalVouHaber, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalVouHaber_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalVouHaber_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalTipCmb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalTipCmb_Internalname, "Tipo de Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1838SalTipCmb, 17, 4, ".", "")), StringUtil.LTrim( ((edtSalTipCmb_Enabled!=0) ? context.localUtil.Format( A1838SalTipCmb, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1838SalTipCmb, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalTipCmb_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalVouDebeD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalVouDebeD_Internalname, "Debe ME", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalVouDebeD_Internalname, StringUtil.LTrim( StringUtil.NToC( A1840SalVouDebeD, 17, 2, ".", "")), StringUtil.LTrim( ((edtSalVouDebeD_Enabled!=0) ? context.localUtil.Format( A1840SalVouDebeD, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1840SalVouDebeD, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalVouDebeD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalVouDebeD_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtSalVouHaberD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtSalVouHaberD_Internalname, "Haber ME", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalVouHaberD_Internalname, StringUtil.LTrim( StringUtil.NToC( A1842SalVouHaberD, 17, 2, ".", "")), StringUtil.LTrim( ((edtSalVouHaberD_Enabled!=0) ? context.localUtil.Format( A1842SalVouHaberD, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1842SalVouHaberD, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalVouHaberD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalVouHaberD_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CBSALDOMENSUAL.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBSALDOMENSUAL.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBSALDOMENSUAL.htm");
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
            Z121SalVouAno = (short)(context.localUtil.CToN( cgiGet( "Z121SalVouAno"), ".", ","));
            Z122SalVouMes = (short)(context.localUtil.CToN( cgiGet( "Z122SalVouMes"), ".", ","));
            Z123SalCueCod = cgiGet( "Z123SalCueCod");
            Z124SalMonCod = (int)(context.localUtil.CToN( cgiGet( "Z124SalMonCod"), ".", ","));
            Z125SalCueAux = cgiGet( "Z125SalCueAux");
            Z1839SalVouDebe = context.localUtil.CToN( cgiGet( "Z1839SalVouDebe"), ".", ",");
            Z1841SalVouHaber = context.localUtil.CToN( cgiGet( "Z1841SalVouHaber"), ".", ",");
            Z1838SalTipCmb = context.localUtil.CToN( cgiGet( "Z1838SalTipCmb"), ".", ",");
            Z1840SalVouDebeD = context.localUtil.CToN( cgiGet( "Z1840SalVouDebeD"), ".", ",");
            Z1842SalVouHaberD = context.localUtil.CToN( cgiGet( "Z1842SalVouHaberD"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALVOUANO");
               AnyError = 1;
               GX_FocusControl = edtSalVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A121SalVouAno = 0;
               AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
            }
            else
            {
               A121SalVouAno = (short)(context.localUtil.CToN( cgiGet( edtSalVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALVOUMES");
               AnyError = 1;
               GX_FocusControl = edtSalVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A122SalVouMes = 0;
               AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
            }
            else
            {
               A122SalVouMes = (short)(context.localUtil.CToN( cgiGet( edtSalVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
            }
            A123SalCueCod = cgiGet( edtSalCueCod_Internalname);
            AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALMONCOD");
               AnyError = 1;
               GX_FocusControl = edtSalMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A124SalMonCod = 0;
               AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
            }
            else
            {
               A124SalMonCod = (int)(context.localUtil.CToN( cgiGet( edtSalMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
            }
            A125SalCueAux = cgiGet( edtSalCueAux_Internalname);
            AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalVouDebe_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalVouDebe_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALVOUDEBE");
               AnyError = 1;
               GX_FocusControl = edtSalVouDebe_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1839SalVouDebe = 0;
               AssignAttri("", false, "A1839SalVouDebe", StringUtil.LTrimStr( A1839SalVouDebe, 15, 2));
            }
            else
            {
               A1839SalVouDebe = context.localUtil.CToN( cgiGet( edtSalVouDebe_Internalname), ".", ",");
               AssignAttri("", false, "A1839SalVouDebe", StringUtil.LTrimStr( A1839SalVouDebe, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalVouHaber_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalVouHaber_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALVOUHABER");
               AnyError = 1;
               GX_FocusControl = edtSalVouHaber_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1841SalVouHaber = 0;
               AssignAttri("", false, "A1841SalVouHaber", StringUtil.LTrimStr( A1841SalVouHaber, 15, 2));
            }
            else
            {
               A1841SalVouHaber = context.localUtil.CToN( cgiGet( edtSalVouHaber_Internalname), ".", ",");
               AssignAttri("", false, "A1841SalVouHaber", StringUtil.LTrimStr( A1841SalVouHaber, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalTipCmb_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalTipCmb_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtSalTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1838SalTipCmb = 0;
               AssignAttri("", false, "A1838SalTipCmb", StringUtil.LTrimStr( A1838SalTipCmb, 15, 4));
            }
            else
            {
               A1838SalTipCmb = context.localUtil.CToN( cgiGet( edtSalTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1838SalTipCmb", StringUtil.LTrimStr( A1838SalTipCmb, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalVouDebeD_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalVouDebeD_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALVOUDEBED");
               AnyError = 1;
               GX_FocusControl = edtSalVouDebeD_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1840SalVouDebeD = 0;
               AssignAttri("", false, "A1840SalVouDebeD", StringUtil.LTrimStr( A1840SalVouDebeD, 15, 2));
            }
            else
            {
               A1840SalVouDebeD = context.localUtil.CToN( cgiGet( edtSalVouDebeD_Internalname), ".", ",");
               AssignAttri("", false, "A1840SalVouDebeD", StringUtil.LTrimStr( A1840SalVouDebeD, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalVouHaberD_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalVouHaberD_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALVOUHABERD");
               AnyError = 1;
               GX_FocusControl = edtSalVouHaberD_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1842SalVouHaberD = 0;
               AssignAttri("", false, "A1842SalVouHaberD", StringUtil.LTrimStr( A1842SalVouHaberD, 15, 2));
            }
            else
            {
               A1842SalVouHaberD = context.localUtil.CToN( cgiGet( edtSalVouHaberD_Internalname), ".", ",");
               AssignAttri("", false, "A1842SalVouHaberD", StringUtil.LTrimStr( A1842SalVouHaberD, 15, 2));
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
               A121SalVouAno = (short)(NumberUtil.Val( GetPar( "SalVouAno"), "."));
               AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
               A122SalVouMes = (short)(NumberUtil.Val( GetPar( "SalVouMes"), "."));
               AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
               A123SalCueCod = GetPar( "SalCueCod");
               AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
               A124SalMonCod = (int)(NumberUtil.Val( GetPar( "SalMonCod"), "."));
               AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
               A125SalCueAux = GetPar( "SalCueAux");
               AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
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
               InitAll2069( ) ;
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
         DisableAttributes2069( ) ;
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

      protected void ResetCaption200( )
      {
      }

      protected void ZM2069( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1839SalVouDebe = T00203_A1839SalVouDebe[0];
               Z1841SalVouHaber = T00203_A1841SalVouHaber[0];
               Z1838SalTipCmb = T00203_A1838SalTipCmb[0];
               Z1840SalVouDebeD = T00203_A1840SalVouDebeD[0];
               Z1842SalVouHaberD = T00203_A1842SalVouHaberD[0];
            }
            else
            {
               Z1839SalVouDebe = A1839SalVouDebe;
               Z1841SalVouHaber = A1841SalVouHaber;
               Z1838SalTipCmb = A1838SalTipCmb;
               Z1840SalVouDebeD = A1840SalVouDebeD;
               Z1842SalVouHaberD = A1842SalVouHaberD;
            }
         }
         if ( GX_JID == -1 )
         {
            Z121SalVouAno = A121SalVouAno;
            Z122SalVouMes = A122SalVouMes;
            Z124SalMonCod = A124SalMonCod;
            Z125SalCueAux = A125SalCueAux;
            Z1839SalVouDebe = A1839SalVouDebe;
            Z1841SalVouHaber = A1841SalVouHaber;
            Z1838SalTipCmb = A1838SalTipCmb;
            Z1840SalVouDebeD = A1840SalVouDebeD;
            Z1842SalVouHaberD = A1842SalVouHaberD;
            Z123SalCueCod = A123SalCueCod;
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

      protected void Load2069( )
      {
         /* Using cursor T00205 */
         pr_default.execute(3, new Object[] {A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound69 = 1;
            A1839SalVouDebe = T00205_A1839SalVouDebe[0];
            AssignAttri("", false, "A1839SalVouDebe", StringUtil.LTrimStr( A1839SalVouDebe, 15, 2));
            A1841SalVouHaber = T00205_A1841SalVouHaber[0];
            AssignAttri("", false, "A1841SalVouHaber", StringUtil.LTrimStr( A1841SalVouHaber, 15, 2));
            A1838SalTipCmb = T00205_A1838SalTipCmb[0];
            AssignAttri("", false, "A1838SalTipCmb", StringUtil.LTrimStr( A1838SalTipCmb, 15, 4));
            A1840SalVouDebeD = T00205_A1840SalVouDebeD[0];
            AssignAttri("", false, "A1840SalVouDebeD", StringUtil.LTrimStr( A1840SalVouDebeD, 15, 2));
            A1842SalVouHaberD = T00205_A1842SalVouHaberD[0];
            AssignAttri("", false, "A1842SalVouHaberD", StringUtil.LTrimStr( A1842SalVouHaberD, 15, 2));
            ZM2069( -1) ;
         }
         pr_default.close(3);
         OnLoadActions2069( ) ;
      }

      protected void OnLoadActions2069( )
      {
      }

      protected void CheckExtendedTable2069( )
      {
         nIsDirty_69 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00204 */
         pr_default.execute(2, new Object[] {A123SalCueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Saldo Mes Cuenta'.", "ForeignKeyNotFound", 1, "SALCUECOD");
            AnyError = 1;
            GX_FocusControl = edtSalCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2069( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A123SalCueCod )
      {
         /* Using cursor T00206 */
         pr_default.execute(4, new Object[] {A123SalCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Saldo Mes Cuenta'.", "ForeignKeyNotFound", 1, "SALCUECOD");
            AnyError = 1;
            GX_FocusControl = edtSalCueCod_Internalname;
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

      protected void GetKey2069( )
      {
         /* Using cursor T00207 */
         pr_default.execute(5, new Object[] {A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound69 = 1;
         }
         else
         {
            RcdFound69 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00203 */
         pr_default.execute(1, new Object[] {A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2069( 1) ;
            RcdFound69 = 1;
            A121SalVouAno = T00203_A121SalVouAno[0];
            AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
            A122SalVouMes = T00203_A122SalVouMes[0];
            AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
            A124SalMonCod = T00203_A124SalMonCod[0];
            AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
            A125SalCueAux = T00203_A125SalCueAux[0];
            AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
            A1839SalVouDebe = T00203_A1839SalVouDebe[0];
            AssignAttri("", false, "A1839SalVouDebe", StringUtil.LTrimStr( A1839SalVouDebe, 15, 2));
            A1841SalVouHaber = T00203_A1841SalVouHaber[0];
            AssignAttri("", false, "A1841SalVouHaber", StringUtil.LTrimStr( A1841SalVouHaber, 15, 2));
            A1838SalTipCmb = T00203_A1838SalTipCmb[0];
            AssignAttri("", false, "A1838SalTipCmb", StringUtil.LTrimStr( A1838SalTipCmb, 15, 4));
            A1840SalVouDebeD = T00203_A1840SalVouDebeD[0];
            AssignAttri("", false, "A1840SalVouDebeD", StringUtil.LTrimStr( A1840SalVouDebeD, 15, 2));
            A1842SalVouHaberD = T00203_A1842SalVouHaberD[0];
            AssignAttri("", false, "A1842SalVouHaberD", StringUtil.LTrimStr( A1842SalVouHaberD, 15, 2));
            A123SalCueCod = T00203_A123SalCueCod[0];
            AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
            Z121SalVouAno = A121SalVouAno;
            Z122SalVouMes = A122SalVouMes;
            Z123SalCueCod = A123SalCueCod;
            Z124SalMonCod = A124SalMonCod;
            Z125SalCueAux = A125SalCueAux;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2069( ) ;
            if ( AnyError == 1 )
            {
               RcdFound69 = 0;
               InitializeNonKey2069( ) ;
            }
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound69 = 0;
            InitializeNonKey2069( ) ;
            sMode69 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode69;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2069( ) ;
         if ( RcdFound69 == 0 )
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
         RcdFound69 = 0;
         /* Using cursor T00208 */
         pr_default.execute(6, new Object[] {A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00208_A121SalVouAno[0] < A121SalVouAno ) || ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( T00208_A122SalVouMes[0] < A122SalVouMes ) || ( T00208_A122SalVouMes[0] == A122SalVouMes ) && ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00208_A123SalCueCod[0], A123SalCueCod) < 0 ) || ( StringUtil.StrCmp(T00208_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00208_A122SalVouMes[0] == A122SalVouMes ) && ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( T00208_A124SalMonCod[0] < A124SalMonCod ) || ( T00208_A124SalMonCod[0] == A124SalMonCod ) && ( StringUtil.StrCmp(T00208_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00208_A122SalVouMes[0] == A122SalVouMes ) && ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00208_A125SalCueAux[0], A125SalCueAux) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00208_A121SalVouAno[0] > A121SalVouAno ) || ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( T00208_A122SalVouMes[0] > A122SalVouMes ) || ( T00208_A122SalVouMes[0] == A122SalVouMes ) && ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00208_A123SalCueCod[0], A123SalCueCod) > 0 ) || ( StringUtil.StrCmp(T00208_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00208_A122SalVouMes[0] == A122SalVouMes ) && ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( T00208_A124SalMonCod[0] > A124SalMonCod ) || ( T00208_A124SalMonCod[0] == A124SalMonCod ) && ( StringUtil.StrCmp(T00208_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00208_A122SalVouMes[0] == A122SalVouMes ) && ( T00208_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00208_A125SalCueAux[0], A125SalCueAux) > 0 ) ) )
            {
               A121SalVouAno = T00208_A121SalVouAno[0];
               AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
               A122SalVouMes = T00208_A122SalVouMes[0];
               AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
               A123SalCueCod = T00208_A123SalCueCod[0];
               AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
               A124SalMonCod = T00208_A124SalMonCod[0];
               AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
               A125SalCueAux = T00208_A125SalCueAux[0];
               AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
               RcdFound69 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound69 = 0;
         /* Using cursor T00209 */
         pr_default.execute(7, new Object[] {A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00209_A121SalVouAno[0] > A121SalVouAno ) || ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( T00209_A122SalVouMes[0] > A122SalVouMes ) || ( T00209_A122SalVouMes[0] == A122SalVouMes ) && ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00209_A123SalCueCod[0], A123SalCueCod) > 0 ) || ( StringUtil.StrCmp(T00209_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00209_A122SalVouMes[0] == A122SalVouMes ) && ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( T00209_A124SalMonCod[0] > A124SalMonCod ) || ( T00209_A124SalMonCod[0] == A124SalMonCod ) && ( StringUtil.StrCmp(T00209_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00209_A122SalVouMes[0] == A122SalVouMes ) && ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00209_A125SalCueAux[0], A125SalCueAux) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00209_A121SalVouAno[0] < A121SalVouAno ) || ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( T00209_A122SalVouMes[0] < A122SalVouMes ) || ( T00209_A122SalVouMes[0] == A122SalVouMes ) && ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00209_A123SalCueCod[0], A123SalCueCod) < 0 ) || ( StringUtil.StrCmp(T00209_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00209_A122SalVouMes[0] == A122SalVouMes ) && ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( T00209_A124SalMonCod[0] < A124SalMonCod ) || ( T00209_A124SalMonCod[0] == A124SalMonCod ) && ( StringUtil.StrCmp(T00209_A123SalCueCod[0], A123SalCueCod) == 0 ) && ( T00209_A122SalVouMes[0] == A122SalVouMes ) && ( T00209_A121SalVouAno[0] == A121SalVouAno ) && ( StringUtil.StrCmp(T00209_A125SalCueAux[0], A125SalCueAux) < 0 ) ) )
            {
               A121SalVouAno = T00209_A121SalVouAno[0];
               AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
               A122SalVouMes = T00209_A122SalVouMes[0];
               AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
               A123SalCueCod = T00209_A123SalCueCod[0];
               AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
               A124SalMonCod = T00209_A124SalMonCod[0];
               AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
               A125SalCueAux = T00209_A125SalCueAux[0];
               AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
               RcdFound69 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2069( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSalVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2069( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound69 == 1 )
            {
               if ( ( A121SalVouAno != Z121SalVouAno ) || ( A122SalVouMes != Z122SalVouMes ) || ( StringUtil.StrCmp(A123SalCueCod, Z123SalCueCod) != 0 ) || ( A124SalMonCod != Z124SalMonCod ) || ( StringUtil.StrCmp(A125SalCueAux, Z125SalCueAux) != 0 ) )
               {
                  A121SalVouAno = Z121SalVouAno;
                  AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
                  A122SalVouMes = Z122SalVouMes;
                  AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
                  A123SalCueCod = Z123SalCueCod;
                  AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
                  A124SalMonCod = Z124SalMonCod;
                  AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
                  A125SalCueAux = Z125SalCueAux;
                  AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SALVOUANO");
                  AnyError = 1;
                  GX_FocusControl = edtSalVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSalVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2069( ) ;
                  GX_FocusControl = edtSalVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A121SalVouAno != Z121SalVouAno ) || ( A122SalVouMes != Z122SalVouMes ) || ( StringUtil.StrCmp(A123SalCueCod, Z123SalCueCod) != 0 ) || ( A124SalMonCod != Z124SalMonCod ) || ( StringUtil.StrCmp(A125SalCueAux, Z125SalCueAux) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSalVouAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2069( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SALVOUANO");
                     AnyError = 1;
                     GX_FocusControl = edtSalVouAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSalVouAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2069( ) ;
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
         if ( ( A121SalVouAno != Z121SalVouAno ) || ( A122SalVouMes != Z122SalVouMes ) || ( StringUtil.StrCmp(A123SalCueCod, Z123SalCueCod) != 0 ) || ( A124SalMonCod != Z124SalMonCod ) || ( StringUtil.StrCmp(A125SalCueAux, Z125SalCueAux) != 0 ) )
         {
            A121SalVouAno = Z121SalVouAno;
            AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
            A122SalVouMes = Z122SalVouMes;
            AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
            A123SalCueCod = Z123SalCueCod;
            AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
            A124SalMonCod = Z124SalMonCod;
            AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
            A125SalCueAux = Z125SalCueAux;
            AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SALVOUANO");
            AnyError = 1;
            GX_FocusControl = edtSalVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSalVouAno_Internalname;
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
         if ( RcdFound69 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SALVOUANO");
            AnyError = 1;
            GX_FocusControl = edtSalVouAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSalVouDebe_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2069( ) ;
         if ( RcdFound69 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalVouDebe_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2069( ) ;
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
         if ( RcdFound69 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalVouDebe_Internalname;
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
         if ( RcdFound69 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalVouDebe_Internalname;
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
         ScanStart2069( ) ;
         if ( RcdFound69 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound69 != 0 )
            {
               ScanNext2069( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalVouDebe_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2069( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2069( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00202 */
            pr_default.execute(0, new Object[] {A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBSALDOMENSUAL"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1839SalVouDebe != T00202_A1839SalVouDebe[0] ) || ( Z1841SalVouHaber != T00202_A1841SalVouHaber[0] ) || ( Z1838SalTipCmb != T00202_A1838SalTipCmb[0] ) || ( Z1840SalVouDebeD != T00202_A1840SalVouDebeD[0] ) || ( Z1842SalVouHaberD != T00202_A1842SalVouHaberD[0] ) )
            {
               if ( Z1839SalVouDebe != T00202_A1839SalVouDebe[0] )
               {
                  GXUtil.WriteLog("cbsaldomensual:[seudo value changed for attri]"+"SalVouDebe");
                  GXUtil.WriteLogRaw("Old: ",Z1839SalVouDebe);
                  GXUtil.WriteLogRaw("Current: ",T00202_A1839SalVouDebe[0]);
               }
               if ( Z1841SalVouHaber != T00202_A1841SalVouHaber[0] )
               {
                  GXUtil.WriteLog("cbsaldomensual:[seudo value changed for attri]"+"SalVouHaber");
                  GXUtil.WriteLogRaw("Old: ",Z1841SalVouHaber);
                  GXUtil.WriteLogRaw("Current: ",T00202_A1841SalVouHaber[0]);
               }
               if ( Z1838SalTipCmb != T00202_A1838SalTipCmb[0] )
               {
                  GXUtil.WriteLog("cbsaldomensual:[seudo value changed for attri]"+"SalTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1838SalTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T00202_A1838SalTipCmb[0]);
               }
               if ( Z1840SalVouDebeD != T00202_A1840SalVouDebeD[0] )
               {
                  GXUtil.WriteLog("cbsaldomensual:[seudo value changed for attri]"+"SalVouDebeD");
                  GXUtil.WriteLogRaw("Old: ",Z1840SalVouDebeD);
                  GXUtil.WriteLogRaw("Current: ",T00202_A1840SalVouDebeD[0]);
               }
               if ( Z1842SalVouHaberD != T00202_A1842SalVouHaberD[0] )
               {
                  GXUtil.WriteLog("cbsaldomensual:[seudo value changed for attri]"+"SalVouHaberD");
                  GXUtil.WriteLogRaw("Old: ",Z1842SalVouHaberD);
                  GXUtil.WriteLogRaw("Current: ",T00202_A1842SalVouHaberD[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBSALDOMENSUAL"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2069( )
      {
         BeforeValidate2069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2069( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2069( 0) ;
            CheckOptimisticConcurrency2069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002010 */
                     pr_default.execute(8, new Object[] {A121SalVouAno, A122SalVouMes, A124SalMonCod, A125SalCueAux, A1839SalVouDebe, A1841SalVouHaber, A1838SalTipCmb, A1840SalVouDebeD, A1842SalVouHaberD, A123SalCueCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("CBSALDOMENSUAL");
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
                           ResetCaption200( ) ;
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
               Load2069( ) ;
            }
            EndLevel2069( ) ;
         }
         CloseExtendedTableCursors2069( ) ;
      }

      protected void Update2069( )
      {
         BeforeValidate2069( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2069( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2069( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2069( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2069( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002011 */
                     pr_default.execute(9, new Object[] {A1839SalVouDebe, A1841SalVouHaber, A1838SalTipCmb, A1840SalVouDebeD, A1842SalVouHaberD, A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("CBSALDOMENSUAL");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBSALDOMENSUAL"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2069( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption200( ) ;
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
            EndLevel2069( ) ;
         }
         CloseExtendedTableCursors2069( ) ;
      }

      protected void DeferredUpdate2069( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2069( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2069( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2069( ) ;
            AfterConfirm2069( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2069( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002012 */
                  pr_default.execute(10, new Object[] {A121SalVouAno, A122SalVouMes, A123SalCueCod, A124SalMonCod, A125SalCueAux});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("CBSALDOMENSUAL");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound69 == 0 )
                        {
                           InitAll2069( ) ;
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
                        ResetCaption200( ) ;
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
         sMode69 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2069( ) ;
         Gx_mode = sMode69;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2069( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2069( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2069( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbsaldomensual",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues200( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbsaldomensual",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2069( )
      {
         /* Using cursor T002013 */
         pr_default.execute(11);
         RcdFound69 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound69 = 1;
            A121SalVouAno = T002013_A121SalVouAno[0];
            AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
            A122SalVouMes = T002013_A122SalVouMes[0];
            AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
            A123SalCueCod = T002013_A123SalCueCod[0];
            AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
            A124SalMonCod = T002013_A124SalMonCod[0];
            AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
            A125SalCueAux = T002013_A125SalCueAux[0];
            AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2069( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound69 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound69 = 1;
            A121SalVouAno = T002013_A121SalVouAno[0];
            AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
            A122SalVouMes = T002013_A122SalVouMes[0];
            AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
            A123SalCueCod = T002013_A123SalCueCod[0];
            AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
            A124SalMonCod = T002013_A124SalMonCod[0];
            AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
            A125SalCueAux = T002013_A125SalCueAux[0];
            AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
         }
      }

      protected void ScanEnd2069( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm2069( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2069( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2069( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2069( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2069( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2069( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2069( )
      {
         edtSalVouAno_Enabled = 0;
         AssignProp("", false, edtSalVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalVouAno_Enabled), 5, 0), true);
         edtSalVouMes_Enabled = 0;
         AssignProp("", false, edtSalVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalVouMes_Enabled), 5, 0), true);
         edtSalCueCod_Enabled = 0;
         AssignProp("", false, edtSalCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCueCod_Enabled), 5, 0), true);
         edtSalMonCod_Enabled = 0;
         AssignProp("", false, edtSalMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalMonCod_Enabled), 5, 0), true);
         edtSalCueAux_Enabled = 0;
         AssignProp("", false, edtSalCueAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCueAux_Enabled), 5, 0), true);
         edtSalVouDebe_Enabled = 0;
         AssignProp("", false, edtSalVouDebe_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalVouDebe_Enabled), 5, 0), true);
         edtSalVouHaber_Enabled = 0;
         AssignProp("", false, edtSalVouHaber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalVouHaber_Enabled), 5, 0), true);
         edtSalTipCmb_Enabled = 0;
         AssignProp("", false, edtSalTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalTipCmb_Enabled), 5, 0), true);
         edtSalVouDebeD_Enabled = 0;
         AssignProp("", false, edtSalVouDebeD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalVouDebeD_Enabled), 5, 0), true);
         edtSalVouHaberD_Enabled = 0;
         AssignProp("", false, edtSalVouHaberD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalVouHaberD_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2069( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues200( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816423018", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbsaldomensual.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z121SalVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121SalVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z122SalVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z122SalVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z123SalCueCod", StringUtil.RTrim( Z123SalCueCod));
         GxWebStd.gx_hidden_field( context, "Z124SalMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z124SalMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z125SalCueAux", StringUtil.RTrim( Z125SalCueAux));
         GxWebStd.gx_hidden_field( context, "Z1839SalVouDebe", StringUtil.LTrim( StringUtil.NToC( Z1839SalVouDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1841SalVouHaber", StringUtil.LTrim( StringUtil.NToC( Z1841SalVouHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1838SalTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1838SalTipCmb, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1840SalVouDebeD", StringUtil.LTrim( StringUtil.NToC( Z1840SalVouDebeD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1842SalVouHaberD", StringUtil.LTrim( StringUtil.NToC( Z1842SalVouHaberD, 15, 2, ".", "")));
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
         return formatLink("cbsaldomensual.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBSALDOMENSUAL" ;
      }

      public override string GetPgmdesc( )
      {
         return "Saldos Mensual Almacen" ;
      }

      protected void InitializeNonKey2069( )
      {
         A1839SalVouDebe = 0;
         AssignAttri("", false, "A1839SalVouDebe", StringUtil.LTrimStr( A1839SalVouDebe, 15, 2));
         A1841SalVouHaber = 0;
         AssignAttri("", false, "A1841SalVouHaber", StringUtil.LTrimStr( A1841SalVouHaber, 15, 2));
         A1838SalTipCmb = 0;
         AssignAttri("", false, "A1838SalTipCmb", StringUtil.LTrimStr( A1838SalTipCmb, 15, 4));
         A1840SalVouDebeD = 0;
         AssignAttri("", false, "A1840SalVouDebeD", StringUtil.LTrimStr( A1840SalVouDebeD, 15, 2));
         A1842SalVouHaberD = 0;
         AssignAttri("", false, "A1842SalVouHaberD", StringUtil.LTrimStr( A1842SalVouHaberD, 15, 2));
         Z1839SalVouDebe = 0;
         Z1841SalVouHaber = 0;
         Z1838SalTipCmb = 0;
         Z1840SalVouDebeD = 0;
         Z1842SalVouHaberD = 0;
      }

      protected void InitAll2069( )
      {
         A121SalVouAno = 0;
         AssignAttri("", false, "A121SalVouAno", StringUtil.LTrimStr( (decimal)(A121SalVouAno), 4, 0));
         A122SalVouMes = 0;
         AssignAttri("", false, "A122SalVouMes", StringUtil.LTrimStr( (decimal)(A122SalVouMes), 2, 0));
         A123SalCueCod = "";
         AssignAttri("", false, "A123SalCueCod", A123SalCueCod);
         A124SalMonCod = 0;
         AssignAttri("", false, "A124SalMonCod", StringUtil.LTrimStr( (decimal)(A124SalMonCod), 6, 0));
         A125SalCueAux = "";
         AssignAttri("", false, "A125SalCueAux", A125SalCueAux);
         InitializeNonKey2069( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816423032", true, true);
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
         context.AddJavascriptSource("cbsaldomensual.js", "?202281816423033", false, true);
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
         edtSalVouAno_Internalname = "SALVOUANO";
         edtSalVouMes_Internalname = "SALVOUMES";
         edtSalCueCod_Internalname = "SALCUECOD";
         edtSalMonCod_Internalname = "SALMONCOD";
         edtSalCueAux_Internalname = "SALCUEAUX";
         edtSalVouDebe_Internalname = "SALVOUDEBE";
         edtSalVouHaber_Internalname = "SALVOUHABER";
         edtSalTipCmb_Internalname = "SALTIPCMB";
         edtSalVouDebeD_Internalname = "SALVOUDEBED";
         edtSalVouHaberD_Internalname = "SALVOUHABERD";
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
         Form.Caption = "Saldos Mensual Almacen";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSalVouHaberD_Jsonclick = "";
         edtSalVouHaberD_Enabled = 1;
         edtSalVouDebeD_Jsonclick = "";
         edtSalVouDebeD_Enabled = 1;
         edtSalTipCmb_Jsonclick = "";
         edtSalTipCmb_Enabled = 1;
         edtSalVouHaber_Jsonclick = "";
         edtSalVouHaber_Enabled = 1;
         edtSalVouDebe_Jsonclick = "";
         edtSalVouDebe_Enabled = 1;
         edtSalCueAux_Jsonclick = "";
         edtSalCueAux_Enabled = 1;
         edtSalMonCod_Jsonclick = "";
         edtSalMonCod_Enabled = 1;
         edtSalCueCod_Jsonclick = "";
         edtSalCueCod_Enabled = 1;
         edtSalVouMes_Jsonclick = "";
         edtSalVouMes_Enabled = 1;
         edtSalVouAno_Jsonclick = "";
         edtSalVouAno_Enabled = 1;
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
         /* Using cursor T002014 */
         pr_default.execute(12, new Object[] {A123SalCueCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Saldo Mes Cuenta'.", "ForeignKeyNotFound", 1, "SALCUECOD");
            AnyError = 1;
            GX_FocusControl = edtSalCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtSalVouDebe_Internalname;
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

      public void Valid_Salcuecod( )
      {
         /* Using cursor T002014 */
         pr_default.execute(12, new Object[] {A123SalCueCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Saldo Mes Cuenta'.", "ForeignKeyNotFound", 1, "SALCUECOD");
            AnyError = 1;
            GX_FocusControl = edtSalCueCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Salcueaux( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1839SalVouDebe", StringUtil.LTrim( StringUtil.NToC( A1839SalVouDebe, 15, 2, ".", "")));
         AssignAttri("", false, "A1841SalVouHaber", StringUtil.LTrim( StringUtil.NToC( A1841SalVouHaber, 15, 2, ".", "")));
         AssignAttri("", false, "A1838SalTipCmb", StringUtil.LTrim( StringUtil.NToC( A1838SalTipCmb, 15, 4, ".", "")));
         AssignAttri("", false, "A1840SalVouDebeD", StringUtil.LTrim( StringUtil.NToC( A1840SalVouDebeD, 15, 2, ".", "")));
         AssignAttri("", false, "A1842SalVouHaberD", StringUtil.LTrim( StringUtil.NToC( A1842SalVouHaberD, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z121SalVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z121SalVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z122SalVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z122SalVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z123SalCueCod", StringUtil.RTrim( Z123SalCueCod));
         GxWebStd.gx_hidden_field( context, "Z124SalMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z124SalMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z125SalCueAux", StringUtil.RTrim( Z125SalCueAux));
         GxWebStd.gx_hidden_field( context, "Z1839SalVouDebe", StringUtil.LTrim( StringUtil.NToC( Z1839SalVouDebe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1841SalVouHaber", StringUtil.LTrim( StringUtil.NToC( Z1841SalVouHaber, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1838SalTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1838SalTipCmb, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1840SalVouDebeD", StringUtil.LTrim( StringUtil.NToC( Z1840SalVouDebeD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1842SalVouHaberD", StringUtil.LTrim( StringUtil.NToC( Z1842SalVouHaberD, 15, 2, ".", "")));
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
         setEventMetadata("VALID_SALVOUANO","{handler:'Valid_Salvouano',iparms:[]");
         setEventMetadata("VALID_SALVOUANO",",oparms:[]}");
         setEventMetadata("VALID_SALVOUMES","{handler:'Valid_Salvoumes',iparms:[]");
         setEventMetadata("VALID_SALVOUMES",",oparms:[]}");
         setEventMetadata("VALID_SALCUECOD","{handler:'Valid_Salcuecod',iparms:[{av:'A123SalCueCod',fld:'SALCUECOD',pic:''}]");
         setEventMetadata("VALID_SALCUECOD",",oparms:[]}");
         setEventMetadata("VALID_SALMONCOD","{handler:'Valid_Salmoncod',iparms:[]");
         setEventMetadata("VALID_SALMONCOD",",oparms:[]}");
         setEventMetadata("VALID_SALCUEAUX","{handler:'Valid_Salcueaux',iparms:[{av:'A121SalVouAno',fld:'SALVOUANO',pic:'ZZZ9'},{av:'A122SalVouMes',fld:'SALVOUMES',pic:'Z9'},{av:'A123SalCueCod',fld:'SALCUECOD',pic:''},{av:'A124SalMonCod',fld:'SALMONCOD',pic:'ZZZZZ9'},{av:'A125SalCueAux',fld:'SALCUEAUX',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SALCUEAUX",",oparms:[{av:'A1839SalVouDebe',fld:'SALVOUDEBE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1841SalVouHaber',fld:'SALVOUHABER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1838SalTipCmb',fld:'SALTIPCMB',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1840SalVouDebeD',fld:'SALVOUDEBED',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1842SalVouHaberD',fld:'SALVOUHABERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z121SalVouAno'},{av:'Z122SalVouMes'},{av:'Z123SalCueCod'},{av:'Z124SalMonCod'},{av:'Z125SalCueAux'},{av:'Z1839SalVouDebe'},{av:'Z1841SalVouHaber'},{av:'Z1838SalTipCmb'},{av:'Z1840SalVouDebeD'},{av:'Z1842SalVouHaberD'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z123SalCueCod = "";
         Z125SalCueAux = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A123SalCueCod = "";
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
         A125SalCueAux = "";
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
         T00205_A121SalVouAno = new short[1] ;
         T00205_A122SalVouMes = new short[1] ;
         T00205_A124SalMonCod = new int[1] ;
         T00205_A125SalCueAux = new string[] {""} ;
         T00205_A1839SalVouDebe = new decimal[1] ;
         T00205_A1841SalVouHaber = new decimal[1] ;
         T00205_A1838SalTipCmb = new decimal[1] ;
         T00205_A1840SalVouDebeD = new decimal[1] ;
         T00205_A1842SalVouHaberD = new decimal[1] ;
         T00205_A123SalCueCod = new string[] {""} ;
         T00204_A123SalCueCod = new string[] {""} ;
         T00206_A123SalCueCod = new string[] {""} ;
         T00207_A121SalVouAno = new short[1] ;
         T00207_A122SalVouMes = new short[1] ;
         T00207_A123SalCueCod = new string[] {""} ;
         T00207_A124SalMonCod = new int[1] ;
         T00207_A125SalCueAux = new string[] {""} ;
         T00203_A121SalVouAno = new short[1] ;
         T00203_A122SalVouMes = new short[1] ;
         T00203_A124SalMonCod = new int[1] ;
         T00203_A125SalCueAux = new string[] {""} ;
         T00203_A1839SalVouDebe = new decimal[1] ;
         T00203_A1841SalVouHaber = new decimal[1] ;
         T00203_A1838SalTipCmb = new decimal[1] ;
         T00203_A1840SalVouDebeD = new decimal[1] ;
         T00203_A1842SalVouHaberD = new decimal[1] ;
         T00203_A123SalCueCod = new string[] {""} ;
         sMode69 = "";
         T00208_A121SalVouAno = new short[1] ;
         T00208_A122SalVouMes = new short[1] ;
         T00208_A123SalCueCod = new string[] {""} ;
         T00208_A124SalMonCod = new int[1] ;
         T00208_A125SalCueAux = new string[] {""} ;
         T00209_A121SalVouAno = new short[1] ;
         T00209_A122SalVouMes = new short[1] ;
         T00209_A123SalCueCod = new string[] {""} ;
         T00209_A124SalMonCod = new int[1] ;
         T00209_A125SalCueAux = new string[] {""} ;
         T00202_A121SalVouAno = new short[1] ;
         T00202_A122SalVouMes = new short[1] ;
         T00202_A124SalMonCod = new int[1] ;
         T00202_A125SalCueAux = new string[] {""} ;
         T00202_A1839SalVouDebe = new decimal[1] ;
         T00202_A1841SalVouHaber = new decimal[1] ;
         T00202_A1838SalTipCmb = new decimal[1] ;
         T00202_A1840SalVouDebeD = new decimal[1] ;
         T00202_A1842SalVouHaberD = new decimal[1] ;
         T00202_A123SalCueCod = new string[] {""} ;
         T002013_A121SalVouAno = new short[1] ;
         T002013_A122SalVouMes = new short[1] ;
         T002013_A123SalCueCod = new string[] {""} ;
         T002013_A124SalMonCod = new int[1] ;
         T002013_A125SalCueAux = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002014_A123SalCueCod = new string[] {""} ;
         ZZ123SalCueCod = "";
         ZZ125SalCueAux = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbsaldomensual__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbsaldomensual__default(),
            new Object[][] {
                new Object[] {
               T00202_A121SalVouAno, T00202_A122SalVouMes, T00202_A124SalMonCod, T00202_A125SalCueAux, T00202_A1839SalVouDebe, T00202_A1841SalVouHaber, T00202_A1838SalTipCmb, T00202_A1840SalVouDebeD, T00202_A1842SalVouHaberD, T00202_A123SalCueCod
               }
               , new Object[] {
               T00203_A121SalVouAno, T00203_A122SalVouMes, T00203_A124SalMonCod, T00203_A125SalCueAux, T00203_A1839SalVouDebe, T00203_A1841SalVouHaber, T00203_A1838SalTipCmb, T00203_A1840SalVouDebeD, T00203_A1842SalVouHaberD, T00203_A123SalCueCod
               }
               , new Object[] {
               T00204_A123SalCueCod
               }
               , new Object[] {
               T00205_A121SalVouAno, T00205_A122SalVouMes, T00205_A124SalMonCod, T00205_A125SalCueAux, T00205_A1839SalVouDebe, T00205_A1841SalVouHaber, T00205_A1838SalTipCmb, T00205_A1840SalVouDebeD, T00205_A1842SalVouHaberD, T00205_A123SalCueCod
               }
               , new Object[] {
               T00206_A123SalCueCod
               }
               , new Object[] {
               T00207_A121SalVouAno, T00207_A122SalVouMes, T00207_A123SalCueCod, T00207_A124SalMonCod, T00207_A125SalCueAux
               }
               , new Object[] {
               T00208_A121SalVouAno, T00208_A122SalVouMes, T00208_A123SalCueCod, T00208_A124SalMonCod, T00208_A125SalCueAux
               }
               , new Object[] {
               T00209_A121SalVouAno, T00209_A122SalVouMes, T00209_A123SalCueCod, T00209_A124SalMonCod, T00209_A125SalCueAux
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002013_A121SalVouAno, T002013_A122SalVouMes, T002013_A123SalCueCod, T002013_A124SalMonCod, T002013_A125SalCueAux
               }
               , new Object[] {
               T002014_A123SalCueCod
               }
            }
         );
      }

      private short Z121SalVouAno ;
      private short Z122SalVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A121SalVouAno ;
      private short A122SalVouMes ;
      private short GX_JID ;
      private short RcdFound69 ;
      private short nIsDirty_69 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ121SalVouAno ;
      private short ZZ122SalVouMes ;
      private int Z124SalMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtSalVouAno_Enabled ;
      private int edtSalVouMes_Enabled ;
      private int edtSalCueCod_Enabled ;
      private int A124SalMonCod ;
      private int edtSalMonCod_Enabled ;
      private int edtSalCueAux_Enabled ;
      private int edtSalVouDebe_Enabled ;
      private int edtSalVouHaber_Enabled ;
      private int edtSalTipCmb_Enabled ;
      private int edtSalVouDebeD_Enabled ;
      private int edtSalVouHaberD_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ124SalMonCod ;
      private decimal Z1839SalVouDebe ;
      private decimal Z1841SalVouHaber ;
      private decimal Z1838SalTipCmb ;
      private decimal Z1840SalVouDebeD ;
      private decimal Z1842SalVouHaberD ;
      private decimal A1839SalVouDebe ;
      private decimal A1841SalVouHaber ;
      private decimal A1838SalTipCmb ;
      private decimal A1840SalVouDebeD ;
      private decimal A1842SalVouHaberD ;
      private decimal ZZ1839SalVouDebe ;
      private decimal ZZ1841SalVouHaber ;
      private decimal ZZ1838SalTipCmb ;
      private decimal ZZ1840SalVouDebeD ;
      private decimal ZZ1842SalVouHaberD ;
      private string sPrefix ;
      private string Z123SalCueCod ;
      private string Z125SalCueAux ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A123SalCueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSalVouAno_Internalname ;
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
      private string edtSalVouAno_Jsonclick ;
      private string edtSalVouMes_Internalname ;
      private string edtSalVouMes_Jsonclick ;
      private string edtSalCueCod_Internalname ;
      private string edtSalCueCod_Jsonclick ;
      private string edtSalMonCod_Internalname ;
      private string edtSalMonCod_Jsonclick ;
      private string edtSalCueAux_Internalname ;
      private string A125SalCueAux ;
      private string edtSalCueAux_Jsonclick ;
      private string edtSalVouDebe_Internalname ;
      private string edtSalVouDebe_Jsonclick ;
      private string edtSalVouHaber_Internalname ;
      private string edtSalVouHaber_Jsonclick ;
      private string edtSalTipCmb_Internalname ;
      private string edtSalTipCmb_Jsonclick ;
      private string edtSalVouDebeD_Internalname ;
      private string edtSalVouDebeD_Jsonclick ;
      private string edtSalVouHaberD_Internalname ;
      private string edtSalVouHaberD_Jsonclick ;
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
      private string sMode69 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ123SalCueCod ;
      private string ZZ125SalCueAux ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00205_A121SalVouAno ;
      private short[] T00205_A122SalVouMes ;
      private int[] T00205_A124SalMonCod ;
      private string[] T00205_A125SalCueAux ;
      private decimal[] T00205_A1839SalVouDebe ;
      private decimal[] T00205_A1841SalVouHaber ;
      private decimal[] T00205_A1838SalTipCmb ;
      private decimal[] T00205_A1840SalVouDebeD ;
      private decimal[] T00205_A1842SalVouHaberD ;
      private string[] T00205_A123SalCueCod ;
      private string[] T00204_A123SalCueCod ;
      private string[] T00206_A123SalCueCod ;
      private short[] T00207_A121SalVouAno ;
      private short[] T00207_A122SalVouMes ;
      private string[] T00207_A123SalCueCod ;
      private int[] T00207_A124SalMonCod ;
      private string[] T00207_A125SalCueAux ;
      private short[] T00203_A121SalVouAno ;
      private short[] T00203_A122SalVouMes ;
      private int[] T00203_A124SalMonCod ;
      private string[] T00203_A125SalCueAux ;
      private decimal[] T00203_A1839SalVouDebe ;
      private decimal[] T00203_A1841SalVouHaber ;
      private decimal[] T00203_A1838SalTipCmb ;
      private decimal[] T00203_A1840SalVouDebeD ;
      private decimal[] T00203_A1842SalVouHaberD ;
      private string[] T00203_A123SalCueCod ;
      private short[] T00208_A121SalVouAno ;
      private short[] T00208_A122SalVouMes ;
      private string[] T00208_A123SalCueCod ;
      private int[] T00208_A124SalMonCod ;
      private string[] T00208_A125SalCueAux ;
      private short[] T00209_A121SalVouAno ;
      private short[] T00209_A122SalVouMes ;
      private string[] T00209_A123SalCueCod ;
      private int[] T00209_A124SalMonCod ;
      private string[] T00209_A125SalCueAux ;
      private short[] T00202_A121SalVouAno ;
      private short[] T00202_A122SalVouMes ;
      private int[] T00202_A124SalMonCod ;
      private string[] T00202_A125SalCueAux ;
      private decimal[] T00202_A1839SalVouDebe ;
      private decimal[] T00202_A1841SalVouHaber ;
      private decimal[] T00202_A1838SalTipCmb ;
      private decimal[] T00202_A1840SalVouDebeD ;
      private decimal[] T00202_A1842SalVouHaberD ;
      private string[] T00202_A123SalCueCod ;
      private short[] T002013_A121SalVouAno ;
      private short[] T002013_A122SalVouMes ;
      private string[] T002013_A123SalCueCod ;
      private int[] T002013_A124SalMonCod ;
      private string[] T002013_A125SalCueAux ;
      private string[] T002014_A123SalCueCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbsaldomensual__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbsaldomensual__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00205;
        prmT00205 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT00204;
        prmT00204 = new Object[] {
        new ParDef("@SalCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00206;
        prmT00206 = new Object[] {
        new ParDef("@SalCueCod",GXType.NChar,15,0)
        };
        Object[] prmT00207;
        prmT00207 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT00203;
        prmT00203 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT00208;
        prmT00208 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT00209;
        prmT00209 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT00202;
        prmT00202 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT002010;
        prmT002010 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0) ,
        new ParDef("@SalVouDebe",GXType.Decimal,15,2) ,
        new ParDef("@SalVouHaber",GXType.Decimal,15,2) ,
        new ParDef("@SalTipCmb",GXType.Decimal,15,4) ,
        new ParDef("@SalVouDebeD",GXType.Decimal,15,2) ,
        new ParDef("@SalVouHaberD",GXType.Decimal,15,2) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0)
        };
        Object[] prmT002011;
        prmT002011 = new Object[] {
        new ParDef("@SalVouDebe",GXType.Decimal,15,2) ,
        new ParDef("@SalVouHaber",GXType.Decimal,15,2) ,
        new ParDef("@SalTipCmb",GXType.Decimal,15,4) ,
        new ParDef("@SalVouDebeD",GXType.Decimal,15,2) ,
        new ParDef("@SalVouHaberD",GXType.Decimal,15,2) ,
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT002012;
        prmT002012 = new Object[] {
        new ParDef("@SalVouAno",GXType.Int16,4,0) ,
        new ParDef("@SalVouMes",GXType.Int16,2,0) ,
        new ParDef("@SalCueCod",GXType.NChar,15,0) ,
        new ParDef("@SalMonCod",GXType.Int32,6,0) ,
        new ParDef("@SalCueAux",GXType.NChar,20,0)
        };
        Object[] prmT002013;
        prmT002013 = new Object[] {
        };
        Object[] prmT002014;
        prmT002014 = new Object[] {
        new ParDef("@SalCueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00202", "SELECT [SalVouAno], [SalVouMes], [SalMonCod], [SalCueAux], [SalVouDebe], [SalVouHaber], [SalTipCmb], [SalVouDebeD], [SalVouHaberD], [SalCueCod] AS SalCueCod FROM [CBSALDOMENSUAL] WITH (UPDLOCK) WHERE [SalVouAno] = @SalVouAno AND [SalVouMes] = @SalVouMes AND [SalCueCod] = @SalCueCod AND [SalMonCod] = @SalMonCod AND [SalCueAux] = @SalCueAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT00202,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00203", "SELECT [SalVouAno], [SalVouMes], [SalMonCod], [SalCueAux], [SalVouDebe], [SalVouHaber], [SalTipCmb], [SalVouDebeD], [SalVouHaberD], [SalCueCod] AS SalCueCod FROM [CBSALDOMENSUAL] WHERE [SalVouAno] = @SalVouAno AND [SalVouMes] = @SalVouMes AND [SalCueCod] = @SalCueCod AND [SalMonCod] = @SalMonCod AND [SalCueAux] = @SalCueAux ",true, GxErrorMask.GX_NOMASK, false, this,prmT00203,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00204", "SELECT [CueCod] AS SalCueCod FROM [CBPLANCUENTA] WHERE [CueCod] = @SalCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00204,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00205", "SELECT TM1.[SalVouAno], TM1.[SalVouMes], TM1.[SalMonCod], TM1.[SalCueAux], TM1.[SalVouDebe], TM1.[SalVouHaber], TM1.[SalTipCmb], TM1.[SalVouDebeD], TM1.[SalVouHaberD], TM1.[SalCueCod] AS SalCueCod FROM [CBSALDOMENSUAL] TM1 WHERE TM1.[SalVouAno] = @SalVouAno and TM1.[SalVouMes] = @SalVouMes and TM1.[SalCueCod] = @SalCueCod and TM1.[SalMonCod] = @SalMonCod and TM1.[SalCueAux] = @SalCueAux ORDER BY TM1.[SalVouAno], TM1.[SalVouMes], TM1.[SalCueCod], TM1.[SalMonCod], TM1.[SalCueAux]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00205,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00206", "SELECT [CueCod] AS SalCueCod FROM [CBPLANCUENTA] WHERE [CueCod] = @SalCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00206,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00207", "SELECT [SalVouAno], [SalVouMes], [SalCueCod] AS SalCueCod, [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE [SalVouAno] = @SalVouAno AND [SalVouMes] = @SalVouMes AND [SalCueCod] = @SalCueCod AND [SalMonCod] = @SalMonCod AND [SalCueAux] = @SalCueAux  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00207,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00208", "SELECT TOP 1 [SalVouAno], [SalVouMes], [SalCueCod] AS SalCueCod, [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE ( [SalVouAno] > @SalVouAno or [SalVouAno] = @SalVouAno and [SalVouMes] > @SalVouMes or [SalVouMes] = @SalVouMes and [SalVouAno] = @SalVouAno and [SalCueCod] > @SalCueCod or [SalCueCod] = @SalCueCod and [SalVouMes] = @SalVouMes and [SalVouAno] = @SalVouAno and [SalMonCod] > @SalMonCod or [SalMonCod] = @SalMonCod and [SalCueCod] = @SalCueCod and [SalVouMes] = @SalVouMes and [SalVouAno] = @SalVouAno and [SalCueAux] > @SalCueAux) ORDER BY [SalVouAno], [SalVouMes], [SalCueCod], [SalMonCod], [SalCueAux]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00208,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00209", "SELECT TOP 1 [SalVouAno], [SalVouMes], [SalCueCod] AS SalCueCod, [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] WHERE ( [SalVouAno] < @SalVouAno or [SalVouAno] = @SalVouAno and [SalVouMes] < @SalVouMes or [SalVouMes] = @SalVouMes and [SalVouAno] = @SalVouAno and [SalCueCod] < @SalCueCod or [SalCueCod] = @SalCueCod and [SalVouMes] = @SalVouMes and [SalVouAno] = @SalVouAno and [SalMonCod] < @SalMonCod or [SalMonCod] = @SalMonCod and [SalCueCod] = @SalCueCod and [SalVouMes] = @SalVouMes and [SalVouAno] = @SalVouAno and [SalCueAux] < @SalCueAux) ORDER BY [SalVouAno] DESC, [SalVouMes] DESC, [SalCueCod] DESC, [SalMonCod] DESC, [SalCueAux] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00209,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002010", "INSERT INTO [CBSALDOMENSUAL]([SalVouAno], [SalVouMes], [SalMonCod], [SalCueAux], [SalVouDebe], [SalVouHaber], [SalTipCmb], [SalVouDebeD], [SalVouHaberD], [SalCueCod]) VALUES(@SalVouAno, @SalVouMes, @SalMonCod, @SalCueAux, @SalVouDebe, @SalVouHaber, @SalTipCmb, @SalVouDebeD, @SalVouHaberD, @SalCueCod)", GxErrorMask.GX_NOMASK,prmT002010)
           ,new CursorDef("T002011", "UPDATE [CBSALDOMENSUAL] SET [SalVouDebe]=@SalVouDebe, [SalVouHaber]=@SalVouHaber, [SalTipCmb]=@SalTipCmb, [SalVouDebeD]=@SalVouDebeD, [SalVouHaberD]=@SalVouHaberD  WHERE [SalVouAno] = @SalVouAno AND [SalVouMes] = @SalVouMes AND [SalCueCod] = @SalCueCod AND [SalMonCod] = @SalMonCod AND [SalCueAux] = @SalCueAux", GxErrorMask.GX_NOMASK,prmT002011)
           ,new CursorDef("T002012", "DELETE FROM [CBSALDOMENSUAL]  WHERE [SalVouAno] = @SalVouAno AND [SalVouMes] = @SalVouMes AND [SalCueCod] = @SalCueCod AND [SalMonCod] = @SalMonCod AND [SalCueAux] = @SalCueAux", GxErrorMask.GX_NOMASK,prmT002012)
           ,new CursorDef("T002013", "SELECT [SalVouAno], [SalVouMes], [SalCueCod] AS SalCueCod, [SalMonCod], [SalCueAux] FROM [CBSALDOMENSUAL] ORDER BY [SalVouAno], [SalVouMes], [SalCueCod], [SalMonCod], [SalCueAux]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002013,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002014", "SELECT [CueCod] AS SalCueCod FROM [CBPLANCUENTA] WHERE [CueCod] = @SalCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002014,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
