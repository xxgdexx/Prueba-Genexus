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
   public class cbparamdet : GXDataArea
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
            A83ParTip = GetPar( "ParTip");
            AssignAttri("", false, "A83ParTip", A83ParTip);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A83ParTip) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A94ParCue1 = GetPar( "ParCue1");
            n94ParCue1 = false;
            AssignAttri("", false, "A94ParCue1", A94ParCue1);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A94ParCue1) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A95ParCue2 = GetPar( "ParCue2");
            n95ParCue2 = false;
            AssignAttri("", false, "A95ParCue2", A95ParCue2);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A95ParCue2) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A96ParCue3 = GetPar( "ParCue3");
            n96ParCue3 = false;
            AssignAttri("", false, "A96ParCue3", A96ParCue3);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A96ParCue3) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A97ParCue4 = GetPar( "ParCue4");
            n97ParCue4 = false;
            AssignAttri("", false, "A97ParCue4", A97ParCue4);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A97ParCue4) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A98ParCue5 = GetPar( "ParCue5");
            n98ParCue5 = false;
            AssignAttri("", false, "A98ParCue5", A98ParCue5);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A98ParCue5) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A99ParCue6 = GetPar( "ParCue6");
            n99ParCue6 = false;
            AssignAttri("", false, "A99ParCue6", A99ParCue6);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A99ParCue6) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A100ParCue7 = GetPar( "ParCue7");
            n100ParCue7 = false;
            AssignAttri("", false, "A100ParCue7", A100ParCue7);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A100ParCue7) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A101ParCue8 = GetPar( "ParCue8");
            n101ParCue8 = false;
            AssignAttri("", false, "A101ParCue8", A101ParCue8);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A101ParCue8) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A102ParCue9 = GetPar( "ParCue9");
            n102ParCue9 = false;
            AssignAttri("", false, "A102ParCue9", A102ParCue9);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A102ParCue9) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A103ParCue10 = GetPar( "ParCue10");
            n103ParCue10 = false;
            AssignAttri("", false, "A103ParCue10", A103ParCue10);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A103ParCue10) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A93ParMonCod = (int)(NumberUtil.Val( GetPar( "ParMonCod"), "."));
            AssignAttri("", false, "A93ParMonCod", StringUtil.LTrimStr( (decimal)(A93ParMonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A93ParMonCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A92ParTipCod = GetPar( "ParTipCod");
            AssignAttri("", false, "A92ParTipCod", A92ParTipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A92ParTipCod) ;
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
            Form.Meta.addItem("description", "Parametrización - Detalle", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cbparamdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbparamdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPARAMDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Asiento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParTip_Internalname, StringUtil.RTrim( A83ParTip), StringUtil.RTrim( context.localUtil.Format( A83ParTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Secuencia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84ParCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtParCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Cuenta 1", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue1_Internalname, StringUtil.RTrim( A94ParCue1), StringUtil.RTrim( context.localUtil.Format( A94ParCue1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Descripción 1", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc1_Internalname, StringUtil.RTrim( A1517ParCueDsc1), StringUtil.RTrim( context.localUtil.Format( A1517ParCueDsc1, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "D/H", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue1Tip_Internalname, StringUtil.RTrim( A1508ParCue1Tip), StringUtil.RTrim( context.localUtil.Format( A1508ParCue1Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue1Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue1Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Cuenta 2", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue2_Internalname, StringUtil.RTrim( A95ParCue2), StringUtil.RTrim( context.localUtil.Format( A95ParCue2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Descripción 2", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc2_Internalname, StringUtil.RTrim( A1519ParCueDsc2), StringUtil.RTrim( context.localUtil.Format( A1519ParCueDsc2, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "D/H", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue2Tip_Internalname, StringUtil.RTrim( A1509ParCue2Tip), StringUtil.RTrim( context.localUtil.Format( A1509ParCue2Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue2Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue2Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Cuenta 3", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue3_Internalname, StringUtil.RTrim( A96ParCue3), StringUtil.RTrim( context.localUtil.Format( A96ParCue3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue3_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Descripción 3", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc3_Internalname, StringUtil.RTrim( A1520ParCueDsc3), StringUtil.RTrim( context.localUtil.Format( A1520ParCueDsc3, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "D/H", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue3Tip_Internalname, StringUtil.RTrim( A1510ParCue3Tip), StringUtil.RTrim( context.localUtil.Format( A1510ParCue3Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue3Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue3Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Cuenta 4", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue4_Internalname, StringUtil.RTrim( A97ParCue4), StringUtil.RTrim( context.localUtil.Format( A97ParCue4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue4_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Descripción 4", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc4_Internalname, StringUtil.RTrim( A1521ParCueDsc4), StringUtil.RTrim( context.localUtil.Format( A1521ParCueDsc4, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc4_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "D/H", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue4Tip_Internalname, StringUtil.RTrim( A1511ParCue4Tip), StringUtil.RTrim( context.localUtil.Format( A1511ParCue4Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue4Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue4Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Cuenta 5", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue5_Internalname, StringUtil.RTrim( A98ParCue5), StringUtil.RTrim( context.localUtil.Format( A98ParCue5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue5_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Descripción 5", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc5_Internalname, StringUtil.RTrim( A1522ParCueDsc5), StringUtil.RTrim( context.localUtil.Format( A1522ParCueDsc5, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc5_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "D/H", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue5Tip_Internalname, StringUtil.RTrim( A1512ParCue5Tip), StringUtil.RTrim( context.localUtil.Format( A1512ParCue5Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue5Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue5Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Cuenta 6", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue6_Internalname, StringUtil.RTrim( A99ParCue6), StringUtil.RTrim( context.localUtil.Format( A99ParCue6, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue6_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Descripción 6", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc6_Internalname, StringUtil.RTrim( A1523ParCueDsc6), StringUtil.RTrim( context.localUtil.Format( A1523ParCueDsc6, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc6_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "D/H", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue6Tip_Internalname, StringUtil.RTrim( A1513ParCue6Tip), StringUtil.RTrim( context.localUtil.Format( A1513ParCue6Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue6Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue6Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Cuenta 7", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue7_Internalname, StringUtil.RTrim( A100ParCue7), StringUtil.RTrim( context.localUtil.Format( A100ParCue7, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue7_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue7_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Descripción 7", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc7_Internalname, StringUtil.RTrim( A1524ParCueDsc7), StringUtil.RTrim( context.localUtil.Format( A1524ParCueDsc7, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc7_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc7_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "D/H", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue7Tip_Internalname, StringUtil.RTrim( A1514ParCue7Tip), StringUtil.RTrim( context.localUtil.Format( A1514ParCue7Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue7Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue7Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Cuenta 8", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue8_Internalname, StringUtil.RTrim( A101ParCue8), StringUtil.RTrim( context.localUtil.Format( A101ParCue8, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue8_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue8_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Descripción 8", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc8_Internalname, StringUtil.RTrim( A1525ParCueDsc8), StringUtil.RTrim( context.localUtil.Format( A1525ParCueDsc8, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc8_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc8_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "D/H", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue8Tip_Internalname, StringUtil.RTrim( A1515ParCue8Tip), StringUtil.RTrim( context.localUtil.Format( A1515ParCue8Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue8Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue8Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Cuenta 9", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue9_Internalname, StringUtil.RTrim( A102ParCue9), StringUtil.RTrim( context.localUtil.Format( A102ParCue9, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue9_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue9_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Descripción 9", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc9_Internalname, StringUtil.RTrim( A1526ParCueDsc9), StringUtil.RTrim( context.localUtil.Format( A1526ParCueDsc9, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc9_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc9_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "D/H", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue9Tip_Internalname, StringUtil.RTrim( A1516ParCue9Tip), StringUtil.RTrim( context.localUtil.Format( A1516ParCue9Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue9Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue9Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Cuenta 10", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue10_Internalname, StringUtil.RTrim( A103ParCue10), StringUtil.RTrim( context.localUtil.Format( A103ParCue10, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue10_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue10_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Descripción 10", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParCueDsc10_Internalname, StringUtil.RTrim( A1518ParCueDsc10), StringUtil.RTrim( context.localUtil.Format( A1518ParCueDsc10, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCueDsc10_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCueDsc10_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "D/H", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCue10Tip_Internalname, StringUtil.RTrim( A1507ParCue10Tip), StringUtil.RTrim( context.localUtil.Format( A1507ParCue10Tip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCue10Tip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCue10Tip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Moneda", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A93ParMonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtParMonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A93ParMonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A93ParMonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParMonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParMonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Tipo Documento", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParTipCod_Internalname, StringUtil.RTrim( A92ParTipCod), StringUtil.RTrim( context.localUtil.Format( A92ParTipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Items", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParTitem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1542ParTitem), 4, 0, ".", "")), StringUtil.LTrim( ((edtParTitem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1542ParTitem), "ZZZ9") : context.localUtil.Format( (decimal)(A1542ParTitem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParTitem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParTitem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Forma de Pago", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1540ParForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtParForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1540ParForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1540ParForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 199,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 200,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 202,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 203,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBPARAMDET.htm");
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
            Z83ParTip = cgiGet( "Z83ParTip");
            Z84ParCod = (int)(context.localUtil.CToN( cgiGet( "Z84ParCod"), ".", ","));
            Z1508ParCue1Tip = cgiGet( "Z1508ParCue1Tip");
            Z1509ParCue2Tip = cgiGet( "Z1509ParCue2Tip");
            Z1510ParCue3Tip = cgiGet( "Z1510ParCue3Tip");
            Z1511ParCue4Tip = cgiGet( "Z1511ParCue4Tip");
            Z1512ParCue5Tip = cgiGet( "Z1512ParCue5Tip");
            Z1513ParCue6Tip = cgiGet( "Z1513ParCue6Tip");
            Z1514ParCue7Tip = cgiGet( "Z1514ParCue7Tip");
            Z1515ParCue8Tip = cgiGet( "Z1515ParCue8Tip");
            Z1516ParCue9Tip = cgiGet( "Z1516ParCue9Tip");
            Z1507ParCue10Tip = cgiGet( "Z1507ParCue10Tip");
            Z1542ParTitem = (short)(context.localUtil.CToN( cgiGet( "Z1542ParTitem"), ".", ","));
            Z1540ParForCod = (int)(context.localUtil.CToN( cgiGet( "Z1540ParForCod"), ".", ","));
            Z94ParCue1 = cgiGet( "Z94ParCue1");
            n94ParCue1 = (String.IsNullOrEmpty(StringUtil.RTrim( A94ParCue1)) ? true : false);
            Z95ParCue2 = cgiGet( "Z95ParCue2");
            n95ParCue2 = (String.IsNullOrEmpty(StringUtil.RTrim( A95ParCue2)) ? true : false);
            Z96ParCue3 = cgiGet( "Z96ParCue3");
            n96ParCue3 = (String.IsNullOrEmpty(StringUtil.RTrim( A96ParCue3)) ? true : false);
            Z97ParCue4 = cgiGet( "Z97ParCue4");
            n97ParCue4 = (String.IsNullOrEmpty(StringUtil.RTrim( A97ParCue4)) ? true : false);
            Z98ParCue5 = cgiGet( "Z98ParCue5");
            n98ParCue5 = (String.IsNullOrEmpty(StringUtil.RTrim( A98ParCue5)) ? true : false);
            Z99ParCue6 = cgiGet( "Z99ParCue6");
            n99ParCue6 = (String.IsNullOrEmpty(StringUtil.RTrim( A99ParCue6)) ? true : false);
            Z100ParCue7 = cgiGet( "Z100ParCue7");
            n100ParCue7 = (String.IsNullOrEmpty(StringUtil.RTrim( A100ParCue7)) ? true : false);
            Z101ParCue8 = cgiGet( "Z101ParCue8");
            n101ParCue8 = (String.IsNullOrEmpty(StringUtil.RTrim( A101ParCue8)) ? true : false);
            Z102ParCue9 = cgiGet( "Z102ParCue9");
            n102ParCue9 = (String.IsNullOrEmpty(StringUtil.RTrim( A102ParCue9)) ? true : false);
            Z103ParCue10 = cgiGet( "Z103ParCue10");
            n103ParCue10 = (String.IsNullOrEmpty(StringUtil.RTrim( A103ParCue10)) ? true : false);
            Z93ParMonCod = (int)(context.localUtil.CToN( cgiGet( "Z93ParMonCod"), ".", ","));
            Z92ParTipCod = cgiGet( "Z92ParTipCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A83ParTip = cgiGet( edtParTip_Internalname);
            AssignAttri("", false, "A83ParTip", A83ParTip);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARCOD");
               AnyError = 1;
               GX_FocusControl = edtParCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A84ParCod = 0;
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            }
            else
            {
               A84ParCod = (int)(context.localUtil.CToN( cgiGet( edtParCod_Internalname), ".", ","));
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            }
            A94ParCue1 = cgiGet( edtParCue1_Internalname);
            n94ParCue1 = false;
            AssignAttri("", false, "A94ParCue1", A94ParCue1);
            n94ParCue1 = (String.IsNullOrEmpty(StringUtil.RTrim( A94ParCue1)) ? true : false);
            A1517ParCueDsc1 = cgiGet( edtParCueDsc1_Internalname);
            AssignAttri("", false, "A1517ParCueDsc1", A1517ParCueDsc1);
            A1508ParCue1Tip = cgiGet( edtParCue1Tip_Internalname);
            AssignAttri("", false, "A1508ParCue1Tip", A1508ParCue1Tip);
            A95ParCue2 = cgiGet( edtParCue2_Internalname);
            n95ParCue2 = false;
            AssignAttri("", false, "A95ParCue2", A95ParCue2);
            n95ParCue2 = (String.IsNullOrEmpty(StringUtil.RTrim( A95ParCue2)) ? true : false);
            A1519ParCueDsc2 = cgiGet( edtParCueDsc2_Internalname);
            AssignAttri("", false, "A1519ParCueDsc2", A1519ParCueDsc2);
            A1509ParCue2Tip = cgiGet( edtParCue2Tip_Internalname);
            AssignAttri("", false, "A1509ParCue2Tip", A1509ParCue2Tip);
            A96ParCue3 = cgiGet( edtParCue3_Internalname);
            n96ParCue3 = false;
            AssignAttri("", false, "A96ParCue3", A96ParCue3);
            n96ParCue3 = (String.IsNullOrEmpty(StringUtil.RTrim( A96ParCue3)) ? true : false);
            A1520ParCueDsc3 = cgiGet( edtParCueDsc3_Internalname);
            AssignAttri("", false, "A1520ParCueDsc3", A1520ParCueDsc3);
            A1510ParCue3Tip = cgiGet( edtParCue3Tip_Internalname);
            AssignAttri("", false, "A1510ParCue3Tip", A1510ParCue3Tip);
            A97ParCue4 = cgiGet( edtParCue4_Internalname);
            n97ParCue4 = false;
            AssignAttri("", false, "A97ParCue4", A97ParCue4);
            n97ParCue4 = (String.IsNullOrEmpty(StringUtil.RTrim( A97ParCue4)) ? true : false);
            A1521ParCueDsc4 = cgiGet( edtParCueDsc4_Internalname);
            AssignAttri("", false, "A1521ParCueDsc4", A1521ParCueDsc4);
            A1511ParCue4Tip = cgiGet( edtParCue4Tip_Internalname);
            AssignAttri("", false, "A1511ParCue4Tip", A1511ParCue4Tip);
            A98ParCue5 = cgiGet( edtParCue5_Internalname);
            n98ParCue5 = false;
            AssignAttri("", false, "A98ParCue5", A98ParCue5);
            n98ParCue5 = (String.IsNullOrEmpty(StringUtil.RTrim( A98ParCue5)) ? true : false);
            A1522ParCueDsc5 = cgiGet( edtParCueDsc5_Internalname);
            AssignAttri("", false, "A1522ParCueDsc5", A1522ParCueDsc5);
            A1512ParCue5Tip = cgiGet( edtParCue5Tip_Internalname);
            AssignAttri("", false, "A1512ParCue5Tip", A1512ParCue5Tip);
            A99ParCue6 = cgiGet( edtParCue6_Internalname);
            n99ParCue6 = false;
            AssignAttri("", false, "A99ParCue6", A99ParCue6);
            n99ParCue6 = (String.IsNullOrEmpty(StringUtil.RTrim( A99ParCue6)) ? true : false);
            A1523ParCueDsc6 = cgiGet( edtParCueDsc6_Internalname);
            AssignAttri("", false, "A1523ParCueDsc6", A1523ParCueDsc6);
            A1513ParCue6Tip = cgiGet( edtParCue6Tip_Internalname);
            AssignAttri("", false, "A1513ParCue6Tip", A1513ParCue6Tip);
            A100ParCue7 = cgiGet( edtParCue7_Internalname);
            n100ParCue7 = false;
            AssignAttri("", false, "A100ParCue7", A100ParCue7);
            n100ParCue7 = (String.IsNullOrEmpty(StringUtil.RTrim( A100ParCue7)) ? true : false);
            A1524ParCueDsc7 = cgiGet( edtParCueDsc7_Internalname);
            AssignAttri("", false, "A1524ParCueDsc7", A1524ParCueDsc7);
            A1514ParCue7Tip = cgiGet( edtParCue7Tip_Internalname);
            AssignAttri("", false, "A1514ParCue7Tip", A1514ParCue7Tip);
            A101ParCue8 = cgiGet( edtParCue8_Internalname);
            n101ParCue8 = false;
            AssignAttri("", false, "A101ParCue8", A101ParCue8);
            n101ParCue8 = (String.IsNullOrEmpty(StringUtil.RTrim( A101ParCue8)) ? true : false);
            A1525ParCueDsc8 = cgiGet( edtParCueDsc8_Internalname);
            AssignAttri("", false, "A1525ParCueDsc8", A1525ParCueDsc8);
            A1515ParCue8Tip = cgiGet( edtParCue8Tip_Internalname);
            AssignAttri("", false, "A1515ParCue8Tip", A1515ParCue8Tip);
            A102ParCue9 = cgiGet( edtParCue9_Internalname);
            n102ParCue9 = false;
            AssignAttri("", false, "A102ParCue9", A102ParCue9);
            n102ParCue9 = (String.IsNullOrEmpty(StringUtil.RTrim( A102ParCue9)) ? true : false);
            A1526ParCueDsc9 = cgiGet( edtParCueDsc9_Internalname);
            AssignAttri("", false, "A1526ParCueDsc9", A1526ParCueDsc9);
            A1516ParCue9Tip = cgiGet( edtParCue9Tip_Internalname);
            AssignAttri("", false, "A1516ParCue9Tip", A1516ParCue9Tip);
            A103ParCue10 = cgiGet( edtParCue10_Internalname);
            n103ParCue10 = false;
            AssignAttri("", false, "A103ParCue10", A103ParCue10);
            n103ParCue10 = (String.IsNullOrEmpty(StringUtil.RTrim( A103ParCue10)) ? true : false);
            A1518ParCueDsc10 = cgiGet( edtParCueDsc10_Internalname);
            AssignAttri("", false, "A1518ParCueDsc10", A1518ParCueDsc10);
            A1507ParCue10Tip = cgiGet( edtParCue10Tip_Internalname);
            AssignAttri("", false, "A1507ParCue10Tip", A1507ParCue10Tip);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARMONCOD");
               AnyError = 1;
               GX_FocusControl = edtParMonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A93ParMonCod = 0;
               AssignAttri("", false, "A93ParMonCod", StringUtil.LTrimStr( (decimal)(A93ParMonCod), 6, 0));
            }
            else
            {
               A93ParMonCod = (int)(context.localUtil.CToN( cgiGet( edtParMonCod_Internalname), ".", ","));
               AssignAttri("", false, "A93ParMonCod", StringUtil.LTrimStr( (decimal)(A93ParMonCod), 6, 0));
            }
            A92ParTipCod = cgiGet( edtParTipCod_Internalname);
            AssignAttri("", false, "A92ParTipCod", A92ParTipCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParTitem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParTitem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARTITEM");
               AnyError = 1;
               GX_FocusControl = edtParTitem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1542ParTitem = 0;
               AssignAttri("", false, "A1542ParTitem", StringUtil.LTrimStr( (decimal)(A1542ParTitem), 4, 0));
            }
            else
            {
               A1542ParTitem = (short)(context.localUtil.CToN( cgiGet( edtParTitem_Internalname), ".", ","));
               AssignAttri("", false, "A1542ParTitem", StringUtil.LTrimStr( (decimal)(A1542ParTitem), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtParForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARFORCOD");
               AnyError = 1;
               GX_FocusControl = edtParForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1540ParForCod = 0;
               AssignAttri("", false, "A1540ParForCod", StringUtil.LTrimStr( (decimal)(A1540ParForCod), 6, 0));
            }
            else
            {
               A1540ParForCod = (int)(context.localUtil.CToN( cgiGet( edtParForCod_Internalname), ".", ","));
               AssignAttri("", false, "A1540ParForCod", StringUtil.LTrimStr( (decimal)(A1540ParForCod), 6, 0));
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
               A83ParTip = GetPar( "ParTip");
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = (int)(NumberUtil.Val( GetPar( "ParCod"), "."));
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
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
               InitAll1T62( ) ;
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
         DisableAttributes1T62( ) ;
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

      protected void CONFIRM_1T0( )
      {
         BeforeValidate1T62( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1T62( ) ;
            }
            else
            {
               CheckExtendedTable1T62( ) ;
               if ( AnyError == 0 )
               {
                  ZM1T62( 2) ;
                  ZM1T62( 3) ;
                  ZM1T62( 4) ;
                  ZM1T62( 5) ;
                  ZM1T62( 6) ;
                  ZM1T62( 7) ;
                  ZM1T62( 8) ;
                  ZM1T62( 9) ;
                  ZM1T62( 10) ;
                  ZM1T62( 11) ;
                  ZM1T62( 12) ;
                  ZM1T62( 13) ;
                  ZM1T62( 14) ;
               }
               CloseExtendedTableCursors1T62( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1T0( ) ;
         }
      }

      protected void ResetCaption1T0( )
      {
      }

      protected void ZM1T62( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1508ParCue1Tip = T001T3_A1508ParCue1Tip[0];
               Z1509ParCue2Tip = T001T3_A1509ParCue2Tip[0];
               Z1510ParCue3Tip = T001T3_A1510ParCue3Tip[0];
               Z1511ParCue4Tip = T001T3_A1511ParCue4Tip[0];
               Z1512ParCue5Tip = T001T3_A1512ParCue5Tip[0];
               Z1513ParCue6Tip = T001T3_A1513ParCue6Tip[0];
               Z1514ParCue7Tip = T001T3_A1514ParCue7Tip[0];
               Z1515ParCue8Tip = T001T3_A1515ParCue8Tip[0];
               Z1516ParCue9Tip = T001T3_A1516ParCue9Tip[0];
               Z1507ParCue10Tip = T001T3_A1507ParCue10Tip[0];
               Z1542ParTitem = T001T3_A1542ParTitem[0];
               Z1540ParForCod = T001T3_A1540ParForCod[0];
               Z94ParCue1 = T001T3_A94ParCue1[0];
               Z95ParCue2 = T001T3_A95ParCue2[0];
               Z96ParCue3 = T001T3_A96ParCue3[0];
               Z97ParCue4 = T001T3_A97ParCue4[0];
               Z98ParCue5 = T001T3_A98ParCue5[0];
               Z99ParCue6 = T001T3_A99ParCue6[0];
               Z100ParCue7 = T001T3_A100ParCue7[0];
               Z101ParCue8 = T001T3_A101ParCue8[0];
               Z102ParCue9 = T001T3_A102ParCue9[0];
               Z103ParCue10 = T001T3_A103ParCue10[0];
               Z93ParMonCod = T001T3_A93ParMonCod[0];
               Z92ParTipCod = T001T3_A92ParTipCod[0];
            }
            else
            {
               Z1508ParCue1Tip = A1508ParCue1Tip;
               Z1509ParCue2Tip = A1509ParCue2Tip;
               Z1510ParCue3Tip = A1510ParCue3Tip;
               Z1511ParCue4Tip = A1511ParCue4Tip;
               Z1512ParCue5Tip = A1512ParCue5Tip;
               Z1513ParCue6Tip = A1513ParCue6Tip;
               Z1514ParCue7Tip = A1514ParCue7Tip;
               Z1515ParCue8Tip = A1515ParCue8Tip;
               Z1516ParCue9Tip = A1516ParCue9Tip;
               Z1507ParCue10Tip = A1507ParCue10Tip;
               Z1542ParTitem = A1542ParTitem;
               Z1540ParForCod = A1540ParForCod;
               Z94ParCue1 = A94ParCue1;
               Z95ParCue2 = A95ParCue2;
               Z96ParCue3 = A96ParCue3;
               Z97ParCue4 = A97ParCue4;
               Z98ParCue5 = A98ParCue5;
               Z99ParCue6 = A99ParCue6;
               Z100ParCue7 = A100ParCue7;
               Z101ParCue8 = A101ParCue8;
               Z102ParCue9 = A102ParCue9;
               Z103ParCue10 = A103ParCue10;
               Z93ParMonCod = A93ParMonCod;
               Z92ParTipCod = A92ParTipCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z84ParCod = A84ParCod;
            Z1508ParCue1Tip = A1508ParCue1Tip;
            Z1509ParCue2Tip = A1509ParCue2Tip;
            Z1510ParCue3Tip = A1510ParCue3Tip;
            Z1511ParCue4Tip = A1511ParCue4Tip;
            Z1512ParCue5Tip = A1512ParCue5Tip;
            Z1513ParCue6Tip = A1513ParCue6Tip;
            Z1514ParCue7Tip = A1514ParCue7Tip;
            Z1515ParCue8Tip = A1515ParCue8Tip;
            Z1516ParCue9Tip = A1516ParCue9Tip;
            Z1507ParCue10Tip = A1507ParCue10Tip;
            Z1542ParTitem = A1542ParTitem;
            Z1540ParForCod = A1540ParForCod;
            Z83ParTip = A83ParTip;
            Z94ParCue1 = A94ParCue1;
            Z95ParCue2 = A95ParCue2;
            Z96ParCue3 = A96ParCue3;
            Z97ParCue4 = A97ParCue4;
            Z98ParCue5 = A98ParCue5;
            Z99ParCue6 = A99ParCue6;
            Z100ParCue7 = A100ParCue7;
            Z101ParCue8 = A101ParCue8;
            Z102ParCue9 = A102ParCue9;
            Z103ParCue10 = A103ParCue10;
            Z93ParMonCod = A93ParMonCod;
            Z92ParTipCod = A92ParTipCod;
            Z1517ParCueDsc1 = A1517ParCueDsc1;
            Z1519ParCueDsc2 = A1519ParCueDsc2;
            Z1520ParCueDsc3 = A1520ParCueDsc3;
            Z1521ParCueDsc4 = A1521ParCueDsc4;
            Z1522ParCueDsc5 = A1522ParCueDsc5;
            Z1523ParCueDsc6 = A1523ParCueDsc6;
            Z1524ParCueDsc7 = A1524ParCueDsc7;
            Z1525ParCueDsc8 = A1525ParCueDsc8;
            Z1526ParCueDsc9 = A1526ParCueDsc9;
            Z1518ParCueDsc10 = A1518ParCueDsc10;
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

      protected void Load1T62( )
      {
         /* Using cursor T001T17 */
         pr_default.execute(15, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound62 = 1;
            A1517ParCueDsc1 = T001T17_A1517ParCueDsc1[0];
            AssignAttri("", false, "A1517ParCueDsc1", A1517ParCueDsc1);
            A1508ParCue1Tip = T001T17_A1508ParCue1Tip[0];
            AssignAttri("", false, "A1508ParCue1Tip", A1508ParCue1Tip);
            A1519ParCueDsc2 = T001T17_A1519ParCueDsc2[0];
            AssignAttri("", false, "A1519ParCueDsc2", A1519ParCueDsc2);
            A1509ParCue2Tip = T001T17_A1509ParCue2Tip[0];
            AssignAttri("", false, "A1509ParCue2Tip", A1509ParCue2Tip);
            A1520ParCueDsc3 = T001T17_A1520ParCueDsc3[0];
            AssignAttri("", false, "A1520ParCueDsc3", A1520ParCueDsc3);
            A1510ParCue3Tip = T001T17_A1510ParCue3Tip[0];
            AssignAttri("", false, "A1510ParCue3Tip", A1510ParCue3Tip);
            A1521ParCueDsc4 = T001T17_A1521ParCueDsc4[0];
            AssignAttri("", false, "A1521ParCueDsc4", A1521ParCueDsc4);
            A1511ParCue4Tip = T001T17_A1511ParCue4Tip[0];
            AssignAttri("", false, "A1511ParCue4Tip", A1511ParCue4Tip);
            A1522ParCueDsc5 = T001T17_A1522ParCueDsc5[0];
            AssignAttri("", false, "A1522ParCueDsc5", A1522ParCueDsc5);
            A1512ParCue5Tip = T001T17_A1512ParCue5Tip[0];
            AssignAttri("", false, "A1512ParCue5Tip", A1512ParCue5Tip);
            A1523ParCueDsc6 = T001T17_A1523ParCueDsc6[0];
            AssignAttri("", false, "A1523ParCueDsc6", A1523ParCueDsc6);
            A1513ParCue6Tip = T001T17_A1513ParCue6Tip[0];
            AssignAttri("", false, "A1513ParCue6Tip", A1513ParCue6Tip);
            A1524ParCueDsc7 = T001T17_A1524ParCueDsc7[0];
            AssignAttri("", false, "A1524ParCueDsc7", A1524ParCueDsc7);
            A1514ParCue7Tip = T001T17_A1514ParCue7Tip[0];
            AssignAttri("", false, "A1514ParCue7Tip", A1514ParCue7Tip);
            A1525ParCueDsc8 = T001T17_A1525ParCueDsc8[0];
            AssignAttri("", false, "A1525ParCueDsc8", A1525ParCueDsc8);
            A1515ParCue8Tip = T001T17_A1515ParCue8Tip[0];
            AssignAttri("", false, "A1515ParCue8Tip", A1515ParCue8Tip);
            A1526ParCueDsc9 = T001T17_A1526ParCueDsc9[0];
            AssignAttri("", false, "A1526ParCueDsc9", A1526ParCueDsc9);
            A1516ParCue9Tip = T001T17_A1516ParCue9Tip[0];
            AssignAttri("", false, "A1516ParCue9Tip", A1516ParCue9Tip);
            A1518ParCueDsc10 = T001T17_A1518ParCueDsc10[0];
            AssignAttri("", false, "A1518ParCueDsc10", A1518ParCueDsc10);
            A1507ParCue10Tip = T001T17_A1507ParCue10Tip[0];
            AssignAttri("", false, "A1507ParCue10Tip", A1507ParCue10Tip);
            A1542ParTitem = T001T17_A1542ParTitem[0];
            AssignAttri("", false, "A1542ParTitem", StringUtil.LTrimStr( (decimal)(A1542ParTitem), 4, 0));
            A1540ParForCod = T001T17_A1540ParForCod[0];
            AssignAttri("", false, "A1540ParForCod", StringUtil.LTrimStr( (decimal)(A1540ParForCod), 6, 0));
            A94ParCue1 = T001T17_A94ParCue1[0];
            n94ParCue1 = T001T17_n94ParCue1[0];
            AssignAttri("", false, "A94ParCue1", A94ParCue1);
            A95ParCue2 = T001T17_A95ParCue2[0];
            n95ParCue2 = T001T17_n95ParCue2[0];
            AssignAttri("", false, "A95ParCue2", A95ParCue2);
            A96ParCue3 = T001T17_A96ParCue3[0];
            n96ParCue3 = T001T17_n96ParCue3[0];
            AssignAttri("", false, "A96ParCue3", A96ParCue3);
            A97ParCue4 = T001T17_A97ParCue4[0];
            n97ParCue4 = T001T17_n97ParCue4[0];
            AssignAttri("", false, "A97ParCue4", A97ParCue4);
            A98ParCue5 = T001T17_A98ParCue5[0];
            n98ParCue5 = T001T17_n98ParCue5[0];
            AssignAttri("", false, "A98ParCue5", A98ParCue5);
            A99ParCue6 = T001T17_A99ParCue6[0];
            n99ParCue6 = T001T17_n99ParCue6[0];
            AssignAttri("", false, "A99ParCue6", A99ParCue6);
            A100ParCue7 = T001T17_A100ParCue7[0];
            n100ParCue7 = T001T17_n100ParCue7[0];
            AssignAttri("", false, "A100ParCue7", A100ParCue7);
            A101ParCue8 = T001T17_A101ParCue8[0];
            n101ParCue8 = T001T17_n101ParCue8[0];
            AssignAttri("", false, "A101ParCue8", A101ParCue8);
            A102ParCue9 = T001T17_A102ParCue9[0];
            n102ParCue9 = T001T17_n102ParCue9[0];
            AssignAttri("", false, "A102ParCue9", A102ParCue9);
            A103ParCue10 = T001T17_A103ParCue10[0];
            n103ParCue10 = T001T17_n103ParCue10[0];
            AssignAttri("", false, "A103ParCue10", A103ParCue10);
            A93ParMonCod = T001T17_A93ParMonCod[0];
            AssignAttri("", false, "A93ParMonCod", StringUtil.LTrimStr( (decimal)(A93ParMonCod), 6, 0));
            A92ParTipCod = T001T17_A92ParTipCod[0];
            AssignAttri("", false, "A92ParTipCod", A92ParTipCod);
            ZM1T62( -1) ;
         }
         pr_default.close(15);
         OnLoadActions1T62( ) ;
      }

      protected void OnLoadActions1T62( )
      {
      }

      protected void CheckExtendedTable1T62( )
      {
         nIsDirty_62 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001T4 */
         pr_default.execute(2, new Object[] {A83ParTip});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Parametrización Cabecera'.", "ForeignKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001T5 */
         pr_default.execute(3, new Object[] {n94ParCue1, A94ParCue1});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A94ParCue1)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE1");
               AnyError = 1;
               GX_FocusControl = edtParCue1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1517ParCueDsc1 = T001T5_A1517ParCueDsc1[0];
         AssignAttri("", false, "A1517ParCueDsc1", A1517ParCueDsc1);
         pr_default.close(3);
         /* Using cursor T001T6 */
         pr_default.execute(4, new Object[] {n95ParCue2, A95ParCue2});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A95ParCue2)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE2");
               AnyError = 1;
               GX_FocusControl = edtParCue2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1519ParCueDsc2 = T001T6_A1519ParCueDsc2[0];
         AssignAttri("", false, "A1519ParCueDsc2", A1519ParCueDsc2);
         pr_default.close(4);
         /* Using cursor T001T7 */
         pr_default.execute(5, new Object[] {n96ParCue3, A96ParCue3});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A96ParCue3)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE3");
               AnyError = 1;
               GX_FocusControl = edtParCue3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1520ParCueDsc3 = T001T7_A1520ParCueDsc3[0];
         AssignAttri("", false, "A1520ParCueDsc3", A1520ParCueDsc3);
         pr_default.close(5);
         /* Using cursor T001T8 */
         pr_default.execute(6, new Object[] {n97ParCue4, A97ParCue4});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A97ParCue4)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE4");
               AnyError = 1;
               GX_FocusControl = edtParCue4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1521ParCueDsc4 = T001T8_A1521ParCueDsc4[0];
         AssignAttri("", false, "A1521ParCueDsc4", A1521ParCueDsc4);
         pr_default.close(6);
         /* Using cursor T001T9 */
         pr_default.execute(7, new Object[] {n98ParCue5, A98ParCue5});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A98ParCue5)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE5");
               AnyError = 1;
               GX_FocusControl = edtParCue5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1522ParCueDsc5 = T001T9_A1522ParCueDsc5[0];
         AssignAttri("", false, "A1522ParCueDsc5", A1522ParCueDsc5);
         pr_default.close(7);
         /* Using cursor T001T10 */
         pr_default.execute(8, new Object[] {n99ParCue6, A99ParCue6});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A99ParCue6)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE6");
               AnyError = 1;
               GX_FocusControl = edtParCue6_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1523ParCueDsc6 = T001T10_A1523ParCueDsc6[0];
         AssignAttri("", false, "A1523ParCueDsc6", A1523ParCueDsc6);
         pr_default.close(8);
         /* Using cursor T001T11 */
         pr_default.execute(9, new Object[] {n100ParCue7, A100ParCue7});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A100ParCue7)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE7");
               AnyError = 1;
               GX_FocusControl = edtParCue7_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1524ParCueDsc7 = T001T11_A1524ParCueDsc7[0];
         AssignAttri("", false, "A1524ParCueDsc7", A1524ParCueDsc7);
         pr_default.close(9);
         /* Using cursor T001T12 */
         pr_default.execute(10, new Object[] {n101ParCue8, A101ParCue8});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A101ParCue8)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE8");
               AnyError = 1;
               GX_FocusControl = edtParCue8_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1525ParCueDsc8 = T001T12_A1525ParCueDsc8[0];
         AssignAttri("", false, "A1525ParCueDsc8", A1525ParCueDsc8);
         pr_default.close(10);
         /* Using cursor T001T13 */
         pr_default.execute(11, new Object[] {n102ParCue9, A102ParCue9});
         if ( (pr_default.getStatus(11) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A102ParCue9)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE9");
               AnyError = 1;
               GX_FocusControl = edtParCue9_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1526ParCueDsc9 = T001T13_A1526ParCueDsc9[0];
         AssignAttri("", false, "A1526ParCueDsc9", A1526ParCueDsc9);
         pr_default.close(11);
         /* Using cursor T001T14 */
         pr_default.execute(12, new Object[] {n103ParCue10, A103ParCue10});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A103ParCue10)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE10");
               AnyError = 1;
               GX_FocusControl = edtParCue10_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1518ParCueDsc10 = T001T14_A1518ParCueDsc10[0];
         AssignAttri("", false, "A1518ParCueDsc10", A1518ParCueDsc10);
         pr_default.close(12);
         /* Using cursor T001T15 */
         pr_default.execute(13, new Object[] {A93ParMonCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "PARMONCOD");
            AnyError = 1;
            GX_FocusControl = edtParMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(13);
         /* Using cursor T001T16 */
         pr_default.execute(14, new Object[] {A92ParTipCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documento'.", "ForeignKeyNotFound", 1, "PARTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtParTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
      }

      protected void CloseExtendedTableCursors1T62( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
         pr_default.close(11);
         pr_default.close(12);
         pr_default.close(13);
         pr_default.close(14);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A83ParTip )
      {
         /* Using cursor T001T18 */
         pr_default.execute(16, new Object[] {A83ParTip});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("No existe 'Parametrización Cabecera'.", "ForeignKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_3( string A94ParCue1 )
      {
         /* Using cursor T001T19 */
         pr_default.execute(17, new Object[] {n94ParCue1, A94ParCue1});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A94ParCue1)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE1");
               AnyError = 1;
               GX_FocusControl = edtParCue1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1517ParCueDsc1 = T001T19_A1517ParCueDsc1[0];
         AssignAttri("", false, "A1517ParCueDsc1", A1517ParCueDsc1);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1517ParCueDsc1))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_4( string A95ParCue2 )
      {
         /* Using cursor T001T20 */
         pr_default.execute(18, new Object[] {n95ParCue2, A95ParCue2});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A95ParCue2)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE2");
               AnyError = 1;
               GX_FocusControl = edtParCue2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1519ParCueDsc2 = T001T20_A1519ParCueDsc2[0];
         AssignAttri("", false, "A1519ParCueDsc2", A1519ParCueDsc2);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1519ParCueDsc2))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void gxLoad_5( string A96ParCue3 )
      {
         /* Using cursor T001T21 */
         pr_default.execute(19, new Object[] {n96ParCue3, A96ParCue3});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A96ParCue3)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE3");
               AnyError = 1;
               GX_FocusControl = edtParCue3_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1520ParCueDsc3 = T001T21_A1520ParCueDsc3[0];
         AssignAttri("", false, "A1520ParCueDsc3", A1520ParCueDsc3);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1520ParCueDsc3))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(19) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(19);
      }

      protected void gxLoad_6( string A97ParCue4 )
      {
         /* Using cursor T001T22 */
         pr_default.execute(20, new Object[] {n97ParCue4, A97ParCue4});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A97ParCue4)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE4");
               AnyError = 1;
               GX_FocusControl = edtParCue4_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1521ParCueDsc4 = T001T22_A1521ParCueDsc4[0];
         AssignAttri("", false, "A1521ParCueDsc4", A1521ParCueDsc4);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1521ParCueDsc4))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(20) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(20);
      }

      protected void gxLoad_7( string A98ParCue5 )
      {
         /* Using cursor T001T23 */
         pr_default.execute(21, new Object[] {n98ParCue5, A98ParCue5});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A98ParCue5)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE5");
               AnyError = 1;
               GX_FocusControl = edtParCue5_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1522ParCueDsc5 = T001T23_A1522ParCueDsc5[0];
         AssignAttri("", false, "A1522ParCueDsc5", A1522ParCueDsc5);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1522ParCueDsc5))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(21) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(21);
      }

      protected void gxLoad_8( string A99ParCue6 )
      {
         /* Using cursor T001T24 */
         pr_default.execute(22, new Object[] {n99ParCue6, A99ParCue6});
         if ( (pr_default.getStatus(22) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A99ParCue6)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE6");
               AnyError = 1;
               GX_FocusControl = edtParCue6_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1523ParCueDsc6 = T001T24_A1523ParCueDsc6[0];
         AssignAttri("", false, "A1523ParCueDsc6", A1523ParCueDsc6);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1523ParCueDsc6))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(22) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(22);
      }

      protected void gxLoad_9( string A100ParCue7 )
      {
         /* Using cursor T001T25 */
         pr_default.execute(23, new Object[] {n100ParCue7, A100ParCue7});
         if ( (pr_default.getStatus(23) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A100ParCue7)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE7");
               AnyError = 1;
               GX_FocusControl = edtParCue7_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1524ParCueDsc7 = T001T25_A1524ParCueDsc7[0];
         AssignAttri("", false, "A1524ParCueDsc7", A1524ParCueDsc7);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1524ParCueDsc7))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(23) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(23);
      }

      protected void gxLoad_10( string A101ParCue8 )
      {
         /* Using cursor T001T26 */
         pr_default.execute(24, new Object[] {n101ParCue8, A101ParCue8});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A101ParCue8)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE8");
               AnyError = 1;
               GX_FocusControl = edtParCue8_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1525ParCueDsc8 = T001T26_A1525ParCueDsc8[0];
         AssignAttri("", false, "A1525ParCueDsc8", A1525ParCueDsc8);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1525ParCueDsc8))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_11( string A102ParCue9 )
      {
         /* Using cursor T001T27 */
         pr_default.execute(25, new Object[] {n102ParCue9, A102ParCue9});
         if ( (pr_default.getStatus(25) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A102ParCue9)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE9");
               AnyError = 1;
               GX_FocusControl = edtParCue9_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1526ParCueDsc9 = T001T27_A1526ParCueDsc9[0];
         AssignAttri("", false, "A1526ParCueDsc9", A1526ParCueDsc9);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1526ParCueDsc9))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void gxLoad_12( string A103ParCue10 )
      {
         /* Using cursor T001T28 */
         pr_default.execute(26, new Object[] {n103ParCue10, A103ParCue10});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A103ParCue10)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE10");
               AnyError = 1;
               GX_FocusControl = edtParCue10_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1518ParCueDsc10 = T001T28_A1518ParCueDsc10[0];
         AssignAttri("", false, "A1518ParCueDsc10", A1518ParCueDsc10);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1518ParCueDsc10))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(26) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(26);
      }

      protected void gxLoad_13( int A93ParMonCod )
      {
         /* Using cursor T001T29 */
         pr_default.execute(27, new Object[] {A93ParMonCod});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "PARMONCOD");
            AnyError = 1;
            GX_FocusControl = edtParMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(27) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(27);
      }

      protected void gxLoad_14( string A92ParTipCod )
      {
         /* Using cursor T001T30 */
         pr_default.execute(28, new Object[] {A92ParTipCod});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documento'.", "ForeignKeyNotFound", 1, "PARTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtParTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(28) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(28);
      }

      protected void GetKey1T62( )
      {
         /* Using cursor T001T31 */
         pr_default.execute(29, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(29) != 101) )
         {
            RcdFound62 = 1;
         }
         else
         {
            RcdFound62 = 0;
         }
         pr_default.close(29);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001T3 */
         pr_default.execute(1, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1T62( 1) ;
            RcdFound62 = 1;
            A84ParCod = T001T3_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A1508ParCue1Tip = T001T3_A1508ParCue1Tip[0];
            AssignAttri("", false, "A1508ParCue1Tip", A1508ParCue1Tip);
            A1509ParCue2Tip = T001T3_A1509ParCue2Tip[0];
            AssignAttri("", false, "A1509ParCue2Tip", A1509ParCue2Tip);
            A1510ParCue3Tip = T001T3_A1510ParCue3Tip[0];
            AssignAttri("", false, "A1510ParCue3Tip", A1510ParCue3Tip);
            A1511ParCue4Tip = T001T3_A1511ParCue4Tip[0];
            AssignAttri("", false, "A1511ParCue4Tip", A1511ParCue4Tip);
            A1512ParCue5Tip = T001T3_A1512ParCue5Tip[0];
            AssignAttri("", false, "A1512ParCue5Tip", A1512ParCue5Tip);
            A1513ParCue6Tip = T001T3_A1513ParCue6Tip[0];
            AssignAttri("", false, "A1513ParCue6Tip", A1513ParCue6Tip);
            A1514ParCue7Tip = T001T3_A1514ParCue7Tip[0];
            AssignAttri("", false, "A1514ParCue7Tip", A1514ParCue7Tip);
            A1515ParCue8Tip = T001T3_A1515ParCue8Tip[0];
            AssignAttri("", false, "A1515ParCue8Tip", A1515ParCue8Tip);
            A1516ParCue9Tip = T001T3_A1516ParCue9Tip[0];
            AssignAttri("", false, "A1516ParCue9Tip", A1516ParCue9Tip);
            A1507ParCue10Tip = T001T3_A1507ParCue10Tip[0];
            AssignAttri("", false, "A1507ParCue10Tip", A1507ParCue10Tip);
            A1542ParTitem = T001T3_A1542ParTitem[0];
            AssignAttri("", false, "A1542ParTitem", StringUtil.LTrimStr( (decimal)(A1542ParTitem), 4, 0));
            A1540ParForCod = T001T3_A1540ParForCod[0];
            AssignAttri("", false, "A1540ParForCod", StringUtil.LTrimStr( (decimal)(A1540ParForCod), 6, 0));
            A83ParTip = T001T3_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A94ParCue1 = T001T3_A94ParCue1[0];
            n94ParCue1 = T001T3_n94ParCue1[0];
            AssignAttri("", false, "A94ParCue1", A94ParCue1);
            A95ParCue2 = T001T3_A95ParCue2[0];
            n95ParCue2 = T001T3_n95ParCue2[0];
            AssignAttri("", false, "A95ParCue2", A95ParCue2);
            A96ParCue3 = T001T3_A96ParCue3[0];
            n96ParCue3 = T001T3_n96ParCue3[0];
            AssignAttri("", false, "A96ParCue3", A96ParCue3);
            A97ParCue4 = T001T3_A97ParCue4[0];
            n97ParCue4 = T001T3_n97ParCue4[0];
            AssignAttri("", false, "A97ParCue4", A97ParCue4);
            A98ParCue5 = T001T3_A98ParCue5[0];
            n98ParCue5 = T001T3_n98ParCue5[0];
            AssignAttri("", false, "A98ParCue5", A98ParCue5);
            A99ParCue6 = T001T3_A99ParCue6[0];
            n99ParCue6 = T001T3_n99ParCue6[0];
            AssignAttri("", false, "A99ParCue6", A99ParCue6);
            A100ParCue7 = T001T3_A100ParCue7[0];
            n100ParCue7 = T001T3_n100ParCue7[0];
            AssignAttri("", false, "A100ParCue7", A100ParCue7);
            A101ParCue8 = T001T3_A101ParCue8[0];
            n101ParCue8 = T001T3_n101ParCue8[0];
            AssignAttri("", false, "A101ParCue8", A101ParCue8);
            A102ParCue9 = T001T3_A102ParCue9[0];
            n102ParCue9 = T001T3_n102ParCue9[0];
            AssignAttri("", false, "A102ParCue9", A102ParCue9);
            A103ParCue10 = T001T3_A103ParCue10[0];
            n103ParCue10 = T001T3_n103ParCue10[0];
            AssignAttri("", false, "A103ParCue10", A103ParCue10);
            A93ParMonCod = T001T3_A93ParMonCod[0];
            AssignAttri("", false, "A93ParMonCod", StringUtil.LTrimStr( (decimal)(A93ParMonCod), 6, 0));
            A92ParTipCod = T001T3_A92ParTipCod[0];
            AssignAttri("", false, "A92ParTipCod", A92ParTipCod);
            Z83ParTip = A83ParTip;
            Z84ParCod = A84ParCod;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1T62( ) ;
            if ( AnyError == 1 )
            {
               RcdFound62 = 0;
               InitializeNonKey1T62( ) ;
            }
            Gx_mode = sMode62;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound62 = 0;
            InitializeNonKey1T62( ) ;
            sMode62 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode62;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1T62( ) ;
         if ( RcdFound62 == 0 )
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
         RcdFound62 = 0;
         /* Using cursor T001T32 */
         pr_default.execute(30, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(30) != 101) )
         {
            while ( (pr_default.getStatus(30) != 101) && ( ( StringUtil.StrCmp(T001T32_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001T32_A83ParTip[0], A83ParTip) == 0 ) && ( T001T32_A84ParCod[0] < A84ParCod ) ) )
            {
               pr_default.readNext(30);
            }
            if ( (pr_default.getStatus(30) != 101) && ( ( StringUtil.StrCmp(T001T32_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001T32_A83ParTip[0], A83ParTip) == 0 ) && ( T001T32_A84ParCod[0] > A84ParCod ) ) )
            {
               A83ParTip = T001T32_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001T32_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               RcdFound62 = 1;
            }
         }
         pr_default.close(30);
      }

      protected void move_previous( )
      {
         RcdFound62 = 0;
         /* Using cursor T001T33 */
         pr_default.execute(31, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(31) != 101) )
         {
            while ( (pr_default.getStatus(31) != 101) && ( ( StringUtil.StrCmp(T001T33_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001T33_A83ParTip[0], A83ParTip) == 0 ) && ( T001T33_A84ParCod[0] > A84ParCod ) ) )
            {
               pr_default.readNext(31);
            }
            if ( (pr_default.getStatus(31) != 101) && ( ( StringUtil.StrCmp(T001T33_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001T33_A83ParTip[0], A83ParTip) == 0 ) && ( T001T33_A84ParCod[0] < A84ParCod ) ) )
            {
               A83ParTip = T001T33_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001T33_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               RcdFound62 = 1;
            }
         }
         pr_default.close(31);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1T62( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1T62( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound62 == 1 )
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) )
               {
                  A83ParTip = Z83ParTip;
                  AssignAttri("", false, "A83ParTip", A83ParTip);
                  A84ParCod = Z84ParCod;
                  AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARTIP");
                  AnyError = 1;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1T62( ) ;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1T62( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARTIP");
                     AnyError = 1;
                     GX_FocusControl = edtParTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtParTip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1T62( ) ;
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
         if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) )
         {
            A83ParTip = Z83ParTip;
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = Z84ParCod;
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtParTip_Internalname;
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
         GetKey1T62( ) ;
         if ( RcdFound62 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PARTIP");
               AnyError = 1;
               GX_FocusControl = edtParTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) )
            {
               A83ParTip = Z83ParTip;
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = Z84ParCod;
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PARTIP");
               AnyError = 1;
               GX_FocusControl = edtParTip_Internalname;
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
            if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARTIP");
                  AnyError = 1;
                  GX_FocusControl = edtParTip_Internalname;
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
         context.RollbackDataStores("cbparamdet",pr_default);
         GX_FocusControl = edtParCue1_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1T0( ) ;
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
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtParCue1_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1T62( ) ;
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParCue1_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1T62( ) ;
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
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParCue1_Internalname;
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
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParCue1_Internalname;
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
         ScanStart1T62( ) ;
         if ( RcdFound62 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound62 != 0 )
            {
               ScanNext1T62( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParCue1_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1T62( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1T62( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001T2 */
            pr_default.execute(0, new Object[] {A83ParTip, A84ParCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1508ParCue1Tip, T001T2_A1508ParCue1Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1509ParCue2Tip, T001T2_A1509ParCue2Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1510ParCue3Tip, T001T2_A1510ParCue3Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1511ParCue4Tip, T001T2_A1511ParCue4Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1512ParCue5Tip, T001T2_A1512ParCue5Tip[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1513ParCue6Tip, T001T2_A1513ParCue6Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1514ParCue7Tip, T001T2_A1514ParCue7Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1515ParCue8Tip, T001T2_A1515ParCue8Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1516ParCue9Tip, T001T2_A1516ParCue9Tip[0]) != 0 ) || ( StringUtil.StrCmp(Z1507ParCue10Tip, T001T2_A1507ParCue10Tip[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1542ParTitem != T001T2_A1542ParTitem[0] ) || ( Z1540ParForCod != T001T2_A1540ParForCod[0] ) || ( StringUtil.StrCmp(Z94ParCue1, T001T2_A94ParCue1[0]) != 0 ) || ( StringUtil.StrCmp(Z95ParCue2, T001T2_A95ParCue2[0]) != 0 ) || ( StringUtil.StrCmp(Z96ParCue3, T001T2_A96ParCue3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z97ParCue4, T001T2_A97ParCue4[0]) != 0 ) || ( StringUtil.StrCmp(Z98ParCue5, T001T2_A98ParCue5[0]) != 0 ) || ( StringUtil.StrCmp(Z99ParCue6, T001T2_A99ParCue6[0]) != 0 ) || ( StringUtil.StrCmp(Z100ParCue7, T001T2_A100ParCue7[0]) != 0 ) || ( StringUtil.StrCmp(Z101ParCue8, T001T2_A101ParCue8[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z102ParCue9, T001T2_A102ParCue9[0]) != 0 ) || ( StringUtil.StrCmp(Z103ParCue10, T001T2_A103ParCue10[0]) != 0 ) || ( Z93ParMonCod != T001T2_A93ParMonCod[0] ) || ( StringUtil.StrCmp(Z92ParTipCod, T001T2_A92ParTipCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1508ParCue1Tip, T001T2_A1508ParCue1Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue1Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1508ParCue1Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1508ParCue1Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1509ParCue2Tip, T001T2_A1509ParCue2Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue2Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1509ParCue2Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1509ParCue2Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1510ParCue3Tip, T001T2_A1510ParCue3Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue3Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1510ParCue3Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1510ParCue3Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1511ParCue4Tip, T001T2_A1511ParCue4Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue4Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1511ParCue4Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1511ParCue4Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1512ParCue5Tip, T001T2_A1512ParCue5Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue5Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1512ParCue5Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1512ParCue5Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1513ParCue6Tip, T001T2_A1513ParCue6Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue6Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1513ParCue6Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1513ParCue6Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1514ParCue7Tip, T001T2_A1514ParCue7Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue7Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1514ParCue7Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1514ParCue7Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1515ParCue8Tip, T001T2_A1515ParCue8Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue8Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1515ParCue8Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1515ParCue8Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1516ParCue9Tip, T001T2_A1516ParCue9Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue9Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1516ParCue9Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1516ParCue9Tip[0]);
               }
               if ( StringUtil.StrCmp(Z1507ParCue10Tip, T001T2_A1507ParCue10Tip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue10Tip");
                  GXUtil.WriteLogRaw("Old: ",Z1507ParCue10Tip);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1507ParCue10Tip[0]);
               }
               if ( Z1542ParTitem != T001T2_A1542ParTitem[0] )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParTitem");
                  GXUtil.WriteLogRaw("Old: ",Z1542ParTitem);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1542ParTitem[0]);
               }
               if ( Z1540ParForCod != T001T2_A1540ParForCod[0] )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParForCod");
                  GXUtil.WriteLogRaw("Old: ",Z1540ParForCod);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A1540ParForCod[0]);
               }
               if ( StringUtil.StrCmp(Z94ParCue1, T001T2_A94ParCue1[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue1");
                  GXUtil.WriteLogRaw("Old: ",Z94ParCue1);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A94ParCue1[0]);
               }
               if ( StringUtil.StrCmp(Z95ParCue2, T001T2_A95ParCue2[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue2");
                  GXUtil.WriteLogRaw("Old: ",Z95ParCue2);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A95ParCue2[0]);
               }
               if ( StringUtil.StrCmp(Z96ParCue3, T001T2_A96ParCue3[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue3");
                  GXUtil.WriteLogRaw("Old: ",Z96ParCue3);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A96ParCue3[0]);
               }
               if ( StringUtil.StrCmp(Z97ParCue4, T001T2_A97ParCue4[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue4");
                  GXUtil.WriteLogRaw("Old: ",Z97ParCue4);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A97ParCue4[0]);
               }
               if ( StringUtil.StrCmp(Z98ParCue5, T001T2_A98ParCue5[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue5");
                  GXUtil.WriteLogRaw("Old: ",Z98ParCue5);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A98ParCue5[0]);
               }
               if ( StringUtil.StrCmp(Z99ParCue6, T001T2_A99ParCue6[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue6");
                  GXUtil.WriteLogRaw("Old: ",Z99ParCue6);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A99ParCue6[0]);
               }
               if ( StringUtil.StrCmp(Z100ParCue7, T001T2_A100ParCue7[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue7");
                  GXUtil.WriteLogRaw("Old: ",Z100ParCue7);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A100ParCue7[0]);
               }
               if ( StringUtil.StrCmp(Z101ParCue8, T001T2_A101ParCue8[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue8");
                  GXUtil.WriteLogRaw("Old: ",Z101ParCue8);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A101ParCue8[0]);
               }
               if ( StringUtil.StrCmp(Z102ParCue9, T001T2_A102ParCue9[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue9");
                  GXUtil.WriteLogRaw("Old: ",Z102ParCue9);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A102ParCue9[0]);
               }
               if ( StringUtil.StrCmp(Z103ParCue10, T001T2_A103ParCue10[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParCue10");
                  GXUtil.WriteLogRaw("Old: ",Z103ParCue10);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A103ParCue10[0]);
               }
               if ( Z93ParMonCod != T001T2_A93ParMonCod[0] )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParMonCod");
                  GXUtil.WriteLogRaw("Old: ",Z93ParMonCod);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A93ParMonCod[0]);
               }
               if ( StringUtil.StrCmp(Z92ParTipCod, T001T2_A92ParTipCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamdet:[seudo value changed for attri]"+"ParTipCod");
                  GXUtil.WriteLogRaw("Old: ",Z92ParTipCod);
                  GXUtil.WriteLogRaw("Current: ",T001T2_A92ParTipCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPARAMDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1T62( )
      {
         BeforeValidate1T62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T62( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1T62( 0) ;
            CheckOptimisticConcurrency1T62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1T62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T34 */
                     pr_default.execute(32, new Object[] {A84ParCod, A1508ParCue1Tip, A1509ParCue2Tip, A1510ParCue3Tip, A1511ParCue4Tip, A1512ParCue5Tip, A1513ParCue6Tip, A1514ParCue7Tip, A1515ParCue8Tip, A1516ParCue9Tip, A1507ParCue10Tip, A1542ParTitem, A1540ParForCod, A83ParTip, n94ParCue1, A94ParCue1, n95ParCue2, A95ParCue2, n96ParCue3, A96ParCue3, n97ParCue4, A97ParCue4, n98ParCue5, A98ParCue5, n99ParCue6, A99ParCue6, n100ParCue7, A100ParCue7, n101ParCue8, A101ParCue8, n102ParCue9, A102ParCue9, n103ParCue10, A103ParCue10, A93ParMonCod, A92ParTipCod});
                     pr_default.close(32);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMDET");
                     if ( (pr_default.getStatus(32) == 1) )
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
                           ResetCaption1T0( ) ;
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
               Load1T62( ) ;
            }
            EndLevel1T62( ) ;
         }
         CloseExtendedTableCursors1T62( ) ;
      }

      protected void Update1T62( )
      {
         BeforeValidate1T62( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1T62( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T62( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1T62( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1T62( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001T35 */
                     pr_default.execute(33, new Object[] {A1508ParCue1Tip, A1509ParCue2Tip, A1510ParCue3Tip, A1511ParCue4Tip, A1512ParCue5Tip, A1513ParCue6Tip, A1514ParCue7Tip, A1515ParCue8Tip, A1516ParCue9Tip, A1507ParCue10Tip, A1542ParTitem, A1540ParForCod, n94ParCue1, A94ParCue1, n95ParCue2, A95ParCue2, n96ParCue3, A96ParCue3, n97ParCue4, A97ParCue4, n98ParCue5, A98ParCue5, n99ParCue6, A99ParCue6, n100ParCue7, A100ParCue7, n101ParCue8, A101ParCue8, n102ParCue9, A102ParCue9, n103ParCue10, A103ParCue10, A93ParMonCod, A92ParTipCod, A83ParTip, A84ParCod});
                     pr_default.close(33);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMDET");
                     if ( (pr_default.getStatus(33) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1T62( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1T0( ) ;
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
            EndLevel1T62( ) ;
         }
         CloseExtendedTableCursors1T62( ) ;
      }

      protected void DeferredUpdate1T62( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1T62( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1T62( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1T62( ) ;
            AfterConfirm1T62( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1T62( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001T36 */
                  pr_default.execute(34, new Object[] {A83ParTip, A84ParCod});
                  pr_default.close(34);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPARAMDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound62 == 0 )
                        {
                           InitAll1T62( ) ;
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
                        ResetCaption1T0( ) ;
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
         sMode62 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1T62( ) ;
         Gx_mode = sMode62;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1T62( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001T37 */
            pr_default.execute(35, new Object[] {n94ParCue1, A94ParCue1});
            A1517ParCueDsc1 = T001T37_A1517ParCueDsc1[0];
            AssignAttri("", false, "A1517ParCueDsc1", A1517ParCueDsc1);
            pr_default.close(35);
            /* Using cursor T001T38 */
            pr_default.execute(36, new Object[] {n95ParCue2, A95ParCue2});
            A1519ParCueDsc2 = T001T38_A1519ParCueDsc2[0];
            AssignAttri("", false, "A1519ParCueDsc2", A1519ParCueDsc2);
            pr_default.close(36);
            /* Using cursor T001T39 */
            pr_default.execute(37, new Object[] {n96ParCue3, A96ParCue3});
            A1520ParCueDsc3 = T001T39_A1520ParCueDsc3[0];
            AssignAttri("", false, "A1520ParCueDsc3", A1520ParCueDsc3);
            pr_default.close(37);
            /* Using cursor T001T40 */
            pr_default.execute(38, new Object[] {n97ParCue4, A97ParCue4});
            A1521ParCueDsc4 = T001T40_A1521ParCueDsc4[0];
            AssignAttri("", false, "A1521ParCueDsc4", A1521ParCueDsc4);
            pr_default.close(38);
            /* Using cursor T001T41 */
            pr_default.execute(39, new Object[] {n98ParCue5, A98ParCue5});
            A1522ParCueDsc5 = T001T41_A1522ParCueDsc5[0];
            AssignAttri("", false, "A1522ParCueDsc5", A1522ParCueDsc5);
            pr_default.close(39);
            /* Using cursor T001T42 */
            pr_default.execute(40, new Object[] {n99ParCue6, A99ParCue6});
            A1523ParCueDsc6 = T001T42_A1523ParCueDsc6[0];
            AssignAttri("", false, "A1523ParCueDsc6", A1523ParCueDsc6);
            pr_default.close(40);
            /* Using cursor T001T43 */
            pr_default.execute(41, new Object[] {n100ParCue7, A100ParCue7});
            A1524ParCueDsc7 = T001T43_A1524ParCueDsc7[0];
            AssignAttri("", false, "A1524ParCueDsc7", A1524ParCueDsc7);
            pr_default.close(41);
            /* Using cursor T001T44 */
            pr_default.execute(42, new Object[] {n101ParCue8, A101ParCue8});
            A1525ParCueDsc8 = T001T44_A1525ParCueDsc8[0];
            AssignAttri("", false, "A1525ParCueDsc8", A1525ParCueDsc8);
            pr_default.close(42);
            /* Using cursor T001T45 */
            pr_default.execute(43, new Object[] {n102ParCue9, A102ParCue9});
            A1526ParCueDsc9 = T001T45_A1526ParCueDsc9[0];
            AssignAttri("", false, "A1526ParCueDsc9", A1526ParCueDsc9);
            pr_default.close(43);
            /* Using cursor T001T46 */
            pr_default.execute(44, new Object[] {n103ParCue10, A103ParCue10});
            A1518ParCueDsc10 = T001T46_A1518ParCueDsc10[0];
            AssignAttri("", false, "A1518ParCueDsc10", A1518ParCueDsc10);
            pr_default.close(44);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001T47 */
            pr_default.execute(45, new Object[] {A83ParTip, A84ParCod});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Conceptos de Planilla"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T001T48 */
            pr_default.execute(46, new Object[] {A83ParTip, A84ParCod});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor T001T49 */
            pr_default.execute(47, new Object[] {A83ParTip, A84ParCod});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Activo Fijo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
         }
      }

      protected void EndLevel1T62( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1T62( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(35);
            pr_default.close(36);
            pr_default.close(37);
            pr_default.close(38);
            pr_default.close(39);
            pr_default.close(40);
            pr_default.close(41);
            pr_default.close(42);
            pr_default.close(43);
            pr_default.close(44);
            context.CommitDataStores("cbparamdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(35);
            pr_default.close(36);
            pr_default.close(37);
            pr_default.close(38);
            pr_default.close(39);
            pr_default.close(40);
            pr_default.close(41);
            pr_default.close(42);
            pr_default.close(43);
            pr_default.close(44);
            context.RollbackDataStores("cbparamdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1T62( )
      {
         /* Using cursor T001T50 */
         pr_default.execute(48);
         RcdFound62 = 0;
         if ( (pr_default.getStatus(48) != 101) )
         {
            RcdFound62 = 1;
            A83ParTip = T001T50_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001T50_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1T62( )
      {
         /* Scan next routine */
         pr_default.readNext(48);
         RcdFound62 = 0;
         if ( (pr_default.getStatus(48) != 101) )
         {
            RcdFound62 = 1;
            A83ParTip = T001T50_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001T50_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
         }
      }

      protected void ScanEnd1T62( )
      {
         pr_default.close(48);
      }

      protected void AfterConfirm1T62( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1T62( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1T62( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1T62( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1T62( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1T62( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1T62( )
      {
         edtParTip_Enabled = 0;
         AssignProp("", false, edtParTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParTip_Enabled), 5, 0), true);
         edtParCod_Enabled = 0;
         AssignProp("", false, edtParCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCod_Enabled), 5, 0), true);
         edtParCue1_Enabled = 0;
         AssignProp("", false, edtParCue1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue1_Enabled), 5, 0), true);
         edtParCueDsc1_Enabled = 0;
         AssignProp("", false, edtParCueDsc1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc1_Enabled), 5, 0), true);
         edtParCue1Tip_Enabled = 0;
         AssignProp("", false, edtParCue1Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue1Tip_Enabled), 5, 0), true);
         edtParCue2_Enabled = 0;
         AssignProp("", false, edtParCue2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue2_Enabled), 5, 0), true);
         edtParCueDsc2_Enabled = 0;
         AssignProp("", false, edtParCueDsc2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc2_Enabled), 5, 0), true);
         edtParCue2Tip_Enabled = 0;
         AssignProp("", false, edtParCue2Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue2Tip_Enabled), 5, 0), true);
         edtParCue3_Enabled = 0;
         AssignProp("", false, edtParCue3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue3_Enabled), 5, 0), true);
         edtParCueDsc3_Enabled = 0;
         AssignProp("", false, edtParCueDsc3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc3_Enabled), 5, 0), true);
         edtParCue3Tip_Enabled = 0;
         AssignProp("", false, edtParCue3Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue3Tip_Enabled), 5, 0), true);
         edtParCue4_Enabled = 0;
         AssignProp("", false, edtParCue4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue4_Enabled), 5, 0), true);
         edtParCueDsc4_Enabled = 0;
         AssignProp("", false, edtParCueDsc4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc4_Enabled), 5, 0), true);
         edtParCue4Tip_Enabled = 0;
         AssignProp("", false, edtParCue4Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue4Tip_Enabled), 5, 0), true);
         edtParCue5_Enabled = 0;
         AssignProp("", false, edtParCue5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue5_Enabled), 5, 0), true);
         edtParCueDsc5_Enabled = 0;
         AssignProp("", false, edtParCueDsc5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc5_Enabled), 5, 0), true);
         edtParCue5Tip_Enabled = 0;
         AssignProp("", false, edtParCue5Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue5Tip_Enabled), 5, 0), true);
         edtParCue6_Enabled = 0;
         AssignProp("", false, edtParCue6_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue6_Enabled), 5, 0), true);
         edtParCueDsc6_Enabled = 0;
         AssignProp("", false, edtParCueDsc6_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc6_Enabled), 5, 0), true);
         edtParCue6Tip_Enabled = 0;
         AssignProp("", false, edtParCue6Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue6Tip_Enabled), 5, 0), true);
         edtParCue7_Enabled = 0;
         AssignProp("", false, edtParCue7_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue7_Enabled), 5, 0), true);
         edtParCueDsc7_Enabled = 0;
         AssignProp("", false, edtParCueDsc7_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc7_Enabled), 5, 0), true);
         edtParCue7Tip_Enabled = 0;
         AssignProp("", false, edtParCue7Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue7Tip_Enabled), 5, 0), true);
         edtParCue8_Enabled = 0;
         AssignProp("", false, edtParCue8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue8_Enabled), 5, 0), true);
         edtParCueDsc8_Enabled = 0;
         AssignProp("", false, edtParCueDsc8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc8_Enabled), 5, 0), true);
         edtParCue8Tip_Enabled = 0;
         AssignProp("", false, edtParCue8Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue8Tip_Enabled), 5, 0), true);
         edtParCue9_Enabled = 0;
         AssignProp("", false, edtParCue9_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue9_Enabled), 5, 0), true);
         edtParCueDsc9_Enabled = 0;
         AssignProp("", false, edtParCueDsc9_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc9_Enabled), 5, 0), true);
         edtParCue9Tip_Enabled = 0;
         AssignProp("", false, edtParCue9Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue9Tip_Enabled), 5, 0), true);
         edtParCue10_Enabled = 0;
         AssignProp("", false, edtParCue10_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue10_Enabled), 5, 0), true);
         edtParCueDsc10_Enabled = 0;
         AssignProp("", false, edtParCueDsc10_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCueDsc10_Enabled), 5, 0), true);
         edtParCue10Tip_Enabled = 0;
         AssignProp("", false, edtParCue10Tip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCue10Tip_Enabled), 5, 0), true);
         edtParMonCod_Enabled = 0;
         AssignProp("", false, edtParMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParMonCod_Enabled), 5, 0), true);
         edtParTipCod_Enabled = 0;
         AssignProp("", false, edtParTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParTipCod_Enabled), 5, 0), true);
         edtParTitem_Enabled = 0;
         AssignProp("", false, edtParTitem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParTitem_Enabled), 5, 0), true);
         edtParForCod_Enabled = 0;
         AssignProp("", false, edtParForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParForCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1T62( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1T0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810241514", false, true);
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
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbparamdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z83ParTip", StringUtil.RTrim( Z83ParTip));
         GxWebStd.gx_hidden_field( context, "Z84ParCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84ParCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1508ParCue1Tip", StringUtil.RTrim( Z1508ParCue1Tip));
         GxWebStd.gx_hidden_field( context, "Z1509ParCue2Tip", StringUtil.RTrim( Z1509ParCue2Tip));
         GxWebStd.gx_hidden_field( context, "Z1510ParCue3Tip", StringUtil.RTrim( Z1510ParCue3Tip));
         GxWebStd.gx_hidden_field( context, "Z1511ParCue4Tip", StringUtil.RTrim( Z1511ParCue4Tip));
         GxWebStd.gx_hidden_field( context, "Z1512ParCue5Tip", StringUtil.RTrim( Z1512ParCue5Tip));
         GxWebStd.gx_hidden_field( context, "Z1513ParCue6Tip", StringUtil.RTrim( Z1513ParCue6Tip));
         GxWebStd.gx_hidden_field( context, "Z1514ParCue7Tip", StringUtil.RTrim( Z1514ParCue7Tip));
         GxWebStd.gx_hidden_field( context, "Z1515ParCue8Tip", StringUtil.RTrim( Z1515ParCue8Tip));
         GxWebStd.gx_hidden_field( context, "Z1516ParCue9Tip", StringUtil.RTrim( Z1516ParCue9Tip));
         GxWebStd.gx_hidden_field( context, "Z1507ParCue10Tip", StringUtil.RTrim( Z1507ParCue10Tip));
         GxWebStd.gx_hidden_field( context, "Z1542ParTitem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1542ParTitem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1540ParForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1540ParForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z94ParCue1", StringUtil.RTrim( Z94ParCue1));
         GxWebStd.gx_hidden_field( context, "Z95ParCue2", StringUtil.RTrim( Z95ParCue2));
         GxWebStd.gx_hidden_field( context, "Z96ParCue3", StringUtil.RTrim( Z96ParCue3));
         GxWebStd.gx_hidden_field( context, "Z97ParCue4", StringUtil.RTrim( Z97ParCue4));
         GxWebStd.gx_hidden_field( context, "Z98ParCue5", StringUtil.RTrim( Z98ParCue5));
         GxWebStd.gx_hidden_field( context, "Z99ParCue6", StringUtil.RTrim( Z99ParCue6));
         GxWebStd.gx_hidden_field( context, "Z100ParCue7", StringUtil.RTrim( Z100ParCue7));
         GxWebStd.gx_hidden_field( context, "Z101ParCue8", StringUtil.RTrim( Z101ParCue8));
         GxWebStd.gx_hidden_field( context, "Z102ParCue9", StringUtil.RTrim( Z102ParCue9));
         GxWebStd.gx_hidden_field( context, "Z103ParCue10", StringUtil.RTrim( Z103ParCue10));
         GxWebStd.gx_hidden_field( context, "Z93ParMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z93ParMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z92ParTipCod", StringUtil.RTrim( Z92ParTipCod));
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
         return formatLink("cbparamdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPARAMDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parametrización - Detalle" ;
      }

      protected void InitializeNonKey1T62( )
      {
         A94ParCue1 = "";
         n94ParCue1 = false;
         AssignAttri("", false, "A94ParCue1", A94ParCue1);
         n94ParCue1 = (String.IsNullOrEmpty(StringUtil.RTrim( A94ParCue1)) ? true : false);
         A1517ParCueDsc1 = "";
         AssignAttri("", false, "A1517ParCueDsc1", A1517ParCueDsc1);
         A1508ParCue1Tip = "";
         AssignAttri("", false, "A1508ParCue1Tip", A1508ParCue1Tip);
         A95ParCue2 = "";
         n95ParCue2 = false;
         AssignAttri("", false, "A95ParCue2", A95ParCue2);
         n95ParCue2 = (String.IsNullOrEmpty(StringUtil.RTrim( A95ParCue2)) ? true : false);
         A1519ParCueDsc2 = "";
         AssignAttri("", false, "A1519ParCueDsc2", A1519ParCueDsc2);
         A1509ParCue2Tip = "";
         AssignAttri("", false, "A1509ParCue2Tip", A1509ParCue2Tip);
         A96ParCue3 = "";
         n96ParCue3 = false;
         AssignAttri("", false, "A96ParCue3", A96ParCue3);
         n96ParCue3 = (String.IsNullOrEmpty(StringUtil.RTrim( A96ParCue3)) ? true : false);
         A1520ParCueDsc3 = "";
         AssignAttri("", false, "A1520ParCueDsc3", A1520ParCueDsc3);
         A1510ParCue3Tip = "";
         AssignAttri("", false, "A1510ParCue3Tip", A1510ParCue3Tip);
         A97ParCue4 = "";
         n97ParCue4 = false;
         AssignAttri("", false, "A97ParCue4", A97ParCue4);
         n97ParCue4 = (String.IsNullOrEmpty(StringUtil.RTrim( A97ParCue4)) ? true : false);
         A1521ParCueDsc4 = "";
         AssignAttri("", false, "A1521ParCueDsc4", A1521ParCueDsc4);
         A1511ParCue4Tip = "";
         AssignAttri("", false, "A1511ParCue4Tip", A1511ParCue4Tip);
         A98ParCue5 = "";
         n98ParCue5 = false;
         AssignAttri("", false, "A98ParCue5", A98ParCue5);
         n98ParCue5 = (String.IsNullOrEmpty(StringUtil.RTrim( A98ParCue5)) ? true : false);
         A1522ParCueDsc5 = "";
         AssignAttri("", false, "A1522ParCueDsc5", A1522ParCueDsc5);
         A1512ParCue5Tip = "";
         AssignAttri("", false, "A1512ParCue5Tip", A1512ParCue5Tip);
         A99ParCue6 = "";
         n99ParCue6 = false;
         AssignAttri("", false, "A99ParCue6", A99ParCue6);
         n99ParCue6 = (String.IsNullOrEmpty(StringUtil.RTrim( A99ParCue6)) ? true : false);
         A1523ParCueDsc6 = "";
         AssignAttri("", false, "A1523ParCueDsc6", A1523ParCueDsc6);
         A1513ParCue6Tip = "";
         AssignAttri("", false, "A1513ParCue6Tip", A1513ParCue6Tip);
         A100ParCue7 = "";
         n100ParCue7 = false;
         AssignAttri("", false, "A100ParCue7", A100ParCue7);
         n100ParCue7 = (String.IsNullOrEmpty(StringUtil.RTrim( A100ParCue7)) ? true : false);
         A1524ParCueDsc7 = "";
         AssignAttri("", false, "A1524ParCueDsc7", A1524ParCueDsc7);
         A1514ParCue7Tip = "";
         AssignAttri("", false, "A1514ParCue7Tip", A1514ParCue7Tip);
         A101ParCue8 = "";
         n101ParCue8 = false;
         AssignAttri("", false, "A101ParCue8", A101ParCue8);
         n101ParCue8 = (String.IsNullOrEmpty(StringUtil.RTrim( A101ParCue8)) ? true : false);
         A1525ParCueDsc8 = "";
         AssignAttri("", false, "A1525ParCueDsc8", A1525ParCueDsc8);
         A1515ParCue8Tip = "";
         AssignAttri("", false, "A1515ParCue8Tip", A1515ParCue8Tip);
         A102ParCue9 = "";
         n102ParCue9 = false;
         AssignAttri("", false, "A102ParCue9", A102ParCue9);
         n102ParCue9 = (String.IsNullOrEmpty(StringUtil.RTrim( A102ParCue9)) ? true : false);
         A1526ParCueDsc9 = "";
         AssignAttri("", false, "A1526ParCueDsc9", A1526ParCueDsc9);
         A1516ParCue9Tip = "";
         AssignAttri("", false, "A1516ParCue9Tip", A1516ParCue9Tip);
         A103ParCue10 = "";
         n103ParCue10 = false;
         AssignAttri("", false, "A103ParCue10", A103ParCue10);
         n103ParCue10 = (String.IsNullOrEmpty(StringUtil.RTrim( A103ParCue10)) ? true : false);
         A1518ParCueDsc10 = "";
         AssignAttri("", false, "A1518ParCueDsc10", A1518ParCueDsc10);
         A1507ParCue10Tip = "";
         AssignAttri("", false, "A1507ParCue10Tip", A1507ParCue10Tip);
         A93ParMonCod = 0;
         AssignAttri("", false, "A93ParMonCod", StringUtil.LTrimStr( (decimal)(A93ParMonCod), 6, 0));
         A92ParTipCod = "";
         AssignAttri("", false, "A92ParTipCod", A92ParTipCod);
         A1542ParTitem = 0;
         AssignAttri("", false, "A1542ParTitem", StringUtil.LTrimStr( (decimal)(A1542ParTitem), 4, 0));
         A1540ParForCod = 0;
         AssignAttri("", false, "A1540ParForCod", StringUtil.LTrimStr( (decimal)(A1540ParForCod), 6, 0));
         Z1508ParCue1Tip = "";
         Z1509ParCue2Tip = "";
         Z1510ParCue3Tip = "";
         Z1511ParCue4Tip = "";
         Z1512ParCue5Tip = "";
         Z1513ParCue6Tip = "";
         Z1514ParCue7Tip = "";
         Z1515ParCue8Tip = "";
         Z1516ParCue9Tip = "";
         Z1507ParCue10Tip = "";
         Z1542ParTitem = 0;
         Z1540ParForCod = 0;
         Z94ParCue1 = "";
         Z95ParCue2 = "";
         Z96ParCue3 = "";
         Z97ParCue4 = "";
         Z98ParCue5 = "";
         Z99ParCue6 = "";
         Z100ParCue7 = "";
         Z101ParCue8 = "";
         Z102ParCue9 = "";
         Z103ParCue10 = "";
         Z93ParMonCod = 0;
         Z92ParTipCod = "";
      }

      protected void InitAll1T62( )
      {
         A83ParTip = "";
         AssignAttri("", false, "A83ParTip", A83ParTip);
         A84ParCod = 0;
         AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
         InitializeNonKey1T62( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810241540", true, true);
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
         context.AddJavascriptSource("cbparamdet.js", "?202281810241541", false, true);
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
         edtParTip_Internalname = "PARTIP";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtParCod_Internalname = "PARCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtParCue1_Internalname = "PARCUE1";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtParCueDsc1_Internalname = "PARCUEDSC1";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtParCue1Tip_Internalname = "PARCUE1TIP";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtParCue2_Internalname = "PARCUE2";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtParCueDsc2_Internalname = "PARCUEDSC2";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtParCue2Tip_Internalname = "PARCUE2TIP";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtParCue3_Internalname = "PARCUE3";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtParCueDsc3_Internalname = "PARCUEDSC3";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtParCue3Tip_Internalname = "PARCUE3TIP";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtParCue4_Internalname = "PARCUE4";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtParCueDsc4_Internalname = "PARCUEDSC4";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtParCue4Tip_Internalname = "PARCUE4TIP";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtParCue5_Internalname = "PARCUE5";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtParCueDsc5_Internalname = "PARCUEDSC5";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtParCue5Tip_Internalname = "PARCUE5TIP";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtParCue6_Internalname = "PARCUE6";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtParCueDsc6_Internalname = "PARCUEDSC6";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtParCue6Tip_Internalname = "PARCUE6TIP";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtParCue7_Internalname = "PARCUE7";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtParCueDsc7_Internalname = "PARCUEDSC7";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtParCue7Tip_Internalname = "PARCUE7TIP";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtParCue8_Internalname = "PARCUE8";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtParCueDsc8_Internalname = "PARCUEDSC8";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtParCue8Tip_Internalname = "PARCUE8TIP";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtParCue9_Internalname = "PARCUE9";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtParCueDsc9_Internalname = "PARCUEDSC9";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtParCue9Tip_Internalname = "PARCUE9TIP";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtParCue10_Internalname = "PARCUE10";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtParCueDsc10_Internalname = "PARCUEDSC10";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtParCue10Tip_Internalname = "PARCUE10TIP";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtParMonCod_Internalname = "PARMONCOD";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtParTipCod_Internalname = "PARTIPCOD";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtParTitem_Internalname = "PARTITEM";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtParForCod_Internalname = "PARFORCOD";
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
         Form.Caption = "Parametrización - Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtParForCod_Jsonclick = "";
         edtParForCod_Enabled = 1;
         edtParTitem_Jsonclick = "";
         edtParTitem_Enabled = 1;
         edtParTipCod_Jsonclick = "";
         edtParTipCod_Enabled = 1;
         edtParMonCod_Jsonclick = "";
         edtParMonCod_Enabled = 1;
         edtParCue10Tip_Jsonclick = "";
         edtParCue10Tip_Enabled = 1;
         edtParCueDsc10_Jsonclick = "";
         edtParCueDsc10_Enabled = 0;
         edtParCue10_Jsonclick = "";
         edtParCue10_Enabled = 1;
         edtParCue9Tip_Jsonclick = "";
         edtParCue9Tip_Enabled = 1;
         edtParCueDsc9_Jsonclick = "";
         edtParCueDsc9_Enabled = 0;
         edtParCue9_Jsonclick = "";
         edtParCue9_Enabled = 1;
         edtParCue8Tip_Jsonclick = "";
         edtParCue8Tip_Enabled = 1;
         edtParCueDsc8_Jsonclick = "";
         edtParCueDsc8_Enabled = 0;
         edtParCue8_Jsonclick = "";
         edtParCue8_Enabled = 1;
         edtParCue7Tip_Jsonclick = "";
         edtParCue7Tip_Enabled = 1;
         edtParCueDsc7_Jsonclick = "";
         edtParCueDsc7_Enabled = 0;
         edtParCue7_Jsonclick = "";
         edtParCue7_Enabled = 1;
         edtParCue6Tip_Jsonclick = "";
         edtParCue6Tip_Enabled = 1;
         edtParCueDsc6_Jsonclick = "";
         edtParCueDsc6_Enabled = 0;
         edtParCue6_Jsonclick = "";
         edtParCue6_Enabled = 1;
         edtParCue5Tip_Jsonclick = "";
         edtParCue5Tip_Enabled = 1;
         edtParCueDsc5_Jsonclick = "";
         edtParCueDsc5_Enabled = 0;
         edtParCue5_Jsonclick = "";
         edtParCue5_Enabled = 1;
         edtParCue4Tip_Jsonclick = "";
         edtParCue4Tip_Enabled = 1;
         edtParCueDsc4_Jsonclick = "";
         edtParCueDsc4_Enabled = 0;
         edtParCue4_Jsonclick = "";
         edtParCue4_Enabled = 1;
         edtParCue3Tip_Jsonclick = "";
         edtParCue3Tip_Enabled = 1;
         edtParCueDsc3_Jsonclick = "";
         edtParCueDsc3_Enabled = 0;
         edtParCue3_Jsonclick = "";
         edtParCue3_Enabled = 1;
         edtParCue2Tip_Jsonclick = "";
         edtParCue2Tip_Enabled = 1;
         edtParCueDsc2_Jsonclick = "";
         edtParCueDsc2_Enabled = 0;
         edtParCue2_Jsonclick = "";
         edtParCue2_Enabled = 1;
         edtParCue1Tip_Jsonclick = "";
         edtParCue1Tip_Enabled = 1;
         edtParCueDsc1_Jsonclick = "";
         edtParCueDsc1_Enabled = 0;
         edtParCue1_Jsonclick = "";
         edtParCue1_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtParCod_Jsonclick = "";
         edtParCod_Enabled = 1;
         edtParTip_Jsonclick = "";
         edtParTip_Enabled = 1;
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
         /* Using cursor T001T51 */
         pr_default.execute(49, new Object[] {A83ParTip});
         if ( (pr_default.getStatus(49) == 101) )
         {
            GX_msglist.addItem("No existe 'Parametrización Cabecera'.", "ForeignKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(49);
         GX_FocusControl = edtParCue1_Internalname;
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

      public void Valid_Partip( )
      {
         /* Using cursor T001T51 */
         pr_default.execute(49, new Object[] {A83ParTip});
         if ( (pr_default.getStatus(49) == 101) )
         {
            GX_msglist.addItem("No existe 'Parametrización Cabecera'.", "ForeignKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
         }
         pr_default.close(49);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Parcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A94ParCue1", StringUtil.RTrim( A94ParCue1));
         AssignAttri("", false, "A1508ParCue1Tip", StringUtil.RTrim( A1508ParCue1Tip));
         AssignAttri("", false, "A95ParCue2", StringUtil.RTrim( A95ParCue2));
         AssignAttri("", false, "A1509ParCue2Tip", StringUtil.RTrim( A1509ParCue2Tip));
         AssignAttri("", false, "A96ParCue3", StringUtil.RTrim( A96ParCue3));
         AssignAttri("", false, "A1510ParCue3Tip", StringUtil.RTrim( A1510ParCue3Tip));
         AssignAttri("", false, "A97ParCue4", StringUtil.RTrim( A97ParCue4));
         AssignAttri("", false, "A1511ParCue4Tip", StringUtil.RTrim( A1511ParCue4Tip));
         AssignAttri("", false, "A98ParCue5", StringUtil.RTrim( A98ParCue5));
         AssignAttri("", false, "A1512ParCue5Tip", StringUtil.RTrim( A1512ParCue5Tip));
         AssignAttri("", false, "A99ParCue6", StringUtil.RTrim( A99ParCue6));
         AssignAttri("", false, "A1513ParCue6Tip", StringUtil.RTrim( A1513ParCue6Tip));
         AssignAttri("", false, "A100ParCue7", StringUtil.RTrim( A100ParCue7));
         AssignAttri("", false, "A1514ParCue7Tip", StringUtil.RTrim( A1514ParCue7Tip));
         AssignAttri("", false, "A101ParCue8", StringUtil.RTrim( A101ParCue8));
         AssignAttri("", false, "A1515ParCue8Tip", StringUtil.RTrim( A1515ParCue8Tip));
         AssignAttri("", false, "A102ParCue9", StringUtil.RTrim( A102ParCue9));
         AssignAttri("", false, "A1516ParCue9Tip", StringUtil.RTrim( A1516ParCue9Tip));
         AssignAttri("", false, "A103ParCue10", StringUtil.RTrim( A103ParCue10));
         AssignAttri("", false, "A1507ParCue10Tip", StringUtil.RTrim( A1507ParCue10Tip));
         AssignAttri("", false, "A93ParMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A93ParMonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A92ParTipCod", StringUtil.RTrim( A92ParTipCod));
         AssignAttri("", false, "A1542ParTitem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1542ParTitem), 4, 0, ".", "")));
         AssignAttri("", false, "A1540ParForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1540ParForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1517ParCueDsc1", StringUtil.RTrim( A1517ParCueDsc1));
         AssignAttri("", false, "A1519ParCueDsc2", StringUtil.RTrim( A1519ParCueDsc2));
         AssignAttri("", false, "A1520ParCueDsc3", StringUtil.RTrim( A1520ParCueDsc3));
         AssignAttri("", false, "A1521ParCueDsc4", StringUtil.RTrim( A1521ParCueDsc4));
         AssignAttri("", false, "A1522ParCueDsc5", StringUtil.RTrim( A1522ParCueDsc5));
         AssignAttri("", false, "A1523ParCueDsc6", StringUtil.RTrim( A1523ParCueDsc6));
         AssignAttri("", false, "A1524ParCueDsc7", StringUtil.RTrim( A1524ParCueDsc7));
         AssignAttri("", false, "A1525ParCueDsc8", StringUtil.RTrim( A1525ParCueDsc8));
         AssignAttri("", false, "A1526ParCueDsc9", StringUtil.RTrim( A1526ParCueDsc9));
         AssignAttri("", false, "A1518ParCueDsc10", StringUtil.RTrim( A1518ParCueDsc10));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z83ParTip", StringUtil.RTrim( Z83ParTip));
         GxWebStd.gx_hidden_field( context, "Z84ParCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84ParCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z94ParCue1", StringUtil.RTrim( Z94ParCue1));
         GxWebStd.gx_hidden_field( context, "Z1508ParCue1Tip", StringUtil.RTrim( Z1508ParCue1Tip));
         GxWebStd.gx_hidden_field( context, "Z95ParCue2", StringUtil.RTrim( Z95ParCue2));
         GxWebStd.gx_hidden_field( context, "Z1509ParCue2Tip", StringUtil.RTrim( Z1509ParCue2Tip));
         GxWebStd.gx_hidden_field( context, "Z96ParCue3", StringUtil.RTrim( Z96ParCue3));
         GxWebStd.gx_hidden_field( context, "Z1510ParCue3Tip", StringUtil.RTrim( Z1510ParCue3Tip));
         GxWebStd.gx_hidden_field( context, "Z97ParCue4", StringUtil.RTrim( Z97ParCue4));
         GxWebStd.gx_hidden_field( context, "Z1511ParCue4Tip", StringUtil.RTrim( Z1511ParCue4Tip));
         GxWebStd.gx_hidden_field( context, "Z98ParCue5", StringUtil.RTrim( Z98ParCue5));
         GxWebStd.gx_hidden_field( context, "Z1512ParCue5Tip", StringUtil.RTrim( Z1512ParCue5Tip));
         GxWebStd.gx_hidden_field( context, "Z99ParCue6", StringUtil.RTrim( Z99ParCue6));
         GxWebStd.gx_hidden_field( context, "Z1513ParCue6Tip", StringUtil.RTrim( Z1513ParCue6Tip));
         GxWebStd.gx_hidden_field( context, "Z100ParCue7", StringUtil.RTrim( Z100ParCue7));
         GxWebStd.gx_hidden_field( context, "Z1514ParCue7Tip", StringUtil.RTrim( Z1514ParCue7Tip));
         GxWebStd.gx_hidden_field( context, "Z101ParCue8", StringUtil.RTrim( Z101ParCue8));
         GxWebStd.gx_hidden_field( context, "Z1515ParCue8Tip", StringUtil.RTrim( Z1515ParCue8Tip));
         GxWebStd.gx_hidden_field( context, "Z102ParCue9", StringUtil.RTrim( Z102ParCue9));
         GxWebStd.gx_hidden_field( context, "Z1516ParCue9Tip", StringUtil.RTrim( Z1516ParCue9Tip));
         GxWebStd.gx_hidden_field( context, "Z103ParCue10", StringUtil.RTrim( Z103ParCue10));
         GxWebStd.gx_hidden_field( context, "Z1507ParCue10Tip", StringUtil.RTrim( Z1507ParCue10Tip));
         GxWebStd.gx_hidden_field( context, "Z93ParMonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z93ParMonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z92ParTipCod", StringUtil.RTrim( Z92ParTipCod));
         GxWebStd.gx_hidden_field( context, "Z1542ParTitem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1542ParTitem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1540ParForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1540ParForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1517ParCueDsc1", StringUtil.RTrim( Z1517ParCueDsc1));
         GxWebStd.gx_hidden_field( context, "Z1519ParCueDsc2", StringUtil.RTrim( Z1519ParCueDsc2));
         GxWebStd.gx_hidden_field( context, "Z1520ParCueDsc3", StringUtil.RTrim( Z1520ParCueDsc3));
         GxWebStd.gx_hidden_field( context, "Z1521ParCueDsc4", StringUtil.RTrim( Z1521ParCueDsc4));
         GxWebStd.gx_hidden_field( context, "Z1522ParCueDsc5", StringUtil.RTrim( Z1522ParCueDsc5));
         GxWebStd.gx_hidden_field( context, "Z1523ParCueDsc6", StringUtil.RTrim( Z1523ParCueDsc6));
         GxWebStd.gx_hidden_field( context, "Z1524ParCueDsc7", StringUtil.RTrim( Z1524ParCueDsc7));
         GxWebStd.gx_hidden_field( context, "Z1525ParCueDsc8", StringUtil.RTrim( Z1525ParCueDsc8));
         GxWebStd.gx_hidden_field( context, "Z1526ParCueDsc9", StringUtil.RTrim( Z1526ParCueDsc9));
         GxWebStd.gx_hidden_field( context, "Z1518ParCueDsc10", StringUtil.RTrim( Z1518ParCueDsc10));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Parcue1( )
      {
         n94ParCue1 = false;
         /* Using cursor T001T37 */
         pr_default.execute(35, new Object[] {n94ParCue1, A94ParCue1});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A94ParCue1)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE1");
               AnyError = 1;
               GX_FocusControl = edtParCue1_Internalname;
            }
         }
         A1517ParCueDsc1 = T001T37_A1517ParCueDsc1[0];
         pr_default.close(35);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1517ParCueDsc1", StringUtil.RTrim( A1517ParCueDsc1));
      }

      public void Valid_Parcue2( )
      {
         n95ParCue2 = false;
         /* Using cursor T001T38 */
         pr_default.execute(36, new Object[] {n95ParCue2, A95ParCue2});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A95ParCue2)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE2");
               AnyError = 1;
               GX_FocusControl = edtParCue2_Internalname;
            }
         }
         A1519ParCueDsc2 = T001T38_A1519ParCueDsc2[0];
         pr_default.close(36);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1519ParCueDsc2", StringUtil.RTrim( A1519ParCueDsc2));
      }

      public void Valid_Parcue3( )
      {
         n96ParCue3 = false;
         /* Using cursor T001T39 */
         pr_default.execute(37, new Object[] {n96ParCue3, A96ParCue3});
         if ( (pr_default.getStatus(37) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A96ParCue3)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE3");
               AnyError = 1;
               GX_FocusControl = edtParCue3_Internalname;
            }
         }
         A1520ParCueDsc3 = T001T39_A1520ParCueDsc3[0];
         pr_default.close(37);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1520ParCueDsc3", StringUtil.RTrim( A1520ParCueDsc3));
      }

      public void Valid_Parcue4( )
      {
         n97ParCue4 = false;
         /* Using cursor T001T40 */
         pr_default.execute(38, new Object[] {n97ParCue4, A97ParCue4});
         if ( (pr_default.getStatus(38) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A97ParCue4)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE4");
               AnyError = 1;
               GX_FocusControl = edtParCue4_Internalname;
            }
         }
         A1521ParCueDsc4 = T001T40_A1521ParCueDsc4[0];
         pr_default.close(38);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1521ParCueDsc4", StringUtil.RTrim( A1521ParCueDsc4));
      }

      public void Valid_Parcue5( )
      {
         n98ParCue5 = false;
         /* Using cursor T001T41 */
         pr_default.execute(39, new Object[] {n98ParCue5, A98ParCue5});
         if ( (pr_default.getStatus(39) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A98ParCue5)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE5");
               AnyError = 1;
               GX_FocusControl = edtParCue5_Internalname;
            }
         }
         A1522ParCueDsc5 = T001T41_A1522ParCueDsc5[0];
         pr_default.close(39);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1522ParCueDsc5", StringUtil.RTrim( A1522ParCueDsc5));
      }

      public void Valid_Parcue6( )
      {
         n99ParCue6 = false;
         /* Using cursor T001T42 */
         pr_default.execute(40, new Object[] {n99ParCue6, A99ParCue6});
         if ( (pr_default.getStatus(40) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A99ParCue6)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE6");
               AnyError = 1;
               GX_FocusControl = edtParCue6_Internalname;
            }
         }
         A1523ParCueDsc6 = T001T42_A1523ParCueDsc6[0];
         pr_default.close(40);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1523ParCueDsc6", StringUtil.RTrim( A1523ParCueDsc6));
      }

      public void Valid_Parcue7( )
      {
         n100ParCue7 = false;
         /* Using cursor T001T43 */
         pr_default.execute(41, new Object[] {n100ParCue7, A100ParCue7});
         if ( (pr_default.getStatus(41) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A100ParCue7)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE7");
               AnyError = 1;
               GX_FocusControl = edtParCue7_Internalname;
            }
         }
         A1524ParCueDsc7 = T001T43_A1524ParCueDsc7[0];
         pr_default.close(41);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1524ParCueDsc7", StringUtil.RTrim( A1524ParCueDsc7));
      }

      public void Valid_Parcue8( )
      {
         n101ParCue8 = false;
         /* Using cursor T001T44 */
         pr_default.execute(42, new Object[] {n101ParCue8, A101ParCue8});
         if ( (pr_default.getStatus(42) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A101ParCue8)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE8");
               AnyError = 1;
               GX_FocusControl = edtParCue8_Internalname;
            }
         }
         A1525ParCueDsc8 = T001T44_A1525ParCueDsc8[0];
         pr_default.close(42);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1525ParCueDsc8", StringUtil.RTrim( A1525ParCueDsc8));
      }

      public void Valid_Parcue9( )
      {
         n102ParCue9 = false;
         /* Using cursor T001T45 */
         pr_default.execute(43, new Object[] {n102ParCue9, A102ParCue9});
         if ( (pr_default.getStatus(43) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A102ParCue9)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE9");
               AnyError = 1;
               GX_FocusControl = edtParCue9_Internalname;
            }
         }
         A1526ParCueDsc9 = T001T45_A1526ParCueDsc9[0];
         pr_default.close(43);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1526ParCueDsc9", StringUtil.RTrim( A1526ParCueDsc9));
      }

      public void Valid_Parcue10( )
      {
         n103ParCue10 = false;
         /* Using cursor T001T46 */
         pr_default.execute(44, new Object[] {n103ParCue10, A103ParCue10});
         if ( (pr_default.getStatus(44) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A103ParCue10)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARCUE10");
               AnyError = 1;
               GX_FocusControl = edtParCue10_Internalname;
            }
         }
         A1518ParCueDsc10 = T001T46_A1518ParCueDsc10[0];
         pr_default.close(44);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1518ParCueDsc10", StringUtil.RTrim( A1518ParCueDsc10));
      }

      public void Valid_Parmoncod( )
      {
         /* Using cursor T001T52 */
         pr_default.execute(50, new Object[] {A93ParMonCod});
         if ( (pr_default.getStatus(50) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "PARMONCOD");
            AnyError = 1;
            GX_FocusControl = edtParMonCod_Internalname;
         }
         pr_default.close(50);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Partipcod( )
      {
         /* Using cursor T001T53 */
         pr_default.execute(51, new Object[] {A92ParTipCod});
         if ( (pr_default.getStatus(51) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipo de Documento'.", "ForeignKeyNotFound", 1, "PARTIPCOD");
            AnyError = 1;
            GX_FocusControl = edtParTipCod_Internalname;
         }
         pr_default.close(51);
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
         setEventMetadata("VALID_PARTIP","{handler:'Valid_Partip',iparms:[{av:'A83ParTip',fld:'PARTIP',pic:''}]");
         setEventMetadata("VALID_PARTIP",",oparms:[]}");
         setEventMetadata("VALID_PARCOD","{handler:'Valid_Parcod',iparms:[{av:'A83ParTip',fld:'PARTIP',pic:''},{av:'A84ParCod',fld:'PARCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PARCOD",",oparms:[{av:'A94ParCue1',fld:'PARCUE1',pic:''},{av:'A1508ParCue1Tip',fld:'PARCUE1TIP',pic:''},{av:'A95ParCue2',fld:'PARCUE2',pic:''},{av:'A1509ParCue2Tip',fld:'PARCUE2TIP',pic:''},{av:'A96ParCue3',fld:'PARCUE3',pic:''},{av:'A1510ParCue3Tip',fld:'PARCUE3TIP',pic:''},{av:'A97ParCue4',fld:'PARCUE4',pic:''},{av:'A1511ParCue4Tip',fld:'PARCUE4TIP',pic:''},{av:'A98ParCue5',fld:'PARCUE5',pic:''},{av:'A1512ParCue5Tip',fld:'PARCUE5TIP',pic:''},{av:'A99ParCue6',fld:'PARCUE6',pic:''},{av:'A1513ParCue6Tip',fld:'PARCUE6TIP',pic:''},{av:'A100ParCue7',fld:'PARCUE7',pic:''},{av:'A1514ParCue7Tip',fld:'PARCUE7TIP',pic:''},{av:'A101ParCue8',fld:'PARCUE8',pic:''},{av:'A1515ParCue8Tip',fld:'PARCUE8TIP',pic:''},{av:'A102ParCue9',fld:'PARCUE9',pic:''},{av:'A1516ParCue9Tip',fld:'PARCUE9TIP',pic:''},{av:'A103ParCue10',fld:'PARCUE10',pic:''},{av:'A1507ParCue10Tip',fld:'PARCUE10TIP',pic:''},{av:'A93ParMonCod',fld:'PARMONCOD',pic:'ZZZZZ9'},{av:'A92ParTipCod',fld:'PARTIPCOD',pic:''},{av:'A1542ParTitem',fld:'PARTITEM',pic:'ZZZ9'},{av:'A1540ParForCod',fld:'PARFORCOD',pic:'ZZZZZ9'},{av:'A1517ParCueDsc1',fld:'PARCUEDSC1',pic:''},{av:'A1519ParCueDsc2',fld:'PARCUEDSC2',pic:''},{av:'A1520ParCueDsc3',fld:'PARCUEDSC3',pic:''},{av:'A1521ParCueDsc4',fld:'PARCUEDSC4',pic:''},{av:'A1522ParCueDsc5',fld:'PARCUEDSC5',pic:''},{av:'A1523ParCueDsc6',fld:'PARCUEDSC6',pic:''},{av:'A1524ParCueDsc7',fld:'PARCUEDSC7',pic:''},{av:'A1525ParCueDsc8',fld:'PARCUEDSC8',pic:''},{av:'A1526ParCueDsc9',fld:'PARCUEDSC9',pic:''},{av:'A1518ParCueDsc10',fld:'PARCUEDSC10',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83ParTip'},{av:'Z84ParCod'},{av:'Z94ParCue1'},{av:'Z1508ParCue1Tip'},{av:'Z95ParCue2'},{av:'Z1509ParCue2Tip'},{av:'Z96ParCue3'},{av:'Z1510ParCue3Tip'},{av:'Z97ParCue4'},{av:'Z1511ParCue4Tip'},{av:'Z98ParCue5'},{av:'Z1512ParCue5Tip'},{av:'Z99ParCue6'},{av:'Z1513ParCue6Tip'},{av:'Z100ParCue7'},{av:'Z1514ParCue7Tip'},{av:'Z101ParCue8'},{av:'Z1515ParCue8Tip'},{av:'Z102ParCue9'},{av:'Z1516ParCue9Tip'},{av:'Z103ParCue10'},{av:'Z1507ParCue10Tip'},{av:'Z93ParMonCod'},{av:'Z92ParTipCod'},{av:'Z1542ParTitem'},{av:'Z1540ParForCod'},{av:'Z1517ParCueDsc1'},{av:'Z1519ParCueDsc2'},{av:'Z1520ParCueDsc3'},{av:'Z1521ParCueDsc4'},{av:'Z1522ParCueDsc5'},{av:'Z1523ParCueDsc6'},{av:'Z1524ParCueDsc7'},{av:'Z1525ParCueDsc8'},{av:'Z1526ParCueDsc9'},{av:'Z1518ParCueDsc10'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PARCUE1","{handler:'Valid_Parcue1',iparms:[{av:'A94ParCue1',fld:'PARCUE1',pic:''},{av:'A1517ParCueDsc1',fld:'PARCUEDSC1',pic:''}]");
         setEventMetadata("VALID_PARCUE1",",oparms:[{av:'A1517ParCueDsc1',fld:'PARCUEDSC1',pic:''}]}");
         setEventMetadata("VALID_PARCUE2","{handler:'Valid_Parcue2',iparms:[{av:'A95ParCue2',fld:'PARCUE2',pic:''},{av:'A1519ParCueDsc2',fld:'PARCUEDSC2',pic:''}]");
         setEventMetadata("VALID_PARCUE2",",oparms:[{av:'A1519ParCueDsc2',fld:'PARCUEDSC2',pic:''}]}");
         setEventMetadata("VALID_PARCUE3","{handler:'Valid_Parcue3',iparms:[{av:'A96ParCue3',fld:'PARCUE3',pic:''},{av:'A1520ParCueDsc3',fld:'PARCUEDSC3',pic:''}]");
         setEventMetadata("VALID_PARCUE3",",oparms:[{av:'A1520ParCueDsc3',fld:'PARCUEDSC3',pic:''}]}");
         setEventMetadata("VALID_PARCUE4","{handler:'Valid_Parcue4',iparms:[{av:'A97ParCue4',fld:'PARCUE4',pic:''},{av:'A1521ParCueDsc4',fld:'PARCUEDSC4',pic:''}]");
         setEventMetadata("VALID_PARCUE4",",oparms:[{av:'A1521ParCueDsc4',fld:'PARCUEDSC4',pic:''}]}");
         setEventMetadata("VALID_PARCUE5","{handler:'Valid_Parcue5',iparms:[{av:'A98ParCue5',fld:'PARCUE5',pic:''},{av:'A1522ParCueDsc5',fld:'PARCUEDSC5',pic:''}]");
         setEventMetadata("VALID_PARCUE5",",oparms:[{av:'A1522ParCueDsc5',fld:'PARCUEDSC5',pic:''}]}");
         setEventMetadata("VALID_PARCUE6","{handler:'Valid_Parcue6',iparms:[{av:'A99ParCue6',fld:'PARCUE6',pic:''},{av:'A1523ParCueDsc6',fld:'PARCUEDSC6',pic:''}]");
         setEventMetadata("VALID_PARCUE6",",oparms:[{av:'A1523ParCueDsc6',fld:'PARCUEDSC6',pic:''}]}");
         setEventMetadata("VALID_PARCUE7","{handler:'Valid_Parcue7',iparms:[{av:'A100ParCue7',fld:'PARCUE7',pic:''},{av:'A1524ParCueDsc7',fld:'PARCUEDSC7',pic:''}]");
         setEventMetadata("VALID_PARCUE7",",oparms:[{av:'A1524ParCueDsc7',fld:'PARCUEDSC7',pic:''}]}");
         setEventMetadata("VALID_PARCUE8","{handler:'Valid_Parcue8',iparms:[{av:'A101ParCue8',fld:'PARCUE8',pic:''},{av:'A1525ParCueDsc8',fld:'PARCUEDSC8',pic:''}]");
         setEventMetadata("VALID_PARCUE8",",oparms:[{av:'A1525ParCueDsc8',fld:'PARCUEDSC8',pic:''}]}");
         setEventMetadata("VALID_PARCUE9","{handler:'Valid_Parcue9',iparms:[{av:'A102ParCue9',fld:'PARCUE9',pic:''},{av:'A1526ParCueDsc9',fld:'PARCUEDSC9',pic:''}]");
         setEventMetadata("VALID_PARCUE9",",oparms:[{av:'A1526ParCueDsc9',fld:'PARCUEDSC9',pic:''}]}");
         setEventMetadata("VALID_PARCUE10","{handler:'Valid_Parcue10',iparms:[{av:'A103ParCue10',fld:'PARCUE10',pic:''},{av:'A1518ParCueDsc10',fld:'PARCUEDSC10',pic:''}]");
         setEventMetadata("VALID_PARCUE10",",oparms:[{av:'A1518ParCueDsc10',fld:'PARCUEDSC10',pic:''}]}");
         setEventMetadata("VALID_PARMONCOD","{handler:'Valid_Parmoncod',iparms:[{av:'A93ParMonCod',fld:'PARMONCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PARMONCOD",",oparms:[]}");
         setEventMetadata("VALID_PARTIPCOD","{handler:'Valid_Partipcod',iparms:[{av:'A92ParTipCod',fld:'PARTIPCOD',pic:''}]");
         setEventMetadata("VALID_PARTIPCOD",",oparms:[]}");
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
         pr_default.close(49);
         pr_default.close(35);
         pr_default.close(36);
         pr_default.close(37);
         pr_default.close(38);
         pr_default.close(39);
         pr_default.close(40);
         pr_default.close(41);
         pr_default.close(42);
         pr_default.close(43);
         pr_default.close(44);
         pr_default.close(50);
         pr_default.close(51);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z83ParTip = "";
         Z1508ParCue1Tip = "";
         Z1509ParCue2Tip = "";
         Z1510ParCue3Tip = "";
         Z1511ParCue4Tip = "";
         Z1512ParCue5Tip = "";
         Z1513ParCue6Tip = "";
         Z1514ParCue7Tip = "";
         Z1515ParCue8Tip = "";
         Z1516ParCue9Tip = "";
         Z1507ParCue10Tip = "";
         Z94ParCue1 = "";
         Z95ParCue2 = "";
         Z96ParCue3 = "";
         Z97ParCue4 = "";
         Z98ParCue5 = "";
         Z99ParCue6 = "";
         Z100ParCue7 = "";
         Z101ParCue8 = "";
         Z102ParCue9 = "";
         Z103ParCue10 = "";
         Z92ParTipCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A83ParTip = "";
         A94ParCue1 = "";
         A95ParCue2 = "";
         A96ParCue3 = "";
         A97ParCue4 = "";
         A98ParCue5 = "";
         A99ParCue6 = "";
         A100ParCue7 = "";
         A101ParCue8 = "";
         A102ParCue9 = "";
         A103ParCue10 = "";
         A92ParTipCod = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A1517ParCueDsc1 = "";
         lblTextblock5_Jsonclick = "";
         A1508ParCue1Tip = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1519ParCueDsc2 = "";
         lblTextblock8_Jsonclick = "";
         A1509ParCue2Tip = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A1520ParCueDsc3 = "";
         lblTextblock11_Jsonclick = "";
         A1510ParCue3Tip = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         A1521ParCueDsc4 = "";
         lblTextblock14_Jsonclick = "";
         A1511ParCue4Tip = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         A1522ParCueDsc5 = "";
         lblTextblock17_Jsonclick = "";
         A1512ParCue5Tip = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         A1523ParCueDsc6 = "";
         lblTextblock20_Jsonclick = "";
         A1513ParCue6Tip = "";
         lblTextblock21_Jsonclick = "";
         lblTextblock22_Jsonclick = "";
         A1524ParCueDsc7 = "";
         lblTextblock23_Jsonclick = "";
         A1514ParCue7Tip = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         A1525ParCueDsc8 = "";
         lblTextblock26_Jsonclick = "";
         A1515ParCue8Tip = "";
         lblTextblock27_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         A1526ParCueDsc9 = "";
         lblTextblock29_Jsonclick = "";
         A1516ParCue9Tip = "";
         lblTextblock30_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         A1518ParCueDsc10 = "";
         lblTextblock32_Jsonclick = "";
         A1507ParCue10Tip = "";
         lblTextblock33_Jsonclick = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         lblTextblock36_Jsonclick = "";
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
         Z1517ParCueDsc1 = "";
         Z1519ParCueDsc2 = "";
         Z1520ParCueDsc3 = "";
         Z1521ParCueDsc4 = "";
         Z1522ParCueDsc5 = "";
         Z1523ParCueDsc6 = "";
         Z1524ParCueDsc7 = "";
         Z1525ParCueDsc8 = "";
         Z1526ParCueDsc9 = "";
         Z1518ParCueDsc10 = "";
         T001T17_A84ParCod = new int[1] ;
         T001T17_A1517ParCueDsc1 = new string[] {""} ;
         T001T17_A1508ParCue1Tip = new string[] {""} ;
         T001T17_A1519ParCueDsc2 = new string[] {""} ;
         T001T17_A1509ParCue2Tip = new string[] {""} ;
         T001T17_A1520ParCueDsc3 = new string[] {""} ;
         T001T17_A1510ParCue3Tip = new string[] {""} ;
         T001T17_A1521ParCueDsc4 = new string[] {""} ;
         T001T17_A1511ParCue4Tip = new string[] {""} ;
         T001T17_A1522ParCueDsc5 = new string[] {""} ;
         T001T17_A1512ParCue5Tip = new string[] {""} ;
         T001T17_A1523ParCueDsc6 = new string[] {""} ;
         T001T17_A1513ParCue6Tip = new string[] {""} ;
         T001T17_A1524ParCueDsc7 = new string[] {""} ;
         T001T17_A1514ParCue7Tip = new string[] {""} ;
         T001T17_A1525ParCueDsc8 = new string[] {""} ;
         T001T17_A1515ParCue8Tip = new string[] {""} ;
         T001T17_A1526ParCueDsc9 = new string[] {""} ;
         T001T17_A1516ParCue9Tip = new string[] {""} ;
         T001T17_A1518ParCueDsc10 = new string[] {""} ;
         T001T17_A1507ParCue10Tip = new string[] {""} ;
         T001T17_A1542ParTitem = new short[1] ;
         T001T17_A1540ParForCod = new int[1] ;
         T001T17_A83ParTip = new string[] {""} ;
         T001T17_A94ParCue1 = new string[] {""} ;
         T001T17_n94ParCue1 = new bool[] {false} ;
         T001T17_A95ParCue2 = new string[] {""} ;
         T001T17_n95ParCue2 = new bool[] {false} ;
         T001T17_A96ParCue3 = new string[] {""} ;
         T001T17_n96ParCue3 = new bool[] {false} ;
         T001T17_A97ParCue4 = new string[] {""} ;
         T001T17_n97ParCue4 = new bool[] {false} ;
         T001T17_A98ParCue5 = new string[] {""} ;
         T001T17_n98ParCue5 = new bool[] {false} ;
         T001T17_A99ParCue6 = new string[] {""} ;
         T001T17_n99ParCue6 = new bool[] {false} ;
         T001T17_A100ParCue7 = new string[] {""} ;
         T001T17_n100ParCue7 = new bool[] {false} ;
         T001T17_A101ParCue8 = new string[] {""} ;
         T001T17_n101ParCue8 = new bool[] {false} ;
         T001T17_A102ParCue9 = new string[] {""} ;
         T001T17_n102ParCue9 = new bool[] {false} ;
         T001T17_A103ParCue10 = new string[] {""} ;
         T001T17_n103ParCue10 = new bool[] {false} ;
         T001T17_A93ParMonCod = new int[1] ;
         T001T17_A92ParTipCod = new string[] {""} ;
         T001T4_A83ParTip = new string[] {""} ;
         T001T5_A1517ParCueDsc1 = new string[] {""} ;
         T001T6_A1519ParCueDsc2 = new string[] {""} ;
         T001T7_A1520ParCueDsc3 = new string[] {""} ;
         T001T8_A1521ParCueDsc4 = new string[] {""} ;
         T001T9_A1522ParCueDsc5 = new string[] {""} ;
         T001T10_A1523ParCueDsc6 = new string[] {""} ;
         T001T11_A1524ParCueDsc7 = new string[] {""} ;
         T001T12_A1525ParCueDsc8 = new string[] {""} ;
         T001T13_A1526ParCueDsc9 = new string[] {""} ;
         T001T14_A1518ParCueDsc10 = new string[] {""} ;
         T001T15_A93ParMonCod = new int[1] ;
         T001T16_A92ParTipCod = new string[] {""} ;
         T001T18_A83ParTip = new string[] {""} ;
         T001T19_A1517ParCueDsc1 = new string[] {""} ;
         T001T20_A1519ParCueDsc2 = new string[] {""} ;
         T001T21_A1520ParCueDsc3 = new string[] {""} ;
         T001T22_A1521ParCueDsc4 = new string[] {""} ;
         T001T23_A1522ParCueDsc5 = new string[] {""} ;
         T001T24_A1523ParCueDsc6 = new string[] {""} ;
         T001T25_A1524ParCueDsc7 = new string[] {""} ;
         T001T26_A1525ParCueDsc8 = new string[] {""} ;
         T001T27_A1526ParCueDsc9 = new string[] {""} ;
         T001T28_A1518ParCueDsc10 = new string[] {""} ;
         T001T29_A93ParMonCod = new int[1] ;
         T001T30_A92ParTipCod = new string[] {""} ;
         T001T31_A83ParTip = new string[] {""} ;
         T001T31_A84ParCod = new int[1] ;
         T001T3_A84ParCod = new int[1] ;
         T001T3_A1508ParCue1Tip = new string[] {""} ;
         T001T3_A1509ParCue2Tip = new string[] {""} ;
         T001T3_A1510ParCue3Tip = new string[] {""} ;
         T001T3_A1511ParCue4Tip = new string[] {""} ;
         T001T3_A1512ParCue5Tip = new string[] {""} ;
         T001T3_A1513ParCue6Tip = new string[] {""} ;
         T001T3_A1514ParCue7Tip = new string[] {""} ;
         T001T3_A1515ParCue8Tip = new string[] {""} ;
         T001T3_A1516ParCue9Tip = new string[] {""} ;
         T001T3_A1507ParCue10Tip = new string[] {""} ;
         T001T3_A1542ParTitem = new short[1] ;
         T001T3_A1540ParForCod = new int[1] ;
         T001T3_A83ParTip = new string[] {""} ;
         T001T3_A94ParCue1 = new string[] {""} ;
         T001T3_n94ParCue1 = new bool[] {false} ;
         T001T3_A95ParCue2 = new string[] {""} ;
         T001T3_n95ParCue2 = new bool[] {false} ;
         T001T3_A96ParCue3 = new string[] {""} ;
         T001T3_n96ParCue3 = new bool[] {false} ;
         T001T3_A97ParCue4 = new string[] {""} ;
         T001T3_n97ParCue4 = new bool[] {false} ;
         T001T3_A98ParCue5 = new string[] {""} ;
         T001T3_n98ParCue5 = new bool[] {false} ;
         T001T3_A99ParCue6 = new string[] {""} ;
         T001T3_n99ParCue6 = new bool[] {false} ;
         T001T3_A100ParCue7 = new string[] {""} ;
         T001T3_n100ParCue7 = new bool[] {false} ;
         T001T3_A101ParCue8 = new string[] {""} ;
         T001T3_n101ParCue8 = new bool[] {false} ;
         T001T3_A102ParCue9 = new string[] {""} ;
         T001T3_n102ParCue9 = new bool[] {false} ;
         T001T3_A103ParCue10 = new string[] {""} ;
         T001T3_n103ParCue10 = new bool[] {false} ;
         T001T3_A93ParMonCod = new int[1] ;
         T001T3_A92ParTipCod = new string[] {""} ;
         sMode62 = "";
         T001T32_A83ParTip = new string[] {""} ;
         T001T32_A84ParCod = new int[1] ;
         T001T33_A83ParTip = new string[] {""} ;
         T001T33_A84ParCod = new int[1] ;
         T001T2_A84ParCod = new int[1] ;
         T001T2_A1508ParCue1Tip = new string[] {""} ;
         T001T2_A1509ParCue2Tip = new string[] {""} ;
         T001T2_A1510ParCue3Tip = new string[] {""} ;
         T001T2_A1511ParCue4Tip = new string[] {""} ;
         T001T2_A1512ParCue5Tip = new string[] {""} ;
         T001T2_A1513ParCue6Tip = new string[] {""} ;
         T001T2_A1514ParCue7Tip = new string[] {""} ;
         T001T2_A1515ParCue8Tip = new string[] {""} ;
         T001T2_A1516ParCue9Tip = new string[] {""} ;
         T001T2_A1507ParCue10Tip = new string[] {""} ;
         T001T2_A1542ParTitem = new short[1] ;
         T001T2_A1540ParForCod = new int[1] ;
         T001T2_A83ParTip = new string[] {""} ;
         T001T2_A94ParCue1 = new string[] {""} ;
         T001T2_n94ParCue1 = new bool[] {false} ;
         T001T2_A95ParCue2 = new string[] {""} ;
         T001T2_n95ParCue2 = new bool[] {false} ;
         T001T2_A96ParCue3 = new string[] {""} ;
         T001T2_n96ParCue3 = new bool[] {false} ;
         T001T2_A97ParCue4 = new string[] {""} ;
         T001T2_n97ParCue4 = new bool[] {false} ;
         T001T2_A98ParCue5 = new string[] {""} ;
         T001T2_n98ParCue5 = new bool[] {false} ;
         T001T2_A99ParCue6 = new string[] {""} ;
         T001T2_n99ParCue6 = new bool[] {false} ;
         T001T2_A100ParCue7 = new string[] {""} ;
         T001T2_n100ParCue7 = new bool[] {false} ;
         T001T2_A101ParCue8 = new string[] {""} ;
         T001T2_n101ParCue8 = new bool[] {false} ;
         T001T2_A102ParCue9 = new string[] {""} ;
         T001T2_n102ParCue9 = new bool[] {false} ;
         T001T2_A103ParCue10 = new string[] {""} ;
         T001T2_n103ParCue10 = new bool[] {false} ;
         T001T2_A93ParMonCod = new int[1] ;
         T001T2_A92ParTipCod = new string[] {""} ;
         T001T37_A1517ParCueDsc1 = new string[] {""} ;
         T001T38_A1519ParCueDsc2 = new string[] {""} ;
         T001T39_A1520ParCueDsc3 = new string[] {""} ;
         T001T40_A1521ParCueDsc4 = new string[] {""} ;
         T001T41_A1522ParCueDsc5 = new string[] {""} ;
         T001T42_A1523ParCueDsc6 = new string[] {""} ;
         T001T43_A1524ParCueDsc7 = new string[] {""} ;
         T001T44_A1525ParCueDsc8 = new string[] {""} ;
         T001T45_A1526ParCueDsc9 = new string[] {""} ;
         T001T46_A1518ParCueDsc10 = new string[] {""} ;
         T001T47_A83ParTip = new string[] {""} ;
         T001T47_A84ParCod = new int[1] ;
         T001T47_A90ParDTipItem = new int[1] ;
         T001T48_A83ParTip = new string[] {""} ;
         T001T48_A84ParCod = new int[1] ;
         T001T48_A104ParDItem = new short[1] ;
         T001T49_A83ParTip = new string[] {""} ;
         T001T49_A84ParCod = new int[1] ;
         T001T49_A85ParDActItem = new int[1] ;
         T001T50_A83ParTip = new string[] {""} ;
         T001T50_A84ParCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001T51_A83ParTip = new string[] {""} ;
         ZZ83ParTip = "";
         ZZ94ParCue1 = "";
         ZZ1508ParCue1Tip = "";
         ZZ95ParCue2 = "";
         ZZ1509ParCue2Tip = "";
         ZZ96ParCue3 = "";
         ZZ1510ParCue3Tip = "";
         ZZ97ParCue4 = "";
         ZZ1511ParCue4Tip = "";
         ZZ98ParCue5 = "";
         ZZ1512ParCue5Tip = "";
         ZZ99ParCue6 = "";
         ZZ1513ParCue6Tip = "";
         ZZ100ParCue7 = "";
         ZZ1514ParCue7Tip = "";
         ZZ101ParCue8 = "";
         ZZ1515ParCue8Tip = "";
         ZZ102ParCue9 = "";
         ZZ1516ParCue9Tip = "";
         ZZ103ParCue10 = "";
         ZZ1507ParCue10Tip = "";
         ZZ92ParTipCod = "";
         ZZ1517ParCueDsc1 = "";
         ZZ1519ParCueDsc2 = "";
         ZZ1520ParCueDsc3 = "";
         ZZ1521ParCueDsc4 = "";
         ZZ1522ParCueDsc5 = "";
         ZZ1523ParCueDsc6 = "";
         ZZ1524ParCueDsc7 = "";
         ZZ1525ParCueDsc8 = "";
         ZZ1526ParCueDsc9 = "";
         ZZ1518ParCueDsc10 = "";
         T001T52_A93ParMonCod = new int[1] ;
         T001T53_A92ParTipCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbparamdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbparamdet__default(),
            new Object[][] {
                new Object[] {
               T001T2_A84ParCod, T001T2_A1508ParCue1Tip, T001T2_A1509ParCue2Tip, T001T2_A1510ParCue3Tip, T001T2_A1511ParCue4Tip, T001T2_A1512ParCue5Tip, T001T2_A1513ParCue6Tip, T001T2_A1514ParCue7Tip, T001T2_A1515ParCue8Tip, T001T2_A1516ParCue9Tip,
               T001T2_A1507ParCue10Tip, T001T2_A1542ParTitem, T001T2_A1540ParForCod, T001T2_A83ParTip, T001T2_A94ParCue1, T001T2_n94ParCue1, T001T2_A95ParCue2, T001T2_n95ParCue2, T001T2_A96ParCue3, T001T2_n96ParCue3,
               T001T2_A97ParCue4, T001T2_n97ParCue4, T001T2_A98ParCue5, T001T2_n98ParCue5, T001T2_A99ParCue6, T001T2_n99ParCue6, T001T2_A100ParCue7, T001T2_n100ParCue7, T001T2_A101ParCue8, T001T2_n101ParCue8,
               T001T2_A102ParCue9, T001T2_n102ParCue9, T001T2_A103ParCue10, T001T2_n103ParCue10, T001T2_A93ParMonCod, T001T2_A92ParTipCod
               }
               , new Object[] {
               T001T3_A84ParCod, T001T3_A1508ParCue1Tip, T001T3_A1509ParCue2Tip, T001T3_A1510ParCue3Tip, T001T3_A1511ParCue4Tip, T001T3_A1512ParCue5Tip, T001T3_A1513ParCue6Tip, T001T3_A1514ParCue7Tip, T001T3_A1515ParCue8Tip, T001T3_A1516ParCue9Tip,
               T001T3_A1507ParCue10Tip, T001T3_A1542ParTitem, T001T3_A1540ParForCod, T001T3_A83ParTip, T001T3_A94ParCue1, T001T3_n94ParCue1, T001T3_A95ParCue2, T001T3_n95ParCue2, T001T3_A96ParCue3, T001T3_n96ParCue3,
               T001T3_A97ParCue4, T001T3_n97ParCue4, T001T3_A98ParCue5, T001T3_n98ParCue5, T001T3_A99ParCue6, T001T3_n99ParCue6, T001T3_A100ParCue7, T001T3_n100ParCue7, T001T3_A101ParCue8, T001T3_n101ParCue8,
               T001T3_A102ParCue9, T001T3_n102ParCue9, T001T3_A103ParCue10, T001T3_n103ParCue10, T001T3_A93ParMonCod, T001T3_A92ParTipCod
               }
               , new Object[] {
               T001T4_A83ParTip
               }
               , new Object[] {
               T001T5_A1517ParCueDsc1
               }
               , new Object[] {
               T001T6_A1519ParCueDsc2
               }
               , new Object[] {
               T001T7_A1520ParCueDsc3
               }
               , new Object[] {
               T001T8_A1521ParCueDsc4
               }
               , new Object[] {
               T001T9_A1522ParCueDsc5
               }
               , new Object[] {
               T001T10_A1523ParCueDsc6
               }
               , new Object[] {
               T001T11_A1524ParCueDsc7
               }
               , new Object[] {
               T001T12_A1525ParCueDsc8
               }
               , new Object[] {
               T001T13_A1526ParCueDsc9
               }
               , new Object[] {
               T001T14_A1518ParCueDsc10
               }
               , new Object[] {
               T001T15_A93ParMonCod
               }
               , new Object[] {
               T001T16_A92ParTipCod
               }
               , new Object[] {
               T001T17_A84ParCod, T001T17_A1517ParCueDsc1, T001T17_A1508ParCue1Tip, T001T17_A1519ParCueDsc2, T001T17_A1509ParCue2Tip, T001T17_A1520ParCueDsc3, T001T17_A1510ParCue3Tip, T001T17_A1521ParCueDsc4, T001T17_A1511ParCue4Tip, T001T17_A1522ParCueDsc5,
               T001T17_A1512ParCue5Tip, T001T17_A1523ParCueDsc6, T001T17_A1513ParCue6Tip, T001T17_A1524ParCueDsc7, T001T17_A1514ParCue7Tip, T001T17_A1525ParCueDsc8, T001T17_A1515ParCue8Tip, T001T17_A1526ParCueDsc9, T001T17_A1516ParCue9Tip, T001T17_A1518ParCueDsc10,
               T001T17_A1507ParCue10Tip, T001T17_A1542ParTitem, T001T17_A1540ParForCod, T001T17_A83ParTip, T001T17_A94ParCue1, T001T17_n94ParCue1, T001T17_A95ParCue2, T001T17_n95ParCue2, T001T17_A96ParCue3, T001T17_n96ParCue3,
               T001T17_A97ParCue4, T001T17_n97ParCue4, T001T17_A98ParCue5, T001T17_n98ParCue5, T001T17_A99ParCue6, T001T17_n99ParCue6, T001T17_A100ParCue7, T001T17_n100ParCue7, T001T17_A101ParCue8, T001T17_n101ParCue8,
               T001T17_A102ParCue9, T001T17_n102ParCue9, T001T17_A103ParCue10, T001T17_n103ParCue10, T001T17_A93ParMonCod, T001T17_A92ParTipCod
               }
               , new Object[] {
               T001T18_A83ParTip
               }
               , new Object[] {
               T001T19_A1517ParCueDsc1
               }
               , new Object[] {
               T001T20_A1519ParCueDsc2
               }
               , new Object[] {
               T001T21_A1520ParCueDsc3
               }
               , new Object[] {
               T001T22_A1521ParCueDsc4
               }
               , new Object[] {
               T001T23_A1522ParCueDsc5
               }
               , new Object[] {
               T001T24_A1523ParCueDsc6
               }
               , new Object[] {
               T001T25_A1524ParCueDsc7
               }
               , new Object[] {
               T001T26_A1525ParCueDsc8
               }
               , new Object[] {
               T001T27_A1526ParCueDsc9
               }
               , new Object[] {
               T001T28_A1518ParCueDsc10
               }
               , new Object[] {
               T001T29_A93ParMonCod
               }
               , new Object[] {
               T001T30_A92ParTipCod
               }
               , new Object[] {
               T001T31_A83ParTip, T001T31_A84ParCod
               }
               , new Object[] {
               T001T32_A83ParTip, T001T32_A84ParCod
               }
               , new Object[] {
               T001T33_A83ParTip, T001T33_A84ParCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001T37_A1517ParCueDsc1
               }
               , new Object[] {
               T001T38_A1519ParCueDsc2
               }
               , new Object[] {
               T001T39_A1520ParCueDsc3
               }
               , new Object[] {
               T001T40_A1521ParCueDsc4
               }
               , new Object[] {
               T001T41_A1522ParCueDsc5
               }
               , new Object[] {
               T001T42_A1523ParCueDsc6
               }
               , new Object[] {
               T001T43_A1524ParCueDsc7
               }
               , new Object[] {
               T001T44_A1525ParCueDsc8
               }
               , new Object[] {
               T001T45_A1526ParCueDsc9
               }
               , new Object[] {
               T001T46_A1518ParCueDsc10
               }
               , new Object[] {
               T001T47_A83ParTip, T001T47_A84ParCod, T001T47_A90ParDTipItem
               }
               , new Object[] {
               T001T48_A83ParTip, T001T48_A84ParCod, T001T48_A104ParDItem
               }
               , new Object[] {
               T001T49_A83ParTip, T001T49_A84ParCod, T001T49_A85ParDActItem
               }
               , new Object[] {
               T001T50_A83ParTip, T001T50_A84ParCod
               }
               , new Object[] {
               T001T51_A83ParTip
               }
               , new Object[] {
               T001T52_A93ParMonCod
               }
               , new Object[] {
               T001T53_A92ParTipCod
               }
            }
         );
      }

      private short Z1542ParTitem ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1542ParTitem ;
      private short GX_JID ;
      private short RcdFound62 ;
      private short nIsDirty_62 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1542ParTitem ;
      private int Z84ParCod ;
      private int Z1540ParForCod ;
      private int Z93ParMonCod ;
      private int A93ParMonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtParTip_Enabled ;
      private int A84ParCod ;
      private int edtParCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtParCue1_Enabled ;
      private int edtParCueDsc1_Enabled ;
      private int edtParCue1Tip_Enabled ;
      private int edtParCue2_Enabled ;
      private int edtParCueDsc2_Enabled ;
      private int edtParCue2Tip_Enabled ;
      private int edtParCue3_Enabled ;
      private int edtParCueDsc3_Enabled ;
      private int edtParCue3Tip_Enabled ;
      private int edtParCue4_Enabled ;
      private int edtParCueDsc4_Enabled ;
      private int edtParCue4Tip_Enabled ;
      private int edtParCue5_Enabled ;
      private int edtParCueDsc5_Enabled ;
      private int edtParCue5Tip_Enabled ;
      private int edtParCue6_Enabled ;
      private int edtParCueDsc6_Enabled ;
      private int edtParCue6Tip_Enabled ;
      private int edtParCue7_Enabled ;
      private int edtParCueDsc7_Enabled ;
      private int edtParCue7Tip_Enabled ;
      private int edtParCue8_Enabled ;
      private int edtParCueDsc8_Enabled ;
      private int edtParCue8Tip_Enabled ;
      private int edtParCue9_Enabled ;
      private int edtParCueDsc9_Enabled ;
      private int edtParCue9Tip_Enabled ;
      private int edtParCue10_Enabled ;
      private int edtParCueDsc10_Enabled ;
      private int edtParCue10Tip_Enabled ;
      private int edtParMonCod_Enabled ;
      private int edtParTipCod_Enabled ;
      private int edtParTitem_Enabled ;
      private int A1540ParForCod ;
      private int edtParForCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ84ParCod ;
      private int ZZ93ParMonCod ;
      private int ZZ1540ParForCod ;
      private string sPrefix ;
      private string Z83ParTip ;
      private string Z1508ParCue1Tip ;
      private string Z1509ParCue2Tip ;
      private string Z1510ParCue3Tip ;
      private string Z1511ParCue4Tip ;
      private string Z1512ParCue5Tip ;
      private string Z1513ParCue6Tip ;
      private string Z1514ParCue7Tip ;
      private string Z1515ParCue8Tip ;
      private string Z1516ParCue9Tip ;
      private string Z1507ParCue10Tip ;
      private string Z94ParCue1 ;
      private string Z95ParCue2 ;
      private string Z96ParCue3 ;
      private string Z97ParCue4 ;
      private string Z98ParCue5 ;
      private string Z99ParCue6 ;
      private string Z100ParCue7 ;
      private string Z101ParCue8 ;
      private string Z102ParCue9 ;
      private string Z103ParCue10 ;
      private string Z92ParTipCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A83ParTip ;
      private string A94ParCue1 ;
      private string A95ParCue2 ;
      private string A96ParCue3 ;
      private string A97ParCue4 ;
      private string A98ParCue5 ;
      private string A99ParCue6 ;
      private string A100ParCue7 ;
      private string A101ParCue8 ;
      private string A102ParCue9 ;
      private string A103ParCue10 ;
      private string A92ParTipCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtParTip_Internalname ;
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
      private string edtParTip_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtParCod_Internalname ;
      private string edtParCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtParCue1_Internalname ;
      private string edtParCue1_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtParCueDsc1_Internalname ;
      private string A1517ParCueDsc1 ;
      private string edtParCueDsc1_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtParCue1Tip_Internalname ;
      private string A1508ParCue1Tip ;
      private string edtParCue1Tip_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtParCue2_Internalname ;
      private string edtParCue2_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtParCueDsc2_Internalname ;
      private string A1519ParCueDsc2 ;
      private string edtParCueDsc2_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtParCue2Tip_Internalname ;
      private string A1509ParCue2Tip ;
      private string edtParCue2Tip_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtParCue3_Internalname ;
      private string edtParCue3_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtParCueDsc3_Internalname ;
      private string A1520ParCueDsc3 ;
      private string edtParCueDsc3_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtParCue3Tip_Internalname ;
      private string A1510ParCue3Tip ;
      private string edtParCue3Tip_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtParCue4_Internalname ;
      private string edtParCue4_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtParCueDsc4_Internalname ;
      private string A1521ParCueDsc4 ;
      private string edtParCueDsc4_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtParCue4Tip_Internalname ;
      private string A1511ParCue4Tip ;
      private string edtParCue4Tip_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtParCue5_Internalname ;
      private string edtParCue5_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtParCueDsc5_Internalname ;
      private string A1522ParCueDsc5 ;
      private string edtParCueDsc5_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtParCue5Tip_Internalname ;
      private string A1512ParCue5Tip ;
      private string edtParCue5Tip_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtParCue6_Internalname ;
      private string edtParCue6_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtParCueDsc6_Internalname ;
      private string A1523ParCueDsc6 ;
      private string edtParCueDsc6_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtParCue6Tip_Internalname ;
      private string A1513ParCue6Tip ;
      private string edtParCue6Tip_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtParCue7_Internalname ;
      private string edtParCue7_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtParCueDsc7_Internalname ;
      private string A1524ParCueDsc7 ;
      private string edtParCueDsc7_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtParCue7Tip_Internalname ;
      private string A1514ParCue7Tip ;
      private string edtParCue7Tip_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtParCue8_Internalname ;
      private string edtParCue8_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtParCueDsc8_Internalname ;
      private string A1525ParCueDsc8 ;
      private string edtParCueDsc8_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtParCue8Tip_Internalname ;
      private string A1515ParCue8Tip ;
      private string edtParCue8Tip_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtParCue9_Internalname ;
      private string edtParCue9_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtParCueDsc9_Internalname ;
      private string A1526ParCueDsc9 ;
      private string edtParCueDsc9_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtParCue9Tip_Internalname ;
      private string A1516ParCue9Tip ;
      private string edtParCue9Tip_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtParCue10_Internalname ;
      private string edtParCue10_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtParCueDsc10_Internalname ;
      private string A1518ParCueDsc10 ;
      private string edtParCueDsc10_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtParCue10Tip_Internalname ;
      private string A1507ParCue10Tip ;
      private string edtParCue10Tip_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtParMonCod_Internalname ;
      private string edtParMonCod_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtParTipCod_Internalname ;
      private string edtParTipCod_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtParTitem_Internalname ;
      private string edtParTitem_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtParForCod_Internalname ;
      private string edtParForCod_Jsonclick ;
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
      private string Z1517ParCueDsc1 ;
      private string Z1519ParCueDsc2 ;
      private string Z1520ParCueDsc3 ;
      private string Z1521ParCueDsc4 ;
      private string Z1522ParCueDsc5 ;
      private string Z1523ParCueDsc6 ;
      private string Z1524ParCueDsc7 ;
      private string Z1525ParCueDsc8 ;
      private string Z1526ParCueDsc9 ;
      private string Z1518ParCueDsc10 ;
      private string sMode62 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ83ParTip ;
      private string ZZ94ParCue1 ;
      private string ZZ1508ParCue1Tip ;
      private string ZZ95ParCue2 ;
      private string ZZ1509ParCue2Tip ;
      private string ZZ96ParCue3 ;
      private string ZZ1510ParCue3Tip ;
      private string ZZ97ParCue4 ;
      private string ZZ1511ParCue4Tip ;
      private string ZZ98ParCue5 ;
      private string ZZ1512ParCue5Tip ;
      private string ZZ99ParCue6 ;
      private string ZZ1513ParCue6Tip ;
      private string ZZ100ParCue7 ;
      private string ZZ1514ParCue7Tip ;
      private string ZZ101ParCue8 ;
      private string ZZ1515ParCue8Tip ;
      private string ZZ102ParCue9 ;
      private string ZZ1516ParCue9Tip ;
      private string ZZ103ParCue10 ;
      private string ZZ1507ParCue10Tip ;
      private string ZZ92ParTipCod ;
      private string ZZ1517ParCueDsc1 ;
      private string ZZ1519ParCueDsc2 ;
      private string ZZ1520ParCueDsc3 ;
      private string ZZ1521ParCueDsc4 ;
      private string ZZ1522ParCueDsc5 ;
      private string ZZ1523ParCueDsc6 ;
      private string ZZ1524ParCueDsc7 ;
      private string ZZ1525ParCueDsc8 ;
      private string ZZ1526ParCueDsc9 ;
      private string ZZ1518ParCueDsc10 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n94ParCue1 ;
      private bool n95ParCue2 ;
      private bool n96ParCue3 ;
      private bool n97ParCue4 ;
      private bool n98ParCue5 ;
      private bool n99ParCue6 ;
      private bool n100ParCue7 ;
      private bool n101ParCue8 ;
      private bool n102ParCue9 ;
      private bool n103ParCue10 ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T001T17_A84ParCod ;
      private string[] T001T17_A1517ParCueDsc1 ;
      private string[] T001T17_A1508ParCue1Tip ;
      private string[] T001T17_A1519ParCueDsc2 ;
      private string[] T001T17_A1509ParCue2Tip ;
      private string[] T001T17_A1520ParCueDsc3 ;
      private string[] T001T17_A1510ParCue3Tip ;
      private string[] T001T17_A1521ParCueDsc4 ;
      private string[] T001T17_A1511ParCue4Tip ;
      private string[] T001T17_A1522ParCueDsc5 ;
      private string[] T001T17_A1512ParCue5Tip ;
      private string[] T001T17_A1523ParCueDsc6 ;
      private string[] T001T17_A1513ParCue6Tip ;
      private string[] T001T17_A1524ParCueDsc7 ;
      private string[] T001T17_A1514ParCue7Tip ;
      private string[] T001T17_A1525ParCueDsc8 ;
      private string[] T001T17_A1515ParCue8Tip ;
      private string[] T001T17_A1526ParCueDsc9 ;
      private string[] T001T17_A1516ParCue9Tip ;
      private string[] T001T17_A1518ParCueDsc10 ;
      private string[] T001T17_A1507ParCue10Tip ;
      private short[] T001T17_A1542ParTitem ;
      private int[] T001T17_A1540ParForCod ;
      private string[] T001T17_A83ParTip ;
      private string[] T001T17_A94ParCue1 ;
      private bool[] T001T17_n94ParCue1 ;
      private string[] T001T17_A95ParCue2 ;
      private bool[] T001T17_n95ParCue2 ;
      private string[] T001T17_A96ParCue3 ;
      private bool[] T001T17_n96ParCue3 ;
      private string[] T001T17_A97ParCue4 ;
      private bool[] T001T17_n97ParCue4 ;
      private string[] T001T17_A98ParCue5 ;
      private bool[] T001T17_n98ParCue5 ;
      private string[] T001T17_A99ParCue6 ;
      private bool[] T001T17_n99ParCue6 ;
      private string[] T001T17_A100ParCue7 ;
      private bool[] T001T17_n100ParCue7 ;
      private string[] T001T17_A101ParCue8 ;
      private bool[] T001T17_n101ParCue8 ;
      private string[] T001T17_A102ParCue9 ;
      private bool[] T001T17_n102ParCue9 ;
      private string[] T001T17_A103ParCue10 ;
      private bool[] T001T17_n103ParCue10 ;
      private int[] T001T17_A93ParMonCod ;
      private string[] T001T17_A92ParTipCod ;
      private string[] T001T4_A83ParTip ;
      private string[] T001T5_A1517ParCueDsc1 ;
      private string[] T001T6_A1519ParCueDsc2 ;
      private string[] T001T7_A1520ParCueDsc3 ;
      private string[] T001T8_A1521ParCueDsc4 ;
      private string[] T001T9_A1522ParCueDsc5 ;
      private string[] T001T10_A1523ParCueDsc6 ;
      private string[] T001T11_A1524ParCueDsc7 ;
      private string[] T001T12_A1525ParCueDsc8 ;
      private string[] T001T13_A1526ParCueDsc9 ;
      private string[] T001T14_A1518ParCueDsc10 ;
      private int[] T001T15_A93ParMonCod ;
      private string[] T001T16_A92ParTipCod ;
      private string[] T001T18_A83ParTip ;
      private string[] T001T19_A1517ParCueDsc1 ;
      private string[] T001T20_A1519ParCueDsc2 ;
      private string[] T001T21_A1520ParCueDsc3 ;
      private string[] T001T22_A1521ParCueDsc4 ;
      private string[] T001T23_A1522ParCueDsc5 ;
      private string[] T001T24_A1523ParCueDsc6 ;
      private string[] T001T25_A1524ParCueDsc7 ;
      private string[] T001T26_A1525ParCueDsc8 ;
      private string[] T001T27_A1526ParCueDsc9 ;
      private string[] T001T28_A1518ParCueDsc10 ;
      private int[] T001T29_A93ParMonCod ;
      private string[] T001T30_A92ParTipCod ;
      private string[] T001T31_A83ParTip ;
      private int[] T001T31_A84ParCod ;
      private int[] T001T3_A84ParCod ;
      private string[] T001T3_A1508ParCue1Tip ;
      private string[] T001T3_A1509ParCue2Tip ;
      private string[] T001T3_A1510ParCue3Tip ;
      private string[] T001T3_A1511ParCue4Tip ;
      private string[] T001T3_A1512ParCue5Tip ;
      private string[] T001T3_A1513ParCue6Tip ;
      private string[] T001T3_A1514ParCue7Tip ;
      private string[] T001T3_A1515ParCue8Tip ;
      private string[] T001T3_A1516ParCue9Tip ;
      private string[] T001T3_A1507ParCue10Tip ;
      private short[] T001T3_A1542ParTitem ;
      private int[] T001T3_A1540ParForCod ;
      private string[] T001T3_A83ParTip ;
      private string[] T001T3_A94ParCue1 ;
      private bool[] T001T3_n94ParCue1 ;
      private string[] T001T3_A95ParCue2 ;
      private bool[] T001T3_n95ParCue2 ;
      private string[] T001T3_A96ParCue3 ;
      private bool[] T001T3_n96ParCue3 ;
      private string[] T001T3_A97ParCue4 ;
      private bool[] T001T3_n97ParCue4 ;
      private string[] T001T3_A98ParCue5 ;
      private bool[] T001T3_n98ParCue5 ;
      private string[] T001T3_A99ParCue6 ;
      private bool[] T001T3_n99ParCue6 ;
      private string[] T001T3_A100ParCue7 ;
      private bool[] T001T3_n100ParCue7 ;
      private string[] T001T3_A101ParCue8 ;
      private bool[] T001T3_n101ParCue8 ;
      private string[] T001T3_A102ParCue9 ;
      private bool[] T001T3_n102ParCue9 ;
      private string[] T001T3_A103ParCue10 ;
      private bool[] T001T3_n103ParCue10 ;
      private int[] T001T3_A93ParMonCod ;
      private string[] T001T3_A92ParTipCod ;
      private string[] T001T32_A83ParTip ;
      private int[] T001T32_A84ParCod ;
      private string[] T001T33_A83ParTip ;
      private int[] T001T33_A84ParCod ;
      private int[] T001T2_A84ParCod ;
      private string[] T001T2_A1508ParCue1Tip ;
      private string[] T001T2_A1509ParCue2Tip ;
      private string[] T001T2_A1510ParCue3Tip ;
      private string[] T001T2_A1511ParCue4Tip ;
      private string[] T001T2_A1512ParCue5Tip ;
      private string[] T001T2_A1513ParCue6Tip ;
      private string[] T001T2_A1514ParCue7Tip ;
      private string[] T001T2_A1515ParCue8Tip ;
      private string[] T001T2_A1516ParCue9Tip ;
      private string[] T001T2_A1507ParCue10Tip ;
      private short[] T001T2_A1542ParTitem ;
      private int[] T001T2_A1540ParForCod ;
      private string[] T001T2_A83ParTip ;
      private string[] T001T2_A94ParCue1 ;
      private bool[] T001T2_n94ParCue1 ;
      private string[] T001T2_A95ParCue2 ;
      private bool[] T001T2_n95ParCue2 ;
      private string[] T001T2_A96ParCue3 ;
      private bool[] T001T2_n96ParCue3 ;
      private string[] T001T2_A97ParCue4 ;
      private bool[] T001T2_n97ParCue4 ;
      private string[] T001T2_A98ParCue5 ;
      private bool[] T001T2_n98ParCue5 ;
      private string[] T001T2_A99ParCue6 ;
      private bool[] T001T2_n99ParCue6 ;
      private string[] T001T2_A100ParCue7 ;
      private bool[] T001T2_n100ParCue7 ;
      private string[] T001T2_A101ParCue8 ;
      private bool[] T001T2_n101ParCue8 ;
      private string[] T001T2_A102ParCue9 ;
      private bool[] T001T2_n102ParCue9 ;
      private string[] T001T2_A103ParCue10 ;
      private bool[] T001T2_n103ParCue10 ;
      private int[] T001T2_A93ParMonCod ;
      private string[] T001T2_A92ParTipCod ;
      private string[] T001T37_A1517ParCueDsc1 ;
      private string[] T001T38_A1519ParCueDsc2 ;
      private string[] T001T39_A1520ParCueDsc3 ;
      private string[] T001T40_A1521ParCueDsc4 ;
      private string[] T001T41_A1522ParCueDsc5 ;
      private string[] T001T42_A1523ParCueDsc6 ;
      private string[] T001T43_A1524ParCueDsc7 ;
      private string[] T001T44_A1525ParCueDsc8 ;
      private string[] T001T45_A1526ParCueDsc9 ;
      private string[] T001T46_A1518ParCueDsc10 ;
      private string[] T001T47_A83ParTip ;
      private int[] T001T47_A84ParCod ;
      private int[] T001T47_A90ParDTipItem ;
      private string[] T001T48_A83ParTip ;
      private int[] T001T48_A84ParCod ;
      private short[] T001T48_A104ParDItem ;
      private string[] T001T49_A83ParTip ;
      private int[] T001T49_A84ParCod ;
      private int[] T001T49_A85ParDActItem ;
      private string[] T001T50_A83ParTip ;
      private int[] T001T50_A84ParCod ;
      private string[] T001T51_A83ParTip ;
      private int[] T001T52_A93ParMonCod ;
      private string[] T001T53_A92ParTipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbparamdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbparamdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new UpdateCursor(def[32])
       ,new UpdateCursor(def[33])
       ,new UpdateCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
       ,new ForEachCursor(def[40])
       ,new ForEachCursor(def[41])
       ,new ForEachCursor(def[42])
       ,new ForEachCursor(def[43])
       ,new ForEachCursor(def[44])
       ,new ForEachCursor(def[45])
       ,new ForEachCursor(def[46])
       ,new ForEachCursor(def[47])
       ,new ForEachCursor(def[48])
       ,new ForEachCursor(def[49])
       ,new ForEachCursor(def[50])
       ,new ForEachCursor(def[51])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001T17;
        prmT001T17 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T4;
        prmT001T4 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0)
        };
        Object[] prmT001T5;
        prmT001T5 = new Object[] {
        new ParDef("@ParCue1",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T6;
        prmT001T6 = new Object[] {
        new ParDef("@ParCue2",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T7;
        prmT001T7 = new Object[] {
        new ParDef("@ParCue3",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T8;
        prmT001T8 = new Object[] {
        new ParDef("@ParCue4",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T9;
        prmT001T9 = new Object[] {
        new ParDef("@ParCue5",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T10;
        prmT001T10 = new Object[] {
        new ParDef("@ParCue6",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T11;
        prmT001T11 = new Object[] {
        new ParDef("@ParCue7",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T12;
        prmT001T12 = new Object[] {
        new ParDef("@ParCue8",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T13;
        prmT001T13 = new Object[] {
        new ParDef("@ParCue9",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T14;
        prmT001T14 = new Object[] {
        new ParDef("@ParCue10",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T15;
        prmT001T15 = new Object[] {
        new ParDef("@ParMonCod",GXType.Int32,6,0)
        };
        Object[] prmT001T16;
        prmT001T16 = new Object[] {
        new ParDef("@ParTipCod",GXType.NChar,3,0)
        };
        Object[] prmT001T18;
        prmT001T18 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0)
        };
        Object[] prmT001T19;
        prmT001T19 = new Object[] {
        new ParDef("@ParCue1",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T20;
        prmT001T20 = new Object[] {
        new ParDef("@ParCue2",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T21;
        prmT001T21 = new Object[] {
        new ParDef("@ParCue3",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T22;
        prmT001T22 = new Object[] {
        new ParDef("@ParCue4",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T23;
        prmT001T23 = new Object[] {
        new ParDef("@ParCue5",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T24;
        prmT001T24 = new Object[] {
        new ParDef("@ParCue6",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T25;
        prmT001T25 = new Object[] {
        new ParDef("@ParCue7",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T26;
        prmT001T26 = new Object[] {
        new ParDef("@ParCue8",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T27;
        prmT001T27 = new Object[] {
        new ParDef("@ParCue9",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T28;
        prmT001T28 = new Object[] {
        new ParDef("@ParCue10",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T29;
        prmT001T29 = new Object[] {
        new ParDef("@ParMonCod",GXType.Int32,6,0)
        };
        Object[] prmT001T30;
        prmT001T30 = new Object[] {
        new ParDef("@ParTipCod",GXType.NChar,3,0)
        };
        Object[] prmT001T31;
        prmT001T31 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T3;
        prmT001T3 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T32;
        prmT001T32 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T33;
        prmT001T33 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T2;
        prmT001T2 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T34;
        prmT001T34 = new Object[] {
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParCue1Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue2Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue3Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue4Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue5Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue6Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue7Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue8Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue9Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue10Tip",GXType.NChar,1,0) ,
        new ParDef("@ParTitem",GXType.Int16,4,0) ,
        new ParDef("@ParForCod",GXType.Int32,6,0) ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCue1",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue2",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue3",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue4",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue5",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue6",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue7",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue8",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue9",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue10",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParMonCod",GXType.Int32,6,0) ,
        new ParDef("@ParTipCod",GXType.NChar,3,0)
        };
        Object[] prmT001T35;
        prmT001T35 = new Object[] {
        new ParDef("@ParCue1Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue2Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue3Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue4Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue5Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue6Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue7Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue8Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue9Tip",GXType.NChar,1,0) ,
        new ParDef("@ParCue10Tip",GXType.NChar,1,0) ,
        new ParDef("@ParTitem",GXType.Int16,4,0) ,
        new ParDef("@ParForCod",GXType.Int32,6,0) ,
        new ParDef("@ParCue1",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue2",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue3",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue4",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue5",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue6",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue7",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue8",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue9",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParCue10",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParMonCod",GXType.Int32,6,0) ,
        new ParDef("@ParTipCod",GXType.NChar,3,0) ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T36;
        prmT001T36 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T47;
        prmT001T47 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T48;
        prmT001T48 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T49;
        prmT001T49 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001T50;
        prmT001T50 = new Object[] {
        };
        Object[] prmT001T51;
        prmT001T51 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0)
        };
        Object[] prmT001T37;
        prmT001T37 = new Object[] {
        new ParDef("@ParCue1",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T38;
        prmT001T38 = new Object[] {
        new ParDef("@ParCue2",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T39;
        prmT001T39 = new Object[] {
        new ParDef("@ParCue3",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T40;
        prmT001T40 = new Object[] {
        new ParDef("@ParCue4",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T41;
        prmT001T41 = new Object[] {
        new ParDef("@ParCue5",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T42;
        prmT001T42 = new Object[] {
        new ParDef("@ParCue6",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T43;
        prmT001T43 = new Object[] {
        new ParDef("@ParCue7",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T44;
        prmT001T44 = new Object[] {
        new ParDef("@ParCue8",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T45;
        prmT001T45 = new Object[] {
        new ParDef("@ParCue9",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T46;
        prmT001T46 = new Object[] {
        new ParDef("@ParCue10",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001T52;
        prmT001T52 = new Object[] {
        new ParDef("@ParMonCod",GXType.Int32,6,0)
        };
        Object[] prmT001T53;
        prmT001T53 = new Object[] {
        new ParDef("@ParTipCod",GXType.NChar,3,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001T2", "SELECT [ParCod], [ParCue1Tip], [ParCue2Tip], [ParCue3Tip], [ParCue4Tip], [ParCue5Tip], [ParCue6Tip], [ParCue7Tip], [ParCue8Tip], [ParCue9Tip], [ParCue10Tip], [ParTitem], [ParForCod], [ParTip], [ParCue1] AS ParCue1, [ParCue2] AS ParCue2, [ParCue3] AS ParCue3, [ParCue4] AS ParCue4, [ParCue5] AS ParCue5, [ParCue6] AS ParCue6, [ParCue7] AS ParCue7, [ParCue8] AS ParCue8, [ParCue9] AS ParCue9, [ParCue10] AS ParCue10, [ParMonCod] AS ParMonCod, [ParTipCod] AS ParTipCod FROM [CBPARAMDET] WITH (UPDLOCK) WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T3", "SELECT [ParCod], [ParCue1Tip], [ParCue2Tip], [ParCue3Tip], [ParCue4Tip], [ParCue5Tip], [ParCue6Tip], [ParCue7Tip], [ParCue8Tip], [ParCue9Tip], [ParCue10Tip], [ParTitem], [ParForCod], [ParTip], [ParCue1] AS ParCue1, [ParCue2] AS ParCue2, [ParCue3] AS ParCue3, [ParCue4] AS ParCue4, [ParCue5] AS ParCue5, [ParCue6] AS ParCue6, [ParCue7] AS ParCue7, [ParCue8] AS ParCue8, [ParCue9] AS ParCue9, [ParCue10] AS ParCue10, [ParMonCod] AS ParMonCod, [ParTipCod] AS ParTipCod FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T4", "SELECT [ParTip] FROM [CBPARAM] WHERE [ParTip] = @ParTip ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T5", "SELECT [CueDsc] AS ParCueDsc1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T6", "SELECT [CueDsc] AS ParCueDsc2 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T7", "SELECT [CueDsc] AS ParCueDsc3 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue3 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T8", "SELECT [CueDsc] AS ParCueDsc4 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue4 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T9", "SELECT [CueDsc] AS ParCueDsc5 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue5 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T10", "SELECT [CueDsc] AS ParCueDsc6 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue6 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T11", "SELECT [CueDsc] AS ParCueDsc7 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue7 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T12", "SELECT [CueDsc] AS ParCueDsc8 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue8 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T13", "SELECT [CueDsc] AS ParCueDsc9 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue9 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T14", "SELECT [CueDsc] AS ParCueDsc10 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue10 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T15", "SELECT [MonCod] AS ParMonCod FROM [CMONEDAS] WHERE [MonCod] = @ParMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T16", "SELECT [TipCod] AS ParTipCod FROM [CTIPDOC] WHERE [TipCod] = @ParTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T17", "SELECT TM1.[ParCod], T2.[CueDsc] AS ParCueDsc1, TM1.[ParCue1Tip], T3.[CueDsc] AS ParCueDsc2, TM1.[ParCue2Tip], T4.[CueDsc] AS ParCueDsc3, TM1.[ParCue3Tip], T5.[CueDsc] AS ParCueDsc4, TM1.[ParCue4Tip], T6.[CueDsc] AS ParCueDsc5, TM1.[ParCue5Tip], T7.[CueDsc] AS ParCueDsc6, TM1.[ParCue6Tip], T8.[CueDsc] AS ParCueDsc7, TM1.[ParCue7Tip], T9.[CueDsc] AS ParCueDsc8, TM1.[ParCue8Tip], T10.[CueDsc] AS ParCueDsc9, TM1.[ParCue9Tip], T11.[CueDsc] AS ParCueDsc10, TM1.[ParCue10Tip], TM1.[ParTitem], TM1.[ParForCod], TM1.[ParTip], TM1.[ParCue1] AS ParCue1, TM1.[ParCue2] AS ParCue2, TM1.[ParCue3] AS ParCue3, TM1.[ParCue4] AS ParCue4, TM1.[ParCue5] AS ParCue5, TM1.[ParCue6] AS ParCue6, TM1.[ParCue7] AS ParCue7, TM1.[ParCue8] AS ParCue8, TM1.[ParCue9] AS ParCue9, TM1.[ParCue10] AS ParCue10, TM1.[ParMonCod] AS ParMonCod, TM1.[ParTipCod] AS ParTipCod FROM (((((((((([CBPARAMDET] TM1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[ParCue1]) LEFT JOIN [CBPLANCUENTA] T3 ON T3.[CueCod] = TM1.[ParCue2]) LEFT JOIN [CBPLANCUENTA] T4 ON T4.[CueCod] = TM1.[ParCue3]) LEFT JOIN [CBPLANCUENTA] T5 ON T5.[CueCod] = TM1.[ParCue4]) LEFT JOIN [CBPLANCUENTA] T6 ON T6.[CueCod] = TM1.[ParCue5]) LEFT JOIN [CBPLANCUENTA] T7 ON T7.[CueCod] = TM1.[ParCue6]) LEFT JOIN [CBPLANCUENTA] T8 ON T8.[CueCod] = TM1.[ParCue7]) LEFT JOIN [CBPLANCUENTA] T9 ON T9.[CueCod] = TM1.[ParCue8]) LEFT JOIN [CBPLANCUENTA] T10 ON T10.[CueCod] = TM1.[ParCue9]) LEFT JOIN [CBPLANCUENTA] T11 ON T11.[CueCod] = TM1.[ParCue10]) WHERE TM1.[ParTip] = @ParTip and TM1.[ParCod] = @ParCod ORDER BY TM1.[ParTip], TM1.[ParCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T18", "SELECT [ParTip] FROM [CBPARAM] WHERE [ParTip] = @ParTip ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T19", "SELECT [CueDsc] AS ParCueDsc1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T20", "SELECT [CueDsc] AS ParCueDsc2 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T21", "SELECT [CueDsc] AS ParCueDsc3 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue3 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T22", "SELECT [CueDsc] AS ParCueDsc4 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue4 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T23", "SELECT [CueDsc] AS ParCueDsc5 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue5 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T23,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T24", "SELECT [CueDsc] AS ParCueDsc6 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue6 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T25", "SELECT [CueDsc] AS ParCueDsc7 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue7 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T26", "SELECT [CueDsc] AS ParCueDsc8 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue8 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T26,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T27", "SELECT [CueDsc] AS ParCueDsc9 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue9 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T27,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T28", "SELECT [CueDsc] AS ParCueDsc10 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue10 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T28,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T29", "SELECT [MonCod] AS ParMonCod FROM [CMONEDAS] WHERE [MonCod] = @ParMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T29,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T30", "SELECT [TipCod] AS ParTipCod FROM [CTIPDOC] WHERE [TipCod] = @ParTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T30,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T31", "SELECT [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T31,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T32", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE ( [ParTip] > @ParTip or [ParTip] = @ParTip and [ParCod] > @ParCod) ORDER BY [ParTip], [ParCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T33", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE ( [ParTip] < @ParTip or [ParTip] = @ParTip and [ParCod] < @ParCod) ORDER BY [ParTip] DESC, [ParCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T34", "INSERT INTO [CBPARAMDET]([ParCod], [ParCue1Tip], [ParCue2Tip], [ParCue3Tip], [ParCue4Tip], [ParCue5Tip], [ParCue6Tip], [ParCue7Tip], [ParCue8Tip], [ParCue9Tip], [ParCue10Tip], [ParTitem], [ParForCod], [ParTip], [ParCue1], [ParCue2], [ParCue3], [ParCue4], [ParCue5], [ParCue6], [ParCue7], [ParCue8], [ParCue9], [ParCue10], [ParMonCod], [ParTipCod]) VALUES(@ParCod, @ParCue1Tip, @ParCue2Tip, @ParCue3Tip, @ParCue4Tip, @ParCue5Tip, @ParCue6Tip, @ParCue7Tip, @ParCue8Tip, @ParCue9Tip, @ParCue10Tip, @ParTitem, @ParForCod, @ParTip, @ParCue1, @ParCue2, @ParCue3, @ParCue4, @ParCue5, @ParCue6, @ParCue7, @ParCue8, @ParCue9, @ParCue10, @ParMonCod, @ParTipCod)", GxErrorMask.GX_NOMASK,prmT001T34)
           ,new CursorDef("T001T35", "UPDATE [CBPARAMDET] SET [ParCue1Tip]=@ParCue1Tip, [ParCue2Tip]=@ParCue2Tip, [ParCue3Tip]=@ParCue3Tip, [ParCue4Tip]=@ParCue4Tip, [ParCue5Tip]=@ParCue5Tip, [ParCue6Tip]=@ParCue6Tip, [ParCue7Tip]=@ParCue7Tip, [ParCue8Tip]=@ParCue8Tip, [ParCue9Tip]=@ParCue9Tip, [ParCue10Tip]=@ParCue10Tip, [ParTitem]=@ParTitem, [ParForCod]=@ParForCod, [ParCue1]=@ParCue1, [ParCue2]=@ParCue2, [ParCue3]=@ParCue3, [ParCue4]=@ParCue4, [ParCue5]=@ParCue5, [ParCue6]=@ParCue6, [ParCue7]=@ParCue7, [ParCue8]=@ParCue8, [ParCue9]=@ParCue9, [ParCue10]=@ParCue10, [ParMonCod]=@ParMonCod, [ParTipCod]=@ParTipCod  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod", GxErrorMask.GX_NOMASK,prmT001T35)
           ,new CursorDef("T001T36", "DELETE FROM [CBPARAMDET]  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod", GxErrorMask.GX_NOMASK,prmT001T36)
           ,new CursorDef("T001T37", "SELECT [CueDsc] AS ParCueDsc1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T37,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T38", "SELECT [CueDsc] AS ParCueDsc2 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue2 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T38,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T39", "SELECT [CueDsc] AS ParCueDsc3 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue3 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T39,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T40", "SELECT [CueDsc] AS ParCueDsc4 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue4 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T40,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T41", "SELECT [CueDsc] AS ParCueDsc5 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue5 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T41,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T42", "SELECT [CueDsc] AS ParCueDsc6 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue6 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T42,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T43", "SELECT [CueDsc] AS ParCueDsc7 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue7 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T43,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T44", "SELECT [CueDsc] AS ParCueDsc8 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue8 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T44,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T45", "SELECT [CueDsc] AS ParCueDsc9 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue9 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T45,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T46", "SELECT [CueDsc] AS ParCueDsc10 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParCue10 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T46,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T47", "SELECT TOP 1 [ParTip], [ParCod], [ParDTipItem] FROM [CBPARAMCONCEPTOS] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T47,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T48", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T48,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T49", "SELECT TOP 1 [ParTip], [ParCod], [ParDActItem] FROM [CBPARAMACTIVO] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T49,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001T50", "SELECT [ParTip], [ParCod] FROM [CBPARAMDET] ORDER BY [ParTip], [ParCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001T50,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T51", "SELECT [ParTip] FROM [CBPARAM] WHERE [ParTip] = @ParTip ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T51,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T52", "SELECT [MonCod] AS ParMonCod FROM [CMONEDAS] WHERE [MonCod] = @ParMonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T52,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001T53", "SELECT [TipCod] AS ParTipCod FROM [CTIPDOC] WHERE [TipCod] = @ParTipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001T53,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 3);
              ((string[]) buf[14])[0] = rslt.getString(15, 15);
              ((bool[]) buf[15])[0] = rslt.wasNull(15);
              ((string[]) buf[16])[0] = rslt.getString(16, 15);
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 15);
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((string[]) buf[20])[0] = rslt.getString(18, 15);
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              ((string[]) buf[22])[0] = rslt.getString(19, 15);
              ((bool[]) buf[23])[0] = rslt.wasNull(19);
              ((string[]) buf[24])[0] = rslt.getString(20, 15);
              ((bool[]) buf[25])[0] = rslt.wasNull(20);
              ((string[]) buf[26])[0] = rslt.getString(21, 15);
              ((bool[]) buf[27])[0] = rslt.wasNull(21);
              ((string[]) buf[28])[0] = rslt.getString(22, 15);
              ((bool[]) buf[29])[0] = rslt.wasNull(22);
              ((string[]) buf[30])[0] = rslt.getString(23, 15);
              ((bool[]) buf[31])[0] = rslt.wasNull(23);
              ((string[]) buf[32])[0] = rslt.getString(24, 15);
              ((bool[]) buf[33])[0] = rslt.wasNull(24);
              ((int[]) buf[34])[0] = rslt.getInt(25);
              ((string[]) buf[35])[0] = rslt.getString(26, 3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 1);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((int[]) buf[12])[0] = rslt.getInt(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 3);
              ((string[]) buf[14])[0] = rslt.getString(15, 15);
              ((bool[]) buf[15])[0] = rslt.wasNull(15);
              ((string[]) buf[16])[0] = rslt.getString(16, 15);
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 15);
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((string[]) buf[20])[0] = rslt.getString(18, 15);
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              ((string[]) buf[22])[0] = rslt.getString(19, 15);
              ((bool[]) buf[23])[0] = rslt.wasNull(19);
              ((string[]) buf[24])[0] = rslt.getString(20, 15);
              ((bool[]) buf[25])[0] = rslt.wasNull(20);
              ((string[]) buf[26])[0] = rslt.getString(21, 15);
              ((bool[]) buf[27])[0] = rslt.wasNull(21);
              ((string[]) buf[28])[0] = rslt.getString(22, 15);
              ((bool[]) buf[29])[0] = rslt.wasNull(22);
              ((string[]) buf[30])[0] = rslt.getString(23, 15);
              ((bool[]) buf[31])[0] = rslt.wasNull(23);
              ((string[]) buf[32])[0] = rslt.getString(24, 15);
              ((bool[]) buf[33])[0] = rslt.wasNull(24);
              ((int[]) buf[34])[0] = rslt.getInt(25);
              ((string[]) buf[35])[0] = rslt.getString(26, 3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 100);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 100);
              ((string[]) buf[6])[0] = rslt.getString(7, 1);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              ((string[]) buf[9])[0] = rslt.getString(10, 100);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((string[]) buf[11])[0] = rslt.getString(12, 100);
              ((string[]) buf[12])[0] = rslt.getString(13, 1);
              ((string[]) buf[13])[0] = rslt.getString(14, 100);
              ((string[]) buf[14])[0] = rslt.getString(15, 1);
              ((string[]) buf[15])[0] = rslt.getString(16, 100);
              ((string[]) buf[16])[0] = rslt.getString(17, 1);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 1);
              ((string[]) buf[19])[0] = rslt.getString(20, 100);
              ((string[]) buf[20])[0] = rslt.getString(21, 1);
              ((short[]) buf[21])[0] = rslt.getShort(22);
              ((int[]) buf[22])[0] = rslt.getInt(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 3);
              ((string[]) buf[24])[0] = rslt.getString(25, 15);
              ((bool[]) buf[25])[0] = rslt.wasNull(25);
              ((string[]) buf[26])[0] = rslt.getString(26, 15);
              ((bool[]) buf[27])[0] = rslt.wasNull(26);
              ((string[]) buf[28])[0] = rslt.getString(27, 15);
              ((bool[]) buf[29])[0] = rslt.wasNull(27);
              ((string[]) buf[30])[0] = rslt.getString(28, 15);
              ((bool[]) buf[31])[0] = rslt.wasNull(28);
              ((string[]) buf[32])[0] = rslt.getString(29, 15);
              ((bool[]) buf[33])[0] = rslt.wasNull(29);
              ((string[]) buf[34])[0] = rslt.getString(30, 15);
              ((bool[]) buf[35])[0] = rslt.wasNull(30);
              ((string[]) buf[36])[0] = rslt.getString(31, 15);
              ((bool[]) buf[37])[0] = rslt.wasNull(31);
              ((string[]) buf[38])[0] = rslt.getString(32, 15);
              ((bool[]) buf[39])[0] = rslt.wasNull(32);
              ((string[]) buf[40])[0] = rslt.getString(33, 15);
              ((bool[]) buf[41])[0] = rslt.wasNull(33);
              ((string[]) buf[42])[0] = rslt.getString(34, 15);
              ((bool[]) buf[43])[0] = rslt.wasNull(34);
              ((int[]) buf[44])[0] = rslt.getInt(35);
              ((string[]) buf[45])[0] = rslt.getString(36, 3);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 28 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 48 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 49 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 50 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
