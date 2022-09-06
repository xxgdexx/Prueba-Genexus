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
   public class clclientesdireccion : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A165CliDirZonCod = (int)(NumberUtil.Val( GetPar( "CliDirZonCod"), "."));
            AssignAttri("", false, "A165CliDirZonCod", StringUtil.LTrimStr( (decimal)(A165CliDirZonCod), 6, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A165CliDirZonCod) ;
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
            Form.Meta.addItem("description", "Clientes - Direcciones", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clclientesdireccion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public clclientesdireccion( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CLCLIENTESDIRECCION.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Cliente", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliCod_Internalname, StringUtil.RTrim( A45CliCod), StringUtil.RTrim( context.localUtil.Format( A45CliCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliCod_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Item", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirItem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A164CliDirItem), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliDirItem_Enabled!=0) ? context.localUtil.Format( (decimal)(A164CliDirItem), "ZZZZZ9") : context.localUtil.Format( (decimal)(A164CliDirItem), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirItem_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirItem_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Razon Social", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirDsc_Internalname, StringUtil.RTrim( A600CliDirDsc), StringUtil.RTrim( context.localUtil.Format( A600CliDirDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Dirección", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirDir_Internalname, StringUtil.RTrim( A598CliDirDir), StringUtil.RTrim( context.localUtil.Format( A598CliDirDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Pais", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirPais_Internalname, StringUtil.RTrim( A605CliDirPais), StringUtil.RTrim( context.localUtil.Format( A605CliDirPais, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirPais_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirPais_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Departamento", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirDep_Internalname, StringUtil.RTrim( A597CliDirDep), StringUtil.RTrim( context.localUtil.Format( A597CliDirDep, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirDep_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirDep_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock7_Internalname, "Provincia", "", "", lblTextblock7_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirProv_Internalname, StringUtil.RTrim( A606CliDirProv), StringUtil.RTrim( context.localUtil.Format( A606CliDirProv, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirProv_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirProv_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock8_Internalname, "Distrito", "", "", lblTextblock8_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirDis_Internalname, StringUtil.RTrim( A599CliDirDis), StringUtil.RTrim( context.localUtil.Format( A599CliDirDis, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirDis_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirDis_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock9_Internalname, "Zona", "", "", lblTextblock9_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliDirZonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A165CliDirZonCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtCliDirZonCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A165CliDirZonCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A165CliDirZonCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,61);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirZonCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirZonCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock10_Internalname, "Zona", "", "", lblTextblock10_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliDirZonDsc_Internalname, StringUtil.RTrim( A607CliDirZonDsc), StringUtil.RTrim( context.localUtil.Format( A607CliDirZonDsc, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliDirZonDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCliDirZonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CLCLIENTESDIRECCION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CLCLIENTESDIRECCION.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CLCLIENTESDIRECCION.htm");
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
            Z45CliCod = cgiGet( "Z45CliCod");
            Z164CliDirItem = (int)(context.localUtil.CToN( cgiGet( "Z164CliDirItem"), ".", ","));
            Z600CliDirDsc = cgiGet( "Z600CliDirDsc");
            Z598CliDirDir = cgiGet( "Z598CliDirDir");
            Z605CliDirPais = cgiGet( "Z605CliDirPais");
            Z597CliDirDep = cgiGet( "Z597CliDirDep");
            Z606CliDirProv = cgiGet( "Z606CliDirProv");
            Z599CliDirDis = cgiGet( "Z599CliDirDis");
            Z165CliDirZonCod = (int)(context.localUtil.CToN( cgiGet( "Z165CliDirZonCod"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A45CliCod = cgiGet( edtCliCod_Internalname);
            AssignAttri("", false, "A45CliCod", A45CliCod);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCliDirItem_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDirItem_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIDIRITEM");
               AnyError = 1;
               GX_FocusControl = edtCliDirItem_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A164CliDirItem = 0;
               AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
            }
            else
            {
               A164CliDirItem = (int)(context.localUtil.CToN( cgiGet( edtCliDirItem_Internalname), ".", ","));
               AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
            }
            A600CliDirDsc = cgiGet( edtCliDirDsc_Internalname);
            AssignAttri("", false, "A600CliDirDsc", A600CliDirDsc);
            A598CliDirDir = cgiGet( edtCliDirDir_Internalname);
            AssignAttri("", false, "A598CliDirDir", A598CliDirDir);
            A605CliDirPais = cgiGet( edtCliDirPais_Internalname);
            AssignAttri("", false, "A605CliDirPais", A605CliDirPais);
            A597CliDirDep = cgiGet( edtCliDirDep_Internalname);
            AssignAttri("", false, "A597CliDirDep", A597CliDirDep);
            A606CliDirProv = cgiGet( edtCliDirProv_Internalname);
            AssignAttri("", false, "A606CliDirProv", A606CliDirProv);
            A599CliDirDis = cgiGet( edtCliDirDis_Internalname);
            AssignAttri("", false, "A599CliDirDis", A599CliDirDis);
            if ( ( ( context.localUtil.CToN( cgiGet( edtCliDirZonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCliDirZonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIDIRZONCOD");
               AnyError = 1;
               GX_FocusControl = edtCliDirZonCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A165CliDirZonCod = 0;
               AssignAttri("", false, "A165CliDirZonCod", StringUtil.LTrimStr( (decimal)(A165CliDirZonCod), 6, 0));
            }
            else
            {
               A165CliDirZonCod = (int)(context.localUtil.CToN( cgiGet( edtCliDirZonCod_Internalname), ".", ","));
               AssignAttri("", false, "A165CliDirZonCod", StringUtil.LTrimStr( (decimal)(A165CliDirZonCod), 6, 0));
            }
            A607CliDirZonDsc = cgiGet( edtCliDirZonDsc_Internalname);
            AssignAttri("", false, "A607CliDirZonDsc", A607CliDirZonDsc);
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
               A45CliCod = GetPar( "CliCod");
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A164CliDirItem = (int)(NumberUtil.Val( GetPar( "CliDirItem"), "."));
               AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
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
               InitAll2F83( ) ;
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
         DisableAttributes2F83( ) ;
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

      protected void CONFIRM_2F0( )
      {
         BeforeValidate2F83( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls2F83( ) ;
            }
            else
            {
               CheckExtendedTable2F83( ) ;
               if ( AnyError == 0 )
               {
                  ZM2F83( 2) ;
                  ZM2F83( 3) ;
               }
               CloseExtendedTableCursors2F83( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues2F0( ) ;
         }
      }

      protected void ResetCaption2F0( )
      {
      }

      protected void ZM2F83( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z600CliDirDsc = T002F3_A600CliDirDsc[0];
               Z598CliDirDir = T002F3_A598CliDirDir[0];
               Z605CliDirPais = T002F3_A605CliDirPais[0];
               Z597CliDirDep = T002F3_A597CliDirDep[0];
               Z606CliDirProv = T002F3_A606CliDirProv[0];
               Z599CliDirDis = T002F3_A599CliDirDis[0];
               Z165CliDirZonCod = T002F3_A165CliDirZonCod[0];
            }
            else
            {
               Z600CliDirDsc = A600CliDirDsc;
               Z598CliDirDir = A598CliDirDir;
               Z605CliDirPais = A605CliDirPais;
               Z597CliDirDep = A597CliDirDep;
               Z606CliDirProv = A606CliDirProv;
               Z599CliDirDis = A599CliDirDis;
               Z165CliDirZonCod = A165CliDirZonCod;
            }
         }
         if ( GX_JID == -1 )
         {
            Z164CliDirItem = A164CliDirItem;
            Z600CliDirDsc = A600CliDirDsc;
            Z598CliDirDir = A598CliDirDir;
            Z605CliDirPais = A605CliDirPais;
            Z597CliDirDep = A597CliDirDep;
            Z606CliDirProv = A606CliDirProv;
            Z599CliDirDis = A599CliDirDis;
            Z45CliCod = A45CliCod;
            Z165CliDirZonCod = A165CliDirZonCod;
            Z607CliDirZonDsc = A607CliDirZonDsc;
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

      protected void Load2F83( )
      {
         /* Using cursor T002F6 */
         pr_default.execute(4, new Object[] {A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound83 = 1;
            A600CliDirDsc = T002F6_A600CliDirDsc[0];
            AssignAttri("", false, "A600CliDirDsc", A600CliDirDsc);
            A598CliDirDir = T002F6_A598CliDirDir[0];
            AssignAttri("", false, "A598CliDirDir", A598CliDirDir);
            A605CliDirPais = T002F6_A605CliDirPais[0];
            AssignAttri("", false, "A605CliDirPais", A605CliDirPais);
            A597CliDirDep = T002F6_A597CliDirDep[0];
            AssignAttri("", false, "A597CliDirDep", A597CliDirDep);
            A606CliDirProv = T002F6_A606CliDirProv[0];
            AssignAttri("", false, "A606CliDirProv", A606CliDirProv);
            A599CliDirDis = T002F6_A599CliDirDis[0];
            AssignAttri("", false, "A599CliDirDis", A599CliDirDis);
            A607CliDirZonDsc = T002F6_A607CliDirZonDsc[0];
            AssignAttri("", false, "A607CliDirZonDsc", A607CliDirZonDsc);
            A165CliDirZonCod = T002F6_A165CliDirZonCod[0];
            AssignAttri("", false, "A165CliDirZonCod", StringUtil.LTrimStr( (decimal)(A165CliDirZonCod), 6, 0));
            ZM2F83( -1) ;
         }
         pr_default.close(4);
         OnLoadActions2F83( ) ;
      }

      protected void OnLoadActions2F83( )
      {
      }

      protected void CheckExtendedTable2F83( )
      {
         nIsDirty_83 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T002F4 */
         pr_default.execute(2, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         /* Using cursor T002F5 */
         pr_default.execute(3, new Object[] {A165CliDirZonCod});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No existe 'Zona'.", "ForeignKeyNotFound", 1, "CLIDIRZONCOD");
            AnyError = 1;
            GX_FocusControl = edtCliDirZonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A607CliDirZonDsc = T002F5_A607CliDirZonDsc[0];
         AssignAttri("", false, "A607CliDirZonDsc", A607CliDirZonDsc);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors2F83( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_2( string A45CliCod )
      {
         /* Using cursor T002F7 */
         pr_default.execute(5, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
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

      protected void gxLoad_3( int A165CliDirZonCod )
      {
         /* Using cursor T002F8 */
         pr_default.execute(6, new Object[] {A165CliDirZonCod});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No existe 'Zona'.", "ForeignKeyNotFound", 1, "CLIDIRZONCOD");
            AnyError = 1;
            GX_FocusControl = edtCliDirZonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A607CliDirZonDsc = T002F8_A607CliDirZonDsc[0];
         AssignAttri("", false, "A607CliDirZonDsc", A607CliDirZonDsc);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A607CliDirZonDsc))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey2F83( )
      {
         /* Using cursor T002F9 */
         pr_default.execute(7, new Object[] {A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound83 = 1;
         }
         else
         {
            RcdFound83 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T002F3 */
         pr_default.execute(1, new Object[] {A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM2F83( 1) ;
            RcdFound83 = 1;
            A164CliDirItem = T002F3_A164CliDirItem[0];
            AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
            A600CliDirDsc = T002F3_A600CliDirDsc[0];
            AssignAttri("", false, "A600CliDirDsc", A600CliDirDsc);
            A598CliDirDir = T002F3_A598CliDirDir[0];
            AssignAttri("", false, "A598CliDirDir", A598CliDirDir);
            A605CliDirPais = T002F3_A605CliDirPais[0];
            AssignAttri("", false, "A605CliDirPais", A605CliDirPais);
            A597CliDirDep = T002F3_A597CliDirDep[0];
            AssignAttri("", false, "A597CliDirDep", A597CliDirDep);
            A606CliDirProv = T002F3_A606CliDirProv[0];
            AssignAttri("", false, "A606CliDirProv", A606CliDirProv);
            A599CliDirDis = T002F3_A599CliDirDis[0];
            AssignAttri("", false, "A599CliDirDis", A599CliDirDis);
            A45CliCod = T002F3_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A165CliDirZonCod = T002F3_A165CliDirZonCod[0];
            AssignAttri("", false, "A165CliDirZonCod", StringUtil.LTrimStr( (decimal)(A165CliDirZonCod), 6, 0));
            Z45CliCod = A45CliCod;
            Z164CliDirItem = A164CliDirItem;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load2F83( ) ;
            if ( AnyError == 1 )
            {
               RcdFound83 = 0;
               InitializeNonKey2F83( ) ;
            }
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound83 = 0;
            InitializeNonKey2F83( ) ;
            sMode83 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode83;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey2F83( ) ;
         if ( RcdFound83 == 0 )
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
         RcdFound83 = 0;
         /* Using cursor T002F10 */
         pr_default.execute(8, new Object[] {A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002F10_A45CliCod[0], A45CliCod) < 0 ) || ( StringUtil.StrCmp(T002F10_A45CliCod[0], A45CliCod) == 0 ) && ( T002F10_A164CliDirItem[0] < A164CliDirItem ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( StringUtil.StrCmp(T002F10_A45CliCod[0], A45CliCod) > 0 ) || ( StringUtil.StrCmp(T002F10_A45CliCod[0], A45CliCod) == 0 ) && ( T002F10_A164CliDirItem[0] > A164CliDirItem ) ) )
            {
               A45CliCod = T002F10_A45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A164CliDirItem = T002F10_A164CliDirItem[0];
               AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound83 = 0;
         /* Using cursor T002F11 */
         pr_default.execute(9, new Object[] {A45CliCod, A164CliDirItem});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002F11_A45CliCod[0], A45CliCod) > 0 ) || ( StringUtil.StrCmp(T002F11_A45CliCod[0], A45CliCod) == 0 ) && ( T002F11_A164CliDirItem[0] > A164CliDirItem ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( StringUtil.StrCmp(T002F11_A45CliCod[0], A45CliCod) < 0 ) || ( StringUtil.StrCmp(T002F11_A45CliCod[0], A45CliCod) == 0 ) && ( T002F11_A164CliDirItem[0] < A164CliDirItem ) ) )
            {
               A45CliCod = T002F11_A45CliCod[0];
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A164CliDirItem = T002F11_A164CliDirItem[0];
               AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
               RcdFound83 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey2F83( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert2F83( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound83 == 1 )
            {
               if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A164CliDirItem != Z164CliDirItem ) )
               {
                  A45CliCod = Z45CliCod;
                  AssignAttri("", false, "A45CliCod", A45CliCod);
                  A164CliDirItem = Z164CliDirItem;
                  AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLICOD");
                  AnyError = 1;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update2F83( ) ;
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A164CliDirItem != Z164CliDirItem ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtCliCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert2F83( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLICOD");
                     AnyError = 1;
                     GX_FocusControl = edtCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtCliCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert2F83( ) ;
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
         if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A164CliDirItem != Z164CliDirItem ) )
         {
            A45CliCod = Z45CliCod;
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A164CliDirItem = Z164CliDirItem;
            AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCliCod_Internalname;
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
         GetKey2F83( ) ;
         if ( RcdFound83 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A164CliDirItem != Z164CliDirItem ) )
            {
               A45CliCod = Z45CliCod;
               AssignAttri("", false, "A45CliCod", A45CliCod);
               A164CliDirItem = Z164CliDirItem;
               AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "CLICOD");
               AnyError = 1;
               GX_FocusControl = edtCliCod_Internalname;
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
            if ( ( StringUtil.StrCmp(A45CliCod, Z45CliCod) != 0 ) || ( A164CliDirItem != Z164CliDirItem ) )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLICOD");
                  AnyError = 1;
                  GX_FocusControl = edtCliCod_Internalname;
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
         context.RollbackDataStores("clclientesdireccion",pr_default);
         GX_FocusControl = edtCliDirDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_2F0( ) ;
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
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtCliDirDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart2F83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDirDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2F83( ) ;
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
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDirDsc_Internalname;
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
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDirDsc_Internalname;
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
         ScanStart2F83( ) ;
         if ( RcdFound83 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound83 != 0 )
            {
               ScanNext2F83( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtCliDirDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd2F83( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency2F83( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T002F2 */
            pr_default.execute(0, new Object[] {A45CliCod, A164CliDirItem});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESDIRECCION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z600CliDirDsc, T002F2_A600CliDirDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z598CliDirDir, T002F2_A598CliDirDir[0]) != 0 ) || ( StringUtil.StrCmp(Z605CliDirPais, T002F2_A605CliDirPais[0]) != 0 ) || ( StringUtil.StrCmp(Z597CliDirDep, T002F2_A597CliDirDep[0]) != 0 ) || ( StringUtil.StrCmp(Z606CliDirProv, T002F2_A606CliDirProv[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z599CliDirDis, T002F2_A599CliDirDis[0]) != 0 ) || ( Z165CliDirZonCod != T002F2_A165CliDirZonCod[0] ) )
            {
               if ( StringUtil.StrCmp(Z600CliDirDsc, T002F2_A600CliDirDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesdireccion:[seudo value changed for attri]"+"CliDirDsc");
                  GXUtil.WriteLogRaw("Old: ",Z600CliDirDsc);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A600CliDirDsc[0]);
               }
               if ( StringUtil.StrCmp(Z598CliDirDir, T002F2_A598CliDirDir[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesdireccion:[seudo value changed for attri]"+"CliDirDir");
                  GXUtil.WriteLogRaw("Old: ",Z598CliDirDir);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A598CliDirDir[0]);
               }
               if ( StringUtil.StrCmp(Z605CliDirPais, T002F2_A605CliDirPais[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesdireccion:[seudo value changed for attri]"+"CliDirPais");
                  GXUtil.WriteLogRaw("Old: ",Z605CliDirPais);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A605CliDirPais[0]);
               }
               if ( StringUtil.StrCmp(Z597CliDirDep, T002F2_A597CliDirDep[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesdireccion:[seudo value changed for attri]"+"CliDirDep");
                  GXUtil.WriteLogRaw("Old: ",Z597CliDirDep);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A597CliDirDep[0]);
               }
               if ( StringUtil.StrCmp(Z606CliDirProv, T002F2_A606CliDirProv[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesdireccion:[seudo value changed for attri]"+"CliDirProv");
                  GXUtil.WriteLogRaw("Old: ",Z606CliDirProv);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A606CliDirProv[0]);
               }
               if ( StringUtil.StrCmp(Z599CliDirDis, T002F2_A599CliDirDis[0]) != 0 )
               {
                  GXUtil.WriteLog("clclientesdireccion:[seudo value changed for attri]"+"CliDirDis");
                  GXUtil.WriteLogRaw("Old: ",Z599CliDirDis);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A599CliDirDis[0]);
               }
               if ( Z165CliDirZonCod != T002F2_A165CliDirZonCod[0] )
               {
                  GXUtil.WriteLog("clclientesdireccion:[seudo value changed for attri]"+"CliDirZonCod");
                  GXUtil.WriteLogRaw("Old: ",Z165CliDirZonCod);
                  GXUtil.WriteLogRaw("Current: ",T002F2_A165CliDirZonCod[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLCLIENTESDIRECCION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert2F83( )
      {
         BeforeValidate2F83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2F83( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM2F83( 0) ;
            CheckOptimisticConcurrency2F83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2F83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert2F83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002F12 */
                     pr_default.execute(10, new Object[] {A164CliDirItem, A600CliDirDsc, A598CliDirDir, A605CliDirPais, A597CliDirDep, A606CliDirProv, A599CliDirDis, A45CliCod, A165CliDirZonCod});
                     pr_default.close(10);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESDIRECCION");
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
                           ResetCaption2F0( ) ;
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
               Load2F83( ) ;
            }
            EndLevel2F83( ) ;
         }
         CloseExtendedTableCursors2F83( ) ;
      }

      protected void Update2F83( )
      {
         BeforeValidate2F83( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable2F83( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2F83( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm2F83( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate2F83( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T002F13 */
                     pr_default.execute(11, new Object[] {A600CliDirDsc, A598CliDirDir, A605CliDirPais, A597CliDirDep, A606CliDirProv, A599CliDirDis, A165CliDirZonCod, A45CliCod, A164CliDirItem});
                     pr_default.close(11);
                     dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESDIRECCION");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLCLIENTESDIRECCION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate2F83( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption2F0( ) ;
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
            EndLevel2F83( ) ;
         }
         CloseExtendedTableCursors2F83( ) ;
      }

      protected void DeferredUpdate2F83( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate2F83( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency2F83( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls2F83( ) ;
            AfterConfirm2F83( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete2F83( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T002F14 */
                  pr_default.execute(12, new Object[] {A45CliCod, A164CliDirItem});
                  pr_default.close(12);
                  dsDefault.SmartCacheProvider.SetUpdated("CLCLIENTESDIRECCION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound83 == 0 )
                        {
                           InitAll2F83( ) ;
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
                        ResetCaption2F0( ) ;
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
         sMode83 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel2F83( ) ;
         Gx_mode = sMode83;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls2F83( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T002F15 */
            pr_default.execute(13, new Object[] {A165CliDirZonCod});
            A607CliDirZonDsc = T002F15_A607CliDirZonDsc[0];
            AssignAttri("", false, "A607CliDirZonDsc", A607CliDirZonDsc);
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T002F16 */
            pr_default.execute(14, new Object[] {A45CliCod, A164CliDirItem});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Sub Remision Destino Item"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T002F17 */
            pr_default.execute(15, new Object[] {A45CliCod, A164CliDirItem});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"+" ("+"Cliente Origen"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
         }
      }

      protected void EndLevel2F83( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete2F83( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(13);
            context.CommitDataStores("clclientesdireccion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues2F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(13);
            context.RollbackDataStores("clclientesdireccion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart2F83( )
      {
         /* Using cursor T002F18 */
         pr_default.execute(16);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound83 = 1;
            A45CliCod = T002F18_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A164CliDirItem = T002F18_A164CliDirItem[0];
            AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext2F83( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound83 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound83 = 1;
            A45CliCod = T002F18_A45CliCod[0];
            AssignAttri("", false, "A45CliCod", A45CliCod);
            A164CliDirItem = T002F18_A164CliDirItem[0];
            AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
         }
      }

      protected void ScanEnd2F83( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm2F83( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert2F83( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate2F83( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete2F83( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete2F83( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate2F83( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes2F83( )
      {
         edtCliCod_Enabled = 0;
         AssignProp("", false, edtCliCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliCod_Enabled), 5, 0), true);
         edtCliDirItem_Enabled = 0;
         AssignProp("", false, edtCliDirItem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirItem_Enabled), 5, 0), true);
         edtCliDirDsc_Enabled = 0;
         AssignProp("", false, edtCliDirDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDsc_Enabled), 5, 0), true);
         edtCliDirDir_Enabled = 0;
         AssignProp("", false, edtCliDirDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDir_Enabled), 5, 0), true);
         edtCliDirPais_Enabled = 0;
         AssignProp("", false, edtCliDirPais_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirPais_Enabled), 5, 0), true);
         edtCliDirDep_Enabled = 0;
         AssignProp("", false, edtCliDirDep_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDep_Enabled), 5, 0), true);
         edtCliDirProv_Enabled = 0;
         AssignProp("", false, edtCliDirProv_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirProv_Enabled), 5, 0), true);
         edtCliDirDis_Enabled = 0;
         AssignProp("", false, edtCliDirDis_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirDis_Enabled), 5, 0), true);
         edtCliDirZonCod_Enabled = 0;
         AssignProp("", false, edtCliDirZonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirZonCod_Enabled), 5, 0), true);
         edtCliDirZonDsc_Enabled = 0;
         AssignProp("", false, edtCliDirZonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliDirZonDsc_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes2F83( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues2F0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810242958", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("clclientesdireccion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z164CliDirItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z164CliDirItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z600CliDirDsc", StringUtil.RTrim( Z600CliDirDsc));
         GxWebStd.gx_hidden_field( context, "Z598CliDirDir", StringUtil.RTrim( Z598CliDirDir));
         GxWebStd.gx_hidden_field( context, "Z605CliDirPais", StringUtil.RTrim( Z605CliDirPais));
         GxWebStd.gx_hidden_field( context, "Z597CliDirDep", StringUtil.RTrim( Z597CliDirDep));
         GxWebStd.gx_hidden_field( context, "Z606CliDirProv", StringUtil.RTrim( Z606CliDirProv));
         GxWebStd.gx_hidden_field( context, "Z599CliDirDis", StringUtil.RTrim( Z599CliDirDis));
         GxWebStd.gx_hidden_field( context, "Z165CliDirZonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z165CliDirZonCod), 6, 0, ".", "")));
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
         return formatLink("clclientesdireccion.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CLCLIENTESDIRECCION" ;
      }

      public override string GetPgmdesc( )
      {
         return "Clientes - Direcciones" ;
      }

      protected void InitializeNonKey2F83( )
      {
         A600CliDirDsc = "";
         AssignAttri("", false, "A600CliDirDsc", A600CliDirDsc);
         A598CliDirDir = "";
         AssignAttri("", false, "A598CliDirDir", A598CliDirDir);
         A605CliDirPais = "";
         AssignAttri("", false, "A605CliDirPais", A605CliDirPais);
         A597CliDirDep = "";
         AssignAttri("", false, "A597CliDirDep", A597CliDirDep);
         A606CliDirProv = "";
         AssignAttri("", false, "A606CliDirProv", A606CliDirProv);
         A599CliDirDis = "";
         AssignAttri("", false, "A599CliDirDis", A599CliDirDis);
         A165CliDirZonCod = 0;
         AssignAttri("", false, "A165CliDirZonCod", StringUtil.LTrimStr( (decimal)(A165CliDirZonCod), 6, 0));
         A607CliDirZonDsc = "";
         AssignAttri("", false, "A607CliDirZonDsc", A607CliDirZonDsc);
         Z600CliDirDsc = "";
         Z598CliDirDir = "";
         Z605CliDirPais = "";
         Z597CliDirDep = "";
         Z606CliDirProv = "";
         Z599CliDirDis = "";
         Z165CliDirZonCod = 0;
      }

      protected void InitAll2F83( )
      {
         A45CliCod = "";
         AssignAttri("", false, "A45CliCod", A45CliCod);
         A164CliDirItem = 0;
         AssignAttri("", false, "A164CliDirItem", StringUtil.LTrimStr( (decimal)(A164CliDirItem), 6, 0));
         InitializeNonKey2F83( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810242966", true, true);
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
         context.AddJavascriptSource("clclientesdireccion.js", "?202281810242967", false, true);
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
         edtCliCod_Internalname = "CLICOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtCliDirItem_Internalname = "CLIDIRITEM";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtCliDirDsc_Internalname = "CLIDIRDSC";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtCliDirDir_Internalname = "CLIDIRDIR";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtCliDirPais_Internalname = "CLIDIRPAIS";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtCliDirDep_Internalname = "CLIDIRDEP";
         lblTextblock7_Internalname = "TEXTBLOCK7";
         edtCliDirProv_Internalname = "CLIDIRPROV";
         lblTextblock8_Internalname = "TEXTBLOCK8";
         edtCliDirDis_Internalname = "CLIDIRDIS";
         lblTextblock9_Internalname = "TEXTBLOCK9";
         edtCliDirZonCod_Internalname = "CLIDIRZONCOD";
         lblTextblock10_Internalname = "TEXTBLOCK10";
         edtCliDirZonDsc_Internalname = "CLIDIRZONDSC";
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
         Form.Caption = "Clientes - Direcciones";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCliDirZonDsc_Jsonclick = "";
         edtCliDirZonDsc_Enabled = 0;
         edtCliDirZonCod_Jsonclick = "";
         edtCliDirZonCod_Enabled = 1;
         edtCliDirDis_Jsonclick = "";
         edtCliDirDis_Enabled = 1;
         edtCliDirProv_Jsonclick = "";
         edtCliDirProv_Enabled = 1;
         edtCliDirDep_Jsonclick = "";
         edtCliDirDep_Enabled = 1;
         edtCliDirPais_Jsonclick = "";
         edtCliDirPais_Enabled = 1;
         edtCliDirDir_Jsonclick = "";
         edtCliDirDir_Enabled = 1;
         edtCliDirDsc_Jsonclick = "";
         edtCliDirDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtCliDirItem_Jsonclick = "";
         edtCliDirItem_Enabled = 1;
         edtCliCod_Jsonclick = "";
         edtCliCod_Enabled = 1;
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
         /* Using cursor T002F19 */
         pr_default.execute(17, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(17);
         GX_FocusControl = edtCliDirDsc_Internalname;
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

      public void Valid_Clicod( )
      {
         /* Using cursor T002F19 */
         pr_default.execute(17, new Object[] {A45CliCod});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("No existe 'Maestros de Clientes'.", "ForeignKeyNotFound", 1, "CLICOD");
            AnyError = 1;
            GX_FocusControl = edtCliCod_Internalname;
         }
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Clidiritem( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A600CliDirDsc", StringUtil.RTrim( A600CliDirDsc));
         AssignAttri("", false, "A598CliDirDir", StringUtil.RTrim( A598CliDirDir));
         AssignAttri("", false, "A605CliDirPais", StringUtil.RTrim( A605CliDirPais));
         AssignAttri("", false, "A597CliDirDep", StringUtil.RTrim( A597CliDirDep));
         AssignAttri("", false, "A606CliDirProv", StringUtil.RTrim( A606CliDirProv));
         AssignAttri("", false, "A599CliDirDis", StringUtil.RTrim( A599CliDirDis));
         AssignAttri("", false, "A165CliDirZonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(A165CliDirZonCod), 6, 0, ".", "")));
         AssignAttri("", false, "A607CliDirZonDsc", StringUtil.RTrim( A607CliDirZonDsc));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z45CliCod", StringUtil.RTrim( Z45CliCod));
         GxWebStd.gx_hidden_field( context, "Z164CliDirItem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z164CliDirItem), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z600CliDirDsc", StringUtil.RTrim( Z600CliDirDsc));
         GxWebStd.gx_hidden_field( context, "Z598CliDirDir", StringUtil.RTrim( Z598CliDirDir));
         GxWebStd.gx_hidden_field( context, "Z605CliDirPais", StringUtil.RTrim( Z605CliDirPais));
         GxWebStd.gx_hidden_field( context, "Z597CliDirDep", StringUtil.RTrim( Z597CliDirDep));
         GxWebStd.gx_hidden_field( context, "Z606CliDirProv", StringUtil.RTrim( Z606CliDirProv));
         GxWebStd.gx_hidden_field( context, "Z599CliDirDis", StringUtil.RTrim( Z599CliDirDis));
         GxWebStd.gx_hidden_field( context, "Z165CliDirZonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z165CliDirZonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z607CliDirZonDsc", StringUtil.RTrim( Z607CliDirZonDsc));
         AssignProp("", false, bttBtn_get_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_get_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_check_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_check_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Clidirzoncod( )
      {
         /* Using cursor T002F15 */
         pr_default.execute(13, new Object[] {A165CliDirZonCod});
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("No existe 'Zona'.", "ForeignKeyNotFound", 1, "CLIDIRZONCOD");
            AnyError = 1;
            GX_FocusControl = edtCliDirZonCod_Internalname;
         }
         A607CliDirZonDsc = T002F15_A607CliDirZonDsc[0];
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A607CliDirZonDsc", StringUtil.RTrim( A607CliDirZonDsc));
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
         setEventMetadata("VALID_CLICOD","{handler:'Valid_Clicod',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''}]");
         setEventMetadata("VALID_CLICOD",",oparms:[]}");
         setEventMetadata("VALID_CLIDIRITEM","{handler:'Valid_Clidiritem',iparms:[{av:'A45CliCod',fld:'CLICOD',pic:''},{av:'A164CliDirItem',fld:'CLIDIRITEM',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_CLIDIRITEM",",oparms:[{av:'A600CliDirDsc',fld:'CLIDIRDSC',pic:''},{av:'A598CliDirDir',fld:'CLIDIRDIR',pic:''},{av:'A605CliDirPais',fld:'CLIDIRPAIS',pic:''},{av:'A597CliDirDep',fld:'CLIDIRDEP',pic:''},{av:'A606CliDirProv',fld:'CLIDIRPROV',pic:''},{av:'A599CliDirDis',fld:'CLIDIRDIS',pic:''},{av:'A165CliDirZonCod',fld:'CLIDIRZONCOD',pic:'ZZZZZ9'},{av:'A607CliDirZonDsc',fld:'CLIDIRZONDSC',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z45CliCod'},{av:'Z164CliDirItem'},{av:'Z600CliDirDsc'},{av:'Z598CliDirDir'},{av:'Z605CliDirPais'},{av:'Z597CliDirDep'},{av:'Z606CliDirProv'},{av:'Z599CliDirDis'},{av:'Z165CliDirZonCod'},{av:'Z607CliDirZonDsc'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
         setEventMetadata("VALID_CLIDIRZONCOD","{handler:'Valid_Clidirzoncod',iparms:[{av:'A165CliDirZonCod',fld:'CLIDIRZONCOD',pic:'ZZZZZ9'},{av:'A607CliDirZonDsc',fld:'CLIDIRZONDSC',pic:''}]");
         setEventMetadata("VALID_CLIDIRZONCOD",",oparms:[{av:'A607CliDirZonDsc',fld:'CLIDIRZONDSC',pic:''}]}");
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
         pr_default.close(17);
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z45CliCod = "";
         Z600CliDirDsc = "";
         Z598CliDirDir = "";
         Z605CliDirPais = "";
         Z597CliDirDep = "";
         Z606CliDirProv = "";
         Z599CliDirDis = "";
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
         lblTextblock2_Jsonclick = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock3_Jsonclick = "";
         A600CliDirDsc = "";
         lblTextblock4_Jsonclick = "";
         A598CliDirDir = "";
         lblTextblock5_Jsonclick = "";
         A605CliDirPais = "";
         lblTextblock6_Jsonclick = "";
         A597CliDirDep = "";
         lblTextblock7_Jsonclick = "";
         A606CliDirProv = "";
         lblTextblock8_Jsonclick = "";
         A599CliDirDis = "";
         lblTextblock9_Jsonclick = "";
         lblTextblock10_Jsonclick = "";
         A607CliDirZonDsc = "";
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
         Z607CliDirZonDsc = "";
         T002F6_A164CliDirItem = new int[1] ;
         T002F6_A600CliDirDsc = new string[] {""} ;
         T002F6_A598CliDirDir = new string[] {""} ;
         T002F6_A605CliDirPais = new string[] {""} ;
         T002F6_A597CliDirDep = new string[] {""} ;
         T002F6_A606CliDirProv = new string[] {""} ;
         T002F6_A599CliDirDis = new string[] {""} ;
         T002F6_A607CliDirZonDsc = new string[] {""} ;
         T002F6_A45CliCod = new string[] {""} ;
         T002F6_A165CliDirZonCod = new int[1] ;
         T002F4_A45CliCod = new string[] {""} ;
         T002F5_A607CliDirZonDsc = new string[] {""} ;
         T002F7_A45CliCod = new string[] {""} ;
         T002F8_A607CliDirZonDsc = new string[] {""} ;
         T002F9_A45CliCod = new string[] {""} ;
         T002F9_A164CliDirItem = new int[1] ;
         T002F3_A164CliDirItem = new int[1] ;
         T002F3_A600CliDirDsc = new string[] {""} ;
         T002F3_A598CliDirDir = new string[] {""} ;
         T002F3_A605CliDirPais = new string[] {""} ;
         T002F3_A597CliDirDep = new string[] {""} ;
         T002F3_A606CliDirProv = new string[] {""} ;
         T002F3_A599CliDirDis = new string[] {""} ;
         T002F3_A45CliCod = new string[] {""} ;
         T002F3_A165CliDirZonCod = new int[1] ;
         sMode83 = "";
         T002F10_A45CliCod = new string[] {""} ;
         T002F10_A164CliDirItem = new int[1] ;
         T002F11_A45CliCod = new string[] {""} ;
         T002F11_A164CliDirItem = new int[1] ;
         T002F2_A164CliDirItem = new int[1] ;
         T002F2_A600CliDirDsc = new string[] {""} ;
         T002F2_A598CliDirDir = new string[] {""} ;
         T002F2_A605CliDirPais = new string[] {""} ;
         T002F2_A597CliDirDep = new string[] {""} ;
         T002F2_A606CliDirProv = new string[] {""} ;
         T002F2_A599CliDirDis = new string[] {""} ;
         T002F2_A45CliCod = new string[] {""} ;
         T002F2_A165CliDirZonCod = new int[1] ;
         T002F15_A607CliDirZonDsc = new string[] {""} ;
         T002F16_A13MvATip = new string[] {""} ;
         T002F16_A14MvACod = new string[] {""} ;
         T002F17_A13MvATip = new string[] {""} ;
         T002F17_A14MvACod = new string[] {""} ;
         T002F18_A45CliCod = new string[] {""} ;
         T002F18_A164CliDirItem = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T002F19_A45CliCod = new string[] {""} ;
         ZZ45CliCod = "";
         ZZ600CliDirDsc = "";
         ZZ598CliDirDir = "";
         ZZ605CliDirPais = "";
         ZZ597CliDirDep = "";
         ZZ606CliDirProv = "";
         ZZ599CliDirDis = "";
         ZZ607CliDirZonDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.clclientesdireccion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clclientesdireccion__default(),
            new Object[][] {
                new Object[] {
               T002F2_A164CliDirItem, T002F2_A600CliDirDsc, T002F2_A598CliDirDir, T002F2_A605CliDirPais, T002F2_A597CliDirDep, T002F2_A606CliDirProv, T002F2_A599CliDirDis, T002F2_A45CliCod, T002F2_A165CliDirZonCod
               }
               , new Object[] {
               T002F3_A164CliDirItem, T002F3_A600CliDirDsc, T002F3_A598CliDirDir, T002F3_A605CliDirPais, T002F3_A597CliDirDep, T002F3_A606CliDirProv, T002F3_A599CliDirDis, T002F3_A45CliCod, T002F3_A165CliDirZonCod
               }
               , new Object[] {
               T002F4_A45CliCod
               }
               , new Object[] {
               T002F5_A607CliDirZonDsc
               }
               , new Object[] {
               T002F6_A164CliDirItem, T002F6_A600CliDirDsc, T002F6_A598CliDirDir, T002F6_A605CliDirPais, T002F6_A597CliDirDep, T002F6_A606CliDirProv, T002F6_A599CliDirDis, T002F6_A607CliDirZonDsc, T002F6_A45CliCod, T002F6_A165CliDirZonCod
               }
               , new Object[] {
               T002F7_A45CliCod
               }
               , new Object[] {
               T002F8_A607CliDirZonDsc
               }
               , new Object[] {
               T002F9_A45CliCod, T002F9_A164CliDirItem
               }
               , new Object[] {
               T002F10_A45CliCod, T002F10_A164CliDirItem
               }
               , new Object[] {
               T002F11_A45CliCod, T002F11_A164CliDirItem
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T002F15_A607CliDirZonDsc
               }
               , new Object[] {
               T002F16_A13MvATip, T002F16_A14MvACod
               }
               , new Object[] {
               T002F17_A13MvATip, T002F17_A14MvACod
               }
               , new Object[] {
               T002F18_A45CliCod, T002F18_A164CliDirItem
               }
               , new Object[] {
               T002F19_A45CliCod
               }
            }
         );
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound83 ;
      private short nIsDirty_83 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int Z164CliDirItem ;
      private int Z165CliDirZonCod ;
      private int A165CliDirZonCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCliCod_Enabled ;
      private int A164CliDirItem ;
      private int edtCliDirItem_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtCliDirDsc_Enabled ;
      private int edtCliDirDir_Enabled ;
      private int edtCliDirPais_Enabled ;
      private int edtCliDirDep_Enabled ;
      private int edtCliDirProv_Enabled ;
      private int edtCliDirDis_Enabled ;
      private int edtCliDirZonCod_Enabled ;
      private int edtCliDirZonDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ164CliDirItem ;
      private int ZZ165CliDirZonCod ;
      private string sPrefix ;
      private string Z45CliCod ;
      private string Z600CliDirDsc ;
      private string Z598CliDirDir ;
      private string Z605CliDirPais ;
      private string Z597CliDirDep ;
      private string Z606CliDirProv ;
      private string Z599CliDirDis ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A45CliCod ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCliCod_Internalname ;
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
      private string edtCliCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtCliDirItem_Internalname ;
      private string edtCliDirItem_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtCliDirDsc_Internalname ;
      private string A600CliDirDsc ;
      private string edtCliDirDsc_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtCliDirDir_Internalname ;
      private string A598CliDirDir ;
      private string edtCliDirDir_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtCliDirPais_Internalname ;
      private string A605CliDirPais ;
      private string edtCliDirPais_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtCliDirDep_Internalname ;
      private string A597CliDirDep ;
      private string edtCliDirDep_Jsonclick ;
      private string lblTextblock7_Internalname ;
      private string lblTextblock7_Jsonclick ;
      private string edtCliDirProv_Internalname ;
      private string A606CliDirProv ;
      private string edtCliDirProv_Jsonclick ;
      private string lblTextblock8_Internalname ;
      private string lblTextblock8_Jsonclick ;
      private string edtCliDirDis_Internalname ;
      private string A599CliDirDis ;
      private string edtCliDirDis_Jsonclick ;
      private string lblTextblock9_Internalname ;
      private string lblTextblock9_Jsonclick ;
      private string edtCliDirZonCod_Internalname ;
      private string edtCliDirZonCod_Jsonclick ;
      private string lblTextblock10_Internalname ;
      private string lblTextblock10_Jsonclick ;
      private string edtCliDirZonDsc_Internalname ;
      private string A607CliDirZonDsc ;
      private string edtCliDirZonDsc_Jsonclick ;
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
      private string Z607CliDirZonDsc ;
      private string sMode83 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ45CliCod ;
      private string ZZ600CliDirDsc ;
      private string ZZ598CliDirDir ;
      private string ZZ605CliDirPais ;
      private string ZZ597CliDirDep ;
      private string ZZ606CliDirProv ;
      private string ZZ599CliDirDis ;
      private string ZZ607CliDirZonDsc ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Gx_longc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T002F6_A164CliDirItem ;
      private string[] T002F6_A600CliDirDsc ;
      private string[] T002F6_A598CliDirDir ;
      private string[] T002F6_A605CliDirPais ;
      private string[] T002F6_A597CliDirDep ;
      private string[] T002F6_A606CliDirProv ;
      private string[] T002F6_A599CliDirDis ;
      private string[] T002F6_A607CliDirZonDsc ;
      private string[] T002F6_A45CliCod ;
      private int[] T002F6_A165CliDirZonCod ;
      private string[] T002F4_A45CliCod ;
      private string[] T002F5_A607CliDirZonDsc ;
      private string[] T002F7_A45CliCod ;
      private string[] T002F8_A607CliDirZonDsc ;
      private string[] T002F9_A45CliCod ;
      private int[] T002F9_A164CliDirItem ;
      private int[] T002F3_A164CliDirItem ;
      private string[] T002F3_A600CliDirDsc ;
      private string[] T002F3_A598CliDirDir ;
      private string[] T002F3_A605CliDirPais ;
      private string[] T002F3_A597CliDirDep ;
      private string[] T002F3_A606CliDirProv ;
      private string[] T002F3_A599CliDirDis ;
      private string[] T002F3_A45CliCod ;
      private int[] T002F3_A165CliDirZonCod ;
      private string[] T002F10_A45CliCod ;
      private int[] T002F10_A164CliDirItem ;
      private string[] T002F11_A45CliCod ;
      private int[] T002F11_A164CliDirItem ;
      private int[] T002F2_A164CliDirItem ;
      private string[] T002F2_A600CliDirDsc ;
      private string[] T002F2_A598CliDirDir ;
      private string[] T002F2_A605CliDirPais ;
      private string[] T002F2_A597CliDirDep ;
      private string[] T002F2_A606CliDirProv ;
      private string[] T002F2_A599CliDirDis ;
      private string[] T002F2_A45CliCod ;
      private int[] T002F2_A165CliDirZonCod ;
      private string[] T002F15_A607CliDirZonDsc ;
      private string[] T002F16_A13MvATip ;
      private string[] T002F16_A14MvACod ;
      private string[] T002F17_A13MvATip ;
      private string[] T002F17_A14MvACod ;
      private string[] T002F18_A45CliCod ;
      private int[] T002F18_A164CliDirItem ;
      private string[] T002F19_A45CliCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class clclientesdireccion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class clclientesdireccion__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT002F6;
        prmT002F6 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F4;
        prmT002F4 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002F5;
        prmT002F5 = new Object[] {
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        Object[] prmT002F7;
        prmT002F7 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002F8;
        prmT002F8 = new Object[] {
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        Object[] prmT002F9;
        prmT002F9 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F3;
        prmT002F3 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F10;
        prmT002F10 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F11;
        prmT002F11 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F2;
        prmT002F2 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F12;
        prmT002F12 = new Object[] {
        new ParDef("@CliDirItem",GXType.Int32,6,0) ,
        new ParDef("@CliDirDsc",GXType.NChar,100,0) ,
        new ParDef("@CliDirDir",GXType.NChar,100,0) ,
        new ParDef("@CliDirPais",GXType.NChar,4,0) ,
        new ParDef("@CliDirDep",GXType.NChar,4,0) ,
        new ParDef("@CliDirProv",GXType.NChar,4,0) ,
        new ParDef("@CliDirDis",GXType.NChar,4,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        Object[] prmT002F13;
        prmT002F13 = new Object[] {
        new ParDef("@CliDirDsc",GXType.NChar,100,0) ,
        new ParDef("@CliDirDir",GXType.NChar,100,0) ,
        new ParDef("@CliDirPais",GXType.NChar,4,0) ,
        new ParDef("@CliDirDep",GXType.NChar,4,0) ,
        new ParDef("@CliDirProv",GXType.NChar,4,0) ,
        new ParDef("@CliDirDis",GXType.NChar,4,0) ,
        new ParDef("@CliDirZonCod",GXType.Int32,6,0) ,
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F14;
        prmT002F14 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F16;
        prmT002F16 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F17;
        prmT002F17 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0) ,
        new ParDef("@CliDirItem",GXType.Int32,6,0)
        };
        Object[] prmT002F18;
        prmT002F18 = new Object[] {
        };
        Object[] prmT002F19;
        prmT002F19 = new Object[] {
        new ParDef("@CliCod",GXType.NChar,20,0)
        };
        Object[] prmT002F15;
        prmT002F15 = new Object[] {
        new ParDef("@CliDirZonCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("T002F2", "SELECT [CliDirItem], [CliDirDsc], [CliDirDir], [CliDirPais], [CliDirDep], [CliDirProv], [CliDirDis], [CliCod], [CliDirZonCod] AS CliDirZonCod FROM [CLCLIENTESDIRECCION] WITH (UPDLOCK) WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F3", "SELECT [CliDirItem], [CliDirDsc], [CliDirDir], [CliDirPais], [CliDirDep], [CliDirProv], [CliDirDis], [CliCod], [CliDirZonCod] AS CliDirZonCod FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F4", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F5", "SELECT [ZonDsc] AS CliDirZonDsc FROM [CZONAS] WHERE [ZonCod] = @CliDirZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F6", "SELECT TM1.[CliDirItem], TM1.[CliDirDsc], TM1.[CliDirDir], TM1.[CliDirPais], TM1.[CliDirDep], TM1.[CliDirProv], TM1.[CliDirDis], T2.[ZonDsc] AS CliDirZonDsc, TM1.[CliCod], TM1.[CliDirZonCod] AS CliDirZonCod FROM ([CLCLIENTESDIRECCION] TM1 INNER JOIN [CZONAS] T2 ON T2.[ZonCod] = TM1.[CliDirZonCod]) WHERE TM1.[CliCod] = @CliCod and TM1.[CliDirItem] = @CliDirItem ORDER BY TM1.[CliCod], TM1.[CliDirItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002F6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F7", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F8", "SELECT [ZonDsc] AS CliDirZonDsc FROM [CZONAS] WHERE [ZonCod] = @CliDirZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F9", "SELECT [CliCod], [CliDirItem] FROM [CLCLIENTESDIRECCION] WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F10", "SELECT TOP 1 [CliCod], [CliDirItem] FROM [CLCLIENTESDIRECCION] WHERE ( [CliCod] > @CliCod or [CliCod] = @CliCod and [CliDirItem] > @CliDirItem) ORDER BY [CliCod], [CliDirItem]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002F10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002F11", "SELECT TOP 1 [CliCod], [CliDirItem] FROM [CLCLIENTESDIRECCION] WHERE ( [CliCod] < @CliCod or [CliCod] = @CliCod and [CliDirItem] < @CliDirItem) ORDER BY [CliCod] DESC, [CliDirItem] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT002F11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002F12", "INSERT INTO [CLCLIENTESDIRECCION]([CliDirItem], [CliDirDsc], [CliDirDir], [CliDirPais], [CliDirDep], [CliDirProv], [CliDirDis], [CliCod], [CliDirZonCod]) VALUES(@CliDirItem, @CliDirDsc, @CliDirDir, @CliDirPais, @CliDirDep, @CliDirProv, @CliDirDis, @CliCod, @CliDirZonCod)", GxErrorMask.GX_NOMASK,prmT002F12)
           ,new CursorDef("T002F13", "UPDATE [CLCLIENTESDIRECCION] SET [CliDirDsc]=@CliDirDsc, [CliDirDir]=@CliDirDir, [CliDirPais]=@CliDirPais, [CliDirDep]=@CliDirDep, [CliDirProv]=@CliDirProv, [CliDirDis]=@CliDirDis, [CliDirZonCod]=@CliDirZonCod  WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem", GxErrorMask.GX_NOMASK,prmT002F13)
           ,new CursorDef("T002F14", "DELETE FROM [CLCLIENTESDIRECCION]  WHERE [CliCod] = @CliCod AND [CliDirItem] = @CliDirItem", GxErrorMask.GX_NOMASK,prmT002F14)
           ,new CursorDef("T002F15", "SELECT [ZonDsc] AS CliDirZonDsc FROM [CZONAS] WHERE [ZonCod] = @CliDirZonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F16", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCDesCod] = @CliCod AND [MVCDesItem] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002F17", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [MVCliCod] = @CliCod AND [MVCliOrigen] = @CliDirItem ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T002F18", "SELECT [CliCod], [CliDirItem] FROM [CLCLIENTESDIRECCION] ORDER BY [CliCod], [CliDirItem]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT002F18,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T002F19", "SELECT [CliCod] FROM [CLCLIENTES] WHERE [CliCod] = @CliCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT002F19,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              ((string[]) buf[7])[0] = rslt.getString(8, 20);
              ((int[]) buf[8])[0] = rslt.getInt(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 4);
              ((string[]) buf[4])[0] = rslt.getString(5, 4);
              ((string[]) buf[5])[0] = rslt.getString(6, 4);
              ((string[]) buf[6])[0] = rslt.getString(7, 4);
              ((string[]) buf[7])[0] = rslt.getString(8, 100);
              ((string[]) buf[8])[0] = rslt.getString(9, 20);
              ((int[]) buf[9])[0] = rslt.getInt(10);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
     }
  }

}

}
