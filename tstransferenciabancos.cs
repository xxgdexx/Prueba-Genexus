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
   public class tstransferenciabancos : GXDataArea
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
            A424TSTransBanOrigen = (int)(NumberUtil.Val( GetPar( "TSTransBanOrigen"), "."));
            AssignAttri("", false, "A424TSTransBanOrigen", StringUtil.LTrimStr( (decimal)(A424TSTransBanOrigen), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A424TSTransBanOrigen) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A425TSTransBanDestino = (int)(NumberUtil.Val( GetPar( "TSTransBanDestino"), "."));
            AssignAttri("", false, "A425TSTransBanDestino", StringUtil.LTrimStr( (decimal)(A425TSTransBanDestino), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A425TSTransBanDestino) ;
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
            Form.Meta.addItem("description", "TSTRANSFERENCIABANCOS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTSTransCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tstransferenciabancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tstransferenciabancos( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "TSTRANSFERENCIABANCOS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_TSTRANSFERENCIABANCOS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSTRANSFERENCIABANCOS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransCod_Internalname, "Transferencia", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransCod_Internalname, A423TSTransCod, StringUtil.RTrim( context.localUtil.Format( A423TSTransCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTSTransFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTSTransFec_Internalname, context.localUtil.Format(A1984TSTransFec, "99/99/99"), context.localUtil.Format( A1984TSTransFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_bitmap( context, edtTSTransFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTSTransFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransBanOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransBanOrigen_Internalname, "Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransBanOrigen_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A424TSTransBanOrigen), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSTransBanOrigen_Enabled!=0) ? context.localUtil.Format( (decimal)(A424TSTransBanOrigen), "ZZZZZ9") : context.localUtil.Format( (decimal)(A424TSTransBanOrigen), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransBanOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransBanOrigen_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransBanOrigenDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransBanOrigenDsc_Internalname, "Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTSTransBanOrigenDsc_Internalname, StringUtil.RTrim( A1981TSTransBanOrigenDsc), StringUtil.RTrim( context.localUtil.Format( A1981TSTransBanOrigenDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransBanOrigenDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransBanOrigenDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransBanCta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransBanCta_Internalname, "Cuenta Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransBanCta_Internalname, A1978TSTransBanCta, StringUtil.RTrim( context.localUtil.Format( A1978TSTransBanCta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransBanCta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransBanCta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransConceptoOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransConceptoOrigen_Internalname, "Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransConceptoOrigen_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1983TSTransConceptoOrigen), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSTransConceptoOrigen_Enabled!=0) ? context.localUtil.Format( (decimal)(A1983TSTransConceptoOrigen), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1983TSTransConceptoOrigen), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransConceptoOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransConceptoOrigen_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransGlosaOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransGlosaOrigen_Internalname, "Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransGlosaOrigen_Internalname, A1986TSTransGlosaOrigen, StringUtil.RTrim( context.localUtil.Format( A1986TSTransGlosaOrigen, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransGlosaOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransGlosaOrigen_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransOperacionOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransOperacionOrigen_Internalname, "Operación Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransOperacionOrigen_Internalname, A1990TSTransOperacionOrigen, StringUtil.RTrim( context.localUtil.Format( A1990TSTransOperacionOrigen, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransOperacionOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransOperacionOrigen_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransImporteOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransImporteOrigen_Internalname, "Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransImporteOrigen_Internalname, StringUtil.LTrim( StringUtil.NToC( A1988TSTransImporteOrigen, 17, 2, ".", "")), StringUtil.LTrim( ((edtTSTransImporteOrigen_Enabled!=0) ? context.localUtil.Format( A1988TSTransImporteOrigen, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1988TSTransImporteOrigen, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransImporteOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransImporteOrigen_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransBanDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransBanDestino_Internalname, "Destino", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransBanDestino_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A425TSTransBanDestino), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSTransBanDestino_Enabled!=0) ? context.localUtil.Format( (decimal)(A425TSTransBanDestino), "ZZZZZ9") : context.localUtil.Format( (decimal)(A425TSTransBanDestino), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransBanDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransBanDestino_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransBanDestinoDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransBanDestinoDsc_Internalname, "Destino", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtTSTransBanDestinoDsc_Internalname, StringUtil.RTrim( A1980TSTransBanDestinoDsc), StringUtil.RTrim( context.localUtil.Format( A1980TSTransBanDestinoDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransBanDestinoDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransBanDestinoDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransBanCtaDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransBanCtaDestino_Internalname, "Cuenta Destino", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransBanCtaDestino_Internalname, A1979TSTransBanCtaDestino, StringUtil.RTrim( context.localUtil.Format( A1979TSTransBanCtaDestino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransBanCtaDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransBanCtaDestino_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransConceptoDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransConceptoDestino_Internalname, "Destino", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransConceptoDestino_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1982TSTransConceptoDestino), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSTransConceptoDestino_Enabled!=0) ? context.localUtil.Format( (decimal)(A1982TSTransConceptoDestino), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1982TSTransConceptoDestino), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransConceptoDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransConceptoDestino_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransGlosaDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransGlosaDestino_Internalname, "Destino", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransGlosaDestino_Internalname, A1985TSTransGlosaDestino, StringUtil.RTrim( context.localUtil.Format( A1985TSTransGlosaDestino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransGlosaDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransGlosaDestino_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransOperacionDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransOperacionDestino_Internalname, "Operación Destino", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransOperacionDestino_Internalname, A1989TSTransOperacionDestino, StringUtil.RTrim( context.localUtil.Format( A1989TSTransOperacionDestino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransOperacionDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransOperacionDestino_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransTipoCambio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransTipoCambio_Internalname, "Cambio", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransTipoCambio_Internalname, StringUtil.LTrim( StringUtil.NToC( A1993TSTransTipoCambio, 17, 4, ".", "")), StringUtil.LTrim( ((edtTSTransTipoCambio_Enabled!=0) ? context.localUtil.Format( A1993TSTransTipoCambio, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1993TSTransTipoCambio, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,108);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransTipoCambio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransTipoCambio_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransImporteDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransImporteDestino_Internalname, "Destino", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransImporteDestino_Internalname, StringUtil.LTrim( StringUtil.NToC( A1987TSTransImporteDestino, 17, 2, ".", "")), StringUtil.LTrim( ((edtTSTransImporteDestino_Enabled!=0) ? context.localUtil.Format( A1987TSTransImporteDestino, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1987TSTransImporteDestino, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,113);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransImporteDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransImporteDestino_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransRegDestino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransRegDestino_Internalname, "Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransRegDestino_Internalname, A1991TSTransRegDestino, StringUtil.RTrim( context.localUtil.Format( A1991TSTransRegDestino, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransRegDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransRegDestino_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSTransRegOrigen_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSTransRegOrigen_Internalname, "Origen", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSTransRegOrigen_Internalname, A1992TSTransRegOrigen, StringUtil.RTrim( context.localUtil.Format( A1992TSTransRegOrigen, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSTransRegOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSTransRegOrigen_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSTRANSFERENCIABANCOS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 130,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSTRANSFERENCIABANCOS.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 132,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSTRANSFERENCIABANCOS.htm");
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
            Z423TSTransCod = cgiGet( "Z423TSTransCod");
            Z1984TSTransFec = context.localUtil.CToD( cgiGet( "Z1984TSTransFec"), 0);
            Z1978TSTransBanCta = cgiGet( "Z1978TSTransBanCta");
            Z1983TSTransConceptoOrigen = (int)(context.localUtil.CToN( cgiGet( "Z1983TSTransConceptoOrigen"), ".", ","));
            Z1986TSTransGlosaOrigen = cgiGet( "Z1986TSTransGlosaOrigen");
            Z1990TSTransOperacionOrigen = cgiGet( "Z1990TSTransOperacionOrigen");
            Z1988TSTransImporteOrigen = context.localUtil.CToN( cgiGet( "Z1988TSTransImporteOrigen"), ".", ",");
            Z1979TSTransBanCtaDestino = cgiGet( "Z1979TSTransBanCtaDestino");
            Z1982TSTransConceptoDestino = (int)(context.localUtil.CToN( cgiGet( "Z1982TSTransConceptoDestino"), ".", ","));
            Z1985TSTransGlosaDestino = cgiGet( "Z1985TSTransGlosaDestino");
            Z1989TSTransOperacionDestino = cgiGet( "Z1989TSTransOperacionDestino");
            Z1993TSTransTipoCambio = context.localUtil.CToN( cgiGet( "Z1993TSTransTipoCambio"), ".", ",");
            Z1987TSTransImporteDestino = context.localUtil.CToN( cgiGet( "Z1987TSTransImporteDestino"), ".", ",");
            Z1991TSTransRegDestino = cgiGet( "Z1991TSTransRegDestino");
            Z1992TSTransRegOrigen = cgiGet( "Z1992TSTransRegOrigen");
            Z143ForCod = (int)(context.localUtil.CToN( cgiGet( "Z143ForCod"), ".", ","));
            Z424TSTransBanOrigen = (int)(context.localUtil.CToN( cgiGet( "Z424TSTransBanOrigen"), ".", ","));
            Z425TSTransBanDestino = (int)(context.localUtil.CToN( cgiGet( "Z425TSTransBanDestino"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A423TSTransCod = cgiGet( edtTSTransCod_Internalname);
            AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
            if ( context.localUtil.VCDate( cgiGet( edtTSTransFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "TSTRANSFEC");
               AnyError = 1;
               GX_FocusControl = edtTSTransFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1984TSTransFec = DateTime.MinValue;
               AssignAttri("", false, "A1984TSTransFec", context.localUtil.Format(A1984TSTransFec, "99/99/99"));
            }
            else
            {
               A1984TSTransFec = context.localUtil.CToD( cgiGet( edtTSTransFec_Internalname), 2);
               AssignAttri("", false, "A1984TSTransFec", context.localUtil.Format(A1984TSTransFec, "99/99/99"));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSTransBanOrigen_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSTransBanOrigen_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSTRANSBANORIGEN");
               AnyError = 1;
               GX_FocusControl = edtTSTransBanOrigen_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A424TSTransBanOrigen = 0;
               AssignAttri("", false, "A424TSTransBanOrigen", StringUtil.LTrimStr( (decimal)(A424TSTransBanOrigen), 6, 0));
            }
            else
            {
               A424TSTransBanOrigen = (int)(context.localUtil.CToN( cgiGet( edtTSTransBanOrigen_Internalname), ".", ","));
               AssignAttri("", false, "A424TSTransBanOrigen", StringUtil.LTrimStr( (decimal)(A424TSTransBanOrigen), 6, 0));
            }
            A1981TSTransBanOrigenDsc = cgiGet( edtTSTransBanOrigenDsc_Internalname);
            AssignAttri("", false, "A1981TSTransBanOrigenDsc", A1981TSTransBanOrigenDsc);
            A1978TSTransBanCta = cgiGet( edtTSTransBanCta_Internalname);
            AssignAttri("", false, "A1978TSTransBanCta", A1978TSTransBanCta);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSTransConceptoOrigen_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSTransConceptoOrigen_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSTRANSCONCEPTOORIGEN");
               AnyError = 1;
               GX_FocusControl = edtTSTransConceptoOrigen_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1983TSTransConceptoOrigen = 0;
               AssignAttri("", false, "A1983TSTransConceptoOrigen", StringUtil.LTrimStr( (decimal)(A1983TSTransConceptoOrigen), 6, 0));
            }
            else
            {
               A1983TSTransConceptoOrigen = (int)(context.localUtil.CToN( cgiGet( edtTSTransConceptoOrigen_Internalname), ".", ","));
               AssignAttri("", false, "A1983TSTransConceptoOrigen", StringUtil.LTrimStr( (decimal)(A1983TSTransConceptoOrigen), 6, 0));
            }
            A1986TSTransGlosaOrigen = cgiGet( edtTSTransGlosaOrigen_Internalname);
            AssignAttri("", false, "A1986TSTransGlosaOrigen", A1986TSTransGlosaOrigen);
            A1990TSTransOperacionOrigen = cgiGet( edtTSTransOperacionOrigen_Internalname);
            AssignAttri("", false, "A1990TSTransOperacionOrigen", A1990TSTransOperacionOrigen);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSTransImporteOrigen_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTSTransImporteOrigen_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSTRANSIMPORTEORIGEN");
               AnyError = 1;
               GX_FocusControl = edtTSTransImporteOrigen_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1988TSTransImporteOrigen = 0;
               AssignAttri("", false, "A1988TSTransImporteOrigen", StringUtil.LTrimStr( A1988TSTransImporteOrigen, 15, 2));
            }
            else
            {
               A1988TSTransImporteOrigen = context.localUtil.CToN( cgiGet( edtTSTransImporteOrigen_Internalname), ".", ",");
               AssignAttri("", false, "A1988TSTransImporteOrigen", StringUtil.LTrimStr( A1988TSTransImporteOrigen, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSTransBanDestino_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSTransBanDestino_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSTRANSBANDESTINO");
               AnyError = 1;
               GX_FocusControl = edtTSTransBanDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A425TSTransBanDestino = 0;
               AssignAttri("", false, "A425TSTransBanDestino", StringUtil.LTrimStr( (decimal)(A425TSTransBanDestino), 6, 0));
            }
            else
            {
               A425TSTransBanDestino = (int)(context.localUtil.CToN( cgiGet( edtTSTransBanDestino_Internalname), ".", ","));
               AssignAttri("", false, "A425TSTransBanDestino", StringUtil.LTrimStr( (decimal)(A425TSTransBanDestino), 6, 0));
            }
            A1980TSTransBanDestinoDsc = cgiGet( edtTSTransBanDestinoDsc_Internalname);
            AssignAttri("", false, "A1980TSTransBanDestinoDsc", A1980TSTransBanDestinoDsc);
            A1979TSTransBanCtaDestino = cgiGet( edtTSTransBanCtaDestino_Internalname);
            AssignAttri("", false, "A1979TSTransBanCtaDestino", A1979TSTransBanCtaDestino);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSTransConceptoDestino_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSTransConceptoDestino_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSTRANSCONCEPTODESTINO");
               AnyError = 1;
               GX_FocusControl = edtTSTransConceptoDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1982TSTransConceptoDestino = 0;
               AssignAttri("", false, "A1982TSTransConceptoDestino", StringUtil.LTrimStr( (decimal)(A1982TSTransConceptoDestino), 6, 0));
            }
            else
            {
               A1982TSTransConceptoDestino = (int)(context.localUtil.CToN( cgiGet( edtTSTransConceptoDestino_Internalname), ".", ","));
               AssignAttri("", false, "A1982TSTransConceptoDestino", StringUtil.LTrimStr( (decimal)(A1982TSTransConceptoDestino), 6, 0));
            }
            A1985TSTransGlosaDestino = cgiGet( edtTSTransGlosaDestino_Internalname);
            AssignAttri("", false, "A1985TSTransGlosaDestino", A1985TSTransGlosaDestino);
            A1989TSTransOperacionDestino = cgiGet( edtTSTransOperacionDestino_Internalname);
            AssignAttri("", false, "A1989TSTransOperacionDestino", A1989TSTransOperacionDestino);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSTransTipoCambio_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTSTransTipoCambio_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSTRANSTIPOCAMBIO");
               AnyError = 1;
               GX_FocusControl = edtTSTransTipoCambio_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1993TSTransTipoCambio = 0;
               AssignAttri("", false, "A1993TSTransTipoCambio", StringUtil.LTrimStr( A1993TSTransTipoCambio, 15, 4));
            }
            else
            {
               A1993TSTransTipoCambio = context.localUtil.CToN( cgiGet( edtTSTransTipoCambio_Internalname), ".", ",");
               AssignAttri("", false, "A1993TSTransTipoCambio", StringUtil.LTrimStr( A1993TSTransTipoCambio, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSTransImporteDestino_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTSTransImporteDestino_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSTRANSIMPORTEDESTINO");
               AnyError = 1;
               GX_FocusControl = edtTSTransImporteDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1987TSTransImporteDestino = 0;
               AssignAttri("", false, "A1987TSTransImporteDestino", StringUtil.LTrimStr( A1987TSTransImporteDestino, 15, 2));
            }
            else
            {
               A1987TSTransImporteDestino = context.localUtil.CToN( cgiGet( edtTSTransImporteDestino_Internalname), ".", ",");
               AssignAttri("", false, "A1987TSTransImporteDestino", StringUtil.LTrimStr( A1987TSTransImporteDestino, 15, 2));
            }
            A1991TSTransRegDestino = cgiGet( edtTSTransRegDestino_Internalname);
            AssignAttri("", false, "A1991TSTransRegDestino", A1991TSTransRegDestino);
            A1992TSTransRegOrigen = cgiGet( edtTSTransRegOrigen_Internalname);
            AssignAttri("", false, "A1992TSTransRegOrigen", A1992TSTransRegOrigen);
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
               A423TSTransCod = GetPar( "TSTransCod");
               AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
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
               InitAll4X164( ) ;
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
         DisableAttributes4X164( ) ;
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

      protected void ResetCaption4X0( )
      {
      }

      protected void ZM4X164( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1984TSTransFec = T004X3_A1984TSTransFec[0];
               Z1978TSTransBanCta = T004X3_A1978TSTransBanCta[0];
               Z1983TSTransConceptoOrigen = T004X3_A1983TSTransConceptoOrigen[0];
               Z1986TSTransGlosaOrigen = T004X3_A1986TSTransGlosaOrigen[0];
               Z1990TSTransOperacionOrigen = T004X3_A1990TSTransOperacionOrigen[0];
               Z1988TSTransImporteOrigen = T004X3_A1988TSTransImporteOrigen[0];
               Z1979TSTransBanCtaDestino = T004X3_A1979TSTransBanCtaDestino[0];
               Z1982TSTransConceptoDestino = T004X3_A1982TSTransConceptoDestino[0];
               Z1985TSTransGlosaDestino = T004X3_A1985TSTransGlosaDestino[0];
               Z1989TSTransOperacionDestino = T004X3_A1989TSTransOperacionDestino[0];
               Z1993TSTransTipoCambio = T004X3_A1993TSTransTipoCambio[0];
               Z1987TSTransImporteDestino = T004X3_A1987TSTransImporteDestino[0];
               Z1991TSTransRegDestino = T004X3_A1991TSTransRegDestino[0];
               Z1992TSTransRegOrigen = T004X3_A1992TSTransRegOrigen[0];
               Z143ForCod = T004X3_A143ForCod[0];
               Z424TSTransBanOrigen = T004X3_A424TSTransBanOrigen[0];
               Z425TSTransBanDestino = T004X3_A425TSTransBanDestino[0];
            }
            else
            {
               Z1984TSTransFec = A1984TSTransFec;
               Z1978TSTransBanCta = A1978TSTransBanCta;
               Z1983TSTransConceptoOrigen = A1983TSTransConceptoOrigen;
               Z1986TSTransGlosaOrigen = A1986TSTransGlosaOrigen;
               Z1990TSTransOperacionOrigen = A1990TSTransOperacionOrigen;
               Z1988TSTransImporteOrigen = A1988TSTransImporteOrigen;
               Z1979TSTransBanCtaDestino = A1979TSTransBanCtaDestino;
               Z1982TSTransConceptoDestino = A1982TSTransConceptoDestino;
               Z1985TSTransGlosaDestino = A1985TSTransGlosaDestino;
               Z1989TSTransOperacionDestino = A1989TSTransOperacionDestino;
               Z1993TSTransTipoCambio = A1993TSTransTipoCambio;
               Z1987TSTransImporteDestino = A1987TSTransImporteDestino;
               Z1991TSTransRegDestino = A1991TSTransRegDestino;
               Z1992TSTransRegOrigen = A1992TSTransRegOrigen;
               Z143ForCod = A143ForCod;
               Z424TSTransBanOrigen = A424TSTransBanOrigen;
               Z425TSTransBanDestino = A425TSTransBanDestino;
            }
         }
         if ( GX_JID == -2 )
         {
            Z423TSTransCod = A423TSTransCod;
            Z1984TSTransFec = A1984TSTransFec;
            Z1978TSTransBanCta = A1978TSTransBanCta;
            Z1983TSTransConceptoOrigen = A1983TSTransConceptoOrigen;
            Z1986TSTransGlosaOrigen = A1986TSTransGlosaOrigen;
            Z1990TSTransOperacionOrigen = A1990TSTransOperacionOrigen;
            Z1988TSTransImporteOrigen = A1988TSTransImporteOrigen;
            Z1979TSTransBanCtaDestino = A1979TSTransBanCtaDestino;
            Z1982TSTransConceptoDestino = A1982TSTransConceptoDestino;
            Z1985TSTransGlosaDestino = A1985TSTransGlosaDestino;
            Z1989TSTransOperacionDestino = A1989TSTransOperacionDestino;
            Z1993TSTransTipoCambio = A1993TSTransTipoCambio;
            Z1987TSTransImporteDestino = A1987TSTransImporteDestino;
            Z1991TSTransRegDestino = A1991TSTransRegDestino;
            Z1992TSTransRegOrigen = A1992TSTransRegOrigen;
            Z143ForCod = A143ForCod;
            Z424TSTransBanOrigen = A424TSTransBanOrigen;
            Z425TSTransBanDestino = A425TSTransBanDestino;
            Z1981TSTransBanOrigenDsc = A1981TSTransBanOrigenDsc;
            Z1980TSTransBanDestinoDsc = A1980TSTransBanDestinoDsc;
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

      protected void Load4X164( )
      {
         /* Using cursor T004X7 */
         pr_default.execute(5, new Object[] {A423TSTransCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound164 = 1;
            A1984TSTransFec = T004X7_A1984TSTransFec[0];
            AssignAttri("", false, "A1984TSTransFec", context.localUtil.Format(A1984TSTransFec, "99/99/99"));
            A1981TSTransBanOrigenDsc = T004X7_A1981TSTransBanOrigenDsc[0];
            AssignAttri("", false, "A1981TSTransBanOrigenDsc", A1981TSTransBanOrigenDsc);
            A1978TSTransBanCta = T004X7_A1978TSTransBanCta[0];
            AssignAttri("", false, "A1978TSTransBanCta", A1978TSTransBanCta);
            A1983TSTransConceptoOrigen = T004X7_A1983TSTransConceptoOrigen[0];
            AssignAttri("", false, "A1983TSTransConceptoOrigen", StringUtil.LTrimStr( (decimal)(A1983TSTransConceptoOrigen), 6, 0));
            A1986TSTransGlosaOrigen = T004X7_A1986TSTransGlosaOrigen[0];
            AssignAttri("", false, "A1986TSTransGlosaOrigen", A1986TSTransGlosaOrigen);
            A1990TSTransOperacionOrigen = T004X7_A1990TSTransOperacionOrigen[0];
            AssignAttri("", false, "A1990TSTransOperacionOrigen", A1990TSTransOperacionOrigen);
            A1988TSTransImporteOrigen = T004X7_A1988TSTransImporteOrigen[0];
            AssignAttri("", false, "A1988TSTransImporteOrigen", StringUtil.LTrimStr( A1988TSTransImporteOrigen, 15, 2));
            A1980TSTransBanDestinoDsc = T004X7_A1980TSTransBanDestinoDsc[0];
            AssignAttri("", false, "A1980TSTransBanDestinoDsc", A1980TSTransBanDestinoDsc);
            A1979TSTransBanCtaDestino = T004X7_A1979TSTransBanCtaDestino[0];
            AssignAttri("", false, "A1979TSTransBanCtaDestino", A1979TSTransBanCtaDestino);
            A1982TSTransConceptoDestino = T004X7_A1982TSTransConceptoDestino[0];
            AssignAttri("", false, "A1982TSTransConceptoDestino", StringUtil.LTrimStr( (decimal)(A1982TSTransConceptoDestino), 6, 0));
            A1985TSTransGlosaDestino = T004X7_A1985TSTransGlosaDestino[0];
            AssignAttri("", false, "A1985TSTransGlosaDestino", A1985TSTransGlosaDestino);
            A1989TSTransOperacionDestino = T004X7_A1989TSTransOperacionDestino[0];
            AssignAttri("", false, "A1989TSTransOperacionDestino", A1989TSTransOperacionDestino);
            A1993TSTransTipoCambio = T004X7_A1993TSTransTipoCambio[0];
            AssignAttri("", false, "A1993TSTransTipoCambio", StringUtil.LTrimStr( A1993TSTransTipoCambio, 15, 4));
            A1987TSTransImporteDestino = T004X7_A1987TSTransImporteDestino[0];
            AssignAttri("", false, "A1987TSTransImporteDestino", StringUtil.LTrimStr( A1987TSTransImporteDestino, 15, 2));
            A1991TSTransRegDestino = T004X7_A1991TSTransRegDestino[0];
            AssignAttri("", false, "A1991TSTransRegDestino", A1991TSTransRegDestino);
            A1992TSTransRegOrigen = T004X7_A1992TSTransRegOrigen[0];
            AssignAttri("", false, "A1992TSTransRegOrigen", A1992TSTransRegOrigen);
            A143ForCod = T004X7_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A424TSTransBanOrigen = T004X7_A424TSTransBanOrigen[0];
            AssignAttri("", false, "A424TSTransBanOrigen", StringUtil.LTrimStr( (decimal)(A424TSTransBanOrigen), 6, 0));
            A425TSTransBanDestino = T004X7_A425TSTransBanDestino[0];
            AssignAttri("", false, "A425TSTransBanDestino", StringUtil.LTrimStr( (decimal)(A425TSTransBanDestino), 6, 0));
            ZM4X164( -2) ;
         }
         pr_default.close(5);
         OnLoadActions4X164( ) ;
      }

      protected void OnLoadActions4X164( )
      {
      }

      protected void CheckExtendedTable4X164( )
      {
         nIsDirty_164 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A1984TSTransFec) || ( DateTimeUtil.ResetTime ( A1984TSTransFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "TSTRANSFEC");
            AnyError = 1;
            GX_FocusControl = edtTSTransFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T004X4 */
         pr_default.execute(2, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T004X5 */
         pr_default.execute(3, new Object[] {A424TSTransBanOrigen});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco Origen'.", "ForeignKeyNotFound", 1, "TSTRANSBANORIGEN");
            AnyError = 1;
            GX_FocusControl = edtTSTransBanOrigen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1981TSTransBanOrigenDsc = T004X5_A1981TSTransBanOrigenDsc[0];
         AssignAttri("", false, "A1981TSTransBanOrigenDsc", A1981TSTransBanOrigenDsc);
         pr_default.close(3);
         /* Using cursor T004X6 */
         pr_default.execute(4, new Object[] {A425TSTransBanDestino});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos Destino'.", "ForeignKeyNotFound", 1, "TSTRANSBANDESTINO");
            AnyError = 1;
            GX_FocusControl = edtTSTransBanDestino_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1980TSTransBanDestinoDsc = T004X6_A1980TSTransBanDestinoDsc[0];
         AssignAttri("", false, "A1980TSTransBanDestinoDsc", A1980TSTransBanDestinoDsc);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors4X164( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( int A143ForCod )
      {
         /* Using cursor T004X8 */
         pr_default.execute(6, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
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

      protected void gxLoad_4( int A424TSTransBanOrigen )
      {
         /* Using cursor T004X9 */
         pr_default.execute(7, new Object[] {A424TSTransBanOrigen});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco Origen'.", "ForeignKeyNotFound", 1, "TSTRANSBANORIGEN");
            AnyError = 1;
            GX_FocusControl = edtTSTransBanOrigen_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1981TSTransBanOrigenDsc = T004X9_A1981TSTransBanOrigenDsc[0];
         AssignAttri("", false, "A1981TSTransBanOrigenDsc", A1981TSTransBanOrigenDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1981TSTransBanOrigenDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_5( int A425TSTransBanDestino )
      {
         /* Using cursor T004X10 */
         pr_default.execute(8, new Object[] {A425TSTransBanDestino});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos Destino'.", "ForeignKeyNotFound", 1, "TSTRANSBANDESTINO");
            AnyError = 1;
            GX_FocusControl = edtTSTransBanDestino_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1980TSTransBanDestinoDsc = T004X10_A1980TSTransBanDestinoDsc[0];
         AssignAttri("", false, "A1980TSTransBanDestinoDsc", A1980TSTransBanDestinoDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1980TSTransBanDestinoDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey4X164( )
      {
         /* Using cursor T004X11 */
         pr_default.execute(9, new Object[] {A423TSTransCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound164 = 1;
         }
         else
         {
            RcdFound164 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004X3 */
         pr_default.execute(1, new Object[] {A423TSTransCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4X164( 2) ;
            RcdFound164 = 1;
            A423TSTransCod = T004X3_A423TSTransCod[0];
            AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
            A1984TSTransFec = T004X3_A1984TSTransFec[0];
            AssignAttri("", false, "A1984TSTransFec", context.localUtil.Format(A1984TSTransFec, "99/99/99"));
            A1978TSTransBanCta = T004X3_A1978TSTransBanCta[0];
            AssignAttri("", false, "A1978TSTransBanCta", A1978TSTransBanCta);
            A1983TSTransConceptoOrigen = T004X3_A1983TSTransConceptoOrigen[0];
            AssignAttri("", false, "A1983TSTransConceptoOrigen", StringUtil.LTrimStr( (decimal)(A1983TSTransConceptoOrigen), 6, 0));
            A1986TSTransGlosaOrigen = T004X3_A1986TSTransGlosaOrigen[0];
            AssignAttri("", false, "A1986TSTransGlosaOrigen", A1986TSTransGlosaOrigen);
            A1990TSTransOperacionOrigen = T004X3_A1990TSTransOperacionOrigen[0];
            AssignAttri("", false, "A1990TSTransOperacionOrigen", A1990TSTransOperacionOrigen);
            A1988TSTransImporteOrigen = T004X3_A1988TSTransImporteOrigen[0];
            AssignAttri("", false, "A1988TSTransImporteOrigen", StringUtil.LTrimStr( A1988TSTransImporteOrigen, 15, 2));
            A1979TSTransBanCtaDestino = T004X3_A1979TSTransBanCtaDestino[0];
            AssignAttri("", false, "A1979TSTransBanCtaDestino", A1979TSTransBanCtaDestino);
            A1982TSTransConceptoDestino = T004X3_A1982TSTransConceptoDestino[0];
            AssignAttri("", false, "A1982TSTransConceptoDestino", StringUtil.LTrimStr( (decimal)(A1982TSTransConceptoDestino), 6, 0));
            A1985TSTransGlosaDestino = T004X3_A1985TSTransGlosaDestino[0];
            AssignAttri("", false, "A1985TSTransGlosaDestino", A1985TSTransGlosaDestino);
            A1989TSTransOperacionDestino = T004X3_A1989TSTransOperacionDestino[0];
            AssignAttri("", false, "A1989TSTransOperacionDestino", A1989TSTransOperacionDestino);
            A1993TSTransTipoCambio = T004X3_A1993TSTransTipoCambio[0];
            AssignAttri("", false, "A1993TSTransTipoCambio", StringUtil.LTrimStr( A1993TSTransTipoCambio, 15, 4));
            A1987TSTransImporteDestino = T004X3_A1987TSTransImporteDestino[0];
            AssignAttri("", false, "A1987TSTransImporteDestino", StringUtil.LTrimStr( A1987TSTransImporteDestino, 15, 2));
            A1991TSTransRegDestino = T004X3_A1991TSTransRegDestino[0];
            AssignAttri("", false, "A1991TSTransRegDestino", A1991TSTransRegDestino);
            A1992TSTransRegOrigen = T004X3_A1992TSTransRegOrigen[0];
            AssignAttri("", false, "A1992TSTransRegOrigen", A1992TSTransRegOrigen);
            A143ForCod = T004X3_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A424TSTransBanOrigen = T004X3_A424TSTransBanOrigen[0];
            AssignAttri("", false, "A424TSTransBanOrigen", StringUtil.LTrimStr( (decimal)(A424TSTransBanOrigen), 6, 0));
            A425TSTransBanDestino = T004X3_A425TSTransBanDestino[0];
            AssignAttri("", false, "A425TSTransBanDestino", StringUtil.LTrimStr( (decimal)(A425TSTransBanDestino), 6, 0));
            Z423TSTransCod = A423TSTransCod;
            sMode164 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4X164( ) ;
            if ( AnyError == 1 )
            {
               RcdFound164 = 0;
               InitializeNonKey4X164( ) ;
            }
            Gx_mode = sMode164;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound164 = 0;
            InitializeNonKey4X164( ) ;
            sMode164 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode164;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4X164( ) ;
         if ( RcdFound164 == 0 )
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
         RcdFound164 = 0;
         /* Using cursor T004X12 */
         pr_default.execute(10, new Object[] {A423TSTransCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T004X12_A423TSTransCod[0], A423TSTransCod) < 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( StringUtil.StrCmp(T004X12_A423TSTransCod[0], A423TSTransCod) > 0 ) ) )
            {
               A423TSTransCod = T004X12_A423TSTransCod[0];
               AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
               RcdFound164 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound164 = 0;
         /* Using cursor T004X13 */
         pr_default.execute(11, new Object[] {A423TSTransCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T004X13_A423TSTransCod[0], A423TSTransCod) > 0 ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( StringUtil.StrCmp(T004X13_A423TSTransCod[0], A423TSTransCod) < 0 ) ) )
            {
               A423TSTransCod = T004X13_A423TSTransCod[0];
               AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
               RcdFound164 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4X164( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTSTransCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4X164( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound164 == 1 )
            {
               if ( StringUtil.StrCmp(A423TSTransCod, Z423TSTransCod) != 0 )
               {
                  A423TSTransCod = Z423TSTransCod;
                  AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TSTRANSCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTSTransCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTSTransCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update4X164( ) ;
                  GX_FocusControl = edtTSTransCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A423TSTransCod, Z423TSTransCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTSTransCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4X164( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TSTRANSCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTSTransCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTSTransCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert4X164( ) ;
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
         if ( StringUtil.StrCmp(A423TSTransCod, Z423TSTransCod) != 0 )
         {
            A423TSTransCod = Z423TSTransCod;
            AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TSTRANSCOD");
            AnyError = 1;
            GX_FocusControl = edtTSTransCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTSTransCod_Internalname;
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
         if ( RcdFound164 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TSTRANSCOD");
            AnyError = 1;
            GX_FocusControl = edtTSTransCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTSTransFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4X164( ) ;
         if ( RcdFound164 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSTransFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4X164( ) ;
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
         if ( RcdFound164 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSTransFec_Internalname;
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
         if ( RcdFound164 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSTransFec_Internalname;
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
         ScanStart4X164( ) ;
         if ( RcdFound164 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound164 != 0 )
            {
               ScanNext4X164( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSTransFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4X164( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4X164( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004X2 */
            pr_default.execute(0, new Object[] {A423TSTransCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSTRANSFERENCIABANCOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1984TSTransFec ) != DateTimeUtil.ResetTime ( T004X2_A1984TSTransFec[0] ) ) || ( StringUtil.StrCmp(Z1978TSTransBanCta, T004X2_A1978TSTransBanCta[0]) != 0 ) || ( Z1983TSTransConceptoOrigen != T004X2_A1983TSTransConceptoOrigen[0] ) || ( StringUtil.StrCmp(Z1986TSTransGlosaOrigen, T004X2_A1986TSTransGlosaOrigen[0]) != 0 ) || ( StringUtil.StrCmp(Z1990TSTransOperacionOrigen, T004X2_A1990TSTransOperacionOrigen[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1988TSTransImporteOrigen != T004X2_A1988TSTransImporteOrigen[0] ) || ( StringUtil.StrCmp(Z1979TSTransBanCtaDestino, T004X2_A1979TSTransBanCtaDestino[0]) != 0 ) || ( Z1982TSTransConceptoDestino != T004X2_A1982TSTransConceptoDestino[0] ) || ( StringUtil.StrCmp(Z1985TSTransGlosaDestino, T004X2_A1985TSTransGlosaDestino[0]) != 0 ) || ( StringUtil.StrCmp(Z1989TSTransOperacionDestino, T004X2_A1989TSTransOperacionDestino[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1993TSTransTipoCambio != T004X2_A1993TSTransTipoCambio[0] ) || ( Z1987TSTransImporteDestino != T004X2_A1987TSTransImporteDestino[0] ) || ( StringUtil.StrCmp(Z1991TSTransRegDestino, T004X2_A1991TSTransRegDestino[0]) != 0 ) || ( StringUtil.StrCmp(Z1992TSTransRegOrigen, T004X2_A1992TSTransRegOrigen[0]) != 0 ) || ( Z143ForCod != T004X2_A143ForCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z424TSTransBanOrigen != T004X2_A424TSTransBanOrigen[0] ) || ( Z425TSTransBanDestino != T004X2_A425TSTransBanDestino[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1984TSTransFec ) != DateTimeUtil.ResetTime ( T004X2_A1984TSTransFec[0] ) )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransFec");
                  GXUtil.WriteLogRaw("Old: ",Z1984TSTransFec);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1984TSTransFec[0]);
               }
               if ( StringUtil.StrCmp(Z1978TSTransBanCta, T004X2_A1978TSTransBanCta[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransBanCta");
                  GXUtil.WriteLogRaw("Old: ",Z1978TSTransBanCta);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1978TSTransBanCta[0]);
               }
               if ( Z1983TSTransConceptoOrigen != T004X2_A1983TSTransConceptoOrigen[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransConceptoOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z1983TSTransConceptoOrigen);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1983TSTransConceptoOrigen[0]);
               }
               if ( StringUtil.StrCmp(Z1986TSTransGlosaOrigen, T004X2_A1986TSTransGlosaOrigen[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransGlosaOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z1986TSTransGlosaOrigen);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1986TSTransGlosaOrigen[0]);
               }
               if ( StringUtil.StrCmp(Z1990TSTransOperacionOrigen, T004X2_A1990TSTransOperacionOrigen[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransOperacionOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z1990TSTransOperacionOrigen);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1990TSTransOperacionOrigen[0]);
               }
               if ( Z1988TSTransImporteOrigen != T004X2_A1988TSTransImporteOrigen[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransImporteOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z1988TSTransImporteOrigen);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1988TSTransImporteOrigen[0]);
               }
               if ( StringUtil.StrCmp(Z1979TSTransBanCtaDestino, T004X2_A1979TSTransBanCtaDestino[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransBanCtaDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1979TSTransBanCtaDestino);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1979TSTransBanCtaDestino[0]);
               }
               if ( Z1982TSTransConceptoDestino != T004X2_A1982TSTransConceptoDestino[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransConceptoDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1982TSTransConceptoDestino);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1982TSTransConceptoDestino[0]);
               }
               if ( StringUtil.StrCmp(Z1985TSTransGlosaDestino, T004X2_A1985TSTransGlosaDestino[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransGlosaDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1985TSTransGlosaDestino);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1985TSTransGlosaDestino[0]);
               }
               if ( StringUtil.StrCmp(Z1989TSTransOperacionDestino, T004X2_A1989TSTransOperacionDestino[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransOperacionDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1989TSTransOperacionDestino);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1989TSTransOperacionDestino[0]);
               }
               if ( Z1993TSTransTipoCambio != T004X2_A1993TSTransTipoCambio[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransTipoCambio");
                  GXUtil.WriteLogRaw("Old: ",Z1993TSTransTipoCambio);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1993TSTransTipoCambio[0]);
               }
               if ( Z1987TSTransImporteDestino != T004X2_A1987TSTransImporteDestino[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransImporteDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1987TSTransImporteDestino);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1987TSTransImporteDestino[0]);
               }
               if ( StringUtil.StrCmp(Z1991TSTransRegDestino, T004X2_A1991TSTransRegDestino[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransRegDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1991TSTransRegDestino);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1991TSTransRegDestino[0]);
               }
               if ( StringUtil.StrCmp(Z1992TSTransRegOrigen, T004X2_A1992TSTransRegOrigen[0]) != 0 )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransRegOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z1992TSTransRegOrigen);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A1992TSTransRegOrigen[0]);
               }
               if ( Z143ForCod != T004X2_A143ForCod[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"ForCod");
                  GXUtil.WriteLogRaw("Old: ",Z143ForCod);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A143ForCod[0]);
               }
               if ( Z424TSTransBanOrigen != T004X2_A424TSTransBanOrigen[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransBanOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z424TSTransBanOrigen);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A424TSTransBanOrigen[0]);
               }
               if ( Z425TSTransBanDestino != T004X2_A425TSTransBanDestino[0] )
               {
                  GXUtil.WriteLog("tstransferenciabancos:[seudo value changed for attri]"+"TSTransBanDestino");
                  GXUtil.WriteLogRaw("Old: ",Z425TSTransBanDestino);
                  GXUtil.WriteLogRaw("Current: ",T004X2_A425TSTransBanDestino[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSTRANSFERENCIABANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4X164( )
      {
         BeforeValidate4X164( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4X164( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4X164( 0) ;
            CheckOptimisticConcurrency4X164( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4X164( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4X164( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004X14 */
                     pr_default.execute(12, new Object[] {A423TSTransCod, A1984TSTransFec, A1978TSTransBanCta, A1983TSTransConceptoOrigen, A1986TSTransGlosaOrigen, A1990TSTransOperacionOrigen, A1988TSTransImporteOrigen, A1979TSTransBanCtaDestino, A1982TSTransConceptoDestino, A1985TSTransGlosaDestino, A1989TSTransOperacionDestino, A1993TSTransTipoCambio, A1987TSTransImporteDestino, A1991TSTransRegDestino, A1992TSTransRegOrigen, A143ForCod, A424TSTransBanOrigen, A425TSTransBanDestino});
                     pr_default.close(12);
                     dsDefault.SmartCacheProvider.SetUpdated("TSTRANSFERENCIABANCOS");
                     if ( (pr_default.getStatus(12) == 1) )
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
                           ResetCaption4X0( ) ;
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
               Load4X164( ) ;
            }
            EndLevel4X164( ) ;
         }
         CloseExtendedTableCursors4X164( ) ;
      }

      protected void Update4X164( )
      {
         BeforeValidate4X164( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4X164( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4X164( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4X164( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4X164( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004X15 */
                     pr_default.execute(13, new Object[] {A1984TSTransFec, A1978TSTransBanCta, A1983TSTransConceptoOrigen, A1986TSTransGlosaOrigen, A1990TSTransOperacionOrigen, A1988TSTransImporteOrigen, A1979TSTransBanCtaDestino, A1982TSTransConceptoDestino, A1985TSTransGlosaDestino, A1989TSTransOperacionDestino, A1993TSTransTipoCambio, A1987TSTransImporteDestino, A1991TSTransRegDestino, A1992TSTransRegOrigen, A143ForCod, A424TSTransBanOrigen, A425TSTransBanDestino, A423TSTransCod});
                     pr_default.close(13);
                     dsDefault.SmartCacheProvider.SetUpdated("TSTRANSFERENCIABANCOS");
                     if ( (pr_default.getStatus(13) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSTRANSFERENCIABANCOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4X164( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4X0( ) ;
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
            EndLevel4X164( ) ;
         }
         CloseExtendedTableCursors4X164( ) ;
      }

      protected void DeferredUpdate4X164( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4X164( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4X164( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4X164( ) ;
            AfterConfirm4X164( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4X164( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004X16 */
                  pr_default.execute(14, new Object[] {A423TSTransCod});
                  pr_default.close(14);
                  dsDefault.SmartCacheProvider.SetUpdated("TSTRANSFERENCIABANCOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound164 == 0 )
                        {
                           InitAll4X164( ) ;
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
                        ResetCaption4X0( ) ;
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
         sMode164 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4X164( ) ;
         Gx_mode = sMode164;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4X164( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T004X17 */
            pr_default.execute(15, new Object[] {A424TSTransBanOrigen});
            A1981TSTransBanOrigenDsc = T004X17_A1981TSTransBanOrigenDsc[0];
            AssignAttri("", false, "A1981TSTransBanOrigenDsc", A1981TSTransBanOrigenDsc);
            pr_default.close(15);
            /* Using cursor T004X18 */
            pr_default.execute(16, new Object[] {A425TSTransBanDestino});
            A1980TSTransBanDestinoDsc = T004X18_A1980TSTransBanDestinoDsc[0];
            AssignAttri("", false, "A1980TSTransBanDestinoDsc", A1980TSTransBanDestinoDsc);
            pr_default.close(16);
         }
      }

      protected void EndLevel4X164( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4X164( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.CommitDataStores("tstransferenciabancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(16);
            context.RollbackDataStores("tstransferenciabancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4X164( )
      {
         /* Using cursor T004X19 */
         pr_default.execute(17);
         RcdFound164 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound164 = 1;
            A423TSTransCod = T004X19_A423TSTransCod[0];
            AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4X164( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound164 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound164 = 1;
            A423TSTransCod = T004X19_A423TSTransCod[0];
            AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
         }
      }

      protected void ScanEnd4X164( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm4X164( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4X164( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4X164( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4X164( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4X164( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4X164( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4X164( )
      {
         edtTSTransCod_Enabled = 0;
         AssignProp("", false, edtTSTransCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransCod_Enabled), 5, 0), true);
         edtTSTransFec_Enabled = 0;
         AssignProp("", false, edtTSTransFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransFec_Enabled), 5, 0), true);
         edtForCod_Enabled = 0;
         AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
         edtTSTransBanOrigen_Enabled = 0;
         AssignProp("", false, edtTSTransBanOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransBanOrigen_Enabled), 5, 0), true);
         edtTSTransBanOrigenDsc_Enabled = 0;
         AssignProp("", false, edtTSTransBanOrigenDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransBanOrigenDsc_Enabled), 5, 0), true);
         edtTSTransBanCta_Enabled = 0;
         AssignProp("", false, edtTSTransBanCta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransBanCta_Enabled), 5, 0), true);
         edtTSTransConceptoOrigen_Enabled = 0;
         AssignProp("", false, edtTSTransConceptoOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransConceptoOrigen_Enabled), 5, 0), true);
         edtTSTransGlosaOrigen_Enabled = 0;
         AssignProp("", false, edtTSTransGlosaOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransGlosaOrigen_Enabled), 5, 0), true);
         edtTSTransOperacionOrigen_Enabled = 0;
         AssignProp("", false, edtTSTransOperacionOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransOperacionOrigen_Enabled), 5, 0), true);
         edtTSTransImporteOrigen_Enabled = 0;
         AssignProp("", false, edtTSTransImporteOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransImporteOrigen_Enabled), 5, 0), true);
         edtTSTransBanDestino_Enabled = 0;
         AssignProp("", false, edtTSTransBanDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransBanDestino_Enabled), 5, 0), true);
         edtTSTransBanDestinoDsc_Enabled = 0;
         AssignProp("", false, edtTSTransBanDestinoDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransBanDestinoDsc_Enabled), 5, 0), true);
         edtTSTransBanCtaDestino_Enabled = 0;
         AssignProp("", false, edtTSTransBanCtaDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransBanCtaDestino_Enabled), 5, 0), true);
         edtTSTransConceptoDestino_Enabled = 0;
         AssignProp("", false, edtTSTransConceptoDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransConceptoDestino_Enabled), 5, 0), true);
         edtTSTransGlosaDestino_Enabled = 0;
         AssignProp("", false, edtTSTransGlosaDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransGlosaDestino_Enabled), 5, 0), true);
         edtTSTransOperacionDestino_Enabled = 0;
         AssignProp("", false, edtTSTransOperacionDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransOperacionDestino_Enabled), 5, 0), true);
         edtTSTransTipoCambio_Enabled = 0;
         AssignProp("", false, edtTSTransTipoCambio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransTipoCambio_Enabled), 5, 0), true);
         edtTSTransImporteDestino_Enabled = 0;
         AssignProp("", false, edtTSTransImporteDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransImporteDestino_Enabled), 5, 0), true);
         edtTSTransRegDestino_Enabled = 0;
         AssignProp("", false, edtTSTransRegDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransRegDestino_Enabled), 5, 0), true);
         edtTSTransRegOrigen_Enabled = 0;
         AssignProp("", false, edtTSTransRegOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSTransRegOrigen_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4X164( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4X0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254372", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tstransferenciabancos.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z423TSTransCod", Z423TSTransCod);
         GxWebStd.gx_hidden_field( context, "Z1984TSTransFec", context.localUtil.DToC( Z1984TSTransFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1978TSTransBanCta", Z1978TSTransBanCta);
         GxWebStd.gx_hidden_field( context, "Z1983TSTransConceptoOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1983TSTransConceptoOrigen), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1986TSTransGlosaOrigen", Z1986TSTransGlosaOrigen);
         GxWebStd.gx_hidden_field( context, "Z1990TSTransOperacionOrigen", Z1990TSTransOperacionOrigen);
         GxWebStd.gx_hidden_field( context, "Z1988TSTransImporteOrigen", StringUtil.LTrim( StringUtil.NToC( Z1988TSTransImporteOrigen, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1979TSTransBanCtaDestino", Z1979TSTransBanCtaDestino);
         GxWebStd.gx_hidden_field( context, "Z1982TSTransConceptoDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1982TSTransConceptoDestino), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1985TSTransGlosaDestino", Z1985TSTransGlosaDestino);
         GxWebStd.gx_hidden_field( context, "Z1989TSTransOperacionDestino", Z1989TSTransOperacionDestino);
         GxWebStd.gx_hidden_field( context, "Z1993TSTransTipoCambio", StringUtil.LTrim( StringUtil.NToC( Z1993TSTransTipoCambio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1987TSTransImporteDestino", StringUtil.LTrim( StringUtil.NToC( Z1987TSTransImporteDestino, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1991TSTransRegDestino", Z1991TSTransRegDestino);
         GxWebStd.gx_hidden_field( context, "Z1992TSTransRegOrigen", Z1992TSTransRegOrigen);
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z424TSTransBanOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z424TSTransBanOrigen), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z425TSTransBanDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z425TSTransBanDestino), 6, 0, ".", "")));
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
         return formatLink("tstransferenciabancos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSTRANSFERENCIABANCOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "TSTRANSFERENCIABANCOS" ;
      }

      protected void InitializeNonKey4X164( )
      {
         A1984TSTransFec = DateTime.MinValue;
         AssignAttri("", false, "A1984TSTransFec", context.localUtil.Format(A1984TSTransFec, "99/99/99"));
         A143ForCod = 0;
         AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         A424TSTransBanOrigen = 0;
         AssignAttri("", false, "A424TSTransBanOrigen", StringUtil.LTrimStr( (decimal)(A424TSTransBanOrigen), 6, 0));
         A1981TSTransBanOrigenDsc = "";
         AssignAttri("", false, "A1981TSTransBanOrigenDsc", A1981TSTransBanOrigenDsc);
         A1978TSTransBanCta = "";
         AssignAttri("", false, "A1978TSTransBanCta", A1978TSTransBanCta);
         A1983TSTransConceptoOrigen = 0;
         AssignAttri("", false, "A1983TSTransConceptoOrigen", StringUtil.LTrimStr( (decimal)(A1983TSTransConceptoOrigen), 6, 0));
         A1986TSTransGlosaOrigen = "";
         AssignAttri("", false, "A1986TSTransGlosaOrigen", A1986TSTransGlosaOrigen);
         A1990TSTransOperacionOrigen = "";
         AssignAttri("", false, "A1990TSTransOperacionOrigen", A1990TSTransOperacionOrigen);
         A1988TSTransImporteOrigen = 0;
         AssignAttri("", false, "A1988TSTransImporteOrigen", StringUtil.LTrimStr( A1988TSTransImporteOrigen, 15, 2));
         A425TSTransBanDestino = 0;
         AssignAttri("", false, "A425TSTransBanDestino", StringUtil.LTrimStr( (decimal)(A425TSTransBanDestino), 6, 0));
         A1980TSTransBanDestinoDsc = "";
         AssignAttri("", false, "A1980TSTransBanDestinoDsc", A1980TSTransBanDestinoDsc);
         A1979TSTransBanCtaDestino = "";
         AssignAttri("", false, "A1979TSTransBanCtaDestino", A1979TSTransBanCtaDestino);
         A1982TSTransConceptoDestino = 0;
         AssignAttri("", false, "A1982TSTransConceptoDestino", StringUtil.LTrimStr( (decimal)(A1982TSTransConceptoDestino), 6, 0));
         A1985TSTransGlosaDestino = "";
         AssignAttri("", false, "A1985TSTransGlosaDestino", A1985TSTransGlosaDestino);
         A1989TSTransOperacionDestino = "";
         AssignAttri("", false, "A1989TSTransOperacionDestino", A1989TSTransOperacionDestino);
         A1993TSTransTipoCambio = 0;
         AssignAttri("", false, "A1993TSTransTipoCambio", StringUtil.LTrimStr( A1993TSTransTipoCambio, 15, 4));
         A1987TSTransImporteDestino = 0;
         AssignAttri("", false, "A1987TSTransImporteDestino", StringUtil.LTrimStr( A1987TSTransImporteDestino, 15, 2));
         A1991TSTransRegDestino = "";
         AssignAttri("", false, "A1991TSTransRegDestino", A1991TSTransRegDestino);
         A1992TSTransRegOrigen = "";
         AssignAttri("", false, "A1992TSTransRegOrigen", A1992TSTransRegOrigen);
         Z1984TSTransFec = DateTime.MinValue;
         Z1978TSTransBanCta = "";
         Z1983TSTransConceptoOrigen = 0;
         Z1986TSTransGlosaOrigen = "";
         Z1990TSTransOperacionOrigen = "";
         Z1988TSTransImporteOrigen = 0;
         Z1979TSTransBanCtaDestino = "";
         Z1982TSTransConceptoDestino = 0;
         Z1985TSTransGlosaDestino = "";
         Z1989TSTransOperacionDestino = "";
         Z1993TSTransTipoCambio = 0;
         Z1987TSTransImporteDestino = 0;
         Z1991TSTransRegDestino = "";
         Z1992TSTransRegOrigen = "";
         Z143ForCod = 0;
         Z424TSTransBanOrigen = 0;
         Z425TSTransBanDestino = 0;
      }

      protected void InitAll4X164( )
      {
         A423TSTransCod = "";
         AssignAttri("", false, "A423TSTransCod", A423TSTransCod);
         InitializeNonKey4X164( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254385", true, true);
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
         context.AddJavascriptSource("tstransferenciabancos.js", "?202281810254385", false, true);
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
         edtTSTransCod_Internalname = "TSTRANSCOD";
         edtTSTransFec_Internalname = "TSTRANSFEC";
         edtForCod_Internalname = "FORCOD";
         edtTSTransBanOrigen_Internalname = "TSTRANSBANORIGEN";
         edtTSTransBanOrigenDsc_Internalname = "TSTRANSBANORIGENDSC";
         edtTSTransBanCta_Internalname = "TSTRANSBANCTA";
         edtTSTransConceptoOrigen_Internalname = "TSTRANSCONCEPTOORIGEN";
         edtTSTransGlosaOrigen_Internalname = "TSTRANSGLOSAORIGEN";
         edtTSTransOperacionOrigen_Internalname = "TSTRANSOPERACIONORIGEN";
         edtTSTransImporteOrigen_Internalname = "TSTRANSIMPORTEORIGEN";
         edtTSTransBanDestino_Internalname = "TSTRANSBANDESTINO";
         edtTSTransBanDestinoDsc_Internalname = "TSTRANSBANDESTINODSC";
         edtTSTransBanCtaDestino_Internalname = "TSTRANSBANCTADESTINO";
         edtTSTransConceptoDestino_Internalname = "TSTRANSCONCEPTODESTINO";
         edtTSTransGlosaDestino_Internalname = "TSTRANSGLOSADESTINO";
         edtTSTransOperacionDestino_Internalname = "TSTRANSOPERACIONDESTINO";
         edtTSTransTipoCambio_Internalname = "TSTRANSTIPOCAMBIO";
         edtTSTransImporteDestino_Internalname = "TSTRANSIMPORTEDESTINO";
         edtTSTransRegDestino_Internalname = "TSTRANSREGDESTINO";
         edtTSTransRegOrigen_Internalname = "TSTRANSREGORIGEN";
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
         Form.Caption = "TSTRANSFERENCIABANCOS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTSTransRegOrigen_Jsonclick = "";
         edtTSTransRegOrigen_Enabled = 1;
         edtTSTransRegDestino_Jsonclick = "";
         edtTSTransRegDestino_Enabled = 1;
         edtTSTransImporteDestino_Jsonclick = "";
         edtTSTransImporteDestino_Enabled = 1;
         edtTSTransTipoCambio_Jsonclick = "";
         edtTSTransTipoCambio_Enabled = 1;
         edtTSTransOperacionDestino_Jsonclick = "";
         edtTSTransOperacionDestino_Enabled = 1;
         edtTSTransGlosaDestino_Jsonclick = "";
         edtTSTransGlosaDestino_Enabled = 1;
         edtTSTransConceptoDestino_Jsonclick = "";
         edtTSTransConceptoDestino_Enabled = 1;
         edtTSTransBanCtaDestino_Jsonclick = "";
         edtTSTransBanCtaDestino_Enabled = 1;
         edtTSTransBanDestinoDsc_Jsonclick = "";
         edtTSTransBanDestinoDsc_Enabled = 0;
         edtTSTransBanDestino_Jsonclick = "";
         edtTSTransBanDestino_Enabled = 1;
         edtTSTransImporteOrigen_Jsonclick = "";
         edtTSTransImporteOrigen_Enabled = 1;
         edtTSTransOperacionOrigen_Jsonclick = "";
         edtTSTransOperacionOrigen_Enabled = 1;
         edtTSTransGlosaOrigen_Jsonclick = "";
         edtTSTransGlosaOrigen_Enabled = 1;
         edtTSTransConceptoOrigen_Jsonclick = "";
         edtTSTransConceptoOrigen_Enabled = 1;
         edtTSTransBanCta_Jsonclick = "";
         edtTSTransBanCta_Enabled = 1;
         edtTSTransBanOrigenDsc_Jsonclick = "";
         edtTSTransBanOrigenDsc_Enabled = 0;
         edtTSTransBanOrigen_Jsonclick = "";
         edtTSTransBanOrigen_Enabled = 1;
         edtForCod_Jsonclick = "";
         edtForCod_Enabled = 1;
         edtTSTransFec_Jsonclick = "";
         edtTSTransFec_Enabled = 1;
         edtTSTransCod_Jsonclick = "";
         edtTSTransCod_Enabled = 1;
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
         GX_FocusControl = edtTSTransFec_Internalname;
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

      public void Valid_Tstranscod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1984TSTransFec", context.localUtil.Format(A1984TSTransFec, "99/99/99"));
         AssignAttri("", false, "A143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A424TSTransBanOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(A424TSTransBanOrigen), 6, 0, ".", "")));
         AssignAttri("", false, "A1978TSTransBanCta", A1978TSTransBanCta);
         AssignAttri("", false, "A1983TSTransConceptoOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1983TSTransConceptoOrigen), 6, 0, ".", "")));
         AssignAttri("", false, "A1986TSTransGlosaOrigen", A1986TSTransGlosaOrigen);
         AssignAttri("", false, "A1990TSTransOperacionOrigen", A1990TSTransOperacionOrigen);
         AssignAttri("", false, "A1988TSTransImporteOrigen", StringUtil.LTrim( StringUtil.NToC( A1988TSTransImporteOrigen, 15, 2, ".", "")));
         AssignAttri("", false, "A425TSTransBanDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(A425TSTransBanDestino), 6, 0, ".", "")));
         AssignAttri("", false, "A1979TSTransBanCtaDestino", A1979TSTransBanCtaDestino);
         AssignAttri("", false, "A1982TSTransConceptoDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1982TSTransConceptoDestino), 6, 0, ".", "")));
         AssignAttri("", false, "A1985TSTransGlosaDestino", A1985TSTransGlosaDestino);
         AssignAttri("", false, "A1989TSTransOperacionDestino", A1989TSTransOperacionDestino);
         AssignAttri("", false, "A1993TSTransTipoCambio", StringUtil.LTrim( StringUtil.NToC( A1993TSTransTipoCambio, 15, 4, ".", "")));
         AssignAttri("", false, "A1987TSTransImporteDestino", StringUtil.LTrim( StringUtil.NToC( A1987TSTransImporteDestino, 15, 2, ".", "")));
         AssignAttri("", false, "A1991TSTransRegDestino", A1991TSTransRegDestino);
         AssignAttri("", false, "A1992TSTransRegOrigen", A1992TSTransRegOrigen);
         AssignAttri("", false, "A1981TSTransBanOrigenDsc", StringUtil.RTrim( A1981TSTransBanOrigenDsc));
         AssignAttri("", false, "A1980TSTransBanDestinoDsc", StringUtil.RTrim( A1980TSTransBanDestinoDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z423TSTransCod", Z423TSTransCod);
         GxWebStd.gx_hidden_field( context, "Z1984TSTransFec", context.localUtil.Format(Z1984TSTransFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z424TSTransBanOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z424TSTransBanOrigen), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1978TSTransBanCta", Z1978TSTransBanCta);
         GxWebStd.gx_hidden_field( context, "Z1983TSTransConceptoOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1983TSTransConceptoOrigen), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1986TSTransGlosaOrigen", Z1986TSTransGlosaOrigen);
         GxWebStd.gx_hidden_field( context, "Z1990TSTransOperacionOrigen", Z1990TSTransOperacionOrigen);
         GxWebStd.gx_hidden_field( context, "Z1988TSTransImporteOrigen", StringUtil.LTrim( StringUtil.NToC( Z1988TSTransImporteOrigen, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z425TSTransBanDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z425TSTransBanDestino), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1979TSTransBanCtaDestino", Z1979TSTransBanCtaDestino);
         GxWebStd.gx_hidden_field( context, "Z1982TSTransConceptoDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1982TSTransConceptoDestino), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1985TSTransGlosaDestino", Z1985TSTransGlosaDestino);
         GxWebStd.gx_hidden_field( context, "Z1989TSTransOperacionDestino", Z1989TSTransOperacionDestino);
         GxWebStd.gx_hidden_field( context, "Z1993TSTransTipoCambio", StringUtil.LTrim( StringUtil.NToC( Z1993TSTransTipoCambio, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1987TSTransImporteDestino", StringUtil.LTrim( StringUtil.NToC( Z1987TSTransImporteDestino, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1991TSTransRegDestino", Z1991TSTransRegDestino);
         GxWebStd.gx_hidden_field( context, "Z1992TSTransRegOrigen", Z1992TSTransRegOrigen);
         GxWebStd.gx_hidden_field( context, "Z1981TSTransBanOrigenDsc", StringUtil.RTrim( Z1981TSTransBanOrigenDsc));
         GxWebStd.gx_hidden_field( context, "Z1980TSTransBanDestinoDsc", StringUtil.RTrim( Z1980TSTransBanDestinoDsc));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Forcod( )
      {
         /* Using cursor T004X20 */
         pr_default.execute(18, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Formas de Pago'.", "ForeignKeyNotFound", 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tstransbanorigen( )
      {
         /* Using cursor T004X17 */
         pr_default.execute(15, new Object[] {A424TSTransBanOrigen});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Banco Origen'.", "ForeignKeyNotFound", 1, "TSTRANSBANORIGEN");
            AnyError = 1;
            GX_FocusControl = edtTSTransBanOrigen_Internalname;
         }
         A1981TSTransBanOrigenDsc = T004X17_A1981TSTransBanOrigenDsc[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1981TSTransBanOrigenDsc", StringUtil.RTrim( A1981TSTransBanOrigenDsc));
      }

      public void Valid_Tstransbandestino( )
      {
         /* Using cursor T004X18 */
         pr_default.execute(16, new Object[] {A425TSTransBanDestino});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Bancos Destino'.", "ForeignKeyNotFound", 1, "TSTRANSBANDESTINO");
            AnyError = 1;
            GX_FocusControl = edtTSTransBanDestino_Internalname;
         }
         A1980TSTransBanDestinoDsc = T004X18_A1980TSTransBanDestinoDsc[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1980TSTransBanDestinoDsc", StringUtil.RTrim( A1980TSTransBanDestinoDsc));
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
         setEventMetadata("VALID_TSTRANSCOD","{handler:'Valid_Tstranscod',iparms:[{av:'A423TSTransCod',fld:'TSTRANSCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TSTRANSCOD",",oparms:[{av:'A1984TSTransFec',fld:'TSTRANSFEC',pic:''},{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'},{av:'A424TSTransBanOrigen',fld:'TSTRANSBANORIGEN',pic:'ZZZZZ9'},{av:'A1978TSTransBanCta',fld:'TSTRANSBANCTA',pic:''},{av:'A1983TSTransConceptoOrigen',fld:'TSTRANSCONCEPTOORIGEN',pic:'ZZZZZ9'},{av:'A1986TSTransGlosaOrigen',fld:'TSTRANSGLOSAORIGEN',pic:''},{av:'A1990TSTransOperacionOrigen',fld:'TSTRANSOPERACIONORIGEN',pic:''},{av:'A1988TSTransImporteOrigen',fld:'TSTRANSIMPORTEORIGEN',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A425TSTransBanDestino',fld:'TSTRANSBANDESTINO',pic:'ZZZZZ9'},{av:'A1979TSTransBanCtaDestino',fld:'TSTRANSBANCTADESTINO',pic:''},{av:'A1982TSTransConceptoDestino',fld:'TSTRANSCONCEPTODESTINO',pic:'ZZZZZ9'},{av:'A1985TSTransGlosaDestino',fld:'TSTRANSGLOSADESTINO',pic:''},{av:'A1989TSTransOperacionDestino',fld:'TSTRANSOPERACIONDESTINO',pic:''},{av:'A1993TSTransTipoCambio',fld:'TSTRANSTIPOCAMBIO',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1987TSTransImporteDestino',fld:'TSTRANSIMPORTEDESTINO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1991TSTransRegDestino',fld:'TSTRANSREGDESTINO',pic:''},{av:'A1992TSTransRegOrigen',fld:'TSTRANSREGORIGEN',pic:''},{av:'A1981TSTransBanOrigenDsc',fld:'TSTRANSBANORIGENDSC',pic:''},{av:'A1980TSTransBanDestinoDsc',fld:'TSTRANSBANDESTINODSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z423TSTransCod'},{av:'Z1984TSTransFec'},{av:'Z143ForCod'},{av:'Z424TSTransBanOrigen'},{av:'Z1978TSTransBanCta'},{av:'Z1983TSTransConceptoOrigen'},{av:'Z1986TSTransGlosaOrigen'},{av:'Z1990TSTransOperacionOrigen'},{av:'Z1988TSTransImporteOrigen'},{av:'Z425TSTransBanDestino'},{av:'Z1979TSTransBanCtaDestino'},{av:'Z1982TSTransConceptoDestino'},{av:'Z1985TSTransGlosaDestino'},{av:'Z1989TSTransOperacionDestino'},{av:'Z1993TSTransTipoCambio'},{av:'Z1987TSTransImporteDestino'},{av:'Z1991TSTransRegDestino'},{av:'Z1992TSTransRegOrigen'},{av:'Z1981TSTransBanOrigenDsc'},{av:'Z1980TSTransBanDestinoDsc'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TSTRANSFEC","{handler:'Valid_Tstransfec',iparms:[]");
         setEventMetadata("VALID_TSTRANSFEC",",oparms:[]}");
         setEventMetadata("VALID_FORCOD","{handler:'Valid_Forcod',iparms:[{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_FORCOD",",oparms:[]}");
         setEventMetadata("VALID_TSTRANSBANORIGEN","{handler:'Valid_Tstransbanorigen',iparms:[{av:'A424TSTransBanOrigen',fld:'TSTRANSBANORIGEN',pic:'ZZZZZ9'},{av:'A1981TSTransBanOrigenDsc',fld:'TSTRANSBANORIGENDSC',pic:''}]");
         setEventMetadata("VALID_TSTRANSBANORIGEN",",oparms:[{av:'A1981TSTransBanOrigenDsc',fld:'TSTRANSBANORIGENDSC',pic:''}]}");
         setEventMetadata("VALID_TSTRANSBANDESTINO","{handler:'Valid_Tstransbandestino',iparms:[{av:'A425TSTransBanDestino',fld:'TSTRANSBANDESTINO',pic:'ZZZZZ9'},{av:'A1980TSTransBanDestinoDsc',fld:'TSTRANSBANDESTINODSC',pic:''}]");
         setEventMetadata("VALID_TSTRANSBANDESTINO",",oparms:[{av:'A1980TSTransBanDestinoDsc',fld:'TSTRANSBANDESTINODSC',pic:''}]}");
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
         pr_default.close(18);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z423TSTransCod = "";
         Z1984TSTransFec = DateTime.MinValue;
         Z1978TSTransBanCta = "";
         Z1986TSTransGlosaOrigen = "";
         Z1990TSTransOperacionOrigen = "";
         Z1979TSTransBanCtaDestino = "";
         Z1985TSTransGlosaDestino = "";
         Z1989TSTransOperacionDestino = "";
         Z1991TSTransRegDestino = "";
         Z1992TSTransRegOrigen = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         A423TSTransCod = "";
         A1984TSTransFec = DateTime.MinValue;
         A1981TSTransBanOrigenDsc = "";
         A1978TSTransBanCta = "";
         A1986TSTransGlosaOrigen = "";
         A1990TSTransOperacionOrigen = "";
         A1980TSTransBanDestinoDsc = "";
         A1979TSTransBanCtaDestino = "";
         A1985TSTransGlosaDestino = "";
         A1989TSTransOperacionDestino = "";
         A1991TSTransRegDestino = "";
         A1992TSTransRegOrigen = "";
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
         Z1981TSTransBanOrigenDsc = "";
         Z1980TSTransBanDestinoDsc = "";
         T004X7_A423TSTransCod = new string[] {""} ;
         T004X7_A1984TSTransFec = new DateTime[] {DateTime.MinValue} ;
         T004X7_A1981TSTransBanOrigenDsc = new string[] {""} ;
         T004X7_A1978TSTransBanCta = new string[] {""} ;
         T004X7_A1983TSTransConceptoOrigen = new int[1] ;
         T004X7_A1986TSTransGlosaOrigen = new string[] {""} ;
         T004X7_A1990TSTransOperacionOrigen = new string[] {""} ;
         T004X7_A1988TSTransImporteOrigen = new decimal[1] ;
         T004X7_A1980TSTransBanDestinoDsc = new string[] {""} ;
         T004X7_A1979TSTransBanCtaDestino = new string[] {""} ;
         T004X7_A1982TSTransConceptoDestino = new int[1] ;
         T004X7_A1985TSTransGlosaDestino = new string[] {""} ;
         T004X7_A1989TSTransOperacionDestino = new string[] {""} ;
         T004X7_A1993TSTransTipoCambio = new decimal[1] ;
         T004X7_A1987TSTransImporteDestino = new decimal[1] ;
         T004X7_A1991TSTransRegDestino = new string[] {""} ;
         T004X7_A1992TSTransRegOrigen = new string[] {""} ;
         T004X7_A143ForCod = new int[1] ;
         T004X7_A424TSTransBanOrigen = new int[1] ;
         T004X7_A425TSTransBanDestino = new int[1] ;
         T004X4_A143ForCod = new int[1] ;
         T004X5_A1981TSTransBanOrigenDsc = new string[] {""} ;
         T004X6_A1980TSTransBanDestinoDsc = new string[] {""} ;
         T004X8_A143ForCod = new int[1] ;
         T004X9_A1981TSTransBanOrigenDsc = new string[] {""} ;
         T004X10_A1980TSTransBanDestinoDsc = new string[] {""} ;
         T004X11_A423TSTransCod = new string[] {""} ;
         T004X3_A423TSTransCod = new string[] {""} ;
         T004X3_A1984TSTransFec = new DateTime[] {DateTime.MinValue} ;
         T004X3_A1978TSTransBanCta = new string[] {""} ;
         T004X3_A1983TSTransConceptoOrigen = new int[1] ;
         T004X3_A1986TSTransGlosaOrigen = new string[] {""} ;
         T004X3_A1990TSTransOperacionOrigen = new string[] {""} ;
         T004X3_A1988TSTransImporteOrigen = new decimal[1] ;
         T004X3_A1979TSTransBanCtaDestino = new string[] {""} ;
         T004X3_A1982TSTransConceptoDestino = new int[1] ;
         T004X3_A1985TSTransGlosaDestino = new string[] {""} ;
         T004X3_A1989TSTransOperacionDestino = new string[] {""} ;
         T004X3_A1993TSTransTipoCambio = new decimal[1] ;
         T004X3_A1987TSTransImporteDestino = new decimal[1] ;
         T004X3_A1991TSTransRegDestino = new string[] {""} ;
         T004X3_A1992TSTransRegOrigen = new string[] {""} ;
         T004X3_A143ForCod = new int[1] ;
         T004X3_A424TSTransBanOrigen = new int[1] ;
         T004X3_A425TSTransBanDestino = new int[1] ;
         sMode164 = "";
         T004X12_A423TSTransCod = new string[] {""} ;
         T004X13_A423TSTransCod = new string[] {""} ;
         T004X2_A423TSTransCod = new string[] {""} ;
         T004X2_A1984TSTransFec = new DateTime[] {DateTime.MinValue} ;
         T004X2_A1978TSTransBanCta = new string[] {""} ;
         T004X2_A1983TSTransConceptoOrigen = new int[1] ;
         T004X2_A1986TSTransGlosaOrigen = new string[] {""} ;
         T004X2_A1990TSTransOperacionOrigen = new string[] {""} ;
         T004X2_A1988TSTransImporteOrigen = new decimal[1] ;
         T004X2_A1979TSTransBanCtaDestino = new string[] {""} ;
         T004X2_A1982TSTransConceptoDestino = new int[1] ;
         T004X2_A1985TSTransGlosaDestino = new string[] {""} ;
         T004X2_A1989TSTransOperacionDestino = new string[] {""} ;
         T004X2_A1993TSTransTipoCambio = new decimal[1] ;
         T004X2_A1987TSTransImporteDestino = new decimal[1] ;
         T004X2_A1991TSTransRegDestino = new string[] {""} ;
         T004X2_A1992TSTransRegOrigen = new string[] {""} ;
         T004X2_A143ForCod = new int[1] ;
         T004X2_A424TSTransBanOrigen = new int[1] ;
         T004X2_A425TSTransBanDestino = new int[1] ;
         T004X17_A1981TSTransBanOrigenDsc = new string[] {""} ;
         T004X18_A1980TSTransBanDestinoDsc = new string[] {""} ;
         T004X19_A423TSTransCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ423TSTransCod = "";
         ZZ1984TSTransFec = DateTime.MinValue;
         ZZ1978TSTransBanCta = "";
         ZZ1986TSTransGlosaOrigen = "";
         ZZ1990TSTransOperacionOrigen = "";
         ZZ1979TSTransBanCtaDestino = "";
         ZZ1985TSTransGlosaDestino = "";
         ZZ1989TSTransOperacionDestino = "";
         ZZ1991TSTransRegDestino = "";
         ZZ1992TSTransRegOrigen = "";
         ZZ1981TSTransBanOrigenDsc = "";
         ZZ1980TSTransBanDestinoDsc = "";
         T004X20_A143ForCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tstransferenciabancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tstransferenciabancos__default(),
            new Object[][] {
                new Object[] {
               T004X2_A423TSTransCod, T004X2_A1984TSTransFec, T004X2_A1978TSTransBanCta, T004X2_A1983TSTransConceptoOrigen, T004X2_A1986TSTransGlosaOrigen, T004X2_A1990TSTransOperacionOrigen, T004X2_A1988TSTransImporteOrigen, T004X2_A1979TSTransBanCtaDestino, T004X2_A1982TSTransConceptoDestino, T004X2_A1985TSTransGlosaDestino,
               T004X2_A1989TSTransOperacionDestino, T004X2_A1993TSTransTipoCambio, T004X2_A1987TSTransImporteDestino, T004X2_A1991TSTransRegDestino, T004X2_A1992TSTransRegOrigen, T004X2_A143ForCod, T004X2_A424TSTransBanOrigen, T004X2_A425TSTransBanDestino
               }
               , new Object[] {
               T004X3_A423TSTransCod, T004X3_A1984TSTransFec, T004X3_A1978TSTransBanCta, T004X3_A1983TSTransConceptoOrigen, T004X3_A1986TSTransGlosaOrigen, T004X3_A1990TSTransOperacionOrigen, T004X3_A1988TSTransImporteOrigen, T004X3_A1979TSTransBanCtaDestino, T004X3_A1982TSTransConceptoDestino, T004X3_A1985TSTransGlosaDestino,
               T004X3_A1989TSTransOperacionDestino, T004X3_A1993TSTransTipoCambio, T004X3_A1987TSTransImporteDestino, T004X3_A1991TSTransRegDestino, T004X3_A1992TSTransRegOrigen, T004X3_A143ForCod, T004X3_A424TSTransBanOrigen, T004X3_A425TSTransBanDestino
               }
               , new Object[] {
               T004X4_A143ForCod
               }
               , new Object[] {
               T004X5_A1981TSTransBanOrigenDsc
               }
               , new Object[] {
               T004X6_A1980TSTransBanDestinoDsc
               }
               , new Object[] {
               T004X7_A423TSTransCod, T004X7_A1984TSTransFec, T004X7_A1981TSTransBanOrigenDsc, T004X7_A1978TSTransBanCta, T004X7_A1983TSTransConceptoOrigen, T004X7_A1986TSTransGlosaOrigen, T004X7_A1990TSTransOperacionOrigen, T004X7_A1988TSTransImporteOrigen, T004X7_A1980TSTransBanDestinoDsc, T004X7_A1979TSTransBanCtaDestino,
               T004X7_A1982TSTransConceptoDestino, T004X7_A1985TSTransGlosaDestino, T004X7_A1989TSTransOperacionDestino, T004X7_A1993TSTransTipoCambio, T004X7_A1987TSTransImporteDestino, T004X7_A1991TSTransRegDestino, T004X7_A1992TSTransRegOrigen, T004X7_A143ForCod, T004X7_A424TSTransBanOrigen, T004X7_A425TSTransBanDestino
               }
               , new Object[] {
               T004X8_A143ForCod
               }
               , new Object[] {
               T004X9_A1981TSTransBanOrigenDsc
               }
               , new Object[] {
               T004X10_A1980TSTransBanDestinoDsc
               }
               , new Object[] {
               T004X11_A423TSTransCod
               }
               , new Object[] {
               T004X12_A423TSTransCod
               }
               , new Object[] {
               T004X13_A423TSTransCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004X17_A1981TSTransBanOrigenDsc
               }
               , new Object[] {
               T004X18_A1980TSTransBanDestinoDsc
               }
               , new Object[] {
               T004X19_A423TSTransCod
               }
               , new Object[] {
               T004X20_A143ForCod
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
      private short RcdFound164 ;
      private short nIsDirty_164 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z1983TSTransConceptoOrigen ;
      private int Z1982TSTransConceptoDestino ;
      private int Z143ForCod ;
      private int Z424TSTransBanOrigen ;
      private int Z425TSTransBanDestino ;
      private int A143ForCod ;
      private int A424TSTransBanOrigen ;
      private int A425TSTransBanDestino ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTSTransCod_Enabled ;
      private int edtTSTransFec_Enabled ;
      private int edtForCod_Enabled ;
      private int edtTSTransBanOrigen_Enabled ;
      private int edtTSTransBanOrigenDsc_Enabled ;
      private int edtTSTransBanCta_Enabled ;
      private int A1983TSTransConceptoOrigen ;
      private int edtTSTransConceptoOrigen_Enabled ;
      private int edtTSTransGlosaOrigen_Enabled ;
      private int edtTSTransOperacionOrigen_Enabled ;
      private int edtTSTransImporteOrigen_Enabled ;
      private int edtTSTransBanDestino_Enabled ;
      private int edtTSTransBanDestinoDsc_Enabled ;
      private int edtTSTransBanCtaDestino_Enabled ;
      private int A1982TSTransConceptoDestino ;
      private int edtTSTransConceptoDestino_Enabled ;
      private int edtTSTransGlosaDestino_Enabled ;
      private int edtTSTransOperacionDestino_Enabled ;
      private int edtTSTransTipoCambio_Enabled ;
      private int edtTSTransImporteDestino_Enabled ;
      private int edtTSTransRegDestino_Enabled ;
      private int edtTSTransRegOrigen_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ143ForCod ;
      private int ZZ424TSTransBanOrigen ;
      private int ZZ1983TSTransConceptoOrigen ;
      private int ZZ425TSTransBanDestino ;
      private int ZZ1982TSTransConceptoDestino ;
      private decimal Z1988TSTransImporteOrigen ;
      private decimal Z1993TSTransTipoCambio ;
      private decimal Z1987TSTransImporteDestino ;
      private decimal A1988TSTransImporteOrigen ;
      private decimal A1993TSTransTipoCambio ;
      private decimal A1987TSTransImporteDestino ;
      private decimal ZZ1988TSTransImporteOrigen ;
      private decimal ZZ1993TSTransTipoCambio ;
      private decimal ZZ1987TSTransImporteDestino ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTSTransCod_Internalname ;
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
      private string edtTSTransCod_Jsonclick ;
      private string edtTSTransFec_Internalname ;
      private string edtTSTransFec_Jsonclick ;
      private string edtForCod_Internalname ;
      private string edtForCod_Jsonclick ;
      private string edtTSTransBanOrigen_Internalname ;
      private string edtTSTransBanOrigen_Jsonclick ;
      private string edtTSTransBanOrigenDsc_Internalname ;
      private string A1981TSTransBanOrigenDsc ;
      private string edtTSTransBanOrigenDsc_Jsonclick ;
      private string edtTSTransBanCta_Internalname ;
      private string edtTSTransBanCta_Jsonclick ;
      private string edtTSTransConceptoOrigen_Internalname ;
      private string edtTSTransConceptoOrigen_Jsonclick ;
      private string edtTSTransGlosaOrigen_Internalname ;
      private string edtTSTransGlosaOrigen_Jsonclick ;
      private string edtTSTransOperacionOrigen_Internalname ;
      private string edtTSTransOperacionOrigen_Jsonclick ;
      private string edtTSTransImporteOrigen_Internalname ;
      private string edtTSTransImporteOrigen_Jsonclick ;
      private string edtTSTransBanDestino_Internalname ;
      private string edtTSTransBanDestino_Jsonclick ;
      private string edtTSTransBanDestinoDsc_Internalname ;
      private string A1980TSTransBanDestinoDsc ;
      private string edtTSTransBanDestinoDsc_Jsonclick ;
      private string edtTSTransBanCtaDestino_Internalname ;
      private string edtTSTransBanCtaDestino_Jsonclick ;
      private string edtTSTransConceptoDestino_Internalname ;
      private string edtTSTransConceptoDestino_Jsonclick ;
      private string edtTSTransGlosaDestino_Internalname ;
      private string edtTSTransGlosaDestino_Jsonclick ;
      private string edtTSTransOperacionDestino_Internalname ;
      private string edtTSTransOperacionDestino_Jsonclick ;
      private string edtTSTransTipoCambio_Internalname ;
      private string edtTSTransTipoCambio_Jsonclick ;
      private string edtTSTransImporteDestino_Internalname ;
      private string edtTSTransImporteDestino_Jsonclick ;
      private string edtTSTransRegDestino_Internalname ;
      private string edtTSTransRegDestino_Jsonclick ;
      private string edtTSTransRegOrigen_Internalname ;
      private string edtTSTransRegOrigen_Jsonclick ;
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
      private string Z1981TSTransBanOrigenDsc ;
      private string Z1980TSTransBanDestinoDsc ;
      private string sMode164 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1981TSTransBanOrigenDsc ;
      private string ZZ1980TSTransBanDestinoDsc ;
      private DateTime Z1984TSTransFec ;
      private DateTime A1984TSTransFec ;
      private DateTime ZZ1984TSTransFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z423TSTransCod ;
      private string Z1978TSTransBanCta ;
      private string Z1986TSTransGlosaOrigen ;
      private string Z1990TSTransOperacionOrigen ;
      private string Z1979TSTransBanCtaDestino ;
      private string Z1985TSTransGlosaDestino ;
      private string Z1989TSTransOperacionDestino ;
      private string Z1991TSTransRegDestino ;
      private string Z1992TSTransRegOrigen ;
      private string A423TSTransCod ;
      private string A1978TSTransBanCta ;
      private string A1986TSTransGlosaOrigen ;
      private string A1990TSTransOperacionOrigen ;
      private string A1979TSTransBanCtaDestino ;
      private string A1985TSTransGlosaDestino ;
      private string A1989TSTransOperacionDestino ;
      private string A1991TSTransRegDestino ;
      private string A1992TSTransRegOrigen ;
      private string ZZ423TSTransCod ;
      private string ZZ1978TSTransBanCta ;
      private string ZZ1986TSTransGlosaOrigen ;
      private string ZZ1990TSTransOperacionOrigen ;
      private string ZZ1979TSTransBanCtaDestino ;
      private string ZZ1985TSTransGlosaDestino ;
      private string ZZ1989TSTransOperacionDestino ;
      private string ZZ1991TSTransRegDestino ;
      private string ZZ1992TSTransRegOrigen ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T004X7_A423TSTransCod ;
      private DateTime[] T004X7_A1984TSTransFec ;
      private string[] T004X7_A1981TSTransBanOrigenDsc ;
      private string[] T004X7_A1978TSTransBanCta ;
      private int[] T004X7_A1983TSTransConceptoOrigen ;
      private string[] T004X7_A1986TSTransGlosaOrigen ;
      private string[] T004X7_A1990TSTransOperacionOrigen ;
      private decimal[] T004X7_A1988TSTransImporteOrigen ;
      private string[] T004X7_A1980TSTransBanDestinoDsc ;
      private string[] T004X7_A1979TSTransBanCtaDestino ;
      private int[] T004X7_A1982TSTransConceptoDestino ;
      private string[] T004X7_A1985TSTransGlosaDestino ;
      private string[] T004X7_A1989TSTransOperacionDestino ;
      private decimal[] T004X7_A1993TSTransTipoCambio ;
      private decimal[] T004X7_A1987TSTransImporteDestino ;
      private string[] T004X7_A1991TSTransRegDestino ;
      private string[] T004X7_A1992TSTransRegOrigen ;
      private int[] T004X7_A143ForCod ;
      private int[] T004X7_A424TSTransBanOrigen ;
      private int[] T004X7_A425TSTransBanDestino ;
      private int[] T004X4_A143ForCod ;
      private string[] T004X5_A1981TSTransBanOrigenDsc ;
      private string[] T004X6_A1980TSTransBanDestinoDsc ;
      private int[] T004X8_A143ForCod ;
      private string[] T004X9_A1981TSTransBanOrigenDsc ;
      private string[] T004X10_A1980TSTransBanDestinoDsc ;
      private string[] T004X11_A423TSTransCod ;
      private string[] T004X3_A423TSTransCod ;
      private DateTime[] T004X3_A1984TSTransFec ;
      private string[] T004X3_A1978TSTransBanCta ;
      private int[] T004X3_A1983TSTransConceptoOrigen ;
      private string[] T004X3_A1986TSTransGlosaOrigen ;
      private string[] T004X3_A1990TSTransOperacionOrigen ;
      private decimal[] T004X3_A1988TSTransImporteOrigen ;
      private string[] T004X3_A1979TSTransBanCtaDestino ;
      private int[] T004X3_A1982TSTransConceptoDestino ;
      private string[] T004X3_A1985TSTransGlosaDestino ;
      private string[] T004X3_A1989TSTransOperacionDestino ;
      private decimal[] T004X3_A1993TSTransTipoCambio ;
      private decimal[] T004X3_A1987TSTransImporteDestino ;
      private string[] T004X3_A1991TSTransRegDestino ;
      private string[] T004X3_A1992TSTransRegOrigen ;
      private int[] T004X3_A143ForCod ;
      private int[] T004X3_A424TSTransBanOrigen ;
      private int[] T004X3_A425TSTransBanDestino ;
      private string[] T004X12_A423TSTransCod ;
      private string[] T004X13_A423TSTransCod ;
      private string[] T004X2_A423TSTransCod ;
      private DateTime[] T004X2_A1984TSTransFec ;
      private string[] T004X2_A1978TSTransBanCta ;
      private int[] T004X2_A1983TSTransConceptoOrigen ;
      private string[] T004X2_A1986TSTransGlosaOrigen ;
      private string[] T004X2_A1990TSTransOperacionOrigen ;
      private decimal[] T004X2_A1988TSTransImporteOrigen ;
      private string[] T004X2_A1979TSTransBanCtaDestino ;
      private int[] T004X2_A1982TSTransConceptoDestino ;
      private string[] T004X2_A1985TSTransGlosaDestino ;
      private string[] T004X2_A1989TSTransOperacionDestino ;
      private decimal[] T004X2_A1993TSTransTipoCambio ;
      private decimal[] T004X2_A1987TSTransImporteDestino ;
      private string[] T004X2_A1991TSTransRegDestino ;
      private string[] T004X2_A1992TSTransRegOrigen ;
      private int[] T004X2_A143ForCod ;
      private int[] T004X2_A424TSTransBanOrigen ;
      private int[] T004X2_A425TSTransBanDestino ;
      private string[] T004X17_A1981TSTransBanOrigenDsc ;
      private string[] T004X18_A1980TSTransBanDestinoDsc ;
      private string[] T004X19_A423TSTransCod ;
      private int[] T004X20_A143ForCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tstransferenciabancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tstransferenciabancos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004X7;
        prmT004X7 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X4;
        prmT004X4 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT004X5;
        prmT004X5 = new Object[] {
        new ParDef("@TSTransBanOrigen",GXType.Int32,6,0)
        };
        Object[] prmT004X6;
        prmT004X6 = new Object[] {
        new ParDef("@TSTransBanDestino",GXType.Int32,6,0)
        };
        Object[] prmT004X8;
        prmT004X8 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT004X9;
        prmT004X9 = new Object[] {
        new ParDef("@TSTransBanOrigen",GXType.Int32,6,0)
        };
        Object[] prmT004X10;
        prmT004X10 = new Object[] {
        new ParDef("@TSTransBanDestino",GXType.Int32,6,0)
        };
        Object[] prmT004X11;
        prmT004X11 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X3;
        prmT004X3 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X12;
        prmT004X12 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X13;
        prmT004X13 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X2;
        prmT004X2 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X14;
        prmT004X14 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSTransFec",GXType.Date,8,0) ,
        new ParDef("@TSTransBanCta",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransConceptoOrigen",GXType.Int32,6,0) ,
        new ParDef("@TSTransGlosaOrigen",GXType.NVarChar,100,0) ,
        new ParDef("@TSTransOperacionOrigen",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransImporteOrigen",GXType.Decimal,15,2) ,
        new ParDef("@TSTransBanCtaDestino",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransConceptoDestino",GXType.Int32,6,0) ,
        new ParDef("@TSTransGlosaDestino",GXType.NVarChar,100,0) ,
        new ParDef("@TSTransOperacionDestino",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransTipoCambio",GXType.Decimal,15,4) ,
        new ParDef("@TSTransImporteDestino",GXType.Decimal,15,2) ,
        new ParDef("@TSTransRegDestino",GXType.NVarChar,10,0) ,
        new ParDef("@TSTransRegOrigen",GXType.NVarChar,10,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@TSTransBanOrigen",GXType.Int32,6,0) ,
        new ParDef("@TSTransBanDestino",GXType.Int32,6,0)
        };
        Object[] prmT004X15;
        prmT004X15 = new Object[] {
        new ParDef("@TSTransFec",GXType.Date,8,0) ,
        new ParDef("@TSTransBanCta",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransConceptoOrigen",GXType.Int32,6,0) ,
        new ParDef("@TSTransGlosaOrigen",GXType.NVarChar,100,0) ,
        new ParDef("@TSTransOperacionOrigen",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransImporteOrigen",GXType.Decimal,15,2) ,
        new ParDef("@TSTransBanCtaDestino",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransConceptoDestino",GXType.Int32,6,0) ,
        new ParDef("@TSTransGlosaDestino",GXType.NVarChar,100,0) ,
        new ParDef("@TSTransOperacionDestino",GXType.NVarChar,20,0) ,
        new ParDef("@TSTransTipoCambio",GXType.Decimal,15,4) ,
        new ParDef("@TSTransImporteDestino",GXType.Decimal,15,2) ,
        new ParDef("@TSTransRegDestino",GXType.NVarChar,10,0) ,
        new ParDef("@TSTransRegOrigen",GXType.NVarChar,10,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@TSTransBanOrigen",GXType.Int32,6,0) ,
        new ParDef("@TSTransBanDestino",GXType.Int32,6,0) ,
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X16;
        prmT004X16 = new Object[] {
        new ParDef("@TSTransCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004X19;
        prmT004X19 = new Object[] {
        };
        Object[] prmT004X20;
        prmT004X20 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT004X17;
        prmT004X17 = new Object[] {
        new ParDef("@TSTransBanOrigen",GXType.Int32,6,0)
        };
        Object[] prmT004X18;
        prmT004X18 = new Object[] {
        new ParDef("@TSTransBanDestino",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004X2", "SELECT [TSTransCod], [TSTransFec], [TSTransBanCta], [TSTransConceptoOrigen], [TSTransGlosaOrigen], [TSTransOperacionOrigen], [TSTransImporteOrigen], [TSTransBanCtaDestino], [TSTransConceptoDestino], [TSTransGlosaDestino], [TSTransOperacionDestino], [TSTransTipoCambio], [TSTransImporteDestino], [TSTransRegDestino], [TSTransRegOrigen], [ForCod], [TSTransBanOrigen] AS TSTransBanOrigen, [TSTransBanDestino] AS TSTransBanDestino FROM [TSTRANSFERENCIABANCOS] WITH (UPDLOCK) WHERE [TSTransCod] = @TSTransCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X3", "SELECT [TSTransCod], [TSTransFec], [TSTransBanCta], [TSTransConceptoOrigen], [TSTransGlosaOrigen], [TSTransOperacionOrigen], [TSTransImporteOrigen], [TSTransBanCtaDestino], [TSTransConceptoDestino], [TSTransGlosaDestino], [TSTransOperacionDestino], [TSTransTipoCambio], [TSTransImporteDestino], [TSTransRegDestino], [TSTransRegOrigen], [ForCod], [TSTransBanOrigen] AS TSTransBanOrigen, [TSTransBanDestino] AS TSTransBanDestino FROM [TSTRANSFERENCIABANCOS] WHERE [TSTransCod] = @TSTransCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X4", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X5", "SELECT [BanDsc] AS TSTransBanOrigenDsc FROM [TSBANCOS] WHERE [BanCod] = @TSTransBanOrigen ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X6", "SELECT [BanDsc] AS TSTransBanDestinoDsc FROM [TSBANCOS] WHERE [BanCod] = @TSTransBanDestino ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X7", "SELECT TM1.[TSTransCod], TM1.[TSTransFec], T2.[BanDsc] AS TSTransBanOrigenDsc, TM1.[TSTransBanCta], TM1.[TSTransConceptoOrigen], TM1.[TSTransGlosaOrigen], TM1.[TSTransOperacionOrigen], TM1.[TSTransImporteOrigen], T3.[BanDsc] AS TSTransBanDestinoDsc, TM1.[TSTransBanCtaDestino], TM1.[TSTransConceptoDestino], TM1.[TSTransGlosaDestino], TM1.[TSTransOperacionDestino], TM1.[TSTransTipoCambio], TM1.[TSTransImporteDestino], TM1.[TSTransRegDestino], TM1.[TSTransRegOrigen], TM1.[ForCod], TM1.[TSTransBanOrigen] AS TSTransBanOrigen, TM1.[TSTransBanDestino] AS TSTransBanDestino FROM (([TSTRANSFERENCIABANCOS] TM1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = TM1.[TSTransBanOrigen]) INNER JOIN [TSBANCOS] T3 ON T3.[BanCod] = TM1.[TSTransBanDestino]) WHERE TM1.[TSTransCod] = @TSTransCod ORDER BY TM1.[TSTransCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004X7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X8", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X9", "SELECT [BanDsc] AS TSTransBanOrigenDsc FROM [TSBANCOS] WHERE [BanCod] = @TSTransBanOrigen ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X10", "SELECT [BanDsc] AS TSTransBanDestinoDsc FROM [TSBANCOS] WHERE [BanCod] = @TSTransBanDestino ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X11", "SELECT [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE [TSTransCod] = @TSTransCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004X11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X12", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE ( [TSTransCod] > @TSTransCod) ORDER BY [TSTransCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004X12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004X13", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE ( [TSTransCod] < @TSTransCod) ORDER BY [TSTransCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004X13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004X14", "INSERT INTO [TSTRANSFERENCIABANCOS]([TSTransCod], [TSTransFec], [TSTransBanCta], [TSTransConceptoOrigen], [TSTransGlosaOrigen], [TSTransOperacionOrigen], [TSTransImporteOrigen], [TSTransBanCtaDestino], [TSTransConceptoDestino], [TSTransGlosaDestino], [TSTransOperacionDestino], [TSTransTipoCambio], [TSTransImporteDestino], [TSTransRegDestino], [TSTransRegOrigen], [ForCod], [TSTransBanOrigen], [TSTransBanDestino]) VALUES(@TSTransCod, @TSTransFec, @TSTransBanCta, @TSTransConceptoOrigen, @TSTransGlosaOrigen, @TSTransOperacionOrigen, @TSTransImporteOrigen, @TSTransBanCtaDestino, @TSTransConceptoDestino, @TSTransGlosaDestino, @TSTransOperacionDestino, @TSTransTipoCambio, @TSTransImporteDestino, @TSTransRegDestino, @TSTransRegOrigen, @ForCod, @TSTransBanOrigen, @TSTransBanDestino)", GxErrorMask.GX_NOMASK,prmT004X14)
           ,new CursorDef("T004X15", "UPDATE [TSTRANSFERENCIABANCOS] SET [TSTransFec]=@TSTransFec, [TSTransBanCta]=@TSTransBanCta, [TSTransConceptoOrigen]=@TSTransConceptoOrigen, [TSTransGlosaOrigen]=@TSTransGlosaOrigen, [TSTransOperacionOrigen]=@TSTransOperacionOrigen, [TSTransImporteOrigen]=@TSTransImporteOrigen, [TSTransBanCtaDestino]=@TSTransBanCtaDestino, [TSTransConceptoDestino]=@TSTransConceptoDestino, [TSTransGlosaDestino]=@TSTransGlosaDestino, [TSTransOperacionDestino]=@TSTransOperacionDestino, [TSTransTipoCambio]=@TSTransTipoCambio, [TSTransImporteDestino]=@TSTransImporteDestino, [TSTransRegDestino]=@TSTransRegDestino, [TSTransRegOrigen]=@TSTransRegOrigen, [ForCod]=@ForCod, [TSTransBanOrigen]=@TSTransBanOrigen, [TSTransBanDestino]=@TSTransBanDestino  WHERE [TSTransCod] = @TSTransCod", GxErrorMask.GX_NOMASK,prmT004X15)
           ,new CursorDef("T004X16", "DELETE FROM [TSTRANSFERENCIABANCOS]  WHERE [TSTransCod] = @TSTransCod", GxErrorMask.GX_NOMASK,prmT004X16)
           ,new CursorDef("T004X17", "SELECT [BanDsc] AS TSTransBanOrigenDsc FROM [TSBANCOS] WHERE [BanCod] = @TSTransBanOrigen ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X18", "SELECT [BanDsc] AS TSTransBanDestinoDsc FROM [TSBANCOS] WHERE [BanCod] = @TSTransBanDestino ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X19", "SELECT [TSTransCod] FROM [TSTRANSFERENCIABANCOS] ORDER BY [TSTransCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004X19,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004X20", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004X20,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((string[]) buf[13])[0] = rslt.getVarchar(14);
              ((string[]) buf[14])[0] = rslt.getVarchar(15);
              ((int[]) buf[15])[0] = rslt.getInt(16);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 100);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              ((decimal[]) buf[13])[0] = rslt.getDecimal(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((string[]) buf[15])[0] = rslt.getVarchar(16);
              ((string[]) buf[16])[0] = rslt.getVarchar(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
