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
   public class tsmoventrega : GXDataArea
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
            A365EntCod = (int)(NumberUtil.Val( GetPar( "EntCod"), "."));
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A365EntCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A411MVLConcEntCod = (int)(NumberUtil.Val( GetPar( "MVLConcEntCod"), "."));
            AssignAttri("", false, "A411MVLConcEntCod", StringUtil.LTrimStr( (decimal)(A411MVLConcEntCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A411MVLConcEntCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A1308MVLConEntCue = GetPar( "MVLConEntCue");
            AssignAttri("", false, "A1308MVLConEntCue", A1308MVLConEntCue);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A1308MVLConEntCue) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A409MVLECosCod = GetPar( "MVLECosCod");
            n409MVLECosCod = false;
            AssignAttri("", false, "A409MVLECosCod", A409MVLECosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A409MVLECosCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A408MVLEPrvCod = GetPar( "MVLEPrvCod");
            AssignAttri("", false, "A408MVLEPrvCod", A408MVLEPrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A408MVLEPrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A407MVLECueCod = GetPar( "MVLECueCod");
            AssignAttri("", false, "A407MVLECueCod", A407MVLECueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A407MVLECueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A410MVLEComCosCod = GetPar( "MVLEComCosCod");
            n410MVLEComCosCod = false;
            AssignAttri("", false, "A410MVLEComCosCod", A410MVLEComCosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A410MVLEComCosCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A406MVLEForCod = (int)(NumberUtil.Val( GetPar( "MVLEForCod"), "."));
            n406MVLEForCod = false;
            AssignAttri("", false, "A406MVLEForCod", StringUtil.LTrimStr( (decimal)(A406MVLEForCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A406MVLEForCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A405MVLEMonCod = (int)(NumberUtil.Val( GetPar( "MVLEMonCod"), "."));
            AssignAttri("", false, "A405MVLEMonCod", StringUtil.LTrimStr( (decimal)(A405MVLEMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A405MVLEMonCod) ;
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
            Form.Meta.addItem("description", "Movimientos de Entrega a Rendir", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tsmoventrega( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tsmoventrega( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_TSMOVENTREGA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEntCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A365EntCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtEntCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A365EntCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEntCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Entrega", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntCod_Internalname, StringUtil.RTrim( A403MVLEntCod), StringUtil.RTrim( context.localUtil.Format( A403MVLEntCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEITem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A404MVLEITem), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLEITem_Enabled!=0) ? context.localUtil.Format( (decimal)(A404MVLEITem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A404MVLEITem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEITem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEITem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLEntFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLEntFec_Internalname, context.localUtil.Format(A1335MVLEntFec, "99/99/99"), context.localUtil.Format( A1335MVLEntFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         GxWebStd.gx_bitmap( context, edtMVLEntFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLEntFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "N° Documento", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntDoc_Internalname, StringUtil.RTrim( A1333MVLEntDoc), StringUtil.RTrim( context.localUtil.Format( A1333MVLEntDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Concepto", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntConc_Internalname, StringUtil.RTrim( A1332MVLEntConc), StringUtil.RTrim( context.localUtil.Format( A1332MVLEntConc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntConc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntConc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Codigo Concepto de Caja", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLConcEntCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A411MVLConcEntCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLConcEntCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A411MVLConcEntCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A411MVLConcEntCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLConcEntCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLConcEntCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cuenta", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLECueCodAux_Internalname, StringUtil.RTrim( A1322MVLECueCodAux), StringUtil.RTrim( context.localUtil.Format( A1322MVLECueCodAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLECueCodAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLECueCodAux_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Auxiliar", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLECueAuxCod_Internalname, StringUtil.RTrim( A1321MVLECueAuxCod), StringUtil.RTrim( context.localUtil.Format( A1321MVLECueAuxCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLECueAuxCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLECueAuxCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Centro de Costo", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLECosCod_Internalname, StringUtil.RTrim( A409MVLECosCod), StringUtil.RTrim( context.localUtil.Format( A409MVLECosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLECosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLECosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Importe", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A1336MVLEntImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLEntImp_Enabled!=0) ? context.localUtil.Format( A1336MVLEntImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1336MVLEntImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Tipo Movimiento", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLETipo_Internalname, StringUtil.RTrim( A1346MVLETipo), StringUtil.RTrim( context.localUtil.Format( A1346MVLETipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLETipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLETipo_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "R.U.C", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEPrvCod_Internalname, StringUtil.RTrim( A408MVLEPrvCod), StringUtil.RTrim( context.localUtil.Format( A408MVLEPrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "T. Documento", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntTCod_Internalname, StringUtil.RTrim( A1339MVLEntTCod), StringUtil.RTrim( context.localUtil.Format( A1339MVLEntTCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntTCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntTCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Documento", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntDocP_Internalname, StringUtil.RTrim( A1334MVLEntDocP), StringUtil.RTrim( context.localUtil.Format( A1334MVLEntDocP, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntDocP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntDocP_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Registro", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntReg_Internalname, StringUtil.RTrim( A1337MVLEntReg), StringUtil.RTrim( context.localUtil.Format( A1337MVLEntReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Tipo Cambio", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEntTCmb_Internalname, StringUtil.LTrim( StringUtil.NToC( A1338MVLEntTCmb, 10, 4, ".", "")), StringUtil.LTrim( ((edtMVLEntTCmb_Enabled!=0) ? context.localUtil.Format( A1338MVLEntTCmb, "ZZZZ9.9999") : context.localUtil.Format( A1338MVLEntTCmb, "ZZZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEntTCmb_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEntTCmb_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Fecha", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLEComFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLEComFec_Internalname, context.localUtil.Format(A1317MVLEComFec, "99/99/99"), context.localUtil.Format( A1317MVLEComFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEComFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEComFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         GxWebStd.gx_bitmap( context, edtMVLEComFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLEComFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Fecha Registro", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLEComFReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLEComFReg_Internalname, context.localUtil.Format(A1318MVLEComFReg, "99/99/99"), context.localUtil.Format( A1318MVLEComFReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEComFReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEComFReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         GxWebStd.gx_bitmap( context, edtMVLEComFReg_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLEComFReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Cuenta Compras", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLECueCod_Internalname, StringUtil.RTrim( A407MVLECueCod), StringUtil.RTrim( context.localUtil.Format( A407MVLECueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLECueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLECueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "C.Costos", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEComCosCod_Internalname, StringUtil.RTrim( A410MVLEComCosCod), StringUtil.RTrim( context.localUtil.Format( A410MVLEComCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEComCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEComCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Cuenta Auxiliar", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEComCueCod_Internalname, StringUtil.RTrim( A1316MVLEComCueCod), StringUtil.RTrim( context.localUtil.Format( A1316MVLEComCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEComCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEComCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Auxiliar", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEComAux_Internalname, StringUtil.RTrim( A1315MVLEComAux), StringUtil.RTrim( context.localUtil.Format( A1315MVLEComAux, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEComAux_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEComAux_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Sub Afecto", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLESubAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1343MVLESubAfecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLESubAfecto_Enabled!=0) ? context.localUtil.Format( A1343MVLESubAfecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1343MVLESubAfecto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLESubAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLESubAfecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Sub Inafecto", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLESubInafecto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1344MVLESubInafecto, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLESubInafecto_Enabled!=0) ? context.localUtil.Format( A1344MVLESubInafecto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1344MVLESubInafecto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLESubInafecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLESubInafecto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "I.G.V.", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEIGV_Internalname, StringUtil.LTrim( StringUtil.NToC( A1326MVLEIGV, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLEIGV_Enabled!=0) ? context.localUtil.Format( A1326MVLEIGV, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1326MVLEIGV, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEIGV_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEIGV_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Total", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLETotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A1347MVLETotal, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLETotal_Enabled!=0) ? context.localUtil.Format( A1347MVLETotal, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1347MVLETotal, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLETotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLETotal_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Total Pago", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLETotalPago_Internalname, StringUtil.LTrim( StringUtil.NToC( A1348MVLETotalPago, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLETotalPago_Enabled!=0) ? context.localUtil.Format( A1348MVLETotalPago, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1348MVLETotalPago, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLETotalPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLETotalPago_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Forma de Pago", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A406MVLEForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLEForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A406MVLEForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A406MVLEForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Registro de Pagos", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEPagReg_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1340MVLEPagReg), 10, 0, ".", "")), StringUtil.LTrim( ((edtMVLEPagReg_Enabled!=0) ? context.localUtil.Format( (decimal)(A1340MVLEPagReg), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1340MVLEPagReg), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEPagReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEPagReg_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Año", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1351MVLEVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtMVLEVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1351MVLEVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1351MVLEVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Mes", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1352MVLEVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtMVLEVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1352MVLEVouMes), "Z9") : context.localUtil.Format( (decimal)(A1352MVLEVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Tipo Asiento", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLETASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1345MVLETASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLETASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1345MVLETASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1345MVLETASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLETASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLETASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "N° Asiento", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEVouNum_Internalname, StringUtil.RTrim( A1353MVLEVouNum), StringUtil.RTrim( context.localUtil.Format( A1353MVLEVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Moneda", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A405MVLEMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVLEMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A405MVLEMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A405MVLEMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Redondeo", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLERedondeo_Internalname, StringUtil.LTrim( StringUtil.NToC( A1342MVLERedondeo, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLERedondeo_Enabled!=0) ? context.localUtil.Format( A1342MVLERedondeo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1342MVLERedondeo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLERedondeo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLERedondeo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "% I.G.V.", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEComPorIVA_Internalname, StringUtil.LTrim( StringUtil.NToC( A1319MVLEComPorIVA, 17, 2, ".", "")), StringUtil.LTrim( ((edtMVLEComPorIVA_Enabled!=0) ? context.localUtil.Format( A1319MVLEComPorIVA, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A1319MVLEComPorIVA, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEComPorIVA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEComPorIVA_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "Usuario", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEUsuCod_Internalname, StringUtil.RTrim( A1349MVLEUsuCod), StringUtil.RTrim( context.localUtil.Format( A1349MVLEUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Usuario Fecha", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVLEUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVLEUsuFec_Internalname, context.localUtil.TToC( A1350MVLEUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1350MVLEUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         GxWebStd.gx_bitmap( context, edtMVLEUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVLEUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Tipo Registro de Compras", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVLEComTipReg_Internalname, StringUtil.RTrim( A1320MVLEComTipReg), StringUtil.RTrim( context.localUtil.Format( A1320MVLEComTipReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEComTipReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEComTipReg_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Centro de Costos", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLECueCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1323MVLECueCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtMVLECueCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A1323MVLECueCos), "9") : context.localUtil.Format( (decimal)(A1323MVLECueCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLECueCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLECueCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock42_Internalname, "Concepto de Caja", "", "", lblTextblock42_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLConEntDsc_Internalname, StringUtil.RTrim( A1309MVLConEntDsc), StringUtil.RTrim( context.localUtil.Format( A1309MVLConEntDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLConEntDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLConEntDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock43_Internalname, "Cuenta Contable", "", "", lblTextblock43_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLConEntCue_Internalname, StringUtil.RTrim( A1308MVLConEntCue), StringUtil.RTrim( context.localUtil.Format( A1308MVLConEntCue, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLConEntCue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLConEntCue_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock44_Internalname, "Proveedor", "", "", lblTextblock44_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLEPrvDsc_Internalname, StringUtil.RTrim( A1341MVLEPrvDsc), StringUtil.RTrim( context.localUtil.Format( A1341MVLEPrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLEPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLEPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock45_Internalname, "Cuenta", "", "", lblTextblock45_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLECueDsc_Internalname, StringUtil.RTrim( A1325MVLECueDsc), StringUtil.RTrim( context.localUtil.Format( A1325MVLECueDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLECueDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLECueDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock46_Internalname, "Maneja C.Costo", "", "", lblTextblock46_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_TSMOVENTREGA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVLECueCosCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1324MVLECueCosCod), 1, 0, ".", "")), StringUtil.LTrim( ((edtMVLECueCosCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1324MVLECueCosCod), "9") : context.localUtil.Format( (decimal)(A1324MVLECueCosCod), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVLECueCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVLECueCosCod_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_TSMOVENTREGA.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 250,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 252,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_TSMOVENTREGA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 253,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_TSMOVENTREGA.htm");
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
            Z365EntCod = (int)(context.localUtil.CToN( cgiGet( "Z365EntCod"), ".", ","));
            Z403MVLEntCod = cgiGet( "Z403MVLEntCod");
            Z404MVLEITem = (int)(context.localUtil.CToN( cgiGet( "Z404MVLEITem"), ".", ","));
            Z1335MVLEntFec = context.localUtil.CToD( cgiGet( "Z1335MVLEntFec"), 0);
            Z1333MVLEntDoc = cgiGet( "Z1333MVLEntDoc");
            Z1332MVLEntConc = cgiGet( "Z1332MVLEntConc");
            Z1322MVLECueCodAux = cgiGet( "Z1322MVLECueCodAux");
            Z1321MVLECueAuxCod = cgiGet( "Z1321MVLECueAuxCod");
            Z1336MVLEntImp = context.localUtil.CToN( cgiGet( "Z1336MVLEntImp"), ".", ",");
            Z1346MVLETipo = cgiGet( "Z1346MVLETipo");
            Z1339MVLEntTCod = cgiGet( "Z1339MVLEntTCod");
            Z1334MVLEntDocP = cgiGet( "Z1334MVLEntDocP");
            Z1337MVLEntReg = cgiGet( "Z1337MVLEntReg");
            Z1338MVLEntTCmb = context.localUtil.CToN( cgiGet( "Z1338MVLEntTCmb"), ".", ",");
            Z1317MVLEComFec = context.localUtil.CToD( cgiGet( "Z1317MVLEComFec"), 0);
            Z1318MVLEComFReg = context.localUtil.CToD( cgiGet( "Z1318MVLEComFReg"), 0);
            Z1316MVLEComCueCod = cgiGet( "Z1316MVLEComCueCod");
            Z1315MVLEComAux = cgiGet( "Z1315MVLEComAux");
            Z1343MVLESubAfecto = context.localUtil.CToN( cgiGet( "Z1343MVLESubAfecto"), ".", ",");
            Z1344MVLESubInafecto = context.localUtil.CToN( cgiGet( "Z1344MVLESubInafecto"), ".", ",");
            Z1326MVLEIGV = context.localUtil.CToN( cgiGet( "Z1326MVLEIGV"), ".", ",");
            Z1347MVLETotal = context.localUtil.CToN( cgiGet( "Z1347MVLETotal"), ".", ",");
            Z1348MVLETotalPago = context.localUtil.CToN( cgiGet( "Z1348MVLETotalPago"), ".", ",");
            Z1340MVLEPagReg = (long)(context.localUtil.CToN( cgiGet( "Z1340MVLEPagReg"), ".", ","));
            Z1351MVLEVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1351MVLEVouAno"), ".", ","));
            Z1352MVLEVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1352MVLEVouMes"), ".", ","));
            Z1345MVLETASICod = (int)(context.localUtil.CToN( cgiGet( "Z1345MVLETASICod"), ".", ","));
            Z1353MVLEVouNum = cgiGet( "Z1353MVLEVouNum");
            Z1342MVLERedondeo = context.localUtil.CToN( cgiGet( "Z1342MVLERedondeo"), ".", ",");
            Z1319MVLEComPorIVA = context.localUtil.CToN( cgiGet( "Z1319MVLEComPorIVA"), ".", ",");
            Z1349MVLEUsuCod = cgiGet( "Z1349MVLEUsuCod");
            Z1350MVLEUsuFec = context.localUtil.CToT( cgiGet( "Z1350MVLEUsuFec"), 0);
            Z1320MVLEComTipReg = cgiGet( "Z1320MVLEComTipReg");
            Z1327MVLEMBanCod = (int)(context.localUtil.CToN( cgiGet( "Z1327MVLEMBanCod"), ".", ","));
            Z1330MVLEMCtaBco = cgiGet( "Z1330MVLEMCtaBco");
            Z1329MVLEMBanReg = cgiGet( "Z1329MVLEMBanReg");
            Z1328MVLEMBanCon = (int)(context.localUtil.CToN( cgiGet( "Z1328MVLEMBanCon"), ".", ","));
            n1328MVLEMBanCon = ((0==A1328MVLEMBanCon) ? true : false);
            Z1331MVLEMTipo = cgiGet( "Z1331MVLEMTipo");
            Z411MVLConcEntCod = (int)(context.localUtil.CToN( cgiGet( "Z411MVLConcEntCod"), ".", ","));
            Z409MVLECosCod = cgiGet( "Z409MVLECosCod");
            Z410MVLEComCosCod = cgiGet( "Z410MVLEComCosCod");
            Z408MVLEPrvCod = cgiGet( "Z408MVLEPrvCod");
            Z407MVLECueCod = cgiGet( "Z407MVLECueCod");
            Z406MVLEForCod = (int)(context.localUtil.CToN( cgiGet( "Z406MVLEForCod"), ".", ","));
            Z405MVLEMonCod = (int)(context.localUtil.CToN( cgiGet( "Z405MVLEMonCod"), ".", ","));
            A1327MVLEMBanCod = (int)(context.localUtil.CToN( cgiGet( "Z1327MVLEMBanCod"), ".", ","));
            A1330MVLEMCtaBco = cgiGet( "Z1330MVLEMCtaBco");
            A1329MVLEMBanReg = cgiGet( "Z1329MVLEMBanReg");
            A1328MVLEMBanCon = (int)(context.localUtil.CToN( cgiGet( "Z1328MVLEMBanCon"), ".", ","));
            n1328MVLEMBanCon = false;
            n1328MVLEMBanCon = ((0==A1328MVLEMBanCon) ? true : false);
            A1331MVLEMTipo = cgiGet( "Z1331MVLEMTipo");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1327MVLEMBanCod = (int)(context.localUtil.CToN( cgiGet( "MVLEMBANCOD"), ".", ","));
            A1330MVLEMCtaBco = cgiGet( "MVLEMCTABCO");
            A1329MVLEMBanReg = cgiGet( "MVLEMBANREG");
            A1328MVLEMBanCon = (int)(context.localUtil.CToN( cgiGet( "MVLEMBANCON"), ".", ","));
            n1328MVLEMBanCon = ((0==A1328MVLEMBanCon) ? true : false);
            A1331MVLEMTipo = cgiGet( "MVLEMTIPO");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A365EntCod = 0;
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            }
            else
            {
               A365EntCod = (int)(context.localUtil.CToN( cgiGet( edtEntCod_Internalname), ".", ","));
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            }
            A403MVLEntCod = cgiGet( edtMVLEntCod_Internalname);
            AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEITem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEITem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEITEM");
               AnyError = 1;
               GX_FocusControl = edtMVLEITem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A404MVLEITem = 0;
               AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
            }
            else
            {
               A404MVLEITem = (int)(context.localUtil.CToN( cgiGet( edtMVLEITem_Internalname), ".", ","));
               AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
            }
            if ( context.localUtil.VCDate( cgiGet( edtMVLEntFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "MVLENTFEC");
               AnyError = 1;
               GX_FocusControl = edtMVLEntFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1335MVLEntFec = DateTime.MinValue;
               AssignAttri("", false, "A1335MVLEntFec", context.localUtil.Format(A1335MVLEntFec, "99/99/99"));
            }
            else
            {
               A1335MVLEntFec = context.localUtil.CToD( cgiGet( edtMVLEntFec_Internalname), 2);
               AssignAttri("", false, "A1335MVLEntFec", context.localUtil.Format(A1335MVLEntFec, "99/99/99"));
            }
            A1333MVLEntDoc = cgiGet( edtMVLEntDoc_Internalname);
            AssignAttri("", false, "A1333MVLEntDoc", A1333MVLEntDoc);
            A1332MVLEntConc = cgiGet( edtMVLEntConc_Internalname);
            AssignAttri("", false, "A1332MVLEntConc", A1332MVLEntConc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLConcEntCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLConcEntCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLCONCENTCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLConcEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A411MVLConcEntCod = 0;
               AssignAttri("", false, "A411MVLConcEntCod", StringUtil.LTrimStr( (decimal)(A411MVLConcEntCod), 6, 0));
            }
            else
            {
               A411MVLConcEntCod = (int)(context.localUtil.CToN( cgiGet( edtMVLConcEntCod_Internalname), ".", ","));
               AssignAttri("", false, "A411MVLConcEntCod", StringUtil.LTrimStr( (decimal)(A411MVLConcEntCod), 6, 0));
            }
            A1322MVLECueCodAux = cgiGet( edtMVLECueCodAux_Internalname);
            AssignAttri("", false, "A1322MVLECueCodAux", A1322MVLECueCodAux);
            A1321MVLECueAuxCod = cgiGet( edtMVLECueAuxCod_Internalname);
            AssignAttri("", false, "A1321MVLECueAuxCod", A1321MVLECueAuxCod);
            A409MVLECosCod = cgiGet( edtMVLECosCod_Internalname);
            n409MVLECosCod = false;
            AssignAttri("", false, "A409MVLECosCod", A409MVLECosCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEntImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEntImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLENTIMP");
               AnyError = 1;
               GX_FocusControl = edtMVLEntImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1336MVLEntImp = 0;
               AssignAttri("", false, "A1336MVLEntImp", StringUtil.LTrimStr( A1336MVLEntImp, 15, 2));
            }
            else
            {
               A1336MVLEntImp = context.localUtil.CToN( cgiGet( edtMVLEntImp_Internalname), ".", ",");
               AssignAttri("", false, "A1336MVLEntImp", StringUtil.LTrimStr( A1336MVLEntImp, 15, 2));
            }
            A1346MVLETipo = cgiGet( edtMVLETipo_Internalname);
            AssignAttri("", false, "A1346MVLETipo", A1346MVLETipo);
            A408MVLEPrvCod = StringUtil.Upper( cgiGet( edtMVLEPrvCod_Internalname));
            AssignAttri("", false, "A408MVLEPrvCod", A408MVLEPrvCod);
            A1339MVLEntTCod = cgiGet( edtMVLEntTCod_Internalname);
            AssignAttri("", false, "A1339MVLEntTCod", A1339MVLEntTCod);
            A1334MVLEntDocP = cgiGet( edtMVLEntDocP_Internalname);
            AssignAttri("", false, "A1334MVLEntDocP", A1334MVLEntDocP);
            A1337MVLEntReg = cgiGet( edtMVLEntReg_Internalname);
            AssignAttri("", false, "A1337MVLEntReg", A1337MVLEntReg);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEntTCmb_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEntTCmb_Internalname), ".", ",") > 99999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLENTTCMB");
               AnyError = 1;
               GX_FocusControl = edtMVLEntTCmb_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1338MVLEntTCmb = 0;
               AssignAttri("", false, "A1338MVLEntTCmb", StringUtil.LTrimStr( A1338MVLEntTCmb, 10, 4));
            }
            else
            {
               A1338MVLEntTCmb = context.localUtil.CToN( cgiGet( edtMVLEntTCmb_Internalname), ".", ",");
               AssignAttri("", false, "A1338MVLEntTCmb", StringUtil.LTrimStr( A1338MVLEntTCmb, 10, 4));
            }
            if ( context.localUtil.VCDate( cgiGet( edtMVLEComFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "MVLECOMFEC");
               AnyError = 1;
               GX_FocusControl = edtMVLEComFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1317MVLEComFec = DateTime.MinValue;
               AssignAttri("", false, "A1317MVLEComFec", context.localUtil.Format(A1317MVLEComFec, "99/99/99"));
            }
            else
            {
               A1317MVLEComFec = context.localUtil.CToD( cgiGet( edtMVLEComFec_Internalname), 2);
               AssignAttri("", false, "A1317MVLEComFec", context.localUtil.Format(A1317MVLEComFec, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtMVLEComFReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Registro"}), 1, "MVLECOMFREG");
               AnyError = 1;
               GX_FocusControl = edtMVLEComFReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1318MVLEComFReg = DateTime.MinValue;
               AssignAttri("", false, "A1318MVLEComFReg", context.localUtil.Format(A1318MVLEComFReg, "99/99/99"));
            }
            else
            {
               A1318MVLEComFReg = context.localUtil.CToD( cgiGet( edtMVLEComFReg_Internalname), 2);
               AssignAttri("", false, "A1318MVLEComFReg", context.localUtil.Format(A1318MVLEComFReg, "99/99/99"));
            }
            A407MVLECueCod = cgiGet( edtMVLECueCod_Internalname);
            AssignAttri("", false, "A407MVLECueCod", A407MVLECueCod);
            A410MVLEComCosCod = cgiGet( edtMVLEComCosCod_Internalname);
            n410MVLEComCosCod = false;
            AssignAttri("", false, "A410MVLEComCosCod", A410MVLEComCosCod);
            A1316MVLEComCueCod = cgiGet( edtMVLEComCueCod_Internalname);
            AssignAttri("", false, "A1316MVLEComCueCod", A1316MVLEComCueCod);
            A1315MVLEComAux = cgiGet( edtMVLEComAux_Internalname);
            AssignAttri("", false, "A1315MVLEComAux", A1315MVLEComAux);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLESubAfecto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLESubAfecto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLESUBAFECTO");
               AnyError = 1;
               GX_FocusControl = edtMVLESubAfecto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1343MVLESubAfecto = 0;
               AssignAttri("", false, "A1343MVLESubAfecto", StringUtil.LTrimStr( A1343MVLESubAfecto, 15, 2));
            }
            else
            {
               A1343MVLESubAfecto = context.localUtil.CToN( cgiGet( edtMVLESubAfecto_Internalname), ".", ",");
               AssignAttri("", false, "A1343MVLESubAfecto", StringUtil.LTrimStr( A1343MVLESubAfecto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLESubInafecto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLESubInafecto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLESUBINAFECTO");
               AnyError = 1;
               GX_FocusControl = edtMVLESubInafecto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1344MVLESubInafecto = 0;
               AssignAttri("", false, "A1344MVLESubInafecto", StringUtil.LTrimStr( A1344MVLESubInafecto, 15, 2));
            }
            else
            {
               A1344MVLESubInafecto = context.localUtil.CToN( cgiGet( edtMVLESubInafecto_Internalname), ".", ",");
               AssignAttri("", false, "A1344MVLESubInafecto", StringUtil.LTrimStr( A1344MVLESubInafecto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEIGV_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEIGV_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEIGV");
               AnyError = 1;
               GX_FocusControl = edtMVLEIGV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1326MVLEIGV = 0;
               AssignAttri("", false, "A1326MVLEIGV", StringUtil.LTrimStr( A1326MVLEIGV, 15, 2));
            }
            else
            {
               A1326MVLEIGV = context.localUtil.CToN( cgiGet( edtMVLEIGV_Internalname), ".", ",");
               AssignAttri("", false, "A1326MVLEIGV", StringUtil.LTrimStr( A1326MVLEIGV, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLETotal_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLETotal_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLETOTAL");
               AnyError = 1;
               GX_FocusControl = edtMVLETotal_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1347MVLETotal = 0;
               AssignAttri("", false, "A1347MVLETotal", StringUtil.LTrimStr( A1347MVLETotal, 15, 2));
            }
            else
            {
               A1347MVLETotal = context.localUtil.CToN( cgiGet( edtMVLETotal_Internalname), ".", ",");
               AssignAttri("", false, "A1347MVLETotal", StringUtil.LTrimStr( A1347MVLETotal, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLETotalPago_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLETotalPago_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLETOTALPAGO");
               AnyError = 1;
               GX_FocusControl = edtMVLETotalPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1348MVLETotalPago = 0;
               AssignAttri("", false, "A1348MVLETotalPago", StringUtil.LTrimStr( A1348MVLETotalPago, 15, 2));
            }
            else
            {
               A1348MVLETotalPago = context.localUtil.CToN( cgiGet( edtMVLETotalPago_Internalname), ".", ",");
               AssignAttri("", false, "A1348MVLETotalPago", StringUtil.LTrimStr( A1348MVLETotalPago, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A406MVLEForCod = 0;
               n406MVLEForCod = false;
               AssignAttri("", false, "A406MVLEForCod", StringUtil.LTrimStr( (decimal)(A406MVLEForCod), 6, 0));
            }
            else
            {
               A406MVLEForCod = (int)(context.localUtil.CToN( cgiGet( edtMVLEForCod_Internalname), ".", ","));
               n406MVLEForCod = false;
               AssignAttri("", false, "A406MVLEForCod", StringUtil.LTrimStr( (decimal)(A406MVLEForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEPagReg_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEPagReg_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEPAGREG");
               AnyError = 1;
               GX_FocusControl = edtMVLEPagReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1340MVLEPagReg = 0;
               AssignAttri("", false, "A1340MVLEPagReg", StringUtil.LTrimStr( (decimal)(A1340MVLEPagReg), 10, 0));
            }
            else
            {
               A1340MVLEPagReg = (long)(context.localUtil.CToN( cgiGet( edtMVLEPagReg_Internalname), ".", ","));
               AssignAttri("", false, "A1340MVLEPagReg", StringUtil.LTrimStr( (decimal)(A1340MVLEPagReg), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEVOUANO");
               AnyError = 1;
               GX_FocusControl = edtMVLEVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1351MVLEVouAno = 0;
               AssignAttri("", false, "A1351MVLEVouAno", StringUtil.LTrimStr( (decimal)(A1351MVLEVouAno), 4, 0));
            }
            else
            {
               A1351MVLEVouAno = (short)(context.localUtil.CToN( cgiGet( edtMVLEVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1351MVLEVouAno", StringUtil.LTrimStr( (decimal)(A1351MVLEVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEVOUMES");
               AnyError = 1;
               GX_FocusControl = edtMVLEVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1352MVLEVouMes = 0;
               AssignAttri("", false, "A1352MVLEVouMes", StringUtil.LTrimStr( (decimal)(A1352MVLEVouMes), 2, 0));
            }
            else
            {
               A1352MVLEVouMes = (short)(context.localUtil.CToN( cgiGet( edtMVLEVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1352MVLEVouMes", StringUtil.LTrimStr( (decimal)(A1352MVLEVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLETASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLETASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLETASICOD");
               AnyError = 1;
               GX_FocusControl = edtMVLETASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1345MVLETASICod = 0;
               AssignAttri("", false, "A1345MVLETASICod", StringUtil.LTrimStr( (decimal)(A1345MVLETASICod), 6, 0));
            }
            else
            {
               A1345MVLETASICod = (int)(context.localUtil.CToN( cgiGet( edtMVLETASICod_Internalname), ".", ","));
               AssignAttri("", false, "A1345MVLETASICod", StringUtil.LTrimStr( (decimal)(A1345MVLETASICod), 6, 0));
            }
            A1353MVLEVouNum = cgiGet( edtMVLEVouNum_Internalname);
            AssignAttri("", false, "A1353MVLEVouNum", A1353MVLEVouNum);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEMONCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A405MVLEMonCod = 0;
               AssignAttri("", false, "A405MVLEMonCod", StringUtil.LTrimStr( (decimal)(A405MVLEMonCod), 6, 0));
            }
            else
            {
               A405MVLEMonCod = (int)(context.localUtil.CToN( cgiGet( edtMVLEMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A405MVLEMonCod", StringUtil.LTrimStr( (decimal)(A405MVLEMonCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLERedondeo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLERedondeo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLEREDONDEO");
               AnyError = 1;
               GX_FocusControl = edtMVLERedondeo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1342MVLERedondeo = 0;
               AssignAttri("", false, "A1342MVLERedondeo", StringUtil.LTrimStr( A1342MVLERedondeo, 15, 2));
            }
            else
            {
               A1342MVLERedondeo = context.localUtil.CToN( cgiGet( edtMVLERedondeo_Internalname), ".", ",");
               AssignAttri("", false, "A1342MVLERedondeo", StringUtil.LTrimStr( A1342MVLERedondeo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVLEComPorIVA_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtMVLEComPorIVA_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVLECOMPORIVA");
               AnyError = 1;
               GX_FocusControl = edtMVLEComPorIVA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1319MVLEComPorIVA = 0;
               AssignAttri("", false, "A1319MVLEComPorIVA", StringUtil.LTrimStr( A1319MVLEComPorIVA, 15, 2));
            }
            else
            {
               A1319MVLEComPorIVA = context.localUtil.CToN( cgiGet( edtMVLEComPorIVA_Internalname), ".", ",");
               AssignAttri("", false, "A1319MVLEComPorIVA", StringUtil.LTrimStr( A1319MVLEComPorIVA, 15, 2));
            }
            A1349MVLEUsuCod = cgiGet( edtMVLEUsuCod_Internalname);
            AssignAttri("", false, "A1349MVLEUsuCod", A1349MVLEUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtMVLEUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "MVLEUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtMVLEUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1350MVLEUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1350MVLEUsuFec", context.localUtil.TToC( A1350MVLEUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1350MVLEUsuFec = context.localUtil.CToT( cgiGet( edtMVLEUsuFec_Internalname));
               AssignAttri("", false, "A1350MVLEUsuFec", context.localUtil.TToC( A1350MVLEUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            A1320MVLEComTipReg = cgiGet( edtMVLEComTipReg_Internalname);
            AssignAttri("", false, "A1320MVLEComTipReg", A1320MVLEComTipReg);
            A1323MVLECueCos = (short)(context.localUtil.CToN( cgiGet( edtMVLECueCos_Internalname), ".", ","));
            AssignAttri("", false, "A1323MVLECueCos", StringUtil.Str( (decimal)(A1323MVLECueCos), 1, 0));
            A1309MVLConEntDsc = cgiGet( edtMVLConEntDsc_Internalname);
            AssignAttri("", false, "A1309MVLConEntDsc", A1309MVLConEntDsc);
            A1308MVLConEntCue = cgiGet( edtMVLConEntCue_Internalname);
            AssignAttri("", false, "A1308MVLConEntCue", A1308MVLConEntCue);
            A1341MVLEPrvDsc = cgiGet( edtMVLEPrvDsc_Internalname);
            AssignAttri("", false, "A1341MVLEPrvDsc", A1341MVLEPrvDsc);
            A1325MVLECueDsc = cgiGet( edtMVLECueDsc_Internalname);
            AssignAttri("", false, "A1325MVLECueDsc", A1325MVLECueDsc);
            A1324MVLECueCosCod = (short)(context.localUtil.CToN( cgiGet( edtMVLECueCosCod_Internalname), ".", ","));
            AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.Str( (decimal)(A1324MVLECueCosCod), 1, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"TSMOVENTREGA");
            forbiddenHiddens.Add("MVLEMBanCod", context.localUtil.Format( (decimal)(A1327MVLEMBanCod), "ZZZZZ9"));
            forbiddenHiddens.Add("MVLEMCtaBco", StringUtil.RTrim( context.localUtil.Format( A1330MVLEMCtaBco, "")));
            forbiddenHiddens.Add("MVLEMBanReg", StringUtil.RTrim( context.localUtil.Format( A1329MVLEMBanReg, "")));
            forbiddenHiddens.Add("MVLEMBanCon", context.localUtil.Format( (decimal)(A1328MVLEMBanCon), "ZZZZZ9"));
            forbiddenHiddens.Add("MVLEMTipo", StringUtil.RTrim( context.localUtil.Format( A1331MVLEMTipo, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A403MVLEntCod, Z403MVLEntCod) != 0 ) || ( A404MVLEITem != Z404MVLEITem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("tsmoventrega:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               AnyError = 1;
               return  ;
            }
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A365EntCod = (int)(NumberUtil.Val( GetPar( "EntCod"), "."));
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A403MVLEntCod = GetPar( "MVLEntCod");
               AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
               A404MVLEITem = (int)(NumberUtil.Val( GetPar( "MVLEITem"), "."));
               AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
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
               InitAll5C179( ) ;
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
         DisableAttributes5C179( ) ;
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

      protected void CONFIRM_5C0( )
      {
         BeforeValidate5C179( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5C179( ) ;
            }
            else
            {
               CheckExtendedTable5C179( ) ;
               if ( AnyError == 0 )
               {
                  ZM5C179( 6) ;
                  ZM5C179( 7) ;
                  ZM5C179( 8) ;
                  ZM5C179( 9) ;
                  ZM5C179( 10) ;
                  ZM5C179( 11) ;
                  ZM5C179( 12) ;
                  ZM5C179( 13) ;
                  ZM5C179( 14) ;
               }
               CloseExtendedTableCursors5C179( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues5C0( ) ;
         }
      }

      protected void ResetCaption5C0( )
      {
      }

      protected void ZM5C179( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1335MVLEntFec = T005C3_A1335MVLEntFec[0];
               Z1333MVLEntDoc = T005C3_A1333MVLEntDoc[0];
               Z1332MVLEntConc = T005C3_A1332MVLEntConc[0];
               Z1322MVLECueCodAux = T005C3_A1322MVLECueCodAux[0];
               Z1321MVLECueAuxCod = T005C3_A1321MVLECueAuxCod[0];
               Z1336MVLEntImp = T005C3_A1336MVLEntImp[0];
               Z1346MVLETipo = T005C3_A1346MVLETipo[0];
               Z1339MVLEntTCod = T005C3_A1339MVLEntTCod[0];
               Z1334MVLEntDocP = T005C3_A1334MVLEntDocP[0];
               Z1337MVLEntReg = T005C3_A1337MVLEntReg[0];
               Z1338MVLEntTCmb = T005C3_A1338MVLEntTCmb[0];
               Z1317MVLEComFec = T005C3_A1317MVLEComFec[0];
               Z1318MVLEComFReg = T005C3_A1318MVLEComFReg[0];
               Z1316MVLEComCueCod = T005C3_A1316MVLEComCueCod[0];
               Z1315MVLEComAux = T005C3_A1315MVLEComAux[0];
               Z1343MVLESubAfecto = T005C3_A1343MVLESubAfecto[0];
               Z1344MVLESubInafecto = T005C3_A1344MVLESubInafecto[0];
               Z1326MVLEIGV = T005C3_A1326MVLEIGV[0];
               Z1347MVLETotal = T005C3_A1347MVLETotal[0];
               Z1348MVLETotalPago = T005C3_A1348MVLETotalPago[0];
               Z1340MVLEPagReg = T005C3_A1340MVLEPagReg[0];
               Z1351MVLEVouAno = T005C3_A1351MVLEVouAno[0];
               Z1352MVLEVouMes = T005C3_A1352MVLEVouMes[0];
               Z1345MVLETASICod = T005C3_A1345MVLETASICod[0];
               Z1353MVLEVouNum = T005C3_A1353MVLEVouNum[0];
               Z1342MVLERedondeo = T005C3_A1342MVLERedondeo[0];
               Z1319MVLEComPorIVA = T005C3_A1319MVLEComPorIVA[0];
               Z1349MVLEUsuCod = T005C3_A1349MVLEUsuCod[0];
               Z1350MVLEUsuFec = T005C3_A1350MVLEUsuFec[0];
               Z1320MVLEComTipReg = T005C3_A1320MVLEComTipReg[0];
               Z1327MVLEMBanCod = T005C3_A1327MVLEMBanCod[0];
               Z1330MVLEMCtaBco = T005C3_A1330MVLEMCtaBco[0];
               Z1329MVLEMBanReg = T005C3_A1329MVLEMBanReg[0];
               Z1328MVLEMBanCon = T005C3_A1328MVLEMBanCon[0];
               Z1331MVLEMTipo = T005C3_A1331MVLEMTipo[0];
               Z411MVLConcEntCod = T005C3_A411MVLConcEntCod[0];
               Z409MVLECosCod = T005C3_A409MVLECosCod[0];
               Z410MVLEComCosCod = T005C3_A410MVLEComCosCod[0];
               Z408MVLEPrvCod = T005C3_A408MVLEPrvCod[0];
               Z407MVLECueCod = T005C3_A407MVLECueCod[0];
               Z406MVLEForCod = T005C3_A406MVLEForCod[0];
               Z405MVLEMonCod = T005C3_A405MVLEMonCod[0];
            }
            else
            {
               Z1335MVLEntFec = A1335MVLEntFec;
               Z1333MVLEntDoc = A1333MVLEntDoc;
               Z1332MVLEntConc = A1332MVLEntConc;
               Z1322MVLECueCodAux = A1322MVLECueCodAux;
               Z1321MVLECueAuxCod = A1321MVLECueAuxCod;
               Z1336MVLEntImp = A1336MVLEntImp;
               Z1346MVLETipo = A1346MVLETipo;
               Z1339MVLEntTCod = A1339MVLEntTCod;
               Z1334MVLEntDocP = A1334MVLEntDocP;
               Z1337MVLEntReg = A1337MVLEntReg;
               Z1338MVLEntTCmb = A1338MVLEntTCmb;
               Z1317MVLEComFec = A1317MVLEComFec;
               Z1318MVLEComFReg = A1318MVLEComFReg;
               Z1316MVLEComCueCod = A1316MVLEComCueCod;
               Z1315MVLEComAux = A1315MVLEComAux;
               Z1343MVLESubAfecto = A1343MVLESubAfecto;
               Z1344MVLESubInafecto = A1344MVLESubInafecto;
               Z1326MVLEIGV = A1326MVLEIGV;
               Z1347MVLETotal = A1347MVLETotal;
               Z1348MVLETotalPago = A1348MVLETotalPago;
               Z1340MVLEPagReg = A1340MVLEPagReg;
               Z1351MVLEVouAno = A1351MVLEVouAno;
               Z1352MVLEVouMes = A1352MVLEVouMes;
               Z1345MVLETASICod = A1345MVLETASICod;
               Z1353MVLEVouNum = A1353MVLEVouNum;
               Z1342MVLERedondeo = A1342MVLERedondeo;
               Z1319MVLEComPorIVA = A1319MVLEComPorIVA;
               Z1349MVLEUsuCod = A1349MVLEUsuCod;
               Z1350MVLEUsuFec = A1350MVLEUsuFec;
               Z1320MVLEComTipReg = A1320MVLEComTipReg;
               Z1327MVLEMBanCod = A1327MVLEMBanCod;
               Z1330MVLEMCtaBco = A1330MVLEMCtaBco;
               Z1329MVLEMBanReg = A1329MVLEMBanReg;
               Z1328MVLEMBanCon = A1328MVLEMBanCon;
               Z1331MVLEMTipo = A1331MVLEMTipo;
               Z411MVLConcEntCod = A411MVLConcEntCod;
               Z409MVLECosCod = A409MVLECosCod;
               Z410MVLEComCosCod = A410MVLEComCosCod;
               Z408MVLEPrvCod = A408MVLEPrvCod;
               Z407MVLECueCod = A407MVLECueCod;
               Z406MVLEForCod = A406MVLEForCod;
               Z405MVLEMonCod = A405MVLEMonCod;
            }
         }
         if ( GX_JID == -5 )
         {
            Z403MVLEntCod = A403MVLEntCod;
            Z404MVLEITem = A404MVLEITem;
            Z1335MVLEntFec = A1335MVLEntFec;
            Z1333MVLEntDoc = A1333MVLEntDoc;
            Z1332MVLEntConc = A1332MVLEntConc;
            Z1322MVLECueCodAux = A1322MVLECueCodAux;
            Z1321MVLECueAuxCod = A1321MVLECueAuxCod;
            Z1336MVLEntImp = A1336MVLEntImp;
            Z1346MVLETipo = A1346MVLETipo;
            Z1339MVLEntTCod = A1339MVLEntTCod;
            Z1334MVLEntDocP = A1334MVLEntDocP;
            Z1337MVLEntReg = A1337MVLEntReg;
            Z1338MVLEntTCmb = A1338MVLEntTCmb;
            Z1317MVLEComFec = A1317MVLEComFec;
            Z1318MVLEComFReg = A1318MVLEComFReg;
            Z1316MVLEComCueCod = A1316MVLEComCueCod;
            Z1315MVLEComAux = A1315MVLEComAux;
            Z1343MVLESubAfecto = A1343MVLESubAfecto;
            Z1344MVLESubInafecto = A1344MVLESubInafecto;
            Z1326MVLEIGV = A1326MVLEIGV;
            Z1347MVLETotal = A1347MVLETotal;
            Z1348MVLETotalPago = A1348MVLETotalPago;
            Z1340MVLEPagReg = A1340MVLEPagReg;
            Z1351MVLEVouAno = A1351MVLEVouAno;
            Z1352MVLEVouMes = A1352MVLEVouMes;
            Z1345MVLETASICod = A1345MVLETASICod;
            Z1353MVLEVouNum = A1353MVLEVouNum;
            Z1342MVLERedondeo = A1342MVLERedondeo;
            Z1319MVLEComPorIVA = A1319MVLEComPorIVA;
            Z1349MVLEUsuCod = A1349MVLEUsuCod;
            Z1350MVLEUsuFec = A1350MVLEUsuFec;
            Z1320MVLEComTipReg = A1320MVLEComTipReg;
            Z1327MVLEMBanCod = A1327MVLEMBanCod;
            Z1330MVLEMCtaBco = A1330MVLEMCtaBco;
            Z1329MVLEMBanReg = A1329MVLEMBanReg;
            Z1328MVLEMBanCon = A1328MVLEMBanCon;
            Z1331MVLEMTipo = A1331MVLEMTipo;
            Z365EntCod = A365EntCod;
            Z411MVLConcEntCod = A411MVLConcEntCod;
            Z409MVLECosCod = A409MVLECosCod;
            Z410MVLEComCosCod = A410MVLEComCosCod;
            Z408MVLEPrvCod = A408MVLEPrvCod;
            Z407MVLECueCod = A407MVLECueCod;
            Z406MVLEForCod = A406MVLEForCod;
            Z405MVLEMonCod = A405MVLEMonCod;
            Z1309MVLConEntDsc = A1309MVLConEntDsc;
            Z1308MVLConEntCue = A1308MVLConEntCue;
            Z1323MVLECueCos = A1323MVLECueCos;
            Z1341MVLEPrvDsc = A1341MVLEPrvDsc;
            Z1325MVLECueDsc = A1325MVLECueDsc;
            Z1324MVLECueCosCod = A1324MVLECueCosCod;
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

      protected void Load5C179( )
      {
         /* Using cursor T005C13 */
         pr_default.execute(11, new Object[] {A365EntCod, A403MVLEntCod, A404MVLEITem});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound179 = 1;
            A1335MVLEntFec = T005C13_A1335MVLEntFec[0];
            AssignAttri("", false, "A1335MVLEntFec", context.localUtil.Format(A1335MVLEntFec, "99/99/99"));
            A1333MVLEntDoc = T005C13_A1333MVLEntDoc[0];
            AssignAttri("", false, "A1333MVLEntDoc", A1333MVLEntDoc);
            A1332MVLEntConc = T005C13_A1332MVLEntConc[0];
            AssignAttri("", false, "A1332MVLEntConc", A1332MVLEntConc);
            A1322MVLECueCodAux = T005C13_A1322MVLECueCodAux[0];
            AssignAttri("", false, "A1322MVLECueCodAux", A1322MVLECueCodAux);
            A1321MVLECueAuxCod = T005C13_A1321MVLECueAuxCod[0];
            AssignAttri("", false, "A1321MVLECueAuxCod", A1321MVLECueAuxCod);
            A1336MVLEntImp = T005C13_A1336MVLEntImp[0];
            AssignAttri("", false, "A1336MVLEntImp", StringUtil.LTrimStr( A1336MVLEntImp, 15, 2));
            A1346MVLETipo = T005C13_A1346MVLETipo[0];
            AssignAttri("", false, "A1346MVLETipo", A1346MVLETipo);
            A1339MVLEntTCod = T005C13_A1339MVLEntTCod[0];
            AssignAttri("", false, "A1339MVLEntTCod", A1339MVLEntTCod);
            A1334MVLEntDocP = T005C13_A1334MVLEntDocP[0];
            AssignAttri("", false, "A1334MVLEntDocP", A1334MVLEntDocP);
            A1337MVLEntReg = T005C13_A1337MVLEntReg[0];
            AssignAttri("", false, "A1337MVLEntReg", A1337MVLEntReg);
            A1338MVLEntTCmb = T005C13_A1338MVLEntTCmb[0];
            AssignAttri("", false, "A1338MVLEntTCmb", StringUtil.LTrimStr( A1338MVLEntTCmb, 10, 4));
            A1317MVLEComFec = T005C13_A1317MVLEComFec[0];
            AssignAttri("", false, "A1317MVLEComFec", context.localUtil.Format(A1317MVLEComFec, "99/99/99"));
            A1318MVLEComFReg = T005C13_A1318MVLEComFReg[0];
            AssignAttri("", false, "A1318MVLEComFReg", context.localUtil.Format(A1318MVLEComFReg, "99/99/99"));
            A1316MVLEComCueCod = T005C13_A1316MVLEComCueCod[0];
            AssignAttri("", false, "A1316MVLEComCueCod", A1316MVLEComCueCod);
            A1315MVLEComAux = T005C13_A1315MVLEComAux[0];
            AssignAttri("", false, "A1315MVLEComAux", A1315MVLEComAux);
            A1343MVLESubAfecto = T005C13_A1343MVLESubAfecto[0];
            AssignAttri("", false, "A1343MVLESubAfecto", StringUtil.LTrimStr( A1343MVLESubAfecto, 15, 2));
            A1344MVLESubInafecto = T005C13_A1344MVLESubInafecto[0];
            AssignAttri("", false, "A1344MVLESubInafecto", StringUtil.LTrimStr( A1344MVLESubInafecto, 15, 2));
            A1326MVLEIGV = T005C13_A1326MVLEIGV[0];
            AssignAttri("", false, "A1326MVLEIGV", StringUtil.LTrimStr( A1326MVLEIGV, 15, 2));
            A1347MVLETotal = T005C13_A1347MVLETotal[0];
            AssignAttri("", false, "A1347MVLETotal", StringUtil.LTrimStr( A1347MVLETotal, 15, 2));
            A1348MVLETotalPago = T005C13_A1348MVLETotalPago[0];
            AssignAttri("", false, "A1348MVLETotalPago", StringUtil.LTrimStr( A1348MVLETotalPago, 15, 2));
            A1340MVLEPagReg = T005C13_A1340MVLEPagReg[0];
            AssignAttri("", false, "A1340MVLEPagReg", StringUtil.LTrimStr( (decimal)(A1340MVLEPagReg), 10, 0));
            A1351MVLEVouAno = T005C13_A1351MVLEVouAno[0];
            AssignAttri("", false, "A1351MVLEVouAno", StringUtil.LTrimStr( (decimal)(A1351MVLEVouAno), 4, 0));
            A1352MVLEVouMes = T005C13_A1352MVLEVouMes[0];
            AssignAttri("", false, "A1352MVLEVouMes", StringUtil.LTrimStr( (decimal)(A1352MVLEVouMes), 2, 0));
            A1345MVLETASICod = T005C13_A1345MVLETASICod[0];
            AssignAttri("", false, "A1345MVLETASICod", StringUtil.LTrimStr( (decimal)(A1345MVLETASICod), 6, 0));
            A1353MVLEVouNum = T005C13_A1353MVLEVouNum[0];
            AssignAttri("", false, "A1353MVLEVouNum", A1353MVLEVouNum);
            A1342MVLERedondeo = T005C13_A1342MVLERedondeo[0];
            AssignAttri("", false, "A1342MVLERedondeo", StringUtil.LTrimStr( A1342MVLERedondeo, 15, 2));
            A1319MVLEComPorIVA = T005C13_A1319MVLEComPorIVA[0];
            AssignAttri("", false, "A1319MVLEComPorIVA", StringUtil.LTrimStr( A1319MVLEComPorIVA, 15, 2));
            A1349MVLEUsuCod = T005C13_A1349MVLEUsuCod[0];
            AssignAttri("", false, "A1349MVLEUsuCod", A1349MVLEUsuCod);
            A1350MVLEUsuFec = T005C13_A1350MVLEUsuFec[0];
            AssignAttri("", false, "A1350MVLEUsuFec", context.localUtil.TToC( A1350MVLEUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1320MVLEComTipReg = T005C13_A1320MVLEComTipReg[0];
            AssignAttri("", false, "A1320MVLEComTipReg", A1320MVLEComTipReg);
            A1323MVLECueCos = T005C13_A1323MVLECueCos[0];
            AssignAttri("", false, "A1323MVLECueCos", StringUtil.Str( (decimal)(A1323MVLECueCos), 1, 0));
            A1309MVLConEntDsc = T005C13_A1309MVLConEntDsc[0];
            AssignAttri("", false, "A1309MVLConEntDsc", A1309MVLConEntDsc);
            A1341MVLEPrvDsc = T005C13_A1341MVLEPrvDsc[0];
            AssignAttri("", false, "A1341MVLEPrvDsc", A1341MVLEPrvDsc);
            A1325MVLECueDsc = T005C13_A1325MVLECueDsc[0];
            AssignAttri("", false, "A1325MVLECueDsc", A1325MVLECueDsc);
            A1324MVLECueCosCod = T005C13_A1324MVLECueCosCod[0];
            AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.Str( (decimal)(A1324MVLECueCosCod), 1, 0));
            A1327MVLEMBanCod = T005C13_A1327MVLEMBanCod[0];
            A1330MVLEMCtaBco = T005C13_A1330MVLEMCtaBco[0];
            A1329MVLEMBanReg = T005C13_A1329MVLEMBanReg[0];
            A1328MVLEMBanCon = T005C13_A1328MVLEMBanCon[0];
            n1328MVLEMBanCon = T005C13_n1328MVLEMBanCon[0];
            A1331MVLEMTipo = T005C13_A1331MVLEMTipo[0];
            A411MVLConcEntCod = T005C13_A411MVLConcEntCod[0];
            AssignAttri("", false, "A411MVLConcEntCod", StringUtil.LTrimStr( (decimal)(A411MVLConcEntCod), 6, 0));
            A409MVLECosCod = T005C13_A409MVLECosCod[0];
            n409MVLECosCod = T005C13_n409MVLECosCod[0];
            AssignAttri("", false, "A409MVLECosCod", A409MVLECosCod);
            A410MVLEComCosCod = T005C13_A410MVLEComCosCod[0];
            n410MVLEComCosCod = T005C13_n410MVLEComCosCod[0];
            AssignAttri("", false, "A410MVLEComCosCod", A410MVLEComCosCod);
            A408MVLEPrvCod = T005C13_A408MVLEPrvCod[0];
            AssignAttri("", false, "A408MVLEPrvCod", A408MVLEPrvCod);
            A407MVLECueCod = T005C13_A407MVLECueCod[0];
            AssignAttri("", false, "A407MVLECueCod", A407MVLECueCod);
            A406MVLEForCod = T005C13_A406MVLEForCod[0];
            n406MVLEForCod = T005C13_n406MVLEForCod[0];
            AssignAttri("", false, "A406MVLEForCod", StringUtil.LTrimStr( (decimal)(A406MVLEForCod), 6, 0));
            A405MVLEMonCod = T005C13_A405MVLEMonCod[0];
            AssignAttri("", false, "A405MVLEMonCod", StringUtil.LTrimStr( (decimal)(A405MVLEMonCod), 6, 0));
            A1308MVLConEntCue = T005C13_A1308MVLConEntCue[0];
            AssignAttri("", false, "A1308MVLConEntCue", A1308MVLConEntCue);
            ZM5C179( -5) ;
         }
         pr_default.close(11);
         OnLoadActions5C179( ) ;
      }

      protected void OnLoadActions5C179( )
      {
      }

      protected void CheckExtendedTable5C179( )
      {
         nIsDirty_179 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T005C4 */
         pr_default.execute(2, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( (DateTime.MinValue==A1335MVLEntFec) || ( DateTimeUtil.ResetTime ( A1335MVLEntFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "MVLENTFEC");
            AnyError = 1;
            GX_FocusControl = edtMVLEntFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005C5 */
         pr_default.execute(3, new Object[] {A411MVLConcEntCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto'.", "ForeignKeyNotFound", 1, "MVLCONCENTCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLConcEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1309MVLConEntDsc = T005C5_A1309MVLConEntDsc[0];
         AssignAttri("", false, "A1309MVLConEntDsc", A1309MVLConEntDsc);
         A1308MVLConEntCue = T005C5_A1308MVLConEntCue[0];
         AssignAttri("", false, "A1308MVLConEntCue", A1308MVLConEntCue);
         pr_default.close(3);
         /* Using cursor T005C12 */
         pr_default.execute(10, new Object[] {A1308MVLConEntCue});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto'.", "ForeignKeyNotFound", 1, "MVLCONENTCUE");
            AnyError = 1;
         }
         A1323MVLECueCos = T005C12_A1323MVLECueCos[0];
         AssignAttri("", false, "A1323MVLECueCos", StringUtil.Str( (decimal)(A1323MVLECueCos), 1, 0));
         pr_default.close(10);
         /* Using cursor T005C6 */
         pr_default.execute(4, new Object[] {n409MVLECosCod, A409MVLECosCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A409MVLECosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "MVLECOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLECosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T005C8 */
         pr_default.execute(6, new Object[] {A408MVLEPrvCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "MVLEPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLEPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1341MVLEPrvDsc = T005C8_A1341MVLEPrvDsc[0];
         AssignAttri("", false, "A1341MVLEPrvDsc", A1341MVLEPrvDsc);
         pr_default.close(6);
         if ( ! ( (DateTime.MinValue==A1317MVLEComFec) || ( DateTimeUtil.ResetTime ( A1317MVLEComFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "MVLECOMFEC");
            AnyError = 1;
            GX_FocusControl = edtMVLEComFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A1318MVLEComFReg) || ( DateTimeUtil.ResetTime ( A1318MVLEComFReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Registro fuera de rango", "OutOfRange", 1, "MVLECOMFREG");
            AnyError = 1;
            GX_FocusControl = edtMVLEComFReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T005C9 */
         pr_default.execute(7, new Object[] {A407MVLECueCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "MVLECUECOD");
            AnyError = 1;
            GX_FocusControl = edtMVLECueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1325MVLECueDsc = T005C9_A1325MVLECueDsc[0];
         AssignAttri("", false, "A1325MVLECueDsc", A1325MVLECueDsc);
         A1324MVLECueCosCod = T005C9_A1324MVLECueCosCod[0];
         AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.Str( (decimal)(A1324MVLECueCosCod), 1, 0));
         pr_default.close(7);
         /* Using cursor T005C7 */
         pr_default.execute(5, new Object[] {n410MVLEComCosCod, A410MVLEComCosCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A410MVLEComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "MVLECOMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEComCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
         /* Using cursor T005C10 */
         pr_default.execute(8, new Object[] {n406MVLEForCod, A406MVLEForCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( (0==A406MVLEForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "MVLEFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(8);
         /* Using cursor T005C11 */
         pr_default.execute(9, new Object[] {A405MVLEMonCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "MVLEMONCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLEMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(9);
         if ( ! ( (DateTime.MinValue==A1350MVLEUsuFec) || ( A1350MVLEUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "MVLEUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtMVLEUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5C179( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(10);
         pr_default.close(4);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(5);
         pr_default.close(8);
         pr_default.close(9);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( int A365EntCod )
      {
         /* Using cursor T005C14 */
         pr_default.execute(12, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
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

      protected void gxLoad_7( int A411MVLConcEntCod )
      {
         /* Using cursor T005C15 */
         pr_default.execute(13, new Object[] {A411MVLConcEntCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto'.", "ForeignKeyNotFound", 1, "MVLCONCENTCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLConcEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1309MVLConEntDsc = T005C15_A1309MVLConEntDsc[0];
         AssignAttri("", false, "A1309MVLConEntDsc", A1309MVLConEntDsc);
         A1308MVLConEntCue = T005C15_A1308MVLConEntCue[0];
         AssignAttri("", false, "A1308MVLConEntCue", A1308MVLConEntCue);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1309MVLConEntDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1308MVLConEntCue))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_14( string A1308MVLConEntCue )
      {
         /* Using cursor T005C16 */
         pr_default.execute(14, new Object[] {A1308MVLConEntCue});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto'.", "ForeignKeyNotFound", 1, "MVLCONENTCUE");
            AnyError = 1;
         }
         A1323MVLECueCos = T005C16_A1323MVLECueCos[0];
         AssignAttri("", false, "A1323MVLECueCos", StringUtil.Str( (decimal)(A1323MVLECueCos), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1323MVLECueCos), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_8( string A409MVLECosCod )
      {
         /* Using cursor T005C17 */
         pr_default.execute(15, new Object[] {n409MVLECosCod, A409MVLECosCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A409MVLECosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "MVLECOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLECosCod_Internalname;
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

      protected void gxLoad_10( string A408MVLEPrvCod )
      {
         /* Using cursor T005C18 */
         pr_default.execute(16, new Object[] {A408MVLEPrvCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "MVLEPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLEPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1341MVLEPrvDsc = T005C18_A1341MVLEPrvDsc[0];
         AssignAttri("", false, "A1341MVLEPrvDsc", A1341MVLEPrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1341MVLEPrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_11( string A407MVLECueCod )
      {
         /* Using cursor T005C19 */
         pr_default.execute(17, new Object[] {A407MVLECueCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "MVLECUECOD");
            AnyError = 1;
            GX_FocusControl = edtMVLECueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1325MVLECueDsc = T005C19_A1325MVLECueDsc[0];
         AssignAttri("", false, "A1325MVLECueDsc", A1325MVLECueDsc);
         A1324MVLECueCosCod = T005C19_A1324MVLECueCosCod[0];
         AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.Str( (decimal)(A1324MVLECueCosCod), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1325MVLECueDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1324MVLECueCosCod), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_9( string A410MVLEComCosCod )
      {
         /* Using cursor T005C20 */
         pr_default.execute(18, new Object[] {n410MVLEComCosCod, A410MVLEComCosCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A410MVLEComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "MVLECOMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEComCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_12( int A406MVLEForCod )
      {
         /* Using cursor T005C21 */
         pr_default.execute(19, new Object[] {n406MVLEForCod, A406MVLEForCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A406MVLEForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "MVLEFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEForCod_Internalname;
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

      protected void gxLoad_13( int A405MVLEMonCod )
      {
         /* Using cursor T005C22 */
         pr_default.execute(20, new Object[] {A405MVLEMonCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "MVLEMONCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLEMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void GetKey5C179( )
      {
         /* Using cursor T005C23 */
         pr_default.execute(21, new Object[] {A365EntCod, A403MVLEntCod, A404MVLEITem});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound179 = 1;
         }
         else
         {
            RcdFound179 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005C3 */
         pr_default.execute(1, new Object[] {A365EntCod, A403MVLEntCod, A404MVLEITem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5C179( 5) ;
            RcdFound179 = 1;
            A403MVLEntCod = T005C3_A403MVLEntCod[0];
            AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
            A404MVLEITem = T005C3_A404MVLEITem[0];
            AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
            A1335MVLEntFec = T005C3_A1335MVLEntFec[0];
            AssignAttri("", false, "A1335MVLEntFec", context.localUtil.Format(A1335MVLEntFec, "99/99/99"));
            A1333MVLEntDoc = T005C3_A1333MVLEntDoc[0];
            AssignAttri("", false, "A1333MVLEntDoc", A1333MVLEntDoc);
            A1332MVLEntConc = T005C3_A1332MVLEntConc[0];
            AssignAttri("", false, "A1332MVLEntConc", A1332MVLEntConc);
            A1322MVLECueCodAux = T005C3_A1322MVLECueCodAux[0];
            AssignAttri("", false, "A1322MVLECueCodAux", A1322MVLECueCodAux);
            A1321MVLECueAuxCod = T005C3_A1321MVLECueAuxCod[0];
            AssignAttri("", false, "A1321MVLECueAuxCod", A1321MVLECueAuxCod);
            A1336MVLEntImp = T005C3_A1336MVLEntImp[0];
            AssignAttri("", false, "A1336MVLEntImp", StringUtil.LTrimStr( A1336MVLEntImp, 15, 2));
            A1346MVLETipo = T005C3_A1346MVLETipo[0];
            AssignAttri("", false, "A1346MVLETipo", A1346MVLETipo);
            A1339MVLEntTCod = T005C3_A1339MVLEntTCod[0];
            AssignAttri("", false, "A1339MVLEntTCod", A1339MVLEntTCod);
            A1334MVLEntDocP = T005C3_A1334MVLEntDocP[0];
            AssignAttri("", false, "A1334MVLEntDocP", A1334MVLEntDocP);
            A1337MVLEntReg = T005C3_A1337MVLEntReg[0];
            AssignAttri("", false, "A1337MVLEntReg", A1337MVLEntReg);
            A1338MVLEntTCmb = T005C3_A1338MVLEntTCmb[0];
            AssignAttri("", false, "A1338MVLEntTCmb", StringUtil.LTrimStr( A1338MVLEntTCmb, 10, 4));
            A1317MVLEComFec = T005C3_A1317MVLEComFec[0];
            AssignAttri("", false, "A1317MVLEComFec", context.localUtil.Format(A1317MVLEComFec, "99/99/99"));
            A1318MVLEComFReg = T005C3_A1318MVLEComFReg[0];
            AssignAttri("", false, "A1318MVLEComFReg", context.localUtil.Format(A1318MVLEComFReg, "99/99/99"));
            A1316MVLEComCueCod = T005C3_A1316MVLEComCueCod[0];
            AssignAttri("", false, "A1316MVLEComCueCod", A1316MVLEComCueCod);
            A1315MVLEComAux = T005C3_A1315MVLEComAux[0];
            AssignAttri("", false, "A1315MVLEComAux", A1315MVLEComAux);
            A1343MVLESubAfecto = T005C3_A1343MVLESubAfecto[0];
            AssignAttri("", false, "A1343MVLESubAfecto", StringUtil.LTrimStr( A1343MVLESubAfecto, 15, 2));
            A1344MVLESubInafecto = T005C3_A1344MVLESubInafecto[0];
            AssignAttri("", false, "A1344MVLESubInafecto", StringUtil.LTrimStr( A1344MVLESubInafecto, 15, 2));
            A1326MVLEIGV = T005C3_A1326MVLEIGV[0];
            AssignAttri("", false, "A1326MVLEIGV", StringUtil.LTrimStr( A1326MVLEIGV, 15, 2));
            A1347MVLETotal = T005C3_A1347MVLETotal[0];
            AssignAttri("", false, "A1347MVLETotal", StringUtil.LTrimStr( A1347MVLETotal, 15, 2));
            A1348MVLETotalPago = T005C3_A1348MVLETotalPago[0];
            AssignAttri("", false, "A1348MVLETotalPago", StringUtil.LTrimStr( A1348MVLETotalPago, 15, 2));
            A1340MVLEPagReg = T005C3_A1340MVLEPagReg[0];
            AssignAttri("", false, "A1340MVLEPagReg", StringUtil.LTrimStr( (decimal)(A1340MVLEPagReg), 10, 0));
            A1351MVLEVouAno = T005C3_A1351MVLEVouAno[0];
            AssignAttri("", false, "A1351MVLEVouAno", StringUtil.LTrimStr( (decimal)(A1351MVLEVouAno), 4, 0));
            A1352MVLEVouMes = T005C3_A1352MVLEVouMes[0];
            AssignAttri("", false, "A1352MVLEVouMes", StringUtil.LTrimStr( (decimal)(A1352MVLEVouMes), 2, 0));
            A1345MVLETASICod = T005C3_A1345MVLETASICod[0];
            AssignAttri("", false, "A1345MVLETASICod", StringUtil.LTrimStr( (decimal)(A1345MVLETASICod), 6, 0));
            A1353MVLEVouNum = T005C3_A1353MVLEVouNum[0];
            AssignAttri("", false, "A1353MVLEVouNum", A1353MVLEVouNum);
            A1342MVLERedondeo = T005C3_A1342MVLERedondeo[0];
            AssignAttri("", false, "A1342MVLERedondeo", StringUtil.LTrimStr( A1342MVLERedondeo, 15, 2));
            A1319MVLEComPorIVA = T005C3_A1319MVLEComPorIVA[0];
            AssignAttri("", false, "A1319MVLEComPorIVA", StringUtil.LTrimStr( A1319MVLEComPorIVA, 15, 2));
            A1349MVLEUsuCod = T005C3_A1349MVLEUsuCod[0];
            AssignAttri("", false, "A1349MVLEUsuCod", A1349MVLEUsuCod);
            A1350MVLEUsuFec = T005C3_A1350MVLEUsuFec[0];
            AssignAttri("", false, "A1350MVLEUsuFec", context.localUtil.TToC( A1350MVLEUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1320MVLEComTipReg = T005C3_A1320MVLEComTipReg[0];
            AssignAttri("", false, "A1320MVLEComTipReg", A1320MVLEComTipReg);
            A1327MVLEMBanCod = T005C3_A1327MVLEMBanCod[0];
            A1330MVLEMCtaBco = T005C3_A1330MVLEMCtaBco[0];
            A1329MVLEMBanReg = T005C3_A1329MVLEMBanReg[0];
            A1328MVLEMBanCon = T005C3_A1328MVLEMBanCon[0];
            n1328MVLEMBanCon = T005C3_n1328MVLEMBanCon[0];
            A1331MVLEMTipo = T005C3_A1331MVLEMTipo[0];
            A365EntCod = T005C3_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A411MVLConcEntCod = T005C3_A411MVLConcEntCod[0];
            AssignAttri("", false, "A411MVLConcEntCod", StringUtil.LTrimStr( (decimal)(A411MVLConcEntCod), 6, 0));
            A409MVLECosCod = T005C3_A409MVLECosCod[0];
            n409MVLECosCod = T005C3_n409MVLECosCod[0];
            AssignAttri("", false, "A409MVLECosCod", A409MVLECosCod);
            A410MVLEComCosCod = T005C3_A410MVLEComCosCod[0];
            n410MVLEComCosCod = T005C3_n410MVLEComCosCod[0];
            AssignAttri("", false, "A410MVLEComCosCod", A410MVLEComCosCod);
            A408MVLEPrvCod = T005C3_A408MVLEPrvCod[0];
            AssignAttri("", false, "A408MVLEPrvCod", A408MVLEPrvCod);
            A407MVLECueCod = T005C3_A407MVLECueCod[0];
            AssignAttri("", false, "A407MVLECueCod", A407MVLECueCod);
            A406MVLEForCod = T005C3_A406MVLEForCod[0];
            n406MVLEForCod = T005C3_n406MVLEForCod[0];
            AssignAttri("", false, "A406MVLEForCod", StringUtil.LTrimStr( (decimal)(A406MVLEForCod), 6, 0));
            A405MVLEMonCod = T005C3_A405MVLEMonCod[0];
            AssignAttri("", false, "A405MVLEMonCod", StringUtil.LTrimStr( (decimal)(A405MVLEMonCod), 6, 0));
            Z365EntCod = A365EntCod;
            Z403MVLEntCod = A403MVLEntCod;
            Z404MVLEITem = A404MVLEITem;
            sMode179 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load5C179( ) ;
            if ( AnyError == 1 )
            {
               RcdFound179 = 0;
               InitializeNonKey5C179( ) ;
            }
            Gx_mode = sMode179;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound179 = 0;
            InitializeNonKey5C179( ) ;
            sMode179 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode179;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5C179( ) ;
         if ( RcdFound179 == 0 )
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
         RcdFound179 = 0;
         /* Using cursor T005C24 */
         pr_default.execute(22, new Object[] {A365EntCod, A403MVLEntCod, A404MVLEITem});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( T005C24_A365EntCod[0] < A365EntCod ) || ( T005C24_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005C24_A403MVLEntCod[0], A403MVLEntCod) < 0 ) || ( StringUtil.StrCmp(T005C24_A403MVLEntCod[0], A403MVLEntCod) == 0 ) && ( T005C24_A365EntCod[0] == A365EntCod ) && ( T005C24_A404MVLEITem[0] < A404MVLEITem ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( T005C24_A365EntCod[0] > A365EntCod ) || ( T005C24_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005C24_A403MVLEntCod[0], A403MVLEntCod) > 0 ) || ( StringUtil.StrCmp(T005C24_A403MVLEntCod[0], A403MVLEntCod) == 0 ) && ( T005C24_A365EntCod[0] == A365EntCod ) && ( T005C24_A404MVLEITem[0] > A404MVLEITem ) ) )
            {
               A365EntCod = T005C24_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A403MVLEntCod = T005C24_A403MVLEntCod[0];
               AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
               A404MVLEITem = T005C24_A404MVLEITem[0];
               AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
               RcdFound179 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound179 = 0;
         /* Using cursor T005C25 */
         pr_default.execute(23, new Object[] {A365EntCod, A403MVLEntCod, A404MVLEITem});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( T005C25_A365EntCod[0] > A365EntCod ) || ( T005C25_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005C25_A403MVLEntCod[0], A403MVLEntCod) > 0 ) || ( StringUtil.StrCmp(T005C25_A403MVLEntCod[0], A403MVLEntCod) == 0 ) && ( T005C25_A365EntCod[0] == A365EntCod ) && ( T005C25_A404MVLEITem[0] > A404MVLEITem ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( T005C25_A365EntCod[0] < A365EntCod ) || ( T005C25_A365EntCod[0] == A365EntCod ) && ( StringUtil.StrCmp(T005C25_A403MVLEntCod[0], A403MVLEntCod) < 0 ) || ( StringUtil.StrCmp(T005C25_A403MVLEntCod[0], A403MVLEntCod) == 0 ) && ( T005C25_A365EntCod[0] == A365EntCod ) && ( T005C25_A404MVLEITem[0] < A404MVLEITem ) ) )
            {
               A365EntCod = T005C25_A365EntCod[0];
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A403MVLEntCod = T005C25_A403MVLEntCod[0];
               AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
               A404MVLEITem = T005C25_A404MVLEITem[0];
               AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
               RcdFound179 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5C179( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5C179( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound179 == 1 )
            {
               if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A403MVLEntCod, Z403MVLEntCod) != 0 ) || ( A404MVLEITem != Z404MVLEITem ) )
               {
                  A365EntCod = Z365EntCod;
                  AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
                  A403MVLEntCod = Z403MVLEntCod;
                  AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
                  A404MVLEITem = Z404MVLEITem;
                  AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update5C179( ) ;
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A403MVLEntCod, Z403MVLEntCod) != 0 ) || ( A404MVLEITem != Z404MVLEITem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtEntCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5C179( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTCOD");
                     AnyError = 1;
                     GX_FocusControl = edtEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtEntCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5C179( ) ;
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
         if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A403MVLEntCod, Z403MVLEntCod) != 0 ) || ( A404MVLEITem != Z404MVLEITem ) )
         {
            A365EntCod = Z365EntCod;
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A403MVLEntCod = Z403MVLEntCod;
            AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
            A404MVLEITem = Z404MVLEITem;
            AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtEntCod_Internalname;
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
         GetKey5C179( ) ;
         if ( RcdFound179 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A403MVLEntCod, Z403MVLEntCod) != 0 ) || ( A404MVLEITem != Z404MVLEITem ) )
            {
               A365EntCod = Z365EntCod;
               AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
               A403MVLEntCod = Z403MVLEntCod;
               AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
               A404MVLEITem = Z404MVLEITem;
               AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ENTCOD");
               AnyError = 1;
               GX_FocusControl = edtEntCod_Internalname;
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
            if ( ( A365EntCod != Z365EntCod ) || ( StringUtil.StrCmp(A403MVLEntCod, Z403MVLEntCod) != 0 ) || ( A404MVLEITem != Z404MVLEITem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ENTCOD");
                  AnyError = 1;
                  GX_FocusControl = edtEntCod_Internalname;
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
         context.RollbackDataStores("tsmoventrega",pr_default);
         GX_FocusControl = edtMVLEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_5C0( ) ;
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
         if ( RcdFound179 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMVLEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart5C179( ) ;
         if ( RcdFound179 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5C179( ) ;
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
         if ( RcdFound179 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLEntFec_Internalname;
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
         if ( RcdFound179 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLEntFec_Internalname;
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
         ScanStart5C179( ) ;
         if ( RcdFound179 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound179 != 0 )
            {
               ScanNext5C179( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMVLEntFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd5C179( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency5C179( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005C2 */
            pr_default.execute(0, new Object[] {A365EntCod, A403MVLEntCod, A404MVLEITem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVENTREGA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z1335MVLEntFec ) != DateTimeUtil.ResetTime ( T005C2_A1335MVLEntFec[0] ) ) || ( StringUtil.StrCmp(Z1333MVLEntDoc, T005C2_A1333MVLEntDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z1332MVLEntConc, T005C2_A1332MVLEntConc[0]) != 0 ) || ( StringUtil.StrCmp(Z1322MVLECueCodAux, T005C2_A1322MVLECueCodAux[0]) != 0 ) || ( StringUtil.StrCmp(Z1321MVLECueAuxCod, T005C2_A1321MVLECueAuxCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1336MVLEntImp != T005C2_A1336MVLEntImp[0] ) || ( StringUtil.StrCmp(Z1346MVLETipo, T005C2_A1346MVLETipo[0]) != 0 ) || ( StringUtil.StrCmp(Z1339MVLEntTCod, T005C2_A1339MVLEntTCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1334MVLEntDocP, T005C2_A1334MVLEntDocP[0]) != 0 ) || ( StringUtil.StrCmp(Z1337MVLEntReg, T005C2_A1337MVLEntReg[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1338MVLEntTCmb != T005C2_A1338MVLEntTCmb[0] ) || ( DateTimeUtil.ResetTime ( Z1317MVLEComFec ) != DateTimeUtil.ResetTime ( T005C2_A1317MVLEComFec[0] ) ) || ( DateTimeUtil.ResetTime ( Z1318MVLEComFReg ) != DateTimeUtil.ResetTime ( T005C2_A1318MVLEComFReg[0] ) ) || ( StringUtil.StrCmp(Z1316MVLEComCueCod, T005C2_A1316MVLEComCueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z1315MVLEComAux, T005C2_A1315MVLEComAux[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1343MVLESubAfecto != T005C2_A1343MVLESubAfecto[0] ) || ( Z1344MVLESubInafecto != T005C2_A1344MVLESubInafecto[0] ) || ( Z1326MVLEIGV != T005C2_A1326MVLEIGV[0] ) || ( Z1347MVLETotal != T005C2_A1347MVLETotal[0] ) || ( Z1348MVLETotalPago != T005C2_A1348MVLETotalPago[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1340MVLEPagReg != T005C2_A1340MVLEPagReg[0] ) || ( Z1351MVLEVouAno != T005C2_A1351MVLEVouAno[0] ) || ( Z1352MVLEVouMes != T005C2_A1352MVLEVouMes[0] ) || ( Z1345MVLETASICod != T005C2_A1345MVLETASICod[0] ) || ( StringUtil.StrCmp(Z1353MVLEVouNum, T005C2_A1353MVLEVouNum[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1342MVLERedondeo != T005C2_A1342MVLERedondeo[0] ) || ( Z1319MVLEComPorIVA != T005C2_A1319MVLEComPorIVA[0] ) || ( StringUtil.StrCmp(Z1349MVLEUsuCod, T005C2_A1349MVLEUsuCod[0]) != 0 ) || ( Z1350MVLEUsuFec != T005C2_A1350MVLEUsuFec[0] ) || ( StringUtil.StrCmp(Z1320MVLEComTipReg, T005C2_A1320MVLEComTipReg[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1327MVLEMBanCod != T005C2_A1327MVLEMBanCod[0] ) || ( StringUtil.StrCmp(Z1330MVLEMCtaBco, T005C2_A1330MVLEMCtaBco[0]) != 0 ) || ( StringUtil.StrCmp(Z1329MVLEMBanReg, T005C2_A1329MVLEMBanReg[0]) != 0 ) || ( Z1328MVLEMBanCon != T005C2_A1328MVLEMBanCon[0] ) || ( StringUtil.StrCmp(Z1331MVLEMTipo, T005C2_A1331MVLEMTipo[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z411MVLConcEntCod != T005C2_A411MVLConcEntCod[0] ) || ( StringUtil.StrCmp(Z409MVLECosCod, T005C2_A409MVLECosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z410MVLEComCosCod, T005C2_A410MVLEComCosCod[0]) != 0 ) || ( StringUtil.StrCmp(Z408MVLEPrvCod, T005C2_A408MVLEPrvCod[0]) != 0 ) || ( StringUtil.StrCmp(Z407MVLECueCod, T005C2_A407MVLECueCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z406MVLEForCod != T005C2_A406MVLEForCod[0] ) || ( Z405MVLEMonCod != T005C2_A405MVLEMonCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z1335MVLEntFec ) != DateTimeUtil.ResetTime ( T005C2_A1335MVLEntFec[0] ) )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntFec");
                  GXUtil.WriteLogRaw("Old: ",Z1335MVLEntFec);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1335MVLEntFec[0]);
               }
               if ( StringUtil.StrCmp(Z1333MVLEntDoc, T005C2_A1333MVLEntDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1333MVLEntDoc);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1333MVLEntDoc[0]);
               }
               if ( StringUtil.StrCmp(Z1332MVLEntConc, T005C2_A1332MVLEntConc[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntConc");
                  GXUtil.WriteLogRaw("Old: ",Z1332MVLEntConc);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1332MVLEntConc[0]);
               }
               if ( StringUtil.StrCmp(Z1322MVLECueCodAux, T005C2_A1322MVLECueCodAux[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLECueCodAux");
                  GXUtil.WriteLogRaw("Old: ",Z1322MVLECueCodAux);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1322MVLECueCodAux[0]);
               }
               if ( StringUtil.StrCmp(Z1321MVLECueAuxCod, T005C2_A1321MVLECueAuxCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLECueAuxCod");
                  GXUtil.WriteLogRaw("Old: ",Z1321MVLECueAuxCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1321MVLECueAuxCod[0]);
               }
               if ( Z1336MVLEntImp != T005C2_A1336MVLEntImp[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntImp");
                  GXUtil.WriteLogRaw("Old: ",Z1336MVLEntImp);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1336MVLEntImp[0]);
               }
               if ( StringUtil.StrCmp(Z1346MVLETipo, T005C2_A1346MVLETipo[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLETipo");
                  GXUtil.WriteLogRaw("Old: ",Z1346MVLETipo);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1346MVLETipo[0]);
               }
               if ( StringUtil.StrCmp(Z1339MVLEntTCod, T005C2_A1339MVLEntTCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntTCod");
                  GXUtil.WriteLogRaw("Old: ",Z1339MVLEntTCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1339MVLEntTCod[0]);
               }
               if ( StringUtil.StrCmp(Z1334MVLEntDocP, T005C2_A1334MVLEntDocP[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntDocP");
                  GXUtil.WriteLogRaw("Old: ",Z1334MVLEntDocP);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1334MVLEntDocP[0]);
               }
               if ( StringUtil.StrCmp(Z1337MVLEntReg, T005C2_A1337MVLEntReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntReg");
                  GXUtil.WriteLogRaw("Old: ",Z1337MVLEntReg);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1337MVLEntReg[0]);
               }
               if ( Z1338MVLEntTCmb != T005C2_A1338MVLEntTCmb[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEntTCmb");
                  GXUtil.WriteLogRaw("Old: ",Z1338MVLEntTCmb);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1338MVLEntTCmb[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1317MVLEComFec ) != DateTimeUtil.ResetTime ( T005C2_A1317MVLEComFec[0] ) )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEComFec");
                  GXUtil.WriteLogRaw("Old: ",Z1317MVLEComFec);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1317MVLEComFec[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1318MVLEComFReg ) != DateTimeUtil.ResetTime ( T005C2_A1318MVLEComFReg[0] ) )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEComFReg");
                  GXUtil.WriteLogRaw("Old: ",Z1318MVLEComFReg);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1318MVLEComFReg[0]);
               }
               if ( StringUtil.StrCmp(Z1316MVLEComCueCod, T005C2_A1316MVLEComCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEComCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z1316MVLEComCueCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1316MVLEComCueCod[0]);
               }
               if ( StringUtil.StrCmp(Z1315MVLEComAux, T005C2_A1315MVLEComAux[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEComAux");
                  GXUtil.WriteLogRaw("Old: ",Z1315MVLEComAux);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1315MVLEComAux[0]);
               }
               if ( Z1343MVLESubAfecto != T005C2_A1343MVLESubAfecto[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLESubAfecto");
                  GXUtil.WriteLogRaw("Old: ",Z1343MVLESubAfecto);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1343MVLESubAfecto[0]);
               }
               if ( Z1344MVLESubInafecto != T005C2_A1344MVLESubInafecto[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLESubInafecto");
                  GXUtil.WriteLogRaw("Old: ",Z1344MVLESubInafecto);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1344MVLESubInafecto[0]);
               }
               if ( Z1326MVLEIGV != T005C2_A1326MVLEIGV[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEIGV");
                  GXUtil.WriteLogRaw("Old: ",Z1326MVLEIGV);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1326MVLEIGV[0]);
               }
               if ( Z1347MVLETotal != T005C2_A1347MVLETotal[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLETotal");
                  GXUtil.WriteLogRaw("Old: ",Z1347MVLETotal);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1347MVLETotal[0]);
               }
               if ( Z1348MVLETotalPago != T005C2_A1348MVLETotalPago[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLETotalPago");
                  GXUtil.WriteLogRaw("Old: ",Z1348MVLETotalPago);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1348MVLETotalPago[0]);
               }
               if ( Z1340MVLEPagReg != T005C2_A1340MVLEPagReg[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEPagReg");
                  GXUtil.WriteLogRaw("Old: ",Z1340MVLEPagReg);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1340MVLEPagReg[0]);
               }
               if ( Z1351MVLEVouAno != T005C2_A1351MVLEVouAno[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1351MVLEVouAno);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1351MVLEVouAno[0]);
               }
               if ( Z1352MVLEVouMes != T005C2_A1352MVLEVouMes[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1352MVLEVouMes);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1352MVLEVouMes[0]);
               }
               if ( Z1345MVLETASICod != T005C2_A1345MVLETASICod[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLETASICod");
                  GXUtil.WriteLogRaw("Old: ",Z1345MVLETASICod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1345MVLETASICod[0]);
               }
               if ( StringUtil.StrCmp(Z1353MVLEVouNum, T005C2_A1353MVLEVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1353MVLEVouNum);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1353MVLEVouNum[0]);
               }
               if ( Z1342MVLERedondeo != T005C2_A1342MVLERedondeo[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLERedondeo");
                  GXUtil.WriteLogRaw("Old: ",Z1342MVLERedondeo);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1342MVLERedondeo[0]);
               }
               if ( Z1319MVLEComPorIVA != T005C2_A1319MVLEComPorIVA[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEComPorIVA");
                  GXUtil.WriteLogRaw("Old: ",Z1319MVLEComPorIVA);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1319MVLEComPorIVA[0]);
               }
               if ( StringUtil.StrCmp(Z1349MVLEUsuCod, T005C2_A1349MVLEUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1349MVLEUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1349MVLEUsuCod[0]);
               }
               if ( Z1350MVLEUsuFec != T005C2_A1350MVLEUsuFec[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1350MVLEUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1350MVLEUsuFec[0]);
               }
               if ( StringUtil.StrCmp(Z1320MVLEComTipReg, T005C2_A1320MVLEComTipReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEComTipReg");
                  GXUtil.WriteLogRaw("Old: ",Z1320MVLEComTipReg);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1320MVLEComTipReg[0]);
               }
               if ( Z1327MVLEMBanCod != T005C2_A1327MVLEMBanCod[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEMBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z1327MVLEMBanCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1327MVLEMBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z1330MVLEMCtaBco, T005C2_A1330MVLEMCtaBco[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEMCtaBco");
                  GXUtil.WriteLogRaw("Old: ",Z1330MVLEMCtaBco);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1330MVLEMCtaBco[0]);
               }
               if ( StringUtil.StrCmp(Z1329MVLEMBanReg, T005C2_A1329MVLEMBanReg[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEMBanReg");
                  GXUtil.WriteLogRaw("Old: ",Z1329MVLEMBanReg);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1329MVLEMBanReg[0]);
               }
               if ( Z1328MVLEMBanCon != T005C2_A1328MVLEMBanCon[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEMBanCon");
                  GXUtil.WriteLogRaw("Old: ",Z1328MVLEMBanCon);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1328MVLEMBanCon[0]);
               }
               if ( StringUtil.StrCmp(Z1331MVLEMTipo, T005C2_A1331MVLEMTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEMTipo");
                  GXUtil.WriteLogRaw("Old: ",Z1331MVLEMTipo);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A1331MVLEMTipo[0]);
               }
               if ( Z411MVLConcEntCod != T005C2_A411MVLConcEntCod[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLConcEntCod");
                  GXUtil.WriteLogRaw("Old: ",Z411MVLConcEntCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A411MVLConcEntCod[0]);
               }
               if ( StringUtil.StrCmp(Z409MVLECosCod, T005C2_A409MVLECosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLECosCod");
                  GXUtil.WriteLogRaw("Old: ",Z409MVLECosCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A409MVLECosCod[0]);
               }
               if ( StringUtil.StrCmp(Z410MVLEComCosCod, T005C2_A410MVLEComCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEComCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z410MVLEComCosCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A410MVLEComCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z408MVLEPrvCod, T005C2_A408MVLEPrvCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEPrvCod");
                  GXUtil.WriteLogRaw("Old: ",Z408MVLEPrvCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A408MVLEPrvCod[0]);
               }
               if ( StringUtil.StrCmp(Z407MVLECueCod, T005C2_A407MVLECueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLECueCod");
                  GXUtil.WriteLogRaw("Old: ",Z407MVLECueCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A407MVLECueCod[0]);
               }
               if ( Z406MVLEForCod != T005C2_A406MVLEForCod[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEForCod");
                  GXUtil.WriteLogRaw("Old: ",Z406MVLEForCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A406MVLEForCod[0]);
               }
               if ( Z405MVLEMonCod != T005C2_A405MVLEMonCod[0] )
               {
                  GXUtil.WriteLog("tsmoventrega:[seudo value changed for attri]"+"MVLEMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z405MVLEMonCod);
                  GXUtil.WriteLogRaw("Current: ",T005C2_A405MVLEMonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSMOVENTREGA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5C179( )
      {
         BeforeValidate5C179( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5C179( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5C179( 0) ;
            CheckOptimisticConcurrency5C179( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5C179( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5C179( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005C26 */
                     pr_default.execute(24, new Object[] {A403MVLEntCod, A404MVLEITem, A1335MVLEntFec, A1333MVLEntDoc, A1332MVLEntConc, A1322MVLECueCodAux, A1321MVLECueAuxCod, A1336MVLEntImp, A1346MVLETipo, A1339MVLEntTCod, A1334MVLEntDocP, A1337MVLEntReg, A1338MVLEntTCmb, A1317MVLEComFec, A1318MVLEComFReg, A1316MVLEComCueCod, A1315MVLEComAux, A1343MVLESubAfecto, A1344MVLESubInafecto, A1326MVLEIGV, A1347MVLETotal, A1348MVLETotalPago, A1340MVLEPagReg, A1351MVLEVouAno, A1352MVLEVouMes, A1345MVLETASICod, A1353MVLEVouNum, A1342MVLERedondeo, A1319MVLEComPorIVA, A1349MVLEUsuCod, A1350MVLEUsuFec, A1320MVLEComTipReg, A1327MVLEMBanCod, A1330MVLEMCtaBco, A1329MVLEMBanReg, n1328MVLEMBanCon, A1328MVLEMBanCon, A1331MVLEMTipo, A365EntCod, A411MVLConcEntCod, n409MVLECosCod, A409MVLECosCod, n410MVLEComCosCod, A410MVLEComCosCod, A408MVLEPrvCod, A407MVLECueCod, n406MVLEForCod, A406MVLEForCod, A405MVLEMonCod});
                     pr_default.close(24);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVENTREGA");
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
                           ResetCaption5C0( ) ;
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
               Load5C179( ) ;
            }
            EndLevel5C179( ) ;
         }
         CloseExtendedTableCursors5C179( ) ;
      }

      protected void Update5C179( )
      {
         BeforeValidate5C179( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5C179( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5C179( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5C179( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5C179( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005C27 */
                     pr_default.execute(25, new Object[] {A1335MVLEntFec, A1333MVLEntDoc, A1332MVLEntConc, A1322MVLECueCodAux, A1321MVLECueAuxCod, A1336MVLEntImp, A1346MVLETipo, A1339MVLEntTCod, A1334MVLEntDocP, A1337MVLEntReg, A1338MVLEntTCmb, A1317MVLEComFec, A1318MVLEComFReg, A1316MVLEComCueCod, A1315MVLEComAux, A1343MVLESubAfecto, A1344MVLESubInafecto, A1326MVLEIGV, A1347MVLETotal, A1348MVLETotalPago, A1340MVLEPagReg, A1351MVLEVouAno, A1352MVLEVouMes, A1345MVLETASICod, A1353MVLEVouNum, A1342MVLERedondeo, A1319MVLEComPorIVA, A1349MVLEUsuCod, A1350MVLEUsuFec, A1320MVLEComTipReg, A1327MVLEMBanCod, A1330MVLEMCtaBco, A1329MVLEMBanReg, n1328MVLEMBanCon, A1328MVLEMBanCon, A1331MVLEMTipo, A411MVLConcEntCod, n409MVLECosCod, A409MVLECosCod, n410MVLEComCosCod, A410MVLEComCosCod, A408MVLEPrvCod, A407MVLECueCod, n406MVLEForCod, A406MVLEForCod, A405MVLEMonCod, A365EntCod, A403MVLEntCod, A404MVLEITem});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("TSMOVENTREGA");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSMOVENTREGA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5C179( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption5C0( ) ;
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
            EndLevel5C179( ) ;
         }
         CloseExtendedTableCursors5C179( ) ;
      }

      protected void DeferredUpdate5C179( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate5C179( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5C179( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5C179( ) ;
            AfterConfirm5C179( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5C179( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005C28 */
                  pr_default.execute(26, new Object[] {A365EntCod, A403MVLEntCod, A404MVLEITem});
                  pr_default.close(26);
                  dsDefault.SmartCacheProvider.SetUpdated("TSMOVENTREGA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound179 == 0 )
                        {
                           InitAll5C179( ) ;
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
                        ResetCaption5C0( ) ;
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
         sMode179 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5C179( ) ;
         Gx_mode = sMode179;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5C179( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T005C29 */
            pr_default.execute(27, new Object[] {A411MVLConcEntCod});
            A1309MVLConEntDsc = T005C29_A1309MVLConEntDsc[0];
            AssignAttri("", false, "A1309MVLConEntDsc", A1309MVLConEntDsc);
            A1308MVLConEntCue = T005C29_A1308MVLConEntCue[0];
            AssignAttri("", false, "A1308MVLConEntCue", A1308MVLConEntCue);
            pr_default.close(27);
            /* Using cursor T005C30 */
            pr_default.execute(28, new Object[] {A1308MVLConEntCue});
            A1323MVLECueCos = T005C30_A1323MVLECueCos[0];
            AssignAttri("", false, "A1323MVLECueCos", StringUtil.Str( (decimal)(A1323MVLECueCos), 1, 0));
            pr_default.close(28);
            /* Using cursor T005C31 */
            pr_default.execute(29, new Object[] {A408MVLEPrvCod});
            A1341MVLEPrvDsc = T005C31_A1341MVLEPrvDsc[0];
            AssignAttri("", false, "A1341MVLEPrvDsc", A1341MVLEPrvDsc);
            pr_default.close(29);
            /* Using cursor T005C32 */
            pr_default.execute(30, new Object[] {A407MVLECueCod});
            A1325MVLECueDsc = T005C32_A1325MVLECueDsc[0];
            AssignAttri("", false, "A1325MVLECueDsc", A1325MVLECueDsc);
            A1324MVLECueCosCod = T005C32_A1324MVLECueCosCod[0];
            AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.Str( (decimal)(A1324MVLECueCosCod), 1, 0));
            pr_default.close(30);
         }
      }

      protected void EndLevel5C179( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5C179( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(27);
            pr_default.close(29);
            pr_default.close(30);
            pr_default.close(28);
            context.CommitDataStores("tsmoventrega",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5C0( ) ;
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
            context.RollbackDataStores("tsmoventrega",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5C179( )
      {
         /* Using cursor T005C33 */
         pr_default.execute(31);
         RcdFound179 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound179 = 1;
            A365EntCod = T005C33_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A403MVLEntCod = T005C33_A403MVLEntCod[0];
            AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
            A404MVLEITem = T005C33_A404MVLEITem[0];
            AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5C179( )
      {
         /* Scan next routine */
         pr_default.readNext(31);
         RcdFound179 = 0;
         if ( (pr_default.getStatus(31) != 101) )
         {
            RcdFound179 = 1;
            A365EntCod = T005C33_A365EntCod[0];
            AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
            A403MVLEntCod = T005C33_A403MVLEntCod[0];
            AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
            A404MVLEITem = T005C33_A404MVLEITem[0];
            AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
         }
      }

      protected void ScanEnd5C179( )
      {
         pr_default.close(31);
      }

      protected void AfterConfirm5C179( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5C179( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5C179( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5C179( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5C179( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5C179( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5C179( )
      {
         edtEntCod_Enabled = 0;
         AssignProp("", false, edtEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEntCod_Enabled), 5, 0), true);
         edtMVLEntCod_Enabled = 0;
         AssignProp("", false, edtMVLEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntCod_Enabled), 5, 0), true);
         edtMVLEITem_Enabled = 0;
         AssignProp("", false, edtMVLEITem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEITem_Enabled), 5, 0), true);
         edtMVLEntFec_Enabled = 0;
         AssignProp("", false, edtMVLEntFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntFec_Enabled), 5, 0), true);
         edtMVLEntDoc_Enabled = 0;
         AssignProp("", false, edtMVLEntDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntDoc_Enabled), 5, 0), true);
         edtMVLEntConc_Enabled = 0;
         AssignProp("", false, edtMVLEntConc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntConc_Enabled), 5, 0), true);
         edtMVLConcEntCod_Enabled = 0;
         AssignProp("", false, edtMVLConcEntCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLConcEntCod_Enabled), 5, 0), true);
         edtMVLECueCodAux_Enabled = 0;
         AssignProp("", false, edtMVLECueCodAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLECueCodAux_Enabled), 5, 0), true);
         edtMVLECueAuxCod_Enabled = 0;
         AssignProp("", false, edtMVLECueAuxCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLECueAuxCod_Enabled), 5, 0), true);
         edtMVLECosCod_Enabled = 0;
         AssignProp("", false, edtMVLECosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLECosCod_Enabled), 5, 0), true);
         edtMVLEntImp_Enabled = 0;
         AssignProp("", false, edtMVLEntImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntImp_Enabled), 5, 0), true);
         edtMVLETipo_Enabled = 0;
         AssignProp("", false, edtMVLETipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLETipo_Enabled), 5, 0), true);
         edtMVLEPrvCod_Enabled = 0;
         AssignProp("", false, edtMVLEPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEPrvCod_Enabled), 5, 0), true);
         edtMVLEntTCod_Enabled = 0;
         AssignProp("", false, edtMVLEntTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntTCod_Enabled), 5, 0), true);
         edtMVLEntDocP_Enabled = 0;
         AssignProp("", false, edtMVLEntDocP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntDocP_Enabled), 5, 0), true);
         edtMVLEntReg_Enabled = 0;
         AssignProp("", false, edtMVLEntReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntReg_Enabled), 5, 0), true);
         edtMVLEntTCmb_Enabled = 0;
         AssignProp("", false, edtMVLEntTCmb_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEntTCmb_Enabled), 5, 0), true);
         edtMVLEComFec_Enabled = 0;
         AssignProp("", false, edtMVLEComFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEComFec_Enabled), 5, 0), true);
         edtMVLEComFReg_Enabled = 0;
         AssignProp("", false, edtMVLEComFReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEComFReg_Enabled), 5, 0), true);
         edtMVLECueCod_Enabled = 0;
         AssignProp("", false, edtMVLECueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLECueCod_Enabled), 5, 0), true);
         edtMVLEComCosCod_Enabled = 0;
         AssignProp("", false, edtMVLEComCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEComCosCod_Enabled), 5, 0), true);
         edtMVLEComCueCod_Enabled = 0;
         AssignProp("", false, edtMVLEComCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEComCueCod_Enabled), 5, 0), true);
         edtMVLEComAux_Enabled = 0;
         AssignProp("", false, edtMVLEComAux_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEComAux_Enabled), 5, 0), true);
         edtMVLESubAfecto_Enabled = 0;
         AssignProp("", false, edtMVLESubAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLESubAfecto_Enabled), 5, 0), true);
         edtMVLESubInafecto_Enabled = 0;
         AssignProp("", false, edtMVLESubInafecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLESubInafecto_Enabled), 5, 0), true);
         edtMVLEIGV_Enabled = 0;
         AssignProp("", false, edtMVLEIGV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEIGV_Enabled), 5, 0), true);
         edtMVLETotal_Enabled = 0;
         AssignProp("", false, edtMVLETotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLETotal_Enabled), 5, 0), true);
         edtMVLETotalPago_Enabled = 0;
         AssignProp("", false, edtMVLETotalPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLETotalPago_Enabled), 5, 0), true);
         edtMVLEForCod_Enabled = 0;
         AssignProp("", false, edtMVLEForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEForCod_Enabled), 5, 0), true);
         edtMVLEPagReg_Enabled = 0;
         AssignProp("", false, edtMVLEPagReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEPagReg_Enabled), 5, 0), true);
         edtMVLEVouAno_Enabled = 0;
         AssignProp("", false, edtMVLEVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEVouAno_Enabled), 5, 0), true);
         edtMVLEVouMes_Enabled = 0;
         AssignProp("", false, edtMVLEVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEVouMes_Enabled), 5, 0), true);
         edtMVLETASICod_Enabled = 0;
         AssignProp("", false, edtMVLETASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLETASICod_Enabled), 5, 0), true);
         edtMVLEVouNum_Enabled = 0;
         AssignProp("", false, edtMVLEVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEVouNum_Enabled), 5, 0), true);
         edtMVLEMonCod_Enabled = 0;
         AssignProp("", false, edtMVLEMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEMonCod_Enabled), 5, 0), true);
         edtMVLERedondeo_Enabled = 0;
         AssignProp("", false, edtMVLERedondeo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLERedondeo_Enabled), 5, 0), true);
         edtMVLEComPorIVA_Enabled = 0;
         AssignProp("", false, edtMVLEComPorIVA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEComPorIVA_Enabled), 5, 0), true);
         edtMVLEUsuCod_Enabled = 0;
         AssignProp("", false, edtMVLEUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEUsuCod_Enabled), 5, 0), true);
         edtMVLEUsuFec_Enabled = 0;
         AssignProp("", false, edtMVLEUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEUsuFec_Enabled), 5, 0), true);
         edtMVLEComTipReg_Enabled = 0;
         AssignProp("", false, edtMVLEComTipReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEComTipReg_Enabled), 5, 0), true);
         edtMVLECueCos_Enabled = 0;
         AssignProp("", false, edtMVLECueCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLECueCos_Enabled), 5, 0), true);
         edtMVLConEntDsc_Enabled = 0;
         AssignProp("", false, edtMVLConEntDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLConEntDsc_Enabled), 5, 0), true);
         edtMVLConEntCue_Enabled = 0;
         AssignProp("", false, edtMVLConEntCue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLConEntCue_Enabled), 5, 0), true);
         edtMVLEPrvDsc_Enabled = 0;
         AssignProp("", false, edtMVLEPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLEPrvDsc_Enabled), 5, 0), true);
         edtMVLECueDsc_Enabled = 0;
         AssignProp("", false, edtMVLECueDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLECueDsc_Enabled), 5, 0), true);
         edtMVLECueCosCod_Enabled = 0;
         AssignProp("", false, edtMVLECueCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVLECueCosCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5C179( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5C0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026359", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("tsmoventrega.aspx") +"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"TSMOVENTREGA");
         forbiddenHiddens.Add("MVLEMBanCod", context.localUtil.Format( (decimal)(A1327MVLEMBanCod), "ZZZZZ9"));
         forbiddenHiddens.Add("MVLEMCtaBco", StringUtil.RTrim( context.localUtil.Format( A1330MVLEMCtaBco, "")));
         forbiddenHiddens.Add("MVLEMBanReg", StringUtil.RTrim( context.localUtil.Format( A1329MVLEMBanReg, "")));
         forbiddenHiddens.Add("MVLEMBanCon", context.localUtil.Format( (decimal)(A1328MVLEMBanCon), "ZZZZZ9"));
         forbiddenHiddens.Add("MVLEMTipo", StringUtil.RTrim( context.localUtil.Format( A1331MVLEMTipo, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("tsmoventrega:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z365EntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z403MVLEntCod", StringUtil.RTrim( Z403MVLEntCod));
         GxWebStd.gx_hidden_field( context, "Z404MVLEITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z404MVLEITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1335MVLEntFec", context.localUtil.DToC( Z1335MVLEntFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1333MVLEntDoc", StringUtil.RTrim( Z1333MVLEntDoc));
         GxWebStd.gx_hidden_field( context, "Z1332MVLEntConc", StringUtil.RTrim( Z1332MVLEntConc));
         GxWebStd.gx_hidden_field( context, "Z1322MVLECueCodAux", StringUtil.RTrim( Z1322MVLECueCodAux));
         GxWebStd.gx_hidden_field( context, "Z1321MVLECueAuxCod", StringUtil.RTrim( Z1321MVLECueAuxCod));
         GxWebStd.gx_hidden_field( context, "Z1336MVLEntImp", StringUtil.LTrim( StringUtil.NToC( Z1336MVLEntImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1346MVLETipo", StringUtil.RTrim( Z1346MVLETipo));
         GxWebStd.gx_hidden_field( context, "Z1339MVLEntTCod", StringUtil.RTrim( Z1339MVLEntTCod));
         GxWebStd.gx_hidden_field( context, "Z1334MVLEntDocP", StringUtil.RTrim( Z1334MVLEntDocP));
         GxWebStd.gx_hidden_field( context, "Z1337MVLEntReg", StringUtil.RTrim( Z1337MVLEntReg));
         GxWebStd.gx_hidden_field( context, "Z1338MVLEntTCmb", StringUtil.LTrim( StringUtil.NToC( Z1338MVLEntTCmb, 10, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1317MVLEComFec", context.localUtil.DToC( Z1317MVLEComFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1318MVLEComFReg", context.localUtil.DToC( Z1318MVLEComFReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1316MVLEComCueCod", StringUtil.RTrim( Z1316MVLEComCueCod));
         GxWebStd.gx_hidden_field( context, "Z1315MVLEComAux", StringUtil.RTrim( Z1315MVLEComAux));
         GxWebStd.gx_hidden_field( context, "Z1343MVLESubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1343MVLESubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1344MVLESubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1344MVLESubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1326MVLEIGV", StringUtil.LTrim( StringUtil.NToC( Z1326MVLEIGV, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1347MVLETotal", StringUtil.LTrim( StringUtil.NToC( Z1347MVLETotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1348MVLETotalPago", StringUtil.LTrim( StringUtil.NToC( Z1348MVLETotalPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1340MVLEPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1340MVLEPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1351MVLEVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1351MVLEVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1352MVLEVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1352MVLEVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1345MVLETASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1345MVLETASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1353MVLEVouNum", StringUtil.RTrim( Z1353MVLEVouNum));
         GxWebStd.gx_hidden_field( context, "Z1342MVLERedondeo", StringUtil.LTrim( StringUtil.NToC( Z1342MVLERedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1319MVLEComPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1319MVLEComPorIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1349MVLEUsuCod", StringUtil.RTrim( Z1349MVLEUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1350MVLEUsuFec", context.localUtil.TToC( Z1350MVLEUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1320MVLEComTipReg", StringUtil.RTrim( Z1320MVLEComTipReg));
         GxWebStd.gx_hidden_field( context, "Z1327MVLEMBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1327MVLEMBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1330MVLEMCtaBco", StringUtil.RTrim( Z1330MVLEMCtaBco));
         GxWebStd.gx_hidden_field( context, "Z1329MVLEMBanReg", Z1329MVLEMBanReg);
         GxWebStd.gx_hidden_field( context, "Z1328MVLEMBanCon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1328MVLEMBanCon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1331MVLEMTipo", Z1331MVLEMTipo);
         GxWebStd.gx_hidden_field( context, "Z411MVLConcEntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z411MVLConcEntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z409MVLECosCod", StringUtil.RTrim( Z409MVLECosCod));
         GxWebStd.gx_hidden_field( context, "Z410MVLEComCosCod", StringUtil.RTrim( Z410MVLEComCosCod));
         GxWebStd.gx_hidden_field( context, "Z408MVLEPrvCod", StringUtil.RTrim( Z408MVLEPrvCod));
         GxWebStd.gx_hidden_field( context, "Z407MVLECueCod", StringUtil.RTrim( Z407MVLECueCod));
         GxWebStd.gx_hidden_field( context, "Z406MVLEForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z406MVLEForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z405MVLEMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405MVLEMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "MVLEMBANCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1327MVLEMBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MVLEMCTABCO", StringUtil.RTrim( A1330MVLEMCtaBco));
         GxWebStd.gx_hidden_field( context, "MVLEMBANREG", A1329MVLEMBanReg);
         GxWebStd.gx_hidden_field( context, "MVLEMBANCON", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1328MVLEMBanCon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "MVLEMTIPO", A1331MVLEMTipo);
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
         return formatLink("tsmoventrega.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "TSMOVENTREGA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimientos de Entrega a Rendir" ;
      }

      protected void InitializeNonKey5C179( )
      {
         A1335MVLEntFec = DateTime.MinValue;
         AssignAttri("", false, "A1335MVLEntFec", context.localUtil.Format(A1335MVLEntFec, "99/99/99"));
         A1333MVLEntDoc = "";
         AssignAttri("", false, "A1333MVLEntDoc", A1333MVLEntDoc);
         A1332MVLEntConc = "";
         AssignAttri("", false, "A1332MVLEntConc", A1332MVLEntConc);
         A411MVLConcEntCod = 0;
         AssignAttri("", false, "A411MVLConcEntCod", StringUtil.LTrimStr( (decimal)(A411MVLConcEntCod), 6, 0));
         A1322MVLECueCodAux = "";
         AssignAttri("", false, "A1322MVLECueCodAux", A1322MVLECueCodAux);
         A1321MVLECueAuxCod = "";
         AssignAttri("", false, "A1321MVLECueAuxCod", A1321MVLECueAuxCod);
         A409MVLECosCod = "";
         n409MVLECosCod = false;
         AssignAttri("", false, "A409MVLECosCod", A409MVLECosCod);
         A1336MVLEntImp = 0;
         AssignAttri("", false, "A1336MVLEntImp", StringUtil.LTrimStr( A1336MVLEntImp, 15, 2));
         A1346MVLETipo = "";
         AssignAttri("", false, "A1346MVLETipo", A1346MVLETipo);
         A408MVLEPrvCod = "";
         AssignAttri("", false, "A408MVLEPrvCod", A408MVLEPrvCod);
         A1339MVLEntTCod = "";
         AssignAttri("", false, "A1339MVLEntTCod", A1339MVLEntTCod);
         A1334MVLEntDocP = "";
         AssignAttri("", false, "A1334MVLEntDocP", A1334MVLEntDocP);
         A1337MVLEntReg = "";
         AssignAttri("", false, "A1337MVLEntReg", A1337MVLEntReg);
         A1338MVLEntTCmb = 0;
         AssignAttri("", false, "A1338MVLEntTCmb", StringUtil.LTrimStr( A1338MVLEntTCmb, 10, 4));
         A1317MVLEComFec = DateTime.MinValue;
         AssignAttri("", false, "A1317MVLEComFec", context.localUtil.Format(A1317MVLEComFec, "99/99/99"));
         A1318MVLEComFReg = DateTime.MinValue;
         AssignAttri("", false, "A1318MVLEComFReg", context.localUtil.Format(A1318MVLEComFReg, "99/99/99"));
         A407MVLECueCod = "";
         AssignAttri("", false, "A407MVLECueCod", A407MVLECueCod);
         A410MVLEComCosCod = "";
         n410MVLEComCosCod = false;
         AssignAttri("", false, "A410MVLEComCosCod", A410MVLEComCosCod);
         A1316MVLEComCueCod = "";
         AssignAttri("", false, "A1316MVLEComCueCod", A1316MVLEComCueCod);
         A1315MVLEComAux = "";
         AssignAttri("", false, "A1315MVLEComAux", A1315MVLEComAux);
         A1343MVLESubAfecto = 0;
         AssignAttri("", false, "A1343MVLESubAfecto", StringUtil.LTrimStr( A1343MVLESubAfecto, 15, 2));
         A1344MVLESubInafecto = 0;
         AssignAttri("", false, "A1344MVLESubInafecto", StringUtil.LTrimStr( A1344MVLESubInafecto, 15, 2));
         A1326MVLEIGV = 0;
         AssignAttri("", false, "A1326MVLEIGV", StringUtil.LTrimStr( A1326MVLEIGV, 15, 2));
         A1347MVLETotal = 0;
         AssignAttri("", false, "A1347MVLETotal", StringUtil.LTrimStr( A1347MVLETotal, 15, 2));
         A1348MVLETotalPago = 0;
         AssignAttri("", false, "A1348MVLETotalPago", StringUtil.LTrimStr( A1348MVLETotalPago, 15, 2));
         A406MVLEForCod = 0;
         n406MVLEForCod = false;
         AssignAttri("", false, "A406MVLEForCod", StringUtil.LTrimStr( (decimal)(A406MVLEForCod), 6, 0));
         A1340MVLEPagReg = 0;
         AssignAttri("", false, "A1340MVLEPagReg", StringUtil.LTrimStr( (decimal)(A1340MVLEPagReg), 10, 0));
         A1351MVLEVouAno = 0;
         AssignAttri("", false, "A1351MVLEVouAno", StringUtil.LTrimStr( (decimal)(A1351MVLEVouAno), 4, 0));
         A1352MVLEVouMes = 0;
         AssignAttri("", false, "A1352MVLEVouMes", StringUtil.LTrimStr( (decimal)(A1352MVLEVouMes), 2, 0));
         A1345MVLETASICod = 0;
         AssignAttri("", false, "A1345MVLETASICod", StringUtil.LTrimStr( (decimal)(A1345MVLETASICod), 6, 0));
         A1353MVLEVouNum = "";
         AssignAttri("", false, "A1353MVLEVouNum", A1353MVLEVouNum);
         A405MVLEMonCod = 0;
         AssignAttri("", false, "A405MVLEMonCod", StringUtil.LTrimStr( (decimal)(A405MVLEMonCod), 6, 0));
         A1342MVLERedondeo = 0;
         AssignAttri("", false, "A1342MVLERedondeo", StringUtil.LTrimStr( A1342MVLERedondeo, 15, 2));
         A1319MVLEComPorIVA = 0;
         AssignAttri("", false, "A1319MVLEComPorIVA", StringUtil.LTrimStr( A1319MVLEComPorIVA, 15, 2));
         A1349MVLEUsuCod = "";
         AssignAttri("", false, "A1349MVLEUsuCod", A1349MVLEUsuCod);
         A1350MVLEUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1350MVLEUsuFec", context.localUtil.TToC( A1350MVLEUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1320MVLEComTipReg = "";
         AssignAttri("", false, "A1320MVLEComTipReg", A1320MVLEComTipReg);
         A1323MVLECueCos = 0;
         AssignAttri("", false, "A1323MVLECueCos", StringUtil.Str( (decimal)(A1323MVLECueCos), 1, 0));
         A1309MVLConEntDsc = "";
         AssignAttri("", false, "A1309MVLConEntDsc", A1309MVLConEntDsc);
         A1308MVLConEntCue = "";
         AssignAttri("", false, "A1308MVLConEntCue", A1308MVLConEntCue);
         A1341MVLEPrvDsc = "";
         AssignAttri("", false, "A1341MVLEPrvDsc", A1341MVLEPrvDsc);
         A1325MVLECueDsc = "";
         AssignAttri("", false, "A1325MVLECueDsc", A1325MVLECueDsc);
         A1324MVLECueCosCod = 0;
         AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.Str( (decimal)(A1324MVLECueCosCod), 1, 0));
         A1327MVLEMBanCod = 0;
         AssignAttri("", false, "A1327MVLEMBanCod", StringUtil.LTrimStr( (decimal)(A1327MVLEMBanCod), 6, 0));
         A1330MVLEMCtaBco = "";
         AssignAttri("", false, "A1330MVLEMCtaBco", A1330MVLEMCtaBco);
         A1329MVLEMBanReg = "";
         AssignAttri("", false, "A1329MVLEMBanReg", A1329MVLEMBanReg);
         A1328MVLEMBanCon = 0;
         n1328MVLEMBanCon = false;
         AssignAttri("", false, "A1328MVLEMBanCon", StringUtil.LTrimStr( (decimal)(A1328MVLEMBanCon), 6, 0));
         A1331MVLEMTipo = "";
         AssignAttri("", false, "A1331MVLEMTipo", A1331MVLEMTipo);
         Z1335MVLEntFec = DateTime.MinValue;
         Z1333MVLEntDoc = "";
         Z1332MVLEntConc = "";
         Z1322MVLECueCodAux = "";
         Z1321MVLECueAuxCod = "";
         Z1336MVLEntImp = 0;
         Z1346MVLETipo = "";
         Z1339MVLEntTCod = "";
         Z1334MVLEntDocP = "";
         Z1337MVLEntReg = "";
         Z1338MVLEntTCmb = 0;
         Z1317MVLEComFec = DateTime.MinValue;
         Z1318MVLEComFReg = DateTime.MinValue;
         Z1316MVLEComCueCod = "";
         Z1315MVLEComAux = "";
         Z1343MVLESubAfecto = 0;
         Z1344MVLESubInafecto = 0;
         Z1326MVLEIGV = 0;
         Z1347MVLETotal = 0;
         Z1348MVLETotalPago = 0;
         Z1340MVLEPagReg = 0;
         Z1351MVLEVouAno = 0;
         Z1352MVLEVouMes = 0;
         Z1345MVLETASICod = 0;
         Z1353MVLEVouNum = "";
         Z1342MVLERedondeo = 0;
         Z1319MVLEComPorIVA = 0;
         Z1349MVLEUsuCod = "";
         Z1350MVLEUsuFec = (DateTime)(DateTime.MinValue);
         Z1320MVLEComTipReg = "";
         Z1327MVLEMBanCod = 0;
         Z1330MVLEMCtaBco = "";
         Z1329MVLEMBanReg = "";
         Z1328MVLEMBanCon = 0;
         Z1331MVLEMTipo = "";
         Z411MVLConcEntCod = 0;
         Z409MVLECosCod = "";
         Z410MVLEComCosCod = "";
         Z408MVLEPrvCod = "";
         Z407MVLECueCod = "";
         Z406MVLEForCod = 0;
         Z405MVLEMonCod = 0;
      }

      protected void InitAll5C179( )
      {
         A365EntCod = 0;
         AssignAttri("", false, "A365EntCod", StringUtil.LTrimStr( (decimal)(A365EntCod), 6, 0));
         A403MVLEntCod = "";
         AssignAttri("", false, "A403MVLEntCod", A403MVLEntCod);
         A404MVLEITem = 0;
         AssignAttri("", false, "A404MVLEITem", StringUtil.LTrimStr( (decimal)(A404MVLEITem), 6, 0));
         InitializeNonKey5C179( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2022818102644", true, true);
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
         context.AddJavascriptSource("tsmoventrega.js", "?2022818102645", false, true);
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
         edtEntCod_Internalname = "ENTCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMVLEntCod_Internalname = "MVLENTCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtMVLEITem_Internalname = "MVLEITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtMVLEntFec_Internalname = "MVLENTFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtMVLEntDoc_Internalname = "MVLENTDOC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtMVLEntConc_Internalname = "MVLENTCONC";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtMVLConcEntCod_Internalname = "MVLCONCENTCOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtMVLECueCodAux_Internalname = "MVLECUECODAUX";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtMVLECueAuxCod_Internalname = "MVLECUEAUXCOD";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtMVLECosCod_Internalname = "MVLECOSCOD";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtMVLEntImp_Internalname = "MVLENTIMP";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtMVLETipo_Internalname = "MVLETIPO";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtMVLEPrvCod_Internalname = "MVLEPRVCOD";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtMVLEntTCod_Internalname = "MVLENTTCOD";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtMVLEntDocP_Internalname = "MVLENTDOCP";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtMVLEntReg_Internalname = "MVLENTREG";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtMVLEntTCmb_Internalname = "MVLENTTCMB";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtMVLEComFec_Internalname = "MVLECOMFEC";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtMVLEComFReg_Internalname = "MVLECOMFREG";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtMVLECueCod_Internalname = "MVLECUECOD";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtMVLEComCosCod_Internalname = "MVLECOMCOSCOD";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtMVLEComCueCod_Internalname = "MVLECOMCUECOD";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtMVLEComAux_Internalname = "MVLECOMAUX";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtMVLESubAfecto_Internalname = "MVLESUBAFECTO";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtMVLESubInafecto_Internalname = "MVLESUBINAFECTO";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtMVLEIGV_Internalname = "MVLEIGV";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtMVLETotal_Internalname = "MVLETOTAL";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtMVLETotalPago_Internalname = "MVLETOTALPAGO";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtMVLEForCod_Internalname = "MVLEFORCOD";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtMVLEPagReg_Internalname = "MVLEPAGREG";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtMVLEVouAno_Internalname = "MVLEVOUANO";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtMVLEVouMes_Internalname = "MVLEVOUMES";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtMVLETASICod_Internalname = "MVLETASICOD";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtMVLEVouNum_Internalname = "MVLEVOUNUM";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtMVLEMonCod_Internalname = "MVLEMONCOD";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtMVLERedondeo_Internalname = "MVLEREDONDEO";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtMVLEComPorIVA_Internalname = "MVLECOMPORIVA";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtMVLEUsuCod_Internalname = "MVLEUSUCOD";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtMVLEUsuFec_Internalname = "MVLEUSUFEC";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         edtMVLEComTipReg_Internalname = "MVLECOMTIPREG";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         edtMVLECueCos_Internalname = "MVLECUECOS";
         lblTextblock42_Internalname = "TEXTBLOCK42";
         edtMVLConEntDsc_Internalname = "MVLCONENTDSC";
         lblTextblock43_Internalname = "TEXTBLOCK43";
         edtMVLConEntCue_Internalname = "MVLCONENTCUE";
         lblTextblock44_Internalname = "TEXTBLOCK44";
         edtMVLEPrvDsc_Internalname = "MVLEPRVDSC";
         lblTextblock45_Internalname = "TEXTBLOCK45";
         edtMVLECueDsc_Internalname = "MVLECUEDSC";
         lblTextblock46_Internalname = "TEXTBLOCK46";
         edtMVLECueCosCod_Internalname = "MVLECUECOSCOD";
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
         Form.Caption = "Movimientos de Entrega a Rendir";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMVLECueCosCod_Jsonclick = "";
         edtMVLECueCosCod_Enabled = 0;
         edtMVLECueDsc_Jsonclick = "";
         edtMVLECueDsc_Enabled = 0;
         edtMVLEPrvDsc_Jsonclick = "";
         edtMVLEPrvDsc_Enabled = 0;
         edtMVLConEntCue_Jsonclick = "";
         edtMVLConEntCue_Enabled = 0;
         edtMVLConEntDsc_Jsonclick = "";
         edtMVLConEntDsc_Enabled = 0;
         edtMVLECueCos_Jsonclick = "";
         edtMVLECueCos_Enabled = 0;
         edtMVLEComTipReg_Jsonclick = "";
         edtMVLEComTipReg_Enabled = 1;
         edtMVLEUsuFec_Jsonclick = "";
         edtMVLEUsuFec_Enabled = 1;
         edtMVLEUsuCod_Jsonclick = "";
         edtMVLEUsuCod_Enabled = 1;
         edtMVLEComPorIVA_Jsonclick = "";
         edtMVLEComPorIVA_Enabled = 1;
         edtMVLERedondeo_Jsonclick = "";
         edtMVLERedondeo_Enabled = 1;
         edtMVLEMonCod_Jsonclick = "";
         edtMVLEMonCod_Enabled = 1;
         edtMVLEVouNum_Jsonclick = "";
         edtMVLEVouNum_Enabled = 1;
         edtMVLETASICod_Jsonclick = "";
         edtMVLETASICod_Enabled = 1;
         edtMVLEVouMes_Jsonclick = "";
         edtMVLEVouMes_Enabled = 1;
         edtMVLEVouAno_Jsonclick = "";
         edtMVLEVouAno_Enabled = 1;
         edtMVLEPagReg_Jsonclick = "";
         edtMVLEPagReg_Enabled = 1;
         edtMVLEForCod_Jsonclick = "";
         edtMVLEForCod_Enabled = 1;
         edtMVLETotalPago_Jsonclick = "";
         edtMVLETotalPago_Enabled = 1;
         edtMVLETotal_Jsonclick = "";
         edtMVLETotal_Enabled = 1;
         edtMVLEIGV_Jsonclick = "";
         edtMVLEIGV_Enabled = 1;
         edtMVLESubInafecto_Jsonclick = "";
         edtMVLESubInafecto_Enabled = 1;
         edtMVLESubAfecto_Jsonclick = "";
         edtMVLESubAfecto_Enabled = 1;
         edtMVLEComAux_Jsonclick = "";
         edtMVLEComAux_Enabled = 1;
         edtMVLEComCueCod_Jsonclick = "";
         edtMVLEComCueCod_Enabled = 1;
         edtMVLEComCosCod_Jsonclick = "";
         edtMVLEComCosCod_Enabled = 1;
         edtMVLECueCod_Jsonclick = "";
         edtMVLECueCod_Enabled = 1;
         edtMVLEComFReg_Jsonclick = "";
         edtMVLEComFReg_Enabled = 1;
         edtMVLEComFec_Jsonclick = "";
         edtMVLEComFec_Enabled = 1;
         edtMVLEntTCmb_Jsonclick = "";
         edtMVLEntTCmb_Enabled = 1;
         edtMVLEntReg_Jsonclick = "";
         edtMVLEntReg_Enabled = 1;
         edtMVLEntDocP_Jsonclick = "";
         edtMVLEntDocP_Enabled = 1;
         edtMVLEntTCod_Jsonclick = "";
         edtMVLEntTCod_Enabled = 1;
         edtMVLEPrvCod_Jsonclick = "";
         edtMVLEPrvCod_Enabled = 1;
         edtMVLETipo_Jsonclick = "";
         edtMVLETipo_Enabled = 1;
         edtMVLEntImp_Jsonclick = "";
         edtMVLEntImp_Enabled = 1;
         edtMVLECosCod_Jsonclick = "";
         edtMVLECosCod_Enabled = 1;
         edtMVLECueAuxCod_Jsonclick = "";
         edtMVLECueAuxCod_Enabled = 1;
         edtMVLECueCodAux_Jsonclick = "";
         edtMVLECueCodAux_Enabled = 1;
         edtMVLConcEntCod_Jsonclick = "";
         edtMVLConcEntCod_Enabled = 1;
         edtMVLEntConc_Jsonclick = "";
         edtMVLEntConc_Enabled = 1;
         edtMVLEntDoc_Jsonclick = "";
         edtMVLEntDoc_Enabled = 1;
         edtMVLEntFec_Jsonclick = "";
         edtMVLEntFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMVLEITem_Jsonclick = "";
         edtMVLEITem_Enabled = 1;
         edtMVLEntCod_Jsonclick = "";
         edtMVLEntCod_Enabled = 1;
         edtEntCod_Jsonclick = "";
         edtEntCod_Enabled = 1;
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
         /* Using cursor T005C34 */
         pr_default.execute(32, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(32);
         GX_FocusControl = edtMVLEntFec_Internalname;
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

      public void Valid_Entcod( )
      {
         /* Using cursor T005C34 */
         pr_default.execute(32, new Object[] {A365EntCod});
         if ( (pr_default.getStatus(32) == 101) )
         {
            GX_msglist.addItem("No existe 'Entregas a rendir'.", "ForeignKeyNotFound", 1, "ENTCOD");
            AnyError = 1;
            GX_FocusControl = edtEntCod_Internalname;
         }
         pr_default.close(32);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvleitem( )
      {
         n1328MVLEMBanCon = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1335MVLEntFec", context.localUtil.Format(A1335MVLEntFec, "99/99/99"));
         AssignAttri("", false, "A1333MVLEntDoc", StringUtil.RTrim( A1333MVLEntDoc));
         AssignAttri("", false, "A1332MVLEntConc", StringUtil.RTrim( A1332MVLEntConc));
         AssignAttri("", false, "A411MVLConcEntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A411MVLConcEntCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1322MVLECueCodAux", StringUtil.RTrim( A1322MVLECueCodAux));
         AssignAttri("", false, "A1321MVLECueAuxCod", StringUtil.RTrim( A1321MVLECueAuxCod));
         AssignAttri("", false, "A409MVLECosCod", StringUtil.RTrim( A409MVLECosCod));
         AssignAttri("", false, "A1336MVLEntImp", StringUtil.LTrim( StringUtil.NToC( A1336MVLEntImp, 15, 2, ".", "")));
         AssignAttri("", false, "A1346MVLETipo", StringUtil.RTrim( A1346MVLETipo));
         AssignAttri("", false, "A408MVLEPrvCod", StringUtil.RTrim( A408MVLEPrvCod));
         AssignAttri("", false, "A1339MVLEntTCod", StringUtil.RTrim( A1339MVLEntTCod));
         AssignAttri("", false, "A1334MVLEntDocP", StringUtil.RTrim( A1334MVLEntDocP));
         AssignAttri("", false, "A1337MVLEntReg", StringUtil.RTrim( A1337MVLEntReg));
         AssignAttri("", false, "A1338MVLEntTCmb", StringUtil.LTrim( StringUtil.NToC( A1338MVLEntTCmb, 10, 4, ".", "")));
         AssignAttri("", false, "A1317MVLEComFec", context.localUtil.Format(A1317MVLEComFec, "99/99/99"));
         AssignAttri("", false, "A1318MVLEComFReg", context.localUtil.Format(A1318MVLEComFReg, "99/99/99"));
         AssignAttri("", false, "A407MVLECueCod", StringUtil.RTrim( A407MVLECueCod));
         AssignAttri("", false, "A410MVLEComCosCod", StringUtil.RTrim( A410MVLEComCosCod));
         AssignAttri("", false, "A1316MVLEComCueCod", StringUtil.RTrim( A1316MVLEComCueCod));
         AssignAttri("", false, "A1315MVLEComAux", StringUtil.RTrim( A1315MVLEComAux));
         AssignAttri("", false, "A1343MVLESubAfecto", StringUtil.LTrim( StringUtil.NToC( A1343MVLESubAfecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1344MVLESubInafecto", StringUtil.LTrim( StringUtil.NToC( A1344MVLESubInafecto, 15, 2, ".", "")));
         AssignAttri("", false, "A1326MVLEIGV", StringUtil.LTrim( StringUtil.NToC( A1326MVLEIGV, 15, 2, ".", "")));
         AssignAttri("", false, "A1347MVLETotal", StringUtil.LTrim( StringUtil.NToC( A1347MVLETotal, 15, 2, ".", "")));
         AssignAttri("", false, "A1348MVLETotalPago", StringUtil.LTrim( StringUtil.NToC( A1348MVLETotalPago, 15, 2, ".", "")));
         AssignAttri("", false, "A406MVLEForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A406MVLEForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1340MVLEPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1340MVLEPagReg), 10, 0, ".", "")));
         AssignAttri("", false, "A1351MVLEVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1351MVLEVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1352MVLEVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1352MVLEVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1345MVLETASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1345MVLETASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A1353MVLEVouNum", StringUtil.RTrim( A1353MVLEVouNum));
         AssignAttri("", false, "A405MVLEMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A405MVLEMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1342MVLERedondeo", StringUtil.LTrim( StringUtil.NToC( A1342MVLERedondeo, 15, 2, ".", "")));
         AssignAttri("", false, "A1319MVLEComPorIVA", StringUtil.LTrim( StringUtil.NToC( A1319MVLEComPorIVA, 15, 2, ".", "")));
         AssignAttri("", false, "A1349MVLEUsuCod", StringUtil.RTrim( A1349MVLEUsuCod));
         AssignAttri("", false, "A1350MVLEUsuFec", context.localUtil.TToC( A1350MVLEUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1320MVLEComTipReg", StringUtil.RTrim( A1320MVLEComTipReg));
         AssignAttri("", false, "A1327MVLEMBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1327MVLEMBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1330MVLEMCtaBco", StringUtil.RTrim( A1330MVLEMCtaBco));
         AssignAttri("", false, "A1329MVLEMBanReg", A1329MVLEMBanReg);
         AssignAttri("", false, "A1328MVLEMBanCon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1328MVLEMBanCon), 6, 0, ".", "")));
         AssignAttri("", false, "A1331MVLEMTipo", A1331MVLEMTipo);
         AssignAttri("", false, "A1309MVLConEntDsc", StringUtil.RTrim( A1309MVLConEntDsc));
         AssignAttri("", false, "A1308MVLConEntCue", StringUtil.RTrim( A1308MVLConEntCue));
         AssignAttri("", false, "A1323MVLECueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1323MVLECueCos), 1, 0, ".", "")));
         AssignAttri("", false, "A1341MVLEPrvDsc", StringUtil.RTrim( A1341MVLEPrvDsc));
         AssignAttri("", false, "A1325MVLECueDsc", StringUtil.RTrim( A1325MVLECueDsc));
         AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1324MVLECueCosCod), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z365EntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z365EntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z403MVLEntCod", StringUtil.RTrim( Z403MVLEntCod));
         GxWebStd.gx_hidden_field( context, "Z404MVLEITem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z404MVLEITem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1335MVLEntFec", context.localUtil.Format(Z1335MVLEntFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1333MVLEntDoc", StringUtil.RTrim( Z1333MVLEntDoc));
         GxWebStd.gx_hidden_field( context, "Z1332MVLEntConc", StringUtil.RTrim( Z1332MVLEntConc));
         GxWebStd.gx_hidden_field( context, "Z411MVLConcEntCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z411MVLConcEntCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1322MVLECueCodAux", StringUtil.RTrim( Z1322MVLECueCodAux));
         GxWebStd.gx_hidden_field( context, "Z1321MVLECueAuxCod", StringUtil.RTrim( Z1321MVLECueAuxCod));
         GxWebStd.gx_hidden_field( context, "Z409MVLECosCod", StringUtil.RTrim( Z409MVLECosCod));
         GxWebStd.gx_hidden_field( context, "Z1336MVLEntImp", StringUtil.LTrim( StringUtil.NToC( Z1336MVLEntImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1346MVLETipo", StringUtil.RTrim( Z1346MVLETipo));
         GxWebStd.gx_hidden_field( context, "Z408MVLEPrvCod", StringUtil.RTrim( Z408MVLEPrvCod));
         GxWebStd.gx_hidden_field( context, "Z1339MVLEntTCod", StringUtil.RTrim( Z1339MVLEntTCod));
         GxWebStd.gx_hidden_field( context, "Z1334MVLEntDocP", StringUtil.RTrim( Z1334MVLEntDocP));
         GxWebStd.gx_hidden_field( context, "Z1337MVLEntReg", StringUtil.RTrim( Z1337MVLEntReg));
         GxWebStd.gx_hidden_field( context, "Z1338MVLEntTCmb", StringUtil.LTrim( StringUtil.NToC( Z1338MVLEntTCmb, 10, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1317MVLEComFec", context.localUtil.Format(Z1317MVLEComFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1318MVLEComFReg", context.localUtil.Format(Z1318MVLEComFReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z407MVLECueCod", StringUtil.RTrim( Z407MVLECueCod));
         GxWebStd.gx_hidden_field( context, "Z410MVLEComCosCod", StringUtil.RTrim( Z410MVLEComCosCod));
         GxWebStd.gx_hidden_field( context, "Z1316MVLEComCueCod", StringUtil.RTrim( Z1316MVLEComCueCod));
         GxWebStd.gx_hidden_field( context, "Z1315MVLEComAux", StringUtil.RTrim( Z1315MVLEComAux));
         GxWebStd.gx_hidden_field( context, "Z1343MVLESubAfecto", StringUtil.LTrim( StringUtil.NToC( Z1343MVLESubAfecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1344MVLESubInafecto", StringUtil.LTrim( StringUtil.NToC( Z1344MVLESubInafecto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1326MVLEIGV", StringUtil.LTrim( StringUtil.NToC( Z1326MVLEIGV, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1347MVLETotal", StringUtil.LTrim( StringUtil.NToC( Z1347MVLETotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1348MVLETotalPago", StringUtil.LTrim( StringUtil.NToC( Z1348MVLETotalPago, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z406MVLEForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z406MVLEForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1340MVLEPagReg", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1340MVLEPagReg), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1351MVLEVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1351MVLEVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1352MVLEVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1352MVLEVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1345MVLETASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1345MVLETASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1353MVLEVouNum", StringUtil.RTrim( Z1353MVLEVouNum));
         GxWebStd.gx_hidden_field( context, "Z405MVLEMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z405MVLEMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1342MVLERedondeo", StringUtil.LTrim( StringUtil.NToC( Z1342MVLERedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1319MVLEComPorIVA", StringUtil.LTrim( StringUtil.NToC( Z1319MVLEComPorIVA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1349MVLEUsuCod", StringUtil.RTrim( Z1349MVLEUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1350MVLEUsuFec", context.localUtil.TToC( Z1350MVLEUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1320MVLEComTipReg", StringUtil.RTrim( Z1320MVLEComTipReg));
         GxWebStd.gx_hidden_field( context, "Z1327MVLEMBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1327MVLEMBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1330MVLEMCtaBco", StringUtil.RTrim( Z1330MVLEMCtaBco));
         GxWebStd.gx_hidden_field( context, "Z1329MVLEMBanReg", Z1329MVLEMBanReg);
         GxWebStd.gx_hidden_field( context, "Z1328MVLEMBanCon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1328MVLEMBanCon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1331MVLEMTipo", Z1331MVLEMTipo);
         GxWebStd.gx_hidden_field( context, "Z1309MVLConEntDsc", StringUtil.RTrim( Z1309MVLConEntDsc));
         GxWebStd.gx_hidden_field( context, "Z1308MVLConEntCue", StringUtil.RTrim( Z1308MVLConEntCue));
         GxWebStd.gx_hidden_field( context, "Z1323MVLECueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1323MVLECueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1341MVLEPrvDsc", StringUtil.RTrim( Z1341MVLEPrvDsc));
         GxWebStd.gx_hidden_field( context, "Z1325MVLECueDsc", StringUtil.RTrim( Z1325MVLECueDsc));
         GxWebStd.gx_hidden_field( context, "Z1324MVLECueCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1324MVLECueCosCod), 1, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Mvlconcentcod( )
      {
         /* Using cursor T005C29 */
         pr_default.execute(27, new Object[] {A411MVLConcEntCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto'.", "ForeignKeyNotFound", 1, "MVLCONCENTCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLConcEntCod_Internalname;
         }
         A1309MVLConEntDsc = T005C29_A1309MVLConEntDsc[0];
         A1308MVLConEntCue = T005C29_A1308MVLConEntCue[0];
         pr_default.close(27);
         /* Using cursor T005C30 */
         pr_default.execute(28, new Object[] {A1308MVLConEntCue});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Concepto'.", "ForeignKeyNotFound", 1, "MVLCONENTCUE");
            AnyError = 1;
         }
         A1323MVLECueCos = T005C30_A1323MVLECueCos[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1309MVLConEntDsc", StringUtil.RTrim( A1309MVLConEntDsc));
         AssignAttri("", false, "A1308MVLConEntCue", StringUtil.RTrim( A1308MVLConEntCue));
         AssignAttri("", false, "A1323MVLECueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1323MVLECueCos), 1, 0, ".", "")));
      }

      public void Valid_Mvlecoscod( )
      {
         n409MVLECosCod = false;
         /* Using cursor T005C35 */
         pr_default.execute(33, new Object[] {n409MVLECosCod, A409MVLECosCod});
         if ( (pr_default.getStatus(33) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A409MVLECosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "MVLECOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLECosCod_Internalname;
            }
         }
         pr_default.close(33);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvleprvcod( )
      {
         /* Using cursor T005C31 */
         pr_default.execute(29, new Object[] {A408MVLEPrvCod});
         if ( (pr_default.getStatus(29) == 101) )
         {
            GX_msglist.addItem("No existe 'Proveedor'.", "ForeignKeyNotFound", 1, "MVLEPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLEPrvCod_Internalname;
         }
         A1341MVLEPrvDsc = T005C31_A1341MVLEPrvDsc[0];
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1341MVLEPrvDsc", StringUtil.RTrim( A1341MVLEPrvDsc));
      }

      public void Valid_Mvlecuecod( )
      {
         /* Using cursor T005C32 */
         pr_default.execute(30, new Object[] {A407MVLECueCod});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta'.", "ForeignKeyNotFound", 1, "MVLECUECOD");
            AnyError = 1;
            GX_FocusControl = edtMVLECueCod_Internalname;
         }
         A1325MVLECueDsc = T005C32_A1325MVLECueDsc[0];
         A1324MVLECueCosCod = T005C32_A1324MVLECueCosCod[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1325MVLECueDsc", StringUtil.RTrim( A1325MVLECueDsc));
         AssignAttri("", false, "A1324MVLECueCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1324MVLECueCosCod), 1, 0, ".", "")));
      }

      public void Valid_Mvlecomcoscod( )
      {
         n410MVLEComCosCod = false;
         /* Using cursor T005C36 */
         pr_default.execute(34, new Object[] {n410MVLEComCosCod, A410MVLEComCosCod});
         if ( (pr_default.getStatus(34) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A410MVLEComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'C.Costo'.", "ForeignKeyNotFound", 1, "MVLECOMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEComCosCod_Internalname;
            }
         }
         pr_default.close(34);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvleforcod( )
      {
         n406MVLEForCod = false;
         /* Using cursor T005C37 */
         pr_default.execute(35, new Object[] {n406MVLEForCod, A406MVLEForCod});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( (0==A406MVLEForCod) ) )
            {
               GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "MVLEFORCOD");
               AnyError = 1;
               GX_FocusControl = edtMVLEForCod_Internalname;
            }
         }
         pr_default.close(35);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvlemoncod( )
      {
         /* Using cursor T005C38 */
         pr_default.execute(36, new Object[] {A405MVLEMonCod});
         if ( (pr_default.getStatus(36) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "MVLEMONCOD");
            AnyError = 1;
            GX_FocusControl = edtMVLEMonCod_Internalname;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1327MVLEMBanCod',fld:'MVLEMBANCOD',pic:'ZZZZZ9'},{av:'A1330MVLEMCtaBco',fld:'MVLEMCTABCO',pic:''},{av:'A1329MVLEMBanReg',fld:'MVLEMBANREG',pic:''},{av:'A1328MVLEMBanCon',fld:'MVLEMBANCON',pic:'ZZZZZ9'},{av:'A1331MVLEMTipo',fld:'MVLEMTIPO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_ENTCOD","{handler:'Valid_Entcod',iparms:[{av:'A365EntCod',fld:'ENTCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_ENTCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLENTCOD","{handler:'Valid_Mvlentcod',iparms:[]");
         setEventMetadata("VALID_MVLENTCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLEITEM","{handler:'Valid_Mvleitem',iparms:[{av:'A1331MVLEMTipo',fld:'MVLEMTIPO',pic:''},{av:'A1328MVLEMBanCon',fld:'MVLEMBANCON',pic:'ZZZZZ9'},{av:'A1329MVLEMBanReg',fld:'MVLEMBANREG',pic:''},{av:'A1330MVLEMCtaBco',fld:'MVLEMCTABCO',pic:''},{av:'A1327MVLEMBanCod',fld:'MVLEMBANCOD',pic:'ZZZZZ9'},{av:'A365EntCod',fld:'ENTCOD',pic:'ZZZZZ9'},{av:'A403MVLEntCod',fld:'MVLENTCOD',pic:''},{av:'A404MVLEITem',fld:'MVLEITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MVLEITEM",",oparms:[{av:'A1335MVLEntFec',fld:'MVLENTFEC',pic:''},{av:'A1333MVLEntDoc',fld:'MVLENTDOC',pic:''},{av:'A1332MVLEntConc',fld:'MVLENTCONC',pic:''},{av:'A411MVLConcEntCod',fld:'MVLCONCENTCOD',pic:'ZZZZZ9'},{av:'A1322MVLECueCodAux',fld:'MVLECUECODAUX',pic:''},{av:'A1321MVLECueAuxCod',fld:'MVLECUEAUXCOD',pic:''},{av:'A409MVLECosCod',fld:'MVLECOSCOD',pic:''},{av:'A1336MVLEntImp',fld:'MVLENTIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1346MVLETipo',fld:'MVLETIPO',pic:''},{av:'A408MVLEPrvCod',fld:'MVLEPRVCOD',pic:'@!'},{av:'A1339MVLEntTCod',fld:'MVLENTTCOD',pic:''},{av:'A1334MVLEntDocP',fld:'MVLENTDOCP',pic:''},{av:'A1337MVLEntReg',fld:'MVLENTREG',pic:''},{av:'A1338MVLEntTCmb',fld:'MVLENTTCMB',pic:'ZZZZ9.9999'},{av:'A1317MVLEComFec',fld:'MVLECOMFEC',pic:''},{av:'A1318MVLEComFReg',fld:'MVLECOMFREG',pic:''},{av:'A407MVLECueCod',fld:'MVLECUECOD',pic:''},{av:'A410MVLEComCosCod',fld:'MVLECOMCOSCOD',pic:''},{av:'A1316MVLEComCueCod',fld:'MVLECOMCUECOD',pic:''},{av:'A1315MVLEComAux',fld:'MVLECOMAUX',pic:''},{av:'A1343MVLESubAfecto',fld:'MVLESUBAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1344MVLESubInafecto',fld:'MVLESUBINAFECTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1326MVLEIGV',fld:'MVLEIGV',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1347MVLETotal',fld:'MVLETOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1348MVLETotalPago',fld:'MVLETOTALPAGO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A406MVLEForCod',fld:'MVLEFORCOD',pic:'ZZZZZ9'},{av:'A1340MVLEPagReg',fld:'MVLEPAGREG',pic:'ZZZZZZZZZ9'},{av:'A1351MVLEVouAno',fld:'MVLEVOUANO',pic:'ZZZ9'},{av:'A1352MVLEVouMes',fld:'MVLEVOUMES',pic:'Z9'},{av:'A1345MVLETASICod',fld:'MVLETASICOD',pic:'ZZZZZ9'},{av:'A1353MVLEVouNum',fld:'MVLEVOUNUM',pic:''},{av:'A405MVLEMonCod',fld:'MVLEMONCOD',pic:'ZZZZZ9'},{av:'A1342MVLERedondeo',fld:'MVLEREDONDEO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1319MVLEComPorIVA',fld:'MVLECOMPORIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1349MVLEUsuCod',fld:'MVLEUSUCOD',pic:''},{av:'A1350MVLEUsuFec',fld:'MVLEUSUFEC',pic:'99/99/99 99:99'},{av:'A1320MVLEComTipReg',fld:'MVLECOMTIPREG',pic:''},{av:'A1327MVLEMBanCod',fld:'MVLEMBANCOD',pic:'ZZZZZ9'},{av:'A1330MVLEMCtaBco',fld:'MVLEMCTABCO',pic:''},{av:'A1329MVLEMBanReg',fld:'MVLEMBANREG',pic:''},{av:'A1328MVLEMBanCon',fld:'MVLEMBANCON',pic:'ZZZZZ9'},{av:'A1331MVLEMTipo',fld:'MVLEMTIPO',pic:''},{av:'A1309MVLConEntDsc',fld:'MVLCONENTDSC',pic:''},{av:'A1308MVLConEntCue',fld:'MVLCONENTCUE',pic:''},{av:'A1323MVLECueCos',fld:'MVLECUECOS',pic:'9'},{av:'A1341MVLEPrvDsc',fld:'MVLEPRVDSC',pic:''},{av:'A1325MVLECueDsc',fld:'MVLECUEDSC',pic:''},{av:'A1324MVLECueCosCod',fld:'MVLECUECOSCOD',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z365EntCod'},{av:'Z403MVLEntCod'},{av:'Z404MVLEITem'},{av:'Z1335MVLEntFec'},{av:'Z1333MVLEntDoc'},{av:'Z1332MVLEntConc'},{av:'Z411MVLConcEntCod'},{av:'Z1322MVLECueCodAux'},{av:'Z1321MVLECueAuxCod'},{av:'Z409MVLECosCod'},{av:'Z1336MVLEntImp'},{av:'Z1346MVLETipo'},{av:'Z408MVLEPrvCod'},{av:'Z1339MVLEntTCod'},{av:'Z1334MVLEntDocP'},{av:'Z1337MVLEntReg'},{av:'Z1338MVLEntTCmb'},{av:'Z1317MVLEComFec'},{av:'Z1318MVLEComFReg'},{av:'Z407MVLECueCod'},{av:'Z410MVLEComCosCod'},{av:'Z1316MVLEComCueCod'},{av:'Z1315MVLEComAux'},{av:'Z1343MVLESubAfecto'},{av:'Z1344MVLESubInafecto'},{av:'Z1326MVLEIGV'},{av:'Z1347MVLETotal'},{av:'Z1348MVLETotalPago'},{av:'Z406MVLEForCod'},{av:'Z1340MVLEPagReg'},{av:'Z1351MVLEVouAno'},{av:'Z1352MVLEVouMes'},{av:'Z1345MVLETASICod'},{av:'Z1353MVLEVouNum'},{av:'Z405MVLEMonCod'},{av:'Z1342MVLERedondeo'},{av:'Z1319MVLEComPorIVA'},{av:'Z1349MVLEUsuCod'},{av:'Z1350MVLEUsuFec'},{av:'Z1320MVLEComTipReg'},{av:'Z1327MVLEMBanCod'},{av:'Z1330MVLEMCtaBco'},{av:'Z1329MVLEMBanReg'},{av:'Z1328MVLEMBanCon'},{av:'Z1331MVLEMTipo'},{av:'Z1309MVLConEntDsc'},{av:'Z1308MVLConEntCue'},{av:'Z1323MVLECueCos'},{av:'Z1341MVLEPrvDsc'},{av:'Z1325MVLECueDsc'},{av:'Z1324MVLECueCosCod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_MVLENTFEC","{handler:'Valid_Mvlentfec',iparms:[]");
         setEventMetadata("VALID_MVLENTFEC",",oparms:[]}");
         setEventMetadata("VALID_MVLCONCENTCOD","{handler:'Valid_Mvlconcentcod',iparms:[{av:'A411MVLConcEntCod',fld:'MVLCONCENTCOD',pic:'ZZZZZ9'},{av:'A1308MVLConEntCue',fld:'MVLCONENTCUE',pic:''},{av:'A1309MVLConEntDsc',fld:'MVLCONENTDSC',pic:''},{av:'A1323MVLECueCos',fld:'MVLECUECOS',pic:'9'}]");
         setEventMetadata("VALID_MVLCONCENTCOD",",oparms:[{av:'A1309MVLConEntDsc',fld:'MVLCONENTDSC',pic:''},{av:'A1308MVLConEntCue',fld:'MVLCONENTCUE',pic:''},{av:'A1323MVLECueCos',fld:'MVLECUECOS',pic:'9'}]}");
         setEventMetadata("VALID_MVLECOSCOD","{handler:'Valid_Mvlecoscod',iparms:[{av:'A409MVLECosCod',fld:'MVLECOSCOD',pic:''}]");
         setEventMetadata("VALID_MVLECOSCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLEPRVCOD","{handler:'Valid_Mvleprvcod',iparms:[{av:'A408MVLEPrvCod',fld:'MVLEPRVCOD',pic:'@!'},{av:'A1341MVLEPrvDsc',fld:'MVLEPRVDSC',pic:''}]");
         setEventMetadata("VALID_MVLEPRVCOD",",oparms:[{av:'A1341MVLEPrvDsc',fld:'MVLEPRVDSC',pic:''}]}");
         setEventMetadata("VALID_MVLECOMFEC","{handler:'Valid_Mvlecomfec',iparms:[]");
         setEventMetadata("VALID_MVLECOMFEC",",oparms:[]}");
         setEventMetadata("VALID_MVLECOMFREG","{handler:'Valid_Mvlecomfreg',iparms:[]");
         setEventMetadata("VALID_MVLECOMFREG",",oparms:[]}");
         setEventMetadata("VALID_MVLECUECOD","{handler:'Valid_Mvlecuecod',iparms:[{av:'A407MVLECueCod',fld:'MVLECUECOD',pic:''},{av:'A1325MVLECueDsc',fld:'MVLECUEDSC',pic:''},{av:'A1324MVLECueCosCod',fld:'MVLECUECOSCOD',pic:'9'}]");
         setEventMetadata("VALID_MVLECUECOD",",oparms:[{av:'A1325MVLECueDsc',fld:'MVLECUEDSC',pic:''},{av:'A1324MVLECueCosCod',fld:'MVLECUECOSCOD',pic:'9'}]}");
         setEventMetadata("VALID_MVLECOMCOSCOD","{handler:'Valid_Mvlecomcoscod',iparms:[{av:'A410MVLEComCosCod',fld:'MVLECOMCOSCOD',pic:''}]");
         setEventMetadata("VALID_MVLECOMCOSCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLEFORCOD","{handler:'Valid_Mvleforcod',iparms:[{av:'A406MVLEForCod',fld:'MVLEFORCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MVLEFORCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLEMONCOD","{handler:'Valid_Mvlemoncod',iparms:[{av:'A405MVLEMonCod',fld:'MVLEMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MVLEMONCOD",",oparms:[]}");
         setEventMetadata("VALID_MVLEUSUFEC","{handler:'Valid_Mvleusufec',iparms:[]");
         setEventMetadata("VALID_MVLEUSUFEC",",oparms:[]}");
         setEventMetadata("VALID_MVLCONENTCUE","{handler:'Valid_Mvlconentcue',iparms:[]");
         setEventMetadata("VALID_MVLCONENTCUE",",oparms:[]}");
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
         pr_default.close(34);
         pr_default.close(29);
         pr_default.close(30);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(28);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z403MVLEntCod = "";
         Z1335MVLEntFec = DateTime.MinValue;
         Z1333MVLEntDoc = "";
         Z1332MVLEntConc = "";
         Z1322MVLECueCodAux = "";
         Z1321MVLECueAuxCod = "";
         Z1346MVLETipo = "";
         Z1339MVLEntTCod = "";
         Z1334MVLEntDocP = "";
         Z1337MVLEntReg = "";
         Z1317MVLEComFec = DateTime.MinValue;
         Z1318MVLEComFReg = DateTime.MinValue;
         Z1316MVLEComCueCod = "";
         Z1315MVLEComAux = "";
         Z1353MVLEVouNum = "";
         Z1349MVLEUsuCod = "";
         Z1350MVLEUsuFec = (DateTime)(DateTime.MinValue);
         Z1320MVLEComTipReg = "";
         Z1330MVLEMCtaBco = "";
         Z1329MVLEMBanReg = "";
         Z1331MVLEMTipo = "";
         Z409MVLECosCod = "";
         Z410MVLEComCosCod = "";
         Z408MVLEPrvCod = "";
         Z407MVLECueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A1308MVLConEntCue = "";
         A409MVLECosCod = "";
         A408MVLEPrvCod = "";
         A407MVLECueCod = "";
         A410MVLEComCosCod = "";
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
         A403MVLEntCod = "";
         lblTextblock3_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1335MVLEntFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A1333MVLEntDoc = "";
         lblTextblock6_Jsonclick = "";
         A1332MVLEntConc = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A1322MVLECueCodAux = "";
         lblTextblock9_Jsonclick = "";
         A1321MVLECueAuxCod = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         A1346MVLETipo = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         A1339MVLEntTCod = "";
         lblTextblock15_Jsonclick = "";
         A1334MVLEntDocP = "";
         lblTextblock16_Jsonclick = "";
         A1337MVLEntReg = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         A1317MVLEComFec = DateTime.MinValue;
         lblTextblock19_Jsonclick = "";
         A1318MVLEComFReg = DateTime.MinValue;
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         A1316MVLEComCueCod = "";
         lblTextblock23_Jsonclick = "";
         A1315MVLEComAux = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         lblTextblock26_Jsonclick = "";
         lblTextblock27_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         lblTextblock29_Jsonclick = "";
         lblTextblock30_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         lblTextblock32_Jsonclick = "";
         lblTextblock33_Jsonclick = "";
         lblTextblock34_Jsonclick = "";
         A1353MVLEVouNum = "";
         lblTextblock35_Jsonclick = "";
         lblTextblock36_Jsonclick = "";
         lblTextblock37_Jsonclick = "";
         lblTextblock38_Jsonclick = "";
         A1349MVLEUsuCod = "";
         lblTextblock39_Jsonclick = "";
         A1350MVLEUsuFec = (DateTime)(DateTime.MinValue);
         lblTextblock40_Jsonclick = "";
         A1320MVLEComTipReg = "";
         lblTextblock41_Jsonclick = "";
         lblTextblock42_Jsonclick = "";
         A1309MVLConEntDsc = "";
         lblTextblock43_Jsonclick = "";
         lblTextblock44_Jsonclick = "";
         A1341MVLEPrvDsc = "";
         lblTextblock45_Jsonclick = "";
         A1325MVLECueDsc = "";
         lblTextblock46_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A1330MVLEMCtaBco = "";
         A1329MVLEMBanReg = "";
         A1331MVLEMTipo = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1309MVLConEntDsc = "";
         Z1308MVLConEntCue = "";
         Z1341MVLEPrvDsc = "";
         Z1325MVLECueDsc = "";
         T005C13_A403MVLEntCod = new string[] {""} ;
         T005C13_A404MVLEITem = new int[1] ;
         T005C13_A1335MVLEntFec = new DateTime[] {DateTime.MinValue} ;
         T005C13_A1333MVLEntDoc = new string[] {""} ;
         T005C13_A1332MVLEntConc = new string[] {""} ;
         T005C13_A1322MVLECueCodAux = new string[] {""} ;
         T005C13_A1321MVLECueAuxCod = new string[] {""} ;
         T005C13_A1336MVLEntImp = new decimal[1] ;
         T005C13_A1346MVLETipo = new string[] {""} ;
         T005C13_A1339MVLEntTCod = new string[] {""} ;
         T005C13_A1334MVLEntDocP = new string[] {""} ;
         T005C13_A1337MVLEntReg = new string[] {""} ;
         T005C13_A1338MVLEntTCmb = new decimal[1] ;
         T005C13_A1317MVLEComFec = new DateTime[] {DateTime.MinValue} ;
         T005C13_A1318MVLEComFReg = new DateTime[] {DateTime.MinValue} ;
         T005C13_A1316MVLEComCueCod = new string[] {""} ;
         T005C13_A1315MVLEComAux = new string[] {""} ;
         T005C13_A1343MVLESubAfecto = new decimal[1] ;
         T005C13_A1344MVLESubInafecto = new decimal[1] ;
         T005C13_A1326MVLEIGV = new decimal[1] ;
         T005C13_A1347MVLETotal = new decimal[1] ;
         T005C13_A1348MVLETotalPago = new decimal[1] ;
         T005C13_A1340MVLEPagReg = new long[1] ;
         T005C13_A1351MVLEVouAno = new short[1] ;
         T005C13_A1352MVLEVouMes = new short[1] ;
         T005C13_A1345MVLETASICod = new int[1] ;
         T005C13_A1353MVLEVouNum = new string[] {""} ;
         T005C13_A1342MVLERedondeo = new decimal[1] ;
         T005C13_A1319MVLEComPorIVA = new decimal[1] ;
         T005C13_A1349MVLEUsuCod = new string[] {""} ;
         T005C13_A1350MVLEUsuFec = new DateTime[] {DateTime.MinValue} ;
         T005C13_A1320MVLEComTipReg = new string[] {""} ;
         T005C13_A1323MVLECueCos = new short[1] ;
         T005C13_A1309MVLConEntDsc = new string[] {""} ;
         T005C13_A1341MVLEPrvDsc = new string[] {""} ;
         T005C13_A1325MVLECueDsc = new string[] {""} ;
         T005C13_A1324MVLECueCosCod = new short[1] ;
         T005C13_A1327MVLEMBanCod = new int[1] ;
         T005C13_A1330MVLEMCtaBco = new string[] {""} ;
         T005C13_A1329MVLEMBanReg = new string[] {""} ;
         T005C13_A1328MVLEMBanCon = new int[1] ;
         T005C13_n1328MVLEMBanCon = new bool[] {false} ;
         T005C13_A1331MVLEMTipo = new string[] {""} ;
         T005C13_A365EntCod = new int[1] ;
         T005C13_A411MVLConcEntCod = new int[1] ;
         T005C13_A409MVLECosCod = new string[] {""} ;
         T005C13_n409MVLECosCod = new bool[] {false} ;
         T005C13_A410MVLEComCosCod = new string[] {""} ;
         T005C13_n410MVLEComCosCod = new bool[] {false} ;
         T005C13_A408MVLEPrvCod = new string[] {""} ;
         T005C13_A407MVLECueCod = new string[] {""} ;
         T005C13_A406MVLEForCod = new int[1] ;
         T005C13_n406MVLEForCod = new bool[] {false} ;
         T005C13_A405MVLEMonCod = new int[1] ;
         T005C13_A1308MVLConEntCue = new string[] {""} ;
         T005C4_A365EntCod = new int[1] ;
         T005C5_A1309MVLConEntDsc = new string[] {""} ;
         T005C5_A1308MVLConEntCue = new string[] {""} ;
         T005C12_A1323MVLECueCos = new short[1] ;
         T005C6_A409MVLECosCod = new string[] {""} ;
         T005C6_n409MVLECosCod = new bool[] {false} ;
         T005C8_A1341MVLEPrvDsc = new string[] {""} ;
         T005C9_A1325MVLECueDsc = new string[] {""} ;
         T005C9_A1324MVLECueCosCod = new short[1] ;
         T005C7_A410MVLEComCosCod = new string[] {""} ;
         T005C7_n410MVLEComCosCod = new bool[] {false} ;
         T005C10_A406MVLEForCod = new int[1] ;
         T005C10_n406MVLEForCod = new bool[] {false} ;
         T005C11_A405MVLEMonCod = new int[1] ;
         T005C14_A365EntCod = new int[1] ;
         T005C15_A1309MVLConEntDsc = new string[] {""} ;
         T005C15_A1308MVLConEntCue = new string[] {""} ;
         T005C16_A1323MVLECueCos = new short[1] ;
         T005C17_A409MVLECosCod = new string[] {""} ;
         T005C17_n409MVLECosCod = new bool[] {false} ;
         T005C18_A1341MVLEPrvDsc = new string[] {""} ;
         T005C19_A1325MVLECueDsc = new string[] {""} ;
         T005C19_A1324MVLECueCosCod = new short[1] ;
         T005C20_A410MVLEComCosCod = new string[] {""} ;
         T005C20_n410MVLEComCosCod = new bool[] {false} ;
         T005C21_A406MVLEForCod = new int[1] ;
         T005C21_n406MVLEForCod = new bool[] {false} ;
         T005C22_A405MVLEMonCod = new int[1] ;
         T005C23_A365EntCod = new int[1] ;
         T005C23_A403MVLEntCod = new string[] {""} ;
         T005C23_A404MVLEITem = new int[1] ;
         T005C3_A403MVLEntCod = new string[] {""} ;
         T005C3_A404MVLEITem = new int[1] ;
         T005C3_A1335MVLEntFec = new DateTime[] {DateTime.MinValue} ;
         T005C3_A1333MVLEntDoc = new string[] {""} ;
         T005C3_A1332MVLEntConc = new string[] {""} ;
         T005C3_A1322MVLECueCodAux = new string[] {""} ;
         T005C3_A1321MVLECueAuxCod = new string[] {""} ;
         T005C3_A1336MVLEntImp = new decimal[1] ;
         T005C3_A1346MVLETipo = new string[] {""} ;
         T005C3_A1339MVLEntTCod = new string[] {""} ;
         T005C3_A1334MVLEntDocP = new string[] {""} ;
         T005C3_A1337MVLEntReg = new string[] {""} ;
         T005C3_A1338MVLEntTCmb = new decimal[1] ;
         T005C3_A1317MVLEComFec = new DateTime[] {DateTime.MinValue} ;
         T005C3_A1318MVLEComFReg = new DateTime[] {DateTime.MinValue} ;
         T005C3_A1316MVLEComCueCod = new string[] {""} ;
         T005C3_A1315MVLEComAux = new string[] {""} ;
         T005C3_A1343MVLESubAfecto = new decimal[1] ;
         T005C3_A1344MVLESubInafecto = new decimal[1] ;
         T005C3_A1326MVLEIGV = new decimal[1] ;
         T005C3_A1347MVLETotal = new decimal[1] ;
         T005C3_A1348MVLETotalPago = new decimal[1] ;
         T005C3_A1340MVLEPagReg = new long[1] ;
         T005C3_A1351MVLEVouAno = new short[1] ;
         T005C3_A1352MVLEVouMes = new short[1] ;
         T005C3_A1345MVLETASICod = new int[1] ;
         T005C3_A1353MVLEVouNum = new string[] {""} ;
         T005C3_A1342MVLERedondeo = new decimal[1] ;
         T005C3_A1319MVLEComPorIVA = new decimal[1] ;
         T005C3_A1349MVLEUsuCod = new string[] {""} ;
         T005C3_A1350MVLEUsuFec = new DateTime[] {DateTime.MinValue} ;
         T005C3_A1320MVLEComTipReg = new string[] {""} ;
         T005C3_A1327MVLEMBanCod = new int[1] ;
         T005C3_A1330MVLEMCtaBco = new string[] {""} ;
         T005C3_A1329MVLEMBanReg = new string[] {""} ;
         T005C3_A1328MVLEMBanCon = new int[1] ;
         T005C3_n1328MVLEMBanCon = new bool[] {false} ;
         T005C3_A1331MVLEMTipo = new string[] {""} ;
         T005C3_A365EntCod = new int[1] ;
         T005C3_A411MVLConcEntCod = new int[1] ;
         T005C3_A409MVLECosCod = new string[] {""} ;
         T005C3_n409MVLECosCod = new bool[] {false} ;
         T005C3_A410MVLEComCosCod = new string[] {""} ;
         T005C3_n410MVLEComCosCod = new bool[] {false} ;
         T005C3_A408MVLEPrvCod = new string[] {""} ;
         T005C3_A407MVLECueCod = new string[] {""} ;
         T005C3_A406MVLEForCod = new int[1] ;
         T005C3_n406MVLEForCod = new bool[] {false} ;
         T005C3_A405MVLEMonCod = new int[1] ;
         sMode179 = "";
         T005C24_A365EntCod = new int[1] ;
         T005C24_A403MVLEntCod = new string[] {""} ;
         T005C24_A404MVLEITem = new int[1] ;
         T005C25_A365EntCod = new int[1] ;
         T005C25_A403MVLEntCod = new string[] {""} ;
         T005C25_A404MVLEITem = new int[1] ;
         T005C2_A403MVLEntCod = new string[] {""} ;
         T005C2_A404MVLEITem = new int[1] ;
         T005C2_A1335MVLEntFec = new DateTime[] {DateTime.MinValue} ;
         T005C2_A1333MVLEntDoc = new string[] {""} ;
         T005C2_A1332MVLEntConc = new string[] {""} ;
         T005C2_A1322MVLECueCodAux = new string[] {""} ;
         T005C2_A1321MVLECueAuxCod = new string[] {""} ;
         T005C2_A1336MVLEntImp = new decimal[1] ;
         T005C2_A1346MVLETipo = new string[] {""} ;
         T005C2_A1339MVLEntTCod = new string[] {""} ;
         T005C2_A1334MVLEntDocP = new string[] {""} ;
         T005C2_A1337MVLEntReg = new string[] {""} ;
         T005C2_A1338MVLEntTCmb = new decimal[1] ;
         T005C2_A1317MVLEComFec = new DateTime[] {DateTime.MinValue} ;
         T005C2_A1318MVLEComFReg = new DateTime[] {DateTime.MinValue} ;
         T005C2_A1316MVLEComCueCod = new string[] {""} ;
         T005C2_A1315MVLEComAux = new string[] {""} ;
         T005C2_A1343MVLESubAfecto = new decimal[1] ;
         T005C2_A1344MVLESubInafecto = new decimal[1] ;
         T005C2_A1326MVLEIGV = new decimal[1] ;
         T005C2_A1347MVLETotal = new decimal[1] ;
         T005C2_A1348MVLETotalPago = new decimal[1] ;
         T005C2_A1340MVLEPagReg = new long[1] ;
         T005C2_A1351MVLEVouAno = new short[1] ;
         T005C2_A1352MVLEVouMes = new short[1] ;
         T005C2_A1345MVLETASICod = new int[1] ;
         T005C2_A1353MVLEVouNum = new string[] {""} ;
         T005C2_A1342MVLERedondeo = new decimal[1] ;
         T005C2_A1319MVLEComPorIVA = new decimal[1] ;
         T005C2_A1349MVLEUsuCod = new string[] {""} ;
         T005C2_A1350MVLEUsuFec = new DateTime[] {DateTime.MinValue} ;
         T005C2_A1320MVLEComTipReg = new string[] {""} ;
         T005C2_A1327MVLEMBanCod = new int[1] ;
         T005C2_A1330MVLEMCtaBco = new string[] {""} ;
         T005C2_A1329MVLEMBanReg = new string[] {""} ;
         T005C2_A1328MVLEMBanCon = new int[1] ;
         T005C2_n1328MVLEMBanCon = new bool[] {false} ;
         T005C2_A1331MVLEMTipo = new string[] {""} ;
         T005C2_A365EntCod = new int[1] ;
         T005C2_A411MVLConcEntCod = new int[1] ;
         T005C2_A409MVLECosCod = new string[] {""} ;
         T005C2_n409MVLECosCod = new bool[] {false} ;
         T005C2_A410MVLEComCosCod = new string[] {""} ;
         T005C2_n410MVLEComCosCod = new bool[] {false} ;
         T005C2_A408MVLEPrvCod = new string[] {""} ;
         T005C2_A407MVLECueCod = new string[] {""} ;
         T005C2_A406MVLEForCod = new int[1] ;
         T005C2_n406MVLEForCod = new bool[] {false} ;
         T005C2_A405MVLEMonCod = new int[1] ;
         T005C29_A1309MVLConEntDsc = new string[] {""} ;
         T005C29_A1308MVLConEntCue = new string[] {""} ;
         T005C30_A1323MVLECueCos = new short[1] ;
         T005C31_A1341MVLEPrvDsc = new string[] {""} ;
         T005C32_A1325MVLECueDsc = new string[] {""} ;
         T005C32_A1324MVLECueCosCod = new short[1] ;
         T005C33_A365EntCod = new int[1] ;
         T005C33_A403MVLEntCod = new string[] {""} ;
         T005C33_A404MVLEITem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T005C34_A365EntCod = new int[1] ;
         ZZ403MVLEntCod = "";
         ZZ1335MVLEntFec = DateTime.MinValue;
         ZZ1333MVLEntDoc = "";
         ZZ1332MVLEntConc = "";
         ZZ1322MVLECueCodAux = "";
         ZZ1321MVLECueAuxCod = "";
         ZZ409MVLECosCod = "";
         ZZ1346MVLETipo = "";
         ZZ408MVLEPrvCod = "";
         ZZ1339MVLEntTCod = "";
         ZZ1334MVLEntDocP = "";
         ZZ1337MVLEntReg = "";
         ZZ1317MVLEComFec = DateTime.MinValue;
         ZZ1318MVLEComFReg = DateTime.MinValue;
         ZZ407MVLECueCod = "";
         ZZ410MVLEComCosCod = "";
         ZZ1316MVLEComCueCod = "";
         ZZ1315MVLEComAux = "";
         ZZ1353MVLEVouNum = "";
         ZZ1349MVLEUsuCod = "";
         ZZ1350MVLEUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1320MVLEComTipReg = "";
         ZZ1330MVLEMCtaBco = "";
         ZZ1329MVLEMBanReg = "";
         ZZ1331MVLEMTipo = "";
         ZZ1309MVLConEntDsc = "";
         ZZ1308MVLConEntCue = "";
         ZZ1341MVLEPrvDsc = "";
         ZZ1325MVLECueDsc = "";
         T005C35_A409MVLECosCod = new string[] {""} ;
         T005C35_n409MVLECosCod = new bool[] {false} ;
         T005C36_A410MVLEComCosCod = new string[] {""} ;
         T005C36_n410MVLEComCosCod = new bool[] {false} ;
         T005C37_A406MVLEForCod = new int[1] ;
         T005C37_n406MVLEForCod = new bool[] {false} ;
         T005C38_A405MVLEMonCod = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.tsmoventrega__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.tsmoventrega__default(),
            new Object[][] {
                new Object[] {
               T005C2_A403MVLEntCod, T005C2_A404MVLEITem, T005C2_A1335MVLEntFec, T005C2_A1333MVLEntDoc, T005C2_A1332MVLEntConc, T005C2_A1322MVLECueCodAux, T005C2_A1321MVLECueAuxCod, T005C2_A1336MVLEntImp, T005C2_A1346MVLETipo, T005C2_A1339MVLEntTCod,
               T005C2_A1334MVLEntDocP, T005C2_A1337MVLEntReg, T005C2_A1338MVLEntTCmb, T005C2_A1317MVLEComFec, T005C2_A1318MVLEComFReg, T005C2_A1316MVLEComCueCod, T005C2_A1315MVLEComAux, T005C2_A1343MVLESubAfecto, T005C2_A1344MVLESubInafecto, T005C2_A1326MVLEIGV,
               T005C2_A1347MVLETotal, T005C2_A1348MVLETotalPago, T005C2_A1340MVLEPagReg, T005C2_A1351MVLEVouAno, T005C2_A1352MVLEVouMes, T005C2_A1345MVLETASICod, T005C2_A1353MVLEVouNum, T005C2_A1342MVLERedondeo, T005C2_A1319MVLEComPorIVA, T005C2_A1349MVLEUsuCod,
               T005C2_A1350MVLEUsuFec, T005C2_A1320MVLEComTipReg, T005C2_A1327MVLEMBanCod, T005C2_A1330MVLEMCtaBco, T005C2_A1329MVLEMBanReg, T005C2_A1328MVLEMBanCon, T005C2_n1328MVLEMBanCon, T005C2_A1331MVLEMTipo, T005C2_A365EntCod, T005C2_A411MVLConcEntCod,
               T005C2_A409MVLECosCod, T005C2_n409MVLECosCod, T005C2_A410MVLEComCosCod, T005C2_n410MVLEComCosCod, T005C2_A408MVLEPrvCod, T005C2_A407MVLECueCod, T005C2_A406MVLEForCod, T005C2_n406MVLEForCod, T005C2_A405MVLEMonCod
               }
               , new Object[] {
               T005C3_A403MVLEntCod, T005C3_A404MVLEITem, T005C3_A1335MVLEntFec, T005C3_A1333MVLEntDoc, T005C3_A1332MVLEntConc, T005C3_A1322MVLECueCodAux, T005C3_A1321MVLECueAuxCod, T005C3_A1336MVLEntImp, T005C3_A1346MVLETipo, T005C3_A1339MVLEntTCod,
               T005C3_A1334MVLEntDocP, T005C3_A1337MVLEntReg, T005C3_A1338MVLEntTCmb, T005C3_A1317MVLEComFec, T005C3_A1318MVLEComFReg, T005C3_A1316MVLEComCueCod, T005C3_A1315MVLEComAux, T005C3_A1343MVLESubAfecto, T005C3_A1344MVLESubInafecto, T005C3_A1326MVLEIGV,
               T005C3_A1347MVLETotal, T005C3_A1348MVLETotalPago, T005C3_A1340MVLEPagReg, T005C3_A1351MVLEVouAno, T005C3_A1352MVLEVouMes, T005C3_A1345MVLETASICod, T005C3_A1353MVLEVouNum, T005C3_A1342MVLERedondeo, T005C3_A1319MVLEComPorIVA, T005C3_A1349MVLEUsuCod,
               T005C3_A1350MVLEUsuFec, T005C3_A1320MVLEComTipReg, T005C3_A1327MVLEMBanCod, T005C3_A1330MVLEMCtaBco, T005C3_A1329MVLEMBanReg, T005C3_A1328MVLEMBanCon, T005C3_n1328MVLEMBanCon, T005C3_A1331MVLEMTipo, T005C3_A365EntCod, T005C3_A411MVLConcEntCod,
               T005C3_A409MVLECosCod, T005C3_n409MVLECosCod, T005C3_A410MVLEComCosCod, T005C3_n410MVLEComCosCod, T005C3_A408MVLEPrvCod, T005C3_A407MVLECueCod, T005C3_A406MVLEForCod, T005C3_n406MVLEForCod, T005C3_A405MVLEMonCod
               }
               , new Object[] {
               T005C4_A365EntCod
               }
               , new Object[] {
               T005C5_A1309MVLConEntDsc, T005C5_A1308MVLConEntCue
               }
               , new Object[] {
               T005C6_A409MVLECosCod
               }
               , new Object[] {
               T005C7_A410MVLEComCosCod
               }
               , new Object[] {
               T005C8_A1341MVLEPrvDsc
               }
               , new Object[] {
               T005C9_A1325MVLECueDsc, T005C9_A1324MVLECueCosCod
               }
               , new Object[] {
               T005C10_A406MVLEForCod
               }
               , new Object[] {
               T005C11_A405MVLEMonCod
               }
               , new Object[] {
               T005C12_A1323MVLECueCos
               }
               , new Object[] {
               T005C13_A403MVLEntCod, T005C13_A404MVLEITem, T005C13_A1335MVLEntFec, T005C13_A1333MVLEntDoc, T005C13_A1332MVLEntConc, T005C13_A1322MVLECueCodAux, T005C13_A1321MVLECueAuxCod, T005C13_A1336MVLEntImp, T005C13_A1346MVLETipo, T005C13_A1339MVLEntTCod,
               T005C13_A1334MVLEntDocP, T005C13_A1337MVLEntReg, T005C13_A1338MVLEntTCmb, T005C13_A1317MVLEComFec, T005C13_A1318MVLEComFReg, T005C13_A1316MVLEComCueCod, T005C13_A1315MVLEComAux, T005C13_A1343MVLESubAfecto, T005C13_A1344MVLESubInafecto, T005C13_A1326MVLEIGV,
               T005C13_A1347MVLETotal, T005C13_A1348MVLETotalPago, T005C13_A1340MVLEPagReg, T005C13_A1351MVLEVouAno, T005C13_A1352MVLEVouMes, T005C13_A1345MVLETASICod, T005C13_A1353MVLEVouNum, T005C13_A1342MVLERedondeo, T005C13_A1319MVLEComPorIVA, T005C13_A1349MVLEUsuCod,
               T005C13_A1350MVLEUsuFec, T005C13_A1320MVLEComTipReg, T005C13_A1323MVLECueCos, T005C13_A1309MVLConEntDsc, T005C13_A1341MVLEPrvDsc, T005C13_A1325MVLECueDsc, T005C13_A1324MVLECueCosCod, T005C13_A1327MVLEMBanCod, T005C13_A1330MVLEMCtaBco, T005C13_A1329MVLEMBanReg,
               T005C13_A1328MVLEMBanCon, T005C13_n1328MVLEMBanCon, T005C13_A1331MVLEMTipo, T005C13_A365EntCod, T005C13_A411MVLConcEntCod, T005C13_A409MVLECosCod, T005C13_n409MVLECosCod, T005C13_A410MVLEComCosCod, T005C13_n410MVLEComCosCod, T005C13_A408MVLEPrvCod,
               T005C13_A407MVLECueCod, T005C13_A406MVLEForCod, T005C13_n406MVLEForCod, T005C13_A405MVLEMonCod, T005C13_A1308MVLConEntCue
               }
               , new Object[] {
               T005C14_A365EntCod
               }
               , new Object[] {
               T005C15_A1309MVLConEntDsc, T005C15_A1308MVLConEntCue
               }
               , new Object[] {
               T005C16_A1323MVLECueCos
               }
               , new Object[] {
               T005C17_A409MVLECosCod
               }
               , new Object[] {
               T005C18_A1341MVLEPrvDsc
               }
               , new Object[] {
               T005C19_A1325MVLECueDsc, T005C19_A1324MVLECueCosCod
               }
               , new Object[] {
               T005C20_A410MVLEComCosCod
               }
               , new Object[] {
               T005C21_A406MVLEForCod
               }
               , new Object[] {
               T005C22_A405MVLEMonCod
               }
               , new Object[] {
               T005C23_A365EntCod, T005C23_A403MVLEntCod, T005C23_A404MVLEITem
               }
               , new Object[] {
               T005C24_A365EntCod, T005C24_A403MVLEntCod, T005C24_A404MVLEITem
               }
               , new Object[] {
               T005C25_A365EntCod, T005C25_A403MVLEntCod, T005C25_A404MVLEITem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005C29_A1309MVLConEntDsc, T005C29_A1308MVLConEntCue
               }
               , new Object[] {
               T005C30_A1323MVLECueCos
               }
               , new Object[] {
               T005C31_A1341MVLEPrvDsc
               }
               , new Object[] {
               T005C32_A1325MVLECueDsc, T005C32_A1324MVLECueCosCod
               }
               , new Object[] {
               T005C33_A365EntCod, T005C33_A403MVLEntCod, T005C33_A404MVLEITem
               }
               , new Object[] {
               T005C34_A365EntCod
               }
               , new Object[] {
               T005C35_A409MVLECosCod
               }
               , new Object[] {
               T005C36_A410MVLEComCosCod
               }
               , new Object[] {
               T005C37_A406MVLEForCod
               }
               , new Object[] {
               T005C38_A405MVLEMonCod
               }
            }
         );
      }

      private short Z1351MVLEVouAno ;
      private short Z1352MVLEVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1351MVLEVouAno ;
      private short A1352MVLEVouMes ;
      private short A1323MVLECueCos ;
      private short A1324MVLECueCosCod ;
      private short GX_JID ;
      private short Z1323MVLECueCos ;
      private short Z1324MVLECueCosCod ;
      private short RcdFound179 ;
      private short nIsDirty_179 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1351MVLEVouAno ;
      private short ZZ1352MVLEVouMes ;
      private short ZZ1323MVLECueCos ;
      private short ZZ1324MVLECueCosCod ;
      private int Z365EntCod ;
      private int Z404MVLEITem ;
      private int Z1345MVLETASICod ;
      private int Z1327MVLEMBanCod ;
      private int Z1328MVLEMBanCon ;
      private int Z411MVLConcEntCod ;
      private int Z406MVLEForCod ;
      private int Z405MVLEMonCod ;
      private int A365EntCod ;
      private int A411MVLConcEntCod ;
      private int A406MVLEForCod ;
      private int A405MVLEMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtEntCod_Enabled ;
      private int edtMVLEntCod_Enabled ;
      private int A404MVLEITem ;
      private int edtMVLEITem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMVLEntFec_Enabled ;
      private int edtMVLEntDoc_Enabled ;
      private int edtMVLEntConc_Enabled ;
      private int edtMVLConcEntCod_Enabled ;
      private int edtMVLECueCodAux_Enabled ;
      private int edtMVLECueAuxCod_Enabled ;
      private int edtMVLECosCod_Enabled ;
      private int edtMVLEntImp_Enabled ;
      private int edtMVLETipo_Enabled ;
      private int edtMVLEPrvCod_Enabled ;
      private int edtMVLEntTCod_Enabled ;
      private int edtMVLEntDocP_Enabled ;
      private int edtMVLEntReg_Enabled ;
      private int edtMVLEntTCmb_Enabled ;
      private int edtMVLEComFec_Enabled ;
      private int edtMVLEComFReg_Enabled ;
      private int edtMVLECueCod_Enabled ;
      private int edtMVLEComCosCod_Enabled ;
      private int edtMVLEComCueCod_Enabled ;
      private int edtMVLEComAux_Enabled ;
      private int edtMVLESubAfecto_Enabled ;
      private int edtMVLESubInafecto_Enabled ;
      private int edtMVLEIGV_Enabled ;
      private int edtMVLETotal_Enabled ;
      private int edtMVLETotalPago_Enabled ;
      private int edtMVLEForCod_Enabled ;
      private int edtMVLEPagReg_Enabled ;
      private int edtMVLEVouAno_Enabled ;
      private int edtMVLEVouMes_Enabled ;
      private int A1345MVLETASICod ;
      private int edtMVLETASICod_Enabled ;
      private int edtMVLEVouNum_Enabled ;
      private int edtMVLEMonCod_Enabled ;
      private int edtMVLERedondeo_Enabled ;
      private int edtMVLEComPorIVA_Enabled ;
      private int edtMVLEUsuCod_Enabled ;
      private int edtMVLEUsuFec_Enabled ;
      private int edtMVLEComTipReg_Enabled ;
      private int edtMVLECueCos_Enabled ;
      private int edtMVLConEntDsc_Enabled ;
      private int edtMVLConEntCue_Enabled ;
      private int edtMVLEPrvDsc_Enabled ;
      private int edtMVLECueDsc_Enabled ;
      private int edtMVLECueCosCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A1328MVLEMBanCon ;
      private int A1327MVLEMBanCod ;
      private int idxLst ;
      private int ZZ365EntCod ;
      private int ZZ404MVLEITem ;
      private int ZZ411MVLConcEntCod ;
      private int ZZ406MVLEForCod ;
      private int ZZ1345MVLETASICod ;
      private int ZZ405MVLEMonCod ;
      private int ZZ1327MVLEMBanCod ;
      private int ZZ1328MVLEMBanCon ;
      private long Z1340MVLEPagReg ;
      private long A1340MVLEPagReg ;
      private long ZZ1340MVLEPagReg ;
      private decimal Z1336MVLEntImp ;
      private decimal Z1338MVLEntTCmb ;
      private decimal Z1343MVLESubAfecto ;
      private decimal Z1344MVLESubInafecto ;
      private decimal Z1326MVLEIGV ;
      private decimal Z1347MVLETotal ;
      private decimal Z1348MVLETotalPago ;
      private decimal Z1342MVLERedondeo ;
      private decimal Z1319MVLEComPorIVA ;
      private decimal A1336MVLEntImp ;
      private decimal A1338MVLEntTCmb ;
      private decimal A1343MVLESubAfecto ;
      private decimal A1344MVLESubInafecto ;
      private decimal A1326MVLEIGV ;
      private decimal A1347MVLETotal ;
      private decimal A1348MVLETotalPago ;
      private decimal A1342MVLERedondeo ;
      private decimal A1319MVLEComPorIVA ;
      private decimal ZZ1336MVLEntImp ;
      private decimal ZZ1338MVLEntTCmb ;
      private decimal ZZ1343MVLESubAfecto ;
      private decimal ZZ1344MVLESubInafecto ;
      private decimal ZZ1326MVLEIGV ;
      private decimal ZZ1347MVLETotal ;
      private decimal ZZ1348MVLETotalPago ;
      private decimal ZZ1342MVLERedondeo ;
      private decimal ZZ1319MVLEComPorIVA ;
      private string sPrefix ;
      private string Z403MVLEntCod ;
      private string Z1333MVLEntDoc ;
      private string Z1332MVLEntConc ;
      private string Z1322MVLECueCodAux ;
      private string Z1321MVLECueAuxCod ;
      private string Z1346MVLETipo ;
      private string Z1339MVLEntTCod ;
      private string Z1334MVLEntDocP ;
      private string Z1337MVLEntReg ;
      private string Z1316MVLEComCueCod ;
      private string Z1315MVLEComAux ;
      private string Z1353MVLEVouNum ;
      private string Z1349MVLEUsuCod ;
      private string Z1320MVLEComTipReg ;
      private string Z1330MVLEMCtaBco ;
      private string Z409MVLECosCod ;
      private string Z410MVLEComCosCod ;
      private string Z408MVLEPrvCod ;
      private string Z407MVLECueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A1308MVLConEntCue ;
      private string A409MVLECosCod ;
      private string A408MVLEPrvCod ;
      private string A407MVLECueCod ;
      private string A410MVLEComCosCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtEntCod_Internalname ;
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
      private string edtEntCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMVLEntCod_Internalname ;
      private string A403MVLEntCod ;
      private string edtMVLEntCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtMVLEITem_Internalname ;
      private string edtMVLEITem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtMVLEntFec_Internalname ;
      private string edtMVLEntFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtMVLEntDoc_Internalname ;
      private string A1333MVLEntDoc ;
      private string edtMVLEntDoc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtMVLEntConc_Internalname ;
      private string A1332MVLEntConc ;
      private string edtMVLEntConc_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtMVLConcEntCod_Internalname ;
      private string edtMVLConcEntCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtMVLECueCodAux_Internalname ;
      private string A1322MVLECueCodAux ;
      private string edtMVLECueCodAux_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtMVLECueAuxCod_Internalname ;
      private string A1321MVLECueAuxCod ;
      private string edtMVLECueAuxCod_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtMVLECosCod_Internalname ;
      private string edtMVLECosCod_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtMVLEntImp_Internalname ;
      private string edtMVLEntImp_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtMVLETipo_Internalname ;
      private string A1346MVLETipo ;
      private string edtMVLETipo_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtMVLEPrvCod_Internalname ;
      private string edtMVLEPrvCod_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtMVLEntTCod_Internalname ;
      private string A1339MVLEntTCod ;
      private string edtMVLEntTCod_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtMVLEntDocP_Internalname ;
      private string A1334MVLEntDocP ;
      private string edtMVLEntDocP_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtMVLEntReg_Internalname ;
      private string A1337MVLEntReg ;
      private string edtMVLEntReg_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtMVLEntTCmb_Internalname ;
      private string edtMVLEntTCmb_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtMVLEComFec_Internalname ;
      private string edtMVLEComFec_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtMVLEComFReg_Internalname ;
      private string edtMVLEComFReg_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtMVLECueCod_Internalname ;
      private string edtMVLECueCod_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtMVLEComCosCod_Internalname ;
      private string edtMVLEComCosCod_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtMVLEComCueCod_Internalname ;
      private string A1316MVLEComCueCod ;
      private string edtMVLEComCueCod_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtMVLEComAux_Internalname ;
      private string A1315MVLEComAux ;
      private string edtMVLEComAux_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtMVLESubAfecto_Internalname ;
      private string edtMVLESubAfecto_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtMVLESubInafecto_Internalname ;
      private string edtMVLESubInafecto_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtMVLEIGV_Internalname ;
      private string edtMVLEIGV_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtMVLETotal_Internalname ;
      private string edtMVLETotal_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtMVLETotalPago_Internalname ;
      private string edtMVLETotalPago_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtMVLEForCod_Internalname ;
      private string edtMVLEForCod_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtMVLEPagReg_Internalname ;
      private string edtMVLEPagReg_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtMVLEVouAno_Internalname ;
      private string edtMVLEVouAno_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtMVLEVouMes_Internalname ;
      private string edtMVLEVouMes_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtMVLETASICod_Internalname ;
      private string edtMVLETASICod_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtMVLEVouNum_Internalname ;
      private string A1353MVLEVouNum ;
      private string edtMVLEVouNum_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtMVLEMonCod_Internalname ;
      private string edtMVLEMonCod_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtMVLERedondeo_Internalname ;
      private string edtMVLERedondeo_Jsonclick ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string edtMVLEComPorIVA_Internalname ;
      private string edtMVLEComPorIVA_Jsonclick ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string edtMVLEUsuCod_Internalname ;
      private string A1349MVLEUsuCod ;
      private string edtMVLEUsuCod_Jsonclick ;
      private string lblTextblock39_Internalname ;
      private string lblTextblock39_Jsonclick ;
      private string edtMVLEUsuFec_Internalname ;
      private string edtMVLEUsuFec_Jsonclick ;
      private string lblTextblock40_Internalname ;
      private string lblTextblock40_Jsonclick ;
      private string edtMVLEComTipReg_Internalname ;
      private string A1320MVLEComTipReg ;
      private string edtMVLEComTipReg_Jsonclick ;
      private string lblTextblock41_Internalname ;
      private string lblTextblock41_Jsonclick ;
      private string edtMVLECueCos_Internalname ;
      private string edtMVLECueCos_Jsonclick ;
      private string lblTextblock42_Internalname ;
      private string lblTextblock42_Jsonclick ;
      private string edtMVLConEntDsc_Internalname ;
      private string A1309MVLConEntDsc ;
      private string edtMVLConEntDsc_Jsonclick ;
      private string lblTextblock43_Internalname ;
      private string lblTextblock43_Jsonclick ;
      private string edtMVLConEntCue_Internalname ;
      private string edtMVLConEntCue_Jsonclick ;
      private string lblTextblock44_Internalname ;
      private string lblTextblock44_Jsonclick ;
      private string edtMVLEPrvDsc_Internalname ;
      private string A1341MVLEPrvDsc ;
      private string edtMVLEPrvDsc_Jsonclick ;
      private string lblTextblock45_Internalname ;
      private string lblTextblock45_Jsonclick ;
      private string edtMVLECueDsc_Internalname ;
      private string A1325MVLECueDsc ;
      private string edtMVLECueDsc_Jsonclick ;
      private string lblTextblock46_Internalname ;
      private string lblTextblock46_Jsonclick ;
      private string edtMVLECueCosCod_Internalname ;
      private string edtMVLECueCosCod_Jsonclick ;
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
      private string A1330MVLEMCtaBco ;
      private string Gx_mode ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1309MVLConEntDsc ;
      private string Z1308MVLConEntCue ;
      private string Z1341MVLEPrvDsc ;
      private string Z1325MVLECueDsc ;
      private string sMode179 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ403MVLEntCod ;
      private string ZZ1333MVLEntDoc ;
      private string ZZ1332MVLEntConc ;
      private string ZZ1322MVLECueCodAux ;
      private string ZZ1321MVLECueAuxCod ;
      private string ZZ409MVLECosCod ;
      private string ZZ1346MVLETipo ;
      private string ZZ408MVLEPrvCod ;
      private string ZZ1339MVLEntTCod ;
      private string ZZ1334MVLEntDocP ;
      private string ZZ1337MVLEntReg ;
      private string ZZ407MVLECueCod ;
      private string ZZ410MVLEComCosCod ;
      private string ZZ1316MVLEComCueCod ;
      private string ZZ1315MVLEComAux ;
      private string ZZ1353MVLEVouNum ;
      private string ZZ1349MVLEUsuCod ;
      private string ZZ1320MVLEComTipReg ;
      private string ZZ1330MVLEMCtaBco ;
      private string ZZ1309MVLConEntDsc ;
      private string ZZ1308MVLConEntCue ;
      private string ZZ1341MVLEPrvDsc ;
      private string ZZ1325MVLECueDsc ;
      private DateTime Z1350MVLEUsuFec ;
      private DateTime A1350MVLEUsuFec ;
      private DateTime ZZ1350MVLEUsuFec ;
      private DateTime Z1335MVLEntFec ;
      private DateTime Z1317MVLEComFec ;
      private DateTime Z1318MVLEComFReg ;
      private DateTime A1335MVLEntFec ;
      private DateTime A1317MVLEComFec ;
      private DateTime A1318MVLEComFReg ;
      private DateTime ZZ1335MVLEntFec ;
      private DateTime ZZ1317MVLEComFec ;
      private DateTime ZZ1318MVLEComFReg ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n409MVLECosCod ;
      private bool n410MVLEComCosCod ;
      private bool n406MVLEForCod ;
      private bool wbErr ;
      private bool n1328MVLEMBanCon ;
      private bool Gx_longc ;
      private string Z1329MVLEMBanReg ;
      private string Z1331MVLEMTipo ;
      private string A1329MVLEMBanReg ;
      private string A1331MVLEMTipo ;
      private string ZZ1329MVLEMBanReg ;
      private string ZZ1331MVLEMTipo ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T005C13_A403MVLEntCod ;
      private int[] T005C13_A404MVLEITem ;
      private DateTime[] T005C13_A1335MVLEntFec ;
      private string[] T005C13_A1333MVLEntDoc ;
      private string[] T005C13_A1332MVLEntConc ;
      private string[] T005C13_A1322MVLECueCodAux ;
      private string[] T005C13_A1321MVLECueAuxCod ;
      private decimal[] T005C13_A1336MVLEntImp ;
      private string[] T005C13_A1346MVLETipo ;
      private string[] T005C13_A1339MVLEntTCod ;
      private string[] T005C13_A1334MVLEntDocP ;
      private string[] T005C13_A1337MVLEntReg ;
      private decimal[] T005C13_A1338MVLEntTCmb ;
      private DateTime[] T005C13_A1317MVLEComFec ;
      private DateTime[] T005C13_A1318MVLEComFReg ;
      private string[] T005C13_A1316MVLEComCueCod ;
      private string[] T005C13_A1315MVLEComAux ;
      private decimal[] T005C13_A1343MVLESubAfecto ;
      private decimal[] T005C13_A1344MVLESubInafecto ;
      private decimal[] T005C13_A1326MVLEIGV ;
      private decimal[] T005C13_A1347MVLETotal ;
      private decimal[] T005C13_A1348MVLETotalPago ;
      private long[] T005C13_A1340MVLEPagReg ;
      private short[] T005C13_A1351MVLEVouAno ;
      private short[] T005C13_A1352MVLEVouMes ;
      private int[] T005C13_A1345MVLETASICod ;
      private string[] T005C13_A1353MVLEVouNum ;
      private decimal[] T005C13_A1342MVLERedondeo ;
      private decimal[] T005C13_A1319MVLEComPorIVA ;
      private string[] T005C13_A1349MVLEUsuCod ;
      private DateTime[] T005C13_A1350MVLEUsuFec ;
      private string[] T005C13_A1320MVLEComTipReg ;
      private short[] T005C13_A1323MVLECueCos ;
      private string[] T005C13_A1309MVLConEntDsc ;
      private string[] T005C13_A1341MVLEPrvDsc ;
      private string[] T005C13_A1325MVLECueDsc ;
      private short[] T005C13_A1324MVLECueCosCod ;
      private int[] T005C13_A1327MVLEMBanCod ;
      private string[] T005C13_A1330MVLEMCtaBco ;
      private string[] T005C13_A1329MVLEMBanReg ;
      private int[] T005C13_A1328MVLEMBanCon ;
      private bool[] T005C13_n1328MVLEMBanCon ;
      private string[] T005C13_A1331MVLEMTipo ;
      private int[] T005C13_A365EntCod ;
      private int[] T005C13_A411MVLConcEntCod ;
      private string[] T005C13_A409MVLECosCod ;
      private bool[] T005C13_n409MVLECosCod ;
      private string[] T005C13_A410MVLEComCosCod ;
      private bool[] T005C13_n410MVLEComCosCod ;
      private string[] T005C13_A408MVLEPrvCod ;
      private string[] T005C13_A407MVLECueCod ;
      private int[] T005C13_A406MVLEForCod ;
      private bool[] T005C13_n406MVLEForCod ;
      private int[] T005C13_A405MVLEMonCod ;
      private string[] T005C13_A1308MVLConEntCue ;
      private int[] T005C4_A365EntCod ;
      private string[] T005C5_A1309MVLConEntDsc ;
      private string[] T005C5_A1308MVLConEntCue ;
      private short[] T005C12_A1323MVLECueCos ;
      private string[] T005C6_A409MVLECosCod ;
      private bool[] T005C6_n409MVLECosCod ;
      private string[] T005C8_A1341MVLEPrvDsc ;
      private string[] T005C9_A1325MVLECueDsc ;
      private short[] T005C9_A1324MVLECueCosCod ;
      private string[] T005C7_A410MVLEComCosCod ;
      private bool[] T005C7_n410MVLEComCosCod ;
      private int[] T005C10_A406MVLEForCod ;
      private bool[] T005C10_n406MVLEForCod ;
      private int[] T005C11_A405MVLEMonCod ;
      private int[] T005C14_A365EntCod ;
      private string[] T005C15_A1309MVLConEntDsc ;
      private string[] T005C15_A1308MVLConEntCue ;
      private short[] T005C16_A1323MVLECueCos ;
      private string[] T005C17_A409MVLECosCod ;
      private bool[] T005C17_n409MVLECosCod ;
      private string[] T005C18_A1341MVLEPrvDsc ;
      private string[] T005C19_A1325MVLECueDsc ;
      private short[] T005C19_A1324MVLECueCosCod ;
      private string[] T005C20_A410MVLEComCosCod ;
      private bool[] T005C20_n410MVLEComCosCod ;
      private int[] T005C21_A406MVLEForCod ;
      private bool[] T005C21_n406MVLEForCod ;
      private int[] T005C22_A405MVLEMonCod ;
      private int[] T005C23_A365EntCod ;
      private string[] T005C23_A403MVLEntCod ;
      private int[] T005C23_A404MVLEITem ;
      private string[] T005C3_A403MVLEntCod ;
      private int[] T005C3_A404MVLEITem ;
      private DateTime[] T005C3_A1335MVLEntFec ;
      private string[] T005C3_A1333MVLEntDoc ;
      private string[] T005C3_A1332MVLEntConc ;
      private string[] T005C3_A1322MVLECueCodAux ;
      private string[] T005C3_A1321MVLECueAuxCod ;
      private decimal[] T005C3_A1336MVLEntImp ;
      private string[] T005C3_A1346MVLETipo ;
      private string[] T005C3_A1339MVLEntTCod ;
      private string[] T005C3_A1334MVLEntDocP ;
      private string[] T005C3_A1337MVLEntReg ;
      private decimal[] T005C3_A1338MVLEntTCmb ;
      private DateTime[] T005C3_A1317MVLEComFec ;
      private DateTime[] T005C3_A1318MVLEComFReg ;
      private string[] T005C3_A1316MVLEComCueCod ;
      private string[] T005C3_A1315MVLEComAux ;
      private decimal[] T005C3_A1343MVLESubAfecto ;
      private decimal[] T005C3_A1344MVLESubInafecto ;
      private decimal[] T005C3_A1326MVLEIGV ;
      private decimal[] T005C3_A1347MVLETotal ;
      private decimal[] T005C3_A1348MVLETotalPago ;
      private long[] T005C3_A1340MVLEPagReg ;
      private short[] T005C3_A1351MVLEVouAno ;
      private short[] T005C3_A1352MVLEVouMes ;
      private int[] T005C3_A1345MVLETASICod ;
      private string[] T005C3_A1353MVLEVouNum ;
      private decimal[] T005C3_A1342MVLERedondeo ;
      private decimal[] T005C3_A1319MVLEComPorIVA ;
      private string[] T005C3_A1349MVLEUsuCod ;
      private DateTime[] T005C3_A1350MVLEUsuFec ;
      private string[] T005C3_A1320MVLEComTipReg ;
      private int[] T005C3_A1327MVLEMBanCod ;
      private string[] T005C3_A1330MVLEMCtaBco ;
      private string[] T005C3_A1329MVLEMBanReg ;
      private int[] T005C3_A1328MVLEMBanCon ;
      private bool[] T005C3_n1328MVLEMBanCon ;
      private string[] T005C3_A1331MVLEMTipo ;
      private int[] T005C3_A365EntCod ;
      private int[] T005C3_A411MVLConcEntCod ;
      private string[] T005C3_A409MVLECosCod ;
      private bool[] T005C3_n409MVLECosCod ;
      private string[] T005C3_A410MVLEComCosCod ;
      private bool[] T005C3_n410MVLEComCosCod ;
      private string[] T005C3_A408MVLEPrvCod ;
      private string[] T005C3_A407MVLECueCod ;
      private int[] T005C3_A406MVLEForCod ;
      private bool[] T005C3_n406MVLEForCod ;
      private int[] T005C3_A405MVLEMonCod ;
      private int[] T005C24_A365EntCod ;
      private string[] T005C24_A403MVLEntCod ;
      private int[] T005C24_A404MVLEITem ;
      private int[] T005C25_A365EntCod ;
      private string[] T005C25_A403MVLEntCod ;
      private int[] T005C25_A404MVLEITem ;
      private string[] T005C2_A403MVLEntCod ;
      private int[] T005C2_A404MVLEITem ;
      private DateTime[] T005C2_A1335MVLEntFec ;
      private string[] T005C2_A1333MVLEntDoc ;
      private string[] T005C2_A1332MVLEntConc ;
      private string[] T005C2_A1322MVLECueCodAux ;
      private string[] T005C2_A1321MVLECueAuxCod ;
      private decimal[] T005C2_A1336MVLEntImp ;
      private string[] T005C2_A1346MVLETipo ;
      private string[] T005C2_A1339MVLEntTCod ;
      private string[] T005C2_A1334MVLEntDocP ;
      private string[] T005C2_A1337MVLEntReg ;
      private decimal[] T005C2_A1338MVLEntTCmb ;
      private DateTime[] T005C2_A1317MVLEComFec ;
      private DateTime[] T005C2_A1318MVLEComFReg ;
      private string[] T005C2_A1316MVLEComCueCod ;
      private string[] T005C2_A1315MVLEComAux ;
      private decimal[] T005C2_A1343MVLESubAfecto ;
      private decimal[] T005C2_A1344MVLESubInafecto ;
      private decimal[] T005C2_A1326MVLEIGV ;
      private decimal[] T005C2_A1347MVLETotal ;
      private decimal[] T005C2_A1348MVLETotalPago ;
      private long[] T005C2_A1340MVLEPagReg ;
      private short[] T005C2_A1351MVLEVouAno ;
      private short[] T005C2_A1352MVLEVouMes ;
      private int[] T005C2_A1345MVLETASICod ;
      private string[] T005C2_A1353MVLEVouNum ;
      private decimal[] T005C2_A1342MVLERedondeo ;
      private decimal[] T005C2_A1319MVLEComPorIVA ;
      private string[] T005C2_A1349MVLEUsuCod ;
      private DateTime[] T005C2_A1350MVLEUsuFec ;
      private string[] T005C2_A1320MVLEComTipReg ;
      private int[] T005C2_A1327MVLEMBanCod ;
      private string[] T005C2_A1330MVLEMCtaBco ;
      private string[] T005C2_A1329MVLEMBanReg ;
      private int[] T005C2_A1328MVLEMBanCon ;
      private bool[] T005C2_n1328MVLEMBanCon ;
      private string[] T005C2_A1331MVLEMTipo ;
      private int[] T005C2_A365EntCod ;
      private int[] T005C2_A411MVLConcEntCod ;
      private string[] T005C2_A409MVLECosCod ;
      private bool[] T005C2_n409MVLECosCod ;
      private string[] T005C2_A410MVLEComCosCod ;
      private bool[] T005C2_n410MVLEComCosCod ;
      private string[] T005C2_A408MVLEPrvCod ;
      private string[] T005C2_A407MVLECueCod ;
      private int[] T005C2_A406MVLEForCod ;
      private bool[] T005C2_n406MVLEForCod ;
      private int[] T005C2_A405MVLEMonCod ;
      private string[] T005C29_A1309MVLConEntDsc ;
      private string[] T005C29_A1308MVLConEntCue ;
      private short[] T005C30_A1323MVLECueCos ;
      private string[] T005C31_A1341MVLEPrvDsc ;
      private string[] T005C32_A1325MVLECueDsc ;
      private short[] T005C32_A1324MVLECueCosCod ;
      private int[] T005C33_A365EntCod ;
      private string[] T005C33_A403MVLEntCod ;
      private int[] T005C33_A404MVLEITem ;
      private int[] T005C34_A365EntCod ;
      private string[] T005C35_A409MVLECosCod ;
      private bool[] T005C35_n409MVLECosCod ;
      private string[] T005C36_A410MVLEComCosCod ;
      private bool[] T005C36_n410MVLEComCosCod ;
      private int[] T005C37_A406MVLEForCod ;
      private bool[] T005C37_n406MVLEForCod ;
      private int[] T005C38_A405MVLEMonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class tsmoventrega__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tsmoventrega__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT005C13;
        prmT005C13 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C4;
        prmT005C4 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005C5;
        prmT005C5 = new Object[] {
        new ParDef("@MVLConcEntCod",GXType.Int32,6,0)
        };
        Object[] prmT005C12;
        prmT005C12 = new Object[] {
        new ParDef("@MVLConEntCue",GXType.NChar,15,0)
        };
        Object[] prmT005C6;
        prmT005C6 = new Object[] {
        new ParDef("@MVLECosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005C8;
        prmT005C8 = new Object[] {
        new ParDef("@MVLEPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005C9;
        prmT005C9 = new Object[] {
        new ParDef("@MVLECueCod",GXType.NChar,15,0)
        };
        Object[] prmT005C7;
        prmT005C7 = new Object[] {
        new ParDef("@MVLEComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005C10;
        prmT005C10 = new Object[] {
        new ParDef("@MVLEForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005C11;
        prmT005C11 = new Object[] {
        new ParDef("@MVLEMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005C14;
        prmT005C14 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005C15;
        prmT005C15 = new Object[] {
        new ParDef("@MVLConcEntCod",GXType.Int32,6,0)
        };
        Object[] prmT005C16;
        prmT005C16 = new Object[] {
        new ParDef("@MVLConEntCue",GXType.NChar,15,0)
        };
        Object[] prmT005C17;
        prmT005C17 = new Object[] {
        new ParDef("@MVLECosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005C18;
        prmT005C18 = new Object[] {
        new ParDef("@MVLEPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005C19;
        prmT005C19 = new Object[] {
        new ParDef("@MVLECueCod",GXType.NChar,15,0)
        };
        Object[] prmT005C20;
        prmT005C20 = new Object[] {
        new ParDef("@MVLEComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005C21;
        prmT005C21 = new Object[] {
        new ParDef("@MVLEForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005C22;
        prmT005C22 = new Object[] {
        new ParDef("@MVLEMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005C23;
        prmT005C23 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C3;
        prmT005C3 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C24;
        prmT005C24 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C25;
        prmT005C25 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C2;
        prmT005C2 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C26;
        prmT005C26 = new Object[] {
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0) ,
        new ParDef("@MVLEntFec",GXType.Date,8,0) ,
        new ParDef("@MVLEntDoc",GXType.NChar,20,0) ,
        new ParDef("@MVLEntConc",GXType.NChar,100,0) ,
        new ParDef("@MVLECueCodAux",GXType.NChar,15,0) ,
        new ParDef("@MVLECueAuxCod",GXType.NChar,20,0) ,
        new ParDef("@MVLEntImp",GXType.Decimal,15,2) ,
        new ParDef("@MVLETipo",GXType.NChar,3,0) ,
        new ParDef("@MVLEntTCod",GXType.NChar,3,0) ,
        new ParDef("@MVLEntDocP",GXType.NChar,15,0) ,
        new ParDef("@MVLEntReg",GXType.NChar,10,0) ,
        new ParDef("@MVLEntTCmb",GXType.Decimal,10,4) ,
        new ParDef("@MVLEComFec",GXType.Date,8,0) ,
        new ParDef("@MVLEComFReg",GXType.Date,8,0) ,
        new ParDef("@MVLEComCueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLEComAux",GXType.NChar,20,0) ,
        new ParDef("@MVLESubAfecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLESubInafecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLEIGV",GXType.Decimal,15,2) ,
        new ParDef("@MVLETotal",GXType.Decimal,15,2) ,
        new ParDef("@MVLETotalPago",GXType.Decimal,15,2) ,
        new ParDef("@MVLEPagReg",GXType.Decimal,10,0) ,
        new ParDef("@MVLEVouAno",GXType.Int16,4,0) ,
        new ParDef("@MVLEVouMes",GXType.Int16,2,0) ,
        new ParDef("@MVLETASICod",GXType.Int32,6,0) ,
        new ParDef("@MVLEVouNum",GXType.NChar,10,0) ,
        new ParDef("@MVLERedondeo",GXType.Decimal,15,2) ,
        new ParDef("@MVLEComPorIVA",GXType.Decimal,15,2) ,
        new ParDef("@MVLEUsuCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@MVLEComTipReg",GXType.NChar,1,0) ,
        new ParDef("@MVLEMBanCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEMCtaBco",GXType.NChar,20,0) ,
        new ParDef("@MVLEMBanReg",GXType.NVarChar,10,0) ,
        new ParDef("@MVLEMBanCon",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVLEMTipo",GXType.NVarChar,1,0) ,
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLConcEntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLECosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLEComCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLEPrvCod",GXType.NChar,20,0) ,
        new ParDef("@MVLECueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLEForCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVLEMonCod",GXType.Int32,6,0)
        };
        Object[] prmT005C27;
        prmT005C27 = new Object[] {
        new ParDef("@MVLEntFec",GXType.Date,8,0) ,
        new ParDef("@MVLEntDoc",GXType.NChar,20,0) ,
        new ParDef("@MVLEntConc",GXType.NChar,100,0) ,
        new ParDef("@MVLECueCodAux",GXType.NChar,15,0) ,
        new ParDef("@MVLECueAuxCod",GXType.NChar,20,0) ,
        new ParDef("@MVLEntImp",GXType.Decimal,15,2) ,
        new ParDef("@MVLETipo",GXType.NChar,3,0) ,
        new ParDef("@MVLEntTCod",GXType.NChar,3,0) ,
        new ParDef("@MVLEntDocP",GXType.NChar,15,0) ,
        new ParDef("@MVLEntReg",GXType.NChar,10,0) ,
        new ParDef("@MVLEntTCmb",GXType.Decimal,10,4) ,
        new ParDef("@MVLEComFec",GXType.Date,8,0) ,
        new ParDef("@MVLEComFReg",GXType.Date,8,0) ,
        new ParDef("@MVLEComCueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLEComAux",GXType.NChar,20,0) ,
        new ParDef("@MVLESubAfecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLESubInafecto",GXType.Decimal,15,2) ,
        new ParDef("@MVLEIGV",GXType.Decimal,15,2) ,
        new ParDef("@MVLETotal",GXType.Decimal,15,2) ,
        new ParDef("@MVLETotalPago",GXType.Decimal,15,2) ,
        new ParDef("@MVLEPagReg",GXType.Decimal,10,0) ,
        new ParDef("@MVLEVouAno",GXType.Int16,4,0) ,
        new ParDef("@MVLEVouMes",GXType.Int16,2,0) ,
        new ParDef("@MVLETASICod",GXType.Int32,6,0) ,
        new ParDef("@MVLEVouNum",GXType.NChar,10,0) ,
        new ParDef("@MVLERedondeo",GXType.Decimal,15,2) ,
        new ParDef("@MVLEComPorIVA",GXType.Decimal,15,2) ,
        new ParDef("@MVLEUsuCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@MVLEComTipReg",GXType.NChar,1,0) ,
        new ParDef("@MVLEMBanCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEMCtaBco",GXType.NChar,20,0) ,
        new ParDef("@MVLEMBanReg",GXType.NVarChar,10,0) ,
        new ParDef("@MVLEMBanCon",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVLEMTipo",GXType.NVarChar,1,0) ,
        new ParDef("@MVLConcEntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLECosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLEComCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVLEPrvCod",GXType.NChar,20,0) ,
        new ParDef("@MVLECueCod",GXType.NChar,15,0) ,
        new ParDef("@MVLEForCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVLEMonCod",GXType.Int32,6,0) ,
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C28;
        prmT005C28 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0) ,
        new ParDef("@MVLEntCod",GXType.NChar,10,0) ,
        new ParDef("@MVLEITem",GXType.Int32,6,0)
        };
        Object[] prmT005C33;
        prmT005C33 = new Object[] {
        };
        Object[] prmT005C34;
        prmT005C34 = new Object[] {
        new ParDef("@EntCod",GXType.Int32,6,0)
        };
        Object[] prmT005C29;
        prmT005C29 = new Object[] {
        new ParDef("@MVLConcEntCod",GXType.Int32,6,0)
        };
        Object[] prmT005C30;
        prmT005C30 = new Object[] {
        new ParDef("@MVLConEntCue",GXType.NChar,15,0)
        };
        Object[] prmT005C35;
        prmT005C35 = new Object[] {
        new ParDef("@MVLECosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005C31;
        prmT005C31 = new Object[] {
        new ParDef("@MVLEPrvCod",GXType.NChar,20,0)
        };
        Object[] prmT005C32;
        prmT005C32 = new Object[] {
        new ParDef("@MVLECueCod",GXType.NChar,15,0)
        };
        Object[] prmT005C36;
        prmT005C36 = new Object[] {
        new ParDef("@MVLEComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT005C37;
        prmT005C37 = new Object[] {
        new ParDef("@MVLEForCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005C38;
        prmT005C38 = new Object[] {
        new ParDef("@MVLEMonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T005C2", "SELECT [MVLEntCod], [MVLEITem], [MVLEntFec], [MVLEntDoc], [MVLEntConc], [MVLECueCodAux], [MVLECueAuxCod], [MVLEntImp], [MVLETipo], [MVLEntTCod], [MVLEntDocP], [MVLEntReg], [MVLEntTCmb], [MVLEComFec], [MVLEComFReg], [MVLEComCueCod], [MVLEComAux], [MVLESubAfecto], [MVLESubInafecto], [MVLEIGV], [MVLETotal], [MVLETotalPago], [MVLEPagReg], [MVLEVouAno], [MVLEVouMes], [MVLETASICod], [MVLEVouNum], [MVLERedondeo], [MVLEComPorIVA], [MVLEUsuCod], [MVLEUsuFec], [MVLEComTipReg], [MVLEMBanCod], [MVLEMCtaBco], [MVLEMBanReg], [MVLEMBanCon], [MVLEMTipo], [EntCod], [MVLConcEntCod] AS MVLConcEntCod, [MVLECosCod] AS MVLECosCod, [MVLEComCosCod] AS MVLEComCosCod, [MVLEPrvCod] AS MVLEPrvCod, [MVLECueCod] AS MVLECueCod, [MVLEForCod] AS MVLEForCod, [MVLEMonCod] AS MVLEMonCod FROM [TSMOVENTREGA] WITH (UPDLOCK) WHERE [EntCod] = @EntCod AND [MVLEntCod] = @MVLEntCod AND [MVLEITem] = @MVLEITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C3", "SELECT [MVLEntCod], [MVLEITem], [MVLEntFec], [MVLEntDoc], [MVLEntConc], [MVLECueCodAux], [MVLECueAuxCod], [MVLEntImp], [MVLETipo], [MVLEntTCod], [MVLEntDocP], [MVLEntReg], [MVLEntTCmb], [MVLEComFec], [MVLEComFReg], [MVLEComCueCod], [MVLEComAux], [MVLESubAfecto], [MVLESubInafecto], [MVLEIGV], [MVLETotal], [MVLETotalPago], [MVLEPagReg], [MVLEVouAno], [MVLEVouMes], [MVLETASICod], [MVLEVouNum], [MVLERedondeo], [MVLEComPorIVA], [MVLEUsuCod], [MVLEUsuFec], [MVLEComTipReg], [MVLEMBanCod], [MVLEMCtaBco], [MVLEMBanReg], [MVLEMBanCon], [MVLEMTipo], [EntCod], [MVLConcEntCod] AS MVLConcEntCod, [MVLECosCod] AS MVLECosCod, [MVLEComCosCod] AS MVLEComCosCod, [MVLEPrvCod] AS MVLEPrvCod, [MVLECueCod] AS MVLECueCod, [MVLEForCod] AS MVLEForCod, [MVLEMonCod] AS MVLEMonCod FROM [TSMOVENTREGA] WHERE [EntCod] = @EntCod AND [MVLEntCod] = @MVLEntCod AND [MVLEITem] = @MVLEITem ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C4", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C5", "SELECT [ConEntDsc] AS MVLConEntDsc, [CueCod] AS MVLConEntCue FROM [TSCONCEPTOENTREGA] WHERE [ConEntCod] = @MVLConcEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C6", "SELECT [COSCod] AS MVLECosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLECosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C7", "SELECT [COSCod] AS MVLEComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLEComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C8", "SELECT [PrvDsc] AS MVLEPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @MVLEPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C9", "SELECT [CueDsc] AS MVLECueDsc, [CueCos] AS MVLECueCosCod FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLECueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C10", "SELECT [ForCod] AS MVLEForCod FROM [CFORMAPAGO] WHERE [ForCod] = @MVLEForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C11", "SELECT [MonCod] AS MVLEMonCod FROM [CMONEDAS] WHERE [MonCod] = @MVLEMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C12", "SELECT [CueCos] AS MVLECueCos FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLConEntCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C13", "SELECT TM1.[MVLEntCod], TM1.[MVLEITem], TM1.[MVLEntFec], TM1.[MVLEntDoc], TM1.[MVLEntConc], TM1.[MVLECueCodAux], TM1.[MVLECueAuxCod], TM1.[MVLEntImp], TM1.[MVLETipo], TM1.[MVLEntTCod], TM1.[MVLEntDocP], TM1.[MVLEntReg], TM1.[MVLEntTCmb], TM1.[MVLEComFec], TM1.[MVLEComFReg], TM1.[MVLEComCueCod], TM1.[MVLEComAux], TM1.[MVLESubAfecto], TM1.[MVLESubInafecto], TM1.[MVLEIGV], TM1.[MVLETotal], TM1.[MVLETotalPago], TM1.[MVLEPagReg], TM1.[MVLEVouAno], TM1.[MVLEVouMes], TM1.[MVLETASICod], TM1.[MVLEVouNum], TM1.[MVLERedondeo], TM1.[MVLEComPorIVA], TM1.[MVLEUsuCod], TM1.[MVLEUsuFec], TM1.[MVLEComTipReg], T3.[CueCos] AS MVLECueCos, T2.[ConEntDsc] AS MVLConEntDsc, T4.[PrvDsc] AS MVLEPrvDsc, T5.[CueDsc] AS MVLECueDsc, T5.[CueCos] AS MVLECueCosCod, TM1.[MVLEMBanCod], TM1.[MVLEMCtaBco], TM1.[MVLEMBanReg], TM1.[MVLEMBanCon], TM1.[MVLEMTipo], TM1.[EntCod], TM1.[MVLConcEntCod] AS MVLConcEntCod, TM1.[MVLECosCod] AS MVLECosCod, TM1.[MVLEComCosCod] AS MVLEComCosCod, TM1.[MVLEPrvCod] AS MVLEPrvCod, TM1.[MVLECueCod] AS MVLECueCod, TM1.[MVLEForCod] AS MVLEForCod, TM1.[MVLEMonCod] AS MVLEMonCod, T2.[CueCod] AS MVLConEntCue FROM (((([TSMOVENTREGA] TM1 INNER JOIN [TSCONCEPTOENTREGA] T2 ON T2.[ConEntCod] = TM1.[MVLConcEntCod]) INNER JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = T2.[CueCod]) INNER JOIN [CPPROVEEDORES] T4 ON T4.[PrvCod] = TM1.[MVLEPrvCod]) INNER JOIN [CBPLANCUENTA] T5 ON T5.[CueCod] = TM1.[MVLECueCod]) WHERE TM1.[EntCod] = @EntCod and TM1.[MVLEntCod] = @MVLEntCod and TM1.[MVLEITem] = @MVLEITem ORDER BY TM1.[EntCod], TM1.[MVLEntCod], TM1.[MVLEITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005C13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C14", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C15", "SELECT [ConEntDsc] AS MVLConEntDsc, [CueCod] AS MVLConEntCue FROM [TSCONCEPTOENTREGA] WHERE [ConEntCod] = @MVLConcEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C16", "SELECT [CueCos] AS MVLECueCos FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLConEntCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C17", "SELECT [COSCod] AS MVLECosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLECosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C18", "SELECT [PrvDsc] AS MVLEPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @MVLEPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C19", "SELECT [CueDsc] AS MVLECueDsc, [CueCos] AS MVLECueCosCod FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLECueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C20", "SELECT [COSCod] AS MVLEComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLEComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C21", "SELECT [ForCod] AS MVLEForCod FROM [CFORMAPAGO] WHERE [ForCod] = @MVLEForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C22", "SELECT [MonCod] AS MVLEMonCod FROM [CMONEDAS] WHERE [MonCod] = @MVLEMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C23", "SELECT [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [EntCod] = @EntCod AND [MVLEntCod] = @MVLEntCod AND [MVLEITem] = @MVLEITem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005C23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C24", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE ( [EntCod] > @EntCod or [EntCod] = @EntCod and [MVLEntCod] > @MVLEntCod or [MVLEntCod] = @MVLEntCod and [EntCod] = @EntCod and [MVLEITem] > @MVLEITem) ORDER BY [EntCod], [MVLEntCod], [MVLEITem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005C24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005C25", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE ( [EntCod] < @EntCod or [EntCod] = @EntCod and [MVLEntCod] < @MVLEntCod or [MVLEntCod] = @MVLEntCod and [EntCod] = @EntCod and [MVLEITem] < @MVLEITem) ORDER BY [EntCod] DESC, [MVLEntCod] DESC, [MVLEITem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005C25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005C26", "INSERT INTO [TSMOVENTREGA]([MVLEntCod], [MVLEITem], [MVLEntFec], [MVLEntDoc], [MVLEntConc], [MVLECueCodAux], [MVLECueAuxCod], [MVLEntImp], [MVLETipo], [MVLEntTCod], [MVLEntDocP], [MVLEntReg], [MVLEntTCmb], [MVLEComFec], [MVLEComFReg], [MVLEComCueCod], [MVLEComAux], [MVLESubAfecto], [MVLESubInafecto], [MVLEIGV], [MVLETotal], [MVLETotalPago], [MVLEPagReg], [MVLEVouAno], [MVLEVouMes], [MVLETASICod], [MVLEVouNum], [MVLERedondeo], [MVLEComPorIVA], [MVLEUsuCod], [MVLEUsuFec], [MVLEComTipReg], [MVLEMBanCod], [MVLEMCtaBco], [MVLEMBanReg], [MVLEMBanCon], [MVLEMTipo], [EntCod], [MVLConcEntCod], [MVLECosCod], [MVLEComCosCod], [MVLEPrvCod], [MVLECueCod], [MVLEForCod], [MVLEMonCod]) VALUES(@MVLEntCod, @MVLEITem, @MVLEntFec, @MVLEntDoc, @MVLEntConc, @MVLECueCodAux, @MVLECueAuxCod, @MVLEntImp, @MVLETipo, @MVLEntTCod, @MVLEntDocP, @MVLEntReg, @MVLEntTCmb, @MVLEComFec, @MVLEComFReg, @MVLEComCueCod, @MVLEComAux, @MVLESubAfecto, @MVLESubInafecto, @MVLEIGV, @MVLETotal, @MVLETotalPago, @MVLEPagReg, @MVLEVouAno, @MVLEVouMes, @MVLETASICod, @MVLEVouNum, @MVLERedondeo, @MVLEComPorIVA, @MVLEUsuCod, @MVLEUsuFec, @MVLEComTipReg, @MVLEMBanCod, @MVLEMCtaBco, @MVLEMBanReg, @MVLEMBanCon, @MVLEMTipo, @EntCod, @MVLConcEntCod, @MVLECosCod, @MVLEComCosCod, @MVLEPrvCod, @MVLECueCod, @MVLEForCod, @MVLEMonCod)", GxErrorMask.GX_NOMASK,prmT005C26)
           ,new CursorDef("T005C27", "UPDATE [TSMOVENTREGA] SET [MVLEntFec]=@MVLEntFec, [MVLEntDoc]=@MVLEntDoc, [MVLEntConc]=@MVLEntConc, [MVLECueCodAux]=@MVLECueCodAux, [MVLECueAuxCod]=@MVLECueAuxCod, [MVLEntImp]=@MVLEntImp, [MVLETipo]=@MVLETipo, [MVLEntTCod]=@MVLEntTCod, [MVLEntDocP]=@MVLEntDocP, [MVLEntReg]=@MVLEntReg, [MVLEntTCmb]=@MVLEntTCmb, [MVLEComFec]=@MVLEComFec, [MVLEComFReg]=@MVLEComFReg, [MVLEComCueCod]=@MVLEComCueCod, [MVLEComAux]=@MVLEComAux, [MVLESubAfecto]=@MVLESubAfecto, [MVLESubInafecto]=@MVLESubInafecto, [MVLEIGV]=@MVLEIGV, [MVLETotal]=@MVLETotal, [MVLETotalPago]=@MVLETotalPago, [MVLEPagReg]=@MVLEPagReg, [MVLEVouAno]=@MVLEVouAno, [MVLEVouMes]=@MVLEVouMes, [MVLETASICod]=@MVLETASICod, [MVLEVouNum]=@MVLEVouNum, [MVLERedondeo]=@MVLERedondeo, [MVLEComPorIVA]=@MVLEComPorIVA, [MVLEUsuCod]=@MVLEUsuCod, [MVLEUsuFec]=@MVLEUsuFec, [MVLEComTipReg]=@MVLEComTipReg, [MVLEMBanCod]=@MVLEMBanCod, [MVLEMCtaBco]=@MVLEMCtaBco, [MVLEMBanReg]=@MVLEMBanReg, [MVLEMBanCon]=@MVLEMBanCon, [MVLEMTipo]=@MVLEMTipo, [MVLConcEntCod]=@MVLConcEntCod, [MVLECosCod]=@MVLECosCod, [MVLEComCosCod]=@MVLEComCosCod, [MVLEPrvCod]=@MVLEPrvCod, [MVLECueCod]=@MVLECueCod, [MVLEForCod]=@MVLEForCod, [MVLEMonCod]=@MVLEMonCod  WHERE [EntCod] = @EntCod AND [MVLEntCod] = @MVLEntCod AND [MVLEITem] = @MVLEITem", GxErrorMask.GX_NOMASK,prmT005C27)
           ,new CursorDef("T005C28", "DELETE FROM [TSMOVENTREGA]  WHERE [EntCod] = @EntCod AND [MVLEntCod] = @MVLEntCod AND [MVLEITem] = @MVLEITem", GxErrorMask.GX_NOMASK,prmT005C28)
           ,new CursorDef("T005C29", "SELECT [ConEntDsc] AS MVLConEntDsc, [CueCod] AS MVLConEntCue FROM [TSCONCEPTOENTREGA] WHERE [ConEntCod] = @MVLConcEntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C30", "SELECT [CueCos] AS MVLECueCos FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLConEntCue ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C31", "SELECT [PrvDsc] AS MVLEPrvDsc FROM [CPPROVEEDORES] WHERE [PrvCod] = @MVLEPrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C32", "SELECT [CueDsc] AS MVLECueDsc, [CueCos] AS MVLECueCosCod FROM [CBPLANCUENTA] WHERE [CueCod] = @MVLECueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C32,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C33", "SELECT [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] ORDER BY [EntCod], [MVLEntCod], [MVLEITem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005C33,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C34", "SELECT [EntCod] FROM [TSENTREGAS] WHERE [EntCod] = @EntCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C34,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C35", "SELECT [COSCod] AS MVLECosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLECosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C35,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C36", "SELECT [COSCod] AS MVLEComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @MVLEComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C36,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C37", "SELECT [ForCod] AS MVLEForCod FROM [CFORMAPAGO] WHERE [ForCod] = @MVLEForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005C38", "SELECT [MonCod] AS MVLEMonCod FROM [CMONEDAS] WHERE [MonCod] = @MVLEMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005C38,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[15])[0] = rslt.getString(16, 15);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(21);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((int[]) buf[25])[0] = rslt.getInt(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 10);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getString(32, 1);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((string[]) buf[33])[0] = rslt.getString(34, 20);
              ((string[]) buf[34])[0] = rslt.getVarchar(35);
              ((int[]) buf[35])[0] = rslt.getInt(36);
              ((bool[]) buf[36])[0] = rslt.wasNull(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              ((int[]) buf[39])[0] = rslt.getInt(39);
              ((string[]) buf[40])[0] = rslt.getString(40, 10);
              ((bool[]) buf[41])[0] = rslt.wasNull(40);
              ((string[]) buf[42])[0] = rslt.getString(41, 10);
              ((bool[]) buf[43])[0] = rslt.wasNull(41);
              ((string[]) buf[44])[0] = rslt.getString(42, 20);
              ((string[]) buf[45])[0] = rslt.getString(43, 15);
              ((int[]) buf[46])[0] = rslt.getInt(44);
              ((bool[]) buf[47])[0] = rslt.wasNull(44);
              ((int[]) buf[48])[0] = rslt.getInt(45);
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
              ((string[]) buf[15])[0] = rslt.getString(16, 15);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(21);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((int[]) buf[25])[0] = rslt.getInt(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 10);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getString(32, 1);
              ((int[]) buf[32])[0] = rslt.getInt(33);
              ((string[]) buf[33])[0] = rslt.getString(34, 20);
              ((string[]) buf[34])[0] = rslt.getVarchar(35);
              ((int[]) buf[35])[0] = rslt.getInt(36);
              ((bool[]) buf[36])[0] = rslt.wasNull(36);
              ((string[]) buf[37])[0] = rslt.getVarchar(37);
              ((int[]) buf[38])[0] = rslt.getInt(38);
              ((int[]) buf[39])[0] = rslt.getInt(39);
              ((string[]) buf[40])[0] = rslt.getString(40, 10);
              ((bool[]) buf[41])[0] = rslt.wasNull(40);
              ((string[]) buf[42])[0] = rslt.getString(41, 10);
              ((bool[]) buf[43])[0] = rslt.wasNull(41);
              ((string[]) buf[44])[0] = rslt.getString(42, 20);
              ((string[]) buf[45])[0] = rslt.getString(43, 15);
              ((int[]) buf[46])[0] = rslt.getInt(44);
              ((bool[]) buf[47])[0] = rslt.wasNull(44);
              ((int[]) buf[48])[0] = rslt.getInt(45);
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
              ((string[]) buf[15])[0] = rslt.getString(16, 15);
              ((string[]) buf[16])[0] = rslt.getString(17, 20);
              ((decimal[]) buf[17])[0] = rslt.getDecimal(18);
              ((decimal[]) buf[18])[0] = rslt.getDecimal(19);
              ((decimal[]) buf[19])[0] = rslt.getDecimal(20);
              ((decimal[]) buf[20])[0] = rslt.getDecimal(21);
              ((decimal[]) buf[21])[0] = rslt.getDecimal(22);
              ((long[]) buf[22])[0] = rslt.getLong(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((int[]) buf[25])[0] = rslt.getInt(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 10);
              ((decimal[]) buf[27])[0] = rslt.getDecimal(28);
              ((decimal[]) buf[28])[0] = rslt.getDecimal(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 10);
              ((DateTime[]) buf[30])[0] = rslt.getGXDateTime(31);
              ((string[]) buf[31])[0] = rslt.getString(32, 1);
              ((short[]) buf[32])[0] = rslt.getShort(33);
              ((string[]) buf[33])[0] = rslt.getString(34, 100);
              ((string[]) buf[34])[0] = rslt.getString(35, 100);
              ((string[]) buf[35])[0] = rslt.getString(36, 100);
              ((short[]) buf[36])[0] = rslt.getShort(37);
              ((int[]) buf[37])[0] = rslt.getInt(38);
              ((string[]) buf[38])[0] = rslt.getString(39, 20);
              ((string[]) buf[39])[0] = rslt.getVarchar(40);
              ((int[]) buf[40])[0] = rslt.getInt(41);
              ((bool[]) buf[41])[0] = rslt.wasNull(41);
              ((string[]) buf[42])[0] = rslt.getVarchar(42);
              ((int[]) buf[43])[0] = rslt.getInt(43);
              ((int[]) buf[44])[0] = rslt.getInt(44);
              ((string[]) buf[45])[0] = rslt.getString(45, 10);
              ((bool[]) buf[46])[0] = rslt.wasNull(45);
              ((string[]) buf[47])[0] = rslt.getString(46, 10);
              ((bool[]) buf[48])[0] = rslt.wasNull(46);
              ((string[]) buf[49])[0] = rslt.getString(47, 20);
              ((string[]) buf[50])[0] = rslt.getString(48, 15);
              ((int[]) buf[51])[0] = rslt.getInt(49);
              ((bool[]) buf[52])[0] = rslt.wasNull(49);
              ((int[]) buf[53])[0] = rslt.getInt(50);
              ((string[]) buf[54])[0] = rslt.getString(51, 15);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 35 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 36 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
