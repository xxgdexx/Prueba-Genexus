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
   public class aproductos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A52LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A52LinCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A51SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
            n51SublCod = false;
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A51SublCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A50FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
            n50FamCod = false;
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A50FamCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
         {
            A49UniCod = (int)(NumberUtil.Val( GetPar( "UniCod"), "."));
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_8( A49UniCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A48ProdCuentaV = GetPar( "ProdCuentaV");
            n48ProdCuentaV = false;
            AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A48ProdCuentaV) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A53ProdCuentaC = GetPar( "ProdCuentaC");
            n53ProdCuentaC = false;
            AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A53ProdCuentaC) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_13") == 0 )
         {
            A54ProdCuentaA = GetPar( "ProdCuentaA");
            n54ProdCuentaA = false;
            AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_13( A54ProdCuentaA) ;
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
            Form.Meta.addItem("description", "Productos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aproductos( IGxContext context )
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
         chkProdVta = new GXCheckbox();
         chkProdCmp = new GXCheckbox();
         cmbProdSts = new GXCombobox();
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
         A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
         A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
         if ( cmbProdSts.ItemCount > 0 )
         {
            A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            AssignProp("", false, cmbProdSts_Internalname, "Values", cmbProdSts.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_APRODUCTOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Producto", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo de Linea", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtLinCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Descripcion producto", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdDsc_Internalname, StringUtil.RTrim( A55ProdDsc), StringUtil.RTrim( context.localUtil.Format( A55ProdDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Codigo Sub Linea", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtSublCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSublCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Familia", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFamCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtFamCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFamCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo Unidad Medida", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUniCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtUniCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUniCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUniCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Destinado Venta", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProdVta_Internalname, StringUtil.Str( (decimal)(A1724ProdVta), 1, 0), "", "", 1, chkProdVta.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(51, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Destinado Compra", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkProdCmp_Internalname, StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0), "", "", 1, chkProdCmp.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(56, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Peso producto", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdPeso_Internalname, StringUtil.LTrim( StringUtil.NToC( A1702ProdPeso, 15, 5, ".", "")), StringUtil.LTrim( ((edtProdPeso_Enabled!=0) ? context.localUtil.Format( A1702ProdPeso, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1702ProdPeso, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdPeso_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdPeso_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Volumen producto", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdVolumen_Internalname, StringUtil.LTrim( StringUtil.NToC( A1723ProdVolumen, 15, 5, ".", "")), StringUtil.LTrim( ((edtProdVolumen_Enabled!=0) ? context.localUtil.Format( A1723ProdVolumen, "ZZZZZZZZ9.99999") : context.localUtil.Format( A1723ProdVolumen, "ZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdVolumen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdVolumen_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Stock Maximo", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdStkMax_Internalname, StringUtil.LTrim( StringUtil.NToC( A1716ProdStkMax, 17, 4, ".", "")), StringUtil.LTrim( ((edtProdStkMax_Enabled!=0) ? context.localUtil.Format( A1716ProdStkMax, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1716ProdStkMax, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdStkMax_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdStkMax_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Stock Minimo", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdStkMin_Internalname, StringUtil.LTrim( StringUtil.NToC( A1717ProdStkMin, 17, 4, ".", "")), StringUtil.LTrim( ((edtProdStkMin_Enabled!=0) ? context.localUtil.Format( A1717ProdStkMin, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1717ProdStkMin, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdStkMin_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdStkMin_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "Foto Producto", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         A1695ProdFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.PathToRelativeUrl( A1695ProdFoto));
         GxWebStd.gx_bitmap( context, imgProdFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProdFoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,81);\"", "", "", "", 0, A1695ProdFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_APRODUCTOS.htm");
         AssignProp("", false, imgProdFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.PathToRelativeUrl( A1695ProdFoto)), true);
         AssignProp("", false, imgProdFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A1695ProdFoto_IsBlob), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Referencia 1", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef1_Internalname, StringUtil.RTrim( A1705ProdRef1), StringUtil.RTrim( context.localUtil.Format( A1705ProdRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Referencia 2", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef2_Internalname, StringUtil.RTrim( A1707ProdRef2), StringUtil.RTrim( context.localUtil.Format( A1707ProdRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Referencia 3", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef3_Internalname, StringUtil.RTrim( A1708ProdRef3), StringUtil.RTrim( context.localUtil.Format( A1708ProdRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Referencia 4", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef4_Internalname, StringUtil.RTrim( A1709ProdRef4), StringUtil.RTrim( context.localUtil.Format( A1709ProdRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Referencia 5", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef5_Internalname, StringUtil.RTrim( A1710ProdRef5), StringUtil.RTrim( context.localUtil.Format( A1710ProdRef5, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef5_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef5_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Referencia 6", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef6_Internalname, StringUtil.RTrim( A1711ProdRef6), StringUtil.RTrim( context.localUtil.Format( A1711ProdRef6, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef6_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef6_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Referencia 7", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef7_Internalname, StringUtil.RTrim( A1712ProdRef7), StringUtil.RTrim( context.localUtil.Format( A1712ProdRef7, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef7_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef7_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Referencia 8", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef8_Internalname, StringUtil.RTrim( A1713ProdRef8), StringUtil.RTrim( context.localUtil.Format( A1713ProdRef8, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef8_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef8_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock22_Internalname, "Referencia 9", "", "", lblTextblock22_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef9_Internalname, StringUtil.RTrim( A1714ProdRef9), StringUtil.RTrim( context.localUtil.Format( A1714ProdRef9, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,126);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef9_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef9_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock23_Internalname, "Referencia 10", "", "", lblTextblock23_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 131,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdRef10_Internalname, StringUtil.RTrim( A1706ProdRef10), StringUtil.RTrim( context.localUtil.Format( A1706ProdRef10, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,131);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdRef10_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdRef10_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock24_Internalname, "Situacion", "", "", lblTextblock24_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 136,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbProdSts, cmbProdSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0)), 1, cmbProdSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbProdSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,136);\"", "", true, 1, "HLP_APRODUCTOS.htm");
         cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         AssignProp("", false, cmbProdSts_Internalname, "Values", (string)(cmbProdSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock25_Internalname, "Ult. Costo MN", "", "", lblTextblock25_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 141,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCosto_Internalname, StringUtil.LTrim( StringUtil.NToC( A1681ProdCosto, 18, 5, ".", "")), StringUtil.LTrim( ((edtProdCosto_Enabled!=0) ? context.localUtil.Format( A1681ProdCosto, "ZZZZZZZZZZZ9.99999") : context.localUtil.Format( A1681ProdCosto, "ZZZZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,141);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCosto_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCosto_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock26_Internalname, "Fecha Ult. Costo", "", "", lblTextblock26_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 146,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProdCostoFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProdCostoFec_Internalname, context.localUtil.Format(A1683ProdCostoFec, "99/99/99"), context.localUtil.Format( A1683ProdCostoFec, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'spa',false,0);"+";gx.evt.onblur(this,146);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCostoFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCostoFec_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         GxWebStd.gx_bitmap( context, edtProdCostoFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProdCostoFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock27_Internalname, "Ult. Costo ME", "", "", lblTextblock27_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 151,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCostoD_Internalname, StringUtil.LTrim( StringUtil.NToC( A1682ProdCostoD, 18, 5, ".", "")), StringUtil.LTrim( ((edtProdCostoD_Enabled!=0) ? context.localUtil.Format( A1682ProdCostoD, "ZZZZZZZZZZZ9.99999") : context.localUtil.Format( A1682ProdCostoD, "ZZZZZZZZZZZ9.99999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','5');"+";gx.evt.onblur(this,151);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCostoD_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCostoD_Enabled, 0, "text", "", 18, "chr", 1, "row", 18, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock28_Internalname, "Inafecta IGV", "", "", lblTextblock28_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 156,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdIna_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1698ProdIna), 1, 0, ".", "")), StringUtil.LTrim( ((edtProdIna_Enabled!=0) ? context.localUtil.Format( (decimal)(A1698ProdIna), "9") : context.localUtil.Format( (decimal)(A1698ProdIna), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,156);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdIna_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdIna_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock29_Internalname, "% Impuesto Selectivo", "", "", lblTextblock29_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 161,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdPorSel_Internalname, StringUtil.LTrim( StringUtil.NToC( A1703ProdPorSel, 6, 2, ".", "")), StringUtil.LTrim( ((edtProdPorSel_Enabled!=0) ? context.localUtil.Format( A1703ProdPorSel, "ZZ9.99") : context.localUtil.Format( A1703ProdPorSel, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,161);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdPorSel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdPorSel_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock30_Internalname, "% AdValorem", "", "", lblTextblock30_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 166,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdAdValor_Internalname, StringUtil.LTrim( StringUtil.NToC( A1672ProdAdValor, 6, 2, ".", "")), StringUtil.LTrim( ((edtProdAdValor_Enabled!=0) ? context.localUtil.Format( A1672ProdAdValor, "ZZ9.99") : context.localUtil.Format( A1672ProdAdValor, "ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,166);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdAdValor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdAdValor_Enabled, 0, "text", "", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "Porcentaje", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock31_Internalname, "Referencias", "", "", lblTextblock31_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtProdReferencias_Internalname, A1715ProdReferencias, "", "", 0, 1, edtProdReferencias_Enabled, 0, 80, "chr", 3, "row", StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock32_Internalname, "Producto Frecuente", "", "", lblTextblock32_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 176,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdFrecuente_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1696ProdFrecuente), 1, 0, ".", "")), StringUtil.LTrim( ((edtProdFrecuente_Enabled!=0) ? context.localUtil.Format( (decimal)(A1696ProdFrecuente), "9") : context.localUtil.Format( (decimal)(A1696ProdFrecuente), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,176);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdFrecuente_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdFrecuente_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock33_Internalname, "Cuenta Venta", "", "", lblTextblock33_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 181,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCuentaV_Internalname, StringUtil.RTrim( A48ProdCuentaV), StringUtil.RTrim( context.localUtil.Format( A48ProdCuentaV, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,181);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaV_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaV_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock34_Internalname, "Descripción Cuenta Venta", "", "", lblTextblock34_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdCuentaVDsc_Internalname, StringUtil.RTrim( A1686ProdCuentaVDsc), StringUtil.RTrim( context.localUtil.Format( A1686ProdCuentaVDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaVDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaVDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock35_Internalname, "Cuenta Compras", "", "", lblTextblock35_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 191,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCuentaC_Internalname, StringUtil.RTrim( A53ProdCuentaC), StringUtil.RTrim( context.localUtil.Format( A53ProdCuentaC, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,191);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaC_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaC_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock36_Internalname, "Descripción Cuenta Compra", "", "", lblTextblock36_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdCuentaCDsc_Internalname, StringUtil.RTrim( A1685ProdCuentaCDsc), StringUtil.RTrim( context.localUtil.Format( A1685ProdCuentaCDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaCDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaCDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock37_Internalname, "Cuenta Almacen", "", "", lblTextblock37_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 201,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCuentaA_Internalname, StringUtil.RTrim( A54ProdCuentaA), StringUtil.RTrim( context.localUtil.Format( A54ProdCuentaA, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,201);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaA_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaA_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock38_Internalname, "Descripción Cuenta Almacen", "", "", lblTextblock38_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtProdCuentaADsc_Internalname, StringUtil.RTrim( A1684ProdCuentaADsc), StringUtil.RTrim( context.localUtil.Format( A1684ProdCuentaADsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCuentaADsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCuentaADsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock39_Internalname, "Usuario", "", "", lblTextblock39_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 211,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdUsuCod_Internalname, StringUtil.RTrim( A1721ProdUsuCod), StringUtil.RTrim( context.localUtil.Format( A1721ProdUsuCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,211);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdUsuCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdUsuCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock40_Internalname, "Usuario Fecha", "", "", lblTextblock40_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 216,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtProdUsuFec_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtProdUsuFec_Internalname, context.localUtil.TToC( A1722ProdUsuFec, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A1722ProdUsuFec, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'spa',false,0);"+";gx.evt.onblur(this,216);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdUsuFec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdUsuFec_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         GxWebStd.gx_bitmap( context, edtProdUsuFec_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtProdUsuFec_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlTextNl( "</div>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock41_Internalname, "Inafecto", "", "", lblTextblock41_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 221,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdAfec_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1673ProdAfec), 1, 0, ".", "")), StringUtil.LTrim( ((edtProdAfec_Enabled!=0) ? context.localUtil.Format( (decimal)(A1673ProdAfec), "9") : context.localUtil.Format( (decimal)(A1673ProdAfec), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,221);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdAfec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdAfec_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APRODUCTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 224,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 225,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 226,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 227,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 228,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_APRODUCTOS.htm");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z28ProdCod = cgiGet( "Z28ProdCod");
               Z55ProdDsc = cgiGet( "Z55ProdDsc");
               Z1724ProdVta = (short)(context.localUtil.CToN( cgiGet( "Z1724ProdVta"), ".", ","));
               Z1679ProdCmp = (short)(context.localUtil.CToN( cgiGet( "Z1679ProdCmp"), ".", ","));
               Z1702ProdPeso = context.localUtil.CToN( cgiGet( "Z1702ProdPeso"), ".", ",");
               Z1723ProdVolumen = context.localUtil.CToN( cgiGet( "Z1723ProdVolumen"), ".", ",");
               Z1716ProdStkMax = context.localUtil.CToN( cgiGet( "Z1716ProdStkMax"), ".", ",");
               Z1717ProdStkMin = context.localUtil.CToN( cgiGet( "Z1717ProdStkMin"), ".", ",");
               Z1705ProdRef1 = cgiGet( "Z1705ProdRef1");
               Z1707ProdRef2 = cgiGet( "Z1707ProdRef2");
               Z1708ProdRef3 = cgiGet( "Z1708ProdRef3");
               Z1709ProdRef4 = cgiGet( "Z1709ProdRef4");
               Z1710ProdRef5 = cgiGet( "Z1710ProdRef5");
               Z1711ProdRef6 = cgiGet( "Z1711ProdRef6");
               Z1712ProdRef7 = cgiGet( "Z1712ProdRef7");
               Z1713ProdRef8 = cgiGet( "Z1713ProdRef8");
               Z1714ProdRef9 = cgiGet( "Z1714ProdRef9");
               Z1706ProdRef10 = cgiGet( "Z1706ProdRef10");
               Z1718ProdSts = (short)(context.localUtil.CToN( cgiGet( "Z1718ProdSts"), ".", ","));
               Z1681ProdCosto = context.localUtil.CToN( cgiGet( "Z1681ProdCosto"), ".", ",");
               Z1683ProdCostoFec = context.localUtil.CToD( cgiGet( "Z1683ProdCostoFec"), 0);
               Z1682ProdCostoD = context.localUtil.CToN( cgiGet( "Z1682ProdCostoD"), ".", ",");
               Z1698ProdIna = (short)(context.localUtil.CToN( cgiGet( "Z1698ProdIna"), ".", ","));
               Z1703ProdPorSel = context.localUtil.CToN( cgiGet( "Z1703ProdPorSel"), ".", ",");
               Z1697ProdImpSel = context.localUtil.CToN( cgiGet( "Z1697ProdImpSel"), ".", ",");
               Z1672ProdAdValor = context.localUtil.CToN( cgiGet( "Z1672ProdAdValor"), ".", ",");
               Z1696ProdFrecuente = (short)(context.localUtil.CToN( cgiGet( "Z1696ProdFrecuente"), ".", ","));
               Z1721ProdUsuCod = cgiGet( "Z1721ProdUsuCod");
               Z1722ProdUsuFec = context.localUtil.CToT( cgiGet( "Z1722ProdUsuFec"), 0);
               Z1673ProdAfec = (short)(context.localUtil.CToN( cgiGet( "Z1673ProdAfec"), ".", ","));
               Z1701ProdObs = cgiGet( "Z1701ProdObs");
               Z1675ProdCanLote = context.localUtil.CToN( cgiGet( "Z1675ProdCanLote"), ".", ",");
               Z1674ProdBarra = cgiGet( "Z1674ProdBarra");
               Z1689ProdExportacion = cgiGet( "Z1689ProdExportacion");
               Z906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "Z906ProdAfecICBPER"), ".", ","));
               Z907ProdValICBPER = context.localUtil.CToN( cgiGet( "Z907ProdValICBPER"), ".", ",");
               Z908ProdValICBPERD = context.localUtil.CToN( cgiGet( "Z908ProdValICBPERD"), ".", ",");
               Z52LinCod = (int)(context.localUtil.CToN( cgiGet( "Z52LinCod"), ".", ","));
               Z51SublCod = (int)(context.localUtil.CToN( cgiGet( "Z51SublCod"), ".", ","));
               n51SublCod = ((0==A51SublCod) ? true : false);
               Z50FamCod = (int)(context.localUtil.CToN( cgiGet( "Z50FamCod"), ".", ","));
               n50FamCod = ((0==A50FamCod) ? true : false);
               Z49UniCod = (int)(context.localUtil.CToN( cgiGet( "Z49UniCod"), ".", ","));
               Z47CBSuCod = cgiGet( "Z47CBSuCod");
               n47CBSuCod = (String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ? true : false);
               Z46cDetCod = (int)(context.localUtil.CToN( cgiGet( "Z46cDetCod"), ".", ","));
               n46cDetCod = ((0==A46cDetCod) ? true : false);
               Z48ProdCuentaV = cgiGet( "Z48ProdCuentaV");
               n48ProdCuentaV = (String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ? true : false);
               Z53ProdCuentaC = cgiGet( "Z53ProdCuentaC");
               n53ProdCuentaC = (String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ? true : false);
               Z54ProdCuentaA = cgiGet( "Z54ProdCuentaA");
               n54ProdCuentaA = (String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ? true : false);
               A1697ProdImpSel = context.localUtil.CToN( cgiGet( "Z1697ProdImpSel"), ".", ",");
               A1701ProdObs = cgiGet( "Z1701ProdObs");
               A1675ProdCanLote = context.localUtil.CToN( cgiGet( "Z1675ProdCanLote"), ".", ",");
               A1674ProdBarra = cgiGet( "Z1674ProdBarra");
               A1689ProdExportacion = cgiGet( "Z1689ProdExportacion");
               A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "Z906ProdAfecICBPER"), ".", ","));
               A907ProdValICBPER = context.localUtil.CToN( cgiGet( "Z907ProdValICBPER"), ".", ",");
               A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "Z908ProdValICBPERD"), ".", ",");
               A47CBSuCod = cgiGet( "Z47CBSuCod");
               n47CBSuCod = false;
               n47CBSuCod = (String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ? true : false);
               A46cDetCod = (int)(context.localUtil.CToN( cgiGet( "Z46cDetCod"), ".", ","));
               n46cDetCod = false;
               n46cDetCod = ((0==A46cDetCod) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               A40000ProdFoto_GXI = cgiGet( "PRODFOTO_GXI");
               n40000ProdFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               A1697ProdImpSel = context.localUtil.CToN( cgiGet( "PRODIMPSEL"), ".", ",");
               A1701ProdObs = cgiGet( "PRODOBS");
               A1675ProdCanLote = context.localUtil.CToN( cgiGet( "PRODCANLOTE"), ".", ",");
               A1674ProdBarra = cgiGet( "PRODBARRA");
               A1689ProdExportacion = cgiGet( "PRODEXPORTACION");
               A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "PRODAFECICBPER"), ".", ","));
               A907ProdValICBPER = context.localUtil.CToN( cgiGet( "PRODVALICBPER"), ".", ",");
               A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "PRODVALICBPERD"), ".", ",");
               A47CBSuCod = cgiGet( "CBSUCOD");
               n47CBSuCod = (String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ? true : false);
               A46cDetCod = (int)(context.localUtil.CToN( cgiGet( "CDETCOD"), ".", ","));
               n46cDetCod = ((0==A46cDetCod) ? true : false);
               /* Read variables values. */
               A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A52LinCod = 0;
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               }
               else
               {
                  A52LinCod = (int)(context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ","));
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               }
               A55ProdDsc = cgiGet( edtProdDsc_Internalname);
               AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
               if ( ( ( context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUBLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A51SublCod = 0;
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               }
               else
               {
                  A51SublCod = (int)(context.localUtil.CToN( cgiGet( edtSublCod_Internalname), ".", ","));
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               }
               n51SublCod = ((0==A51SublCod) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FAMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A50FamCod = 0;
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               else
               {
                  A50FamCod = (int)(context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ","));
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               n50FamCod = ((0==A50FamCod) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "UNICOD");
                  AnyError = 1;
                  GX_FocusControl = edtUniCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A49UniCod = 0;
                  AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
               }
               else
               {
                  A49UniCod = (int)(context.localUtil.CToN( cgiGet( edtUniCod_Internalname), ".", ","));
                  AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODVTA");
                  AnyError = 1;
                  GX_FocusControl = chkProdVta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1724ProdVta = 0;
                  AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
               }
               else
               {
                  A1724ProdVta = (short)(((StringUtil.StrCmp(cgiGet( chkProdVta_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCMP");
                  AnyError = 1;
                  GX_FocusControl = chkProdCmp_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1679ProdCmp = 0;
                  AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
               }
               else
               {
                  A1679ProdCmp = (short)(((StringUtil.StrCmp(cgiGet( chkProdCmp_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdPeso_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdPeso_Internalname), ".", ",") > 999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODPESO");
                  AnyError = 1;
                  GX_FocusControl = edtProdPeso_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1702ProdPeso = 0;
                  AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
               }
               else
               {
                  A1702ProdPeso = context.localUtil.CToN( cgiGet( edtProdPeso_Internalname), ".", ",");
                  AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdVolumen_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdVolumen_Internalname), ".", ",") > 999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODVOLUMEN");
                  AnyError = 1;
                  GX_FocusControl = edtProdVolumen_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1723ProdVolumen = 0;
                  AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
               }
               else
               {
                  A1723ProdVolumen = context.localUtil.CToN( cgiGet( edtProdVolumen_Internalname), ".", ",");
                  AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdStkMax_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdStkMax_Internalname), ".", ",") > 9999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODSTKMAX");
                  AnyError = 1;
                  GX_FocusControl = edtProdStkMax_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1716ProdStkMax = 0;
                  AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
               }
               else
               {
                  A1716ProdStkMax = context.localUtil.CToN( cgiGet( edtProdStkMax_Internalname), ".", ",");
                  AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdStkMin_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdStkMin_Internalname), ".", ",") > 9999999999.9999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODSTKMIN");
                  AnyError = 1;
                  GX_FocusControl = edtProdStkMin_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1717ProdStkMin = 0;
                  AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
               }
               else
               {
                  A1717ProdStkMin = context.localUtil.CToN( cgiGet( edtProdStkMin_Internalname), ".", ",");
                  AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
               }
               A1695ProdFoto = cgiGet( imgProdFoto_Internalname);
               n1695ProdFoto = false;
               AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
               n1695ProdFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               A1705ProdRef1 = cgiGet( edtProdRef1_Internalname);
               AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
               A1707ProdRef2 = cgiGet( edtProdRef2_Internalname);
               AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
               A1708ProdRef3 = cgiGet( edtProdRef3_Internalname);
               AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
               A1709ProdRef4 = cgiGet( edtProdRef4_Internalname);
               AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
               A1710ProdRef5 = cgiGet( edtProdRef5_Internalname);
               AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
               A1711ProdRef6 = cgiGet( edtProdRef6_Internalname);
               AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
               A1712ProdRef7 = cgiGet( edtProdRef7_Internalname);
               AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
               A1713ProdRef8 = cgiGet( edtProdRef8_Internalname);
               AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
               A1714ProdRef9 = cgiGet( edtProdRef9_Internalname);
               AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
               A1706ProdRef10 = cgiGet( edtProdRef10_Internalname);
               AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
               cmbProdSts.CurrentValue = cgiGet( cmbProdSts_Internalname);
               A1718ProdSts = (short)(NumberUtil.Val( cgiGet( cmbProdSts_Internalname), "."));
               AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdCosto_Internalname), ".", ",") < -99999999999.99999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtProdCosto_Internalname), ".", ",") > 999999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCOSTO");
                  AnyError = 1;
                  GX_FocusControl = edtProdCosto_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1681ProdCosto = 0;
                  AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
               }
               else
               {
                  A1681ProdCosto = context.localUtil.CToN( cgiGet( edtProdCosto_Internalname), ".", ",");
                  AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
               }
               if ( context.localUtil.VCDate( cgiGet( edtProdCostoFec_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Fecha Ult. Costo"}), 1, "PRODCOSTOFEC");
                  AnyError = 1;
                  GX_FocusControl = edtProdCostoFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1683ProdCostoFec = DateTime.MinValue;
                  AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
               }
               else
               {
                  A1683ProdCostoFec = context.localUtil.CToD( cgiGet( edtProdCostoFec_Internalname), 2);
                  AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdCostoD_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdCostoD_Internalname), ".", ",") > 999999999999.99999m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODCOSTOD");
                  AnyError = 1;
                  GX_FocusControl = edtProdCostoD_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1682ProdCostoD = 0;
                  AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
               }
               else
               {
                  A1682ProdCostoD = context.localUtil.CToN( cgiGet( edtProdCostoD_Internalname), ".", ",");
                  AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdIna_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdIna_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODINA");
                  AnyError = 1;
                  GX_FocusControl = edtProdIna_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1698ProdIna = 0;
                  AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
               }
               else
               {
                  A1698ProdIna = (short)(context.localUtil.CToN( cgiGet( edtProdIna_Internalname), ".", ","));
                  AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdPorSel_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdPorSel_Internalname), ".", ",") > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODPORSEL");
                  AnyError = 1;
                  GX_FocusControl = edtProdPorSel_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1703ProdPorSel = 0;
                  AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
               }
               else
               {
                  A1703ProdPorSel = context.localUtil.CToN( cgiGet( edtProdPorSel_Internalname), ".", ",");
                  AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdAdValor_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdAdValor_Internalname), ".", ",") > 999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODADVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtProdAdValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1672ProdAdValor = 0;
                  AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
               }
               else
               {
                  A1672ProdAdValor = context.localUtil.CToN( cgiGet( edtProdAdValor_Internalname), ".", ",");
                  AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
               }
               A1715ProdReferencias = cgiGet( edtProdReferencias_Internalname);
               AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdFrecuente_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdFrecuente_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODFRECUENTE");
                  AnyError = 1;
                  GX_FocusControl = edtProdFrecuente_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1696ProdFrecuente = 0;
                  AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
               }
               else
               {
                  A1696ProdFrecuente = (short)(context.localUtil.CToN( cgiGet( edtProdFrecuente_Internalname), ".", ","));
                  AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
               }
               A48ProdCuentaV = cgiGet( edtProdCuentaV_Internalname);
               n48ProdCuentaV = false;
               AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
               n48ProdCuentaV = (String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ? true : false);
               A1686ProdCuentaVDsc = cgiGet( edtProdCuentaVDsc_Internalname);
               AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
               A53ProdCuentaC = cgiGet( edtProdCuentaC_Internalname);
               n53ProdCuentaC = false;
               AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
               n53ProdCuentaC = (String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ? true : false);
               A1685ProdCuentaCDsc = cgiGet( edtProdCuentaCDsc_Internalname);
               AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
               A54ProdCuentaA = cgiGet( edtProdCuentaA_Internalname);
               n54ProdCuentaA = false;
               AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
               n54ProdCuentaA = (String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ? true : false);
               A1684ProdCuentaADsc = cgiGet( edtProdCuentaADsc_Internalname);
               AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
               A1721ProdUsuCod = cgiGet( edtProdUsuCod_Internalname);
               AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
               if ( context.localUtil.VCDateTime( cgiGet( edtProdUsuFec_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Usuario Fecha"}), 1, "PRODUSUFEC");
                  AnyError = 1;
                  GX_FocusControl = edtProdUsuFec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1722ProdUsuFec = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A1722ProdUsuFec = context.localUtil.CToT( cgiGet( edtProdUsuFec_Internalname));
                  AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdAfec_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdAfec_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODAFEC");
                  AnyError = 1;
                  GX_FocusControl = edtProdAfec_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1673ProdAfec = 0;
                  AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
               }
               else
               {
                  A1673ProdAfec = (short)(context.localUtil.CToN( cgiGet( edtProdAfec_Internalname), ".", ","));
                  AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProdFoto_Internalname, ref  A1695ProdFoto, ref  A40000ProdFoto_GXI);
               n40000ProdFoto_GXI = (String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdFoto_GXI))&&String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               n1695ProdFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"APRODUCTOS");
               forbiddenHiddens.Add("ProdImpSel", context.localUtil.Format( A1697ProdImpSel, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("ProdObs", StringUtil.RTrim( context.localUtil.Format( A1701ProdObs, "")));
               forbiddenHiddens.Add("ProdCanLote", context.localUtil.Format( A1675ProdCanLote, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("ProdBarra", StringUtil.RTrim( context.localUtil.Format( A1674ProdBarra, "")));
               forbiddenHiddens.Add("ProdExportacion", StringUtil.RTrim( context.localUtil.Format( A1689ProdExportacion, "")));
               forbiddenHiddens.Add("CBSuCod", StringUtil.RTrim( context.localUtil.Format( A47CBSuCod, "")));
               forbiddenHiddens.Add("ProdAfecICBPER", context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9"));
               forbiddenHiddens.Add("ProdValICBPER", context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("ProdValICBPERD", context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99"));
               forbiddenHiddens.Add("cDetCod", context.localUtil.Format( (decimal)(A46cDetCod), "ZZZZZ9"));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("aproductos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A28ProdCod = GetPar( "ProdCod");
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E111A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E121A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
            /* Execute user event: After Trn */
            E121A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1A44( ) ;
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
         DisableAttributes1A44( ) ;
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

      protected void CONFIRM_1A0( )
      {
         BeforeValidate1A44( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1A44( ) ;
            }
            else
            {
               CheckExtendedTable1A44( ) ;
               if ( AnyError == 0 )
               {
                  ZM1A44( 5) ;
                  ZM1A44( 6) ;
                  ZM1A44( 7) ;
                  ZM1A44( 8) ;
                  ZM1A44( 9) ;
                  ZM1A44( 10) ;
                  ZM1A44( 11) ;
                  ZM1A44( 12) ;
                  ZM1A44( 13) ;
               }
               CloseExtendedTableCursors1A44( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1A0( ) ;
         }
      }

      protected void ResetCaption1A0( )
      {
      }

      protected void E111A2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E121A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1A44( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z55ProdDsc = T001A3_A55ProdDsc[0];
               Z1724ProdVta = T001A3_A1724ProdVta[0];
               Z1679ProdCmp = T001A3_A1679ProdCmp[0];
               Z1702ProdPeso = T001A3_A1702ProdPeso[0];
               Z1723ProdVolumen = T001A3_A1723ProdVolumen[0];
               Z1716ProdStkMax = T001A3_A1716ProdStkMax[0];
               Z1717ProdStkMin = T001A3_A1717ProdStkMin[0];
               Z1705ProdRef1 = T001A3_A1705ProdRef1[0];
               Z1707ProdRef2 = T001A3_A1707ProdRef2[0];
               Z1708ProdRef3 = T001A3_A1708ProdRef3[0];
               Z1709ProdRef4 = T001A3_A1709ProdRef4[0];
               Z1710ProdRef5 = T001A3_A1710ProdRef5[0];
               Z1711ProdRef6 = T001A3_A1711ProdRef6[0];
               Z1712ProdRef7 = T001A3_A1712ProdRef7[0];
               Z1713ProdRef8 = T001A3_A1713ProdRef8[0];
               Z1714ProdRef9 = T001A3_A1714ProdRef9[0];
               Z1706ProdRef10 = T001A3_A1706ProdRef10[0];
               Z1718ProdSts = T001A3_A1718ProdSts[0];
               Z1681ProdCosto = T001A3_A1681ProdCosto[0];
               Z1683ProdCostoFec = T001A3_A1683ProdCostoFec[0];
               Z1682ProdCostoD = T001A3_A1682ProdCostoD[0];
               Z1698ProdIna = T001A3_A1698ProdIna[0];
               Z1703ProdPorSel = T001A3_A1703ProdPorSel[0];
               Z1697ProdImpSel = T001A3_A1697ProdImpSel[0];
               Z1672ProdAdValor = T001A3_A1672ProdAdValor[0];
               Z1696ProdFrecuente = T001A3_A1696ProdFrecuente[0];
               Z1721ProdUsuCod = T001A3_A1721ProdUsuCod[0];
               Z1722ProdUsuFec = T001A3_A1722ProdUsuFec[0];
               Z1673ProdAfec = T001A3_A1673ProdAfec[0];
               Z1701ProdObs = T001A3_A1701ProdObs[0];
               Z1675ProdCanLote = T001A3_A1675ProdCanLote[0];
               Z1674ProdBarra = T001A3_A1674ProdBarra[0];
               Z1689ProdExportacion = T001A3_A1689ProdExportacion[0];
               Z906ProdAfecICBPER = T001A3_A906ProdAfecICBPER[0];
               Z907ProdValICBPER = T001A3_A907ProdValICBPER[0];
               Z908ProdValICBPERD = T001A3_A908ProdValICBPERD[0];
               Z52LinCod = T001A3_A52LinCod[0];
               Z51SublCod = T001A3_A51SublCod[0];
               Z50FamCod = T001A3_A50FamCod[0];
               Z49UniCod = T001A3_A49UniCod[0];
               Z47CBSuCod = T001A3_A47CBSuCod[0];
               Z46cDetCod = T001A3_A46cDetCod[0];
               Z48ProdCuentaV = T001A3_A48ProdCuentaV[0];
               Z53ProdCuentaC = T001A3_A53ProdCuentaC[0];
               Z54ProdCuentaA = T001A3_A54ProdCuentaA[0];
            }
            else
            {
               Z55ProdDsc = A55ProdDsc;
               Z1724ProdVta = A1724ProdVta;
               Z1679ProdCmp = A1679ProdCmp;
               Z1702ProdPeso = A1702ProdPeso;
               Z1723ProdVolumen = A1723ProdVolumen;
               Z1716ProdStkMax = A1716ProdStkMax;
               Z1717ProdStkMin = A1717ProdStkMin;
               Z1705ProdRef1 = A1705ProdRef1;
               Z1707ProdRef2 = A1707ProdRef2;
               Z1708ProdRef3 = A1708ProdRef3;
               Z1709ProdRef4 = A1709ProdRef4;
               Z1710ProdRef5 = A1710ProdRef5;
               Z1711ProdRef6 = A1711ProdRef6;
               Z1712ProdRef7 = A1712ProdRef7;
               Z1713ProdRef8 = A1713ProdRef8;
               Z1714ProdRef9 = A1714ProdRef9;
               Z1706ProdRef10 = A1706ProdRef10;
               Z1718ProdSts = A1718ProdSts;
               Z1681ProdCosto = A1681ProdCosto;
               Z1683ProdCostoFec = A1683ProdCostoFec;
               Z1682ProdCostoD = A1682ProdCostoD;
               Z1698ProdIna = A1698ProdIna;
               Z1703ProdPorSel = A1703ProdPorSel;
               Z1697ProdImpSel = A1697ProdImpSel;
               Z1672ProdAdValor = A1672ProdAdValor;
               Z1696ProdFrecuente = A1696ProdFrecuente;
               Z1721ProdUsuCod = A1721ProdUsuCod;
               Z1722ProdUsuFec = A1722ProdUsuFec;
               Z1673ProdAfec = A1673ProdAfec;
               Z1701ProdObs = A1701ProdObs;
               Z1675ProdCanLote = A1675ProdCanLote;
               Z1674ProdBarra = A1674ProdBarra;
               Z1689ProdExportacion = A1689ProdExportacion;
               Z906ProdAfecICBPER = A906ProdAfecICBPER;
               Z907ProdValICBPER = A907ProdValICBPER;
               Z908ProdValICBPERD = A908ProdValICBPERD;
               Z52LinCod = A52LinCod;
               Z51SublCod = A51SublCod;
               Z50FamCod = A50FamCod;
               Z49UniCod = A49UniCod;
               Z47CBSuCod = A47CBSuCod;
               Z46cDetCod = A46cDetCod;
               Z48ProdCuentaV = A48ProdCuentaV;
               Z53ProdCuentaC = A53ProdCuentaC;
               Z54ProdCuentaA = A54ProdCuentaA;
            }
         }
         if ( GX_JID == -4 )
         {
            Z28ProdCod = A28ProdCod;
            Z55ProdDsc = A55ProdDsc;
            Z1724ProdVta = A1724ProdVta;
            Z1679ProdCmp = A1679ProdCmp;
            Z1702ProdPeso = A1702ProdPeso;
            Z1723ProdVolumen = A1723ProdVolumen;
            Z1716ProdStkMax = A1716ProdStkMax;
            Z1717ProdStkMin = A1717ProdStkMin;
            Z1695ProdFoto = A1695ProdFoto;
            Z40000ProdFoto_GXI = A40000ProdFoto_GXI;
            Z1705ProdRef1 = A1705ProdRef1;
            Z1707ProdRef2 = A1707ProdRef2;
            Z1708ProdRef3 = A1708ProdRef3;
            Z1709ProdRef4 = A1709ProdRef4;
            Z1710ProdRef5 = A1710ProdRef5;
            Z1711ProdRef6 = A1711ProdRef6;
            Z1712ProdRef7 = A1712ProdRef7;
            Z1713ProdRef8 = A1713ProdRef8;
            Z1714ProdRef9 = A1714ProdRef9;
            Z1706ProdRef10 = A1706ProdRef10;
            Z1718ProdSts = A1718ProdSts;
            Z1681ProdCosto = A1681ProdCosto;
            Z1683ProdCostoFec = A1683ProdCostoFec;
            Z1682ProdCostoD = A1682ProdCostoD;
            Z1698ProdIna = A1698ProdIna;
            Z1703ProdPorSel = A1703ProdPorSel;
            Z1697ProdImpSel = A1697ProdImpSel;
            Z1672ProdAdValor = A1672ProdAdValor;
            Z1696ProdFrecuente = A1696ProdFrecuente;
            Z1721ProdUsuCod = A1721ProdUsuCod;
            Z1722ProdUsuFec = A1722ProdUsuFec;
            Z1673ProdAfec = A1673ProdAfec;
            Z1701ProdObs = A1701ProdObs;
            Z1675ProdCanLote = A1675ProdCanLote;
            Z1674ProdBarra = A1674ProdBarra;
            Z1689ProdExportacion = A1689ProdExportacion;
            Z906ProdAfecICBPER = A906ProdAfecICBPER;
            Z907ProdValICBPER = A907ProdValICBPER;
            Z908ProdValICBPERD = A908ProdValICBPERD;
            Z52LinCod = A52LinCod;
            Z51SublCod = A51SublCod;
            Z50FamCod = A50FamCod;
            Z49UniCod = A49UniCod;
            Z47CBSuCod = A47CBSuCod;
            Z46cDetCod = A46cDetCod;
            Z48ProdCuentaV = A48ProdCuentaV;
            Z53ProdCuentaC = A53ProdCuentaC;
            Z54ProdCuentaA = A54ProdCuentaA;
            Z1686ProdCuentaVDsc = A1686ProdCuentaVDsc;
            Z1685ProdCuentaCDsc = A1685ProdCuentaCDsc;
            Z1684ProdCuentaADsc = A1684ProdCuentaADsc;
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
         /* Using cursor T001A8 */
         pr_default.execute(6, new Object[] {n47CBSuCod, A47CBSuCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A47CBSuCod)) ) )
            {
               GX_msglist.addItem("No existe 'Productos Sunat'.", "ForeignKeyNotFound", 1, "CBSUCOD");
               AnyError = 1;
            }
         }
         pr_default.close(6);
         /* Using cursor T001A9 */
         pr_default.execute(7, new Object[] {n46cDetCod, A46cDetCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A46cDetCod) ) )
            {
               GX_msglist.addItem("No existe 'CDETRACCIONES'.", "ForeignKeyNotFound", 1, "CDETCOD");
               AnyError = 1;
            }
         }
         pr_default.close(7);
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

      protected void Load1A44( )
      {
         /* Using cursor T001A13 */
         pr_default.execute(11, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound44 = 1;
            A55ProdDsc = T001A13_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1724ProdVta = T001A13_A1724ProdVta[0];
            AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
            A1679ProdCmp = T001A13_A1679ProdCmp[0];
            AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
            A1702ProdPeso = T001A13_A1702ProdPeso[0];
            AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
            A1723ProdVolumen = T001A13_A1723ProdVolumen[0];
            AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
            A1716ProdStkMax = T001A13_A1716ProdStkMax[0];
            AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
            A1717ProdStkMin = T001A13_A1717ProdStkMin[0];
            AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
            A40000ProdFoto_GXI = T001A13_A40000ProdFoto_GXI[0];
            n40000ProdFoto_GXI = T001A13_n40000ProdFoto_GXI[0];
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            A1705ProdRef1 = T001A13_A1705ProdRef1[0];
            AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
            A1707ProdRef2 = T001A13_A1707ProdRef2[0];
            AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
            A1708ProdRef3 = T001A13_A1708ProdRef3[0];
            AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
            A1709ProdRef4 = T001A13_A1709ProdRef4[0];
            AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
            A1710ProdRef5 = T001A13_A1710ProdRef5[0];
            AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
            A1711ProdRef6 = T001A13_A1711ProdRef6[0];
            AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
            A1712ProdRef7 = T001A13_A1712ProdRef7[0];
            AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
            A1713ProdRef8 = T001A13_A1713ProdRef8[0];
            AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
            A1714ProdRef9 = T001A13_A1714ProdRef9[0];
            AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
            A1706ProdRef10 = T001A13_A1706ProdRef10[0];
            AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
            A1718ProdSts = T001A13_A1718ProdSts[0];
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            A1681ProdCosto = T001A13_A1681ProdCosto[0];
            AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
            A1683ProdCostoFec = T001A13_A1683ProdCostoFec[0];
            AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
            A1682ProdCostoD = T001A13_A1682ProdCostoD[0];
            AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
            A1698ProdIna = T001A13_A1698ProdIna[0];
            AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
            A1703ProdPorSel = T001A13_A1703ProdPorSel[0];
            AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
            A1697ProdImpSel = T001A13_A1697ProdImpSel[0];
            A1672ProdAdValor = T001A13_A1672ProdAdValor[0];
            AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
            A1696ProdFrecuente = T001A13_A1696ProdFrecuente[0];
            AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
            A1686ProdCuentaVDsc = T001A13_A1686ProdCuentaVDsc[0];
            AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
            A1685ProdCuentaCDsc = T001A13_A1685ProdCuentaCDsc[0];
            AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
            A1684ProdCuentaADsc = T001A13_A1684ProdCuentaADsc[0];
            AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
            A1721ProdUsuCod = T001A13_A1721ProdUsuCod[0];
            AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
            A1722ProdUsuFec = T001A13_A1722ProdUsuFec[0];
            AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1673ProdAfec = T001A13_A1673ProdAfec[0];
            AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
            A1701ProdObs = T001A13_A1701ProdObs[0];
            A1675ProdCanLote = T001A13_A1675ProdCanLote[0];
            A1674ProdBarra = T001A13_A1674ProdBarra[0];
            A1689ProdExportacion = T001A13_A1689ProdExportacion[0];
            A906ProdAfecICBPER = T001A13_A906ProdAfecICBPER[0];
            A907ProdValICBPER = T001A13_A907ProdValICBPER[0];
            A908ProdValICBPERD = T001A13_A908ProdValICBPERD[0];
            A52LinCod = T001A13_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            A51SublCod = T001A13_A51SublCod[0];
            n51SublCod = T001A13_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            A50FamCod = T001A13_A50FamCod[0];
            n50FamCod = T001A13_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            A49UniCod = T001A13_A49UniCod[0];
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            A47CBSuCod = T001A13_A47CBSuCod[0];
            n47CBSuCod = T001A13_n47CBSuCod[0];
            A46cDetCod = T001A13_A46cDetCod[0];
            n46cDetCod = T001A13_n46cDetCod[0];
            A48ProdCuentaV = T001A13_A48ProdCuentaV[0];
            n48ProdCuentaV = T001A13_n48ProdCuentaV[0];
            AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
            A53ProdCuentaC = T001A13_A53ProdCuentaC[0];
            n53ProdCuentaC = T001A13_n53ProdCuentaC[0];
            AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
            A54ProdCuentaA = T001A13_A54ProdCuentaA[0];
            n54ProdCuentaA = T001A13_n54ProdCuentaA[0];
            AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
            A1695ProdFoto = T001A13_A1695ProdFoto[0];
            n1695ProdFoto = T001A13_n1695ProdFoto[0];
            AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            ZM1A44( -4) ;
         }
         pr_default.close(11);
         OnLoadActions1A44( ) ;
      }

      protected void OnLoadActions1A44( )
      {
         A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
         AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
      }

      protected void CheckExtendedTable1A44( )
      {
         nIsDirty_44 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001A4 */
         pr_default.execute(2, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001A5 */
         pr_default.execute(3, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A51SublCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         /* Using cursor T001A6 */
         pr_default.execute(4, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A50FamCod) ) )
            {
               GX_msglist.addItem("No existe 'Familia'.", "ForeignKeyNotFound", 1, "FAMCOD");
               AnyError = 1;
               GX_FocusControl = edtFamCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T001A7 */
         pr_default.execute(5, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidad de Medida'.", "ForeignKeyNotFound", 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         nIsDirty_44 = 1;
         A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
         AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
         if ( ! ( (DateTime.MinValue==A1683ProdCostoFec) || ( DateTimeUtil.ResetTime ( A1683ProdCostoFec ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Campo Fecha Ult. Costo fuera de rango", "OutOfRange", 1, "PRODCOSTOFEC");
            AnyError = 1;
            GX_FocusControl = edtProdCostoFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001A10 */
         pr_default.execute(8, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAV");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1686ProdCuentaVDsc = T001A10_A1686ProdCuentaVDsc[0];
         AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
         pr_default.close(8);
         /* Using cursor T001A11 */
         pr_default.execute(9, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAC");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1685ProdCuentaCDsc = T001A11_A1685ProdCuentaCDsc[0];
         AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
         pr_default.close(9);
         /* Using cursor T001A12 */
         pr_default.execute(10, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Almacen'.", "ForeignKeyNotFound", 1, "PRODCUENTAA");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1684ProdCuentaADsc = T001A12_A1684ProdCuentaADsc[0];
         AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
         pr_default.close(10);
         if ( ! ( (DateTime.MinValue==A1722ProdUsuFec) || ( A1722ProdUsuFec >= context.localUtil.YMDHMSToT( 1753, 1, 1, 0, 0, 0) ) ) )
         {
            GX_msglist.addItem("Campo Usuario Fecha fuera de rango", "OutOfRange", 1, "PRODUSUFEC");
            AnyError = 1;
            GX_FocusControl = edtProdUsuFec_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1A44( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
         pr_default.close(8);
         pr_default.close(9);
         pr_default.close(10);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( int A52LinCod )
      {
         /* Using cursor T001A14 */
         pr_default.execute(12, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
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

      protected void gxLoad_6( int A51SublCod )
      {
         /* Using cursor T001A15 */
         pr_default.execute(13, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            if ( ! ( (0==A51SublCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(13) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(13);
      }

      protected void gxLoad_7( int A50FamCod )
      {
         /* Using cursor T001A16 */
         pr_default.execute(14, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A50FamCod) ) )
            {
               GX_msglist.addItem("No existe 'Familia'.", "ForeignKeyNotFound", 1, "FAMCOD");
               AnyError = 1;
               GX_FocusControl = edtFamCod_Internalname;
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

      protected void gxLoad_8( int A49UniCod )
      {
         /* Using cursor T001A17 */
         pr_default.execute(15, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidad de Medida'.", "ForeignKeyNotFound", 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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

      protected void gxLoad_11( string A48ProdCuentaV )
      {
         /* Using cursor T001A18 */
         pr_default.execute(16, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
         if ( (pr_default.getStatus(16) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAV");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaV_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1686ProdCuentaVDsc = T001A18_A1686ProdCuentaVDsc[0];
         AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1686ProdCuentaVDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(16) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(16);
      }

      protected void gxLoad_12( string A53ProdCuentaC )
      {
         /* Using cursor T001A19 */
         pr_default.execute(17, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAC");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaC_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1685ProdCuentaCDsc = T001A19_A1685ProdCuentaCDsc[0];
         AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1685ProdCuentaCDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void gxLoad_13( string A54ProdCuentaA )
      {
         /* Using cursor T001A20 */
         pr_default.execute(18, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Almacen'.", "ForeignKeyNotFound", 1, "PRODCUENTAA");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaA_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A1684ProdCuentaADsc = T001A20_A1684ProdCuentaADsc[0];
         AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1684ProdCuentaADsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(18) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(18);
      }

      protected void GetKey1A44( )
      {
         /* Using cursor T001A21 */
         pr_default.execute(19, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001A3 */
         pr_default.execute(1, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1A44( 4) ;
            RcdFound44 = 1;
            A28ProdCod = T001A3_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A55ProdDsc = T001A3_A55ProdDsc[0];
            AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
            A1724ProdVta = T001A3_A1724ProdVta[0];
            AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
            A1679ProdCmp = T001A3_A1679ProdCmp[0];
            AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
            A1702ProdPeso = T001A3_A1702ProdPeso[0];
            AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
            A1723ProdVolumen = T001A3_A1723ProdVolumen[0];
            AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
            A1716ProdStkMax = T001A3_A1716ProdStkMax[0];
            AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
            A1717ProdStkMin = T001A3_A1717ProdStkMin[0];
            AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
            A40000ProdFoto_GXI = T001A3_A40000ProdFoto_GXI[0];
            n40000ProdFoto_GXI = T001A3_n40000ProdFoto_GXI[0];
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            A1705ProdRef1 = T001A3_A1705ProdRef1[0];
            AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
            A1707ProdRef2 = T001A3_A1707ProdRef2[0];
            AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
            A1708ProdRef3 = T001A3_A1708ProdRef3[0];
            AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
            A1709ProdRef4 = T001A3_A1709ProdRef4[0];
            AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
            A1710ProdRef5 = T001A3_A1710ProdRef5[0];
            AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
            A1711ProdRef6 = T001A3_A1711ProdRef6[0];
            AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
            A1712ProdRef7 = T001A3_A1712ProdRef7[0];
            AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
            A1713ProdRef8 = T001A3_A1713ProdRef8[0];
            AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
            A1714ProdRef9 = T001A3_A1714ProdRef9[0];
            AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
            A1706ProdRef10 = T001A3_A1706ProdRef10[0];
            AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
            A1718ProdSts = T001A3_A1718ProdSts[0];
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
            A1681ProdCosto = T001A3_A1681ProdCosto[0];
            AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
            A1683ProdCostoFec = T001A3_A1683ProdCostoFec[0];
            AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
            A1682ProdCostoD = T001A3_A1682ProdCostoD[0];
            AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
            A1698ProdIna = T001A3_A1698ProdIna[0];
            AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
            A1703ProdPorSel = T001A3_A1703ProdPorSel[0];
            AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
            A1697ProdImpSel = T001A3_A1697ProdImpSel[0];
            A1672ProdAdValor = T001A3_A1672ProdAdValor[0];
            AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
            A1696ProdFrecuente = T001A3_A1696ProdFrecuente[0];
            AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
            A1721ProdUsuCod = T001A3_A1721ProdUsuCod[0];
            AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
            A1722ProdUsuFec = T001A3_A1722ProdUsuFec[0];
            AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
            A1673ProdAfec = T001A3_A1673ProdAfec[0];
            AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
            A1701ProdObs = T001A3_A1701ProdObs[0];
            A1675ProdCanLote = T001A3_A1675ProdCanLote[0];
            A1674ProdBarra = T001A3_A1674ProdBarra[0];
            A1689ProdExportacion = T001A3_A1689ProdExportacion[0];
            A906ProdAfecICBPER = T001A3_A906ProdAfecICBPER[0];
            A907ProdValICBPER = T001A3_A907ProdValICBPER[0];
            A908ProdValICBPERD = T001A3_A908ProdValICBPERD[0];
            A52LinCod = T001A3_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            A51SublCod = T001A3_A51SublCod[0];
            n51SublCod = T001A3_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            A50FamCod = T001A3_A50FamCod[0];
            n50FamCod = T001A3_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            A49UniCod = T001A3_A49UniCod[0];
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            A47CBSuCod = T001A3_A47CBSuCod[0];
            n47CBSuCod = T001A3_n47CBSuCod[0];
            A46cDetCod = T001A3_A46cDetCod[0];
            n46cDetCod = T001A3_n46cDetCod[0];
            A48ProdCuentaV = T001A3_A48ProdCuentaV[0];
            n48ProdCuentaV = T001A3_n48ProdCuentaV[0];
            AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
            A53ProdCuentaC = T001A3_A53ProdCuentaC[0];
            n53ProdCuentaC = T001A3_n53ProdCuentaC[0];
            AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
            A54ProdCuentaA = T001A3_A54ProdCuentaA[0];
            n54ProdCuentaA = T001A3_n54ProdCuentaA[0];
            AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
            A1695ProdFoto = T001A3_A1695ProdFoto[0];
            n1695ProdFoto = T001A3_n1695ProdFoto[0];
            AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
            AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
            AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
            Z28ProdCod = A28ProdCod;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1A44( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1A44( ) ;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1A44( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1A44( ) ;
         if ( RcdFound44 == 0 )
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
         RcdFound44 = 0;
         /* Using cursor T001A22 */
         pr_default.execute(20, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(20) != 101) )
         {
            while ( (pr_default.getStatus(20) != 101) && ( ( StringUtil.StrCmp(T001A22_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               pr_default.readNext(20);
            }
            if ( (pr_default.getStatus(20) != 101) && ( ( StringUtil.StrCmp(T001A22_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               A28ProdCod = T001A22_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(20);
      }

      protected void move_previous( )
      {
         RcdFound44 = 0;
         /* Using cursor T001A23 */
         pr_default.execute(21, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(21) != 101) )
         {
            while ( (pr_default.getStatus(21) != 101) && ( ( StringUtil.StrCmp(T001A23_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               pr_default.readNext(21);
            }
            if ( (pr_default.getStatus(21) != 101) && ( ( StringUtil.StrCmp(T001A23_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               A28ProdCod = T001A23_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(21);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1A44( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1A44( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
               {
                  A28ProdCod = Z28ProdCod;
                  AssignAttri("", false, "A28ProdCod", A28ProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1A44( ) ;
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtProdCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1A44( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODCOD");
                     AnyError = 1;
                     GX_FocusControl = edtProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1A44( ) ;
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
         if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
         {
            A28ProdCod = Z28ProdCod;
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProdCod_Internalname;
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
         GetKey1A44( ) ;
         if ( RcdFound44 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
            {
               A28ProdCod = Z28ProdCod;
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PRODCOD");
               AnyError = 1;
               GX_FocusControl = edtProdCod_Internalname;
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
            if ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODCOD");
                  AnyError = 1;
                  GX_FocusControl = edtProdCod_Internalname;
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
         context.RollbackDataStores("aproductos",pr_default);
         GX_FocusControl = edtLinCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1A0( ) ;
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
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtLinCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1A44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1A44( ) ;
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
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinCod_Internalname;
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
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinCod_Internalname;
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
         ScanStart1A44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound44 != 0 )
            {
               ScanNext1A44( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtLinCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1A44( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1A44( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001A2 */
            pr_default.execute(0, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z55ProdDsc, T001A2_A55ProdDsc[0]) != 0 ) || ( Z1724ProdVta != T001A2_A1724ProdVta[0] ) || ( Z1679ProdCmp != T001A2_A1679ProdCmp[0] ) || ( Z1702ProdPeso != T001A2_A1702ProdPeso[0] ) || ( Z1723ProdVolumen != T001A2_A1723ProdVolumen[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1716ProdStkMax != T001A2_A1716ProdStkMax[0] ) || ( Z1717ProdStkMin != T001A2_A1717ProdStkMin[0] ) || ( StringUtil.StrCmp(Z1705ProdRef1, T001A2_A1705ProdRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1707ProdRef2, T001A2_A1707ProdRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1708ProdRef3, T001A2_A1708ProdRef3[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1709ProdRef4, T001A2_A1709ProdRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z1710ProdRef5, T001A2_A1710ProdRef5[0]) != 0 ) || ( StringUtil.StrCmp(Z1711ProdRef6, T001A2_A1711ProdRef6[0]) != 0 ) || ( StringUtil.StrCmp(Z1712ProdRef7, T001A2_A1712ProdRef7[0]) != 0 ) || ( StringUtil.StrCmp(Z1713ProdRef8, T001A2_A1713ProdRef8[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1714ProdRef9, T001A2_A1714ProdRef9[0]) != 0 ) || ( StringUtil.StrCmp(Z1706ProdRef10, T001A2_A1706ProdRef10[0]) != 0 ) || ( Z1718ProdSts != T001A2_A1718ProdSts[0] ) || ( Z1681ProdCosto != T001A2_A1681ProdCosto[0] ) || ( DateTimeUtil.ResetTime ( Z1683ProdCostoFec ) != DateTimeUtil.ResetTime ( T001A2_A1683ProdCostoFec[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1682ProdCostoD != T001A2_A1682ProdCostoD[0] ) || ( Z1698ProdIna != T001A2_A1698ProdIna[0] ) || ( Z1703ProdPorSel != T001A2_A1703ProdPorSel[0] ) || ( Z1697ProdImpSel != T001A2_A1697ProdImpSel[0] ) || ( Z1672ProdAdValor != T001A2_A1672ProdAdValor[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1696ProdFrecuente != T001A2_A1696ProdFrecuente[0] ) || ( StringUtil.StrCmp(Z1721ProdUsuCod, T001A2_A1721ProdUsuCod[0]) != 0 ) || ( Z1722ProdUsuFec != T001A2_A1722ProdUsuFec[0] ) || ( Z1673ProdAfec != T001A2_A1673ProdAfec[0] ) || ( StringUtil.StrCmp(Z1701ProdObs, T001A2_A1701ProdObs[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1675ProdCanLote != T001A2_A1675ProdCanLote[0] ) || ( StringUtil.StrCmp(Z1674ProdBarra, T001A2_A1674ProdBarra[0]) != 0 ) || ( StringUtil.StrCmp(Z1689ProdExportacion, T001A2_A1689ProdExportacion[0]) != 0 ) || ( Z906ProdAfecICBPER != T001A2_A906ProdAfecICBPER[0] ) || ( Z907ProdValICBPER != T001A2_A907ProdValICBPER[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z908ProdValICBPERD != T001A2_A908ProdValICBPERD[0] ) || ( Z52LinCod != T001A2_A52LinCod[0] ) || ( Z51SublCod != T001A2_A51SublCod[0] ) || ( Z50FamCod != T001A2_A50FamCod[0] ) || ( Z49UniCod != T001A2_A49UniCod[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z47CBSuCod, T001A2_A47CBSuCod[0]) != 0 ) || ( Z46cDetCod != T001A2_A46cDetCod[0] ) || ( StringUtil.StrCmp(Z48ProdCuentaV, T001A2_A48ProdCuentaV[0]) != 0 ) || ( StringUtil.StrCmp(Z53ProdCuentaC, T001A2_A53ProdCuentaC[0]) != 0 ) || ( StringUtil.StrCmp(Z54ProdCuentaA, T001A2_A54ProdCuentaA[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z55ProdDsc, T001A2_A55ProdDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdDsc");
                  GXUtil.WriteLogRaw("Old: ",Z55ProdDsc);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A55ProdDsc[0]);
               }
               if ( Z1724ProdVta != T001A2_A1724ProdVta[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdVta");
                  GXUtil.WriteLogRaw("Old: ",Z1724ProdVta);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1724ProdVta[0]);
               }
               if ( Z1679ProdCmp != T001A2_A1679ProdCmp[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCmp");
                  GXUtil.WriteLogRaw("Old: ",Z1679ProdCmp);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1679ProdCmp[0]);
               }
               if ( Z1702ProdPeso != T001A2_A1702ProdPeso[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdPeso");
                  GXUtil.WriteLogRaw("Old: ",Z1702ProdPeso);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1702ProdPeso[0]);
               }
               if ( Z1723ProdVolumen != T001A2_A1723ProdVolumen[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdVolumen");
                  GXUtil.WriteLogRaw("Old: ",Z1723ProdVolumen);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1723ProdVolumen[0]);
               }
               if ( Z1716ProdStkMax != T001A2_A1716ProdStkMax[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdStkMax");
                  GXUtil.WriteLogRaw("Old: ",Z1716ProdStkMax);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1716ProdStkMax[0]);
               }
               if ( Z1717ProdStkMin != T001A2_A1717ProdStkMin[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdStkMin");
                  GXUtil.WriteLogRaw("Old: ",Z1717ProdStkMin);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1717ProdStkMin[0]);
               }
               if ( StringUtil.StrCmp(Z1705ProdRef1, T001A2_A1705ProdRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1705ProdRef1);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1705ProdRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1707ProdRef2, T001A2_A1707ProdRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1707ProdRef2);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1707ProdRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1708ProdRef3, T001A2_A1708ProdRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1708ProdRef3);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1708ProdRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1709ProdRef4, T001A2_A1709ProdRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1709ProdRef4);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1709ProdRef4[0]);
               }
               if ( StringUtil.StrCmp(Z1710ProdRef5, T001A2_A1710ProdRef5[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef5");
                  GXUtil.WriteLogRaw("Old: ",Z1710ProdRef5);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1710ProdRef5[0]);
               }
               if ( StringUtil.StrCmp(Z1711ProdRef6, T001A2_A1711ProdRef6[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef6");
                  GXUtil.WriteLogRaw("Old: ",Z1711ProdRef6);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1711ProdRef6[0]);
               }
               if ( StringUtil.StrCmp(Z1712ProdRef7, T001A2_A1712ProdRef7[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef7");
                  GXUtil.WriteLogRaw("Old: ",Z1712ProdRef7);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1712ProdRef7[0]);
               }
               if ( StringUtil.StrCmp(Z1713ProdRef8, T001A2_A1713ProdRef8[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef8");
                  GXUtil.WriteLogRaw("Old: ",Z1713ProdRef8);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1713ProdRef8[0]);
               }
               if ( StringUtil.StrCmp(Z1714ProdRef9, T001A2_A1714ProdRef9[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef9");
                  GXUtil.WriteLogRaw("Old: ",Z1714ProdRef9);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1714ProdRef9[0]);
               }
               if ( StringUtil.StrCmp(Z1706ProdRef10, T001A2_A1706ProdRef10[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdRef10");
                  GXUtil.WriteLogRaw("Old: ",Z1706ProdRef10);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1706ProdRef10[0]);
               }
               if ( Z1718ProdSts != T001A2_A1718ProdSts[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdSts");
                  GXUtil.WriteLogRaw("Old: ",Z1718ProdSts);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1718ProdSts[0]);
               }
               if ( Z1681ProdCosto != T001A2_A1681ProdCosto[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCosto");
                  GXUtil.WriteLogRaw("Old: ",Z1681ProdCosto);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1681ProdCosto[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z1683ProdCostoFec ) != DateTimeUtil.ResetTime ( T001A2_A1683ProdCostoFec[0] ) )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCostoFec");
                  GXUtil.WriteLogRaw("Old: ",Z1683ProdCostoFec);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1683ProdCostoFec[0]);
               }
               if ( Z1682ProdCostoD != T001A2_A1682ProdCostoD[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCostoD");
                  GXUtil.WriteLogRaw("Old: ",Z1682ProdCostoD);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1682ProdCostoD[0]);
               }
               if ( Z1698ProdIna != T001A2_A1698ProdIna[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdIna");
                  GXUtil.WriteLogRaw("Old: ",Z1698ProdIna);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1698ProdIna[0]);
               }
               if ( Z1703ProdPorSel != T001A2_A1703ProdPorSel[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdPorSel");
                  GXUtil.WriteLogRaw("Old: ",Z1703ProdPorSel);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1703ProdPorSel[0]);
               }
               if ( Z1697ProdImpSel != T001A2_A1697ProdImpSel[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdImpSel");
                  GXUtil.WriteLogRaw("Old: ",Z1697ProdImpSel);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1697ProdImpSel[0]);
               }
               if ( Z1672ProdAdValor != T001A2_A1672ProdAdValor[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdAdValor");
                  GXUtil.WriteLogRaw("Old: ",Z1672ProdAdValor);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1672ProdAdValor[0]);
               }
               if ( Z1696ProdFrecuente != T001A2_A1696ProdFrecuente[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdFrecuente");
                  GXUtil.WriteLogRaw("Old: ",Z1696ProdFrecuente);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1696ProdFrecuente[0]);
               }
               if ( StringUtil.StrCmp(Z1721ProdUsuCod, T001A2_A1721ProdUsuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdUsuCod");
                  GXUtil.WriteLogRaw("Old: ",Z1721ProdUsuCod);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1721ProdUsuCod[0]);
               }
               if ( Z1722ProdUsuFec != T001A2_A1722ProdUsuFec[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdUsuFec");
                  GXUtil.WriteLogRaw("Old: ",Z1722ProdUsuFec);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1722ProdUsuFec[0]);
               }
               if ( Z1673ProdAfec != T001A2_A1673ProdAfec[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdAfec");
                  GXUtil.WriteLogRaw("Old: ",Z1673ProdAfec);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1673ProdAfec[0]);
               }
               if ( StringUtil.StrCmp(Z1701ProdObs, T001A2_A1701ProdObs[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdObs");
                  GXUtil.WriteLogRaw("Old: ",Z1701ProdObs);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1701ProdObs[0]);
               }
               if ( Z1675ProdCanLote != T001A2_A1675ProdCanLote[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCanLote");
                  GXUtil.WriteLogRaw("Old: ",Z1675ProdCanLote);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1675ProdCanLote[0]);
               }
               if ( StringUtil.StrCmp(Z1674ProdBarra, T001A2_A1674ProdBarra[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdBarra");
                  GXUtil.WriteLogRaw("Old: ",Z1674ProdBarra);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1674ProdBarra[0]);
               }
               if ( StringUtil.StrCmp(Z1689ProdExportacion, T001A2_A1689ProdExportacion[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdExportacion");
                  GXUtil.WriteLogRaw("Old: ",Z1689ProdExportacion);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A1689ProdExportacion[0]);
               }
               if ( Z906ProdAfecICBPER != T001A2_A906ProdAfecICBPER[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdAfecICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z906ProdAfecICBPER);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A906ProdAfecICBPER[0]);
               }
               if ( Z907ProdValICBPER != T001A2_A907ProdValICBPER[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdValICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z907ProdValICBPER);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A907ProdValICBPER[0]);
               }
               if ( Z908ProdValICBPERD != T001A2_A908ProdValICBPERD[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdValICBPERD");
                  GXUtil.WriteLogRaw("Old: ",Z908ProdValICBPERD);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A908ProdValICBPERD[0]);
               }
               if ( Z52LinCod != T001A2_A52LinCod[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"LinCod");
                  GXUtil.WriteLogRaw("Old: ",Z52LinCod);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A52LinCod[0]);
               }
               if ( Z51SublCod != T001A2_A51SublCod[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"SublCod");
                  GXUtil.WriteLogRaw("Old: ",Z51SublCod);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A51SublCod[0]);
               }
               if ( Z50FamCod != T001A2_A50FamCod[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"FamCod");
                  GXUtil.WriteLogRaw("Old: ",Z50FamCod);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A50FamCod[0]);
               }
               if ( Z49UniCod != T001A2_A49UniCod[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"UniCod");
                  GXUtil.WriteLogRaw("Old: ",Z49UniCod);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A49UniCod[0]);
               }
               if ( StringUtil.StrCmp(Z47CBSuCod, T001A2_A47CBSuCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"CBSuCod");
                  GXUtil.WriteLogRaw("Old: ",Z47CBSuCod);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A47CBSuCod[0]);
               }
               if ( Z46cDetCod != T001A2_A46cDetCod[0] )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"cDetCod");
                  GXUtil.WriteLogRaw("Old: ",Z46cDetCod);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A46cDetCod[0]);
               }
               if ( StringUtil.StrCmp(Z48ProdCuentaV, T001A2_A48ProdCuentaV[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCuentaV");
                  GXUtil.WriteLogRaw("Old: ",Z48ProdCuentaV);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A48ProdCuentaV[0]);
               }
               if ( StringUtil.StrCmp(Z53ProdCuentaC, T001A2_A53ProdCuentaC[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCuentaC");
                  GXUtil.WriteLogRaw("Old: ",Z53ProdCuentaC);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A53ProdCuentaC[0]);
               }
               if ( StringUtil.StrCmp(Z54ProdCuentaA, T001A2_A54ProdCuentaA[0]) != 0 )
               {
                  GXUtil.WriteLog("aproductos:[seudo value changed for attri]"+"ProdCuentaA");
                  GXUtil.WriteLogRaw("Old: ",Z54ProdCuentaA);
                  GXUtil.WriteLogRaw("Current: ",T001A2_A54ProdCuentaA[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"APRODUCTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1A44( )
      {
         BeforeValidate1A44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A44( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1A44( 0) ;
            CheckOptimisticConcurrency1A44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1A44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001A24 */
                     pr_default.execute(22, new Object[] {A28ProdCod, A55ProdDsc, A1724ProdVta, A1679ProdCmp, A1702ProdPeso, A1723ProdVolumen, A1716ProdStkMax, A1717ProdStkMin, n1695ProdFoto, A1695ProdFoto, n40000ProdFoto_GXI, A40000ProdFoto_GXI, A1705ProdRef1, A1707ProdRef2, A1708ProdRef3, A1709ProdRef4, A1710ProdRef5, A1711ProdRef6, A1712ProdRef7, A1713ProdRef8, A1714ProdRef9, A1706ProdRef10, A1718ProdSts, A1681ProdCosto, A1683ProdCostoFec, A1682ProdCostoD, A1698ProdIna, A1703ProdPorSel, A1697ProdImpSel, A1672ProdAdValor, A1696ProdFrecuente, A1721ProdUsuCod, A1722ProdUsuFec, A1673ProdAfec, A1701ProdObs, A1675ProdCanLote, A1674ProdBarra, A1689ProdExportacion, A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD, A52LinCod, n51SublCod, A51SublCod, n50FamCod, A50FamCod, A49UniCod, n47CBSuCod, A47CBSuCod, n46cDetCod, A46cDetCod, n48ProdCuentaV, A48ProdCuentaV, n53ProdCuentaC, A53ProdCuentaC, n54ProdCuentaA, A54ProdCuentaA});
                     pr_default.close(22);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( (pr_default.getStatus(22) == 1) )
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
                           ResetCaption1A0( ) ;
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
               Load1A44( ) ;
            }
            EndLevel1A44( ) ;
         }
         CloseExtendedTableCursors1A44( ) ;
      }

      protected void Update1A44( )
      {
         BeforeValidate1A44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1A44( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1A44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1A44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001A25 */
                     pr_default.execute(23, new Object[] {A55ProdDsc, A1724ProdVta, A1679ProdCmp, A1702ProdPeso, A1723ProdVolumen, A1716ProdStkMax, A1717ProdStkMin, A1705ProdRef1, A1707ProdRef2, A1708ProdRef3, A1709ProdRef4, A1710ProdRef5, A1711ProdRef6, A1712ProdRef7, A1713ProdRef8, A1714ProdRef9, A1706ProdRef10, A1718ProdSts, A1681ProdCosto, A1683ProdCostoFec, A1682ProdCostoD, A1698ProdIna, A1703ProdPorSel, A1697ProdImpSel, A1672ProdAdValor, A1696ProdFrecuente, A1721ProdUsuCod, A1722ProdUsuFec, A1673ProdAfec, A1701ProdObs, A1675ProdCanLote, A1674ProdBarra, A1689ProdExportacion, A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD, A52LinCod, n51SublCod, A51SublCod, n50FamCod, A50FamCod, A49UniCod, n47CBSuCod, A47CBSuCod, n46cDetCod, A46cDetCod, n48ProdCuentaV, A48ProdCuentaV, n53ProdCuentaC, A53ProdCuentaC, n54ProdCuentaA, A54ProdCuentaA, A28ProdCod});
                     pr_default.close(23);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( (pr_default.getStatus(23) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1A44( ) ;
                     if ( AnyError == 0 )
                     {
                        new aproductosupdateredundancy(context ).execute( ref  A28ProdCod) ;
                        AssignAttri("", false, "A28ProdCod", A28ProdCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1A0( ) ;
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
            EndLevel1A44( ) ;
         }
         CloseExtendedTableCursors1A44( ) ;
      }

      protected void DeferredUpdate1A44( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001A26 */
            pr_default.execute(24, new Object[] {n1695ProdFoto, A1695ProdFoto, n40000ProdFoto_GXI, A40000ProdFoto_GXI, A28ProdCod});
            pr_default.close(24);
            dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1A44( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1A44( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1A44( ) ;
            AfterConfirm1A44( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1A44( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001A27 */
                  pr_default.execute(25, new Object[] {A28ProdCod});
                  pr_default.close(25);
                  dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound44 == 0 )
                        {
                           InitAll1A44( ) ;
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
                        ResetCaption1A0( ) ;
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1A44( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1A44( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A1715ProdReferencias = StringUtil.Trim( A1705ProdRef1) + " " + StringUtil.Trim( A1707ProdRef2) + " " + StringUtil.Trim( A1708ProdRef3) + " " + StringUtil.Trim( A1709ProdRef4) + " " + StringUtil.Trim( A1710ProdRef5) + " " + StringUtil.Trim( A1711ProdRef6) + " " + StringUtil.Trim( A1712ProdRef7) + " " + StringUtil.Trim( A1713ProdRef8) + " " + StringUtil.Trim( A1714ProdRef9) + " " + StringUtil.Trim( A1706ProdRef10);
            AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
            /* Using cursor T001A28 */
            pr_default.execute(26, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
            A1686ProdCuentaVDsc = T001A28_A1686ProdCuentaVDsc[0];
            AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
            pr_default.close(26);
            /* Using cursor T001A29 */
            pr_default.execute(27, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
            A1685ProdCuentaCDsc = T001A29_A1685ProdCuentaCDsc[0];
            AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
            pr_default.close(27);
            /* Using cursor T001A30 */
            pr_default.execute(28, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
            A1684ProdCuentaADsc = T001A30_A1684ProdCuentaADsc[0];
            AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
            pr_default.close(28);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001A31 */
            pr_default.execute(29, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Materias Primas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T001A32 */
            pr_default.execute(30, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Gastos de Fabricación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T001A33 */
            pr_default.execute(31, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POSERVICIODET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T001A34 */
            pr_default.execute(32, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Orden de Servicio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T001A35 */
            pr_default.execute(33, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Plan de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T001A36 */
            pr_default.execute(34, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T001A37 */
            pr_default.execute(35, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T001A38 */
            pr_default.execute(36, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZADET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T001A39 */
            pr_default.execute(37, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T001A40 */
            pr_default.execute(38, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sabana de Compras "}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T001A41 */
            pr_default.execute(39, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T001A42 */
            pr_default.execute(40, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T001A43 */
            pr_default.execute(41, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T001A44 */
            pr_default.execute(42, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T001A45 */
            pr_default.execute(43, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Detalle Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
            /* Using cursor T001A46 */
            pr_default.execute(44, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(44) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Sub Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(44);
            /* Using cursor T001A47 */
            pr_default.execute(45, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(45) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldo Mensual de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(45);
            /* Using cursor T001A48 */
            pr_default.execute(46, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(46) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Descuentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(46);
            /* Using cursor T001A49 */
            pr_default.execute(47, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(47) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Orden de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(47);
            /* Using cursor T001A50 */
            pr_default.execute(48, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(48) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ventas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(48);
            /* Using cursor T001A51 */
            pr_default.execute(49, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(49) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(49);
            /* Using cursor T001A52 */
            pr_default.execute(50, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(50) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(50);
            /* Using cursor T001A53 */
            pr_default.execute(51, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(51) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(51);
            /* Using cursor T001A54 */
            pr_default.execute(52, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(52) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(52);
            /* Using cursor T001A55 */
            pr_default.execute(53, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(53) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov Almacen Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(53);
            /* Using cursor T001A56 */
            pr_default.execute(54, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(54) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLPEDIDOSDETLOTE"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(54);
            /* Using cursor T001A57 */
            pr_default.execute(55, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(55) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Stock Actual"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(55);
            /* Using cursor T001A58 */
            pr_default.execute(56, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(56) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos Unidades de Medida"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(56);
            /* Using cursor T001A59 */
            pr_default.execute(57, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(57) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Formula de Productos"+" ("+"Producto en Formula"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(57);
            /* Using cursor T001A60 */
            pr_default.execute(58, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(58) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Formula de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(58);
            /* Using cursor T001A61 */
            pr_default.execute(59, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(59) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"+" ("+"Productos Equivalentes"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(59);
            /* Using cursor T001A62 */
            pr_default.execute(60, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(60) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(60);
            /* Using cursor T001A63 */
            pr_default.execute(61, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(61) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seguimiento de Consignacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(61);
         }
      }

      protected void EndLevel1A44( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1A44( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(26);
            pr_default.close(27);
            pr_default.close(28);
            context.CommitDataStores("aproductos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(26);
            pr_default.close(27);
            pr_default.close(28);
            context.RollbackDataStores("aproductos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1A44( )
      {
         /* Using cursor T001A64 */
         pr_default.execute(62);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(62) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T001A64_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1A44( )
      {
         /* Scan next routine */
         pr_default.readNext(62);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(62) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T001A64_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
      }

      protected void ScanEnd1A44( )
      {
         pr_default.close(62);
      }

      protected void AfterConfirm1A44( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1A44( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1A44( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1A44( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1A44( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1A44( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1A44( )
      {
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
         edtLinCod_Enabled = 0;
         AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
         edtProdDsc_Enabled = 0;
         AssignProp("", false, edtProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdDsc_Enabled), 5, 0), true);
         edtSublCod_Enabled = 0;
         AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
         edtFamCod_Enabled = 0;
         AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
         edtUniCod_Enabled = 0;
         AssignProp("", false, edtUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniCod_Enabled), 5, 0), true);
         chkProdVta.Enabled = 0;
         AssignProp("", false, chkProdVta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProdVta.Enabled), 5, 0), true);
         chkProdCmp.Enabled = 0;
         AssignProp("", false, chkProdCmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkProdCmp.Enabled), 5, 0), true);
         edtProdPeso_Enabled = 0;
         AssignProp("", false, edtProdPeso_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdPeso_Enabled), 5, 0), true);
         edtProdVolumen_Enabled = 0;
         AssignProp("", false, edtProdVolumen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdVolumen_Enabled), 5, 0), true);
         edtProdStkMax_Enabled = 0;
         AssignProp("", false, edtProdStkMax_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdStkMax_Enabled), 5, 0), true);
         edtProdStkMin_Enabled = 0;
         AssignProp("", false, edtProdStkMin_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdStkMin_Enabled), 5, 0), true);
         imgProdFoto_Enabled = 0;
         AssignProp("", false, imgProdFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProdFoto_Enabled), 5, 0), true);
         edtProdRef1_Enabled = 0;
         AssignProp("", false, edtProdRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef1_Enabled), 5, 0), true);
         edtProdRef2_Enabled = 0;
         AssignProp("", false, edtProdRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef2_Enabled), 5, 0), true);
         edtProdRef3_Enabled = 0;
         AssignProp("", false, edtProdRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef3_Enabled), 5, 0), true);
         edtProdRef4_Enabled = 0;
         AssignProp("", false, edtProdRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef4_Enabled), 5, 0), true);
         edtProdRef5_Enabled = 0;
         AssignProp("", false, edtProdRef5_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef5_Enabled), 5, 0), true);
         edtProdRef6_Enabled = 0;
         AssignProp("", false, edtProdRef6_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef6_Enabled), 5, 0), true);
         edtProdRef7_Enabled = 0;
         AssignProp("", false, edtProdRef7_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef7_Enabled), 5, 0), true);
         edtProdRef8_Enabled = 0;
         AssignProp("", false, edtProdRef8_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef8_Enabled), 5, 0), true);
         edtProdRef9_Enabled = 0;
         AssignProp("", false, edtProdRef9_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef9_Enabled), 5, 0), true);
         edtProdRef10_Enabled = 0;
         AssignProp("", false, edtProdRef10_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdRef10_Enabled), 5, 0), true);
         cmbProdSts.Enabled = 0;
         AssignProp("", false, cmbProdSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbProdSts.Enabled), 5, 0), true);
         edtProdCosto_Enabled = 0;
         AssignProp("", false, edtProdCosto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCosto_Enabled), 5, 0), true);
         edtProdCostoFec_Enabled = 0;
         AssignProp("", false, edtProdCostoFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCostoFec_Enabled), 5, 0), true);
         edtProdCostoD_Enabled = 0;
         AssignProp("", false, edtProdCostoD_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCostoD_Enabled), 5, 0), true);
         edtProdIna_Enabled = 0;
         AssignProp("", false, edtProdIna_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdIna_Enabled), 5, 0), true);
         edtProdPorSel_Enabled = 0;
         AssignProp("", false, edtProdPorSel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdPorSel_Enabled), 5, 0), true);
         edtProdAdValor_Enabled = 0;
         AssignProp("", false, edtProdAdValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdAdValor_Enabled), 5, 0), true);
         edtProdReferencias_Enabled = 0;
         AssignProp("", false, edtProdReferencias_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdReferencias_Enabled), 5, 0), true);
         edtProdFrecuente_Enabled = 0;
         AssignProp("", false, edtProdFrecuente_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdFrecuente_Enabled), 5, 0), true);
         edtProdCuentaV_Enabled = 0;
         AssignProp("", false, edtProdCuentaV_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaV_Enabled), 5, 0), true);
         edtProdCuentaVDsc_Enabled = 0;
         AssignProp("", false, edtProdCuentaVDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaVDsc_Enabled), 5, 0), true);
         edtProdCuentaC_Enabled = 0;
         AssignProp("", false, edtProdCuentaC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaC_Enabled), 5, 0), true);
         edtProdCuentaCDsc_Enabled = 0;
         AssignProp("", false, edtProdCuentaCDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaCDsc_Enabled), 5, 0), true);
         edtProdCuentaA_Enabled = 0;
         AssignProp("", false, edtProdCuentaA_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaA_Enabled), 5, 0), true);
         edtProdCuentaADsc_Enabled = 0;
         AssignProp("", false, edtProdCuentaADsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCuentaADsc_Enabled), 5, 0), true);
         edtProdUsuCod_Enabled = 0;
         AssignProp("", false, edtProdUsuCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdUsuCod_Enabled), 5, 0), true);
         edtProdUsuFec_Enabled = 0;
         AssignProp("", false, edtProdUsuFec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdUsuFec_Enabled), 5, 0), true);
         edtProdAfec_Enabled = 0;
         AssignProp("", false, edtProdAfec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdAfec_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1A44( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1A0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281816425654", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aproductos.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"APRODUCTOS");
         forbiddenHiddens.Add("ProdImpSel", context.localUtil.Format( A1697ProdImpSel, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("ProdObs", StringUtil.RTrim( context.localUtil.Format( A1701ProdObs, "")));
         forbiddenHiddens.Add("ProdCanLote", context.localUtil.Format( A1675ProdCanLote, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("ProdBarra", StringUtil.RTrim( context.localUtil.Format( A1674ProdBarra, "")));
         forbiddenHiddens.Add("ProdExportacion", StringUtil.RTrim( context.localUtil.Format( A1689ProdExportacion, "")));
         forbiddenHiddens.Add("CBSuCod", StringUtil.RTrim( context.localUtil.Format( A47CBSuCod, "")));
         forbiddenHiddens.Add("ProdAfecICBPER", context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9"));
         forbiddenHiddens.Add("ProdValICBPER", context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("ProdValICBPERD", context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("cDetCod", context.localUtil.Format( (decimal)(A46cDetCod), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("aproductos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z1724ProdVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1724ProdVta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1679ProdCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1679ProdCmp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1702ProdPeso", StringUtil.LTrim( StringUtil.NToC( Z1702ProdPeso, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1723ProdVolumen", StringUtil.LTrim( StringUtil.NToC( Z1723ProdVolumen, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1716ProdStkMax", StringUtil.LTrim( StringUtil.NToC( Z1716ProdStkMax, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1717ProdStkMin", StringUtil.LTrim( StringUtil.NToC( Z1717ProdStkMin, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1705ProdRef1", StringUtil.RTrim( Z1705ProdRef1));
         GxWebStd.gx_hidden_field( context, "Z1707ProdRef2", StringUtil.RTrim( Z1707ProdRef2));
         GxWebStd.gx_hidden_field( context, "Z1708ProdRef3", StringUtil.RTrim( Z1708ProdRef3));
         GxWebStd.gx_hidden_field( context, "Z1709ProdRef4", StringUtil.RTrim( Z1709ProdRef4));
         GxWebStd.gx_hidden_field( context, "Z1710ProdRef5", StringUtil.RTrim( Z1710ProdRef5));
         GxWebStd.gx_hidden_field( context, "Z1711ProdRef6", StringUtil.RTrim( Z1711ProdRef6));
         GxWebStd.gx_hidden_field( context, "Z1712ProdRef7", StringUtil.RTrim( Z1712ProdRef7));
         GxWebStd.gx_hidden_field( context, "Z1713ProdRef8", StringUtil.RTrim( Z1713ProdRef8));
         GxWebStd.gx_hidden_field( context, "Z1714ProdRef9", StringUtil.RTrim( Z1714ProdRef9));
         GxWebStd.gx_hidden_field( context, "Z1706ProdRef10", StringUtil.RTrim( Z1706ProdRef10));
         GxWebStd.gx_hidden_field( context, "Z1718ProdSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1718ProdSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1681ProdCosto", StringUtil.LTrim( StringUtil.NToC( Z1681ProdCosto, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1683ProdCostoFec", context.localUtil.DToC( Z1683ProdCostoFec, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z1682ProdCostoD", StringUtil.LTrim( StringUtil.NToC( Z1682ProdCostoD, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1698ProdIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1698ProdIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1703ProdPorSel", StringUtil.LTrim( StringUtil.NToC( Z1703ProdPorSel, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1697ProdImpSel", StringUtil.LTrim( StringUtil.NToC( Z1697ProdImpSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1672ProdAdValor", StringUtil.LTrim( StringUtil.NToC( Z1672ProdAdValor, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1696ProdFrecuente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1696ProdFrecuente), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1721ProdUsuCod", StringUtil.RTrim( Z1721ProdUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1722ProdUsuFec", context.localUtil.TToC( Z1722ProdUsuFec, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1673ProdAfec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1673ProdAfec), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1701ProdObs", Z1701ProdObs);
         GxWebStd.gx_hidden_field( context, "Z1675ProdCanLote", StringUtil.LTrim( StringUtil.NToC( Z1675ProdCanLote, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1674ProdBarra", Z1674ProdBarra);
         GxWebStd.gx_hidden_field( context, "Z1689ProdExportacion", Z1689ProdExportacion);
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49UniCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49UniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z47CBSuCod", Z47CBSuCod);
         GxWebStd.gx_hidden_field( context, "Z46cDetCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z46cDetCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z48ProdCuentaV", StringUtil.RTrim( Z48ProdCuentaV));
         GxWebStd.gx_hidden_field( context, "Z53ProdCuentaC", StringUtil.RTrim( Z53ProdCuentaC));
         GxWebStd.gx_hidden_field( context, "Z54ProdCuentaA", StringUtil.RTrim( Z54ProdCuentaA));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "PRODFOTO_GXI", A40000ProdFoto_GXI);
         GxWebStd.gx_hidden_field( context, "PRODIMPSEL", StringUtil.LTrim( StringUtil.NToC( A1697ProdImpSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODOBS", A1701ProdObs);
         GxWebStd.gx_hidden_field( context, "PRODCANLOTE", StringUtil.LTrim( StringUtil.NToC( A1675ProdCanLote, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODBARRA", A1674ProdBarra);
         GxWebStd.gx_hidden_field( context, "PRODEXPORTACION", A1689ProdExportacion);
         GxWebStd.gx_hidden_field( context, "PRODAFECICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "CBSUCOD", A47CBSuCod);
         GxWebStd.gx_hidden_field( context, "CDETCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A46cDetCod), 6, 0, ".", "")));
         GXCCtlgxBlob = "PRODFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A1695ProdFoto);
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
         return formatLink("aproductos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "APRODUCTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Productos" ;
      }

      protected void InitializeNonKey1A44( )
      {
         A1715ProdReferencias = "";
         AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
         A52LinCod = 0;
         AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         A55ProdDsc = "";
         AssignAttri("", false, "A55ProdDsc", A55ProdDsc);
         A51SublCod = 0;
         n51SublCod = false;
         AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         n51SublCod = ((0==A51SublCod) ? true : false);
         A50FamCod = 0;
         n50FamCod = false;
         AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         n50FamCod = ((0==A50FamCod) ? true : false);
         A49UniCod = 0;
         AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
         A1724ProdVta = 0;
         AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
         A1679ProdCmp = 0;
         AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
         A1702ProdPeso = 0;
         AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrimStr( A1702ProdPeso, 15, 5));
         A1723ProdVolumen = 0;
         AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrimStr( A1723ProdVolumen, 15, 5));
         A1716ProdStkMax = 0;
         AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrimStr( A1716ProdStkMax, 15, 4));
         A1717ProdStkMin = 0;
         AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrimStr( A1717ProdStkMin, 15, 4));
         A1695ProdFoto = "";
         n1695ProdFoto = false;
         AssignAttri("", false, "A1695ProdFoto", A1695ProdFoto);
         AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
         AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
         n1695ProdFoto = (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? true : false);
         A40000ProdFoto_GXI = "";
         n40000ProdFoto_GXI = false;
         AssignProp("", false, imgProdFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A1695ProdFoto)) ? A40000ProdFoto_GXI : context.convertURL( context.PathToRelativeUrl( A1695ProdFoto))), true);
         AssignProp("", false, imgProdFoto_Internalname, "SrcSet", context.GetImageSrcSet( A1695ProdFoto), true);
         A1705ProdRef1 = "";
         AssignAttri("", false, "A1705ProdRef1", A1705ProdRef1);
         A1707ProdRef2 = "";
         AssignAttri("", false, "A1707ProdRef2", A1707ProdRef2);
         A1708ProdRef3 = "";
         AssignAttri("", false, "A1708ProdRef3", A1708ProdRef3);
         A1709ProdRef4 = "";
         AssignAttri("", false, "A1709ProdRef4", A1709ProdRef4);
         A1710ProdRef5 = "";
         AssignAttri("", false, "A1710ProdRef5", A1710ProdRef5);
         A1711ProdRef6 = "";
         AssignAttri("", false, "A1711ProdRef6", A1711ProdRef6);
         A1712ProdRef7 = "";
         AssignAttri("", false, "A1712ProdRef7", A1712ProdRef7);
         A1713ProdRef8 = "";
         AssignAttri("", false, "A1713ProdRef8", A1713ProdRef8);
         A1714ProdRef9 = "";
         AssignAttri("", false, "A1714ProdRef9", A1714ProdRef9);
         A1706ProdRef10 = "";
         AssignAttri("", false, "A1706ProdRef10", A1706ProdRef10);
         A1718ProdSts = 0;
         AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         A1681ProdCosto = 0;
         AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrimStr( A1681ProdCosto, 18, 5));
         A1683ProdCostoFec = DateTime.MinValue;
         AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
         A1682ProdCostoD = 0;
         AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrimStr( A1682ProdCostoD, 18, 5));
         A1698ProdIna = 0;
         AssignAttri("", false, "A1698ProdIna", StringUtil.Str( (decimal)(A1698ProdIna), 1, 0));
         A1703ProdPorSel = 0;
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrimStr( A1703ProdPorSel, 6, 2));
         A1697ProdImpSel = 0;
         AssignAttri("", false, "A1697ProdImpSel", StringUtil.LTrimStr( A1697ProdImpSel, 15, 2));
         A1672ProdAdValor = 0;
         AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrimStr( A1672ProdAdValor, 6, 2));
         A1696ProdFrecuente = 0;
         AssignAttri("", false, "A1696ProdFrecuente", StringUtil.Str( (decimal)(A1696ProdFrecuente), 1, 0));
         A48ProdCuentaV = "";
         n48ProdCuentaV = false;
         AssignAttri("", false, "A48ProdCuentaV", A48ProdCuentaV);
         n48ProdCuentaV = (String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ? true : false);
         A1686ProdCuentaVDsc = "";
         AssignAttri("", false, "A1686ProdCuentaVDsc", A1686ProdCuentaVDsc);
         A53ProdCuentaC = "";
         n53ProdCuentaC = false;
         AssignAttri("", false, "A53ProdCuentaC", A53ProdCuentaC);
         n53ProdCuentaC = (String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ? true : false);
         A1685ProdCuentaCDsc = "";
         AssignAttri("", false, "A1685ProdCuentaCDsc", A1685ProdCuentaCDsc);
         A54ProdCuentaA = "";
         n54ProdCuentaA = false;
         AssignAttri("", false, "A54ProdCuentaA", A54ProdCuentaA);
         n54ProdCuentaA = (String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ? true : false);
         A1684ProdCuentaADsc = "";
         AssignAttri("", false, "A1684ProdCuentaADsc", A1684ProdCuentaADsc);
         A1721ProdUsuCod = "";
         AssignAttri("", false, "A1721ProdUsuCod", A1721ProdUsuCod);
         A1722ProdUsuFec = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 8, 5, 0, 3, "/", ":", " "));
         A1673ProdAfec = 0;
         AssignAttri("", false, "A1673ProdAfec", StringUtil.Str( (decimal)(A1673ProdAfec), 1, 0));
         A1701ProdObs = "";
         AssignAttri("", false, "A1701ProdObs", A1701ProdObs);
         A1675ProdCanLote = 0;
         AssignAttri("", false, "A1675ProdCanLote", StringUtil.LTrimStr( A1675ProdCanLote, 15, 2));
         A1674ProdBarra = "";
         AssignAttri("", false, "A1674ProdBarra", A1674ProdBarra);
         A1689ProdExportacion = "";
         AssignAttri("", false, "A1689ProdExportacion", A1689ProdExportacion);
         A47CBSuCod = "";
         n47CBSuCod = false;
         AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
         A906ProdAfecICBPER = 0;
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
         A907ProdValICBPER = 0;
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
         A908ProdValICBPERD = 0;
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
         A46cDetCod = 0;
         n46cDetCod = false;
         AssignAttri("", false, "A46cDetCod", StringUtil.LTrimStr( (decimal)(A46cDetCod), 6, 0));
         Z55ProdDsc = "";
         Z1724ProdVta = 0;
         Z1679ProdCmp = 0;
         Z1702ProdPeso = 0;
         Z1723ProdVolumen = 0;
         Z1716ProdStkMax = 0;
         Z1717ProdStkMin = 0;
         Z1705ProdRef1 = "";
         Z1707ProdRef2 = "";
         Z1708ProdRef3 = "";
         Z1709ProdRef4 = "";
         Z1710ProdRef5 = "";
         Z1711ProdRef6 = "";
         Z1712ProdRef7 = "";
         Z1713ProdRef8 = "";
         Z1714ProdRef9 = "";
         Z1706ProdRef10 = "";
         Z1718ProdSts = 0;
         Z1681ProdCosto = 0;
         Z1683ProdCostoFec = DateTime.MinValue;
         Z1682ProdCostoD = 0;
         Z1698ProdIna = 0;
         Z1703ProdPorSel = 0;
         Z1697ProdImpSel = 0;
         Z1672ProdAdValor = 0;
         Z1696ProdFrecuente = 0;
         Z1721ProdUsuCod = "";
         Z1722ProdUsuFec = (DateTime)(DateTime.MinValue);
         Z1673ProdAfec = 0;
         Z1701ProdObs = "";
         Z1675ProdCanLote = 0;
         Z1674ProdBarra = "";
         Z1689ProdExportacion = "";
         Z906ProdAfecICBPER = 0;
         Z907ProdValICBPER = 0;
         Z908ProdValICBPERD = 0;
         Z52LinCod = 0;
         Z51SublCod = 0;
         Z50FamCod = 0;
         Z49UniCod = 0;
         Z47CBSuCod = "";
         Z46cDetCod = 0;
         Z48ProdCuentaV = "";
         Z53ProdCuentaC = "";
         Z54ProdCuentaA = "";
      }

      protected void InitAll1A44( )
      {
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         InitializeNonKey1A44( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281816425731", true, true);
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
         context.AddJavascriptSource("aproductos.js", "?202281816425731", false, true);
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
         edtProdCod_Internalname = "PRODCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtLinCod_Internalname = "LINCOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtProdDsc_Internalname = "PRODDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtSublCod_Internalname = "SUBLCOD";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtFamCod_Internalname = "FAMCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtUniCod_Internalname = "UNICOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         chkProdVta_Internalname = "PRODVTA";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         chkProdCmp_Internalname = "PRODCMP";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtProdPeso_Internalname = "PRODPESO";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtProdVolumen_Internalname = "PRODVOLUMEN";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtProdStkMax_Internalname = "PRODSTKMAX";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtProdStkMin_Internalname = "PRODSTKMIN";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         imgProdFoto_Internalname = "PRODFOTO";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtProdRef1_Internalname = "PRODREF1";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtProdRef2_Internalname = "PRODREF2";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtProdRef3_Internalname = "PRODREF3";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtProdRef4_Internalname = "PRODREF4";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtProdRef5_Internalname = "PRODREF5";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtProdRef6_Internalname = "PRODREF6";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtProdRef7_Internalname = "PRODREF7";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtProdRef8_Internalname = "PRODREF8";
         lblTextblock22_Internalname = "TEXTBLOCK22";
         edtProdRef9_Internalname = "PRODREF9";
         lblTextblock23_Internalname = "TEXTBLOCK23";
         edtProdRef10_Internalname = "PRODREF10";
         lblTextblock24_Internalname = "TEXTBLOCK24";
         cmbProdSts_Internalname = "PRODSTS";
         lblTextblock25_Internalname = "TEXTBLOCK25";
         edtProdCosto_Internalname = "PRODCOSTO";
         lblTextblock26_Internalname = "TEXTBLOCK26";
         edtProdCostoFec_Internalname = "PRODCOSTOFEC";
         lblTextblock27_Internalname = "TEXTBLOCK27";
         edtProdCostoD_Internalname = "PRODCOSTOD";
         lblTextblock28_Internalname = "TEXTBLOCK28";
         edtProdIna_Internalname = "PRODINA";
         lblTextblock29_Internalname = "TEXTBLOCK29";
         edtProdPorSel_Internalname = "PRODPORSEL";
         lblTextblock30_Internalname = "TEXTBLOCK30";
         edtProdAdValor_Internalname = "PRODADVALOR";
         lblTextblock31_Internalname = "TEXTBLOCK31";
         edtProdReferencias_Internalname = "PRODREFERENCIAS";
         lblTextblock32_Internalname = "TEXTBLOCK32";
         edtProdFrecuente_Internalname = "PRODFRECUENTE";
         lblTextblock33_Internalname = "TEXTBLOCK33";
         edtProdCuentaV_Internalname = "PRODCUENTAV";
         lblTextblock34_Internalname = "TEXTBLOCK34";
         edtProdCuentaVDsc_Internalname = "PRODCUENTAVDSC";
         lblTextblock35_Internalname = "TEXTBLOCK35";
         edtProdCuentaC_Internalname = "PRODCUENTAC";
         lblTextblock36_Internalname = "TEXTBLOCK36";
         edtProdCuentaCDsc_Internalname = "PRODCUENTACDSC";
         lblTextblock37_Internalname = "TEXTBLOCK37";
         edtProdCuentaA_Internalname = "PRODCUENTAA";
         lblTextblock38_Internalname = "TEXTBLOCK38";
         edtProdCuentaADsc_Internalname = "PRODCUENTAADSC";
         lblTextblock39_Internalname = "TEXTBLOCK39";
         edtProdUsuCod_Internalname = "PRODUSUCOD";
         lblTextblock40_Internalname = "TEXTBLOCK40";
         edtProdUsuFec_Internalname = "PRODUSUFEC";
         lblTextblock41_Internalname = "TEXTBLOCK41";
         edtProdAfec_Internalname = "PRODAFEC";
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
         Form.Caption = "Productos";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtProdAfec_Jsonclick = "";
         edtProdAfec_Enabled = 1;
         edtProdUsuFec_Jsonclick = "";
         edtProdUsuFec_Enabled = 1;
         edtProdUsuCod_Jsonclick = "";
         edtProdUsuCod_Enabled = 1;
         edtProdCuentaADsc_Jsonclick = "";
         edtProdCuentaADsc_Enabled = 0;
         edtProdCuentaA_Jsonclick = "";
         edtProdCuentaA_Enabled = 1;
         edtProdCuentaCDsc_Jsonclick = "";
         edtProdCuentaCDsc_Enabled = 0;
         edtProdCuentaC_Jsonclick = "";
         edtProdCuentaC_Enabled = 1;
         edtProdCuentaVDsc_Jsonclick = "";
         edtProdCuentaVDsc_Enabled = 0;
         edtProdCuentaV_Jsonclick = "";
         edtProdCuentaV_Enabled = 1;
         edtProdFrecuente_Jsonclick = "";
         edtProdFrecuente_Enabled = 1;
         edtProdReferencias_Enabled = 0;
         edtProdAdValor_Jsonclick = "";
         edtProdAdValor_Enabled = 1;
         edtProdPorSel_Jsonclick = "";
         edtProdPorSel_Enabled = 1;
         edtProdIna_Jsonclick = "";
         edtProdIna_Enabled = 1;
         edtProdCostoD_Jsonclick = "";
         edtProdCostoD_Enabled = 1;
         edtProdCostoFec_Jsonclick = "";
         edtProdCostoFec_Enabled = 1;
         edtProdCosto_Jsonclick = "";
         edtProdCosto_Enabled = 1;
         cmbProdSts_Jsonclick = "";
         cmbProdSts.Enabled = 1;
         edtProdRef10_Jsonclick = "";
         edtProdRef10_Enabled = 1;
         edtProdRef9_Jsonclick = "";
         edtProdRef9_Enabled = 1;
         edtProdRef8_Jsonclick = "";
         edtProdRef8_Enabled = 1;
         edtProdRef7_Jsonclick = "";
         edtProdRef7_Enabled = 1;
         edtProdRef6_Jsonclick = "";
         edtProdRef6_Enabled = 1;
         edtProdRef5_Jsonclick = "";
         edtProdRef5_Enabled = 1;
         edtProdRef4_Jsonclick = "";
         edtProdRef4_Enabled = 1;
         edtProdRef3_Jsonclick = "";
         edtProdRef3_Enabled = 1;
         edtProdRef2_Jsonclick = "";
         edtProdRef2_Enabled = 1;
         edtProdRef1_Jsonclick = "";
         edtProdRef1_Enabled = 1;
         imgProdFoto_Enabled = 1;
         edtProdStkMin_Jsonclick = "";
         edtProdStkMin_Enabled = 1;
         edtProdStkMax_Jsonclick = "";
         edtProdStkMax_Enabled = 1;
         edtProdVolumen_Jsonclick = "";
         edtProdVolumen_Enabled = 1;
         edtProdPeso_Jsonclick = "";
         edtProdPeso_Enabled = 1;
         chkProdCmp.Enabled = 1;
         chkProdVta.Enabled = 1;
         edtUniCod_Jsonclick = "";
         edtUniCod_Enabled = 1;
         edtFamCod_Jsonclick = "";
         edtFamCod_Enabled = 1;
         edtSublCod_Jsonclick = "";
         edtSublCod_Enabled = 1;
         edtProdDsc_Jsonclick = "";
         edtProdDsc_Enabled = 1;
         edtLinCod_Jsonclick = "";
         edtLinCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtProdCod_Jsonclick = "";
         edtProdCod_Enabled = 1;
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
         chkProdVta.Name = "PRODVTA";
         chkProdVta.WebTags = "";
         chkProdVta.Caption = "";
         AssignProp("", false, chkProdVta_Internalname, "TitleCaption", chkProdVta.Caption, true);
         chkProdVta.CheckedValue = "0";
         A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1724ProdVta", StringUtil.Str( (decimal)(A1724ProdVta), 1, 0));
         chkProdCmp.Name = "PRODCMP";
         chkProdCmp.WebTags = "";
         chkProdCmp.Caption = "";
         AssignProp("", false, chkProdCmp_Internalname, "TitleCaption", chkProdCmp.Caption, true);
         chkProdCmp.CheckedValue = "0";
         A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1679ProdCmp", StringUtil.Str( (decimal)(A1679ProdCmp), 1, 0));
         cmbProdSts.Name = "PRODSTS";
         cmbProdSts.WebTags = "";
         cmbProdSts.addItem("1", "ACTIVO", 0);
         cmbProdSts.addItem("0", "INACTIVO", 0);
         if ( cmbProdSts.ItemCount > 0 )
         {
            A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
            AssignAttri("", false, "A1718ProdSts", StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtLinCod_Internalname;
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

      public void Valid_Prodcod( )
      {
         A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.CurrentValue, "."));
         cmbProdSts.CurrentValue = StringUtil.Str( (decimal)(A1718ProdSts), 1, 0);
         n47CBSuCod = false;
         n46cDetCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A1724ProdVta = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A1679ProdCmp = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         if ( cmbProdSts.ItemCount > 0 )
         {
            A1718ProdSts = (short)(NumberUtil.Val( cmbProdSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0))), "."));
            cmbProdSts.CurrentValue = StringUtil.Str( (decimal)(A1718ProdSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")));
         AssignAttri("", false, "A55ProdDsc", StringUtil.RTrim( A55ProdDsc));
         AssignAttri("", false, "A51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")));
         AssignAttri("", false, "A50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")));
         AssignAttri("", false, "A49UniCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1724ProdVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1724ProdVta), 1, 0, ".", "")));
         AssignAttri("", false, "A1679ProdCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1679ProdCmp), 1, 0, ".", "")));
         AssignAttri("", false, "A1702ProdPeso", StringUtil.LTrim( StringUtil.NToC( A1702ProdPeso, 15, 5, ".", "")));
         AssignAttri("", false, "A1723ProdVolumen", StringUtil.LTrim( StringUtil.NToC( A1723ProdVolumen, 15, 5, ".", "")));
         AssignAttri("", false, "A1716ProdStkMax", StringUtil.LTrim( StringUtil.NToC( A1716ProdStkMax, 15, 4, ".", "")));
         AssignAttri("", false, "A1717ProdStkMin", StringUtil.LTrim( StringUtil.NToC( A1717ProdStkMin, 15, 4, ".", "")));
         AssignAttri("", false, "A1695ProdFoto", context.PathToRelativeUrl( A1695ProdFoto));
         GXCCtlgxBlob = "PRODFOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A1695ProdFoto));
         AssignAttri("", false, "A40000ProdFoto_GXI", A40000ProdFoto_GXI);
         AssignAttri("", false, "A1705ProdRef1", StringUtil.RTrim( A1705ProdRef1));
         AssignAttri("", false, "A1707ProdRef2", StringUtil.RTrim( A1707ProdRef2));
         AssignAttri("", false, "A1708ProdRef3", StringUtil.RTrim( A1708ProdRef3));
         AssignAttri("", false, "A1709ProdRef4", StringUtil.RTrim( A1709ProdRef4));
         AssignAttri("", false, "A1710ProdRef5", StringUtil.RTrim( A1710ProdRef5));
         AssignAttri("", false, "A1711ProdRef6", StringUtil.RTrim( A1711ProdRef6));
         AssignAttri("", false, "A1712ProdRef7", StringUtil.RTrim( A1712ProdRef7));
         AssignAttri("", false, "A1713ProdRef8", StringUtil.RTrim( A1713ProdRef8));
         AssignAttri("", false, "A1714ProdRef9", StringUtil.RTrim( A1714ProdRef9));
         AssignAttri("", false, "A1706ProdRef10", StringUtil.RTrim( A1706ProdRef10));
         AssignAttri("", false, "A1718ProdSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1718ProdSts), 1, 0, ".", "")));
         cmbProdSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1718ProdSts), 1, 0));
         AssignProp("", false, cmbProdSts_Internalname, "Values", cmbProdSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A1681ProdCosto", StringUtil.LTrim( StringUtil.NToC( A1681ProdCosto, 18, 5, ".", "")));
         AssignAttri("", false, "A1683ProdCostoFec", context.localUtil.Format(A1683ProdCostoFec, "99/99/99"));
         AssignAttri("", false, "A1682ProdCostoD", StringUtil.LTrim( StringUtil.NToC( A1682ProdCostoD, 18, 5, ".", "")));
         AssignAttri("", false, "A1698ProdIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1698ProdIna), 1, 0, ".", "")));
         AssignAttri("", false, "A1703ProdPorSel", StringUtil.LTrim( StringUtil.NToC( A1703ProdPorSel, 6, 2, ".", "")));
         AssignAttri("", false, "A1697ProdImpSel", StringUtil.LTrim( StringUtil.NToC( A1697ProdImpSel, 15, 2, ".", "")));
         AssignAttri("", false, "A1672ProdAdValor", StringUtil.LTrim( StringUtil.NToC( A1672ProdAdValor, 6, 2, ".", "")));
         AssignAttri("", false, "A1696ProdFrecuente", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1696ProdFrecuente), 1, 0, ".", "")));
         AssignAttri("", false, "A48ProdCuentaV", StringUtil.RTrim( A48ProdCuentaV));
         AssignAttri("", false, "A53ProdCuentaC", StringUtil.RTrim( A53ProdCuentaC));
         AssignAttri("", false, "A54ProdCuentaA", StringUtil.RTrim( A54ProdCuentaA));
         AssignAttri("", false, "A1721ProdUsuCod", StringUtil.RTrim( A1721ProdUsuCod));
         AssignAttri("", false, "A1722ProdUsuFec", context.localUtil.TToC( A1722ProdUsuFec, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A1673ProdAfec", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1673ProdAfec), 1, 0, ".", "")));
         AssignAttri("", false, "A1701ProdObs", A1701ProdObs);
         AssignAttri("", false, "A1675ProdCanLote", StringUtil.LTrim( StringUtil.NToC( A1675ProdCanLote, 15, 2, ".", "")));
         AssignAttri("", false, "A1674ProdBarra", A1674ProdBarra);
         AssignAttri("", false, "A1689ProdExportacion", A1689ProdExportacion);
         AssignAttri("", false, "A47CBSuCod", A47CBSuCod);
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         AssignAttri("", false, "A46cDetCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A46cDetCod), 6, 0, ".", "")));
         AssignAttri("", false, "A1715ProdReferencias", A1715ProdReferencias);
         AssignAttri("", false, "A1686ProdCuentaVDsc", StringUtil.RTrim( A1686ProdCuentaVDsc));
         AssignAttri("", false, "A1685ProdCuentaCDsc", StringUtil.RTrim( A1685ProdCuentaCDsc));
         AssignAttri("", false, "A1684ProdCuentaADsc", StringUtil.RTrim( A1684ProdCuentaADsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z55ProdDsc", StringUtil.RTrim( Z55ProdDsc));
         GxWebStd.gx_hidden_field( context, "Z51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49UniCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49UniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1724ProdVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1724ProdVta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1679ProdCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1679ProdCmp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1702ProdPeso", StringUtil.LTrim( StringUtil.NToC( Z1702ProdPeso, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1723ProdVolumen", StringUtil.LTrim( StringUtil.NToC( Z1723ProdVolumen, 15, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1716ProdStkMax", StringUtil.LTrim( StringUtil.NToC( Z1716ProdStkMax, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1717ProdStkMin", StringUtil.LTrim( StringUtil.NToC( Z1717ProdStkMin, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1695ProdFoto", context.PathToRelativeUrl( Z1695ProdFoto));
         GxWebStd.gx_hidden_field( context, "Z40000ProdFoto_GXI", Z40000ProdFoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z1705ProdRef1", StringUtil.RTrim( Z1705ProdRef1));
         GxWebStd.gx_hidden_field( context, "Z1707ProdRef2", StringUtil.RTrim( Z1707ProdRef2));
         GxWebStd.gx_hidden_field( context, "Z1708ProdRef3", StringUtil.RTrim( Z1708ProdRef3));
         GxWebStd.gx_hidden_field( context, "Z1709ProdRef4", StringUtil.RTrim( Z1709ProdRef4));
         GxWebStd.gx_hidden_field( context, "Z1710ProdRef5", StringUtil.RTrim( Z1710ProdRef5));
         GxWebStd.gx_hidden_field( context, "Z1711ProdRef6", StringUtil.RTrim( Z1711ProdRef6));
         GxWebStd.gx_hidden_field( context, "Z1712ProdRef7", StringUtil.RTrim( Z1712ProdRef7));
         GxWebStd.gx_hidden_field( context, "Z1713ProdRef8", StringUtil.RTrim( Z1713ProdRef8));
         GxWebStd.gx_hidden_field( context, "Z1714ProdRef9", StringUtil.RTrim( Z1714ProdRef9));
         GxWebStd.gx_hidden_field( context, "Z1706ProdRef10", StringUtil.RTrim( Z1706ProdRef10));
         GxWebStd.gx_hidden_field( context, "Z1718ProdSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1718ProdSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1681ProdCosto", StringUtil.LTrim( StringUtil.NToC( Z1681ProdCosto, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1683ProdCostoFec", context.localUtil.Format(Z1683ProdCostoFec, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "Z1682ProdCostoD", StringUtil.LTrim( StringUtil.NToC( Z1682ProdCostoD, 18, 5, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1698ProdIna", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1698ProdIna), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1703ProdPorSel", StringUtil.LTrim( StringUtil.NToC( Z1703ProdPorSel, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1697ProdImpSel", StringUtil.LTrim( StringUtil.NToC( Z1697ProdImpSel, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1672ProdAdValor", StringUtil.LTrim( StringUtil.NToC( Z1672ProdAdValor, 6, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1696ProdFrecuente", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1696ProdFrecuente), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z48ProdCuentaV", StringUtil.RTrim( Z48ProdCuentaV));
         GxWebStd.gx_hidden_field( context, "Z53ProdCuentaC", StringUtil.RTrim( Z53ProdCuentaC));
         GxWebStd.gx_hidden_field( context, "Z54ProdCuentaA", StringUtil.RTrim( Z54ProdCuentaA));
         GxWebStd.gx_hidden_field( context, "Z1721ProdUsuCod", StringUtil.RTrim( Z1721ProdUsuCod));
         GxWebStd.gx_hidden_field( context, "Z1722ProdUsuFec", context.localUtil.TToC( Z1722ProdUsuFec, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z1673ProdAfec", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1673ProdAfec), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1701ProdObs", Z1701ProdObs);
         GxWebStd.gx_hidden_field( context, "Z1675ProdCanLote", StringUtil.LTrim( StringUtil.NToC( Z1675ProdCanLote, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1674ProdBarra", Z1674ProdBarra);
         GxWebStd.gx_hidden_field( context, "Z1689ProdExportacion", Z1689ProdExportacion);
         GxWebStd.gx_hidden_field( context, "Z47CBSuCod", Z47CBSuCod);
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z46cDetCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z46cDetCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1715ProdReferencias", Z1715ProdReferencias);
         GxWebStd.gx_hidden_field( context, "Z1686ProdCuentaVDsc", StringUtil.RTrim( Z1686ProdCuentaVDsc));
         GxWebStd.gx_hidden_field( context, "Z1685ProdCuentaCDsc", StringUtil.RTrim( Z1685ProdCuentaCDsc));
         GxWebStd.gx_hidden_field( context, "Z1684ProdCuentaADsc", StringUtil.RTrim( Z1684ProdCuentaADsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Lincod( )
      {
         /* Using cursor T001A65 */
         pr_default.execute(63, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(63) == 101) )
         {
            GX_msglist.addItem("No existe 'Linea de Producto'.", "ForeignKeyNotFound", 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
         }
         pr_default.close(63);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Sublcod( )
      {
         n51SublCod = false;
         /* Using cursor T001A66 */
         pr_default.execute(64, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(64) == 101) )
         {
            if ( ! ( (0==A51SublCod) ) )
            {
               GX_msglist.addItem("No existe 'Sub Linea de Producto'.", "ForeignKeyNotFound", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
            }
         }
         pr_default.close(64);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Famcod( )
      {
         n50FamCod = false;
         /* Using cursor T001A67 */
         pr_default.execute(65, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(65) == 101) )
         {
            if ( ! ( (0==A50FamCod) ) )
            {
               GX_msglist.addItem("No existe 'Familia'.", "ForeignKeyNotFound", 1, "FAMCOD");
               AnyError = 1;
               GX_FocusControl = edtFamCod_Internalname;
            }
         }
         pr_default.close(65);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Unicod( )
      {
         /* Using cursor T001A68 */
         pr_default.execute(66, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(66) == 101) )
         {
            GX_msglist.addItem("No existe 'Unidad de Medida'.", "ForeignKeyNotFound", 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
         }
         pr_default.close(66);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prodcuentav( )
      {
         n48ProdCuentaV = false;
         /* Using cursor T001A28 */
         pr_default.execute(26, new Object[] {n48ProdCuentaV, A48ProdCuentaV});
         if ( (pr_default.getStatus(26) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A48ProdCuentaV)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAV");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaV_Internalname;
            }
         }
         A1686ProdCuentaVDsc = T001A28_A1686ProdCuentaVDsc[0];
         pr_default.close(26);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1686ProdCuentaVDsc", StringUtil.RTrim( A1686ProdCuentaVDsc));
      }

      public void Valid_Prodcuentac( )
      {
         n53ProdCuentaC = false;
         /* Using cursor T001A29 */
         pr_default.execute(27, new Object[] {n53ProdCuentaC, A53ProdCuentaC});
         if ( (pr_default.getStatus(27) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A53ProdCuentaC)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "PRODCUENTAC");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaC_Internalname;
            }
         }
         A1685ProdCuentaCDsc = T001A29_A1685ProdCuentaCDsc[0];
         pr_default.close(27);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1685ProdCuentaCDsc", StringUtil.RTrim( A1685ProdCuentaCDsc));
      }

      public void Valid_Prodcuentaa( )
      {
         n54ProdCuentaA = false;
         /* Using cursor T001A30 */
         pr_default.execute(28, new Object[] {n54ProdCuentaA, A54ProdCuentaA});
         if ( (pr_default.getStatus(28) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A54ProdCuentaA)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Almacen'.", "ForeignKeyNotFound", 1, "PRODCUENTAA");
               AnyError = 1;
               GX_FocusControl = edtProdCuentaA_Internalname;
            }
         }
         A1684ProdCuentaADsc = T001A30_A1684ProdCuentaADsc[0];
         pr_default.close(28);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1684ProdCuentaADsc", StringUtil.RTrim( A1684ProdCuentaADsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1697ProdImpSel',fld:'PRODIMPSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1701ProdObs',fld:'PRODOBS',pic:''},{av:'A1675ProdCanLote',fld:'PRODCANLOTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1674ProdBarra',fld:'PRODBARRA',pic:''},{av:'A1689ProdExportacion',fld:'PRODEXPORTACION',pic:''},{av:'A47CBSuCod',fld:'CBSUCOD',pic:''},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A46cDetCod',fld:'CDETCOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E121A2',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A1689ProdExportacion',fld:'PRODEXPORTACION',pic:''},{av:'A1674ProdBarra',fld:'PRODBARRA',pic:''},{av:'A1675ProdCanLote',fld:'PRODCANLOTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1701ProdObs',fld:'PRODOBS',pic:''},{av:'A1697ProdImpSel',fld:'PRODIMPSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'cmbProdSts'},{av:'A1718ProdSts',fld:'PRODSTS',pic:'9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'A47CBSuCod',fld:'CBSUCOD',pic:''},{av:'A46cDetCod',fld:'CDETCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A55ProdDsc',fld:'PRODDSC',pic:''},{av:'A51SublCod',fld:'SUBLCOD',pic:'ZZZZZ9'},{av:'A50FamCod',fld:'FAMCOD',pic:'ZZZZZ9'},{av:'A49UniCod',fld:'UNICOD',pic:'ZZZZZ9'},{av:'A1702ProdPeso',fld:'PRODPESO',pic:'ZZZZZZZZ9.99999'},{av:'A1723ProdVolumen',fld:'PRODVOLUMEN',pic:'ZZZZZZZZ9.99999'},{av:'A1716ProdStkMax',fld:'PRODSTKMAX',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1717ProdStkMin',fld:'PRODSTKMIN',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1695ProdFoto',fld:'PRODFOTO',pic:''},{av:'A40000ProdFoto_GXI',fld:'PRODFOTO_GXI',pic:''},{av:'A1705ProdRef1',fld:'PRODREF1',pic:''},{av:'A1707ProdRef2',fld:'PRODREF2',pic:''},{av:'A1708ProdRef3',fld:'PRODREF3',pic:''},{av:'A1709ProdRef4',fld:'PRODREF4',pic:''},{av:'A1710ProdRef5',fld:'PRODREF5',pic:''},{av:'A1711ProdRef6',fld:'PRODREF6',pic:''},{av:'A1712ProdRef7',fld:'PRODREF7',pic:''},{av:'A1713ProdRef8',fld:'PRODREF8',pic:''},{av:'A1714ProdRef9',fld:'PRODREF9',pic:''},{av:'A1706ProdRef10',fld:'PRODREF10',pic:''},{av:'cmbProdSts'},{av:'A1718ProdSts',fld:'PRODSTS',pic:'9'},{av:'A1681ProdCosto',fld:'PRODCOSTO',pic:'ZZZZZZZZZZZ9.99999'},{av:'A1683ProdCostoFec',fld:'PRODCOSTOFEC',pic:''},{av:'A1682ProdCostoD',fld:'PRODCOSTOD',pic:'ZZZZZZZZZZZ9.99999'},{av:'A1698ProdIna',fld:'PRODINA',pic:'9'},{av:'A1703ProdPorSel',fld:'PRODPORSEL',pic:'ZZ9.99'},{av:'A1697ProdImpSel',fld:'PRODIMPSEL',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1672ProdAdValor',fld:'PRODADVALOR',pic:'ZZ9.99'},{av:'A1696ProdFrecuente',fld:'PRODFRECUENTE',pic:'9'},{av:'A48ProdCuentaV',fld:'PRODCUENTAV',pic:''},{av:'A53ProdCuentaC',fld:'PRODCUENTAC',pic:''},{av:'A54ProdCuentaA',fld:'PRODCUENTAA',pic:''},{av:'A1721ProdUsuCod',fld:'PRODUSUCOD',pic:''},{av:'A1722ProdUsuFec',fld:'PRODUSUFEC',pic:'99/99/99 99:99'},{av:'A1673ProdAfec',fld:'PRODAFEC',pic:'9'},{av:'A1701ProdObs',fld:'PRODOBS',pic:''},{av:'A1675ProdCanLote',fld:'PRODCANLOTE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A1674ProdBarra',fld:'PRODBARRA',pic:''},{av:'A1689ProdExportacion',fld:'PRODEXPORTACION',pic:''},{av:'A47CBSuCod',fld:'CBSUCOD',pic:''},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A46cDetCod',fld:'CDETCOD',pic:'ZZZZZ9'},{av:'A1715ProdReferencias',fld:'PRODREFERENCIAS',pic:''},{av:'A1686ProdCuentaVDsc',fld:'PRODCUENTAVDSC',pic:''},{av:'A1685ProdCuentaCDsc',fld:'PRODCUENTACDSC',pic:''},{av:'A1684ProdCuentaADsc',fld:'PRODCUENTAADSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z28ProdCod'},{av:'Z52LinCod'},{av:'Z55ProdDsc'},{av:'Z51SublCod'},{av:'Z50FamCod'},{av:'Z49UniCod'},{av:'Z1724ProdVta'},{av:'Z1679ProdCmp'},{av:'Z1702ProdPeso'},{av:'Z1723ProdVolumen'},{av:'Z1716ProdStkMax'},{av:'Z1717ProdStkMin'},{av:'Z1695ProdFoto'},{av:'Z40000ProdFoto_GXI'},{av:'Z1705ProdRef1'},{av:'Z1707ProdRef2'},{av:'Z1708ProdRef3'},{av:'Z1709ProdRef4'},{av:'Z1710ProdRef5'},{av:'Z1711ProdRef6'},{av:'Z1712ProdRef7'},{av:'Z1713ProdRef8'},{av:'Z1714ProdRef9'},{av:'Z1706ProdRef10'},{av:'Z1718ProdSts'},{av:'Z1681ProdCosto'},{av:'Z1683ProdCostoFec'},{av:'Z1682ProdCostoD'},{av:'Z1698ProdIna'},{av:'Z1703ProdPorSel'},{av:'Z1697ProdImpSel'},{av:'Z1672ProdAdValor'},{av:'Z1696ProdFrecuente'},{av:'Z48ProdCuentaV'},{av:'Z53ProdCuentaC'},{av:'Z54ProdCuentaA'},{av:'Z1721ProdUsuCod'},{av:'Z1722ProdUsuFec'},{av:'Z1673ProdAfec'},{av:'Z1701ProdObs'},{av:'Z1675ProdCanLote'},{av:'Z1674ProdBarra'},{av:'Z1689ProdExportacion'},{av:'Z47CBSuCod'},{av:'Z906ProdAfecICBPER'},{av:'Z907ProdValICBPER'},{av:'Z908ProdValICBPERD'},{av:'Z46cDetCod'},{av:'Z1715ProdReferencias'},{av:'Z1686ProdCuentaVDsc'},{av:'Z1685ProdCuentaCDsc'},{av:'Z1684ProdCuentaADsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_LINCOD","{handler:'Valid_Lincod',iparms:[{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_LINCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_SUBLCOD","{handler:'Valid_Sublcod',iparms:[{av:'A51SublCod',fld:'SUBLCOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_SUBLCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_FAMCOD","{handler:'Valid_Famcod',iparms:[{av:'A50FamCod',fld:'FAMCOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_FAMCOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_UNICOD","{handler:'Valid_Unicod',iparms:[{av:'A49UniCod',fld:'UNICOD',pic:'ZZZZZ9'},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_UNICOD",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF1","{handler:'Valid_Prodref1',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF1",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF2","{handler:'Valid_Prodref2',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF2",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF3","{handler:'Valid_Prodref3',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF3",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF4","{handler:'Valid_Prodref4',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF4",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF5","{handler:'Valid_Prodref5',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF5",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF6","{handler:'Valid_Prodref6',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF6",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF7","{handler:'Valid_Prodref7',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF7",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF8","{handler:'Valid_Prodref8',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF8",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF9","{handler:'Valid_Prodref9',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF9",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODREF10","{handler:'Valid_Prodref10',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODREF10",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCOSTOFEC","{handler:'Valid_Prodcostofec',iparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCOSTOFEC",",oparms:[{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCUENTAV","{handler:'Valid_Prodcuentav',iparms:[{av:'A48ProdCuentaV',fld:'PRODCUENTAV',pic:''},{av:'A1686ProdCuentaVDsc',fld:'PRODCUENTAVDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCUENTAV",",oparms:[{av:'A1686ProdCuentaVDsc',fld:'PRODCUENTAVDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCUENTAC","{handler:'Valid_Prodcuentac',iparms:[{av:'A53ProdCuentaC',fld:'PRODCUENTAC',pic:''},{av:'A1685ProdCuentaCDsc',fld:'PRODCUENTACDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCUENTAC",",oparms:[{av:'A1685ProdCuentaCDsc',fld:'PRODCUENTACDSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]}");
         setEventMetadata("VALID_PRODCUENTAA","{handler:'Valid_Prodcuentaa',iparms:[{av:'A54ProdCuentaA',fld:'PRODCUENTAA',pic:''},{av:'A1684ProdCuentaADsc',fld:'PRODCUENTAADSC',pic:''},{av:'A1724ProdVta',fld:'PRODVTA',pic:'9'},{av:'A1679ProdCmp',fld:'PRODCMP',pic:'9'}]");
         setEventMetadata("VALID_PRODCUENTAA"