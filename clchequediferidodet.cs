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
   public class clchequediferidodet : GXDataArea
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
            A150CLCheqDCod = GetPar( "CLCheqDCod");
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A150CLCheqDCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A154CLCheqDTipCod = GetPar( "CLCheqDTipCod");
            AssignAttri("", false, "A154CLCheqDTipCod", A154CLCheqDTipCod);
            A155CLCheqDDocNum = GetPar( "CLCheqDDocNum");
            AssignAttri("", false, "A155CLCheqDDocNum", A155CLCheqDDocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A154CLCheqDTipCod, A155CLCheqDDocNum) ;
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
            Form.Meta.addItem("description", "CLCHEQDIFERIDODET", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clchequediferidodet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clchequediferidodet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CLCHEQDIFERIDODET", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDCod_Internalname, "N° Canje Cheque", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDCod_Internalname, StringUtil.RTrim( A150CLCheqDCod), StringUtil.RTrim( context.localUtil.Format( A150CLCheqDCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A153CLCheqDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtCLCheqDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A153CLCheqDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A153CLCheqDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDTipo_Internalname, "C", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDTipo_Internalname, StringUtil.RTrim( A567CLCheqDTipo), StringUtil.RTrim( context.localUtil.Format( A567CLCheqDTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDTipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDTipCod_Internalname, "D", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDTipCod_Internalname, StringUtil.RTrim( A154CLCheqDTipCod), StringUtil.RTrim( context.localUtil.Format( A154CLCheqDTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDDocNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDDocNum_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDDocNum_Internalname, StringUtil.RTrim( A155CLCheqDDocNum), StringUtil.RTrim( context.localUtil.Format( A155CLCheqDDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDDias_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDDias_Internalname, "Dias", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDDias_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A557CLCheqDDias), 6, 0, ".", "")), StringUtil.LTrim( ((edtCLCheqDDias_Enabled!=0) ? context.localUtil.Format( (decimal)(A557CLCheqDDias), "ZZZZZ9") : context.localUtil.Format( (decimal)(A557CLCheqDDias), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDDias_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDDias_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDFecD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDFecD_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCLCheqDFecD_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCLCheqDFecD_Internalname, context.localUtil.Format(A559CLCheqDFecD, "99/99/99"), context.localUtil.Format( A559CLCheqDFecD, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDFecD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDFecD_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_bitmap( context, edtCLCheqDFecD_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCLCheqDFecD_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDFecV_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDFecV_Internalname, "Vcto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCLCheqDFecV_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCLCheqDFecV_Internalname, context.localUtil.Format(A560CLCheqDFecV, "99/99/99"), context.localUtil.Format( A560CLCheqDFecV, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDFecV_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDFecV_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_bitmap( context, edtCLCheqDFecV_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCLCheqDFecV_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLCHEQUEDIFERIDODET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLCheqDImpD_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLCheqDImpD_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLCheqDImpD_Internalname, StringUtil.LTrim( StringUtil.NToC( A562CLCheqDImpD, 17, 2, ".", "")), StringUtil.LTrim( ((edtCLCheqDImpD_Enabled!=0) ? context.localUtil.Format( A562CLCheqDImpD, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A562CLCheqDImpD, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLCheqDImpD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLCheqDImpD_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLCHEQUEDIFERIDODET.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDODET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCHEQUEDIFERIDODET.htm");
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
            Z150CLCheqDCod = cgiGet( "Z150CLCheqDCod");
            Z153CLCheqDItem = (int)(context.localUtil.CToN( cgiGet( "Z153CLCheqDItem"), ".", ","));
            Z567CLCheqDTipo = cgiGet( "Z567CLCheqDTipo");
            Z557CLCheqDDias = (int)(context.localUtil.CToN( cgiGet( "Z557CLCheqDDias"), ".", ","));
            Z559CLCheqDFecD = context.localUtil.CToD( cgiGet( "Z559CLCheqDFecD"), 0);
            Z560CLCheqDFecV = context.localUtil.CToD( cgiGet( "Z560CLCheqDFecV"), 0);
            Z562CLCheqDImpD = context.localUtil.CToN( cgiGet( "Z562CLCheqDImpD"), ".", ",");
            Z154CLCheqDTipCod = cgiGet( "Z154CLCheqDTipCod");
            Z155CLCheqDDocNum = cgiGet( "Z155CLCheqDDocNum");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A150CLCheqDCod = cgiGet( edtCLCheqDCod_Internalname);
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDITEM");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A153CLCheqDItem = 0;
               AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
            }
            else
            {
               A153CLCheqDItem = (int)(context.localUtil.CToN( cgiGet( edtCLCheqDItem_Internalname), ".", ","));
               AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
            }
            A567CLCheqDTipo = cgiGet( edtCLCheqDTipo_Internalname);
            AssignAttri("", false, "A567CLCheqDTipo", A567CLCheqDTipo);
            A154CLCheqDTipCod = cgiGet( edtCLCheqDTipCod_Internalname);
            AssignAttri("", false, "A154CLCheqDTipCod", A154CLCheqDTipCod);
            A155CLCheqDDocNum = cgiGet( edtCLCheqDDocNum_Internalname);
            AssignAttri("", false, "A155CLCheqDDocNum", A155CLCheqDDocNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDDias_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDDias_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDDIAS");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDDias_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A557CLCheqDDias = 0;
               AssignAttri("", false, "A557CLCheqDDias", StringUtil.LTrimStr( (decimal)(A557CLCheqDDias), 6, 0));
            }
            else
            {
               A557CLCheqDDias = (int)(context.localUtil.CToN( cgiGet( edtCLCheqDDias_Internalname), ".", ","));
               AssignAttri("", false, "A557CLCheqDDias", StringUtil.LTrimStr( (decimal)(A557CLCheqDDias), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtCLCheqDFecD_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "CLCHEQDFECD");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDFecD_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A559CLCheqDFecD = DateTime.MinValue;
               AssignAttri("", false, "A559CLCheqDFecD", context.localUtil.Format(A559CLCheqDFecD, "99/99/99"));
            }
            else
            {
               A559CLCheqDFecD = context.localUtil.CToD( cgiGet( edtCLCheqDFecD_Internalname), 2);
               AssignAttri("", false, "A559CLCheqDFecD", context.localUtil.Format(A559CLCheqDFecD, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtCLCheqDFecV_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "CLCHEQDFECV");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDFecV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A560CLCheqDFecV = DateTime.MinValue;
               AssignAttri("", false, "A560CLCheqDFecV", context.localUtil.Format(A560CLCheqDFecV, "99/99/99"));
            }
            else
            {
               A560CLCheqDFecV = context.localUtil.CToD( cgiGet( edtCLCheqDFecV_Internalname), 2);
               AssignAttri("", false, "A560CLCheqDFecV", context.localUtil.Format(A560CLCheqDFecV, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLCheqDImpD_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCLCheqDImpD_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLCHEQDIMPD");
               AnyError = 1;
               GX_FocusControl = edtCLCheqDImpD_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A562CLCheqDImpD = 0;
               AssignAttri("", false, "A562CLCheqDImpD", StringUtil.LTrimStr( A562CLCheqDImpD, 15, 2));
            }
            else
            {
               A562CLCheqDImpD = context.localUtil.CToN( cgiGet( edtCLCheqDImpD_Internalname), ".", ",");
               AssignAttri("", false, "A562CLCheqDImpD", StringUtil.LTrimStr( A562CLCheqDImpD, 15, 2));
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
               A150CLCheqDCod = GetPar( "CLCheqDCod");
               AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
               A153CLCheqDItem = (int)(NumberUtil.Val( GetPar( "CLCheqDItem"), "."));
               AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
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
               InitAll0A10( ) ;
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
         DisableAttributes0A10( ) ;
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

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z567CLCheqDTipo = T000A3_A567CLCheqDTipo[0];
               Z557CLCheqDDias = T000A3_A557CLCheqDDias[0];
               Z559CLCheqDFecD = T000A3_A559CLCheqDFecD[0];
               Z560CLCheqDFecV = T000A3_A560CLCheqDFecV[0];
               Z562CLCheqDImpD = T000A3_A562CLCheqDImpD[0];
               Z154CLCheqDTipCod = T000A3_A154CLCheqDTipCod[0];
               Z155CLCheqDDocNum = T000A3_A155CLCheqDDocNum[0];
            }
            else
            {
               Z567CLCheqDTipo = A567CLCheqDTipo;
               Z557CLCheqDDias = A557CLCheqDDias;
               Z559CLCheqDFecD = A559CLCheqDFecD;
               Z560CLCheqDFecV = A560CLCheqDFecV;
               Z562CLCheqDImpD = A562CLCheqDImpD;
               Z154CLCheqDTipCod = A154CLCheqDTipCod;
               Z155CLCheqDDocNum = A155CLCheqDDocNum;
            }
         }
         if ( GX_JID == -3 )
         {
            Z153CLCheqDItem = A153CLCheqDItem;
            Z567CLCheqDTipo = A567CLCheqDTipo;
            Z557CLCheqDDias = A557CLCheqDDias;
            Z559CLCheqDFecD = A559CLCheqDFecD;
            Z560CLCheqDFecV = A560CLCheqDFecV;
            Z562CLCheqDImpD = A562CLCheqDImpD;
            Z150CLCheqDCod = A150CLCheqDCod;
            Z154CLCheqDTipCod = A154CLCheqDTipCod;
            Z155CLCheqDDocNum = A155CLCheqDDocNum;
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

      protected void Load0A10( )
      {
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A150CLCheqDCod, A153CLCheqDItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound10 = 1;
            A567CLCheqDTipo = T000A6_A567CLCheqDTipo[0];
            AssignAttri("", false, "A567CLCheqDTipo", A567CLCheqDTipo);
            A557CLCheqDDias = T000A6_A557CLCheqDDias[0];
            AssignAttri("", false, "A557CLCheqDDias", StringUtil.LTrimStr( (decimal)(A557CLCheqDDias), 6, 0));
            A559CLCheqDFecD = T000A6_A559CLCheqDFecD[0];
            AssignAttri("", false, "A559CLCheqDFecD", context.localUtil.Format(A559CLCheqDFecD, "99/99/99"));
            A560CLCheqDFecV = T000A6_A560CLCheqDFecV[0];
            AssignAttri("", false, "A560CLCheqDFecV", context.localUtil.Format(A560CLCheqDFecV, "99/99/99"));
            A562CLCheqDImpD = T000A6_A562CLCheqDImpD[0];
            AssignAttri("", false, "A562CLCheqDImpD", StringUtil.LTrimStr( A562CLCheqDImpD, 15, 2));
            A154CLCheqDTipCod = T000A6_A154CLCheqDTipCod[0];
            AssignAttri("", false, "A154CLCheqDTipCod", A154CLCheqDTipCod);
            A155CLCheqDDocNum = T000A6_A155CLCheqDDocNum[0];
            AssignAttri("", false, "A155CLCheqDDocNum", A155CLCheqDDocNum);
            ZM0A10( -3) ;
         }
         pr_default.close(4);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'CLCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A154CLCheqDTipCod, A155CLCheqDDocNum});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Cheques Diferidos Cliente Documento'.", "ForeignKeyNotFound", 1, "CLCHEQDDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A559CLCheqDFecD) || ( DateTimeUtil.ResetTime ( A559CLCheqDFecD ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CLCHEQDFECD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDFecD_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A560CLCheqDFecV) || ( DateTimeUtil.ResetTime ( A560CLCheqDFecV ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "CLCHEQDFECV");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDFecV_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0A10( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A150CLCheqDCod )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'CLCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
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

      protected void gxLoad_5( string A154CLCheqDTipCod ,
                               string A155CLCheqDDocNum )
      {
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A154CLCheqDTipCod, A155CLCheqDDocNum});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Cheques Diferidos Cliente Documento'.", "ForeignKeyNotFound", 1, "CLCHEQDDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDTipCod_Internalname;
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

      protected void GetKey0A10( )
      {
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A150CLCheqDCod, A153CLCheqDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A150CLCheqDCod, A153CLCheqDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A10( 3) ;
            RcdFound10 = 1;
            A153CLCheqDItem = T000A3_A153CLCheqDItem[0];
            AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
            A567CLCheqDTipo = T000A3_A567CLCheqDTipo[0];
            AssignAttri("", false, "A567CLCheqDTipo", A567CLCheqDTipo);
            A557CLCheqDDias = T000A3_A557CLCheqDDias[0];
            AssignAttri("", false, "A557CLCheqDDias", StringUtil.LTrimStr( (decimal)(A557CLCheqDDias), 6, 0));
            A559CLCheqDFecD = T000A3_A559CLCheqDFecD[0];
            AssignAttri("", false, "A559CLCheqDFecD", context.localUtil.Format(A559CLCheqDFecD, "99/99/99"));
            A560CLCheqDFecV = T000A3_A560CLCheqDFecV[0];
            AssignAttri("", false, "A560CLCheqDFecV", context.localUtil.Format(A560CLCheqDFecV, "99/99/99"));
            A562CLCheqDImpD = T000A3_A562CLCheqDImpD[0];
            AssignAttri("", false, "A562CLCheqDImpD", StringUtil.LTrimStr( A562CLCheqDImpD, 15, 2));
            A150CLCheqDCod = T000A3_A150CLCheqDCod[0];
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            A154CLCheqDTipCod = T000A3_A154CLCheqDTipCod[0];
            AssignAttri("", false, "A154CLCheqDTipCod", A154CLCheqDTipCod);
            A155CLCheqDDocNum = T000A3_A155CLCheqDDocNum[0];
            AssignAttri("", false, "A155CLCheqDDocNum", A155CLCheqDDocNum);
            Z150CLCheqDCod = A150CLCheqDCod;
            Z153CLCheqDItem = A153CLCheqDItem;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
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
         RcdFound10 = 0;
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {A150CLCheqDCod, A153CLCheqDItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000A10_A150CLCheqDCod[0], A150CLCheqDCod) < 0 ) || ( StringUtil.StrCmp(T000A10_A150CLCheqDCod[0], A150CLCheqDCod) == 0 ) && ( T000A10_A153CLCheqDItem[0] < A153CLCheqDItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000A10_A150CLCheqDCod[0], A150CLCheqDCod) > 0 ) || ( StringUtil.StrCmp(T000A10_A150CLCheqDCod[0], A150CLCheqDCod) == 0 ) && ( T000A10_A153CLCheqDItem[0] > A153CLCheqDItem ) ) )
            {
               A150CLCheqDCod = T000A10_A150CLCheqDCod[0];
               AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
               A153CLCheqDItem = T000A10_A153CLCheqDItem[0];
               AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000A11 */
         pr_default.execute(9, new Object[] {A150CLCheqDCod, A153CLCheqDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000A11_A150CLCheqDCod[0], A150CLCheqDCod) > 0 ) || ( StringUtil.StrCmp(T000A11_A150CLCheqDCod[0], A150CLCheqDCod) == 0 ) && ( T000A11_A153CLCheqDItem[0] > A153CLCheqDItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000A11_A150CLCheqDCod[0], A150CLCheqDCod) < 0 ) || ( StringUtil.StrCmp(T000A11_A150CLCheqDCod[0], A150CLCheqDCod) == 0 ) && ( T000A11_A153CLCheqDItem[0] < A153CLCheqDItem ) ) )
            {
               A150CLCheqDCod = T000A11_A150CLCheqDCod[0];
               AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
               A153CLCheqDItem = T000A11_A153CLCheqDItem[0];
               AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A10( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( ( StringUtil.StrCmp(A150CLCheqDCod, Z150CLCheqDCod) != 0 ) || ( A153CLCheqDItem != Z153CLCheqDItem ) )
               {
                  A150CLCheqDCod = Z150CLCheqDCod;
                  AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
                  A153CLCheqDItem = Z153CLCheqDItem;
                  AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLCHEQDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A10( ) ;
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A150CLCheqDCod, Z150CLCheqDCod) != 0 ) || ( A153CLCheqDItem != Z153CLCheqDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCLCheqDCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A10( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLCHEQDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCLCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCLCheqDCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A10( ) ;
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
         if ( ( StringUtil.StrCmp(A150CLCheqDCod, Z150CLCheqDCod) != 0 ) || ( A153CLCheqDItem != Z153CLCheqDItem ) )
         {
            A150CLCheqDCod = Z150CLCheqDCod;
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            A153CLCheqDItem = Z153CLCheqDItem;
            AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCLCheqDCod_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCLCheqDTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A10( ) ;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDTipo_Internalname;
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
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDTipo_Internalname;
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
         ScanStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound10 != 0 )
            {
               ScanNext0A10( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLCheqDTipo_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A10( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A150CLCheqDCod, A153CLCheqDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCHEQUEDIFERIDODET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z567CLCheqDTipo, T000A2_A567CLCheqDTipo[0]) != 0 ) || ( Z557CLCheqDDias != T000A2_A557CLCheqDDias[0] ) || ( DateTimeUtil.ResetTime ( Z559CLCheqDFecD ) != DateTimeUtil.ResetTime ( T000A2_A559CLCheqDFecD[0] ) ) || ( DateTimeUtil.ResetTime ( Z560CLCheqDFecV ) != DateTimeUtil.ResetTime ( T000A2_A560CLCheqDFecV[0] ) ) || ( Z562CLCheqDImpD != T000A2_A562CLCheqDImpD[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z154CLCheqDTipCod, T000A2_A154CLCheqDTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z155CLCheqDDocNum, T000A2_A155CLCheqDDocNum[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z567CLCheqDTipo, T000A2_A567CLCheqDTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("clchequediferidodet:[seudo value changed for attri]"+"CLCheqDTipo");
                  GXUtil.WriteLogRaw("Old: ",Z567CLCheqDTipo);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A567CLCheqDTipo[0]);
               }
               if ( Z557CLCheqDDias != T000A2_A557CLCheqDDias[0] )
               {
                  GXUtil.WriteLog("clchequediferidodet:[seudo value changed for attri]"+"CLCheqDDias");
                  GXUtil.WriteLogRaw("Old: ",Z557CLCheqDDias);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A557CLCheqDDias[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z559CLCheqDFecD ) != DateTimeUtil.ResetTime ( T000A2_A559CLCheqDFecD[0] ) )
               {
                  GXUtil.WriteLog("clchequediferidodet:[seudo value changed for attri]"+"CLCheqDFecD");
                  GXUtil.WriteLogRaw("Old: ",Z559CLCheqDFecD);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A559CLCheqDFecD[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z560CLCheqDFecV ) != DateTimeUtil.ResetTime ( T000A2_A560CLCheqDFecV[0] ) )
               {
                  GXUtil.WriteLog("clchequediferidodet:[seudo value changed for attri]"+"CLCheqDFecV");
                  GXUtil.WriteLogRaw("Old: ",Z560CLCheqDFecV);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A560CLCheqDFecV[0]);
               }
               if ( Z562CLCheqDImpD != T000A2_A562CLCheqDImpD[0] )
               {
                  GXUtil.WriteLog("clchequediferidodet:[seudo value changed for attri]"+"CLCheqDImpD");
                  GXUtil.WriteLogRaw("Old: ",Z562CLCheqDImpD);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A562CLCheqDImpD[0]);
               }
               if ( StringUtil.StrCmp(Z154CLCheqDTipCod, T000A2_A154CLCheqDTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clchequediferidodet:[seudo value changed for attri]"+"CLCheqDTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z154CLCheqDTipCod);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A154CLCheqDTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z155CLCheqDDocNum, T000A2_A155CLCheqDDocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("clchequediferidodet:[seudo value changed for attri]"+"CLCheqDDocNum");
                  GXUtil.WriteLogRaw("Old: ",Z155CLCheqDDocNum);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A155CLCheqDDocNum[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCHEQUEDIFERIDODET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A12 */
                     pr_default.execute(10, new Object[] {A153CLCheqDItem, A567CLCheqDTipo, A557CLCheqDDias, A559CLCheqDFecD, A560CLCheqDFecV, A562CLCheqDImpD, A150CLCheqDCod, A154CLCheqDTipCod, A155CLCheqDDocNum});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCHEQUEDIFERIDODET");
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
                           ResetCaption0A0( ) ;
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
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A13 */
                     pr_default.execute(11, new Object[] {A567CLCheqDTipo, A557CLCheqDDias, A559CLCheqDFecD, A560CLCheqDFecV, A562CLCheqDImpD, A154CLCheqDTipCod, A155CLCheqDDocNum, A150CLCheqDCod, A153CLCheqDItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCHEQUEDIFERIDODET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCHEQUEDIFERIDODET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A14 */
                  pr_default.execute(12, new Object[] {A150CLCheqDCod, A153CLCheqDItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCHEQUEDIFERIDODET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound10 == 0 )
                        {
                           InitAll0A10( ) ;
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
                        ResetCaption0A0( ) ;
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clchequediferidodet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clchequediferidodet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A10( )
      {
         /* Using cursor T000A15 */
         pr_default.execute(13);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A150CLCheqDCod = T000A15_A150CLCheqDCod[0];
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            A153CLCheqDItem = T000A15_A153CLCheqDItem[0];
            AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound10 = 1;
            A150CLCheqDCod = T000A15_A150CLCheqDCod[0];
            AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
            A153CLCheqDItem = T000A15_A153CLCheqDItem[0];
            AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
         }
      }

      protected void ScanEnd0A10( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
         edtCLCheqDCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDCod_Enabled), 5, 0), true);
         edtCLCheqDItem_Enabled = 0;
         AssignProp("", false, edtCLCheqDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDItem_Enabled), 5, 0), true);
         edtCLCheqDTipo_Enabled = 0;
         AssignProp("", false, edtCLCheqDTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDTipo_Enabled), 5, 0), true);
         edtCLCheqDTipCod_Enabled = 0;
         AssignProp("", false, edtCLCheqDTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDTipCod_Enabled), 5, 0), true);
         edtCLCheqDDocNum_Enabled = 0;
         AssignProp("", false, edtCLCheqDDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDDocNum_Enabled), 5, 0), true);
         edtCLCheqDDias_Enabled = 0;
         AssignProp("", false, edtCLCheqDDias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDDias_Enabled), 5, 0), true);
         edtCLCheqDFecD_Enabled = 0;
         AssignProp("", false, edtCLCheqDFecD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDFecD_Enabled), 5, 0), true);
         edtCLCheqDFecV_Enabled = 0;
         AssignProp("", false, edtCLCheqDFecV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDFecV_Enabled), 5, 0), true);
         edtCLCheqDImpD_Enabled = 0;
         AssignProp("", false, edtCLCheqDImpD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLCheqDImpD_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816421462", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clchequediferidodet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z150CLCheqDCod", StringUtil.RTrim( Z150CLCheqDCod));
         GxWebStd.gx_hidden_field( context, "Z153CLCheqDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z153CLCheqDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z567CLCheqDTipo", StringUtil.RTrim( Z567CLCheqDTipo));
         GxWebStd.gx_hidden_field( context, "Z557CLCheqDDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z557CLCheqDDias), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z559CLCheqDFecD", context.localUtil.DToC( Z559CLCheqDFecD, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z560CLCheqDFecV", context.localUtil.DToC( Z560CLCheqDFecV, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z562CLCheqDImpD", StringUtil.LTrim( StringUtil.NToC( Z562CLCheqDImpD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z154CLCheqDTipCod", StringUtil.RTrim( Z154CLCheqDTipCod));
         GxWebStd.gx_hidden_field( context, "Z155CLCheqDDocNum", StringUtil.RTrim( Z155CLCheqDDocNum));
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
         return formatLink("clchequediferidodet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCHEQUEDIFERIDODET" ;
      }

      public override string GetPgmdesc( )
      {
         return "CLCHEQDIFERIDODET" ;
      }

      protected void InitializeNonKey0A10( )
      {
         A567CLCheqDTipo = "";
         AssignAttri("", false, "A567CLCheqDTipo", A567CLCheqDTipo);
         A154CLCheqDTipCod = "";
         AssignAttri("", false, "A154CLCheqDTipCod", A154CLCheqDTipCod);
         A155CLCheqDDocNum = "";
         AssignAttri("", false, "A155CLCheqDDocNum", A155CLCheqDDocNum);
         A557CLCheqDDias = 0;
         AssignAttri("", false, "A557CLCheqDDias", StringUtil.LTrimStr( (decimal)(A557CLCheqDDias), 6, 0));
         A559CLCheqDFecD = DateTime.MinValue;
         AssignAttri("", false, "A559CLCheqDFecD", context.localUtil.Format(A559CLCheqDFecD, "99/99/99"));
         A560CLCheqDFecV = DateTime.MinValue;
         AssignAttri("", false, "A560CLCheqDFecV", context.localUtil.Format(A560CLCheqDFecV, "99/99/99"));
         A562CLCheqDImpD = 0;
         AssignAttri("", false, "A562CLCheqDImpD", StringUtil.LTrimStr( A562CLCheqDImpD, 15, 2));
         Z567CLCheqDTipo = "";
         Z557CLCheqDDias = 0;
         Z559CLCheqDFecD = DateTime.MinValue;
         Z560CLCheqDFecV = DateTime.MinValue;
         Z562CLCheqDImpD = 0;
         Z154CLCheqDTipCod = "";
         Z155CLCheqDDocNum = "";
      }

      protected void InitAll0A10( )
      {
         A150CLCheqDCod = "";
         AssignAttri("", false, "A150CLCheqDCod", A150CLCheqDCod);
         A153CLCheqDItem = 0;
         AssignAttri("", false, "A153CLCheqDItem", StringUtil.LTrimStr( (decimal)(A153CLCheqDItem), 6, 0));
         InitializeNonKey0A10( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816421472", true, true);
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
         context.AddJavascriptSource("clchequediferidodet.js", "?202281816421472", false, true);
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
         edtCLCheqDCod_Internalname = "CLCHEQDCOD";
         edtCLCheqDItem_Internalname = "CLCHEQDITEM";
         edtCLCheqDTipo_Internalname = "CLCHEQDTIPO";
         edtCLCheqDTipCod_Internalname = "CLCHEQDTIPCOD";
         edtCLCheqDDocNum_Internalname = "CLCHEQDDOCNUM";
         edtCLCheqDDias_Internalname = "CLCHEQDDIAS";
         edtCLCheqDFecD_Internalname = "CLCHEQDFECD";
         edtCLCheqDFecV_Internalname = "CLCHEQDFECV";
         edtCLCheqDImpD_Internalname = "CLCHEQDIMPD";
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
         Form.Caption = "CLCHEQDIFERIDODET";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCLCheqDImpD_Jsonclick = "";
         edtCLCheqDImpD_Enabled = 1;
         edtCLCheqDFecV_Jsonclick = "";
         edtCLCheqDFecV_Enabled = 1;
         edtCLCheqDFecD_Jsonclick = "";
         edtCLCheqDFecD_Enabled = 1;
         edtCLCheqDDias_Jsonclick = "";
         edtCLCheqDDias_Enabled = 1;
         edtCLCheqDDocNum_Jsonclick = "";
         edtCLCheqDDocNum_Enabled = 1;
         edtCLCheqDTipCod_Jsonclick = "";
         edtCLCheqDTipCod_Enabled = 1;
         edtCLCheqDTipo_Jsonclick = "";
         edtCLCheqDTipo_Enabled = 1;
         edtCLCheqDItem_Jsonclick = "";
         edtCLCheqDItem_Enabled = 1;
         edtCLCheqDCod_Jsonclick = "";
         edtCLCheqDCod_Enabled = 1;
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
         /* Using cursor T000A16 */
         pr_default.execute(14, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'CLCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtCLCheqDTipo_Internalname;
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

      public void Valid_Clcheqdcod( )
      {
         /* Using cursor T000A16 */
         pr_default.execute(14, new Object[] {A150CLCheqDCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'CLCHEQUEDIFERIDO'.", "ForeignKeyNotFound", 1, "CLCHEQDCOD");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clcheqditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A567CLCheqDTipo", StringUtil.RTrim( A567CLCheqDTipo));
         AssignAttri("", false, "A154CLCheqDTipCod", StringUtil.RTrim( A154CLCheqDTipCod));
         AssignAttri("", false, "A155CLCheqDDocNum", StringUtil.RTrim( A155CLCheqDDocNum));
         AssignAttri("", false, "A557CLCheqDDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A557CLCheqDDias), 6, 0, ".", "")));
         AssignAttri("", false, "A559CLCheqDFecD", context.localUtil.Format(A559CLCheqDFecD, "99/99/99"));
         AssignAttri("", false, "A560CLCheqDFecV", context.localUtil.Format(A560CLCheqDFecV, "99/99/99"));
         AssignAttri("", false, "A562CLCheqDImpD", StringUtil.LTrim( StringUtil.NToC( A562CLCheqDImpD, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z150CLCheqDCod", StringUtil.RTrim( Z150CLCheqDCod));
         GxWebStd.gx_hidden_field( context, "Z153CLCheqDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z153CLCheqDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z567CLCheqDTipo", StringUtil.RTrim( Z567CLCheqDTipo));
         GxWebStd.gx_hidden_field( context, "Z154CLCheqDTipCod", StringUtil.RTrim( Z154CLCheqDTipCod));
         GxWebStd.gx_hidden_field( context, "Z155CLCheqDDocNum", StringUtil.RTrim( Z155CLCheqDDocNum));
         GxWebStd.gx_hidden_field( context, "Z557CLCheqDDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z557CLCheqDDias), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z559CLCheqDFecD", context.localUtil.Format(Z559CLCheqDFecD, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z560CLCheqDFecV", context.localUtil.Format(Z560CLCheqDFecV, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z562CLCheqDImpD", StringUtil.LTrim( StringUtil.NToC( Z562CLCheqDImpD, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clcheqddocnum( )
      {
         /* Using cursor T000A17 */
         pr_default.execute(15, new Object[] {A154CLCheqDTipCod, A155CLCheqDDocNum});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Cheques Diferidos Cliente Documento'.", "ForeignKeyNotFound", 1, "CLCHEQDDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCLCheqDTipCod_Internalname;
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
         setEventMetadata("VALID_CLCHEQDCOD","{handler:'Valid_Clcheqdcod',iparms:[{av:'A150CLCheqDCod',fld:'CLCHEQDCOD',pic:''}]");
         setEventMetadata("VALID_CLCHEQDCOD",",oparms:[]}");
         setEventMetadata("VALID_CLCHEQDITEM","{handler:'Valid_Clcheqditem',iparms:[{av:'A150CLCheqDCod',fld:'CLCHEQDCOD',pic:''},{av:'A153CLCheqDItem',fld:'CLCHEQDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLCHEQDITEM",",oparms:[{av:'A567CLCheqDTipo',fld:'CLCHEQDTIPO',pic:''},{av:'A154CLCheqDTipCod',fld:'CLCHEQDTIPCOD',pic:''},{av:'A155CLCheqDDocNum',fld:'CLCHEQDDOCNUM',pic:''},{av:'A557CLCheqDDias',fld:'CLCHEQDDIAS',pic:'ZZZZZ9'},{av:'A559CLCheqDFecD',fld:'CLCHEQDFECD',pic:''},{av:'A560CLCheqDFecV',fld:'CLCHEQDFECV',pic:''},{av:'A562CLCheqDImpD',fld:'CLCHEQDIMPD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z150CLCheqDCod'},{av:'Z153CLCheqDItem'},{av:'Z567CLCheqDTipo'},{av:'Z154CLCheqDTipCod'},{av:'Z155CLCheqDDocNum'},{av:'Z557CLCheqDDias'},{av:'Z559CLCheqDFecD'},{av:'Z560CLCheqDFecV'},{av:'Z562CLCheqDImpD'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLCHEQDTIPCOD","{handler:'Valid_Clcheqdtipcod',iparms:[]");
         setEventMetadata("VALID_CLCHEQDTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_CLCHEQDDOCNUM","{handler:'Valid_Clcheqddocnum',iparms:[{av:'A154CLCheqDTipCod',fld:'CLCHEQDTIPCOD',pic:''},{av:'A155CLCheqDDocNum',fld:'CLCHEQDDOCNUM',pic:''}]");
         setEventMetadata("VALID_CLCHEQDDOCNUM",",oparms:[]}");
         setEventMetadata("VALID_CLCHEQDFECD","{handler:'Valid_Clcheqdfecd',iparms:[]");
         setEventMetadata("VALID_CLCHEQDFECD",",oparms:[]}");
         setEventMetadata("VALID_CLCHEQDFECV","{handler:'Valid_Clcheqdfecv',iparms:[]");
         setEventMetadata("VALID_CLCHEQDFECV",",oparms:[]}");
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
         Z150CLCheqDCod = "";
         Z567CLCheqDTipo = "";
         Z559CLCheqDFecD = DateTime.MinValue;
         Z560CLCheqDFecV = DateTime.MinValue;
         Z154CLCheqDTipCod = "";
         Z155CLCheqDDocNum = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A150CLCheqDCod = "";
         A154CLCheqDTipCod = "";
         A155CLCheqDDocNum = "";
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
         A567CLCheqDTipo = "";
         A559CLCheqDFecD = DateTime.MinValue;
         A560CLCheqDFecV = DateTime.MinValue;
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
         T000A6_A153CLCheqDItem = new int[1] ;
         T000A6_A567CLCheqDTipo = new string[] {""} ;
         T000A6_A557CLCheqDDias = new int[1] ;
         T000A6_A559CLCheqDFecD = new DateTime[] {DateTime.MinValue} ;
         T000A6_A560CLCheqDFecV = new DateTime[] {DateTime.MinValue} ;
         T000A6_A562CLCheqDImpD = new decimal[1] ;
         T000A6_A150CLCheqDCod = new string[] {""} ;
         T000A6_A154CLCheqDTipCod = new string[] {""} ;
         T000A6_A155CLCheqDDocNum = new string[] {""} ;
         T000A4_A150CLCheqDCod = new string[] {""} ;
         T000A5_A154CLCheqDTipCod = new string[] {""} ;
         T000A7_A150CLCheqDCod = new string[] {""} ;
         T000A8_A154CLCheqDTipCod = new string[] {""} ;
         T000A9_A150CLCheqDCod = new string[] {""} ;
         T000A9_A153CLCheqDItem = new int[1] ;
         T000A3_A153CLCheqDItem = new int[1] ;
         T000A3_A567CLCheqDTipo = new string[] {""} ;
         T000A3_A557CLCheqDDias = new int[1] ;
         T000A3_A559CLCheqDFecD = new DateTime[] {DateTime.MinValue} ;
         T000A3_A560CLCheqDFecV = new DateTime[] {DateTime.MinValue} ;
         T000A3_A562CLCheqDImpD = new decimal[1] ;
         T000A3_A150CLCheqDCod = new string[] {""} ;
         T000A3_A154CLCheqDTipCod = new string[] {""} ;
         T000A3_A155CLCheqDDocNum = new string[] {""} ;
         sMode10 = "";
         T000A10_A150CLCheqDCod = new string[] {""} ;
         T000A10_A153CLCheqDItem = new int[1] ;
         T000A11_A150CLCheqDCod = new string[] {""} ;
         T000A11_A153CLCheqDItem = new int[1] ;
         T000A2_A153CLCheqDItem = new int[1] ;
         T000A2_A567CLCheqDTipo = new string[] {""} ;
         T000A2_A557CLCheqDDias = new int[1] ;
         T000A2_A559CLCheqDFecD = new DateTime[] {DateTime.MinValue} ;
         T000A2_A560CLCheqDFecV = new DateTime[] {DateTime.MinValue} ;
         T000A2_A562CLCheqDImpD = new decimal[1] ;
         T000A2_A150CLCheqDCod = new string[] {""} ;
         T000A2_A154CLCheqDTipCod = new string[] {""} ;
         T000A2_A155CLCheqDDocNum = new string[] {""} ;
         T000A15_A150CLCheqDCod = new string[] {""} ;
         T000A15_A153CLCheqDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000A16_A150CLCheqDCod = new string[] {""} ;
         ZZ150CLCheqDCod = "";
         ZZ567CLCheqDTipo = "";
         ZZ154CLCheqDTipCod = "";
         ZZ155CLCheqDDocNum = "";
         ZZ559CLCheqDFecD = DateTime.MinValue;
         ZZ560CLCheqDFecV = DateTime.MinValue;
         T000A17_A154CLCheqDTipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clchequediferidodet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clchequediferidodet__default(),
            new Object[][] {
                new Object[] {
               T000A2_A153CLCheqDItem, T000A2_A567CLCheqDTipo, T000A2_A557CLCheqDDias, T000A2_A559CLCheqDFecD, T000A2_A560CLCheqDFecV, T000A2_A562CLCheqDImpD, T000A2_A150CLCheqDCod, T000A2_A154CLCheqDTipCod, T000A2_A155CLCheqDDocNum
               }
               , new Object[] {
               T000A3_A153CLCheqDItem, T000A3_A567CLCheqDTipo, T000A3_A557CLCheqDDias, T000A3_A559CLCheqDFecD, T000A3_A560CLCheqDFecV, T000A3_A562CLCheqDImpD, T000A3_A150CLCheqDCod, T000A3_A154CLCheqDTipCod, T000A3_A155CLCheqDDocNum
               }
               , new Object[] {
               T000A4_A150CLCheqDCod
               }
               , new Object[] {
               T000A5_A154CLCheqDTipCod
               }
               , new Object[] {
               T000A6_A153CLCheqDItem, T000A6_A567CLCheqDTipo, T000A6_A557CLCheqDDias, T000A6_A559CLCheqDFecD, T000A6_A560CLCheqDFecV, T000A6_A562CLCheqDImpD, T000A6_A150CLCheqDCod, T000A6_A154CLCheqDTipCod, T000A6_A155CLCheqDDocNum
               }
               , new Object[] {
               T000A7_A150CLCheqDCod
               }
               , new Object[] {
               T000A8_A154CLCheqDTipCod
               }
               , new Object[] {
               T000A9_A150CLCheqDCod, T000A9_A153CLCheqDItem
               }
               , new Object[] {
               T000A10_A150CLCheqDCod, T000A10_A153CLCheqDItem
               }
               , new Object[] {
               T000A11_A150CLCheqDCod, T000A11_A153CLCheqDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A15_A150CLCheqDCod, T000A15_A153CLCheqDItem
               }
               , new Object[] {
               T000A16_A150CLCheqDCod
               }
               , new Object[] {
               T000A17_A154CLCheqDTipCod
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
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z153CLCheqDItem ;
      private int Z557CLCheqDDias ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCLCheqDCod_Enabled ;
      private int A153CLCheqDItem ;
      private int edtCLCheqDItem_Enabled ;
      private int edtCLCheqDTipo_Enabled ;
      private int edtCLCheqDTipCod_Enabled ;
      private int edtCLCheqDDocNum_Enabled ;
      private int A557CLCheqDDias ;
      private int edtCLCheqDDias_Enabled ;
      private int edtCLCheqDFecD_Enabled ;
      private int edtCLCheqDFecV_Enabled ;
      private int edtCLCheqDImpD_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ153CLCheqDItem ;
      private int ZZ557CLCheqDDias ;
      private decimal Z562CLCheqDImpD ;
      private decimal A562CLCheqDImpD ;
      private decimal ZZ562CLCheqDImpD ;
      private string sPrefix ;
      private string Z150CLCheqDCod ;
      private string Z567CLCheqDTipo ;
      private string Z154CLCheqDTipCod ;
      private string Z155CLCheqDDocNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A150CLCheqDCod ;
      private string A154CLCheqDTipCod ;
      private string A155CLCheqDDocNum ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCLCheqDCod_Internalname ;
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
      private string edtCLCheqDCod_Jsonclick ;
      private string edtCLCheqDItem_Internalname ;
      private string edtCLCheqDItem_Jsonclick ;
      private string edtCLCheqDTipo_Internalname ;
      private string A567CLCheqDTipo ;
      private string edtCLCheqDTipo_Jsonclick ;
      private string edtCLCheqDTipCod_Internalname ;
      private string edtCLCheqDTipCod_Jsonclick ;
      private string edtCLCheqDDocNum_Internalname ;
      private string edtCLCheqDDocNum_Jsonclick ;
      private string edtCLCheqDDias_Internalname ;
      private string edtCLCheqDDias_Jsonclick ;
      private string edtCLCheqDFecD_Internalname ;
      private string edtCLCheqDFecD_Jsonclick ;
      private string edtCLCheqDFecV_Internalname ;
      private string edtCLCheqDFecV_Jsonclick ;
      private string edtCLCheqDImpD_Internalname ;
      private string edtCLCheqDImpD_Jsonclick ;
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
      private string sMode10 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ150CLCheqDCod ;
      private string ZZ567CLCheqDTipo ;
      private string ZZ154CLCheqDTipCod ;
      private string ZZ155CLCheqDDocNum ;
      private DateTime Z559CLCheqDFecD ;
      private DateTime Z560CLCheqDFecV ;
      private DateTime A559CLCheqDFecD ;
      private DateTime A560CLCheqDFecV ;
      private DateTime ZZ559CLCheqDFecD ;
      private DateTime ZZ560CLCheqDFecV ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000A6_A153CLCheqDItem ;
      private string[] T000A6_A567CLCheqDTipo ;
      private int[] T000A6_A557CLCheqDDias ;
      private DateTime[] T000A6_A559CLCheqDFecD ;
      private DateTime[] T000A6_A560CLCheqDFecV ;
      private decimal[] T000A6_A562CLCheqDImpD ;
      private string[] T000A6_A150CLCheqDCod ;
      private string[] T000A6_A154CLCheqDTipCod ;
      private string[] T000A6_A155CLCheqDDocNum ;
      private string[] T000A4_A150CLCheqDCod ;
      private string[] T000A5_A154CLCheqDTipCod ;
      private string[] T000A7_A150CLCheqDCod ;
      private string[] T000A8_A154CLCheqDTipCod ;
      private string[] T000A9_A150CLCheqDCod ;
      private int[] T000A9_A153CLCheqDItem ;
      private int[] T000A3_A153CLCheqDItem ;
      private string[] T000A3_A567CLCheqDTipo ;
      private int[] T000A3_A557CLCheqDDias ;
      private DateTime[] T000A3_A559CLCheqDFecD ;
      private DateTime[] T000A3_A560CLCheqDFecV ;
      private decimal[] T000A3_A562CLCheqDImpD ;
      private string[] T000A3_A150CLCheqDCod ;
      private string[] T000A3_A154CLCheqDTipCod ;
      private string[] T000A3_A155CLCheqDDocNum ;
      private string[] T000A10_A150CLCheqDCod ;
      private int[] T000A10_A153CLCheqDItem ;
      private string[] T000A11_A150CLCheqDCod ;
      private int[] T000A11_A153CLCheqDItem ;
      private int[] T000A2_A153CLCheqDItem ;
      private string[] T000A2_A567CLCheqDTipo ;
      private int[] T000A2_A557CLCheqDDias ;
      private DateTime[] T000A2_A559CLCheqDFecD ;
      private DateTime[] T000A2_A560CLCheqDFecV ;
      private decimal[] T000A2_A562CLCheqDImpD ;
      private string[] T000A2_A150CLCheqDCod ;
      private string[] T000A2_A154CLCheqDTipCod ;
      private string[] T000A2_A155CLCheqDDocNum ;
      private string[] T000A15_A150CLCheqDCod ;
      private int[] T000A15_A153CLCheqDItem ;
      private string[] T000A16_A150CLCheqDCod ;
      private string[] T000A17_A154CLCheqDTipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clchequediferidodet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clchequediferidodet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000A6;
        prmT000A6 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A4;
        prmT000A4 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000A5;
        prmT000A5 = new Object[] {
        new ParDef("@CLCheqDTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLCheqDDocNum",GXType.NChar,12,0)
        };
        Object[] prmT000A7;
        prmT000A7 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000A8;
        prmT000A8 = new Object[] {
        new ParDef("@CLCheqDTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLCheqDDocNum",GXType.NChar,12,0)
        };
        Object[] prmT000A9;
        prmT000A9 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A3;
        prmT000A3 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A10;
        prmT000A10 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A11;
        prmT000A11 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A2;
        prmT000A2 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A12;
        prmT000A12 = new Object[] {
        new ParDef("@CLCheqDItem",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDTipo",GXType.NChar,1,0) ,
        new ParDef("@CLCheqDDias",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDFecD",GXType.Date,8,0) ,
        new ParDef("@CLCheqDFecV",GXType.Date,8,0) ,
        new ParDef("@CLCheqDImpD",GXType.Decimal,15,2) ,
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLCheqDDocNum",GXType.NChar,12,0)
        };
        Object[] prmT000A13;
        prmT000A13 = new Object[] {
        new ParDef("@CLCheqDTipo",GXType.NChar,1,0) ,
        new ParDef("@CLCheqDDias",GXType.Int32,6,0) ,
        new ParDef("@CLCheqDFecD",GXType.Date,8,0) ,
        new ParDef("@CLCheqDFecV",GXType.Date,8,0) ,
        new ParDef("@CLCheqDImpD",GXType.Decimal,15,2) ,
        new ParDef("@CLCheqDTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLCheqDDocNum",GXType.NChar,12,0) ,
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A14;
        prmT000A14 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0) ,
        new ParDef("@CLCheqDItem",GXType.Int32,6,0)
        };
        Object[] prmT000A15;
        prmT000A15 = new Object[] {
        };
        Object[] prmT000A16;
        prmT000A16 = new Object[] {
        new ParDef("@CLCheqDCod",GXType.NChar,10,0)
        };
        Object[] prmT000A17;
        prmT000A17 = new Object[] {
        new ParDef("@CLCheqDTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLCheqDDocNum",GXType.NChar,12,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000A2", "SELECT [CLCheqDItem], [CLCheqDTipo], [CLCheqDDias], [CLCheqDFecD], [CLCheqDFecV], [CLCheqDImpD], [CLCheqDCod], [CLCheqDTipCod] AS CLCheqDTipCod, [CLCheqDDocNum] AS CLCheqDDocNum FROM [CLCHEQUEDIFERIDODET] WITH (UPDLOCK) WHERE [CLCheqDCod] = @CLCheqDCod AND [CLCheqDItem] = @CLCheqDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A3", "SELECT [CLCheqDItem], [CLCheqDTipo], [CLCheqDDias], [CLCheqDFecD], [CLCheqDFecV], [CLCheqDImpD], [CLCheqDCod], [CLCheqDTipCod] AS CLCheqDTipCod, [CLCheqDDocNum] AS CLCheqDDocNum FROM [CLCHEQUEDIFERIDODET] WHERE [CLCheqDCod] = @CLCheqDCod AND [CLCheqDItem] = @CLCheqDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A4", "SELECT [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDCod] = @CLCheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A5", "SELECT [CCTipCod] AS CLCheqDTipCod FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CLCheqDTipCod AND [CCDocNum] = @CLCheqDDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A6", "SELECT TM1.[CLCheqDItem], TM1.[CLCheqDTipo], TM1.[CLCheqDDias], TM1.[CLCheqDFecD], TM1.[CLCheqDFecV], TM1.[CLCheqDImpD], TM1.[CLCheqDCod], TM1.[CLCheqDTipCod] AS CLCheqDTipCod, TM1.[CLCheqDDocNum] AS CLCheqDDocNum FROM [CLCHEQUEDIFERIDODET] TM1 WHERE TM1.[CLCheqDCod] = @CLCheqDCod and TM1.[CLCheqDItem] = @CLCheqDItem ORDER BY TM1.[CLCheqDCod], TM1.[CLCheqDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A7", "SELECT [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDCod] = @CLCheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A8", "SELECT [CCTipCod] AS CLCheqDTipCod FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CLCheqDTipCod AND [CCDocNum] = @CLCheqDDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A9", "SELECT [CLCheqDCod], [CLCheqDItem] FROM [CLCHEQUEDIFERIDODET] WHERE [CLCheqDCod] = @CLCheqDCod AND [CLCheqDItem] = @CLCheqDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A10", "SELECT TOP 1 [CLCheqDCod], [CLCheqDItem] FROM [CLCHEQUEDIFERIDODET] WHERE ( [CLCheqDCod] > @CLCheqDCod or [CLCheqDCod] = @CLCheqDCod and [CLCheqDItem] > @CLCheqDItem) ORDER BY [CLCheqDCod], [CLCheqDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A11", "SELECT TOP 1 [CLCheqDCod], [CLCheqDItem] FROM [CLCHEQUEDIFERIDODET] WHERE ( [CLCheqDCod] < @CLCheqDCod or [CLCheqDCod] = @CLCheqDCod and [CLCheqDItem] < @CLCheqDItem) ORDER BY [CLCheqDCod] DESC, [CLCheqDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A12", "INSERT INTO [CLCHEQUEDIFERIDODET]([CLCheqDItem], [CLCheqDTipo], [CLCheqDDias], [CLCheqDFecD], [CLCheqDFecV], [CLCheqDImpD], [CLCheqDCod], [CLCheqDTipCod], [CLCheqDDocNum]) VALUES(@CLCheqDItem, @CLCheqDTipo, @CLCheqDDias, @CLCheqDFecD, @CLCheqDFecV, @CLCheqDImpD, @CLCheqDCod, @CLCheqDTipCod, @CLCheqDDocNum)", GxErrorMask.GX_NOMASK,prmT000A12)
           ,new CursorDef("T000A13", "UPDATE [CLCHEQUEDIFERIDODET] SET [CLCheqDTipo]=@CLCheqDTipo, [CLCheqDDias]=@CLCheqDDias, [CLCheqDFecD]=@CLCheqDFecD, [CLCheqDFecV]=@CLCheqDFecV, [CLCheqDImpD]=@CLCheqDImpD, [CLCheqDTipCod]=@CLCheqDTipCod, [CLCheqDDocNum]=@CLCheqDDocNum  WHERE [CLCheqDCod] = @CLCheqDCod AND [CLCheqDItem] = @CLCheqDItem", GxErrorMask.GX_NOMASK,prmT000A13)
           ,new CursorDef("T000A14", "DELETE FROM [CLCHEQUEDIFERIDODET]  WHERE [CLCheqDCod] = @CLCheqDCod AND [CLCheqDItem] = @CLCheqDItem", GxErrorMask.GX_NOMASK,prmT000A14)
           ,new CursorDef("T000A15", "SELECT [CLCheqDCod], [CLCheqDItem] FROM [CLCHEQUEDIFERIDODET] ORDER BY [CLCheqDCod], [CLCheqDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A16", "SELECT [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDCod] = @CLCheqDCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A17", "SELECT [CCTipCod] AS CLCheqDTipCod FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @CLCheqDTipCod AND [CCDocNum] = @CLCheqDDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 12);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 12);
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
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 10);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((string[]) buf[8])[0] = rslt.getString(9, 12);
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
