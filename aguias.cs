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
   public class aguias : GXDataArea
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
            A22MvAMov = (int)(NumberUtil.Val( GetPar( "MvAMov"), "."));
            AssignAttri("", false, "A22MvAMov", StringUtil.LTrimStr( (decimal)(A22MvAMov), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A22MvAMov) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A21MvAlm = (int)(NumberUtil.Val( GetPar( "MvAlm"), "."));
            AssignAttri("", false, "A21MvAlm", StringUtil.LTrimStr( (decimal)(A21MvAlm), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A21MvAlm) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A23DocTip = GetPar( "DocTip");
            n23DocTip = false;
            AssignAttri("", false, "A23DocTip", A23DocTip);
            A24DocNum = GetPar( "DocNum");
            n24DocNum = false;
            AssignAttri("", false, "A24DocNum", A24DocNum);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A23DocTip, A24DocNum) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A20MVPedCod = GetPar( "MVPedCod");
            n20MVPedCod = false;
            AssignAttri("", false, "A20MVPedCod", A20MVPedCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A20MVPedCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A15MVCliCod = GetPar( "MVCliCod");
            n15MVCliCod = false;
            AssignAttri("", false, "A15MVCliCod", A15MVCliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A15MVCliCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A15MVCliCod = GetPar( "MVCliCod");
            n15MVCliCod = false;
            AssignAttri("", false, "A15MVCliCod", A15MVCliCod);
            A16MVCliOrigen = (int)(NumberUtil.Val( GetPar( "MVCliOrigen"), "."));
            n16MVCliOrigen = false;
            AssignAttri("", false, "A16MVCliOrigen", StringUtil.LTrimStr( (decimal)(A16MVCliOrigen), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A15MVCliCod, A16MVCliOrigen) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A10ChoCod = (int)(NumberUtil.Val( GetPar( "ChoCod"), "."));
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A10ChoCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A18MVCDesCod = GetPar( "MVCDesCod");
            n18MVCDesCod = false;
            AssignAttri("", false, "A18MVCDesCod", A18MVCDesCod);
            A19MVCDesItem = (int)(NumberUtil.Val( GetPar( "MVCDesItem"), "."));
            n19MVCDesItem = false;
            AssignAttri("", false, "A19MVCDesItem", StringUtil.LTrimStr( (decimal)(A19MVCDesItem), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A18MVCDesCod, A19MVCDesItem) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A17EmpTCod = (int)(NumberUtil.Val( GetPar( "EmpTCod"), "."));
            n17EmpTCod = false;
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A17EmpTCod) ;
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
            Form.Meta.addItem("description", "Movimientos de Almacen - Cabecera", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aguias( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aguias( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AGUIAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Mov. Almacen", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvATip_Internalname, StringUtil.RTrim( A13MvATip), StringUtil.RTrim( context.localUtil.Format( A13MvATip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvATip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvATip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Mov.Almacen", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvACod_Internalname, StringUtil.RTrim( A14MvACod), StringUtil.RTrim( context.localUtil.Format( A14MvACod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvACod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvACod_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Fecha Mov. Almacen", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMvAFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMvAFec_Internalname, context.localUtil.Format(A25MvAFec, "99/99/99"), context.localUtil.Format( A25MvAFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         GxWebStd.gx_bitmap( context, edtMvAFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMvAFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "O.Compra", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvAOcom_Internalname, StringUtil.RTrim( A1276MvAOcom), StringUtil.RTrim( context.localUtil.Format( A1276MvAOcom, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAOcom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAOcom_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Doc.Referencia", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvARef_Internalname, StringUtil.RTrim( A1278MvARef), StringUtil.RTrim( context.localUtil.Format( A1278MvARef, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvARef_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvARef_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Tipo Movimiento", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvATMov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1286MvATMov), 1, 0, ".", "")), StringUtil.LTrim( ((edtMvATMov_Enabled!=0) ? context.localUtil.Format( (decimal)(A1286MvATMov), "9") : context.localUtil.Format( (decimal)(A1286MvATMov), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvATMov_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvATMov_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Codigo Mov. Almacen", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvAMov_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A22MvAMov), 6, 0, ".", "")), StringUtil.LTrim( ((edtMvAMov_Enabled!=0) ? context.localUtil.Format( (decimal)(A22MvAMov), "ZZZZZ9") : context.localUtil.Format( (decimal)(A22MvAMov), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAMov_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAMov_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Movimiento de Almacen", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMvAMovDsc_Internalname, StringUtil.RTrim( A1274MvAMovDsc), StringUtil.RTrim( context.localUtil.Format( A1274MvAMovDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAMovDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAMovDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Autogenera costo", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMvAMovAut_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1273MvAMovAut), 1, 0, ".", "")), StringUtil.LTrim( ((edtMvAMovAut_Enabled!=0) ? context.localUtil.Format( (decimal)(A1273MvAMovAut), "9") : context.localUtil.Format( (decimal)(A1273MvAMovAut), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAMovAut_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAMovAut_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Codigo Almacen", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvAlm_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A21MvAlm), 6, 0, ".", "")), StringUtil.LTrim( ((edtMvAlm_Enabled!=0) ? context.localUtil.Format( (decimal)(A21MvAlm), "ZZZZZ9") : context.localUtil.Format( (decimal)(A21MvAlm), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAlm_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAlm_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Observaciones", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtMvAObs_Internalname, A1275MvAObs, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", 0, 1, edtMvAObs_Enabled, 0, 80, "chr", 7, "row", StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Tipo Documento", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTip_Internalname, StringUtil.RTrim( A23DocTip), StringUtil.RTrim( context.localUtil.Format( A23DocTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Numero Doc.", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocNum_Internalname, StringUtil.RTrim( A24DocNum), StringUtil.RTrim( context.localUtil.Format( A24DocNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtDocNum_Enabled, 0, "text", "", 12, "chr", 1, "row", 12, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Situacion", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVSts_Internalname, StringUtil.RTrim( A1370MVSts), StringUtil.RTrim( context.localUtil.Format( A1370MVSts, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVSts_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Pedido", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVPedCod_Internalname, StringUtil.RTrim( A20MVPedCod), StringUtil.RTrim( context.localUtil.Format( A20MVPedCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVPedCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Total Items", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMvATItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1285MvATItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtMvATItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A1285MvATItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1285MvATItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvATItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvATItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Codigo Cliente", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVCliCod_Internalname, StringUtil.RTrim( A15MVCliCod), StringUtil.RTrim( context.localUtil.Format( A15MVCliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Cliente", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVCliDsc_Internalname, StringUtil.RTrim( A1290MVCliDsc), StringUtil.RTrim( context.localUtil.Format( A1290MVCliDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCliDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCliDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Dirección", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVCliDir_Internalname, StringUtil.RTrim( A1289MVCliDir), StringUtil.RTrim( context.localUtil.Format( A1289MVCliDir, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCliDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCliDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Cliente Destino 1", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVCliOrigen_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A16MVCliOrigen), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVCliOrigen_Enabled!=0) ? context.localUtil.Format( (decimal)(A16MVCliOrigen), "ZZZZZ9") : context.localUtil.Format( (decimal)(A16MVCliOrigen), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCliOrigen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCliOrigen_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Dirección Origen", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMVCliOrigenDir_Internalname, StringUtil.RTrim( A1291MVCliOrigenDir), StringUtil.RTrim( context.localUtil.Format( A1291MVCliOrigenDir, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCliOrigenDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCliOrigenDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Codigo Chofer", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtChoCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ChoCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtChoCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A10ChoCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtChoCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtChoCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Tipo de Movimiento Interno", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVATipo_Internalname, StringUtil.RTrim( A1284MVATipo), StringUtil.RTrim( context.localUtil.Format( A1284MVATipo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVATipo_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVATipo_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Almacen Destino", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVAlmDestino_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1270MVAlmDestino), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVAlmDestino_Enabled!=0) ? context.localUtil.Format( (decimal)(A1270MVAlmDestino), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1270MVAlmDestino), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,136);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVAlmDestino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVAlmDestino_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Placa - Guia", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVAPlaca_Internalname, StringUtil.RTrim( A1277MVAPlaca), StringUtil.RTrim( context.localUtil.Format( A1277MVAPlaca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVAPlaca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVAPlaca_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Centro de Costo", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVCCosto_Internalname, StringUtil.RTrim( A1287MVCCosto), StringUtil.RTrim( context.localUtil.Format( A1287MVCCosto, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCCosto_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Codigo Cliente", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVCDesCod_Internalname, StringUtil.RTrim( A18MVCDesCod), StringUtil.RTrim( context.localUtil.Format( A18MVCDesCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCDesCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCDesCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Cliente Destino 2", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVCDesItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MVCDesItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVCDesItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A19MVCDesItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A19MVCDesItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVCDesItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVCDesItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "Codigo", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtEmpTCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EmpTCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtEmpTCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A17EmpTCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A17EmpTCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtEmpTCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtEmpTCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "Usuario", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVUsuCod_Internalname, StringUtil.RTrim( A1372MVUsuCod), StringUtil.RTrim( context.localUtil.Format( A1372MVUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Usuario Fecha", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 171,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtMVUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtMVUsuFec_Internalname, context.localUtil.TToC( A1373MVUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1373MVUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,171);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         GxWebStd.gx_bitmap( context, edtMVUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtMVUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Almacen", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMvAlmDsc_Internalname, StringUtil.RTrim( A1271MvAlmDsc), StringUtil.RTrim( context.localUtil.Format( A1271MvAlmDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAlmDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAlmDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Valoriza", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtMvAlmCos_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1269MvAlmCos), 1, 0, ".", "")), StringUtil.LTrim( ((edtMvAlmCos_Enabled!=0) ? context.localUtil.Format( (decimal)(A1269MvAlmCos), "9") : context.localUtil.Format( (decimal)(A1269MvAlmCos), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMvAlmCos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMvAlmCos_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Año", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 186,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVVouAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1374MVVouAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtMVVouAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1374MVVouAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1374MVVouAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,186);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVVouAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVVouAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Mes", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVVouMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1375MVVouMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtMVVouMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1375MVVouMes), "Z9") : context.localUtil.Format( (decimal)(A1375MVVouMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVVouMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVVouMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Tipo Asiento", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 196,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVTAsiCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1371MVTAsiCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtMVTAsiCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1371MVTAsiCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1371MVTAsiCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,196);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVTAsiCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVTAsiCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "N° Asiento", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVVouNum_Internalname, StringUtil.RTrim( A1376MVVouNum), StringUtil.RTrim( context.localUtil.Format( A1376MVVouNum, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVVouNum_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVVouNum_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "N° Poliza", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 206,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMVPoliza_Internalname, StringUtil.RTrim( A1369MVPoliza), StringUtil.RTrim( context.localUtil.Format( A1369MVPoliza, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,206);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMVPoliza_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMVPoliza_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AGUIAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 209,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 210,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 212,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AGUIAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 213,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_AGUIAS.htm");
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
            Z13MvATip = cgiGet( "Z13MvATip");
            Z14MvACod = cgiGet( "Z14MvACod");
            Z25MvAFec = context.localUtil.CToD( cgiGet( "Z25MvAFec"), 0);
            Z1276MvAOcom = cgiGet( "Z1276MvAOcom");
            Z1278MvARef = cgiGet( "Z1278MvARef");
            Z1286MvATMov = (short)(context.localUtil.CToN( cgiGet( "Z1286MvATMov"), ".", ","));
            Z1370MVSts = cgiGet( "Z1370MVSts");
            Z1285MvATItem = (int)(context.localUtil.CToN( cgiGet( "Z1285MvATItem"), ".", ","));
            Z1284MVATipo = cgiGet( "Z1284MVATipo");
            Z1270MVAlmDestino = (int)(context.localUtil.CToN( cgiGet( "Z1270MVAlmDestino"), ".", ","));
            Z1277MVAPlaca = cgiGet( "Z1277MVAPlaca");
            Z1287MVCCosto = cgiGet( "Z1287MVCCosto");
            Z1372MVUsuCod = cgiGet( "Z1372MVUsuCod");
            Z1373MVUsuFec = context.localUtil.CToT( cgiGet( "Z1373MVUsuFec"), 0);
            Z1374MVVouAno = (short)(context.localUtil.CToN( cgiGet( "Z1374MVVouAno"), ".", ","));
            Z1375MVVouMes = (short)(context.localUtil.CToN( cgiGet( "Z1375MVVouMes"), ".", ","));
            Z1371MVTAsiCod = (int)(context.localUtil.CToN( cgiGet( "Z1371MVTAsiCod"), ".", ","));
            Z1376MVVouNum = cgiGet( "Z1376MVVouNum");
            Z1369MVPoliza = cgiGet( "Z1369MVPoliza");
            Z1279MVARef1 = cgiGet( "Z1279MVARef1");
            Z1280MVARef2 = cgiGet( "Z1280MVARef2");
            Z1281MVARef3 = cgiGet( "Z1281MVARef3");
            Z1282MVARef4 = cgiGet( "Z1282MVARef4");
            Z1283MVARef5 = cgiGet( "Z1283MVARef5");
            Z1246MVACadena = cgiGet( "Z1246MVACadena");
            Z1268MVAGEOBS = cgiGet( "Z1268MVAGEOBS");
            Z1267MVAFecIni = context.localUtil.CToD( cgiGet( "Z1267MVAFecIni"), 0);
            Z10ChoCod = (int)(context.localUtil.CToN( cgiGet( "Z10ChoCod"), ".", ","));
            Z17EmpTCod = (int)(context.localUtil.CToN( cgiGet( "Z17EmpTCod"), ".", ","));
            Z22MvAMov = (int)(context.localUtil.CToN( cgiGet( "Z22MvAMov"), ".", ","));
            Z21MvAlm = (int)(context.localUtil.CToN( cgiGet( "Z21MvAlm"), ".", ","));
            Z23DocTip = cgiGet( "Z23DocTip");
            n23DocTip = (String.IsNullOrEmpty(StringUtil.RTrim( A23DocTip)) ? true : false);
            Z20MVPedCod = cgiGet( "Z20MVPedCod");
            n20MVPedCod = (String.IsNullOrEmpty(StringUtil.RTrim( A20MVPedCod)) ? true : false);
            Z15MVCliCod = cgiGet( "Z15MVCliCod");
            n15MVCliCod = (String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) ? true : false);
            Z18MVCDesCod = cgiGet( "Z18MVCDesCod");
            Z24DocNum = cgiGet( "Z24DocNum");
            n24DocNum = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? true : false);
            Z16MVCliOrigen = (int)(context.localUtil.CToN( cgiGet( "Z16MVCliOrigen"), ".", ","));
            n16MVCliOrigen = ((0==A16MVCliOrigen) ? true : false);
            Z19MVCDesItem = (int)(context.localUtil.CToN( cgiGet( "Z19MVCDesItem"), ".", ","));
            A1279MVARef1 = cgiGet( "Z1279MVARef1");
            A1280MVARef2 = cgiGet( "Z1280MVARef2");
            A1281MVARef3 = cgiGet( "Z1281MVARef3");
            A1282MVARef4 = cgiGet( "Z1282MVARef4");
            A1283MVARef5 = cgiGet( "Z1283MVARef5");
            A1246MVACadena = cgiGet( "Z1246MVACadena");
            A1268MVAGEOBS = cgiGet( "Z1268MVAGEOBS");
            A1267MVAFecIni = context.localUtil.CToD( cgiGet( "Z1267MVAFecIni"), 0);
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1279MVARef1 = cgiGet( "MVAREF1");
            A1280MVARef2 = cgiGet( "MVAREF2");
            A1281MVARef3 = cgiGet( "MVAREF3");
            A1282MVARef4 = cgiGet( "MVAREF4");
            A1283MVARef5 = cgiGet( "MVAREF5");
            A1246MVACadena = cgiGet( "MVACADENA");
            A1268MVAGEOBS = cgiGet( "MVAGEOBS");
            A1267MVAFecIni = context.localUtil.CToD( cgiGet( "MVAFECINI"), 0);
            A1272MVAlmSts = (short)(context.localUtil.CToN( cgiGet( "MVALMSTS"), ".", ","));
            /* Read variables values. */
            A13MvATip = cgiGet( edtMvATip_Internalname);
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = cgiGet( edtMvACod_Internalname);
            AssignAttri("", false, "A14MvACod", A14MvACod);
            if ( context.localUtil.VCDate( cgiGet( edtMvAFec_Internalname), 2) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Mov. Almacen"}), 1, "MVAFEC");
               AnyError = 1;
               GX_FocusControl = edtMvAFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A25MvAFec = DateTime.MinValue;
               AssignAttri("", false, "A25MvAFec", context.localUtil.Format(A25MvAFec, "99/99/99"));
            }
            else
            {
               A25MvAFec = context.localUtil.CToD( cgiGet( edtMvAFec_Internalname), 2);
               AssignAttri("", false, "A25MvAFec", context.localUtil.Format(A25MvAFec, "99/99/99"));
            }
            A1276MvAOcom = cgiGet( edtMvAOcom_Internalname);
            AssignAttri("", false, "A1276MvAOcom", A1276MvAOcom);
            A1278MvARef = cgiGet( edtMvARef_Internalname);
            AssignAttri("", false, "A1278MvARef", A1278MvARef);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMvATMov_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMvATMov_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVATMOV");
               AnyError = 1;
               GX_FocusControl = edtMvATMov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1286MvATMov = 0;
               AssignAttri("", false, "A1286MvATMov", StringUtil.Str( (decimal)(A1286MvATMov), 1, 0));
            }
            else
            {
               A1286MvATMov = (short)(context.localUtil.CToN( cgiGet( edtMvATMov_Internalname), ".", ","));
               AssignAttri("", false, "A1286MvATMov", StringUtil.Str( (decimal)(A1286MvATMov), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMvAMov_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMvAMov_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVAMOV");
               AnyError = 1;
               GX_FocusControl = edtMvAMov_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A22MvAMov = 0;
               AssignAttri("", false, "A22MvAMov", StringUtil.LTrimStr( (decimal)(A22MvAMov), 6, 0));
            }
            else
            {
               A22MvAMov = (int)(context.localUtil.CToN( cgiGet( edtMvAMov_Internalname), ".", ","));
               AssignAttri("", false, "A22MvAMov", StringUtil.LTrimStr( (decimal)(A22MvAMov), 6, 0));
            }
            A1274MvAMovDsc = cgiGet( edtMvAMovDsc_Internalname);
            AssignAttri("", false, "A1274MvAMovDsc", A1274MvAMovDsc);
            A1273MvAMovAut = (short)(context.localUtil.CToN( cgiGet( edtMvAMovAut_Internalname), ".", ","));
            AssignAttri("", false, "A1273MvAMovAut", StringUtil.Str( (decimal)(A1273MvAMovAut), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtMvAlm_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMvAlm_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVALM");
               AnyError = 1;
               GX_FocusControl = edtMvAlm_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A21MvAlm = 0;
               AssignAttri("", false, "A21MvAlm", StringUtil.LTrimStr( (decimal)(A21MvAlm), 6, 0));
            }
            else
            {
               A21MvAlm = (int)(context.localUtil.CToN( cgiGet( edtMvAlm_Internalname), ".", ","));
               AssignAttri("", false, "A21MvAlm", StringUtil.LTrimStr( (decimal)(A21MvAlm), 6, 0));
            }
            A1275MvAObs = cgiGet( edtMvAObs_Internalname);
            AssignAttri("", false, "A1275MvAObs", A1275MvAObs);
            A23DocTip = cgiGet( edtDocTip_Internalname);
            n23DocTip = false;
            AssignAttri("", false, "A23DocTip", A23DocTip);
            n23DocTip = (String.IsNullOrEmpty(StringUtil.RTrim( A23DocTip)) ? true : false);
            A24DocNum = cgiGet( edtDocNum_Internalname);
            n24DocNum = false;
            AssignAttri("", false, "A24DocNum", A24DocNum);
            n24DocNum = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? true : false);
            A1370MVSts = cgiGet( edtMVSts_Internalname);
            AssignAttri("", false, "A1370MVSts", A1370MVSts);
            A20MVPedCod = cgiGet( edtMVPedCod_Internalname);
            n20MVPedCod = false;
            AssignAttri("", false, "A20MVPedCod", A20MVPedCod);
            n20MVPedCod = (String.IsNullOrEmpty(StringUtil.RTrim( A20MVPedCod)) ? true : false);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMvATItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMvATItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVATITEM");
               AnyError = 1;
               GX_FocusControl = edtMvATItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1285MvATItem = 0;
               AssignAttri("", false, "A1285MvATItem", StringUtil.LTrimStr( (decimal)(A1285MvATItem), 6, 0));
            }
            else
            {
               A1285MvATItem = (int)(context.localUtil.CToN( cgiGet( edtMvATItem_Internalname), ".", ","));
               AssignAttri("", false, "A1285MvATItem", StringUtil.LTrimStr( (decimal)(A1285MvATItem), 6, 0));
            }
            A15MVCliCod = cgiGet( edtMVCliCod_Internalname);
            n15MVCliCod = false;
            AssignAttri("", false, "A15MVCliCod", A15MVCliCod);
            n15MVCliCod = (String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) ? true : false);
            A1290MVCliDsc = cgiGet( edtMVCliDsc_Internalname);
            AssignAttri("", false, "A1290MVCliDsc", A1290MVCliDsc);
            A1289MVCliDir = cgiGet( edtMVCliDir_Internalname);
            AssignAttri("", false, "A1289MVCliDir", A1289MVCliDir);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVCliOrigen_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVCliOrigen_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVCLIORIGEN");
               AnyError = 1;
               GX_FocusControl = edtMVCliOrigen_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A16MVCliOrigen = 0;
               n16MVCliOrigen = false;
               AssignAttri("", false, "A16MVCliOrigen", StringUtil.LTrimStr( (decimal)(A16MVCliOrigen), 6, 0));
            }
            else
            {
               A16MVCliOrigen = (int)(context.localUtil.CToN( cgiGet( edtMVCliOrigen_Internalname), ".", ","));
               n16MVCliOrigen = false;
               AssignAttri("", false, "A16MVCliOrigen", StringUtil.LTrimStr( (decimal)(A16MVCliOrigen), 6, 0));
            }
            n16MVCliOrigen = ((0==A16MVCliOrigen) ? true : false);
            A1291MVCliOrigenDir = cgiGet( edtMVCliOrigenDir_Internalname);
            AssignAttri("", false, "A1291MVCliOrigenDir", A1291MVCliOrigenDir);
            if ( ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CHOCOD");
               AnyError = 1;
               GX_FocusControl = edtChoCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A10ChoCod = 0;
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            }
            else
            {
               A10ChoCod = (int)(context.localUtil.CToN( cgiGet( edtChoCod_Internalname), ".", ","));
               AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            }
            A1284MVATipo = cgiGet( edtMVATipo_Internalname);
            AssignAttri("", false, "A1284MVATipo", A1284MVATipo);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVAlmDestino_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVAlmDestino_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVALMDESTINO");
               AnyError = 1;
               GX_FocusControl = edtMVAlmDestino_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1270MVAlmDestino = 0;
               AssignAttri("", false, "A1270MVAlmDestino", StringUtil.LTrimStr( (decimal)(A1270MVAlmDestino), 6, 0));
            }
            else
            {
               A1270MVAlmDestino = (int)(context.localUtil.CToN( cgiGet( edtMVAlmDestino_Internalname), ".", ","));
               AssignAttri("", false, "A1270MVAlmDestino", StringUtil.LTrimStr( (decimal)(A1270MVAlmDestino), 6, 0));
            }
            A1277MVAPlaca = cgiGet( edtMVAPlaca_Internalname);
            AssignAttri("", false, "A1277MVAPlaca", A1277MVAPlaca);
            A1287MVCCosto = cgiGet( edtMVCCosto_Internalname);
            AssignAttri("", false, "A1287MVCCosto", A1287MVCCosto);
            A18MVCDesCod = cgiGet( edtMVCDesCod_Internalname);
            n18MVCDesCod = false;
            AssignAttri("", false, "A18MVCDesCod", A18MVCDesCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVCDesItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVCDesItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVCDESITEM");
               AnyError = 1;
               GX_FocusControl = edtMVCDesItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A19MVCDesItem = 0;
               n19MVCDesItem = false;
               AssignAttri("", false, "A19MVCDesItem", StringUtil.LTrimStr( (decimal)(A19MVCDesItem), 6, 0));
            }
            else
            {
               A19MVCDesItem = (int)(context.localUtil.CToN( cgiGet( edtMVCDesItem_Internalname), ".", ","));
               n19MVCDesItem = false;
               AssignAttri("", false, "A19MVCDesItem", StringUtil.LTrimStr( (decimal)(A19MVCDesItem), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "EMPTCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpTCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A17EmpTCod = 0;
               n17EmpTCod = false;
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            }
            else
            {
               A17EmpTCod = (int)(context.localUtil.CToN( cgiGet( edtEmpTCod_Internalname), ".", ","));
               n17EmpTCod = false;
               AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            }
            A1372MVUsuCod = cgiGet( edtMVUsuCod_Internalname);
            AssignAttri("", false, "A1372MVUsuCod", A1372MVUsuCod);
            if ( context.localUtil.VCDateTime( cgiGet( edtMVUsuFec_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "MVUSUFEC");
               AnyError = 1;
               GX_FocusControl = edtMVUsuFec_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1373MVUsuFec = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A1373MVUsuFec", context.localUtil.TToC( A1373MVUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A1373MVUsuFec = context.localUtil.CToT( cgiGet( edtMVUsuFec_Internalname));
               AssignAttri("", false, "A1373MVUsuFec", context.localUtil.TToC( A1373MVUsuFec, 8, 5, 0, 3, "/", ":", " "));
            }
            A1271MvAlmDsc = cgiGet( edtMvAlmDsc_Internalname);
            AssignAttri("", false, "A1271MvAlmDsc", A1271MvAlmDsc);
            A1269MvAlmCos = (short)(context.localUtil.CToN( cgiGet( edtMvAlmCos_Internalname), ".", ","));
            AssignAttri("", false, "A1269MvAlmCos", StringUtil.Str( (decimal)(A1269MvAlmCos), 1, 0));
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVVouAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVVouAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVVOUANO");
               AnyError = 1;
               GX_FocusControl = edtMVVouAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1374MVVouAno = 0;
               AssignAttri("", false, "A1374MVVouAno", StringUtil.LTrimStr( (decimal)(A1374MVVouAno), 4, 0));
            }
            else
            {
               A1374MVVouAno = (short)(context.localUtil.CToN( cgiGet( edtMVVouAno_Internalname), ".", ","));
               AssignAttri("", false, "A1374MVVouAno", StringUtil.LTrimStr( (decimal)(A1374MVVouAno), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVVouMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVVouMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVVOUMES");
               AnyError = 1;
               GX_FocusControl = edtMVVouMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1375MVVouMes = 0;
               AssignAttri("", false, "A1375MVVouMes", StringUtil.LTrimStr( (decimal)(A1375MVVouMes), 2, 0));
            }
            else
            {
               A1375MVVouMes = (short)(context.localUtil.CToN( cgiGet( edtMVVouMes_Internalname), ".", ","));
               AssignAttri("", false, "A1375MVVouMes", StringUtil.LTrimStr( (decimal)(A1375MVVouMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtMVTAsiCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMVTAsiCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MVTASICOD");
               AnyError = 1;
               GX_FocusControl = edtMVTAsiCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1371MVTAsiCod = 0;
               AssignAttri("", false, "A1371MVTAsiCod", StringUtil.LTrimStr( (decimal)(A1371MVTAsiCod), 6, 0));
            }
            else
            {
               A1371MVTAsiCod = (int)(context.localUtil.CToN( cgiGet( edtMVTAsiCod_Internalname), ".", ","));
               AssignAttri("", false, "A1371MVTAsiCod", StringUtil.LTrimStr( (decimal)(A1371MVTAsiCod), 6, 0));
            }
            A1376MVVouNum = cgiGet( edtMVVouNum_Internalname);
            AssignAttri("", false, "A1376MVVouNum", A1376MVVouNum);
            A1369MVPoliza = cgiGet( edtMVPoliza_Internalname);
            AssignAttri("", false, "A1369MVPoliza", A1369MVPoliza);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"AGUIAS");
            forbiddenHiddens.Add("MVARef1", StringUtil.RTrim( context.localUtil.Format( A1279MVARef1, "")));
            forbiddenHiddens.Add("MVARef2", StringUtil.RTrim( context.localUtil.Format( A1280MVARef2, "")));
            forbiddenHiddens.Add("MVARef3", StringUtil.RTrim( context.localUtil.Format( A1281MVARef3, "")));
            forbiddenHiddens.Add("MVARef4", StringUtil.RTrim( context.localUtil.Format( A1282MVARef4, "")));
            forbiddenHiddens.Add("MVARef5", StringUtil.RTrim( context.localUtil.Format( A1283MVARef5, "")));
            forbiddenHiddens.Add("MVACadena", StringUtil.RTrim( context.localUtil.Format( A1246MVACadena, "")));
            forbiddenHiddens.Add("MVAGEOBS", StringUtil.RTrim( context.localUtil.Format( A1268MVAGEOBS, "")));
            forbiddenHiddens.Add("MVAFecIni", context.localUtil.Format(A1267MVAFecIni, "99/99/99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("aguias:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A13MvATip = GetPar( "MvATip");
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = GetPar( "MvACod");
               AssignAttri("", false, "A14MvACod", A14MvACod);
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
               InitAll1438( ) ;
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
         DisableAttributes1438( ) ;
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

      protected void CONFIRM_140( )
      {
         BeforeValidate1438( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1438( ) ;
            }
            else
            {
               CheckExtendedTable1438( ) ;
               if ( AnyError == 0 )
               {
                  ZM1438( 4) ;
                  ZM1438( 5) ;
                  ZM1438( 6) ;
                  ZM1438( 7) ;
                  ZM1438( 8) ;
                  ZM1438( 9) ;
                  ZM1438( 10) ;
                  ZM1438( 11) ;
                  ZM1438( 12) ;
               }
               CloseExtendedTableCursors1438( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues140( ) ;
         }
      }

      protected void ResetCaption140( )
      {
      }

      protected void ZM1438( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z25MvAFec = T00143_A25MvAFec[0];
               Z1276MvAOcom = T00143_A1276MvAOcom[0];
               Z1278MvARef = T00143_A1278MvARef[0];
               Z1286MvATMov = T00143_A1286MvATMov[0];
               Z1370MVSts = T00143_A1370MVSts[0];
               Z1285MvATItem = T00143_A1285MvATItem[0];
               Z1284MVATipo = T00143_A1284MVATipo[0];
               Z1270MVAlmDestino = T00143_A1270MVAlmDestino[0];
               Z1277MVAPlaca = T00143_A1277MVAPlaca[0];
               Z1287MVCCosto = T00143_A1287MVCCosto[0];
               Z1372MVUsuCod = T00143_A1372MVUsuCod[0];
               Z1373MVUsuFec = T00143_A1373MVUsuFec[0];
               Z1374MVVouAno = T00143_A1374MVVouAno[0];
               Z1375MVVouMes = T00143_A1375MVVouMes[0];
               Z1371MVTAsiCod = T00143_A1371MVTAsiCod[0];
               Z1376MVVouNum = T00143_A1376MVVouNum[0];
               Z1369MVPoliza = T00143_A1369MVPoliza[0];
               Z1279MVARef1 = T00143_A1279MVARef1[0];
               Z1280MVARef2 = T00143_A1280MVARef2[0];
               Z1281MVARef3 = T00143_A1281MVARef3[0];
               Z1282MVARef4 = T00143_A1282MVARef4[0];
               Z1283MVARef5 = T00143_A1283MVARef5[0];
               Z1246MVACadena = T00143_A1246MVACadena[0];
               Z1268MVAGEOBS = T00143_A1268MVAGEOBS[0];
               Z1267MVAFecIni = T00143_A1267MVAFecIni[0];
               Z10ChoCod = T00143_A10ChoCod[0];
               Z17EmpTCod = T00143_A17EmpTCod[0];
               Z22MvAMov = T00143_A22MvAMov[0];
               Z21MvAlm = T00143_A21MvAlm[0];
               Z23DocTip = T00143_A23DocTip[0];
               Z20MVPedCod = T00143_A20MVPedCod[0];
               Z15MVCliCod = T00143_A15MVCliCod[0];
               Z18MVCDesCod = T00143_A18MVCDesCod[0];
               Z24DocNum = T00143_A24DocNum[0];
               Z16MVCliOrigen = T00143_A16MVCliOrigen[0];
               Z19MVCDesItem = T00143_A19MVCDesItem[0];
            }
            else
            {
               Z25MvAFec = A25MvAFec;
               Z1276MvAOcom = A1276MvAOcom;
               Z1278MvARef = A1278MvARef;
               Z1286MvATMov = A1286MvATMov;
               Z1370MVSts = A1370MVSts;
               Z1285MvATItem = A1285MvATItem;
               Z1284MVATipo = A1284MVATipo;
               Z1270MVAlmDestino = A1270MVAlmDestino;
               Z1277MVAPlaca = A1277MVAPlaca;
               Z1287MVCCosto = A1287MVCCosto;
               Z1372MVUsuCod = A1372MVUsuCod;
               Z1373MVUsuFec = A1373MVUsuFec;
               Z1374MVVouAno = A1374MVVouAno;
               Z1375MVVouMes = A1375MVVouMes;
               Z1371MVTAsiCod = A1371MVTAsiCod;
               Z1376MVVouNum = A1376MVVouNum;
               Z1369MVPoliza = A1369MVPoliza;
               Z1279MVARef1 = A1279MVARef1;
               Z1280MVARef2 = A1280MVARef2;
               Z1281MVARef3 = A1281MVARef3;
               Z1282MVARef4 = A1282MVARef4;
               Z1283MVARef5 = A1283MVARef5;
               Z1246MVACadena = A1246MVACadena;
               Z1268MVAGEOBS = A1268MVAGEOBS;
               Z1267MVAFecIni = A1267MVAFecIni;
               Z10ChoCod = A10ChoCod;
               Z17EmpTCod = A17EmpTCod;
               Z22MvAMov = A22MvAMov;
               Z21MvAlm = A21MvAlm;
               Z23DocTip = A23DocTip;
               Z20MVPedCod = A20MVPedCod;
               Z15MVCliCod = A15MVCliCod;
               Z18MVCDesCod = A18MVCDesCod;
               Z24DocNum = A24DocNum;
               Z16MVCliOrigen = A16MVCliOrigen;
               Z19MVCDesItem = A19MVCDesItem;
            }
         }
         if ( GX_JID == -3 )
         {
            Z13MvATip = A13MvATip;
            Z14MvACod = A14MvACod;
            Z25MvAFec = A25MvAFec;
            Z1276MvAOcom = A1276MvAOcom;
            Z1278MvARef = A1278MvARef;
            Z1286MvATMov = A1286MvATMov;
            Z1275MvAObs = A1275MvAObs;
            Z1370MVSts = A1370MVSts;
            Z1285MvATItem = A1285MvATItem;
            Z1284MVATipo = A1284MVATipo;
            Z1270MVAlmDestino = A1270MVAlmDestino;
            Z1277MVAPlaca = A1277MVAPlaca;
            Z1287MVCCosto = A1287MVCCosto;
            Z1372MVUsuCod = A1372MVUsuCod;
            Z1373MVUsuFec = A1373MVUsuFec;
            Z1374MVVouAno = A1374MVVouAno;
            Z1375MVVouMes = A1375MVVouMes;
            Z1371MVTAsiCod = A1371MVTAsiCod;
            Z1376MVVouNum = A1376MVVouNum;
            Z1369MVPoliza = A1369MVPoliza;
            Z1279MVARef1 = A1279MVARef1;
            Z1280MVARef2 = A1280MVARef2;
            Z1281MVARef3 = A1281MVARef3;
            Z1282MVARef4 = A1282MVARef4;
            Z1283MVARef5 = A1283MVARef5;
            Z1246MVACadena = A1246MVACadena;
            Z1268MVAGEOBS = A1268MVAGEOBS;
            Z1267MVAFecIni = A1267MVAFecIni;
            Z10ChoCod = A10ChoCod;
            Z17EmpTCod = A17EmpTCod;
            Z22MvAMov = A22MvAMov;
            Z21MvAlm = A21MvAlm;
            Z23DocTip = A23DocTip;
            Z20MVPedCod = A20MVPedCod;
            Z15MVCliCod = A15MVCliCod;
            Z18MVCDesCod = A18MVCDesCod;
            Z24DocNum = A24DocNum;
            Z16MVCliOrigen = A16MVCliOrigen;
            Z19MVCDesItem = A19MVCDesItem;
            Z1274MvAMovDsc = A1274MvAMovDsc;
            Z1273MvAMovAut = A1273MvAMovAut;
            Z1272MVAlmSts = A1272MVAlmSts;
            Z1271MvAlmDsc = A1271MvAlmDsc;
            Z1269MvAlmCos = A1269MvAlmCos;
            Z1290MVCliDsc = A1290MVCliDsc;
            Z1289MVCliDir = A1289MVCliDir;
            Z1291MVCliOrigenDir = A1291MVCliOrigenDir;
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

      protected void Load1438( )
      {
         /* Using cursor T001413 */
         pr_default.execute(11, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound38 = 1;
            A25MvAFec = T001413_A25MvAFec[0];
            AssignAttri("", false, "A25MvAFec", context.localUtil.Format(A25MvAFec, "99/99/99"));
            A1276MvAOcom = T001413_A1276MvAOcom[0];
            AssignAttri("", false, "A1276MvAOcom", A1276MvAOcom);
            A1278MvARef = T001413_A1278MvARef[0];
            AssignAttri("", false, "A1278MvARef", A1278MvARef);
            A1286MvATMov = T001413_A1286MvATMov[0];
            AssignAttri("", false, "A1286MvATMov", StringUtil.Str( (decimal)(A1286MvATMov), 1, 0));
            A1274MvAMovDsc = T001413_A1274MvAMovDsc[0];
            AssignAttri("", false, "A1274MvAMovDsc", A1274MvAMovDsc);
            A1273MvAMovAut = T001413_A1273MvAMovAut[0];
            AssignAttri("", false, "A1273MvAMovAut", StringUtil.Str( (decimal)(A1273MvAMovAut), 1, 0));
            A1272MVAlmSts = T001413_A1272MVAlmSts[0];
            A1275MvAObs = T001413_A1275MvAObs[0];
            AssignAttri("", false, "A1275MvAObs", A1275MvAObs);
            A1370MVSts = T001413_A1370MVSts[0];
            AssignAttri("", false, "A1370MVSts", A1370MVSts);
            A1285MvATItem = T001413_A1285MvATItem[0];
            AssignAttri("", false, "A1285MvATItem", StringUtil.LTrimStr( (decimal)(A1285MvATItem), 6, 0));
            A1290MVCliDsc = T001413_A1290MVCliDsc[0];
            AssignAttri("", false, "A1290MVCliDsc", A1290MVCliDsc);
            A1289MVCliDir = T001413_A1289MVCliDir[0];
            AssignAttri("", false, "A1289MVCliDir", A1289MVCliDir);
            A1291MVCliOrigenDir = T001413_A1291MVCliOrigenDir[0];
            AssignAttri("", false, "A1291MVCliOrigenDir", A1291MVCliOrigenDir);
            A1284MVATipo = T001413_A1284MVATipo[0];
            AssignAttri("", false, "A1284MVATipo", A1284MVATipo);
            A1270MVAlmDestino = T001413_A1270MVAlmDestino[0];
            AssignAttri("", false, "A1270MVAlmDestino", StringUtil.LTrimStr( (decimal)(A1270MVAlmDestino), 6, 0));
            A1277MVAPlaca = T001413_A1277MVAPlaca[0];
            AssignAttri("", false, "A1277MVAPlaca", A1277MVAPlaca);
            A1287MVCCosto = T001413_A1287MVCCosto[0];
            AssignAttri("", false, "A1287MVCCosto", A1287MVCCosto);
            A1372MVUsuCod = T001413_A1372MVUsuCod[0];
            AssignAttri("", false, "A1372MVUsuCod", A1372MVUsuCod);
            A1373MVUsuFec = T001413_A1373MVUsuFec[0];
            AssignAttri("", false, "A1373MVUsuFec", context.localUtil.TToC( A1373MVUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1271MvAlmDsc = T001413_A1271MvAlmDsc[0];
            AssignAttri("", false, "A1271MvAlmDsc", A1271MvAlmDsc);
            A1269MvAlmCos = T001413_A1269MvAlmCos[0];
            AssignAttri("", false, "A1269MvAlmCos", StringUtil.Str( (decimal)(A1269MvAlmCos), 1, 0));
            A1374MVVouAno = T001413_A1374MVVouAno[0];
            AssignAttri("", false, "A1374MVVouAno", StringUtil.LTrimStr( (decimal)(A1374MVVouAno), 4, 0));
            A1375MVVouMes = T001413_A1375MVVouMes[0];
            AssignAttri("", false, "A1375MVVouMes", StringUtil.LTrimStr( (decimal)(A1375MVVouMes), 2, 0));
            A1371MVTAsiCod = T001413_A1371MVTAsiCod[0];
            AssignAttri("", false, "A1371MVTAsiCod", StringUtil.LTrimStr( (decimal)(A1371MVTAsiCod), 6, 0));
            A1376MVVouNum = T001413_A1376MVVouNum[0];
            AssignAttri("", false, "A1376MVVouNum", A1376MVVouNum);
            A1369MVPoliza = T001413_A1369MVPoliza[0];
            AssignAttri("", false, "A1369MVPoliza", A1369MVPoliza);
            A1279MVARef1 = T001413_A1279MVARef1[0];
            A1280MVARef2 = T001413_A1280MVARef2[0];
            A1281MVARef3 = T001413_A1281MVARef3[0];
            A1282MVARef4 = T001413_A1282MVARef4[0];
            A1283MVARef5 = T001413_A1283MVARef5[0];
            A1246MVACadena = T001413_A1246MVACadena[0];
            A1268MVAGEOBS = T001413_A1268MVAGEOBS[0];
            A1267MVAFecIni = T001413_A1267MVAFecIni[0];
            A10ChoCod = T001413_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            A17EmpTCod = T001413_A17EmpTCod[0];
            n17EmpTCod = T001413_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            A22MvAMov = T001413_A22MvAMov[0];
            AssignAttri("", false, "A22MvAMov", StringUtil.LTrimStr( (decimal)(A22MvAMov), 6, 0));
            A21MvAlm = T001413_A21MvAlm[0];
            AssignAttri("", false, "A21MvAlm", StringUtil.LTrimStr( (decimal)(A21MvAlm), 6, 0));
            A23DocTip = T001413_A23DocTip[0];
            n23DocTip = T001413_n23DocTip[0];
            AssignAttri("", false, "A23DocTip", A23DocTip);
            A20MVPedCod = T001413_A20MVPedCod[0];
            n20MVPedCod = T001413_n20MVPedCod[0];
            AssignAttri("", false, "A20MVPedCod", A20MVPedCod);
            A15MVCliCod = T001413_A15MVCliCod[0];
            n15MVCliCod = T001413_n15MVCliCod[0];
            AssignAttri("", false, "A15MVCliCod", A15MVCliCod);
            A18MVCDesCod = T001413_A18MVCDesCod[0];
            n18MVCDesCod = T001413_n18MVCDesCod[0];
            AssignAttri("", false, "A18MVCDesCod", A18MVCDesCod);
            A24DocNum = T001413_A24DocNum[0];
            n24DocNum = T001413_n24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A16MVCliOrigen = T001413_A16MVCliOrigen[0];
            n16MVCliOrigen = T001413_n16MVCliOrigen[0];
            AssignAttri("", false, "A16MVCliOrigen", StringUtil.LTrimStr( (decimal)(A16MVCliOrigen), 6, 0));
            A19MVCDesItem = T001413_A19MVCDesItem[0];
            n19MVCDesItem = T001413_n19MVCDesItem[0];
            AssignAttri("", false, "A19MVCDesItem", StringUtil.LTrimStr( (decimal)(A19MVCDesItem), 6, 0));
            ZM1438( -3) ;
         }
         pr_default.close(11);
         OnLoadActions1438( ) ;
      }

      protected void OnLoadActions1438( )
      {
      }

      protected void CheckExtendedTable1438( )
      {
         nIsDirty_38 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( (DateTime.MinValue==A25MvAFec) || ( DateTimeUtil.ResetTime ( A25MvAFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Mov. Almacen fuera de rango", "OutOfRange", 1, "MVAFEC");
            AnyError = 1;
            GX_FocusControl = edtMvAFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00146 */
         pr_default.execute(4, new Object[] {A22MvAMov});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Almacen'.", "ForeignKeyNotFound", 1, "MVAMOV");
            AnyError = 1;
            GX_FocusControl = edtMvAMov_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1274MvAMovDsc = T00146_A1274MvAMovDsc[0];
         AssignAttri("", false, "A1274MvAMovDsc", A1274MvAMovDsc);
         A1273MvAMovAut = T00146_A1273MvAMovAut[0];
         AssignAttri("", false, "A1273MvAMovAut", StringUtil.Str( (decimal)(A1273MvAMovAut), 1, 0));
         pr_default.close(4);
         /* Using cursor T00147 */
         pr_default.execute(5, new Object[] {A21MvAlm});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Almacen'.", "ForeignKeyNotFound", 1, "MVALM");
            AnyError = 1;
            GX_FocusControl = edtMvAlm_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1272MVAlmSts = T00147_A1272MVAlmSts[0];
         A1271MvAlmDsc = T00147_A1271MvAlmDsc[0];
         AssignAttri("", false, "A1271MvAlmDsc", A1271MvAlmDsc);
         A1269MvAlmCos = T00147_A1269MvAlmCos[0];
         AssignAttri("", false, "A1269MvAlmCos", StringUtil.Str( (decimal)(A1269MvAlmCos), 1, 0));
         pr_default.close(5);
         /* Using cursor T001410 */
         pr_default.execute(8, new Object[] {n23DocTip, A23DocTip, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A23DocTip)) || String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Salida x Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
               AnyError = 1;
               GX_FocusControl = edtDocTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(8);
         /* Using cursor T00148 */
         pr_default.execute(6, new Object[] {n20MVPedCod, A20MVPedCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A20MVPedCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Despacho Pedido'.", "ForeignKeyNotFound", 1, "MVPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtMVPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(6);
         /* Using cursor T00149 */
         pr_default.execute(7, new Object[] {n15MVCliCod, A15MVCliCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "MVCLICOD");
               AnyError = 1;
               GX_FocusControl = edtMVCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1290MVCliDsc = T00149_A1290MVCliDsc[0];
         AssignAttri("", false, "A1290MVCliDsc", A1290MVCliDsc);
         A1289MVCliDir = T00149_A1289MVCliDir[0];
         AssignAttri("", false, "A1289MVCliDir", A1289MVCliDir);
         pr_default.close(7);
         /* Using cursor T001411 */
         pr_default.execute(9, new Object[] {n15MVCliCod, A15MVCliCod, n16MVCliOrigen, A16MVCliOrigen});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) || (0==A16MVCliOrigen) ) )
            {
               GX_msglist.addItem("No existe 'Cliente Origen'.", "ForeignKeyNotFound", 1, "MVCLIORIGEN");
               AnyError = 1;
               GX_FocusControl = edtMVCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1291MVCliOrigenDir = T001411_A1291MVCliOrigenDir[0];
         AssignAttri("", false, "A1291MVCliOrigenDir", A1291MVCliOrigenDir);
         pr_default.close(9);
         /* Using cursor T00144 */
         pr_default.execute(2, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Transportistas'.", "ForeignKeyNotFound", 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001412 */
         pr_default.execute(10, new Object[] {n18MVCDesCod, A18MVCDesCod, n19MVCDesItem, A19MVCDesItem});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A18MVCDesCod)) || (0==A19MVCDesItem) ) )
            {
               GX_msglist.addItem("No existe 'Sub Remision Destino Item'.", "ForeignKeyNotFound", 1, "MVCDESITEM");
               AnyError = 1;
               GX_FocusControl = edtMVCDesCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(10);
         /* Using cursor T00145 */
         pr_default.execute(3, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A17EmpTCod) ) )
            {
               GX_msglist.addItem("No existe 'Empresa de Transporte'.", "ForeignKeyNotFound", 1, "EMPTCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpTCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         if ( ! ( (DateTime.MinValue==A1373MVUsuFec) || ( A1373MVUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "MVUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtMVUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1438( )
      {
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
         pr_default.close(9);
         pr_default.close(2);
         pr_default.close(10);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( int A22MvAMov )
      {
         /* Using cursor T001414 */
         pr_default.execute(12, new Object[] {A22MvAMov});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Almacen'.", "ForeignKeyNotFound", 1, "MVAMOV");
            AnyError = 1;
            GX_FocusControl = edtMvAMov_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1274MvAMovDsc = T001414_A1274MvAMovDsc[0];
         AssignAttri("", false, "A1274MvAMovDsc", A1274MvAMovDsc);
         A1273MvAMovAut = T001414_A1273MvAMovAut[0];
         AssignAttri("", false, "A1273MvAMovAut", StringUtil.Str( (decimal)(A1273MvAMovAut), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1274MvAMovDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1273MvAMovAut), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void gxLoad_7( int A21MvAlm )
      {
         /* Using cursor T001415 */
         pr_default.execute(13, new Object[] {A21MvAlm});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Almacen'.", "ForeignKeyNotFound", 1, "MVALM");
            AnyError = 1;
            GX_FocusControl = edtMvAlm_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1272MVAlmSts = T001415_A1272MVAlmSts[0];
         A1271MvAlmDsc = T001415_A1271MvAlmDsc[0];
         AssignAttri("", false, "A1271MvAlmDsc", A1271MvAlmDsc);
         A1269MvAlmCos = T001415_A1269MvAlmCos[0];
         AssignAttri("", false, "A1269MvAlmCos", StringUtil.Str( (decimal)(A1269MvAlmCos), 1, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1272MVAlmSts), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1271MvAlmDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A1269MvAlmCos), 1, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_10( string A23DocTip ,
                                string A24DocNum )
      {
         /* Using cursor T001416 */
         pr_default.execute(14, new Object[] {n23DocTip, A23DocTip, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A23DocTip)) || String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Salida x Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
               AnyError = 1;
               GX_FocusControl = edtDocTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(14) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(14);
      }

      protected void gxLoad_8( string A20MVPedCod )
      {
         /* Using cursor T001417 */
         pr_default.execute(15, new Object[] {n20MVPedCod, A20MVPedCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A20MVPedCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Despacho Pedido'.", "ForeignKeyNotFound", 1, "MVPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtMVPedCod_Internalname;
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

      protected void gxLoad_9( string A15MVCliCod )
      {
         /* Using cursor T001418 */
         pr_default.execute(16, new Object[] {n15MVCliCod, A15MVCliCod});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "MVCLICOD");
               AnyError = 1;
               GX_FocusControl = edtMVCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1290MVCliDsc = T001418_A1290MVCliDsc[0];
         AssignAttri("", false, "A1290MVCliDsc", A1290MVCliDsc);
         A1289MVCliDir = T001418_A1289MVCliDir[0];
         AssignAttri("", false, "A1289MVCliDir", A1289MVCliDir);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1290MVCliDsc))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1289MVCliDir))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_11( string A15MVCliCod ,
                                int A16MVCliOrigen )
      {
         /* Using cursor T001419 */
         pr_default.execute(17, new Object[] {n15MVCliCod, A15MVCliCod, n16MVCliOrigen, A16MVCliOrigen});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) || (0==A16MVCliOrigen) ) )
            {
               GX_msglist.addItem("No existe 'Cliente Origen'.", "ForeignKeyNotFound", 1, "MVCLIORIGEN");
               AnyError = 1;
               GX_FocusControl = edtMVCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1291MVCliOrigenDir = T001419_A1291MVCliOrigenDir[0];
         AssignAttri("", false, "A1291MVCliOrigenDir", A1291MVCliOrigenDir);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1291MVCliOrigenDir))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_4( int A10ChoCod )
      {
         /* Using cursor T001420 */
         pr_default.execute(18, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(18) == 101) )
         {
            GX_msglist.addItem("No existe 'Transportistas'.", "ForeignKeyNotFound", 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
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

      protected void gxLoad_12( string A18MVCDesCod ,
                                int A19MVCDesItem )
      {
         /* Using cursor T001421 */
         pr_default.execute(19, new Object[] {n18MVCDesCod, A18MVCDesCod, n19MVCDesItem, A19MVCDesItem});
         if ( (pr_default.getStatus(19) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A18MVCDesCod)) || (0==A19MVCDesItem) ) )
            {
               GX_msglist.addItem("No existe 'Sub Remision Destino Item'.", "ForeignKeyNotFound", 1, "MVCDESITEM");
               AnyError = 1;
               GX_FocusControl = edtMVCDesCod_Internalname;
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

      protected void gxLoad_5( int A17EmpTCod )
      {
         /* Using cursor T001422 */
         pr_default.execute(20, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( (0==A17EmpTCod) ) )
            {
               GX_msglist.addItem("No existe 'Empresa de Transporte'.", "ForeignKeyNotFound", 1, "EMPTCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpTCod_Internalname;
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

      protected void GetKey1438( )
      {
         /* Using cursor T001423 */
         pr_default.execute(21, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(21);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00143 */
         pr_default.execute(1, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1438( 3) ;
            RcdFound38 = 1;
            A13MvATip = T00143_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T00143_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
            A25MvAFec = T00143_A25MvAFec[0];
            AssignAttri("", false, "A25MvAFec", context.localUtil.Format(A25MvAFec, "99/99/99"));
            A1276MvAOcom = T00143_A1276MvAOcom[0];
            AssignAttri("", false, "A1276MvAOcom", A1276MvAOcom);
            A1278MvARef = T00143_A1278MvARef[0];
            AssignAttri("", false, "A1278MvARef", A1278MvARef);
            A1286MvATMov = T00143_A1286MvATMov[0];
            AssignAttri("", false, "A1286MvATMov", StringUtil.Str( (decimal)(A1286MvATMov), 1, 0));
            A1275MvAObs = T00143_A1275MvAObs[0];
            AssignAttri("", false, "A1275MvAObs", A1275MvAObs);
            A1370MVSts = T00143_A1370MVSts[0];
            AssignAttri("", false, "A1370MVSts", A1370MVSts);
            A1285MvATItem = T00143_A1285MvATItem[0];
            AssignAttri("", false, "A1285MvATItem", StringUtil.LTrimStr( (decimal)(A1285MvATItem), 6, 0));
            A1284MVATipo = T00143_A1284MVATipo[0];
            AssignAttri("", false, "A1284MVATipo", A1284MVATipo);
            A1270MVAlmDestino = T00143_A1270MVAlmDestino[0];
            AssignAttri("", false, "A1270MVAlmDestino", StringUtil.LTrimStr( (decimal)(A1270MVAlmDestino), 6, 0));
            A1277MVAPlaca = T00143_A1277MVAPlaca[0];
            AssignAttri("", false, "A1277MVAPlaca", A1277MVAPlaca);
            A1287MVCCosto = T00143_A1287MVCCosto[0];
            AssignAttri("", false, "A1287MVCCosto", A1287MVCCosto);
            A1372MVUsuCod = T00143_A1372MVUsuCod[0];
            AssignAttri("", false, "A1372MVUsuCod", A1372MVUsuCod);
            A1373MVUsuFec = T00143_A1373MVUsuFec[0];
            AssignAttri("", false, "A1373MVUsuFec", context.localUtil.TToC( A1373MVUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1374MVVouAno = T00143_A1374MVVouAno[0];
            AssignAttri("", false, "A1374MVVouAno", StringUtil.LTrimStr( (decimal)(A1374MVVouAno), 4, 0));
            A1375MVVouMes = T00143_A1375MVVouMes[0];
            AssignAttri("", false, "A1375MVVouMes", StringUtil.LTrimStr( (decimal)(A1375MVVouMes), 2, 0));
            A1371MVTAsiCod = T00143_A1371MVTAsiCod[0];
            AssignAttri("", false, "A1371MVTAsiCod", StringUtil.LTrimStr( (decimal)(A1371MVTAsiCod), 6, 0));
            A1376MVVouNum = T00143_A1376MVVouNum[0];
            AssignAttri("", false, "A1376MVVouNum", A1376MVVouNum);
            A1369MVPoliza = T00143_A1369MVPoliza[0];
            AssignAttri("", false, "A1369MVPoliza", A1369MVPoliza);
            A1279MVARef1 = T00143_A1279MVARef1[0];
            A1280MVARef2 = T00143_A1280MVARef2[0];
            A1281MVARef3 = T00143_A1281MVARef3[0];
            A1282MVARef4 = T00143_A1282MVARef4[0];
            A1283MVARef5 = T00143_A1283MVARef5[0];
            A1246MVACadena = T00143_A1246MVACadena[0];
            A1268MVAGEOBS = T00143_A1268MVAGEOBS[0];
            A1267MVAFecIni = T00143_A1267MVAFecIni[0];
            A10ChoCod = T00143_A10ChoCod[0];
            AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
            A17EmpTCod = T00143_A17EmpTCod[0];
            n17EmpTCod = T00143_n17EmpTCod[0];
            AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
            A22MvAMov = T00143_A22MvAMov[0];
            AssignAttri("", false, "A22MvAMov", StringUtil.LTrimStr( (decimal)(A22MvAMov), 6, 0));
            A21MvAlm = T00143_A21MvAlm[0];
            AssignAttri("", false, "A21MvAlm", StringUtil.LTrimStr( (decimal)(A21MvAlm), 6, 0));
            A23DocTip = T00143_A23DocTip[0];
            n23DocTip = T00143_n23DocTip[0];
            AssignAttri("", false, "A23DocTip", A23DocTip);
            A20MVPedCod = T00143_A20MVPedCod[0];
            n20MVPedCod = T00143_n20MVPedCod[0];
            AssignAttri("", false, "A20MVPedCod", A20MVPedCod);
            A15MVCliCod = T00143_A15MVCliCod[0];
            n15MVCliCod = T00143_n15MVCliCod[0];
            AssignAttri("", false, "A15MVCliCod", A15MVCliCod);
            A18MVCDesCod = T00143_A18MVCDesCod[0];
            n18MVCDesCod = T00143_n18MVCDesCod[0];
            AssignAttri("", false, "A18MVCDesCod", A18MVCDesCod);
            A24DocNum = T00143_A24DocNum[0];
            n24DocNum = T00143_n24DocNum[0];
            AssignAttri("", false, "A24DocNum", A24DocNum);
            A16MVCliOrigen = T00143_A16MVCliOrigen[0];
            n16MVCliOrigen = T00143_n16MVCliOrigen[0];
            AssignAttri("", false, "A16MVCliOrigen", StringUtil.LTrimStr( (decimal)(A16MVCliOrigen), 6, 0));
            A19MVCDesItem = T00143_A19MVCDesItem[0];
            n19MVCDesItem = T00143_n19MVCDesItem[0];
            AssignAttri("", false, "A19MVCDesItem", StringUtil.LTrimStr( (decimal)(A19MVCDesItem), 6, 0));
            Z13MvATip = A13MvATip;
            Z14MvACod = A14MvACod;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1438( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey1438( ) ;
            }
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey1438( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1438( ) ;
         if ( RcdFound38 == 0 )
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
         RcdFound38 = 0;
         /* Using cursor T001424 */
         pr_default.execute(22, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(22) != 101) )
         {
            while ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T001424_A13MvATip[0], A13MvATip) < 0 ) || ( StringUtil.StrCmp(T001424_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T001424_A14MvACod[0], A14MvACod) < 0 ) ) )
            {
               pr_default.readNext(22);
            }
            if ( (pr_default.getStatus(22) != 101) && ( ( StringUtil.StrCmp(T001424_A13MvATip[0], A13MvATip) > 0 ) || ( StringUtil.StrCmp(T001424_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T001424_A14MvACod[0], A14MvACod) > 0 ) ) )
            {
               A13MvATip = T001424_A13MvATip[0];
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = T001424_A14MvACod[0];
               AssignAttri("", false, "A14MvACod", A14MvACod);
               RcdFound38 = 1;
            }
         }
         pr_default.close(22);
      }

      protected void move_previous( )
      {
         RcdFound38 = 0;
         /* Using cursor T001425 */
         pr_default.execute(23, new Object[] {A13MvATip, A14MvACod});
         if ( (pr_default.getStatus(23) != 101) )
         {
            while ( (pr_default.getStatus(23) != 101) && ( ( StringUtil.StrCmp(T001425_A13MvATip[0], A13MvATip) > 0 ) || ( StringUtil.StrCmp(T001425_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T001425_A14MvACod[0], A14MvACod) > 0 ) ) )
            {
               pr_default.readNext(23);
            }
            if ( (pr_default.getStatus(23) != 101) && ( ( StringUtil.StrCmp(T001425_A13MvATip[0], A13MvATip) < 0 ) || ( StringUtil.StrCmp(T001425_A13MvATip[0], A13MvATip) == 0 ) && ( StringUtil.StrCmp(T001425_A14MvACod[0], A14MvACod) < 0 ) ) )
            {
               A13MvATip = T001425_A13MvATip[0];
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = T001425_A14MvACod[0];
               AssignAttri("", false, "A14MvACod", A14MvACod);
               RcdFound38 = 1;
            }
         }
         pr_default.close(23);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1438( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1438( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) )
               {
                  A13MvATip = Z13MvATip;
                  AssignAttri("", false, "A13MvATip", A13MvATip);
                  A14MvACod = Z14MvACod;
                  AssignAttri("", false, "A14MvACod", A14MvACod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1438( ) ;
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtMvATip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1438( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MVATIP");
                     AnyError = 1;
                     GX_FocusControl = edtMvATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtMvATip_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1438( ) ;
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
         if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) )
         {
            A13MvATip = Z13MvATip;
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = Z14MvACod;
            AssignAttri("", false, "A14MvACod", A14MvACod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MVATIP");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMvATip_Internalname;
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
         GetKey1438( ) ;
         if ( RcdFound38 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "MVATIP");
               AnyError = 1;
               GX_FocusControl = edtMvATip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) )
            {
               A13MvATip = Z13MvATip;
               AssignAttri("", false, "A13MvATip", A13MvATip);
               A14MvACod = Z14MvACod;
               AssignAttri("", false, "A14MvACod", A14MvACod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "MVATIP");
               AnyError = 1;
               GX_FocusControl = edtMvATip_Internalname;
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
            if ( ( StringUtil.StrCmp(A13MvATip, Z13MvATip) != 0 ) || ( StringUtil.StrCmp(A14MvACod, Z14MvACod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MVATIP");
                  AnyError = 1;
                  GX_FocusControl = edtMvATip_Internalname;
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
         context.RollbackDataStores("aguias",pr_default);
         GX_FocusControl = edtMvAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_140( ) ;
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
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "MVATIP");
            AnyError = 1;
            GX_FocusControl = edtMvATip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtMvAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1438( ) ;
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1438( ) ;
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
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvAFec_Internalname;
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
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvAFec_Internalname;
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
         ScanStart1438( ) ;
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound38 != 0 )
            {
               ScanNext1438( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtMvAFec_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1438( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1438( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00142 */
            pr_default.execute(0, new Object[] {A13MvATip, A14MvACod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( DateTimeUtil.ResetTime ( Z25MvAFec ) != DateTimeUtil.ResetTime ( T00142_A25MvAFec[0] ) ) || ( StringUtil.StrCmp(Z1276MvAOcom, T00142_A1276MvAOcom[0]) != 0 ) || ( StringUtil.StrCmp(Z1278MvARef, T00142_A1278MvARef[0]) != 0 ) || ( Z1286MvATMov != T00142_A1286MvATMov[0] ) || ( StringUtil.StrCmp(Z1370MVSts, T00142_A1370MVSts[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1285MvATItem != T00142_A1285MvATItem[0] ) || ( StringUtil.StrCmp(Z1284MVATipo, T00142_A1284MVATipo[0]) != 0 ) || ( Z1270MVAlmDestino != T00142_A1270MVAlmDestino[0] ) || ( StringUtil.StrCmp(Z1277MVAPlaca, T00142_A1277MVAPlaca[0]) != 0 ) || ( StringUtil.StrCmp(Z1287MVCCosto, T00142_A1287MVCCosto[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1372MVUsuCod, T00142_A1372MVUsuCod[0]) != 0 ) || ( Z1373MVUsuFec != T00142_A1373MVUsuFec[0] ) || ( Z1374MVVouAno != T00142_A1374MVVouAno[0] ) || ( Z1375MVVouMes != T00142_A1375MVVouMes[0] ) || ( Z1371MVTAsiCod != T00142_A1371MVTAsiCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1376MVVouNum, T00142_A1376MVVouNum[0]) != 0 ) || ( StringUtil.StrCmp(Z1369MVPoliza, T00142_A1369MVPoliza[0]) != 0 ) || ( StringUtil.StrCmp(Z1279MVARef1, T00142_A1279MVARef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1280MVARef2, T00142_A1280MVARef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1281MVARef3, T00142_A1281MVARef3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1282MVARef4, T00142_A1282MVARef4[0]) != 0 ) || ( StringUtil.StrCmp(Z1283MVARef5, T00142_A1283MVARef5[0]) != 0 ) || ( StringUtil.StrCmp(Z1246MVACadena, T00142_A1246MVACadena[0]) != 0 ) || ( StringUtil.StrCmp(Z1268MVAGEOBS, T00142_A1268MVAGEOBS[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z1267MVAFecIni ) != DateTimeUtil.ResetTime ( T00142_A1267MVAFecIni[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z10ChoCod != T00142_A10ChoCod[0] ) || ( Z17EmpTCod != T00142_A17EmpTCod[0] ) || ( Z22MvAMov != T00142_A22MvAMov[0] ) || ( Z21MvAlm != T00142_A21MvAlm[0] ) || ( StringUtil.StrCmp(Z23DocTip, T00142_A23DocTip[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z20MVPedCod, T00142_A20MVPedCod[0]) != 0 ) || ( StringUtil.StrCmp(Z15MVCliCod, T00142_A15MVCliCod[0]) != 0 ) || ( StringUtil.StrCmp(Z18MVCDesCod, T00142_A18MVCDesCod[0]) != 0 ) || ( StringUtil.StrCmp(Z24DocNum, T00142_A24DocNum[0]) != 0 ) || ( Z16MVCliOrigen != T00142_A16MVCliOrigen[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z19MVCDesItem != T00142_A19MVCDesItem[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z25MvAFec ) != DateTimeUtil.ResetTime ( T00142_A25MvAFec[0] ) )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MvAFec");
                  GXUtil.WriteLogRaw("Old: ",Z25MvAFec);
                  GXUtil.WriteLogRaw("Current: ",T00142_A25MvAFec[0]);
               }
               if ( StringUtil.StrCmp(Z1276MvAOcom, T00142_A1276MvAOcom[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MvAOcom");
                  GXUtil.WriteLogRaw("Old: ",Z1276MvAOcom);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1276MvAOcom[0]);
               }
               if ( StringUtil.StrCmp(Z1278MvARef, T00142_A1278MvARef[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MvARef");
                  GXUtil.WriteLogRaw("Old: ",Z1278MvARef);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1278MvARef[0]);
               }
               if ( Z1286MvATMov != T00142_A1286MvATMov[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MvATMov");
                  GXUtil.WriteLogRaw("Old: ",Z1286MvATMov);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1286MvATMov[0]);
               }
               if ( StringUtil.StrCmp(Z1370MVSts, T00142_A1370MVSts[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVSts");
                  GXUtil.WriteLogRaw("Old: ",Z1370MVSts);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1370MVSts[0]);
               }
               if ( Z1285MvATItem != T00142_A1285MvATItem[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MvATItem");
                  GXUtil.WriteLogRaw("Old: ",Z1285MvATItem);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1285MvATItem[0]);
               }
               if ( StringUtil.StrCmp(Z1284MVATipo, T00142_A1284MVATipo[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVATipo");
                  GXUtil.WriteLogRaw("Old: ",Z1284MVATipo);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1284MVATipo[0]);
               }
               if ( Z1270MVAlmDestino != T00142_A1270MVAlmDestino[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVAlmDestino");
                  GXUtil.WriteLogRaw("Old: ",Z1270MVAlmDestino);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1270MVAlmDestino[0]);
               }
               if ( StringUtil.StrCmp(Z1277MVAPlaca, T00142_A1277MVAPlaca[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVAPlaca");
                  GXUtil.WriteLogRaw("Old: ",Z1277MVAPlaca);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1277MVAPlaca[0]);
               }
               if ( StringUtil.StrCmp(Z1287MVCCosto, T00142_A1287MVCCosto[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVCCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1287MVCCosto);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1287MVCCosto[0]);
               }
               if ( StringUtil.StrCmp(Z1372MVUsuCod, T00142_A1372MVUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1372MVUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1372MVUsuCod[0]);
               }
               if ( Z1373MVUsuFec != T00142_A1373MVUsuFec[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1373MVUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1373MVUsuFec[0]);
               }
               if ( Z1374MVVouAno != T00142_A1374MVVouAno[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVVouAno");
                  GXUtil.WriteLogRaw("Old: ",Z1374MVVouAno);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1374MVVouAno[0]);
               }
               if ( Z1375MVVouMes != T00142_A1375MVVouMes[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVVouMes");
                  GXUtil.WriteLogRaw("Old: ",Z1375MVVouMes);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1375MVVouMes[0]);
               }
               if ( Z1371MVTAsiCod != T00142_A1371MVTAsiCod[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVTAsiCod");
                  GXUtil.WriteLogRaw("Old: ",Z1371MVTAsiCod);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1371MVTAsiCod[0]);
               }
               if ( StringUtil.StrCmp(Z1376MVVouNum, T00142_A1376MVVouNum[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVVouNum");
                  GXUtil.WriteLogRaw("Old: ",Z1376MVVouNum);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1376MVVouNum[0]);
               }
               if ( StringUtil.StrCmp(Z1369MVPoliza, T00142_A1369MVPoliza[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVPoliza");
                  GXUtil.WriteLogRaw("Old: ",Z1369MVPoliza);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1369MVPoliza[0]);
               }
               if ( StringUtil.StrCmp(Z1279MVARef1, T00142_A1279MVARef1[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVARef1");
                  GXUtil.WriteLogRaw("Old: ",Z1279MVARef1);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1279MVARef1[0]);
               }
               if ( StringUtil.StrCmp(Z1280MVARef2, T00142_A1280MVARef2[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVARef2");
                  GXUtil.WriteLogRaw("Old: ",Z1280MVARef2);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1280MVARef2[0]);
               }
               if ( StringUtil.StrCmp(Z1281MVARef3, T00142_A1281MVARef3[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVARef3");
                  GXUtil.WriteLogRaw("Old: ",Z1281MVARef3);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1281MVARef3[0]);
               }
               if ( StringUtil.StrCmp(Z1282MVARef4, T00142_A1282MVARef4[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVARef4");
                  GXUtil.WriteLogRaw("Old: ",Z1282MVARef4);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1282MVARef4[0]);
               }
               if ( StringUtil.StrCmp(Z1283MVARef5, T00142_A1283MVARef5[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVARef5");
                  GXUtil.WriteLogRaw("Old: ",Z1283MVARef5);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1283MVARef5[0]);
               }
               if ( StringUtil.StrCmp(Z1246MVACadena, T00142_A1246MVACadena[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVACadena");
                  GXUtil.WriteLogRaw("Old: ",Z1246MVACadena);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1246MVACadena[0]);
               }
               if ( StringUtil.StrCmp(Z1268MVAGEOBS, T00142_A1268MVAGEOBS[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVAGEOBS");
                  GXUtil.WriteLogRaw("Old: ",Z1268MVAGEOBS);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1268MVAGEOBS[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1267MVAFecIni ) != DateTimeUtil.ResetTime ( T00142_A1267MVAFecIni[0] ) )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVAFecIni");
                  GXUtil.WriteLogRaw("Old: ",Z1267MVAFecIni);
                  GXUtil.WriteLogRaw("Current: ",T00142_A1267MVAFecIni[0]);
               }
               if ( Z10ChoCod != T00142_A10ChoCod[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"ChoCod");
                  GXUtil.WriteLogRaw("Old: ",Z10ChoCod);
                  GXUtil.WriteLogRaw("Current: ",T00142_A10ChoCod[0]);
               }
               if ( Z17EmpTCod != T00142_A17EmpTCod[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"EmpTCod");
                  GXUtil.WriteLogRaw("Old: ",Z17EmpTCod);
                  GXUtil.WriteLogRaw("Current: ",T00142_A17EmpTCod[0]);
               }
               if ( Z22MvAMov != T00142_A22MvAMov[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MvAMov");
                  GXUtil.WriteLogRaw("Old: ",Z22MvAMov);
                  GXUtil.WriteLogRaw("Current: ",T00142_A22MvAMov[0]);
               }
               if ( Z21MvAlm != T00142_A21MvAlm[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MvAlm");
                  GXUtil.WriteLogRaw("Old: ",Z21MvAlm);
                  GXUtil.WriteLogRaw("Current: ",T00142_A21MvAlm[0]);
               }
               if ( StringUtil.StrCmp(Z23DocTip, T00142_A23DocTip[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"DocTip");
                  GXUtil.WriteLogRaw("Old: ",Z23DocTip);
                  GXUtil.WriteLogRaw("Current: ",T00142_A23DocTip[0]);
               }
               if ( StringUtil.StrCmp(Z20MVPedCod, T00142_A20MVPedCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVPedCod");
                  GXUtil.WriteLogRaw("Old: ",Z20MVPedCod);
                  GXUtil.WriteLogRaw("Current: ",T00142_A20MVPedCod[0]);
               }
               if ( StringUtil.StrCmp(Z15MVCliCod, T00142_A15MVCliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVCliCod");
                  GXUtil.WriteLogRaw("Old: ",Z15MVCliCod);
                  GXUtil.WriteLogRaw("Current: ",T00142_A15MVCliCod[0]);
               }
               if ( StringUtil.StrCmp(Z18MVCDesCod, T00142_A18MVCDesCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVCDesCod");
                  GXUtil.WriteLogRaw("Old: ",Z18MVCDesCod);
                  GXUtil.WriteLogRaw("Current: ",T00142_A18MVCDesCod[0]);
               }
               if ( StringUtil.StrCmp(Z24DocNum, T00142_A24DocNum[0]) != 0 )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"DocNum");
                  GXUtil.WriteLogRaw("Old: ",Z24DocNum);
                  GXUtil.WriteLogRaw("Current: ",T00142_A24DocNum[0]);
               }
               if ( Z16MVCliOrigen != T00142_A16MVCliOrigen[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVCliOrigen");
                  GXUtil.WriteLogRaw("Old: ",Z16MVCliOrigen);
                  GXUtil.WriteLogRaw("Current: ",T00142_A16MVCliOrigen[0]);
               }
               if ( Z19MVCDesItem != T00142_A19MVCDesItem[0] )
               {
                  GXUtil.WriteLog("aguias:[seudo value changed for attri]"+"MVCDesItem");
                  GXUtil.WriteLogRaw("Old: ",Z19MVCDesItem);
                  GXUtil.WriteLogRaw("Current: ",T00142_A19MVCDesItem[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AGUIAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1438( )
      {
         BeforeValidate1438( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1438( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1438( 0) ;
            CheckOptimisticConcurrency1438( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1438( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1438( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001426 */
                     pr_default.execute(24, new Object[] {A13MvATip, A14MvACod, A25MvAFec, A1276MvAOcom, A1278MvARef, A1286MvATMov, A1275MvAObs, A1370MVSts, A1285MvATItem, A1284MVATipo, A1270MVAlmDestino, A1277MVAPlaca, A1287MVCCosto, A1372MVUsuCod, A1373MVUsuFec, A1374MVVouAno, A1375MVVouMes, A1371MVTAsiCod, A1376MVVouNum, A1369MVPoliza, A1279MVARef1, A1280MVARef2, A1281MVARef3, A1282MVARef4, A1283MVARef5, A1246MVACadena, A1268MVAGEOBS, A1267MVAFecIni, A10ChoCod, n17EmpTCod, A17EmpTCod, A22MvAMov, A21MvAlm, n23DocTip, A23DocTip, n20MVPedCod, A20MVPedCod, n15MVCliCod, A15MVCliCod, n18MVCDesCod, A18MVCDesCod, n24DocNum, A24DocNum, n16MVCliOrigen, A16MVCliOrigen, n19MVCDesItem, A19MVCDesItem});
                     pr_default.close(24);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIAS");
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
                           ResetCaption140( ) ;
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
               Load1438( ) ;
            }
            EndLevel1438( ) ;
         }
         CloseExtendedTableCursors1438( ) ;
      }

      protected void Update1438( )
      {
         BeforeValidate1438( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1438( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1438( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1438( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1438( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001427 */
                     pr_default.execute(25, new Object[] {A25MvAFec, A1276MvAOcom, A1278MvARef, A1286MvATMov, A1275MvAObs, A1370MVSts, A1285MvATItem, A1284MVATipo, A1270MVAlmDestino, A1277MVAPlaca, A1287MVCCosto, A1372MVUsuCod, A1373MVUsuFec, A1374MVVouAno, A1375MVVouMes, A1371MVTAsiCod, A1376MVVouNum, A1369MVPoliza, A1279MVARef1, A1280MVARef2, A1281MVARef3, A1282MVARef4, A1283MVARef5, A1246MVACadena, A1268MVAGEOBS, A1267MVAFecIni, A10ChoCod, n17EmpTCod, A17EmpTCod, A22MvAMov, A21MvAlm, n23DocTip, A23DocTip, n20MVPedCod, A20MVPedCod, n15MVCliCod, A15MVCliCod, n18MVCDesCod, A18MVCDesCod, n24DocNum, A24DocNum, n16MVCliOrigen, A16MVCliOrigen, n19MVCDesItem, A19MVCDesItem, A13MvATip, A14MvACod});
                     pr_default.close(25);
                     dsDefault.SmartCacheProvider.SetUpdated("AGUIAS");
                     if ( (pr_default.getStatus(25) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AGUIAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1438( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption140( ) ;
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
            EndLevel1438( ) ;
         }
         CloseExtendedTableCursors1438( ) ;
      }

      protected void DeferredUpdate1438( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1438( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1438( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1438( ) ;
            AfterConfirm1438( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1438( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001428 */
                  pr_default.execute(26, new Object[] {A13MvATip, A14MvACod});
                  pr_default.close(26);
                  dsDefault.SmartCacheProvider.SetUpdated("AGUIAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound38 == 0 )
                        {
                           InitAll1438( ) ;
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
                        ResetCaption140( ) ;
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1438( ) ;
         Gx_mode = sMode38;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1438( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001429 */
            pr_default.execute(27, new Object[] {A22MvAMov});
            A1274MvAMovDsc = T001429_A1274MvAMovDsc[0];
            AssignAttri("", false, "A1274MvAMovDsc", A1274MvAMovDsc);
            A1273MvAMovAut = T001429_A1273MvAMovAut[0];
            AssignAttri("", false, "A1273MvAMovAut", StringUtil.Str( (decimal)(A1273MvAMovAut), 1, 0));
            pr_default.close(27);
            /* Using cursor T001430 */
            pr_default.execute(28, new Object[] {A21MvAlm});
            A1272MVAlmSts = T001430_A1272MVAlmSts[0];
            A1271MvAlmDsc = T001430_A1271MvAlmDsc[0];
            AssignAttri("", false, "A1271MvAlmDsc", A1271MvAlmDsc);
            A1269MvAlmCos = T001430_A1269MvAlmCos[0];
            AssignAttri("", false, "A1269MvAlmCos", StringUtil.Str( (decimal)(A1269MvAlmCos), 1, 0));
            pr_default.close(28);
            /* Using cursor T001431 */
            pr_default.execute(29, new Object[] {n15MVCliCod, A15MVCliCod});
            A1290MVCliDsc = T001431_A1290MVCliDsc[0];
            AssignAttri("", false, "A1290MVCliDsc", A1290MVCliDsc);
            A1289MVCliDir = T001431_A1289MVCliDir[0];
            AssignAttri("", false, "A1289MVCliDir", A1289MVCliDir);
            pr_default.close(29);
            /* Using cursor T001432 */
            pr_default.execute(30, new Object[] {n15MVCliCod, A15MVCliCod, n16MVCliOrigen, A16MVCliOrigen});
            A1291MVCliOrigenDir = T001432_A1291MVCliOrigenDir[0];
            AssignAttri("", false, "A1291MVCliOrigenDir", A1291MVCliOrigenDir);
            pr_default.close(30);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001433 */
            pr_default.execute(31, new Object[] {A13MvATip, A14MvACod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Transferencia Entre Almacenes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T001434 */
            pr_default.execute(32, new Object[] {A13MvATip, A14MvACod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov Almacen Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T001435 */
            pr_default.execute(33, new Object[] {A13MvATip, A14MvACod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Despacho Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
         }
      }

      protected void EndLevel1438( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1438( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(27);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(30);
            context.CommitDataStores("aguias",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues140( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(27);
            pr_default.close(28);
            pr_default.close(29);
            pr_default.close(30);
            context.RollbackDataStores("aguias",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1438( )
      {
         /* Using cursor T001436 */
         pr_default.execute(34);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound38 = 1;
            A13MvATip = T001436_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T001436_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1438( )
      {
         /* Scan next routine */
         pr_default.readNext(34);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(34) != 101) )
         {
            RcdFound38 = 1;
            A13MvATip = T001436_A13MvATip[0];
            AssignAttri("", false, "A13MvATip", A13MvATip);
            A14MvACod = T001436_A14MvACod[0];
            AssignAttri("", false, "A14MvACod", A14MvACod);
         }
      }

      protected void ScanEnd1438( )
      {
         pr_default.close(34);
      }

      protected void AfterConfirm1438( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1438( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1438( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1438( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1438( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1438( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1438( )
      {
         edtMvATip_Enabled = 0;
         AssignProp("", false, edtMvATip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvATip_Enabled), 5, 0), true);
         edtMvACod_Enabled = 0;
         AssignProp("", false, edtMvACod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvACod_Enabled), 5, 0), true);
         edtMvAFec_Enabled = 0;
         AssignProp("", false, edtMvAFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAFec_Enabled), 5, 0), true);
         edtMvAOcom_Enabled = 0;
         AssignProp("", false, edtMvAOcom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAOcom_Enabled), 5, 0), true);
         edtMvARef_Enabled = 0;
         AssignProp("", false, edtMvARef_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvARef_Enabled), 5, 0), true);
         edtMvATMov_Enabled = 0;
         AssignProp("", false, edtMvATMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvATMov_Enabled), 5, 0), true);
         edtMvAMov_Enabled = 0;
         AssignProp("", false, edtMvAMov_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAMov_Enabled), 5, 0), true);
         edtMvAMovDsc_Enabled = 0;
         AssignProp("", false, edtMvAMovDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAMovDsc_Enabled), 5, 0), true);
         edtMvAMovAut_Enabled = 0;
         AssignProp("", false, edtMvAMovAut_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAMovAut_Enabled), 5, 0), true);
         edtMvAlm_Enabled = 0;
         AssignProp("", false, edtMvAlm_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAlm_Enabled), 5, 0), true);
         edtMvAObs_Enabled = 0;
         AssignProp("", false, edtMvAObs_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAObs_Enabled), 5, 0), true);
         edtDocTip_Enabled = 0;
         AssignProp("", false, edtDocTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTip_Enabled), 5, 0), true);
         edtDocNum_Enabled = 0;
         AssignProp("", false, edtDocNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNum_Enabled), 5, 0), true);
         edtMVSts_Enabled = 0;
         AssignProp("", false, edtMVSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVSts_Enabled), 5, 0), true);
         edtMVPedCod_Enabled = 0;
         AssignProp("", false, edtMVPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVPedCod_Enabled), 5, 0), true);
         edtMvATItem_Enabled = 0;
         AssignProp("", false, edtMvATItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvATItem_Enabled), 5, 0), true);
         edtMVCliCod_Enabled = 0;
         AssignProp("", false, edtMVCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCliCod_Enabled), 5, 0), true);
         edtMVCliDsc_Enabled = 0;
         AssignProp("", false, edtMVCliDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCliDsc_Enabled), 5, 0), true);
         edtMVCliDir_Enabled = 0;
         AssignProp("", false, edtMVCliDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCliDir_Enabled), 5, 0), true);
         edtMVCliOrigen_Enabled = 0;
         AssignProp("", false, edtMVCliOrigen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCliOrigen_Enabled), 5, 0), true);
         edtMVCliOrigenDir_Enabled = 0;
         AssignProp("", false, edtMVCliOrigenDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCliOrigenDir_Enabled), 5, 0), true);
         edtChoCod_Enabled = 0;
         AssignProp("", false, edtChoCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtChoCod_Enabled), 5, 0), true);
         edtMVATipo_Enabled = 0;
         AssignProp("", false, edtMVATipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVATipo_Enabled), 5, 0), true);
         edtMVAlmDestino_Enabled = 0;
         AssignProp("", false, edtMVAlmDestino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVAlmDestino_Enabled), 5, 0), true);
         edtMVAPlaca_Enabled = 0;
         AssignProp("", false, edtMVAPlaca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVAPlaca_Enabled), 5, 0), true);
         edtMVCCosto_Enabled = 0;
         AssignProp("", false, edtMVCCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCCosto_Enabled), 5, 0), true);
         edtMVCDesCod_Enabled = 0;
         AssignProp("", false, edtMVCDesCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCDesCod_Enabled), 5, 0), true);
         edtMVCDesItem_Enabled = 0;
         AssignProp("", false, edtMVCDesItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVCDesItem_Enabled), 5, 0), true);
         edtEmpTCod_Enabled = 0;
         AssignProp("", false, edtEmpTCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtEmpTCod_Enabled), 5, 0), true);
         edtMVUsuCod_Enabled = 0;
         AssignProp("", false, edtMVUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVUsuCod_Enabled), 5, 0), true);
         edtMVUsuFec_Enabled = 0;
         AssignProp("", false, edtMVUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVUsuFec_Enabled), 5, 0), true);
         edtMvAlmDsc_Enabled = 0;
         AssignProp("", false, edtMvAlmDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAlmDsc_Enabled), 5, 0), true);
         edtMvAlmCos_Enabled = 0;
         AssignProp("", false, edtMvAlmCos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMvAlmCos_Enabled), 5, 0), true);
         edtMVVouAno_Enabled = 0;
         AssignProp("", false, edtMVVouAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVVouAno_Enabled), 5, 0), true);
         edtMVVouMes_Enabled = 0;
         AssignProp("", false, edtMVVouMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVVouMes_Enabled), 5, 0), true);
         edtMVTAsiCod_Enabled = 0;
         AssignProp("", false, edtMVTAsiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVTAsiCod_Enabled), 5, 0), true);
         edtMVVouNum_Enabled = 0;
         AssignProp("", false, edtMVVouNum_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVVouNum_Enabled), 5, 0), true);
         edtMVPoliza_Enabled = 0;
         AssignProp("", false, edtMVPoliza_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMVPoliza_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1438( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues140( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181146486", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aguias.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"AGUIAS");
         forbiddenHiddens.Add("MVARef1", StringUtil.RTrim( context.localUtil.Format( A1279MVARef1, "")));
         forbiddenHiddens.Add("MVARef2", StringUtil.RTrim( context.localUtil.Format( A1280MVARef2, "")));
         forbiddenHiddens.Add("MVARef3", StringUtil.RTrim( context.localUtil.Format( A1281MVARef3, "")));
         forbiddenHiddens.Add("MVARef4", StringUtil.RTrim( context.localUtil.Format( A1282MVARef4, "")));
         forbiddenHiddens.Add("MVARef5", StringUtil.RTrim( context.localUtil.Format( A1283MVARef5, "")));
         forbiddenHiddens.Add("MVACadena", StringUtil.RTrim( context.localUtil.Format( A1246MVACadena, "")));
         forbiddenHiddens.Add("MVAGEOBS", StringUtil.RTrim( context.localUtil.Format( A1268MVAGEOBS, "")));
         forbiddenHiddens.Add("MVAFecIni", context.localUtil.Format(A1267MVAFecIni, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("aguias:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z13MvATip", StringUtil.RTrim( Z13MvATip));
         GxWebStd.gx_hidden_field( context, "Z14MvACod", StringUtil.RTrim( Z14MvACod));
         GxWebStd.gx_hidden_field( context, "Z25MvAFec", context.localUtil.DToC( Z25MvAFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1276MvAOcom", StringUtil.RTrim( Z1276MvAOcom));
         GxWebStd.gx_hidden_field( context, "Z1278MvARef", StringUtil.RTrim( Z1278MvARef));
         GxWebStd.gx_hidden_field( context, "Z1286MvATMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1286MvATMov), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1370MVSts", StringUtil.RTrim( Z1370MVSts));
         GxWebStd.gx_hidden_field( context, "Z1285MvATItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1285MvATItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1284MVATipo", StringUtil.RTrim( Z1284MVATipo));
         GxWebStd.gx_hidden_field( context, "Z1270MVAlmDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1270MVAlmDestino), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1277MVAPlaca", StringUtil.RTrim( Z1277MVAPlaca));
         GxWebStd.gx_hidden_field( context, "Z1287MVCCosto", StringUtil.RTrim( Z1287MVCCosto));
         GxWebStd.gx_hidden_field( context, "Z1372MVUsuCod", StringUtil.RTrim( Z1372MVUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1373MVUsuFec", context.localUtil.TToC( Z1373MVUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1374MVVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1374MVVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1375MVVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1375MVVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1371MVTAsiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1371MVTAsiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1376MVVouNum", StringUtil.RTrim( Z1376MVVouNum));
         GxWebStd.gx_hidden_field( context, "Z1369MVPoliza", StringUtil.RTrim( Z1369MVPoliza));
         GxWebStd.gx_hidden_field( context, "Z1279MVARef1", Z1279MVARef1);
         GxWebStd.gx_hidden_field( context, "Z1280MVARef2", Z1280MVARef2);
         GxWebStd.gx_hidden_field( context, "Z1281MVARef3", Z1281MVARef3);
         GxWebStd.gx_hidden_field( context, "Z1282MVARef4", Z1282MVARef4);
         GxWebStd.gx_hidden_field( context, "Z1283MVARef5", Z1283MVARef5);
         GxWebStd.gx_hidden_field( context, "Z1246MVACadena", Z1246MVACadena);
         GxWebStd.gx_hidden_field( context, "Z1268MVAGEOBS", Z1268MVAGEOBS);
         GxWebStd.gx_hidden_field( context, "Z1267MVAFecIni", context.localUtil.DToC( Z1267MVAFecIni, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17EmpTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EmpTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22MvAMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22MvAMov), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21MvAlm", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21MvAlm), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z23DocTip", StringUtil.RTrim( Z23DocTip));
         GxWebStd.gx_hidden_field( context, "Z20MVPedCod", StringUtil.RTrim( Z20MVPedCod));
         GxWebStd.gx_hidden_field( context, "Z15MVCliCod", StringUtil.RTrim( Z15MVCliCod));
         GxWebStd.gx_hidden_field( context, "Z18MVCDesCod", StringUtil.RTrim( Z18MVCDesCod));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z16MVCliOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16MVCliOrigen), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z19MVCDesItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19MVCDesItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "MVAREF1", A1279MVARef1);
         GxWebStd.gx_hidden_field( context, "MVAREF2", A1280MVARef2);
         GxWebStd.gx_hidden_field( context, "MVAREF3", A1281MVARef3);
         GxWebStd.gx_hidden_field( context, "MVAREF4", A1282MVARef4);
         GxWebStd.gx_hidden_field( context, "MVAREF5", A1283MVARef5);
         GxWebStd.gx_hidden_field( context, "MVACADENA", A1246MVACadena);
         GxWebStd.gx_hidden_field( context, "MVAGEOBS", A1268MVAGEOBS);
         GxWebStd.gx_hidden_field( context, "MVAFECINI", context.localUtil.DToC( A1267MVAFecIni, 0, "/"));
         GxWebStd.gx_hidden_field( context, "MVALMSTS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1272MVAlmSts), 1, 0, ".", "")));
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
         return formatLink("aguias.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AGUIAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Movimientos de Almacen - Cabecera" ;
      }

      protected void InitializeNonKey1438( )
      {
         A25MvAFec = DateTime.MinValue;
         AssignAttri("", false, "A25MvAFec", context.localUtil.Format(A25MvAFec, "99/99/99"));
         A1276MvAOcom = "";
         AssignAttri("", false, "A1276MvAOcom", A1276MvAOcom);
         A1278MvARef = "";
         AssignAttri("", false, "A1278MvARef", A1278MvARef);
         A1286MvATMov = 0;
         AssignAttri("", false, "A1286MvATMov", StringUtil.Str( (decimal)(A1286MvATMov), 1, 0));
         A22MvAMov = 0;
         AssignAttri("", false, "A22MvAMov", StringUtil.LTrimStr( (decimal)(A22MvAMov), 6, 0));
         A1274MvAMovDsc = "";
         AssignAttri("", false, "A1274MvAMovDsc", A1274MvAMovDsc);
         A1273MvAMovAut = 0;
         AssignAttri("", false, "A1273MvAMovAut", StringUtil.Str( (decimal)(A1273MvAMovAut), 1, 0));
         A21MvAlm = 0;
         AssignAttri("", false, "A21MvAlm", StringUtil.LTrimStr( (decimal)(A21MvAlm), 6, 0));
         A1272MVAlmSts = 0;
         AssignAttri("", false, "A1272MVAlmSts", StringUtil.Str( (decimal)(A1272MVAlmSts), 1, 0));
         A1275MvAObs = "";
         AssignAttri("", false, "A1275MvAObs", A1275MvAObs);
         A23DocTip = "";
         n23DocTip = false;
         AssignAttri("", false, "A23DocTip", A23DocTip);
         n23DocTip = (String.IsNullOrEmpty(StringUtil.RTrim( A23DocTip)) ? true : false);
         A24DocNum = "";
         n24DocNum = false;
         AssignAttri("", false, "A24DocNum", A24DocNum);
         n24DocNum = (String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ? true : false);
         A1370MVSts = "";
         AssignAttri("", false, "A1370MVSts", A1370MVSts);
         A20MVPedCod = "";
         n20MVPedCod = false;
         AssignAttri("", false, "A20MVPedCod", A20MVPedCod);
         n20MVPedCod = (String.IsNullOrEmpty(StringUtil.RTrim( A20MVPedCod)) ? true : false);
         A1285MvATItem = 0;
         AssignAttri("", false, "A1285MvATItem", StringUtil.LTrimStr( (decimal)(A1285MvATItem), 6, 0));
         A15MVCliCod = "";
         n15MVCliCod = false;
         AssignAttri("", false, "A15MVCliCod", A15MVCliCod);
         n15MVCliCod = (String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) ? true : false);
         A1290MVCliDsc = "";
         AssignAttri("", false, "A1290MVCliDsc", A1290MVCliDsc);
         A1289MVCliDir = "";
         AssignAttri("", false, "A1289MVCliDir", A1289MVCliDir);
         A16MVCliOrigen = 0;
         n16MVCliOrigen = false;
         AssignAttri("", false, "A16MVCliOrigen", StringUtil.LTrimStr( (decimal)(A16MVCliOrigen), 6, 0));
         n16MVCliOrigen = ((0==A16MVCliOrigen) ? true : false);
         A1291MVCliOrigenDir = "";
         AssignAttri("", false, "A1291MVCliOrigenDir", A1291MVCliOrigenDir);
         A10ChoCod = 0;
         AssignAttri("", false, "A10ChoCod", StringUtil.LTrimStr( (decimal)(A10ChoCod), 6, 0));
         A1284MVATipo = "";
         AssignAttri("", false, "A1284MVATipo", A1284MVATipo);
         A1270MVAlmDestino = 0;
         AssignAttri("", false, "A1270MVAlmDestino", StringUtil.LTrimStr( (decimal)(A1270MVAlmDestino), 6, 0));
         A1277MVAPlaca = "";
         AssignAttri("", false, "A1277MVAPlaca", A1277MVAPlaca);
         A1287MVCCosto = "";
         AssignAttri("", false, "A1287MVCCosto", A1287MVCCosto);
         A18MVCDesCod = "";
         n18MVCDesCod = false;
         AssignAttri("", false, "A18MVCDesCod", A18MVCDesCod);
         A19MVCDesItem = 0;
         n19MVCDesItem = false;
         AssignAttri("", false, "A19MVCDesItem", StringUtil.LTrimStr( (decimal)(A19MVCDesItem), 6, 0));
         A17EmpTCod = 0;
         n17EmpTCod = false;
         AssignAttri("", false, "A17EmpTCod", StringUtil.LTrimStr( (decimal)(A17EmpTCod), 6, 0));
         A1372MVUsuCod = "";
         AssignAttri("", false, "A1372MVUsuCod", A1372MVUsuCod);
         A1373MVUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1373MVUsuFec", context.localUtil.TToC( A1373MVUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1271MvAlmDsc = "";
         AssignAttri("", false, "A1271MvAlmDsc", A1271MvAlmDsc);
         A1269MvAlmCos = 0;
         AssignAttri("", false, "A1269MvAlmCos", StringUtil.Str( (decimal)(A1269MvAlmCos), 1, 0));
         A1374MVVouAno = 0;
         AssignAttri("", false, "A1374MVVouAno", StringUtil.LTrimStr( (decimal)(A1374MVVouAno), 4, 0));
         A1375MVVouMes = 0;
         AssignAttri("", false, "A1375MVVouMes", StringUtil.LTrimStr( (decimal)(A1375MVVouMes), 2, 0));
         A1371MVTAsiCod = 0;
         AssignAttri("", false, "A1371MVTAsiCod", StringUtil.LTrimStr( (decimal)(A1371MVTAsiCod), 6, 0));
         A1376MVVouNum = "";
         AssignAttri("", false, "A1376MVVouNum", A1376MVVouNum);
         A1369MVPoliza = "";
         AssignAttri("", false, "A1369MVPoliza", A1369MVPoliza);
         A1279MVARef1 = "";
         AssignAttri("", false, "A1279MVARef1", A1279MVARef1);
         A1280MVARef2 = "";
         AssignAttri("", false, "A1280MVARef2", A1280MVARef2);
         A1281MVARef3 = "";
         AssignAttri("", false, "A1281MVARef3", A1281MVARef3);
         A1282MVARef4 = "";
         AssignAttri("", false, "A1282MVARef4", A1282MVARef4);
         A1283MVARef5 = "";
         AssignAttri("", false, "A1283MVARef5", A1283MVARef5);
         A1246MVACadena = "";
         AssignAttri("", false, "A1246MVACadena", A1246MVACadena);
         A1268MVAGEOBS = "";
         AssignAttri("", false, "A1268MVAGEOBS", A1268MVAGEOBS);
         A1267MVAFecIni = DateTime.MinValue;
         AssignAttri("", false, "A1267MVAFecIni", context.localUtil.Format(A1267MVAFecIni, "99/99/99"));
         Z25MvAFec = DateTime.MinValue;
         Z1276MvAOcom = "";
         Z1278MvARef = "";
         Z1286MvATMov = 0;
         Z1370MVSts = "";
         Z1285MvATItem = 0;
         Z1284MVATipo = "";
         Z1270MVAlmDestino = 0;
         Z1277MVAPlaca = "";
         Z1287MVCCosto = "";
         Z1372MVUsuCod = "";
         Z1373MVUsuFec = (DateTime)(DateTime.MinValue);
         Z1374MVVouAno = 0;
         Z1375MVVouMes = 0;
         Z1371MVTAsiCod = 0;
         Z1376MVVouNum = "";
         Z1369MVPoliza = "";
         Z1279MVARef1 = "";
         Z1280MVARef2 = "";
         Z1281MVARef3 = "";
         Z1282MVARef4 = "";
         Z1283MVARef5 = "";
         Z1246MVACadena = "";
         Z1268MVAGEOBS = "";
         Z1267MVAFecIni = DateTime.MinValue;
         Z10ChoCod = 0;
         Z17EmpTCod = 0;
         Z22MvAMov = 0;
         Z21MvAlm = 0;
         Z23DocTip = "";
         Z20MVPedCod = "";
         Z15MVCliCod = "";
         Z18MVCDesCod = "";
         Z24DocNum = "";
         Z16MVCliOrigen = 0;
         Z19MVCDesItem = 0;
      }

      protected void InitAll1438( )
      {
         A13MvATip = "";
         AssignAttri("", false, "A13MvATip", A13MvATip);
         A14MvACod = "";
         AssignAttri("", false, "A14MvACod", A14MvACod);
         InitializeNonKey1438( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811464820", true, true);
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
         context.AddJavascriptSource("aguias.js", "?202281811464821", false, true);
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
         edtMvATip_Internalname = "MVATIP";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtMvACod_Internalname = "MVACOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtMvAFec_Internalname = "MVAFEC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtMvAOcom_Internalname = "MVAOCOM";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtMvARef_Internalname = "MVAREF";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtMvATMov_Internalname = "MVATMOV";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtMvAMov_Internalname = "MVAMOV";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtMvAMovDsc_Internalname = "MVAMOVDSC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtMvAMovAut_Internalname = "MVAMOVAUT";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtMvAlm_Internalname = "MVALM";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtMvAObs_Internalname = "MVAOBS";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtDocTip_Internalname = "DOCTIP";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtDocNum_Internalname = "DOCNUM";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtMVSts_Internalname = "MVSTS";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtMVPedCod_Internalname = "MVPEDCOD";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtMvATItem_Internalname = "MVATITEM";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtMVCliCod_Internalname = "MVCLICOD";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtMVCliDsc_Internalname = "MVCLIDSC";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtMVCliDir_Internalname = "MVCLIDIR";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtMVCliOrigen_Internalname = "MVCLIORIGEN";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtMVCliOrigenDir_Internalname = "MVCLIORIGENDIR";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtChoCod_Internalname = "CHOCOD";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtMVATipo_Internalname = "MVATIPO";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         edtMVAlmDestino_Internalname = "MVALMDESTINO";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtMVAPlaca_Internalname = "MVAPLACA";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtMVCCosto_Internalname = "MVCCOSTO";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtMVCDesCod_Internalname = "MVCDESCOD";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtMVCDesItem_Internalname = "MVCDESITEM";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtEmpTCod_Internalname = "EMPTCOD";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtMVUsuCod_Internalname = "MVUSUCOD";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtMVUsuFec_Internalname = "MVUSUFEC";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtMvAlmDsc_Internalname = "MVALMDSC";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtMvAlmCos_Internalname = "MVALMCOS";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtMVVouAno_Internalname = "MVVOUANO";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtMVVouMes_Internalname = "MVVOUMES";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtMVTAsiCod_Internalname = "MVTASICOD";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtMVVouNum_Internalname = "MVVOUNUM";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtMVPoliza_Internalname = "MVPOLIZA";
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
         Form.Caption = "Movimientos de Almacen - Cabecera";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtMVPoliza_Jsonclick = "";
         edtMVPoliza_Enabled = 1;
         edtMVVouNum_Jsonclick = "";
         edtMVVouNum_Enabled = 1;
         edtMVTAsiCod_Jsonclick = "";
         edtMVTAsiCod_Enabled = 1;
         edtMVVouMes_Jsonclick = "";
         edtMVVouMes_Enabled = 1;
         edtMVVouAno_Jsonclick = "";
         edtMVVouAno_Enabled = 1;
         edtMvAlmCos_Jsonclick = "";
         edtMvAlmCos_Enabled = 0;
         edtMvAlmDsc_Jsonclick = "";
         edtMvAlmDsc_Enabled = 0;
         edtMVUsuFec_Jsonclick = "";
         edtMVUsuFec_Enabled = 1;
         edtMVUsuCod_Jsonclick = "";
         edtMVUsuCod_Enabled = 1;
         edtEmpTCod_Jsonclick = "";
         edtEmpTCod_Enabled = 1;
         edtMVCDesItem_Jsonclick = "";
         edtMVCDesItem_Enabled = 1;
         edtMVCDesCod_Jsonclick = "";
         edtMVCDesCod_Enabled = 1;
         edtMVCCosto_Jsonclick = "";
         edtMVCCosto_Enabled = 1;
         edtMVAPlaca_Jsonclick = "";
         edtMVAPlaca_Enabled = 1;
         edtMVAlmDestino_Jsonclick = "";
         edtMVAlmDestino_Enabled = 1;
         edtMVATipo_Jsonclick = "";
         edtMVATipo_Enabled = 1;
         edtChoCod_Jsonclick = "";
         edtChoCod_Enabled = 1;
         edtMVCliOrigenDir_Jsonclick = "";
         edtMVCliOrigenDir_Enabled = 0;
         edtMVCliOrigen_Jsonclick = "";
         edtMVCliOrigen_Enabled = 1;
         edtMVCliDir_Jsonclick = "";
         edtMVCliDir_Enabled = 0;
         edtMVCliDsc_Jsonclick = "";
         edtMVCliDsc_Enabled = 0;
         edtMVCliCod_Jsonclick = "";
         edtMVCliCod_Enabled = 1;
         edtMvATItem_Jsonclick = "";
         edtMvATItem_Enabled = 1;
         edtMVPedCod_Jsonclick = "";
         edtMVPedCod_Enabled = 1;
         edtMVSts_Jsonclick = "";
         edtMVSts_Enabled = 1;
         edtDocNum_Jsonclick = "";
         edtDocNum_Enabled = 1;
         edtDocTip_Jsonclick = "";
         edtDocTip_Enabled = 1;
         edtMvAObs_Enabled = 1;
         edtMvAlm_Jsonclick = "";
         edtMvAlm_Enabled = 1;
         edtMvAMovAut_Jsonclick = "";
         edtMvAMovAut_Enabled = 0;
         edtMvAMovDsc_Jsonclick = "";
         edtMvAMovDsc_Enabled = 0;
         edtMvAMov_Jsonclick = "";
         edtMvAMov_Enabled = 1;
         edtMvATMov_Jsonclick = "";
         edtMvATMov_Enabled = 1;
         edtMvARef_Jsonclick = "";
         edtMvARef_Enabled = 1;
         edtMvAOcom_Jsonclick = "";
         edtMvAOcom_Enabled = 1;
         edtMvAFec_Jsonclick = "";
         edtMvAFec_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtMvACod_Jsonclick = "";
         edtMvACod_Enabled = 1;
         edtMvATip_Jsonclick = "";
         edtMvATip_Enabled = 1;
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
         GX_FocusControl = edtMvAFec_Internalname;
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

      public void Valid_Mvacod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25MvAFec", context.localUtil.Format(A25MvAFec, "99/99/99"));
         AssignAttri("", false, "A1276MvAOcom", StringUtil.RTrim( A1276MvAOcom));
         AssignAttri("", false, "A1278MvARef", StringUtil.RTrim( A1278MvARef));
         AssignAttri("", false, "A1286MvATMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1286MvATMov), 1, 0, ".", "")));
         AssignAttri("", false, "A22MvAMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(A22MvAMov), 6, 0, ".", "")));
         AssignAttri("", false, "A21MvAlm", StringUtil.LTrim( StringUtil.NToC( (decimal)(A21MvAlm), 6, 0, ".", "")));
         AssignAttri("", false, "A1275MvAObs", A1275MvAObs);
         AssignAttri("", false, "A23DocTip", StringUtil.RTrim( A23DocTip));
         AssignAttri("", false, "A24DocNum", StringUtil.RTrim( A24DocNum));
         AssignAttri("", false, "A1370MVSts", StringUtil.RTrim( A1370MVSts));
         AssignAttri("", false, "A20MVPedCod", StringUtil.RTrim( A20MVPedCod));
         AssignAttri("", false, "A1285MvATItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1285MvATItem), 6, 0, ".", "")));
         AssignAttri("", false, "A15MVCliCod", StringUtil.RTrim( A15MVCliCod));
         AssignAttri("", false, "A16MVCliOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(A16MVCliOrigen), 6, 0, ".", "")));
         AssignAttri("", false, "A10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A10ChoCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1284MVATipo", StringUtil.RTrim( A1284MVATipo));
         AssignAttri("", false, "A1270MVAlmDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1270MVAlmDestino), 6, 0, ".", "")));
         AssignAttri("", false, "A1277MVAPlaca", StringUtil.RTrim( A1277MVAPlaca));
         AssignAttri("", false, "A1287MVCCosto", StringUtil.RTrim( A1287MVCCosto));
         AssignAttri("", false, "A18MVCDesCod", StringUtil.RTrim( A18MVCDesCod));
         AssignAttri("", false, "A19MVCDesItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19MVCDesItem), 6, 0, ".", "")));
         AssignAttri("", false, "A17EmpTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A17EmpTCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1372MVUsuCod", StringUtil.RTrim( A1372MVUsuCod));
         AssignAttri("", false, "A1373MVUsuFec", context.localUtil.TToC( A1373MVUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1374MVVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1374MVVouAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1375MVVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1375MVVouMes), 2, 0, ".", "")));
         AssignAttri("", false, "A1371MVTAsiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1371MVTAsiCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1376MVVouNum", StringUtil.RTrim( A1376MVVouNum));
         AssignAttri("", false, "A1369MVPoliza", StringUtil.RTrim( A1369MVPoliza));
         AssignAttri("", false, "A1279MVARef1", A1279MVARef1);
         AssignAttri("", false, "A1280MVARef2", A1280MVARef2);
         AssignAttri("", false, "A1281MVARef3", A1281MVARef3);
         AssignAttri("", false, "A1282MVARef4", A1282MVARef4);
         AssignAttri("", false, "A1283MVARef5", A1283MVARef5);
         AssignAttri("", false, "A1246MVACadena", A1246MVACadena);
         AssignAttri("", false, "A1268MVAGEOBS", A1268MVAGEOBS);
         AssignAttri("", false, "A1267MVAFecIni", context.localUtil.Format(A1267MVAFecIni, "99/99/99"));
         AssignAttri("", false, "A1274MvAMovDsc", StringUtil.RTrim( A1274MvAMovDsc));
         AssignAttri("", false, "A1273MvAMovAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1273MvAMovAut), 1, 0, ".", "")));
         AssignAttri("", false, "A1272MVAlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1272MVAlmSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1271MvAlmDsc", StringUtil.RTrim( A1271MvAlmDsc));
         AssignAttri("", false, "A1269MvAlmCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1269MvAlmCos), 1, 0, ".", "")));
         AssignAttri("", false, "A1290MVCliDsc", StringUtil.RTrim( A1290MVCliDsc));
         AssignAttri("", false, "A1289MVCliDir", StringUtil.RTrim( A1289MVCliDir));
         AssignAttri("", false, "A1291MVCliOrigenDir", StringUtil.RTrim( A1291MVCliOrigenDir));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z13MvATip", StringUtil.RTrim( Z13MvATip));
         GxWebStd.gx_hidden_field( context, "Z14MvACod", StringUtil.RTrim( Z14MvACod));
         GxWebStd.gx_hidden_field( context, "Z25MvAFec", context.localUtil.Format(Z25MvAFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1276MvAOcom", StringUtil.RTrim( Z1276MvAOcom));
         GxWebStd.gx_hidden_field( context, "Z1278MvARef", StringUtil.RTrim( Z1278MvARef));
         GxWebStd.gx_hidden_field( context, "Z1286MvATMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1286MvATMov), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z22MvAMov", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z22MvAMov), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z21MvAlm", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z21MvAlm), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1275MvAObs", Z1275MvAObs);
         GxWebStd.gx_hidden_field( context, "Z23DocTip", StringUtil.RTrim( Z23DocTip));
         GxWebStd.gx_hidden_field( context, "Z24DocNum", StringUtil.RTrim( Z24DocNum));
         GxWebStd.gx_hidden_field( context, "Z1370MVSts", StringUtil.RTrim( Z1370MVSts));
         GxWebStd.gx_hidden_field( context, "Z20MVPedCod", StringUtil.RTrim( Z20MVPedCod));
         GxWebStd.gx_hidden_field( context, "Z1285MvATItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1285MvATItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z15MVCliCod", StringUtil.RTrim( Z15MVCliCod));
         GxWebStd.gx_hidden_field( context, "Z16MVCliOrigen", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z16MVCliOrigen), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z10ChoCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z10ChoCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1284MVATipo", StringUtil.RTrim( Z1284MVATipo));
         GxWebStd.gx_hidden_field( context, "Z1270MVAlmDestino", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1270MVAlmDestino), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1277MVAPlaca", StringUtil.RTrim( Z1277MVAPlaca));
         GxWebStd.gx_hidden_field( context, "Z1287MVCCosto", StringUtil.RTrim( Z1287MVCCosto));
         GxWebStd.gx_hidden_field( context, "Z18MVCDesCod", StringUtil.RTrim( Z18MVCDesCod));
         GxWebStd.gx_hidden_field( context, "Z19MVCDesItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19MVCDesItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z17EmpTCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17EmpTCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1372MVUsuCod", StringUtil.RTrim( Z1372MVUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1373MVUsuFec", context.localUtil.TToC( Z1373MVUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1374MVVouAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1374MVVouAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1375MVVouMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1375MVVouMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1371MVTAsiCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1371MVTAsiCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1376MVVouNum", StringUtil.RTrim( Z1376MVVouNum));
         GxWebStd.gx_hidden_field( context, "Z1369MVPoliza", StringUtil.RTrim( Z1369MVPoliza));
         GxWebStd.gx_hidden_field( context, "Z1279MVARef1", Z1279MVARef1);
         GxWebStd.gx_hidden_field( context, "Z1280MVARef2", Z1280MVARef2);
         GxWebStd.gx_hidden_field( context, "Z1281MVARef3", Z1281MVARef3);
         GxWebStd.gx_hidden_field( context, "Z1282MVARef4", Z1282MVARef4);
         GxWebStd.gx_hidden_field( context, "Z1283MVARef5", Z1283MVARef5);
         GxWebStd.gx_hidden_field( context, "Z1246MVACadena", Z1246MVACadena);
         GxWebStd.gx_hidden_field( context, "Z1268MVAGEOBS", Z1268MVAGEOBS);
         GxWebStd.gx_hidden_field( context, "Z1267MVAFecIni", context.localUtil.Format(Z1267MVAFecIni, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1274MvAMovDsc", StringUtil.RTrim( Z1274MvAMovDsc));
         GxWebStd.gx_hidden_field( context, "Z1273MvAMovAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1273MvAMovAut), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1272MVAlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1272MVAlmSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1271MvAlmDsc", StringUtil.RTrim( Z1271MvAlmDsc));
         GxWebStd.gx_hidden_field( context, "Z1269MvAlmCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1269MvAlmCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1290MVCliDsc", StringUtil.RTrim( Z1290MVCliDsc));
         GxWebStd.gx_hidden_field( context, "Z1289MVCliDir", StringUtil.RTrim( Z1289MVCliDir));
         GxWebStd.gx_hidden_field( context, "Z1291MVCliOrigenDir", StringUtil.RTrim( Z1291MVCliOrigenDir));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Mvamov( )
      {
         /* Using cursor T001429 */
         pr_default.execute(27, new Object[] {A22MvAMov});
         if ( (pr_default.getStatus(27) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Almacen'.", "ForeignKeyNotFound", 1, "MVAMOV");
            AnyError = 1;
            GX_FocusControl = edtMvAMov_Internalname;
         }
         A1274MvAMovDsc = T001429_A1274MvAMovDsc[0];
         A1273MvAMovAut = T001429_A1273MvAMovAut[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1274MvAMovDsc", StringUtil.RTrim( A1274MvAMovDsc));
         AssignAttri("", false, "A1273MvAMovAut", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1273MvAMovAut), 1, 0, ".", "")));
      }

      public void Valid_Mvalm( )
      {
         /* Using cursor T001430 */
         pr_default.execute(28, new Object[] {A21MvAlm});
         if ( (pr_default.getStatus(28) == 101) )
         {
            GX_msglist.addItem("No existe 'Movimiento de Almacen'.", "ForeignKeyNotFound", 1, "MVALM");
            AnyError = 1;
            GX_FocusControl = edtMvAlm_Internalname;
         }
         A1272MVAlmSts = T001430_A1272MVAlmSts[0];
         A1271MvAlmDsc = T001430_A1271MvAlmDsc[0];
         A1269MvAlmCos = T001430_A1269MvAlmCos[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1272MVAlmSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1272MVAlmSts), 1, 0, ".", "")));
         AssignAttri("", false, "A1271MvAlmDsc", StringUtil.RTrim( A1271MvAlmDsc));
         AssignAttri("", false, "A1269MvAlmCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1269MvAlmCos), 1, 0, ".", "")));
      }

      public void Valid_Docnum( )
      {
         n23DocTip = false;
         n24DocNum = false;
         /* Using cursor T001437 */
         pr_default.execute(35, new Object[] {n23DocTip, A23DocTip, n24DocNum, A24DocNum});
         if ( (pr_default.getStatus(35) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A23DocTip)) || String.IsNullOrEmpty(StringUtil.RTrim( A24DocNum)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Salida x Venta'.", "ForeignKeyNotFound", 1, "DOCNUM");
               AnyError = 1;
               GX_FocusControl = edtDocTip_Internalname;
            }
         }
         pr_default.close(35);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvpedcod( )
      {
         n20MVPedCod = false;
         /* Using cursor T001438 */
         pr_default.execute(36, new Object[] {n20MVPedCod, A20MVPedCod});
         if ( (pr_default.getStatus(36) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A20MVPedCod)) ) )
            {
               GX_msglist.addItem("No existe 'Sub Despacho Pedido'.", "ForeignKeyNotFound", 1, "MVPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtMVPedCod_Internalname;
            }
         }
         pr_default.close(36);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvclicod( )
      {
         n15MVCliCod = false;
         /* Using cursor T001431 */
         pr_default.execute(29, new Object[] {n15MVCliCod, A15MVCliCod});
         if ( (pr_default.getStatus(29) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cliente'.", "ForeignKeyNotFound", 1, "MVCLICOD");
               AnyError = 1;
               GX_FocusControl = edtMVCliCod_Internalname;
            }
         }
         A1290MVCliDsc = T001431_A1290MVCliDsc[0];
         A1289MVCliDir = T001431_A1289MVCliDir[0];
         pr_default.close(29);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1290MVCliDsc", StringUtil.RTrim( A1290MVCliDsc));
         AssignAttri("", false, "A1289MVCliDir", StringUtil.RTrim( A1289MVCliDir));
      }

      public void Valid_Mvcliorigen( )
      {
         n15MVCliCod = false;
         n16MVCliOrigen = false;
         /* Using cursor T001432 */
         pr_default.execute(30, new Object[] {n15MVCliCod, A15MVCliCod, n16MVCliOrigen, A16MVCliOrigen});
         if ( (pr_default.getStatus(30) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A15MVCliCod)) || (0==A16MVCliOrigen) ) )
            {
               GX_msglist.addItem("No existe 'Cliente Origen'.", "ForeignKeyNotFound", 1, "MVCLIORIGEN");
               AnyError = 1;
               GX_FocusControl = edtMVCliCod_Internalname;
            }
         }
         A1291MVCliOrigenDir = T001432_A1291MVCliOrigenDir[0];
         pr_default.close(30);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1291MVCliOrigenDir", StringUtil.RTrim( A1291MVCliOrigenDir));
      }

      public void Valid_Chocod( )
      {
         /* Using cursor T001439 */
         pr_default.execute(37, new Object[] {A10ChoCod});
         if ( (pr_default.getStatus(37) == 101) )
         {
            GX_msglist.addItem("No existe 'Transportistas'.", "ForeignKeyNotFound", 1, "CHOCOD");
            AnyError = 1;
            GX_FocusControl = edtChoCod_Internalname;
         }
         pr_default.close(37);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Mvcdesitem( )
      {
         n18MVCDesCod = false;
         n19MVCDesItem = false;
         /* Using cursor T001440 */
         pr_default.execute(38, new Object[] {n18MVCDesCod, A18MVCDesCod, n19MVCDesItem, A19MVCDesItem});
         if ( (pr_default.getStatus(38) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A18MVCDesCod)) || (0==A19MVCDesItem) ) )
            {
               GX_msglist.addItem("No existe 'Sub Remision Destino Item'.", "ForeignKeyNotFound", 1, "MVCDESITEM");
               AnyError = 1;
               GX_FocusControl = edtMVCDesCod_Internalname;
            }
         }
         pr_default.close(38);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Emptcod( )
      {
         n17EmpTCod = false;
         /* Using cursor T001441 */
         pr_default.execute(39, new Object[] {n17EmpTCod, A17EmpTCod});
         if ( (pr_default.getStatus(39) == 101) )
         {
            if ( ! ( (0==A17EmpTCod) ) )
            {
               GX_msglist.addItem("No existe 'Empresa de Transporte'.", "ForeignKeyNotFound", 1, "EMPTCOD");
               AnyError = 1;
               GX_FocusControl = edtEmpTCod_Internalname;
            }
         }
         pr_default.close(39);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1279MVARef1',fld:'MVAREF1',pic:''},{av:'A1280MVARef2',fld:'MVAREF2',pic:''},{av:'A1281MVARef3',fld:'MVAREF3',pic:''},{av:'A1282MVARef4',fld:'MVAREF4',pic:''},{av:'A1283MVARef5',fld:'MVAREF5',pic:''},{av:'A1246MVACadena',fld:'MVACADENA',pic:''},{av:'A1268MVAGEOBS',fld:'MVAGEOBS',pic:''},{av:'A1267MVAFecIni',fld:'MVAFECINI',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_MVATIP","{handler:'Valid_Mvatip',iparms:[]");
         setEventMetadata("VALID_MVATIP",",oparms:[]}");
         setEventMetadata("VALID_MVACOD","{handler:'Valid_Mvacod',iparms:[{av:'A1267MVAFecIni',fld:'MVAFECINI',pic:''},{av:'A1268MVAGEOBS',fld:'MVAGEOBS',pic:''},{av:'A1246MVACadena',fld:'MVACADENA',pic:''},{av:'A1283MVARef5',fld:'MVAREF5',pic:''},{av:'A1282MVARef4',fld:'MVAREF4',pic:''},{av:'A1281MVARef3',fld:'MVAREF3',pic:''},{av:'A1280MVARef2',fld:'MVAREF2',pic:''},{av:'A1279MVARef1',fld:'MVAREF1',pic:''},{av:'A13MvATip',fld:'MVATIP',pic:''},{av:'A14MvACod',fld:'MVACOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_MVACOD",",oparms:[{av:'A25MvAFec',fld:'MVAFEC',pic:''},{av:'A1276MvAOcom',fld:'MVAOCOM',pic:''},{av:'A1278MvARef',fld:'MVAREF',pic:''},{av:'A1286MvATMov',fld:'MVATMOV',pic:'9'},{av:'A22MvAMov',fld:'MVAMOV',pic:'ZZZZZ9'},{av:'A21MvAlm',fld:'MVALM',pic:'ZZZZZ9'},{av:'A1275MvAObs',fld:'MVAOBS',pic:''},{av:'A23DocTip',fld:'DOCTIP',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''},{av:'A1370MVSts',fld:'MVSTS',pic:''},{av:'A20MVPedCod',fld:'MVPEDCOD',pic:''},{av:'A1285MvATItem',fld:'MVATITEM',pic:'ZZZZZ9'},{av:'A15MVCliCod',fld:'MVCLICOD',pic:''},{av:'A16MVCliOrigen',fld:'MVCLIORIGEN',pic:'ZZZZZ9'},{av:'A10ChoCod',fld:'CHOCOD',pic:'ZZZZZ9'},{av:'A1284MVATipo',fld:'MVATIPO',pic:''},{av:'A1270MVAlmDestino',fld:'MVALMDESTINO',pic:'ZZZZZ9'},{av:'A1277MVAPlaca',fld:'MVAPLACA',pic:''},{av:'A1287MVCCosto',fld:'MVCCOSTO',pic:''},{av:'A18MVCDesCod',fld:'MVCDESCOD',pic:''},{av:'A19MVCDesItem',fld:'MVCDESITEM',pic:'ZZZZZ9'},{av:'A17EmpTCod',fld:'EMPTCOD',pic:'ZZZZZ9'},{av:'A1372MVUsuCod',fld:'MVUSUCOD',pic:''},{av:'A1373MVUsuFec',fld:'MVUSUFEC',pic:'99/99/99 99:99'},{av:'A1374MVVouAno',fld:'MVVOUANO',pic:'ZZZ9'},{av:'A1375MVVouMes',fld:'MVVOUMES',pic:'Z9'},{av:'A1371MVTAsiCod',fld:'MVTASICOD',pic:'ZZZZZ9'},{av:'A1376MVVouNum',fld:'MVVOUNUM',pic:''},{av:'A1369MVPoliza',fld:'MVPOLIZA',pic:''},{av:'A1279MVARef1',fld:'MVAREF1',pic:''},{av:'A1280MVARef2',fld:'MVAREF2',pic:''},{av:'A1281MVARef3',fld:'MVAREF3',pic:''},{av:'A1282MVARef4',fld:'MVAREF4',pic:''},{av:'A1283MVARef5',fld:'MVAREF5',pic:''},{av:'A1246MVACadena',fld:'MVACADENA',pic:''},{av:'A1268MVAGEOBS',fld:'MVAGEOBS',pic:''},{av:'A1267MVAFecIni',fld:'MVAFECINI',pic:''},{av:'A1274MvAMovDsc',fld:'MVAMOVDSC',pic:''},{av:'A1273MvAMovAut',fld:'MVAMOVAUT',pic:'9'},{av:'A1272MVAlmSts',fld:'MVALMSTS',pic:'9'},{av:'A1271MvAlmDsc',fld:'MVALMDSC',pic:''},{av:'A1269MvAlmCos',fld:'MVALMCOS',pic:'9'},{av:'A1290MVCliDsc',fld:'MVCLIDSC',pic:''},{av:'A1289MVCliDir',fld:'MVCLIDIR',pic:''},{av:'A1291MVCliOrigenDir',fld:'MVCLIORIGENDIR',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z13MvATip'},{av:'Z14MvACod'},{av:'Z25MvAFec'},{av:'Z1276MvAOcom'},{av:'Z1278MvARef'},{av:'Z1286MvATMov'},{av:'Z22MvAMov'},{av:'Z21MvAlm'},{av:'Z1275MvAObs'},{av:'Z23DocTip'},{av:'Z24DocNum'},{av:'Z1370MVSts'},{av:'Z20MVPedCod'},{av:'Z1285MvATItem'},{av:'Z15MVCliCod'},{av:'Z16MVCliOrigen'},{av:'Z10ChoCod'},{av:'Z1284MVATipo'},{av:'Z1270MVAlmDestino'},{av:'Z1277MVAPlaca'},{av:'Z1287MVCCosto'},{av:'Z18MVCDesCod'},{av:'Z19MVCDesItem'},{av:'Z17EmpTCod'},{av:'Z1372MVUsuCod'},{av:'Z1373MVUsuFec'},{av:'Z1374MVVouAno'},{av:'Z1375MVVouMes'},{av:'Z1371MVTAsiCod'},{av:'Z1376MVVouNum'},{av:'Z1369MVPoliza'},{av:'Z1279MVARef1'},{av:'Z1280MVARef2'},{av:'Z1281MVARef3'},{av:'Z1282MVARef4'},{av:'Z1283MVARef5'},{av:'Z1246MVACadena'},{av:'Z1268MVAGEOBS'},{av:'Z1267MVAFecIni'},{av:'Z1274MvAMovDsc'},{av:'Z1273MvAMovAut'},{av:'Z1272MVAlmSts'},{av:'Z1271MvAlmDsc'},{av:'Z1269MvAlmCos'},{av:'Z1290MVCliDsc'},{av:'Z1289MVCliDir'},{av:'Z1291MVCliOrigenDir'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_MVAFEC","{handler:'Valid_Mvafec',iparms:[]");
         setEventMetadata("VALID_MVAFEC",",oparms:[]}");
         setEventMetadata("VALID_MVAMOV","{handler:'Valid_Mvamov',iparms:[{av:'A22MvAMov',fld:'MVAMOV',pic:'ZZZZZ9'},{av:'A1274MvAMovDsc',fld:'MVAMOVDSC',pic:''},{av:'A1273MvAMovAut',fld:'MVAMOVAUT',pic:'9'}]");
         setEventMetadata("VALID_MVAMOV",",oparms:[{av:'A1274MvAMovDsc',fld:'MVAMOVDSC',pic:''},{av:'A1273MvAMovAut',fld:'MVAMOVAUT',pic:'9'}]}");
         setEventMetadata("VALID_MVALM","{handler:'Valid_Mvalm',iparms:[{av:'A21MvAlm',fld:'MVALM',pic:'ZZZZZ9'},{av:'A1272MVAlmSts',fld:'MVALMSTS',pic:'9'},{av:'A1271MvAlmDsc',fld:'MVALMDSC',pic:''},{av:'A1269MvAlmCos',fld:'MVALMCOS',pic:'9'}]");
         setEventMetadata("VALID_MVALM",",oparms:[{av:'A1272MVAlmSts',fld:'MVALMSTS',pic:'9'},{av:'A1271MvAlmDsc',fld:'MVALMDSC',pic:''},{av:'A1269MvAlmCos',fld:'MVALMCOS',pic:'9'}]}");
         setEventMetadata("VALID_DOCTIP","{handler:'Valid_Doctip',iparms:[]");
         setEventMetadata("VALID_DOCTIP",",oparms:[]}");
         setEventMetadata("VALID_DOCNUM","{handler:'Valid_Docnum',iparms:[{av:'A23DocTip',fld:'DOCTIP',pic:''},{av:'A24DocNum',fld:'DOCNUM',pic:''}]");
         setEventMetadata("VALID_DOCNUM",",oparms:[]}");
         setEventMetadata("VALID_MVPEDCOD","{handler:'Valid_Mvpedcod',iparms:[{av:'A20MVPedCod',fld:'MVPEDCOD',pic:''}]");
         setEventMetadata("VALID_MVPEDCOD",",oparms:[]}");
         setEventMetadata("VALID_MVCLICOD","{handler:'Valid_Mvclicod',iparms:[{av:'A15MVCliCod',fld:'MVCLICOD',pic:''},{av:'A1290MVCliDsc',fld:'MVCLIDSC',pic:''},{av:'A1289MVCliDir',fld:'MVCLIDIR',pic:''}]");
         setEventMetadata("VALID_MVCLICOD",",oparms:[{av:'A1290MVCliDsc',fld:'MVCLIDSC',pic:''},{av:'A1289MVCliDir',fld:'MVCLIDIR',pic:''}]}");
         setEventMetadata("VALID_MVCLIORIGEN","{handler:'Valid_Mvcliorigen',iparms:[{av:'A15MVCliCod',fld:'MVCLICOD',pic:''},{av:'A16MVCliOrigen',fld:'MVCLIORIGEN',pic:'ZZZZZ9'},{av:'A1291MVCliOrigenDir',fld:'MVCLIORIGENDIR',pic:''}]");
         setEventMetadata("VALID_MVCLIORIGEN",",oparms:[{av:'A1291MVCliOrigenDir',fld:'MVCLIORIGENDIR',pic:''}]}");
         setEventMetadata("VALID_CHOCOD","{handler:'Valid_Chocod',iparms:[{av:'A10ChoCod',fld:'CHOCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_CHOCOD",",oparms:[]}");
         setEventMetadata("VALID_MVCDESCOD","{handler:'Valid_Mvcdescod',iparms:[]");
         setEventMetadata("VALID_MVCDESCOD",",oparms:[]}");
         setEventMetadata("VALID_MVCDESITEM","{handler:'Valid_Mvcdesitem',iparms:[{av:'A18MVCDesCod',fld:'MVCDESCOD',pic:''},{av:'A19MVCDesItem',fld:'MVCDESITEM',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_MVCDESITEM",",oparms:[]}");
         setEventMetadata("VALID_EMPTCOD","{handler:'Valid_Emptcod',iparms:[{av:'A17EmpTCod',fld:'EMPTCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_EMPTCOD",",oparms:[]}");
         setEventMetadata("VALID_MVUSUFEC","{handler:'Valid_Mvusufec',iparms:[]");
         setEventMetadata("VALID_MVUSUFEC",",oparms:[]}");
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
         pr_default.close(37);
         pr_default.close(39);
         pr_default.close(27);
         pr_default.close(28);
         pr_default.close(36);
         pr_default.close(29);
         pr_default.close(35);
         pr_default.close(30);
         pr_default.close(38);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z13MvATip = "";
         Z14MvACod = "";
         Z25MvAFec = DateTime.MinValue;
         Z1276MvAOcom = "";
         Z1278MvARef = "";
         Z1370MVSts = "";
         Z1284MVATipo = "";
         Z1277MVAPlaca = "";
         Z1287MVCCosto = "";
         Z1372MVUsuCod = "";
         Z1373MVUsuFec = (DateTime)(DateTime.MinValue);
         Z1376MVVouNum = "";
         Z1369MVPoliza = "";
         Z1279MVARef1 = "";
         Z1280MVARef2 = "";
         Z1281MVARef3 = "";
         Z1282MVARef4 = "";
         Z1283MVARef5 = "";
         Z1246MVACadena = "";
         Z1268MVAGEOBS = "";
         Z1267MVAFecIni = DateTime.MinValue;
         Z23DocTip = "";
         Z20MVPedCod = "";
         Z15MVCliCod = "";
         Z18MVCDesCod = "";
         Z24DocNum = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A23DocTip = "";
         A24DocNum = "";
         A20MVPedCod = "";
         A15MVCliCod = "";
         A18MVCDesCod = "";
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
         A13MvATip = "";
         lblTextblock2_Jsonclick = "";
         A14MvACod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A25MvAFec = DateTime.MinValue;
         lblTextblock4_Jsonclick = "";
         A1276MvAOcom = "";
         lblTextblock5_Jsonclick = "";
         A1278MvARef = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A1274MvAMovDsc = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         A1275MvAObs = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         A1370MVSts = "";
         lblTextblock15_Jsonclick = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         lblTextblock18_Jsonclick = "";
         A1290MVCliDsc = "";
         lblTextblock19_Jsonclick = "";
         A1289MVCliDir = "";
         lblTextblock20_Jsonclick = "";
         lblTextblock21_Jsonclick = "";
         A1291MVCliOrigenDir = "";
         lblTextblock22_Jsonclick = "";
         lblTextblock23_Jsonclick = "";
         A1284MVATipo = "";
         lblTextblock24_Jsonclick = "";
         lblTextblock25_Jsonclick = "";
         A1277MVAPlaca = "";
         lblTextblock26_Jsonclick = "";
         A1287MVCCosto = "";
         lblTextblock27_Jsonclick = "";
         lblTextblock28_Jsonclick = "";
         lblTextblock29_Jsonclick = "";
         lblTextblock30_Jsonclick = "";
         A1372MVUsuCod = "";
         lblTextblock31_Jsonclick = "";
         A1373MVUsuFec = (DateTime)(DateTime.MinValue);
         lblTextblock32_Jsonclick = "";
         A1271MvAlmDsc = "";
         lblTextblock33_Jsonclick = "";
         lblTextblock34_Jsonclick = "";
         lblTextblock35_Jsonclick = "";
         lblTextblock36_Jsonclick = "";
         lblTextblock37_Jsonclick = "";
         A1376MVVouNum = "";
         lblTextblock38_Jsonclick = "";
         A1369MVPoliza = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         A1279MVARef1 = "";
         A1280MVARef2 = "";
         A1281MVARef3 = "";
         A1282MVARef4 = "";
         A1283MVARef5 = "";
         A1246MVACadena = "";
         A1268MVAGEOBS = "";
         A1267MVAFecIni = DateTime.MinValue;
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z1275MvAObs = "";
         Z1274MvAMovDsc = "";
         Z1271MvAlmDsc = "";
         Z1290MVCliDsc = "";
         Z1289MVCliDir = "";
         Z1291MVCliOrigenDir = "";
         T001413_A13MvATip = new string[] {""} ;
         T001413_A14MvACod = new string[] {""} ;
         T001413_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         T001413_A1276MvAOcom = new string[] {""} ;
         T001413_A1278MvARef = new string[] {""} ;
         T001413_A1286MvATMov = new short[1] ;
         T001413_A1274MvAMovDsc = new string[] {""} ;
         T001413_A1273MvAMovAut = new short[1] ;
         T001413_A1272MVAlmSts = new short[1] ;
         T001413_A1275MvAObs = new string[] {""} ;
         T001413_A1370MVSts = new string[] {""} ;
         T001413_A1285MvATItem = new int[1] ;
         T001413_A1290MVCliDsc = new string[] {""} ;
         T001413_A1289MVCliDir = new string[] {""} ;
         T001413_A1291MVCliOrigenDir = new string[] {""} ;
         T001413_A1284MVATipo = new string[] {""} ;
         T001413_A1270MVAlmDestino = new int[1] ;
         T001413_A1277MVAPlaca = new string[] {""} ;
         T001413_A1287MVCCosto = new string[] {""} ;
         T001413_A1372MVUsuCod = new string[] {""} ;
         T001413_A1373MVUsuFec = new DateTime[] {DateTime.MinValue} ;
         T001413_A1271MvAlmDsc = new string[] {""} ;
         T001413_A1269MvAlmCos = new short[1] ;
         T001413_A1374MVVouAno = new short[1] ;
         T001413_A1375MVVouMes = new short[1] ;
         T001413_A1371MVTAsiCod = new int[1] ;
         T001413_A1376MVVouNum = new string[] {""} ;
         T001413_A1369MVPoliza = new string[] {""} ;
         T001413_A1279MVARef1 = new string[] {""} ;
         T001413_A1280MVARef2 = new string[] {""} ;
         T001413_A1281MVARef3 = new string[] {""} ;
         T001413_A1282MVARef4 = new string[] {""} ;
         T001413_A1283MVARef5 = new string[] {""} ;
         T001413_A1246MVACadena = new string[] {""} ;
         T001413_A1268MVAGEOBS = new string[] {""} ;
         T001413_A1267MVAFecIni = new DateTime[] {DateTime.MinValue} ;
         T001413_A10ChoCod = new int[1] ;
         T001413_A17EmpTCod = new int[1] ;
         T001413_n17EmpTCod = new bool[] {false} ;
         T001413_A22MvAMov = new int[1] ;
         T001413_A21MvAlm = new int[1] ;
         T001413_A23DocTip = new string[] {""} ;
         T001413_n23DocTip = new bool[] {false} ;
         T001413_A20MVPedCod = new string[] {""} ;
         T001413_n20MVPedCod = new bool[] {false} ;
         T001413_A15MVCliCod = new string[] {""} ;
         T001413_n15MVCliCod = new bool[] {false} ;
         T001413_A18MVCDesCod = new string[] {""} ;
         T001413_n18MVCDesCod = new bool[] {false} ;
         T001413_A24DocNum = new string[] {""} ;
         T001413_n24DocNum = new bool[] {false} ;
         T001413_A16MVCliOrigen = new int[1] ;
         T001413_n16MVCliOrigen = new bool[] {false} ;
         T001413_A19MVCDesItem = new int[1] ;
         T001413_n19MVCDesItem = new bool[] {false} ;
         T00146_A1274MvAMovDsc = new string[] {""} ;
         T00146_A1273MvAMovAut = new short[1] ;
         T00147_A1272MVAlmSts = new short[1] ;
         T00147_A1271MvAlmDsc = new string[] {""} ;
         T00147_A1269MvAlmCos = new short[1] ;
         T001410_A23DocTip = new string[] {""} ;
         T001410_n23DocTip = new bool[] {false} ;
         T00148_A20MVPedCod = new string[] {""} ;
         T00148_n20MVPedCod = new bool[] {false} ;
         T00149_A1290MVCliDsc = new string[] {""} ;
         T00149_A1289MVCliDir = new string[] {""} ;
         T001411_A1291MVCliOrigenDir = new string[] {""} ;
         T00144_A10ChoCod = new int[1] ;
         T001412_A18MVCDesCod = new string[] {""} ;
         T001412_n18MVCDesCod = new bool[] {false} ;
         T00145_A17EmpTCod = new int[1] ;
         T00145_n17EmpTCod = new bool[] {false} ;
         T001414_A1274MvAMovDsc = new string[] {""} ;
         T001414_A1273MvAMovAut = new short[1] ;
         T001415_A1272MVAlmSts = new short[1] ;
         T001415_A1271MvAlmDsc = new string[] {""} ;
         T001415_A1269MvAlmCos = new short[1] ;
         T001416_A23DocTip = new string[] {""} ;
         T001416_n23DocTip = new bool[] {false} ;
         T001417_A20MVPedCod = new string[] {""} ;
         T001417_n20MVPedCod = new bool[] {false} ;
         T001418_A1290MVCliDsc = new string[] {""} ;
         T001418_A1289MVCliDir = new string[] {""} ;
         T001419_A1291MVCliOrigenDir = new string[] {""} ;
         T001420_A10ChoCod = new int[1] ;
         T001421_A18MVCDesCod = new string[] {""} ;
         T001421_n18MVCDesCod = new bool[] {false} ;
         T001422_A17EmpTCod = new int[1] ;
         T001422_n17EmpTCod = new bool[] {false} ;
         T001423_A13MvATip = new string[] {""} ;
         T001423_A14MvACod = new string[] {""} ;
         T00143_A13MvATip = new string[] {""} ;
         T00143_A14MvACod = new string[] {""} ;
         T00143_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         T00143_A1276MvAOcom = new string[] {""} ;
         T00143_A1278MvARef = new string[] {""} ;
         T00143_A1286MvATMov = new short[1] ;
         T00143_A1275MvAObs = new string[] {""} ;
         T00143_A1370MVSts = new string[] {""} ;
         T00143_A1285MvATItem = new int[1] ;
         T00143_A1284MVATipo = new string[] {""} ;
         T00143_A1270MVAlmDestino = new int[1] ;
         T00143_A1277MVAPlaca = new string[] {""} ;
         T00143_A1287MVCCosto = new string[] {""} ;
         T00143_A1372MVUsuCod = new string[] {""} ;
         T00143_A1373MVUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00143_A1374MVVouAno = new short[1] ;
         T00143_A1375MVVouMes = new short[1] ;
         T00143_A1371MVTAsiCod = new int[1] ;
         T00143_A1376MVVouNum = new string[] {""} ;
         T00143_A1369MVPoliza = new string[] {""} ;
         T00143_A1279MVARef1 = new string[] {""} ;
         T00143_A1280MVARef2 = new string[] {""} ;
         T00143_A1281MVARef3 = new string[] {""} ;
         T00143_A1282MVARef4 = new string[] {""} ;
         T00143_A1283MVARef5 = new string[] {""} ;
         T00143_A1246MVACadena = new string[] {""} ;
         T00143_A1268MVAGEOBS = new string[] {""} ;
         T00143_A1267MVAFecIni = new DateTime[] {DateTime.MinValue} ;
         T00143_A10ChoCod = new int[1] ;
         T00143_A17EmpTCod = new int[1] ;
         T00143_n17EmpTCod = new bool[] {false} ;
         T00143_A22MvAMov = new int[1] ;
         T00143_A21MvAlm = new int[1] ;
         T00143_A23DocTip = new string[] {""} ;
         T00143_n23DocTip = new bool[] {false} ;
         T00143_A20MVPedCod = new string[] {""} ;
         T00143_n20MVPedCod = new bool[] {false} ;
         T00143_A15MVCliCod = new string[] {""} ;
         T00143_n15MVCliCod = new bool[] {false} ;
         T00143_A18MVCDesCod = new string[] {""} ;
         T00143_n18MVCDesCod = new bool[] {false} ;
         T00143_A24DocNum = new string[] {""} ;
         T00143_n24DocNum = new bool[] {false} ;
         T00143_A16MVCliOrigen = new int[1] ;
         T00143_n16MVCliOrigen = new bool[] {false} ;
         T00143_A19MVCDesItem = new int[1] ;
         T00143_n19MVCDesItem = new bool[] {false} ;
         sMode38 = "";
         T001424_A13MvATip = new string[] {""} ;
         T001424_A14MvACod = new string[] {""} ;
         T001425_A13MvATip = new string[] {""} ;
         T001425_A14MvACod = new string[] {""} ;
         T00142_A13MvATip = new string[] {""} ;
         T00142_A14MvACod = new string[] {""} ;
         T00142_A25MvAFec = new DateTime[] {DateTime.MinValue} ;
         T00142_A1276MvAOcom = new string[] {""} ;
         T00142_A1278MvARef = new string[] {""} ;
         T00142_A1286MvATMov = new short[1] ;
         T00142_A1275MvAObs = new string[] {""} ;
         T00142_A1370MVSts = new string[] {""} ;
         T00142_A1285MvATItem = new int[1] ;
         T00142_A1284MVATipo = new string[] {""} ;
         T00142_A1270MVAlmDestino = new int[1] ;
         T00142_A1277MVAPlaca = new string[] {""} ;
         T00142_A1287MVCCosto = new string[] {""} ;
         T00142_A1372MVUsuCod = new string[] {""} ;
         T00142_A1373MVUsuFec = new DateTime[] {DateTime.MinValue} ;
         T00142_A1374MVVouAno = new short[1] ;
         T00142_A1375MVVouMes = new short[1] ;
         T00142_A1371MVTAsiCod = new int[1] ;
         T00142_A1376MVVouNum = new string[] {""} ;
         T00142_A1369MVPoliza = new string[] {""} ;
         T00142_A1279MVARef1 = new string[] {""} ;
         T00142_A1280MVARef2 = new string[] {""} ;
         T00142_A1281MVARef3 = new string[] {""} ;
         T00142_A1282MVARef4 = new string[] {""} ;
         T00142_A1283MVARef5 = new string[] {""} ;
         T00142_A1246MVACadena = new string[] {""} ;
         T00142_A1268MVAGEOBS = new string[] {""} ;
         T00142_A1267MVAFecIni = new DateTime[] {DateTime.MinValue} ;
         T00142_A10ChoCod = new int[1] ;
         T00142_A17EmpTCod = new int[1] ;
         T00142_n17EmpTCod = new bool[] {false} ;
         T00142_A22MvAMov = new int[1] ;
         T00142_A21MvAlm = new int[1] ;
         T00142_A23DocTip = new string[] {""} ;
         T00142_n23DocTip = new bool[] {false} ;
         T00142_A20MVPedCod = new string[] {""} ;
         T00142_n20MVPedCod = new bool[] {false} ;
         T00142_A15MVCliCod = new string[] {""} ;
         T00142_n15MVCliCod = new bool[] {false} ;
         T00142_A18MVCDesCod = new string[] {""} ;
         T00142_n18MVCDesCod = new bool[] {false} ;
         T00142_A24DocNum = new string[] {""} ;
         T00142_n24DocNum = new bool[] {false} ;
         T00142_A16MVCliOrigen = new int[1] ;
         T00142_n16MVCliOrigen = new bool[] {false} ;
         T00142_A19MVCDesItem = new int[1] ;
         T00142_n19MVCDesItem = new bool[] {false} ;
         T001429_A1274MvAMovDsc = new string[] {""} ;
         T001429_A1273MvAMovAut = new short[1] ;
         T001430_A1272MVAlmSts = new short[1] ;
         T001430_A1271MvAlmDsc = new string[] {""} ;
         T001430_A1269MvAlmCos = new short[1] ;
         T001431_A1290MVCliDsc = new string[] {""} ;
         T001431_A1289MVCliDir = new string[] {""} ;
         T001432_A1291MVCliOrigenDir = new string[] {""} ;
         T001433_A65TraMVATip = new string[] {""} ;
         T001433_A66TraMVACod = new string[] {""} ;
         T001434_A13MvATip = new string[] {""} ;
         T001434_A14MvACod = new string[] {""} ;
         T001434_A30MvADItem = new int[1] ;
         T001435_A8DesCod = new string[] {""} ;
         T001435_A11DesTipGuia = new string[] {""} ;
         T001435_A12DesGuia = new string[] {""} ;
         T001436_A13MvATip = new string[] {""} ;
         T001436_A14MvACod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ13MvATip = "";
         ZZ14MvACod = "";
         ZZ25MvAFec = DateTime.MinValue;
         ZZ1276MvAOcom = "";
         ZZ1278MvARef = "";
         ZZ1275MvAObs = "";
         ZZ23DocTip = "";
         ZZ24DocNum = "";
         ZZ1370MVSts = "";
         ZZ20MVPedCod = "";
         ZZ15MVCliCod = "";
         ZZ1284MVATipo = "";
         ZZ1277MVAPlaca = "";
         ZZ1287MVCCosto = "";
         ZZ18MVCDesCod = "";
         ZZ1372MVUsuCod = "";
         ZZ1373MVUsuFec = (DateTime)(DateTime.MinValue);
         ZZ1376MVVouNum = "";
         ZZ1369MVPoliza = "";
         ZZ1279MVARef1 = "";
         ZZ1280MVARef2 = "";
         ZZ1281MVARef3 = "";
         ZZ1282MVARef4 = "";
         ZZ1283MVARef5 = "";
         ZZ1246MVACadena = "";
         ZZ1268MVAGEOBS = "";
         ZZ1267MVAFecIni = DateTime.MinValue;
         ZZ1274MvAMovDsc = "";
         ZZ1271MvAlmDsc = "";
         ZZ1290MVCliDsc = "";
         ZZ1289MVCliDir = "";
         ZZ1291MVCliOrigenDir = "";
         T001437_A23DocTip = new string[] {""} ;
         T001437_n23DocTip = new bool[] {false} ;
         T001438_A20MVPedCod = new string[] {""} ;
         T001438_n20MVPedCod = new bool[] {false} ;
         T001439_A10ChoCod = new int[1] ;
         T001440_A18MVCDesCod = new string[] {""} ;
         T001440_n18MVCDesCod = new bool[] {false} ;
         T001441_A17EmpTCod = new int[1] ;
         T001441_n17EmpTCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aguias__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aguias__default(),
            new Object[][] {
                new Object[] {
               T00142_A13MvATip, T00142_A14MvACod, T00142_A25MvAFec, T00142_A1276MvAOcom, T00142_A1278MvARef, T00142_A1286MvATMov, T00142_A1275MvAObs, T00142_A1370MVSts, T00142_A1285MvATItem, T00142_A1284MVATipo,
               T00142_A1270MVAlmDestino, T00142_A1277MVAPlaca, T00142_A1287MVCCosto, T00142_A1372MVUsuCod, T00142_A1373MVUsuFec, T00142_A1374MVVouAno, T00142_A1375MVVouMes, T00142_A1371MVTAsiCod, T00142_A1376MVVouNum, T00142_A1369MVPoliza,
               T00142_A1279MVARef1, T00142_A1280MVARef2, T00142_A1281MVARef3, T00142_A1282MVARef4, T00142_A1283MVARef5, T00142_A1246MVACadena, T00142_A1268MVAGEOBS, T00142_A1267MVAFecIni, T00142_A10ChoCod, T00142_A17EmpTCod,
               T00142_n17EmpTCod, T00142_A22MvAMov, T00142_A21MvAlm, T00142_A23DocTip, T00142_n23DocTip, T00142_A20MVPedCod, T00142_n20MVPedCod, T00142_A15MVCliCod, T00142_n15MVCliCod, T00142_A18MVCDesCod,
               T00142_n18MVCDesCod, T00142_A24DocNum, T00142_n24DocNum, T00142_A16MVCliOrigen, T00142_n16MVCliOrigen, T00142_A19MVCDesItem, T00142_n19MVCDesItem
               }
               , new Object[] {
               T00143_A13MvATip, T00143_A14MvACod, T00143_A25MvAFec, T00143_A1276MvAOcom, T00143_A1278MvARef, T00143_A1286MvATMov, T00143_A1275MvAObs, T00143_A1370MVSts, T00143_A1285MvATItem, T00143_A1284MVATipo,
               T00143_A1270MVAlmDestino, T00143_A1277MVAPlaca, T00143_A1287MVCCosto, T00143_A1372MVUsuCod, T00143_A1373MVUsuFec, T00143_A1374MVVouAno, T00143_A1375MVVouMes, T00143_A1371MVTAsiCod, T00143_A1376MVVouNum, T00143_A1369MVPoliza,
               T00143_A1279MVARef1, T00143_A1280MVARef2, T00143_A1281MVARef3, T00143_A1282MVARef4, T00143_A1283MVARef5, T00143_A1246MVACadena, T00143_A1268MVAGEOBS, T00143_A1267MVAFecIni, T00143_A10ChoCod, T00143_A17EmpTCod,
               T00143_n17EmpTCod, T00143_A22MvAMov, T00143_A21MvAlm, T00143_A23DocTip, T00143_n23DocTip, T00143_A20MVPedCod, T00143_n20MVPedCod, T00143_A15MVCliCod, T00143_n15MVCliCod, T00143_A18MVCDesCod,
               T00143_n18MVCDesCod, T00143_A24DocNum, T00143_n24DocNum, T00143_A16MVCliOrigen, T00143_n16MVCliOrigen, T00143_A19MVCDesItem, T00143_n19MVCDesItem
               }
               , new Object[] {
               T00144_A10ChoCod
               }
               , new Object[] {
               T00145_A17EmpTCod
               }
               , new Object[] {
               T00146_A1274MvAMovDsc, T00146_A1273MvAMovAut
               }
               , new Object[] {
               T00147_A1272MVAlmSts, T00147_A1271MvAlmDsc, T00147_A1269MvAlmCos
               }
               , new Object[] {
               T00148_A20MVPedCod
               }
               , new Object[] {
               T00149_A1290MVCliDsc, T00149_A1289MVCliDir
               }
               , new Object[] {
               T001410_A23DocTip
               }
               , new Object[] {
               T001411_A1291MVCliOrigenDir
               }
               , new Object[] {
               T001412_A18MVCDesCod
               }
               , new Object[] {
               T001413_A13MvATip, T001413_A14MvACod, T001413_A25MvAFec, T001413_A1276MvAOcom, T001413_A1278MvARef, T001413_A1286MvATMov, T001413_A1274MvAMovDsc, T001413_A1273MvAMovAut, T001413_A1272MVAlmSts, T001413_A1275MvAObs,
               T001413_A1370MVSts, T001413_A1285MvATItem, T001413_A1290MVCliDsc, T001413_A1289MVCliDir, T001413_A1291MVCliOrigenDir, T001413_A1284MVATipo, T001413_A1270MVAlmDestino, T001413_A1277MVAPlaca, T001413_A1287MVCCosto, T001413_A1372MVUsuCod,
               T001413_A1373MVUsuFec, T001413_A1271MvAlmDsc, T001413_A1269MvAlmCos, T001413_A1374MVVouAno, T001413_A1375MVVouMes, T001413_A1371MVTAsiCod, T001413_A1376MVVouNum, T001413_A1369MVPoliza, T001413_A1279MVARef1, T001413_A1280MVARef2,
               T001413_A1281MVARef3, T001413_A1282MVARef4, T001413_A1283MVARef5, T001413_A1246MVACadena, T001413_A1268MVAGEOBS, T001413_A1267MVAFecIni, T001413_A10ChoCod, T001413_A17EmpTCod, T001413_n17EmpTCod, T001413_A22MvAMov,
               T001413_A21MvAlm, T001413_A23DocTip, T001413_n23DocTip, T001413_A20MVPedCod, T001413_n20MVPedCod, T001413_A15MVCliCod, T001413_n15MVCliCod, T001413_A18MVCDesCod, T001413_n18MVCDesCod, T001413_A24DocNum,
               T001413_n24DocNum, T001413_A16MVCliOrigen, T001413_n16MVCliOrigen, T001413_A19MVCDesItem, T001413_n19MVCDesItem
               }
               , new Object[] {
               T001414_A1274MvAMovDsc, T001414_A1273MvAMovAut
               }
               , new Object[] {
               T001415_A1272MVAlmSts, T001415_A1271MvAlmDsc, T001415_A1269MvAlmCos
               }
               , new Object[] {
               T001416_A23DocTip
               }
               , new Object[] {
               T001417_A20MVPedCod
               }
               , new Object[] {
               T001418_A1290MVCliDsc, T001418_A1289MVCliDir
               }
               , new Object[] {
               T001419_A1291MVCliOrigenDir
               }
               , new Object[] {
               T001420_A10ChoCod
               }
               , new Object[] {
               T001421_A18MVCDesCod
               }
               , new Object[] {
               T001422_A17EmpTCod
               }
               , new Object[] {
               T001423_A13MvATip, T001423_A14MvACod
               }
               , new Object[] {
               T001424_A13MvATip, T001424_A14MvACod
               }
               , new Object[] {
               T001425_A13MvATip, T001425_A14MvACod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001429_A1274MvAMovDsc, T001429_A1273MvAMovAut
               }
               , new Object[] {
               T001430_A1272MVAlmSts, T001430_A1271MvAlmDsc, T001430_A1269MvAlmCos
               }
               , new Object[] {
               T001431_A1290MVCliDsc, T001431_A1289MVCliDir
               }
               , new Object[] {
               T001432_A1291MVCliOrigenDir
               }
               , new Object[] {
               T001433_A65TraMVATip, T001433_A66TraMVACod
               }
               , new Object[] {
               T001434_A13MvATip, T001434_A14MvACod, T001434_A30MvADItem
               }
               , new Object[] {
               T001435_A8DesCod, T001435_A11DesTipGuia, T001435_A12DesGuia
               }
               , new Object[] {
               T001436_A13MvATip, T001436_A14MvACod
               }
               , new Object[] {
               T001437_A23DocTip
               }
               , new Object[] {
               T001438_A20MVPedCod
               }
               , new Object[] {
               T001439_A10ChoCod
               }
               , new Object[] {
               T001440_A18MVCDesCod
               }
               , new Object[] {
               T001441_A17EmpTCod
               }
            }
         );
      }

      private short Z1286MvATMov ;
      private short Z1374MVVouAno ;
      private short Z1375MVVouMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1286MvATMov ;
      private short A1273MvAMovAut ;
      private short A1269MvAlmCos ;
      private short A1374MVVouAno ;
      private short A1375MVVouMes ;
      private short A1272MVAlmSts ;
      private short GX_JID ;
      private short Z1273MvAMovAut ;
      private short Z1272MVAlmSts ;
      private short Z1269MvAlmCos ;
      private short RcdFound38 ;
      private short nIsDirty_38 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1286MvATMov ;
      private short ZZ1374MVVouAno ;
      private short ZZ1375MVVouMes ;
      private short ZZ1273MvAMovAut ;
      private short ZZ1272MVAlmSts ;
      private short ZZ1269MvAlmCos ;
      private int Z1285MvATItem ;
      private int Z1270MVAlmDestino ;
      private int Z1371MVTAsiCod ;
      private int Z10ChoCod ;
      private int Z17EmpTCod ;
      private int Z22MvAMov ;
      private int Z21MvAlm ;
      private int Z16MVCliOrigen ;
      private int Z19MVCDesItem ;
      private int A22MvAMov ;
      private int A21MvAlm ;
      private int A16MVCliOrigen ;
      private int A10ChoCod ;
      private int A19MVCDesItem ;
      private int A17EmpTCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtMvATip_Enabled ;
      private int edtMvACod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtMvAFec_Enabled ;
      private int edtMvAOcom_Enabled ;
      private int edtMvARef_Enabled ;
      private int edtMvATMov_Enabled ;
      private int edtMvAMov_Enabled ;
      private int edtMvAMovDsc_Enabled ;
      private int edtMvAMovAut_Enabled ;
      private int edtMvAlm_Enabled ;
      private int edtMvAObs_Enabled ;
      private int edtDocTip_Enabled ;
      private int edtDocNum_Enabled ;
      private int edtMVSts_Enabled ;
      private int edtMVPedCod_Enabled ;
      private int A1285MvATItem ;
      private int edtMvATItem_Enabled ;
      private int edtMVCliCod_Enabled ;
      private int edtMVCliDsc_Enabled ;
      private int edtMVCliDir_Enabled ;
      private int edtMVCliOrigen_Enabled ;
      private int edtMVCliOrigenDir_Enabled ;
      private int edtChoCod_Enabled ;
      private int edtMVATipo_Enabled ;
      private int A1270MVAlmDestino ;
      private int edtMVAlmDestino_Enabled ;
      private int edtMVAPlaca_Enabled ;
      private int edtMVCCosto_Enabled ;
      private int edtMVCDesCod_Enabled ;
      private int edtMVCDesItem_Enabled ;
      private int edtEmpTCod_Enabled ;
      private int edtMVUsuCod_Enabled ;
      private int edtMVUsuFec_Enabled ;
      private int edtMvAlmDsc_Enabled ;
      private int edtMvAlmCos_Enabled ;
      private int edtMVVouAno_Enabled ;
      private int edtMVVouMes_Enabled ;
      private int A1371MVTAsiCod ;
      private int edtMVTAsiCod_Enabled ;
      private int edtMVVouNum_Enabled ;
      private int edtMVPoliza_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ22MvAMov ;
      private int ZZ21MvAlm ;
      private int ZZ1285MvATItem ;
      private int ZZ16MVCliOrigen ;
      private int ZZ10ChoCod ;
      private int ZZ1270MVAlmDestino ;
      private int ZZ19MVCDesItem ;
      private int ZZ17EmpTCod ;
      private int ZZ1371MVTAsiCod ;
      private string sPrefix ;
      private string Z13MvATip ;
      private string Z14MvACod ;
      private string Z1276MvAOcom ;
      private string Z1278MvARef ;
      private string Z1370MVSts ;
      private string Z1284MVATipo ;
      private string Z1277MVAPlaca ;
      private string Z1287MVCCosto ;
      private string Z1372MVUsuCod ;
      private string Z1376MVVouNum ;
      private string Z1369MVPoliza ;
      private string Z23DocTip ;
      private string Z20MVPedCod ;
      private string Z15MVCliCod ;
      private string Z18MVCDesCod ;
      private string Z24DocNum ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A23DocTip ;
      private string A24DocNum ;
      private string A20MVPedCod ;
      private string A15MVCliCod ;
      private string A18MVCDesCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMvATip_Internalname ;
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
      private string A13MvATip ;
      private string edtMvATip_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtMvACod_Internalname ;
      private string A14MvACod ;
      private string edtMvACod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtMvAFec_Internalname ;
      private string edtMvAFec_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtMvAOcom_Internalname ;
      private string A1276MvAOcom ;
      private string edtMvAOcom_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtMvARef_Internalname ;
      private string A1278MvARef ;
      private string edtMvARef_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtMvATMov_Internalname ;
      private string edtMvATMov_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtMvAMov_Internalname ;
      private string edtMvAMov_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtMvAMovDsc_Internalname ;
      private string A1274MvAMovDsc ;
      private string edtMvAMovDsc_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtMvAMovAut_Internalname ;
      private string edtMvAMovAut_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtMvAlm_Internalname ;
      private string edtMvAlm_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtMvAObs_Internalname ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtDocTip_Internalname ;
      private string edtDocTip_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtDocNum_Internalname ;
      private string edtDocNum_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtMVSts_Internalname ;
      private string A1370MVSts ;
      private string edtMVSts_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtMVPedCod_Internalname ;
      private string edtMVPedCod_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtMvATItem_Internalname ;
      private string edtMvATItem_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtMVCliCod_Internalname ;
      private string edtMVCliCod_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtMVCliDsc_Internalname ;
      private string A1290MVCliDsc ;
      private string edtMVCliDsc_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtMVCliDir_Internalname ;
      private string A1289MVCliDir ;
      private string edtMVCliDir_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtMVCliOrigen_Internalname ;
      private string edtMVCliOrigen_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtMVCliOrigenDir_Internalname ;
      private string A1291MVCliOrigenDir ;
      private string edtMVCliOrigenDir_Jsonclick ;
      private string lblTextblock22_Internalname ;
      private string lblTextblock22_Jsonclick ;
      private string edtChoCod_Internalname ;
      private string edtChoCod_Jsonclick ;
      private string lblTextblock23_Internalname ;
      private string lblTextblock23_Jsonclick ;
      private string edtMVATipo_Internalname ;
      private string A1284MVATipo ;
      private string edtMVATipo_Jsonclick ;
      private string lblTextblock24_Internalname ;
      private string lblTextblock24_Jsonclick ;
      private string edtMVAlmDestino_Internalname ;
      private string edtMVAlmDestino_Jsonclick ;
      private string lblTextblock25_Internalname ;
      private string lblTextblock25_Jsonclick ;
      private string edtMVAPlaca_Internalname ;
      private string A1277MVAPlaca ;
      private string edtMVAPlaca_Jsonclick ;
      private string lblTextblock26_Internalname ;
      private string lblTextblock26_Jsonclick ;
      private string edtMVCCosto_Internalname ;
      private string A1287MVCCosto ;
      private string edtMVCCosto_Jsonclick ;
      private string lblTextblock27_Internalname ;
      private string lblTextblock27_Jsonclick ;
      private string edtMVCDesCod_Internalname ;
      private string edtMVCDesCod_Jsonclick ;
      private string lblTextblock28_Internalname ;
      private string lblTextblock28_Jsonclick ;
      private string edtMVCDesItem_Internalname ;
      private string edtMVCDesItem_Jsonclick ;
      private string lblTextblock29_Internalname ;
      private string lblTextblock29_Jsonclick ;
      private string edtEmpTCod_Internalname ;
      private string edtEmpTCod_Jsonclick ;
      private string lblTextblock30_Internalname ;
      private string lblTextblock30_Jsonclick ;
      private string edtMVUsuCod_Internalname ;
      private string A1372MVUsuCod ;
      private string edtMVUsuCod_Jsonclick ;
      private string lblTextblock31_Internalname ;
      private string lblTextblock31_Jsonclick ;
      private string edtMVUsuFec_Internalname ;
      private string edtMVUsuFec_Jsonclick ;
      private string lblTextblock32_Internalname ;
      private string lblTextblock32_Jsonclick ;
      private string edtMvAlmDsc_Internalname ;
      private string A1271MvAlmDsc ;
      private string edtMvAlmDsc_Jsonclick ;
      private string lblTextblock33_Internalname ;
      private string lblTextblock33_Jsonclick ;
      private string edtMvAlmCos_Internalname ;
      private string edtMvAlmCos_Jsonclick ;
      private string lblTextblock34_Internalname ;
      private string lblTextblock34_Jsonclick ;
      private string edtMVVouAno_Internalname ;
      private string edtMVVouAno_Jsonclick ;
      private string lblTextblock35_Internalname ;
      private string lblTextblock35_Jsonclick ;
      private string edtMVVouMes_Internalname ;
      private string edtMVVouMes_Jsonclick ;
      private string lblTextblock36_Internalname ;
      private string lblTextblock36_Jsonclick ;
      private string edtMVTAsiCod_Internalname ;
      private string edtMVTAsiCod_Jsonclick ;
      private string lblTextblock37_Internalname ;
      private string lblTextblock37_Jsonclick ;
      private string edtMVVouNum_Internalname ;
      private string A1376MVVouNum ;
      private string edtMVVouNum_Jsonclick ;
      private string lblTextblock38_Internalname ;
      private string lblTextblock38_Jsonclick ;
      private string edtMVPoliza_Internalname ;
      private string A1369MVPoliza ;
      private string edtMVPoliza_Jsonclick ;
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
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z1274MvAMovDsc ;
      private string Z1271MvAlmDsc ;
      private string Z1290MVCliDsc ;
      private string Z1289MVCliDir ;
      private string Z1291MVCliOrigenDir ;
      private string sMode38 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ13MvATip ;
      private string ZZ14MvACod ;
      private string ZZ1276MvAOcom ;
      private string ZZ1278MvARef ;
      private string ZZ23DocTip ;
      private string ZZ24DocNum ;
      private string ZZ1370MVSts ;
      private string ZZ20MVPedCod ;
      private string ZZ15MVCliCod ;
      private string ZZ1284MVATipo ;
      private string ZZ1277MVAPlaca ;
      private string ZZ1287MVCCosto ;
      private string ZZ18MVCDesCod ;
      private string ZZ1372MVUsuCod ;
      private string ZZ1376MVVouNum ;
      private string ZZ1369MVPoliza ;
      private string ZZ1274MvAMovDsc ;
      private string ZZ1271MvAlmDsc ;
      private string ZZ1290MVCliDsc ;
      private string ZZ1289MVCliDir ;
      private string ZZ1291MVCliOrigenDir ;
      private DateTime Z1373MVUsuFec ;
      private DateTime A1373MVUsuFec ;
      private DateTime ZZ1373MVUsuFec ;
      private DateTime Z25MvAFec ;
      private DateTime Z1267MVAFecIni ;
      private DateTime A25MvAFec ;
      private DateTime A1267MVAFecIni ;
      private DateTime ZZ25MvAFec ;
      private DateTime ZZ1267MVAFecIni ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n23DocTip ;
      private bool n24DocNum ;
      private bool n20MVPedCod ;
      private bool n15MVCliCod ;
      private bool n16MVCliOrigen ;
      private bool n18MVCDesCod ;
      private bool n19MVCDesItem ;
      private bool n17EmpTCod ;
      private bool wbErr ;
      private bool Gx_longc ;
      private string A1275MvAObs ;
      private string Z1275MvAObs ;
      private string ZZ1275MvAObs ;
      private string Z1279MVARef1 ;
      private string Z1280MVARef2 ;
      private string Z1281MVARef3 ;
      private string Z1282MVARef4 ;
      private string Z1283MVARef5 ;
      private string Z1246MVACadena ;
      private string Z1268MVAGEOBS ;
      private string A1279MVARef1 ;
      private string A1280MVARef2 ;
      private string A1281MVARef3 ;
      private string A1282MVARef4 ;
      private string A1283MVARef5 ;
      private string A1246MVACadena ;
      private string A1268MVAGEOBS ;
      private string ZZ1279MVARef1 ;
      private string ZZ1280MVARef2 ;
      private string ZZ1281MVARef3 ;
      private string ZZ1282MVARef4 ;
      private string ZZ1283MVARef5 ;
      private string ZZ1246MVACadena ;
      private string ZZ1268MVAGEOBS ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001413_A13MvATip ;
      private string[] T001413_A14MvACod ;
      private DateTime[] T001413_A25MvAFec ;
      private string[] T001413_A1276MvAOcom ;
      private string[] T001413_A1278MvARef ;
      private short[] T001413_A1286MvATMov ;
      private string[] T001413_A1274MvAMovDsc ;
      private short[] T001413_A1273MvAMovAut ;
      private short[] T001413_A1272MVAlmSts ;
      private string[] T001413_A1275MvAObs ;
      private string[] T001413_A1370MVSts ;
      private int[] T001413_A1285MvATItem ;
      private string[] T001413_A1290MVCliDsc ;
      private string[] T001413_A1289MVCliDir ;
      private string[] T001413_A1291MVCliOrigenDir ;
      private string[] T001413_A1284MVATipo ;
      private int[] T001413_A1270MVAlmDestino ;
      private string[] T001413_A1277MVAPlaca ;
      private string[] T001413_A1287MVCCosto ;
      private string[] T001413_A1372MVUsuCod ;
      private DateTime[] T001413_A1373MVUsuFec ;
      private string[] T001413_A1271MvAlmDsc ;
      private short[] T001413_A1269MvAlmCos ;
      private short[] T001413_A1374MVVouAno ;
      private short[] T001413_A1375MVVouMes ;
      private int[] T001413_A1371MVTAsiCod ;
      private string[] T001413_A1376MVVouNum ;
      private string[] T001413_A1369MVPoliza ;
      private string[] T001413_A1279MVARef1 ;
      private string[] T001413_A1280MVARef2 ;
      private string[] T001413_A1281MVARef3 ;
      private string[] T001413_A1282MVARef4 ;
      private string[] T001413_A1283MVARef5 ;
      private string[] T001413_A1246MVACadena ;
      private string[] T001413_A1268MVAGEOBS ;
      private DateTime[] T001413_A1267MVAFecIni ;
      private int[] T001413_A10ChoCod ;
      private int[] T001413_A17EmpTCod ;
      private bool[] T001413_n17EmpTCod ;
      private int[] T001413_A22MvAMov ;
      private int[] T001413_A21MvAlm ;
      private string[] T001413_A23DocTip ;
      private bool[] T001413_n23DocTip ;
      private string[] T001413_A20MVPedCod ;
      private bool[] T001413_n20MVPedCod ;
      private string[] T001413_A15MVCliCod ;
      private bool[] T001413_n15MVCliCod ;
      private string[] T001413_A18MVCDesCod ;
      private bool[] T001413_n18MVCDesCod ;
      private string[] T001413_A24DocNum ;
      private bool[] T001413_n24DocNum ;
      private int[] T001413_A16MVCliOrigen ;
      private bool[] T001413_n16MVCliOrigen ;
      private int[] T001413_A19MVCDesItem ;
      private bool[] T001413_n19MVCDesItem ;
      private string[] T00146_A1274MvAMovDsc ;
      private short[] T00146_A1273MvAMovAut ;
      private short[] T00147_A1272MVAlmSts ;
      private string[] T00147_A1271MvAlmDsc ;
      private short[] T00147_A1269MvAlmCos ;
      private string[] T001410_A23DocTip ;
      private bool[] T001410_n23DocTip ;
      private string[] T00148_A20MVPedCod ;
      private bool[] T00148_n20MVPedCod ;
      private string[] T00149_A1290MVCliDsc ;
      private string[] T00149_A1289MVCliDir ;
      private string[] T001411_A1291MVCliOrigenDir ;
      private int[] T00144_A10ChoCod ;
      private string[] T001412_A18MVCDesCod ;
      private bool[] T001412_n18MVCDesCod ;
      private int[] T00145_A17EmpTCod ;
      private bool[] T00145_n17EmpTCod ;
      private string[] T001414_A1274MvAMovDsc ;
      private short[] T001414_A1273MvAMovAut ;
      private short[] T001415_A1272MVAlmSts ;
      private string[] T001415_A1271MvAlmDsc ;
      private short[] T001415_A1269MvAlmCos ;
      private string[] T001416_A23DocTip ;
      private bool[] T001416_n23DocTip ;
      private string[] T001417_A20MVPedCod ;
      private bool[] T001417_n20MVPedCod ;
      private string[] T001418_A1290MVCliDsc ;
      private string[] T001418_A1289MVCliDir ;
      private string[] T001419_A1291MVCliOrigenDir ;
      private int[] T001420_A10ChoCod ;
      private string[] T001421_A18MVCDesCod ;
      private bool[] T001421_n18MVCDesCod ;
      private int[] T001422_A17EmpTCod ;
      private bool[] T001422_n17EmpTCod ;
      private string[] T001423_A13MvATip ;
      private string[] T001423_A14MvACod ;
      private string[] T00143_A13MvATip ;
      private string[] T00143_A14MvACod ;
      private DateTime[] T00143_A25MvAFec ;
      private string[] T00143_A1276MvAOcom ;
      private string[] T00143_A1278MvARef ;
      private short[] T00143_A1286MvATMov ;
      private string[] T00143_A1275MvAObs ;
      private string[] T00143_A1370MVSts ;
      private int[] T00143_A1285MvATItem ;
      private string[] T00143_A1284MVATipo ;
      private int[] T00143_A1270MVAlmDestino ;
      private string[] T00143_A1277MVAPlaca ;
      private string[] T00143_A1287MVCCosto ;
      private string[] T00143_A1372MVUsuCod ;
      private DateTime[] T00143_A1373MVUsuFec ;
      private short[] T00143_A1374MVVouAno ;
      private short[] T00143_A1375MVVouMes ;
      private int[] T00143_A1371MVTAsiCod ;
      private string[] T00143_A1376MVVouNum ;
      private string[] T00143_A1369MVPoliza ;
      private string[] T00143_A1279MVARef1 ;
      private string[] T00143_A1280MVARef2 ;
      private string[] T00143_A1281MVARef3 ;
      private string[] T00143_A1282MVARef4 ;
      private string[] T00143_A1283MVARef5 ;
      private string[] T00143_A1246MVACadena ;
      private string[] T00143_A1268MVAGEOBS ;
      private DateTime[] T00143_A1267MVAFecIni ;
      private int[] T00143_A10ChoCod ;
      private int[] T00143_A17EmpTCod ;
      private bool[] T00143_n17EmpTCod ;
      private int[] T00143_A22MvAMov ;
      private int[] T00143_A21MvAlm ;
      private string[] T00143_A23DocTip ;
      private bool[] T00143_n23DocTip ;
      private string[] T00143_A20MVPedCod ;
      private bool[] T00143_n20MVPedCod ;
      private string[] T00143_A15MVCliCod ;
      private bool[] T00143_n15MVCliCod ;
      private string[] T00143_A18MVCDesCod ;
      private bool[] T00143_n18MVCDesCod ;
      private string[] T00143_A24DocNum ;
      private bool[] T00143_n24DocNum ;
      private int[] T00143_A16MVCliOrigen ;
      private bool[] T00143_n16MVCliOrigen ;
      private int[] T00143_A19MVCDesItem ;
      private bool[] T00143_n19MVCDesItem ;
      private string[] T001424_A13MvATip ;
      private string[] T001424_A14MvACod ;
      private string[] T001425_A13MvATip ;
      private string[] T001425_A14MvACod ;
      private string[] T00142_A13MvATip ;
      private string[] T00142_A14MvACod ;
      private DateTime[] T00142_A25MvAFec ;
      private string[] T00142_A1276MvAOcom ;
      private string[] T00142_A1278MvARef ;
      private short[] T00142_A1286MvATMov ;
      private string[] T00142_A1275MvAObs ;
      private string[] T00142_A1370MVSts ;
      private int[] T00142_A1285MvATItem ;
      private string[] T00142_A1284MVATipo ;
      private int[] T00142_A1270MVAlmDestino ;
      private string[] T00142_A1277MVAPlaca ;
      private string[] T00142_A1287MVCCosto ;
      private string[] T00142_A1372MVUsuCod ;
      private DateTime[] T00142_A1373MVUsuFec ;
      private short[] T00142_A1374MVVouAno ;
      private short[] T00142_A1375MVVouMes ;
      private int[] T00142_A1371MVTAsiCod ;
      private string[] T00142_A1376MVVouNum ;
      private string[] T00142_A1369MVPoliza ;
      private string[] T00142_A1279MVARef1 ;
      private string[] T00142_A1280MVARef2 ;
      private string[] T00142_A1281MVARef3 ;
      private string[] T00142_A1282MVARef4 ;
      private string[] T00142_A1283MVARef5 ;
      private string[] T00142_A1246MVACadena ;
      private string[] T00142_A1268MVAGEOBS ;
      private DateTime[] T00142_A1267MVAFecIni ;
      private int[] T00142_A10ChoCod ;
      private int[] T00142_A17EmpTCod ;
      private bool[] T00142_n17EmpTCod ;
      private int[] T00142_A22MvAMov ;
      private int[] T00142_A21MvAlm ;
      private string[] T00142_A23DocTip ;
      private bool[] T00142_n23DocTip ;
      private string[] T00142_A20MVPedCod ;
      private bool[] T00142_n20MVPedCod ;
      private string[] T00142_A15MVCliCod ;
      private bool[] T00142_n15MVCliCod ;
      private string[] T00142_A18MVCDesCod ;
      private bool[] T00142_n18MVCDesCod ;
      private string[] T00142_A24DocNum ;
      private bool[] T00142_n24DocNum ;
      private int[] T00142_A16MVCliOrigen ;
      private bool[] T00142_n16MVCliOrigen ;
      private int[] T00142_A19MVCDesItem ;
      private bool[] T00142_n19MVCDesItem ;
      private string[] T001429_A1274MvAMovDsc ;
      private short[] T001429_A1273MvAMovAut ;
      private short[] T001430_A1272MVAlmSts ;
      private string[] T001430_A1271MvAlmDsc ;
      private short[] T001430_A1269MvAlmCos ;
      private string[] T001431_A1290MVCliDsc ;
      private string[] T001431_A1289MVCliDir ;
      private string[] T001432_A1291MVCliOrigenDir ;
      private string[] T001433_A65TraMVATip ;
      private string[] T001433_A66TraMVACod ;
      private string[] T001434_A13MvATip ;
      private string[] T001434_A14MvACod ;
      private int[] T001434_A30MvADItem ;
      private string[] T001435_A8DesCod ;
      private string[] T001435_A11DesTipGuia ;
      private string[] T001435_A12DesGuia ;
      private string[] T001436_A13MvATip ;
      private string[] T001436_A14MvACod ;
      private string[] T001437_A23DocTip ;
      private bool[] T001437_n23DocTip ;
      private string[] T001438_A20MVPedCod ;
      private bool[] T001438_n20MVPedCod ;
      private int[] T001439_A10ChoCod ;
      private string[] T001440_A18MVCDesCod ;
      private bool[] T001440_n18MVCDesCod ;
      private int[] T001441_A17EmpTCod ;
      private bool[] T001441_n17EmpTCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aguias__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aguias__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[37])
       ,new ForEachCursor(def[38])
       ,new ForEachCursor(def[39])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001413;
        prmT001413 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT00146;
        prmT00146 = new Object[] {
        new ParDef("@MvAMov",GXType.Int32,6,0)
        };
        Object[] prmT00147;
        prmT00147 = new Object[] {
        new ParDef("@MvAlm",GXType.Int32,6,0)
        };
        Object[] prmT001410;
        prmT001410 = new Object[] {
        new ParDef("@DocTip",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT00148;
        prmT00148 = new Object[] {
        new ParDef("@MVPedCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT00149;
        prmT00149 = new Object[] {
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001411;
        prmT001411 = new Object[] {
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCliOrigen",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00144;
        prmT00144 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT001412;
        prmT001412 = new Object[] {
        new ParDef("@MVCDesCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCDesItem",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT00145;
        prmT00145 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001414;
        prmT001414 = new Object[] {
        new ParDef("@MvAMov",GXType.Int32,6,0)
        };
        Object[] prmT001415;
        prmT001415 = new Object[] {
        new ParDef("@MvAlm",GXType.Int32,6,0)
        };
        Object[] prmT001416;
        prmT001416 = new Object[] {
        new ParDef("@DocTip",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT001417;
        prmT001417 = new Object[] {
        new ParDef("@MVPedCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001418;
        prmT001418 = new Object[] {
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001419;
        prmT001419 = new Object[] {
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCliOrigen",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001420;
        prmT001420 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT001421;
        prmT001421 = new Object[] {
        new ParDef("@MVCDesCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCDesItem",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001422;
        prmT001422 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001423;
        prmT001423 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT00143;
        prmT00143 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001424;
        prmT001424 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001425;
        prmT001425 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT00142;
        prmT00142 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001426;
        prmT001426 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0) ,
        new ParDef("@MvAFec",GXType.Date,8,0) ,
        new ParDef("@MvAOcom",GXType.NChar,10,0) ,
        new ParDef("@MvARef",GXType.NChar,20,0) ,
        new ParDef("@MvATMov",GXType.Int16,1,0) ,
        new ParDef("@MvAObs",GXType.NVarChar,500,0) ,
        new ParDef("@MVSts",GXType.NChar,1,0) ,
        new ParDef("@MvATItem",GXType.Int32,6,0) ,
        new ParDef("@MVATipo",GXType.NChar,1,0) ,
        new ParDef("@MVAlmDestino",GXType.Int32,6,0) ,
        new ParDef("@MVAPlaca",GXType.NChar,20,0) ,
        new ParDef("@MVCCosto",GXType.NChar,10,0) ,
        new ParDef("@MVUsuCod",GXType.NChar,10,0) ,
        new ParDef("@MVUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@MVVouAno",GXType.Int16,4,0) ,
        new ParDef("@MVVouMes",GXType.Int16,2,0) ,
        new ParDef("@MVTAsiCod",GXType.Int32,6,0) ,
        new ParDef("@MVVouNum",GXType.NChar,10,0) ,
        new ParDef("@MVPoliza",GXType.NChar,20,0) ,
        new ParDef("@MVARef1",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef2",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef3",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef4",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef5",GXType.NVarChar,100,0) ,
        new ParDef("@MVACadena",GXType.NVarChar,200,0) ,
        new ParDef("@MVAGEOBS",GXType.NVarChar,200,0) ,
        new ParDef("@MVAFecIni",GXType.Date,8,0) ,
        new ParDef("@ChoCod",GXType.Int32,6,0) ,
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MvAMov",GXType.Int32,6,0) ,
        new ParDef("@MvAlm",GXType.Int32,6,0) ,
        new ParDef("@DocTip",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@MVPedCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCDesCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true} ,
        new ParDef("@MVCliOrigen",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVCDesItem",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001427;
        prmT001427 = new Object[] {
        new ParDef("@MvAFec",GXType.Date,8,0) ,
        new ParDef("@MvAOcom",GXType.NChar,10,0) ,
        new ParDef("@MvARef",GXType.NChar,20,0) ,
        new ParDef("@MvATMov",GXType.Int16,1,0) ,
        new ParDef("@MvAObs",GXType.NVarChar,500,0) ,
        new ParDef("@MVSts",GXType.NChar,1,0) ,
        new ParDef("@MvATItem",GXType.Int32,6,0) ,
        new ParDef("@MVATipo",GXType.NChar,1,0) ,
        new ParDef("@MVAlmDestino",GXType.Int32,6,0) ,
        new ParDef("@MVAPlaca",GXType.NChar,20,0) ,
        new ParDef("@MVCCosto",GXType.NChar,10,0) ,
        new ParDef("@MVUsuCod",GXType.NChar,10,0) ,
        new ParDef("@MVUsuFec",GXType.DateTime,8,5) ,
        new ParDef("@MVVouAno",GXType.Int16,4,0) ,
        new ParDef("@MVVouMes",GXType.Int16,2,0) ,
        new ParDef("@MVTAsiCod",GXType.Int32,6,0) ,
        new ParDef("@MVVouNum",GXType.NChar,10,0) ,
        new ParDef("@MVPoliza",GXType.NChar,20,0) ,
        new ParDef("@MVARef1",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef2",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef3",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef4",GXType.NVarChar,100,0) ,
        new ParDef("@MVARef5",GXType.NVarChar,100,0) ,
        new ParDef("@MVACadena",GXType.NVarChar,200,0) ,
        new ParDef("@MVAGEOBS",GXType.NVarChar,200,0) ,
        new ParDef("@MVAFecIni",GXType.Date,8,0) ,
        new ParDef("@ChoCod",GXType.Int32,6,0) ,
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MvAMov",GXType.Int32,6,0) ,
        new ParDef("@MvAlm",GXType.Int32,6,0) ,
        new ParDef("@DocTip",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@MVPedCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCDesCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true} ,
        new ParDef("@MVCliOrigen",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MVCDesItem",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001428;
        prmT001428 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001433;
        prmT001433 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001434;
        prmT001434 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001435;
        prmT001435 = new Object[] {
        new ParDef("@MvATip",GXType.NChar,3,0) ,
        new ParDef("@MvACod",GXType.NChar,12,0)
        };
        Object[] prmT001436;
        prmT001436 = new Object[] {
        };
        Object[] prmT001429;
        prmT001429 = new Object[] {
        new ParDef("@MvAMov",GXType.Int32,6,0)
        };
        Object[] prmT001430;
        prmT001430 = new Object[] {
        new ParDef("@MvAlm",GXType.Int32,6,0)
        };
        Object[] prmT001437;
        prmT001437 = new Object[] {
        new ParDef("@DocTip",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@DocNum",GXType.NChar,12,0){Nullable=true}
        };
        Object[] prmT001438;
        prmT001438 = new Object[] {
        new ParDef("@MVPedCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT001431;
        prmT001431 = new Object[] {
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true}
        };
        Object[] prmT001432;
        prmT001432 = new Object[] {
        new ParDef("@MVCliCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCliOrigen",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001439;
        prmT001439 = new Object[] {
        new ParDef("@ChoCod",GXType.Int32,6,0)
        };
        Object[] prmT001440;
        prmT001440 = new Object[] {
        new ParDef("@MVCDesCod",GXType.NChar,20,0){Nullable=true} ,
        new ParDef("@MVCDesItem",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001441;
        prmT001441 = new Object[] {
        new ParDef("@EmpTCod",GXType.Int32,6,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00142", "SELECT [MvATip], [MvACod], [MvAFec], [MvAOcom], [MvARef], [MvATMov], [MvAObs], [MVSts], [MvATItem], [MVATipo], [MVAlmDestino], [MVAPlaca], [MVCCosto], [MVUsuCod], [MVUsuFec], [MVVouAno], [MVVouMes], [MVTAsiCod], [MVVouNum], [MVPoliza], [MVARef1], [MVARef2], [MVARef3], [MVARef4], [MVARef5], [MVACadena], [MVAGEOBS], [MVAFecIni], [ChoCod], [EmpTCod], [MvAMov] AS MvAMov, [MvAlm] AS MvAlm, [DocTip] AS DocTip, [MVPedCod] AS MVPedCod, [MVCliCod] AS MVCliCod, [MVCDesCod] AS MVCDesCod, [DocNum], [MVCliOrigen] AS MVCliOrigen, [MVCDesItem] AS MVCDesItem FROM [AGUIAS] WITH (UPDLOCK) WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00142,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00143", "SELECT [MvATip], [MvACod], [MvAFec], [MvAOcom], [MvARef], [MvATMov], [MvAObs], [MVSts], [MvATItem], [MVATipo], [MVAlmDestino], [MVAPlaca], [MVCCosto], [MVUsuCod], [MVUsuFec], [MVVouAno], [MVVouMes], [MVTAsiCod], [MVVouNum], [MVPoliza], [MVARef1], [MVARef2], [MVARef3], [MVARef4], [MVARef5], [MVACadena], [MVAGEOBS], [MVAFecIni], [ChoCod], [EmpTCod], [MvAMov] AS MvAMov, [MvAlm] AS MvAlm, [DocTip] AS DocTip, [MVPedCod] AS MVPedCod, [MVCliCod] AS MVCliCod, [MVCDesCod] AS MVCDesCod, [DocNum], [MVCliOrigen] AS MVCliOrigen, [MVCDesItem] AS MVCDesItem FROM [AGUIAS] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00143,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00144", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00144,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00145", "SELECT [EmpTCod] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00145,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00146", "SELECT [MovDsc] AS MvAMovDsc, [MovAut] AS MvAMovAut FROM [CMOVALMACEN] WHERE [MovCod] = @MvAMov ",true, GxErrorMask.GX_NOMASK, false, this,prmT00146,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00147", "SELECT [AlmSts] AS MVAlmSts, [AlmDsc] AS MvAlmDsc, [AlmCos] AS MvAlmCos FROM [CALMACEN] WHERE [AlmCod] = @MvAlm ",true, GxErrorMask.GX_NOMASK, false, this,prmT00147,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00148", "SELECT [PedCod] AS MVPedCod FROM [CLPEDIDOS] WHERE [PedCod] = @MVPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00148,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00149", "SELECT [CliDsc] AS MVCliDsc, [CliDir] AS MVCliDir FROM [CLCLIENTES] WHERE [CliCod] = @MVCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00149,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001410", "SELECT [TipCod] AS DocTip FROM [CLVENTAS] WHERE [TipCod] = @DocTip AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT001410,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001411", "SELECT [CliDirDir] AS MVCliOrigenDir FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @MVCliCod AND [CliDirItem] = @MVCliOrigen ",true, GxErrorMask.GX_NOMASK, false, this,prmT001411,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001412", "SELECT [CliCod] AS MVCDesCod FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @MVCDesCod AND [CliDirItem] = @MVCDesItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001412,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001413", "SELECT TM1.[MvATip], TM1.[MvACod], TM1.[MvAFec], TM1.[MvAOcom], TM1.[MvARef], TM1.[MvATMov], T2.[MovDsc] AS MvAMovDsc, T2.[MovAut] AS MvAMovAut, T3.[AlmSts] AS MVAlmSts, TM1.[MvAObs], TM1.[MVSts], TM1.[MvATItem], T4.[CliDsc] AS MVCliDsc, T4.[CliDir] AS MVCliDir, T5.[CliDirDir] AS MVCliOrigenDir, TM1.[MVATipo], TM1.[MVAlmDestino], TM1.[MVAPlaca], TM1.[MVCCosto], TM1.[MVUsuCod], TM1.[MVUsuFec], T3.[AlmDsc] AS MvAlmDsc, T3.[AlmCos] AS MvAlmCos, TM1.[MVVouAno], TM1.[MVVouMes], TM1.[MVTAsiCod], TM1.[MVVouNum], TM1.[MVPoliza], TM1.[MVARef1], TM1.[MVARef2], TM1.[MVARef3], TM1.[MVARef4], TM1.[MVARef5], TM1.[MVACadena], TM1.[MVAGEOBS], TM1.[MVAFecIni], TM1.[ChoCod], TM1.[EmpTCod], TM1.[MvAMov] AS MvAMov, TM1.[MvAlm] AS MvAlm, TM1.[DocTip] AS DocTip, TM1.[MVPedCod] AS MVPedCod, TM1.[MVCliCod] AS MVCliCod, TM1.[MVCDesCod] AS MVCDesCod, TM1.[DocNum], TM1.[MVCliOrigen] AS MVCliOrigen, TM1.[MVCDesItem] AS MVCDesItem FROM (((([AGUIAS] TM1 INNER JOIN [CMOVALMACEN] T2 ON T2.[MovCod] = TM1.[MvAMov]) INNER JOIN [CALMACEN] T3 ON T3.[AlmCod] = TM1.[MvAlm]) LEFT JOIN [CLCLIENTES] T4 ON T4.[CliCod] = TM1.[MVCliCod]) LEFT JOIN [CLCLIENTESDIRECCION] T5 ON T5.[CliCod] = TM1.[MVCliCod] AND T5.[CliDirItem] = TM1.[MVCliOrigen]) WHERE TM1.[MvATip] = @MvATip and TM1.[MvACod] = @MvACod ORDER BY TM1.[MvATip], TM1.[MvACod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001413,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001414", "SELECT [MovDsc] AS MvAMovDsc, [MovAut] AS MvAMovAut FROM [CMOVALMACEN] WHERE [MovCod] = @MvAMov ",true, GxErrorMask.GX_NOMASK, false, this,prmT001414,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001415", "SELECT [AlmSts] AS MVAlmSts, [AlmDsc] AS MvAlmDsc, [AlmCos] AS MvAlmCos FROM [CALMACEN] WHERE [AlmCod] = @MvAlm ",true, GxErrorMask.GX_NOMASK, false, this,prmT001415,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001416", "SELECT [TipCod] AS DocTip FROM [CLVENTAS] WHERE [TipCod] = @DocTip AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT001416,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001417", "SELECT [PedCod] AS MVPedCod FROM [CLPEDIDOS] WHERE [PedCod] = @MVPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001417,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001418", "SELECT [CliDsc] AS MVCliDsc, [CliDir] AS MVCliDir FROM [CLCLIENTES] WHERE [CliCod] = @MVCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001418,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001419", "SELECT [CliDirDir] AS MVCliOrigenDir FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @MVCliCod AND [CliDirItem] = @MVCliOrigen ",true, GxErrorMask.GX_NOMASK, false, this,prmT001419,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001420", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001420,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001421", "SELECT [CliCod] AS MVCDesCod FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @MVCDesCod AND [CliDirItem] = @MVCDesItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001421,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001422", "SELECT [EmpTCod] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001422,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001423", "SELECT [MvATip], [MvACod] FROM [AGUIAS] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001423,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001424", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE ( [MvATip] > @MvATip or [MvATip] = @MvATip and [MvACod] > @MvACod) ORDER BY [MvATip], [MvACod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001424,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001425", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE ( [MvATip] < @MvATip or [MvATip] = @MvATip and [MvACod] < @MvACod) ORDER BY [MvATip] DESC, [MvACod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001425,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001426", "INSERT INTO [AGUIAS]([MvATip], [MvACod], [MvAFec], [MvAOcom], [MvARef], [MvATMov], [MvAObs], [MVSts], [MvATItem], [MVATipo], [MVAlmDestino], [MVAPlaca], [MVCCosto], [MVUsuCod], [MVUsuFec], [MVVouAno], [MVVouMes], [MVTAsiCod], [MVVouNum], [MVPoliza], [MVARef1], [MVARef2], [MVARef3], [MVARef4], [MVARef5], [MVACadena], [MVAGEOBS], [MVAFecIni], [ChoCod], [EmpTCod], [MvAMov], [MvAlm], [DocTip], [MVPedCod], [MVCliCod], [MVCDesCod], [DocNum], [MVCliOrigen], [MVCDesItem]) VALUES(@MvATip, @MvACod, @MvAFec, @MvAOcom, @MvARef, @MvATMov, @MvAObs, @MVSts, @MvATItem, @MVATipo, @MVAlmDestino, @MVAPlaca, @MVCCosto, @MVUsuCod, @MVUsuFec, @MVVouAno, @MVVouMes, @MVTAsiCod, @MVVouNum, @MVPoliza, @MVARef1, @MVARef2, @MVARef3, @MVARef4, @MVARef5, @MVACadena, @MVAGEOBS, @MVAFecIni, @ChoCod, @EmpTCod, @MvAMov, @MvAlm, @DocTip, @MVPedCod, @MVCliCod, @MVCDesCod, @DocNum, @MVCliOrigen, @MVCDesItem)", GxErrorMask.GX_NOMASK,prmT001426)
           ,new CursorDef("T001427", "UPDATE [AGUIAS] SET [MvAFec]=@MvAFec, [MvAOcom]=@MvAOcom, [MvARef]=@MvARef, [MvATMov]=@MvATMov, [MvAObs]=@MvAObs, [MVSts]=@MVSts, [MvATItem]=@MvATItem, [MVATipo]=@MVATipo, [MVAlmDestino]=@MVAlmDestino, [MVAPlaca]=@MVAPlaca, [MVCCosto]=@MVCCosto, [MVUsuCod]=@MVUsuCod, [MVUsuFec]=@MVUsuFec, [MVVouAno]=@MVVouAno, [MVVouMes]=@MVVouMes, [MVTAsiCod]=@MVTAsiCod, [MVVouNum]=@MVVouNum, [MVPoliza]=@MVPoliza, [MVARef1]=@MVARef1, [MVARef2]=@MVARef2, [MVARef3]=@MVARef3, [MVARef4]=@MVARef4, [MVARef5]=@MVARef5, [MVACadena]=@MVACadena, [MVAGEOBS]=@MVAGEOBS, [MVAFecIni]=@MVAFecIni, [ChoCod]=@ChoCod, [EmpTCod]=@EmpTCod, [MvAMov]=@MvAMov, [MvAlm]=@MvAlm, [DocTip]=@DocTip, [MVPedCod]=@MVPedCod, [MVCliCod]=@MVCliCod, [MVCDesCod]=@MVCDesCod, [DocNum]=@DocNum, [MVCliOrigen]=@MVCliOrigen, [MVCDesItem]=@MVCDesItem  WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod", GxErrorMask.GX_NOMASK,prmT001427)
           ,new CursorDef("T001428", "DELETE FROM [AGUIAS]  WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod", GxErrorMask.GX_NOMASK,prmT001428)
           ,new CursorDef("T001429", "SELECT [MovDsc] AS MvAMovDsc, [MovAut] AS MvAMovAut FROM [CMOVALMACEN] WHERE [MovCod] = @MvAMov ",true, GxErrorMask.GX_NOMASK, false, this,prmT001429,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001430", "SELECT [AlmSts] AS MVAlmSts, [AlmDsc] AS MvAlmDsc, [AlmCos] AS MvAlmCos FROM [CALMACEN] WHERE [AlmCod] = @MvAlm ",true, GxErrorMask.GX_NOMASK, false, this,prmT001430,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001431", "SELECT [CliDsc] AS MVCliDsc, [CliDir] AS MVCliDir FROM [CLCLIENTES] WHERE [CliCod] = @MVCliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001431,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001432", "SELECT [CliDirDir] AS MVCliOrigenDir FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @MVCliCod AND [CliDirItem] = @MVCliOrigen ",true, GxErrorMask.GX_NOMASK, false, this,prmT001432,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001433", "SELECT TOP 1 [TraMVATip], [TraMVACod] FROM [ATRANSFERENCIA] WHERE [TraMVATip] = @MvATip AND [TraMVACod] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001433,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001434", "SELECT TOP 1 [MvATip], [MvACod], [MvADItem] FROM [AGUIASDET] WHERE [MvATip] = @MvATip AND [MvACod] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001434,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001435", "SELECT TOP 1 [DesCod], [DesTipGuia], [DesGuia] FROM [ADESPACHODET] WHERE [DesTipGuia] = @MvATip AND [DesGuia] = @MvACod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001435,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001436", "SELECT [MvATip], [MvACod] FROM [AGUIAS] ORDER BY [MvATip], [MvACod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001436,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001437", "SELECT [TipCod] AS DocTip FROM [CLVENTAS] WHERE [TipCod] = @DocTip AND [DocNum] = @DocNum ",true, GxErrorMask.GX_NOMASK, false, this,prmT001437,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001438", "SELECT [PedCod] AS MVPedCod FROM [CLPEDIDOS] WHERE [PedCod] = @MVPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001438,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001439", "SELECT [ChoCod] FROM [CCHOFERES] WHERE [ChoCod] = @ChoCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001439,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001440", "SELECT [CliCod] AS MVCDesCod FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @MVCDesCod AND [CliDirItem] = @MVCDesItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001440,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001441", "SELECT [EmpTCod] FROM [CEMPTRANSPORTE] WHERE [EmpTCod] = @EmpTCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001441,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((short[]) buf[16])[0] = rslt.getShort(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((string[]) buf[19])[0] = rslt.getString(20, 20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((DateTime[]) buf[27])[0] = rslt.getGXDate(28);
              ((int[]) buf[28])[0] = rslt.getInt(29);
              ((int[]) buf[29])[0] = rslt.getInt(30);
              ((bool[]) buf[30])[0] = rslt.wasNull(30);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              ((int[]) buf[32])[0] = rslt.getInt(32);
              ((string[]) buf[33])[0] = rslt.getString(33, 3);
              ((bool[]) buf[34])[0] = rslt.wasNull(33);
              ((string[]) buf[35])[0] = rslt.getString(34, 10);
              ((bool[]) buf[36])[0] = rslt.wasNull(34);
              ((string[]) buf[37])[0] = rslt.getString(35, 20);
              ((bool[]) buf[38])[0] = rslt.wasNull(35);
              ((string[]) buf[39])[0] = rslt.getString(36, 20);
              ((bool[]) buf[40])[0] = rslt.wasNull(36);
              ((string[]) buf[41])[0] = rslt.getString(37, 12);
              ((bool[]) buf[42])[0] = rslt.wasNull(37);
              ((int[]) buf[43])[0] = rslt.getInt(38);
              ((bool[]) buf[44])[0] = rslt.wasNull(38);
              ((int[]) buf[45])[0] = rslt.getInt(39);
              ((bool[]) buf[46])[0] = rslt.wasNull(39);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              ((string[]) buf[9])[0] = rslt.getString(10, 1);
              ((int[]) buf[10])[0] = rslt.getInt(11);
              ((string[]) buf[11])[0] = rslt.getString(12, 20);
              ((string[]) buf[12])[0] = rslt.getString(13, 10);
              ((string[]) buf[13])[0] = rslt.getString(14, 10);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(15);
              ((short[]) buf[15])[0] = rslt.getShort(16);
              ((short[]) buf[16])[0] = rslt.getShort(17);
              ((int[]) buf[17])[0] = rslt.getInt(18);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((string[]) buf[19])[0] = rslt.getString(20, 20);
              ((string[]) buf[20])[0] = rslt.getVarchar(21);
              ((string[]) buf[21])[0] = rslt.getVarchar(22);
              ((string[]) buf[22])[0] = rslt.getVarchar(23);
              ((string[]) buf[23])[0] = rslt.getVarchar(24);
              ((string[]) buf[24])[0] = rslt.getVarchar(25);
              ((string[]) buf[25])[0] = rslt.getVarchar(26);
              ((string[]) buf[26])[0] = rslt.getVarchar(27);
              ((DateTime[]) buf[27])[0] = rslt.getGXDate(28);
              ((int[]) buf[28])[0] = rslt.getInt(29);
              ((int[]) buf[29])[0] = rslt.getInt(30);
              ((bool[]) buf[30])[0] = rslt.wasNull(30);
              ((int[]) buf[31])[0] = rslt.getInt(31);
              ((int[]) buf[32])[0] = rslt.getInt(32);
              ((string[]) buf[33])[0] = rslt.getString(33, 3);
              ((bool[]) buf[34])[0] = rslt.wasNull(33);
              ((string[]) buf[35])[0] = rslt.getString(34, 10);
              ((bool[]) buf[36])[0] = rslt.wasNull(34);
              ((string[]) buf[37])[0] = rslt.getString(35, 20);
              ((bool[]) buf[38])[0] = rslt.wasNull(35);
              ((string[]) buf[39])[0] = rslt.getString(36, 20);
              ((bool[]) buf[40])[0] = rslt.wasNull(36);
              ((string[]) buf[41])[0] = rslt.getString(37, 12);
              ((bool[]) buf[42])[0] = rslt.wasNull(37);
              ((int[]) buf[43])[0] = rslt.getInt(38);
              ((bool[]) buf[44])[0] = rslt.wasNull(38);
              ((int[]) buf[45])[0] = rslt.getInt(39);
              ((bool[]) buf[46])[0] = rslt.wasNull(39);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 5 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 100);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((string[]) buf[10])[0] = rslt.getString(11, 1);
              ((int[]) buf[11])[0] = rslt.getInt(12);
              ((string[]) buf[12])[0] = rslt.getString(13, 100);
              ((string[]) buf[13])[0] = rslt.getString(14, 100);
              ((string[]) buf[14])[0] = rslt.getString(15, 100);
              ((string[]) buf[15])[0] = rslt.getString(16, 1);
              ((int[]) buf[16])[0] = rslt.getInt(17);
              ((string[]) buf[17])[0] = rslt.getString(18, 20);
              ((string[]) buf[18])[0] = rslt.getString(19, 10);
              ((string[]) buf[19])[0] = rslt.getString(20, 10);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(21);
              ((string[]) buf[21])[0] = rslt.getString(22, 100);
              ((short[]) buf[22])[0] = rslt.getShort(23);
              ((short[]) buf[23])[0] = rslt.getShort(24);
              ((short[]) buf[24])[0] = rslt.getShort(25);
              ((int[]) buf[25])[0] = rslt.getInt(26);
              ((string[]) buf[26])[0] = rslt.getString(27, 10);
              ((string[]) buf[27])[0] = rslt.getString(28, 20);
              ((string[]) buf[28])[0] = rslt.getVarchar(29);
              ((string[]) buf[29])[0] = rslt.getVarchar(30);
              ((string[]) buf[30])[0] = rslt.getVarchar(31);
              ((string[]) buf[31])[0] = rslt.getVarchar(32);
              ((string[]) buf[32])[0] = rslt.getVarchar(33);
              ((string[]) buf[33])[0] = rslt.getVarchar(34);
              ((string[]) buf[34])[0] = rslt.getVarchar(35);
              ((DateTime[]) buf[35])[0] = rslt.getGXDate(36);
              ((int[]) buf[36])[0] = rslt.getInt(37);
              ((int[]) buf[37])[0] = rslt.getInt(38);
              ((bool[]) buf[38])[0] = rslt.wasNull(38);
              ((int[]) buf[39])[0] = rslt.getInt(39);
              ((int[]) buf[40])[0] = rslt.getInt(40);
              ((string[]) buf[41])[0] = rslt.getString(41, 3);
              ((bool[]) buf[42])[0] = rslt.wasNull(41);
              ((string[]) buf[43])[0] = rslt.getString(42, 10);
              ((bool[]) buf[44])[0] = rslt.wasNull(42);
              ((string[]) buf[45])[0] = rslt.getString(43, 20);
              ((bool[]) buf[46])[0] = rslt.wasNull(43);
              ((string[]) buf[47])[0] = rslt.getString(44, 20);
              ((bool[]) buf[48])[0] = rslt.wasNull(44);
              ((string[]) buf[49])[0] = rslt.getString(45, 12);
              ((bool[]) buf[50])[0] = rslt.wasNull(45);
              ((int[]) buf[51])[0] = rslt.getInt(46);
              ((bool[]) buf[52])[0] = rslt.wasNull(46);
              ((int[]) buf[53])[0] = rslt.getInt(47);
              ((bool[]) buf[54])[0] = rslt.wasNull(47);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 20 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 28 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
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
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 12);
              return;
           case 34 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 37 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 38 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 39 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
