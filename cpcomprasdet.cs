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
   public class cpcomprasdet : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_8") == 0 )
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
            gxLoad_8( A149TipCod, A243ComCod, A244PrvCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A254ComDProCod = GetPar( "ComDProCod");
            n254ComDProCod = false;
            AssignAttri("", false, "A254ComDProCod", A254ComDProCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A254ComDProCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_10") == 0 )
         {
            A253ComDCueCod = GetPar( "ComDCueCod");
            n253ComDCueCod = false;
            AssignAttri("", false, "A253ComDCueCod", A253ComDCueCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_10( A253ComDCueCod) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A252ComCosCod = GetPar( "ComCosCod");
            n252ComCosCod = false;
            AssignAttri("", false, "A252ComCosCod", A252ComCosCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A252ComCosCod) ;
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
            Form.Meta.addItem("description", "Compras - Detalle", 0) ;
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

      public cpcomprasdet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cpcomprasdet( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CPCOMPRASDET.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo T. Documento", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "N° Documento", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComCod_Internalname, StringUtil.RTrim( A243ComCod), StringUtil.RTrim( context.localUtil.Format( A243ComCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Codigo Proveedor", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrvCod_Internalname, StringUtil.RTrim( A244PrvCod), StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrvCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPrvCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Item", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A250ComDItem), 4, 0, ".", "")), StringUtil.LTrim( ((edtComDItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A250ComDItem), "ZZZ9") : context.localUtil.Format( (decimal)(A250ComDItem), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDItem_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "N° Orden", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDOrdCod_Internalname, StringUtil.RTrim( A251ComDOrdCod), StringUtil.RTrim( context.localUtil.Format( A251ComDOrdCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDOrdCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDOrdCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Codigo", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDProCod_Internalname, StringUtil.RTrim( A254ComDProCod), StringUtil.RTrim( context.localUtil.Format( A254ComDProCod, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDProCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDProCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Descripción", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDDsc_Internalname, StringUtil.RTrim( A694ComDDsc), StringUtil.RTrim( context.localUtil.Format( A694ComDDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Cantidad", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDCant_Internalname, StringUtil.LTrim( StringUtil.NToC( A685ComDCant, 17, 4, ".", "")), StringUtil.LTrim( ((edtComDCant_Enabled!=0) ? context.localUtil.Format( A685ComDCant, "ZZZZ,ZZZ,ZZ9.9999") : context.localUtil.Format( A685ComDCant, "ZZZZ,ZZZ,ZZ9.9999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','4');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDCant_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDCant_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "CantidadPrecio", "right", false, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Precio", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDPre_Internalname, StringUtil.LTrim( StringUtil.NToC( A686ComDPre, 20, 6, ".", "")), StringUtil.LTrim( ((edtComDPre_Enabled!=0) ? context.localUtil.Format( A686ComDPre, "ZZZZZ,ZZZ,ZZ9.999999") : context.localUtil.Format( A686ComDPre, "ZZZZZ,ZZZ,ZZ9.999999"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','6');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDPre_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDPre_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, 0, true, "Precio6", "right", false, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Afecto/Inafecto", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDTip_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A690ComDTip), 1, 0, ".", "")), StringUtil.LTrim( ((edtComDTip_Enabled!=0) ? context.localUtil.Format( (decimal)(A690ComDTip), "9") : context.localUtil.Format( (decimal)(A690ComDTip), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDTip_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "Concepto Gasto", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDCueCod_Internalname, StringUtil.RTrim( A253ComDCueCod), StringUtil.RTrim( context.localUtil.Format( A253ComDCueCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDCueCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDCueCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "Centro de Costos", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComCosCod_Internalname, StringUtil.RTrim( A252ComCosCod), StringUtil.RTrim( context.localUtil.Format( A252ComCosCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComCosCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComCosCod_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "% Dscto", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDDct_Internalname, StringUtil.LTrim( StringUtil.NToC( A689ComDDct, 17, 2, ".", "")), StringUtil.LTrim( ((edtComDDct_Enabled!=0) ? context.localUtil.Format( A689ComDDct, "ZZZZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A689ComDDct, "ZZZZZZ,ZZZ,ZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDDct_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDDct_Enabled, 0, "text", "", 17, "chr", 1, "row", 17, 0, 0, 0, 1, -1, 0, true, "Importe", "right", false, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Cuenta Auxiliar", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDAuxCue_Internalname, StringUtil.RTrim( A692ComDAuxCue), StringUtil.RTrim( context.localUtil.Format( A692ComDAuxCue, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDAuxCue_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDAuxCue_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Auxiliar", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDAuxCod_Internalname, StringUtil.RTrim( A691ComDAuxCod), StringUtil.RTrim( context.localUtil.Format( A691ComDAuxCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDAuxCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDAuxCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "Afecto Importación", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDImp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A695ComDImp), 1, 0, ".", "")), StringUtil.LTrim( ((edtComDImp_Enabled!=0) ? context.localUtil.Format( (decimal)(A695ComDImp), "9") : context.localUtil.Format( (decimal)(A695ComDImp), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDImp_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDImp_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "Tipo de Orden", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtComDOrdTip_Internalname, A697ComDOrdTip, StringUtil.RTrim( context.localUtil.Format( A697ComDOrdTip, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtComDOrdTip_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtComDOrdTip_Enabled, 0, "text", "", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CPCOMPRASDET.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CPCOMPRASDET.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CPCOMPRASDET.htm");
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
            Z250ComDItem = (short)(context.localUtil.CToN( cgiGet( "Z250ComDItem"), ".", ","));
            Z251ComDOrdCod = cgiGet( "Z251ComDOrdCod");
            Z694ComDDsc = cgiGet( "Z694ComDDsc");
            Z685ComDCant = context.localUtil.CToN( cgiGet( "Z685ComDCant"), ".", ",");
            Z686ComDPre = context.localUtil.CToN( cgiGet( "Z686ComDPre"), ".", ",");
            Z690ComDTip = (short)(context.localUtil.CToN( cgiGet( "Z690ComDTip"), ".", ","));
            Z689ComDDct = context.localUtil.CToN( cgiGet( "Z689ComDDct"), ".", ",");
            Z692ComDAuxCue = cgiGet( "Z692ComDAuxCue");
            Z691ComDAuxCod = cgiGet( "Z691ComDAuxCod");
            Z695ComDImp = (short)(context.localUtil.CToN( cgiGet( "Z695ComDImp"), ".", ","));
            n695ComDImp = ((0==A695ComDImp) ? true : false);
            Z697ComDOrdTip = cgiGet( "Z697ComDOrdTip");
            Z254ComDProCod = cgiGet( "Z254ComDProCod");
            n254ComDProCod = (String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ? true : false);
            Z253ComDCueCod = cgiGet( "Z253ComDCueCod");
            n253ComDCueCod = (String.IsNullOrEmpty(StringUtil.RTrim( A253ComDCueCod)) ? true : false);
            Z252ComCosCod = cgiGet( "Z252ComCosCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            A688ComDSub = context.localUtil.CToN( cgiGet( "COMDSUB"), ".", ",");
            A687ComDDescuento = context.localUtil.CToN( cgiGet( "COMDDESCUENTO"), ".", ",");
            A684ComDTot = context.localUtil.CToN( cgiGet( "COMDTOT"), ".", ",");
            A696ComDIna = context.localUtil.CToN( cgiGet( "COMDINA"), ".", ",");
            A683ComDAfe = context.localUtil.CToN( cgiGet( "COMDAFE"), ".", ",");
            A700ComDTotImp = context.localUtil.CToN( cgiGet( "COMDTOTIMP"), ".", ",");
            A693ComDCueCos = (short)(context.localUtil.CToN( cgiGet( "COMDCUECOS"), ".", ","));
            A699ComDTipACod = (int)(context.localUtil.CToN( cgiGet( "COMDTIPACOD"), ".", ","));
            n699ComDTipACod = false;
            /* Read variables values. */
            A149TipCod = cgiGet( edtTipCod_Internalname);
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = cgiGet( edtComCod_Internalname);
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = StringUtil.Upper( cgiGet( edtPrvCod_Internalname));
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComDItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComDItem_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMDITEM");
               AnyError = 1;
               GX_FocusControl = edtComDItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A250ComDItem = 0;
               AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
            }
            else
            {
               A250ComDItem = (short)(context.localUtil.CToN( cgiGet( edtComDItem_Internalname), ".", ","));
               AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
            }
            A251ComDOrdCod = cgiGet( edtComDOrdCod_Internalname);
            AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
            A254ComDProCod = StringUtil.Upper( cgiGet( edtComDProCod_Internalname));
            n254ComDProCod = false;
            AssignAttri("", false, "A254ComDProCod", A254ComDProCod);
            n254ComDProCod = (String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ? true : false);
            A694ComDDsc = cgiGet( edtComDDsc_Internalname);
            AssignAttri("", false, "A694ComDDsc", A694ComDDsc);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComDCant_Internalname), ".", ",") < -999999999.9999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComDCant_Internalname), ".", ",") > 9999999999.9999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMDCANT");
               AnyError = 1;
               GX_FocusControl = edtComDCant_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A685ComDCant = 0;
               AssignAttri("", false, "A685ComDCant", StringUtil.LTrimStr( A685ComDCant, 15, 4));
            }
            else
            {
               A685ComDCant = context.localUtil.CToN( cgiGet( edtComDCant_Internalname), ".", ",");
               AssignAttri("", false, "A685ComDCant", StringUtil.LTrimStr( A685ComDCant, 15, 4));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComDPre_Internalname), ".", ",") < -9999999999.999999m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComDPre_Internalname), ".", ",") > 99999999999.999999m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMDPRE");
               AnyError = 1;
               GX_FocusControl = edtComDPre_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A686ComDPre = 0;
               AssignAttri("", false, "A686ComDPre", StringUtil.LTrimStr( A686ComDPre, 18, 6));
            }
            else
            {
               A686ComDPre = context.localUtil.CToN( cgiGet( edtComDPre_Internalname), ".", ",");
               AssignAttri("", false, "A686ComDPre", StringUtil.LTrimStr( A686ComDPre, 18, 6));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtComDTip_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComDTip_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMDTIP");
               AnyError = 1;
               GX_FocusControl = edtComDTip_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A690ComDTip = 0;
               AssignAttri("", false, "A690ComDTip", StringUtil.Str( (decimal)(A690ComDTip), 1, 0));
            }
            else
            {
               A690ComDTip = (short)(context.localUtil.CToN( cgiGet( edtComDTip_Internalname), ".", ","));
               AssignAttri("", false, "A690ComDTip", StringUtil.Str( (decimal)(A690ComDTip), 1, 0));
            }
            A253ComDCueCod = cgiGet( edtComDCueCod_Internalname);
            n253ComDCueCod = false;
            AssignAttri("", false, "A253ComDCueCod", A253ComDCueCod);
            n253ComDCueCod = (String.IsNullOrEmpty(StringUtil.RTrim( A253ComDCueCod)) ? true : false);
            A252ComCosCod = cgiGet( edtComCosCod_Internalname);
            n252ComCosCod = false;
            AssignAttri("", false, "A252ComCosCod", A252ComCosCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComDDct_Internalname), ".", ",") < -99999999999.99m ) ) || ( ( context.localUtil.CToN( cgiGet( edtComDDct_Internalname), ".", ",") > 999999999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMDDCT");
               AnyError = 1;
               GX_FocusControl = edtComDDct_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A689ComDDct = 0;
               AssignAttri("", false, "A689ComDDct", StringUtil.LTrimStr( A689ComDDct, 15, 2));
            }
            else
            {
               A689ComDDct = context.localUtil.CToN( cgiGet( edtComDDct_Internalname), ".", ",");
               AssignAttri("", false, "A689ComDDct", StringUtil.LTrimStr( A689ComDDct, 15, 2));
            }
            A692ComDAuxCue = cgiGet( edtComDAuxCue_Internalname);
            AssignAttri("", false, "A692ComDAuxCue", A692ComDAuxCue);
            A691ComDAuxCod = cgiGet( edtComDAuxCod_Internalname);
            AssignAttri("", false, "A691ComDAuxCod", A691ComDAuxCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtComDImp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtComDImp_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "COMDIMP");
               AnyError = 1;
               GX_FocusControl = edtComDImp_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A695ComDImp = 0;
               n695ComDImp = false;
               AssignAttri("", false, "A695ComDImp", StringUtil.Str( (decimal)(A695ComDImp), 1, 0));
            }
            else
            {
               A695ComDImp = (short)(context.localUtil.CToN( cgiGet( edtComDImp_Internalname), ".", ","));
               n695ComDImp = false;
               AssignAttri("", false, "A695ComDImp", StringUtil.Str( (decimal)(A695ComDImp), 1, 0));
            }
            n695ComDImp = ((0==A695ComDImp) ? true : false);
            A697ComDOrdTip = cgiGet( edtComDOrdTip_Internalname);
            AssignAttri("", false, "A697ComDOrdTip", A697ComDOrdTip);
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
               A149TipCod = GetPar( "TipCod");
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = GetPar( "ComCod");
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = GetPar( "PrvCod");
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               A250ComDItem = (short)(NumberUtil.Val( GetPar( "ComDItem"), "."));
               AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
               A251ComDOrdCod = GetPar( "ComDOrdCod");
               AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
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
               InitAll37110( ) ;
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
         DisableAttributes37110( ) ;
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

      protected void CONFIRM_370( )
      {
         BeforeValidate37110( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls37110( ) ;
            }
            else
            {
               CheckExtendedTable37110( ) ;
               if ( AnyError == 0 )
               {
                  ZM37110( 8) ;
                  ZM37110( 9) ;
                  ZM37110( 10) ;
                  ZM37110( 11) ;
               }
               CloseExtendedTableCursors37110( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues370( ) ;
         }
      }

      protected void ResetCaption370( )
      {
      }

      protected void ZM37110( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z694ComDDsc = T00373_A694ComDDsc[0];
               Z685ComDCant = T00373_A685ComDCant[0];
               Z686ComDPre = T00373_A686ComDPre[0];
               Z690ComDTip = T00373_A690ComDTip[0];
               Z689ComDDct = T00373_A689ComDDct[0];
               Z692ComDAuxCue = T00373_A692ComDAuxCue[0];
               Z691ComDAuxCod = T00373_A691ComDAuxCod[0];
               Z695ComDImp = T00373_A695ComDImp[0];
               Z697ComDOrdTip = T00373_A697ComDOrdTip[0];
               Z254ComDProCod = T00373_A254ComDProCod[0];
               Z253ComDCueCod = T00373_A253ComDCueCod[0];
               Z252ComCosCod = T00373_A252ComCosCod[0];
            }
            else
            {
               Z694ComDDsc = A694ComDDsc;
               Z685ComDCant = A685ComDCant;
               Z686ComDPre = A686ComDPre;
               Z690ComDTip = A690ComDTip;
               Z689ComDDct = A689ComDDct;
               Z692ComDAuxCue = A692ComDAuxCue;
               Z691ComDAuxCod = A691ComDAuxCod;
               Z695ComDImp = A695ComDImp;
               Z697ComDOrdTip = A697ComDOrdTip;
               Z254ComDProCod = A254ComDProCod;
               Z253ComDCueCod = A253ComDCueCod;
               Z252ComCosCod = A252ComCosCod;
            }
         }
         if ( GX_JID == -7 )
         {
            Z250ComDItem = A250ComDItem;
            Z251ComDOrdCod = A251ComDOrdCod;
            Z694ComDDsc = A694ComDDsc;
            Z685ComDCant = A685ComDCant;
            Z686ComDPre = A686ComDPre;
            Z690ComDTip = A690ComDTip;
            Z689ComDDct = A689ComDDct;
            Z692ComDAuxCue = A692ComDAuxCue;
            Z691ComDAuxCod = A691ComDAuxCod;
            Z695ComDImp = A695ComDImp;
            Z697ComDOrdTip = A697ComDOrdTip;
            Z149TipCod = A149TipCod;
            Z243ComCod = A243ComCod;
            Z244PrvCod = A244PrvCod;
            Z254ComDProCod = A254ComDProCod;
            Z253ComDCueCod = A253ComDCueCod;
            Z252ComCosCod = A252ComCosCod;
            Z693ComDCueCos = A693ComDCueCos;
            Z699ComDTipACod = A699ComDTipACod;
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

      protected void Load37110( )
      {
         /* Using cursor T00378 */
         pr_default.execute(6, new Object[] {A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound110 = 1;
            A694ComDDsc = T00378_A694ComDDsc[0];
            AssignAttri("", false, "A694ComDDsc", A694ComDDsc);
            A685ComDCant = T00378_A685ComDCant[0];
            AssignAttri("", false, "A685ComDCant", StringUtil.LTrimStr( A685ComDCant, 15, 4));
            A686ComDPre = T00378_A686ComDPre[0];
            AssignAttri("", false, "A686ComDPre", StringUtil.LTrimStr( A686ComDPre, 18, 6));
            A690ComDTip = T00378_A690ComDTip[0];
            AssignAttri("", false, "A690ComDTip", StringUtil.Str( (decimal)(A690ComDTip), 1, 0));
            A689ComDDct = T00378_A689ComDDct[0];
            AssignAttri("", false, "A689ComDDct", StringUtil.LTrimStr( A689ComDDct, 15, 2));
            A692ComDAuxCue = T00378_A692ComDAuxCue[0];
            AssignAttri("", false, "A692ComDAuxCue", A692ComDAuxCue);
            A691ComDAuxCod = T00378_A691ComDAuxCod[0];
            AssignAttri("", false, "A691ComDAuxCod", A691ComDAuxCod);
            A695ComDImp = T00378_A695ComDImp[0];
            n695ComDImp = T00378_n695ComDImp[0];
            AssignAttri("", false, "A695ComDImp", StringUtil.Str( (decimal)(A695ComDImp), 1, 0));
            A697ComDOrdTip = T00378_A697ComDOrdTip[0];
            AssignAttri("", false, "A697ComDOrdTip", A697ComDOrdTip);
            A693ComDCueCos = T00378_A693ComDCueCos[0];
            A254ComDProCod = T00378_A254ComDProCod[0];
            n254ComDProCod = T00378_n254ComDProCod[0];
            AssignAttri("", false, "A254ComDProCod", A254ComDProCod);
            A253ComDCueCod = T00378_A253ComDCueCod[0];
            n253ComDCueCod = T00378_n253ComDCueCod[0];
            AssignAttri("", false, "A253ComDCueCod", A253ComDCueCod);
            A252ComCosCod = T00378_A252ComCosCod[0];
            n252ComCosCod = T00378_n252ComCosCod[0];
            AssignAttri("", false, "A252ComCosCod", A252ComCosCod);
            A699ComDTipACod = T00378_A699ComDTipACod[0];
            n699ComDTipACod = T00378_n699ComDTipACod[0];
            ZM37110( -7) ;
         }
         pr_default.close(6);
         OnLoadActions37110( ) ;
      }

      protected void OnLoadActions37110( )
      {
         A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
         AssignAttri("", false, "A688ComDSub", StringUtil.LTrimStr( A688ComDSub, 15, 2));
         A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
         AssignAttri("", false, "A687ComDDescuento", StringUtil.LTrimStr( A687ComDDescuento, 15, 2));
         A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
         AssignAttri("", false, "A684ComDTot", StringUtil.LTrimStr( A684ComDTot, 15, 2));
         if ( A690ComDTip == 1 )
         {
            A696ComDIna = A684ComDTot;
            AssignAttri("", false, "A696ComDIna", StringUtil.LTrimStr( A696ComDIna, 15, 2));
         }
         else
         {
            A696ComDIna = 0;
            AssignAttri("", false, "A696ComDIna", StringUtil.LTrimStr( A696ComDIna, 15, 2));
         }
         if ( A690ComDTip == 0 )
         {
            A683ComDAfe = A684ComDTot;
            AssignAttri("", false, "A683ComDAfe", StringUtil.LTrimStr( A683ComDAfe, 15, 2));
         }
         else
         {
            A683ComDAfe = 0;
            AssignAttri("", false, "A683ComDAfe", StringUtil.LTrimStr( A683ComDAfe, 15, 2));
         }
         A700ComDTotImp = ((A695ComDImp==1) ? A684ComDTot : (decimal)(0));
         AssignAttri("", false, "A700ComDTotImp", StringUtil.LTrimStr( A700ComDTotImp, 15, 2));
      }

      protected void CheckExtendedTable37110( )
      {
         nIsDirty_110 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00374 */
         pr_default.execute(2, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T00375 */
         pr_default.execute(3, new Object[] {n254ComDProCod, A254ComDProCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ) )
            {
               GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "COMDPROCOD");
               AnyError = 1;
               GX_FocusControl = edtComDProCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(3);
         nIsDirty_110 = 1;
         A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
         AssignAttri("", false, "A688ComDSub", StringUtil.LTrimStr( A688ComDSub, 15, 2));
         nIsDirty_110 = 1;
         A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
         AssignAttri("", false, "A687ComDDescuento", StringUtil.LTrimStr( A687ComDDescuento, 15, 2));
         nIsDirty_110 = 1;
         A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
         AssignAttri("", false, "A684ComDTot", StringUtil.LTrimStr( A684ComDTot, 15, 2));
         if ( A690ComDTip == 1 )
         {
            nIsDirty_110 = 1;
            A696ComDIna = A684ComDTot;
            AssignAttri("", false, "A696ComDIna", StringUtil.LTrimStr( A696ComDIna, 15, 2));
         }
         else
         {
            nIsDirty_110 = 1;
            A696ComDIna = 0;
            AssignAttri("", false, "A696ComDIna", StringUtil.LTrimStr( A696ComDIna, 15, 2));
         }
         if ( A690ComDTip == 0 )
         {
            nIsDirty_110 = 1;
            A683ComDAfe = A684ComDTot;
            AssignAttri("", false, "A683ComDAfe", StringUtil.LTrimStr( A683ComDAfe, 15, 2));
         }
         else
         {
            nIsDirty_110 = 1;
            A683ComDAfe = 0;
            AssignAttri("", false, "A683ComDAfe", StringUtil.LTrimStr( A683ComDAfe, 15, 2));
         }
         nIsDirty_110 = 1;
         A700ComDTotImp = ((A695ComDImp==1) ? A684ComDTot : (decimal)(0));
         AssignAttri("", false, "A700ComDTotImp", StringUtil.LTrimStr( A700ComDTotImp, 15, 2));
         /* Using cursor T00376 */
         pr_default.execute(4, new Object[] {n253ComDCueCod, A253ComDCueCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A253ComDCueCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "COMDCUECOD");
               AnyError = 1;
               GX_FocusControl = edtComDCueCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A693ComDCueCos = T00376_A693ComDCueCos[0];
         A699ComDTipACod = T00376_A699ComDTipACod[0];
         n699ComDTipACod = T00376_n699ComDTipACod[0];
         pr_default.close(4);
         /* Using cursor T00377 */
         pr_default.execute(5, new Object[] {n252ComCosCod, A252ComCosCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A252ComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro Costo'.", "ForeignKeyNotFound", 1, "COMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtComCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors37110( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_8( string A149TipCod ,
                               string A243ComCod ,
                               string A244PrvCod )
      {
         /* Using cursor T00379 */
         pr_default.execute(7, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_9( string A254ComDProCod )
      {
         /* Using cursor T003710 */
         pr_default.execute(8, new Object[] {n254ComDProCod, A254ComDProCod});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ) )
            {
               GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "COMDPROCOD");
               AnyError = 1;
               GX_FocusControl = edtComDProCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
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

      protected void gxLoad_10( string A253ComDCueCod )
      {
         /* Using cursor T003711 */
         pr_default.execute(9, new Object[] {n253ComDCueCod, A253ComDCueCod});
         if ( (pr_default.getStatus(9) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A253ComDCueCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "COMDCUECOD");
               AnyError = 1;
               GX_FocusControl = edtComDCueCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A693ComDCueCos = T003711_A693ComDCueCos[0];
         A699ComDTipACod = T003711_A699ComDTipACod[0];
         n699ComDTipACod = T003711_n699ComDTipACod[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A693ComDCueCos), 1, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A699ComDTipACod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_11( string A252ComCosCod )
      {
         /* Using cursor T003712 */
         pr_default.execute(10, new Object[] {n252ComCosCod, A252ComCosCod});
         if ( (pr_default.getStatus(10) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A252ComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro Costo'.", "ForeignKeyNotFound", 1, "COMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtComCosCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void GetKey37110( )
      {
         /* Using cursor T003713 */
         pr_default.execute(11, new Object[] {A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound110 = 1;
         }
         else
         {
            RcdFound110 = 0;
         }
         pr_default.close(11);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00373 */
         pr_default.execute(1, new Object[] {A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM37110( 7) ;
            RcdFound110 = 1;
            A250ComDItem = T00373_A250ComDItem[0];
            AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
            A251ComDOrdCod = T00373_A251ComDOrdCod[0];
            AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
            A694ComDDsc = T00373_A694ComDDsc[0];
            AssignAttri("", false, "A694ComDDsc", A694ComDDsc);
            A685ComDCant = T00373_A685ComDCant[0];
            AssignAttri("", false, "A685ComDCant", StringUtil.LTrimStr( A685ComDCant, 15, 4));
            A686ComDPre = T00373_A686ComDPre[0];
            AssignAttri("", false, "A686ComDPre", StringUtil.LTrimStr( A686ComDPre, 18, 6));
            A690ComDTip = T00373_A690ComDTip[0];
            AssignAttri("", false, "A690ComDTip", StringUtil.Str( (decimal)(A690ComDTip), 1, 0));
            A689ComDDct = T00373_A689ComDDct[0];
            AssignAttri("", false, "A689ComDDct", StringUtil.LTrimStr( A689ComDDct, 15, 2));
            A692ComDAuxCue = T00373_A692ComDAuxCue[0];
            AssignAttri("", false, "A692ComDAuxCue", A692ComDAuxCue);
            A691ComDAuxCod = T00373_A691ComDAuxCod[0];
            AssignAttri("", false, "A691ComDAuxCod", A691ComDAuxCod);
            A695ComDImp = T00373_A695ComDImp[0];
            n695ComDImp = T00373_n695ComDImp[0];
            AssignAttri("", false, "A695ComDImp", StringUtil.Str( (decimal)(A695ComDImp), 1, 0));
            A697ComDOrdTip = T00373_A697ComDOrdTip[0];
            AssignAttri("", false, "A697ComDOrdTip", A697ComDOrdTip);
            A149TipCod = T00373_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = T00373_A243ComCod[0];
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = T00373_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A254ComDProCod = T00373_A254ComDProCod[0];
            n254ComDProCod = T00373_n254ComDProCod[0];
            AssignAttri("", false, "A254ComDProCod", A254ComDProCod);
            A253ComDCueCod = T00373_A253ComDCueCod[0];
            n253ComDCueCod = T00373_n253ComDCueCod[0];
            AssignAttri("", false, "A253ComDCueCod", A253ComDCueCod);
            A252ComCosCod = T00373_A252ComCosCod[0];
            n252ComCosCod = T00373_n252ComCosCod[0];
            AssignAttri("", false, "A252ComCosCod", A252ComCosCod);
            Z149TipCod = A149TipCod;
            Z243ComCod = A243ComCod;
            Z244PrvCod = A244PrvCod;
            Z250ComDItem = A250ComDItem;
            Z251ComDOrdCod = A251ComDOrdCod;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load37110( ) ;
            if ( AnyError == 1 )
            {
               RcdFound110 = 0;
               InitializeNonKey37110( ) ;
            }
            Gx_mode = sMode110;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound110 = 0;
            InitializeNonKey37110( ) ;
            sMode110 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode110;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey37110( ) ;
         if ( RcdFound110 == 0 )
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
         RcdFound110 = 0;
         /* Using cursor T003714 */
         pr_default.execute(12, new Object[] {A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
         if ( (pr_default.getStatus(12) != 101) )
         {
            while ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) < 0 ) || ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003714_A244PrvCod[0], A244PrvCod) < 0 ) || ( StringUtil.StrCmp(T003714_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( T003714_A250ComDItem[0] < A250ComDItem ) || ( T003714_A250ComDItem[0] == A250ComDItem ) && ( StringUtil.StrCmp(T003714_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003714_A251ComDOrdCod[0], A251ComDOrdCod) < 0 ) ) )
            {
               pr_default.readNext(12);
            }
            if ( (pr_default.getStatus(12) != 101) && ( ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) > 0 ) || ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003714_A244PrvCod[0], A244PrvCod) > 0 ) || ( StringUtil.StrCmp(T003714_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( T003714_A250ComDItem[0] > A250ComDItem ) || ( T003714_A250ComDItem[0] == A250ComDItem ) && ( StringUtil.StrCmp(T003714_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003714_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003714_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003714_A251ComDOrdCod[0], A251ComDOrdCod) > 0 ) ) )
            {
               A149TipCod = T003714_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = T003714_A243ComCod[0];
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = T003714_A244PrvCod[0];
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               A250ComDItem = T003714_A250ComDItem[0];
               AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
               A251ComDOrdCod = T003714_A251ComDOrdCod[0];
               AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
               RcdFound110 = 1;
            }
         }
         pr_default.close(12);
      }

      protected void move_previous( )
      {
         RcdFound110 = 0;
         /* Using cursor T003715 */
         pr_default.execute(13, new Object[] {A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) > 0 ) || ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) > 0 ) || ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003715_A244PrvCod[0], A244PrvCod) > 0 ) || ( StringUtil.StrCmp(T003715_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( T003715_A250ComDItem[0] > A250ComDItem ) || ( T003715_A250ComDItem[0] == A250ComDItem ) && ( StringUtil.StrCmp(T003715_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003715_A251ComDOrdCod[0], A251ComDOrdCod) > 0 ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) < 0 ) || ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) < 0 ) || ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003715_A244PrvCod[0], A244PrvCod) < 0 ) || ( StringUtil.StrCmp(T003715_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( T003715_A250ComDItem[0] < A250ComDItem ) || ( T003715_A250ComDItem[0] == A250ComDItem ) && ( StringUtil.StrCmp(T003715_A244PrvCod[0], A244PrvCod) == 0 ) && ( StringUtil.StrCmp(T003715_A243ComCod[0], A243ComCod) == 0 ) && ( StringUtil.StrCmp(T003715_A149TipCod[0], A149TipCod) == 0 ) && ( StringUtil.StrCmp(T003715_A251ComDOrdCod[0], A251ComDOrdCod) < 0 ) ) )
            {
               A149TipCod = T003715_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = T003715_A243ComCod[0];
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = T003715_A244PrvCod[0];
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               A250ComDItem = T003715_A250ComDItem[0];
               AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
               A251ComDOrdCod = T003715_A251ComDOrdCod[0];
               AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
               RcdFound110 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey37110( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert37110( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound110 == 1 )
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) || ( A250ComDItem != Z250ComDItem ) || ( StringUtil.StrCmp(A251ComDOrdCod, Z251ComDOrdCod) != 0 ) )
               {
                  A149TipCod = Z149TipCod;
                  AssignAttri("", false, "A149TipCod", A149TipCod);
                  A243ComCod = Z243ComCod;
                  AssignAttri("", false, "A243ComCod", A243ComCod);
                  A244PrvCod = Z244PrvCod;
                  AssignAttri("", false, "A244PrvCod", A244PrvCod);
                  A250ComDItem = Z250ComDItem;
                  AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
                  A251ComDOrdCod = Z251ComDOrdCod;
                  AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
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
                  Update37110( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) || ( A250ComDItem != Z250ComDItem ) || ( StringUtil.StrCmp(A251ComDOrdCod, Z251ComDOrdCod) != 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert37110( ) ;
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
                     Insert37110( ) ;
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
         if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) || ( A250ComDItem != Z250ComDItem ) || ( StringUtil.StrCmp(A251ComDOrdCod, Z251ComDOrdCod) != 0 ) )
         {
            A149TipCod = Z149TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = Z243ComCod;
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = Z244PrvCod;
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A250ComDItem = Z250ComDItem;
            AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
            A251ComDOrdCod = Z251ComDOrdCod;
            AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
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
         GetKey37110( ) ;
         if ( RcdFound110 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "TIPCOD");
               AnyError = 1;
               GX_FocusControl = edtTipCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) || ( A250ComDItem != Z250ComDItem ) || ( StringUtil.StrCmp(A251ComDOrdCod, Z251ComDOrdCod) != 0 ) )
            {
               A149TipCod = Z149TipCod;
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A243ComCod = Z243ComCod;
               AssignAttri("", false, "A243ComCod", A243ComCod);
               A244PrvCod = Z244PrvCod;
               AssignAttri("", false, "A244PrvCod", A244PrvCod);
               A250ComDItem = Z250ComDItem;
               AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
               A251ComDOrdCod = Z251ComDOrdCod;
               AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
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
            if ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) || ( StringUtil.StrCmp(A243ComCod, Z243ComCod) != 0 ) || ( StringUtil.StrCmp(A244PrvCod, Z244PrvCod) != 0 ) || ( A250ComDItem != Z250ComDItem ) || ( StringUtil.StrCmp(A251ComDOrdCod, Z251ComDOrdCod) != 0 ) )
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
         context.RollbackDataStores("cpcomprasdet",pr_default);
         GX_FocusControl = edtComDProCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_370( ) ;
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
         if ( RcdFound110 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtComDProCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart37110( ) ;
         if ( RcdFound110 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComDProCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd37110( ) ;
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
         if ( RcdFound110 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComDProCod_Internalname;
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
         if ( RcdFound110 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComDProCod_Internalname;
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
         ScanStart37110( ) ;
         if ( RcdFound110 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound110 != 0 )
            {
               ScanNext37110( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtComDProCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd37110( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency37110( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00372 */
            pr_default.execute(0, new Object[] {A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCOMPRASDET"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z694ComDDsc, T00372_A694ComDDsc[0]) != 0 ) || ( Z685ComDCant != T00372_A685ComDCant[0] ) || ( Z686ComDPre != T00372_A686ComDPre[0] ) || ( Z690ComDTip != T00372_A690ComDTip[0] ) || ( Z689ComDDct != T00372_A689ComDDct[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z692ComDAuxCue, T00372_A692ComDAuxCue[0]) != 0 ) || ( StringUtil.StrCmp(Z691ComDAuxCod, T00372_A691ComDAuxCod[0]) != 0 ) || ( Z695ComDImp != T00372_A695ComDImp[0] ) || ( StringUtil.StrCmp(Z697ComDOrdTip, T00372_A697ComDOrdTip[0]) != 0 ) || ( StringUtil.StrCmp(Z254ComDProCod, T00372_A254ComDProCod[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z253ComDCueCod, T00372_A253ComDCueCod[0]) != 0 ) || ( StringUtil.StrCmp(Z252ComCosCod, T00372_A252ComCosCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z694ComDDsc, T00372_A694ComDDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDDsc");
                  GXUtil.WriteLogRaw("Old: ",Z694ComDDsc);
                  GXUtil.WriteLogRaw("Current: ",T00372_A694ComDDsc[0]);
               }
               if ( Z685ComDCant != T00372_A685ComDCant[0] )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDCant");
                  GXUtil.WriteLogRaw("Old: ",Z685ComDCant);
                  GXUtil.WriteLogRaw("Current: ",T00372_A685ComDCant[0]);
               }
               if ( Z686ComDPre != T00372_A686ComDPre[0] )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDPre");
                  GXUtil.WriteLogRaw("Old: ",Z686ComDPre);
                  GXUtil.WriteLogRaw("Current: ",T00372_A686ComDPre[0]);
               }
               if ( Z690ComDTip != T00372_A690ComDTip[0] )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDTip");
                  GXUtil.WriteLogRaw("Old: ",Z690ComDTip);
                  GXUtil.WriteLogRaw("Current: ",T00372_A690ComDTip[0]);
               }
               if ( Z689ComDDct != T00372_A689ComDDct[0] )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDDct");
                  GXUtil.WriteLogRaw("Old: ",Z689ComDDct);
                  GXUtil.WriteLogRaw("Current: ",T00372_A689ComDDct[0]);
               }
               if ( StringUtil.StrCmp(Z692ComDAuxCue, T00372_A692ComDAuxCue[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDAuxCue");
                  GXUtil.WriteLogRaw("Old: ",Z692ComDAuxCue);
                  GXUtil.WriteLogRaw("Current: ",T00372_A692ComDAuxCue[0]);
               }
               if ( StringUtil.StrCmp(Z691ComDAuxCod, T00372_A691ComDAuxCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDAuxCod");
                  GXUtil.WriteLogRaw("Old: ",Z691ComDAuxCod);
                  GXUtil.WriteLogRaw("Current: ",T00372_A691ComDAuxCod[0]);
               }
               if ( Z695ComDImp != T00372_A695ComDImp[0] )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDImp");
                  GXUtil.WriteLogRaw("Old: ",Z695ComDImp);
                  GXUtil.WriteLogRaw("Current: ",T00372_A695ComDImp[0]);
               }
               if ( StringUtil.StrCmp(Z697ComDOrdTip, T00372_A697ComDOrdTip[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDOrdTip");
                  GXUtil.WriteLogRaw("Old: ",Z697ComDOrdTip);
                  GXUtil.WriteLogRaw("Current: ",T00372_A697ComDOrdTip[0]);
               }
               if ( StringUtil.StrCmp(Z254ComDProCod, T00372_A254ComDProCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDProCod");
                  GXUtil.WriteLogRaw("Old: ",Z254ComDProCod);
                  GXUtil.WriteLogRaw("Current: ",T00372_A254ComDProCod[0]);
               }
               if ( StringUtil.StrCmp(Z253ComDCueCod, T00372_A253ComDCueCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComDCueCod");
                  GXUtil.WriteLogRaw("Old: ",Z253ComDCueCod);
                  GXUtil.WriteLogRaw("Current: ",T00372_A253ComDCueCod[0]);
               }
               if ( StringUtil.StrCmp(Z252ComCosCod, T00372_A252ComCosCod[0]) != 0 )
               {
                  GXUtil.WriteLog("cpcomprasdet:[seudo value changed for attri]"+"ComCosCod");
                  GXUtil.WriteLogRaw("Old: ",Z252ComCosCod);
                  GXUtil.WriteLogRaw("Current: ",T00372_A252ComCosCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CPCOMPRASDET"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert37110( )
      {
         BeforeValidate37110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable37110( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM37110( 0) ;
            CheckOptimisticConcurrency37110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm37110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert37110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003716 */
                     pr_default.execute(14, new Object[] {A250ComDItem, A251ComDOrdCod, A694ComDDsc, A685ComDCant, A686ComDPre, A690ComDTip, A689ComDDct, A692ComDAuxCue, A691ComDAuxCod, n695ComDImp, A695ComDImp, A697ComDOrdTip, A149TipCod, A243ComCod, A244PrvCod, n254ComDProCod, A254ComDProCod, n253ComDCueCod, A253ComDCueCod, n252ComCosCod, A252ComCosCod});
                     pr_default.close(14);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRASDET");
                     if ( (pr_default.getStatus(14) == 1) )
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
                           ResetCaption370( ) ;
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
               Load37110( ) ;
            }
            EndLevel37110( ) ;
         }
         CloseExtendedTableCursors37110( ) ;
      }

      protected void Update37110( )
      {
         BeforeValidate37110( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable37110( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency37110( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm37110( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate37110( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003717 */
                     pr_default.execute(15, new Object[] {A694ComDDsc, A685ComDCant, A686ComDPre, A690ComDTip, A689ComDDct, A692ComDAuxCue, A691ComDAuxCod, n695ComDImp, A695ComDImp, A697ComDOrdTip, n254ComDProCod, A254ComDProCod, n253ComDCueCod, A253ComDCueCod, n252ComCosCod, A252ComCosCod, A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
                     pr_default.close(15);
                     dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRASDET");
                     if ( (pr_default.getStatus(15) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CPCOMPRASDET"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate37110( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption370( ) ;
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
            EndLevel37110( ) ;
         }
         CloseExtendedTableCursors37110( ) ;
      }

      protected void DeferredUpdate37110( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate37110( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency37110( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls37110( ) ;
            AfterConfirm37110( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete37110( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003718 */
                  pr_default.execute(16, new Object[] {A149TipCod, A243ComCod, A244PrvCod, A250ComDItem, A251ComDOrdCod});
                  pr_default.close(16);
                  dsDefault.SmartCacheProvider.SetUpdated("CPCOMPRASDET");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound110 == 0 )
                        {
                           InitAll37110( ) ;
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
                        ResetCaption370( ) ;
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
         sMode110 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel37110( ) ;
         Gx_mode = sMode110;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls37110( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            A688ComDSub = NumberUtil.Round( A685ComDCant*A686ComDPre, 2);
            AssignAttri("", false, "A688ComDSub", StringUtil.LTrimStr( A688ComDSub, 15, 2));
            /* Using cursor T003719 */
            pr_default.execute(17, new Object[] {n253ComDCueCod, A253ComDCueCod});
            A693ComDCueCos = T003719_A693ComDCueCos[0];
            A699ComDTipACod = T003719_A699ComDTipACod[0];
            n699ComDTipACod = T003719_n699ComDTipACod[0];
            pr_default.close(17);
            A687ComDDescuento = NumberUtil.Round( A688ComDSub*A689ComDDct/ (decimal)(100), 2);
            AssignAttri("", false, "A687ComDDescuento", StringUtil.LTrimStr( A687ComDDescuento, 15, 2));
            A684ComDTot = (decimal)((A685ComDCant*A686ComDPre)-A687ComDDescuento);
            AssignAttri("", false, "A684ComDTot", StringUtil.LTrimStr( A684ComDTot, 15, 2));
            if ( A690ComDTip == 1 )
            {
               A696ComDIna = A684ComDTot;
               AssignAttri("", false, "A696ComDIna", StringUtil.LTrimStr( A696ComDIna, 15, 2));
            }
            else
            {
               A696ComDIna = 0;
               AssignAttri("", false, "A696ComDIna", StringUtil.LTrimStr( A696ComDIna, 15, 2));
            }
            if ( A690ComDTip == 0 )
            {
               A683ComDAfe = A684ComDTot;
               AssignAttri("", false, "A683ComDAfe", StringUtil.LTrimStr( A683ComDAfe, 15, 2));
            }
            else
            {
               A683ComDAfe = 0;
               AssignAttri("", false, "A683ComDAfe", StringUtil.LTrimStr( A683ComDAfe, 15, 2));
            }
            A700ComDTotImp = ((A695ComDImp==1) ? A684ComDTot : (decimal)(0));
            AssignAttri("", false, "A700ComDTotImp", StringUtil.LTrimStr( A700ComDTotImp, 15, 2));
         }
      }

      protected void EndLevel37110( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete37110( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(17);
            context.CommitDataStores("cpcomprasdet",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues370( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(17);
            context.RollbackDataStores("cpcomprasdet",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart37110( )
      {
         /* Using cursor T003720 */
         pr_default.execute(18);
         RcdFound110 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound110 = 1;
            A149TipCod = T003720_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = T003720_A243ComCod[0];
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = T003720_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A250ComDItem = T003720_A250ComDItem[0];
            AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
            A251ComDOrdCod = T003720_A251ComDOrdCod[0];
            AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext37110( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound110 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound110 = 1;
            A149TipCod = T003720_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A243ComCod = T003720_A243ComCod[0];
            AssignAttri("", false, "A243ComCod", A243ComCod);
            A244PrvCod = T003720_A244PrvCod[0];
            AssignAttri("", false, "A244PrvCod", A244PrvCod);
            A250ComDItem = T003720_A250ComDItem[0];
            AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
            A251ComDOrdCod = T003720_A251ComDOrdCod[0];
            AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
         }
      }

      protected void ScanEnd37110( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm37110( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert37110( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate37110( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete37110( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete37110( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate37110( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes37110( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtComCod_Enabled = 0;
         AssignProp("", false, edtComCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComCod_Enabled), 5, 0), true);
         edtPrvCod_Enabled = 0;
         AssignProp("", false, edtPrvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrvCod_Enabled), 5, 0), true);
         edtComDItem_Enabled = 0;
         AssignProp("", false, edtComDItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDItem_Enabled), 5, 0), true);
         edtComDOrdCod_Enabled = 0;
         AssignProp("", false, edtComDOrdCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDOrdCod_Enabled), 5, 0), true);
         edtComDProCod_Enabled = 0;
         AssignProp("", false, edtComDProCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDProCod_Enabled), 5, 0), true);
         edtComDDsc_Enabled = 0;
         AssignProp("", false, edtComDDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDDsc_Enabled), 5, 0), true);
         edtComDCant_Enabled = 0;
         AssignProp("", false, edtComDCant_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDCant_Enabled), 5, 0), true);
         edtComDPre_Enabled = 0;
         AssignProp("", false, edtComDPre_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDPre_Enabled), 5, 0), true);
         edtComDTip_Enabled = 0;
         AssignProp("", false, edtComDTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDTip_Enabled), 5, 0), true);
         edtComDCueCod_Enabled = 0;
         AssignProp("", false, edtComDCueCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDCueCod_Enabled), 5, 0), true);
         edtComCosCod_Enabled = 0;
         AssignProp("", false, edtComCosCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComCosCod_Enabled), 5, 0), true);
         edtComDDct_Enabled = 0;
         AssignProp("", false, edtComDDct_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDDct_Enabled), 5, 0), true);
         edtComDAuxCue_Enabled = 0;
         AssignProp("", false, edtComDAuxCue_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDAuxCue_Enabled), 5, 0), true);
         edtComDAuxCod_Enabled = 0;
         AssignProp("", false, edtComDAuxCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDAuxCod_Enabled), 5, 0), true);
         edtComDImp_Enabled = 0;
         AssignProp("", false, edtComDImp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDImp_Enabled), 5, 0), true);
         edtComDOrdTip_Enabled = 0;
         AssignProp("", false, edtComDOrdTip_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtComDOrdTip_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes37110( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues370( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810245922", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cpcomprasdet.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z243ComCod", StringUtil.RTrim( Z243ComCod));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z250ComDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z250ComDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z251ComDOrdCod", StringUtil.RTrim( Z251ComDOrdCod));
         GxWebStd.gx_hidden_field( context, "Z694ComDDsc", StringUtil.RTrim( Z694ComDDsc));
         GxWebStd.gx_hidden_field( context, "Z685ComDCant", StringUtil.LTrim( StringUtil.NToC( Z685ComDCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z686ComDPre", StringUtil.LTrim( StringUtil.NToC( Z686ComDPre, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z690ComDTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z690ComDTip), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z689ComDDct", StringUtil.LTrim( StringUtil.NToC( Z689ComDDct, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z692ComDAuxCue", StringUtil.RTrim( Z692ComDAuxCue));
         GxWebStd.gx_hidden_field( context, "Z691ComDAuxCod", StringUtil.RTrim( Z691ComDAuxCod));
         GxWebStd.gx_hidden_field( context, "Z695ComDImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z695ComDImp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z697ComDOrdTip", Z697ComDOrdTip);
         GxWebStd.gx_hidden_field( context, "Z254ComDProCod", StringUtil.RTrim( Z254ComDProCod));
         GxWebStd.gx_hidden_field( context, "Z253ComDCueCod", StringUtil.RTrim( Z253ComDCueCod));
         GxWebStd.gx_hidden_field( context, "Z252ComCosCod", StringUtil.RTrim( Z252ComCosCod));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "COMDSUB", StringUtil.LTrim( StringUtil.NToC( A688ComDSub, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMDDESCUENTO", StringUtil.LTrim( StringUtil.NToC( A687ComDDescuento, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMDTOT", StringUtil.LTrim( StringUtil.NToC( A684ComDTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMDINA", StringUtil.LTrim( StringUtil.NToC( A696ComDIna, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMDAFE", StringUtil.LTrim( StringUtil.NToC( A683ComDAfe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMDTOTIMP", StringUtil.LTrim( StringUtil.NToC( A700ComDTotImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMDCUECOS", StringUtil.LTrim( StringUtil.NToC( (decimal)(A693ComDCueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "COMDTIPACOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A699ComDTipACod), 6, 0, ".", "")));
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
         return formatLink("cpcomprasdet.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CPCOMPRASDET" ;
      }

      public override string GetPgmdesc( )
      {
         return "Compras - Detalle" ;
      }

      protected void InitializeNonKey37110( )
      {
         A700ComDTotImp = 0;
         AssignAttri("", false, "A700ComDTotImp", StringUtil.LTrimStr( A700ComDTotImp, 15, 2));
         A687ComDDescuento = 0;
         AssignAttri("", false, "A687ComDDescuento", StringUtil.LTrimStr( A687ComDDescuento, 15, 2));
         A683ComDAfe = 0;
         AssignAttri("", false, "A683ComDAfe", StringUtil.LTrimStr( A683ComDAfe, 15, 2));
         A696ComDIna = 0;
         AssignAttri("", false, "A696ComDIna", StringUtil.LTrimStr( A696ComDIna, 15, 2));
         A684ComDTot = 0;
         AssignAttri("", false, "A684ComDTot", StringUtil.LTrimStr( A684ComDTot, 15, 2));
         A688ComDSub = 0;
         AssignAttri("", false, "A688ComDSub", StringUtil.LTrimStr( A688ComDSub, 15, 2));
         A254ComDProCod = "";
         n254ComDProCod = false;
         AssignAttri("", false, "A254ComDProCod", A254ComDProCod);
         n254ComDProCod = (String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ? true : false);
         A694ComDDsc = "";
         AssignAttri("", false, "A694ComDDsc", A694ComDDsc);
         A685ComDCant = 0;
         AssignAttri("", false, "A685ComDCant", StringUtil.LTrimStr( A685ComDCant, 15, 4));
         A686ComDPre = 0;
         AssignAttri("", false, "A686ComDPre", StringUtil.LTrimStr( A686ComDPre, 18, 6));
         A690ComDTip = 0;
         AssignAttri("", false, "A690ComDTip", StringUtil.Str( (decimal)(A690ComDTip), 1, 0));
         A253ComDCueCod = "";
         n253ComDCueCod = false;
         AssignAttri("", false, "A253ComDCueCod", A253ComDCueCod);
         n253ComDCueCod = (String.IsNullOrEmpty(StringUtil.RTrim( A253ComDCueCod)) ? true : false);
         A252ComCosCod = "";
         n252ComCosCod = false;
         AssignAttri("", false, "A252ComCosCod", A252ComCosCod);
         A689ComDDct = 0;
         AssignAttri("", false, "A689ComDDct", StringUtil.LTrimStr( A689ComDDct, 15, 2));
         A692ComDAuxCue = "";
         AssignAttri("", false, "A692ComDAuxCue", A692ComDAuxCue);
         A691ComDAuxCod = "";
         AssignAttri("", false, "A691ComDAuxCod", A691ComDAuxCod);
         A695ComDImp = 0;
         n695ComDImp = false;
         AssignAttri("", false, "A695ComDImp", StringUtil.Str( (decimal)(A695ComDImp), 1, 0));
         n695ComDImp = ((0==A695ComDImp) ? true : false);
         A697ComDOrdTip = "";
         AssignAttri("", false, "A697ComDOrdTip", A697ComDOrdTip);
         A699ComDTipACod = 0;
         n699ComDTipACod = false;
         AssignAttri("", false, "A699ComDTipACod", StringUtil.LTrimStr( (decimal)(A699ComDTipACod), 6, 0));
         A693ComDCueCos = 0;
         AssignAttri("", false, "A693ComDCueCos", StringUtil.Str( (decimal)(A693ComDCueCos), 1, 0));
         Z694ComDDsc = "";
         Z685ComDCant = 0;
         Z686ComDPre = 0;
         Z690ComDTip = 0;
         Z689ComDDct = 0;
         Z692ComDAuxCue = "";
         Z691ComDAuxCod = "";
         Z695ComDImp = 0;
         Z697ComDOrdTip = "";
         Z254ComDProCod = "";
         Z253ComDCueCod = "";
         Z252ComCosCod = "";
      }

      protected void InitAll37110( )
      {
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         A243ComCod = "";
         AssignAttri("", false, "A243ComCod", A243ComCod);
         A244PrvCod = "";
         AssignAttri("", false, "A244PrvCod", A244PrvCod);
         A250ComDItem = 0;
         AssignAttri("", false, "A250ComDItem", StringUtil.LTrimStr( (decimal)(A250ComDItem), 4, 0));
         A251ComDOrdCod = "";
         AssignAttri("", false, "A251ComDOrdCod", A251ComDOrdCod);
         InitializeNonKey37110( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810245938", true, true);
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
         context.AddJavascriptSource("cpcomprasdet.js", "?202281810245938", false, true);
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
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtComDItem_Internalname = "COMDITEM";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtComDOrdCod_Internalname = "COMDORDCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtComDProCod_Internalname = "COMDPROCOD";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtComDDsc_Internalname = "COMDDSC";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtComDCant_Internalname = "COMDCANT";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtComDPre_Internalname = "COMDPRE";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtComDTip_Internalname = "COMDTIP";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtComDCueCod_Internalname = "COMDCUECOD";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtComCosCod_Internalname = "COMCOSCOD";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtComDDct_Internalname = "COMDDCT";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtComDAuxCue_Internalname = "COMDAUXCUE";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtComDAuxCod_Internalname = "COMDAUXCOD";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtComDImp_Internalname = "COMDIMP";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtComDOrdTip_Internalname = "COMDORDTIP";
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
         Form.Caption = "Compras - Detalle";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtComDOrdTip_Jsonclick = "";
         edtComDOrdTip_Enabled = 1;
         edtComDImp_Jsonclick = "";
         edtComDImp_Enabled = 1;
         edtComDAuxCod_Jsonclick = "";
         edtComDAuxCod_Enabled = 1;
         edtComDAuxCue_Jsonclick = "";
         edtComDAuxCue_Enabled = 1;
         edtComDDct_Jsonclick = "";
         edtComDDct_Enabled = 1;
         edtComCosCod_Jsonclick = "";
         edtComCosCod_Enabled = 1;
         edtComDCueCod_Jsonclick = "";
         edtComDCueCod_Enabled = 1;
         edtComDTip_Jsonclick = "";
         edtComDTip_Enabled = 1;
         edtComDPre_Jsonclick = "";
         edtComDPre_Enabled = 1;
         edtComDCant_Jsonclick = "";
         edtComDCant_Enabled = 1;
         edtComDDsc_Jsonclick = "";
         edtComDDsc_Enabled = 1;
         edtComDProCod_Jsonclick = "";
         edtComDProCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtComDOrdCod_Jsonclick = "";
         edtComDOrdCod_Enabled = 1;
         edtComDItem_Jsonclick = "";
         edtComDItem_Enabled = 1;
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
         /* Using cursor T003721 */
         pr_default.execute(19, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(19);
         GX_FocusControl = edtComDProCod_Internalname;
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

      public void Valid_Prvcod( )
      {
         /* Using cursor T003721 */
         pr_default.execute(19, new Object[] {A149TipCod, A243ComCod, A244PrvCod});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No existe 'Documentos de proveedores'.", "ForeignKeyNotFound", 1, "PRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
         }
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Comdordcod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A254ComDProCod", StringUtil.RTrim( A254ComDProCod));
         AssignAttri("", false, "A694ComDDsc", StringUtil.RTrim( A694ComDDsc));
         AssignAttri("", false, "A685ComDCant", StringUtil.LTrim( StringUtil.NToC( A685ComDCant, 15, 4, ".", "")));
         AssignAttri("", false, "A686ComDPre", StringUtil.LTrim( StringUtil.NToC( A686ComDPre, 18, 6, ".", "")));
         AssignAttri("", false, "A690ComDTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(A690ComDTip), 1, 0, ".", "")));
         AssignAttri("", false, "A253ComDCueCod", StringUtil.RTrim( A253ComDCueCod));
         AssignAttri("", false, "A252ComCosCod", StringUtil.RTrim( A252ComCosCod));
         AssignAttri("", false, "A689ComDDct", StringUtil.LTrim( StringUtil.NToC( A689ComDDct, 15, 2, ".", "")));
         AssignAttri("", false, "A692ComDAuxCue", StringUtil.RTrim( A692ComDAuxCue));
         AssignAttri("", false, "A691ComDAuxCod", StringUtil.RTrim( A691ComDAuxCod));
         AssignAttri("", false, "A695ComDImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(A695ComDImp), 1, 0, ".", "")));
         AssignAttri("", false, "A697ComDOrdTip", A697ComDOrdTip);
         AssignAttri("", false, "A688ComDSub", StringUtil.LTrim( StringUtil.NToC( A688ComDSub, 15, 2, ".", "")));
         AssignAttri("", false, "A687ComDDescuento", StringUtil.LTrim( StringUtil.NToC( A687ComDDescuento, 15, 2, ".", "")));
         AssignAttri("", false, "A684ComDTot", StringUtil.LTrim( StringUtil.NToC( A684ComDTot, 15, 2, ".", "")));
         AssignAttri("", false, "A696ComDIna", StringUtil.LTrim( StringUtil.NToC( A696ComDIna, 15, 2, ".", "")));
         AssignAttri("", false, "A683ComDAfe", StringUtil.LTrim( StringUtil.NToC( A683ComDAfe, 15, 2, ".", "")));
         AssignAttri("", false, "A700ComDTotImp", StringUtil.LTrim( StringUtil.NToC( A700ComDTotImp, 15, 2, ".", "")));
         AssignAttri("", false, "A693ComDCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A693ComDCueCos), 1, 0, ".", "")));
         AssignAttri("", false, "A699ComDTipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A699ComDTipACod), 6, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z243ComCod", StringUtil.RTrim( Z243ComCod));
         GxWebStd.gx_hidden_field( context, "Z244PrvCod", StringUtil.RTrim( Z244PrvCod));
         GxWebStd.gx_hidden_field( context, "Z250ComDItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z250ComDItem), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z251ComDOrdCod", StringUtil.RTrim( Z251ComDOrdCod));
         GxWebStd.gx_hidden_field( context, "Z254ComDProCod", StringUtil.RTrim( Z254ComDProCod));
         GxWebStd.gx_hidden_field( context, "Z694ComDDsc", StringUtil.RTrim( Z694ComDDsc));
         GxWebStd.gx_hidden_field( context, "Z685ComDCant", StringUtil.LTrim( StringUtil.NToC( Z685ComDCant, 15, 4, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z686ComDPre", StringUtil.LTrim( StringUtil.NToC( Z686ComDPre, 18, 6, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z690ComDTip", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z690ComDTip), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z253ComDCueCod", StringUtil.RTrim( Z253ComDCueCod));
         GxWebStd.gx_hidden_field( context, "Z252ComCosCod", StringUtil.RTrim( Z252ComCosCod));
         GxWebStd.gx_hidden_field( context, "Z689ComDDct", StringUtil.LTrim( StringUtil.NToC( Z689ComDDct, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z692ComDAuxCue", StringUtil.RTrim( Z692ComDAuxCue));
         GxWebStd.gx_hidden_field( context, "Z691ComDAuxCod", StringUtil.RTrim( Z691ComDAuxCod));
         GxWebStd.gx_hidden_field( context, "Z695ComDImp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z695ComDImp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z697ComDOrdTip", Z697ComDOrdTip);
         GxWebStd.gx_hidden_field( context, "Z688ComDSub", StringUtil.LTrim( StringUtil.NToC( Z688ComDSub, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z687ComDDescuento", StringUtil.LTrim( StringUtil.NToC( Z687ComDDescuento, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z684ComDTot", StringUtil.LTrim( StringUtil.NToC( Z684ComDTot, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z696ComDIna", StringUtil.LTrim( StringUtil.NToC( Z696ComDIna, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z683ComDAfe", StringUtil.LTrim( StringUtil.NToC( Z683ComDAfe, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z700ComDTotImp", StringUtil.LTrim( StringUtil.NToC( Z700ComDTotImp, 15, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z693ComDCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z693ComDCueCos), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z699ComDTipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z699ComDTipACod), 6, 0, ".", "")));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Comdprocod( )
      {
         n254ComDProCod = false;
         /* Using cursor T003722 */
         pr_default.execute(20, new Object[] {n254ComDProCod, A254ComDProCod});
         if ( (pr_default.getStatus(20) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A254ComDProCod)) ) )
            {
               GX_msglist.addItem("No existe 'Productos'.", "ForeignKeyNotFound", 1, "COMDPROCOD");
               AnyError = 1;
               GX_FocusControl = edtComDProCod_Internalname;
            }
         }
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Comdcuecod( )
      {
         n253ComDCueCod = false;
         n699ComDTipACod = false;
         /* Using cursor T003719 */
         pr_default.execute(17, new Object[] {n253ComDCueCod, A253ComDCueCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A253ComDCueCod)) ) )
            {
               GX_msglist.addItem("No existe 'Cuenta Contable'.", "ForeignKeyNotFound", 1, "COMDCUECOD");
               AnyError = 1;
               GX_FocusControl = edtComDCueCod_Internalname;
            }
         }
         A693ComDCueCos = T003719_A693ComDCueCos[0];
         A699ComDTipACod = T003719_A699ComDTipACod[0];
         n699ComDTipACod = T003719_n699ComDTipACod[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A693ComDCueCos", StringUtil.LTrim( StringUtil.NToC( (decimal)(A693ComDCueCos), 1, 0, ".", "")));
         AssignAttri("", false, "A699ComDTipACod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A699ComDTipACod), 6, 0, ".", "")));
      }

      public void Valid_Comcoscod( )
      {
         n252ComCosCod = false;
         /* Using cursor T003723 */
         pr_default.execute(21, new Object[] {n252ComCosCod, A252ComCosCod});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A252ComCosCod)) ) )
            {
               GX_msglist.addItem("No existe 'Centro Costo'.", "ForeignKeyNotFound", 1, "COMCOSCOD");
               AnyError = 1;
               GX_FocusControl = edtComCosCod_Internalname;
            }
         }
         pr_default.close(21);
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
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[]");
         setEventMetadata("VALID_TIPCOD",",oparms:[]}");
         setEventMetadata("VALID_COMCOD","{handler:'Valid_Comcod',iparms:[]");
         setEventMetadata("VALID_COMCOD",",oparms:[]}");
         setEventMetadata("VALID_PRVCOD","{handler:'Valid_Prvcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A243ComCod',fld:'COMCOD',pic:''},{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'}]");
         setEventMetadata("VALID_PRVCOD",",oparms:[]}");
         setEventMetadata("VALID_COMDITEM","{handler:'Valid_Comditem',iparms:[]");
         setEventMetadata("VALID_COMDITEM",",oparms:[]}");
         setEventMetadata("VALID_COMDORDCOD","{handler:'Valid_Comdordcod',iparms:[{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A243ComCod',fld:'COMCOD',pic:''},{av:'A244PrvCod',fld:'PRVCOD',pic:'@!'},{av:'A250ComDItem',fld:'COMDITEM',pic:'ZZZ9'},{av:'A251ComDOrdCod',fld:'COMDORDCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_COMDORDCOD",",oparms:[{av:'A254ComDProCod',fld:'COMDPROCOD',pic:'@!'},{av:'A694ComDDsc',fld:'COMDDSC',pic:''},{av:'A685ComDCant',fld:'COMDCANT',pic:'ZZZZ,ZZZ,ZZ9.9999'},{av:'A686ComDPre',fld:'COMDPRE',pic:'ZZZZZ,ZZZ,ZZ9.999999'},{av:'A690ComDTip',fld:'COMDTIP',pic:'9'},{av:'A253ComDCueCod',fld:'COMDCUECOD',pic:''},{av:'A252ComCosCod',fld:'COMCOSCOD',pic:''},{av:'A689ComDDct',fld:'COMDDCT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A692ComDAuxCue',fld:'COMDAUXCUE',pic:''},{av:'A691ComDAuxCod',fld:'COMDAUXCOD',pic:''},{av:'A695ComDImp',fld:'COMDIMP',pic:'9'},{av:'A697ComDOrdTip',fld:'COMDORDTIP',pic:''},{av:'A688ComDSub',fld:'COMDSUB',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A687ComDDescuento',fld:'COMDDESCUENTO',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A684ComDTot',fld:'COMDTOT',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A696ComDIna',fld:'COMDINA',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A683ComDAfe',fld:'COMDAFE',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A700ComDTotImp',fld:'COMDTOTIMP',pic:'ZZZZZZ,ZZZ,ZZ9.99'},{av:'A693ComDCueCos',fld:'COMDCUECOS',pic:'9'},{av:'A699ComDTipACod',fld:'COMDTIPACOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z149TipCod'},{av:'Z243ComCod'},{av:'Z244PrvCod'},{av:'Z250ComDItem'},{av:'Z251ComDOrdCod'},{av:'Z254ComDProCod'},{av:'Z694ComDDsc'},{av:'Z685ComDCant'},{av:'Z686ComDPre'},{av:'Z690ComDTip'},{av:'Z253ComDCueCod'},{av:'Z252ComCosCod'},{av:'Z689ComDDct'},{av:'Z692ComDAuxCue'},{av:'Z691ComDAuxCod'},{av:'Z695ComDImp'},{av:'Z697ComDOrdTip'},{av:'Z688ComDSub'},{av:'Z687ComDDescuento'},{av:'Z684ComDTot'},{av:'Z696ComDIna'},{av:'Z683ComDAfe'},{av:'Z700ComDTotImp'},{av:'Z693ComDCueCos'},{av:'Z699ComDTipACod'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_COMDPROCOD","{handler:'Valid_Comdprocod',iparms:[{av:'A254ComDProCod',fld:'COMDPROCOD',pic:'@!'}]");
         setEventMetadata("VALID_COMDPROCOD",",oparms:[]}");
         setEventMetadata("VALID_COMDCANT","{handler:'Valid_Comdcant',iparms:[]");
         setEventMetadata("VALID_COMDCANT",",oparms:[]}");
         setEventMetadata("VALID_COMDPRE","{handler:'Valid_Comdpre',iparms:[]");
         setEventMetadata("VALID_COMDPRE",",oparms:[]}");
         setEventMetadata("VALID_COMDTIP","{handler:'Valid_Comdtip',iparms:[]");
         setEventMetadata("VALID_COMDTIP",",oparms:[]}");
         setEventMetadata("VALID_COMDCUECOD","{handler:'Valid_Comdcuecod',iparms:[{av:'A253ComDCueCod',fld:'COMDCUECOD',pic:''},{av:'A693ComDCueCos',fld:'COMDCUECOS',pic:'9'},{av:'A699ComDTipACod',fld:'COMDTIPACOD',pic:'ZZZZZ9'}]");
         setEventMetadata("VALID_COMDCUECOD",",oparms:[{av:'A693ComDCueCos',fld:'COMDCUECOS',pic:'9'},{av:'A699ComDTipACod',fld:'COMDTIPACOD',pic:'ZZZZZ9'}]}");
         setEventMetadata("VALID_COMCOSCOD","{handler:'Valid_Comcoscod',iparms:[{av:'A252ComCosCod',fld:'COMCOSCOD',pic:''}]");
         setEventMetadata("VALID_COMCOSCOD",",oparms:[]}");
         setEventMetadata("VALID_COMDDCT","{handler:'Valid_Comddct',iparms:[]");
         setEventMetadata("VALID_COMDDCT",",oparms:[]}");
         setEventMetadata("VALID_COMDIMP","{handler:'Valid_Comdimp',iparms:[]");
         setEventMetadata("VALID_COMDIMP",",oparms:[]}");
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
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(17);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z149TipCod = "";
         Z243ComCod = "";
         Z244PrvCod = "";
         Z251ComDOrdCod = "";
         Z694ComDDsc = "";
         Z692ComDAuxCue = "";
         Z691ComDAuxCod = "";
         Z697ComDOrdTip = "";
         Z254ComDProCod = "";
         Z253ComDCueCod = "";
         Z252ComCosCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A149TipCod = "";
         A243ComCod = "";
         A244PrvCod = "";
         A254ComDProCod = "";
         A253ComDCueCod = "";
         A252ComCosCod = "";
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
         lblTextblock5_Jsonclick = "";
         A251ComDOrdCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock6_Jsonclick = "";
         lblTextblock7_Jsonclick = "";
         A694ComDDsc = "";
         lblTextblock8_Jsonclick = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         A692ComDAuxCue = "";
         lblTextblock15_Jsonclick = "";
         A691ComDAuxCod = "";
         lblTextblock16_Jsonclick = "";
         lblTextblock17_Jsonclick = "";
         A697ComDOrdTip = "";
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
         T00378_A250ComDItem = new short[1] ;
         T00378_A251ComDOrdCod = new string[] {""} ;
         T00378_A694ComDDsc = new string[] {""} ;
         T00378_A685ComDCant = new decimal[1] ;
         T00378_A686ComDPre = new decimal[1] ;
         T00378_A690ComDTip = new short[1] ;
         T00378_A689ComDDct = new decimal[1] ;
         T00378_A692ComDAuxCue = new string[] {""} ;
         T00378_A691ComDAuxCod = new string[] {""} ;
         T00378_A695ComDImp = new short[1] ;
         T00378_n695ComDImp = new bool[] {false} ;
         T00378_A697ComDOrdTip = new string[] {""} ;
         T00378_A693ComDCueCos = new short[1] ;
         T00378_A149TipCod = new string[] {""} ;
         T00378_A243ComCod = new string[] {""} ;
         T00378_A244PrvCod = new string[] {""} ;
         T00378_A254ComDProCod = new string[] {""} ;
         T00378_n254ComDProCod = new bool[] {false} ;
         T00378_A253ComDCueCod = new string[] {""} ;
         T00378_n253ComDCueCod = new bool[] {false} ;
         T00378_A252ComCosCod = new string[] {""} ;
         T00378_n252ComCosCod = new bool[] {false} ;
         T00378_A699ComDTipACod = new int[1] ;
         T00378_n699ComDTipACod = new bool[] {false} ;
         T00374_A149TipCod = new string[] {""} ;
         T00375_A254ComDProCod = new string[] {""} ;
         T00375_n254ComDProCod = new bool[] {false} ;
         T00376_A693ComDCueCos = new short[1] ;
         T00376_A699ComDTipACod = new int[1] ;
         T00376_n699ComDTipACod = new bool[] {false} ;
         T00377_A252ComCosCod = new string[] {""} ;
         T00377_n252ComCosCod = new bool[] {false} ;
         T00379_A149TipCod = new string[] {""} ;
         T003710_A254ComDProCod = new string[] {""} ;
         T003710_n254ComDProCod = new bool[] {false} ;
         T003711_A693ComDCueCos = new short[1] ;
         T003711_A699ComDTipACod = new int[1] ;
         T003711_n699ComDTipACod = new bool[] {false} ;
         T003712_A252ComCosCod = new string[] {""} ;
         T003712_n252ComCosCod = new bool[] {false} ;
         T003713_A149TipCod = new string[] {""} ;
         T003713_A243ComCod = new string[] {""} ;
         T003713_A244PrvCod = new string[] {""} ;
         T003713_A250ComDItem = new short[1] ;
         T003713_A251ComDOrdCod = new string[] {""} ;
         T00373_A250ComDItem = new short[1] ;
         T00373_A251ComDOrdCod = new string[] {""} ;
         T00373_A694ComDDsc = new string[] {""} ;
         T00373_A685ComDCant = new decimal[1] ;
         T00373_A686ComDPre = new decimal[1] ;
         T00373_A690ComDTip = new short[1] ;
         T00373_A689ComDDct = new decimal[1] ;
         T00373_A692ComDAuxCue = new string[] {""} ;
         T00373_A691ComDAuxCod = new string[] {""} ;
         T00373_A695ComDImp = new short[1] ;
         T00373_n695ComDImp = new bool[] {false} ;
         T00373_A697ComDOrdTip = new string[] {""} ;
         T00373_A149TipCod = new string[] {""} ;
         T00373_A243ComCod = new string[] {""} ;
         T00373_A244PrvCod = new string[] {""} ;
         T00373_A254ComDProCod = new string[] {""} ;
         T00373_n254ComDProCod = new bool[] {false} ;
         T00373_A253ComDCueCod = new string[] {""} ;
         T00373_n253ComDCueCod = new bool[] {false} ;
         T00373_A252ComCosCod = new string[] {""} ;
         T00373_n252ComCosCod = new bool[] {false} ;
         sMode110 = "";
         T003714_A149TipCod = new string[] {""} ;
         T003714_A243ComCod = new string[] {""} ;
         T003714_A244PrvCod = new string[] {""} ;
         T003714_A250ComDItem = new short[1] ;
         T003714_A251ComDOrdCod = new string[] {""} ;
         T003715_A149TipCod = new string[] {""} ;
         T003715_A243ComCod = new string[] {""} ;
         T003715_A244PrvCod = new string[] {""} ;
         T003715_A250ComDItem = new short[1] ;
         T003715_A251ComDOrdCod = new string[] {""} ;
         T00372_A250ComDItem = new short[1] ;
         T00372_A251ComDOrdCod = new string[] {""} ;
         T00372_A694ComDDsc = new string[] {""} ;
         T00372_A685ComDCant = new decimal[1] ;
         T00372_A686ComDPre = new decimal[1] ;
         T00372_A690ComDTip = new short[1] ;
         T00372_A689ComDDct = new decimal[1] ;
         T00372_A692ComDAuxCue = new string[] {""} ;
         T00372_A691ComDAuxCod = new string[] {""} ;
         T00372_A695ComDImp = new short[1] ;
         T00372_n695ComDImp = new bool[] {false} ;
         T00372_A697ComDOrdTip = new string[] {""} ;
         T00372_A149TipCod = new string[] {""} ;
         T00372_A243ComCod = new string[] {""} ;
         T00372_A244PrvCod = new string[] {""} ;
         T00372_A254ComDProCod = new string[] {""} ;
         T00372_n254ComDProCod = new bool[] {false} ;
         T00372_A253ComDCueCod = new string[] {""} ;
         T00372_n253ComDCueCod = new bool[] {false} ;
         T00372_A252ComCosCod = new string[] {""} ;
         T00372_n252ComCosCod = new bool[] {false} ;
         T003719_A693ComDCueCos = new short[1] ;
         T003719_A699ComDTipACod = new int[1] ;
         T003719_n699ComDTipACod = new bool[] {false} ;
         T003720_A149TipCod = new string[] {""} ;
         T003720_A243ComCod = new string[] {""} ;
         T003720_A244PrvCod = new string[] {""} ;
         T003720_A250ComDItem = new short[1] ;
         T003720_A251ComDOrdCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T003721_A149TipCod = new string[] {""} ;
         ZZ149TipCod = "";
         ZZ243ComCod = "";
         ZZ244PrvCod = "";
         ZZ251ComDOrdCod = "";
         ZZ254ComDProCod = "";
         ZZ694ComDDsc = "";
         ZZ253ComDCueCod = "";
         ZZ252ComCosCod = "";
         ZZ692ComDAuxCue = "";
         ZZ691ComDAuxCod = "";
         ZZ697ComDOrdTip = "";
         T003722_A254ComDProCod = new string[] {""} ;
         T003722_n254ComDProCod = new bool[] {false} ;
         T003723_A252ComCosCod = new string[] {""} ;
         T003723_n252ComCosCod = new bool[] {false} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cpcomprasdet__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cpcomprasdet__default(),
            new Object[][] {
                new Object[] {
               T00372_A250ComDItem, T00372_A251ComDOrdCod, T00372_A694ComDDsc, T00372_A685ComDCant, T00372_A686ComDPre, T00372_A690ComDTip, T00372_A689ComDDct, T00372_A692ComDAuxCue, T00372_A691ComDAuxCod, T00372_A695ComDImp,
               T00372_n695ComDImp, T00372_A697ComDOrdTip, T00372_A149TipCod, T00372_A243ComCod, T00372_A244PrvCod, T00372_A254ComDProCod, T00372_n254ComDProCod, T00372_A253ComDCueCod, T00372_n253ComDCueCod, T00372_A252ComCosCod,
               T00372_n252ComCosCod
               }
               , new Object[] {
               T00373_A250ComDItem, T00373_A251ComDOrdCod, T00373_A694ComDDsc, T00373_A685ComDCant, T00373_A686ComDPre, T00373_A690ComDTip, T00373_A689ComDDct, T00373_A692ComDAuxCue, T00373_A691ComDAuxCod, T00373_A695ComDImp,
               T00373_n695ComDImp, T00373_A697ComDOrdTip, T00373_A149TipCod, T00373_A243ComCod, T00373_A244PrvCod, T00373_A254ComDProCod, T00373_n254ComDProCod, T00373_A253ComDCueCod, T00373_n253ComDCueCod, T00373_A252ComCosCod,
               T00373_n252ComCosCod
               }
               , new Object[] {
               T00374_A149TipCod
               }
               , new Object[] {
               T00375_A254ComDProCod
               }
               , new Object[] {
               T00376_A693ComDCueCos, T00376_A699ComDTipACod, T00376_n699ComDTipACod
               }
               , new Object[] {
               T00377_A252ComCosCod
               }
               , new Object[] {
               T00378_A250ComDItem, T00378_A251ComDOrdCod, T00378_A694ComDDsc, T00378_A685ComDCant, T00378_A686ComDPre, T00378_A690ComDTip, T00378_A689ComDDct, T00378_A692ComDAuxCue, T00378_A691ComDAuxCod, T00378_A695ComDImp,
               T00378_n695ComDImp, T00378_A697ComDOrdTip, T00378_A693ComDCueCos, T00378_A149TipCod, T00378_A243ComCod, T00378_A244PrvCod, T00378_A254ComDProCod, T00378_n254ComDProCod, T00378_A253ComDCueCod, T00378_n253ComDCueCod,
               T00378_A252ComCosCod, T00378_n252ComCosCod, T00378_A699ComDTipACod, T00378_n699ComDTipACod
               }
               , new Object[] {
               T00379_A149TipCod
               }
               , new Object[] {
               T003710_A254ComDProCod
               }
               , new Object[] {
               T003711_A693ComDCueCos, T003711_A699ComDTipACod, T003711_n699ComDTipACod
               }
               , new Object[] {
               T003712_A252ComCosCod
               }
               , new Object[] {
               T003713_A149TipCod, T003713_A243ComCod, T003713_A244PrvCod, T003713_A250ComDItem, T003713_A251ComDOrdCod
               }
               , new Object[] {
               T003714_A149TipCod, T003714_A243ComCod, T003714_A244PrvCod, T003714_A250ComDItem, T003714_A251ComDOrdCod
               }
               , new Object[] {
               T003715_A149TipCod, T003715_A243ComCod, T003715_A244PrvCod, T003715_A250ComDItem, T003715_A251ComDOrdCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003719_A693ComDCueCos, T003719_A699ComDTipACod, T003719_n699ComDTipACod
               }
               , new Object[] {
               T003720_A149TipCod, T003720_A243ComCod, T003720_A244PrvCod, T003720_A250ComDItem, T003720_A251ComDOrdCod
               }
               , new Object[] {
               T003721_A149TipCod
               }
               , new Object[] {
               T003722_A254ComDProCod
               }
               , new Object[] {
               T003723_A252ComCosCod
               }
            }
         );
      }

      private short Z250ComDItem ;
      private short Z690ComDTip ;
      private short Z695ComDImp ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A250ComDItem ;
      private short A690ComDTip ;
      private short A695ComDImp ;
      private short A693ComDCueCos ;
      private short GX_JID ;
      private short Z693ComDCueCos ;
      private short RcdFound110 ;
      private short nIsDirty_110 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ250ComDItem ;
      private short ZZ690ComDTip ;
      private short ZZ695ComDImp ;
      private short ZZ693ComDCueCos ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtTipCod_Enabled ;
      private int edtComCod_Enabled ;
      private int edtPrvCod_Enabled ;
      private int edtComDItem_Enabled ;
      private int edtComDOrdCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtComDProCod_Enabled ;
      private int edtComDDsc_Enabled ;
      private int edtComDCant_Enabled ;
      private int edtComDPre_Enabled ;
      private int edtComDTip_Enabled ;
      private int edtComDCueCod_Enabled ;
      private int edtComCosCod_Enabled ;
      private int edtComDDct_Enabled ;
      private int edtComDAuxCue_Enabled ;
      private int edtComDAuxCod_Enabled ;
      private int edtComDImp_Enabled ;
      private int edtComDOrdTip_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int A699ComDTipACod ;
      private int Z699ComDTipACod ;
      private int idxLst ;
      private int ZZ699ComDTipACod ;
      private decimal Z685ComDCant ;
      private decimal Z686ComDPre ;
      private decimal Z689ComDDct ;
      private decimal A685ComDCant ;
      private decimal A686ComDPre ;
      private decimal A689ComDDct ;
      private decimal A688ComDSub ;
      private decimal A687ComDDescuento ;
      private decimal A684ComDTot ;
      private decimal A696ComDIna ;
      private decimal A683ComDAfe ;
      private decimal A700ComDTotImp ;
      private decimal Z688ComDSub ;
      private decimal Z687ComDDescuento ;
      private decimal Z684ComDTot ;
      private decimal Z696ComDIna ;
      private decimal Z683ComDAfe ;
      private decimal Z700ComDTotImp ;
      private decimal ZZ685ComDCant ;
      private decimal ZZ686ComDPre ;
      private decimal ZZ689ComDDct ;
      private decimal ZZ688ComDSub ;
      private decimal ZZ687ComDDescuento ;
      private decimal ZZ684ComDTot ;
      private decimal ZZ696ComDIna ;
      private decimal ZZ683ComDAfe ;
      private decimal ZZ700ComDTotImp ;
      private string sPrefix ;
      private string Z149TipCod ;
      private string Z243ComCod ;
      private string Z244PrvCod ;
      private string Z251ComDOrdCod ;
      private string Z694ComDDsc ;
      private string Z692ComDAuxCue ;
      private string Z691ComDAuxCod ;
      private string Z254ComDProCod ;
      private string Z253ComDCueCod ;
      private string Z252ComCosCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A149TipCod ;
      private string A243ComCod ;
      private string A244PrvCod ;
      private string A254ComDProCod ;
      private string A253ComDCueCod ;
      private string A252ComCosCod ;
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
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtComDItem_Internalname ;
      private string edtComDItem_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtComDOrdCod_Internalname ;
      private string A251ComDOrdCod ;
      private string edtComDOrdCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtComDProCod_Internalname ;
      private string edtComDProCod_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtComDDsc_Internalname ;
      private string A694ComDDsc ;
      private string edtComDDsc_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtComDCant_Internalname ;
      private string edtComDCant_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtComDPre_Internalname ;
      private string edtComDPre_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtComDTip_Internalname ;
      private string edtComDTip_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtComDCueCod_Internalname ;
      private string edtComDCueCod_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtComCosCod_Internalname ;
      private string edtComCosCod_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtComDDct_Internalname ;
      private string edtComDDct_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtComDAuxCue_Internalname ;
      private string A692ComDAuxCue ;
      private string edtComDAuxCue_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtComDAuxCod_Internalname ;
      private string A691ComDAuxCod ;
      private string edtComDAuxCod_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtComDImp_Internalname ;
      private string edtComDImp_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtComDOrdTip_Internalname ;
      private string edtComDOrdTip_Jsonclick ;
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
      private string sMode110 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ149TipCod ;
      private string ZZ243ComCod ;
      private string ZZ244PrvCod ;
      private string ZZ251ComDOrdCod ;
      private string ZZ254ComDProCod ;
      private string ZZ694ComDDsc ;
      private string ZZ253ComDCueCod ;
      private string ZZ252ComCosCod ;
      private string ZZ692ComDAuxCue ;
      private string ZZ691ComDAuxCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n254ComDProCod ;
      private bool n253ComDCueCod ;
      private bool n252ComCosCod ;
      private bool wbErr ;
      private bool n695ComDImp ;
      private bool n699ComDTipACod ;
      private bool Gx_longc ;
      private string Z697ComDOrdTip ;
      private string A697ComDOrdTip ;
      private string ZZ697ComDOrdTip ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00378_A250ComDItem ;
      private string[] T00378_A251ComDOrdCod ;
      private string[] T00378_A694ComDDsc ;
      private decimal[] T00378_A685ComDCant ;
      private decimal[] T00378_A686ComDPre ;
      private short[] T00378_A690ComDTip ;
      private decimal[] T00378_A689ComDDct ;
      private string[] T00378_A692ComDAuxCue ;
      private string[] T00378_A691ComDAuxCod ;
      private short[] T00378_A695ComDImp ;
      private bool[] T00378_n695ComDImp ;
      private string[] T00378_A697ComDOrdTip ;
      private short[] T00378_A693ComDCueCos ;
      private string[] T00378_A149TipCod ;
      private string[] T00378_A243ComCod ;
      private string[] T00378_A244PrvCod ;
      private string[] T00378_A254ComDProCod ;
      private bool[] T00378_n254ComDProCod ;
      private string[] T00378_A253ComDCueCod ;
      private bool[] T00378_n253ComDCueCod ;
      private string[] T00378_A252ComCosCod ;
      private bool[] T00378_n252ComCosCod ;
      private int[] T00378_A699ComDTipACod ;
      private bool[] T00378_n699ComDTipACod ;
      private string[] T00374_A149TipCod ;
      private string[] T00375_A254ComDProCod ;
      private bool[] T00375_n254ComDProCod ;
      private short[] T00376_A693ComDCueCos ;
      private int[] T00376_A699ComDTipACod ;
      private bool[] T00376_n699ComDTipACod ;
      private string[] T00377_A252ComCosCod ;
      private bool[] T00377_n252ComCosCod ;
      private string[] T00379_A149TipCod ;
      private string[] T003710_A254ComDProCod ;
      private bool[] T003710_n254ComDProCod ;
      private short[] T003711_A693ComDCueCos ;
      private int[] T003711_A699ComDTipACod ;
      private bool[] T003711_n699ComDTipACod ;
      private string[] T003712_A252ComCosCod ;
      private bool[] T003712_n252ComCosCod ;
      private string[] T003713_A149TipCod ;
      private string[] T003713_A243ComCod ;
      private string[] T003713_A244PrvCod ;
      private short[] T003713_A250ComDItem ;
      private string[] T003713_A251ComDOrdCod ;
      private short[] T00373_A250ComDItem ;
      private string[] T00373_A251ComDOrdCod ;
      private string[] T00373_A694ComDDsc ;
      private decimal[] T00373_A685ComDCant ;
      private decimal[] T00373_A686ComDPre ;
      private short[] T00373_A690ComDTip ;
      private decimal[] T00373_A689ComDDct ;
      private string[] T00373_A692ComDAuxCue ;
      private string[] T00373_A691ComDAuxCod ;
      private short[] T00373_A695ComDImp ;
      private bool[] T00373_n695ComDImp ;
      private string[] T00373_A697ComDOrdTip ;
      private string[] T00373_A149TipCod ;
      private string[] T00373_A243ComCod ;
      private string[] T00373_A244PrvCod ;
      private string[] T00373_A254ComDProCod ;
      private bool[] T00373_n254ComDProCod ;
      private string[] T00373_A253ComDCueCod ;
      private bool[] T00373_n253ComDCueCod ;
      private string[] T00373_A252ComCosCod ;
      private bool[] T00373_n252ComCosCod ;
      private string[] T003714_A149TipCod ;
      private string[] T003714_A243ComCod ;
      private string[] T003714_A244PrvCod ;
      private short[] T003714_A250ComDItem ;
      private string[] T003714_A251ComDOrdCod ;
      private string[] T003715_A149TipCod ;
      private string[] T003715_A243ComCod ;
      private string[] T003715_A244PrvCod ;
      private short[] T003715_A250ComDItem ;
      private string[] T003715_A251ComDOrdCod ;
      private short[] T00372_A250ComDItem ;
      private string[] T00372_A251ComDOrdCod ;
      private string[] T00372_A694ComDDsc ;
      private decimal[] T00372_A685ComDCant ;
      private decimal[] T00372_A686ComDPre ;
      private short[] T00372_A690ComDTip ;
      private decimal[] T00372_A689ComDDct ;
      private string[] T00372_A692ComDAuxCue ;
      private string[] T00372_A691ComDAuxCod ;
      private short[] T00372_A695ComDImp ;
      private bool[] T00372_n695ComDImp ;
      private string[] T00372_A697ComDOrdTip ;
      private string[] T00372_A149TipCod ;
      private string[] T00372_A243ComCod ;
      private string[] T00372_A244PrvCod ;
      private string[] T00372_A254ComDProCod ;
      private bool[] T00372_n254ComDProCod ;
      private string[] T00372_A253ComDCueCod ;
      private bool[] T00372_n253ComDCueCod ;
      private string[] T00372_A252ComCosCod ;
      private bool[] T00372_n252ComCosCod ;
      private short[] T003719_A693ComDCueCos ;
      private int[] T003719_A699ComDTipACod ;
      private bool[] T003719_n699ComDTipACod ;
      private string[] T003720_A149TipCod ;
      private string[] T003720_A243ComCod ;
      private string[] T003720_A244PrvCod ;
      private short[] T003720_A250ComDItem ;
      private string[] T003720_A251ComDOrdCod ;
      private string[] T003721_A149TipCod ;
      private string[] T003722_A254ComDProCod ;
      private bool[] T003722_n254ComDProCod ;
      private string[] T003723_A252ComCosCod ;
      private bool[] T003723_n252ComCosCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class cpcomprasdet__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cpcomprasdet__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00378;
        prmT00378 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT00374;
        prmT00374 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT00375;
        prmT00375 = new Object[] {
        new ParDef("@ComDProCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT00376;
        prmT00376 = new Object[] {
        new ParDef("@ComDCueCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT00377;
        prmT00377 = new Object[] {
        new ParDef("@ComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT00379;
        prmT00379 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003710;
        prmT003710 = new Object[] {
        new ParDef("@ComDProCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT003711;
        prmT003711 = new Object[] {
        new ParDef("@ComDCueCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT003712;
        prmT003712 = new Object[] {
        new ParDef("@ComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT003713;
        prmT003713 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT00373;
        prmT00373 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003714;
        prmT003714 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003715;
        prmT003715 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT00372;
        prmT00372 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003716;
        prmT003716 = new Object[] {
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0) ,
        new ParDef("@ComDDsc",GXType.NChar,100,0) ,
        new ParDef("@ComDCant",GXType.Decimal,15,4) ,
        new ParDef("@ComDPre",GXType.Decimal,18,6) ,
        new ParDef("@ComDTip",GXType.Int16,1,0) ,
        new ParDef("@ComDDct",GXType.Decimal,15,2) ,
        new ParDef("@ComDAuxCue",GXType.NChar,15,0) ,
        new ParDef("@ComDAuxCod",GXType.NChar,20,0) ,
        new ParDef("@ComDImp",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@ComDOrdTip",GXType.NVarChar,1,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDProCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ComDCueCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        Object[] prmT003717;
        prmT003717 = new Object[] {
        new ParDef("@ComDDsc",GXType.NChar,100,0) ,
        new ParDef("@ComDCant",GXType.Decimal,15,4) ,
        new ParDef("@ComDPre",GXType.Decimal,18,6) ,
        new ParDef("@ComDTip",GXType.Int16,1,0) ,
        new ParDef("@ComDDct",GXType.Decimal,15,2) ,
        new ParDef("@ComDAuxCue",GXType.NChar,15,0) ,
        new ParDef("@ComDAuxCod",GXType.NChar,20,0) ,
        new ParDef("@ComDImp",GXType.Int16,1,0){Nullable=true} ,
        new ParDef("@ComDOrdTip",GXType.NVarChar,1,0) ,
        new ParDef("@ComDProCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ComDCueCod",GXType.NChar,15,0){Nullable=true} ,
        new ParDef("@ComCosCod",GXType.NChar,10,0){Nullable=true} ,
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003718;
        prmT003718 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0) ,
        new ParDef("@ComDItem",GXType.Int16,4,0) ,
        new ParDef("@ComDOrdCod",GXType.NChar,10,0)
        };
        Object[] prmT003720;
        prmT003720 = new Object[] {
        };
        Object[] prmT003721;
        prmT003721 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@ComCod",GXType.NChar,15,0) ,
        new ParDef("@PrvCod",GXType.NChar,20,0)
        };
        Object[] prmT003722;
        prmT003722 = new Object[] {
        new ParDef("@ComDProCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT003719;
        prmT003719 = new Object[] {
        new ParDef("@ComDCueCod",GXType.NChar,15,0){Nullable=true}
        };
        Object[] prmT003723;
        prmT003723 = new Object[] {
        new ParDef("@ComCosCod",GXType.NChar,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00372", "SELECT [ComDItem], [ComDOrdCod], [ComDDsc], [ComDCant], [ComDPre], [ComDTip], [ComDDct], [ComDAuxCue], [ComDAuxCod], [ComDImp], [ComDOrdTip], [TipCod], [ComCod], [PrvCod], [ComDProCod] AS ComDProCod, [ComDCueCod] AS ComDCueCod, [ComCosCod] AS ComCosCod FROM [CPCOMPRASDET] WITH (UPDLOCK) WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod AND [ComDItem] = @ComDItem AND [ComDOrdCod] = @ComDOrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00372,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00373", "SELECT [ComDItem], [ComDOrdCod], [ComDDsc], [ComDCant], [ComDPre], [ComDTip], [ComDDct], [ComDAuxCue], [ComDAuxCod], [ComDImp], [ComDOrdTip], [TipCod], [ComCod], [PrvCod], [ComDProCod] AS ComDProCod, [ComDCueCod] AS ComDCueCod, [ComCosCod] AS ComCosCod FROM [CPCOMPRASDET] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod AND [ComDItem] = @ComDItem AND [ComDOrdCod] = @ComDOrdCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00373,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00374", "SELECT [TipCod] FROM [CPCOMPRAS] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00374,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00375", "SELECT [ProdCod] AS ComDProCod FROM [APRODUCTOS] WHERE [ProdCod] = @ComDProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00375,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00376", "SELECT [CueCos] AS ComDCueCos, [TipACod] AS ComDTipACod FROM [CBPLANCUENTA] WHERE [CueCod] = @ComDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00376,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00377", "SELECT [COSCod] AS ComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @ComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00377,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00378", "SELECT TM1.[ComDItem], TM1.[ComDOrdCod], TM1.[ComDDsc], TM1.[ComDCant], TM1.[ComDPre], TM1.[ComDTip], TM1.[ComDDct], TM1.[ComDAuxCue], TM1.[ComDAuxCod], TM1.[ComDImp], TM1.[ComDOrdTip], T2.[CueCos] AS ComDCueCos, TM1.[TipCod], TM1.[ComCod], TM1.[PrvCod], TM1.[ComDProCod] AS ComDProCod, TM1.[ComDCueCod] AS ComDCueCod, TM1.[ComCosCod] AS ComCosCod, T2.[TipACod] AS ComDTipACod FROM ([CPCOMPRASDET] TM1 LEFT JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = TM1.[ComDCueCod]) WHERE TM1.[TipCod] = @TipCod and TM1.[ComCod] = @ComCod and TM1.[PrvCod] = @PrvCod and TM1.[ComDItem] = @ComDItem and TM1.[ComDOrdCod] = @ComDOrdCod ORDER BY TM1.[TipCod], TM1.[ComCod], TM1.[PrvCod], TM1.[ComDItem], TM1.[ComDOrdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00378,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00379", "SELECT [TipCod] FROM [CPCOMPRAS] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00379,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003710", "SELECT [ProdCod] AS ComDProCod FROM [APRODUCTOS] WHERE [ProdCod] = @ComDProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003710,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003711", "SELECT [CueCos] AS ComDCueCos, [TipACod] AS ComDTipACod FROM [CBPLANCUENTA] WHERE [CueCod] = @ComDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003711,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003712", "SELECT [COSCod] AS ComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @ComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003712,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003713", "SELECT [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod AND [ComDItem] = @ComDItem AND [ComDOrdCod] = @ComDOrdCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003713,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003714", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE ( [TipCod] > @TipCod or [TipCod] = @TipCod and [ComCod] > @ComCod or [ComCod] = @ComCod and [TipCod] = @TipCod and [PrvCod] > @PrvCod or [PrvCod] = @PrvCod and [ComCod] = @ComCod and [TipCod] = @TipCod and [ComDItem] > @ComDItem or [ComDItem] = @ComDItem and [PrvCod] = @PrvCod and [ComCod] = @ComCod and [TipCod] = @TipCod and [ComDOrdCod] > @ComDOrdCod) ORDER BY [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003714,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003715", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] WHERE ( [TipCod] < @TipCod or [TipCod] = @TipCod and [ComCod] < @ComCod or [ComCod] = @ComCod and [TipCod] = @TipCod and [PrvCod] < @PrvCod or [PrvCod] = @PrvCod and [ComCod] = @ComCod and [TipCod] = @TipCod and [ComDItem] < @ComDItem or [ComDItem] = @ComDItem and [PrvCod] = @PrvCod and [ComCod] = @ComCod and [TipCod] = @TipCod and [ComDOrdCod] < @ComDOrdCod) ORDER BY [TipCod] DESC, [ComCod] DESC, [PrvCod] DESC, [ComDItem] DESC, [ComDOrdCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003715,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003716", "INSERT INTO [CPCOMPRASDET]([ComDItem], [ComDOrdCod], [ComDDsc], [ComDCant], [ComDPre], [ComDTip], [ComDDct], [ComDAuxCue], [ComDAuxCod], [ComDImp], [ComDOrdTip], [TipCod], [ComCod], [PrvCod], [ComDProCod], [ComDCueCod], [ComCosCod]) VALUES(@ComDItem, @ComDOrdCod, @ComDDsc, @ComDCant, @ComDPre, @ComDTip, @ComDDct, @ComDAuxCue, @ComDAuxCod, @ComDImp, @ComDOrdTip, @TipCod, @ComCod, @PrvCod, @ComDProCod, @ComDCueCod, @ComCosCod)", GxErrorMask.GX_NOMASK,prmT003716)
           ,new CursorDef("T003717", "UPDATE [CPCOMPRASDET] SET [ComDDsc]=@ComDDsc, [ComDCant]=@ComDCant, [ComDPre]=@ComDPre, [ComDTip]=@ComDTip, [ComDDct]=@ComDDct, [ComDAuxCue]=@ComDAuxCue, [ComDAuxCod]=@ComDAuxCod, [ComDImp]=@ComDImp, [ComDOrdTip]=@ComDOrdTip, [ComDProCod]=@ComDProCod, [ComDCueCod]=@ComDCueCod, [ComCosCod]=@ComCosCod  WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod AND [ComDItem] = @ComDItem AND [ComDOrdCod] = @ComDOrdCod", GxErrorMask.GX_NOMASK,prmT003717)
           ,new CursorDef("T003718", "DELETE FROM [CPCOMPRASDET]  WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod AND [ComDItem] = @ComDItem AND [ComDOrdCod] = @ComDOrdCod", GxErrorMask.GX_NOMASK,prmT003718)
           ,new CursorDef("T003719", "SELECT [CueCos] AS ComDCueCos, [TipACod] AS ComDTipACod FROM [CBPLANCUENTA] WHERE [CueCod] = @ComDCueCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003719,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003720", "SELECT [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod] FROM [CPCOMPRASDET] ORDER BY [TipCod], [ComCod], [PrvCod], [ComDItem], [ComDOrdCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003720,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003721", "SELECT [TipCod] FROM [CPCOMPRAS] WHERE [TipCod] = @TipCod AND [ComCod] = @ComCod AND [PrvCod] = @PrvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003721,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003722", "SELECT [ProdCod] AS ComDProCod FROM [APRODUCTOS] WHERE [ProdCod] = @ComDProCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003722,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003723", "SELECT [COSCod] AS ComCosCod FROM [CBCOSTOS] WHERE [COSCod] = @ComCosCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003723,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 3);
              ((string[]) buf[13])[0] = rslt.getString(13, 15);
              ((string[]) buf[14])[0] = rslt.getString(14, 20);
              ((string[]) buf[15])[0] = rslt.getString(15, 15);
              ((bool[]) buf[16])[0] = rslt.wasNull(15);
              ((string[]) buf[17])[0] = rslt.getString(16, 15);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              ((string[]) buf[19])[0] = rslt.getString(17, 10);
              ((bool[]) buf[20])[0] = rslt.wasNull(17);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 3);
              ((string[]) buf[13])[0] = rslt.getString(13, 15);
              ((string[]) buf[14])[0] = rslt.getString(14, 20);
              ((string[]) buf[15])[0] = rslt.getString(15, 15);
              ((bool[]) buf[16])[0] = rslt.wasNull(15);
              ((string[]) buf[17])[0] = rslt.getString(16, 15);
              ((bool[]) buf[18])[0] = rslt.wasNull(16);
              ((string[]) buf[19])[0] = rslt.getString(17, 10);
              ((bool[]) buf[20])[0] = rslt.wasNull(17);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
              ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 15);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getVarchar(11);
              ((short[]) buf[12])[0] = rslt.getShort(12);
              ((string[]) buf[13])[0] = rslt.getString(13, 3);
              ((string[]) buf[14])[0] = rslt.getString(14, 15);
              ((string[]) buf[15])[0] = rslt.getString(15, 20);
              ((string[]) buf[16])[0] = rslt.getString(16, 15);
              ((bool[]) buf[17])[0] = rslt.wasNull(16);
              ((string[]) buf[18])[0] = rslt.getString(17, 15);
              ((bool[]) buf[19])[0] = rslt.wasNull(17);
              ((string[]) buf[20])[0] = rslt.getString(18, 10);
              ((bool[]) buf[21])[0] = rslt.wasNull(18);
              ((int[]) buf[22])[0] = rslt.getInt(19);
              ((bool[]) buf[23])[0] = rslt.wasNull(19);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 9 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 17 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
  }

}

}
