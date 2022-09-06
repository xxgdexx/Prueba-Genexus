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
   public class tsmovbancos : GXDataArea
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
            A143ForCod = (int)(NumberUtil.Val( GetPar( "ForCod"), "."));
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A143ForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A244PrvCod = GetPar( "PrvCod");
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A149TipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A388TSMovBanCod = (int)(NumberUtil.Val( GetPar( "TSMovBanCod"), "."));
            AssignAttri("", false, "A388TSMovBanCod", StringUtil.LTrimStr( (decimal)(A388TSMovBanCod), 6, 0));
            A389TSMovCBCod = GetPar( "TSMovCBCod");
            AssignAttri("", false, "A389TSMovCBCod", A389TSMovCBCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A388TSMovBanCod, A389TSMovCBCod) ;
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
            Form.Meta.addItem("description", "Movimientos Bancos Otros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsmovbancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsmovbancos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Movimientos Bancos Otros", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_TSMOVBANCOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSMOVBANCOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovCod_Internalname, "Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovCod_Internalname, A387TSMovCod, StringUtil.RTrim( context.localUtil.Format( A387TSMovCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTSMovFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTSMovFec_Internalname, context.localUtil.Format(A1970TSMovFec, "99/99/99"), context.localUtil.Format( A1970TSMovFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_bitmap( context, edtTSMovFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTSMovFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVBANCOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtForCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtForCod_Internalname, "Codigo forma pago", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPrvCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrvCod_Internalname, "Codigo Proveedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPrvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrvDsc_Internalname, "Razon Social", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvDsc_Internalname, StringUtil.RTrim( A247PrvDsc), StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovGls_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovGls_Internalname, "Concepto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovGls_Internalname, A1971TSMovGls, StringUtil.RTrim( context.localUtil.Format( A1971TSMovGls, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovGls_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovGls_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovImp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovImp_Internalname, "Credito", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A1972TSMovImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtTSMovImp_Enabled!=0) ? context.localUtil.Format( A1972TSMovImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1972TSMovImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovMonCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovMonCod_Internalname, "Moneda", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTSMovMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1975TSMovMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSMovMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1975TSMovMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1975TSMovMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovBanCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovBanCod_Internalname, "Banco", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A388TSMovBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSMovBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A388TSMovBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A388TSMovBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovCBCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovCBCod_Internalname, "Cuenta", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovCBCod_Internalname, StringUtil.RTrim( A389TSMovCBCod), StringUtil.RTrim( context.localUtil.Format( A389TSMovCBCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovCBCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovCBCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovNCuotas_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovNCuotas_Internalname, "Cuotas", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovNCuotas_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1976TSMovNCuotas), 4, 0, ".", "")), StringUtil.LTrim( ((edtTSMovNCuotas_Enabled!=0) ? context.localUtil.Format( (decimal)(A1976TSMovNCuotas), "ZZZ9") : context.localUtil.Format( (decimal)(A1976TSMovNCuotas), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovNCuotas_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovNCuotas_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovImpCuota_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovImpCuota_Internalname, "Cuota", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovImpCuota_Internalname, StringUtil.LTrim( StringUtil.NToC( A1973TSMovImpCuota, 17, 2, ".", "")), StringUtil.LTrim( ((edtTSMovImpCuota_Enabled!=0) ? context.localUtil.Format( A1973TSMovImpCuota, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1973TSMovImpCuota, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovImpCuota_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovImpCuota_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovTItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovTItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovTItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1977TSMovTItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSMovTItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1977TSMovTItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1977TSMovTItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovTItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovTItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 102,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOS.htm");
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
            Z387TSMovCod = cgiGet( "Z387TSMovCod");
            Z1970TSMovFec = context.localUtil.CToD( cgiGet( "Z1970TSMovFec"), 0);
            Z1971TSMovGls = cgiGet( "Z1971TSMovGls");
            Z1972TSMovImp = context.localUtil.CToN( cgiGet( "Z1972TSMovImp"), ".", ",");
            Z1976TSMovNCuotas = (short)(context.localUtil.CToN( cgiGet( "Z1976TSMovNCuotas"), ".", ","));
            Z1973TSMovImpCuota = context.localUtil.CToN( cgiGet( "Z1973TSMovImpCuota"), ".", ",");
            Z1977TSMovTItem = (int)(context.localUtil.CToN( cgiGet( "Z1977TSMovTItem"), ".", ","));
            Z143ForCod = (int)(context.localUtil.CToN( cgiGet( "Z143ForCod"), ".", ","));
            Z244PrvCod = cgiGet( "Z244PrvCod");
            Z149TipCod = cgiGet( "Z149TipCod");
            Z388TSMovBanCod = (int)(context.localUtil.CToN( cgiGet( "Z388TSMovBanCod"), ".", ","));
            Z389TSMovCBCod = cgiGet( "Z389TSMovCBCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A387TSMovCod = cgiGet( edtTSMovCod_Internalname);
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            if ( context.localUtil.VCDate( cgiGet( edtTSMovFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "TSMOVFEC");
               AnyError = 1;
               GX_FocusControl = edtTSMovFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1970TSMovFec = DateTime.MinValue;
               AssignAttri("", false, "A1970TSMovFec", context.localUtil.Format(A1970TSMovFec, "99/99/99"));
            }
            else
            {
               A1970TSMovFec = context.localUtil.CToD( cgiGet( edtTSMovFec_Internalname), 2);
               AssignAttri("", false, "A1970TSMovFec", context.localUtil.Format(A1970TSMovFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORCOD");
               AnyError = 1;
               GX_FocusControl = edtForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A143ForCod = 0;
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            }
            else
            {
               A143ForCod = (int)(context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ","));
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            }
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A247PrvDsc = cgiGet( edtPrvDsc_Internalname);
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1971TSMovGls = cgiGet( edtTSMovGls_Internalname);
            AssignAttri("", false, "A1971TSMovGls", A1971TSMovGls);
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSMovImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTSMovImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSMOVIMP");
               AnyError = 1;
               GX_FocusControl = edtTSMovImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1972TSMovImp = 0;
               AssignAttri("", false, "A1972TSMovImp", StringUtil.LTrimStr( A1972TSMovImp, 15, 2));
            }
            else
            {
               A1972TSMovImp = context.localUtil.CToN( cgiGet( edtTSMovImp_Internalname), ".", ",");
               AssignAttri("", false, "A1972TSMovImp", StringUtil.LTrimStr( A1972TSMovImp, 15, 2));
            }
            A1975TSMovMonCod = (int)(context.localUtil.CToN( cgiGet( edtTSMovMonCod_Internalname), ".", ","));
            AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrimStr( (decimal)(A1975TSMovMonCod), 6, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSMovBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSMovBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSMOVBANCOD");
               AnyError = 1;
               GX_FocusControl = edtTSMovBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A388TSMovBanCod = 0;
               AssignAttri("", false, "A388TSMovBanCod", StringUtil.LTrimStr( (decimal)(A388TSMovBanCod), 6, 0));
            }
            else
            {
               A388TSMovBanCod = (int)(context.localUtil.CToN( cgiGet( edtTSMovBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A388TSMovBanCod", StringUtil.LTrimStr( (decimal)(A388TSMovBanCod), 6, 0));
            }
            A389TSMovCBCod = cgiGet( edtTSMovCBCod_Internalname);
            AssignAttri("", false, "A389TSMovCBCod", A389TSMovCBCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSMovNCuotas_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSMovNCuotas_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSMOVNCUOTAS");
               AnyError = 1;
               GX_FocusControl = edtTSMovNCuotas_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1976TSMovNCuotas = 0;
               AssignAttri("", false, "A1976TSMovNCuotas", StringUtil.LTrimStr( (decimal)(A1976TSMovNCuotas), 4, 0));
            }
            else
            {
               A1976TSMovNCuotas = (short)(context.localUtil.CToN( cgiGet( edtTSMovNCuotas_Internalname), ".", ","));
               AssignAttri("", false, "A1976TSMovNCuotas", StringUtil.LTrimStr( (decimal)(A1976TSMovNCuotas), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSMovImpCuota_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTSMovImpCuota_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSMOVIMPCUOTA");
               AnyError = 1;
               GX_FocusControl = edtTSMovImpCuota_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1973TSMovImpCuota = 0;
               AssignAttri("", false, "A1973TSMovImpCuota", StringUtil.LTrimStr( A1973TSMovImpCuota, 15, 2));
            }
            else
            {
               A1973TSMovImpCuota = context.localUtil.CToN( cgiGet( edtTSMovImpCuota_Internalname), ".", ",");
               AssignAttri("", false, "A1973TSMovImpCuota", StringUtil.LTrimStr( A1973TSMovImpCuota, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSMovTItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSMovTItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSMOVTITEM");
               AnyError = 1;
               GX_FocusControl = edtTSMovTItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1977TSMovTItem = 0;
               AssignAttri("", false, "A1977TSMovTItem", StringUtil.LTrimStr( (decimal)(A1977TSMovTItem), 6, 0));
            }
            else
            {
               A1977TSMovTItem = (int)(context.localUtil.CToN( cgiGet( edtTSMovTItem_Internalname), ".", ","));
               AssignAttri("", false, "A1977TSMovTItem", StringUtil.LTrimStr( (decimal)(A1977TSMovTItem), 6, 0));
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
               A387TSMovCod = GetPar( "TSMovCod");
               AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
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
               InitAll4U161( ) ;
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
         DisableAttributes4U161( ) ;
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

      protected void ResetCaption4U0( )
      {
      }

      protected void ZM4U161( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1970TSMovFec = T004U3_A1970TSMovFec[0];
               Z1971TSMovGls = T004U3_A1971TSMovGls[0];
               Z1972TSMovImp = T004U3_A1972TSMovImp[0];
               Z1976TSMovNCuotas = T004U3_A1976TSMovNCuotas[0];
               Z1973TSMovImpCuota = T004U3_A1973TSMovImpCuota[0];
               Z1977TSMovTItem = T004U3_A1977TSMovTItem[0];
               Z143ForCod = T004U3_A143ForCod[0];
               Z244PrvCod = T004U3_A244PrvCod[0];
               Z149TipCod = T004U3_A149TipCod[0];
               Z388TSMovBanCod = T004U3_A388TSMovBanCod[0];
               Z389TSMovCBCod = T004U3_A389TSMovCBCod[0];
            }
            else
            {
               Z1970TSMovFec = A1970TSMovFec;
               Z1971TSMovGls = A1971TSMovGls;
               Z1972TSMovImp = A1972TSMovImp;
               Z1976TSMovNCuotas = A1976TSMovNCuotas;
               Z1973TSMovImpCuota = A1973TSMovImpCuota;
               Z1977TSMovTItem = A1977TSMovTItem;
               Z143ForCod = A143ForCod;
               Z244PrvCod = A244PrvCod;
               Z149TipCod = A149TipCod;
               Z388TSMovBanCod = A388TSMovBanCod;
               Z389TSMovCBCod = A389TSMovCBCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z387TSMovCod = A387TSMovCod;
            Z1970TSMovFec = A1970TSMovFec;
            Z1971TSMovGls = A1971TSMovGls;
            Z1972TSMovImp = A1972TSMovImp;
            Z1976TSMovNCuotas = A1976TSMovNCuotas;
            Z1973TSMovImpCuota = A1973TSMovImpCuota;
            Z1977TSMovTItem = A1977TSMovTItem;
            Z143ForCod = A143ForCod;
            Z244PrvCod = A244PrvCod;
            Z149TipCod = A149TipCod;
            Z388TSMovBanCod = A388TSMovBanCod;
            Z389TSMovCBCod = A389TSMovCBCod;
            Z247PrvDsc = A247PrvDsc;
            Z1975TSMovMonCod = A1975TSMovMonCod;
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

      protected void Load4U161( )
      {
         /* Using cursor T004U8 */
         pr_default.execute(6, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound161 = 1;
            A1970TSMovFec = T004U8_A1970TSMovFec[0];
            AssignAttri("", false, "A1970TSMovFec", context.localUtil.Format(A1970TSMovFec, "99/99/99"));
            A247PrvDsc = T004U8_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A1971TSMovGls = T004U8_A1971TSMovGls[0];
            AssignAttri("", false, "A1971TSMovGls", A1971TSMovGls);
            A1972TSMovImp = T004U8_A1972TSMovImp[0];
            AssignAttri("", false, "A1972TSMovImp", StringUtil.LTrimStr( A1972TSMovImp, 15, 2));
            A1976TSMovNCuotas = T004U8_A1976TSMovNCuotas[0];
            AssignAttri("", false, "A1976TSMovNCuotas", StringUtil.LTrimStr( (decimal)(A1976TSMovNCuotas), 4, 0));
            A1973TSMovImpCuota = T004U8_A1973TSMovImpCuota[0];
            AssignAttri("", false, "A1973TSMovImpCuota", StringUtil.LTrimStr( A1973TSMovImpCuota, 15, 2));
            A1977TSMovTItem = T004U8_A1977TSMovTItem[0];
            AssignAttri("", false, "A1977TSMovTItem", StringUtil.LTrimStr( (decimal)(A1977TSMovTItem), 6, 0));
            A143ForCod = T004U8_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A244PrvCod = T004U8_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A149TipCod = T004U8_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A388TSMovBanCod = T004U8_A388TSMovBanCod[0];
            AssignAttri("", false, "A388TSMovBanCod", StringUtil.LTrimStr( (decimal)(A388TSMovBanCod), 6, 0));
            A389TSMovCBCod = T004U8_A389TSMovCBCod[0];
            AssignAttri("", false, "A389TSMovCBCod", A389TSMovCBCod);
            A1975TSMovMonCod = T004U8_A1975TSMovMonCod[0];
            AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrimStr( (decimal)(A1975TSMovMonCod), 6, 0));
            ZM4U161( -2) ;
         }
         pr_default.close(6);
         OnLoadActions4U161( ) ;
      }

      protected void OnLoadActions4U161( )
      {
      }

      protected void CheckExtendedTable4U161( )
      {
         nIsDirty_161 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1970TSMovFec) || ( DateTimeUtil.ResetTime ( A1970TSMovFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "TSMOVFEC");
            AnyError = 1;
            GX_FocusControl = edtTSMovFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T004U4 */
         pr_default.execute(2, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T004U5 */
         pr_default.execute(3, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T004U5_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         pr_default.close(3);
         /* Using cursor T004U6 */
         pr_default.execute(4, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T004U7 */
         pr_default.execute(5, new Object[] {A388TSMovBanCod, A389TSMovCBCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento Bancos Otros'.", "ForeignKeyNotFound", 1, "TSMOVCBCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1975TSMovMonCod = T004U7_A1975TSMovMonCod[0];
         AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrimStr( (decimal)(A1975TSMovMonCod), 6, 0));
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors4U161( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A143ForCod )
      {
         /* Using cursor T004U9 */
         pr_default.execute(7, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
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

      protected void gxLoad_4( string A244PrvCod )
      {
         /* Using cursor T004U10 */
         pr_default.execute(8, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T004U10_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A247PrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_5( string A149TipCod )
      {
         /* Using cursor T004U11 */
         pr_default.execute(9, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
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

      protected void gxLoad_6( int A388TSMovBanCod ,
                               string A389TSMovCBCod )
      {
         /* Using cursor T004U12 */
         pr_default.execute(10, new Object[] {A388TSMovBanCod, A389TSMovCBCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento Bancos Otros'.", "ForeignKeyNotFound", 1, "TSMOVCBCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1975TSMovMonCod = T004U12_A1975TSMovMonCod[0];
         AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrimStr( (decimal)(A1975TSMovMonCod), 6, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1975TSMovMonCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey4U161( )
      {
         /* Using cursor T004U13 */
         pr_default.execute(11, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound161 = 1;
         }
         else
         {
            RcdFound161 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004U3 */
         pr_default.execute(1, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4U161( 2) ;
            RcdFound161 = 1;
            A387TSMovCod = T004U3_A387TSMovCod[0];
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            A1970TSMovFec = T004U3_A1970TSMovFec[0];
            AssignAttri("", false, "A1970TSMovFec", context.localUtil.Format(A1970TSMovFec, "99/99/99"));
            A1971TSMovGls = T004U3_A1971TSMovGls[0];
            AssignAttri("", false, "A1971TSMovGls", A1971TSMovGls);
            A1972TSMovImp = T004U3_A1972TSMovImp[0];
            AssignAttri("", false, "A1972TSMovImp", StringUtil.LTrimStr( A1972TSMovImp, 15, 2));
            A1976TSMovNCuotas = T004U3_A1976TSMovNCuotas[0];
            AssignAttri("", false, "A1976TSMovNCuotas", StringUtil.LTrimStr( (decimal)(A1976TSMovNCuotas), 4, 0));
            A1973TSMovImpCuota = T004U3_A1973TSMovImpCuota[0];
            AssignAttri("", false, "A1973TSMovImpCuota", StringUtil.LTrimStr( A1973TSMovImpCuota, 15, 2));
            A1977TSMovTItem = T004U3_A1977TSMovTItem[0];
            AssignAttri("", false, "A1977TSMovTItem", StringUtil.LTrimStr( (decimal)(A1977TSMovTItem), 6, 0));
            A143ForCod = T004U3_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A244PrvCod = T004U3_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A149TipCod = T004U3_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A388TSMovBanCod = T004U3_A388TSMovBanCod[0];
            AssignAttri("", false, "A388TSMovBanCod", StringUtil.LTrimStr( (decimal)(A388TSMovBanCod), 6, 0));
            A389TSMovCBCod = T004U3_A389TSMovCBCod[0];
            AssignAttri("", false, "A389TSMovCBCod", A389TSMovCBCod);
            Z387TSMovCod = A387TSMovCod;
            sMode161 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4U161( ) ;
            if ( AnyError == 1 )
            {
               RcdFound161 = 0;
               InitializeNonKey4U161( ) ;
            }
            Gx_mode = sMode161;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound161 = 0;
            InitializeNonKey4U161( ) ;
            sMode161 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode161;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4U161( ) ;
         if ( RcdFound161 == 0 )
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
         RcdFound161 = 0;
         /* Using cursor T004U14 */
         pr_default.execute(12, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T004U14_A387TSMovCod[0], A387TSMovCod) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T004U14_A387TSMovCod[0], A387TSMovCod) > 0 ) ) )
            {
               A387TSMovCod = T004U14_A387TSMovCod[0];
               AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
               RcdFound161 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound161 = 0;
         /* Using cursor T004U15 */
         pr_default.execute(13, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T004U15_A387TSMovCod[0], A387TSMovCod) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T004U15_A387TSMovCod[0], A387TSMovCod) < 0 ) ) )
            {
               A387TSMovCod = T004U15_A387TSMovCod[0];
               AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
               RcdFound161 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4U161( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4U161( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound161 == 1 )
            {
               if ( StringUtil.StrCmp(A387TSMovCod, Z387TSMovCod) != 0 )
               {
                  A387TSMovCod = Z387TSMovCod;
                  AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TSMOVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTSMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTSMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4U161( ) ;
                  GX_FocusControl = edtTSMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A387TSMovCod, Z387TSMovCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTSMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4U161( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TSMOVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTSMovCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTSMovCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4U161( ) ;
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
         if ( StringUtil.StrCmp(A387TSMovCod, Z387TSMovCod) != 0 )
         {
            A387TSMovCod = Z387TSMovCod;
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TSMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTSMovCod_Internalname;
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
         if ( RcdFound161 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TSMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTSMovFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4U161( ) ;
         if ( RcdFound161 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4U161( ) ;
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
         if ( RcdFound161 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovFec_Internalname;
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
         if ( RcdFound161 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovFec_Internalname;
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
         ScanStart4U161( ) ;
         if ( RcdFound161 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound161 != 0 )
            {
               ScanNext4U161( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4U161( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4U161( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004U2 */
            pr_default.execute(0, new Object[] {A387TSMovCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVBANCOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1970TSMovFec ) != DateTimeUtil.ResetTime ( T004U2_A1970TSMovFec[0] ) ) || ( StringUtil.StrCmp(Z1971TSMovGls, T004U2_A1971TSMovGls[0]) != 0 ) || ( Z1972TSMovImp != T004U2_A1972TSMovImp[0] ) || ( Z1976TSMovNCuotas != T004U2_A1976TSMovNCuotas[0] ) || ( Z1973TSMovImpCuota != T004U2_A1973TSMovImpCuota[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1977TSMovTItem != T004U2_A1977TSMovTItem[0] ) || ( Z143ForCod != T004U2_A143ForCod[0] ) || ( StringUtil.StrCmp(Z244PrvCod, T004U2_A244PrvCod[0]) != 0 ) || ( StringUtil.StrCmp(Z149TipCod, T004U2_A149TipCod[0]) != 0 ) || ( Z388TSMovBanCod != T004U2_A388TSMovBanCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z389TSMovCBCod, T004U2_A389TSMovCBCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1970TSMovFec ) != DateTimeUtil.ResetTime ( T004U2_A1970TSMovFec[0] ) )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovFec");
                  GXUtil.WriteLogRaw("Old: ",Z1970TSMovFec);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A1970TSMovFec[0]);
               }
               if ( StringUtil.StrCmp(Z1971TSMovGls, T004U2_A1971TSMovGls[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovGls");
                  GXUtil.WriteLogRaw("Old: ",Z1971TSMovGls);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A1971TSMovGls[0]);
               }
               if ( Z1972TSMovImp != T004U2_A1972TSMovImp[0] )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovImp");
                  GXUtil.WriteLogRaw("Old: ",Z1972TSMovImp);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A1972TSMovImp[0]);
               }
               if ( Z1976TSMovNCuotas != T004U2_A1976TSMovNCuotas[0] )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovNCuotas");
                  GXUtil.WriteLogRaw("Old: ",Z1976TSMovNCuotas);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A1976TSMovNCuotas[0]);
               }
               if ( Z1973TSMovImpCuota != T004U2_A1973TSMovImpCuota[0] )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovImpCuota");
                  GXUtil.WriteLogRaw("Old: ",Z1973TSMovImpCuota);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A1973TSMovImpCuota[0]);
               }
               if ( Z1977TSMovTItem != T004U2_A1977TSMovTItem[0] )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovTItem");
                  GXUtil.WriteLogRaw("Old: ",Z1977TSMovTItem);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A1977TSMovTItem[0]);
               }
               if ( Z143ForCod != T004U2_A143ForCod[0] )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"ForCod");
                  GXUtil.WriteLogRaw("Old: ",Z143ForCod);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A143ForCod[0]);
               }
               if ( StringUtil.StrCmp(Z244PrvCod, T004U2_A244PrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"PrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z244PrvCod);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A244PrvCod[0]);
               }
               if ( StringUtil.StrCmp(Z149TipCod, T004U2_A149TipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TipCod");
                  GXUtil.WriteLogRaw("Old: ",Z149TipCod);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A149TipCod[0]);
               }
               if ( Z388TSMovBanCod != T004U2_A388TSMovBanCod[0] )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z388TSMovBanCod);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A388TSMovBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z389TSMovCBCod, T004U2_A389TSMovCBCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovbancos:[seudo value changed for attri]"+"TSMovCBCod");
                  GXUtil.WriteLogRaw("Old: ",Z389TSMovCBCod);
                  GXUtil.WriteLogRaw("Current: ",T004U2_A389TSMovCBCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSMOVBANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4U161( )
      {
         BeforeValidate4U161( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4U161( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4U161( 0) ;
            CheckOptimisticConcurrency4U161( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4U161( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4U161( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004U16 */
                     pr_default.execute(14, new Object[] {A387TSMovCod, A1970TSMovFec, A1971TSMovGls, A1972TSMovImp, A1976TSMovNCuotas, A1973TSMovImpCuota, A1977TSMovTItem, A143ForCod, A244PrvCod, A149TipCod, A388TSMovBanCod, A389TSMovCBCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVBANCOS");
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
                           ResetCaption4U0( ) ;
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
               Load4U161( ) ;
            }
            EndLevel4U161( ) ;
         }
         CloseExtendedTableCursors4U161( ) ;
      }

      protected void Update4U161( )
      {
         BeforeValidate4U161( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4U161( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4U161( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4U161( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4U161( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004U17 */
                     pr_default.execute(15, new Object[] {A1970TSMovFec, A1971TSMovGls, A1972TSMovImp, A1976TSMovNCuotas, A1973TSMovImpCuota, A1977TSMovTItem, A143ForCod, A244PrvCod, A149TipCod, A388TSMovBanCod, A389TSMovCBCod, A387TSMovCod});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVBANCOS");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVBANCOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4U161( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4U0( ) ;
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
            EndLevel4U161( ) ;
         }
         CloseExtendedTableCursors4U161( ) ;
      }

      protected void DeferredUpdate4U161( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4U161( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4U161( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4U161( ) ;
            AfterConfirm4U161( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4U161( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004U18 */
                  pr_default.execute(16, new Object[] {A387TSMovCod});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("TSMOVBANCOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound161 == 0 )
                        {
                           InitAll4U161( ) ;
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
                        ResetCaption4U0( ) ;
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
         sMode161 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4U161( ) ;
         Gx_mode = sMode161;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4U161( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004U19 */
            pr_default.execute(17, new Object[] {A244PrvCod});
            A247PrvDsc = T004U19_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            pr_default.close(17);
            /* Using cursor T004U20 */
            pr_default.execute(18, new Object[] {A388TSMovBanCod, A389TSMovCBCod});
            A1975TSMovMonCod = T004U20_A1975TSMovMonCod[0];
            AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrimStr( (decimal)(A1975TSMovMonCod), 6, 0));
            pr_default.close(18);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T004U21 */
            pr_default.execute(19, new Object[] {A387TSMovCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TSMOVBANCOSDET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel4U161( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4U161( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            context.CommitDataStores("tsmovbancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            pr_default.close(18);
            context.RollbackDataStores("tsmovbancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4U161( )
      {
         /* Using cursor T004U22 */
         pr_default.execute(20);
         RcdFound161 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound161 = 1;
            A387TSMovCod = T004U22_A387TSMovCod[0];
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4U161( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound161 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound161 = 1;
            A387TSMovCod = T004U22_A387TSMovCod[0];
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
         }
      }

      protected void ScanEnd4U161( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm4U161( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4U161( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4U161( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4U161( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4U161( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4U161( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4U161( )
      {
         edtTSMovCod_Enabled = 0;
         AssignProp("", false, edtTSMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovCod_Enabled), 5, 0), true);
         edtTSMovFec_Enabled = 0;
         AssignProp("", false, edtTSMovFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovFec_Enabled), 5, 0), true);
         edtForCod_Enabled = 0;
         AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtPrvDsc_Enabled = 0;
         AssignProp("", false, edtPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDsc_Enabled), 5, 0), true);
         edtTSMovGls_Enabled = 0;
         AssignProp("", false, edtTSMovGls_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovGls_Enabled), 5, 0), true);
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtTSMovImp_Enabled = 0;
         AssignProp("", false, edtTSMovImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovImp_Enabled), 5, 0), true);
         edtTSMovMonCod_Enabled = 0;
         AssignProp("", false, edtTSMovMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovMonCod_Enabled), 5, 0), true);
         edtTSMovBanCod_Enabled = 0;
         AssignProp("", false, edtTSMovBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovBanCod_Enabled), 5, 0), true);
         edtTSMovCBCod_Enabled = 0;
         AssignProp("", false, edtTSMovCBCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovCBCod_Enabled), 5, 0), true);
         edtTSMovNCuotas_Enabled = 0;
         AssignProp("", false, edtTSMovNCuotas_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovNCuotas_Enabled), 5, 0), true);
         edtTSMovImpCuota_Enabled = 0;
         AssignProp("", false, edtTSMovImpCuota_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovImpCuota_Enabled), 5, 0), true);
         edtTSMovTItem_Enabled = 0;
         AssignProp("", false, edtTSMovTItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovTItem_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4U161( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4U0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254215", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tsmovbancos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z387TSMovCod", Z387TSMovCod);
         GxWebStd.gx_hidden_field( context, "Z1970TSMovFec", context.localUtil.DToC( Z1970TSMovFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1971TSMovGls", Z1971TSMovGls);
         GxWebStd.gx_hidden_field( context, "Z1972TSMovImp", StringUtil.LTrim( StringUtil.NToC( Z1972TSMovImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1976TSMovNCuotas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1976TSMovNCuotas), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1973TSMovImpCuota", StringUtil.LTrim( StringUtil.NToC( Z1973TSMovImpCuota, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1977TSMovTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1977TSMovTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z388TSMovBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z388TSMovBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z389TSMovCBCod", StringUtil.RTrim( Z389TSMovCBCod));
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
         return formatLink("tsmovbancos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSMOVBANCOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimientos Bancos Otros" ;
      }

      protected void InitializeNonKey4U161( )
      {
         A1970TSMovFec = DateTime.MinValue;
         AssignAttri("", false, "A1970TSMovFec", context.localUtil.Format(A1970TSMovFec, "99/99/99"));
         A143ForCod = 0;
         AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         A247PrvDsc = "";
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A1971TSMovGls = "";
         AssignAttri("", false, "A1971TSMovGls", A1971TSMovGls);
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         A1972TSMovImp = 0;
         AssignAttri("", false, "A1972TSMovImp", StringUtil.LTrimStr( A1972TSMovImp, 15, 2));
         A1975TSMovMonCod = 0;
         AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrimStr( (decimal)(A1975TSMovMonCod), 6, 0));
         A388TSMovBanCod = 0;
         AssignAttri("", false, "A388TSMovBanCod", StringUtil.LTrimStr( (decimal)(A388TSMovBanCod), 6, 0));
         A389TSMovCBCod = "";
         AssignAttri("", false, "A389TSMovCBCod", A389TSMovCBCod);
         A1976TSMovNCuotas = 0;
         AssignAttri("", false, "A1976TSMovNCuotas", StringUtil.LTrimStr( (decimal)(A1976TSMovNCuotas), 4, 0));
         A1973TSMovImpCuota = 0;
         AssignAttri("", false, "A1973TSMovImpCuota", StringUtil.LTrimStr( A1973TSMovImpCuota, 15, 2));
         A1977TSMovTItem = 0;
         AssignAttri("", false, "A1977TSMovTItem", StringUtil.LTrimStr( (decimal)(A1977TSMovTItem), 6, 0));
         Z1970TSMovFec = DateTime.MinValue;
         Z1971TSMovGls = "";
         Z1972TSMovImp = 0;
         Z1976TSMovNCuotas = 0;
         Z1973TSMovImpCuota = 0;
         Z1977TSMovTItem = 0;
         Z143ForCod = 0;
         Z244PrvCod = "";
         Z149TipCod = "";
         Z388TSMovBanCod = 0;
         Z389TSMovCBCod = "";
      }

      protected void InitAll4U161( )
      {
         A387TSMovCod = "";
         AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
         InitializeNonKey4U161( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254224", true, true);
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
         context.AddJavascriptSource("tsmovbancos.js", "?202281810254225", false, true);
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
         edtTSMovCod_Internalname = "TSMOVCOD";
         edtTSMovFec_Internalname = "TSMOVFEC";
         edtForCod_Internalname = "FORCOD";
         edtPrvCod_Internalname = "PRVCOD";
         edtPrvDsc_Internalname = "PRVDSC";
         edtTSMovGls_Internalname = "TSMOVGLS";
         edtTipCod_Internalname = "TIPCOD";
         edtTSMovImp_Internalname = "TSMOVIMP";
         edtTSMovMonCod_Internalname = "TSMOVMONCOD";
         edtTSMovBanCod_Internalname = "TSMOVBANCOD";
         edtTSMovCBCod_Internalname = "TSMOVCBCOD";
         edtTSMovNCuotas_Internalname = "TSMOVNCUOTAS";
         edtTSMovImpCuota_Internalname = "TSMOVIMPCUOTA";
         edtTSMovTItem_Internalname = "TSMOVTITEM";
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
         Form.Caption = "Movimientos Bancos Otros";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTSMovTItem_Jsonclick = "";
         edtTSMovTItem_Enabled = 1;
         edtTSMovImpCuota_Jsonclick = "";
         edtTSMovImpCuota_Enabled = 1;
         edtTSMovNCuotas_Jsonclick = "";
         edtTSMovNCuotas_Enabled = 1;
         edtTSMovCBCod_Jsonclick = "";
         edtTSMovCBCod_Enabled = 1;
         edtTSMovBanCod_Jsonclick = "";
         edtTSMovBanCod_Enabled = 1;
         edtTSMovMonCod_Jsonclick = "";
         edtTSMovMonCod_Enabled = 0;
         edtTSMovImp_Jsonclick = "";
         edtTSMovImp_Enabled = 1;
         edtTipCod_Jsonclick = "";
         edtTipCod_Enabled = 1;
         edtTSMovGls_Jsonclick = "";
         edtTSMovGls_Enabled = 1;
         edtPrvDsc_Jsonclick = "";
         edtPrvDsc_Enabled = 0;
         edtPrvCod_Jsonclick = "";
         edtPrvCod_Enabled = 1;
         edtForCod_Jsonclick = "";
         edtForCod_Enabled = 1;
         edtTSMovFec_Jsonclick = "";
         edtTSMovFec_Enabled = 1;
         edtTSMovCod_Jsonclick = "";
         edtTSMovCod_Enabled = 1;
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
         GX_FocusControl = edtTSMovFec_Internalname;
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

      public void Valid_Tsmovcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1970TSMovFec", context.localUtil.Format(A1970TSMovFec, "99/99/99"));
         AssignAttri("", false, "A143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A244PrvCod", StringUtil.RTrim( A244PrvCod));
         AssignAttri("", false, "A1971TSMovGls", A1971TSMovGls);
         AssignAttri("", false, "A149TipCod", StringUtil.RTrim( A149TipCod));
         AssignAttri("", false, "A1972TSMovImp", StringUtil.LTrim( StringUtil.NToC( A1972TSMovImp, 15, 2, ".", "")));
         AssignAttri("", false, "A388TSMovBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A388TSMovBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A389TSMovCBCod", StringUtil.RTrim( A389TSMovCBCod));
         AssignAttri("", false, "A1976TSMovNCuotas", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1976TSMovNCuotas), 4, 0, ".", "")));
         AssignAttri("", false, "A1973TSMovImpCuota", StringUtil.LTrim( StringUtil.NToC( A1973TSMovImpCuota, 15, 2, ".", "")));
         AssignAttri("", false, "A1977TSMovTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1977TSMovTItem), 6, 0, ".", "")));
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1975TSMovMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z387TSMovCod", Z387TSMovCod);
         GxWebStd.gx_hidden_field( context, "Z1970TSMovFec", context.localUtil.Format(Z1970TSMovFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z1971TSMovGls", Z1971TSMovGls);
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z1972TSMovImp", StringUtil.LTrim( StringUtil.NToC( Z1972TSMovImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z388TSMovBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z388TSMovBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z389TSMovCBCod", StringUtil.RTrim( Z389TSMovCBCod));
         GxWebStd.gx_hidden_field( context, "Z1976TSMovNCuotas", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1976TSMovNCuotas), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1973TSMovImpCuota", StringUtil.LTrim( StringUtil.NToC( Z1973TSMovImpCuota, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1977TSMovTItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1977TSMovTItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z247PrvDsc", StringUtil.RTrim( Z247PrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1975TSMovMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1975TSMovMonCod), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Forcod( )
      {
         /* Using cursor T004U23 */
         pr_default.execute(21, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prvcod( )
      {
         /* Using cursor T004U19 */
         pr_default.execute(17, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
         }
         A247PrvDsc = T004U19_A247PrvDsc[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
      }

      public void Valid_Tipcod( )
      {
         /* Using cursor T004U24 */
         pr_default.execute(22, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tsmovcbcod( )
      {
         /* Using cursor T004U20 */
         pr_default.execute(18, new Object[] {A388TSMovBanCod, A389TSMovCBCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento Bancos Otros'.", "ForeignKeyNotFound", 1, "TSMOVCBCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovBanCod_Internalname;
         }
         A1975TSMovMonCod = T004U20_A1975TSMovMonCod[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1975TSMovMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1975TSMovMonCod), 6, 0, ".", "")));
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
         setEventMetadata("VALID_TSMOVCOD","{handler:'Valid_Tsmovcod',iparms:[{av:'A387TSMovCod',fld:'TSMOVCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TSMOVCOD",",oparms:[{av:'A1970TSMovFec',fld:'TSMOVFEC',pic:''},{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'},{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A1971TSMovGls',fld:'TSMOVGLS',pic:''},{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A1972TSMovImp',fld:'TSMOVIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A388TSMovBanCod',fld:'TSMOVBANCOD',pic:'ZZZZZ9'},{av:'A389TSMovCBCod',fld:'TSMOVCBCOD',pic:''},{av:'A1976TSMovNCuotas',fld:'TSMOVNCUOTAS',pic:'ZZZ9'},{av:'A1973TSMovImpCuota',fld:'TSMOVIMPCUOTA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1977TSMovTItem',fld:'TSMOVTITEM',pic:'ZZZZZ9'},{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A1975TSMovMonCod',fld:'TSMOVMONCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z387TSMovCod'},{av:'Z1970TSMovFec'},{av:'Z143ForCod'},{av:'Z244PrvCod'},{av:'Z1971TSMovGls'},{av:'Z149TipCod'},{av:'Z1972TSMovImp'},{av:'Z388TSMovBanCod'},{av:'Z389TSMovCBCod'},{av:'Z1976TSMovNCuotas'},{av:'Z1973TSMovImpCuota'},{av:'Z1977TSMovTItem'},{av:'Z247PrvDsc'},{av:'Z1975TSMovMonCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TSMOVFEC","{handler:'Valid_Tsmovfec',iparms:[]");
         setEventMetadata("VALID_TSMOVFEC",",oparms:[]}");
         setEventMetadata("VALID_FORCOD","{handler:'Valid_Forcod',iparms:[{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_FORCOD",",oparms:[]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A247PrvDsc',fld:'PRVDSC',pic:''}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[{av:'A247PrvDsc',fld:'PRVDSC',pic:''}]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_TSMOVBANCOD","{handler:'Valid_Tsmovbancod',iparms:[]");
         setEventMetadata("VALID_TSMOVBANCOD",",oparms:[]}");
         setEventMetadata("VALID_TSMOVCBCOD","{handler:'Valid_Tsmovcbcod',iparms:[{av:'A388TSMovBanCod',fld:'TSMOVBANCOD',pic:'ZZZZZ9'},{av:'A389TSMovCBCod',fld:'TSMOVCBCOD',pic:''},{av:'A1975TSMovMonCod',fld:'TSMOVMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_TSMOVCBCOD",",oparms:[{av:'A1975TSMovMonCod',fld:'TSMOVMONCOD',pic:'ZZZZZ9'}]}");
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
         pr_default.close(17);
         pr_default.close(22);
         pr_default.close(18);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z387TSMovCod = "";
         Z1970TSMovFec = DateTime.MinValue;
         Z1971TSMovGls = "";
         Z244PrvCod = "";
         Z149TipCod = "";
         Z389TSMovCBCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A244PrvCod = "";
         A149TipCod = "";
         A389TSMovCBCod = "";
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
         A387TSMovCod = "";
         A1970TSMovFec = DateTime.MinValue;
         A247PrvDsc = "";
         A1971TSMovGls = "";
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
         Z247PrvDsc = "";
         T004U8_A387TSMovCod = new string[] {""} ;
         T004U8_A1970TSMovFec = new DateTime[] {DateTime.MinValue} ;
         T004U8_A247PrvDsc = new string[] {""} ;
         T004U8_A1971TSMovGls = new string[] {""} ;
         T004U8_A1972TSMovImp = new decimal[1] ;
         T004U8_A1976TSMovNCuotas = new short[1] ;
         T004U8_A1973TSMovImpCuota = new decimal[1] ;
         T004U8_A1977TSMovTItem = new int[1] ;
         T004U8_A143ForCod = new int[1] ;
         T004U8_A244PrvCod = new string[] {""} ;
         T004U8_A149TipCod = new string[] {""} ;
         T004U8_A388TSMovBanCod = new int[1] ;
         T004U8_A389TSMovCBCod = new string[] {""} ;
         T004U8_A1975TSMovMonCod = new int[1] ;
         T004U4_A143ForCod = new int[1] ;
         T004U5_A247PrvDsc = new string[] {""} ;
         T004U6_A149TipCod = new string[] {""} ;
         T004U7_A1975TSMovMonCod = new int[1] ;
         T004U9_A143ForCod = new int[1] ;
         T004U10_A247PrvDsc = new string[] {""} ;
         T004U11_A149TipCod = new string[] {""} ;
         T004U12_A1975TSMovMonCod = new int[1] ;
         T004U13_A387TSMovCod = new string[] {""} ;
         T004U3_A387TSMovCod = new string[] {""} ;
         T004U3_A1970TSMovFec = new DateTime[] {DateTime.MinValue} ;
         T004U3_A1971TSMovGls = new string[] {""} ;
         T004U3_A1972TSMovImp = new decimal[1] ;
         T004U3_A1976TSMovNCuotas = new short[1] ;
         T004U3_A1973TSMovImpCuota = new decimal[1] ;
         T004U3_A1977TSMovTItem = new int[1] ;
         T004U3_A143ForCod = new int[1] ;
         T004U3_A244PrvCod = new string[] {""} ;
         T004U3_A149TipCod = new string[] {""} ;
         T004U3_A388TSMovBanCod = new int[1] ;
         T004U3_A389TSMovCBCod = new string[] {""} ;
         sMode161 = "";
         T004U14_A387TSMovCod = new string[] {""} ;
         T004U15_A387TSMovCod = new string[] {""} ;
         T004U2_A387TSMovCod = new string[] {""} ;
         T004U2_A1970TSMovFec = new DateTime[] {DateTime.MinValue} ;
         T004U2_A1971TSMovGls = new string[] {""} ;
         T004U2_A1972TSMovImp = new decimal[1] ;
         T004U2_A1976TSMovNCuotas = new short[1] ;
         T004U2_A1973TSMovImpCuota = new decimal[1] ;
         T004U2_A1977TSMovTItem = new int[1] ;
         T004U2_A143ForCod = new int[1] ;
         T004U2_A244PrvCod = new string[] {""} ;
         T004U2_A149TipCod = new string[] {""} ;
         T004U2_A388TSMovBanCod = new int[1] ;
         T004U2_A389TSMovCBCod = new string[] {""} ;
         T004U19_A247PrvDsc = new string[] {""} ;
         T004U20_A1975TSMovMonCod = new int[1] ;
         T004U21_A387TSMovCod = new string[] {""} ;
         T004U21_A390TSMovDItem = new int[1] ;
         T004U22_A387TSMovCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ387TSMovCod = "";
         ZZ1970TSMovFec = DateTime.MinValue;
         ZZ244PrvCod = "";
         ZZ1971TSMovGls = "";
         ZZ149TipCod = "";
         ZZ389TSMovCBCod = "";
         ZZ247PrvDsc = "";
         T004U23_A143ForCod = new int[1] ;
         T004U24_A149TipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsmovbancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsmovbancos__default(),
            new Object[][] {
                new Object[] {
               T004U2_A387TSMovCod, T004U2_A1970TSMovFec, T004U2_A1971TSMovGls, T004U2_A1972TSMovImp, T004U2_A1976TSMovNCuotas, T004U2_A1973TSMovImpCuota, T004U2_A1977TSMovTItem, T004U2_A143ForCod, T004U2_A244PrvCod, T004U2_A149TipCod,
               T004U2_A388TSMovBanCod, T004U2_A389TSMovCBCod
               }
               , new Object[] {
               T004U3_A387TSMovCod, T004U3_A1970TSMovFec, T004U3_A1971TSMovGls, T004U3_A1972TSMovImp, T004U3_A1976TSMovNCuotas, T004U3_A1973TSMovImpCuota, T004U3_A1977TSMovTItem, T004U3_A143ForCod, T004U3_A244PrvCod, T004U3_A149TipCod,
               T004U3_A388TSMovBanCod, T004U3_A389TSMovCBCod
               }
               , new Object[] {
               T004U4_A143ForCod
               }
               , new Object[] {
               T004U5_A247PrvDsc
               }
               , new Object[] {
               T004U6_A149TipCod
               }
               , new Object[] {
               T004U7_A1975TSMovMonCod
               }
               , new Object[] {
               T004U8_A387TSMovCod, T004U8_A1970TSMovFec, T004U8_A247PrvDsc, T004U8_A1971TSMovGls, T004U8_A1972TSMovImp, T004U8_A1976TSMovNCuotas, T004U8_A1973TSMovImpCuota, T004U8_A1977TSMovTItem, T004U8_A143ForCod, T004U8_A244PrvCod,
               T004U8_A149TipCod, T004U8_A388TSMovBanCod, T004U8_A389TSMovCBCod, T004U8_A1975TSMovMonCod
               }
               , new Object[] {
               T004U9_A143ForCod
               }
               , new Object[] {
               T004U10_A247PrvDsc
               }
               , new Object[] {
               T004U11_A149TipCod
               }
               , new Object[] {
               T004U12_A1975TSMovMonCod
               }
               , new Object[] {
               T004U13_A387TSMovCod
               }
               , new Object[] {
               T004U14_A387TSMovCod
               }
               , new Object[] {
               T004U15_A387TSMovCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004U19_A247PrvDsc
               }
               , new Object[] {
               T004U20_A1975TSMovMonCod
               }
               , new Object[] {
               T004U21_A387TSMovCod, T004U21_A390TSMovDItem
               }
               , new Object[] {
               T004U22_A387TSMovCod
               }
               , new Object[] {
               T004U23_A143ForCod
               }
               , new Object[] {
               T004U24_A149TipCod
               }
            }
         );
      }

      private short Z1976TSMovNCuotas ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1976TSMovNCuotas ;
      private short GX_JID ;
      private short RcdFound161 ;
      private short nIsDirty_161 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1976TSMovNCuotas ;
      private int Z1977TSMovTItem ;
      private int Z143ForCod ;
      private int Z388TSMovBanCod ;
      private int A143ForCod ;
      private int A388TSMovBanCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTSMovCod_Enabled ;
      private int edtTSMovFec_Enabled ;
      private int edtForCod_Enabled ;
      private int edtPrvCod_Enabled ;
      private int edtPrvDsc_Enabled ;
      private int edtTSMovGls_Enabled ;
      private int edtTipCod_Enabled ;
      private int edtTSMovImp_Enabled ;
      private int A1975TSMovMonCod ;
      private int edtTSMovMonCod_Enabled ;
      private int edtTSMovBanCod_Enabled ;
      private int edtTSMovCBCod_Enabled ;
      private int edtTSMovNCuotas_Enabled ;
      private int edtTSMovImpCuota_Enabled ;
      private int A1977TSMovTItem ;
      private int edtTSMovTItem_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int Z1975TSMovMonCod ;
      private int idxLst ;
      private int ZZ143ForCod ;
      private int ZZ388TSMovBanCod ;
      private int ZZ1977TSMovTItem ;
      private int ZZ1975TSMovMonCod ;
      private decimal Z1972TSMovImp ;
      private decimal Z1973TSMovImpCuota ;
      private decimal A1972TSMovImp ;
      private decimal A1973TSMovImpCuota ;
      private decimal ZZ1972TSMovImp ;
      private decimal ZZ1973TSMovImpCuota ;
      private string sPrefix ;
      private string Z244PrvCod ;
      private string Z149TipCod ;
      private string Z389TSMovCBCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A244PrvCod ;
      private string A149TipCod ;
      private string A389TSMovCBCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTSMovCod_Internalname ;
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
      private string edtTSMovCod_Jsonclick ;
      private string edtTSMovFec_Internalname ;
      private string edtTSMovFec_Jsonclick ;
      private string edtForCod_Internalname ;
      private string edtForCod_Jsonclick ;
      private string edtPrvCod_Internalname ;
      private string edtPrvCod_Jsonclick ;
      private string edtPrvDsc_Internalname ;
      private string A247PrvDsc ;
      private string edtPrvDsc_Jsonclick ;
      private string edtTSMovGls_Internalname ;
      private string edtTSMovGls_Jsonclick ;
      private string edtTipCod_Internalname ;
      private string edtTipCod_Jsonclick ;
      private string edtTSMovImp_Internalname ;
      private string edtTSMovImp_Jsonclick ;
      private string edtTSMovMonCod_Internalname ;
      private string edtTSMovMonCod_Jsonclick ;
      private string edtTSMovBanCod_Internalname ;
      private string edtTSMovBanCod_Jsonclick ;
      private string edtTSMovCBCod_Internalname ;
      private string edtTSMovCBCod_Jsonclick ;
      private string edtTSMovNCuotas_Internalname ;
      private string edtTSMovNCuotas_Jsonclick ;
      private string edtTSMovImpCuota_Internalname ;
      private string edtTSMovImpCuota_Jsonclick ;
      private string edtTSMovTItem_Internalname ;
      private string edtTSMovTItem_Jsonclick ;
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
      private string Z247PrvDsc ;
      private string sMode161 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ244PrvCod ;
      private string ZZ149TipCod ;
      private string ZZ389TSMovCBCod ;
      private string ZZ247PrvDsc ;
      private DateTime Z1970TSMovFec ;
      private DateTime A1970TSMovFec ;
      private DateTime ZZ1970TSMovFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z387TSMovCod ;
      private string Z1971TSMovGls ;
      private string A387TSMovCod ;
      private string A1971TSMovGls ;
      private string ZZ387TSMovCod ;
      private string ZZ1971TSMovGls ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T004U8_A387TSMovCod ;
      private DateTime[] T004U8_A1970TSMovFec ;
      private string[] T004U8_A247PrvDsc ;
      private string[] T004U8_A1971TSMovGls ;
      private decimal[] T004U8_A1972TSMovImp ;
      private short[] T004U8_A1976TSMovNCuotas ;
      private decimal[] T004U8_A1973TSMovImpCuota ;
      private int[] T004U8_A1977TSMovTItem ;
      private int[] T004U8_A143ForCod ;
      private string[] T004U8_A244PrvCod ;
      private string[] T004U8_A149TipCod ;
      private int[] T004U8_A388TSMovBanCod ;
      private string[] T004U8_A389TSMovCBCod ;
      private int[] T004U8_A1975TSMovMonCod ;
      private int[] T004U4_A143ForCod ;
      private string[] T004U5_A247PrvDsc ;
      private string[] T004U6_A149TipCod ;
      private int[] T004U7_A1975TSMovMonCod ;
      private int[] T004U9_A143ForCod ;
      private string[] T004U10_A247PrvDsc ;
      private string[] T004U11_A149TipCod ;
      private int[] T004U12_A1975TSMovMonCod ;
      private string[] T004U13_A387TSMovCod ;
      private string[] T004U3_A387TSMovCod ;
      private DateTime[] T004U3_A1970TSMovFec ;
      private string[] T004U3_A1971TSMovGls ;
      private decimal[] T004U3_A1972TSMovImp ;
      private short[] T004U3_A1976TSMovNCuotas ;
      private decimal[] T004U3_A1973TSMovImpCuota ;
      private int[] T004U3_A1977TSMovTItem ;
      private int[] T004U3_A143ForCod ;
      private string[] T004U3_A244PrvCod ;
      private string[] T004U3_A149TipCod ;
      private int[] T004U3_A388TSMovBanCod ;
      private string[] T004U3_A389TSMovCBCod ;
      private string[] T004U14_A387TSMovCod ;
      private string[] T004U15_A387TSMovCod ;
      private string[] T004U2_A387TSMovCod ;
      private DateTime[] T004U2_A1970TSMovFec ;
      private string[] T004U2_A1971TSMovGls ;
      private decimal[] T004U2_A1972TSMovImp ;
      private short[] T004U2_A1976TSMovNCuotas ;
      private decimal[] T004U2_A1973TSMovImpCuota ;
      private int[] T004U2_A1977TSMovTItem ;
      private int[] T004U2_A143ForCod ;
      private string[] T004U2_A244PrvCod ;
      private string[] T004U2_A149TipCod ;
      private int[] T004U2_A388TSMovBanCod ;
      private string[] T004U2_A389TSMovCBCod ;
      private string[] T004U19_A247PrvDsc ;
      private int[] T004U20_A1975TSMovMonCod ;
      private string[] T004U21_A387TSMovCod ;
      private int[] T004U21_A390TSMovDItem ;
      private string[] T004U22_A387TSMovCod ;
      private int[] T004U23_A143ForCod ;
      private string[] T004U24_A149TipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsmovbancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsmovbancos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[22])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004U8;
        prmT004U8 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U4;
        prmT004U4 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT004U5;
        prmT004U5 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT004U6;
        prmT004U6 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT004U7;
        prmT004U7 = new Object[] {
        new ParDef("@TSMovBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSMovCBCod",GXType.NChar,20,0)
        };
        Object[] prmT004U9;
        prmT004U9 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT004U10;
        prmT004U10 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT004U11;
        prmT004U11 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT004U12;
        prmT004U12 = new Object[] {
        new ParDef("@TSMovBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSMovCBCod",GXType.NChar,20,0)
        };
        Object[] prmT004U13;
        prmT004U13 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U3;
        prmT004U3 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U14;
        prmT004U14 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U15;
        prmT004U15 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U2;
        prmT004U2 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U16;
        prmT004U16 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovFec",GXType.Date,8,0) ,
        new ParDef("@TSMovGls",GXType.NVarChar,100,0) ,
        new ParDef("@TSMovImp",GXType.Decimal,15,2) ,
        new ParDef("@TSMovNCuotas",GXType.Int16,4,0) ,
        new ParDef("@TSMovImpCuota",GXType.Decimal,15,2) ,
        new ParDef("@TSMovTItem",GXType.Int32,6,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@TSMovBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSMovCBCod",GXType.NChar,20,0)
        };
        Object[] prmT004U17;
        prmT004U17 = new Object[] {
        new ParDef("@TSMovFec",GXType.Date,8,0) ,
        new ParDef("@TSMovGls",GXType.NVarChar,100,0) ,
        new ParDef("@TSMovImp",GXType.Decimal,15,2) ,
        new ParDef("@TSMovNCuotas",GXType.Int16,4,0) ,
        new ParDef("@TSMovImpCuota",GXType.Decimal,15,2) ,
        new ParDef("@TSMovTItem",GXType.Int32,6,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@TSMovBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSMovCBCod",GXType.NChar,20,0) ,
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U18;
        prmT004U18 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U21;
        prmT004U21 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004U22;
        prmT004U22 = new Object[] {
        };
        Object[] prmT004U23;
        prmT004U23 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT004U19;
        prmT004U19 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT004U24;
        prmT004U24 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT004U20;
        prmT004U20 = new Object[] {
        new ParDef("@TSMovBanCod",GXType.Int32,6,0) ,
        new ParDef("@TSMovCBCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004U2", "SELECT [TSMovCod], [TSMovFec], [TSMovGls], [TSMovImp], [TSMovNCuotas], [TSMovImpCuota], [TSMovTItem], [ForCod], [PrvCod], [TipCod], [TSMovBanCod] AS TSMovBanCod, [TSMovCBCod] AS TSMovCBCod FROM [TSMOVBANCOS] WITH (UPDLOCK) WHERE [TSMovCod] = @TSMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U3", "SELECT [TSMovCod], [TSMovFec], [TSMovGls], [TSMovImp], [TSMovNCuotas], [TSMovImpCuota], [TSMovTItem], [ForCod], [PrvCod], [TipCod], [TSMovBanCod] AS TSMovBanCod, [TSMovCBCod] AS TSMovCBCod FROM [TSMOVBANCOS] WHERE [TSMovCod] = @TSMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U4", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U5", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U6", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U7", "SELECT [MonCod] AS TSMovMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @TSMovBanCod AND [CBCod] = @TSMovCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U8", "SELECT TM1.[TSMovCod], TM1.[TSMovFec], T2.[PrvDsc], TM1.[TSMovGls], TM1.[TSMovImp], TM1.[TSMovNCuotas], TM1.[TSMovImpCuota], TM1.[TSMovTItem], TM1.[ForCod], TM1.[PrvCod], TM1.[TipCod], TM1.[TSMovBanCod] AS TSMovBanCod, TM1.[TSMovCBCod] AS TSMovCBCod, T3.[MonCod] AS TSMovMonCod FROM (([TSMOVBANCOS] TM1 INNER JOIN [CPPROVEEDORES] T2 ON T2.[PrvCod] = TM1.[PrvCod]) INNER JOIN [TSCUENTABANCO] T3 ON T3.[BanCod] = TM1.[TSMovBanCod] AND T3.[CBCod] = TM1.[TSMovCBCod]) WHERE TM1.[TSMovCod] = @TSMovCod ORDER BY TM1.[TSMovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004U8,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U9", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U10", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U11", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U12", "SELECT [MonCod] AS TSMovMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @TSMovBanCod AND [CBCod] = @TSMovCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U13", "SELECT [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovCod] = @TSMovCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004U13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U14", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE ( [TSMovCod] > @TSMovCod) ORDER BY [TSMovCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004U14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004U15", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE ( [TSMovCod] < @TSMovCod) ORDER BY [TSMovCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004U15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004U16", "INSERT INTO [TSMOVBANCOS]([TSMovCod], [TSMovFec], [TSMovGls], [TSMovImp], [TSMovNCuotas], [TSMovImpCuota], [TSMovTItem], [ForCod], [PrvCod], [TipCod], [TSMovBanCod], [TSMovCBCod]) VALUES(@TSMovCod, @TSMovFec, @TSMovGls, @TSMovImp, @TSMovNCuotas, @TSMovImpCuota, @TSMovTItem, @ForCod, @PrvCod, @TipCod, @TSMovBanCod, @TSMovCBCod)", GxErrorMask.GX_NOMASK,prmT004U16)
           ,new CursorDef("T004U17", "UPDATE [TSMOVBANCOS] SET [TSMovFec]=@TSMovFec, [TSMovGls]=@TSMovGls, [TSMovImp]=@TSMovImp, [TSMovNCuotas]=@TSMovNCuotas, [TSMovImpCuota]=@TSMovImpCuota, [TSMovTItem]=@TSMovTItem, [ForCod]=@ForCod, [PrvCod]=@PrvCod, [TipCod]=@TipCod, [TSMovBanCod]=@TSMovBanCod, [TSMovCBCod]=@TSMovCBCod  WHERE [TSMovCod] = @TSMovCod", GxErrorMask.GX_NOMASK,prmT004U17)
           ,new CursorDef("T004U18", "DELETE FROM [TSMOVBANCOS]  WHERE [TSMovCod] = @TSMovCod", GxErrorMask.GX_NOMASK,prmT004U18)
           ,new CursorDef("T004U19", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U20", "SELECT [MonCod] AS TSMovMonCod FROM [TSCUENTABANCO] WHERE [BanCod] = @TSMovBanCod AND [CBCod] = @TSMovCBCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U21", "SELECT TOP 1 [TSMovCod], [TSMovDItem] FROM [TSMOVBANCOSDET] WHERE [TSMovCod] = @TSMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004U22", "SELECT [TSMovCod] FROM [TSMOVBANCOS] ORDER BY [TSMovCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004U22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U23", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004U24", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004U24,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((int[]) buf[7])[0] = rslt.getInt(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 20);
              ((string[]) buf[10])[0] = rslt.getString(11, 3);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 20);
              ((int[]) buf[13])[0] = rslt.getInt(14);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
