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
   public class cpliquidaciondoc : GXDataArea
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
            gxLoad_3( A270LiqCod, A236LiqPrvCod, A271LiqCodItem) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A283LiqDTipCod = GetPar( "LiqDTipCod");
            AssignAttri("", false, "A283LiqDTipCod", A283LiqDTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A283LiqDTipCod) ;
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
            Form.Meta.addItem("description", "Documentos Liquidación", 0) ;
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

      public cpliquidaciondoc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpliquidaciondoc( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Documentos Liquidación", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CPLIQUIDACIONDOC.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPLIQUIDACIONDOC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtLiqCod_Internalname, A270LiqCod, StringUtil.RTrim( context.localUtil.Format( A270LiqCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDOC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtLiqPrvCod_Internalname, StringUtil.RTrim( A236LiqPrvCod), StringUtil.RTrim( context.localUtil.Format( A236LiqPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDOC.htm");
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
         GxWebStd.gx_single_line_edit( context, edtLiqCodItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A271LiqCodItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqCodItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A271LiqCodItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A271LiqCodItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCodItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCodItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqDItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqDItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A282LiqDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A282LiqDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A282LiqDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqDTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqDTipCod_Internalname, "Tipo Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqDTipCod_Internalname, StringUtil.RTrim( A283LiqDTipCod), StringUtil.RTrim( context.localUtil.Format( A283LiqDTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqDTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqDTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqDComCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqDComCod_Internalname, "N° Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqDComCod_Internalname, StringUtil.RTrim( A1176LiqDComCod), StringUtil.RTrim( context.localUtil.Format( A1176LiqDComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqDComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqDComCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqDFVcto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqDFVcto_Internalname, "F. Vcto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLiqDFVcto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLiqDFVcto_Internalname, context.localUtil.Format(A1177LiqDFVcto, "99/99/99"), context.localUtil.Format( A1177LiqDFVcto, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqDFVcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqDFVcto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_bitmap( context, edtLiqDFVcto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLiqDFVcto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLIQUIDACIONDOC.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqDTot_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqDTot_Internalname, "Total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqDTot_Internalname, StringUtil.LTrim( StringUtil.NToC( A1169LiqDTot, 17, 2, ".", "")), StringUtil.LTrim( ((edtLiqDTot_Enabled!=0) ? context.localUtil.Format( A1169LiqDTot, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1169LiqDTot, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqDTot_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqDTot_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPLIQUIDACIONDOC.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDOC.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDOC.htm");
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
            Z282LiqDItem = (int)(context.localUtil.CToN( cgiGet( "Z282LiqDItem"), ".", ","));
            Z1176LiqDComCod = cgiGet( "Z1176LiqDComCod");
            Z1177LiqDFVcto = context.localUtil.CToD( cgiGet( "Z1177LiqDFVcto"), 0);
            Z1169LiqDTot = context.localUtil.CToN( cgiGet( "Z1169LiqDTot"), ".", ",");
            Z283LiqDTipCod = cgiGet( "Z283LiqDTipCod");
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQDITEM");
               AnyError = 1;
               GX_FocusControl = edtLiqDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A282LiqDItem = 0;
               AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
            }
            else
            {
               A282LiqDItem = (int)(context.localUtil.CToN( cgiGet( edtLiqDItem_Internalname), ".", ","));
               AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
            }
            A283LiqDTipCod = cgiGet( edtLiqDTipCod_Internalname);
            AssignAttri("", false, "A283LiqDTipCod", A283LiqDTipCod);
            A1176LiqDComCod = cgiGet( edtLiqDComCod_Internalname);
            AssignAttri("", false, "A1176LiqDComCod", A1176LiqDComCod);
            if ( context.localUtil.VCDate( cgiGet( edtLiqDFVcto_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"F. Vcto"}), 1, "LIQDFVCTO");
               AnyError = 1;
               GX_FocusControl = edtLiqDFVcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1177LiqDFVcto = DateTime.MinValue;
               AssignAttri("", false, "A1177LiqDFVcto", context.localUtil.Format(A1177LiqDFVcto, "99/99/99"));
            }
            else
            {
               A1177LiqDFVcto = context.localUtil.CToD( cgiGet( edtLiqDFVcto_Internalname), 2);
               AssignAttri("", false, "A1177LiqDFVcto", context.localUtil.Format(A1177LiqDFVcto, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqDTot_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqDTot_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQDTOT");
               AnyError = 1;
               GX_FocusControl = edtLiqDTot_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1169LiqDTot = 0;
               AssignAttri("", false, "A1169LiqDTot", StringUtil.LTrimStr( A1169LiqDTot, 15, 2));
            }
            else
            {
               A1169LiqDTot = context.localUtil.CToN( cgiGet( edtLiqDTot_Internalname), ".", ",");
               AssignAttri("", false, "A1169LiqDTot", StringUtil.LTrimStr( A1169LiqDTot, 15, 2));
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
               A270LiqCod = GetPar( "LiqCod");
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = GetPar( "LiqPrvCod");
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A271LiqCodItem = (int)(NumberUtil.Val( GetPar( "LiqCodItem"), "."));
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
               A282LiqDItem = (int)(NumberUtil.Val( GetPar( "LiqDItem"), "."));
               AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
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
               InitAll3E117( ) ;
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
         DisableAttributes3E117( ) ;
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

      protected void ResetCaption3E0( )
      {
      }

      protected void ZM3E117( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1176LiqDComCod = T003E3_A1176LiqDComCod[0];
               Z1177LiqDFVcto = T003E3_A1177LiqDFVcto[0];
               Z1169LiqDTot = T003E3_A1169LiqDTot[0];
               Z283LiqDTipCod = T003E3_A283LiqDTipCod[0];
            }
            else
            {
               Z1176LiqDComCod = A1176LiqDComCod;
               Z1177LiqDFVcto = A1177LiqDFVcto;
               Z1169LiqDTot = A1169LiqDTot;
               Z283LiqDTipCod = A283LiqDTipCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z282LiqDItem = A282LiqDItem;
            Z1176LiqDComCod = A1176LiqDComCod;
            Z1177LiqDFVcto = A1177LiqDFVcto;
            Z1169LiqDTot = A1169LiqDTot;
            Z236LiqPrvCod = A236LiqPrvCod;
            Z270LiqCod = A270LiqCod;
            Z271LiqCodItem = A271LiqCodItem;
            Z283LiqDTipCod = A283LiqDTipCod;
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

      protected void Load3E117( )
      {
         /* Using cursor T003E6 */
         pr_default.execute(4, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound117 = 1;
            A1176LiqDComCod = T003E6_A1176LiqDComCod[0];
            AssignAttri("", false, "A1176LiqDComCod", A1176LiqDComCod);
            A1177LiqDFVcto = T003E6_A1177LiqDFVcto[0];
            AssignAttri("", false, "A1177LiqDFVcto", context.localUtil.Format(A1177LiqDFVcto, "99/99/99"));
            A1169LiqDTot = T003E6_A1169LiqDTot[0];
            AssignAttri("", false, "A1169LiqDTot", StringUtil.LTrimStr( A1169LiqDTot, 15, 2));
            A283LiqDTipCod = T003E6_A283LiqDTipCod[0];
            AssignAttri("", false, "A283LiqDTipCod", A283LiqDTipCod);
            ZM3E117( -2) ;
         }
         pr_default.close(4);
         OnLoadActions3E117( ) ;
      }

      protected void OnLoadActions3E117( )
      {
      }

      protected void CheckExtendedTable3E117( )
      {
         nIsDirty_117 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003E4 */
         pr_default.execute(2, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Liquidación'.", "ForeignKeyNotFound", 1, "LIQCODITEM");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T003E5 */
         pr_default.execute(3, new Object[] {A283LiqDTipCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "LIQDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqDTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1177LiqDFVcto) || ( DateTimeUtil.ResetTime ( A1177LiqDFVcto ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo F. Vcto fuera de rango", "OutOfRange", 1, "LIQDFVCTO");
            AnyError = 1;
            GX_FocusControl = edtLiqDFVcto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3E117( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A270LiqCod ,
                               string A236LiqPrvCod ,
                               int A271LiqCodItem )
      {
         /* Using cursor T003E7 */
         pr_default.execute(5, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Liquidación'.", "ForeignKeyNotFound", 1, "LIQCODITEM");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
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

      protected void gxLoad_4( string A283LiqDTipCod )
      {
         /* Using cursor T003E8 */
         pr_default.execute(6, new Object[] {A283LiqDTipCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "LIQDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqDTipCod_Internalname;
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

      protected void GetKey3E117( )
      {
         /* Using cursor T003E9 */
         pr_default.execute(7, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound117 = 1;
         }
         else
         {
            RcdFound117 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003E3 */
         pr_default.execute(1, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3E117( 2) ;
            RcdFound117 = 1;
            A282LiqDItem = T003E3_A282LiqDItem[0];
            AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
            A1176LiqDComCod = T003E3_A1176LiqDComCod[0];
            AssignAttri("", false, "A1176LiqDComCod", A1176LiqDComCod);
            A1177LiqDFVcto = T003E3_A1177LiqDFVcto[0];
            AssignAttri("", false, "A1177LiqDFVcto", context.localUtil.Format(A1177LiqDFVcto, "99/99/99"));
            A1169LiqDTot = T003E3_A1169LiqDTot[0];
            AssignAttri("", false, "A1169LiqDTot", StringUtil.LTrimStr( A1169LiqDTot, 15, 2));
            A236LiqPrvCod = T003E3_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A270LiqCod = T003E3_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A271LiqCodItem = T003E3_A271LiqCodItem[0];
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            A283LiqDTipCod = T003E3_A283LiqDTipCod[0];
            AssignAttri("", false, "A283LiqDTipCod", A283LiqDTipCod);
            Z270LiqCod = A270LiqCod;
            Z236LiqPrvCod = A236LiqPrvCod;
            Z271LiqCodItem = A271LiqCodItem;
            Z282LiqDItem = A282LiqDItem;
            sMode117 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3E117( ) ;
            if ( AnyError == 1 )
            {
               RcdFound117 = 0;
               InitializeNonKey3E117( ) ;
            }
            Gx_mode = sMode117;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound117 = 0;
            InitializeNonKey3E117( ) ;
            sMode117 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode117;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3E117( ) ;
         if ( RcdFound117 == 0 )
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
         RcdFound117 = 0;
         /* Using cursor T003E10 */
         pr_default.execute(8, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) < 0 ) || ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003E10_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) || ( StringUtil.StrCmp(T003E10_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E10_A271LiqCodItem[0] < A271LiqCodItem ) || ( T003E10_A271LiqCodItem[0] == A271LiqCodItem ) && ( StringUtil.StrCmp(T003E10_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E10_A282LiqDItem[0] < A282LiqDItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) > 0 ) || ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003E10_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) || ( StringUtil.StrCmp(T003E10_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E10_A271LiqCodItem[0] > A271LiqCodItem ) || ( T003E10_A271LiqCodItem[0] == A271LiqCodItem ) && ( StringUtil.StrCmp(T003E10_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E10_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E10_A282LiqDItem[0] > A282LiqDItem ) ) )
            {
               A270LiqCod = T003E10_A270LiqCod[0];
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = T003E10_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A271LiqCodItem = T003E10_A271LiqCodItem[0];
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
               A282LiqDItem = T003E10_A282LiqDItem[0];
               AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
               RcdFound117 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound117 = 0;
         /* Using cursor T003E11 */
         pr_default.execute(9, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) > 0 ) || ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003E11_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) || ( StringUtil.StrCmp(T003E11_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E11_A271LiqCodItem[0] > A271LiqCodItem ) || ( T003E11_A271LiqCodItem[0] == A271LiqCodItem ) && ( StringUtil.StrCmp(T003E11_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E11_A282LiqDItem[0] > A282LiqDItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) < 0 ) || ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003E11_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) || ( StringUtil.StrCmp(T003E11_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E11_A271LiqCodItem[0] < A271LiqCodItem ) || ( T003E11_A271LiqCodItem[0] == A271LiqCodItem ) && ( StringUtil.StrCmp(T003E11_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003E11_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003E11_A282LiqDItem[0] < A282LiqDItem ) ) )
            {
               A270LiqCod = T003E11_A270LiqCod[0];
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = T003E11_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A271LiqCodItem = T003E11_A271LiqCodItem[0];
               AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
               A282LiqDItem = T003E11_A282LiqDItem[0];
               AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
               RcdFound117 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3E117( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3E117( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound117 == 1 )
            {
               if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A271LiqCodItem != Z271LiqCodItem ) || ( A282LiqDItem != Z282LiqDItem ) )
               {
                  A270LiqCod = Z270LiqCod;
                  AssignAttri("", false, "A270LiqCod", A270LiqCod);
                  A236LiqPrvCod = Z236LiqPrvCod;
                  AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
                  A271LiqCodItem = Z271LiqCodItem;
                  AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
                  A282LiqDItem = Z282LiqDItem;
                  AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
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
                  Update3E117( ) ;
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A271LiqCodItem != Z271LiqCodItem ) || ( A282LiqDItem != Z282LiqDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3E117( ) ;
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
                     Insert3E117( ) ;
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
         if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A271LiqCodItem != Z271LiqCodItem ) || ( A282LiqDItem != Z282LiqDItem ) )
         {
            A270LiqCod = Z270LiqCod;
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = Z236LiqPrvCod;
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A271LiqCodItem = Z271LiqCodItem;
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            A282LiqDItem = Z282LiqDItem;
            AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
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
         if ( RcdFound117 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LIQCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLiqDTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3E117( ) ;
         if ( RcdFound117 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqDTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3E117( ) ;
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
         if ( RcdFound117 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqDTipCod_Internalname;
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
         if ( RcdFound117 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqDTipCod_Internalname;
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
         ScanStart3E117( ) ;
         if ( RcdFound117 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound117 != 0 )
            {
               ScanNext3E117( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqDTipCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3E117( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3E117( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003E2 */
            pr_default.execute(0, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLIQUIDACIONDOC"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1176LiqDComCod, T003E2_A1176LiqDComCod[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1177LiqDFVcto ) != DateTimeUtil.ResetTime ( T003E2_A1177LiqDFVcto[0] ) ) || ( Z1169LiqDTot != T003E2_A1169LiqDTot[0] ) || ( StringUtil.StrCmp(Z283LiqDTipCod, T003E2_A283LiqDTipCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1176LiqDComCod, T003E2_A1176LiqDComCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondoc:[seudo value changed for attri]"+"LiqDComCod");
                  GXUtil.WriteLogRaw("Old: ",Z1176LiqDComCod);
                  GXUtil.WriteLogRaw("Current: ",T003E2_A1176LiqDComCod[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1177LiqDFVcto ) != DateTimeUtil.ResetTime ( T003E2_A1177LiqDFVcto[0] ) )
               {
                  GXUtil.WriteLog("cpliquidaciondoc:[seudo value changed for attri]"+"LiqDFVcto");
                  GXUtil.WriteLogRaw("Old: ",Z1177LiqDFVcto);
                  GXUtil.WriteLogRaw("Current: ",T003E2_A1177LiqDFVcto[0]);
               }
               if ( Z1169LiqDTot != T003E2_A1169LiqDTot[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondoc:[seudo value changed for attri]"+"LiqDTot");
                  GXUtil.WriteLogRaw("Old: ",Z1169LiqDTot);
                  GXUtil.WriteLogRaw("Current: ",T003E2_A1169LiqDTot[0]);
               }
               if ( StringUtil.StrCmp(Z283LiqDTipCod, T003E2_A283LiqDTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondoc:[seudo value changed for attri]"+"LiqDTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z283LiqDTipCod);
                  GXUtil.WriteLogRaw("Current: ",T003E2_A283LiqDTipCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPLIQUIDACIONDOC"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3E117( )
      {
         BeforeValidate3E117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3E117( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3E117( 0) ;
            CheckOptimisticConcurrency3E117( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3E117( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3E117( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003E12 */
                     pr_default.execute(10, new Object[] {A282LiqDItem, A1176LiqDComCod, A1177LiqDFVcto, A1169LiqDTot, A236LiqPrvCod, A270LiqCod, A271LiqCodItem, A283LiqDTipCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACIONDOC");
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
                           ResetCaption3E0( ) ;
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
               Load3E117( ) ;
            }
            EndLevel3E117( ) ;
         }
         CloseExtendedTableCursors3E117( ) ;
      }

      protected void Update3E117( )
      {
         BeforeValidate3E117( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3E117( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3E117( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3E117( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3E117( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003E13 */
                     pr_default.execute(11, new Object[] {A1176LiqDComCod, A1177LiqDFVcto, A1169LiqDTot, A283LiqDTipCod, A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACIONDOC");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLIQUIDACIONDOC"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3E117( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3E0( ) ;
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
            EndLevel3E117( ) ;
         }
         CloseExtendedTableCursors3E117( ) ;
      }

      protected void DeferredUpdate3E117( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3E117( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3E117( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3E117( ) ;
            AfterConfirm3E117( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3E117( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003E14 */
                  pr_default.execute(12, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem, A282LiqDItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACIONDOC");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound117 == 0 )
                        {
                           InitAll3E117( ) ;
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
                        ResetCaption3E0( ) ;
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
         sMode117 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3E117( ) ;
         Gx_mode = sMode117;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3E117( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel3E117( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3E117( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cpliquidaciondoc",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cpliquidaciondoc",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3E117( )
      {
         /* Using cursor T003E15 */
         pr_default.execute(13);
         RcdFound117 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound117 = 1;
            A270LiqCod = T003E15_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = T003E15_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A271LiqCodItem = T003E15_A271LiqCodItem[0];
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            A282LiqDItem = T003E15_A282LiqDItem[0];
            AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3E117( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound117 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound117 = 1;
            A270LiqCod = T003E15_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = T003E15_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A271LiqCodItem = T003E15_A271LiqCodItem[0];
            AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
            A282LiqDItem = T003E15_A282LiqDItem[0];
            AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
         }
      }

      protected void ScanEnd3E117( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm3E117( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3E117( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3E117( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3E117( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3E117( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3E117( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3E117( )
      {
         edtLiqCod_Enabled = 0;
         AssignProp("", false, edtLiqCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCod_Enabled), 5, 0), true);
         edtLiqPrvCod_Enabled = 0;
         AssignProp("", false, edtLiqPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqPrvCod_Enabled), 5, 0), true);
         edtLiqCodItem_Enabled = 0;
         AssignProp("", false, edtLiqCodItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCodItem_Enabled), 5, 0), true);
         edtLiqDItem_Enabled = 0;
         AssignProp("", false, edtLiqDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqDItem_Enabled), 5, 0), true);
         edtLiqDTipCod_Enabled = 0;
         AssignProp("", false, edtLiqDTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqDTipCod_Enabled), 5, 0), true);
         edtLiqDComCod_Enabled = 0;
         AssignProp("", false, edtLiqDComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqDComCod_Enabled), 5, 0), true);
         edtLiqDFVcto_Enabled = 0;
         AssignProp("", false, edtLiqDFVcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqDFVcto_Enabled), 5, 0), true);
         edtLiqDTot_Enabled = 0;
         AssignProp("", false, edtLiqDTot_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqDTot_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3E117( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3E0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025366", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cpliquidaciondoc.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z282LiqDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z282LiqDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1176LiqDComCod", StringUtil.RTrim( Z1176LiqDComCod));
         GxWebStd.gx_hidden_field( context, "Z1177LiqDFVcto", context.localUtil.DToC( Z1177LiqDFVcto, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1169LiqDTot", StringUtil.LTrim( StringUtil.NToC( Z1169LiqDTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z283LiqDTipCod", StringUtil.RTrim( Z283LiqDTipCod));
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
         return formatLink("cpliquidaciondoc.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPLIQUIDACIONDOC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documentos Liquidación" ;
      }

      protected void InitializeNonKey3E117( )
      {
         A283LiqDTipCod = "";
         AssignAttri("", false, "A283LiqDTipCod", A283LiqDTipCod);
         A1176LiqDComCod = "";
         AssignAttri("", false, "A1176LiqDComCod", A1176LiqDComCod);
         A1177LiqDFVcto = DateTime.MinValue;
         AssignAttri("", false, "A1177LiqDFVcto", context.localUtil.Format(A1177LiqDFVcto, "99/99/99"));
         A1169LiqDTot = 0;
         AssignAttri("", false, "A1169LiqDTot", StringUtil.LTrimStr( A1169LiqDTot, 15, 2));
         Z1176LiqDComCod = "";
         Z1177LiqDFVcto = DateTime.MinValue;
         Z1169LiqDTot = 0;
         Z283LiqDTipCod = "";
      }

      protected void InitAll3E117( )
      {
         A270LiqCod = "";
         AssignAttri("", false, "A270LiqCod", A270LiqCod);
         A236LiqPrvCod = "";
         AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
         A271LiqCodItem = 0;
         AssignAttri("", false, "A271LiqCodItem", StringUtil.LTrimStr( (decimal)(A271LiqCodItem), 6, 0));
         A282LiqDItem = 0;
         AssignAttri("", false, "A282LiqDItem", StringUtil.LTrimStr( (decimal)(A282LiqDItem), 6, 0));
         InitializeNonKey3E117( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025372", true, true);
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
         context.AddJavascriptSource("cpliquidaciondoc.js", "?20228181025373", false, true);
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
         edtLiqDItem_Internalname = "LIQDITEM";
         edtLiqDTipCod_Internalname = "LIQDTIPCOD";
         edtLiqDComCod_Internalname = "LIQDCOMCOD";
         edtLiqDFVcto_Internalname = "LIQDFVCTO";
         edtLiqDTot_Internalname = "LIQDTOT";
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
         Form.Caption = "Documentos Liquidación";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLiqDTot_Jsonclick = "";
         edtLiqDTot_Enabled = 1;
         edtLiqDFVcto_Jsonclick = "";
         edtLiqDFVcto_Enabled = 1;
         edtLiqDComCod_Jsonclick = "";
         edtLiqDComCod_Enabled = 1;
         edtLiqDTipCod_Jsonclick = "";
         edtLiqDTipCod_Enabled = 1;
         edtLiqDItem_Jsonclick = "";
         edtLiqDItem_Enabled = 1;
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
         /* Using cursor T003E16 */
         pr_default.execute(14, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Liquidación'.", "ForeignKeyNotFound", 1, "LIQCODITEM");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = edtLiqDTipCod_Internalname;
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

      public void Valid_Liqcoditem( )
      {
         /* Using cursor T003E16 */
         pr_default.execute(14, new Object[] {A270LiqCod, A236LiqPrvCod, A271LiqCodItem});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Liquidación'.", "ForeignKeyNotFound", 1, "LIQCODITEM");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Liqditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A283LiqDTipCod", StringUtil.RTrim( A283LiqDTipCod));
         AssignAttri("", false, "A1176LiqDComCod", StringUtil.RTrim( A1176LiqDComCod));
         AssignAttri("", false, "A1177LiqDFVcto", context.localUtil.Format(A1177LiqDFVcto, "99/99/99"));
         AssignAttri("", false, "A1169LiqDTot", StringUtil.LTrim( StringUtil.NToC( A1169LiqDTot, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z270LiqCod", Z270LiqCod);
         GxWebStd.gx_hidden_field( context, "Z236LiqPrvCod", StringUtil.RTrim( Z236LiqPrvCod));
         GxWebStd.gx_hidden_field( context, "Z271LiqCodItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z271LiqCodItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z282LiqDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z282LiqDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z283LiqDTipCod", StringUtil.RTrim( Z283LiqDTipCod));
         GxWebStd.gx_hidden_field( context, "Z1176LiqDComCod", StringUtil.RTrim( Z1176LiqDComCod));
         GxWebStd.gx_hidden_field( context, "Z1177LiqDFVcto", context.localUtil.Format(Z1177LiqDFVcto, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1169LiqDTot", StringUtil.LTrim( StringUtil.NToC( Z1169LiqDTot, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Liqdtipcod( )
      {
         /* Using cursor T003E17 */
         pr_default.execute(15, new Object[] {A283LiqDTipCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo Documento'.", "ForeignKeyNotFound", 1, "LIQDTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqDTipCod_Internalname;
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
         setEventMetadata("VALID_LIQCOD","{handler:'Valid_Liqcod',iparms:[]");
         setEventMetadata("VALID_LIQCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQPRVCOD","{handler:'Valid_Liqprvcod',iparms:[]");
         setEventMetadata("VALID_LIQPRVCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQCODITEM","{handler:'Valid_Liqcoditem',iparms:[{av:'A270LiqCod',fld:'LIQCOD',pic:''},{av:'A236LiqPrvCod',fld:'LIQPRVCOD',pic:''},{av:'A271LiqCodItem',fld:'LIQCODITEM',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LIQCODITEM",",oparms:[]}");
         setEventMetadata("VALID_LIQDITEM","{handler:'Valid_Liqditem',iparms:[{av:'A270LiqCod',fld:'LIQCOD',pic:''},{av:'A236LiqPrvCod',fld:'LIQPRVCOD',pic:''},{av:'A271LiqCodItem',fld:'LIQCODITEM',pic:'ZZZZZ9'},{av:'A282LiqDItem',fld:'LIQDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LIQDITEM",",oparms:[{av:'A283LiqDTipCod',fld:'LIQDTIPCOD',pic:''},{av:'A1176LiqDComCod',fld:'LIQDCOMCOD',pic:''},{av:'A1177LiqDFVcto',fld:'LIQDFVCTO',pic:''},{av:'A1169LiqDTot',fld:'LIQDTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z270LiqCod'},{av:'Z236LiqPrvCod'},{av:'Z271LiqCodItem'},{av:'Z282LiqDItem'},{av:'Z283LiqDTipCod'},{av:'Z1176LiqDComCod'},{av:'Z1177LiqDFVcto'},{av:'Z1169LiqDTot'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_LIQDTIPCOD","{handler:'Valid_Liqdtipcod',iparms:[{av:'A283LiqDTipCod',fld:'LIQDTIPCOD',pic:''}]");
         setEventMetadata("VALID_LIQDTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQDFVCTO","{handler:'Valid_Liqdfvcto',iparms:[]");
         setEventMetadata("VALID_LIQDFVCTO",",oparms:[]}");
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
         Z270LiqCod = "";
         Z236LiqPrvCod = "";
         Z1176LiqDComCod = "";
         Z1177LiqDFVcto = DateTime.MinValue;
         Z283LiqDTipCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A270LiqCod = "";
         A236LiqPrvCod = "";
         A283LiqDTipCod = "";
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
         A1176LiqDComCod = "";
         A1177LiqDFVcto = DateTime.MinValue;
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
         T003E6_A282LiqDItem = new int[1] ;
         T003E6_A1176LiqDComCod = new string[] {""} ;
         T003E6_A1177LiqDFVcto = new DateTime[] {DateTime.MinValue} ;
         T003E6_A1169LiqDTot = new decimal[1] ;
         T003E6_A236LiqPrvCod = new string[] {""} ;
         T003E6_A270LiqCod = new string[] {""} ;
         T003E6_A271LiqCodItem = new int[1] ;
         T003E6_A283LiqDTipCod = new string[] {""} ;
         T003E4_A270LiqCod = new string[] {""} ;
         T003E5_A283LiqDTipCod = new string[] {""} ;
         T003E7_A270LiqCod = new string[] {""} ;
         T003E8_A283LiqDTipCod = new string[] {""} ;
         T003E9_A270LiqCod = new string[] {""} ;
         T003E9_A236LiqPrvCod = new string[] {""} ;
         T003E9_A271LiqCodItem = new int[1] ;
         T003E9_A282LiqDItem = new int[1] ;
         T003E3_A282LiqDItem = new int[1] ;
         T003E3_A1176LiqDComCod = new string[] {""} ;
         T003E3_A1177LiqDFVcto = new DateTime[] {DateTime.MinValue} ;
         T003E3_A1169LiqDTot = new decimal[1] ;
         T003E3_A236LiqPrvCod = new string[] {""} ;
         T003E3_A270LiqCod = new string[] {""} ;
         T003E3_A271LiqCodItem = new int[1] ;
         T003E3_A283LiqDTipCod = new string[] {""} ;
         sMode117 = "";
         T003E10_A270LiqCod = new string[] {""} ;
         T003E10_A236LiqPrvCod = new string[] {""} ;
         T003E10_A271LiqCodItem = new int[1] ;
         T003E10_A282LiqDItem = new int[1] ;
         T003E11_A270LiqCod = new string[] {""} ;
         T003E11_A236LiqPrvCod = new string[] {""} ;
         T003E11_A271LiqCodItem = new int[1] ;
         T003E11_A282LiqDItem = new int[1] ;
         T003E2_A282LiqDItem = new int[1] ;
         T003E2_A1176LiqDComCod = new string[] {""} ;
         T003E2_A1177LiqDFVcto = new DateTime[] {DateTime.MinValue} ;
         T003E2_A1169LiqDTot = new decimal[1] ;
         T003E2_A236LiqPrvCod = new string[] {""} ;
         T003E2_A270LiqCod = new string[] {""} ;
         T003E2_A271LiqCodItem = new int[1] ;
         T003E2_A283LiqDTipCod = new string[] {""} ;
         T003E15_A270LiqCod = new string[] {""} ;
         T003E15_A236LiqPrvCod = new string[] {""} ;
         T003E15_A271LiqCodItem = new int[1] ;
         T003E15_A282LiqDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003E16_A270LiqCod = new string[] {""} ;
         ZZ270LiqCod = "";
         ZZ236LiqPrvCod = "";
         ZZ283LiqDTipCod = "";
         ZZ1176LiqDComCod = "";
         ZZ1177LiqDFVcto = DateTime.MinValue;
         T003E17_A283LiqDTipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpliquidaciondoc__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpliquidaciondoc__default(),
            new Object[][] {
                new Object[] {
               T003E2_A282LiqDItem, T003E2_A1176LiqDComCod, T003E2_A1177LiqDFVcto, T003E2_A1169LiqDTot, T003E2_A236LiqPrvCod, T003E2_A270LiqCod, T003E2_A271LiqCodItem, T003E2_A283LiqDTipCod
               }
               , new Object[] {
               T003E3_A282LiqDItem, T003E3_A1176LiqDComCod, T003E3_A1177LiqDFVcto, T003E3_A1169LiqDTot, T003E3_A236LiqPrvCod, T003E3_A270LiqCod, T003E3_A271LiqCodItem, T003E3_A283LiqDTipCod
               }
               , new Object[] {
               T003E4_A270LiqCod
               }
               , new Object[] {
               T003E5_A283LiqDTipCod
               }
               , new Object[] {
               T003E6_A282LiqDItem, T003E6_A1176LiqDComCod, T003E6_A1177LiqDFVcto, T003E6_A1169LiqDTot, T003E6_A236LiqPrvCod, T003E6_A270LiqCod, T003E6_A271LiqCodItem, T003E6_A283LiqDTipCod
               }
               , new Object[] {
               T003E7_A270LiqCod
               }
               , new Object[] {
               T003E8_A283LiqDTipCod
               }
               , new Object[] {
               T003E9_A270LiqCod, T003E9_A236LiqPrvCod, T003E9_A271LiqCodItem, T003E9_A282LiqDItem
               }
               , new Object[] {
               T003E10_A270LiqCod, T003E10_A236LiqPrvCod, T003E10_A271LiqCodItem, T003E10_A282LiqDItem
               }
               , new Object[] {
               T003E11_A270LiqCod, T003E11_A236LiqPrvCod, T003E11_A271LiqCodItem, T003E11_A282LiqDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003E15_A270LiqCod, T003E15_A236LiqPrvCod, T003E15_A271LiqCodItem, T003E15_A282LiqDItem
               }
               , new Object[] {
               T003E16_A270LiqCod
               }
               , new Object[] {
               T003E17_A283LiqDTipCod
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
      private short RcdFound117 ;
      private short nIsDirty_117 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z271LiqCodItem ;
      private int Z282LiqDItem ;
      private int A271LiqCodItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLiqCod_Enabled ;
      private int edtLiqPrvCod_Enabled ;
      private int edtLiqCodItem_Enabled ;
      private int A282LiqDItem ;
      private int edtLiqDItem_Enabled ;
      private int edtLiqDTipCod_Enabled ;
      private int edtLiqDComCod_Enabled ;
      private int edtLiqDFVcto_Enabled ;
      private int edtLiqDTot_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ271LiqCodItem ;
      private int ZZ282LiqDItem ;
      private decimal Z1169LiqDTot ;
      private decimal A1169LiqDTot ;
      private decimal ZZ1169LiqDTot ;
      private string sPrefix ;
      private string Z236LiqPrvCod ;
      private string Z1176LiqDComCod ;
      private string Z283LiqDTipCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A236LiqPrvCod ;
      private string A283LiqDTipCod ;
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
      private string edtLiqDItem_Internalname ;
      private string edtLiqDItem_Jsonclick ;
      private string edtLiqDTipCod_Internalname ;
      private string edtLiqDTipCod_Jsonclick ;
      private string edtLiqDComCod_Internalname ;
      private string A1176LiqDComCod ;
      private string edtLiqDComCod_Jsonclick ;
      private string edtLiqDFVcto_Internalname ;
      private string edtLiqDFVcto_Jsonclick ;
      private string edtLiqDTot_Internalname ;
      private string edtLiqDTot_Jsonclick ;
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
      private string sMode117 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ236LiqPrvCod ;
      private string ZZ283LiqDTipCod ;
      private string ZZ1176LiqDComCod ;
      private DateTime Z1177LiqDFVcto ;
      private DateTime A1177LiqDFVcto ;
      private DateTime ZZ1177LiqDFVcto ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z270LiqCod ;
      private string A270LiqCod ;
      private string ZZ270LiqCod ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T003E6_A282LiqDItem ;
      private string[] T003E6_A1176LiqDComCod ;
      private DateTime[] T003E6_A1177LiqDFVcto ;
      private decimal[] T003E6_A1169LiqDTot ;
      private string[] T003E6_A236LiqPrvCod ;
      private string[] T003E6_A270LiqCod ;
      private int[] T003E6_A271LiqCodItem ;
      private string[] T003E6_A283LiqDTipCod ;
      private string[] T003E4_A270LiqCod ;
      private string[] T003E5_A283LiqDTipCod ;
      private string[] T003E7_A270LiqCod ;
      private string[] T003E8_A283LiqDTipCod ;
      private string[] T003E9_A270LiqCod ;
      private string[] T003E9_A236LiqPrvCod ;
      private int[] T003E9_A271LiqCodItem ;
      private int[] T003E9_A282LiqDItem ;
      private int[] T003E3_A282LiqDItem ;
      private string[] T003E3_A1176LiqDComCod ;
      private DateTime[] T003E3_A1177LiqDFVcto ;
      private decimal[] T003E3_A1169LiqDTot ;
      private string[] T003E3_A236LiqPrvCod ;
      private string[] T003E3_A270LiqCod ;
      private int[] T003E3_A271LiqCodItem ;
      private string[] T003E3_A283LiqDTipCod ;
      private string[] T003E10_A270LiqCod ;
      private string[] T003E10_A236LiqPrvCod ;
      private int[] T003E10_A271LiqCodItem ;
      private int[] T003E10_A282LiqDItem ;
      private string[] T003E11_A270LiqCod ;
      private string[] T003E11_A236LiqPrvCod ;
      private int[] T003E11_A271LiqCodItem ;
      private int[] T003E11_A282LiqDItem ;
      private int[] T003E2_A282LiqDItem ;
      private string[] T003E2_A1176LiqDComCod ;
      private DateTime[] T003E2_A1177LiqDFVcto ;
      private decimal[] T003E2_A1169LiqDTot ;
      private string[] T003E2_A236LiqPrvCod ;
      private string[] T003E2_A270LiqCod ;
      private int[] T003E2_A271LiqCodItem ;
      private string[] T003E2_A283LiqDTipCod ;
      private string[] T003E15_A270LiqCod ;
      private string[] T003E15_A236LiqPrvCod ;
      private int[] T003E15_A271LiqCodItem ;
      private int[] T003E15_A282LiqDItem ;
      private string[] T003E16_A270LiqCod ;
      private string[] T003E17_A283LiqDTipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpliquidaciondoc__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpliquidaciondoc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003E6;
        prmT003E6 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E4;
        prmT003E4 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003E5;
        prmT003E5 = new Object[] {
        new ParDef("@LiqDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003E7;
        prmT003E7 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003E8;
        prmT003E8 = new Object[] {
        new ParDef("@LiqDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003E9;
        prmT003E9 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E3;
        prmT003E3 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E10;
        prmT003E10 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E11;
        prmT003E11 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E2;
        prmT003E2 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E12;
        prmT003E12 = new Object[] {
        new ParDef("@LiqDItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDComCod",GXType.NChar,20,0) ,
        new ParDef("@LiqDFVcto",GXType.Date,8,0) ,
        new ParDef("@LiqDTot",GXType.Decimal,15,2) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDTipCod",GXType.NChar,3,0)
        };
        Object[] prmT003E13;
        prmT003E13 = new Object[] {
        new ParDef("@LiqDComCod",GXType.NChar,20,0) ,
        new ParDef("@LiqDFVcto",GXType.Date,8,0) ,
        new ParDef("@LiqDTot",GXType.Decimal,15,2) ,
        new ParDef("@LiqDTipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E14;
        prmT003E14 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0) ,
        new ParDef("@LiqDItem",GXType.Int32,6,0)
        };
        Object[] prmT003E15;
        prmT003E15 = new Object[] {
        };
        Object[] prmT003E16;
        prmT003E16 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqCodItem",GXType.Int32,6,0)
        };
        Object[] prmT003E17;
        prmT003E17 = new Object[] {
        new ParDef("@LiqDTipCod",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003E2", "SELECT [LiqDItem], [LiqDComCod], [LiqDFVcto], [LiqDTot], [LiqPrvCod], [LiqCod], [LiqCodItem], [LiqDTipCod] AS LiqDTipCod FROM [CPLIQUIDACIONDOC] WITH (UPDLOCK) WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem AND [LiqDItem] = @LiqDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E3", "SELECT [LiqDItem], [LiqDComCod], [LiqDFVcto], [LiqDTot], [LiqPrvCod], [LiqCod], [LiqCodItem], [LiqDTipCod] AS LiqDTipCod FROM [CPLIQUIDACIONDOC] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem AND [LiqDItem] = @LiqDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E4", "SELECT [LiqCod] FROM [CPLIQUIDACION] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E5", "SELECT [TipCod] AS LiqDTipCod FROM [CTIPDOC] WHERE [TipCod] = @LiqDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E6", "SELECT TM1.[LiqDItem], TM1.[LiqDComCod], TM1.[LiqDFVcto], TM1.[LiqDTot], TM1.[LiqPrvCod], TM1.[LiqCod], TM1.[LiqCodItem], TM1.[LiqDTipCod] AS LiqDTipCod FROM [CPLIQUIDACIONDOC] TM1 WHERE TM1.[LiqCod] = @LiqCod and TM1.[LiqPrvCod] = @LiqPrvCod and TM1.[LiqCodItem] = @LiqCodItem and TM1.[LiqDItem] = @LiqDItem ORDER BY TM1.[LiqCod], TM1.[LiqPrvCod], TM1.[LiqCodItem], TM1.[LiqDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E7", "SELECT [LiqCod] FROM [CPLIQUIDACION] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E8", "SELECT [TipCod] AS LiqDTipCod FROM [CTIPDOC] WHERE [TipCod] = @LiqDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E9", "SELECT [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem] FROM [CPLIQUIDACIONDOC] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem AND [LiqDItem] = @LiqDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003E9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E10", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem] FROM [CPLIQUIDACIONDOC] WHERE ( [LiqCod] > @LiqCod or [LiqCod] = @LiqCod and [LiqPrvCod] > @LiqPrvCod or [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqCodItem] > @LiqCodItem or [LiqCodItem] = @LiqCodItem and [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqDItem] > @LiqDItem) ORDER BY [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003E10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003E11", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem] FROM [CPLIQUIDACIONDOC] WHERE ( [LiqCod] < @LiqCod or [LiqCod] = @LiqCod and [LiqPrvCod] < @LiqPrvCod or [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqCodItem] < @LiqCodItem or [LiqCodItem] = @LiqCodItem and [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqDItem] < @LiqDItem) ORDER BY [LiqCod] DESC, [LiqPrvCod] DESC, [LiqCodItem] DESC, [LiqDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003E12", "INSERT INTO [CPLIQUIDACIONDOC]([LiqDItem], [LiqDComCod], [LiqDFVcto], [LiqDTot], [LiqPrvCod], [LiqCod], [LiqCodItem], [LiqDTipCod]) VALUES(@LiqDItem, @LiqDComCod, @LiqDFVcto, @LiqDTot, @LiqPrvCod, @LiqCod, @LiqCodItem, @LiqDTipCod)", GxErrorMask.GX_NOMASK,prmT003E12)
           ,new CursorDef("T003E13", "UPDATE [CPLIQUIDACIONDOC] SET [LiqDComCod]=@LiqDComCod, [LiqDFVcto]=@LiqDFVcto, [LiqDTot]=@LiqDTot, [LiqDTipCod]=@LiqDTipCod  WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem AND [LiqDItem] = @LiqDItem", GxErrorMask.GX_NOMASK,prmT003E13)
           ,new CursorDef("T003E14", "DELETE FROM [CPLIQUIDACIONDOC]  WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem AND [LiqDItem] = @LiqDItem", GxErrorMask.GX_NOMASK,prmT003E14)
           ,new CursorDef("T003E15", "SELECT [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem] FROM [CPLIQUIDACIONDOC] ORDER BY [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003E15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E16", "SELECT [LiqCod] FROM [CPLIQUIDACION] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqCodItem] = @LiqCodItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003E17", "SELECT [TipCod] AS LiqDTipCod FROM [CTIPDOC] WHERE [TipCod] = @LiqDTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003E17,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
