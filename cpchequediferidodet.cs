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
   public class cpchequediferidodet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A238CheqDCod = GetPar( "CheqDCod");
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A238CheqDCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A242CheqDTipCod = GetPar( "CheqDTipCod");
            AssignAttri("", false, "A242CheqDTipCod", A242CheqDTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A242CheqDTipCod) ;
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
            Form.Meta.addItem("description", "ChequeDiferido Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpchequediferidodet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpchequediferidodet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "ChequeDiferido Detalle", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CPCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDCod_Internalname, "Nº Canje Cheque", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDCod_Internalname, StringUtil.RTrim( A238CheqDCod), StringUtil.RTrim( context.localUtil.Format( A238CheqDCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A241CheqDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtCheqDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A241CheqDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A241CheqDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDTipo_Internalname, "C", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDTipo_Internalname, StringUtil.RTrim( A535CheqDTipo), StringUtil.RTrim( context.localUtil.Format( A535CheqDTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDTipCod_Internalname, "D", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDTipCod_Internalname, StringUtil.RTrim( A242CheqDTipCod), StringUtil.RTrim( context.localUtil.Format( A242CheqDTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDDocNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDDocNum_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDDocNum_Internalname, StringUtil.RTrim( A523CheqDDocNum), StringUtil.RTrim( context.localUtil.Format( A523CheqDDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDDocNum_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDDias_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDDias_Internalname, "Dias", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A522CheqDDias), 6, 0, ".", "")), StringUtil.LTrim( ((edtCheqDDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A522CheqDDias), "ZZZZZ9") : context.localUtil.Format( (decimal)(A522CheqDDias), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDDias_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDFecD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDFecD_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCheqDFecD_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCheqDFecD_Internalname, context.localUtil.Format(A525CheqDFecD, "99/99/99"), context.localUtil.Format( A525CheqDFecD, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDFecD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDFecD_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_bitmap( context, edtCheqDFecD_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCheqDFecD_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDFecV_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDFecV_Internalname, "Vcto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCheqDFecV_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCheqDFecV_Internalname, context.localUtil.Format(A526CheqDFecV, "99/99/99"), context.localUtil.Format( A526CheqDFecV, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDFecV_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDFecV_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_bitmap( context, edtCheqDFecV_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCheqDFecV_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDimpD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDimpD_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDimpD_Internalname, StringUtil.LTrim( StringUtil.NToC( A528CheqDimpD, 17, 2, ".", "")), StringUtil.LTrim( ((edtCheqDimpD_Enabled!=0) ? context.localUtil.Format( A528CheqDimpD, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A528CheqDimpD, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDimpD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDimpD_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCheqDPagCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCheqDPagCod_Internalname, "Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCheqDPagCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A530CheqDPagCod), 10, 0, ".", "")), StringUtil.LTrim( ((edtCheqDPagCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A530CheqDPagCod), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A530CheqDPagCod), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCheqDPagCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCheqDPagCod_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 80,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCHEQUEDIFERIDODET.htm");
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
            Z238CheqDCod = cgiGet( "Z238CheqDCod");
            Z241CheqDItem = (int)(context.localUtil.CToN( cgiGet( "Z241CheqDItem"), ".", ","));
            Z535CheqDTipo = cgiGet( "Z535CheqDTipo");
            Z523CheqDDocNum = cgiGet( "Z523CheqDDocNum");
            Z522CheqDDias = (int)(context.localUtil.CToN( cgiGet( "Z522CheqDDias"), ".", ","));
            Z525CheqDFecD = context.localUtil.CToD( cgiGet( "Z525CheqDFecD"), 0);
            Z526CheqDFecV = context.localUtil.CToD( cgiGet( "Z526CheqDFecV"), 0);
            Z528CheqDimpD = context.localUtil.CToN( cgiGet( "Z528CheqDimpD"), ".", ",");
            Z530CheqDPagCod = (long)(context.localUtil.CToN( cgiGet( "Z530CheqDPagCod"), ".", ","));
            Z242CheqDTipCod = cgiGet( "Z242CheqDTipCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A238CheqDCod = cgiGet( edtCheqDCod_Internalname);
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDITEM");
               AnyError = 1;
               GX_FocusControl = edtCheqDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A241CheqDItem = 0;
               AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
            }
            else
            {
               A241CheqDItem = (int)(context.localUtil.CToN( cgiGet( edtCheqDItem_Internalname), ".", ","));
               AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
            }
            A535CheqDTipo = cgiGet( edtCheqDTipo_Internalname);
            AssignAttri("", false, "A535CheqDTipo", A535CheqDTipo);
            A242CheqDTipCod = cgiGet( edtCheqDTipCod_Internalname);
            AssignAttri("", false, "A242CheqDTipCod", A242CheqDTipCod);
            A523CheqDDocNum = cgiGet( edtCheqDDocNum_Internalname);
            AssignAttri("", false, "A523CheqDDocNum", A523CheqDDocNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDDias_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDDias_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDDIAS");
               AnyError = 1;
               GX_FocusControl = edtCheqDDias_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A522CheqDDias = 0;
               AssignAttri("", false, "A522CheqDDias", StringUtil.LTrimStr( (decimal)(A522CheqDDias), 6, 0));
            }
            else
            {
               A522CheqDDias = (int)(context.localUtil.CToN( cgiGet( edtCheqDDias_Internalname), ".", ","));
               AssignAttri("", false, "A522CheqDDias", StringUtil.LTrimStr( (decimal)(A522CheqDDias), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtCheqDFecD_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "CHEQDFECD");
               AnyError = 1;
               GX_FocusControl = edtCheqDFecD_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A525CheqDFecD = DateTime.MinValue;
               AssignAttri("", false, "A525CheqDFecD", context.localUtil.Format(A525CheqDFecD, "99/99/99"));
            }
            else
            {
               A525CheqDFecD = context.localUtil.CToD( cgiGet( edtCheqDFecD_Internalname), 2);
               AssignAttri("", false, "A525CheqDFecD", context.localUtil.Format(A525CheqDFecD, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtCheqDFecV_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "CHEQDFECV");
               AnyError = 1;
               GX_FocusControl = edtCheqDFecV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A526CheqDFecV = DateTime.MinValue;
               AssignAttri("", false, "A526CheqDFecV", context.localUtil.Format(A526CheqDFecV, "99/99/99"));
            }
            else
            {
               A526CheqDFecV = context.localUtil.CToD( cgiGet( edtCheqDFecV_Internalname), 2);
               AssignAttri("", false, "A526CheqDFecV", context.localUtil.Format(A526CheqDFecV, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDimpD_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDimpD_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDIMPD");
               AnyError = 1;
               GX_FocusControl = edtCheqDimpD_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A528CheqDimpD = 0;
               AssignAttri("", false, "A528CheqDimpD", StringUtil.LTrimStr( A528CheqDimpD, 15, 2));
            }
            else
            {
               A528CheqDimpD = context.localUtil.CToN( cgiGet( edtCheqDimpD_Internalname), ".", ",");
               AssignAttri("", false, "A528CheqDimpD", StringUtil.LTrimStr( A528CheqDimpD, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCheqDPagCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCheqDPagCod_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHEQDPAGCOD");
               AnyError = 1;
               GX_FocusControl = edtCheqDPagCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A530CheqDPagCod = 0;
               AssignAttri("", false, "A530CheqDPagCod", StringUtil.LTrimStr( (decimal)(A530CheqDPagCod), 10, 0));
            }
            else
            {
               A530CheqDPagCod = (long)(context.localUtil.CToN( cgiGet( edtCheqDPagCod_Internalname), ".", ","));
               AssignAttri("", false, "A530CheqDPagCod", StringUtil.LTrimStr( (decimal)(A530CheqDPagCod), 10, 0));
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
               A238CheqDCod = GetPar( "CheqDCod");
               AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
               A241CheqDItem = (int)(NumberUtil.Val( GetPar( "CheqDItem"), "."));
               AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
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
               InitAll0E15( ) ;
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
         DisableAttributes0E15( ) ;
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

      protected void ResetCaption0E0( )
      {
      }

      protected void ZM0E15( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z535CheqDTipo = T000E3_A535CheqDTipo[0];
               Z523CheqDDocNum = T000E3_A523CheqDDocNum[0];
               Z522CheqDDias = T000E3_A522CheqDDias[0];
               Z525CheqDFecD = T000E3_A525CheqDFecD[0];
               Z526CheqDFecV = T000E3_A526CheqDFecV[0];
               Z528CheqDimpD = T000E3_A528CheqDimpD[0];
               Z530CheqDPagCod = T000E3_A530CheqDPagCod[0];
               Z242CheqDTipCod = T000E3_A242CheqDTipCod[0];
            }
            else
            {
               Z535CheqDTipo = A535CheqDTipo;
               Z523CheqDDocNum = A523CheqDDocNum;
               Z522CheqDDias = A522CheqDDias;
               Z525CheqDFecD = A525CheqDFecD;
               Z526CheqDFecV = A526CheqDFecV;
               Z528CheqDimpD = A528CheqDimpD;
               Z530CheqDPagCod = A530CheqDPagCod;
               Z242CheqDTipCod = A242CheqDTipCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z241CheqDItem = A241CheqDItem;
            Z535CheqDTipo = A535CheqDTipo;
            Z523CheqDDocNum = A523CheqDDocNum;
            Z522CheqDDias = A522CheqDDias;
            Z525CheqDFecD = A525CheqDFecD;
            Z526CheqDFecV = A526CheqDFecV;
            Z528CheqDimpD = A528CheqDimpD;
            Z530CheqDPagCod = A530CheqDPagCod;
            Z238CheqDCod = A238CheqDCod;
            Z242CheqDTipCod = A242CheqDTipCod;
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

      protected void Load0E15( )
      {
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {A238CheqDCod, A241CheqDItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound15 = 1;
            A535CheqDTipo = T000E6_A535CheqDTipo[0];
            AssignAttri("", false, "A535CheqDTipo", A535CheqDTipo);
            A523CheqDDocNum = T000E6_A523CheqDDocNum[0];
            AssignAttri("", false, "A523CheqDDocNum", A523CheqDDocNum);
            A522CheqDDias = T000E6_A522CheqDDias[0];
            AssignAttri("", false, "A522CheqDDias", StringUtil.LTrimStr( (decimal)(A522CheqDDias), 6, 0));
            A525CheqDFecD = T000E6_A525CheqDFecD[0];
            AssignAttri("", false, "A525CheqDFecD", context.localUtil.Format(A525CheqDFecD, "99/99/99"));
            A526CheqDFecV = T000E6_A526CheqDFecV[0];
            AssignAttri("", false, "A526CheqDFecV", context.localUtil.Format(A526CheqDFecV, "99/99/99"));
            A528CheqDimpD = T000E6_A528CheqDimpD[0];
            AssignAttri("", false, "A528CheqDimpD", StringUtil.LTrimStr( A528CheqDimpD, 15, 2));
            A530CheqDPagCod = T000E6_A530CheqDPagCod[0];
            AssignAttri("", false, "A530CheqDPagCod", StringUtil.LTrimStr( (decimal)(A530CheqDPagCod), 10, 0));
            A242CheqDTipCod = T000E6_A242CheqDTipCod[0];
            AssignAttri("", false, "A242CheqDTipCod", A242CheqDTipCod);
            ZM0E15( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0E15( ) ;
      }

      protected void OnLoadActions0E15( )
      {
      }

      protected void CheckExtendedTable0E15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'CPCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {A242CheqDTipCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documento'.", "ForeignKeyNotFound", 1, "CHEQDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A525CheqDFecD) || ( DateTimeUtil.ResetTime ( A525CheqDFecD ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CHEQDFECD");
            AnyError = 1;
            GX_FocusControl = edtCheqDFecD_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A526CheqDFecV) || ( DateTimeUtil.ResetTime ( A526CheqDFecV ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "CHEQDFECV");
            AnyError = 1;
            GX_FocusControl = edtCheqDFecV_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0E15( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A238CheqDCod )
      {
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'CPCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_5( string A242CheqDTipCod )
      {
         /* Using cursor T000E8 */
         pr_default.execute(6, new Object[] {A242CheqDTipCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documento'.", "ForeignKeyNotFound", 1, "CHEQDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0E15( )
      {
         /* Using cursor T000E9 */
         pr_default.execute(7, new Object[] {A238CheqDCod, A241CheqDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A238CheqDCod, A241CheqDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E15( 3) ;
            RcdFound15 = 1;
            A241CheqDItem = T000E3_A241CheqDItem[0];
            AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
            A535CheqDTipo = T000E3_A535CheqDTipo[0];
            AssignAttri("", false, "A535CheqDTipo", A535CheqDTipo);
            A523CheqDDocNum = T000E3_A523CheqDDocNum[0];
            AssignAttri("", false, "A523CheqDDocNum", A523CheqDDocNum);
            A522CheqDDias = T000E3_A522CheqDDias[0];
            AssignAttri("", false, "A522CheqDDias", StringUtil.LTrimStr( (decimal)(A522CheqDDias), 6, 0));
            A525CheqDFecD = T000E3_A525CheqDFecD[0];
            AssignAttri("", false, "A525CheqDFecD", context.localUtil.Format(A525CheqDFecD, "99/99/99"));
            A526CheqDFecV = T000E3_A526CheqDFecV[0];
            AssignAttri("", false, "A526CheqDFecV", context.localUtil.Format(A526CheqDFecV, "99/99/99"));
            A528CheqDimpD = T000E3_A528CheqDimpD[0];
            AssignAttri("", false, "A528CheqDimpD", StringUtil.LTrimStr( A528CheqDimpD, 15, 2));
            A530CheqDPagCod = T000E3_A530CheqDPagCod[0];
            AssignAttri("", false, "A530CheqDPagCod", StringUtil.LTrimStr( (decimal)(A530CheqDPagCod), 10, 0));
            A238CheqDCod = T000E3_A238CheqDCod[0];
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            A242CheqDTipCod = T000E3_A242CheqDTipCod[0];
            AssignAttri("", false, "A242CheqDTipCod", A242CheqDTipCod);
            Z238CheqDCod = A238CheqDCod;
            Z241CheqDItem = A241CheqDItem;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0E15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0E15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0E15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E15( ) ;
         if ( RcdFound15 == 0 )
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
         RcdFound15 = 0;
         /* Using cursor T000E10 */
         pr_default.execute(8, new Object[] {A238CheqDCod, A241CheqDItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000E10_A238CheqDCod[0], A238CheqDCod) < 0 ) || ( StringUtil.StrCmp(T000E10_A238CheqDCod[0], A238CheqDCod) == 0 ) && ( T000E10_A241CheqDItem[0] < A241CheqDItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000E10_A238CheqDCod[0], A238CheqDCod) > 0 ) || ( StringUtil.StrCmp(T000E10_A238CheqDCod[0], A238CheqDCod) == 0 ) && ( T000E10_A241CheqDItem[0] > A241CheqDItem ) ) )
            {
               A238CheqDCod = T000E10_A238CheqDCod[0];
               AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
               A241CheqDItem = T000E10_A241CheqDItem[0];
               AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000E11 */
         pr_default.execute(9, new Object[] {A238CheqDCod, A241CheqDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000E11_A238CheqDCod[0], A238CheqDCod) > 0 ) || ( StringUtil.StrCmp(T000E11_A238CheqDCod[0], A238CheqDCod) == 0 ) && ( T000E11_A241CheqDItem[0] > A241CheqDItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000E11_A238CheqDCod[0], A238CheqDCod) < 0 ) || ( StringUtil.StrCmp(T000E11_A238CheqDCod[0], A238CheqDCod) == 0 ) && ( T000E11_A241CheqDItem[0] < A241CheqDItem ) ) )
            {
               A238CheqDCod = T000E11_A238CheqDCod[0];
               AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
               A241CheqDItem = T000E11_A241CheqDItem[0];
               AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( ( StringUtil.StrCmp(A238CheqDCod, Z238CheqDCod) != 0 ) || ( A241CheqDItem != Z241CheqDItem ) )
               {
                  A238CheqDCod = Z238CheqDCod;
                  AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
                  A241CheqDItem = Z241CheqDItem;
                  AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CHEQDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0E15( ) ;
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A238CheqDCod, Z238CheqDCod) != 0 ) || ( A241CheqDItem != Z241CheqDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CHEQDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E15( ) ;
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
         if ( ( StringUtil.StrCmp(A238CheqDCod, Z238CheqDCod) != 0 ) || ( A241CheqDItem != Z241CheqDItem ) )
         {
            A238CheqDCod = Z238CheqDCod;
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            A241CheqDItem = Z241CheqDItem;
            AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCheqDCod_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCheqDTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E15( ) ;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDTipo_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDTipo_Internalname;
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
         ScanStart0E15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound15 != 0 )
            {
               ScanNext0E15( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCheqDTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E15( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0E15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A238CheqDCod, A241CheqDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCHEQUEDIFERIDODET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z535CheqDTipo, T000E2_A535CheqDTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z523CheqDDocNum, T000E2_A523CheqDDocNum[0]) != 0 ) || ( Z522CheqDDias != T000E2_A522CheqDDias[0] ) || ( DateTimeUtil.ResetTime ( Z525CheqDFecD ) != DateTimeUtil.ResetTime ( T000E2_A525CheqDFecD[0] ) ) || ( DateTimeUtil.ResetTime ( Z526CheqDFecV ) != DateTimeUtil.ResetTime ( T000E2_A526CheqDFecV[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z528CheqDimpD != T000E2_A528CheqDimpD[0] ) || ( Z530CheqDPagCod != T000E2_A530CheqDPagCod[0] ) || ( StringUtil.StrCmp(Z242CheqDTipCod, T000E2_A242CheqDTipCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z535CheqDTipo, T000E2_A535CheqDTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDTipo");
                  GXUtil.WriteLogRaw("Old: ",Z535CheqDTipo);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A535CheqDTipo[0]);
               }
               if ( StringUtil.StrCmp(Z523CheqDDocNum, T000E2_A523CheqDDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z523CheqDDocNum);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A523CheqDDocNum[0]);
               }
               if ( Z522CheqDDias != T000E2_A522CheqDDias[0] )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDDias");
                  GXUtil.WriteLogRaw("Old: ",Z522CheqDDias);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A522CheqDDias[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z525CheqDFecD ) != DateTimeUtil.ResetTime ( T000E2_A525CheqDFecD[0] ) )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDFecD");
                  GXUtil.WriteLogRaw("Old: ",Z525CheqDFecD);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A525CheqDFecD[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z526CheqDFecV ) != DateTimeUtil.ResetTime ( T000E2_A526CheqDFecV[0] ) )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDFecV");
                  GXUtil.WriteLogRaw("Old: ",Z526CheqDFecV);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A526CheqDFecV[0]);
               }
               if ( Z528CheqDimpD != T000E2_A528CheqDimpD[0] )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDimpD");
                  GXUtil.WriteLogRaw("Old: ",Z528CheqDimpD);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A528CheqDimpD[0]);
               }
               if ( Z530CheqDPagCod != T000E2_A530CheqDPagCod[0] )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDPagCod");
                  GXUtil.WriteLogRaw("Old: ",Z530CheqDPagCod);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A530CheqDPagCod[0]);
               }
               if ( StringUtil.StrCmp(Z242CheqDTipCod, T000E2_A242CheqDTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpchequediferidodet:[seudo value changed for attri]"+"CheqDTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z242CheqDTipCod);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A242CheqDTipCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPCHEQUEDIFERIDODET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E15( 0) ;
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E12 */
                     pr_default.execute(10, new Object[] {A241CheqDItem, A535CheqDTipo, A523CheqDDocNum, A522CheqDDias, A525CheqDFecD, A526CheqDFecV, A528CheqDimpD, A530CheqDPagCod, A238CheqDCod, A242CheqDTipCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCHEQUEDIFERIDODET");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption0E0( ) ;
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
               Load0E15( ) ;
            }
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void Update0E15( )
      {
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E13 */
                     pr_default.execute(11, new Object[] {A535CheqDTipo, A523CheqDDocNum, A522CheqDDias, A525CheqDFecD, A526CheqDFecV, A528CheqDimpD, A530CheqDPagCod, A242CheqDTipCod, A238CheqDCod, A241CheqDItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCHEQUEDIFERIDODET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCHEQUEDIFERIDODET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0E0( ) ;
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
            EndLevel0E15( ) ;
         }
         CloseExtendedTableCursors0E15( ) ;
      }

      protected void DeferredUpdate0E15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0E15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E15( ) ;
            AfterConfirm0E15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E15( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E14 */
                  pr_default.execute(12, new Object[] {A238CheqDCod, A241CheqDItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPCHEQUEDIFERIDODET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound15 == 0 )
                        {
                           InitAll0E15( ) ;
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
                        ResetCaption0E0( ) ;
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E15( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0E15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E15( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpchequediferidodet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpchequediferidodet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E15( )
      {
         /* Using cursor T000E15 */
         pr_default.execute(13);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound15 = 1;
            A238CheqDCod = T000E15_A238CheqDCod[0];
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            A241CheqDItem = T000E15_A241CheqDItem[0];
            AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E15( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound15 = 1;
            A238CheqDCod = T000E15_A238CheqDCod[0];
            AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
            A241CheqDItem = T000E15_A241CheqDItem[0];
            AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
         }
      }

      protected void ScanEnd0E15( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0E15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E15( )
      {
         edtCheqDCod_Enabled = 0;
         AssignProp("", false, edtCheqDCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDCod_Enabled), 5, 0), true);
         edtCheqDItem_Enabled = 0;
         AssignProp("", false, edtCheqDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDItem_Enabled), 5, 0), true);
         edtCheqDTipo_Enabled = 0;
         AssignProp("", false, edtCheqDTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDTipo_Enabled), 5, 0), true);
         edtCheqDTipCod_Enabled = 0;
         AssignProp("", false, edtCheqDTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDTipCod_Enabled), 5, 0), true);
         edtCheqDDocNum_Enabled = 0;
         AssignProp("", false, edtCheqDDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDDocNum_Enabled), 5, 0), true);
         edtCheqDDias_Enabled = 0;
         AssignProp("", false, edtCheqDDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDDias_Enabled), 5, 0), true);
         edtCheqDFecD_Enabled = 0;
         AssignProp("", false, edtCheqDFecD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDFecD_Enabled), 5, 0), true);
         edtCheqDFecV_Enabled = 0;
         AssignProp("", false, edtCheqDFecV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDFecV_Enabled), 5, 0), true);
         edtCheqDimpD_Enabled = 0;
         AssignProp("", false, edtCheqDimpD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDimpD_Enabled), 5, 0), true);
         edtCheqDPagCod_Enabled = 0;
         AssignProp("", false, edtCheqDPagCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCheqDPagCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E15( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816421592", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cpchequediferidodet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z238CheqDCod", StringUtil.RTrim( Z238CheqDCod));
         GxWebStd.gx_hidden_field( context, "Z241CheqDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z241CheqDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z535CheqDTipo", StringUtil.RTrim( Z535CheqDTipo));
         GxWebStd.gx_hidden_field( context, "Z523CheqDDocNum", StringUtil.RTrim( Z523CheqDDocNum));
         GxWebStd.gx_hidden_field( context, "Z522CheqDDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z522CheqDDias), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z525CheqDFecD", context.localUtil.DToC( Z525CheqDFecD, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z526CheqDFecV", context.localUtil.DToC( Z526CheqDFecV, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z528CheqDimpD", StringUtil.LTrim( StringUtil.NToC( Z528CheqDimpD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z530CheqDPagCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z530CheqDPagCod), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z242CheqDTipCod", StringUtil.RTrim( Z242CheqDTipCod));
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
         return formatLink("cpchequediferidodet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPCHEQUEDIFERIDODET" ;
      }

      public override string GetPgmdesc( )
      {
         return "ChequeDiferido Detalle" ;
      }

      protected void InitializeNonKey0E15( )
      {
         A535CheqDTipo = "";
         AssignAttri("", false, "A535CheqDTipo", A535CheqDTipo);
         A242CheqDTipCod = "";
         AssignAttri("", false, "A242CheqDTipCod", A242CheqDTipCod);
         A523CheqDDocNum = "";
         AssignAttri("", false, "A523CheqDDocNum", A523CheqDDocNum);
         A522CheqDDias = 0;
         AssignAttri("", false, "A522CheqDDias", StringUtil.LTrimStr( (decimal)(A522CheqDDias), 6, 0));
         A525CheqDFecD = DateTime.MinValue;
         AssignAttri("", false, "A525CheqDFecD", context.localUtil.Format(A525CheqDFecD, "99/99/99"));
         A526CheqDFecV = DateTime.MinValue;
         AssignAttri("", false, "A526CheqDFecV", context.localUtil.Format(A526CheqDFecV, "99/99/99"));
         A528CheqDimpD = 0;
         AssignAttri("", false, "A528CheqDimpD", StringUtil.LTrimStr( A528CheqDimpD, 15, 2));
         A530CheqDPagCod = 0;
         AssignAttri("", false, "A530CheqDPagCod", StringUtil.LTrimStr( (decimal)(A530CheqDPagCod), 10, 0));
         Z535CheqDTipo = "";
         Z523CheqDDocNum = "";
         Z522CheqDDias = 0;
         Z525CheqDFecD = DateTime.MinValue;
         Z526CheqDFecV = DateTime.MinValue;
         Z528CheqDimpD = 0;
         Z530CheqDPagCod = 0;
         Z242CheqDTipCod = "";
      }

      protected void InitAll0E15( )
      {
         A238CheqDCod = "";
         AssignAttri("", false, "A238CheqDCod", A238CheqDCod);
         A241CheqDItem = 0;
         AssignAttri("", false, "A241CheqDItem", StringUtil.LTrimStr( (decimal)(A241CheqDItem), 6, 0));
         InitializeNonKey0E15( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181642167", true, true);
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
         context.AddJavascriptSource("cpchequediferidodet.js", "?20228181642168", false, true);
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
         edtCheqDCod_Internalname = "CHEQDCOD";
         edtCheqDItem_Internalname = "CHEQDITEM";
         edtCheqDTipo_Internalname = "CHEQDTIPO";
         edtCheqDTipCod_Internalname = "CHEQDTIPCOD";
         edtCheqDDocNum_Internalname = "CHEQDDOCNUM";
         edtCheqDDias_Internalname = "CHEQDDIAS";
         edtCheqDFecD_Internalname = "CHEQDFECD";
         edtCheqDFecV_Internalname = "CHEQDFECV";
         edtCheqDimpD_Internalname = "CHEQDIMPD";
         edtCheqDPagCod_Internalname = "CHEQDPAGCOD";
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
         Form.Caption = "ChequeDiferido Detalle";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCheqDPagCod_Jsonclick = "";
         edtCheqDPagCod_Enabled = 1;
         edtCheqDimpD_Jsonclick = "";
         edtCheqDimpD_Enabled = 1;
         edtCheqDFecV_Jsonclick = "";
         edtCheqDFecV_Enabled = 1;
         edtCheqDFecD_Jsonclick = "";
         edtCheqDFecD_Enabled = 1;
         edtCheqDDias_Jsonclick = "";
         edtCheqDDias_Enabled = 1;
         edtCheqDDocNum_Jsonclick = "";
         edtCheqDDocNum_Enabled = 1;
         edtCheqDTipCod_Jsonclick = "";
         edtCheqDTipCod_Enabled = 1;
         edtCheqDTipo_Jsonclick = "";
         edtCheqDTipo_Enabled = 1;
         edtCheqDItem_Jsonclick = "";
         edtCheqDItem_Enabled = 1;
         edtCheqDCod_Jsonclick = "";
         edtCheqDCod_Enabled = 1;
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
         /* Using cursor T000E16 */
         pr_default.execute(14, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'CPCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtCheqDTipo_Internalname;
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

      public void Valid_Cheqdcod( )
      {
         /* Using cursor T000E16 */
         pr_default.execute(14, new Object[] {A238CheqDCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'CPCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Cheqditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A535CheqDTipo", StringUtil.RTrim( A535CheqDTipo));
         AssignAttri("", false, "A242CheqDTipCod", StringUtil.RTrim( A242CheqDTipCod));
         AssignAttri("", false, "A523CheqDDocNum", StringUtil.RTrim( A523CheqDDocNum));
         AssignAttri("", false, "A522CheqDDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A522CheqDDias), 6, 0, ".", "")));
         AssignAttri("", false, "A525CheqDFecD", context.localUtil.Format(A525CheqDFecD, "99/99/99"));
         AssignAttri("", false, "A526CheqDFecV", context.localUtil.Format(A526CheqDFecV, "99/99/99"));
         AssignAttri("", false, "A528CheqDimpD", StringUtil.LTrim( StringUtil.NToC( A528CheqDimpD, 15, 2, ".", "")));
         AssignAttri("", false, "A530CheqDPagCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A530CheqDPagCod), 10, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z238CheqDCod", StringUtil.RTrim( Z238CheqDCod));
         GxWebStd.gx_hidden_field( context, "Z241CheqDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z241CheqDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z535CheqDTipo", StringUtil.RTrim( Z535CheqDTipo));
         GxWebStd.gx_hidden_field( context, "Z242CheqDTipCod", StringUtil.RTrim( Z242CheqDTipCod));
         GxWebStd.gx_hidden_field( context, "Z523CheqDDocNum", StringUtil.RTrim( Z523CheqDDocNum));
         GxWebStd.gx_hidden_field( context, "Z522CheqDDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z522CheqDDias), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z525CheqDFecD", context.localUtil.Format(Z525CheqDFecD, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z526CheqDFecV", context.localUtil.Format(Z526CheqDFecV, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z528CheqDimpD", StringUtil.LTrim( StringUtil.NToC( Z528CheqDimpD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z530CheqDPagCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z530CheqDPagCod), 10, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cheqdtipcod( )
      {
         /* Using cursor T000E17 */
         pr_default.execute(15, new Object[] {A242CheqDTipCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documento'.", "ForeignKeyNotFound", 1, "CHEQDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCheqDTipCod_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("VALID_CHEQDCOD","{handler:'Valid_Cheqdcod',iparms:[{av:'A238CheqDCod',fld:'CHEQDCOD',pic:''}]");
         setEventMetadata("VALID_CHEQDCOD",",oparms:[]}");
         setEventMetadata("VALID_CHEQDITEM","{handler:'Valid_Cheqditem',iparms:[{av:'A238CheqDCod',fld:'CHEQDCOD',pic:''},{av:'A241CheqDItem',fld:'CHEQDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CHEQDITEM",",oparms:[{av:'A535CheqDTipo',fld:'CHEQDTIPO',pic:''},{av:'A242CheqDTipCod',fld:'CHEQDTIPCOD',pic:''},{av:'A523CheqDDocNum',fld:'CHEQDDOCNUM',pic:''},{av:'A522CheqDDias',fld:'CHEQDDIAS',pic:'ZZZZZ9'},{av:'A525CheqDFecD',fld:'CHEQDFECD',pic:''},{av:'A526CheqDFecV',fld:'CHEQDFECV',pic:''},{av:'A528CheqDimpD',fld:'CHEQDIMPD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A530CheqDPagCod',fld:'CHEQDPAGCOD',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z238CheqDCod'},{av:'Z241CheqDItem'},{av:'Z535CheqDTipo'},{av:'Z242CheqDTipCod'},{av:'Z523CheqDDocNum'},{av:'Z522CheqDDias'},{av:'Z525CheqDFecD'},{av:'Z526CheqDFecV'},{av:'Z528CheqDimpD'},{av:'Z530CheqDPagCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CHEQDTIPCOD","{handler:'Valid_Cheqdtipcod',iparms:[{av:'A242CheqDTipCod',fld:'CHEQDTIPCOD',pic:''}]");
         setEventMetadata("VALID_CHEQDTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_CHEQDFECD","{handler:'Valid_Cheqdfecd',iparms:[]");
         setEventMetadata("VALID_CHEQDFECD",",oparms:[]}");
         setEventMetadata("VALID_CHEQDFECV","{handler:'Valid_Cheqdfecv',iparms:[]");
         setEventMetadata("VALID_CHEQDFECV",",oparms:[]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z238CheqDCod = "";
         Z535CheqDTipo = "";
         Z523CheqDDocNum = "";
         Z525CheqDFecD = DateTime.MinValue;
         Z526CheqDFecV = DateTime.MinValue;
         Z242CheqDTipCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A238CheqDCod = "";
         A242CheqDTipCod = "";
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
         A535CheqDTipo = "";
         A523CheqDDocNum = "";
         A525CheqDFecD = DateTime.MinValue;
         A526CheqDFecV = DateTime.MinValue;
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
         T000E6_A241CheqDItem = new int[1] ;
         T000E6_A535CheqDTipo = new string[] {""} ;
         T000E6_A523CheqDDocNum = new string[] {""} ;
         T000E6_A522CheqDDias = new int[1] ;
         T000E6_A525CheqDFecD = new DateTime[] {DateTime.MinValue} ;
         T000E6_A526CheqDFecV = new DateTime[] {DateTime.MinValue} ;
         T000E6_A528CheqDimpD = new decimal[1] ;
         T000E6_A530CheqDPagCod = new long[1] ;
         T000E6_A238CheqDCod = new string[] {""} ;
         T000E6_A242CheqDTipCod = new string[] {""} ;
         T000E4_A238CheqDCod = new string[] {""} ;
         T000E5_A242CheqDTipCod = new string[] {""} ;
         T000E7_A238CheqDCod = new string[] {""} ;
         T000E8_A242CheqDTipCod = new string[] {""} ;
         T000E9_A238CheqDCod = new string[] {""} ;
         T000E9_A241CheqDItem = new int[1] ;
         T000E3_A241CheqDItem = new int[1] ;
         T000E3_A535CheqDTipo = new string[] {""} ;
         T000E3_A523CheqDDocNum = new string[] {""} ;
         T000E3_A522CheqDDias = new int[1] ;
         T000E3_A525CheqDFecD = new DateTime[] {DateTime.MinValue} ;
         T000E3_A526CheqDFecV = new DateTime[] {DateTime.MinValue} ;
         T000E3_A528CheqDimpD = new decimal[1] ;
         T000E3_A530CheqDPagCod = new long[1] ;
         T000E3_A238CheqDCod = new string[] {""} ;
         T000E3_A242CheqDTipCod = new string[] {""} ;
         sMode15 = "";
         T000E10_A238CheqDCod = new string[] {""} ;
         T000E10_A241CheqDItem = new int[1] ;
         T000E11_A238CheqDCod = new string[] {""} ;
         T000E11_A241CheqDItem = new int[1] ;
         T000E2_A241CheqDItem = new int[1] ;
         T000E2_A535CheqDTipo = new string[] {""} ;
         T000E2_A523CheqDDocNum = new string[] {""} ;
         T000E2_A522CheqDDias = new int[1] ;
         T000E2_A525CheqDFecD = new DateTime[] {DateTime.MinValue} ;
         T000E2_A526CheqDFecV = new DateTime[] {DateTime.MinValue} ;
         T000E2_A528CheqDimpD = new decimal[1] ;
         T000E2_A530CheqDPagCod = new long[1] ;
         T000E2_A238CheqDCod = new string[] {""} ;
         T000E2_A242CheqDTipCod = new string[] {""} ;
         T000E15_A238CheqDCod = new string[] {""} ;
         T000E15_A241CheqDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000E16_A238CheqDCod = new string[] {""} ;
         ZZ238CheqDCod = "";
         ZZ535CheqDTipo = "";
         ZZ242CheqDTipCod = "";
         ZZ523CheqDDocNum = "";
         ZZ525CheqDFecD = DateTime.MinValue;
         ZZ526CheqDFecV = DateTime.MinValue;
         T000E17_A242CheqDTipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpchequediferidodet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpchequediferidodet__default(),
            new Object[][] {
                new Object[] {
               T000E2_A241CheqDItem, T000E2_A535CheqDTipo, T000E2_A523CheqDDocNum, T000E2_A522CheqDDias, T000E2_A525CheqDFecD, T000E2_A526CheqDFecV, T000E2_A528CheqDimpD, T000E2_A530CheqDPagCod, T000E2_A238CheqDCod, T000E2_A242CheqDTipCod
               }
               , new Object[] {
               T000E3_A241CheqDItem, T000E3_A535CheqDTipo, T000E3_A523CheqDDocNum, T000E3_A522CheqDDias, T000E3_A525CheqDFecD, T000E3_A526CheqDFecV, T000E3_A528CheqDimpD, T000E3_A530CheqDPagCod, T000E3_A238CheqDCod, T000E3_A242CheqDTipCod
               }
               , new Object[] {
               T000E4_A238CheqDCod
               }
               , new Object[] {
               T000E5_A242CheqDTipCod
               }
               , new Object[] {
               T000E6_A241CheqDItem, T000E6_A535CheqDTipo, T000E6_A523CheqDDocNum, T000E6_A522CheqDDias, T000E6_A525CheqDFecD, T000E6_A526CheqDFecV, T000E6_A528CheqDimpD, T000E6_A530CheqDPagCod, T000E6_A238CheqDCod, T000E6_A242CheqDTipCod
               }
               , new Object[] {
               T000E7_A238CheqDCod
               }
               , new Object[] {
               T000E8_A242CheqDTipCod
               }
               , new Object[] {
               T000E9_A238CheqDCod, T000E9_A241CheqDItem
               }
               , new Object[] {
               T000E10_A238CheqDCod, T000E10_A241CheqDItem
               }
               , new Object[] {
               T000E11_A238CheqDCod, T000E11_A241CheqDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E15_A238CheqDCod, T000E15_A241CheqDItem
               }
               , new Object[] {
               T000E16_A238CheqDCod
               }
               , new Object[] {
               T000E17_A242CheqDTipCod
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
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z241CheqDItem ;
      private int Z522CheqDDias ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCheqDCod_Enabled ;
      private int A241CheqDItem ;
      private int edtCheqDItem_Enabled ;
      private int edtCheqDTipo_Enabled ;
      private int edtCheqDTipCod_Enabled ;
      private int edtCheqDDocNum_Enabled ;
      private int A522CheqDDias ;
      private int edtCheqDDias_Enabled ;
      private int edtCheqDFecD_Enabled ;
      private int edtCheqDFecV_Enabled ;
      private int edtCheqDimpD_Enabled ;
      private int edtCheqDPagCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ241CheqDItem ;
      private int ZZ522CheqDDias ;
      private long Z530CheqDPagCod ;
      private long A530CheqDPagCod ;
      private long ZZ530CheqDPagCod ;
      private decimal Z528CheqDimpD ;
      private decimal A528CheqDimpD ;
      private decimal ZZ528CheqDimpD ;
      private string sPrefix ;
      private string Z238CheqDCod ;
      private string Z535CheqDTipo ;
      private string Z523CheqDDocNum ;
      private string Z242CheqDTipCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A238CheqDCod ;
      private string A242CheqDTipCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCheqDCod_Internalname ;
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
      private string edtCheqDCod_Jsonclick ;
      private string edtCheqDItem_Internalname ;
      private string edtCheqDItem_Jsonclick ;
      private string edtCheqDTipo_Internalname ;
      private string A535CheqDTipo ;
      private string edtCheqDTipo_Jsonclick ;
      private string edtCheqDTipCod_Internalname ;
      private string edtCheqDTipCod_Jsonclick ;
      private string edtCheqDDocNum_Internalname ;
      private string A523CheqDDocNum ;
      private string edtCheqDDocNum_Jsonclick ;
      private string edtCheqDDias_Internalname ;
      private string edtCheqDDias_Jsonclick ;
      private string edtCheqDFecD_Internalname ;
      private string edtCheqDFecD_Jsonclick ;
      private string edtCheqDFecV_Internalname ;
      private string edtCheqDFecV_Jsonclick ;
      private string edtCheqDimpD_Internalname ;
      private string edtCheqDimpD_Jsonclick ;
      private string edtCheqDPagCod_Internalname ;
      private string edtCheqDPagCod_Jsonclick ;
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
      private string sMode15 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ238CheqDCod ;
      private string ZZ535CheqDTipo ;
      private string ZZ242CheqDTipCod ;
      private string ZZ523CheqDDocNum ;
      private DateTime Z525CheqDFecD ;
      private DateTime Z526CheqDFecV ;
      private DateTime A525CheqDFecD ;
      private DateTime A526CheqDFecV ;
      private DateTime ZZ525CheqDFecD ;
      private DateTime ZZ526CheqDFecV ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000E6_A241CheqDItem ;
      private string[] T000E6_A535CheqDTipo ;
      private string[] T000E6_A523CheqDDocNum ;
      private int[] T000E6_A522CheqDDias ;
      private DateTime[] T000E6_A525CheqDFecD ;
      private DateTime[] T000E6_A526CheqDFecV ;
      private decimal[] T000E6_A528CheqDimpD ;
      private long[] T000E6_A530CheqDPagCod ;
      private string[] T000E6_A238CheqDCod ;
      private string[] T000E6_A242CheqDTipCod ;
      private string[] T000E4_A238CheqDCod ;
      private string[] T000E5_A242CheqDTipCod ;
      private string[] T000E7_A238CheqDCod ;
      private string[] T000E8_A242CheqDTipCod ;
      private string[] T000E9_A238CheqDCod ;
      private int[] T000E9_A241CheqDItem ;
      private int[] T000E3_A241CheqDItem ;
      private string[] T000E3_A535CheqDTipo ;
      private string[] T000E3_A523CheqDDocNum ;
      private int[] T000E3_A522CheqDDias ;
      private DateTime[] T000E3_A525CheqDFecD ;
      private DateTime[] T000E3_A526CheqDFecV ;
      private decimal[] T000E3_A528CheqDimpD ;
      private long[] T000E3_A530CheqDPagCod ;
      private string[] T000E3_A238CheqDCod ;
      private string[] T000E3_A242CheqDTipCod ;
      private string[] T000E10_A238CheqDCod ;
      private int[] T000E10_A241CheqDItem ;
      private string[] T000E11_A238CheqDCod ;
      private int[] T000E11_A241CheqDItem ;
      private int[] T000E2_A241CheqDItem ;
      private string[] T000E2_A535CheqDTipo ;
      private string[] T000E2_A523CheqDDocNum ;
      private int[] T000E2_A522CheqDDias ;
      private DateTime[] T000E2_A525CheqDFecD ;
      private DateTime[] T000E2_A526CheqDFecV ;
      private decimal[] T000E2_A528CheqDimpD ;
      private long[] T000E2_A530CheqDPagCod ;
      private string[] T000E2_A238CheqDCod ;
      private string[] T000E2_A242CheqDTipCod ;
      private string[] T000E15_A238CheqDCod ;
      private int[] T000E15_A241CheqDItem ;
      private string[] T000E16_A238CheqDCod ;
      private string[] T000E17_A242CheqDTipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpchequediferidodet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpchequediferidodet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000E6;
        prmT000E6 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E4;
        prmT000E4 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000E5;
        prmT000E5 = new Object[] {
        new ParDef("@CheqDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT000E7;
        prmT000E7 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000E8;
        prmT000E8 = new Object[] {
        new ParDef("@CheqDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT000E9;
        prmT000E9 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E3;
        prmT000E3 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E10;
        prmT000E10 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E11;
        prmT000E11 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E2;
        prmT000E2 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E12;
        prmT000E12 = new Object[] {
        new ParDef("@CheqDItem",GXType.Int32,6,0) ,
        new ParDef("@CheqDTipo",GXType.NChar,1,0) ,
        new ParDef("@CheqDDocNum",GXType.NChar,15,0) ,
        new ParDef("@CheqDDias",GXType.Int32,6,0) ,
        new ParDef("@CheqDFecD",GXType.Date,8,0) ,
        new ParDef("@CheqDFecV",GXType.Date,8,0) ,
        new ParDef("@CheqDimpD",GXType.Decimal,15,2) ,
        new ParDef("@CheqDPagCod",GXType.Decimal,10,0) ,
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT000E13;
        prmT000E13 = new Object[] {
        new ParDef("@CheqDTipo",GXType.NChar,1,0) ,
        new ParDef("@CheqDDocNum",GXType.NChar,15,0) ,
        new ParDef("@CheqDDias",GXType.Int32,6,0) ,
        new ParDef("@CheqDFecD",GXType.Date,8,0) ,
        new ParDef("@CheqDFecV",GXType.Date,8,0) ,
        new ParDef("@CheqDimpD",GXType.Decimal,15,2) ,
        new ParDef("@CheqDPagCod",GXType.Decimal,10,0) ,
        new ParDef("@CheqDTipCod",GXType.NChar,3,0) ,
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E14;
        prmT000E14 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000E15;
        prmT000E15 = new Object[] {
        };
        Object[] prmT000E16;
        prmT000E16 = new Object[] {
        new ParDef("@CheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000E17;
        prmT000E17 = new Object[] {
        new ParDef("@CheqDTipCod",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000E2", "SELECT [CheqDItem], [CheqDTipo], [CheqDDocNum], [CheqDDias], [CheqDFecD], [CheqDFecV], [CheqDimpD], [CheqDPagCod], [CheqDCod], [CheqDTipCod] AS CheqDTipCod FROM [CPCHEQUEDIFERIDODET] WITH (UPDLOCK) WHERE [CheqDCod] = @CheqDCod AND [CheqDItem] = @CheqDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E3", "SELECT [CheqDItem], [CheqDTipo], [CheqDDocNum], [CheqDDias], [CheqDFecD], [CheqDFecV], [CheqDimpD], [CheqDPagCod], [CheqDCod], [CheqDTipCod] AS CheqDTipCod FROM [CPCHEQUEDIFERIDODET] WHERE [CheqDCod] = @CheqDCod AND [CheqDItem] = @CheqDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E4", "SELECT [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE [CheqDCod] = @CheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E5", "SELECT [TipCod] AS CheqDTipCod FROM [CTIPDOC] WHERE [TipCod] = @CheqDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E6", "SELECT TM1.[CheqDItem], TM1.[CheqDTipo], TM1.[CheqDDocNum], TM1.[CheqDDias], TM1.[CheqDFecD], TM1.[CheqDFecV], TM1.[CheqDimpD], TM1.[CheqDPagCod], TM1.[CheqDCod], TM1.[CheqDTipCod] AS CheqDTipCod FROM [CPCHEQUEDIFERIDODET] TM1 WHERE TM1.[CheqDCod] = @CheqDCod and TM1.[CheqDItem] = @CheqDItem ORDER BY TM1.[CheqDCod], TM1.[CheqDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E7", "SELECT [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE [CheqDCod] = @CheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E8", "SELECT [TipCod] AS CheqDTipCod FROM [CTIPDOC] WHERE [TipCod] = @CheqDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E9", "SELECT [CheqDCod], [CheqDItem] FROM [CPCHEQUEDIFERIDODET] WHERE [CheqDCod] = @CheqDCod AND [CheqDItem] = @CheqDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E10", "SELECT TOP 1 [CheqDCod], [CheqDItem] FROM [CPCHEQUEDIFERIDODET] WHERE ( [CheqDCod] > @CheqDCod or [CheqDCod] = @CheqDCod and [CheqDItem] > @CheqDItem) ORDER BY [CheqDCod], [CheqDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E11", "SELECT TOP 1 [CheqDCod], [CheqDItem] FROM [CPCHEQUEDIFERIDODET] WHERE ( [CheqDCod] < @CheqDCod or [CheqDCod] = @CheqDCod and [CheqDItem] < @CheqDItem) ORDER BY [CheqDCod] DESC, [CheqDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E12", "INSERT INTO [CPCHEQUEDIFERIDODET]([CheqDItem], [CheqDTipo], [CheqDDocNum], [CheqDDias], [CheqDFecD], [CheqDFecV], [CheqDimpD], [CheqDPagCod], [CheqDCod], [CheqDTipCod]) VALUES(@CheqDItem, @CheqDTipo, @CheqDDocNum, @CheqDDias, @CheqDFecD, @CheqDFecV, @CheqDimpD, @CheqDPagCod, @CheqDCod, @CheqDTipCod)", GxErrorMask.GX_NOMASK,prmT000E12)
           ,new CursorDef("T000E13", "UPDATE [CPCHEQUEDIFERIDODET] SET [CheqDTipo]=@CheqDTipo, [CheqDDocNum]=@CheqDDocNum, [CheqDDias]=@CheqDDias, [CheqDFecD]=@CheqDFecD, [CheqDFecV]=@CheqDFecV, [CheqDimpD]=@CheqDimpD, [CheqDPagCod]=@CheqDPagCod, [CheqDTipCod]=@CheqDTipCod  WHERE [CheqDCod] = @CheqDCod AND [CheqDItem] = @CheqDItem", GxErrorMask.GX_NOMASK,prmT000E13)
           ,new CursorDef("T000E14", "DELETE FROM [CPCHEQUEDIFERIDODET]  WHERE [CheqDCod] = @CheqDCod AND [CheqDItem] = @CheqDItem", GxErrorMask.GX_NOMASK,prmT000E14)
           ,new CursorDef("T000E15", "SELECT [CheqDCod], [CheqDItem] FROM [CPCHEQUEDIFERIDODET] ORDER BY [CheqDCod], [CheqDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000E15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E16", "SELECT [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE [CheqDCod] = @CheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E17", "SELECT [TipCod] AS CheqDTipCod FROM [CTIPDOC] WHERE [TipCod] = @CheqDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E17,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 10);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
