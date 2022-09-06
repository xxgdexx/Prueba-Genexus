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
   public class cbparamprod : GXDataArea
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
            A84ParCod = (int)(NumberUtil.Val( GetPar( "ParCod"), "."));
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A83ParTip, A84ParCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A108ParDLinProd = (int)(NumberUtil.Val( GetPar( "ParDLinProd"), "."));
            n108ParDLinProd = false;
            AssignAttri("", false, "A108ParDLinProd", StringUtil.LTrimStr( (decimal)(A108ParDLinProd), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A108ParDLinProd) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A107ParDSubProd = (int)(NumberUtil.Val( GetPar( "ParDSubProd"), "."));
            n107ParDSubProd = false;
            AssignAttri("", false, "A107ParDSubProd", StringUtil.LTrimStr( (decimal)(A107ParDSubProd), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A107ParDSubProd) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A105ParDCueCod = GetPar( "ParDCueCod");
            AssignAttri("", false, "A105ParDCueCod", A105ParDCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A105ParDCueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A106ParDCueCod1 = GetPar( "ParDCueCod1");
            n106ParDCueCod1 = false;
            AssignAttri("", false, "A106ParDCueCod1", A106ParDCueCod1);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A106ParDCueCod1) ;
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
            Form.Meta.addItem("description", "Parametrización - Productos", 0) ;
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

      public cbparamprod( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbparamprod( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPARAMPROD.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Asiento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParTip_Internalname, StringUtil.RTrim( A83ParTip), StringUtil.RTrim( context.localUtil.Format( A83ParTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Secuencia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84ParCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtParCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A104ParDItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtParDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A104ParDItem), "ZZZ9") : context.localUtil.Format( (decimal)(A104ParDItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Linea", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDLinProd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A108ParDLinProd), 6, 0, ".", "")), StringUtil.LTrim( ((edtParDLinProd_Enabled!=0) ? context.localUtil.Format( (decimal)(A108ParDLinProd), "ZZZZZ9") : context.localUtil.Format( (decimal)(A108ParDLinProd), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDLinProd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDLinProd_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Linea", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParDLinDsc_Internalname, StringUtil.RTrim( A1531ParDLinDsc), StringUtil.RTrim( context.localUtil.Format( A1531ParDLinDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDLinDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDLinDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Sub Linea", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDSubProd_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A107ParDSubProd), 6, 0, ".", "")), StringUtil.LTrim( ((edtParDSubProd_Enabled!=0) ? context.localUtil.Format( (decimal)(A107ParDSubProd), "ZZZZZ9") : context.localUtil.Format( (decimal)(A107ParDSubProd), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDSubProd_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDSubProd_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "SubLinea", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtParDSubDsc_Internalname, StringUtil.RTrim( A1532ParDSubDsc), StringUtil.RTrim( context.localUtil.Format( A1532ParDSubDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDSubDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDSubDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cuenta", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDCueCod_Internalname, StringUtil.RTrim( A105ParDCueCod), StringUtil.RTrim( context.localUtil.Format( A105ParDCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "D/H", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTip_Internalname, StringUtil.RTrim( A1533ParDTip), StringUtil.RTrim( context.localUtil.Format( A1533ParDTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Cuenta 2", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDCueCod1_Internalname, StringUtil.RTrim( A106ParDCueCod1), StringUtil.RTrim( context.localUtil.Format( A106ParDCueCod1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDCueCod1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDCueCod1_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "D/H", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTip1_Internalname, StringUtil.RTrim( A1534ParDTip1), StringUtil.RTrim( context.localUtil.Format( A1534ParDTip1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTip1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTip1_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Cuenta 3", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDCueCod2_Internalname, StringUtil.RTrim( A1529ParDCueCod2), StringUtil.RTrim( context.localUtil.Format( A1529ParDCueCod2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDCueCod2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDCueCod2_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "D/H", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTip2_Internalname, StringUtil.RTrim( A1535ParDTip2), StringUtil.RTrim( context.localUtil.Format( A1535ParDTip2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTip2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTip2_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Cuenta 4", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDCueCod3_Internalname, StringUtil.RTrim( A1530ParDCueCod3), StringUtil.RTrim( context.localUtil.Format( A1530ParDCueCod3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDCueCod3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDCueCod3_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "D/H", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTip3_Internalname, StringUtil.RTrim( A1536ParDTip3), StringUtil.RTrim( context.localUtil.Format( A1536ParDTip3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTip3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTip3_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 95,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBPARAMPROD.htm");
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
            Z104ParDItem = (short)(context.localUtil.CToN( cgiGet( "Z104ParDItem"), ".", ","));
            Z1533ParDTip = cgiGet( "Z1533ParDTip");
            Z1534ParDTip1 = cgiGet( "Z1534ParDTip1");
            Z1529ParDCueCod2 = cgiGet( "Z1529ParDCueCod2");
            n1529ParDCueCod2 = (String.IsNullOrEmpty(StringUtil.RTrim( A1529ParDCueCod2)) ? true : false);
            Z1535ParDTip2 = cgiGet( "Z1535ParDTip2");
            Z1530ParDCueCod3 = cgiGet( "Z1530ParDCueCod3");
            n1530ParDCueCod3 = (String.IsNullOrEmpty(StringUtil.RTrim( A1530ParDCueCod3)) ? true : false);
            Z1536ParDTip3 = cgiGet( "Z1536ParDTip3");
            Z108ParDLinProd = (int)(context.localUtil.CToN( cgiGet( "Z108ParDLinProd"), ".", ","));
            Z107ParDSubProd = (int)(context.localUtil.CToN( cgiGet( "Z107ParDSubProd"), ".", ","));
            Z105ParDCueCod = cgiGet( "Z105ParDCueCod");
            Z106ParDCueCod1 = cgiGet( "Z106ParDCueCod1");
            n106ParDCueCod1 = (String.IsNullOrEmpty(StringUtil.RTrim( A106ParDCueCod1)) ? true : false);
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDITEM");
               AnyError = 1;
               GX_FocusControl = edtParDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A104ParDItem = 0;
               AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
            }
            else
            {
               A104ParDItem = (short)(context.localUtil.CToN( cgiGet( edtParDItem_Internalname), ".", ","));
               AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDLinProd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDLinProd_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDLINPROD");
               AnyError = 1;
               GX_FocusControl = edtParDLinProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A108ParDLinProd = 0;
               n108ParDLinProd = false;
               AssignAttri("", false, "A108ParDLinProd", StringUtil.LTrimStr( (decimal)(A108ParDLinProd), 6, 0));
            }
            else
            {
               A108ParDLinProd = (int)(context.localUtil.CToN( cgiGet( edtParDLinProd_Internalname), ".", ","));
               n108ParDLinProd = false;
               AssignAttri("", false, "A108ParDLinProd", StringUtil.LTrimStr( (decimal)(A108ParDLinProd), 6, 0));
            }
            A1531ParDLinDsc = cgiGet( edtParDLinDsc_Internalname);
            AssignAttri("", false, "A1531ParDLinDsc", A1531ParDLinDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDSubProd_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDSubProd_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDSUBPROD");
               AnyError = 1;
               GX_FocusControl = edtParDSubProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A107ParDSubProd = 0;
               n107ParDSubProd = false;
               AssignAttri("", false, "A107ParDSubProd", StringUtil.LTrimStr( (decimal)(A107ParDSubProd), 6, 0));
            }
            else
            {
               A107ParDSubProd = (int)(context.localUtil.CToN( cgiGet( edtParDSubProd_Internalname), ".", ","));
               n107ParDSubProd = false;
               AssignAttri("", false, "A107ParDSubProd", StringUtil.LTrimStr( (decimal)(A107ParDSubProd), 6, 0));
            }
            A1532ParDSubDsc = cgiGet( edtParDSubDsc_Internalname);
            AssignAttri("", false, "A1532ParDSubDsc", A1532ParDSubDsc);
            A105ParDCueCod = cgiGet( edtParDCueCod_Internalname);
            AssignAttri("", false, "A105ParDCueCod", A105ParDCueCod);
            A1533ParDTip = cgiGet( edtParDTip_Internalname);
            AssignAttri("", false, "A1533ParDTip", A1533ParDTip);
            A106ParDCueCod1 = cgiGet( edtParDCueCod1_Internalname);
            n106ParDCueCod1 = false;
            AssignAttri("", false, "A106ParDCueCod1", A106ParDCueCod1);
            n106ParDCueCod1 = (String.IsNullOrEmpty(StringUtil.RTrim( A106ParDCueCod1)) ? true : false);
            A1534ParDTip1 = cgiGet( edtParDTip1_Internalname);
            AssignAttri("", false, "A1534ParDTip1", A1534ParDTip1);
            A1529ParDCueCod2 = cgiGet( edtParDCueCod2_Internalname);
            n1529ParDCueCod2 = false;
            AssignAttri("", false, "A1529ParDCueCod2", A1529ParDCueCod2);
            n1529ParDCueCod2 = (String.IsNullOrEmpty(StringUtil.RTrim( A1529ParDCueCod2)) ? true : false);
            A1535ParDTip2 = cgiGet( edtParDTip2_Internalname);
            AssignAttri("", false, "A1535ParDTip2", A1535ParDTip2);
            A1530ParDCueCod3 = cgiGet( edtParDCueCod3_Internalname);
            n1530ParDCueCod3 = false;
            AssignAttri("", false, "A1530ParDCueCod3", A1530ParDCueCod3);
            n1530ParDCueCod3 = (String.IsNullOrEmpty(StringUtil.RTrim( A1530ParDCueCod3)) ? true : false);
            A1536ParDTip3 = cgiGet( edtParDTip3_Internalname);
            AssignAttri("", false, "A1536ParDTip3", A1536ParDTip3);
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
               A104ParDItem = (short)(NumberUtil.Val( GetPar( "ParDItem"), "."));
               AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
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
               InitAll1U63( ) ;
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
         DisableAttributes1U63( ) ;
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

      protected void CONFIRM_1U0( )
      {
         BeforeValidate1U63( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1U63( ) ;
            }
            else
            {
               CheckExtendedTable1U63( ) ;
               if ( AnyError == 0 )
               {
                  ZM1U63( 2) ;
                  ZM1U63( 3) ;
                  ZM1U63( 4) ;
                  ZM1U63( 5) ;
                  ZM1U63( 6) ;
               }
               CloseExtendedTableCursors1U63( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1U0( ) ;
         }
      }

      protected void ResetCaption1U0( )
      {
      }

      protected void ZM1U63( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1533ParDTip = T001U3_A1533ParDTip[0];
               Z1534ParDTip1 = T001U3_A1534ParDTip1[0];
               Z1529ParDCueCod2 = T001U3_A1529ParDCueCod2[0];
               Z1535ParDTip2 = T001U3_A1535ParDTip2[0];
               Z1530ParDCueCod3 = T001U3_A1530ParDCueCod3[0];
               Z1536ParDTip3 = T001U3_A1536ParDTip3[0];
               Z108ParDLinProd = T001U3_A108ParDLinProd[0];
               Z107ParDSubProd = T001U3_A107ParDSubProd[0];
               Z105ParDCueCod = T001U3_A105ParDCueCod[0];
               Z106ParDCueCod1 = T001U3_A106ParDCueCod1[0];
            }
            else
            {
               Z1533ParDTip = A1533ParDTip;
               Z1534ParDTip1 = A1534ParDTip1;
               Z1529ParDCueCod2 = A1529ParDCueCod2;
               Z1535ParDTip2 = A1535ParDTip2;
               Z1530ParDCueCod3 = A1530ParDCueCod3;
               Z1536ParDTip3 = A1536ParDTip3;
               Z108ParDLinProd = A108ParDLinProd;
               Z107ParDSubProd = A107ParDSubProd;
               Z105ParDCueCod = A105ParDCueCod;
               Z106ParDCueCod1 = A106ParDCueCod1;
            }
         }
         if ( GX_JID == -1 )
         {
            Z104ParDItem = A104ParDItem;
            Z1533ParDTip = A1533ParDTip;
            Z1534ParDTip1 = A1534ParDTip1;
            Z1529ParDCueCod2 = A1529ParDCueCod2;
            Z1535ParDTip2 = A1535ParDTip2;
            Z1530ParDCueCod3 = A1530ParDCueCod3;
            Z1536ParDTip3 = A1536ParDTip3;
            Z83ParTip = A83ParTip;
            Z84ParCod = A84ParCod;
            Z108ParDLinProd = A108ParDLinProd;
            Z107ParDSubProd = A107ParDSubProd;
            Z105ParDCueCod = A105ParDCueCod;
            Z106ParDCueCod1 = A106ParDCueCod1;
            Z1531ParDLinDsc = A1531ParDLinDsc;
            Z1532ParDSubDsc = A1532ParDSubDsc;
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

      protected void Load1U63( )
      {
         /* Using cursor T001U9 */
         pr_default.execute(7, new Object[] {A83ParTip, A84ParCod, A104ParDItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound63 = 1;
            A1531ParDLinDsc = T001U9_A1531ParDLinDsc[0];
            AssignAttri("", false, "A1531ParDLinDsc", A1531ParDLinDsc);
            A1532ParDSubDsc = T001U9_A1532ParDSubDsc[0];
            AssignAttri("", false, "A1532ParDSubDsc", A1532ParDSubDsc);
            A1533ParDTip = T001U9_A1533ParDTip[0];
            AssignAttri("", false, "A1533ParDTip", A1533ParDTip);
            A1534ParDTip1 = T001U9_A1534ParDTip1[0];
            AssignAttri("", false, "A1534ParDTip1", A1534ParDTip1);
            A1529ParDCueCod2 = T001U9_A1529ParDCueCod2[0];
            n1529ParDCueCod2 = T001U9_n1529ParDCueCod2[0];
            AssignAttri("", false, "A1529ParDCueCod2", A1529ParDCueCod2);
            A1535ParDTip2 = T001U9_A1535ParDTip2[0];
            AssignAttri("", false, "A1535ParDTip2", A1535ParDTip2);
            A1530ParDCueCod3 = T001U9_A1530ParDCueCod3[0];
            n1530ParDCueCod3 = T001U9_n1530ParDCueCod3[0];
            AssignAttri("", false, "A1530ParDCueCod3", A1530ParDCueCod3);
            A1536ParDTip3 = T001U9_A1536ParDTip3[0];
            AssignAttri("", false, "A1536ParDTip3", A1536ParDTip3);
            A108ParDLinProd = T001U9_A108ParDLinProd[0];
            n108ParDLinProd = T001U9_n108ParDLinProd[0];
            AssignAttri("", false, "A108ParDLinProd", StringUtil.LTrimStr( (decimal)(A108ParDLinProd), 6, 0));
            A107ParDSubProd = T001U9_A107ParDSubProd[0];
            n107ParDSubProd = T001U9_n107ParDSubProd[0];
            AssignAttri("", false, "A107ParDSubProd", StringUtil.LTrimStr( (decimal)(A107ParDSubProd), 6, 0));
            A105ParDCueCod = T001U9_A105ParDCueCod[0];
            AssignAttri("", false, "A105ParDCueCod", A105ParDCueCod);
            A106ParDCueCod1 = T001U9_A106ParDCueCod1[0];
            n106ParDCueCod1 = T001U9_n106ParDCueCod1[0];
            AssignAttri("", false, "A106ParDCueCod1", A106ParDCueCod1);
            ZM1U63( -1) ;
         }
         pr_default.close(7);
         OnLoadActions1U63( ) ;
      }

      protected void OnLoadActions1U63( )
      {
      }

      protected void CheckExtendedTable1U63( )
      {
         nIsDirty_63 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001U4 */
         pr_default.execute(2, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001U5 */
         pr_default.execute(3, new Object[] {n108ParDLinProd, A108ParDLinProd});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A108ParDLinProd) ) )
            {
               GX_msglist.addItem("No existe 'Linea de Productos'.", "ForeignKeyNotFound", 1, "PARDLINPROD");
               AnyError = 1;
               GX_FocusControl = edtParDLinProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1531ParDLinDsc = T001U5_A1531ParDLinDsc[0];
         AssignAttri("", false, "A1531ParDLinDsc", A1531ParDLinDsc);
         pr_default.close(3);
         /* Using cursor T001U6 */
         pr_default.execute(4, new Object[] {n107ParDSubProd, A107ParDSubProd});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A107ParDSubProd) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "PARDSUBPROD");
               AnyError = 1;
               GX_FocusControl = edtParDSubProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1532ParDSubDsc = T001U6_A1532ParDSubDsc[0];
         AssignAttri("", false, "A1532ParDSubDsc", A1532ParDSubDsc);
         pr_default.close(4);
         /* Using cursor T001U7 */
         pr_default.execute(5, new Object[] {A105ParDCueCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtParDCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T001U8 */
         pr_default.execute(6, new Object[] {n106ParDCueCod1, A106ParDCueCod1});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A106ParDCueCod1)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARDCUECOD1");
               AnyError = 1;
               GX_FocusControl = edtParDCueCod1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
      }

      protected void CloseExtendedTableCursors1U63( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(6);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A83ParTip ,
                               int A84ParCod )
      {
         /* Using cursor T001U10 */
         pr_default.execute(8, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
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

      protected void gxLoad_3( int A108ParDLinProd )
      {
         /* Using cursor T001U11 */
         pr_default.execute(9, new Object[] {n108ParDLinProd, A108ParDLinProd});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( (0==A108ParDLinProd) ) )
            {
               GX_msglist.addItem("No existe 'Linea de Productos'.", "ForeignKeyNotFound", 1, "PARDLINPROD");
               AnyError = 1;
               GX_FocusControl = edtParDLinProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1531ParDLinDsc = T001U11_A1531ParDLinDsc[0];
         AssignAttri("", false, "A1531ParDLinDsc", A1531ParDLinDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1531ParDLinDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_4( int A107ParDSubProd )
      {
         /* Using cursor T001U12 */
         pr_default.execute(10, new Object[] {n107ParDSubProd, A107ParDSubProd});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( (0==A107ParDSubProd) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "PARDSUBPROD");
               AnyError = 1;
               GX_FocusControl = edtParDSubProd_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1532ParDSubDsc = T001U12_A1532ParDSubDsc[0];
         AssignAttri("", false, "A1532ParDSubDsc", A1532ParDSubDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1532ParDSubDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_5( string A105ParDCueCod )
      {
         /* Using cursor T001U13 */
         pr_default.execute(11, new Object[] {A105ParDCueCod});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtParDCueCod_Internalname;
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

      protected void gxLoad_6( string A106ParDCueCod1 )
      {
         /* Using cursor T001U14 */
         pr_default.execute(12, new Object[] {n106ParDCueCod1, A106ParDCueCod1});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A106ParDCueCod1)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARDCUECOD1");
               AnyError = 1;
               GX_FocusControl = edtParDCueCod1_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void GetKey1U63( )
      {
         /* Using cursor T001U15 */
         pr_default.execute(13, new Object[] {A83ParTip, A84ParCod, A104ParDItem});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound63 = 1;
         }
         else
         {
            RcdFound63 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001U3 */
         pr_default.execute(1, new Object[] {A83ParTip, A84ParCod, A104ParDItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1U63( 1) ;
            RcdFound63 = 1;
            A104ParDItem = T001U3_A104ParDItem[0];
            AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
            A1533ParDTip = T001U3_A1533ParDTip[0];
            AssignAttri("", false, "A1533ParDTip", A1533ParDTip);
            A1534ParDTip1 = T001U3_A1534ParDTip1[0];
            AssignAttri("", false, "A1534ParDTip1", A1534ParDTip1);
            A1529ParDCueCod2 = T001U3_A1529ParDCueCod2[0];
            n1529ParDCueCod2 = T001U3_n1529ParDCueCod2[0];
            AssignAttri("", false, "A1529ParDCueCod2", A1529ParDCueCod2);
            A1535ParDTip2 = T001U3_A1535ParDTip2[0];
            AssignAttri("", false, "A1535ParDTip2", A1535ParDTip2);
            A1530ParDCueCod3 = T001U3_A1530ParDCueCod3[0];
            n1530ParDCueCod3 = T001U3_n1530ParDCueCod3[0];
            AssignAttri("", false, "A1530ParDCueCod3", A1530ParDCueCod3);
            A1536ParDTip3 = T001U3_A1536ParDTip3[0];
            AssignAttri("", false, "A1536ParDTip3", A1536ParDTip3);
            A83ParTip = T001U3_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001U3_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A108ParDLinProd = T001U3_A108ParDLinProd[0];
            n108ParDLinProd = T001U3_n108ParDLinProd[0];
            AssignAttri("", false, "A108ParDLinProd", StringUtil.LTrimStr( (decimal)(A108ParDLinProd), 6, 0));
            A107ParDSubProd = T001U3_A107ParDSubProd[0];
            n107ParDSubProd = T001U3_n107ParDSubProd[0];
            AssignAttri("", false, "A107ParDSubProd", StringUtil.LTrimStr( (decimal)(A107ParDSubProd), 6, 0));
            A105ParDCueCod = T001U3_A105ParDCueCod[0];
            AssignAttri("", false, "A105ParDCueCod", A105ParDCueCod);
            A106ParDCueCod1 = T001U3_A106ParDCueCod1[0];
            n106ParDCueCod1 = T001U3_n106ParDCueCod1[0];
            AssignAttri("", false, "A106ParDCueCod1", A106ParDCueCod1);
            Z83ParTip = A83ParTip;
            Z84ParCod = A84ParCod;
            Z104ParDItem = A104ParDItem;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1U63( ) ;
            if ( AnyError == 1 )
            {
               RcdFound63 = 0;
               InitializeNonKey1U63( ) ;
            }
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound63 = 0;
            InitializeNonKey1U63( ) ;
            sMode63 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode63;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1U63( ) ;
         if ( RcdFound63 == 0 )
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
         RcdFound63 = 0;
         /* Using cursor T001U16 */
         pr_default.execute(14, new Object[] {A83ParTip, A84ParCod, A104ParDItem});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T001U16_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001U16_A83ParTip[0], A83ParTip) == 0 ) && ( T001U16_A84ParCod[0] < A84ParCod ) || ( T001U16_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001U16_A83ParTip[0], A83ParTip) == 0 ) && ( T001U16_A104ParDItem[0] < A104ParDItem ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( StringUtil.StrCmp(T001U16_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001U16_A83ParTip[0], A83ParTip) == 0 ) && ( T001U16_A84ParCod[0] > A84ParCod ) || ( T001U16_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001U16_A83ParTip[0], A83ParTip) == 0 ) && ( T001U16_A104ParDItem[0] > A104ParDItem ) ) )
            {
               A83ParTip = T001U16_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001U16_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A104ParDItem = T001U16_A104ParDItem[0];
               AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
               RcdFound63 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound63 = 0;
         /* Using cursor T001U17 */
         pr_default.execute(15, new Object[] {A83ParTip, A84ParCod, A104ParDItem});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T001U17_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001U17_A83ParTip[0], A83ParTip) == 0 ) && ( T001U17_A84ParCod[0] > A84ParCod ) || ( T001U17_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001U17_A83ParTip[0], A83ParTip) == 0 ) && ( T001U17_A104ParDItem[0] > A104ParDItem ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( StringUtil.StrCmp(T001U17_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001U17_A83ParTip[0], A83ParTip) == 0 ) && ( T001U17_A84ParCod[0] < A84ParCod ) || ( T001U17_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001U17_A83ParTip[0], A83ParTip) == 0 ) && ( T001U17_A104ParDItem[0] < A104ParDItem ) ) )
            {
               A83ParTip = T001U17_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001U17_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A104ParDItem = T001U17_A104ParDItem[0];
               AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
               RcdFound63 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1U63( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1U63( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound63 == 1 )
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A104ParDItem != Z104ParDItem ) )
               {
                  A83ParTip = Z83ParTip;
                  AssignAttri("", false, "A83ParTip", A83ParTip);
                  A84ParCod = Z84ParCod;
                  AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
                  A104ParDItem = Z104ParDItem;
                  AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
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
                  Update1U63( ) ;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A104ParDItem != Z104ParDItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1U63( ) ;
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
                     Insert1U63( ) ;
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
         if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A104ParDItem != Z104ParDItem ) )
         {
            A83ParTip = Z83ParTip;
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = Z84ParCod;
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A104ParDItem = Z104ParDItem;
            AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
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
         GetKey1U63( ) ;
         if ( RcdFound63 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PARTIP");
               AnyError = 1;
               GX_FocusControl = edtParTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A104ParDItem != Z104ParDItem ) )
            {
               A83ParTip = Z83ParTip;
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = Z84ParCod;
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A104ParDItem = Z104ParDItem;
               AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
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
            if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A104ParDItem != Z104ParDItem ) )
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
         context.RollbackDataStores("cbparamprod",pr_default);
         GX_FocusControl = edtParDLinProd_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1U0( ) ;
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
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtParDLinProd_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1U63( ) ;
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParDLinProd_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1U63( ) ;
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
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParDLinProd_Internalname;
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
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParDLinProd_Internalname;
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
         ScanStart1U63( ) ;
         if ( RcdFound63 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound63 != 0 )
            {
               ScanNext1U63( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtParDLinProd_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1U63( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1U63( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001U2 */
            pr_default.execute(0, new Object[] {A83ParTip, A84ParCod, A104ParDItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMPROD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1533ParDTip, T001U2_A1533ParDTip[0]) != 0 ) || ( StringUtil.StrCmp(Z1534ParDTip1, T001U2_A1534ParDTip1[0]) != 0 ) || ( StringUtil.StrCmp(Z1529ParDCueCod2, T001U2_A1529ParDCueCod2[0]) != 0 ) || ( StringUtil.StrCmp(Z1535ParDTip2, T001U2_A1535ParDTip2[0]) != 0 ) || ( StringUtil.StrCmp(Z1530ParDCueCod3, T001U2_A1530ParDCueCod3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1536ParDTip3, T001U2_A1536ParDTip3[0]) != 0 ) || ( Z108ParDLinProd != T001U2_A108ParDLinProd[0] ) || ( Z107ParDSubProd != T001U2_A107ParDSubProd[0] ) || ( StringUtil.StrCmp(Z105ParDCueCod, T001U2_A105ParDCueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z106ParDCueCod1, T001U2_A106ParDCueCod1[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1533ParDTip, T001U2_A1533ParDTip[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDTip");
                  GXUtil.WriteLogRaw("Old: ",Z1533ParDTip);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A1533ParDTip[0]);
               }
               if ( StringUtil.StrCmp(Z1534ParDTip1, T001U2_A1534ParDTip1[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDTip1");
                  GXUtil.WriteLogRaw("Old: ",Z1534ParDTip1);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A1534ParDTip1[0]);
               }
               if ( StringUtil.StrCmp(Z1529ParDCueCod2, T001U2_A1529ParDCueCod2[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDCueCod2");
                  GXUtil.WriteLogRaw("Old: ",Z1529ParDCueCod2);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A1529ParDCueCod2[0]);
               }
               if ( StringUtil.StrCmp(Z1535ParDTip2, T001U2_A1535ParDTip2[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDTip2");
                  GXUtil.WriteLogRaw("Old: ",Z1535ParDTip2);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A1535ParDTip2[0]);
               }
               if ( StringUtil.StrCmp(Z1530ParDCueCod3, T001U2_A1530ParDCueCod3[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDCueCod3");
                  GXUtil.WriteLogRaw("Old: ",Z1530ParDCueCod3);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A1530ParDCueCod3[0]);
               }
               if ( StringUtil.StrCmp(Z1536ParDTip3, T001U2_A1536ParDTip3[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDTip3");
                  GXUtil.WriteLogRaw("Old: ",Z1536ParDTip3);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A1536ParDTip3[0]);
               }
               if ( Z108ParDLinProd != T001U2_A108ParDLinProd[0] )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDLinProd");
                  GXUtil.WriteLogRaw("Old: ",Z108ParDLinProd);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A108ParDLinProd[0]);
               }
               if ( Z107ParDSubProd != T001U2_A107ParDSubProd[0] )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDSubProd");
                  GXUtil.WriteLogRaw("Old: ",Z107ParDSubProd);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A107ParDSubProd[0]);
               }
               if ( StringUtil.StrCmp(Z105ParDCueCod, T001U2_A105ParDCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z105ParDCueCod);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A105ParDCueCod[0]);
               }
               if ( StringUtil.StrCmp(Z106ParDCueCod1, T001U2_A106ParDCueCod1[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamprod:[seudo value changed for attri]"+"ParDCueCod1");
                  GXUtil.WriteLogRaw("Old: ",Z106ParDCueCod1);
                  GXUtil.WriteLogRaw("Current: ",T001U2_A106ParDCueCod1[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPARAMPROD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1U63( )
      {
         BeforeValidate1U63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U63( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1U63( 0) ;
            CheckOptimisticConcurrency1U63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1U63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U18 */
                     pr_default.execute(16, new Object[] {A104ParDItem, A1533ParDTip, A1534ParDTip1, n1529ParDCueCod2, A1529ParDCueCod2, A1535ParDTip2, n1530ParDCueCod3, A1530ParDCueCod3, A1536ParDTip3, A83ParTip, A84ParCod, n108ParDLinProd, A108ParDLinProd, n107ParDSubProd, A107ParDSubProd, A105ParDCueCod, n106ParDCueCod1, A106ParDCueCod1});
                     pr_default.close(16);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMPROD");
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
                           ResetCaption1U0( ) ;
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
               Load1U63( ) ;
            }
            EndLevel1U63( ) ;
         }
         CloseExtendedTableCursors1U63( ) ;
      }

      protected void Update1U63( )
      {
         BeforeValidate1U63( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1U63( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U63( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1U63( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1U63( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001U19 */
                     pr_default.execute(17, new Object[] {A1533ParDTip, A1534ParDTip1, n1529ParDCueCod2, A1529ParDCueCod2, A1535ParDTip2, n1530ParDCueCod3, A1530ParDCueCod3, A1536ParDTip3, n108ParDLinProd, A108ParDLinProd, n107ParDSubProd, A107ParDSubProd, A105ParDCueCod, n106ParDCueCod1, A106ParDCueCod1, A83ParTip, A84ParCod, A104ParDItem});
                     pr_default.close(17);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMPROD");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMPROD"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1U63( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1U0( ) ;
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
            EndLevel1U63( ) ;
         }
         CloseExtendedTableCursors1U63( ) ;
      }

      protected void DeferredUpdate1U63( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1U63( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1U63( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1U63( ) ;
            AfterConfirm1U63( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1U63( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001U20 */
                  pr_default.execute(18, new Object[] {A83ParTip, A84ParCod, A104ParDItem});
                  pr_default.close(18);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPARAMPROD");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound63 == 0 )
                        {
                           InitAll1U63( ) ;
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
                        ResetCaption1U0( ) ;
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
         sMode63 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1U63( ) ;
         Gx_mode = sMode63;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1U63( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001U21 */
            pr_default.execute(19, new Object[] {n108ParDLinProd, A108ParDLinProd});
            A1531ParDLinDsc = T001U21_A1531ParDLinDsc[0];
            AssignAttri("", false, "A1531ParDLinDsc", A1531ParDLinDsc);
            pr_default.close(19);
            /* Using cursor T001U22 */
            pr_default.execute(20, new Object[] {n107ParDSubProd, A107ParDSubProd});
            A1532ParDSubDsc = T001U22_A1532ParDSubDsc[0];
            AssignAttri("", false, "A1532ParDSubDsc", A1532ParDSubDsc);
            pr_default.close(20);
         }
      }

      protected void EndLevel1U63( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1U63( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            context.CommitDataStores("cbparamprod",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            context.RollbackDataStores("cbparamprod",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1U63( )
      {
         /* Using cursor T001U23 */
         pr_default.execute(21);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound63 = 1;
            A83ParTip = T001U23_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001U23_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A104ParDItem = T001U23_A104ParDItem[0];
            AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1U63( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound63 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound63 = 1;
            A83ParTip = T001U23_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001U23_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A104ParDItem = T001U23_A104ParDItem[0];
            AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
         }
      }

      protected void ScanEnd1U63( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm1U63( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1U63( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1U63( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1U63( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1U63( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1U63( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1U63( )
      {
         edtParTip_Enabled = 0;
         AssignProp("", false, edtParTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParTip_Enabled), 5, 0), true);
         edtParCod_Enabled = 0;
         AssignProp("", false, edtParCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCod_Enabled), 5, 0), true);
         edtParDItem_Enabled = 0;
         AssignProp("", false, edtParDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDItem_Enabled), 5, 0), true);
         edtParDLinProd_Enabled = 0;
         AssignProp("", false, edtParDLinProd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDLinProd_Enabled), 5, 0), true);
         edtParDLinDsc_Enabled = 0;
         AssignProp("", false, edtParDLinDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDLinDsc_Enabled), 5, 0), true);
         edtParDSubProd_Enabled = 0;
         AssignProp("", false, edtParDSubProd_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDSubProd_Enabled), 5, 0), true);
         edtParDSubDsc_Enabled = 0;
         AssignProp("", false, edtParDSubDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDSubDsc_Enabled), 5, 0), true);
         edtParDCueCod_Enabled = 0;
         AssignProp("", false, edtParDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDCueCod_Enabled), 5, 0), true);
         edtParDTip_Enabled = 0;
         AssignProp("", false, edtParDTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTip_Enabled), 5, 0), true);
         edtParDCueCod1_Enabled = 0;
         AssignProp("", false, edtParDCueCod1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDCueCod1_Enabled), 5, 0), true);
         edtParDTip1_Enabled = 0;
         AssignProp("", false, edtParDTip1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTip1_Enabled), 5, 0), true);
         edtParDCueCod2_Enabled = 0;
         AssignProp("", false, edtParDCueCod2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDCueCod2_Enabled), 5, 0), true);
         edtParDTip2_Enabled = 0;
         AssignProp("", false, edtParDTip2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTip2_Enabled), 5, 0), true);
         edtParDCueCod3_Enabled = 0;
         AssignProp("", false, edtParDCueCod3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDCueCod3_Enabled), 5, 0), true);
         edtParDTip3_Enabled = 0;
         AssignProp("", false, edtParDTip3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTip3_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1U63( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1U0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810241034", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbparamprod.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z104ParDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z104ParDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1533ParDTip", StringUtil.RTrim( Z1533ParDTip));
         GxWebStd.gx_hidden_field( context, "Z1534ParDTip1", StringUtil.RTrim( Z1534ParDTip1));
         GxWebStd.gx_hidden_field( context, "Z1529ParDCueCod2", StringUtil.RTrim( Z1529ParDCueCod2));
         GxWebStd.gx_hidden_field( context, "Z1535ParDTip2", StringUtil.RTrim( Z1535ParDTip2));
         GxWebStd.gx_hidden_field( context, "Z1530ParDCueCod3", StringUtil.RTrim( Z1530ParDCueCod3));
         GxWebStd.gx_hidden_field( context, "Z1536ParDTip3", StringUtil.RTrim( Z1536ParDTip3));
         GxWebStd.gx_hidden_field( context, "Z108ParDLinProd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108ParDLinProd), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z107ParDSubProd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z107ParDSubProd), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z105ParDCueCod", StringUtil.RTrim( Z105ParDCueCod));
         GxWebStd.gx_hidden_field( context, "Z106ParDCueCod1", StringUtil.RTrim( Z106ParDCueCod1));
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
         return formatLink("cbparamprod.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPARAMPROD" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parametrización - Productos" ;
      }

      protected void InitializeNonKey1U63( )
      {
         A108ParDLinProd = 0;
         n108ParDLinProd = false;
         AssignAttri("", false, "A108ParDLinProd", StringUtil.LTrimStr( (decimal)(A108ParDLinProd), 6, 0));
         A1531ParDLinDsc = "";
         AssignAttri("", false, "A1531ParDLinDsc", A1531ParDLinDsc);
         A107ParDSubProd = 0;
         n107ParDSubProd = false;
         AssignAttri("", false, "A107ParDSubProd", StringUtil.LTrimStr( (decimal)(A107ParDSubProd), 6, 0));
         A1532ParDSubDsc = "";
         AssignAttri("", false, "A1532ParDSubDsc", A1532ParDSubDsc);
         A105ParDCueCod = "";
         AssignAttri("", false, "A105ParDCueCod", A105ParDCueCod);
         A1533ParDTip = "";
         AssignAttri("", false, "A1533ParDTip", A1533ParDTip);
         A106ParDCueCod1 = "";
         n106ParDCueCod1 = false;
         AssignAttri("", false, "A106ParDCueCod1", A106ParDCueCod1);
         n106ParDCueCod1 = (String.IsNullOrEmpty(StringUtil.RTrim( A106ParDCueCod1)) ? true : false);
         A1534ParDTip1 = "";
         AssignAttri("", false, "A1534ParDTip1", A1534ParDTip1);
         A1529ParDCueCod2 = "";
         n1529ParDCueCod2 = false;
         AssignAttri("", false, "A1529ParDCueCod2", A1529ParDCueCod2);
         n1529ParDCueCod2 = (String.IsNullOrEmpty(StringUtil.RTrim( A1529ParDCueCod2)) ? true : false);
         A1535ParDTip2 = "";
         AssignAttri("", false, "A1535ParDTip2", A1535ParDTip2);
         A1530ParDCueCod3 = "";
         n1530ParDCueCod3 = false;
         AssignAttri("", false, "A1530ParDCueCod3", A1530ParDCueCod3);
         n1530ParDCueCod3 = (String.IsNullOrEmpty(StringUtil.RTrim( A1530ParDCueCod3)) ? true : false);
         A1536ParDTip3 = "";
         AssignAttri("", false, "A1536ParDTip3", A1536ParDTip3);
         Z1533ParDTip = "";
         Z1534ParDTip1 = "";
         Z1529ParDCueCod2 = "";
         Z1535ParDTip2 = "";
         Z1530ParDCueCod3 = "";
         Z1536ParDTip3 = "";
         Z108ParDLinProd = 0;
         Z107ParDSubProd = 0;
         Z105ParDCueCod = "";
         Z106ParDCueCod1 = "";
      }

      protected void InitAll1U63( )
      {
         A83ParTip = "";
         AssignAttri("", false, "A83ParTip", A83ParTip);
         A84ParCod = 0;
         AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
         A104ParDItem = 0;
         AssignAttri("", false, "A104ParDItem", StringUtil.LTrimStr( (decimal)(A104ParDItem), 4, 0));
         InitializeNonKey1U63( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810241044", true, true);
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
         context.AddJavascriptSource("cbparamprod.js", "?202281810241044", false, true);
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
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtParDItem_Internalname = "PARDITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtParDLinProd_Internalname = "PARDLINPROD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtParDLinDsc_Internalname = "PARDLINDSC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtParDSubProd_Internalname = "PARDSUBPROD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtParDSubDsc_Internalname = "PARDSUBDSC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtParDCueCod_Internalname = "PARDCUECOD";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtParDTip_Internalname = "PARDTIP";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtParDCueCod1_Internalname = "PARDCUECOD1";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtParDTip1_Internalname = "PARDTIP1";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtParDCueCod2_Internalname = "PARDCUECOD2";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtParDTip2_Internalname = "PARDTIP2";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtParDCueCod3_Internalname = "PARDCUECOD3";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtParDTip3_Internalname = "PARDTIP3";
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
         Form.Caption = "Parametrización - Productos";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtParDTip3_Jsonclick = "";
         edtParDTip3_Enabled = 1;
         edtParDCueCod3_Jsonclick = "";
         edtParDCueCod3_Enabled = 1;
         edtParDTip2_Jsonclick = "";
         edtParDTip2_Enabled = 1;
         edtParDCueCod2_Jsonclick = "";
         edtParDCueCod2_Enabled = 1;
         edtParDTip1_Jsonclick = "";
         edtParDTip1_Enabled = 1;
         edtParDCueCod1_Jsonclick = "";
         edtParDCueCod1_Enabled = 1;
         edtParDTip_Jsonclick = "";
         edtParDTip_Enabled = 1;
         edtParDCueCod_Jsonclick = "";
         edtParDCueCod_Enabled = 1;
         edtParDSubDsc_Jsonclick = "";
         edtParDSubDsc_Enabled = 0;
         edtParDSubProd_Jsonclick = "";
         edtParDSubProd_Enabled = 1;
         edtParDLinDsc_Jsonclick = "";
         edtParDLinDsc_Enabled = 0;
         edtParDLinProd_Jsonclick = "";
         edtParDLinProd_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtParDItem_Jsonclick = "";
         edtParDItem_Enabled = 1;
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
         /* Using cursor T001U24 */
         pr_default.execute(22, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(22);
         GX_FocusControl = edtParDLinProd_Internalname;
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

      public void Valid_Parcod( )
      {
         /* Using cursor T001U24 */
         pr_default.execute(22, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
         }
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Parditem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A108ParDLinProd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A108ParDLinProd), 6, 0, ".", "")));
         AssignAttri("", false, "A107ParDSubProd", StringUtil.LTrim( StringUtil.NToC( (decimal)(A107ParDSubProd), 6, 0, ".", "")));
         AssignAttri("", false, "A105ParDCueCod", StringUtil.RTrim( A105ParDCueCod));
         AssignAttri("", false, "A1533ParDTip", StringUtil.RTrim( A1533ParDTip));
         AssignAttri("", false, "A106ParDCueCod1", StringUtil.RTrim( A106ParDCueCod1));
         AssignAttri("", false, "A1534ParDTip1", StringUtil.RTrim( A1534ParDTip1));
         AssignAttri("", false, "A1529ParDCueCod2", StringUtil.RTrim( A1529ParDCueCod2));
         AssignAttri("", false, "A1535ParDTip2", StringUtil.RTrim( A1535ParDTip2));
         AssignAttri("", false, "A1530ParDCueCod3", StringUtil.RTrim( A1530ParDCueCod3));
         AssignAttri("", false, "A1536ParDTip3", StringUtil.RTrim( A1536ParDTip3));
         AssignAttri("", false, "A1531ParDLinDsc", StringUtil.RTrim( A1531ParDLinDsc));
         AssignAttri("", false, "A1532ParDSubDsc", StringUtil.RTrim( A1532ParDSubDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z83ParTip", StringUtil.RTrim( Z83ParTip));
         GxWebStd.gx_hidden_field( context, "Z84ParCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84ParCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z104ParDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z104ParDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z108ParDLinProd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z108ParDLinProd), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z107ParDSubProd", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z107ParDSubProd), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z105ParDCueCod", StringUtil.RTrim( Z105ParDCueCod));
         GxWebStd.gx_hidden_field( context, "Z1533ParDTip", StringUtil.RTrim( Z1533ParDTip));
         GxWebStd.gx_hidden_field( context, "Z106ParDCueCod1", StringUtil.RTrim( Z106ParDCueCod1));
         GxWebStd.gx_hidden_field( context, "Z1534ParDTip1", StringUtil.RTrim( Z1534ParDTip1));
         GxWebStd.gx_hidden_field( context, "Z1529ParDCueCod2", StringUtil.RTrim( Z1529ParDCueCod2));
         GxWebStd.gx_hidden_field( context, "Z1535ParDTip2", StringUtil.RTrim( Z1535ParDTip2));
         GxWebStd.gx_hidden_field( context, "Z1530ParDCueCod3", StringUtil.RTrim( Z1530ParDCueCod3));
         GxWebStd.gx_hidden_field( context, "Z1536ParDTip3", StringUtil.RTrim( Z1536ParDTip3));
         GxWebStd.gx_hidden_field( context, "Z1531ParDLinDsc", StringUtil.RTrim( Z1531ParDLinDsc));
         GxWebStd.gx_hidden_field( context, "Z1532ParDSubDsc", StringUtil.RTrim( Z1532ParDSubDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Pardlinprod( )
      {
         n108ParDLinProd = false;
         /* Using cursor T001U21 */
         pr_default.execute(19, new Object[] {n108ParDLinProd, A108ParDLinProd});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( (0==A108ParDLinProd) ) )
            {
               GX_msglist.addItem("No existe 'Linea de Productos'.", "ForeignKeyNotFound", 1, "PARDLINPROD");
               AnyError = 1;
               GX_FocusControl = edtParDLinProd_Internalname;
            }
         }
         A1531ParDLinDsc = T001U21_A1531ParDLinDsc[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1531ParDLinDsc", StringUtil.RTrim( A1531ParDLinDsc));
      }

      public void Valid_Pardsubprod( )
      {
         n107ParDSubProd = false;
         /* Using cursor T001U22 */
         pr_default.execute(20, new Object[] {n107ParDSubProd, A107ParDSubProd});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A107ParDSubProd) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "PARDSUBPROD");
               AnyError = 1;
               GX_FocusControl = edtParDSubProd_Internalname;
            }
         }
         A1532ParDSubDsc = T001U22_A1532ParDSubDsc[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1532ParDSubDsc", StringUtil.RTrim( A1532ParDSubDsc));
      }

      public void Valid_Pardcuecod( )
      {
         /* Using cursor T001U25 */
         pr_default.execute(23, new Object[] {A105ParDCueCod});
         if ( (pr_default.getStatus(23) == 101) )
         {
            GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARDCUECOD");
            AnyError = 1;
            GX_FocusControl = edtParDCueCod_Internalname;
         }
         pr_default.close(23);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pardcuecod1( )
      {
         n106ParDCueCod1 = false;
         /* Using cursor T001U26 */
         pr_default.execute(24, new Object[] {n106ParDCueCod1, A106ParDCueCod1});
         if ( (pr_default.getStatus(24) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A106ParDCueCod1)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PARDCUECOD1");
               AnyError = 1;
               GX_FocusControl = edtParDCueCod1_Internalname;
            }
         }
         pr_default.close(24);
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
         setEventMetadata("VALID_PARTIP","{handler:'Valid_Partip',iparms:[]");
         setEventMetadata("VALID_PARTIP",",oparms:[]}");
         setEventMetadata("VALID_PARCOD","{handler:'Valid_Parcod',iparms:[{av:'A83ParTip',fld:'PARTIP',pic:''},{av:'A84ParCod',fld:'PARCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PARCOD",",oparms:[]}");
         setEventMetadata("VALID_PARDITEM","{handler:'Valid_Parditem',iparms:[{av:'A83ParTip',fld:'PARTIP',pic:''},{av:'A84ParCod',fld:'PARCOD',pic:'ZZZZZ9'},{av:'A104ParDItem',fld:'PARDITEM',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PARDITEM",",oparms:[{av:'A108ParDLinProd',fld:'PARDLINPROD',pic:'ZZZZZ9'},{av:'A107ParDSubProd',fld:'PARDSUBPROD',pic:'ZZZZZ9'},{av:'A105ParDCueCod',fld:'PARDCUECOD',pic:''},{av:'A1533ParDTip',fld:'PARDTIP',pic:''},{av:'A106ParDCueCod1',fld:'PARDCUECOD1',pic:''},{av:'A1534ParDTip1',fld:'PARDTIP1',pic:''},{av:'A1529ParDCueCod2',fld:'PARDCUECOD2',pic:''},{av:'A1535ParDTip2',fld:'PARDTIP2',pic:''},{av:'A1530ParDCueCod3',fld:'PARDCUECOD3',pic:''},{av:'A1536ParDTip3',fld:'PARDTIP3',pic:''},{av:'A1531ParDLinDsc',fld:'PARDLINDSC',pic:''},{av:'A1532ParDSubDsc',fld:'PARDSUBDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83ParTip'},{av:'Z84ParCod'},{av:'Z104ParDItem'},{av:'Z108ParDLinProd'},{av:'Z107ParDSubProd'},{av:'Z105ParDCueCod'},{av:'Z1533ParDTip'},{av:'Z106ParDCueCod1'},{av:'Z1534ParDTip1'},{av:'Z1529ParDCueCod2'},{av:'Z1535ParDTip2'},{av:'Z1530ParDCueCod3'},{av:'Z1536ParDTip3'},{av:'Z1531ParDLinDsc'},{av:'Z1532ParDSubDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PARDLINPROD","{handler:'Valid_Pardlinprod',iparms:[{av:'A108ParDLinProd',fld:'PARDLINPROD',pic:'ZZZZZ9'},{av:'A1531ParDLinDsc',fld:'PARDLINDSC',pic:''}]");
         setEventMetadata("VALID_PARDLINPROD",",oparms:[{av:'A1531ParDLinDsc',fld:'PARDLINDSC',pic:''}]}");
         setEventMetadata("VALID_PARDSUBPROD","{handler:'Valid_Pardsubprod',iparms:[{av:'A107ParDSubProd',fld:'PARDSUBPROD',pic:'ZZZZZ9'},{av:'A1532ParDSubDsc',fld:'PARDSUBDSC',pic:''}]");
         setEventMetadata("VALID_PARDSUBPROD",",oparms:[{av:'A1532ParDSubDsc',fld:'PARDSUBDSC',pic:''}]}");
         setEventMetadata("VALID_PARDCUECOD","{handler:'Valid_Pardcuecod',iparms:[{av:'A105ParDCueCod',fld:'PARDCUECOD',pic:''}]");
         setEventMetadata("VALID_PARDCUECOD",",oparms:[]}");
         setEventMetadata("VALID_PARDCUECOD1","{handler:'Valid_Pardcuecod1',iparms:[{av:'A106ParDCueCod1',fld:'PARDCUECOD1',pic:''}]");
         setEventMetadata("VALID_PARDCUECOD1",",oparms:[]}");
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
         pr_default.close(22);
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(23);
         pr_default.close(24);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z83ParTip = "";
         Z1533ParDTip = "";
         Z1534ParDTip1 = "";
         Z1529ParDCueCod2 = "";
         Z1535ParDTip2 = "";
         Z1530ParDCueCod3 = "";
         Z1536ParDTip3 = "";
         Z105ParDCueCod = "";
         Z106ParDCueCod1 = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A83ParTip = "";
         A105ParDCueCod = "";
         A106ParDCueCod1 = "";
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
         lblTextblock5_Jsonclick = "";
         A1531ParDLinDsc = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A1532ParDSubDsc = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         A1533ParDTip = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         A1534ParDTip1 = "";
         lblTextblock12_Jsonclick = "";
         A1529ParDCueCod2 = "";
         lblTextblock13_Jsonclick = "";
         A1535ParDTip2 = "";
         lblTextblock14_Jsonclick = "";
         A1530ParDCueCod3 = "";
         lblTextblock15_Jsonclick = "";
         A1536ParDTip3 = "";
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
         Z1531ParDLinDsc = "";
         Z1532ParDSubDsc = "";
         T001U9_A104ParDItem = new short[1] ;
         T001U9_A1531ParDLinDsc = new string[] {""} ;
         T001U9_A1532ParDSubDsc = new string[] {""} ;
         T001U9_A1533ParDTip = new string[] {""} ;
         T001U9_A1534ParDTip1 = new string[] {""} ;
         T001U9_A1529ParDCueCod2 = new string[] {""} ;
         T001U9_n1529ParDCueCod2 = new bool[] {false} ;
         T001U9_A1535ParDTip2 = new string[] {""} ;
         T001U9_A1530ParDCueCod3 = new string[] {""} ;
         T001U9_n1530ParDCueCod3 = new bool[] {false} ;
         T001U9_A1536ParDTip3 = new string[] {""} ;
         T001U9_A83ParTip = new string[] {""} ;
         T001U9_A84ParCod = new int[1] ;
         T001U9_A108ParDLinProd = new int[1] ;
         T001U9_n108ParDLinProd = new bool[] {false} ;
         T001U9_A107ParDSubProd = new int[1] ;
         T001U9_n107ParDSubProd = new bool[] {false} ;
         T001U9_A105ParDCueCod = new string[] {""} ;
         T001U9_A106ParDCueCod1 = new string[] {""} ;
         T001U9_n106ParDCueCod1 = new bool[] {false} ;
         T001U4_A83ParTip = new string[] {""} ;
         T001U5_A1531ParDLinDsc = new string[] {""} ;
         T001U6_A1532ParDSubDsc = new string[] {""} ;
         T001U7_A105ParDCueCod = new string[] {""} ;
         T001U8_A106ParDCueCod1 = new string[] {""} ;
         T001U8_n106ParDCueCod1 = new bool[] {false} ;
         T001U10_A83ParTip = new string[] {""} ;
         T001U11_A1531ParDLinDsc = new string[] {""} ;
         T001U12_A1532ParDSubDsc = new string[] {""} ;
         T001U13_A105ParDCueCod = new string[] {""} ;
         T001U14_A106ParDCueCod1 = new string[] {""} ;
         T001U14_n106ParDCueCod1 = new bool[] {false} ;
         T001U15_A83ParTip = new string[] {""} ;
         T001U15_A84ParCod = new int[1] ;
         T001U15_A104ParDItem = new short[1] ;
         T001U3_A104ParDItem = new short[1] ;
         T001U3_A1533ParDTip = new string[] {""} ;
         T001U3_A1534ParDTip1 = new string[] {""} ;
         T001U3_A1529ParDCueCod2 = new string[] {""} ;
         T001U3_n1529ParDCueCod2 = new bool[] {false} ;
         T001U3_A1535ParDTip2 = new string[] {""} ;
         T001U3_A1530ParDCueCod3 = new string[] {""} ;
         T001U3_n1530ParDCueCod3 = new bool[] {false} ;
         T001U3_A1536ParDTip3 = new string[] {""} ;
         T001U3_A83ParTip = new string[] {""} ;
         T001U3_A84ParCod = new int[1] ;
         T001U3_A108ParDLinProd = new int[1] ;
         T001U3_n108ParDLinProd = new bool[] {false} ;
         T001U3_A107ParDSubProd = new int[1] ;
         T001U3_n107ParDSubProd = new bool[] {false} ;
         T001U3_A105ParDCueCod = new string[] {""} ;
         T001U3_A106ParDCueCod1 = new string[] {""} ;
         T001U3_n106ParDCueCod1 = new bool[] {false} ;
         sMode63 = "";
         T001U16_A83ParTip = new string[] {""} ;
         T001U16_A84ParCod = new int[1] ;
         T001U16_A104ParDItem = new short[1] ;
         T001U17_A83ParTip = new string[] {""} ;
         T001U17_A84ParCod = new int[1] ;
         T001U17_A104ParDItem = new short[1] ;
         T001U2_A104ParDItem = new short[1] ;
         T001U2_A1533ParDTip = new string[] {""} ;
         T001U2_A1534ParDTip1 = new string[] {""} ;
         T001U2_A1529ParDCueCod2 = new string[] {""} ;
         T001U2_n1529ParDCueCod2 = new bool[] {false} ;
         T001U2_A1535ParDTip2 = new string[] {""} ;
         T001U2_A1530ParDCueCod3 = new string[] {""} ;
         T001U2_n1530ParDCueCod3 = new bool[] {false} ;
         T001U2_A1536ParDTip3 = new string[] {""} ;
         T001U2_A83ParTip = new string[] {""} ;
         T001U2_A84ParCod = new int[1] ;
         T001U2_A108ParDLinProd = new int[1] ;
         T001U2_n108ParDLinProd = new bool[] {false} ;
         T001U2_A107ParDSubProd = new int[1] ;
         T001U2_n107ParDSubProd = new bool[] {false} ;
         T001U2_A105ParDCueCod = new string[] {""} ;
         T001U2_A106ParDCueCod1 = new string[] {""} ;
         T001U2_n106ParDCueCod1 = new bool[] {false} ;
         T001U21_A1531ParDLinDsc = new string[] {""} ;
         T001U22_A1532ParDSubDsc = new string[] {""} ;
         T001U23_A83ParTip = new string[] {""} ;
         T001U23_A84ParCod = new int[1] ;
         T001U23_A104ParDItem = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001U24_A83ParTip = new string[] {""} ;
         ZZ83ParTip = "";
         ZZ105ParDCueCod = "";
         ZZ1533ParDTip = "";
         ZZ106ParDCueCod1 = "";
         ZZ1534ParDTip1 = "";
         ZZ1529ParDCueCod2 = "";
         ZZ1535ParDTip2 = "";
         ZZ1530ParDCueCod3 = "";
         ZZ1536ParDTip3 = "";
         ZZ1531ParDLinDsc = "";
         ZZ1532ParDSubDsc = "";
         T001U25_A105ParDCueCod = new string[] {""} ;
         T001U26_A106ParDCueCod1 = new string[] {""} ;
         T001U26_n106ParDCueCod1 = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbparamprod__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbparamprod__default(),
            new Object[][] {
                new Object[] {
               T001U2_A104ParDItem, T001U2_A1533ParDTip, T001U2_A1534ParDTip1, T001U2_A1529ParDCueCod2, T001U2_n1529ParDCueCod2, T001U2_A1535ParDTip2, T001U2_A1530ParDCueCod3, T001U2_n1530ParDCueCod3, T001U2_A1536ParDTip3, T001U2_A83ParTip,
               T001U2_A84ParCod, T001U2_A108ParDLinProd, T001U2_n108ParDLinProd, T001U2_A107ParDSubProd, T001U2_n107ParDSubProd, T001U2_A105ParDCueCod, T001U2_A106ParDCueCod1, T001U2_n106ParDCueCod1
               }
               , new Object[] {
               T001U3_A104ParDItem, T001U3_A1533ParDTip, T001U3_A1534ParDTip1, T001U3_A1529ParDCueCod2, T001U3_n1529ParDCueCod2, T001U3_A1535ParDTip2, T001U3_A1530ParDCueCod3, T001U3_n1530ParDCueCod3, T001U3_A1536ParDTip3, T001U3_A83ParTip,
               T001U3_A84ParCod, T001U3_A108ParDLinProd, T001U3_n108ParDLinProd, T001U3_A107ParDSubProd, T001U3_n107ParDSubProd, T001U3_A105ParDCueCod, T001U3_A106ParDCueCod1, T001U3_n106ParDCueCod1
               }
               , new Object[] {
               T001U4_A83ParTip
               }
               , new Object[] {
               T001U5_A1531ParDLinDsc
               }
               , new Object[] {
               T001U6_A1532ParDSubDsc
               }
               , new Object[] {
               T001U7_A105ParDCueCod
               }
               , new Object[] {
               T001U8_A106ParDCueCod1
               }
               , new Object[] {
               T001U9_A104ParDItem, T001U9_A1531ParDLinDsc, T001U9_A1532ParDSubDsc, T001U9_A1533ParDTip, T001U9_A1534ParDTip1, T001U9_A1529ParDCueCod2, T001U9_n1529ParDCueCod2, T001U9_A1535ParDTip2, T001U9_A1530ParDCueCod3, T001U9_n1530ParDCueCod3,
               T001U9_A1536ParDTip3, T001U9_A83ParTip, T001U9_A84ParCod, T001U9_A108ParDLinProd, T001U9_n108ParDLinProd, T001U9_A107ParDSubProd, T001U9_n107ParDSubProd, T001U9_A105ParDCueCod, T001U9_A106ParDCueCod1, T001U9_n106ParDCueCod1
               }
               , new Object[] {
               T001U10_A83ParTip
               }
               , new Object[] {
               T001U11_A1531ParDLinDsc
               }
               , new Object[] {
               T001U12_A1532ParDSubDsc
               }
               , new Object[] {
               T001U13_A105ParDCueCod
               }
               , new Object[] {
               T001U14_A106ParDCueCod1
               }
               , new Object[] {
               T001U15_A83ParTip, T001U15_A84ParCod, T001U15_A104ParDItem
               }
               , new Object[] {
               T001U16_A83ParTip, T001U16_A84ParCod, T001U16_A104ParDItem
               }
               , new Object[] {
               T001U17_A83ParTip, T001U17_A84ParCod, T001U17_A104ParDItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001U21_A1531ParDLinDsc
               }
               , new Object[] {
               T001U22_A1532ParDSubDsc
               }
               , new Object[] {
               T001U23_A83ParTip, T001U23_A84ParCod, T001U23_A104ParDItem
               }
               , new Object[] {
               T001U24_A83ParTip
               }
               , new Object[] {
               T001U25_A105ParDCueCod
               }
               , new Object[] {
               T001U26_A106ParDCueCod1
               }
            }
         );
      }

      private short Z104ParDItem ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A104ParDItem ;
      private short GX_JID ;
      private short RcdFound63 ;
      private short nIsDirty_63 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ104ParDItem ;
      private int Z84ParCod ;
      private int Z108ParDLinProd ;
      private int Z107ParDSubProd ;
      private int A84ParCod ;
      private int A108ParDLinProd ;
      private int A107ParDSubProd ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtParTip_Enabled ;
      private int edtParCod_Enabled ;
      private int edtParDItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtParDLinProd_Enabled ;
      private int edtParDLinDsc_Enabled ;
      private int edtParDSubProd_Enabled ;
      private int edtParDSubDsc_Enabled ;
      private int edtParDCueCod_Enabled ;
      private int edtParDTip_Enabled ;
      private int edtParDCueCod1_Enabled ;
      private int edtParDTip1_Enabled ;
      private int edtParDCueCod2_Enabled ;
      private int edtParDTip2_Enabled ;
      private int edtParDCueCod3_Enabled ;
      private int edtParDTip3_Enabled ;
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
      private int ZZ108ParDLinProd ;
      private int ZZ107ParDSubProd ;
      private string sPrefix ;
      private string Z83ParTip ;
      private string Z1533ParDTip ;
      private string Z1534ParDTip1 ;
      private string Z1529ParDCueCod2 ;
      private string Z1535ParDTip2 ;
      private string Z1530ParDCueCod3 ;
      private string Z1536ParDTip3 ;
      private string Z105ParDCueCod ;
      private string Z106ParDCueCod1 ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A83ParTip ;
      private string A105ParDCueCod ;
      private string A106ParDCueCod1 ;
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
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtParDItem_Internalname ;
      private string edtParDItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtParDLinProd_Internalname ;
      private string edtParDLinProd_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtParDLinDsc_Internalname ;
      private string A1531ParDLinDsc ;
      private string edtParDLinDsc_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtParDSubProd_Internalname ;
      private string edtParDSubProd_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtParDSubDsc_Internalname ;
      private string A1532ParDSubDsc ;
      private string edtParDSubDsc_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtParDCueCod_Internalname ;
      private string edtParDCueCod_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtParDTip_Internalname ;
      private string A1533ParDTip ;
      private string edtParDTip_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtParDCueCod1_Internalname ;
      private string edtParDCueCod1_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtParDTip1_Internalname ;
      private string A1534ParDTip1 ;
      private string edtParDTip1_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtParDCueCod2_Internalname ;
      private string A1529ParDCueCod2 ;
      private string edtParDCueCod2_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtParDTip2_Internalname ;
      private string A1535ParDTip2 ;
      private string edtParDTip2_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtParDCueCod3_Internalname ;
      private string A1530ParDCueCod3 ;
      private string edtParDCueCod3_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtParDTip3_Internalname ;
      private string A1536ParDTip3 ;
      private string edtParDTip3_Jsonclick ;
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
      private string Z1531ParDLinDsc ;
      private string Z1532ParDSubDsc ;
      private string sMode63 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ83ParTip ;
      private string ZZ105ParDCueCod ;
      private string ZZ1533ParDTip ;
      private string ZZ106ParDCueCod1 ;
      private string ZZ1534ParDTip1 ;
      private string ZZ1529ParDCueCod2 ;
      private string ZZ1535ParDTip2 ;
      private string ZZ1530ParDCueCod3 ;
      private string ZZ1536ParDTip3 ;
      private string ZZ1531ParDLinDsc ;
      private string ZZ1532ParDSubDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n108ParDLinProd ;
      private bool n107ParDSubProd ;
      private bool n106ParDCueCod1 ;
      private bool wbErr ;
      private bool n1529ParDCueCod2 ;
      private bool n1530ParDCueCod3 ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T001U9_A104ParDItem ;
      private string[] T001U9_A1531ParDLinDsc ;
      private string[] T001U9_A1532ParDSubDsc ;
      private string[] T001U9_A1533ParDTip ;
      private string[] T001U9_A1534ParDTip1 ;
      private string[] T001U9_A1529ParDCueCod2 ;
      private bool[] T001U9_n1529ParDCueCod2 ;
      private string[] T001U9_A1535ParDTip2 ;
      private string[] T001U9_A1530ParDCueCod3 ;
      private bool[] T001U9_n1530ParDCueCod3 ;
      private string[] T001U9_A1536ParDTip3 ;
      private string[] T001U9_A83ParTip ;
      private int[] T001U9_A84ParCod ;
      private int[] T001U9_A108ParDLinProd ;
      private bool[] T001U9_n108ParDLinProd ;
      private int[] T001U9_A107ParDSubProd ;
      private bool[] T001U9_n107ParDSubProd ;
      private string[] T001U9_A105ParDCueCod ;
      private string[] T001U9_A106ParDCueCod1 ;
      private bool[] T001U9_n106ParDCueCod1 ;
      private string[] T001U4_A83ParTip ;
      private string[] T001U5_A1531ParDLinDsc ;
      private string[] T001U6_A1532ParDSubDsc ;
      private string[] T001U7_A105ParDCueCod ;
      private string[] T001U8_A106ParDCueCod1 ;
      private bool[] T001U8_n106ParDCueCod1 ;
      private string[] T001U10_A83ParTip ;
      private string[] T001U11_A1531ParDLinDsc ;
      private string[] T001U12_A1532ParDSubDsc ;
      private string[] T001U13_A105ParDCueCod ;
      private string[] T001U14_A106ParDCueCod1 ;
      private bool[] T001U14_n106ParDCueCod1 ;
      private string[] T001U15_A83ParTip ;
      private int[] T001U15_A84ParCod ;
      private short[] T001U15_A104ParDItem ;
      private short[] T001U3_A104ParDItem ;
      private string[] T001U3_A1533ParDTip ;
      private string[] T001U3_A1534ParDTip1 ;
      private string[] T001U3_A1529ParDCueCod2 ;
      private bool[] T001U3_n1529ParDCueCod2 ;
      private string[] T001U3_A1535ParDTip2 ;
      private string[] T001U3_A1530ParDCueCod3 ;
      private bool[] T001U3_n1530ParDCueCod3 ;
      private string[] T001U3_A1536ParDTip3 ;
      private string[] T001U3_A83ParTip ;
      private int[] T001U3_A84ParCod ;
      private int[] T001U3_A108ParDLinProd ;
      private bool[] T001U3_n108ParDLinProd ;
      private int[] T001U3_A107ParDSubProd ;
      private bool[] T001U3_n107ParDSubProd ;
      private string[] T001U3_A105ParDCueCod ;
      private string[] T001U3_A106ParDCueCod1 ;
      private bool[] T001U3_n106ParDCueCod1 ;
      private string[] T001U16_A83ParTip ;
      private int[] T001U16_A84ParCod ;
      private short[] T001U16_A104ParDItem ;
      private string[] T001U17_A83ParTip ;
      private int[] T001U17_A84ParCod ;
      private short[] T001U17_A104ParDItem ;
      private short[] T001U2_A104ParDItem ;
      private string[] T001U2_A1533ParDTip ;
      private string[] T001U2_A1534ParDTip1 ;
      private string[] T001U2_A1529ParDCueCod2 ;
      private bool[] T001U2_n1529ParDCueCod2 ;
      private string[] T001U2_A1535ParDTip2 ;
      private string[] T001U2_A1530ParDCueCod3 ;
      private bool[] T001U2_n1530ParDCueCod3 ;
      private string[] T001U2_A1536ParDTip3 ;
      private string[] T001U2_A83ParTip ;
      private int[] T001U2_A84ParCod ;
      private int[] T001U2_A108ParDLinProd ;
      private bool[] T001U2_n108ParDLinProd ;
      private int[] T001U2_A107ParDSubProd ;
      private bool[] T001U2_n107ParDSubProd ;
      private string[] T001U2_A105ParDCueCod ;
      private string[] T001U2_A106ParDCueCod1 ;
      private bool[] T001U2_n106ParDCueCod1 ;
      private string[] T001U21_A1531ParDLinDsc ;
      private string[] T001U22_A1532ParDSubDsc ;
      private string[] T001U23_A83ParTip ;
      private int[] T001U23_A84ParCod ;
      private short[] T001U23_A104ParDItem ;
      private string[] T001U24_A83ParTip ;
      private string[] T001U25_A105ParDCueCod ;
      private string[] T001U26_A106ParDCueCod1 ;
      private bool[] T001U26_n106ParDCueCod1 ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbparamprod__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbparamprod__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001U9;
        prmT001U9 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U4;
        prmT001U4 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001U5;
        prmT001U5 = new Object[] {
        new ParDef("@ParDLinProd",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001U6;
        prmT001U6 = new Object[] {
        new ParDef("@ParDSubProd",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001U7;
        prmT001U7 = new Object[] {
        new ParDef("@ParDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT001U8;
        prmT001U8 = new Object[] {
        new ParDef("@ParDCueCod1",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001U10;
        prmT001U10 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001U11;
        prmT001U11 = new Object[] {
        new ParDef("@ParDLinProd",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001U12;
        prmT001U12 = new Object[] {
        new ParDef("@ParDSubProd",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001U13;
        prmT001U13 = new Object[] {
        new ParDef("@ParDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT001U14;
        prmT001U14 = new Object[] {
        new ParDef("@ParDCueCod1",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001U15;
        prmT001U15 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U3;
        prmT001U3 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U16;
        prmT001U16 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U17;
        prmT001U17 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U2;
        prmT001U2 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U18;
        prmT001U18 = new Object[] {
        new ParDef("@ParDItem",GXType.Int16,4,0) ,
        new ParDef("@ParDTip",GXType.NChar,1,0) ,
        new ParDef("@ParDTip1",GXType.NChar,1,0) ,
        new ParDef("@ParDCueCod2",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParDTip2",GXType.NChar,1,0) ,
        new ParDef("@ParDCueCod3",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParDTip3",GXType.NChar,1,0) ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDLinProd",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ParDSubProd",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ParDCueCod",GXType.NChar,15,0) ,
        new ParDef("@ParDCueCod1",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT001U19;
        prmT001U19 = new Object[] {
        new ParDef("@ParDTip",GXType.NChar,1,0) ,
        new ParDef("@ParDTip1",GXType.NChar,1,0) ,
        new ParDef("@ParDCueCod2",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParDTip2",GXType.NChar,1,0) ,
        new ParDef("@ParDCueCod3",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParDTip3",GXType.NChar,1,0) ,
        new ParDef("@ParDLinProd",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ParDSubProd",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@ParDCueCod",GXType.NChar,15,0) ,
        new ParDef("@ParDCueCod1",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U20;
        prmT001U20 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDItem",GXType.Int16,4,0)
        };
        Object[] prmT001U23;
        prmT001U23 = new Object[] {
        };
        Object[] prmT001U24;
        prmT001U24 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001U21;
        prmT001U21 = new Object[] {
        new ParDef("@ParDLinProd",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001U22;
        prmT001U22 = new Object[] {
        new ParDef("@ParDSubProd",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001U25;
        prmT001U25 = new Object[] {
        new ParDef("@ParDCueCod",GXType.NChar,15,0)
        };
        Object[] prmT001U26;
        prmT001U26 = new Object[] {
        new ParDef("@ParDCueCod1",GXType.NChar,15,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T001U2", "SELECT [ParDItem], [ParDTip], [ParDTip1], [ParDCueCod2], [ParDTip2], [ParDCueCod3], [ParDTip3], [ParTip], [ParCod], [ParDLinProd] AS ParDLinProd, [ParDSubProd] AS ParDSubProd, [ParDCueCod] AS ParDCueCod, [ParDCueCod1] AS ParDCueCod1 FROM [CBPARAMPROD] WITH (UPDLOCK) WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDItem] = @ParDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U3", "SELECT [ParDItem], [ParDTip], [ParDTip1], [ParDCueCod2], [ParDTip2], [ParDCueCod3], [ParDTip3], [ParTip], [ParCod], [ParDLinProd] AS ParDLinProd, [ParDSubProd] AS ParDSubProd, [ParDCueCod] AS ParDCueCod, [ParDCueCod1] AS ParDCueCod1 FROM [CBPARAMPROD] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDItem] = @ParDItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U4", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U5", "SELECT [LinDsc] AS ParDLinDsc FROM [CLINEAPROD] WHERE [LinCod] = @ParDLinProd ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U6", "SELECT [SublDsc] AS ParDSubDsc FROM [CSUBLPROD] WHERE [SublCod] = @ParDSubProd ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U7", "SELECT [CueCod] AS ParDCueCod FROM [CBPLANCUENTA] WHERE [CueCod] = @ParDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U8", "SELECT [CueCod] AS ParDCueCod1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParDCueCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U9", "SELECT TM1.[ParDItem], T2.[LinDsc] AS ParDLinDsc, T3.[SublDsc] AS ParDSubDsc, TM1.[ParDTip], TM1.[ParDTip1], TM1.[ParDCueCod2], TM1.[ParDTip2], TM1.[ParDCueCod3], TM1.[ParDTip3], TM1.[ParTip], TM1.[ParCod], TM1.[ParDLinProd] AS ParDLinProd, TM1.[ParDSubProd] AS ParDSubProd, TM1.[ParDCueCod] AS ParDCueCod, TM1.[ParDCueCod1] AS ParDCueCod1 FROM (([CBPARAMPROD] TM1 LEFT JOIN [CLINEAPROD] T2 ON T2.[LinCod] = TM1.[ParDLinProd]) LEFT JOIN [CSUBLPROD] T3 ON T3.[SublCod] = TM1.[ParDSubProd]) WHERE TM1.[ParTip] = @ParTip and TM1.[ParCod] = @ParCod and TM1.[ParDItem] = @ParDItem ORDER BY TM1.[ParTip], TM1.[ParCod], TM1.[ParDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U9,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U10", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U11", "SELECT [LinDsc] AS ParDLinDsc FROM [CLINEAPROD] WHERE [LinCod] = @ParDLinProd ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U12", "SELECT [SublDsc] AS ParDSubDsc FROM [CSUBLPROD] WHERE [SublCod] = @ParDSubProd ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U13", "SELECT [CueCod] AS ParDCueCod FROM [CBPLANCUENTA] WHERE [CueCod] = @ParDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U14", "SELECT [CueCod] AS ParDCueCod1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParDCueCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U15", "SELECT [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDItem] = @ParDItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U16", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE ( [ParTip] > @ParTip or [ParTip] = @ParTip and [ParCod] > @ParCod or [ParCod] = @ParCod and [ParTip] = @ParTip and [ParDItem] > @ParDItem) ORDER BY [ParTip], [ParCod], [ParDItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001U17", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE ( [ParTip] < @ParTip or [ParTip] = @ParTip and [ParCod] < @ParCod or [ParCod] = @ParCod and [ParTip] = @ParTip and [ParDItem] < @ParDItem) ORDER BY [ParTip] DESC, [ParCod] DESC, [ParDItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001U18", "INSERT INTO [CBPARAMPROD]([ParDItem], [ParDTip], [ParDTip1], [ParDCueCod2], [ParDTip2], [ParDCueCod3], [ParDTip3], [ParTip], [ParCod], [ParDLinProd], [ParDSubProd], [ParDCueCod], [ParDCueCod1]) VALUES(@ParDItem, @ParDTip, @ParDTip1, @ParDCueCod2, @ParDTip2, @ParDCueCod3, @ParDTip3, @ParTip, @ParCod, @ParDLinProd, @ParDSubProd, @ParDCueCod, @ParDCueCod1)", GxErrorMask.GX_NOMASK,prmT001U18)
           ,new CursorDef("T001U19", "UPDATE [CBPARAMPROD] SET [ParDTip]=@ParDTip, [ParDTip1]=@ParDTip1, [ParDCueCod2]=@ParDCueCod2, [ParDTip2]=@ParDTip2, [ParDCueCod3]=@ParDCueCod3, [ParDTip3]=@ParDTip3, [ParDLinProd]=@ParDLinProd, [ParDSubProd]=@ParDSubProd, [ParDCueCod]=@ParDCueCod, [ParDCueCod1]=@ParDCueCod1  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDItem] = @ParDItem", GxErrorMask.GX_NOMASK,prmT001U19)
           ,new CursorDef("T001U20", "DELETE FROM [CBPARAMPROD]  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDItem] = @ParDItem", GxErrorMask.GX_NOMASK,prmT001U20)
           ,new CursorDef("T001U21", "SELECT [LinDsc] AS ParDLinDsc FROM [CLINEAPROD] WHERE [LinCod] = @ParDLinProd ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U22", "SELECT [SublDsc] AS ParDSubDsc FROM [CSUBLPROD] WHERE [SublCod] = @ParDSubProd ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U22,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U23", "SELECT [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] ORDER BY [ParTip], [ParCod], [ParDItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001U23,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U24", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U25", "SELECT [CueCod] AS ParDCueCod FROM [CBPLANCUENTA] WHERE [CueCod] = @ParDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U25,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001U26", "SELECT [CueCod] AS ParDCueCod1 FROM [CBPLANCUENTA] WHERE [CueCod] = @ParDCueCod1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001U26,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 1);
              ((string[]) buf[6])[0] = rslt.getString(6, 15);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 1);
              ((string[]) buf[9])[0] = rslt.getString(8, 3);
              ((int[]) buf[10])[0] = rslt.getInt(9);
              ((int[]) buf[11])[0] = rslt.getInt(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((int[]) buf[13])[0] = rslt.getInt(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 15);
              ((string[]) buf[16])[0] = rslt.getString(13, 15);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 1);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 1);
              ((string[]) buf[6])[0] = rslt.getString(6, 15);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((string[]) buf[8])[0] = rslt.getString(7, 1);
              ((string[]) buf[9])[0] = rslt.getString(8, 3);
              ((int[]) buf[10])[0] = rslt.getInt(9);
              ((int[]) buf[11])[0] = rslt.getInt(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((int[]) buf[13])[0] = rslt.getInt(11);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 15);
              ((string[]) buf[16])[0] = rslt.getString(13, 15);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 1);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 1);
              ((string[]) buf[8])[0] = rslt.getString(8, 15);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getString(9, 1);
              ((string[]) buf[11])[0] = rslt.getString(10, 3);
              ((int[]) buf[12])[0] = rslt.getInt(11);
              ((int[]) buf[13])[0] = rslt.getInt(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((int[]) buf[15])[0] = rslt.getInt(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              ((string[]) buf[17])[0] = rslt.getString(14, 15);
              ((string[]) buf[18])[0] = rslt.getString(15, 15);
              ((bool[]) buf[19])[0] = rslt.wasNull(15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
