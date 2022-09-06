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
   public class ctippedido : GXDataArea
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
            Form.Meta.addItem("description", "Tipos de Pedidos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public ctippedido( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public ctippedido( IGxContext context )
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
         cmbTPedSts = new GXCombobox();
         chkTPedGuia = new GXCheckbox();
         chkTPedFac = new GXCheckbox();
         chkTPedPer = new GXCheckbox();
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
         if ( cmbTPedSts.ItemCount > 0 )
         {
            A1936TPedSts = (short)(NumberUtil.Val( cmbTPedSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0))), "."));
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTPedSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
            AssignProp("", false, cmbTPedSts_Internalname, "Values", cmbTPedSts.ToJavascriptSource(), true);
         }
         A1933TPedGuia = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1933TPedGuia), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
         A1932TPedFac = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1932TPedFac), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
         A1935TPedPer = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1935TPedPer), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CTIPPEDIDO.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPedCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A212TPedCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTPedCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A212TPedCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A212TPedCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPedCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPedCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Tipo de Pedidos", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPedDsc_Internalname, StringUtil.RTrim( A1931TPedDsc), StringUtil.RTrim( context.localUtil.Format( A1931TPedDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPedDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPedDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTPedSts, cmbTPedSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0)), 1, cmbTPedSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTPedSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 1, "HLP_CTIPPEDIDO.htm");
         cmbTPedSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         AssignProp("", false, cmbTPedSts_Internalname, "Values", (string)(cmbTPedSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Afecta Guia", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTPedGuia_Internalname, StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0), "", "", 1, chkTPedGuia.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(36, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Afecta Factura", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTPedFac_Internalname, StringUtil.Str( (decimal)(A1932TPedFac), 1, 0), "", "", 1, chkTPedFac.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,41);\"");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Afecta Percepción", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTPedPer_Internalname, StringUtil.Str( (decimal)(A1935TPedPer), 1, 0), "", "", 1, chkTPedPer.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(46, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Tipo Movimiento Almacen", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTPedMovCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1934TPedMovCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTPedMovCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A1934TPedMovCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A1934TPedMovCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTPedMovCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTPedMovCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CTIPPEDIDO.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CTIPPEDIDO.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CTIPPEDIDO.htm");
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
            Z212TPedCod = (int)(context.localUtil.CToN( cgiGet( "Z212TPedCod"), ".", ","));
            Z1931TPedDsc = cgiGet( "Z1931TPedDsc");
            Z1936TPedSts = (short)(context.localUtil.CToN( cgiGet( "Z1936TPedSts"), ".", ","));
            Z1933TPedGuia = (short)(context.localUtil.CToN( cgiGet( "Z1933TPedGuia"), ".", ","));
            Z1932TPedFac = (short)(context.localUtil.CToN( cgiGet( "Z1932TPedFac"), ".", ","));
            Z1935TPedPer = (short)(context.localUtil.CToN( cgiGet( "Z1935TPedPer"), ".", ","));
            Z1934TPedMovCod = (int)(context.localUtil.CToN( cgiGet( "Z1934TPedMovCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtTPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A212TPedCod = 0;
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            }
            else
            {
               A212TPedCod = (int)(context.localUtil.CToN( cgiGet( edtTPedCod_Internalname), ".", ","));
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            }
            A1931TPedDsc = cgiGet( edtTPedDsc_Internalname);
            AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
            cmbTPedSts.CurrentValue = cgiGet( cmbTPedSts_Internalname);
            A1936TPedSts = (short)(NumberUtil.Val( cgiGet( cmbTPedSts_Internalname), "."));
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTPedGuia_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTPedGuia_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDGUIA");
               AnyError = 1;
               GX_FocusControl = chkTPedGuia_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1933TPedGuia = 0;
               AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
            }
            else
            {
               A1933TPedGuia = (short)(((StringUtil.StrCmp(cgiGet( chkTPedGuia_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTPedFac_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTPedFac_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDFAC");
               AnyError = 1;
               GX_FocusControl = chkTPedFac_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1932TPedFac = 0;
               AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
            }
            else
            {
               A1932TPedFac = (short)(((StringUtil.StrCmp(cgiGet( chkTPedFac_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
            }
            if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTPedPer_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTPedPer_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDPER");
               AnyError = 1;
               GX_FocusControl = chkTPedPer_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1935TPedPer = 0;
               AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
            }
            else
            {
               A1935TPedPer = (short)(((StringUtil.StrCmp(cgiGet( chkTPedPer_Internalname), "1")==0) ? 1 : 0));
               AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtTPedMovCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTPedMovCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPEDMOVCOD");
               AnyError = 1;
               GX_FocusControl = edtTPedMovCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1934TPedMovCod = 0;
               AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
            }
            else
            {
               A1934TPedMovCod = (int)(context.localUtil.CToN( cgiGet( edtTPedMovCod_Internalname), ".", ","));
               AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
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
               A212TPedCod = (int)(NumberUtil.Val( GetPar( "TPedCod"), "."));
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
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
               InitAll3W135( ) ;
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
         DisableAttributes3W135( ) ;
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

      protected void CONFIRM_3W0( )
      {
         BeforeValidate3W135( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3W135( ) ;
            }
            else
            {
               CheckExtendedTable3W135( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3W135( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3W0( ) ;
         }
      }

      protected void ResetCaption3W0( )
      {
      }

      protected void ZM3W135( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1931TPedDsc = T003W3_A1931TPedDsc[0];
               Z1936TPedSts = T003W3_A1936TPedSts[0];
               Z1933TPedGuia = T003W3_A1933TPedGuia[0];
               Z1932TPedFac = T003W3_A1932TPedFac[0];
               Z1935TPedPer = T003W3_A1935TPedPer[0];
               Z1934TPedMovCod = T003W3_A1934TPedMovCod[0];
            }
            else
            {
               Z1931TPedDsc = A1931TPedDsc;
               Z1936TPedSts = A1936TPedSts;
               Z1933TPedGuia = A1933TPedGuia;
               Z1932TPedFac = A1932TPedFac;
               Z1935TPedPer = A1935TPedPer;
               Z1934TPedMovCod = A1934TPedMovCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z212TPedCod = A212TPedCod;
            Z1931TPedDsc = A1931TPedDsc;
            Z1936TPedSts = A1936TPedSts;
            Z1933TPedGuia = A1933TPedGuia;
            Z1932TPedFac = A1932TPedFac;
            Z1935TPedPer = A1935TPedPer;
            Z1934TPedMovCod = A1934TPedMovCod;
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

      protected void Load3W135( )
      {
         /* Using cursor T003W4 */
         pr_default.execute(2, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound135 = 1;
            A1931TPedDsc = T003W4_A1931TPedDsc[0];
            AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
            A1936TPedSts = T003W4_A1936TPedSts[0];
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
            A1933TPedGuia = T003W4_A1933TPedGuia[0];
            AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
            A1932TPedFac = T003W4_A1932TPedFac[0];
            AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
            A1935TPedPer = T003W4_A1935TPedPer[0];
            AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
            A1934TPedMovCod = T003W4_A1934TPedMovCod[0];
            AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
            ZM3W135( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3W135( ) ;
      }

      protected void OnLoadActions3W135( )
      {
      }

      protected void CheckExtendedTable3W135( )
      {
         nIsDirty_135 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3W135( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3W135( )
      {
         /* Using cursor T003W5 */
         pr_default.execute(3, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound135 = 1;
         }
         else
         {
            RcdFound135 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003W3 */
         pr_default.execute(1, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3W135( 1) ;
            RcdFound135 = 1;
            A212TPedCod = T003W3_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            A1931TPedDsc = T003W3_A1931TPedDsc[0];
            AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
            A1936TPedSts = T003W3_A1936TPedSts[0];
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
            A1933TPedGuia = T003W3_A1933TPedGuia[0];
            AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
            A1932TPedFac = T003W3_A1932TPedFac[0];
            AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
            A1935TPedPer = T003W3_A1935TPedPer[0];
            AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
            A1934TPedMovCod = T003W3_A1934TPedMovCod[0];
            AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
            Z212TPedCod = A212TPedCod;
            sMode135 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3W135( ) ;
            if ( AnyError == 1 )
            {
               RcdFound135 = 0;
               InitializeNonKey3W135( ) ;
            }
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound135 = 0;
            InitializeNonKey3W135( ) ;
            sMode135 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode135;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3W135( ) ;
         if ( RcdFound135 == 0 )
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
         RcdFound135 = 0;
         /* Using cursor T003W6 */
         pr_default.execute(4, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003W6_A212TPedCod[0] < A212TPedCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003W6_A212TPedCod[0] > A212TPedCod ) ) )
            {
               A212TPedCod = T003W6_A212TPedCod[0];
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
               RcdFound135 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound135 = 0;
         /* Using cursor T003W7 */
         pr_default.execute(5, new Object[] {A212TPedCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003W7_A212TPedCod[0] > A212TPedCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003W7_A212TPedCod[0] < A212TPedCod ) ) )
            {
               A212TPedCod = T003W7_A212TPedCod[0];
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
               RcdFound135 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3W135( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3W135( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound135 == 1 )
            {
               if ( A212TPedCod != Z212TPedCod )
               {
                  A212TPedCod = Z212TPedCod;
                  AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TPEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3W135( ) ;
                  GX_FocusControl = edtTPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A212TPedCod != Z212TPedCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTPedCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3W135( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPEDCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtTPedCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3W135( ) ;
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
         if ( A212TPedCod != Z212TPedCod )
         {
            A212TPedCod = Z212TPedCod;
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtTPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTPedCod_Internalname;
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
         GetKey3W135( ) ;
         if ( RcdFound135 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtTPedCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A212TPedCod != Z212TPedCod )
            {
               A212TPedCod = Z212TPedCod;
               AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "TPEDCOD");
               AnyError = 1;
               GX_FocusControl = edtTPedCod_Internalname;
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
            if ( A212TPedCod != Z212TPedCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPEDCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTPedCod_Internalname;
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
         context.RollbackDataStores("ctippedido",pr_default);
         GX_FocusControl = edtTPedDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3W0( ) ;
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
         if ( RcdFound135 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TPEDCOD");
            AnyError = 1;
            GX_FocusControl = edtTPedCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtTPedDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3W135( ) ;
         if ( RcdFound135 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPedDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3W135( ) ;
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
         if ( RcdFound135 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPedDsc_Internalname;
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
         if ( RcdFound135 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPedDsc_Internalname;
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
         ScanStart3W135( ) ;
         if ( RcdFound135 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound135 != 0 )
            {
               ScanNext3W135( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtTPedDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3W135( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3W135( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003W2 */
            pr_default.execute(0, new Object[] {A212TPedCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPPEDIDO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1931TPedDsc, T003W2_A1931TPedDsc[0]) != 0 ) || ( Z1936TPedSts != T003W2_A1936TPedSts[0] ) || ( Z1933TPedGuia != T003W2_A1933TPedGuia[0] ) || ( Z1932TPedFac != T003W2_A1932TPedFac[0] ) || ( Z1935TPedPer != T003W2_A1935TPedPer[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1934TPedMovCod != T003W2_A1934TPedMovCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z1931TPedDsc, T003W2_A1931TPedDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("ctippedido:[seudo value changed for attri]"+"TPedDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1931TPedDsc);
                  GXUtil.WriteLogRaw("Current: ",T003W2_A1931TPedDsc[0]);
               }
               if ( Z1936TPedSts != T003W2_A1936TPedSts[0] )
               {
                  GXUtil.WriteLog("ctippedido:[seudo value changed for attri]"+"TPedSts");
                  GXUtil.WriteLogRaw("Old: ",Z1936TPedSts);
                  GXUtil.WriteLogRaw("Current: ",T003W2_A1936TPedSts[0]);
               }
               if ( Z1933TPedGuia != T003W2_A1933TPedGuia[0] )
               {
                  GXUtil.WriteLog("ctippedido:[seudo value changed for attri]"+"TPedGuia");
                  GXUtil.WriteLogRaw("Old: ",Z1933TPedGuia);
                  GXUtil.WriteLogRaw("Current: ",T003W2_A1933TPedGuia[0]);
               }
               if ( Z1932TPedFac != T003W2_A1932TPedFac[0] )
               {
                  GXUtil.WriteLog("ctippedido:[seudo value changed for attri]"+"TPedFac");
                  GXUtil.WriteLogRaw("Old: ",Z1932TPedFac);
                  GXUtil.WriteLogRaw("Current: ",T003W2_A1932TPedFac[0]);
               }
               if ( Z1935TPedPer != T003W2_A1935TPedPer[0] )
               {
                  GXUtil.WriteLog("ctippedido:[seudo value changed for attri]"+"TPedPer");
                  GXUtil.WriteLogRaw("Old: ",Z1935TPedPer);
                  GXUtil.WriteLogRaw("Current: ",T003W2_A1935TPedPer[0]);
               }
               if ( Z1934TPedMovCod != T003W2_A1934TPedMovCod[0] )
               {
                  GXUtil.WriteLog("ctippedido:[seudo value changed for attri]"+"TPedMovCod");
                  GXUtil.WriteLogRaw("Old: ",Z1934TPedMovCod);
                  GXUtil.WriteLogRaw("Current: ",T003W2_A1934TPedMovCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPPEDIDO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3W135( )
      {
         BeforeValidate3W135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3W135( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3W135( 0) ;
            CheckOptimisticConcurrency3W135( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3W135( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3W135( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003W8 */
                     pr_default.execute(6, new Object[] {A212TPedCod, A1931TPedDsc, A1936TPedSts, A1933TPedGuia, A1932TPedFac, A1935TPedPer, A1934TPedMovCod});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPPEDIDO");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption3W0( ) ;
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
               Load3W135( ) ;
            }
            EndLevel3W135( ) ;
         }
         CloseExtendedTableCursors3W135( ) ;
      }

      protected void Update3W135( )
      {
         BeforeValidate3W135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3W135( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3W135( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3W135( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3W135( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003W9 */
                     pr_default.execute(7, new Object[] {A1931TPedDsc, A1936TPedSts, A1933TPedGuia, A1932TPedFac, A1935TPedPer, A1934TPedMovCod, A212TPedCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPPEDIDO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPPEDIDO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3W135( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3W0( ) ;
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
            EndLevel3W135( ) ;
         }
         CloseExtendedTableCursors3W135( ) ;
      }

      protected void DeferredUpdate3W135( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3W135( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3W135( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3W135( ) ;
            AfterConfirm3W135( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3W135( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003W10 */
                  pr_default.execute(8, new Object[] {A212TPedCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPPEDIDO");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound135 == 0 )
                        {
                           InitAll3W135( ) ;
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
                        ResetCaption3W0( ) ;
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
         sMode135 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3W135( ) ;
         Gx_mode = sMode135;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3W135( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003W11 */
            pr_default.execute(9, new Object[] {A212TPedCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel3W135( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3W135( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("ctippedido",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3W0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("ctippedido",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3W135( )
      {
         /* Using cursor T003W12 */
         pr_default.execute(10);
         RcdFound135 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound135 = 1;
            A212TPedCod = T003W12_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3W135( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound135 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound135 = 1;
            A212TPedCod = T003W12_A212TPedCod[0];
            AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         }
      }

      protected void ScanEnd3W135( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm3W135( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3W135( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3W135( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3W135( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3W135( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3W135( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3W135( )
      {
         edtTPedCod_Enabled = 0;
         AssignProp("", false, edtTPedCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedCod_Enabled), 5, 0), true);
         edtTPedDsc_Enabled = 0;
         AssignProp("", false, edtTPedDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedDsc_Enabled), 5, 0), true);
         cmbTPedSts.Enabled = 0;
         AssignProp("", false, cmbTPedSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTPedSts.Enabled), 5, 0), true);
         chkTPedGuia.Enabled = 0;
         AssignProp("", false, chkTPedGuia_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTPedGuia.Enabled), 5, 0), true);
         chkTPedFac.Enabled = 0;
         AssignProp("", false, chkTPedFac_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTPedFac.Enabled), 5, 0), true);
         chkTPedPer.Enabled = 0;
         AssignProp("", false, chkTPedPer_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTPedPer.Enabled), 5, 0), true);
         edtTPedMovCod_Enabled = 0;
         AssignProp("", false, edtTPedMovCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTPedMovCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3W135( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3W0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181025221", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("ctippedido.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z212TPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212TPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1931TPedDsc", StringUtil.RTrim( Z1931TPedDsc));
         GxWebStd.gx_hidden_field( context, "Z1936TPedSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1936TPedSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1933TPedGuia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1933TPedGuia), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1932TPedFac", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1932TPedFac), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1935TPedPer", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1935TPedPer), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1934TPedMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1934TPedMovCod), 6, 0, ".", "")));
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
         return formatLink("ctippedido.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CTIPPEDIDO" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Pedidos" ;
      }

      protected void InitializeNonKey3W135( )
      {
         A1931TPedDsc = "";
         AssignAttri("", false, "A1931TPedDsc", A1931TPedDsc);
         A1936TPedSts = 0;
         AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         A1933TPedGuia = 0;
         AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
         A1932TPedFac = 0;
         AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
         A1935TPedPer = 0;
         AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
         A1934TPedMovCod = 0;
         AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrimStr( (decimal)(A1934TPedMovCod), 6, 0));
         Z1931TPedDsc = "";
         Z1936TPedSts = 0;
         Z1933TPedGuia = 0;
         Z1932TPedFac = 0;
         Z1935TPedPer = 0;
         Z1934TPedMovCod = 0;
      }

      protected void InitAll3W135( )
      {
         A212TPedCod = 0;
         AssignAttri("", false, "A212TPedCod", StringUtil.LTrimStr( (decimal)(A212TPedCod), 6, 0));
         InitializeNonKey3W135( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181025228", true, true);
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
         context.AddJavascriptSource("ctippedido.js", "?20228181025228", false, true);
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
         edtTPedCod_Internalname = "TPEDCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtTPedDsc_Internalname = "TPEDDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbTPedSts_Internalname = "TPEDSTS";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         chkTPedGuia_Internalname = "TPEDGUIA";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         chkTPedFac_Internalname = "TPEDFAC";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         chkTPedPer_Internalname = "TPEDPER";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtTPedMovCod_Internalname = "TPEDMOVCOD";
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
         Form.Caption = "Tipos de Pedidos";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtTPedMovCod_Jsonclick = "";
         edtTPedMovCod_Enabled = 1;
         chkTPedPer.Enabled = 1;
         chkTPedFac.Enabled = 1;
         chkTPedGuia.Enabled = 1;
         cmbTPedSts_Jsonclick = "";
         cmbTPedSts.Enabled = 1;
         edtTPedDsc_Jsonclick = "";
         edtTPedDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtTPedCod_Jsonclick = "";
         edtTPedCod_Enabled = 1;
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
         cmbTPedSts.Name = "TPEDSTS";
         cmbTPedSts.WebTags = "";
         cmbTPedSts.addItem("1", "ACTIVO", 0);
         cmbTPedSts.addItem("0", "INACTIVO", 0);
         if ( cmbTPedSts.ItemCount > 0 )
         {
            A1936TPedSts = (short)(NumberUtil.Val( cmbTPedSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0))), "."));
            AssignAttri("", false, "A1936TPedSts", StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         }
         chkTPedGuia.Name = "TPEDGUIA";
         chkTPedGuia.WebTags = "";
         chkTPedGuia.Caption = "";
         AssignProp("", false, chkTPedGuia_Internalname, "TitleCaption", chkTPedGuia.Caption, true);
         chkTPedGuia.CheckedValue = "0";
         A1933TPedGuia = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1933TPedGuia), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1933TPedGuia", StringUtil.Str( (decimal)(A1933TPedGuia), 1, 0));
         chkTPedFac.Name = "TPEDFAC";
         chkTPedFac.WebTags = "";
         chkTPedFac.Caption = "";
         AssignProp("", false, chkTPedFac_Internalname, "TitleCaption", chkTPedFac.Caption, true);
         chkTPedFac.CheckedValue = "0";
         A1932TPedFac = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1932TPedFac), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1932TPedFac", StringUtil.Str( (decimal)(A1932TPedFac), 1, 0));
         chkTPedPer.Name = "TPEDPER";
         chkTPedPer.WebTags = "";
         chkTPedPer.Caption = "";
         AssignProp("", false, chkTPedPer_Internalname, "TitleCaption", chkTPedPer.Caption, true);
         chkTPedPer.CheckedValue = "0";
         A1935TPedPer = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1935TPedPer), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1935TPedPer", StringUtil.Str( (decimal)(A1935TPedPer), 1, 0));
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtTPedDsc_Internalname;
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

      public void Valid_Tpedcod( )
      {
         A1936TPedSts = (short)(NumberUtil.Val( cmbTPedSts.CurrentValue, "."));
         cmbTPedSts.CurrentValue = StringUtil.Str( (decimal)(A1936TPedSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbTPedSts.ItemCount > 0 )
         {
            A1936TPedSts = (short)(NumberUtil.Val( cmbTPedSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0))), "."));
            cmbTPedSts.CurrentValue = StringUtil.Str( (decimal)(A1936TPedSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTPedSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         }
         A1933TPedGuia = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1933TPedGuia), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A1932TPedFac = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1932TPedFac), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         A1935TPedPer = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1935TPedPer), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         /*  Sending validation outputs */
         AssignAttri("", false, "A1931TPedDsc", StringUtil.RTrim( A1931TPedDsc));
         AssignAttri("", false, "A1936TPedSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1936TPedSts), 1, 0, ".", "")));
         cmbTPedSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1936TPedSts), 1, 0));
         AssignProp("", false, cmbTPedSts_Internalname, "Values", cmbTPedSts.ToJavascriptSource(), true);
         AssignAttri("", false, "A1933TPedGuia", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1933TPedGuia), 1, 0, ".", "")));
         AssignAttri("", false, "A1932TPedFac", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1932TPedFac), 1, 0, ".", "")));
         AssignAttri("", false, "A1935TPedPer", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1935TPedPer), 1, 0, ".", "")));
         AssignAttri("", false, "A1934TPedMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1934TPedMovCod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z212TPedCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z212TPedCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1931TPedDsc", StringUtil.RTrim( Z1931TPedDsc));
         GxWebStd.gx_hidden_field( context, "Z1936TPedSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1936TPedSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1933TPedGuia", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1933TPedGuia), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1932TPedFac", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1932TPedFac), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1935TPedPer", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1935TPedPer), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1934TPedMovCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1934TPedMovCod), 6, 0, ".", "")));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
         setEventMetadata("VALID_TPEDCOD","{handler:'Valid_Tpedcod',iparms:[{av:'cmbTPedSts'},{av:'A1936TPedSts',fld:'TPEDSTS',pic:'9'},{av:'A212TPedCod',fld:'TPEDCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]");
         setEventMetadata("VALID_TPEDCOD",",oparms:[{av:'A1931TPedDsc',fld:'TPEDDSC',pic:''},{av:'cmbTPedSts'},{av:'A1936TPedSts',fld:'TPEDSTS',pic:'9'},{av:'A1934TPedMovCod',fld:'TPEDMOVCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z212TPedCod'},{av:'Z1931TPedDsc'},{av:'Z1936TPedSts'},{av:'Z1933TPedGuia'},{av:'Z1932TPedFac'},{av:'Z1935TPedPer'},{av:'Z1934TPedMovCod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'},{av:'A1933TPedGuia',fld:'TPEDGUIA',pic:'9'},{av:'A1932TPedFac',fld:'TPEDFAC',pic:'9'},{av:'A1935TPedPer',fld:'TPEDPER',pic:'9'}]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z1931TPedDsc = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
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
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A1931TPedDsc = "";
         lblTextblock3_Jsonclick = "";
         lblTextblock4_Jsonclick = "";
         lblTextblock5_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
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
         T003W4_A212TPedCod = new int[1] ;
         T003W4_A1931TPedDsc = new string[] {""} ;
         T003W4_A1936TPedSts = new short[1] ;
         T003W4_A1933TPedGuia = new short[1] ;
         T003W4_A1932TPedFac = new short[1] ;
         T003W4_A1935TPedPer = new short[1] ;
         T003W4_A1934TPedMovCod = new int[1] ;
         T003W5_A212TPedCod = new int[1] ;
         T003W3_A212TPedCod = new int[1] ;
         T003W3_A1931TPedDsc = new string[] {""} ;
         T003W3_A1936TPedSts = new short[1] ;
         T003W3_A1933TPedGuia = new short[1] ;
         T003W3_A1932TPedFac = new short[1] ;
         T003W3_A1935TPedPer = new short[1] ;
         T003W3_A1934TPedMovCod = new int[1] ;
         sMode135 = "";
         T003W6_A212TPedCod = new int[1] ;
         T003W7_A212TPedCod = new int[1] ;
         T003W2_A212TPedCod = new int[1] ;
         T003W2_A1931TPedDsc = new string[] {""} ;
         T003W2_A1936TPedSts = new short[1] ;
         T003W2_A1933TPedGuia = new short[1] ;
         T003W2_A1932TPedFac = new short[1] ;
         T003W2_A1935TPedPer = new short[1] ;
         T003W2_A1934TPedMovCod = new int[1] ;
         T003W11_A210PedCod = new string[] {""} ;
         T003W12_A212TPedCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1931TPedDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.ctippedido__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ctippedido__default(),
            new Object[][] {
                new Object[] {
               T003W2_A212TPedCod, T003W2_A1931TPedDsc, T003W2_A1936TPedSts, T003W2_A1933TPedGuia, T003W2_A1932TPedFac, T003W2_A1935TPedPer, T003W2_A1934TPedMovCod
               }
               , new Object[] {
               T003W3_A212TPedCod, T003W3_A1931TPedDsc, T003W3_A1936TPedSts, T003W3_A1933TPedGuia, T003W3_A1932TPedFac, T003W3_A1935TPedPer, T003W3_A1934TPedMovCod
               }
               , new Object[] {
               T003W4_A212TPedCod, T003W4_A1931TPedDsc, T003W4_A1936TPedSts, T003W4_A1933TPedGuia, T003W4_A1932TPedFac, T003W4_A1935TPedPer, T003W4_A1934TPedMovCod
               }
               , new Object[] {
               T003W5_A212TPedCod
               }
               , new Object[] {
               T003W6_A212TPedCod
               }
               , new Object[] {
               T003W7_A212TPedCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003W11_A210PedCod
               }
               , new Object[] {
               T003W12_A212TPedCod
               }
            }
         );
      }

      private short Z1936TPedSts ;
      private short Z1933TPedGuia ;
      private short Z1932TPedFac ;
      private short Z1935TPedPer ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1936TPedSts ;
      private short A1933TPedGuia ;
      private short A1932TPedFac ;
      private short A1935TPedPer ;
      private short GX_JID ;
      private short RcdFound135 ;
      private short nIsDirty_135 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1936TPedSts ;
      private short ZZ1933TPedGuia ;
      private short ZZ1932TPedFac ;
      private short ZZ1935TPedPer ;
      private int Z212TPedCod ;
      private int Z1934TPedMovCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A212TPedCod ;
      private int edtTPedCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtTPedDsc_Enabled ;
      private int A1934TPedMovCod ;
      private int edtTPedMovCod_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ212TPedCod ;
      private int ZZ1934TPedMovCod ;
      private string sPrefix ;
      private string Z1931TPedDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTPedCod_Internalname ;
      private string cmbTPedSts_Internalname ;
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
      private string edtTPedCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtTPedDsc_Internalname ;
      private string A1931TPedDsc ;
      private string edtTPedDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbTPedSts_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string chkTPedGuia_Internalname ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string chkTPedFac_Internalname ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string chkTPedPer_Internalname ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtTPedMovCod_Internalname ;
      private string edtTPedMovCod_Jsonclick ;
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
      private string sMode135 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1931TPedDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTPedSts ;
      private GXCheckbox chkTPedGuia ;
      private GXCheckbox chkTPedFac ;
      private GXCheckbox chkTPedPer ;
      private IDataStoreProvider pr_default ;
      private int[] T003W4_A212TPedCod ;
      private string[] T003W4_A1931TPedDsc ;
      private short[] T003W4_A1936TPedSts ;
      private short[] T003W4_A1933TPedGuia ;
      private short[] T003W4_A1932TPedFac ;
      private short[] T003W4_A1935TPedPer ;
      private int[] T003W4_A1934TPedMovCod ;
      private int[] T003W5_A212TPedCod ;
      private int[] T003W3_A212TPedCod ;
      private string[] T003W3_A1931TPedDsc ;
      private short[] T003W3_A1936TPedSts ;
      private short[] T003W3_A1933TPedGuia ;
      private short[] T003W3_A1932TPedFac ;
      private short[] T003W3_A1935TPedPer ;
      private int[] T003W3_A1934TPedMovCod ;
      private int[] T003W6_A212TPedCod ;
      private int[] T003W7_A212TPedCod ;
      private int[] T003W2_A212TPedCod ;
      private string[] T003W2_A1931TPedDsc ;
      private short[] T003W2_A1936TPedSts ;
      private short[] T003W2_A1933TPedGuia ;
      private short[] T003W2_A1932TPedFac ;
      private short[] T003W2_A1935TPedPer ;
      private int[] T003W2_A1934TPedMovCod ;
      private string[] T003W11_A210PedCod ;
      private int[] T003W12_A212TPedCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class ctippedido__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class ctippedido__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003W4;
        prmT003W4 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W5;
        prmT003W5 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W3;
        prmT003W3 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W6;
        prmT003W6 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W7;
        prmT003W7 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W2;
        prmT003W2 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W8;
        prmT003W8 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0) ,
        new ParDef("@TPedDsc",GXType.NChar,100,0) ,
        new ParDef("@TPedSts",GXType.Int16,1,0) ,
        new ParDef("@TPedGuia",GXType.Int16,1,0) ,
        new ParDef("@TPedFac",GXType.Int16,1,0) ,
        new ParDef("@TPedPer",GXType.Int16,1,0) ,
        new ParDef("@TPedMovCod",GXType.Int32,6,0)
        };
        Object[] prmT003W9;
        prmT003W9 = new Object[] {
        new ParDef("@TPedDsc",GXType.NChar,100,0) ,
        new ParDef("@TPedSts",GXType.Int16,1,0) ,
        new ParDef("@TPedGuia",GXType.Int16,1,0) ,
        new ParDef("@TPedFac",GXType.Int16,1,0) ,
        new ParDef("@TPedPer",GXType.Int16,1,0) ,
        new ParDef("@TPedMovCod",GXType.Int32,6,0) ,
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W10;
        prmT003W10 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W11;
        prmT003W11 = new Object[] {
        new ParDef("@TPedCod",GXType.Int32,6,0)
        };
        Object[] prmT003W12;
        prmT003W12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003W2", "SELECT [TPedCod], [TPedDsc], [TPedSts], [TPedGuia], [TPedFac], [TPedPer], [TPedMovCod] FROM [CTIPPEDIDO] WITH (UPDLOCK) WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003W2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003W3", "SELECT [TPedCod], [TPedDsc], [TPedSts], [TPedGuia], [TPedFac], [TPedPer], [TPedMovCod] FROM [CTIPPEDIDO] WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003W3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003W4", "SELECT TM1.[TPedCod], TM1.[TPedDsc], TM1.[TPedSts], TM1.[TPedGuia], TM1.[TPedFac], TM1.[TPedPer], TM1.[TPedMovCod] FROM [CTIPPEDIDO] TM1 WHERE TM1.[TPedCod] = @TPedCod ORDER BY TM1.[TPedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003W4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003W5", "SELECT [TPedCod] FROM [CTIPPEDIDO] WHERE [TPedCod] = @TPedCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003W5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003W6", "SELECT TOP 1 [TPedCod] FROM [CTIPPEDIDO] WHERE ( [TPedCod] > @TPedCod) ORDER BY [TPedCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003W6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003W7", "SELECT TOP 1 [TPedCod] FROM [CTIPPEDIDO] WHERE ( [TPedCod] < @TPedCod) ORDER BY [TPedCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003W7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003W8", "INSERT INTO [CTIPPEDIDO]([TPedCod], [TPedDsc], [TPedSts], [TPedGuia], [TPedFac], [TPedPer], [TPedMovCod]) VALUES(@TPedCod, @TPedDsc, @TPedSts, @TPedGuia, @TPedFac, @TPedPer, @TPedMovCod)", GxErrorMask.GX_NOMASK,prmT003W8)
           ,new CursorDef("T003W9", "UPDATE [CTIPPEDIDO] SET [TPedDsc]=@TPedDsc, [TPedSts]=@TPedSts, [TPedGuia]=@TPedGuia, [TPedFac]=@TPedFac, [TPedPer]=@TPedPer, [TPedMovCod]=@TPedMovCod  WHERE [TPedCod] = @TPedCod", GxErrorMask.GX_NOMASK,prmT003W9)
           ,new CursorDef("T003W10", "DELETE FROM [CTIPPEDIDO]  WHERE [TPedCod] = @TPedCod", GxErrorMask.GX_NOMASK,prmT003W10)
           ,new CursorDef("T003W11", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [TPedCod] = @TPedCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003W11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003W12", "SELECT [TPedCod] FROM [CTIPPEDIDO] ORDER BY [TPedCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003W12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((int[]) buf[6])[0] = rslt.getInt(7);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
