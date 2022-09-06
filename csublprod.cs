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
   public class csublprod : GXHttpHandler
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
            Form.Meta.addItem("description", "Sub Lineas de Productos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtSublCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public csublprod( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public csublprod( IGxContext context )
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
            RenderHtmlCloseForm3P128( ) ;
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CSUBLPROD.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo Sub Linea", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A51SublCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtSublCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A51SublCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSublCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Descripcion de Sub Linea", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublDsc_Internalname, StringUtil.RTrim( A1892SublDsc), StringUtil.RTrim( context.localUtil.Format( A1892SublDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSublDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Abreviatura de Sub Linea", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublAbr_Internalname, StringUtil.RTrim( A1891SublAbr), StringUtil.RTrim( context.localUtil.Format( A1891SublAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSublAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock4_Internalname, "Situacion de Sub Linea", "", "", lblTextblock4_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtSublSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1893SublSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtSublSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1893SublSts), "9") : context.localUtil.Format( (decimal)(A1893SublSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtSublSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtSublSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CSUBLPROD.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CSUBLPROD.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CSUBLPROD.htm");
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
            Z51SublCod = (int)(context.localUtil.CToN( cgiGet( "Z51SublCod"), ".", ","));
            Z1892SublDsc = cgiGet( "Z1892SublDsc");
            Z1891SublAbr = cgiGet( "Z1891SublAbr");
            Z1893SublSts = (short)(context.localUtil.CToN( cgiGet( "Z1893SublSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
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
            A1892SublDsc = cgiGet( edtSublDsc_Internalname);
            AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
            A1891SublAbr = cgiGet( edtSublAbr_Internalname);
            AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
            if ( ( ( context.localUtil.CToN( cgiGet( edtSublSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtSublSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "SUBLSTS");
               AnyError = 1;
               GX_FocusControl = edtSublSts_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A1893SublSts = 0;
               AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
            }
            else
            {
               A1893SublSts = (short)(context.localUtil.CToN( cgiGet( edtSublSts_Internalname), ".", ","));
               AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
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
               A51SublCod = (int)(NumberUtil.Val( GetPar( "SublCod"), "."));
               n51SublCod = false;
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
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
               InitAll3P128( ) ;
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
         DisableAttributes3P128( ) ;
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

      protected void CONFIRM_3P0( )
      {
         BeforeValidate3P128( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls3P128( ) ;
            }
            else
            {
               CheckExtendedTable3P128( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors3P128( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues3P0( ) ;
         }
      }

      protected void ResetCaption3P0( )
      {
      }

      protected void ZM3P128( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1892SublDsc = T003P3_A1892SublDsc[0];
               Z1891SublAbr = T003P3_A1891SublAbr[0];
               Z1893SublSts = T003P3_A1893SublSts[0];
            }
            else
            {
               Z1892SublDsc = A1892SublDsc;
               Z1891SublAbr = A1891SublAbr;
               Z1893SublSts = A1893SublSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z51SublCod = A51SublCod;
            Z1892SublDsc = A1892SublDsc;
            Z1891SublAbr = A1891SublAbr;
            Z1893SublSts = A1893SublSts;
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

      protected void Load3P128( )
      {
         /* Using cursor T003P4 */
         pr_default.execute(2, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound128 = 1;
            A1892SublDsc = T003P4_A1892SublDsc[0];
            AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
            A1891SublAbr = T003P4_A1891SublAbr[0];
            AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
            A1893SublSts = T003P4_A1893SublSts[0];
            AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
            ZM3P128( -1) ;
         }
         pr_default.close(2);
         OnLoadActions3P128( ) ;
      }

      protected void OnLoadActions3P128( )
      {
      }

      protected void CheckExtendedTable3P128( )
      {
         nIsDirty_128 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors3P128( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey3P128( )
      {
         /* Using cursor T003P5 */
         pr_default.execute(3, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound128 = 1;
         }
         else
         {
            RcdFound128 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T003P3 */
         pr_default.execute(1, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM3P128( 1) ;
            RcdFound128 = 1;
            A51SublCod = T003P3_A51SublCod[0];
            n51SublCod = T003P3_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            A1892SublDsc = T003P3_A1892SublDsc[0];
            AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
            A1891SublAbr = T003P3_A1891SublAbr[0];
            AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
            A1893SublSts = T003P3_A1893SublSts[0];
            AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
            Z51SublCod = A51SublCod;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load3P128( ) ;
            if ( AnyError == 1 )
            {
               RcdFound128 = 0;
               InitializeNonKey3P128( ) ;
            }
            Gx_mode = sMode128;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound128 = 0;
            InitializeNonKey3P128( ) ;
            sMode128 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode128;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey3P128( ) ;
         if ( RcdFound128 == 0 )
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
         RcdFound128 = 0;
         /* Using cursor T003P6 */
         pr_default.execute(4, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T003P6_A51SublCod[0] < A51SublCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T003P6_A51SublCod[0] > A51SublCod ) ) )
            {
               A51SublCod = T003P6_A51SublCod[0];
               n51SublCod = T003P6_n51SublCod[0];
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               RcdFound128 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound128 = 0;
         /* Using cursor T003P7 */
         pr_default.execute(5, new Object[] {n51SublCod, A51SublCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T003P7_A51SublCod[0] > A51SublCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T003P7_A51SublCod[0] < A51SublCod ) ) )
            {
               A51SublCod = T003P7_A51SublCod[0];
               n51SublCod = T003P7_n51SublCod[0];
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               RcdFound128 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey3P128( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtSublCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert3P128( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound128 == 1 )
            {
               if ( A51SublCod != Z51SublCod )
               {
                  A51SublCod = Z51SublCod;
                  n51SublCod = false;
                  AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "SUBLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update3P128( ) ;
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A51SublCod != Z51SublCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtSublCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert3P128( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUBLCOD");
                     AnyError = 1;
                     GX_FocusControl = edtSublCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtSublCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert3P128( ) ;
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
         if ( A51SublCod != Z51SublCod )
         {
            A51SublCod = Z51SublCod;
            n51SublCod = false;
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "SUBLCOD");
            AnyError = 1;
            GX_FocusControl = edtSublCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtSublCod_Internalname;
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
         GetKey3P128( ) ;
         if ( RcdFound128 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A51SublCod != Z51SublCod )
            {
               A51SublCod = Z51SublCod;
               n51SublCod = false;
               AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "SUBLCOD");
               AnyError = 1;
               GX_FocusControl = edtSublCod_Internalname;
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
            if ( A51SublCod != Z51SublCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "SUBLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtSublCod_Internalname;
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
         context.RollbackDataStores("csublprod",pr_default);
         GX_FocusControl = edtSublDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_3P0( ) ;
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
         if ( RcdFound128 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "SUBLCOD");
            AnyError = 1;
            GX_FocusControl = edtSublCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtSublDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart3P128( ) ;
         if ( RcdFound128 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSublDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3P128( ) ;
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
         if ( RcdFound128 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSublDsc_Internalname;
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
         if ( RcdFound128 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSublDsc_Internalname;
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
         ScanStart3P128( ) ;
         if ( RcdFound128 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound128 != 0 )
            {
               ScanNext3P128( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtSublDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd3P128( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency3P128( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T003P2 */
            pr_default.execute(0, new Object[] {n51SublCod, A51SublCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CSUBLPROD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1892SublDsc, T003P2_A1892SublDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1891SublAbr, T003P2_A1891SublAbr[0]) != 0 ) || ( Z1893SublSts != T003P2_A1893SublSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1892SublDsc, T003P2_A1892SublDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("csublprod:[seudo value changed for attri]"+"SublDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1892SublDsc);
                  GXUtil.WriteLogRaw("Current: ",T003P2_A1892SublDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1891SublAbr, T003P2_A1891SublAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("csublprod:[seudo value changed for attri]"+"SublAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1891SublAbr);
                  GXUtil.WriteLogRaw("Current: ",T003P2_A1891SublAbr[0]);
               }
               if ( Z1893SublSts != T003P2_A1893SublSts[0] )
               {
                  GXUtil.WriteLog("csublprod:[seudo value changed for attri]"+"SublSts");
                  GXUtil.WriteLogRaw("Old: ",Z1893SublSts);
                  GXUtil.WriteLogRaw("Current: ",T003P2_A1893SublSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CSUBLPROD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert3P128( )
      {
         BeforeValidate3P128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3P128( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM3P128( 0) ;
            CheckOptimisticConcurrency3P128( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3P128( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert3P128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003P8 */
                     pr_default.execute(6, new Object[] {n51SublCod, A51SublCod, A1892SublDsc, A1891SublAbr, A1893SublSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CSUBLPROD");
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
                           ResetCaption3P0( ) ;
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
               Load3P128( ) ;
            }
            EndLevel3P128( ) ;
         }
         CloseExtendedTableCursors3P128( ) ;
      }

      protected void Update3P128( )
      {
         BeforeValidate3P128( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable3P128( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3P128( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm3P128( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate3P128( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T003P9 */
                     pr_default.execute(7, new Object[] {A1892SublDsc, A1891SublAbr, A1893SublSts, n51SublCod, A51SublCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CSUBLPROD");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CSUBLPROD"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate3P128( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption3P0( ) ;
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
            EndLevel3P128( ) ;
         }
         CloseExtendedTableCursors3P128( ) ;
      }

      protected void DeferredUpdate3P128( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate3P128( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency3P128( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls3P128( ) ;
            AfterConfirm3P128( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete3P128( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T003P10 */
                  pr_default.execute(8, new Object[] {n51SublCod, A51SublCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CSUBLPROD");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound128 == 0 )
                        {
                           InitAll3P128( ) ;
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
                        ResetCaption3P0( ) ;
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
         sMode128 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel3P128( ) ;
         Gx_mode = sMode128;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls3P128( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T003P11 */
            pr_default.execute(9, new Object[] {n51SublCod, A51SublCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T003P12 */
            pr_default.execute(10, new Object[] {n51SublCod, A51SublCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel3P128( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete3P128( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("csublprod",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues3P0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("csublprod",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart3P128( )
      {
         /* Using cursor T003P13 */
         pr_default.execute(11);
         RcdFound128 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound128 = 1;
            A51SublCod = T003P13_A51SublCod[0];
            n51SublCod = T003P13_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext3P128( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound128 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound128 = 1;
            A51SublCod = T003P13_A51SublCod[0];
            n51SublCod = T003P13_n51SublCod[0];
            AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         }
      }

      protected void ScanEnd3P128( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm3P128( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert3P128( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate3P128( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete3P128( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete3P128( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate3P128( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes3P128( )
      {
         edtSublCod_Enabled = 0;
         AssignProp("", false, edtSublCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublCod_Enabled), 5, 0), true);
         edtSublDsc_Enabled = 0;
         AssignProp("", false, edtSublDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublDsc_Enabled), 5, 0), true);
         edtSublAbr_Enabled = 0;
         AssignProp("", false, edtSublAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublAbr_Enabled), 5, 0), true);
         edtSublSts_Enabled = 0;
         AssignProp("", false, edtSublSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtSublSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes3P128( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues3P0( )
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
         context.SendWebValue( "Sub Lineas de Productos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810251932", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("csublprod.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1892SublDsc", StringUtil.RTrim( Z1892SublDsc));
         GxWebStd.gx_hidden_field( context, "Z1891SublAbr", StringUtil.RTrim( Z1891SublAbr));
         GxWebStd.gx_hidden_field( context, "Z1893SublSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1893SublSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm3P128( )
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
         return "CSUBLPROD" ;
      }

      public override string GetPgmdesc( )
      {
         return "Sub Lineas de Productos" ;
      }

      protected void InitializeNonKey3P128( )
      {
         A1892SublDsc = "";
         AssignAttri("", false, "A1892SublDsc", A1892SublDsc);
         A1891SublAbr = "";
         AssignAttri("", false, "A1891SublAbr", A1891SublAbr);
         A1893SublSts = 0;
         AssignAttri("", false, "A1893SublSts", StringUtil.Str( (decimal)(A1893SublSts), 1, 0));
         Z1892SublDsc = "";
         Z1891SublAbr = "";
         Z1893SublSts = 0;
      }

      protected void InitAll3P128( )
      {
         A51SublCod = 0;
         n51SublCod = false;
         AssignAttri("", false, "A51SublCod", StringUtil.LTrimStr( (decimal)(A51SublCod), 6, 0));
         InitializeNonKey3P128( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810251936", true, true);
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
         context.AddJavascriptSource("csublprod.js", "?202281810251936", false, true);
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
         edtSublCod_Internalname = "SUBLCOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtSublDsc_Internalname = "SUBLDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         edtSublAbr_Internalname = "SUBLABR";
         lblTextblock4_Internalname = "TEXTBLOCK4";
         edtSublSts_Internalname = "SUBLSTS";
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
         edtSublSts_Jsonclick = "";
         edtSublSts_Enabled = 1;
         edtSublAbr_Jsonclick = "";
         edtSublAbr_Enabled = 1;
         edtSublDsc_Jsonclick = "";
         edtSublDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtSublCod_Jsonclick = "";
         edtSublCod_Enabled = 1;
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
         GX_FocusControl = edtSublDsc_Internalname;
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

      public void Valid_Sublcod( )
      {
         n51SublCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A1892SublDsc", StringUtil.RTrim( A1892SublDsc));
         AssignAttri("", false, "A1891SublAbr", StringUtil.RTrim( A1891SublAbr));
         AssignAttri("", false, "A1893SublSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A1893SublSts), 1, 0, ".", "")));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z51SublCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z51SublCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1892SublDsc", StringUtil.RTrim( Z1892SublDsc));
         GxWebStd.gx_hidden_field( context, "Z1891SublAbr", StringUtil.RTrim( Z1891SublAbr));
         GxWebStd.gx_hidden_field( context, "Z1893SublSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1893SublSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_SUBLCOD","{handler:'Valid_Sublcod',iparms:[{av:'A51SublCod',fld:'SUBLCOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_SUBLCOD",",oparms:[{av:'A1892SublDsc',fld:'SUBLDSC',pic:''},{av:'A1891SublAbr',fld:'SUBLABR',pic:''},{av:'A1893SublSts',fld:'SUBLSTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z51SublCod'},{av:'Z1892SublDsc'},{av:'Z1891SublAbr'},{av:'Z1893SublSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z1892SublDsc = "";
         Z1891SublAbr = "";
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
         A1892SublDsc = "";
         lblTextblock3_Jsonclick = "";
         A1891SublAbr = "";
         lblTextblock4_Jsonclick = "";
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
         T003P4_A51SublCod = new int[1] ;
         T003P4_n51SublCod = new bool[] {false} ;
         T003P4_A1892SublDsc = new string[] {""} ;
         T003P4_A1891SublAbr = new string[] {""} ;
         T003P4_A1893SublSts = new short[1] ;
         T003P5_A51SublCod = new int[1] ;
         T003P5_n51SublCod = new bool[] {false} ;
         T003P3_A51SublCod = new int[1] ;
         T003P3_n51SublCod = new bool[] {false} ;
         T003P3_A1892SublDsc = new string[] {""} ;
         T003P3_A1891SublAbr = new string[] {""} ;
         T003P3_A1893SublSts = new short[1] ;
         sMode128 = "";
         T003P6_A51SublCod = new int[1] ;
         T003P6_n51SublCod = new bool[] {false} ;
         T003P7_A51SublCod = new int[1] ;
         T003P7_n51SublCod = new bool[] {false} ;
         T003P2_A51SublCod = new int[1] ;
         T003P2_n51SublCod = new bool[] {false} ;
         T003P2_A1892SublDsc = new string[] {""} ;
         T003P2_A1891SublAbr = new string[] {""} ;
         T003P2_A1893SublSts = new short[1] ;
         T003P11_A83ParTip = new string[] {""} ;
         T003P11_A84ParCod = new int[1] ;
         T003P11_A104ParDItem = new short[1] ;
         T003P12_A28ProdCod = new string[] {""} ;
         T003P13_A51SublCod = new int[1] ;
         T003P13_n51SublCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ1892SublDsc = "";
         ZZ1891SublAbr = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.csublprod__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.csublprod__default(),
            new Object[][] {
                new Object[] {
               T003P2_A51SublCod, T003P2_A1892SublDsc, T003P2_A1891SublAbr, T003P2_A1893SublSts
               }
               , new Object[] {
               T003P3_A51SublCod, T003P3_A1892SublDsc, T003P3_A1891SublAbr, T003P3_A1893SublSts
               }
               , new Object[] {
               T003P4_A51SublCod, T003P4_A1892SublDsc, T003P4_A1891SublAbr, T003P4_A1893SublSts
               }
               , new Object[] {
               T003P5_A51SublCod
               }
               , new Object[] {
               T003P6_A51SublCod
               }
               , new Object[] {
               T003P7_A51SublCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T003P11_A83ParTip, T003P11_A84ParCod, T003P11_A104ParDItem
               }
               , new Object[] {
               T003P12_A28ProdCod
               }
               , new Object[] {
               T003P13_A51SublCod
               }
            }
         );
      }

      private short Z1893SublSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A1893SublSts ;
      private short GX_JID ;
      private short RcdFound128 ;
      private short nIsDirty_128 ;
      private short Gx_BScreen ;
      private short ZZ1893SublSts ;
      private int Z51SublCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A51SublCod ;
      private int edtSublCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtSublDsc_Enabled ;
      private int edtSublAbr_Enabled ;
      private int edtSublSts_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ51SublCod ;
      private string sPrefix ;
      private string Z1892SublDsc ;
      private string Z1891SublAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtSublCod_Internalname ;
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
      private string edtSublCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtSublDsc_Internalname ;
      private string A1892SublDsc ;
      private string edtSublDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string edtSublAbr_Internalname ;
      private string A1891SublAbr ;
      private string edtSublAbr_Jsonclick ;
      private string lblTextblock4_Internalname ;
      private string lblTextblock4_Jsonclick ;
      private string edtSublSts_Internalname ;
      private string edtSublSts_Jsonclick ;
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
      private string sMode128 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ1892SublDsc ;
      private string ZZ1891SublAbr ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n51SublCod ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T003P4_A51SublCod ;
      private bool[] T003P4_n51SublCod ;
      private string[] T003P4_A1892SublDsc ;
      private string[] T003P4_A1891SublAbr ;
      private short[] T003P4_A1893SublSts ;
      private int[] T003P5_A51SublCod ;
      private bool[] T003P5_n51SublCod ;
      private int[] T003P3_A51SublCod ;
      private bool[] T003P3_n51SublCod ;
      private string[] T003P3_A1892SublDsc ;
      private string[] T003P3_A1891SublAbr ;
      private short[] T003P3_A1893SublSts ;
      private int[] T003P6_A51SublCod ;
      private bool[] T003P6_n51SublCod ;
      private int[] T003P7_A51SublCod ;
      private bool[] T003P7_n51SublCod ;
      private int[] T003P2_A51SublCod ;
      private bool[] T003P2_n51SublCod ;
      private string[] T003P2_A1892SublDsc ;
      private string[] T003P2_A1891SublAbr ;
      private short[] T003P2_A1893SublSts ;
      private string[] T003P11_A83ParTip ;
      private int[] T003P11_A84ParCod ;
      private short[] T003P11_A104ParDItem ;
      private string[] T003P12_A28ProdCod ;
      private int[] T003P13_A51SublCod ;
      private bool[] T003P13_n51SublCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class csublprod__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class csublprod__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT003P4;
        prmT003P4 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P5;
        prmT003P5 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P3;
        prmT003P3 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P6;
        prmT003P6 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P7;
        prmT003P7 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P2;
        prmT003P2 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P8;
        prmT003P8 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@SublDsc",GXType.NChar,100,0) ,
        new ParDef("@SublAbr",GXType.NChar,5,0) ,
        new ParDef("@SublSts",GXType.Int16,1,0)
        };
        Object[] prmT003P9;
        prmT003P9 = new Object[] {
        new ParDef("@SublDsc",GXType.NChar,100,0) ,
        new ParDef("@SublAbr",GXType.NChar,5,0) ,
        new ParDef("@SublSts",GXType.Int16,1,0) ,
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P10;
        prmT003P10 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P11;
        prmT003P11 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P12;
        prmT003P12 = new Object[] {
        new ParDef("@SublCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT003P13;
        prmT003P13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T003P2", "SELECT [SublCod], [SublDsc], [SublAbr], [SublSts] FROM [CSUBLPROD] WITH (UPDLOCK) WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003P2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003P3", "SELECT [SublCod], [SublDsc], [SublAbr], [SublSts] FROM [CSUBLPROD] WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003P3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003P4", "SELECT TM1.[SublCod], TM1.[SublDsc], TM1.[SublAbr], TM1.[SublSts] FROM [CSUBLPROD] TM1 WHERE TM1.[SublCod] = @SublCod ORDER BY TM1.[SublCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003P4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003P5", "SELECT [SublCod] FROM [CSUBLPROD] WHERE [SublCod] = @SublCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003P5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T003P6", "SELECT TOP 1 [SublCod] FROM [CSUBLPROD] WHERE ( [SublCod] > @SublCod) ORDER BY [SublCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003P6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003P7", "SELECT TOP 1 [SublCod] FROM [CSUBLPROD] WHERE ( [SublCod] < @SublCod) ORDER BY [SublCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT003P7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003P8", "INSERT INTO [CSUBLPROD]([SublCod], [SublDsc], [SublAbr], [SublSts]) VALUES(@SublCod, @SublDsc, @SublAbr, @SublSts)", GxErrorMask.GX_NOMASK,prmT003P8)
           ,new CursorDef("T003P9", "UPDATE [CSUBLPROD] SET [SublDsc]=@SublDsc, [SublAbr]=@SublAbr, [SublSts]=@SublSts  WHERE [SublCod] = @SublCod", GxErrorMask.GX_NOMASK,prmT003P9)
           ,new CursorDef("T003P10", "DELETE FROM [CSUBLPROD]  WHERE [SublCod] = @SublCod", GxErrorMask.GX_NOMASK,prmT003P10)
           ,new CursorDef("T003P11", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDSubProd] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003P11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003P12", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [SublCod] = @SublCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT003P12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T003P13", "SELECT [SublCod] FROM [CSUBLPROD] ORDER BY [SublCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT003P13,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
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
