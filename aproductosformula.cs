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
   public class aproductosformula : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A57ProdForProdCod = GetPar( "ProdForProdCod");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A57ProdForProdCod) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
         {
            nRC_GXsfl_25 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_25"), "."));
            nGXsfl_25_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_25_idx"), "."));
            sGXsfl_25_idx = GetPar( "sGXsfl_25_idx");
            Gx_mode = GetPar( "Mode");
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxnrGrid1_newrow( ) ;
            return  ;
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
            Form.Meta.addItem("description", "Productos - Formulas", 0) ;
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

      public aproductosformula( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aproductosformula( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_APRODUCTOSFORMULA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Producto", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APRODUCTOSFORMULA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdCod_Internalname, StringUtil.RTrim( A28ProdCod), StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /*  Grid Control  */
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("Header", subGrid1_Header);
         Grid1Container.AddObjectProperty("Class", "Grid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, ".", "")));
         Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavnRcdDeleted_46_Enabled), 5, 0, ".", "")));
         Grid1Container.AddColumnProperties(Grid1Column);
         Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A57ProdForProdCod));
         Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdCod_Enabled), 5, 0, ".", "")));
         Grid1Container.AddColumnProperties(Grid1Column);
         Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A1691ProdForProdDsc));
         Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdDsc_Enabled), 5, 0, ".", "")));
         Grid1Container.AddColumnProperties(Grid1Column);
         Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
         Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A1690ProdForCant, 18, 6, ".", "")));
         Grid1Column.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForCant_Enabled), 5, 0, ".", "")));
         Grid1Container.AddColumnProperties(Grid1Column);
         Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
         Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
         Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
         Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         nGXsfl_25_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount46 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_46 = 1;
               ScanStart1C46( ) ;
               while ( RcdFound46 != 0 )
               {
                  init_level_properties46( ) ;
                  getByPrimaryKey1C46( ) ;
                  AddRow1C46( ) ;
                  ScanNext1C46( ) ;
               }
               ScanEnd1C46( ) ;
               nBlankRcdCount46 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal1C46( ) ;
            standaloneModal1C46( ) ;
            sMode46 = Gx_mode;
            while ( nGXsfl_25_idx < nRC_GXsfl_25 )
            {
               bGXsfl_25_Refreshing = true;
               ReadRow1C46( ) ;
               edtavnRcdDeleted_46_Enabled = (int)(context.localUtil.CToN( cgiGet( "vNRCDDELETED_46_"+sGXsfl_25_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtavnRcdDeleted_46_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavnRcdDeleted_46_Enabled), 5, 0), !bGXsfl_25_Refreshing);
               edtProdForProdCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODFORPRODCOD_"+sGXsfl_25_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdForProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForProdCod_Enabled), 5, 0), !bGXsfl_25_Refreshing);
               edtProdForProdDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODFORPRODDSC_"+sGXsfl_25_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdForProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForProdDsc_Enabled), 5, 0), !bGXsfl_25_Refreshing);
               edtProdForCant_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODFORCANT_"+sGXsfl_25_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdForCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForCant_Enabled), 5, 0), !bGXsfl_25_Refreshing);
               if ( ( nRcdExists_46 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal1C46( ) ;
               }
               SendRow1C46( ) ;
               bGXsfl_25_Refreshing = false;
            }
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount46 = 5;
            nRcdExists_46 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart1C46( ) ;
               while ( RcdFound46 != 0 )
               {
                  sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_2546( ) ;
                  init_level_properties46( ) ;
                  standaloneNotModal1C46( ) ;
                  getByPrimaryKey1C46( ) ;
                  standaloneModal1C46( ) ;
                  AddRow1C46( ) ;
                  ScanNext1C46( ) ;
               }
               ScanEnd1C46( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode46 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx+1), 4, 0), 4, "0");
         SubsflControlProps_2546( ) ;
         InitAll1C46( ) ;
         init_level_properties46( ) ;
         nRcdExists_46 = 0;
         nIsMod_46 = 0;
         nRcdDeleted_46 = 0;
         nBlankRcdCount46 = (short)(nBlankRcdUsr46+nBlankRcdCount46);
         fRowAdded = 0;
         while ( nBlankRcdCount46 > 0 )
         {
            standaloneNotModal1C46( ) ;
            standaloneModal1C46( ) ;
            AddRow1C46( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtProdForProdCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount46 = (short)(nBlankRcdCount46-1);
         }
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
         }
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_APRODUCTOSFORMULA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_APRODUCTOSFORMULA.htm");
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
            Z28ProdCod = cgiGet( "Z28ProdCod");
            Z906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "Z906ProdAfecICBPER"), ".", ","));
            Z907ProdValICBPER = context.localUtil.CToN( cgiGet( "Z907ProdValICBPER"), ".", ",");
            Z908ProdValICBPERD = context.localUtil.CToN( cgiGet( "Z908ProdValICBPERD"), ".", ",");
            A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "Z906ProdAfecICBPER"), ".", ","));
            A907ProdValICBPER = context.localUtil.CToN( cgiGet( "Z907ProdValICBPER"), ".", ",");
            A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "Z908ProdValICBPERD"), ".", ",");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_25 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_25"), ".", ","));
            A906ProdAfecICBPER = (short)(context.localUtil.CToN( cgiGet( "PRODAFECICBPER"), ".", ","));
            A907ProdValICBPER = context.localUtil.CToN( cgiGet( "PRODVALICBPER"), ".", ",");
            A908ProdValICBPERD = context.localUtil.CToN( cgiGet( "PRODVALICBPERD"), ".", ",");
            A1692ProdForSub = (short)(context.localUtil.CToN( cgiGet( "PRODFORSUB"), ".", ","));
            /* Read variables values. */
            A28ProdCod = StringUtil.Upper( cgiGet( edtProdCod_Internalname));
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
            forbiddenHiddens = new GXProperties();
            forbiddenHiddens.Add("hshsalt", "hsh"+"APRODUCTOSFORMULA");
            forbiddenHiddens.Add("ProdAfecICBPER", context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9"));
            forbiddenHiddens.Add("ProdValICBPER", context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99"));
            forbiddenHiddens.Add("ProdValICBPERD", context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99"));
            hsh = cgiGet( "hsh");
            if ( ( ! ( ( StringUtil.StrCmp(A28ProdCod, Z28ProdCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
            {
               GXUtil.WriteLogError("aproductosformula:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               AnyError = 1;
               return  ;
            }
            /* Check if conditions changed and reset current page numbers */
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll1C44( ) ;
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
         AssignProp("", false, edtavnRcdDeleted_46_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavnRcdDeleted_46_Enabled), 5, 0), !bGXsfl_25_Refreshing);
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
         DisableAttributes1C44( ) ;
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

      protected void CONFIRM_1C0( )
      {
         BeforeValidate1C44( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1C44( ) ;
            }
            else
            {
               CheckExtendedTable1C44( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1C44( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode44 = Gx_mode;
            CONFIRM_1C46( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode44;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1C0( ) ;
         }
      }

      protected void CONFIRM_1C46( )
      {
         nGXsfl_25_idx = 0;
         while ( nGXsfl_25_idx < nRC_GXsfl_25 )
         {
            ReadRow1C46( ) ;
            if ( ( nRcdExists_46 != 0 ) || ( nIsMod_46 != 0 ) )
            {
               GetKey1C46( ) ;
               if ( ( nRcdExists_46 == 0 ) && ( nRcdDeleted_46 == 0 ) )
               {
                  if ( RcdFound46 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate1C46( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1C46( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM1C46( 3) ;
                        }
                        CloseExtendedTableCursors1C46( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODFORPRODCOD_" + sGXsfl_25_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProdForProdCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound46 != 0 )
                  {
                     if ( nRcdDeleted_46 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey1C46( ) ;
                        Load1C46( ) ;
                        BeforeValidate1C46( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1C46( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_46 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate1C46( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1C46( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM1C46( 3) ;
                              }
                              CloseExtendedTableCursors1C46( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_46 == 0 )
                     {
                        GXCCtl = "PRODFORPRODCOD_" + sGXsfl_25_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdForProdCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtavnRcdDeleted_46_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdForProdCod_Internalname, StringUtil.RTrim( A57ProdForProdCod)) ;
            ChangePostValue( edtProdForProdDsc_Internalname, StringUtil.RTrim( A1691ProdForProdDsc)) ;
            ChangePostValue( edtProdForCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1690ProdForCant, 18, 6, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z57ProdForProdCod_"+sGXsfl_25_idx, StringUtil.RTrim( Z57ProdForProdCod)) ;
            ChangePostValue( "ZT_"+"Z1690ProdForCant_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( Z1690ProdForCant, 18, 6, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1692ProdForSub_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1692ProdForSub), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_46_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_46_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_46), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_46_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_46), 4, 0, ".", ""))) ;
            if ( nIsMod_46 != 0 )
            {
               ChangePostValue( "vNRCDDELETED_46_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavnRcdDeleted_46_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODFORPRODCOD_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODFORPRODDSC_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODFORCANT_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForCant_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption1C0( )
      {
      }

      protected void ZM1C44( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z906ProdAfecICBPER = T001C6_A906ProdAfecICBPER[0];
               Z907ProdValICBPER = T001C6_A907ProdValICBPER[0];
               Z908ProdValICBPERD = T001C6_A908ProdValICBPERD[0];
            }
            else
            {
               Z906ProdAfecICBPER = A906ProdAfecICBPER;
               Z907ProdValICBPER = A907ProdValICBPER;
               Z908ProdValICBPERD = A908ProdValICBPERD;
            }
         }
         if ( GX_JID == -1 )
         {
            Z28ProdCod = A28ProdCod;
            Z906ProdAfecICBPER = A906ProdAfecICBPER;
            Z907ProdValICBPER = A907ProdValICBPER;
            Z908ProdValICBPERD = A908ProdValICBPERD;
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

      protected void Load1C44( )
      {
         /* Using cursor T001C7 */
         pr_default.execute(5, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound44 = 1;
            A906ProdAfecICBPER = T001C7_A906ProdAfecICBPER[0];
            A907ProdValICBPER = T001C7_A907ProdValICBPER[0];
            A908ProdValICBPERD = T001C7_A908ProdValICBPERD[0];
            ZM1C44( -1) ;
         }
         pr_default.close(5);
         OnLoadActions1C44( ) ;
      }

      protected void OnLoadActions1C44( )
      {
      }

      protected void CheckExtendedTable1C44( )
      {
         nIsDirty_44 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1C44( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1C44( )
      {
         /* Using cursor T001C8 */
         pr_default.execute(6, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001C6 */
         pr_default.execute(4, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM1C44( 1) ;
            RcdFound44 = 1;
            A28ProdCod = T001C6_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
            A906ProdAfecICBPER = T001C6_A906ProdAfecICBPER[0];
            A907ProdValICBPER = T001C6_A907ProdValICBPER[0];
            A908ProdValICBPERD = T001C6_A908ProdValICBPERD[0];
            Z28ProdCod = A28ProdCod;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1C44( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1C44( ) ;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1C44( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey1C44( ) ;
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
         /* Using cursor T001C9 */
         pr_default.execute(7, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T001C9_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T001C9_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               A28ProdCod = T001C9_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound44 = 0;
         /* Using cursor T001C10 */
         pr_default.execute(8, new Object[] {A28ProdCod});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001C10_A28ProdCod[0], A28ProdCod) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T001C10_A28ProdCod[0], A28ProdCod) < 0 ) ) )
            {
               A28ProdCod = T001C10_A28ProdCod[0];
               AssignAttri("", false, "A28ProdCod", A28ProdCod);
               RcdFound44 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1C44( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1C44( ) ;
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
                  Update1C44( ) ;
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
                  Insert1C44( ) ;
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
                     Insert1C44( ) ;
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
         GetKey1C44( ) ;
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
         pr_default.close(4);
         pr_default.close(3);
         pr_default.close(1);
         pr_default.close(0);
         pr_default.close(2);
         context.RollbackDataStores("aproductosformula",pr_default);
      }

      protected void insert_Check( )
      {
         CONFIRM_1C0( ) ;
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
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1C44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1C44( ) ;
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
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1C44( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound44 != 0 )
            {
               ScanNext1C44( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         ScanEnd1C44( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1C44( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001C5 */
            pr_default.execute(3, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( Z906ProdAfecICBPER != T001C5_A906ProdAfecICBPER[0] ) || ( Z907ProdValICBPER != T001C5_A907ProdValICBPER[0] ) || ( Z908ProdValICBPERD != T001C5_A908ProdValICBPERD[0] ) )
            {
               if ( Z906ProdAfecICBPER != T001C5_A906ProdAfecICBPER[0] )
               {
                  GXUtil.WriteLog("aproductosformula:[seudo value changed for attri]"+"ProdAfecICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z906ProdAfecICBPER);
                  GXUtil.WriteLogRaw("Current: ",T001C5_A906ProdAfecICBPER[0]);
               }
               if ( Z907ProdValICBPER != T001C5_A907ProdValICBPER[0] )
               {
                  GXUtil.WriteLog("aproductosformula:[seudo value changed for attri]"+"ProdValICBPER");
                  GXUtil.WriteLogRaw("Old: ",Z907ProdValICBPER);
                  GXUtil.WriteLogRaw("Current: ",T001C5_A907ProdValICBPER[0]);
               }
               if ( Z908ProdValICBPERD != T001C5_A908ProdValICBPERD[0] )
               {
                  GXUtil.WriteLog("aproductosformula:[seudo value changed for attri]"+"ProdValICBPERD");
                  GXUtil.WriteLogRaw("Old: ",Z908ProdValICBPERD);
                  GXUtil.WriteLogRaw("Current: ",T001C5_A908ProdValICBPERD[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"APRODUCTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C44( )
      {
         BeforeValidate1C44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C44( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C44( 0) ;
            CheckOptimisticConcurrency1C44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C11 */
                     pr_default.execute(9, new Object[] {A28ProdCod, A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel1C44( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption1C0( ) ;
                           }
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
               Load1C44( ) ;
            }
            EndLevel1C44( ) ;
         }
         CloseExtendedTableCursors1C44( ) ;
      }

      protected void Update1C44( )
      {
         BeforeValidate1C44( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C44( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C44( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C44( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1C44( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C12 */
                     pr_default.execute(10, new Object[] {A906ProdAfecICBPER, A907ProdValICBPER, A908ProdValICBPERD, A28ProdCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOS");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1C44( ) ;
                     if ( AnyError == 0 )
                     {
                        new aproductosupdateredundancy(context ).execute( ref  A28ProdCod) ;
                        AssignAttri("", false, "A28ProdCod", A28ProdCod);
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1C44( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption1C0( ) ;
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
            }
            EndLevel1C44( ) ;
         }
         CloseExtendedTableCursors1C44( ) ;
      }

      protected void DeferredUpdate1C44( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1C44( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C44( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C44( ) ;
            AfterConfirm1C44( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C44( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart1C46( ) ;
                  while ( RcdFound46 != 0 )
                  {
                     getByPrimaryKey1C46( ) ;
                     Delete1C46( ) ;
                     ScanNext1C46( ) ;
                  }
                  ScanEnd1C46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C13 */
                     pr_default.execute(11, new Object[] {A28ProdCod});
                     pr_default.close(11);
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
                              InitAll1C44( ) ;
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
                           ResetCaption1C0( ) ;
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
         }
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1C44( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1C44( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001C14 */
            pr_default.execute(12, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Materias Primas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T001C15 */
            pr_default.execute(13, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Gastos de Fabricación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T001C16 */
            pr_default.execute(14, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POSERVICIODET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T001C17 */
            pr_default.execute(15, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Orden de Servicio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T001C18 */
            pr_default.execute(16, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Plan de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T001C19 */
            pr_default.execute(17, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T001C20 */
            pr_default.execute(18, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Ordenes de Producción"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T001C21 */
            pr_default.execute(19, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZADET"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T001C22 */
            pr_default.execute(20, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCOTIZA"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T001C23 */
            pr_default.execute(21, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Sabana de Compras "}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T001C24 */
            pr_default.execute(22, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Historico de Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T001C25 */
            pr_default.execute(23, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T001C26 */
            pr_default.execute(24, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Compras - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T001C27 */
            pr_default.execute(25, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T001C28 */
            pr_default.execute(26, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Detalle Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T001C29 */
            pr_default.execute(27, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CBONIFICACION"+" ("+"Sub Producto Bonificacion"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T001C30 */
            pr_default.execute(28, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Saldo Mensual de Costos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T001C31 */
            pr_default.execute(29, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Descuentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T001C32 */
            pr_default.execute(30, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle Orden de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T001C33 */
            pr_default.execute(31, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Ventas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T001C34 */
            pr_default.execute(32, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T001C35 */
            pr_default.execute(33, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T001C36 */
            pr_default.execute(34, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T001C37 */
            pr_default.execute(35, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
            /* Using cursor T001C38 */
            pr_default.execute(36, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(36) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov Almacen Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(36);
            /* Using cursor T001C39 */
            pr_default.execute(37, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(37) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLPEDIDOSDETLOTE"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(37);
            /* Using cursor T001C40 */
            pr_default.execute(38, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(38) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Stock Actual"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(38);
            /* Using cursor T001C41 */
            pr_default.execute(39, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(39) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos Unidades de Medida"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(39);
            /* Using cursor T001C42 */
            pr_default.execute(40, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(40) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Formula de Productos"+" ("+"Producto en Formula"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(40);
            /* Using cursor T001C43 */
            pr_default.execute(41, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(41) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"+" ("+"Productos Equivalentes"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(41);
            /* Using cursor T001C44 */
            pr_default.execute(42, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(42) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Producto Equivalente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(42);
            /* Using cursor T001C45 */
            pr_default.execute(43, new Object[] {A28ProdCod});
            if ( (pr_default.getStatus(43) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Seguimiento de Consignacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(43);
         }
      }

      protected void ProcessNestedLevel1C46( )
      {
         nGXsfl_25_idx = 0;
         while ( nGXsfl_25_idx < nRC_GXsfl_25 )
         {
            ReadRow1C46( ) ;
            if ( ( nRcdExists_46 != 0 ) || ( nIsMod_46 != 0 ) )
            {
               standaloneNotModal1C46( ) ;
               GetKey1C46( ) ;
               if ( ( nRcdExists_46 == 0 ) && ( nRcdDeleted_46 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert1C46( ) ;
               }
               else
               {
                  if ( RcdFound46 != 0 )
                  {
                     if ( ( nRcdDeleted_46 != 0 ) && ( nRcdExists_46 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete1C46( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_46 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update1C46( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_46 == 0 )
                     {
                        GXCCtl = "PRODFORPRODCOD_" + sGXsfl_25_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdForProdCod_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtavnRcdDeleted_46_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdForProdCod_Internalname, StringUtil.RTrim( A57ProdForProdCod)) ;
            ChangePostValue( edtProdForProdDsc_Internalname, StringUtil.RTrim( A1691ProdForProdDsc)) ;
            ChangePostValue( edtProdForCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A1690ProdForCant, 18, 6, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z57ProdForProdCod_"+sGXsfl_25_idx, StringUtil.RTrim( Z57ProdForProdCod)) ;
            ChangePostValue( "ZT_"+"Z1690ProdForCant_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( Z1690ProdForCant, 18, 6, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z1692ProdForSub_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1692ProdForSub), 1, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_46_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_46_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_46), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_46_"+sGXsfl_25_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_46), 4, 0, ".", ""))) ;
            if ( nIsMod_46 != 0 )
            {
               ChangePostValue( "vNRCDDELETED_46_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavnRcdDeleted_46_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODFORPRODCOD_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdCod_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODFORPRODDSC_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdDsc_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODFORCANT_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForCant_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1C46( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_46 = 0;
         nIsMod_46 = 0;
         nRcdDeleted_46 = 0;
      }

      protected void ProcessLevel1C44( )
      {
         /* Save parent mode. */
         sMode44 = Gx_mode;
         ProcessNestedLevel1C46( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel1C44( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1C44( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("aproductosformula",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("aproductosformula",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1C44( )
      {
         /* Using cursor T001C46 */
         pr_default.execute(44);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T001C46_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1C44( )
      {
         /* Scan next routine */
         pr_default.readNext(44);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(44) != 101) )
         {
            RcdFound44 = 1;
            A28ProdCod = T001C46_A28ProdCod[0];
            AssignAttri("", false, "A28ProdCod", A28ProdCod);
         }
      }

      protected void ScanEnd1C44( )
      {
         pr_default.close(44);
      }

      protected void AfterConfirm1C44( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C44( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C44( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C44( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C44( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C44( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C44( )
      {
         edtProdCod_Enabled = 0;
         AssignProp("", false, edtProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdCod_Enabled), 5, 0), true);
      }

      protected void ZM1C46( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1690ProdForCant = T001C3_A1690ProdForCant[0];
               Z1692ProdForSub = T001C3_A1692ProdForSub[0];
            }
            else
            {
               Z1690ProdForCant = A1690ProdForCant;
               Z1692ProdForSub = A1692ProdForSub;
            }
         }
         if ( GX_JID == -2 )
         {
            Z28ProdCod = A28ProdCod;
            Z1690ProdForCant = A1690ProdForCant;
            Z1692ProdForSub = A1692ProdForSub;
            Z57ProdForProdCod = A57ProdForProdCod;
            Z1691ProdForProdDsc = A1691ProdForProdDsc;
         }
      }

      protected void standaloneNotModal1C46( )
      {
      }

      protected void standaloneModal1C46( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProdForProdCod_Enabled = 0;
            AssignProp("", false, edtProdForProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForProdCod_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         }
         else
         {
            edtProdForProdCod_Enabled = 1;
            AssignProp("", false, edtProdForProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForProdCod_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         }
      }

      protected void Load1C46( )
      {
         /* Using cursor T001C47 */
         pr_default.execute(45, new Object[] {A28ProdCod, A57ProdForProdCod});
         if ( (pr_default.getStatus(45) != 101) )
         {
            RcdFound46 = 1;
            A1691ProdForProdDsc = T001C47_A1691ProdForProdDsc[0];
            A1690ProdForCant = T001C47_A1690ProdForCant[0];
            A1692ProdForSub = T001C47_A1692ProdForSub[0];
            ZM1C46( -2) ;
         }
         pr_default.close(45);
         OnLoadActions1C46( ) ;
      }

      protected void OnLoadActions1C46( )
      {
      }

      protected void CheckExtendedTable1C46( )
      {
         nIsDirty_46 = 0;
         Gx_BScreen = 1;
         standaloneModal1C46( ) ;
         /* Using cursor T001C4 */
         pr_default.execute(2, new Object[] {A57ProdForProdCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODFORPRODCOD_" + sGXsfl_25_idx;
            GX_msglist.addItem("No existe 'Producto en Formula'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdForProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1691ProdForProdDsc = T001C4_A1691ProdForProdDsc[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1C46( )
      {
         pr_default.close(2);
      }

      protected void enableDisable1C46( )
      {
      }

      protected void gxLoad_3( string A57ProdForProdCod )
      {
         /* Using cursor T001C48 */
         pr_default.execute(46, new Object[] {A57ProdForProdCod});
         if ( (pr_default.getStatus(46) == 101) )
         {
            GXCCtl = "PRODFORPRODCOD_" + sGXsfl_25_idx;
            GX_msglist.addItem("No existe 'Producto en Formula'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdForProdCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A1691ProdForProdDsc = T001C48_A1691ProdForProdDsc[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A1691ProdForProdDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(46) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(46);
      }

      protected void GetKey1C46( )
      {
         /* Using cursor T001C49 */
         pr_default.execute(47, new Object[] {A28ProdCod, A57ProdForProdCod});
         if ( (pr_default.getStatus(47) != 101) )
         {
            RcdFound46 = 1;
         }
         else
         {
            RcdFound46 = 0;
         }
         pr_default.close(47);
      }

      protected void getByPrimaryKey1C46( )
      {
         /* Using cursor T001C3 */
         pr_default.execute(1, new Object[] {A28ProdCod, A57ProdForProdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1C46( 2) ;
            RcdFound46 = 1;
            InitializeNonKey1C46( ) ;
            A1690ProdForCant = T001C3_A1690ProdForCant[0];
            A1692ProdForSub = T001C3_A1692ProdForSub[0];
            A57ProdForProdCod = T001C3_A57ProdForProdCod[0];
            Z28ProdCod = A28ProdCod;
            Z57ProdForProdCod = A57ProdForProdCod;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1C46( ) ;
            Load1C46( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound46 = 0;
            InitializeNonKey1C46( ) ;
            sMode46 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal1C46( ) ;
            Gx_mode = sMode46;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1C46( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1C46( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001C2 */
            pr_default.execute(0, new Object[] {A28ProdCod, A57ProdForProdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOSFORMULA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1690ProdForCant != T001C2_A1690ProdForCant[0] ) || ( Z1692ProdForSub != T001C2_A1692ProdForSub[0] ) )
            {
               if ( Z1690ProdForCant != T001C2_A1690ProdForCant[0] )
               {
                  GXUtil.WriteLog("aproductosformula:[seudo value changed for attri]"+"ProdForCant");
                  GXUtil.WriteLogRaw("Old: ",Z1690ProdForCant);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A1690ProdForCant[0]);
               }
               if ( Z1692ProdForSub != T001C2_A1692ProdForSub[0] )
               {
                  GXUtil.WriteLog("aproductosformula:[seudo value changed for attri]"+"ProdForSub");
                  GXUtil.WriteLogRaw("Old: ",Z1692ProdForSub);
                  GXUtil.WriteLogRaw("Current: ",T001C2_A1692ProdForSub[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"APRODUCTOSFORMULA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1C46( )
      {
         BeforeValidate1C46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C46( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1C46( 0) ;
            CheckOptimisticConcurrency1C46( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1C46( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1C46( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001C50 */
                     pr_default.execute(48, new Object[] {A28ProdCod, A1690ProdForCant, A1692ProdForSub, A57ProdForProdCod});
                     pr_default.close(48);
                     dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOSFORMULA");
                     if ( (pr_default.getStatus(48) == 1) )
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
               Load1C46( ) ;
            }
            EndLevel1C46( ) ;
         }
         CloseExtendedTableCursors1C46( ) ;
      }

      protected void Update1C46( )
      {
         BeforeValidate1C46( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1C46( ) ;
         }
         if ( ( nIsMod_46 != 0 ) || ( nIsDirty_46 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency1C46( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm1C46( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate1C46( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T001C51 */
                        pr_default.execute(49, new Object[] {A1690ProdForCant, A1692ProdForSub, A28ProdCod, A57ProdForProdCod});
                        pr_default.close(49);
                        dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOSFORMULA");
                        if ( (pr_default.getStatus(49) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APRODUCTOSFORMULA"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate1C46( ) ;
                        if ( AnyError == 0 )
                        {
                           new aproductosupdateredundancy(context ).execute( ref  A28ProdCod) ;
                           AssignAttri("", false, "A28ProdCod", A28ProdCod);
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey1C46( ) ;
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
               EndLevel1C46( ) ;
            }
         }
         CloseExtendedTableCursors1C46( ) ;
      }

      protected void DeferredUpdate1C46( )
      {
      }

      protected void Delete1C46( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1C46( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1C46( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1C46( ) ;
            AfterConfirm1C46( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1C46( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001C52 */
                  pr_default.execute(50, new Object[] {A28ProdCod, A57ProdForProdCod});
                  pr_default.close(50);
                  dsDefault.SmartCacheProvider.SetUpdated("APRODUCTOSFORMULA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode46 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1C46( ) ;
         Gx_mode = sMode46;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1C46( )
      {
         standaloneModal1C46( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001C53 */
            pr_default.execute(51, new Object[] {A57ProdForProdCod});
            A1691ProdForProdDsc = T001C53_A1691ProdForProdDsc[0];
            pr_default.close(51);
         }
      }

      protected void EndLevel1C46( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1C46( )
      {
         /* Scan By routine */
         /* Using cursor T001C54 */
         pr_default.execute(52, new Object[] {A28ProdCod});
         RcdFound46 = 0;
         if ( (pr_default.getStatus(52) != 101) )
         {
            RcdFound46 = 1;
            A57ProdForProdCod = T001C54_A57ProdForProdCod[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1C46( )
      {
         /* Scan next routine */
         pr_default.readNext(52);
         RcdFound46 = 0;
         if ( (pr_default.getStatus(52) != 101) )
         {
            RcdFound46 = 1;
            A57ProdForProdCod = T001C54_A57ProdForProdCod[0];
         }
      }

      protected void ScanEnd1C46( )
      {
         pr_default.close(52);
      }

      protected void AfterConfirm1C46( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1C46( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1C46( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1C46( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1C46( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1C46( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1C46( )
      {
         edtProdForProdCod_Enabled = 0;
         AssignProp("", false, edtProdForProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForProdCod_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtProdForProdDsc_Enabled = 0;
         AssignProp("", false, edtProdForProdDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForProdDsc_Enabled), 5, 0), !bGXsfl_25_Refreshing);
         edtProdForCant_Enabled = 0;
         AssignProp("", false, edtProdForCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForCant_Enabled), 5, 0), !bGXsfl_25_Refreshing);
      }

      protected void send_integrity_lvl_hashes1C46( )
      {
      }

      protected void send_integrity_lvl_hashes1C44( )
      {
      }

      protected void SubsflControlProps_2546( )
      {
         edtavnRcdDeleted_46_Internalname = "vNRCDDELETED_46_"+sGXsfl_25_idx;
         edtProdForProdCod_Internalname = "PRODFORPRODCOD_"+sGXsfl_25_idx;
         edtProdForProdDsc_Internalname = "PRODFORPRODDSC_"+sGXsfl_25_idx;
         edtProdForCant_Internalname = "PRODFORCANT_"+sGXsfl_25_idx;
      }

      protected void SubsflControlProps_fel_2546( )
      {
         edtavnRcdDeleted_46_Internalname = "vNRCDDELETED_46_"+sGXsfl_25_fel_idx;
         edtProdForProdCod_Internalname = "PRODFORPRODCOD_"+sGXsfl_25_fel_idx;
         edtProdForProdDsc_Internalname = "PRODFORPRODDSC_"+sGXsfl_25_fel_idx;
         edtProdForCant_Internalname = "PRODFORCANT_"+sGXsfl_25_fel_idx;
      }

      protected void AddRow1C46( )
      {
         nGXsfl_25_idx = (int)(nGXsfl_25_idx+1);
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_2546( ) ;
         SendRow1C46( ) ;
      }

      protected void SendRow1C46( )
      {
         Grid1Row = GXWebRow.GetNew(context);
         if ( subGrid1_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid1_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
         }
         else if ( subGrid1_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid1_Backstyle = 0;
            subGrid1_Backcolor = subGrid1_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Uniform";
            }
         }
         else if ( subGrid1_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
            {
               subGrid1_Linesclass = subGrid1_Class+"Odd";
            }
            subGrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_25_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_25_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_25_idx + "',25)\"";
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavnRcdDeleted_46_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, ".", "")),StringUtil.LTrim( ((edtavnRcdDeleted_46_Enabled!=0) ? context.localUtil.Format( (decimal)(nRcdDeleted_46), "9999") : context.localUtil.Format( (decimal)(nRcdDeleted_46), "9999")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,26);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavnRcdDeleted_46_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtavnRcdDeleted_46_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_25_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 27,'',false,'" + sGXsfl_25_idx + "',25)\"";
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdForProdCod_Internalname,StringUtil.RTrim( A57ProdForProdCod),StringUtil.RTrim( context.localUtil.Format( A57ProdForProdCod, "@!")),TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdForProdCod_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdForProdCod_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdForProdDsc_Internalname,StringUtil.RTrim( A1691ProdForProdDsc),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdForProdDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdForProdDsc_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_46_" + sGXsfl_25_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 29,'',false,'" + sGXsfl_25_idx + "',25)\"";
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdForCant_Internalname,StringUtil.LTrim( StringUtil.NToC( A1690ProdForCant, 18, 6, ".", "")),StringUtil.LTrim( ((edtProdForCant_Enabled!=0) ? context.localUtil.Format( A1690ProdForCant, "ZZZZZZZZZZ9.999999") : context.localUtil.Format( A1690ProdForCant, "ZZZZZZZZZZ9.999999"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,29);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdForCant_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdForCant_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)25,(short)1,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Grid1Row);
         send_integrity_lvl_hashes1C46( ) ;
         GXCCtl = "Z57ProdForProdCod_" + sGXsfl_25_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z57ProdForProdCod));
         GXCCtl = "Z1690ProdForCant_" + sGXsfl_25_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z1690ProdForCant, 18, 6, ".", "")));
         GXCCtl = "Z1692ProdForSub_" + sGXsfl_25_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1692ProdForSub), 1, 0, ".", "")));
         GXCCtl = "nRcdDeleted_46_" + sGXsfl_25_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_46), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_46_" + sGXsfl_25_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_46), 4, 0, ".", "")));
         GXCCtl = "nIsMod_46_" + sGXsfl_25_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_46), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vNRCDDELETED_46_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavnRcdDeleted_46_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODFORPRODCOD_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdCod_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODFORPRODDSC_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForProdDsc_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODFORCANT_"+sGXsfl_25_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdForCant_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Grid1Container.AddRow(Grid1Row);
      }

      protected void ReadRow1C46( )
      {
         nGXsfl_25_idx = (int)(nGXsfl_25_idx+1);
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_2546( ) ;
         edtavnRcdDeleted_46_Enabled = (int)(context.localUtil.CToN( cgiGet( "vNRCDDELETED_46_"+sGXsfl_25_idx+"Enabled"), ".", ","));
         edtProdForProdCod_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODFORPRODCOD_"+sGXsfl_25_idx+"Enabled"), ".", ","));
         edtProdForProdDsc_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODFORPRODDSC_"+sGXsfl_25_idx+"Enabled"), ".", ","));
         edtProdForCant_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODFORCANT_"+sGXsfl_25_idx+"Enabled"), ".", ","));
         if ( ( ( context.localUtil.CToN( cgiGet( edtavnRcdDeleted_46_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavnRcdDeleted_46_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vNRCDDELETED_46");
            AnyError = 1;
            GX_FocusControl = edtavnRcdDeleted_46_Internalname;
            wbErr = true;
            nRcdDeleted_46 = 0;
         }
         else
         {
            nRcdDeleted_46 = (short)(context.localUtil.CToN( cgiGet( edtavnRcdDeleted_46_Internalname), ".", ","));
         }
         A57ProdForProdCod = StringUtil.Upper( cgiGet( edtProdForProdCod_Internalname));
         A1691ProdForProdDsc = cgiGet( edtProdForProdDsc_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtProdForCant_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdForCant_Internalname), ".", ",") > 99999999999.999999m ) ) )
         {
            GXCCtl = "PRODFORCANT_" + sGXsfl_25_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdForCant_Internalname;
            wbErr = true;
            A1690ProdForCant = 0;
         }
         else
         {
            A1690ProdForCant = context.localUtil.CToN( cgiGet( edtProdForCant_Internalname), ".", ",");
         }
         GXCCtl = "Z57ProdForProdCod_" + sGXsfl_25_idx;
         Z57ProdForProdCod = cgiGet( GXCCtl);
         GXCCtl = "Z1690ProdForCant_" + sGXsfl_25_idx;
         Z1690ProdForCant = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "Z1692ProdForSub_" + sGXsfl_25_idx;
         Z1692ProdForSub = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z1692ProdForSub_" + sGXsfl_25_idx;
         A1692ProdForSub = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_46_" + sGXsfl_25_idx;
         nRcdDeleted_46 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_46_" + sGXsfl_25_idx;
         nRcdExists_46 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_46_" + sGXsfl_25_idx;
         nIsMod_46 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtProdForProdCod_Enabled = edtProdForProdCod_Enabled;
      }

      protected void ConfirmValues1C0( )
      {
         nGXsfl_25_idx = 0;
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
         SubsflControlProps_2546( ) ;
         while ( nGXsfl_25_idx < nRC_GXsfl_25 )
         {
            nGXsfl_25_idx = (int)(nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_2546( ) ;
            ChangePostValue( "Z57ProdForProdCod_"+sGXsfl_25_idx, cgiGet( "ZT_"+"Z57ProdForProdCod_"+sGXsfl_25_idx)) ;
            DeletePostValue( "ZT_"+"Z57ProdForProdCod_"+sGXsfl_25_idx) ;
            ChangePostValue( "Z1690ProdForCant_"+sGXsfl_25_idx, cgiGet( "ZT_"+"Z1690ProdForCant_"+sGXsfl_25_idx)) ;
            DeletePostValue( "ZT_"+"Z1690ProdForCant_"+sGXsfl_25_idx) ;
            ChangePostValue( "Z1692ProdForSub_"+sGXsfl_25_idx, cgiGet( "ZT_"+"Z1692ProdForSub_"+sGXsfl_25_idx)) ;
            DeletePostValue( "ZT_"+"Z1692ProdForSub_"+sGXsfl_25_idx) ;
         }
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
         context.AddJavascriptSource("gxcfg.js", "?202281810235492", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aproductosformula.aspx") +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"APRODUCTOSFORMULA");
         forbiddenHiddens.Add("ProdAfecICBPER", context.localUtil.Format( (decimal)(A906ProdAfecICBPER), "9"));
         forbiddenHiddens.Add("ProdValICBPER", context.localUtil.Format( A907ProdValICBPER, "ZZZZZZ,ZZZ,ZZ9.99"));
         forbiddenHiddens.Add("ProdValICBPERD", context.localUtil.Format( A908ProdValICBPERD, "ZZZZZZ,ZZZ,ZZ9.99"));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("aproductosformula:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_25", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_25_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODAFECICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODVALICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODFORSUB", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1692ProdForSub), 1, 0, ".", "")));
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
         return formatLink("aproductosformula.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "APRODUCTOSFORMULA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Productos - Formulas" ;
      }

      protected void InitializeNonKey1C44( )
      {
         A906ProdAfecICBPER = 0;
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.Str( (decimal)(A906ProdAfecICBPER), 1, 0));
         A907ProdValICBPER = 0;
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrimStr( A907ProdValICBPER, 15, 2));
         A908ProdValICBPERD = 0;
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrimStr( A908ProdValICBPERD, 15, 2));
         Z906ProdAfecICBPER = 0;
         Z907ProdValICBPER = 0;
         Z908ProdValICBPERD = 0;
      }

      protected void InitAll1C44( )
      {
         A28ProdCod = "";
         AssignAttri("", false, "A28ProdCod", A28ProdCod);
         InitializeNonKey1C44( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey1C46( )
      {
         A1691ProdForProdDsc = "";
         A1690ProdForCant = 0;
         A1692ProdForSub = 0;
         AssignAttri("", false, "A1692ProdForSub", StringUtil.Str( (decimal)(A1692ProdForSub), 1, 0));
         Z1690ProdForCant = 0;
         Z1692ProdForSub = 0;
      }

      protected void InitAll1C46( )
      {
         A57ProdForProdCod = "";
         InitializeNonKey1C46( ) ;
      }

      protected void StandaloneModalInsert1C46( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181023551", true, true);
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
         context.AddJavascriptSource("aproductosformula.js", "?20228181023551", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties46( )
      {
         edtProdForProdCod_Enabled = defedtProdForProdCod_Enabled;
         AssignProp("", false, edtProdForProdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdForProdCod_Enabled), 5, 0), !bGXsfl_25_Refreshing);
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
         edtavnRcdDeleted_46_Internalname = "vNRCDDELETED_46";
         edtProdForProdCod_Internalname = "PRODFORPRODCOD";
         edtProdForProdDsc_Internalname = "PRODFORPRODDSC";
         edtProdForCant_Internalname = "PRODFORCANT";
         tblTable2_Internalname = "TABLE2";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_check_Internalname = "BTN_CHECK";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         bttBtn_help_Internalname = "BTN_HELP";
         tblTable1_Internalname = "TABLE1";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
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
         Form.Caption = "Productos - Formulas";
         edtProdForCant_Jsonclick = "";
         edtProdForProdDsc_Jsonclick = "";
         edtProdForProdCod_Jsonclick = "";
         edtavnRcdDeleted_46_Jsonclick = "";
         subGrid1_Class = "Grid";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         edtProdForCant_Enabled = 1;
         edtProdForProdDsc_Enabled = 0;
         edtProdForProdCod_Enabled = 1;
         edtavnRcdDeleted_46_Enabled = 1;
         subGrid1_Backcolorstyle = 2;
         subGrid1_Header = "";
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

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_2546( ) ;
         while ( nGXsfl_25_idx <= nRC_GXsfl_25 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal1C46( ) ;
            standaloneModal1C46( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow1C46( ) ;
            nGXsfl_25_idx = (int)(nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0");
            SubsflControlProps_2546( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
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
         if ( AnyError == 0 )
         {
            GX_FocusControl = "";
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
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
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(A906ProdAfecICBPER), 1, 0, ".", "")));
         AssignAttri("", false, "A907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( A907ProdValICBPER, 15, 2, ".", "")));
         AssignAttri("", false, "A908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( A908ProdValICBPERD, 15, 2, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z28ProdCod", StringUtil.RTrim( Z28ProdCod));
         GxWebStd.gx_hidden_field( context, "Z906ProdAfecICBPER", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z906ProdAfecICBPER), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z907ProdValICBPER", StringUtil.LTrim( StringUtil.NToC( Z907ProdValICBPER, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z908ProdValICBPERD", StringUtil.LTrim( StringUtil.NToC( Z908ProdValICBPERD, 15, 2, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Prodforprodcod( )
      {
         /* Using cursor T001C53 */
         pr_default.execute(51, new Object[] {A57ProdForProdCod});
         if ( (pr_default.getStatus(51) == 101) )
         {
            GX_msglist.addItem("No existe 'Producto en Formula'.", "ForeignKeyNotFound", 1, "PRODFORPRODCOD");
            AnyError = 1;
            GX_FocusControl = edtProdForProdCod_Internalname;
         }
         A1691ProdForProdDsc = T001C53_A1691ProdForProdDsc[0];
         pr_default.close(51);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1691ProdForProdDsc", StringUtil.RTrim( A1691ProdForProdDsc));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_PRODCOD","{handler:'Valid_Prodcod',iparms:[{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A28ProdCod',fld:'PRODCOD',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PRODCOD",",oparms:[{av:'A906ProdAfecICBPER',fld:'PRODAFECICBPER',pic:'9'},{av:'A907ProdValICBPER',fld:'PRODVALICBPER',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A908ProdValICBPERD',fld:'PRODVALICBPERD',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z28ProdCod'},{av:'Z906ProdAfecICBPER'},{av:'Z907ProdValICBPER'},{av:'Z908ProdValICBPERD'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_PRODFORPRODCOD","{handler:'Valid_Prodforprodcod',iparms:[{av:'A57ProdForProdCod',fld:'PRODFORPRODCOD',pic:'@!'},{av:'A1691ProdForProdDsc',fld:'PRODFORPRODDSC',pic:''}]");
         setEventMetadata("VALID_PRODFORPRODCOD",",oparms:[{av:'A1691ProdForProdDsc',fld:'PRODFORPRODDSC',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Prodforcant',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(51);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z28ProdCod = "";
         Z57ProdForProdCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A57ProdForProdCod = "";
         Gx_mode = "";
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
         A28ProdCod = "";
         bttBtn_get_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         Grid1Column = new GXWebColumn();
         A1691ProdForProdDsc = "";
         sMode46 = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_check_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         bttBtn_help_Jsonclick = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode44 = "";
         GXCCtl = "";
         T001C7_A28ProdCod = new string[] {""} ;
         T001C7_A906ProdAfecICBPER = new short[1] ;
         T001C7_A907ProdValICBPER = new decimal[1] ;
         T001C7_A908ProdValICBPERD = new decimal[1] ;
         T001C8_A28ProdCod = new string[] {""} ;
         T001C6_A28ProdCod = new string[] {""} ;
         T001C6_A906ProdAfecICBPER = new short[1] ;
         T001C6_A907ProdValICBPER = new decimal[1] ;
         T001C6_A908ProdValICBPERD = new decimal[1] ;
         T001C9_A28ProdCod = new string[] {""} ;
         T001C10_A28ProdCod = new string[] {""} ;
         T001C5_A28ProdCod = new string[] {""} ;
         T001C5_A906ProdAfecICBPER = new short[1] ;
         T001C5_A907ProdValICBPER = new decimal[1] ;
         T001C5_A908ProdValICBPERD = new decimal[1] ;
         T001C14_A2385ProCosProdCod = new string[] {""} ;
         T001C15_A2382ProGasProdCod = new string[] {""} ;
         T001C16_A329PSerCod = new string[] {""} ;
         T001C16_A335PSerDItem = new int[1] ;
         T001C17_A329PSerCod = new string[] {""} ;
         T001C18_A324ProPlanCod = new string[] {""} ;
         T001C18_A331ProPlanDProdCod = new string[] {""} ;
         T001C19_A322ProCod = new string[] {""} ;
         T001C19_A326ProDItem = new int[1] ;
         T001C20_A322ProCod = new string[] {""} ;
         T001C21_A317ProCotProdCod = new string[] {""} ;
         T001C21_A318ProCotItem = new int[1] ;
         T001C22_A317ProCotProdCod = new string[] {""} ;
         T001C23_A310Iesa_SabPedCod = new string[] {""} ;
         T001C23_A311Iesa_SabProdSec = new int[1] ;
         T001C23_A312Iesa_SabProdCod = new string[] {""} ;
         T001C24_A286CPLisHisProdCod = new string[] {""} ;
         T001C24_A287CPLisHisPrvCod = new string[] {""} ;
         T001C24_A288CPLisHisFecha = new DateTime[] {DateTime.MinValue} ;
         T001C25_A284CPLisProdCod = new string[] {""} ;
         T001C26_A149TipCod = new string[] {""} ;
         T001C26_A243ComCod = new string[] {""} ;
         T001C26_A244PrvCod = new string[] {""} ;
         T001C26_A250ComDItem = new short[1] ;
         T001C26_A251ComDOrdCod = new string[] {""} ;
         T001C27_A191ImpItem = new long[1] ;
         T001C27_A197ImpDItem = new int[1] ;
         T001C28_A81CBonProdCod = new string[] {""} ;
         T001C29_A81CBonProdCod = new string[] {""} ;
         T001C30_A59SalCosAno = new int[1] ;
         T001C30_A60SalCosMes = new short[1] ;
         T001C30_A61SalCosAlmCod = new int[1] ;
         T001C30_A62SalCosProdCod = new string[] {""} ;
         T001C31_A37ListItem = new int[1] ;
         T001C32_A289OrdCod = new string[] {""} ;
         T001C32_A295OrdDItem = new int[1] ;
         T001C33_A149TipCod = new string[] {""} ;
         T001C33_A24DocNum = new string[] {""} ;
         T001C33_A233DocItem = new long[1] ;
         T001C34_A224LotCliCod = new string[] {""} ;
         T001C35_A210PedCod = new string[] {""} ;
         T001C35_A216PedDItem = new short[1] ;
         T001C36_A202TipLCod = new int[1] ;
         T001C36_A203TipLItem = new int[1] ;
         T001C37_A177CotCod = new string[] {""} ;
         T001C37_A183CotDItem = new short[1] ;
         T001C38_A13MvATip = new string[] {""} ;
         T001C38_A14MvACod = new string[] {""} ;
         T001C38_A30MvADItem = new int[1] ;
         T001C39_A210PedCod = new string[] {""} ;
         T001C39_A28ProdCod = new string[] {""} ;
         T001C39_A217PedDLRef1 = new string[] {""} ;
         T001C40_A63AlmCod = new int[1] ;
         T001C40_A28ProdCod = new string[] {""} ;
         T001C41_A28ProdCod = new string[] {""} ;
         T001C41_A58ProdMedUniCod = new int[1] ;
         T001C42_A28ProdCod = new string[] {""} ;
         T001C42_A57ProdForProdCod = new string[] {""} ;
         T001C43_A28ProdCod = new string[] {""} ;
         T001C43_A56ProdEQVCod = new string[] {""} ;
         T001C44_A28ProdCod = new string[] {""} ;
         T001C44_A56ProdEQVCod = new string[] {""} ;
         T001C45_A26AGMVATip = new string[] {""} ;
         T001C45_A27AGMVACod = new string[] {""} ;
         T001C45_A28ProdCod = new string[] {""} ;
         T001C46_A28ProdCod = new string[] {""} ;
         Z1691ProdForProdDsc = "";
         T001C47_A28ProdCod = new string[] {""} ;
         T001C47_A1691ProdForProdDsc = new string[] {""} ;
         T001C47_A1690ProdForCant = new decimal[1] ;
         T001C47_A1692ProdForSub = new short[1] ;
         T001C47_A57ProdForProdCod = new string[] {""} ;
         T001C4_A1691ProdForProdDsc = new string[] {""} ;
         T001C48_A1691ProdForProdDsc = new string[] {""} ;
         T001C49_A28ProdCod = new string[] {""} ;
         T001C49_A57ProdForProdCod = new string[] {""} ;
         T001C3_A28ProdCod = new string[] {""} ;
         T001C3_A1690ProdForCant = new decimal[1] ;
         T001C3_A1692ProdForSub = new short[1] ;
         T001C3_A57ProdForProdCod = new string[] {""} ;
         T001C2_A28ProdCod = new string[] {""} ;
         T001C2_A1690ProdForCant = new decimal[1] ;
         T001C2_A1692ProdForSub = new short[1] ;
         T001C2_A57ProdForProdCod = new string[] {""} ;
         T001C53_A1691ProdForProdDsc = new string[] {""} ;
         T001C54_A28ProdCod = new string[] {""} ;
         T001C54_A57ProdForProdCod = new string[] {""} ;
         Grid1Row = new GXWebRow();
         subGrid1_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ28ProdCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aproductosformula__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aproductosformula__default(),
            new Object[][] {
                new Object[] {
               T001C2_A28ProdCod, T001C2_A1690ProdForCant, T001C2_A1692ProdForSub, T001C2_A57ProdForProdCod
               }
               , new Object[] {
               T001C3_A28ProdCod, T001C3_A1690ProdForCant, T001C3_A1692ProdForSub, T001C3_A57ProdForProdCod
               }
               , new Object[] {
               T001C4_A1691ProdForProdDsc
               }
               , new Object[] {
               T001C5_A28ProdCod, T001C5_A906ProdAfecICBPER, T001C5_A907ProdValICBPER, T001C5_A908ProdValICBPERD
               }
               , new Object[] {
               T001C6_A28ProdCod, T001C6_A906ProdAfecICBPER, T001C6_A907ProdValICBPER, T001C6_A908ProdValICBPERD
               }
               , new Object[] {
               T001C7_A28ProdCod, T001C7_A906ProdAfecICBPER, T001C7_A907ProdValICBPER, T001C7_A908ProdValICBPERD
               }
               , new Object[] {
               T001C8_A28ProdCod
               }
               , new Object[] {
               T001C9_A28ProdCod
               }
               , new Object[] {
               T001C10_A28ProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001C14_A2385ProCosProdCod
               }
               , new Object[] {
               T001C15_A2382ProGasProdCod
               }
               , new Object[] {
               T001C16_A329PSerCod, T001C16_A335PSerDItem
               }
               , new Object[] {
               T001C17_A329PSerCod
               }
               , new Object[] {
               T001C18_A324ProPlanCod, T001C18_A331ProPlanDProdCod
               }
               , new Object[] {
               T001C19_A322ProCod, T001C19_A326ProDItem
               }
               , new Object[] {
               T001C20_A322ProCod
               }
               , new Object[] {
               T001C21_A317ProCotProdCod, T001C21_A318ProCotItem
               }
               , new Object[] {
               T001C22_A317ProCotProdCod
               }
               , new Object[] {
               T001C23_A310Iesa_SabPedCod, T001C23_A311Iesa_SabProdSec, T001C23_A312Iesa_SabProdCod
               }
               , new Object[] {
               T001C24_A286CPLisHisProdCod, T001C24_A287CPLisHisPrvCod, T001C24_A288CPLisHisFecha
               }
               , new Object[] {
               T001C25_A284CPLisProdCod
               }
               , new Object[] {
               T001C26_A149TipCod, T001C26_A243ComCod, T001C26_A244PrvCod, T001C26_A250ComDItem, T001C26_A251ComDOrdCod
               }
               , new Object[] {
               T001C27_A191ImpItem, T001C27_A197ImpDItem
               }
               , new Object[] {
               T001C28_A81CBonProdCod
               }
               , new Object[] {
               T001C29_A81CBonProdCod
               }
               , new Object[] {
               T001C30_A59SalCosAno, T001C30_A60SalCosMes, T001C30_A61SalCosAlmCod, T001C30_A62SalCosProdCod
               }
               , new Object[] {
               T001C31_A37ListItem
               }
               , new Object[] {
               T001C32_A289OrdCod, T001C32_A295OrdDItem
               }
               , new Object[] {
               T001C33_A149TipCod, T001C33_A24DocNum, T001C33_A233DocItem
               }
               , new Object[] {
               T001C34_A224LotCliCod
               }
               , new Object[] {
               T001C35_A210PedCod, T001C35_A216PedDItem
               }
               , new Object[] {
               T001C36_A202TipLCod, T001C36_A203TipLItem
               }
               , new Object[] {
               T001C37_A177CotCod, T001C37_A183CotDItem
               }
               , new Object[] {
               T001C38_A13MvATip, T001C38_A14MvACod, T001C38_A30MvADItem
               }
               , new Object[] {
               T001C39_A210PedCod, T001C39_A28ProdCod, T001C39_A217PedDLRef1
               }
               , new Object[] {
               T001C40_A63AlmCod, T001C40_A28ProdCod
               }
               , new Object[] {
               T001C41_A28ProdCod, T001C41_A58ProdMedUniCod
               }
               , new Object[] {
               T001C42_A28ProdCod, T001C42_A57ProdForProdCod
               }
               , new Object[] {
               T001C43_A28ProdCod, T001C43_A56ProdEQVCod
               }
               , new Object[] {
               T001C44_A28ProdCod, T001C44_A56ProdEQVCod
               }
               , new Object[] {
               T001C45_A26AGMVATip, T001C45_A27AGMVACod, T001C45_A28ProdCod
               }
               , new Object[] {
               T001C46_A28ProdCod
               }
               , new Object[] {
               T001C47_A28ProdCod, T001C47_A1691ProdForProdDsc, T001C47_A1690ProdForCant, T001C47_A1692ProdForSub, T001C47_A57ProdForProdCod
               }
               , new Object[] {
               T001C48_A1691ProdForProdDsc
               }
               , new Object[] {
               T001C49_A28ProdCod, T001C49_A57ProdForProdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001C53_A1691ProdForProdDsc
               }
               , new Object[] {
               T001C54_A28ProdCod, T001C54_A57ProdForProdCod
               }
            }
         );
      }

      private short Z906ProdAfecICBPER ;
      private short Z1692ProdForSub ;
      private short nRcdDeleted_46 ;
      private short nRcdExists_46 ;
      private short nIsMod_46 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short nBlankRcdCount46 ;
      private short RcdFound46 ;
      private short nBlankRcdUsr46 ;
      private short A906ProdAfecICBPER ;
      private short A1692ProdForSub ;
      private short GX_JID ;
      private short RcdFound44 ;
      private short nIsDirty_44 ;
      private short Gx_BScreen ;
      private short nIsDirty_46 ;
      private short subGrid1_Backstyle ;
      private short gxajaxcallmode ;
      private short ZZ906ProdAfecICBPER ;
      private int nRC_GXsfl_25 ;
      private int nGXsfl_25_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtavnRcdDeleted_46_Enabled ;
      private int edtProdForProdCod_Enabled ;
      private int edtProdForProdDsc_Enabled ;
      private int edtProdForCant_Enabled ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int fRowAdded ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int defedtProdForProdCod_Enabled ;
      private int idxLst ;
      private long GRID1_nFirstRecordOnPage ;
      private decimal Z907ProdValICBPER ;
      private decimal Z908ProdValICBPERD ;
      private decimal Z1690ProdForCant ;
      private decimal A1690ProdForCant ;
      private decimal A907ProdValICBPER ;
      private decimal A908ProdValICBPERD ;
      private decimal ZZ907ProdValICBPER ;
      private decimal ZZ908ProdValICBPERD ;
      private string sPrefix ;
      private string Z28ProdCod ;
      private string Z57ProdForProdCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A57ProdForProdCod ;
      private string sGXsfl_25_idx="0001" ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtProdCod_Internalname ;
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
      private string A28ProdCod ;
      private string edtProdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string subGrid1_Header ;
      private string A1691ProdForProdDsc ;
      private string sMode46 ;
      private string edtavnRcdDeleted_46_Internalname ;
      private string edtProdForProdCod_Internalname ;
      private string edtProdForProdDsc_Internalname ;
      private string edtProdForCant_Internalname ;
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
      private string hsh ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode44 ;
      private string GXCCtl ;
      private string Z1691ProdForProdDsc ;
      private string sGXsfl_25_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string ROClassString ;
      private string edtavnRcdDeleted_46_Jsonclick ;
      private string edtProdForProdCod_Jsonclick ;
      private string edtProdForProdDsc_Jsonclick ;
      private string edtProdForCant_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGrid1_Internalname ;
      private string ZZ28ProdCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool bGXsfl_25_Refreshing=false ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T001C7_A28ProdCod ;
      private short[] T001C7_A906ProdAfecICBPER ;
      private decimal[] T001C7_A907ProdValICBPER ;
      private decimal[] T001C7_A908ProdValICBPERD ;
      private string[] T001C8_A28ProdCod ;
      private string[] T001C6_A28ProdCod ;
      private short[] T001C6_A906ProdAfecICBPER ;
      private decimal[] T001C6_A907ProdValICBPER ;
      private decimal[] T001C6_A908ProdValICBPERD ;
      private string[] T001C9_A28ProdCod ;
      private string[] T001C10_A28ProdCod ;
      private string[] T001C5_A28ProdCod ;
      private short[] T001C5_A906ProdAfecICBPER ;
      private decimal[] T001C5_A907ProdValICBPER ;
      private decimal[] T001C5_A908ProdValICBPERD ;
      private string[] T001C14_A2385ProCosProdCod ;
      private string[] T001C15_A2382ProGasProdCod ;
      private string[] T001C16_A329PSerCod ;
      private int[] T001C16_A335PSerDItem ;
      private string[] T001C17_A329PSerCod ;
      private string[] T001C18_A324ProPlanCod ;
      private string[] T001C18_A331ProPlanDProdCod ;
      private string[] T001C19_A322ProCod ;
      private int[] T001C19_A326ProDItem ;
      private string[] T001C20_A322ProCod ;
      private string[] T001C21_A317ProCotProdCod ;
      private int[] T001C21_A318ProCotItem ;
      private string[] T001C22_A317ProCotProdCod ;
      private string[] T001C23_A310Iesa_SabPedCod ;
      private int[] T001C23_A311Iesa_SabProdSec ;
      private string[] T001C23_A312Iesa_SabProdCod ;
      private string[] T001C24_A286CPLisHisProdCod ;
      private string[] T001C24_A287CPLisHisPrvCod ;
      private DateTime[] T001C24_A288CPLisHisFecha ;
      private string[] T001C25_A284CPLisProdCod ;
      private string[] T001C26_A149TipCod ;
      private string[] T001C26_A243ComCod ;
      private string[] T001C26_A244PrvCod ;
      private short[] T001C26_A250ComDItem ;
      private string[] T001C26_A251ComDOrdCod ;
      private long[] T001C27_A191ImpItem ;
      private int[] T001C27_A197ImpDItem ;
      private string[] T001C28_A81CBonProdCod ;
      private string[] T001C29_A81CBonProdCod ;
      private int[] T001C30_A59SalCosAno ;
      private short[] T001C30_A60SalCosMes ;
      private int[] T001C30_A61SalCosAlmCod ;
      private string[] T001C30_A62SalCosProdCod ;
      private int[] T001C31_A37ListItem ;
      private string[] T001C32_A289OrdCod ;
      private int[] T001C32_A295OrdDItem ;
      private string[] T001C33_A149TipCod ;
      private string[] T001C33_A24DocNum ;
      private long[] T001C33_A233DocItem ;
      private string[] T001C34_A224LotCliCod ;
      private string[] T001C35_A210PedCod ;
      private short[] T001C35_A216PedDItem ;
      private int[] T001C36_A202TipLCod ;
      private int[] T001C36_A203TipLItem ;
      private string[] T001C37_A177CotCod ;
      private short[] T001C37_A183CotDItem ;
      private string[] T001C38_A13MvATip ;
      private string[] T001C38_A14MvACod ;
      private int[] T001C38_A30MvADItem ;
      private string[] T001C39_A210PedCod ;
      private string[] T001C39_A28ProdCod ;
      private string[] T001C39_A217PedDLRef1 ;
      private int[] T001C40_A63AlmCod ;
      private string[] T001C40_A28ProdCod ;
      private string[] T001C41_A28ProdCod ;
      private int[] T001C41_A58ProdMedUniCod ;
      private string[] T001C42_A28ProdCod ;
      private string[] T001C42_A57ProdForProdCod ;
      private string[] T001C43_A28ProdCod ;
      private string[] T001C43_A56ProdEQVCod ;
      private string[] T001C44_A28ProdCod ;
      private string[] T001C44_A56ProdEQVCod ;
      private string[] T001C45_A26AGMVATip ;
      private string[] T001C45_A27AGMVACod ;
      private string[] T001C45_A28ProdCod ;
      private string[] T001C46_A28ProdCod ;
      private string[] T001C47_A28ProdCod ;
      private string[] T001C47_A1691ProdForProdDsc ;
      private decimal[] T001C47_A1690ProdForCant ;
      private short[] T001C47_A1692ProdForSub ;
      private string[] T001C47_A57ProdForProdCod ;
      private string[] T001C4_A1691ProdForProdDsc ;
      private string[] T001C48_A1691ProdForProdDsc ;
      private string[] T001C49_A28ProdCod ;
      private string[] T001C49_A57ProdForProdCod ;
      private string[] T001C3_A28ProdCod ;
      private decimal[] T001C3_A1690ProdForCant ;
      private short[] T001C3_A1692ProdForSub ;
      private string[] T001C3_A57ProdForProdCod ;
      private string[] T001C2_A28ProdCod ;
      private decimal[] T001C2_A1690ProdForCant ;
      private short[] T001C2_A1692ProdForSub ;
      private string[] T001C2_A57ProdForProdCod ;
      private string[] T001C53_A1691ProdForProdDsc ;
      private string[] T001C54_A28ProdCod ;
      private string[] T001C54_A57ProdForProdCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aproductosformula__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aproductosformula__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
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
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
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
       ,new UpdateCursor(def[48])
       ,new UpdateCursor(def[49])
       ,new UpdateCursor(def[50])
       ,new ForEachCursor(def[51])
       ,new ForEachCursor(def[52])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT001C7;
        prmT001C7 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C8;
        prmT001C8 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C6;
        prmT001C6 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C9;
        prmT001C9 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C10;
        prmT001C10 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C5;
        prmT001C5 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C11;
        prmT001C11 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdAfecICBPER",GXType.Int16,1,0) ,
        new ParDef("@ProdValICBPER",GXType.Decimal,15,2) ,
        new ParDef("@ProdValICBPERD",GXType.Decimal,15,2)
        };
        Object[] prmT001C12;
        prmT001C12 = new Object[] {
        new ParDef("@ProdAfecICBPER",GXType.Int16,1,0) ,
        new ParDef("@ProdValICBPER",GXType.Decimal,15,2) ,
        new ParDef("@ProdValICBPERD",GXType.Decimal,15,2) ,
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C13;
        prmT001C13 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C14;
        prmT001C14 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C15;
        prmT001C15 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C16;
        prmT001C16 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C17;
        prmT001C17 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C18;
        prmT001C18 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C19;
        prmT001C19 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C20;
        prmT001C20 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C21;
        prmT001C21 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C22;
        prmT001C22 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C23;
        prmT001C23 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C24;
        prmT001C24 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C25;
        prmT001C25 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C26;
        prmT001C26 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C27;
        prmT001C27 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C28;
        prmT001C28 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C29;
        prmT001C29 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C30;
        prmT001C30 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C31;
        prmT001C31 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C32;
        prmT001C32 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C33;
        prmT001C33 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C34;
        prmT001C34 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C35;
        prmT001C35 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C36;
        prmT001C36 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C37;
        prmT001C37 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C38;
        prmT001C38 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C39;
        prmT001C39 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C40;
        prmT001C40 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C41;
        prmT001C41 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C42;
        prmT001C42 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C43;
        prmT001C43 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C44;
        prmT001C44 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C45;
        prmT001C45 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C46;
        prmT001C46 = new Object[] {
        };
        Object[] prmT001C47;
        prmT001C47 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C4;
        prmT001C4 = new Object[] {
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C48;
        prmT001C48 = new Object[] {
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C49;
        prmT001C49 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C3;
        prmT001C3 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C2;
        prmT001C2 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C50;
        prmT001C50 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdForCant",GXType.Decimal,18,6) ,
        new ParDef("@ProdForSub",GXType.Int16,1,0) ,
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C51;
        prmT001C51 = new Object[] {
        new ParDef("@ProdForCant",GXType.Decimal,18,6) ,
        new ParDef("@ProdForSub",GXType.Int16,1,0) ,
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C52;
        prmT001C52 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0) ,
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C54;
        prmT001C54 = new Object[] {
        new ParDef("@ProdCod",GXType.NChar,15,0)
        };
        Object[] prmT001C53;
        prmT001C53 = new Object[] {
        new ParDef("@ProdForProdCod",GXType.NChar,15,0)
        };
        def= new CursorDef[] {
            new CursorDef("T001C2", "SELECT [ProdCod], [ProdForCant], [ProdForSub], [ProdForProdCod] AS ProdForProdCod FROM [APRODUCTOSFORMULA] WITH (UPDLOCK) WHERE [ProdCod] = @ProdCod AND [ProdForProdCod] = @ProdForProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C3", "SELECT [ProdCod], [ProdForCant], [ProdForSub], [ProdForProdCod] AS ProdForProdCod FROM [APRODUCTOSFORMULA] WHERE [ProdCod] = @ProdCod AND [ProdForProdCod] = @ProdForProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C4", "SELECT [ProdDsc] AS ProdForProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProdForProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C5", "SELECT [ProdCod], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD] FROM [APRODUCTOS] WITH (UPDLOCK) WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C6", "SELECT [ProdCod], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C7", "SELECT TM1.[ProdCod], TM1.[ProdAfecICBPER], TM1.[ProdValICBPER], TM1.[ProdValICBPERD] FROM [APRODUCTOS] TM1 WHERE TM1.[ProdCod] = @ProdCod ORDER BY TM1.[ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C8", "SELECT [ProdCod] FROM [APRODUCTOS] WHERE [ProdCod] = @ProdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C9", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE ( [ProdCod] > @ProdCod) ORDER BY [ProdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C10", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE ( [ProdCod] < @ProdCod) ORDER BY [ProdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C11", "INSERT INTO [APRODUCTOS]([ProdCod], [ProdAfecICBPER], [ProdValICBPER], [ProdValICBPERD], [LinCod], [ProdDsc], [SublCod], [FamCod], [UniCod], [ProdVta], [ProdCmp], [ProdPeso], [ProdVolumen], [ProdStkMax], [ProdStkMin], [ProdFoto], [ProdFoto_GXI], [ProdRef1], [ProdRef2], [ProdRef3], [ProdRef4], [ProdRef5], [ProdRef6], [ProdRef7], [ProdRef8], [ProdRef9], [ProdRef10], [ProdSts], [ProdCosto], [ProdCostoFec], [ProdCostoD], [ProdIna], [ProdPorSel], [ProdImpSel], [ProdAdValor], [ProdFrecuente], [ProdCuentaV], [ProdCuentaC], [ProdCuentaA], [ProdUsuCod], [ProdUsuFec], [ProdAfec], [ProdObs], [ProdCanLote], [ProdBarra], [ProdExportacion], [CBSuCod], [cDetCod]) VALUES(@ProdCod, @ProdAfecICBPER, @ProdValICBPER, @ProdValICBPERD, convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), CONVERT(varbinary(1), ''), '', '', '', '', '', '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert( DATETIME, '17530101', 112 ), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', '', convert( DATETIME, '17530101', 112 ), convert(int, 0), '', convert(int, 0), '', '', '', convert(int, 0))", GxErrorMask.GX_NOMASK,prmT001C11)
           ,new CursorDef("T001C12", "UPDATE [APRODUCTOS] SET [ProdAfecICBPER]=@ProdAfecICBPER, [ProdValICBPER]=@ProdValICBPER, [ProdValICBPERD]=@ProdValICBPERD  WHERE [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001C12)
           ,new CursorDef("T001C13", "DELETE FROM [APRODUCTOS]  WHERE [ProdCod] = @ProdCod", GxErrorMask.GX_NOMASK,prmT001C13)
           ,new CursorDef("T001C14", "SELECT TOP 1 [ProCosProdCod] FROM [PROCOSTOMATERIAS] WHERE [ProCosProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C15", "SELECT TOP 1 [ProGasProdCod] FROM [PROCOSTOGASTOS] WHERE [ProGasProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C16", "SELECT TOP 1 [PSerCod], [PSerDItem] FROM [POSERVICIODET] WHERE [PSerDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C17", "SELECT TOP 1 [PSerCod] FROM [POSERVICIO] WHERE [PSerProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C18", "SELECT TOP 1 [ProPlanCod], [ProPlanDProdCod] FROM [POPLANDET] WHERE [ProPlanDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C19", "SELECT TOP 1 [ProCod], [ProDItem] FROM [POORDENESDET] WHERE [ProDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C20", "SELECT TOP 1 [ProCod] FROM [POORDENES] WHERE [ProProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C21", "SELECT TOP 1 [ProCotProdCod], [ProCotItem] FROM [POCOTIZADET] WHERE [ProCotDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C22", "SELECT TOP 1 [ProCotProdCod] FROM [POCOTIZA] WHERE [ProCotProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C23", "SELECT TOP 1 [Iesa_SabPedCod], [Iesa_SabProdSec], [Iesa_SabProdCod] FROM [OBR_SABANA] WHERE [Iesa_SabProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C24", "SELECT TOP 1 [CPLisHisProdCod], [CPLisHisPrvCod], [CPLisHisFecha] FROM [CPLISTAPRECIOSHIS] WHERE [CPLisHisProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C25", "SELECT TOP 1 [CPLisProdCod] FROM [CPLISTAPRECIOS] WHERE [CPLisProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C26", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [ComDProCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C26,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C27", "SELECT TOP 1 [ImpItem], [ImpDItem] FROM [CLDOCUMENTOSDET] WHERE [ImpDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C28", "SELECT TOP 1 [CBonProdCod] FROM [CBONIFICACION] WHERE [CBonDProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C28,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C29", "SELECT TOP 1 [CBonProdCod] FROM [CBONIFICACION] WHERE [CBonProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C29,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C30", "SELECT TOP 1 [SalCosAno], [SalCosMes], [SalCosAlmCod], [SalCosProdCod] FROM [ASALDOCOSTOMENSUAL] WHERE [SalCosProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C30,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C31", "SELECT TOP 1 [ListItem] FROM [ALISTADESCUENTO] WHERE [ListProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C31,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C32", "SELECT TOP 1 [OrdCod], [OrdDItem] FROM [CPORDENDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C32,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C33", "SELECT TOP 1 [TipCod], [DocNum], [DocItem] FROM [CLVENTASDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C33,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C34", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C34,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C35", "SELECT TOP 1 [PedCod], [PedDItem] FROM [CLPEDIDOSDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C35,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C36", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C36,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C37", "SELECT TOP 1 [CotCod], [CotDItem] FROM [CLCOTIZADET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C37,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C38", "SELECT TOP 1 [MvATip], [MvACod], [MvADItem] FROM [AGUIASDET] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C38,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C39", "SELECT TOP 1 [PedCod], [ProdCod], [PedDLRef1] FROM [CLPEDIDOSDETLOTE] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C39,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C40", "SELECT TOP 1 [AlmCod], [ProdCod] FROM [ASTOCKACTUAL] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C40,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C41", "SELECT TOP 1 [ProdCod], [ProdMedUniCod] FROM [APRODUCTOSMEDIDAS] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C41,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C42", "SELECT TOP 1 [ProdCod], [ProdForProdCod] AS ProdForProdCod FROM [APRODUCTOSFORMULA] WHERE [ProdForProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C42,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C43", "SELECT TOP 1 [ProdCod], [ProdEQVCod] FROM [APRODUCTOSEQUIVALENTE] WHERE [ProdEQVCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C43,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C44", "SELECT TOP 1 [ProdCod], [ProdEQVCod] FROM [APRODUCTOSEQUIVALENTE] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C44,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C45", "SELECT TOP 1 [AGMVATip], [AGMVACod], [ProdCod] FROM [AGUIASCONSIGNA] WHERE [ProdCod] = @ProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C45,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001C46", "SELECT [ProdCod] FROM [APRODUCTOS] ORDER BY [ProdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001C46,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C47", "SELECT T1.[ProdCod], T2.[ProdDsc] AS ProdForProdDsc, T1.[ProdForCant], T1.[ProdForSub], T1.[ProdForProdCod] AS ProdForProdCod FROM ([APRODUCTOSFORMULA] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[ProdForProdCod]) WHERE T1.[ProdCod] = @ProdCod and T1.[ProdForProdCod] = @ProdForProdCod ORDER BY T1.[ProdCod], T1.[ProdForProdCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C47,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C48", "SELECT [ProdDsc] AS ProdForProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProdForProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C48,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C49", "SELECT [ProdCod], [ProdForProdCod] AS ProdForProdCod FROM [APRODUCTOSFORMULA] WHERE [ProdCod] = @ProdCod AND [ProdForProdCod] = @ProdForProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C49,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C50", "INSERT INTO [APRODUCTOSFORMULA]([ProdCod], [ProdForCant], [ProdForSub], [ProdForProdCod]) VALUES(@ProdCod, @ProdForCant, @ProdForSub, @ProdForProdCod)", GxErrorMask.GX_NOMASK,prmT001C50)
           ,new CursorDef("T001C51", "UPDATE [APRODUCTOSFORMULA] SET [ProdForCant]=@ProdForCant, [ProdForSub]=@ProdForSub  WHERE [ProdCod] = @ProdCod AND [ProdForProdCod] = @ProdForProdCod", GxErrorMask.GX_NOMASK,prmT001C51)
           ,new CursorDef("T001C52", "DELETE FROM [APRODUCTOSFORMULA]  WHERE [ProdCod] = @ProdCod AND [ProdForProdCod] = @ProdForProdCod", GxErrorMask.GX_NOMASK,prmT001C52)
           ,new CursorDef("T001C53", "SELECT [ProdDsc] AS ProdForProdDsc FROM [APRODUCTOS] WHERE [ProdCod] = @ProdForProdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C53,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001C54", "SELECT [ProdCod], [ProdForProdCod] AS ProdForProdCod FROM [APRODUCTOSFORMULA] WHERE [ProdCod] = @ProdCod ORDER BY [ProdCod], [ProdForProdCod] ",true, GxErrorMask.GX_NOMASK, false, this,prmT001C54,11, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 27 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              return;
           case 29 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 34 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 36 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 37 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              return;
           case 38 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 39 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 40 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 41 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 42 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 43 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 15);
              return;
           case 44 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 45 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              return;
           case 46 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 47 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
           case 51 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 52 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              return;
     }
  }

}

}
