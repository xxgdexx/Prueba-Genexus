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
   public class cpcompras : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_14") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_14( A149TipCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_15") == 0 )
         {
            A244PrvCod = GetPar( "PrvCod");
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_15( A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A149TipCod = GetPar( "TipCod");
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = GetPar( "ComCod");
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = GetPar( "PrvCod");
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A149TipCod, A243ComCod, A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_16") == 0 )
         {
            A246ComMon = (int)(NumberUtil.Val( GetPar( "ComMon"), "."));
            AssignAttri("", false, "A246ComMon", StringUtil.LTrimStr( (decimal)(A246ComMon), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_16( A246ComMon) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_17") == 0 )
         {
            A245ComConpCod = (int)(NumberUtil.Val( GetPar( "ComConpCod"), "."));
            AssignAttri("", false, "A245ComConpCod", StringUtil.LTrimStr( (decimal)(A245ComConpCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_17( A245ComConpCod) ;
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
            Form.Meta.addItem("description", "Compras - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cpcompras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpcompras( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPCOMPRAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Documento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComCod_Internalname, StringUtil.RTrim( A243ComCod), StringUtil.RTrim( context.localUtil.Format( A243ComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Proveedor", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Fecha", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComFec_Internalname, context.localUtil.Format(A248ComFec, "99/99/99"), context.localUtil.Format( A248ComFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Fecha Vcto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComFVcto_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComFVcto_Internalname, context.localUtil.Format(A708ComFVcto, "99/99/99"), context.localUtil.Format( A708ComFVcto, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFVcto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFVcto_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComFVcto_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComFVcto_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Fecha Registro", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComFReg_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComFReg_Internalname, context.localUtil.Format(A707ComFReg, "99/99/99"), context.localUtil.Format( A707ComFReg, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFReg_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComFReg_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComFReg_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Moneda", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComMon_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A246ComMon), 6, 0, ".", "")), StringUtil.LTrim( ((edtComMon_Enabled!=0) ? context.localUtil.Format( (decimal)(A246ComMon), "ZZZZZ9") : context.localUtil.Format( (decimal)(A246ComMon), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComMon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComMon_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Condicion de Pago", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComConpCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A245ComConpCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtComConpCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A245ComConpCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A245ComConpCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComConpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComConpCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "N° Registro", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRef_Internalname, StringUtil.RTrim( A249ComRef), StringUtil.RTrim( context.localUtil.Format( A249ComRef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRef_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Maneja O.Compra", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComOcSt_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A721ComOcSt), 1, 0, ".", "")), StringUtil.LTrim( ((edtComOcSt_Enabled!=0) ? context.localUtil.Format( (decimal)(A721ComOcSt), "9") : context.localUtil.Format( (decimal)(A721ComOcSt), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComOcSt_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComOcSt_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Descuento", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDscto_Internalname, StringUtil.LTrim( StringUtil.NToC( A698ComDscto, 17, 2, ".", "")), StringUtil.LTrim( ((edtComDscto_Enabled!=0) ? context.localUtil.Format( A698ComDscto, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A698ComDscto, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDscto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDscto_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Retención 1", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRete1_Internalname, StringUtil.LTrim( StringUtil.NToC( A728ComRete1, 17, 2, ".", "")), StringUtil.LTrim( ((edtComRete1_Enabled!=0) ? context.localUtil.Format( A728ComRete1, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A728ComRete1, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRete1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRete1_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Retención 2", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRete2_Internalname, StringUtil.LTrim( StringUtil.NToC( A729ComRete2, 17, 2, ".", "")), StringUtil.LTrim( ((edtComRete2_Enabled!=0) ? context.localUtil.Format( A729ComRete2, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A729ComRete2, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRete2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRete2_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Flete", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComFlete_Internalname, StringUtil.LTrim( StringUtil.NToC( A706ComFlete, 17, 2, ".", "")), StringUtil.LTrim( ((edtComFlete_Enabled!=0) ? context.localUtil.Format( A706ComFlete, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A706ComFlete, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFlete_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFlete_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "I.S.C.", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComISC_Internalname, StringUtil.LTrim( StringUtil.NToC( A713ComISC, 17, 2, ".", "")), StringUtil.LTrim( ((edtComISC_Enabled!=0) ? context.localUtil.Format( A713ComISC, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A713ComISC, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComISC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComISC_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "% I.G.V.", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComPorIva_Internalname, StringUtil.LTrim( StringUtil.NToC( A717ComPorIva, 6, 2, ".", "")), StringUtil.LTrim( ((edtComPorIva_Enabled!=0) ? context.localUtil.Format( A717ComPorIva, "ZZ9.99") : context.localUtil.Format( A717ComPorIva, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComPorIva_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComPorIva_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Observaciones", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtComObs_Internalname, A720ComObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", 0, 1, edtComObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Total Item", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A714ComItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtComItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A714ComItem), "ZZZ9") : context.localUtil.Format( (decimal)(A714ComItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Redondeo", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRedondeo_Internalname, StringUtil.LTrim( StringUtil.NToC( A718ComRedondeo, 17, 2, ".", "")), StringUtil.LTrim( ((edtComRedondeo_Enabled!=0) ? context.localUtil.Format( A718ComRedondeo, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A718ComRedondeo, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRedondeo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRedondeo_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Valor", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A740ComValor, 17, 2, ".", "")), StringUtil.LTrim( ((edtComValor_Enabled!=0) ? context.localUtil.Format( A740ComValor, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A740ComValor, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComValor_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Razon Social", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrvDsc_Internalname, StringUtil.RTrim( A247PrvDsc), StringUtil.RTrim( context.localUtil.Format( A247PrvDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Año", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ComVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtComVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A741ComVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A741ComVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Mes", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A742ComVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtComVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A742ComVouMes), "Z9") : context.localUtil.Format( (decimal)(A742ComVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Tipo Asiento", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComTASICod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A734ComTASICod), 6, 0, ".", "")), StringUtil.LTrim( ((edtComTASICod_Enabled!=0) ? context.localUtil.Format( (decimal)(A734ComTASICod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A734ComTASICod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComTASICod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComTASICod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "N° Asiento", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComVouNum_Internalname, StringUtil.RTrim( A743ComVouNum), StringUtil.RTrim( context.localUtil.Format( A743ComVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Usuario Creación", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComUsuC_Internalname, StringUtil.RTrim( A738ComUsuC), StringUtil.RTrim( context.localUtil.Format( A738ComUsuC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComUsuC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComUsuC_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Fecha Creación", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComFecC_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComFecC_Internalname, context.localUtil.TToC( A702ComFecC, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A702ComFecC, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFecC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFecC_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComFecC_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComFecC_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Usuario Modificación", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComUsuM_Internalname, StringUtil.RTrim( A739ComUsuM), StringUtil.RTrim( context.localUtil.Format( A739ComUsuM, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComUsuM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComUsuM_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Fecha Modificación", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComFecM_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComFecM_Internalname, context.localUtil.TToC( A703ComFecM, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A703ComFecM, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFecM_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFecM_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComFecM_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComFecM_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Autorización", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComAut_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A671ComAut), 1, 0, ".", "")), StringUtil.LTrim( ((edtComAut_Enabled!=0) ? context.localUtil.Format( (decimal)(A671ComAut), "9") : context.localUtil.Format( (decimal)(A671ComAut), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComAut_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Usuario Autorización", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComUsuAut_Internalname, StringUtil.RTrim( A737ComUsuAut), StringUtil.RTrim( context.localUtil.Format( A737ComUsuAut, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComUsuAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComUsuAut_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Fecha Autorización", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComFecAut_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComFecAut_Internalname, context.localUtil.TToC( A701ComFecAut, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A701ComFecAut, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFecAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFecAut_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComFecAut_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComFecAut_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Importación", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComImpAfec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A709ComImpAfec), 1, 0, ".", "")), StringUtil.LTrim( ((edtComImpAfec_Enabled!=0) ? context.localUtil.Format( (decimal)(A709ComImpAfec), "9") : context.localUtil.Format( (decimal)(A709ComImpAfec), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComImpAfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComImpAfec_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Tipo Importación", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComImpTip_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A711ComImpTip), 1, 0, ".", "")), StringUtil.LTrim( ((edtComImpTip_Enabled!=0) ? context.localUtil.Format( (decimal)(A711ComImpTip), "9") : context.localUtil.Format( (decimal)(A711ComImpTip), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComImpTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComImpTip_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "N° de Importación", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComImpCod_Internalname, StringUtil.RTrim( A710ComImpCod), StringUtil.RTrim( context.localUtil.Format( A710ComImpCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComImpCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComImpCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Tipo de Costeo", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComImpTipCos_Internalname, StringUtil.RTrim( A712ComImpTipCos), StringUtil.RTrim( context.localUtil.Format( A712ComImpTipCos, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComImpTipCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComImpTipCos_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "Afecto Retención", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRetAfecto_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A726ComRetAfecto), 1, 0, ".", "")), StringUtil.LTrim( ((edtComRetAfecto_Enabled!=0) ? context.localUtil.Format( (decimal)(A726ComRetAfecto), "9") : context.localUtil.Format( (decimal)(A726ComRetAfecto), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRetAfecto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRetAfecto_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "N° Retención", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRetCod_Internalname, StringUtil.RTrim( A727ComRetCod), StringUtil.RTrim( context.localUtil.Format( A727ComRetCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRetCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRetCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Fecha Retención", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComRetFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComRetFec_Internalname, context.localUtil.Format(A730ComRetFec, "99/99/99"), context.localUtil.Format( A730ComRetFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRetFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRetFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComRetFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComRetFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Fecha Pago", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComFecPago_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComFecPago_Internalname, context.localUtil.Format(A704ComFecPago, "99/99/99"), context.localUtil.Format( A704ComFecPago, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFecPago_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFecPago_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComFecPago_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComFecPago_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Tipo Registro(Reg. Compras)", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComTipReg_Internalname, StringUtil.RTrim( A735ComTipReg), StringUtil.RTrim( context.localUtil.Format( A735ComTipReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,221);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComTipReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComTipReg_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock42_Internalname, "I.G.V. DUA", "", "", lblTextblock42_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComIVADUA_Internalname, StringUtil.LTrim( StringUtil.NToC( A719ComIVADUA, 17, 2, ".", "")), StringUtil.LTrim( ((edtComIVADUA_Enabled!=0) ? context.localUtil.Format( A719ComIVADUA, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A719ComIVADUA, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,226);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComIVADUA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComIVADUA_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock43_Internalname, "Afecto a CIF", "", "", lblTextblock43_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 231,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComCif_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A680ComCif), 1, 0, ".", "")), StringUtil.LTrim( ((edtComCif_Enabled!=0) ? context.localUtil.Format( (decimal)(A680ComCif), "9") : context.localUtil.Format( (decimal)(A680ComCif), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,231);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComCif_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComCif_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock44_Internalname, "T/D Ref", "", "", lblTextblock44_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 236,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRefTDoc_Internalname, StringUtil.RTrim( A725ComRefTDoc), StringUtil.RTrim( context.localUtil.Format( A725ComRefTDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,236);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRefTDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRefTDoc_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock45_Internalname, "N° Documento Ref", "", "", lblTextblock45_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 241,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComRefDoc_Internalname, StringUtil.RTrim( A722ComRefDoc), StringUtil.RTrim( context.localUtil.Format( A722ComRefDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,241);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRefDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRefDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock46_Internalname, "Fecha Ref", "", "", lblTextblock46_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 246,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtComRefFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtComRefFec_Internalname, context.localUtil.Format(A724ComRefFec, "99/99/99"), context.localUtil.Format( A724ComRefFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,246);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComRefFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComRefFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         GxWebStd.gx_bitmap( context, edtComRefFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtComRefFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock47_Internalname, "Flag Retención", "", "", lblTextblock47_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 251,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComFlagRet_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A705ComFlagRet), 1, 0, ".", "")), StringUtil.LTrim( ((edtComFlagRet_Enabled!=0) ? context.localUtil.Format( (decimal)(A705ComFlagRet), "9") : context.localUtil.Format( (decimal)(A705ComFlagRet), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,251);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComFlagRet_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComFlagRet_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock48_Internalname, "Codigo Banco", "", "", lblTextblock48_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 256,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A672ComBanCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtComBanCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A672ComBanCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A672ComBanCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,256);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock49_Internalname, "N° Cuenta de Banco", "", "", lblTextblock49_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 261,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanCta_Internalname, StringUtil.RTrim( A674ComBanCta), StringUtil.RTrim( context.localUtil.Format( A674ComBanCta, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,261);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanCta_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanCta_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock50_Internalname, "N° Registro de Banco", "", "", lblTextblock50_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 266,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanReg_Internalname, StringUtil.RTrim( A678ComBanReg), StringUtil.RTrim( context.localUtil.Format( A678ComBanReg, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,266);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanReg_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanReg_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock51_Internalname, "Forma de Pago", "", "", lblTextblock51_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 271,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A676ComBanForCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtComBanForCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A676ComBanForCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A676ComBanForCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,271);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanForCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanForCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock52_Internalname, "Importe Retención", "", "", lblTextblock52_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 276,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanImp_Internalname, StringUtil.LTrim( StringUtil.NToC( A677ComBanImp, 17, 2, ".", "")), StringUtil.LTrim( ((edtComBanImp_Enabled!=0) ? context.localUtil.Format( A677ComBanImp, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A677ComBanImp, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,276);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanImp_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock53_Internalname, "N° Cheque", "", "", lblTextblock53_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 281,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanDoc_Internalname, StringUtil.RTrim( A675ComBanDoc), StringUtil.RTrim( context.localUtil.Format( A675ComBanDoc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,281);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanDoc_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock54_Internalname, "Tipo de Cambio", "", "", lblTextblock54_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 286,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanTipC_Internalname, StringUtil.LTrim( StringUtil.NToC( A679ComBanTipC, 15, 5, ".", "")), StringUtil.LTrim( ((edtComBanTipC_Enabled!=0) ? context.localUtil.Format( A679ComBanTipC, "ZZZZZZZZ9.99999") : context.localUtil.Format( A679ComBanTipC, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,286);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanTipC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanTipC_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock55_Internalname, "Concepto Bancos", "", "", lblTextblock55_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 291,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComBanConc_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A673ComBanConc), 6, 0, ".", "")), StringUtil.LTrim( ((edtComBanConc_Enabled!=0) ? context.localUtil.Format( (decimal)(A673ComBanConc), "ZZZZZ9") : context.localUtil.Format( (decimal)(A673ComBanConc), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,291);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComBanConc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComBanConc_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 294,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 295,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 296,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 297,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 298,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPCOMPRAS.htm");
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
            Z149TipCod = cgiGet( "Z149TipCod");
            Z243ComCod = cgiGet( "Z243ComCod");
            Z244PrvCod = cgiGet( "Z244PrvCod");
            Z248ComFec = context.localUtil.CToD( cgiGet( "Z248ComFec"), 0);
            Z708ComFVcto = context.localUtil.CToD( cgiGet( "Z708ComFVcto"), 0);
            Z707ComFReg = context.localUtil.CToD( cgiGet( "Z707ComFReg"), 0);
            Z249ComRef = cgiGet( "Z249ComRef");
            Z721ComOcSt = (short)(context.localUtil.CToN( cgiGet( "Z721ComOcSt"), ".", ","));
            Z698ComDscto = context.localUtil.CToN( cgiGet( "Z698ComDscto"), ".", ",");
            Z728ComRete1 = context.localUtil.CToN( cgiGet( "Z728ComRete1"), ".", ",");
            Z729ComRete2 = context.localUtil.CToN( cgiGet( "Z729ComRete2"), ".", ",");
            Z706ComFlete = context.localUtil.CToN( cgiGet( "Z706ComFlete"), ".", ",");
            Z713ComISC = context.localUtil.CToN( cgiGet( "Z713ComISC"), ".", ",");
            Z717ComPorIva = context.localUtil.CToN( cgiGet( "Z717ComPorIva"), ".", ",");
            Z714ComItem = (short)(context.localUtil.CToN( cgiGet( "Z714ComItem"), ".", ","));
            Z718ComRedondeo = context.localUtil.CToN( cgiGet( "Z718ComRedondeo"), ".", ",");
            Z740ComValor = context.localUtil.CToN( cgiGet( "Z740ComValor"), ".", ",");
            Z741ComVouAno = (short)(context.localUtil.CToN( cgiGet( "Z741ComVouAno"), ".", ","));
            Z742ComVouMes = (short)(context.localUtil.CToN( cgiGet( "Z742ComVouMes"), ".", ","));
            Z734ComTASICod = (int)(context.localUtil.CToN( cgiGet( "Z734ComTASICod"), ".", ","));
            Z743ComVouNum = cgiGet( "Z743ComVouNum");
            Z738ComUsuC = cgiGet( "Z738ComUsuC");
            Z702ComFecC = context.localUtil.CToT( cgiGet( "Z702ComFecC"), 0);
            Z739ComUsuM = cgiGet( "Z739ComUsuM");
            Z703ComFecM = context.localUtil.CToT( cgiGet( "Z703ComFecM"), 0);
            Z671ComAut = (short)(context.localUtil.CToN( cgiGet( "Z671ComAut"), ".", ","));
            Z737ComUsuAut = cgiGet( "Z737ComUsuAut");
            Z701ComFecAut = context.localUtil.CToT( cgiGet( "Z701ComFecAut"), 0);
            Z709ComImpAfec = (short)(context.localUtil.CToN( cgiGet( "Z709ComImpAfec"), ".", ","));
            Z711ComImpTip = (short)(context.localUtil.CToN( cgiGet( "Z711ComImpTip"), ".", ","));
            Z710ComImpCod = cgiGet( "Z710ComImpCod");
            Z712ComImpTipCos = cgiGet( "Z712ComImpTipCos");
            Z726ComRetAfecto = (short)(context.localUtil.CToN( cgiGet( "Z726ComRetAfecto"), ".", ","));
            Z727ComRetCod = cgiGet( "Z727ComRetCod");
            Z730ComRetFec = context.localUtil.CToD( cgiGet( "Z730ComRetFec"), 0);
            Z704ComFecPago = context.localUtil.CToD( cgiGet( "Z704ComFecPago"), 0);
            Z735ComTipReg = cgiGet( "Z735ComTipReg");
            Z719ComIVADUA = context.localUtil.CToN( cgiGet( "Z719ComIVADUA"), ".", ",");
            Z680ComCif = (short)(context.localUtil.CToN( cgiGet( "Z680ComCif"), ".", ","));
            Z725ComRefTDoc = cgiGet( "Z725ComRefTDoc");
            Z722ComRefDoc = cgiGet( "Z722ComRefDoc");
            Z724ComRefFec = context.localUtil.CToD( cgiGet( "Z724ComRefFec"), 0);
            Z705ComFlagRet = (short)(context.localUtil.CToN( cgiGet( "Z705ComFlagRet"), ".", ","));
            n705ComFlagRet = ((0==A705ComFlagRet) ? true : false);
            Z672ComBanCod = (int)(context.localUtil.CToN( cgiGet( "Z672ComBanCod"), ".", ","));
            Z674ComBanCta = cgiGet( "Z674ComBanCta");
            Z678ComBanReg = cgiGet( "Z678ComBanReg");
            Z676ComBanForCod = (int)(context.localUtil.CToN( cgiGet( "Z676ComBanForCod"), ".", ","));
            Z677ComBanImp = context.localUtil.CToN( cgiGet( "Z677ComBanImp"), ".", ",");
            Z675ComBanDoc = cgiGet( "Z675ComBanDoc");
            Z679ComBanTipC = context.localUtil.CToN( cgiGet( "Z679ComBanTipC"), ".", ",");
            Z673ComBanConc = (int)(context.localUtil.CToN( cgiGet( "Z673ComBanConc"), ".", ","));
            Z723ComRefDom = cgiGet( "Z723ComRefDom");
            Z246ComMon = (int)(context.localUtil.CToN( cgiGet( "Z246ComMon"), ".", ","));
            Z245ComConpCod = (int)(context.localUtil.CToN( cgiGet( "Z245ComConpCod"), ".", ","));
            A723ComRefDom = cgiGet( "Z723ComRefDom");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A716ComSubAfe = context.localUtil.CToN( cgiGet( "COMSUBAFE"), ".", ",");
            A732ComSubIna = context.localUtil.CToN( cgiGet( "COMSUBINA"), ".", ",");
            A733ComSubTotal = context.localUtil.CToN( cgiGet( "COMSUBTOTAL"), ".", ",");
            A715ComIva = context.localUtil.CToN( cgiGet( "COMIVA"), ".", ",");
            A736ComTotal = context.localUtil.CToN( cgiGet( "COMTOTAL"), ".", ",");
            A723ComRefDom = cgiGet( "COMREFDOM");
            A681ComConpAbr = cgiGet( "COMCONPABR");
            A682ComConpDias = (short)(context.localUtil.CToN( cgiGet( "COMCONPDIAS"), ".", ","));
            A731ComSubImportacion = context.localUtil.CToN( cgiGet( "COMSUBIMPORTACION"), ".", ",");
            /* Read variables values. */
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = cgiGet( edtComCod_Internalname);
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            if ( context.localUtil.VCDate( cgiGet( edtComFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha"}), 1, "COMFEC");
               AnyError = 1;
               GX_FocusControl = edtComFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A248ComFec = DateTime.MinValue;
               AssignAttri("", false, "A248ComFec", context.localUtil.Format(A248ComFec, "99/99/99"));
            }
            else
            {
               A248ComFec = context.localUtil.CToD( cgiGet( edtComFec_Internalname), 2);
               AssignAttri("", false, "A248ComFec", context.localUtil.Format(A248ComFec, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtComFVcto_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Vcto"}), 1, "COMFVCTO");
               AnyError = 1;
               GX_FocusControl = edtComFVcto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A708ComFVcto = DateTime.MinValue;
               AssignAttri("", false, "A708ComFVcto", context.localUtil.Format(A708ComFVcto, "99/99/99"));
            }
            else
            {
               A708ComFVcto = context.localUtil.CToD( cgiGet( edtComFVcto_Internalname), 2);
               AssignAttri("", false, "A708ComFVcto", context.localUtil.Format(A708ComFVcto, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtComFReg_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Registro"}), 1, "COMFREG");
               AnyError = 1;
               GX_FocusControl = edtComFReg_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A707ComFReg = DateTime.MinValue;
               AssignAttri("", false, "A707ComFReg", context.localUtil.Format(A707ComFReg, "99/99/99"));
            }
            else
            {
               A707ComFReg = context.localUtil.CToD( cgiGet( edtComFReg_Internalname), 2);
               AssignAttri("", false, "A707ComFReg", context.localUtil.Format(A707ComFReg, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComMon_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComMon_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMMON");
               AnyError = 1;
               GX_FocusControl = edtComMon_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A246ComMon = 0;
               AssignAttri("", false, "A246ComMon", StringUtil.LTrimStr( (decimal)(A246ComMon), 6, 0));
            }
            else
            {
               A246ComMon = (int)(context.localUtil.CToN( cgiGet( edtComMon_Internalname), ".", ","));
               AssignAttri("", false, "A246ComMon", StringUtil.LTrimStr( (decimal)(A246ComMon), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComConpCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComConpCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMCONPCOD");
               AnyError = 1;
               GX_FocusControl = edtComConpCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A245ComConpCod = 0;
               AssignAttri("", false, "A245ComConpCod", StringUtil.LTrimStr( (decimal)(A245ComConpCod), 6, 0));
            }
            else
            {
               A245ComConpCod = (int)(context.localUtil.CToN( cgiGet( edtComConpCod_Internalname), ".", ","));
               AssignAttri("", false, "A245ComConpCod", StringUtil.LTrimStr( (decimal)(A245ComConpCod), 6, 0));
            }
            A249ComRef = cgiGet( edtComRef_Internalname);
            AssignAttri("", false, "A249ComRef", A249ComRef);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComOcSt_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComOcSt_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMOCST");
               AnyError = 1;
               GX_FocusControl = edtComOcSt_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A721ComOcSt = 0;
               AssignAttri("", false, "A721ComOcSt", StringUtil.Str( (decimal)(A721ComOcSt), 1, 0));
            }
            else
            {
               A721ComOcSt = (short)(context.localUtil.CToN( cgiGet( edtComOcSt_Internalname), ".", ","));
               AssignAttri("", false, "A721ComOcSt", StringUtil.Str( (decimal)(A721ComOcSt), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComDscto_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComDscto_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMDSCTO");
               AnyError = 1;
               GX_FocusControl = edtComDscto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A698ComDscto = 0;
               AssignAttri("", false, "A698ComDscto", StringUtil.LTrimStr( A698ComDscto, 15, 2));
            }
            else
            {
               A698ComDscto = context.localUtil.CToN( cgiGet( edtComDscto_Internalname), ".", ",");
               AssignAttri("", false, "A698ComDscto", StringUtil.LTrimStr( A698ComDscto, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComRete1_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComRete1_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMRETE1");
               AnyError = 1;
               GX_FocusControl = edtComRete1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A728ComRete1 = 0;
               AssignAttri("", false, "A728ComRete1", StringUtil.LTrimStr( A728ComRete1, 15, 2));
            }
            else
            {
               A728ComRete1 = context.localUtil.CToN( cgiGet( edtComRete1_Internalname), ".", ",");
               AssignAttri("", false, "A728ComRete1", StringUtil.LTrimStr( A728ComRete1, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComRete2_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComRete2_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMRETE2");
               AnyError = 1;
               GX_FocusControl = edtComRete2_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A729ComRete2 = 0;
               AssignAttri("", false, "A729ComRete2", StringUtil.LTrimStr( A729ComRete2, 15, 2));
            }
            else
            {
               A729ComRete2 = context.localUtil.CToN( cgiGet( edtComRete2_Internalname), ".", ",");
               AssignAttri("", false, "A729ComRete2", StringUtil.LTrimStr( A729ComRete2, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComFlete_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComFlete_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMFLETE");
               AnyError = 1;
               GX_FocusControl = edtComFlete_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A706ComFlete = 0;
               AssignAttri("", false, "A706ComFlete", StringUtil.LTrimStr( A706ComFlete, 15, 2));
            }
            else
            {
               A706ComFlete = context.localUtil.CToN( cgiGet( edtComFlete_Internalname), ".", ",");
               AssignAttri("", false, "A706ComFlete", StringUtil.LTrimStr( A706ComFlete, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComISC_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComISC_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMISC");
               AnyError = 1;
               GX_FocusControl = edtComISC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A713ComISC = 0;
               AssignAttri("", false, "A713ComISC", StringUtil.LTrimStr( A713ComISC, 15, 2));
            }
            else
            {
               A713ComISC = context.localUtil.CToN( cgiGet( edtComISC_Internalname), ".", ",");
               AssignAttri("", false, "A713ComISC", StringUtil.LTrimStr( A713ComISC, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComPorIva_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComPorIva_Internalname), ".", ",") > 999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMPORIVA");
               AnyError = 1;
               GX_FocusControl = edtComPorIva_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A717ComPorIva = 0;
               AssignAttri("", false, "A717ComPorIva", StringUtil.LTrimStr( A717ComPorIva, 6, 2));
            }
            else
            {
               A717ComPorIva = context.localUtil.CToN( cgiGet( edtComPorIva_Internalname), ".", ",");
               AssignAttri("", false, "A717ComPorIva", StringUtil.LTrimStr( A717ComPorIva, 6, 2));
            }
            A720ComObs = cgiGet( edtComObs_Internalname);
            AssignAttri("", false, "A720ComObs", A720ComObs);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMITEM");
               AnyError = 1;
               GX_FocusControl = edtComItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A714ComItem = 0;
               AssignAttri("", false, "A714ComItem", StringUtil.LTrimStr( (decimal)(A714ComItem), 4, 0));
            }
            else
            {
               A714ComItem = (short)(context.localUtil.CToN( cgiGet( edtComItem_Internalname), ".", ","));
               AssignAttri("", false, "A714ComItem", StringUtil.LTrimStr( (decimal)(A714ComItem), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComRedondeo_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComRedondeo_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMREDONDEO");
               AnyError = 1;
               GX_FocusControl = edtComRedondeo_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A718ComRedondeo = 0;
               AssignAttri("", false, "A718ComRedondeo", StringUtil.LTrimStr( A718ComRedondeo, 15, 2));
            }
            else
            {
               A718ComRedondeo = context.localUtil.CToN( cgiGet( edtComRedondeo_Internalname), ".", ",");
               AssignAttri("", false, "A718ComRedondeo", StringUtil.LTrimStr( A718ComRedondeo, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComValor_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComValor_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMVALOR");
               AnyError = 1;
               GX_FocusControl = edtComValor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A740ComValor = 0;
               AssignAttri("", false, "A740ComValor", StringUtil.LTrimStr( A740ComValor, 15, 2));
            }
            else
            {
               A740ComValor = context.localUtil.CToN( cgiGet( edtComValor_Internalname), ".", ",");
               AssignAttri("", false, "A740ComValor", StringUtil.LTrimStr( A740ComValor, 15, 2));
            }
            A247PrvDsc = cgiGet( edtPrvDsc_Internalname);
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMVOUANO");
               AnyError = 1;
               GX_FocusControl = edtComVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A741ComVouAno = 0;
               AssignAttri("", false, "A741ComVouAno", StringUtil.LTrimStr( (decimal)(A741ComVouAno), 4, 0));
            }
            else
            {
               A741ComVouAno = (short)(context.localUtil.CToN( cgiGet( edtComVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A741ComVouAno", StringUtil.LTrimStr( (decimal)(A741ComVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMVOUMES");
               AnyError = 1;
               GX_FocusControl = edtComVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A742ComVouMes = 0;
               AssignAttri("", false, "A742ComVouMes", StringUtil.LTrimStr( (decimal)(A742ComVouMes), 2, 0));
            }
            else
            {
               A742ComVouMes = (short)(context.localUtil.CToN( cgiGet( edtComVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A742ComVouMes", StringUtil.LTrimStr( (decimal)(A742ComVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComTASICod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComTASICod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMTASICOD");
               AnyError = 1;
               GX_FocusControl = edtComTASICod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A734ComTASICod = 0;
               AssignAttri("", false, "A734ComTASICod", StringUtil.LTrimStr( (decimal)(A734ComTASICod), 6, 0));
            }
            else
            {
               A734ComTASICod = (int)(context.localUtil.CToN( cgiGet( edtComTASICod_Internalname), ".", ","));
               AssignAttri("", false, "A734ComTASICod", StringUtil.LTrimStr( (decimal)(A734ComTASICod), 6, 0));
            }
            A743ComVouNum = cgiGet( edtComVouNum_Internalname);
            AssignAttri("", false, "A743ComVouNum", A743ComVouNum);
            A738ComUsuC = cgiGet( edtComUsuC_Internalname);
            AssignAttri("", false, "A738ComUsuC", A738ComUsuC);
            if ( context.localUtil.VCDateTime( cgiGet( edtComFecC_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Creación"}), 1, "COMFECC");
               AnyError = 1;
               GX_FocusControl = edtComFecC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A702ComFecC = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A702ComFecC", context.localUtil.TToC( A702ComFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A702ComFecC = context.localUtil.CToT( cgiGet( edtComFecC_Internalname));
               AssignAttri("", false, "A702ComFecC", context.localUtil.TToC( A702ComFecC, 8, 5, 0, 3, "/", ":", " "));
            }
            A739ComUsuM = cgiGet( edtComUsuM_Internalname);
            AssignAttri("", false, "A739ComUsuM", A739ComUsuM);
            if ( context.localUtil.VCDateTime( cgiGet( edtComFecM_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Modificación"}), 1, "COMFECM");
               AnyError = 1;
               GX_FocusControl = edtComFecM_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A703ComFecM = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A703ComFecM", context.localUtil.TToC( A703ComFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A703ComFecM = context.localUtil.CToT( cgiGet( edtComFecM_Internalname));
               AssignAttri("", false, "A703ComFecM", context.localUtil.TToC( A703ComFecM, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComAut_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComAut_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMAUT");
               AnyError = 1;
               GX_FocusControl = edtComAut_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A671ComAut = 0;
               AssignAttri("", false, "A671ComAut", StringUtil.Str( (decimal)(A671ComAut), 1, 0));
            }
            else
            {
               A671ComAut = (short)(context.localUtil.CToN( cgiGet( edtComAut_Internalname), ".", ","));
               AssignAttri("", false, "A671ComAut", StringUtil.Str( (decimal)(A671ComAut), 1, 0));
            }
            A737ComUsuAut = cgiGet( edtComUsuAut_Internalname);
            AssignAttri("", false, "A737ComUsuAut", A737ComUsuAut);
            if ( context.localUtil.VCDateTime( cgiGet( edtComFecAut_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Fecha Autorización"}), 1, "COMFECAUT");
               AnyError = 1;
               GX_FocusControl = edtComFecAut_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A701ComFecAut = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A701ComFecAut", context.localUtil.TToC( A701ComFecAut, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A701ComFecAut = context.localUtil.CToT( cgiGet( edtComFecAut_Internalname));
               AssignAttri("", false, "A701ComFecAut", context.localUtil.TToC( A701ComFecAut, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComImpAfec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComImpAfec_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMIMPAFEC");
               AnyError = 1;
               GX_FocusControl = edtComImpAfec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A709ComImpAfec = 0;
               AssignAttri("", false, "A709ComImpAfec", StringUtil.Str( (decimal)(A709ComImpAfec), 1, 0));
            }
            else
            {
               A709ComImpAfec = (short)(context.localUtil.CToN( cgiGet( edtComImpAfec_Internalname), ".", ","));
               AssignAttri("", false, "A709ComImpAfec", StringUtil.Str( (decimal)(A709ComImpAfec), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComImpTip_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComImpTip_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMIMPTIP");
               AnyError = 1;
               GX_FocusControl = edtComImpTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A711ComImpTip = 0;
               AssignAttri("", false, "A711ComImpTip", StringUtil.Str( (decimal)(A711ComImpTip), 1, 0));
            }
            else
            {
               A711ComImpTip = (short)(context.localUtil.CToN( cgiGet( edtComImpTip_Internalname), ".", ","));
               AssignAttri("", false, "A711ComImpTip", StringUtil.Str( (decimal)(A711ComImpTip), 1, 0));
            }
            A710ComImpCod = cgiGet( edtComImpCod_Internalname);
            AssignAttri("", false, "A710ComImpCod", A710ComImpCod);
            A712ComImpTipCos = cgiGet( edtComImpTipCos_Internalname);
            AssignAttri("", false, "A712ComImpTipCos", A712ComImpTipCos);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComRetAfecto_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComRetAfecto_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMRETAFECTO");
               AnyError = 1;
               GX_FocusControl = edtComRetAfecto_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A726ComRetAfecto = 0;
               AssignAttri("", false, "A726ComRetAfecto", StringUtil.Str( (decimal)(A726ComRetAfecto), 1, 0));
            }
            else
            {
               A726ComRetAfecto = (short)(context.localUtil.CToN( cgiGet( edtComRetAfecto_Internalname), ".", ","));
               AssignAttri("", false, "A726ComRetAfecto", StringUtil.Str( (decimal)(A726ComRetAfecto), 1, 0));
            }
            A727ComRetCod = cgiGet( edtComRetCod_Internalname);
            AssignAttri("", false, "A727ComRetCod", A727ComRetCod);
            if ( context.localUtil.VCDate( cgiGet( edtComRetFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Retención"}), 1, "COMRETFEC");
               AnyError = 1;
               GX_FocusControl = edtComRetFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A730ComRetFec = DateTime.MinValue;
               AssignAttri("", false, "A730ComRetFec", context.localUtil.Format(A730ComRetFec, "99/99/99"));
            }
            else
            {
               A730ComRetFec = context.localUtil.CToD( cgiGet( edtComRetFec_Internalname), 2);
               AssignAttri("", false, "A730ComRetFec", context.localUtil.Format(A730ComRetFec, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtComFecPago_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Pago"}), 1, "COMFECPAGO");
               AnyError = 1;
               GX_FocusControl = edtComFecPago_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A704ComFecPago = DateTime.MinValue;
               AssignAttri("", false, "A704ComFecPago", context.localUtil.Format(A704ComFecPago, "99/99/99"));
            }
            else
            {
               A704ComFecPago = context.localUtil.CToD( cgiGet( edtComFecPago_Internalname), 2);
               AssignAttri("", false, "A704ComFecPago", context.localUtil.Format(A704ComFecPago, "99/99/99"));
            }
            A735ComTipReg = cgiGet( edtComTipReg_Internalname);
            AssignAttri("", false, "A735ComTipReg", A735ComTipReg);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComIVADUA_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComIVADUA_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMIVADUA");
               AnyError = 1;
               GX_FocusControl = edtComIVADUA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A719ComIVADUA = 0;
               AssignAttri("", false, "A719ComIVADUA", StringUtil.LTrimStr( A719ComIVADUA, 15, 2));
            }
            else
            {
               A719ComIVADUA = context.localUtil.CToN( cgiGet( edtComIVADUA_Internalname), ".", ",");
               AssignAttri("", false, "A719ComIVADUA", StringUtil.LTrimStr( A719ComIVADUA, 15, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComCif_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComCif_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMCIF");
               AnyError = 1;
               GX_FocusControl = edtComCif_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A680ComCif = 0;
               AssignAttri("", false, "A680ComCif", StringUtil.Str( (decimal)(A680ComCif), 1, 0));
            }
            else
            {
               A680ComCif = (short)(context.localUtil.CToN( cgiGet( edtComCif_Internalname), ".", ","));
               AssignAttri("", false, "A680ComCif", StringUtil.Str( (decimal)(A680ComCif), 1, 0));
            }
            A725ComRefTDoc = cgiGet( edtComRefTDoc_Internalname);
            AssignAttri("", false, "A725ComRefTDoc", A725ComRefTDoc);
            A722ComRefDoc = cgiGet( edtComRefDoc_Internalname);
            AssignAttri("", false, "A722ComRefDoc", A722ComRefDoc);
            if ( context.localUtil.VCDate( cgiGet( edtComRefFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Ref"}), 1, "COMREFFEC");
               AnyError = 1;
               GX_FocusControl = edtComRefFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A724ComRefFec = DateTime.MinValue;
               AssignAttri("", false, "A724ComRefFec", context.localUtil.Format(A724ComRefFec, "99/99/99"));
            }
            else
            {
               A724ComRefFec = context.localUtil.CToD( cgiGet( edtComRefFec_Internalname), 2);
               AssignAttri("", false, "A724ComRefFec", context.localUtil.Format(A724ComRefFec, "99/99/99"));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComFlagRet_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComFlagRet_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMFLAGRET");
               AnyError = 1;
               GX_FocusControl = edtComFlagRet_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A705ComFlagRet = 0;
               n705ComFlagRet = false;
               AssignAttri("", false, "A705ComFlagRet", StringUtil.Str( (decimal)(A705ComFlagRet), 1, 0));
            }
            else
            {
               A705ComFlagRet = (short)(context.localUtil.CToN( cgiGet( edtComFlagRet_Internalname), ".", ","));
               n705ComFlagRet = false;
               AssignAttri("", false, "A705ComFlagRet", StringUtil.Str( (decimal)(A705ComFlagRet), 1, 0));
            }
            n705ComFlagRet = ((0==A705ComFlagRet) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMBANCOD");
               AnyError = 1;
               GX_FocusControl = edtComBanCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A672ComBanCod = 0;
               AssignAttri("", false, "A672ComBanCod", StringUtil.LTrimStr( (decimal)(A672ComBanCod), 6, 0));
            }
            else
            {
               A672ComBanCod = (int)(context.localUtil.CToN( cgiGet( edtComBanCod_Internalname), ".", ","));
               AssignAttri("", false, "A672ComBanCod", StringUtil.LTrimStr( (decimal)(A672ComBanCod), 6, 0));
            }
            A674ComBanCta = cgiGet( edtComBanCta_Internalname);
            AssignAttri("", false, "A674ComBanCta", A674ComBanCta);
            A678ComBanReg = cgiGet( edtComBanReg_Internalname);
            AssignAttri("", false, "A678ComBanReg", A678ComBanReg);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComBanForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComBanForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMBANFORCOD");
               AnyError = 1;
               GX_FocusControl = edtComBanForCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A676ComBanForCod = 0;
               AssignAttri("", false, "A676ComBanForCod", StringUtil.LTrimStr( (decimal)(A676ComBanForCod), 6, 0));
            }
            else
            {
               A676ComBanForCod = (int)(context.localUtil.CToN( cgiGet( edtComBanForCod_Internalname), ".", ","));
               AssignAttri("", false, "A676ComBanForCod", StringUtil.LTrimStr( (decimal)(A676ComBanForCod), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComBanImp_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComBanImp_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMBANIMP");
               AnyError = 1;
               GX_FocusControl = edtComBanImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A677ComBanImp = 0;
               AssignAttri("", false, "A677ComBanImp", StringUtil.LTrimStr( A677ComBanImp, 15, 2));
            }
            else
            {
               A677ComBanImp = context.localUtil.CToN( cgiGet( edtComBanImp_Internalname), ".", ",");
               AssignAttri("", false, "A677ComBanImp", StringUtil.LTrimStr( A677ComBanImp, 15, 2));
            }
            A675ComBanDoc = cgiGet( edtComBanDoc_Internalname);
            AssignAttri("", false, "A675ComBanDoc", A675ComBanDoc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComBanTipC_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComBanTipC_Internalname), ".", ",") > 999999999.99999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMBANTIPC");
               AnyError = 1;
               GX_FocusControl = edtComBanTipC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A679ComBanTipC = 0;
               AssignAttri("", false, "A679ComBanTipC", StringUtil.LTrimStr( A679ComBanTipC, 15, 5));
            }
            else
            {
               A679ComBanTipC = context.localUtil.CToN( cgiGet( edtComBanTipC_Internalname), ".", ",");
               AssignAttri("", false, "A679ComBanTipC", StringUtil.LTrimStr( A679ComBanTipC, 15, 5));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComBanConc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComBanConc_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMBANCONC");
               AnyError = 1;
               GX_FocusControl = edtComBanConc_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A673ComBanConc = 0;
               AssignAttri("", false, "A673ComBanConc", StringUtil.LTrimStr( (decimal)(A673ComBanConc), 6, 0));
            }
            else
            {
               A673ComBanConc = (int)(context.localUtil.CToN( cgiGet( edtComBanConc_Internalname), ".", ","));
               AssignAttri("", false, "A673ComBanConc", StringUtil.LTrimStr( (decimal)(A673ComBanConc), 6, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CPCOMPRAS");
            forbiddenHiddens.Add("ComRefDom", StringUtil.RTrim( context.localUtil.Format( A723ComRefDom, "")));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cpcompras:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A149TipCod = GetPar( "TipCod");
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = GetPar( "ComCod");
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = GetPar( "PrvCod");
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
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
               InitAll36109( ) ;
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
         DisableAttributes36109( ) ;
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

      protected void CONFIRM_360( )
      {
         BeforeValidate36109( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls36109( ) ;
            }
            else
            {
               CheckExtendedTable36109( ) ;
               if ( AnyError == 0 )
               {
                  ZM36109( 14) ;
                  ZM36109( 15) ;
                  ZM36109( 16) ;
                  ZM36109( 17) ;
                  ZM36109( 18) ;
               }
               CloseExtendedTableCursors36109( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues360( ) ;
         }
      }

      protected void ResetCaption360( )
      {
      }

      protected void ZM36109( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z248ComFec = T00363_A248ComFec[0];
               Z708ComFVcto = T00363_A708ComFVcto[0];
               Z707ComFReg = T00363_A707ComFReg[0];
               Z249ComRef = T00363_A249ComRef[0];
               Z721ComOcSt = T00363_A721ComOcSt[0];
               Z698ComDscto = T00363_A698ComDscto[0];
               Z728ComRete1 = T00363_A728ComRete1[0];
               Z729ComRete2 = T00363_A729ComRete2[0];
               Z706ComFlete = T00363_A706ComFlete[0];
               Z713ComISC = T00363_A713ComISC[0];
               Z717ComPorIva = T00363_A717ComPorIva[0];
               Z714ComItem = T00363_A714ComItem[0];
               Z718ComRedondeo = T00363_A718ComRedondeo[0];
               Z740ComValor = T00363_A740ComValor[0];
               Z741ComVouAno = T00363_A741ComVouAno[0];
               Z742ComVouMes = T00363_A742ComVouMes[0];
               Z734ComTASICod = T00363_A734ComTASICod[0];
               Z743ComVouNum = T00363_A743ComVouNum[0];
               Z738ComUsuC = T00363_A738ComUsuC[0];
               Z702ComFecC = T00363_A702ComFecC[0];
               Z739ComUsuM = T00363_A739ComUsuM[0];
               Z703ComFecM = T00363_A703ComFecM[0];
               Z671ComAut = T00363_A671ComAut[0];
               Z737ComUsuAut = T00363_A737ComUsuAut[0];
               Z701ComFecAut = T00363_A701ComFecAut[0];
               Z709ComImpAfec = T00363_A709ComImpAfec[0];
               Z711ComImpTip = T00363_A711ComImpTip[0];
               Z710ComImpCod = T00363_A710ComImpCod[0];
               Z712ComImpTipCos = T00363_A712ComImpTipCos[0];
               Z726ComRetAfecto = T00363_A726ComRetAfecto[0];
               Z727ComRetCod = T00363_A727ComRetCod[0];
               Z730ComRetFec = T00363_A730ComRetFec[0];
               Z704ComFecPago = T00363_A704ComFecPago[0];
               Z735ComTipReg = T00363_A735ComTipReg[0];
               Z719ComIVADUA = T00363_A719ComIVADUA[0];
               Z680ComCif = T00363_A680ComCif[0];
               Z725ComRefTDoc = T00363_A725ComRefTDoc[0];
               Z722ComRefDoc = T00363_A722ComRefDoc[0];
               Z724ComRefFec = T00363_A724ComRefFec[0];
               Z705ComFlagRet = T00363_A705ComFlagRet[0];
               Z672ComBanCod = T00363_A672ComBanCod[0];
               Z674ComBanCta = T00363_A674ComBanCta[0];
               Z678ComBanReg = T00363_A678ComBanReg[0];
               Z676ComBanForCod = T00363_A676ComBanForCod[0];
               Z677ComBanImp = T00363_A677ComBanImp[0];
               Z675ComBanDoc = T00363_A675ComBanDoc[0];
               Z679ComBanTipC = T00363_A679ComBanTipC[0];
               Z673ComBanConc = T00363_A673ComBanConc[0];
               Z723ComRefDom = T00363_A723ComRefDom[0];
               Z246ComMon = T00363_A246ComMon[0];
               Z245ComConpCod = T00363_A245ComConpCod[0];
            }
            else
            {
               Z248ComFec = A248ComFec;
               Z708ComFVcto = A708ComFVcto;
               Z707ComFReg = A707ComFReg;
               Z249ComRef = A249ComRef;
               Z721ComOcSt = A721ComOcSt;
               Z698ComDscto = A698ComDscto;
               Z728ComRete1 = A728ComRete1;
               Z729ComRete2 = A729ComRete2;
               Z706ComFlete = A706ComFlete;
               Z713ComISC = A713ComISC;
               Z717ComPorIva = A717ComPorIva;
               Z714ComItem = A714ComItem;
               Z718ComRedondeo = A718ComRedondeo;
               Z740ComValor = A740ComValor;
               Z741ComVouAno = A741ComVouAno;
               Z742ComVouMes = A742ComVouMes;
               Z734ComTASICod = A734ComTASICod;
               Z743ComVouNum = A743ComVouNum;
               Z738ComUsuC = A738ComUsuC;
               Z702ComFecC = A702ComFecC;
               Z739ComUsuM = A739ComUsuM;
               Z703ComFecM = A703ComFecM;
               Z671ComAut = A671ComAut;
               Z737ComUsuAut = A737ComUsuAut;
               Z701ComFecAut = A701ComFecAut;
               Z709ComImpAfec = A709ComImpAfec;
               Z711ComImpTip = A711ComImpTip;
               Z710ComImpCod = A710ComImpCod;
               Z712ComImpTipCos = A712ComImpTipCos;
               Z726ComRetAfecto = A726ComRetAfecto;
               Z727ComRetCod = A727ComRetCod;
               Z730ComRetFec = A730ComRetFec;
               Z704ComFecPago = A704ComFecPago;
               Z735ComTipReg = A735ComTipReg;
               Z719ComIVADUA = A719ComIVADUA;
               Z680ComCif = A680ComCif;
               Z725ComRefTDoc = A725ComRefTDoc;
               Z722ComRefDoc = A722ComRefDoc;
               Z724ComRefFec = A724ComRefFec;
               Z705ComFlagRet = A705ComFlagRet;
               Z672ComBanCod = A672ComBanCod;
               Z674ComBanCta = A674ComBanCta;
               Z678ComBanReg = A678ComBanReg;
               Z676ComBanForCod = A676ComBanForCod;
               Z677ComBanImp = A677ComBanImp;
               Z675ComBanDoc = A675ComBanDoc;
               Z679ComBanTipC = A679ComBanTipC;
               Z673ComBanConc = A673ComBanConc;
               Z723ComRefDom = A723ComRefDom;
               Z246ComMon = A246ComMon;
               Z245ComConpCod = A245ComConpCod;
            }
         }
         if ( GX_JID == -13 )
         {
            Z243ComCod = A243ComCod;
            Z248ComFec = A248ComFec;
            Z708ComFVcto = A708ComFVcto;
            Z707ComFReg = A707ComFReg;
            Z249ComRef = A249ComRef;
            Z721ComOcSt = A721ComOcSt;
            Z698ComDscto = A698ComDscto;
            Z728ComRete1 = A728ComRete1;
            Z729ComRete2 = A729ComRete2;
            Z706ComFlete = A706ComFlete;
            Z713ComISC = A713ComISC;
            Z717ComPorIva = A717ComPorIva;
            Z720ComObs = A720ComObs;
            Z714ComItem = A714ComItem;
            Z718ComRedondeo = A718ComRedondeo;
            Z740ComValor = A740ComValor;
            Z247PrvDsc = A247PrvDsc;
            Z741ComVouAno = A741ComVouAno;
            Z742ComVouMes = A742ComVouMes;
            Z734ComTASICod = A734ComTASICod;
            Z743ComVouNum = A743ComVouNum;
            Z738ComUsuC = A738ComUsuC;
            Z702ComFecC = A702ComFecC;
            Z739ComUsuM = A739ComUsuM;
            Z703ComFecM = A703ComFecM;
            Z671ComAut = A671ComAut;
            Z737ComUsuAut = A737ComUsuAut;
            Z701ComFecAut = A701ComFecAut;
            Z709ComImpAfec = A709ComImpAfec;
            Z711ComImpTip = A711ComImpTip;
            Z710ComImpCod = A710ComImpCod;
            Z712ComImpTipCos = A712ComImpTipCos;
            Z726ComRetAfecto = A726ComRetAfecto;
            Z727ComRetCod = A727ComRetCod;
            Z730ComRetFec = A730ComRetFec;
            Z704ComFecPago = A704ComFecPago;
            Z735ComTipReg = A735ComTipReg;
            Z719ComIVADUA = A719ComIVADUA;
            Z680ComCif = A680ComCif;
            Z725ComRefTDoc = A725ComRefTDoc;
            Z722ComRefDoc = A722ComRefDoc;
            Z724ComRefFec = A724ComRefFec;
            Z705ComFlagRet = A705ComFlagRet;
            Z672ComBanCod = A672ComBanCod;
            Z674ComBanCta = A674ComBanCta;
            Z678ComBanReg = A678ComBanReg;
            Z676ComBanForCod = A676ComBanForCod;
            Z677ComBanImp = A677ComBanImp;
            Z675ComBanDoc = A675ComBanDoc;
            Z679ComBanTipC = A679ComBanTipC;
            Z673ComBanConc = A673ComBanConc;
            Z723ComRefDom = A723ComRefDom;
            Z149TipCod = A149TipCod;
            Z244PrvCod = A244PrvCod;
            Z246ComMon = A246ComMon;
            Z245ComConpCod = A245ComConpCod;
            Z716ComSubAfe = A716ComSubAfe;
            Z732ComSubIna = A732ComSubIna;
            Z731ComSubImportacion = A731ComSubImportacion;
            Z681ComConpAbr = A681ComConpAbr;
            Z682ComConpDias = A682ComConpDias;
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

      protected void Load36109( )
      {
         /* Using cursor T003611 */
         pr_default.execute(7, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound109 = 1;
            A248ComFec = T003611_A248ComFec[0];
            AssignAttri("", false, "A248ComFec", context.localUtil.Format(A248ComFec, "99/99/99"));
            A708ComFVcto = T003611_A708ComFVcto[0];
            AssignAttri("", false, "A708ComFVcto", context.localUtil.Format(A708ComFVcto, "99/99/99"));
            A707ComFReg = T003611_A707ComFReg[0];
            AssignAttri("", false, "A707ComFReg", context.localUtil.Format(A707ComFReg, "99/99/99"));
            A249ComRef = T003611_A249ComRef[0];
            AssignAttri("", false, "A249ComRef", A249ComRef);
            A721ComOcSt = T003611_A721ComOcSt[0];
            AssignAttri("", false, "A721ComOcSt", StringUtil.Str( (decimal)(A721ComOcSt), 1, 0));
            A698ComDscto = T003611_A698ComDscto[0];
            AssignAttri("", false, "A698ComDscto", StringUtil.LTrimStr( A698ComDscto, 15, 2));
            A728ComRete1 = T003611_A728ComRete1[0];
            AssignAttri("", false, "A728ComRete1", StringUtil.LTrimStr( A728ComRete1, 15, 2));
            A729ComRete2 = T003611_A729ComRete2[0];
            AssignAttri("", false, "A729ComRete2", StringUtil.LTrimStr( A729ComRete2, 15, 2));
            A706ComFlete = T003611_A706ComFlete[0];
            AssignAttri("", false, "A706ComFlete", StringUtil.LTrimStr( A706ComFlete, 15, 2));
            A713ComISC = T003611_A713ComISC[0];
            AssignAttri("", false, "A713ComISC", StringUtil.LTrimStr( A713ComISC, 15, 2));
            A717ComPorIva = T003611_A717ComPorIva[0];
            AssignAttri("", false, "A717ComPorIva", StringUtil.LTrimStr( A717ComPorIva, 6, 2));
            A720ComObs = T003611_A720ComObs[0];
            AssignAttri("", false, "A720ComObs", A720ComObs);
            A714ComItem = T003611_A714ComItem[0];
            AssignAttri("", false, "A714ComItem", StringUtil.LTrimStr( (decimal)(A714ComItem), 4, 0));
            A718ComRedondeo = T003611_A718ComRedondeo[0];
            AssignAttri("", false, "A718ComRedondeo", StringUtil.LTrimStr( A718ComRedondeo, 15, 2));
            A740ComValor = T003611_A740ComValor[0];
            AssignAttri("", false, "A740ComValor", StringUtil.LTrimStr( A740ComValor, 15, 2));
            A247PrvDsc = T003611_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            A741ComVouAno = T003611_A741ComVouAno[0];
            AssignAttri("", false, "A741ComVouAno", StringUtil.LTrimStr( (decimal)(A741ComVouAno), 4, 0));
            A742ComVouMes = T003611_A742ComVouMes[0];
            AssignAttri("", false, "A742ComVouMes", StringUtil.LTrimStr( (decimal)(A742ComVouMes), 2, 0));
            A734ComTASICod = T003611_A734ComTASICod[0];
            AssignAttri("", false, "A734ComTASICod", StringUtil.LTrimStr( (decimal)(A734ComTASICod), 6, 0));
            A743ComVouNum = T003611_A743ComVouNum[0];
            AssignAttri("", false, "A743ComVouNum", A743ComVouNum);
            A738ComUsuC = T003611_A738ComUsuC[0];
            AssignAttri("", false, "A738ComUsuC", A738ComUsuC);
            A702ComFecC = T003611_A702ComFecC[0];
            AssignAttri("", false, "A702ComFecC", context.localUtil.TToC( A702ComFecC, 8, 5, 0, 3, "/", ":", " "));
            A739ComUsuM = T003611_A739ComUsuM[0];
            AssignAttri("", false, "A739ComUsuM", A739ComUsuM);
            A703ComFecM = T003611_A703ComFecM[0];
            AssignAttri("", false, "A703ComFecM", context.localUtil.TToC( A703ComFecM, 8, 5, 0, 3, "/", ":", " "));
            A671ComAut = T003611_A671ComAut[0];
            AssignAttri("", false, "A671ComAut", StringUtil.Str( (decimal)(A671ComAut), 1, 0));
            A737ComUsuAut = T003611_A737ComUsuAut[0];
            AssignAttri("", false, "A737ComUsuAut", A737ComUsuAut);
            A701ComFecAut = T003611_A701ComFecAut[0];
            AssignAttri("", false, "A701ComFecAut", context.localUtil.TToC( A701ComFecAut, 8, 5, 0, 3, "/", ":", " "));
            A709ComImpAfec = T003611_A709ComImpAfec[0];
            AssignAttri("", false, "A709ComImpAfec", StringUtil.Str( (decimal)(A709ComImpAfec), 1, 0));
            A711ComImpTip = T003611_A711ComImpTip[0];
            AssignAttri("", false, "A711ComImpTip", StringUtil.Str( (decimal)(A711ComImpTip), 1, 0));
            A710ComImpCod = T003611_A710ComImpCod[0];
            AssignAttri("", false, "A710ComImpCod", A710ComImpCod);
            A712ComImpTipCos = T003611_A712ComImpTipCos[0];
            AssignAttri("", false, "A712ComImpTipCos", A712ComImpTipCos);
            A726ComRetAfecto = T003611_A726ComRetAfecto[0];
            AssignAttri("", false, "A726ComRetAfecto", StringUtil.Str( (decimal)(A726ComRetAfecto), 1, 0));
            A727ComRetCod = T003611_A727ComRetCod[0];
            AssignAttri("", false, "A727ComRetCod", A727ComRetCod);
            A730ComRetFec = T003611_A730ComRetFec[0];
            AssignAttri("", false, "A730ComRetFec", context.localUtil.Format(A730ComRetFec, "99/99/99"));
            A704ComFecPago = T003611_A704ComFecPago[0];
            AssignAttri("", false, "A704ComFecPago", context.localUtil.Format(A704ComFecPago, "99/99/99"));
            A735ComTipReg = T003611_A735ComTipReg[0];
            AssignAttri("", false, "A735ComTipReg", A735ComTipReg);
            A719ComIVADUA = T003611_A719ComIVADUA[0];
            AssignAttri("", false, "A719ComIVADUA", StringUtil.LTrimStr( A719ComIVADUA, 15, 2));
            A680ComCif = T003611_A680ComCif[0];
            AssignAttri("", false, "A680ComCif", StringUtil.Str( (decimal)(A680ComCif), 1, 0));
            A725ComRefTDoc = T003611_A725ComRefTDoc[0];
            AssignAttri("", false, "A725ComRefTDoc", A725ComRefTDoc);
            A722ComRefDoc = T003611_A722ComRefDoc[0];
            AssignAttri("", false, "A722ComRefDoc", A722ComRefDoc);
            A724ComRefFec = T003611_A724ComRefFec[0];
            AssignAttri("", false, "A724ComRefFec", context.localUtil.Format(A724ComRefFec, "99/99/99"));
            A705ComFlagRet = T003611_A705ComFlagRet[0];
            n705ComFlagRet = T003611_n705ComFlagRet[0];
            AssignAttri("", false, "A705ComFlagRet", StringUtil.Str( (decimal)(A705ComFlagRet), 1, 0));
            A672ComBanCod = T003611_A672ComBanCod[0];
            AssignAttri("", false, "A672ComBanCod", StringUtil.LTrimStr( (decimal)(A672ComBanCod), 6, 0));
            A674ComBanCta = T003611_A674ComBanCta[0];
            AssignAttri("", false, "A674ComBanCta", A674ComBanCta);
            A678ComBanReg = T003611_A678ComBanReg[0];
            AssignAttri("", false, "A678ComBanReg", A678ComBanReg);
            A676ComBanForCod = T003611_A676ComBanForCod[0];
            AssignAttri("", false, "A676ComBanForCod", StringUtil.LTrimStr( (decimal)(A676ComBanForCod), 6, 0));
            A677ComBanImp = T003611_A677ComBanImp[0];
            AssignAttri("", false, "A677ComBanImp", StringUtil.LTrimStr( A677ComBanImp, 15, 2));
            A675ComBanDoc = T003611_A675ComBanDoc[0];
            AssignAttri("", false, "A675ComBanDoc", A675ComBanDoc);
            A679ComBanTipC = T003611_A679ComBanTipC[0];
            AssignAttri("", false, "A679ComBanTipC", StringUtil.LTrimStr( A679ComBanTipC, 15, 5));
            A673ComBanConc = T003611_A673ComBanConc[0];
            AssignAttri("", false, "A673ComBanConc", StringUtil.LTrimStr( (decimal)(A673ComBanConc), 6, 0));
            A681ComConpAbr = T003611_A681ComConpAbr[0];
            A682ComConpDias = T003611_A682ComConpDias[0];
            A723ComRefDom = T003611_A723ComRefDom[0];
            A246ComMon = T003611_A246ComMon[0];
            AssignAttri("", false, "A246ComMon", StringUtil.LTrimStr( (decimal)(A246ComMon), 6, 0));
            A245ComConpCod = T003611_A245ComConpCod[0];
            AssignAttri("", false, "A245ComConpCod", StringUtil.LTrimStr( (decimal)(A245ComConpCod), 6, 0));
            A716ComSubAfe = T003611_A716ComSubAfe[0];
            A732ComSubIna = T003611_A732ComSubIna[0];
            A731ComSubImportacion = T003611_A731ComSubImportacion[0];
            ZM36109( -13) ;
         }
         pr_default.close(7);
         OnLoadActions36109( ) ;
      }

      protected void OnLoadActions36109( )
      {
         /* Using cursor T00365 */
         pr_default.execute(3, new Object[] {A244PrvCod});
         A247PrvDsc = T00365_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         pr_default.close(3);
         A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
         AssignAttri("", false, "A715ComIva", StringUtil.LTrimStr( A715ComIva, 15, 2));
         A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
         AssignAttri("", false, "A733ComSubTotal", StringUtil.LTrimStr( A733ComSubTotal, 15, 2));
         A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
         AssignAttri("", false, "A736ComTotal", StringUtil.LTrimStr( A736ComTotal, 15, 2));
      }

      protected void CheckExtendedTable36109( )
      {
         nIsDirty_109 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00364 */
         pr_default.execute(2, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00365 */
         pr_default.execute(3, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T00365_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         pr_default.close(3);
         /* Using cursor T00369 */
         pr_default.execute(6, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A716ComSubAfe = T00369_A716ComSubAfe[0];
            A732ComSubIna = T00369_A732ComSubIna[0];
            A731ComSubImportacion = T00369_A731ComSubImportacion[0];
         }
         else
         {
            nIsDirty_109 = 1;
            A716ComSubAfe = 0;
            AssignAttri("", false, "A716ComSubAfe", StringUtil.LTrimStr( A716ComSubAfe, 15, 2));
            nIsDirty_109 = 1;
            A732ComSubIna = 0;
            AssignAttri("", false, "A732ComSubIna", StringUtil.LTrimStr( A732ComSubIna, 15, 2));
            nIsDirty_109 = 1;
            A731ComSubImportacion = 0;
            AssignAttri("", false, "A731ComSubImportacion", StringUtil.LTrimStr( A731ComSubImportacion, 15, 2));
         }
         pr_default.close(6);
         nIsDirty_109 = 1;
         A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
         AssignAttri("", false, "A715ComIva", StringUtil.LTrimStr( A715ComIva, 15, 2));
         nIsDirty_109 = 1;
         A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
         AssignAttri("", false, "A733ComSubTotal", StringUtil.LTrimStr( A733ComSubTotal, 15, 2));
         nIsDirty_109 = 1;
         A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
         AssignAttri("", false, "A736ComTotal", StringUtil.LTrimStr( A736ComTotal, 15, 2));
         if ( ! ( (DateTime.MinValue==A248ComFec) || ( DateTimeUtil.ResetTime ( A248ComFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha fuera de rango", "OutOfRange", 1, "COMFEC");
            AnyError = 1;
            GX_FocusControl = edtComFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A708ComFVcto) || ( DateTimeUtil.ResetTime ( A708ComFVcto ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Vcto fuera de rango", "OutOfRange", 1, "COMFVCTO");
            AnyError = 1;
            GX_FocusControl = edtComFVcto_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A707ComFReg) || ( DateTimeUtil.ResetTime ( A707ComFReg ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Registro fuera de rango", "OutOfRange", 1, "COMFREG");
            AnyError = 1;
            GX_FocusControl = edtComFReg_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00366 */
         pr_default.execute(4, new Object[] {A246ComMon});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "COMMON");
            AnyError = 1;
            GX_FocusControl = edtComMon_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T00367 */
         pr_default.execute(5, new Object[] {A245ComConpCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "COMCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtComConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A681ComConpAbr = T00367_A681ComConpAbr[0];
         A682ComConpDias = T00367_A682ComConpDias[0];
         pr_default.close(5);
         if ( ! ( (DateTime.MinValue==A702ComFecC) || ( A702ComFecC >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Creación fuera de rango", "OutOfRange", 1, "COMFECC");
            AnyError = 1;
            GX_FocusControl = edtComFecC_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A703ComFecM) || ( A703ComFecM >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Modificación fuera de rango", "OutOfRange", 1, "COMFECM");
            AnyError = 1;
            GX_FocusControl = edtComFecM_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A701ComFecAut) || ( A701ComFecAut >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Autorización fuera de rango", "OutOfRange", 1, "COMFECAUT");
            AnyError = 1;
            GX_FocusControl = edtComFecAut_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A730ComRetFec) || ( DateTimeUtil.ResetTime ( A730ComRetFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Retención fuera de rango", "OutOfRange", 1, "COMRETFEC");
            AnyError = 1;
            GX_FocusControl = edtComRetFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A704ComFecPago) || ( DateTimeUtil.ResetTime ( A704ComFecPago ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Pago fuera de rango", "OutOfRange", 1, "COMFECPAGO");
            AnyError = 1;
            GX_FocusControl = edtComFecPago_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A724ComRefFec) || ( DateTimeUtil.ResetTime ( A724ComRefFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Ref fuera de rango", "OutOfRange", 1, "COMREFFEC");
            AnyError = 1;
            GX_FocusControl = edtComRefFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors36109( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(6);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_14( string A149TipCod )
      {
         /* Using cursor T003612 */
         pr_default.execute(8, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_15( string A244PrvCod )
      {
         /* Using cursor T003613 */
         pr_default.execute(9, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T003613_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A247PrvDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_18( string A149TipCod ,
                                string A243ComCod ,
                                string A244PrvCod )
      {
         /* Using cursor T003615 */
         pr_default.execute(10, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A716ComSubAfe = T003615_A716ComSubAfe[0];
            A732ComSubIna = T003615_A732ComSubIna[0];
            A731ComSubImportacion = T003615_A731ComSubImportacion[0];
         }
         else
         {
            A716ComSubAfe = 0;
            AssignAttri("", false, "A716ComSubAfe", StringUtil.LTrimStr( A716ComSubAfe, 15, 2));
            A732ComSubIna = 0;
            AssignAttri("", false, "A732ComSubIna", StringUtil.LTrimStr( A732ComSubIna, 15, 2));
            A731ComSubImportacion = 0;
            AssignAttri("", false, "A731ComSubImportacion", StringUtil.LTrimStr( A731ComSubImportacion, 15, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A716ComSubAfe, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A732ComSubIna, 15, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A731ComSubImportacion, 15, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_16( int A246ComMon )
      {
         /* Using cursor T003616 */
         pr_default.execute(11, new Object[] {A246ComMon});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "COMMON");
            AnyError = 1;
            GX_FocusControl = edtComMon_Internalname;
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

      protected void gxLoad_17( int A245ComConpCod )
      {
         /* Using cursor T003617 */
         pr_default.execute(12, new Object[] {A245ComConpCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "COMCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtComConpCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A681ComConpAbr = T003617_A681ComConpAbr[0];
         A682ComConpDias = T003617_A682ComConpDias[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A681ComConpAbr))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A682ComConpDias), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey36109( )
      {
         /* Using cursor T003618 */
         pr_default.execute(13, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound109 = 1;
         }
         else
         {
            RcdFound109 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00363 */
         pr_default.execute(1, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM36109( 13) ;
            RcdFound109 = 1;
            A243ComCod = T00363_A243ComCod[0];
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A248ComFec = T00363_A248ComFec[0];
            AssignAttri("", false, "A248ComFec", context.localUtil.Format(A248ComFec, "99/99/99"));
            A708ComFVcto = T00363_A708ComFVcto[0];
            AssignAttri("", false, "A708ComFVcto", context.localUtil.Format(A708ComFVcto, "99/99/99"));
            A707ComFReg = T00363_A707ComFReg[0];
            AssignAttri("", false, "A707ComFReg", context.localUtil.Format(A707ComFReg, "99/99/99"));
            A249ComRef = T00363_A249ComRef[0];
            AssignAttri("", false, "A249ComRef", A249ComRef);
            A721ComOcSt = T00363_A721ComOcSt[0];
            AssignAttri("", false, "A721ComOcSt", StringUtil.Str( (decimal)(A721ComOcSt), 1, 0));
            A698ComDscto = T00363_A698ComDscto[0];
            AssignAttri("", false, "A698ComDscto", StringUtil.LTrimStr( A698ComDscto, 15, 2));
            A728ComRete1 = T00363_A728ComRete1[0];
            AssignAttri("", false, "A728ComRete1", StringUtil.LTrimStr( A728ComRete1, 15, 2));
            A729ComRete2 = T00363_A729ComRete2[0];
            AssignAttri("", false, "A729ComRete2", StringUtil.LTrimStr( A729ComRete2, 15, 2));
            A706ComFlete = T00363_A706ComFlete[0];
            AssignAttri("", false, "A706ComFlete", StringUtil.LTrimStr( A706ComFlete, 15, 2));
            A713ComISC = T00363_A713ComISC[0];
            AssignAttri("", false, "A713ComISC", StringUtil.LTrimStr( A713ComISC, 15, 2));
            A717ComPorIva = T00363_A717ComPorIva[0];
            AssignAttri("", false, "A717ComPorIva", StringUtil.LTrimStr( A717ComPorIva, 6, 2));
            A720ComObs = T00363_A720ComObs[0];
            AssignAttri("", false, "A720ComObs", A720ComObs);
            A714ComItem = T00363_A714ComItem[0];
            AssignAttri("", false, "A714ComItem", StringUtil.LTrimStr( (decimal)(A714ComItem), 4, 0));
            A718ComRedondeo = T00363_A718ComRedondeo[0];
            AssignAttri("", false, "A718ComRedondeo", StringUtil.LTrimStr( A718ComRedondeo, 15, 2));
            A740ComValor = T00363_A740ComValor[0];
            AssignAttri("", false, "A740ComValor", StringUtil.LTrimStr( A740ComValor, 15, 2));
            A741ComVouAno = T00363_A741ComVouAno[0];
            AssignAttri("", false, "A741ComVouAno", StringUtil.LTrimStr( (decimal)(A741ComVouAno), 4, 0));
            A742ComVouMes = T00363_A742ComVouMes[0];
            AssignAttri("", false, "A742ComVouMes", StringUtil.LTrimStr( (decimal)(A742ComVouMes), 2, 0));
            A734ComTASICod = T00363_A734ComTASICod[0];
            AssignAttri("", false, "A734ComTASICod", StringUtil.LTrimStr( (decimal)(A734ComTASICod), 6, 0));
            A743ComVouNum = T00363_A743ComVouNum[0];
            AssignAttri("", false, "A743ComVouNum", A743ComVouNum);
            A738ComUsuC = T00363_A738ComUsuC[0];
            AssignAttri("", false, "A738ComUsuC", A738ComUsuC);
            A702ComFecC = T00363_A702ComFecC[0];
            AssignAttri("", false, "A702ComFecC", context.localUtil.TToC( A702ComFecC, 8, 5, 0, 3, "/", ":", " "));
            A739ComUsuM = T00363_A739ComUsuM[0];
            AssignAttri("", false, "A739ComUsuM", A739ComUsuM);
            A703ComFecM = T00363_A703ComFecM[0];
            AssignAttri("", false, "A703ComFecM", context.localUtil.TToC( A703ComFecM, 8, 5, 0, 3, "/", ":", " "));
            A671ComAut = T00363_A671ComAut[0];
            AssignAttri("", false, "A671ComAut", StringUtil.Str( (decimal)(A671ComAut), 1, 0));
            A737ComUsuAut = T00363_A737ComUsuAut[0];
            AssignAttri("", false, "A737ComUsuAut", A737ComUsuAut);
            A701ComFecAut = T00363_A701ComFecAut[0];
            AssignAttri("", false, "A701ComFecAut", context.localUtil.TToC( A701ComFecAut, 8, 5, 0, 3, "/", ":", " "));
            A709ComImpAfec = T00363_A709ComImpAfec[0];
            AssignAttri("", false, "A709ComImpAfec", StringUtil.Str( (decimal)(A709ComImpAfec), 1, 0));
            A711ComImpTip = T00363_A711ComImpTip[0];
            AssignAttri("", false, "A711ComImpTip", StringUtil.Str( (decimal)(A711ComImpTip), 1, 0));
            A710ComImpCod = T00363_A710ComImpCod[0];
            AssignAttri("", false, "A710ComImpCod", A710ComImpCod);
            A712ComImpTipCos = T00363_A712ComImpTipCos[0];
            AssignAttri("", false, "A712ComImpTipCos", A712ComImpTipCos);
            A726ComRetAfecto = T00363_A726ComRetAfecto[0];
            AssignAttri("", false, "A726ComRetAfecto", StringUtil.Str( (decimal)(A726ComRetAfecto), 1, 0));
            A727ComRetCod = T00363_A727ComRetCod[0];
            AssignAttri("", false, "A727ComRetCod", A727ComRetCod);
            A730ComRetFec = T00363_A730ComRetFec[0];
            AssignAttri("", false, "A730ComRetFec", context.localUtil.Format(A730ComRetFec, "99/99/99"));
            A704ComFecPago = T00363_A704ComFecPago[0];
            AssignAttri("", false, "A704ComFecPago", context.localUtil.Format(A704ComFecPago, "99/99/99"));
            A735ComTipReg = T00363_A735ComTipReg[0];
            AssignAttri("", false, "A735ComTipReg", A735ComTipReg);
            A719ComIVADUA = T00363_A719ComIVADUA[0];
            AssignAttri("", false, "A719ComIVADUA", StringUtil.LTrimStr( A719ComIVADUA, 15, 2));
            A680ComCif = T00363_A680ComCif[0];
            AssignAttri("", false, "A680ComCif", StringUtil.Str( (decimal)(A680ComCif), 1, 0));
            A725ComRefTDoc = T00363_A725ComRefTDoc[0];
            AssignAttri("", false, "A725ComRefTDoc", A725ComRefTDoc);
            A722ComRefDoc = T00363_A722ComRefDoc[0];
            AssignAttri("", false, "A722ComRefDoc", A722ComRefDoc);
            A724ComRefFec = T00363_A724ComRefFec[0];
            AssignAttri("", false, "A724ComRefFec", context.localUtil.Format(A724ComRefFec, "99/99/99"));
            A705ComFlagRet = T00363_A705ComFlagRet[0];
            n705ComFlagRet = T00363_n705ComFlagRet[0];
            AssignAttri("", false, "A705ComFlagRet", StringUtil.Str( (decimal)(A705ComFlagRet), 1, 0));
            A672ComBanCod = T00363_A672ComBanCod[0];
            AssignAttri("", false, "A672ComBanCod", StringUtil.LTrimStr( (decimal)(A672ComBanCod), 6, 0));
            A674ComBanCta = T00363_A674ComBanCta[0];
            AssignAttri("", false, "A674ComBanCta", A674ComBanCta);
            A678ComBanReg = T00363_A678ComBanReg[0];
            AssignAttri("", false, "A678ComBanReg", A678ComBanReg);
            A676ComBanForCod = T00363_A676ComBanForCod[0];
            AssignAttri("", false, "A676ComBanForCod", StringUtil.LTrimStr( (decimal)(A676ComBanForCod), 6, 0));
            A677ComBanImp = T00363_A677ComBanImp[0];
            AssignAttri("", false, "A677ComBanImp", StringUtil.LTrimStr( A677ComBanImp, 15, 2));
            A675ComBanDoc = T00363_A675ComBanDoc[0];
            AssignAttri("", false, "A675ComBanDoc", A675ComBanDoc);
            A679ComBanTipC = T00363_A679ComBanTipC[0];
            AssignAttri("", false, "A679ComBanTipC", StringUtil.LTrimStr( A679ComBanTipC, 15, 5));
            A673ComBanConc = T00363_A673ComBanConc[0];
            AssignAttri("", false, "A673ComBanConc", StringUtil.LTrimStr( (decimal)(A673ComBanConc), 6, 0));
            A723ComRefDom = T00363_A723ComRefDom[0];
            A149TipCod = T00363_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A244PrvCod = T00363_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A246ComMon = T00363_A246ComMon[0];
            AssignAttri("", false, "A246ComMon", StringUtil.LTrimStr( (decimal)(A246ComMon), 6, 0));
            A245ComConpCod = T00363_A245ComConpCod[0];
            AssignAttri("", false, "A245ComConpCod", StringUtil.LTrimStr( (decimal)(A245ComConpCod), 6, 0));
            Z149TipCod = A149TipCod;
            Z243ComCod = A243ComCod;
            Z244PrvCod = A244PrvCod;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load36109( ) ;
            if ( AnyError == 1 )
            {
               RcdFound109 = 0;
               InitializeNonKey36109( ) ;
            }
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound109 = 0;
            InitializeNonKey36109( ) ;
            sMode109 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode109;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey36109( ) ;
         if ( RcdFound109 == 0 )
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
         RcdFound109 = 0;
         /* Using cursor T003619 */
         pr_default.execute(14, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T003619_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T003619_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003619_A243ComCod[0], A243ComCod) < 0 ) || ( StringUtil.StrCmp(T003619_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003619_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003619_A244PrvCod[0], A244PrvCod) < 0 ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T003619_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T003619_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003619_A243ComCod[0], A243ComCod) > 0 ) || ( StringUtil.StrCmp(T003619_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003619_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003619_A244PrvCod[0], A244PrvCod) > 0 ) ) )
            {
               A149TipCod = T003619_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = T003619_A243ComCod[0];
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = T003619_A244PrvCod[0];
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               RcdFound109 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound109 = 0;
         /* Using cursor T003620 */
         pr_default.execute(15, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T003620_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T003620_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003620_A243ComCod[0], A243ComCod) > 0 ) || ( StringUtil.StrCmp(T003620_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003620_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003620_A244PrvCod[0], A244PrvCod) > 0 ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T003620_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T003620_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003620_A243ComCod[0], A243ComCod) < 0 ) || ( StringUtil.StrCmp(T003620_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003620_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003620_A244PrvCod[0], A244PrvCod) < 0 ) ) )
            {
               A149TipCod = T003620_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = T003620_A243ComCod[0];
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = T003620_A244PrvCod[0];
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               RcdFound109 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey36109( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert36109( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound109 == 1 )
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) )
               {
                  A149TipCod = Z149TipCod;
                  AssignAttri("", false, "A149TipCod", A149TipCod);
                  A243ComCod = Z243ComCod;
                  AssignAttri("", false, "A243ComCod", A243ComCod);
                  A244PrvCod = Z244PrvCod;
                  AssignAttri("", false, "A244PrvCod", A244PrvCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update36109( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert36109( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert36109( ) ;
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
         if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) )
         {
            A149TipCod = Z149TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = Z243ComCod;
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = Z244PrvCod;
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipCod_Internalname;
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
         GetKey36109( ) ;
         if ( RcdFound109 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) )
            {
               A149TipCod = Z149TipCod;
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = Z243ComCod;
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = Z244PrvCod;
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCod_Internalname;
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
         context.RollbackDataStores("cpcompras",pr_default);
         GX_FocusControl = edtComFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_360( ) ;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtComFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart36109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd36109( ) ;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComFec_Internalname;
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
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComFec_Internalname;
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
         ScanStart36109( ) ;
         if ( RcdFound109 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound109 != 0 )
            {
               ScanNext36109( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd36109( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency36109( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00362 */
            pr_default.execute(0, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCOMPRAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z248ComFec ) != DateTimeUtil.ResetTime ( T00362_A248ComFec[0] ) ) || ( DateTimeUtil.ResetTime ( Z708ComFVcto ) != DateTimeUtil.ResetTime ( T00362_A708ComFVcto[0] ) ) || ( DateTimeUtil.ResetTime ( Z707ComFReg ) != DateTimeUtil.ResetTime ( T00362_A707ComFReg[0] ) ) || ( StringUtil.StrCmp(Z249ComRef, T00362_A249ComRef[0]) != 0 ) || ( Z721ComOcSt != T00362_A721ComOcSt[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z698ComDscto != T00362_A698ComDscto[0] ) || ( Z728ComRete1 != T00362_A728ComRete1[0] ) || ( Z729ComRete2 != T00362_A729ComRete2[0] ) || ( Z706ComFlete != T00362_A706ComFlete[0] ) || ( Z713ComISC != T00362_A713ComISC[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z717ComPorIva != T00362_A717ComPorIva[0] ) || ( Z714ComItem != T00362_A714ComItem[0] ) || ( Z718ComRedondeo != T00362_A718ComRedondeo[0] ) || ( Z740ComValor != T00362_A740ComValor[0] ) || ( Z741ComVouAno != T00362_A741ComVouAno[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z742ComVouMes != T00362_A742ComVouMes[0] ) || ( Z734ComTASICod != T00362_A734ComTASICod[0] ) || ( StringUtil.StrCmp(Z743ComVouNum, T00362_A743ComVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z738ComUsuC, T00362_A738ComUsuC[0]) != 0 ) || ( Z702ComFecC != T00362_A702ComFecC[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z739ComUsuM, T00362_A739ComUsuM[0]) != 0 ) || ( Z703ComFecM != T00362_A703ComFecM[0] ) || ( Z671ComAut != T00362_A671ComAut[0] ) || ( StringUtil.StrCmp(Z737ComUsuAut, T00362_A737ComUsuAut[0]) != 0 ) || ( Z701ComFecAut != T00362_A701ComFecAut[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z709ComImpAfec != T00362_A709ComImpAfec[0] ) || ( Z711ComImpTip != T00362_A711ComImpTip[0] ) || ( StringUtil.StrCmp(Z710ComImpCod, T00362_A710ComImpCod[0]) != 0 ) || ( StringUtil.StrCmp(Z712ComImpTipCos, T00362_A712ComImpTipCos[0]) != 0 ) || ( Z726ComRetAfecto != T00362_A726ComRetAfecto[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z727ComRetCod, T00362_A727ComRetCod[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z730ComRetFec ) != DateTimeUtil.ResetTime ( T00362_A730ComRetFec[0] ) ) || ( DateTimeUtil.ResetTime ( Z704ComFecPago ) != DateTimeUtil.ResetTime ( T00362_A704ComFecPago[0] ) ) || ( StringUtil.StrCmp(Z735ComTipReg, T00362_A735ComTipReg[0]) != 0 ) || ( Z719ComIVADUA != T00362_A719ComIVADUA[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z680ComCif != T00362_A680ComCif[0] ) || ( StringUtil.StrCmp(Z725ComRefTDoc, T00362_A725ComRefTDoc[0]) != 0 ) || ( StringUtil.StrCmp(Z722ComRefDoc, T00362_A722ComRefDoc[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z724ComRefFec ) != DateTimeUtil.ResetTime ( T00362_A724ComRefFec[0] ) ) || ( Z705ComFlagRet != T00362_A705ComFlagRet[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z672ComBanCod != T00362_A672ComBanCod[0] ) || ( StringUtil.StrCmp(Z674ComBanCta, T00362_A674ComBanCta[0]) != 0 ) || ( StringUtil.StrCmp(Z678ComBanReg, T00362_A678ComBanReg[0]) != 0 ) || ( Z676ComBanForCod != T00362_A676ComBanForCod[0] ) || ( Z677ComBanImp != T00362_A677ComBanImp[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z675ComBanDoc, T00362_A675ComBanDoc[0]) != 0 ) || ( Z679ComBanTipC != T00362_A679ComBanTipC[0] ) || ( Z673ComBanConc != T00362_A673ComBanConc[0] ) || ( StringUtil.StrCmp(Z723ComRefDom, T00362_A723ComRefDom[0]) != 0 ) || ( Z246ComMon != T00362_A246ComMon[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z245ComConpCod != T00362_A245ComConpCod[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z248ComFec ) != DateTimeUtil.ResetTime ( T00362_A248ComFec[0] ) )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFec");
                  GXUtil.WriteLogRaw("Old: ",Z248ComFec);
                  GXUtil.WriteLogRaw("Current: ",T00362_A248ComFec[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z708ComFVcto ) != DateTimeUtil.ResetTime ( T00362_A708ComFVcto[0] ) )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFVcto");
                  GXUtil.WriteLogRaw("Old: ",Z708ComFVcto);
                  GXUtil.WriteLogRaw("Current: ",T00362_A708ComFVcto[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z707ComFReg ) != DateTimeUtil.ResetTime ( T00362_A707ComFReg[0] ) )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFReg");
                  GXUtil.WriteLogRaw("Old: ",Z707ComFReg);
                  GXUtil.WriteLogRaw("Current: ",T00362_A707ComFReg[0]);
               }
               if ( StringUtil.StrCmp(Z249ComRef, T00362_A249ComRef[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRef");
                  GXUtil.WriteLogRaw("Old: ",Z249ComRef);
                  GXUtil.WriteLogRaw("Current: ",T00362_A249ComRef[0]);
               }
               if ( Z721ComOcSt != T00362_A721ComOcSt[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComOcSt");
                  GXUtil.WriteLogRaw("Old: ",Z721ComOcSt);
                  GXUtil.WriteLogRaw("Current: ",T00362_A721ComOcSt[0]);
               }
               if ( Z698ComDscto != T00362_A698ComDscto[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComDscto");
                  GXUtil.WriteLogRaw("Old: ",Z698ComDscto);
                  GXUtil.WriteLogRaw("Current: ",T00362_A698ComDscto[0]);
               }
               if ( Z728ComRete1 != T00362_A728ComRete1[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRete1");
                  GXUtil.WriteLogRaw("Old: ",Z728ComRete1);
                  GXUtil.WriteLogRaw("Current: ",T00362_A728ComRete1[0]);
               }
               if ( Z729ComRete2 != T00362_A729ComRete2[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRete2");
                  GXUtil.WriteLogRaw("Old: ",Z729ComRete2);
                  GXUtil.WriteLogRaw("Current: ",T00362_A729ComRete2[0]);
               }
               if ( Z706ComFlete != T00362_A706ComFlete[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFlete");
                  GXUtil.WriteLogRaw("Old: ",Z706ComFlete);
                  GXUtil.WriteLogRaw("Current: ",T00362_A706ComFlete[0]);
               }
               if ( Z713ComISC != T00362_A713ComISC[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComISC");
                  GXUtil.WriteLogRaw("Old: ",Z713ComISC);
                  GXUtil.WriteLogRaw("Current: ",T00362_A713ComISC[0]);
               }
               if ( Z717ComPorIva != T00362_A717ComPorIva[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComPorIva");
                  GXUtil.WriteLogRaw("Old: ",Z717ComPorIva);
                  GXUtil.WriteLogRaw("Current: ",T00362_A717ComPorIva[0]);
               }
               if ( Z714ComItem != T00362_A714ComItem[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComItem");
                  GXUtil.WriteLogRaw("Old: ",Z714ComItem);
                  GXUtil.WriteLogRaw("Current: ",T00362_A714ComItem[0]);
               }
               if ( Z718ComRedondeo != T00362_A718ComRedondeo[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRedondeo");
                  GXUtil.WriteLogRaw("Old: ",Z718ComRedondeo);
                  GXUtil.WriteLogRaw("Current: ",T00362_A718ComRedondeo[0]);
               }
               if ( Z740ComValor != T00362_A740ComValor[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComValor");
                  GXUtil.WriteLogRaw("Old: ",Z740ComValor);
                  GXUtil.WriteLogRaw("Current: ",T00362_A740ComValor[0]);
               }
               if ( Z741ComVouAno != T00362_A741ComVouAno[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z741ComVouAno);
                  GXUtil.WriteLogRaw("Current: ",T00362_A741ComVouAno[0]);
               }
               if ( Z742ComVouMes != T00362_A742ComVouMes[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z742ComVouMes);
                  GXUtil.WriteLogRaw("Current: ",T00362_A742ComVouMes[0]);
               }
               if ( Z734ComTASICod != T00362_A734ComTASICod[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComTASICod");
                  GXUtil.WriteLogRaw("Old: ",Z734ComTASICod);
                  GXUtil.WriteLogRaw("Current: ",T00362_A734ComTASICod[0]);
               }
               if ( StringUtil.StrCmp(Z743ComVouNum, T00362_A743ComVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z743ComVouNum);
                  GXUtil.WriteLogRaw("Current: ",T00362_A743ComVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z738ComUsuC, T00362_A738ComUsuC[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComUsuC");
                  GXUtil.WriteLogRaw("Old: ",Z738ComUsuC);
                  GXUtil.WriteLogRaw("Current: ",T00362_A738ComUsuC[0]);
               }
               if ( Z702ComFecC != T00362_A702ComFecC[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFecC");
                  GXUtil.WriteLogRaw("Old: ",Z702ComFecC);
                  GXUtil.WriteLogRaw("Current: ",T00362_A702ComFecC[0]);
               }
               if ( StringUtil.StrCmp(Z739ComUsuM, T00362_A739ComUsuM[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComUsuM");
                  GXUtil.WriteLogRaw("Old: ",Z739ComUsuM);
                  GXUtil.WriteLogRaw("Current: ",T00362_A739ComUsuM[0]);
               }
               if ( Z703ComFecM != T00362_A703ComFecM[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFecM");
                  GXUtil.WriteLogRaw("Old: ",Z703ComFecM);
                  GXUtil.WriteLogRaw("Current: ",T00362_A703ComFecM[0]);
               }
               if ( Z671ComAut != T00362_A671ComAut[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComAut");
                  GXUtil.WriteLogRaw("Old: ",Z671ComAut);
                  GXUtil.WriteLogRaw("Current: ",T00362_A671ComAut[0]);
               }
               if ( StringUtil.StrCmp(Z737ComUsuAut, T00362_A737ComUsuAut[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComUsuAut");
                  GXUtil.WriteLogRaw("Old: ",Z737ComUsuAut);
                  GXUtil.WriteLogRaw("Current: ",T00362_A737ComUsuAut[0]);
               }
               if ( Z701ComFecAut != T00362_A701ComFecAut[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFecAut");
                  GXUtil.WriteLogRaw("Old: ",Z701ComFecAut);
                  GXUtil.WriteLogRaw("Current: ",T00362_A701ComFecAut[0]);
               }
               if ( Z709ComImpAfec != T00362_A709ComImpAfec[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComImpAfec");
                  GXUtil.WriteLogRaw("Old: ",Z709ComImpAfec);
                  GXUtil.WriteLogRaw("Current: ",T00362_A709ComImpAfec[0]);
               }
               if ( Z711ComImpTip != T00362_A711ComImpTip[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComImpTip");
                  GXUtil.WriteLogRaw("Old: ",Z711ComImpTip);
                  GXUtil.WriteLogRaw("Current: ",T00362_A711ComImpTip[0]);
               }
               if ( StringUtil.StrCmp(Z710ComImpCod, T00362_A710ComImpCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComImpCod");
                  GXUtil.WriteLogRaw("Old: ",Z710ComImpCod);
                  GXUtil.WriteLogRaw("Current: ",T00362_A710ComImpCod[0]);
               }
               if ( StringUtil.StrCmp(Z712ComImpTipCos, T00362_A712ComImpTipCos[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComImpTipCos");
                  GXUtil.WriteLogRaw("Old: ",Z712ComImpTipCos);
                  GXUtil.WriteLogRaw("Current: ",T00362_A712ComImpTipCos[0]);
               }
               if ( Z726ComRetAfecto != T00362_A726ComRetAfecto[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRetAfecto");
                  GXUtil.WriteLogRaw("Old: ",Z726ComRetAfecto);
                  GXUtil.WriteLogRaw("Current: ",T00362_A726ComRetAfecto[0]);
               }
               if ( StringUtil.StrCmp(Z727ComRetCod, T00362_A727ComRetCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRetCod");
                  GXUtil.WriteLogRaw("Old: ",Z727ComRetCod);
                  GXUtil.WriteLogRaw("Current: ",T00362_A727ComRetCod[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z730ComRetFec ) != DateTimeUtil.ResetTime ( T00362_A730ComRetFec[0] ) )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRetFec");
                  GXUtil.WriteLogRaw("Old: ",Z730ComRetFec);
                  GXUtil.WriteLogRaw("Current: ",T00362_A730ComRetFec[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z704ComFecPago ) != DateTimeUtil.ResetTime ( T00362_A704ComFecPago[0] ) )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFecPago");
                  GXUtil.WriteLogRaw("Old: ",Z704ComFecPago);
                  GXUtil.WriteLogRaw("Current: ",T00362_A704ComFecPago[0]);
               }
               if ( StringUtil.StrCmp(Z735ComTipReg, T00362_A735ComTipReg[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComTipReg");
                  GXUtil.WriteLogRaw("Old: ",Z735ComTipReg);
                  GXUtil.WriteLogRaw("Current: ",T00362_A735ComTipReg[0]);
               }
               if ( Z719ComIVADUA != T00362_A719ComIVADUA[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComIVADUA");
                  GXUtil.WriteLogRaw("Old: ",Z719ComIVADUA);
                  GXUtil.WriteLogRaw("Current: ",T00362_A719ComIVADUA[0]);
               }
               if ( Z680ComCif != T00362_A680ComCif[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComCif");
                  GXUtil.WriteLogRaw("Old: ",Z680ComCif);
                  GXUtil.WriteLogRaw("Current: ",T00362_A680ComCif[0]);
               }
               if ( StringUtil.StrCmp(Z725ComRefTDoc, T00362_A725ComRefTDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRefTDoc");
                  GXUtil.WriteLogRaw("Old: ",Z725ComRefTDoc);
                  GXUtil.WriteLogRaw("Current: ",T00362_A725ComRefTDoc[0]);
               }
               if ( StringUtil.StrCmp(Z722ComRefDoc, T00362_A722ComRefDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRefDoc");
                  GXUtil.WriteLogRaw("Old: ",Z722ComRefDoc);
                  GXUtil.WriteLogRaw("Current: ",T00362_A722ComRefDoc[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z724ComRefFec ) != DateTimeUtil.ResetTime ( T00362_A724ComRefFec[0] ) )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRefFec");
                  GXUtil.WriteLogRaw("Old: ",Z724ComRefFec);
                  GXUtil.WriteLogRaw("Current: ",T00362_A724ComRefFec[0]);
               }
               if ( Z705ComFlagRet != T00362_A705ComFlagRet[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComFlagRet");
                  GXUtil.WriteLogRaw("Old: ",Z705ComFlagRet);
                  GXUtil.WriteLogRaw("Current: ",T00362_A705ComFlagRet[0]);
               }
               if ( Z672ComBanCod != T00362_A672ComBanCod[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanCod");
                  GXUtil.WriteLogRaw("Old: ",Z672ComBanCod);
                  GXUtil.WriteLogRaw("Current: ",T00362_A672ComBanCod[0]);
               }
               if ( StringUtil.StrCmp(Z674ComBanCta, T00362_A674ComBanCta[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanCta");
                  GXUtil.WriteLogRaw("Old: ",Z674ComBanCta);
                  GXUtil.WriteLogRaw("Current: ",T00362_A674ComBanCta[0]);
               }
               if ( StringUtil.StrCmp(Z678ComBanReg, T00362_A678ComBanReg[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanReg");
                  GXUtil.WriteLogRaw("Old: ",Z678ComBanReg);
                  GXUtil.WriteLogRaw("Current: ",T00362_A678ComBanReg[0]);
               }
               if ( Z676ComBanForCod != T00362_A676ComBanForCod[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanForCod");
                  GXUtil.WriteLogRaw("Old: ",Z676ComBanForCod);
                  GXUtil.WriteLogRaw("Current: ",T00362_A676ComBanForCod[0]);
               }
               if ( Z677ComBanImp != T00362_A677ComBanImp[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanImp");
                  GXUtil.WriteLogRaw("Old: ",Z677ComBanImp);
                  GXUtil.WriteLogRaw("Current: ",T00362_A677ComBanImp[0]);
               }
               if ( StringUtil.StrCmp(Z675ComBanDoc, T00362_A675ComBanDoc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanDoc");
                  GXUtil.WriteLogRaw("Old: ",Z675ComBanDoc);
                  GXUtil.WriteLogRaw("Current: ",T00362_A675ComBanDoc[0]);
               }
               if ( Z679ComBanTipC != T00362_A679ComBanTipC[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanTipC");
                  GXUtil.WriteLogRaw("Old: ",Z679ComBanTipC);
                  GXUtil.WriteLogRaw("Current: ",T00362_A679ComBanTipC[0]);
               }
               if ( Z673ComBanConc != T00362_A673ComBanConc[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComBanConc");
                  GXUtil.WriteLogRaw("Old: ",Z673ComBanConc);
                  GXUtil.WriteLogRaw("Current: ",T00362_A673ComBanConc[0]);
               }
               if ( StringUtil.StrCmp(Z723ComRefDom, T00362_A723ComRefDom[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComRefDom");
                  GXUtil.WriteLogRaw("Old: ",Z723ComRefDom);
                  GXUtil.WriteLogRaw("Current: ",T00362_A723ComRefDom[0]);
               }
               if ( Z246ComMon != T00362_A246ComMon[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComMon");
                  GXUtil.WriteLogRaw("Old: ",Z246ComMon);
                  GXUtil.WriteLogRaw("Current: ",T00362_A246ComMon[0]);
               }
               if ( Z245ComConpCod != T00362_A245ComConpCod[0] )
               {
                  GXUtil.WriteLog("cpcompras:[seudo value changed for attri]"+"ComConpCod");
                  GXUtil.WriteLogRaw("Old: ",Z245ComConpCod);
                  GXUtil.WriteLogRaw("Current: ",T00362_A245ComConpCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPCOMPRAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert36109( )
      {
         BeforeValidate36109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable36109( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM36109( 0) ;
            CheckOptimisticConcurrency36109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm36109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert36109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003621 */
                     pr_default.execute(16, new Object[] {A247PrvDsc, A243ComCod, A248ComFec, A708ComFVcto, A707ComFReg, A249ComRef, A721ComOcSt, A698ComDscto, A728ComRete1, A729ComRete2, A706ComFlete, A713ComISC, A717ComPorIva, A720ComObs, A714ComItem, A718ComRedondeo, A740ComValor, A741ComVouAno, A742ComVouMes, A734ComTASICod, A743ComVouNum, A738ComUsuC, A702ComFecC, A739ComUsuM, A703ComFecM, A671ComAut, A737ComUsuAut, A701ComFecAut, A709ComImpAfec, A711ComImpTip, A710ComImpCod, A712ComImpTipCos, A726ComRetAfecto, A727ComRetCod, A730ComRetFec, A704ComFecPago, A735ComTipReg, A719ComIVADUA, A680ComCif, A725ComRefTDoc, A722ComRefDoc, A724ComRefFec, n705ComFlagRet, A705ComFlagRet, A672ComBanCod, A674ComBanCta, A678ComBanReg, A676ComBanForCod, A677ComBanImp, A675ComBanDoc, A679ComBanTipC, A673ComBanConc, A723ComRefDom, A149TipCod, A244PrvCod, A246ComMon, A245ComConpCod});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRAS");
                     if ( (pr_default.getStatus(16) == 1) )
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
                           ResetCaption360( ) ;
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
               Load36109( ) ;
            }
            EndLevel36109( ) ;
         }
         CloseExtendedTableCursors36109( ) ;
      }

      protected void Update36109( )
      {
         BeforeValidate36109( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable36109( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency36109( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm36109( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate36109( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003622 */
                     pr_default.execute(17, new Object[] {A247PrvDsc, A248ComFec, A708ComFVcto, A707ComFReg, A249ComRef, A721ComOcSt, A698ComDscto, A728ComRete1, A729ComRete2, A706ComFlete, A713ComISC, A717ComPorIva, A720ComObs, A714ComItem, A718ComRedondeo, A740ComValor, A741ComVouAno, A742ComVouMes, A734ComTASICod, A743ComVouNum, A738ComUsuC, A702ComFecC, A739ComUsuM, A703ComFecM, A671ComAut, A737ComUsuAut, A701ComFecAut, A709ComImpAfec, A711ComImpTip, A710ComImpCod, A712ComImpTipCos, A726ComRetAfecto, A727ComRetCod, A730ComRetFec, A704ComFecPago, A735ComTipReg, A719ComIVADUA, A680ComCif, A725ComRefTDoc, A722ComRefDoc, A724ComRefFec, n705ComFlagRet, A705ComFlagRet, A672ComBanCod, A674ComBanCta, A678ComBanReg, A676ComBanForCod, A677ComBanImp, A675ComBanDoc, A679ComBanTipC, A673ComBanConc, A723ComRefDom, A246ComMon, A245ComConpCod, A149TipCod, A243ComCod, A244PrvCod});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRAS");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCOMPRAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate36109( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption360( ) ;
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
            EndLevel36109( ) ;
         }
         CloseExtendedTableCursors36109( ) ;
      }

      protected void DeferredUpdate36109( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate36109( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency36109( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls36109( ) ;
            AfterConfirm36109( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete36109( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003623 */
                  pr_default.execute(18, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound109 == 0 )
                        {
                           InitAll36109( ) ;
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
                        ResetCaption360( ) ;
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
         sMode109 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel36109( ) ;
         Gx_mode = sMode109;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls36109( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T003624 */
            pr_default.execute(19, new Object[] {A244PrvCod});
            A247PrvDsc = T003624_A247PrvDsc[0];
            AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
            pr_default.close(19);
            /* Using cursor T003626 */
            pr_default.execute(20, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               A716ComSubAfe = T003626_A716ComSubAfe[0];
               A732ComSubIna = T003626_A732ComSubIna[0];
               A731ComSubImportacion = T003626_A731ComSubImportacion[0];
            }
            else
            {
               A716ComSubAfe = 0;
               AssignAttri("", false, "A716ComSubAfe", StringUtil.LTrimStr( A716ComSubAfe, 15, 2));
               A732ComSubIna = 0;
               AssignAttri("", false, "A732ComSubIna", StringUtil.LTrimStr( A732ComSubIna, 15, 2));
               A731ComSubImportacion = 0;
               AssignAttri("", false, "A731ComSubImportacion", StringUtil.LTrimStr( A731ComSubImportacion, 15, 2));
            }
            pr_default.close(20);
            /* Using cursor T003627 */
            pr_default.execute(21, new Object[] {A245ComConpCod});
            A681ComConpAbr = T003627_A681ComConpAbr[0];
            A682ComConpDias = T003627_A682ComConpDias[0];
            pr_default.close(21);
            A733ComSubTotal = (decimal)(NumberUtil.Round( A716ComSubAfe+A732ComSubIna+A713ComISC+A706ComFlete, 2)-NumberUtil.Round( A698ComDscto+A728ComRete1+A729ComRete2, 2));
            AssignAttri("", false, "A733ComSubTotal", StringUtil.LTrimStr( A733ComSubTotal, 15, 2));
            A715ComIva = (decimal)(NumberUtil.Round( (NumberUtil.Round( (A716ComSubAfe+A706ComFlete+A713ComISC)-A698ComDscto, 2)*A717ComPorIva)/ (decimal)(100), 2)+A718ComRedondeo+A719ComIVADUA);
            AssignAttri("", false, "A715ComIva", StringUtil.LTrimStr( A715ComIva, 15, 2));
            A736ComTotal = (decimal)((A733ComSubTotal+A715ComIva));
            AssignAttri("", false, "A736ComTotal", StringUtil.LTrimStr( A736ComTotal, 15, 2));
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T003628 */
            pr_default.execute(22, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
         }
      }

      protected void EndLevel36109( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete36109( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(21);
            pr_default.close(20);
            context.CommitDataStores("cpcompras",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues360( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(21);
            pr_default.close(20);
            context.RollbackDataStores("cpcompras",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart36109( )
      {
         /* Using cursor T003629 */
         pr_default.execute(23);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound109 = 1;
            A149TipCod = T003629_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = T003629_A243ComCod[0];
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = T003629_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext36109( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound109 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound109 = 1;
            A149TipCod = T003629_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = T003629_A243ComCod[0];
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = T003629_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
         }
      }

      protected void ScanEnd36109( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm36109( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert36109( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate36109( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete36109( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete36109( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate36109( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes36109( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtComCod_Enabled = 0;
         AssignProp("", false, edtComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComCod_Enabled), 5, 0), true);
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtComFec_Enabled = 0;
         AssignProp("", false, edtComFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFec_Enabled), 5, 0), true);
         edtComFVcto_Enabled = 0;
         AssignProp("", false, edtComFVcto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFVcto_Enabled), 5, 0), true);
         edtComFReg_Enabled = 0;
         AssignProp("", false, edtComFReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFReg_Enabled), 5, 0), true);
         edtComMon_Enabled = 0;
         AssignProp("", false, edtComMon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComMon_Enabled), 5, 0), true);
         edtComConpCod_Enabled = 0;
         AssignProp("", false, edtComConpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComConpCod_Enabled), 5, 0), true);
         edtComRef_Enabled = 0;
         AssignProp("", false, edtComRef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRef_Enabled), 5, 0), true);
         edtComOcSt_Enabled = 0;
         AssignProp("", false, edtComOcSt_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComOcSt_Enabled), 5, 0), true);
         edtComDscto_Enabled = 0;
         AssignProp("", false, edtComDscto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDscto_Enabled), 5, 0), true);
         edtComRete1_Enabled = 0;
         AssignProp("", false, edtComRete1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRete1_Enabled), 5, 0), true);
         edtComRete2_Enabled = 0;
         AssignProp("", false, edtComRete2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRete2_Enabled), 5, 0), true);
         edtComFlete_Enabled = 0;
         AssignProp("", false, edtComFlete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFlete_Enabled), 5, 0), true);
         edtComISC_Enabled = 0;
         AssignProp("", false, edtComISC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComISC_Enabled), 5, 0), true);
         edtComPorIva_Enabled = 0;
         AssignProp("", false, edtComPorIva_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComPorIva_Enabled), 5, 0), true);
         edtComObs_Enabled = 0;
         AssignProp("", false, edtComObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComObs_Enabled), 5, 0), true);
         edtComItem_Enabled = 0;
         AssignProp("", false, edtComItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComItem_Enabled), 5, 0), true);
         edtComRedondeo_Enabled = 0;
         AssignProp("", false, edtComRedondeo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRedondeo_Enabled), 5, 0), true);
         edtComValor_Enabled = 0;
         AssignProp("", false, edtComValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComValor_Enabled), 5, 0), true);
         edtPrvDsc_Enabled = 0;
         AssignProp("", false, edtPrvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvDsc_Enabled), 5, 0), true);
         edtComVouAno_Enabled = 0;
         AssignProp("", false, edtComVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComVouAno_Enabled), 5, 0), true);
         edtComVouMes_Enabled = 0;
         AssignProp("", false, edtComVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComVouMes_Enabled), 5, 0), true);
         edtComTASICod_Enabled = 0;
         AssignProp("", false, edtComTASICod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComTASICod_Enabled), 5, 0), true);
         edtComVouNum_Enabled = 0;
         AssignProp("", false, edtComVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComVouNum_Enabled), 5, 0), true);
         edtComUsuC_Enabled = 0;
         AssignProp("", false, edtComUsuC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComUsuC_Enabled), 5, 0), true);
         edtComFecC_Enabled = 0;
         AssignProp("", false, edtComFecC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFecC_Enabled), 5, 0), true);
         edtComUsuM_Enabled = 0;
         AssignProp("", false, edtComUsuM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComUsuM_Enabled), 5, 0), true);
         edtComFecM_Enabled = 0;
         AssignProp("", false, edtComFecM_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFecM_Enabled), 5, 0), true);
         edtComAut_Enabled = 0;
         AssignProp("", false, edtComAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComAut_Enabled), 5, 0), true);
         edtComUsuAut_Enabled = 0;
         AssignProp("", false, edtComUsuAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComUsuAut_Enabled), 5, 0), true);
         edtComFecAut_Enabled = 0;
         AssignProp("", false, edtComFecAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFecAut_Enabled), 5, 0), true);
         edtComImpAfec_Enabled = 0;
         AssignProp("", false, edtComImpAfec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComImpAfec_Enabled), 5, 0), true);
         edtComImpTip_Enabled = 0;
         AssignProp("", false, edtComImpTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComImpTip_Enabled), 5, 0), true);
         edtComImpCod_Enabled = 0;
         AssignProp("", false, edtComImpCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComImpCod_Enabled), 5, 0), true);
         edtComImpTipCos_Enabled = 0;
         AssignProp("", false, edtComImpTipCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComImpTipCos_Enabled), 5, 0), true);
         edtComRetAfecto_Enabled = 0;
         AssignProp("", false, edtComRetAfecto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRetAfecto_Enabled), 5, 0), true);
         edtComRetCod_Enabled = 0;
         AssignProp("", false, edtComRetCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRetCod_Enabled), 5, 0), true);
         edtComRetFec_Enabled = 0;
         AssignProp("", false, edtComRetFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRetFec_Enabled), 5, 0), true);
         edtComFecPago_Enabled = 0;
         AssignProp("", false, edtComFecPago_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFecPago_Enabled), 5, 0), true);
         edtComTipReg_Enabled = 0;
         AssignProp("", false, edtComTipReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComTipReg_Enabled), 5, 0), true);
         edtComIVADUA_Enabled = 0;
         AssignProp("", false, edtComIVADUA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComIVADUA_Enabled), 5, 0), true);
         edtComCif_Enabled = 0;
         AssignProp("", false, edtComCif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComCif_Enabled), 5, 0), true);
         edtComRefTDoc_Enabled = 0;
         AssignProp("", false, edtComRefTDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRefTDoc_Enabled), 5, 0), true);
         edtComRefDoc_Enabled = 0;
         AssignProp("", false, edtComRefDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRefDoc_Enabled), 5, 0), true);
         edtComRefFec_Enabled = 0;
         AssignProp("", false, edtComRefFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComRefFec_Enabled), 5, 0), true);
         edtComFlagRet_Enabled = 0;
         AssignProp("", false, edtComFlagRet_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComFlagRet_Enabled), 5, 0), true);
         edtComBanCod_Enabled = 0;
         AssignProp("", false, edtComBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanCod_Enabled), 5, 0), true);
         edtComBanCta_Enabled = 0;
         AssignProp("", false, edtComBanCta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanCta_Enabled), 5, 0), true);
         edtComBanReg_Enabled = 0;
         AssignProp("", false, edtComBanReg_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanReg_Enabled), 5, 0), true);
         edtComBanForCod_Enabled = 0;
         AssignProp("", false, edtComBanForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanForCod_Enabled), 5, 0), true);
         edtComBanImp_Enabled = 0;
         AssignProp("", false, edtComBanImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanImp_Enabled), 5, 0), true);
         edtComBanDoc_Enabled = 0;
         AssignProp("", false, edtComBanDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanDoc_Enabled), 5, 0), true);
         edtComBanTipC_Enabled = 0;
         AssignProp("", false, edtComBanTipC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanTipC_Enabled), 5, 0), true);
         edtComBanConc_Enabled = 0;
         AssignProp("", false, edtComBanConc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComBanConc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes36109( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues360( )
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
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpcompras.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CPCOMPRAS");
         forbiddenHiddens.Add("ComRefDom", StringUtil.RTrim( context.localUtil.Format( A723ComRefDom, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cpcompras:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z243ComCod", StringUtil.RTrim( Z243ComCod));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z248ComFec", context.localUtil.DToC( Z248ComFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z708ComFVcto", context.localUtil.DToC( Z708ComFVcto, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z707ComFReg", context.localUtil.DToC( Z707ComFReg, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z249ComRef", StringUtil.RTrim( Z249ComRef));
         GxWebStd.gx_hidden_field( context, "Z721ComOcSt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z721ComOcSt), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z698ComDscto", StringUtil.LTrim( StringUtil.NToC( Z698ComDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z728ComRete1", StringUtil.LTrim( StringUtil.NToC( Z728ComRete1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z729ComRete2", StringUtil.LTrim( StringUtil.NToC( Z729ComRete2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z706ComFlete", StringUtil.LTrim( StringUtil.NToC( Z706ComFlete, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z713ComISC", StringUtil.LTrim( StringUtil.NToC( Z713ComISC, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z717ComPorIva", StringUtil.LTrim( StringUtil.NToC( Z717ComPorIva, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z714ComItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z714ComItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z718ComRedondeo", StringUtil.LTrim( StringUtil.NToC( Z718ComRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z740ComValor", StringUtil.LTrim( StringUtil.NToC( Z740ComValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z741ComVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z741ComVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z742ComVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z742ComVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z734ComTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z734ComTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z743ComVouNum", StringUtil.RTrim( Z743ComVouNum));
         GxWebStd.gx_hidden_field( context, "Z738ComUsuC", StringUtil.RTrim( Z738ComUsuC));
         GxWebStd.gx_hidden_field( context, "Z702ComFecC", context.localUtil.TToC( Z702ComFecC, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z739ComUsuM", StringUtil.RTrim( Z739ComUsuM));
         GxWebStd.gx_hidden_field( context, "Z703ComFecM", context.localUtil.TToC( Z703ComFecM, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z671ComAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z671ComAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z737ComUsuAut", StringUtil.RTrim( Z737ComUsuAut));
         GxWebStd.gx_hidden_field( context, "Z701ComFecAut", context.localUtil.TToC( Z701ComFecAut, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z709ComImpAfec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z709ComImpAfec), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z711ComImpTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z711ComImpTip), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z710ComImpCod", StringUtil.RTrim( Z710ComImpCod));
         GxWebStd.gx_hidden_field( context, "Z712ComImpTipCos", StringUtil.RTrim( Z712ComImpTipCos));
         GxWebStd.gx_hidden_field( context, "Z726ComRetAfecto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z726ComRetAfecto), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z727ComRetCod", StringUtil.RTrim( Z727ComRetCod));
         GxWebStd.gx_hidden_field( context, "Z730ComRetFec", context.localUtil.DToC( Z730ComRetFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z704ComFecPago", context.localUtil.DToC( Z704ComFecPago, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z735ComTipReg", StringUtil.RTrim( Z735ComTipReg));
         GxWebStd.gx_hidden_field( context, "Z719ComIVADUA", StringUtil.LTrim( StringUtil.NToC( Z719ComIVADUA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z680ComCif", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z680ComCif), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z725ComRefTDoc", StringUtil.RTrim( Z725ComRefTDoc));
         GxWebStd.gx_hidden_field( context, "Z722ComRefDoc", StringUtil.RTrim( Z722ComRefDoc));
         GxWebStd.gx_hidden_field( context, "Z724ComRefFec", context.localUtil.DToC( Z724ComRefFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z705ComFlagRet", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z705ComFlagRet), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z672ComBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z672ComBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z674ComBanCta", StringUtil.RTrim( Z674ComBanCta));
         GxWebStd.gx_hidden_field( context, "Z678ComBanReg", StringUtil.RTrim( Z678ComBanReg));
         GxWebStd.gx_hidden_field( context, "Z676ComBanForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z676ComBanForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z677ComBanImp", StringUtil.LTrim( StringUtil.NToC( Z677ComBanImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z675ComBanDoc", StringUtil.RTrim( Z675ComBanDoc));
         GxWebStd.gx_hidden_field( context, "Z679ComBanTipC", StringUtil.LTrim( StringUtil.NToC( Z679ComBanTipC, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z673ComBanConc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z673ComBanConc), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z723ComRefDom", Z723ComRefDom);
         GxWebStd.gx_hidden_field( context, "Z246ComMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z246ComMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z245ComConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z245ComConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "COMSUBAFE", StringUtil.LTrim( StringUtil.NToC( A716ComSubAfe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMSUBINA", StringUtil.LTrim( StringUtil.NToC( A732ComSubIna, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMSUBTOTAL", StringUtil.LTrim( StringUtil.NToC( A733ComSubTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMIVA", StringUtil.LTrim( StringUtil.NToC( A715ComIva, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMTOTAL", StringUtil.LTrim( StringUtil.NToC( A736ComTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMREFDOM", A723ComRefDom);
         GxWebStd.gx_hidden_field( context, "COMCONPABR", StringUtil.RTrim( A681ComConpAbr));
         GxWebStd.gx_hidden_field( context, "COMCONPDIAS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A682ComConpDias), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMSUBIMPORTACION", StringUtil.LTrim( StringUtil.NToC( A731ComSubImportacion, 15, 2, ".", "")));
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
         return formatLink("cpcompras.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPCOMPRAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Compras - Cabecera" ;
      }

      protected void InitializeNonKey36109( )
      {
         A736ComTotal = 0;
         AssignAttri("", false, "A736ComTotal", StringUtil.LTrimStr( A736ComTotal, 15, 2));
         A715ComIva = 0;
         AssignAttri("", false, "A715ComIva", StringUtil.LTrimStr( A715ComIva, 15, 2));
         A733ComSubTotal = 0;
         AssignAttri("", false, "A733ComSubTotal", StringUtil.LTrimStr( A733ComSubTotal, 15, 2));
         A248ComFec = DateTime.MinValue;
         AssignAttri("", false, "A248ComFec", context.localUtil.Format(A248ComFec, "99/99/99"));
         A708ComFVcto = DateTime.MinValue;
         AssignAttri("", false, "A708ComFVcto", context.localUtil.Format(A708ComFVcto, "99/99/99"));
         A707ComFReg = DateTime.MinValue;
         AssignAttri("", false, "A707ComFReg", context.localUtil.Format(A707ComFReg, "99/99/99"));
         A246ComMon = 0;
         AssignAttri("", false, "A246ComMon", StringUtil.LTrimStr( (decimal)(A246ComMon), 6, 0));
         A245ComConpCod = 0;
         AssignAttri("", false, "A245ComConpCod", StringUtil.LTrimStr( (decimal)(A245ComConpCod), 6, 0));
         A249ComRef = "";
         AssignAttri("", false, "A249ComRef", A249ComRef);
         A721ComOcSt = 0;
         AssignAttri("", false, "A721ComOcSt", StringUtil.Str( (decimal)(A721ComOcSt), 1, 0));
         A698ComDscto = 0;
         AssignAttri("", false, "A698ComDscto", StringUtil.LTrimStr( A698ComDscto, 15, 2));
         A728ComRete1 = 0;
         AssignAttri("", false, "A728ComRete1", StringUtil.LTrimStr( A728ComRete1, 15, 2));
         A729ComRete2 = 0;
         AssignAttri("", false, "A729ComRete2", StringUtil.LTrimStr( A729ComRete2, 15, 2));
         A706ComFlete = 0;
         AssignAttri("", false, "A706ComFlete", StringUtil.LTrimStr( A706ComFlete, 15, 2));
         A713ComISC = 0;
         AssignAttri("", false, "A713ComISC", StringUtil.LTrimStr( A713ComISC, 15, 2));
         A717ComPorIva = 0;
         AssignAttri("", false, "A717ComPorIva", StringUtil.LTrimStr( A717ComPorIva, 6, 2));
         A720ComObs = "";
         AssignAttri("", false, "A720ComObs", A720ComObs);
         A714ComItem = 0;
         AssignAttri("", false, "A714ComItem", StringUtil.LTrimStr( (decimal)(A714ComItem), 4, 0));
         A718ComRedondeo = 0;
         AssignAttri("", false, "A718ComRedondeo", StringUtil.LTrimStr( A718ComRedondeo, 15, 2));
         A740ComValor = 0;
         AssignAttri("", false, "A740ComValor", StringUtil.LTrimStr( A740ComValor, 15, 2));
         A247PrvDsc = "";
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         A741ComVouAno = 0;
         AssignAttri("", false, "A741ComVouAno", StringUtil.LTrimStr( (decimal)(A741ComVouAno), 4, 0));
         A742ComVouMes = 0;
         AssignAttri("", false, "A742ComVouMes", StringUtil.LTrimStr( (decimal)(A742ComVouMes), 2, 0));
         A734ComTASICod = 0;
         AssignAttri("", false, "A734ComTASICod", StringUtil.LTrimStr( (decimal)(A734ComTASICod), 6, 0));
         A743ComVouNum = "";
         AssignAttri("", false, "A743ComVouNum", A743ComVouNum);
         A738ComUsuC = "";
         AssignAttri("", false, "A738ComUsuC", A738ComUsuC);
         A702ComFecC = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A702ComFecC", context.localUtil.TToC( A702ComFecC, 8, 5, 0, 3, "/", ":", " "));
         A739ComUsuM = "";
         AssignAttri("", false, "A739ComUsuM", A739ComUsuM);
         A703ComFecM = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A703ComFecM", context.localUtil.TToC( A703ComFecM, 8, 5, 0, 3, "/", ":", " "));
         A671ComAut = 0;
         AssignAttri("", false, "A671ComAut", StringUtil.Str( (decimal)(A671ComAut), 1, 0));
         A737ComUsuAut = "";
         AssignAttri("", false, "A737ComUsuAut", A737ComUsuAut);
         A701ComFecAut = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A701ComFecAut", context.localUtil.TToC( A701ComFecAut, 8, 5, 0, 3, "/", ":", " "));
         A709ComImpAfec = 0;
         AssignAttri("", false, "A709ComImpAfec", StringUtil.Str( (decimal)(A709ComImpAfec), 1, 0));
         A711ComImpTip = 0;
         AssignAttri("", false, "A711ComImpTip", StringUtil.Str( (decimal)(A711ComImpTip), 1, 0));
         A710ComImpCod = "";
         AssignAttri("", false, "A710ComImpCod", A710ComImpCod);
         A712ComImpTipCos = "";
         AssignAttri("", false, "A712ComImpTipCos", A712ComImpTipCos);
         A726ComRetAfecto = 0;
         AssignAttri("", false, "A726ComRetAfecto", StringUtil.Str( (decimal)(A726ComRetAfecto), 1, 0));
         A727ComRetCod = "";
         AssignAttri("", false, "A727ComRetCod", A727ComRetCod);
         A730ComRetFec = DateTime.MinValue;
         AssignAttri("", false, "A730ComRetFec", context.localUtil.Format(A730ComRetFec, "99/99/99"));
         A704ComFecPago = DateTime.MinValue;
         AssignAttri("", false, "A704ComFecPago", context.localUtil.Format(A704ComFecPago, "99/99/99"));
         A735ComTipReg = "";
         AssignAttri("", false, "A735ComTipReg", A735ComTipReg);
         A719ComIVADUA = 0;
         AssignAttri("", false, "A719ComIVADUA", StringUtil.LTrimStr( A719ComIVADUA, 15, 2));
         A680ComCif = 0;
         AssignAttri("", false, "A680ComCif", StringUtil.Str( (decimal)(A680ComCif), 1, 0));
         A725ComRefTDoc = "";
         AssignAttri("", false, "A725ComRefTDoc", A725ComRefTDoc);
         A722ComRefDoc = "";
         AssignAttri("", false, "A722ComRefDoc", A722ComRefDoc);
         A724ComRefFec = DateTime.MinValue;
         AssignAttri("", false, "A724ComRefFec", context.localUtil.Format(A724ComRefFec, "99/99/99"));
         A705ComFlagRet = 0;
         n705ComFlagRet = false;
         AssignAttri("", false, "A705ComFlagRet", StringUtil.Str( (decimal)(A705ComFlagRet), 1, 0));
         n705ComFlagRet = ((0==A705ComFlagRet) ? true : false);
         A672ComBanCod = 0;
         AssignAttri("", false, "A672ComBanCod", StringUtil.LTrimStr( (decimal)(A672ComBanCod), 6, 0));
         A674ComBanCta = "";
         AssignAttri("", false, "A674ComBanCta", A674ComBanCta);
         A678ComBanReg = "";
         AssignAttri("", false, "A678ComBanReg", A678ComBanReg);
         A676ComBanForCod = 0;
         AssignAttri("", false, "A676ComBanForCod", StringUtil.LTrimStr( (decimal)(A676ComBanForCod), 6, 0));
         A677ComBanImp = 0;
         AssignAttri("", false, "A677ComBanImp", StringUtil.LTrimStr( A677ComBanImp, 15, 2));
         A675ComBanDoc = "";
         AssignAttri("", false, "A675ComBanDoc", A675ComBanDoc);
         A679ComBanTipC = 0;
         AssignAttri("", false, "A679ComBanTipC", StringUtil.LTrimStr( A679ComBanTipC, 15, 5));
         A673ComBanConc = 0;
         AssignAttri("", false, "A673ComBanConc", StringUtil.LTrimStr( (decimal)(A673ComBanConc), 6, 0));
         A716ComSubAfe = 0;
         AssignAttri("", false, "A716ComSubAfe", StringUtil.LTrimStr( A716ComSubAfe, 15, 2));
         A732ComSubIna = 0;
         AssignAttri("", false, "A732ComSubIna", StringUtil.LTrimStr( A732ComSubIna, 15, 2));
         A681ComConpAbr = "";
         AssignAttri("", false, "A681ComConpAbr", A681ComConpAbr);
         A682ComConpDias = 0;
         AssignAttri("", false, "A682ComConpDias", StringUtil.LTrimStr( (decimal)(A682ComConpDias), 4, 0));
         A731ComSubImportacion = 0;
         AssignAttri("", false, "A731ComSubImportacion", StringUtil.LTrimStr( A731ComSubImportacion, 15, 2));
         A723ComRefDom = "";
         AssignAttri("", false, "A723ComRefDom", A723ComRefDom);
         Z248ComFec = DateTime.MinValue;
         Z708ComFVcto = DateTime.MinValue;
         Z707ComFReg = DateTime.MinValue;
         Z249ComRef = "";
         Z721ComOcSt = 0;
         Z698ComDscto = 0;
         Z728ComRete1 = 0;
         Z729ComRete2 = 0;
         Z706ComFlete = 0;
         Z713ComISC = 0;
         Z717ComPorIva = 0;
         Z714ComItem = 0;
         Z718ComRedondeo = 0;
         Z740ComValor = 0;
         Z741ComVouAno = 0;
         Z742ComVouMes = 0;
         Z734ComTASICod = 0;
         Z743ComVouNum = "";
         Z738ComUsuC = "";
         Z702ComFecC = (DateTime)(DateTime.MinValue);
         Z739ComUsuM = "";
         Z703ComFecM = (DateTime)(DateTime.MinValue);
         Z671ComAut = 0;
         Z737ComUsuAut = "";
         Z701ComFecAut = (DateTime)(DateTime.MinValue);
         Z709ComImpAfec = 0;
         Z711ComImpTip = 0;
         Z710ComImpCod = "";
         Z712ComImpTipCos = "";
         Z726ComRetAfecto = 0;
         Z727ComRetCod = "";
         Z730ComRetFec = DateTime.MinValue;
         Z704ComFecPago = DateTime.MinValue;
         Z735ComTipReg = "";
         Z719ComIVADUA = 0;
         Z680ComCif = 0;
         Z725ComRefTDoc = "";
         Z722ComRefDoc = "";
         Z724ComRefFec = DateTime.MinValue;
         Z705ComFlagRet = 0;
         Z672ComBanCod = 0;
         Z674ComBanCta = "";
         Z678ComBanReg = "";
         Z676ComBanForCod = 0;
         Z677ComBanImp = 0;
         Z675ComBanDoc = "";
         Z679ComBanTipC = 0;
         Z673ComBanConc = 0;
         Z723ComRefDom = "";
         Z246ComMon = 0;
         Z245ComConpCod = 0;
      }

      protected void InitAll36109( )
      {
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         A243ComCod = "";
         AssignAttri("", false, "A243ComCod", A243ComCod);
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         InitializeNonKey36109( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025996", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("cpcompras.js", "?20228181025997", false, true);
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
         edtTipCod_Internalname = "TIPCOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtComCod_Internalname = "COMCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPrvCod_Internalname = "PRVCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtComFec_Internalname = "COMFEC";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtComFVcto_Internalname = "COMFVCTO";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtComFReg_Internalname = "COMFREG";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtComMon_Internalname = "COMMON";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtComConpCod_Internalname = "COMCONPCOD";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtComRef_Internalname = "COMREF";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtComOcSt_Internalname = "COMOCST";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtComDscto_Internalname = "COMDSCTO";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtComRete1_Internalname = "COMRETE1";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtComRete2_Internalname = "COMRETE2";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtComFlete_Internalname = "COMFLETE";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtComISC_Internalname = "COMISC";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtComPorIva_Internalname = "COMPORIVA";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtComObs_Internalname = "COMOBS";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtComItem_Internalname = "COMITEM";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtComRedondeo_Internalname = "COMREDONDEO";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtComValor_Internalname = "COMVALOR";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtPrvDsc_Internalname = "PRVDSC";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtComVouAno_Internalname = "COMVOUANO";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtComVouMes_Internalname = "COMVOUMES";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtComTASICod_Internalname = "COMTASICOD";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtComVouNum_Internalname = "COMVOUNUM";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtComUsuC_Internalname = "COMUSUC";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtComFecC_Internalname = "COMFECC";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtComUsuM_Internalname = "COMUSUM";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtComFecM_Internalname = "COMFECM";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtComAut_Internalname = "COMAUT";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtComUsuAut_Internalname = "COMUSUAUT";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtComFecAut_Internalname = "COMFECAUT";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtComImpAfec_Internalname = "COMIMPAFEC";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtComImpTip_Internalname = "COMIMPTIP";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtComImpCod_Internalname = "COMIMPCOD";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtComImpTipCos_Internalname = "COMIMPTIPCOS";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtComRetAfecto_Internalname = "COMRETAFECTO";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtComRetCod_Internalname = "COMRETCOD";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtComRetFec_Internalname = "COMRETFEC";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         edtComFecPago_Internalname = "COMFECPAGO";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         edtComTipReg_Internalname = "COMTIPREG";
         lblTextblock42_Internalname = "TEXTBLOCK42";
         edtComIVADUA_Internalname = "COMIVADUA";
         lblTextblock43_Internalname = "TEXTBLOCK43";
         edtComCif_Internalname = "COMCIF";
         lblTextblock44_Internalname = "TEXTBLOCK44";
         edtComRefTDoc_Internalname = "COMREFTDOC";
         lblTextblock45_Internalname = "TEXTBLOCK45";
         edtComRefDoc_Internalname = "COMREFDOC";
         lblTextblock46_Internalname = "TEXTBLOCK46";
         edtComRefFec_Internalname = "COMREFFEC";
         lblTextblock47_Internalname = "TEXTBLOCK47";
         edtComFlagRet_Internalname = "COMFLAGRET";
         lblTextblock48_Internalname = "TEXTBLOCK48";
         edtComBanCod_Internalname = "COMBANCOD";
         lblTextblock49_Internalname = "TEXTBLOCK49";
         edtComBanCta_Internalname = "COMBANCTA";
         lblTextblock50_Internalname = "TEXTBLOCK50";
         edtComBanReg_Internalname = "COMBANREG";
         lblTextblock51_Internalname = "TEXTBLOCK51";
         edtComBanForCod_Internalname = "COMBANFORCOD";
         lblTextblock52_Internalname = "TEXTBLOCK52";
         edtComBanImp_Internalname = "COMBANIMP";
         lblTextblock53_Internalname = "TEXTBLOCK53";
         edtComBanDoc_Internalname = "COMBANDOC";
         lblTextblock54_Internalname = "TEXTBLOCK54";
         edtComBanTipC_Internalname = "COMBANTIPC";
         lblTextblock55_Internalname = "TEXTBLOCK55";
         edtComBanConc_Internalname = "COMBANCONC";
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
         Form.Caption = "Compras - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtComBanConc_Jsonclick = "";
         edtComBanConc_Enabled = 1;
         edtComBanTipC_Jsonclick = "";
         edtComBanTipC_Enabled = 1;
         edtComBanDoc_Jsonclick = "";
         edtComBanDoc_Enabled = 1;
         edtComBanImp_Jsonclick = "";
         edtComBanImp_Enabled = 1;
         edtComBanForCod_Jsonclick = "";
         edtComBanForCod_Enabled = 1;
         edtComBanReg_Jsonclick = "";
         edtComBanReg_Enabled = 1;
         edtComBanCta_Jsonclick = "";
         edtComBanCta_Enabled = 1;
         edtComBanCod_Jsonclick = "";
         edtComBanCod_Enabled = 1;
         edtComFlagRet_Jsonclick = "";
         edtComFlagRet_Enabled = 1;
         edtComRefFec_Jsonclick = "";
         edtComRefFec_Enabled = 1;
         edtComRefDoc_Jsonclick = "";
         edtComRefDoc_Enabled = 1;
         edtComRefTDoc_Jsonclick = "";
         edtComRefTDoc_Enabled = 1;
         edtComCif_Jsonclick = "";
         edtComCif_Enabled = 1;
         edtComIVADUA_Jsonclick = "";
         edtComIVADUA_Enabled = 1;
         edtComTipReg_Jsonclick = "";
         edtComTipReg_Enabled = 1;
         edtComFecPago_Jsonclick = "";
         edtComFecPago_Enabled = 1;
         edtComRetFec_Jsonclick = "";
         edtComRetFec_Enabled = 1;
         edtComRetCod_Jsonclick = "";
         edtComRetCod_Enabled = 1;
         edtComRetAfecto_Jsonclick = "";
         edtComRetAfecto_Enabled = 1;
         edtComImpTipCos_Jsonclick = "";
         edtComImpTipCos_Enabled = 1;
         edtComImpCod_Jsonclick = "";
         edtComImpCod_Enabled = 1;
         edtComImpTip_Jsonclick = "";
         edtComImpTip_Enabled = 1;
         edtComImpAfec_Jsonclick = "";
         edtComImpAfec_Enabled = 1;
         edtComFecAut_Jsonclick = "";
         edtComFecAut_Enabled = 1;
         edtComUsuAut_Jsonclick = "";
         edtComUsuAut_Enabled = 1;
         edtComAut_Jsonclick = "";
         edtComAut_Enabled = 1;
         edtComFecM_Jsonclick = "";
         edtComFecM_Enabled = 1;
         edtComUsuM_Jsonclick = "";
         edtComUsuM_Enabled = 1;
         edtComFecC_Jsonclick = "";
         edtComFecC_Enabled = 1;
         edtComUsuC_Jsonclick = "";
         edtComUsuC_Enabled = 1;
         edtComVouNum_Jsonclick = "";
         edtComVouNum_Enabled = 1;
         edtComTASICod_Jsonclick = "";
         edtComTASICod_Enabled = 1;
         edtComVouMes_Jsonclick = "";
         edtComVouMes_Enabled = 1;
         edtComVouAno_Jsonclick = "";
         edtComVouAno_Enabled = 1;
         edtPrvDsc_Jsonclick = "";
         edtPrvDsc_Enabled = 0;
         edtComValor_Jsonclick = "";
         edtComValor_Enabled = 1;
         edtComRedondeo_Jsonclick = "";
         edtComRedondeo_Enabled = 1;
         edtComItem_Jsonclick = "";
         edtComItem_Enabled = 1;
         edtComObs_Enabled = 1;
         edtComPorIva_Jsonclick = "";
         edtComPorIva_Enabled = 1;
         edtComISC_Jsonclick = "";
         edtComISC_Enabled = 1;
         edtComFlete_Jsonclick = "";
         edtComFlete_Enabled = 1;
         edtComRete2_Jsonclick = "";
         edtComRete2_Enabled = 1;
         edtComRete1_Jsonclick = "";
         edtComRete1_Enabled = 1;
         edtComDscto_Jsonclick = "";
         edtComDscto_Enabled = 1;
         edtComOcSt_Jsonclick = "";
         edtComOcSt_Enabled = 1;
         edtComRef_Jsonclick = "";
         edtComRef_Enabled = 1;
         edtComConpCod_Jsonclick = "";
         edtComConpCod_Enabled = 1;
         edtComMon_Jsonclick = "";
         edtComMon_Enabled = 1;
         edtComFReg_Jsonclick = "";
         edtComFReg_Enabled = 1;
         edtComFVcto_Jsonclick = "";
         edtComFVcto_Enabled = 1;
         edtComFec_Jsonclick = "";
         edtComFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPrvCod_Jsonclick = "";
         edtPrvCod_Enabled = 1;
         edtComCod_Jsonclick = "";
         edtComCod_Enabled = 1;
         edtTipCod_Jsonclick = "";
         edtTipCod_Enabled = 1;
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
         /* Using cursor T003630 */
         pr_default.execute(24, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(24);
         /* Using cursor T003624 */
         pr_default.execute(19, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A247PrvDsc = T003624_A247PrvDsc[0];
         AssignAttri("", false, "A247PrvDsc", A247PrvDsc);
         pr_default.close(19);
         /* Using cursor T003626 */
         pr_default.execute(20, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(20) != 101) )
         {
            A716ComSubAfe = T003626_A716ComSubAfe[0];
            A732ComSubIna = T003626_A732ComSubIna[0];
            A731ComSubImportacion = T003626_A731ComSubImportacion[0];
         }
         else
         {
            A716ComSubAfe = 0;
            AssignAttri("", false, "A716ComSubAfe", StringUtil.LTrimStr( A716ComSubAfe, 15, 2));
            A732ComSubIna = 0;
            AssignAttri("", false, "A732ComSubIna", StringUtil.LTrimStr( A732ComSubIna, 15, 2));
            A731ComSubImportacion = 0;
            AssignAttri("", false, "A731ComSubImportacion", StringUtil.LTrimStr( A731ComSubImportacion, 15, 2));
         }
         pr_default.close(20);
         GX_FocusControl = edtComFec_Internalname;
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

      public void Valid_Tipcod( )
      {
         /* Using cursor T003630 */
         pr_default.execute(24, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GX_msglist.addItem("No existe 'Tipos de Documentos'.", "ForeignKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(24);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prvcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T003624 */
         pr_default.execute(19, new Object[] {A244PrvCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Datos Generales Proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtPrvCod_Internalname;
         }
         A247PrvDsc = T003624_A247PrvDsc[0];
         pr_default.close(19);
         /* Using cursor T003626 */
         pr_default.execute(20, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(20) != 101) )
         {
            A716ComSubAfe = T003626_A716ComSubAfe[0];
            A732ComSubIna = T003626_A732ComSubIna[0];
            A731ComSubImportacion = T003626_A731ComSubImportacion[0];
         }
         else
         {
            A716ComSubAfe = 0;
            A732ComSubIna = 0;
            A731ComSubImportacion = 0;
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A248ComFec", context.localUtil.Format(A248ComFec, "99/99/99"));
         AssignAttri("", false, "A708ComFVcto", context.localUtil.Format(A708ComFVcto, "99/99/99"));
         AssignAttri("", false, "A707ComFReg", context.localUtil.Format(A707ComFReg, "99/99/99"));
         AssignAttri("", false, "A246ComMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(A246ComMon), 6, 0, ".", "")));
         AssignAttri("", false, "A245ComConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A245ComConpCod), 6, 0, ".", "")));
         AssignAttri("", false, "A249ComRef", StringUtil.RTrim( A249ComRef));
         AssignAttri("", false, "A721ComOcSt", StringUtil.LTrim( StringUtil.NToC( (decimal)(A721ComOcSt), 1, 0, ".", "")));
         AssignAttri("", false, "A698ComDscto", StringUtil.LTrim( StringUtil.NToC( A698ComDscto, 15, 2, ".", "")));
         AssignAttri("", false, "A728ComRete1", StringUtil.LTrim( StringUtil.NToC( A728ComRete1, 15, 2, ".", "")));
         AssignAttri("", false, "A729ComRete2", StringUtil.LTrim( StringUtil.NToC( A729ComRete2, 15, 2, ".", "")));
         AssignAttri("", false, "A706ComFlete", StringUtil.LTrim( StringUtil.NToC( A706ComFlete, 15, 2, ".", "")));
         AssignAttri("", false, "A713ComISC", StringUtil.LTrim( StringUtil.NToC( A713ComISC, 15, 2, ".", "")));
         AssignAttri("", false, "A717ComPorIva", StringUtil.LTrim( StringUtil.NToC( A717ComPorIva, 6, 2, ".", "")));
         AssignAttri("", false, "A720ComObs", A720ComObs);
         AssignAttri("", false, "A714ComItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A714ComItem), 4, 0, ".", "")));
         AssignAttri("", false, "A718ComRedondeo", StringUtil.LTrim( StringUtil.NToC( A718ComRedondeo, 15, 2, ".", "")));
         AssignAttri("", false, "A740ComValor", StringUtil.LTrim( StringUtil.NToC( A740ComValor, 15, 2, ".", "")));
         AssignAttri("", false, "A741ComVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A741ComVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A742ComVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A742ComVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A734ComTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A734ComTASICod), 6, 0, ".", "")));
         AssignAttri("", false, "A743ComVouNum", StringUtil.RTrim( A743ComVouNum));
         AssignAttri("", false, "A738ComUsuC", StringUtil.RTrim( A738ComUsuC));
         AssignAttri("", false, "A702ComFecC", context.localUtil.TToC( A702ComFecC, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A739ComUsuM", StringUtil.RTrim( A739ComUsuM));
         AssignAttri("", false, "A703ComFecM", context.localUtil.TToC( A703ComFecM, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A671ComAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A671ComAut), 1, 0, ".", "")));
         AssignAttri("", false, "A737ComUsuAut", StringUtil.RTrim( A737ComUsuAut));
         AssignAttri("", false, "A701ComFecAut", context.localUtil.TToC( A701ComFecAut, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A709ComImpAfec", StringUtil.LTrim( StringUtil.NToC( (decimal)(A709ComImpAfec), 1, 0, ".", "")));
         AssignAttri("", false, "A711ComImpTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(A711ComImpTip), 1, 0, ".", "")));
         AssignAttri("", false, "A710ComImpCod", StringUtil.RTrim( A710ComImpCod));
         AssignAttri("", false, "A712ComImpTipCos", StringUtil.RTrim( A712ComImpTipCos));
         AssignAttri("", false, "A726ComRetAfecto", StringUtil.LTrim( StringUtil.NToC( (decimal)(A726ComRetAfecto), 1, 0, ".", "")));
         AssignAttri("", false, "A727ComRetCod", StringUtil.RTrim( A727ComRetCod));
         AssignAttri("", false, "A730ComRetFec", context.localUtil.Format(A730ComRetFec, "99/99/99"));
         AssignAttri("", false, "A704ComFecPago", context.localUtil.Format(A704ComFecPago, "99/99/99"));
         AssignAttri("", false, "A735ComTipReg", StringUtil.RTrim( A735ComTipReg));
         AssignAttri("", false, "A719ComIVADUA", StringUtil.LTrim( StringUtil.NToC( A719ComIVADUA, 15, 2, ".", "")));
         AssignAttri("", false, "A680ComCif", StringUtil.LTrim( StringUtil.NToC( (decimal)(A680ComCif), 1, 0, ".", "")));
         AssignAttri("", false, "A725ComRefTDoc", StringUtil.RTrim( A725ComRefTDoc));
         AssignAttri("", false, "A722ComRefDoc", StringUtil.RTrim( A722ComRefDoc));
         AssignAttri("", false, "A724ComRefFec", context.localUtil.Format(A724ComRefFec, "99/99/99"));
         AssignAttri("", false, "A705ComFlagRet", StringUtil.LTrim( StringUtil.NToC( (decimal)(A705ComFlagRet), 1, 0, ".", "")));
         AssignAttri("", false, "A672ComBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A672ComBanCod), 6, 0, ".", "")));
         AssignAttri("", false, "A674ComBanCta", StringUtil.RTrim( A674ComBanCta));
         AssignAttri("", false, "A678ComBanReg", StringUtil.RTrim( A678ComBanReg));
         AssignAttri("", false, "A676ComBanForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A676ComBanForCod), 6, 0, ".", "")));
         AssignAttri("", false, "A677ComBanImp", StringUtil.LTrim( StringUtil.NToC( A677ComBanImp, 15, 2, ".", "")));
         AssignAttri("", false, "A675ComBanDoc", StringUtil.RTrim( A675ComBanDoc));
         AssignAttri("", false, "A679ComBanTipC", StringUtil.LTrim( StringUtil.NToC( A679ComBanTipC, 15, 5, ".", "")));
         AssignAttri("", false, "A673ComBanConc", StringUtil.LTrim( StringUtil.NToC( (decimal)(A673ComBanConc), 6, 0, ".", "")));
         AssignAttri("", false, "A723ComRefDom", A723ComRefDom);
         AssignAttri("", false, "A247PrvDsc", StringUtil.RTrim( A247PrvDsc));
         AssignAttri("", false, "A716ComSubAfe", StringUtil.LTrim( StringUtil.NToC( A716ComSubAfe, 15, 2, ".", "")));
         AssignAttri("", false, "A732ComSubIna", StringUtil.LTrim( StringUtil.NToC( A732ComSubIna, 15, 2, ".", "")));
         AssignAttri("", false, "A731ComSubImportacion", StringUtil.LTrim( StringUtil.NToC( A731ComSubImportacion, 15, 2, ".", "")));
         AssignAttri("", false, "A715ComIva", StringUtil.LTrim( StringUtil.NToC( A715ComIva, 15, 2, ".", "")));
         AssignAttri("", false, "A733ComSubTotal", StringUtil.LTrim( StringUtil.NToC( A733ComSubTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A736ComTotal", StringUtil.LTrim( StringUtil.NToC( A736ComTotal, 15, 2, ".", "")));
         AssignAttri("", false, "A681ComConpAbr", StringUtil.RTrim( A681ComConpAbr));
         AssignAttri("", false, "A682ComConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A682ComConpDias), 4, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z243ComCod", StringUtil.RTrim( Z243ComCod));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z248ComFec", context.localUtil.Format(Z248ComFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z708ComFVcto", context.localUtil.Format(Z708ComFVcto, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z707ComFReg", context.localUtil.Format(Z707ComFReg, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z246ComMon", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z246ComMon), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z245ComConpCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z245ComConpCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z249ComRef", StringUtil.RTrim( Z249ComRef));
         GxWebStd.gx_hidden_field( context, "Z721ComOcSt", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z721ComOcSt), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z698ComDscto", StringUtil.LTrim( StringUtil.NToC( Z698ComDscto, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z728ComRete1", StringUtil.LTrim( StringUtil.NToC( Z728ComRete1, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z729ComRete2", StringUtil.LTrim( StringUtil.NToC( Z729ComRete2, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z706ComFlete", StringUtil.LTrim( StringUtil.NToC( Z706ComFlete, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z713ComISC", StringUtil.LTrim( StringUtil.NToC( Z713ComISC, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z717ComPorIva", StringUtil.LTrim( StringUtil.NToC( Z717ComPorIva, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z720ComObs", Z720ComObs);
         GxWebStd.gx_hidden_field( context, "Z714ComItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z714ComItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z718ComRedondeo", StringUtil.LTrim( StringUtil.NToC( Z718ComRedondeo, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z740ComValor", StringUtil.LTrim( StringUtil.NToC( Z740ComValor, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z741ComVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z741ComVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z742ComVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z742ComVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z734ComTASICod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z734ComTASICod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z743ComVouNum", StringUtil.RTrim( Z743ComVouNum));
         GxWebStd.gx_hidden_field( context, "Z738ComUsuC", StringUtil.RTrim( Z738ComUsuC));
         GxWebStd.gx_hidden_field( context, "Z702ComFecC", context.localUtil.TToC( Z702ComFecC, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z739ComUsuM", StringUtil.RTrim( Z739ComUsuM));
         GxWebStd.gx_hidden_field( context, "Z703ComFecM", context.localUtil.TToC( Z703ComFecM, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z671ComAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z671ComAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z737ComUsuAut", StringUtil.RTrim( Z737ComUsuAut));
         GxWebStd.gx_hidden_field( context, "Z701ComFecAut", context.localUtil.TToC( Z701ComFecAut, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z709ComImpAfec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z709ComImpAfec), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z711ComImpTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z711ComImpTip), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z710ComImpCod", StringUtil.RTrim( Z710ComImpCod));
         GxWebStd.gx_hidden_field( context, "Z712ComImpTipCos", StringUtil.RTrim( Z712ComImpTipCos));
         GxWebStd.gx_hidden_field( context, "Z726ComRetAfecto", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z726ComRetAfecto), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z727ComRetCod", StringUtil.RTrim( Z727ComRetCod));
         GxWebStd.gx_hidden_field( context, "Z730ComRetFec", context.localUtil.Format(Z730ComRetFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z704ComFecPago", context.localUtil.Format(Z704ComFecPago, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z735ComTipReg", StringUtil.RTrim( Z735ComTipReg));
         GxWebStd.gx_hidden_field( context, "Z719ComIVADUA", StringUtil.LTrim( StringUtil.NToC( Z719ComIVADUA, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z680ComCif", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z680ComCif), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z725ComRefTDoc", StringUtil.RTrim( Z725ComRefTDoc));
         GxWebStd.gx_hidden_field( context, "Z722ComRefDoc", StringUtil.RTrim( Z722ComRefDoc));
         GxWebStd.gx_hidden_field( context, "Z724ComRefFec", context.localUtil.Format(Z724ComRefFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z705ComFlagRet", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z705ComFlagRet), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z672ComBanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z672ComBanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z674ComBanCta", StringUtil.RTrim( Z674ComBanCta));
         GxWebStd.gx_hidden_field( context, "Z678ComBanReg", StringUtil.RTrim( Z678ComBanReg));
         GxWebStd.gx_hidden_field( context, "Z676ComBanForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z676ComBanForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z677ComBanImp", StringUtil.LTrim( StringUtil.NToC( Z677ComBanImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z675ComBanDoc", StringUtil.RTrim( Z675ComBanDoc));
         GxWebStd.gx_hidden_field( context, "Z679ComBanTipC", StringUtil.LTrim( StringUtil.NToC( Z679ComBanTipC, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z673ComBanConc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z673ComBanConc), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z723ComRefDom", Z723ComRefDom);
         GxWebStd.gx_hidden_field( context, "Z247PrvDsc", StringUtil.RTrim( Z247PrvDsc));
         GxWebStd.gx_hidden_field( context, "Z716ComSubAfe", StringUtil.LTrim( StringUtil.NToC( Z716ComSubAfe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z732ComSubIna", StringUtil.LTrim( StringUtil.NToC( Z732ComSubIna, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z731ComSubImportacion", StringUtil.LTrim( StringUtil.NToC( Z731ComSubImportacion, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z715ComIva", StringUtil.LTrim( StringUtil.NToC( Z715ComIva, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z733ComSubTotal", StringUtil.LTrim( StringUtil.NToC( Z733ComSubTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z736ComTotal", StringUtil.LTrim( StringUtil.NToC( Z736ComTotal, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z681ComConpAbr", StringUtil.RTrim( Z681ComConpAbr));
         GxWebStd.gx_hidden_field( context, "Z682ComConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z682ComConpDias), 4, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Common( )
      {
         /* Using cursor T003631 */
         pr_default.execute(25, new Object[] {A246ComMon});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No existe 'Moneda'.", "ForeignKeyNotFound", 1, "COMMON");
            AnyError = 1;
            GX_FocusControl = edtComMon_Internalname;
         }
         pr_default.close(25);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Comconpcod( )
      {
         /* Using cursor T003627 */
         pr_default.execute(21, new Object[] {A245ComConpCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No existe 'Forma de Pago'.", "ForeignKeyNotFound", 1, "COMCONPCOD");
            AnyError = 1;
            GX_FocusControl = edtComConpCod_Internalname;
         }
         A681ComConpAbr = T003627_A681ComConpAbr[0];
         A682ComConpDias = T003627_A682ComConpDias[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A681ComConpAbr", StringUtil.RTrim( A681ComConpAbr));
         AssignAttri("", false, "A682ComConpDias", StringUtil.LTrim( StringUtil.NToC( (decimal)(A682ComConpDias), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A723ComRefDom',fld:'COMREFDOM',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_COMCOD","{handler:'Valid_Comcod',iparms:[]");
         setEventMetadata("VALID_COMCOD",",oparms:[]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A723ComRefDom',fld:'COMREFDOM',pic:''},{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A243ComCod',fld:'COMCOD',pic:''},{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[{av:'A248ComFec',fld:'COMFEC',pic:''},{av:'A708ComFVcto',fld:'COMFVCTO',pic:''},{av:'A707ComFReg',fld:'COMFREG',pic:''},{av:'A246ComMon',fld:'COMMON',pic:'ZZZZZ9'},{av:'A245ComConpCod',fld:'COMCONPCOD',pic:'ZZZZZ9'},{av:'A249ComRef',fld:'COMREF',pic:''},{av:'A721ComOcSt',fld:'COMOCST',pic:'9'},{av:'A698ComDscto',fld:'COMDSCTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A728ComRete1',fld:'COMRETE1',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A729ComRete2',fld:'COMRETE2',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A706ComFlete',fld:'COMFLETE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A713ComISC',fld:'COMISC',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A717ComPorIva',fld:'COMPORIVA',pic:'ZZ9.99'},{av:'A720ComObs',fld:'COMOBS',pic:''},{av:'A714ComItem',fld:'COMITEM',pic:'ZZZ9'},{av:'A718ComRedondeo',fld:'COMREDONDEO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A740ComValor',fld:'COMVALOR',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A741ComVouAno',fld:'COMVOUANO',pic:'ZZZ9'},{av:'A742ComVouMes',fld:'COMVOUMES',pic:'Z9'},{av:'A734ComTASICod',fld:'COMTASICOD',pic:'ZZZZZ9'},{av:'A743ComVouNum',fld:'COMVOUNUM',pic:''},{av:'A738ComUsuC',fld:'COMUSUC',pic:''},{av:'A702ComFecC',fld:'COMFECC',pic:'99/99/99 99:99'},{av:'A739ComUsuM',fld:'COMUSUM',pic:''},{av:'A703ComFecM',fld:'COMFECM',pic:'99/99/99 99:99'},{av:'A671ComAut',fld:'COMAUT',pic:'9'},{av:'A737ComUsuAut',fld:'COMUSUAUT',pic:''},{av:'A701ComFecAut',fld:'COMFECAUT',pic:'99/99/99 99:99'},{av:'A709ComImpAfec',fld:'COMIMPAFEC',pic:'9'},{av:'A711ComImpTip',fld:'COMIMPTIP',pic:'9'},{av:'A710ComImpCod',fld:'COMIMPCOD',pic:''},{av:'A712ComImpTipCos',fld:'COMIMPTIPCOS',pic:''},{av:'A726ComRetAfecto',fld:'COMRETAFECTO',pic:'9'},{av:'A727ComRetCod',fld:'COMRETCOD',pic:''},{av:'A730ComRetFec',fld:'COMRETFEC',pic:''},{av:'A704ComFecPago',fld:'COMFECPAGO',pic:''},{av:'A735ComTipReg',fld:'COMTIPREG',pic:''},{av:'A719ComIVADUA',fld:'COMIVADUA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A680ComCif',fld:'COMCIF',pic:'9'},{av:'A725ComRefTDoc',fld:'COMREFTDOC',pic:''},{av:'A722ComRefDoc',fld:'COMREFDOC',pic:''},{av:'A724ComRefFec',fld:'COMREFFEC',pic:''},{av:'A705ComFlagRet',fld:'COMFLAGRET',pic:'9'},{av:'A672ComBanCod',fld:'COMBANCOD',pic:'ZZZZZ9'},{av:'A674ComBanCta',fld:'COMBANCTA',pic:''},{av:'A678ComBanReg',fld:'COMBANREG',pic:''},{av:'A676ComBanForCod',fld:'COMBANFORCOD',pic:'ZZZZZ9'},{av:'A677ComBanImp',fld:'COMBANIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A675ComBanDoc',fld:'COMBANDOC',pic:''},{av:'A679ComBanTipC',fld:'COMBANTIPC',pic:'ZZZZZZZZ9.99999'},{av:'A673ComBanConc',fld:'COMBANCONC',pic:'ZZZZZ9'},{av:'A723ComRefDom',fld:'COMREFDOM',pic:''},{av:'A247PrvDsc',fld:'PRVDSC',pic:''},{av:'A716ComSubAfe',fld:'COMSUBAFE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A732ComSubIna',fld:'COMSUBINA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A731ComSubImportacion',fld:'COMSUBIMPORTACION',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A715ComIva',fld:'COMIVA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A733ComSubTotal',fld:'COMSUBTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A736ComTotal',fld:'COMTOTAL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A681ComConpAbr',fld:'COMCONPABR',pic:''},{av:'A682ComConpDias',fld:'COMCONPDIAS',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z149TipCod'},{av:'Z243ComCod'},{av:'Z244PrvCod'},{av:'Z248ComFec'},{av:'Z708ComFVcto'},{av:'Z707ComFReg'},{av:'Z246ComMon'},{av:'Z245ComConpCod'},{av:'Z249ComRef'},{av:'Z721ComOcSt'},{av:'Z698ComDscto'},{av:'Z728ComRete1'},{av:'Z729ComRete2'},{av:'Z706ComFlete'},{av:'Z713ComISC'},{av:'Z717ComPorIva'},{av:'Z720ComObs'},{av:'Z714ComItem'},{av:'Z718ComRedondeo'},{av:'Z740ComValor'},{av:'Z741ComVouAno'},{av:'Z742ComVouMes'},{av:'Z734ComTASICod'},{av:'Z743ComVouNum'},{av:'Z738ComUsuC'},{av:'Z702ComFecC'},{av:'Z739ComUsuM'},{av:'Z703ComFecM'},{av:'Z671ComAut'},{av:'Z737ComUsuAut'},{av:'Z701ComFecAut'},{av:'Z709ComImpAfec'},{av:'Z711ComImpTip'},{av:'Z710ComImpCod'},{av:'Z712ComImpTipCos'},{av:'Z726ComRetAfecto'},{av:'Z727ComRetCod'},{av:'Z730ComRetFec'},{av:'Z704ComFecPago'},{av:'Z735ComTipReg'},{av:'Z719ComIVADUA'},{av:'Z680ComCif'},{av:'Z725ComRefTDoc'},{av:'Z722ComRefDoc'},{av:'Z724ComRefFec'},{av:'Z705ComFlagRet'},{av:'Z672ComBanCod'},{av:'Z674ComBanCta'},{av:'Z678ComBanReg'},{av:'Z676ComBanForCod'},{av:'Z677ComBanImp'},{av:'Z675ComBanDoc'},{av:'Z679ComBanTipC'},{av:'Z673ComBanConc'},{av:'Z723ComRefDom'},{av:'Z247PrvDsc'},{av:'Z716ComSubAfe'},{av:'Z732ComSubIna'},{av:'Z731ComSubImportacion'},{av:'Z715ComIva'},{av:'Z733ComSubTotal'},{av:'Z736ComTotal'},{av:'Z681ComConpAbr'},{av:'Z682ComConpDias'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_COMFEC","{handler:'Valid_Comfec',iparms:[]");
         setEventMetadata("VALID_COMFEC",",oparms:[]}");
         setEventMetadata("VALID_COMFVCTO","{handler:'Valid_Comfvcto',iparms:[]");
         setEventMetadata("VALID_COMFVCTO",",oparms:[]}");
         setEventMetadata("VALID_COMFREG","{handler:'Valid_Comfreg',iparms:[]");
         setEventMetadata("VALID_COMFREG",",oparms:[]}");
         setEventMetadata("VALID_COMMON","{handler:'Valid_Common',iparms:[{av:'A246ComMon',fld:'COMMON',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COMMON",",oparms:[]}");
         setEventMetadata("VALID_COMCONPCOD","{handler:'Valid_Comconpcod',iparms:[{av:'A245ComConpCod',fld:'COMCONPCOD',pic:'ZZZZZ9'},{av:'A681ComConpAbr',fld:'COMCONPABR',pic:''},{av:'A682ComConpDias',fld:'COMCONPDIAS',pic:'ZZZ9'}]");
         setEventMetadata("VALID_COMCONPCOD",",oparms:[{av:'A681ComConpAbr',fld:'COMCONPABR',pic:''},{av:'A682ComConpDias',fld:'COMCONPDIAS',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_COMDSCTO","{handler:'Valid_Comdscto',iparms:[]");
         setEventMetadata("VALID_COMDSCTO",",oparms:[]}");
         setEventMetadata("VALID_COMRETE1","{handler:'Valid_Comrete1',iparms:[]");
         setEventMetadata("VALID_COMRETE1",",oparms:[]}");
         setEventMetadata("VALID_COMRETE2","{handler:'Valid_Comrete2',iparms:[]");
         setEventMetadata("VALID_COMRETE2",",oparms:[]}");
         setEventMetadata("VALID_COMFLETE","{handler:'Valid_Comflete',iparms:[]");
         setEventMetadata("VALID_COMFLETE",",oparms:[]}");
         setEventMetadata("VALID_COMISC","{handler:'Valid_Comisc',iparms:[]");
         setEventMetadata("VALID_COMISC",",oparms:[]}");
         setEventMetadata("VALID_COMPORIVA","{handler:'Valid_Comporiva',iparms:[]");
         setEventMetadata("VALID_COMPORIVA",",oparms:[]}");
         setEventMetadata("VALID_COMREDONDEO","{handler:'Valid_Comredondeo',iparms:[]");
         setEventMetadata("VALID_COMREDONDEO",",oparms:[]}");
         setEventMetadata("VALID_COMFECC","{handler:'Valid_Comfecc',iparms:[]");
         setEventMetadata("VALID_COMFECC",",oparms:[]}");
         setEventMetadata("VALID_COMFECM","{handler:'Valid_Comfecm',iparms:[]");
         setEventMetadata("VALID_COMFECM",",oparms:[]}");
         setEventMetadata("VALID_COMFECAUT","{handler:'Valid_Comfecaut',iparms:[]");
         setEventMetadata("VALID_COMFECAUT",",oparms:[]}");
         setEventMetadata("VALID_COMRETFEC","{handler:'Valid_Comretfec',iparms:[]");
         setEventMetadata("VALID_COMRETFEC",",oparms:[]}");
         setEventMetadata("VALID_COMFECPAGO","{handler:'Valid_Comfecpago',iparms:[]");
         setEventMetadata("VALID_COMFECPAGO",",oparms:[]}");
         setEventMetadata("VALID_COMIVADUA","{handler:'Valid_Comivadua',iparms:[]");
         setEventMetadata("VALID_COMIVADUA",",oparms:[]}");
         setEventMetadata("VALID_COMREFFEC","{handler:'Valid_Comreffec',iparms:[]");
         setEventMetadata("VALID_COMREFFEC",",oparms:[]}");
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
         pr_default.close(24);
         pr_default.close(19);
         pr_default.close(25);
         pr_default.close(21);
         pr_default.close(20);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z149TipCod = "";
         Z243ComCod = "";
         Z244PrvCod = "";
         Z248ComFec = DateTime.MinValue;
         Z708ComFVcto = DateTime.MinValue;
         Z707ComFReg = DateTime.MinValue;
         Z249ComRef = "";
         Z743ComVouNum = "";
         Z738ComUsuC = "";
         Z702ComFecC = (DateTime)(DateTime.MinValue);
         Z739ComUsuM = "";
         Z703ComFecM = (DateTime)(DateTime.MinValue);
         Z737ComUsuAut = "";
         Z701ComFecAut = (DateTime)(DateTime.MinValue);
         Z710ComImpCod = "";
         Z712ComImpTipCos = "";
         Z727ComRetCod = "";
         Z730ComRetFec = DateTime.MinValue;
         Z704ComFecPago = DateTime.MinValue;
         Z735ComTipReg = "";
         Z725ComRefTDoc = "";
         Z722ComRefDoc = "";
         Z724ComRefFec = DateTime.MinValue;
         Z674ComBanCta = "";
         Z678ComBanReg = "";
         Z675ComBanDoc = "";
         Z723ComRefDom = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A149TipCod = "";
         A244PrvCod = "";
         A243ComCod = "";
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
         lblTextblock3_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         A248ComFec = DateTime.MinValue;
         lblTextblock5_Jsonclick = "";
         A708ComFVcto = DateTime.MinValue;
         lblTextblock6_Jsonclick = "";
         A707ComFReg = DateTime.MinValue;
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         A249ComRef = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         A720ComObs = "";
         lblTextblock18_Jsonclick = "";
         lblTextblock19_Jsonclick = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         A247PrvDsc = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         A743ComVouNum = "";
         lblTextblock26_Jsonclick = "";
         A738ComUsuC = "";
         lblTextblock27_Jsonclick = "";
         A702ComFecC = (DateTime)(DateTime.MinValue);
         lblTextblock28_Jsonclick = "";
         A739ComUsuM = "";
         lblTextblock29_Jsonclick = "";
         A703ComFecM = (DateTime)(DateTime.MinValue);
         lblTextblock30_Jsonclick = "";
         lblTextblock31_Jsonclick = "";
         A737ComUsuAut = "";
         lblTextblock32_Jsonclick = "";
         A701ComFecAut = (DateTime)(DateTime.MinValue);
         lblTextblock33_Jsonclick = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         A710ComImpCod = "";
         lblTextblock36_Jsonclick = "";
         A712ComImpTipCos = "";
         lblTextblock37_Jsonclick = "";
         lblTextblock38_Jsonclick = "";
         A727ComRetCod = "";
         lblTextblock39_Jsonclick = "";
         A730ComRetFec = DateTime.MinValue;
         lblTextblock40_Jsonclick = "";
         A704ComFecPago = DateTime.MinValue;
         lblTextblock41_Jsonclick = "";
         A735ComTipReg = "";
         lblTextblock42_Jsonclick = "";
         lblTextblock43_Jsonclick = "";
         lblTextblock44_Jsonclick = "";
         A725ComRefTDoc = "";
         lblTextblock45_Jsonclick = "";
         A722ComRefDoc = "";
         lblTextblock46_Jsonclick = "";
         A724ComRefFec = DateTime.MinValue;
         lblTextblock47_Jsonclick = "";
         lblTextblock48_Jsonclick = "";
         lblTextblock49_Jsonclick = "";
         A674ComBanCta = "";
         lblTextblock50_Jsonclick = "";
         A678ComBanReg = "";
         lblTextblock51_Jsonclick = "";
         lblTextblock52_Jsonclick = "";
         lblTextblock53_Jsonclick = "";
         A675ComBanDoc = "";
         lblTextblock54_Jsonclick = "";
         lblTextblock55_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A723ComRefDom = "";
         Gx_mode = "";
         A681ComConpAbr = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z720ComObs = "";
         Z247PrvDsc = "";
         Z681ComConpAbr = "";
         T003611_A243ComCod = new string[] {""} ;
         T003611_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         T003611_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         T003611_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         T003611_A249ComRef = new string[] {""} ;
         T003611_A721ComOcSt = new short[1] ;
         T003611_A698ComDscto = new decimal[1] ;
         T003611_A728ComRete1 = new decimal[1] ;
         T003611_A729ComRete2 = new decimal[1] ;
         T003611_A706ComFlete = new decimal[1] ;
         T003611_A713ComISC = new decimal[1] ;
         T003611_A717ComPorIva = new decimal[1] ;
         T003611_A720ComObs = new string[] {""} ;
         T003611_A714ComItem = new short[1] ;
         T003611_A718ComRedondeo = new decimal[1] ;
         T003611_A740ComValor = new decimal[1] ;
         T003611_A247PrvDsc = new string[] {""} ;
         T003611_A741ComVouAno = new short[1] ;
         T003611_A742ComVouMes = new short[1] ;
         T003611_A734ComTASICod = new int[1] ;
         T003611_A743ComVouNum = new string[] {""} ;
         T003611_A738ComUsuC = new string[] {""} ;
         T003611_A702ComFecC = new DateTime[] {DateTime.MinValue} ;
         T003611_A739ComUsuM = new string[] {""} ;
         T003611_A703ComFecM = new DateTime[] {DateTime.MinValue} ;
         T003611_A671ComAut = new short[1] ;
         T003611_A737ComUsuAut = new string[] {""} ;
         T003611_A701ComFecAut = new DateTime[] {DateTime.MinValue} ;
         T003611_A709ComImpAfec = new short[1] ;
         T003611_A711ComImpTip = new short[1] ;
         T003611_A710ComImpCod = new string[] {""} ;
         T003611_A712ComImpTipCos = new string[] {""} ;
         T003611_A726ComRetAfecto = new short[1] ;
         T003611_A727ComRetCod = new string[] {""} ;
         T003611_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         T003611_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         T003611_A735ComTipReg = new string[] {""} ;
         T003611_A719ComIVADUA = new decimal[1] ;
         T003611_A680ComCif = new short[1] ;
         T003611_A725ComRefTDoc = new string[] {""} ;
         T003611_A722ComRefDoc = new string[] {""} ;
         T003611_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         T003611_A705ComFlagRet = new short[1] ;
         T003611_n705ComFlagRet = new bool[] {false} ;
         T003611_A672ComBanCod = new int[1] ;
         T003611_A674ComBanCta = new string[] {""} ;
         T003611_A678ComBanReg = new string[] {""} ;
         T003611_A676ComBanForCod = new int[1] ;
         T003611_A677ComBanImp = new decimal[1] ;
         T003611_A675ComBanDoc = new string[] {""} ;
         T003611_A679ComBanTipC = new decimal[1] ;
         T003611_A673ComBanConc = new int[1] ;
         T003611_A681ComConpAbr = new string[] {""} ;
         T003611_A682ComConpDias = new short[1] ;
         T003611_A723ComRefDom = new string[] {""} ;
         T003611_A149TipCod = new string[] {""} ;
         T003611_A244PrvCod = new string[] {""} ;
         T003611_A246ComMon = new int[1] ;
         T003611_A245ComConpCod = new int[1] ;
         T003611_A716ComSubAfe = new decimal[1] ;
         T003611_A732ComSubIna = new decimal[1] ;
         T003611_A731ComSubImportacion = new decimal[1] ;
         T00365_A247PrvDsc = new string[] {""} ;
         T00364_A149TipCod = new string[] {""} ;
         T00369_A716ComSubAfe = new decimal[1] ;
         T00369_A732ComSubIna = new decimal[1] ;
         T00369_A731ComSubImportacion = new decimal[1] ;
         T00366_A246ComMon = new int[1] ;
         T00367_A681ComConpAbr = new string[] {""} ;
         T00367_A682ComConpDias = new short[1] ;
         T003612_A149TipCod = new string[] {""} ;
         T003613_A247PrvDsc = new string[] {""} ;
         T003615_A716ComSubAfe = new decimal[1] ;
         T003615_A732ComSubIna = new decimal[1] ;
         T003615_A731ComSubImportacion = new decimal[1] ;
         T003616_A246ComMon = new int[1] ;
         T003617_A681ComConpAbr = new string[] {""} ;
         T003617_A682ComConpDias = new short[1] ;
         T003618_A149TipCod = new string[] {""} ;
         T003618_A243ComCod = new string[] {""} ;
         T003618_A244PrvCod = new string[] {""} ;
         T00363_A243ComCod = new string[] {""} ;
         T00363_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         T00363_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         T00363_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         T00363_A249ComRef = new string[] {""} ;
         T00363_A721ComOcSt = new short[1] ;
         T00363_A698ComDscto = new decimal[1] ;
         T00363_A728ComRete1 = new decimal[1] ;
         T00363_A729ComRete2 = new decimal[1] ;
         T00363_A706ComFlete = new decimal[1] ;
         T00363_A713ComISC = new decimal[1] ;
         T00363_A717ComPorIva = new decimal[1] ;
         T00363_A720ComObs = new string[] {""} ;
         T00363_A714ComItem = new short[1] ;
         T00363_A718ComRedondeo = new decimal[1] ;
         T00363_A740ComValor = new decimal[1] ;
         T00363_A741ComVouAno = new short[1] ;
         T00363_A742ComVouMes = new short[1] ;
         T00363_A734ComTASICod = new int[1] ;
         T00363_A743ComVouNum = new string[] {""} ;
         T00363_A738ComUsuC = new string[] {""} ;
         T00363_A702ComFecC = new DateTime[] {DateTime.MinValue} ;
         T00363_A739ComUsuM = new string[] {""} ;
         T00363_A703ComFecM = new DateTime[] {DateTime.MinValue} ;
         T00363_A671ComAut = new short[1] ;
         T00363_A737ComUsuAut = new string[] {""} ;
         T00363_A701ComFecAut = new DateTime[] {DateTime.MinValue} ;
         T00363_A709ComImpAfec = new short[1] ;
         T00363_A711ComImpTip = new short[1] ;
         T00363_A710ComImpCod = new string[] {""} ;
         T00363_A712ComImpTipCos = new string[] {""} ;
         T00363_A726ComRetAfecto = new short[1] ;
         T00363_A727ComRetCod = new string[] {""} ;
         T00363_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         T00363_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         T00363_A735ComTipReg = new string[] {""} ;
         T00363_A719ComIVADUA = new decimal[1] ;
         T00363_A680ComCif = new short[1] ;
         T00363_A725ComRefTDoc = new string[] {""} ;
         T00363_A722ComRefDoc = new string[] {""} ;
         T00363_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         T00363_A705ComFlagRet = new short[1] ;
         T00363_n705ComFlagRet = new bool[] {false} ;
         T00363_A672ComBanCod = new int[1] ;
         T00363_A674ComBanCta = new string[] {""} ;
         T00363_A678ComBanReg = new string[] {""} ;
         T00363_A676ComBanForCod = new int[1] ;
         T00363_A677ComBanImp = new decimal[1] ;
         T00363_A675ComBanDoc = new string[] {""} ;
         T00363_A679ComBanTipC = new decimal[1] ;
         T00363_A673ComBanConc = new int[1] ;
         T00363_A723ComRefDom = new string[] {""} ;
         T00363_A149TipCod = new string[] {""} ;
         T00363_A244PrvCod = new string[] {""} ;
         T00363_A246ComMon = new int[1] ;
         T00363_A245ComConpCod = new int[1] ;
         T00363_A247PrvDsc = new string[] {""} ;
         sMode109 = "";
         T003619_A149TipCod = new string[] {""} ;
         T003619_A243ComCod = new string[] {""} ;
         T003619_A244PrvCod = new string[] {""} ;
         T003620_A149TipCod = new string[] {""} ;
         T003620_A243ComCod = new string[] {""} ;
         T003620_A244PrvCod = new string[] {""} ;
         T00362_A243ComCod = new string[] {""} ;
         T00362_A248ComFec = new DateTime[] {DateTime.MinValue} ;
         T00362_A708ComFVcto = new DateTime[] {DateTime.MinValue} ;
         T00362_A707ComFReg = new DateTime[] {DateTime.MinValue} ;
         T00362_A249ComRef = new string[] {""} ;
         T00362_A721ComOcSt = new short[1] ;
         T00362_A698ComDscto = new decimal[1] ;
         T00362_A728ComRete1 = new decimal[1] ;
         T00362_A729ComRete2 = new decimal[1] ;
         T00362_A706ComFlete = new decimal[1] ;
         T00362_A713ComISC = new decimal[1] ;
         T00362_A717ComPorIva = new decimal[1] ;
         T00362_A720ComObs = new string[] {""} ;
         T00362_A714ComItem = new short[1] ;
         T00362_A718ComRedondeo = new decimal[1] ;
         T00362_A740ComValor = new decimal[1] ;
         T00362_A741ComVouAno = new short[1] ;
         T00362_A742ComVouMes = new short[1] ;
         T00362_A734ComTASICod = new int[1] ;
         T00362_A743ComVouNum = new string[] {""} ;
         T00362_A738ComUsuC = new string[] {""} ;
         T00362_A702ComFecC = new DateTime[] {DateTime.MinValue} ;
         T00362_A739ComUsuM = new string[] {""} ;
         T00362_A703ComFecM = new DateTime[] {DateTime.MinValue} ;
         T00362_A671ComAut = new short[1] ;
         T00362_A737ComUsuAut = new string[] {""} ;
         T00362_A701ComFecAut = new DateTime[] {DateTime.MinValue} ;
         T00362_A709ComImpAfec = new short[1] ;
         T00362_A711ComImpTip = new short[1] ;
         T00362_A710ComImpCod = new string[] {""} ;
         T00362_A712ComImpTipCos = new string[] {""} ;
         T00362_A726ComRetAfecto = new short[1] ;
         T00362_A727ComRetCod = new string[] {""} ;
         T00362_A730ComRetFec = new DateTime[] {DateTime.MinValue} ;
         T00362_A704ComFecPago = new DateTime[] {DateTime.MinValue} ;
         T00362_A735ComTipReg = new string[] {""} ;
         T00362_A719ComIVADUA = new decimal[1] ;
         T00362_A680ComCif = new short[1] ;
         T00362_A725ComRefTDoc = new string[] {""} ;
         T00362_A722ComRefDoc = new string[] {""} ;
         T00362_A724ComRefFec = new DateTime[] {DateTime.MinValue} ;
         T00362_A705ComFlagRet = new short[1] ;
         T00362_n705ComFlagRet = new bool[] {false} ;
         T00362_A672ComBanCod = new int[1] ;
         T00362_A674ComBanCta = new string[] {""} ;
         T00362_A678ComBanReg = new string[] {""} ;
         T00362_A676ComBanForCod = new int[1] ;
         T00362_A677ComBanImp = new decimal[1] ;
         T00362_A675ComBanDoc = new string[] {""} ;
         T00362_A679ComBanTipC = new decimal[1] ;
         T00362_A673ComBanConc = new int[1] ;
         T00362_A723ComRefDom = new string[] {""} ;
         T00362_A149TipCod = new string[] {""} ;
         T00362_A244PrvCod = new string[] {""} ;
         T00362_A246ComMon = new int[1] ;
         T00362_A245ComConpCod = new int[1] ;
         T00362_A247PrvDsc = new string[] {""} ;
         T003624_A247PrvDsc = new string[] {""} ;
         T003626_A716ComSubAfe = new decimal[1] ;
         T003626_A732ComSubIna = new decimal[1] ;
         T003626_A731ComSubImportacion = new decimal[1] ;
         T003627_A681ComConpAbr = new string[] {""} ;
         T003627_A682ComConpDias = new short[1] ;
         T003628_A149TipCod = new string[] {""} ;
         T003628_A243ComCod = new string[] {""} ;
         T003628_A244PrvCod = new string[] {""} ;
         T003628_A250ComDItem = new short[1] ;
         T003628_A251ComDOrdCod = new string[] {""} ;
         T003629_A149TipCod = new string[] {""} ;
         T003629_A243ComCod = new string[] {""} ;
         T003629_A244PrvCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003630_A149TipCod = new string[] {""} ;
         ZZ149TipCod = "";
         ZZ243ComCod = "";
         ZZ244PrvCod = "";
         ZZ248ComFec = DateTime.MinValue;
         ZZ708ComFVcto = DateTime.MinValue;
         ZZ707ComFReg = DateTime.MinValue;
         ZZ249ComRef = "";
         ZZ720ComObs = "";
         ZZ743ComVouNum = "";
         ZZ738ComUsuC = "";
         ZZ702ComFecC = (DateTime)(DateTime.MinValue);
         ZZ739ComUsuM = "";
         ZZ703ComFecM = (DateTime)(DateTime.MinValue);
         ZZ737ComUsuAut = "";
         ZZ701ComFecAut = (DateTime)(DateTime.MinValue);
         ZZ710ComImpCod = "";
         ZZ712ComImpTipCos = "";
         ZZ727ComRetCod = "";
         ZZ730ComRetFec = DateTime.MinValue;
         ZZ704ComFecPago = DateTime.MinValue;
         ZZ735ComTipReg = "";
         ZZ725ComRefTDoc = "";
         ZZ722ComRefDoc = "";
         ZZ724ComRefFec = DateTime.MinValue;
         ZZ674ComBanCta = "";
         ZZ678ComBanReg = "";
         ZZ675ComBanDoc = "";
         ZZ723ComRefDom = "";
         ZZ247PrvDsc = "";
         ZZ681ComConpAbr = "";
         T003631_A246ComMon = new int[1] ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpcompras__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpcompras__default(),
            new Object[][] {
                new Object[] {
               T00362_A243ComCod, T00362_A248ComFec, T00362_A708ComFVcto, T00362_A707ComFReg, T00362_A249ComRef, T00362_A721ComOcSt, T00362_A698ComDscto, T00362_A728ComRete1, T00362_A729ComRete2, T00362_A706ComFlete,
               T00362_A713ComISC, T00362_A717ComPorIva, T00362_A720ComObs, T00362_A714ComItem, T00362_A718ComRedondeo, T00362_A740ComValor, T00362_A741ComVouAno, T00362_A742ComVouMes, T00362_A734ComTASICod, T00362_A743ComVouNum,
               T00362_A738ComUsuC, T00362_A702ComFecC, T00362_A739ComUsuM, T00362_A703ComFecM, T00362_A671ComAut, T00362_A737ComUsuAut, T00362_A701ComFecAut, T00362_A709ComImpAfec, T00362_A711ComImpTip, T00362_A710ComImpCod,
               T00362_A712ComImpTipCos, T00362_A726ComRetAfecto, T00362_A727ComRetCod, T00362_A730ComRetFec, T00362_A704ComFecPago, T00362_A735ComTipReg, T00362_A719ComIVADUA, T00362_A680ComCif, T00362_A725ComRefTDoc, T00362_A722ComRefDoc,
               T00362_A724ComRefFec, T00362_A705ComFlagRet, T00362_n705ComFlagRet, T00362_A672ComBanCod, T00362_A674ComBanCta, T00362_A678ComBanReg, T00362_A676ComBanForCod, T00362_A677ComBanImp, T00362_A675ComBanDoc, T00362_A679ComBanTipC,
               T00362_A673ComBanConc, T00362_A723ComRefDom, T00362_A149TipCod, T00362_A244PrvCod, T00362_A246ComMon, T00362_A245ComConpCod, T00362_A247PrvDsc
               }
               , new Object[] {
               T00363_A243ComCod, T00363_A248ComFec, T00363_A708ComFVcto, T00363_A707ComFReg, T00363_A249ComRef, T00363_A721ComOcSt, T00363_A698ComDscto, T00363_A728ComRete1, T00363_A729ComRete2, T00363_A706ComFlete,
               T00363_A713ComISC, T00363_A717ComPorIva, T00363_A720ComObs, T00363_A714ComItem, T00363_A718ComRedondeo, T00363_A740ComValor, T00363_A741ComVouAno, T00363_A742ComVouMes, T00363_A734ComTASICod, T00363_A743ComVouNum,
               T00363_A738ComUsuC, T00363_A702ComFecC, T00363_A739ComUsuM, T00363_A703ComFecM, T00363_A671ComAut, T00363_A737ComUsuAut, T00363_A701ComFecAut, T00363_A709ComImpAfec, T00363_A711ComImpTip, T00363_A710ComImpCod,
               T00363_A712ComImpTipCos, T00363_A726ComRetAfecto, T00363_A727ComRetCod, T00363_A730ComRetFec, T00363_A704ComFecPago, T00363_A735ComTipReg, T00363_A719ComIVADUA, T00363_A680ComCif, T00363_A725ComRefTDoc, T00363_A722ComRefDoc,
               T00363_A724ComRefFec, T00363_A705ComFlagRet, T00363_n705ComFlagRet, T00363_A672ComBanCod, T00363_A674ComBanCta, T00363_A678ComBanReg, T00363_A676ComBanForCod, T00363_A677ComBanImp, T00363_A675ComBanDoc, T00363_A679ComBanTipC,
               T00363_A673ComBanConc, T00363_A723ComRefDom, T00363_A149TipCod, T00363_A244PrvCod, T00363_A246ComMon, T00363_A245ComConpCod, T00363_A247PrvDsc
               }
               , new Object[] {
               T00364_A149TipCod
               }
               , new Object[] {
               T00365_A247PrvDsc
               }
               , new Object[] {
               T00366_A246ComMon
               }
               , new Object[] {
               T00367_A681ComConpAbr, T00367_A682ComConpDias
               }
               , new Object[] {
               T00369_A716ComSubAfe, T00369_A732ComSubIna, T00369_A731ComSubImportacion
               }
               , new Object[] {
               T003611_A243ComCod, T003611_A248ComFec, T003611_A708ComFVcto, T003611_A707ComFReg, T003611_A249ComRef, T003611_A721ComOcSt, T003611_A698ComDscto, T003611_A728ComRete1, T003611_A729ComRete2, T003611_A706ComFlete,
               T003611_A713ComISC, T003611_A717ComPorIva, T003611_A720ComObs, T003611_A714ComItem, T003611_A718ComRedondeo, T003611_A740ComValor, T003611_A247PrvDsc, T003611_A741ComVouAno, T003611_A742ComVouMes, T003611_A734ComTASICod,
               T003611_A743ComVouNum, T003611_A738ComUsuC, T003611_A702ComFecC, T003611_A739ComUsuM, T003611_A703ComFecM, T003611_A671ComAut, T003611_A737ComUsuAut, T003611_A701ComFecAut, T003611_A709ComImpAfec, T003611_A711ComImpTip,
               T003611_A710ComImpCod, T003611_A712ComImpTipCos, T003611_A726ComRetAfecto, T003611_A727ComRetCod, T003611_A730ComRetFec, T003611_A704ComFecPago, T003611_A735ComTipReg, T003611_A719ComIVADUA, T003611_A680ComCif, T003611_A725ComRefTDoc,
               T003611_A722ComRefDoc, T003611_A724ComRefFec, T003611_A705ComFlagRet, T003611_n705ComFlagRet, T003611_A672ComBanCod, T003611_A674ComBanCta, T003611_A678ComBanReg, T003611_A676ComBanForCod, T003611_A677ComBanImp, T003611_A675ComBanDoc,
               T003611_A679ComBanTipC, T003611_A673ComBanConc, T003611_A681ComConpAbr, T003611_A682ComConpDias, T003611_A723ComRefDom, T003611_A149TipCod, T003611_A244PrvCod, T003611_A246ComMon, T003611_A245ComConpCod, T003611_A716ComSubAfe,
               T003611_A732ComSubIna, T003611_A731ComSubImportacion
               }
               , new Object[] {
               T003612_A149TipCod
               }
               , new Object[] {
               T003613_A247PrvDsc
               }
               , new Object[] {
               T003615_A716ComSubAfe, T003615_A732ComSubIna, T003615_A731ComSubImportacion
               }
               , new Object[] {
               T003616_A246ComMon
               }
               , new Object[] {
               T003617_A681ComConpAbr, T003617_A682ComConpDias
               }
               , new Object[] {
               T003618_A149TipCod, T003618_A243ComCod, T003618_A244PrvCod
               }
               , new Object[] {
               T003619_A149TipCod, T003619_A243ComCod, T003619_A244PrvCod
               }
               , new Object[] {
               T003620_A149TipCod, T003620_A243ComCod, T003620_A244PrvCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003624_A247PrvDsc
               }
               , new Object[] {
               T003626_A716ComSubAfe, T003626_A732ComSubIna, T003626_A731ComSubImportacion
               }
               , new Object[] {
               T003627_A681ComConpAbr, T003627_A682ComConpDias
               }
               , new Object[] {
               T003628_A149TipCod, T003628_A243ComCod, T003628_A244PrvCod, T003628_A250ComDItem, T003628_A251ComDOrdCod
               }
               , new Object[] {
               T003629_A149TipCod, T003629_A243ComCod, T003629_A244PrvCod
               }
               , new Object[] {
               T003630_A149TipCod
               }
               , new Object[] {
               T003631_A246ComMon
               }
            }
         );
      }

      private short Z721ComOcSt ;
      private short Z714ComItem ;
      private short Z741ComVouAno ;
      private short Z742ComVouMes ;
      private short Z671ComAut ;
      private short Z709ComImpAfec ;
      private short Z711ComImpTip ;
      private short Z726ComRetAfecto ;
      private short Z680ComCif ;
      private short Z705ComFlagRet ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A721ComOcSt ;
      private short A714ComItem ;
      private short A741ComVouAno ;
      private short A742ComVouMes ;
      private short A671ComAut ;
      private short A709ComImpAfec ;
      private short A711ComImpTip ;
      private short A726ComRetAfecto ;
      private short A680ComCif ;
      private short A705ComFlagRet ;
      private short A682ComConpDias ;
      private short GX_JID ;
      private short Z682ComConpDias ;
      private short RcdFound109 ;
      private short nIsDirty_109 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ721ComOcSt ;
      private short ZZ714ComItem ;
      private short ZZ741ComVouAno ;
      private short ZZ742ComVouMes ;
      private short ZZ671ComAut ;
      private short ZZ709ComImpAfec ;
      private short ZZ711ComImpTip ;
      private short ZZ726ComRetAfecto ;
      private short ZZ680ComCif ;
      private short ZZ705ComFlagRet ;
      private short ZZ682ComConpDias ;
      private int Z734ComTASICod ;
      private int Z672ComBanCod ;
      private int Z676ComBanForCod ;
      private int Z673ComBanConc ;
      private int Z246ComMon ;
      private int Z245ComConpCod ;
      private int A246ComMon ;
      private int A245ComConpCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipCod_Enabled ;
      private int edtComCod_Enabled ;
      private int edtPrvCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtComFec_Enabled ;
      private int edtComFVcto_Enabled ;
      private int edtComFReg_Enabled ;
      private int edtComMon_Enabled ;
      private int edtComConpCod_Enabled ;
      private int edtComRef_Enabled ;
      private int edtComOcSt_Enabled ;
      private int edtComDscto_Enabled ;
      private int edtComRete1_Enabled ;
      private int edtComRete2_Enabled ;
      private int edtComFlete_Enabled ;
      private int edtComISC_Enabled ;
      private int edtComPorIva_Enabled ;
      private int edtComObs_Enabled ;
      private int edtComItem_Enabled ;
      private int edtComRedondeo_Enabled ;
      private int edtComValor_Enabled ;
      private int edtPrvDsc_Enabled ;
      private int edtComVouAno_Enabled ;
      private int edtComVouMes_Enabled ;
      private int A734ComTASICod ;
      private int edtComTASICod_Enabled ;
      private int edtComVouNum_Enabled ;
      private int edtComUsuC_Enabled ;
      private int edtComFecC_Enabled ;
      private int edtComUsuM_Enabled ;
      private int edtComFecM_Enabled ;
      private int edtComAut_Enabled ;
      private int edtComUsuAut_Enabled ;
      private int edtComFecAut_Enabled ;
      private int edtComImpAfec_Enabled ;
      private int edtComImpTip_Enabled ;
      private int edtComImpCod_Enabled ;
      private int edtComImpTipCos_Enabled ;
      private int edtComRetAfecto_Enabled ;
      private int edtComRetCod_Enabled ;
      private int edtComRetFec_Enabled ;
      private int edtComFecPago_Enabled ;
      private int edtComTipReg_Enabled ;
      private int edtComIVADUA_Enabled ;
      private int edtComCif_Enabled ;
      private int edtComRefTDoc_Enabled ;
      private int edtComRefDoc_Enabled ;
      private int edtComRefFec_Enabled ;
      private int edtComFlagRet_Enabled ;
      private int A672ComBanCod ;
      private int edtComBanCod_Enabled ;
      private int edtComBanCta_Enabled ;
      private int edtComBanReg_Enabled ;
      private int A676ComBanForCod ;
      private int edtComBanForCod_Enabled ;
      private int edtComBanImp_Enabled ;
      private int edtComBanDoc_Enabled ;
      private int edtComBanTipC_Enabled ;
      private int A673ComBanConc ;
      private int edtComBanConc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ246ComMon ;
      private int ZZ245ComConpCod ;
      private int ZZ734ComTASICod ;
      private int ZZ672ComBanCod ;
      private int ZZ676ComBanForCod ;
      private int ZZ673ComBanConc ;
      private decimal Z698ComDscto ;
      private decimal Z728ComRete1 ;
      private decimal Z729ComRete2 ;
      private decimal Z706ComFlete ;
      private decimal Z713ComISC ;
      private decimal Z717ComPorIva ;
      private decimal Z718ComRedondeo ;
      private decimal Z740ComValor ;
      private decimal Z719ComIVADUA ;
      private decimal Z677ComBanImp ;
      private decimal Z679ComBanTipC ;
      private decimal A698ComDscto ;
      private decimal A728ComRete1 ;
      private decimal A729ComRete2 ;
      private decimal A706ComFlete ;
      private decimal A713ComISC ;
      private decimal A717ComPorIva ;
      private decimal A718ComRedondeo ;
      private decimal A740ComValor ;
      private decimal A719ComIVADUA ;
      private decimal A677ComBanImp ;
      private decimal A679ComBanTipC ;
      private decimal A716ComSubAfe ;
      private decimal A732ComSubIna ;
      private decimal A733ComSubTotal ;
      private decimal A715ComIva ;
      private decimal A736ComTotal ;
      private decimal A731ComSubImportacion ;
      private decimal Z716ComSubAfe ;
      private decimal Z732ComSubIna ;
      private decimal Z731ComSubImportacion ;
      private decimal Z715ComIva ;
      private decimal Z733ComSubTotal ;
      private decimal Z736ComTotal ;
      private decimal ZZ698ComDscto ;
      private decimal ZZ728ComRete1 ;
      private decimal ZZ729ComRete2 ;
      private decimal ZZ706ComFlete ;
      private decimal ZZ713ComISC ;
      private decimal ZZ717ComPorIva ;
      private decimal ZZ718ComRedondeo ;
      private decimal ZZ740ComValor ;
      private decimal ZZ719ComIVADUA ;
      private decimal ZZ677ComBanImp ;
      private decimal ZZ679ComBanTipC ;
      private decimal ZZ716ComSubAfe ;
      private decimal ZZ732ComSubIna ;
      private decimal ZZ731ComSubImportacion ;
      private decimal ZZ715ComIva ;
      private decimal ZZ733ComSubTotal ;
      private decimal ZZ736ComTotal ;
      private string sPrefix ;
      private string Z149TipCod ;
      private string Z243ComCod ;
      private string Z244PrvCod ;
      private string Z249ComRef ;
      private string Z743ComVouNum ;
      private string Z738ComUsuC ;
      private string Z739ComUsuM ;
      private string Z737ComUsuAut ;
      private string Z710ComImpCod ;
      private string Z712ComImpTipCos ;
      private string Z727ComRetCod ;
      private string Z735ComTipReg ;
      private string Z725ComRefTDoc ;
      private string Z722ComRefDoc ;
      private string Z674ComBanCta ;
      private string Z678ComBanReg ;
      private string Z675ComBanDoc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A149TipCod ;
      private string A244PrvCod ;
      private string A243ComCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipCod_Internalname ;
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
      private string edtTipCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtComCod_Internalname ;
      private string edtComCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPrvCod_Internalname ;
      private string edtPrvCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtComFec_Internalname ;
      private string edtComFec_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtComFVcto_Internalname ;
      private string edtComFVcto_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtComFReg_Internalname ;
      private string edtComFReg_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtComMon_Internalname ;
      private string edtComMon_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtComConpCod_Internalname ;
      private string edtComConpCod_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtComRef_Internalname ;
      private string A249ComRef ;
      private string edtComRef_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtComOcSt_Internalname ;
      private string edtComOcSt_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtComDscto_Internalname ;
      private string edtComDscto_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtComRete1_Internalname ;
      private string edtComRete1_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtComRete2_Internalname ;
      private string edtComRete2_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtComFlete_Internalname ;
      private string edtComFlete_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtComISC_Internalname ;
      private string edtComISC_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtComPorIva_Internalname ;
      private string edtComPorIva_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtComObs_Internalname ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtComItem_Internalname ;
      private string edtComItem_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtComRedondeo_Internalname ;
      private string edtComRedondeo_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtComValor_Internalname ;
      private string edtComValor_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtPrvDsc_Internalname ;
      private string A247PrvDsc ;
      private string edtPrvDsc_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtComVouAno_Internalname ;
      private string edtComVouAno_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtComVouMes_Internalname ;
      private string edtComVouMes_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtComTASICod_Internalname ;
      private string edtComTASICod_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtComVouNum_Internalname ;
      private string A743ComVouNum ;
      private string edtComVouNum_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtComUsuC_Internalname ;
      private string A738ComUsuC ;
      private string edtComUsuC_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtComFecC_Internalname ;
      private string edtComFecC_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtComUsuM_Internalname ;
      private string A739ComUsuM ;
      private string edtComUsuM_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtComFecM_Internalname ;
      private string edtComFecM_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtComAut_Internalname ;
      private string edtComAut_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtComUsuAut_Internalname ;
      private string A737ComUsuAut ;
      private string edtComUsuAut_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtComFecAut_Internalname ;
      private string edtComFecAut_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtComImpAfec_Internalname ;
      private string edtComImpAfec_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtComImpTip_Internalname ;
      private string edtComImpTip_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtComImpCod_Internalname ;
      private string A710ComImpCod ;
      private string edtComImpCod_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtComImpTipCos_Internalname ;
      private string A712ComImpTipCos ;
      private string edtComImpTipCos_Jsonclick ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string edtComRetAfecto_Internalname ;
      private string edtComRetAfecto_Jsonclick ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string edtComRetCod_Internalname ;
      private string A727ComRetCod ;
      private string edtComRetCod_Jsonclick ;
      private string lblTextblock39_Internalname ;
      private string lblTextblock39_Jsonclick ;
      private string edtComRetFec_Internalname ;
      private string edtComRetFec_Jsonclick ;
      private string lblTextblock40_Internalname ;
      private string lblTextblock40_Jsonclick ;
      private string edtComFecPago_Internalname ;
      private string edtComFecPago_Jsonclick ;
      private string lblTextblock41_Internalname ;
      private string lblTextblock41_Jsonclick ;
      private string edtComTipReg_Internalname ;
      private string A735ComTipReg ;
      private string edtComTipReg_Jsonclick ;
      private string lblTextblock42_Internalname ;
      private string lblTextblock42_Jsonclick ;
      private string edtComIVADUA_Internalname ;
      private string edtComIVADUA_Jsonclick ;
      private string lblTextblock43_Internalname ;
      private string lblTextblock43_Jsonclick ;
      private string edtComCif_Internalname ;
      private string edtComCif_Jsonclick ;
      private string lblTextblock44_Internalname ;
      private string lblTextblock44_Jsonclick ;
      private string edtComRefTDoc_Internalname ;
      private string A725ComRefTDoc ;
      private string edtComRefTDoc_Jsonclick ;
      private string lblTextblock45_Internalname ;
      private string lblTextblock45_Jsonclick ;
      private string edtComRefDoc_Internalname ;
      private string A722ComRefDoc ;
      private string edtComRefDoc_Jsonclick ;
      private string lblTextblock46_Internalname ;
      private string lblTextblock46_Jsonclick ;
      private string edtComRefFec_Internalname ;
      private string edtComRefFec_Jsonclick ;
      private string lblTextblock47_Internalname ;
      private string lblTextblock47_Jsonclick ;
      private string edtComFlagRet_Internalname ;
      private string edtComFlagRet_Jsonclick ;
      private string lblTextblock48_Internalname ;
      private string lblTextblock48_Jsonclick ;
      private string edtComBanCod_Internalname ;
      private string edtComBanCod_Jsonclick ;
      private string lblTextblock49_Internalname ;
      private string lblTextblock49_Jsonclick ;
      private string edtComBanCta_Internalname ;
      private string A674ComBanCta ;
      private string edtComBanCta_Jsonclick ;
      private string lblTextblock50_Internalname ;
      private string lblTextblock50_Jsonclick ;
      private string edtComBanReg_Internalname ;
      private string A678ComBanReg ;
      private string edtComBanReg_Jsonclick ;
      private string lblTextblock51_Internalname ;
      private string lblTextblock51_Jsonclick ;
      private string edtComBanForCod_Internalname ;
      private string edtComBanForCod_Jsonclick ;
      private string lblTextblock52_Internalname ;
      private string lblTextblock52_Jsonclick ;
      private string edtComBanImp_Internalname ;
      private string edtComBanImp_Jsonclick ;
      private string lblTextblock53_Internalname ;
      private string lblTextblock53_Jsonclick ;
      private string edtComBanDoc_Internalname ;
      private string A675ComBanDoc ;
      private string edtComBanDoc_Jsonclick ;
      private string lblTextblock54_Internalname ;
      private string lblTextblock54_Jsonclick ;
      private string edtComBanTipC_Internalname ;
      private string edtComBanTipC_Jsonclick ;
      private string lblTextblock55_Internalname ;
      private string lblTextblock55_Jsonclick ;
      private string edtComBanConc_Internalname ;
      private string edtComBanConc_Jsonclick ;
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
      private string A681ComConpAbr ;
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z247PrvDsc ;
      private string Z681ComConpAbr ;
      private string sMode109 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ149TipCod ;
      private string ZZ243ComCod ;
      private string ZZ244PrvCod ;
      private string ZZ249ComRef ;
      private string ZZ743ComVouNum ;
      private string ZZ738ComUsuC ;
      private string ZZ739ComUsuM ;
      private string ZZ737ComUsuAut ;
      private string ZZ710ComImpCod ;
      private string ZZ712ComImpTipCos ;
      private string ZZ727ComRetCod ;
      private string ZZ735ComTipReg ;
      private string ZZ725ComRefTDoc ;
      private string ZZ722ComRefDoc ;
      private string ZZ674ComBanCta ;
      private string ZZ678ComBanReg ;
      private string ZZ675ComBanDoc ;
      private string ZZ247PrvDsc ;
      private string ZZ681ComConpAbr ;
      private DateTime Z702ComFecC ;
      private DateTime Z703ComFecM ;
      private DateTime Z701ComFecAut ;
      private DateTime A702ComFecC ;
      private DateTime A703ComFecM ;
      private DateTime A701ComFecAut ;
      private DateTime ZZ702ComFecC ;
      private DateTime ZZ703ComFecM ;
      private DateTime ZZ701ComFecAut ;
      private DateTime Z248ComFec ;
      private DateTime Z708ComFVcto ;
      private DateTime Z707ComFReg ;
      private DateTime Z730ComRetFec ;
      private DateTime Z704ComFecPago ;
      private DateTime Z724ComRefFec ;
      private DateTime A248ComFec ;
      private DateTime A708ComFVcto ;
      private DateTime A707ComFReg ;
      private DateTime A730ComRetFec ;
      private DateTime A704ComFecPago ;
      private DateTime A724ComRefFec ;
      private DateTime ZZ248ComFec ;
      private DateTime ZZ708ComFVcto ;
      private DateTime ZZ707ComFReg ;
      private DateTime ZZ730ComRetFec ;
      private DateTime ZZ704ComFecPago ;
      private DateTime ZZ724ComRefFec ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n705ComFlagRet ;
      private bool Gx_longc ;
      private string A720ComObs ;
      private string Z720ComObs ;
      private string ZZ720ComObs ;
      private string Z723ComRefDom ;
      private string A723ComRefDom ;
      private string ZZ723ComRefDom ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T003611_A243ComCod ;
      private DateTime[] T003611_A248ComFec ;
      private DateTime[] T003611_A708ComFVcto ;
      private DateTime[] T003611_A707ComFReg ;
      private string[] T003611_A249ComRef ;
      private short[] T003611_A721ComOcSt ;
      private decimal[] T003611_A698ComDscto ;
      private decimal[] T003611_A728ComRete1 ;
      private decimal[] T003611_A729ComRete2 ;
      private decimal[] T003611_A706ComFlete ;
      private decimal[] T003611_A713ComISC ;
      private decimal[] T003611_A717ComPorIva ;
      private string[] T003611_A720ComObs ;
      private short[] T003611_A714ComItem ;
      private decimal[] T003611_A718ComRedondeo ;
      private decimal[] T003611_A740ComValor ;
      private string[] T003611_A247PrvDsc ;
      private short[] T003611_A741ComVouAno ;
      private short[] T003611_A742ComVouMes ;
      private int[] T003611_A734ComTASICod ;
      private string[] T003611_A743ComVouNum ;
      private string[] T003611_A738ComUsuC ;
      private DateTime[] T003611_A702ComFecC ;
      private string[] T003611_A739ComUsuM ;
      private DateTime[] T003611_A703ComFecM ;
      private short[] T003611_A671ComAut ;
      private string[] T003611_A737ComUsuAut ;
      private DateTime[] T003611_A701ComFecAut ;
      private short[] T003611_A709ComImpAfec ;
      private short[] T003611_A711ComImpTip ;
      private string[] T003611_A710ComImpCod ;
      private string[] T003611_A712ComImpTipCos ;
      private short[] T003611_A726ComRetAfecto ;
      private string[] T003611_A727ComRetCod ;
      private DateTime[] T003611_A730ComRetFec ;
      private DateTime[] T003611_A704ComFecPago ;
      private string[] T003611_A735ComTipReg ;
      private decimal[] T003611_A719ComIVADUA ;
      private short[] T003611_A680ComCif ;
      private string[] T003611_A725ComRefTDoc ;
      private string[] T003611_A722ComRefDoc ;
      private DateTime[] T003611_A724ComRefFec ;
      private short[] T003611_A705ComFlagRet ;
      private bool[] T003611_n705ComFlagRet ;
      private int[] T003611_A672ComBanCod ;
      private string[] T003611_A674ComBanCta ;
      private string[] T003611_A678ComBanReg ;
      private int[] T003611_A676ComBanForCod ;
      private decimal[] T003611_A677ComBanImp ;
      private string[] T003611_A675ComBanDoc ;
      private decimal[] T003611_A679ComBanTipC ;
      private int[] T003611_A673ComBanConc ;
      private string[] T003611_A681ComConpAbr ;
      private short[] T003611_A682ComConpDias ;
      private string[] T003611_A723ComRefDom ;
      private string[] T003611_A149TipCod ;
      private string[] T003611_A244PrvCod ;
      private int[] T003611_A246ComMon ;
      private int[] T003611_A245ComConpCod ;
      private decimal[] T003611_A716ComSubAfe ;
      private decimal[] T003611_A732ComSubIna ;
      private decimal[] T003611_A731ComSubImportacion ;
      private string[] T00365_A247PrvDsc ;
      private string[] T00364_A149TipCod ;
      private decimal[] T00369_A716ComSubAfe ;
      private decimal[] T00369_A732ComSubIna ;
      private decimal[] T00369_A731ComSubImportacion ;
      private int[] T00366_A246ComMon ;
      private string[] T00367_A681ComConpAbr ;
      private short[] T00367_A682ComConpDias ;
      private string[] T003612_A149TipCod ;
      private string[] T003613_A247PrvDsc ;
      private decimal[] T003615_A716ComSubAfe ;
      private decimal[] T003615_A732ComSubIna ;
      private decimal[] T003615_A731ComSubImportacion ;
      private int[] T003616_A246ComMon ;
      private string[] T003617_A681ComConpAbr ;
      private short[] T003617_A682ComConpDias ;
      private string[] T003618_A149TipCod ;
      private string[] T003618_A243ComCod ;
      private string[] T003618_A244PrvCod ;
      private string[] T00363_A243ComCod ;
      private DateTime[] T00363_A248ComFec ;
      private DateTime[] T00363_A708ComFVcto ;
      private DateTime[] T00363_A707ComFReg ;
      private string[] T00363_A249ComRef ;
      private short[] T00363_A721ComOcSt ;
      private decimal[] T00363_A698ComDscto ;
      private decimal[] T00363_A728ComRete1 ;
      private decimal[] T00363_A729ComRete2 ;
      private decimal[] T00363_A706ComFlete ;
      private decimal[] T00363_A713ComISC ;
      private decimal[] T00363_A717ComPorIva ;
      private string[] T00363_A720ComObs ;
      private short[] T00363_A714ComItem ;
      private decimal[] T00363_A718ComRedondeo ;
      private decimal[] T00363_A740ComValor ;
      private short[] T00363_A741ComVouAno ;
      private short[] T00363_A742ComVouMes ;
      private int[] T00363_A734ComTASICod ;
      private string[] T00363_A743ComVouNum ;
      private string[] T00363_A738ComUsuC ;
      private DateTime[] T00363_A702ComFecC ;
      private string[] T00363_A739ComUsuM ;
      private DateTime[] T00363_A703ComFecM ;
      private short[] T00363_A671ComAut ;
      private string[] T00363_A737ComUsuAut ;
      private DateTime[] T00363_A701ComFecAut ;
      private short[] T00363_A709ComImpAfec ;
      private short[] T00363_A711ComImpTip ;
      private string[] T00363_A710ComImpCod ;
      private string[] T00363_A712ComImpTipCos ;
      private short[] T00363_A726ComRetAfecto ;
      private string[] T00363_A727ComRetCod ;
      private DateTime[] T00363_A730ComRetFec ;
      private DateTime[] T00363_A704ComFecPago ;
      private string[] T00363_A735ComTipReg ;
      private decimal[] T00363_A719ComIVADUA ;
      private short[] T00363_A680ComCif ;
      private string[] T00363_A725ComRefTDoc ;
      private string[] T00363_A722ComRefDoc ;
      private DateTime[] T00363_A724ComRefFec ;
      private short[] T00363_A705ComFlagRet ;
      private bool[] T00363_n705ComFlagRet ;
      private int[] T00363_A672ComBanCod ;
      private string[] T00363_A674ComBanCta ;
      private string[] T00363_A678ComBanReg ;
      private int[] T00363_A676ComBanForCod ;
      private decimal[] T00363_A677ComBanImp ;
      private string[] T00363_A675ComBanDoc ;
      private decimal[] T00363_A679ComBanTipC ;
      private int[] T00363_A673ComBanConc ;
      private string[] T00363_A723ComRefDom ;
      private string[] T00363_A149TipCod ;
      private string[] T00363_A244PrvCod ;
      private int[] T00363_A246ComMon ;
      private int[] T00363_A245ComConpCod ;
      private string[] T00363_A247PrvDsc ;
      private string[] T003619_A149TipCod ;
      private string[] T003619_A243ComCod ;
      private string[] T003619_A244PrvCod ;
      private string[] T003620_A149TipCod ;
      private string[] T003620_A243ComCod ;
      private string[] T003620_A244PrvCod ;
      private string[] T00362_A243ComCod ;
      private DateTime[] T00362_A248ComFec ;
      private DateTime[] T00362_A708ComFVcto ;
      private DateTime[] T00362_A707ComFReg ;
      private string[] T00362_A249ComRef ;
      private short[] T00362_A721ComOcSt ;
      private decimal[] T00362_A698ComDscto ;
      private decimal[] T00362_A728ComRete1 ;
      private decimal[] T00362_A729ComRete2 ;
      private decimal[] T00362_A706ComFlete ;
      private decimal[] T00362_A713ComISC ;
      private decimal[] T00362_A717ComPorIva ;
      private string[] T00362_A720ComObs ;
      private short[] T00362_A714ComItem ;
      private decimal[] T00362_A718ComRedondeo ;
      private decimal[] T00362_A740ComValor ;
      private short[] T00362_A741ComVouAno ;
      private short[] T00362_A742ComVouMes ;
      private int[] T00362_A734ComTASICod ;
      private string[] T00362_A743ComVouNum ;
      private string[] T00362_A738ComUsuC ;
      private DateTime[] T00362_A702ComFecC ;
      private string[] T00362_A739ComUsuM ;
      private DateTime[] T00362_A703ComFecM ;
      private short[] T00362_A671ComAut ;
      private string[] T00362_A737ComUsuAut ;
      private DateTime[] T00362_A701ComFecAut ;
      private short[] T00362_A709ComImpAfec ;
      private short[] T00362_A711ComImpTip ;
      private string[] T00362_A710ComImpCod ;
      private string[] T00362_A712ComImpTipCos ;
      private short[] T00362_A726ComRetAfecto ;
      private string[] T00362_A727ComRetCod ;
      private DateTime[] T00362_A730ComRetFec ;
      private DateTime[] T00362_A704ComFecPago ;
      private string[] T00362_A735ComTipReg ;
      private decimal[] T00362_A719ComIVADUA ;
      private short[] T00362_A680ComCif ;
      private string[] T00362_A725ComRefTDoc ;
      private string[] T00362_A722ComRefDoc ;
      private DateTime[] T00362_A724ComRefFec ;
      private short[] T00362_A705ComFlagRet ;
      private bool[] T00362_n705ComFlagRet ;
      private int[] T00362_A672ComBanCod ;
      private string[] T00362_A674ComBanCta ;
      private string[] T00362_A678ComBanReg ;
      private int[] T00362_A676ComBanForCod ;
      private decimal[] T00362_A677ComBanImp ;
      private string[] T00362_A675ComBanDoc ;
      private decimal[] T00362_A679ComBanTipC ;
      private int[] T00362_A673ComBanConc ;
      private string[] T00362_A723ComRefDom ;
      private string[] T00362_A149TipCod ;
      private string[] T00362_A244PrvCod ;
      private int[] T00362_A246ComMon ;
      private int[] T00362_A245ComConpCod ;
      private string[] T00362_A247PrvDsc ;
      private string[] T003624_A247PrvDsc ;
      private decimal[] T003626_A716ComSubAfe ;
      private decimal[] T003626_A732ComSubIna ;
      private decimal[] T003626_A731ComSubImportacion ;
      private string[] T003627_A681ComConpAbr ;
      private short[] T003627_A682ComConpDias ;
      private string[] T003628_A149TipCod ;
      private string[] T003628_A243ComCod ;
      private string[] T003628_A244PrvCod ;
      private short[] T003628_A250ComDItem ;
      private string[] T003628_A251ComDOrdCod ;
      private string[] T003629_A149TipCod ;
      private string[] T003629_A243ComCod ;
      private string[] T003629_A244PrvCod ;
      private string[] T003630_A149TipCod ;
      private int[] T003631_A246ComMon ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpcompras__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpcompras__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003611;
        prmT003611 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        string cmdBufferT003611;
        cmdBufferT003611=" SELECT TM1.[ComCod], TM1.[ComFec], TM1.[ComFVcto], TM1.[ComFReg], TM1.[ComRef], TM1.[ComOcSt], TM1.[ComDscto], TM1.[ComRete1], TM1.[ComRete2], TM1.[ComFlete], TM1.[ComISC], TM1.[ComPorIva], TM1.[ComObs], TM1.[ComItem], TM1.[ComRedondeo], TM1.[ComValor], TM1.[PrvDsc], TM1.[ComVouAno], TM1.[ComVouMes], TM1.[ComTASICod], TM1.[ComVouNum], TM1.[ComUsuC], TM1.[ComFecC], TM1.[ComUsuM], TM1.[ComFecM], TM1.[ComAut], TM1.[ComUsuAut], TM1.[ComFecAut], TM1.[ComImpAfec], TM1.[ComImpTip], TM1.[ComImpCod], TM1.[ComImpTipCos], TM1.[ComRetAfecto], TM1.[ComRetCod], TM1.[ComRetFec], TM1.[ComFecPago], TM1.[ComTipReg], TM1.[ComIVADUA], TM1.[ComCif], TM1.[ComRefTDoc], TM1.[ComRefDoc], TM1.[ComRefFec], TM1.[ComFlagRet], TM1.[ComBanCod], TM1.[ComBanCta], TM1.[ComBanReg], TM1.[ComBanForCod], TM1.[ComBanImp], TM1.[ComBanDoc], TM1.[ComBanTipC], TM1.[ComBanConc], T3.[ConpAbr] AS ComConpAbr, T3.[ConpDias] AS ComConpDias, TM1.[ComRefDom], TM1.[TipCod], TM1.[PrvCod], TM1.[ComMon] AS ComMon, TM1.[ComConpCod] AS ComConpCod, COALESCE( T2.[ComSubAfe], 0) AS ComSubAfe, COALESCE( T2.[ComSubIna], 0) AS ComSubIna, COALESCE( T2.[ComSubImportacion], 0) AS ComSubImportacion FROM (([CPCOMPRAS] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN COALESCE( [ComDImp], 0) = 1 THEN ( "
        + " ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubImportacion FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T2 ON T2.[TipCod] = TM1.[TipCod] AND T2.[ComCod] = TM1.[ComCod] AND T2.[PrvCod] = TM1.[PrvCod]) INNER JOIN [CCONDICIONPAGO] T3 ON T3.[Conpcod] = TM1.[ComConpCod]) WHERE TM1.[TipCod] = @TipCod and TM1.[ComCod] = @ComCod and TM1.[PrvCod] = @PrvCod ORDER BY TM1.[TipCod], TM1.[ComCod], TM1.[PrvCod]  OPTION (FAST 100)" ;
        Object[] prmT00364;
        prmT00364 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT00365;
        prmT00365 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00369;
        prmT00369 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00366;
        prmT00366 = new Object[] {
        new ParDef("@ComMon",GXType.Int32,6,0)
        };
        Object[] prmT00367;
        prmT00367 = new Object[] {
        new ParDef("@ComConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003612;
        prmT003612 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003613;
        prmT003613 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003615;
        prmT003615 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003616;
        prmT003616 = new Object[] {
        new ParDef("@ComMon",GXType.Int32,6,0)
        };
        Object[] prmT003617;
        prmT003617 = new Object[] {
        new ParDef("@ComConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003618;
        prmT003618 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00363;
        prmT00363 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003619;
        prmT003619 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003620;
        prmT003620 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00362;
        prmT00362 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003621;
        prmT003621 = new Object[] {
        new ParDef("@PrvDsc",GXType.NChar,100,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@ComFec",GXType.Date,8,0) ,
        new ParDef("@ComFVcto",GXType.Date,8,0) ,
        new ParDef("@ComFReg",GXType.Date,8,0) ,
        new ParDef("@ComRef",GXType.NChar,10,0) ,
        new ParDef("@ComOcSt",GXType.Int16,1,0) ,
        new ParDef("@ComDscto",GXType.Decimal,15,2) ,
        new ParDef("@ComRete1",GXType.Decimal,15,2) ,
        new ParDef("@ComRete2",GXType.Decimal,15,2) ,
        new ParDef("@ComFlete",GXType.Decimal,15,2) ,
        new ParDef("@ComISC",GXType.Decimal,15,2) ,
        new ParDef("@ComPorIva",GXType.Decimal,6,2) ,
        new ParDef("@ComObs",GXType.NVarChar,500,0) ,
        new ParDef("@ComItem",GXType.Int16,4,0) ,
        new ParDef("@ComRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@ComValor",GXType.Decimal,15,2) ,
        new ParDef("@ComVouAno",GXType.Int16,4,0) ,
        new ParDef("@ComVouMes",GXType.Int16,2,0) ,
        new ParDef("@ComTASICod",GXType.Int32,6,0) ,
        new ParDef("@ComVouNum",GXType.NChar,10,0) ,
        new ParDef("@ComUsuC",GXType.NChar,10,0) ,
        new ParDef("@ComFecC",GXType.DateTime,8,5) ,
        new ParDef("@ComUsuM",GXType.NChar,10,0) ,
        new ParDef("@ComFecM",GXType.DateTime,8,5) ,
        new ParDef("@ComAut",GXType.Int16,1,0) ,
        new ParDef("@ComUsuAut",GXType.NChar,10,0) ,
        new ParDef("@ComFecAut",GXType.DateTime,8,5) ,
        new ParDef("@ComImpAfec",GXType.Int16,1,0) ,
        new ParDef("@ComImpTip",GXType.Int16,1,0) ,
        new ParDef("@ComImpCod",GXType.NChar,20,0) ,
        new ParDef("@ComImpTipCos",GXType.NChar,3,0) ,
        new ParDef("@ComRetAfecto",GXType.Int16,1,0) ,
        new ParDef("@ComRetCod",GXType.NChar,20,0) ,
        new ParDef("@ComRetFec",GXType.Date,8,0) ,
        new ParDef("@ComFecPago",GXType.Date,8,0) ,
        new ParDef("@ComTipReg",GXType.NChar,1,0) ,
        new ParDef("@ComIVADUA",GXType.Decimal,15,2) ,
        new ParDef("@ComCif",GXType.Int16,1,0) ,
        new ParDef("@ComRefTDoc",GXType.NChar,3,0) ,
        new ParDef("@ComRefDoc",GXType.NChar,20,0) ,
        new ParDef("@ComRefFec",GXType.Date,8,0) ,
        new ParDef("@ComFlagRet",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@ComBanCod",GXType.Int32,6,0) ,
        new ParDef("@ComBanCta",GXType.NChar,20,0) ,
        new ParDef("@ComBanReg",GXType.NChar,10,0) ,
        new ParDef("@ComBanForCod",GXType.Int32,6,0) ,
        new ParDef("@ComBanImp",GXType.Decimal,15,2) ,
        new ParDef("@ComBanDoc",GXType.NChar,20,0) ,
        new ParDef("@ComBanTipC",GXType.Decimal,15,5) ,
        new ParDef("@ComBanConc",GXType.Int32,6,0) ,
        new ParDef("@ComRefDom",GXType.NVarChar,20,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComMon",GXType.Int32,6,0) ,
        new ParDef("@ComConpCod",GXType.Int32,6,0)
        };
        Object[] prmT003622;
        prmT003622 = new Object[] {
        new ParDef("@PrvDsc",GXType.NChar,100,0) ,
        new ParDef("@ComFec",GXType.Date,8,0) ,
        new ParDef("@ComFVcto",GXType.Date,8,0) ,
        new ParDef("@ComFReg",GXType.Date,8,0) ,
        new ParDef("@ComRef",GXType.NChar,10,0) ,
        new ParDef("@ComOcSt",GXType.Int16,1,0) ,
        new ParDef("@ComDscto",GXType.Decimal,15,2) ,
        new ParDef("@ComRete1",GXType.Decimal,15,2) ,
        new ParDef("@ComRete2",GXType.Decimal,15,2) ,
        new ParDef("@ComFlete",GXType.Decimal,15,2) ,
        new ParDef("@ComISC",GXType.Decimal,15,2) ,
        new ParDef("@ComPorIva",GXType.Decimal,6,2) ,
        new ParDef("@ComObs",GXType.NVarChar,500,0) ,
        new ParDef("@ComItem",GXType.Int16,4,0) ,
        new ParDef("@ComRedondeo",GXType.Decimal,15,2) ,
        new ParDef("@ComValor",GXType.Decimal,15,2) ,
        new ParDef("@ComVouAno",GXType.Int16,4,0) ,
        new ParDef("@ComVouMes",GXType.Int16,2,0) ,
        new ParDef("@ComTASICod",GXType.Int32,6,0) ,
        new ParDef("@ComVouNum",GXType.NChar,10,0) ,
        new ParDef("@ComUsuC",GXType.NChar,10,0) ,
        new ParDef("@ComFecC",GXType.DateTime,8,5) ,
        new ParDef("@ComUsuM",GXType.NChar,10,0) ,
        new ParDef("@ComFecM",GXType.DateTime,8,5) ,
        new ParDef("@ComAut",GXType.Int16,1,0) ,
        new ParDef("@ComUsuAut",GXType.NChar,10,0) ,
        new ParDef("@ComFecAut",GXType.DateTime,8,5) ,
        new ParDef("@ComImpAfec",GXType.Int16,1,0) ,
        new ParDef("@ComImpTip",GXType.Int16,1,0) ,
        new ParDef("@ComImpCod",GXType.NChar,20,0) ,
        new ParDef("@ComImpTipCos",GXType.NChar,3,0) ,
        new ParDef("@ComRetAfecto",GXType.Int16,1,0) ,
        new ParDef("@ComRetCod",GXType.NChar,20,0) ,
        new ParDef("@ComRetFec",GXType.Date,8,0) ,
        new ParDef("@ComFecPago",GXType.Date,8,0) ,
        new ParDef("@ComTipReg",GXType.NChar,1,0) ,
        new ParDef("@ComIVADUA",GXType.Decimal,15,2) ,
        new ParDef("@ComCif",GXType.Int16,1,0) ,
        new ParDef("@ComRefTDoc",GXType.NChar,3,0) ,
        new ParDef("@ComRefDoc",GXType.NChar,20,0) ,
        new ParDef("@ComRefFec",GXType.Date,8,0) ,
        new ParDef("@ComFlagRet",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@ComBanCod",GXType.Int32,6,0) ,
        new ParDef("@ComBanCta",GXType.NChar,20,0) ,
        new ParDef("@ComBanReg",GXType.NChar,10,0) ,
        new ParDef("@ComBanForCod",GXType.Int32,6,0) ,
        new ParDef("@ComBanImp",GXType.Decimal,15,2) ,
        new ParDef("@ComBanDoc",GXType.NChar,20,0) ,
        new ParDef("@ComBanTipC",GXType.Decimal,15,5) ,
        new ParDef("@ComBanConc",GXType.Int32,6,0) ,
        new ParDef("@ComRefDom",GXType.NVarChar,20,0) ,
        new ParDef("@ComMon",GXType.Int32,6,0) ,
        new ParDef("@ComConpCod",GXType.Int32,6,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003623;
        prmT003623 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003628;
        prmT003628 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003629;
        prmT003629 = new Object[] {
        };
        Object[] prmT003630;
        prmT003630 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT003624;
        prmT003624 = new Object[] {
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003626;
        prmT003626 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003631;
        prmT003631 = new Object[] {
        new ParDef("@ComMon",GXType.Int32,6,0)
        };
        Object[] prmT003627;
        prmT003627 = new Object[] {
        new ParDef("@ComConpCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00362", "SELECT [ComCod], [ComFec], [ComFVcto], [ComFReg], [ComRef], [ComOcSt], [ComDscto], [ComRete1], [ComRete2], [ComFlete], [ComISC], [ComPorIva], [ComObs], [ComItem], [ComRedondeo], [ComValor], [ComVouAno], [ComVouMes], [ComTASICod], [ComVouNum], [ComUsuC], [ComFecC], [ComUsuM], [ComFecM], [ComAut], [ComUsuAut], [ComFecAut], [ComImpAfec], [ComImpTip], [ComImpCod], [ComImpTipCos], [ComRetAfecto], [ComRetCod], [ComRetFec], [ComFecPago], [ComTipReg], [ComIVADUA], [ComCif], [ComRefTDoc], [ComRefDoc], [ComRefFec], [ComFlagRet], [ComBanCod], [ComBanCta], [ComBanReg], [ComBanForCod], [ComBanImp], [ComBanDoc], [ComBanTipC], [ComBanConc], [ComRefDom], [TipCod], [PrvCod], [ComMon] AS ComMon, [ComConpCod] AS ComConpCod, [PrvDsc] FROM [CPCOMPRAS] WITH (UPDLOCK) WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00362,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00363", "SELECT [ComCod], [ComFec], [ComFVcto], [ComFReg], [ComRef], [ComOcSt], [ComDscto], [ComRete1], [ComRete2], [ComFlete], [ComISC], [ComPorIva], [ComObs], [ComItem], [ComRedondeo], [ComValor], [ComVouAno], [ComVouMes], [ComTASICod], [ComVouNum], [ComUsuC], [ComFecC], [ComUsuM], [ComFecM], [ComAut], [ComUsuAut], [ComFecAut], [ComImpAfec], [ComImpTip], [ComImpCod], [ComImpTipCos], [ComRetAfecto], [ComRetCod], [ComRetFec], [ComFecPago], [ComTipReg], [ComIVADUA], [ComCif], [ComRefTDoc], [ComRefDoc], [ComRefFec], [ComFlagRet], [ComBanCod], [ComBanCta], [ComBanReg], [ComBanForCod], [ComBanImp], [ComBanDoc], [ComBanTipC], [ComBanConc], [ComRefDom], [TipCod], [PrvCod], [ComMon] AS ComMon, [ComConpCod] AS ComConpCod, [PrvDsc] FROM [CPCOMPRAS] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00363,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00364", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00364,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00365", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00365,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00366", "SELECT [MonCod] AS ComMon FROM [CMONEDAS] WHERE [MonCod] = @ComMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT00366,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00367", "SELECT [ConpAbr] AS ComConpAbr, [ConpDias] AS ComConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @ComConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00367,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00369", "SELECT COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe, COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubImportacion], 0) AS ComSubImportacion FROM (SELECT SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN COALESCE( [ComDImp], 0) = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubImportacion FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00369,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003611", cmdBufferT003611,true, GxErrorMask.GX_NOMASK, false, this,prmT003611,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003612", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003612,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003613", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003613,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003615", "SELECT COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe, COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubImportacion], 0) AS ComSubImportacion FROM (SELECT SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN COALESCE( [ComDImp], 0) = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubImportacion FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003615,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003616", "SELECT [MonCod] AS ComMon FROM [CMONEDAS] WHERE [MonCod] = @ComMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT003616,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003617", "SELECT [ConpAbr] AS ComConpAbr, [ConpDias] AS ComConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @ComConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003617,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003618", "SELECT [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003618,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003619", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE ( [TipCod] > @TipCod or [TipCod] = @TipCod and [ComCod] > @ComCod or [ComCod] = @ComCod and [TipCod] = @TipCod and [PrvCod] > @PrvCod) ORDER BY [TipCod], [ComCod], [PrvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003619,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003620", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE ( [TipCod] < @TipCod or [TipCod] = @TipCod and [ComCod] < @ComCod or [ComCod] = @ComCod and [TipCod] = @TipCod and [PrvCod] < @PrvCod) ORDER BY [TipCod] DESC, [ComCod] DESC, [PrvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003620,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003621", "INSERT INTO [CPCOMPRAS]([PrvDsc], [ComCod], [ComFec], [ComFVcto], [ComFReg], [ComRef], [ComOcSt], [ComDscto], [ComRete1], [ComRete2], [ComFlete], [ComISC], [ComPorIva], [ComObs], [ComItem], [ComRedondeo], [ComValor], [ComVouAno], [ComVouMes], [ComTASICod], [ComVouNum], [ComUsuC], [ComFecC], [ComUsuM], [ComFecM], [ComAut], [ComUsuAut], [ComFecAut], [ComImpAfec], [ComImpTip], [ComImpCod], [ComImpTipCos], [ComRetAfecto], [ComRetCod], [ComRetFec], [ComFecPago], [ComTipReg], [ComIVADUA], [ComCif], [ComRefTDoc], [ComRefDoc], [ComRefFec], [ComFlagRet], [ComBanCod], [ComBanCta], [ComBanReg], [ComBanForCod], [ComBanImp], [ComBanDoc], [ComBanTipC], [ComBanConc], [ComRefDom], [TipCod], [PrvCod], [ComMon], [ComConpCod]) VALUES(@PrvDsc, @ComCod, @ComFec, @ComFVcto, @ComFReg, @ComRef, @ComOcSt, @ComDscto, @ComRete1, @ComRete2, @ComFlete, @ComISC, @ComPorIva, @ComObs, @ComItem, @ComRedondeo, @ComValor, @ComVouAno, @ComVouMes, @ComTASICod, @ComVouNum, @ComUsuC, @ComFecC, @ComUsuM, @ComFecM, @ComAut, @ComUsuAut, @ComFecAut, @ComImpAfec, @ComImpTip, @ComImpCod, @ComImpTipCos, @ComRetAfecto, @ComRetCod, @ComRetFec, @ComFecPago, @ComTipReg, @ComIVADUA, @ComCif, @ComRefTDoc, @ComRefDoc, @ComRefFec, @ComFlagRet, @ComBanCod, @ComBanCta, @ComBanReg, @ComBanForCod, @ComBanImp, @ComBanDoc, @ComBanTipC, @ComBanConc, @ComRefDom, @TipCod, @PrvCod, @ComMon, @ComConpCod)", GxErrorMask.GX_NOMASK,prmT003621)
           ,new CursorDef("T003622", "UPDATE [CPCOMPRAS] SET [PrvDsc]=@PrvDsc, [ComFec]=@ComFec, [ComFVcto]=@ComFVcto, [ComFReg]=@ComFReg, [ComRef]=@ComRef, [ComOcSt]=@ComOcSt, [ComDscto]=@ComDscto, [ComRete1]=@ComRete1, [ComRete2]=@ComRete2, [ComFlete]=@ComFlete, [ComISC]=@ComISC, [ComPorIva]=@ComPorIva, [ComObs]=@ComObs, [ComItem]=@ComItem, [ComRedondeo]=@ComRedondeo, [ComValor]=@ComValor, [ComVouAno]=@ComVouAno, [ComVouMes]=@ComVouMes, [ComTASICod]=@ComTASICod, [ComVouNum]=@ComVouNum, [ComUsuC]=@ComUsuC, [ComFecC]=@ComFecC, [ComUsuM]=@ComUsuM, [ComFecM]=@ComFecM, [ComAut]=@ComAut, [ComUsuAut]=@ComUsuAut, [ComFecAut]=@ComFecAut, [ComImpAfec]=@ComImpAfec, [ComImpTip]=@ComImpTip, [ComImpCod]=@ComImpCod, [ComImpTipCos]=@ComImpTipCos, [ComRetAfecto]=@ComRetAfecto, [ComRetCod]=@ComRetCod, [ComRetFec]=@ComRetFec, [ComFecPago]=@ComFecPago, [ComTipReg]=@ComTipReg, [ComIVADUA]=@ComIVADUA, [ComCif]=@ComCif, [ComRefTDoc]=@ComRefTDoc, [ComRefDoc]=@ComRefDoc, [ComRefFec]=@ComRefFec, [ComFlagRet]=@ComFlagRet, [ComBanCod]=@ComBanCod, [ComBanCta]=@ComBanCta, [ComBanReg]=@ComBanReg, [ComBanForCod]=@ComBanForCod, [ComBanImp]=@ComBanImp, [ComBanDoc]=@ComBanDoc, [ComBanTipC]=@ComBanTipC, [ComBanConc]=@ComBanConc, [ComRefDom]=@ComRefDom, [ComMon]=@ComMon, [ComConpCod]=@ComConpCod  WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod", GxErrorMask.GX_NOMASK,prmT003622)
           ,new CursorDef("T003623", "DELETE FROM [CPCOMPRAS]  WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod", GxErrorMask.GX_NOMASK,prmT003623)
           ,new CursorDef("T003624", "SELECT [PrvDsc] FROM [CPPROVEEDORES] WHERE [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003624,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003626", "SELECT COALESCE( T1.[ComSubAfe], 0) AS ComSubAfe, COALESCE( T1.[ComSubIna], 0) AS ComSubIna, COALESCE( T1.[ComSubImportacion], 0) AS ComSubImportacion FROM (SELECT SUM(CASE  WHEN [ComDTip] = 0 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubAfe, [TipCod], [ComCod], [PrvCod], SUM(CASE  WHEN [ComDTip] = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubIna, SUM(CASE  WHEN COALESCE( [ComDImp], 0) = 1 THEN ( ( [ComDCant] * CAST([ComDPre] AS decimal( 28, 10))) - ( ROUND(( ( ROUND([ComDCant] * CAST([ComDPre] AS decimal( 28, 10)), 2))) * CAST(CAST([ComDDct] AS decimal( 25, 10)) / 100 AS decimal( 30, 10)), 2))) ELSE 0 END) AS ComSubImportacion FROM [CPCOMPRASDET] GROUP BY [TipCod], [ComCod], [PrvCod] ) T1 WHERE T1.[TipCod] = @TipCod AND T1.[ComCod] = @ComCod AND T1.[PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003626,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003627", "SELECT [ConpAbr] AS ComConpAbr, [ConpDias] AS ComConpDias FROM [CCONDICIONPAGO] WHERE [Conpcod] = @ComConpCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003627,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003628", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003628,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003629", "SELECT [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] ORDER BY [TipCod], [ComCod], [PrvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003629,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003630", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003630,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003631", "SELECT [MonCod] AS ComMon FROM [CMONEDAS] WHERE [MonCod] = @ComMon ",true, GxErrorMask.GX_NOMASK, false, this,prmT003631,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((short[]) buf[16])[0] = rslt.getShort(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((string[]) buf[20])[0] = rslt.getString(21, 10);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 10);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((string[]) buf[25])[0] = rslt.getString(26, 10);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((short[]) buf[28])[0] = rslt.getShort(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 20);
              ((string[]) buf[30])[0] = rslt.getString(31, 3);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((string[]) buf[32])[0] = rslt.getString(33, 20);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(34);
              ((DateTime[]) buf[34])[0] = rslt.getGXDate(35);
              ((string[]) buf[35])[0] = rslt.getString(36, 1);
              ((decimal[]) buf[36])[0] = rslt.getDecimal(37);
              ((short[]) buf[37])[0] = rslt.getShort(38);
              ((string[]) buf[38])[0] = rslt.getString(39, 3);
              ((string[]) buf[39])[0] = rslt.getString(40, 20);
              ((DateTime[]) buf[40])[0] = rslt.getGXDate(41);
              ((short[]) buf[41])[0] = rslt.getShort(42);
              ((bool[]) buf[42])[0] = rslt.wasNull(42);
              ((int[]) buf[43])[0] = rslt.getInt(43);
              ((string[]) buf[44])[0] = rslt.getString(44, 20);
              ((string[]) buf[45])[0] = rslt.getString(45, 10);
              ((int[]) buf[46])[0] = rslt.getInt(46);
              ((decimal[]) buf[47])[0] = rslt.getDecimal(47);
              ((string[]) buf[48])[0] = rslt.getString(48, 20);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(49);
              ((int[]) buf[50])[0] = rslt.getInt(50);
              ((string[]) buf[51])[0] = rslt.getVarchar(51);
              ((string[]) buf[52])[0] = rslt.getString(52, 3);
              ((string[]) buf[53])[0] = rslt.getString(53, 20);
              ((int[]) buf[54])[0] = rslt.getInt(54);
              ((int[]) buf[55])[0] = rslt.getInt(55);
              ((string[]) buf[56])[0] = rslt.getString(56, 100);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((short[]) buf[16])[0] = rslt.getShort(17);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((int[]) buf[18])[0] = rslt.getInt(19);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((string[]) buf[20])[0] = rslt.getString(21, 10);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(22);
              ((string[]) buf[22])[0] = rslt.getString(23, 10);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((string[]) buf[25])[0] = rslt.getString(26, 10);
              ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(27);
              ((short[]) buf[27])[0] = rslt.getShort(28);
              ((short[]) buf[28])[0] = rslt.getShort(29);
              ((string[]) buf[29])[0] = rslt.getString(30, 20);
              ((string[]) buf[30])[0] = rslt.getString(31, 3);
              ((short[]) buf[31])[0] = rslt.getShort(32);
              ((string[]) buf[32])[0] = rslt.getString(33, 20);
              ((DateTime[]) buf[33])[0] = rslt.getGXDate(34);
              ((DateTime[]) buf[34])[0] = rslt.getGXDate(35);
              ((string[]) buf[35])[0] = rslt.getString(36, 1);
              ((decimal[]) buf[36])[0] = rslt.getDecimal(37);
              ((short[]) buf[37])[0] = rslt.getShort(38);
              ((string[]) buf[38])[0] = rslt.getString(39, 3);
              ((string[]) buf[39])[0] = rslt.getString(40, 20);
              ((DateTime[]) buf[40])[0] = rslt.getGXDate(41);
              ((short[]) buf[41])[0] = rslt.getShort(42);
              ((bool[]) buf[42])[0] = rslt.wasNull(42);
              ((int[]) buf[43])[0] = rslt.getInt(43);
              ((string[]) buf[44])[0] = rslt.getString(44, 20);
              ((string[]) buf[45])[0] = rslt.getString(45, 10);
              ((int[]) buf[46])[0] = rslt.getInt(46);
              ((decimal[]) buf[47])[0] = rslt.getDecimal(47);
              ((string[]) buf[48])[0] = rslt.getString(48, 20);
              ((decimal[]) buf[49])[0] = rslt.getDecimal(49);
              ((int[]) buf[50])[0] = rslt.getInt(50);
              ((string[]) buf[51])[0] = rslt.getVarchar(51);
              ((string[]) buf[52])[0] = rslt.getString(52, 3);
              ((string[]) buf[53])[0] = rslt.getString(53, 20);
              ((int[]) buf[54])[0] = rslt.getInt(54);
              ((int[]) buf[55])[0] = rslt.getInt(55);
              ((string[]) buf[56])[0] = rslt.getString(56, 100);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 6 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
              ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
              ((decimal[]) buf[9])[0] = rslt.getDecimal(10);
              ((decimal[]) buf[10])[0] = rslt.getDecimal(11);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(12);
              ((string[]) buf[12])[0] = rslt.getLongVarchar(13);
              ((short[]) buf[13])[0] = rslt.getShort(14);
              ((decimal[]) buf[14])[0] = rslt.getDecimal(15);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(16);
              ((string[]) buf[16])[0] = rslt.getString(17, 100);
              ((short[]) buf[17])[0] = rslt.getShort(18);
              ((short[]) buf[18])[0] = rslt.getShort(19);
              ((int[]) buf[19])[0] = rslt.getInt(20);
              ((string[]) buf[20])[0] = rslt.getString(21, 10);
              ((string[]) buf[21])[0] = rslt.getString(22, 10);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(23);
              ((string[]) buf[23])[0] = rslt.getString(24, 10);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(25);
              ((short[]) buf[25])[0] = rslt.getShort(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 10);
              ((DateTime[]) buf[27])[0] = rslt.getGXDateTime(28);
              ((short[]) buf[28])[0] = rslt.getShort(29);
              ((short[]) buf[29])[0] = rslt.getShort(30);
              ((string[]) buf[30])[0] = rslt.getString(31, 20);
              ((string[]) buf[31])[0] = rslt.getString(32, 3);
              ((short[]) buf[32])[0] = rslt.getShort(33);
              ((string[]) buf[33])[0] = rslt.getString(34, 20);
              ((DateTime[]) buf[34])[0] = rslt.getGXDate(35);
              ((DateTime[]) buf[35])[0] = rslt.getGXDate(36);
              ((string[]) buf[36])[0] = rslt.getString(37, 1);
              ((decimal[]) buf[37])[0] = rslt.getDecimal(38);
              ((short[]) buf[38])[0] = rslt.getShort(39);
              ((string[]) buf[39])[0] = rslt.getString(40, 3);
              ((string[]) buf[40])[0] = rslt.getString(41, 20);
              ((DateTime[]) buf[41])[0] = rslt.getGXDate(42);
              ((short[]) buf[42])[0] = rslt.getShort(43);
              ((bool[]) buf[43])[0] = rslt.wasNull(43);
              ((int[]) buf[44])[0] = rslt.getInt(44);
              ((string[]) buf[45])[0] = rslt.getString(45, 20);
              ((string[]) buf[46])[0] = rslt.getString(46, 10);
              ((int[]) buf[47])[0] = rslt.getInt(47);
              ((decimal[]) buf[48])[0] = rslt.getDecimal(48);
              ((string[]) buf[49])[0] = rslt.getString(49, 20);
              ((decimal[]) buf[50])[0] = rslt.getDecimal(50);
              ((int[]) buf[51])[0] = rslt.getInt(51);
              ((string[]) buf[52])[0] = rslt.getString(52, 5);
              ((short[]) buf[53])[0] = rslt.getShort(53);
              ((string[]) buf[54])[0] = rslt.getVarchar(54);
              ((string[]) buf[55])[0] = rslt.getString(55, 3);
              ((string[]) buf[56])[0] = rslt.getString(56, 20);
              ((int[]) buf[57])[0] = rslt.getInt(57);
              ((int[]) buf[58])[0] = rslt.getInt(58);
              ((decimal[]) buf[59])[0] = rslt.getDecimal(59);
              ((decimal[]) buf[60])[0] = rslt.getDecimal(60);
              ((decimal[]) buf[61])[0] = rslt.getDecimal(61);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 5);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 25 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
