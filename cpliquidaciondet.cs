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
   public class cpliquidaciondet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A279LiqMTipCod = GetPar( "LiqMTipCod");
            AssignAttri("", false, "A279LiqMTipCod", A279LiqMTipCod);
            A280LiqMComCod = GetPar( "LiqMComCod");
            AssignAttri("", false, "A280LiqMComCod", A280LiqMComCod);
            A281LiqMPrvCod = GetPar( "LiqMPrvCod");
            AssignAttri("", false, "A281LiqMPrvCod", A281LiqMPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A279LiqMTipCod, A280LiqMComCod, A281LiqMPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A281LiqMPrvCod = GetPar( "LiqMPrvCod");
            AssignAttri("", false, "A281LiqMPrvCod", A281LiqMPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A281LiqMPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A278LiqMTMovCod = (int)(NumberUtil.Val( GetPar( "LiqMTMovCod"), "."));
            AssignAttri("", false, "A278LiqMTMovCod", StringUtil.LTrimStr( (decimal)(A278LiqMTMovCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A278LiqMTMovCod) ;
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
            Form.Meta.addItem("description", "Liquidación Detalle", 0) ;
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

      public cpliquidaciondet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpliquidaciondet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Liquidación Detalle", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_CPLIQUIDACIONDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPLIQUIDACIONDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtLiqCod_Internalname, A270LiqCod, StringUtil.RTrim( context.localUtil.Format( A270LiqCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
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
         GxWebStd.gx_single_line_edit( context, edtLiqPrvCod_Internalname, StringUtil.RTrim( A236LiqPrvCod), StringUtil.RTrim( context.localUtil.Format( A236LiqPrvCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A277LiqMItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqMItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A277LiqMItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A277LiqMItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMFech_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMFech_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLiqMFech_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLiqMFech_Internalname, context.localUtil.Format(A1180LiqMFech, "99/99/99"), context.localUtil.Format( A1180LiqMFech, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMFech_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMFech_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_bitmap( context, edtLiqMFech_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLiqMFech_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLIQUIDACIONDET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMConcepto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMConcepto_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMConcepto_Internalname, A1179LiqMConcepto, StringUtil.RTrim( context.localUtil.Format( A1179LiqMConcepto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMConcepto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMConcepto_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMPrvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMPrvCod_Internalname, "Proveedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMPrvCod_Internalname, StringUtil.RTrim( A281LiqMPrvCod), StringUtil.RTrim( context.localUtil.Format( A281LiqMPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMPrvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMPrvDsc_Internalname, "Proveeedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqMPrvDsc_Internalname, StringUtil.RTrim( A1187LiqMPrvDsc), StringUtil.RTrim( context.localUtil.Format( A1187LiqMPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMTipCod_Internalname, "Tipo Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMTipCod_Internalname, StringUtil.RTrim( A279LiqMTipCod), StringUtil.RTrim( context.localUtil.Format( A279LiqMTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMComCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMComCod_Internalname, "N° Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMComCod_Internalname, StringUtil.RTrim( A280LiqMComCod), StringUtil.RTrim( context.localUtil.Format( A280LiqMComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMComCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMForCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMForCod_Internalname, "Forma de Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1181LiqMForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqMForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1181LiqMForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1181LiqMForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqMMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1183LiqMMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqMMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1183LiqMMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1183LiqMMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMTipCmb_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMTipCmb_Internalname, "Tipo de Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMTipCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1189LiqMTipCmb, 10, 4, ".", "")), StringUtil.LTrim( ((edtLiqMTipCmb_Enabled!=0) ? context.localUtil.Format( A1189LiqMTipCmb, "ZZZZ9.9999") : context.localUtil.Format( A1189LiqMTipCmb, "ZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMTipCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMTipCmb_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMImporte_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMImporte_Internalname, "Importe Saldo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMImporte_Internalname, StringUtil.LTrim( StringUtil.NToC( A1182LiqMImporte, 15, 2, ".", "")), StringUtil.LTrim( ((edtLiqMImporte_Enabled!=0) ? context.localUtil.Format( A1182LiqMImporte, "ZZZZZZZZZZZ9.99") : context.localUtil.Format( A1182LiqMImporte, "ZZZZZZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMImporte_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMImporte_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMPago_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMPago_Internalname, "Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A1185LiqMPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtLiqMPago_Enabled!=0) ? context.localUtil.Format( A1185LiqMPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1185LiqMPago, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMVouAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMVouAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1194LiqMVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtLiqMVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1194LiqMVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1194LiqMVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMVouMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMVouMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1195LiqMVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtLiqMVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1195LiqMVouMes), "Z9") : context.localUtil.Format( (decimal)(A1195LiqMVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMTASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMTASICod_Internalname, "Tipo Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1188LiqMTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqMTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1188LiqMTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1188LiqMTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMVouNum_Internalname, "N° Voucher", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMVouNum_Internalname, StringUtil.RTrim( A1196LiqMVouNum), StringUtil.RTrim( context.localUtil.Format( A1196LiqMVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMTMovCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMTMovCod_Internalname, "Tipo Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMTMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A278LiqMTMovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLiqMTMovCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A278LiqMTMovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A278LiqMTMovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMTMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMTMovCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMTMovDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMTMovDsc_Internalname, "Tipo Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqMTMovDsc_Internalname, StringUtil.RTrim( A1191LiqMTMovDsc), StringUtil.RTrim( context.localUtil.Format( A1191LiqMTMovDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMTMovDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMTMovDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMUsuCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMUsuCod_Internalname, "Usuario", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMUsuCod_Internalname, StringUtil.RTrim( A1192LiqMUsuCod), StringUtil.RTrim( context.localUtil.Format( A1192LiqMUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,128);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMUsuFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMUsuFec_Internalname, "Usuario Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtLiqMUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtLiqMUsuFec_Internalname, context.localUtil.TToC( A1193LiqMUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1193LiqMUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_bitmap( context, edtLiqMUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtLiqMUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPLIQUIDACIONDET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMPagReg_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMPagReg_Internalname, "Item Pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLiqMPagReg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1186LiqMPagReg), 10, 0, ".", "")), StringUtil.LTrim( ((edtLiqMPagReg_Enabled!=0) ? context.localUtil.Format( (decimal)(A1186LiqMPagReg), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1186LiqMPagReg), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,138);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMPagReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMPagReg_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLiqMTMovCueCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLiqMTMovCueCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtLiqMTMovCueCod_Internalname, StringUtil.RTrim( A1190LiqMTMovCueCod), StringUtil.RTrim( context.localUtil.Format( A1190LiqMTMovCueCod, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLiqMTMovCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLiqMTMovCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPLIQUIDACIONDET.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 150,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 152,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPLIQUIDACIONDET.htm");
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
            Z277LiqMItem = (int)(context.localUtil.CToN( cgiGet( "Z277LiqMItem"), ".", ","));
            Z1180LiqMFech = context.localUtil.CToD( cgiGet( "Z1180LiqMFech"), 0);
            Z1179LiqMConcepto = cgiGet( "Z1179LiqMConcepto");
            Z1181LiqMForCod = (int)(context.localUtil.CToN( cgiGet( "Z1181LiqMForCod"), ".", ","));
            Z1189LiqMTipCmb = context.localUtil.CToN( cgiGet( "Z1189LiqMTipCmb"), ".", ",");
            Z1182LiqMImporte = context.localUtil.CToN( cgiGet( "Z1182LiqMImporte"), ".", ",");
            Z1185LiqMPago = context.localUtil.CToN( cgiGet( "Z1185LiqMPago"), ".", ",");
            Z1194LiqMVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1194LiqMVouAno"), ".", ","));
            Z1195LiqMVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1195LiqMVouMes"), ".", ","));
            Z1188LiqMTASICod = (int)(context.localUtil.CToN( cgiGet( "Z1188LiqMTASICod"), ".", ","));
            Z1196LiqMVouNum = cgiGet( "Z1196LiqMVouNum");
            Z1192LiqMUsuCod = cgiGet( "Z1192LiqMUsuCod");
            Z1193LiqMUsuFec = context.localUtil.CToT( cgiGet( "Z1193LiqMUsuFec"), 0);
            Z1186LiqMPagReg = (long)(context.localUtil.CToN( cgiGet( "Z1186LiqMPagReg"), ".", ","));
            Z279LiqMTipCod = cgiGet( "Z279LiqMTipCod");
            Z280LiqMComCod = cgiGet( "Z280LiqMComCod");
            Z281LiqMPrvCod = cgiGet( "Z281LiqMPrvCod");
            Z278LiqMTMovCod = (int)(context.localUtil.CToN( cgiGet( "Z278LiqMTMovCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A270LiqCod = cgiGet( edtLiqCod_Internalname);
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = cgiGet( edtLiqPrvCod_Internalname);
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMITEM");
               AnyError = 1;
               GX_FocusControl = edtLiqMItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A277LiqMItem = 0;
               AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
            }
            else
            {
               A277LiqMItem = (int)(context.localUtil.CToN( cgiGet( edtLiqMItem_Internalname), ".", ","));
               AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtLiqMFech_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "LIQMFECH");
               AnyError = 1;
               GX_FocusControl = edtLiqMFech_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1180LiqMFech = DateTime.MinValue;
               AssignAttri("", false, "A1180LiqMFech", context.localUtil.Format(A1180LiqMFech, "99/99/99"));
            }
            else
            {
               A1180LiqMFech = context.localUtil.CToD( cgiGet( edtLiqMFech_Internalname), 2);
               AssignAttri("", false, "A1180LiqMFech", context.localUtil.Format(A1180LiqMFech, "99/99/99"));
            }
            A1179LiqMConcepto = cgiGet( edtLiqMConcepto_Internalname);
            AssignAttri("", false, "A1179LiqMConcepto", A1179LiqMConcepto);
            A281LiqMPrvCod = StringUtil.Upper( cgiGet( edtLiqMPrvCod_Internalname));
            AssignAttri("", false, "A281LiqMPrvCod", A281LiqMPrvCod);
            A1187LiqMPrvDsc = cgiGet( edtLiqMPrvDsc_Internalname);
            AssignAttri("", false, "A1187LiqMPrvDsc", A1187LiqMPrvDsc);
            A279LiqMTipCod = cgiGet( edtLiqMTipCod_Internalname);
            AssignAttri("", false, "A279LiqMTipCod", A279LiqMTipCod);
            A280LiqMComCod = cgiGet( edtLiqMComCod_Internalname);
            AssignAttri("", false, "A280LiqMComCod", A280LiqMComCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMFORCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqMForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1181LiqMForCod = 0;
               AssignAttri("", false, "A1181LiqMForCod", StringUtil.LTrimStr( (decimal)(A1181LiqMForCod), 6, 0));
            }
            else
            {
               A1181LiqMForCod = (int)(context.localUtil.CToN( cgiGet( edtLiqMForCod_Internalname), ".", ","));
               AssignAttri("", false, "A1181LiqMForCod", StringUtil.LTrimStr( (decimal)(A1181LiqMForCod), 6, 0));
            }
            A1183LiqMMonCod = (int)(context.localUtil.CToN( cgiGet( edtLiqMMonCod_Internalname), ".", ","));
            AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrimStr( (decimal)(A1183LiqMMonCod), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMTipCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMTipCmb_Internalname), ".", ",") > 99999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMTIPCMB");
               AnyError = 1;
               GX_FocusControl = edtLiqMTipCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1189LiqMTipCmb = 0;
               AssignAttri("", false, "A1189LiqMTipCmb", StringUtil.LTrimStr( A1189LiqMTipCmb, 10, 4));
            }
            else
            {
               A1189LiqMTipCmb = context.localUtil.CToN( cgiGet( edtLiqMTipCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1189LiqMTipCmb", StringUtil.LTrimStr( A1189LiqMTipCmb, 10, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMImporte_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMImporte_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMIMPORTE");
               AnyError = 1;
               GX_FocusControl = edtLiqMImporte_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1182LiqMImporte = 0;
               AssignAttri("", false, "A1182LiqMImporte", StringUtil.LTrimStr( A1182LiqMImporte, 15, 2));
            }
            else
            {
               A1182LiqMImporte = context.localUtil.CToN( cgiGet( edtLiqMImporte_Internalname), ".", ",");
               AssignAttri("", false, "A1182LiqMImporte", StringUtil.LTrimStr( A1182LiqMImporte, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMPago_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMPago_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMPAGO");
               AnyError = 1;
               GX_FocusControl = edtLiqMPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1185LiqMPago = 0;
               AssignAttri("", false, "A1185LiqMPago", StringUtil.LTrimStr( A1185LiqMPago, 15, 2));
            }
            else
            {
               A1185LiqMPago = context.localUtil.CToN( cgiGet( edtLiqMPago_Internalname), ".", ",");
               AssignAttri("", false, "A1185LiqMPago", StringUtil.LTrimStr( A1185LiqMPago, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMVOUANO");
               AnyError = 1;
               GX_FocusControl = edtLiqMVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1194LiqMVouAno = 0;
               AssignAttri("", false, "A1194LiqMVouAno", StringUtil.LTrimStr( (decimal)(A1194LiqMVouAno), 4, 0));
            }
            else
            {
               A1194LiqMVouAno = (short)(context.localUtil.CToN( cgiGet( edtLiqMVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1194LiqMVouAno", StringUtil.LTrimStr( (decimal)(A1194LiqMVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMVOUMES");
               AnyError = 1;
               GX_FocusControl = edtLiqMVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1195LiqMVouMes = 0;
               AssignAttri("", false, "A1195LiqMVouMes", StringUtil.LTrimStr( (decimal)(A1195LiqMVouMes), 2, 0));
            }
            else
            {
               A1195LiqMVouMes = (short)(context.localUtil.CToN( cgiGet( edtLiqMVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1195LiqMVouMes", StringUtil.LTrimStr( (decimal)(A1195LiqMVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMTASICOD");
               AnyError = 1;
               GX_FocusControl = edtLiqMTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1188LiqMTASICod = 0;
               AssignAttri("", false, "A1188LiqMTASICod", StringUtil.LTrimStr( (decimal)(A1188LiqMTASICod), 6, 0));
            }
            else
            {
               A1188LiqMTASICod = (int)(context.localUtil.CToN( cgiGet( edtLiqMTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A1188LiqMTASICod", StringUtil.LTrimStr( (decimal)(A1188LiqMTASICod), 6, 0));
            }
            A1196LiqMVouNum = cgiGet( edtLiqMVouNum_Internalname);
            AssignAttri("", false, "A1196LiqMVouNum", A1196LiqMVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMTMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMTMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMTMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtLiqMTMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A278LiqMTMovCod = 0;
               AssignAttri("", false, "A278LiqMTMovCod", StringUtil.LTrimStr( (decimal)(A278LiqMTMovCod), 6, 0));
            }
            else
            {
               A278LiqMTMovCod = (int)(context.localUtil.CToN( cgiGet( edtLiqMTMovCod_Internalname), ".", ","));
               AssignAttri("", false, "A278LiqMTMovCod", StringUtil.LTrimStr( (decimal)(A278LiqMTMovCod), 6, 0));
            }
            A1191LiqMTMovDsc = cgiGet( edtLiqMTMovDsc_Internalname);
            AssignAttri("", false, "A1191LiqMTMovDsc", A1191LiqMTMovDsc);
            A1192LiqMUsuCod = cgiGet( edtLiqMUsuCod_Internalname);
            AssignAttri("", false, "A1192LiqMUsuCod", A1192LiqMUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtLiqMUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "LIQMUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtLiqMUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1193LiqMUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1193LiqMUsuFec", context.localUtil.TToC( A1193LiqMUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1193LiqMUsuFec = context.localUtil.CToT( cgiGet( edtLiqMUsuFec_Internalname));
               AssignAttri("", false, "A1193LiqMUsuFec", context.localUtil.TToC( A1193LiqMUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtLiqMPagReg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLiqMPagReg_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LIQMPAGREG");
               AnyError = 1;
               GX_FocusControl = edtLiqMPagReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1186LiqMPagReg = 0;
               AssignAttri("", false, "A1186LiqMPagReg", StringUtil.LTrimStr( (decimal)(A1186LiqMPagReg), 10, 0));
            }
            else
            {
               A1186LiqMPagReg = (long)(context.localUtil.CToN( cgiGet( edtLiqMPagReg_Internalname), ".", ","));
               AssignAttri("", false, "A1186LiqMPagReg", StringUtil.LTrimStr( (decimal)(A1186LiqMPagReg), 10, 0));
            }
            A1190LiqMTMovCueCod = cgiGet( edtLiqMTMovCueCod_Internalname);
            AssignAttri("", false, "A1190LiqMTMovCueCod", A1190LiqMTMovCueCod);
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
               A277LiqMItem = (int)(NumberUtil.Val( GetPar( "LiqMItem"), "."));
               AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
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
               InitAll3D116( ) ;
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
         DisableAttributes3D116( ) ;
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

      protected void ResetCaption3D0( )
      {
      }

      protected void ZM3D116( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1180LiqMFech = T003D3_A1180LiqMFech[0];
               Z1179LiqMConcepto = T003D3_A1179LiqMConcepto[0];
               Z1181LiqMForCod = T003D3_A1181LiqMForCod[0];
               Z1189LiqMTipCmb = T003D3_A1189LiqMTipCmb[0];
               Z1182LiqMImporte = T003D3_A1182LiqMImporte[0];
               Z1185LiqMPago = T003D3_A1185LiqMPago[0];
               Z1194LiqMVouAno = T003D3_A1194LiqMVouAno[0];
               Z1195LiqMVouMes = T003D3_A1195LiqMVouMes[0];
               Z1188LiqMTASICod = T003D3_A1188LiqMTASICod[0];
               Z1196LiqMVouNum = T003D3_A1196LiqMVouNum[0];
               Z1192LiqMUsuCod = T003D3_A1192LiqMUsuCod[0];
               Z1193LiqMUsuFec = T003D3_A1193LiqMUsuFec[0];
               Z1186LiqMPagReg = T003D3_A1186LiqMPagReg[0];
               Z279LiqMTipCod = T003D3_A279LiqMTipCod[0];
               Z280LiqMComCod = T003D3_A280LiqMComCod[0];
               Z281LiqMPrvCod = T003D3_A281LiqMPrvCod[0];
               Z278LiqMTMovCod = T003D3_A278LiqMTMovCod[0];
            }
            else
            {
               Z1180LiqMFech = A1180LiqMFech;
               Z1179LiqMConcepto = A1179LiqMConcepto;
               Z1181LiqMForCod = A1181LiqMForCod;
               Z1189LiqMTipCmb = A1189LiqMTipCmb;
               Z1182LiqMImporte = A1182LiqMImporte;
               Z1185LiqMPago = A1185LiqMPago;
               Z1194LiqMVouAno = A1194LiqMVouAno;
               Z1195LiqMVouMes = A1195LiqMVouMes;
               Z1188LiqMTASICod = A1188LiqMTASICod;
               Z1196LiqMVouNum = A1196LiqMVouNum;
               Z1192LiqMUsuCod = A1192LiqMUsuCod;
               Z1193LiqMUsuFec = A1193LiqMUsuFec;
               Z1186LiqMPagReg = A1186LiqMPagReg;
               Z279LiqMTipCod = A279LiqMTipCod;
               Z280LiqMComCod = A280LiqMComCod;
               Z281LiqMPrvCod = A281LiqMPrvCod;
               Z278LiqMTMovCod = A278LiqMTMovCod;
            }
         }
         if ( GX_JID == -3 )
         {
            Z270LiqCod = A270LiqCod;
            Z277LiqMItem = A277LiqMItem;
            Z1180LiqMFech = A1180LiqMFech;
            Z1179LiqMConcepto = A1179LiqMConcepto;
            Z1181LiqMForCod = A1181LiqMForCod;
            Z1189LiqMTipCmb = A1189LiqMTipCmb;
            Z1182LiqMImporte = A1182LiqMImporte;
            Z1185LiqMPago = A1185LiqMPago;
            Z1194LiqMVouAno = A1194LiqMVouAno;
            Z1195LiqMVouMes = A1195LiqMVouMes;
            Z1188LiqMTASICod = A1188LiqMTASICod;
            Z1196LiqMVouNum = A1196LiqMVouNum;
            Z1192LiqMUsuCod = A1192LiqMUsuCod;
            Z1193LiqMUsuFec = A1193LiqMUsuFec;
            Z1186LiqMPagReg = A1186LiqMPagReg;
            Z236LiqPrvCod = A236LiqPrvCod;
            Z279LiqMTipCod = A279LiqMTipCod;
            Z280LiqMComCod = A280LiqMComCod;
            Z281LiqMPrvCod = A281LiqMPrvCod;
            Z278LiqMTMovCod = A278LiqMTMovCod;
            Z1187LiqMPrvDsc = A1187LiqMPrvDsc;
            Z1183LiqMMonCod = A1183LiqMMonCod;
            Z1191LiqMTMovDsc = A1191LiqMTMovDsc;
            Z1190LiqMTMovCueCod = A1190LiqMTMovCueCod;
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

      protected void Load3D116( )
      {
         /* Using cursor T003D8 */
         pr_default.execute(6, new Object[] {A270LiqCod, A236LiqPrvCod, A277LiqMItem});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound116 = 1;
            A1180LiqMFech = T003D8_A1180LiqMFech[0];
            AssignAttri("", false, "A1180LiqMFech", context.localUtil.Format(A1180LiqMFech, "99/99/99"));
            A1179LiqMConcepto = T003D8_A1179LiqMConcepto[0];
            AssignAttri("", false, "A1179LiqMConcepto", A1179LiqMConcepto);
            A1187LiqMPrvDsc = T003D8_A1187LiqMPrvDsc[0];
            AssignAttri("", false, "A1187LiqMPrvDsc", A1187LiqMPrvDsc);
            A1181LiqMForCod = T003D8_A1181LiqMForCod[0];
            AssignAttri("", false, "A1181LiqMForCod", StringUtil.LTrimStr( (decimal)(A1181LiqMForCod), 6, 0));
            A1189LiqMTipCmb = T003D8_A1189LiqMTipCmb[0];
            AssignAttri("", false, "A1189LiqMTipCmb", StringUtil.LTrimStr( A1189LiqMTipCmb, 10, 4));
            A1182LiqMImporte = T003D8_A1182LiqMImporte[0];
            AssignAttri("", false, "A1182LiqMImporte", StringUtil.LTrimStr( A1182LiqMImporte, 15, 2));
            A1185LiqMPago = T003D8_A1185LiqMPago[0];
            AssignAttri("", false, "A1185LiqMPago", StringUtil.LTrimStr( A1185LiqMPago, 15, 2));
            A1194LiqMVouAno = T003D8_A1194LiqMVouAno[0];
            AssignAttri("", false, "A1194LiqMVouAno", StringUtil.LTrimStr( (decimal)(A1194LiqMVouAno), 4, 0));
            A1195LiqMVouMes = T003D8_A1195LiqMVouMes[0];
            AssignAttri("", false, "A1195LiqMVouMes", StringUtil.LTrimStr( (decimal)(A1195LiqMVouMes), 2, 0));
            A1188LiqMTASICod = T003D8_A1188LiqMTASICod[0];
            AssignAttri("", false, "A1188LiqMTASICod", StringUtil.LTrimStr( (decimal)(A1188LiqMTASICod), 6, 0));
            A1196LiqMVouNum = T003D8_A1196LiqMVouNum[0];
            AssignAttri("", false, "A1196LiqMVouNum", A1196LiqMVouNum);
            A1191LiqMTMovDsc = T003D8_A1191LiqMTMovDsc[0];
            AssignAttri("", false, "A1191LiqMTMovDsc", A1191LiqMTMovDsc);
            A1192LiqMUsuCod = T003D8_A1192LiqMUsuCod[0];
            AssignAttri("", false, "A1192LiqMUsuCod", A1192LiqMUsuCod);
            A1193LiqMUsuFec = T003D8_A1193LiqMUsuFec[0];
            AssignAttri("", false, "A1193LiqMUsuFec", context.localUtil.TToC( A1193LiqMUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1186LiqMPagReg = T003D8_A1186LiqMPagReg[0];
            AssignAttri("", false, "A1186LiqMPagReg", StringUtil.LTrimStr( (decimal)(A1186LiqMPagReg), 10, 0));
            A279LiqMTipCod = T003D8_A279LiqMTipCod[0];
            AssignAttri("", false, "A279LiqMTipCod", A279LiqMTipCod);
            A280LiqMComCod = T003D8_A280LiqMComCod[0];
            AssignAttri("", false, "A280LiqMComCod", A280LiqMComCod);
            A281LiqMPrvCod = T003D8_A281LiqMPrvCod[0];
            AssignAttri("", false, "A281LiqMPrvCod", A281LiqMPrvCod);
            A278LiqMTMovCod = T003D8_A278LiqMTMovCod[0];
            AssignAttri("", false, "A278LiqMTMovCod", StringUtil.LTrimStr( (decimal)(A278LiqMTMovCod), 6, 0));
            A1183LiqMMonCod = T003D8_A1183LiqMMonCod[0];
            AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrimStr( (decimal)(A1183LiqMMonCod), 6, 0));
            A1190LiqMTMovCueCod = T003D8_A1190LiqMTMovCueCod[0];
            AssignAttri("", false, "A1190LiqMTMovCueCod", A1190LiqMTMovCueCod);
            ZM3D116( -3) ;
         }
         pr_default.close(6);
         OnLoadActions3D116( ) ;
      }

      protected void OnLoadActions3D116( )
      {
      }

      protected void CheckExtendedTable3D116( )
      {
         nIsDirty_116 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T003D4 */
         pr_default.execute(2, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1180LiqMFech) || ( DateTimeUtil.ResetTime ( A1180LiqMFech ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "LIQMFECH");
            AnyError = 1;
            GX_FocusControl = edtLiqMFech_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T003D5 */
         pr_default.execute(3, new Object[] {A279LiqMTipCod, A280LiqMComCod, A281LiqMPrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Movimiento Liquidacion Proveedor'.", "ForeignKeyNotFound", 1, "LIQMPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1183LiqMMonCod = T003D5_A1183LiqMMonCod[0];
         AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrimStr( (decimal)(A1183LiqMMonCod), 6, 0));
         pr_default.close(3);
         /* Using cursor T003D7 */
         pr_default.execute(5, new Object[] {A281LiqMPrvCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "LIQMPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1187LiqMPrvDsc = T003D7_A1187LiqMPrvDsc[0];
         AssignAttri("", false, "A1187LiqMPrvDsc", A1187LiqMPrvDsc);
         pr_default.close(5);
         /* Using cursor T003D6 */
         pr_default.execute(4, new Object[] {A278LiqMTMovCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Movimiento'.", "ForeignKeyNotFound", 1, "LIQMTMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMTMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1191LiqMTMovDsc = T003D6_A1191LiqMTMovDsc[0];
         AssignAttri("", false, "A1191LiqMTMovDsc", A1191LiqMTMovDsc);
         A1190LiqMTMovCueCod = T003D6_A1190LiqMTMovCueCod[0];
         AssignAttri("", false, "A1190LiqMTMovCueCod", A1190LiqMTMovCueCod);
         pr_default.close(4);
         if ( ! ( (DateTime.MinValue==A1193LiqMUsuFec) || ( A1193LiqMUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "LIQMUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtLiqMUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors3D116( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A236LiqPrvCod )
      {
         /* Using cursor T003D9 */
         pr_default.execute(7, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( string A279LiqMTipCod ,
                               string A280LiqMComCod ,
                               string A281LiqMPrvCod )
      {
         /* Using cursor T003D10 */
         pr_default.execute(8, new Object[] {A279LiqMTipCod, A280LiqMComCod, A281LiqMPrvCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Movimiento Liquidacion Proveedor'.", "ForeignKeyNotFound", 1, "LIQMPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1183LiqMMonCod = T003D10_A1183LiqMMonCod[0];
         AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrimStr( (decimal)(A1183LiqMMonCod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1183LiqMMonCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_7( string A281LiqMPrvCod )
      {
         /* Using cursor T003D11 */
         pr_default.execute(9, new Object[] {A281LiqMPrvCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "LIQMPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1187LiqMPrvDsc = T003D11_A1187LiqMPrvDsc[0];
         AssignAttri("", false, "A1187LiqMPrvDsc", A1187LiqMPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1187LiqMPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_6( int A278LiqMTMovCod )
      {
         /* Using cursor T003D12 */
         pr_default.execute(10, new Object[] {A278LiqMTMovCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Movimiento'.", "ForeignKeyNotFound", 1, "LIQMTMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMTMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1191LiqMTMovDsc = T003D12_A1191LiqMTMovDsc[0];
         AssignAttri("", false, "A1191LiqMTMovDsc", A1191LiqMTMovDsc);
         A1190LiqMTMovCueCod = T003D12_A1190LiqMTMovCueCod[0];
         AssignAttri("", false, "A1190LiqMTMovCueCod", A1190LiqMTMovCueCod);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1191LiqMTMovDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1190LiqMTMovCueCod))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey3D116( )
      {
         /* Using cursor T003D13 */
         pr_default.execute(11, new Object[] {A270LiqCod, A236LiqPrvCod, A277LiqMItem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound116 = 1;
         }
         else
         {
            RcdFound116 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003D3 */
         pr_default.execute(1, new Object[] {A270LiqCod, A236LiqPrvCod, A277LiqMItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3D116( 3) ;
            RcdFound116 = 1;
            A270LiqCod = T003D3_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A277LiqMItem = T003D3_A277LiqMItem[0];
            AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
            A1180LiqMFech = T003D3_A1180LiqMFech[0];
            AssignAttri("", false, "A1180LiqMFech", context.localUtil.Format(A1180LiqMFech, "99/99/99"));
            A1179LiqMConcepto = T003D3_A1179LiqMConcepto[0];
            AssignAttri("", false, "A1179LiqMConcepto", A1179LiqMConcepto);
            A1181LiqMForCod = T003D3_A1181LiqMForCod[0];
            AssignAttri("", false, "A1181LiqMForCod", StringUtil.LTrimStr( (decimal)(A1181LiqMForCod), 6, 0));
            A1189LiqMTipCmb = T003D3_A1189LiqMTipCmb[0];
            AssignAttri("", false, "A1189LiqMTipCmb", StringUtil.LTrimStr( A1189LiqMTipCmb, 10, 4));
            A1182LiqMImporte = T003D3_A1182LiqMImporte[0];
            AssignAttri("", false, "A1182LiqMImporte", StringUtil.LTrimStr( A1182LiqMImporte, 15, 2));
            A1185LiqMPago = T003D3_A1185LiqMPago[0];
            AssignAttri("", false, "A1185LiqMPago", StringUtil.LTrimStr( A1185LiqMPago, 15, 2));
            A1194LiqMVouAno = T003D3_A1194LiqMVouAno[0];
            AssignAttri("", false, "A1194LiqMVouAno", StringUtil.LTrimStr( (decimal)(A1194LiqMVouAno), 4, 0));
            A1195LiqMVouMes = T003D3_A1195LiqMVouMes[0];
            AssignAttri("", false, "A1195LiqMVouMes", StringUtil.LTrimStr( (decimal)(A1195LiqMVouMes), 2, 0));
            A1188LiqMTASICod = T003D3_A1188LiqMTASICod[0];
            AssignAttri("", false, "A1188LiqMTASICod", StringUtil.LTrimStr( (decimal)(A1188LiqMTASICod), 6, 0));
            A1196LiqMVouNum = T003D3_A1196LiqMVouNum[0];
            AssignAttri("", false, "A1196LiqMVouNum", A1196LiqMVouNum);
            A1192LiqMUsuCod = T003D3_A1192LiqMUsuCod[0];
            AssignAttri("", false, "A1192LiqMUsuCod", A1192LiqMUsuCod);
            A1193LiqMUsuFec = T003D3_A1193LiqMUsuFec[0];
            AssignAttri("", false, "A1193LiqMUsuFec", context.localUtil.TToC( A1193LiqMUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1186LiqMPagReg = T003D3_A1186LiqMPagReg[0];
            AssignAttri("", false, "A1186LiqMPagReg", StringUtil.LTrimStr( (decimal)(A1186LiqMPagReg), 10, 0));
            A236LiqPrvCod = T003D3_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A279LiqMTipCod = T003D3_A279LiqMTipCod[0];
            AssignAttri("", false, "A279LiqMTipCod", A279LiqMTipCod);
            A280LiqMComCod = T003D3_A280LiqMComCod[0];
            AssignAttri("", false, "A280LiqMComCod", A280LiqMComCod);
            A281LiqMPrvCod = T003D3_A281LiqMPrvCod[0];
            AssignAttri("", false, "A281LiqMPrvCod", A281LiqMPrvCod);
            A278LiqMTMovCod = T003D3_A278LiqMTMovCod[0];
            AssignAttri("", false, "A278LiqMTMovCod", StringUtil.LTrimStr( (decimal)(A278LiqMTMovCod), 6, 0));
            Z270LiqCod = A270LiqCod;
            Z236LiqPrvCod = A236LiqPrvCod;
            Z277LiqMItem = A277LiqMItem;
            sMode116 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3D116( ) ;
            if ( AnyError == 1 )
            {
               RcdFound116 = 0;
               InitializeNonKey3D116( ) ;
            }
            Gx_mode = sMode116;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound116 = 0;
            InitializeNonKey3D116( ) ;
            sMode116 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode116;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3D116( ) ;
         if ( RcdFound116 == 0 )
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
         RcdFound116 = 0;
         /* Using cursor T003D14 */
         pr_default.execute(12, new Object[] {A270LiqCod, A236LiqPrvCod, A277LiqMItem});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T003D14_A270LiqCod[0], A270LiqCod) < 0 ) || ( StringUtil.StrCmp(T003D14_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003D14_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) || ( StringUtil.StrCmp(T003D14_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003D14_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003D14_A277LiqMItem[0] < A277LiqMItem ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T003D14_A270LiqCod[0], A270LiqCod) > 0 ) || ( StringUtil.StrCmp(T003D14_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003D14_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) || ( StringUtil.StrCmp(T003D14_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003D14_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003D14_A277LiqMItem[0] > A277LiqMItem ) ) )
            {
               A270LiqCod = T003D14_A270LiqCod[0];
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = T003D14_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A277LiqMItem = T003D14_A277LiqMItem[0];
               AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
               RcdFound116 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound116 = 0;
         /* Using cursor T003D15 */
         pr_default.execute(13, new Object[] {A270LiqCod, A236LiqPrvCod, A277LiqMItem});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T003D15_A270LiqCod[0], A270LiqCod) > 0 ) || ( StringUtil.StrCmp(T003D15_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003D15_A236LiqPrvCod[0], A236LiqPrvCod) > 0 ) || ( StringUtil.StrCmp(T003D15_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003D15_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003D15_A277LiqMItem[0] > A277LiqMItem ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T003D15_A270LiqCod[0], A270LiqCod) < 0 ) || ( StringUtil.StrCmp(T003D15_A270LiqCod[0], A270LiqCod) == 0 ) && ( StringUtil.StrCmp(T003D15_A236LiqPrvCod[0], A236LiqPrvCod) < 0 ) || ( StringUtil.StrCmp(T003D15_A236LiqPrvCod[0], A236LiqPrvCod) == 0 ) && ( StringUtil.StrCmp(T003D15_A270LiqCod[0], A270LiqCod) == 0 ) && ( T003D15_A277LiqMItem[0] < A277LiqMItem ) ) )
            {
               A270LiqCod = T003D15_A270LiqCod[0];
               AssignAttri("", false, "A270LiqCod", A270LiqCod);
               A236LiqPrvCod = T003D15_A236LiqPrvCod[0];
               AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
               A277LiqMItem = T003D15_A277LiqMItem[0];
               AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
               RcdFound116 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3D116( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3D116( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound116 == 1 )
            {
               if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A277LiqMItem != Z277LiqMItem ) )
               {
                  A270LiqCod = Z270LiqCod;
                  AssignAttri("", false, "A270LiqCod", A270LiqCod);
                  A236LiqPrvCod = Z236LiqPrvCod;
                  AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
                  A277LiqMItem = Z277LiqMItem;
                  AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
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
                  Update3D116( ) ;
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A277LiqMItem != Z277LiqMItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtLiqCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3D116( ) ;
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
                     Insert3D116( ) ;
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
         if ( ( StringUtil.StrCmp(A270LiqCod, Z270LiqCod) != 0 ) || ( StringUtil.StrCmp(A236LiqPrvCod, Z236LiqPrvCod) != 0 ) || ( A277LiqMItem != Z277LiqMItem ) )
         {
            A270LiqCod = Z270LiqCod;
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = Z236LiqPrvCod;
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A277LiqMItem = Z277LiqMItem;
            AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
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
         if ( RcdFound116 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "LIQCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLiqMFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3D116( ) ;
         if ( RcdFound116 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqMFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3D116( ) ;
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
         if ( RcdFound116 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqMFech_Internalname;
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
         if ( RcdFound116 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqMFech_Internalname;
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
         ScanStart3D116( ) ;
         if ( RcdFound116 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound116 != 0 )
            {
               ScanNext3D116( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLiqMFech_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3D116( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3D116( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003D2 */
            pr_default.execute(0, new Object[] {A270LiqCod, A236LiqPrvCod, A277LiqMItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLIQUIDACIONDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1180LiqMFech ) != DateTimeUtil.ResetTime ( T003D2_A1180LiqMFech[0] ) ) || ( StringUtil.StrCmp(Z1179LiqMConcepto, T003D2_A1179LiqMConcepto[0]) != 0 ) || ( Z1181LiqMForCod != T003D2_A1181LiqMForCod[0] ) || ( Z1189LiqMTipCmb != T003D2_A1189LiqMTipCmb[0] ) || ( Z1182LiqMImporte != T003D2_A1182LiqMImporte[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1185LiqMPago != T003D2_A1185LiqMPago[0] ) || ( Z1194LiqMVouAno != T003D2_A1194LiqMVouAno[0] ) || ( Z1195LiqMVouMes != T003D2_A1195LiqMVouMes[0] ) || ( Z1188LiqMTASICod != T003D2_A1188LiqMTASICod[0] ) || ( StringUtil.StrCmp(Z1196LiqMVouNum, T003D2_A1196LiqMVouNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1192LiqMUsuCod, T003D2_A1192LiqMUsuCod[0]) != 0 ) || ( Z1193LiqMUsuFec != T003D2_A1193LiqMUsuFec[0] ) || ( Z1186LiqMPagReg != T003D2_A1186LiqMPagReg[0] ) || ( StringUtil.StrCmp(Z279LiqMTipCod, T003D2_A279LiqMTipCod[0]) != 0 ) || ( StringUtil.StrCmp(Z280LiqMComCod, T003D2_A280LiqMComCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z281LiqMPrvCod, T003D2_A281LiqMPrvCod[0]) != 0 ) || ( Z278LiqMTMovCod != T003D2_A278LiqMTMovCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1180LiqMFech ) != DateTimeUtil.ResetTime ( T003D2_A1180LiqMFech[0] ) )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMFech");
                  GXUtil.WriteLogRaw("Old: ",Z1180LiqMFech);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1180LiqMFech[0]);
               }
               if ( StringUtil.StrCmp(Z1179LiqMConcepto, T003D2_A1179LiqMConcepto[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMConcepto");
                  GXUtil.WriteLogRaw("Old: ",Z1179LiqMConcepto);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1179LiqMConcepto[0]);
               }
               if ( Z1181LiqMForCod != T003D2_A1181LiqMForCod[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMForCod");
                  GXUtil.WriteLogRaw("Old: ",Z1181LiqMForCod);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1181LiqMForCod[0]);
               }
               if ( Z1189LiqMTipCmb != T003D2_A1189LiqMTipCmb[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMTipCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1189LiqMTipCmb);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1189LiqMTipCmb[0]);
               }
               if ( Z1182LiqMImporte != T003D2_A1182LiqMImporte[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMImporte");
                  GXUtil.WriteLogRaw("Old: ",Z1182LiqMImporte);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1182LiqMImporte[0]);
               }
               if ( Z1185LiqMPago != T003D2_A1185LiqMPago[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMPago");
                  GXUtil.WriteLogRaw("Old: ",Z1185LiqMPago);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1185LiqMPago[0]);
               }
               if ( Z1194LiqMVouAno != T003D2_A1194LiqMVouAno[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1194LiqMVouAno);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1194LiqMVouAno[0]);
               }
               if ( Z1195LiqMVouMes != T003D2_A1195LiqMVouMes[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1195LiqMVouMes);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1195LiqMVouMes[0]);
               }
               if ( Z1188LiqMTASICod != T003D2_A1188LiqMTASICod[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z1188LiqMTASICod);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1188LiqMTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z1196LiqMVouNum, T003D2_A1196LiqMVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1196LiqMVouNum);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1196LiqMVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1192LiqMUsuCod, T003D2_A1192LiqMUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1192LiqMUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1192LiqMUsuCod[0]);
               }
               if ( Z1193LiqMUsuFec != T003D2_A1193LiqMUsuFec[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1193LiqMUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1193LiqMUsuFec[0]);
               }
               if ( Z1186LiqMPagReg != T003D2_A1186LiqMPagReg[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMPagReg");
                  GXUtil.WriteLogRaw("Old: ",Z1186LiqMPagReg);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A1186LiqMPagReg[0]);
               }
               if ( StringUtil.StrCmp(Z279LiqMTipCod, T003D2_A279LiqMTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z279LiqMTipCod);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A279LiqMTipCod[0]);
               }
               if ( StringUtil.StrCmp(Z280LiqMComCod, T003D2_A280LiqMComCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMComCod");
                  GXUtil.WriteLogRaw("Old: ",Z280LiqMComCod);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A280LiqMComCod[0]);
               }
               if ( StringUtil.StrCmp(Z281LiqMPrvCod, T003D2_A281LiqMPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z281LiqMPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A281LiqMPrvCod[0]);
               }
               if ( Z278LiqMTMovCod != T003D2_A278LiqMTMovCod[0] )
               {
                  GXUtil.WriteLog("cpliquidaciondet:[seudo value changed for attri]"+"LiqMTMovCod");
                  GXUtil.WriteLogRaw("Old: ",Z278LiqMTMovCod);
                  GXUtil.WriteLogRaw("Current: ",T003D2_A278LiqMTMovCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPLIQUIDACIONDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3D116( )
      {
         BeforeValidate3D116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3D116( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3D116( 0) ;
            CheckOptimisticConcurrency3D116( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3D116( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3D116( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003D16 */
                     pr_default.execute(14, new Object[] {A270LiqCod, A277LiqMItem, A1180LiqMFech, A1179LiqMConcepto, A1181LiqMForCod, A1189LiqMTipCmb, A1182LiqMImporte, A1185LiqMPago, A1194LiqMVouAno, A1195LiqMVouMes, A1188LiqMTASICod, A1196LiqMVouNum, A1192LiqMUsuCod, A1193LiqMUsuFec, A1186LiqMPagReg, A236LiqPrvCod, A279LiqMTipCod, A280LiqMComCod, A281LiqMPrvCod, A278LiqMTMovCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACIONDET");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption3D0( ) ;
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
               Load3D116( ) ;
            }
            EndLevel3D116( ) ;
         }
         CloseExtendedTableCursors3D116( ) ;
      }

      protected void Update3D116( )
      {
         BeforeValidate3D116( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3D116( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3D116( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3D116( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3D116( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003D17 */
                     pr_default.execute(15, new Object[] {A1180LiqMFech, A1179LiqMConcepto, A1181LiqMForCod, A1189LiqMTipCmb, A1182LiqMImporte, A1185LiqMPago, A1194LiqMVouAno, A1195LiqMVouMes, A1188LiqMTASICod, A1196LiqMVouNum, A1192LiqMUsuCod, A1193LiqMUsuFec, A1186LiqMPagReg, A279LiqMTipCod, A280LiqMComCod, A281LiqMPrvCod, A278LiqMTMovCod, A270LiqCod, A236LiqPrvCod, A277LiqMItem});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACIONDET");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPLIQUIDACIONDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3D116( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3D0( ) ;
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
            EndLevel3D116( ) ;
         }
         CloseExtendedTableCursors3D116( ) ;
      }

      protected void DeferredUpdate3D116( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3D116( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3D116( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3D116( ) ;
            AfterConfirm3D116( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3D116( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003D18 */
                  pr_default.execute(16, new Object[] {A270LiqCod, A236LiqPrvCod, A277LiqMItem});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CPLIQUIDACIONDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound116 == 0 )
                        {
                           InitAll3D116( ) ;
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
                        ResetCaption3D0( ) ;
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
         sMode116 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3D116( ) ;
         Gx_mode = sMode116;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3D116( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003D19 */
            pr_default.execute(17, new Object[] {A281LiqMPrvCod});
            A1187LiqMPrvDsc = T003D19_A1187LiqMPrvDsc[0];
            AssignAttri("", false, "A1187LiqMPrvDsc", A1187LiqMPrvDsc);
            pr_default.close(17);
            /* Using cursor T003D20 */
            pr_default.execute(18, new Object[] {A279LiqMTipCod, A280LiqMComCod, A281LiqMPrvCod});
            A1183LiqMMonCod = T003D20_A1183LiqMMonCod[0];
            AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrimStr( (decimal)(A1183LiqMMonCod), 6, 0));
            pr_default.close(18);
            /* Using cursor T003D21 */
            pr_default.execute(19, new Object[] {A278LiqMTMovCod});
            A1191LiqMTMovDsc = T003D21_A1191LiqMTMovDsc[0];
            AssignAttri("", false, "A1191LiqMTMovDsc", A1191LiqMTMovDsc);
            A1190LiqMTMovCueCod = T003D21_A1190LiqMTMovCueCod[0];
            AssignAttri("", false, "A1190LiqMTMovCueCod", A1190LiqMTMovCueCod);
            pr_default.close(19);
         }
      }

      protected void EndLevel3D116( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3D116( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(18);
            pr_default.close(19);
            pr_default.close(17);
            context.CommitDataStores("cpliquidaciondet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(18);
            pr_default.close(19);
            pr_default.close(17);
            context.RollbackDataStores("cpliquidaciondet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3D116( )
      {
         /* Using cursor T003D22 */
         pr_default.execute(20);
         RcdFound116 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound116 = 1;
            A270LiqCod = T003D22_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = T003D22_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A277LiqMItem = T003D22_A277LiqMItem[0];
            AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3D116( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound116 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound116 = 1;
            A270LiqCod = T003D22_A270LiqCod[0];
            AssignAttri("", false, "A270LiqCod", A270LiqCod);
            A236LiqPrvCod = T003D22_A236LiqPrvCod[0];
            AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
            A277LiqMItem = T003D22_A277LiqMItem[0];
            AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
         }
      }

      protected void ScanEnd3D116( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm3D116( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3D116( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3D116( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3D116( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3D116( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3D116( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3D116( )
      {
         edtLiqCod_Enabled = 0;
         AssignProp("", false, edtLiqCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqCod_Enabled), 5, 0), true);
         edtLiqPrvCod_Enabled = 0;
         AssignProp("", false, edtLiqPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqPrvCod_Enabled), 5, 0), true);
         edtLiqMItem_Enabled = 0;
         AssignProp("", false, edtLiqMItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMItem_Enabled), 5, 0), true);
         edtLiqMFech_Enabled = 0;
         AssignProp("", false, edtLiqMFech_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMFech_Enabled), 5, 0), true);
         edtLiqMConcepto_Enabled = 0;
         AssignProp("", false, edtLiqMConcepto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMConcepto_Enabled), 5, 0), true);
         edtLiqMPrvCod_Enabled = 0;
         AssignProp("", false, edtLiqMPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMPrvCod_Enabled), 5, 0), true);
         edtLiqMPrvDsc_Enabled = 0;
         AssignProp("", false, edtLiqMPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMPrvDsc_Enabled), 5, 0), true);
         edtLiqMTipCod_Enabled = 0;
         AssignProp("", false, edtLiqMTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMTipCod_Enabled), 5, 0), true);
         edtLiqMComCod_Enabled = 0;
         AssignProp("", false, edtLiqMComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMComCod_Enabled), 5, 0), true);
         edtLiqMForCod_Enabled = 0;
         AssignProp("", false, edtLiqMForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMForCod_Enabled), 5, 0), true);
         edtLiqMMonCod_Enabled = 0;
         AssignProp("", false, edtLiqMMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMMonCod_Enabled), 5, 0), true);
         edtLiqMTipCmb_Enabled = 0;
         AssignProp("", false, edtLiqMTipCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMTipCmb_Enabled), 5, 0), true);
         edtLiqMImporte_Enabled = 0;
         AssignProp("", false, edtLiqMImporte_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMImporte_Enabled), 5, 0), true);
         edtLiqMPago_Enabled = 0;
         AssignProp("", false, edtLiqMPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMPago_Enabled), 5, 0), true);
         edtLiqMVouAno_Enabled = 0;
         AssignProp("", false, edtLiqMVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMVouAno_Enabled), 5, 0), true);
         edtLiqMVouMes_Enabled = 0;
         AssignProp("", false, edtLiqMVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMVouMes_Enabled), 5, 0), true);
         edtLiqMTASICod_Enabled = 0;
         AssignProp("", false, edtLiqMTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMTASICod_Enabled), 5, 0), true);
         edtLiqMVouNum_Enabled = 0;
         AssignProp("", false, edtLiqMVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMVouNum_Enabled), 5, 0), true);
         edtLiqMTMovCod_Enabled = 0;
         AssignProp("", false, edtLiqMTMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMTMovCod_Enabled), 5, 0), true);
         edtLiqMTMovDsc_Enabled = 0;
         AssignProp("", false, edtLiqMTMovDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMTMovDsc_Enabled), 5, 0), true);
         edtLiqMUsuCod_Enabled = 0;
         AssignProp("", false, edtLiqMUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMUsuCod_Enabled), 5, 0), true);
         edtLiqMUsuFec_Enabled = 0;
         AssignProp("", false, edtLiqMUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMUsuFec_Enabled), 5, 0), true);
         edtLiqMPagReg_Enabled = 0;
         AssignProp("", false, edtLiqMPagReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMPagReg_Enabled), 5, 0), true);
         edtLiqMTMovCueCod_Enabled = 0;
         AssignProp("", false, edtLiqMTMovCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLiqMTMovCueCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3D116( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3D0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025937", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cpliquidaciondet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z277LiqMItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z277LiqMItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1180LiqMFech", context.localUtil.DToC( Z1180LiqMFech, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1179LiqMConcepto", Z1179LiqMConcepto);
         GxWebStd.gx_hidden_field( context, "Z1181LiqMForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1181LiqMForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1189LiqMTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1189LiqMTipCmb, 10, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1182LiqMImporte", StringUtil.LTrim( StringUtil.NToC( Z1182LiqMImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1185LiqMPago", StringUtil.LTrim( StringUtil.NToC( Z1185LiqMPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1194LiqMVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1194LiqMVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1195LiqMVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1195LiqMVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1188LiqMTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1188LiqMTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1196LiqMVouNum", StringUtil.RTrim( Z1196LiqMVouNum));
         GxWebStd.gx_hidden_field( context, "Z1192LiqMUsuCod", StringUtil.RTrim( Z1192LiqMUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1193LiqMUsuFec", context.localUtil.TToC( Z1193LiqMUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1186LiqMPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1186LiqMPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z279LiqMTipCod", StringUtil.RTrim( Z279LiqMTipCod));
         GxWebStd.gx_hidden_field( context, "Z280LiqMComCod", StringUtil.RTrim( Z280LiqMComCod));
         GxWebStd.gx_hidden_field( context, "Z281LiqMPrvCod", StringUtil.RTrim( Z281LiqMPrvCod));
         GxWebStd.gx_hidden_field( context, "Z278LiqMTMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z278LiqMTMovCod), 6, 0, ".", "")));
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
         return formatLink("cpliquidaciondet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPLIQUIDACIONDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Liquidación Detalle" ;
      }

      protected void InitializeNonKey3D116( )
      {
         A1180LiqMFech = DateTime.MinValue;
         AssignAttri("", false, "A1180LiqMFech", context.localUtil.Format(A1180LiqMFech, "99/99/99"));
         A1179LiqMConcepto = "";
         AssignAttri("", false, "A1179LiqMConcepto", A1179LiqMConcepto);
         A281LiqMPrvCod = "";
         AssignAttri("", false, "A281LiqMPrvCod", A281LiqMPrvCod);
         A1187LiqMPrvDsc = "";
         AssignAttri("", false, "A1187LiqMPrvDsc", A1187LiqMPrvDsc);
         A279LiqMTipCod = "";
         AssignAttri("", false, "A279LiqMTipCod", A279LiqMTipCod);
         A280LiqMComCod = "";
         AssignAttri("", false, "A280LiqMComCod", A280LiqMComCod);
         A1181LiqMForCod = 0;
         AssignAttri("", false, "A1181LiqMForCod", StringUtil.LTrimStr( (decimal)(A1181LiqMForCod), 6, 0));
         A1183LiqMMonCod = 0;
         AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrimStr( (decimal)(A1183LiqMMonCod), 6, 0));
         A1189LiqMTipCmb = 0;
         AssignAttri("", false, "A1189LiqMTipCmb", StringUtil.LTrimStr( A1189LiqMTipCmb, 10, 4));
         A1182LiqMImporte = 0;
         AssignAttri("", false, "A1182LiqMImporte", StringUtil.LTrimStr( A1182LiqMImporte, 15, 2));
         A1185LiqMPago = 0;
         AssignAttri("", false, "A1185LiqMPago", StringUtil.LTrimStr( A1185LiqMPago, 15, 2));
         A1194LiqMVouAno = 0;
         AssignAttri("", false, "A1194LiqMVouAno", StringUtil.LTrimStr( (decimal)(A1194LiqMVouAno), 4, 0));
         A1195LiqMVouMes = 0;
         AssignAttri("", false, "A1195LiqMVouMes", StringUtil.LTrimStr( (decimal)(A1195LiqMVouMes), 2, 0));
         A1188LiqMTASICod = 0;
         AssignAttri("", false, "A1188LiqMTASICod", StringUtil.LTrimStr( (decimal)(A1188LiqMTASICod), 6, 0));
         A1196LiqMVouNum = "";
         AssignAttri("", false, "A1196LiqMVouNum", A1196LiqMVouNum);
         A278LiqMTMovCod = 0;
         AssignAttri("", false, "A278LiqMTMovCod", StringUtil.LTrimStr( (decimal)(A278LiqMTMovCod), 6, 0));
         A1191LiqMTMovDsc = "";
         AssignAttri("", false, "A1191LiqMTMovDsc", A1191LiqMTMovDsc);
         A1192LiqMUsuCod = "";
         AssignAttri("", false, "A1192LiqMUsuCod", A1192LiqMUsuCod);
         A1193LiqMUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1193LiqMUsuFec", context.localUtil.TToC( A1193LiqMUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1186LiqMPagReg = 0;
         AssignAttri("", false, "A1186LiqMPagReg", StringUtil.LTrimStr( (decimal)(A1186LiqMPagReg), 10, 0));
         A1190LiqMTMovCueCod = "";
         AssignAttri("", false, "A1190LiqMTMovCueCod", A1190LiqMTMovCueCod);
         Z1180LiqMFech = DateTime.MinValue;
         Z1179LiqMConcepto = "";
         Z1181LiqMForCod = 0;
         Z1189LiqMTipCmb = 0;
         Z1182LiqMImporte = 0;
         Z1185LiqMPago = 0;
         Z1194LiqMVouAno = 0;
         Z1195LiqMVouMes = 0;
         Z1188LiqMTASICod = 0;
         Z1196LiqMVouNum = "";
         Z1192LiqMUsuCod = "";
         Z1193LiqMUsuFec = (DateTime)(DateTime.MinValue);
         Z1186LiqMPagReg = 0;
         Z279LiqMTipCod = "";
         Z280LiqMComCod = "";
         Z281LiqMPrvCod = "";
         Z278LiqMTMovCod = 0;
      }

      protected void InitAll3D116( )
      {
         A270LiqCod = "";
         AssignAttri("", false, "A270LiqCod", A270LiqCod);
         A236LiqPrvCod = "";
         AssignAttri("", false, "A236LiqPrvCod", A236LiqPrvCod);
         A277LiqMItem = 0;
         AssignAttri("", false, "A277LiqMItem", StringUtil.LTrimStr( (decimal)(A277LiqMItem), 6, 0));
         InitializeNonKey3D116( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025954", true, true);
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
         context.AddJavascriptSource("cpliquidaciondet.js", "?20228181025955", false, true);
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
         edtLiqMItem_Internalname = "LIQMITEM";
         edtLiqMFech_Internalname = "LIQMFECH";
         edtLiqMConcepto_Internalname = "LIQMCONCEPTO";
         edtLiqMPrvCod_Internalname = "LIQMPRVCOD";
         edtLiqMPrvDsc_Internalname = "LIQMPRVDSC";
         edtLiqMTipCod_Internalname = "LIQMTIPCOD";
         edtLiqMComCod_Internalname = "LIQMCOMCOD";
         edtLiqMForCod_Internalname = "LIQMFORCOD";
         edtLiqMMonCod_Internalname = "LIQMMONCOD";
         edtLiqMTipCmb_Internalname = "LIQMTIPCMB";
         edtLiqMImporte_Internalname = "LIQMIMPORTE";
         edtLiqMPago_Internalname = "LIQMPAGO";
         edtLiqMVouAno_Internalname = "LIQMVOUANO";
         edtLiqMVouMes_Internalname = "LIQMVOUMES";
         edtLiqMTASICod_Internalname = "LIQMTASICOD";
         edtLiqMVouNum_Internalname = "LIQMVOUNUM";
         edtLiqMTMovCod_Internalname = "LIQMTMOVCOD";
         edtLiqMTMovDsc_Internalname = "LIQMTMOVDSC";
         edtLiqMUsuCod_Internalname = "LIQMUSUCOD";
         edtLiqMUsuFec_Internalname = "LIQMUSUFEC";
         edtLiqMPagReg_Internalname = "LIQMPAGREG";
         edtLiqMTMovCueCod_Internalname = "LIQMTMOVCUECOD";
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
         Form.Caption = "Liquidación Detalle";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtLiqMTMovCueCod_Jsonclick = "";
         edtLiqMTMovCueCod_Enabled = 0;
         edtLiqMPagReg_Jsonclick = "";
         edtLiqMPagReg_Enabled = 1;
         edtLiqMUsuFec_Jsonclick = "";
         edtLiqMUsuFec_Enabled = 1;
         edtLiqMUsuCod_Jsonclick = "";
         edtLiqMUsuCod_Enabled = 1;
         edtLiqMTMovDsc_Jsonclick = "";
         edtLiqMTMovDsc_Enabled = 0;
         edtLiqMTMovCod_Jsonclick = "";
         edtLiqMTMovCod_Enabled = 1;
         edtLiqMVouNum_Jsonclick = "";
         edtLiqMVouNum_Enabled = 1;
         edtLiqMTASICod_Jsonclick = "";
         edtLiqMTASICod_Enabled = 1;
         edtLiqMVouMes_Jsonclick = "";
         edtLiqMVouMes_Enabled = 1;
         edtLiqMVouAno_Jsonclick = "";
         edtLiqMVouAno_Enabled = 1;
         edtLiqMPago_Jsonclick = "";
         edtLiqMPago_Enabled = 1;
         edtLiqMImporte_Jsonclick = "";
         edtLiqMImporte_Enabled = 1;
         edtLiqMTipCmb_Jsonclick = "";
         edtLiqMTipCmb_Enabled = 1;
         edtLiqMMonCod_Jsonclick = "";
         edtLiqMMonCod_Enabled = 0;
         edtLiqMForCod_Jsonclick = "";
         edtLiqMForCod_Enabled = 1;
         edtLiqMComCod_Jsonclick = "";
         edtLiqMComCod_Enabled = 1;
         edtLiqMTipCod_Jsonclick = "";
         edtLiqMTipCod_Enabled = 1;
         edtLiqMPrvDsc_Jsonclick = "";
         edtLiqMPrvDsc_Enabled = 0;
         edtLiqMPrvCod_Jsonclick = "";
         edtLiqMPrvCod_Enabled = 1;
         edtLiqMConcepto_Jsonclick = "";
         edtLiqMConcepto_Enabled = 1;
         edtLiqMFech_Jsonclick = "";
         edtLiqMFech_Enabled = 1;
         edtLiqMItem_Jsonclick = "";
         edtLiqMItem_Enabled = 1;
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
         /* Using cursor T003D23 */
         pr_default.execute(21, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(21);
         GX_FocusControl = edtLiqMFech_Internalname;
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
         /* Using cursor T003D23 */
         pr_default.execute(21, new Object[] {A236LiqPrvCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Agentes de Aduana'.", "ForeignKeyNotFound", 1, "LIQPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqPrvCod_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Liqmitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1180LiqMFech", context.localUtil.Format(A1180LiqMFech, "99/99/99"));
         AssignAttri("", false, "A1179LiqMConcepto", A1179LiqMConcepto);
         AssignAttri("", false, "A281LiqMPrvCod", StringUtil.RTrim( A281LiqMPrvCod));
         AssignAttri("", false, "A279LiqMTipCod", StringUtil.RTrim( A279LiqMTipCod));
         AssignAttri("", false, "A280LiqMComCod", StringUtil.RTrim( A280LiqMComCod));
         AssignAttri("", false, "A1181LiqMForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1181LiqMForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1189LiqMTipCmb", StringUtil.LTrim( StringUtil.NToC( A1189LiqMTipCmb, 10, 4, ".", "")));
         AssignAttri("", false, "A1182LiqMImporte", StringUtil.LTrim( StringUtil.NToC( A1182LiqMImporte, 15, 2, ".", "")));
         AssignAttri("", false, "A1185LiqMPago", StringUtil.LTrim( StringUtil.NToC( A1185LiqMPago, 15, 2, ".", "")));
         AssignAttri("", false, "A1194LiqMVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1194LiqMVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1195LiqMVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1195LiqMVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1188LiqMTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1188LiqMTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A1196LiqMVouNum", StringUtil.RTrim( A1196LiqMVouNum));
         AssignAttri("", false, "A278LiqMTMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A278LiqMTMovCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1192LiqMUsuCod", StringUtil.RTrim( A1192LiqMUsuCod));
         AssignAttri("", false, "A1193LiqMUsuFec", context.localUtil.TToC( A1193LiqMUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1186LiqMPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1186LiqMPagReg), 10, 0, ".", "")));
         AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1183LiqMMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1187LiqMPrvDsc", StringUtil.RTrim( A1187LiqMPrvDsc));
         AssignAttri("", false, "A1191LiqMTMovDsc", StringUtil.RTrim( A1191LiqMTMovDsc));
         AssignAttri("", false, "A1190LiqMTMovCueCod", StringUtil.RTrim( A1190LiqMTMovCueCod));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z270LiqCod", Z270LiqCod);
         GxWebStd.gx_hidden_field( context, "Z236LiqPrvCod", StringUtil.RTrim( Z236LiqPrvCod));
         GxWebStd.gx_hidden_field( context, "Z277LiqMItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z277LiqMItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1180LiqMFech", context.localUtil.Format(Z1180LiqMFech, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1179LiqMConcepto", Z1179LiqMConcepto);
         GxWebStd.gx_hidden_field( context, "Z281LiqMPrvCod", StringUtil.RTrim( Z281LiqMPrvCod));
         GxWebStd.gx_hidden_field( context, "Z279LiqMTipCod", StringUtil.RTrim( Z279LiqMTipCod));
         GxWebStd.gx_hidden_field( context, "Z280LiqMComCod", StringUtil.RTrim( Z280LiqMComCod));
         GxWebStd.gx_hidden_field( context, "Z1181LiqMForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1181LiqMForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1189LiqMTipCmb", StringUtil.LTrim( StringUtil.NToC( Z1189LiqMTipCmb, 10, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1182LiqMImporte", StringUtil.LTrim( StringUtil.NToC( Z1182LiqMImporte, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1185LiqMPago", StringUtil.LTrim( StringUtil.NToC( Z1185LiqMPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1194LiqMVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1194LiqMVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1195LiqMVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1195LiqMVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1188LiqMTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1188LiqMTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1196LiqMVouNum", StringUtil.RTrim( Z1196LiqMVouNum));
         GxWebStd.gx_hidden_field( context, "Z278LiqMTMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z278LiqMTMovCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1192LiqMUsuCod", StringUtil.RTrim( Z1192LiqMUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1193LiqMUsuFec", context.localUtil.TToC( Z1193LiqMUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1186LiqMPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1186LiqMPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1183LiqMMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1183LiqMMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1187LiqMPrvDsc", StringUtil.RTrim( Z1187LiqMPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1191LiqMTMovDsc", StringUtil.RTrim( Z1191LiqMTMovDsc));
         GxWebStd.gx_hidden_field( context, "Z1190LiqMTMovCueCod", StringUtil.RTrim( Z1190LiqMTMovCueCod));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Liqmprvcod( )
      {
         /* Using cursor T003D19 */
         pr_default.execute(17, new Object[] {A281LiqMPrvCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "LIQMPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMPrvCod_Internalname;
         }
         A1187LiqMPrvDsc = T003D19_A1187LiqMPrvDsc[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1187LiqMPrvDsc", StringUtil.RTrim( A1187LiqMPrvDsc));
      }

      public void Valid_Liqmcomcod( )
      {
         /* Using cursor T003D20 */
         pr_default.execute(18, new Object[] {A279LiqMTipCod, A280LiqMComCod, A281LiqMPrvCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Sub Movimiento Liquidacion Proveedor'.", "ForeignKeyNotFound", 1, "LIQMPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMTipCod_Internalname;
         }
         A1183LiqMMonCod = T003D20_A1183LiqMMonCod[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1183LiqMMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1183LiqMMonCod), 6, 0, ".", "")));
      }

      public void Valid_Liqmtmovcod( )
      {
         /* Using cursor T003D21 */
         pr_default.execute(19, new Object[] {A278LiqMTMovCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Movimiento'.", "ForeignKeyNotFound", 1, "LIQMTMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtLiqMTMovCod_Internalname;
         }
         A1191LiqMTMovDsc = T003D21_A1191LiqMTMovDsc[0];
         A1190LiqMTMovCueCod = T003D21_A1190LiqMTMovCueCod[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1191LiqMTMovDsc", StringUtil.RTrim( A1191LiqMTMovDsc));
         AssignAttri("", false, "A1190LiqMTMovCueCod", StringUtil.RTrim( A1190LiqMTMovCueCod));
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
         setEventMetadata("VALID_LIQPRVCOD","{handler:'Valid_Liqprvcod',iparms:[{av:'A236LiqPrvCod',fld:'LIQPRVCOD',pic:''}]");
         setEventMetadata("VALID_LIQPRVCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQMITEM","{handler:'Valid_Liqmitem',iparms:[{av:'A270LiqCod',fld:'LIQCOD',pic:''},{av:'A236LiqPrvCod',fld:'LIQPRVCOD',pic:''},{av:'A277LiqMItem',fld:'LIQMITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_LIQMITEM",",oparms:[{av:'A1180LiqMFech',fld:'LIQMFECH',pic:''},{av:'A1179LiqMConcepto',fld:'LIQMCONCEPTO',pic:''},{av:'A281LiqMPrvCod',fld:'LIQMPRVCOD',pic:'@!'},{av:'A279LiqMTipCod',fld:'LIQMTIPCOD',pic:''},{av:'A280LiqMComCod',fld:'LIQMCOMCOD',pic:''},{av:'A1181LiqMForCod',fld:'LIQMFORCOD',pic:'ZZZZZ9'},{av:'A1189LiqMTipCmb',fld:'LIQMTIPCMB',pic:'ZZZZ9.9999'},{av:'A1182LiqMImporte',fld:'LIQMIMPORTE',pic:'ZZZZZZZZZZZ9.99'},{av:'A1185LiqMPago',fld:'LIQMPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1194LiqMVouAno',fld:'LIQMVOUANO',pic:'ZZZ9'},{av:'A1195LiqMVouMes',fld:'LIQMVOUMES',pic:'Z9'},{av:'A1188LiqMTASICod',fld:'LIQMTASICOD',pic:'ZZZZZ9'},{av:'A1196LiqMVouNum',fld:'LIQMVOUNUM',pic:''},{av:'A278LiqMTMovCod',fld:'LIQMTMOVCOD',pic:'ZZZZZ9'},{av:'A1192LiqMUsuCod',fld:'LIQMUSUCOD',pic:''},{av:'A1193LiqMUsuFec',fld:'LIQMUSUFEC',pic:'99/99/99 99:99'},{av:'A1186LiqMPagReg',fld:'LIQMPAGREG',pic:'ZZZZZZZZZ9'},{av:'A1183LiqMMonCod',fld:'LIQMMONCOD',pic:'ZZZZZ9'},{av:'A1187LiqMPrvDsc',fld:'LIQMPRVDSC',pic:''},{av:'A1191LiqMTMovDsc',fld:'LIQMTMOVDSC',pic:''},{av:'A1190LiqMTMovCueCod',fld:'LIQMTMOVCUECOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z270LiqCod'},{av:'Z236LiqPrvCod'},{av:'Z277LiqMItem'},{av:'Z1180LiqMFech'},{av:'Z1179LiqMConcepto'},{av:'Z281LiqMPrvCod'},{av:'Z279LiqMTipCod'},{av:'Z280LiqMComCod'},{av:'Z1181LiqMForCod'},{av:'Z1189LiqMTipCmb'},{av:'Z1182LiqMImporte'},{av:'Z1185LiqMPago'},{av:'Z1194LiqMVouAno'},{av:'Z1195LiqMVouMes'},{av:'Z1188LiqMTASICod'},{av:'Z1196LiqMVouNum'},{av:'Z278LiqMTMovCod'},{av:'Z1192LiqMUsuCod'},{av:'Z1193LiqMUsuFec'},{av:'Z1186LiqMPagReg'},{av:'Z1183LiqMMonCod'},{av:'Z1187LiqMPrvDsc'},{av:'Z1191LiqMTMovDsc'},{av:'Z1190LiqMTMovCueCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_LIQMFECH","{handler:'Valid_Liqmfech',iparms:[]");
         setEventMetadata("VALID_LIQMFECH",",oparms:[]}");
         setEventMetadata("VALID_LIQMPRVCOD","{handler:'Valid_Liqmprvcod',iparms:[{av:'A281LiqMPrvCod',fld:'LIQMPRVCOD',pic:'@!'},{av:'A1187LiqMPrvDsc',fld:'LIQMPRVDSC',pic:''}]");
         setEventMetadata("VALID_LIQMPRVCOD",",oparms:[{av:'A1187LiqMPrvDsc',fld:'LIQMPRVDSC',pic:''}]}");
         setEventMetadata("VALID_LIQMTIPCOD","{handler:'Valid_Liqmtipcod',iparms:[]");
         setEventMetadata("VALID_LIQMTIPCOD",",oparms:[]}");
         setEventMetadata("VALID_LIQMCOMCOD","{handler:'Valid_Liqmcomcod',iparms:[{av:'A279LiqMTipCod',fld:'LIQMTIPCOD',pic:''},{av:'A280LiqMComCod',fld:'LIQMCOMCOD',pic:''},{av:'A281LiqMPrvCod',fld:'LIQMPRVCOD',pic:'@!'},{av:'A1183LiqMMonCod',fld:'LIQMMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_LIQMCOMCOD",",oparms:[{av:'A1183LiqMMonCod',fld:'LIQMMONCOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_LIQMTMOVCOD","{handler:'Valid_Liqmtmovcod',iparms:[{av:'A278LiqMTMovCod',fld:'LIQMTMOVCOD',pic:'ZZZZZ9'},{av:'A1191LiqMTMovDsc',fld:'LIQMTMOVDSC',pic:''},{av:'A1190LiqMTMovCueCod',fld:'LIQMTMOVCUECOD',pic:''}]");
         setEventMetadata("VALID_LIQMTMOVCOD",",oparms:[{av:'A1191LiqMTMovDsc',fld:'LIQMTMOVDSC',pic:''},{av:'A1190LiqMTMovCueCod',fld:'LIQMTMOVCUECOD',pic:''}]}");
         setEventMetadata("VALID_LIQMUSUFEC","{handler:'Valid_Liqmusufec',iparms:[]");
         setEventMetadata("VALID_LIQMUSUFEC",",oparms:[]}");
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
         pr_default.close(18);
         pr_default.close(19);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z270LiqCod = "";
         Z236LiqPrvCod = "";
         Z1180LiqMFech = DateTime.MinValue;
         Z1179LiqMConcepto = "";
         Z1196LiqMVouNum = "";
         Z1192LiqMUsuCod = "";
         Z1193LiqMUsuFec = (DateTime)(DateTime.MinValue);
         Z279LiqMTipCod = "";
         Z280LiqMComCod = "";
         Z281LiqMPrvCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A236LiqPrvCod = "";
         A279LiqMTipCod = "";
         A280LiqMComCod = "";
         A281LiqMPrvCod = "";
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
         A270LiqCod = "";
         A1180LiqMFech = DateTime.MinValue;
         A1179LiqMConcepto = "";
         A1187LiqMPrvDsc = "";
         A1196LiqMVouNum = "";
         A1191LiqMTMovDsc = "";
         A1192LiqMUsuCod = "";
         A1193LiqMUsuFec = (DateTime)(DateTime.MinValue);
         A1190LiqMTMovCueCod = "";
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
         Z1187LiqMPrvDsc = "";
         Z1191LiqMTMovDsc = "";
         Z1190LiqMTMovCueCod = "";
         T003D8_A270LiqCod = new string[] {""} ;
         T003D8_A277LiqMItem = new int[1] ;
         T003D8_A1180LiqMFech = new DateTime[] {DateTime.MinValue} ;
         T003D8_A1179LiqMConcepto = new string[] {""} ;
         T003D8_A1187LiqMPrvDsc = new string[] {""} ;
         T003D8_A1181LiqMForCod = new int[1] ;
         T003D8_A1189LiqMTipCmb = new decimal[1] ;
         T003D8_A1182LiqMImporte = new decimal[1] ;
         T003D8_A1185LiqMPago = new decimal[1] ;
         T003D8_A1194LiqMVouAno = new short[1] ;
         T003D8_A1195LiqMVouMes = new short[1] ;
         T003D8_A1188LiqMTASICod = new int[1] ;
         T003D8_A1196LiqMVouNum = new string[] {""} ;
         T003D8_A1191LiqMTMovDsc = new string[] {""} ;
         T003D8_A1192LiqMUsuCod = new string[] {""} ;
         T003D8_A1193LiqMUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003D8_A1186LiqMPagReg = new long[1] ;
         T003D8_A236LiqPrvCod = new string[] {""} ;
         T003D8_A279LiqMTipCod = new string[] {""} ;
         T003D8_A280LiqMComCod = new string[] {""} ;
         T003D8_A281LiqMPrvCod = new string[] {""} ;
         T003D8_A278LiqMTMovCod = new int[1] ;
         T003D8_A1183LiqMMonCod = new int[1] ;
         T003D8_A1190LiqMTMovCueCod = new string[] {""} ;
         T003D4_A236LiqPrvCod = new string[] {""} ;
         T003D5_A1183LiqMMonCod = new int[1] ;
         T003D7_A1187LiqMPrvDsc = new string[] {""} ;
         T003D6_A1191LiqMTMovDsc = new string[] {""} ;
         T003D6_A1190LiqMTMovCueCod = new string[] {""} ;
         T003D9_A236LiqPrvCod = new string[] {""} ;
         T003D10_A1183LiqMMonCod = new int[1] ;
         T003D11_A1187LiqMPrvDsc = new string[] {""} ;
         T003D12_A1191LiqMTMovDsc = new string[] {""} ;
         T003D12_A1190LiqMTMovCueCod = new string[] {""} ;
         T003D13_A270LiqCod = new string[] {""} ;
         T003D13_A236LiqPrvCod = new string[] {""} ;
         T003D13_A277LiqMItem = new int[1] ;
         T003D3_A270LiqCod = new string[] {""} ;
         T003D3_A277LiqMItem = new int[1] ;
         T003D3_A1180LiqMFech = new DateTime[] {DateTime.MinValue} ;
         T003D3_A1179LiqMConcepto = new string[] {""} ;
         T003D3_A1181LiqMForCod = new int[1] ;
         T003D3_A1189LiqMTipCmb = new decimal[1] ;
         T003D3_A1182LiqMImporte = new decimal[1] ;
         T003D3_A1185LiqMPago = new decimal[1] ;
         T003D3_A1194LiqMVouAno = new short[1] ;
         T003D3_A1195LiqMVouMes = new short[1] ;
         T003D3_A1188LiqMTASICod = new int[1] ;
         T003D3_A1196LiqMVouNum = new string[] {""} ;
         T003D3_A1192LiqMUsuCod = new string[] {""} ;
         T003D3_A1193LiqMUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003D3_A1186LiqMPagReg = new long[1] ;
         T003D3_A236LiqPrvCod = new string[] {""} ;
         T003D3_A279LiqMTipCod = new string[] {""} ;
         T003D3_A280LiqMComCod = new string[] {""} ;
         T003D3_A281LiqMPrvCod = new string[] {""} ;
         T003D3_A278LiqMTMovCod = new int[1] ;
         sMode116 = "";
         T003D14_A270LiqCod = new string[] {""} ;
         T003D14_A236LiqPrvCod = new string[] {""} ;
         T003D14_A277LiqMItem = new int[1] ;
         T003D15_A270LiqCod = new string[] {""} ;
         T003D15_A236LiqPrvCod = new string[] {""} ;
         T003D15_A277LiqMItem = new int[1] ;
         T003D2_A270LiqCod = new string[] {""} ;
         T003D2_A277LiqMItem = new int[1] ;
         T003D2_A1180LiqMFech = new DateTime[] {DateTime.MinValue} ;
         T003D2_A1179LiqMConcepto = new string[] {""} ;
         T003D2_A1181LiqMForCod = new int[1] ;
         T003D2_A1189LiqMTipCmb = new decimal[1] ;
         T003D2_A1182LiqMImporte = new decimal[1] ;
         T003D2_A1185LiqMPago = new decimal[1] ;
         T003D2_A1194LiqMVouAno = new short[1] ;
         T003D2_A1195LiqMVouMes = new short[1] ;
         T003D2_A1188LiqMTASICod = new int[1] ;
         T003D2_A1196LiqMVouNum = new string[] {""} ;
         T003D2_A1192LiqMUsuCod = new string[] {""} ;
         T003D2_A1193LiqMUsuFec = new DateTime[] {DateTime.MinValue} ;
         T003D2_A1186LiqMPagReg = new long[1] ;
         T003D2_A236LiqPrvCod = new string[] {""} ;
         T003D2_A279LiqMTipCod = new string[] {""} ;
         T003D2_A280LiqMComCod = new string[] {""} ;
         T003D2_A281LiqMPrvCod = new string[] {""} ;
         T003D2_A278LiqMTMovCod = new int[1] ;
         T003D19_A1187LiqMPrvDsc = new string[] {""} ;
         T003D20_A1183LiqMMonCod = new int[1] ;
         T003D21_A1191LiqMTMovDsc = new string[] {""} ;
         T003D21_A1190LiqMTMovCueCod = new string[] {""} ;
         T003D22_A270LiqCod = new string[] {""} ;
         T003D22_A236LiqPrvCod = new string[] {""} ;
         T003D22_A277LiqMItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003D23_A236LiqPrvCod = new string[] {""} ;
         ZZ270LiqCod = "";
         ZZ236LiqPrvCod = "";
         ZZ1180LiqMFech = DateTime.MinValue;
         ZZ1179LiqMConcepto = "";
         ZZ281LiqMPrvCod = "";
         ZZ279LiqMTipCod = "";
         ZZ280LiqMComCod = "";
         ZZ1196LiqMVouNum = "";
         ZZ1192LiqMUsuCod = "";
         ZZ1193LiqMUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1187LiqMPrvDsc = "";
         ZZ1191LiqMTMovDsc = "";
         ZZ1190LiqMTMovCueCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpliquidaciondet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpliquidaciondet__default(),
            new Object[][] {
                new Object[] {
               T003D2_A270LiqCod, T003D2_A277LiqMItem, T003D2_A1180LiqMFech, T003D2_A1179LiqMConcepto, T003D2_A1181LiqMForCod, T003D2_A1189LiqMTipCmb, T003D2_A1182LiqMImporte, T003D2_A1185LiqMPago, T003D2_A1194LiqMVouAno, T003D2_A1195LiqMVouMes,
               T003D2_A1188LiqMTASICod, T003D2_A1196LiqMVouNum, T003D2_A1192LiqMUsuCod, T003D2_A1193LiqMUsuFec, T003D2_A1186LiqMPagReg, T003D2_A236LiqPrvCod, T003D2_A279LiqMTipCod, T003D2_A280LiqMComCod, T003D2_A281LiqMPrvCod, T003D2_A278LiqMTMovCod
               }
               , new Object[] {
               T003D3_A270LiqCod, T003D3_A277LiqMItem, T003D3_A1180LiqMFech, T003D3_A1179LiqMConcepto, T003D3_A1181LiqMForCod, T003D3_A1189LiqMTipCmb, T003D3_A1182LiqMImporte, T003D3_A1185LiqMPago, T003D3_A1194LiqMVouAno, T003D3_A1195LiqMVouMes,
               T003D3_A1188LiqMTASICod, T003D3_A1196LiqMVouNum, T003D3_A1192LiqMUsuCod, T003D3_A1193LiqMUsuFec, T003D3_A1186LiqMPagReg, T003D3_A236LiqPrvCod, T003D3_A279LiqMTipCod, T003D3_A280LiqMComCod, T003D3_A281LiqMPrvCod, T003D3_A278LiqMTMovCod
               }
               , new Object[] {
               T003D4_A236LiqPrvCod
               }
               , new Object[] {
               T003D5_A1183LiqMMonCod
               }
               , new Object[] {
               T003D6_A1191LiqMTMovDsc, T003D6_A1190LiqMTMovCueCod
               }
               , new Object[] {
               T003D7_A1187LiqMPrvDsc
               }
               , new Object[] {
               T003D8_A270LiqCod, T003D8_A277LiqMItem, T003D8_A1180LiqMFech, T003D8_A1179LiqMConcepto, T003D8_A1187LiqMPrvDsc, T003D8_A1181LiqMForCod, T003D8_A1189LiqMTipCmb, T003D8_A1182LiqMImporte, T003D8_A1185LiqMPago, T003D8_A1194LiqMVouAno,
               T003D8_A1195LiqMVouMes, T003D8_A1188LiqMTASICod, T003D8_A1196LiqMVouNum, T003D8_A1191LiqMTMovDsc, T003D8_A1192LiqMUsuCod, T003D8_A1193LiqMUsuFec, T003D8_A1186LiqMPagReg, T003D8_A236LiqPrvCod, T003D8_A279LiqMTipCod, T003D8_A280LiqMComCod,
               T003D8_A281LiqMPrvCod, T003D8_A278LiqMTMovCod, T003D8_A1183LiqMMonCod, T003D8_A1190LiqMTMovCueCod
               }
               , new Object[] {
               T003D9_A236LiqPrvCod
               }
               , new Object[] {
               T003D10_A1183LiqMMonCod
               }
               , new Object[] {
               T003D11_A1187LiqMPrvDsc
               }
               , new Object[] {
               T003D12_A1191LiqMTMovDsc, T003D12_A1190LiqMTMovCueCod
               }
               , new Object[] {
               T003D13_A270LiqCod, T003D13_A236LiqPrvCod, T003D13_A277LiqMItem
               }
               , new Object[] {
               T003D14_A270LiqCod, T003D14_A236LiqPrvCod, T003D14_A277LiqMItem
               }
               , new Object[] {
               T003D15_A270LiqCod, T003D15_A236LiqPrvCod, T003D15_A277LiqMItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003D19_A1187LiqMPrvDsc
               }
               , new Object[] {
               T003D20_A1183LiqMMonCod
               }
               , new Object[] {
               T003D21_A1191LiqMTMovDsc, T003D21_A1190LiqMTMovCueCod
               }
               , new Object[] {
               T003D22_A270LiqCod, T003D22_A236LiqPrvCod, T003D22_A277LiqMItem
               }
               , new Object[] {
               T003D23_A236LiqPrvCod
               }
            }
         );
      }

      private short Z1194LiqMVouAno ;
      private short Z1195LiqMVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1194LiqMVouAno ;
      private short A1195LiqMVouMes ;
      private short GX_JID ;
      private short RcdFound116 ;
      private short nIsDirty_116 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1194LiqMVouAno ;
      private short ZZ1195LiqMVouMes ;
      private int Z277LiqMItem ;
      private int Z1181LiqMForCod ;
      private int Z1188LiqMTASICod ;
      private int Z278LiqMTMovCod ;
      private int A278LiqMTMovCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtLiqCod_Enabled ;
      private int edtLiqPrvCod_Enabled ;
      private int A277LiqMItem ;
      private int edtLiqMItem_Enabled ;
      private int edtLiqMFech_Enabled ;
      private int edtLiqMConcepto_Enabled ;
      private int edtLiqMPrvCod_Enabled ;
      private int edtLiqMPrvDsc_Enabled ;
      private int edtLiqMTipCod_Enabled ;
      private int edtLiqMComCod_Enabled ;
      private int A1181LiqMForCod ;
      private int edtLiqMForCod_Enabled ;
      private int A1183LiqMMonCod ;
      private int edtLiqMMonCod_Enabled ;
      private int edtLiqMTipCmb_Enabled ;
      private int edtLiqMImporte_Enabled ;
      private int edtLiqMPago_Enabled ;
      private int edtLiqMVouAno_Enabled ;
      private int edtLiqMVouMes_Enabled ;
      private int A1188LiqMTASICod ;
      private int edtLiqMTASICod_Enabled ;
      private int edtLiqMVouNum_Enabled ;
      private int edtLiqMTMovCod_Enabled ;
      private int edtLiqMTMovDsc_Enabled ;
      private int edtLiqMUsuCod_Enabled ;
      private int edtLiqMUsuFec_Enabled ;
      private int edtLiqMPagReg_Enabled ;
      private int edtLiqMTMovCueCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z1183LiqMMonCod ;
      private int idxLst ;
      private int ZZ277LiqMItem ;
      private int ZZ1181LiqMForCod ;
      private int ZZ1188LiqMTASICod ;
      private int ZZ278LiqMTMovCod ;
      private int ZZ1183LiqMMonCod ;
      private long Z1186LiqMPagReg ;
      private long A1186LiqMPagReg ;
      private long ZZ1186LiqMPagReg ;
      private decimal Z1189LiqMTipCmb ;
      private decimal Z1182LiqMImporte ;
      private decimal Z1185LiqMPago ;
      private decimal A1189LiqMTipCmb ;
      private decimal A1182LiqMImporte ;
      private decimal A1185LiqMPago ;
      private decimal ZZ1189LiqMTipCmb ;
      private decimal ZZ1182LiqMImporte ;
      private decimal ZZ1185LiqMPago ;
      private string sPrefix ;
      private string Z236LiqPrvCod ;
      private string Z1196LiqMVouNum ;
      private string Z1192LiqMUsuCod ;
      private string Z279LiqMTipCod ;
      private string Z280LiqMComCod ;
      private string Z281LiqMPrvCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A236LiqPrvCod ;
      private string A279LiqMTipCod ;
      private string A280LiqMComCod ;
      private string A281LiqMPrvCod ;
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
      private string edtLiqMItem_Internalname ;
      private string edtLiqMItem_Jsonclick ;
      private string edtLiqMFech_Internalname ;
      private string edtLiqMFech_Jsonclick ;
      private string edtLiqMConcepto_Internalname ;
      private string edtLiqMConcepto_Jsonclick ;
      private string edtLiqMPrvCod_Internalname ;
      private string edtLiqMPrvCod_Jsonclick ;
      private string edtLiqMPrvDsc_Internalname ;
      private string A1187LiqMPrvDsc ;
      private string edtLiqMPrvDsc_Jsonclick ;
      private string edtLiqMTipCod_Internalname ;
      private string edtLiqMTipCod_Jsonclick ;
      private string edtLiqMComCod_Internalname ;
      private string edtLiqMComCod_Jsonclick ;
      private string edtLiqMForCod_Internalname ;
      private string edtLiqMForCod_Jsonclick ;
      private string edtLiqMMonCod_Internalname ;
      private string edtLiqMMonCod_Jsonclick ;
      private string edtLiqMTipCmb_Internalname ;
      private string edtLiqMTipCmb_Jsonclick ;
      private string edtLiqMImporte_Internalname ;
      private string edtLiqMImporte_Jsonclick ;
      private string edtLiqMPago_Internalname ;
      private string edtLiqMPago_Jsonclick ;
      private string edtLiqMVouAno_Internalname ;
      private string edtLiqMVouAno_Jsonclick ;
      private string edtLiqMVouMes_Internalname ;
      private string edtLiqMVouMes_Jsonclick ;
      private string edtLiqMTASICod_Internalname ;
      private string edtLiqMTASICod_Jsonclick ;
      private string edtLiqMVouNum_Internalname ;
      private string A1196LiqMVouNum ;
      private string edtLiqMVouNum_Jsonclick ;
      private string edtLiqMTMovCod_Internalname ;
      private string edtLiqMTMovCod_Jsonclick ;
      private string edtLiqMTMovDsc_Internalname ;
      private string A1191LiqMTMovDsc ;
      private string edtLiqMTMovDsc_Jsonclick ;
      private string edtLiqMUsuCod_Internalname ;
      private string A1192LiqMUsuCod ;
      private string edtLiqMUsuCod_Jsonclick ;
      private string edtLiqMUsuFec_Internalname ;
      private string edtLiqMUsuFec_Jsonclick ;
      private string edtLiqMPagReg_Internalname ;
      private string edtLiqMPagReg_Jsonclick ;
      private string edtLiqMTMovCueCod_Internalname ;
      private string A1190LiqMTMovCueCod ;
      private string edtLiqMTMovCueCod_Jsonclick ;
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
      private string Z1187LiqMPrvDsc ;
      private string Z1191LiqMTMovDsc ;
      private string Z1190LiqMTMovCueCod ;
      private string sMode116 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ236LiqPrvCod ;
      private string ZZ281LiqMPrvCod ;
      private string ZZ279LiqMTipCod ;
      private string ZZ280LiqMComCod ;
      private string ZZ1196LiqMVouNum ;
      private string ZZ1192LiqMUsuCod ;
      private string ZZ1187LiqMPrvDsc ;
      private string ZZ1191LiqMTMovDsc ;
      private string ZZ1190LiqMTMovCueCod ;
      private DateTime Z1193LiqMUsuFec ;
      private DateTime A1193LiqMUsuFec ;
      private DateTime ZZ1193LiqMUsuFec ;
      private DateTime Z1180LiqMFech ;
      private DateTime A1180LiqMFech ;
      private DateTime ZZ1180LiqMFech ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z270LiqCod ;
      private string Z1179LiqMConcepto ;
      private string A270LiqCod ;
      private string A1179LiqMConcepto ;
      private string ZZ270LiqCod ;
      private string ZZ1179LiqMConcepto ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003D8_A270LiqCod ;
      private int[] T003D8_A277LiqMItem ;
      private DateTime[] T003D8_A1180LiqMFech ;
      private string[] T003D8_A1179LiqMConcepto ;
      private string[] T003D8_A1187LiqMPrvDsc ;
      private int[] T003D8_A1181LiqMForCod ;
      private decimal[] T003D8_A1189LiqMTipCmb ;
      private decimal[] T003D8_A1182LiqMImporte ;
      private decimal[] T003D8_A1185LiqMPago ;
      private short[] T003D8_A1194LiqMVouAno ;
      private short[] T003D8_A1195LiqMVouMes ;
      private int[] T003D8_A1188LiqMTASICod ;
      private string[] T003D8_A1196LiqMVouNum ;
      private string[] T003D8_A1191LiqMTMovDsc ;
      private string[] T003D8_A1192LiqMUsuCod ;
      private DateTime[] T003D8_A1193LiqMUsuFec ;
      private long[] T003D8_A1186LiqMPagReg ;
      private string[] T003D8_A236LiqPrvCod ;
      private string[] T003D8_A279LiqMTipCod ;
      private string[] T003D8_A280LiqMComCod ;
      private string[] T003D8_A281LiqMPrvCod ;
      private int[] T003D8_A278LiqMTMovCod ;
      private int[] T003D8_A1183LiqMMonCod ;
      private string[] T003D8_A1190LiqMTMovCueCod ;
      private string[] T003D4_A236LiqPrvCod ;
      private int[] T003D5_A1183LiqMMonCod ;
      private string[] T003D7_A1187LiqMPrvDsc ;
      private string[] T003D6_A1191LiqMTMovDsc ;
      private string[] T003D6_A1190LiqMTMovCueCod ;
      private string[] T003D9_A236LiqPrvCod ;
      private int[] T003D10_A1183LiqMMonCod ;
      private string[] T003D11_A1187LiqMPrvDsc ;
      private string[] T003D12_A1191LiqMTMovDsc ;
      private string[] T003D12_A1190LiqMTMovCueCod ;
      private string[] T003D13_A270LiqCod ;
      private string[] T003D13_A236LiqPrvCod ;
      private int[] T003D13_A277LiqMItem ;
      private string[] T003D3_A270LiqCod ;
      private int[] T003D3_A277LiqMItem ;
      private DateTime[] T003D3_A1180LiqMFech ;
      private string[] T003D3_A1179LiqMConcepto ;
      private int[] T003D3_A1181LiqMForCod ;
      private decimal[] T003D3_A1189LiqMTipCmb ;
      private decimal[] T003D3_A1182LiqMImporte ;
      private decimal[] T003D3_A1185LiqMPago ;
      private short[] T003D3_A1194LiqMVouAno ;
      private short[] T003D3_A1195LiqMVouMes ;
      private int[] T003D3_A1188LiqMTASICod ;
      private string[] T003D3_A1196LiqMVouNum ;
      private string[] T003D3_A1192LiqMUsuCod ;
      private DateTime[] T003D3_A1193LiqMUsuFec ;
      private long[] T003D3_A1186LiqMPagReg ;
      private string[] T003D3_A236LiqPrvCod ;
      private string[] T003D3_A279LiqMTipCod ;
      private string[] T003D3_A280LiqMComCod ;
      private string[] T003D3_A281LiqMPrvCod ;
      private int[] T003D3_A278LiqMTMovCod ;
      private string[] T003D14_A270LiqCod ;
      private string[] T003D14_A236LiqPrvCod ;
      private int[] T003D14_A277LiqMItem ;
      private string[] T003D15_A270LiqCod ;
      private string[] T003D15_A236LiqPrvCod ;
      private int[] T003D15_A277LiqMItem ;
      private string[] T003D2_A270LiqCod ;
      private int[] T003D2_A277LiqMItem ;
      private DateTime[] T003D2_A1180LiqMFech ;
      private string[] T003D2_A1179LiqMConcepto ;
      private int[] T003D2_A1181LiqMForCod ;
      private decimal[] T003D2_A1189LiqMTipCmb ;
      private decimal[] T003D2_A1182LiqMImporte ;
      private decimal[] T003D2_A1185LiqMPago ;
      private short[] T003D2_A1194LiqMVouAno ;
      private short[] T003D2_A1195LiqMVouMes ;
      private int[] T003D2_A1188LiqMTASICod ;
      private string[] T003D2_A1196LiqMVouNum ;
      private string[] T003D2_A1192LiqMUsuCod ;
      private DateTime[] T003D2_A1193LiqMUsuFec ;
      private long[] T003D2_A1186LiqMPagReg ;
      private string[] T003D2_A236LiqPrvCod ;
      private string[] T003D2_A279LiqMTipCod ;
      private string[] T003D2_A280LiqMComCod ;
      private string[] T003D2_A281LiqMPrvCod ;
      private int[] T003D2_A278LiqMTMovCod ;
      private string[] T003D19_A1187LiqMPrvDsc ;
      private int[] T003D20_A1183LiqMMonCod ;
      private string[] T003D21_A1191LiqMTMovDsc ;
      private string[] T003D21_A1190LiqMTMovCueCod ;
      private string[] T003D22_A270LiqCod ;
      private string[] T003D22_A236LiqPrvCod ;
      private int[] T003D22_A277LiqMItem ;
      private string[] T003D23_A236LiqPrvCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpliquidaciondet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpliquidaciondet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003D8;
        prmT003D8 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D4;
        prmT003D4 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D5;
        prmT003D5 = new Object[] {
        new ParDef("@LiqMTipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqMComCod",GXType.NChar,15,0) ,
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D7;
        prmT003D7 = new Object[] {
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D6;
        prmT003D6 = new Object[] {
        new ParDef("@LiqMTMovCod",GXType.Int32,6,0)
        };
        Object[] prmT003D9;
        prmT003D9 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D10;
        prmT003D10 = new Object[] {
        new ParDef("@LiqMTipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqMComCod",GXType.NChar,15,0) ,
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D11;
        prmT003D11 = new Object[] {
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D12;
        prmT003D12 = new Object[] {
        new ParDef("@LiqMTMovCod",GXType.Int32,6,0)
        };
        Object[] prmT003D13;
        prmT003D13 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D3;
        prmT003D3 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D14;
        prmT003D14 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D15;
        prmT003D15 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D2;
        prmT003D2 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D16;
        prmT003D16 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0) ,
        new ParDef("@LiqMFech",GXType.Date,8,0) ,
        new ParDef("@LiqMConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@LiqMForCod",GXType.Int32,6,0) ,
        new ParDef("@LiqMTipCmb",GXType.Decimal,10,4) ,
        new ParDef("@LiqMImporte",GXType.Decimal,15,2) ,
        new ParDef("@LiqMPago",GXType.Decimal,15,2) ,
        new ParDef("@LiqMVouAno",GXType.Int16,4,0) ,
        new ParDef("@LiqMVouMes",GXType.Int16,2,0) ,
        new ParDef("@LiqMTASICod",GXType.Int32,6,0) ,
        new ParDef("@LiqMVouNum",GXType.NChar,10,0) ,
        new ParDef("@LiqMUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LiqMUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LiqMPagReg",GXType.Decimal,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMTipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqMComCod",GXType.NChar,15,0) ,
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMTMovCod",GXType.Int32,6,0)
        };
        Object[] prmT003D17;
        prmT003D17 = new Object[] {
        new ParDef("@LiqMFech",GXType.Date,8,0) ,
        new ParDef("@LiqMConcepto",GXType.NVarChar,100,0) ,
        new ParDef("@LiqMForCod",GXType.Int32,6,0) ,
        new ParDef("@LiqMTipCmb",GXType.Decimal,10,4) ,
        new ParDef("@LiqMImporte",GXType.Decimal,15,2) ,
        new ParDef("@LiqMPago",GXType.Decimal,15,2) ,
        new ParDef("@LiqMVouAno",GXType.Int16,4,0) ,
        new ParDef("@LiqMVouMes",GXType.Int16,2,0) ,
        new ParDef("@LiqMTASICod",GXType.Int32,6,0) ,
        new ParDef("@LiqMVouNum",GXType.NChar,10,0) ,
        new ParDef("@LiqMUsuCod",GXType.NChar,10,0) ,
        new ParDef("@LiqMUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@LiqMPagReg",GXType.Decimal,10,0) ,
        new ParDef("@LiqMTipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqMComCod",GXType.NChar,15,0) ,
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMTMovCod",GXType.Int32,6,0) ,
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D18;
        prmT003D18 = new Object[] {
        new ParDef("@LiqCod",GXType.NVarChar,10,0) ,
        new ParDef("@LiqPrvCod",GXType.NChar,20,0) ,
        new ParDef("@LiqMItem",GXType.Int32,6,0)
        };
        Object[] prmT003D22;
        prmT003D22 = new Object[] {
        };
        Object[] prmT003D23;
        prmT003D23 = new Object[] {
        new ParDef("@LiqPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D19;
        prmT003D19 = new Object[] {
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D20;
        prmT003D20 = new Object[] {
        new ParDef("@LiqMTipCod",GXType.NChar,3,0) ,
        new ParDef("@LiqMComCod",GXType.NChar,15,0) ,
        new ParDef("@LiqMPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003D21;
        prmT003D21 = new Object[] {
        new ParDef("@LiqMTMovCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T003D2", "SELECT [LiqCod], [LiqMItem], [LiqMFech], [LiqMConcepto], [LiqMForCod], [LiqMTipCmb], [LiqMImporte], [LiqMPago], [LiqMVouAno], [LiqMVouMes], [LiqMTASICod], [LiqMVouNum], [LiqMUsuCod], [LiqMUsuFec], [LiqMPagReg], [LiqPrvCod], [LiqMTipCod] AS LiqMTipCod, [LiqMComCod] AS LiqMComCod, [LiqMPrvCod] AS LiqMPrvCod, [LiqMTMovCod] AS LiqMTMovCod FROM [CPLIQUIDACIONDET] WITH (UPDLOCK) WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqMItem] = @LiqMItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D3", "SELECT [LiqCod], [LiqMItem], [LiqMFech], [LiqMConcepto], [LiqMForCod], [LiqMTipCmb], [LiqMImporte], [LiqMPago], [LiqMVouAno], [LiqMVouMes], [LiqMTASICod], [LiqMVouNum], [LiqMUsuCod], [LiqMUsuFec], [LiqMPagReg], [LiqPrvCod], [LiqMTipCod] AS LiqMTipCod, [LiqMComCod] AS LiqMComCod, [LiqMPrvCod] AS LiqMPrvCod, [LiqMTMovCod] AS LiqMTMovCod FROM [CPLIQUIDACIONDET] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqMItem] = @LiqMItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D4", "SELECT [LiqPrvCod] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D5", "SELECT [CPMonCod] AS LiqMMonCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @LiqMTipCod AND [CPComCod] = @LiqMComCod AND [CPPrvCod] = @LiqMPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D6", "SELECT [ConBDsc] AS LiqMTMovDsc, [ConBCueCod] AS LiqMTMovCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LiqMTMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D7", "SELECT [PrvDsc] AS LiqMPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @LiqMPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D8", "SELECT TM1.[LiqCod], TM1.[LiqMItem], TM1.[LiqMFech], TM1.[LiqMConcepto], T2.[PrvDsc] AS LiqMPrvDsc, TM1.[LiqMForCod], TM1.[LiqMTipCmb], TM1.[LiqMImporte], TM1.[LiqMPago], TM1.[LiqMVouAno], TM1.[LiqMVouMes], TM1.[LiqMTASICod], TM1.[LiqMVouNum], T4.[ConBDsc] AS LiqMTMovDsc, TM1.[LiqMUsuCod], TM1.[LiqMUsuFec], TM1.[LiqMPagReg], TM1.[LiqPrvCod], TM1.[LiqMTipCod] AS LiqMTipCod, TM1.[LiqMComCod] AS LiqMComCod, TM1.[LiqMPrvCod] AS LiqMPrvCod, TM1.[LiqMTMovCod] AS LiqMTMovCod, T3.[CPMonCod] AS LiqMMonCod, T4.[ConBCueCod] AS LiqMTMovCueCod FROM ((([CPLIQUIDACIONDET] TM1 INNER JOIN [CPCUENTAPAGAR] T3 ON T3.[CPTipCod] = TM1.[LiqMTipCod] AND T3.[CPComCod] = TM1.[LiqMComCod] AND T3.[CPPrvCod] = TM1.[LiqMPrvCod]) INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = T3.[CPPrvCod]) INNER JOIN [TSCONCEPTOBANCOS] T4 ON T4.[ConBCod] = TM1.[LiqMTMovCod]) WHERE TM1.[LiqCod] = @LiqCod and TM1.[LiqPrvCod] = @LiqPrvCod and TM1.[LiqMItem] = @LiqMItem ORDER BY TM1.[LiqCod], TM1.[LiqPrvCod], TM1.[LiqMItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003D8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D9", "SELECT [LiqPrvCod] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D10", "SELECT [CPMonCod] AS LiqMMonCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @LiqMTipCod AND [CPComCod] = @LiqMComCod AND [CPPrvCod] = @LiqMPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D11", "SELECT [PrvDsc] AS LiqMPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @LiqMPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D12", "SELECT [ConBDsc] AS LiqMTMovDsc, [ConBCueCod] AS LiqMTMovCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LiqMTMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D13", "SELECT [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqMItem] = @LiqMItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003D13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D14", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] WHERE ( [LiqCod] > @LiqCod or [LiqCod] = @LiqCod and [LiqPrvCod] > @LiqPrvCod or [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqMItem] > @LiqMItem) ORDER BY [LiqCod], [LiqPrvCod], [LiqMItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003D14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003D15", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] WHERE ( [LiqCod] < @LiqCod or [LiqCod] = @LiqCod and [LiqPrvCod] < @LiqPrvCod or [LiqPrvCod] = @LiqPrvCod and [LiqCod] = @LiqCod and [LiqMItem] < @LiqMItem) ORDER BY [LiqCod] DESC, [LiqPrvCod] DESC, [LiqMItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003D15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003D16", "INSERT INTO [CPLIQUIDACIONDET]([LiqCod], [LiqMItem], [LiqMFech], [LiqMConcepto], [LiqMForCod], [LiqMTipCmb], [LiqMImporte], [LiqMPago], [LiqMVouAno], [LiqMVouMes], [LiqMTASICod], [LiqMVouNum], [LiqMUsuCod], [LiqMUsuFec], [LiqMPagReg], [LiqPrvCod], [LiqMTipCod], [LiqMComCod], [LiqMPrvCod], [LiqMTMovCod]) VALUES(@LiqCod, @LiqMItem, @LiqMFech, @LiqMConcepto, @LiqMForCod, @LiqMTipCmb, @LiqMImporte, @LiqMPago, @LiqMVouAno, @LiqMVouMes, @LiqMTASICod, @LiqMVouNum, @LiqMUsuCod, @LiqMUsuFec, @LiqMPagReg, @LiqPrvCod, @LiqMTipCod, @LiqMComCod, @LiqMPrvCod, @LiqMTMovCod)", GxErrorMask.GX_NOMASK,prmT003D16)
           ,new CursorDef("T003D17", "UPDATE [CPLIQUIDACIONDET] SET [LiqMFech]=@LiqMFech, [LiqMConcepto]=@LiqMConcepto, [LiqMForCod]=@LiqMForCod, [LiqMTipCmb]=@LiqMTipCmb, [LiqMImporte]=@LiqMImporte, [LiqMPago]=@LiqMPago, [LiqMVouAno]=@LiqMVouAno, [LiqMVouMes]=@LiqMVouMes, [LiqMTASICod]=@LiqMTASICod, [LiqMVouNum]=@LiqMVouNum, [LiqMUsuCod]=@LiqMUsuCod, [LiqMUsuFec]=@LiqMUsuFec, [LiqMPagReg]=@LiqMPagReg, [LiqMTipCod]=@LiqMTipCod, [LiqMComCod]=@LiqMComCod, [LiqMPrvCod]=@LiqMPrvCod, [LiqMTMovCod]=@LiqMTMovCod  WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqMItem] = @LiqMItem", GxErrorMask.GX_NOMASK,prmT003D17)
           ,new CursorDef("T003D18", "DELETE FROM [CPLIQUIDACIONDET]  WHERE [LiqCod] = @LiqCod AND [LiqPrvCod] = @LiqPrvCod AND [LiqMItem] = @LiqMItem", GxErrorMask.GX_NOMASK,prmT003D18)
           ,new CursorDef("T003D19", "SELECT [PrvDsc] AS LiqMPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @LiqMPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D20", "SELECT [CPMonCod] AS LiqMMonCod FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @LiqMTipCod AND [CPComCod] = @LiqMComCod AND [CPPrvCod] = @LiqMPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D21", "SELECT [ConBDsc] AS LiqMTMovDsc, [ConBCueCod] AS LiqMTMovCueCod FROM [TSCONCEPTOBANCOS] WHERE [ConBCod] = @LiqMTMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D22", "SELECT [LiqCod], [LiqPrvCod], [LiqMItem] FROM [CPLIQUIDACIONDET] ORDER BY [LiqCod], [LiqPrvCod], [LiqMItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003D22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003D23", "SELECT [LiqPrvCod] FROM [CPAGENTES] WHERE [LiqPrvCod] = @LiqPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003D23,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((long[]) buf[14])[0] = rslt.getLong(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 3);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(14);
              ((long[]) buf[14])[0] = rslt.getLong(15);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 3);
              ((string[]) buf[17])[0] = rslt.getString(18, 15);
              ((string[]) buf[18])[0] = rslt.getString(19, 20);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((int[]) buf[5])[0] = rslt.getInt(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((string[]) buf[13])[0] = rslt.getString(14, 100);
              ((string[]) buf[14])[0] = rslt.getString(15, 10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(16);
              ((long[]) buf[16])[0] = rslt.getLong(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 20);
              ((string[]) buf[18])[0] = rslt.getString(19, 3);
              ((string[]) buf[19])[0] = rslt.getString(20, 15);
              ((string[]) buf[20])[0] = rslt.getString(21, 20);
              ((int[]) buf[21])[0] = rslt.getInt(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
  }

}

}
