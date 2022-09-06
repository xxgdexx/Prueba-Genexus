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
   public class aayudantes : GXDataArea
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
            Form.Meta.addItem("description", "Ayudantes", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAYUCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public aayudantes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public aayudantes( IGxContext context )
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_AAYUDANTES.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Ayudante", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAYUCod_Internalname, StringUtil.RTrim( A1AYUCod), StringUtil.RTrim( context.localUtil.Format( A1AYUCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAYUCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAYUCod_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Ayudante", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAYUDsc_Internalname, StringUtil.RTrim( A478AYUDsc), StringUtil.RTrim( context.localUtil.Format( A478AYUDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAYUDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAYUDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Dirección", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAYUDir_Internalname, StringUtil.RTrim( A477AYUDir), StringUtil.RTrim( context.localUtil.Format( A477AYUDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAYUDir_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAYUDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Telefono", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAYUTelf_Internalname, StringUtil.RTrim( A480AYUTelf), StringUtil.RTrim( context.localUtil.Format( A480AYUTelf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAYUTelf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAYUTelf_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Celular", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAYUCel_Internalname, StringUtil.RTrim( A476AYUCel), StringUtil.RTrim( context.localUtil.Format( A476AYUCel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAYUCel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAYUCel_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock6_Internalname, "Estado", "", "", lblTextblock6_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_AAYUDANTES.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAYUSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A479AYUSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtAYUSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A479AYUSts), "9") : context.localUtil.Format( (decimal)(A479AYUSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAYUSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAYUSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_AAYUDANTES.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_AAYUDANTES.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_AAYUDANTES.htm");
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
            Z1AYUCod = cgiGet( "Z1AYUCod");
            Z478AYUDsc = cgiGet( "Z478AYUDsc");
            Z477AYUDir = cgiGet( "Z477AYUDir");
            Z480AYUTelf = cgiGet( "Z480AYUTelf");
            Z476AYUCel = cgiGet( "Z476AYUCel");
            Z479AYUSts = (short)(context.localUtil.CToN( cgiGet( "Z479AYUSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A1AYUCod = cgiGet( edtAYUCod_Internalname);
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
            A478AYUDsc = cgiGet( edtAYUDsc_Internalname);
            AssignAttri("", false, "A478AYUDsc", A478AYUDsc);
            A477AYUDir = cgiGet( edtAYUDir_Internalname);
            AssignAttri("", false, "A477AYUDir", A477AYUDir);
            A480AYUTelf = cgiGet( edtAYUTelf_Internalname);
            AssignAttri("", false, "A480AYUTelf", A480AYUTelf);
            A476AYUCel = cgiGet( edtAYUCel_Internalname);
            AssignAttri("", false, "A476AYUCel", A476AYUCel);
            if ( ( ( context.localUtil.CToN( cgiGet( edtAYUSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAYUSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "AYUSTS");
               AnyError = 1;
               GX_FocusControl = edtAYUSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A479AYUSts = 0;
               AssignAttri("", false, "A479AYUSts", StringUtil.Str( (decimal)(A479AYUSts), 1, 0));
            }
            else
            {
               A479AYUSts = (short)(context.localUtil.CToN( cgiGet( edtAYUSts_Internalname), ".", ","));
               AssignAttri("", false, "A479AYUSts", StringUtil.Str( (decimal)(A479AYUSts), 1, 0));
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
               A1AYUCod = GetPar( "AYUCod");
               AssignAttri("", false, "A1AYUCod", A1AYUCod);
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
               InitAll1135( ) ;
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
         DisableAttributes1135( ) ;
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

      protected void CONFIRM_110( )
      {
         BeforeValidate1135( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1135( ) ;
            }
            else
            {
               CheckExtendedTable1135( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1135( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues110( ) ;
         }
      }

      protected void ResetCaption110( )
      {
      }

      protected void ZM1135( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z478AYUDsc = T00113_A478AYUDsc[0];
               Z477AYUDir = T00113_A477AYUDir[0];
               Z480AYUTelf = T00113_A480AYUTelf[0];
               Z476AYUCel = T00113_A476AYUCel[0];
               Z479AYUSts = T00113_A479AYUSts[0];
            }
            else
            {
               Z478AYUDsc = A478AYUDsc;
               Z477AYUDir = A477AYUDir;
               Z480AYUTelf = A480AYUTelf;
               Z476AYUCel = A476AYUCel;
               Z479AYUSts = A479AYUSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z1AYUCod = A1AYUCod;
            Z478AYUDsc = A478AYUDsc;
            Z477AYUDir = A477AYUDir;
            Z480AYUTelf = A480AYUTelf;
            Z476AYUCel = A476AYUCel;
            Z479AYUSts = A479AYUSts;
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

      protected void Load1135( )
      {
         /* Using cursor T00114 */
         pr_default.execute(2, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound35 = 1;
            A478AYUDsc = T00114_A478AYUDsc[0];
            AssignAttri("", false, "A478AYUDsc", A478AYUDsc);
            A477AYUDir = T00114_A477AYUDir[0];
            AssignAttri("", false, "A477AYUDir", A477AYUDir);
            A480AYUTelf = T00114_A480AYUTelf[0];
            AssignAttri("", false, "A480AYUTelf", A480AYUTelf);
            A476AYUCel = T00114_A476AYUCel[0];
            AssignAttri("", false, "A476AYUCel", A476AYUCel);
            A479AYUSts = T00114_A479AYUSts[0];
            AssignAttri("", false, "A479AYUSts", StringUtil.Str( (decimal)(A479AYUSts), 1, 0));
            ZM1135( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1135( ) ;
      }

      protected void OnLoadActions1135( )
      {
      }

      protected void CheckExtendedTable1135( )
      {
         nIsDirty_35 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1135( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1135( )
      {
         /* Using cursor T00115 */
         pr_default.execute(3, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound35 = 1;
         }
         else
         {
            RcdFound35 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00113 */
         pr_default.execute(1, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1135( 1) ;
            RcdFound35 = 1;
            A1AYUCod = T00113_A1AYUCod[0];
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
            A478AYUDsc = T00113_A478AYUDsc[0];
            AssignAttri("", false, "A478AYUDsc", A478AYUDsc);
            A477AYUDir = T00113_A477AYUDir[0];
            AssignAttri("", false, "A477AYUDir", A477AYUDir);
            A480AYUTelf = T00113_A480AYUTelf[0];
            AssignAttri("", false, "A480AYUTelf", A480AYUTelf);
            A476AYUCel = T00113_A476AYUCel[0];
            AssignAttri("", false, "A476AYUCel", A476AYUCel);
            A479AYUSts = T00113_A479AYUSts[0];
            AssignAttri("", false, "A479AYUSts", StringUtil.Str( (decimal)(A479AYUSts), 1, 0));
            Z1AYUCod = A1AYUCod;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1135( ) ;
            if ( AnyError == 1 )
            {
               RcdFound35 = 0;
               InitializeNonKey1135( ) ;
            }
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound35 = 0;
            InitializeNonKey1135( ) ;
            sMode35 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode35;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1135( ) ;
         if ( RcdFound35 == 0 )
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
         RcdFound35 = 0;
         /* Using cursor T00116 */
         pr_default.execute(4, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00116_A1AYUCod[0], A1AYUCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00116_A1AYUCod[0], A1AYUCod) > 0 ) ) )
            {
               A1AYUCod = T00116_A1AYUCod[0];
               AssignAttri("", false, "A1AYUCod", A1AYUCod);
               RcdFound35 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound35 = 0;
         /* Using cursor T00117 */
         pr_default.execute(5, new Object[] {A1AYUCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00117_A1AYUCod[0], A1AYUCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00117_A1AYUCod[0], A1AYUCod) < 0 ) ) )
            {
               A1AYUCod = T00117_A1AYUCod[0];
               AssignAttri("", false, "A1AYUCod", A1AYUCod);
               RcdFound35 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1135( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAYUCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1135( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound35 == 1 )
            {
               if ( StringUtil.StrCmp(A1AYUCod, Z1AYUCod) != 0 )
               {
                  A1AYUCod = Z1AYUCod;
                  AssignAttri("", false, "A1AYUCod", A1AYUCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "AYUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAYUCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAYUCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1135( ) ;
                  GX_FocusControl = edtAYUCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A1AYUCod, Z1AYUCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAYUCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1135( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AYUCOD");
                     AnyError = 1;
                     GX_FocusControl = edtAYUCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAYUCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1135( ) ;
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
         if ( StringUtil.StrCmp(A1AYUCod, Z1AYUCod) != 0 )
         {
            A1AYUCod = Z1AYUCod;
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "AYUCOD");
            AnyError = 1;
            GX_FocusControl = edtAYUCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAYUCod_Internalname;
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
         GetKey1135( ) ;
         if ( RcdFound35 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "AYUCOD");
               AnyError = 1;
               GX_FocusControl = edtAYUCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( StringUtil.StrCmp(A1AYUCod, Z1AYUCod) != 0 )
            {
               A1AYUCod = Z1AYUCod;
               AssignAttri("", false, "A1AYUCod", A1AYUCod);
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "AYUCOD");
               AnyError = 1;
               GX_FocusControl = edtAYUCod_Internalname;
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
            if ( StringUtil.StrCmp(A1AYUCod, Z1AYUCod) != 0 )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "AYUCOD");
                  AnyError = 1;
                  GX_FocusControl = edtAYUCod_Internalname;
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
         context.RollbackDataStores("aayudantes",pr_default);
         GX_FocusControl = edtAYUDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_110( ) ;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "AYUCOD");
            AnyError = 1;
            GX_FocusControl = edtAYUCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAYUDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1135( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAYUDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1135( ) ;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAYUDsc_Internalname;
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
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAYUDsc_Internalname;
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
         ScanStart1135( ) ;
         if ( RcdFound35 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound35 != 0 )
            {
               ScanNext1135( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAYUDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1135( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1135( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00112 */
            pr_default.execute(0, new Object[] {A1AYUCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AAYUDANTES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z478AYUDsc, T00112_A478AYUDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z477AYUDir, T00112_A477AYUDir[0]) != 0 ) || ( StringUtil.StrCmp(Z480AYUTelf, T00112_A480AYUTelf[0]) != 0 ) || ( StringUtil.StrCmp(Z476AYUCel, T00112_A476AYUCel[0]) != 0 ) || ( Z479AYUSts != T00112_A479AYUSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z478AYUDsc, T00112_A478AYUDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("aayudantes:[seudo value changed for attri]"+"AYUDsc");
                  GXUtil.WriteLogRaw("Old: ",Z478AYUDsc);
                  GXUtil.WriteLogRaw("Current: ",T00112_A478AYUDsc[0]);
               }
               if ( StringUtil.StrCmp(Z477AYUDir, T00112_A477AYUDir[0]) != 0 )
               {
                  GXUtil.WriteLog("aayudantes:[seudo value changed for attri]"+"AYUDir");
                  GXUtil.WriteLogRaw("Old: ",Z477AYUDir);
                  GXUtil.WriteLogRaw("Current: ",T00112_A477AYUDir[0]);
               }
               if ( StringUtil.StrCmp(Z480AYUTelf, T00112_A480AYUTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("aayudantes:[seudo value changed for attri]"+"AYUTelf");
                  GXUtil.WriteLogRaw("Old: ",Z480AYUTelf);
                  GXUtil.WriteLogRaw("Current: ",T00112_A480AYUTelf[0]);
               }
               if ( StringUtil.StrCmp(Z476AYUCel, T00112_A476AYUCel[0]) != 0 )
               {
                  GXUtil.WriteLog("aayudantes:[seudo value changed for attri]"+"AYUCel");
                  GXUtil.WriteLogRaw("Old: ",Z476AYUCel);
                  GXUtil.WriteLogRaw("Current: ",T00112_A476AYUCel[0]);
               }
               if ( Z479AYUSts != T00112_A479AYUSts[0] )
               {
                  GXUtil.WriteLog("aayudantes:[seudo value changed for attri]"+"AYUSts");
                  GXUtil.WriteLogRaw("Old: ",Z479AYUSts);
                  GXUtil.WriteLogRaw("Current: ",T00112_A479AYUSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"AAYUDANTES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1135( )
      {
         BeforeValidate1135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1135( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1135( 0) ;
            CheckOptimisticConcurrency1135( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1135( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1135( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00118 */
                     pr_default.execute(6, new Object[] {A1AYUCod, A478AYUDsc, A477AYUDir, A480AYUTelf, A476AYUCel, A479AYUSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("AAYUDANTES");
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
                           ResetCaption110( ) ;
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
               Load1135( ) ;
            }
            EndLevel1135( ) ;
         }
         CloseExtendedTableCursors1135( ) ;
      }

      protected void Update1135( )
      {
         BeforeValidate1135( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1135( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1135( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1135( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1135( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00119 */
                     pr_default.execute(7, new Object[] {A478AYUDsc, A477AYUDir, A480AYUTelf, A476AYUCel, A479AYUSts, A1AYUCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("AAYUDANTES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"AAYUDANTES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1135( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption110( ) ;
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
            EndLevel1135( ) ;
         }
         CloseExtendedTableCursors1135( ) ;
      }

      protected void DeferredUpdate1135( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1135( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1135( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1135( ) ;
            AfterConfirm1135( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1135( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001110 */
                  pr_default.execute(8, new Object[] {A1AYUCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("AAYUDANTES");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound35 == 0 )
                        {
                           InitAll1135( ) ;
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
                        ResetCaption110( ) ;
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
         sMode35 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1135( ) ;
         Gx_mode = sMode35;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1135( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001111 */
            pr_default.execute(9, new Object[] {A1AYUCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Despacho"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1135( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1135( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("aayudantes",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues110( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("aayudantes",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1135( )
      {
         /* Using cursor T001112 */
         pr_default.execute(10);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound35 = 1;
            A1AYUCod = T001112_A1AYUCod[0];
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1135( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound35 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound35 = 1;
            A1AYUCod = T001112_A1AYUCod[0];
            AssignAttri("", false, "A1AYUCod", A1AYUCod);
         }
      }

      protected void ScanEnd1135( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1135( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1135( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1135( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1135( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1135( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1135( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1135( )
      {
         edtAYUCod_Enabled = 0;
         AssignProp("", false, edtAYUCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAYUCod_Enabled), 5, 0), true);
         edtAYUDsc_Enabled = 0;
         AssignProp("", false, edtAYUDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAYUDsc_Enabled), 5, 0), true);
         edtAYUDir_Enabled = 0;
         AssignProp("", false, edtAYUDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAYUDir_Enabled), 5, 0), true);
         edtAYUTelf_Enabled = 0;
         AssignProp("", false, edtAYUTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAYUTelf_Enabled), 5, 0), true);
         edtAYUCel_Enabled = 0;
         AssignProp("", false, edtAYUCel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAYUCel_Enabled), 5, 0), true);
         edtAYUSts_Enabled = 0;
         AssignProp("", false, edtAYUSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAYUSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1135( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues110( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181144309", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("aayudantes.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z1AYUCod", StringUtil.RTrim( Z1AYUCod));
         GxWebStd.gx_hidden_field( context, "Z478AYUDsc", StringUtil.RTrim( Z478AYUDsc));
         GxWebStd.gx_hidden_field( context, "Z477AYUDir", StringUtil.RTrim( Z477AYUDir));
         GxWebStd.gx_hidden_field( context, "Z480AYUTelf", StringUtil.RTrim( Z480AYUTelf));
         GxWebStd.gx_hidden_field( context, "Z476AYUCel", StringUtil.RTrim( Z476AYUCel));
         GxWebStd.gx_hidden_field( context, "Z479AYUSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z479AYUSts), 1, 0, ".", "")));
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
         return formatLink("aayudantes.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "AAYUDANTES" ;
      }

      public override string GetPgmdesc( )
      {
         return "Ayudantes" ;
      }

      protected void InitializeNonKey1135( )
      {
         A478AYUDsc = "";
         AssignAttri("", false, "A478AYUDsc", A478AYUDsc);
         A477AYUDir = "";
         AssignAttri("", false, "A477AYUDir", A477AYUDir);
         A480AYUTelf = "";
         AssignAttri("", false, "A480AYUTelf", A480AYUTelf);
         A476AYUCel = "";
         AssignAttri("", false, "A476AYUCel", A476AYUCel);
         A479AYUSts = 0;
         AssignAttri("", false, "A479AYUSts", StringUtil.Str( (decimal)(A479AYUSts), 1, 0));
         Z478AYUDsc = "";
         Z477AYUDir = "";
         Z480AYUTelf = "";
         Z476AYUCel = "";
         Z479AYUSts = 0;
      }

      protected void InitAll1135( )
      {
         A1AYUCod = "";
         AssignAttri("", false, "A1AYUCod", A1AYUCod);
         InitializeNonKey1135( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811443015", true, true);
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
         context.AddJavascriptSource("aayudantes.js", "?202281811443015", false, true);
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
         edtAYUCod_Internalname = "AYUCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtAYUDsc_Internalname = "AYUDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtAYUDir_Internalname = "AYUDIR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtAYUTelf_Internalname = "AYUTELF";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         edtAYUCel_Internalname = "AYUCEL";
         lblTextblock6_Internalname = "TEXTBLOCK6";
         edtAYUSts_Internalname = "AYUSTS";
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
         Form.Caption = "Ayudantes";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtAYUSts_Jsonclick = "";
         edtAYUSts_Enabled = 1;
         edtAYUCel_Jsonclick = "";
         edtAYUCel_Enabled = 1;
         edtAYUTelf_Jsonclick = "";
         edtAYUTelf_Enabled = 1;
         edtAYUDir_Jsonclick = "";
         edtAYUDir_Enabled = 1;
         edtAYUDsc_Jsonclick = "";
         edtAYUDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtAYUCod_Jsonclick = "";
         edtAYUCod_Enabled = 1;
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
         GX_FocusControl = edtAYUDsc_Internalname;
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

      public void Valid_Ayucod( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A478AYUDsc", StringUtil.RTrim( A478AYUDsc));
         AssignAttri("", false, "A477AYUDir", StringUtil.RTrim( A477AYUDir));
         AssignAttri("", false, "A480AYUTelf", StringUtil.RTrim( A480AYUTelf));
         AssignAttri("", false, "A476AYUCel", StringUtil.RTrim( A476AYUCel));
         AssignAttri("", false, "A479AYUSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A479AYUSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z1AYUCod", StringUtil.RTrim( Z1AYUCod));
         GxWebStd.gx_hidden_field( context, "Z478AYUDsc", StringUtil.RTrim( Z478AYUDsc));
         GxWebStd.gx_hidden_field( context, "Z477AYUDir", StringUtil.RTrim( Z477AYUDir));
         GxWebStd.gx_hidden_field( context, "Z480AYUTelf", StringUtil.RTrim( Z480AYUTelf));
         GxWebStd.gx_hidden_field( context, "Z476AYUCel", StringUtil.RTrim( Z476AYUCel));
         GxWebStd.gx_hidden_field( context, "Z479AYUSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z479AYUSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_AYUCOD","{handler:'Valid_Ayucod',iparms:[{av:'A1AYUCod',fld:'AYUCOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_AYUCOD",",oparms:[{av:'A478AYUDsc',fld:'AYUDSC',pic:''},{av:'A477AYUDir',fld:'AYUDIR',pic:''},{av:'A480AYUTelf',fld:'AYUTELF',pic:''},{av:'A476AYUCel',fld:'AYUCEL',pic:''},{av:'A479AYUSts',fld:'AYUSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z1AYUCod'},{av:'Z478AYUDsc'},{av:'Z477AYUDir'},{av:'Z480AYUTelf'},{av:'Z476AYUCel'},{av:'Z479AYUSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1AYUCod = "";
         Z478AYUDsc = "";
         Z477AYUDir = "";
         Z480AYUTelf = "";
         Z476AYUCel = "";
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
         A1AYUCod = "";
         bttBtn_get_Jsonclick = "";
         lblTextblock2_Jsonclick = "";
         A478AYUDsc = "";
         lblTextblock3_Jsonclick = "";
         A477AYUDir = "";
         lblTextblock4_Jsonclick = "";
         A480AYUTelf = "";
         lblTextblock5_Jsonclick = "";
         A476AYUCel = "";
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
         T00114_A1AYUCod = new string[] {""} ;
         T00114_A478AYUDsc = new string[] {""} ;
         T00114_A477AYUDir = new string[] {""} ;
         T00114_A480AYUTelf = new string[] {""} ;
         T00114_A476AYUCel = new string[] {""} ;
         T00114_A479AYUSts = new short[1] ;
         T00115_A1AYUCod = new string[] {""} ;
         T00113_A1AYUCod = new string[] {""} ;
         T00113_A478AYUDsc = new string[] {""} ;
         T00113_A477AYUDir = new string[] {""} ;
         T00113_A480AYUTelf = new string[] {""} ;
         T00113_A476AYUCel = new string[] {""} ;
         T00113_A479AYUSts = new short[1] ;
         sMode35 = "";
         T00116_A1AYUCod = new string[] {""} ;
         T00117_A1AYUCod = new string[] {""} ;
         T00112_A1AYUCod = new string[] {""} ;
         T00112_A478AYUDsc = new string[] {""} ;
         T00112_A477AYUDir = new string[] {""} ;
         T00112_A480AYUTelf = new string[] {""} ;
         T00112_A476AYUCel = new string[] {""} ;
         T00112_A479AYUSts = new short[1] ;
         T001111_A8DesCod = new string[] {""} ;
         T001112_A1AYUCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1AYUCod = "";
         ZZ478AYUDsc = "";
         ZZ477AYUDir = "";
         ZZ480AYUTelf = "";
         ZZ476AYUCel = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.aayudantes__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aayudantes__default(),
            new Object[][] {
                new Object[] {
               T00112_A1AYUCod, T00112_A478AYUDsc, T00112_A477AYUDir, T00112_A480AYUTelf, T00112_A476AYUCel, T00112_A479AYUSts
               }
               , new Object[] {
               T00113_A1AYUCod, T00113_A478AYUDsc, T00113_A477AYUDir, T00113_A480AYUTelf, T00113_A476AYUCel, T00113_A479AYUSts
               }
               , new Object[] {
               T00114_A1AYUCod, T00114_A478AYUDsc, T00114_A477AYUDir, T00114_A480AYUTelf, T00114_A476AYUCel, T00114_A479AYUSts
               }
               , new Object[] {
               T00115_A1AYUCod
               }
               , new Object[] {
               T00116_A1AYUCod
               }
               , new Object[] {
               T00117_A1AYUCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001111_A8DesCod
               }
               , new Object[] {
               T001112_A1AYUCod
               }
            }
         );
      }

      private short Z479AYUSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A479AYUSts ;
      private short GX_JID ;
      private short RcdFound35 ;
      private short nIsDirty_35 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ479AYUSts ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtAYUCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtAYUDsc_Enabled ;
      private int edtAYUDir_Enabled ;
      private int edtAYUTelf_Enabled ;
      private int edtAYUCel_Enabled ;
      private int edtAYUSts_Enabled ;
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
      private string Z1AYUCod ;
      private string Z478AYUDsc ;
      private string Z477AYUDir ;
      private string Z480AYUTelf ;
      private string Z476AYUCel ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAYUCod_Internalname ;
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
      private string A1AYUCod ;
      private string edtAYUCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtAYUDsc_Internalname ;
      private string A478AYUDsc ;
      private string edtAYUDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtAYUDir_Internalname ;
      private string A477AYUDir ;
      private string edtAYUDir_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtAYUTelf_Internalname ;
      private string A480AYUTelf ;
      private string edtAYUTelf_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string edtAYUCel_Internalname ;
      private string A476AYUCel ;
      private string edtAYUCel_Jsonclick ;
      private string lblTextblock6_Internalname ;
      private string lblTextblock6_Jsonclick ;
      private string edtAYUSts_Internalname ;
      private string edtAYUSts_Jsonclick ;
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
      private string sMode35 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1AYUCod ;
      private string ZZ478AYUDsc ;
      private string ZZ477AYUDir ;
      private string ZZ480AYUTelf ;
      private string ZZ476AYUCel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00114_A1AYUCod ;
      private string[] T00114_A478AYUDsc ;
      private string[] T00114_A477AYUDir ;
      private string[] T00114_A480AYUTelf ;
      private string[] T00114_A476AYUCel ;
      private short[] T00114_A479AYUSts ;
      private string[] T00115_A1AYUCod ;
      private string[] T00113_A1AYUCod ;
      private string[] T00113_A478AYUDsc ;
      private string[] T00113_A477AYUDir ;
      private string[] T00113_A480AYUTelf ;
      private string[] T00113_A476AYUCel ;
      private short[] T00113_A479AYUSts ;
      private string[] T00116_A1AYUCod ;
      private string[] T00117_A1AYUCod ;
      private string[] T00112_A1AYUCod ;
      private string[] T00112_A478AYUDsc ;
      private string[] T00112_A477AYUDir ;
      private string[] T00112_A480AYUTelf ;
      private string[] T00112_A476AYUCel ;
      private short[] T00112_A479AYUSts ;
      private string[] T001111_A8DesCod ;
      private string[] T001112_A1AYUCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class aayudantes__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class aayudantes__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00114;
        prmT00114 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT00115;
        prmT00115 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT00113;
        prmT00113 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT00116;
        prmT00116 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT00117;
        prmT00117 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT00112;
        prmT00112 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT00118;
        prmT00118 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0) ,
        new ParDef("@AYUDsc",GXType.NChar,100,0) ,
        new ParDef("@AYUDir",GXType.NChar,100,0) ,
        new ParDef("@AYUTelf",GXType.NChar,20,0) ,
        new ParDef("@AYUCel",GXType.NChar,20,0) ,
        new ParDef("@AYUSts",GXType.Int16,1,0)
        };
        Object[] prmT00119;
        prmT00119 = new Object[] {
        new ParDef("@AYUDsc",GXType.NChar,100,0) ,
        new ParDef("@AYUDir",GXType.NChar,100,0) ,
        new ParDef("@AYUTelf",GXType.NChar,20,0) ,
        new ParDef("@AYUCel",GXType.NChar,20,0) ,
        new ParDef("@AYUSts",GXType.Int16,1,0) ,
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT001110;
        prmT001110 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT001111;
        prmT001111 = new Object[] {
        new ParDef("@AYUCod",GXType.NChar,15,0)
        };
        Object[] prmT001112;
        prmT001112 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00112", "SELECT [AYUCod], [AYUDsc], [AYUDir], [AYUTelf], [AYUCel], [AYUSts] FROM [AAYUDANTES] WITH (UPDLOCK) WHERE [AYUCod] = @AYUCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00112,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00113", "SELECT [AYUCod], [AYUDsc], [AYUDir], [AYUTelf], [AYUCel], [AYUSts] FROM [AAYUDANTES] WHERE [AYUCod] = @AYUCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00113,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00114", "SELECT TM1.[AYUCod], TM1.[AYUDsc], TM1.[AYUDir], TM1.[AYUTelf], TM1.[AYUCel], TM1.[AYUSts] FROM [AAYUDANTES] TM1 WHERE TM1.[AYUCod] = @AYUCod ORDER BY TM1.[AYUCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00114,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00115", "SELECT [AYUCod] FROM [AAYUDANTES] WHERE [AYUCod] = @AYUCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00115,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00116", "SELECT TOP 1 [AYUCod] FROM [AAYUDANTES] WHERE ( [AYUCod] > @AYUCod) ORDER BY [AYUCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00116,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00117", "SELECT TOP 1 [AYUCod] FROM [AAYUDANTES] WHERE ( [AYUCod] < @AYUCod) ORDER BY [AYUCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00117,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00118", "INSERT INTO [AAYUDANTES]([AYUCod], [AYUDsc], [AYUDir], [AYUTelf], [AYUCel], [AYUSts]) VALUES(@AYUCod, @AYUDsc, @AYUDir, @AYUTelf, @AYUCel, @AYUSts)", GxErrorMask.GX_NOMASK,prmT00118)
           ,new CursorDef("T00119", "UPDATE [AAYUDANTES] SET [AYUDsc]=@AYUDsc, [AYUDir]=@AYUDir, [AYUTelf]=@AYUTelf, [AYUCel]=@AYUCel, [AYUSts]=@AYUSts  WHERE [AYUCod] = @AYUCod", GxErrorMask.GX_NOMASK,prmT00119)
           ,new CursorDef("T001110", "DELETE FROM [AAYUDANTES]  WHERE [AYUCod] = @AYUCod", GxErrorMask.GX_NOMASK,prmT001110)
           ,new CursorDef("T001111", "SELECT TOP 1 [DesCod] FROM [ADESPACHO] WHERE [AYUCod] = @AYUCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001112", "SELECT [AYUCod] FROM [AAYUDANTES] ORDER BY [AYUCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001112,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
     }
  }

}

}
