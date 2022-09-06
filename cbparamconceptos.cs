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
   public class cbparamconceptos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
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
            gxLoad_4( A83ParTip, A84ParCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A91CueCod = GetPar( "CueCod");
            AssignAttri("", false, "A91CueCod", A91CueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A91CueCod) ;
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
            Form.Meta.addItem("description", "CBPARAMCONCEPTOS", 0) ;
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

      public cbparamconceptos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cbparamconceptos( IGxContext context )
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
         cmbRHConTipRem = new GXCombobox();
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
         if ( cmbRHConTipRem.ItemCount > 0 )
         {
            A1820RHConTipRem = cmbRHConTipRem.getValidValue(A1820RHConTipRem);
            AssignAttri("", false, "A1820RHConTipRem", A1820RHConTipRem);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRHConTipRem.CurrentValue = StringUtil.RTrim( A1820RHConTipRem);
            AssignProp("", false, cmbRHConTipRem_Internalname, "Values", cmbRHConTipRem.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CBPARAMCONCEPTOS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Tipo de Asiento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParTip_Internalname, StringUtil.RTrim( A83ParTip), StringUtil.RTrim( context.localUtil.Format( A83ParTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParTip_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Secuencia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A84ParCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtParCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A84ParCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Item", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTipItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A90ParDTipItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtParDTipItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A90ParDTipItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A90ParDTipItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTipItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTipItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Tipo Remuneración (Remuneraciones,Descuento,Aportación)", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbRHConTipRem, cmbRHConTipRem_Internalname, StringUtil.RTrim( A1820RHConTipRem), 1, cmbRHConTipRem_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbRHConTipRem.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "", true, 1, "HLP_CBPARAMCONCEPTOS.htm");
         cmbRHConTipRem.CurrentValue = StringUtil.RTrim( A1820RHConTipRem);
         AssignProp("", false, cmbRHConTipRem_Internalname, "Values", (string)(cmbRHConTipRem.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Codigo Concepto", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtRHConCod_Internalname, StringUtil.RTrim( A1819RHConCod), StringUtil.RTrim( context.localUtil.Format( A1819RHConCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtRHConCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtRHConCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "C.Costo", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTipCosCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1538ParDTipCosCod), 1, 0, ".", "")), StringUtil.LTrim( ((edtParDTipCosCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1538ParDTipCosCod), "9") : context.localUtil.Format( (decimal)(A1538ParDTipCosCod), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTipCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTipCosCod_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Cuenta", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCueCod_Internalname, StringUtil.RTrim( A91CueCod), StringUtil.RTrim( context.localUtil.Format( A91CueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "D/H", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTipConc_Internalname, StringUtil.RTrim( A1537ParDTipConc), StringUtil.RTrim( context.localUtil.Format( A1537ParDTipConc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTipConc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTipConc_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Flag", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDTipFlag_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1539ParDTipFlag), 1, 0, ".", "")), StringUtil.LTrim( ((edtParDTipFlag_Enabled!=0) ? context.localUtil.Format( (decimal)(A1539ParDTipFlag), "9") : context.localUtil.Format( (decimal)(A1539ParDTipFlag), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDTipFlag_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDTipFlag_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Flag AFP", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDAFP_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1527ParDAFP), 1, 0, ".", "")), StringUtil.LTrim( ((edtParDAFP_Enabled!=0) ? context.localUtil.Format( (decimal)(A1527ParDAFP), "9") : context.localUtil.Format( (decimal)(A1527ParDAFP), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDAFP_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDAFP_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Centro de Costo", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParDCosCod_Internalname, StringUtil.RTrim( A1528ParDCosCod), StringUtil.RTrim( context.localUtil.Format( A1528ParDCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParDCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtParDCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CBPARAMCONCEPTOS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 77,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CBPARAMCONCEPTOS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CBPARAMCONCEPTOS.htm");
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
            Z90ParDTipItem = (int)(context.localUtil.CToN( cgiGet( "Z90ParDTipItem"), ".", ","));
            Z1820RHConTipRem = cgiGet( "Z1820RHConTipRem");
            Z1819RHConCod = cgiGet( "Z1819RHConCod");
            Z1538ParDTipCosCod = (short)(context.localUtil.CToN( cgiGet( "Z1538ParDTipCosCod"), ".", ","));
            Z1537ParDTipConc = cgiGet( "Z1537ParDTipConc");
            Z1539ParDTipFlag = (short)(context.localUtil.CToN( cgiGet( "Z1539ParDTipFlag"), ".", ","));
            Z1527ParDAFP = (short)(context.localUtil.CToN( cgiGet( "Z1527ParDAFP"), ".", ","));
            Z1528ParDCosCod = cgiGet( "Z1528ParDCosCod");
            n1528ParDCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1528ParDCosCod)) ? true : false);
            Z1821RHTipPlaCod = (int)(context.localUtil.CToN( cgiGet( "Z1821RHTipPlaCod"), ".", ","));
            Z91CueCod = cgiGet( "Z91CueCod");
            A1821RHTipPlaCod = (int)(context.localUtil.CToN( cgiGet( "Z1821RHTipPlaCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A1821RHTipPlaCod = (int)(context.localUtil.CToN( cgiGet( "RHTIPPLACOD"), ".", ","));
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
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDTipItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDTipItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDTIPITEM");
               AnyError = 1;
               GX_FocusControl = edtParDTipItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A90ParDTipItem = 0;
               AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
            }
            else
            {
               A90ParDTipItem = (int)(context.localUtil.CToN( cgiGet( edtParDTipItem_Internalname), ".", ","));
               AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
            }
            cmbRHConTipRem.CurrentValue = cgiGet( cmbRHConTipRem_Internalname);
            A1820RHConTipRem = cgiGet( cmbRHConTipRem_Internalname);
            AssignAttri("", false, "A1820RHConTipRem", A1820RHConTipRem);
            A1819RHConCod = cgiGet( edtRHConCod_Internalname);
            AssignAttri("", false, "A1819RHConCod", A1819RHConCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDTipCosCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDTipCosCod_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDTIPCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtParDTipCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1538ParDTipCosCod = 0;
               AssignAttri("", false, "A1538ParDTipCosCod", StringUtil.Str( (decimal)(A1538ParDTipCosCod), 1, 0));
            }
            else
            {
               A1538ParDTipCosCod = (short)(context.localUtil.CToN( cgiGet( edtParDTipCosCod_Internalname), ".", ","));
               AssignAttri("", false, "A1538ParDTipCosCod", StringUtil.Str( (decimal)(A1538ParDTipCosCod), 1, 0));
            }
            A91CueCod = cgiGet( edtCueCod_Internalname);
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A1537ParDTipConc = cgiGet( edtParDTipConc_Internalname);
            AssignAttri("", false, "A1537ParDTipConc", A1537ParDTipConc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDTipFlag_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDTipFlag_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDTIPFLAG");
               AnyError = 1;
               GX_FocusControl = edtParDTipFlag_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1539ParDTipFlag = 0;
               AssignAttri("", false, "A1539ParDTipFlag", StringUtil.Str( (decimal)(A1539ParDTipFlag), 1, 0));
            }
            else
            {
               A1539ParDTipFlag = (short)(context.localUtil.CToN( cgiGet( edtParDTipFlag_Internalname), ".", ","));
               AssignAttri("", false, "A1539ParDTipFlag", StringUtil.Str( (decimal)(A1539ParDTipFlag), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtParDAFP_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtParDAFP_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PARDAFP");
               AnyError = 1;
               GX_FocusControl = edtParDAFP_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1527ParDAFP = 0;
               AssignAttri("", false, "A1527ParDAFP", StringUtil.Str( (decimal)(A1527ParDAFP), 1, 0));
            }
            else
            {
               A1527ParDAFP = (short)(context.localUtil.CToN( cgiGet( edtParDAFP_Internalname), ".", ","));
               AssignAttri("", false, "A1527ParDAFP", StringUtil.Str( (decimal)(A1527ParDAFP), 1, 0));
            }
            A1528ParDCosCod = cgiGet( edtParDCosCod_Internalname);
            n1528ParDCosCod = false;
            AssignAttri("", false, "A1528ParDCosCod", A1528ParDCosCod);
            n1528ParDCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1528ParDCosCod)) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"CBPARAMCONCEPTOS");
            forbiddenHiddens.Add("RHTipPlaCod", context.localUtil.Format( (decimal)(A1821RHTipPlaCod), "ZZZZZ9"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A90ParDTipItem != Z90ParDTipItem ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("cbparamconceptos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
               A83ParTip = GetPar( "ParTip");
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = (int)(NumberUtil.Val( GetPar( "ParCod"), "."));
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A90ParDTipItem = (int)(NumberUtil.Val( GetPar( "ParDTipItem"), "."));
               AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
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
               InitAll1S183( ) ;
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
         DisableAttributes1S183( ) ;
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

      protected void CONFIRM_1S0( )
      {
         BeforeValidate1S183( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1S183( ) ;
            }
            else
            {
               CheckExtendedTable1S183( ) ;
               if ( AnyError == 0 )
               {
                  ZM1S183( 3) ;
                  ZM1S183( 4) ;
               }
               CloseExtendedTableCursors1S183( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1S0( ) ;
         }
      }

      protected void ResetCaption1S0( )
      {
      }

      protected void ZM1S183( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1820RHConTipRem = T001S3_A1820RHConTipRem[0];
               Z1819RHConCod = T001S3_A1819RHConCod[0];
               Z1538ParDTipCosCod = T001S3_A1538ParDTipCosCod[0];
               Z1537ParDTipConc = T001S3_A1537ParDTipConc[0];
               Z1539ParDTipFlag = T001S3_A1539ParDTipFlag[0];
               Z1527ParDAFP = T001S3_A1527ParDAFP[0];
               Z1528ParDCosCod = T001S3_A1528ParDCosCod[0];
               Z1821RHTipPlaCod = T001S3_A1821RHTipPlaCod[0];
               Z91CueCod = T001S3_A91CueCod[0];
            }
            else
            {
               Z1820RHConTipRem = A1820RHConTipRem;
               Z1819RHConCod = A1819RHConCod;
               Z1538ParDTipCosCod = A1538ParDTipCosCod;
               Z1537ParDTipConc = A1537ParDTipConc;
               Z1539ParDTipFlag = A1539ParDTipFlag;
               Z1527ParDAFP = A1527ParDAFP;
               Z1528ParDCosCod = A1528ParDCosCod;
               Z1821RHTipPlaCod = A1821RHTipPlaCod;
               Z91CueCod = A91CueCod;
            }
         }
         if ( GX_JID == -2 )
         {
            Z90ParDTipItem = A90ParDTipItem;
            Z1820RHConTipRem = A1820RHConTipRem;
            Z1819RHConCod = A1819RHConCod;
            Z1538ParDTipCosCod = A1538ParDTipCosCod;
            Z1537ParDTipConc = A1537ParDTipConc;
            Z1539ParDTipFlag = A1539ParDTipFlag;
            Z1527ParDAFP = A1527ParDAFP;
            Z1528ParDCosCod = A1528ParDCosCod;
            Z1821RHTipPlaCod = A1821RHTipPlaCod;
            Z83ParTip = A83ParTip;
            Z91CueCod = A91CueCod;
            Z84ParCod = A84ParCod;
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

      protected void Load1S183( )
      {
         /* Using cursor T001S6 */
         pr_default.execute(4, new Object[] {A83ParTip, A84ParCod, A90ParDTipItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound183 = 1;
            A1820RHConTipRem = T001S6_A1820RHConTipRem[0];
            AssignAttri("", false, "A1820RHConTipRem", A1820RHConTipRem);
            A1819RHConCod = T001S6_A1819RHConCod[0];
            AssignAttri("", false, "A1819RHConCod", A1819RHConCod);
            A1538ParDTipCosCod = T001S6_A1538ParDTipCosCod[0];
            AssignAttri("", false, "A1538ParDTipCosCod", StringUtil.Str( (decimal)(A1538ParDTipCosCod), 1, 0));
            A1537ParDTipConc = T001S6_A1537ParDTipConc[0];
            AssignAttri("", false, "A1537ParDTipConc", A1537ParDTipConc);
            A1539ParDTipFlag = T001S6_A1539ParDTipFlag[0];
            AssignAttri("", false, "A1539ParDTipFlag", StringUtil.Str( (decimal)(A1539ParDTipFlag), 1, 0));
            A1527ParDAFP = T001S6_A1527ParDAFP[0];
            AssignAttri("", false, "A1527ParDAFP", StringUtil.Str( (decimal)(A1527ParDAFP), 1, 0));
            A1528ParDCosCod = T001S6_A1528ParDCosCod[0];
            n1528ParDCosCod = T001S6_n1528ParDCosCod[0];
            AssignAttri("", false, "A1528ParDCosCod", A1528ParDCosCod);
            A1821RHTipPlaCod = T001S6_A1821RHTipPlaCod[0];
            A91CueCod = T001S6_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            ZM1S183( -2) ;
         }
         pr_default.close(4);
         OnLoadActions1S183( ) ;
      }

      protected void OnLoadActions1S183( )
      {
      }

      protected void CheckExtendedTable1S183( )
      {
         nIsDirty_183 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001S5 */
         pr_default.execute(3, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( ! ( ( StringUtil.StrCmp(A1820RHConTipRem, "I") == 0 ) || ( StringUtil.StrCmp(A1820RHConTipRem, "D") == 0 ) || ( StringUtil.StrCmp(A1820RHConTipRem, "A") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Tipo Remuneración (Remuneraciones,Descuento,Aportación) fuera de rango", "OutOfRange", 1, "RHCONTIPREM");
            AnyError = 1;
            GX_FocusControl = cmbRHConTipRem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T001S4 */
         pr_default.execute(2, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1S183( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_4( string A83ParTip ,
                               int A84ParCod )
      {
         /* Using cursor T001S7 */
         pr_default.execute(5, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_3( string A91CueCod )
      {
         /* Using cursor T001S8 */
         pr_default.execute(6, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
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

      protected void GetKey1S183( )
      {
         /* Using cursor T001S9 */
         pr_default.execute(7, new Object[] {A83ParTip, A84ParCod, A90ParDTipItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound183 = 1;
         }
         else
         {
            RcdFound183 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001S3 */
         pr_default.execute(1, new Object[] {A83ParTip, A84ParCod, A90ParDTipItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1S183( 2) ;
            RcdFound183 = 1;
            A90ParDTipItem = T001S3_A90ParDTipItem[0];
            AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
            A1820RHConTipRem = T001S3_A1820RHConTipRem[0];
            AssignAttri("", false, "A1820RHConTipRem", A1820RHConTipRem);
            A1819RHConCod = T001S3_A1819RHConCod[0];
            AssignAttri("", false, "A1819RHConCod", A1819RHConCod);
            A1538ParDTipCosCod = T001S3_A1538ParDTipCosCod[0];
            AssignAttri("", false, "A1538ParDTipCosCod", StringUtil.Str( (decimal)(A1538ParDTipCosCod), 1, 0));
            A1537ParDTipConc = T001S3_A1537ParDTipConc[0];
            AssignAttri("", false, "A1537ParDTipConc", A1537ParDTipConc);
            A1539ParDTipFlag = T001S3_A1539ParDTipFlag[0];
            AssignAttri("", false, "A1539ParDTipFlag", StringUtil.Str( (decimal)(A1539ParDTipFlag), 1, 0));
            A1527ParDAFP = T001S3_A1527ParDAFP[0];
            AssignAttri("", false, "A1527ParDAFP", StringUtil.Str( (decimal)(A1527ParDAFP), 1, 0));
            A1528ParDCosCod = T001S3_A1528ParDCosCod[0];
            n1528ParDCosCod = T001S3_n1528ParDCosCod[0];
            AssignAttri("", false, "A1528ParDCosCod", A1528ParDCosCod);
            A1821RHTipPlaCod = T001S3_A1821RHTipPlaCod[0];
            A83ParTip = T001S3_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A91CueCod = T001S3_A91CueCod[0];
            AssignAttri("", false, "A91CueCod", A91CueCod);
            A84ParCod = T001S3_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            Z83ParTip = A83ParTip;
            Z84ParCod = A84ParCod;
            Z90ParDTipItem = A90ParDTipItem;
            sMode183 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1S183( ) ;
            if ( AnyError == 1 )
            {
               RcdFound183 = 0;
               InitializeNonKey1S183( ) ;
            }
            Gx_mode = sMode183;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound183 = 0;
            InitializeNonKey1S183( ) ;
            sMode183 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode183;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1S183( ) ;
         if ( RcdFound183 == 0 )
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
         RcdFound183 = 0;
         /* Using cursor T001S10 */
         pr_default.execute(8, new Object[] {A83ParTip, A84ParCod, A90ParDTipItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001S10_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001S10_A83ParTip[0], A83ParTip) == 0 ) && ( T001S10_A84ParCod[0] < A84ParCod ) || ( T001S10_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001S10_A83ParTip[0], A83ParTip) == 0 ) && ( T001S10_A90ParDTipItem[0] < A90ParDTipItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001S10_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001S10_A83ParTip[0], A83ParTip) == 0 ) && ( T001S10_A84ParCod[0] > A84ParCod ) || ( T001S10_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001S10_A83ParTip[0], A83ParTip) == 0 ) && ( T001S10_A90ParDTipItem[0] > A90ParDTipItem ) ) )
            {
               A83ParTip = T001S10_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001S10_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A90ParDTipItem = T001S10_A90ParDTipItem[0];
               AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
               RcdFound183 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound183 = 0;
         /* Using cursor T001S11 */
         pr_default.execute(9, new Object[] {A83ParTip, A84ParCod, A90ParDTipItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001S11_A83ParTip[0], A83ParTip) > 0 ) || ( StringUtil.StrCmp(T001S11_A83ParTip[0], A83ParTip) == 0 ) && ( T001S11_A84ParCod[0] > A84ParCod ) || ( T001S11_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001S11_A83ParTip[0], A83ParTip) == 0 ) && ( T001S11_A90ParDTipItem[0] > A90ParDTipItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T001S11_A83ParTip[0], A83ParTip) < 0 ) || ( StringUtil.StrCmp(T001S11_A83ParTip[0], A83ParTip) == 0 ) && ( T001S11_A84ParCod[0] < A84ParCod ) || ( T001S11_A84ParCod[0] == A84ParCod ) && ( StringUtil.StrCmp(T001S11_A83ParTip[0], A83ParTip) == 0 ) && ( T001S11_A90ParDTipItem[0] < A90ParDTipItem ) ) )
            {
               A83ParTip = T001S11_A83ParTip[0];
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = T001S11_A84ParCod[0];
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A90ParDTipItem = T001S11_A90ParDTipItem[0];
               AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
               RcdFound183 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1S183( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1S183( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound183 == 1 )
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A90ParDTipItem != Z90ParDTipItem ) )
               {
                  A83ParTip = Z83ParTip;
                  AssignAttri("", false, "A83ParTip", A83ParTip);
                  A84ParCod = Z84ParCod;
                  AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
                  A90ParDTipItem = Z90ParDTipItem;
                  AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
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
                  Update1S183( ) ;
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A90ParDTipItem != Z90ParDTipItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtParTip_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1S183( ) ;
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
                     Insert1S183( ) ;
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
         if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A90ParDTipItem != Z90ParDTipItem ) )
         {
            A83ParTip = Z83ParTip;
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = Z84ParCod;
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A90ParDTipItem = Z90ParDTipItem;
            AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
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
         GetKey1S183( ) ;
         if ( RcdFound183 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PARTIP");
               AnyError = 1;
               GX_FocusControl = edtParTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A90ParDTipItem != Z90ParDTipItem ) )
            {
               A83ParTip = Z83ParTip;
               AssignAttri("", false, "A83ParTip", A83ParTip);
               A84ParCod = Z84ParCod;
               AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
               A90ParDTipItem = Z90ParDTipItem;
               AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
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
            if ( ( StringUtil.StrCmp(A83ParTip, Z83ParTip) != 0 ) || ( A84ParCod != Z84ParCod ) || ( A90ParDTipItem != Z90ParDTipItem ) )
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
         context.RollbackDataStores("cbparamconceptos",pr_default);
         GX_FocusControl = cmbRHConTipRem_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1S0( ) ;
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
         if ( RcdFound183 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PARTIP");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = cmbRHConTipRem_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1S183( ) ;
         if ( RcdFound183 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbRHConTipRem_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1S183( ) ;
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
         if ( RcdFound183 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbRHConTipRem_Internalname;
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
         if ( RcdFound183 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbRHConTipRem_Internalname;
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
         ScanStart1S183( ) ;
         if ( RcdFound183 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound183 != 0 )
            {
               ScanNext1S183( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = cmbRHConTipRem_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1S183( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1S183( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001S2 */
            pr_default.execute(0, new Object[] {A83ParTip, A84ParCod, A90ParDTipItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMCONCEPTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1820RHConTipRem, T001S2_A1820RHConTipRem[0]) != 0 ) || ( StringUtil.StrCmp(Z1819RHConCod, T001S2_A1819RHConCod[0]) != 0 ) || ( Z1538ParDTipCosCod != T001S2_A1538ParDTipCosCod[0] ) || ( StringUtil.StrCmp(Z1537ParDTipConc, T001S2_A1537ParDTipConc[0]) != 0 ) || ( Z1539ParDTipFlag != T001S2_A1539ParDTipFlag[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1527ParDAFP != T001S2_A1527ParDAFP[0] ) || ( StringUtil.StrCmp(Z1528ParDCosCod, T001S2_A1528ParDCosCod[0]) != 0 ) || ( Z1821RHTipPlaCod != T001S2_A1821RHTipPlaCod[0] ) || ( StringUtil.StrCmp(Z91CueCod, T001S2_A91CueCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1820RHConTipRem, T001S2_A1820RHConTipRem[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"RHConTipRem");
                  GXUtil.WriteLogRaw("Old: ",Z1820RHConTipRem);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1820RHConTipRem[0]);
               }
               if ( StringUtil.StrCmp(Z1819RHConCod, T001S2_A1819RHConCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"RHConCod");
                  GXUtil.WriteLogRaw("Old: ",Z1819RHConCod);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1819RHConCod[0]);
               }
               if ( Z1538ParDTipCosCod != T001S2_A1538ParDTipCosCod[0] )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"ParDTipCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z1538ParDTipCosCod);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1538ParDTipCosCod[0]);
               }
               if ( StringUtil.StrCmp(Z1537ParDTipConc, T001S2_A1537ParDTipConc[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"ParDTipConc");
                  GXUtil.WriteLogRaw("Old: ",Z1537ParDTipConc);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1537ParDTipConc[0]);
               }
               if ( Z1539ParDTipFlag != T001S2_A1539ParDTipFlag[0] )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"ParDTipFlag");
                  GXUtil.WriteLogRaw("Old: ",Z1539ParDTipFlag);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1539ParDTipFlag[0]);
               }
               if ( Z1527ParDAFP != T001S2_A1527ParDAFP[0] )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"ParDAFP");
                  GXUtil.WriteLogRaw("Old: ",Z1527ParDAFP);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1527ParDAFP[0]);
               }
               if ( StringUtil.StrCmp(Z1528ParDCosCod, T001S2_A1528ParDCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"ParDCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z1528ParDCosCod);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1528ParDCosCod[0]);
               }
               if ( Z1821RHTipPlaCod != T001S2_A1821RHTipPlaCod[0] )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"RHTipPlaCod");
                  GXUtil.WriteLogRaw("Old: ",Z1821RHTipPlaCod);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A1821RHTipPlaCod[0]);
               }
               if ( StringUtil.StrCmp(Z91CueCod, T001S2_A91CueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cbparamconceptos:[seudo value changed for attri]"+"CueCod");
                  GXUtil.WriteLogRaw("Old: ",Z91CueCod);
                  GXUtil.WriteLogRaw("Current: ",T001S2_A91CueCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CBPARAMCONCEPTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1S183( )
      {
         BeforeValidate1S183( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S183( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1S183( 0) ;
            CheckOptimisticConcurrency1S183( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S183( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1S183( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001S12 */
                     pr_default.execute(10, new Object[] {A90ParDTipItem, A1820RHConTipRem, A1819RHConCod, A1538ParDTipCosCod, A1537ParDTipConc, A1539ParDTipFlag, A1527ParDAFP, n1528ParDCosCod, A1528ParDCosCod, A1821RHTipPlaCod, A83ParTip, A91CueCod, A84ParCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMCONCEPTOS");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ResetCaption1S0( ) ;
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
               Load1S183( ) ;
            }
            EndLevel1S183( ) ;
         }
         CloseExtendedTableCursors1S183( ) ;
      }

      protected void Update1S183( )
      {
         BeforeValidate1S183( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1S183( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S183( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1S183( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1S183( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001S13 */
                     pr_default.execute(11, new Object[] {A1820RHConTipRem, A1819RHConCod, A1538ParDTipCosCod, A1537ParDTipConc, A1539ParDTipFlag, A1527ParDAFP, n1528ParDCosCod, A1528ParDCosCod, A1821RHTipPlaCod, A91CueCod, A83ParTip, A84ParCod, A90ParDTipItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CBPARAMCONCEPTOS");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CBPARAMCONCEPTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1S183( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1S0( ) ;
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
            EndLevel1S183( ) ;
         }
         CloseExtendedTableCursors1S183( ) ;
      }

      protected void DeferredUpdate1S183( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1S183( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1S183( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1S183( ) ;
            AfterConfirm1S183( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1S183( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001S14 */
                  pr_default.execute(12, new Object[] {A83ParTip, A84ParCod, A90ParDTipItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CBPARAMCONCEPTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound183 == 0 )
                        {
                           InitAll1S183( ) ;
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
                        ResetCaption1S0( ) ;
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
         sMode183 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1S183( ) ;
         Gx_mode = sMode183;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1S183( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1S183( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1S183( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cbparamconceptos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cbparamconceptos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1S183( )
      {
         /* Using cursor T001S15 */
         pr_default.execute(13);
         RcdFound183 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound183 = 1;
            A83ParTip = T001S15_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001S15_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A90ParDTipItem = T001S15_A90ParDTipItem[0];
            AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1S183( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound183 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound183 = 1;
            A83ParTip = T001S15_A83ParTip[0];
            AssignAttri("", false, "A83ParTip", A83ParTip);
            A84ParCod = T001S15_A84ParCod[0];
            AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
            A90ParDTipItem = T001S15_A90ParDTipItem[0];
            AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
         }
      }

      protected void ScanEnd1S183( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1S183( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1S183( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1S183( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1S183( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1S183( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1S183( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1S183( )
      {
         edtParTip_Enabled = 0;
         AssignProp("", false, edtParTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParTip_Enabled), 5, 0), true);
         edtParCod_Enabled = 0;
         AssignProp("", false, edtParCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParCod_Enabled), 5, 0), true);
         edtParDTipItem_Enabled = 0;
         AssignProp("", false, edtParDTipItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTipItem_Enabled), 5, 0), true);
         cmbRHConTipRem.Enabled = 0;
         AssignProp("", false, cmbRHConTipRem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbRHConTipRem.Enabled), 5, 0), true);
         edtRHConCod_Enabled = 0;
         AssignProp("", false, edtRHConCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtRHConCod_Enabled), 5, 0), true);
         edtParDTipCosCod_Enabled = 0;
         AssignProp("", false, edtParDTipCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTipCosCod_Enabled), 5, 0), true);
         edtCueCod_Enabled = 0;
         AssignProp("", false, edtCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCueCod_Enabled), 5, 0), true);
         edtParDTipConc_Enabled = 0;
         AssignProp("", false, edtParDTipConc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTipConc_Enabled), 5, 0), true);
         edtParDTipFlag_Enabled = 0;
         AssignProp("", false, edtParDTipFlag_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDTipFlag_Enabled), 5, 0), true);
         edtParDAFP_Enabled = 0;
         AssignProp("", false, edtParDAFP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDAFP_Enabled), 5, 0), true);
         edtParDCosCod_Enabled = 0;
         AssignProp("", false, edtParDCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParDCosCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1S183( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1S0( )
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
         context.AddJavascriptSource("gxcfg.js", "?2022818102472", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cbparamconceptos.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CBPARAMCONCEPTOS");
         forbiddenHiddens.Add("RHTipPlaCod", context.localUtil.Format( (decimal)(A1821RHTipPlaCod), "ZZZZZ9"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cbparamconceptos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z83ParTip", StringUtil.RTrim( Z83ParTip));
         GxWebStd.gx_hidden_field( context, "Z84ParCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84ParCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z90ParDTipItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z90ParDTipItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1820RHConTipRem", StringUtil.RTrim( Z1820RHConTipRem));
         GxWebStd.gx_hidden_field( context, "Z1819RHConCod", StringUtil.RTrim( Z1819RHConCod));
         GxWebStd.gx_hidden_field( context, "Z1538ParDTipCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1538ParDTipCosCod), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1537ParDTipConc", StringUtil.RTrim( Z1537ParDTipConc));
         GxWebStd.gx_hidden_field( context, "Z1539ParDTipFlag", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1539ParDTipFlag), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1527ParDAFP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1527ParDAFP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1528ParDCosCod", StringUtil.RTrim( Z1528ParDCosCod));
         GxWebStd.gx_hidden_field( context, "Z1821RHTipPlaCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1821RHTipPlaCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "RHTIPPLACOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1821RHTipPlaCod), 6, 0, ".", "")));
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
         return formatLink("cbparamconceptos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CBPARAMCONCEPTOS" ;
      }

      public override string GetPgmdesc( )
      {
         return "CBPARAMCONCEPTOS" ;
      }

      protected void InitializeNonKey1S183( )
      {
         A1820RHConTipRem = "";
         AssignAttri("", false, "A1820RHConTipRem", A1820RHConTipRem);
         A1819RHConCod = "";
         AssignAttri("", false, "A1819RHConCod", A1819RHConCod);
         A1538ParDTipCosCod = 0;
         AssignAttri("", false, "A1538ParDTipCosCod", StringUtil.Str( (decimal)(A1538ParDTipCosCod), 1, 0));
         A91CueCod = "";
         AssignAttri("", false, "A91CueCod", A91CueCod);
         A1537ParDTipConc = "";
         AssignAttri("", false, "A1537ParDTipConc", A1537ParDTipConc);
         A1539ParDTipFlag = 0;
         AssignAttri("", false, "A1539ParDTipFlag", StringUtil.Str( (decimal)(A1539ParDTipFlag), 1, 0));
         A1527ParDAFP = 0;
         AssignAttri("", false, "A1527ParDAFP", StringUtil.Str( (decimal)(A1527ParDAFP), 1, 0));
         A1528ParDCosCod = "";
         n1528ParDCosCod = false;
         AssignAttri("", false, "A1528ParDCosCod", A1528ParDCosCod);
         n1528ParDCosCod = (String.IsNullOrEmpty(StringUtil.RTrim( A1528ParDCosCod)) ? true : false);
         A1821RHTipPlaCod = 0;
         AssignAttri("", false, "A1821RHTipPlaCod", StringUtil.LTrimStr( (decimal)(A1821RHTipPlaCod), 6, 0));
         Z1820RHConTipRem = "";
         Z1819RHConCod = "";
         Z1538ParDTipCosCod = 0;
         Z1537ParDTipConc = "";
         Z1539ParDTipFlag = 0;
         Z1527ParDAFP = 0;
         Z1528ParDCosCod = "";
         Z1821RHTipPlaCod = 0;
         Z91CueCod = "";
      }

      protected void InitAll1S183( )
      {
         A83ParTip = "";
         AssignAttri("", false, "A83ParTip", A83ParTip);
         A84ParCod = 0;
         AssignAttri("", false, "A84ParCod", StringUtil.LTrimStr( (decimal)(A84ParCod), 6, 0));
         A90ParDTipItem = 0;
         AssignAttri("", false, "A90ParDTipItem", StringUtil.LTrimStr( (decimal)(A90ParDTipItem), 6, 0));
         InitializeNonKey1S183( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024712", true, true);
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
         context.AddJavascriptSource("cbparamconceptos.js", "?20228181024713", false, true);
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
         edtParDTipItem_Internalname = "PARDTIPITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         cmbRHConTipRem_Internalname = "RHCONTIPREM";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtRHConCod_Internalname = "RHCONCOD";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtParDTipCosCod_Internalname = "PARDTIPCOSCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCueCod_Internalname = "CUECOD";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtParDTipConc_Internalname = "PARDTIPCONC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtParDTipFlag_Internalname = "PARDTIPFLAG";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtParDAFP_Internalname = "PARDAFP";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtParDCosCod_Internalname = "PARDCOSCOD";
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
         Form.Caption = "CBPARAMCONCEPTOS";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtParDCosCod_Jsonclick = "";
         edtParDCosCod_Enabled = 1;
         edtParDAFP_Jsonclick = "";
         edtParDAFP_Enabled = 1;
         edtParDTipFlag_Jsonclick = "";
         edtParDTipFlag_Enabled = 1;
         edtParDTipConc_Jsonclick = "";
         edtParDTipConc_Enabled = 1;
         edtCueCod_Jsonclick = "";
         edtCueCod_Enabled = 1;
         edtParDTipCosCod_Jsonclick = "";
         edtParDTipCosCod_Enabled = 1;
         edtRHConCod_Jsonclick = "";
         edtRHConCod_Enabled = 1;
         cmbRHConTipRem_Jsonclick = "";
         cmbRHConTipRem.Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtParDTipItem_Jsonclick = "";
         edtParDTipItem_Enabled = 1;
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
         cmbRHConTipRem.Name = "RHCONTIPREM";
         cmbRHConTipRem.WebTags = "";
         cmbRHConTipRem.addItem("I", "Remuneraciones", 0);
         cmbRHConTipRem.addItem("D", "Descuentos", 0);
         cmbRHConTipRem.addItem("A", "Aportaciones", 0);
         if ( cmbRHConTipRem.ItemCount > 0 )
         {
            A1820RHConTipRem = cmbRHConTipRem.getValidValue(A1820RHConTipRem);
            AssignAttri("", false, "A1820RHConTipRem", A1820RHConTipRem);
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         /* Using cursor T001S16 */
         pr_default.execute(14, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         GX_FocusControl = cmbRHConTipRem_Internalname;
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
         /* Using cursor T001S16 */
         pr_default.execute(14, new Object[] {A83ParTip, A84ParCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Detalle'.", "ForeignKeyNotFound", 1, "PARCOD");
            AnyError = 1;
            GX_FocusControl = edtParTip_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Pardtipitem( )
      {
         A1820RHConTipRem = cmbRHConTipRem.CurrentValue;
         cmbRHConTipRem.CurrentValue = A1820RHConTipRem;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbRHConTipRem.ItemCount > 0 )
         {
            A1820RHConTipRem = cmbRHConTipRem.getValidValue(A1820RHConTipRem);
            cmbRHConTipRem.CurrentValue = A1820RHConTipRem;
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbRHConTipRem.CurrentValue = StringUtil.RTrim( A1820RHConTipRem);
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1820RHConTipRem", StringUtil.RTrim( A1820RHConTipRem));
         cmbRHConTipRem.CurrentValue = StringUtil.RTrim( A1820RHConTipRem);
         AssignProp("", false, cmbRHConTipRem_Internalname, "Values", cmbRHConTipRem.ToJavascriptSource(), true);
         AssignAttri("", false, "A1819RHConCod", StringUtil.RTrim( A1819RHConCod));
         AssignAttri("", false, "A1538ParDTipCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1538ParDTipCosCod), 1, 0, ".", "")));
         AssignAttri("", false, "A91CueCod", StringUtil.RTrim( A91CueCod));
         AssignAttri("", false, "A1537ParDTipConc", StringUtil.RTrim( A1537ParDTipConc));
         AssignAttri("", false, "A1539ParDTipFlag", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1539ParDTipFlag), 1, 0, ".", "")));
         AssignAttri("", false, "A1527ParDAFP", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1527ParDAFP), 1, 0, ".", "")));
         AssignAttri("", false, "A1528ParDCosCod", StringUtil.RTrim( A1528ParDCosCod));
         AssignAttri("", false, "A1821RHTipPlaCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1821RHTipPlaCod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z83ParTip", StringUtil.RTrim( Z83ParTip));
         GxWebStd.gx_hidden_field( context, "Z84ParCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z84ParCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z90ParDTipItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z90ParDTipItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1820RHConTipRem", StringUtil.RTrim( Z1820RHConTipRem));
         GxWebStd.gx_hidden_field( context, "Z1819RHConCod", StringUtil.RTrim( Z1819RHConCod));
         GxWebStd.gx_hidden_field( context, "Z1538ParDTipCosCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1538ParDTipCosCod), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z91CueCod", StringUtil.RTrim( Z91CueCod));
         GxWebStd.gx_hidden_field( context, "Z1537ParDTipConc", StringUtil.RTrim( Z1537ParDTipConc));
         GxWebStd.gx_hidden_field( context, "Z1539ParDTipFlag", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1539ParDTipFlag), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1527ParDAFP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1527ParDAFP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1528ParDCosCod", StringUtil.RTrim( Z1528ParDCosCod));
         GxWebStd.gx_hidden_field( context, "Z1821RHTipPlaCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1821RHTipPlaCod), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Cuecod( )
      {
         /* Using cursor T001S17 */
         pr_default.execute(15, new Object[] {A91CueCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Plan de Cuentas'.", "ForeignKeyNotFound", 1, "CUECOD");
            AnyError = 1;
            GX_FocusControl = edtCueCod_Internalname;
         }
         pr_default.close(15);
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1821RHTipPlaCod',fld:'RHTIPPLACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PARTIP","{handler:'Valid_Partip',iparms:[]");
         setEventMetadata("VALID_PARTIP",",oparms:[]}");
         setEventMetadata("VALID_PARCOD","{handler:'Valid_Parcod',iparms:[{av:'A83ParTip',fld:'PARTIP',pic:''},{av:'A84ParCod',fld:'PARCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_PARCOD",",oparms:[]}");
         setEventMetadata("VALID_PARDTIPITEM","{handler:'Valid_Pardtipitem',iparms:[{av:'A1821RHTipPlaCod',fld:'RHTIPPLACOD',pic:'ZZZZZ9'},{av:'cmbRHConTipRem'},{av:'A1820RHConTipRem',fld:'RHCONTIPREM',pic:''},{av:'A83ParTip',fld:'PARTIP',pic:''},{av:'A84ParCod',fld:'PARCOD',pic:'ZZZZZ9'},{av:'A90ParDTipItem',fld:'PARDTIPITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PARDTIPITEM",",oparms:[{av:'cmbRHConTipRem'},{av:'A1820RHConTipRem',fld:'RHCONTIPREM',pic:''},{av:'A1819RHConCod',fld:'RHCONCOD',pic:''},{av:'A1538ParDTipCosCod',fld:'PARDTIPCOSCOD',pic:'9'},{av:'A91CueCod',fld:'CUECOD',pic:''},{av:'A1537ParDTipConc',fld:'PARDTIPCONC',pic:''},{av:'A1539ParDTipFlag',fld:'PARDTIPFLAG',pic:'9'},{av:'A1527ParDAFP',fld:'PARDAFP',pic:'9'},{av:'A1528ParDCosCod',fld:'PARDCOSCOD',pic:''},{av:'A1821RHTipPlaCod',fld:'RHTIPPLACOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z83ParTip'},{av:'Z84ParCod'},{av:'Z90ParDTipItem'},{av:'Z1820RHConTipRem'},{av:'Z1819RHConCod'},{av:'Z1538ParDTipCosCod'},{av:'Z91CueCod'},{av:'Z1537ParDTipConc'},{av:'Z1539ParDTipFlag'},{av:'Z1527ParDAFP'},{av:'Z1528ParDCosCod'},{av:'Z1821RHTipPlaCod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_RHCONTIPREM","{handler:'Valid_Rhcontiprem',iparms:[]");
         setEventMetadata("VALID_RHCONTIPREM",",oparms:[]}");
         setEventMetadata("VALID_CUECOD","{handler:'Valid_Cuecod',iparms:[{av:'A91CueCod',fld:'CUECOD',pic:''}]");
         setEventMetadata("VALID_CUECOD",",oparms:[]}");
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
         pr_default.close(15);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z83ParTip = "";
         Z1820RHConTipRem = "";
         Z1819RHConCod = "";
         Z1537ParDTipConc = "";
         Z1528ParDCosCod = "";
         Z91CueCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A83ParTip = "";
         A91CueCod = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A1820RHConTipRem = "";
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
         A1819RHConCod = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         lblTextblock8_Jsonclick = "";
         A1537ParDTipConc = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         A1528ParDCosCod = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         Gx_mode = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T001S6_A90ParDTipItem = new int[1] ;
         T001S6_A1820RHConTipRem = new string[] {""} ;
         T001S6_A1819RHConCod = new string[] {""} ;
         T001S6_A1538ParDTipCosCod = new short[1] ;
         T001S6_A1537ParDTipConc = new string[] {""} ;
         T001S6_A1539ParDTipFlag = new short[1] ;
         T001S6_A1527ParDAFP = new short[1] ;
         T001S6_A1528ParDCosCod = new string[] {""} ;
         T001S6_n1528ParDCosCod = new bool[] {false} ;
         T001S6_A1821RHTipPlaCod = new int[1] ;
         T001S6_A83ParTip = new string[] {""} ;
         T001S6_A91CueCod = new string[] {""} ;
         T001S6_A84ParCod = new int[1] ;
         T001S5_A83ParTip = new string[] {""} ;
         T001S4_A91CueCod = new string[] {""} ;
         T001S7_A83ParTip = new string[] {""} ;
         T001S8_A91CueCod = new string[] {""} ;
         T001S9_A83ParTip = new string[] {""} ;
         T001S9_A84ParCod = new int[1] ;
         T001S9_A90ParDTipItem = new int[1] ;
         T001S3_A90ParDTipItem = new int[1] ;
         T001S3_A1820RHConTipRem = new string[] {""} ;
         T001S3_A1819RHConCod = new string[] {""} ;
         T001S3_A1538ParDTipCosCod = new short[1] ;
         T001S3_A1537ParDTipConc = new string[] {""} ;
         T001S3_A1539ParDTipFlag = new short[1] ;
         T001S3_A1527ParDAFP = new short[1] ;
         T001S3_A1528ParDCosCod = new string[] {""} ;
         T001S3_n1528ParDCosCod = new bool[] {false} ;
         T001S3_A1821RHTipPlaCod = new int[1] ;
         T001S3_A83ParTip = new string[] {""} ;
         T001S3_A91CueCod = new string[] {""} ;
         T001S3_A84ParCod = new int[1] ;
         sMode183 = "";
         T001S10_A83ParTip = new string[] {""} ;
         T001S10_A84ParCod = new int[1] ;
         T001S10_A90ParDTipItem = new int[1] ;
         T001S11_A83ParTip = new string[] {""} ;
         T001S11_A84ParCod = new int[1] ;
         T001S11_A90ParDTipItem = new int[1] ;
         T001S2_A90ParDTipItem = new int[1] ;
         T001S2_A1820RHConTipRem = new string[] {""} ;
         T001S2_A1819RHConCod = new string[] {""} ;
         T001S2_A1538ParDTipCosCod = new short[1] ;
         T001S2_A1537ParDTipConc = new string[] {""} ;
         T001S2_A1539ParDTipFlag = new short[1] ;
         T001S2_A1527ParDAFP = new short[1] ;
         T001S2_A1528ParDCosCod = new string[] {""} ;
         T001S2_n1528ParDCosCod = new bool[] {false} ;
         T001S2_A1821RHTipPlaCod = new int[1] ;
         T001S2_A83ParTip = new string[] {""} ;
         T001S2_A91CueCod = new string[] {""} ;
         T001S2_A84ParCod = new int[1] ;
         T001S15_A83ParTip = new string[] {""} ;
         T001S15_A84ParCod = new int[1] ;
         T001S15_A90ParDTipItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001S16_A83ParTip = new string[] {""} ;
         ZZ83ParTip = "";
         ZZ1820RHConTipRem = "";
         ZZ1819RHConCod = "";
         ZZ91CueCod = "";
         ZZ1537ParDTipConc = "";
         ZZ1528ParDCosCod = "";
         T001S17_A91CueCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cbparamconceptos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cbparamconceptos__default(),
            new Object[][] {
                new Object[] {
               T001S2_A90ParDTipItem, T001S2_A1820RHConTipRem, T001S2_A1819RHConCod, T001S2_A1538ParDTipCosCod, T001S2_A1537ParDTipConc, T001S2_A1539ParDTipFlag, T001S2_A1527ParDAFP, T001S2_A1528ParDCosCod, T001S2_n1528ParDCosCod, T001S2_A1821RHTipPlaCod,
               T001S2_A83ParTip, T001S2_A91CueCod, T001S2_A84ParCod
               }
               , new Object[] {
               T001S3_A90ParDTipItem, T001S3_A1820RHConTipRem, T001S3_A1819RHConCod, T001S3_A1538ParDTipCosCod, T001S3_A1537ParDTipConc, T001S3_A1539ParDTipFlag, T001S3_A1527ParDAFP, T001S3_A1528ParDCosCod, T001S3_n1528ParDCosCod, T001S3_A1821RHTipPlaCod,
               T001S3_A83ParTip, T001S3_A91CueCod, T001S3_A84ParCod
               }
               , new Object[] {
               T001S4_A91CueCod
               }
               , new Object[] {
               T001S5_A83ParTip
               }
               , new Object[] {
               T001S6_A90ParDTipItem, T001S6_A1820RHConTipRem, T001S6_A1819RHConCod, T001S6_A1538ParDTipCosCod, T001S6_A1537ParDTipConc, T001S6_A1539ParDTipFlag, T001S6_A1527ParDAFP, T001S6_A1528ParDCosCod, T001S6_n1528ParDCosCod, T001S6_A1821RHTipPlaCod,
               T001S6_A83ParTip, T001S6_A91CueCod, T001S6_A84ParCod
               }
               , new Object[] {
               T001S7_A83ParTip
               }
               , new Object[] {
               T001S8_A91CueCod
               }
               , new Object[] {
               T001S9_A83ParTip, T001S9_A84ParCod, T001S9_A90ParDTipItem
               }
               , new Object[] {
               T001S10_A83ParTip, T001S10_A84ParCod, T001S10_A90ParDTipItem
               }
               , new Object[] {
               T001S11_A83ParTip, T001S11_A84ParCod, T001S11_A90ParDTipItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001S15_A83ParTip, T001S15_A84ParCod, T001S15_A90ParDTipItem
               }
               , new Object[] {
               T001S16_A83ParTip
               }
               , new Object[] {
               T001S17_A91CueCod
               }
            }
         );
      }

      private short Z1538ParDTipCosCod ;
      private short Z1539ParDTipFlag ;
      private short Z1527ParDAFP ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1538ParDTipCosCod ;
      private short A1539ParDTipFlag ;
      private short A1527ParDAFP ;
      private short GX_JID ;
      private short RcdFound183 ;
      private short nIsDirty_183 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1538ParDTipCosCod ;
      private short ZZ1539ParDTipFlag ;
      private short ZZ1527ParDAFP ;
      private int Z84ParCod ;
      private int Z90ParDTipItem ;
      private int Z1821RHTipPlaCod ;
      private int A84ParCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtParTip_Enabled ;
      private int edtParCod_Enabled ;
      private int A90ParDTipItem ;
      private int edtParDTipItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtRHConCod_Enabled ;
      private int edtParDTipCosCod_Enabled ;
      private int edtCueCod_Enabled ;
      private int edtParDTipConc_Enabled ;
      private int edtParDTipFlag_Enabled ;
      private int edtParDAFP_Enabled ;
      private int edtParDCosCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A1821RHTipPlaCod ;
      private int idxLst ;
      private int ZZ84ParCod ;
      private int ZZ90ParDTipItem ;
      private int ZZ1821RHTipPlaCod ;
      private string sPrefix ;
      private string Z83ParTip ;
      private string Z1820RHConTipRem ;
      private string Z1819RHConCod ;
      private string Z1537ParDTipConc ;
      private string Z1528ParDCosCod ;
      private string Z91CueCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A83ParTip ;
      private string A91CueCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtParTip_Internalname ;
      private string A1820RHConTipRem ;
      private string cmbRHConTipRem_Internalname ;
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
      private string edtParDTipItem_Internalname ;
      private string edtParDTipItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string cmbRHConTipRem_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtRHConCod_Internalname ;
      private string A1819RHConCod ;
      private string edtRHConCod_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtParDTipCosCod_Internalname ;
      private string edtParDTipCosCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCueCod_Internalname ;
      private string edtCueCod_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtParDTipConc_Internalname ;
      private string A1537ParDTipConc ;
      private string edtParDTipConc_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtParDTipFlag_Internalname ;
      private string edtParDTipFlag_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtParDAFP_Internalname ;
      private string edtParDAFP_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtParDCosCod_Internalname ;
      private string A1528ParDCosCod ;
      private string edtParDCosCod_Jsonclick ;
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
      private string sMode183 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ83ParTip ;
      private string ZZ1820RHConTipRem ;
      private string ZZ1819RHConCod ;
      private string ZZ91CueCod ;
      private string ZZ1537ParDTipConc ;
      private string ZZ1528ParDCosCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n1528ParDCosCod ;
      private bool Gx_longc ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbRHConTipRem ;
      private IDataStoreProvider pr_default ;
      private int[] T001S6_A90ParDTipItem ;
      private string[] T001S6_A1820RHConTipRem ;
      private string[] T001S6_A1819RHConCod ;
      private short[] T001S6_A1538ParDTipCosCod ;
      private string[] T001S6_A1537ParDTipConc ;
      private short[] T001S6_A1539ParDTipFlag ;
      private short[] T001S6_A1527ParDAFP ;
      private string[] T001S6_A1528ParDCosCod ;
      private bool[] T001S6_n1528ParDCosCod ;
      private int[] T001S6_A1821RHTipPlaCod ;
      private string[] T001S6_A83ParTip ;
      private string[] T001S6_A91CueCod ;
      private int[] T001S6_A84ParCod ;
      private string[] T001S5_A83ParTip ;
      private string[] T001S4_A91CueCod ;
      private string[] T001S7_A83ParTip ;
      private string[] T001S8_A91CueCod ;
      private string[] T001S9_A83ParTip ;
      private int[] T001S9_A84ParCod ;
      private int[] T001S9_A90ParDTipItem ;
      private int[] T001S3_A90ParDTipItem ;
      private string[] T001S3_A1820RHConTipRem ;
      private string[] T001S3_A1819RHConCod ;
      private short[] T001S3_A1538ParDTipCosCod ;
      private string[] T001S3_A1537ParDTipConc ;
      private short[] T001S3_A1539ParDTipFlag ;
      private short[] T001S3_A1527ParDAFP ;
      private string[] T001S3_A1528ParDCosCod ;
      private bool[] T001S3_n1528ParDCosCod ;
      private int[] T001S3_A1821RHTipPlaCod ;
      private string[] T001S3_A83ParTip ;
      private string[] T001S3_A91CueCod ;
      private int[] T001S3_A84ParCod ;
      private string[] T001S10_A83ParTip ;
      private int[] T001S10_A84ParCod ;
      private int[] T001S10_A90ParDTipItem ;
      private string[] T001S11_A83ParTip ;
      private int[] T001S11_A84ParCod ;
      private int[] T001S11_A90ParDTipItem ;
      private int[] T001S2_A90ParDTipItem ;
      private string[] T001S2_A1820RHConTipRem ;
      private string[] T001S2_A1819RHConCod ;
      private short[] T001S2_A1538ParDTipCosCod ;
      private string[] T001S2_A1537ParDTipConc ;
      private short[] T001S2_A1539ParDTipFlag ;
      private short[] T001S2_A1527ParDAFP ;
      private string[] T001S2_A1528ParDCosCod ;
      private bool[] T001S2_n1528ParDCosCod ;
      private int[] T001S2_A1821RHTipPlaCod ;
      private string[] T001S2_A83ParTip ;
      private string[] T001S2_A91CueCod ;
      private int[] T001S2_A84ParCod ;
      private string[] T001S15_A83ParTip ;
      private int[] T001S15_A84ParCod ;
      private int[] T001S15_A90ParDTipItem ;
      private string[] T001S16_A83ParTip ;
      private string[] T001S17_A91CueCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cbparamconceptos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cbparamconceptos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001S6;
        prmT001S6 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S5;
        prmT001S5 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001S4;
        prmT001S4 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001S7;
        prmT001S7 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001S8;
        prmT001S8 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        Object[] prmT001S9;
        prmT001S9 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S3;
        prmT001S3 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S10;
        prmT001S10 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S11;
        prmT001S11 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S2;
        prmT001S2 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S12;
        prmT001S12 = new Object[] {
        new ParDef("@ParDTipItem",GXType.Int32,6,0) ,
        new ParDef("@RHConTipRem",GXType.NChar,1,0) ,
        new ParDef("@RHConCod",GXType.NChar,5,0) ,
        new ParDef("@ParDTipCosCod",GXType.Int16,1,0) ,
        new ParDef("@ParDTipConc",GXType.NChar,1,0) ,
        new ParDef("@ParDTipFlag",GXType.Int16,1,0) ,
        new ParDef("@ParDAFP",GXType.Int16,1,0) ,
        new ParDef("@ParDCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@RHTipPlaCod",GXType.Int32,6,0) ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001S13;
        prmT001S13 = new Object[] {
        new ParDef("@RHConTipRem",GXType.NChar,1,0) ,
        new ParDef("@RHConCod",GXType.NChar,5,0) ,
        new ParDef("@ParDTipCosCod",GXType.Int16,1,0) ,
        new ParDef("@ParDTipConc",GXType.NChar,1,0) ,
        new ParDef("@ParDTipFlag",GXType.Int16,1,0) ,
        new ParDef("@ParDAFP",GXType.Int16,1,0) ,
        new ParDef("@ParDCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@RHTipPlaCod",GXType.Int32,6,0) ,
        new ParDef("@CueCod",GXType.NChar,15,0) ,
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S14;
        prmT001S14 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0) ,
        new ParDef("@ParDTipItem",GXType.Int32,6,0)
        };
        Object[] prmT001S15;
        prmT001S15 = new Object[] {
        };
        Object[] prmT001S16;
        prmT001S16 = new Object[] {
        new ParDef("@ParTip",GXType.NChar,3,0) ,
        new ParDef("@ParCod",GXType.Int32,6,0)
        };
        Object[] prmT001S17;
        prmT001S17 = new Object[] {
        new ParDef("@CueCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001S2", "SELECT [ParDTipItem], [RHConTipRem], [RHConCod], [ParDTipCosCod], [ParDTipConc], [ParDTipFlag], [ParDAFP], [ParDCosCod], [RHTipPlaCod], [ParTip], [CueCod], [ParCod] FROM [CBPARAMCONCEPTOS] WITH (UPDLOCK) WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDTipItem] = @ParDTipItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S3", "SELECT [ParDTipItem], [RHConTipRem], [RHConCod], [ParDTipCosCod], [ParDTipConc], [ParDTipFlag], [ParDAFP], [ParDCosCod], [RHTipPlaCod], [ParTip], [CueCod], [ParCod] FROM [CBPARAMCONCEPTOS] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDTipItem] = @ParDTipItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S4", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S5", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S6", "SELECT TM1.[ParDTipItem], TM1.[RHConTipRem], TM1.[RHConCod], TM1.[ParDTipCosCod], TM1.[ParDTipConc], TM1.[ParDTipFlag], TM1.[ParDAFP], TM1.[ParDCosCod], TM1.[RHTipPlaCod], TM1.[ParTip], TM1.[CueCod], TM1.[ParCod] FROM [CBPARAMCONCEPTOS] TM1 WHERE TM1.[ParTip] = @ParTip and TM1.[ParCod] = @ParCod and TM1.[ParDTipItem] = @ParDTipItem ORDER BY TM1.[ParTip], TM1.[ParCod], TM1.[ParDTipItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S7", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S8", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S9", "SELECT [ParTip], [ParCod], [ParDTipItem] FROM [CBPARAMCONCEPTOS] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDTipItem] = @ParDTipItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S10", "SELECT TOP 1 [ParTip], [ParCod], [ParDTipItem] FROM [CBPARAMCONCEPTOS] WHERE ( [ParTip] > @ParTip or [ParTip] = @ParTip and [ParCod] > @ParCod or [ParCod] = @ParCod and [ParTip] = @ParTip and [ParDTipItem] > @ParDTipItem) ORDER BY [ParTip], [ParCod], [ParDTipItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001S11", "SELECT TOP 1 [ParTip], [ParCod], [ParDTipItem] FROM [CBPARAMCONCEPTOS] WHERE ( [ParTip] < @ParTip or [ParTip] = @ParTip and [ParCod] < @ParCod or [ParCod] = @ParCod and [ParTip] = @ParTip and [ParDTipItem] < @ParDTipItem) ORDER BY [ParTip] DESC, [ParCod] DESC, [ParDTipItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001S12", "INSERT INTO [CBPARAMCONCEPTOS]([ParDTipItem], [RHConTipRem], [RHConCod], [ParDTipCosCod], [ParDTipConc], [ParDTipFlag], [ParDAFP], [ParDCosCod], [RHTipPlaCod], [ParTip], [CueCod], [ParCod]) VALUES(@ParDTipItem, @RHConTipRem, @RHConCod, @ParDTipCosCod, @ParDTipConc, @ParDTipFlag, @ParDAFP, @ParDCosCod, @RHTipPlaCod, @ParTip, @CueCod, @ParCod)", GxErrorMask.GX_NOMASK,prmT001S12)
           ,new CursorDef("T001S13", "UPDATE [CBPARAMCONCEPTOS] SET [RHConTipRem]=@RHConTipRem, [RHConCod]=@RHConCod, [ParDTipCosCod]=@ParDTipCosCod, [ParDTipConc]=@ParDTipConc, [ParDTipFlag]=@ParDTipFlag, [ParDAFP]=@ParDAFP, [ParDCosCod]=@ParDCosCod, [RHTipPlaCod]=@RHTipPlaCod, [CueCod]=@CueCod  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDTipItem] = @ParDTipItem", GxErrorMask.GX_NOMASK,prmT001S13)
           ,new CursorDef("T001S14", "DELETE FROM [CBPARAMCONCEPTOS]  WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod AND [ParDTipItem] = @ParDTipItem", GxErrorMask.GX_NOMASK,prmT001S14)
           ,new CursorDef("T001S15", "SELECT [ParTip], [ParCod], [ParDTipItem] FROM [CBPARAMCONCEPTOS] ORDER BY [ParTip], [ParCod], [ParDTipItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001S15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S16", "SELECT [ParTip] FROM [CBPARAMDET] WHERE [ParTip] = @ParTip AND [ParCod] = @ParCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001S17", "SELECT [CueCod] FROM [CBPLANCUENTA] WHERE [CueCod] = @CueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001S17,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((int[]) buf[9])[0] = rslt.getInt(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 3);
              ((string[]) buf[11])[0] = rslt.getString(11, 15);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((int[]) buf[9])[0] = rslt.getInt(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 3);
              ((string[]) buf[11])[0] = rslt.getString(11, 15);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 10);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((int[]) buf[9])[0] = rslt.getInt(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 3);
              ((string[]) buf[11])[0] = rslt.getString(11, 15);
              ((int[]) buf[12])[0] = rslt.getInt(12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
