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
   public class aplacas : GXDataArea
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
            A45CliCod = GetPar( "CliCod");
            AssignAttri("", false, "A45CliCod", A45CliCod);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_2( A45CliCod) ;
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
            Form.Meta.addItem("description", "APLACAS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPlaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aplacas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aplacas( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_APLACAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Placa", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaCod_Internalname, StringUtil.RTrim( A44PlaCod), StringUtil.RTrim( context.localUtil.Format( A44PlaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Codigo Cliente", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Marca", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaMarca_Internalname, StringUtil.RTrim( A1639PlaMarca), StringUtil.RTrim( context.localUtil.Format( A1639PlaMarca, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaMarca_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaMarca_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Modelo", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaModel_Internalname, StringUtil.RTrim( A1640PlaModel), StringUtil.RTrim( context.localUtil.Format( A1640PlaModel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaModel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaModel_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Color", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaColor_Internalname, StringUtil.RTrim( A1632PlaColor), StringUtil.RTrim( context.localUtil.Format( A1632PlaColor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaColor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaColor_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "N° Chasis", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaChasis_Internalname, StringUtil.RTrim( A1630PlaChasis), StringUtil.RTrim( context.localUtil.Format( A1630PlaChasis, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaChasis_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaChasis_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "N° Motor", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaMotor_Internalname, StringUtil.RTrim( A1641PlaMotor), StringUtil.RTrim( context.localUtil.Format( A1641PlaMotor, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaMotor_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaMotor_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Dirección", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaDirec_Internalname, StringUtil.RTrim( A1633PlaDirec), StringUtil.RTrim( context.localUtil.Format( A1633PlaDirec, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaDirec_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaDirec_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Maquina", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaMaqu_Internalname, StringUtil.RTrim( A1638PlaMaqu), StringUtil.RTrim( context.localUtil.Format( A1638PlaMaqu, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaMaqu_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaMaqu_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Telefono", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaTelf_Internalname, StringUtil.RTrim( A1646PlaTelf), StringUtil.RTrim( context.localUtil.Format( A1646PlaTelf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaTelf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaTelf_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock11_Internalname, "N° Asientos", "", "", lblTextblock11_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaAsiento_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1629PlaAsiento), 4, 0, ".", "")), StringUtil.LTrim( ((edtPlaAsiento_Enabled!=0) ? context.localUtil.Format( (decimal)(A1629PlaAsiento), "ZZZ9") : context.localUtil.Format( (decimal)(A1629PlaAsiento), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,71);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaAsiento_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaAsiento_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock12_Internalname, "N° Kilomentros", "", "", lblTextblock12_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaKilom_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1636PlaKilom), 4, 0, ".", "")), StringUtil.LTrim( ((edtPlaKilom_Enabled!=0) ? context.localUtil.Format( (decimal)(A1636PlaKilom), "ZZZ9") : context.localUtil.Format( (decimal)(A1636PlaKilom), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaKilom_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaKilom_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock13_Internalname, "N° Ejes", "", "", lblTextblock13_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaEjes_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1635PlaEjes), 4, 0, ".", "")), StringUtil.LTrim( ((edtPlaEjes_Enabled!=0) ? context.localUtil.Format( (decimal)(A1635PlaEjes), "ZZZ9") : context.localUtil.Format( (decimal)(A1635PlaEjes), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,81);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaEjes_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaEjes_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock14_Internalname, "Año", "", "", lblTextblock14_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaAno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1628PlaAno), 4, 0, ".", "")), StringUtil.LTrim( ((edtPlaAno_Enabled!=0) ? context.localUtil.Format( (decimal)(A1628PlaAno), "ZZZ9") : context.localUtil.Format( (decimal)(A1628PlaAno), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,86);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaAno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaAno_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock15_Internalname, "Nombre Chofer", "", "", lblTextblock15_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaChofDsc_Internalname, StringUtil.RTrim( A1631PlaChofDsc), StringUtil.RTrim( context.localUtil.Format( A1631PlaChofDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaChofDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaChofDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock16_Internalname, "N° Licencia", "", "", lblTextblock16_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaLicen_Internalname, StringUtil.RTrim( A1637PlaLicen), StringUtil.RTrim( context.localUtil.Format( A1637PlaLicen, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaLicen_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaLicen_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock17_Internalname, "D.N.I.", "", "", lblTextblock17_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaDNI_Internalname, StringUtil.RTrim( A1634PlaDNI), StringUtil.RTrim( context.localUtil.Format( A1634PlaDNI, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaDNI_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaDNI_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock18_Internalname, "Referencia 1", "", "", lblTextblock18_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaRef1_Internalname, StringUtil.RTrim( A1642PlaRef1), StringUtil.RTrim( context.localUtil.Format( A1642PlaRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,106);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaRef1_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock19_Internalname, "Referencia 2", "", "", lblTextblock19_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 111,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaRef2_Internalname, StringUtil.RTrim( A1643PlaRef2), StringUtil.RTrim( context.localUtil.Format( A1643PlaRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,111);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaRef2_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock20_Internalname, "Referencia 3", "", "", lblTextblock20_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaRef3_Internalname, StringUtil.RTrim( A1644PlaRef3), StringUtil.RTrim( context.localUtil.Format( A1644PlaRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaRef3_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock21_Internalname, "Referencia 4", "", "", lblTextblock21_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPlaRef4_Internalname, StringUtil.RTrim( A1645PlaRef4), StringUtil.RTrim( context.localUtil.Format( A1645PlaRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPlaRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPlaRef4_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_APLACAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 125,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 126,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_APLACAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_APLACAS.htm");
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
            Z44PlaCod = cgiGet( "Z44PlaCod");
            Z1639PlaMarca = cgiGet( "Z1639PlaMarca");
            Z1640PlaModel = cgiGet( "Z1640PlaModel");
            Z1632PlaColor = cgiGet( "Z1632PlaColor");
            Z1630PlaChasis = cgiGet( "Z1630PlaChasis");
            Z1641PlaMotor = cgiGet( "Z1641PlaMotor");
            Z1633PlaDirec = cgiGet( "Z1633PlaDirec");
            Z1638PlaMaqu = cgiGet( "Z1638PlaMaqu");
            Z1646PlaTelf = cgiGet( "Z1646PlaTelf");
            Z1629PlaAsiento = (short)(context.localUtil.CToN( cgiGet( "Z1629PlaAsiento"), ".", ","));
            Z1636PlaKilom = (short)(context.localUtil.CToN( cgiGet( "Z1636PlaKilom"), ".", ","));
            Z1635PlaEjes = (short)(context.localUtil.CToN( cgiGet( "Z1635PlaEjes"), ".", ","));
            Z1628PlaAno = (short)(context.localUtil.CToN( cgiGet( "Z1628PlaAno"), ".", ","));
            Z1631PlaChofDsc = cgiGet( "Z1631PlaChofDsc");
            Z1637PlaLicen = cgiGet( "Z1637PlaLicen");
            Z1634PlaDNI = cgiGet( "Z1634PlaDNI");
            Z1642PlaRef1 = cgiGet( "Z1642PlaRef1");
            Z1643PlaRef2 = cgiGet( "Z1643PlaRef2");
            Z1644PlaRef3 = cgiGet( "Z1644PlaRef3");
            Z1645PlaRef4 = cgiGet( "Z1645PlaRef4");
            Z45CliCod = cgiGet( "Z45CliCod");
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A44PlaCod = cgiGet( edtPlaCod_Internalname);
            AssignAttri("", false, "A44PlaCod", A44PlaCod);
            A45CliCod = cgiGet( edtCliCod_Internalname);
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A1639PlaMarca = cgiGet( edtPlaMarca_Internalname);
            AssignAttri("", false, "A1639PlaMarca", A1639PlaMarca);
            A1640PlaModel = cgiGet( edtPlaModel_Internalname);
            AssignAttri("", false, "A1640PlaModel", A1640PlaModel);
            A1632PlaColor = cgiGet( edtPlaColor_Internalname);
            AssignAttri("", false, "A1632PlaColor", A1632PlaColor);
            A1630PlaChasis = cgiGet( edtPlaChasis_Internalname);
            AssignAttri("", false, "A1630PlaChasis", A1630PlaChasis);
            A1641PlaMotor = cgiGet( edtPlaMotor_Internalname);
            AssignAttri("", false, "A1641PlaMotor", A1641PlaMotor);
            A1633PlaDirec = cgiGet( edtPlaDirec_Internalname);
            AssignAttri("", false, "A1633PlaDirec", A1633PlaDirec);
            A1638PlaMaqu = cgiGet( edtPlaMaqu_Internalname);
            AssignAttri("", false, "A1638PlaMaqu", A1638PlaMaqu);
            A1646PlaTelf = cgiGet( edtPlaTelf_Internalname);
            AssignAttri("", false, "A1646PlaTelf", A1646PlaTelf);
            if ( ( ( context.localUtil.CToN( cgiGet( edtPlaAsiento_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPlaAsiento_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PLAASIENTO");
               AnyError = 1;
               GX_FocusControl = edtPlaAsiento_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1629PlaAsiento = 0;
               AssignAttri("", false, "A1629PlaAsiento", StringUtil.LTrimStr( (decimal)(A1629PlaAsiento), 4, 0));
            }
            else
            {
               A1629PlaAsiento = (short)(context.localUtil.CToN( cgiGet( edtPlaAsiento_Internalname), ".", ","));
               AssignAttri("", false, "A1629PlaAsiento", StringUtil.LTrimStr( (decimal)(A1629PlaAsiento), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPlaKilom_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPlaKilom_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PLAKILOM");
               AnyError = 1;
               GX_FocusControl = edtPlaKilom_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1636PlaKilom = 0;
               AssignAttri("", false, "A1636PlaKilom", StringUtil.LTrimStr( (decimal)(A1636PlaKilom), 4, 0));
            }
            else
            {
               A1636PlaKilom = (short)(context.localUtil.CToN( cgiGet( edtPlaKilom_Internalname), ".", ","));
               AssignAttri("", false, "A1636PlaKilom", StringUtil.LTrimStr( (decimal)(A1636PlaKilom), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPlaEjes_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPlaEjes_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PLAEJES");
               AnyError = 1;
               GX_FocusControl = edtPlaEjes_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1635PlaEjes = 0;
               AssignAttri("", false, "A1635PlaEjes", StringUtil.LTrimStr( (decimal)(A1635PlaEjes), 4, 0));
            }
            else
            {
               A1635PlaEjes = (short)(context.localUtil.CToN( cgiGet( edtPlaEjes_Internalname), ".", ","));
               AssignAttri("", false, "A1635PlaEjes", StringUtil.LTrimStr( (decimal)(A1635PlaEjes), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtPlaAno_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPlaAno_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PLAANO");
               AnyError = 1;
               GX_FocusControl = edtPlaAno_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1628PlaAno = 0;
               AssignAttri("", false, "A1628PlaAno", StringUtil.LTrimStr( (decimal)(A1628PlaAno), 4, 0));
            }
            else
            {
               A1628PlaAno = (short)(context.localUtil.CToN( cgiGet( edtPlaAno_Internalname), ".", ","));
               AssignAttri("", false, "A1628PlaAno", StringUtil.LTrimStr( (decimal)(A1628PlaAno), 4, 0));
            }
            A1631PlaChofDsc = cgiGet( edtPlaChofDsc_Internalname);
            AssignAttri("", false, "A1631PlaChofDsc", A1631PlaChofDsc);
            A1637PlaLicen = cgiGet( edtPlaLicen_Internalname);
            AssignAttri("", false, "A1637PlaLicen", A1637PlaLicen);
            A1634PlaDNI = cgiGet( edtPlaDNI_Internalname);
            AssignAttri("", false, "A1634PlaDNI", A1634PlaDNI);
            A1642PlaRef1 = cgiGet( edtPlaRef1_Internalname);
            AssignAttri("", false, "A1642PlaRef1", A1642PlaRef1);
            A1643PlaRef2 = cgiGet( edtPlaRef2_Internalname);
            AssignAttri("", false, "A1643PlaRef2", A1643PlaRef2);
            A1644PlaRef3 = cgiGet( edtPlaRef3_Internalname);
            AssignAttri("", false, "A1644PlaRef3", A1644PlaRef3);
            A1645PlaRef4 = cgiGet( edtPlaRef4_Internalname);
            AssignAttri("", false, "A1645PlaRef4", A1645PlaRef4);
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
               A44PlaCod = GetPar( "PlaCod");
               AssignAttri("", false, "A44PlaCod", A44PlaCod);
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
               InitAll1943( ) ;
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
         DisableAttributes1943( ) ;
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1943( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1943( ) ;
            }
            else
            {
               CheckExtendedTable1943( ) ;
               if ( AnyError == 0 )
               {
                  ZM1943( 2) ;
               }
               CloseExtendedTableCursors1943( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues190( ) ;
         }
      }

      protected void ResetCaption190( )
      {
      }

      protected void ZM1943( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1639PlaMarca = T00193_A1639PlaMarca[0];
               Z1640PlaModel = T00193_A1640PlaModel[0];
               Z1632PlaColor = T00193_A1632PlaColor[0];
               Z1630PlaChasis = T00193_A1630PlaChasis[0];
               Z1641PlaMotor = T00193_A1641PlaMotor[0];
               Z1633PlaDirec = T00193_A1633PlaDirec[0];
               Z1638PlaMaqu = T00193_A1638PlaMaqu[0];
               Z1646PlaTelf = T00193_A1646PlaTelf[0];
               Z1629PlaAsiento = T00193_A1629PlaAsiento[0];
               Z1636PlaKilom = T00193_A1636PlaKilom[0];
               Z1635PlaEjes = T00193_A1635PlaEjes[0];
               Z1628PlaAno = T00193_A1628PlaAno[0];
               Z1631PlaChofDsc = T00193_A1631PlaChofDsc[0];
               Z1637PlaLicen = T00193_A1637PlaLicen[0];
               Z1634PlaDNI = T00193_A1634PlaDNI[0];
               Z1642PlaRef1 = T00193_A1642PlaRef1[0];
               Z1643PlaRef2 = T00193_A1643PlaRef2[0];
               Z1644PlaRef3 = T00193_A1644PlaRef3[0];
               Z1645PlaRef4 = T00193_A1645PlaRef4[0];
               Z45CliCod = T00193_A45CliCod[0];
            }
            else
            {
               Z1639PlaMarca = A1639PlaMarca;
               Z1640PlaModel = A1640PlaModel;
               Z1632PlaColor = A1632PlaColor;
               Z1630PlaChasis = A1630PlaChasis;
               Z1641PlaMotor = A1641PlaMotor;
               Z1633PlaDirec = A1633PlaDirec;
               Z1638PlaMaqu = A1638PlaMaqu;
               Z1646PlaTelf = A1646PlaTelf;
               Z1629PlaAsiento = A1629PlaAsiento;
               Z1636PlaKilom = A1636PlaKilom;
               Z1635PlaEjes = A1635PlaEjes;
               Z1628PlaAno = A1628PlaAno;
               Z1631PlaChofDsc = A1631PlaChofDsc;
               Z1637PlaLicen = A1637PlaLicen;
               Z1634PlaDNI = A1634PlaDNI;
               Z1642PlaRef1 = A1642PlaRef1;
               Z1643PlaRef2 = A1643PlaRef2;
               Z1644PlaRef3 = A1644PlaRef3;
               Z1645PlaRef4 = A1645PlaRef4;
               Z45CliCod = A45CliCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z44PlaCod = A44PlaCod;
            Z1639PlaMarca = A1639PlaMarca;
            Z1640PlaModel = A1640PlaModel;
            Z1632PlaColor = A1632PlaColor;
            Z1630PlaChasis = A1630PlaChasis;
            Z1641PlaMotor = A1641PlaMotor;
            Z1633PlaDirec = A1633PlaDirec;
            Z1638PlaMaqu = A1638PlaMaqu;
            Z1646PlaTelf = A1646PlaTelf;
            Z1629PlaAsiento = A1629PlaAsiento;
            Z1636PlaKilom = A1636PlaKilom;
            Z1635PlaEjes = A1635PlaEjes;
            Z1628PlaAno = A1628PlaAno;
            Z1631PlaChofDsc = A1631PlaChofDsc;
            Z1637PlaLicen = A1637PlaLicen;
            Z1634PlaDNI = A1634PlaDNI;
            Z1642PlaRef1 = A1642PlaRef1;
            Z1643PlaRef2 = A1643PlaRef2;
            Z1644PlaRef3 = A1644PlaRef3;
            Z1645PlaRef4 = A1645PlaRef4;
            Z45CliCod = A45CliCod;
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

      protected void Load1943( )
      {
         /* Using cursor T00195 */
         pr_default.execute(3, new Object[] {A44PlaCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound43 = 1;
            A1639PlaMarca = T00195_A1639PlaMarca[0];
            AssignAttri("", false, "A1639PlaMarca", A1639PlaMarca);
            A1640PlaModel = T00195_A1640PlaModel[0];
            AssignAttri("", false, "A1640PlaModel", A1640PlaModel);
            A1632PlaColor = T00195_A1632PlaColor[0];
            AssignAttri("", false, "A1632PlaColor", A1632PlaColor);
            A1630PlaChasis = T00195_A1630PlaChasis[0];
            AssignAttri("", false, "A1630PlaChasis", A1630PlaChasis);
            A1641PlaMotor = T00195_A1641PlaMotor[0];
            AssignAttri("", false, "A1641PlaMotor", A1641PlaMotor);
            A1633PlaDirec = T00195_A1633PlaDirec[0];
            AssignAttri("", false, "A1633PlaDirec", A1633PlaDirec);
            A1638PlaMaqu = T00195_A1638PlaMaqu[0];
            AssignAttri("", false, "A1638PlaMaqu", A1638PlaMaqu);
            A1646PlaTelf = T00195_A1646PlaTelf[0];
            AssignAttri("", false, "A1646PlaTelf", A1646PlaTelf);
            A1629PlaAsiento = T00195_A1629PlaAsiento[0];
            AssignAttri("", false, "A1629PlaAsiento", StringUtil.LTrimStr( (decimal)(A1629PlaAsiento), 4, 0));
            A1636PlaKilom = T00195_A1636PlaKilom[0];
            AssignAttri("", false, "A1636PlaKilom", StringUtil.LTrimStr( (decimal)(A1636PlaKilom), 4, 0));
            A1635PlaEjes = T00195_A1635PlaEjes[0];
            AssignAttri("", false, "A1635PlaEjes", StringUtil.LTrimStr( (decimal)(A1635PlaEjes), 4, 0));
            A1628PlaAno = T00195_A1628PlaAno[0];
            AssignAttri("", false, "A1628PlaAno", StringUtil.LTrimStr( (decimal)(A1628PlaAno), 4, 0));
            A1631PlaChofDsc = T00195_A1631PlaChofDsc[0];
            AssignAttri("", false, "A1631PlaChofDsc", A1631PlaChofDsc);
            A1637PlaLicen = T00195_A1637PlaLicen[0];
            AssignAttri("", false, "A1637PlaLicen", A1637PlaLicen);
            A1634PlaDNI = T00195_A1634PlaDNI[0];
            AssignAttri("", false, "A1634PlaDNI", A1634PlaDNI);
            A1642PlaRef1 = T00195_A1642PlaRef1[0];
            AssignAttri("", false, "A1642PlaRef1", A1642PlaRef1);
            A1643PlaRef2 = T00195_A1643PlaRef2[0];
            AssignAttri("", false, "A1643PlaRef2", A1643PlaRef2);
            A1644PlaRef3 = T00195_A1644PlaRef3[0];
            AssignAttri("", false, "A1644PlaRef3", A1644PlaRef3);
            A1645PlaRef4 = T00195_A1645PlaRef4[0];
            AssignAttri("", false, "A1645PlaRef4", A1645PlaRef4);
            A45CliCod = T00195_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            ZM1943( -1) ;
         }
         pr_default.close(3);
         OnLoadActions1943( ) ;
      }

      protected void OnLoadActions1943( )
      {
      }

      protected void CheckExtendedTable1943( )
      {
         nIsDirty_43 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00194 */
         pr_default.execute(2, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors1943( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A45CliCod )
      {
         /* Using cursor T00196 */
         pr_default.execute(4, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1943( )
      {
         /* Using cursor T00197 */
         pr_default.execute(5, new Object[] {A44PlaCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00193 */
         pr_default.execute(1, new Object[] {A44PlaCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1943( 1) ;
            RcdFound43 = 1;
            A44PlaCod = T00193_A44PlaCod[0];
            AssignAttri("", false, "A44PlaCod", A44PlaCod);
            A1639PlaMarca = T00193_A1639PlaMarca[0];
            AssignAttri("", false, "A1639PlaMarca", A1639PlaMarca);
            A1640PlaModel = T00193_A1640PlaModel[0];
            AssignAttri("", false, "A1640PlaModel", A1640PlaModel);
            A1632PlaColor = T00193_A1632PlaColor[0];
            AssignAttri("", false, "A1632PlaColor", A1632PlaColor);
            A1630PlaChasis = T00193_A1630PlaChasis[0];
            AssignAttri("", false, "A1630PlaChasis", A1630PlaChasis);
            A1641PlaMotor = T00193_A1641PlaMotor[0];
            AssignAttri("", false, "A1641PlaMotor", A1641PlaMotor);
            A1633PlaDirec = T00193_A1633PlaDirec[0];
            AssignAttri("", false, "A1633PlaDirec", A1633PlaDirec);
            A1638PlaMaqu = T00193_A1638PlaMaqu[0];
            AssignAttri("", false, "A1638PlaMaqu", A1638PlaMaqu);
            A1646PlaTelf = T00193_A1646PlaTelf[0];
            AssignAttri("", false, "A1646PlaTelf", A1646PlaTelf);
            A1629PlaAsiento = T00193_A1629PlaAsiento[0];
            AssignAttri("", false, "A1629PlaAsiento", StringUtil.LTrimStr( (decimal)(A1629PlaAsiento), 4, 0));
            A1636PlaKilom = T00193_A1636PlaKilom[0];
            AssignAttri("", false, "A1636PlaKilom", StringUtil.LTrimStr( (decimal)(A1636PlaKilom), 4, 0));
            A1635PlaEjes = T00193_A1635PlaEjes[0];
            AssignAttri("", false, "A1635PlaEjes", StringUtil.LTrimStr( (decimal)(A1635PlaEjes), 4, 0));
            A1628PlaAno = T00193_A1628PlaAno[0];
            AssignAttri("", false, "A1628PlaAno", StringUtil.LTrimStr( (decimal)(A1628PlaAno), 4, 0));
            A1631PlaChofDsc = T00193_A1631PlaChofDsc[0];
            AssignAttri("", false, "A1631PlaChofDsc", A1631PlaChofDsc);
            A1637PlaLicen = T00193_A1637PlaLicen[0];
            AssignAttri("", false, "A1637PlaLicen", A1637PlaLicen);
            A1634PlaDNI = T00193_A1634PlaDNI[0];
            AssignAttri("", false, "A1634PlaDNI", A1634PlaDNI);
            A1642PlaRef1 = T00193_A1642PlaRef1[0];
            AssignAttri("", false, "A1642PlaRef1", A1642PlaRef1);
            A1643PlaRef2 = T00193_A1643PlaRef2[0];
            AssignAttri("", false, "A1643PlaRef2", A1643PlaRef2);
            A1644PlaRef3 = T00193_A1644PlaRef3[0];
            AssignAttri("", false, "A1644PlaRef3", A1644PlaRef3);
            A1645PlaRef4 = T00193_A1645PlaRef4[0];
            AssignAttri("", false, "A1645PlaRef4", A1645PlaRef4);
            A45CliCod = T00193_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            Z44PlaCod = A44PlaCod;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1943( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey1943( ) ;
            }
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey1943( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode43;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1943( ) ;
         if ( RcdFound43 == 0 )
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
         RcdFound43 = 0;
         /* Using cursor T00198 */
         pr_default.execute(6, new Object[] {A44PlaCod});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00198_A44PlaCod[0], A44PlaCod) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( StringUtil.StrCmp(T00198_A44PlaCod[0], A44PlaCod) > 0 ) ) )
            {
               A44PlaCod = T00198_A44PlaCod[0];
               AssignAttri("", false, "A44PlaCod", A44PlaCod);
               RcdFound43 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound43 = 0;
         /* Using cursor T00199 */
         pr_default.execute(7, new Object[] {A44PlaCod});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00199_A44PlaCod[0], A44PlaCod) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( StringUtil.StrCmp(T00199_A44PlaCod[0], A44PlaCod) < 0 ) ) )
            {
               A44PlaCod = T00199_A44PlaCod[0];
               AssignAttri("", false, "A44PlaCod", A44PlaCod);
               RcdFound43 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1943( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPlaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1943( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( StringUtil.StrCmp(A44PlaCod, Z44PlaCod) != 0 )
               {
                  A44PlaCod = Z44PlaCod;
                  AssignAttri("", false, "A44PlaCod", A44PlaCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PLACOD");
                  AnyError = 1;
                  GX_FocusControl = edtPlaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPlaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1943( ) ;
                  GX_FocusControl = edtPlaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A44PlaCod, Z44PlaCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtPlaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1943( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PLACOD");
                     AnyError = 1;
                     GX_FocusControl = edtPlaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtPlaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1943( ) ;
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
         if ( StringUtil.StrCmp(A44PlaCod, Z44PlaCod) != 0 )
         {
            A44PlaCod = Z44PlaCod;
            AssignAttri("", false, "A44PlaCod", A44PlaCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PLACOD");
            AnyError = 1;
            GX_FocusControl = edtPlaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPlaCod_Internalname;
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
         GetKey1943( ) ;
         if ( RcdFound43 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "PLACOD");
               AnyError = 1;
               GX_FocusControl = edtPlaCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A44PlaCod, Z44PlaCod) != 0 )
            {
               A44PlaCod = Z44PlaCod;
               AssignAttri("", false, "A44PlaCod", A44PlaCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "PLACOD");
               AnyError = 1;
               GX_FocusControl = edtPlaCod_Internalname;
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
            if ( StringUtil.StrCmp(A44PlaCod, Z44PlaCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PLACOD");
                  AnyError = 1;
                  GX_FocusControl = edtPlaCod_Internalname;
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
         context.RollbackDataStores("aplacas",pr_default);
         GX_FocusControl = edtCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_190( ) ;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "PLACOD");
            AnyError = 1;
            GX_FocusControl = edtPlaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1943( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1943( ) ;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliCod_Internalname;
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
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliCod_Internalname;
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
         ScanStart1943( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound43 != 0 )
            {
               ScanNext1943( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliCod_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1943( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1943( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00192 */
            pr_default.execute(0, new Object[] {A44PlaCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APLACAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1639PlaMarca, T00192_A1639PlaMarca[0]) != 0 ) || ( StringUtil.StrCmp(Z1640PlaModel, T00192_A1640PlaModel[0]) != 0 ) || ( StringUtil.StrCmp(Z1632PlaColor, T00192_A1632PlaColor[0]) != 0 ) || ( StringUtil.StrCmp(Z1630PlaChasis, T00192_A1630PlaChasis[0]) != 0 ) || ( StringUtil.StrCmp(Z1641PlaMotor, T00192_A1641PlaMotor[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1633PlaDirec, T00192_A1633PlaDirec[0]) != 0 ) || ( StringUtil.StrCmp(Z1638PlaMaqu, T00192_A1638PlaMaqu[0]) != 0 ) || ( StringUtil.StrCmp(Z1646PlaTelf, T00192_A1646PlaTelf[0]) != 0 ) || ( Z1629PlaAsiento != T00192_A1629PlaAsiento[0] ) || ( Z1636PlaKilom != T00192_A1636PlaKilom[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1635PlaEjes != T00192_A1635PlaEjes[0] ) || ( Z1628PlaAno != T00192_A1628PlaAno[0] ) || ( StringUtil.StrCmp(Z1631PlaChofDsc, T00192_A1631PlaChofDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1637PlaLicen, T00192_A1637PlaLicen[0]) != 0 ) || ( StringUtil.StrCmp(Z1634PlaDNI, T00192_A1634PlaDNI[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1642PlaRef1, T00192_A1642PlaRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1643PlaRef2, T00192_A1643PlaRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1644PlaRef3, T00192_A1644PlaRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1645PlaRef4, T00192_A1645PlaRef4[0]) != 0 ) || ( StringUtil.StrCmp(Z45CliCod, T00192_A45CliCod[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1639PlaMarca, T00192_A1639PlaMarca[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaMarca");
                  GXUtil.WriteLogRaw("Old: ",Z1639PlaMarca);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1639PlaMarca[0]);
               }
               if ( StringUtil.StrCmp(Z1640PlaModel, T00192_A1640PlaModel[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaModel");
                  GXUtil.WriteLogRaw("Old: ",Z1640PlaModel);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1640PlaModel[0]);
               }
               if ( StringUtil.StrCmp(Z1632PlaColor, T00192_A1632PlaColor[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaColor");
                  GXUtil.WriteLogRaw("Old: ",Z1632PlaColor);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1632PlaColor[0]);
               }
               if ( StringUtil.StrCmp(Z1630PlaChasis, T00192_A1630PlaChasis[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaChasis");
                  GXUtil.WriteLogRaw("Old: ",Z1630PlaChasis);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1630PlaChasis[0]);
               }
               if ( StringUtil.StrCmp(Z1641PlaMotor, T00192_A1641PlaMotor[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaMotor");
                  GXUtil.WriteLogRaw("Old: ",Z1641PlaMotor);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1641PlaMotor[0]);
               }
               if ( StringUtil.StrCmp(Z1633PlaDirec, T00192_A1633PlaDirec[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaDirec");
                  GXUtil.WriteLogRaw("Old: ",Z1633PlaDirec);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1633PlaDirec[0]);
               }
               if ( StringUtil.StrCmp(Z1638PlaMaqu, T00192_A1638PlaMaqu[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaMaqu");
                  GXUtil.WriteLogRaw("Old: ",Z1638PlaMaqu);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1638PlaMaqu[0]);
               }
               if ( StringUtil.StrCmp(Z1646PlaTelf, T00192_A1646PlaTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaTelf");
                  GXUtil.WriteLogRaw("Old: ",Z1646PlaTelf);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1646PlaTelf[0]);
               }
               if ( Z1629PlaAsiento != T00192_A1629PlaAsiento[0] )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaAsiento");
                  GXUtil.WriteLogRaw("Old: ",Z1629PlaAsiento);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1629PlaAsiento[0]);
               }
               if ( Z1636PlaKilom != T00192_A1636PlaKilom[0] )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaKilom");
                  GXUtil.WriteLogRaw("Old: ",Z1636PlaKilom);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1636PlaKilom[0]);
               }
               if ( Z1635PlaEjes != T00192_A1635PlaEjes[0] )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaEjes");
                  GXUtil.WriteLogRaw("Old: ",Z1635PlaEjes);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1635PlaEjes[0]);
               }
               if ( Z1628PlaAno != T00192_A1628PlaAno[0] )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaAno");
                  GXUtil.WriteLogRaw("Old: ",Z1628PlaAno);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1628PlaAno[0]);
               }
               if ( StringUtil.StrCmp(Z1631PlaChofDsc, T00192_A1631PlaChofDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaChofDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1631PlaChofDsc);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1631PlaChofDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1637PlaLicen, T00192_A1637PlaLicen[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaLicen");
                  GXUtil.WriteLogRaw("Old: ",Z1637PlaLicen);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1637PlaLicen[0]);
               }
               if ( StringUtil.StrCmp(Z1634PlaDNI, T00192_A1634PlaDNI[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaDNI");
                  GXUtil.WriteLogRaw("Old: ",Z1634PlaDNI);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1634PlaDNI[0]);
               }
               if ( StringUtil.StrCmp(Z1642PlaRef1, T00192_A1642PlaRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1642PlaRef1);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1642PlaRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1643PlaRef2, T00192_A1643PlaRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1643PlaRef2);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1643PlaRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1644PlaRef3, T00192_A1644PlaRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1644PlaRef3);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1644PlaRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1645PlaRef4, T00192_A1645PlaRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"PlaRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1645PlaRef4);
                  GXUtil.WriteLogRaw("Current: ",T00192_A1645PlaRef4[0]);
               }
               if ( StringUtil.StrCmp(Z45CliCod, T00192_A45CliCod[0]) != 0 )
               {
                  GXUtil.WriteLog("aplacas:[seudo value changed for attri]"+"CliCod");
                  GXUtil.WriteLogRaw("Old: ",Z45CliCod);
                  GXUtil.WriteLogRaw("Current: ",T00192_A45CliCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"APLACAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1943( )
      {
         BeforeValidate1943( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1943( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1943( 0) ;
            CheckOptimisticConcurrency1943( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1943( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1943( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001910 */
                     pr_default.execute(8, new Object[] {A44PlaCod, A1639PlaMarca, A1640PlaModel, A1632PlaColor, A1630PlaChasis, A1641PlaMotor, A1633PlaDirec, A1638PlaMaqu, A1646PlaTelf, A1629PlaAsiento, A1636PlaKilom, A1635PlaEjes, A1628PlaAno, A1631PlaChofDsc, A1637PlaLicen, A1634PlaDNI, A1642PlaRef1, A1643PlaRef2, A1644PlaRef3, A1645PlaRef4, A45CliCod});
                     pr_default.close(8);
                     dsDefault.SmartCacheProvider.SetUpdated("APLACAS");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption190( ) ;
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
               Load1943( ) ;
            }
            EndLevel1943( ) ;
         }
         CloseExtendedTableCursors1943( ) ;
      }

      protected void Update1943( )
      {
         BeforeValidate1943( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1943( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1943( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1943( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1943( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001911 */
                     pr_default.execute(9, new Object[] {A1639PlaMarca, A1640PlaModel, A1632PlaColor, A1630PlaChasis, A1641PlaMotor, A1633PlaDirec, A1638PlaMaqu, A1646PlaTelf, A1629PlaAsiento, A1636PlaKilom, A1635PlaEjes, A1628PlaAno, A1631PlaChofDsc, A1637PlaLicen, A1634PlaDNI, A1642PlaRef1, A1643PlaRef2, A1644PlaRef3, A1645PlaRef4, A45CliCod, A44PlaCod});
                     pr_default.close(9);
                     dsDefault.SmartCacheProvider.SetUpdated("APLACAS");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"APLACAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1943( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption190( ) ;
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
            EndLevel1943( ) ;
         }
         CloseExtendedTableCursors1943( ) ;
      }

      protected void DeferredUpdate1943( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1943( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1943( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1943( ) ;
            AfterConfirm1943( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1943( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001912 */
                  pr_default.execute(10, new Object[] {A44PlaCod});
                  pr_default.close(10);
                  dsDefault.SmartCacheProvider.SetUpdated("APLACAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound43 == 0 )
                        {
                           InitAll1943( ) ;
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
                        ResetCaption190( ) ;
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1943( ) ;
         Gx_mode = sMode43;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1943( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1943( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1943( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("aplacas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues190( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("aplacas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1943( )
      {
         /* Using cursor T001913 */
         pr_default.execute(11);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound43 = 1;
            A44PlaCod = T001913_A44PlaCod[0];
            AssignAttri("", false, "A44PlaCod", A44PlaCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1943( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound43 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound43 = 1;
            A44PlaCod = T001913_A44PlaCod[0];
            AssignAttri("", false, "A44PlaCod", A44PlaCod);
         }
      }

      protected void ScanEnd1943( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1943( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1943( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1943( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1943( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1943( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1943( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1943( )
      {
         edtPlaCod_Enabled = 0;
         AssignProp("", false, edtPlaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaCod_Enabled), 5, 0), true);
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtPlaMarca_Enabled = 0;
         AssignProp("", false, edtPlaMarca_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaMarca_Enabled), 5, 0), true);
         edtPlaModel_Enabled = 0;
         AssignProp("", false, edtPlaModel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaModel_Enabled), 5, 0), true);
         edtPlaColor_Enabled = 0;
         AssignProp("", false, edtPlaColor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaColor_Enabled), 5, 0), true);
         edtPlaChasis_Enabled = 0;
         AssignProp("", false, edtPlaChasis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaChasis_Enabled), 5, 0), true);
         edtPlaMotor_Enabled = 0;
         AssignProp("", false, edtPlaMotor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaMotor_Enabled), 5, 0), true);
         edtPlaDirec_Enabled = 0;
         AssignProp("", false, edtPlaDirec_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaDirec_Enabled), 5, 0), true);
         edtPlaMaqu_Enabled = 0;
         AssignProp("", false, edtPlaMaqu_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaMaqu_Enabled), 5, 0), true);
         edtPlaTelf_Enabled = 0;
         AssignProp("", false, edtPlaTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaTelf_Enabled), 5, 0), true);
         edtPlaAsiento_Enabled = 0;
         AssignProp("", false, edtPlaAsiento_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaAsiento_Enabled), 5, 0), true);
         edtPlaKilom_Enabled = 0;
         AssignProp("", false, edtPlaKilom_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaKilom_Enabled), 5, 0), true);
         edtPlaEjes_Enabled = 0;
         AssignProp("", false, edtPlaEjes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaEjes_Enabled), 5, 0), true);
         edtPlaAno_Enabled = 0;
         AssignProp("", false, edtPlaAno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaAno_Enabled), 5, 0), true);
         edtPlaChofDsc_Enabled = 0;
         AssignProp("", false, edtPlaChofDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaChofDsc_Enabled), 5, 0), true);
         edtPlaLicen_Enabled = 0;
         AssignProp("", false, edtPlaLicen_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaLicen_Enabled), 5, 0), true);
         edtPlaDNI_Enabled = 0;
         AssignProp("", false, edtPlaDNI_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaDNI_Enabled), 5, 0), true);
         edtPlaRef1_Enabled = 0;
         AssignProp("", false, edtPlaRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaRef1_Enabled), 5, 0), true);
         edtPlaRef2_Enabled = 0;
         AssignProp("", false, edtPlaRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaRef2_Enabled), 5, 0), true);
         edtPlaRef3_Enabled = 0;
         AssignProp("", false, edtPlaRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaRef3_Enabled), 5, 0), true);
         edtPlaRef4_Enabled = 0;
         AssignProp("", false, edtPlaRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPlaRef4_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1943( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues190( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811465459", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aplacas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z44PlaCod", StringUtil.RTrim( Z44PlaCod));
         GxWebStd.gx_hidden_field( context, "Z1639PlaMarca", StringUtil.RTrim( Z1639PlaMarca));
         GxWebStd.gx_hidden_field( context, "Z1640PlaModel", StringUtil.RTrim( Z1640PlaModel));
         GxWebStd.gx_hidden_field( context, "Z1632PlaColor", StringUtil.RTrim( Z1632PlaColor));
         GxWebStd.gx_hidden_field( context, "Z1630PlaChasis", StringUtil.RTrim( Z1630PlaChasis));
         GxWebStd.gx_hidden_field( context, "Z1641PlaMotor", StringUtil.RTrim( Z1641PlaMotor));
         GxWebStd.gx_hidden_field( context, "Z1633PlaDirec", StringUtil.RTrim( Z1633PlaDirec));
         GxWebStd.gx_hidden_field( context, "Z1638PlaMaqu", StringUtil.RTrim( Z1638PlaMaqu));
         GxWebStd.gx_hidden_field( context, "Z1646PlaTelf", StringUtil.RTrim( Z1646PlaTelf));
         GxWebStd.gx_hidden_field( context, "Z1629PlaAsiento", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1629PlaAsiento), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1636PlaKilom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1636PlaKilom), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1635PlaEjes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1635PlaEjes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1628PlaAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1628PlaAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1631PlaChofDsc", StringUtil.RTrim( Z1631PlaChofDsc));
         GxWebStd.gx_hidden_field( context, "Z1637PlaLicen", StringUtil.RTrim( Z1637PlaLicen));
         GxWebStd.gx_hidden_field( context, "Z1634PlaDNI", StringUtil.RTrim( Z1634PlaDNI));
         GxWebStd.gx_hidden_field( context, "Z1642PlaRef1", StringUtil.RTrim( Z1642PlaRef1));
         GxWebStd.gx_hidden_field( context, "Z1643PlaRef2", StringUtil.RTrim( Z1643PlaRef2));
         GxWebStd.gx_hidden_field( context, "Z1644PlaRef3", StringUtil.RTrim( Z1644PlaRef3));
         GxWebStd.gx_hidden_field( context, "Z1645PlaRef4", StringUtil.RTrim( Z1645PlaRef4));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
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
         return formatLink("aplacas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "APLACAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "APLACAS" ;
      }

      protected void InitializeNonKey1943( )
      {
         A45CliCod = "";
         AssignAttri("", false, "A45CliCod", A45CliCod);
         A1639PlaMarca = "";
         AssignAttri("", false, "A1639PlaMarca", A1639PlaMarca);
         A1640PlaModel = "";
         AssignAttri("", false, "A1640PlaModel", A1640PlaModel);
         A1632PlaColor = "";
         AssignAttri("", false, "A1632PlaColor", A1632PlaColor);
         A1630PlaChasis = "";
         AssignAttri("", false, "A1630PlaChasis", A1630PlaChasis);
         A1641PlaMotor = "";
         AssignAttri("", false, "A1641PlaMotor", A1641PlaMotor);
         A1633PlaDirec = "";
         AssignAttri("", false, "A1633PlaDirec", A1633PlaDirec);
         A1638PlaMaqu = "";
         AssignAttri("", false, "A1638PlaMaqu", A1638PlaMaqu);
         A1646PlaTelf = "";
         AssignAttri("", false, "A1646PlaTelf", A1646PlaTelf);
         A1629PlaAsiento = 0;
         AssignAttri("", false, "A1629PlaAsiento", StringUtil.LTrimStr( (decimal)(A1629PlaAsiento), 4, 0));
         A1636PlaKilom = 0;
         AssignAttri("", false, "A1636PlaKilom", StringUtil.LTrimStr( (decimal)(A1636PlaKilom), 4, 0));
         A1635PlaEjes = 0;
         AssignAttri("", false, "A1635PlaEjes", StringUtil.LTrimStr( (decimal)(A1635PlaEjes), 4, 0));
         A1628PlaAno = 0;
         AssignAttri("", false, "A1628PlaAno", StringUtil.LTrimStr( (decimal)(A1628PlaAno), 4, 0));
         A1631PlaChofDsc = "";
         AssignAttri("", false, "A1631PlaChofDsc", A1631PlaChofDsc);
         A1637PlaLicen = "";
         AssignAttri("", false, "A1637PlaLicen", A1637PlaLicen);
         A1634PlaDNI = "";
         AssignAttri("", false, "A1634PlaDNI", A1634PlaDNI);
         A1642PlaRef1 = "";
         AssignAttri("", false, "A1642PlaRef1", A1642PlaRef1);
         A1643PlaRef2 = "";
         AssignAttri("", false, "A1643PlaRef2", A1643PlaRef2);
         A1644PlaRef3 = "";
         AssignAttri("", false, "A1644PlaRef3", A1644PlaRef3);
         A1645PlaRef4 = "";
         AssignAttri("", false, "A1645PlaRef4", A1645PlaRef4);
         Z1639PlaMarca = "";
         Z1640PlaModel = "";
         Z1632PlaColor = "";
         Z1630PlaChasis = "";
         Z1641PlaMotor = "";
         Z1633PlaDirec = "";
         Z1638PlaMaqu = "";
         Z1646PlaTelf = "";
         Z1629PlaAsiento = 0;
         Z1636PlaKilom = 0;
         Z1635PlaEjes = 0;
         Z1628PlaAno = 0;
         Z1631PlaChofDsc = "";
         Z1637PlaLicen = "";
         Z1634PlaDNI = "";
         Z1642PlaRef1 = "";
         Z1643PlaRef2 = "";
         Z1644PlaRef3 = "";
         Z1645PlaRef4 = "";
         Z45CliCod = "";
      }

      protected void InitAll1943( )
      {
         A44PlaCod = "";
         AssignAttri("", false, "A44PlaCod", A44PlaCod);
         InitializeNonKey1943( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811465465", true, true);
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
         context.AddJavascriptSource("aplacas.js", "?202281811465465", false, true);
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
         edtPlaCod_Internalname = "PLACOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCliCod_Internalname = "CLICOD";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtPlaMarca_Internalname = "PLAMARCA";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtPlaModel_Internalname = "PLAMODEL";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtPlaColor_Internalname = "PLACOLOR";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtPlaChasis_Internalname = "PLACHASIS";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtPlaMotor_Internalname = "PLAMOTOR";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtPlaDirec_Internalname = "PLADIREC";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtPlaMaqu_Internalname = "PLAMAQU";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtPlaTelf_Internalname = "PLATELF";
         lblTextblock11_Internalname = "TEXTBLOCK11";
         edtPlaAsiento_Internalname = "PLAASIENTO";
         lblTextblock12_Internalname = "TEXTBLOCK12";
         edtPlaKilom_Internalname = "PLAKILOM";
         lblTextblock13_Internalname = "TEXTBLOCK13";
         edtPlaEjes_Internalname = "PLAEJES";
         lblTextblock14_Internalname = "TEXTBLOCK14";
         edtPlaAno_Internalname = "PLAANO";
         lblTextblock15_Internalname = "TEXTBLOCK15";
         edtPlaChofDsc_Internalname = "PLACHOFDSC";
         lblTextblock16_Internalname = "TEXTBLOCK16";
         edtPlaLicen_Internalname = "PLALICEN";
         lblTextblock17_Internalname = "TEXTBLOCK17";
         edtPlaDNI_Internalname = "PLADNI";
         lblTextblock18_Internalname = "TEXTBLOCK18";
         edtPlaRef1_Internalname = "PLAREF1";
         lblTextblock19_Internalname = "TEXTBLOCK19";
         edtPlaRef2_Internalname = "PLAREF2";
         lblTextblock20_Internalname = "TEXTBLOCK20";
         edtPlaRef3_Internalname = "PLAREF3";
         lblTextblock21_Internalname = "TEXTBLOCK21";
         edtPlaRef4_Internalname = "PLAREF4";
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
         Form.Caption = "APLACAS";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPlaRef4_Jsonclick = "";
         edtPlaRef4_Enabled = 1;
         edtPlaRef3_Jsonclick = "";
         edtPlaRef3_Enabled = 1;
         edtPlaRef2_Jsonclick = "";
         edtPlaRef2_Enabled = 1;
         edtPlaRef1_Jsonclick = "";
         edtPlaRef1_Enabled = 1;
         edtPlaDNI_Jsonclick = "";
         edtPlaDNI_Enabled = 1;
         edtPlaLicen_Jsonclick = "";
         edtPlaLicen_Enabled = 1;
         edtPlaChofDsc_Jsonclick = "";
         edtPlaChofDsc_Enabled = 1;
         edtPlaAno_Jsonclick = "";
         edtPlaAno_Enabled = 1;
         edtPlaEjes_Jsonclick = "";
         edtPlaEjes_Enabled = 1;
         edtPlaKilom_Jsonclick = "";
         edtPlaKilom_Enabled = 1;
         edtPlaAsiento_Jsonclick = "";
         edtPlaAsiento_Enabled = 1;
         edtPlaTelf_Jsonclick = "";
         edtPlaTelf_Enabled = 1;
         edtPlaMaqu_Jsonclick = "";
         edtPlaMaqu_Enabled = 1;
         edtPlaDirec_Jsonclick = "";
         edtPlaDirec_Enabled = 1;
         edtPlaMotor_Jsonclick = "";
         edtPlaMotor_Enabled = 1;
         edtPlaChasis_Jsonclick = "";
         edtPlaChasis_Enabled = 1;
         edtPlaColor_Jsonclick = "";
         edtPlaColor_Enabled = 1;
         edtPlaModel_Jsonclick = "";
         edtPlaModel_Enabled = 1;
         edtPlaMarca_Jsonclick = "";
         edtPlaMarca_Enabled = 1;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtPlaCod_Jsonclick = "";
         edtPlaCod_Enabled = 1;
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
         GX_FocusControl = edtCliCod_Internalname;
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

      public void Valid_Placod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A45CliCod", StringUtil.RTrim( A45CliCod));
         AssignAttri("", false, "A1639PlaMarca", StringUtil.RTrim( A1639PlaMarca));
         AssignAttri("", false, "A1640PlaModel", StringUtil.RTrim( A1640PlaModel));
         AssignAttri("", false, "A1632PlaColor", StringUtil.RTrim( A1632PlaColor));
         AssignAttri("", false, "A1630PlaChasis", StringUtil.RTrim( A1630PlaChasis));
         AssignAttri("", false, "A1641PlaMotor", StringUtil.RTrim( A1641PlaMotor));
         AssignAttri("", false, "A1633PlaDirec", StringUtil.RTrim( A1633PlaDirec));
         AssignAttri("", false, "A1638PlaMaqu", StringUtil.RTrim( A1638PlaMaqu));
         AssignAttri("", false, "A1646PlaTelf", StringUtil.RTrim( A1646PlaTelf));
         AssignAttri("", false, "A1629PlaAsiento", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1629PlaAsiento), 4, 0, ".", "")));
         AssignAttri("", false, "A1636PlaKilom", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1636PlaKilom), 4, 0, ".", "")));
         AssignAttri("", false, "A1635PlaEjes", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1635PlaEjes), 4, 0, ".", "")));
         AssignAttri("", false, "A1628PlaAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1628PlaAno), 4, 0, ".", "")));
         AssignAttri("", false, "A1631PlaChofDsc", StringUtil.RTrim( A1631PlaChofDsc));
         AssignAttri("", false, "A1637PlaLicen", StringUtil.RTrim( A1637PlaLicen));
         AssignAttri("", false, "A1634PlaDNI", StringUtil.RTrim( A1634PlaDNI));
         AssignAttri("", false, "A1642PlaRef1", StringUtil.RTrim( A1642PlaRef1));
         AssignAttri("", false, "A1643PlaRef2", StringUtil.RTrim( A1643PlaRef2));
         AssignAttri("", false, "A1644PlaRef3", StringUtil.RTrim( A1644PlaRef3));
         AssignAttri("", false, "A1645PlaRef4", StringUtil.RTrim( A1645PlaRef4));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z44PlaCod", StringUtil.RTrim( Z44PlaCod));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z1639PlaMarca", StringUtil.RTrim( Z1639PlaMarca));
         GxWebStd.gx_hidden_field( context, "Z1640PlaModel", StringUtil.RTrim( Z1640PlaModel));
         GxWebStd.gx_hidden_field( context, "Z1632PlaColor", StringUtil.RTrim( Z1632PlaColor));
         GxWebStd.gx_hidden_field( context, "Z1630PlaChasis", StringUtil.RTrim( Z1630PlaChasis));
         GxWebStd.gx_hidden_field( context, "Z1641PlaMotor", StringUtil.RTrim( Z1641PlaMotor));
         GxWebStd.gx_hidden_field( context, "Z1633PlaDirec", StringUtil.RTrim( Z1633PlaDirec));
         GxWebStd.gx_hidden_field( context, "Z1638PlaMaqu", StringUtil.RTrim( Z1638PlaMaqu));
         GxWebStd.gx_hidden_field( context, "Z1646PlaTelf", StringUtil.RTrim( Z1646PlaTelf));
         GxWebStd.gx_hidden_field( context, "Z1629PlaAsiento", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1629PlaAsiento), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1636PlaKilom", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1636PlaKilom), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1635PlaEjes", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1635PlaEjes), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1628PlaAno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1628PlaAno), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1631PlaChofDsc", StringUtil.RTrim( Z1631PlaChofDsc));
         GxWebStd.gx_hidden_field( context, "Z1637PlaLicen", StringUtil.RTrim( Z1637PlaLicen));
         GxWebStd.gx_hidden_field( context, "Z1634PlaDNI", StringUtil.RTrim( Z1634PlaDNI));
         GxWebStd.gx_hidden_field( context, "Z1642PlaRef1", StringUtil.RTrim( Z1642PlaRef1));
         GxWebStd.gx_hidden_field( context, "Z1643PlaRef2", StringUtil.RTrim( Z1643PlaRef2));
         GxWebStd.gx_hidden_field( context, "Z1644PlaRef3", StringUtil.RTrim( Z1644PlaRef3));
         GxWebStd.gx_hidden_field( context, "Z1645PlaRef4", StringUtil.RTrim( Z1645PlaRef4));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clicod( )
      {
         /* Using cursor T001914 */
         pr_default.execute(12, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
         }
         pr_default.close(12);
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
         setEventMetadata("VALID_PLACOD","{handler:'Valid_Placod',iparms:[{av:'A44PlaCod',fld:'PLACOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_PLACOD",",oparms:[{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A1639PlaMarca',fld:'PLAMARCA',pic:''},{av:'A1640PlaModel',fld:'PLAMODEL',pic:''},{av:'A1632PlaColor',fld:'PLACOLOR',pic:''},{av:'A1630PlaChasis',fld:'PLACHASIS',pic:''},{av:'A1641PlaMotor',fld:'PLAMOTOR',pic:''},{av:'A1633PlaDirec',fld:'PLADIREC',pic:''},{av:'A1638PlaMaqu',fld:'PLAMAQU',pic:''},{av:'A1646PlaTelf',fld:'PLATELF',pic:''},{av:'A1629PlaAsiento',fld:'PLAASIENTO',pic:'ZZZ9'},{av:'A1636PlaKilom',fld:'PLAKILOM',pic:'ZZZ9'},{av:'A1635PlaEjes',fld:'PLAEJES',pic:'ZZZ9'},{av:'A1628PlaAno',fld:'PLAANO',pic:'ZZZ9'},{av:'A1631PlaChofDsc',fld:'PLACHOFDSC',pic:''},{av:'A1637PlaLicen',fld:'PLALICEN',pic:''},{av:'A1634PlaDNI',fld:'PLADNI',pic:''},{av:'A1642PlaRef1',fld:'PLAREF1',pic:''},{av:'A1643PlaRef2',fld:'PLAREF2',pic:''},{av:'A1644PlaRef3',fld:'PLAREF3',pic:''},{av:'A1645PlaRef4',fld:'PLAREF4',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z44PlaCod'},{av:'Z45CliCod'},{av:'Z1639PlaMarca'},{av:'Z1640PlaModel'},{av:'Z1632PlaColor'},{av:'Z1630PlaChasis'},{av:'Z1641PlaMotor'},{av:'Z1633PlaDirec'},{av:'Z1638PlaMaqu'},{av:'Z1646PlaTelf'},{av:'Z1629PlaAsiento'},{av:'Z1636PlaKilom'},{av:'Z1635PlaEjes'},{av:'Z1628PlaAno'},{av:'Z1631PlaChofDsc'},{av:'Z1637PlaLicen'},{av:'Z1634PlaDNI'},{av:'Z1642PlaRef1'},{av:'Z1643PlaRef2'},{av:'Z1644PlaRef3'},{av:'Z1645PlaRef4'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''}]");
         setEventMetadata("VALID_CLICOD",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z44PlaCod = "";
         Z1639PlaMarca = "";
         Z1640PlaModel = "";
         Z1632PlaColor = "";
         Z1630PlaChasis = "";
         Z1641PlaMotor = "";
         Z1633PlaDirec = "";
         Z1638PlaMaqu = "";
         Z1646PlaTelf = "";
         Z1631PlaChofDsc = "";
         Z1637PlaLicen = "";
         Z1634PlaDNI = "";
         Z1642PlaRef1 = "";
         Z1643PlaRef2 = "";
         Z1644PlaRef3 = "";
         Z1645PlaRef4 = "";
         Z45CliCod = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A45CliCod = "";
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
         A44PlaCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A1639PlaMarca = "";
         lblTextblock4_Jsonclick = "";
         A1640PlaModel = "";
         lblTextblock5_Jsonclick = "";
         A1632PlaColor = "";
         lblTextblock6_Jsonclick = "";
         A1630PlaChasis = "";
         lblTextblock7_Jsonclick = "";
         A1641PlaMotor = "";
         lblTextblock8_Jsonclick = "";
         A1633PlaDirec = "";
         lblTextblock9_Jsonclick = "";
         A1638PlaMaqu = "";
         lblTextblock10_Jsonclick = "";
         A1646PlaTelf = "";
         lblTextblock11_Jsonclick = "";
         lblTextblock12_Jsonclick = "";
         lblTextblock13_Jsonclick = "";
         lblTextblock14_Jsonclick = "";
         lblTextblock15_Jsonclick = "";
         A1631PlaChofDsc = "";
         lblTextblock16_Jsonclick = "";
         A1637PlaLicen = "";
         lblTextblock17_Jsonclick = "";
         A1634PlaDNI = "";
         lblTextblock18_Jsonclick = "";
         A1642PlaRef1 = "";
         lblTextblock19_Jsonclick = "";
         A1643PlaRef2 = "";
         lblTextblock20_Jsonclick = "";
         A1644PlaRef3 = "";
         lblTextblock21_Jsonclick = "";
         A1645PlaRef4 = "";
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
         T00195_A44PlaCod = new string[] {""} ;
         T00195_A1639PlaMarca = new string[] {""} ;
         T00195_A1640PlaModel = new string[] {""} ;
         T00195_A1632PlaColor = new string[] {""} ;
         T00195_A1630PlaChasis = new string[] {""} ;
         T00195_A1641PlaMotor = new string[] {""} ;
         T00195_A1633PlaDirec = new string[] {""} ;
         T00195_A1638PlaMaqu = new string[] {""} ;
         T00195_A1646PlaTelf = new string[] {""} ;
         T00195_A1629PlaAsiento = new short[1] ;
         T00195_A1636PlaKilom = new short[1] ;
         T00195_A1635PlaEjes = new short[1] ;
         T00195_A1628PlaAno = new short[1] ;
         T00195_A1631PlaChofDsc = new string[] {""} ;
         T00195_A1637PlaLicen = new string[] {""} ;
         T00195_A1634PlaDNI = new string[] {""} ;
         T00195_A1642PlaRef1 = new string[] {""} ;
         T00195_A1643PlaRef2 = new string[] {""} ;
         T00195_A1644PlaRef3 = new string[] {""} ;
         T00195_A1645PlaRef4 = new string[] {""} ;
         T00195_A45CliCod = new string[] {""} ;
         T00194_A45CliCod = new string[] {""} ;
         T00196_A45CliCod = new string[] {""} ;
         T00197_A44PlaCod = new string[] {""} ;
         T00193_A44PlaCod = new string[] {""} ;
         T00193_A1639PlaMarca = new string[] {""} ;
         T00193_A1640PlaModel = new string[] {""} ;
         T00193_A1632PlaColor = new string[] {""} ;
         T00193_A1630PlaChasis = new string[] {""} ;
         T00193_A1641PlaMotor = new string[] {""} ;
         T00193_A1633PlaDirec = new string[] {""} ;
         T00193_A1638PlaMaqu = new string[] {""} ;
         T00193_A1646PlaTelf = new string[] {""} ;
         T00193_A1629PlaAsiento = new short[1] ;
         T00193_A1636PlaKilom = new short[1] ;
         T00193_A1635PlaEjes = new short[1] ;
         T00193_A1628PlaAno = new short[1] ;
         T00193_A1631PlaChofDsc = new string[] {""} ;
         T00193_A1637PlaLicen = new string[] {""} ;
         T00193_A1634PlaDNI = new string[] {""} ;
         T00193_A1642PlaRef1 = new string[] {""} ;
         T00193_A1643PlaRef2 = new string[] {""} ;
         T00193_A1644PlaRef3 = new string[] {""} ;
         T00193_A1645PlaRef4 = new string[] {""} ;
         T00193_A45CliCod = new string[] {""} ;
         sMode43 = "";
         T00198_A44PlaCod = new string[] {""} ;
         T00199_A44PlaCod = new string[] {""} ;
         T00192_A44PlaCod = new string[] {""} ;
         T00192_A1639PlaMarca = new string[] {""} ;
         T00192_A1640PlaModel = new string[] {""} ;
         T00192_A1632PlaColor = new string[] {""} ;
         T00192_A1630PlaChasis = new string[] {""} ;
         T00192_A1641PlaMotor = new string[] {""} ;
         T00192_A1633PlaDirec = new string[] {""} ;
         T00192_A1638PlaMaqu = new string[] {""} ;
         T00192_A1646PlaTelf = new string[] {""} ;
         T00192_A1629PlaAsiento = new short[1] ;
         T00192_A1636PlaKilom = new short[1] ;
         T00192_A1635PlaEjes = new short[1] ;
         T00192_A1628PlaAno = new short[1] ;
         T00192_A1631PlaChofDsc = new string[] {""} ;
         T00192_A1637PlaLicen = new string[] {""} ;
         T00192_A1634PlaDNI = new string[] {""} ;
         T00192_A1642PlaRef1 = new string[] {""} ;
         T00192_A1643PlaRef2 = new string[] {""} ;
         T00192_A1644PlaRef3 = new string[] {""} ;
         T00192_A1645PlaRef4 = new string[] {""} ;
         T00192_A45CliCod = new string[] {""} ;
         T001913_A44PlaCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ44PlaCod = "";
         ZZ45CliCod = "";
         ZZ1639PlaMarca = "";
         ZZ1640PlaModel = "";
         ZZ1632PlaColor = "";
         ZZ1630PlaChasis = "";
         ZZ1641PlaMotor = "";
         ZZ1633PlaDirec = "";
         ZZ1638PlaMaqu = "";
         ZZ1646PlaTelf = "";
         ZZ1631PlaChofDsc = "";
         ZZ1637PlaLicen = "";
         ZZ1634PlaDNI = "";
         ZZ1642PlaRef1 = "";
         ZZ1643PlaRef2 = "";
         ZZ1644PlaRef3 = "";
         ZZ1645PlaRef4 = "";
         T001914_A45CliCod = new string[] {""} ;
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aplacas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aplacas__default(),
            new Object[][] {
                new Object[] {
               T00192_A44PlaCod, T00192_A1639PlaMarca, T00192_A1640PlaModel, T00192_A1632PlaColor, T00192_A1630PlaChasis, T00192_A1641PlaMotor, T00192_A1633PlaDirec, T00192_A1638PlaMaqu, T00192_A1646PlaTelf, T00192_A1629PlaAsiento,
               T00192_A1636PlaKilom, T00192_A1635PlaEjes, T00192_A1628PlaAno, T00192_A1631PlaChofDsc, T00192_A1637PlaLicen, T00192_A1634PlaDNI, T00192_A1642PlaRef1, T00192_A1643PlaRef2, T00192_A1644PlaRef3, T00192_A1645PlaRef4,
               T00192_A45CliCod
               }
               , new Object[] {
               T00193_A44PlaCod, T00193_A1639PlaMarca, T00193_A1640PlaModel, T00193_A1632PlaColor, T00193_A1630PlaChasis, T00193_A1641PlaMotor, T00193_A1633PlaDirec, T00193_A1638PlaMaqu, T00193_A1646PlaTelf, T00193_A1629PlaAsiento,
               T00193_A1636PlaKilom, T00193_A1635PlaEjes, T00193_A1628PlaAno, T00193_A1631PlaChofDsc, T00193_A1637PlaLicen, T00193_A1634PlaDNI, T00193_A1642PlaRef1, T00193_A1643PlaRef2, T00193_A1644PlaRef3, T00193_A1645PlaRef4,
               T00193_A45CliCod
               }
               , new Object[] {
               T00194_A45CliCod
               }
               , new Object[] {
               T00195_A44PlaCod, T00195_A1639PlaMarca, T00195_A1640PlaModel, T00195_A1632PlaColor, T00195_A1630PlaChasis, T00195_A1641PlaMotor, T00195_A1633PlaDirec, T00195_A1638PlaMaqu, T00195_A1646PlaTelf, T00195_A1629PlaAsiento,
               T00195_A1636PlaKilom, T00195_A1635PlaEjes, T00195_A1628PlaAno, T00195_A1631PlaChofDsc, T00195_A1637PlaLicen, T00195_A1634PlaDNI, T00195_A1642PlaRef1, T00195_A1643PlaRef2, T00195_A1644PlaRef3, T00195_A1645PlaRef4,
               T00195_A45CliCod
               }
               , new Object[] {
               T00196_A45CliCod
               }
               , new Object[] {
               T00197_A44PlaCod
               }
               , new Object[] {
               T00198_A44PlaCod
               }
               , new Object[] {
               T00199_A44PlaCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001913_A44PlaCod
               }
               , new Object[] {
               T001914_A45CliCod
               }
            }
         );
      }

      private short Z1629PlaAsiento ;
      private short Z1636PlaKilom ;
      private short Z1635PlaEjes ;
      private short Z1628PlaAno ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1629PlaAsiento ;
      private short A1636PlaKilom ;
      private short A1635PlaEjes ;
      private short A1628PlaAno ;
      private short GX_JID ;
      private short RcdFound43 ;
      private short nIsDirty_43 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ1629PlaAsiento ;
      private short ZZ1636PlaKilom ;
      private short ZZ1635PlaEjes ;
      private short ZZ1628PlaAno ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPlaCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCliCod_Enabled ;
      private int edtPlaMarca_Enabled ;
      private int edtPlaModel_Enabled ;
      private int edtPlaColor_Enabled ;
      private int edtPlaChasis_Enabled ;
      private int edtPlaMotor_Enabled ;
      private int edtPlaDirec_Enabled ;
      private int edtPlaMaqu_Enabled ;
      private int edtPlaTelf_Enabled ;
      private int edtPlaAsiento_Enabled ;
      private int edtPlaKilom_Enabled ;
      private int edtPlaEjes_Enabled ;
      private int edtPlaAno_Enabled ;
      private int edtPlaChofDsc_Enabled ;
      private int edtPlaLicen_Enabled ;
      private int edtPlaDNI_Enabled ;
      private int edtPlaRef1_Enabled ;
      private int edtPlaRef2_Enabled ;
      private int edtPlaRef3_Enabled ;
      private int edtPlaRef4_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private string sPrefix ;
      private string Z44PlaCod ;
      private string Z1639PlaMarca ;
      private string Z1640PlaModel ;
      private string Z1632PlaColor ;
      private string Z1630PlaChasis ;
      private string Z1641PlaMotor ;
      private string Z1633PlaDirec ;
      private string Z1638PlaMaqu ;
      private string Z1646PlaTelf ;
      private string Z1631PlaChofDsc ;
      private string Z1637PlaLicen ;
      private string Z1634PlaDNI ;
      private string Z1642PlaRef1 ;
      private string Z1643PlaRef2 ;
      private string Z1644PlaRef3 ;
      private string Z1645PlaRef4 ;
      private string Z45CliCod ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A45CliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPlaCod_Internalname ;
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
      private string A44PlaCod ;
      private string edtPlaCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCliCod_Internalname ;
      private string edtCliCod_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtPlaMarca_Internalname ;
      private string A1639PlaMarca ;
      private string edtPlaMarca_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtPlaModel_Internalname ;
      private string A1640PlaModel ;
      private string edtPlaModel_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtPlaColor_Internalname ;
      private string A1632PlaColor ;
      private string edtPlaColor_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtPlaChasis_Internalname ;
      private string A1630PlaChasis ;
      private string edtPlaChasis_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtPlaMotor_Internalname ;
      private string A1641PlaMotor ;
      private string edtPlaMotor_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtPlaDirec_Internalname ;
      private string A1633PlaDirec ;
      private string edtPlaDirec_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtPlaMaqu_Internalname ;
      private string A1638PlaMaqu ;
      private string edtPlaMaqu_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtPlaTelf_Internalname ;
      private string A1646PlaTelf ;
      private string edtPlaTelf_Jsonclick ;
      private string lblTextblock11_Internalname ;
      private string lblTextblock11_Jsonclick ;
      private string edtPlaAsiento_Internalname ;
      private string edtPlaAsiento_Jsonclick ;
      private string lblTextblock12_Internalname ;
      private string lblTextblock12_Jsonclick ;
      private string edtPlaKilom_Internalname ;
      private string edtPlaKilom_Jsonclick ;
      private string lblTextblock13_Internalname ;
      private string lblTextblock13_Jsonclick ;
      private string edtPlaEjes_Internalname ;
      private string edtPlaEjes_Jsonclick ;
      private string lblTextblock14_Internalname ;
      private string lblTextblock14_Jsonclick ;
      private string edtPlaAno_Internalname ;
      private string edtPlaAno_Jsonclick ;
      private string lblTextblock15_Internalname ;
      private string lblTextblock15_Jsonclick ;
      private string edtPlaChofDsc_Internalname ;
      private string A1631PlaChofDsc ;
      private string edtPlaChofDsc_Jsonclick ;
      private string lblTextblock16_Internalname ;
      private string lblTextblock16_Jsonclick ;
      private string edtPlaLicen_Internalname ;
      private string A1637PlaLicen ;
      private string edtPlaLicen_Jsonclick ;
      private string lblTextblock17_Internalname ;
      private string lblTextblock17_Jsonclick ;
      private string edtPlaDNI_Internalname ;
      private string A1634PlaDNI ;
      private string edtPlaDNI_Jsonclick ;
      private string lblTextblock18_Internalname ;
      private string lblTextblock18_Jsonclick ;
      private string edtPlaRef1_Internalname ;
      private string A1642PlaRef1 ;
      private string edtPlaRef1_Jsonclick ;
      private string lblTextblock19_Internalname ;
      private string lblTextblock19_Jsonclick ;
      private string edtPlaRef2_Internalname ;
      private string A1643PlaRef2 ;
      private string edtPlaRef2_Jsonclick ;
      private string lblTextblock20_Internalname ;
      private string lblTextblock20_Jsonclick ;
      private string edtPlaRef3_Internalname ;
      private string A1644PlaRef3 ;
      private string edtPlaRef3_Jsonclick ;
      private string lblTextblock21_Internalname ;
      private string lblTextblock21_Jsonclick ;
      private string edtPlaRef4_Internalname ;
      private string A1645PlaRef4 ;
      private string edtPlaRef4_Jsonclick ;
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
      private string sMode43 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ44PlaCod ;
      private string ZZ45CliCod ;
      private string ZZ1639PlaMarca ;
      private string ZZ1640PlaModel ;
      private string ZZ1632PlaColor ;
      private string ZZ1630PlaChasis ;
      private string ZZ1641PlaMotor ;
      private string ZZ1633PlaDirec ;
      private string ZZ1638PlaMaqu ;
      private string ZZ1646PlaTelf ;
      private string ZZ1631PlaChofDsc ;
      private string ZZ1637PlaLicen ;
      private string ZZ1634PlaDNI ;
      private string ZZ1642PlaRef1 ;
      private string ZZ1643PlaRef2 ;
      private string ZZ1644PlaRef3 ;
      private string ZZ1645PlaRef4 ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00195_A44PlaCod ;
      private string[] T00195_A1639PlaMarca ;
      private string[] T00195_A1640PlaModel ;
      private string[] T00195_A1632PlaColor ;
      private string[] T00195_A1630PlaChasis ;
      private string[] T00195_A1641PlaMotor ;
      private string[] T00195_A1633PlaDirec ;
      private string[] T00195_A1638PlaMaqu ;
      private string[] T00195_A1646PlaTelf ;
      private short[] T00195_A1629PlaAsiento ;
      private short[] T00195_A1636PlaKilom ;
      private short[] T00195_A1635PlaEjes ;
      private short[] T00195_A1628PlaAno ;
      private string[] T00195_A1631PlaChofDsc ;
      private string[] T00195_A1637PlaLicen ;
      private string[] T00195_A1634PlaDNI ;
      private string[] T00195_A1642PlaRef1 ;
      private string[] T00195_A1643PlaRef2 ;
      private string[] T00195_A1644PlaRef3 ;
      private string[] T00195_A1645PlaRef4 ;
      private string[] T00195_A45CliCod ;
      private string[] T00194_A45CliCod ;
      private string[] T00196_A45CliCod ;
      private string[] T00197_A44PlaCod ;
      private string[] T00193_A44PlaCod ;
      private string[] T00193_A1639PlaMarca ;
      private string[] T00193_A1640PlaModel ;
      private string[] T00193_A1632PlaColor ;
      private string[] T00193_A1630PlaChasis ;
      private string[] T00193_A1641PlaMotor ;
      private string[] T00193_A1633PlaDirec ;
      private string[] T00193_A1638PlaMaqu ;
      private string[] T00193_A1646PlaTelf ;
      private short[] T00193_A1629PlaAsiento ;
      private short[] T00193_A1636PlaKilom ;
      private short[] T00193_A1635PlaEjes ;
      private short[] T00193_A1628PlaAno ;
      private string[] T00193_A1631PlaChofDsc ;
      private string[] T00193_A1637PlaLicen ;
      private string[] T00193_A1634PlaDNI ;
      private string[] T00193_A1642PlaRef1 ;
      private string[] T00193_A1643PlaRef2 ;
      private string[] T00193_A1644PlaRef3 ;
      private string[] T00193_A1645PlaRef4 ;
      private string[] T00193_A45CliCod ;
      private string[] T00198_A44PlaCod ;
      private string[] T00199_A44PlaCod ;
      private string[] T00192_A44PlaCod ;
      private string[] T00192_A1639PlaMarca ;
      private string[] T00192_A1640PlaModel ;
      private string[] T00192_A1632PlaColor ;
      private string[] T00192_A1630PlaChasis ;
      private string[] T00192_A1641PlaMotor ;
      private string[] T00192_A1633PlaDirec ;
      private string[] T00192_A1638PlaMaqu ;
      private string[] T00192_A1646PlaTelf ;
      private short[] T00192_A1629PlaAsiento ;
      private short[] T00192_A1636PlaKilom ;
      private short[] T00192_A1635PlaEjes ;
      private short[] T00192_A1628PlaAno ;
      private string[] T00192_A1631PlaChofDsc ;
      private string[] T00192_A1637PlaLicen ;
      private string[] T00192_A1634PlaDNI ;
      private string[] T00192_A1642PlaRef1 ;
      private string[] T00192_A1643PlaRef2 ;
      private string[] T00192_A1644PlaRef3 ;
      private string[] T00192_A1645PlaRef4 ;
      private string[] T00192_A45CliCod ;
      private string[] T001913_A44PlaCod ;
      private string[] T001914_A45CliCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aplacas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aplacas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00195;
        prmT00195 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT00194;
        prmT00194 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT00196;
        prmT00196 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT00197;
        prmT00197 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT00193;
        prmT00193 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT00198;
        prmT00198 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT00199;
        prmT00199 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT00192;
        prmT00192 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT001910;
        prmT001910 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0) ,
        new ParDef("@PlaMarca",GXType.NChar,50,0) ,
        new ParDef("@PlaModel",GXType.NChar,50,0) ,
        new ParDef("@PlaColor",GXType.NChar,50,0) ,
        new ParDef("@PlaChasis",GXType.NChar,50,0) ,
        new ParDef("@PlaMotor",GXType.NChar,50,0) ,
        new ParDef("@PlaDirec",GXType.NChar,50,0) ,
        new ParDef("@PlaMaqu",GXType.NChar,50,0) ,
        new ParDef("@PlaTelf",GXType.NChar,50,0) ,
        new ParDef("@PlaAsiento",GXType.Int16,4,0) ,
        new ParDef("@PlaKilom",GXType.Int16,4,0) ,
        new ParDef("@PlaEjes",GXType.Int16,4,0) ,
        new ParDef("@PlaAno",GXType.Int16,4,0) ,
        new ParDef("@PlaChofDsc",GXType.NChar,100,0) ,
        new ParDef("@PlaLicen",GXType.NChar,20,0) ,
        new ParDef("@PlaDNI",GXType.NChar,20,0) ,
        new ParDef("@PlaRef1",GXType.NChar,100,0) ,
        new ParDef("@PlaRef2",GXType.NChar,100,0) ,
        new ParDef("@PlaRef3",GXType.NChar,100,0) ,
        new ParDef("@PlaRef4",GXType.NChar,100,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT001911;
        prmT001911 = new Object[] {
        new ParDef("@PlaMarca",GXType.NChar,50,0) ,
        new ParDef("@PlaModel",GXType.NChar,50,0) ,
        new ParDef("@PlaColor",GXType.NChar,50,0) ,
        new ParDef("@PlaChasis",GXType.NChar,50,0) ,
        new ParDef("@PlaMotor",GXType.NChar,50,0) ,
        new ParDef("@PlaDirec",GXType.NChar,50,0) ,
        new ParDef("@PlaMaqu",GXType.NChar,50,0) ,
        new ParDef("@PlaTelf",GXType.NChar,50,0) ,
        new ParDef("@PlaAsiento",GXType.Int16,4,0) ,
        new ParDef("@PlaKilom",GXType.Int16,4,0) ,
        new ParDef("@PlaEjes",GXType.Int16,4,0) ,
        new ParDef("@PlaAno",GXType.Int16,4,0) ,
        new ParDef("@PlaChofDsc",GXType.NChar,100,0) ,
        new ParDef("@PlaLicen",GXType.NChar,20,0) ,
        new ParDef("@PlaDNI",GXType.NChar,20,0) ,
        new ParDef("@PlaRef1",GXType.NChar,100,0) ,
        new ParDef("@PlaRef2",GXType.NChar,100,0) ,
        new ParDef("@PlaRef3",GXType.NChar,100,0) ,
        new ParDef("@PlaRef4",GXType.NChar,100,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT001912;
        prmT001912 = new Object[] {
        new ParDef("@PlaCod",GXType.NChar,20,0)
        };
        Object[] prmT001913;
        prmT001913 = new Object[] {
        };
        Object[] prmT001914;
        prmT001914 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00192", "SELECT [PlaCod], [PlaMarca], [PlaModel], [PlaColor], [PlaChasis], [PlaMotor], [PlaDirec], [PlaMaqu], [PlaTelf], [PlaAsiento], [PlaKilom], [PlaEjes], [PlaAno], [PlaChofDsc], [PlaLicen], [PlaDNI], [PlaRef1], [PlaRef2], [PlaRef3], [PlaRef4], [CliCod] FROM [APLACAS] WITH (UPDLOCK) WHERE [PlaCod] = @PlaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00192,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00193", "SELECT [PlaCod], [PlaMarca], [PlaModel], [PlaColor], [PlaChasis], [PlaMotor], [PlaDirec], [PlaMaqu], [PlaTelf], [PlaAsiento], [PlaKilom], [PlaEjes], [PlaAno], [PlaChofDsc], [PlaLicen], [PlaDNI], [PlaRef1], [PlaRef2], [PlaRef3], [PlaRef4], [CliCod] FROM [APLACAS] WHERE [PlaCod] = @PlaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00193,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00194", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00194,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00195", "SELECT TM1.[PlaCod], TM1.[PlaMarca], TM1.[PlaModel], TM1.[PlaColor], TM1.[PlaChasis], TM1.[PlaMotor], TM1.[PlaDirec], TM1.[PlaMaqu], TM1.[PlaTelf], TM1.[PlaAsiento], TM1.[PlaKilom], TM1.[PlaEjes], TM1.[PlaAno], TM1.[PlaChofDsc], TM1.[PlaLicen], TM1.[PlaDNI], TM1.[PlaRef1], TM1.[PlaRef2], TM1.[PlaRef3], TM1.[PlaRef4], TM1.[CliCod] FROM [APLACAS] TM1 WHERE TM1.[PlaCod] = @PlaCod ORDER BY TM1.[PlaCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00195,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00196", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00196,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00197", "SELECT [PlaCod] FROM [APLACAS] WHERE [PlaCod] = @PlaCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00197,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00198", "SELECT TOP 1 [PlaCod] FROM [APLACAS] WHERE ( [PlaCod] > @PlaCod) ORDER BY [PlaCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00198,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00199", "SELECT TOP 1 [PlaCod] FROM [APLACAS] WHERE ( [PlaCod] < @PlaCod) ORDER BY [PlaCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00199,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001910", "INSERT INTO [APLACAS]([PlaCod], [PlaMarca], [PlaModel], [PlaColor], [PlaChasis], [PlaMotor], [PlaDirec], [PlaMaqu], [PlaTelf], [PlaAsiento], [PlaKilom], [PlaEjes], [PlaAno], [PlaChofDsc], [PlaLicen], [PlaDNI], [PlaRef1], [PlaRef2], [PlaRef3], [PlaRef4], [CliCod]) VALUES(@PlaCod, @PlaMarca, @PlaModel, @PlaColor, @PlaChasis, @PlaMotor, @PlaDirec, @PlaMaqu, @PlaTelf, @PlaAsiento, @PlaKilom, @PlaEjes, @PlaAno, @PlaChofDsc, @PlaLicen, @PlaDNI, @PlaRef1, @PlaRef2, @PlaRef3, @PlaRef4, @CliCod)", GxErrorMask.GX_NOMASK,prmT001910)
           ,new CursorDef("T001911", "UPDATE [APLACAS] SET [PlaMarca]=@PlaMarca, [PlaModel]=@PlaModel, [PlaColor]=@PlaColor, [PlaChasis]=@PlaChasis, [PlaMotor]=@PlaMotor, [PlaDirec]=@PlaDirec, [PlaMaqu]=@PlaMaqu, [PlaTelf]=@PlaTelf, [PlaAsiento]=@PlaAsiento, [PlaKilom]=@PlaKilom, [PlaEjes]=@PlaEjes, [PlaAno]=@PlaAno, [PlaChofDsc]=@PlaChofDsc, [PlaLicen]=@PlaLicen, [PlaDNI]=@PlaDNI, [PlaRef1]=@PlaRef1, [PlaRef2]=@PlaRef2, [PlaRef3]=@PlaRef3, [PlaRef4]=@PlaRef4, [CliCod]=@CliCod  WHERE [PlaCod] = @PlaCod", GxErrorMask.GX_NOMASK,prmT001911)
           ,new CursorDef("T001912", "DELETE FROM [APLACAS]  WHERE [PlaCod] = @PlaCod", GxErrorMask.GX_NOMASK,prmT001912)
           ,new CursorDef("T001913", "SELECT [PlaCod] FROM [APLACAS] ORDER BY [PlaCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001913,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001914", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001914,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 50);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((string[]) buf[4])[0] = rslt.getString(5, 50);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              ((string[]) buf[6])[0] = rslt.getString(7, 50);
              ((string[]) buf[7])[0] = rslt.getString(8, 50);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 100);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 100);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((string[]) buf[19])[0] = rslt.getString(20, 100);
              ((string[]) buf[20])[0] = rslt.getString(21, 20);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 50);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((string[]) buf[4])[0] = rslt.getString(5, 50);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              ((string[]) buf[6])[0] = rslt.getString(7, 50);
              ((string[]) buf[7])[0] = rslt.getString(8, 50);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 100);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 100);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((string[]) buf[19])[0] = rslt.getString(20, 100);
              ((string[]) buf[20])[0] = rslt.getString(21, 20);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 50);
              ((string[]) buf[2])[0] = rslt.getString(3, 50);
              ((string[]) buf[3])[0] = rslt.getString(4, 50);
              ((string[]) buf[4])[0] = rslt.getString(5, 50);
              ((string[]) buf[5])[0] = rslt.getString(6, 50);
              ((string[]) buf[6])[0] = rslt.getString(7, 50);
              ((string[]) buf[7])[0] = rslt.getString(8, 50);
              ((string[]) buf[8])[0] = rslt.getString(9, 50);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              ((short[]) buf[10])[0] = rslt.getShort(11);
              ((short[]) buf[11])[0] = rslt.getShort(12);
              ((short[]) buf[12])[0] = rslt.getShort(13);
              ((string[]) buf[13])[0] = rslt.getString(14, 100);
              ((string[]) buf[14])[0] = rslt.getString(15, 20);
              ((string[]) buf[15])[0] = rslt.getString(16, 20);
              ((string[]) buf[16])[0] = rslt.getString(17, 100);
              ((string[]) buf[17])[0] = rslt.getString(18, 100);
              ((string[]) buf[18])[0] = rslt.getString(19, 100);
              ((string[]) buf[19])[0] = rslt.getString(20, 100);
              ((string[]) buf[20])[0] = rslt.getString(21, 20);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
  }

}

}
