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
   public class cunidadmedida : GXHttpHandler
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
            Form.Meta.addItem("description", "Unidad de Medida", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cunidadmedida( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cunidadmedida( IGxContext context )
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
         cmbUniSts = new GXCombobox();
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
            ValidateSpaRequest();
            UserMain( ) ;
            if ( ! isFullAjaxMode( ) && ( nDynComponent == 0 ) )
            {
               Draw( ) ;
            }
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
         if ( cmbUniSts.ItemCount > 0 )
         {
            A1999UniSts = (short)(NumberUtil.Val( cmbUniSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0))), "."));
            AssignAttri("", false, "A1999UniSts", StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUniSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
            AssignProp("", false, cmbUniSts_Internalname, "Values", cmbUniSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm3Y137( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable1_Internalname, tblTable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 5,'',false,'',0)\"";
         ClassString = "BtnFirst";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CUNIDADMEDIDA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Unidad Medida", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUniCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A49UniCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtUniCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A49UniCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUniCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUniCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Descripcion Unidad de Medida", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUniDsc_Internalname, StringUtil.RTrim( A1998UniDsc), StringUtil.RTrim( context.localUtil.Format( A1998UniDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUniDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUniDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura Unidad de Medida", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUniAbr_Internalname, StringUtil.RTrim( A1997UniAbr), StringUtil.RTrim( context.localUtil.Format( A1997UniAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUniAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUniAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Cod.Sunat", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtUniSunat_Internalname, A2000UniSunat, StringUtil.RTrim( context.localUtil.Format( A2000UniSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtUniSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtUniSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock5_Internalname, "Situacion Unidad de Medida", "", "", lblTextblock5_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CUNIDADMEDIDA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbUniSts, cmbUniSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0)), 1, cmbUniSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbUniSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 1, "HLP_CUNIDADMEDIDA.htm");
         cmbUniSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
         AssignProp("", false, cmbUniSts_Internalname, "Values", (string)(cmbUniSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CUNIDADMEDIDA.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CUNIDADMEDIDA.htm");
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
            Z49UniCod = (int)(context.localUtil.CToN( cgiGet( "Z49UniCod"), ".", ","));
            Z1998UniDsc = cgiGet( "Z1998UniDsc");
            Z1997UniAbr = cgiGet( "Z1997UniAbr");
            Z2000UniSunat = cgiGet( "Z2000UniSunat");
            Z1999UniSts = (short)(context.localUtil.CToN( cgiGet( "Z1999UniSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            A1998UniDsc = cgiGet( edtUniDsc_Internalname);
            AssignAttri("", false, "A1998UniDsc", A1998UniDsc);
            A1997UniAbr = cgiGet( edtUniAbr_Internalname);
            AssignAttri("", false, "A1997UniAbr", A1997UniAbr);
            A2000UniSunat = cgiGet( edtUniSunat_Internalname);
            AssignAttri("", false, "A2000UniSunat", A2000UniSunat);
            cmbUniSts.CurrentValue = cgiGet( cmbUniSts_Internalname);
            A1999UniSts = (short)(NumberUtil.Val( cgiGet( cmbUniSts_Internalname), "."));
            AssignAttri("", false, "A1999UniSts", StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
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
               A49UniCod = (int)(NumberUtil.Val( GetPar( "UniCod"), "."));
               AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
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
               InitAll3Y137( ) ;
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
         DisableAttributes3Y137( ) ;
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

      protected void CONFIRM_3Y0( )
      {
         BeforeValidate3Y137( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3Y137( ) ;
            }
            else
            {
               CheckExtendedTable3Y137( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3Y137( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3Y0( ) ;
         }
      }

      protected void ResetCaption3Y0( )
      {
      }

      protected void ZM3Y137( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1998UniDsc = T003Y3_A1998UniDsc[0];
               Z1997UniAbr = T003Y3_A1997UniAbr[0];
               Z2000UniSunat = T003Y3_A2000UniSunat[0];
               Z1999UniSts = T003Y3_A1999UniSts[0];
            }
            else
            {
               Z1998UniDsc = A1998UniDsc;
               Z1997UniAbr = A1997UniAbr;
               Z2000UniSunat = A2000UniSunat;
               Z1999UniSts = A1999UniSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z49UniCod = A49UniCod;
            Z1998UniDsc = A1998UniDsc;
            Z1997UniAbr = A1997UniAbr;
            Z2000UniSunat = A2000UniSunat;
            Z1999UniSts = A1999UniSts;
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

      protected void Load3Y137( )
      {
         /* Using cursor T003Y4 */
         pr_default.execute(2, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound137 = 1;
            A1998UniDsc = T003Y4_A1998UniDsc[0];
            AssignAttri("", false, "A1998UniDsc", A1998UniDsc);
            A1997UniAbr = T003Y4_A1997UniAbr[0];
            AssignAttri("", false, "A1997UniAbr", A1997UniAbr);
            A2000UniSunat = T003Y4_A2000UniSunat[0];
            AssignAttri("", false, "A2000UniSunat", A2000UniSunat);
            A1999UniSts = T003Y4_A1999UniSts[0];
            AssignAttri("", false, "A1999UniSts", StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
            ZM3Y137( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3Y137( ) ;
      }

      protected void OnLoadActions3Y137( )
      {
      }

      protected void CheckExtendedTable3Y137( )
      {
         nIsDirty_137 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3Y137( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3Y137( )
      {
         /* Using cursor T003Y5 */
         pr_default.execute(3, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound137 = 1;
         }
         else
         {
            RcdFound137 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003Y3 */
         pr_default.execute(1, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3Y137( 1) ;
            RcdFound137 = 1;
            A49UniCod = T003Y3_A49UniCod[0];
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            A1998UniDsc = T003Y3_A1998UniDsc[0];
            AssignAttri("", false, "A1998UniDsc", A1998UniDsc);
            A1997UniAbr = T003Y3_A1997UniAbr[0];
            AssignAttri("", false, "A1997UniAbr", A1997UniAbr);
            A2000UniSunat = T003Y3_A2000UniSunat[0];
            AssignAttri("", false, "A2000UniSunat", A2000UniSunat);
            A1999UniSts = T003Y3_A1999UniSts[0];
            AssignAttri("", false, "A1999UniSts", StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
            Z49UniCod = A49UniCod;
            sMode137 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3Y137( ) ;
            if ( AnyError == 1 )
            {
               RcdFound137 = 0;
               InitializeNonKey3Y137( ) ;
            }
            Gx_mode = sMode137;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound137 = 0;
            InitializeNonKey3Y137( ) ;
            sMode137 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode137;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3Y137( ) ;
         if ( RcdFound137 == 0 )
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
         RcdFound137 = 0;
         /* Using cursor T003Y6 */
         pr_default.execute(4, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003Y6_A49UniCod[0] < A49UniCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003Y6_A49UniCod[0] > A49UniCod ) ) )
            {
               A49UniCod = T003Y6_A49UniCod[0];
               AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
               RcdFound137 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound137 = 0;
         /* Using cursor T003Y7 */
         pr_default.execute(5, new Object[] {A49UniCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003Y7_A49UniCod[0] > A49UniCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003Y7_A49UniCod[0] < A49UniCod ) ) )
            {
               A49UniCod = T003Y7_A49UniCod[0];
               AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
               RcdFound137 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3Y137( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3Y137( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound137 == 1 )
            {
               if ( A49UniCod != Z49UniCod )
               {
                  A49UniCod = Z49UniCod;
                  AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "UNICOD");
                  AnyError = 1;
                  GX_FocusControl = edtUniCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtUniCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3Y137( ) ;
                  GX_FocusControl = edtUniCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A49UniCod != Z49UniCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtUniCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3Y137( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "UNICOD");
                     AnyError = 1;
                     GX_FocusControl = edtUniCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtUniCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3Y137( ) ;
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
         if ( A49UniCod != Z49UniCod )
         {
            A49UniCod = Z49UniCod;
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtUniCod_Internalname;
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
         GetKey3Y137( ) ;
         if ( RcdFound137 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "UNICOD");
               AnyError = 1;
               GX_FocusControl = edtUniCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A49UniCod != Z49UniCod )
            {
               A49UniCod = Z49UniCod;
               AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "UNICOD");
               AnyError = 1;
               GX_FocusControl = edtUniCod_Internalname;
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
            if ( A49UniCod != Z49UniCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "UNICOD");
                  AnyError = 1;
                  GX_FocusControl = edtUniCod_Internalname;
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
         context.RollbackDataStores("cunidadmedida",pr_default);
         GX_FocusControl = edtUniDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3Y0( ) ;
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
         if ( RcdFound137 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "UNICOD");
            AnyError = 1;
            GX_FocusControl = edtUniCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtUniDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3Y137( ) ;
         if ( RcdFound137 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUniDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3Y137( ) ;
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
         if ( RcdFound137 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUniDsc_Internalname;
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
         if ( RcdFound137 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUniDsc_Internalname;
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
         ScanStart3Y137( ) ;
         if ( RcdFound137 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound137 != 0 )
            {
               ScanNext3Y137( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtUniDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3Y137( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3Y137( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003Y2 */
            pr_default.execute(0, new Object[] {A49UniCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CUNIDADMEDIDA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1998UniDsc, T003Y2_A1998UniDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1997UniAbr, T003Y2_A1997UniAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z2000UniSunat, T003Y2_A2000UniSunat[0]) != 0 ) || ( Z1999UniSts != T003Y2_A1999UniSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1998UniDsc, T003Y2_A1998UniDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("cunidadmedida:[seudo value changed for attri]"+"UniDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1998UniDsc);
                  GXUtil.WriteLogRaw("Current: ",T003Y2_A1998UniDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1997UniAbr, T003Y2_A1997UniAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("cunidadmedida:[seudo value changed for attri]"+"UniAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1997UniAbr);
                  GXUtil.WriteLogRaw("Current: ",T003Y2_A1997UniAbr[0]);
               }
               if ( StringUtil.StrCmp(Z2000UniSunat, T003Y2_A2000UniSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("cunidadmedida:[seudo value changed for attri]"+"UniSunat");
                  GXUtil.WriteLogRaw("Old: ",Z2000UniSunat);
                  GXUtil.WriteLogRaw("Current: ",T003Y2_A2000UniSunat[0]);
               }
               if ( Z1999UniSts != T003Y2_A1999UniSts[0] )
               {
                  GXUtil.WriteLog("cunidadmedida:[seudo value changed for attri]"+"UniSts");
                  GXUtil.WriteLogRaw("Old: ",Z1999UniSts);
                  GXUtil.WriteLogRaw("Current: ",T003Y2_A1999UniSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CUNIDADMEDIDA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3Y137( )
      {
         BeforeValidate3Y137( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3Y137( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3Y137( 0) ;
            CheckOptimisticConcurrency3Y137( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3Y137( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3Y137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003Y8 */
                     pr_default.execute(6, new Object[] {A49UniCod, A1998UniDsc, A1997UniAbr, A2000UniSunat, A1999UniSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CUNIDADMEDIDA");
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
                           ResetCaption3Y0( ) ;
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
               Load3Y137( ) ;
            }
            EndLevel3Y137( ) ;
         }
         CloseExtendedTableCursors3Y137( ) ;
      }

      protected void Update3Y137( )
      {
         BeforeValidate3Y137( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3Y137( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3Y137( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3Y137( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3Y137( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003Y9 */
                     pr_default.execute(7, new Object[] {A1998UniDsc, A1997UniAbr, A2000UniSunat, A1999UniSts, A49UniCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CUNIDADMEDIDA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CUNIDADMEDIDA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3Y137( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3Y0( ) ;
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
            EndLevel3Y137( ) ;
         }
         CloseExtendedTableCursors3Y137( ) ;
      }

      protected void DeferredUpdate3Y137( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3Y137( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3Y137( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3Y137( ) ;
            AfterConfirm3Y137( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3Y137( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003Y10 */
                  pr_default.execute(8, new Object[] {A49UniCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CUNIDADMEDIDA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound137 == 0 )
                        {
                           InitAll3Y137( ) ;
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
                        ResetCaption3Y0( ) ;
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
         sMode137 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3Y137( ) ;
         Gx_mode = sMode137;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3Y137( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003Y11 */
            pr_default.execute(9, new Object[] {A49UniCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos Unidades de Medida"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T003Y12 */
            pr_default.execute(10, new Object[] {A49UniCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel3Y137( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3Y137( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("cunidadmedida",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3Y0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("cunidadmedida",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3Y137( )
      {
         /* Using cursor T003Y13 */
         pr_default.execute(11);
         RcdFound137 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound137 = 1;
            A49UniCod = T003Y13_A49UniCod[0];
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3Y137( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound137 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound137 = 1;
            A49UniCod = T003Y13_A49UniCod[0];
            AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
         }
      }

      protected void ScanEnd3Y137( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm3Y137( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3Y137( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3Y137( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3Y137( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3Y137( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3Y137( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3Y137( )
      {
         edtUniCod_Enabled = 0;
         AssignProp("", false, edtUniCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniCod_Enabled), 5, 0), true);
         edtUniDsc_Enabled = 0;
         AssignProp("", false, edtUniDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniDsc_Enabled), 5, 0), true);
         edtUniAbr_Enabled = 0;
         AssignProp("", false, edtUniAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniAbr_Enabled), 5, 0), true);
         edtUniSunat_Enabled = 0;
         AssignProp("", false, edtUniSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtUniSunat_Enabled), 5, 0), true);
         cmbUniSts.Enabled = 0;
         AssignProp("", false, cmbUniSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbUniSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3Y137( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3Y0( )
      {
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, false);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( "Unidad de Medida") ;
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
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281810252326", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         context.WriteHtmlText( " "+"class=\"Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("cunidadmedida.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z49UniCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49UniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1998UniDsc", StringUtil.RTrim( Z1998UniDsc));
         GxWebStd.gx_hidden_field( context, "Z1997UniAbr", StringUtil.RTrim( Z1997UniAbr));
         GxWebStd.gx_hidden_field( context, "Z2000UniSunat", Z2000UniSunat);
         GxWebStd.gx_hidden_field( context, "Z1999UniSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1999UniSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm3Y137( )
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
         context.WriteHtmlTextNl( "</body>") ;
         context.WriteHtmlTextNl( "</html>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
      }

      public override string GetPgmname( )
      {
         return "CUNIDADMEDIDA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Unidad de Medida" ;
      }

      protected void InitializeNonKey3Y137( )
      {
         A1998UniDsc = "";
         AssignAttri("", false, "A1998UniDsc", A1998UniDsc);
         A1997UniAbr = "";
         AssignAttri("", false, "A1997UniAbr", A1997UniAbr);
         A2000UniSunat = "";
         AssignAttri("", false, "A2000UniSunat", A2000UniSunat);
         A1999UniSts = 0;
         AssignAttri("", false, "A1999UniSts", StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
         Z1998UniDsc = "";
         Z1997UniAbr = "";
         Z2000UniSunat = "";
         Z1999UniSts = 0;
      }

      protected void InitAll3Y137( )
      {
         A49UniCod = 0;
         AssignAttri("", false, "A49UniCod", StringUtil.LTrimStr( (decimal)(A49UniCod), 6, 0));
         InitializeNonKey3Y137( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810252330", true, true);
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
         context.AddJavascriptSource("cunidadmedida.js", "?202281810252331", false, true);
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
         edtUniCod_Internalname = "UNICOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtUniDsc_Internalname = "UNIDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtUniAbr_Internalname = "UNIABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtUniSunat_Internalname = "UNISUNAT";
         lblTextblock5_Internalname = "TEXTBLOCK5";
         cmbUniSts_Internalname = "UNISTS";
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
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbUniSts_Jsonclick = "";
         cmbUniSts.Enabled = 1;
         edtUniSunat_Jsonclick = "";
         edtUniSunat_Enabled = 1;
         edtUniAbr_Jsonclick = "";
         edtUniAbr_Enabled = 1;
         edtUniDsc_Jsonclick = "";
         edtUniDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtUniCod_Jsonclick = "";
         edtUniCod_Enabled = 1;
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
         cmbUniSts.Name = "UNISTS";
         cmbUniSts.WebTags = "";
         cmbUniSts.addItem("1", "ACTIVO", 0);
         cmbUniSts.addItem("0", "INACTIVO", 0);
         if ( cmbUniSts.ItemCount > 0 )
         {
            A1999UniSts = (short)(NumberUtil.Val( cmbUniSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0))), "."));
            AssignAttri("", false, "A1999UniSts", StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtUniDsc_Internalname;
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

      public void Valid_Unicod( )
      {
         A1999UniSts = (short)(NumberUtil.Val( cmbUniSts.CurrentValue, "."));
         cmbUniSts.CurrentValue = StringUtil.Str( (decimal)(A1999UniSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbUniSts.ItemCount > 0 )
         {
            A1999UniSts = (short)(NumberUtil.Val( cmbUniSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0))), "."));
            cmbUniSts.CurrentValue = StringUtil.Str( (decimal)(A1999UniSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbUniSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A1998UniDsc", StringUtil.RTrim( A1998UniDsc));
         AssignAttri("", false, "A1997UniAbr", StringUtil.RTrim( A1997UniAbr));
         AssignAttri("", false, "A2000UniSunat", A2000UniSunat);
         AssignAttri("", false, "A1999UniSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1999UniSts), 1, 0, ".", "")));
         cmbUniSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1999UniSts), 1, 0));
         AssignProp("", false, cmbUniSts_Internalname, "Values", cmbUniSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z49UniCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z49UniCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1998UniDsc", StringUtil.RTrim( Z1998UniDsc));
         GxWebStd.gx_hidden_field( context, "Z1997UniAbr", StringUtil.RTrim( Z1997UniAbr));
         GxWebStd.gx_hidden_field( context, "Z2000UniSunat", Z2000UniSunat);
         GxWebStd.gx_hidden_field( context, "Z1999UniSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1999UniSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_UNICOD","{handler:'Valid_Unicod',iparms:[{av:'cmbUniSts'},{av:'A1999UniSts',fld:'UNISTS',pic:'9'},{av:'A49UniCod',fld:'UNICOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_UNICOD",",oparms:[{av:'A1998UniDsc',fld:'UNIDSC',pic:''},{av:'A1997UniAbr',fld:'UNIABR',pic:''},{av:'A2000UniSunat',fld:'UNISUNAT',pic:''},{av:'cmbUniSts'},{av:'A1999UniSts',fld:'UNISTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z49UniCod'},{av:'Z1998UniDsc'},{av:'Z1997UniAbr'},{av:'Z2000UniSunat'},{av:'Z1999UniSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1998UniDsc = "";
         Z1997UniAbr = "";
         Z2000UniSunat = "";
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
         A1998UniDsc = "";
         lblTextblock3_Jsonclick = "";
         A1997UniAbr = "";
         lblTextblock4_Jsonclick = "";
         A2000UniSunat = "";
         lblTextblock5_Jsonclick = "";
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
         T003Y4_A49UniCod = new int[1] ;
         T003Y4_A1998UniDsc = new string[] {""} ;
         T003Y4_A1997UniAbr = new string[] {""} ;
         T003Y4_A2000UniSunat = new string[] {""} ;
         T003Y4_A1999UniSts = new short[1] ;
         T003Y5_A49UniCod = new int[1] ;
         T003Y3_A49UniCod = new int[1] ;
         T003Y3_A1998UniDsc = new string[] {""} ;
         T003Y3_A1997UniAbr = new string[] {""} ;
         T003Y3_A2000UniSunat = new string[] {""} ;
         T003Y3_A1999UniSts = new short[1] ;
         sMode137 = "";
         T003Y6_A49UniCod = new int[1] ;
         T003Y7_A49UniCod = new int[1] ;
         T003Y2_A49UniCod = new int[1] ;
         T003Y2_A1998UniDsc = new string[] {""} ;
         T003Y2_A1997UniAbr = new string[] {""} ;
         T003Y2_A2000UniSunat = new string[] {""} ;
         T003Y2_A1999UniSts = new short[1] ;
         T003Y11_A28ProdCod = new string[] {""} ;
         T003Y11_A58ProdMedUniCod = new int[1] ;
         T003Y12_A28ProdCod = new string[] {""} ;
         T003Y13_A49UniCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1998UniDsc = "";
         ZZ1997UniAbr = "";
         ZZ2000UniSunat = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.cunidadmedida__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cunidadmedida__default(),
            new Object[][] {
                new Object[] {
               T003Y2_A49UniCod, T003Y2_A1998UniDsc, T003Y2_A1997UniAbr, T003Y2_A2000UniSunat, T003Y2_A1999UniSts
               }
               , new Object[] {
               T003Y3_A49UniCod, T003Y3_A1998UniDsc, T003Y3_A1997UniAbr, T003Y3_A2000UniSunat, T003Y3_A1999UniSts
               }
               , new Object[] {
               T003Y4_A49UniCod, T003Y4_A1998UniDsc, T003Y4_A1997UniAbr, T003Y4_A2000UniSunat, T003Y4_A1999UniSts
               }
               , new Object[] {
               T003Y5_A49UniCod
               }
               , new Object[] {
               T003Y6_A49UniCod
               }
               , new Object[] {
               T003Y7_A49UniCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003Y11_A28ProdCod, T003Y11_A58ProdMedUniCod
               }
               , new Object[] {
               T003Y12_A28ProdCod
               }
               , new Object[] {
               T003Y13_A49UniCod
               }
            }
         );
      }

      private short Z1999UniSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1999UniSts ;
      private short GX_JID ;
      private short RcdFound137 ;
      private short nIsDirty_137 ;
      private short Gx_BScreen ;
      private short ZZ1999UniSts ;
      private int Z49UniCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A49UniCod ;
      private int edtUniCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtUniDsc_Enabled ;
      private int edtUniAbr_Enabled ;
      private int edtUniSunat_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ49UniCod ;
      private string sPrefix ;
      private string Z1998UniDsc ;
      private string Z1997UniAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtUniCod_Internalname ;
      private string cmbUniSts_Internalname ;
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
      private string edtUniCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtUniDsc_Internalname ;
      private string A1998UniDsc ;
      private string edtUniDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtUniAbr_Internalname ;
      private string A1997UniAbr ;
      private string edtUniAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtUniSunat_Internalname ;
      private string edtUniSunat_Jsonclick ;
      private string lblTextblock5_Internalname ;
      private string lblTextblock5_Jsonclick ;
      private string cmbUniSts_Jsonclick ;
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
      private string sMode137 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1998UniDsc ;
      private string ZZ1997UniAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z2000UniSunat ;
      private string A2000UniSunat ;
      private string ZZ2000UniSunat ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbUniSts ;
      private IDataStoreProvider pr_default ;
      private int[] T003Y4_A49UniCod ;
      private string[] T003Y4_A1998UniDsc ;
      private string[] T003Y4_A1997UniAbr ;
      private string[] T003Y4_A2000UniSunat ;
      private short[] T003Y4_A1999UniSts ;
      private int[] T003Y5_A49UniCod ;
      private int[] T003Y3_A49UniCod ;
      private string[] T003Y3_A1998UniDsc ;
      private string[] T003Y3_A1997UniAbr ;
      private string[] T003Y3_A2000UniSunat ;
      private short[] T003Y3_A1999UniSts ;
      private int[] T003Y6_A49UniCod ;
      private int[] T003Y7_A49UniCod ;
      private int[] T003Y2_A49UniCod ;
      private string[] T003Y2_A1998UniDsc ;
      private string[] T003Y2_A1997UniAbr ;
      private string[] T003Y2_A2000UniSunat ;
      private short[] T003Y2_A1999UniSts ;
      private string[] T003Y11_A28ProdCod ;
      private int[] T003Y11_A58ProdMedUniCod ;
      private string[] T003Y12_A28ProdCod ;
      private int[] T003Y13_A49UniCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class cunidadmedida__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class cunidadmedida__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT003Y4;
        prmT003Y4 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y5;
        prmT003Y5 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y3;
        prmT003Y3 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y6;
        prmT003Y6 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y7;
        prmT003Y7 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y2;
        prmT003Y2 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y8;
        prmT003Y8 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0) ,
        new ParDef("@UniDsc",GXType.NChar,100,0) ,
        new ParDef("@UniAbr",GXType.NChar,5,0) ,
        new ParDef("@UniSunat",GXType.NVarChar,5,0) ,
        new ParDef("@UniSts",GXType.Int16,1,0)
        };
        Object[] prmT003Y9;
        prmT003Y9 = new Object[] {
        new ParDef("@UniDsc",GXType.NChar,100,0) ,
        new ParDef("@UniAbr",GXType.NChar,5,0) ,
        new ParDef("@UniSunat",GXType.NVarChar,5,0) ,
        new ParDef("@UniSts",GXType.Int16,1,0) ,
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y10;
        prmT003Y10 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y11;
        prmT003Y11 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y12;
        prmT003Y12 = new Object[] {
        new ParDef("@UniCod",GXType.Int32,6,0)
        };
        Object[] prmT003Y13;
        prmT003Y13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003Y2", "SELECT [UniCod], [UniDsc], [UniAbr], [UniSunat], [UniSts] FROM [CUNIDADMEDIDA] WITH (UPDLOCK) WHERE [UniCod] = @UniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Y3", "SELECT [UniCod], [UniDsc], [UniAbr], [UniSunat], [UniSts] FROM [CUNIDADMEDIDA] WHERE [UniCod] = @UniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Y4", "SELECT TM1.[UniCod], TM1.[UniDsc], TM1.[UniAbr], TM1.[UniSunat], TM1.[UniSts] FROM [CUNIDADMEDIDA] TM1 WHERE TM1.[UniCod] = @UniCod ORDER BY TM1.[UniCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Y5", "SELECT [UniCod] FROM [CUNIDADMEDIDA] WHERE [UniCod] = @UniCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003Y6", "SELECT TOP 1 [UniCod] FROM [CUNIDADMEDIDA] WHERE ( [UniCod] > @UniCod) ORDER BY [UniCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Y7", "SELECT TOP 1 [UniCod] FROM [CUNIDADMEDIDA] WHERE ( [UniCod] < @UniCod) ORDER BY [UniCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Y8", "INSERT INTO [CUNIDADMEDIDA]([UniCod], [UniDsc], [UniAbr], [UniSunat], [UniSts]) VALUES(@UniCod, @UniDsc, @UniAbr, @UniSunat, @UniSts)", GxErrorMask.GX_NOMASK,prmT003Y8)
           ,new CursorDef("T003Y9", "UPDATE [CUNIDADMEDIDA] SET [UniDsc]=@UniDsc, [UniAbr]=@UniAbr, [UniSunat]=@UniSunat, [UniSts]=@UniSts  WHERE [UniCod] = @UniCod", GxErrorMask.GX_NOMASK,prmT003Y9)
           ,new CursorDef("T003Y10", "DELETE FROM [CUNIDADMEDIDA]  WHERE [UniCod] = @UniCod", GxErrorMask.GX_NOMASK,prmT003Y10)
           ,new CursorDef("T003Y11", "SELECT TOP 1 [ProdCod], [ProdMedUniCod] FROM [APRODUCTOSMEDIDAS] WHERE [ProdMedUniCod] = @UniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Y12", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [UniCod] = @UniCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003Y13", "SELECT [UniCod] FROM [CUNIDADMEDIDA] ORDER BY [UniCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003Y13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
