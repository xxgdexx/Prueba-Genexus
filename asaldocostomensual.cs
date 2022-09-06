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
   public class asaldocostomensual : GXDataArea
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
            A61SalCosAlmCod = (int)(NumberUtil.Val( GetPar( "SalCosAlmCod"), "."));
            AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A61SalCosAlmCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A62SalCosProdCod = GetPar( "SalCosProdCod");
            AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A62SalCosProdCod) ;
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
            Form.Meta.addItem("description", "Saldos Costos de Almacen Mensual", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSalCosAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public asaldocostomensual( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public asaldocostomensual( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_ASALDOCOSTOMENSUAL.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Año", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCosAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A59SalCosAno), 6, 0, ".", "")), StringUtil.LTrim( ((edtSalCosAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A59SalCosAno), "ZZZZZ9") : context.localUtil.Format( (decimal)(A59SalCosAno), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCosAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCosAno_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Mes", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCosMes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A60SalCosMes), 2, 0, ".", "")), StringUtil.LTrim( ((edtSalCosMes_Enabled!=0) ? context.localUtil.Format( (decimal)(A60SalCosMes), "Z9") : context.localUtil.Format( (decimal)(A60SalCosMes), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCosMes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCosMes_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Almacen", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCosAlmCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A61SalCosAlmCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtSalCosAlmCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A61SalCosAlmCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A61SalCosAlmCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCosAlmCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCosAlmCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Producto", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCosProdCod_Internalname, StringUtil.RTrim( A62SalCosProdCod), StringUtil.RTrim( context.localUtil.Format( A62SalCosProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCosProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCosProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Cantidad", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCosCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1830SalCosCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtSalCosCant_Enabled!=0) ? context.localUtil.Format( A1830SalCosCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A1830SalCosCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCosCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCosCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Costo Unit", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSalCosUni_Internalname, StringUtil.LTrim( StringUtil.NToC( A1831SalCosUni, 20, 8, ".", "")), StringUtil.LTrim( ((edtSalCosUni_Enabled!=0) ? context.localUtil.Format( A1831SalCosUni, "ZZZ,ZZZ,ZZ9.99999999") : context.localUtil.Format( A1831SalCosUni, "ZZZ,ZZZ,ZZ9.99999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','8');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSalCosUni_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSalCosUni_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "CantidadFormula", "right", false, "", "HLP_ASALDOCOSTOMENSUAL.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_ASALDOCOSTOMENSUAL.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_ASALDOCOSTOMENSUAL.htm");
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
            Z59SalCosAno = (int)(context.localUtil.CToN( cgiGet( "Z59SalCosAno"), ".", ","));
            Z60SalCosMes = (short)(context.localUtil.CToN( cgiGet( "Z60SalCosMes"), ".", ","));
            Z61SalCosAlmCod = (int)(context.localUtil.CToN( cgiGet( "Z61SalCosAlmCod"), ".", ","));
            Z62SalCosProdCod = cgiGet( "Z62SalCosProdCod");
            Z1830SalCosCant = context.localUtil.CToN( cgiGet( "Z1830SalCosCant"), ".", ",");
            Z1831SalCosUni = context.localUtil.CToN( cgiGet( "Z1831SalCosUni"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalCosAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalCosAno_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALCOSANO");
               AnyError = 1;
               GX_FocusControl = edtSalCosAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A59SalCosAno = 0;
               AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
            }
            else
            {
               A59SalCosAno = (int)(context.localUtil.CToN( cgiGet( edtSalCosAno_Internalname), ".", ","));
               AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalCosMes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalCosMes_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALCOSMES");
               AnyError = 1;
               GX_FocusControl = edtSalCosMes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A60SalCosMes = 0;
               AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
            }
            else
            {
               A60SalCosMes = (short)(context.localUtil.CToN( cgiGet( edtSalCosMes_Internalname), ".", ","));
               AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalCosAlmCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSalCosAlmCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALCOSALMCOD");
               AnyError = 1;
               GX_FocusControl = edtSalCosAlmCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A61SalCosAlmCod = 0;
               AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
            }
            else
            {
               A61SalCosAlmCod = (int)(context.localUtil.CToN( cgiGet( edtSalCosAlmCod_Internalname), ".", ","));
               AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
            }
            A62SalCosProdCod = StringUtil.Upper( cgiGet( edtSalCosProdCod_Internalname));
            AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalCosCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalCosCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALCOSCANT");
               AnyError = 1;
               GX_FocusControl = edtSalCosCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1830SalCosCant = 0;
               AssignAttri("", false, "A1830SalCosCant", StringUtil.LTrimStr( A1830SalCosCant, 15, 4));
            }
            else
            {
               A1830SalCosCant = context.localUtil.CToN( cgiGet( edtSalCosCant_Internalname), ".", ",");
               AssignAttri("", false, "A1830SalCosCant", StringUtil.LTrimStr( A1830SalCosCant, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtSalCosUni_Internalname), ".", ",") < -99999999.99999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtSalCosUni_Internalname), ".", ",") > 999999999.99999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SALCOSUNI");
               AnyError = 1;
               GX_FocusControl = edtSalCosUni_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1831SalCosUni = 0;
               AssignAttri("", false, "A1831SalCosUni", StringUtil.LTrimStr( A1831SalCosUni, 18, 8));
            }
            else
            {
               A1831SalCosUni = context.localUtil.CToN( cgiGet( edtSalCosUni_Internalname), ".", ",");
               AssignAttri("", false, "A1831SalCosUni", StringUtil.LTrimStr( A1831SalCosUni, 18, 8));
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
               A59SalCosAno = (int)(NumberUtil.Val( GetPar( "SalCosAno"), "."));
               AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
               A60SalCosMes = (short)(NumberUtil.Val( GetPar( "SalCosMes"), "."));
               AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
               A61SalCosAlmCod = (int)(NumberUtil.Val( GetPar( "SalCosAlmCod"), "."));
               AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
               A62SalCosProdCod = GetPar( "SalCosProdCod");
               AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
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
               InitAll1E48( ) ;
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
         DisableAttributes1E48( ) ;
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

      protected void CONFIRM_1E0( )
      {
         BeforeValidate1E48( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1E48( ) ;
            }
            else
            {
               CheckExtendedTable1E48( ) ;
               if ( AnyError == 0 )
               {
                  ZM1E48( 2) ;
                  ZM1E48( 3) ;
               }
               CloseExtendedTableCursors1E48( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1E0( ) ;
         }
      }

      protected void ResetCaption1E0( )
      {
      }

      protected void ZM1E48( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1830SalCosCant = T001E3_A1830SalCosCant[0];
               Z1831SalCosUni = T001E3_A1831SalCosUni[0];
            }
            else
            {
               Z1830SalCosCant = A1830SalCosCant;
               Z1831SalCosUni = A1831SalCosUni;
            }
         }
         if ( GX_JID == -1 )
         {
            Z59SalCosAno = A59SalCosAno;
            Z60SalCosMes = A60SalCosMes;
            Z1830SalCosCant = A1830SalCosCant;
            Z1831SalCosUni = A1831SalCosUni;
            Z61SalCosAlmCod = A61SalCosAlmCod;
            Z62SalCosProdCod = A62SalCosProdCod;
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

      protected void Load1E48( )
      {
         /* Using cursor T001E6 */
         pr_default.execute(4, new Object[] {A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound48 = 1;
            A1830SalCosCant = T001E6_A1830SalCosCant[0];
            AssignAttri("", false, "A1830SalCosCant", StringUtil.LTrimStr( A1830SalCosCant, 15, 4));
            A1831SalCosUni = T001E6_A1831SalCosUni[0];
            AssignAttri("", false, "A1831SalCosUni", StringUtil.LTrimStr( A1831SalCosUni, 18, 8));
            ZM1E48( -1) ;
         }
         pr_default.close(4);
         OnLoadActions1E48( ) ;
      }

      protected void OnLoadActions1E48( )
      {
      }

      protected void CheckExtendedTable1E48( )
      {
         nIsDirty_48 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T001E4 */
         pr_default.execute(2, new Object[] {A61SalCosAlmCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "SALCOSALMCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T001E5 */
         pr_default.execute(3, new Object[] {A62SalCosProdCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "SALCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1E48( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( int A61SalCosAlmCod )
      {
         /* Using cursor T001E7 */
         pr_default.execute(5, new Object[] {A61SalCosAlmCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "SALCOSALMCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosAlmCod_Internalname;
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

      protected void gxLoad_3( string A62SalCosProdCod )
      {
         /* Using cursor T001E8 */
         pr_default.execute(6, new Object[] {A62SalCosProdCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "SALCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosProdCod_Internalname;
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

      protected void GetKey1E48( )
      {
         /* Using cursor T001E9 */
         pr_default.execute(7, new Object[] {A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound48 = 1;
         }
         else
         {
            RcdFound48 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001E3 */
         pr_default.execute(1, new Object[] {A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1E48( 1) ;
            RcdFound48 = 1;
            A59SalCosAno = T001E3_A59SalCosAno[0];
            AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
            A60SalCosMes = T001E3_A60SalCosMes[0];
            AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
            A1830SalCosCant = T001E3_A1830SalCosCant[0];
            AssignAttri("", false, "A1830SalCosCant", StringUtil.LTrimStr( A1830SalCosCant, 15, 4));
            A1831SalCosUni = T001E3_A1831SalCosUni[0];
            AssignAttri("", false, "A1831SalCosUni", StringUtil.LTrimStr( A1831SalCosUni, 18, 8));
            A61SalCosAlmCod = T001E3_A61SalCosAlmCod[0];
            AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
            A62SalCosProdCod = T001E3_A62SalCosProdCod[0];
            AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
            Z59SalCosAno = A59SalCosAno;
            Z60SalCosMes = A60SalCosMes;
            Z61SalCosAlmCod = A61SalCosAlmCod;
            Z62SalCosProdCod = A62SalCosProdCod;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1E48( ) ;
            if ( AnyError == 1 )
            {
               RcdFound48 = 0;
               InitializeNonKey1E48( ) ;
            }
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound48 = 0;
            InitializeNonKey1E48( ) ;
            sMode48 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode48;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1E48( ) ;
         if ( RcdFound48 == 0 )
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
         RcdFound48 = 0;
         /* Using cursor T001E10 */
         pr_default.execute(8, new Object[] {A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T001E10_A59SalCosAno[0] < A59SalCosAno ) || ( T001E10_A59SalCosAno[0] == A59SalCosAno ) && ( T001E10_A60SalCosMes[0] < A60SalCosMes ) || ( T001E10_A60SalCosMes[0] == A60SalCosMes ) && ( T001E10_A59SalCosAno[0] == A59SalCosAno ) && ( T001E10_A61SalCosAlmCod[0] < A61SalCosAlmCod ) || ( T001E10_A61SalCosAlmCod[0] == A61SalCosAlmCod ) && ( T001E10_A60SalCosMes[0] == A60SalCosMes ) && ( T001E10_A59SalCosAno[0] == A59SalCosAno ) && ( StringUtil.StrCmp(T001E10_A62SalCosProdCod[0], A62SalCosProdCod) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T001E10_A59SalCosAno[0] > A59SalCosAno ) || ( T001E10_A59SalCosAno[0] == A59SalCosAno ) && ( T001E10_A60SalCosMes[0] > A60SalCosMes ) || ( T001E10_A60SalCosMes[0] == A60SalCosMes ) && ( T001E10_A59SalCosAno[0] == A59SalCosAno ) && ( T001E10_A61SalCosAlmCod[0] > A61SalCosAlmCod ) || ( T001E10_A61SalCosAlmCod[0] == A61SalCosAlmCod ) && ( T001E10_A60SalCosMes[0] == A60SalCosMes ) && ( T001E10_A59SalCosAno[0] == A59SalCosAno ) && ( StringUtil.StrCmp(T001E10_A62SalCosProdCod[0], A62SalCosProdCod) > 0 ) ) )
            {
               A59SalCosAno = T001E10_A59SalCosAno[0];
               AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
               A60SalCosMes = T001E10_A60SalCosMes[0];
               AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
               A61SalCosAlmCod = T001E10_A61SalCosAlmCod[0];
               AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
               A62SalCosProdCod = T001E10_A62SalCosProdCod[0];
               AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
               RcdFound48 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound48 = 0;
         /* Using cursor T001E11 */
         pr_default.execute(9, new Object[] {A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T001E11_A59SalCosAno[0] > A59SalCosAno ) || ( T001E11_A59SalCosAno[0] == A59SalCosAno ) && ( T001E11_A60SalCosMes[0] > A60SalCosMes ) || ( T001E11_A60SalCosMes[0] == A60SalCosMes ) && ( T001E11_A59SalCosAno[0] == A59SalCosAno ) && ( T001E11_A61SalCosAlmCod[0] > A61SalCosAlmCod ) || ( T001E11_A61SalCosAlmCod[0] == A61SalCosAlmCod ) && ( T001E11_A60SalCosMes[0] == A60SalCosMes ) && ( T001E11_A59SalCosAno[0] == A59SalCosAno ) && ( StringUtil.StrCmp(T001E11_A62SalCosProdCod[0], A62SalCosProdCod) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T001E11_A59SalCosAno[0] < A59SalCosAno ) || ( T001E11_A59SalCosAno[0] == A59SalCosAno ) && ( T001E11_A60SalCosMes[0] < A60SalCosMes ) || ( T001E11_A60SalCosMes[0] == A60SalCosMes ) && ( T001E11_A59SalCosAno[0] == A59SalCosAno ) && ( T001E11_A61SalCosAlmCod[0] < A61SalCosAlmCod ) || ( T001E11_A61SalCosAlmCod[0] == A61SalCosAlmCod ) && ( T001E11_A60SalCosMes[0] == A60SalCosMes ) && ( T001E11_A59SalCosAno[0] == A59SalCosAno ) && ( StringUtil.StrCmp(T001E11_A62SalCosProdCod[0], A62SalCosProdCod) < 0 ) ) )
            {
               A59SalCosAno = T001E11_A59SalCosAno[0];
               AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
               A60SalCosMes = T001E11_A60SalCosMes[0];
               AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
               A61SalCosAlmCod = T001E11_A61SalCosAlmCod[0];
               AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
               A62SalCosProdCod = T001E11_A62SalCosProdCod[0];
               AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
               RcdFound48 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1E48( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSalCosAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1E48( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound48 == 1 )
            {
               if ( ( A59SalCosAno != Z59SalCosAno ) || ( A60SalCosMes != Z60SalCosMes ) || ( A61SalCosAlmCod != Z61SalCosAlmCod ) || ( StringUtil.StrCmp(A62SalCosProdCod, Z62SalCosProdCod) != 0 ) )
               {
                  A59SalCosAno = Z59SalCosAno;
                  AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
                  A60SalCosMes = Z60SalCosMes;
                  AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
                  A61SalCosAlmCod = Z61SalCosAlmCod;
                  AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
                  A62SalCosProdCod = Z62SalCosProdCod;
                  AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SALCOSANO");
                  AnyError = 1;
                  GX_FocusControl = edtSalCosAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSalCosAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1E48( ) ;
                  GX_FocusControl = edtSalCosAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A59SalCosAno != Z59SalCosAno ) || ( A60SalCosMes != Z60SalCosMes ) || ( A61SalCosAlmCod != Z61SalCosAlmCod ) || ( StringUtil.StrCmp(A62SalCosProdCod, Z62SalCosProdCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSalCosAno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1E48( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SALCOSANO");
                     AnyError = 1;
                     GX_FocusControl = edtSalCosAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSalCosAno_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1E48( ) ;
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
         if ( ( A59SalCosAno != Z59SalCosAno ) || ( A60SalCosMes != Z60SalCosMes ) || ( A61SalCosAlmCod != Z61SalCosAlmCod ) || ( StringUtil.StrCmp(A62SalCosProdCod, Z62SalCosProdCod) != 0 ) )
         {
            A59SalCosAno = Z59SalCosAno;
            AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
            A60SalCosMes = Z60SalCosMes;
            AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
            A61SalCosAlmCod = Z61SalCosAlmCod;
            AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
            A62SalCosProdCod = Z62SalCosProdCod;
            AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SALCOSANO");
            AnyError = 1;
            GX_FocusControl = edtSalCosAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSalCosAno_Internalname;
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
         GetKey1E48( ) ;
         if ( RcdFound48 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "SALCOSANO");
               AnyError = 1;
               GX_FocusControl = edtSalCosAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( A59SalCosAno != Z59SalCosAno ) || ( A60SalCosMes != Z60SalCosMes ) || ( A61SalCosAlmCod != Z61SalCosAlmCod ) || ( StringUtil.StrCmp(A62SalCosProdCod, Z62SalCosProdCod) != 0 ) )
            {
               A59SalCosAno = Z59SalCosAno;
               AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
               A60SalCosMes = Z60SalCosMes;
               AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
               A61SalCosAlmCod = Z61SalCosAlmCod;
               AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
               A62SalCosProdCod = Z62SalCosProdCod;
               AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "SALCOSANO");
               AnyError = 1;
               GX_FocusControl = edtSalCosAno_Internalname;
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
            if ( ( A59SalCosAno != Z59SalCosAno ) || ( A60SalCosMes != Z60SalCosMes ) || ( A61SalCosAlmCod != Z61SalCosAlmCod ) || ( StringUtil.StrCmp(A62SalCosProdCod, Z62SalCosProdCod) != 0 ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SALCOSANO");
                  AnyError = 1;
                  GX_FocusControl = edtSalCosAno_Internalname;
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
         context.RollbackDataStores("asaldocostomensual",pr_default);
         GX_FocusControl = edtSalCosCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1E0( ) ;
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
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SALCOSANO");
            AnyError = 1;
            GX_FocusControl = edtSalCosAno_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSalCosCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1E48( ) ;
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalCosCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1E48( ) ;
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
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalCosCant_Internalname;
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
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalCosCant_Internalname;
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
         ScanStart1E48( ) ;
         if ( RcdFound48 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound48 != 0 )
            {
               ScanNext1E48( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSalCosCant_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1E48( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1E48( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001E2 */
            pr_default.execute(0, new Object[] {A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ASALDOCOSTOMENSUAL"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1830SalCosCant != T001E2_A1830SalCosCant[0] ) || ( Z1831SalCosUni != T001E2_A1831SalCosUni[0] ) )
            {
               if ( Z1830SalCosCant != T001E2_A1830SalCosCant[0] )
               {
                  GXUtil.WriteLog("asaldocostomensual:[seudo value changed for attri]"+"SalCosCant");
                  GXUtil.WriteLogRaw("Old: ",Z1830SalCosCant);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A1830SalCosCant[0]);
               }
               if ( Z1831SalCosUni != T001E2_A1831SalCosUni[0] )
               {
                  GXUtil.WriteLog("asaldocostomensual:[seudo value changed for attri]"+"SalCosUni");
                  GXUtil.WriteLogRaw("Old: ",Z1831SalCosUni);
                  GXUtil.WriteLogRaw("Current: ",T001E2_A1831SalCosUni[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ASALDOCOSTOMENSUAL"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1E48( )
      {
         BeforeValidate1E48( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E48( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1E48( 0) ;
            CheckOptimisticConcurrency1E48( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E48( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1E48( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001E12 */
                     pr_default.execute(10, new Object[] {A59SalCosAno, A60SalCosMes, A1830SalCosCant, A1831SalCosUni, A61SalCosAlmCod, A62SalCosProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("ASALDOCOSTOMENSUAL");
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
                           ResetCaption1E0( ) ;
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
               Load1E48( ) ;
            }
            EndLevel1E48( ) ;
         }
         CloseExtendedTableCursors1E48( ) ;
      }

      protected void Update1E48( )
      {
         BeforeValidate1E48( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1E48( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E48( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1E48( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1E48( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001E13 */
                     pr_default.execute(11, new Object[] {A1830SalCosCant, A1831SalCosUni, A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("ASALDOCOSTOMENSUAL");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ASALDOCOSTOMENSUAL"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1E48( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1E0( ) ;
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
            EndLevel1E48( ) ;
         }
         CloseExtendedTableCursors1E48( ) ;
      }

      protected void DeferredUpdate1E48( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1E48( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1E48( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1E48( ) ;
            AfterConfirm1E48( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1E48( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001E14 */
                  pr_default.execute(12, new Object[] {A59SalCosAno, A60SalCosMes, A61SalCosAlmCod, A62SalCosProdCod});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("ASALDOCOSTOMENSUAL");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound48 == 0 )
                        {
                           InitAll1E48( ) ;
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
                        ResetCaption1E0( ) ;
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
         sMode48 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1E48( ) ;
         Gx_mode = sMode48;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1E48( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1E48( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1E48( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("asaldocostomensual",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("asaldocostomensual",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1E48( )
      {
         /* Using cursor T001E15 */
         pr_default.execute(13);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound48 = 1;
            A59SalCosAno = T001E15_A59SalCosAno[0];
            AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
            A60SalCosMes = T001E15_A60SalCosMes[0];
            AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
            A61SalCosAlmCod = T001E15_A61SalCosAlmCod[0];
            AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
            A62SalCosProdCod = T001E15_A62SalCosProdCod[0];
            AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1E48( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound48 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound48 = 1;
            A59SalCosAno = T001E15_A59SalCosAno[0];
            AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
            A60SalCosMes = T001E15_A60SalCosMes[0];
            AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
            A61SalCosAlmCod = T001E15_A61SalCosAlmCod[0];
            AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
            A62SalCosProdCod = T001E15_A62SalCosProdCod[0];
            AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
         }
      }

      protected void ScanEnd1E48( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm1E48( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1E48( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1E48( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1E48( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1E48( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1E48( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1E48( )
      {
         edtSalCosAno_Enabled = 0;
         AssignProp("", false, edtSalCosAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCosAno_Enabled), 5, 0), true);
         edtSalCosMes_Enabled = 0;
         AssignProp("", false, edtSalCosMes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCosMes_Enabled), 5, 0), true);
         edtSalCosAlmCod_Enabled = 0;
         AssignProp("", false, edtSalCosAlmCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCosAlmCod_Enabled), 5, 0), true);
         edtSalCosProdCod_Enabled = 0;
         AssignProp("", false, edtSalCosProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCosProdCod_Enabled), 5, 0), true);
         edtSalCosCant_Enabled = 0;
         AssignProp("", false, edtSalCosCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCosCant_Enabled), 5, 0), true);
         edtSalCosUni_Enabled = 0;
         AssignProp("", false, edtSalCosUni_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSalCosUni_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1E48( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1E0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811465594", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("asaldocostomensual.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z59SalCosAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z59SalCosAno), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z60SalCosMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60SalCosMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z61SalCosAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61SalCosAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z62SalCosProdCod", StringUtil.RTrim( Z62SalCosProdCod));
         GxWebStd.gx_hidden_field( context, "Z1830SalCosCant", StringUtil.LTrim( StringUtil.NToC( Z1830SalCosCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1831SalCosUni", StringUtil.LTrim( StringUtil.NToC( Z1831SalCosUni, 18, 8, ".", "")));
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
         return formatLink("asaldocostomensual.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "ASALDOCOSTOMENSUAL" ;
      }

      public override string GetPgmdesc( )
      {
         return "Saldos Costos de Almacen Mensual" ;
      }

      protected void InitializeNonKey1E48( )
      {
         A1830SalCosCant = 0;
         AssignAttri("", false, "A1830SalCosCant", StringUtil.LTrimStr( A1830SalCosCant, 15, 4));
         A1831SalCosUni = 0;
         AssignAttri("", false, "A1831SalCosUni", StringUtil.LTrimStr( A1831SalCosUni, 18, 8));
         Z1830SalCosCant = 0;
         Z1831SalCosUni = 0;
      }

      protected void InitAll1E48( )
      {
         A59SalCosAno = 0;
         AssignAttri("", false, "A59SalCosAno", StringUtil.LTrimStr( (decimal)(A59SalCosAno), 6, 0));
         A60SalCosMes = 0;
         AssignAttri("", false, "A60SalCosMes", StringUtil.LTrimStr( (decimal)(A60SalCosMes), 2, 0));
         A61SalCosAlmCod = 0;
         AssignAttri("", false, "A61SalCosAlmCod", StringUtil.LTrimStr( (decimal)(A61SalCosAlmCod), 6, 0));
         A62SalCosProdCod = "";
         AssignAttri("", false, "A62SalCosProdCod", A62SalCosProdCod);
         InitializeNonKey1E48( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811465596", true, true);
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
         context.AddJavascriptSource("asaldocostomensual.js", "?202281811465596", false, true);
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
         edtSalCosAno_Internalname = "SALCOSANO";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtSalCosMes_Internalname = "SALCOSMES";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtSalCosAlmCod_Internalname = "SALCOSALMCOD";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtSalCosProdCod_Internalname = "SALCOSPRODCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtSalCosCant_Internalname = "SALCOSCANT";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtSalCosUni_Internalname = "SALCOSUNI";
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
         Form.Caption = "Saldos Costos de Almacen Mensual";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtSalCosUni_Jsonclick = "";
         edtSalCosUni_Enabled = 1;
         edtSalCosCant_Jsonclick = "";
         edtSalCosCant_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtSalCosProdCod_Jsonclick = "";
         edtSalCosProdCod_Enabled = 1;
         edtSalCosAlmCod_Jsonclick = "";
         edtSalCosAlmCod_Enabled = 1;
         edtSalCosMes_Jsonclick = "";
         edtSalCosMes_Enabled = 1;
         edtSalCosAno_Jsonclick = "";
         edtSalCosAno_Enabled = 1;
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
         /* Using cursor T001E16 */
         pr_default.execute(14, new Object[] {A61SalCosAlmCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "SALCOSALMCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosAlmCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(14);
         /* Using cursor T001E17 */
         pr_default.execute(15, new Object[] {A62SalCosProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "SALCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(15);
         GX_FocusControl = edtSalCosCant_Internalname;
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

      public void Valid_Salcosalmcod( )
      {
         /* Using cursor T001E16 */
         pr_default.execute(14, new Object[] {A61SalCosAlmCod});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No existe 'Almacen'.", "ForeignKeyNotFound", 1, "SALCOSALMCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosAlmCod_Internalname;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Salcosprodcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         /* Using cursor T001E17 */
         pr_default.execute(15, new Object[] {A62SalCosProdCod});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto'.", "ForeignKeyNotFound", 1, "SALCOSPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtSalCosProdCod_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1830SalCosCant", StringUtil.LTrim( StringUtil.NToC( A1830SalCosCant, 15, 4, ".", "")));
         AssignAttri("", false, "A1831SalCosUni", StringUtil.LTrim( StringUtil.NToC( A1831SalCosUni, 18, 8, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z59SalCosAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z59SalCosAno), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z60SalCosMes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60SalCosMes), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z61SalCosAlmCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z61SalCosAlmCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z62SalCosProdCod", StringUtil.RTrim( Z62SalCosProdCod));
         GxWebStd.gx_hidden_field( context, "Z1830SalCosCant", StringUtil.LTrim( StringUtil.NToC( Z1830SalCosCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1831SalCosUni", StringUtil.LTrim( StringUtil.NToC( Z1831SalCosUni, 18, 8, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
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
         setEventMetadata("VALID_SALCOSANO","{handler:'Valid_Salcosano',iparms:[]");
         setEventMetadata("VALID_SALCOSANO",",oparms:[]}");
         setEventMetadata("VALID_SALCOSMES","{handler:'Valid_Salcosmes',iparms:[]");
         setEventMetadata("VALID_SALCOSMES",",oparms:[]}");
         setEventMetadata("VALID_SALCOSALMCOD","{handler:'Valid_Salcosalmcod',iparms:[{av:'A61SalCosAlmCod',fld:'SALCOSALMCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_SALCOSALMCOD",",oparms:[]}");
         setEventMetadata("VALID_SALCOSPRODCOD","{handler:'Valid_Salcosprodcod',iparms:[{av:'A59SalCosAno',fld:'SALCOSANO',pic:'ZZZZZ9'},{av:'A60SalCosMes',fld:'SALCOSMES',pic:'Z9'},{av:'A61SalCosAlmCod',fld:'SALCOSALMCOD',pic:'ZZZZZ9'},{av:'A62SalCosProdCod',fld:'SALCOSPRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SALCOSPRODCOD",",oparms:[{av:'A1830SalCosCant',fld:'SALCOSCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A1831SalCosUni',fld:'SALCOSUNI',pic:'ZZZ,ZZZ,ZZ9.99999999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z59SalCosAno'},{av:'Z60SalCosMes'},{av:'Z61SalCosAlmCod'},{av:'Z62SalCosProdCod'},{av:'Z1830SalCosCant'},{av:'Z1831SalCosUni'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z62SalCosProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A62SalCosProdCod = "";
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
         lblTextblock4_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
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
         T001E6_A59SalCosAno = new int[1] ;
         T001E6_A60SalCosMes = new short[1] ;
         T001E6_A1830SalCosCant = new decimal[1] ;
         T001E6_A1831SalCosUni = new decimal[1] ;
         T001E6_A61SalCosAlmCod = new int[1] ;
         T001E6_A62SalCosProdCod = new string[] {""} ;
         T001E4_A61SalCosAlmCod = new int[1] ;
         T001E5_A62SalCosProdCod = new string[] {""} ;
         T001E7_A61SalCosAlmCod = new int[1] ;
         T001E8_A62SalCosProdCod = new string[] {""} ;
         T001E9_A59SalCosAno = new int[1] ;
         T001E9_A60SalCosMes = new short[1] ;
         T001E9_A61SalCosAlmCod = new int[1] ;
         T001E9_A62SalCosProdCod = new string[] {""} ;
         T001E3_A59SalCosAno = new int[1] ;
         T001E3_A60SalCosMes = new short[1] ;
         T001E3_A1830SalCosCant = new decimal[1] ;
         T001E3_A1831SalCosUni = new decimal[1] ;
         T001E3_A61SalCosAlmCod = new int[1] ;
         T001E3_A62SalCosProdCod = new string[] {""} ;
         sMode48 = "";
         T001E10_A59SalCosAno = new int[1] ;
         T001E10_A60SalCosMes = new short[1] ;
         T001E10_A61SalCosAlmCod = new int[1] ;
         T001E10_A62SalCosProdCod = new string[] {""} ;
         T001E11_A59SalCosAno = new int[1] ;
         T001E11_A60SalCosMes = new short[1] ;
         T001E11_A61SalCosAlmCod = new int[1] ;
         T001E11_A62SalCosProdCod = new string[] {""} ;
         T001E2_A59SalCosAno = new int[1] ;
         T001E2_A60SalCosMes = new short[1] ;
         T001E2_A1830SalCosCant = new decimal[1] ;
         T001E2_A1831SalCosUni = new decimal[1] ;
         T001E2_A61SalCosAlmCod = new int[1] ;
         T001E2_A62SalCosProdCod = new string[] {""} ;
         T001E15_A59SalCosAno = new int[1] ;
         T001E15_A60SalCosMes = new short[1] ;
         T001E15_A61SalCosAlmCod = new int[1] ;
         T001E15_A62SalCosProdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T001E16_A61SalCosAlmCod = new int[1] ;
         T001E17_A62SalCosProdCod = new string[] {""} ;
         ZZ62SalCosProdCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.asaldocostomensual__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.asaldocostomensual__default(),
            new Object[][] {
                new Object[] {
               T001E2_A59SalCosAno, T001E2_A60SalCosMes, T001E2_A1830SalCosCant, T001E2_A1831SalCosUni, T001E2_A61SalCosAlmCod, T001E2_A62SalCosProdCod
               }
               , new Object[] {
               T001E3_A59SalCosAno, T001E3_A60SalCosMes, T001E3_A1830SalCosCant, T001E3_A1831SalCosUni, T001E3_A61SalCosAlmCod, T001E3_A62SalCosProdCod
               }
               , new Object[] {
               T001E4_A61SalCosAlmCod
               }
               , new Object[] {
               T001E5_A62SalCosProdCod
               }
               , new Object[] {
               T001E6_A59SalCosAno, T001E6_A60SalCosMes, T001E6_A1830SalCosCant, T001E6_A1831SalCosUni, T001E6_A61SalCosAlmCod, T001E6_A62SalCosProdCod
               }
               , new Object[] {
               T001E7_A61SalCosAlmCod
               }
               , new Object[] {
               T001E8_A62SalCosProdCod
               }
               , new Object[] {
               T001E9_A59SalCosAno, T001E9_A60SalCosMes, T001E9_A61SalCosAlmCod, T001E9_A62SalCosProdCod
               }
               , new Object[] {
               T001E10_A59SalCosAno, T001E10_A60SalCosMes, T001E10_A61SalCosAlmCod, T001E10_A62SalCosProdCod
               }
               , new Object[] {
               T001E11_A59SalCosAno, T001E11_A60SalCosMes, T001E11_A61SalCosAlmCod, T001E11_A62SalCosProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001E15_A59SalCosAno, T001E15_A60SalCosMes, T001E15_A61SalCosAlmCod, T001E15_A62SalCosProdCod
               }
               , new Object[] {
               T001E16_A61SalCosAlmCod
               }
               , new Object[] {
               T001E17_A62SalCosProdCod
               }
            }
         );
      }

      private short Z60SalCosMes ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A60SalCosMes ;
      private short GX_JID ;
      private short RcdFound48 ;
      private short nIsDirty_48 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ60SalCosMes ;
      private int Z59SalCosAno ;
      private int Z61SalCosAlmCod ;
      private int A61SalCosAlmCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A59SalCosAno ;
      private int edtSalCosAno_Enabled ;
      private int edtSalCosMes_Enabled ;
      private int edtSalCosAlmCod_Enabled ;
      private int edtSalCosProdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtSalCosCant_Enabled ;
      private int edtSalCosUni_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ59SalCosAno ;
      private int ZZ61SalCosAlmCod ;
      private decimal Z1830SalCosCant ;
      private decimal Z1831SalCosUni ;
      private decimal A1830SalCosCant ;
      private decimal A1831SalCosUni ;
      private decimal ZZ1830SalCosCant ;
      private decimal ZZ1831SalCosUni ;
      private string sPrefix ;
      private string Z62SalCosProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A62SalCosProdCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSalCosAno_Internalname ;
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
      private string edtSalCosAno_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtSalCosMes_Internalname ;
      private string edtSalCosMes_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtSalCosAlmCod_Internalname ;
      private string edtSalCosAlmCod_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtSalCosProdCod_Internalname ;
      private string edtSalCosProdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtSalCosCant_Internalname ;
      private string edtSalCosCant_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtSalCosUni_Internalname ;
      private string edtSalCosUni_Jsonclick ;
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
      private string sMode48 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ62SalCosProdCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T001E6_A59SalCosAno ;
      private short[] T001E6_A60SalCosMes ;
      private decimal[] T001E6_A1830SalCosCant ;
      private decimal[] T001E6_A1831SalCosUni ;
      private int[] T001E6_A61SalCosAlmCod ;
      private string[] T001E6_A62SalCosProdCod ;
      private int[] T001E4_A61SalCosAlmCod ;
      private string[] T001E5_A62SalCosProdCod ;
      private int[] T001E7_A61SalCosAlmCod ;
      private string[] T001E8_A62SalCosProdCod ;
      private int[] T001E9_A59SalCosAno ;
      private short[] T001E9_A60SalCosMes ;
      private int[] T001E9_A61SalCosAlmCod ;
      private string[] T001E9_A62SalCosProdCod ;
      private int[] T001E3_A59SalCosAno ;
      private short[] T001E3_A60SalCosMes ;
      private decimal[] T001E3_A1830SalCosCant ;
      private decimal[] T001E3_A1831SalCosUni ;
      private int[] T001E3_A61SalCosAlmCod ;
      private string[] T001E3_A62SalCosProdCod ;
      private int[] T001E10_A59SalCosAno ;
      private short[] T001E10_A60SalCosMes ;
      private int[] T001E10_A61SalCosAlmCod ;
      private string[] T001E10_A62SalCosProdCod ;
      private int[] T001E11_A59SalCosAno ;
      private short[] T001E11_A60SalCosMes ;
      private int[] T001E11_A61SalCosAlmCod ;
      private string[] T001E11_A62SalCosProdCod ;
      private int[] T001E2_A59SalCosAno ;
      private short[] T001E2_A60SalCosMes ;
      private decimal[] T001E2_A1830SalCosCant ;
      private decimal[] T001E2_A1831SalCosUni ;
      private int[] T001E2_A61SalCosAlmCod ;
      private string[] T001E2_A62SalCosProdCod ;
      private int[] T001E15_A59SalCosAno ;
      private short[] T001E15_A60SalCosMes ;
      private int[] T001E15_A61SalCosAlmCod ;
      private string[] T001E15_A62SalCosProdCod ;
      private int[] T001E16_A61SalCosAlmCod ;
      private string[] T001E17_A62SalCosProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class asaldocostomensual__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class asaldocostomensual__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001E6;
        prmT001E6 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E4;
        prmT001E4 = new Object[] {
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001E5;
        prmT001E5 = new Object[] {
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E7;
        prmT001E7 = new Object[] {
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001E8;
        prmT001E8 = new Object[] {
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E9;
        prmT001E9 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E3;
        prmT001E3 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E10;
        prmT001E10 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E11;
        prmT001E11 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E2;
        prmT001E2 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E12;
        prmT001E12 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosCant",GXType.Decimal,15,4) ,
        new ParDef("@SalCosUni",GXType.Decimal,18,8) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E13;
        prmT001E13 = new Object[] {
        new ParDef("@SalCosCant",GXType.Decimal,15,4) ,
        new ParDef("@SalCosUni",GXType.Decimal,18,8) ,
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E14;
        prmT001E14 = new Object[] {
        new ParDef("@SalCosAno",GXType.Int32,6,0) ,
        new ParDef("@SalCosMes",GXType.Int16,2,0) ,
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0) ,
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001E15;
        prmT001E15 = new Object[] {
        };
        Object[] prmT001E16;
        prmT001E16 = new Object[] {
        new ParDef("@SalCosAlmCod",GXType.Int32,6,0)
        };
        Object[] prmT001E17;
        prmT001E17 = new Object[] {
        new ParDef("@SalCosProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001E2", "SELECT [SalCosAno], [SalCosMes], [SalCosCant], [SalCosUni], [SalCosAlmCod] AS SalCosAlmCod, [SalCosProdCod] AS SalCosProdCod FROM [ASALDOCOSTOMENSUAL] WITH (UPDLOCK) WHERE [SalCosAno] = @SalCosAno AND [SalCosMes] = @SalCosMes AND [SalCosAlmCod] = @SalCosAlmCod AND [SalCosProdCod] = @SalCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E3", "SELECT [SalCosAno], [SalCosMes], [SalCosCant], [SalCosUni], [SalCosAlmCod] AS SalCosAlmCod, [SalCosProdCod] AS SalCosProdCod FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosAno] = @SalCosAno AND [SalCosMes] = @SalCosMes AND [SalCosAlmCod] = @SalCosAlmCod AND [SalCosProdCod] = @SalCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E4", "SELECT [AlmCod] AS SalCosAlmCod FROM [CALMACEN] WHERE [AlmCod] = @SalCosAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E5", "SELECT [ProdCod] AS SalCosProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @SalCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E6", "SELECT TM1.[SalCosAno], TM1.[SalCosMes], TM1.[SalCosCant], TM1.[SalCosUni], TM1.[SalCosAlmCod] AS SalCosAlmCod, TM1.[SalCosProdCod] AS SalCosProdCod FROM [ASALDOCOSTOMENSUAL] TM1 WHERE TM1.[SalCosAno] = @SalCosAno and TM1.[SalCosMes] = @SalCosMes and TM1.[SalCosAlmCod] = @SalCosAlmCod and TM1.[SalCosProdCod] = @SalCosProdCod ORDER BY TM1.[SalCosAno], TM1.[SalCosMes], TM1.[SalCosAlmCod], TM1.[SalCosProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E7", "SELECT [AlmCod] AS SalCosAlmCod FROM [CALMACEN] WHERE [AlmCod] = @SalCosAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E8", "SELECT [ProdCod] AS SalCosProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @SalCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E9", "SELECT [SalCosAno], [SalCosMes], [SalCosAlmCod] AS SalCosAlmCod, [SalCosProdCod] AS SalCosProdCod FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosAno] = @SalCosAno AND [SalCosMes] = @SalCosMes AND [SalCosAlmCod] = @SalCosAlmCod AND [SalCosProdCod] = @SalCosProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E10", "SELECT TOP 1 [SalCosAno], [SalCosMes], [SalCosAlmCod] AS SalCosAlmCod, [SalCosProdCod] AS SalCosProdCod FROM [ASALDOCOSTOMENSUAL] WHERE ( [SalCosAno] > @SalCosAno or [SalCosAno] = @SalCosAno and [SalCosMes] > @SalCosMes or [SalCosMes] = @SalCosMes and [SalCosAno] = @SalCosAno and [SalCosAlmCod] > @SalCosAlmCod or [SalCosAlmCod] = @SalCosAlmCod and [SalCosMes] = @SalCosMes and [SalCosAno] = @SalCosAno and [SalCosProdCod] > @SalCosProdCod) ORDER BY [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001E11", "SELECT TOP 1 [SalCosAno], [SalCosMes], [SalCosAlmCod] AS SalCosAlmCod, [SalCosProdCod] AS SalCosProdCod FROM [ASALDOCOSTOMENSUAL] WHERE ( [SalCosAno] < @SalCosAno or [SalCosAno] = @SalCosAno and [SalCosMes] < @SalCosMes or [SalCosMes] = @SalCosMes and [SalCosAno] = @SalCosAno and [SalCosAlmCod] < @SalCosAlmCod or [SalCosAlmCod] = @SalCosAlmCod and [SalCosMes] = @SalCosMes and [SalCosAno] = @SalCosAno and [SalCosProdCod] < @SalCosProdCod) ORDER BY [SalCosAno] DESC, [SalCosMes] DESC, [SalCosAlmCod] DESC, [SalCosProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001E12", "INSERT INTO [ASALDOCOSTOMENSUAL]([SalCosAno], [SalCosMes], [SalCosCant], [SalCosUni], [SalCosAlmCod], [SalCosProdCod]) VALUES(@SalCosAno, @SalCosMes, @SalCosCant, @SalCosUni, @SalCosAlmCod, @SalCosProdCod)", GxErrorMask.GX_NOMASK,prmT001E12)
           ,new CursorDef("T001E13", "UPDATE [ASALDOCOSTOMENSUAL] SET [SalCosCant]=@SalCosCant, [SalCosUni]=@SalCosUni  WHERE [SalCosAno] = @SalCosAno AND [SalCosMes] = @SalCosMes AND [SalCosAlmCod] = @SalCosAlmCod AND [SalCosProdCod] = @SalCosProdCod", GxErrorMask.GX_NOMASK,prmT001E13)
           ,new CursorDef("T001E14", "DELETE FROM [ASALDOCOSTOMENSUAL]  WHERE [SalCosAno] = @SalCosAno AND [SalCosMes] = @SalCosMes AND [SalCosAlmCod] = @SalCosAlmCod AND [SalCosProdCod] = @SalCosProdCod", GxErrorMask.GX_NOMASK,prmT001E14)
           ,new CursorDef("T001E15", "SELECT [SalCosAno], [SalCosMes], [SalCosAlmCod] AS SalCosAlmCod, [SalCosProdCod] AS SalCosProdCod FROM [ASALDOCOSTOMENSUAL] ORDER BY [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001E15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E16", "SELECT [AlmCod] AS SalCosAlmCod FROM [CALMACEN] WHERE [AlmCod] = @SalCosAlmCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001E17", "SELECT [ProdCod] AS SalCosProdCod FROM [APRODUCTOS] WHERE [ProdCod] = @SalCosProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001E17,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
