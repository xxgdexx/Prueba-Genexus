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
   public class clanticiposdet : GXDataArea
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
            A144CLAntTipCod = GetPar( "CLAntTipCod");
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = GetPar( "CLAntDocNum");
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A144CLAntTipCod, A145CLAntDocNum) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = GetPar( "DocNum");
            AssignAttri("", false, "A24DocNum", A24DocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A149TipCod, A24DocNum) ;
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
            Form.Meta.addItem("description", "Anticipos Clientes Detalle", 0) ;
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

      public clanticiposdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clanticiposdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Anticipos Clientes Detalle", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CLANTICIPOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLANTICIPOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCLAntTipCod_Internalname, StringUtil.RTrim( A144CLAntTipCod), StringUtil.RTrim( context.localUtil.Format( A144CLAntTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOSDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCLAntDocNum_Internalname, StringUtil.RTrim( A145CLAntDocNum), StringUtil.RTrim( context.localUtil.Format( A145CLAntDocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipCod_Internalname, "Codigo T. Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtDocNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocNum_Internalname, "Numero Doc.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocNum_Internalname, StringUtil.RTrim( A24DocNum), StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCLAntDImporte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCLAntDImporte_Internalname, "Aplicado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCLAntDImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A552CLAntDImporte, 17, 2, ".", "")), StringUtil.LTrim( ((edtCLAntDImporte_Enabled!=0) ? context.localUtil.Format( A552CLAntDImporte, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A552CLAntDImporte, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCLAntDImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCLAntDImporte_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CLANTICIPOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLANTICIPOSDET.htm");
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
            Z144CLAntTipCod = cgiGet( "Z144CLAntTipCod");
            Z145CLAntDocNum = cgiGet( "Z145CLAntDocNum");
            Z149TipCod = cgiGet( "Z149TipCod");
            Z24DocNum = cgiGet( "Z24DocNum");
            Z552CLAntDImporte = context.localUtil.CToN( cgiGet( "Z552CLAntDImporte"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A144CLAntTipCod = cgiGet( edtCLAntTipCod_Internalname);
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = cgiGet( edtCLAntDocNum_Internalname);
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = cgiGet( edtDocNum_Internalname);
            AssignAttri("", false, "A24DocNum", A24DocNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCLAntDImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtCLAntDImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLANTDIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtCLAntDImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A552CLAntDImporte = 0;
               AssignAttri("", false, "A552CLAntDImporte", StringUtil.LTrimStr( A552CLAntDImporte, 15, 2));
            }
            else
            {
               A552CLAntDImporte = context.localUtil.CToN( cgiGet( edtCLAntDImporte_Internalname), ".", ",");
               AssignAttri("", false, "A552CLAntDImporte", StringUtil.LTrimStr( A552CLAntDImporte, 15, 2));
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
               A144CLAntTipCod = GetPar( "CLAntTipCod");
               AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
               A145CLAntDocNum = GetPar( "CLAntDocNum");
               AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
               A149TipCod = GetPar( "TipCod");
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = GetPar( "DocNum");
               AssignAttri("", false, "A24DocNum", A24DocNum);
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
               InitAll088( ) ;
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
         DisableAttributes088( ) ;
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

      protected void ResetCaption080( )
      {
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z552CLAntDImporte = T00083_A552CLAntDImporte[0];
            }
            else
            {
               Z552CLAntDImporte = A552CLAntDImporte;
            }
         }
         if ( GX_JID == -1 )
         {
            Z552CLAntDImporte = A552CLAntDImporte;
            Z144CLAntTipCod = A144CLAntTipCod;
            Z145CLAntDocNum = A145CLAntDocNum;
            Z149TipCod = A149TipCod;
            Z24DocNum = A24DocNum;
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

      protected void Load088( )
      {
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound8 = 1;
            A552CLAntDImporte = T00086_A552CLAntDImporte[0];
            AssignAttri("", false, "A552CLAntDImporte", StringUtil.LTrimStr( A552CLAntDImporte, 15, 2));
            ZM088( -1) ;
         }
         pr_default.close(4);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Anticipos'.", "ForeignKeyNotFound", 1, "CLANTDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A144CLAntTipCod ,
                               string A145CLAntDocNum )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Anticipos'.", "ForeignKeyNotFound", 1, "CLANTDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCLAntTipCod_Internalname;
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

      protected void gxLoad_3( string A149TipCod ,
                               string A24DocNum )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
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

      protected void GetKey088( )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 1) ;
            RcdFound8 = 1;
            A552CLAntDImporte = T00083_A552CLAntDImporte[0];
            AssignAttri("", false, "A552CLAntDImporte", StringUtil.LTrimStr( A552CLAntDImporte, 15, 2));
            A144CLAntTipCod = T00083_A144CLAntTipCod[0];
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = T00083_A145CLAntDocNum[0];
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            A149TipCod = T00083_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T00083_A24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
            Z144CLAntTipCod = A144CLAntTipCod;
            Z145CLAntDocNum = A145CLAntDocNum;
            Z149TipCod = A149TipCod;
            Z24DocNum = A24DocNum;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) < 0 ) || ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A145CLAntDocNum[0], A145CLAntDocNum) < 0 ) || ( StringUtil.StrCmp(T000810_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T000810_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A24DocNum[0], A24DocNum) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) > 0 ) || ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A145CLAntDocNum[0], A145CLAntDocNum) > 0 ) || ( StringUtil.StrCmp(T000810_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T000810_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000810_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000810_A24DocNum[0], A24DocNum) > 0 ) ) )
            {
               A144CLAntTipCod = T000810_A144CLAntTipCod[0];
               AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
               A145CLAntDocNum = T000810_A145CLAntDocNum[0];
               AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
               A149TipCod = T000810_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = T000810_A24DocNum[0];
               AssignAttri("", false, "A24DocNum", A24DocNum);
               RcdFound8 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) > 0 ) || ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A145CLAntDocNum[0], A145CLAntDocNum) > 0 ) || ( StringUtil.StrCmp(T000811_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T000811_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A24DocNum[0], A24DocNum) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) < 0 ) || ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A145CLAntDocNum[0], A145CLAntDocNum) < 0 ) || ( StringUtil.StrCmp(T000811_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T000811_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A145CLAntDocNum[0], A145CLAntDocNum) == 0 ) && ( StringUtil.StrCmp(T000811_A144CLAntTipCod[0], A144CLAntTipCod) == 0 ) && ( StringUtil.StrCmp(T000811_A24DocNum[0], A24DocNum) < 0 ) ) )
            {
               A144CLAntTipCod = T000811_A144CLAntTipCod[0];
               AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
               A145CLAntDocNum = T000811_A145CLAntDocNum[0];
               AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
               A149TipCod = T000811_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A24DocNum = T000811_A24DocNum[0];
               AssignAttri("", false, "A24DocNum", A24DocNum);
               RcdFound8 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( ( StringUtil.StrCmp(A144CLAntTipCod, Z144CLAntTipCod) != 0 ) || ( StringUtil.StrCmp(A145CLAntDocNum, Z145CLAntDocNum) != 0 ) || ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
               {
                  A144CLAntTipCod = Z144CLAntTipCod;
                  AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
                  A145CLAntDocNum = Z145CLAntDocNum;
                  AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
                  A149TipCod = Z149TipCod;
                  AssignAttri("", false, "A149TipCod", A149TipCod);
                  A24DocNum = Z24DocNum;
                  AssignAttri("", false, "A24DocNum", A24DocNum);
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
                  Update088( ) ;
                  GX_FocusControl = edtCLAntTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A144CLAntTipCod, Z144CLAntTipCod) != 0 ) || ( StringUtil.StrCmp(A145CLAntDocNum, Z145CLAntDocNum) != 0 ) || ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCLAntTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     Insert088( ) ;
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
         if ( ( StringUtil.StrCmp(A144CLAntTipCod, Z144CLAntTipCod) != 0 ) || ( StringUtil.StrCmp(A145CLAntDocNum, Z145CLAntDocNum) != 0 ) || ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A24DocNum, Z24DocNum) != 0 ) )
         {
            A144CLAntTipCod = Z144CLAntTipCod;
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = Z145CLAntDocNum;
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            A149TipCod = Z149TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = Z24DocNum;
            AssignAttri("", false, "A24DocNum", A24DocNum);
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLANTTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCLAntDImporte_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntDImporte_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntDImporte_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntDImporte_Internalname;
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
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext088( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCLAntDImporte_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLANTICIPOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z552CLAntDImporte != T00082_A552CLAntDImporte[0] ) )
            {
               if ( Z552CLAntDImporte != T00082_A552CLAntDImporte[0] )
               {
                  GXUtil.WriteLog("clanticiposdet:[seudo value changed for attri]"+"CLAntDImporte");
                  GXUtil.WriteLogRaw("Old: ",Z552CLAntDImporte);
                  GXUtil.WriteLogRaw("Current: ",T00082_A552CLAntDImporte[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLANTICIPOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000812 */
                     pr_default.execute(10, new Object[] {A552CLAntDImporte, A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOSDET");
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
                           ResetCaption080( ) ;
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000813 */
                     pr_default.execute(11, new Object[] {A552CLAntDImporte, A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOSDET");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLANTICIPOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption080( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000814 */
                  pr_default.execute(12, new Object[] {A144CLAntTipCod, A145CLAntDocNum, A149TipCod, A24DocNum});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLANTICIPOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll088( ) ;
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
                        ResetCaption080( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("clanticiposdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("clanticiposdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Using cursor T000815 */
         pr_default.execute(13);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A144CLAntTipCod = T000815_A144CLAntTipCod[0];
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = T000815_A145CLAntDocNum[0];
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            A149TipCod = T000815_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T000815_A24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound8 = 1;
            A144CLAntTipCod = T000815_A144CLAntTipCod[0];
            AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
            A145CLAntDocNum = T000815_A145CLAntDocNum[0];
            AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
            A149TipCod = T000815_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A24DocNum = T000815_A24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtCLAntTipCod_Enabled = 0;
         AssignProp("", false, edtCLAntTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntTipCod_Enabled), 5, 0), true);
         edtCLAntDocNum_Enabled = 0;
         AssignProp("", false, edtCLAntDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntDocNum_Enabled), 5, 0), true);
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtDocNum_Enabled = 0;
         AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), true);
         edtCLAntDImporte_Enabled = 0;
         AssignProp("", false, edtCLAntDImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCLAntDImporte_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181144115", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clanticiposdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z552CLAntDImporte", StringUtil.LTrim( StringUtil.NToC( Z552CLAntDImporte, 15, 2, ".", "")));
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
         return formatLink("clanticiposdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLANTICIPOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Anticipos Clientes Detalle" ;
      }

      protected void InitializeNonKey088( )
      {
         A552CLAntDImporte = 0;
         AssignAttri("", false, "A552CLAntDImporte", StringUtil.LTrimStr( A552CLAntDImporte, 15, 2));
         Z552CLAntDImporte = 0;
      }

      protected void InitAll088( )
      {
         A144CLAntTipCod = "";
         AssignAttri("", false, "A144CLAntTipCod", A144CLAntTipCod);
         A145CLAntDocNum = "";
         AssignAttri("", false, "A145CLAntDocNum", A145CLAntDocNum);
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         A24DocNum = "";
         AssignAttri("", false, "A24DocNum", A24DocNum);
         InitializeNonKey088( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811441110", true, true);
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
         context.AddJavascriptSource("clanticiposdet.js", "?202281811441110", false, true);
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
         edtCLAntTipCod_Internalname = "CLANTTIPCOD";
         edtCLAntDocNum_Internalname = "CLANTDOCNUM";
         edtTipCod_Internalname = "TIPCOD";
         edtDocNum_Internalname = "DOCNUM";
         edtCLAntDImporte_Internalname = "CLANTDIMPORTE";
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
         Form.Caption = "Anticipos Clientes Detalle";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCLAntDImporte_Jsonclick = "";
         edtCLAntDImporte_Enabled = 1;
         edtDocNum_Jsonclick = "";
         edtDocNum_Enabled = 1;
         edtTipCod_Jsonclick = "";
         edtTipCod_Enabled = 1;
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

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T000816 */
         pr_default.execute(14, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Anticipos'.", "ForeignKeyNotFound", 1, "CLANTDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCLAntTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T000817 */
         pr_default.execute(15, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtCLAntDImporte_Internalname;
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
         /* Using cursor T000816 */
         pr_default.execute(14, new Object[] {A144CLAntTipCod, A145CLAntDocNum});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Anticipos'.", "ForeignKeyNotFound", 1, "CLANTDOCNUM");
            AnyError = 1;
            GX_FocusControl = edtCLAntTipCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Docnum( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T000817 */
         pr_default.execute(15, new Object[] {A149TipCod, A24DocNum});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A552CLAntDImporte", StringUtil.LTrim( StringUtil.NToC( A552CLAntDImporte, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z144CLAntTipCod", StringUtil.RTrim( Z144CLAntTipCod));
         GxWebStd.gx_hidden_field( context, "Z145CLAntDocNum", StringUtil.RTrim( Z145CLAntDocNum));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z552CLAntDImporte", StringUtil.LTrim( StringUtil.NToC( Z552CLAntDImporte, 15, 2, ".", "")));
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
         setEventMetadata("VALID_CLANTTIPCOD","{handler:'Valid_Clanttipcod',iparms:[]");
         setEventMetadata("VALID_CLANTTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_CLANTDOCNUM","{handler:'Valid_Clantdocnum',iparms:[{av:'A144CLAntTipCod',fld:'CLANTTIPCOD',pic:''},{av:'A145CLAntDocNum',fld:'CLANTDOCNUM',pic:''}]");
         setEventMetadata("VALID_CLANTDOCNUM",",oparms:[]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_DOCNUM","{handler:'Valid_Docnum',iparms:[{av:'A144CLAntTipCod',fld:'CLANTTIPCOD',pic:''},{av:'A145CLAntDocNum',fld:'CLANTDOCNUM',pic:''},{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_DOCNUM",",oparms:[{av:'A552CLAntDImporte',fld:'CLANTDIMPORTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z144CLAntTipCod'},{av:'Z145CLAntDocNum'},{av:'Z149TipCod'},{av:'Z24DocNum'},{av:'Z552CLAntDImporte'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z144CLAntTipCod = "";
         Z145CLAntDocNum = "";
         Z149TipCod = "";
         Z24DocNum = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A144CLAntTipCod = "";
         A145CLAntDocNum = "";
         A149TipCod = "";
         A24DocNum = "";
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
         T00086_A552CLAntDImporte = new decimal[1] ;
         T00086_A144CLAntTipCod = new string[] {""} ;
         T00086_A145CLAntDocNum = new string[] {""} ;
         T00086_A149TipCod = new string[] {""} ;
         T00086_A24DocNum = new string[] {""} ;
         T00084_A144CLAntTipCod = new string[] {""} ;
         T00085_A149TipCod = new string[] {""} ;
         T00087_A144CLAntTipCod = new string[] {""} ;
         T00088_A149TipCod = new string[] {""} ;
         T00089_A144CLAntTipCod = new string[] {""} ;
         T00089_A145CLAntDocNum = new string[] {""} ;
         T00089_A149TipCod = new string[] {""} ;
         T00089_A24DocNum = new string[] {""} ;
         T00083_A552CLAntDImporte = new decimal[1] ;
         T00083_A144CLAntTipCod = new string[] {""} ;
         T00083_A145CLAntDocNum = new string[] {""} ;
         T00083_A149TipCod = new string[] {""} ;
         T00083_A24DocNum = new string[] {""} ;
         sMode8 = "";
         T000810_A144CLAntTipCod = new string[] {""} ;
         T000810_A145CLAntDocNum = new string[] {""} ;
         T000810_A149TipCod = new string[] {""} ;
         T000810_A24DocNum = new string[] {""} ;
         T000811_A144CLAntTipCod = new string[] {""} ;
         T000811_A145CLAntDocNum = new string[] {""} ;
         T000811_A149TipCod = new string[] {""} ;
         T000811_A24DocNum = new string[] {""} ;
         T00082_A552CLAntDImporte = new decimal[1] ;
         T00082_A144CLAntTipCod = new string[] {""} ;
         T00082_A145CLAntDocNum = new string[] {""} ;
         T00082_A149TipCod = new string[] {""} ;
         T00082_A24DocNum = new string[] {""} ;
         T000815_A144CLAntTipCod = new string[] {""} ;
         T000815_A145CLAntDocNum = new string[] {""} ;
         T000815_A149TipCod = new string[] {""} ;
         T000815_A24DocNum = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000816_A144CLAntTipCod = new string[] {""} ;
         T000817_A149TipCod = new string[] {""} ;
         ZZ144CLAntTipCod = "";
         ZZ145CLAntDocNum = "";
         ZZ149TipCod = "";
         ZZ24DocNum = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clanticiposdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clanticiposdet__default(),
            new Object[][] {
                new Object[] {
               T00082_A552CLAntDImporte, T00082_A144CLAntTipCod, T00082_A145CLAntDocNum, T00082_A149TipCod, T00082_A24DocNum
               }
               , new Object[] {
               T00083_A552CLAntDImporte, T00083_A144CLAntTipCod, T00083_A145CLAntDocNum, T00083_A149TipCod, T00083_A24DocNum
               }
               , new Object[] {
               T00084_A144CLAntTipCod
               }
               , new Object[] {
               T00085_A149TipCod
               }
               , new Object[] {
               T00086_A552CLAntDImporte, T00086_A144CLAntTipCod, T00086_A145CLAntDocNum, T00086_A149TipCod, T00086_A24DocNum
               }
               , new Object[] {
               T00087_A144CLAntTipCod
               }
               , new Object[] {
               T00088_A149TipCod
               }
               , new Object[] {
               T00089_A144CLAntTipCod, T00089_A145CLAntDocNum, T00089_A149TipCod, T00089_A24DocNum
               }
               , new Object[] {
               T000810_A144CLAntTipCod, T000810_A145CLAntDocNum, T000810_A149TipCod, T000810_A24DocNum
               }
               , new Object[] {
               T000811_A144CLAntTipCod, T000811_A145CLAntDocNum, T000811_A149TipCod, T000811_A24DocNum
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000815_A144CLAntTipCod, T000815_A145CLAntDocNum, T000815_A149TipCod, T000815_A24DocNum
               }
               , new Object[] {
               T000816_A144CLAntTipCod
               }
               , new Object[] {
               T000817_A149TipCod
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
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCLAntTipCod_Enabled ;
      private int edtCLAntDocNum_Enabled ;
      private int edtTipCod_Enabled ;
      private int edtDocNum_Enabled ;
      private int edtCLAntDImporte_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private decimal Z552CLAntDImporte ;
      private decimal A552CLAntDImporte ;
      private decimal ZZ552CLAntDImporte ;
      private string sPrefix ;
      private string Z144CLAntTipCod ;
      private string Z145CLAntDocNum ;
      private string Z149TipCod ;
      private string Z24DocNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A144CLAntTipCod ;
      private string A145CLAntDocNum ;
      private string A149TipCod ;
      private string A24DocNum ;
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
      private string edtCLAntTipCod_Jsonclick ;
      private string edtCLAntDocNum_Internalname ;
      private string edtCLAntDocNum_Jsonclick ;
      private string edtTipCod_Internalname ;
      private string edtTipCod_Jsonclick ;
      private string edtDocNum_Internalname ;
      private string edtDocNum_Jsonclick ;
      private string edtCLAntDImporte_Internalname ;
      private string edtCLAntDImporte_Jsonclick ;
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
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ144CLAntTipCod ;
      private string ZZ145CLAntDocNum ;
      private string ZZ149TipCod ;
      private string ZZ24DocNum ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T00086_A552CLAntDImporte ;
      private string[] T00086_A144CLAntTipCod ;
      private string[] T00086_A145CLAntDocNum ;
      private string[] T00086_A149TipCod ;
      private string[] T00086_A24DocNum ;
      private string[] T00084_A144CLAntTipCod ;
      private string[] T00085_A149TipCod ;
      private string[] T00087_A144CLAntTipCod ;
      private string[] T00088_A149TipCod ;
      private string[] T00089_A144CLAntTipCod ;
      private string[] T00089_A145CLAntDocNum ;
      private string[] T00089_A149TipCod ;
      private string[] T00089_A24DocNum ;
      private decimal[] T00083_A552CLAntDImporte ;
      private string[] T00083_A144CLAntTipCod ;
      private string[] T00083_A145CLAntDocNum ;
      private string[] T00083_A149TipCod ;
      private string[] T00083_A24DocNum ;
      private string[] T000810_A144CLAntTipCod ;
      private string[] T000810_A145CLAntDocNum ;
      private string[] T000810_A149TipCod ;
      private string[] T000810_A24DocNum ;
      private string[] T000811_A144CLAntTipCod ;
      private string[] T000811_A145CLAntDocNum ;
      private string[] T000811_A149TipCod ;
      private string[] T000811_A24DocNum ;
      private decimal[] T00082_A552CLAntDImporte ;
      private string[] T00082_A144CLAntTipCod ;
      private string[] T00082_A145CLAntDocNum ;
      private string[] T00082_A149TipCod ;
      private string[] T00082_A24DocNum ;
      private string[] T000815_A144CLAntTipCod ;
      private string[] T000815_A145CLAntDocNum ;
      private string[] T000815_A149TipCod ;
      private string[] T000815_A24DocNum ;
      private string[] T000816_A144CLAntTipCod ;
      private string[] T000817_A149TipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clanticiposdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clanticiposdet__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00086;
        prmT00086 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT00084;
        prmT00084 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT00085;
        prmT00085 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT00087;
        prmT00087 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT00088;
        prmT00088 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT00089;
        prmT00089 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT00083;
        prmT00083 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT000810;
        prmT000810 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT000811;
        prmT000811 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT00082;
        prmT00082 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT000812;
        prmT000812 = new Object[] {
        new ParDef("@CLAntDImporte",GXType.Decimal,15,2) ,
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT000813;
        prmT000813 = new Object[] {
        new ParDef("@CLAntDImporte",GXType.Decimal,15,2) ,
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT000814;
        prmT000814 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        Object[] prmT000815;
        prmT000815 = new Object[] {
        };
        Object[] prmT000816;
        prmT000816 = new Object[] {
        new ParDef("@CLAntTipCod",GXType.NChar,3,0) ,
        new ParDef("@CLAntDocNum",GXType.NChar,12,0)
        };
        Object[] prmT000817;
        prmT000817 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@DocNum",GXType.NChar,12,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00082", "SELECT [CLAntDImporte], [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WITH (UPDLOCK) WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00083", "SELECT [CLAntDImporte], [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00084", "SELECT [CLAntTipCod] FROM [CLANTICIPOS] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00085", "SELECT [TipCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00086", "SELECT TM1.[CLAntDImporte], TM1.[CLAntTipCod], TM1.[CLAntDocNum], TM1.[TipCod], TM1.[DocNum] FROM [CLANTICIPOSDET] TM1 WHERE TM1.[CLAntTipCod] = @CLAntTipCod and TM1.[CLAntDocNum] = @CLAntDocNum and TM1.[TipCod] = @TipCod and TM1.[DocNum] = @DocNum ORDER BY TM1.[CLAntTipCod], TM1.[CLAntDocNum], TM1.[TipCod], TM1.[DocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00087", "SELECT [CLAntTipCod] FROM [CLANTICIPOS] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00088", "SELECT [TipCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00089", "SELECT [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000810", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE ( [CLAntTipCod] > @CLAntTipCod or [CLAntTipCod] = @CLAntTipCod and [CLAntDocNum] > @CLAntDocNum or [CLAntDocNum] = @CLAntDocNum and [CLAntTipCod] = @CLAntTipCod and [TipCod] > @TipCod or [TipCod] = @TipCod and [CLAntDocNum] = @CLAntDocNum and [CLAntTipCod] = @CLAntTipCod and [DocNum] > @DocNum) ORDER BY [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000811", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] WHERE ( [CLAntTipCod] < @CLAntTipCod or [CLAntTipCod] = @CLAntTipCod and [CLAntDocNum] < @CLAntDocNum or [CLAntDocNum] = @CLAntDocNum and [CLAntTipCod] = @CLAntTipCod and [TipCod] < @TipCod or [TipCod] = @TipCod and [CLAntDocNum] = @CLAntDocNum and [CLAntTipCod] = @CLAntTipCod and [DocNum] < @DocNum) ORDER BY [CLAntTipCod] DESC, [CLAntDocNum] DESC, [TipCod] DESC, [DocNum] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000812", "INSERT INTO [CLANTICIPOSDET]([CLAntDImporte], [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum]) VALUES(@CLAntDImporte, @CLAntTipCod, @CLAntDocNum, @TipCod, @DocNum)", GxErrorMask.GX_NOMASK,prmT000812)
           ,new CursorDef("T000813", "UPDATE [CLANTICIPOSDET] SET [CLAntDImporte]=@CLAntDImporte  WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK,prmT000813)
           ,new CursorDef("T000814", "DELETE FROM [CLANTICIPOSDET]  WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum AND [TipCod] = @TipCod AND [DocNum] = @DocNum", GxErrorMask.GX_NOMASK,prmT000814)
           ,new CursorDef("T000815", "SELECT [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum] FROM [CLANTICIPOSDET] ORDER BY [CLAntTipCod], [CLAntDocNum], [TipCod], [DocNum]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000816", "SELECT [CLAntTipCod] FROM [CLANTICIPOS] WHERE [CLAntTipCod] = @CLAntTipCod AND [CLAntDocNum] = @CLAntDocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT000816,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000817", "SELECT [TipCod] FROM [CLVENTAS] WHERE [TipCod] = @TipCod AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT000817,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 1 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              ((string[]) buf[3])[0] = rslt.getString(4, 3);
              ((string[]) buf[4])[0] = rslt.getString(5, 12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 12);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 12);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 12);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((string[]) buf[3])[0] = rslt.getString(4, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
