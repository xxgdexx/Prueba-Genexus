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
   public class tsmovbancosdet : GXDataArea
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
            A387TSMovCod = GetPar( "TSMovCod");
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A387TSMovCod) ;
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
            Form.Meta.addItem("description", "TSMOVBANCOSDET", 0) ;
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

      public tsmovbancosdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsmovbancosdet( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "TSMOVBANCOSDET", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_TSMOVBANCOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSMOVBANCOSDET.htm");
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
         GxWebStd.gx_label_element( context, edtTSMovCod_Internalname, "Cod.Movimiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovCod_Internalname, A387TSMovCod, StringUtil.RTrim( context.localUtil.Format( A387TSMovCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovDItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovDItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A390TSMovDItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtTSMovDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A390TSMovDItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A390TSMovDItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovDItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovDDoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovDDoc_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovDDoc_Internalname, A1967TSMovDDoc, StringUtil.RTrim( context.localUtil.Format( A1967TSMovDDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovDDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovDDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovDFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovDFec_Internalname, "Vcto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTSMovDFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTSMovDFec_Internalname, context.localUtil.Format(A1968TSMovDFec, "99/99/99"), context.localUtil.Format( A1968TSMovDFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovDFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovDFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_bitmap( context, edtTSMovDFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtTSMovDFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVBANCOSDET.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTSMovDImp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTSMovDImp_Internalname, "Importe", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTSMovDImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A1969TSMovDImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtTSMovDImp_Enabled!=0) ? context.localUtil.Format( A1969TSMovDImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1969TSMovDImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTSMovDImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTSMovDImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVBANCOSDET.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOSDET.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVBANCOSDET.htm");
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
            Z390TSMovDItem = (int)(context.localUtil.CToN( cgiGet( "Z390TSMovDItem"), ".", ","));
            Z1967TSMovDDoc = cgiGet( "Z1967TSMovDDoc");
            Z1968TSMovDFec = context.localUtil.CToD( cgiGet( "Z1968TSMovDFec"), 0);
            Z1969TSMovDImp = context.localUtil.CToN( cgiGet( "Z1969TSMovDImp"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A387TSMovCod = cgiGet( edtTSMovCod_Internalname);
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSMovDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTSMovDItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSMOVDITEM");
               AnyError = 1;
               GX_FocusControl = edtTSMovDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A390TSMovDItem = 0;
               AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
            }
            else
            {
               A390TSMovDItem = (int)(context.localUtil.CToN( cgiGet( edtTSMovDItem_Internalname), ".", ","));
               AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
            }
            A1967TSMovDDoc = cgiGet( edtTSMovDDoc_Internalname);
            AssignAttri("", false, "A1967TSMovDDoc", A1967TSMovDDoc);
            if ( context.localUtil.VCDate( cgiGet( edtTSMovDFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "TSMOVDFEC");
               AnyError = 1;
               GX_FocusControl = edtTSMovDFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1968TSMovDFec = DateTime.MinValue;
               AssignAttri("", false, "A1968TSMovDFec", context.localUtil.Format(A1968TSMovDFec, "99/99/99"));
            }
            else
            {
               A1968TSMovDFec = context.localUtil.CToD( cgiGet( edtTSMovDFec_Internalname), 2);
               AssignAttri("", false, "A1968TSMovDFec", context.localUtil.Format(A1968TSMovDFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTSMovDImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtTSMovDImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TSMOVDIMP");
               AnyError = 1;
               GX_FocusControl = edtTSMovDImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1969TSMovDImp = 0;
               AssignAttri("", false, "A1969TSMovDImp", StringUtil.LTrimStr( A1969TSMovDImp, 15, 2));
            }
            else
            {
               A1969TSMovDImp = context.localUtil.CToN( cgiGet( edtTSMovDImp_Internalname), ".", ",");
               AssignAttri("", false, "A1969TSMovDImp", StringUtil.LTrimStr( A1969TSMovDImp, 15, 2));
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
               A390TSMovDItem = (int)(NumberUtil.Val( GetPar( "TSMovDItem"), "."));
               AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
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
               InitAll4V162( ) ;
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
         DisableAttributes4V162( ) ;
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

      protected void ResetCaption4V0( )
      {
      }

      protected void ZM4V162( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1967TSMovDDoc = T004V3_A1967TSMovDDoc[0];
               Z1968TSMovDFec = T004V3_A1968TSMovDFec[0];
               Z1969TSMovDImp = T004V3_A1969TSMovDImp[0];
            }
            else
            {
               Z1967TSMovDDoc = A1967TSMovDDoc;
               Z1968TSMovDFec = A1968TSMovDFec;
               Z1969TSMovDImp = A1969TSMovDImp;
            }
         }
         if ( GX_JID == -2 )
         {
            Z390TSMovDItem = A390TSMovDItem;
            Z1967TSMovDDoc = A1967TSMovDDoc;
            Z1968TSMovDFec = A1968TSMovDFec;
            Z1969TSMovDImp = A1969TSMovDImp;
            Z387TSMovCod = A387TSMovCod;
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

      protected void Load4V162( )
      {
         /* Using cursor T004V5 */
         pr_default.execute(3, new Object[] {A387TSMovCod, A390TSMovDItem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound162 = 1;
            A1967TSMovDDoc = T004V5_A1967TSMovDDoc[0];
            AssignAttri("", false, "A1967TSMovDDoc", A1967TSMovDDoc);
            A1968TSMovDFec = T004V5_A1968TSMovDFec[0];
            AssignAttri("", false, "A1968TSMovDFec", context.localUtil.Format(A1968TSMovDFec, "99/99/99"));
            A1969TSMovDImp = T004V5_A1969TSMovDImp[0];
            AssignAttri("", false, "A1969TSMovDImp", StringUtil.LTrimStr( A1969TSMovDImp, 15, 2));
            ZM4V162( -2) ;
         }
         pr_default.close(3);
         OnLoadActions4V162( ) ;
      }

      protected void OnLoadActions4V162( )
      {
      }

      protected void CheckExtendedTable4V162( )
      {
         nIsDirty_162 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T004V4 */
         pr_default.execute(2, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimientos Bancos Otros'.", "ForeignKeyNotFound", 1, "TSMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1968TSMovDFec) || ( DateTimeUtil.ResetTime ( A1968TSMovDFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "TSMOVDFEC");
            AnyError = 1;
            GX_FocusControl = edtTSMovDFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors4V162( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A387TSMovCod )
      {
         /* Using cursor T004V6 */
         pr_default.execute(4, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimientos Bancos Otros'.", "ForeignKeyNotFound", 1, "TSMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey4V162( )
      {
         /* Using cursor T004V7 */
         pr_default.execute(5, new Object[] {A387TSMovCod, A390TSMovDItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound162 = 1;
         }
         else
         {
            RcdFound162 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T004V3 */
         pr_default.execute(1, new Object[] {A387TSMovCod, A390TSMovDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM4V162( 2) ;
            RcdFound162 = 1;
            A390TSMovDItem = T004V3_A390TSMovDItem[0];
            AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
            A1967TSMovDDoc = T004V3_A1967TSMovDDoc[0];
            AssignAttri("", false, "A1967TSMovDDoc", A1967TSMovDDoc);
            A1968TSMovDFec = T004V3_A1968TSMovDFec[0];
            AssignAttri("", false, "A1968TSMovDFec", context.localUtil.Format(A1968TSMovDFec, "99/99/99"));
            A1969TSMovDImp = T004V3_A1969TSMovDImp[0];
            AssignAttri("", false, "A1969TSMovDImp", StringUtil.LTrimStr( A1969TSMovDImp, 15, 2));
            A387TSMovCod = T004V3_A387TSMovCod[0];
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            Z387TSMovCod = A387TSMovCod;
            Z390TSMovDItem = A390TSMovDItem;
            sMode162 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load4V162( ) ;
            if ( AnyError == 1 )
            {
               RcdFound162 = 0;
               InitializeNonKey4V162( ) ;
            }
            Gx_mode = sMode162;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound162 = 0;
            InitializeNonKey4V162( ) ;
            sMode162 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode162;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey4V162( ) ;
         if ( RcdFound162 == 0 )
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
         RcdFound162 = 0;
         /* Using cursor T004V8 */
         pr_default.execute(6, new Object[] {A387TSMovCod, A390TSMovDItem});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T004V8_A387TSMovCod[0], A387TSMovCod) < 0 ) || ( StringUtil.StrCmp(T004V8_A387TSMovCod[0], A387TSMovCod) == 0 ) && ( T004V8_A390TSMovDItem[0] < A390TSMovDItem ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T004V8_A387TSMovCod[0], A387TSMovCod) > 0 ) || ( StringUtil.StrCmp(T004V8_A387TSMovCod[0], A387TSMovCod) == 0 ) && ( T004V8_A390TSMovDItem[0] > A390TSMovDItem ) ) )
            {
               A387TSMovCod = T004V8_A387TSMovCod[0];
               AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
               A390TSMovDItem = T004V8_A390TSMovDItem[0];
               AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
               RcdFound162 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound162 = 0;
         /* Using cursor T004V9 */
         pr_default.execute(7, new Object[] {A387TSMovCod, A390TSMovDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T004V9_A387TSMovCod[0], A387TSMovCod) > 0 ) || ( StringUtil.StrCmp(T004V9_A387TSMovCod[0], A387TSMovCod) == 0 ) && ( T004V9_A390TSMovDItem[0] > A390TSMovDItem ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T004V9_A387TSMovCod[0], A387TSMovCod) < 0 ) || ( StringUtil.StrCmp(T004V9_A387TSMovCod[0], A387TSMovCod) == 0 ) && ( T004V9_A390TSMovDItem[0] < A390TSMovDItem ) ) )
            {
               A387TSMovCod = T004V9_A387TSMovCod[0];
               AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
               A390TSMovDItem = T004V9_A390TSMovDItem[0];
               AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
               RcdFound162 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey4V162( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert4V162( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound162 == 1 )
            {
               if ( ( StringUtil.StrCmp(A387TSMovCod, Z387TSMovCod) != 0 ) || ( A390TSMovDItem != Z390TSMovDItem ) )
               {
                  A387TSMovCod = Z387TSMovCod;
                  AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
                  A390TSMovDItem = Z390TSMovDItem;
                  AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
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
                  Update4V162( ) ;
                  GX_FocusControl = edtTSMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A387TSMovCod, Z387TSMovCod) != 0 ) || ( A390TSMovDItem != Z390TSMovDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTSMovCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert4V162( ) ;
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
                     Insert4V162( ) ;
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
         if ( ( StringUtil.StrCmp(A387TSMovCod, Z387TSMovCod) != 0 ) || ( A390TSMovDItem != Z390TSMovDItem ) )
         {
            A387TSMovCod = Z387TSMovCod;
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            A390TSMovDItem = Z390TSMovDItem;
            AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
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
         if ( RcdFound162 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TSMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTSMovDDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart4V162( ) ;
         if ( RcdFound162 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovDDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4V162( ) ;
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
         if ( RcdFound162 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovDDoc_Internalname;
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
         if ( RcdFound162 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovDDoc_Internalname;
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
         ScanStart4V162( ) ;
         if ( RcdFound162 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound162 != 0 )
            {
               ScanNext4V162( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTSMovDDoc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd4V162( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency4V162( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T004V2 */
            pr_default.execute(0, new Object[] {A387TSMovCod, A390TSMovDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVBANCOSDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1967TSMovDDoc, T004V2_A1967TSMovDDoc[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1968TSMovDFec ) != DateTimeUtil.ResetTime ( T004V2_A1968TSMovDFec[0] ) ) || ( Z1969TSMovDImp != T004V2_A1969TSMovDImp[0] ) )
            {
               if ( StringUtil.StrCmp(Z1967TSMovDDoc, T004V2_A1967TSMovDDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovbancosdet:[seudo value changed for attri]"+"TSMovDDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1967TSMovDDoc);
                  GXUtil.WriteLogRaw("Current: ",T004V2_A1967TSMovDDoc[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1968TSMovDFec ) != DateTimeUtil.ResetTime ( T004V2_A1968TSMovDFec[0] ) )
               {
                  GXUtil.WriteLog("tsmovbancosdet:[seudo value changed for attri]"+"TSMovDFec");
                  GXUtil.WriteLogRaw("Old: ",Z1968TSMovDFec);
                  GXUtil.WriteLogRaw("Current: ",T004V2_A1968TSMovDFec[0]);
               }
               if ( Z1969TSMovDImp != T004V2_A1969TSMovDImp[0] )
               {
                  GXUtil.WriteLog("tsmovbancosdet:[seudo value changed for attri]"+"TSMovDImp");
                  GXUtil.WriteLogRaw("Old: ",Z1969TSMovDImp);
                  GXUtil.WriteLogRaw("Current: ",T004V2_A1969TSMovDImp[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSMOVBANCOSDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert4V162( )
      {
         BeforeValidate4V162( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4V162( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM4V162( 0) ;
            CheckOptimisticConcurrency4V162( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4V162( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert4V162( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004V10 */
                     pr_default.execute(8, new Object[] {A390TSMovDItem, A1967TSMovDDoc, A1968TSMovDFec, A1969TSMovDImp, A387TSMovCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVBANCOSDET");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption4V0( ) ;
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
               Load4V162( ) ;
            }
            EndLevel4V162( ) ;
         }
         CloseExtendedTableCursors4V162( ) ;
      }

      protected void Update4V162( )
      {
         BeforeValidate4V162( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable4V162( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4V162( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm4V162( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate4V162( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T004V11 */
                     pr_default.execute(9, new Object[] {A1967TSMovDDoc, A1968TSMovDFec, A1969TSMovDImp, A387TSMovCod, A390TSMovDItem});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVBANCOSDET");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVBANCOSDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate4V162( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption4V0( ) ;
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
            EndLevel4V162( ) ;
         }
         CloseExtendedTableCursors4V162( ) ;
      }

      protected void DeferredUpdate4V162( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate4V162( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency4V162( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls4V162( ) ;
            AfterConfirm4V162( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete4V162( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T004V12 */
                  pr_default.execute(10, new Object[] {A387TSMovCod, A390TSMovDItem});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("TSMOVBANCOSDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound162 == 0 )
                        {
                           InitAll4V162( ) ;
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
                        ResetCaption4V0( ) ;
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
         sMode162 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel4V162( ) ;
         Gx_mode = sMode162;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls4V162( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel4V162( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete4V162( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("tsmovbancosdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues4V0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("tsmovbancosdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart4V162( )
      {
         /* Using cursor T004V13 */
         pr_default.execute(11);
         RcdFound162 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound162 = 1;
            A387TSMovCod = T004V13_A387TSMovCod[0];
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            A390TSMovDItem = T004V13_A390TSMovDItem[0];
            AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext4V162( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound162 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound162 = 1;
            A387TSMovCod = T004V13_A387TSMovCod[0];
            AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
            A390TSMovDItem = T004V13_A390TSMovDItem[0];
            AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
         }
      }

      protected void ScanEnd4V162( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm4V162( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert4V162( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate4V162( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete4V162( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete4V162( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate4V162( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes4V162( )
      {
         edtTSMovCod_Enabled = 0;
         AssignProp("", false, edtTSMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovCod_Enabled), 5, 0), true);
         edtTSMovDItem_Enabled = 0;
         AssignProp("", false, edtTSMovDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovDItem_Enabled), 5, 0), true);
         edtTSMovDDoc_Enabled = 0;
         AssignProp("", false, edtTSMovDDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovDDoc_Enabled), 5, 0), true);
         edtTSMovDFec_Enabled = 0;
         AssignProp("", false, edtTSMovDFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovDFec_Enabled), 5, 0), true);
         edtTSMovDImp_Enabled = 0;
         AssignProp("", false, edtTSMovDImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTSMovDImp_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes4V162( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues4V0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810254086", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("tsmovbancosdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z390TSMovDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z390TSMovDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1967TSMovDDoc", Z1967TSMovDDoc);
         GxWebStd.gx_hidden_field( context, "Z1968TSMovDFec", context.localUtil.DToC( Z1968TSMovDFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1969TSMovDImp", StringUtil.LTrim( StringUtil.NToC( Z1969TSMovDImp, 15, 2, ".", "")));
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
         return formatLink("tsmovbancosdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSMOVBANCOSDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "TSMOVBANCOSDET" ;
      }

      protected void InitializeNonKey4V162( )
      {
         A1967TSMovDDoc = "";
         AssignAttri("", false, "A1967TSMovDDoc", A1967TSMovDDoc);
         A1968TSMovDFec = DateTime.MinValue;
         AssignAttri("", false, "A1968TSMovDFec", context.localUtil.Format(A1968TSMovDFec, "99/99/99"));
         A1969TSMovDImp = 0;
         AssignAttri("", false, "A1969TSMovDImp", StringUtil.LTrimStr( A1969TSMovDImp, 15, 2));
         Z1967TSMovDDoc = "";
         Z1968TSMovDFec = DateTime.MinValue;
         Z1969TSMovDImp = 0;
      }

      protected void InitAll4V162( )
      {
         A387TSMovCod = "";
         AssignAttri("", false, "A387TSMovCod", A387TSMovCod);
         A390TSMovDItem = 0;
         AssignAttri("", false, "A390TSMovDItem", StringUtil.LTrimStr( (decimal)(A390TSMovDItem), 6, 0));
         InitializeNonKey4V162( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810254092", true, true);
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
         context.AddJavascriptSource("tsmovbancosdet.js", "?202281810254092", false, true);
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
         edtTSMovDItem_Internalname = "TSMOVDITEM";
         edtTSMovDDoc_Internalname = "TSMOVDDOC";
         edtTSMovDFec_Internalname = "TSMOVDFEC";
         edtTSMovDImp_Internalname = "TSMOVDIMP";
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
         Form.Caption = "TSMOVBANCOSDET";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTSMovDImp_Jsonclick = "";
         edtTSMovDImp_Enabled = 1;
         edtTSMovDFec_Jsonclick = "";
         edtTSMovDFec_Enabled = 1;
         edtTSMovDDoc_Jsonclick = "";
         edtTSMovDDoc_Enabled = 1;
         edtTSMovDItem_Jsonclick = "";
         edtTSMovDItem_Enabled = 1;
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
         /* Using cursor T004V14 */
         pr_default.execute(12, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimientos Bancos Otros'.", "ForeignKeyNotFound", 1, "TSMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtTSMovDDoc_Internalname;
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
         /* Using cursor T004V14 */
         pr_default.execute(12, new Object[] {A387TSMovCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimientos Bancos Otros'.", "ForeignKeyNotFound", 1, "TSMOVCOD");
            AnyError = 1;
            GX_FocusControl = edtTSMovCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Tsmovditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1967TSMovDDoc", A1967TSMovDDoc);
         AssignAttri("", false, "A1968TSMovDFec", context.localUtil.Format(A1968TSMovDFec, "99/99/99"));
         AssignAttri("", false, "A1969TSMovDImp", StringUtil.LTrim( StringUtil.NToC( A1969TSMovDImp, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z387TSMovCod", Z387TSMovCod);
         GxWebStd.gx_hidden_field( context, "Z390TSMovDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z390TSMovDItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1967TSMovDDoc", Z1967TSMovDDoc);
         GxWebStd.gx_hidden_field( context, "Z1968TSMovDFec", context.localUtil.Format(Z1968TSMovDFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1969TSMovDImp", StringUtil.LTrim( StringUtil.NToC( Z1969TSMovDImp, 15, 2, ".", "")));
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
         setEventMetadata("VALID_TSMOVCOD","{handler:'Valid_Tsmovcod',iparms:[{av:'A387TSMovCod',fld:'TSMOVCOD',pic:''}]");
         setEventMetadata("VALID_TSMOVCOD",",oparms:[]}");
         setEventMetadata("VALID_TSMOVDITEM","{handler:'Valid_Tsmovditem',iparms:[{av:'A387TSMovCod',fld:'TSMOVCOD',pic:''},{av:'A390TSMovDItem',fld:'TSMOVDITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_TSMOVDITEM",",oparms:[{av:'A1967TSMovDDoc',fld:'TSMOVDDOC',pic:''},{av:'A1968TSMovDFec',fld:'TSMOVDFEC',pic:''},{av:'A1969TSMovDImp',fld:'TSMOVDIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z387TSMovCod'},{av:'Z390TSMovDItem'},{av:'Z1967TSMovDDoc'},{av:'Z1968TSMovDFec'},{av:'Z1969TSMovDImp'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_TSMOVDFEC","{handler:'Valid_Tsmovdfec',iparms:[]");
         setEventMetadata("VALID_TSMOVDFEC",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z387TSMovCod = "";
         Z1967TSMovDDoc = "";
         Z1968TSMovDFec = DateTime.MinValue;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A387TSMovCod = "";
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
         A1967TSMovDDoc = "";
         A1968TSMovDFec = DateTime.MinValue;
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
         T004V5_A390TSMovDItem = new int[1] ;
         T004V5_A1967TSMovDDoc = new string[] {""} ;
         T004V5_A1968TSMovDFec = new DateTime[] {DateTime.MinValue} ;
         T004V5_A1969TSMovDImp = new decimal[1] ;
         T004V5_A387TSMovCod = new string[] {""} ;
         T004V4_A387TSMovCod = new string[] {""} ;
         T004V6_A387TSMovCod = new string[] {""} ;
         T004V7_A387TSMovCod = new string[] {""} ;
         T004V7_A390TSMovDItem = new int[1] ;
         T004V3_A390TSMovDItem = new int[1] ;
         T004V3_A1967TSMovDDoc = new string[] {""} ;
         T004V3_A1968TSMovDFec = new DateTime[] {DateTime.MinValue} ;
         T004V3_A1969TSMovDImp = new decimal[1] ;
         T004V3_A387TSMovCod = new string[] {""} ;
         sMode162 = "";
         T004V8_A387TSMovCod = new string[] {""} ;
         T004V8_A390TSMovDItem = new int[1] ;
         T004V9_A387TSMovCod = new string[] {""} ;
         T004V9_A390TSMovDItem = new int[1] ;
         T004V2_A390TSMovDItem = new int[1] ;
         T004V2_A1967TSMovDDoc = new string[] {""} ;
         T004V2_A1968TSMovDFec = new DateTime[] {DateTime.MinValue} ;
         T004V2_A1969TSMovDImp = new decimal[1] ;
         T004V2_A387TSMovCod = new string[] {""} ;
         T004V13_A387TSMovCod = new string[] {""} ;
         T004V13_A390TSMovDItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T004V14_A387TSMovCod = new string[] {""} ;
         ZZ387TSMovCod = "";
         ZZ1967TSMovDDoc = "";
         ZZ1968TSMovDFec = DateTime.MinValue;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsmovbancosdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsmovbancosdet__default(),
            new Object[][] {
                new Object[] {
               T004V2_A390TSMovDItem, T004V2_A1967TSMovDDoc, T004V2_A1968TSMovDFec, T004V2_A1969TSMovDImp, T004V2_A387TSMovCod
               }
               , new Object[] {
               T004V3_A390TSMovDItem, T004V3_A1967TSMovDDoc, T004V3_A1968TSMovDFec, T004V3_A1969TSMovDImp, T004V3_A387TSMovCod
               }
               , new Object[] {
               T004V4_A387TSMovCod
               }
               , new Object[] {
               T004V5_A390TSMovDItem, T004V5_A1967TSMovDDoc, T004V5_A1968TSMovDFec, T004V5_A1969TSMovDImp, T004V5_A387TSMovCod
               }
               , new Object[] {
               T004V6_A387TSMovCod
               }
               , new Object[] {
               T004V7_A387TSMovCod, T004V7_A390TSMovDItem
               }
               , new Object[] {
               T004V8_A387TSMovCod, T004V8_A390TSMovDItem
               }
               , new Object[] {
               T004V9_A387TSMovCod, T004V9_A390TSMovDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T004V13_A387TSMovCod, T004V13_A390TSMovDItem
               }
               , new Object[] {
               T004V14_A387TSMovCod
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
      private short RcdFound162 ;
      private short nIsDirty_162 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z390TSMovDItem ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTSMovCod_Enabled ;
      private int A390TSMovDItem ;
      private int edtTSMovDItem_Enabled ;
      private int edtTSMovDDoc_Enabled ;
      private int edtTSMovDFec_Enabled ;
      private int edtTSMovDImp_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ390TSMovDItem ;
      private decimal Z1969TSMovDImp ;
      private decimal A1969TSMovDImp ;
      private decimal ZZ1969TSMovDImp ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
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
      private string edtTSMovDItem_Internalname ;
      private string edtTSMovDItem_Jsonclick ;
      private string edtTSMovDDoc_Internalname ;
      private string edtTSMovDDoc_Jsonclick ;
      private string edtTSMovDFec_Internalname ;
      private string edtTSMovDFec_Jsonclick ;
      private string edtTSMovDImp_Internalname ;
      private string edtTSMovDImp_Jsonclick ;
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
      private string sMode162 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z1968TSMovDFec ;
      private DateTime A1968TSMovDFec ;
      private DateTime ZZ1968TSMovDFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z387TSMovCod ;
      private string Z1967TSMovDDoc ;
      private string A387TSMovCod ;
      private string A1967TSMovDDoc ;
      private string ZZ387TSMovCod ;
      private string ZZ1967TSMovDDoc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T004V5_A390TSMovDItem ;
      private string[] T004V5_A1967TSMovDDoc ;
      private DateTime[] T004V5_A1968TSMovDFec ;
      private decimal[] T004V5_A1969TSMovDImp ;
      private string[] T004V5_A387TSMovCod ;
      private string[] T004V4_A387TSMovCod ;
      private string[] T004V6_A387TSMovCod ;
      private string[] T004V7_A387TSMovCod ;
      private int[] T004V7_A390TSMovDItem ;
      private int[] T004V3_A390TSMovDItem ;
      private string[] T004V3_A1967TSMovDDoc ;
      private DateTime[] T004V3_A1968TSMovDFec ;
      private decimal[] T004V3_A1969TSMovDImp ;
      private string[] T004V3_A387TSMovCod ;
      private string[] T004V8_A387TSMovCod ;
      private int[] T004V8_A390TSMovDItem ;
      private string[] T004V9_A387TSMovCod ;
      private int[] T004V9_A390TSMovDItem ;
      private int[] T004V2_A390TSMovDItem ;
      private string[] T004V2_A1967TSMovDDoc ;
      private DateTime[] T004V2_A1968TSMovDFec ;
      private decimal[] T004V2_A1969TSMovDImp ;
      private string[] T004V2_A387TSMovCod ;
      private string[] T004V13_A387TSMovCod ;
      private int[] T004V13_A390TSMovDItem ;
      private string[] T004V14_A387TSMovCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsmovbancosdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsmovbancosdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT004V5;
        prmT004V5 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V4;
        prmT004V4 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004V6;
        prmT004V6 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004V7;
        prmT004V7 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V3;
        prmT004V3 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V8;
        prmT004V8 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V9;
        prmT004V9 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V2;
        prmT004V2 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V10;
        prmT004V10 = new Object[] {
        new ParDef("@TSMovDItem",GXType.Int32,6,0) ,
        new ParDef("@TSMovDDoc",GXType.NVarChar,20,0) ,
        new ParDef("@TSMovDFec",GXType.Date,8,0) ,
        new ParDef("@TSMovDImp",GXType.Decimal,15,2) ,
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        Object[] prmT004V11;
        prmT004V11 = new Object[] {
        new ParDef("@TSMovDDoc",GXType.NVarChar,20,0) ,
        new ParDef("@TSMovDFec",GXType.Date,8,0) ,
        new ParDef("@TSMovDImp",GXType.Decimal,15,2) ,
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V12;
        prmT004V12 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0) ,
        new ParDef("@TSMovDItem",GXType.Int32,6,0)
        };
        Object[] prmT004V13;
        prmT004V13 = new Object[] {
        };
        Object[] prmT004V14;
        prmT004V14 = new Object[] {
        new ParDef("@TSMovCod",GXType.NVarChar,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T004V2", "SELECT [TSMovDItem], [TSMovDDoc], [TSMovDFec], [TSMovDImp], [TSMovCod] FROM [TSMOVBANCOSDET] WITH (UPDLOCK) WHERE [TSMovCod] = @TSMovCod AND [TSMovDItem] = @TSMovDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT004V2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004V3", "SELECT [TSMovDItem], [TSMovDDoc], [TSMovDFec], [TSMovDImp], [TSMovCod] FROM [TSMOVBANCOSDET] WHERE [TSMovCod] = @TSMovCod AND [TSMovDItem] = @TSMovDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT004V3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004V4", "SELECT [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovCod] = @TSMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004V4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004V5", "SELECT TM1.[TSMovDItem], TM1.[TSMovDDoc], TM1.[TSMovDFec], TM1.[TSMovDImp], TM1.[TSMovCod] FROM [TSMOVBANCOSDET] TM1 WHERE TM1.[TSMovCod] = @TSMovCod and TM1.[TSMovDItem] = @TSMovDItem ORDER BY TM1.[TSMovCod], TM1.[TSMovDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004V5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004V6", "SELECT [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovCod] = @TSMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004V6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004V7", "SELECT [TSMovCod], [TSMovDItem] FROM [TSMOVBANCOSDET] WHERE [TSMovCod] = @TSMovCod AND [TSMovDItem] = @TSMovDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004V7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004V8", "SELECT TOP 1 [TSMovCod], [TSMovDItem] FROM [TSMOVBANCOSDET] WHERE ( [TSMovCod] > @TSMovCod or [TSMovCod] = @TSMovCod and [TSMovDItem] > @TSMovDItem) ORDER BY [TSMovCod], [TSMovDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004V8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004V9", "SELECT TOP 1 [TSMovCod], [TSMovDItem] FROM [TSMOVBANCOSDET] WHERE ( [TSMovCod] < @TSMovCod or [TSMovCod] = @TSMovCod and [TSMovDItem] < @TSMovDItem) ORDER BY [TSMovCod] DESC, [TSMovDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT004V9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T004V10", "INSERT INTO [TSMOVBANCOSDET]([TSMovDItem], [TSMovDDoc], [TSMovDFec], [TSMovDImp], [TSMovCod]) VALUES(@TSMovDItem, @TSMovDDoc, @TSMovDFec, @TSMovDImp, @TSMovCod)", GxErrorMask.GX_NOMASK,prmT004V10)
           ,new CursorDef("T004V11", "UPDATE [TSMOVBANCOSDET] SET [TSMovDDoc]=@TSMovDDoc, [TSMovDFec]=@TSMovDFec, [TSMovDImp]=@TSMovDImp  WHERE [TSMovCod] = @TSMovCod AND [TSMovDItem] = @TSMovDItem", GxErrorMask.GX_NOMASK,prmT004V11)
           ,new CursorDef("T004V12", "DELETE FROM [TSMOVBANCOSDET]  WHERE [TSMovCod] = @TSMovCod AND [TSMovDItem] = @TSMovDItem", GxErrorMask.GX_NOMASK,prmT004V12)
           ,new CursorDef("T004V13", "SELECT [TSMovCod], [TSMovDItem] FROM [TSMOVBANCOSDET] ORDER BY [TSMovCod], [TSMovDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT004V13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T004V14", "SELECT [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovCod] = @TSMovCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT004V14,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
