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
   public class actubicacion : GXHttpHandler
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
            Form.Meta.addItem("description", "Familia de Activos Fijos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtActUbiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actubicacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actubicacion( IGxContext context )
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
         cmbActUbiSts = new GXCombobox();
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
         if ( cmbActUbiSts.ItemCount > 0 )
         {
            A2232ActUbiSts = (short)(NumberUtil.Val( cmbActUbiSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0))), "."));
            AssignAttri("", false, "A2232ActUbiSts", StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbActUbiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
            AssignProp("", false, cmbActUbiSts_Internalname, "Values", cmbActUbiSts.ToJavascriptSource(), true);
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
            /* Event 'Enter' not assigned to any button. */
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
            RenderHtmlCloseForm73197( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Control Group */
         GxWebStd.gx_group_start( context, grpGroup1_Internalname, "Familia", 1, 0, "px", 0, "px", "Group", "", "HLP_ACTUBICACION.htm");
         /* Table start */
         sStyleString = "";
         GxWebStd.gx_table_start( context, tblTable2_Internalname, tblTable2_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
         context.WriteHtmlText( "<tbody>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td colspan=\"2\" >") ;
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 6,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         sImgUrl = "(none)";
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, imgImage1_Enabled, "", "Grabar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EENTER."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTUBICACION.htm");
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         sImgUrl = "(none)";
         GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage2_Visible, 1, "", "Salir", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'SALIR\\'."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTUBICACION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td colspan=\"2\" >") ;
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTUBICACION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActUbiCod_Internalname, A2101ActUbiCod, StringUtil.RTrim( context.localUtil.Format( A2101ActUbiCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActUbiCod_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtActUbiCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTUBICACION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Familia", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTUBICACION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtActUbiDsc_Internalname, A2231ActUbiDsc, StringUtil.RTrim( context.localUtil.Format( A2231ActUbiDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtActUbiDsc_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtActUbiDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTUBICACION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTUBICACION.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbActUbiSts, cmbActUbiSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0)), 1, cmbActUbiSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbActUbiSts.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 1, "HLP_ACTUBICACION.htm");
         cmbActUbiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
         AssignProp("", false, cmbActUbiSts_Internalname, "Values", (string)(cmbActUbiSts.ToJavascriptSource()), true);
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td colspan=\"2\" >") ;
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "</tbody>") ;
         /* End of table */
         context.WriteHtmlText( "</table>") ;
         context.WriteHtmlText( "</fieldset>") ;
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
            Z2101ActUbiCod = cgiGet( "Z2101ActUbiCod");
            Z2231ActUbiDsc = cgiGet( "Z2231ActUbiDsc");
            Z2232ActUbiSts = (short)(context.localUtil.CToN( cgiGet( "Z2232ActUbiSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2101ActUbiCod = cgiGet( edtActUbiCod_Internalname);
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
            A2231ActUbiDsc = cgiGet( edtActUbiDsc_Internalname);
            AssignAttri("", false, "A2231ActUbiDsc", A2231ActUbiDsc);
            cmbActUbiSts.CurrentValue = cgiGet( cmbActUbiSts_Internalname);
            A2232ActUbiSts = (short)(NumberUtil.Val( cgiGet( cmbActUbiSts_Internalname), "."));
            AssignAttri("", false, "A2232ActUbiSts", StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
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
               A2101ActUbiCod = GetPar( "ActUbiCod");
               AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
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
                     else if ( StringUtil.StrCmp(sEvt, "'SALIR'") == 0 )
                     {
                        context.wbHandled = 1;
                        dynload_actions( ) ;
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
               InitAll73197( ) ;
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
      }

      protected void disable_std_buttons_dsp( )
      {
         if ( IsDsp( ) )
         {
            imgImage1_Visible = 0;
            AssignProp("", false, imgImage1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgImage1_Visible), 5, 0), true);
         }
         DisableAttributes73197( ) ;
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

      protected void ResetCaption730( )
      {
      }

      protected void ZM73197( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2231ActUbiDsc = T00733_A2231ActUbiDsc[0];
               Z2232ActUbiSts = T00733_A2232ActUbiSts[0];
            }
            else
            {
               Z2231ActUbiDsc = A2231ActUbiDsc;
               Z2232ActUbiSts = A2232ActUbiSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2101ActUbiCod = A2101ActUbiCod;
            Z2231ActUbiDsc = A2231ActUbiDsc;
            Z2232ActUbiSts = A2232ActUbiSts;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            imgImage1_Enabled = 0;
            AssignProp("", false, imgImage1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImage1_Enabled), 5, 0), true);
         }
         else
         {
            imgImage1_Enabled = 1;
            AssignProp("", false, imgImage1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImage1_Enabled), 5, 0), true);
         }
      }

      protected void Load73197( )
      {
         /* Using cursor T00734 */
         pr_default.execute(2, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound197 = 1;
            A2231ActUbiDsc = T00734_A2231ActUbiDsc[0];
            AssignAttri("", false, "A2231ActUbiDsc", A2231ActUbiDsc);
            A2232ActUbiSts = T00734_A2232ActUbiSts[0];
            AssignAttri("", false, "A2232ActUbiSts", StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
            ZM73197( -1) ;
         }
         pr_default.close(2);
         OnLoadActions73197( ) ;
      }

      protected void OnLoadActions73197( )
      {
      }

      protected void CheckExtendedTable73197( )
      {
         nIsDirty_197 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors73197( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey73197( )
      {
         /* Using cursor T00735 */
         pr_default.execute(3, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound197 = 1;
         }
         else
         {
            RcdFound197 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00733 */
         pr_default.execute(1, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM73197( 1) ;
            RcdFound197 = 1;
            A2101ActUbiCod = T00733_A2101ActUbiCod[0];
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
            A2231ActUbiDsc = T00733_A2231ActUbiDsc[0];
            AssignAttri("", false, "A2231ActUbiDsc", A2231ActUbiDsc);
            A2232ActUbiSts = T00733_A2232ActUbiSts[0];
            AssignAttri("", false, "A2232ActUbiSts", StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
            Z2101ActUbiCod = A2101ActUbiCod;
            sMode197 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load73197( ) ;
            if ( AnyError == 1 )
            {
               RcdFound197 = 0;
               InitializeNonKey73197( ) ;
            }
            Gx_mode = sMode197;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound197 = 0;
            InitializeNonKey73197( ) ;
            sMode197 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode197;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey73197( ) ;
         if ( RcdFound197 == 0 )
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
         RcdFound197 = 0;
         /* Using cursor T00736 */
         pr_default.execute(4, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00736_A2101ActUbiCod[0], A2101ActUbiCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00736_A2101ActUbiCod[0], A2101ActUbiCod) > 0 ) ) )
            {
               A2101ActUbiCod = T00736_A2101ActUbiCod[0];
               AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
               RcdFound197 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound197 = 0;
         /* Using cursor T00737 */
         pr_default.execute(5, new Object[] {A2101ActUbiCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00737_A2101ActUbiCod[0], A2101ActUbiCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00737_A2101ActUbiCod[0], A2101ActUbiCod) < 0 ) ) )
            {
               A2101ActUbiCod = T00737_A2101ActUbiCod[0];
               AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
               RcdFound197 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey73197( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtActUbiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert73197( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound197 == 1 )
            {
               if ( StringUtil.StrCmp(A2101ActUbiCod, Z2101ActUbiCod) != 0 )
               {
                  A2101ActUbiCod = Z2101ActUbiCod;
                  AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTUBICOD");
                  AnyError = 1;
                  GX_FocusControl = edtActUbiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtActUbiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update73197( ) ;
                  GX_FocusControl = edtActUbiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2101ActUbiCod, Z2101ActUbiCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtActUbiCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert73197( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTUBICOD");
                     AnyError = 1;
                     GX_FocusControl = edtActUbiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtActUbiCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert73197( ) ;
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
         if ( StringUtil.StrCmp(A2101ActUbiCod, Z2101ActUbiCod) != 0 )
         {
            A2101ActUbiCod = Z2101ActUbiCod;
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTUBICOD");
            AnyError = 1;
            GX_FocusControl = edtActUbiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtActUbiCod_Internalname;
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

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound197 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTUBICOD");
            AnyError = 1;
            GX_FocusControl = edtActUbiCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtActUbiDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart73197( ) ;
         if ( RcdFound197 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActUbiDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd73197( ) ;
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
         if ( RcdFound197 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActUbiDsc_Internalname;
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
         if ( RcdFound197 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActUbiDsc_Internalname;
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
         ScanStart73197( ) ;
         if ( RcdFound197 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound197 != 0 )
            {
               ScanNext73197( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtActUbiDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd73197( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency73197( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00732 */
            pr_default.execute(0, new Object[] {A2101ActUbiCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTUBICACION"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2231ActUbiDsc, T00732_A2231ActUbiDsc[0]) != 0 ) || ( Z2232ActUbiSts != T00732_A2232ActUbiSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z2231ActUbiDsc, T00732_A2231ActUbiDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actubicacion:[seudo value changed for attri]"+"ActUbiDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2231ActUbiDsc);
                  GXUtil.WriteLogRaw("Current: ",T00732_A2231ActUbiDsc[0]);
               }
               if ( Z2232ActUbiSts != T00732_A2232ActUbiSts[0] )
               {
                  GXUtil.WriteLog("actubicacion:[seudo value changed for attri]"+"ActUbiSts");
                  GXUtil.WriteLogRaw("Old: ",Z2232ActUbiSts);
                  GXUtil.WriteLogRaw("Current: ",T00732_A2232ActUbiSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTUBICACION"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert73197( )
      {
         BeforeValidate73197( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable73197( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM73197( 0) ;
            CheckOptimisticConcurrency73197( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm73197( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert73197( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00738 */
                     pr_default.execute(6, new Object[] {A2101ActUbiCod, A2231ActUbiDsc, A2232ActUbiSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTUBICACION");
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
                           ResetCaption730( ) ;
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
               Load73197( ) ;
            }
            EndLevel73197( ) ;
         }
         CloseExtendedTableCursors73197( ) ;
      }

      protected void Update73197( )
      {
         BeforeValidate73197( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable73197( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency73197( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm73197( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate73197( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00739 */
                     pr_default.execute(7, new Object[] {A2231ActUbiDsc, A2232ActUbiSts, A2101ActUbiCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTUBICACION");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTUBICACION"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate73197( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption730( ) ;
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
            EndLevel73197( ) ;
         }
         CloseExtendedTableCursors73197( ) ;
      }

      protected void DeferredUpdate73197( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate73197( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency73197( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls73197( ) ;
            AfterConfirm73197( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete73197( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T007310 */
                  pr_default.execute(8, new Object[] {A2101ActUbiCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTUBICACION");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound197 == 0 )
                        {
                           InitAll73197( ) ;
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
                        ResetCaption730( ) ;
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
         sMode197 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel73197( ) ;
         Gx_mode = sMode197;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls73197( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T007311 */
            pr_default.execute(9, new Object[] {A2101ActUbiCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACTACTIVOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel73197( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete73197( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actubicacion",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues730( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actubicacion",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart73197( )
      {
         /* Using cursor T007312 */
         pr_default.execute(10);
         RcdFound197 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound197 = 1;
            A2101ActUbiCod = T007312_A2101ActUbiCod[0];
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext73197( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound197 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound197 = 1;
            A2101ActUbiCod = T007312_A2101ActUbiCod[0];
            AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
         }
      }

      protected void ScanEnd73197( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm73197( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert73197( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate73197( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete73197( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete73197( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate73197( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes73197( )
      {
         edtActUbiCod_Enabled = 0;
         AssignProp("", false, edtActUbiCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActUbiCod_Enabled), 5, 0), true);
         edtActUbiDsc_Enabled = 0;
         AssignProp("", false, edtActUbiDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtActUbiDsc_Enabled), 5, 0), true);
         cmbActUbiSts.Enabled = 0;
         AssignProp("", false, cmbActUbiSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbActUbiSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes73197( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues730( )
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
         context.SendWebValue( "Familia de Activos Fijos") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810265539", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("actubicacion.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2101ActUbiCod", Z2101ActUbiCod);
         GxWebStd.gx_hidden_field( context, "Z2231ActUbiDsc", Z2231ActUbiDsc);
         GxWebStd.gx_hidden_field( context, "Z2232ActUbiSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2232ActUbiSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm73197( )
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
         return "ACTUBICACION" ;
      }

      public override string GetPgmdesc( )
      {
         return "Familia de Activos Fijos" ;
      }

      protected void InitializeNonKey73197( )
      {
         A2231ActUbiDsc = "";
         AssignAttri("", false, "A2231ActUbiDsc", A2231ActUbiDsc);
         A2232ActUbiSts = 0;
         AssignAttri("", false, "A2232ActUbiSts", StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
         Z2231ActUbiDsc = "";
         Z2232ActUbiSts = 0;
      }

      protected void InitAll73197( )
      {
         A2101ActUbiCod = "";
         AssignAttri("", false, "A2101ActUbiCod", A2101ActUbiCod);
         InitializeNonKey73197( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810265543", true, true);
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
         context.AddJavascriptSource("actubicacion.js", "?202281810265543", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtActUbiCod_Internalname = "ACTUBICOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtActUbiDsc_Internalname = "ACTUBIDSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbActUbiSts_Internalname = "ACTUBISTS";
         tblTable2_Internalname = "TABLE2";
         grpGroup1_Internalname = "GROUP1";
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
         cmbActUbiSts_Jsonclick = "";
         cmbActUbiSts.Enabled = 1;
         edtActUbiDsc_Jsonclick = "";
         edtActUbiDsc_Enabled = 1;
         edtActUbiCod_Jsonclick = "";
         edtActUbiCod_Enabled = 1;
         imgImage2_Visible = 1;
         imgImage1_Enabled = 1;
         imgImage1_Visible = 1;
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
         cmbActUbiSts.Name = "ACTUBISTS";
         cmbActUbiSts.WebTags = "";
         cmbActUbiSts.addItem("1", "Activo", 0);
         cmbActUbiSts.addItem("0", "Inactivo", 0);
         if ( cmbActUbiSts.ItemCount > 0 )
         {
            A2232ActUbiSts = (short)(NumberUtil.Val( cmbActUbiSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0))), "."));
            AssignAttri("", false, "A2232ActUbiSts", StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtActUbiDsc_Internalname;
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

      public void Valid_Actubicod( )
      {
         A2232ActUbiSts = (short)(NumberUtil.Val( cmbActUbiSts.CurrentValue, "."));
         cmbActUbiSts.CurrentValue = StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbActUbiSts.ItemCount > 0 )
         {
            A2232ActUbiSts = (short)(NumberUtil.Val( cmbActUbiSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0))), "."));
            cmbActUbiSts.CurrentValue = StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbActUbiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2231ActUbiDsc", A2231ActUbiDsc);
         AssignAttri("", false, "A2232ActUbiSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2232ActUbiSts), 1, 0, ".", "")));
         cmbActUbiSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2232ActUbiSts), 1, 0));
         AssignProp("", false, cmbActUbiSts_Internalname, "Values", cmbActUbiSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2101ActUbiCod", Z2101ActUbiCod);
         GxWebStd.gx_hidden_field( context, "Z2231ActUbiDsc", Z2231ActUbiDsc);
         GxWebStd.gx_hidden_field( context, "Z2232ActUbiSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2232ActUbiSts), 1, 0, ".", "")));
         AssignProp("", false, imgImage1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgImage1_Enabled), 5, 0), true);
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
         setEventMetadata("VALID_ACTUBICOD","{handler:'Valid_Actubicod',iparms:[{av:'cmbActUbiSts'},{av:'A2232ActUbiSts',fld:'ACTUBISTS',pic:'9'},{av:'A2101ActUbiCod',fld:'ACTUBICOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTUBICOD",",oparms:[{av:'A2231ActUbiDsc',fld:'ACTUBIDSC',pic:''},{av:'cmbActUbiSts'},{av:'A2232ActUbiSts',fld:'ACTUBISTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2101ActUbiCod'},{av:'Z2231ActUbiDsc'},{av:'Z2232ActUbiSts'},{av:'imgImage1_Enabled',ctrl:'IMAGE1',prop:'Enabled'}]}");
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
         Z2101ActUbiCod = "";
         Z2231ActUbiDsc = "";
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
         sImgUrl = "";
         imgImage1_Jsonclick = "";
         imgImage2_Jsonclick = "";
         lblTextblock1_Jsonclick = "";
         A2101ActUbiCod = "";
         lblTextblock2_Jsonclick = "";
         A2231ActUbiDsc = "";
         lblTextblock3_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T00734_A2101ActUbiCod = new string[] {""} ;
         T00734_A2231ActUbiDsc = new string[] {""} ;
         T00734_A2232ActUbiSts = new short[1] ;
         T00735_A2101ActUbiCod = new string[] {""} ;
         T00733_A2101ActUbiCod = new string[] {""} ;
         T00733_A2231ActUbiDsc = new string[] {""} ;
         T00733_A2232ActUbiSts = new short[1] ;
         sMode197 = "";
         T00736_A2101ActUbiCod = new string[] {""} ;
         T00737_A2101ActUbiCod = new string[] {""} ;
         T00732_A2101ActUbiCod = new string[] {""} ;
         T00732_A2231ActUbiDsc = new string[] {""} ;
         T00732_A2232ActUbiSts = new short[1] ;
         T007311_A2100ACTActCod = new string[] {""} ;
         T007312_A2101ActUbiCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2101ActUbiCod = "";
         ZZ2231ActUbiDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actubicacion__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actubicacion__default(),
            new Object[][] {
                new Object[] {
               T00732_A2101ActUbiCod, T00732_A2231ActUbiDsc, T00732_A2232ActUbiSts
               }
               , new Object[] {
               T00733_A2101ActUbiCod, T00733_A2231ActUbiDsc, T00733_A2232ActUbiSts
               }
               , new Object[] {
               T00734_A2101ActUbiCod, T00734_A2231ActUbiDsc, T00734_A2232ActUbiSts
               }
               , new Object[] {
               T00735_A2101ActUbiCod
               }
               , new Object[] {
               T00736_A2101ActUbiCod
               }
               , new Object[] {
               T00737_A2101ActUbiCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T007311_A2100ACTActCod
               }
               , new Object[] {
               T007312_A2101ActUbiCod
               }
            }
         );
      }

      private short Z2232ActUbiSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2232ActUbiSts ;
      private short GX_JID ;
      private short RcdFound197 ;
      private short nIsDirty_197 ;
      private short Gx_BScreen ;
      private short ZZ2232ActUbiSts ;
      private int trnEnded ;
      private int imgImage1_Visible ;
      private int imgImage1_Enabled ;
      private int imgImage2_Visible ;
      private int edtActUbiCod_Enabled ;
      private int edtActUbiDsc_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtActUbiCod_Internalname ;
      private string cmbActUbiSts_Internalname ;
      private string grpGroup1_Internalname ;
      private string sStyleString ;
      private string tblTable2_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgImage1_Internalname ;
      private string imgImage1_Jsonclick ;
      private string imgImage2_Internalname ;
      private string imgImage2_Jsonclick ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string edtActUbiCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtActUbiDsc_Internalname ;
      private string edtActUbiDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbActUbiSts_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode197 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z2101ActUbiCod ;
      private string Z2231ActUbiDsc ;
      private string A2101ActUbiCod ;
      private string A2231ActUbiDsc ;
      private string ZZ2101ActUbiCod ;
      private string ZZ2231ActUbiDsc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbActUbiSts ;
      private IDataStoreProvider pr_default ;
      private string[] T00734_A2101ActUbiCod ;
      private string[] T00734_A2231ActUbiDsc ;
      private short[] T00734_A2232ActUbiSts ;
      private string[] T00735_A2101ActUbiCod ;
      private string[] T00733_A2101ActUbiCod ;
      private string[] T00733_A2231ActUbiDsc ;
      private short[] T00733_A2232ActUbiSts ;
      private string[] T00736_A2101ActUbiCod ;
      private string[] T00737_A2101ActUbiCod ;
      private string[] T00732_A2101ActUbiCod ;
      private string[] T00732_A2231ActUbiDsc ;
      private short[] T00732_A2232ActUbiSts ;
      private string[] T007311_A2100ACTActCod ;
      private string[] T007312_A2101ActUbiCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actubicacion__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actubicacion__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00734;
        prmT00734 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00735;
        prmT00735 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00733;
        prmT00733 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00736;
        prmT00736 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00737;
        prmT00737 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00732;
        prmT00732 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT00738;
        prmT00738 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0) ,
        new ParDef("@ActUbiDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ActUbiSts",GXType.Int16,1,0)
        };
        Object[] prmT00739;
        prmT00739 = new Object[] {
        new ParDef("@ActUbiDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ActUbiSts",GXType.Int16,1,0) ,
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007310;
        prmT007310 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007311;
        prmT007311 = new Object[] {
        new ParDef("@ActUbiCod",GXType.NVarChar,5,0)
        };
        Object[] prmT007312;
        prmT007312 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00732", "SELECT [ActUbiCod], [ActUbiDsc], [ActUbiSts] FROM [ACTUBICACION] WITH (UPDLOCK) WHERE [ActUbiCod] = @ActUbiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00732,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00733", "SELECT [ActUbiCod], [ActUbiDsc], [ActUbiSts] FROM [ACTUBICACION] WHERE [ActUbiCod] = @ActUbiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00733,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00734", "SELECT TM1.[ActUbiCod], TM1.[ActUbiDsc], TM1.[ActUbiSts] FROM [ACTUBICACION] TM1 WHERE TM1.[ActUbiCod] = @ActUbiCod ORDER BY TM1.[ActUbiCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00734,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00735", "SELECT [ActUbiCod] FROM [ACTUBICACION] WHERE [ActUbiCod] = @ActUbiCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00735,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00736", "SELECT TOP 1 [ActUbiCod] FROM [ACTUBICACION] WHERE ( [ActUbiCod] > @ActUbiCod) ORDER BY [ActUbiCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00736,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00737", "SELECT TOP 1 [ActUbiCod] FROM [ACTUBICACION] WHERE ( [ActUbiCod] < @ActUbiCod) ORDER BY [ActUbiCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00737,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00738", "INSERT INTO [ACTUBICACION]([ActUbiCod], [ActUbiDsc], [ActUbiSts]) VALUES(@ActUbiCod, @ActUbiDsc, @ActUbiSts)", GxErrorMask.GX_NOMASK,prmT00738)
           ,new CursorDef("T00739", "UPDATE [ACTUBICACION] SET [ActUbiDsc]=@ActUbiDsc, [ActUbiSts]=@ActUbiSts  WHERE [ActUbiCod] = @ActUbiCod", GxErrorMask.GX_NOMASK,prmT00739)
           ,new CursorDef("T007310", "DELETE FROM [ACTUBICACION]  WHERE [ActUbiCod] = @ActUbiCod", GxErrorMask.GX_NOMASK,prmT007310)
           ,new CursorDef("T007311", "SELECT TOP 1 [ACTActCod] FROM [ACTACTIVOS] WHERE [ActUbiCod] = @ActUbiCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT007311,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T007312", "SELECT [ActUbiCod] FROM [ACTUBICACION] ORDER BY [ActUbiCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT007312,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
