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
   public class clanticipos : GXDataArea
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
            A148CLAntCliCod = GetPar( "CLAntCliCod");
            AssignAttri("", false, "A148CLAntCliCod", A148CLAntCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A148CLAntCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A147CLAntMonCod = (int)(NumberUtil.Val( GetPar( "CLAntMonCod"), "."));
            AssignAttri("", false, "A147CLAntMonCod", StringUtil.LTrimStr( (decimal)(A147CLAntMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A147CLAntMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A146CLAntVenCod = (int)(NumberUtil.Val( GetPar( "CLAntVenCod"), "."));
            AssignAttri("", false, "A146CLAntVenCod", StringUtil.LTrimStr( (decimal)(A146CLAntVenCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A146CLAntVenCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            A24DocNum = GetPar( "DocNum");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A149TipCod, A24DocNum) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridclanticipos_level1") == 0 )
         {
            nRC_GXsfl_74 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."));
            nGXsfl_74_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."));
            sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGridclanticipos_level1_newrow( ) ;
            return  ;
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
            Form.Meta.addItem("description", "Anticipos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clanticipos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clanticipos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Anticipos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLANTICIPOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLANTICIPOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntTipCod_Internalname, "T/D", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntTipCod_Internalname, StringUtil.RTrim( A144CLAntTipCod), StringUtil.RTrim( context.localUtil.Format( A144CLAntTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntDocNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntDocNum_Internalname, "N° Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntDocNum_Internalname, StringUtil.RTrim( A145CLAntDocNum), StringUtil.RTrim( context.localUtil.Format( A145CLAntDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntCliCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntCliCod_Internalname, "U. C.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntCliCod_Internalname, StringUtil.RTrim( A148CLAntCliCod), StringUtil.RTrim( context.localUtil.Format( A148CLAntCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntCliDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntCliDsc_Internalname, "Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCLAntCliDsc_Internalname, StringUtil.RTrim( A551CLAntCliDsc), StringUtil.RTrim( context.localUtil.Format( A551CLAntCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A147CLAntMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCLAntMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A147CLAntMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A147CLAntMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntImporte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntImporte_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A554CLAntImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtCLAntImporte_Enabled!=0) ? context.localUtil.Format( A554CLAntImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A554CLAntImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClAntFecha_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClAntFecha_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtClAntFecha_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtClAntFecha_Internalname, context.localUtil.Format(A553ClAntFecha, "99/99/99"), context.localUtil.Format( A553ClAntFecha, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClAntFecha_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClAntFecha_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_bitmap( context, edtClAntFecha_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtClAntFecha_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CLANTICIPOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntImpPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntImpPago_Internalname, "Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntImpPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A555CLAntImpPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtCLAntImpPago_Enabled!=0) ? context.localUtil.Format( A555CLAntImpPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A555CLAntImpPago, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntImpPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntImpPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntVenCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntVenCod_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntVenCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A146CLAntVenCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCLAntVenCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A146CLAntVenCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A146CLAntVenCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntVenCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntVenCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitlelevel1_Internalname, "Level1", "", "", lblTitlelevel1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3", "left", "top", "", "", "div");
         gxdraw_Gridclanticipos_level1( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridclanticipos_level1( )
      {
         /*  Grid Control  */
         Gridclanticipos_level1Container.AddObjectProperty("GridName", "Gridclanticipos_level1");
         Gridclanticipos_level1Container.AddObjectProperty("Header", subGridclanticipos_level1_Header);
         Gridclanticipos_level1Container.AddObjectProperty("Class", "Grid");
         Gridclanticipos_level1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Backcolorstyle), 1, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("CmpContext", "");
         Gridclanticipos_level1Container.AddObjectProperty("InMasterPage", "false");
         Gridclanticipos_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclanticipos_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A149TipCod));
         Gridclanticipos_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", "")));
         Gridclanticipos_level1Container.AddColumnProperties(Gridclanticipos_level1Column);
         Gridclanticipos_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclanticipos_level1Column.AddObjectProperty("Value", StringUtil.RTrim( A24DocNum));
         Gridclanticipos_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocNum_Enabled), 5, 0, ".", "")));
         Gridclanticipos_level1Container.AddColumnProperties(Gridclanticipos_level1Column);
         Gridclanticipos_level1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridclanticipos_level1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A552CLAntDImporte, 17, 2, ".", "")));
         Gridclanticipos_level1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCLAntDImporte_Enabled), 5, 0, ".", "")));
         Gridclanticipos_level1Container.AddColumnProperties(Gridclanticipos_level1Column);
         Gridclanticipos_level1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Selectedindex), 4, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Allowselection), 1, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Selectioncolor), 9, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Allowhovering), 1, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Hoveringcolor), 9, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Allowcollapsing), 1, 0, ".", "")));
         Gridclanticipos_level1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridclanticipos_level1_Collapsed), 1, 0, ".", "")));
         nGXsfl_74_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount8 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_8 = 1;
               ScanStart2D8( ) ;
               while ( RcdFound8 != 0 )
               {
                  init_level_properties8( ) ;
                  getByPrimaryKey2D8( ) ;
                  AddRow2D8( ) ;
                  ScanNext2D8( ) ;
               }
               ScanEnd2D8( ) ;
               nBlankRcdCount8 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal2D8( ) ;
            standaloneModal2D8( ) ;
            sMode8 = Gx_mode;
            while ( nGXsfl_74_idx < nRC_GXsfl_74 )
            {
               bGXsfl_74_Refreshing = true;
               ReadRow2D8( ) ;
               edtTipCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "TIPCOD_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtDocNum_Enabled = (int)(context.localUtil.CToN( cgiGet( "DOCNUM_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               edtCLAntDImporte_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLANTDIMPORTE_"+sGXsfl_74_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCLAntDImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntDImporte_Enabled), 5, 0), !bGXsfl_74_Refreshing);
               if ( ( nRcdExists_8 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal2D8( ) ;
               }
               SendRow2D8( ) ;
               bGXsfl_74_Refreshing = false;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount8 = 5;
            nRcdExists_8 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart2D8( ) ;
               while ( RcdFound8 != 0 )
               {
                  sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_748( ) ;
                  init_level_properties8( ) ;
                  standaloneNotModal2D8( ) ;
                  getByPrimaryKey2D8( ) ;
                  standaloneModal2D8( ) ;
                  AddRow2D8( ) ;
                  ScanNext2D8( ) ;
               }
               ScanEnd2D8( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode8 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx+1), 4, 0), 4, "0");
         SubsflControlProps_748( ) ;
         InitAll2D8( ) ;
         init_level_properties8( ) ;
         nRcdExists_8 = 0;
         nIsMod_8 = 0;
         nRcdDeleted_8 = 0;
         nBlankRcdCount8 = (short)(nBlankRcdUsr8+nBlankRcdCount8);
         fRowAdded = 0;
         while ( nBlankRcdCount8 > 0 )
         {
            standaloneNotModal2D8( ) ;
            standaloneModal2D8( ) ;
            AddRow2D8( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount8 = (short)(nBlankRcdCount8-1);
         }
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridclanticipos_level1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridclanticipos_level1", Gridclanticipos_level1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridclanticipos_level1ContainerData", Gridclanticipos_level1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridclanticipos_level1ContainerData"+"V", Gridclanticipos_level1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridclanticipos_level1ContainerData"+"V"+"\" value='"+Gridclanticipos_level1Container.GridValuesHidden()+"'/>") ;
         }
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
            Z144CLAntTipCod = cgiGet( "Z144CLAntTipCod");
            Z145CLAntDocNum = cgiGet( "Z145CLAntDocNum");
            Z554CLAntImporte = context.localUtil.CToN( cgiGet( "Z554CLAntImporte"), ".", ",");
            Z553ClAntFecha = context.localUtil.CToD( cgiGet( "Z553ClAntFecha"), 0);
            Z555CLAntImpPago = context.localUtil.CToN( cgiGet( "Z555CLAntImpPago"), ".", ",");
            Z148CLAntCliCod = cgiGet( "Z148CLAntCliCod");
            Z147CLAntMonCod = (int)(context.localUtil.CToN( cgiGet( "Z147CLAntMonCod"), ".", ","));
            Z146CLAntVenCod = (int)(context.localUtil.CToN( cgiGet( "Z146CLAntVenCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_74 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ".", ","));
            /* Read variables values. */
            A144CLAntTipCod = cgiGet( edtCLAntTipCod_Internalname);
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = cgiGet( edtCLAntDocNum_Internalname);
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            A148CLAntCliCod = cgiGet( edtCLAntCliCod_Internalname);
            AssignAttri("", false, "A148CLAntCliCod", A148CLAntCliCod);
            A551CLAntCliDsc = cgiGet( edtCLAntCliDsc_Internalname);
            AssignAttri("", false, "A551CLAntCliDsc", A551CLAntCliDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLAntMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLAntMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLANTMONCOD");
               AnyError = 1;
               GX_FocusControl = edtCLAntMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A147CLAntMonCod = 0;
               AssignAttri("", false, "A147CLAntMonCod", StringUtil.LTrimStr( (decimal)(A147CLAntMonCod), 6, 0));
            }
            else
            {
               A147CLAntMonCod = (int)(context.localUtil.CToN( cgiGet( edtCLAntMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A147CLAntMonCod", StringUtil.LTrimStr( (decimal)(A147CLAntMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLAntImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCLAntImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLANTIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtCLAntImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A554CLAntImporte = 0;
               AssignAttri("", false, "A554CLAntImporte", StringUtil.LTrimStr( A554CLAntImporte, 15, 2));
            }
            else
            {
               A554CLAntImporte = context.localUtil.CToN( cgiGet( edtCLAntImporte_Internalname), ".", ",");
               AssignAttri("", false, "A554CLAntImporte", StringUtil.LTrimStr( A554CLAntImporte, 15, 2));
            }
            if ( context.localUtil.VCDate( cgiGet( edtClAntFecha_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "CLANTFECHA");
               AnyError = 1;
               GX_FocusControl = edtClAntFecha_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A553ClAntFecha = DateTime.MinValue;
               AssignAttri("", false, "A553ClAntFecha", context.localUtil.Format(A553ClAntFecha, "99/99/99"));
            }
            else
            {
               A553ClAntFecha = context.localUtil.CToD( cgiGet( edtClAntFecha_Internalname), 2);
               AssignAttri("", false, "A553ClAntFecha", context.localUtil.Format(A553ClAntFecha, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLAntImpPago_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCLAntImpPago_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLANTIMPPAGO");
               AnyError = 1;
               GX_FocusControl = edtCLAntImpPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A555CLAntImpPago = 0;
               AssignAttri("", false, "A555CLAntImpPago", StringUtil.LTrimStr( A555CLAntImpPago, 15, 2));
            }
            else
            {
               A555CLAntImpPago = context.localUtil.CToN( cgiGet( edtCLAntImpPago_Internalname), ".", ",");
               AssignAttri("", false, "A555CLAntImpPago", StringUtil.LTrimStr( A555CLAntImpPago, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLAntVenCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCLAntVenCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLANTVENCOD");
               AnyError = 1;
               GX_FocusControl = edtCLAntVenCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A146CLAntVenCod = 0;
               AssignAttri("", false, "A146CLAntVenCod", StringUtil.LTrimStr( (decimal)(A146CLAntVenCod), 6, 0));
            }
            else
            {
               A146CLAntVenCod = (int)(context.localUtil.CToN( cgiGet( edtCLAntVenCod_Internalname), ".", ","));
               AssignAttri("", false, "A146CLAntVenCod", StringUtil.LTrimStr( (decimal)(A146CLAntVenCod), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A144CLAntTipCod = GetPar( "CLAntTipCod");
               AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
               A145CLAntDocNum = GetPar( "CLAntDocNum");
               AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll2D82( ) ;
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
         DisableAttributes2D82( ) ;
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

      protected void CONFIRM_2D8( )
      {
         nGXsfl_74_idx = 0;
         while ( nGXsfl_74_idx < nRC_GXsfl_74 )
         {
            ReadRow2D8( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               GetKey2D8( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  if ( RcdFound8 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate2D8( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable2D8( ) ;
                        CloseExtendedTableCursors2D8( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "TIPCOD_" + sGXsfl_74_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( nRcdDeleted_8 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey2D8( ) ;
                        Load2D8( ) ;
                        BeforeValidate2D8( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls2D8( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate2D8( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable2D8( ) ;
                              CloseExtendedTableCursors2D8( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "TIPCOD_" + sGXsfl_74_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTipCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtTipCod_Internalname, StringUtil.RTrim( A149TipCod)) ;
            ChangePostValue( edtDocNum_Internalname, StringUtil.RTrim( A24DocNum)) ;
            ChangePostValue( edtCLAntDImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A552CLAntDImporte, 17, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z149TipCod_"+sGXsfl_74_idx, StringUtil.RTrim( Z149TipCod)) ;
            ChangePostValue( "ZT_"+"Z24DocNum_"+sGXsfl_74_idx, StringUtil.RTrim( Z24DocNum)) ;
            ChangePostValue( "ZT_"+"Z552CLAntDImporte_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( Z552CLAntDImporte, 15, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_8_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_8_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_8_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ".", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( "TIPCOD_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DOCNUM_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocNum_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLANTDIMPORTE_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCLAntDImporte_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption2D0( )
      {
      }

      protected void ZM2D82( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z554CLAntImporte = T002D6_A554CLAntImporte[0];
               Z553ClAntFecha = T002D6_A553ClAntFecha[0];
               Z555CLAntImpPago = T002D6_A555CLAntImpPago[0];
               Z148CLAntCliCod = T002D6_A148CLAntCliCod[0];
               Z147CLAntMonCod = T002D6_A147CLAntMonCod[0];
               Z146CLAntVenCod = T002D6_A146CLAntVenCod[0];
            }
            else
            {
               Z554CLAntImporte = A554CLAntImporte;
               Z553ClAntFecha = A553ClAntFecha;
               Z555CLAntImpPago = A555CLAntImpPago;
               Z148CLAntCliCod = A148CLAntCliCod;
               Z147CLAntMonCod = A147CLAntMonCod;
               Z146CLAntVenCod = A146CLAntVenCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z144CLAntTipCod = A144CLAntTipCod;
            Z145CLAntDocNum = A145CLAntDocNum;
            Z554CLAntImporte = A554CLAntImporte;
            Z553ClAntFecha = A553ClAntFecha;
            Z555CLAntImpPago = A555CLAntImpPago;
            Z148CLAntCliCod = A148CLAntCliCod;
            Z147CLAntMonCod = A147CLAntMonCod;
            Z146CLAntVenCod = A146CLAntVenCod;
            Z551CLAntCliDsc = A551CLAntCliDsc;
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

      protected void Load2D82( )
      {
         /* Using cursor T002D10 */
         pr_default.execute(8, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound82 = 1;
            A551CLAntCliDsc = T002D10_A551CLAntCliDsc[0];
            AssignAttri("", false, "A551CLAntCliDsc", A551CLAntCliDsc);
            A554CLAntImporte = T002D10_A554CLAntImporte[0];
            AssignAttri("", false, "A554CLAntImporte", StringUtil.LTrimStr( A554CLAntImporte, 15, 2));
            A553ClAntFecha = T002D10_A553ClAntFecha[0];
            AssignAttri("", false, "A553ClAntFecha", context.localUtil.Format(A553ClAntFecha, "99/99/99"));
            A555CLAntImpPago = T002D10_A555CLAntImpPago[0];
            AssignAttri("", false, "A555CLAntImpPago", StringUtil.LTrimStr( A555CLAntImpPago, 15, 2));
            A148CLAntCliCod = T002D10_A148CLAntCliCod[0];
            AssignAttri("", false, "A148CLAntCliCod", A148CLAntCliCod);
            A147CLAntMonCod = T002D10_A147CLAntMonCod[0];
            AssignAttri("", false, "A147CLAntMonCod", StringUtil.LTrimStr( (decimal)(A147CLAntMonCod), 6, 0));
            A146CLAntVenCod = T002D10_A146CLAntVenCod[0];
            AssignAttri("", false, "A146CLAntVenCod", StringUtil.LTrimStr( (decimal)(A146CLAntVenCod), 6, 0));
            ZM2D82( -2) ;
         }
         pr_default.close(8);
         OnLoadActions2D82( ) ;
      }

      protected void OnLoadActions2D82( )
      {
      }

      protected void CheckExtendedTable2D82( )
      {
         nIsDirty_82 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002D7 */
         pr_default.execute(5, new Object[] {A148CLAntCliCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLANTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A551CLAntCliDsc = T002D7_A551CLAntCliDsc[0];
         AssignAttri("", false, "A551CLAntCliDsc", A551CLAntCliDsc);
         pr_default.close(5);
         /* Using cursor T002D8 */
         pr_default.execute(6, new Object[] {A147CLAntMonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CLANTMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A553ClAntFecha) || ( DateTimeUtil.ResetTime ( A553ClAntFecha ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "CLANTFECHA");
            AnyError = 1;
            GX_FocusControl = edtClAntFecha_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T002D9 */
         pr_default.execute(7, new Object[] {A146CLAntVenCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Anticipo Vendedor'.", "ForeignKeyNotFound", 1, "CLANTVENCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntVenCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors2D82( )
      {
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A148CLAntCliCod )
      {
         /* Using cursor T002D11 */
         pr_default.execute(9, new Object[] {A148CLAntCliCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLANTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A551CLAntCliDsc = T002D11_A551CLAntCliDsc[0];
         AssignAttri("", false, "A551CLAntCliDsc", A551CLAntCliDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A551CLAntCliDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_4( int A147CLAntMonCod )
      {
         /* Using cursor T002D12 */
         pr_default.execute(10, new Object[] {A147CLAntMonCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CLANTMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_5( int A146CLAntVenCod )
      {
         /* Using cursor T002D13 */
         pr_default.execute(11, new Object[] {A146CLAntVenCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Anticipo Vendedor'.", "ForeignKeyNotFound", 1, "CLANTVENCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntVenCod_Internalname;
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

      protected void GetKey2D82( )
      {
         /* Using cursor T002D14 */
         pr_default.execute(12, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound82 = 1;
         }
         else
         {
            RcdFound82 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002D6 */
         pr_default.execute(4, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM2D82( 2) ;
            RcdFound82 = 1;
            A144CLAntTipCod = T002D6_A144CLAntTipCod[0];
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = T002D6_A145CLAntDocNum[0];
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            A554CLAntImporte = T002D6_A554CLAntImporte[0];
            AssignAttri("", false, "A554CLAntImporte", StringUtil.LTrimStr( A554CLAntImporte, 15, 2));
            A553ClAntFecha = T002D6_A553ClAntFecha[0];
            AssignAttri("", false, "A553ClAntFecha", context.localUtil.Format(A553ClAntFecha, "99/99/99"));
            A555CLAntImpPago = T002D6_A555CLAntImpPago[0];
            AssignAttri("", false, "A555CLAntImpPago", StringUtil.LTrimStr( A555CLAntImpPago, 15, 2));
            A148CLAntCliCod = T002D6_A148CLAntCliCod[0];
            AssignAttri("", false, "A148CLAntCliCod", A148CLAntCliCod);
            A147CLAntMonCod = T002D6_A147CLAntMonCod[0];
            AssignAttri("", false, "A147CLAntMonCod", StringUtil.LTrimStr( (decimal)(A147CLAntMonCod), 6, 0));
            A146CLAntVenCod = T002D6_A146CLAntVenCod[0];
            AssignAttri("", false, "A146CLAntVenCod", StringUtil.LTrimStr( (decimal)(A146CLAntVenCod), 6, 0));
            Z144CLAntTipCod = A144CLAntTipCod;
            Z145CLAntDocNum = A145CLAntDocNum;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2D82( ) ;
            if ( AnyError == 1 )
            {
               RcdFound82 = 0;
               InitializeNonKey2D82( ) ;
            }
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound82 = 0;
            InitializeNonKey2D82( ) ;
            sMode82 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode82;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey2D82( ) ;
         if ( RcdFound82 == 0 )
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
         RcdFound82 = 0;
         /* Using cursor T002D15 */
         pr_default.execute(13, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002D15_A144CLAntTipCod[0], A144CLAntTipCod) < 0 ) || ( StringUtil.StrCmp(T002D15_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T002D15_A145CLAntDocNum[0], A145CLAntDocNum) < 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T002D15_A144CLAntTipCod[0], A144CLAntTipCod) > 0 ) || ( StringUtil.StrCmp(T002D15_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T002D15_A145CLAntDocNum[0], A145CLAntDocNum) > 0 ) ) )
            {
               A144CLAntTipCod = T002D15_A144CLAntTipCod[0];
               AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
               A145CLAntDocNum = T002D15_A145CLAntDocNum[0];
               AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
               RcdFound82 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound82 = 0;
         /* Using cursor T002D16 */
         pr_default.execute(14, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T002D16_A144CLAntTipCod[0], A144CLAntTipCod) > 0 ) || ( StringUtil.StrCmp(T002D16_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T002D16_A145CLAntDocNum[0], A145CLAntDocNum) > 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T002D16_A144CLAntTipCod[0], A144CLAntTipCod) < 0 ) || ( StringUtil.StrCmp(T002D16_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T002D16_A145CLAntDocNum[0], A145CLAntDocNum) < 0 ) ) )
            {
               A144CLAntTipCod = T002D16_A144CLAntTipCod[0];
               AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
               A145CLAntDocNum = T002D16_A145CLAntDocNum[0];
               AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
               RcdFound82 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2D82( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2D82( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound82 == 1 )
            {
               if ( ( StringUtil.StrCmp(A144CLAntTipCod, Z144CLAntTipCod) != 0 ) || ( StringUtil.StrCmp(A145CLAntDocNum, Z145CLAntDocNum) != 0 ) )
               {
                  A144CLAntTipCod = Z144CLAntTipCod;
                  AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
                  A145CLAntDocNum = Z145CLAntDocNum;
                  AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLANTTIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCLAntTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCLAntTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2D82( ) ;
                  GX_FocusControl = edtCLAntTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A144CLAntTipCod, Z144CLAntTipCod) != 0 ) || ( StringUtil.StrCmp(A145CLAntDocNum, Z145CLAntDocNum) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCLAntTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2D82( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLANTTIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCLAntTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCLAntTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2D82( ) ;
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
         if ( ( StringUtil.StrCmp(A144CLAntTipCod, Z144CLAntTipCod) != 0 ) || ( StringUtil.StrCmp(A145CLAntDocNum, Z145CLAntDocNum) != 0 ) )
         {
            A144CLAntTipCod = Z144CLAntTipCod;
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = Z145CLAntDocNum;
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLANTTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCLAntTipCod_Internalname;
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
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLANTTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCLAntCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2D82( ) ;
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2D82( ) ;
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
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntCliCod_Internalname;
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
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntCliCod_Internalname;
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
         ScanStart2D82( ) ;
         if ( RcdFound82 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound82 != 0 )
            {
               ScanNext2D82( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2D82( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2D82( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002D5 */
            pr_default.execute(3, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLANTICIPOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( Z554CLAntImporte != T002D5_A554CLAntImporte[0] ) || ( DateTimeUtil.ResetTime ( Z553ClAntFecha ) != DateTimeUtil.ResetTime ( T002D5_A553ClAntFecha[0] ) ) || ( Z555CLAntImpPago != T002D5_A555CLAntImpPago[0] ) || ( StringUtil.StrCmp(Z148CLAntCliCod, T002D5_A148CLAntCliCod[0]) != 0 ) || ( Z147CLAntMonCod != T002D5_A147CLAntMonCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z146CLAntVenCod != T002D5_A146CLAntVenCod[0] ) )
            {
               if ( Z554CLAntImporte != T002D5_A554CLAntImporte[0] )
               {
                  GXUtil.WriteLog("clanticipos:[seudo value changed for attri]"+"CLAntImporte");
                  GXUtil.WriteLogRaw("Old: ",Z554CLAntImporte);
                  GXUtil.WriteLogRaw("Current: ",T002D5_A554CLAntImporte[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z553ClAntFecha ) != DateTimeUtil.ResetTime ( T002D5_A553ClAntFecha[0] ) )
               {
                  GXUtil.WriteLog("clanticipos:[seudo value changed for attri]"+"ClAntFecha");
                  GXUtil.WriteLogRaw("Old: ",Z553ClAntFecha);
                  GXUtil.WriteLogRaw("Current: ",T002D5_A553ClAntFecha[0]);
               }
               if ( Z555CLAntImpPago != T002D5_A555CLAntImpPago[0] )
               {
                  GXUtil.WriteLog("clanticipos:[seudo value changed for attri]"+"CLAntImpPago");
                  GXUtil.WriteLogRaw("Old: ",Z555CLAntImpPago);
                  GXUtil.WriteLogRaw("Current: ",T002D5_A555CLAntImpPago[0]);
               }
               if ( StringUtil.StrCmp(Z148CLAntCliCod, T002D5_A148CLAntCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("clanticipos:[seudo value changed for attri]"+"CLAntCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z148CLAntCliCod);
                  GXUtil.WriteLogRaw("Current: ",T002D5_A148CLAntCliCod[0]);
               }
               if ( Z147CLAntMonCod != T002D5_A147CLAntMonCod[0] )
               {
                  GXUtil.WriteLog("clanticipos:[seudo value changed for attri]"+"CLAntMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z147CLAntMonCod);
                  GXUtil.WriteLogRaw("Current: ",T002D5_A147CLAntMonCod[0]);
               }
               if ( Z146CLAntVenCod != T002D5_A146CLAntVenCod[0] )
               {
                  GXUtil.WriteLog("clanticipos:[seudo value changed for attri]"+"CLAntVenCod");
                  GXUtil.WriteLogRaw("Old: ",Z146CLAntVenCod);
                  GXUtil.WriteLogRaw("Current: ",T002D5_A146CLAntVenCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLANTICIPOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2D82( )
      {
         BeforeValidate2D82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D82( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2D82( 0) ;
            CheckOptimisticConcurrency2D82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2D82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D17 */
                     pr_default.execute(15, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A554CLAntImporte, A553ClAntFecha, A555CLAntImpPago, A148CLAntCliCod, A147CLAntMonCod, A146CLAntVenCod});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOS");
                     if ( (pr_default.getStatus(15) == 1) )
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
                           ProcessLevel2D82( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption2D0( ) ;
                           }
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
               Load2D82( ) ;
            }
            EndLevel2D82( ) ;
         }
         CloseExtendedTableCursors2D82( ) ;
      }

      protected void Update2D82( )
      {
         BeforeValidate2D82( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D82( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D82( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D82( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2D82( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D18 */
                     pr_default.execute(16, new Object[] {A554CLAntImporte, A553ClAntFecha, A555CLAntImpPago, A148CLAntCliCod, A147CLAntMonCod, A146CLAntVenCod, A144CLAntTipCod, A145CLAntDocNum});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOS");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLANTICIPOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2D82( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel2D82( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption2D0( ) ;
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
            }
            EndLevel2D82( ) ;
         }
         CloseExtendedTableCursors2D82( ) ;
      }

      protected void DeferredUpdate2D82( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2D82( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D82( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2D82( ) ;
            AfterConfirm2D82( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2D82( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart2D8( ) ;
                  while ( RcdFound8 != 0 )
                  {
                     getByPrimaryKey2D8( ) ;
                     Delete2D8( ) ;
                     ScanNext2D8( ) ;
                  }
                  ScanEnd2D8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D19 */
                     pr_default.execute(17, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound82 == 0 )
                           {
                              InitAll2D82( ) ;
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
                           ResetCaption2D0( ) ;
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
         }
         sMode82 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2D82( ) ;
         Gx_mode = sMode82;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2D82( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002D20 */
            pr_default.execute(18, new Object[] {A148CLAntCliCod});
            A551CLAntCliDsc = T002D20_A551CLAntCliDsc[0];
            AssignAttri("", false, "A551CLAntCliDsc", A551CLAntCliDsc);
            pr_default.close(18);
         }
      }

      protected void ProcessNestedLevel2D8( )
      {
         nGXsfl_74_idx = 0;
         while ( nGXsfl_74_idx < nRC_GXsfl_74 )
         {
            ReadRow2D8( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               standaloneNotModal2D8( ) ;
               GetKey2D8( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert2D8( ) ;
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( ( nRcdDeleted_8 != 0 ) && ( nRcdExists_8 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete2D8( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update2D8( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "TIPCOD_" + sGXsfl_74_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtTipCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtTipCod_Internalname, StringUtil.RTrim( A149TipCod)) ;
            ChangePostValue( edtDocNum_Internalname, StringUtil.RTrim( A24DocNum)) ;
            ChangePostValue( edtCLAntDImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A552CLAntDImporte, 17, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z149TipCod_"+sGXsfl_74_idx, StringUtil.RTrim( Z149TipCod)) ;
            ChangePostValue( "ZT_"+"Z24DocNum_"+sGXsfl_74_idx, StringUtil.RTrim( Z24DocNum)) ;
            ChangePostValue( "ZT_"+"Z552CLAntDImporte_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( Z552CLAntDImporte, 15, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_8_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_8_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_8_"+sGXsfl_74_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ".", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( "TIPCOD_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "DOCNUM_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocNum_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CLANTDIMPORTE_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCLAntDImporte_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll2D8( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_8 = 0;
         nIsMod_8 = 0;
         nRcdDeleted_8 = 0;
      }

      protected void ProcessLevel2D82( )
      {
         /* Save parent mode. */
         sMode82 = Gx_mode;
         ProcessNestedLevel2D8( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode82;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel2D82( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2D82( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(18);
            pr_default.close(2);
            context.CommitDataStores("clanticipos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(18);
            pr_default.close(2);
            context.RollbackDataStores("clanticipos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2D82( )
      {
         /* Using cursor T002D21 */
         pr_default.execute(19);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound82 = 1;
            A144CLAntTipCod = T002D21_A144CLAntTipCod[0];
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = T002D21_A145CLAntDocNum[0];
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2D82( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound82 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound82 = 1;
            A144CLAntTipCod = T002D21_A144CLAntTipCod[0];
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = T002D21_A145CLAntDocNum[0];
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
         }
      }

      protected void ScanEnd2D82( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm2D82( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2D82( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2D82( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2D82( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2D82( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2D82( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2D82( )
      {
         edtCLAntTipCod_Enabled = 0;
         AssignProp("", false, edtCLAntTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntTipCod_Enabled), 5, 0), true);
         edtCLAntDocNum_Enabled = 0;
         AssignProp("", false, edtCLAntDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntDocNum_Enabled), 5, 0), true);
         edtCLAntCliCod_Enabled = 0;
         AssignProp("", false, edtCLAntCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntCliCod_Enabled), 5, 0), true);
         edtCLAntCliDsc_Enabled = 0;
         AssignProp("", false, edtCLAntCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntCliDsc_Enabled), 5, 0), true);
         edtCLAntMonCod_Enabled = 0;
         AssignProp("", false, edtCLAntMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntMonCod_Enabled), 5, 0), true);
         edtCLAntImporte_Enabled = 0;
         AssignProp("", false, edtCLAntImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntImporte_Enabled), 5, 0), true);
         edtClAntFecha_Enabled = 0;
         AssignProp("", false, edtClAntFecha_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClAntFecha_Enabled), 5, 0), true);
         edtCLAntImpPago_Enabled = 0;
         AssignProp("", false, edtCLAntImpPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntImpPago_Enabled), 5, 0), true);
         edtCLAntVenCod_Enabled = 0;
         AssignProp("", false, edtCLAntVenCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntVenCod_Enabled), 5, 0), true);
      }

      protected void ZM2D8( short GX_JID )
      {
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z552CLAntDImporte = T002D3_A552CLAntDImporte[0];
            }
            else
            {
               Z552CLAntDImporte = A552CLAntDImporte;
            }
         }
         if ( GX_JID == -6 )
         {
            Z144CLAntTipCod = A144CLAntTipCod;
            Z145CLAntDocNum = A145CLAntDocNum;
            Z552CLAntDImporte = A552CLAntDImporte;
            Z149TipCod = A149TipCod;
            Z24DocNum = A24DocNum;
         }
      }

      protected void standaloneNotModal2D8( )
      {
      }

      protected void standaloneModal2D8( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtTipCod_Enabled = 0;
            AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         }
         else
         {
            edtTipCod_Enabled = 1;
            AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtDocNum_Enabled = 0;
            AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         }
         else
         {
            edtDocNum_Enabled = 1;
            AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         }
      }

      protected void Load2D8( )
      {
         /* Using cursor T002D22 */
         pr_default.execute(20, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound8 = 1;
            A552CLAntDImporte = T002D22_A552CLAntDImporte[0];
            ZM2D8( -6) ;
         }
         pr_default.close(20);
         OnLoadActions2D8( ) ;
      }

      protected void OnLoadActions2D8( )
      {
      }

      protected void CheckExtendedTable2D8( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal2D8( ) ;
         /* Using cursor T002D4 */
         pr_default.execute(2, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "DOCNUM_" + sGXsfl_74_idx;
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors2D8( )
      {
         pr_default.close(2);
      }

      protected void enableDisable2D8( )
      {
      }

      protected void gxLoad_7( string A149TipCod ,
                               string A24DocNum )
      {
         /* Using cursor T002D23 */
         pr_default.execute(21, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GXCCtl = "DOCNUM_" + sGXsfl_74_idx;
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void GetKey2D8( )
      {
         /* Using cursor T002D24 */
         pr_default.execute(22, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(22);
      }

      protected void getByPrimaryKey2D8( )
      {
         /* Using cursor T002D3 */
         pr_default.execute(1, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2D8( 6) ;
            RcdFound8 = 1;
            InitializeNonKey2D8( ) ;
            A552CLAntDImporte = T002D3_A552CLAntDImporte[0];
            A149TipCod = T002D3_A149TipCod[0];
            A24DocNum = T002D3_A24DocNum[0];
            Z144CLAntTipCod = A144CLAntTipCod;
            Z145CLAntDocNum = A145CLAntDocNum;
            Z149TipCod = A149TipCod;
            Z24DocNum = A24DocNum;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2D8( ) ;
            Load2D8( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey2D8( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal2D8( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes2D8( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency2D8( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002D2 */
            pr_default.execute(0, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLANTICIPOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z552CLAntDImporte != T002D2_A552CLAntDImporte[0] ) )
            {
               if ( Z552CLAntDImporte != T002D2_A552CLAntDImporte[0] )
               {
                  GXUtil.WriteLog("clanticipos:[seudo value changed for attri]"+"CLAntDImporte");
                  GXUtil.WriteLogRaw("Old: ",Z552CLAntDImporte);
                  GXUtil.WriteLogRaw("Current: ",T002D2_A552CLAntDImporte[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLANTICIPOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2D8( )
      {
         BeforeValidate2D8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D8( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2D8( 0) ;
            CheckOptimisticConcurrency2D8( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2D8( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2D8( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002D25 */
                     pr_default.execute(23, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A552CLAntDImporte, A149TipCod, A24DocNum});
                     pr_default.close(23);
                     dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOSDET");
                     if ( (pr_default.getStatus(23) == 1) )
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
               Load2D8( ) ;
            }
            EndLevel2D8( ) ;
         }
         CloseExtendedTableCursors2D8( ) ;
      }

      protected void Update2D8( )
      {
         BeforeValidate2D8( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2D8( ) ;
         }
         if ( ( nIsMod_8 != 0 ) || ( nIsDirty_8 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency2D8( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm2D8( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate2D8( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T002D26 */
                        pr_default.execute(24, new Object[] {A552CLAntDImporte, A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
                        pr_default.close(24);
                        dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOSDET");
                        if ( (pr_default.getStatus(24) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLANTICIPOSDET"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate2D8( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey2D8( ) ;
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
               EndLevel2D8( ) ;
            }
         }
         CloseExtendedTableCursors2D8( ) ;
      }

      protected void DeferredUpdate2D8( )
      {
      }

      protected void Delete2D8( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2D8( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2D8( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2D8( ) ;
            AfterConfirm2D8( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2D8( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002D27 */
                  pr_default.execute(25, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
                  pr_default.close(25);
                  dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2D8( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2D8( )
      {
         standaloneModal2D8( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel2D8( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2D8( )
      {
         /* Scan By routine */
         /* Using cursor T002D28 */
         pr_default.execute(26, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound8 = 1;
            A149TipCod = T002D28_A149TipCod[0];
            A24DocNum = T002D28_A24DocNum[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2D8( )
      {
         /* Scan next routine */
         pr_default.readNext(26);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound8 = 1;
            A149TipCod = T002D28_A149TipCod[0];
            A24DocNum = T002D28_A24DocNum[0];
         }
      }

      protected void ScanEnd2D8( )
      {
         pr_default.close(26);
      }

      protected void AfterConfirm2D8( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2D8( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2D8( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2D8( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2D8( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2D8( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2D8( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtDocNum_Enabled = 0;
         AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtCLAntDImporte_Enabled = 0;
         AssignProp("", false, edtCLAntDImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntDImporte_Enabled), 5, 0), !bGXsfl_74_Refreshing);
      }

      protected void send_integrity_lvl_hashes2D8( )
      {
      }

      protected void send_integrity_lvl_hashes2D82( )
      {
      }

      protected void SubsflControlProps_748( )
      {
         edtTipCod_Internalname = "TIPCOD_"+sGXsfl_74_idx;
         edtDocNum_Internalname = "DOCNUM_"+sGXsfl_74_idx;
         edtCLAntDImporte_Internalname = "CLANTDIMPORTE_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_748( )
      {
         edtTipCod_Internalname = "TIPCOD_"+sGXsfl_74_fel_idx;
         edtDocNum_Internalname = "DOCNUM_"+sGXsfl_74_fel_idx;
         edtCLAntDImporte_Internalname = "CLANTDIMPORTE_"+sGXsfl_74_fel_idx;
      }

      protected void AddRow2D8( )
      {
         nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_748( ) ;
         SendRow2D8( ) ;
      }

      protected void SendRow2D8( )
      {
         Gridclanticipos_level1Row = GXWebRow.GetNew(context);
         if ( subGridclanticipos_level1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridclanticipos_level1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridclanticipos_level1_Class, "") != 0 )
            {
               subGridclanticipos_level1_Linesclass = subGridclanticipos_level1_Class+"Odd";
            }
         }
         else if ( subGridclanticipos_level1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridclanticipos_level1_Backstyle = 0;
            subGridclanticipos_level1_Backcolor = subGridclanticipos_level1_Allbackcolor;
            if ( StringUtil.StrCmp(subGridclanticipos_level1_Class, "") != 0 )
            {
               subGridclanticipos_level1_Linesclass = subGridclanticipos_level1_Class+"Uniform";
            }
         }
         else if ( subGridclanticipos_level1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridclanticipos_level1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridclanticipos_level1_Class, "") != 0 )
            {
               subGridclanticipos_level1_Linesclass = subGridclanticipos_level1_Class+"Odd";
            }
            subGridclanticipos_level1_Backcolor = (int)(0x0);
         }
         else if ( subGridclanticipos_level1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridclanticipos_level1_Backstyle = 1;
            if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
            {
               subGridclanticipos_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridclanticipos_level1_Class, "") != 0 )
               {
                  subGridclanticipos_level1_Linesclass = subGridclanticipos_level1_Class+"Even";
               }
            }
            else
            {
               subGridclanticipos_level1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridclanticipos_level1_Class, "") != 0 )
               {
                  subGridclanticipos_level1_Linesclass = subGridclanticipos_level1_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_8_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 75,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridclanticipos_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTipCod_Internalname,StringUtil.RTrim( A149TipCod),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,75);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTipCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtTipCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)3,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_8_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridclanticipos_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtDocNum_Internalname,StringUtil.RTrim( A24DocNum),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtDocNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtDocNum_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_8_" + sGXsfl_74_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 77,'',false,'" + sGXsfl_74_idx + "',74)\"";
         ROClassString = "Attribute";
         Gridclanticipos_level1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCLAntDImporte_Internalname,StringUtil.LTrim( StringUtil.NToC( A552CLAntDImporte, 17, 2, ".", "")),StringUtil.LTrim( ((edtCLAntDImporte_Enabled!=0) ? context.localUtil.Format( A552CLAntDImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A552CLAntDImporte, "ZZZZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,77);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCLAntDImporte_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCLAntDImporte_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)17,(short)0,(short)0,(short)74,(short)1,(short)-1,(short)0,(bool)true,(string)"Importe",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridclanticipos_level1Row);
         send_integrity_lvl_hashes2D8( ) ;
         GXCCtl = "Z149TipCod_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z149TipCod));
         GXCCtl = "Z24DocNum_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z24DocNum));
         GXCCtl = "Z552CLAntDImporte_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z552CLAntDImporte, 15, 2, ".", "")));
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_8_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ".", "")));
         GXCCtl = "nIsMod_8_" + sGXsfl_74_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TIPCOD_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTipCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DOCNUM_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtDocNum_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CLANTDIMPORTE_"+sGXsfl_74_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCLAntDImporte_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridclanticipos_level1Container.AddRow(Gridclanticipos_level1Row);
      }

      protected void ReadRow2D8( )
      {
         nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_748( ) ;
         edtTipCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "TIPCOD_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtDocNum_Enabled = (int)(context.localUtil.CToN( cgiGet( "DOCNUM_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         edtCLAntDImporte_Enabled = (int)(context.localUtil.CToN( cgiGet( "CLANTDIMPORTE_"+sGXsfl_74_idx+"Enabled"), ".", ","));
         A149TipCod = cgiGet( edtTipCod_Internalname);
         A24DocNum = cgiGet( edtDocNum_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtCLAntDImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCLAntDImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
         {
            GXCCtl = "CLANTDIMPORTE_" + sGXsfl_74_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCLAntDImporte_Internalname;
            wbErr = true;
            A552CLAntDImporte = 0;
         }
         else
         {
            A552CLAntDImporte = context.localUtil.CToN( cgiGet( edtCLAntDImporte_Internalname), ".", ",");
         }
         GXCCtl = "Z149TipCod_" + sGXsfl_74_idx;
         Z149TipCod = cgiGet( GXCCtl);
         GXCCtl = "Z24DocNum_" + sGXsfl_74_idx;
         Z24DocNum = cgiGet( GXCCtl);
         GXCCtl = "Z552CLAntDImporte_" + sGXsfl_74_idx;
         Z552CLAntDImporte = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_74_idx;
         nRcdDeleted_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_8_" + sGXsfl_74_idx;
         nRcdExists_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_8_" + sGXsfl_74_idx;
         nIsMod_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtDocNum_Enabled = edtDocNum_Enabled;
         defedtTipCod_Enabled = edtTipCod_Enabled;
      }

      protected void ConfirmValues2D0( )
      {
         nGXsfl_74_idx = 0;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_748( ) ;
         while ( nGXsfl_74_idx < nRC_GXsfl_74 )
         {
            nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_748( ) ;
            ChangePostValue( "Z149TipCod_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z149TipCod_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z149TipCod_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z24DocNum_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z24DocNum_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z24DocNum_"+sGXsfl_74_idx) ;
            ChangePostValue( "Z552CLAntDImporte_"+sGXsfl_74_idx, cgiGet( "ZT_"+"Z552CLAntDImporte_"+sGXsfl_74_idx)) ;
            DeletePostValue( "ZT_"+"Z552CLAntDImporte_"+sGXsfl_74_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?202281816423960", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clanticipos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z144CLAntTipCod", StringUtil.RTrim( Z144CLAntTipCod));
         GxWebStd.gx_hidden_field( context, "Z145CLAntDocNum", StringUtil.RTrim( Z145CLAntDocNum));
         GxWebStd.gx_hidden_field( context, "Z554CLAntImporte", StringUtil.LTrim( StringUtil.NToC( Z554CLAntImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z553ClAntFecha", context.localUtil.DToC( Z553ClAntFecha, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z555CLAntImpPago", StringUtil.LTrim( StringUtil.NToC( Z555CLAntImpPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z148CLAntCliCod", StringUtil.RTrim( Z148CLAntCliCod));
         GxWebStd.gx_hidden_field( context, "Z147CLAntMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147CLAntMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z146CLAntVenCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z146CLAntVenCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_74_idx), 8, 0, ".", "")));
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
         return formatLink("clanticipos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLANTICIPOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Anticipos" ;
      }

      protected void InitializeNonKey2D82( )
      {
         A148CLAntCliCod = "";
         AssignAttri("", false, "A148CLAntCliCod", A148CLAntCliCod);
         A551CLAntCliDsc = "";
         AssignAttri("", false, "A551CLAntCliDsc", A551CLAntCliDsc);
         A147CLAntMonCod = 0;
         AssignAttri("", false, "A147CLAntMonCod", StringUtil.LTrimStr( (decimal)(A147CLAntMonCod), 6, 0));
         A554CLAntImporte = 0;
         AssignAttri("", false, "A554CLAntImporte", StringUtil.LTrimStr( A554CLAntImporte, 15, 2));
         A553ClAntFecha = DateTime.MinValue;
         AssignAttri("", false, "A553ClAntFecha", context.localUtil.Format(A553ClAntFecha, "99/99/99"));
         A555CLAntImpPago = 0;
         AssignAttri("", false, "A555CLAntImpPago", StringUtil.LTrimStr( A555CLAntImpPago, 15, 2));
         A146CLAntVenCod = 0;
         AssignAttri("", false, "A146CLAntVenCod", StringUtil.LTrimStr( (decimal)(A146CLAntVenCod), 6, 0));
         Z554CLAntImporte = 0;
         Z553ClAntFecha = DateTime.MinValue;
         Z555CLAntImpPago = 0;
         Z148CLAntCliCod = "";
         Z147CLAntMonCod = 0;
         Z146CLAntVenCod = 0;
      }

      protected void InitAll2D82( )
      {
         A144CLAntTipCod = "";
         AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
         A145CLAntDocNum = "";
         AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
         InitializeNonKey2D82( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey2D8( )
      {
         A552CLAntDImporte = 0;
         Z552CLAntDImporte = 0;
      }

      protected void InitAll2D8( )
      {
         A149TipCod = "";
         A24DocNum = "";
         InitializeNonKey2D8( ) ;
      }

      protected void StandaloneModalInsert2D8( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816423975", true, true);
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
         context.AddJavascriptSource("clanticipos.js", "?202281816423975", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties8( )
      {
         edtDocNum_Enabled = defedtDocNum_Enabled;
         AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), !bGXsfl_74_Refreshing);
         edtTipCod_Enabled = defedtTipCod_Enabled;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), !bGXsfl_74_Refreshing);
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         edtCLAntTipCod_Internalname = "CLANTTIPCOD";
         edtCLAntDocNum_Internalname = "CLANTDOCNUM";
         edtCLAntCliCod_Internalname = "CLANTCLICOD";
         edtCLAntCliDsc_Internalname = "CLANTCLIDSC";
         edtCLAntMonCod_Internalname = "CLANTMONCOD";
         edtCLAntImporte_Internalname = "CLANTIMPORTE";
         edtClAntFecha_Internalname = "CLANTFECHA";
         edtCLAntImpPago_Internalname = "CLANTIMPPAGO";
         edtCLAntVenCod_Internalname = "CLANTVENCOD";
         lblTitlelevel1_Internalname = "TITLELEVEL1";
         edtTipCod_Internalname = "TIPCOD";
         edtDocNum_Internalname = "DOCNUM";
         edtCLAntDImporte_Internalname = "CLANTDIMPORTE";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         Form.Internalname = "FORM";
         subGridclanticipos_level1_Internalname = "GRIDCLANTICIPOS_LEVEL1";
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
         Form.Caption = "Anticipos";
         edtCLAntDImporte_Jsonclick = "";
         edtDocNum_Jsonclick = "";
         edtTipCod_Jsonclick = "";
         subGridclanticipos_level1_Class = "Grid";
         subGridclanticipos_level1_Backcolorstyle = 0;
         subGridclanticipos_level1_Allowcollapsing = 0;
         subGridclanticipos_level1_Allowselection = 0;
         edtCLAntDImporte_Enabled = 1;
         edtDocNum_Enabled = 1;
         edtTipCod_Enabled = 1;
         subGridclanticipos_level1_Header = "";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCLAntVenCod_Jsonclick = "";
         edtCLAntVenCod_Enabled = 1;
         edtCLAntImpPago_Jsonclick = "";
         edtCLAntImpPago_Enabled = 1;
         edtClAntFecha_Jsonclick = "";
         edtClAntFecha_Enabled = 1;
         edtCLAntImporte_Jsonclick = "";
         edtCLAntImporte_Enabled = 1;
         edtCLAntMonCod_Jsonclick = "";
         edtCLAntMonCod_Enabled = 1;
         edtCLAntCliDsc_Jsonclick = "";
         edtCLAntCliDsc_Enabled = 0;
         edtCLAntCliCod_Jsonclick = "";
         edtCLAntCliCod_Enabled = 1;
         edtCLAntDocNum_Jsonclick = "";
         edtCLAntDocNum_Enabled = 1;
         edtCLAntTipCod_Jsonclick = "";
         edtCLAntTipCod_Enabled = 1;
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

      protected void gxnrGridclanticipos_level1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_748( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal2D8( ) ;
            standaloneModal2D8( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow2D8( ) ;
            nGXsfl_74_idx = (int)(nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_748( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridclanticipos_level1Container)) ;
         /* End function gxnrGridclanticipos_level1_newrow */
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
         GX_FocusControl = edtCLAntCliCod_Internalname;
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

      public void Valid_Clantdocnum( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A148CLAntCliCod", StringUtil.RTrim( A148CLAntCliCod));
         AssignAttri("", false, "A147CLAntMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A147CLAntMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A554CLAntImporte", StringUtil.LTrim( StringUtil.NToC( A554CLAntImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A553ClAntFecha", context.localUtil.Format(A553ClAntFecha, "99/99/99"));
         AssignAttri("", false, "A555CLAntImpPago", StringUtil.LTrim( StringUtil.NToC( A555CLAntImpPago, 15, 2, ".", "")));
         AssignAttri("", false, "A146CLAntVenCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A146CLAntVenCod), 6, 0, ".", "")));
         AssignAttri("", false, "A551CLAntCliDsc", StringUtil.RTrim( A551CLAntCliDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z144CLAntTipCod", StringUtil.RTrim( Z144CLAntTipCod));
         GxWebStd.gx_hidden_field( context, "Z145CLAntDocNum", StringUtil.RTrim( Z145CLAntDocNum));
         GxWebStd.gx_hidden_field( context, "Z148CLAntCliCod", StringUtil.RTrim( Z148CLAntCliCod));
         GxWebStd.gx_hidden_field( context, "Z147CLAntMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z147CLAntMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z554CLAntImporte", StringUtil.LTrim( StringUtil.NToC( Z554CLAntImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z553ClAntFecha", context.localUtil.Format(Z553ClAntFecha, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z555CLAntImpPago", StringUtil.LTrim( StringUtil.NToC( Z555CLAntImpPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z146CLAntVenCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z146CLAntVenCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z551CLAntCliDsc", StringUtil.RTrim( Z551CLAntCliDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clantclicod( )
      {
         /* Using cursor T002D20 */
         pr_default.execute(18, new Object[] {A148CLAntCliCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "CLANTCLICOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntCliCod_Internalname;
         }
         A551CLAntCliDsc = T002D20_A551CLAntCliDsc[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A551CLAntCliDsc", StringUtil.RTrim( A551CLAntCliDsc));
      }

      public void Valid_Clantmoncod( )
      {
         /* Using cursor T002D29 */
         pr_default.execute(27, new Object[] {A147CLAntMonCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "CLANTMONCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntMonCod_Internalname;
         }
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clantvencod( )
      {
         /* Using cursor T002D30 */
         pr_default.execute(28, new Object[] {A146CLAntVenCod});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Anticipo Vendedor'.", "ForeignKeyNotFound", 1, "CLANTVENCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntVenCod_Internalname;
         }
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Docnum( )
      {
         /* Using cursor T002D31 */
         pr_default.execute(29, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(29);
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
         setEventMetadata("VALID_CLANTTIPCOD","{handler:'Valid_Clanttipcod',iparms:[]");
         setEventMetadata("VALID_CLANTTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_CLANTDOCNUM","{handler:'Valid_Clantdocnum',iparms:[{av:'A144CLAntTipCod',fld:'CLANTTIPCOD',pic:''},{av:'A145CLAntDocNum',fld:'CLANTDOCNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLANTDOCNUM",",oparms:[{av:'A148CLAntCliCod',fld:'CLANTCLICOD',pic:''},{av:'A147CLAntMonCod',fld:'CLANTMONCOD',pic:'ZZZZZ9'},{av:'A554CLAntImporte',fld:'CLANTIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A553ClAntFecha',fld:'CLANTFECHA',pic:''},{av:'A555CLAntImpPago',fld:'CLANTIMPPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A146CLAntVenCod',fld:'CLANTVENCOD',pic:'ZZZZZ9'},{av:'A551CLAntCliDsc',fld:'CLANTCLIDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z144CLAntTipCod'},{av:'Z145CLAntDocNum'},{av:'Z148CLAntCliCod'},{av:'Z147CLAntMonCod'},{av:'Z554CLAntImporte'},{av:'Z553ClAntFecha'},{av:'Z555CLAntImpPago'},{av:'Z146CLAntVenCod'},{av:'Z551CLAntCliDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLANTCLICOD","{handler:'Valid_Clantclicod',iparms:[{av:'A148CLAntCliCod',fld:'CLANTCLICOD',pic:''},{av:'A551CLAntCliDsc',fld:'CLANTCLIDSC',pic:''}]");
         setEventMetadata("VALID_CLANTCLICOD",",oparms:[{av:'A551CLAntCliDsc',fld:'CLANTCLIDSC',pic:''}]}");
         setEventMetadata("VALID_CLANTMONCOD","{handler:'Valid_Clantmoncod',iparms:[{av:'A147CLAntMonCod',fld:'CLANTMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CLANTMONCOD",",oparms:[]}");
         setEventMetadata("VALID_CLANTFECHA","{handler:'Valid_Clantfecha',iparms:[]");
         setEventMetadata("VALID_CLANTFECHA",",oparms:[]}");
         setEventMetadata("VALID_CLANTVENCOD","{handler:'Valid_Clantvencod',iparms:[{av:'A146CLAntVenCod',fld:'CLANTVENCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CLANTVENCOD",",oparms:[]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_DOCNUM","{handler:'Valid_Docnum',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''}]");
         setEventMetadata("VALID_DOCNUM",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Clantdimporte',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(29);
         pr_default.close(4);
         pr_default.close(18);
         pr_default.close(27);
         pr_default.close(28);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z144CLAntTipCod = "";
         Z145CLAntDocNum = "";
         Z553ClAntFecha = DateTime.MinValue;
         Z148CLAntCliCod = "";
         Z149TipCod = "";
         Z24DocNum = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A148CLAntCliCod = "";
         A149TipCod = "";
         A24DocNum = "";
         Gx_mode = "";
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
         A144CLAntTipCod = "";
         A145CLAntDocNum = "";
         A551CLAntCliDsc = "";
         A553ClAntFecha = DateTime.MinValue;
         lblTitlelevel1_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridclanticipos_level1Container = new GXWebGrid( context);
         Gridclanticipos_level1Column = new GXWebColumn();
         sMode8 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         Z551CLAntCliDsc = "";
         T002D10_A144CLAntTipCod = new string[] {""} ;
         T002D10_A145CLAntDocNum = new string[] {""} ;
         T002D10_A551CLAntCliDsc = new string[] {""} ;
         T002D10_A554CLAntImporte = new decimal[1] ;
         T002D10_A553ClAntFecha = new DateTime[] {DateTime.MinValue} ;
         T002D10_A555CLAntImpPago = new decimal[1] ;
         T002D10_A148CLAntCliCod = new string[] {""} ;
         T002D10_A147CLAntMonCod = new int[1] ;
         T002D10_A146CLAntVenCod = new int[1] ;
         T002D7_A551CLAntCliDsc = new string[] {""} ;
         T002D8_A147CLAntMonCod = new int[1] ;
         T002D9_A146CLAntVenCod = new int[1] ;
         T002D11_A551CLAntCliDsc = new string[] {""} ;
         T002D12_A147CLAntMonCod = new int[1] ;
         T002D13_A146CLAntVenCod = new int[1] ;
         T002D14_A144CLAntTipCod = new string[] {""} ;
         T002D14_A145CLAntDocNum = new string[] {""} ;
         T002D6_A144CLAntTipCod = new string[] {""} ;
         T002D6_A145CLAntDocNum = new string[] {""} ;
         T002D6_A554CLAntImporte = new decimal[1] ;
         T002D6_A553ClAntFecha = new DateTime[] {DateTime.MinValue} ;
         T002D6_A555CLAntImpPago = new decimal[1] ;
         T002D6_A148CLAntCliCod = new string[] {""} ;
         T002D6_A147CLAntMonCod = new int[1] ;
         T002D6_A146CLAntVenCod = new int[1] ;
         sMode82 = "";
         T002D15_A144CLAntTipCod = new string[] {""} ;
         T002D15_A145CLAntDocNum = new string[] {""} ;
         T002D16_A144CLAntTipCod = new string[] {""} ;
         T002D16_A145CLAntDocNum = new string[] {""} ;
         T002D5_A144CLAntTipCod = new string[] {""} ;
         T002D5_A145CLAntDocNum = new string[] {""} ;
         T002D5_A554CLAntImporte = new decimal[1] ;
         T002D5_A553ClAntFecha = new DateTime[] {DateTime.MinValue} ;
         T002D5_A555CLAntImpPago = new decimal[1] ;
         T002D5_A148CLAntCliCod = new string[] {""} ;
         T002D5_A147CLAntMonCod = new int[1] ;
         T002D5_A146CLAntVenCod = new int[1] ;
         T002D20_A551CLAntCliDsc = new string[] {""} ;
         T002D21_A144CLAntTipCod = new string[] {""} ;
         T002D21_A145CLAntDocNum = new string[] {""} ;
         T002D22_A144CLAntTipCod = new string[] {""} ;
         T002D22_A145CLAntDocNum = new string[] {""} ;
         T002D22_A552CLAntDImporte = new decimal[1] ;
         T002D22_A149TipCod = new string[] {""} ;
         T002D22_A24DocNum = new string[] {""} ;
         T002D4_A149TipCod = new string[] {""} ;
         T002D23_A149TipCod = new string[] {""} ;
         T002D24_A144CLAntTipCod = new string[] {""} ;
         T002D24_A145CLAntDocNum = new string[] {""} ;
         T002D24_A149TipCod = new string[] {""} ;
         T002D24_A24DocNum = new string[] {""} ;
         T002D3_A144CLAntTipCod = new string[] {""} ;
         T002D3_A145CLAntDocNum = new string[] {""} ;
         T002D3_A552CLAntDImporte = new decimal[1] ;
         T002D3_A149TipCod = new string[] {""} ;
         T002D3_A24DocNum = new string[] {""} ;
         T002D2_A144CLAntTipCod = new string[] {""} ;
         T002D2_A145CLAntDocNum = new string[] {""} ;
         T002D2_A552CLAntDImporte = new decimal[1] ;
         T002D2_A149TipCod = new string[] {""} ;
         T002D2_A24DocNum = new string[] {""} ;
         T002D28_A144CLAntTipCod = new string[] {""} ;
         T002D28_A145CLAntDocNum = new string[] {""} ;
         T002D28_A149TipCod = new string[] {""} ;
         T002D28_A24DocNum = new string[] {""} ;
         Gridclanticipos_level1Row = new GXWebRow();
         subGridclanticipos_level1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ144CLAntTipCod = "";
         ZZ145CLAntDocNum = "";
         ZZ148CLAntCliCod = "";
         ZZ553ClAntFecha = DateTime.MinValue;
         ZZ551CLAntCliDsc = "";
         T002D29_A147CLAntMonCod = new int[1] ;
         T002D30_A146CLAntVenCod = new int[1] ;
         T002D31_A149TipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clanticipos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clanticipos__default(),
            new Object[][] {
                new Object[] {
               T002D2_A144CLAntTipCod, T002D2_A145CLAntDocNum, T002D2_A552CLAntDImporte, T002D2_A149TipCod, T002D2_A24DocNum
               }
               , new Object[] {
               T002D3_A144CLAntTipCod, T002D3_A145CLAntDocNum, T002D3_A552CLAntDImporte, T002D3_A149TipCod, T002D3_A24DocNum
               }
               , new Object[] {
               T002D4_A149TipCod
               }
               , new Object[] {
               T002D5_A144CLAntTipCod, T002D5_A145CLAntDocNum, T002D5_A554CLAntImporte, T002D5_A553ClAntFecha, T002D5_A555CLAntImpPago, T002D5_A148CLAntCliCod, T002D5_A147CLAntMonCod, T002D5_A146CLAntVenCod
               }
               , new Object[] {
               T002D6_A144CLAntTipCod, T002D6_A145CLAntDocNum, T002D6_A554CLAntImporte, T002D6_A553ClAntFecha, T002D6_A555CLAntImpPago, T002D6_A148CLAntCliCod, T002D6_A147CLAntMonCod, T002D6_A146CLAntVenCod
               }
               , new Object[] {
               T002D7_A551CLAntCliDsc
               }
               , new Object[] {
               T002D8_A147CLAntMonCod
               }
               , new Object[] {
               T002D9_A146CLAntVenCod
               }
               , new Object[] {
               T002D10_A144CLAntTipCod, T002D10_A145CLAntDocNum, T002D10_A551CLAntCliDsc, T002D10_A554CLAntImporte, T002D10_A553ClAntFecha, T002D10_A555CLAntImpPago, T002D10_A148CLAntCliCod, T002D10_A147CLAntMonCod, T002D10_A146CLAntVenCod
               }
               , new Object[] {
               T002D11_A551CLAntCliDsc
               }
               , new Object[] {
               T002D12_A147CLAntMonCod
               }
               , new Object[] {
               T002D13_A146CLAntVenCod
               }
               , new Object[] {
               T002D14_A144CLAntTipCod, T002D14_A145CLAntDocNum
               }
               , new Object[] {
               T002D15_A144CLAntTipCod, T002D15_A145CLAntDocNum
               }
               , new Object[] {
               T002D16_A144CLAntTipCod, T002D16_A145CLAntDocNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002D20_A551CLAntCliDsc
               }
               , new Object[] {
               T002D21_A144CLAntTipCod, T002D21_A145CLAntDocNum
               }
               , new Object[] {
               T002D22_A144CLAntTipCod, T002D22_A145CLAntDocNum, T002D22_A552CLAntDImporte, T002D22_A149TipCod, T002D22_A24DocNum
               }
               , new Object[] {
               T002D23_A149TipCod
               }
               , new Object[] {
               T002D24_A144CLAntTipCod, T002D24_A145CLAntDocNum, T002D24_A149TipCod, T002D24_A24DocNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002D28_A144CLAntTipCod, T002D28_A145CLAntDocNum, T002D28_A149TipCod, T002D28_A24DocNum
               }
               , new Object[] {
               T002D29_A147CLAntMonCod
               }
               , new Object[] {
               T002D30_A146CLAntVenCod
               }
               , new Object[] {
               T002D31_A149TipCod
               }
            }
         );
      }

      private short nRcdDeleted_8 ;
      private short nRcdExists_8 ;
      private short nIsMod_8 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGridclanticipos_level1_Backcolorstyle ;
      private short subGridclanticipos_level1_Allowselection ;
      private short subGridclanticipos_level1_Allowhovering ;
      private short subGridclanticipos_level1_Allowcollapsing ;
      private short subGridclanticipos_level1_Collapsed ;
      private short nBlankRcdCount8 ;
      private short RcdFound8 ;
      private short nBlankRcdUsr8 ;
      private short GX_JID ;
      private short RcdFound82 ;
      private short nIsDirty_82 ;
      private short Gx_BScreen ;
      private short nIsDirty_8 ;
      private short subGridclanticipos_level1_Backstyle ;
      private short gxajaxcallmode ;
      private int Z147CLAntMonCod ;
      private int Z146CLAntVenCod ;
      private int nRC_GXsfl_74 ;
      private int nGXsfl_74_idx=1 ;
      private int A147CLAntMonCod ;
      private int A146CLAntVenCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCLAntTipCod_Enabled ;
      private int edtCLAntDocNum_Enabled ;
      private int edtCLAntCliCod_Enabled ;
      private int edtCLAntCliDsc_Enabled ;
      private int edtCLAntMonCod_Enabled ;
      private int edtCLAntImporte_Enabled ;
      private int edtClAntFecha_Enabled ;
      private int edtCLAntImpPago_Enabled ;
      private int edtCLAntVenCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtTipCod_Enabled ;
      private int edtDocNum_Enabled ;
      private int edtCLAntDImporte_Enabled ;
      private int subGridclanticipos_level1_Selectedindex ;
      private int subGridclanticipos_level1_Selectioncolor ;
      private int subGridclanticipos_level1_Hoveringcolor ;
      private int fRowAdded ;
      private int subGridclanticipos_level1_Backcolor ;
      private int subGridclanticipos_level1_Allbackcolor ;
      private int defedtDocNum_Enabled ;
      private int defedtTipCod_Enabled ;
      private int idxLst ;
      private int ZZ147CLAntMonCod ;
      private int ZZ146CLAntVenCod ;
      private long GRIDCLANTICIPOS_LEVEL1_nFirstRecordOnPage ;
      private decimal Z554CLAntImporte ;
      private decimal Z555CLAntImpPago ;
      private decimal Z552CLAntDImporte ;
      private decimal A554CLAntImporte ;
      private decimal A555CLAntImpPago ;
      private decimal A552CLAntDImporte ;
      private decimal ZZ554CLAntImporte ;
      private decimal ZZ555CLAntImpPago ;
      private string sPrefix ;
      private string Z144CLAntTipCod ;
      private string Z145CLAntDocNum ;
      private string Z148CLAntCliCod ;
      private string Z149TipCod ;
      private string Z24DocNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A148CLAntCliCod ;
      private string A149TipCod ;
      private string A24DocNum ;
      private string sGXsfl_74_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCLAntTipCod_Internalname ;
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
      private string A144CLAntTipCod ;
      private string edtCLAntTipCod_Jsonclick ;
      private string edtCLAntDocNum_Internalname ;
      private string A145CLAntDocNum ;
      private string edtCLAntDocNum_Jsonclick ;
      private string edtCLAntCliCod_Internalname ;
      private string edtCLAntCliCod_Jsonclick ;
      private string edtCLAntCliDsc_Internalname ;
      private string A551CLAntCliDsc ;
      private string edtCLAntCliDsc_Jsonclick ;
      private string edtCLAntMonCod_Internalname ;
      private string edtCLAntMonCod_Jsonclick ;
      private string edtCLAntImporte_Internalname ;
      private string edtCLAntImporte_Jsonclick ;
      private string edtClAntFecha_Internalname ;
      private string edtClAntFecha_Jsonclick ;
      private string edtCLAntImpPago_Internalname ;
      private string edtCLAntImpPago_Jsonclick ;
      private string edtCLAntVenCod_Internalname ;
      private string edtCLAntVenCod_Jsonclick ;
      private string lblTitlelevel1_Internalname ;
      private string lblTitlelevel1_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string subGridclanticipos_level1_Header ;
      private string sMode8 ;
      private string edtTipCod_Internalname ;
      private string edtDocNum_Internalname ;
      private string edtCLAntDImporte_Internalname ;
      private string sStyleString ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string Z551CLAntCliDsc ;
      private string sMode82 ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGridclanticipos_level1_Class ;
      private string subGridclanticipos_level1_Linesclass ;
      private string ROClassString ;
      private string edtTipCod_Jsonclick ;
      private string edtDocNum_Jsonclick ;
      private string edtCLAntDImporte_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridclanticipos_level1_Internalname ;
      private string ZZ144CLAntTipCod ;
      private string ZZ145CLAntDocNum ;
      private string ZZ148CLAntCliCod ;
      private string ZZ551CLAntCliDsc ;
      private DateTime Z553ClAntFecha ;
      private DateTime A553ClAntFecha ;
      private DateTime ZZ553ClAntFecha ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool Gx_longc ;
      private GXWebGrid Gridclanticipos_level1Container ;
      private GXWebRow Gridclanticipos_level1Row ;
      private GXWebColumn Gridclanticipos_level1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T002D10_A144CLAntTipCod ;
      private string[] T002D10_A145CLAntDocNum ;
      private string[] T002D10_A551CLAntCliDsc ;
      private decimal[] T002D10_A554CLAntImporte ;
      private DateTime[] T002D10_A553ClAntFecha ;
      private decimal[] T002D10_A555CLAntImpPago ;
      private string[] T002D10_A148CLAntCliCod ;
      private int[] T002D10_A147CLAntMonCod ;
      private int[] T002D10_A146CLAntVenCod ;
      private string[] T002D7_A551CLAntCliDsc ;
      private int[] T002D8_A147CLAntMonCod ;
      private int[] T002D9_A146CLAntVenCod ;
      private string[] T002D11_A551CLAntCliDsc ;
      private int[] T002D12_A147CLAntMonCod ;
      private int[] T002D13_A146CLAntVenCod ;
      private string[] T002D14_A144CLAntTipCod ;
      private string[] T002D14_A145CLAntDocNum ;
      private string[] T002D6_A144CLAntTipCod ;
      private string[] T002D6_A145CLAntDocNum ;
      private decimal[] T002D6_A554CLAntImporte ;
      private DateTime[] T002D6_A553ClAntFecha ;
      private decimal[] T002D6_A555CLAntImpPago ;
      private string[] T002D6_A148CLAntCliCod ;
      private int[] T002D6_A147CLAntMonCod ;
      private int[] T002D6_A146CLAntVenCod ;
      private string[] T002D15_A144CLAntTipCod ;
      private string[] T002D15_A145CLAntDocNum ;
      private string[] T002D16_A144CLAntTipCod ;
      private string[] T002D16_A145CLAntDocNum ;
      private string[] T002D5_A144CLAntTipCod ;
      private string[] T002D5_A145CLAntDocNum ;
      private decimal[] T002D5_A554CLAntImporte ;
      private DateTime[] T002D5_A553ClAntFecha ;
      private decimal[] T002D5_A555CLAntImpPago ;
      private string[] T002D5_A148CLAntCliCod ;
      private int[] T002D5_A147CLAntMonCod ;
      private int[] T002D5_A146CLAntVenCod ;
      private string[] T002D20_A551CLAntCliDsc ;
      private string[] T002D21_A144CLAntTipCod ;
      private string[] T002D21_A145CLAntDocNum ;
      private string[] T002D22_A144CLAntTipCod ;
      private string[] T002D22_A145CLAntDocNum ;
      private decimal[] T002D22_A552CLAntDImporte ;
      private string[] T002D22_A149TipCod ;
      private string[] T002D22_A24DocNum ;
      private string[] T002D4_A149TipCod ;
      private string[] T002D23_A149TipCod ;
      private string[] T002D24_A144CLAntTipCod ;
      private string[] T002D24_A145CLAntDocNum ;
      private string[] T002D24_A149TipCod ;
      private string[] T002D24_A24DocNum ;
      private string[] T002D3_A144CLAntTipCod ;
      private string[] T002D3_A145CLAntDocNum ;
      private decimal[] T002D3_A552CLAntDImporte ;
      private string[] T002D3_A149TipCod ;
      private string[] T002D3_A24DocNum ;
      private string[] T002D2_A144CLAntTipCod ;
      private string[] T002D2_A145CLAntDocNum ;
      private decimal[] T002D2_A552CLAntDImporte ;
      private string[] T002D2_A149TipCod ;
      private string[] T002D2_A24DocNum ;
      private string[] T002D28_A144CLAntTipCod ;
      private string[] T002D28_A145CLAntDocNum ;
      private string[] T002D28_A149TipCod ;
      private string[] T002D28_A24DocNum ;
      private int[] T002D29_A147CLAntMonCod ;
      private int[] T002D30_A146CLAntVenCod ;
      private string[] T002D31_A149TipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clanticipos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clanticipos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new UpdateCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002D10;
        prmT002D10 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D7;
        prmT002D7 = new Object[] {
        new ParDef("@CLAntCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002D8;
        prmT002D8 = new Object[] {
        new ParDef("@CLAntMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002D9;
        prmT002D9 = new Object[] {
        new ParDef("@CLAntVenCod",GXType.Int32,6,0)
        };
        Object[] prmT002D11;
        prmT002D11 = new Object[] {
        new ParDef("@CLAntCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002D12;
        prmT002D12 = new Object[] {
        new ParDef("@CLAntMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002D13;
        prmT002D13 = new Object[] {
        new ParDef("@CLAntVenCod",GXType.Int32,6,0)
        };
        Object[] prmT002D14;
        prmT002D14 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D6;
        prmT002D6 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D15;
        prmT002D15 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D16;
        prmT002D16 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D5;
        prmT002D5 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D17;
        prmT002D17 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@CLAntImporte",GXType.Decimal,15,2) ,
        new ParDef("@ClAntFecha",GXType.Date,8,0) ,
        new ParDef("@CLAntImpPago",GXType.Decimal,15,2) ,
        new ParDef("@CLAntCliCod",GXType.NChar,20,0) ,
        new ParDef("@CLAntMonCod",GXType.Int32,6,0) ,
        new ParDef("@CLAntVenCod",GXType.Int32,6,0)
        };
        Object[] prmT002D18;
        prmT002D18 = new Object[] {
        new ParDef("@CLAntImporte",GXType.Decimal,15,2) ,
        new ParDef("@ClAntFecha",GXType.Date,8,0) ,
        new ParDef("@CLAntImpPago",GXType.Decimal,15,2) ,
        new ParDef("@CLAntCliCod",GXType.NChar,20,0) ,
        new ParDef("@CLAntMonCod",GXType.Int32,6,0) ,
        new ParDef("@CLAntVenCod",GXType.Int32,6,0) ,
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D19;
        prmT002D19 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D21;
        prmT002D21 = new Object[] {
        };
        Object[] prmT002D22;
        prmT002D22 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D4;
        prmT002D4 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D23;
        prmT002D23 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D24;
        prmT002D24 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D3;
        prmT002D3 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D2;
        prmT002D2 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D25;
        prmT002D25 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@CLAntDImporte",GXType.Decimal,15,2) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D26;
        prmT002D26 = new Object[] {
        new ParDef("@CLAntDImporte",GXType.Decimal,15,2) ,
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D27;
        prmT002D27 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D28;
        prmT002D28 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT002D20;
        prmT002D20 = new Object[] {
        new ParDef("@CLAntCliCod",GXType.NChar,20,0)
        };
        Object[] prmT002D29;
        prmT002D29 = new Object[] {
        new ParDef("@CLAntMonCod",GXType.Int32,6,0)
        };
        Object[] prmT002D30;
        prmT002D30 = new Object[] {
        new ParDef("@CLAntVenCod",GXType.Int32,6,0)
        };
        Object[] prmT002D31;
        prmT002D31 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002D2", "SELECT [CLAntTipCod], [CLAntDocNum], [CLAntDImporte], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WITH (UPDLOCK) WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D3", "SELECT [CLAntTipCod], [CLAntDocNum], [CLAntDImporte], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D4", "SELECT [TipCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D5", "SELECT [CLAntTipCod], [CLAntDocNum], [CLAntImporte], [ClAntFecha], [CLAntImpPago], [CLAntCliCod] AS CLAntCliCod, [CLAntMonCod] AS CLAntMonCod, [CLAntVenCod] AS CLAntVenCod FROM [CLANTICIPOS] WITH (UPDLOCK) WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D6", "SELECT [CLAntTipCod], [CLAntDocNum], [CLAntImporte], [ClAntFecha], [CLAntImpPago], [CLAntCliCod] AS CLAntCliCod, [CLAntMonCod] AS CLAntMonCod, [CLAntVenCod] AS CLAntVenCod FROM [CLANTICIPOS] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D7", "SELECT [CliDsc] AS CLAntCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @CLAntCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D8", "SELECT [MonCod] AS CLAntMonCod FROM [CMONEDAS] WHERE [MonCod] = @CLAntMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D9", "SELECT [VenCod] AS CLAntVenCod FROM [CVENDEDORES] WHERE [VenCod] = @CLAntVenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D10", "SELECT TM1.[CLAntTipCod], TM1.[CLAntDocNum], T2.[CliDsc] AS CLAntCliDsc, TM1.[CLAntImporte], TM1.[ClAntFecha], TM1.[CLAntImpPago], TM1.[CLAntCliCod] AS CLAntCliCod, TM1.[CLAntMonCod] AS CLAntMonCod, TM1.[CLAntVenCod] AS CLAntVenCod FROM ([CLANTICIPOS] TM1 INNER JOIN [CLCLIENTES] T2 ON T2.[CliCod] = TM1.[CLAntCliCod]) WHERE TM1.[CLAntTipCod] = @CLAntTipCod and TM1.[CLAntDocNum] = @CLAntDocNum ORDER BY TM1.[CLAntTipCod], TM1.[CLAntDocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002D10,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D11", "SELECT [CliDsc] AS CLAntCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @CLAntCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D12", "SELECT [MonCod] AS CLAntMonCod FROM [CMONEDAS] WHERE [MonCod] = @CLAntMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D13", "SELECT [VenCod] AS CLAntVenCod FROM [CVENDEDORES] WHERE [VenCod] = @CLAntVenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D14", "SELECT [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002D14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D15", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE ( [CLAntTipCod] > @CLAntTipCod or [CLAntTipCod] = @CLAntTipCod and [CLAntDocNum] > @CLAntDocNum) ORDER BY [CLAntTipCod], [CLAntDocNum]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002D15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002D16", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE ( [CLAntTipCod] < @CLAntTipCod or [CLAntTipCod] = @CLAntTipCod and [CLAntDocNum] < @CLAntDocNum) ORDER BY [CLAntTipCod] DESC, [CLAntDocNum] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002D16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002D17", "INSERT INTO [CLANTICIPOS]([CLAntTipCod], [CLAntDocNum], [CLAntImporte], [ClAntFecha], [CLAntImpPago], [CLAntCliCod], [CLAntMonCod], [CLAntVenCod]) VALUES(@CLAntTipCod, @CLAntDocNum, @CLAntImporte, @ClAntFecha, @CLAntImpPago, @CLAntCliCod, @CLAntMonCod, @CLAntVenCod)", GxErrorMask.GX_NOMASK,prmT002D17)
           ,new CursorDef("T002D18", "UPDATE [CLANTICIPOS] SET [CLAntImporte]=@CLAntImporte, [ClAntFecha]=@ClAntFecha, [CLAntImpPago]=@CLAntImpPago, [CLAntCliCod]=@CLAntCliCod, [CLAntMonCod]=@CLAntMonCod, [CLAntVenCod]=@CLAntVenCod  WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum", GxErrorMask.GX_NOMASK,prmT002D18)
           ,new CursorDef("T002D19", "DELETE FROM [CLANTICIPOS]  WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum", GxErrorMask.GX_NOMASK,prmT002D19)
           ,new CursorDef("T002D20", "SELECT [CliDsc] AS CLAntCliDsc FROM [CLCLIENTES] WHERE [CliCod] = @CLAntCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D21", "SELECT [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] ORDER BY [CLAntTipCod], [CLAntDocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002D21,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D22", "SELECT [CLAntTipCod], [CLAntDocNum], [CLAntDImporte], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE [CLAntTipCod] = @CLAntTipCod and [CLAntDocNum] = @CLAntDocNum and [TipCod] = @TipCod and [DocNum] = @DocNum ORDER BY [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D22,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D23", "SELECT [TipCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D24", "SELECT [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D25", "INSERT INTO [CLANTICIPOSDET]([CLAntTipCod], [CLAntDocNum], [CLAntDImporte], [TipCod], [DocNum]) VALUES(@CLAntTipCod, @CLAntDocNum, @CLAntDImporte, @TipCod, @DocNum)", GxErrorMask.GX_NOMASK,prmT002D25)
           ,new CursorDef("T002D26", "UPDATE [CLANTICIPOSDET] SET [CLAntDImporte]=@CLAntDImporte  WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK,prmT002D26)
           ,new CursorDef("T002D27", "DELETE FROM [CLANTICIPOSDET]  WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK,prmT002D27)
           ,new CursorDef("T002D28", "SELECT [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE [CLAntTipCod] = @CLAntTipCod and [CLAntDocNum] = @CLAntDocNum ORDER BY [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D28,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D29", "SELECT [MonCod] AS CLAntMonCod FROM [CMONEDAS] WHERE [MonCod] = @CLAntMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D30", "SELECT [VenCod] AS CLAntVenCod FROM [CVENDEDORES] WHERE [VenCod] = @CLAntVenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002D31", "SELECT [TipCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT002D31,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 20);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 12);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 12);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
