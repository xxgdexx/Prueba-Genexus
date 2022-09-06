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
   public class actarea : GXHttpHandler
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
            Form.Meta.addItem("description", "Area Activo Fijo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtACTAreaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public actarea( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public actarea( IGxContext context )
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
         cmbACTAreaSts = new GXCombobox();
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
         if ( cmbACTAreaSts.ItemCount > 0 )
         {
            A2173ACTAreaSts = (short)(NumberUtil.Val( cmbACTAreaSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0))), "."));
            AssignAttri("", false, "A2173ACTAreaSts", StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTAreaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
            AssignProp("", false, cmbACTAreaSts_Internalname, "Values", cmbACTAreaSts.ToJavascriptSource(), true);
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
            RenderHtmlCloseForm6T187( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         RenderHtmlHeaders( ) ;
         RenderHtmlOpenForm( ) ;
         /* Control Group */
         GxWebStd.gx_group_start( context, grpGroup1_Internalname, "Area", 1, 100, "%", 0, "px", "Group", "", "HLP_ACTAREA.htm");
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
         GxWebStd.gx_bitmap( context, imgImage1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage1_Visible, imgImage1_Enabled, "", "Grabar", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage1_Jsonclick, "'"+""+"'"+",false,"+"'"+"EENTER."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTAREA.htm");
         /* Active images/pictures */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 7,'',false,'',0)\"";
         ClassString = "Image";
         StyleString = "";
         sImgUrl = "(none)";
         GxWebStd.gx_bitmap( context, imgImage2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgImage2_Visible, 1, "", "Salir", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImage2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'SALIR\\'."+"'", StyleString, ClassString, "", "", "", "", ""+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_ACTAREA.htm");
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
         GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Codigo", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTAREA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTAreaCod_Internalname, A2102ACTAreaCod, StringUtil.RTrim( context.localUtil.Format( A2102ACTAreaCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,15);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTAreaCod_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTAreaCod_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTAREA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock2_Internalname, "Area", "", "", lblTextblock2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTAREA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtACTAreaDsc_Internalname, A2172ACTAreaDsc, StringUtil.RTrim( context.localUtil.Format( A2172ACTAreaDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,20);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtACTAreaDsc_Jsonclick, 0, "AttSIG", "", "", "", "", 1, edtACTAreaDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_ACTAREA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "</tr>") ;
         context.WriteHtmlText( "<tr>") ;
         context.WriteHtmlText( "<td>") ;
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblock3_Internalname, "Estado", "", "", lblTextblock3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "LabelSIG", 0, "", 1, 1, 0, 0, "HLP_ACTAREA.htm");
         context.WriteHtmlText( "</td>") ;
         context.WriteHtmlText( "<td>") ;
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbACTAreaSts, cmbACTAreaSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0)), 1, cmbACTAreaSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbACTAreaSts.Enabled, 0, 0, 0, "em", 0, "", "", "AttSIG", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "", true, 1, "HLP_ACTAREA.htm");
         cmbACTAreaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
         AssignProp("", false, cmbACTAreaSts_Internalname, "Values", (string)(cmbACTAreaSts.ToJavascriptSource()), true);
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
            Z2102ACTAreaCod = cgiGet( "Z2102ACTAreaCod");
            Z2172ACTAreaDsc = cgiGet( "Z2172ACTAreaDsc");
            Z2173ACTAreaSts = (short)(context.localUtil.CToN( cgiGet( "Z2173ACTAreaSts"), ".", ","));
            IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
            IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
            Gx_mode = cgiGet( "Mode");
            /* Read variables values. */
            A2102ACTAreaCod = cgiGet( edtACTAreaCod_Internalname);
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
            A2172ACTAreaDsc = cgiGet( edtACTAreaDsc_Internalname);
            AssignAttri("", false, "A2172ACTAreaDsc", A2172ACTAreaDsc);
            cmbACTAreaSts.CurrentValue = cgiGet( cmbACTAreaSts_Internalname);
            A2173ACTAreaSts = (short)(NumberUtil.Val( cgiGet( cmbACTAreaSts_Internalname), "."));
            AssignAttri("", false, "A2173ACTAreaSts", StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
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
               A2102ACTAreaCod = GetPar( "ACTAreaCod");
               AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
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
               InitAll6T187( ) ;
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
         DisableAttributes6T187( ) ;
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

      protected void ResetCaption6T0( )
      {
      }

      protected void ZM6T187( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2172ACTAreaDsc = T006T3_A2172ACTAreaDsc[0];
               Z2173ACTAreaSts = T006T3_A2173ACTAreaSts[0];
            }
            else
            {
               Z2172ACTAreaDsc = A2172ACTAreaDsc;
               Z2173ACTAreaSts = A2173ACTAreaSts;
            }
         }
         if ( GX_JID == -1 )
         {
            Z2102ACTAreaCod = A2102ACTAreaCod;
            Z2172ACTAreaDsc = A2172ACTAreaDsc;
            Z2173ACTAreaSts = A2173ACTAreaSts;
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

      protected void Load6T187( )
      {
         /* Using cursor T006T4 */
         pr_default.execute(2, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound187 = 1;
            A2172ACTAreaDsc = T006T4_A2172ACTAreaDsc[0];
            AssignAttri("", false, "A2172ACTAreaDsc", A2172ACTAreaDsc);
            A2173ACTAreaSts = T006T4_A2173ACTAreaSts[0];
            AssignAttri("", false, "A2173ACTAreaSts", StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
            ZM6T187( -1) ;
         }
         pr_default.close(2);
         OnLoadActions6T187( ) ;
      }

      protected void OnLoadActions6T187( )
      {
      }

      protected void CheckExtendedTable6T187( )
      {
         nIsDirty_187 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors6T187( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey6T187( )
      {
         /* Using cursor T006T5 */
         pr_default.execute(3, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound187 = 1;
         }
         else
         {
            RcdFound187 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006T3 */
         pr_default.execute(1, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6T187( 1) ;
            RcdFound187 = 1;
            A2102ACTAreaCod = T006T3_A2102ACTAreaCod[0];
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
            A2172ACTAreaDsc = T006T3_A2172ACTAreaDsc[0];
            AssignAttri("", false, "A2172ACTAreaDsc", A2172ACTAreaDsc);
            A2173ACTAreaSts = T006T3_A2173ACTAreaSts[0];
            AssignAttri("", false, "A2173ACTAreaSts", StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
            Z2102ACTAreaCod = A2102ACTAreaCod;
            sMode187 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load6T187( ) ;
            if ( AnyError == 1 )
            {
               RcdFound187 = 0;
               InitializeNonKey6T187( ) ;
            }
            Gx_mode = sMode187;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound187 = 0;
            InitializeNonKey6T187( ) ;
            sMode187 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode187;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6T187( ) ;
         if ( RcdFound187 == 0 )
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
         RcdFound187 = 0;
         /* Using cursor T006T6 */
         pr_default.execute(4, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T006T6_A2102ACTAreaCod[0], A2102ACTAreaCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T006T6_A2102ACTAreaCod[0], A2102ACTAreaCod) > 0 ) ) )
            {
               A2102ACTAreaCod = T006T6_A2102ACTAreaCod[0];
               AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
               RcdFound187 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound187 = 0;
         /* Using cursor T006T7 */
         pr_default.execute(5, new Object[] {A2102ACTAreaCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T006T7_A2102ACTAreaCod[0], A2102ACTAreaCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T006T7_A2102ACTAreaCod[0], A2102ACTAreaCod) < 0 ) ) )
            {
               A2102ACTAreaCod = T006T7_A2102ACTAreaCod[0];
               AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
               RcdFound187 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6T187( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtACTAreaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6T187( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound187 == 1 )
            {
               if ( StringUtil.StrCmp(A2102ACTAreaCod, Z2102ACTAreaCod) != 0 )
               {
                  A2102ACTAreaCod = Z2102ACTAreaCod;
                  AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ACTAREACOD");
                  AnyError = 1;
                  GX_FocusControl = edtACTAreaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtACTAreaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update6T187( ) ;
                  GX_FocusControl = edtACTAreaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A2102ACTAreaCod, Z2102ACTAreaCod) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtACTAreaCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6T187( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ACTAREACOD");
                     AnyError = 1;
                     GX_FocusControl = edtACTAreaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtACTAreaCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6T187( ) ;
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
         if ( StringUtil.StrCmp(A2102ACTAreaCod, Z2102ACTAreaCod) != 0 )
         {
            A2102ACTAreaCod = Z2102ACTAreaCod;
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ACTAREACOD");
            AnyError = 1;
            GX_FocusControl = edtACTAreaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtACTAreaCod_Internalname;
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
         if ( RcdFound187 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "ACTAREACOD");
            AnyError = 1;
            GX_FocusControl = edtACTAreaCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtACTAreaDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart6T187( ) ;
         if ( RcdFound187 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTAreaDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6T187( ) ;
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
         if ( RcdFound187 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTAreaDsc_Internalname;
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
         if ( RcdFound187 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTAreaDsc_Internalname;
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
         ScanStart6T187( ) ;
         if ( RcdFound187 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound187 != 0 )
            {
               ScanNext6T187( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtACTAreaDsc_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd6T187( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency6T187( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006T2 */
            pr_default.execute(0, new Object[] {A2102ACTAreaCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTAREA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2172ACTAreaDsc, T006T2_A2172ACTAreaDsc[0]) != 0 ) || ( Z2173ACTAreaSts != T006T2_A2173ACTAreaSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z2172ACTAreaDsc, T006T2_A2172ACTAreaDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("actarea:[seudo value changed for attri]"+"ACTAreaDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2172ACTAreaDsc);
                  GXUtil.WriteLogRaw("Current: ",T006T2_A2172ACTAreaDsc[0]);
               }
               if ( Z2173ACTAreaSts != T006T2_A2173ACTAreaSts[0] )
               {
                  GXUtil.WriteLog("actarea:[seudo value changed for attri]"+"ACTAreaSts");
                  GXUtil.WriteLogRaw("Old: ",Z2173ACTAreaSts);
                  GXUtil.WriteLogRaw("Current: ",T006T2_A2173ACTAreaSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"ACTAREA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6T187( )
      {
         BeforeValidate6T187( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6T187( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6T187( 0) ;
            CheckOptimisticConcurrency6T187( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6T187( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6T187( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006T8 */
                     pr_default.execute(6, new Object[] {A2102ACTAreaCod, A2172ACTAreaDsc, A2173ACTAreaSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTAREA");
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
                           ResetCaption6T0( ) ;
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
               Load6T187( ) ;
            }
            EndLevel6T187( ) ;
         }
         CloseExtendedTableCursors6T187( ) ;
      }

      protected void Update6T187( )
      {
         BeforeValidate6T187( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6T187( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6T187( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6T187( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6T187( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006T9 */
                     pr_default.execute(7, new Object[] {A2172ACTAreaDsc, A2173ACTAreaSts, A2102ACTAreaCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("ACTAREA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"ACTAREA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6T187( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption6T0( ) ;
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
            EndLevel6T187( ) ;
         }
         CloseExtendedTableCursors6T187( ) ;
      }

      protected void DeferredUpdate6T187( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate6T187( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6T187( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6T187( ) ;
            AfterConfirm6T187( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6T187( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006T10 */
                  pr_default.execute(8, new Object[] {A2102ACTAreaCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("ACTAREA");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound187 == 0 )
                        {
                           InitAll6T187( ) ;
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
                        ResetCaption6T0( ) ;
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
         sMode187 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6T187( ) ;
         Gx_mode = sMode187;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6T187( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006T11 */
            pr_default.execute(9, new Object[] {A2102ACTAreaCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Activo Fijo"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T006T12 */
            pr_default.execute(10, new Object[] {A2102ACTAreaCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ACTACTIVOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel6T187( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6T187( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("actarea",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("actarea",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6T187( )
      {
         /* Using cursor T006T13 */
         pr_default.execute(11);
         RcdFound187 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound187 = 1;
            A2102ACTAreaCod = T006T13_A2102ACTAreaCod[0];
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6T187( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound187 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound187 = 1;
            A2102ACTAreaCod = T006T13_A2102ACTAreaCod[0];
            AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
         }
      }

      protected void ScanEnd6T187( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm6T187( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert6T187( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6T187( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6T187( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6T187( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6T187( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6T187( )
      {
         edtACTAreaCod_Enabled = 0;
         AssignProp("", false, edtACTAreaCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTAreaCod_Enabled), 5, 0), true);
         edtACTAreaDsc_Enabled = 0;
         AssignProp("", false, edtACTAreaDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtACTAreaDsc_Enabled), 5, 0), true);
         cmbACTAreaSts.Enabled = 0;
         AssignProp("", false, cmbACTAreaSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbACTAreaSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6T187( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6T0( )
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
         context.SendWebValue( "Area Activo Fijo") ;
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
         context.AddJavascriptSource("gxcfg.js", "?202281810264739", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"Form\" data-gx-class=\"Form\" novalidate action=\""+formatLink("actarea.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z2102ACTAreaCod", Z2102ACTAreaCod);
         GxWebStd.gx_hidden_field( context, "Z2172ACTAreaDsc", Z2172ACTAreaDsc);
         GxWebStd.gx_hidden_field( context, "Z2173ACTAreaSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2173ACTAreaSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
      }

      protected void RenderHtmlCloseForm6T187( )
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
         return "ACTAREA" ;
      }

      public override string GetPgmdesc( )
      {
         return "Area Activo Fijo" ;
      }

      protected void InitializeNonKey6T187( )
      {
         A2172ACTAreaDsc = "";
         AssignAttri("", false, "A2172ACTAreaDsc", A2172ACTAreaDsc);
         A2173ACTAreaSts = 0;
         AssignAttri("", false, "A2173ACTAreaSts", StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
         Z2172ACTAreaDsc = "";
         Z2173ACTAreaSts = 0;
      }

      protected void InitAll6T187( )
      {
         A2102ACTAreaCod = "";
         AssignAttri("", false, "A2102ACTAreaCod", A2102ACTAreaCod);
         InitializeNonKey6T187( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810264742", true, true);
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
         context.AddJavascriptSource("actarea.js", "?202281810264742", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         imgImage1_Internalname = "IMAGE1";
         imgImage2_Internalname = "IMAGE2";
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtACTAreaCod_Internalname = "ACTAREACOD";
         lblTextblock2_Internalname = "TEXTBLOCK2";
         edtACTAreaDsc_Internalname = "ACTAREADSC";
         lblTextblock3_Internalname = "TEXTBLOCK3";
         cmbACTAreaSts_Internalname = "ACTAREASTS";
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
         cmbACTAreaSts_Jsonclick = "";
         cmbACTAreaSts.Enabled = 1;
         edtACTAreaDsc_Jsonclick = "";
         edtACTAreaDsc_Enabled = 1;
         edtACTAreaCod_Jsonclick = "";
         edtACTAreaCod_Enabled = 1;
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
         cmbACTAreaSts.Name = "ACTAREASTS";
         cmbACTAreaSts.WebTags = "";
         cmbACTAreaSts.addItem("1", "Activo", 0);
         cmbACTAreaSts.addItem("0", "Inactivo", 0);
         if ( cmbACTAreaSts.ItemCount > 0 )
         {
            A2173ACTAreaSts = (short)(NumberUtil.Val( cmbACTAreaSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0))), "."));
            AssignAttri("", false, "A2173ACTAreaSts", StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtACTAreaDsc_Internalname;
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

      public void Valid_Actareacod( )
      {
         A2173ACTAreaSts = (short)(NumberUtil.Val( cmbACTAreaSts.CurrentValue, "."));
         cmbACTAreaSts.CurrentValue = StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbACTAreaSts.ItemCount > 0 )
         {
            A2173ACTAreaSts = (short)(NumberUtil.Val( cmbACTAreaSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0))), "."));
            cmbACTAreaSts.CurrentValue = StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbACTAreaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A2172ACTAreaDsc", A2172ACTAreaDsc);
         AssignAttri("", false, "A2173ACTAreaSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(A2173ACTAreaSts), 1, 0, ".", "")));
         cmbACTAreaSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2173ACTAreaSts), 1, 0));
         AssignProp("", false, cmbACTAreaSts_Internalname, "Values", cmbACTAreaSts.ToJavascriptSource(), true);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z2102ACTAreaCod", Z2102ACTAreaCod);
         GxWebStd.gx_hidden_field( context, "Z2172ACTAreaDsc", Z2172ACTAreaDsc);
         GxWebStd.gx_hidden_field( context, "Z2173ACTAreaSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2173ACTAreaSts), 1, 0, ".", "")));
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
         setEventMetadata("VALID_ACTAREACOD","{handler:'Valid_Actareacod',iparms:[{av:'cmbACTAreaSts'},{av:'A2173ACTAreaSts',fld:'ACTAREASTS',pic:'9'},{av:'A2102ACTAreaCod',fld:'ACTAREACOD',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_ACTAREACOD",",oparms:[{av:'A2172ACTAreaDsc',fld:'ACTAREADSC',pic:''},{av:'cmbACTAreaSts'},{av:'A2173ACTAreaSts',fld:'ACTAREASTS',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z2102ACTAreaCod'},{av:'Z2172ACTAreaDsc'},{av:'Z2173ACTAreaSts'},{av:'imgImage1_Enabled',ctrl:'IMAGE1',prop:'Enabled'}]}");
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
         Z2102ACTAreaCod = "";
         Z2172ACTAreaDsc = "";
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
         A2102ACTAreaCod = "";
         lblTextblock2_Jsonclick = "";
         A2172ACTAreaDsc = "";
         lblTextblock3_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         T006T4_A2102ACTAreaCod = new string[] {""} ;
         T006T4_A2172ACTAreaDsc = new string[] {""} ;
         T006T4_A2173ACTAreaSts = new short[1] ;
         T006T5_A2102ACTAreaCod = new string[] {""} ;
         T006T3_A2102ACTAreaCod = new string[] {""} ;
         T006T3_A2172ACTAreaDsc = new string[] {""} ;
         T006T3_A2173ACTAreaSts = new short[1] ;
         sMode187 = "";
         T006T6_A2102ACTAreaCod = new string[] {""} ;
         T006T7_A2102ACTAreaCod = new string[] {""} ;
         T006T2_A2102ACTAreaCod = new string[] {""} ;
         T006T2_A2172ACTAreaDsc = new string[] {""} ;
         T006T2_A2173ACTAreaSts = new short[1] ;
         T006T11_A2109AMovCod = new string[] {""} ;
         T006T12_A2100ACTActCod = new string[] {""} ;
         T006T13_A2102ACTAreaCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ2102ACTAreaCod = "";
         ZZ2172ACTAreaDsc = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.actarea__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.actarea__default(),
            new Object[][] {
                new Object[] {
               T006T2_A2102ACTAreaCod, T006T2_A2172ACTAreaDsc, T006T2_A2173ACTAreaSts
               }
               , new Object[] {
               T006T3_A2102ACTAreaCod, T006T3_A2172ACTAreaDsc, T006T3_A2173ACTAreaSts
               }
               , new Object[] {
               T006T4_A2102ACTAreaCod, T006T4_A2172ACTAreaDsc, T006T4_A2173ACTAreaSts
               }
               , new Object[] {
               T006T5_A2102ACTAreaCod
               }
               , new Object[] {
               T006T6_A2102ACTAreaCod
               }
               , new Object[] {
               T006T7_A2102ACTAreaCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006T11_A2109AMovCod
               }
               , new Object[] {
               T006T12_A2100ACTActCod
               }
               , new Object[] {
               T006T13_A2102ACTAreaCod
               }
            }
         );
      }

      private short Z2173ACTAreaSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nDynComponent ;
      private short A2173ACTAreaSts ;
      private short GX_JID ;
      private short RcdFound187 ;
      private short nIsDirty_187 ;
      private short Gx_BScreen ;
      private short ZZ2173ACTAreaSts ;
      private int trnEnded ;
      private int imgImage1_Visible ;
      private int imgImage1_Enabled ;
      private int imgImage2_Visible ;
      private int edtACTAreaCod_Enabled ;
      private int edtACTAreaDsc_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtACTAreaCod_Internalname ;
      private string cmbACTAreaSts_Internalname ;
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
      private string edtACTAreaCod_Jsonclick ;
      private string lblTextblock2_Internalname ;
      private string lblTextblock2_Jsonclick ;
      private string edtACTAreaDsc_Internalname ;
      private string edtACTAreaDsc_Jsonclick ;
      private string lblTextblock3_Internalname ;
      private string lblTextblock3_Jsonclick ;
      private string cmbACTAreaSts_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode187 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private string Z2102ACTAreaCod ;
      private string Z2172ACTAreaDsc ;
      private string A2102ACTAreaCod ;
      private string A2172ACTAreaDsc ;
      private string ZZ2102ACTAreaCod ;
      private string ZZ2172ACTAreaDsc ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbACTAreaSts ;
      private IDataStoreProvider pr_default ;
      private string[] T006T4_A2102ACTAreaCod ;
      private string[] T006T4_A2172ACTAreaDsc ;
      private short[] T006T4_A2173ACTAreaSts ;
      private string[] T006T5_A2102ACTAreaCod ;
      private string[] T006T3_A2102ACTAreaCod ;
      private string[] T006T3_A2172ACTAreaDsc ;
      private short[] T006T3_A2173ACTAreaSts ;
      private string[] T006T6_A2102ACTAreaCod ;
      private string[] T006T7_A2102ACTAreaCod ;
      private string[] T006T2_A2102ACTAreaCod ;
      private string[] T006T2_A2172ACTAreaDsc ;
      private short[] T006T2_A2173ACTAreaSts ;
      private string[] T006T11_A2109AMovCod ;
      private string[] T006T12_A2100ACTActCod ;
      private string[] T006T13_A2102ACTAreaCod ;
      private IDataStoreProvider pr_datastore2 ;
   }

   public class actarea__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class actarea__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT006T4;
        prmT006T4 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T5;
        prmT006T5 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T3;
        prmT006T3 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T6;
        prmT006T6 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T7;
        prmT006T7 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T2;
        prmT006T2 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T8;
        prmT006T8 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0) ,
        new ParDef("@ACTAreaDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTAreaSts",GXType.Int16,1,0)
        };
        Object[] prmT006T9;
        prmT006T9 = new Object[] {
        new ParDef("@ACTAreaDsc",GXType.NVarChar,100,0) ,
        new ParDef("@ACTAreaSts",GXType.Int16,1,0) ,
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T10;
        prmT006T10 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T11;
        prmT006T11 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T12;
        prmT006T12 = new Object[] {
        new ParDef("@ACTAreaCod",GXType.NVarChar,5,0)
        };
        Object[] prmT006T13;
        prmT006T13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T006T2", "SELECT [ACTAreaCod], [ACTAreaDsc], [ACTAreaSts] FROM [ACTAREA] WITH (UPDLOCK) WHERE [ACTAreaCod] = @ACTAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006T3", "SELECT [ACTAreaCod], [ACTAreaDsc], [ACTAreaSts] FROM [ACTAREA] WHERE [ACTAreaCod] = @ACTAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006T4", "SELECT TM1.[ACTAreaCod], TM1.[ACTAreaDsc], TM1.[ACTAreaSts] FROM [ACTAREA] TM1 WHERE TM1.[ACTAreaCod] = @ACTAreaCod ORDER BY TM1.[ACTAreaCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006T4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006T5", "SELECT [ACTAreaCod] FROM [ACTAREA] WHERE [ACTAreaCod] = @ACTAreaCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006T6", "SELECT TOP 1 [ACTAreaCod] FROM [ACTAREA] WHERE ( [ACTAreaCod] > @ACTAreaCod) ORDER BY [ACTAreaCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006T6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006T7", "SELECT TOP 1 [ACTAreaCod] FROM [ACTAREA] WHERE ( [ACTAreaCod] < @ACTAreaCod) ORDER BY [ACTAreaCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006T7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006T8", "INSERT INTO [ACTAREA]([ACTAreaCod], [ACTAreaDsc], [ACTAreaSts]) VALUES(@ACTAreaCod, @ACTAreaDsc, @ACTAreaSts)", GxErrorMask.GX_NOMASK,prmT006T8)
           ,new CursorDef("T006T9", "UPDATE [ACTAREA] SET [ACTAreaDsc]=@ACTAreaDsc, [ACTAreaSts]=@ACTAreaSts  WHERE [ACTAreaCod] = @ACTAreaCod", GxErrorMask.GX_NOMASK,prmT006T9)
           ,new CursorDef("T006T10", "DELETE FROM [ACTAREA]  WHERE [ACTAreaCod] = @ACTAreaCod", GxErrorMask.GX_NOMASK,prmT006T10)
           ,new CursorDef("T006T11", "SELECT TOP 1 [AMovCod] FROM [ACTMOVACTIVO] WHERE [AMovAreaCod] = @ACTAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006T11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006T12", "SELECT TOP 1 [ACTActCod] FROM [ACTACTIVOS] WHERE [ACTAreaCod] = @ACTAreaCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006T12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006T13", "SELECT [ACTAreaCod] FROM [ACTAREA] ORDER BY [ACTAreaCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006T13,100, GxCacheFrequency.OFF ,true,false )
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
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
