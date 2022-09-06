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
   public class actcostodep : GXDataArea
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
            A2100ACTActCod = GetPar( "ACTActCod");
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = GetPar( "ActActItem");
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A2100ACTActCod, A2104ActActItem) ;
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
            Form.Meta.addItem("description", "Historico Costo Depreciación", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTHisAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actcostodep( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actcostodep( IGxContext context )
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Historico Costo Depreciación", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Title", 0, "", 1, 1, 0, 0, "HLP_ACTCOSTODEP.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 14,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ACTCOSTODEP.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisAno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisAno_Internalname, "Año", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2107ACTHisAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtACTHisAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A2107ACTHisAno), "ZZZ9") : context.localUtil.Format( (decimal)(A2107ACTHisAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisMes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisMes_Internalname, "Mes", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2108ACTHisMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtACTHisMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A2108ACTHisMes), "Z9") : context.localUtil.Format( (decimal)(A2108ACTHisMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTActCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTActCod_Internalname, "Codigo Activo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTActCod_Internalname, A2100ACTActCod, StringUtil.RTrim( context.localUtil.Format( A2100ACTActCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTActCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTActCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActActItem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActActItem_Internalname, "Item", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActActItem_Internalname, A2104ActActItem, StringUtil.RTrim( context.localUtil.Format( A2104ActActItem, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActActItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActActItem_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtActHisFec_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtActHisFec_Internalname, "Fecha", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtActHisFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtActHisFec_Internalname, context.localUtil.Format(A2190ActHisFec, "99/99/99"), context.localUtil.Format( A2190ActHisFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActHisFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtActHisFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_bitmap( context, edtActHisFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtActHisFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_ACTCOSTODEP.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisValor_Internalname, "Valor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A2193ACTHisValor, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTHisValor_Enabled!=0) ? context.localUtil.Format( A2193ACTHisValor, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2193ACTHisValor, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisValor_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisCostoHist_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisCostoHist_Internalname, "Costo Historico", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisCostoHist_Internalname, StringUtil.LTrim( StringUtil.NToC( A2188ACTHisCostoHist, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTHisCostoHist_Enabled!=0) ? context.localUtil.Format( A2188ACTHisCostoHist, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2188ACTHisCostoHist, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisCostoHist_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisCostoHist_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisDepre_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisDepre_Internalname, "Costo Depreciación", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisDepre_Internalname, StringUtil.LTrim( StringUtil.NToC( A2189ACTHisDepre, 17, 2, ".", "")), StringUtil.LTrim( ((edtACTHisDepre_Enabled!=0) ? context.localUtil.Format( A2189ACTHisDepre, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A2189ACTHisDepre, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisDepre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisDepre_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisAnoVou_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisAnoVou_Internalname, "Año Voucher", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisAnoVou_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2186ACTHisAnoVou), 4, 0, ".", "")), StringUtil.LTrim( ((edtACTHisAnoVou_Enabled!=0) ? context.localUtil.Format( (decimal)(A2186ACTHisAnoVou), "ZZZ9") : context.localUtil.Format( (decimal)(A2186ACTHisAnoVou), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisAnoVou_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisAnoVou_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisMesVou_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisMesVou_Internalname, "Mes Voucher", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisMesVou_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2191ACTHisMesVou), 2, 0, ".", "")), StringUtil.LTrim( ((edtACTHisMesVou_Enabled!=0) ? context.localUtil.Format( (decimal)(A2191ACTHisMesVou), "Z9") : context.localUtil.Format( (decimal)(A2191ACTHisMesVou), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisMesVou_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisMesVou_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisTASICod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisTASICod_Internalname, "Tipo Asiento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A2192ACTHisTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtACTHisTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A2192ACTHisTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A2192ACTHisTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisVouNum_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisVouNum_Internalname, "N° Voucher", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisVouNum_Internalname, StringUtil.RTrim( A2194ACTHisVouNum), StringUtil.RTrim( context.localUtil.Format( A2194ACTHisVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtACTHisCosCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtACTHisCosCod_Internalname, "C.Costos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTHisCosCod_Internalname, StringUtil.RTrim( A2187ACTHisCosCod), StringUtil.RTrim( context.localUtil.Format( A2187ACTHisCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTHisCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtACTHisCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTCOSTODEP.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTCOSTODEP.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ACTCOSTODEP.htm");
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
            Z2107ACTHisAno = (short)(context.localUtil.CToN( cgiGet( "Z2107ACTHisAno"), ".", ","));
            Z2108ACTHisMes = (short)(context.localUtil.CToN( cgiGet( "Z2108ACTHisMes"), ".", ","));
            Z2100ACTActCod = cgiGet( "Z2100ACTActCod");
            Z2104ActActItem = cgiGet( "Z2104ActActItem");
            Z2190ActHisFec = context.localUtil.CToD( cgiGet( "Z2190ActHisFec"), 0);
            Z2193ACTHisValor = context.localUtil.CToN( cgiGet( "Z2193ACTHisValor"), ".", ",");
            Z2188ACTHisCostoHist = context.localUtil.CToN( cgiGet( "Z2188ACTHisCostoHist"), ".", ",");
            Z2189ACTHisDepre = context.localUtil.CToN( cgiGet( "Z2189ACTHisDepre"), ".", ",");
            Z2186ACTHisAnoVou = (short)(context.localUtil.CToN( cgiGet( "Z2186ACTHisAnoVou"), ".", ","));
            Z2191ACTHisMesVou = (short)(context.localUtil.CToN( cgiGet( "Z2191ACTHisMesVou"), ".", ","));
            Z2192ACTHisTASICod = (int)(context.localUtil.CToN( cgiGet( "Z2192ACTHisTASICod"), ".", ","));
            Z2194ACTHisVouNum = cgiGet( "Z2194ACTHisVouNum");
            Z2187ACTHisCosCod = cgiGet( "Z2187ACTHisCosCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISANO");
               AnyError = 1;
               GX_FocusControl = edtACTHisAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2107ACTHisAno = 0;
               AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
            }
            else
            {
               A2107ACTHisAno = (short)(context.localUtil.CToN( cgiGet( edtACTHisAno_Internalname), ".", ","));
               AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISMES");
               AnyError = 1;
               GX_FocusControl = edtACTHisMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2108ACTHisMes = 0;
               AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
            }
            else
            {
               A2108ACTHisMes = (short)(context.localUtil.CToN( cgiGet( edtACTHisMes_Internalname), ".", ","));
               AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
            }
            A2100ACTActCod = cgiGet( edtACTActCod_Internalname);
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = cgiGet( edtActActItem_Internalname);
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            if ( context.localUtil.VCDate( cgiGet( edtActHisFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "ACTHISFEC");
               AnyError = 1;
               GX_FocusControl = edtActHisFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2190ActHisFec = DateTime.MinValue;
               AssignAttri("", false, "A2190ActHisFec", context.localUtil.Format(A2190ActHisFec, "99/99/99"));
            }
            else
            {
               A2190ActHisFec = context.localUtil.CToD( cgiGet( edtActHisFec_Internalname), 2);
               AssignAttri("", false, "A2190ActHisFec", context.localUtil.Format(A2190ActHisFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisValor_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisValor_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISVALOR");
               AnyError = 1;
               GX_FocusControl = edtACTHisValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2193ACTHisValor = 0;
               AssignAttri("", false, "A2193ACTHisValor", StringUtil.LTrimStr( A2193ACTHisValor, 15, 2));
            }
            else
            {
               A2193ACTHisValor = context.localUtil.CToN( cgiGet( edtACTHisValor_Internalname), ".", ",");
               AssignAttri("", false, "A2193ACTHisValor", StringUtil.LTrimStr( A2193ACTHisValor, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisCostoHist_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisCostoHist_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISCOSTOHIST");
               AnyError = 1;
               GX_FocusControl = edtACTHisCostoHist_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2188ACTHisCostoHist = 0;
               AssignAttri("", false, "A2188ACTHisCostoHist", StringUtil.LTrimStr( A2188ACTHisCostoHist, 15, 2));
            }
            else
            {
               A2188ACTHisCostoHist = context.localUtil.CToN( cgiGet( edtACTHisCostoHist_Internalname), ".", ",");
               AssignAttri("", false, "A2188ACTHisCostoHist", StringUtil.LTrimStr( A2188ACTHisCostoHist, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisDepre_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisDepre_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISDEPRE");
               AnyError = 1;
               GX_FocusControl = edtACTHisDepre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2189ACTHisDepre = 0;
               AssignAttri("", false, "A2189ACTHisDepre", StringUtil.LTrimStr( A2189ACTHisDepre, 15, 2));
            }
            else
            {
               A2189ACTHisDepre = context.localUtil.CToN( cgiGet( edtACTHisDepre_Internalname), ".", ",");
               AssignAttri("", false, "A2189ACTHisDepre", StringUtil.LTrimStr( A2189ACTHisDepre, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisAnoVou_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisAnoVou_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISANOVOU");
               AnyError = 1;
               GX_FocusControl = edtACTHisAnoVou_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2186ACTHisAnoVou = 0;
               AssignAttri("", false, "A2186ACTHisAnoVou", StringUtil.LTrimStr( (decimal)(A2186ACTHisAnoVou), 4, 0));
            }
            else
            {
               A2186ACTHisAnoVou = (short)(context.localUtil.CToN( cgiGet( edtACTHisAnoVou_Internalname), ".", ","));
               AssignAttri("", false, "A2186ACTHisAnoVou", StringUtil.LTrimStr( (decimal)(A2186ACTHisAnoVou), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisMesVou_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisMesVou_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISMESVOU");
               AnyError = 1;
               GX_FocusControl = edtACTHisMesVou_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2191ACTHisMesVou = 0;
               AssignAttri("", false, "A2191ACTHisMesVou", StringUtil.LTrimStr( (decimal)(A2191ACTHisMesVou), 2, 0));
            }
            else
            {
               A2191ACTHisMesVou = (short)(context.localUtil.CToN( cgiGet( edtACTHisMesVou_Internalname), ".", ","));
               AssignAttri("", false, "A2191ACTHisMesVou", StringUtil.LTrimStr( (decimal)(A2191ACTHisMesVou), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtACTHisTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtACTHisTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ACTHISTASICOD");
               AnyError = 1;
               GX_FocusControl = edtACTHisTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A2192ACTHisTASICod = 0;
               AssignAttri("", false, "A2192ACTHisTASICod", StringUtil.LTrimStr( (decimal)(A2192ACTHisTASICod), 6, 0));
            }
            else
            {
               A2192ACTHisTASICod = (int)(context.localUtil.CToN( cgiGet( edtACTHisTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A2192ACTHisTASICod", StringUtil.LTrimStr( (decimal)(A2192ACTHisTASICod), 6, 0));
            }
            A2194ACTHisVouNum = cgiGet( edtACTHisVouNum_Internalname);
            AssignAttri("", false, "A2194ACTHisVouNum", A2194ACTHisVouNum);
            A2187ACTHisCosCod = cgiGet( edtACTHisCosCod_Internalname);
            AssignAttri("", false, "A2187ACTHisCosCod", A2187ACTHisCosCod);
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
               A2107ACTHisAno = (short)(NumberUtil.Val( GetPar( "ACTHisAno"), "."));
               AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
               A2108ACTHisMes = (short)(NumberUtil.Val( GetPar( "ACTHisMes"), "."));
               AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
               A2100ACTActCod = GetPar( "ACTActCod");
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               A2104ActActItem = GetPar( "ActActItem");
               AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
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
               InitAll6W190( ) ;
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
         DisableAttributes6W190( ) ;
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

      protected void ResetCaption6W0( )
      {
      }

      protected void ZM6W190( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2190ActHisFec = T006W3_A2190ActHisFec[0];
               Z2193ACTHisValor = T006W3_A2193ACTHisValor[0];
               Z2188ACTHisCostoHist = T006W3_A2188ACTHisCostoHist[0];
               Z2189ACTHisDepre = T006W3_A2189ACTHisDepre[0];
               Z2186ACTHisAnoVou = T006W3_A2186ACTHisAnoVou[0];
               Z2191ACTHisMesVou = T006W3_A2191ACTHisMesVou[0];
               Z2192ACTHisTASICod = T006W3_A2192ACTHisTASICod[0];
               Z2194ACTHisVouNum = T006W3_A2194ACTHisVouNum[0];
               Z2187ACTHisCosCod = T006W3_A2187ACTHisCosCod[0];
            }
            else
            {
               Z2190ActHisFec = A2190ActHisFec;
               Z2193ACTHisValor = A2193ACTHisValor;
               Z2188ACTHisCostoHist = A2188ACTHisCostoHist;
               Z2189ACTHisDepre = A2189ACTHisDepre;
               Z2186ACTHisAnoVou = A2186ACTHisAnoVou;
               Z2191ACTHisMesVou = A2191ACTHisMesVou;
               Z2192ACTHisTASICod = A2192ACTHisTASICod;
               Z2194ACTHisVouNum = A2194ACTHisVouNum;
               Z2187ACTHisCosCod = A2187ACTHisCosCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z2107ACTHisAno = A2107ACTHisAno;
            Z2108ACTHisMes = A2108ACTHisMes;
            Z2190ActHisFec = A2190ActHisFec;
            Z2193ACTHisValor = A2193ACTHisValor;
            Z2188ACTHisCostoHist = A2188ACTHisCostoHist;
            Z2189ACTHisDepre = A2189ACTHisDepre;
            Z2186ACTHisAnoVou = A2186ACTHisAnoVou;
            Z2191ACTHisMesVou = A2191ACTHisMesVou;
            Z2192ACTHisTASICod = A2192ACTHisTASICod;
            Z2194ACTHisVouNum = A2194ACTHisVouNum;
            Z2187ACTHisCosCod = A2187ACTHisCosCod;
            Z2100ACTActCod = A2100ACTActCod;
            Z2104ActActItem = A2104ActActItem;
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

      protected void Load6W190( )
      {
         /* Using cursor T006W5 */
         pr_default.execute(3, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound190 = 1;
            A2190ActHisFec = T006W5_A2190ActHisFec[0];
            AssignAttri("", false, "A2190ActHisFec", context.localUtil.Format(A2190ActHisFec, "99/99/99"));
            A2193ACTHisValor = T006W5_A2193ACTHisValor[0];
            AssignAttri("", false, "A2193ACTHisValor", StringUtil.LTrimStr( A2193ACTHisValor, 15, 2));
            A2188ACTHisCostoHist = T006W5_A2188ACTHisCostoHist[0];
            AssignAttri("", false, "A2188ACTHisCostoHist", StringUtil.LTrimStr( A2188ACTHisCostoHist, 15, 2));
            A2189ACTHisDepre = T006W5_A2189ACTHisDepre[0];
            AssignAttri("", false, "A2189ACTHisDepre", StringUtil.LTrimStr( A2189ACTHisDepre, 15, 2));
            A2186ACTHisAnoVou = T006W5_A2186ACTHisAnoVou[0];
            AssignAttri("", false, "A2186ACTHisAnoVou", StringUtil.LTrimStr( (decimal)(A2186ACTHisAnoVou), 4, 0));
            A2191ACTHisMesVou = T006W5_A2191ACTHisMesVou[0];
            AssignAttri("", false, "A2191ACTHisMesVou", StringUtil.LTrimStr( (decimal)(A2191ACTHisMesVou), 2, 0));
            A2192ACTHisTASICod = T006W5_A2192ACTHisTASICod[0];
            AssignAttri("", false, "A2192ACTHisTASICod", StringUtil.LTrimStr( (decimal)(A2192ACTHisTASICod), 6, 0));
            A2194ACTHisVouNum = T006W5_A2194ACTHisVouNum[0];
            AssignAttri("", false, "A2194ACTHisVouNum", A2194ACTHisVouNum);
            A2187ACTHisCosCod = T006W5_A2187ACTHisCosCod[0];
            AssignAttri("", false, "A2187ACTHisCosCod", A2187ACTHisCosCod);
            ZM6W190( -2) ;
         }
         pr_default.close(3);
         OnLoadActions6W190( ) ;
      }

      protected void OnLoadActions6W190( )
      {
      }

      protected void CheckExtendedTable6W190( )
      {
         nIsDirty_190 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T006W4 */
         pr_default.execute(2, new Object[] {A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A2190ActHisFec) || ( DateTimeUtil.ResetTime ( A2190ActHisFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "ACTHISFEC");
            AnyError = 1;
            GX_FocusControl = edtActHisFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6W190( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( string A2100ACTActCod ,
                               string A2104ActActItem )
      {
         /* Using cursor T006W6 */
         pr_default.execute(4, new Object[] {A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
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

      protected void GetKey6W190( )
      {
         /* Using cursor T006W7 */
         pr_default.execute(5, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound190 = 1;
         }
         else
         {
            RcdFound190 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006W3 */
         pr_default.execute(1, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6W190( 2) ;
            RcdFound190 = 1;
            A2107ACTHisAno = T006W3_A2107ACTHisAno[0];
            AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
            A2108ACTHisMes = T006W3_A2108ACTHisMes[0];
            AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
            A2190ActHisFec = T006W3_A2190ActHisFec[0];
            AssignAttri("", false, "A2190ActHisFec", context.localUtil.Format(A2190ActHisFec, "99/99/99"));
            A2193ACTHisValor = T006W3_A2193ACTHisValor[0];
            AssignAttri("", false, "A2193ACTHisValor", StringUtil.LTrimStr( A2193ACTHisValor, 15, 2));
            A2188ACTHisCostoHist = T006W3_A2188ACTHisCostoHist[0];
            AssignAttri("", false, "A2188ACTHisCostoHist", StringUtil.LTrimStr( A2188ACTHisCostoHist, 15, 2));
            A2189ACTHisDepre = T006W3_A2189ACTHisDepre[0];
            AssignAttri("", false, "A2189ACTHisDepre", StringUtil.LTrimStr( A2189ACTHisDepre, 15, 2));
            A2186ACTHisAnoVou = T006W3_A2186ACTHisAnoVou[0];
            AssignAttri("", false, "A2186ACTHisAnoVou", StringUtil.LTrimStr( (decimal)(A2186ACTHisAnoVou), 4, 0));
            A2191ACTHisMesVou = T006W3_A2191ACTHisMesVou[0];
            AssignAttri("", false, "A2191ACTHisMesVou", StringUtil.LTrimStr( (decimal)(A2191ACTHisMesVou), 2, 0));
            A2192ACTHisTASICod = T006W3_A2192ACTHisTASICod[0];
            AssignAttri("", false, "A2192ACTHisTASICod", StringUtil.LTrimStr( (decimal)(A2192ACTHisTASICod), 6, 0));
            A2194ACTHisVouNum = T006W3_A2194ACTHisVouNum[0];
            AssignAttri("", false, "A2194ACTHisVouNum", A2194ACTHisVouNum);
            A2187ACTHisCosCod = T006W3_A2187ACTHisCosCod[0];
            AssignAttri("", false, "A2187ACTHisCosCod", A2187ACTHisCosCod);
            A2100ACTActCod = T006W3_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006W3_A2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            Z2107ACTHisAno = A2107ACTHisAno;
            Z2108ACTHisMes = A2108ACTHisMes;
            Z2100ACTActCod = A2100ACTActCod;
            Z2104ActActItem = A2104ActActItem;
            sMode190 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6W190( ) ;
            if ( AnyError == 1 )
            {
               RcdFound190 = 0;
               InitializeNonKey6W190( ) ;
            }
            Gx_mode = sMode190;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound190 = 0;
            InitializeNonKey6W190( ) ;
            sMode190 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode190;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6W190( ) ;
         if ( RcdFound190 == 0 )
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
         RcdFound190 = 0;
         /* Using cursor T006W8 */
         pr_default.execute(6, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T006W8_A2107ACTHisAno[0] < A2107ACTHisAno ) || ( T006W8_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( T006W8_A2108ACTHisMes[0] < A2108ACTHisMes ) || ( T006W8_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W8_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W8_A2100ACTActCod[0], A2100ACTActCod) < 0 ) || ( StringUtil.StrCmp(T006W8_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( T006W8_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W8_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W8_A2104ActActItem[0], A2104ActActItem) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T006W8_A2107ACTHisAno[0] > A2107ACTHisAno ) || ( T006W8_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( T006W8_A2108ACTHisMes[0] > A2108ACTHisMes ) || ( T006W8_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W8_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W8_A2100ACTActCod[0], A2100ACTActCod) > 0 ) || ( StringUtil.StrCmp(T006W8_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( T006W8_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W8_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W8_A2104ActActItem[0], A2104ActActItem) > 0 ) ) )
            {
               A2107ACTHisAno = T006W8_A2107ACTHisAno[0];
               AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
               A2108ACTHisMes = T006W8_A2108ACTHisMes[0];
               AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
               A2100ACTActCod = T006W8_A2100ACTActCod[0];
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               A2104ActActItem = T006W8_A2104ActActItem[0];
               AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
               RcdFound190 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound190 = 0;
         /* Using cursor T006W9 */
         pr_default.execute(7, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T006W9_A2107ACTHisAno[0] > A2107ACTHisAno ) || ( T006W9_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( T006W9_A2108ACTHisMes[0] > A2108ACTHisMes ) || ( T006W9_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W9_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W9_A2100ACTActCod[0], A2100ACTActCod) > 0 ) || ( StringUtil.StrCmp(T006W9_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( T006W9_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W9_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W9_A2104ActActItem[0], A2104ActActItem) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T006W9_A2107ACTHisAno[0] < A2107ACTHisAno ) || ( T006W9_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( T006W9_A2108ACTHisMes[0] < A2108ACTHisMes ) || ( T006W9_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W9_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W9_A2100ACTActCod[0], A2100ACTActCod) < 0 ) || ( StringUtil.StrCmp(T006W9_A2100ACTActCod[0], A2100ACTActCod) == 0 ) && ( T006W9_A2108ACTHisMes[0] == A2108ACTHisMes ) && ( T006W9_A2107ACTHisAno[0] == A2107ACTHisAno ) && ( StringUtil.StrCmp(T006W9_A2104ActActItem[0], A2104ActActItem) < 0 ) ) )
            {
               A2107ACTHisAno = T006W9_A2107ACTHisAno[0];
               AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
               A2108ACTHisMes = T006W9_A2108ACTHisMes[0];
               AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
               A2100ACTActCod = T006W9_A2100ACTActCod[0];
               AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
               A2104ActActItem = T006W9_A2104ActActItem[0];
               AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
               RcdFound190 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6W190( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTHisAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6W190( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound190 == 1 )
            {
               if ( ( A2107ACTHisAno != Z2107ACTHisAno ) || ( A2108ACTHisMes != Z2108ACTHisMes ) || ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 ) || ( StringUtil.StrCmp(A2104ActActItem, Z2104ActActItem) != 0 ) )
               {
                  A2107ACTHisAno = Z2107ACTHisAno;
                  AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
                  A2108ACTHisMes = Z2108ACTHisMes;
                  AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
                  A2100ACTActCod = Z2100ACTActCod;
                  AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
                  A2104ActActItem = Z2104ActActItem;
                  AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTHISANO");
                  AnyError = 1;
                  GX_FocusControl = edtACTHisAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTHisAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6W190( ) ;
                  GX_FocusControl = edtACTHisAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A2107ACTHisAno != Z2107ACTHisAno ) || ( A2108ACTHisMes != Z2108ACTHisMes ) || ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 ) || ( StringUtil.StrCmp(A2104ActActItem, Z2104ActActItem) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTHisAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6W190( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTHISANO");
                     AnyError = 1;
                     GX_FocusControl = edtACTHisAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTHisAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6W190( ) ;
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
         if ( ( A2107ACTHisAno != Z2107ACTHisAno ) || ( A2108ACTHisMes != Z2108ACTHisMes ) || ( StringUtil.StrCmp(A2100ACTActCod, Z2100ACTActCod) != 0 ) || ( StringUtil.StrCmp(A2104ActActItem, Z2104ActActItem) != 0 ) )
         {
            A2107ACTHisAno = Z2107ACTHisAno;
            AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
            A2108ACTHisMes = Z2108ACTHisMes;
            AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
            A2100ACTActCod = Z2100ACTActCod;
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = Z2104ActActItem;
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTHISANO");
            AnyError = 1;
            GX_FocusControl = edtACTHisAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTHisAno_Internalname;
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
         if ( RcdFound190 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTHISANO");
            AnyError = 1;
            GX_FocusControl = edtACTHisAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtActHisFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6W190( ) ;
         if ( RcdFound190 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActHisFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6W190( ) ;
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
         if ( RcdFound190 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActHisFec_Internalname;
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
         if ( RcdFound190 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActHisFec_Internalname;
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
         ScanStart6W190( ) ;
         if ( RcdFound190 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound190 != 0 )
            {
               ScanNext6W190( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActHisFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6W190( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6W190( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006W2 */
            pr_default.execute(0, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTCOSTODEP"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z2190ActHisFec ) != DateTimeUtil.ResetTime ( T006W2_A2190ActHisFec[0] ) ) || ( Z2193ACTHisValor != T006W2_A2193ACTHisValor[0] ) || ( Z2188ACTHisCostoHist != T006W2_A2188ACTHisCostoHist[0] ) || ( Z2189ACTHisDepre != T006W2_A2189ACTHisDepre[0] ) || ( Z2186ACTHisAnoVou != T006W2_A2186ACTHisAnoVou[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2191ACTHisMesVou != T006W2_A2191ACTHisMesVou[0] ) || ( Z2192ACTHisTASICod != T006W2_A2192ACTHisTASICod[0] ) || ( StringUtil.StrCmp(Z2194ACTHisVouNum, T006W2_A2194ACTHisVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z2187ACTHisCosCod, T006W2_A2187ACTHisCosCod[0]) != 0 ) )
            {
               if ( DateTimeUtil.ResetTime ( Z2190ActHisFec ) != DateTimeUtil.ResetTime ( T006W2_A2190ActHisFec[0] ) )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ActHisFec");
                  GXUtil.WriteLogRaw("Old: ",Z2190ActHisFec);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2190ActHisFec[0]);
               }
               if ( Z2193ACTHisValor != T006W2_A2193ACTHisValor[0] )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisValor");
                  GXUtil.WriteLogRaw("Old: ",Z2193ACTHisValor);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2193ACTHisValor[0]);
               }
               if ( Z2188ACTHisCostoHist != T006W2_A2188ACTHisCostoHist[0] )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisCostoHist");
                  GXUtil.WriteLogRaw("Old: ",Z2188ACTHisCostoHist);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2188ACTHisCostoHist[0]);
               }
               if ( Z2189ACTHisDepre != T006W2_A2189ACTHisDepre[0] )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisDepre");
                  GXUtil.WriteLogRaw("Old: ",Z2189ACTHisDepre);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2189ACTHisDepre[0]);
               }
               if ( Z2186ACTHisAnoVou != T006W2_A2186ACTHisAnoVou[0] )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisAnoVou");
                  GXUtil.WriteLogRaw("Old: ",Z2186ACTHisAnoVou);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2186ACTHisAnoVou[0]);
               }
               if ( Z2191ACTHisMesVou != T006W2_A2191ACTHisMesVou[0] )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisMesVou");
                  GXUtil.WriteLogRaw("Old: ",Z2191ACTHisMesVou);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2191ACTHisMesVou[0]);
               }
               if ( Z2192ACTHisTASICod != T006W2_A2192ACTHisTASICod[0] )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z2192ACTHisTASICod);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2192ACTHisTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z2194ACTHisVouNum, T006W2_A2194ACTHisVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z2194ACTHisVouNum);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2194ACTHisVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z2187ACTHisCosCod, T006W2_A2187ACTHisCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("actcostodep:[seudo value changed for attri]"+"ACTHisCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z2187ACTHisCosCod);
                  GXUtil.WriteLogRaw("Current: ",T006W2_A2187ACTHisCosCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTCOSTODEP"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6W190( )
      {
         BeforeValidate6W190( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6W190( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6W190( 0) ;
            CheckOptimisticConcurrency6W190( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6W190( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6W190( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006W10 */
                     pr_default.execute(8, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2190ActHisFec, A2193ACTHisValor, A2188ACTHisCostoHist, A2189ACTHisDepre, A2186ACTHisAnoVou, A2191ACTHisMesVou, A2192ACTHisTASICod, A2194ACTHisVouNum, A2187ACTHisCosCod, A2100ACTActCod, A2104ActActItem});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTCOSTODEP");
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
                           ResetCaption6W0( ) ;
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
               Load6W190( ) ;
            }
            EndLevel6W190( ) ;
         }
         CloseExtendedTableCursors6W190( ) ;
      }

      protected void Update6W190( )
      {
         BeforeValidate6W190( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6W190( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6W190( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6W190( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6W190( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006W11 */
                     pr_default.execute(9, new Object[] {A2190ActHisFec, A2193ACTHisValor, A2188ACTHisCostoHist, A2189ACTHisDepre, A2186ACTHisAnoVou, A2191ACTHisMesVou, A2192ACTHisTASICod, A2194ACTHisVouNum, A2187ACTHisCosCod, A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTCOSTODEP");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTCOSTODEP"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6W190( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6W0( ) ;
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
            EndLevel6W190( ) ;
         }
         CloseExtendedTableCursors6W190( ) ;
      }

      protected void DeferredUpdate6W190( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6W190( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6W190( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6W190( ) ;
            AfterConfirm6W190( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6W190( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006W12 */
                  pr_default.execute(10, new Object[] {A2107ACTHisAno, A2108ACTHisMes, A2100ACTActCod, A2104ActActItem});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTCOSTODEP");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound190 == 0 )
                        {
                           InitAll6W190( ) ;
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
                        ResetCaption6W0( ) ;
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
         sMode190 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6W190( ) ;
         Gx_mode = sMode190;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6W190( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel6W190( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6W190( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actcostodep",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actcostodep",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6W190( )
      {
         /* Using cursor T006W13 */
         pr_default.execute(11);
         RcdFound190 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound190 = 1;
            A2107ACTHisAno = T006W13_A2107ACTHisAno[0];
            AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
            A2108ACTHisMes = T006W13_A2108ACTHisMes[0];
            AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
            A2100ACTActCod = T006W13_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006W13_A2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6W190( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound190 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound190 = 1;
            A2107ACTHisAno = T006W13_A2107ACTHisAno[0];
            AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
            A2108ACTHisMes = T006W13_A2108ACTHisMes[0];
            AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
            A2100ACTActCod = T006W13_A2100ACTActCod[0];
            AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
            A2104ActActItem = T006W13_A2104ActActItem[0];
            AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         }
      }

      protected void ScanEnd6W190( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm6W190( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6W190( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6W190( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6W190( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6W190( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6W190( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6W190( )
      {
         edtACTHisAno_Enabled = 0;
         AssignProp("", false, edtACTHisAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisAno_Enabled), 5, 0), true);
         edtACTHisMes_Enabled = 0;
         AssignProp("", false, edtACTHisMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisMes_Enabled), 5, 0), true);
         edtACTActCod_Enabled = 0;
         AssignProp("", false, edtACTActCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTActCod_Enabled), 5, 0), true);
         edtActActItem_Enabled = 0;
         AssignProp("", false, edtActActItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActActItem_Enabled), 5, 0), true);
         edtActHisFec_Enabled = 0;
         AssignProp("", false, edtActHisFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActHisFec_Enabled), 5, 0), true);
         edtACTHisValor_Enabled = 0;
         AssignProp("", false, edtACTHisValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisValor_Enabled), 5, 0), true);
         edtACTHisCostoHist_Enabled = 0;
         AssignProp("", false, edtACTHisCostoHist_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisCostoHist_Enabled), 5, 0), true);
         edtACTHisDepre_Enabled = 0;
         AssignProp("", false, edtACTHisDepre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisDepre_Enabled), 5, 0), true);
         edtACTHisAnoVou_Enabled = 0;
         AssignProp("", false, edtACTHisAnoVou_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisAnoVou_Enabled), 5, 0), true);
         edtACTHisMesVou_Enabled = 0;
         AssignProp("", false, edtACTHisMesVou_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisMesVou_Enabled), 5, 0), true);
         edtACTHisTASICod_Enabled = 0;
         AssignProp("", false, edtACTHisTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisTASICod_Enabled), 5, 0), true);
         edtACTHisVouNum_Enabled = 0;
         AssignProp("", false, edtACTHisVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisVouNum_Enabled), 5, 0), true);
         edtACTHisCosCod_Enabled = 0;
         AssignProp("", false, edtACTHisCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTHisCosCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6W190( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6W0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265117", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("actcostodep.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2107ACTHisAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2107ACTHisAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2108ACTHisMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2108ACTHisMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2190ActHisFec", context.localUtil.DToC( Z2190ActHisFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z2193ACTHisValor", StringUtil.LTrim( StringUtil.NToC( Z2193ACTHisValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2188ACTHisCostoHist", StringUtil.LTrim( StringUtil.NToC( Z2188ACTHisCostoHist, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2189ACTHisDepre", StringUtil.LTrim( StringUtil.NToC( Z2189ACTHisDepre, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2186ACTHisAnoVou", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2186ACTHisAnoVou), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2191ACTHisMesVou", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2191ACTHisMesVou), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2192ACTHisTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2192ACTHisTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2194ACTHisVouNum", StringUtil.RTrim( Z2194ACTHisVouNum));
         GxWebStd.gx_hidden_field( context, "Z2187ACTHisCosCod", StringUtil.RTrim( Z2187ACTHisCosCod));
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
         return formatLink("actcostodep.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ACTCOSTODEP" ;
      }

      public override string GetPgmdesc( )
      {
         return "Historico Costo Depreciación" ;
      }

      protected void InitializeNonKey6W190( )
      {
         A2190ActHisFec = DateTime.MinValue;
         AssignAttri("", false, "A2190ActHisFec", context.localUtil.Format(A2190ActHisFec, "99/99/99"));
         A2193ACTHisValor = 0;
         AssignAttri("", false, "A2193ACTHisValor", StringUtil.LTrimStr( A2193ACTHisValor, 15, 2));
         A2188ACTHisCostoHist = 0;
         AssignAttri("", false, "A2188ACTHisCostoHist", StringUtil.LTrimStr( A2188ACTHisCostoHist, 15, 2));
         A2189ACTHisDepre = 0;
         AssignAttri("", false, "A2189ACTHisDepre", StringUtil.LTrimStr( A2189ACTHisDepre, 15, 2));
         A2186ACTHisAnoVou = 0;
         AssignAttri("", false, "A2186ACTHisAnoVou", StringUtil.LTrimStr( (decimal)(A2186ACTHisAnoVou), 4, 0));
         A2191ACTHisMesVou = 0;
         AssignAttri("", false, "A2191ACTHisMesVou", StringUtil.LTrimStr( (decimal)(A2191ACTHisMesVou), 2, 0));
         A2192ACTHisTASICod = 0;
         AssignAttri("", false, "A2192ACTHisTASICod", StringUtil.LTrimStr( (decimal)(A2192ACTHisTASICod), 6, 0));
         A2194ACTHisVouNum = "";
         AssignAttri("", false, "A2194ACTHisVouNum", A2194ACTHisVouNum);
         A2187ACTHisCosCod = "";
         AssignAttri("", false, "A2187ACTHisCosCod", A2187ACTHisCosCod);
         Z2190ActHisFec = DateTime.MinValue;
         Z2193ACTHisValor = 0;
         Z2188ACTHisCostoHist = 0;
         Z2189ACTHisDepre = 0;
         Z2186ACTHisAnoVou = 0;
         Z2191ACTHisMesVou = 0;
         Z2192ACTHisTASICod = 0;
         Z2194ACTHisVouNum = "";
         Z2187ACTHisCosCod = "";
      }

      protected void InitAll6W190( )
      {
         A2107ACTHisAno = 0;
         AssignAttri("", false, "A2107ACTHisAno", StringUtil.LTrimStr( (decimal)(A2107ACTHisAno), 4, 0));
         A2108ACTHisMes = 0;
         AssignAttri("", false, "A2108ACTHisMes", StringUtil.LTrimStr( (decimal)(A2108ACTHisMes), 2, 0));
         A2100ACTActCod = "";
         AssignAttri("", false, "A2100ACTActCod", A2100ACTActCod);
         A2104ActActItem = "";
         AssignAttri("", false, "A2104ActActItem", A2104ActActItem);
         InitializeNonKey6W190( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265129", true, true);
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
         context.AddJavascriptSource("actcostodep.js", "?202281810265129", false, true);
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
         edtACTHisAno_Internalname = "ACTHISANO";
         edtACTHisMes_Internalname = "ACTHISMES";
         edtACTActCod_Internalname = "ACTACTCOD";
         edtActActItem_Internalname = "ACTACTITEM";
         edtActHisFec_Internalname = "ACTHISFEC";
         edtACTHisValor_Internalname = "ACTHISVALOR";
         edtACTHisCostoHist_Internalname = "ACTHISCOSTOHIST";
         edtACTHisDepre_Internalname = "ACTHISDEPRE";
         edtACTHisAnoVou_Internalname = "ACTHISANOVOU";
         edtACTHisMesVou_Internalname = "ACTHISMESVOU";
         edtACTHisTASICod_Internalname = "ACTHISTASICOD";
         edtACTHisVouNum_Internalname = "ACTHISVOUNUM";
         edtACTHisCosCod_Internalname = "ACTHISCOSCOD";
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
         Form.Caption = "Historico Costo Depreciación";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtACTHisCosCod_Jsonclick = "";
         edtACTHisCosCod_Enabled = 1;
         edtACTHisVouNum_Jsonclick = "";
         edtACTHisVouNum_Enabled = 1;
         edtACTHisTASICod_Jsonclick = "";
         edtACTHisTASICod_Enabled = 1;
         edtACTHisMesVou_Jsonclick = "";
         edtACTHisMesVou_Enabled = 1;
         edtACTHisAnoVou_Jsonclick = "";
         edtACTHisAnoVou_Enabled = 1;
         edtACTHisDepre_Jsonclick = "";
         edtACTHisDepre_Enabled = 1;
         edtACTHisCostoHist_Jsonclick = "";
         edtACTHisCostoHist_Enabled = 1;
         edtACTHisValor_Jsonclick = "";
         edtACTHisValor_Enabled = 1;
         edtActHisFec_Jsonclick = "";
         edtActHisFec_Enabled = 1;
         edtActActItem_Jsonclick = "";
         edtActActItem_Enabled = 1;
         edtACTActCod_Jsonclick = "";
         edtACTActCod_Enabled = 1;
         edtACTHisMes_Jsonclick = "";
         edtACTHisMes_Enabled = 1;
         edtACTHisAno_Jsonclick = "";
         edtACTHisAno_Enabled = 1;
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
         /* Using cursor T006W14 */
         pr_default.execute(12, new Object[] {A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(12);
         GX_FocusControl = edtActHisFec_Internalname;
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

      public void Valid_Actactitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T006W14 */
         pr_default.execute(12, new Object[] {A2100ACTActCod, A2104ActActItem});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'ACTACTIVOSDET'.", "ForeignKeyNotFound", 1, "ACTACTITEM");
            AnyError = 1;
            GX_FocusControl = edtACTActCod_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A2190ActHisFec", context.localUtil.Format(A2190ActHisFec, "99/99/99"));
         AssignAttri("", false, "A2193ACTHisValor", StringUtil.LTrim( StringUtil.NToC( A2193ACTHisValor, 15, 2, ".", "")));
         AssignAttri("", false, "A2188ACTHisCostoHist", StringUtil.LTrim( StringUtil.NToC( A2188ACTHisCostoHist, 15, 2, ".", "")));
         AssignAttri("", false, "A2189ACTHisDepre", StringUtil.LTrim( StringUtil.NToC( A2189ACTHisDepre, 15, 2, ".", "")));
         AssignAttri("", false, "A2186ACTHisAnoVou", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2186ACTHisAnoVou), 4, 0, ".", "")));
         AssignAttri("", false, "A2191ACTHisMesVou", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2191ACTHisMesVou), 2, 0, ".", "")));
         AssignAttri("", false, "A2192ACTHisTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2192ACTHisTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A2194ACTHisVouNum", StringUtil.RTrim( A2194ACTHisVouNum));
         AssignAttri("", false, "A2187ACTHisCosCod", StringUtil.RTrim( A2187ACTHisCosCod));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2107ACTHisAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2107ACTHisAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2108ACTHisMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2108ACTHisMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2100ACTActCod", Z2100ACTActCod);
         GxWebStd.gx_hidden_field( context, "Z2104ActActItem", Z2104ActActItem);
         GxWebStd.gx_hidden_field( context, "Z2190ActHisFec", context.localUtil.Format(Z2190ActHisFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z2193ACTHisValor", StringUtil.LTrim( StringUtil.NToC( Z2193ACTHisValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2188ACTHisCostoHist", StringUtil.LTrim( StringUtil.NToC( Z2188ACTHisCostoHist, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2189ACTHisDepre", StringUtil.LTrim( StringUtil.NToC( Z2189ACTHisDepre, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2186ACTHisAnoVou", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2186ACTHisAnoVou), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2191ACTHisMesVou", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2191ACTHisMesVou), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2192ACTHisTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2192ACTHisTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2194ACTHisVouNum", StringUtil.RTrim( Z2194ACTHisVouNum));
         GxWebStd.gx_hidden_field( context, "Z2187ACTHisCosCod", StringUtil.RTrim( Z2187ACTHisCosCod));
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
         setEventMetadata("VALID_ACTHISANO","{handler:'Valid_Acthisano',iparms:[]");
         setEventMetadata("VALID_ACTHISANO",",oparms:[]}");
         setEventMetadata("VALID_ACTHISMES","{handler:'Valid_Acthismes',iparms:[]");
         setEventMetadata("VALID_ACTHISMES",",oparms:[]}");
         setEventMetadata("VALID_ACTACTCOD","{handler:'Valid_Actactcod',iparms:[]");
         setEventMetadata("VALID_ACTACTCOD",",oparms:[]}");
         setEventMetadata("VALID_ACTACTITEM","{handler:'Valid_Actactitem',iparms:[{av:'A2107ACTHisAno',fld:'ACTHISANO',pic:'ZZZ9'},{av:'A2108ACTHisMes',fld:'ACTHISMES',pic:'Z9'},{av:'A2100ACTActCod',fld:'ACTACTCOD',pic:''},{av:'A2104ActActItem',fld:'ACTACTITEM',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTACTITEM",",oparms:[{av:'A2190ActHisFec',fld:'ACTHISFEC',pic:''},{av:'A2193ACTHisValor',fld:'ACTHISVALOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2188ACTHisCostoHist',fld:'ACTHISCOSTOHIST',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2189ACTHisDepre',fld:'ACTHISDEPRE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A2186ACTHisAnoVou',fld:'ACTHISANOVOU',pic:'ZZZ9'},{av:'A2191ACTHisMesVou',fld:'ACTHISMESVOU',pic:'Z9'},{av:'A2192ACTHisTASICod',fld:'ACTHISTASICOD',pic:'ZZZZZ9'},{av:'A2194ACTHisVouNum',fld:'ACTHISVOUNUM',pic:''},{av:'A2187ACTHisCosCod',fld:'ACTHISCOSCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2107ACTHisAno'},{av:'Z2108ACTHisMes'},{av:'Z2100ACTActCod'},{av:'Z2104ActActItem'},{av:'Z2190ActHisFec'},{av:'Z2193ACTHisValor'},{av:'Z2188ACTHisCostoHist'},{av:'Z2189ACTHisDepre'},{av:'Z2186ACTHisAnoVou'},{av:'Z2191ACTHisMesVou'},{av:'Z2192ACTHisTASICod'},{av:'Z2194ACTHisVouNum'},{av:'Z2187ACTHisCosCod'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_ACTHISFEC","{handler:'Valid_Acthisfec',iparms:[]");
         setEventMetadata("VALID_ACTHISFEC",",oparms:[]}");
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
         Z2100ACTActCod = "";
         Z2104ActActItem = "";
         Z2190ActHisFec = DateTime.MinValue;
         Z2194ACTHisVouNum = "";
         Z2187ACTHisCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A2100ACTActCod = "";
         A2104ActActItem = "";
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
         A2190ActHisFec = DateTime.MinValue;
         A2194ACTHisVouNum = "";
         A2187ACTHisCosCod = "";
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
         T006W5_A2107ACTHisAno = new short[1] ;
         T006W5_A2108ACTHisMes = new short[1] ;
         T006W5_A2190ActHisFec = new DateTime[] {DateTime.MinValue} ;
         T006W5_A2193ACTHisValor = new decimal[1] ;
         T006W5_A2188ACTHisCostoHist = new decimal[1] ;
         T006W5_A2189ACTHisDepre = new decimal[1] ;
         T006W5_A2186ACTHisAnoVou = new short[1] ;
         T006W5_A2191ACTHisMesVou = new short[1] ;
         T006W5_A2192ACTHisTASICod = new int[1] ;
         T006W5_A2194ACTHisVouNum = new string[] {""} ;
         T006W5_A2187ACTHisCosCod = new string[] {""} ;
         T006W5_A2100ACTActCod = new string[] {""} ;
         T006W5_A2104ActActItem = new string[] {""} ;
         T006W4_A2100ACTActCod = new string[] {""} ;
         T006W6_A2100ACTActCod = new string[] {""} ;
         T006W7_A2107ACTHisAno = new short[1] ;
         T006W7_A2108ACTHisMes = new short[1] ;
         T006W7_A2100ACTActCod = new string[] {""} ;
         T006W7_A2104ActActItem = new string[] {""} ;
         T006W3_A2107ACTHisAno = new short[1] ;
         T006W3_A2108ACTHisMes = new short[1] ;
         T006W3_A2190ActHisFec = new DateTime[] {DateTime.MinValue} ;
         T006W3_A2193ACTHisValor = new decimal[1] ;
         T006W3_A2188ACTHisCostoHist = new decimal[1] ;
         T006W3_A2189ACTHisDepre = new decimal[1] ;
         T006W3_A2186ACTHisAnoVou = new short[1] ;
         T006W3_A2191ACTHisMesVou = new short[1] ;
         T006W3_A2192ACTHisTASICod = new int[1] ;
         T006W3_A2194ACTHisVouNum = new string[] {""} ;
         T006W3_A2187ACTHisCosCod = new string[] {""} ;
         T006W3_A2100ACTActCod = new string[] {""} ;
         T006W3_A2104ActActItem = new string[] {""} ;
         sMode190 = "";
         T006W8_A2107ACTHisAno = new short[1] ;
         T006W8_A2108ACTHisMes = new short[1] ;
         T006W8_A2100ACTActCod = new string[] {""} ;
         T006W8_A2104ActActItem = new string[] {""} ;
         T006W9_A2107ACTHisAno = new short[1] ;
         T006W9_A2108ACTHisMes = new short[1] ;
         T006W9_A2100ACTActCod = new string[] {""} ;
         T006W9_A2104ActActItem = new string[] {""} ;
         T006W2_A2107ACTHisAno = new short[1] ;
         T006W2_A2108ACTHisMes = new short[1] ;
         T006W2_A2190ActHisFec = new DateTime[] {DateTime.MinValue} ;
         T006W2_A2193ACTHisValor = new decimal[1] ;
         T006W2_A2188ACTHisCostoHist = new decimal[1] ;
         T006W2_A2189ACTHisDepre = new decimal[1] ;
         T006W2_A2186ACTHisAnoVou = new short[1] ;
         T006W2_A2191ACTHisMesVou = new short[1] ;
         T006W2_A2192ACTHisTASICod = new int[1] ;
         T006W2_A2194ACTHisVouNum = new string[] {""} ;
         T006W2_A2187ACTHisCosCod = new string[] {""} ;
         T006W2_A2100ACTActCod = new string[] {""} ;
         T006W2_A2104ActActItem = new string[] {""} ;
         T006W13_A2107ACTHisAno = new short[1] ;
         T006W13_A2108ACTHisMes = new short[1] ;
         T006W13_A2100ACTActCod = new string[] {""} ;
         T006W13_A2104ActActItem = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T006W14_A2100ACTActCod = new string[] {""} ;
         ZZ2100ACTActCod = "";
         ZZ2104ActActItem = "";
         ZZ2190ActHisFec = DateTime.MinValue;
         ZZ2194ACTHisVouNum = "";
         ZZ2187ACTHisCosCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actcostodep__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actcostodep__default(),
            new Object[][] {
                new Object[] {
               T006W2_A2107ACTHisAno, T006W2_A2108ACTHisMes, T006W2_A2190ActHisFec, T006W2_A2193ACTHisValor, T006W2_A2188ACTHisCostoHist, T006W2_A2189ACTHisDepre, T006W2_A2186ACTHisAnoVou, T006W2_A2191ACTHisMesVou, T006W2_A2192ACTHisTASICod, T006W2_A2194ACTHisVouNum,
               T006W2_A2187ACTHisCosCod, T006W2_A2100ACTActCod, T006W2_A2104ActActItem
               }
               , new Object[] {
               T006W3_A2107ACTHisAno, T006W3_A2108ACTHisMes, T006W3_A2190ActHisFec, T006W3_A2193ACTHisValor, T006W3_A2188ACTHisCostoHist, T006W3_A2189ACTHisDepre, T006W3_A2186ACTHisAnoVou, T006W3_A2191ACTHisMesVou, T006W3_A2192ACTHisTASICod, T006W3_A2194ACTHisVouNum,
               T006W3_A2187ACTHisCosCod, T006W3_A2100ACTActCod, T006W3_A2104ActActItem
               }
               , new Object[] {
               T006W4_A2100ACTActCod
               }
               , new Object[] {
               T006W5_A2107ACTHisAno, T006W5_A2108ACTHisMes, T006W5_A2190ActHisFec, T006W5_A2193ACTHisValor, T006W5_A2188ACTHisCostoHist, T006W5_A2189ACTHisDepre, T006W5_A2186ACTHisAnoVou, T006W5_A2191ACTHisMesVou, T006W5_A2192ACTHisTASICod, T006W5_A2194ACTHisVouNum,
               T006W5_A2187ACTHisCosCod, T006W5_A2100ACTActCod, T006W5_A2104ActActItem
               }
               , new Object[] {
               T006W6_A2100ACTActCod
               }
               , new Object[] {
               T006W7_A2107ACTHisAno, T006W7_A2108ACTHisMes, T006W7_A2100ACTActCod, T006W7_A2104ActActItem
               }
               , new Object[] {
               T006W8_A2107ACTHisAno, T006W8_A2108ACTHisMes, T006W8_A2100ACTActCod, T006W8_A2104ActActItem
               }
               , new Object[] {
               T006W9_A2107ACTHisAno, T006W9_A2108ACTHisMes, T006W9_A2100ACTActCod, T006W9_A2104ActActItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006W13_A2107ACTHisAno, T006W13_A2108ACTHisMes, T006W13_A2100ACTActCod, T006W13_A2104ActActItem
               }
               , new Object[] {
               T006W14_A2100ACTActCod
               }
            }
         );
      }

      private short Z2107ACTHisAno ;
      private short Z2108ACTHisMes ;
      private short Z2186ACTHisAnoVou ;
      private short Z2191ACTHisMesVou ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2107ACTHisAno ;
      private short A2108ACTHisMes ;
      private short A2186ACTHisAnoVou ;
      private short A2191ACTHisMesVou ;
      private short GX_JID ;
      private short RcdFound190 ;
      private short nIsDirty_190 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ2107ACTHisAno ;
      private short ZZ2108ACTHisMes ;
      private short ZZ2186ACTHisAnoVou ;
      private short ZZ2191ACTHisMesVou ;
      private int Z2192ACTHisTASICod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtACTHisAno_Enabled ;
      private int edtACTHisMes_Enabled ;
      private int edtACTActCod_Enabled ;
      private int edtActActItem_Enabled ;
      private int edtActHisFec_Enabled ;
      private int edtACTHisValor_Enabled ;
      private int edtACTHisCostoHist_Enabled ;
      private int edtACTHisDepre_Enabled ;
      private int edtACTHisAnoVou_Enabled ;
      private int edtACTHisMesVou_Enabled ;
      private int A2192ACTHisTASICod ;
      private int edtACTHisTASICod_Enabled ;
      private int edtACTHisVouNum_Enabled ;
      private int edtACTHisCosCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private int ZZ2192ACTHisTASICod ;
      private decimal Z2193ACTHisValor ;
      private decimal Z2188ACTHisCostoHist ;
      private decimal Z2189ACTHisDepre ;
      private decimal A2193ACTHisValor ;
      private decimal A2188ACTHisCostoHist ;
      private decimal A2189ACTHisDepre ;
      private decimal ZZ2193ACTHisValor ;
      private decimal ZZ2188ACTHisCostoHist ;
      private decimal ZZ2189ACTHisDepre ;
      private string sPrefix ;
      private string Z2194ACTHisVouNum ;
      private string Z2187ACTHisCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTHisAno_Internalname ;
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
      private string edtACTHisAno_Jsonclick ;
      private string edtACTHisMes_Internalname ;
      private string edtACTHisMes_Jsonclick ;
      private string edtACTActCod_Internalname ;
      private string edtACTActCod_Jsonclick ;
      private string edtActActItem_Internalname ;
      private string edtActActItem_Jsonclick ;
      private string edtActHisFec_Internalname ;
      private string edtActHisFec_Jsonclick ;
      private string edtACTHisValor_Internalname ;
      private string edtACTHisValor_Jsonclick ;
      private string edtACTHisCostoHist_Internalname ;
      private string edtACTHisCostoHist_Jsonclick ;
      private string edtACTHisDepre_Internalname ;
      private string edtACTHisDepre_Jsonclick ;
      private string edtACTHisAnoVou_Internalname ;
      private string edtACTHisAnoVou_Jsonclick ;
      private string edtACTHisMesVou_Internalname ;
      private string edtACTHisMesVou_Jsonclick ;
      private string edtACTHisTASICod_Internalname ;
      private string edtACTHisTASICod_Jsonclick ;
      private string edtACTHisVouNum_Internalname ;
      private string A2194ACTHisVouNum ;
      private string edtACTHisVouNum_Jsonclick ;
      private string edtACTHisCosCod_Internalname ;
      private string A2187ACTHisCosCod ;
      private string edtACTHisCosCod_Jsonclick ;
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
      private string sMode190 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ2194ACTHisVouNum ;
      private string ZZ2187ACTHisCosCod ;
      private DateTime Z2190ActHisFec ;
      private DateTime A2190ActHisFec ;
      private DateTime ZZ2190ActHisFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string Z2100ACTActCod ;
      private string Z2104ActActItem ;
      private string A2100ACTActCod ;
      private string A2104ActActItem ;
      private string ZZ2100ACTActCod ;
      private string ZZ2104ActActItem ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T006W5_A2107ACTHisAno ;
      private short[] T006W5_A2108ACTHisMes ;
      private DateTime[] T006W5_A2190ActHisFec ;
      private decimal[] T006W5_A2193ACTHisValor ;
      private decimal[] T006W5_A2188ACTHisCostoHist ;
      private decimal[] T006W5_A2189ACTHisDepre ;
      private short[] T006W5_A2186ACTHisAnoVou ;
      private short[] T006W5_A2191ACTHisMesVou ;
      private int[] T006W5_A2192ACTHisTASICod ;
      private string[] T006W5_A2194ACTHisVouNum ;
      private string[] T006W5_A2187ACTHisCosCod ;
      private string[] T006W5_A2100ACTActCod ;
      private string[] T006W5_A2104ActActItem ;
      private string[] T006W4_A2100ACTActCod ;
      private string[] T006W6_A2100ACTActCod ;
      private short[] T006W7_A2107ACTHisAno ;
      private short[] T006W7_A2108ACTHisMes ;
      private string[] T006W7_A2100ACTActCod ;
      private string[] T006W7_A2104ActActItem ;
      private short[] T006W3_A2107ACTHisAno ;
      private short[] T006W3_A2108ACTHisMes ;
      private DateTime[] T006W3_A2190ActHisFec ;
      private decimal[] T006W3_A2193ACTHisValor ;
      private decimal[] T006W3_A2188ACTHisCostoHist ;
      private decimal[] T006W3_A2189ACTHisDepre ;
      private short[] T006W3_A2186ACTHisAnoVou ;
      private short[] T006W3_A2191ACTHisMesVou ;
      private int[] T006W3_A2192ACTHisTASICod ;
      private string[] T006W3_A2194ACTHisVouNum ;
      private string[] T006W3_A2187ACTHisCosCod ;
      private string[] T006W3_A2100ACTActCod ;
      private string[] T006W3_A2104ActActItem ;
      private short[] T006W8_A2107ACTHisAno ;
      private short[] T006W8_A2108ACTHisMes ;
      private string[] T006W8_A2100ACTActCod ;
      private string[] T006W8_A2104ActActItem ;
      private short[] T006W9_A2107ACTHisAno ;
      private short[] T006W9_A2108ACTHisMes ;
      private string[] T006W9_A2100ACTActCod ;
      private string[] T006W9_A2104ActActItem ;
      private short[] T006W2_A2107ACTHisAno ;
      private short[] T006W2_A2108ACTHisMes ;
      private DateTime[] T006W2_A2190ActHisFec ;
      private decimal[] T006W2_A2193ACTHisValor ;
      private decimal[] T006W2_A2188ACTHisCostoHist ;
      private decimal[] T006W2_A2189ACTHisDepre ;
      private short[] T006W2_A2186ACTHisAnoVou ;
      private short[] T006W2_A2191ACTHisMesVou ;
      private int[] T006W2_A2192ACTHisTASICod ;
      private string[] T006W2_A2194ACTHisVouNum ;
      private string[] T006W2_A2187ACTHisCosCod ;
      private string[] T006W2_A2100ACTActCod ;
      private string[] T006W2_A2104ActActItem ;
      private short[] T006W13_A2107ACTHisAno ;
      private short[] T006W13_A2108ACTHisMes ;
      private string[] T006W13_A2100ACTActCod ;
      private string[] T006W13_A2104ActActItem ;
      private string[] T006W14_A2100ACTActCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class actcostodep__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actcostodep__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT006W5;
        prmT006W5 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W4;
        prmT006W4 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W6;
        prmT006W6 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W7;
        prmT006W7 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W3;
        prmT006W3 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W8;
        prmT006W8 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W9;
        prmT006W9 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W2;
        prmT006W2 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W10;
        prmT006W10 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ActHisFec",GXType.Date,8,0) ,
        new ParDef("@ACTHisValor",GXType.Decimal,15,2) ,
        new ParDef("@ACTHisCostoHist",GXType.Decimal,15,2) ,
        new ParDef("@ACTHisDepre",GXType.Decimal,15,2) ,
        new ParDef("@ACTHisAnoVou",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMesVou",GXType.Int16,2,0) ,
        new ParDef("@ACTHisTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTHisVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTHisCosCod",GXType.NChar,10,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W11;
        prmT006W11 = new Object[] {
        new ParDef("@ActHisFec",GXType.Date,8,0) ,
        new ParDef("@ACTHisValor",GXType.Decimal,15,2) ,
        new ParDef("@ACTHisCostoHist",GXType.Decimal,15,2) ,
        new ParDef("@ACTHisDepre",GXType.Decimal,15,2) ,
        new ParDef("@ACTHisAnoVou",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMesVou",GXType.Int16,2,0) ,
        new ParDef("@ACTHisTASICod",GXType.Int32,6,0) ,
        new ParDef("@ACTHisVouNum",GXType.NChar,10,0) ,
        new ParDef("@ACTHisCosCod",GXType.NChar,10,0) ,
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W12;
        prmT006W12 = new Object[] {
        new ParDef("@ACTHisAno",GXType.Int16,4,0) ,
        new ParDef("@ACTHisMes",GXType.Int16,2,0) ,
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        Object[] prmT006W13;
        prmT006W13 = new Object[] {
        };
        Object[] prmT006W14;
        prmT006W14 = new Object[] {
        new ParDef("@ACTActCod",GXType.NVarChar,20,0) ,
        new ParDef("@ActActItem",GXType.NVarChar,5,0)
        };
        def= new CursorDef[] {
            new CursorDef("T006W2", "SELECT [ACTHisAno], [ACTHisMes], [ActHisFec], [ACTHisValor], [ACTHisCostoHist], [ACTHisDepre], [ACTHisAnoVou], [ACTHisMesVou], [ACTHisTASICod], [ACTHisVouNum], [ACTHisCosCod], [ACTActCod], [ActActItem] FROM [ACTCOSTODEP] WITH (UPDLOCK) WHERE [ACTHisAno] = @ACTHisAno AND [ACTHisMes] = @ACTHisMes AND [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006W3", "SELECT [ACTHisAno], [ACTHisMes], [ActHisFec], [ACTHisValor], [ACTHisCostoHist], [ACTHisDepre], [ACTHisAnoVou], [ACTHisMesVou], [ACTHisTASICod], [ACTHisVouNum], [ACTHisCosCod], [ACTActCod], [ActActItem] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @ACTHisAno AND [ACTHisMes] = @ACTHisMes AND [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006W4", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006W4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006W5", "SELECT TM1.[ACTHisAno], TM1.[ACTHisMes], TM1.[ActHisFec], TM1.[ACTHisValor], TM1.[ACTHisCostoHist], TM1.[ACTHisDepre], TM1.[ACTHisAnoVou], TM1.[ACTHisMesVou], TM1.[ACTHisTASICod], TM1.[ACTHisVouNum], TM1.[ACTHisCosCod], TM1.[ACTActCod], TM1.[ActActItem] FROM [ACTCOSTODEP] TM1 WHERE TM1.[ACTHisAno] = @ACTHisAno and TM1.[ACTHisMes] = @ACTHisMes and TM1.[ACTActCod] = @ACTActCod and TM1.[ActActItem] = @ActActItem ORDER BY TM1.[ACTHisAno], TM1.[ACTHisMes], TM1.[ACTActCod], TM1.[ActActItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006W5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006W6", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006W6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006W7", "SELECT [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] FROM [ACTCOSTODEP] WHERE [ACTHisAno] = @ACTHisAno AND [ACTHisMes] = @ACTHisMes AND [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006W7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006W8", "SELECT TOP 1 [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] FROM [ACTCOSTODEP] WHERE ( [ACTHisAno] > @ACTHisAno or [ACTHisAno] = @ACTHisAno and [ACTHisMes] > @ACTHisMes or [ACTHisMes] = @ACTHisMes and [ACTHisAno] = @ACTHisAno and [ACTActCod] > @ACTActCod or [ACTActCod] = @ACTActCod and [ACTHisMes] = @ACTHisMes and [ACTHisAno] = @ACTHisAno and [ActActItem] > @ActActItem) ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006W8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006W9", "SELECT TOP 1 [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] FROM [ACTCOSTODEP] WHERE ( [ACTHisAno] < @ACTHisAno or [ACTHisAno] = @ACTHisAno and [ACTHisMes] < @ACTHisMes or [ACTHisMes] = @ACTHisMes and [ACTHisAno] = @ACTHisAno and [ACTActCod] < @ACTActCod or [ACTActCod] = @ACTActCod and [ACTHisMes] = @ACTHisMes and [ACTHisAno] = @ACTHisAno and [ActActItem] < @ActActItem) ORDER BY [ACTHisAno] DESC, [ACTHisMes] DESC, [ACTActCod] DESC, [ActActItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006W9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006W10", "INSERT INTO [ACTCOSTODEP]([ACTHisAno], [ACTHisMes], [ActHisFec], [ACTHisValor], [ACTHisCostoHist], [ACTHisDepre], [ACTHisAnoVou], [ACTHisMesVou], [ACTHisTASICod], [ACTHisVouNum], [ACTHisCosCod], [ACTActCod], [ActActItem]) VALUES(@ACTHisAno, @ACTHisMes, @ActHisFec, @ACTHisValor, @ACTHisCostoHist, @ACTHisDepre, @ACTHisAnoVou, @ACTHisMesVou, @ACTHisTASICod, @ACTHisVouNum, @ACTHisCosCod, @ACTActCod, @ActActItem)", GxErrorMask.GX_NOMASK,prmT006W10)
           ,new CursorDef("T006W11", "UPDATE [ACTCOSTODEP] SET [ActHisFec]=@ActHisFec, [ACTHisValor]=@ACTHisValor, [ACTHisCostoHist]=@ACTHisCostoHist, [ACTHisDepre]=@ACTHisDepre, [ACTHisAnoVou]=@ACTHisAnoVou, [ACTHisMesVou]=@ACTHisMesVou, [ACTHisTASICod]=@ACTHisTASICod, [ACTHisVouNum]=@ACTHisVouNum, [ACTHisCosCod]=@ACTHisCosCod  WHERE [ACTHisAno] = @ACTHisAno AND [ACTHisMes] = @ACTHisMes AND [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem", GxErrorMask.GX_NOMASK,prmT006W11)
           ,new CursorDef("T006W12", "DELETE FROM [ACTCOSTODEP]  WHERE [ACTHisAno] = @ACTHisAno AND [ACTHisMes] = @ACTHisMes AND [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem", GxErrorMask.GX_NOMASK,prmT006W12)
           ,new CursorDef("T006W13", "SELECT [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem] FROM [ACTCOSTODEP] ORDER BY [ACTHisAno], [ACTHisMes], [ACTActCod], [ActActItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006W13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006W14", "SELECT [ACTActCod] FROM [ACTACTIVOSDET] WHERE [ACTActCod] = @ACTActCod AND [ActActItem] = @ActActItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT006W14,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 10);
              ((string[]) buf[10])[0] = rslt.getString(11, 10);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((string[]) buf[12])[0] = rslt.getVarchar(13);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 11 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
