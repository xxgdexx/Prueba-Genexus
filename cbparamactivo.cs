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
   public class cbparamactivo : GXDataArea
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
            A83ParTip = GetPar( "ParTip");
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = (int)(NumberUtil.Val( GetPar( "ParCod"), "."));
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A83ParTip, A84ParCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A426ACTClaCod = GetPar( "ACTClaCod");
            n426ACTClaCod = false;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A426ACTClaCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A86ParActCueCod1 = GetPar( "ParActCueCod1");
            AssignAttri("", false, "A86ParActCueCod1", A86ParActCueCod1);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A86ParActCueCod1) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A87ParActCueCod2 = GetPar( "ParActCueCod2");
            AssignAttri("", false, "A87ParActCueCod2", A87ParActCueCod2);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A87ParActCueCod2) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A88ParActCueCod3 = GetPar( "ParActCueCod3");
            n88ParActCueCod3 = false;
            AssignAttri("", false, "A88ParActCueCod3", A88ParActCueCod3);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A88ParActCueCod3) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A89ParActCueCod4 = GetPar( "ParActCueCod4");
            n89ParActCueCod4 = false;
            AssignAttri("", false, "A89ParActCueCod4", A89ParActCueCod4);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A89ParActCueCod4) ;
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
            Form.Meta.addItem("description", "CBPARAMACTIVO", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbparamactivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbparamactivo( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "CBPARAMACTIVO", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CBPARAMACTIVO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPARAMACTIVO.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParTip_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParTip_Internalname, "Tipo de Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParTip_Internalname, StringUtil.RTrim( A83ParTip), StringUtil.RTrim( context.localUtil.Format( A83ParTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParCod_Internalname, "Secuencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84ParCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtParCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParDActItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParDActItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDActItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A85ParDActItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtParDActItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A85ParDActItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A85ParDActItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDActItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTClaCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTClaCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTClaCod_Internalname, A426ACTClaCod, StringUtil.RTrim( context.localUtil.Format( A426ACTClaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTClaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTClaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParActCueCod1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParActCueCod1_Internalname, "Cuenta Debe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParActCueCod1_Internalname, StringUtil.RTrim( A86ParActCueCod1), StringUtil.RTrim( context.localUtil.Format( A86ParActCueCod1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParActCueCod1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParActCueCod1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParActCueCod2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParActCueCod2_Internalname, "Cuenta Haber", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParActCueCod2_Internalname, StringUtil.RTrim( A87ParActCueCod2), StringUtil.RTrim( context.localUtil.Format( A87ParActCueCod2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParActCueCod2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParActCueCod2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParActCueCod3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParActCueCod3_Internalname, "3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParActCueCod3_Internalname, StringUtil.RTrim( A88ParActCueCod3), StringUtil.RTrim( context.localUtil.Format( A88ParActCueCod3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParActCueCod3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParActCueCod3_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParActCueCod4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParActCueCod4_Internalname, "4", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParActCueCod4_Internalname, StringUtil.RTrim( A89ParActCueCod4), StringUtil.RTrim( context.localUtil.Format( A89ParActCueCod4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParActCueCod4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParActCueCod4_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtParActCosCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParActCosCod_Internalname, "de Costo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParActCosCod_Internalname, StringUtil.RTrim( A1502ParActCosCod), StringUtil.RTrim( context.localUtil.Format( A1502ParActCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParActCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParActCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMACTIVO.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMACTIVO.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMACTIVO.htm");
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
            Z83ParTip = cgiGet( "Z83ParTip");
            Z84ParCod = (int)(context.localUtil.CToN( cgiGet( "Z84ParCod"), ".", ","));
            Z85ParDActItem = (int)(context.localUtil.CToN( cgiGet( "Z85ParDActItem"), ".", ","));
            Z1502ParActCosCod = cgiGet( "Z1502ParActCosCod");
            n1502ParActCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1502ParActCosCod)) ? true : false);
            Z426ACTClaCod = cgiGet( "Z426ACTClaCod");
            n426ACTClaCod = (String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ? true : false);
            Z86ParActCueCod1 = cgiGet( "Z86ParActCueCod1");
            Z87ParActCueCod2 = cgiGet( "Z87ParActCueCod2");
            Z88ParActCueCod3 = cgiGet( "Z88ParActCueCod3");
            n88ParActCueCod3 = (String.IsNullOrEmpty(StringUtil.RTrim( A88ParActCueCod3)) ? true : false);
            Z89ParActCueCod4 = cgiGet( "Z89ParActCueCod4");
            n89ParActCueCod4 = (String.IsNullOrEmpty(StringUtil.RTrim( A89ParActCueCod4)) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A83ParTip = cgiGet( edtParTip_Internalname);
            AssignAttri("", false, "A83ParTip", A83ParTip);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARCOD");
               AnyError = 1;
               GX_FocusControl = edtParCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A84ParCod = 0;
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            }
            else
            {
               A84ParCod = (int)(context.localUtil.CToN( cgiGet( edtParCod_Internalname), ".", ","));
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDActItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDActItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDACTITEM");
               AnyError = 1;
               GX_FocusControl = edtParDActItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A85ParDActItem = 0;
               AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
            }
            else
            {
               A85ParDActItem = (int)(context.localUtil.CToN( cgiGet( edtParDActItem_Internalname), ".", ","));
               AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
            }
            A426ACTClaCod = cgiGet( edtACTClaCod_Internalname);
            n426ACTClaCod = false;
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            n426ACTClaCod = (String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ? true : false);
            A86ParActCueCod1 = cgiGet( edtParActCueCod1_Internalname);
            AssignAttri("", false, "A86ParActCueCod1", A86ParActCueCod1);
            A87ParActCueCod2 = cgiGet( edtParActCueCod2_Internalname);
            AssignAttri("", false, "A87ParActCueCod2", A87ParActCueCod2);
            A88ParActCueCod3 = cgiGet( edtParActCueCod3_Internalname);
            n88ParActCueCod3 = false;
            AssignAttri("", false, "A88ParActCueCod3", A88ParActCueCod3);
            n88ParActCueCod3 = (String.IsNullOrEmpty(StringUtil.RTrim( A88ParActCueCod3)) ? true : false);
            A89ParActCueCod4 = cgiGet( edtParActCueCod4_Internalname);
            n89ParActCueCod4 = false;
            AssignAttri("", false, "A89ParActCueCod4", A89ParActCueCod4);
            n89ParActCueCod4 = (String.IsNullOrEmpty(StringUtil.RTrim( A89ParActCueCod4)) ? true : false);
            A1502ParActCosCod = cgiGet( edtParActCosCod_Internalname);
            n1502ParActCosCod = false;
            AssignAttri("", false, "A1502ParActCosCod", A1502ParActCosCod);
            n1502ParActCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1502ParActCosCod)) ? true : false);
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
               A83ParTip = GetPar( "ParTip");
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = (int)(NumberUtil.Val( GetPar( "ParCod"), "."));
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A85ParDActItem = (int)(NumberUtil.Val( GetPar( "ParDActItem"), "."));
               AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
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
               InitAll1R60( ) ;
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
         DisableAttributes1R60( ) ;
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

      protected void ResetCaption1R0( )
      {
      }

      protected void ZM1R60( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1502ParActCosCod = T001R3_A1502ParActCosCod[0];
               Z426ACTClaCod = T001R3_A426ACTClaCod[0];
               Z86ParActCueCod1 = T001R3_A86ParActCueCod1[0];
               Z87ParActCueCod2 = T001R3_A87ParActCueCod2[0];
               Z88ParActCueCod3 = T001R3_A88ParActCueCod3[0];
               Z89ParActCueCod4 = T001R3_A89ParActCueCod4[0];
            }
            else
            {
               Z1502ParActCosCod = A1502ParActCosCod;
               Z426ACTClaCod = A426ACTClaCod;
               Z86ParActCueCod1 = A86ParActCueCod1;
               Z87ParActCueCod2 = A87ParActCueCod2;
               Z88ParActCueCod3 = A88ParActCueCod3;
               Z89ParActCueCod4 = A89ParActCueCod4;
            }
         }
         if ( GX_JID == -1 )
         {
            Z85ParDActItem = A85ParDActItem;
            Z1502ParActCosCod = A1502ParActCosCod;
            Z83ParTip = A83ParTip;
            Z84ParCod = A84ParCod;
            Z426ACTClaCod = A426ACTClaCod;
            Z86ParActCueCod1 = A86ParActCueCod1;
            Z87ParActCueCod2 = A87ParActCueCod2;
            Z88ParActCueCod3 = A88ParActCueCod3;
            Z89ParActCueCod4 = A89ParActCueCod4;
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

      protected void Load1R60( )
      {
         /* Using cursor T001R10 */
         pr_default.execute(8, new Object[] {A83ParTip, A84ParCod, A85ParDActItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound60 = 1;
            A1502ParActCosCod = T001R10_A1502ParActCosCod[0];
            n1502ParActCosCod = T001R10_n1502ParActCosCod[0];
            AssignAttri("", false, "A1502ParActCosCod", A1502ParActCosCod);
            A426ACTClaCod = T001R10_A426ACTClaCod[0];
            n426ACTClaCod = T001R10_n426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A86ParActCueCod1 = T001R10_A86ParActCueCod1[0];
            AssignAttri("", false, "A86ParActCueCod1", A86ParActCueCod1);
            A87ParActCueCod2 = T001R10_A87ParActCueCod2[0];
            AssignAttri("", false, "A87ParActCueCod2", A87ParActCueCod2);
            A88ParActCueCod3 = T001R10_A88ParActCueCod3[0];
            n88ParActCueCod3 = T001R10_n88ParActCueCod3[0];
            AssignAttri("", false, "A88ParActCueCod3", A88ParActCueCod3);
            A89ParActCueCod4 = T001R10_A89ParActCueCod4[0];
            n89ParActCueCod4 = T001R10_n89ParActCueCod4[0];
            AssignAttri("", false, "A89ParActCueCod4", A89ParActCueCod4);
            ZM1R60( -1) ;
         }
         pr_default.close(8);
         OnLoadActions1R60( ) ;
      }

      protected void OnLoadActions1R60( )
      {
      }

      protected void CheckExtendedTable1R60( )
      {
         nIsDirty_60 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001R4 */
         pr_default.execute(2, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001R5 */
         pr_default.execute(3, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
               AnyError = 1;
               GX_FocusControl = edtACTClaCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T001R6 */
         pr_default.execute(4, new Object[] {A86ParActCueCod1});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Debe'.", "ForeignKeyNotFound", 1, "PARACTCUECOD1");
            AnyError = 1;
            GX_FocusControl = edtParActCueCod1_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T001R7 */
         pr_default.execute(5, new Object[] {A87ParActCueCod2});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Haber'.", "ForeignKeyNotFound", 1, "PARACTCUECOD2");
            AnyError = 1;
            GX_FocusControl = edtParActCueCod2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T001R8 */
         pr_default.execute(6, new Object[] {n88ParActCueCod3, A88ParActCueCod3});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A88ParActCueCod3)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta 3'.", "ForeignKeyNotFound", 1, "PARACTCUECOD3");
               AnyError = 1;
               GX_FocusControl = edtParActCueCod3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T001R9 */
         pr_default.execute(7, new Object[] {n89ParActCueCod4, A89ParActCueCod4});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A89ParActCueCod4)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta 4'.", "ForeignKeyNotFound", 1, "PARACTCUECOD4");
               AnyError = 1;
               GX_FocusControl = edtParActCueCod4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors1R60( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A83ParTip ,
                               int A84ParCod )
      {
         /* Using cursor T001R11 */
         pr_default.execute(9, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_3( string A426ACTClaCod )
      {
         /* Using cursor T001R12 */
         pr_default.execute(10, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
               AnyError = 1;
               GX_FocusControl = edtACTClaCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_4( string A86ParActCueCod1 )
      {
         /* Using cursor T001R13 */
         pr_default.execute(11, new Object[] {A86ParActCueCod1});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Debe'.", "ForeignKeyNotFound", 1, "PARACTCUECOD1");
            AnyError = 1;
            GX_FocusControl = edtParActCueCod1_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_5( string A87ParActCueCod2 )
      {
         /* Using cursor T001R14 */
         pr_default.execute(12, new Object[] {A87ParActCueCod2});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Haber'.", "ForeignKeyNotFound", 1, "PARACTCUECOD2");
            AnyError = 1;
            GX_FocusControl = edtParActCueCod2_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_6( string A88ParActCueCod3 )
      {
         /* Using cursor T001R15 */
         pr_default.execute(13, new Object[] {n88ParActCueCod3, A88ParActCueCod3});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A88ParActCueCod3)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta 3'.", "ForeignKeyNotFound", 1, "PARACTCUECOD3");
               AnyError = 1;
               GX_FocusControl = edtParActCueCod3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_7( string A89ParActCueCod4 )
      {
         /* Using cursor T001R16 */
         pr_default.execute(14, new Object[] {n89ParActCueCod4, A89ParActCueCod4});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A89ParActCueCod4)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta 4'.", "ForeignKeyNotFound", 1, "PARACTCUECOD4");
               AnyError = 1;
               GX_FocusControl = edtParActCueCod4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey1R60( )
      {
         /* Using cursor T001R17 */
         pr_default.execute(15, new Object[] {A83ParTip, A84ParCod, A85ParDActItem});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound60 = 1;
         }
         else
         {
            RcdFound60 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001R3 */
         pr_default.execute(1, new Object[] {A83ParTip, A84ParCod, A85ParDActItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1R60( 1) ;
            RcdFound60 = 1;
            A85ParDActItem = T001R3_A85ParDActItem[0];
            AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
            A1502ParActCosCod = T001R3_A1502ParActCosCod[0];
            n1502ParActCosCod = T001R3_n1502ParActCosCod[0];
            AssignAttri("", false, "A1502ParActCosCod", A1502ParActCosCod);
            A83ParTip = T001R3_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001R3_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A426ACTClaCod = T001R3_A426ACTClaCod[0];
            n426ACTClaCod = T001R3_n426ACTClaCod[0];
            AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
            A86ParActCueCod1 = T001R3_A86ParActCueCod1[0];
            AssignAttri("", false, "A86ParActCueCod1", A86ParActCueCod1);
            A87ParActCueCod2 = T001R3_A87ParActCueCod2[0];
            AssignAttri("", false, "A87ParActCueCod2", A87ParActCueCod2);
            A88ParActCueCod3 = T001R3_A88ParActCueCod3[0];
            n88ParActCueCod3 = T001R3_n88ParActCueCod3[0];
            AssignAttri("", false, "A88ParActCueCod3", A88ParActCueCod3);
            A89ParActCueCod4 = T001R3_A89ParActCueCod4[0];
            n89ParActCueCod4 = T001R3_n89ParActCueCod4[0];
            AssignAttri("", false, "A89ParActCueCod4", A89ParActCueCod4);
            Z83ParTip = A83ParTip;
            Z84ParCod = A84ParCod;
            Z85ParDActItem = A85ParDActItem;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1R60( ) ;
            if ( AnyError == 1 )
            {
               RcdFound60 = 0;
               InitializeNonKey1R60( ) ;
            }
            Gx_mode = sMode60;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound60 = 0;
            InitializeNonKey1R60( ) ;
            sMode60 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode60;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1R60( ) ;
         if ( RcdFound60 == 0 )
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
         RcdFound60 = 0;
         /* Using cursor T001R18 */
         pr_default.execute(16, new Object[] {A83ParTip, A84ParCod, A85ParDActItem});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T001R18_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001R18_A83ParTip[0], A83ParTip) == 0 ) && ( T001R18_A84ParCod[0] < A84ParCod ) || ( T001R18_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001R18_A83ParTip[0], A83ParTip) == 0 ) && ( T001R18_A85ParDActItem[0] < A85ParDActItem ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T001R18_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001R18_A83ParTip[0], A83ParTip) == 0 ) && ( T001R18_A84ParCod[0] > A84ParCod ) || ( T001R18_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001R18_A83ParTip[0], A83ParTip) == 0 ) && ( T001R18_A85ParDActItem[0] > A85ParDActItem ) ) )
            {
               A83ParTip = T001R18_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001R18_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A85ParDActItem = T001R18_A85ParDActItem[0];
               AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
               RcdFound60 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound60 = 0;
         /* Using cursor T001R19 */
         pr_default.execute(17, new Object[] {A83ParTip, A84ParCod, A85ParDActItem});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( StringUtil.StrCmp(T001R19_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001R19_A83ParTip[0], A83ParTip) == 0 ) && ( T001R19_A84ParCod[0] > A84ParCod ) || ( T001R19_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001R19_A83ParTip[0], A83ParTip) == 0 ) && ( T001R19_A85ParDActItem[0] > A85ParDActItem ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( StringUtil.StrCmp(T001R19_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001R19_A83ParTip[0], A83ParTip) == 0 ) && ( T001R19_A84ParCod[0] < A84ParCod ) || ( T001R19_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001R19_A83ParTip[0], A83ParTip) == 0 ) && ( T001R19_A85ParDActItem[0] < A85ParDActItem ) ) )
            {
               A83ParTip = T001R19_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001R19_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A85ParDActItem = T001R19_A85ParDActItem[0];
               AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
               RcdFound60 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1R60( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1R60( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound60 == 1 )
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A85ParDActItem != Z85ParDActItem ) )
               {
                  A83ParTip = Z83ParTip;
                  AssignAttri("", false, "A83ParTip", A83ParTip);
                  A84ParCod = Z84ParCod;
                  AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
                  A85ParDActItem = Z85ParDActItem;
                  AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARTIP");
                  AnyError = 1;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1R60( ) ;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A85ParDActItem != Z85ParDActItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1R60( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARTIP");
                     AnyError = 1;
                     GX_FocusControl = edtParTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtParTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1R60( ) ;
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
         if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A85ParDActItem != Z85ParDActItem ) )
         {
            A83ParTip = Z83ParTip;
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = Z84ParCod;
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A85ParDActItem = Z85ParDActItem;
            AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtParTip_Internalname;
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
         if ( RcdFound60 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTClaCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1R60( ) ;
         if ( RcdFound60 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1R60( ) ;
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
         if ( RcdFound60 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaCod_Internalname;
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
         if ( RcdFound60 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaCod_Internalname;
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
         ScanStart1R60( ) ;
         if ( RcdFound60 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound60 != 0 )
            {
               ScanNext1R60( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTClaCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1R60( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1R60( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001R2 */
            pr_default.execute(0, new Object[] {A83ParTip, A84ParCod, A85ParDActItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMACTIVO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1502ParActCosCod, T001R2_A1502ParActCosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z426ACTClaCod, T001R2_A426ACTClaCod[0]) != 0 ) || ( StringUtil.StrCmp(Z86ParActCueCod1, T001R2_A86ParActCueCod1[0]) != 0 ) || ( StringUtil.StrCmp(Z87ParActCueCod2, T001R2_A87ParActCueCod2[0]) != 0 ) || ( StringUtil.StrCmp(Z88ParActCueCod3, T001R2_A88ParActCueCod3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z89ParActCueCod4, T001R2_A89ParActCueCod4[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1502ParActCosCod, T001R2_A1502ParActCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamactivo:[seudo value changed for attri]"+"ParActCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z1502ParActCosCod);
                  GXUtil.WriteLogRaw("Current: ",T001R2_A1502ParActCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z426ACTClaCod, T001R2_A426ACTClaCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamactivo:[seudo value changed for attri]"+"ACTClaCod");
                  GXUtil.WriteLogRaw("Old: ",Z426ACTClaCod);
                  GXUtil.WriteLogRaw("Current: ",T001R2_A426ACTClaCod[0]);
               }
               if ( StringUtil.StrCmp(Z86ParActCueCod1, T001R2_A86ParActCueCod1[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamactivo:[seudo value changed for attri]"+"ParActCueCod1");
                  GXUtil.WriteLogRaw("Old: ",Z86ParActCueCod1);
                  GXUtil.WriteLogRaw("Current: ",T001R2_A86ParActCueCod1[0]);
               }
               if ( StringUtil.StrCmp(Z87ParActCueCod2, T001R2_A87ParActCueCod2[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamactivo:[seudo value changed for attri]"+"ParActCueCod2");
                  GXUtil.WriteLogRaw("Old: ",Z87ParActCueCod2);
                  GXUtil.WriteLogRaw("Current: ",T001R2_A87ParActCueCod2[0]);
               }
               if ( StringUtil.StrCmp(Z88ParActCueCod3, T001R2_A88ParActCueCod3[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamactivo:[seudo value changed for attri]"+"ParActCueCod3");
                  GXUtil.WriteLogRaw("Old: ",Z88ParActCueCod3);
                  GXUtil.WriteLogRaw("Current: ",T001R2_A88ParActCueCod3[0]);
               }
               if ( StringUtil.StrCmp(Z89ParActCueCod4, T001R2_A89ParActCueCod4[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamactivo:[seudo value changed for attri]"+"ParActCueCod4");
                  GXUtil.WriteLogRaw("Old: ",Z89ParActCueCod4);
                  GXUtil.WriteLogRaw("Current: ",T001R2_A89ParActCueCod4[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPARAMACTIVO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1R60( )
      {
         BeforeValidate1R60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1R60( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1R60( 0) ;
            CheckOptimisticConcurrency1R60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1R60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1R60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001R20 */
                     pr_default.execute(18, new Object[] {A85ParDActItem, n1502ParActCosCod, A1502ParActCosCod, A83ParTip, A84ParCod, n426ACTClaCod, A426ACTClaCod, A86ParActCueCod1, A87ParActCueCod2, n88ParActCueCod3, A88ParActCueCod3, n89ParActCueCod4, A89ParActCueCod4});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMACTIVO");
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
                           ResetCaption1R0( ) ;
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
               Load1R60( ) ;
            }
            EndLevel1R60( ) ;
         }
         CloseExtendedTableCursors1R60( ) ;
      }

      protected void Update1R60( )
      {
         BeforeValidate1R60( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1R60( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1R60( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1R60( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1R60( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001R21 */
                     pr_default.execute(19, new Object[] {n1502ParActCosCod, A1502ParActCosCod, n426ACTClaCod, A426ACTClaCod, A86ParActCueCod1, A87ParActCueCod2, n88ParActCueCod3, A88ParActCueCod3, n89ParActCueCod4, A89ParActCueCod4, A83ParTip, A84ParCod, A85ParDActItem});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMACTIVO");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMACTIVO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1R60( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1R0( ) ;
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
            EndLevel1R60( ) ;
         }
         CloseExtendedTableCursors1R60( ) ;
      }

      protected void DeferredUpdate1R60( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1R60( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1R60( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1R60( ) ;
            AfterConfirm1R60( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1R60( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001R22 */
                  pr_default.execute(20, new Object[] {A83ParTip, A84ParCod, A85ParDActItem});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPARAMACTIVO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound60 == 0 )
                        {
                           InitAll1R60( ) ;
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
                        ResetCaption1R0( ) ;
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
         sMode60 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1R60( ) ;
         Gx_mode = sMode60;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1R60( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1R60( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1R60( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbparamactivo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbparamactivo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1R60( )
      {
         /* Using cursor T001R23 */
         pr_default.execute(21);
         RcdFound60 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound60 = 1;
            A83ParTip = T001R23_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001R23_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A85ParDActItem = T001R23_A85ParDActItem[0];
            AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1R60( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound60 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound60 = 1;
            A83ParTip = T001R23_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001R23_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A85ParDActItem = T001R23_A85ParDActItem[0];
            AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
         }
      }

      protected void ScanEnd1R60( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1R60( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1R60( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1R60( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1R60( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1R60( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1R60( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1R60( )
      {
         edtParTip_Enabled = 0;
         AssignProp("", false, edtParTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParTip_Enabled), 5, 0), true);
         edtParCod_Enabled = 0;
         AssignProp("", false, edtParCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCod_Enabled), 5, 0), true);
         edtParDActItem_Enabled = 0;
         AssignProp("", false, edtParDActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDActItem_Enabled), 5, 0), true);
         edtACTClaCod_Enabled = 0;
         AssignProp("", false, edtACTClaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTClaCod_Enabled), 5, 0), true);
         edtParActCueCod1_Enabled = 0;
         AssignProp("", false, edtParActCueCod1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParActCueCod1_Enabled), 5, 0), true);
         edtParActCueCod2_Enabled = 0;
         AssignProp("", false, edtParActCueCod2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParActCueCod2_Enabled), 5, 0), true);
         edtParActCueCod3_Enabled = 0;
         AssignProp("", false, edtParActCueCod3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParActCueCod3_Enabled), 5, 0), true);
         edtParActCueCod4_Enabled = 0;
         AssignProp("", false, edtParActCueCod4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParActCueCod4_Enabled), 5, 0), true);
         edtParActCosCod_Enabled = 0;
         AssignProp("", false, edtParActCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParActCosCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1R60( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1R0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181024942", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cbparamactivo.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z83ParTip", StringUtil.RTrim( Z83ParTip));
         GxWebStd.gx_hidden_field( context, "Z84ParCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84ParCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z85ParDActItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z85ParDActItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1502ParActCosCod", StringUtil.RTrim( Z1502ParActCosCod));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z86ParActCueCod1", StringUtil.RTrim( Z86ParActCueCod1));
         GxWebStd.gx_hidden_field( context, "Z87ParActCueCod2", StringUtil.RTrim( Z87ParActCueCod2));
         GxWebStd.gx_hidden_field( context, "Z88ParActCueCod3", StringUtil.RTrim( Z88ParActCueCod3));
         GxWebStd.gx_hidden_field( context, "Z89ParActCueCod4", StringUtil.RTrim( Z89ParActCueCod4));
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
         return formatLink("cbparamactivo.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPARAMACTIVO" ;
      }

      public override string GetPgmdesc( )
      {
         return "CBPARAMACTIVO" ;
      }

      protected void InitializeNonKey1R60( )
      {
         A426ACTClaCod = "";
         n426ACTClaCod = false;
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         n426ACTClaCod = (String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ? true : false);
         A86ParActCueCod1 = "";
         AssignAttri("", false, "A86ParActCueCod1", A86ParActCueCod1);
         A87ParActCueCod2 = "";
         AssignAttri("", false, "A87ParActCueCod2", A87ParActCueCod2);
         A88ParActCueCod3 = "";
         n88ParActCueCod3 = false;
         AssignAttri("", false, "A88ParActCueCod3", A88ParActCueCod3);
         n88ParActCueCod3 = (String.IsNullOrEmpty(StringUtil.RTrim( A88ParActCueCod3)) ? true : false);
         A89ParActCueCod4 = "";
         n89ParActCueCod4 = false;
         AssignAttri("", false, "A89ParActCueCod4", A89ParActCueCod4);
         n89ParActCueCod4 = (String.IsNullOrEmpty(StringUtil.RTrim( A89ParActCueCod4)) ? true : false);
         A1502ParActCosCod = "";
         n1502ParActCosCod = false;
         AssignAttri("", false, "A1502ParActCosCod", A1502ParActCosCod);
         n1502ParActCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1502ParActCosCod)) ? true : false);
         Z1502ParActCosCod = "";
         Z426ACTClaCod = "";
         Z86ParActCueCod1 = "";
         Z87ParActCueCod2 = "";
         Z88ParActCueCod3 = "";
         Z89ParActCueCod4 = "";
      }

      protected void InitAll1R60( )
      {
         A83ParTip = "";
         AssignAttri("", false, "A83ParTip", A83ParTip);
         A84ParCod = 0;
         AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
         A85ParDActItem = 0;
         AssignAttri("", false, "A85ParDActItem", StringUtil.LTrimStr( (decimal)(A85ParDActItem), 6, 0));
         InitializeNonKey1R60( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024950", true, true);
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
         context.AddJavascriptSource("cbparamactivo.js", "?20228181024951", false, true);
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
         edtParTip_Internalname = "PARTIP";
         edtParCod_Internalname = "PARCOD";
         edtParDActItem_Internalname = "PARDACTITEM";
         edtACTClaCod_Internalname = "ACTCLACOD";
         edtParActCueCod1_Internalname = "PARACTCUECOD1";
         edtParActCueCod2_Internalname = "PARACTCUECOD2";
         edtParActCueCod3_Internalname = "PARACTCUECOD3";
         edtParActCueCod4_Internalname = "PARACTCUECOD4";
         edtParActCosCod_Internalname = "PARACTCOSCOD";
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
         Form.Caption = "CBPARAMACTIVO";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtParActCosCod_Jsonclick = "";
         edtParActCosCod_Enabled = 1;
         edtParActCueCod4_Jsonclick = "";
         edtParActCueCod4_Enabled = 1;
         edtParActCueCod3_Jsonclick = "";
         edtParActCueCod3_Enabled = 1;
         edtParActCueCod2_Jsonclick = "";
         edtParActCueCod2_Enabled = 1;
         edtParActCueCod1_Jsonclick = "";
         edtParActCueCod1_Enabled = 1;
         edtACTClaCod_Jsonclick = "";
         edtACTClaCod_Enabled = 1;
         edtParDActItem_Jsonclick = "";
         edtParDActItem_Enabled = 1;
         edtParCod_Jsonclick = "";
         edtParCod_Enabled = 1;
         edtParTip_Jsonclick = "";
         edtParTip_Enabled = 1;
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
         /* Using cursor T001R24 */
         pr_default.execute(22, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(22);
         GX_FocusControl = edtACTClaCod_Internalname;
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

      public void Valid_Parcod( )
      {
         /* Using cursor T001R24 */
         pr_default.execute(22, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pardactitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A426ACTClaCod", A426ACTClaCod);
         AssignAttri("", false, "A86ParActCueCod1", StringUtil.RTrim( A86ParActCueCod1));
         AssignAttri("", false, "A87ParActCueCod2", StringUtil.RTrim( A87ParActCueCod2));
         AssignAttri("", false, "A88ParActCueCod3", StringUtil.RTrim( A88ParActCueCod3));
         AssignAttri("", false, "A89ParActCueCod4", StringUtil.RTrim( A89ParActCueCod4));
         AssignAttri("", false, "A1502ParActCosCod", StringUtil.RTrim( A1502ParActCosCod));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z83ParTip", StringUtil.RTrim( Z83ParTip));
         GxWebStd.gx_hidden_field( context, "Z84ParCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84ParCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z85ParDActItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z85ParDActItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z426ACTClaCod", Z426ACTClaCod);
         GxWebStd.gx_hidden_field( context, "Z86ParActCueCod1", StringUtil.RTrim( Z86ParActCueCod1));
         GxWebStd.gx_hidden_field( context, "Z87ParActCueCod2", StringUtil.RTrim( Z87ParActCueCod2));
         GxWebStd.gx_hidden_field( context, "Z88ParActCueCod3", StringUtil.RTrim( Z88ParActCueCod3));
         GxWebStd.gx_hidden_field( context, "Z89ParActCueCod4", StringUtil.RTrim( Z89ParActCueCod4));
         GxWebStd.gx_hidden_field( context, "Z1502ParActCosCod", StringUtil.RTrim( Z1502ParActCosCod));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Actclacod( )
      {
         n426ACTClaCod = false;
         /* Using cursor T001R25 */
         pr_default.execute(23, new Object[] {n426ACTClaCod, A426ACTClaCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A426ACTClaCod)) ) )
            {
               GX_msglist.addItem("No existe 'Clase de Activo'.", "ForeignKeyNotFound", 1, "ACTCLACOD");
               AnyError = 1;
               GX_FocusControl = edtACTClaCod_Internalname;
            }
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Paractcuecod1( )
      {
         /* Using cursor T001R26 */
         pr_default.execute(24, new Object[] {A86ParActCueCod1});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Debe'.", "ForeignKeyNotFound", 1, "PARACTCUECOD1");
            AnyError = 1;
            GX_FocusControl = edtParActCueCod1_Internalname;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Paractcuecod2( )
      {
         /* Using cursor T001R27 */
         pr_default.execute(25, new Object[] {A87ParActCueCod2});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Haber'.", "ForeignKeyNotFound", 1, "PARACTCUECOD2");
            AnyError = 1;
            GX_FocusControl = edtParActCueCod2_Internalname;
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Paractcuecod3( )
      {
         n88ParActCueCod3 = false;
         /* Using cursor T001R28 */
         pr_default.execute(26, new Object[] {n88ParActCueCod3, A88ParActCueCod3});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A88ParActCueCod3)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta 3'.", "ForeignKeyNotFound", 1, "PARACTCUECOD3");
               AnyError = 1;
               GX_FocusControl = edtParActCueCod3_Internalname;
            }
         }
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Paractcuecod4( )
      {
         n89ParActCueCod4 = false;
         /* Using cursor T001R29 */
         pr_default.execute(27, new Object[] {n89ParActCueCod4, A89ParActCueCod4});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A89ParActCueCod4)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta 4'.", "ForeignKeyNotFound", 1, "PARACTCUECOD4");
               AnyError = 1;
               GX_FocusControl = edtParActCueCod4_Internalname;
            }
         }
         pr_default.close(27);
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
         setEventMetadata("VALID_PARTIP","{handler:'Valid_Partip',iparms:[]");
         setEventMetadata("VALID_PARTIP",",oparms:[]}");
         setEventMetadata("VALID_PARCOD","{handler:'Valid_Parcod',iparms:[{av:'A83ParTip',fld:'PARTIP',pic:''},{av:'A84ParCod',fld:'PARCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PARCOD",",oparms:[]}");
         setEventMetadata("VALID_PARDACTITEM","{handler:'Valid_Pardactitem',iparms:[{av:'A83ParTip',fld:'PARTIP',pic:''},{av:'A84ParCod',fld:'PARCOD',pic:'ZZZZZ9'},{av:'A85ParDActItem',fld:'PARDACTITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PARDACTITEM",",oparms:[{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''},{av:'A86ParActCueCod1',fld:'PARACTCUECOD1',pic:''},{av:'A87ParActCueCod2',fld:'PARACTCUECOD2',pic:''},{av:'A88ParActCueCod3',fld:'PARACTCUECOD3',pic:''},{av:'A89ParActCueCod4',fld:'PARACTCUECOD4',pic:''},{av:'A1502ParActCosCod',fld:'PARACTCOSCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83ParTip'},{av:'Z84ParCod'},{av:'Z85ParDActItem'},{av:'Z426ACTClaCod'},{av:'Z86ParActCueCod1'},{av:'Z87ParActCueCod2'},{av:'Z88ParActCueCod3'},{av:'Z89ParActCueCod4'},{av:'Z1502ParActCosCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACTCLACOD","{handler:'Valid_Actclacod',iparms:[{av:'A426ACTClaCod',fld:'ACTCLACOD',pic:''}]");
         setEventMetadata("VALID_ACTCLACOD",",oparms:[]}");
         setEventMetadata("VALID_PARACTCUECOD1","{handler:'Valid_Paractcuecod1',iparms:[{av:'A86ParActCueCod1',fld:'PARACTCUECOD1',pic:''}]");
         setEventMetadata("VALID_PARACTCUECOD1",",oparms:[]}");
         setEventMetadata("VALID_PARACTCUECOD2","{handler:'Valid_Paractcuecod2',iparms:[{av:'A87ParActCueCod2',fld:'PARACTCUECOD2',pic:''}]");
         setEventMetadata("VALID_PARACTCUECOD2",",oparms:[]}");
         setEventMetadata("VALID_PARACTCUECOD3","{handler:'Valid_Paractcuecod3',iparms:[{av:'A88ParActCueCod3',fld:'PARACTCUECOD3',pic:''}]");
         setEventMetadata("VALID_PARACTCUECOD3",",oparms:[]}");
         setEventMetadata("VALID_PARACTCUECOD4","{handler:'Valid_Paractcuecod4',iparms:[{av:'A89ParActCueCod4',fld:'PARACTCUECOD4',pic:''}]");
         setEventMetadata("VALID_PARACTCUECOD4",",oparms:[]}");
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
         pr_default.close(22);
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(25);
         pr_default.close(26);
         pr_default.close(27);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z83ParTip = "";
         Z1502ParActCosCod = "";
         Z426ACTClaCod = "";
         Z86ParActCueCod1 = "";
         Z87ParActCueCod2 = "";
         Z88ParActCueCod3 = "";
         Z89ParActCueCod4 = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A83ParTip = "";
         A426ACTClaCod = "";
         A86ParActCueCod1 = "";
         A87ParActCueCod2 = "";
         A88ParActCueCod3 = "";
         A89ParActCueCod4 = "";
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
         A1502ParActCosCod = "";
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
         T001R10_A85ParDActItem = new int[1] ;
         T001R10_A1502ParActCosCod = new string[] {""} ;
         T001R10_n1502ParActCosCod = new bool[] {false} ;
         T001R10_A83ParTip = new string[] {""} ;
         T001R10_A84ParCod = new int[1] ;
         T001R10_A426ACTClaCod = new string[] {""} ;
         T001R10_n426ACTClaCod = new bool[] {false} ;
         T001R10_A86ParActCueCod1 = new string[] {""} ;
         T001R10_A87ParActCueCod2 = new string[] {""} ;
         T001R10_A88ParActCueCod3 = new string[] {""} ;
         T001R10_n88ParActCueCod3 = new bool[] {false} ;
         T001R10_A89ParActCueCod4 = new string[] {""} ;
         T001R10_n89ParActCueCod4 = new bool[] {false} ;
         T001R4_A83ParTip = new string[] {""} ;
         T001R5_A426ACTClaCod = new string[] {""} ;
         T001R5_n426ACTClaCod = new bool[] {false} ;
         T001R6_A86ParActCueCod1 = new string[] {""} ;
         T001R7_A87ParActCueCod2 = new string[] {""} ;
         T001R8_A88ParActCueCod3 = new string[] {""} ;
         T001R8_n88ParActCueCod3 = new bool[] {false} ;
         T001R9_A89ParActCueCod4 = new string[] {""} ;
         T001R9_n89ParActCueCod4 = new bool[] {false} ;
         T001R11_A83ParTip = new string[] {""} ;
         T001R12_A426ACTClaCod = new string[] {""} ;
         T001R12_n426ACTClaCod = new bool[] {false} ;
         T001R13_A86ParActCueCod1 = new string[] {""} ;
         T001R14_A87ParActCueCod2 = new string[] {""} ;
         T001R15_A88ParActCueCod3 = new string[] {""} ;
         T001R15_n88ParActCueCod3 = new bool[] {false} ;
         T001R16_A89ParActCueCod4 = new string[] {""} ;
         T001R16_n89ParActCueCod4 = new bool[] {false} ;
         T001R17_A83ParTip = new string[] {""} ;
         T001R17_A84ParCod = new int[1] ;
         T001R17_A85ParDActItem = new int[1] ;
         T001R3_A85ParDActItem = new int[1] ;
         T001R3_A1502ParActCosCod = new string[] {""} ;
         T001R3_n1502ParActCosCod = new bool[] {false} ;
         T001R3_A83ParTip = new string[] {""} ;
         T001R3_A84ParCod = new int[1] ;
         T001R3_A426ACTClaCod = new string[] {""} ;
         T001R3_n426ACTClaCod = new bool[] {false} ;
         T001R3_A86ParActCueCod1 = new string[] {""} ;
         T001R3_A87ParActCueCod2 = new string[] {""} ;
         T001R3_A88ParActCueCod3 = new string[] {""} ;
         T001R3_n88ParActCueCod3 = new bool[] {false} ;
         T001R3_A89ParActCueCod4 = new string[] {""} ;
         T001R3_n89ParActCueCod4 = new bool[] {false} ;
         sMode60 = "";
         T001R18_A83ParTip = new string[] {""} ;
         T001R18_A84ParCod = new int[1] ;
         T001R18_A85ParDActItem = new int[1] ;
         T001R19_A83ParTip = new string[] {""} ;
         T001R19_A84ParCod = new int[1] ;
         T001R19_A85ParDActItem = new int[1] ;
         T001R2_A85ParDActItem = new int[1] ;
         T001R2_A1502ParActCosCod = new string[] {""} ;
         T001R2_n1502ParActCosCod = new bool[] {false} ;
         T001R2_A83ParTip = new string[] {""} ;
         T001R2_A84ParCod = new int[1] ;
         T001R2_A426ACTClaCod = new string[] {""} ;
         T001R2_n426ACTClaCod = new bool[] {false} ;
         T001R2_A86ParActCueCod1 = new string[] {""} ;
         T001R2_A87ParActCueCod2 = new string[] {""} ;
         T001R2_A88ParActCueCod3 = new string[] {""} ;
         T001R2_n88ParActCueCod3 = new bool[] {false} ;
         T001R2_A89ParActCueCod4 = new string[] {""} ;
         T001R2_n89ParActCueCod4 = new bool[] {false} ;
         T001R23_A83ParTip = new string[] {""} ;
         T001R23_A84ParCod = new int[1] ;
         T001R23_A85ParDActItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001R24_A83ParTip = new string[] {""} ;
         ZZ83ParTip = "";
         ZZ426ACTClaCod = "";
         ZZ86ParActCueCod1 = "";
         ZZ87ParActCueCod2 = "";
         ZZ88ParActCueCod3 = "";
         ZZ89ParActCueCod4 = "";
         ZZ1502ParActCosCod = "";
         T001R25_A426ACTClaCod = new string[] {""} ;
         T001R25_n426ACTClaCod = new bool[] {false} ;
         T001R26_A86ParActCueCod1 = new string[] {""} ;
         T001R27_A87ParActCueCod2 = new string[] {""} ;
         T001R28_A88ParActCueCod3 = new string[] {""} ;
         T001R28_n88ParActCueCod3 = new bool[] {false} ;
         T001R29_A89ParActCueCod4 = new string[] {""} ;
         T001R29_n89ParActCueCod4 = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbparamactivo__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbparamactivo__default(),
            new Object[][] {
                new Object[] {
               T001R2_A85ParDActItem, T001R2_A1502ParActCosCod, T001R2_n1502ParActCosCod, T001R2_A83ParTip, T001R2_A84ParCod, T001R2_A426ACTClaCod, T001R2_n426ACTClaCod, T001R2_A86ParActCueCod1, T001R2_A87ParActCueCod2, T001R2_A88ParActCueCod3,
               T001R2_n88ParActCueCod3, T001R2_A89ParActCueCod4, T001R2_n89ParActCueCod4
               }
               , new Object[] {
               T001R3_A85ParDActItem, T001R3_A1502ParActCosCod, T001R3_n1502ParActCosCod, T001R3_A83ParTip, T001R3_A84ParCod, T001R3_A426ACTClaCod, T001R3_n426ACTClaCod, T001R3_A86ParActCueCod1, T001R3_A87ParActCueCod2, T001R3_A88ParActCueCod3,
               T001R3_n88ParActCueCod3, T001R3_A89ParActCueCod4, T001R3_n89ParActCueCod4
               }
               , new Object[] {
               T001R4_A83ParTip
               }
               , new Object[] {
               T001R5_A426ACTClaCod
               }
               , new Object[] {
               T001R6_A86ParActCueCod1
               }
               , new Object[] {
               T001R7_A87ParActCueCod2
               }
               , new Object[] {
               T001R8_A88ParActCueCod3
               }
               , new Object[] {
               T001R9_A89ParActCueCod4
               }
               , new Object[] {
               T001R10_A85ParDActItem, T001R10_A1502ParActCosCod, T001R10_n1502ParActCosCod, T001R10_A83ParTip, T001R10_A84ParCod, T001R10_A426ACTClaCod, T001R10_n426ACTClaCod, T001R10_A86ParActCueCod1, T001R10_A87ParActCueCod2, T001R10_A88ParActCueCod3,
               T001R10_n88ParActCueCod3, T001R10_A89ParActCueCod4, T001R10_n89ParActCueCod4
               }
               , new Object[] {
               T001R11_A83ParTip
               }
               , new Object[] {
               T001R12_A426ACTClaCod
               }
               , new Object[] {
               T001R13_A86ParActCueCod1
               }
               , new Object[] {
               T001R14_A87ParActCueCod2
               }
               , new Object[] {
               T001R15_A88ParActCueCod3
               }
               , new Object[] {
               T001R16_A89ParActCueCod4
               }
               , new Object[] {
               T001R17_A83ParTip, T001R17_A84ParCod, T001R17_A85ParDActItem
               }
               , new Object[] {
               T001R18_A83ParTip, T001R18_A84ParCod, T001R18_A85ParDActItem
               }
               , new Object[] {
               T001R19_A83ParTip, T001R19_A84ParCod, T001R19_A85ParDActItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001R23_A83ParTip, T001R23_A84ParCod, T001R23_A85ParDActItem
               }
               , new Object[] {
               T001R24_A83ParTip
               }
               , new Object[] {
               T001R25_A426ACTClaCod
               }
               , new Object[] {
               T001R26_A86ParActCueCod1
               }
               , new Object[] {
               T001R27_A87ParActCueCod2
               }
               , new Object[] {
               T001R28_A88ParActCueCod3
               }
               , new Object[] {
               T001R29_A89ParActCueCod4
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
      private short RcdFound60 ;
      private short nIsDirty_60 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z84ParCod ;
      private int Z85ParDActItem ;
      private int A84ParCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtParTip_Enabled ;
      private int edtParCod_Enabled ;
      private int A85ParDActItem ;
      private int edtParDActItem_Enabled ;
      private int edtACTClaCod_Enabled ;
      private int edtParActCueCod1_Enabled ;
      private int edtParActCueCod2_Enabled ;
      private int edtParActCueCod3_Enabled ;
      private int edtParActCueCod4_Enabled ;
      private int edtParActCosCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ84ParCod ;
      private int ZZ85ParDActItem ;
      private string sPrefix ;
      private string Z83ParTip ;
      private string Z1502ParActCosCod ;
      private string Z86ParActCueCod1 ;
      private string Z87ParActCueCod2 ;
      private string Z88ParActCueCod3 ;
      private string Z89ParActCueCod4 ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A83ParTip ;
      private string A86ParActCueCod1 ;
      private string A87ParActCueCod2 ;
      private string A88ParActCueCod3 ;
      private string A89ParActCueCod4 ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtParTip_Internalname ;
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
      private string edtParTip_Jsonclick ;
      private string edtParCod_Internalname ;
      private string edtParCod_Jsonclick ;
      private string edtParDActItem_Internalname ;
      private string edtParDActItem_Jsonclick ;
      private string edtACTClaCod_Internalname ;
      private string edtACTClaCod_Jsonclick ;
      private string edtParActCueCod1_Internalname ;
      private string edtParActCueCod1_Jsonclick ;
      private string edtParActCueCod2_Internalname ;
      private string edtParActCueCod2_Jsonclick ;
      private string edtParActCueCod3_Internalname ;
      private string edtParActCueCod3_Jsonclick ;
      private string edtParActCueCod4_Internalname ;
      private string edtParActCueCod4_Jsonclick ;
      private string edtParActCosCod_Internalname ;
      private string A1502ParActCosCod ;
      private string edtParActCosCod_Jsonclick ;
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
      private string sMode60 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ83ParTip ;
      private string ZZ86ParActCueCod1 ;
      private string ZZ87ParActCueCod2 ;
      private string ZZ88ParActCueCod3 ;
      private string ZZ89ParActCueCod4 ;
      private string ZZ1502ParActCosCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n426ACTClaCod ;
      private bool n88ParActCueCod3 ;
      private bool n89ParActCueCod4 ;
      private bool wbErr ;
      private bool n1502ParActCosCod ;
      private bool Gx_longc ;
      private string Z426ACTClaCod ;
      private string A426ACTClaCod ;
      private string ZZ426ACTClaCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T001R10_A85ParDActItem ;
      private string[] T001R10_A1502ParActCosCod ;
      private bool[] T001R10_n1502ParActCosCod ;
      private string[] T001R10_A83ParTip ;
      private int[] T001R10_A84ParCod ;
      private string[] T001R10_A426ACTClaCod ;
      private bool[] T001R10_n426ACTClaCod ;
      private string[] T001R10_A86ParActCueCod1 ;
      private string[] T001R10_A87ParActCueCod2 ;
      private string[] T001R10_A88ParActCueCod3 ;
      private bool[] T001R10_n88ParActCueCod3 ;
      private string[] T001R10_A89ParActCueCod4 ;
      private bool[] T001R10_n89ParActCueCod4 ;
      private string[] T001R4_A83ParTip ;
      private string[] T001R5_A426ACTClaCod ;
      private bool[] T001R5_n426ACTClaCod ;
      private string[] T001R6_A86ParActCueCod1 ;
      private string[] T001R7_A87ParActCueCod2 ;
      private string[] T001R8_A88ParActCueCod3 ;
      private bool[] T001R8_n88ParActCueCod3 ;
      private string[] T001R9_A89ParActCueCod4 ;
      private bool[] T001R9_n89ParActCueCod4 ;
      private string[] T001R11_A83ParTip ;
      private string[] T001R12_A426ACTClaCod ;
      private bool[] T001R12_n426ACTClaCod ;
      private string[] T001R13_A86ParActCueCod1 ;
      private string[] T001R14_A87ParActCueCod2 ;
      private string[] T001R15_A88ParActCueCod3 ;
      private bool[] T001R15_n88ParActCueCod3 ;
      private string[] T001R16_A89ParActCueCod4 ;
      private bool[] T001R16_n89ParActCueCod4 ;
      private string[] T001R17_A83ParTip ;
      private int[] T001R17_A84ParCod ;
      private int[] T001R17_A85ParDActItem ;
      private int[] T001R3_A85ParDActItem ;
      private string[] T001R3_A1502ParActCosCod ;
      private bool[] T001R3_n1502ParActCosCod ;
      private string[] T001R3_A83ParTip ;
      private int[] T001R3_A84ParCod ;
      private string[] T001R3_A426ACTClaCod ;
      private bool[] T001R3_n426ACTClaCod ;
      private string[] T001R3_A86ParActCueCod1 ;
      private string[] T001R3_A87ParActCueCod2 ;
      private string[] T001R3_A88ParActCueCod3 ;
      private bool[] T001R3_n88ParActCueCod3 ;
      private string[] T001R3_A89ParActCueCod4 ;
      private bool[] T001R3_n89ParActCueCod4 ;
      private string[] T001R18_A83ParTip ;
      private int[] T001R18_A84ParCod ;
      private int[] T001R18_A85ParDActItem ;
      private string[] T001R19_A83ParTip ;
      private int[] T001R19_A84ParCod ;
      private int[] T001R19_A85ParDActItem ;
      private int[] T001R2_A85ParDActItem ;
      private string[] T001R2_A1502ParActCosCod ;
      private bool[] T001R2_n1502ParActCosCod ;
      private string[] T001R2_A83ParTip ;
      private int[] T001R2_A84ParCod ;
      private string[] T001R2_A426ACTClaCod ;
      private bool[] T001R2_n426ACTClaCod ;
      private string[] T001R2_A86ParActCueCod1 ;
      private string[] T001R2_A87ParActCueCod2 ;
      private string[] T001R2_A88ParActCueCod3 ;
      private bool[] T001R2_n88ParActCueCod3 ;
      private string[] T001R2_A89ParActCueCod4 ;
      private bool[] T001R2_n89ParActCueCod4 ;
      private string[] T001R23_A83ParTip ;
      private int[] T001R23_A84ParCod ;
      private int[] T001R23_A85ParDActItem ;
      private string[] T001R24_A83ParTip ;
      private string[] T001R25_A426ACTClaCod ;
      private bool[] T001R25_n426ACTClaCod ;
      private string[] T001R26_A86ParActCueCod1 ;
      private string[] T001R27_A87ParActCueCod2 ;
      private string[] T001R28_A88ParActCueCod3 ;
      private bool[] T001R28_n88ParActCueCod3 ;
      private string[] T001R29_A89ParActCueCod4 ;
      private bool[] T001R29_n89ParActCueCod4 ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbparamactivo__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbparamactivo__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001R10;
        prmT001R10 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R4;
        prmT001R4 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001R5;
        prmT001R5 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT001R6;
        prmT001R6 = new Object[] {
        new ParDef("@ParActCueCod1",GXType.NChar,15,0)
        };
        Object[] prmT001R7;
        prmT001R7 = new Object[] {
        new ParDef("@ParActCueCod2",GXType.NChar,15,0)
        };
        Object[] prmT001R8;
        prmT001R8 = new Object[] {
        new ParDef("@ParActCueCod3",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001R9;
        prmT001R9 = new Object[] {
        new ParDef("@ParActCueCod4",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001R11;
        prmT001R11 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001R12;
        prmT001R12 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT001R13;
        prmT001R13 = new Object[] {
        new ParDef("@ParActCueCod1",GXType.NChar,15,0)
        };
        Object[] prmT001R14;
        prmT001R14 = new Object[] {
        new ParDef("@ParActCueCod2",GXType.NChar,15,0)
        };
        Object[] prmT001R15;
        prmT001R15 = new Object[] {
        new ParDef("@ParActCueCod3",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001R16;
        prmT001R16 = new Object[] {
        new ParDef("@ParActCueCod4",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001R17;
        prmT001R17 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R3;
        prmT001R3 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R18;
        prmT001R18 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R19;
        prmT001R19 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R2;
        prmT001R2 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R20;
        prmT001R20 = new Object[] {
        new ParDef("@ParDActItem",GXType.Int32,6,0) ,
        new ParDef("@ParActCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ParActCueCod1",GXType.NChar,15,0) ,
        new ParDef("@ParActCueCod2",GXType.NChar,15,0) ,
        new ParDef("@ParActCueCod3",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParActCueCod4",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001R21;
        prmT001R21 = new Object[] {
        new ParDef("@ParActCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true} ,
        new ParDef("@ParActCueCod1",GXType.NChar,15,0) ,
        new ParDef("@ParActCueCod2",GXType.NChar,15,0) ,
        new ParDef("@ParActCueCod3",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParActCueCod4",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R22;
        prmT001R22 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDActItem",GXType.Int32,6,0)
        };
        Object[] prmT001R23;
        prmT001R23 = new Object[] {
        };
        Object[] prmT001R24;
        prmT001R24 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001R25;
        prmT001R25 = new Object[] {
        new ParDef("@ACTClaCod",GXType.NVarChar,5,0){Nullable=true}
        };
        Object[] prmT001R26;
        prmT001R26 = new Object[] {
        new ParDef("@ParActCueCod1",GXType.NChar,15,0)
        };
        Object[] prmT001R27;
        prmT001R27 = new Object[] {
        new ParDef("@ParActCueCod2",GXType.NChar,15,0)
        };
        Object[] prmT001R28;
        prmT001R28 = new Object[] {
        new ParDef("@ParActCueCod3",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001R29;
        prmT001R29 = new Object[] {
        new ParDef("@ParActCueCod4",GXType.NChar,15,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001R2", "SELECT [ParDActItem], [ParActCosCod], [ParTip], [ParCod], [ACTClaCod], [ParActCueCod1] AS ParActCueCod1, [ParActCueCod2] AS ParActCueCod2, [ParActCueCod3] AS ParActCueCod3, [ParActCueCod4] AS ParActCueCod4 FROM [CBPARAMACTIVO] WITH (UPDLOCK) WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDActItem] = @ParDActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R3", "SELECT [ParDActItem], [ParActCosCod], [ParTip], [ParCod], [ACTClaCod], [ParActCueCod1] AS ParActCueCod1, [ParActCueCod2] AS ParActCueCod2, [ParActCueCod3] AS ParActCueCod3, [ParActCueCod4] AS ParActCueCod4 FROM [CBPARAMACTIVO] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDActItem] = @ParDActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R4", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R5", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R6", "SELECT [CueCod] AS ParActCueCod1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R7", "SELECT [CueCod] AS ParActCueCod2 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R8", "SELECT [CueCod] AS ParActCueCod3 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod3 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R9", "SELECT [CueCod] AS ParActCueCod4 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod4 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R10", "SELECT TM1.[ParDActItem], TM1.[ParActCosCod], TM1.[ParTip], TM1.[ParCod], TM1.[ACTClaCod], TM1.[ParActCueCod1] AS ParActCueCod1, TM1.[ParActCueCod2] AS ParActCueCod2, TM1.[ParActCueCod3] AS ParActCueCod3, TM1.[ParActCueCod4] AS ParActCueCod4 FROM [CBPARAMACTIVO] TM1 WHERE TM1.[ParTip] = @ParTip and TM1.[ParCod] = @ParCod and TM1.[ParDActItem] = @ParDActItem ORDER BY TM1.[ParTip], TM1.[ParCod], TM1.[ParDActItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001R10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R11", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R12", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R13", "SELECT [CueCod] AS ParActCueCod1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R14", "SELECT [CueCod] AS ParActCueCod2 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R15", "SELECT [CueCod] AS ParActCueCod3 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod3 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R16", "SELECT [CueCod] AS ParActCueCod4 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod4 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R17", "SELECT [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDActItem] = @ParDActItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001R17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R18", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE ( [ParTip] > @ParTip or [ParTip] = @ParTip and [ParCod] > @ParCod or [ParCod] = @ParCod and [ParTip] = @ParTip and [ParDActItem] > @ParDActItem) ORDER BY [ParTip], [ParCod], [ParDActItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001R18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001R19", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE ( [ParTip] < @ParTip or [ParTip] = @ParTip and [ParCod] < @ParCod or [ParCod] = @ParCod and [ParTip] = @ParTip and [ParDActItem] < @ParDActItem) ORDER BY [ParTip] DESC, [ParCod] DESC, [ParDActItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001R19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001R20", "INSERT INTO [CBPARAMACTIVO]([ParDActItem], [ParActCosCod], [ParTip], [ParCod], [ACTClaCod], [ParActCueCod1], [ParActCueCod2], [ParActCueCod3], [ParActCueCod4]) VALUES(@ParDActItem, @ParActCosCod, @ParTip, @ParCod, @ACTClaCod, @ParActCueCod1, @ParActCueCod2, @ParActCueCod3, @ParActCueCod4)", GxErrorMask.GX_NOMASK,prmT001R20)
           ,new CursorDef("T001R21", "UPDATE [CBPARAMACTIVO] SET [ParActCosCod]=@ParActCosCod, [ACTClaCod]=@ACTClaCod, [ParActCueCod1]=@ParActCueCod1, [ParActCueCod2]=@ParActCueCod2, [ParActCueCod3]=@ParActCueCod3, [ParActCueCod4]=@ParActCueCod4  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDActItem] = @ParDActItem", GxErrorMask.GX_NOMASK,prmT001R21)
           ,new CursorDef("T001R22", "DELETE FROM [CBPARAMACTIVO]  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDActItem] = @ParDActItem", GxErrorMask.GX_NOMASK,prmT001R22)
           ,new CursorDef("T001R23", "SELECT [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] ORDER BY [ParTip], [ParCod], [ParDActItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001R23,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R24", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R25", "SELECT [ACTClaCod] FROM [ACTCLASE] WHERE [ACTClaCod] = @ACTClaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R26", "SELECT [CueCod] AS ParActCueCod1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R27", "SELECT [CueCod] AS ParActCueCod2 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R28", "SELECT [CueCod] AS ParActCueCod3 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod3 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001R29", "SELECT [CueCod] AS ParActCueCod4 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParActCueCod4 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001R29,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 15);
              ((string[]) buf[8])[0] = rslt.getString(7, 15);
              ((string[]) buf[9])[0] = rslt.getString(8, 15);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 15);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 15);
              ((string[]) buf[8])[0] = rslt.getString(7, 15);
              ((string[]) buf[9])[0] = rslt.getString(8, 15);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 15);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 3);
              ((int[]) buf[4])[0] = rslt.getInt(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getString(6, 15);
              ((string[]) buf[8])[0] = rslt.getString(7, 15);
              ((string[]) buf[9])[0] = rslt.getString(8, 15);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getString(9, 15);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
