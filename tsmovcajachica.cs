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
   public class tsmovcajachica : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A358CajCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A399MVLConcCajCod = (int)(NumberUtil.Val( GetPar( "MVLConcCajCod"), "."));
            AssignAttri("", false, "A399MVLConcCajCod", StringUtil.LTrimStr( (decimal)(A399MVLConcCajCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A399MVLConcCajCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A1306MVLConCajCue = GetPar( "MVLConCajCue");
            AssignAttri("", false, "A1306MVLConCajCue", A1306MVLConCajCue);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A1306MVLConCajCue) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A397MVLCosCod = GetPar( "MVLCosCod");
            n397MVLCosCod = false;
            AssignAttri("", false, "A397MVLCosCod", A397MVLCosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A397MVLCosCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A396MVLPrvCod = GetPar( "MVLPrvCod");
            AssignAttri("", false, "A396MVLPrvCod", A396MVLPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A396MVLPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A395MVLCueCod = GetPar( "MVLCueCod");
            AssignAttri("", false, "A395MVLCueCod", A395MVLCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A395MVLCueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A394MVLMonCod = (int)(NumberUtil.Val( GetPar( "MVLMonCod"), "."));
            AssignAttri("", false, "A394MVLMonCod", StringUtil.LTrimStr( (decimal)(A394MVLMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A394MVLMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A398MVLComCosCod = GetPar( "MVLComCosCod");
            n398MVLComCosCod = false;
            AssignAttri("", false, "A398MVLComCosCod", A398MVLComCosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A398MVLComCosCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A393MVLForCod = (int)(NumberUtil.Val( GetPar( "MVLForCod"), "."));
            n393MVLForCod = false;
            AssignAttri("", false, "A393MVLForCod", StringUtil.LTrimStr( (decimal)(A393MVLForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A393MVLForCod) ;
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
            Form.Meta.addItem("description", "Movimientos de Caja Chica", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsmovcajachica( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsmovcajachica( IGxContext context )
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
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Caja Chica", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A358CajCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCajCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A358CajCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCajCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Caja", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajCod_Internalname, StringUtil.RTrim( A391MVLCajCod), StringUtil.RTrim( context.localUtil.Format( A391MVLCajCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLITem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A392MVLITem), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLITem_Enabled!=0) ? context.localUtil.Format( (decimal)(A392MVLITem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A392MVLITem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLITem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLITem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLCajFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLCajFec_Internalname, context.localUtil.Format(A1295MVLCajFec, "99/99/99"), context.localUtil.Format( A1295MVLCajFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         GxWebStd.gx_bitmap( context, edtMVLCajFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLCajFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "N° Documento", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajDoc_Internalname, StringUtil.RTrim( A1293MVLCajDoc), StringUtil.RTrim( context.localUtil.Format( A1293MVLCajDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Concepto", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajConc_Internalname, StringUtil.RTrim( A1292MVLCajConc), StringUtil.RTrim( context.localUtil.Format( A1292MVLCajConc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajConc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajConc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Codigo Concepto de Caja", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLConcCajCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A399MVLConcCajCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLConcCajCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A399MVLConcCajCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A399MVLConcCajCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLConcCajCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLConcCajCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cuenta", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCueCodAux_Internalname, StringUtil.RTrim( A1311MVLCueCodAux), StringUtil.RTrim( context.localUtil.Format( A1311MVLCueCodAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCueCodAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCueCodAux_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Auxiliar", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCueAuxCod_Internalname, StringUtil.RTrim( A1310MVLCueAuxCod), StringUtil.RTrim( context.localUtil.Format( A1310MVLCueAuxCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCueAuxCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCueAuxCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Centro de Costo", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCosCod_Internalname, StringUtil.RTrim( A397MVLCosCod), StringUtil.RTrim( context.localUtil.Format( A397MVLCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Importe", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A1296MVLCajImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLCajImp_Enabled!=0) ? context.localUtil.Format( A1296MVLCajImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1296MVLCajImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Tipo Movimiento", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLTipo_Internalname, StringUtil.RTrim( A1361MVLTipo), StringUtil.RTrim( context.localUtil.Format( A1361MVLTipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLTipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLTipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "R.U.C", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLPrvCod_Internalname, StringUtil.RTrim( A396MVLPrvCod), StringUtil.RTrim( context.localUtil.Format( A396MVLPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "T. Documento", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajTCod_Internalname, StringUtil.RTrim( A1299MVLCajTCod), StringUtil.RTrim( context.localUtil.Format( A1299MVLCajTCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajTCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajTCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Documento", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajDocP_Internalname, StringUtil.RTrim( A1294MVLCajDocP), StringUtil.RTrim( context.localUtil.Format( A1294MVLCajDocP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajDocP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajDocP_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Registro", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajReg_Internalname, StringUtil.RTrim( A1297MVLCajReg), StringUtil.RTrim( context.localUtil.Format( A1297MVLCajReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Tipo Cambio", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCajTCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1298MVLCajTCmb, 10, 4, ".", "")), StringUtil.LTrim( ((edtMVLCajTCmb_Enabled!=0) ? context.localUtil.Format( A1298MVLCajTCmb, "ZZZZ9.9999") : context.localUtil.Format( A1298MVLCajTCmb, "ZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCajTCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCajTCmb_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Fecha", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLComFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLComFec_Internalname, context.localUtil.Format(A1302MVLComFec, "99/99/99"), context.localUtil.Format( A1302MVLComFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLComFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLComFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         GxWebStd.gx_bitmap( context, edtMVLComFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLComFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Fecha Registro", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLComFReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLComFReg_Internalname, context.localUtil.Format(A1303MVLComFReg, "99/99/99"), context.localUtil.Format( A1303MVLComFReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLComFReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLComFReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         GxWebStd.gx_bitmap( context, edtMVLComFReg_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLComFReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Cuenta Compras", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLCueCod_Internalname, StringUtil.RTrim( A395MVLCueCod), StringUtil.RTrim( context.localUtil.Format( A395MVLCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Sub Afecto", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLSubAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1358MVLSubAfecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLSubAfecto_Enabled!=0) ? context.localUtil.Format( A1358MVLSubAfecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1358MVLSubAfecto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLSubAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLSubAfecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Sub Inafecto", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLSubInafecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1359MVLSubInafecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLSubInafecto_Enabled!=0) ? context.localUtil.Format( A1359MVLSubInafecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1359MVLSubInafecto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLSubInafecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLSubInafecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "I.G.V.", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLIGV_Internalname, StringUtil.LTrim( StringUtil.NToC( A1354MVLIGV, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLIGV_Enabled!=0) ? context.localUtil.Format( A1354MVLIGV, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1354MVLIGV, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLIGV_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLIGV_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Total", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1362MVLTotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLTotal_Enabled!=0) ? context.localUtil.Format( A1362MVLTotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1362MVLTotal, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLTotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Total Pago", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLTotalPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A1363MVLTotalPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLTotalPago_Enabled!=0) ? context.localUtil.Format( A1363MVLTotalPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1363MVLTotalPago, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLTotalPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLTotalPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Año", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1366MVLVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtMVLVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1366MVLVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1366MVLVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Mes", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1367MVLVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtMVLVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1367MVLVouMes), "Z9") : context.localUtil.Format( (decimal)(A1367MVLVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Tipo Asiento", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1360MVLTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1360MVLTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1360MVLTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "N° Asiento", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLVouNum_Internalname, StringUtil.RTrim( A1368MVLVouNum), StringUtil.RTrim( context.localUtil.Format( A1368MVLVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Moneda", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A394MVLMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A394MVLMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A394MVLMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "C.Costos", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLComCosCod_Internalname, StringUtil.RTrim( A398MVLComCosCod), StringUtil.RTrim( context.localUtil.Format( A398MVLComCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLComCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLComCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Auxiliar", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLComAux_Internalname, StringUtil.RTrim( A1300MVLComAux), StringUtil.RTrim( context.localUtil.Format( A1300MVLComAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLComAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLComAux_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Cuenta Auxiliar", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLComCueCod_Internalname, StringUtil.RTrim( A1301MVLComCueCod), StringUtil.RTrim( context.localUtil.Format( A1301MVLComCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLComCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLComCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Forma de Pago", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A393MVLForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A393MVLForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A393MVLForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Registro de Pagos", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLPagReg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1355MVLPagReg), 10, 0, ".", "")), StringUtil.LTrim( ((edtMVLPagReg_Enabled!=0) ? context.localUtil.Format( (decimal)(A1355MVLPagReg), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1355MVLPagReg), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLPagReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLPagReg_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Redondeo", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLRedondeo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1357MVLRedondeo, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLRedondeo_Enabled!=0) ? context.localUtil.Format( A1357MVLRedondeo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1357MVLRedondeo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLRedondeo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLRedondeo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "% I.G.V.", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLComPorIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A1304MVLComPorIVA, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLComPorIVA_Enabled!=0) ? context.localUtil.Format( A1304MVLComPorIVA, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1304MVLComPorIVA, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLComPorIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLComPorIVA_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "Usuario", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLUsuCod_Internalname, StringUtil.RTrim( A1364MVLUsuCod), StringUtil.RTrim( context.localUtil.Format( A1364MVLUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Usuario Fecha", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLUsuFec_Internalname, context.localUtil.TToC( A1365MVLUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1365MVLUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         GxWebStd.gx_bitmap( context, edtMVLUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Tipo Registro de Compras", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLComTipReg_Internalname, StringUtil.RTrim( A1305MVLComTipReg), StringUtil.RTrim( context.localUtil.Format( A1305MVLComTipReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLComTipReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLComTipReg_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Concepto de Caja", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLConCajDsc_Internalname, StringUtil.RTrim( A1307MVLConCajDsc), StringUtil.RTrim( context.localUtil.Format( A1307MVLConCajDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLConCajDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLConCajDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock42_Internalname, "Cuenta Contable", "", "", lblTextblock42_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLConCajCue_Internalname, StringUtil.RTrim( A1306MVLConCajCue), StringUtil.RTrim( context.localUtil.Format( A1306MVLConCajCue, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLConCajCue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLConCajCue_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock43_Internalname, "Centro de Costos", "", "", lblTextblock43_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLCueCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1312MVLCueCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtMVLCueCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A1312MVLCueCos), "9") : context.localUtil.Format( (decimal)(A1312MVLCueCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCueCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCueCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock44_Internalname, "Proveedor", "", "", lblTextblock44_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLPrvDsc_Internalname, StringUtil.RTrim( A1356MVLPrvDsc), StringUtil.RTrim( context.localUtil.Format( A1356MVLPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock45_Internalname, "Cuenta", "", "", lblTextblock45_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLCueDsc_Internalname, StringUtil.RTrim( A1314MVLCueDsc), StringUtil.RTrim( context.localUtil.Format( A1314MVLCueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock46_Internalname, "Maneja C.Costo Compras", "", "", lblTextblock46_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLCueCosCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1313MVLCueCosCod), 1, 0, ".", "")), StringUtil.LTrim( ((edtMVLCueCosCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1313MVLCueCosCod), "9") : context.localUtil.Format( (decimal)(A1313MVLCueCosCod), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLCueCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLCueCosCod_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 249,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 250,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 252,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVCAJACHICA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 253,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSMOVCAJACHICA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
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
            Z358CajCod = (int)(context.localUtil.CToN( cgiGet( "Z358CajCod"), ".", ","));
            Z391MVLCajCod = cgiGet( "Z391MVLCajCod");
            Z392MVLITem = (int)(context.localUtil.CToN( cgiGet( "Z392MVLITem"), ".", ","));
            Z1295MVLCajFec = context.localUtil.CToD( cgiGet( "Z1295MVLCajFec"), 0);
            Z1293MVLCajDoc = cgiGet( "Z1293MVLCajDoc");
            Z1292MVLCajConc = cgiGet( "Z1292MVLCajConc");
            Z1311MVLCueCodAux = cgiGet( "Z1311MVLCueCodAux");
            Z1310MVLCueAuxCod = cgiGet( "Z1310MVLCueAuxCod");
            Z1296MVLCajImp = context.localUtil.CToN( cgiGet( "Z1296MVLCajImp"), ".", ",");
            Z1361MVLTipo = cgiGet( "Z1361MVLTipo");
            Z1299MVLCajTCod = cgiGet( "Z1299MVLCajTCod");
            Z1294MVLCajDocP = cgiGet( "Z1294MVLCajDocP");
            Z1297MVLCajReg = cgiGet( "Z1297MVLCajReg");
            Z1298MVLCajTCmb = context.localUtil.CToN( cgiGet( "Z1298MVLCajTCmb"), ".", ",");
            Z1302MVLComFec = context.localUtil.CToD( cgiGet( "Z1302MVLComFec"), 0);
            Z1303MVLComFReg = context.localUtil.CToD( cgiGet( "Z1303MVLComFReg"), 0);
            Z1358MVLSubAfecto = context.localUtil.CToN( cgiGet( "Z1358MVLSubAfecto"), ".", ",");
            Z1359MVLSubInafecto = context.localUtil.CToN( cgiGet( "Z1359MVLSubInafecto"), ".", ",");
            Z1354MVLIGV = context.localUtil.CToN( cgiGet( "Z1354MVLIGV"), ".", ",");
            Z1362MVLTotal = context.localUtil.CToN( cgiGet( "Z1362MVLTotal"), ".", ",");
            Z1363MVLTotalPago = context.localUtil.CToN( cgiGet( "Z1363MVLTotalPago"), ".", ",");
            Z1366MVLVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1366MVLVouAno"), ".", ","));
            Z1367MVLVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1367MVLVouMes"), ".", ","));
            Z1360MVLTASICod = (int)(context.localUtil.CToN( cgiGet( "Z1360MVLTASICod"), ".", ","));
            Z1368MVLVouNum = cgiGet( "Z1368MVLVouNum");
            Z1300MVLComAux = cgiGet( "Z1300MVLComAux");
            Z1301MVLComCueCod = cgiGet( "Z1301MVLComCueCod");
            Z1355MVLPagReg = (long)(context.localUtil.CToN( cgiGet( "Z1355MVLPagReg"), ".", ","));
            Z1357MVLRedondeo = context.localUtil.CToN( cgiGet( "Z1357MVLRedondeo"), ".", ",");
            Z1304MVLComPorIVA = context.localUtil.CToN( cgiGet( "Z1304MVLComPorIVA"), ".", ",");
            Z1364MVLUsuCod = cgiGet( "Z1364MVLUsuCod");
            Z1365MVLUsuFec = context.localUtil.CToT( cgiGet( "Z1365MVLUsuFec"), 0);
            Z1305MVLComTipReg = cgiGet( "Z1305MVLComTipReg");
            Z399MVLConcCajCod = (int)(context.localUtil.CToN( cgiGet( "Z399MVLConcCajCod"), ".", ","));
            Z397MVLCosCod = cgiGet( "Z397MVLCosCod");
            Z398MVLComCosCod = cgiGet( "Z398MVLComCosCod");
            Z396MVLPrvCod = cgiGet( "Z396MVLPrvCod");
            Z395MVLCueCod = cgiGet( "Z395MVLCueCod");
            Z394MVLMonCod = (int)(context.localUtil.CToN( cgiGet( "Z394MVLMonCod"), ".", ","));
            Z393MVLForCod = (int)(context.localUtil.CToN( cgiGet( "Z393MVLForCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A358CajCod = 0;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            else
            {
               A358CajCod = (int)(context.localUtil.CToN( cgiGet( edtCajCod_Internalname), ".", ","));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            }
            A391MVLCajCod = cgiGet( edtMVLCajCod_Internalname);
            AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLITem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLITem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLITEM");
               AnyError = 1;
               GX_FocusControl = edtMVLITem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A392MVLITem = 0;
               AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
            }
            else
            {
               A392MVLITem = (int)(context.localUtil.CToN( cgiGet( edtMVLITem_Internalname), ".", ","));
               AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtMVLCajFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "MVLCAJFEC");
               AnyError = 1;
               GX_FocusControl = edtMVLCajFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1295MVLCajFec = DateTime.MinValue;
               AssignAttri("", false, "A1295MVLCajFec", context.localUtil.Format(A1295MVLCajFec, "99/99/99"));
            }
            else
            {
               A1295MVLCajFec = context.localUtil.CToD( cgiGet( edtMVLCajFec_Internalname), 2);
               AssignAttri("", false, "A1295MVLCajFec", context.localUtil.Format(A1295MVLCajFec, "99/99/99"));
            }
            A1293MVLCajDoc = cgiGet( edtMVLCajDoc_Internalname);
            AssignAttri("", false, "A1293MVLCajDoc", A1293MVLCajDoc);
            A1292MVLCajConc = cgiGet( edtMVLCajConc_Internalname);
            AssignAttri("", false, "A1292MVLCajConc", A1292MVLCajConc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLConcCajCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLConcCajCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLCONCCAJCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLConcCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A399MVLConcCajCod = 0;
               AssignAttri("", false, "A399MVLConcCajCod", StringUtil.LTrimStr( (decimal)(A399MVLConcCajCod), 6, 0));
            }
            else
            {
               A399MVLConcCajCod = (int)(context.localUtil.CToN( cgiGet( edtMVLConcCajCod_Internalname), ".", ","));
               AssignAttri("", false, "A399MVLConcCajCod", StringUtil.LTrimStr( (decimal)(A399MVLConcCajCod), 6, 0));
            }
            A1311MVLCueCodAux = cgiGet( edtMVLCueCodAux_Internalname);
            AssignAttri("", false, "A1311MVLCueCodAux", A1311MVLCueCodAux);
            A1310MVLCueAuxCod = cgiGet( edtMVLCueAuxCod_Internalname);
            AssignAttri("", false, "A1310MVLCueAuxCod", A1310MVLCueAuxCod);
            A397MVLCosCod = cgiGet( edtMVLCosCod_Internalname);
            n397MVLCosCod = false;
            AssignAttri("", false, "A397MVLCosCod", A397MVLCosCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLCajImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLCajImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLCAJIMP");
               AnyError = 1;
               GX_FocusControl = edtMVLCajImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1296MVLCajImp = 0;
               AssignAttri("", false, "A1296MVLCajImp", StringUtil.LTrimStr( A1296MVLCajImp, 15, 2));
            }
            else
            {
               A1296MVLCajImp = context.localUtil.CToN( cgiGet( edtMVLCajImp_Internalname), ".", ",");
               AssignAttri("", false, "A1296MVLCajImp", StringUtil.LTrimStr( A1296MVLCajImp, 15, 2));
            }
            A1361MVLTipo = cgiGet( edtMVLTipo_Internalname);
            AssignAttri("", false, "A1361MVLTipo", A1361MVLTipo);
            A396MVLPrvCod = StringUtil.Upper( cgiGet( edtMVLPrvCod_Internalname));
            AssignAttri("", false, "A396MVLPrvCod", A396MVLPrvCod);
            A1299MVLCajTCod = cgiGet( edtMVLCajTCod_Internalname);
            AssignAttri("", false, "A1299MVLCajTCod", A1299MVLCajTCod);
            A1294MVLCajDocP = cgiGet( edtMVLCajDocP_Internalname);
            AssignAttri("", false, "A1294MVLCajDocP", A1294MVLCajDocP);
            A1297MVLCajReg = cgiGet( edtMVLCajReg_Internalname);
            AssignAttri("", false, "A1297MVLCajReg", A1297MVLCajReg);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLCajTCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLCajTCmb_Internalname), ".", ",") > 99999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLCAJTCMB");
               AnyError = 1;
               GX_FocusControl = edtMVLCajTCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1298MVLCajTCmb = 0;
               AssignAttri("", false, "A1298MVLCajTCmb", StringUtil.LTrimStr( A1298MVLCajTCmb, 10, 4));
            }
            else
            {
               A1298MVLCajTCmb = context.localUtil.CToN( cgiGet( edtMVLCajTCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1298MVLCajTCmb", StringUtil.LTrimStr( A1298MVLCajTCmb, 10, 4));
            }
            if ( context.localUtil.VCDate( cgiGet( edtMVLComFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "MVLCOMFEC");
               AnyError = 1;
               GX_FocusControl = edtMVLComFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1302MVLComFec = DateTime.MinValue;
               AssignAttri("", false, "A1302MVLComFec", context.localUtil.Format(A1302MVLComFec, "99/99/99"));
            }
            else
            {
               A1302MVLComFec = context.localUtil.CToD( cgiGet( edtMVLComFec_Internalname), 2);
               AssignAttri("", false, "A1302MVLComFec", context.localUtil.Format(A1302MVLComFec, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtMVLComFReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Registro"}), 1, "MVLCOMFREG");
               AnyError = 1;
               GX_FocusControl = edtMVLComFReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1303MVLComFReg = DateTime.MinValue;
               AssignAttri("", false, "A1303MVLComFReg", context.localUtil.Format(A1303MVLComFReg, "99/99/99"));
            }
            else
            {
               A1303MVLComFReg = context.localUtil.CToD( cgiGet( edtMVLComFReg_Internalname), 2);
               AssignAttri("", false, "A1303MVLComFReg", context.localUtil.Format(A1303MVLComFReg, "99/99/99"));
            }
            A395MVLCueCod = cgiGet( edtMVLCueCod_Internalname);
            AssignAttri("", false, "A395MVLCueCod", A395MVLCueCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLSubAfecto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLSubAfecto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLSUBAFECTO");
               AnyError = 1;
               GX_FocusControl = edtMVLSubAfecto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1358MVLSubAfecto = 0;
               AssignAttri("", false, "A1358MVLSubAfecto", StringUtil.LTrimStr( A1358MVLSubAfecto, 15, 2));
            }
            else
            {
               A1358MVLSubAfecto = context.localUtil.CToN( cgiGet( edtMVLSubAfecto_Internalname), ".", ",");
               AssignAttri("", false, "A1358MVLSubAfecto", StringUtil.LTrimStr( A1358MVLSubAfecto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLSubInafecto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLSubInafecto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLSUBINAFECTO");
               AnyError = 1;
               GX_FocusControl = edtMVLSubInafecto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1359MVLSubInafecto = 0;
               AssignAttri("", false, "A1359MVLSubInafecto", StringUtil.LTrimStr( A1359MVLSubInafecto, 15, 2));
            }
            else
            {
               A1359MVLSubInafecto = context.localUtil.CToN( cgiGet( edtMVLSubInafecto_Internalname), ".", ",");
               AssignAttri("", false, "A1359MVLSubInafecto", StringUtil.LTrimStr( A1359MVLSubInafecto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLIGV_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLIGV_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLIGV");
               AnyError = 1;
               GX_FocusControl = edtMVLIGV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1354MVLIGV = 0;
               AssignAttri("", false, "A1354MVLIGV", StringUtil.LTrimStr( A1354MVLIGV, 15, 2));
            }
            else
            {
               A1354MVLIGV = context.localUtil.CToN( cgiGet( edtMVLIGV_Internalname), ".", ",");
               AssignAttri("", false, "A1354MVLIGV", StringUtil.LTrimStr( A1354MVLIGV, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLTotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLTotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLTOTAL");
               AnyError = 1;
               GX_FocusControl = edtMVLTotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1362MVLTotal = 0;
               AssignAttri("", false, "A1362MVLTotal", StringUtil.LTrimStr( A1362MVLTotal, 15, 2));
            }
            else
            {
               A1362MVLTotal = context.localUtil.CToN( cgiGet( edtMVLTotal_Internalname), ".", ",");
               AssignAttri("", false, "A1362MVLTotal", StringUtil.LTrimStr( A1362MVLTotal, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLTotalPago_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLTotalPago_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLTOTALPAGO");
               AnyError = 1;
               GX_FocusControl = edtMVLTotalPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1363MVLTotalPago = 0;
               AssignAttri("", false, "A1363MVLTotalPago", StringUtil.LTrimStr( A1363MVLTotalPago, 15, 2));
            }
            else
            {
               A1363MVLTotalPago = context.localUtil.CToN( cgiGet( edtMVLTotalPago_Internalname), ".", ",");
               AssignAttri("", false, "A1363MVLTotalPago", StringUtil.LTrimStr( A1363MVLTotalPago, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLVOUANO");
               AnyError = 1;
               GX_FocusControl = edtMVLVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1366MVLVouAno = 0;
               AssignAttri("", false, "A1366MVLVouAno", StringUtil.LTrimStr( (decimal)(A1366MVLVouAno), 4, 0));
            }
            else
            {
               A1366MVLVouAno = (short)(context.localUtil.CToN( cgiGet( edtMVLVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1366MVLVouAno", StringUtil.LTrimStr( (decimal)(A1366MVLVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLVOUMES");
               AnyError = 1;
               GX_FocusControl = edtMVLVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1367MVLVouMes = 0;
               AssignAttri("", false, "A1367MVLVouMes", StringUtil.LTrimStr( (decimal)(A1367MVLVouMes), 2, 0));
            }
            else
            {
               A1367MVLVouMes = (short)(context.localUtil.CToN( cgiGet( edtMVLVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1367MVLVouMes", StringUtil.LTrimStr( (decimal)(A1367MVLVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLTASICOD");
               AnyError = 1;
               GX_FocusControl = edtMVLTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1360MVLTASICod = 0;
               AssignAttri("", false, "A1360MVLTASICod", StringUtil.LTrimStr( (decimal)(A1360MVLTASICod), 6, 0));
            }
            else
            {
               A1360MVLTASICod = (int)(context.localUtil.CToN( cgiGet( edtMVLTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A1360MVLTASICod", StringUtil.LTrimStr( (decimal)(A1360MVLTASICod), 6, 0));
            }
            A1368MVLVouNum = cgiGet( edtMVLVouNum_Internalname);
            AssignAttri("", false, "A1368MVLVouNum", A1368MVLVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLMONCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A394MVLMonCod = 0;
               AssignAttri("", false, "A394MVLMonCod", StringUtil.LTrimStr( (decimal)(A394MVLMonCod), 6, 0));
            }
            else
            {
               A394MVLMonCod = (int)(context.localUtil.CToN( cgiGet( edtMVLMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A394MVLMonCod", StringUtil.LTrimStr( (decimal)(A394MVLMonCod), 6, 0));
            }
            A398MVLComCosCod = cgiGet( edtMVLComCosCod_Internalname);
            n398MVLComCosCod = false;
            AssignAttri("", false, "A398MVLComCosCod", A398MVLComCosCod);
            A1300MVLComAux = cgiGet( edtMVLComAux_Internalname);
            AssignAttri("", false, "A1300MVLComAux", A1300MVLComAux);
            A1301MVLComCueCod = cgiGet( edtMVLComCueCod_Internalname);
            AssignAttri("", false, "A1301MVLComCueCod", A1301MVLComCueCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A393MVLForCod = 0;
               n393MVLForCod = false;
               AssignAttri("", false, "A393MVLForCod", StringUtil.LTrimStr( (decimal)(A393MVLForCod), 6, 0));
            }
            else
            {
               A393MVLForCod = (int)(context.localUtil.CToN( cgiGet( edtMVLForCod_Internalname), ".", ","));
               n393MVLForCod = false;
               AssignAttri("", false, "A393MVLForCod", StringUtil.LTrimStr( (decimal)(A393MVLForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLPagReg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLPagReg_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLPAGREG");
               AnyError = 1;
               GX_FocusControl = edtMVLPagReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1355MVLPagReg = 0;
               AssignAttri("", false, "A1355MVLPagReg", StringUtil.LTrimStr( (decimal)(A1355MVLPagReg), 10, 0));
            }
            else
            {
               A1355MVLPagReg = (long)(context.localUtil.CToN( cgiGet( edtMVLPagReg_Internalname), ".", ","));
               AssignAttri("", false, "A1355MVLPagReg", StringUtil.LTrimStr( (decimal)(A1355MVLPagReg), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLRedondeo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLRedondeo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLREDONDEO");
               AnyError = 1;
               GX_FocusControl = edtMVLRedondeo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1357MVLRedondeo = 0;
               AssignAttri("", false, "A1357MVLRedondeo", StringUtil.LTrimStr( A1357MVLRedondeo, 15, 2));
            }
            else
            {
               A1357MVLRedondeo = context.localUtil.CToN( cgiGet( edtMVLRedondeo_Internalname), ".", ",");
               AssignAttri("", false, "A1357MVLRedondeo", StringUtil.LTrimStr( A1357MVLRedondeo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLComPorIVA_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLComPorIVA_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLCOMPORIVA");
               AnyError = 1;
               GX_FocusControl = edtMVLComPorIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1304MVLComPorIVA = 0;
               AssignAttri("", false, "A1304MVLComPorIVA", StringUtil.LTrimStr( A1304MVLComPorIVA, 15, 2));
            }
            else
            {
               A1304MVLComPorIVA = context.localUtil.CToN( cgiGet( edtMVLComPorIVA_Internalname), ".", ",");
               AssignAttri("", false, "A1304MVLComPorIVA", StringUtil.LTrimStr( A1304MVLComPorIVA, 15, 2));
            }
            A1364MVLUsuCod = cgiGet( edtMVLUsuCod_Internalname);
            AssignAttri("", false, "A1364MVLUsuCod", A1364MVLUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtMVLUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "MVLUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtMVLUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1365MVLUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1365MVLUsuFec", context.localUtil.TToC( A1365MVLUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1365MVLUsuFec = context.localUtil.CToT( cgiGet( edtMVLUsuFec_Internalname));
               AssignAttri("", false, "A1365MVLUsuFec", context.localUtil.TToC( A1365MVLUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            A1305MVLComTipReg = cgiGet( edtMVLComTipReg_Internalname);
            AssignAttri("", false, "A1305MVLComTipReg", A1305MVLComTipReg);
            A1307MVLConCajDsc = cgiGet( edtMVLConCajDsc_Internalname);
            AssignAttri("", false, "A1307MVLConCajDsc", A1307MVLConCajDsc);
            A1306MVLConCajCue = cgiGet( edtMVLConCajCue_Internalname);
            AssignAttri("", false, "A1306MVLConCajCue", A1306MVLConCajCue);
            A1312MVLCueCos = (short)(context.localUtil.CToN( cgiGet( edtMVLCueCos_Internalname), ".", ","));
            AssignAttri("", false, "A1312MVLCueCos", StringUtil.Str( (decimal)(A1312MVLCueCos), 1, 0));
            A1356MVLPrvDsc = cgiGet( edtMVLPrvDsc_Internalname);
            AssignAttri("", false, "A1356MVLPrvDsc", A1356MVLPrvDsc);
            A1314MVLCueDsc = cgiGet( edtMVLCueDsc_Internalname);
            AssignAttri("", false, "A1314MVLCueDsc", A1314MVLCueDsc);
            A1313MVLCueCosCod = (short)(context.localUtil.CToN( cgiGet( edtMVLCueCosCod_Internalname), ".", ","));
            AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.Str( (decimal)(A1313MVLCueCosCod), 1, 0));
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
               A358CajCod = (int)(NumberUtil.Val( GetPar( "CajCod"), "."));
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A391MVLCajCod = GetPar( "MVLCajCod");
               AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
               A392MVLITem = (int)(NumberUtil.Val( GetPar( "MVLITem"), "."));
               AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
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
                        else if ( StringUtil.StrCmp(sEvt, "GET") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_get( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "CHECK") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_Check( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                           /* No code required for Help button. It is implemented at the Browser level. */
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
               InitAll5B178( ) ;
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
         bttBtn_get_Visible = 0;
         AssignProp("", false, bttBtn_get_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_get_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes5B178( ) ;
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

      protected void CONFIRM_5B0( )
      {
         BeforeValidate5B178( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5B178( ) ;
            }
            else
            {
               CheckExtendedTable5B178( ) ;
               if ( AnyError == 0 )
               {
                  ZM5B178( 6) ;
                  ZM5B178( 7) ;
                  ZM5B178( 8) ;
                  ZM5B178( 9) ;
                  ZM5B178( 10) ;
                  ZM5B178( 11) ;
                  ZM5B178( 12) ;
                  ZM5B178( 13) ;
                  ZM5B178( 14) ;
               }
               CloseExtendedTableCursors5B178( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues5B0( ) ;
         }
      }

      protected void ResetCaption5B0( )
      {
      }

      protected void ZM5B178( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1295MVLCajFec = T005B3_A1295MVLCajFec[0];
               Z1293MVLCajDoc = T005B3_A1293MVLCajDoc[0];
               Z1292MVLCajConc = T005B3_A1292MVLCajConc[0];
               Z1311MVLCueCodAux = T005B3_A1311MVLCueCodAux[0];
               Z1310MVLCueAuxCod = T005B3_A1310MVLCueAuxCod[0];
               Z1296MVLCajImp = T005B3_A1296MVLCajImp[0];
               Z1361MVLTipo = T005B3_A1361MVLTipo[0];
               Z1299MVLCajTCod = T005B3_A1299MVLCajTCod[0];
               Z1294MVLCajDocP = T005B3_A1294MVLCajDocP[0];
               Z1297MVLCajReg = T005B3_A1297MVLCajReg[0];
               Z1298MVLCajTCmb = T005B3_A1298MVLCajTCmb[0];
               Z1302MVLComFec = T005B3_A1302MVLComFec[0];
               Z1303MVLComFReg = T005B3_A1303MVLComFReg[0];
               Z1358MVLSubAfecto = T005B3_A1358MVLSubAfecto[0];
               Z1359MVLSubInafecto = T005B3_A1359MVLSubInafecto[0];
               Z1354MVLIGV = T005B3_A1354MVLIGV[0];
               Z1362MVLTotal = T005B3_A1362MVLTotal[0];
               Z1363MVLTotalPago = T005B3_A1363MVLTotalPago[0];
               Z1366MVLVouAno = T005B3_A1366MVLVouAno[0];
               Z1367MVLVouMes = T005B3_A1367MVLVouMes[0];
               Z1360MVLTASICod = T005B3_A1360MVLTASICod[0];
               Z1368MVLVouNum = T005B3_A1368MVLVouNum[0];
               Z1300MVLComAux = T005B3_A1300MVLComAux[0];
               Z1301MVLComCueCod = T005B3_A1301MVLComCueCod[0];
               Z1355MVLPagReg = T005B3_A1355MVLPagReg[0];
               Z1357MVLRedondeo = T005B3_A1357MVLRedondeo[0];
               Z1304MVLComPorIVA = T005B3_A1304MVLComPorIVA[0];
               Z1364MVLUsuCod = T005B3_A1364MVLUsuCod[0];
               Z1365MVLUsuFec = T005B3_A1365MVLUsuFec[0];
               Z1305MVLComTipReg = T005B3_A1305MVLComTipReg[0];
               Z399MVLConcCajCod = T005B3_A399MVLConcCajCod[0];
               Z397MVLCosCod = T005B3_A397MVLCosCod[0];
               Z398MVLComCosCod = T005B3_A398MVLComCosCod[0];
               Z396MVLPrvCod = T005B3_A396MVLPrvCod[0];
               Z395MVLCueCod = T005B3_A395MVLCueCod[0];
               Z394MVLMonCod = T005B3_A394MVLMonCod[0];
               Z393MVLForCod = T005B3_A393MVLForCod[0];
            }
            else
            {
               Z1295MVLCajFec = A1295MVLCajFec;
               Z1293MVLCajDoc = A1293MVLCajDoc;
               Z1292MVLCajConc = A1292MVLCajConc;
               Z1311MVLCueCodAux = A1311MVLCueCodAux;
               Z1310MVLCueAuxCod = A1310MVLCueAuxCod;
               Z1296MVLCajImp = A1296MVLCajImp;
               Z1361MVLTipo = A1361MVLTipo;
               Z1299MVLCajTCod = A1299MVLCajTCod;
               Z1294MVLCajDocP = A1294MVLCajDocP;
               Z1297MVLCajReg = A1297MVLCajReg;
               Z1298MVLCajTCmb = A1298MVLCajTCmb;
               Z1302MVLComFec = A1302MVLComFec;
               Z1303MVLComFReg = A1303MVLComFReg;
               Z1358MVLSubAfecto = A1358MVLSubAfecto;
               Z1359MVLSubInafecto = A1359MVLSubInafecto;
               Z1354MVLIGV = A1354MVLIGV;
               Z1362MVLTotal = A1362MVLTotal;
               Z1363MVLTotalPago = A1363MVLTotalPago;
               Z1366MVLVouAno = A1366MVLVouAno;
               Z1367MVLVouMes = A1367MVLVouMes;
               Z1360MVLTASICod = A1360MVLTASICod;
               Z1368MVLVouNum = A1368MVLVouNum;
               Z1300MVLComAux = A1300MVLComAux;
               Z1301MVLComCueCod = A1301MVLComCueCod;
               Z1355MVLPagReg = A1355MVLPagReg;
               Z1357MVLRedondeo = A1357MVLRedondeo;
               Z1304MVLComPorIVA = A1304MVLComPorIVA;
               Z1364MVLUsuCod = A1364MVLUsuCod;
               Z1365MVLUsuFec = A1365MVLUsuFec;
               Z1305MVLComTipReg = A1305MVLComTipReg;
               Z399MVLConcCajCod = A399MVLConcCajCod;
               Z397MVLCosCod = A397MVLCosCod;
               Z398MVLComCosCod = A398MVLComCosCod;
               Z396MVLPrvCod = A396MVLPrvCod;
               Z395MVLCueCod = A395MVLCueCod;
               Z394MVLMonCod = A394MVLMonCod;
               Z393MVLForCod = A393MVLForCod;
            }
         }
         if ( GX_JID == -5 )
         {
            Z391MVLCajCod = A391MVLCajCod;
            Z392MVLITem = A392MVLITem;
            Z1295MVLCajFec = A1295MVLCajFec;
            Z1293MVLCajDoc = A1293MVLCajDoc;
            Z1292MVLCajConc = A1292MVLCajConc;
            Z1311MVLCueCodAux = A1311MVLCueCodAux;
            Z1310MVLCueAuxCod = A1310MVLCueAuxCod;
            Z1296MVLCajImp = A1296MVLCajImp;
            Z1361MVLTipo = A1361MVLTipo;
            Z1299MVLCajTCod = A1299MVLCajTCod;
            Z1294MVLCajDocP = A1294MVLCajDocP;
            Z1297MVLCajReg = A1297MVLCajReg;
            Z1298MVLCajTCmb = A1298MVLCajTCmb;
            Z1302MVLComFec = A1302MVLComFec;
            Z1303MVLComFReg = A1303MVLComFReg;
            Z1358MVLSubAfecto = A1358MVLSubAfecto;
            Z1359MVLSubInafecto = A1359MVLSubInafecto;
            Z1354MVLIGV = A1354MVLIGV;
            Z1362MVLTotal = A1362MVLTotal;
            Z1363MVLTotalPago = A1363MVLTotalPago;
            Z1366MVLVouAno = A1366MVLVouAno;
            Z1367MVLVouMes = A1367MVLVouMes;
            Z1360MVLTASICod = A1360MVLTASICod;
            Z1368MVLVouNum = A1368MVLVouNum;
            Z1300MVLComAux = A1300MVLComAux;
            Z1301MVLComCueCod = A1301MVLComCueCod;
            Z1355MVLPagReg = A1355MVLPagReg;
            Z1357MVLRedondeo = A1357MVLRedondeo;
            Z1304MVLComPorIVA = A1304MVLComPorIVA;
            Z1364MVLUsuCod = A1364MVLUsuCod;
            Z1365MVLUsuFec = A1365MVLUsuFec;
            Z1305MVLComTipReg = A1305MVLComTipReg;
            Z358CajCod = A358CajCod;
            Z399MVLConcCajCod = A399MVLConcCajCod;
            Z397MVLCosCod = A397MVLCosCod;
            Z398MVLComCosCod = A398MVLComCosCod;
            Z396MVLPrvCod = A396MVLPrvCod;
            Z395MVLCueCod = A395MVLCueCod;
            Z394MVLMonCod = A394MVLMonCod;
            Z393MVLForCod = A393MVLForCod;
            Z1307MVLConCajDsc = A1307MVLConCajDsc;
            Z1306MVLConCajCue = A1306MVLConCajCue;
            Z1312MVLCueCos = A1312MVLCueCos;
            Z1356MVLPrvDsc = A1356MVLPrvDsc;
            Z1314MVLCueDsc = A1314MVLCueDsc;
            Z1313MVLCueCosCod = A1313MVLCueCosCod;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  )
         {
            bttBtn_get_Enabled = 0;
            AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_get_Enabled = 1;
            AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         }
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
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_check_Enabled = 0;
            AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_check_Enabled = 1;
            AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         }
      }

      protected void Load5B178( )
      {
         /* Using cursor T005B13 */
         pr_default.execute(11, new Object[] {A358CajCod, A391MVLCajCod, A392MVLITem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound178 = 1;
            A1295MVLCajFec = T005B13_A1295MVLCajFec[0];
            AssignAttri("", false, "A1295MVLCajFec", context.localUtil.Format(A1295MVLCajFec, "99/99/99"));
            A1293MVLCajDoc = T005B13_A1293MVLCajDoc[0];
            AssignAttri("", false, "A1293MVLCajDoc", A1293MVLCajDoc);
            A1292MVLCajConc = T005B13_A1292MVLCajConc[0];
            AssignAttri("", false, "A1292MVLCajConc", A1292MVLCajConc);
            A1311MVLCueCodAux = T005B13_A1311MVLCueCodAux[0];
            AssignAttri("", false, "A1311MVLCueCodAux", A1311MVLCueCodAux);
            A1310MVLCueAuxCod = T005B13_A1310MVLCueAuxCod[0];
            AssignAttri("", false, "A1310MVLCueAuxCod", A1310MVLCueAuxCod);
            A1296MVLCajImp = T005B13_A1296MVLCajImp[0];
            AssignAttri("", false, "A1296MVLCajImp", StringUtil.LTrimStr( A1296MVLCajImp, 15, 2));
            A1361MVLTipo = T005B13_A1361MVLTipo[0];
            AssignAttri("", false, "A1361MVLTipo", A1361MVLTipo);
            A1299MVLCajTCod = T005B13_A1299MVLCajTCod[0];
            AssignAttri("", false, "A1299MVLCajTCod", A1299MVLCajTCod);
            A1294MVLCajDocP = T005B13_A1294MVLCajDocP[0];
            AssignAttri("", false, "A1294MVLCajDocP", A1294MVLCajDocP);
            A1297MVLCajReg = T005B13_A1297MVLCajReg[0];
            AssignAttri("", false, "A1297MVLCajReg", A1297MVLCajReg);
            A1298MVLCajTCmb = T005B13_A1298MVLCajTCmb[0];
            AssignAttri("", false, "A1298MVLCajTCmb", StringUtil.LTrimStr( A1298MVLCajTCmb, 10, 4));
            A1302MVLComFec = T005B13_A1302MVLComFec[0];
            AssignAttri("", false, "A1302MVLComFec", context.localUtil.Format(A1302MVLComFec, "99/99/99"));
            A1303MVLComFReg = T005B13_A1303MVLComFReg[0];
            AssignAttri("", false, "A1303MVLComFReg", context.localUtil.Format(A1303MVLComFReg, "99/99/99"));
            A1358MVLSubAfecto = T005B13_A1358MVLSubAfecto[0];
            AssignAttri("", false, "A1358MVLSubAfecto", StringUtil.LTrimStr( A1358MVLSubAfecto, 15, 2));
            A1359MVLSubInafecto = T005B13_A1359MVLSubInafecto[0];
            AssignAttri("", false, "A1359MVLSubInafecto", StringUtil.LTrimStr( A1359MVLSubInafecto, 15, 2));
            A1354MVLIGV = T005B13_A1354MVLIGV[0];
            AssignAttri("", false, "A1354MVLIGV", StringUtil.LTrimStr( A1354MVLIGV, 15, 2));
            A1362MVLTotal = T005B13_A1362MVLTotal[0];
            AssignAttri("", false, "A1362MVLTotal", StringUtil.LTrimStr( A1362MVLTotal, 15, 2));
            A1363MVLTotalPago = T005B13_A1363MVLTotalPago[0];
            AssignAttri("", false, "A1363MVLTotalPago", StringUtil.LTrimStr( A1363MVLTotalPago, 15, 2));
            A1366MVLVouAno = T005B13_A1366MVLVouAno[0];
            AssignAttri("", false, "A1366MVLVouAno", StringUtil.LTrimStr( (decimal)(A1366MVLVouAno), 4, 0));
            A1367MVLVouMes = T005B13_A1367MVLVouMes[0];
            AssignAttri("", false, "A1367MVLVouMes", StringUtil.LTrimStr( (decimal)(A1367MVLVouMes), 2, 0));
            A1360MVLTASICod = T005B13_A1360MVLTASICod[0];
            AssignAttri("", false, "A1360MVLTASICod", StringUtil.LTrimStr( (decimal)(A1360MVLTASICod), 6, 0));
            A1368MVLVouNum = T005B13_A1368MVLVouNum[0];
            AssignAttri("", false, "A1368MVLVouNum", A1368MVLVouNum);
            A1300MVLComAux = T005B13_A1300MVLComAux[0];
            AssignAttri("", false, "A1300MVLComAux", A1300MVLComAux);
            A1301MVLComCueCod = T005B13_A1301MVLComCueCod[0];
            AssignAttri("", false, "A1301MVLComCueCod", A1301MVLComCueCod);
            A1355MVLPagReg = T005B13_A1355MVLPagReg[0];
            AssignAttri("", false, "A1355MVLPagReg", StringUtil.LTrimStr( (decimal)(A1355MVLPagReg), 10, 0));
            A1357MVLRedondeo = T005B13_A1357MVLRedondeo[0];
            AssignAttri("", false, "A1357MVLRedondeo", StringUtil.LTrimStr( A1357MVLRedondeo, 15, 2));
            A1304MVLComPorIVA = T005B13_A1304MVLComPorIVA[0];
            AssignAttri("", false, "A1304MVLComPorIVA", StringUtil.LTrimStr( A1304MVLComPorIVA, 15, 2));
            A1364MVLUsuCod = T005B13_A1364MVLUsuCod[0];
            AssignAttri("", false, "A1364MVLUsuCod", A1364MVLUsuCod);
            A1365MVLUsuFec = T005B13_A1365MVLUsuFec[0];
            AssignAttri("", false, "A1365MVLUsuFec", context.localUtil.TToC( A1365MVLUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1305MVLComTipReg = T005B13_A1305MVLComTipReg[0];
            AssignAttri("", false, "A1305MVLComTipReg", A1305MVLComTipReg);
            A1307MVLConCajDsc = T005B13_A1307MVLConCajDsc[0];
            AssignAttri("", false, "A1307MVLConCajDsc", A1307MVLConCajDsc);
            A1312MVLCueCos = T005B13_A1312MVLCueCos[0];
            AssignAttri("", false, "A1312MVLCueCos", StringUtil.Str( (decimal)(A1312MVLCueCos), 1, 0));
            A1356MVLPrvDsc = T005B13_A1356MVLPrvDsc[0];
            AssignAttri("", false, "A1356MVLPrvDsc", A1356MVLPrvDsc);
            A1314MVLCueDsc = T005B13_A1314MVLCueDsc[0];
            AssignAttri("", false, "A1314MVLCueDsc", A1314MVLCueDsc);
            A1313MVLCueCosCod = T005B13_A1313MVLCueCosCod[0];
            AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.Str( (decimal)(A1313MVLCueCosCod), 1, 0));
            A399MVLConcCajCod = T005B13_A399MVLConcCajCod[0];
            AssignAttri("", false, "A399MVLConcCajCod", StringUtil.LTrimStr( (decimal)(A399MVLConcCajCod), 6, 0));
            A397MVLCosCod = T005B13_A397MVLCosCod[0];
            n397MVLCosCod = T005B13_n397MVLCosCod[0];
            AssignAttri("", false, "A397MVLCosCod", A397MVLCosCod);
            A398MVLComCosCod = T005B13_A398MVLComCosCod[0];
            n398MVLComCosCod = T005B13_n398MVLComCosCod[0];
            AssignAttri("", false, "A398MVLComCosCod", A398MVLComCosCod);
            A396MVLPrvCod = T005B13_A396MVLPrvCod[0];
            AssignAttri("", false, "A396MVLPrvCod", A396MVLPrvCod);
            A395MVLCueCod = T005B13_A395MVLCueCod[0];
            AssignAttri("", false, "A395MVLCueCod", A395MVLCueCod);
            A394MVLMonCod = T005B13_A394MVLMonCod[0];
            AssignAttri("", false, "A394MVLMonCod", StringUtil.LTrimStr( (decimal)(A394MVLMonCod), 6, 0));
            A393MVLForCod = T005B13_A393MVLForCod[0];
            n393MVLForCod = T005B13_n393MVLForCod[0];
            AssignAttri("", false, "A393MVLForCod", StringUtil.LTrimStr( (decimal)(A393MVLForCod), 6, 0));
            A1306MVLConCajCue = T005B13_A1306MVLConCajCue[0];
            AssignAttri("", false, "A1306MVLConCajCue", A1306MVLConCajCue);
            ZM5B178( -5) ;
         }
         pr_default.close(11);
         OnLoadActions5B178( ) ;
      }

      protected void OnLoadActions5B178( )
      {
      }

      protected void CheckExtendedTable5B178( )
      {
         nIsDirty_178 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T005B4 */
         pr_default.execute(2, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1295MVLCajFec) || ( DateTimeUtil.ResetTime ( A1295MVLCajFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "MVLCAJFEC");
            AnyError = 1;
            GX_FocusControl = edtMVLCajFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005B5 */
         pr_default.execute(3, new Object[] {A399MVLConcCajCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Caja'.", "ForeignKeyNotFound", 1, "MVLCONCCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLConcCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1307MVLConCajDsc = T005B5_A1307MVLConCajDsc[0];
         AssignAttri("", false, "A1307MVLConCajDsc", A1307MVLConCajDsc);
         A1306MVLConCajCue = T005B5_A1306MVLConCajCue[0];
         AssignAttri("", false, "A1306MVLConCajCue", A1306MVLConCajCue);
         pr_default.close(3);
         /* Using cursor T005B12 */
         pr_default.execute(10, new Object[] {A1306MVLConCajCue});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Caja'.", "ForeignKeyNotFound", 1, "MVLCONCAJCUE");
            AnyError = 1;
         }
         A1312MVLCueCos = T005B12_A1312MVLCueCos[0];
         AssignAttri("", false, "A1312MVLCueCos", StringUtil.Str( (decimal)(A1312MVLCueCos), 1, 0));
         pr_default.close(10);
         /* Using cursor T005B6 */
         pr_default.execute(4, new Object[] {n397MVLCosCod, A397MVLCosCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A397MVLCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "MVLCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T005B8 */
         pr_default.execute(6, new Object[] {A396MVLPrvCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "MVLPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1356MVLPrvDsc = T005B8_A1356MVLPrvDsc[0];
         AssignAttri("", false, "A1356MVLPrvDsc", A1356MVLPrvDsc);
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A1302MVLComFec) || ( DateTimeUtil.ResetTime ( A1302MVLComFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "MVLCOMFEC");
            AnyError = 1;
            GX_FocusControl = edtMVLComFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1303MVLComFReg) || ( DateTimeUtil.ResetTime ( A1303MVLComFReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Registro fuera de rango", "OutOfRange", 1, "MVLCOMFREG");
            AnyError = 1;
            GX_FocusControl = edtMVLComFReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005B9 */
         pr_default.execute(7, new Object[] {A395MVLCueCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "MVLCUECOD");
            AnyError = 1;
            GX_FocusControl = edtMVLCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1314MVLCueDsc = T005B9_A1314MVLCueDsc[0];
         AssignAttri("", false, "A1314MVLCueDsc", A1314MVLCueDsc);
         A1313MVLCueCosCod = T005B9_A1313MVLCueCosCod[0];
         AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.Str( (decimal)(A1313MVLCueCosCod), 1, 0));
         pr_default.close(7);
         /* Using cursor T005B10 */
         pr_default.execute(8, new Object[] {A394MVLMonCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "MVLMONCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(8);
         /* Using cursor T005B7 */
         pr_default.execute(5, new Object[] {n398MVLComCosCod, A398MVLComCosCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A398MVLComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "MVLCOMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLComCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T005B11 */
         pr_default.execute(9, new Object[] {n393MVLForCod, A393MVLForCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A393MVLForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma Pago'.", "ForeignKeyNotFound", 1, "MVLFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(9);
         if ( ! ( (DateTime.MinValue==A1365MVLUsuFec) || ( A1365MVLUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "MVLUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtMVLUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5B178( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(10);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(5);
         pr_default.close(9);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( int A358CajCod )
      {
         /* Using cursor T005B14 */
         pr_default.execute(12, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
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

      protected void gxLoad_7( int A399MVLConcCajCod )
      {
         /* Using cursor T005B15 */
         pr_default.execute(13, new Object[] {A399MVLConcCajCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Caja'.", "ForeignKeyNotFound", 1, "MVLCONCCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLConcCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1307MVLConCajDsc = T005B15_A1307MVLConCajDsc[0];
         AssignAttri("", false, "A1307MVLConCajDsc", A1307MVLConCajDsc);
         A1306MVLConCajCue = T005B15_A1306MVLConCajCue[0];
         AssignAttri("", false, "A1306MVLConCajCue", A1306MVLConCajCue);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1307MVLConCajDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1306MVLConCajCue))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_14( string A1306MVLConCajCue )
      {
         /* Using cursor T005B16 */
         pr_default.execute(14, new Object[] {A1306MVLConCajCue});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Caja'.", "ForeignKeyNotFound", 1, "MVLCONCAJCUE");
            AnyError = 1;
         }
         A1312MVLCueCos = T005B16_A1312MVLCueCos[0];
         AssignAttri("", false, "A1312MVLCueCos", StringUtil.Str( (decimal)(A1312MVLCueCos), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1312MVLCueCos), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_8( string A397MVLCosCod )
      {
         /* Using cursor T005B17 */
         pr_default.execute(15, new Object[] {n397MVLCosCod, A397MVLCosCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A397MVLCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "MVLCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void gxLoad_10( string A396MVLPrvCod )
      {
         /* Using cursor T005B18 */
         pr_default.execute(16, new Object[] {A396MVLPrvCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "MVLPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1356MVLPrvDsc = T005B18_A1356MVLPrvDsc[0];
         AssignAttri("", false, "A1356MVLPrvDsc", A1356MVLPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1356MVLPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_11( string A395MVLCueCod )
      {
         /* Using cursor T005B19 */
         pr_default.execute(17, new Object[] {A395MVLCueCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "MVLCUECOD");
            AnyError = 1;
            GX_FocusControl = edtMVLCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1314MVLCueDsc = T005B19_A1314MVLCueDsc[0];
         AssignAttri("", false, "A1314MVLCueDsc", A1314MVLCueDsc);
         A1313MVLCueCosCod = T005B19_A1313MVLCueCosCod[0];
         AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.Str( (decimal)(A1313MVLCueCosCod), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1314MVLCueDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1313MVLCueCosCod), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_12( int A394MVLMonCod )
      {
         /* Using cursor T005B20 */
         pr_default.execute(18, new Object[] {A394MVLMonCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "MVLMONCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_9( string A398MVLComCosCod )
      {
         /* Using cursor T005B21 */
         pr_default.execute(19, new Object[] {n398MVLComCosCod, A398MVLComCosCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A398MVLComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "MVLCOMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLComCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_13( int A393MVLForCod )
      {
         /* Using cursor T005B22 */
         pr_default.execute(20, new Object[] {n393MVLForCod, A393MVLForCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A393MVLForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma Pago'.", "ForeignKeyNotFound", 1, "MVLFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void GetKey5B178( )
      {
         /* Using cursor T005B23 */
         pr_default.execute(21, new Object[] {A358CajCod, A391MVLCajCod, A392MVLITem});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound178 = 1;
         }
         else
         {
            RcdFound178 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005B3 */
         pr_default.execute(1, new Object[] {A358CajCod, A391MVLCajCod, A392MVLITem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5B178( 5) ;
            RcdFound178 = 1;
            A391MVLCajCod = T005B3_A391MVLCajCod[0];
            AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
            A392MVLITem = T005B3_A392MVLITem[0];
            AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
            A1295MVLCajFec = T005B3_A1295MVLCajFec[0];
            AssignAttri("", false, "A1295MVLCajFec", context.localUtil.Format(A1295MVLCajFec, "99/99/99"));
            A1293MVLCajDoc = T005B3_A1293MVLCajDoc[0];
            AssignAttri("", false, "A1293MVLCajDoc", A1293MVLCajDoc);
            A1292MVLCajConc = T005B3_A1292MVLCajConc[0];
            AssignAttri("", false, "A1292MVLCajConc", A1292MVLCajConc);
            A1311MVLCueCodAux = T005B3_A1311MVLCueCodAux[0];
            AssignAttri("", false, "A1311MVLCueCodAux", A1311MVLCueCodAux);
            A1310MVLCueAuxCod = T005B3_A1310MVLCueAuxCod[0];
            AssignAttri("", false, "A1310MVLCueAuxCod", A1310MVLCueAuxCod);
            A1296MVLCajImp = T005B3_A1296MVLCajImp[0];
            AssignAttri("", false, "A1296MVLCajImp", StringUtil.LTrimStr( A1296MVLCajImp, 15, 2));
            A1361MVLTipo = T005B3_A1361MVLTipo[0];
            AssignAttri("", false, "A1361MVLTipo", A1361MVLTipo);
            A1299MVLCajTCod = T005B3_A1299MVLCajTCod[0];
            AssignAttri("", false, "A1299MVLCajTCod", A1299MVLCajTCod);
            A1294MVLCajDocP = T005B3_A1294MVLCajDocP[0];
            AssignAttri("", false, "A1294MVLCajDocP", A1294MVLCajDocP);
            A1297MVLCajReg = T005B3_A1297MVLCajReg[0];
            AssignAttri("", false, "A1297MVLCajReg", A1297MVLCajReg);
            A1298MVLCajTCmb = T005B3_A1298MVLCajTCmb[0];
            AssignAttri("", false, "A1298MVLCajTCmb", StringUtil.LTrimStr( A1298MVLCajTCmb, 10, 4));
            A1302MVLComFec = T005B3_A1302MVLComFec[0];
            AssignAttri("", false, "A1302MVLComFec", context.localUtil.Format(A1302MVLComFec, "99/99/99"));
            A1303MVLComFReg = T005B3_A1303MVLComFReg[0];
            AssignAttri("", false, "A1303MVLComFReg", context.localUtil.Format(A1303MVLComFReg, "99/99/99"));
            A1358MVLSubAfecto = T005B3_A1358MVLSubAfecto[0];
            AssignAttri("", false, "A1358MVLSubAfecto", StringUtil.LTrimStr( A1358MVLSubAfecto, 15, 2));
            A1359MVLSubInafecto = T005B3_A1359MVLSubInafecto[0];
            AssignAttri("", false, "A1359MVLSubInafecto", StringUtil.LTrimStr( A1359MVLSubInafecto, 15, 2));
            A1354MVLIGV = T005B3_A1354MVLIGV[0];
            AssignAttri("", false, "A1354MVLIGV", StringUtil.LTrimStr( A1354MVLIGV, 15, 2));
            A1362MVLTotal = T005B3_A1362MVLTotal[0];
            AssignAttri("", false, "A1362MVLTotal", StringUtil.LTrimStr( A1362MVLTotal, 15, 2));
            A1363MVLTotalPago = T005B3_A1363MVLTotalPago[0];
            AssignAttri("", false, "A1363MVLTotalPago", StringUtil.LTrimStr( A1363MVLTotalPago, 15, 2));
            A1366MVLVouAno = T005B3_A1366MVLVouAno[0];
            AssignAttri("", false, "A1366MVLVouAno", StringUtil.LTrimStr( (decimal)(A1366MVLVouAno), 4, 0));
            A1367MVLVouMes = T005B3_A1367MVLVouMes[0];
            AssignAttri("", false, "A1367MVLVouMes", StringUtil.LTrimStr( (decimal)(A1367MVLVouMes), 2, 0));
            A1360MVLTASICod = T005B3_A1360MVLTASICod[0];
            AssignAttri("", false, "A1360MVLTASICod", StringUtil.LTrimStr( (decimal)(A1360MVLTASICod), 6, 0));
            A1368MVLVouNum = T005B3_A1368MVLVouNum[0];
            AssignAttri("", false, "A1368MVLVouNum", A1368MVLVouNum);
            A1300MVLComAux = T005B3_A1300MVLComAux[0];
            AssignAttri("", false, "A1300MVLComAux", A1300MVLComAux);
            A1301MVLComCueCod = T005B3_A1301MVLComCueCod[0];
            AssignAttri("", false, "A1301MVLComCueCod", A1301MVLComCueCod);
            A1355MVLPagReg = T005B3_A1355MVLPagReg[0];
            AssignAttri("", false, "A1355MVLPagReg", StringUtil.LTrimStr( (decimal)(A1355MVLPagReg), 10, 0));
            A1357MVLRedondeo = T005B3_A1357MVLRedondeo[0];
            AssignAttri("", false, "A1357MVLRedondeo", StringUtil.LTrimStr( A1357MVLRedondeo, 15, 2));
            A1304MVLComPorIVA = T005B3_A1304MVLComPorIVA[0];
            AssignAttri("", false, "A1304MVLComPorIVA", StringUtil.LTrimStr( A1304MVLComPorIVA, 15, 2));
            A1364MVLUsuCod = T005B3_A1364MVLUsuCod[0];
            AssignAttri("", false, "A1364MVLUsuCod", A1364MVLUsuCod);
            A1365MVLUsuFec = T005B3_A1365MVLUsuFec[0];
            AssignAttri("", false, "A1365MVLUsuFec", context.localUtil.TToC( A1365MVLUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1305MVLComTipReg = T005B3_A1305MVLComTipReg[0];
            AssignAttri("", false, "A1305MVLComTipReg", A1305MVLComTipReg);
            A358CajCod = T005B3_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A399MVLConcCajCod = T005B3_A399MVLConcCajCod[0];
            AssignAttri("", false, "A399MVLConcCajCod", StringUtil.LTrimStr( (decimal)(A399MVLConcCajCod), 6, 0));
            A397MVLCosCod = T005B3_A397MVLCosCod[0];
            n397MVLCosCod = T005B3_n397MVLCosCod[0];
            AssignAttri("", false, "A397MVLCosCod", A397MVLCosCod);
            A398MVLComCosCod = T005B3_A398MVLComCosCod[0];
            n398MVLComCosCod = T005B3_n398MVLComCosCod[0];
            AssignAttri("", false, "A398MVLComCosCod", A398MVLComCosCod);
            A396MVLPrvCod = T005B3_A396MVLPrvCod[0];
            AssignAttri("", false, "A396MVLPrvCod", A396MVLPrvCod);
            A395MVLCueCod = T005B3_A395MVLCueCod[0];
            AssignAttri("", false, "A395MVLCueCod", A395MVLCueCod);
            A394MVLMonCod = T005B3_A394MVLMonCod[0];
            AssignAttri("", false, "A394MVLMonCod", StringUtil.LTrimStr( (decimal)(A394MVLMonCod), 6, 0));
            A393MVLForCod = T005B3_A393MVLForCod[0];
            n393MVLForCod = T005B3_n393MVLForCod[0];
            AssignAttri("", false, "A393MVLForCod", StringUtil.LTrimStr( (decimal)(A393MVLForCod), 6, 0));
            Z358CajCod = A358CajCod;
            Z391MVLCajCod = A391MVLCajCod;
            Z392MVLITem = A392MVLITem;
            sMode178 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load5B178( ) ;
            if ( AnyError == 1 )
            {
               RcdFound178 = 0;
               InitializeNonKey5B178( ) ;
            }
            Gx_mode = sMode178;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound178 = 0;
            InitializeNonKey5B178( ) ;
            sMode178 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode178;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5B178( ) ;
         if ( RcdFound178 == 0 )
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
         RcdFound178 = 0;
         /* Using cursor T005B24 */
         pr_default.execute(22, new Object[] {A358CajCod, A391MVLCajCod, A392MVLITem});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( T005B24_A358CajCod[0] < A358CajCod ) || ( T005B24_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T005B24_A391MVLCajCod[0], A391MVLCajCod) < 0 ) || ( StringUtil.StrCmp(T005B24_A391MVLCajCod[0], A391MVLCajCod) == 0 ) && ( T005B24_A358CajCod[0] == A358CajCod ) && ( T005B24_A392MVLITem[0] < A392MVLITem ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( T005B24_A358CajCod[0] > A358CajCod ) || ( T005B24_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T005B24_A391MVLCajCod[0], A391MVLCajCod) > 0 ) || ( StringUtil.StrCmp(T005B24_A391MVLCajCod[0], A391MVLCajCod) == 0 ) && ( T005B24_A358CajCod[0] == A358CajCod ) && ( T005B24_A392MVLITem[0] > A392MVLITem ) ) )
            {
               A358CajCod = T005B24_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A391MVLCajCod = T005B24_A391MVLCajCod[0];
               AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
               A392MVLITem = T005B24_A392MVLITem[0];
               AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
               RcdFound178 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound178 = 0;
         /* Using cursor T005B25 */
         pr_default.execute(23, new Object[] {A358CajCod, A391MVLCajCod, A392MVLITem});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( T005B25_A358CajCod[0] > A358CajCod ) || ( T005B25_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T005B25_A391MVLCajCod[0], A391MVLCajCod) > 0 ) || ( StringUtil.StrCmp(T005B25_A391MVLCajCod[0], A391MVLCajCod) == 0 ) && ( T005B25_A358CajCod[0] == A358CajCod ) && ( T005B25_A392MVLITem[0] > A392MVLITem ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( T005B25_A358CajCod[0] < A358CajCod ) || ( T005B25_A358CajCod[0] == A358CajCod ) && ( StringUtil.StrCmp(T005B25_A391MVLCajCod[0], A391MVLCajCod) < 0 ) || ( StringUtil.StrCmp(T005B25_A391MVLCajCod[0], A391MVLCajCod) == 0 ) && ( T005B25_A358CajCod[0] == A358CajCod ) && ( T005B25_A392MVLITem[0] < A392MVLITem ) ) )
            {
               A358CajCod = T005B25_A358CajCod[0];
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A391MVLCajCod = T005B25_A391MVLCajCod[0];
               AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
               A392MVLITem = T005B25_A392MVLITem[0];
               AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
               RcdFound178 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5B178( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5B178( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound178 == 1 )
            {
               if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A391MVLCajCod, Z391MVLCajCod) != 0 ) || ( A392MVLITem != Z392MVLITem ) )
               {
                  A358CajCod = Z358CajCod;
                  AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
                  A391MVLCajCod = Z391MVLCajCod;
                  AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
                  A392MVLITem = Z392MVLITem;
                  AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update5B178( ) ;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A391MVLCajCod, Z391MVLCajCod) != 0 ) || ( A392MVLITem != Z392MVLITem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5B178( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                     AnyError = 1;
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCajCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5B178( ) ;
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
         if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A391MVLCajCod, Z391MVLCajCod) != 0 ) || ( A392MVLITem != Z392MVLITem ) )
         {
            A358CajCod = Z358CajCod;
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A391MVLCajCod = Z391MVLCajCod;
            AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
            A392MVLITem = Z392MVLITem;
            AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCajCod_Internalname;
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

      protected void btn_Check( )
      {
         nKeyPressed = 3;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         GetKey5B178( ) ;
         if ( RcdFound178 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A391MVLCajCod, Z391MVLCajCod) != 0 ) || ( A392MVLITem != Z392MVLITem ) )
            {
               A358CajCod = Z358CajCod;
               AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
               A391MVLCajCod = Z391MVLCajCod;
               AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
               A392MVLITem = Z392MVLITem;
               AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CAJCOD");
               AnyError = 1;
               GX_FocusControl = edtCajCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               update_Check( ) ;
            }
         }
         else
         {
            if ( ( A358CajCod != Z358CajCod ) || ( StringUtil.StrCmp(A391MVLCajCod, Z391MVLCajCod) != 0 ) || ( A392MVLITem != Z392MVLITem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CAJCOD");
                  AnyError = 1;
                  GX_FocusControl = edtCajCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         pr_default.close(0);
         context.RollbackDataStores("tsmovcajachica",pr_default);
         GX_FocusControl = edtMVLCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_5B0( ) ;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound178 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMVLCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart5B178( ) ;
         if ( RcdFound178 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5B178( ) ;
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
         if ( RcdFound178 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLCajFec_Internalname;
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
         if ( RcdFound178 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLCajFec_Internalname;
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
         ScanStart5B178( ) ;
         if ( RcdFound178 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound178 != 0 )
            {
               ScanNext5B178( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLCajFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5B178( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency5B178( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005B2 */
            pr_default.execute(0, new Object[] {A358CajCod, A391MVLCajCod, A392MVLITem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVCAJACHICA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1295MVLCajFec ) != DateTimeUtil.ResetTime ( T005B2_A1295MVLCajFec[0] ) ) || ( StringUtil.StrCmp(Z1293MVLCajDoc, T005B2_A1293MVLCajDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z1292MVLCajConc, T005B2_A1292MVLCajConc[0]) != 0 ) || ( StringUtil.StrCmp(Z1311MVLCueCodAux, T005B2_A1311MVLCueCodAux[0]) != 0 ) || ( StringUtil.StrCmp(Z1310MVLCueAuxCod, T005B2_A1310MVLCueAuxCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1296MVLCajImp != T005B2_A1296MVLCajImp[0] ) || ( StringUtil.StrCmp(Z1361MVLTipo, T005B2_A1361MVLTipo[0]) != 0 ) || ( StringUtil.StrCmp(Z1299MVLCajTCod, T005B2_A1299MVLCajTCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1294MVLCajDocP, T005B2_A1294MVLCajDocP[0]) != 0 ) || ( StringUtil.StrCmp(Z1297MVLCajReg, T005B2_A1297MVLCajReg[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1298MVLCajTCmb != T005B2_A1298MVLCajTCmb[0] ) || ( DateTimeUtil.ResetTime ( Z1302MVLComFec ) != DateTimeUtil.ResetTime ( T005B2_A1302MVLComFec[0] ) ) || ( DateTimeUtil.ResetTime ( Z1303MVLComFReg ) != DateTimeUtil.ResetTime ( T005B2_A1303MVLComFReg[0] ) ) || ( Z1358MVLSubAfecto != T005B2_A1358MVLSubAfecto[0] ) || ( Z1359MVLSubInafecto != T005B2_A1359MVLSubInafecto[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1354MVLIGV != T005B2_A1354MVLIGV[0] ) || ( Z1362MVLTotal != T005B2_A1362MVLTotal[0] ) || ( Z1363MVLTotalPago != T005B2_A1363MVLTotalPago[0] ) || ( Z1366MVLVouAno != T005B2_A1366MVLVouAno[0] ) || ( Z1367MVLVouMes != T005B2_A1367MVLVouMes[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1360MVLTASICod != T005B2_A1360MVLTASICod[0] ) || ( StringUtil.StrCmp(Z1368MVLVouNum, T005B2_A1368MVLVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1300MVLComAux, T005B2_A1300MVLComAux[0]) != 0 ) || ( StringUtil.StrCmp(Z1301MVLComCueCod, T005B2_A1301MVLComCueCod[0]) != 0 ) || ( Z1355MVLPagReg != T005B2_A1355MVLPagReg[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1357MVLRedondeo != T005B2_A1357MVLRedondeo[0] ) || ( Z1304MVLComPorIVA != T005B2_A1304MVLComPorIVA[0] ) || ( StringUtil.StrCmp(Z1364MVLUsuCod, T005B2_A1364MVLUsuCod[0]) != 0 ) || ( Z1365MVLUsuFec != T005B2_A1365MVLUsuFec[0] ) || ( StringUtil.StrCmp(Z1305MVLComTipReg, T005B2_A1305MVLComTipReg[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z399MVLConcCajCod != T005B2_A399MVLConcCajCod[0] ) || ( StringUtil.StrCmp(Z397MVLCosCod, T005B2_A397MVLCosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z398MVLComCosCod, T005B2_A398MVLComCosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z396MVLPrvCod, T005B2_A396MVLPrvCod[0]) != 0 ) || ( StringUtil.StrCmp(Z395MVLCueCod, T005B2_A395MVLCueCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z394MVLMonCod != T005B2_A394MVLMonCod[0] ) || ( Z393MVLForCod != T005B2_A393MVLForCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1295MVLCajFec ) != DateTimeUtil.ResetTime ( T005B2_A1295MVLCajFec[0] ) )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajFec");
                  GXUtil.WriteLogRaw("Old: ",Z1295MVLCajFec);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1295MVLCajFec[0]);
               }
               if ( StringUtil.StrCmp(Z1293MVLCajDoc, T005B2_A1293MVLCajDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1293MVLCajDoc);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1293MVLCajDoc[0]);
               }
               if ( StringUtil.StrCmp(Z1292MVLCajConc, T005B2_A1292MVLCajConc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajConc");
                  GXUtil.WriteLogRaw("Old: ",Z1292MVLCajConc);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1292MVLCajConc[0]);
               }
               if ( StringUtil.StrCmp(Z1311MVLCueCodAux, T005B2_A1311MVLCueCodAux[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCueCodAux");
                  GXUtil.WriteLogRaw("Old: ",Z1311MVLCueCodAux);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1311MVLCueCodAux[0]);
               }
               if ( StringUtil.StrCmp(Z1310MVLCueAuxCod, T005B2_A1310MVLCueAuxCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCueAuxCod");
                  GXUtil.WriteLogRaw("Old: ",Z1310MVLCueAuxCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1310MVLCueAuxCod[0]);
               }
               if ( Z1296MVLCajImp != T005B2_A1296MVLCajImp[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajImp");
                  GXUtil.WriteLogRaw("Old: ",Z1296MVLCajImp);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1296MVLCajImp[0]);
               }
               if ( StringUtil.StrCmp(Z1361MVLTipo, T005B2_A1361MVLTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1361MVLTipo);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1361MVLTipo[0]);
               }
               if ( StringUtil.StrCmp(Z1299MVLCajTCod, T005B2_A1299MVLCajTCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajTCod");
                  GXUtil.WriteLogRaw("Old: ",Z1299MVLCajTCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1299MVLCajTCod[0]);
               }
               if ( StringUtil.StrCmp(Z1294MVLCajDocP, T005B2_A1294MVLCajDocP[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajDocP");
                  GXUtil.WriteLogRaw("Old: ",Z1294MVLCajDocP);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1294MVLCajDocP[0]);
               }
               if ( StringUtil.StrCmp(Z1297MVLCajReg, T005B2_A1297MVLCajReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajReg");
                  GXUtil.WriteLogRaw("Old: ",Z1297MVLCajReg);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1297MVLCajReg[0]);
               }
               if ( Z1298MVLCajTCmb != T005B2_A1298MVLCajTCmb[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCajTCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1298MVLCajTCmb);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1298MVLCajTCmb[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1302MVLComFec ) != DateTimeUtil.ResetTime ( T005B2_A1302MVLComFec[0] ) )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLComFec");
                  GXUtil.WriteLogRaw("Old: ",Z1302MVLComFec);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1302MVLComFec[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1303MVLComFReg ) != DateTimeUtil.ResetTime ( T005B2_A1303MVLComFReg[0] ) )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLComFReg");
                  GXUtil.WriteLogRaw("Old: ",Z1303MVLComFReg);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1303MVLComFReg[0]);
               }
               if ( Z1358MVLSubAfecto != T005B2_A1358MVLSubAfecto[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLSubAfecto");
                  GXUtil.WriteLogRaw("Old: ",Z1358MVLSubAfecto);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1358MVLSubAfecto[0]);
               }
               if ( Z1359MVLSubInafecto != T005B2_A1359MVLSubInafecto[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLSubInafecto");
                  GXUtil.WriteLogRaw("Old: ",Z1359MVLSubInafecto);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1359MVLSubInafecto[0]);
               }
               if ( Z1354MVLIGV != T005B2_A1354MVLIGV[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLIGV");
                  GXUtil.WriteLogRaw("Old: ",Z1354MVLIGV);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1354MVLIGV[0]);
               }
               if ( Z1362MVLTotal != T005B2_A1362MVLTotal[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLTotal");
                  GXUtil.WriteLogRaw("Old: ",Z1362MVLTotal);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1362MVLTotal[0]);
               }
               if ( Z1363MVLTotalPago != T005B2_A1363MVLTotalPago[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLTotalPago");
                  GXUtil.WriteLogRaw("Old: ",Z1363MVLTotalPago);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1363MVLTotalPago[0]);
               }
               if ( Z1366MVLVouAno != T005B2_A1366MVLVouAno[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1366MVLVouAno);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1366MVLVouAno[0]);
               }
               if ( Z1367MVLVouMes != T005B2_A1367MVLVouMes[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1367MVLVouMes);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1367MVLVouMes[0]);
               }
               if ( Z1360MVLTASICod != T005B2_A1360MVLTASICod[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z1360MVLTASICod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1360MVLTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z1368MVLVouNum, T005B2_A1368MVLVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1368MVLVouNum);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1368MVLVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1300MVLComAux, T005B2_A1300MVLComAux[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLComAux");
                  GXUtil.WriteLogRaw("Old: ",Z1300MVLComAux);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1300MVLComAux[0]);
               }
               if ( StringUtil.StrCmp(Z1301MVLComCueCod, T005B2_A1301MVLComCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLComCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z1301MVLComCueCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1301MVLComCueCod[0]);
               }
               if ( Z1355MVLPagReg != T005B2_A1355MVLPagReg[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLPagReg");
                  GXUtil.WriteLogRaw("Old: ",Z1355MVLPagReg);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1355MVLPagReg[0]);
               }
               if ( Z1357MVLRedondeo != T005B2_A1357MVLRedondeo[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLRedondeo");
                  GXUtil.WriteLogRaw("Old: ",Z1357MVLRedondeo);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1357MVLRedondeo[0]);
               }
               if ( Z1304MVLComPorIVA != T005B2_A1304MVLComPorIVA[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLComPorIVA");
                  GXUtil.WriteLogRaw("Old: ",Z1304MVLComPorIVA);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1304MVLComPorIVA[0]);
               }
               if ( StringUtil.StrCmp(Z1364MVLUsuCod, T005B2_A1364MVLUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1364MVLUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1364MVLUsuCod[0]);
               }
               if ( Z1365MVLUsuFec != T005B2_A1365MVLUsuFec[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1365MVLUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1365MVLUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z1305MVLComTipReg, T005B2_A1305MVLComTipReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLComTipReg");
                  GXUtil.WriteLogRaw("Old: ",Z1305MVLComTipReg);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A1305MVLComTipReg[0]);
               }
               if ( Z399MVLConcCajCod != T005B2_A399MVLConcCajCod[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLConcCajCod");
                  GXUtil.WriteLogRaw("Old: ",Z399MVLConcCajCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A399MVLConcCajCod[0]);
               }
               if ( StringUtil.StrCmp(Z397MVLCosCod, T005B2_A397MVLCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z397MVLCosCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A397MVLCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z398MVLComCosCod, T005B2_A398MVLComCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLComCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z398MVLComCosCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A398MVLComCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z396MVLPrvCod, T005B2_A396MVLPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z396MVLPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A396MVLPrvCod[0]);
               }
               if ( StringUtil.StrCmp(Z395MVLCueCod, T005B2_A395MVLCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z395MVLCueCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A395MVLCueCod[0]);
               }
               if ( Z394MVLMonCod != T005B2_A394MVLMonCod[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z394MVLMonCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A394MVLMonCod[0]);
               }
               if ( Z393MVLForCod != T005B2_A393MVLForCod[0] )
               {
                  GXUtil.WriteLog("tsmovcajachica:[seudo value changed for attri]"+"MVLForCod");
                  GXUtil.WriteLogRaw("Old: ",Z393MVLForCod);
                  GXUtil.WriteLogRaw("Current: ",T005B2_A393MVLForCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSMOVCAJACHICA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5B178( )
      {
         BeforeValidate5B178( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5B178( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5B178( 0) ;
            CheckOptimisticConcurrency5B178( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5B178( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5B178( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005B26 */
                     pr_default.execute(24, new Object[] {A391MVLCajCod, A392MVLITem, A1295MVLCajFec, A1293MVLCajDoc, A1292MVLCajConc, A1311MVLCueCodAux, A1310MVLCueAuxCod, A1296MVLCajImp, A1361MVLTipo, A1299MVLCajTCod, A1294MVLCajDocP, A1297MVLCajReg, A1298MVLCajTCmb, A1302MVLComFec, A1303MVLComFReg, A1358MVLSubAfecto, A1359MVLSubInafecto, A1354MVLIGV, A1362MVLTotal, A1363MVLTotalPago, A1366MVLVouAno, A1367MVLVouMes, A1360MVLTASICod, A1368MVLVouNum, A1300MVLComAux, A1301MVLComCueCod, A1355MVLPagReg, A1357MVLRedondeo, A1304MVLComPorIVA, A1364MVLUsuCod, A1365MVLUsuFec, A1305MVLComTipReg, A358CajCod, A399MVLConcCajCod, n397MVLCosCod, A397MVLCosCod, n398MVLComCosCod, A398MVLComCosCod, A396MVLPrvCod, A395MVLCueCod, A394MVLMonCod, n393MVLForCod, A393MVLForCod});
                     pr_default.close(24);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVCAJACHICA");
                     if ( (pr_default.getStatus(24) == 1) )
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
                           ResetCaption5B0( ) ;
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
               Load5B178( ) ;
            }
            EndLevel5B178( ) ;
         }
         CloseExtendedTableCursors5B178( ) ;
      }

      protected void Update5B178( )
      {
         BeforeValidate5B178( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5B178( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5B178( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5B178( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5B178( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005B27 */
                     pr_default.execute(25, new Object[] {A1295MVLCajFec, A1293MVLCajDoc, A1292MVLCajConc, A1311MVLCueCodAux, A1310MVLCueAuxCod, A1296MVLCajImp, A1361MVLTipo, A1299MVLCajTCod, A1294MVLCajDocP, A1297MVLCajReg, A1298MVLCajTCmb, A1302MVLComFec, A1303MVLComFReg, A1358MVLSubAfecto, A1359MVLSubInafecto, A1354MVLIGV, A1362MVLTotal, A1363MVLTotalPago, A1366MVLVouAno, A1367MVLVouMes, A1360MVLTASICod, A1368MVLVouNum, A1300MVLComAux, A1301MVLComCueCod, A1355MVLPagReg, A1357MVLRedondeo, A1304MVLComPorIVA, A1364MVLUsuCod, A1365MVLUsuFec, A1305MVLComTipReg, A399MVLConcCajCod, n397MVLCosCod, A397MVLCosCod, n398MVLComCosCod, A398MVLComCosCod, A396MVLPrvCod, A395MVLCueCod, A394MVLMonCod, n393MVLForCod, A393MVLForCod, A358CajCod, A391MVLCajCod, A392MVLITem});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVCAJACHICA");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVCAJACHICA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5B178( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption5B0( ) ;
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
            EndLevel5B178( ) ;
         }
         CloseExtendedTableCursors5B178( ) ;
      }

      protected void DeferredUpdate5B178( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate5B178( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5B178( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5B178( ) ;
            AfterConfirm5B178( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5B178( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005B28 */
                  pr_default.execute(26, new Object[] {A358CajCod, A391MVLCajCod, A392MVLITem});
                  pr_default.close(26);
                  dsDefault.SmartCacheProvider.SetUpdated("TSMOVCAJACHICA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound178 == 0 )
                        {
                           InitAll5B178( ) ;
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
                        ResetCaption5B0( ) ;
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
         sMode178 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5B178( ) ;
         Gx_mode = sMode178;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5B178( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005B29 */
            pr_default.execute(27, new Object[] {A399MVLConcCajCod});
            A1307MVLConCajDsc = T005B29_A1307MVLConCajDsc[0];
            AssignAttri("", false, "A1307MVLConCajDsc", A1307MVLConCajDsc);
            A1306MVLConCajCue = T005B29_A1306MVLConCajCue[0];
            AssignAttri("", false, "A1306MVLConCajCue", A1306MVLConCajCue);
            pr_default.close(27);
            /* Using cursor T005B30 */
            pr_default.execute(28, new Object[] {A1306MVLConCajCue});
            A1312MVLCueCos = T005B30_A1312MVLCueCos[0];
            AssignAttri("", false, "A1312MVLCueCos", StringUtil.Str( (decimal)(A1312MVLCueCos), 1, 0));
            pr_default.close(28);
            /* Using cursor T005B31 */
            pr_default.execute(29, new Object[] {A396MVLPrvCod});
            A1356MVLPrvDsc = T005B31_A1356MVLPrvDsc[0];
            AssignAttri("", false, "A1356MVLPrvDsc", A1356MVLPrvDsc);
            pr_default.close(29);
            /* Using cursor T005B32 */
            pr_default.execute(30, new Object[] {A395MVLCueCod});
            A1314MVLCueDsc = T005B32_A1314MVLCueDsc[0];
            AssignAttri("", false, "A1314MVLCueDsc", A1314MVLCueDsc);
            A1313MVLCueCosCod = T005B32_A1313MVLCueCosCod[0];
            AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.Str( (decimal)(A1313MVLCueCosCod), 1, 0));
            pr_default.close(30);
         }
      }

      protected void EndLevel5B178( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5B178( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(27);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(28);
            context.CommitDataStores("tsmovcajachica",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5B0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(27);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(28);
            context.RollbackDataStores("tsmovcajachica",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5B178( )
      {
         /* Using cursor T005B33 */
         pr_default.execute(31);
         RcdFound178 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound178 = 1;
            A358CajCod = T005B33_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A391MVLCajCod = T005B33_A391MVLCajCod[0];
            AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
            A392MVLITem = T005B33_A392MVLITem[0];
            AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5B178( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound178 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound178 = 1;
            A358CajCod = T005B33_A358CajCod[0];
            AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
            A391MVLCajCod = T005B33_A391MVLCajCod[0];
            AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
            A392MVLITem = T005B33_A392MVLITem[0];
            AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
         }
      }

      protected void ScanEnd5B178( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm5B178( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5B178( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5B178( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5B178( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5B178( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5B178( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5B178( )
      {
         edtCajCod_Enabled = 0;
         AssignProp("", false, edtCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCajCod_Enabled), 5, 0), true);
         edtMVLCajCod_Enabled = 0;
         AssignProp("", false, edtMVLCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajCod_Enabled), 5, 0), true);
         edtMVLITem_Enabled = 0;
         AssignProp("", false, edtMVLITem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLITem_Enabled), 5, 0), true);
         edtMVLCajFec_Enabled = 0;
         AssignProp("", false, edtMVLCajFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajFec_Enabled), 5, 0), true);
         edtMVLCajDoc_Enabled = 0;
         AssignProp("", false, edtMVLCajDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajDoc_Enabled), 5, 0), true);
         edtMVLCajConc_Enabled = 0;
         AssignProp("", false, edtMVLCajConc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajConc_Enabled), 5, 0), true);
         edtMVLConcCajCod_Enabled = 0;
         AssignProp("", false, edtMVLConcCajCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLConcCajCod_Enabled), 5, 0), true);
         edtMVLCueCodAux_Enabled = 0;
         AssignProp("", false, edtMVLCueCodAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCueCodAux_Enabled), 5, 0), true);
         edtMVLCueAuxCod_Enabled = 0;
         AssignProp("", false, edtMVLCueAuxCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCueAuxCod_Enabled), 5, 0), true);
         edtMVLCosCod_Enabled = 0;
         AssignProp("", false, edtMVLCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCosCod_Enabled), 5, 0), true);
         edtMVLCajImp_Enabled = 0;
         AssignProp("", false, edtMVLCajImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajImp_Enabled), 5, 0), true);
         edtMVLTipo_Enabled = 0;
         AssignProp("", false, edtMVLTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLTipo_Enabled), 5, 0), true);
         edtMVLPrvCod_Enabled = 0;
         AssignProp("", false, edtMVLPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLPrvCod_Enabled), 5, 0), true);
         edtMVLCajTCod_Enabled = 0;
         AssignProp("", false, edtMVLCajTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajTCod_Enabled), 5, 0), true);
         edtMVLCajDocP_Enabled = 0;
         AssignProp("", false, edtMVLCajDocP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajDocP_Enabled), 5, 0), true);
         edtMVLCajReg_Enabled = 0;
         AssignProp("", false, edtMVLCajReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajReg_Enabled), 5, 0), true);
         edtMVLCajTCmb_Enabled = 0;
         AssignProp("", false, edtMVLCajTCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCajTCmb_Enabled), 5, 0), true);
         edtMVLComFec_Enabled = 0;
         AssignProp("", false, edtMVLComFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLComFec_Enabled), 5, 0), true);
         edtMVLComFReg_Enabled = 0;
         AssignProp("", false, edtMVLComFReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLComFReg_Enabled), 5, 0), true);
         edtMVLCueCod_Enabled = 0;
         AssignProp("", false, edtMVLCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCueCod_Enabled), 5, 0), true);
         edtMVLSubAfecto_Enabled = 0;
         AssignProp("", false, edtMVLSubAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLSubAfecto_Enabled), 5, 0), true);
         edtMVLSubInafecto_Enabled = 0;
         AssignProp("", false, edtMVLSubInafecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLSubInafecto_Enabled), 5, 0), true);
         edtMVLIGV_Enabled = 0;
         AssignProp("", false, edtMVLIGV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLIGV_Enabled), 5, 0), true);
         edtMVLTotal_Enabled = 0;
         AssignProp("", false, edtMVLTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLTotal_Enabled), 5, 0), true);
         edtMVLTotalPago_Enabled = 0;
         AssignProp("", false, edtMVLTotalPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLTotalPago_Enabled), 5, 0), true);
         edtMVLVouAno_Enabled = 0;
         AssignProp("", false, edtMVLVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLVouAno_Enabled), 5, 0), true);
         edtMVLVouMes_Enabled = 0;
         AssignProp("", false, edtMVLVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLVouMes_Enabled), 5, 0), true);
         edtMVLTASICod_Enabled = 0;
         AssignProp("", false, edtMVLTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLTASICod_Enabled), 5, 0), true);
         edtMVLVouNum_Enabled = 0;
         AssignProp("", false, edtMVLVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLVouNum_Enabled), 5, 0), true);
         edtMVLMonCod_Enabled = 0;
         AssignProp("", false, edtMVLMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLMonCod_Enabled), 5, 0), true);
         edtMVLComCosCod_Enabled = 0;
         AssignProp("", false, edtMVLComCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLComCosCod_Enabled), 5, 0), true);
         edtMVLComAux_Enabled = 0;
         AssignProp("", false, edtMVLComAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLComAux_Enabled), 5, 0), true);
         edtMVLComCueCod_Enabled = 0;
         AssignProp("", false, edtMVLComCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLComCueCod_Enabled), 5, 0), true);
         edtMVLForCod_Enabled = 0;
         AssignProp("", false, edtMVLForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLForCod_Enabled), 5, 0), true);
         edtMVLPagReg_Enabled = 0;
         AssignProp("", false, edtMVLPagReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLPagReg_Enabled), 5, 0), true);
         edtMVLRedondeo_Enabled = 0;
         AssignProp("", false, edtMVLRedondeo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLRedondeo_Enabled), 5, 0), true);
         edtMVLComPorIVA_Enabled = 0;
         AssignProp("", false, edtMVLComPorIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLComPorIVA_Enabled), 5, 0), true);
         edtMVLUsuCod_Enabled = 0;
         AssignProp("", false, edtMVLUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLUsuCod_Enabled), 5, 0), true);
         edtMVLUsuFec_Enabled = 0;
         AssignProp("", false, edtMVLUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLUsuFec_Enabled), 5, 0), true);
         edtMVLComTipReg_Enabled = 0;
         AssignProp("", false, edtMVLComTipReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLComTipReg_Enabled), 5, 0), true);
         edtMVLConCajDsc_Enabled = 0;
         AssignProp("", false, edtMVLConCajDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLConCajDsc_Enabled), 5, 0), true);
         edtMVLConCajCue_Enabled = 0;
         AssignProp("", false, edtMVLConCajCue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLConCajCue_Enabled), 5, 0), true);
         edtMVLCueCos_Enabled = 0;
         AssignProp("", false, edtMVLCueCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCueCos_Enabled), 5, 0), true);
         edtMVLPrvDsc_Enabled = 0;
         AssignProp("", false, edtMVLPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLPrvDsc_Enabled), 5, 0), true);
         edtMVLCueDsc_Enabled = 0;
         AssignProp("", false, edtMVLCueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCueDsc_Enabled), 5, 0), true);
         edtMVLCueCosCod_Enabled = 0;
         AssignProp("", false, edtMVLCueCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLCueCosCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5B178( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5B0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
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
         context.AddJavascriptSource("gxcfg.js", "?202281810255819", false, true);
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
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsmovcajachica.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "Form", true);
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
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z391MVLCajCod", StringUtil.RTrim( Z391MVLCajCod));
         GxWebStd.gx_hidden_field( context, "Z392MVLITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z392MVLITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1295MVLCajFec", context.localUtil.DToC( Z1295MVLCajFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1293MVLCajDoc", StringUtil.RTrim( Z1293MVLCajDoc));
         GxWebStd.gx_hidden_field( context, "Z1292MVLCajConc", StringUtil.RTrim( Z1292MVLCajConc));
         GxWebStd.gx_hidden_field( context, "Z1311MVLCueCodAux", StringUtil.RTrim( Z1311MVLCueCodAux));
         GxWebStd.gx_hidden_field( context, "Z1310MVLCueAuxCod", StringUtil.RTrim( Z1310MVLCueAuxCod));
         GxWebStd.gx_hidden_field( context, "Z1296MVLCajImp", StringUtil.LTrim( StringUtil.NToC( Z1296MVLCajImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1361MVLTipo", StringUtil.RTrim( Z1361MVLTipo));
         GxWebStd.gx_hidden_field( context, "Z1299MVLCajTCod", StringUtil.RTrim( Z1299MVLCajTCod));
         GxWebStd.gx_hidden_field( context, "Z1294MVLCajDocP", StringUtil.RTrim( Z1294MVLCajDocP));
         GxWebStd.gx_hidden_field( context, "Z1297MVLCajReg", StringUtil.RTrim( Z1297MVLCajReg));
         GxWebStd.gx_hidden_field( context, "Z1298MVLCajTCmb", StringUtil.LTrim( StringUtil.NToC( Z1298MVLCajTCmb, 10, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1302MVLComFec", context.localUtil.DToC( Z1302MVLComFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1303MVLComFReg", context.localUtil.DToC( Z1303MVLComFReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1358MVLSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1358MVLSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1359MVLSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1359MVLSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1354MVLIGV", StringUtil.LTrim( StringUtil.NToC( Z1354MVLIGV, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1362MVLTotal", StringUtil.LTrim( StringUtil.NToC( Z1362MVLTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1363MVLTotalPago", StringUtil.LTrim( StringUtil.NToC( Z1363MVLTotalPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1366MVLVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1366MVLVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1367MVLVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1367MVLVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1360MVLTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1360MVLTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1368MVLVouNum", StringUtil.RTrim( Z1368MVLVouNum));
         GxWebStd.gx_hidden_field( context, "Z1300MVLComAux", StringUtil.RTrim( Z1300MVLComAux));
         GxWebStd.gx_hidden_field( context, "Z1301MVLComCueCod", StringUtil.RTrim( Z1301MVLComCueCod));
         GxWebStd.gx_hidden_field( context, "Z1355MVLPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1355MVLPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1357MVLRedondeo", StringUtil.LTrim( StringUtil.NToC( Z1357MVLRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1304MVLComPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1304MVLComPorIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1364MVLUsuCod", StringUtil.RTrim( Z1364MVLUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1365MVLUsuFec", context.localUtil.TToC( Z1365MVLUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1305MVLComTipReg", StringUtil.RTrim( Z1305MVLComTipReg));
         GxWebStd.gx_hidden_field( context, "Z399MVLConcCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z399MVLConcCajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z397MVLCosCod", StringUtil.RTrim( Z397MVLCosCod));
         GxWebStd.gx_hidden_field( context, "Z398MVLComCosCod", StringUtil.RTrim( Z398MVLComCosCod));
         GxWebStd.gx_hidden_field( context, "Z396MVLPrvCod", StringUtil.RTrim( Z396MVLPrvCod));
         GxWebStd.gx_hidden_field( context, "Z395MVLCueCod", StringUtil.RTrim( Z395MVLCueCod));
         GxWebStd.gx_hidden_field( context, "Z394MVLMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z394MVLMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z393MVLForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z393MVLForCod), 6, 0, ".", "")));
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
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "Form" : Form.Class)+"-fx");
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
         return formatLink("tsmovcajachica.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSMOVCAJACHICA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimientos de Caja Chica" ;
      }

      protected void InitializeNonKey5B178( )
      {
         A1295MVLCajFec = DateTime.MinValue;
         AssignAttri("", false, "A1295MVLCajFec", context.localUtil.Format(A1295MVLCajFec, "99/99/99"));
         A1293MVLCajDoc = "";
         AssignAttri("", false, "A1293MVLCajDoc", A1293MVLCajDoc);
         A1292MVLCajConc = "";
         AssignAttri("", false, "A1292MVLCajConc", A1292MVLCajConc);
         A399MVLConcCajCod = 0;
         AssignAttri("", false, "A399MVLConcCajCod", StringUtil.LTrimStr( (decimal)(A399MVLConcCajCod), 6, 0));
         A1311MVLCueCodAux = "";
         AssignAttri("", false, "A1311MVLCueCodAux", A1311MVLCueCodAux);
         A1310MVLCueAuxCod = "";
         AssignAttri("", false, "A1310MVLCueAuxCod", A1310MVLCueAuxCod);
         A397MVLCosCod = "";
         n397MVLCosCod = false;
         AssignAttri("", false, "A397MVLCosCod", A397MVLCosCod);
         A1296MVLCajImp = 0;
         AssignAttri("", false, "A1296MVLCajImp", StringUtil.LTrimStr( A1296MVLCajImp, 15, 2));
         A1361MVLTipo = "";
         AssignAttri("", false, "A1361MVLTipo", A1361MVLTipo);
         A396MVLPrvCod = "";
         AssignAttri("", false, "A396MVLPrvCod", A396MVLPrvCod);
         A1299MVLCajTCod = "";
         AssignAttri("", false, "A1299MVLCajTCod", A1299MVLCajTCod);
         A1294MVLCajDocP = "";
         AssignAttri("", false, "A1294MVLCajDocP", A1294MVLCajDocP);
         A1297MVLCajReg = "";
         AssignAttri("", false, "A1297MVLCajReg", A1297MVLCajReg);
         A1298MVLCajTCmb = 0;
         AssignAttri("", false, "A1298MVLCajTCmb", StringUtil.LTrimStr( A1298MVLCajTCmb, 10, 4));
         A1302MVLComFec = DateTime.MinValue;
         AssignAttri("", false, "A1302MVLComFec", context.localUtil.Format(A1302MVLComFec, "99/99/99"));
         A1303MVLComFReg = DateTime.MinValue;
         AssignAttri("", false, "A1303MVLComFReg", context.localUtil.Format(A1303MVLComFReg, "99/99/99"));
         A395MVLCueCod = "";
         AssignAttri("", false, "A395MVLCueCod", A395MVLCueCod);
         A1358MVLSubAfecto = 0;
         AssignAttri("", false, "A1358MVLSubAfecto", StringUtil.LTrimStr( A1358MVLSubAfecto, 15, 2));
         A1359MVLSubInafecto = 0;
         AssignAttri("", false, "A1359MVLSubInafecto", StringUtil.LTrimStr( A1359MVLSubInafecto, 15, 2));
         A1354MVLIGV = 0;
         AssignAttri("", false, "A1354MVLIGV", StringUtil.LTrimStr( A1354MVLIGV, 15, 2));
         A1362MVLTotal = 0;
         AssignAttri("", false, "A1362MVLTotal", StringUtil.LTrimStr( A1362MVLTotal, 15, 2));
         A1363MVLTotalPago = 0;
         AssignAttri("", false, "A1363MVLTotalPago", StringUtil.LTrimStr( A1363MVLTotalPago, 15, 2));
         A1366MVLVouAno = 0;
         AssignAttri("", false, "A1366MVLVouAno", StringUtil.LTrimStr( (decimal)(A1366MVLVouAno), 4, 0));
         A1367MVLVouMes = 0;
         AssignAttri("", false, "A1367MVLVouMes", StringUtil.LTrimStr( (decimal)(A1367MVLVouMes), 2, 0));
         A1360MVLTASICod = 0;
         AssignAttri("", false, "A1360MVLTASICod", StringUtil.LTrimStr( (decimal)(A1360MVLTASICod), 6, 0));
         A1368MVLVouNum = "";
         AssignAttri("", false, "A1368MVLVouNum", A1368MVLVouNum);
         A394MVLMonCod = 0;
         AssignAttri("", false, "A394MVLMonCod", StringUtil.LTrimStr( (decimal)(A394MVLMonCod), 6, 0));
         A398MVLComCosCod = "";
         n398MVLComCosCod = false;
         AssignAttri("", false, "A398MVLComCosCod", A398MVLComCosCod);
         A1300MVLComAux = "";
         AssignAttri("", false, "A1300MVLComAux", A1300MVLComAux);
         A1301MVLComCueCod = "";
         AssignAttri("", false, "A1301MVLComCueCod", A1301MVLComCueCod);
         A393MVLForCod = 0;
         n393MVLForCod = false;
         AssignAttri("", false, "A393MVLForCod", StringUtil.LTrimStr( (decimal)(A393MVLForCod), 6, 0));
         A1355MVLPagReg = 0;
         AssignAttri("", false, "A1355MVLPagReg", StringUtil.LTrimStr( (decimal)(A1355MVLPagReg), 10, 0));
         A1357MVLRedondeo = 0;
         AssignAttri("", false, "A1357MVLRedondeo", StringUtil.LTrimStr( A1357MVLRedondeo, 15, 2));
         A1304MVLComPorIVA = 0;
         AssignAttri("", false, "A1304MVLComPorIVA", StringUtil.LTrimStr( A1304MVLComPorIVA, 15, 2));
         A1364MVLUsuCod = "";
         AssignAttri("", false, "A1364MVLUsuCod", A1364MVLUsuCod);
         A1365MVLUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1365MVLUsuFec", context.localUtil.TToC( A1365MVLUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1305MVLComTipReg = "";
         AssignAttri("", false, "A1305MVLComTipReg", A1305MVLComTipReg);
         A1307MVLConCajDsc = "";
         AssignAttri("", false, "A1307MVLConCajDsc", A1307MVLConCajDsc);
         A1306MVLConCajCue = "";
         AssignAttri("", false, "A1306MVLConCajCue", A1306MVLConCajCue);
         A1312MVLCueCos = 0;
         AssignAttri("", false, "A1312MVLCueCos", StringUtil.Str( (decimal)(A1312MVLCueCos), 1, 0));
         A1356MVLPrvDsc = "";
         AssignAttri("", false, "A1356MVLPrvDsc", A1356MVLPrvDsc);
         A1314MVLCueDsc = "";
         AssignAttri("", false, "A1314MVLCueDsc", A1314MVLCueDsc);
         A1313MVLCueCosCod = 0;
         AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.Str( (decimal)(A1313MVLCueCosCod), 1, 0));
         Z1295MVLCajFec = DateTime.MinValue;
         Z1293MVLCajDoc = "";
         Z1292MVLCajConc = "";
         Z1311MVLCueCodAux = "";
         Z1310MVLCueAuxCod = "";
         Z1296MVLCajImp = 0;
         Z1361MVLTipo = "";
         Z1299MVLCajTCod = "";
         Z1294MVLCajDocP = "";
         Z1297MVLCajReg = "";
         Z1298MVLCajTCmb = 0;
         Z1302MVLComFec = DateTime.MinValue;
         Z1303MVLComFReg = DateTime.MinValue;
         Z1358MVLSubAfecto = 0;
         Z1359MVLSubInafecto = 0;
         Z1354MVLIGV = 0;
         Z1362MVLTotal = 0;
         Z1363MVLTotalPago = 0;
         Z1366MVLVouAno = 0;
         Z1367MVLVouMes = 0;
         Z1360MVLTASICod = 0;
         Z1368MVLVouNum = "";
         Z1300MVLComAux = "";
         Z1301MVLComCueCod = "";
         Z1355MVLPagReg = 0;
         Z1357MVLRedondeo = 0;
         Z1304MVLComPorIVA = 0;
         Z1364MVLUsuCod = "";
         Z1365MVLUsuFec = (DateTime)(DateTime.MinValue);
         Z1305MVLComTipReg = "";
         Z399MVLConcCajCod = 0;
         Z397MVLCosCod = "";
         Z398MVLComCosCod = "";
         Z396MVLPrvCod = "";
         Z395MVLCueCod = "";
         Z394MVLMonCod = 0;
         Z393MVLForCod = 0;
      }

      protected void InitAll5B178( )
      {
         A358CajCod = 0;
         AssignAttri("", false, "A358CajCod", StringUtil.LTrimStr( (decimal)(A358CajCod), 6, 0));
         A391MVLCajCod = "";
         AssignAttri("", false, "A391MVLCajCod", A391MVLCajCod);
         A392MVLITem = 0;
         AssignAttri("", false, "A392MVLITem", StringUtil.LTrimStr( (decimal)(A392MVLITem), 6, 0));
         InitializeNonKey5B178( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810255854", true, true);
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
         context.AddJavascriptSource("tsmovcajachica.js", "?202281810255855", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtCajCod_Internalname = "CAJCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMVLCajCod_Internalname = "MVLCAJCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtMVLITem_Internalname = "MVLITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtMVLCajFec_Internalname = "MVLCAJFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtMVLCajDoc_Internalname = "MVLCAJDOC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtMVLCajConc_Internalname = "MVLCAJCONC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtMVLConcCajCod_Internalname = "MVLCONCCAJCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtMVLCueCodAux_Internalname = "MVLCUECODAUX";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtMVLCueAuxCod_Internalname = "MVLCUEAUXCOD";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtMVLCosCod_Internalname = "MVLCOSCOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtMVLCajImp_Internalname = "MVLCAJIMP";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtMVLTipo_Internalname = "MVLTIPO";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtMVLPrvCod_Internalname = "MVLPRVCOD";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtMVLCajTCod_Internalname = "MVLCAJTCOD";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtMVLCajDocP_Internalname = "MVLCAJDOCP";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtMVLCajReg_Internalname = "MVLCAJREG";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtMVLCajTCmb_Internalname = "MVLCAJTCMB";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtMVLComFec_Internalname = "MVLCOMFEC";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtMVLComFReg_Internalname = "MVLCOMFREG";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtMVLCueCod_Internalname = "MVLCUECOD";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtMVLSubAfecto_Internalname = "MVLSUBAFECTO";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtMVLSubInafecto_Internalname = "MVLSUBINAFECTO";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtMVLIGV_Internalname = "MVLIGV";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtMVLTotal_Internalname = "MVLTOTAL";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtMVLTotalPago_Internalname = "MVLTOTALPAGO";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtMVLVouAno_Internalname = "MVLVOUANO";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtMVLVouMes_Internalname = "MVLVOUMES";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtMVLTASICod_Internalname = "MVLTASICOD";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtMVLVouNum_Internalname = "MVLVOUNUM";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtMVLMonCod_Internalname = "MVLMONCOD";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtMVLComCosCod_Internalname = "MVLCOMCOSCOD";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtMVLComAux_Internalname = "MVLCOMAUX";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtMVLComCueCod_Internalname = "MVLCOMCUECOD";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtMVLForCod_Internalname = "MVLFORCOD";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtMVLPagReg_Internalname = "MVLPAGREG";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtMVLRedondeo_Internalname = "MVLREDONDEO";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtMVLComPorIVA_Internalname = "MVLCOMPORIVA";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtMVLUsuCod_Internalname = "MVLUSUCOD";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtMVLUsuFec_Internalname = "MVLUSUFEC";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         edtMVLComTipReg_Internalname = "MVLCOMTIPREG";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         edtMVLConCajDsc_Internalname = "MVLCONCAJDSC";
         lblTextblock42_Internalname = "TEXTBLOCK42";
         edtMVLConCajCue_Internalname = "MVLCONCAJCUE";
         lblTextblock43_Internalname = "TEXTBLOCK43";
         edtMVLCueCos_Internalname = "MVLCUECOS";
         lblTextblock44_Internalname = "TEXTBLOCK44";
         edtMVLPrvDsc_Internalname = "MVLPRVDSC";
         lblTextblock45_Internalname = "TEXTBLOCK45";
         edtMVLCueDsc_Internalname = "MVLCUEDSC";
         lblTextblock46_Internalname = "TEXTBLOCK46";
         edtMVLCueCosCod_Internalname = "MVLCUECOSCOD";
         tblTable2_Internalname = "TABLE2";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_check_Internalname = "BTN_CHECK";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         bttBtn_help_Internalname = "BTN_HELP";
         tblTable1_Internalname = "TABLE1";
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
         Form.Caption = "Movimientos de Caja Chica";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMVLCueCosCod_Jsonclick = "";
         edtMVLCueCosCod_Enabled = 0;
         edtMVLCueDsc_Jsonclick = "";
         edtMVLCueDsc_Enabled = 0;
         edtMVLPrvDsc_Jsonclick = "";
         edtMVLPrvDsc_Enabled = 0;
         edtMVLCueCos_Jsonclick = "";
         edtMVLCueCos_Enabled = 0;
         edtMVLConCajCue_Jsonclick = "";
         edtMVLConCajCue_Enabled = 0;
         edtMVLConCajDsc_Jsonclick = "";
         edtMVLConCajDsc_Enabled = 0;
         edtMVLComTipReg_Jsonclick = "";
         edtMVLComTipReg_Enabled = 1;
         edtMVLUsuFec_Jsonclick = "";
         edtMVLUsuFec_Enabled = 1;
         edtMVLUsuCod_Jsonclick = "";
         edtMVLUsuCod_Enabled = 1;
         edtMVLComPorIVA_Jsonclick = "";
         edtMVLComPorIVA_Enabled = 1;
         edtMVLRedondeo_Jsonclick = "";
         edtMVLRedondeo_Enabled = 1;
         edtMVLPagReg_Jsonclick = "";
         edtMVLPagReg_Enabled = 1;
         edtMVLForCod_Jsonclick = "";
         edtMVLForCod_Enabled = 1;
         edtMVLComCueCod_Jsonclick = "";
         edtMVLComCueCod_Enabled = 1;
         edtMVLComAux_Jsonclick = "";
         edtMVLComAux_Enabled = 1;
         edtMVLComCosCod_Jsonclick = "";
         edtMVLComCosCod_Enabled = 1;
         edtMVLMonCod_Jsonclick = "";
         edtMVLMonCod_Enabled = 1;
         edtMVLVouNum_Jsonclick = "";
         edtMVLVouNum_Enabled = 1;
         edtMVLTASICod_Jsonclick = "";
         edtMVLTASICod_Enabled = 1;
         edtMVLVouMes_Jsonclick = "";
         edtMVLVouMes_Enabled = 1;
         edtMVLVouAno_Jsonclick = "";
         edtMVLVouAno_Enabled = 1;
         edtMVLTotalPago_Jsonclick = "";
         edtMVLTotalPago_Enabled = 1;
         edtMVLTotal_Jsonclick = "";
         edtMVLTotal_Enabled = 1;
         edtMVLIGV_Jsonclick = "";
         edtMVLIGV_Enabled = 1;
         edtMVLSubInafecto_Jsonclick = "";
         edtMVLSubInafecto_Enabled = 1;
         edtMVLSubAfecto_Jsonclick = "";
         edtMVLSubAfecto_Enabled = 1;
         edtMVLCueCod_Jsonclick = "";
         edtMVLCueCod_Enabled = 1;
         edtMVLComFReg_Jsonclick = "";
         edtMVLComFReg_Enabled = 1;
         edtMVLComFec_Jsonclick = "";
         edtMVLComFec_Enabled = 1;
         edtMVLCajTCmb_Jsonclick = "";
         edtMVLCajTCmb_Enabled = 1;
         edtMVLCajReg_Jsonclick = "";
         edtMVLCajReg_Enabled = 1;
         edtMVLCajDocP_Jsonclick = "";
         edtMVLCajDocP_Enabled = 1;
         edtMVLCajTCod_Jsonclick = "";
         edtMVLCajTCod_Enabled = 1;
         edtMVLPrvCod_Jsonclick = "";
         edtMVLPrvCod_Enabled = 1;
         edtMVLTipo_Jsonclick = "";
         edtMVLTipo_Enabled = 1;
         edtMVLCajImp_Jsonclick = "";
         edtMVLCajImp_Enabled = 1;
         edtMVLCosCod_Jsonclick = "";
         edtMVLCosCod_Enabled = 1;
         edtMVLCueAuxCod_Jsonclick = "";
         edtMVLCueAuxCod_Enabled = 1;
         edtMVLCueCodAux_Jsonclick = "";
         edtMVLCueCodAux_Enabled = 1;
         edtMVLConcCajCod_Jsonclick = "";
         edtMVLConcCajCod_Enabled = 1;
         edtMVLCajConc_Jsonclick = "";
         edtMVLCajConc_Enabled = 1;
         edtMVLCajDoc_Jsonclick = "";
         edtMVLCajDoc_Enabled = 1;
         edtMVLCajFec_Jsonclick = "";
         edtMVLCajFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMVLITem_Jsonclick = "";
         edtMVLITem_Enabled = 1;
         edtMVLCajCod_Jsonclick = "";
         edtMVLCajCod_Enabled = 1;
         edtCajCod_Jsonclick = "";
         edtCajCod_Enabled = 1;
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
         /* Using cursor T005B34 */
         pr_default.execute(32, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(32);
         GX_FocusControl = edtMVLCajFec_Internalname;
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

      public void Valid_Cajcod( )
      {
         /* Using cursor T005B34 */
         pr_default.execute(32, new Object[] {A358CajCod});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Caja Chica'.", "ForeignKeyNotFound", 1, "CAJCOD");
            AnyError = 1;
            GX_FocusControl = edtCajCod_Internalname;
         }
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvlitem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1295MVLCajFec", context.localUtil.Format(A1295MVLCajFec, "99/99/99"));
         AssignAttri("", false, "A1293MVLCajDoc", StringUtil.RTrim( A1293MVLCajDoc));
         AssignAttri("", false, "A1292MVLCajConc", StringUtil.RTrim( A1292MVLCajConc));
         AssignAttri("", false, "A399MVLConcCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A399MVLConcCajCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1311MVLCueCodAux", StringUtil.RTrim( A1311MVLCueCodAux));
         AssignAttri("", false, "A1310MVLCueAuxCod", StringUtil.RTrim( A1310MVLCueAuxCod));
         AssignAttri("", false, "A397MVLCosCod", StringUtil.RTrim( A397MVLCosCod));
         AssignAttri("", false, "A1296MVLCajImp", StringUtil.LTrim( StringUtil.NToC( A1296MVLCajImp, 15, 2, ".", "")));
         AssignAttri("", false, "A1361MVLTipo", StringUtil.RTrim( A1361MVLTipo));
         AssignAttri("", false, "A396MVLPrvCod", StringUtil.RTrim( A396MVLPrvCod));
         AssignAttri("", false, "A1299MVLCajTCod", StringUtil.RTrim( A1299MVLCajTCod));
         AssignAttri("", false, "A1294MVLCajDocP", StringUtil.RTrim( A1294MVLCajDocP));
         AssignAttri("", false, "A1297MVLCajReg", StringUtil.RTrim( A1297MVLCajReg));
         AssignAttri("", false, "A1298MVLCajTCmb", StringUtil.LTrim( StringUtil.NToC( A1298MVLCajTCmb, 10, 4, ".", "")));
         AssignAttri("", false, "A1302MVLComFec", context.localUtil.Format(A1302MVLComFec, "99/99/99"));
         AssignAttri("", false, "A1303MVLComFReg", context.localUtil.Format(A1303MVLComFReg, "99/99/99"));
         AssignAttri("", false, "A395MVLCueCod", StringUtil.RTrim( A395MVLCueCod));
         AssignAttri("", false, "A1358MVLSubAfecto", StringUtil.LTrim( StringUtil.NToC( A1358MVLSubAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1359MVLSubInafecto", StringUtil.LTrim( StringUtil.NToC( A1359MVLSubInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1354MVLIGV", StringUtil.LTrim( StringUtil.NToC( A1354MVLIGV, 15, 2, ".", "")));
         AssignAttri("", false, "A1362MVLTotal", StringUtil.LTrim( StringUtil.NToC( A1362MVLTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A1363MVLTotalPago", StringUtil.LTrim( StringUtil.NToC( A1363MVLTotalPago, 15, 2, ".", "")));
         AssignAttri("", false, "A1366MVLVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1366MVLVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1367MVLVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1367MVLVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1360MVLTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1360MVLTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A1368MVLVouNum", StringUtil.RTrim( A1368MVLVouNum));
         AssignAttri("", false, "A394MVLMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A394MVLMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A398MVLComCosCod", StringUtil.RTrim( A398MVLComCosCod));
         AssignAttri("", false, "A1300MVLComAux", StringUtil.RTrim( A1300MVLComAux));
         AssignAttri("", false, "A1301MVLComCueCod", StringUtil.RTrim( A1301MVLComCueCod));
         AssignAttri("", false, "A393MVLForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A393MVLForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1355MVLPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1355MVLPagReg), 10, 0, ".", "")));
         AssignAttri("", false, "A1357MVLRedondeo", StringUtil.LTrim( StringUtil.NToC( A1357MVLRedondeo, 15, 2, ".", "")));
         AssignAttri("", false, "A1304MVLComPorIVA", StringUtil.LTrim( StringUtil.NToC( A1304MVLComPorIVA, 15, 2, ".", "")));
         AssignAttri("", false, "A1364MVLUsuCod", StringUtil.RTrim( A1364MVLUsuCod));
         AssignAttri("", false, "A1365MVLUsuFec", context.localUtil.TToC( A1365MVLUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1305MVLComTipReg", StringUtil.RTrim( A1305MVLComTipReg));
         AssignAttri("", false, "A1307MVLConCajDsc", StringUtil.RTrim( A1307MVLConCajDsc));
         AssignAttri("", false, "A1306MVLConCajCue", StringUtil.RTrim( A1306MVLConCajCue));
         AssignAttri("", false, "A1312MVLCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1312MVLCueCos), 1, 0, ".", "")));
         AssignAttri("", false, "A1356MVLPrvDsc", StringUtil.RTrim( A1356MVLPrvDsc));
         AssignAttri("", false, "A1314MVLCueDsc", StringUtil.RTrim( A1314MVLCueDsc));
         AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1313MVLCueCosCod), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z358CajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z358CajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z391MVLCajCod", StringUtil.RTrim( Z391MVLCajCod));
         GxWebStd.gx_hidden_field( context, "Z392MVLITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z392MVLITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1295MVLCajFec", context.localUtil.Format(Z1295MVLCajFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1293MVLCajDoc", StringUtil.RTrim( Z1293MVLCajDoc));
         GxWebStd.gx_hidden_field( context, "Z1292MVLCajConc", StringUtil.RTrim( Z1292MVLCajConc));
         GxWebStd.gx_hidden_field( context, "Z399MVLConcCajCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z399MVLConcCajCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1311MVLCueCodAux", StringUtil.RTrim( Z1311MVLCueCodAux));
         GxWebStd.gx_hidden_field( context, "Z1310MVLCueAuxCod", StringUtil.RTrim( Z1310MVLCueAuxCod));
         GxWebStd.gx_hidden_field( context, "Z397MVLCosCod", StringUtil.RTrim( Z397MVLCosCod));
         GxWebStd.gx_hidden_field( context, "Z1296MVLCajImp", StringUtil.LTrim( StringUtil.NToC( Z1296MVLCajImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1361MVLTipo", StringUtil.RTrim( Z1361MVLTipo));
         GxWebStd.gx_hidden_field( context, "Z396MVLPrvCod", StringUtil.RTrim( Z396MVLPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1299MVLCajTCod", StringUtil.RTrim( Z1299MVLCajTCod));
         GxWebStd.gx_hidden_field( context, "Z1294MVLCajDocP", StringUtil.RTrim( Z1294MVLCajDocP));
         GxWebStd.gx_hidden_field( context, "Z1297MVLCajReg", StringUtil.RTrim( Z1297MVLCajReg));
         GxWebStd.gx_hidden_field( context, "Z1298MVLCajTCmb", StringUtil.LTrim( StringUtil.NToC( Z1298MVLCajTCmb, 10, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1302MVLComFec", context.localUtil.Format(Z1302MVLComFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1303MVLComFReg", context.localUtil.Format(Z1303MVLComFReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z395MVLCueCod", StringUtil.RTrim( Z395MVLCueCod));
         GxWebStd.gx_hidden_field( context, "Z1358MVLSubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1358MVLSubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1359MVLSubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1359MVLSubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1354MVLIGV", StringUtil.LTrim( StringUtil.NToC( Z1354MVLIGV, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1362MVLTotal", StringUtil.LTrim( StringUtil.NToC( Z1362MVLTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1363MVLTotalPago", StringUtil.LTrim( StringUtil.NToC( Z1363MVLTotalPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1366MVLVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1366MVLVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1367MVLVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1367MVLVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1360MVLTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1360MVLTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1368MVLVouNum", StringUtil.RTrim( Z1368MVLVouNum));
         GxWebStd.gx_hidden_field( context, "Z394MVLMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z394MVLMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z398MVLComCosCod", StringUtil.RTrim( Z398MVLComCosCod));
         GxWebStd.gx_hidden_field( context, "Z1300MVLComAux", StringUtil.RTrim( Z1300MVLComAux));
         GxWebStd.gx_hidden_field( context, "Z1301MVLComCueCod", StringUtil.RTrim( Z1301MVLComCueCod));
         GxWebStd.gx_hidden_field( context, "Z393MVLForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z393MVLForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1355MVLPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1355MVLPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1357MVLRedondeo", StringUtil.LTrim( StringUtil.NToC( Z1357MVLRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1304MVLComPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1304MVLComPorIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1364MVLUsuCod", StringUtil.RTrim( Z1364MVLUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1365MVLUsuFec", context.localUtil.TToC( Z1365MVLUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1305MVLComTipReg", StringUtil.RTrim( Z1305MVLComTipReg));
         GxWebStd.gx_hidden_field( context, "Z1307MVLConCajDsc", StringUtil.RTrim( Z1307MVLConCajDsc));
         GxWebStd.gx_hidden_field( context, "Z1306MVLConCajCue", StringUtil.RTrim( Z1306MVLConCajCue));
         GxWebStd.gx_hidden_field( context, "Z1312MVLCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1312MVLCueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1356MVLPrvDsc", StringUtil.RTrim( Z1356MVLPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1314MVLCueDsc", StringUtil.RTrim( Z1314MVLCueDsc));
         GxWebStd.gx_hidden_field( context, "Z1313MVLCueCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1313MVLCueCosCod), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Mvlconccajcod( )
      {
         /* Using cursor T005B29 */
         pr_default.execute(27, new Object[] {A399MVLConcCajCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Caja'.", "ForeignKeyNotFound", 1, "MVLCONCCAJCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLConcCajCod_Internalname;
         }
         A1307MVLConCajDsc = T005B29_A1307MVLConCajDsc[0];
         A1306MVLConCajCue = T005B29_A1306MVLConCajCue[0];
         pr_default.close(27);
         /* Using cursor T005B30 */
         pr_default.execute(28, new Object[] {A1306MVLConCajCue});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto de Caja'.", "ForeignKeyNotFound", 1, "MVLCONCAJCUE");
            AnyError = 1;
         }
         A1312MVLCueCos = T005B30_A1312MVLCueCos[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1307MVLConCajDsc", StringUtil.RTrim( A1307MVLConCajDsc));
         AssignAttri("", false, "A1306MVLConCajCue", StringUtil.RTrim( A1306MVLConCajCue));
         AssignAttri("", false, "A1312MVLCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1312MVLCueCos), 1, 0, ".", "")));
      }

      public void Valid_Mvlcoscod( )
      {
         n397MVLCosCod = false;
         /* Using cursor T005B35 */
         pr_default.execute(33, new Object[] {n397MVLCosCod, A397MVLCosCod});
         if ( (pr_default.getStatus(33) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A397MVLCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "MVLCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLCosCod_Internalname;
            }
         }
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvlprvcod( )
      {
         /* Using cursor T005B31 */
         pr_default.execute(29, new Object[] {A396MVLPrvCod});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "MVLPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLPrvCod_Internalname;
         }
         A1356MVLPrvDsc = T005B31_A1356MVLPrvDsc[0];
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1356MVLPrvDsc", StringUtil.RTrim( A1356MVLPrvDsc));
      }

      public void Valid_Mvlcuecod( )
      {
         /* Using cursor T005B32 */
         pr_default.execute(30, new Object[] {A395MVLCueCod});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "MVLCUECOD");
            AnyError = 1;
            GX_FocusControl = edtMVLCueCod_Internalname;
         }
         A1314MVLCueDsc = T005B32_A1314MVLCueDsc[0];
         A1313MVLCueCosCod = T005B32_A1313MVLCueCosCod[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1314MVLCueDsc", StringUtil.RTrim( A1314MVLCueDsc));
         AssignAttri("", false, "A1313MVLCueCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1313MVLCueCosCod), 1, 0, ".", "")));
      }

      public void Valid_Mvlmoncod( )
      {
         /* Using cursor T005B36 */
         pr_default.execute(34, new Object[] {A394MVLMonCod});
         if ( (pr_default.getStatus(34) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "MVLMONCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLMonCod_Internalname;
         }
         pr_default.close(34);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvlcomcoscod( )
      {
         n398MVLComCosCod = false;
         /* Using cursor T005B37 */
         pr_default.execute(35, new Object[] {n398MVLComCosCod, A398MVLComCosCod});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A398MVLComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro de Costos'.", "ForeignKeyNotFound", 1, "MVLCOMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLComCosCod_Internalname;
            }
         }
         pr_default.close(35);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvlforcod( )
      {
         n393MVLForCod = false;
         /* Using cursor T005B38 */
         pr_default.execute(36, new Object[] {n393MVLForCod, A393MVLForCod});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( (0==A393MVLForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma Pago'.", "ForeignKeyNotFound", 1, "MVLFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLForCod_Internalname;
            }
         }
         pr_default.close(36);
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
         setEventMetadata("VALID_CAJCOD","{handler:'Valid_Cajcod',iparms:[{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CAJCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLCAJCOD","{handler:'Valid_Mvlcajcod',iparms:[]");
         setEventMetadata("VALID_MVLCAJCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLITEM","{handler:'Valid_Mvlitem',iparms:[{av:'A358CajCod',fld:'CAJCOD',pic:'ZZZZZ9'},{av:'A391MVLCajCod',fld:'MVLCAJCOD',pic:''},{av:'A392MVLITem',fld:'MVLITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MVLITEM",",oparms:[{av:'A1295MVLCajFec',fld:'MVLCAJFEC',pic:''},{av:'A1293MVLCajDoc',fld:'MVLCAJDOC',pic:''},{av:'A1292MVLCajConc',fld:'MVLCAJCONC',pic:''},{av:'A399MVLConcCajCod',fld:'MVLCONCCAJCOD',pic:'ZZZZZ9'},{av:'A1311MVLCueCodAux',fld:'MVLCUECODAUX',pic:''},{av:'A1310MVLCueAuxCod',fld:'MVLCUEAUXCOD',pic:''},{av:'A397MVLCosCod',fld:'MVLCOSCOD',pic:''},{av:'A1296MVLCajImp',fld:'MVLCAJIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1361MVLTipo',fld:'MVLTIPO',pic:''},{av:'A396MVLPrvCod',fld:'MVLPRVCOD',pic:'@!'},{av:'A1299MVLCajTCod',fld:'MVLCAJTCOD',pic:''},{av:'A1294MVLCajDocP',fld:'MVLCAJDOCP',pic:''},{av:'A1297MVLCajReg',fld:'MVLCAJREG',pic:''},{av:'A1298MVLCajTCmb',fld:'MVLCAJTCMB',pic:'ZZZZ9.9999'},{av:'A1302MVLComFec',fld:'MVLCOMFEC',pic:''},{av:'A1303MVLComFReg',fld:'MVLCOMFREG',pic:''},{av:'A395MVLCueCod',fld:'MVLCUECOD',pic:''},{av:'A1358MVLSubAfecto',fld:'MVLSUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1359MVLSubInafecto',fld:'MVLSUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1354MVLIGV',fld:'MVLIGV',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1362MVLTotal',fld:'MVLTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1363MVLTotalPago',fld:'MVLTOTALPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1366MVLVouAno',fld:'MVLVOUANO',pic:'ZZZ9'},{av:'A1367MVLVouMes',fld:'MVLVOUMES',pic:'Z9'},{av:'A1360MVLTASICod',fld:'MVLTASICOD',pic:'ZZZZZ9'},{av:'A1368MVLVouNum',fld:'MVLVOUNUM',pic:''},{av:'A394MVLMonCod',fld:'MVLMONCOD',pic:'ZZZZZ9'},{av:'A398MVLComCosCod',fld:'MVLCOMCOSCOD',pic:''},{av:'A1300MVLComAux',fld:'MVLCOMAUX',pic:''},{av:'A1301MVLComCueCod',fld:'MVLCOMCUECOD',pic:''},{av:'A393MVLForCod',fld:'MVLFORCOD',pic:'ZZZZZ9'},{av:'A1355MVLPagReg',fld:'MVLPAGREG',pic:'ZZZZZZZZZ9'},{av:'A1357MVLRedondeo',fld:'MVLREDONDEO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1304MVLComPorIVA',fld:'MVLCOMPORIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1364MVLUsuCod',fld:'MVLUSUCOD',pic:''},{av:'A1365MVLUsuFec',fld:'MVLUSUFEC',pic:'99/99/99 99:99'},{av:'A1305MVLComTipReg',fld:'MVLCOMTIPREG',pic:''},{av:'A1307MVLConCajDsc',fld:'MVLCONCAJDSC',pic:''},{av:'A1306MVLConCajCue',fld:'MVLCONCAJCUE',pic:''},{av:'A1312MVLCueCos',fld:'MVLCUECOS',pic:'9'},{av:'A1356MVLPrvDsc',fld:'MVLPRVDSC',pic:''},{av:'A1314MVLCueDsc',fld:'MVLCUEDSC',pic:''},{av:'A1313MVLCueCosCod',fld:'MVLCUECOSCOD',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z358CajCod'},{av:'Z391MVLCajCod'},{av:'Z392MVLITem'},{av:'Z1295MVLCajFec'},{av:'Z1293MVLCajDoc'},{av:'Z1292MVLCajConc'},{av:'Z399MVLConcCajCod'},{av:'Z1311MVLCueCodAux'},{av:'Z1310MVLCueAuxCod'},{av:'Z397MVLCosCod'},{av:'Z1296MVLCajImp'},{av:'Z1361MVLTipo'},{av:'Z396MVLPrvCod'},{av:'Z1299MVLCajTCod'},{av:'Z1294MVLCajDocP'},{av:'Z1297MVLCajReg'},{av:'Z1298MVLCajTCmb'},{av:'Z1302MVLComFec'},{av:'Z1303MVLComFReg'},{av:'Z395MVLCueCod'},{av:'Z1358MVLSubAfecto'},{av:'Z1359MVLSubInafecto'},{av:'Z1354MVLIGV'},{av:'Z1362MVLTotal'},{av:'Z1363MVLTotalPago'},{av:'Z1366MVLVouAno'},{av:'Z1367MVLVouMes'},{av:'Z1360MVLTASICod'},{av:'Z1368MVLVouNum'},{av:'Z394MVLMonCod'},{av:'Z398MVLComCosCod'},{av:'Z1300MVLComAux'},{av:'Z1301MVLComCueCod'},{av:'Z393MVLForCod'},{av:'Z1355MVLPagReg'},{av:'Z1357MVLRedondeo'},{av:'Z1304MVLComPorIVA'},{av:'Z1364MVLUsuCod'},{av:'Z1365MVLUsuFec'},{av:'Z1305MVLComTipReg'},{av:'Z1307MVLConCajDsc'},{av:'Z1306MVLConCajCue'},{av:'Z1312MVLCueCos'},{av:'Z1356MVLPrvDsc'},{av:'Z1314MVLCueDsc'},{av:'Z1313MVLCueCosCod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_MVLCAJFEC","{handler:'Valid_Mvlcajfec',iparms:[]");
         setEventMetadata("VALID_MVLCAJFEC",",oparms:[]}");
         setEventMetadata("VALID_MVLCONCCAJCOD","{handler:'Valid_Mvlconccajcod',iparms:[{av:'A399MVLConcCajCod',fld:'MVLCONCCAJCOD',pic:'ZZZZZ9'},{av:'A1306MVLConCajCue',fld:'MVLCONCAJCUE',pic:''},{av:'A1307MVLConCajDsc',fld:'MVLCONCAJDSC',pic:''},{av:'A1312MVLCueCos',fld:'MVLCUECOS',pic:'9'}]");
         setEventMetadata("VALID_MVLCONCCAJCOD",",oparms:[{av:'A1307MVLConCajDsc',fld:'MVLCONCAJDSC',pic:''},{av:'A1306MVLConCajCue',fld:'MVLCONCAJCUE',pic:''},{av:'A1312MVLCueCos',fld:'MVLCUECOS',pic:'9'}]}");
         setEventMetadata("VALID_MVLCOSCOD","{handler:'Valid_Mvlcoscod',iparms:[{av:'A397MVLCosCod',fld:'MVLCOSCOD',pic:''}]");
         setEventMetadata("VALID_MVLCOSCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLPRVCOD","{handler:'Valid_Mvlprvcod',iparms:[{av:'A396MVLPrvCod',fld:'MVLPRVCOD',pic:'@!'},{av:'A1356MVLPrvDsc',fld:'MVLPRVDSC',pic:''}]");
         setEventMetadata("VALID_MVLPRVCOD",",oparms:[{av:'A1356MVLPrvDsc',fld:'MVLPRVDSC',pic:''}]}");
         setEventMetadata("VALID_MVLCOMFEC","{handler:'Valid_Mvlcomfec',iparms:[]");
         setEventMetadata("VALID_MVLCOMFEC",",oparms:[]}");
         setEventMetadata("VALID_MVLCOMFREG","{handler:'Valid_Mvlcomfreg',iparms:[]");
         setEventMetadata("VALID_MVLCOMFREG",",oparms:[]}");
         setEventMetadata("VALID_MVLCUECOD","{handler:'Valid_Mvlcuecod',iparms:[{av:'A395MVLCueCod',fld:'MVLCUECOD',pic:''},{av:'A1314MVLCueDsc',fld:'MVLCUEDSC',pic:''},{av:'A1313MVLCueCosCod',fld:'MVLCUECOSCOD',pic:'9'}]");
         setEventMetadata("VALID_MVLCUECOD",",oparms:[{av:'A1314MVLCueDsc',fld:'MVLCUEDSC',pic:''},{av:'A1313MVLCueCosCod',fld:'MVLCUECOSCOD',pic:'9'}]}");
         setEventMetadata("VALID_MVLMONCOD","{handler:'Valid_Mvlmoncod',iparms:[{av:'A394MVLMonCod',fld:'MVLMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MVLMONCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLCOMCOSCOD","{handler:'Valid_Mvlcomcoscod',iparms:[{av:'A398MVLComCosCod',fld:'MVLCOMCOSCOD',pic:''}]");
         setEventMetadata("VALID_MVLCOMCOSCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLFORCOD","{handler:'Valid_Mvlforcod',iparms:[{av:'A393MVLForCod',fld:'MVLFORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MVLFORCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLUSUFEC","{handler:'Valid_Mvlusufec',iparms:[]");
         setEventMetadata("VALID_MVLUSUFEC",",oparms:[]}");
         setEventMetadata("VALID_MVLCONCAJCUE","{handler:'Valid_Mvlconcajcue',iparms:[]");
         setEventMetadata("VALID_MVLCONCAJCUE",",oparms:[]}");
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
         pr_default.close(32);
         pr_default.close(27);
         pr_default.close(33);
         pr_default.close(35);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(34);
         pr_default.close(36);
         pr_default.close(28);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z391MVLCajCod = "";
         Z1295MVLCajFec = DateTime.MinValue;
         Z1293MVLCajDoc = "";
         Z1292MVLCajConc = "";
         Z1311MVLCueCodAux = "";
         Z1310MVLCueAuxCod = "";
         Z1361MVLTipo = "";
         Z1299MVLCajTCod = "";
         Z1294MVLCajDocP = "";
         Z1297MVLCajReg = "";
         Z1302MVLComFec = DateTime.MinValue;
         Z1303MVLComFReg = DateTime.MinValue;
         Z1368MVLVouNum = "";
         Z1300MVLComAux = "";
         Z1301MVLComCueCod = "";
         Z1364MVLUsuCod = "";
         Z1365MVLUsuFec = (DateTime)(DateTime.MinValue);
         Z1305MVLComTipReg = "";
         Z397MVLCosCod = "";
         Z398MVLComCosCod = "";
         Z396MVLPrvCod = "";
         Z395MVLCueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A1306MVLConCajCue = "";
         A397MVLCosCod = "";
         A396MVLPrvCod = "";
         A395MVLCueCod = "";
         A398MVLComCosCod = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         sStyleString = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A391MVLCajCod = "";
         lblTextblock3_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1295MVLCajFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A1293MVLCajDoc = "";
         lblTextblock6_Jsonclick = "";
         A1292MVLCajConc = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A1311MVLCueCodAux = "";
         lblTextblock9_Jsonclick = "";
         A1310MVLCueAuxCod = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A1361MVLTipo = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         A1299MVLCajTCod = "";
         lblTextblock15_Jsonclick = "";
         A1294MVLCajDocP = "";
         lblTextblock16_Jsonclick = "";
         A1297MVLCajReg = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         A1302MVLComFec = DateTime.MinValue;
         lblTextblock19_Jsonclick = "";
         A1303MVLComFReg = DateTime.MinValue;
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         lblTextblock29_Jsonclick = "";
         A1368MVLVouNum = "";
         lblTextblock30_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         lblTextblock32_Jsonclick = "";
         A1300MVLComAux = "";
         lblTextblock33_Jsonclick = "";
         A1301MVLComCueCod = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         lblTextblock36_Jsonclick = "";
         lblTextblock37_Jsonclick = "";
         lblTextblock38_Jsonclick = "";
         A1364MVLUsuCod = "";
         lblTextblock39_Jsonclick = "";
         A1365MVLUsuFec = (DateTime)(DateTime.MinValue);
         lblTextblock40_Jsonclick = "";
         A1305MVLComTipReg = "";
         lblTextblock41_Jsonclick = "";
         A1307MVLConCajDsc = "";
         lblTextblock42_Jsonclick = "";
         lblTextblock43_Jsonclick = "";
         lblTextblock44_Jsonclick = "";
         A1356MVLPrvDsc = "";
         lblTextblock45_Jsonclick = "";
         A1314MVLCueDsc = "";
         lblTextblock46_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1307MVLConCajDsc = "";
         Z1306MVLConCajCue = "";
         Z1356MVLPrvDsc = "";
         Z1314MVLCueDsc = "";
         T005B13_A391MVLCajCod = new string[] {""} ;
         T005B13_A392MVLITem = new int[1] ;
         T005B13_A1295MVLCajFec = new DateTime[] {DateTime.MinValue} ;
         T005B13_A1293MVLCajDoc = new string[] {""} ;
         T005B13_A1292MVLCajConc = new string[] {""} ;
         T005B13_A1311MVLCueCodAux = new string[] {""} ;
         T005B13_A1310MVLCueAuxCod = new string[] {""} ;
         T005B13_A1296MVLCajImp = new decimal[1] ;
         T005B13_A1361MVLTipo = new string[] {""} ;
         T005B13_A1299MVLCajTCod = new string[] {""} ;
         T005B13_A1294MVLCajDocP = new string[] {""} ;
         T005B13_A1297MVLCajReg = new string[] {""} ;
         T005B13_A1298MVLCajTCmb = new decimal[1] ;
         T005B13_A1302MVLComFec = new DateTime[] {DateTime.MinValue} ;
         T005B13_A1303MVLComFReg = new DateTime[] {DateTime.MinValue} ;
         T005B13_A1358MVLSubAfecto = new decimal[1] ;
         T005B13_A1359MVLSubInafecto = new decimal[1] ;
         T005B13_A1354MVLIGV = new decimal[1] ;
         T005B13_A1362MVLTotal = new decimal[1] ;
         T005B13_A1363MVLTotalPago = new decimal[1] ;
         T005B13_A1366MVLVouAno = new short[1] ;
         T005B13_A1367MVLVouMes = new short[1] ;
         T005B13_A1360MVLTASICod = new int[1] ;
         T005B13_A1368MVLVouNum = new string[] {""} ;
         T005B13_A1300MVLComAux = new string[] {""} ;
         T005B13_A1301MVLComCueCod = new string[] {""} ;
         T005B13_A1355MVLPagReg = new long[1] ;
         T005B13_A1357MVLRedondeo = new decimal[1] ;
         T005B13_A1304MVLComPorIVA = new decimal[1] ;
         T005B13_A1364MVLUsuCod = new string[] {""} ;
         T005B13_A1365MVLUsuFec = new DateTime[] {DateTime.MinValue} ;
         T005B13_A1305MVLComTipReg = new string[] {""} ;
         T005B13_A1307MVLConCajDsc = new string[] {""} ;
         T005B13_A1312MVLCueCos = new short[1] ;
         T005B13_A1356MVLPrvDsc = new string[] {""} ;
         T005B13_A1314MVLCueDsc = new string[] {""} ;
         T005B13_A1313MVLCueCosCod = new short[1] ;
         T005B13_A358CajCod = new int[1] ;
         T005B13_A399MVLConcCajCod = new int[1] ;
         T005B13_A397MVLCosCod = new string[] {""} ;
         T005B13_n397MVLCosCod = new bool[] {false} ;
         T005B13_A398MVLComCosCod = new string[] {""} ;
         T005B13_n398MVLComCosCod = new bool[] {false} ;
         T005B13_A396MVLPrvCod = new string[] {""} ;
         T005B13_A395MVLCueCod = new string[] {""} ;
         T005B13_A394MVLMonCod = new int[1] ;
         T005B13_A393MVLForCod = new int[1] ;
         T005B13_n393MVLForCod = new bool[] {false} ;
         T005B13_A1306MVLConCajCue = new string[] {""} ;
         T005B4_A358CajCod = new int[1] ;
         T005B5_A1307MVLConCajDsc = new string[] {""} ;
         T005B5_A1306MVLConCajCue = new string[] {""} ;
         T005B12_A1312MVLCueCos = new short[1] ;
         T005B6_A397MVLCosCod = new string[] {""} ;
         T005B6_n397MVLCosCod = new bool[] {false} ;
         T005B8_A1356MVLPrvDsc = new string[] {""} ;
         T005B9_A1314MVLCueDsc = new string[] {""} ;
         T005B9_A1313MVLCueCosCod = new short[1] ;
         T005B10_A394MVLMonCod = new int[1] ;
         T005B7_A398MVLComCosCod = new string[] {""} ;
         T005B7_n398MVLComCosCod = new bool[] {false} ;
         T005B11_A393MVLForCod = new int[1] ;
         T005B11_n393MVLForCod = new bool[] {false} ;
         T005B14_A358CajCod = new int[1] ;
         T005B15_A1307MVLConCajDsc = new string[] {""} ;
         T005B15_A1306MVLConCajCue = new string[] {""} ;
         T005B16_A1312MVLCueCos = new short[1] ;
         T005B17_A397MVLCosCod = new string[] {""} ;
         T005B17_n397MVLCosCod = new bool[] {false} ;
         T005B18_A1356MVLPrvDsc = new string[] {""} ;
         T005B19_A1314MVLCueDsc = new string[] {""} ;
         T005B19_A1313MVLCueCosCod = new short[1] ;
         T005B20_A394MVLMonCod = new int[1] ;
         T005B21_A398MVLComCosCod = new string[] {""} ;
         T005B21_n398MVLComCosCod = new bool[] {false} ;
         T005B22_A393MVLForCod = new int[1] ;
         T005B22_n393MVLForCod = new bool[] {false} ;
         T005B23_A358CajCod = new int[1] ;
         T005B23_A391MVLCajCod = new string[] {""} ;
         T005B23_A392MVLITem = new int[1] ;
         T005B3_A391MVLCajCod = new string[] {""} ;
         T005B3_A392MVLITem = new int[1] ;
         T005B3_A1295MVLCajFec = new DateTime[] {DateTime.MinValue} ;
         T005B3_A1293MVLCajDoc = new string[] {""} ;
         T005B3_A1292MVLCajConc = new string[] {""} ;
         T005B3_A1311MVLCueCodAux = new string[] {""} ;
         T005B3_A1310MVLCueAuxCod = new string[] {""} ;
         T005B3_A1296MVLCajImp = new decimal[1] ;
         T005B3_A1361MVLTipo = new string[] {""} ;
         T005B3_A1299MVLCajTCod = new string[] {""} ;
         T005B3_A1294MVLCajDocP = new string[] {""} ;
         T005B3_A1297MVLCajReg = new string[] {""} ;
         T005B3_A1298MVLCajTCmb = new decimal[1] ;
         T005B3_A1302MVLComFec = new DateTime[] {DateTime.MinValue} ;
         T005B3_A1303MVLComFReg = new DateTime[] {DateTime.MinValue} ;
         T005B3_A1358MVLSubAfecto = new decimal[1] ;
         T005B3_A1359MVLSubInafecto = new decimal[1] ;
         T005B3_A1354MVLIGV = new decimal[1] ;
         T005B3_A1362MVLTotal = new decimal[1] ;
         T005B3_A1363MVLTotalPago = new decimal[1] ;
         T005B3_A1366MVLVouAno = new short[1] ;
         T005B3_A1367MVLVouMes = new short[1] ;
         T005B3_A1360MVLTASICod = new int[1] ;
         T005B3_A1368MVLVouNum = new string[] {""} ;
         T005B3_A1300MVLComAux = new string[] {""} ;
         T005B3_A1301MVLComCueCod = new string[] {""} ;
         T005B3_A1355MVLPagReg = new long[1] ;
         T005B3_A1357MVLRedondeo = new decimal[1] ;
         T005B3_A1304MVLComPorIVA = new decimal[1] ;
         T005B3_A1364MVLUsuCod = new string[] {""} ;
         T005B3_A1365MVLUsuFec = new DateTime[] {DateTime.MinValue} ;
         T005B3_A1305MVLComTipReg = new string[] {""} ;
         T005B3_A358CajCod = new int[1] ;
         T005B3_A399MVLConcCajCod = new int[1] ;
         T005B3_A397MVLCosCod = new string[] {""} ;
         T005B3_n397MVLCosCod = new bool[] {false} ;
         T005B3_A398MVLComCosCod = new string[] {""} ;
         T005B3_n398MVLComCosCod = new bool[] {false} ;
         T005B3_A396MVLPrvCod = new string[] {""} ;
         T005B3_A395MVLCueCod = new string[] {""} ;
         T005B3_A394MVLMonCod = new int[1] ;
         T005B3_A393MVLForCod = new int[1] ;
         T005B3_n393MVLForCod = new bool[] {false} ;
         sMode178 = "";
         T005B24_A358CajCod = new int[1] ;
         T005B24_A391MVLCajCod = new string[] {""} ;
         T005B24_A392MVLITem = new int[1] ;
         T005B25_A358CajCod = new int[1] ;
         T005B25_A391MVLCajCod = new string[] {""} ;
         T005B25_A392MVLITem = new int[1] ;
         T005B2_A391MVLCajCod = new string[] {""} ;
         T005B2_A392MVLITem = new int[1] ;
         T005B2_A1295MVLCajFec = new DateTime[] {DateTime.MinValue} ;
         T005B2_A1293MVLCajDoc = new string[] {""} ;
         T005B2_A1292MVLCajConc = new string[] {""} ;
         T005B2_A1311MVLCueCodAux = new string[] {""} ;
         T005B2_A1310MVLCueAuxCod = new string[] {""} ;
         T005B2_A1296MVLCajImp = new decimal[1] ;
         T005B2_A1361MVLTipo = new string[] {""} ;
         T005B2_A1299MVLCajTCod = new string[] {""} ;
         T005B2_A1294MVLCajDocP = new string[] {""} ;
         T005B2_A1297MVLCajReg = new string[] {""} ;
         T005B2_A1298MVLCajTCmb = new decimal[1] ;
         T005B2_A1302MVLComFec = new DateTime[] {DateTime.MinValue} ;
         T005B2_A1303MVLComFReg = new DateTime[] {DateTime.MinValue} ;
         T005B2_A1358MVLSubAfecto = new decimal[1] ;
         T005B2_A1359MVLSubInafecto = new decimal[1] ;
         T005B2_A1354MVLIGV = new decimal[1] ;
         T005B2_A1362MVLTotal = new decimal[1] ;
         T005B2_A1363MVLTotalPago = new decimal[1] ;
         T005B2_A1366MVLVouAno = new short[1] ;
         T005B2_A1367MVLVouMes = new short[1] ;
         T005B2_A1360MVLTASICod = new int[1] ;
         T005B2_A1368MVLVouNum = new string[] {""} ;
         T005B2_A1300MVLComAux = new string[] {""} ;
         T005B2_A1301MVLComCueCod = new string[] {""} ;
         T005B2_A1355MVLPagReg = new long[1] ;
         T005B2_A1357MVLRedondeo = new decimal[1] ;
         T005B2_A1304MVLComPorIVA = new decimal[1] ;
         T005B2_A1364MVLUsuCod = new string[] {""} ;
         T005B2_A1365MVLUsuFec = new DateTime[] {DateTime.MinValue} ;
         T005B2_A1305MVLComTipReg = new string[] {""} ;
         T005B2_A358CajCod = new int[1] ;
         T005B2_A399MVLConcCajCod = new int[1] ;
         T005B2_A397MVLCosCod = new string[] {""} ;
         T005B2_n397MVLCosCod = new bool[] {false} ;
         T005B2_A398MVLComCosCod = new string[] {""} ;
         T005B2_n398MVLComCosCod = new bool[] {false} ;
         T005B2_A396MVLPrvCod = new string[] {""} ;
         T005B2_A395MVLCueCod = new string[] {""} ;
         T005B2_A394MVLMonCod = new int[1] ;
         T005B2_A393MVLForCod = new int[1] ;
         T005B2_n393MVLForCod = new bool[] {false} ;
         T005B29_A1307MVLConCajDsc = new string[] {""} ;
         T005B29_A1306MVLConCajCue = new string[] {""} ;
         T005B30_A1312MVLCueCos = new short[1] ;
         T005B31_A1356MVLPrvDsc = new string[] {""} ;
         T005B32_A1314MVLCueDsc = new string[] {""} ;
         T005B32_A1313MVLCueCosCod = new short[1] ;
         T005B33_A358CajCod = new int[1] ;
         T005B33_A391MVLCajCod = new string[] {""} ;
         T005B33_A392MVLITem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T005B34_A358CajCod = new int[1] ;
         ZZ391MVLCajCod = "";
         ZZ1295MVLCajFec = DateTime.MinValue;
         ZZ1293MVLCajDoc = "";
         ZZ1292MVLCajConc = "";
         ZZ1311MVLCueCodAux = "";
         ZZ1310MVLCueAuxCod = "";
         ZZ397MVLCosCod = "";
         ZZ1361MVLTipo = "";
         ZZ396MVLPrvCod = "";
         ZZ1299MVLCajTCod = "";
         ZZ1294MVLCajDocP = "";
         ZZ1297MVLCajReg = "";
         ZZ1302MVLComFec = DateTime.MinValue;
         ZZ1303MVLComFReg = DateTime.MinValue;
         ZZ395MVLCueCod = "";
         ZZ1368MVLVouNum = "";
         ZZ398MVLComCosCod = "";
         ZZ1300MVLComAux = "";
         ZZ1301MVLComCueCod = "";
         ZZ1364MVLUsuCod = "";
         ZZ1365MVLUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1305MVLComTipReg = "";
         ZZ1307MVLConCajDsc = "";
         ZZ1306MVLConCajCue = "";
         ZZ1356MVLPrvDsc = "";
         ZZ1314MVLCueDsc = "";
         T005B35_A397MVLCosCod = new string[] {""} ;
         T005B35_n397MVLCosCod = new bool[] {false} ;
         T005B36_A394MVLMonCod = new int[1] ;
         T005B37_A398MVLComCosCod = new string[] {""} ;
         T005B37_n398MVLComCosCod = new bool[] {false} ;
         T005B38_A393MVLForCod = new int[1] ;
         T005B38_n393MVLForCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsmovcajachica__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsmovcajachica__default(),
            new Object[][] {
                new Object[] {
               T005B2_A391MVLCajCod, T005B2_A392MVLITem, T005B2_A1295MVLCajFec, T005B2_A1293MVLCajDoc, T005B2_A1292MVLCajConc, T005B2_A1311MVLCueCodAux, T005B2_A1310MVLCueAuxCod, T005B2_A1296MVLCajImp, T005B2_A1361MVLTipo, T005B2_A1299MVLCajTCod,
               T005B2_A1294MVLCajDocP, T005B2_A1297MVLCajReg, T005B2_A1298MVLCajTCmb, T005B2_A1302MVLComFec, T005B2_A1303MVLComFReg, T005B2_A1358MVLSubAfecto, T005B2_A1359MVLSubInafecto, T005B2_A1354MVLIGV, T005B2_A1362MVLTotal, T005B2_A1363MVLTotalPago,
               T005B2_A1366MVLVouAno, T005B2_A1367MVLVouMes, T005B2_A1360MVLTASICod, T005B2_A1368MVLVouNum, T005B2_A1300MVLComAux, T005B2_A1301MVLComCueCod, T005B2_A1355MVLPagReg, T005B2_A1357MVLRedondeo, T005B2_A1304MVLComPorIVA, T005B2_A1364MVLUsuCod,
               T005B2_A1365MVLUsuFec, T005B2_A1305MVLComTipReg, T005B2_A358CajCod, T005B2_A399MVLConcCajCod, T005B2_A397MVLCosCod, T005B2_n397MVLCosCod, T005B2_A398MVLComCosCod, T005B2_n398MVLComCosCod, T005B2_A396MVLPrvCod, T005B2_A395MVLCueCod,
               T005B2_A394MVLMonCod, T005B2_A393MVLForCod, T005B2_n393MVLForCod
               }
               , new Object[] {
               T005B3_A391MVLCajCod, T005B3_A392MVLITem, T005B3_A1295MVLCajFec, T005B3_A1293MVLCajDoc, T005B3_A1292MVLCajConc, T005B3_A1311MVLCueCodAux, T005B3_A1310MVLCueAuxCod, T005B3_A1296MVLCajImp, T005B3_A1361MVLTipo, T005B3_A1299MVLCajTCod,
               T005B3_A1294MVLCajDocP, T005B3_A1297MVLCajReg, T005B3_A1298MVLCajTCmb, T005B3_A1302MVLComFec, T005B3_A1303MVLComFReg, T005B3_A1358MVLSubAfecto, T005B3_A1359MVLSubInafecto, T005B3_A1354MVLIGV, T005B3_A1362MVLTotal, T005B3_A1363MVLTotalPago,
               T005B3_A1366MVLVouAno, T005B3_A1367MVLVouMes, T005B3_A1360MVLTASICod, T005B3_A1368MVLVouNum, T005B3_A1300MVLComAux, T005B3_A1301MVLComCueCod, T005B3_A1355MVLPagReg, T005B3_A1357MVLRedondeo, T005B3_A1304MVLComPorIVA, T005B3_A1364MVLUsuCod,
               T005B3_A1365MVLUsuFec, T005B3_A1305MVLComTipReg, T005B3_A358CajCod, T005B3_A399MVLConcCajCod, T005B3_A397MVLCosCod, T005B3_n397MVLCosCod, T005B3_A398MVLComCosCod, T005B3_n398MVLComCosCod, T005B3_A396MVLPrvCod, T005B3_A395MVLCueCod,
               T005B3_A394MVLMonCod, T005B3_A393MVLForCod, T005B3_n393MVLForCod
               }
               , new Object[] {
               T005B4_A358CajCod
               }
               , new Object[] {
               T005B5_A1307MVLConCajDsc, T005B5_A1306MVLConCajCue
               }
               , new Object[] {
               T005B6_A397MVLCosCod
               }
               , new Object[] {
               T005B7_A398MVLComCosCod
               }
               , new Object[] {
               T005B8_A1356MVLPrvDsc
               }
               , new Object[] {
               T005B9_A1314MVLCueDsc, T005B9_A1313MVLCueCosCod
               }
               , new Object[] {
               T005B10_A394MVLMonCod
               }
               , new Object[] {
               T005B11_A393MVLForCod
               }
               , new Object[] {
               T005B12_A1312MVLCueCos
               }
               , new Object[] {
               T005B13_A391MVLCajCod, T005B13_A392MVLITem, T005B13_A1295MVLCajFec, T005B13_A1293MVLCajDoc, T005B13_A1292MVLCajConc, T005B13_A1311MVLCueCodAux, T005B13_A1310MVLCueAuxCod, T005B13_A1296MVLCajImp, T005B13_A1361MVLTipo, T005B13_A1299MVLCajTCod,
               T005B13_A1294MVLCajDocP, T005B13_A1297MVLCajReg, T005B13_A1298MVLCajTCmb, T005B13_A1302MVLComFec, T005B13_A1303MVLComFReg, T005B13_A1358MVLSubAfecto, T005B13_A1359MVLSubInafecto, T005B13_A1354MVLIGV, T005B13_A1362MVLTotal, T005B13_A1363MVLTotalPago,
               T005B13_A1366MVLVouAno, T005B13_A1367MVLVouMes, T005B13_A1360MVLTASICod, T005B13_A1368MVLVouNum, T005B13_A1300MVLComAux, T005B13_A1301MVLComCueCod, T005B13_A1355MVLPagReg, T005B13_A1357MVLRedondeo, T005B13_A1304MVLComPorIVA, T005B13_A1364MVLUsuCod,
               T005B13_A1365MVLUsuFec, T005B13_A1305MVLComTipReg, T005B13_A1307MVLConCajDsc, T005B13_A1312MVLCueCos, T005B13_A1356MVLPrvDsc, T005B13_A1314MVLCueDsc, T005B13_A1313MVLCueCosCod, T005B13_A358CajCod, T005B13_A399MVLConcCajCod, T005B13_A397MVLCosCod,
               T005B13_n397MVLCosCod, T005B13_A398MVLComCosCod, T005B13_n398MVLComCosCod, T005B13_A396MVLPrvCod, T005B13_A395MVLCueCod, T005B13_A394MVLMonCod, T005B13_A393MVLForCod, T005B13_n393MVLForCod, T005B13_A1306MVLConCajCue
               }
               , new Object[] {
               T005B14_A358CajCod
               }
               , new Object[] {
               T005B15_A1307MVLConCajDsc, T005B15_A1306MVLConCajCue
               }
               , new Object[] {
               T005B16_A1312MVLCueCos
               }
               , new Object[] {
               T005B17_A397MVLCosCod
               }
               , new Object[] {
               T005B18_A1356MVLPrvDsc
               }
               , new Object[] {
               T005B19_A1314MVLCueDsc, T005B19_A1313MVLCueCosCod
               }
               , new Object[] {
               T005B20_A394MVLMonCod
               }
               , new Object[] {
               T005B21_A398MVLComCosCod
               }
               , new Object[] {
               T005B22_A393MVLForCod
               }
               , new Object[] {
               T005B23_A358CajCod, T005B23_A391MVLCajCod, T005B23_A392MVLITem
               }
               , new Object[] {
               T005B24_A358CajCod, T005B24_A391MVLCajCod, T005B24_A392MVLITem
               }
               , new Object[] {
               T005B25_A358CajCod, T005B25_A391MVLCajCod, T005B25_A392MVLITem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005B29_A1307MVLConCajDsc, T005B29_A1306MVLConCajCue
               }
               , new Object[] {
               T005B30_A1312MVLCueCos
               }
               , new Object[] {
               T005B31_A1356MVLPrvDsc
               }
               , new Object[] {
               T005B32_A1314MVLCueDsc, T005B32_A1313MVLCueCosCod
               }
               , new Object[] {
               T005B33_A358CajCod, T005B33_A391MVLCajCod, T005B33_A392MVLITem
               }
               , new Object[] {
               T005B34_A358CajCod
               }
               , new Object[] {
               T005B35_A397MVLCosCod
               }
               , new Object[] {
               T005B36_A394MVLMonCod
               }
               , new Object[] {
               T005B37_A398MVLComCosCod
               }
               , new Object[] {
               T005B38_A393MVLForCod
               }
            }
         );
      }

      private short Z1366MVLVouAno ;
      private short Z1367MVLVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1366MVLVouAno ;
      private short A1367MVLVouMes ;
      private short A1312MVLCueCos ;
      private short A1313MVLCueCosCod ;
      private short GX_JID ;
      private short Z1312MVLCueCos ;
      private short Z1313MVLCueCosCod ;
      private short RcdFound178 ;
      private short nIsDirty_178 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1366MVLVouAno ;
      private short ZZ1367MVLVouMes ;
      private short ZZ1312MVLCueCos ;
      private short ZZ1313MVLCueCosCod ;
      private int Z358CajCod ;
      private int Z392MVLITem ;
      private int Z1360MVLTASICod ;
      private int Z399MVLConcCajCod ;
      private int Z394MVLMonCod ;
      private int Z393MVLForCod ;
      private int A358CajCod ;
      private int A399MVLConcCajCod ;
      private int A394MVLMonCod ;
      private int A393MVLForCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCajCod_Enabled ;
      private int edtMVLCajCod_Enabled ;
      private int A392MVLITem ;
      private int edtMVLITem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMVLCajFec_Enabled ;
      private int edtMVLCajDoc_Enabled ;
      private int edtMVLCajConc_Enabled ;
      private int edtMVLConcCajCod_Enabled ;
      private int edtMVLCueCodAux_Enabled ;
      private int edtMVLCueAuxCod_Enabled ;
      private int edtMVLCosCod_Enabled ;
      private int edtMVLCajImp_Enabled ;
      private int edtMVLTipo_Enabled ;
      private int edtMVLPrvCod_Enabled ;
      private int edtMVLCajTCod_Enabled ;
      private int edtMVLCajDocP_Enabled ;
      private int edtMVLCajReg_Enabled ;
      private int edtMVLCajTCmb_Enabled ;
      private int edtMVLComFec_Enabled ;
      private int edtMVLComFReg_Enabled ;
      private int edtMVLCueCod_Enabled ;
      private int edtMVLSubAfecto_Enabled ;
      private int edtMVLSubInafecto_Enabled ;
      private int edtMVLIGV_Enabled ;
      private int edtMVLTotal_Enabled ;
      private int edtMVLTotalPago_Enabled ;
      private int edtMVLVouAno_Enabled ;
      private int edtMVLVouMes_Enabled ;
      private int A1360MVLTASICod ;
      private int edtMVLTASICod_Enabled ;
      private int edtMVLVouNum_Enabled ;
      private int edtMVLMonCod_Enabled ;
      private int edtMVLComCosCod_Enabled ;
      private int edtMVLComAux_Enabled ;
      private int edtMVLComCueCod_Enabled ;
      private int edtMVLForCod_Enabled ;
      private int edtMVLPagReg_Enabled ;
      private int edtMVLRedondeo_Enabled ;
      private int edtMVLComPorIVA_Enabled ;
      private int edtMVLUsuCod_Enabled ;
      private int edtMVLUsuFec_Enabled ;
      private int edtMVLComTipReg_Enabled ;
      private int edtMVLConCajDsc_Enabled ;
      private int edtMVLConCajCue_Enabled ;
      private int edtMVLCueCos_Enabled ;
      private int edtMVLPrvDsc_Enabled ;
      private int edtMVLCueDsc_Enabled ;
      private int edtMVLCueCosCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ358CajCod ;
      private int ZZ392MVLITem ;
      private int ZZ399MVLConcCajCod ;
      private int ZZ1360MVLTASICod ;
      private int ZZ394MVLMonCod ;
      private int ZZ393MVLForCod ;
      private long Z1355MVLPagReg ;
      private long A1355MVLPagReg ;
      private long ZZ1355MVLPagReg ;
      private decimal Z1296MVLCajImp ;
      private decimal Z1298MVLCajTCmb ;
      private decimal Z1358MVLSubAfecto ;
      private decimal Z1359MVLSubInafecto ;
      private decimal Z1354MVLIGV ;
      private decimal Z1362MVLTotal ;
      private decimal Z1363MVLTotalPago ;
      private decimal Z1357MVLRedondeo ;
      private decimal Z1304MVLComPorIVA ;
      private decimal A1296MVLCajImp ;
      private decimal A1298MVLCajTCmb ;
      private decimal A1358MVLSubAfecto ;
      private decimal A1359MVLSubInafecto ;
      private decimal A1354MVLIGV ;
      private decimal A1362MVLTotal ;
      private decimal A1363MVLTotalPago ;
      private decimal A1357MVLRedondeo ;
      private decimal A1304MVLComPorIVA ;
      private decimal ZZ1296MVLCajImp ;
      private decimal ZZ1298MVLCajTCmb ;
      private decimal ZZ1358MVLSubAfecto ;
      private decimal ZZ1359MVLSubInafecto ;
      private decimal ZZ1354MVLIGV ;
      private decimal ZZ1362MVLTotal ;
      private decimal ZZ1363MVLTotalPago ;
      private decimal ZZ1357MVLRedondeo ;
      private decimal ZZ1304MVLComPorIVA ;
      private string sPrefix ;
      private string Z391MVLCajCod ;
      private string Z1293MVLCajDoc ;
      private string Z1292MVLCajConc ;
      private string Z1311MVLCueCodAux ;
      private string Z1310MVLCueAuxCod ;
      private string Z1361MVLTipo ;
      private string Z1299MVLCajTCod ;
      private string Z1294MVLCajDocP ;
      private string Z1297MVLCajReg ;
      private string Z1368MVLVouNum ;
      private string Z1300MVLComAux ;
      private string Z1301MVLComCueCod ;
      private string Z1364MVLUsuCod ;
      private string Z1305MVLComTipReg ;
      private string Z397MVLCosCod ;
      private string Z398MVLComCosCod ;
      private string Z396MVLPrvCod ;
      private string Z395MVLCueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1306MVLConCajCue ;
      private string A397MVLCosCod ;
      private string A396MVLPrvCod ;
      private string A395MVLCueCod ;
      private string A398MVLComCosCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCajCod_Internalname ;
      private string sStyleString ;
      private string tblTable1_Internalname ;
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
      private string tblTable2_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtCajCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMVLCajCod_Internalname ;
      private string A391MVLCajCod ;
      private string edtMVLCajCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtMVLITem_Internalname ;
      private string edtMVLITem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtMVLCajFec_Internalname ;
      private string edtMVLCajFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtMVLCajDoc_Internalname ;
      private string A1293MVLCajDoc ;
      private string edtMVLCajDoc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtMVLCajConc_Internalname ;
      private string A1292MVLCajConc ;
      private string edtMVLCajConc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtMVLConcCajCod_Internalname ;
      private string edtMVLConcCajCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtMVLCueCodAux_Internalname ;
      private string A1311MVLCueCodAux ;
      private string edtMVLCueCodAux_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtMVLCueAuxCod_Internalname ;
      private string A1310MVLCueAuxCod ;
      private string edtMVLCueAuxCod_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtMVLCosCod_Internalname ;
      private string edtMVLCosCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtMVLCajImp_Internalname ;
      private string edtMVLCajImp_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtMVLTipo_Internalname ;
      private string A1361MVLTipo ;
      private string edtMVLTipo_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtMVLPrvCod_Internalname ;
      private string edtMVLPrvCod_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtMVLCajTCod_Internalname ;
      private string A1299MVLCajTCod ;
      private string edtMVLCajTCod_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtMVLCajDocP_Internalname ;
      private string A1294MVLCajDocP ;
      private string edtMVLCajDocP_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtMVLCajReg_Internalname ;
      private string A1297MVLCajReg ;
      private string edtMVLCajReg_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtMVLCajTCmb_Internalname ;
      private string edtMVLCajTCmb_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtMVLComFec_Internalname ;
      private string edtMVLComFec_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtMVLComFReg_Internalname ;
      private string edtMVLComFReg_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtMVLCueCod_Internalname ;
      private string edtMVLCueCod_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtMVLSubAfecto_Internalname ;
      private string edtMVLSubAfecto_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtMVLSubInafecto_Internalname ;
      private string edtMVLSubInafecto_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtMVLIGV_Internalname ;
      private string edtMVLIGV_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtMVLTotal_Internalname ;
      private string edtMVLTotal_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtMVLTotalPago_Internalname ;
      private string edtMVLTotalPago_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtMVLVouAno_Internalname ;
      private string edtMVLVouAno_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtMVLVouMes_Internalname ;
      private string edtMVLVouMes_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtMVLTASICod_Internalname ;
      private string edtMVLTASICod_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtMVLVouNum_Internalname ;
      private string A1368MVLVouNum ;
      private string edtMVLVouNum_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtMVLMonCod_Internalname ;
      private string edtMVLMonCod_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtMVLComCosCod_Internalname ;
      private string edtMVLComCosCod_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtMVLComAux_Internalname ;
      private string A1300MVLComAux ;
      private string edtMVLComAux_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtMVLComCueCod_Internalname ;
      private string A1301MVLComCueCod ;
      private string edtMVLComCueCod_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtMVLForCod_Internalname ;
      private string edtMVLForCod_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtMVLPagReg_Internalname ;
      private string edtMVLPagReg_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtMVLRedondeo_Internalname ;
      private string edtMVLRedondeo_Jsonclick ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string edtMVLComPorIVA_Internalname ;
      private string edtMVLComPorIVA_Jsonclick ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string edtMVLUsuCod_Internalname ;
      private string A1364MVLUsuCod ;
      private string edtMVLUsuCod_Jsonclick ;
      private string lblTextblock39_Internalname ;
      private string lblTextblock39_Jsonclick ;
      private string edtMVLUsuFec_Internalname ;
      private string edtMVLUsuFec_Jsonclick ;
      private string lblTextblock40_Internalname ;
      private string lblTextblock40_Jsonclick ;
      private string edtMVLComTipReg_Internalname ;
      private string A1305MVLComTipReg ;
      private string edtMVLComTipReg_Jsonclick ;
      private string lblTextblock41_Internalname ;
      private string lblTextblock41_Jsonclick ;
      private string edtMVLConCajDsc_Internalname ;
      private string A1307MVLConCajDsc ;
      private string edtMVLConCajDsc_Jsonclick ;
      private string lblTextblock42_Internalname ;
      private string lblTextblock42_Jsonclick ;
      private string edtMVLConCajCue_Internalname ;
      private string edtMVLConCajCue_Jsonclick ;
      private string lblTextblock43_Internalname ;
      private string lblTextblock43_Jsonclick ;
      private string edtMVLCueCos_Internalname ;
      private string edtMVLCueCos_Jsonclick ;
      private string lblTextblock44_Internalname ;
      private string lblTextblock44_Jsonclick ;
      private string edtMVLPrvDsc_Internalname ;
      private string A1356MVLPrvDsc ;
      private string edtMVLPrvDsc_Jsonclick ;
      private string lblTextblock45_Internalname ;
      private string lblTextblock45_Jsonclick ;
      private string edtMVLCueDsc_Internalname ;
      private string A1314MVLCueDsc ;
      private string edtMVLCueDsc_Jsonclick ;
      private string lblTextblock46_Internalname ;
      private string lblTextblock46_Jsonclick ;
      private string edtMVLCueCosCod_Internalname ;
      private string edtMVLCueCosCod_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_check_Internalname ;
      private string bttBtn_check_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string bttBtn_help_Internalname ;
      private string bttBtn_help_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1307MVLConCajDsc ;
      private string Z1306MVLConCajCue ;
      private string Z1356MVLPrvDsc ;
      private string Z1314MVLCueDsc ;
      private string sMode178 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ391MVLCajCod ;
      private string ZZ1293MVLCajDoc ;
      private string ZZ1292MVLCajConc ;
      private string ZZ1311MVLCueCodAux ;
      private string ZZ1310MVLCueAuxCod ;
      private string ZZ397MVLCosCod ;
      private string ZZ1361MVLTipo ;
      private string ZZ396MVLPrvCod ;
      private string ZZ1299MVLCajTCod ;
      private string ZZ1294MVLCajDocP ;
      private string ZZ1297MVLCajReg ;
      private string ZZ395MVLCueCod ;
      private string ZZ1368MVLVouNum ;
      private string ZZ398MVLComCosCod ;
      private string ZZ1300MVLComAux ;
      private string ZZ1301MVLComCueCod ;
      private string ZZ1364MVLUsuCod ;
      private string ZZ1305MVLComTipReg ;
      private string ZZ1307MVLConCajDsc ;
      private string ZZ1306MVLConCajCue ;
      private string ZZ1356MVLPrvDsc ;
      private string ZZ1314MVLCueDsc ;
      private DateTime Z1365MVLUsuFec ;
      private DateTime A1365MVLUsuFec ;
      private DateTime ZZ1365MVLUsuFec ;
      private DateTime Z1295MVLCajFec ;
      private DateTime Z1302MVLComFec ;
      private DateTime Z1303MVLComFReg ;
      private DateTime A1295MVLCajFec ;
      private DateTime A1302MVLComFec ;
      private DateTime A1303MVLComFReg ;
      private DateTime ZZ1295MVLCajFec ;
      private DateTime ZZ1302MVLComFec ;
      private DateTime ZZ1303MVLComFReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n397MVLCosCod ;
      private bool n398MVLComCosCod ;
      private bool n393MVLForCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T005B13_A391MVLCajCod ;
      private int[] T005B13_A392MVLITem ;
      private DateTime[] T005B13_A1295MVLCajFec ;
      private string[] T005B13_A1293MVLCajDoc ;
      private string[] T005B13_A1292MVLCajConc ;
      private string[] T005B13_A1311MVLCueCodAux ;
      private string[] T005B13_A1310MVLCueAuxCod ;
      private decimal[] T005B13_A1296MVLCajImp ;
      private string[] T005B13_A1361MVLTipo ;
      private string[] T005B13_A1299MVLCajTCod ;
      private string[] T005B13_A1294MVLCajDocP ;
      private string[] T005B13_A1297MVLCajReg ;
      private decimal[] T005B13_A1298MVLCajTCmb ;
      private DateTime[] T005B13_A1302MVLComFec ;
      private DateTime[] T005B13_A1303MVLComFReg ;
      private decimal[] T005B13_A1358MVLSubAfecto ;
      private decimal[] T005B13_A1359MVLSubInafecto ;
      private decimal[] T005B13_A1354MVLIGV ;
      private decimal[] T005B13_A1362MVLTotal ;
      private decimal[] T005B13_A1363MVLTotalPago ;
      private short[] T005B13_A1366MVLVouAno ;
      private short[] T005B13_A1367MVLVouMes ;
      private int[] T005B13_A1360MVLTASICod ;
      private string[] T005B13_A1368MVLVouNum ;
      private string[] T005B13_A1300MVLComAux ;
      private string[] T005B13_A1301MVLComCueCod ;
      private long[] T005B13_A1355MVLPagReg ;
      private decimal[] T005B13_A1357MVLRedondeo ;
      private decimal[] T005B13_A1304MVLComPorIVA ;
      private string[] T005B13_A1364MVLUsuCod ;
      private DateTime[] T005B13_A1365MVLUsuFec ;
      private string[] T005B13_A1305MVLComTipReg ;
      private string[] T005B13_A1307MVLConCajDsc ;
      private short[] T005B13_A1312MVLCueCos ;
      private string[] T005B13_A1356MVLPrvDsc ;
      private string[] T005B13_A1314MVLCueDsc ;
      private short[] T005B13_A1313MVLCueCosCod ;
      private int[] T005B13_A358CajCod ;
      private int[] T005B13_A399MVLConcCajCod ;
      private string[] T005B13_A397MVLCosCod ;
      private bool[] T005B13_n397MVLCosCod ;
      private string[] T005B13_A398MVLComCosCod ;
      private bool[] T005B13_n398MVLComCosCod ;
      private string[] T005B13_A396MVLPrvCod ;
      private string[] T005B13_A395MVLCueCod ;
      private int[] T005B13_A394MVLMonCod ;
      private int[] T005B13_A393MVLForCod ;
      private bool[] T005B13_n393MVLForCod ;
      private string[] T005B13_A1306MVLConCajCue ;
      private int[] T005B4_A358CajCod ;
      private string[] T005B5_A1307MVLConCajDsc ;
      private string[] T005B5_A1306MVLConCajCue ;
      private short[] T005B12_A1312MVLCueCos ;
      private string[] T005B6_A397MVLCosCod ;
      private bool[] T005B6_n397MVLCosCod ;
      private string[] T005B8_A1356MVLPrvDsc ;
      private string[] T005B9_A1314MVLCueDsc ;
      private short[] T005B9_A1313MVLCueCosCod ;
      private int[] T005B10_A394MVLMonCod ;
      private string[] T005B7_A398MVLComCosCod ;
      private bool[] T005B7_n398MVLComCosCod ;
      private int[] T005B11_A393MVLForCod ;
      private bool[] T005B11_n393MVLForCod ;
      private int[] T005B14_A358CajCod ;
      private string[] T005B15_A1307MVLConCajDsc ;
      private string[] T005B15_A1306MVLConCajCue ;
      private short[] T005B16_A1312MVLCueCos ;
      private string[] T005B17_A397MVLCosCod ;
      private bool[] T005B17_n397MVLCosCod ;
      private string[] T005B18_A1356MVLPrvDsc ;
      private string[] T005B19_A1314MVLCueDsc ;
      private short[] T005B19_A1313MVLCueCosCod ;
      private int[] T005B20_A394MVLMonCod ;
      private string[] T005B21_A398MVLComCosCod ;
      private bool[] T005B21_n398MVLComCosCod ;
      private int[] T005B22_A393MVLForCod ;
      private bool[] T005B22_n393MVLForCod ;
      private int[] T005B23_A358CajCod ;
      private string[] T005B23_A391MVLCajCod ;
      private int[] T005B23_A392MVLITem ;
      private string[] T005B3_A391MVLCajCod ;
      private int[] T005B3_A392MVLITem ;
      private DateTime[] T005B3_A1295MVLCajFec ;
      private string[] T005B3_A1293MVLCajDoc ;
      private string[] T005B3_A1292MVLCajConc ;
      private string[] T005B3_A1311MVLCueCodAux ;
      private string[] T005B3_A1310MVLCueAuxCod ;
      private decimal[] T005B3_A1296MVLCajImp ;
      private string[] T005B3_A1361MVLTipo ;
      private string[] T005B3_A1299MVLCajTCod ;
      private string[] T005B3_A1294MVLCajDocP ;
      private string[] T005B3_A1297MVLCajReg ;
      private decimal[] T005B3_A1298MVLCajTCmb ;
      private DateTime[] T005B3_A1302MVLComFec ;
      private DateTime[] T005B3_A1303MVLComFReg ;
      private decimal[] T005B3_A1358MVLSubAfecto ;
      private decimal[] T005B3_A1359MVLSubInafecto ;
      private decimal[] T005B3_A1354MVLIGV ;
      private decimal[] T005B3_A1362MVLTotal ;
      private decimal[] T005B3_A1363MVLTotalPago ;
      private short[] T005B3_A1366MVLVouAno ;
      private short[] T005B3_A1367MVLVouMes ;
      private int[] T005B3_A1360MVLTASICod ;
      private string[] T005B3_A1368MVLVouNum ;
      private string[] T005B3_A1300MVLComAux ;
      private string[] T005B3_A1301MVLComCueCod ;
      private long[] T005B3_A1355MVLPagReg ;
      private decimal[] T005B3_A1357MVLRedondeo ;
      private decimal[] T005B3_A1304MVLComPorIVA ;
      private string[] T005B3_A1364MVLUsuCod ;
      private DateTime[] T005B3_A1365MVLUsuFec ;
      private string[] T005B3_A1305MVLComTipReg ;
      private int[] T005B3_A358CajCod ;
      private int[] T005B3_A399MVLConcCajCod ;
      private string[] T005B3_A397MVLCosCod ;
      private bool[] T005B3_n397MVLCosCod ;
      private string[] T005B3_A398MVLComCosCod ;
      private bool[] T005B3_n398MVLComCosCod ;
      private string[] T005B3_A396MVLPrvCod ;
      private string[] T005B3_A395MVLCueCod ;
      private int[] T005B3_A394MVLMonCod ;
      private int[] T005B3_A393MVLForCod ;
      private bool[] T005B3_n393MVLForCod ;
      private int[] T005B24_A358CajCod ;
      private string[] T005B24_A391MVLCajCod ;
      private int[] T005B24_A392MVLITem ;
      private int[] T005B25_A358CajCod ;
      private string[] T005B25_A391MVLCajCod ;
      private int[] T005B25_A392MVLITem ;
      private string[] T005B2_A391MVLCajCod ;
      private int[] T005B2_A392MVLITem ;
      private DateTime[] T005B2_A1295MVLCajFec ;
      private string[] T005B2_A1293MVLCajDoc ;
      private string[] T005B2_A1292MVLCajConc ;
      private string[] T005B2_A1311MVLCueCodAux ;
      private string[] T005B2_A1310MVLCueAuxCod ;
      private decimal[] T005B2_A1296MVLCajImp ;
      private string[] T005B2_A1361MVLTipo ;
      private string[] T005B2_A1299MVLCajTCod ;
      private string[] T005B2_A1294MVLCajDocP ;
      private string[] T005B2_A1297MVLCajReg ;
      private decimal[] T005B2_A1298MVLCajTCmb ;
      private DateTime[] T005B2_A1302MVLComFec ;
      private DateTime[] T005B2_A1303MVLComFReg ;
      private decimal[] T005B2_A1358MVLSubAfecto ;
      private decimal[] T005B2_A1359MVLSubInafecto ;
      private decimal[] T005B2_A1354MVLIGV ;
      private decimal[] T005B2_A1362MVLTotal ;
      private decimal[] T005B2_A1363MVLTotalPago ;
      private short[] T005B2_A1366MVLVouAno ;
      private short[] T005B2_A1367MVLVouMes ;
      private int[] T005B2_A1360MVLTASICod ;
      private string[] T005B2_A1368MVLVouNum ;
      private string[] T005B2_A1300MVLComAux ;
      private string[] T005B2_A1301MVLComCueCod ;
      private long[] T005B2_A1355MVLPagReg ;
      private decimal[] T005B2_A1357MVLRedondeo ;
      private decimal[] T005B2_A1304MVLComPorIVA ;
      private string[] T005B2_A1364MVLUsuCod ;
      private DateTime[] T005B2_A1365MVLUsuFec ;
      private string[] T005B2_A1305MVLComTipReg ;
      private int[] T005B2_A358CajCod ;
      private int[] T005B2_A399MVLConcCajCod ;
      private string[] T005B2_A397MVLCosCod ;
      private bool[] T005B2_n397MVLCosCod ;
      private string[] T005B2_A398MVLComCosCod ;
      private bool[] T005B2_n398MVLComCosCod ;
      private string[] T005B2_A396MVLPrvCod ;
      private string[] T005B2_A395MVLCueCod ;
      private int[] T005B2_A394MVLMonCod ;
      private int[] T005B2_A393MVLForCod ;
      private bool[] T005B2_n393MVLForCod ;
      private string[] T005B29_A1307MVLConCajDsc ;
      private string[] T005B29_A1306MVLConCajCue ;
      private short[] T005B30_A1312MVLCueCos ;
      private string[] T005B31_A1356MVLPrvDsc ;
      private string[] T005B32_A1314MVLCueDsc ;
      private short[] T005B32_A1313MVLCueCosCod ;
      private int[] T005B33_A358CajCod ;
      private string[] T005B33_A391MVLCajCod ;
      private int[] T005B33_A392MVLITem ;
      private int[] T005B34_A358CajCod ;
      private string[] T005B35_A397MVLCosCod ;
      private bool[] T005B35_n397MVLCosCod ;
      private int[] T005B36_A394MVLMonCod ;
      private string[] T005B37_A398MVLComCosCod ;
      private bool[] T005B37_n398MVLComCosCod ;
      private int[] T005B38_A393MVLForCod ;
      private bool[] T005B38_n393MVLForCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsmovcajachica__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsmovcajachica__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new UpdateCursor(def[24])
       ,new UpdateCursor(def[25])
       ,new UpdateCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005B13;
        prmT005B13 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B4;
        prmT005B4 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005B5;
        prmT005B5 = new Object[] {
        new ParDef("@MVLConcCajCod",GXType.Int32,6,0)
        };
        Object[] prmT005B12;
        prmT005B12 = new Object[] {
        new ParDef("@MVLConCajCue",GXType.NChar,15,0)
        };
        Object[] prmT005B6;
        prmT005B6 = new Object[] {
        new ParDef("@MVLCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005B8;
        prmT005B8 = new Object[] {
        new ParDef("@MVLPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005B9;
        prmT005B9 = new Object[] {
        new ParDef("@MVLCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005B10;
        prmT005B10 = new Object[] {
        new ParDef("@MVLMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005B7;
        prmT005B7 = new Object[] {
        new ParDef("@MVLComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005B11;
        prmT005B11 = new Object[] {
        new ParDef("@MVLForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005B14;
        prmT005B14 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005B15;
        prmT005B15 = new Object[] {
        new ParDef("@MVLConcCajCod",GXType.Int32,6,0)
        };
        Object[] prmT005B16;
        prmT005B16 = new Object[] {
        new ParDef("@MVLConCajCue",GXType.NChar,15,0)
        };
        Object[] prmT005B17;
        prmT005B17 = new Object[] {
        new ParDef("@MVLCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005B18;
        prmT005B18 = new Object[] {
        new ParDef("@MVLPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005B19;
        prmT005B19 = new Object[] {
        new ParDef("@MVLCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005B20;
        prmT005B20 = new Object[] {
        new ParDef("@MVLMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005B21;
        prmT005B21 = new Object[] {
        new ParDef("@MVLComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005B22;
        prmT005B22 = new Object[] {
        new ParDef("@MVLForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005B23;
        prmT005B23 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B3;
        prmT005B3 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B24;
        prmT005B24 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B25;
        prmT005B25 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B2;
        prmT005B2 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B26;
        prmT005B26 = new Object[] {
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0) ,
        new ParDef("@MVLCajFec",GXType.Date,8,0) ,
        new ParDef("@MVLCajDoc",GXType.NChar,20,0) ,
        new ParDef("@MVLCajConc",GXType.NChar,100,0) ,
        new ParDef("@MVLCueCodAux",GXType.NChar,15,0) ,
        new ParDef("@MVLCueAuxCod",GXType.NChar,20,0) ,
        new ParDef("@MVLCajImp",GXType.Decimal,15,2) ,
        new ParDef("@MVLTipo",GXType.NChar,3,0) ,
        new ParDef("@MVLCajTCod",GXType.NChar,3,0) ,
        new ParDef("@MVLCajDocP",GXType.NChar,15,0) ,
        new ParDef("@MVLCajReg",GXType.NChar,10,0) ,
        new ParDef("@MVLCajTCmb",GXType.Decimal,10,4) ,
        new ParDef("@MVLComFec",GXType.Date,8,0) ,
        new ParDef("@MVLComFReg",GXType.Date,8,0) ,
        new ParDef("@MVLSubAfecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLSubInafecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLIGV",GXType.Decimal,15,2) ,
        new ParDef("@MVLTotal",GXType.Decimal,15,2) ,
        new ParDef("@MVLTotalPago",GXType.Decimal,15,2) ,
        new ParDef("@MVLVouAno",GXType.Int16,4,0) ,
        new ParDef("@MVLVouMes",GXType.Int16,2,0) ,
        new ParDef("@MVLTASICod",GXType.Int32,6,0) ,
        new ParDef("@MVLVouNum",GXType.NChar,10,0) ,
        new ParDef("@MVLComAux",GXType.NChar,20,0) ,
        new ParDef("@MVLComCueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLPagReg",GXType.Decimal,10,0) ,
        new ParDef("@MVLRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@MVLComPorIVA",GXType.Decimal,15,2) ,
        new ParDef("@MVLUsuCod",GXType.NChar,10,0) ,
        new ParDef("@MVLUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@MVLComTipReg",GXType.NChar,1,0) ,
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLConcCajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLComCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLPrvCod",GXType.NChar,20,0) ,
        new ParDef("@MVLCueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLMonCod",GXType.Int32,6,0) ,
        new ParDef("@MVLForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005B27;
        prmT005B27 = new Object[] {
        new ParDef("@MVLCajFec",GXType.Date,8,0) ,
        new ParDef("@MVLCajDoc",GXType.NChar,20,0) ,
        new ParDef("@MVLCajConc",GXType.NChar,100,0) ,
        new ParDef("@MVLCueCodAux",GXType.NChar,15,0) ,
        new ParDef("@MVLCueAuxCod",GXType.NChar,20,0) ,
        new ParDef("@MVLCajImp",GXType.Decimal,15,2) ,
        new ParDef("@MVLTipo",GXType.NChar,3,0) ,
        new ParDef("@MVLCajTCod",GXType.NChar,3,0) ,
        new ParDef("@MVLCajDocP",GXType.NChar,15,0) ,
        new ParDef("@MVLCajReg",GXType.NChar,10,0) ,
        new ParDef("@MVLCajTCmb",GXType.Decimal,10,4) ,
        new ParDef("@MVLComFec",GXType.Date,8,0) ,
        new ParDef("@MVLComFReg",GXType.Date,8,0) ,
        new ParDef("@MVLSubAfecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLSubInafecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLIGV",GXType.Decimal,15,2) ,
        new ParDef("@MVLTotal",GXType.Decimal,15,2) ,
        new ParDef("@MVLTotalPago",GXType.Decimal,15,2) ,
        new ParDef("@MVLVouAno",GXType.Int16,4,0) ,
        new ParDef("@MVLVouMes",GXType.Int16,2,0) ,
        new ParDef("@MVLTASICod",GXType.Int32,6,0) ,
        new ParDef("@MVLVouNum",GXType.NChar,10,0) ,
        new ParDef("@MVLComAux",GXType.NChar,20,0) ,
        new ParDef("@MVLComCueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLPagReg",GXType.Decimal,10,0) ,
        new ParDef("@MVLRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@MVLComPorIVA",GXType.Decimal,15,2) ,
        new ParDef("@MVLUsuCod",GXType.NChar,10,0) ,
        new ParDef("@MVLUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@MVLComTipReg",GXType.NChar,1,0) ,
        new ParDef("@MVLConcCajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLComCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLPrvCod",GXType.NChar,20,0) ,
        new ParDef("@MVLCueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLMonCod",GXType.Int32,6,0) ,
        new ParDef("@MVLForCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B28;
        prmT005B28 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0) ,
        new ParDef("@MVLCajCod",GXType.NChar,10,0) ,
        new ParDef("@MVLITem",GXType.Int32,6,0)
        };
        Object[] prmT005B33;
        prmT005B33 = new Object[] {
        };
        Object[] prmT005B34;
        prmT005B34 = new Object[] {
        new ParDef("@CajCod",GXType.Int32,6,0)
        };
        Object[] prmT005B29;
        prmT005B29 = new Object[] {
        new ParDef("@MVLConcCajCod",GXType.Int32,6,0)
        };
        Object[] prmT005B30;
        prmT005B30 = new Object[] {
        new ParDef("@MVLConCajCue",GXType.NChar,15,0)
        };
        Object[] prmT005B35;
        prmT005B35 = new Object[] {
        new ParDef("@MVLCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005B31;
        prmT005B31 = new Object[] {
        new ParDef("@MVLPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005B32;
        prmT005B32 = new Object[] {
        new ParDef("@MVLCueCod",GXType.NChar,15,0)
        };
        Object[] prmT005B36;
        prmT005B36 = new Object[] {
        new ParDef("@MVLMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005B37;
        prmT005B37 = new Object[] {
        new ParDef("@MVLComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005B38;
        prmT005B38 = new Object[] {
        new ParDef("@MVLForCod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T005B2", "SELECT [MVLCajCod], [MVLITem], [MVLCajFec], [MVLCajDoc], [MVLCajConc], [MVLCueCodAux], [MVLCueAuxCod], [MVLCajImp], [MVLTipo], [MVLCajTCod], [MVLCajDocP], [MVLCajReg], [MVLCajTCmb], [MVLComFec], [MVLComFReg], [MVLSubAfecto], [MVLSubInafecto], [MVLIGV], [MVLTotal], [MVLTotalPago], [MVLVouAno], [MVLVouMes], [MVLTASICod], [MVLVouNum], [MVLComAux], [MVLComCueCod], [MVLPagReg], [MVLRedondeo], [MVLComPorIVA], [MVLUsuCod], [MVLUsuFec], [MVLComTipReg], [CajCod], [MVLConcCajCod] AS MVLConcCajCod, [MVLCosCod] AS MVLCosCod, [MVLComCosCod] AS MVLComCosCod, [MVLPrvCod] AS MVLPrvCod, [MVLCueCod] AS MVLCueCod, [MVLMonCod] AS MVLMonCod, [MVLForCod] AS MVLForCod FROM [TSMOVCAJACHICA] WITH (UPDLOCK) WHERE [CajCod] = @CajCod AND [MVLCajCod] = @MVLCajCod AND [MVLITem] = @MVLITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B3", "SELECT [MVLCajCod], [MVLITem], [MVLCajFec], [MVLCajDoc], [MVLCajConc], [MVLCueCodAux], [MVLCueAuxCod], [MVLCajImp], [MVLTipo], [MVLCajTCod], [MVLCajDocP], [MVLCajReg], [MVLCajTCmb], [MVLComFec], [MVLComFReg], [MVLSubAfecto], [MVLSubInafecto], [MVLIGV], [MVLTotal], [MVLTotalPago], [MVLVouAno], [MVLVouMes], [MVLTASICod], [MVLVouNum], [MVLComAux], [MVLComCueCod], [MVLPagReg], [MVLRedondeo], [MVLComPorIVA], [MVLUsuCod], [MVLUsuFec], [MVLComTipReg], [CajCod], [MVLConcCajCod] AS MVLConcCajCod, [MVLCosCod] AS MVLCosCod, [MVLComCosCod] AS MVLComCosCod, [MVLPrvCod] AS MVLPrvCod, [MVLCueCod] AS MVLCueCod, [MVLMonCod] AS MVLMonCod, [MVLForCod] AS MVLForCod FROM [TSMOVCAJACHICA] WHERE [CajCod] = @CajCod AND [MVLCajCod] = @MVLCajCod AND [MVLITem] = @MVLITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B4", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B5", "SELECT [ConCajDsc] AS MVLConCajDsc, [CueCod] AS MVLConCajCue FROM [TSCONCEPTOCAJA] WHERE [ConCajCod] = @MVLConcCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B6", "SELECT [COSCod] AS MVLCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B7", "SELECT [COSCod] AS MVLComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B8", "SELECT [PrvDsc] AS MVLPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @MVLPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B9", "SELECT [CueDsc] AS MVLCueDsc, [CueCos] AS MVLCueCosCod FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B10", "SELECT [MonCod] AS MVLMonCod FROM [CMONEDAS] WHERE [MonCod] = @MVLMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B11", "SELECT [ForCod] AS MVLForCod FROM [CFORMAPAGO] WHERE [ForCod] = @MVLForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B12", "SELECT [CueCos] AS MVLCueCos FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLConCajCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B13", "SELECT TM1.[MVLCajCod], TM1.[MVLITem], TM1.[MVLCajFec], TM1.[MVLCajDoc], TM1.[MVLCajConc], TM1.[MVLCueCodAux], TM1.[MVLCueAuxCod], TM1.[MVLCajImp], TM1.[MVLTipo], TM1.[MVLCajTCod], TM1.[MVLCajDocP], TM1.[MVLCajReg], TM1.[MVLCajTCmb], TM1.[MVLComFec], TM1.[MVLComFReg], TM1.[MVLSubAfecto], TM1.[MVLSubInafecto], TM1.[MVLIGV], TM1.[MVLTotal], TM1.[MVLTotalPago], TM1.[MVLVouAno], TM1.[MVLVouMes], TM1.[MVLTASICod], TM1.[MVLVouNum], TM1.[MVLComAux], TM1.[MVLComCueCod], TM1.[MVLPagReg], TM1.[MVLRedondeo], TM1.[MVLComPorIVA], TM1.[MVLUsuCod], TM1.[MVLUsuFec], TM1.[MVLComTipReg], T2.[ConCajDsc] AS MVLConCajDsc, T3.[CueCos] AS MVLCueCos, T4.[PrvDsc] AS MVLPrvDsc, T5.[CueDsc] AS MVLCueDsc, T5.[CueCos] AS MVLCueCosCod, TM1.[CajCod], TM1.[MVLConcCajCod] AS MVLConcCajCod, TM1.[MVLCosCod] AS MVLCosCod, TM1.[MVLComCosCod] AS MVLComCosCod, TM1.[MVLPrvCod] AS MVLPrvCod, TM1.[MVLCueCod] AS MVLCueCod, TM1.[MVLMonCod] AS MVLMonCod, TM1.[MVLForCod] AS MVLForCod, T2.[CueCod] AS MVLConCajCue FROM (((([TSMOVCAJACHICA] TM1 INNER JOIN [TSCONCEPTOCAJA] T2 ON T2.[ConCajCod] = TM1.[MVLConcCajCod]) INNER JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T2.[CueCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = TM1.[MVLPrvCod]) INNER JOIN [CBPLANCUENTA] T5 ON T5.[CueCod] = TM1.[MVLCueCod]) WHERE TM1.[CajCod] = @CajCod and TM1.[MVLCajCod] = @MVLCajCod and TM1.[MVLITem] = @MVLITem ORDER BY TM1.[CajCod], TM1.[MVLCajCod], TM1.[MVLITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005B13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B14", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B15", "SELECT [ConCajDsc] AS MVLConCajDsc, [CueCod] AS MVLConCajCue FROM [TSCONCEPTOCAJA] WHERE [ConCajCod] = @MVLConcCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B16", "SELECT [CueCos] AS MVLCueCos FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLConCajCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B17", "SELECT [COSCod] AS MVLCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B18", "SELECT [PrvDsc] AS MVLPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @MVLPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B19", "SELECT [CueDsc] AS MVLCueDsc, [CueCos] AS MVLCueCosCod FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B20", "SELECT [MonCod] AS MVLMonCod FROM [CMONEDAS] WHERE [MonCod] = @MVLMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B21", "SELECT [COSCod] AS MVLComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B22", "SELECT [ForCod] AS MVLForCod FROM [CFORMAPAGO] WHERE [ForCod] = @MVLForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B23", "SELECT [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [CajCod] = @CajCod AND [MVLCajCod] = @MVLCajCod AND [MVLITem] = @MVLITem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005B23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B24", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE ( [CajCod] > @CajCod or [CajCod] = @CajCod and [MVLCajCod] > @MVLCajCod or [MVLCajCod] = @MVLCajCod and [CajCod] = @CajCod and [MVLITem] > @MVLITem) ORDER BY [CajCod], [MVLCajCod], [MVLITem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005B24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005B25", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE ( [CajCod] < @CajCod or [CajCod] = @CajCod and [MVLCajCod] < @MVLCajCod or [MVLCajCod] = @MVLCajCod and [CajCod] = @CajCod and [MVLITem] < @MVLITem) ORDER BY [CajCod] DESC, [MVLCajCod] DESC, [MVLITem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005B25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005B26", "INSERT INTO [TSMOVCAJACHICA]([MVLCajCod], [MVLITem], [MVLCajFec], [MVLCajDoc], [MVLCajConc], [MVLCueCodAux], [MVLCueAuxCod], [MVLCajImp], [MVLTipo], [MVLCajTCod], [MVLCajDocP], [MVLCajReg], [MVLCajTCmb], [MVLComFec], [MVLComFReg], [MVLSubAfecto], [MVLSubInafecto], [MVLIGV], [MVLTotal], [MVLTotalPago], [MVLVouAno], [MVLVouMes], [MVLTASICod], [MVLVouNum], [MVLComAux], [MVLComCueCod], [MVLPagReg], [MVLRedondeo], [MVLComPorIVA], [MVLUsuCod], [MVLUsuFec], [MVLComTipReg], [CajCod], [MVLConcCajCod], [MVLCosCod], [MVLComCosCod], [MVLPrvCod], [MVLCueCod], [MVLMonCod], [MVLForCod]) VALUES(@MVLCajCod, @MVLITem, @MVLCajFec, @MVLCajDoc, @MVLCajConc, @MVLCueCodAux, @MVLCueAuxCod, @MVLCajImp, @MVLTipo, @MVLCajTCod, @MVLCajDocP, @MVLCajReg, @MVLCajTCmb, @MVLComFec, @MVLComFReg, @MVLSubAfecto, @MVLSubInafecto, @MVLIGV, @MVLTotal, @MVLTotalPago, @MVLVouAno, @MVLVouMes, @MVLTASICod, @MVLVouNum, @MVLComAux, @MVLComCueCod, @MVLPagReg, @MVLRedondeo, @MVLComPorIVA, @MVLUsuCod, @MVLUsuFec, @MVLComTipReg, @CajCod, @MVLConcCajCod, @MVLCosCod, @MVLComCosCod, @MVLPrvCod, @MVLCueCod, @MVLMonCod, @MVLForCod)", GxErrorMask.GX_NOMASK,prmT005B26)
           ,new CursorDef("T005B27", "UPDATE [TSMOVCAJACHICA] SET [MVLCajFec]=@MVLCajFec, [MVLCajDoc]=@MVLCajDoc, [MVLCajConc]=@MVLCajConc, [MVLCueCodAux]=@MVLCueCodAux, [MVLCueAuxCod]=@MVLCueAuxCod, [MVLCajImp]=@MVLCajImp, [MVLTipo]=@MVLTipo, [MVLCajTCod]=@MVLCajTCod, [MVLCajDocP]=@MVLCajDocP, [MVLCajReg]=@MVLCajReg, [MVLCajTCmb]=@MVLCajTCmb, [MVLComFec]=@MVLComFec, [MVLComFReg]=@MVLComFReg, [MVLSubAfecto]=@MVLSubAfecto, [MVLSubInafecto]=@MVLSubInafecto, [MVLIGV]=@MVLIGV, [MVLTotal]=@MVLTotal, [MVLTotalPago]=@MVLTotalPago, [MVLVouAno]=@MVLVouAno, [MVLVouMes]=@MVLVouMes, [MVLTASICod]=@MVLTASICod, [MVLVouNum]=@MVLVouNum, [MVLComAux]=@MVLComAux, [MVLComCueCod]=@MVLComCueCod, [MVLPagReg]=@MVLPagReg, [MVLRedondeo]=@MVLRedondeo, [MVLComPorIVA]=@MVLComPorIVA, [MVLUsuCod]=@MVLUsuCod, [MVLUsuFec]=@MVLUsuFec, [MVLComTipReg]=@MVLComTipReg, [MVLConcCajCod]=@MVLConcCajCod, [MVLCosCod]=@MVLCosCod, [MVLComCosCod]=@MVLComCosCod, [MVLPrvCod]=@MVLPrvCod, [MVLCueCod]=@MVLCueCod, [MVLMonCod]=@MVLMonCod, [MVLForCod]=@MVLForCod  WHERE [CajCod] = @CajCod AND [MVLCajCod] = @MVLCajCod AND [MVLITem] = @MVLITem", GxErrorMask.GX_NOMASK,prmT005B27)
           ,new CursorDef("T005B28", "DELETE FROM [TSMOVCAJACHICA]  WHERE [CajCod] = @CajCod AND [MVLCajCod] = @MVLCajCod AND [MVLITem] = @MVLITem", GxErrorMask.GX_NOMASK,prmT005B28)
           ,new CursorDef("T005B29", "SELECT [ConCajDsc] AS MVLConCajDsc, [CueCod] AS MVLConCajCue FROM [TSCONCEPTOCAJA] WHERE [ConCajCod] = @MVLConcCajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B30", "SELECT [CueCos] AS MVLCueCos FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLConCajCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B31", "SELECT [PrvDsc] AS MVLPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @MVLPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B32", "SELECT [CueDsc] AS MVLCueDsc, [CueCos] AS MVLCueCosCod FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B33", "SELECT [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] ORDER BY [CajCod], [MVLCajCod], [MVLITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005B33,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B34", "SELECT [CajCod] FROM [TSCAJACHICA] WHERE [CajCod] = @CajCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B35", "SELECT [COSCod] AS MVLCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B36", "SELECT [MonCod] AS MVLMonCod FROM [CMONEDAS] WHERE [MonCod] = @MVLMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B37", "SELECT [COSCod] AS MVLComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005B38", "SELECT [ForCod] AS MVLForCod FROM [CFORMAPAGO] WHERE [ForCod] = @MVLForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005B38,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((short[]) buf[20])[0] = rslt.getShort(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((string[]) buf[24])[0] = rslt.getString(25, 20);
              ((string[]) buf[25])[0] = rslt.getString(26, 15);
              ((long[]) buf[26])[0] = rslt.getLong(27);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getString(32, 1);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((string[]) buf[34])[0] = rslt.getString(35, 10);
              ((bool[]) buf[35])[0] = rslt.wasNull(35);
              ((string[]) buf[36])[0] = rslt.getString(36, 10);
              ((bool[]) buf[37])[0] = rslt.wasNull(36);
              ((string[]) buf[38])[0] = rslt.getString(37, 20);
              ((string[]) buf[39])[0] = rslt.getString(38, 15);
              ((int[]) buf[40])[0] = rslt.getInt(39);
              ((int[]) buf[41])[0] = rslt.getInt(40);
              ((bool[]) buf[42])[0] = rslt.wasNull(40);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((short[]) buf[20])[0] = rslt.getShort(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((string[]) buf[24])[0] = rslt.getString(25, 20);
              ((string[]) buf[25])[0] = rslt.getString(26, 15);
              ((long[]) buf[26])[0] = rslt.getLong(27);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getString(32, 1);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((int[]) buf[33])[0] = rslt.getInt(34);
              ((string[]) buf[34])[0] = rslt.getString(35, 10);
              ((bool[]) buf[35])[0] = rslt.wasNull(35);
              ((string[]) buf[36])[0] = rslt.getString(36, 10);
              ((bool[]) buf[37])[0] = rslt.wasNull(36);
              ((string[]) buf[38])[0] = rslt.getString(37, 20);
              ((string[]) buf[39])[0] = rslt.getString(38, 15);
              ((int[]) buf[40])[0] = rslt.getInt(39);
              ((int[]) buf[41])[0] = rslt.getInt(40);
              ((bool[]) buf[42])[0] = rslt.wasNull(40);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 100);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((string[]) buf[6])[0] = rslt.getString(7, 20);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((string[]) buf[8])[0] = rslt.getString(9, 3);
              ((string[]) buf[9])[0] = rslt.getString(10, 3);
              ((string[]) buf[10])[0] = rslt.getString(11, 15);
              ((string[]) buf[11])[0] = rslt.getString(12, 10);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(13);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
              ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((decimal[]) buf[16])[0] = rslt.getDecimal(17);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((short[]) buf[20])[0] = rslt.getShort(21);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((string[]) buf[24])[0] = rslt.getString(25, 20);
              ((string[]) buf[25])[0] = rslt.getString(26, 15);
              ((long[]) buf[26])[0] = rslt.getLong(27);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getString(32, 1);
              ((string[]) buf[32])[0] = rslt.getString(33, 100);
              ((short[]) buf[33])[0] = rslt.getShort(34);
              ((string[]) buf[34])[0] = rslt.getString(35, 100);
              ((string[]) buf[35])[0] = rslt.getString(36, 100);
              ((short[]) buf[36])[0] = rslt.getShort(37);
              ((int[]) buf[37])[0] = rslt.getInt(38);
              ((int[]) buf[38])[0] = rslt.getInt(39);
              ((string[]) buf[39])[0] = rslt.getString(40, 10);
              ((bool[]) buf[40])[0] = rslt.wasNull(40);
              ((string[]) buf[41])[0] = rslt.getString(41, 10);
              ((bool[]) buf[42])[0] = rslt.wasNull(41);
              ((string[]) buf[43])[0] = rslt.getString(42, 20);
              ((string[]) buf[44])[0] = rslt.getString(43, 15);
              ((int[]) buf[45])[0] = rslt.getInt(44);
              ((int[]) buf[46])[0] = rslt.getInt(45);
              ((bool[]) buf[47])[0] = rslt.wasNull(45);
              ((string[]) buf[48])[0] = rslt.getString(46, 15);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 14 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 22 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 23 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 28 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 31 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 32 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 34 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 36 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
