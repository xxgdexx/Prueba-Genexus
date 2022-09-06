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
   public class cpliquidacion : GXDataArea
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
            A236LiqPrvCod = GetPar( "LiqPrvCod");
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A236LiqPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A270LiqCod = GetPar( "LiqCod");
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = GetPar( "LiqPrvCod");
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A271LiqCodItem = (int)(NumberUtil.Val( GetPar( "LiqCodItem"), "."));
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A270LiqCod, A236LiqPrvCod, A271LiqCodItem) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A276LiqMonCod = (int)(NumberUtil.Val( GetPar( "LiqMonCod"), "."));
            AssignAttri("", false, "A276LiqMonCod", StringUtil.LTrimStr( (decimal)(A276LiqMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A276LiqMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A275LiqForCod = (int)(NumberUtil.Val( GetPar( "LiqForCod"), "."));
            AssignAttri("", false, "A275LiqForCod", StringUtil.LTrimStr( (decimal)(A275LiqForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A275LiqForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A273LiqBanCod = (int)(NumberUtil.Val( GetPar( "LiqBanCod"), "."));
            n273LiqBanCod = false;
            AssignAttri("", false, "A273LiqBanCod", StringUtil.LTrimStr( (decimal)(A273LiqBanCod), 6, 0));
            A274LiqBanCue = GetPar( "LiqBanCue");
            n274LiqBanCue = false;
            AssignAttri("", false, "A274LiqBanCue", A274LiqBanCue);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A273LiqBanCod, A274LiqBanCue) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A272LiqTMovCod = (int)(NumberUtil.Val( GetPar( "LiqTMovCod"), "."));
            n272LiqTMovCod = false;
            AssignAttri("", false, "A272LiqTMovCod", StringUtil.LTrimStr( (decimal)(A272LiqTMovCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A272LiqTMovCod) ;
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
            Form.Meta.addItem("description", "Liquidación", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpliquidacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpliquidacion( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Liquidación", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CPLIQUIDACION.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPLIQUIDACION.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqCod_Internalname, "N° Liquidación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqCod_Internalname, A270LiqCod, StringUtil.RTrim( context.localUtil.Format( A270LiqCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqPrvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqPrvCod_Internalname, "Codigo Agente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqPrvCod_Internalname, StringUtil.RTrim( A236LiqPrvCod), StringUtil.RTrim( context.localUtil.Format( A236LiqPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqCodItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqCodItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqCodItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A271LiqCodItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqCodItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A271LiqCodItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A271LiqCodItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCodItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCodItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqPrvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqPrvDsc_Internalname, "Agente de Aduana", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqPrvDsc_Internalname, StringUtil.RTrim( A1197LiqPrvDsc), StringUtil.RTrim( context.localUtil.Format( A1197LiqPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqFech_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqFech_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLiqFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLiqFech_Internalname, context.localUtil.Format(A1178LiqFech, "99/99/99"), context.localUtil.Format( A1178LiqFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_bitmap( context, edtLiqFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLiqFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLIQUIDACION.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A276LiqMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A276LiqMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A276LiqMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqForCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqForCod_Internalname, "Forma Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A275LiqForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A275LiqForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A275LiqForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqBanCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqBanCod_Internalname, "Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A273LiqBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A273LiqBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A273LiqBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqBanCue_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqBanCue_Internalname, "N° Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqBanCue_Internalname, StringUtil.RTrim( A274LiqBanCue), StringUtil.RTrim( context.localUtil.Format( A274LiqBanCue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqBanCue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqBanCue_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqCheque_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqCheque_Internalname, "N° Cheque", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqCheque_Internalname, A1173LiqCheque, StringUtil.RTrim( context.localUtil.Format( A1173LiqCheque, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCheque_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCheque_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqTMovCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqTMovCod_Internalname, "Tipo Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqTMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A272LiqTMovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqTMovCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A272LiqTMovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A272LiqTMovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqTMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqTMovCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqTMovDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqTMovDsc_Internalname, "Tipo Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqTMovDsc_Internalname, StringUtil.RTrim( A1201LiqTMovDsc), StringUtil.RTrim( context.localUtil.Format( A1201LiqTMovDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqTMovDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqTMovDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqTotal_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1202LiqTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtLiqTotal_Enabled!=0) ? context.localUtil.Format( A1202LiqTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1202LiqTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqTItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqTItem_Internalname, "Total Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1199LiqTItem), 10, 0, ".", "")), StringUtil.LTrim( ((edtLiqTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1199LiqTItem), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1199LiqTItem), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqTItem_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqASts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqASts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqASts_Internalname, StringUtil.RTrim( A1164LiqASts), StringUtil.RTrim( context.localUtil.Format( A1164LiqASts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqASts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqASts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqATipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqATipCod_Internalname, "Tipo Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqATipCod_Internalname, StringUtil.RTrim( A1166LiqATipCod), StringUtil.RTrim( context.localUtil.Format( A1166LiqATipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqATipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqATipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqACXP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqACXP_Internalname, "Afecta CxP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqACXP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1162LiqACXP), 1, 0, ".", "")), StringUtil.LTrim( ((edtLiqACXP_Enabled!=0) ? context.localUtil.Format( (decimal)(A1162LiqACXP), "9") : context.localUtil.Format( (decimal)(A1162LiqACXP), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqACXP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqACXP_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqARegistro_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqARegistro_Internalname, "N° Registro", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqARegistro_Internalname, A1163LiqARegistro, StringUtil.RTrim( context.localUtil.Format( A1163LiqARegistro, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqARegistro_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqARegistro_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqAVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqAVouAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqAVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1170LiqAVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtLiqAVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1170LiqAVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1170LiqAVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqAVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqAVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqAVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqAVouMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqAVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1171LiqAVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtLiqAVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1171LiqAVouMes), "Z9") : context.localUtil.Format( (decimal)(A1171LiqAVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqAVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqAVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqATASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqATASICod_Internalname, "Tipo Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqATASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1165LiqATASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqATASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1165LiqATASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1165LiqATASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqATASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqATASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqAVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqAVouNum_Internalname, "N° Voucher", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqAVouNum_Internalname, StringUtil.RTrim( A1172LiqAVouNum), StringUtil.RTrim( context.localUtil.Format( A1172LiqAVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqAVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqAVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqATItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqATItem_Internalname, "Total Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqATItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1167LiqATItem), 10, 0, ".", "")), StringUtil.LTrim( ((edtLiqATItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1167LiqATItem), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1167LiqATItem), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqATItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqATItem_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqUsuCod_Internalname, StringUtil.RTrim( A1203LiqUsuCod), StringUtil.RTrim( context.localUtil.Format( A1203LiqUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,143);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqUsuFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqUsuFec_Internalname, "Usuario Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLiqUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLiqUsuFec_Internalname, context.localUtil.TToC( A1204LiqUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1204LiqUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_bitmap( context, edtLiqUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLiqUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLIQUIDACION.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqAComCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqAComCod_Internalname, "N° Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqAComCod_Internalname, A1161LiqAComCod, StringUtil.RTrim( context.localUtil.Format( A1161LiqAComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,153);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqAComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqAComCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMonDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMonDsc_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqMonDsc_Internalname, StringUtil.RTrim( A1184LiqMonDsc), StringUtil.RTrim( context.localUtil.Format( A1184LiqMonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqTMovCueCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqTMovCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqTMovCueCod_Internalname, StringUtil.RTrim( A1200LiqTMovCueCod), StringUtil.RTrim( context.localUtil.Format( A1200LiqTMovCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqTMovCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqTMovCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqATot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqATot_Internalname, "Total Doc.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqATot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1168LiqATot, 17, 2, ".", "")), StringUtil.LTrim( ((edtLiqATot_Enabled!=0) ? context.localUtil.Format( A1168LiqATot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1168LiqATot, "ZZZZZZ,ZZZ,ZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqATot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqATot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPLIQUIDACION.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 175,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACION.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 177,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACION.htm");
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
            Z270LiqCod = cgiGet( "Z270LiqCod");
            Z236LiqPrvCod = cgiGet( "Z236LiqPrvCod");
            Z271LiqCodItem = (int)(context.localUtil.CToN( cgiGet( "Z271LiqCodItem"), ".", ","));
            Z1178LiqFech = context.localUtil.CToD( cgiGet( "Z1178LiqFech"), 0);
            Z1173LiqCheque = cgiGet( "Z1173LiqCheque");
            Z1202LiqTotal = context.localUtil.CToN( cgiGet( "Z1202LiqTotal"), ".", ",");
            Z1199LiqTItem = (long)(context.localUtil.CToN( cgiGet( "Z1199LiqTItem"), ".", ","));
            Z1164LiqASts = cgiGet( "Z1164LiqASts");
            Z1166LiqATipCod = cgiGet( "Z1166LiqATipCod");
            Z1162LiqACXP = (short)(context.localUtil.CToN( cgiGet( "Z1162LiqACXP"), ".", ","));
            Z1163LiqARegistro = cgiGet( "Z1163LiqARegistro");
            Z1170LiqAVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1170LiqAVouAno"), ".", ","));
            Z1171LiqAVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1171LiqAVouMes"), ".", ","));
            Z1165LiqATASICod = (int)(context.localUtil.CToN( cgiGet( "Z1165LiqATASICod"), ".", ","));
            Z1172LiqAVouNum = cgiGet( "Z1172LiqAVouNum");
            Z1167LiqATItem = (long)(context.localUtil.CToN( cgiGet( "Z1167LiqATItem"), ".", ","));
            Z1203LiqUsuCod = cgiGet( "Z1203LiqUsuCod");
            Z1204LiqUsuFec = context.localUtil.CToT( cgiGet( "Z1204LiqUsuFec"), 0);
            Z1161LiqAComCod = cgiGet( "Z1161LiqAComCod");
            Z276LiqMonCod = (int)(context.localUtil.CToN( cgiGet( "Z276LiqMonCod"), ".", ","));
            Z275LiqForCod = (int)(context.localUtil.CToN( cgiGet( "Z275LiqForCod"), ".", ","));
            Z273LiqBanCod = (int)(context.localUtil.CToN( cgiGet( "Z273LiqBanCod"), ".", ","));
            n273LiqBanCod = ((0==A273LiqBanCod) ? true : false);
            Z274LiqBanCue = cgiGet( "Z274LiqBanCue");
            n274LiqBanCue = (String.IsNullOrEmpty(StringUtil.RTrim( A274LiqBanCue)) ? true : false);
            Z272LiqTMovCod = (int)(context.localUtil.CToN( cgiGet( "Z272LiqTMovCod"), ".", ","));
            n272LiqTMovCod = ((0==A272LiqTMovCod) ? true : false);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A270LiqCod = cgiGet( edtLiqCod_Internalname);
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = cgiGet( edtLiqPrvCod_Internalname);
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqCodItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqCodItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQCODITEM");
               AnyError = 1;
               GX_FocusControl = edtLiqCodItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A271LiqCodItem = 0;
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            }
            else
            {
               A271LiqCodItem = (int)(context.localUtil.CToN( cgiGet( edtLiqCodItem_Internalname), ".", ","));
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            }
            A1197LiqPrvDsc = cgiGet( edtLiqPrvDsc_Internalname);
            AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
            if ( context.localUtil.VCDate( cgiGet( edtLiqFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "LIQFECH");
               AnyError = 1;
               GX_FocusControl = edtLiqFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1178LiqFech = DateTime.MinValue;
               AssignAttri("", false, "A1178LiqFech", context.localUtil.Format(A1178LiqFech, "99/99/99"));
            }
            else
            {
               A1178LiqFech = context.localUtil.CToD( cgiGet( edtLiqFech_Internalname), 2);
               AssignAttri("", false, "A1178LiqFech", context.localUtil.Format(A1178LiqFech, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMONCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A276LiqMonCod = 0;
               AssignAttri("", false, "A276LiqMonCod", StringUtil.LTrimStr( (decimal)(A276LiqMonCod), 6, 0));
            }
            else
            {
               A276LiqMonCod = (int)(context.localUtil.CToN( cgiGet( edtLiqMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A276LiqMonCod", StringUtil.LTrimStr( (decimal)(A276LiqMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A275LiqForCod = 0;
               AssignAttri("", false, "A275LiqForCod", StringUtil.LTrimStr( (decimal)(A275LiqForCod), 6, 0));
            }
            else
            {
               A275LiqForCod = (int)(context.localUtil.CToN( cgiGet( edtLiqForCod_Internalname), ".", ","));
               AssignAttri("", false, "A275LiqForCod", StringUtil.LTrimStr( (decimal)(A275LiqForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQBANCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A273LiqBanCod = 0;
               n273LiqBanCod = false;
               AssignAttri("", false, "A273LiqBanCod", StringUtil.LTrimStr( (decimal)(A273LiqBanCod), 6, 0));
            }
            else
            {
               A273LiqBanCod = (int)(context.localUtil.CToN( cgiGet( edtLiqBanCod_Internalname), ".", ","));
               n273LiqBanCod = false;
               AssignAttri("", false, "A273LiqBanCod", StringUtil.LTrimStr( (decimal)(A273LiqBanCod), 6, 0));
            }
            n273LiqBanCod = ((0==A273LiqBanCod) ? true : false);
            A274LiqBanCue = cgiGet( edtLiqBanCue_Internalname);
            n274LiqBanCue = false;
            AssignAttri("", false, "A274LiqBanCue", A274LiqBanCue);
            n274LiqBanCue = (String.IsNullOrEmpty(StringUtil.RTrim( A274LiqBanCue)) ? true : false);
            A1173LiqCheque = cgiGet( edtLiqCheque_Internalname);
            AssignAttri("", false, "A1173LiqCheque", A1173LiqCheque);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqTMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqTMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQTMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqTMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A272LiqTMovCod = 0;
               n272LiqTMovCod = false;
               AssignAttri("", false, "A272LiqTMovCod", StringUtil.LTrimStr( (decimal)(A272LiqTMovCod), 6, 0));
            }
            else
            {
               A272LiqTMovCod = (int)(context.localUtil.CToN( cgiGet( edtLiqTMovCod_Internalname), ".", ","));
               n272LiqTMovCod = false;
               AssignAttri("", false, "A272LiqTMovCod", StringUtil.LTrimStr( (decimal)(A272LiqTMovCod), 6, 0));
            }
            n272LiqTMovCod = ((0==A272LiqTMovCod) ? true : false);
            A1201LiqTMovDsc = cgiGet( edtLiqTMovDsc_Internalname);
            AssignAttri("", false, "A1201LiqTMovDsc", A1201LiqTMovDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqTotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqTotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQTOTAL");
               AnyError = 1;
               GX_FocusControl = edtLiqTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1202LiqTotal = 0;
               AssignAttri("", false, "A1202LiqTotal", StringUtil.LTrimStr( A1202LiqTotal, 15, 2));
            }
            else
            {
               A1202LiqTotal = context.localUtil.CToN( cgiGet( edtLiqTotal_Internalname), ".", ",");
               AssignAttri("", false, "A1202LiqTotal", StringUtil.LTrimStr( A1202LiqTotal, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqTItem_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQTITEM");
               AnyError = 1;
               GX_FocusControl = edtLiqTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1199LiqTItem = 0;
               AssignAttri("", false, "A1199LiqTItem", StringUtil.LTrimStr( (decimal)(A1199LiqTItem), 10, 0));
            }
            else
            {
               A1199LiqTItem = (long)(context.localUtil.CToN( cgiGet( edtLiqTItem_Internalname), ".", ","));
               AssignAttri("", false, "A1199LiqTItem", StringUtil.LTrimStr( (decimal)(A1199LiqTItem), 10, 0));
            }
            A1164LiqASts = cgiGet( edtLiqASts_Internalname);
            AssignAttri("", false, "A1164LiqASts", A1164LiqASts);
            A1166LiqATipCod = cgiGet( edtLiqATipCod_Internalname);
            AssignAttri("", false, "A1166LiqATipCod", A1166LiqATipCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqACXP_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqACXP_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQACXP");
               AnyError = 1;
               GX_FocusControl = edtLiqACXP_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1162LiqACXP = 0;
               AssignAttri("", false, "A1162LiqACXP", StringUtil.Str( (decimal)(A1162LiqACXP), 1, 0));
            }
            else
            {
               A1162LiqACXP = (short)(context.localUtil.CToN( cgiGet( edtLiqACXP_Internalname), ".", ","));
               AssignAttri("", false, "A1162LiqACXP", StringUtil.Str( (decimal)(A1162LiqACXP), 1, 0));
            }
            A1163LiqARegistro = cgiGet( edtLiqARegistro_Internalname);
            AssignAttri("", false, "A1163LiqARegistro", A1163LiqARegistro);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqAVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqAVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQAVOUANO");
               AnyError = 1;
               GX_FocusControl = edtLiqAVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1170LiqAVouAno = 0;
               AssignAttri("", false, "A1170LiqAVouAno", StringUtil.LTrimStr( (decimal)(A1170LiqAVouAno), 4, 0));
            }
            else
            {
               A1170LiqAVouAno = (short)(context.localUtil.CToN( cgiGet( edtLiqAVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1170LiqAVouAno", StringUtil.LTrimStr( (decimal)(A1170LiqAVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqAVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqAVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQAVOUMES");
               AnyError = 1;
               GX_FocusControl = edtLiqAVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1171LiqAVouMes = 0;
               AssignAttri("", false, "A1171LiqAVouMes", StringUtil.LTrimStr( (decimal)(A1171LiqAVouMes), 2, 0));
            }
            else
            {
               A1171LiqAVouMes = (short)(context.localUtil.CToN( cgiGet( edtLiqAVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1171LiqAVouMes", StringUtil.LTrimStr( (decimal)(A1171LiqAVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqATASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqATASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQATASICOD");
               AnyError = 1;
               GX_FocusControl = edtLiqATASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1165LiqATASICod = 0;
               AssignAttri("", false, "A1165LiqATASICod", StringUtil.LTrimStr( (decimal)(A1165LiqATASICod), 6, 0));
            }
            else
            {
               A1165LiqATASICod = (int)(context.localUtil.CToN( cgiGet( edtLiqATASICod_Internalname), ".", ","));
               AssignAttri("", false, "A1165LiqATASICod", StringUtil.LTrimStr( (decimal)(A1165LiqATASICod), 6, 0));
            }
            A1172LiqAVouNum = cgiGet( edtLiqAVouNum_Internalname);
            AssignAttri("", false, "A1172LiqAVouNum", A1172LiqAVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqATItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqATItem_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQATITEM");
               AnyError = 1;
               GX_FocusControl = edtLiqATItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1167LiqATItem = 0;
               AssignAttri("", false, "A1167LiqATItem", StringUtil.LTrimStr( (decimal)(A1167LiqATItem), 10, 0));
            }
            else
            {
               A1167LiqATItem = (long)(context.localUtil.CToN( cgiGet( edtLiqATItem_Internalname), ".", ","));
               AssignAttri("", false, "A1167LiqATItem", StringUtil.LTrimStr( (decimal)(A1167LiqATItem), 10, 0));
            }
            A1203LiqUsuCod = cgiGet( edtLiqUsuCod_Internalname);
            AssignAttri("", false, "A1203LiqUsuCod", A1203LiqUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtLiqUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "LIQUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtLiqUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1204LiqUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1204LiqUsuFec", context.localUtil.TToC( A1204LiqUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1204LiqUsuFec = context.localUtil.CToT( cgiGet( edtLiqUsuFec_Internalname));
               AssignAttri("", false, "A1204LiqUsuFec", context.localUtil.TToC( A1204LiqUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            A1161LiqAComCod = cgiGet( edtLiqAComCod_Internalname);
            AssignAttri("", false, "A1161LiqAComCod", A1161LiqAComCod);
            A1184LiqMonDsc = cgiGet( edtLiqMonDsc_Internalname);
            AssignAttri("", false, "A1184LiqMonDsc", A1184LiqMonDsc);
            A1200LiqTMovCueCod = cgiGet( edtLiqTMovCueCod_Internalname);
            AssignAttri("", false, "A1200LiqTMovCueCod", A1200LiqTMovCueCod);
            A1168LiqATot = context.localUtil.CToN( cgiGet( edtLiqATot_Internalname), ".", ",");
            n1168LiqATot = false;
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
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
               A270LiqCod = GetPar( "LiqCod");
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = GetPar( "LiqPrvCod");
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A271LiqCodItem = (int)(NumberUtil.Val( GetPar( "LiqCodItem"), "."));
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
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
               InitAll3C115( ) ;
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
         DisableAttributes3C115( ) ;
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

      protected void ResetCaption3C0( )
      {
      }

      protected void ZM3C115( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1178LiqFech = T003C3_A1178LiqFech[0];
               Z1173LiqCheque = T003C3_A1173LiqCheque[0];
               Z1202LiqTotal = T003C3_A1202LiqTotal[0];
               Z1199LiqTItem = T003C3_A1199LiqTItem[0];
               Z1164LiqASts = T003C3_A1164LiqASts[0];
               Z1166LiqATipCod = T003C3_A1166LiqATipCod[0];
               Z1162LiqACXP = T003C3_A1162LiqACXP[0];
               Z1163LiqARegistro = T003C3_A1163LiqARegistro[0];
               Z1170LiqAVouAno = T003C3_A1170LiqAVouAno[0];
               Z1171LiqAVouMes = T003C3_A1171LiqAVouMes[0];
               Z1165LiqATASICod = T003C3_A1165LiqATASICod[0];
               Z1172LiqAVouNum = T003C3_A1172LiqAVouNum[0];
               Z1167LiqATItem = T003C3_A1167LiqATItem[0];
               Z1203LiqUsuCod = T003C3_A1203LiqUsuCod[0];
               Z1204LiqUsuFec = T003C3_A1204LiqUsuFec[0];
               Z1161LiqAComCod = T003C3_A1161LiqAComCod[0];
               Z276LiqMonCod = T003C3_A276LiqMonCod[0];
               Z275LiqForCod = T003C3_A275LiqForCod[0];
               Z273LiqBanCod = T003C3_A273LiqBanCod[0];
               Z274LiqBanCue = T003C3_A274LiqBanCue[0];
               Z272LiqTMovCod = T003C3_A272LiqTMovCod[0];
            }
            else
            {
               Z1178LiqFech = A1178LiqFech;
               Z1173LiqCheque = A1173LiqCheque;
               Z1202LiqTotal = A1202LiqTotal;
               Z1199LiqTItem = A1199LiqTItem;
               Z1164LiqASts = A1164LiqASts;
               Z1166LiqATipCod = A1166LiqATipCod;
               Z1162LiqACXP = A1162LiqACXP;
               Z1163LiqARegistro = A1163LiqARegistro;
               Z1170LiqAVouAno = A1170LiqAVouAno;
               Z1171LiqAVouMes = A1171LiqAVouMes;
               Z1165LiqATASICod = A1165LiqATASICod;
               Z1172LiqAVouNum = A1172LiqAVouNum;
               Z1167LiqATItem = A1167LiqATItem;
               Z1203LiqUsuCod = A1203LiqUsuCod;
               Z1204LiqUsuFec = A1204LiqUsuFec;
               Z1161LiqAComCod = A1161LiqAComCod;
               Z276LiqMonCod = A276LiqMonCod;
               Z275LiqForCod = A275LiqForCod;
               Z273LiqBanCod = A273LiqBanCod;
               Z274LiqBanCue = A274LiqBanCue;
               Z272LiqTMovCod = A272LiqTMovCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z270LiqCod = A270LiqCod;
            Z271LiqCodItem = A271LiqCodItem;
            Z1178LiqFech = A1178LiqFech;
            Z1173LiqCheque = A1173LiqCheque;
            Z1202LiqTotal = A1202LiqTotal;
            Z1199LiqTItem = A1199LiqTItem;
            Z1164LiqASts = A1164LiqASts;
            Z1166LiqATipCod = A1166LiqATipCod;
            Z1162LiqACXP = A1162LiqACXP;
            Z1163LiqARegistro = A1163LiqARegistro;
            Z1170LiqAVouAno = A1170LiqAVouAno;
            Z1171LiqAVouMes = A1171LiqAVouMes;
            Z1165LiqATASICod = A1165LiqATASICod;
            Z1172LiqAVouNum = A1172LiqAVouNum;
            Z1167LiqATItem = A1167LiqATItem;
            Z1203LiqUsuCod = A1203LiqUsuCod;
            Z1204LiqUsuFec = A1204LiqUsuFec;
            Z1161LiqAComCod = A1161LiqAComCod;
            Z236LiqPrvCod = A236LiqPrvCod;
            Z276LiqMonCod = A276LiqMonCod;
            Z275LiqForCod = A275LiqForCod;
            Z273LiqBanCod = A273LiqBanCod;
            Z274LiqBanCue = A274LiqBanCue;
            Z272LiqTMovCod = A272LiqTMovCod;
            Z1197LiqPrvDsc = A1197LiqPrvDsc;
            Z1168LiqATot = A1168LiqATot;
            Z1184LiqMonDsc = A1184LiqMonDsc;
            Z1201LiqTMovDsc = A1201LiqTMovDsc;
            Z1200LiqTMovCueCod = A1200LiqTMovCueCod;
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

      protected void Load3C115( )
      {
         /* Using cursor T003C12 */
         pr_default.execute(8, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound115 = 1;
            A1197LiqPrvDsc = T003C12_A1197LiqPrvDsc[0];
            AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
            A1178LiqFech = T003C12_A1178LiqFech[0];
            AssignAttri("", false, "A1178LiqFech", context.localUtil.Format(A1178LiqFech, "99/99/99"));
            A1173LiqCheque = T003C12_A1173LiqCheque[0];
            AssignAttri("", false, "A1173LiqCheque", A1173LiqCheque);
            A1201LiqTMovDsc = T003C12_A1201LiqTMovDsc[0];
            AssignAttri("", false, "A1201LiqTMovDsc", A1201LiqTMovDsc);
            A1202LiqTotal = T003C12_A1202LiqTotal[0];
            AssignAttri("", false, "A1202LiqTotal", StringUtil.LTrimStr( A1202LiqTotal, 15, 2));
            A1199LiqTItem = T003C12_A1199LiqTItem[0];
            AssignAttri("", false, "A1199LiqTItem", StringUtil.LTrimStr( (decimal)(A1199LiqTItem), 10, 0));
            A1164LiqASts = T003C12_A1164LiqASts[0];
            AssignAttri("", false, "A1164LiqASts", A1164LiqASts);
            A1166LiqATipCod = T003C12_A1166LiqATipCod[0];
            AssignAttri("", false, "A1166LiqATipCod", A1166LiqATipCod);
            A1162LiqACXP = T003C12_A1162LiqACXP[0];
            AssignAttri("", false, "A1162LiqACXP", StringUtil.Str( (decimal)(A1162LiqACXP), 1, 0));
            A1163LiqARegistro = T003C12_A1163LiqARegistro[0];
            AssignAttri("", false, "A1163LiqARegistro", A1163LiqARegistro);
            A1170LiqAVouAno = T003C12_A1170LiqAVouAno[0];
            AssignAttri("", false, "A1170LiqAVouAno", StringUtil.LTrimStr( (decimal)(A1170LiqAVouAno), 4, 0));
            A1171LiqAVouMes = T003C12_A1171LiqAVouMes[0];
            AssignAttri("", false, "A1171LiqAVouMes", StringUtil.LTrimStr( (decimal)(A1171LiqAVouMes), 2, 0));
            A1165LiqATASICod = T003C12_A1165LiqATASICod[0];
            AssignAttri("", false, "A1165LiqATASICod", StringUtil.LTrimStr( (decimal)(A1165LiqATASICod), 6, 0));
            A1172LiqAVouNum = T003C12_A1172LiqAVouNum[0];
            AssignAttri("", false, "A1172LiqAVouNum", A1172LiqAVouNum);
            A1167LiqATItem = T003C12_A1167LiqATItem[0];
            AssignAttri("", false, "A1167LiqATItem", StringUtil.LTrimStr( (decimal)(A1167LiqATItem), 10, 0));
            A1203LiqUsuCod = T003C12_A1203LiqUsuCod[0];
            AssignAttri("", false, "A1203LiqUsuCod", A1203LiqUsuCod);
            A1204LiqUsuFec = T003C12_A1204LiqUsuFec[0];
            AssignAttri("", false, "A1204LiqUsuFec", context.localUtil.TToC( A1204LiqUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1161LiqAComCod = T003C12_A1161LiqAComCod[0];
            AssignAttri("", false, "A1161LiqAComCod", A1161LiqAComCod);
            A1184LiqMonDsc = T003C12_A1184LiqMonDsc[0];
            AssignAttri("", false, "A1184LiqMonDsc", A1184LiqMonDsc);
            A276LiqMonCod = T003C12_A276LiqMonCod[0];
            AssignAttri("", false, "A276LiqMonCod", StringUtil.LTrimStr( (decimal)(A276LiqMonCod), 6, 0));
            A275LiqForCod = T003C12_A275LiqForCod[0];
            AssignAttri("", false, "A275LiqForCod", StringUtil.LTrimStr( (decimal)(A275LiqForCod), 6, 0));
            A273LiqBanCod = T003C12_A273LiqBanCod[0];
            n273LiqBanCod = T003C12_n273LiqBanCod[0];
            AssignAttri("", false, "A273LiqBanCod", StringUtil.LTrimStr( (decimal)(A273LiqBanCod), 6, 0));
            A274LiqBanCue = T003C12_A274LiqBanCue[0];
            n274LiqBanCue = T003C12_n274LiqBanCue[0];
            AssignAttri("", false, "A274LiqBanCue", A274LiqBanCue);
            A272LiqTMovCod = T003C12_A272LiqTMovCod[0];
            n272LiqTMovCod = T003C12_n272LiqTMovCod[0];
            AssignAttri("", false, "A272LiqTMovCod", StringUtil.LTrimStr( (decimal)(A272LiqTMovCod), 6, 0));
            A1200LiqTMovCueCod = T003C12_A1200LiqTMovCueCod[0];
            AssignAttri("", false, "A1200LiqTMovCueCod", A1200LiqTMovCueCod);
            A1168LiqATot = T003C12_A1168LiqATot[0];
            n1168LiqATot = T003C12_n1168LiqATot[0];
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
            ZM3C115( -3) ;
         }
         pr_default.close(8);
         OnLoadActions3C115( ) ;
      }

      protected void OnLoadActions3C115( )
      {
      }

      protected void CheckExtendedTable3C115( )
      {
         nIsDirty_115 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003C4 */
         pr_default.execute(2, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1197LiqPrvDsc = T003C4_A1197LiqPrvDsc[0];
         AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
         pr_default.close(2);
         /* Using cursor T003C10 */
         pr_default.execute(7, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            A1168LiqATot = T003C10_A1168LiqATot[0];
            n1168LiqATot = T003C10_n1168LiqATot[0];
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
         }
         else
         {
            nIsDirty_115 = 1;
            A1168LiqATot = 0;
            n1168LiqATot = false;
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
         }
         pr_default.close(7);
         if ( ! ( (DateTime.MinValue==A1178LiqFech) || ( DateTimeUtil.ResetTime ( A1178LiqFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "LIQFECH");
            AnyError = 1;
            GX_FocusControl = edtLiqFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T003C5 */
         pr_default.execute(3, new Object[] {A276LiqMonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LIQMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1184LiqMonDsc = T003C5_A1184LiqMonDsc[0];
         AssignAttri("", false, "A1184LiqMonDsc", A1184LiqMonDsc);
         pr_default.close(3);
         /* Using cursor T003C6 */
         pr_default.execute(4, new Object[] {A275LiqForCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "LIQFORCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T003C7 */
         pr_default.execute(5, new Object[] {n273LiqBanCod, A273LiqBanCod, n274LiqBanCue, A274LiqBanCue});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A273LiqBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A274LiqBanCue)) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LIQBANCUE");
               AnyError = 1;
               GX_FocusControl = edtLiqBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T003C8 */
         pr_default.execute(6, new Object[] {n272LiqTMovCod, A272LiqTMovCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A272LiqTMovCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Movimiento'.", "ForeignKeyNotFound", 1, "LIQTMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqTMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1201LiqTMovDsc = T003C8_A1201LiqTMovDsc[0];
         AssignAttri("", false, "A1201LiqTMovDsc", A1201LiqTMovDsc);
         A1200LiqTMovCueCod = T003C8_A1200LiqTMovCueCod[0];
         AssignAttri("", false, "A1200LiqTMovCueCod", A1200LiqTMovCueCod);
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A1204LiqUsuFec) || ( A1204LiqUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "LIQUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtLiqUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3C115( )
      {
         pr_default.close(2);
         pr_default.close(7);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A236LiqPrvCod )
      {
         /* Using cursor T003C13 */
         pr_default.execute(9, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1197LiqPrvDsc = T003C13_A1197LiqPrvDsc[0];
         AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1197LiqPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_9( string A270LiqCod ,
                               string A236LiqPrvCod ,
                               int A271LiqCodItem )
      {
         /* Using cursor T003C15 */
         pr_default.execute(10, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A1168LiqATot = T003C15_A1168LiqATot[0];
            n1168LiqATot = T003C15_n1168LiqATot[0];
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
         }
         else
         {
            A1168LiqATot = 0;
            n1168LiqATot = false;
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A1168LiqATot, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_5( int A276LiqMonCod )
      {
         /* Using cursor T003C16 */
         pr_default.execute(11, new Object[] {A276LiqMonCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LIQMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1184LiqMonDsc = T003C16_A1184LiqMonDsc[0];
         AssignAttri("", false, "A1184LiqMonDsc", A1184LiqMonDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1184LiqMonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_6( int A275LiqForCod )
      {
         /* Using cursor T003C17 */
         pr_default.execute(12, new Object[] {A275LiqForCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "LIQFORCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqForCod_Internalname;
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

      protected void gxLoad_7( int A273LiqBanCod ,
                               string A274LiqBanCue )
      {
         /* Using cursor T003C18 */
         pr_default.execute(13, new Object[] {n273LiqBanCod, A273LiqBanCod, n274LiqBanCue, A274LiqBanCue});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A273LiqBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A274LiqBanCue)) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LIQBANCUE");
               AnyError = 1;
               GX_FocusControl = edtLiqBanCod_Internalname;
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

      protected void gxLoad_8( int A272LiqTMovCod )
      {
         /* Using cursor T003C19 */
         pr_default.execute(14, new Object[] {n272LiqTMovCod, A272LiqTMovCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A272LiqTMovCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Movimiento'.", "ForeignKeyNotFound", 1, "LIQTMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqTMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1201LiqTMovDsc = T003C19_A1201LiqTMovDsc[0];
         AssignAttri("", false, "A1201LiqTMovDsc", A1201LiqTMovDsc);
         A1200LiqTMovCueCod = T003C19_A1200LiqTMovCueCod[0];
         AssignAttri("", false, "A1200LiqTMovCueCod", A1200LiqTMovCueCod);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1201LiqTMovDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1200LiqTMovCueCod))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void GetKey3C115( )
      {
         /* Using cursor T003C20 */
         pr_default.execute(15, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound115 = 1;
         }
         else
         {
            RcdFound115 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003C3 */
         pr_default.execute(1, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3C115( 3) ;
            RcdFound115 = 1;
            A270LiqCod = T003C3_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A271LiqCodItem = T003C3_A271LiqCodItem[0];
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            A1178LiqFech = T003C3_A1178LiqFech[0];
            AssignAttri("", false, "A1178LiqFech", context.localUtil.Format(A1178LiqFech, "99/99/99"));
            A1173LiqCheque = T003C3_A1173LiqCheque[0];
            AssignAttri("", false, "A1173LiqCheque", A1173LiqCheque);
            A1202LiqTotal = T003C3_A1202LiqTotal[0];
            AssignAttri("", false, "A1202LiqTotal", StringUtil.LTrimStr( A1202LiqTotal, 15, 2));
            A1199LiqTItem = T003C3_A1199LiqTItem[0];
            AssignAttri("", false, "A1199LiqTItem", StringUtil.LTrimStr( (decimal)(A1199LiqTItem), 10, 0));
            A1164LiqASts = T003C3_A1164LiqASts[0];
            AssignAttri("", false, "A1164LiqASts", A1164LiqASts);
            A1166LiqATipCod = T003C3_A1166LiqATipCod[0];
            AssignAttri("", false, "A1166LiqATipCod", A1166LiqATipCod);
            A1162LiqACXP = T003C3_A1162LiqACXP[0];
            AssignAttri("", false, "A1162LiqACXP", StringUtil.Str( (decimal)(A1162LiqACXP), 1, 0));
            A1163LiqARegistro = T003C3_A1163LiqARegistro[0];
            AssignAttri("", false, "A1163LiqARegistro", A1163LiqARegistro);
            A1170LiqAVouAno = T003C3_A1170LiqAVouAno[0];
            AssignAttri("", false, "A1170LiqAVouAno", StringUtil.LTrimStr( (decimal)(A1170LiqAVouAno), 4, 0));
            A1171LiqAVouMes = T003C3_A1171LiqAVouMes[0];
            AssignAttri("", false, "A1171LiqAVouMes", StringUtil.LTrimStr( (decimal)(A1171LiqAVouMes), 2, 0));
            A1165LiqATASICod = T003C3_A1165LiqATASICod[0];
            AssignAttri("", false, "A1165LiqATASICod", StringUtil.LTrimStr( (decimal)(A1165LiqATASICod), 6, 0));
            A1172LiqAVouNum = T003C3_A1172LiqAVouNum[0];
            AssignAttri("", false, "A1172LiqAVouNum", A1172LiqAVouNum);
            A1167LiqATItem = T003C3_A1167LiqATItem[0];
            AssignAttri("", false, "A1167LiqATItem", StringUtil.LTrimStr( (decimal)(A1167LiqATItem), 10, 0));
            A1203LiqUsuCod = T003C3_A1203LiqUsuCod[0];
            AssignAttri("", false, "A1203LiqUsuCod", A1203LiqUsuCod);
            A1204LiqUsuFec = T003C3_A1204LiqUsuFec[0];
            AssignAttri("", false, "A1204LiqUsuFec", context.localUtil.TToC( A1204LiqUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1161LiqAComCod = T003C3_A1161LiqAComCod[0];
            AssignAttri("", false, "A1161LiqAComCod", A1161LiqAComCod);
            A236LiqPrvCod = T003C3_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A276LiqMonCod = T003C3_A276LiqMonCod[0];
            AssignAttri("", false, "A276LiqMonCod", StringUtil.LTrimStr( (decimal)(A276LiqMonCod), 6, 0));
            A275LiqForCod = T003C3_A275LiqForCod[0];
            AssignAttri("", false, "A275LiqForCod", StringUtil.LTrimStr( (decimal)(A275LiqForCod), 6, 0));
            A273LiqBanCod = T003C3_A273LiqBanCod[0];
            n273LiqBanCod = T003C3_n273LiqBanCod[0];
            AssignAttri("", false, "A273LiqBanCod", StringUtil.LTrimStr( (decimal)(A273LiqBanCod), 6, 0));
            A274LiqBanCue = T003C3_A274LiqBanCue[0];
            n274LiqBanCue = T003C3_n274LiqBanCue[0];
            AssignAttri("", false, "A274LiqBanCue", A274LiqBanCue);
            A272LiqTMovCod = T003C3_A272LiqTMovCod[0];
            n272LiqTMovCod = T003C3_n272LiqTMovCod[0];
            AssignAttri("", false, "A272LiqTMovCod", StringUtil.LTrimStr( (decimal)(A272LiqTMovCod), 6, 0));
            Z270LiqCod = A270LiqCod;
            Z236LiqPrvCod = A236LiqPrvCod;
            Z271LiqCodItem = A271LiqCodItem;
            sMode115 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3C115( ) ;
            if ( AnyError == 1 )
            {
               RcdFound115 = 0;
               InitializeNonKey3C115( ) ;
            }
            Gx_mode = sMode115;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound115 = 0;
            InitializeNonKey3C115( ) ;
            sMode115 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode115;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3C115( ) ;
         if ( RcdFound115 == 0 )
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
         RcdFound115 = 0;
         /* Using cursor T003C21 */
         pr_default.execute(16, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(16) != 101) )
         {
            while ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T003C21_A270LiqCod[0], A270LiqCod) < 0 ) || ( StringUtil.StrCmp(T003C21_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003C21_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) || ( StringUtil.StrCmp(T003C21_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003C21_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003C21_A271LiqCodItem[0] < A271LiqCodItem ) ) )
            {
               pr_default.readNext(16);
            }
            if ( (pr_default.getStatus(16) != 101) && ( ( StringUtil.StrCmp(T003C21_A270LiqCod[0], A270LiqCod) > 0 ) || ( StringUtil.StrCmp(T003C21_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003C21_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) || ( StringUtil.StrCmp(T003C21_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003C21_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003C21_A271LiqCodItem[0] > A271LiqCodItem ) ) )
            {
               A270LiqCod = T003C21_A270LiqCod[0];
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = T003C21_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A271LiqCodItem = T003C21_A271LiqCodItem[0];
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
               RcdFound115 = 1;
            }
         }
         pr_default.close(16);
      }

      protected void move_previous( )
      {
         RcdFound115 = 0;
         /* Using cursor T003C22 */
         pr_default.execute(17, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(17) != 101) )
         {
            while ( (pr_default.getStatus(17) != 101) && ( ( StringUtil.StrCmp(T003C22_A270LiqCod[0], A270LiqCod) > 0 ) || ( StringUtil.StrCmp(T003C22_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003C22_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) || ( StringUtil.StrCmp(T003C22_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003C22_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003C22_A271LiqCodItem[0] > A271LiqCodItem ) ) )
            {
               pr_default.readNext(17);
            }
            if ( (pr_default.getStatus(17) != 101) && ( ( StringUtil.StrCmp(T003C22_A270LiqCod[0], A270LiqCod) < 0 ) || ( StringUtil.StrCmp(T003C22_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003C22_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) || ( StringUtil.StrCmp(T003C22_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003C22_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003C22_A271LiqCodItem[0] < A271LiqCodItem ) ) )
            {
               A270LiqCod = T003C22_A270LiqCod[0];
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = T003C22_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A271LiqCodItem = T003C22_A271LiqCodItem[0];
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
               RcdFound115 = 1;
            }
         }
         pr_default.close(17);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3C115( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3C115( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound115 == 1 )
            {
               if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A271LiqCodItem != Z271LiqCodItem ) )
               {
                  A270LiqCod = Z270LiqCod;
                  AssignAttri("", false, "A270LiqCod", A270LiqCod);
                  A236LiqPrvCod = Z236LiqPrvCod;
                  AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
                  A271LiqCodItem = Z271LiqCodItem;
                  AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LIQCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3C115( ) ;
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A271LiqCodItem != Z271LiqCodItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3C115( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LIQCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLiqCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtLiqCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3C115( ) ;
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
         if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A271LiqCodItem != Z271LiqCodItem ) )
         {
            A270LiqCod = Z270LiqCod;
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = Z236LiqPrvCod;
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A271LiqCodItem = Z271LiqCodItem;
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LIQCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLiqCod_Internalname;
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
         if ( RcdFound115 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LIQCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLiqFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3C115( ) ;
         if ( RcdFound115 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3C115( ) ;
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
         if ( RcdFound115 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqFech_Internalname;
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
         if ( RcdFound115 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqFech_Internalname;
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
         ScanStart3C115( ) ;
         if ( RcdFound115 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound115 != 0 )
            {
               ScanNext3C115( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3C115( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3C115( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003C2 */
            pr_default.execute(0, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLIQUIDACION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1178LiqFech ) != DateTimeUtil.ResetTime ( T003C2_A1178LiqFech[0] ) ) || ( StringUtil.StrCmp(Z1173LiqCheque, T003C2_A1173LiqCheque[0]) != 0 ) || ( Z1202LiqTotal != T003C2_A1202LiqTotal[0] ) || ( Z1199LiqTItem != T003C2_A1199LiqTItem[0] ) || ( StringUtil.StrCmp(Z1164LiqASts, T003C2_A1164LiqASts[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1166LiqATipCod, T003C2_A1166LiqATipCod[0]) != 0 ) || ( Z1162LiqACXP != T003C2_A1162LiqACXP[0] ) || ( StringUtil.StrCmp(Z1163LiqARegistro, T003C2_A1163LiqARegistro[0]) != 0 ) || ( Z1170LiqAVouAno != T003C2_A1170LiqAVouAno[0] ) || ( Z1171LiqAVouMes != T003C2_A1171LiqAVouMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1165LiqATASICod != T003C2_A1165LiqATASICod[0] ) || ( StringUtil.StrCmp(Z1172LiqAVouNum, T003C2_A1172LiqAVouNum[0]) != 0 ) || ( Z1167LiqATItem != T003C2_A1167LiqATItem[0] ) || ( StringUtil.StrCmp(Z1203LiqUsuCod, T003C2_A1203LiqUsuCod[0]) != 0 ) || ( Z1204LiqUsuFec != T003C2_A1204LiqUsuFec[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1161LiqAComCod, T003C2_A1161LiqAComCod[0]) != 0 ) || ( Z276LiqMonCod != T003C2_A276LiqMonCod[0] ) || ( Z275LiqForCod != T003C2_A275LiqForCod[0] ) || ( Z273LiqBanCod != T003C2_A273LiqBanCod[0] ) || ( StringUtil.StrCmp(Z274LiqBanCue, T003C2_A274LiqBanCue[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z272LiqTMovCod != T003C2_A272LiqTMovCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1178LiqFech ) != DateTimeUtil.ResetTime ( T003C2_A1178LiqFech[0] ) )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqFech");
                  GXUtil.WriteLogRaw("Old: ",Z1178LiqFech);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1178LiqFech[0]);
               }
               if ( StringUtil.StrCmp(Z1173LiqCheque, T003C2_A1173LiqCheque[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqCheque");
                  GXUtil.WriteLogRaw("Old: ",Z1173LiqCheque);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1173LiqCheque[0]);
               }
               if ( Z1202LiqTotal != T003C2_A1202LiqTotal[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqTotal");
                  GXUtil.WriteLogRaw("Old: ",Z1202LiqTotal);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1202LiqTotal[0]);
               }
               if ( Z1199LiqTItem != T003C2_A1199LiqTItem[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqTItem");
                  GXUtil.WriteLogRaw("Old: ",Z1199LiqTItem);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1199LiqTItem[0]);
               }
               if ( StringUtil.StrCmp(Z1164LiqASts, T003C2_A1164LiqASts[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqASts");
                  GXUtil.WriteLogRaw("Old: ",Z1164LiqASts);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1164LiqASts[0]);
               }
               if ( StringUtil.StrCmp(Z1166LiqATipCod, T003C2_A1166LiqATipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqATipCod");
                  GXUtil.WriteLogRaw("Old: ",Z1166LiqATipCod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1166LiqATipCod[0]);
               }
               if ( Z1162LiqACXP != T003C2_A1162LiqACXP[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqACXP");
                  GXUtil.WriteLogRaw("Old: ",Z1162LiqACXP);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1162LiqACXP[0]);
               }
               if ( StringUtil.StrCmp(Z1163LiqARegistro, T003C2_A1163LiqARegistro[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqARegistro");
                  GXUtil.WriteLogRaw("Old: ",Z1163LiqARegistro);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1163LiqARegistro[0]);
               }
               if ( Z1170LiqAVouAno != T003C2_A1170LiqAVouAno[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqAVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1170LiqAVouAno);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1170LiqAVouAno[0]);
               }
               if ( Z1171LiqAVouMes != T003C2_A1171LiqAVouMes[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqAVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1171LiqAVouMes);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1171LiqAVouMes[0]);
               }
               if ( Z1165LiqATASICod != T003C2_A1165LiqATASICod[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqATASICod");
                  GXUtil.WriteLogRaw("Old: ",Z1165LiqATASICod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1165LiqATASICod[0]);
               }
               if ( StringUtil.StrCmp(Z1172LiqAVouNum, T003C2_A1172LiqAVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqAVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1172LiqAVouNum);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1172LiqAVouNum[0]);
               }
               if ( Z1167LiqATItem != T003C2_A1167LiqATItem[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqATItem");
                  GXUtil.WriteLogRaw("Old: ",Z1167LiqATItem);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1167LiqATItem[0]);
               }
               if ( StringUtil.StrCmp(Z1203LiqUsuCod, T003C2_A1203LiqUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1203LiqUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1203LiqUsuCod[0]);
               }
               if ( Z1204LiqUsuFec != T003C2_A1204LiqUsuFec[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1204LiqUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1204LiqUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z1161LiqAComCod, T003C2_A1161LiqAComCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqAComCod");
                  GXUtil.WriteLogRaw("Old: ",Z1161LiqAComCod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A1161LiqAComCod[0]);
               }
               if ( Z276LiqMonCod != T003C2_A276LiqMonCod[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z276LiqMonCod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A276LiqMonCod[0]);
               }
               if ( Z275LiqForCod != T003C2_A275LiqForCod[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqForCod");
                  GXUtil.WriteLogRaw("Old: ",Z275LiqForCod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A275LiqForCod[0]);
               }
               if ( Z273LiqBanCod != T003C2_A273LiqBanCod[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z273LiqBanCod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A273LiqBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z274LiqBanCue, T003C2_A274LiqBanCue[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqBanCue");
                  GXUtil.WriteLogRaw("Old: ",Z274LiqBanCue);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A274LiqBanCue[0]);
               }
               if ( Z272LiqTMovCod != T003C2_A272LiqTMovCod[0] )
               {
                  GXUtil.WriteLog("cpliquidacion:[seudo value changed for attri]"+"LiqTMovCod");
                  GXUtil.WriteLogRaw("Old: ",Z272LiqTMovCod);
                  GXUtil.WriteLogRaw("Current: ",T003C2_A272LiqTMovCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPLIQUIDACION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3C115( )
      {
         BeforeValidate3C115( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3C115( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3C115( 0) ;
            CheckOptimisticConcurrency3C115( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3C115( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3C115( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003C23 */
                     pr_default.execute(18, new Object[] {A270LiqCod, A271LiqCodItem, A1178LiqFech, A1173LiqCheque, A1202LiqTotal, A1199LiqTItem, A1164LiqASts, A1166LiqATipCod, A1162LiqACXP, A1163LiqARegistro, A1170LiqAVouAno, A1171LiqAVouMes, A1165LiqATASICod, A1172LiqAVouNum, A1167LiqATItem, A1203LiqUsuCod, A1204LiqUsuFec, A1161LiqAComCod, A236LiqPrvCod, A276LiqMonCod, A275LiqForCod, n273LiqBanCod, A273LiqBanCod, n274LiqBanCue, A274LiqBanCue, n272LiqTMovCod, A272LiqTMovCod});
                     pr_default.close(18);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACION");
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
                           ResetCaption3C0( ) ;
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
               Load3C115( ) ;
            }
            EndLevel3C115( ) ;
         }
         CloseExtendedTableCursors3C115( ) ;
      }

      protected void Update3C115( )
      {
         BeforeValidate3C115( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3C115( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3C115( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3C115( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3C115( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003C24 */
                     pr_default.execute(19, new Object[] {A1178LiqFech, A1173LiqCheque, A1202LiqTotal, A1199LiqTItem, A1164LiqASts, A1166LiqATipCod, A1162LiqACXP, A1163LiqARegistro, A1170LiqAVouAno, A1171LiqAVouMes, A1165LiqATASICod, A1172LiqAVouNum, A1167LiqATItem, A1203LiqUsuCod, A1204LiqUsuFec, A1161LiqAComCod, A276LiqMonCod, A275LiqForCod, n273LiqBanCod, A273LiqBanCod, n274LiqBanCue, A274LiqBanCue, n272LiqTMovCod, A272LiqTMovCod, A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
                     pr_default.close(19);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACION");
                     if ( (pr_default.getStatus(19) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLIQUIDACION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3C115( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3C0( ) ;
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
            EndLevel3C115( ) ;
         }
         CloseExtendedTableCursors3C115( ) ;
      }

      protected void DeferredUpdate3C115( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3C115( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3C115( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3C115( ) ;
            AfterConfirm3C115( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3C115( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003C25 */
                  pr_default.execute(20, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
                  pr_default.close(20);
                  dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound115 == 0 )
                        {
                           InitAll3C115( ) ;
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
                        ResetCaption3C0( ) ;
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
         sMode115 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3C115( ) ;
         Gx_mode = sMode115;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3C115( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003C26 */
            pr_default.execute(21, new Object[] {A236LiqPrvCod});
            A1197LiqPrvDsc = T003C26_A1197LiqPrvDsc[0];
            AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
            pr_default.close(21);
            /* Using cursor T003C28 */
            pr_default.execute(22, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
            if ( (pr_default.getStatus(22) != 101) )
            {
               A1168LiqATot = T003C28_A1168LiqATot[0];
               n1168LiqATot = T003C28_n1168LiqATot[0];
               AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
            }
            else
            {
               A1168LiqATot = 0;
               n1168LiqATot = false;
               AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
            }
            pr_default.close(22);
            /* Using cursor T003C29 */
            pr_default.execute(23, new Object[] {A276LiqMonCod});
            A1184LiqMonDsc = T003C29_A1184LiqMonDsc[0];
            AssignAttri("", false, "A1184LiqMonDsc", A1184LiqMonDsc);
            pr_default.close(23);
            /* Using cursor T003C30 */
            pr_default.execute(24, new Object[] {n272LiqTMovCod, A272LiqTMovCod});
            A1201LiqTMovDsc = T003C30_A1201LiqTMovDsc[0];
            AssignAttri("", false, "A1201LiqTMovDsc", A1201LiqTMovDsc);
            A1200LiqTMovCueCod = T003C30_A1200LiqTMovCueCod[0];
            AssignAttri("", false, "A1200LiqTMovCueCod", A1200LiqTMovCueCod);
            pr_default.close(24);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003C31 */
            pr_default.execute(25, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
         }
      }

      protected void EndLevel3C115( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3C115( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(21);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(22);
            context.CommitDataStores("cpliquidacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(21);
            pr_default.close(23);
            pr_default.close(24);
            pr_default.close(22);
            context.RollbackDataStores("cpliquidacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3C115( )
      {
         /* Using cursor T003C32 */
         pr_default.execute(26);
         RcdFound115 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound115 = 1;
            A270LiqCod = T003C32_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = T003C32_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A271LiqCodItem = T003C32_A271LiqCodItem[0];
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3C115( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound115 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound115 = 1;
            A270LiqCod = T003C32_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = T003C32_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A271LiqCodItem = T003C32_A271LiqCodItem[0];
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
         }
      }

      protected void ScanEnd3C115( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm3C115( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3C115( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3C115( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3C115( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3C115( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3C115( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3C115( )
      {
         edtLiqCod_Enabled = 0;
         AssignProp("", false, edtLiqCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCod_Enabled), 5, 0), true);
         edtLiqPrvCod_Enabled = 0;
         AssignProp("", false, edtLiqPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqPrvCod_Enabled), 5, 0), true);
         edtLiqCodItem_Enabled = 0;
         AssignProp("", false, edtLiqCodItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCodItem_Enabled), 5, 0), true);
         edtLiqPrvDsc_Enabled = 0;
         AssignProp("", false, edtLiqPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqPrvDsc_Enabled), 5, 0), true);
         edtLiqFech_Enabled = 0;
         AssignProp("", false, edtLiqFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqFech_Enabled), 5, 0), true);
         edtLiqMonCod_Enabled = 0;
         AssignProp("", false, edtLiqMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMonCod_Enabled), 5, 0), true);
         edtLiqForCod_Enabled = 0;
         AssignProp("", false, edtLiqForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqForCod_Enabled), 5, 0), true);
         edtLiqBanCod_Enabled = 0;
         AssignProp("", false, edtLiqBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqBanCod_Enabled), 5, 0), true);
         edtLiqBanCue_Enabled = 0;
         AssignProp("", false, edtLiqBanCue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqBanCue_Enabled), 5, 0), true);
         edtLiqCheque_Enabled = 0;
         AssignProp("", false, edtLiqCheque_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCheque_Enabled), 5, 0), true);
         edtLiqTMovCod_Enabled = 0;
         AssignProp("", false, edtLiqTMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqTMovCod_Enabled), 5, 0), true);
         edtLiqTMovDsc_Enabled = 0;
         AssignProp("", false, edtLiqTMovDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqTMovDsc_Enabled), 5, 0), true);
         edtLiqTotal_Enabled = 0;
         AssignProp("", false, edtLiqTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqTotal_Enabled), 5, 0), true);
         edtLiqTItem_Enabled = 0;
         AssignProp("", false, edtLiqTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqTItem_Enabled), 5, 0), true);
         edtLiqASts_Enabled = 0;
         AssignProp("", false, edtLiqASts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqASts_Enabled), 5, 0), true);
         edtLiqATipCod_Enabled = 0;
         AssignProp("", false, edtLiqATipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqATipCod_Enabled), 5, 0), true);
         edtLiqACXP_Enabled = 0;
         AssignProp("", false, edtLiqACXP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqACXP_Enabled), 5, 0), true);
         edtLiqARegistro_Enabled = 0;
         AssignProp("", false, edtLiqARegistro_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqARegistro_Enabled), 5, 0), true);
         edtLiqAVouAno_Enabled = 0;
         AssignProp("", false, edtLiqAVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqAVouAno_Enabled), 5, 0), true);
         edtLiqAVouMes_Enabled = 0;
         AssignProp("", false, edtLiqAVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqAVouMes_Enabled), 5, 0), true);
         edtLiqATASICod_Enabled = 0;
         AssignProp("", false, edtLiqATASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqATASICod_Enabled), 5, 0), true);
         edtLiqAVouNum_Enabled = 0;
         AssignProp("", false, edtLiqAVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqAVouNum_Enabled), 5, 0), true);
         edtLiqATItem_Enabled = 0;
         AssignProp("", false, edtLiqATItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqATItem_Enabled), 5, 0), true);
         edtLiqUsuCod_Enabled = 0;
         AssignProp("", false, edtLiqUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqUsuCod_Enabled), 5, 0), true);
         edtLiqUsuFec_Enabled = 0;
         AssignProp("", false, edtLiqUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqUsuFec_Enabled), 5, 0), true);
         edtLiqAComCod_Enabled = 0;
         AssignProp("", false, edtLiqAComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqAComCod_Enabled), 5, 0), true);
         edtLiqMonDsc_Enabled = 0;
         AssignProp("", false, edtLiqMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMonDsc_Enabled), 5, 0), true);
         edtLiqTMovCueCod_Enabled = 0;
         AssignProp("", false, edtLiqTMovCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqTMovCueCod_Enabled), 5, 0), true);
         edtLiqATot_Enabled = 0;
         AssignProp("", false, edtLiqATot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqATot_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3C115( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810251482", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cpliquidacion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z270LiqCod", Z270LiqCod);
         GxWebStd.gx_hidden_field( context, "Z236LiqPrvCod", StringUtil.RTrim( Z236LiqPrvCod));
         GxWebStd.gx_hidden_field( context, "Z271LiqCodItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z271LiqCodItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1178LiqFech", context.localUtil.DToC( Z1178LiqFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1173LiqCheque", Z1173LiqCheque);
         GxWebStd.gx_hidden_field( context, "Z1202LiqTotal", StringUtil.LTrim( StringUtil.NToC( Z1202LiqTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1199LiqTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1199LiqTItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1164LiqASts", StringUtil.RTrim( Z1164LiqASts));
         GxWebStd.gx_hidden_field( context, "Z1166LiqATipCod", StringUtil.RTrim( Z1166LiqATipCod));
         GxWebStd.gx_hidden_field( context, "Z1162LiqACXP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1162LiqACXP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1163LiqARegistro", Z1163LiqARegistro);
         GxWebStd.gx_hidden_field( context, "Z1170LiqAVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1170LiqAVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1171LiqAVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1171LiqAVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1165LiqATASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1165LiqATASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1172LiqAVouNum", StringUtil.RTrim( Z1172LiqAVouNum));
         GxWebStd.gx_hidden_field( context, "Z1167LiqATItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1167LiqATItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1203LiqUsuCod", StringUtil.RTrim( Z1203LiqUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1204LiqUsuFec", context.localUtil.TToC( Z1204LiqUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1161LiqAComCod", Z1161LiqAComCod);
         GxWebStd.gx_hidden_field( context, "Z276LiqMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z276LiqMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z275LiqForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z275LiqForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z273LiqBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z273LiqBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z274LiqBanCue", StringUtil.RTrim( Z274LiqBanCue));
         GxWebStd.gx_hidden_field( context, "Z272LiqTMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z272LiqTMovCod), 6, 0, ".", "")));
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
         return formatLink("cpliquidacion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPLIQUIDACION" ;
      }

      public override string GetPgmdesc( )
      {
         return "Liquidación" ;
      }

      protected void InitializeNonKey3C115( )
      {
         A1197LiqPrvDsc = "";
         AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
         A1178LiqFech = DateTime.MinValue;
         AssignAttri("", false, "A1178LiqFech", context.localUtil.Format(A1178LiqFech, "99/99/99"));
         A276LiqMonCod = 0;
         AssignAttri("", false, "A276LiqMonCod", StringUtil.LTrimStr( (decimal)(A276LiqMonCod), 6, 0));
         A275LiqForCod = 0;
         AssignAttri("", false, "A275LiqForCod", StringUtil.LTrimStr( (decimal)(A275LiqForCod), 6, 0));
         A273LiqBanCod = 0;
         n273LiqBanCod = false;
         AssignAttri("", false, "A273LiqBanCod", StringUtil.LTrimStr( (decimal)(A273LiqBanCod), 6, 0));
         n273LiqBanCod = ((0==A273LiqBanCod) ? true : false);
         A274LiqBanCue = "";
         n274LiqBanCue = false;
         AssignAttri("", false, "A274LiqBanCue", A274LiqBanCue);
         n274LiqBanCue = (String.IsNullOrEmpty(StringUtil.RTrim( A274LiqBanCue)) ? true : false);
         A1173LiqCheque = "";
         AssignAttri("", false, "A1173LiqCheque", A1173LiqCheque);
         A272LiqTMovCod = 0;
         n272LiqTMovCod = false;
         AssignAttri("", false, "A272LiqTMovCod", StringUtil.LTrimStr( (decimal)(A272LiqTMovCod), 6, 0));
         n272LiqTMovCod = ((0==A272LiqTMovCod) ? true : false);
         A1201LiqTMovDsc = "";
         AssignAttri("", false, "A1201LiqTMovDsc", A1201LiqTMovDsc);
         A1202LiqTotal = 0;
         AssignAttri("", false, "A1202LiqTotal", StringUtil.LTrimStr( A1202LiqTotal, 15, 2));
         A1199LiqTItem = 0;
         AssignAttri("", false, "A1199LiqTItem", StringUtil.LTrimStr( (decimal)(A1199LiqTItem), 10, 0));
         A1164LiqASts = "";
         AssignAttri("", false, "A1164LiqASts", A1164LiqASts);
         A1166LiqATipCod = "";
         AssignAttri("", false, "A1166LiqATipCod", A1166LiqATipCod);
         A1162LiqACXP = 0;
         AssignAttri("", false, "A1162LiqACXP", StringUtil.Str( (decimal)(A1162LiqACXP), 1, 0));
         A1163LiqARegistro = "";
         AssignAttri("", false, "A1163LiqARegistro", A1163LiqARegistro);
         A1170LiqAVouAno = 0;
         AssignAttri("", false, "A1170LiqAVouAno", StringUtil.LTrimStr( (decimal)(A1170LiqAVouAno), 4, 0));
         A1171LiqAVouMes = 0;
         AssignAttri("", false, "A1171LiqAVouMes", StringUtil.LTrimStr( (decimal)(A1171LiqAVouMes), 2, 0));
         A1165LiqATASICod = 0;
         AssignAttri("", false, "A1165LiqATASICod", StringUtil.LTrimStr( (decimal)(A1165LiqATASICod), 6, 0));
         A1172LiqAVouNum = "";
         AssignAttri("", false, "A1172LiqAVouNum", A1172LiqAVouNum);
         A1167LiqATItem = 0;
         AssignAttri("", false, "A1167LiqATItem", StringUtil.LTrimStr( (decimal)(A1167LiqATItem), 10, 0));
         A1203LiqUsuCod = "";
         AssignAttri("", false, "A1203LiqUsuCod", A1203LiqUsuCod);
         A1204LiqUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1204LiqUsuFec", context.localUtil.TToC( A1204LiqUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1161LiqAComCod = "";
         AssignAttri("", false, "A1161LiqAComCod", A1161LiqAComCod);
         A1184LiqMonDsc = "";
         AssignAttri("", false, "A1184LiqMonDsc", A1184LiqMonDsc);
         A1200LiqTMovCueCod = "";
         AssignAttri("", false, "A1200LiqTMovCueCod", A1200LiqTMovCueCod);
         A1168LiqATot = 0;
         n1168LiqATot = false;
         AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
         Z1178LiqFech = DateTime.MinValue;
         Z1173LiqCheque = "";
         Z1202LiqTotal = 0;
         Z1199LiqTItem = 0;
         Z1164LiqASts = "";
         Z1166LiqATipCod = "";
         Z1162LiqACXP = 0;
         Z1163LiqARegistro = "";
         Z1170LiqAVouAno = 0;
         Z1171LiqAVouMes = 0;
         Z1165LiqATASICod = 0;
         Z1172LiqAVouNum = "";
         Z1167LiqATItem = 0;
         Z1203LiqUsuCod = "";
         Z1204LiqUsuFec = (DateTime)(DateTime.MinValue);
         Z1161LiqAComCod = "";
         Z276LiqMonCod = 0;
         Z275LiqForCod = 0;
         Z273LiqBanCod = 0;
         Z274LiqBanCue = "";
         Z272LiqTMovCod = 0;
      }

      protected void InitAll3C115( )
      {
         A270LiqCod = "";
         AssignAttri("", false, "A270LiqCod", A270LiqCod);
         A236LiqPrvCod = "";
         AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
         A271LiqCodItem = 0;
         AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
         InitializeNonKey3C115( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025153", true, true);
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
         context.AddJavascriptSource("cpliquidacion.js", "?20228181025154", false, true);
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
         edtLiqCod_Internalname = "LIQCOD";
         edtLiqPrvCod_Internalname = "LIQPRVCOD";
         edtLiqCodItem_Internalname = "LIQCODITEM";
         edtLiqPrvDsc_Internalname = "LIQPRVDSC";
         edtLiqFech_Internalname = "LIQFECH";
         edtLiqMonCod_Internalname = "LIQMONCOD";
         edtLiqForCod_Internalname = "LIQFORCOD";
         edtLiqBanCod_Internalname = "LIQBANCOD";
         edtLiqBanCue_Internalname = "LIQBANCUE";
         edtLiqCheque_Internalname = "LIQCHEQUE";
         edtLiqTMovCod_Internalname = "LIQTMOVCOD";
         edtLiqTMovDsc_Internalname = "LIQTMOVDSC";
         edtLiqTotal_Internalname = "LIQTOTAL";
         edtLiqTItem_Internalname = "LIQTITEM";
         edtLiqASts_Internalname = "LIQASTS";
         edtLiqATipCod_Internalname = "LIQATIPCOD";
         edtLiqACXP_Internalname = "LIQACXP";
         edtLiqARegistro_Internalname = "LIQAREGISTRO";
         edtLiqAVouAno_Internalname = "LIQAVOUANO";
         edtLiqAVouMes_Internalname = "LIQAVOUMES";
         edtLiqATASICod_Internalname = "LIQATASICOD";
         edtLiqAVouNum_Internalname = "LIQAVOUNUM";
         edtLiqATItem_Internalname = "LIQATITEM";
         edtLiqUsuCod_Internalname = "LIQUSUCOD";
         edtLiqUsuFec_Internalname = "LIQUSUFEC";
         edtLiqAComCod_Internalname = "LIQACOMCOD";
         edtLiqMonDsc_Internalname = "LIQMONDSC";
         edtLiqTMovCueCod_Internalname = "LIQTMOVCUECOD";
         edtLiqATot_Internalname = "LIQATOT";
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
         Form.Caption = "Liquidación";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLiqATot_Jsonclick = "";
         edtLiqATot_Enabled = 0;
         edtLiqTMovCueCod_Jsonclick = "";
         edtLiqTMovCueCod_Enabled = 0;
         edtLiqMonDsc_Jsonclick = "";
         edtLiqMonDsc_Enabled = 0;
         edtLiqAComCod_Jsonclick = "";
         edtLiqAComCod_Enabled = 1;
         edtLiqUsuFec_Jsonclick = "";
         edtLiqUsuFec_Enabled = 1;
         edtLiqUsuCod_Jsonclick = "";
         edtLiqUsuCod_Enabled = 1;
         edtLiqATItem_Jsonclick = "";
         edtLiqATItem_Enabled = 1;
         edtLiqAVouNum_Jsonclick = "";
         edtLiqAVouNum_Enabled = 1;
         edtLiqATASICod_Jsonclick = "";
         edtLiqATASICod_Enabled = 1;
         edtLiqAVouMes_Jsonclick = "";
         edtLiqAVouMes_Enabled = 1;
         edtLiqAVouAno_Jsonclick = "";
         edtLiqAVouAno_Enabled = 1;
         edtLiqARegistro_Jsonclick = "";
         edtLiqARegistro_Enabled = 1;
         edtLiqACXP_Jsonclick = "";
         edtLiqACXP_Enabled = 1;
         edtLiqATipCod_Jsonclick = "";
         edtLiqATipCod_Enabled = 1;
         edtLiqASts_Jsonclick = "";
         edtLiqASts_Enabled = 1;
         edtLiqTItem_Jsonclick = "";
         edtLiqTItem_Enabled = 1;
         edtLiqTotal_Jsonclick = "";
         edtLiqTotal_Enabled = 1;
         edtLiqTMovDsc_Jsonclick = "";
         edtLiqTMovDsc_Enabled = 0;
         edtLiqTMovCod_Jsonclick = "";
         edtLiqTMovCod_Enabled = 1;
         edtLiqCheque_Jsonclick = "";
         edtLiqCheque_Enabled = 1;
         edtLiqBanCue_Jsonclick = "";
         edtLiqBanCue_Enabled = 1;
         edtLiqBanCod_Jsonclick = "";
         edtLiqBanCod_Enabled = 1;
         edtLiqForCod_Jsonclick = "";
         edtLiqForCod_Enabled = 1;
         edtLiqMonCod_Jsonclick = "";
         edtLiqMonCod_Enabled = 1;
         edtLiqFech_Jsonclick = "";
         edtLiqFech_Enabled = 1;
         edtLiqPrvDsc_Jsonclick = "";
         edtLiqPrvDsc_Enabled = 0;
         edtLiqCodItem_Jsonclick = "";
         edtLiqCodItem_Enabled = 1;
         edtLiqPrvCod_Jsonclick = "";
         edtLiqPrvCod_Enabled = 1;
         edtLiqCod_Jsonclick = "";
         edtLiqCod_Enabled = 1;
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
         /* Using cursor T003C26 */
         pr_default.execute(21, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1197LiqPrvDsc = T003C26_A1197LiqPrvDsc[0];
         AssignAttri("", false, "A1197LiqPrvDsc", A1197LiqPrvDsc);
         pr_default.close(21);
         /* Using cursor T003C28 */
         pr_default.execute(22, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(22) != 101) )
         {
            A1168LiqATot = T003C28_A1168LiqATot[0];
            n1168LiqATot = T003C28_n1168LiqATot[0];
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
         }
         else
         {
            A1168LiqATot = 0;
            n1168LiqATot = false;
            AssignAttri("", false, "A1168LiqATot", StringUtil.LTrimStr( A1168LiqATot, 15, 2));
         }
         pr_default.close(22);
         GX_FocusControl = edtLiqFech_Internalname;
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

      public void Valid_Liqprvcod( )
      {
         /* Using cursor T003C26 */
         pr_default.execute(21, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
         }
         A1197LiqPrvDsc = T003C26_A1197LiqPrvDsc[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1197LiqPrvDsc", StringUtil.RTrim( A1197LiqPrvDsc));
      }

      public void Valid_Liqcoditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T003C28 */
         pr_default.execute(22, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(22) != 101) )
         {
            A1168LiqATot = T003C28_A1168LiqATot[0];
            n1168LiqATot = T003C28_n1168LiqATot[0];
         }
         else
         {
            A1168LiqATot = 0;
            n1168LiqATot = false;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1178LiqFech", context.localUtil.Format(A1178LiqFech, "99/99/99"));
         AssignAttri("", false, "A276LiqMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A276LiqMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A275LiqForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A275LiqForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A273LiqBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A273LiqBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A274LiqBanCue", StringUtil.RTrim( A274LiqBanCue));
         AssignAttri("", false, "A1173LiqCheque", A1173LiqCheque);
         AssignAttri("", false, "A272LiqTMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A272LiqTMovCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1202LiqTotal", StringUtil.LTrim( StringUtil.NToC( A1202LiqTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A1199LiqTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1199LiqTItem), 10, 0, ".", "")));
         AssignAttri("", false, "A1164LiqASts", StringUtil.RTrim( A1164LiqASts));
         AssignAttri("", false, "A1166LiqATipCod", StringUtil.RTrim( A1166LiqATipCod));
         AssignAttri("", false, "A1162LiqACXP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1162LiqACXP), 1, 0, ".", "")));
         AssignAttri("", false, "A1163LiqARegistro", A1163LiqARegistro);
         AssignAttri("", false, "A1170LiqAVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1170LiqAVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1171LiqAVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1171LiqAVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1165LiqATASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1165LiqATASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A1172LiqAVouNum", StringUtil.RTrim( A1172LiqAVouNum));
         AssignAttri("", false, "A1167LiqATItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1167LiqATItem), 10, 0, ".", "")));
         AssignAttri("", false, "A1203LiqUsuCod", StringUtil.RTrim( A1203LiqUsuCod));
         AssignAttri("", false, "A1204LiqUsuFec", context.localUtil.TToC( A1204LiqUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1161LiqAComCod", A1161LiqAComCod);
         AssignAttri("", false, "A1197LiqPrvDsc", StringUtil.RTrim( A1197LiqPrvDsc));
         AssignAttri("", false, "A1168LiqATot", StringUtil.LTrim( StringUtil.NToC( A1168LiqATot, 15, 2, ".", "")));
         AssignAttri("", false, "A1184LiqMonDsc", StringUtil.RTrim( A1184LiqMonDsc));
         AssignAttri("", false, "A1201LiqTMovDsc", StringUtil.RTrim( A1201LiqTMovDsc));
         AssignAttri("", false, "A1200LiqTMovCueCod", StringUtil.RTrim( A1200LiqTMovCueCod));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z270LiqCod", Z270LiqCod);
         GxWebStd.gx_hidden_field( context, "Z236LiqPrvCod", StringUtil.RTrim( Z236LiqPrvCod));
         GxWebStd.gx_hidden_field( context, "Z271LiqCodItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z271LiqCodItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1178LiqFech", context.localUtil.Format(Z1178LiqFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z276LiqMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z276LiqMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z275LiqForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z275LiqForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z273LiqBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z273LiqBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z274LiqBanCue", StringUtil.RTrim( Z274LiqBanCue));
         GxWebStd.gx_hidden_field( context, "Z1173LiqCheque", Z1173LiqCheque);
         GxWebStd.gx_hidden_field( context, "Z272LiqTMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z272LiqTMovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1202LiqTotal", StringUtil.LTrim( StringUtil.NToC( Z1202LiqTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1199LiqTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1199LiqTItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1164LiqASts", StringUtil.RTrim( Z1164LiqASts));
         GxWebStd.gx_hidden_field( context, "Z1166LiqATipCod", StringUtil.RTrim( Z1166LiqATipCod));
         GxWebStd.gx_hidden_field( context, "Z1162LiqACXP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1162LiqACXP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1163LiqARegistro", Z1163LiqARegistro);
         GxWebStd.gx_hidden_field( context, "Z1170LiqAVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1170LiqAVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1171LiqAVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1171LiqAVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1165LiqATASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1165LiqATASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1172LiqAVouNum", StringUtil.RTrim( Z1172LiqAVouNum));
         GxWebStd.gx_hidden_field( context, "Z1167LiqATItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1167LiqATItem), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1203LiqUsuCod", StringUtil.RTrim( Z1203LiqUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1204LiqUsuFec", context.localUtil.TToC( Z1204LiqUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1161LiqAComCod", Z1161LiqAComCod);
         GxWebStd.gx_hidden_field( context, "Z1197LiqPrvDsc", StringUtil.RTrim( Z1197LiqPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1168LiqATot", StringUtil.LTrim( StringUtil.NToC( Z1168LiqATot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1184LiqMonDsc", StringUtil.RTrim( Z1184LiqMonDsc));
         GxWebStd.gx_hidden_field( context, "Z1201LiqTMovDsc", StringUtil.RTrim( Z1201LiqTMovDsc));
         GxWebStd.gx_hidden_field( context, "Z1200LiqTMovCueCod", StringUtil.RTrim( Z1200LiqTMovCueCod));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Liqmoncod( )
      {
         /* Using cursor T003C29 */
         pr_default.execute(23, new Object[] {A276LiqMonCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "LIQMONCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMonCod_Internalname;
         }
         A1184LiqMonDsc = T003C29_A1184LiqMonDsc[0];
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1184LiqMonDsc", StringUtil.RTrim( A1184LiqMonDsc));
      }

      public void Valid_Liqforcod( )
      {
         /* Using cursor T003C33 */
         pr_default.execute(27, new Object[] {A275LiqForCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "LIQFORCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqForCod_Internalname;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Liqbancue( )
      {
         n273LiqBanCod = false;
         n274LiqBanCue = false;
         /* Using cursor T003C34 */
         pr_default.execute(28, new Object[] {n273LiqBanCod, A273LiqBanCod, n274LiqBanCue, A274LiqBanCue});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( (0==A273LiqBanCod) || String.IsNullOrEmpty(StringUtil.RTrim( A274LiqBanCue)) ) )
            {
               GX_msglist.addItem("No existe 'Banco'.", "ForeignKeyNotFound", 1, "LIQBANCUE");
               AnyError = 1;
               GX_FocusControl = edtLiqBanCod_Internalname;
            }
         }
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Liqtmovcod( )
      {
         n272LiqTMovCod = false;
         /* Using cursor T003C30 */
         pr_default.execute(24, new Object[] {n272LiqTMovCod, A272LiqTMovCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( (0==A272LiqTMovCod) ) )
            {
               GX_msglist.addItem("No existe 'Tipo de Movimiento'.", "ForeignKeyNotFound", 1, "LIQTMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqTMovCod_Internalname;
            }
         }
         A1201LiqTMovDsc = T003C30_A1201LiqTMovDsc[0];
         A1200LiqTMovCueCod = T003C30_A1200LiqTMovCueCod[0];
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1201LiqTMovDsc", StringUtil.RTrim( A1201LiqTMovDsc));
         AssignAttri("", false, "A1200LiqTMovCueCod", StringUtil.RTrim( A1200LiqTMovCueCod));
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
         setEventMetadata("VALID_LIQCOD","{handler:'Valid_Liqcod',iparms:[]");
         setEventMetadata("VALID_LIQCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQPRVCOD","{handler:'Valid_Liqprvcod',iparms:[{av:'A236LiqPrvCod',fld:'LIQPRVCOD',pic:''},{av:'A1197LiqPrvDsc',fld:'LIQPRVDSC',pic:''}]");
         setEventMetadata("VALID_LIQPRVCOD",",oparms:[{av:'A1197LiqPrvDsc',fld:'LIQPRVDSC',pic:''}]}");
         setEventMetadata("VALID_LIQCODITEM","{handler:'Valid_Liqcoditem',iparms:[{av:'A270LiqCod',fld:'LIQCOD',pic:''},{av:'A236LiqPrvCod',fld:'LIQPRVCOD',pic:''},{av:'A271LiqCodItem',fld:'LIQCODITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LIQCODITEM",",oparms:[{av:'A1178LiqFech',fld:'LIQFECH',pic:''},{av:'A276LiqMonCod',fld:'LIQMONCOD',pic:'ZZZZZ9'},{av:'A275LiqForCod',fld:'LIQFORCOD',pic:'ZZZZZ9'},{av:'A273LiqBanCod',fld:'LIQBANCOD',pic:'ZZZZZ9'},{av:'A274LiqBanCue',fld:'LIQBANCUE',pic:''},{av:'A1173LiqCheque',fld:'LIQCHEQUE',pic:''},{av:'A272LiqTMovCod',fld:'LIQTMOVCOD',pic:'ZZZZZ9'},{av:'A1202LiqTotal',fld:'LIQTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1199LiqTItem',fld:'LIQTITEM',pic:'ZZZZZZZZZ9'},{av:'A1164LiqASts',fld:'LIQASTS',pic:''},{av:'A1166LiqATipCod',fld:'LIQATIPCOD',pic:''},{av:'A1162LiqACXP',fld:'LIQACXP',pic:'9'},{av:'A1163LiqARegistro',fld:'LIQAREGISTRO',pic:''},{av:'A1170LiqAVouAno',fld:'LIQAVOUANO',pic:'ZZZ9'},{av:'A1171LiqAVouMes',fld:'LIQAVOUMES',pic:'Z9'},{av:'A1165LiqATASICod',fld:'LIQATASICOD',pic:'ZZZZZ9'},{av:'A1172LiqAVouNum',fld:'LIQAVOUNUM',pic:''},{av:'A1167LiqATItem',fld:'LIQATITEM',pic:'ZZZZZZZZZ9'},{av:'A1203LiqUsuCod',fld:'LIQUSUCOD',pic:''},{av:'A1204LiqUsuFec',fld:'LIQUSUFEC',pic:'99/99/99 99:99'},{av:'A1161LiqAComCod',fld:'LIQACOMCOD',pic:''},{av:'A1197LiqPrvDsc',fld:'LIQPRVDSC',pic:''},{av:'A1168LiqATot',fld:'LIQATOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1184LiqMonDsc',fld:'LIQMONDSC',pic:''},{av:'A1201LiqTMovDsc',fld:'LIQTMOVDSC',pic:''},{av:'A1200LiqTMovCueCod',fld:'LIQTMOVCUECOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z270LiqCod'},{av:'Z236LiqPrvCod'},{av:'Z271LiqCodItem'},{av:'Z1178LiqFech'},{av:'Z276LiqMonCod'},{av:'Z275LiqForCod'},{av:'Z273LiqBanCod'},{av:'Z274LiqBanCue'},{av:'Z1173LiqCheque'},{av:'Z272LiqTMovCod'},{av:'Z1202LiqTotal'},{av:'Z1199LiqTItem'},{av:'Z1164LiqASts'},{av:'Z1166LiqATipCod'},{av:'Z1162LiqACXP'},{av:'Z1163LiqARegistro'},{av:'Z1170LiqAVouAno'},{av:'Z1171LiqAVouMes'},{av:'Z1165LiqATASICod'},{av:'Z1172LiqAVouNum'},{av:'Z1167LiqATItem'},{av:'Z1203LiqUsuCod'},{av:'Z1204LiqUsuFec'},{av:'Z1161LiqAComCod'},{av:'Z1197LiqPrvDsc'},{av:'Z1168LiqATot'},{av:'Z1184LiqMonDsc'},{av:'Z1201LiqTMovDsc'},{av:'Z1200LiqTMovCueCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_LIQFECH","{handler:'Valid_Liqfech',iparms:[]");
         setEventMetadata("VALID_LIQFECH",",oparms:[]}");
         setEventMetadata("VALID_LIQMONCOD","{handler:'Valid_Liqmoncod',iparms:[{av:'A276LiqMonCod',fld:'LIQMONCOD',pic:'ZZZZZ9'},{av:'A1184LiqMonDsc',fld:'LIQMONDSC',pic:''}]");
         setEventMetadata("VALID_LIQMONCOD",",oparms:[{av:'A1184LiqMonDsc',fld:'LIQMONDSC',pic:''}]}");
         setEventMetadata("VALID_LIQFORCOD","{handler:'Valid_Liqforcod',iparms:[{av:'A275LiqForCod',fld:'LIQFORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LIQFORCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQBANCOD","{handler:'Valid_Liqbancod',iparms:[]");
         setEventMetadata("VALID_LIQBANCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQBANCUE","{handler:'Valid_Liqbancue',iparms:[{av:'A273LiqBanCod',fld:'LIQBANCOD',pic:'ZZZZZ9'},{av:'A274LiqBanCue',fld:'LIQBANCUE',pic:''}]");
         setEventMetadata("VALID_LIQBANCUE",",oparms:[]}");
         setEventMetadata("VALID_LIQTMOVCOD","{handler:'Valid_Liqtmovcod',iparms:[{av:'A272LiqTMovCod',fld:'LIQTMOVCOD',pic:'ZZZZZ9'},{av:'A1201LiqTMovDsc',fld:'LIQTMOVDSC',pic:''},{av:'A1200LiqTMovCueCod',fld:'LIQTMOVCUECOD',pic:''}]");
         setEventMetadata("VALID_LIQTMOVCOD",",oparms:[{av:'A1201LiqTMovDsc',fld:'LIQTMOVDSC',pic:''},{av:'A1200LiqTMovCueCod',fld:'LIQTMOVCUECOD',pic:''}]}");
         setEventMetadata("VALID_LIQUSUFEC","{handler:'Valid_Liqusufec',iparms:[]");
         setEventMetadata("VALID_LIQUSUFEC",",oparms:[]}");
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
         pr_default.close(23);
         pr_default.close(27);
         pr_default.close(28);
         pr_default.close(24);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z270LiqCod = "";
         Z236LiqPrvCod = "";
         Z1178LiqFech = DateTime.MinValue;
         Z1173LiqCheque = "";
         Z1164LiqASts = "";
         Z1166LiqATipCod = "";
         Z1163LiqARegistro = "";
         Z1172LiqAVouNum = "";
         Z1203LiqUsuCod = "";
         Z1204LiqUsuFec = (DateTime)(DateTime.MinValue);
         Z1161LiqAComCod = "";
         Z274LiqBanCue = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A236LiqPrvCod = "";
         A270LiqCod = "";
         A274LiqBanCue = "";
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
         A1197LiqPrvDsc = "";
         A1178LiqFech = DateTime.MinValue;
         A1173LiqCheque = "";
         A1201LiqTMovDsc = "";
         A1164LiqASts = "";
         A1166LiqATipCod = "";
         A1163LiqARegistro = "";
         A1172LiqAVouNum = "";
         A1203LiqUsuCod = "";
         A1204LiqUsuFec = (DateTime)(DateTime.MinValue);
         A1161LiqAComCod = "";
         A1184LiqMonDsc = "";
         A1200LiqTMovCueCod = "";
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
         Z1197LiqPrvDsc = "";
         Z1184LiqMonDsc = "";
         Z1201LiqTMovDsc = "";
         Z1200LiqTMovCueCod = "";
         T003C12_A270LiqCod = new string[] {""} ;
         T003C12_A271LiqCodItem = new int[1] ;
         T003C12_A1197LiqPrvDsc = new string[] {""} ;
         T003C12_A1178LiqFech = new DateTime[] {DateTime.MinValue} ;
         T003C12_A1173LiqCheque = new string[] {""} ;
         T003C12_A1201LiqTMovDsc = new string[] {""} ;
         T003C12_A1202LiqTotal = new decimal[1] ;
         T003C12_A1199LiqTItem = new long[1] ;
         T003C12_A1164LiqASts = new string[] {""} ;
         T003C12_A1166LiqATipCod = new string[] {""} ;
         T003C12_A1162LiqACXP = new short[1] ;
         T003C12_A1163LiqARegistro = new string[] {""} ;
         T003C12_A1170LiqAVouAno = new short[1] ;
         T003C12_A1171LiqAVouMes = new short[1] ;
         T003C12_A1165LiqATASICod = new int[1] ;
         T003C12_A1172LiqAVouNum = new string[] {""} ;
         T003C12_A1167LiqATItem = new long[1] ;
         T003C12_A1203LiqUsuCod = new string[] {""} ;
         T003C12_A1204LiqUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003C12_A1161LiqAComCod = new string[] {""} ;
         T003C12_A1184LiqMonDsc = new string[] {""} ;
         T003C12_A236LiqPrvCod = new string[] {""} ;
         T003C12_A276LiqMonCod = new int[1] ;
         T003C12_A275LiqForCod = new int[1] ;
         T003C12_A273LiqBanCod = new int[1] ;
         T003C12_n273LiqBanCod = new bool[] {false} ;
         T003C12_A274LiqBanCue = new string[] {""} ;
         T003C12_n274LiqBanCue = new bool[] {false} ;
         T003C12_A272LiqTMovCod = new int[1] ;
         T003C12_n272LiqTMovCod = new bool[] {false} ;
         T003C12_A1200LiqTMovCueCod = new string[] {""} ;
         T003C12_A1168LiqATot = new decimal[1] ;
         T003C12_n1168LiqATot = new bool[] {false} ;
         T003C4_A1197LiqPrvDsc = new string[] {""} ;
         T003C10_A1168LiqATot = new decimal[1] ;
         T003C10_n1168LiqATot = new bool[] {false} ;
         T003C5_A1184LiqMonDsc = new string[] {""} ;
         T003C6_A275LiqForCod = new int[1] ;
         T003C7_A273LiqBanCod = new int[1] ;
         T003C7_n273LiqBanCod = new bool[] {false} ;
         T003C8_A1201LiqTMovDsc = new string[] {""} ;
         T003C8_A1200LiqTMovCueCod = new string[] {""} ;
         T003C13_A1197LiqPrvDsc = new string[] {""} ;
         T003C15_A1168LiqATot = new decimal[1] ;
         T003C15_n1168LiqATot = new bool[] {false} ;
         T003C16_A1184LiqMonDsc = new string[] {""} ;
         T003C17_A275LiqForCod = new int[1] ;
         T003C18_A273LiqBanCod = new int[1] ;
         T003C18_n273LiqBanCod = new bool[] {false} ;
         T003C19_A1201LiqTMovDsc = new string[] {""} ;
         T003C19_A1200LiqTMovCueCod = new string[] {""} ;
         T003C20_A270LiqCod = new string[] {""} ;
         T003C20_A236LiqPrvCod = new string[] {""} ;
         T003C20_A271LiqCodItem = new int[1] ;
         T003C3_A270LiqCod = new string[] {""} ;
         T003C3_A271LiqCodItem = new int[1] ;
         T003C3_A1178LiqFech = new DateTime[] {DateTime.MinValue} ;
         T003C3_A1173LiqCheque = new string[] {""} ;
         T003C3_A1202LiqTotal = new decimal[1] ;
         T003C3_A1199LiqTItem = new long[1] ;
         T003C3_A1164LiqASts = new string[] {""} ;
         T003C3_A1166LiqATipCod = new string[] {""} ;
         T003C3_A1162LiqACXP = new short[1] ;
         T003C3_A1163LiqARegistro = new string[] {""} ;
         T003C3_A1170LiqAVouAno = new short[1] ;
         T003C3_A1171LiqAVouMes = new short[1] ;
         T003C3_A1165LiqATASICod = new int[1] ;
         T003C3_A1172LiqAVouNum = new string[] {""} ;
         T003C3_A1167LiqATItem = new long[1] ;
         T003C3_A1203LiqUsuCod = new string[] {""} ;
         T003C3_A1204LiqUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003C3_A1161LiqAComCod = new string[] {""} ;
         T003C3_A236LiqPrvCod = new string[] {""} ;
         T003C3_A276LiqMonCod = new int[1] ;
         T003C3_A275LiqForCod = new int[1] ;
         T003C3_A273LiqBanCod = new int[1] ;
         T003C3_n273LiqBanCod = new bool[] {false} ;
         T003C3_A274LiqBanCue = new string[] {""} ;
         T003C3_n274LiqBanCue = new bool[] {false} ;
         T003C3_A272LiqTMovCod = new int[1] ;
         T003C3_n272LiqTMovCod = new bool[] {false} ;
         sMode115 = "";
         T003C21_A270LiqCod = new string[] {""} ;
         T003C21_A236LiqPrvCod = new string[] {""} ;
         T003C21_A271LiqCodItem = new int[1] ;
         T003C22_A270LiqCod = new string[] {""} ;
         T003C22_A236LiqPrvCod = new string[] {""} ;
         T003C22_A271LiqCodItem = new int[1] ;
         T003C2_A270LiqCod = new string[] {""} ;
         T003C2_A271LiqCodItem = new int[1] ;
         T003C2_A1178LiqFech = new DateTime[] {DateTime.MinValue} ;
         T003C2_A1173LiqCheque = new string[] {""} ;
         T003C2_A1202LiqTotal = new decimal[1] ;
         T003C2_A1199LiqTItem = new long[1] ;
         T003C2_A1164LiqASts = new string[] {""} ;
         T003C2_A1166LiqATipCod = new string[] {""} ;
         T003C2_A1162LiqACXP = new short[1] ;
         T003C2_A1163LiqARegistro = new string[] {""} ;
         T003C2_A1170LiqAVouAno = new short[1] ;
         T003C2_A1171LiqAVouMes = new short[1] ;
         T003C2_A1165LiqATASICod = new int[1] ;
         T003C2_A1172LiqAVouNum = new string[] {""} ;
         T003C2_A1167LiqATItem = new long[1] ;
         T003C2_A1203LiqUsuCod = new string[] {""} ;
         T003C2_A1204LiqUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003C2_A1161LiqAComCod = new string[] {""} ;
         T003C2_A236LiqPrvCod = new string[] {""} ;
         T003C2_A276LiqMonCod = new int[1] ;
         T003C2_A275LiqForCod = new int[1] ;
         T003C2_A273LiqBanCod = new int[1] ;
         T003C2_n273LiqBanCod = new bool[] {false} ;
         T003C2_A274LiqBanCue = new string[] {""} ;
         T003C2_n274LiqBanCue = new bool[] {false} ;
         T003C2_A272LiqTMovCod = new int[1] ;
         T003C2_n272LiqTMovCod = new bool[] {false} ;
         T003C26_A1197LiqPrvDsc = new string[] {""} ;
         T003C28_A1168LiqATot = new decimal[1] ;
         T003C28_n1168LiqATot = new bool[] {false} ;
         T003C29_A1184LiqMonDsc = new string[] {""} ;
         T003C30_A1201LiqTMovDsc = new string[] {""} ;
         T003C30_A1200LiqTMovCueCod = new string[] {""} ;
         T003C31_A270LiqCod = new string[] {""} ;
         T003C31_A236LiqPrvCod = new string[] {""} ;
         T003C31_A271LiqCodItem = new int[1] ;
         T003C31_A282LiqDItem = new int[1] ;
         T003C32_A270LiqCod = new string[] {""} ;
         T003C32_A236LiqPrvCod = new string[] {""} ;
         T003C32_A271LiqCodItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ270LiqCod = "";
         ZZ236LiqPrvCod = "";
         ZZ1178LiqFech = DateTime.MinValue;
         ZZ274LiqBanCue = "";
         ZZ1173LiqCheque = "";
         ZZ1164LiqASts = "";
         ZZ1166LiqATipCod = "";
         ZZ1163LiqARegistro = "";
         ZZ1172LiqAVouNum = "";
         ZZ1203LiqUsuCod = "";
         ZZ1204LiqUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1161LiqAComCod = "";
         ZZ1197LiqPrvDsc = "";
         ZZ1184LiqMonDsc = "";
         ZZ1201LiqTMovDsc = "";
         ZZ1200LiqTMovCueCod = "";
         T003C33_A275LiqForCod = new int[1] ;
         T003C34_A273LiqBanCod = new int[1] ;
         T003C34_n273LiqBanCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpliquidacion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpliquidacion__default(),
            new Object[][] {
                new Object[] {
               T003C2_A270LiqCod, T003C2_A271LiqCodItem, T003C2_A1178LiqFech, T003C2_A1173LiqCheque, T003C2_A1202LiqTotal, T003C2_A1199LiqTItem, T003C2_A1164LiqASts, T003C2_A1166LiqATipCod, T003C2_A1162LiqACXP, T003C2_A1163LiqARegistro,
               T003C2_A1170LiqAVouAno, T003C2_A1171LiqAVouMes, T003C2_A1165LiqATASICod, T003C2_A1172LiqAVouNum, T003C2_A1167LiqATItem, T003C2_A1203LiqUsuCod, T003C2_A1204LiqUsuFec, T003C2_A1161LiqAComCod, T003C2_A236LiqPrvCod, T003C2_A276LiqMonCod,
               T003C2_A275LiqForCod, T003C2_A273LiqBanCod, T003C2_n273LiqBanCod, T003C2_A274LiqBanCue, T003C2_n274LiqBanCue, T003C2_A272LiqTMovCod, T003C2_n272LiqTMovCod
               }
               , new Object[] {
               T003C3_A270LiqCod, T003C3_A271LiqCodItem, T003C3_A1178LiqFech, T003C3_A1173LiqCheque, T003C3_A1202LiqTotal, T003C3_A1199LiqTItem, T003C3_A1164LiqASts, T003C3_A1166LiqATipCod, T003C3_A1162LiqACXP, T003C3_A1163LiqARegistro,
               T003C3_A1170LiqAVouAno, T003C3_A1171LiqAVouMes, T003C3_A1165LiqATASICod, T003C3_A1172LiqAVouNum, T003C3_A1167LiqATItem, T003C3_A1203LiqUsuCod, T003C3_A1204LiqUsuFec, T003C3_A1161LiqAComCod, T003C3_A236LiqPrvCod, T003C3_A276LiqMonCod,
               T003C3_A275LiqForCod, T003C3_A273LiqBanCod, T003C3_n273LiqBanCod, T003C3_A274LiqBanCue, T003C3_n274LiqBanCue, T003C3_A272LiqTMovCod, T003C3_n272LiqTMovCod
               }
               , new Object[] {
               T003C4_A1197LiqPrvDsc
               }
               , new Object[] {
               T003C5_A1184LiqMonDsc
               }
               , new Object[] {
               T003C6_A275LiqForCod
               }
               , new Object[] {
               T003C7_A273LiqBanCod
               }
               , new Object[] {
               T003C8_A1201LiqTMovDsc, T003C8_A1200LiqTMovCueCod
               }
               , new Object[] {
               T003C10_A1168LiqATot, T003C10_n1168LiqATot
               }
               , new Object[] {
               T003C12_A270LiqCod, T003C12_A271LiqCodItem, T003C12_A1197LiqPrvDsc, T003C12_A1178LiqFech, T003C12_A1173LiqCheque, T003C12_A1201LiqTMovDsc, T003C12_A1202LiqTotal, T003C12_A1199LiqTItem, T003C12_A1164LiqASts, T003C12_A1166LiqATipCod,
               T003C12_A1162LiqACXP, T003C12_A1163LiqARegistro, T003C12_A1170LiqAVouAno, T003C12_A1171LiqAVouMes, T003C12_A1165LiqATASICod, T003C12_A1172LiqAVouNum, T003C12_A1167LiqATItem, T003C12_A1203LiqUsuCod, T003C12_A1204LiqUsuFec, T003C12_A1161LiqAComCod,
               T003C12_A1184LiqMonDsc, T003C12_A236LiqPrvCod, T003C12_A276LiqMonCod, T003C12_A275LiqForCod, T003C12_A273LiqBanCod, T003C12_n273LiqBanCod, T003C12_A274LiqBanCue, T003C12_n274LiqBanCue, T003C12_A272LiqTMovCod, T003C12_n272LiqTMovCod,
               T003C12_A1200LiqTMovCueCod, T003C12_A1168LiqATot, T003C12_n1168LiqATot
               }
               , new Object[] {
               T003C13_A1197LiqPrvDsc
               }
               , new Object[] {
               T003C15_A1168LiqATot, T003C15_n1168LiqATot
               }
               , new Object[] {
               T003C16_A1184LiqMonDsc
               }
               , new Object[] {
               T003C17_A275LiqForCod
               }
               , new Object[] {
               T003C18_A273LiqBanCod
               }
               , new Object[] {
               T003C19_A1201LiqTMovDsc, T003C19_A1200LiqTMovCueCod
               }
               , new Object[] {
               T003C20_A270LiqCod, T003C20_A236LiqPrvCod, T003C20_A271LiqCodItem
               }
               , new Object[] {
               T003C21_A270LiqCod, T003C21_A236LiqPrvCod, T003C21_A271LiqCodItem
               }
               , new Object[] {
               T003C22_A270LiqCod, T003C22_A236LiqPrvCod, T003C22_A271LiqCodItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003C26_A1197LiqPrvDsc
               }
               , new Object[] {
               T003C28_A1168LiqATot, T003C28_n1168LiqATot
               }
               , new Object[] {
               T003C29_A1184LiqMonDsc
               }
               , new Object[] {
               T003C30_A1201LiqTMovDsc, T003C30_A1200LiqTMovCueCod
               }
               , new Object[] {
               T003C31_A270LiqCod, T003C31_A236LiqPrvCod, T003C31_A271LiqCodItem, T003C31_A282LiqDItem
               }
               , new Object[] {
               T003C32_A270LiqCod, T003C32_A236LiqPrvCod, T003C32_A271LiqCodItem
               }
               , new Object[] {
               T003C33_A275LiqForCod
               }
               , new Object[] {
               T003C34_A273LiqBanCod
               }
            }
         );
      }

      private short Z1162LiqACXP ;
      private short Z1170LiqAVouAno ;
      private short Z1171LiqAVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1162LiqACXP ;
      private short A1170LiqAVouAno ;
      private short A1171LiqAVouMes ;
      private short GX_JID ;
      private short RcdFound115 ;
      private short nIsDirty_115 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1162LiqACXP ;
      private short ZZ1170LiqAVouAno ;
      private short ZZ1171LiqAVouMes ;
      private int Z271LiqCodItem ;
      private int Z1165LiqATASICod ;
      private int Z276LiqMonCod ;
      private int Z275LiqForCod ;
      private int Z273LiqBanCod ;
      private int Z272LiqTMovCod ;
      private int A271LiqCodItem ;
      private int A276LiqMonCod ;
      private int A275LiqForCod ;
      private int A273LiqBanCod ;
      private int A272LiqTMovCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLiqCod_Enabled ;
      private int edtLiqPrvCod_Enabled ;
      private int edtLiqCodItem_Enabled ;
      private int edtLiqPrvDsc_Enabled ;
      private int edtLiqFech_Enabled ;
      private int edtLiqMonCod_Enabled ;
      private int edtLiqForCod_Enabled ;
      private int edtLiqBanCod_Enabled ;
      private int edtLiqBanCue_Enabled ;
      private int edtLiqCheque_Enabled ;
      private int edtLiqTMovCod_Enabled ;
      private int edtLiqTMovDsc_Enabled ;
      private int edtLiqTotal_Enabled ;
      private int edtLiqTItem_Enabled ;
      private int edtLiqASts_Enabled ;
      private int edtLiqATipCod_Enabled ;
      private int edtLiqACXP_Enabled ;
      private int edtLiqARegistro_Enabled ;
      private int edtLiqAVouAno_Enabled ;
      private int edtLiqAVouMes_Enabled ;
      private int A1165LiqATASICod ;
      private int edtLiqATASICod_Enabled ;
      private int edtLiqAVouNum_Enabled ;
      private int edtLiqATItem_Enabled ;
      private int edtLiqUsuCod_Enabled ;
      private int edtLiqUsuFec_Enabled ;
      private int edtLiqAComCod_Enabled ;
      private int edtLiqMonDsc_Enabled ;
      private int edtLiqTMovCueCod_Enabled ;
      private int edtLiqATot_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ271LiqCodItem ;
      private int ZZ276LiqMonCod ;
      private int ZZ275LiqForCod ;
      private int ZZ273LiqBanCod ;
      private int ZZ272LiqTMovCod ;
      private int ZZ1165LiqATASICod ;
      private long Z1199LiqTItem ;
      private long Z1167LiqATItem ;
      private long A1199LiqTItem ;
      private long A1167LiqATItem ;
      private long ZZ1199LiqTItem ;
      private long ZZ1167LiqATItem ;
      private decimal Z1202LiqTotal ;
      private decimal A1202LiqTotal ;
      private decimal A1168LiqATot ;
      private decimal Z1168LiqATot ;
      private decimal ZZ1202LiqTotal ;
      private decimal ZZ1168LiqATot ;
      private string sPrefix ;
      private string Z236LiqPrvCod ;
      private string Z1164LiqASts ;
      private string Z1166LiqATipCod ;
      private string Z1172LiqAVouNum ;
      private string Z1203LiqUsuCod ;
      private string Z274LiqBanCue ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A236LiqPrvCod ;
      private string A274LiqBanCue ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLiqCod_Internalname ;
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
      private string edtLiqCod_Jsonclick ;
      private string edtLiqPrvCod_Internalname ;
      private string edtLiqPrvCod_Jsonclick ;
      private string edtLiqCodItem_Internalname ;
      private string edtLiqCodItem_Jsonclick ;
      private string edtLiqPrvDsc_Internalname ;
      private string A1197LiqPrvDsc ;
      private string edtLiqPrvDsc_Jsonclick ;
      private string edtLiqFech_Internalname ;
      private string edtLiqFech_Jsonclick ;
      private string edtLiqMonCod_Internalname ;
      private string edtLiqMonCod_Jsonclick ;
      private string edtLiqForCod_Internalname ;
      private string edtLiqForCod_Jsonclick ;
      private string edtLiqBanCod_Internalname ;
      private string edtLiqBanCod_Jsonclick ;
      private string edtLiqBanCue_Internalname ;
      private string edtLiqBanCue_Jsonclick ;
      private string edtLiqCheque_Internalname ;
      private string edtLiqCheque_Jsonclick ;
      private string edtLiqTMovCod_Internalname ;
      private string edtLiqTMovCod_Jsonclick ;
      private string edtLiqTMovDsc_Internalname ;
      private string A1201LiqTMovDsc ;
      private string edtLiqTMovDsc_Jsonclick ;
      private string edtLiqTotal_Internalname ;
      private string edtLiqTotal_Jsonclick ;
      private string edtLiqTItem_Internalname ;
      private string edtLiqTItem_Jsonclick ;
      private string edtLiqASts_Internalname ;
      private string A1164LiqASts ;
      private string edtLiqASts_Jsonclick ;
      private string edtLiqATipCod_Internalname ;
      private string A1166LiqATipCod ;
      private string edtLiqATipCod_Jsonclick ;
      private string edtLiqACXP_Internalname ;
      private string edtLiqACXP_Jsonclick ;
      private string edtLiqARegistro_Internalname ;
      private string edtLiqARegistro_Jsonclick ;
      private string edtLiqAVouAno_Internalname ;
      private string edtLiqAVouAno_Jsonclick ;
      private string edtLiqAVouMes_Internalname ;
      private string edtLiqAVouMes_Jsonclick ;
      private string edtLiqATASICod_Internalname ;
      private string edtLiqATASICod_Jsonclick ;
      private string edtLiqAVouNum_Internalname ;
      private string A1172LiqAVouNum ;
      private string edtLiqAVouNum_Jsonclick ;
      private string edtLiqATItem_Internalname ;
      private string edtLiqATItem_Jsonclick ;
      private string edtLiqUsuCod_Internalname ;
      private string A1203LiqUsuCod ;
      private string edtLiqUsuCod_Jsonclick ;
      private string edtLiqUsuFec_Internalname ;
      private string edtLiqUsuFec_Jsonclick ;
      private string edtLiqAComCod_Internalname ;
      private string edtLiqAComCod_Jsonclick ;
      private string edtLiqMonDsc_Internalname ;
      private string A1184LiqMonDsc ;
      private string edtLiqMonDsc_Jsonclick ;
      private string edtLiqTMovCueCod_Internalname ;
      private string A1200LiqTMovCueCod ;
      private string edtLiqTMovCueCod_Jsonclick ;
      private string edtLiqATot_Internalname ;
      private string edtLiqATot_Jsonclick ;
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
      private string Z1197LiqPrvDsc ;
      private string Z1184LiqMonDsc ;
      private string Z1201LiqTMovDsc ;
      private string Z1200LiqTMovCueCod ;
      private string sMode115 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ236LiqPrvCod ;
      private string ZZ274LiqBanCue ;
      private string ZZ1164LiqASts ;
      private string ZZ1166LiqATipCod ;
      private string ZZ1172LiqAVouNum ;
      private string ZZ1203LiqUsuCod ;
      private string ZZ1197LiqPrvDsc ;
      private string ZZ1184LiqMonDsc ;
      private string ZZ1201LiqTMovDsc ;
      private string ZZ1200LiqTMovCueCod ;
      private DateTime Z1204LiqUsuFec ;
      private DateTime A1204LiqUsuFec ;
      private DateTime ZZ1204LiqUsuFec ;
      private DateTime Z1178LiqFech ;
      private DateTime A1178LiqFech ;
      private DateTime ZZ1178LiqFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n273LiqBanCod ;
      private bool n274LiqBanCue ;
      private bool n272LiqTMovCod ;
      private bool wbErr ;
      private bool n1168LiqATot ;
      private bool Gx_longc ;
      private string Z270LiqCod ;
      private string Z1173LiqCheque ;
      private string Z1163LiqARegistro ;
      private string Z1161LiqAComCod ;
      private string A270LiqCod ;
      private string A1173LiqCheque ;
      private string A1163LiqARegistro ;
      private string A1161LiqAComCod ;
      private string ZZ270LiqCod ;
      private string ZZ1173LiqCheque ;
      private string ZZ1163LiqARegistro ;
      private string ZZ1161LiqAComCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003C12_A270LiqCod ;
      private int[] T003C12_A271LiqCodItem ;
      private string[] T003C12_A1197LiqPrvDsc ;
      private DateTime[] T003C12_A1178LiqFech ;
      private string[] T003C12_A1173LiqCheque ;
      private string[] T003C12_A1201LiqTMovDsc ;
      private decimal[] T003C12_A1202LiqTotal ;
      private long[] T003C12_A1199LiqTItem ;
      private string[] T003C12_A1164LiqASts ;
      private string[] T003C12_A1166LiqATipCod ;
      private short[] T003C12_A1162LiqACXP ;
      private string[] T003C12_A1163LiqARegistro ;
      private short[] T003C12_A1170LiqAVouAno ;
      private short[] T003C12_A1171LiqAVouMes ;
      private int[] T003C12_A1165LiqATASICod ;
      private string[] T003C12_A1172LiqAVouNum ;
      private long[] T003C12_A1167LiqATItem ;
      private string[] T003C12_A1203LiqUsuCod ;
      private DateTime[] T003C12_A1204LiqUsuFec ;
      private string[] T003C12_A1161LiqAComCod ;
      private string[] T003C12_A1184LiqMonDsc ;
      private string[] T003C12_A236LiqPrvCod ;
      private int[] T003C12_A276LiqMonCod ;
      private int[] T003C12_A275LiqForCod ;
      private int[] T003C12_A273LiqBanCod ;
      private bool[] T003C12_n273LiqBanCod ;
      private string[] T003C12_A274LiqBanCue ;
      private bool[] T003C12_n274LiqBanCue ;
      private int[] T003C12_A272LiqTMovCod ;
      private bool[] T003C12_n272LiqTMovCod ;
      private string[] T003C12_A1200LiqTMovCueCod ;
      private decimal[] T003C12_A1168LiqATot ;
      private bool[] T003C12_n1168LiqATot ;
      private string[] T003C4_A1197LiqPrvDsc ;
      private decimal[] T003C10_A1168LiqATot ;
      private bool[] T003C10_n1168LiqATot ;
      private string[] T003C5_A1184LiqMonDsc ;
      private int[] T003C6_A275LiqForCod ;
      private int[] T003C7_A273LiqBanCod ;
      private bool[] T003C7_n273LiqBanCod ;
      private string[] T003C8_A1201LiqTMovDsc ;
      private string[] T003C8_A1200LiqTMovCueCod ;
      private string[] T003C13_A1197LiqPrvDsc ;
      private decimal[] T003C15_A1168LiqATot ;
      private bool[] T003C15_n1168LiqATot ;
      private string[] T003C16_A1184LiqMonDsc ;
      private int[] T003C17_A275LiqForCod ;
      private int[] T003C18_A273LiqBanCod ;
      private bool[] T003C18_n273LiqBanCod ;
      private string[] T003C19_A1201LiqTMovDsc ;
      private string[] T003C19_A1200LiqTMovCueCod ;
      private string[] T003C20_A270LiqCod ;
      private string[] T003C20_A236LiqPrvCod ;
      private int[] T003C20_A271LiqCodItem ;
      private string[] T003C3_A270LiqCod ;
      private int[] T003C3_A271LiqCodItem ;
      private DateTime[] T003C3_A1178LiqFech ;
      private string[] T003C3_A1173LiqCheque ;
      private decimal[] T003C3_A1202LiqTotal ;
      private long[] T003C3_A1199LiqTItem ;
      private string[] T003C3_A1164LiqASts ;
      private string[] T003C3_A1166LiqATipCod ;
      private short[] T003C3_A1162LiqACXP ;
      private string[] T003C3_A1163LiqARegistro ;
      private short[] T003C3_A1170LiqAVouAno ;
      private short[] T003C3_A1171LiqAVouMes ;
      private int[] T003C3_A1165LiqATASICod ;
      private string[] T003C3_A1172LiqAVouNum ;
      private long[] T003C3_A1167LiqATItem ;
      private string[] T003C3_A1203LiqUsuCod ;
      private DateTime[] T003C3_A1204LiqUsuFec ;
      private string[] T003C3_A1161LiqAComCod ;
      private string[] T003C3_A236LiqPrvCod ;
      private int[] T003C3_A276LiqMonCod ;
      private int[] T003C3_A275LiqForCod ;
      private int[] T003C3_A273LiqBanCod ;
      private bool[] T003C3_n273LiqBanCod ;
      private string[] T003C3_A274LiqBanCue ;
      private bool[] T003C3_n274LiqBanCue ;
      private int[] T003C3_A272LiqTMovCod ;
      private bool[] T003C3_n272LiqTMovCod ;
      private string[] T003C21_A270LiqCod ;
      private string[] T003C21_A236LiqPrvCod ;
      private int[] T003C21_A271LiqCodItem ;
      private string[] T003C22_A270LiqCod ;
      private string[] T003C22_A236LiqPrvCod ;
      private int[] T003C22_A271LiqCodItem ;
      private string[] T003C2_A270LiqCod ;
      private int[] T003C2_A271LiqCodItem ;
      private DateTime[] T003C2_A1178LiqFech ;
      private string[] T003C2_A1173LiqCheque ;
      private decimal[] T003C2_A1202LiqTotal ;
      private long[] T003C2_A1199LiqTItem ;
      private string[] T003C2_A1164LiqASts ;
      private string[] T003C2_A1166LiqATipCod ;
      private short[] T003C2_A1162LiqACXP ;
      private string[] T003C2_A1163LiqARegistro ;
      private short[] T003C2_A1170LiqAVouAno ;
      private short[] T003C2_A1171LiqAVouMes ;
      private int[] T003C2_A1165LiqATASICod ;
      private string[] T003C2_A1172LiqAVouNum ;
      private long[] T003C2_A1167LiqATItem ;
      private string[] T003C2_A1203LiqUsuCod ;
      private DateTime[] T003C2_A1204LiqUsuFec ;
      private string[] T003C2_A1161LiqAComCod ;
      private string[] T003C2_A236LiqPrvCod ;
      private int[] T003C2_A276LiqMonCod ;
      private int[] T003C2_A275LiqForCod ;
      private int[] T003C2_A273LiqBanCod ;
      private bool[] T003C2_n273LiqBanCod ;
      private string[] T003C2_A274LiqBanCue ;
      private bool[] T003C2_n274LiqBanCue ;
      private int[] T003C2_A272LiqTMovCod ;
      private bool[] T003C2_n272LiqTMovCod ;
      private string[] T003C26_A1197LiqPrvDsc ;
      private decimal[] T003C28_A1168LiqATot ;
      private bool[] T003C28_n1168LiqATot ;
      private string[] T003C29_A1184LiqMonDsc ;
      private string[] T003C30_A1201LiqTMovDsc ;
      private string[] T003C30_A1200LiqTMovCueCod ;
      private string[] T003C31_A270LiqCod ;
      private string[] T003C31_A236LiqPrvCod ;
      private int[] T003C31_A271LiqCodItem ;
      private int[] T003C31_A282LiqDItem ;
      private string[] T003C32_A270LiqCod ;
      private string[] T003C32_A236LiqPrvCod ;
      private int[] T003C32_A271LiqCodItem ;
      private int[] T003C33_A275LiqForCod ;
      private int[] T003C34_A273LiqBanCod ;
      private bool[] T003C34_n273LiqBanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpliquidacion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpliquidacion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003C12;
        prmT003C12 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C4;
        prmT003C4 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003C10;
        prmT003C10 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C5;
        prmT003C5 = new Object[] {
        new ParDef("@LiqMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003C6;
        prmT003C6 = new Object[] {
        new ParDef("@LiqForCod",GXType.Int32,6,0)
        };
        Object[] prmT003C7;
        prmT003C7 = new Object[] {
        new ParDef("@LiqBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LiqBanCue",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT003C8;
        prmT003C8 = new Object[] {
        new ParDef("@LiqTMovCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003C13;
        prmT003C13 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003C15;
        prmT003C15 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C16;
        prmT003C16 = new Object[] {
        new ParDef("@LiqMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003C17;
        prmT003C17 = new Object[] {
        new ParDef("@LiqForCod",GXType.Int32,6,0)
        };
        Object[] prmT003C18;
        prmT003C18 = new Object[] {
        new ParDef("@LiqBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LiqBanCue",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT003C19;
        prmT003C19 = new Object[] {
        new ParDef("@LiqTMovCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003C20;
        prmT003C20 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C3;
        prmT003C3 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C21;
        prmT003C21 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C22;
        prmT003C22 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C2;
        prmT003C2 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C23;
        prmT003C23 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqFech",GXType.Date,8,0) ,
        new ParDef("@LiqCheque",GXType.NVarChar,10,0) ,
        new ParDef("@LiqTotal",GXType.Decimal,15,2) ,
        new ParDef("@LiqTItem",GXType.Decimal,10,0) ,
        new ParDef("@LiqASts",GXType.NChar,1,0) ,
        new ParDef("@LiqATipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqACXP",GXType.Int16,1,0) ,
        new ParDef("@LiqARegistro",GXType.NVarChar,10,0) ,
        new ParDef("@LiqAVouAno",GXType.Int16,4,0) ,
        new ParDef("@LiqAVouMes",GXType.Int16,2,0) ,
        new ParDef("@LiqATASICod",GXType.Int32,6,0) ,
        new ParDef("@LiqAVouNum",GXType.NChar,10,0) ,
        new ParDef("@LiqATItem",GXType.Decimal,10,0) ,
        new ParDef("@LiqUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LiqUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LiqAComCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMonCod",GXType.Int32,6,0) ,
        new ParDef("@LiqForCod",GXType.Int32,6,0) ,
        new ParDef("@LiqBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LiqBanCue",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@LiqTMovCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003C24;
        prmT003C24 = new Object[] {
        new ParDef("@LiqFech",GXType.Date,8,0) ,
        new ParDef("@LiqCheque",GXType.NVarChar,10,0) ,
        new ParDef("@LiqTotal",GXType.Decimal,15,2) ,
        new ParDef("@LiqTItem",GXType.Decimal,10,0) ,
        new ParDef("@LiqASts",GXType.NChar,1,0) ,
        new ParDef("@LiqATipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqACXP",GXType.Int16,1,0) ,
        new ParDef("@LiqARegistro",GXType.NVarChar,10,0) ,
        new ParDef("@LiqAVouAno",GXType.Int16,4,0) ,
        new ParDef("@LiqAVouMes",GXType.Int16,2,0) ,
        new ParDef("@LiqATASICod",GXType.Int32,6,0) ,
        new ParDef("@LiqAVouNum",GXType.NChar,10,0) ,
        new ParDef("@LiqATItem",GXType.Decimal,10,0) ,
        new ParDef("@LiqUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LiqUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LiqAComCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqMonCod",GXType.Int32,6,0) ,
        new ParDef("@LiqForCod",GXType.Int32,6,0) ,
        new ParDef("@LiqBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LiqBanCue",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@LiqTMovCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C25;
        prmT003C25 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C31;
        prmT003C31 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C32;
        prmT003C32 = new Object[] {
        };
        Object[] prmT003C26;
        prmT003C26 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003C28;
        prmT003C28 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003C29;
        prmT003C29 = new Object[] {
        new ParDef("@LiqMonCod",GXType.Int32,6,0)
        };
        Object[] prmT003C33;
        prmT003C33 = new Object[] {
        new ParDef("@LiqForCod",GXType.Int32,6,0)
        };
        Object[] prmT003C34;
        prmT003C34 = new Object[] {
        new ParDef("@LiqBanCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@LiqBanCue",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT003C30;
        prmT003C30 = new Object[] {
        new ParDef("@LiqTMovCod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T003C2", "SELECT [LiqCod], [LiqCodItem], [LiqFech], [LiqCheque], [LiqTotal], [LiqTItem], [LiqASts], [LiqATipCod], [LiqACXP], [LiqARegistro], [LiqAVouAno], [LiqAVouMes], [LiqATASICod], [LiqAVouNum], [LiqATItem], [LiqUsuCod], [LiqUsuFec], [LiqAComCod], [LiqPrvCod], [LiqMonCod] AS LiqMonCod, [LiqForCod] AS LiqForCod, [LiqBanCod] AS LiqBanCod, [LiqBanCue] AS LiqBanCue, [LiqTMovCod] AS LiqTMovCod FROM [CPLIQUIDACION] WITH (UPDLOCK) WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C3", "SELECT [LiqCod], [LiqCodItem], [LiqFech], [LiqCheque], [LiqTotal], [LiqTItem], [LiqASts], [LiqATipCod], [LiqACXP], [LiqARegistro], [LiqAVouAno], [LiqAVouMes], [LiqATASICod], [LiqAVouNum], [LiqATItem], [LiqUsuCod], [LiqUsuFec], [LiqAComCod], [LiqPrvCod], [LiqMonCod] AS LiqMonCod, [LiqForCod] AS LiqForCod, [LiqBanCod] AS LiqBanCod, [LiqBanCue] AS LiqBanCue, [LiqTMovCod] AS LiqTMovCod FROM [CPLIQUIDACION] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C4", "SELECT [LiqPrvDsc] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C5", "SELECT [MonDsc] AS LiqMonDsc FROM [CMONEDAS] WHERE [MonCod] = @LiqMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C6", "SELECT [ForCod] AS LiqForCod FROM [CFORMAPAGO] WHERE [ForCod] = @LiqForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C7", "SELECT [BanCod] AS LiqBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @LiqBanCod AND [CBCod] = @LiqBanCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C8", "SELECT [ConBDsc] AS LiqTMovDsc, [ConBCueCod] AS LiqTMovCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LiqTMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C10", "SELECT COALESCE( T1.[LiqATot], 0) AS LiqATot FROM (SELECT SUM([LiqDTot]) AS LiqATot, [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACIONDOC] GROUP BY [LiqCod], [LiqPrvCod], [LiqCodItem] ) T1 WHERE T1.[LiqCod] = @LiqCod AND T1.[LiqPrvCod] = @LiqPrvCod AND T1.[LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C12", "SELECT TM1.[LiqCod], TM1.[LiqCodItem], T2.[LiqPrvDsc], TM1.[LiqFech], TM1.[LiqCheque], T5.[ConBDsc] AS LiqTMovDsc, TM1.[LiqTotal], TM1.[LiqTItem], TM1.[LiqASts], TM1.[LiqATipCod], TM1.[LiqACXP], TM1.[LiqARegistro], TM1.[LiqAVouAno], TM1.[LiqAVouMes], TM1.[LiqATASICod], TM1.[LiqAVouNum], TM1.[LiqATItem], TM1.[LiqUsuCod], TM1.[LiqUsuFec], TM1.[LiqAComCod], T4.[MonDsc] AS LiqMonDsc, TM1.[LiqPrvCod], TM1.[LiqMonCod] AS LiqMonCod, TM1.[LiqForCod] AS LiqForCod, TM1.[LiqBanCod] AS LiqBanCod, TM1.[LiqBanCue] AS LiqBanCue, TM1.[LiqTMovCod] AS LiqTMovCod, T5.[ConBCueCod] AS LiqTMovCueCod, COALESCE( T3.[LiqATot], 0) AS LiqATot FROM (((([CPLIQUIDACION] TM1 INNER JOIN [CPAGENTES] T2 ON T2.[LiqPrvCod] = TM1.[LiqPrvCod]) LEFT JOIN (SELECT SUM([LiqDTot]) AS LiqATot, [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACIONDOC] GROUP BY [LiqCod], [LiqPrvCod], [LiqCodItem] ) T3 ON T3.[LiqCod] = TM1.[LiqCod] AND T3.[LiqPrvCod] = TM1.[LiqPrvCod] AND T3.[LiqCodItem] = TM1.[LiqCodItem]) INNER JOIN [CMONEDAS] T4 ON T4.[MonCod] = TM1.[LiqMonCod]) LEFT JOIN [TSCONCEPTOBANCOS] T5 ON T5.[ConBCod] = TM1.[LiqTMovCod]) WHERE TM1.[LiqCod] = @LiqCod and TM1.[LiqPrvCod] = @LiqPrvCod and TM1.[LiqCodItem] = @LiqCodItem ORDER BY TM1.[LiqCod], TM1.[LiqPrvCod], TM1.[LiqCodItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003C12,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C13", "SELECT [LiqPrvDsc] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C15", "SELECT COALESCE( T1.[LiqATot], 0) AS LiqATot FROM (SELECT SUM([LiqDTot]) AS LiqATot, [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACIONDOC] GROUP BY [LiqCod], [LiqPrvCod], [LiqCodItem] ) T1 WHERE T1.[LiqCod] = @LiqCod AND T1.[LiqPrvCod] = @LiqPrvCod AND T1.[LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C16", "SELECT [MonDsc] AS LiqMonDsc FROM [CMONEDAS] WHERE [MonCod] = @LiqMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C17", "SELECT [ForCod] AS LiqForCod FROM [CFORMAPAGO] WHERE [ForCod] = @LiqForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C18", "SELECT [BanCod] AS LiqBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @LiqBanCod AND [CBCod] = @LiqBanCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C19", "SELECT [ConBDsc] AS LiqTMovDsc, [ConBCueCod] AS LiqTMovCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LiqTMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C20", "SELECT [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003C20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C21", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE ( [LiqCod] > @LiqCod or [LiqCod] = @LiqCod and [LiqPrvCod] > @LiqPrvCod or [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqCodItem] > @LiqCodItem) ORDER BY [LiqCod], [LiqPrvCod], [LiqCodItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003C21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003C22", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE ( [LiqCod] < @LiqCod or [LiqCod] = @LiqCod and [LiqPrvCod] < @LiqPrvCod or [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqCodItem] < @LiqCodItem) ORDER BY [LiqCod] DESC, [LiqPrvCod] DESC, [LiqCodItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003C22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003C23", "INSERT INTO [CPLIQUIDACION]([LiqCod], [LiqCodItem], [LiqFech], [LiqCheque], [LiqTotal], [LiqTItem], [LiqASts], [LiqATipCod], [LiqACXP], [LiqARegistro], [LiqAVouAno], [LiqAVouMes], [LiqATASICod], [LiqAVouNum], [LiqATItem], [LiqUsuCod], [LiqUsuFec], [LiqAComCod], [LiqPrvCod], [LiqMonCod], [LiqForCod], [LiqBanCod], [LiqBanCue], [LiqTMovCod]) VALUES(@LiqCod, @LiqCodItem, @LiqFech, @LiqCheque, @LiqTotal, @LiqTItem, @LiqASts, @LiqATipCod, @LiqACXP, @LiqARegistro, @LiqAVouAno, @LiqAVouMes, @LiqATASICod, @LiqAVouNum, @LiqATItem, @LiqUsuCod, @LiqUsuFec, @LiqAComCod, @LiqPrvCod, @LiqMonCod, @LiqForCod, @LiqBanCod, @LiqBanCue, @LiqTMovCod)", GxErrorMask.GX_NOMASK,prmT003C23)
           ,new CursorDef("T003C24", "UPDATE [CPLIQUIDACION] SET [LiqFech]=@LiqFech, [LiqCheque]=@LiqCheque, [LiqTotal]=@LiqTotal, [LiqTItem]=@LiqTItem, [LiqASts]=@LiqASts, [LiqATipCod]=@LiqATipCod, [LiqACXP]=@LiqACXP, [LiqARegistro]=@LiqARegistro, [LiqAVouAno]=@LiqAVouAno, [LiqAVouMes]=@LiqAVouMes, [LiqATASICod]=@LiqATASICod, [LiqAVouNum]=@LiqAVouNum, [LiqATItem]=@LiqATItem, [LiqUsuCod]=@LiqUsuCod, [LiqUsuFec]=@LiqUsuFec, [LiqAComCod]=@LiqAComCod, [LiqMonCod]=@LiqMonCod, [LiqForCod]=@LiqForCod, [LiqBanCod]=@LiqBanCod, [LiqBanCue]=@LiqBanCue, [LiqTMovCod]=@LiqTMovCod  WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem", GxErrorMask.GX_NOMASK,prmT003C24)
           ,new CursorDef("T003C25", "DELETE FROM [CPLIQUIDACION]  WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem", GxErrorMask.GX_NOMASK,prmT003C25)
           ,new CursorDef("T003C26", "SELECT [LiqPrvDsc] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C28", "SELECT COALESCE( T1.[LiqATot], 0) AS LiqATot FROM (SELECT SUM([LiqDTot]) AS LiqATot, [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACIONDOC] GROUP BY [LiqCod], [LiqPrvCod], [LiqCodItem] ) T1 WHERE T1.[LiqCod] = @LiqCod AND T1.[LiqPrvCod] = @LiqPrvCod AND T1.[LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C29", "SELECT [MonDsc] AS LiqMonDsc FROM [CMONEDAS] WHERE [MonCod] = @LiqMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C30", "SELECT [ConBDsc] AS LiqTMovDsc, [ConBCueCod] AS LiqTMovCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LiqTMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C31", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem] FROM [CPLIQUIDACIONDOC] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003C32", "SELECT [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] ORDER BY [LiqCod], [LiqPrvCod], [LiqCodItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003C32,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C33", "SELECT [ForCod] AS LiqForCod FROM [CFORMAPAGO] WHERE [ForCod] = @LiqForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C33,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003C34", "SELECT [BanCod] AS LiqBanCod FROM [TSCUENTABANCO] WHERE [BanCod] = @LiqBanCod AND [CBCod] = @LiqBanCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT003C34,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((long[]) buf[14])[0] = rslt.getLong(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((bool[]) buf[24])[0] = rslt.wasNull(23);
              ((int[]) buf[25])[0] = rslt.getInt(24);
              ((bool[]) buf[26])[0] = rslt.wasNull(24);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((long[]) buf[14])[0] = rslt.getLong(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(17);
              ((string[]) buf[17])[0] = rslt.getVarchar(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((int[]) buf[20])[0] = rslt.getInt(21);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((bool[]) buf[22])[0] = rslt.wasNull(22);
              ((string[]) buf[23])[0] = rslt.getString(23, 20);
              ((bool[]) buf[24])[0] = rslt.wasNull(23);
              ((int[]) buf[25])[0] = rslt.getInt(24);
              ((bool[]) buf[26])[0] = rslt.wasNull(24);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 7 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((long[]) buf[7])[0] = rslt.getLong(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((int[]) buf[14])[0] = rslt.getInt(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 10);
              ((long[]) buf[16])[0] = rslt.getLong(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 10);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(19);
              ((string[]) buf[19])[0] = rslt.getVarchar(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 100);
              ((string[]) buf[21])[0] = rslt.getString(22, 20);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((int[]) buf[23])[0] = rslt.getInt(24);
              ((int[]) buf[24])[0] = rslt.getInt(25);
              ((bool[]) buf[25])[0] = rslt.wasNull(25);
              ((string[]) buf[26])[0] = rslt.getString(26, 20);
              ((bool[]) buf[27])[0] = rslt.wasNull(26);
              ((int[]) buf[28])[0] = rslt.getInt(27);
              ((bool[]) buf[29])[0] = rslt.wasNull(27);
              ((string[]) buf[30])[0] = rslt.getString(28, 15);
              ((decimal[]) buf[31])[0] = rslt.getDecimal(29);
              ((bool[]) buf[32])[0] = rslt.wasNull(29);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
