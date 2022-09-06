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
   public class careas : GXDataArea
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
            Form.Meta.addItem("description", "Areas Empresa", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtAreCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public careas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public careas( IGxContext context )
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
         cmbAreSts = new GXCombobox();
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
         if ( cmbAreSts.ItemCount > 0 )
         {
            A475AreSts = (short)(NumberUtil.Val( cmbAreSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0))), "."));
            AssignAttri("", false, "A475AreSts", StringUtil.Str( (decimal)(A475AreSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAreSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0));
            AssignProp("", false, cmbAreSts_Internalname, "Values", cmbAreSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "|<", bttBtn_first_Jsonclick, 5, "|<", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "BtnPrevious";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "<", bttBtn_previous_Jsonclick, 5, "<", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "BtnNext";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", ">", bttBtn_next_Jsonclick, 5, ">", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'',false,'',0)\"";
         ClassString = "BtnLast";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", ">|", bttBtn_last_Jsonclick, 5, ">|", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 9,'',false,'',0)\"";
         ClassString = "BtnSelect";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Seleccionar", bttBtn_select_Jsonclick, 5, "Seleccionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CAREAS.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CAREAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A69AreCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtAreCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A69AreCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A69AreCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAreCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "BtnGet";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_get_Internalname, "", "=>", bttBtn_get_Jsonclick, 6, "=>", "", StyleString, ClassString, bttBtn_get_Visible, bttBtn_get_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EGET."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Area Empresa", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CAREAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtAreDsc_Internalname, A474AreDsc, StringUtil.RTrim( context.localUtil.Format( A474AreDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtAreDsc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtAreDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_CAREAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_CAREAS.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 31,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbAreSts, cmbAreSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0)), 1, cmbAreSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbAreSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,31);\"", "", true, 1, "HLP_CAREAS.htm");
         cmbAreSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0));
         AssignProp("", false, cmbAreSts_Internalname, "Values", (string)(cmbAreSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "BtnEnter";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         ClassString = "BtnCheck";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_check_Internalname, "", "Verificar", bttBtn_check_Jsonclick, 5, "Verificar", "", StyleString, ClassString, bttBtn_check_Visible, bttBtn_check_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"ECHECK."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'',0)\"";
         ClassString = "BtnCancel";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancelar", bttBtn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "BtnDelete";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Eliminar", bttBtn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CAREAS.htm");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "BtnHelp";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_help_Internalname, "", "Ayuda", bttBtn_help_Jsonclick, 3, "Ayuda", "", StyleString, ClassString, bttBtn_help_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EHELP."+"'", TempTags, "", 2, "HLP_CAREAS.htm");
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
            Z69AreCod = (int)(context.localUtil.CToN( cgiGet( "Z69AreCod"), ".", ","));
            Z474AreDsc = cgiGet( "Z474AreDsc");
            Z475AreSts = (short)(context.localUtil.CToN( cgiGet( "Z475AreSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A69AreCod = 0;
               n69AreCod = false;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            }
            else
            {
               A69AreCod = (int)(context.localUtil.CToN( cgiGet( edtAreCod_Internalname), ".", ","));
               n69AreCod = false;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            }
            A474AreDsc = cgiGet( edtAreDsc_Internalname);
            AssignAttri("", false, "A474AreDsc", A474AreDsc);
            cmbAreSts.CurrentValue = cgiGet( cmbAreSts_Internalname);
            A475AreSts = (short)(NumberUtil.Val( cgiGet( cmbAreSts_Internalname), "."));
            AssignAttri("", false, "A475AreSts", StringUtil.Str( (decimal)(A475AreSts), 1, 0));
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
               A69AreCod = (int)(NumberUtil.Val( GetPar( "AreCod"), "."));
               n69AreCod = false;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
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
               InitAll1L55( ) ;
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
         DisableAttributes1L55( ) ;
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

      protected void CONFIRM_1L0( )
      {
         BeforeValidate1L55( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1L55( ) ;
            }
            else
            {
               CheckExtendedTable1L55( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1L55( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
         if ( AnyError == 0 )
         {
            ConfirmValues1L0( ) ;
         }
      }

      protected void ResetCaption1L0( )
      {
      }

      protected void ZM1L55( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z474AreDsc = T001L3_A474AreDsc[0];
               Z475AreSts = T001L3_A475AreSts[0];
            }
            else
            {
               Z474AreDsc = A474AreDsc;
               Z475AreSts = A475AreSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z69AreCod = A69AreCod;
            Z474AreDsc = A474AreDsc;
            Z475AreSts = A475AreSts;
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

      protected void Load1L55( )
      {
         /* Using cursor T001L4 */
         pr_default.execute(2, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound55 = 1;
            A474AreDsc = T001L4_A474AreDsc[0];
            AssignAttri("", false, "A474AreDsc", A474AreDsc);
            A475AreSts = T001L4_A475AreSts[0];
            AssignAttri("", false, "A475AreSts", StringUtil.Str( (decimal)(A475AreSts), 1, 0));
            ZM1L55( -1) ;
         }
         pr_default.close(2);
         OnLoadActions1L55( ) ;
      }

      protected void OnLoadActions1L55( )
      {
      }

      protected void CheckExtendedTable1L55( )
      {
         nIsDirty_55 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1L55( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1L55( )
      {
         /* Using cursor T001L5 */
         pr_default.execute(3, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound55 = 1;
         }
         else
         {
            RcdFound55 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T001L3 */
         pr_default.execute(1, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1L55( 1) ;
            RcdFound55 = 1;
            A69AreCod = T001L3_A69AreCod[0];
            n69AreCod = T001L3_n69AreCod[0];
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            A474AreDsc = T001L3_A474AreDsc[0];
            AssignAttri("", false, "A474AreDsc", A474AreDsc);
            A475AreSts = T001L3_A475AreSts[0];
            AssignAttri("", false, "A475AreSts", StringUtil.Str( (decimal)(A475AreSts), 1, 0));
            Z69AreCod = A69AreCod;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load1L55( ) ;
            if ( AnyError == 1 )
            {
               RcdFound55 = 0;
               InitializeNonKey1L55( ) ;
            }
            Gx_mode = sMode55;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound55 = 0;
            InitializeNonKey1L55( ) ;
            sMode55 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode55;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1L55( ) ;
         if ( RcdFound55 == 0 )
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
         RcdFound55 = 0;
         /* Using cursor T001L6 */
         pr_default.execute(4, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T001L6_A69AreCod[0] < A69AreCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T001L6_A69AreCod[0] > A69AreCod ) ) )
            {
               A69AreCod = T001L6_A69AreCod[0];
               n69AreCod = T001L6_n69AreCod[0];
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
               RcdFound55 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound55 = 0;
         /* Using cursor T001L7 */
         pr_default.execute(5, new Object[] {n69AreCod, A69AreCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T001L7_A69AreCod[0] > A69AreCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T001L7_A69AreCod[0] < A69AreCod ) ) )
            {
               A69AreCod = T001L7_A69AreCod[0];
               n69AreCod = T001L7_n69AreCod[0];
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
               RcdFound55 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1L55( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtAreCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1L55( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound55 == 1 )
            {
               if ( A69AreCod != Z69AreCod )
               {
                  A69AreCod = Z69AreCod;
                  n69AreCod = false;
                  AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ARECOD");
                  AnyError = 1;
                  GX_FocusControl = edtAreCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtAreCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update1L55( ) ;
                  GX_FocusControl = edtAreCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A69AreCod != Z69AreCod )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtAreCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1L55( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ARECOD");
                     AnyError = 1;
                     GX_FocusControl = edtAreCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtAreCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1L55( ) ;
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
         if ( A69AreCod != Z69AreCod )
         {
            A69AreCod = Z69AreCod;
            n69AreCod = false;
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ARECOD");
            AnyError = 1;
            GX_FocusControl = edtAreCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtAreCod_Internalname;
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
         GetKey1L55( ) ;
         if ( RcdFound55 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            else if ( A69AreCod != Z69AreCod )
            {
               A69AreCod = Z69AreCod;
               n69AreCod = false;
               AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "ARECOD");
               AnyError = 1;
               GX_FocusControl = edtAreCod_Internalname;
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
            if ( A69AreCod != Z69AreCod )
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ARECOD");
                  AnyError = 1;
                  GX_FocusControl = edtAreCod_Internalname;
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
         context.RollbackDataStores("careas",pr_default);
         GX_FocusControl = edtAreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
      }

      protected void insert_Check( )
      {
         CONFIRM_1L0( ) ;
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
         if ( RcdFound55 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ARECOD");
            AnyError = 1;
            GX_FocusControl = edtAreCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtAreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart1L55( ) ;
         if ( RcdFound55 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1L55( ) ;
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
         if ( RcdFound55 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAreDsc_Internalname;
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
         if ( RcdFound55 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAreDsc_Internalname;
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
         ScanStart1L55( ) ;
         if ( RcdFound55 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound55 != 0 )
            {
               ScanNext1L55( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtAreDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd1L55( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency1L55( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T001L2 */
            pr_default.execute(0, new Object[] {n69AreCod, A69AreCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CAREAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z474AreDsc, T001L2_A474AreDsc[0]) != 0 ) || ( Z475AreSts != T001L2_A475AreSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z474AreDsc, T001L2_A474AreDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("careas:[seudo value changed for attri]"+"AreDsc");
                  GXUtil.WriteLogRaw("Old: ",Z474AreDsc);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A474AreDsc[0]);
               }
               if ( Z475AreSts != T001L2_A475AreSts[0] )
               {
                  GXUtil.WriteLog("careas:[seudo value changed for attri]"+"AreSts");
                  GXUtil.WriteLogRaw("Old: ",Z475AreSts);
                  GXUtil.WriteLogRaw("Current: ",T001L2_A475AreSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CAREAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1L55( )
      {
         BeforeValidate1L55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L55( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1L55( 0) ;
            CheckOptimisticConcurrency1L55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1L55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L8 */
                     pr_default.execute(6, new Object[] {n69AreCod, A69AreCod, A474AreDsc, A475AreSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CAREAS");
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
                           ResetCaption1L0( ) ;
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
               Load1L55( ) ;
            }
            EndLevel1L55( ) ;
         }
         CloseExtendedTableCursors1L55( ) ;
      }

      protected void Update1L55( )
      {
         BeforeValidate1L55( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1L55( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L55( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1L55( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1L55( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001L9 */
                     pr_default.execute(7, new Object[] {A474AreDsc, A475AreSts, n69AreCod, A69AreCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CAREAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CAREAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1L55( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption1L0( ) ;
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
            EndLevel1L55( ) ;
         }
         CloseExtendedTableCursors1L55( ) ;
      }

      protected void DeferredUpdate1L55( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate1L55( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1L55( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1L55( ) ;
            AfterConfirm1L55( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1L55( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001L10 */
                  pr_default.execute(8, new Object[] {n69AreCod, A69AreCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CAREAS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound55 == 0 )
                        {
                           InitAll1L55( ) ;
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
                        ResetCaption1L0( ) ;
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
         sMode55 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1L55( ) ;
         Gx_mode = sMode55;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1L55( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001L11 */
            pr_default.execute(9, new Object[] {n69AreCod, A69AreCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1L55( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1L55( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("careas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues1L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("careas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1L55( )
      {
         /* Using cursor T001L12 */
         pr_default.execute(10);
         RcdFound55 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound55 = 1;
            A69AreCod = T001L12_A69AreCod[0];
            n69AreCod = T001L12_n69AreCod[0];
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1L55( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound55 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound55 = 1;
            A69AreCod = T001L12_A69AreCod[0];
            n69AreCod = T001L12_n69AreCod[0];
            AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
         }
      }

      protected void ScanEnd1L55( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1L55( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1L55( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1L55( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1L55( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1L55( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1L55( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1L55( )
      {
         edtAreCod_Enabled = 0;
         AssignProp("", false, edtAreCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreCod_Enabled), 5, 0), true);
         edtAreDsc_Enabled = 0;
         AssignProp("", false, edtAreDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtAreDsc_Enabled), 5, 0), true);
         cmbAreSts.Enabled = 0;
         AssignProp("", false, cmbAreSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbAreSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1L55( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues1L0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181024182", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("careas.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z69AreCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69AreCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z474AreDsc", Z474AreDsc);
         GxWebStd.gx_hidden_field( context, "Z475AreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z475AreSts), 1, 0, ".", "")));
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
         return formatLink("careas.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "CAREAS" ;
      }

      public override string GetPgmdesc( )
      {
         return "Areas Empresa" ;
      }

      protected void InitializeNonKey1L55( )
      {
         A474AreDsc = "";
         AssignAttri("", false, "A474AreDsc", A474AreDsc);
         A475AreSts = 0;
         AssignAttri("", false, "A475AreSts", StringUtil.Str( (decimal)(A475AreSts), 1, 0));
         Z474AreDsc = "";
         Z475AreSts = 0;
      }

      protected void InitAll1L55( )
      {
         A69AreCod = 0;
         n69AreCod = false;
         AssignAttri("", false, "A69AreCod", StringUtil.LTrimStr( (decimal)(A69AreCod), 6, 0));
         InitializeNonKey1L55( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181024186", true, true);
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
         context.AddJavascriptSource("careas.js", "?20228181024187", false, true);
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
         edtAreCod_Internalname = "ARECOD";
         bttBtn_get_Internalname = "BTN_GET";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtAreDsc_Internalname = "AREDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbAreSts_Internalname = "ARESTS";
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
         Form.Caption = "Areas Empresa";
         bttBtn_help_Visible = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_check_Enabled = 1;
         bttBtn_check_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         cmbAreSts_Jsonclick = "";
         cmbAreSts.Enabled = 1;
         edtAreDsc_Jsonclick = "";
         edtAreDsc_Enabled = 1;
         bttBtn_get_Enabled = 1;
         bttBtn_get_Visible = 1;
         edtAreCod_Jsonclick = "";
         edtAreCod_Enabled = 1;
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
         cmbAreSts.Name = "ARESTS";
         cmbAreSts.WebTags = "";
         cmbAreSts.addItem("1", "ACTIVO", 0);
         cmbAreSts.addItem("0", "INACTIVO", 0);
         if ( cmbAreSts.ItemCount > 0 )
         {
            A475AreSts = (short)(NumberUtil.Val( cmbAreSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0))), "."));
            AssignAttri("", false, "A475AreSts", StringUtil.Str( (decimal)(A475AreSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtAreDsc_Internalname;
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

      public void Valid_Arecod( )
      {
         A475AreSts = (short)(NumberUtil.Val( cmbAreSts.CurrentValue, "."));
         cmbAreSts.CurrentValue = StringUtil.Str( (decimal)(A475AreSts), 1, 0);
         n69AreCod = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbAreSts.ItemCount > 0 )
         {
            A475AreSts = (short)(NumberUtil.Val( cmbAreSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0))), "."));
            cmbAreSts.CurrentValue = StringUtil.Str( (decimal)(A475AreSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbAreSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A474AreDsc", A474AreDsc);
         AssignAttri("", false, "A475AreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A475AreSts), 1, 0, ".", "")));
         cmbAreSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A475AreSts), 1, 0));
         AssignProp("", false, cmbAreSts_Internalname, "Values", cmbAreSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z69AreCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z69AreCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z474AreDsc", Z474AreDsc);
         GxWebStd.gx_hidden_field( context, "Z475AreSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z475AreSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_ARECOD","{handler:'Valid_Arecod',iparms:[{av:'cmbAreSts'},{av:'A475AreSts',fld:'ARESTS',pic:'9'},{av:'A69AreCod',fld:'ARECOD',pic:'ZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ARECOD",",oparms:[{av:'A474AreDsc',fld:'AREDSC',pic:''},{av:'cmbAreSts'},{av:'A475AreSts',fld:'ARESTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z69AreCod'},{av:'Z474AreDsc'},{av:'Z475AreSts'},{ctrl:'BTN_GET',prop:'Enabled'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{ctrl:'BTN_CHECK',prop:'Enabled'}]}");
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
         Z474AreDsc = "";
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
         A474AreDsc = "";
         lblTextblock3_Jsonclick = "";
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
         T001L4_A69AreCod = new int[1] ;
         T001L4_n69AreCod = new bool[] {false} ;
         T001L4_A474AreDsc = new string[] {""} ;
         T001L4_A475AreSts = new short[1] ;
         T001L5_A69AreCod = new int[1] ;
         T001L5_n69AreCod = new bool[] {false} ;
         T001L3_A69AreCod = new int[1] ;
         T001L3_n69AreCod = new bool[] {false} ;
         T001L3_A474AreDsc = new string[] {""} ;
         T001L3_A475AreSts = new short[1] ;
         sMode55 = "";
         T001L6_A69AreCod = new int[1] ;
         T001L6_n69AreCod = new bool[] {false} ;
         T001L7_A69AreCod = new int[1] ;
         T001L7_n69AreCod = new bool[] {false} ;
         T001L2_A69AreCod = new int[1] ;
         T001L2_n69AreCod = new bool[] {false} ;
         T001L2_A474AreDsc = new string[] {""} ;
         T001L2_A475AreSts = new short[1] ;
         T001L11_A348UsuCod = new string[] {""} ;
         T001L12_A69AreCod = new int[1] ;
         T001L12_n69AreCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ474AreDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.careas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.careas__default(),
            new Object[][] {
                new Object[] {
               T001L2_A69AreCod, T001L2_A474AreDsc, T001L2_A475AreSts
               }
               , new Object[] {
               T001L3_A69AreCod, T001L3_A474AreDsc, T001L3_A475AreSts
               }
               , new Object[] {
               T001L4_A69AreCod, T001L4_A474AreDsc, T001L4_A475AreSts
               }
               , new Object[] {
               T001L5_A69AreCod
               }
               , new Object[] {
               T001L6_A69AreCod
               }
               , new Object[] {
               T001L7_A69AreCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001L11_A348UsuCod
               }
               , new Object[] {
               T001L12_A69AreCod
               }
            }
         );
      }

      private short Z475AreSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A475AreSts ;
      private short GX_JID ;
      private short RcdFound55 ;
      private short nIsDirty_55 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private short ZZ475AreSts ;
      private int Z69AreCod ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int A69AreCod ;
      private int edtAreCod_Enabled ;
      private int bttBtn_get_Visible ;
      private int bttBtn_get_Enabled ;
      private int edtAreDsc_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_check_Visible ;
      private int bttBtn_check_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int bttBtn_help_Visible ;
      private int idxLst ;
      private int ZZ69AreCod ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtAreCod_Internalname ;
      private string cmbAreSts_Internalname ;
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
      private string edtAreCod_Jsonclick ;
      private string bttBtn_get_Internalname ;
      private string bttBtn_get_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtAreDsc_Internalname ;
      private string edtAreDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbAreSts_Jsonclick ;
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
      private string sMode55 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n69AreCod ;
      private string Z474AreDsc ;
      private string A474AreDsc ;
      private string ZZ474AreDsc ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbAreSts ;
      private IDataStoreProvider pr_default ;
      private int[] T001L4_A69AreCod ;
      private bool[] T001L4_n69AreCod ;
      private string[] T001L4_A474AreDsc ;
      private short[] T001L4_A475AreSts ;
      private int[] T001L5_A69AreCod ;
      private bool[] T001L5_n69AreCod ;
      private int[] T001L3_A69AreCod ;
      private bool[] T001L3_n69AreCod ;
      private string[] T001L3_A474AreDsc ;
      private short[] T001L3_A475AreSts ;
      private int[] T001L6_A69AreCod ;
      private bool[] T001L6_n69AreCod ;
      private int[] T001L7_A69AreCod ;
      private bool[] T001L7_n69AreCod ;
      private int[] T001L2_A69AreCod ;
      private bool[] T001L2_n69AreCod ;
      private string[] T001L2_A474AreDsc ;
      private short[] T001L2_A475AreSts ;
      private string[] T001L11_A348UsuCod ;
      private int[] T001L12_A69AreCod ;
      private bool[] T001L12_n69AreCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
   }

   public class careas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class careas__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT001L4;
        prmT001L4 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L5;
        prmT001L5 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L3;
        prmT001L3 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L6;
        prmT001L6 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L7;
        prmT001L7 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L2;
        prmT001L2 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L8;
        prmT001L8 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@AreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@AreSts",GXType.Int16,1,0)
        };
        Object[] prmT001L9;
        prmT001L9 = new Object[] {
        new ParDef("@AreDsc",GXType.NVarChar,100,0) ,
        new ParDef("@AreSts",GXType.Int16,1,0) ,
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L10;
        prmT001L10 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L11;
        prmT001L11 = new Object[] {
        new ParDef("@AreCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT001L12;
        prmT001L12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T001L2", "SELECT [AreCod], [AreDsc], [AreSts] FROM [CAREAS] WITH (UPDLOCK) WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001L3", "SELECT [AreCod], [AreDsc], [AreSts] FROM [CAREAS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001L4", "SELECT TM1.[AreCod], TM1.[AreDsc], TM1.[AreSts] FROM [CAREAS] TM1 WHERE TM1.[AreCod] = @AreCod ORDER BY TM1.[AreCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001L5", "SELECT [AreCod] FROM [CAREAS] WHERE [AreCod] = @AreCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001L6", "SELECT TOP 1 [AreCod] FROM [CAREAS] WHERE ( [AreCod] > @AreCod) ORDER BY [AreCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001L6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001L7", "SELECT TOP 1 [AreCod] FROM [CAREAS] WHERE ( [AreCod] < @AreCod) ORDER BY [AreCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT001L7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001L8", "INSERT INTO [CAREAS]([AreCod], [AreDsc], [AreSts]) VALUES(@AreCod, @AreDsc, @AreSts)", GxErrorMask.GX_NOMASK,prmT001L8)
           ,new CursorDef("T001L9", "UPDATE [CAREAS] SET [AreDsc]=@AreDsc, [AreSts]=@AreSts  WHERE [AreCod] = @AreCod", GxErrorMask.GX_NOMASK,prmT001L9)
           ,new CursorDef("T001L10", "DELETE FROM [CAREAS]  WHERE [AreCod] = @AreCod", GxErrorMask.GX_NOMASK,prmT001L10)
           ,new CursorDef("T001L11", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [AreCod] = @AreCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT001L11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001L12", "SELECT [AreCod] FROM [CAREAS] ORDER BY [AreCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT001L12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
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
